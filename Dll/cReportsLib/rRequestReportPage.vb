
Public Class rRequestReportPage
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oRequestData() As cStructureLib.sRequestData
    Private oRequestDataDBIO As cDataRequestDBIO
    Private rRequestData() As cStructureLib.sRequestData

    Private oRequestSubData() As cStructureLib.sRequestSubData
    Private oRequestSubDataDBIO As cDataRequestSubDBIO
    Private rRequestSubData() As cStructureLib.sRequestSubData

    Private oChannelPaymentFull() As cStructureLib.sViewChannelPaymentFull
    Private oChannelPaymentMstDBIO As cMstChannelPaymentDBIO

    Private oTool As cTool

    Private RECORD_CNT As Long
    Private H_RECORD_NO As Integer
    Private D_RECORD_NO As Integer
    Private DETILE_NO As Integer

    Private oRequestCode As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private Tran As OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iRequestCode As String,
            ByVal iSelectRowCount As Integer,
            ByRef iTran As OleDb.OleDbTransaction)

        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Integer
        Dim j As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oRequestCode = iRequestCode
        RECORD_CNT = iSelectRowCount

        '環境マスタ読込み
        ReDim oConf(1)
        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, Tran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                                    "開発元にお問い合わせ下さい",
                                                     Nothing, Nothing)
            Message_form.ShowDialog()
            Windows.Forms.Application.DoEvents()
            oConfMstDBIO = Nothing
            Windows.Forms.Application.Exit()
        End If
        oConfMstDBIO = Nothing

        oRequestDataDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oRequestSubDataDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        H_RECORD_NO = 0
        D_RECORD_NO = 0

        ReDim rRequestData(0)
        oRequestDataDBIO.getRequest(rRequestData,
                                    Nothing,
                                    oRequestCode,
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
                                    Tran)
        ReDim rRequestSubData(0)
        oRequestSubDataDBIO.getSubRequest(rRequestSubData, oRequestCode, Nothing, Tran)

        '抽出データをレポートデータとして設定
        'ヘッダー情報コピー
        For j = 0 To rRequestData.Length - 1
            If oRequestData Is Nothing Then
                ReDim oRequestData(0)
            Else
                ReDim Preserve oRequestData(oRequestData.Length)
            End If
            oRequestData(oRequestData.Length - 1) = rRequestData(j)
        Next

        '明細情報コピー
        For j = 0 To rRequestSubData.Length - 1
            If oRequestSubData Is Nothing Then
                ReDim oRequestSubData(0)
            Else
                ReDim Preserve oRequestSubData(oRequestSubData.Length)
            End If
            oRequestSubData(oRequestSubData.Length - 1) = rRequestSubData(j)
        Next
        '    End If
        'Next i

    End Sub

    Private Sub rRequestReport_DataInitialize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.DataInitialize
        '******************
        ' 注文情報
        '******************
        Fields.Add("REQUEST_CODE")
        Fields.Add("ORG_REQUEST_CODE")
        Fields.Add("CHANNEL_NAME")
        Fields.Add("REQUEST_DATE")
        Fields.Add("BARCODE")

        '******************
        '  請求者情報
        '******************
        Fields.Add("B_POST_CODE")
        Fields.Add("B_COUNTRY")
        Fields.Add("B_STATE")
        Fields.Add("B_CITY")
        Fields.Add("B_ADDRESS1")
        Fields.Add("B_ADDRESS2")
        Fields.Add("B_NAME")
        Fields.Add("B_TEL")
        Fields.Add("B_MAIL")

        '******************
        '  送付先
        '******************
        Fields.Add("S_POST_CODE")
        Fields.Add("S_COUNTRY")
        Fields.Add("S_STATE")
        Fields.Add("S_CITY")
        Fields.Add("S_ADDRESS1")
        Fields.Add("S_ADDRESS2")
        Fields.Add("S_NAME")
        Fields.Add("S_TEL")

        '******************
        '  お支払い情報
        '******************
        Fields.Add("PAYMENT")
        Fields.Add("PAY_COUNT")

        '******************
        '  注意事項
        '******************
        Fields.Add("NOSHI")
        Fields.Add("GIFT")
        Fields.Add("NOSHI_NAME")
        Fields.Add("GIFT_TYPE")
        Fields.Add("OTHER_REQ")

        '******************
        '  発送方法
        '******************
        Fields.Add("SHIP_CORP")
        Fields.Add("SHIP_REQDATE")
        Fields.Add("SHIP_REQTIME")
        Fields.Add("MEMO")

        '******************
        ' 請求金額情報
        '******************
        Fields.Add("SALE_TOTAL")
        Fields.Add("TOTAL")
        Fields.Add("POSTAGE")
        Fields.Add("FEE")
        Fields.Add("TAX")
        '2019,10,18 A.Komita 追加 From
        Fields.Add("REDUCED_TAX")
        '2019,10,18 A.Komita 追加 To
        Fields.Add("POINT")
        Fields.Add("DISCOUNT")

        '******************
        ' 明細情報
        '******************
        Fields.Add("NO")
        Fields.Add("PRODUCT_NAME")
        Fields.Add("PRODUCT_CODE")
        Fields.Add("OPTION_VALUE")
        Fields.Add("PRICE")
        Fields.Add("CNT")
        Fields.Add("T_PRICE")

    End Sub

    Private Sub rRequestReport_FetchData(ByVal sender As Object, ByVal eArgs As FetchEventArgs) Handles Me.FetchData
        If D_RECORD_NO < oRequestSubData.Length Then
            If H_RECORD_NO = 0 Then
                HEADER_INFO()

            ElseIf oRequestSubData.Length >= 2 Then
                If (oRequestSubData(D_RECORD_NO).sRequestCode <> oRequestSubData(D_RECORD_NO - 1).sRequestCode) Then
                    HEADER_INFO()
                End If
            End If
        End If

        If D_RECORD_NO >= oRequestSubData.Length Then
            eArgs.EOF = True
        Else
            While oRequestSubData(D_RECORD_NO).sProductCode = ""
                If D_RECORD_NO >= oRequestSubData.Length Then
                    DETILE_NO = DETILE_NO + 1
                    D_RECORD_NO = D_RECORD_NO + 1
                Else
                    Exit Sub
                End If
            End While
            If oRequestSubData(D_RECORD_NO).sProductCode <> "" Then
                DETILE_INFO()
                eArgs.EOF = False
            End If
        End If
    End Sub

    Private Sub HEADER_INFO()
        Dim oChannelDBIO As cMstChannelDBIO
        Dim oChannel() As cStructureLib.sChannel

        '******************
        ' 注文情報
        '******************
        Fields("REQUEST_CODE").Value = oRequestData(H_RECORD_NO).sRequestCode
        Fields("ORG_REQUEST_CODE").Value = oRequestData(H_RECORD_NO).sORRequestCode

        'チャネル名称取得
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        ReDim oChannel(0)
        oChannelDBIO.getChannelMst(oChannel, oRequestData(H_RECORD_NO).sChannelCode, Nothing, Nothing, Nothing, Tran)
        oChannelDBIO = Nothing
        Fields("CHANNEL_NAME").Value = oChannel(0).sChannelName

        Fields("REQUEST_DATE").Value = oRequestData(H_RECORD_NO).sRequestDate

        Fields("BARCODE").Value = oRequestData(H_RECORD_NO).sRequestCode

        '******************
        '  請求者情報
        '******************
        Fields("B_POST_CODE").Value = oRequestData(H_RECORD_NO).sBillPostCode1 & "-" & oRequestData(H_RECORD_NO).sBillPostCode2
        Fields("B_COUNTRY").Value = oRequestData(H_RECORD_NO).sBillCountry
        Fields("B_STATE").Value = oRequestData(H_RECORD_NO).sBillState
        Fields("B_CITY").Value = oRequestData(H_RECORD_NO).sBillCity
        Fields("B_ADDRESS1").Value = oRequestData(H_RECORD_NO).sBillAdder1
        Fields("B_ADDRESS2").Value = oRequestData(H_RECORD_NO).sBillAdder2
        Fields("B_NAME").Value = oRequestData(H_RECORD_NO).sBill1stName & " " & oRequestData(H_RECORD_NO).sBill2ndName
        Fields("B_TEL").Value = oRequestData(H_RECORD_NO).sBillTel
        Fields("B_MAIL").Value = oRequestData(H_RECORD_NO).sMailAdderss

        '******************
        '  送付先
        '******************
        Fields("S_POST_CODE").Value = oRequestData(H_RECORD_NO).sShipPostCode1 & "-" & oRequestData(H_RECORD_NO).sShipPostCode2
        Fields("S_COUNTRY").Value = oRequestData(H_RECORD_NO).sShipCountry
        Fields("S_STATE").Value = oRequestData(H_RECORD_NO).sShipState
        Fields("S_CITY").Value = oRequestData(H_RECORD_NO).sShipCity
        Fields("S_ADDRESS1").Value = oRequestData(H_RECORD_NO).sShipAdder1
        Fields("S_ADDRESS2").Value = oRequestData(H_RECORD_NO).sShipAdder2
        Fields("S_NAME").Value = oRequestData(H_RECORD_NO).sShip1stName & " " & oRequestData(H_RECORD_NO).sShip2ndName
        Fields("S_TEL").Value = oRequestData(H_RECORD_NO).sShipTel

        '******************
        '  お支払い情報
        '******************
        oChannelPaymentMstDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)
        oChannelPaymentMstDBIO.getChannelPaymentFull(oChannelPaymentFull, oRequestData(H_RECORD_NO).sChannelPaymentCode, Nothing, Nothing, Nothing, Nothing, Tran)
        oChannelPaymentMstDBIO = Nothing
        Fields("PAYMENT").Value = oChannelPaymentFull(0).sPaymentName
        Fields("PAY_COUNT").Value = oRequestData(H_RECORD_NO).sCardPayment

        '******************
        '  注意事項
        '******************
        Fields("GIFT").Value = oRequestData(H_RECORD_NO).sGiftRequest
        Fields("NOSHI").Value = oRequestData(H_RECORD_NO).sNoshiType
        Fields("NOSHI_NAME").Value = oRequestData(H_RECORD_NO).sNoshiName
        Fields("GIFT_TYPE").Value = oRequestData(H_RECORD_NO).sGiftWrapKind
        Fields("OTHER_REQ").Value = oRequestData(H_RECORD_NO).sComment

        '******************
        '  発送方法
        '******************
        Fields("SHIP_CORP").Value = oRequestData(H_RECORD_NO).sShipCorp
        Fields("SHIP_REQDATE").Value = oRequestData(H_RECORD_NO).sShipRequestDate
        Fields("SHIP_REQTIME").Value = oRequestData(H_RECORD_NO).sShipRequestTime
        Fields("MEMO").Value = oRequestData(H_RECORD_NO).sShipMemo

        '******************
        ' 請求金額情報
        '******************
        Fields("SALE_TOTAL").Value = oRequestData(H_RECORD_NO).sTotalPrice
        Fields("TOTAL").Value = oRequestData(H_RECORD_NO).sNoTaxTotalProductPrice
        Fields("POSTAGE").Value = oRequestData(H_RECORD_NO).sShippingCharge
        Fields("FEE").Value = oRequestData(H_RECORD_NO).sPaymentCharge
        Fields("TAX").Value = oRequestData(H_RECORD_NO).sTaxTotal
        '2019,10,18 A.Komita 追加 From
        Fields("REDUCED_TAX").Value = oRequestData(H_RECORD_NO).sReducedTaxRateTotal
        '2019,10,18 A.Komita 追加 To
        Fields("POINT").Value = oRequestData(H_RECORD_NO).sPointDisCount
        Fields("DISCOUNT").Value = oRequestData(H_RECORD_NO).sDiscount

        H_RECORD_NO = H_RECORD_NO + 1
        DETILE_NO = 1
    End Sub

    Private Sub DETILE_INFO()
        Dim str As String
        If D_RECORD_NO < oRequestSubData.Length Then
            Fields("NO").Value = DETILE_NO
            Fields("PRODUCT_NAME").Value = oRequestSubData(D_RECORD_NO).sProductName
            Fields("PRODUCT_CODE").Value = oRequestSubData(D_RECORD_NO).sProductCode
            str = ""
            If oRequestSubData(D_RECORD_NO).sOptionName <> "" Then
                str = str + oRequestSubData(D_RECORD_NO).sOptionName & " " & oRequestSubData(D_RECORD_NO).sOptionValue
                Fields("OPTION_VALUE").Value = str
            Else
                Fields("OPTION_VALUE").Value = ""
            End If

            Fields("PRICE").Value = oRequestSubData(D_RECORD_NO).sUnitPrice
            Fields("CNT").Value = oRequestSubData(D_RECORD_NO).sCount
            Fields("T_PRICE").Value = oRequestSubData(D_RECORD_NO).sNoTaxPrice
        End If

        DETILE_NO = DETILE_NO + 1
        D_RECORD_NO = D_RECORD_NO + 1
    End Sub

    Protected Overrides Sub Finalize()
        oRequestDataDBIO = Nothing
        oRequestSubDataDBIO = Nothing
        oTool = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub rRequestReportPage_ReportStart(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ReportStart
        Me.Document.Printer.PrinterName = String.Empty
    End Sub

End Class
