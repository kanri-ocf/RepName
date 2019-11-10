Public Class fShopRequestReport
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oRequestData() As cStructureLib.sRequestData
    Private oDataRequestDBIO As cDataRequestDBIO

    Private oRequestSubData() As cStructureLib.sRequestSubData
    Private oDataRequestSubDBIO As cDataRequestSubDBIO

    Private oRequestStatus() As cStructureLib.sRequestStatus
    Private oDataRequestStatusDBIO As cDataRequestStatusDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    Private oTool As cTool

    Private SUPPLIER_CODE As Integer
    Private oSupplierCode() As Integer

    Private BEFORE_TAX_ORDER As Long
    Private TOTAL_TAX As Long
    Private TOTAL_ORDER As Long

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private PRINT_FLG As Boolean
    Private EDIT_MODE As Integer        '0 : 新規　　1 : 更新

    Private CALLING_FLG As Boolean      '計算中 = Ture
    Private INIT_FLG As Boolean         'フォーム初期化中 = True

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iRequestCode As String, _
            ByVal StaffCode As String, _
            ByVal StaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        INIT_FLG = True

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oDataRequestStatusDBIO = New cDataRequestStatusDBIO(oConn, oCommand, oDataReader)

        If iRequestCode = Nothing Then
            EDIT_MODE = 0
        Else
            EDIT_MODE = 1
            REQUEST_CODE_T.Text = iRequestCode
        End If

        oTool = New cTool

        TOTAL_ORDER = 0
        STAFF_CODE = StaffCode
        STAFF_NAME = StaffName

        PRINT_FLG = False

        CALLING_FLG = False

    End Sub
    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_CLOSE As Integer = &HF060
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
            Return  ' Windows標準の処理は行わない
        End If
        MyBase.WndProc(m)
    End Sub
    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property

    Private Sub fShopRequestReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RequestNumber As String
        Dim RecordCnt As Integer
        Dim i As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(0)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        '初期値設定
        TITLE_L.Text = "受注伝票作成中"
        TITLE_L.BackColor = Color.DarkBlue
        TITLE_L.ForeColor = Color.White

        If EDIT_MODE = 0 Then   '新規時
            EDIT_L.Text = "新規登録中"
            EDIT_L.BackColor = Color.DarkBlue
            EDIT_L.ForeColor = Color.White
        Else
            EDIT_L.Text = "更新中"
            EDIT_L.BackColor = Color.Red
            EDIT_L.ForeColor = Color.White
        End If

        If EDIT_MODE = 0 Then
            '受注番号発番
            RequestNumber = REQUEST_NUMBER_CREATE()
            REQUEST_CODE_T.Text = RequestNumber
        End If

        '受注情報データグリッド生成
        GRIDVIEW_CREATE()

        'フォーム初期化終了
        INIT_FLG = False

        'データセット
        REQUEST_HEADER_SET()
        REQUEST_DETAIL_SET()

        '計算処理
        CAL_MONEY(True)

        '担当者セット
        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

    End Sub
    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        REQUEST_V.RowHeadersVisible = False
        REQUEST_V.ColumnHeadersHeight = 30
        REQUEST_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "JANコード"
        REQUEST_V.Columns.Add(column0)
        column0.Width = 85
        column0.ReadOnly = True
        column0.DefaultCellStyle.Format = "c"
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column0.Name = "JANコード"

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        REQUEST_V.Columns.Add(column1)
        column1.Width = 90
        column1.ReadOnly = True
        column1.Name = "商品コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        REQUEST_V.Columns.Add(column2)
        column2.Width = 200
        column2.ReadOnly = True
        column2.Name = "商品名称"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        REQUEST_V.Columns.Add(column3)
        column3.Width = 170
        column3.ReadOnly = True
        column3.Name = "オプション"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "定価"
        REQUEST_V.Columns.Add(column4)
        column4.Width = 90
        column4.ReadOnly = True
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "定価"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "仕入価格"
        REQUEST_V.Columns.Add(column5)
        column5.Width = 90
        column5.ReadOnly = True
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "仕入価格"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "数量"
        REQUEST_V.Columns.Add(column6)
        column6.Width = 60
        column6.ReadOnly = False
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.DefaultCellStyle.BackColor = Color.Wheat
        column6.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        column6.Name = "数量"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "金額"
        REQUEST_V.Columns.Add(column7)
        column7.Width = 90
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "金額"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        REQUEST_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "在庫数"

        '背景色を白に設定
        REQUEST_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        REQUEST_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub
    '***********************************************
    '受注ヘッダーを画面にセット
    '***********************************************
    Private Sub REQUEST_HEADER_SET()
        Dim RecordCnt As Integer

        '受注金額セット
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oDataRequestDBIO.getRequest(oRequestData, Nothing, REQUEST_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        CALLING_FLG = True

        If RecordCnt > 0 Then

            '税込みモード
            BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sNoTaxTotalProductPrice, oConf(0).sTax, oConf(0).sFracProc))
            POSTAGE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
            FEE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
            DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sDiscount, oConf(0).sTax, oConf(0).sFracProc))
            P_DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sPointDisCount, oConf(0).sTax, oConf(0).sFracProc))
            BEFORE_TAX_REQUEST_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oRequestData(0).sNoTaxTotalPrice, oConf(0).sTax, oConf(0).sFracProc))
            TAX_T.Text = String.Format("{0,9:C}", 0)
            AFTER_TAX_REQUEST_T.Text = String.Format("{0,9:C}", oRequestData(0).sTotalPrice)
        End If
        oDataRequestDBIO = Nothing

        CALLING_FLG = False
    End Sub
    '***********************************************
    '受注明細を画面にセット
    '***********************************************
    Private Sub REQUEST_DETAIL_SET()
        Dim i As Integer
        Dim j As Integer
        Dim RecordCnt As Integer
        Dim Str As String

        CALLING_FLG = True

        oRequestReport = Nothing
        oViewRequestReportDBIO = New cViewRequestReportDBIO(oConn, oCommand, oDataReader)

        '受注データの読み込み
        RecordCnt = oViewRequestReportDBIO.getRequestReport(oRequestReport, SUPPER_CODE_T.Text, oTran)

        'DataGridViewセット
        Me.SuspendLayout()

        For i = 0 To RecordCnt - 1
            Str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oRequestReport(i).sOption1 <> "" Then
                            Str = Str + oRequestReport(i).sOption1 & "："
                        End If
                    Case 2
                        If oRequestReport(i).sOption2 <> "" Then
                            Str = Str + oRequestReport(i).sOption2 & "："
                        End If
                    Case 3
                        If oRequestReport(i).sOption3 <> "" Then
                            Str = Str + oRequestReport(i).sOption3 & "："
                        End If
                    Case 4
                        If oRequestReport(i).sOption4 <> "" Then
                            Str = Str + oRequestReport(i).sOption4 & "："
                        End If
                    Case 5
                        If oRequestReport(i).sOption5 <> "" Then
                            Str = Str + oRequestReport(i).sOption5 & "："
                        End If
                End Select
            Next
            If oRequestReport(i).sCount = 0 Then
                oRequestReport(i).sCount = 1
            End If
            REQUEST_V.Rows.Add( _
                    oRequestReport(i).sJANCode, _
                    oRequestReport(i).sProductCode, _
                    oRequestReport(i).sProductShortName, _
                    Str, _
                    oRequestReport(i).sPrice, _
                    oRequestReport(i).sCostPrice, _
                    oRequestReport(i).sCount, _
                    oRequestReport(i).sCostPrice * oRequestReport(i).sCount, _
                    oRequestReport(i).sStock _
            )
        Next i
        Me.ResumeLayout(False)

        CALLING_FLG = False

    End Sub

    '**********************
    '受注番号発番処理
    '**********************
    Private Function REQUEST_NUMBER_CREATE() As String
        Dim REQUEST_NUMBER As String
        Dim MaxRequestCode As Long
        Dim JanCode As String

        '受注情報データデータアクセスクラスの生成
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)

        MaxRequestCode = oDataRequestDBIO.getMaxRequestCode(CInt(String.Format("{0:00}", SUPPLIER_CODE)), String.Format("{0:yyMMdd}", Now), oTran)
        If MaxRequestCode = 9 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "同一受注先の本日の受注伝票が１０枚を超えました。", _
                                            "不要な受注データを削除後、", _
                                            "再度、受注処理を行って下さい。", Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
        Else
            REQUEST_NUMBER = "991" & String.Format("{0:00}", SUPPLIER_CODE) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:0}", MaxRequestCode)
        End If
        REQUEST_NUMBER = "991" & String.Format("{0:00}", SUPPLIER_CODE) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:0}", MaxRequestCode)

        'チェックデジットの生成
        JanCode = oTool.JANCD(REQUEST_NUMBER)

        oDataRequestDBIO = Nothing

        REQUEST_NUMBER_CREATE = JanCode
    End Function
    Private Function REQUEST_INSERT(ByVal RequestMode As Integer) As Long
        Dim ret As Boolean
        Dim Ope As Integer

        '返品伝票印刷モードの場合は、オペレータとして-1をセット
        If RequestMode = 0 Then
            Ope = 1
        Else
            Ope = -1
        End If

        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)

        ReDim oRequestData(0)

        '受注コード
        oRequestData(0).sRequestCode = REQUEST_CODE_T.Text.ToString
        '受注日
        oRequestData(0).sRequestDate = String.Format("{0:yyyy/MM/dd}", Now)
        '受注モード
        oRequestData(0).sRequestMode = REQUEST_MODE

        If BEFORE_TAX_R.Checked = True Then         '税抜きモード時  
            '受注税抜商品金額
            oRequestData(0).sNoTaxTotalProductPrice = CLng(BEFORE_TAX_PRODUCT_T.Text) * Ope
            '送料
            oRequestData(0).sShippingCharge = CLng(POSTAGE_T.Text) * Ope
            '手数料
            oRequestData(0).sPaymentCharge = CLng(FEE_T.Text) * Ope
            '受注値引き
            oRequestData(0).sDiscount = CLng(DISCOUNT_T.Text) * -1 * Ope
            '受注ポイント値引き
            oRequestData(0).sPointDisCount = CLng(P_DISCOUNT_T.Text) * -1 * Ope
            '受注税抜金額
            oRequestData(0).sNoTaxTotalPrice = CLng(BEFORE_TAX_REQUEST_T.Text) * Ope
            '受注消費税額
            oRequestData(0).sTaxTotal = CLng(TAX_T.Text) * Ope
            '受注税込金額
            oRequestData(0).sTotalPrice = CLng(AFTER_TAX_REQUEST_T.Text) * Ope
        Else        '税込みモード
            '受注税抜商品金額
            oRequestData(0).sNoTaxTotalProductPrice = oTool.AfterToBeforeTax(CLng(BEFORE_TAX_PRODUCT_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope
            '送料
            oRequestData(0).sShippingCharge = oTool.AfterToBeforeTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope
            '手数料
            oRequestData(0).sPaymentCharge = oTool.AfterToBeforeTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope
            '受注値引き
            oRequestData(0).sDiscount = oTool.AfterToBeforeTax(CLng(DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc) * -1 * Ope
            '受注ポイント値引き
            oRequestData(0).sPointDisCount = oTool.AfterToBeforeTax(CLng(P_DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc) * -1 * Ope
            '受注税抜金額
            oRequestData(0).sNoTaxTotalPrice = oRequestData(0).sNoTaxTotalProductPrice + _
                                                oRequestData(0).sShippingCharge + _
                                                oRequestData(0).sPaymentCharge + _
                                                oRequestData(0).sDiscount + _
                                                oRequestData(0).sPointDisCount

            '受注消費税額
            oRequestData(0).sTaxTotal = oTool.BeforeToTax(oRequestData(0).sNoTaxTotalPrice, oConf(0).sTax, oConf(0).sFracProc)
            '受注税込金額
            oRequestData(0).sTotalPrice = oRequestData(0).sNoTaxTotalPrice + oRequestData(0).sTaxTotal
        End If

        '仕入先コード
        oSupplierDBIO.getSupplierCode(oSupplier, SUPPLIER_C.Text, oTran)
        oRequestData(0).sSupplierCode = oSupplier(0).sSupplierCode
        '支払方法コード
        Select Case PAYMENT_L.SelectedIndex
            Case 0
                oRequestData(0).sPaymentCode = oSupplier(0).sPaymentCode1
            Case 1
                oRequestData(0).sPaymentCode = oSupplier(0).sPaymentCode2
            Case 2
                oRequestData(0).sPaymentCode = oSupplier(0).sPaymentCode3
        End Select
        '希望納品日
        oRequestData(0).sRequestDate = RQ_DATE_T.Text
        '希望納品場所
        oRequestData(0).sRequestPlace = ADDR_T.Text
        '受注担当者コード
        oRequestData(0).sStaffCode = STAFF_CODE_T.Text
        '備考
        oRequestData(0).sMemo = MEMO_T.Text.ToString

        '伝票印刷モード
        If BEFORE_TAX_R.Checked = True Then
            oRequestData(0).sPrintMode = 1        '税抜き
        Else
            oRequestData(0).sPrintMode = 0        '税込み
        End If

        ret = oDataRequestDBIO.insertRequestData(oRequestData, oTran)
        If ret = False Then
            REQUEST_INSERT = -1
        End If
        REQUEST_INSERT = 1
    End Function
    Private Function REQUEST_SUB_INSERT(ByVal RequestMode As Integer) As Long
        Dim ret As Boolean
        Dim i As Integer
        Dim oProductDBIO As cMstProductDBIO
        Dim oProduct() As cStructureLib.sProduct
        Dim oCostPriceDBIO As cMstCostPriceDBIO
        Dim oCostPrice() As cStructureLib.sCostPrice
        Dim RecordCnt As Long

        oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)

        ReDim oRequestSubData(0)

        For i = 0 To REQUEST_V.Rows.Count - 1
            ReDim oProduct(0)
            RecordCnt = oProductDBIO.getProduct(oProduct, Nothing, REQUEST_V("商品コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            ReDim oCostPrice(0)
            oCostPriceDBIO.getPriceMst(oCostPrice, REQUEST_V("商品コード", i).Value, CInt(SUPPER_CODE_T.Text), oTran)

            '受注コード
            oRequestSubData(0).sRequestCode = REQUEST_CODE_T.Text.ToString
            '受注明細コード
            oRequestSubData(0).sRequestSubCode = i + 1
            'JANコード
            oRequestSubData(0).sJANCode = oProduct(0).sJANCode
            '商品コード
            oRequestSubData(0).sProductCode = oProduct(0).sProductCode
            '商品略称
            oRequestSubData(0).sProductName = oProduct(0).sProductShortName
            'オプション1
            oRequestSubData(0).sOption1 = oProduct(0).sOption1
            'オプション2
            oRequestSubData(0).sOption2 = oProduct(0).sOption2
            'オプション3
            oRequestSubData(0).sOption3 = oProduct(0).sOption3
            'オプション4
            oRequestSubData(0).sOption4 = oProduct(0).sOption4
            'オプション5
            oRequestSubData(0).sOption5 = oProduct(0).sOption5
            '定価
            oRequestSubData(0).sListPrice = oProduct(0).sListPrice
            '仕入価格
            oRequestSubData(0).sCostPrice = oCostPrice(0).sCostPrice
            '受注商品単価
            oRequestSubData(0).sUnitPrice = oCostPrice(0).sCostPrice
            '受注数量
            oRequestSubData(0).sCount = CLng(REQUEST_V("数量", i).Value)
            '受注税抜金額
            oRequestSubData(0).sNoTaxPrice = oRequestSubData(0).sUnitPrice * oRequestSubData(0).sCount
            If BEFORE_TAX_R.Checked = True Then         '税抜きの場合   
                '受注税込金額
                oRequestSubData(0).sPrice = oTool.BeforeToAfterTax(oRequestSubData(0).sUnitPrice * oRequestSubData(0).sCount, oConf(0).sTax, oConf(0).sFracProc)
                '受注消費税額
                oRequestSubData(0).sTaxPrice = oRequestSubData(0).sPrice - oRequestSubData(0).sNoTaxPrice
            Else
                '受注税込金額
                oRequestSubData(0).sPrice = oTool.BeforeToAfterTax(oRequestSubData(0).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc) * oRequestSubData(0).sCount
                '受注消費税額
                oRequestSubData(0).sTaxPrice = oRequestSubData(0).sPrice - oRequestSubData(0).sNoTaxPrice
            End If

            'データ書込み
            ret = oDataRequestSubDBIO.insertRequestSubData(oRequestSubData, oTran)
            If ret = False Then
                REQUEST_SUB_INSERT = -1
            End If
        Next i
        REQUEST_SUB_INSERT = i
    End Function
    Private Function STOCK_UPDATE() As Boolean
        Dim oStock() As cStructureLib.sStock
        Dim oStockDBIO As New cMstStockDBIO(oConn, oCommand, oDataReader)
        Dim i As Integer
        Dim ret As Boolean

        For i = 0 To REQUEST_V.Rows.Count - 1
            ReDim oStock(0)
            oStockDBIO.getStock(oStock, REQUEST_V("商品コード", i).Value, oTran)
            oStock(0).sStockCount = oStock(0).sStockCount - CInt(REQUEST_V("数量", i).Value)
            ret = oStockDBIO.updateStock(oStock, oTran)
            If ret = False Then
                STOCK_UPDATE = False
                Exit For
            End If
        Next
        STOCK_UPDATE = True
    End Function
    Private Sub REQUEST_DELETE()

        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)

        '受注データの削除
        oDataRequestDBIO.deleteRequestData(REQUEST_CODE_T.Text.ToString, oTran)

        oDataRequestDBIO = Nothing

        oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        '受注明細データの削除
        oDataRequestSubDBIO.deleteRequestSubData(REQUEST_CODE_T.Text.ToString, oTran)

        oDataRequestSubDBIO = Nothing

    End Sub

    Private Sub REQUEST_V_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles REQUEST_V.CellValueChanged

        '数量セルの変更の場合
        If e.ColumnIndex = 6 Then
            'If CALLING_FLG = False Then
            '数量の更新
            ReDim oRequestStatus(0)
            oRequestStatus(0).sProductCode = REQUEST_V("商品コード", REQUEST_V.CurrentRow.Index).Value
            oRequestStatus(0).sRequestCheck = True
            oRequestStatus(0).sCount = REQUEST_V("数量", REQUEST_V.CurrentRow.Index).Value
            oDataRequestStatusDBIO.updateRequestStatus(oRequestStatus(0), oTran)
            'End If
            '計算処理
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub CAL_MONEY(ByRef MODE_CHANGE As Boolean)
        Dim i As Integer
        Dim BeforeTaxPrice As Long
        Dim TaxPrice As Long
        Dim TotalPrice As Long

        If CALLING_FLG = False Then
            CALLING_FLG = True

            BeforeTaxPrice = 0
            TaxPrice = 0
            TotalPrice = 0

            For i = 0 To REQUEST_V.RowCount - 1

                '選択された仕入先の仕入価格を抽出
                oProductDBIO.getProduct(oProduct, Nothing, REQUEST_V("商品コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

                '選択された仕入先の仕入価格を抽出
                oCostPriceDBIO.getPriceMst(oCostPrice, REQUEST_V("商品コード", i).Value, CInt(SUPPER_CODE_T.Text), oTran)

                If BEFORE_TAX_R.Checked = True Then         '税抜きの場合   
                    '定価の更新
                    REQUEST_V("定価", i).Value = oProduct(0).sListPrice

                    '仕入単価の更新
                    REQUEST_V("仕入価格", i).Value = oCostPrice(0).sCostPrice

                    '明細行受注金額の更新
                    REQUEST_V("金額", i).Value = REQUEST_V("仕入価格", i).Value * REQUEST_V("数量", i).Value

                Else    '税込みの場合
                    '定価の更新
                    REQUEST_V("定価", i).Value = oTool.BeforeToAfterTax(oProduct(0).sListPrice, oConf(0).sTax, oConf(0).sFracProc)

                    '仕入単価の更新
                    REQUEST_V("仕入価格", i).Value = oTool.BeforeToAfterTax(oCostPrice(0).sCostPrice, oConf(0).sTax, oConf(0).sFracProc)

                    '明細行受注金額の更新
                    REQUEST_V("金額", i).Value = REQUEST_V("仕入価格", i).Value * REQUEST_V("数量", i).Value

                End If

                '（税込み金額計算）
                TotalPrice = TotalPrice + REQUEST_V("金額", i).Value
            Next

            '---------------------
            '    合計値セット
            '---------------------
            BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", TotalPrice)

            If MODE_CHANGE = True Then
                If BEFORE_TAX_R.Checked = True Then     '税抜きの場合
                    POSTAGE_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    FEE_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(CLng(DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    P_DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(CLng(P_DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    BEFORE_TAX_REQUEST_T.Text = String.Format("{0,9:C}", _
                                                            CLng(BEFORE_TAX_PRODUCT_T.Text) + _
                                                            CLng(POSTAGE_T.Text) + _
                                                            CLng(FEE_T.Text) - _
                                                            CLng(DISCOUNT_T.Text) - _
                                                            CLng(P_DISCOUNT_T.Text))
                    TAX_T.Text = String.Format("{0,9:C}", oTool.BeforeToTax(BEFORE_TAX_REQUEST_T.Text, oConf(0).sTax, oConf(0).sFracProc))
                    AFTER_TAX_REQUEST_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_REQUEST_T.Text) + CLng(TAX_T.Text))
                Else
                    POSTAGE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    FEE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(CLng(DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    P_DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(CLng(P_DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    BEFORE_TAX_REQUEST_T.Text = String.Format("{0,9:C}", _
                                                            CLng(BEFORE_TAX_PRODUCT_T.Text) + _
                                                            CLng(POSTAGE_T.Text) + _
                                                            CLng(FEE_T.Text) - _
                                                            CLng(DISCOUNT_T.Text) - _
                                                            CLng(P_DISCOUNT_T.Text))
                    TAX_T.Text = 0
                    AFTER_TAX_REQUEST_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_REQUEST_T.Text))
                End If
            Else
                If BEFORE_TAX_R.Checked = True Then     '税抜きの場合
                    BEFORE_TAX_REQUEST_T.Text = String.Format("{0,9:C}", _
                                                           CLng(BEFORE_TAX_PRODUCT_T.Text) + _
                                                           CLng(POSTAGE_T.Text) + _
                                                           CLng(FEE_T.Text) - _
                                                           CLng(DISCOUNT_T.Text) - _
                                                           CLng(P_DISCOUNT_T.Text))
                    TAX_T.Text = String.Format("{0,9:C}", oTool.BeforeToTax(BEFORE_TAX_REQUEST_T.Text, oConf(0).sTax, oConf(0).sFracProc))
                    AFTER_TAX_REQUEST_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_REQUEST_T.Text) + CLng(TAX_T.Text))
                Else
                    BEFORE_TAX_REQUEST_T.Text = String.Format("{0,9:C}", _
                                                           CLng(BEFORE_TAX_PRODUCT_T.Text) + _
                                                           CLng(POSTAGE_T.Text) + _
                                                           CLng(FEE_T.Text) - _
                                                           CLng(DISCOUNT_T.Text) - _
                                                           CLng(P_DISCOUNT_T.Text))
                    TAX_T.Text = 0
                    AFTER_TAX_REQUEST_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_REQUEST_T.Text))
                End If

            End If
            CALLING_FLG = False
        End If

    End Sub

    Private Sub SUPPLIER_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RecordCnt As Integer
        Dim i As Integer

        '仕入先情報取得
        oSupplierDBIO.getSupplierCode(oSupplier, SUPPLIER_C.Text, oTran)
        SUPPER_CODE_T.Text = oSupplier(0).sSupplierCode

        '支払方法リストボックスセット
        PAYMENT_L.BeginUpdate()

        'リストボックスの初期化
        PAYMENT_L.Items.Clear()
        PAYMENT_L.Refresh()

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)

        If REQUEST_MODE = 0 Then
            If IsDBNull(oSupplier(0).sPaymentCode1) = False Then
                RecordCnt = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode1, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                If RecordCnt = 1 Then
                    PAYMENT_L.Items.Add(oPayment(0).sPaymentName)
                End If
            End If
            If IsDBNull(oSupplier(0).sPaymentCode2) = False Then
                RecordCnt = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode2, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                If RecordCnt = 1 Then
                    PAYMENT_L.Items.Add(oPayment(0).sPaymentName)
                End If
            End If
            If IsDBNull(oSupplier(0).sPaymentCode3) = False Then
                RecordCnt = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode3, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                If RecordCnt = 1 Then
                    PAYMENT_L.Items.Add(oPayment(0).sPaymentName)
                End If
            End If
        Else
            RecordCnt = oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            For i = 0 To oPayment.Length - 1
                PAYMENT_L.Items.Add(oPayment(i).sPaymentName)
            Next i
        End If
        PAYMENT_L.EndUpdate()
        PAYMENT_L.SelectedIndex = 0

        TRN_RULE_T.Text = oSupplier(0).sTrnRule

        '仕入単価および受注金額の更新
        CAL_MONEY(False)
    End Sub

    Private Sub BEFORE_TAX_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If INIT_FLG = False Then
            CAL_MONEY(True)
        End If
    End Sub

    Private Sub DISCOUNT_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DISCOUNT_T.LostFocus
        If INIT_FLG = False Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub P_DISCOUNT_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_DISCOUNT_T.LostFocus
        If INIT_FLG = False Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub FEE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FEE_T.LostFocus
        If INIT_FLG = False Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub POSTAGE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSTAGE_T.LostFocus
        If INIT_FLG = False Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        'エラートラップを設定
        On Error Resume Next

        oTran.Rollback()

        'エラートラップを解除
        On Error GoTo 0


        oDataRequestDBIO = Nothing
        oDataRequestSubDBIO = Nothing
        oDataRequestStatusDBIO = Nothing
        oSupplierDBIO = Nothing
        'oStaffDBIO = Nothing
        oMstConfigDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub PRINT_START_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINT_START_B.Click
        Dim ret As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim oReportPage As rShopRequestReport
        Dim DefaultTaxMode As Integer   '0：税込みモード   1：税抜きモード
        Dim ReportMode As String

        If IsNothing(oTran) = True Then
            oTran = oConn.BeginTransaction()
        End If

        '受注データの削除
        REQUEST_DELETE()

        'デフォルト税モード = 税込みモードにセット
        DefaultTaxMode = 0

        '受注情報データ登録
        ret = REQUEST_INSERT(REQUEST_MODE)
        If ret = -1 Then
            'トランザクションのロールバック
            oTran.Rollback()

            Message_form = New cMessageLib.fMessage(1, "受注情報の登録に失敗しました。", _
                                            "開発元に連絡して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If

        '受注情報明細データ登録
        ret = REQUEST_SUB_INSERT(REQUEST_MODE)
        If ret = -1 Then
            'トランザクションのロールバック
            oTran.Rollback()

            Message_form = New cMessageLib.fMessage(1, "受注情報明細の登録に失敗しました。", _
                                            "開発元に連絡して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If
        '------------------------------------------
        '返品モードの場合は返品伝票の出力をもって
        '在庫の情報更新を行う。
        '------------------------------------------
        If REQUEST_MODE = 1 Then
            ret = STOCK_UPDATE()
            If ret = False Then
                'トランザクションのロールバック
                oTran.Rollback()

                Message_form = New cMessageLib.fMessage(1, "在庫情報の更新に失敗しました。", _
                                                "開発元に連絡して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Application.DoEvents()
                Message_form = Nothing
                Exit Sub
            End If
        End If
        '税モードを元に戻す
        If DefaultTaxMode = 1 Then
            BEFORE_TAX_R.Checked = True
            CAL_MONEY(False)
        End If

        '伝票印刷モード設定
        If BEFORE_TAX_R.Checked = True Then
            ReportMode = "税抜き"
        Else
            ReportMode = "税込み"
        End If

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "受注伝票を印刷中です。", _
                                        "しばらくお待ちください。", _
                                        Nothing, Nothing)
        Message_form.Show()

        Application.DoEvents()

        '印刷開始
        oReportPage = New rShopRequestReport(oConn, oCommand, oDataReader, REQUEST_CODE_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)
        oReportPage.Run()
        ret = oReportPage.Document.Print(True, True, True)
        oReportPage = Nothing

        Message_form.Dispose()
        Message_form = Nothing

        If ret = False Then
            'トランザクションのロールバック
            oTran.Rollback()

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "受注伝票の印刷に失敗しました。", _
                                            "システム管理者にお問い合わせ下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If
        Application.DoEvents()

        PRINT_FLG = True

    End Sub

    Private Sub EXIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        If PRINT_FLG = False Then
            'メッセージウィンドウ表示

            Message_form = New cMessageLib.fMessage(2, "作成中の伝票は印刷されていません", _
                                            "作成中のデータは破棄されます。", _
                                            "よろしいですか？", Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                Message_form = Nothing
                Exit Sub
            End If
        End If

        'エラートラップを設定
        On Error Resume Next

        'トランザクションのコミット
        oTran.Commit()

        'エラートラップを解除
        On Error GoTo 0

        oSupplierDBIO = Nothing
        oMstConfigDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class
