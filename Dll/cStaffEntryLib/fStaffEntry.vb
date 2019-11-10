Public Class fStaffEntry
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Public STAFF_CODE As String
    Public STAFF_NAME As String

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        oTool = New cTool
        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
    End Sub
    Private Sub fStaffEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        STAFF_CODE_T.Focus()
    End Sub
    Private Sub STAFF_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles STAFF_CODE_T.LostFocus
        Dim RecordCount As Integer
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage

        If STAFF_CODE_T.Text = "" Then
            STAFF_CODE_T.Focus()
            Exit Sub
        End If
        If STAFF_CODE_T.Text = "9999999999999" Then
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Environment.Exit(1)
        End If

        RecordCount = oMstStaffDBIO.getStaff(oStaff, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)
        If RecordCount <> 1 Then

            Message_form = New cMessageLib.fMessage(1, "スタッフコードが登録されていません", _
                                            "スタッフコードを再入力して下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form.Dispose()
            Message_form = Nothing
            STAFF_CODE_T.Text = ""
            STAFF_CODE_T.Focus()
        Else
            STAFF_CODE = oStaff(0).sStaffCode
            STAFF_NAME = oStaff(0).sStaffName

            oMstStaffDBIO = Nothing
            Me.Visible = False

            ret = AUTHORITY_READ()
            If ret = False Then

                Message_form = New cMessageLib.fMessage(1, "このプログラムを実行する権限がありません。", _
                                                "実行する必要がある場合は", _
                                                "システム管理者に権限を付与して頂いて下さい。", Nothing)
                Message_form.ShowDialog()
                System.Windows.Forms.Application.DoEvents()
                Message_form.Dispose()
                Message_form = Nothing
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Environment.Exit(1)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Function AUTHORITY_READ() As Boolean
        Dim oViewStaffAuthorityDBIO As New cViewStaffAuthorityDBIO(oConn, oCommand, oDataReader)
        Dim oViewStaffAuthority() As cStructureLib.sViewStaffAuthority

        ReDim oViewStaffAuthority(0)
        AUTHORITY_READ = oViewStaffAuthorityDBIO.getStaffAuthority(oViewStaffAuthority, STAFF_CODE_T.Text, oTran)

    End Function
    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property



End Class
