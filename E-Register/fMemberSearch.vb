Public Class fMemberSearch

    Private ConArry() As CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oMstAdjustDBIO As cDataAdjustDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

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

        MEMBER_CODE_T.Focus()
    End Sub

    Private Sub COLOR_SET(ByVal Btn As CheckBox)
        Dim i As Integer
        Dim pos As Integer

        For i = 0 To ConArry.Count - 1
            If Btn.Name = ConArry(i).Name Then
                pos = i
                Exit For
            End If
        Next i

        Select Case pos
            Case 0, 1
                For i = 0 To 1
                    If Btn.Name = ConArry(i).Name Then
                        ConArry(i).Checked = True
                        ConArry(i).BackColor = Color.LightSalmon
                    Else
                        ConArry(i).Checked = False
                        ConArry(i).BackColor = Color.Wheat

                    End If
                Next i
            Case 2, 3, 4, 5, 6, 7, 8
                For i = 2 To 8
                    If Btn.Name = ConArry(i).Name Then
                        ConArry(i).Checked = True
                        ConArry(i).BackColor = Color.LightSalmon
                    Else
                        ConArry(i).Checked = False
                        ConArry(i).BackColor = Color.Wheat

                    End If
                Next i
            Case 9, 10, 11, 12
                For i = 9 To 12
                    If Btn.Name = ConArry(i).Name Then
                        ConArry(i).Checked = True
                        ConArry(i).BackColor = Color.LightSalmon
                    Else
                        ConArry(i).Checked = False
                        ConArry(i).BackColor = Color.Wheat

                    End If
                Next i
        End Select
    End Sub

    Private Sub MEMBER_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEMBER_CODE_T.GotFocus
        MEMBER_CODE_T.SelectAll()
    End Sub

    Private Sub MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEMBER_CODE_T.LostFocus
        Dim RecordCount As Integer

        If MEMBER_CODE_T.Text = "" Then
            Exit Sub
        End If
        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                               MEMBER_CODE_T.Text, _
                                               "", _
                                               "", _
                                               Nothing, _
                                               oTran)
        If RecordCount = 0 Then
            Dim message_form As New cMessageLib.fMessage(1, _
                      "会員コードが未登録です。", _
                      "再度確認して下さい。", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            oMstMemberDBIO = Nothing
            MEMBER_CODE_T.Text = ""
            MEMBER_CODE_T.Focus()
            Exit Sub
        End If
        MEMBER_CODE_T.Text = MEMBER_CODE_T.Text
        MEMBER_NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDRESS_T.Text = oMember(0).sAddress1 & oMember(0).sAddress2
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        E_MAIL_T.Text = oMember(0).sMailAddress
        ENTRY_DATE_T.Text = oMember(0).sEntryDate
        REG_S_DATE.Text = oMember(0).sStartRegistDate
        REG_E_DATE.Text = oMember(0).sEndRegistDate
        SEX_T.Text = oMember(0).sSex
        GEN_T.Text = oMember(0).sAge

        oMstMemberDBIO = Nothing

    End Sub

    Private Sub MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_SEARCH_B.Click
        Dim fMember_form As New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
        Dim RecordCount As Integer

        fMember_form.ShowDialog()
        If fMember_form.DialogResult = Windows.Forms.DialogResult.Abort Then
            fMember_form.Dispose()
            fMember_form = Nothing
            Exit Sub
        End If

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                                   fMember_form.MEMBER_CODE_T.Text, _
                                                   "", _
                                                   "", _
                                                   Nothing, _
                                                   oTran)
        MEMBER_CODE_T.Text = fMember_form.MEMBER_CODE_T.Text
        MEMBER_NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDRESS_T.Text = oMember(0).sAddress1 & oMember(0).sAddress2 & oMember(0).sAddress3
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        E_MAIL_T.Text = oMember(0).sMailAddress
        ENTRY_DATE_T.Text = oMember(0).sEntryDate
        REG_S_DATE.Text = oMember(0).sStartRegistDate
        REG_E_DATE.Text = oMember(0).sEndRegistDate
        SEX_T.Text = oMember(0).sSex
        GEN_T.Text = oMember(0).sAge
        fMember_form.Dispose()
        fMember_form = Nothing
        oMstMemberDBIO = Nothing

    End Sub

    Private Sub MEMBER_INS_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_INS_B.Click
        '顧客属性ウィンドウ表示
        Dim fMember_form As New cMasterMenteLib.fMemberMst(oConn, oCommand, oDataReader, Nothing, oTran)
        Dim RecordCount As Integer

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)

        fMember_form.STAFF_CODE_T.Text = STAFF_CODE
        fMember_form.STAFF_NAME_T.Text = STAFF_NAME
        fMember_form.ShowDialog()

        '2016.06.30 K.Oikawa s
        '課題表No133 会員登録を中断した場合に会員情報が表示されるため修正
        If fMember_form.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        '2016.06.30 K.Oikawa e

        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                               fMember_form.MEMBER_CODE_T.Text, _
                                               "", _
                                               "", _
                                               Nothing, _
                                               oTran)

        MEMBER_CODE_T.Text = fMember_form.MEMBER_CODE_T.Text
        MEMBER_NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDRESS_T.Text = oMember(0).sAddress1 & oMember(0).sAddress2
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        E_MAIL_T.Text = oMember(0).sMailAddress
        ENTRY_DATE_T.Text = oMember(0).sEntryDate.ToString
        REG_S_DATE.Text = oMember(0).sStartRegistDate.ToString
        REG_E_DATE.Text = oMember(0).sEndRegistDate.ToString
        SEX_T.Text = oMember(0).sSex
        GEN_T.Text = oMember(0).sAge
        fMember_form = Nothing
        oMstMemberDBIO = Nothing

        fMember_form = Nothing

    End Sub

    Private Sub MEMBER_EDIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_EDIT_B.Click
        If MEMBER_CODE_T.Text = "" Then
            Dim message_form As New cMessageLib.fMessage(1, Nothing, _
                      "会員コードを指定して下さい", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Exit Sub
        End If

        '会員マスタ画面表示
        Dim fMember_form As New cMasterMenteLib.fMemberMst(oConn, oCommand, oDataReader, MEMBER_CODE_T.Text, oTran)
        Dim RecordCount As Integer

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)

        fMember_form.STAFF_CODE_T.Text = STAFF_CODE
        fMember_form.STAFF_NAME_T.Text = STAFF_NAME
        fMember_form.MEMBER_CODE_T.Text = MEMBER_CODE_T.Text
        fMember_form.ShowDialog()
        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                               fMember_form.MEMBER_CODE_T.Text, _
                                               "", _
                                               "", _
                                               Nothing, _
                                               oTran)
        MEMBER_CODE_T.Text = fMember_form.MEMBER_CODE_T.Text
        MEMBER_NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDRESS_T.Text = oMember(0).sAddress1 & oMember(0).sAddress2
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        E_MAIL_T.Text = oMember(0).sMailAddress
        ENTRY_DATE_T.Text = oMember(0).sEntryDate.ToString
        REG_S_DATE.Text = oMember(0).sStartRegistDate.ToString
        REG_E_DATE.Text = oMember(0).sEndRegistDate.ToString
        SEX_T.Text = oMember(0).sSex
        GEN_T.Text = oMember(0).sAge
        fMember_form = Nothing
        oMstMemberDBIO = Nothing

        fMember_form = Nothing

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        '会員の有効性確認
        If MEMBER_CODE_T.Text <> "" Then
            If (REG_S_DATE.Text > String.Format("{0:yyyy/MM/dd}", Now)) Or (REG_E_DATE.Text < String.Format("{0:yyyy/MM/dd}", Now)) Then
                Dim message_form As New cMessageLib.fMessage(1, Nothing, _
                                 "選択された会員は現在有効な会員ではありません。", _
                                         "会員コードを確認して下さい。", Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Exit Sub
            End If

            '2016.07.08 K.Oikawa s
        Else
            '課題表No126 入力チェック
            Dim message_form As New cMessageLib.fMessage(1, Nothing, _
                             "会員が選択されておりません。", _
                                     "会員コードを確認して下さい。", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Exit Sub
            '2016.07.08 K.Oikawa e

        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class
