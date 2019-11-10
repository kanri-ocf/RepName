Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 


Public Class rDayCloseReportSub3
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oCloseDate As String

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oDataTrnMs() As cStructureLib.sViewDataTrnMs
    Private oDataTrnMsDBIO As cDataTrnMsDBIO

    Private CLOSE_DATE As String

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private BUMON_CNT As Integer
    Private LAST_BUMON_CODE As String

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCloseDate As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oCloseDate = iCloseDate
        oTran = iTran

        '環境マスタ読込み
        ReDim oConf(1)

        LAST_BUMON_CODE = ""
        BUMON_CNT = 0

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RECORD_CNT = oConfMstDBIO.getConfMst(oConf, oTran)
        If RECORD_CNT < 1 Then
            'RECORD_CNT表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oConfMstDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If

        oConfMstDBIO = Nothing

        oTool = New cTool
    End Sub
    Private Sub rDayCloseReportSub3_DataInitialize(ByVal sender As Object, _
                                                   ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("BUMON_NAME")
        Fields.Add("PRODUCT_CODE")
        Fields.Add("PRODUCT")
        Fields.Add("SALE_COUNT")
        Fields.Add("SALE_PRICE")
    End Sub
    Private Sub rDayCloseReportSub3_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        Dim oDataTrnMs() As cStructureLib.sViewDataTrnMs
        Dim tmpProductStr As String

        ReDim oDataTrnMs(0)
        tmpProductStr = ""


        ' 取引明細集計クラスの呼び出し(MODECODE:2)
        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)

        RECORD_CNT = oDataTrnMsDBIO.getTrnMs(oDataTrnMs, oCloseDate, "2", oTran)

        If RECORD_NO < RECORD_CNT _
        And BUMON_CNT < 20 Then
            ' 部門名
            Fields("BUMON_NAME").Value = "【" & _
                                         oDataTrnMs(RECORD_NO).sBumonName & _
                                         "】"

            ' 商品番号
            Fields("PRODUCT_CODE").Value = oDataTrnMs(RECORD_NO).sProductCode

            ' 商品名とオプション名を連結する
            If oConf(0).sOptionName1 <> "" _
            And oDataTrnMs(RECORD_NO).sOption1 <> "" Then
                tmpProductStr = "（" & _
                                    oConf(0).sOptionName1 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption1
            End If

            If oConf(0).sOptionName2 <> "" _
            And oDataTrnMs(RECORD_NO).sOption2 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName2 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption2
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName2 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption2
                End If
            End If

            If oConf(0).sOptionName3 <> "" _
            And oDataTrnMs(RECORD_NO).sOption3 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName3 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption3
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName3 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption3
                End If
            End If

            If oConf(0).sOptionName4 <> "" _
            And oDataTrnMs(RECORD_NO).sOption4 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName4 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption4
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName4 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption4
                End If
            End If

            If oConf(0).sOptionName5 <> "" _
            And oDataTrnMs(RECORD_NO).sOption5 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                     oConf(0).sOptionName5 & _
                                     "：" & _
                                     oDataTrnMs(RECORD_NO).sOption5
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName5 & _
                                    "：" & _
                                    oDataTrnMs(RECORD_NO).sOption5
                End If
            End If

            If tmpProductStr <> "" Then
                tmpProductStr = tmpProductStr & "）"
            End If

            Fields("PRODUCT").Value = oDataTrnMs(RECORD_NO).sProductName & tmpProductStr

            ' 販売数量
            Fields("SALE_COUNT").Value = String.Format("{0:#,##0}", oDataTrnMs(RECORD_NO).sCount)

            ' 売上価格
            Fields("SALE_PRICE").Value = String.Format("{0:#,##0}", oDataTrnMs(RECORD_NO).sPrice)

            eArgs.EOF = False

            ' 前レコードの部門コードと比較
            If LAST_BUMON_CODE = oDataTrnMs(RECORD_NO).sBumonCode Then
                BUMON_CNT = BUMON_CNT + 1
            Else
                BUMON_CNT = 0
            End If
        Else
            eArgs.EOF = True
        End If

        RECORD_NO = RECORD_NO + 1

    End Sub


End Class
