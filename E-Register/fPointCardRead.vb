Public Class fPointCardRead

    Private ConArry() As CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private POINT_MEMBER_CODE As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
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

    End Sub
    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property
    <System.Runtime.InteropServices.DllImport("winmm.dll", EntryPoint:="PlaySound")> _
Private Shared Function PlaySound(<System.Runtime.InteropServices.MarshalAs( _
                        System.Runtime.InteropServices.UnmanagedType.LPStr)> _
    ByVal pszSound As String, _
    ByVal hModule As Integer, _
    ByVal dwFlags As Integer) _
    As Integer
    End Function

    Private Sub fMemberSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)

        POINT_MEMBER_CODE_T.Text = ""
        POINT_MEMBER_NAME_T.Text = ""
        SEX_T.Text = ""
        GEN_T.Text = ""
        ENTRY_DATE_T.Text = ""
        REG_S_DATE.Text = ""
        REG_E_DATE.Text = ""
        POST_CODE_T.Text = ""
        ADDRESS_T.Text = ""
        TEL_T.Text = ""
        FAX_T.Text = ""
        E_MAIL_T.Text = ""

    End Sub
    Private Sub POINT_MEMBER_SET()
        Dim RecordCount As Long

        If POINT_MEMBER_CODE <> "" Then
            RecordCount = oMstPointMemberDBIO.getPointMember(oPointMember, _
                                   POINT_MEMBER_CODE, _
                                   POINT_MEMBER_CODE, _
                                   Nothing, _
                                   Nothing, _
                                   1, _
                                   oTran)
            If RecordCount = 0 Then
                Dim Message_form As cMessageLib.fMessage

                Message_form = New cMessageLib.fMessage(1, "ポイント会員コードの登録がありません。", _
                                                "ポイント会員コードを確認して下さい。", _
                                                "", Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                System.Windows.Forms.Application.DoEvents()
                POINT_MEMBER_CODE_T.Text = ""
                POINT_MEMBER_CODE_T.Focus()
                Exit Sub
            Else

                POINT_MEMBER_CODE_T.Text = oPointMember(0).sPointMemberCode
                POINT_MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName
                POST_CODE_T.Text = oPointMember(0).sPostCode
                ADDRESS_T.Text = oPointMember(0).sAddress1 & oPointMember(0).sAddress2 & oPointMember(0).sAddress3
                TEL_T.Text = oPointMember(0).sTEL
                FAX_T.Text = oPointMember(0).sFAX
                E_MAIL_T.Text = oPointMember(0).sMailAddress
                ENTRY_DATE_T.Text = oPointMember(0).sEntryDate
                REG_S_DATE.Text = oPointMember(0).sStartRegistDate
                REG_E_DATE.Text = oPointMember(0).sEndRegistDate
                SEX_T.Text = oPointMember(0).sSex
                GEN_T.Text = oPointMember(0).sAge
                oMstPointMemberDBIO = Nothing
            End If
        End If
    End Sub
    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        'キー入力音出力
        PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        'キー入力音出力
        PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub POINT_MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_SEARCH_B.Click
        Dim fPointMemberSearch_form = New cSelectLib.fPointMemberSearch(oConn, oCommand, oDataReader, oTran)

        'キー入力音出力
        PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)

        fPointMemberSearch_form.ShowDialog()
        If fPointMemberSearch_form.DialogResult = Windows.Forms.DialogResult.OK Then
            POINT_MEMBER_CODE_T.Text = fPointMemberSearch_form.POINT_MEMBER_CODE_T.Text
            POINT_MEMBER_CODE = POINT_MEMBER_CODE_T.Text
            fPointMemberSearch_form.Dispose()
            fPointMemberSearch_form = Nothing

            POINT_MEMBER_SET()
        End If
    End Sub

    Private Sub POINT_MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_CODE_T.LostFocus
        'キー入力音出力
        PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)

        POINT_MEMBER_CODE = POINT_MEMBER_CODE_T.Text
        POINT_MEMBER_SET()

        'COMMIT_B.Focus()
    End Sub
End Class
