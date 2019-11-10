Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 


Public Class rPointCard_Back
    Implements IDisposable

    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private CHANNEL_CODE As Integer

    Private oConf() As cStructureLib.sConfig

    Private oPointMember() As cStructureLib.sPointMember
    Private PRINT_COUNT As Integer
    Private CARD_PRINTER As Boolean

    Private RECORD_NO As Long

    Private hStream As System.IO.FileStream

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iPointMember() As cStructureLib.sPointMember, _
            ByVal iPrintCnt As Integer, _
            ByVal iCardPrinter As Boolean, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction _
            )

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oConf = iConf
        oTran = iTran

        oTool = New cTool

        oPointMember = iPointMember
        PRINT_COUNT = iPrintCnt
        CARD_PRINTER = iCardPrinter

        hStream = New System.IO.FileStream("Picture\" & oConf(0).sPointBackPass, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        RECORD_NO = 0
    End Sub
    Private Sub rPointCard_Back_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        '段組設定（A4プリント時のみ使用）
        If CARD_PRINTER = False Then
            Detail.ColumnCount = 2
        Else
            Detail.ColumnCount = 1
        End If

        Fields.Add("PICTURE")
        Fields.Add("BARCODE")
        Fields.Add("MESSAGE")

        Fields.Add("LABEL1")
        Fields.Add("LABEL2")
        Fields.Add("LABEL3")
        Fields.Add("LABEL4")

    End Sub

    Private Sub rPointCard_Back_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData

        If RECORD_NO < PRINT_COUNT Then

            PICTURE.Visible = True
            BARCODE.Visible = True
            MESSAGE.Visible = True

            LABEL1.Visible = True
            LABEL2.Visible = True
            LABEL3.Visible = True
            LABEL4.Visible = True

            Fields("PICTURE").Value = System.Drawing.Image.FromStream(hStream)
            Fields("BARCODE").Value = oPointMember(RECORD_NO).sPointMemberCode
            Fields("MESSAGE").Value = oConf(0).sPointCardMsg

            Fields("LABEL1").Value = "(御署名)"
            Fields("LABEL2").Value = "　"
            Fields("LABEL3").Value = "(発行日)"
            Fields("LABEL4").Value = "　　　　　年　　　月　　　日"
            eArgs.EOF = False
            RECORD_NO = RECORD_NO + 1
        Else
            eArgs.EOF = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        hStream = Nothing
        MyBase.Finalize()
    End Sub
End Class
