Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rMemberCard_Back
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private hStream As System.IO.FileStream

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
        ByRef iCommand As OleDb.OleDbCommand, _
        ByRef iDataReader As OleDb.OleDbDataReader, _
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

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

        hStream = New System.IO.FileStream("Picture\" & oConf(0).sPointBackPass, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        RECORD_CNT = 1
        RECORD_NO = 0
    End Sub

    Private Sub rMemberCard_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        Fields.Add("PICTURE")
        Fields.Add("MESSAGE")
    End Sub

    Private Sub rMemberCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData

        If RECORD_NO >= RECORD_CNT Then
            eArgs.EOF = True
        Else
            Fields("PICTURE").Value = System.Drawing.Image.FromStream(hStream)
            Fields("MESSAGE").Value = oConf(0).sMemberCardMsg

            eArgs.EOF = False
        End If

        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        hStream = Nothing
        oMstConfigDBIO = Nothing
        oMstMemberDBIO = Nothing

        MyBase.Finalize()
    End Sub
End Class
