Public Class rOrderReport
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oOrderData() As cStructureLib.sOrderData
    Private oDataOrderDBIO As cDataOrderDBIO

    Private oOrderSubData() As cStructureLib.sOrderSubData
    Private oDataOrderSubDBIO As cDataOrderSubDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private ORDER_NUMBER As String
    Private REPORT_MODE As String       '税込み or 税抜き

    Private ReadOnly STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTool As cTool

    Private NoTaxPrice As Long          '小計

    Private iCnt As Integer             '詳細行の番号

    Private oTran As OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iOrderCode As String,
            ByVal iStaff_Code As String,
            ByVal iStaff_Name As String,
            ByVal iReportMode As String,
            ByRef iTran As OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        ORDER_NUMBER = iOrderCode
        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name
        REPORT_MODE = iReportMode

        oTool = New cTool

        iCnt = 0
        NoTaxPrice = 0

        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Windows.Forms.Application.Exit()
        End If
        oMstConfigDBIO = Nothing

        RECORD_CNT = 0

        oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)
        oDataOrderSubDBIO.getOrderSubData(oOrderSubData, iOrderCode, Nothing, oTran)

        RECORD_CNT = oOrderSubData.Length
        RECORD_NO = 0

        Me.Document.Name = "Eazy-POS 発注伝票"
    End Sub

    Private Sub rOrderReport_DataInitialize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.DataInitialize
        ' ヘッダー情報
        Fields.Add("SUPPLIER_NAME")
        Fields.Add("ORDER_CODE")
        Fields.Add("TOTAL_BEFORE_TAX_PRICE")
        Fields.Add("TOTAL_TAX_PRICE")
        '2019.9.5 A.Komita 追加 From
        Fields.Add("RTAX_RATE_PRICE")
        '2019.9.5 A.Komita 追加 To
        Fields.Add("TOTAL_AFTER_TAX_PRICE")
        Fields.Add("REQUEST_DATE")
        Fields.Add("REQUEST_PLACE")
        Fields.Add("PAYMENT")

        Fields.Add("BARCODE")

        '******************
        '     弊社情報
        '******************
        Fields.Add("POSTAL_CODE")
        Fields.Add("ADDRESS")
        Fields.Add("CORP_NAME")
        Fields.Add("TEL")
        Fields.Add("FAX")
        Fields.Add("TANTOU_NAME")
        '単位：円(税込）
        Fields.Add("REPORT_PEACE")

        '******************
        '     明細情報
        '******************
        Fields.Add("No")
        Fields.Add("PRODUCT_NAME")
        Fields.Add("JAN_CODE")
        Fields.Add("OPTION_VALUE")
        Fields.Add("PRICE")
        Fields.Add("COST")
        Fields.Add("CNT")
        Fields.Add("T_PRICE")
        '2019.9.5 A.Komita 追加 From
        Fields.Add("TAX")
        '2019.9.5 A.Komita 追加 To

        '******************
        '     集計情報
        '******************
        Fields.Add("POSTAGE")
        Fields.Add("FEE")
        Fields.Add("NO_TAX_TOTAL")
        Fields.Add("TAX_TOTAL")
        '2019.9.5 A.Komita 追加 From
        Fields.Add("RTAX_RATE")
        '2019.9.5 A.Komita 追加 To
        Fields.Add("DISCOUNT")
        Fields.Add("POINT_DISCOUNT")
        Fields.Add("IN_TAX_TOTAL")

        ' フッダー情報
        Fields.Add("MEMO")
    End Sub

    Private Sub rOrderReport_FetchData(ByVal sender As Object, ByVal eArgs As FetchEventArgs) Handles Me.FetchData
        '現金状況情報セット
        If RECORD_NO = 0 Then
            HEADER_INFO()
        End If

        If RECORD_NO >= RECORD_CNT Then
            eArgs.EOF = True
        Else
            DETILE_INFO()
            eArgs.EOF = False
        End If

        RECORD_NO = RECORD_NO + 1

    End Sub

    Private Sub HEADER_INFO()
        Dim oSupplierDBIO As cMstSupplierDBIO
        Dim oSupplier() As cStructureLib.sSupplier
        Dim oMstPaymentDBIO As cMstPaymentDBIO
        Dim oPayment() As cStructureLib.sPayment


        '発注情報
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        oDataOrderDBIO.getOrderData(oOrderData, ORDER_NUMBER, Nothing, Nothing, Nothing, oTran)


        '仕入先情報取得
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        ReDim oSupplier(0)
        oSupplierDBIO.getSupplier(oSupplier, oOrderData(0).sSupplierCode, Nothing, oTran)
        oSupplierDBIO = Nothing

        Fields("SUPPLIER_NAME").Value = oSupplier(0).sSupplierName

        Fields("ORDER_CODE").Value = ORDER_NUMBER

        '2019,9,28 A.Komita 修正 Start
        'If REPORT_MODE = "税込み" Then
        '    Fields("TOTAL_BEFORE_TAX_PRICE").Value = oOrderData(0).sNoTaxTotalPrice
        'Else
        '    Fields("TOTAL_BEFORE_TAX_PRICE").Value = oOrderData(0).sNoTaxTotalProductPrice
        'End If

        Fields("TOTAL_BEFORE_TAX_PRICE").Value = oOrderData(0).sNoTaxTotalPrice


        Fields("TOTAL_TAX_PRICE").Value = oOrderData(0).sTaxTotal
        Fields("RTAX_RATE_PRICE").Value = oOrderData(0).sReducedTaxRateTotal
        Fields("TOTAL_AFTER_TAX_PRICE").Value = oOrderData(0).sTotalPrice

        Fields("REQUEST_DATE").Value = oOrderData(0).sRequestDate
        Fields("REQUEST_PLACE").Value = oOrderData(0).sRequestPlace
        '2019,9,28 A.Komita 修正 End


        '支払方法情報取得
        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)
        ReDim oPayment(0)
        '2016.05.17 K.Oikawa s
        'oMstPaymentDBIO.getPayment(oPayment, oOrderData(0).sPaymentCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        oMstPaymentDBIO.getPayment(oPayment, oOrderData(0).sPaymentCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        '2016.05.17 K.Oikawa e
        oMstPaymentDBIO = Nothing

        Fields("PAYMENT").Value = oPayment(0).sPaymentName

        Fields("BARCODE").Value = ORDER_NUMBER

        '弊社情報セット
        Fields("POSTAL_CODE").Value = "〒" & oConf(0).sPostCode
        Fields("ADDRESS").Value = oConf(0).sAdderess1 & oConf(0).sAdderess2
        Fields("CORP_NAME").Value = oConf(0).sCorpName
        Fields("TEL").Value = "TEL：" & oConf(0).sTEL
        Fields("FAX").Value = "FAX：" & oConf(0).sFAX
        Fields("TANTOU_NAME").Value = STAFF_NAME

        If REPORT_MODE = "税込み" Then
            Fields("REPORT_PEACE").Value = "単位：円(税込み）"
        Else
            Fields("REPORT_PEACE").Value = "単位：円(税抜き）"
        End If

    End Sub

    Private Sub DETILE_INFO()
        Dim j As Integer
        Dim str As String

        If RECORD_NO < RECORD_CNT Then
            Fields("No").Value = RECORD_NO + 1
            Fields("PRODUCT_NAME").Value = oOrderSubData(RECORD_NO).sProductName & "(" & oOrderSubData(RECORD_NO).sProductCode & ")"
            Fields("JAN_CODE").Value = oOrderSubData(RECORD_NO).sJANCode
            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oOrderSubData(RECORD_NO).sOption1 <> "" Then
                            str = str + oConf(0).sOptionName1 & "=" & oOrderSubData(RECORD_NO).sOption1
                        End If
                    Case 2
                        If oOrderSubData(RECORD_NO).sOption2 <> "" Then
                            If str <> "" Then
                                str = str & Chr(10)
                            End If
                            str = str & oConf(0).sOptionName2 & "=" & oOrderSubData(RECORD_NO).sOption2
                        End If
                    Case 3
                        If oOrderSubData(RECORD_NO).sOption3 <> "" Then
                            If str <> "" Then
                                str = str & Chr(10)
                            End If
                            str = str + oConf(0).sOptionName3 & "=" & oOrderSubData(RECORD_NO).sOption3
                        End If
                    Case 4
                        If oOrderSubData(RECORD_NO).sOption4 <> "" Then
                            If str <> "" Then
                                str = str & Chr(10)
                            End If
                            str = str + oConf(0).sOptionName4 & "=" & oOrderSubData(RECORD_NO).sOption4
                        End If
                    Case 5
                        If oOrderSubData(RECORD_NO).sOption5 <> "" Then
                            If str <> "" Then
                                str = str & Chr(10)
                            End If
                            str = str + oConf(0).sOptionName5 & "=" & oOrderSubData(RECORD_NO).sOption5
                        End If
                End Select
            Next

            '2019,9,18 A.Komita 削除 Del--------------------------------------------------
            'Fields("OPTION_VALUE").Value = str
            'Fields("CNT").Value = oOrderSubData(RECORD_NO).sCount
            '2019,9,18 A.Komita 削除 End--------------------------------------------------

            Fields("OPTION_VALUE").Value = str

            '2019,9,20 A.Komita 修正 Start
            'If REPORT_MODE = "税込み" Then
            '    Fields("PRICE").Value = oOrderSubData(RECORD_NO).sPrice
            '    Fields("COST").Value = oOrderSubData(RECORD_NO).sCostPrice + oOrderSubData(RECORD_NO).sTaxPrice
            'Else
            Fields("PRICE").Value = oOrderSubData(RECORD_NO).sListPrice
            Fields("COST").Value = oOrderSubData(RECORD_NO).sCostPrice
            'End If
            '2019,9,20 A.Komita 修正 End

            Fields("CNT").Value = oOrderSubData(RECORD_NO).sCount

            '2019,9,27 A.Komita 修正 Start
            If REPORT_MODE = "税込み" Then
                Fields("T_PRICE").Value = oOrderSubData(RECORD_NO).sPrice
            Else
                Fields("T_PRICE").Value = oOrderSubData(RECORD_NO).sNoTaxPrice
            End If
            NoTaxPrice = NoTaxPrice + CLng(Fields("T_PRICE").Value)
            TOTAL_T_PRICE.Text = NoTaxPrice

            '2019,9,20 A.Komita 修正 Start
            If oOrderSubData(RECORD_NO).sReducedTaxRate = String.Empty Then
                Fields("TAX").Value = oConf(0).sTax
            Else
                Fields("TAX").Value = oOrderSubData(RECORD_NO).sReducedTaxRate
            End If

            '2019,9,20 A.Komita 修正 End

            '2019,9,20 A.Komita 削除 Del-------------------------------------------------------------------------------------------------
            'If REPORT_MODE = "税込み" Then
            '    Fields("PRICE").Value = oTool.BeforeToAfterTax(oOrderSubData(RECORD_NO).sListPrice, oConf(0).sTax, oConf(0).sFracProc)
            '    Fields("COST").Value = oTool.BeforeToAfterTax(oOrderSubData(RECORD_NO).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc)
            'Else
            '    Fields("PRICE").Value = oOrderSubData(RECORD_NO).sListPrice
            '    Fields("COST").Value = oOrderSubData(RECORD_NO).sUnitPrice
            'End If
            'Fields("T_PRICE").Value = CLng(Fields("COST").Value) * CLng(Fields("CNT").Value)
            'NoTaxPrice = NoTaxPrice + CLng(Fields("T_PRICE").Value)
            '2019,9,20 A.Komita 削除 End-------------------------------------------------------------------------------------------------           

        End If

    End Sub

    Protected Overrides Sub Finalize()
        oMstConfigDBIO = Nothing
        oDataOrderSubDBIO = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub GroupFooter7_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter7.Format
        '送料

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------
        If REPORT_MODE = "税込み" Then
            POSTAGE.Value = oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc)

        Else
            POSTAGE.Value = oOrderData(0).sShippingCharge

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------

    End Sub

    Private Sub GroupFooter6_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter6.Format
        '手数料

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------
        If REPORT_MODE = "税込み" Then
            FEE.Value = oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc)

        Else
            FEE.Value = oOrderData(0).sPaymentCharge

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------

    End Sub

    Private Sub GroupFooter5_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter5.Format
        '発注金額（税抜き）

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------
        Dim Postage_No_Tax As Integer = 0
        Dim Fee_No_Tax As Integer = 0

        If REPORT_MODE = "税込み" Then

            Postage_No_Tax = oTool.AfterToBeforeTax(POSTAGE.Value, oConf(0).sTax, oConf(0).sFracProc)
            Fee_No_Tax = oTool.AfterToBeforeTax(FEE.Value, oConf(0).sTax, oConf(0).sFracProc)

            NO_TAX_TOTAL.Value = oOrderData(0).sNoTaxTotalProductPrice + Postage_No_Tax + Fee_No_Tax + oOrderData(0).sTaxTotal + oOrderData(0).sReducedTaxRateTotal

        Else
            NO_TAX_TOTAL.Value = oOrderData(0).sNoTaxTotalProductPrice + POSTAGE.Value + FEE.Value

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------

    End Sub

    Private Sub GroupFooter4_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter4.Format
        '消費税

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------
        If REPORT_MODE = "税込み" Then
            TAX_TOTAL.Value = 0

        Else
            TAX_TOTAL.Value = oOrderData(0).sTaxTotal

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------

    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter3.Format

        '軽減税額

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------
        If REPORT_MODE = "税込み" Then
            RTAX_RATE.Value = 0

        Else
            RTAX_RATE.Value = oOrderData(0).sReducedTaxRateTotal

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------

    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter2.Format

        '値引き
        '2019,9,20 A.Komita 追加 From
        DISCOUNT.Value = oOrderData(0).sDiscount
        '2019,9,20 A.Komita 追加 To


    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As EventArgs) Handles GroupFooter1.Format
        'ポイント値引き
        '2019,9,20 A.Komita 追加 From
        POINT_DISCOUNT.Value = oOrderData(0).sPointDisCount
        '2019,9,20 A.Komita 追加 To

        '2019,10,23 A.Komita 修正 Start--------------------------------------------------------------------------------------------
        '発注金額（税込み）
        If REPORT_MODE = "税込み" Then
            IN_TAX_TOTAL.Value = NO_TAX_TOTAL.Value + (DISCOUNT.Value + POINT_DISCOUNT.Value)

        Else
            IN_TAX_TOTAL.Value = (NO_TAX_TOTAL.Value + TAX_TOTAL.Value + RTAX_RATE.Value) + (DISCOUNT.Value + POINT_DISCOUNT.Value)

        End If
        '2019,10,23 A.Komita 修正 End----------------------------------------------------------------------------------------------
        MEMO.Value = oOrderData(0).sMemo
    End Sub
End Class
