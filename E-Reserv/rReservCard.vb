Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rReservCard
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oReservFull() As cStructureLib.sViewReservFull
    Private oDataReservDBIO As cDataReservDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private RESERV_NUMBER As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Dim hStream As System.IO.FileStream

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
        ByRef iCommand As OleDb.OleDbCommand, _
        ByRef iDataReader As OleDb.OleDbDataReader, _
        ByRef iReservCode As String, _
        ByRef ihStream As System.IO.FileStream, _
        ByVal iStaff_Code As String, _
        ByVal iStaff_Name As String, _
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        hStream = ihStream

        oTran = iTran

        RESERV_NUMBER = iReservCode
        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name


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

        '会員マスタ読込み
        ReDim oReservFull(1)
        oDataReservDBIO = New cDataReservDBIO(oConn, oCommand, oDataReader)
        RECORD_CNT = oDataReservDBIO.getReservFull(oReservFull, iReservCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        RECORD_NO = 0
    End Sub

    Private Sub rReservCard_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("CUSTOMER_NAME")
        Fields.Add("SERVICE_NAME")
        Fields.Add("FROM_DATE")
        Fields.Add("TO_DATE")
        Fields.Add("FROM_TIME")
        Fields.Add("TO_TIME")
        Fields.Add("ROOM_NAME")
        Fields.Add("SERVICE_STAFF_NAME")

        Fields.Add("MEMO")

        Fields.Add("LOGO")
        Fields.Add("POST_CODE")
        Fields.Add("CORP_NAME")
        Fields.Add("ADDR1")
        Fields.Add("ADDR2")
        Fields.Add("TEL")
        Fields.Add("FAX")
        Fields.Add("FRONT_STAFF_NAME")

    End Sub

    Private Sub rReservCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData

        If RECORD_NO >= RECORD_CNT Then
            eArgs.EOF = True
        Else
            Fields("CUSTOMER_NAME").Value = oReservFull(0).sName
            Fields("SERVICE_NAME").Value = oReservFull(0).sBumonName
            Fields("FROM_DATE").Value = oReservFull(0).sFromReserveDate
            Fields("FROM_TIME").Value = String.Format("{0:00}", oReservFull(0).sFromHour) & ":" & String.Format("{0:00}", oReservFull(0).sFromMinute)
            Fields("TO_DATE").Value = oReservFull(0).sToReserveDate
            Fields("TO_TIME").Value = String.Format("{0:00}", oReservFull(0).sToHour) & ":" & String.Format("{0:00}", oReservFull(0).sToMinute)
            Fields("ROOM_NAME").Value = oReservFull(0).sRoomName
            Fields("SERVICE_STAFF_NAME").Value = oReservFull(0).sServiceStaffName
            Fields("MEMO").Value = oReservFull(0).sMemo1 & vbCrLf & oReservFull(0).sMemo2 & vbCrLf & oReservFull(0).sMemo3

            ' FileStream を開く
            Fields("LOGO").Value = System.Drawing.Image.FromStream(hStream)

            Fields("CORP_NAME").Value = oConf(0).sCorpName
            Fields("POST_CODE").Value = oConf(0).sPostCode
            Fields("ADDR1").Value = oConf(0).sAdderess1
            Fields("ADDR2").Value = oConf(0).sAdderess2
            If Fields("ADDR2").Value = "" Then
                Fields("ADDR2").Value = "TEL:" & oConf(0).sTEL & "  FAX：" & oConf(0).sFAX
                Fields("TEL").Value = ""
                Fields("FAX").Value = ""
            Else
                Fields("TEL").Value = "TEL:" & oConf(0).sTEL
                Fields("FAX").Value = "FAX:" & oConf(0).sFAX
            End If

            eArgs.EOF = False
        End If
        Fields("FRONT_STAFF_NAME").Value = STAFF_NAME

        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        oMstConfigDBIO = Nothing
        oDataReservDBIO = Nothing

        MyBase.Finalize()
    End Sub
End Class
