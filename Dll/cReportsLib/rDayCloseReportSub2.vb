Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rDayCloseReportSub2
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

    Private tmpMARGIN As Long

    Private PART_CNT As Long
    Private PART_SALES As Long
    Private PART_MARGIN As Long

    Private TOTAL_CNT As Long
    Private TOTAL_SALES As Long
    Private TOTAL_MARGIN As Long

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

        ' ワークエリアのクリア
        PART_CNT = 0
        PART_SALES = 0
        PART_MARGIN = 0

        TOTAL_CNT = 0
        TOTAL_SALES = 0
        TOTAL_MARGIN = 0

        tmpMARGIN = 0

    End Sub
    Private Sub rDayCloseReportSub2_DataInitialize(ByVal sender As Object, _
                                                   ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("CHANNEL")
        Fields.Add("BUMON")
        Fields.Add("PRODUCT_CODE")
        Fields.Add("PRODUCT")
        Fields.Add("LIST_PRICE")
        Fields.Add("COUNT")
        Fields.Add("SALES")
        Fields.Add("MARGIN")
        Fields.Add("PROFIT_RATE")
        Fields.Add("SUB_COUNT")
        Fields.Add("SUB_SALES")
        Fields.Add("SUB_MARGIN")
        Fields.Add("SUB_PROFIT_RATE")
        Fields.Add("SUM_COUNT")
        Fields.Add("SUM_SALES")
        Fields.Add("SUM_MARGIN")
        Fields.Add("SUM_PROFIT_RATE")
    End Sub
    Private Sub rDayCloseReportSub2_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        Dim oDataTrnMs() As cStructureLib.sViewDataTrnMs
        Dim tmpProductStr As String

        ReDim oDataTrnMs(0)
        tmpProductStr = ""

        ' 取引明細集計クラスの呼び出し(MODECODE:1)
        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)

        RECORD_CNT = oDataTrnMsDBIO.getTrnMs(oDataTrnMs, oCloseDate, "1", oTran)

        If RECORD_NO < RECORD_CNT Then
            ' チャネル名
            Fields("CHANNEL").Value = "【" & _
                                      oDataTrnMs(RECORD_NO).sChannelName & _
                                      "】"

            ' 部門名
            Fields("BUMON").Value = oDataTrnMs(RECORD_NO).sBumonName

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

            If oConf(0).sOptionName2 <> Nothing _
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

            If oConf(0).sOptionName3 <> Nothing _
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

            If oConf(0).sOptionName4 <> Nothing _
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

            If oConf(0).sOptionName5 <> Nothing _
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

            ' 定価
            Fields("LIST_PRICE").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oDataTrnMs(RECORD_NO).sListPrice, _
                                                                                                oConf(0).sTax, oConf(0).sFracProc))

            ' 販売数量
            Fields("COUNT").Value = String.Format("{0:#,##0}", oDataTrnMs(RECORD_NO).sCount)

            ' 売上価格
            Fields("SALES").Value = String.Format("{0:#,##0}", oDataTrnMs(RECORD_NO).sPrice)

            ' 粗利(売上価格-(仕入価格×販売数量))
            tmpMARGIN = oDataTrnMs(RECORD_NO).sPrice - _
                            oTool.BeforeToAfterTax(oDataTrnMs(RECORD_NO).sCostPrice, oConf(0).sTax, oConf(0).sFracProc)

            Fields("MARGIN").Value = String.Format("{0:#,##0}", tmpMARGIN)

            ' 利益率(帳票上は小数点第1位で端数処理)
            Fields("PROFIT_RATE").Value = String.Format("{0:#.0}", (tmpMARGIN / oDataTrnMs(RECORD_NO).sPrice) * 100)

            ' 売上数量、売上金額、粗利を集計する
            PART_CNT = PART_CNT + CLng(oDataTrnMs(RECORD_NO).sCount)
            PART_SALES = PART_SALES + CLng(oDataTrnMs(RECORD_NO).sPrice)
            PART_MARGIN = PART_MARGIN + oDataTrnMs(RECORD_NO).sPrice _
                                     - (oDataTrnMs(RECORD_NO).sCostPrice * oDataTrnMs(RECORD_NO).sCount)

            TOTAL_CNT = TOTAL_CNT + CLng(oDataTrnMs(RECORD_NO).sCount)
            TOTAL_SALES = TOTAL_SALES + CLng(oDataTrnMs(RECORD_NO).sPrice)
            TOTAL_MARGIN = TOTAL_MARGIN + oDataTrnMs(RECORD_NO).sPrice _
                                     - (oDataTrnMs(RECORD_NO).sCostPrice * oDataTrnMs(RECORD_NO).sCount)

            RECORD_NO = RECORD_NO + 1

            ' すべてのレコードを読み終わっている場合、小計・合計を出力
            If RECORD_NO = RECORD_CNT Then
                ' 小計
                ' 販売数量
                Fields("SUB_COUNT").Value = String.Format("{0:#,##0}", PART_CNT)
                ' 売上金額
                Fields("SUB_SALES").Value = String.Format("{0:#,##0}", PART_SALES)
                ' 粗利
                Fields("SUB_MARGIN").Value = String.Format("{0:#,##0}", PART_MARGIN)
                ' 利益率（帳票上は小数点第1位で端数処理）
                Fields("SUB_PROFIT_RATE").Value = String.Format("{0:0.0}", (PART_MARGIN / PART_SALES) * 100)

                ' 合計
                ' 販売数量
                Fields("SUM_COUNT").Value = String.Format("{0:#,##0}", TOTAL_CNT)
                ' 売上金額
                Fields("SUM_SALES").Value = String.Format("{0:#,##0}", TOTAL_SALES)
                ' 粗利
                Fields("SUM_MARGIN").Value = String.Format("{0:#,##0}", TOTAL_MARGIN)
                ' 利益率（帳票上は小数点第1位で端数処理）
                Fields("SUM_PROFIT_RATE").Value = String.Format("{0:0.0}", (TOTAL_MARGIN / TOTAL_SALES) * 100)
            Else
                ' 読み込むレコードが残っている場合、小計・合計を出力有無を判定
                If oDataTrnMs(RECORD_NO).sChannelCode <> oDataTrnMs(RECORD_NO - 1).sChannelCode _
                Or oDataTrnMs(RECORD_NO).sBumonCode <> oDataTrnMs(RECORD_NO - 1).sBumonCode Then

                    ' 前レコードとカレントレコードのチャネルが同一である場合
                    If oDataTrnMs(RECORD_NO).sChannelCode = oDataTrnMs(RECORD_NO - 1).sChannelCode Then
                        ' 小計のみ出力

                        ' 小計
                        ' 販売数量
                        Fields("SUB_COUNT").Value = String.Format("{0:#,##0}", PART_CNT)
                        ' 売上金額
                        Fields("SUB_SALES").Value = String.Format("{0:#,##0}", PART_SALES)
                        ' 粗利
                        Fields("SUB_MARGIN").Value = String.Format("{0:#,##0}", PART_MARGIN)
                        ' 利益率（帳票上は小数点第1位で端数処理）
                        Fields("SUB_PROFIT_RATE").Value = String.Format("{0:0.0}", (PART_MARGIN / PART_SALES) * 100)

                        ' ワークエリアのクリア
                        PART_CNT = 0
                        PART_SALES = 0
                        PART_MARGIN = 0
                    Else
                        ' 小計・合計を出力

                        ' 小計
                        ' 販売数量
                        Fields("SUB_COUNT").Value = String.Format("{0:#,##0}", PART_CNT)
                        ' 売上金額
                        Fields("SUB_SALES").Value = String.Format("{0:#,##0}", PART_SALES)
                        ' 粗利
                        Fields("SUB_MARGIN").Value = String.Format("{0:#,##0}", PART_MARGIN)
                        ' 利益率（帳票上は小数点第1位で端数処理）
                        Fields("SUB_PROFIT_RATE").Value = String.Format("{0:0.0}", (PART_MARGIN / PART_SALES) * 100)

                        ' 合計
                        ' 販売数量
                        Fields("SUM_COUNT").Value = String.Format("{0:#,##0}", TOTAL_CNT)
                        ' 売上金額
                        Fields("SUM_SALES").Value = String.Format("{0:#,##0}", TOTAL_SALES)
                        ' 粗利
                        Fields("SUM_MARGIN").Value = String.Format("{0:#,##0}", TOTAL_MARGIN)
                        ' 利益率（帳票上は小数点第1位で端数処理）
                        Fields("SUM_PROFIT_RATE").Value = String.Format("{0:0.0}", (TOTAL_MARGIN / TOTAL_SALES) * 100)

                        ' ワークエリアのクリア
                        PART_CNT = 0
                        PART_SALES = 0
                        PART_MARGIN = 0

                        TOTAL_CNT = 0
                        TOTAL_SALES = 0
                        TOTAL_MARGIN = 0
                    End If

                End If

            End If

            eArgs.EOF = False
        Else

            eArgs.EOF = True
        End If

    End Sub
End Class
