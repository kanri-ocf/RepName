Public Class fOrderReport
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oOrderData() As cStructureLib.sOrderData
    Private oDataOrderDBIO As cDataOrderDBIO

    Private oOrderSubData() As cStructureLib.sOrderSubData
    Private oDataOrderSubDBIO As cDataOrderSubDBIO

    Private oOrderStatus() As cStructureLib.sOrderStatus
    Private oDataOrderStatusDBIO As cDataOrderStatusDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oPayment() As cStructureLib.sPayment
    Private oMstPaymentDBIO As cMstPaymentDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    Private oOrderReport() As cStructureLib.sViewOrderReport
    Private oViewOrderReportDBIO As cViewOrderReportDBIO

    Private oTool As cTool

    Private SUPPLIER_CODE As Integer
    Private oSupplierCode() As Integer

    Private BEFORE_TAX_ORDER As Long
    Private TOTAL_TAX As Long
    Private TOTAL_ORDER As Long

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private PRINT_FLG As Boolean
    Private ORDER_MODE As Integer       '0 : 発注　　1 : 返品
    Private EDIT_MODE As Integer        '0 : 新規　　1 : 更新

    Private CALLING_FLG As Boolean      '計算中 = Ture
    Private INIT_FLG As Boolean         'フォーム初期化中 = True

    'shimizu start
    Private TAX_TOTAL_PRICE_STR = "0"　'軽減税率対象外の商品の金額合計の保持
    Private RTAX_RATE_TOTAL_STR = "0" '軽減税率対象の商品の金額合計の保持
    Private TAX_STR As String = "0" '消費税の合計の保持
    Private REDUCED_TAX_RATE_STR As String = "0" '軽減消費税の合計の保持
    Private POSTAGE_TAX As String = "0" '送料の消費税の保持
    Private FEE_TAX As String = "0" '手数料の消費税の保持

    Private POSTAGE_FLG As String '送料の値が変化があった時のフラグ
    Private FEE_FLG As String '手数料の値が変化があった時のフラグ
    Private Cal_Money_Flg As Boolean

    Private REDUCED_TAX_RATE_FLG As Long = 8 '軽減税率対象商品が入ってたときのフラグ

    'shimizu end

    '2019,10,30 A.Komita 追加 From
    'ORDER_INSERTメソッドで税込価格を税抜価格で登録する為に使用する
    Dim NoTaxTotal As Integer = 0
    Dim NoReducedTaxTotal As Integer = 0
    Dim TaxTotal As Integer = 0
    Dim ReducedTaxTotal As Integer = 0
    '2019,10,30 A.Komita 追加 To

    Private oTran As OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iSupplierCode() As Integer,
            ByVal iOrderMode As Integer,
            ByVal iOrderCode As String,
            ByVal StaffCode As String,
            ByVal StaffName As String,
            ByRef iTran As OleDb.OleDbTransaction)

        INIT_FLG = True

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oDataOrderStatusDBIO = New cDataOrderStatusDBIO(oConn, oCommand, oDataReader)

        oSupplierCode = iSupplierCode
        If iOrderCode = "" Then
            EDIT_MODE = 0
        Else
            EDIT_MODE = 1
            ORDER_CODE_T.Text = iOrderCode
        End If

        ORDER_MODE = iOrderMode

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
    Protected Overrides Sub WndProc(ByRef m As Message)
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
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property

    Private Sub fOrderReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim OrderNumber As String
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

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        '初期値設定
        If ORDER_MODE = 0 Then      '発注時
            TITLE_L.Text = "発注伝票作成中"
            TITLE_L.BackColor = Color.DarkBlue
            TITLE_L.ForeColor = Color.White

            ORDER_NUMBER_L.Text = "発注番号"
            SUPPLIER_L.Text = "発注先"
            TOTAL_L.Text = "発注金額："
            DATE_L.Text = "納品期限"
            PLACE_L.Text = "納品場所"
            RQ_DATE_T.Text = "別途ご相談"
            RQ_PLACE_T.Text = "右記弊社事業所"

            AFTER_TAX_R.Checked = True
        Else    '返品時
            TITLE_L.Text = "返品伝票作成中"
            TITLE_L.BackColor = Color.Red
            TITLE_L.ForeColor = Color.White

            ORDER_NUMBER_L.Text = "伝票番号"
            SUPPLIER_L.Text = "仕入先"
            TOTAL_L.Text = "返品金額"
            DATE_L.Text = "返品日付"
            PLACE_L.Text = "送付先"

            RQ_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)
            RQ_PLACE_T.Text = "御社指定事業所"

            BEFORE_TAX_R.Checked = True
        End If

        If EDIT_MODE = 0 Then   '新規時
            EDIT_L.Text = "新規登録中"
            EDIT_L.BackColor = Color.DarkBlue
            EDIT_L.ForeColor = Color.White
        Else
            EDIT_L.Text = "更新中"
            EDIT_L.BackColor = Color.Red
            EDIT_L.ForeColor = Color.White
        End If

        '仕入先名称のセット
        SUPPLIER_C.BeginUpdate()
        If EDIT_MODE = 0 Then
            '発注番号発番
            OrderNumber = ORDER_NUMBER_CREATE()
            ORDER_CODE_T.Text = OrderNumber
        End If

        For i = 0 To oSupplierCode.Length - 1
            RecordCnt = oSupplierDBIO.getSupplier(oSupplier, oSupplierCode(i), Nothing, oTran)
            SUPPLIER_C.Items.Add(oSupplier(0).sSupplierName)
        Next

        TAX_T.Text = String.Format("{0,9:C}", 0)
        RTAX_RATE_T.Text = String.Format("{0,9:C}", 0)


        SUPPLIER_C.EndUpdate()
        SUPPLIER_C.SelectedIndex = 0

        '発注情報データグリッド生成
        GRIDVIEW_CREATE()

        'フォーム初期化終了
        INIT_FLG = False

        'データセット
        ORDER_HEADER_SET()
        ORDER_DETAIL_SET()

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
        ORDER_V.RowHeadersVisible = False
        ORDER_V.ColumnHeadersHeight = 30
        ORDER_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "JANコード"
        ORDER_V.Columns.Add(column0)
        column0.Width = 85
        column0.ReadOnly = True
        column0.DefaultCellStyle.Format = "c"
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column0.Name = "JANコード"

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        ORDER_V.Columns.Add(column1)
        column1.Width = 90
        column1.ReadOnly = True
        column1.Name = "商品コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        ORDER_V.Columns.Add(column2)
        column2.Width = 175
        column2.ReadOnly = True
        column2.Name = "商品名称"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        ORDER_V.Columns.Add(column3)
        column3.Width = 145
        column3.ReadOnly = True
        column3.Name = "オプション"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "定価"
        ORDER_V.Columns.Add(column4)
        column4.Width = 90
        column4.ReadOnly = True
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "定価"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "仕入価格"
        ORDER_V.Columns.Add(column5)
        column5.Width = 90
        column5.ReadOnly = True
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "仕入価格"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "数量"
        ORDER_V.Columns.Add(column6)
        column6.Width = 60
        column6.ReadOnly = False
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.DefaultCellStyle.BackColor = Color.Wheat
        column6.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        column6.Name = "数量"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "金額"
        ORDER_V.Columns.Add(column7)
        column7.Width = 90
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "金額"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        ORDER_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "在庫数"

        '2019\8/30 shimizu add start
        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "税率"
        ORDER_V.Columns.Add(column9)
        column9.Width = 70
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "税率"
        '2019\8/30 shimizu add end

        '背景色を白に設定
        ORDER_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        ORDER_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub
    '***********************************************
    '発注ヘッダーを画面にセット
    '***********************************************
    Private Sub ORDER_HEADER_SET()
        Dim RecordCnt As Integer

        '発注金額セット
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oDataOrderDBIO.getOrderData(oOrderData, ORDER_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

        CALLING_FLG = True

        If RecordCnt > 0 Then
            If oOrderData(0).sPrintMode = 0 Then
                AFTER_TAX_R.Checked = True
            Else
                BEFORE_TAX_R.Checked = True
            End If

            If BEFORE_TAX_R.Checked = True Then     '税抜きモード
                BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", oOrderData(0).sNoTaxTotalProductPrice)
                POSTAGE_T.Text = String.Format("{0,9:C}", oOrderData(0).sShippingCharge)
                FEE_T.Text = String.Format("{0,9:C}", oOrderData(0).sPaymentCharge)
                DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sDiscount)
                P_DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sPointDisCount)
                BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}", oOrderData(0).sNoTaxTotalPrice)

                '2019/9/25 shimizu upd start
                If oProduct(0).sReducedTaxRate <> String.Empty Then
                    RTAX_RATE_T.Text = String.Format("{0,9:C}", oOrderData(0).sReducedTaxRateTotal)
                Else
                    TAX_T.Text = String.Format("{0,9:C}", oOrderData(0).sTaxTotal)
                End If
                '2019/9/25 shimizu upd end

                AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", oOrderData(0).sTotalPrice)

            Else   '税込みモード

                '2019/8/30 shimizu add start
                If oOrderData(0).sReducedTaxRate = String.Empty Then
                    BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sNoTaxTotalProductPrice, oConf(0).sTax, oConf(0).sFracProc))
                    POSTAGE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
                    FEE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
                    DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sDiscount)
                    P_DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sPointDisCount)
                    BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sNoTaxTotalPrice, oConf(0).sTax, oConf(0).sFracProc))
                    TAX_T.Text = String.Format("{0,9:C}", 0)
                    RTAX_RATE_T.Text = String.Format("{0,9:C}", 0)
                    AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", oOrderData(0).sTotalPrice)
                Else
                    BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sNoTaxTotalProductPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc))
                    POSTAGE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oProduct(0).sReducedTaxRate, oConf(0).sFracProc))
                    FEE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oProduct(0).sReducedTaxRate, oConf(0).sFracProc))
                    DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sDiscount)
                    P_DISCOUNT_T.Text = String.Format("{0,9:C}", oOrderData(0).sPointDisCount)
                    BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(oOrderData(0).sNoTaxTotalPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc))
                    TAX_T.Text = String.Format("{0,9:C}", 0)
                    RTAX_RATE_T.Text = String.Format("{0,9:C}", 0)
                    AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", oOrderData(0).sTotalPrice)
                End If
                '2019/8/30 shimizu add end


            End If
        End If

        oDataOrderDBIO = Nothing

        CALLING_FLG = False
    End Sub
    '***********************************************
    '発注明細を画面にセット
    '***********************************************
    Private Sub ORDER_DETAIL_SET()
        Dim i As Integer
        Dim j As Integer
        Dim RecordCnt As Integer
        Dim Str As String

        CALLING_FLG = True

        oOrderReport = Nothing
        oViewOrderReportDBIO = New cViewOrderReportDBIO(oConn, oCommand, oDataReader)

        '発注データの読み込み
        RecordCnt = oViewOrderReportDBIO.getOrderReport(oOrderReport, SUPPER_CODE_T.Text, oTran)

        'DataGridViewセット
        Me.SuspendLayout()

        For i = 0 To RecordCnt - 1
            Str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oOrderReport(i).sOption1 <> "" Then
                            Str = Str + oOrderReport(i).sOption1 & "："
                        End If
                    Case 2
                        If oOrderReport(i).sOption2 <> "" Then
                            Str = Str + oOrderReport(i).sOption2 & "："
                        End If
                    Case 3
                        If oOrderReport(i).sOption3 <> "" Then
                            Str = Str + oOrderReport(i).sOption3 & "："
                        End If
                    Case 4
                        If oOrderReport(i).sOption4 <> "" Then
                            Str = Str + oOrderReport(i).sOption4 & "："
                        End If
                    Case 5
                        If oOrderReport(i).sOption5 <> "" Then
                            Str = Str + oOrderReport(i).sOption5 & "："
                        End If
                End Select
            Next
            If EDIT_MODE = 0 And oOrderReport(i).sCount = 0 Then
                oOrderReport(i).sCount = 1
            End If
            ORDER_V.Rows.Add(
                    oOrderReport(i).sJANCode,
                    oOrderReport(i).sProductCode,
                    oOrderReport(i).sProductShortName,
                    Str,
                    oOrderReport(i).sPrice,
                    oOrderReport(i).sCostPrice,
                    oOrderReport(i).sCount,
                    oOrderReport(i).sCostPrice * oOrderReport(i).sCount,
                    oOrderReport(i).sStock
            )
        Next i
        Me.ResumeLayout(False)

        CALLING_FLG = False

    End Sub

    '**********************
    '発注番号発番処理
    '**********************
    Private Function ORDER_NUMBER_CREATE() As String
        Dim ORDER_NUMBER As String
        Dim MaxOrderCode As Long
        Dim JanCode As String

        '発注情報データデータアクセスクラスの生成
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)

        MaxOrderCode = oDataOrderDBIO.getMaxOrderCode(CInt(String.Format("{0:00}", SUPPLIER_CODE)), String.Format("{0:yyMMdd}", Now), oTran)
        If MaxOrderCode = 9 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "同一発注先の本日の発注伝票が１０枚を超えました。",
                                            "不要な発注データを削除後、",
                                            "再度、発注処理を行って下さい。", Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
        Else
            ORDER_NUMBER = "991" & String.Format("{0:00}", SUPPLIER_CODE) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:0}", MaxOrderCode)
        End If
        ORDER_NUMBER = "991" & String.Format("{0:00}", SUPPLIER_CODE) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:0}", MaxOrderCode)

        'チェックデジットの生成
        JanCode = oTool.JANCD(ORDER_NUMBER)

        oDataOrderDBIO = Nothing

        ORDER_NUMBER_CREATE = JanCode
    End Function
    Private Function ORDER_INSERT(ByVal OrderMode As Integer) As Long
        Dim ret As Boolean
        Dim Ope As Integer

        Dim syohin As Long = 0 '個々の商品の金額

        Dim syouhizei As Long = 0　'軽減税率対象外の消費税の合計
        Dim keigen As Long = 0 '軽減税率対象の消費税の合計

        Dim zeiristu As Long = 0 '個々の商品の税率
        Dim zeiristu_flg As Boolean = False '軽減税率の商品が含まれているかのフラグ
        Dim syohin_total As Long = 0 '商品の合計(税抜)
        Dim Shipping As Integer = 0
        Dim Payment As Integer = 0


        '返品伝票印刷モードの場合は、オペレータとして-1をセット
        If OrderMode = 0 Then
            Ope = 1
        Else
            Ope = -1
        End If

        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)

        ReDim oOrderData(0)

        '発注コード
        oOrderData(0).sOrderCode = ORDER_CODE_T.Text.ToString
        '発注日
        oOrderData(0).sOrderDate = String.Format("{0:yyyy/MM/dd}", Now)
        '発注モード
        oOrderData(0).sOrderMode = ORDER_MODE


        '2019,10,31 A.Komita 修正 Start--------------------------------------------------------------------------------------------------

        If BEFORE_TAX_R.Checked = True Then         '税抜きモード時  
            '発注税抜商品金額
            oOrderData(0).sNoTaxTotalProductPrice = CLng(BEFORE_TAX_PRODUCT_T.Text) * Ope
            '送料
            oOrderData(0).sShippingCharge = CLng(POSTAGE_T.Text) * Ope
            '手数料
            oOrderData(0).sPaymentCharge = CLng(FEE_T.Text) * Ope
            '発注値引き
            oOrderData(0).sDiscount = CLng(DISCOUNT_T.Text) * -1 * Ope
            '発注ポイント値引き
            oOrderData(0).sPointDisCount = CLng(P_DISCOUNT_T.Text) * -1 * Ope
            '発注税抜金額
            oOrderData(0).sNoTaxTotalPrice = CLng(BEFORE_TAX_ORDER_T.Text) * Ope

            '2019/9/20 shimizu upd start
            '発注消費税額
            'oOrderData(0).sTaxTotal = (CLng(TAX_T.Text) + CLng(RTAX_RATE_T.Text)) * Ope
            oOrderData(0).sTaxTotal = CLng(TAX_T.Text) * Ope
            '軽減税率
            If RTAX_RATE_T.Text <> "0" Then
                oOrderData(0).sReducedTaxRate = REDUCED_TAX_RATE_FLG
            Else
                oOrderData(0).sReducedTaxRate = String.Empty

            End If
            '発注軽減消費税金額
            oOrderData(0).sReducedTaxRateTotal = CLng(RTAX_RATE_T.Text) * Ope
            '2019/9/20 shimizu add end

            '発注税込金額
            oOrderData(0).sTotalPrice = CLng(AFTER_TAX_ORDER_T.Text) * Ope


        Else     '税込みモード

            '発注税抜商品金額
            oOrderData(0).sNoTaxTotalProductPrice = (NoTaxTotal + NoReducedTaxTotal) * Ope
            '送料
            oOrderData(0).sShippingCharge = oTool.AfterToBeforeTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope

            Shipping = oTool.AfterToTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope

            '手数料
            oOrderData(0).sPaymentCharge = oTool.AfterToBeforeTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope

            Payment = oTool.AfterToTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc) * Ope


            '発注税抜金額
            oOrderData(0).sNoTaxTotalPrice = oOrderData(0).sNoTaxTotalProductPrice +
                                                oOrderData(0).sShippingCharge +
                                                oOrderData(0).sPaymentCharge

            '発注消費税額
            oOrderData(0).sTaxTotal = (TaxTotal + Shipping + Payment) * Ope

            If zeiristu_flg = False Then
                '軽減税率
                oOrderData(0).sReducedTaxRate = String.Empty
            Else
                oOrderData(0).sReducedTaxRate = REDUCED_TAX_RATE_FLG
            End If

            ''発注軽減消費税額
            'oOrderData(0).sReducedTaxRateTotal = keigen

            '発注軽減消費税額
            oOrderData(0).sReducedTaxRateTotal = ReducedTaxTotal

            '発注値引き
            oOrderData(0).sDiscount = CLng(DISCOUNT_T.Text) * -1 * Ope
            '発注ポイント値引き
            oOrderData(0).sPointDisCount = CLng(P_DISCOUNT_T.Text) * -1 * Ope

            '発注税込金額
            oOrderData(0).sTotalPrice = oOrderData(0).sNoTaxTotalPrice +
                                        oOrderData(0).sTaxTotal +
                                        oOrderData(0).sReducedTaxRateTotal +
                                        oOrderData(0).sDiscount +
                                        oOrderData(0).sPointDisCount

            NoTaxTotal = 0
            NoReducedTaxTotal = 0
            Shipping = 0
            Payment = 0

            Cal_Money_Flg = 0

            '2019,10,31 A.Komita 修正 End-----------------------------------------------------------------------------------------

        End If

        '仕入先コード
        oSupplierDBIO.getSupplierCode(oSupplier, SUPPLIER_C.Text, oTran)
        oOrderData(0).sSupplierCode = oSupplier(0).sSupplierCode

        '支払方法コード
        Select Case PAYMENT_L.SelectedIndex
            Case 0
                oOrderData(0).sPaymentCode = 1
            Case 1
                oOrderData(0).sPaymentCode = 2
            Case 2
                oOrderData(0).sPaymentCode = 3
            Case 3
                oOrderData(0).sPaymentCode = 4
            Case 4
                oOrderData(0).sPaymentCode = 5
            Case 5
                oOrderData(0).sPaymentCode = 7
            Case 6
                oOrderData(0).sPaymentCode = 8
            Case 7
                oOrderData(0).sPaymentCode = 9
            Case 8
                oOrderData(0).sPaymentCode = 10
            Case 9
                oOrderData(0).sPaymentCode = 11
            Case 10
                oOrderData(0).sPaymentCode = 12
        End Select

        '2019/9/28 shimizu upd end

        '希望納品日
        oOrderData(0).sRequestDate = RQ_DATE_T.Text
        '希望納品場所
        oOrderData(0).sRequestPlace = RQ_PLACE_T.Text
        '発注担当者コード
        oOrderData(0).sStaffCode = STAFF_CODE_T.Text
        '備考
        oOrderData(0).sMemo = MEMO_T.Text.ToString

        '伝票印刷モード
        If BEFORE_TAX_R.Checked = True Then
            oOrderData(0).sPrintMode = 1        '税抜き
        Else
            oOrderData(0).sPrintMode = 0        '税込み
        End If

        ret = oDataOrderDBIO.insertOrderData(oOrderData(0), oTran)
        If ret = False Then
            ORDER_INSERT = -1
        End If
        ORDER_INSERT = 1
    End Function
    Private Function ORDER_SUB_INSERT(ByVal OrderMode As Integer) As Long
        Dim ret As Boolean
        Dim i As Integer
        Dim oProductDBIO As cMstProductDBIO
        Dim oProduct() As cStructureLib.sProduct
        Dim oCostPriceDBIO As cMstCostPriceDBIO
        Dim oCostPrice() As cStructureLib.sCostPrice
        Dim RecordCnt As Long

        oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)

        ReDim oOrderSubData(0)

        For i = 0 To ORDER_V.Rows.Count - 1
            ReDim oProduct(0)
            RecordCnt = oProductDBIO.getProduct(oProduct, Nothing, ORDER_V("商品コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            ReDim oCostPrice(0)
            oCostPriceDBIO.getPriceMst(oCostPrice, ORDER_V("商品コード", i).Value, SUPPER_CODE_T.Text, oTran)

            '発注コード
            oOrderSubData(0).sOrderCode = ORDER_CODE_T.Text.ToString
            '発注明細コード
            oOrderSubData(0).sOrderSubCode = i + 1
            'JANコード
            oOrderSubData(0).sJANCode = oProduct(0).sJANCode
            '商品コード
            oOrderSubData(0).sProductCode = oProduct(0).sProductCode
            '商品略称
            oOrderSubData(0).sProductName = oProduct(0).sProductShortName
            'オプション1
            oOrderSubData(0).sOption1 = oProduct(0).sOption1
            'オプション2
            oOrderSubData(0).sOption2 = oProduct(0).sOption2
            'オプション3
            oOrderSubData(0).sOption3 = oProduct(0).sOption3
            'オプション4
            oOrderSubData(0).sOption4 = oProduct(0).sOption4
            'オプション5
            oOrderSubData(0).sOption5 = oProduct(0).sOption5
            '--------------------------------------------------
            'suzuki 2019/09/29
            '--------------------------------------------------
            '定価
            oOrderSubData(0).sListPrice = ORDER_V("定価", i).Value
            '仕入価格
            oOrderSubData(0).sCostPrice = ORDER_V("仕入価格", i).Value
            '発注商品単価
            oOrderSubData(0).sUnitPrice = oCostPrice(0).sCostPrice
            '発注数量
            oOrderSubData(0).sCount = CLng(ORDER_V("数量", i).Value)
            '発注税抜金額
            oOrderSubData(0).sNoTaxPrice = oOrderSubData(0).sUnitPrice * oOrderSubData(0).sCount
            '発注税込金額
            oOrderSubData(0).sPrice = CLng(ORDER_V("金額", i).Value)
            '発注消費税額
            oOrderSubData(0).sTaxPrice = oOrderSubData(0).sPrice - oOrderSubData(0).sNoTaxPrice
            '2019/9/6 add start
            '軽減税率
            oOrderSubData(0).sReducedTaxRate = oProduct(0).sReducedTaxRate
            '2019/9/6 add end
            '--------------------------------------------------
            'suzuki 2019/09/29 end
            '--------------------------------------------------
            'データ書込み
            ret = oDataOrderSubDBIO.insertOrderSubData(oOrderSubData(0), oTran)
            If ret = False Then
                ORDER_SUB_INSERT = -1
            End If
        Next i
        ORDER_SUB_INSERT = i
    End Function
    Private Function STOCK_UPDATE() As Boolean
        Dim oStock() As cStructureLib.sStock
        Dim oStockDBIO As New cMstStockDBIO(oConn, oCommand, oDataReader)
        Dim i As Integer
        Dim ret As Boolean

        For i = 0 To ORDER_V.Rows.Count - 1
            ReDim oStock(0)
            oStockDBIO.getStock(oStock, ORDER_V("商品コード", i).Value, oTran)
            oStock(0).sStockCount = oStock(0).sStockCount - CInt(ORDER_V("数量", i).Value)
            ret = oStockDBIO.updateStock(oStock, oTran)
            If ret = False Then
                STOCK_UPDATE = False
                Exit For
            End If
        Next
        STOCK_UPDATE = True
    End Function
    Private Sub ORDER_DELETE()
        'いつでも消せるように
        'LogWrite(ORDER_CODE_T.Text.ToString)
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)

        '発注データの削除
        oDataOrderDBIO.deleteOrderData(ORDER_CODE_T.Text.ToString, oTran)

        oDataOrderDBIO = Nothing

        oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)

        '発注明細データの削除
        oDataOrderSubDBIO.deleteOrderSubData(ORDER_CODE_T.Text.ToString, oTran)

        oDataOrderSubDBIO = Nothing

    End Sub

    Private Sub ORDER_V_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles ORDER_V.CellValueChanged

        '数量セルの変更の場合
        If e.ColumnIndex = 6 Then
            'If CALLING_FLG = False Then
            '数量の更新
            ReDim oOrderStatus(0)
            oOrderStatus(0).sProductCode = ORDER_V("商品コード", ORDER_V.CurrentRow.Index).Value
            oOrderStatus(0).sCheck = True
            oOrderStatus(0).sCount = ORDER_V("数量", ORDER_V.CurrentRow.Index).Value
            oDataOrderStatusDBIO.updateOrderStatus(oOrderStatus(0), oTran)
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
        Dim zero As Integer = 0


        If CALLING_FLG = False Then
            CALLING_FLG = True

            BeforeTaxPrice = 0
            TaxPrice = 0
            TotalPrice = 0


            TAX_TOTAL_PRICE_STR = "0"
            RTAX_RATE_TOTAL_STR = "0"
            TAX_STR = "0"
            REDUCED_TAX_RATE_STR = "0"
            POSTAGE_TAX = "0"
            FEE_TAX = "0"


            '2019,11,29 A.Komita 数量を変更した時に再計算をする為フラグを変数を初期化するコードを追加 From
            If AFTER_TAX_R.Checked = True Then

                If ORDER_V("数量", i).Value <> 1 Then
                    Cal_Money_Flg = 0
                    NoTaxTotal = 0
                    TaxTotal = 0
                    NoReducedTaxTotal = 0
                    ReducedTaxTotal = 0

                End If
            End If
            '2019,11,29 A.Komita 追加 To


            For i = 0 To ORDER_V.RowCount - 1

                    '選択された仕入先の仕入価格を抽出
                    oProductDBIO.getProduct(oProduct, Nothing, ORDER_V("商品コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

                    '選択された仕入先の仕入価格を抽出
                    oCostPriceDBIO.getPriceMst(oCostPrice, ORDER_V("商品コード", i).Value, SUPPER_CODE_T.Text, oTran)

                    If BEFORE_TAX_R.Checked = True Then         '税抜きの場合   
                        '定価の更新
                        ORDER_V("定価", i).Value = oProduct(0).sListPrice

                        '仕入単価の更新
                        ORDER_V("仕入価格", i).Value = oCostPrice(0).sCostPrice

                        '明細行発注金額の更新
                        ORDER_V("金額", i).Value = ORDER_V("仕入価格", i).Value * ORDER_V("数量", i).Value

                        '2019/9/20 shimiz add start
                        '軽減税率対象、非対象のそれぞれ
                        If oProduct(0).sReducedTaxRate = String.Empty Then

                            '軽減税率対象外の商品の金額合計
                            TAX_TOTAL_PRICE_STR = String.Format("{0,9:C}", CLng(TAX_TOTAL_PRICE_STR) + oProduct(0).sListPrice)
                            TAX_T.Text = String.Format("{0,9:C}", TAX_STR + oTool.BeforeToTax(ORDER_V("仕入価格", i).Value * ORDER_V("数量", i).Value, oConf(0).sTax, oConf(0).sFracProc))
                            '商品の消費税の合計
                            TAX_STR = TAX_T.Text
                        Else
                            '軽減税率対象の商品の金額合計
                            RTAX_RATE_TOTAL_STR = String.Format("{0,9:C}", CLng(RTAX_RATE_TOTAL_STR) + oProduct(0).sListPrice)
                            RTAX_RATE_T.Text = String.Format("{0,9:C}", REDUCED_TAX_RATE_STR + oTool.BeforeToTax(ORDER_V("仕入価格", i).Value * ORDER_V("数量", i).Value, oProduct(0).sReducedTaxRate, oConf(0).sFracProc))
                            '軽減税率商品の消費税の合計
                            REDUCED_TAX_RATE_STR = RTAX_RATE_T.Text
                        End If
                        '2019/9/20 shimiz add end

                    Else    '税込みの場合

                        '2019/8/30 shimizu add start
                        If oProduct(0).sReducedTaxRate = String.Empty Then
                            '定価の更新
                            ORDER_V("定価", i).Value = oTool.BeforeToAfterTax(oProduct(0).sListPrice, oConf(0).sTax, oConf(0).sFracProc)

                            '仕入単価の更新
                            ORDER_V("仕入価格", i).Value = oTool.BeforeToAfterTax(oCostPrice(0).sCostPrice, oConf(0).sTax, oConf(0).sFracProc)

                            '明細行発注金額の更新
                            ORDER_V("金額", i).Value = ORDER_V("仕入価格", i).Value * ORDER_V("数量", i).Value

                        Else
                            '定価の更新
                            ORDER_V("定価", i).Value = oTool.BeforeToAfterTax(oProduct(0).sListPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)

                            '仕入単価の更新
                            ORDER_V("仕入価格", i).Value = oTool.BeforeToAfterTax(oCostPrice(0).sCostPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)

                            '明細行発注金額の更新
                            ORDER_V("金額", i).Value = ORDER_V("仕入価格", i).Value * ORDER_V("数量", i).Value

                        End If

                    End If

                    '税率の更新
                    If oProduct(0).sReducedTaxRate = String.Empty Then
                        ORDER_V("税率", i).Value = oConf(0).sTax & "%"
                    Else
                        ORDER_V("税率", i).Value = oProduct(0).sReducedTaxRate & "%"
                    End If
                    '2019/8/30 shimizu add end


                    '（税込み金額計算）
                    TotalPrice = TotalPrice + ORDER_V("金額", i).Value


                '2019,11,2 A.Komita 追加 From

                'ORDER_INSERTで税込モードで登録する際、税抜価格と消費税の値が必要になるのでここで取得している

                If Cal_Money_Flg = 0 Then

                    If AFTER_TAX_R.Checked = True Then
                        If oProduct(0).sReducedTaxRate = String.Empty Then
                            NoTaxTotal += oTool.AfterToBeforeTax(ORDER_V("金額", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                            TaxTotal += oTool.AfterToTax(ORDER_V("金額", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            NoReducedTaxTotal += oTool.AfterToBeforeTax(ORDER_V("金額", i).Value, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)
                            ReducedTaxTotal += oTool.AfterToTax(ORDER_V("金額", i).Value, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)
                        End If

                    End If
                Else

                End If

            Next

                Cal_Money_Flg = 1

                '2019,11,2 A.Komita 追加 To

                '---------------------
                '    合計値セット
                '---------------------
                BEFORE_TAX_PRODUCT_T.Text = String.Format("{0,9:C}", TotalPrice)

                If MODE_CHANGE = True Then
                    If BEFORE_TAX_R.Checked = True Then     '税抜きの場合
                        '--------------------------------------------------
                        'suzuki 2019/09/29
                        '--------------------------------------------------
                        POSTAGE_TAX = oTool.AfterToTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        FEE_TAX = oTool.AfterToTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        POSTAGE_T.Text = String.Format("{0,9:C}", CLng(POSTAGE_T.Text) - CLng(POSTAGE_TAX))
                        FEE_T.Text = String.Format("{0,9:C}", CLng(FEE_T.Text) - CLng(FEE_TAX))

                        BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}",
                                                            CLng(BEFORE_TAX_PRODUCT_T.Text) +
                                                            CLng(POSTAGE_T.Text) +
                                                            CLng(FEE_T.Text))

                        TAX_T.Text = String.Format("{0,9:C}", CLng(TAX_T.Text) +
                                               CLng(POSTAGE_TAX) +
                                               CLng(FEE_TAX))

                        AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_ORDER_T.Text) +
                                                           CLng(TAX_T.Text) +
                                                           CLng(RTAX_RATE_T.Text) -
                                                           CLng(DISCOUNT_T.Text) -
                                                           CLng(P_DISCOUNT_T.Text))

                    Else

                        POSTAGE_TAX = oTool.BeforeToTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        FEE_TAX = oTool.BeforeToTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)


                        If oProduct(0).sReducedTaxRate = String.Empty Then
                            POSTAGE_T.Text = String.Format("{0,9:C}", CLng(POSTAGE_T.Text) + CLng(POSTAGE_TAX))
                            FEE_T.Text = String.Format("{0,9:C}", CLng(FEE_T.Text) + CLng(FEE_TAX))
                            BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}",
                                                                CLng(BEFORE_TAX_PRODUCT_T.Text) +
                                                                CLng(POSTAGE_T.Text) +
                                                                CLng(FEE_T.Text))
                            TAX_T.Text = 0
                            RTAX_RATE_T.Text = 0
                            AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_ORDER_T.Text) -
                                                               CLng(DISCOUNT_T.Text) -
                                                               CLng(P_DISCOUNT_T.Text))


                        Else
                            POSTAGE_T.Text = String.Format("{0,9:C}", CLng(POSTAGE_T.Text) + CLng(POSTAGE_TAX))
                            FEE_T.Text = String.Format("{0,9:C}", CLng(FEE_T.Text) + CLng(FEE_TAX))
                            BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}",
                                                                CLng(BEFORE_TAX_PRODUCT_T.Text) +
                                                                CLng(POSTAGE_T.Text) +
                                                                CLng(FEE_T.Text))
                            TAX_T.Text = 0
                            RTAX_RATE_T.Text = 0
                            AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_ORDER_T.Text) -
                                                                CLng(DISCOUNT_T.Text) -
                                                                CLng(P_DISCOUNT_T.Text))
                        End If
                        '--------------------------------------------------
                        'suzuki 2019/09/29 end
                        '--------------------------------------------------

                    End If

                Else
                    If BEFORE_TAX_R.Checked = True Then     '税抜きの場合

                        POSTAGE_TAX = oTool.BeforeToTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        FEE_TAX = oTool.BeforeToTax(CLng(FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                        BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}",
                                                           CLng(BEFORE_TAX_PRODUCT_T.Text) +
                                                           CLng(POSTAGE_T.Text) +
                                                           CLng(FEE_T.Text))

                        TAX_T.Text = String.Format("{0,9:C}", CLng(TAX_STR) +
                                               CLng(POSTAGE_TAX) +
                                               CLng(FEE_TAX))

                        AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_ORDER_T.Text) +
                                                           CLng(TAX_T.Text) +
                                                           CLng(RTAX_RATE_T.Text) -
                                                           CLng(DISCOUNT_T.Text) -
                                                           CLng(P_DISCOUNT_T.Text))
                    Else

                        BEFORE_TAX_ORDER_T.Text = String.Format("{0,9:C}",
                                                           CLng(BEFORE_TAX_PRODUCT_T.Text) +
                                                           CLng(POSTAGE_T.Text) +
                                                           CLng(FEE_T.Text))
                        TAX_T.Text = 0
                        RTAX_RATE_T.Text = 0
                        AFTER_TAX_ORDER_T.Text = String.Format("{0,9:C}", CLng(BEFORE_TAX_ORDER_T.Text) -
                                                           CLng(DISCOUNT_T.Text) -
                                                           CLng(P_DISCOUNT_T.Text))
                    End If
                End If
                CALLING_FLG = False
                POSTAGE_TAX = "0"
                FEE_TAX = "0"

                '送料、手数料の値が変更された時のフラグ
                POSTAGE_FLG = POSTAGE_T.Text
                FEE_FLG = FEE_T.Text

            End If

    End Sub

    Private Sub SUPPLIER_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SUPPLIER_C.SelectedIndexChanged
        Dim RecordCnt As Integer
        Dim i As Integer

        '仕入先情報取得
        oSupplierDBIO.getSupplierCode(oSupplier, SUPPLIER_C.Text, oTran)
        SUPPER_CODE_T.Text = oSupplier(0).sSupplierCode
        MEMO_T.Text = oSupplier(0).sMemo & vbCrLf & MEMO_T.Text

        '支払方法リストボックスセット
        PAYMENT_L.BeginUpdate()

        'リストボックスの初期化
        PAYMENT_L.Items.Clear()
        PAYMENT_L.Refresh()

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)


        RecordCnt = oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To oPayment.Length - 1
            PAYMENT_L.Items.Add(oPayment(i).sPaymentName)
        Next i

        '--------------------------------------------------
        'suzuki 2019/09/29 end
        '--------------------------------------------------

        PAYMENT_L.EndUpdate()
        PAYMENT_L.SelectedIndex = 0

        TRN_RULE_T.Text = oSupplier(0).sTrnRule

        '仕入単価および発注金額の更新
        'CAL_MONEY(False)
    End Sub

    Private Sub BEFORE_TAX_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BEFORE_TAX_R.CheckedChanged
        If INIT_FLG = False And BEFORE_TAX_R.Checked = True Then
            CAL_MONEY(True)
        End If
    End Sub
    Private Sub AFTER_TAX_R_CheckedChanged(sender As Object, e As EventArgs) Handles AFTER_TAX_R.CheckedChanged
        If INIT_FLG = False And AFTER_TAX_R.Checked = True Then
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
        If INIT_FLG = False And FEE_FLG <> FEE_T.Text Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub POSTAGE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSTAGE_T.LostFocus
        If INIT_FLG = False And POSTAGE_FLG <> POSTAGE_T.Text Then
            CAL_MONEY(False)
        End If
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        'エラートラップを設定
        On Error Resume Next

        oTran.Rollback()

        'エラートラップを解除
        On Error GoTo 0


        oDataOrderDBIO = Nothing
        oDataOrderSubDBIO = Nothing
        oDataOrderStatusDBIO = Nothing
        oSupplierDBIO = Nothing
        'oStaffDBIO = Nothing
        oMstConfigDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub PRINT_START_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINT_START_B.Click
        Dim ret As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim oReportPage As New cReportsLib.cReportsLib
        Dim DefaultTaxMode As Integer   '0：税込みモード   1：税抜きモード
        Dim ReportMode As String

        If IsNothing(oTran) = True Then
            oTran = oConn.BeginTransaction()
        End If

        '発注データの削除
        ORDER_DELETE()

        'デフォルト税モード = 税込みモードにセット
        DefaultTaxMode = 0

        '発注情報データ登録
        ret = ORDER_INSERT(ORDER_MODE)
        If ret = -1 Then
            'トランザクションのロールバック
            oTran.Rollback()

            Message_form = New cMessageLib.fMessage(1, "発注情報の登録に失敗しました。",
                                            "開発元に連絡して下さい。",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If

        '発注情報明細データ登録
        ret = ORDER_SUB_INSERT(ORDER_MODE)
        If ret = -1 Then
            'トランザクションのロールバック
            oTran.Rollback()

            Message_form = New cMessageLib.fMessage(1, "発注情報明細の登録に失敗しました。",
                                            "開発元に連絡して下さい。",
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
        If ORDER_MODE = 1 Then
            ret = STOCK_UPDATE()
            If ret = False Then
                'トランザクションのロールバック
                oTran.Rollback()

                Message_form = New cMessageLib.fMessage(1, "在庫情報の更新に失敗しました。",
                                                "開発元に連絡して下さい。",
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
        Message_form = New cMessageLib.fMessage(0, "発注伝票を印刷中です。",
                                        "しばらくお待ちください。",
                                        Nothing, Nothing)
        Message_form.Show()

        Application.DoEvents()

        '印刷開始
        If ORDER_MODE = 0 Then      '発注伝票印刷
            ret = oReportPage.OrderPrint(oConn, oCommand, oDataReader, ORDER_CODE_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)
            oReportPage = Nothing
        Else                        '返品伝票印刷
            ret = oReportPage.ReturnOrderPrint(oConn, oCommand, oDataReader, ORDER_CODE_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)

            oReportPage = Nothing
        End If
        Message_form.Dispose()
        Message_form = Nothing

        If ret = False Then
            'トランザクションのロールバック
            oTran.Rollback()

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "発注伝票の印刷に失敗しました。",
                                            "システム管理者にお問い合わせ下さい。",
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

            Message_form = New cMessageLib.fMessage(2, "作成中の伝票は印刷されていません",
                                            "作成中のデータは破棄されます。",
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

    '設定したパスのテキストファイルにログを書き込む処理
    'テキストファイルはl_folderPathのパス内に[Log今日の日付.txt]で出力されます。
    'ストリング型の文字列を引数に渡してください。
    'Private Sub LogWrite(ByVal text As String)
    '    '今日の日付の取得
    '    Dim l_NowDate As String = System.DateTime.Now.Date
    '    l_NowDate = l_NowDate.Replace("/", "") '/を取り除く
    '    '出力する文字列の設定
    '    Dim l_outText As String = text
    '    'カスタマイズ部分　ーーー　出力するフォルダパスの設定
    '    Dim l_folderPath As String = "C:\test"
    '    'パスに出力ファイルの名称を追加
    '    l_folderPath += "\Log" + l_NowDate + ".txt"
    '    'アセンブリ名称の取得
    '    Dim assenblyName As String = System.IO.Path.GetFileName(Me.GetType().Assembly.Location)
    '    'Shift JISで書き込む
    '    '書き込むファイルが既に存在している場合は、追加で書き込む
    '    Dim l_sw As New System.IO.StreamWriter(l_folderPath,
    '        True,
    '        System.Text.Encoding.GetEncoding("shift_jis"))
    '    'ログを書き込む
    '    l_sw.Write(vbCrLf + "[" + assenblyName + "]" + System.DateTime.Now + " ---- " + text)
    '    '閉じる
    '    l_sw.Close()

    'End Sub

End Class
