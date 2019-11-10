Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rShipmentReport
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig

    Private oShipmentData() As cStructureLib.sShipmentData
    Private oDataShipmentDBIO As cDataShipmentDBIO

    Private oShipmentSubData() As cStructureLib.sShipmentSubData
    Private oDataShipmentSubDBIO As cDataShipmentSubDBIO

    Private oTool As cTool

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    '2019/10/10 shimizu add start
    Private TOTAL_ITEMS_PRICE As Long
    '2019/10/10 shimizu add end

    Private SHIPMENT_NUMBER As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private RESHIP_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
        ByRef iCommand As OleDb.OleDbCommand,
        ByRef iDataReader As OleDb.OleDbDataReader,
        ByRef iShipmentCode As String,
        ByVal iStaff_Code As String,
        ByVal iStaff_Name As String,
        ByVal iReShipFlg As Boolean,
        ByRef iTran As System.Data.OleDb.OleDbTransaction
)
        Dim RecordCnt As Integer
        Dim oMstConfigDBIO As New cMstConfigDBIO(oConn, oCommand, oDataReader)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oTool = New cTool

        SHIPMENT_NUMBER = iShipmentCode
        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name

        If iReShipFlg = True Then
            RESHIP_FLG = True

            RESHIP_L.Visible = True
            RESHIP_SHAPE.Visible = True
        Else
            RESHIP_FLG = False

            RESHIP_L.Visible = False
            RESHIP_SHAPE.Visible = False
        End If

        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If
        oMstConfigDBIO = Nothing

        RECORD_CNT = 0
        RECORD_NO = 0

        '納品書ロゴの設定


        '出荷情報
        ReDim oShipmentData(0)
        oDataShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oDataShipmentDBIO.getShipment(oShipmentData, Nothing, Nothing, SHIPMENT_NUMBER, Nothing, Nothing, Nothing, Nothing, oTran)

        '出荷明細情報
        ReDim oShipmentSubData(0)
        oDataShipmentSubDBIO = New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)
        RECORD_CNT = oDataShipmentSubDBIO.getSubShipment(oShipmentSubData, Nothing, SHIPMENT_NUMBER, Nothing, oTran)

    End Sub

    Private Sub rShipmentReport_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        '******************
        ' ヘッダー情報
        '******************
        Fields.Add("COSTOMER_NAME")
        Fields.Add("BILL_PRICE")
        Fields.Add("TAX_PRICE")
        '2019/10/9 shimizu add start
        Fields.Add("R_TAX_RATE_PRICE")
        '2019/10/9 shimizu add end
        Fields.Add("PAYMENT")

        '******************
        '     弊社情報
        '******************
        Fields.Add("POSTAL_CODE")
        Fields.Add("ADDRESS")
        Fields.Add("CORP_NAME")
        Fields.Add("TEL")
        Fields.Add("FAX")
        Fields.Add("TANTOU_NAME")

        '******************
        '     明細情報
        '******************
        Fields.Add("No")
        Fields.Add("PRODUCT_NAME")
        Fields.Add("JAN_CODE")
        Fields.Add("OPTION_VALUE")
        Fields.Add("PRICE")
        Fields.Add("CNT")
        Fields.Add("T_PRICE")
        '2019/10/9 shimizu add start
        Fields.Add("TAX_RATE")
        '2019/10/9 shimizu add end


        '******************
        ' フッダー情報
        '******************
        Fields.Add("PRODUCT_PRICE")
        Fields.Add("POSTAGE_PRICE")
        Fields.Add("FEE_PRICE")
        Fields.Add("DISCOUNT_PRICE")
        Fields.Add("POINT_DISCOUNT_PRICE")
        Fields.Add("TOTAL_PRICE")
        Fields.Add("TAX_F_PRICE")
        '2019/10/9 shimizu add start
        Fields.Add("R_TAX_RATE_F_PRICE")
        '2019/10/9 shimizu add end
        Fields.Add("MEMO")
    End Sub

    Private Sub rShipmentReport_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
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
        Dim oRequestData() As cStructureLib.sRequestData
        Dim oDataRequestDBIO As New cDataRequestDBIO(oConn, oCommand, oDataReader)
        Dim oChannelPaymentFull() As cStructureLib.sViewChannelPaymentFull
        Dim oChannelPaymentDBIO As New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)

        '注文情報読込み
        ReDim oRequestData(0)
        oDataRequestDBIO.getRequest(
                                    oRequestData,
                                    Nothing,
                                    oShipmentData(0).sRequestCode,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    oTran)

        Fields("COSTOMER_NAME").Value = oRequestData(0).sShip1stName & " " & oRequestData(0).sShip2ndName
        Fields("BILL_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sTotalPrice)
        Fields("TAX_PRICE").Value = String.Format("（内消費税： {0:C} ）", oShipmentData(0).sTaxTotal)
        '2019/10/9 shimizu add start
        Fields("R_TAX_RATE_PRICE").Value = String.Format("（内軽減税： {0:C} ）", oShipmentData(0).sReducedTaxRateTotal)
        '2019/10/9 shimizu add end


        '支払方法名称読込み
        ReDim oChannelPaymentFull(0)
        oChannelPaymentDBIO.getChannelPaymentFull(oChannelPaymentFull,
                                                      oRequestData(0).sChannelPaymentCode,
                                                      oRequestData(0).sChannelCode,
                                                      Nothing,
                                                      Nothing,
                                                      Nothing,
                                                      oTran)
        Fields("PAYMENT").Value = oChannelPaymentFull(0).sPaymentName
        If System.IO.File.Exists("Picture\" & oConf(0).sRLogoPass) Then
            LOGO_P.Image = System.Drawing.Image.FromFile("Picture\" & oConf(0).sRLogoPass)
        End If
        '弊社情報セット
        Fields("POSTAL_CODE").Value = "〒" & oConf(0).sPostCode
        Fields("ADDRESS").Value = oConf(0).sAdderess1 & oConf(0).sAdderess2
        Fields("CORP_NAME").Value = oConf(0).sCorpName
        Fields("TEL").Value = "TEL：" & oConf(0).sTEL
        Fields("FAX").Value = "FAX：" & oConf(0).sFAX
        Fields("TANTOU_NAME").Value = STAFF_NAME

        '集計情報
        '2019/10/10 shimizu upd start
        'Fields("PRODUCT_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sNoTaxTotalProductPrice, oConf(0).sTax, oConf(0).sFracProc))
        'Fields("POSTAGE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
        'Fields("FEE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
        'Fields("DISCOUNT_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sDiscount, oConf(0).sTax, oConf(0).sFracProc))
        'Fields("POINT_DISCOUNT_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sPointDisCount, oConf(0).sTax, oConf(0).sFracProc))

        Fields("POSTAGE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
        Fields("FEE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oShipmentData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
        Fields("DISCOUNT_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sDiscount)
        Fields("POINT_DISCOUNT_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sPointDisCount)
        '2019/10/10 shimizu upd end

        Fields("TOTAL_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sTotalPrice)
        Fields("TAX_F_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sTaxTotal)

        '2019/10/9 shimizu add start
        Fields("R_TAX_RATE_F_PRICE").Value = String.Format("{0:C}", oShipmentData(0).sReducedTaxRateTotal)
        '2019/10/9 shimizu add start

        Fields("MEMO").Value = oShipmentData(0).sShipMemo
    End Sub
    Private Sub DETILE_INFO()
        Dim j As Integer
        Dim str As String
        Dim oName() As String
        Dim oValue() As String

        If RECORD_NO < RECORD_CNT Then
            Fields("No").Value = RECORD_NO + 1
            Fields("PRODUCT_NAME").Value = oShipmentSubData(RECORD_NO).sProductName
            Fields("JAN_CODE").Value = oShipmentSubData(RECORD_NO).sJANCode

            'オプション整形
            str = ""
            oName = oShipmentSubData(RECORD_NO).sOptionName.Split(":")
            oValue = oShipmentSubData(RECORD_NO).sOptionValue.Split(":")
            str = ""
            For j = 0 To oName.Length - 1
                If str <> "" And oValue(j) <> "" Then
                    str = str & Chr(10)
                End If
                If oValue(j) <> "" Then
                    str = str & oName(j) & "=" & oValue(j)
                End If
            Next

            Fields("OPTION_VALUE").Value = str
            Fields("PRICE").Value = oShipmentSubData(RECORD_NO).sUnitPrice
            Fields("CNT").Value = oShipmentSubData(RECORD_NO).sCount
            Fields("T_PRICE").Value = oShipmentSubData(RECORD_NO).sPrice

            '2019/10/10 shimizu add start
            If oShipmentSubData(RECORD_NO).sReducedTaxRate = String.Empty Then
                Fields("TAX_RATE").Value = oConf(0).sTax & "%"
            Else
                Fields("TAX_RATE").Value = oShipmentSubData(RECORD_NO).sReducedTaxRate & "%"
            End If


            TOTAL_ITEMS_PRICE = oShipmentSubData(RECORD_NO).sPrice
            Fields("PRODUCT_PRICE").Value = String.Format("{0:C}", CLng(Fields("PRODUCT_PRICE").Value) + TOTAL_ITEMS_PRICE)
            '2019/10/10 shimizu add end

        End If
    End Sub

    Protected Overrides Sub Finalize()
        oDataShipmentDBIO = Nothing
        oDataShipmentSubDBIO = Nothing

        MyBase.Finalize()
    End Sub
End Class
