Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rPointCard_Fore
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader


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


        hStream = New System.IO.FileStream("Picture\" & oConf(0).sPointForePass, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        RECORD_NO = 0


    End Sub
    Private Sub rPointCard_Fore_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        '段組設定（A4プリント時のみ使用）
        If CARD_PRINTER = False Then
            Detail.ColumnCount = 2
        Else
            Detail.ColumnCount = 1
        End If

        Fields.Add("PICTURE_1")
    End Sub

    Private Sub rPointCard_Fore_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData

        If RECORD_NO < PRINT_COUNT Then

            PICTURE_1.Visible = True

            Fields("PICTURE_1").Value = System.Drawing.Image.FromStream(hStream)

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
