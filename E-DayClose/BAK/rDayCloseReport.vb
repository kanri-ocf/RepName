Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rDayCloseReport
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oAdjust() As cStructureLib.sAdjust
    Private oAdjustDBIO As cDataAdjustDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oCalc() As cStructureLib.sCalc
    Private oTrnSummary() As cStructureLib.sViewTrnSummary

    Private Const SRCCOPY As Integer = &HCC0020

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private CLOSE_DATE As String

    Private YCASH_TOTAL As Long
    Private CASHSALE_TOTAL As Long
    Private CASHSALE_CNT As Integer

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iCalc() As cStructureLib.sCalc, _
            ByRef iTrnSummary() As cStructureLib.sViewTrnSummary, _
            ByVal iStaff_Code As String, _
            ByVal iStaff_Name As String, _
            ByVal iCloseDate As String, _
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

        Dim RecordCnt As Integer

        '環境マスタ読込み
        ReDim oConf(1)

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            oConfMstDBIO = Nothing
            Application.Exit()
        End If
        oConfMstDBIO = Nothing

        oTool = New cTool

        RECORD_CNT = 0
        CASHSALE_TOTAL = 0
        CASHSALE_CNT = 0
        For i = 0 To oTrnSummary.Length - 1
            If oTrnSummary(i).sPaymentName = "現金払い" Then
                CASHSALE_TOTAL = CASHSALE_TOTAL + oTrnSummary(i).sPrice
                CASHSALE_CNT = CASHSALE_CNT + oTrnSummary(i).sCount
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

        Fields.Add("S_YCASH")
        Fields.Add("S_YCNT")
        Fields.Add("S_SALECASH")
        Fields.Add("S_SALECNT")
        Fields.Add("S_INCASH")
        Fields.Add("S_INCNT")
        Fields.Add("S_OUTCASH")
        Fields.Add("S_OUTCNT")
        Fields.Add("S_CALCASH")
        Fields.Add("S_RETCASH")
        Fields.Add("S_CCASH")

        '入出金明細表サブレーポート
        Fields.Add("INOUT_DETAIL")
    End Sub

    Private Sub fDayCloseReport_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
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

        Fields("CLOSEDATE").Value = String.Format("{0:yyyy年MM月dd日}", CDate(CLOSE_DATE))
        Fields("STAFFNAME").Value = STAFF_NAME
        '入金状況
        oAdjustDBIO = New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        AdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", CLOSE_DATE, "<=", oTran)
        RecordCount = oAdjustDBIO.getAdjust(oAdjust, AdjustCode, Nothing, Nothing, cStructureLib.GetAdjustMode.FromToAdjustCode, oTran)

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

        AdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", CDate(CLOSE_DATE), "=", oTran)
        RecordCount = oAdjustDBIO.getAdjust(oAdjust, AdjustCode, Nothing, Nothing, cStructureLib.GetAdjustMode.FromToAdjustCode, oTran)

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

        '<販売金額>
        ' *** START K.MINAGAWA 2013/04/04 ***
        ' Fields("S_SALES").Value = String.Format("{0:#,##0}", oReadData.sPrice)
        Fields("S_SALES").Value = String.Format("{0:#,##0}", oReadData.sPrice - oTool.BeforeToAfterTax(oReadData.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc))
        ' *** END   K.MINAGAWA 2013/04/04 ***

        '<数量>
        Fields("S_CNT").Value = String.Format("{0:#,##0}", oReadData.sCount)

        '<値引き>
        Fields("S_DISCOUNT").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oReadData.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc))

        '<送料>
        Fields("S_POSTAGE").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oReadData.sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))

        '<手数料>
        Fields("S_FEE").Value = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oReadData.sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))

        '<売上金額>
        Fields("S_BILL").Value = String.Format("{0:#,##0}", CLng(Fields("S_SALES").Value) + CLng(Fields("S_DISCOUNT").Value) + CLng(Fields("S_POSTAGE").Value) + CLng(Fields("S_FEE").Value))

    End Sub
    Private Sub SUM_CAL_INFO()
        Fields("S_YCASH").Value = YCASH_TOTAL
        Fields("S_YCNT").Value = "－"
        Fields("S_SALECASH").Value = CASHSALE_TOTAL
        Fields("S_SALECNT").Value = CASHSALE_CNT
        Fields("S_OUTCASH").Value = oCalc(0).sOutCash
        Fields("S_OUTCNT").Value = oCalc(0).sOutCashCnt
        Fields("S_INCASH").Value = oCalc(0).sInCash
        Fields("S_INCNT").Value = oCalc(0).sInCashCnt
        Fields("S_CALCASH").Value = oCalc(0).sBalance
        Fields("S_RETCASH").Value = oCalc(0).sRetCash
        Fields("S_CCASH").Value = oCalc(0).sBalance - oCalc(0).sRetCash
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim rpt As New rDayCloseReportSub1(oConn, oCommand, oDataReader, CLOSE_DATE, oTran)

        ' サブレポートコントロールにサブレポートオブジェクトをセットします。
        INOUT_DETAIL.Report = rpt

    End Sub
End Class
