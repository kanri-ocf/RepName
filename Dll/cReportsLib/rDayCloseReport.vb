Public Class rDayCloseReport
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oAdjust() As cStructureLib.sAdjust
    Private oAdjustDBIO As cDataAdjustDBIO

    Private oAdjust2() As cStructureLib.sAdjust

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oCalc() As cStructureLib.sCalc
    Private oTrnSummary() As cStructureLib.sViewTrnSummary

    ' *** START K.MINAGAWA 2013/04/29 ***
    Private oDataTrnMsDBIO As cDataTrnMsDBIO
    Private oTimeSales() As cStructureLib.sViewTimeSales
    ' *** END   K.MINAGAWA 2013/04/29 ***

    '2020,1,27 A.Komita 追加 From
    'Private oViewTrnFull() As cStructureLib.sViewTrnFull
    'Private oViewTrnFullDBIO As cViewTrnFullDBIO
    '2020,1,27 A.Komita 追加 To

    Private Const SRCCOPY As Integer = &HCC0020

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private CLOSE_DATE As String

    Private YCASH_TOTAL As Long
    Private CASHSALE_TOTAL As Long
    Private CASHSALE_CNT As Integer

    ' *** START K.MINAGAWA 2013/04/29 ***
    Private CRESALE_TOTAL As Long
    Private CRESALE_CNT As Long

    Private MEISAI_PRINT_FLG As Boolean

    Private oCloseDate As String
    ' *** END   K.MINAGAWA 2013/04/29 ***

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iCalc() As cStructureLib.sCalc,
            ByRef iTrnSummary() As cStructureLib.sViewTrnSummary,
            ByVal iStaff_Code As String,
            ByVal iStaff_Name As String,
            ByVal iCloseDate As String,
            ByVal iSubCloseDate As String,
            ByVal iMeisai_Print_Flg As Boolean,
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        Dim i As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oTrnSummary = iTrnSummary
        oCalc = iCalc

        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name
        CLOSE_DATE = iCloseDate

        ' *** START K.MINAGAWA 2013/04/29 ***
        MEISAI_PRINT_FLG = iMeisai_Print_Flg
        ' *** END   K.MINAGAWA 2013/04/29 ***

        Dim RecordCnt As Integer

        '環境マスタ読込み
        ReDim oConf(1)

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oConfMstDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If
        oConfMstDBIO = Nothing

        oTool = New cTool

        RECORD_CNT = 0
        CASHSALE_TOTAL = 0
        CASHSALE_CNT = 0
        ' *** START K.MINAGAWA 2013/04/29 ***
        CRESALE_TOTAL = 0
        CRESALE_CNT = 0



        If CLOSE_DATE = Nothing Then
            oCloseDate = iSubCloseDate
        Else
            oCloseDate = CLOSE_DATE
        End If
        ' *** END   K.MINAGAWA 2013/04/29 ***

        For i = 0 To oTrnSummary.Length - 1
            If oTrnSummary(i).sPaymentName = "現金払い" Then
                CASHSALE_TOTAL = CASHSALE_TOTAL + oTrnSummary(i).sPrice
                CASHSALE_CNT = CASHSALE_CNT + oTrnSummary(i).sCount
                ' *** START K.MINAGAWA 2013/04/29 ***
            ElseIf oTrnSummary(i).sPaymentName = "クレジットカード払い" Then
                CRESALE_TOTAL = CRESALE_TOTAL + oTrnSummary(i).sPrice
                CRESALE_CNT = CRESALE_CNT + oTrnSummary(i).sCount
                ' *** END   K.MINAGAWA 2013/04/29 ***
            End If
        Next
        RECORD_CNT = oTrnSummary.Length - 1
        RECORD_NO = 0
    End Sub


    Private Sub fDayCloseReport_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        ' ヘッダー情報
        Fields.Add("MAKE_DATE")
        Fields.Add("CLOSEDATE")
        Fields.Add("STAFFNAME")

        '******************
        '     現金状況
        '******************
        Fields.Add("D_R10000")
        Fields.Add("D_R5000")
        Fields.Add("D_R1000")
        Fields.Add("D_R500")
        Fields.Add("D_R100")
        Fields.Add("D_R50")
        Fields.Add("D_R10")
        Fields.Add("D_R5")
        Fields.Add("D_R1")

        Fields.Add("D_K10000")
        Fields.Add("D_K5000")
        Fields.Add("D_K1000")
        Fields.Add("D_K500")
        Fields.Add("D_K100")
        Fields.Add("D_K50")
        Fields.Add("D_K10")
        Fields.Add("D_K5")
        Fields.Add("D_K1")

        Fields.Add("D_R_TOTAL")
        Fields.Add("D_K_TOTAL")

        Fields.Add("D_TOTAL")

        Fields.Add("K_R10000")
        Fields.Add("K_R5000")
        Fields.Add("K_R1000")
        Fields.Add("K_R500")
        Fields.Add("K_R100")
        Fields.Add("K_R50")
        Fields.Add("K_R10")
        Fields.Add("K_R5")
        Fields.Add("K_R1")

        Fields.Add("K_K10000")
        Fields.Add("K_K5000")
        Fields.Add("K_K1000")
        Fields.Add("K_K500")
        Fields.Add("K_K100")
        Fields.Add("K_K50")
        Fields.Add("K_K10")
        Fields.Add("K_K5")
        Fields.Add("K_K1")

        Fields.Add("K_R_TOTAL")
        Fields.Add("K_K_TOTAL")

        Fields.Add("K_TOTAL")

        '******************
        '     集計状況
        '******************
        Fields.Add("S_CLASS")
        Fields.Add("S_BUMON")
        Fields.Add("S_CHANNEL")
        Fields.Add("S_PAYMENT")
        Fields.Add("S_SALES")
        Fields.Add("S_CNT")
        Fields.Add("S_DISCOUNT")
        Fields.Add("S_POSTAGE")
        Fields.Add("S_FEE")
        Fields.Add("S_BILL")
        '2020,1,29 A.Komita 2回目以降のループで同じ支払方法が連続すると値を上書きする為、S_PAYMENT以降のフィールドを複数追加 From
        Fields.Add("S_PAYMENT")
        ' Fields.Add("S_PAYMENT_2")
        Fields.Add("S_SALES")
        ' Fields.Add("S_SALES_2")
        Fields.Add("S_CNT")
        ' Fields.Add("S_CNT_2")
        Fields.Add("S_DISCOUNT")
        ' Fields.Add("S_DISCOUNT_2")
        Fields.Add("S_POSTAGE")
        ' Fields.Add("S_POSTAGE_2")
        Fields.Add("S_FEE")
        ' Fields.Add("S_FEE_2")
        Fields.Add("S_BILL")
        ' Fields.Add("S_BILL_2")
        '2020,1,29 A.Komita 追加 To

        Fields.Add("S_YCASH")
        Fields.Add("S_YCNT")
        Fields.Add("S_SALECASH")
        Fields.Add("S_SALECNT")
        ' *** START K.MINAGAWA 2013/04/29 ***
        Fields.Add("S_SALECREDIT")
        Fields.Add("S_CREDITCNT")
        ' *** END   K.MINAGAWA 2013/04/29 ***
        Fields.Add("S_INCASH")
        Fields.Add("S_INCNT")
        Fields.Add("S_OUTCASH")
        Fields.Add("S_OUTCNT")
        Fields.Add("S_CALCASH")
        Fields.Add("S_RETCASH")
        Fields.Add("S_CCASH")

        '入出金明細表サブレポート
        Fields.Add("INOUT_DETAIL")
    End Sub

    Private Sub fDayCloseReport_FetchData(ByVal sender As Object, ByVal eArgs As FetchEventArgs) Handles Me.FetchData
        '現金状況情報セット
        If RECORD_NO = 0 Then
            CASH_INFO()
            SUM_CAL_INFO()
        End If

        If RECORD_NO > RECORD_CNT Then
            eArgs.EOF = True
        Else
            CAL_INFO(oTrnSummary(RECORD_NO))
            eArgs.EOF = False
        End If

        RECORD_NO = RECORD_NO + 1
    End Sub
    Private Sub CASH_INFO()
        Dim AdjustCode As Long
        Dim RecordCount As Long

        Fields("CLOSEDATE").Value = String.Format("{0:yyyy年MM月dd日}", CDate(oCloseDate))
        Fields("STAFFNAME").Value = STAFF_NAME
        '入金状況
        oAdjustDBIO = New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        AdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", CLOSE_DATE, "<=", oTran)
        RecordCount = oAdjustDBIO.getAdjust(oAdjust2, AdjustCode, Nothing, Nothing, Nothing, Nothing, oTran)
        RecordCount = oAdjustDBIO.getAdjust(oAdjust, AdjustCode, AdjustCode, Nothing, Nothing, Nothing, oTran)

        Fields("D_R10000").Value = oAdjust(0).sD10000Yen
        Fields("D_R5000").Value = oAdjust(0).sD5000Yen
        Fields("D_R1000").Value = oAdjust(0).sD1000Yen
        Fields("D_R500").Value = oAdjust(0).sD500Yen
        Fields("D_R100").Value = oAdjust(0).sD100Yen
        Fields("D_R50").Value = oAdjust(0).sD50Yen
        Fields("D_R10").Value = oAdjust(0).sD10Yen
        Fields("D_R5").Value = oAdjust(0).sD5Yen
        Fields("D_R1").Value = oAdjust(0).sD1Yen

        Fields("D_R_TOTAL").Value = oAdjust(0).sDTotalPrice

        Fields("D_K10000").Value = oAdjust(0).sK10000Yen
        Fields("D_K5000").Value = oAdjust(0).sK5000Yen
        Fields("D_K1000").Value = oAdjust(0).sK1000Yen
        Fields("D_K500").Value = oAdjust(0).sK500Yen
        Fields("D_K100").Value = oAdjust(0).sK100Yen
        Fields("D_K50").Value = oAdjust(0).sK50Yen
        Fields("D_K10").Value = oAdjust(0).sK10Yen
        Fields("D_K5").Value = oAdjust(0).sK5Yen
        Fields("D_K1").Value = oAdjust(0).sK1Yen

        Fields("D_K_TOTAL").Value = oAdjust(0).sKTotalPrice

        Fields("D_TOTAL").Value = oAdjust(0).sTotalPrice
        YCASH_TOTAL = oAdjust(0).sTotalPrice

        AdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", CDate(oCloseDate), "=", oTran)
        RecordCount = oAdjustDBIO.getAdjust(oAdjust, AdjustCode, AdjustCode, Nothing, Nothing, Nothing, oTran)

        Fields("K_R10000").Value = oAdjust(0).sD10000Yen
        Fields("K_R5000").Value = oAdjust(0).sD5000Yen
        Fields("K_R1000").Value = oAdjust(0).sD1000Yen
        Fields("K_R500").Value = oAdjust(0).sD500Yen
        Fields("K_R100").Value = oAdjust(0).sD100Yen
        Fields("K_R50").Value = oAdjust(0).sD50Yen
        Fields("K_R10").Value = oAdjust(0).sD10Yen
        Fields("K_R5").Value = oAdjust(0).sD5Yen
        Fields("K_R1").Value = oAdjust(0).sD1Yen

        Fields("K_R_TOTAL").Value = oAdjust(0).sDTotalPrice

        Fields("K_K10000").Value = oAdjust(0).sK10000Yen
        Fields("K_K5000").Value = oAdjust(0).sK5000Yen
        Fields("K_K1000").Value = oAdjust(0).sK1000Yen
        Fields("K_K500").Value = oAdjust(0).sK500Yen
        Fields("K_K100").Value = oAdjust(0).sK100Yen
        Fields("K_K50").Value = oAdjust(0).sK50Yen
        Fields("K_K10").Value = oAdjust(0).sK10Yen
        Fields("K_K5").Value = oAdjust(0).sK5Yen
        Fields("K_K1").Value = oAdjust(0).sK1Yen

        Fields("K_K_TOTAL").Value = oAdjust(0).sKTotalPrice

        Fields("K_TOTAL").Value = oAdjust(0).sTotalPrice

        oAdjustDBIO = Nothing
    End Sub

    Private Sub CAL_INFO(ByVal oReadData As cStructureLib.sViewTrnSummary)

        '<取引区分>
        Fields("S_CLASS").Value = oReadData.sTrnClass

        '<部門名称>
        Fields("S_BUMON").Value = oReadData.sBumonShortName

        '<チャネル名称>
        Fields("S_CHANNEL").Value = oReadData.sChannelName

        '<支払方法>
        Fields("S_PAYMENT").Value = oReadData.sPaymentName

        '-----------------------------------------------------------------------
        ' 2019/10/24  suzuki 値引き税率計算なし、販売金額の表示
        '-----------------------------------------------------------------------

        ''<販売金額>
        '2020,1,27 A.Komita 日時集計表の通常税率商品の販売金額を税込にする為条件分岐を追加 From
        If oReadData.sReducedTaxRate = 0 Then
            oReadData.sNoTaxProductPrice = oTool.BeforeToAfterTax(oReadData.sNoTaxProductPrice, oConf(0).sTax, oConf(0).sFracProc)
        Else
            oReadData.sNoTaxProductPrice = oTool.BeforeToAfterTax(oReadData.sNoTaxProductPrice, oReadData.sReducedTaxRate, oConf(0).sFracProc)
        End If
        '2020,1,27 A.Komita 追加 To
        Fields("S_SALES").Value = String.Format("{0:#,##0}", oReadData.sNoTaxProductPrice)
        'String.Format("{0:#,##0}", （oReadData.sPrice - Fields("S_FEE").Value - Fields("S_POSTAGE").Value - Fields("S_DISCOUNT").Value）)


        '<数量>
        Fields("S_CNT").Value = String.Format("{0:#,##0}", oReadData.sCount)

        '<値引き>
        Fields("S_DISCOUNT").Value = String.Format("{0:#,##0}", oReadData.sDiscountPrice)

        '<送料>
        Fields("S_POSTAGE").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oReadData.sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))

        '<手数料>
        Fields("S_FEE").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oReadData.sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))

        '<売上金額>
        'Fields("S_BILL").Value = String.Format("{0:#,##0}", CLng(Fields("S_SALES").Value) + CLng(Fields("S_DISCOUNT").Value) + CLng(Fields("S_POSTAGE").Value) + CLng(Fields("S_FEE").Value))
        Fields("S_BILL").Value = String.Format("{0:#,##0}", （oReadData.sNoTaxProductPrice + Fields("S_FEE").Value + Fields("S_POSTAGE").Value) + Fields("S_DISCOUNT").Value）
        'String.Format("{0:#,##0}", oReadData.sPrice)
        '-----------------------------------------------------------------------
        ' 2019/10/24  suzuki END
        '-----------------------------------------------------------------------

    End Sub
    Private Sub SUM_CAL_INFO()
        Fields("S_YCASH").Value = YCASH_TOTAL
        Fields("S_YCNT").Value = "－"
        Fields("S_SALECASH").Value = CASHSALE_TOTAL
        Fields("S_SALECNT").Value = CASHSALE_CNT
        ' *** START K.MINAGAWA 2013/04/29 ***
        Fields("S_SALECREDIT").Value = CRESALE_TOTAL
        Fields("S_CREDITCNT").Value = CRESALE_CNT
        ' *** START K.MINAGAWA 2013/04/29 ***
        Fields("S_OUTCASH").Value = oCalc(0).sOutCash
        Fields("S_OUTCNT").Value = oCalc(0).sOutCashCnt
        Fields("S_INCASH").Value = oCalc(0).sInCash
        Fields("S_INCNT").Value = oCalc(0).sInCashCnt
        Fields("S_CALCASH").Value = oCalc(0).sBalance
        Fields("S_RETCASH").Value = oCalc(0).sRetCash
        Fields("S_CCASH").Value = oCalc(0).sBalance - oCalc(0).sRetCash
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        ' *** START K.MINAGAWA 2013/04/29 ***
        Dim iRealChannel() As String
        Dim iNetChannel() As String

        Dim tLastDate As String
        Dim tStartTime As String
        Dim tEndTime As String
        Dim tStHoliday As String
        Dim tEndHoliday As String
        ' *** END   K.MINAGAWA 2013/04/29 ***

        ' *** START K.MINAGAWA 2013/04/15 ***
        ''Dim rpt As New rDayCloseReportSub1(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)
        'Dim rpt1 As New rDayCloseReportSub1(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)

        'Dim rpt1 As New rDayCloseReportSub1(oConn, oCommand, oDataReader, oCloseDate, oTran)
        Dim rpt1 As New rDayCloseReportSub1(oConn, oCommand, oDataReader, oAdjust2(0).sAdjustCode, Nothing, oCloseDate, oTran)


        Dim rpt2 As New rDayCloseReportSub2(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)
        Dim rpt3 As New rDayCloseReportSub3(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)
        Dim rpt4 As New rDayCloseReportSub4(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)
        ' *** END   K.MINAGAWA 2013/04/15 ***
        ' *** START K.MINAGAWA 2013/04/29 ***
        Dim rpt5 As New rDayCloseReportSub5(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)
        Dim rpt6 As New rDayCloseReportSub6(oConn, oCommand, oDataReader, CLOSE_DATE, 1, oTran)
        Dim rpt7 As New rDayCloseReportSub6(oConn, oCommand, oDataReader, CLOSE_DATE, 2, oTran)

        iRealChannel = Nothing
        iNetChannel = Nothing

        tLastDate = Nothing
        tStartTime = Nothing
        tEndTime = Nothing
        tStHoliday = Nothing
        tEndHoliday = Nothing

        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)
        ' *** END   K.MINAGAWA 2013/04/29 ***

        ' サブレポートコントロールにサブレポートオブジェクトをセットします。
        ' *** START K.MINAGAWA 2013/04/15 ***
        ''INOUT_DETAIL1.Report = rpt
        INOUT_DETAIL1.Report = rpt1
        ' *** START K.MINAGAWA 2013/04/29 ***
        ''INOUT_DETAIL2.Report = rpt2
        ''INOUT_DETAIL3.Report = rpt3
        ''INOUT_DETAIL4.Report = rpt4
        ' *** END   K.MINAGAWA 2013/04/29 ***
        ' *** END   K.MINAGAWA 2013/04/15 ***

        ' *** START K.MINAGAWA 2013/04/29 ***

        ' 明細を印書する場合
        If MEISAI_PRINT_FLG = True Then
            PageBreak1.Enabled = True
            PageBreak2.Enabled = True

            INOUT_DETAIL2.Report = rpt2
            INOUT_DETAIL3.Report = rpt3
            INOUT_DETAIL4.Report = rpt4
            INOUT_DETAIL5.Report = rpt5
            ' リアル店舗
            INOUT_DETAIL6.Report = rpt6

            'ネット店舗(対象データがない時は改ページ・グラフを印字しない)
            If oDataTrnMsDBIO.getNetShopSales(oTimeSales, oCloseDate, oTran) > 0 Then
                INOUT_DETAIL7.Report = rpt7
            Else
                INOUT_DETAIL7.Visible = False
            End If

        End If
        ' *** END   K.MINAGAWA 2013/04/29 ***
    End Sub


End Class

Friend Class S_SALES_1
End Class
