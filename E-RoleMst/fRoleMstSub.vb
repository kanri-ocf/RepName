Public Class fRoleMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oRole() As cStructureLib.sRole
    Private oRoleDBIO As cMstRoleDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_ROLE_CODE As Integer
    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyRoleCode As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oConf = iConf

        oTran = iTran

        '新規／更新のモード設定
        If iKeyRoleCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_ROLE_CODE = iKeyRoleCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oRoleDBIO = New cMstRoleDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oStaffDBIO.getStaff(oStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        oTool = New cTool

        IVENT_FLG = False

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "（更新）"
            DELETE_B.Enabled = True
            ROLE_CODE_T.ReadOnly = True
            ROLE_CODE_T.BackColor = Color.White

            'スタッフ情報セット
            ROLE_DISP()

        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "（新規）"
        End If

        IVENT_FLG = True

    End Sub
    Private Sub ROLE_DISP()
        Dim pRole() As cStructureLib.sRole

        ReDim oRole(0)
        oRoleDBIO.getRole(oRole, S_ROLE_CODE, Nothing, oTran)

        ROLE_CODE_T.Text = oRole(0).sRoleCode
        ROLE_CODE_T.ReadOnly = True

        ReDim pRole(0)
        oRoleDBIO.getRole(pRole, oRole(0).sRoleCode, Nothing, oTran)
        ROLE_CODE_T.Text = pRole(0).sRoleCode
        ROLE_NAME_T.Text = pRole(0).sRoleName

    End Sub
    Private Sub INIT_PROC()
        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        ROLE_CODE_T.Text = ""
        ROLE_CODE_T.ReadOnly = False
        ROLE_CODE_T.BackColor = Color.LightGreen
        DELETE_B.Enabled = False
    End Sub
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Private Sub CLOSE_PROC()
        oConn = Nothing
        oRoleDBIO = Nothing
        oStaffDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '役割マスタの削除
        ret = oRoleDBIO.deleteRole(ROLE_CODE_T.Text, oTran)


        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                    "登録が完了しました。", _
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If ROLE_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "役割コードが未入力です。", _
                                             "役割コードを入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            ROLE_CODE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If ROLE_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "役割名称が未入力です。", _
                                             "役割名称を入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            ROLE_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function
    Private Sub COMMIT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '必須入力確認
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        ReDim oRole(0)
        oRole(0).sRoleCode = CInt(ROLE_CODE_T.Text)
        oRole(0).sRoleName = ROLE_NAME_T.Text

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '役割マスタの登録
        If EDIT_MODE = False Then
            ret = oRoleDBIO.insertRole(oRole(0), oTran)
        Else
            ret = oRoleDBIO.updateRole(oRole, oTran)
        End If


        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                        "登録が完了しました。", _
                        Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()
        Message_form = Nothing
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "変更は破棄されます。", _
                                                    "よろしいですか？", _
                                                    Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If

        Message_form = Nothing
        Application.DoEvents()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        CLOSE_PROC()

    End Sub

 End Class
