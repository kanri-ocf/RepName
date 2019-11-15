Public Class fCustomer

    Private ConArry() As CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oAdjust() As cStructureLib.sAdjust
    Private oMstAdjustDBIO As cDataAdjustDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oDrawer As cOPOSControlLib.cDrawer

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oTool As cTool

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iDrawer As Object,
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oDrawer = iDrawer

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)

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
    '    <System.Runtime.InteropServices.DllImport("winmm.dll", EntryPoint:="PlaySound")> _
    'Private Shared Function PlaySound(<System.Runtime.InteropServices.MarshalAs( _
    '                        System.Runtime.InteropServices.UnmanagedType.LPStr)> _
    '    ByVal pszSound As String, _
    '    ByVal hModule As Integer, _
    '    ByVal dwFlags As Integer) _
    '    As Integer
    '    End Function

    Private Sub fCustmoer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

        ReDim Preserve ConArry(12)

        ConArry(0) = SEX_C1
        ConArry(1) = SEX_C2

        ConArry(2) = GEN_C1
        ConArry(3) = GEN_C2
        ConArry(4) = GEN_C3
        ConArry(5) = GEN_C4
        ConArry(6) = GEN_C5
        ConArry(7) = GEN_C6
        ConArry(8) = GEN_C7

        ConArry(9) = WEA_C1
        ConArry(10) = WEA_C2
        ConArry(11) = WEA_C3
        ConArry(12) = WEA_C4

        MEMBER_CODE_T.Focus()
    End Sub
    Public Sub SetData(ByVal Code, ByVal Name)
        STAFF_NAME_T.Text = Name
        STAFF_CODE_T.Text = Code
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

    Private Sub INIT_PROC(ByVal Mode As String)
        If Mode = "ALL" Then
            MEMBER_CODE_T.Text = ""
        End If
        MEMBER_NAME_T.Text = ""
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

        MEMBER_CODE_T.Focus()

    End Sub

    Private Sub SEX_C1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SEX_C1.Click
        COLOR_SET(sender)
    End Sub

    Private Sub SEX_C2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SEX_C2.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C1.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C2.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C3.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C4.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C5.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C6.Click
        COLOR_SET(sender)
    End Sub

    Private Sub GEN_C7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GEN_C7.Click
        COLOR_SET(sender)
    End Sub

    Private Sub WEA_C1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WEA_C1.Click
        COLOR_SET(sender)
    End Sub

    Private Sub WEA_C2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WEA_C2.Click
        COLOR_SET(sender)
    End Sub

    Private Sub WEA_C3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WEA_C3.Click
        COLOR_SET(sender)
    End Sub

    Private Sub WEA_C4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WEA_C4.Click
        COLOR_SET(sender)
    End Sub

    Private Sub MEMBER_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEMBER_CODE_T.GotFocus
        MEMBER_CODE_T.SelectAll()
    End Sub

    Private Sub MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_SEARCH_B.Click
        Dim fMember_form As cSelectLib.fMemberSearch
        Dim RecordCount As Integer

        'キー入力音出力
        oTool.PlaySound()

        fMember_form = New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
        fMember_form.ShowDialog()
        If fMember_form.DialogResult = Windows.Forms.DialogResult.OK Then
            RecordCount = oMstMemberDBIO.getMember(oMember,
                                                   fMember_form.MEMBER_CODE_T.Text,
                                                   "",
                                                   "",
                                                   Nothing,
                                                   oTran)
            MEMBER_SET()
        Else
            MEMBER_INIT()
        End If
        fMember_form = Nothing
        MEMBER_CODE_T.Focus()
    End Sub
    Private Sub MEMBER_INIT()
        MEMBER_CODE_T.Text = ""
        MEMBER_NAME_T.Text = ""
        POST_CODE_T.Text = ""
        ADDRESS_T.Text = ""
        TEL_T.Text = ""
        FAX_T.Text = ""
        E_MAIL_T.Text = ""
        ENTRY_DATE_T.Text = ""
        REG_S_DATE.Text = ""
        REG_E_DATE.Text = ""
        SEX_T.Text = ""
        GEN_T.Text = ""
        RESIGN_DATE_T.Text = ""
    End Sub
    Private Sub MEMBER_SET()
        MEMBER_CODE_T.Text = oMember(0).sMemberCode
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
        RESIGN_DATE_T.Text = oMember(0).sResignDate

        '性別セット
        Select Case oMember(0).sSex
            Case "M"
                SEX_C1.Checked = True
                COLOR_SET(SEX_C1)
            Case "F"
                SEX_C2.Checked = True
                COLOR_SET(SEX_C2)
        End Select
        '年齢セット
        Select Case CInt(oMember(0).sAge / 10)
            Case Is < 2
                GEN_C1.Checked = True
                COLOR_SET(GEN_C1)
            Case 2
                GEN_C2.Checked = True
                COLOR_SET(GEN_C2)
            Case 3
                GEN_C3.Checked = True
                COLOR_SET(GEN_C3)
            Case 4
                GEN_C4.Checked = True
                COLOR_SET(GEN_C4)
            Case 5
                GEN_C5.Checked = True
                COLOR_SET(GEN_C5)
            Case 6
                GEN_C6.Checked = True
                COLOR_SET(GEN_C6)
            Case Else
                GEN_C7.Checked = True
                COLOR_SET(GEN_C7)
        End Select

    End Sub
    Private Sub MEMBER_INS_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_INS_B.Click
        '顧客属性ウィンドウ表示
        Dim fMember_form As New cMasterMenteLib.fMemberMst(oConn, oCommand, oDataReader, Nothing, oTran)
        Dim RecordCount As Integer

        'キー入力音出力
        oTool.PlaySound()

        fMember_form.STAFF_CODE_T.Text = STAFF_CODE_T.Text
        fMember_form.STAFF_NAME_T.Text = STAFF_NAME_T.Text
        fMember_form.ShowDialog()
        RecordCount = oMstMemberDBIO.getMember(oMember,
                                               fMember_form.MEMBER_CODE_T.Text,
                                               "",
                                               "",
                                               Nothing,
                                               oTran)
        If fMember_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
            fMember_form = Nothing
            MEMBER_CODE_T.Focus()
            Exit Sub
        End If

        MEMBER_SET()

        fMember_form = Nothing
    End Sub
    Private Function MEMBER_CHECK() As Boolean
        Dim RecordCount As Integer
        Dim message_form As cMessageLib.fMessage

        MEMBER_CHECK = False
        If MEMBER_CODE_T.Text.Length < 13 Then
            Exit Function
        End If

        RecordCount = oMstMemberDBIO.getMember(oMember,
                                               MEMBER_CODE_T.Text,
                                               "",
                                               "",
                                               Nothing,
                                               oTran)
        If RecordCount = 0 Then
            message_form = New cMessageLib.fMessage(1,
                      "会員コードが未登録です。",
                      "再度確認して下さい。",
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            INIT_PROC("ALL")
            Exit Function
        End If

        If oMember(0).sResignDate <> "" Then
            message_form = New cMessageLib.fMessage(1,
                      "退会済みの会員コードが入力されました。",
                      "再度確認して下さい。",
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            INIT_PROC("SUB")
            Exit Function
        End If

        If CDate(oMember(0).sEndRegistDate) < Now() Then
            message_form = New cMessageLib.fMessage(1,
                      "契約期間切れの会員コードが入力されました。",
                      "再度確認して下さい。",
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            INIT_PROC("SUB")
            Exit Function
        End If

        MEMBER_SET()

        MEMBER_CHECK = True

    End Function
    Private Sub MEMBER_EDIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_EDIT_B.Click

        '会員マスタ画面表示
        Dim fMember_form As New cMasterMenteLib.fMemberMst(oConn, oCommand, oDataReader, MEMBER_CODE_T.Text, oTran)
        Dim RecordCount As Integer

        'キー入力音出力
        oTool.PlaySound()

        fMember_form.STAFF_CODE_T.Text = STAFF_CODE_T.Text
        fMember_form.STAFF_NAME_T.Text = STAFF_NAME_T.Text
        fMember_form.MEMBER_CODE_T.Text = MEMBER_CODE_T.Text
        fMember_form.ShowDialog()
        RecordCount = oMstMemberDBIO.getMember(oMember,
                                               fMember_form.MEMBER_CODE_T.Text,
                                               "",
                                               "",
                                               Nothing,
                                               oTran)
        MEMBER_SET()

        fMember_form = Nothing

    End Sub

    Private Sub DROWER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DROWER_B.Click
        'キー入力音出力
        oTool.PlaySound()

        '2019.10.23 R.Takashima  FROM
        '課題No.74 ドロワーを閉めるメッセージを表示する
        Dim message_form As New cMessageLib.fMessage(0,
                                          Nothing,
                                          "ドロワーを閉じて下さい。",
                                          Nothing, Nothing)
        message_form.Show()
        Application.DoEvents()

        oDrawer.OpenDrawer()

        message_form.Dispose()

        '2019.10.23 R.Takashima TO

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click

        'キー入力音出力
        oTool.PlaySound()

        oMstMemberDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click

        '会員コードの入力がある場合
        If MEMBER_CODE_T.Text <> "" Then
            If MEMBER_CHECK() = False Then
                Exit Sub
            End If
        End If

        'キー入力音出力
        oTool.PlaySound()

        '会員の有効性確認
        If MEMBER_CODE_T.Text <> "" Then
            If (REG_S_DATE.Text > String.Format("{0:yyyy/MM/dd}", Now)) Or (REG_E_DATE.Text < String.Format("{0:yyyy/MM/dd}", Now)) Then
                Dim message_form As New cMessageLib.fMessage(1, Nothing,
                                 "選択された会員は現在有効な会員ではありません。",
                                         "会員コードを確認して下さい。", Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Exit Sub
            End If
        End If

        If SEX_C1.Checked = True Then
            SEX_T.Text = "M"
        Else
            If SEX_C2.Checked = True Then
                SEX_T.Text = "F"
            Else
                Dim message_form As New cMessageLib.fMessage(1, Nothing,
                                      "性別を選択して下さい",
                                      Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Exit Sub
            End If
        End If

        If GEN_C1.Checked = True Then
            GEN_T.Text = "1"
        Else
            If GEN_C2.Checked = True Then
                GEN_T.Text = "2"
            Else
                If GEN_C3.Checked = True Then
                    GEN_T.Text = "3"
                Else
                    If GEN_C4.Checked = True Then
                        GEN_T.Text = "4"
                    Else
                        If GEN_C5.Checked = True Then
                            GEN_T.Text = "5"
                        Else
                            If GEN_C6.Checked = True Then
                                GEN_T.Text = "6"
                            Else
                                If GEN_C7.Checked = True Then
                                    GEN_T.Text = "7"
                                Else
                                    Dim message_form As New cMessageLib.fMessage(1, Nothing,
                                                          "年代を選択して下さい",
                                                          Nothing, Nothing)
                                    message_form.ShowDialog()
                                    message_form = Nothing
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If WEA_C1.Checked = True Then
            WEATHER_T.Text = "G"
        Else
            If WEA_C2.Checked = True Then
                WEATHER_T.Text = "R"
            Else
                If WEA_C3.Checked = True Then
                    WEATHER_T.Text = "C"
                Else
                    If WEA_C4.Checked = True Then
                        WEATHER_T.Text = "S"
                    Else
                        Dim message_form As New cMessageLib.fMessage(1, Nothing,
                                              "天気を選択して下さい",
                                              Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing
                        Exit Sub
                    End If
                End If
            End If
        End If

        oMstMemberDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub SEX_C1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEX_C1.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()
    End Sub

    Private Sub SEX_C2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEX_C2.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()
    End Sub

    Private Sub WEA_C1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEA_C1.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub WEA_C2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEA_C2.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub WEA_C3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEA_C3.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub WEA_C4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEA_C4.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C1.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C2.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C3.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C4.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C5.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C6.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()

    End Sub

    Private Sub GEN_C7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GEN_C7.CheckedChanged
        'キー入力音出力
        oTool.PlaySound()
    End Sub

    Private Sub MEMBER_CODE_T_TextChanged(sender As Object, e As EventArgs) Handles MEMBER_CODE_T.TextChanged
        MEMBER_CHECK()
    End Sub

    '2019.10.23 R.Takashima From
    '天気ボタンがクリックされたときに呼び出されるメソッドを呼び出している。
    Private Sub Weather_Set(ByVal weather As String)
        Select Case weather
            Case "G"
                WEA_C1_Click(WEA_C1, New EventArgs)
            Case "R"
                WEA_C2_Click(WEA_C2, New EventArgs)
            Case "C"
                WEA_C3_Click(WEA_C3, New EventArgs)
            Case "S"
                WEA_C4_Click(WEA_C4, New EventArgs)
            Case Else
                Exit Sub
        End Select
    End Sub

    'ShowDialogをオーバーロードをし、天気だけデータをクリックされた状態にしてShowDialogを呼び出す
    Public Overloads Sub ShowDialog(ByVal weather As String)
        Dim i As Integer = 0
        If IsNothing(ConArry) = False Then

            For Each arry As CheckBox In ConArry
                ConArry(i).Checked = False
                ConArry(i).BackColor = Color.Wheat
                i += 1
            Next

            Weather_Set(weather)
        End If

        MyBase.ShowDialog()
    End Sub
    '2019.10.23 R.Takashima TO
End Class
