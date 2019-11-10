Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rDayCloseReportSub5
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oCloseDate As String

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oDayTrhkMs() As cStructureLib.sViewDayTrhkMs
    Private oDataTrnMsDBIO As cDataTrnMsDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private tPRODUCT_NAME As String
    Private tEXAMPLE As String

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCloseDate As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oCloseDate = iCloseDate
        oTran = iTran

        '環境マスタ読込み
        ReDim oConf(1)

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
    Private Sub rDayCloseReportSub5_DataInitialize(ByVal sender As Object, _
                                                  ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("EXAMPLE")
        Fields.Add("CHANNEL_NAME")
        Fields.Add("TRN_CODE")
        Fields.Add("TRN_NAME")
        Fields.Add("STATUS")
        Fields.Add("PRODUCT_CODE")
        Fields.Add("PRODUCT")
        Fields.Add("LIST_PRICE")
        Fields.Add("SALE_COUNT")
        Fields.Add("SALES")
    End Sub
    Private Sub rDayCloseReportSub5_FetchData(ByVal sender As Object, _
                                             ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) _
                                             Handles Me.FetchData
        Dim tmpProductStr As String

        tmpProductStr = ""

        '
        ' 取引区分のレコード追加待ち
        ' 取引区分の略称を組み立てる
        ' Fields("EXAMPLE").Value = ""

        ' 取引明細集計クラスの呼び出し
        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)

        RECORD_CNT = oDataTrnMsDBIO.getDaySaleMs(oDayTrhkMs, oCloseDate, oTran)

        ' 集計したデータを帳票に設定
        If RECORD_NO < RECORD_CNT Then

            ' チャネル名
            Fields("CHANNEL_NAME").Value = "【" & oDayTrhkMs(RECORD_NO).sChannelName & "】"

            ' 取引コードと取引明細コードを連結
            Fields("TRN_CODE").Value = oDayTrhkMs(RECORD_NO).sTrhkCode & _
                                       "-" & _
                                       oDayTrhkMs(RECORD_NO).sTrhkMsCode

            ' 取引区分
            Fields("TRN_NAME").Value = oDayTrhkMs(RECORD_NO).sTrhkKbn

            ' 売上状態
            Fields("STATUS").Value = oDayTrhkMs(RECORD_NO).sStatus

            ' 商品コード
            Fields("PRODUCT_CODE").Value = oDayTrhkMs(RECORD_NO).sProductCode

            ' 商品名とオプション名を連結する
            If oConf(0).sOptionName1 <> "" _
            And oDayTrhkMs(RECORD_NO).sOption1 <> "" Then
                tmpProductStr = "（" & _
                                    oConf(0).sOptionName1 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption1
            End If

            If oConf(0).sOptionName2 <> "" _
            And oDayTrhkMs(RECORD_NO).sOption2 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName2 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption2
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName2 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption2
                End If
            End If

            If oConf(0).sOptionName3 <> "" _
            And oDayTrhkMs(RECORD_NO).sOption3 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName3 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption3
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName3 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption3
                End If
            End If

            If oConf(0).sOptionName4 <> "" _
            And oDayTrhkMs(RECORD_NO).sOption4 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                    oConf(0).sOptionName4 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption4
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName4 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption4
                End If
            End If

            If oConf(0).sOptionName5 <> "" _
            And oDayTrhkMs(RECORD_NO).sOption5 <> "" Then
                If tmpProductStr = "" Then
                    tmpProductStr = "（" & _
                                     oConf(0).sOptionName5 & _
                                     "：" & _
                                     oDayTrhkMs(RECORD_NO).sOption5
                Else
                    tmpProductStr = tmpProductStr & _
                                    "、" & _
                                    oConf(0).sOptionName5 & _
                                    "：" & _
                                    oDayTrhkMs(RECORD_NO).sOption5
                End If
            End If

            If tmpProductStr <> "" Then
                tmpProductStr = tmpProductStr & "）"
            End If

            Fields("PRODUCT").Value = oDayTrhkMs(RECORD_NO).sProductName & tmpProductStr

            ' 販売価格
            Fields("LIST_PRICE").Value = CLng(oDayTrhkMs(RECORD_NO).sListPrice)
            ' 数量
            Fields("SALE_COUNT").Value = CLng(oDayTrhkMs(RECORD_NO).sCount)
            ' 金額
            Fields("SALES").Value = CLng(oDayTrhkMs(RECORD_NO).sPrice)

            RECORD_NO = RECORD_NO + 1

            eArgs.EOF = False
        Else
            eArgs.EOF = True
        End If

    End Sub
End Class
