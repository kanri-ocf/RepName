Public Class fReservSub

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oMstBumonDBIO As cMstBumonDBIO

    Private oRoom() As cStructureLib.sRoom
    Private oMstRoomDBIO As cMstRoomDBIO

    Private oReserv() As cStructureLib.sReserv
    Private oReservFull() As cStructureLib.sViewReservFull
    Private oDataReservDBIO As cDataReservDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction
    ''******************************************************************
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
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iKeyReservCode As String, _
            ByVal iKeyChannelCode As Integer, _
            ByVal iKeyFromReservDate As String, _
            ByVal iKeyToReservDate As String, _
            ByVal iKeyBumonCode As String, _
            ByVal iKeyRoomCode As Integer, _
            ByVal iKeyServiceStaffCode As String, _
            ByVal iKeyStartHour As Integer, _
            ByVal iKeyStartMinute As Integer, _
            ByVal iKeyEndHour As Integer, _
            ByVal iKeyEndMinute As Integer, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran
        oTran = oConn.BeginTransaction

        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oMstRoomDBIO = New cMstRoomDBIO(oConn, oCommand, oDataReader)
        oDataReservDBIO = New cDataReservDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If
        oMstConfigDBIO = Nothing

        'サービス担当者リストボックスセット
        If iKeyServiceStaffCode <> Nothing Then
            STAFF_SET(iKeyBumonCode)
        End If

        '初期値表示
        If iKeyReservCode = "" Then
            REQ_CODE_T.Text = oDataReservDBIO.readMaxReservCode(oTran)
            CHANNEL_CODE_T.Text = iKeyChannelCode
            REQ_DATE_FROM_T.Text = iKeyFromReservDate
            REQ_DATE_TO_T.Text = iKeyToReservDate
            BUMON_CODE_T.Text = iKeyBumonCode
            'oMstBumonDBIO.getBumonMst(oBumon, iKeyBumonCode, Nothing, Nothing, Nothing, Nothing, oTran)
            oMstBumonDBIO.getBumonMst(oBumon, iKeyBumonCode, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            BUMON_NAME_T.Text = oBumon(0).sBumonName
            S_STAFF_CODE_T.Text = iKeyServiceStaffCode
            oMstStaffDBIO.getStaff(oStaff, iKeyServiceStaffCode, Nothing, Nothing, Nothing, oTran)
            ROOM_CODE_T.Text = iKeyRoomCode
            oMstRoomDBIO.getRoom(oRoom, iKeyRoomCode, Nothing, oTran)
            ROOM_NAME_T.Text = oRoom(0).sRoomName
            If iKeyServiceStaffCode = Nothing Then
                S_STAFF_CODE_T.Enabled = False
                S_STAFF_NAME_C.Enabled = False
            Else
                S_STAFF_NAME_C.Text = oStaff(0).sStaffName
                S_STAFF_CODE_T.Text = iKeyServiceStaffCode
            End If
            If iKeyStartHour = Nothing Then
                START_HOUR_T.Enabled = False
                START_MIN_T.Enabled = False
                END_HOUR_T.Enabled = False
                END_MIN_T.Enabled = False
            Else
                START_HOUR_T.Text = String.Format("{0:00}", iKeyStartHour)
                START_MIN_T.Text = String.Format("{0:00}", iKeyStartMinute)
                END_HOUR_T.Text = String.Format("{0:00}", iKeyEndHour)
                END_MIN_T.Text = String.Format("{0:00}", iKeyEndMinute)
            End If
        Else
            oDataReservDBIO.getReservFull(oReservFull, iKeyReservCode, Nothing, Nothing, Nothing, Nothing, iKeyChannelCode, BUMON_CODE_T.Text, oTran)

            REQ_CODE_T.Text = oReservFull(0).sReserveCode
            CHANNEL_CODE_T.Text = oReservFull(0).sChannelCode
            REQ_DATE_FROM_T.Text = oReservFull(0).sFromReserveDate
            REQ_DATE_TO_T.Text = oReservFull(0).sToReserveDate
            BUMON_CODE_T.Text = oReservFull(0).sBumonCode
            BUMON_NAME_T.Text = oReservFull(0).sBumonName
            ROOM_CODE_T.Text = oReservFull(0).sRoomCode
            ROOM_NAME_T.Text = oReservFull(0).sRoomName
            If oReservFull(0).sFromHour = Nothing Then
                S_STAFF_CODE_T.Enabled = False
                S_STAFF_NAME_C.Enabled = False
                START_HOUR_T.Enabled = False
                START_MIN_T.Enabled = False
                END_HOUR_T.Enabled = False
                END_MIN_T.Enabled = False
            Else
                S_STAFF_CODE_T.Text = oReservFull(0).sServiceStaffCode
                S_STAFF_NAME_C.Text = oReservFull(0).sServiceStaffName
                START_HOUR_T.Text = String.Format("{0:00}", oReservFull(0).sFromHour)
                START_MIN_T.Text = String.Format("{0:00}", oReservFull(0).sfromMinute)
                END_HOUR_T.Text = String.Format("{0:00}", oReservFull(0).sToHour)
                END_MIN_T.Text = String.Format("{0:00}", oReservFull(0).sToMinute)
            End If

            MEMBER_CODE_T.Text = oReservFull(0).sMemberCode
            NAME_T.Text = oReservFull(0).sName
            POST_CODE_T.Text = oReservFull(0).sPostCode
            ADDR1_T.Text = oReservFull(0).sAddress1
            ADDR2_T.Text = oReservFull(0).sAddress2
            ADDR3_T.Text = oReservFull(0).sAddress3
            TEL_T.Text = oReservFull(0).sTEL
            FAX_T.Text = oReservFull(0).sFAX
            MAIL_T.Text = oReservFull(0).sMailAddress
            If oReservFull(0).sSex = "M" Then
                SEX_M_R.Checked = True
            Else
                SEX_F_R.Checked = True
            End If
            BIRTHDAY_T.Text = oReservFull(0).sBirthDay
            AGE_T.Text = oReservFull(0).sGeneration
            MEMO1_T.Text = oReservFull(0).sMemo1
            MEMO2_T.Text = oReservFull(0).sMemo2
            MEMO3_T.Text = oReservFull(0).sMemo3

        End If

        STAFF_CODE_T.Text = iStaffCode
        oMstStaffDBIO.getStaff(oStaff, iStaffCode, Nothing, Nothing, Nothing, oTran)
        STAFF_NAME_T.Text = oStaff(0).sStaffName
    End Sub

    '************************************
    ' サービス担当者リストボックスセット
    '************************************
    Private Sub STAFF_SET(ByVal KeyBumonCode As String)
        Dim RecordCnt As Integer
        Dim i As Long
        Dim str As String

        '初期化
        S_STAFF_NAME_C.Items.Clear()

        'サービス担当者コンボ内容設定
        oStaff = Nothing

        If KeyBumonCode = "" Then
            str = Nothing
        Else
            str = KeyBumonCode
        End If
        RecordCnt = oMstStaffDBIO.getStaff(oStaff, Nothing, Nothing, Nothing, str, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "サービス担当者マスタが登録されていません", _
                                                "サービス担当者マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "サービス担当者マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            S_STAFF_NAME_C.Items.Add(oStaff(i).sStaffName)
        Next
    End Sub
    Private Sub RETURN_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oTran.Rollback()

        CLOSE_PROC()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub STAFF_NAME_C_SelectedIndexChanged(ByVal sCloseer As Object, ByVal e As System.EventArgs) Handles S_STAFF_NAME_C.SelectedIndexChanged
        If S_STAFF_NAME_C.SelectedIndex <> -1 Then
            oMstStaffDBIO.getStaff(oStaff, Nothing, S_STAFF_NAME_C.Text, Nothing, Nothing, oTran)
            S_STAFF_CODE_T.Text = oStaff(0).sStaffCode
        End If
    End Sub
    Private Sub CLOSE_PROC()
        oBumon = Nothing
        oMstBumonDBIO = Nothing
        oStaff = Nothing
        oMstStaffDBIO = Nothing
        oConf = Nothing
        oMstConfigDBIO = Nothing

    End Sub
    Private Function WRITE_PROC()
        Dim RecCnt As Long

        RecCnt = oDataReservDBIO.getReserv(oReserv, REQ_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CInt(CHANNEL_CODE_T.Text), oTran)

        ReDim oReserv(0)

        oReserv(0).sReserveCode = REQ_CODE_T.Text
        oReserv(0).sChannelCode = CInt(CHANNEL_CODE_T.Text)
        oReserv(0).sRoomCode = CInt(ROOM_CODE_T.Text)
        oReserv(0).sFromReserveDate = oTool.MaskClear(REQ_DATE_FROM_T.Text)
        oReserv(0).sToReserveDate = oTool.MaskClear(REQ_DATE_TO_T.Text)
        If START_HOUR_T.Enabled = False Then
            oReserv(0).sFromHour = Nothing
            oReserv(0).sFromMinute = Nothing
            oReserv(0).sToHour = Nothing
            oReserv(0).sToMinute = Nothing
        Else
            oReserv(0).sFromHour = CInt(START_HOUR_T.Text)
            oReserv(0).sFromMinute = CInt(START_MIN_T.Text)
            oReserv(0).sToHour = CInt(END_HOUR_T.Text)
            oReserv(0).sToMinute = CInt(END_MIN_T.Text)
        End If
        oReserv(0).sBumonCode = BUMON_CODE_T.Text
        If S_STAFF_CODE_T.Enabled = False Then
            oReserv(0).sServiceStaffCode = ""
        Else
            oReserv(0).sServiceStaffCode = S_STAFF_CODE_T.Text
        End If
        oReserv(0).sMemberCode = MEMBER_CODE_T.Text
        oReserv(0).sName = NAME_T.Text
        oReserv(0).sPostCode = oTool.MaskClear(POST_CODE_T.Text)
        oReserv(0).sAddress1 = ADDR1_T.Text
        oReserv(0).sAddress2 = ADDR2_T.Text
        oReserv(0).sAddress3 = ADDR3_T.Text
        oReserv(0).sTEL = oTool.MaskClear(TEL_T.Text)
        oReserv(0).sFAX = oTool.MaskClear(FAX_T.Text)
        oReserv(0).sMailAddress = MAIL_T.Text
        If SEX_M_R.Checked = True Then
            oReserv(0).sSex = "M"
        Else
            oReserv(0).sSex = "F"
        End If
        oReserv(0).sBirthDay = oTool.MaskClear(BIRTHDAY_T.Text)
        If AGE_T.Text = "" Then
            oReserv(0).sGeneration = Nothing
        Else
            oReserv(0).sGeneration = CInt(AGE_T.Text)
        End If
        oReserv(0).sMemo1 = MEMO1_T.Text
        oReserv(0).sMemo2 = MEMO2_T.Text
        oReserv(0).sMemo3 = MEMO3_T.Text
        oReserv(0).sStaffCode = STAFF_CODE_T.Text

        'DB登録
        If RecCnt = 0 Then
            WRITE_PROC = oDataReservDBIO.insertReserv(oReserv(0), oTran)
        Else
            WRITE_PROC = oDataReservDBIO.updateReserv(oReserv(0), oTran)
        End If
    End Function
    Private Sub COMMIT_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        If INPUT_CHECK() = True Then
            oTran.Commit()
        End If
        CLOSE_PROC()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Function INPUT_CHECK()
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        '予約開始日確認
        If oTool.MaskClear(REQ_DATE_FROM_T.Text) = "//" Then
            Message_form = New cMessageLib.fMessage(1, "予約開始日が入力されていません。", _
                                        "予約開始日を入力して下さい", _
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            REQ_DATE_FROM_T.Focus()
            Exit Function
        End If

        '予約終了日確認
        If oTool.MaskClear(REQ_DATE_FROM_T.Text) = "//" Then
            Message_form = New cMessageLib.fMessage(1, "予約終了日が入力されていません。", _
                                        "予約終了日を入力して下さい", _
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            REQ_DATE_FROM_T.Focus()
            Exit Function
        End If

        If START_HOUR_T.Enabled = True Then
            '開始時間（時）確認
            If START_HOUR_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "開始時間(時）が入力されていません。", _
                                            "開始時間(時）を入力して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                INPUT_CHECK = False
                START_HOUR_T.Focus()
                Exit Function
            End If

            '開始時間（分）確認
            If START_MIN_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "開始時間(分）が入力されていません。", _
                                            "開始時間(分）を入力して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                INPUT_CHECK = False
                START_MIN_T.Focus()
                Exit Function
            End If

            '終了時間（時）確認
            If END_HOUR_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "終了時間(時）が入力されていません。", _
                                            "終了時間(時）を入力して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                INPUT_CHECK = False
                END_HOUR_T.Focus()
                Exit Function
            End If

            '終了時間（分）確認
            If END_MIN_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "終了時間(分）が入力されていません。", _
                                            "終了時間(分）を入力して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                INPUT_CHECK = False
                END_MIN_T.Focus()
                Exit Function
            End If
        End If

        If S_STAFF_NAME_C.Enabled = True Then
            'サービス担当者確認
            If S_STAFF_NAME_C.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "サービス担当者が入力されていません。", _
                                            "サービス担当者を入力して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                INPUT_CHECK = False
                S_STAFF_NAME_C.Focus()
                Exit Function
            End If
        End If

        '名称
        If NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "名称が入力されていません。", _
                                        "名称を入力して下さい", _
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            NAME_T.Focus()
            Exit Function
        End If

        '電話番号
        If oTool.MaskClear(TEL_T.Text) = "" Then
            Message_form = New cMessageLib.fMessage(1, "電話番号が入力されていません。", _
                                        "電話番号を入力して下さい", _
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            TEL_T.Focus()
            Exit Function
        End If
    End Function

    Private Sub DELETE_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim ret As Boolean

        ret = oDataReservDBIO.deleteReserv(CLng(REQ_CODE_T.Text), oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            Message_form = New cMessageLib.fMessage(1, "予約データの削除に失敗しました。", _
                                                "システム管理者にご確認下さい。", _
                                                Nothing, Nothing)

            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        Else
            oTran.Commit()
        End If

        CLOSE_PROC()

        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()

    End Sub

    Private Sub RESERV_CARD_PRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESERV_CARD_PRINT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim oReportPage As rReservCard
        Dim ret As Boolean
        Dim hStream As System.IO.FileStream

        'DB登録処理
        If INPUT_CHECK() = True Then
            If WRITE_PROC() = False Then
                '登録エラー
                Message_form = New cMessageLib.fMessage(1, "データの登録に失敗しました。", _
                                    "システム管理者に連絡して下さい。", _
                                    Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                CLOSE_PROC()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Exit Sub
        End If

        ''予約票印刷確認
        If INPUT_CHECK() = True Then
            'タグ印刷
            Message_form = New cMessageLib.fMessage(2, "予約票を印刷しますか？", _
                                "用紙（A4）をプリンターにセットして下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                Message_form = Nothing

                '会員証印刷
                Message_form = New cMessageLib.fMessage(0, Nothing, _
                        "予約票印刷中", _
                        Nothing, Nothing)
                Message_form.Show()
                System.Windows.Forms.Application.DoEvents()

                hStream = New System.IO.FileStream("Picture\" & oConf(0).sRLogoPass, System.IO.FileMode.Open)
                oReportPage = New rReservCard(oConn, oCommand, oDataReader, REQ_CODE_T.Text, hStream, STAFF_CODE_T.Text, STAFF_NAME_T.Text, oTran)
                oReportPage.Run()
                ret = oReportPage.Document.Print(True, False)
                Message_form.Dispose()
                Message_form = Nothing

                hStream.Close()
                hStream = Nothing

            End If
        End If

        COMMIT_B.Enabled = True

        System.Windows.Forms.Application.DoEvents()

    End Sub

    Private Sub fReservSub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        COMMIT_B.Enabled = False
    End Sub

    Private Sub MEMBER_SERCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_SERCH_B.Click
        Dim fMember_form As New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
        fMember_form.ShowDialog()

        '2016.09.13 K.Oikawa s
        'MEMBER_SET(fMember_form.MEMBER_CODE_T.Text)
        'fMember_form = Nothing
        '課題表No.159 会員検索を取りやめた際の処理を追加
        If fMember_form.DialogResult = Windows.Forms.DialogResult.OK Then
            MEMBER_SET(fMember_form.MEMBER_CODE_T.Text)
            fMember_form = Nothing
        End If
        '2016.09.13 K.Oikawa e

    End Sub

    Private Sub MEMBER_SET(ByVal MemberCode As String)
        Dim RecordCount As Integer
        Dim oMstMemberDBIO As New cMstMemberDBIO(oConn, oCommand, oDataReader)
        Dim oMember() As cStructureLib.sMember
        Dim oMstChannelDBIO As New cMstChannelDBIO(oConn, oCommand, oDataReader)
        Dim oChannel() As cStructureLib.sChannel

        ReDim oMember(0)
        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                       MemberCode, _
                                       "", _
                                       "", _
                                       Nothing, _
                                       oTran)
        MEMBER_CODE_T.Text = oMember(0).sMemberCode
        ReDim oChannel(0)
        RecordCount = oMstChannelDBIO.getChannelMst(oChannel, CInt(oMember(0).sMemberCode.Substring(3, 1)), Nothing, Nothing, Nothing, oTran)
        NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDR1_T.Text = oMember(0).sAddress1
        ADDR2_T.Text = oMember(0).sAddress2
        ADDR3_T.Text = oMember(0).sAddress3
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        MAIL_T.Text = oMember(0).sMailAddress
        If oMember(0).sSex = "M" Then
            SEX_M_R.Checked = True
            SEX_F_R.Checked = False
        Else
            SEX_M_R.Checked = False
            SEX_F_R.Checked = True
        End If
        BIRTHDAY_T.Text = oMember(0).sBirthday

        AGE_T.Text = oMember(0).sAge
    End Sub

    Private Sub MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEMBER_CODE_T.LostFocus
        MEMBER_SET(MEMBER_CODE_T.Text)
    End Sub
End Class