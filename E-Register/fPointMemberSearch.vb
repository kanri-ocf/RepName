Public Class fPointMemberSearch

    Private ConArry() As CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iStaffCode As String, _
            ByRef iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

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
    Private Sub fMemberSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        POINT_MEMBER_CODE_T.Focus()
    End Sub

    Private Sub POINT_MEMBER_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_CODE_T.GotFocus
        POINT_MEMBER_CODE_T.SelectAll()
    End Sub

    Private Sub POINT_MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_CODE_T.LostFocus
        Dim RecordCount As Integer

        If POINT_MEMBER_CODE_T.Text = "" Then
            Exit Sub
        End If
        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstPointMemberDBIO.getPointMember(oPointMember, _
                                               POINT_MEMBER_CODE_T.Text, _
                                               POINT_MEMBER_CODE_T.Text, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing, _
                                               oTran)
        If RecordCount = 0 Then
            Dim message_form As New cMessageLib.fMessage(1, _
                      "会員コードが未登録です。", _
                      "再度確認して下さい。", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            oMstPointMemberDBIO = Nothing
            POINT_MEMBER_CODE_T.Text = ""
            POINT_MEMBER_CODE_T.Focus()
            Exit Sub
        End If
        POINT_MEMBER_CODE_T.Text = POINT_MEMBER_CODE_T.Text
        POINT_MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName
        POST_CODE_T.Text = oPointMember(0).sPostCode
        ADDRESS_T.Text = oPointMember(0).sAddress1 & oPointMember(0).sAddress2
        TEL_T.Text = oPointMember(0).sTEL
        FAX_T.Text = oPointMember(0).sFAX
        E_MAIL_T.Text = oPointMember(0).sMailAddress
        ENTRY_DATE_T.Text = oPointMember(0).sEntryDate
        REG_S_DATE.Text = oPointMember(0).sStartRegistDate
        REG_E_DATE.Text = oPointMember(0).sEndRegistDate
        SEX_T.Text = oPointMember(0).sSex
        GEN_T.Text = oPointMember(0).sAge

        oMstPointMemberDBIO = Nothing

    End Sub

    Private Sub POINT_MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_SEARCH_B.Click
        Dim fMember_form As New cSelectLib.fPointMemberSearch(oConn, oCommand, oDataReader, oTran)
        Dim RecordCount As Integer

        fMember_form.ShowDialog()
        If fMember_form.DialogResult = Windows.Forms.DialogResult.Abort Then
            fMember_form.Dispose()
            fMember_form = Nothing
            Exit Sub
        End If

        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstPointMemberDBIO.getPointMember(oPointMember, _
                                                  fMember_form.POINT_MEMBER_CODE_T.Text, _
                                                  fMember_form.POINT_MEMBER_CODE_T.Text, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  oTran)
        POINT_MEMBER_CODE_T.Text = fMember_form.POINT_MEMBER_CODE_T.Text
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
        fMember_form = Nothing
        oMstPointMemberDBIO = Nothing

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click

        '会員の有効性確認
        If POINT_MEMBER_CODE_T.Text <> "" Then
            If (REG_S_DATE.Text > String.Format("{0:yyyy/MM/dd}", Now)) Or (REG_E_DATE.Text < String.Format("{0:yyyy/MM/dd}", Now)) Then
                Dim message_form As New cMessageLib.fMessage(1, Nothing, _
                                 "選択されたポイント会員は現在有効な会員ではありません。", _
                                         "ポイント会員コードを確認して下さい。", Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Exit Sub
            End If

            '2016.07.08 K.Oikawa s
        Else
            '課題表No126 入力チェック
            Dim message_form As New cMessageLib.fMessage(1, Nothing, _
                             "ポイント会員が選択されておりません。", _
                                     "ポイント会員コードを確認して下さい。", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Exit Sub
            '2016.07.08 K.Oikawa e

        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub POINT_MEMBER_INS_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_INS_B.Click
        Dim oPointMemberMst = New cMasterMenteLib.fPointMemberMst(oConn, oCommand, oDataReader, STAFF_CODE, STAFF_NAME, oTran)

        Me.Visible = False
        oPointMemberMst.ShowDialog()
        oPointMemberMst = Nothing
        Me.Visible = True

    End Sub
End Class
