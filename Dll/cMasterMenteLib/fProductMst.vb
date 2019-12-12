Imports System.IO
Public Class fProductMst

    Private Const DISP_ROW_MAX = 500

    Private oTool As cTool

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProduct() As cStructureLib.sProduct
    Private oMstProductDBIO As cMstProductDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oMstCostPriceDBIO As cMstCostPriceDBIO

    Private oSalePrice() As cStructureLib.sSalePrice
    Private oMstSalePriceDBIO As cMstSalePriceDBIO

    Private oNetInfo() As cStructureLib.sNetInfo
    Private oNetInfoDBIO As cMstNetInfoDBIO

    Private oSales() As cStructureLib.sViewSales
    Private oSalesDBIO As cMstSalesDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oStock() As cStructureLib.sStock
    Private oMstStockDBIO As cMstStockDBIO

    Private oDirectry() As cStructureLib.sDirectryMst
    Private oDirectryDBIO As cMstDirectryDBIO

    Private oCategory1() As cStructureLib.sCategory1
    Private oCategory2() As cStructureLib.sCategory2
    Private oCategoryDBIO As cMstCategoryDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private PRODUCT_CODE As String

    Private IVENT_FLG As Boolean

    Private SEARCH_CATEGORY_1 As String
    Private SEARCH_CATEGORY_2 As String
    Private SEARCH_PRODUCT_CODE As String

    Private SUB_MODE As Boolean

    Private oTran As OleDb.OleDbTransaction

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        SUB_MODE = False

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oDirectryDBIO = New cMstDirectryDBIO(oConn, oCommand, oDataReader)
        oCategoryDBIO = New cMstCategoryDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oNetInfoDBIO = New cMstNetInfoDBIO(oConn, oCommand, oDataReader)
        oMstSalePriceDBIO = New cMstSalePriceDBIO(oConn, oCommand, oDataReader)
        oMstCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstStockDBIO = New cMstStockDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        PRODUCT_CODE = Nothing
        STAFF_CODE = Nothing
        STAFF_NAME = Nothing

    End Sub

    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByVal ProductCode As String,
            ByVal StaffCode As String,
            ByVal StaffName As String,
            ByRef iTran As OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        SUB_MODE = True

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oDirectryDBIO = New cMstDirectryDBIO(oConn, oCommand, oDataReader)
        oCategoryDBIO = New cMstCategoryDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oNetInfoDBIO = New cMstNetInfoDBIO(oConn, oCommand, oDataReader)
        oMstSalePriceDBIO = New cMstSalePriceDBIO(oConn, oCommand, oDataReader)
        oMstCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstStockDBIO = New cMstStockDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool
        PRODUCT_CODE = ProductCode
        STAFF_CODE = StaffCode
        STAFF_NAME = StaffName

    End Sub

    Private Sub fMstProduct_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Windows.Forms.Application.DoEvents()
            Windows.Forms.Application.Exit()
        End If

        If STAFF_CODE = Nothing Then
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            Windows.Forms.Application.DoEvents()
            STAFF_CODE = staff_form.STAFF_CODE_T.Text
            STAFF_NAME = staff_form.STAFF_NAME_T.Text
            staff_form = Nothing
        End If

        'オプションラベルセット
        OPTION_SET()

        '仕入先リストボックスセット
        SUPPLIER_SET()

        SEARCH_CATEGORY_1 = ""
        SEARCH_CATEGORY_2 = ""

        'カテゴリ１リストボックスセット
        CATEGORY_1_SET()

        'ディレクトリーリストボックスセット
        DIRECTRY_1_SET()

        'ネット掲載パスリストボックスセット
        PATH_1_SET()

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        IVENT_FLG = True

        '表示初期化処理
        INIT_PROC()

        If PRODUCT_CODE <> Nothing Then
            PRODUCT_CODE_T.Text = PRODUCT_CODE
            UPDATE_PRODUCT_SET()
            PRODUCT_CODE_T.ReadOnly = True
            CATEGORY_1_L.Enabled = False
            CATEGORY_2_L.Enabled = False
        End If

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        MODE_T.Text = "（新規）"

        NET_TAB_T.SelectedTab = NetTab1

        If PRODUCT_CODE = Nothing Then
            CATEGORY_1_L.Visible = True
            CATEGORY_2_L.Visible = True
            CATEGORY_1_T.Visible = False
            CATEGORY_2_T.Visible = False
            PRODUCT_CODE_T.ReadOnly = False
            '2017.09.27 Y.Sato 追加　
            CREATE_JANCD_B.Enabled = True

        Else
            CATEGORY_1_L.Visible = False
            CATEGORY_2_L.Visible = False
            CATEGORY_1_T.Visible = True
            CATEGORY_2_T.Visible = True
            PRODUCT_CODE_T.ReadOnly = True

            DELETE_B.Enabled = False
            COPY_B.Enabled = False
            SEARCH_B.Enabled = False
        End If

        '仕入価格初期化
        For i = 0 To COST_PRICE_V.Rows.Count - 1
            COST_PRICE_V.Rows.Clear()
        Next i

        '販売価格初期化
        For i = 0 To SALE_PRICE_V.Rows.Count - 1
            SALE_PRICE_V.Rows.Clear()
        Next i

        'カテゴリ初期化
        CATEGORY_1_L.Text = ""
        CATEGORY_2_L.Text = ""

        '商品情報初期化
        PRODUCT_CODE_T.Text = ""
        JANCODE_T.Text = ""
        PLU_CODE_T.Text = ""
        PRODUCT_NAME_T.Text = ""
        PRODUCT_S_NAME_T.Text = ""
        MAKER_NAME_T.Text = ""
        SYUBETU_1_R.Checked = True
        OPTION1_T.Text = ""
        OPTION2_T.Text = ""
        OPTION3_T.Text = ""
        OPTION4_T.Text = ""
        OPTION5_T.Text = ""
        MEMO_T.Text = ""
        STOPSALE_C.Checked = False
        STOPSUPPLIER_C.Checked = False

        '2019.8.7 A.Komita From
        RTAX_RATE_T.Text = ""
        '2019.8.7 A.Komita To

        PRICE_T.Text = ""
        TAX_PRICE_T.Text = ""
        BEFORETAX_PRICE_T.Text = ""
        YAHOO_C.Checked = False
        RAKUTEN_C.Checked = False
        AMAZON_C.Checked = False
        ORIGINAL_C.Checked = False
        MIN_STOCK_T.Text = ""

        'ネット掲載情報初期化
        DIRECTRY_ID_T.Text = ""
        DIRECTRY_1_L.Text = ""
        DIRECTRY_2_L.Text = ""
        DIRECTRY_3_L.Text = ""
        DIRECTRY_4_L.Text = ""
        DIRECTRY_5_L.Text = ""
        PATH_T.Text = ""
        PATH_1_L.Text = ""
        PATH_2_L.Text = ""
        META_KEYWORD_T.Text = ""
        META_DESCRIPTION_T.Text = ""
        CATCH_COPY_T.Text = ""
        PRODUCT_INFO_T.Text = ""
        PRODUCT_DESCRIPTION_T.Text = ""
        MATERIAL_T.Text = ""
        SIZE_HEIGHT_T.Text = ""
        SIZE_WIDE_T.Text = ""
        SIZE_DEPTH_T.Text = ""
        SIZE_NECK_T.Text = ""
        SIZE_BUST_T.Text = ""
        SIZE_WAIST_T.Text = ""
        SIZE_LENGTH_T.Text = ""
        RECOMMENDATION_T.Text = ""

        '販売状況情報初期化
        NETUP_V.ReadOnly = True

        '画像初期化
        PRODUCT_P1_PB.Image = Nothing
        PRODUCT_P2_PB.Image = Nothing
        PRODUCT_P3_PB.Image = Nothing
        PRODUCT_P4_PB.Image = Nothing
        PRODUCT_P5_PB.Image = Nothing

        SEARCH_PRODUCT_CODE = ""
        SEARCH_CATEGORY_1 = ""
        SEARCH_CATEGORY_2 = ""
    End Sub

    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property
    <System.Runtime.InteropServices.DllImport("USER32.DLL",
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function HideCaret(
           ByVal hwnd As IntPtr) As Integer
    End Function
    '******************************
    '     System.Windows.Forms.DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    Sub GRIDVIEW_CREATE()
        Dim i As Integer
        Dim RecordCount As Integer
        Dim oSupplier() As cStructureLib.sSupplier
        Dim oSupplierDBIO As cMstSupplierDBIO
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        '-------------- 仕入価格の描画 ------------------------
        'レコードセレクタを非表示に設定
        COST_PRICE_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim SupplierName As New System.Windows.Forms.DataGridViewComboBoxColumn()
        SupplierName.HeaderText = "仕入先名称"
        SupplierName.Name = "SupplierName"
        COST_PRICE_V.Columns.Add(SupplierName)
        SupplierName.Width = 180
        SupplierName.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        SupplierName.Name = "仕入先名称"

        'ComboBoxのリストに表示する項目を指定する
        ReDim oSupplier(0)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        RecordCount = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        SupplierName.Items.Add("")
        For i = 0 To oSupplier.Length - 1
            SupplierName.Items.Add(oSupplier(i).sSupplierName)
        Next i
        oSupplierDBIO = Nothing

        Dim CostPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        CostPrice.HeaderText = "仕入価格"
        COST_PRICE_V.Columns.Add(CostPrice)
        CostPrice.Width = 90
        CostPrice.DefaultCellStyle.Format = "c"
        CostPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        CostPrice.Name = "仕入価格"

        Dim CostTaxPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        CostTaxPrice.HeaderText = "消費税"
        COST_PRICE_V.Columns.Add(CostTaxPrice)
        CostTaxPrice.Width = 80
        CostTaxPrice.DefaultCellStyle.Format = "c"
        CostTaxPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        CostTaxPrice.ReadOnly = False
        CostTaxPrice.Name = "消費税"

        Dim CostBeforeTaxPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        CostBeforeTaxPrice.HeaderText = "税込価格"
        COST_PRICE_V.Columns.Add(CostBeforeTaxPrice)
        CostBeforeTaxPrice.Width = 90
        CostBeforeTaxPrice.DefaultCellStyle.Format = "c"
        CostBeforeTaxPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        CostBeforeTaxPrice.ReadOnly = False
        CostBeforeTaxPrice.Name = "税込価格"

        Dim SupplierCode As New System.Windows.Forms.DataGridViewTextBoxColumn
        SupplierCode.HeaderText = "仕入先コード"
        COST_PRICE_V.Columns.Add(SupplierCode)
        SupplierCode.Width = 90
        SupplierCode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        SupplierCode.Visible = False
        SupplierCode.Name = "仕入先コード"

        '背景色を白に設定
        COST_PRICE_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        COST_PRICE_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

        '-------------- 販売価格の描画 ------------------------
        'レコードセレクタを非表示に設定
        SALE_PRICE_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim ChannelName As New System.Windows.Forms.DataGridViewComboBoxColumn()
        ChannelName.HeaderText = "チャネル名称"
        SALE_PRICE_V.Columns.Add(ChannelName)
        ChannelName.Width = 100
        ChannelName.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ChannelName.Name = "チャネル名称"
        ChannelName.SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic

        'ComboBoxのリストに表示する項目を指定する
        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, 2, oTran)
        ChannelName.Items.Add("")
        For i = 0 To oChannel.Length - 1
            ChannelName.Items.Add(oChannel(i).sChannelName)
        Next i
        oChannelDBIO = Nothing

        Dim SalePrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        SalePrice.HeaderText = "販売価格"
        SALE_PRICE_V.Columns.Add(SalePrice)
        SalePrice.Width = 80
        SalePrice.DefaultCellStyle.Format = "c"
        SalePrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        SalePrice.Name = "販売価格"

        Dim SaleTaxPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        SaleTaxPrice.HeaderText = "消費税"
        SALE_PRICE_V.Columns.Add(SaleTaxPrice)
        SaleTaxPrice.Width = 70
        SaleTaxPrice.DefaultCellStyle.Format = "c"
        SaleTaxPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        SaleTaxPrice.ReadOnly = True
        SaleTaxPrice.Name = "消費税"

        Dim SaleBeforeTaxPrice As New System.Windows.Forms.DataGridViewTextBoxColumn
        SaleBeforeTaxPrice.HeaderText = "税込価格"
        SALE_PRICE_V.Columns.Add(SaleBeforeTaxPrice)
        SaleBeforeTaxPrice.Width = 85
        SaleBeforeTaxPrice.DefaultCellStyle.Format = "c"
        SaleBeforeTaxPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        SaleBeforeTaxPrice.ReadOnly = False
        SaleBeforeTaxPrice.Name = "税込価格"

        Dim FromDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        FromDate.HeaderText = "適用開始日"
        SALE_PRICE_V.Columns.Add(FromDate)
        FromDate.Width = 95
        FromDate.DefaultCellStyle.Format = "YYYY/MM/DD"
        FromDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        FromDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        FromDate.Name = "適用開始日"

        Dim ToDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        ToDate.HeaderText = "適用終了日"
        SALE_PRICE_V.Columns.Add(ToDate)
        ToDate.Width = 95
        ToDate.DefaultCellStyle.Format = "YYYY/MM/DD"
        ToDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        ToDate.Name = "適用終了日"

        Dim ChannelCode As New System.Windows.Forms.DataGridViewTextBoxColumn
        ChannelCode.HeaderText = "チャネルコード"
        SALE_PRICE_V.Columns.Add(ChannelCode)
        ChannelCode.Width = 100
        ChannelCode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        ChannelCode.Visible = False
        ChannelCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        ChannelCode.Name = "チャネルコード"

        '背景色を白に設定
        SALE_PRICE_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        SALE_PRICE_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

        '販売価格Viewのソート設定
        Dim c As System.Windows.Forms.DataGridViewColumn
        For Each c In SALE_PRICE_V.Columns
            c.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Next c

        '-------------- ネット掲載状況の描画 ------------------------
        'レコードセレクタを非表示に設定
        NETUP_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim NetChannelName As New System.Windows.Forms.DataGridViewTextBoxColumn
        NetChannelName.HeaderText = "チャネル名称"
        NETUP_V.Columns.Add(NetChannelName)
        NetChannelName.Width = 110
        NetChannelName.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim NetStartDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        NetStartDate.HeaderText = "掲載開始日"
        NETUP_V.Columns.Add(NetStartDate)
        NetStartDate.Width = 90
        NetStartDate.DefaultCellStyle.Format = "c"
        NetStartDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight

        Dim NetEndDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        NetEndDate.HeaderText = "掲載終了日"
        NETUP_V.Columns.Add(NetEndDate)
        NetEndDate.Width = 90
        NetEndDate.DefaultCellStyle.Format = "c"
        NetEndDate.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

        '背景色を白に設定
        NETUP_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        NETUP_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '更新対象の商品マスタ情報を画面にセット
    '***********************************************
    Private Sub UPDATE_PRODUCT_SET()
        Dim RecordCount As Long
        Dim i As Integer
        Dim tPath As String
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        MODE_T.Text = "（更新）"
        MODE_T.BackColor = Drawing.Color.Blue

        '商品情報セット
        RecordCount = oMstProductDBIO.getProduct(oProduct, Nothing, PRODUCT_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        PRODUCT_CODE_T.Text = oProduct(0).sProductCode
        PLU_CODE_T.Text = oProduct(0).sPLUCode
        JANCODE_T.Text = oProduct(0).sJANCode
        PRODUCT_NAME_T.Text = oProduct(0).sProductName
        PRODUCT_S_NAME_T.Text = oProduct(0).sProductShortName
        Select Case oProduct(0).sProductClass
            Case 1
                SYUBETU_1_R.Checked = True
            Case 2
                SYUBETU_2_R.Checked = True
            Case 3
                SYUBETU_3_R.Checked = True
        End Select
        MAKER_NAME_T.Text = oProduct(0).sMakerName
        OPTION1_T.Text = oProduct(0).sOption1
        OPTION2_T.Text = oProduct(0).sOption2
        OPTION3_T.Text = oProduct(0).sOption3
        OPTION4_T.Text = oProduct(0).sOption4
        OPTION5_T.Text = oProduct(0).sOption5
        MEMO_T.Text = oProduct(0).sMemo
        If oProduct(0).sStopSaleFlg = True Then
            STOPSALE_C.Checked = True
        Else
            STOPSALE_C.Checked = False
        End If
        If oProduct(0).sStopSupplieFlg = True Then
            STOPSUPPLIER_C.Checked = True
        Else
            STOPSUPPLIER_C.Checked = False
        End If
        If oProduct(0).sYahooFlg = True Then
            YAHOO_C.Checked = True
        Else
            YAHOO_C.Checked = False
        End If
        If oProduct(0).sRakutenFlg = True Then
            RAKUTEN_C.Checked = True
        Else
            RAKUTEN_C.Checked = False
        End If
        If oProduct(0).sAmazonFlg = True Then
            AMAZON_C.Checked = True
        Else
            AMAZON_C.Checked = False
        End If
        If oProduct(0).seShopFlg = True Then
            ORIGINAL_C.Checked = True
        Else
            ORIGINAL_C.Checked = False
        End If
        PRICE_T.Text = oProduct(0).sListPrice

        '2019.8.8 A.Komita From
        RTAX_RATE_T.Text = oProduct(0).sReducedTaxRate
        If RTAX_RATE_T.Text = String.Empty Then
            TAX_PRICE_T.Text = oTool.BeforeToTax(oProduct(0).sListPrice, oConf(0).sTax, oConf(0).sFracProc)
            BEFORETAX_PRICE_T.Text = oTool.BeforeToAfterTax(oProduct(0).sListPrice, oConf(0).sTax, oConf(0).sFracProc)
        Else
            TAX_PRICE_T.Text = oTool.BeforeToTax(oProduct(0).sListPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)
            BEFORETAX_PRICE_T.Text = oTool.BeforeToAfterTax(oProduct(0).sListPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc)
        End If
        '2019.8.8 A.Komita To


        MIN_STOCK_T.Text = oProduct(0).sMinStock

        '仕入価格情報セット
        RecordCount = oMstCostPriceDBIO.getPriceMst(oCostPrice, PRODUCT_CODE_T.Text, Nothing, oTran)
        If RecordCount > 0 Then
            For i = 0 To COST_PRICE_V.Rows.Count
                COST_PRICE_V.Rows.Clear()
            Next i

            '表示設定
            ReDim oSupplier(0)
            For i = 0 To oCostPrice.Length - 1
                oSupplierDBIO.getSupplier(oSupplier, oCostPrice(i).sSupplierCode, Nothing, oTran)

                '2019.8.8 A.Komita From
                If RTAX_RATE_T.Text = String.Empty Then
                    COST_PRICE_V.Rows.Add(
                            oSupplier(0).sSupplierName,
                            oCostPrice(i).sCostPrice,
                            oTool.BeforeToTax(oCostPrice(i).sCostPrice, oConf(0).sTax, oConf(0).sFracProc),
                            oCostPrice(i).sCostPrice + oTool.BeforeToTax(oCostPrice(i).sCostPrice, oConf(0).sTax, oConf(0).sFracProc),
                            oSupplier(0).sSupplierCode
                    )
                Else
                    COST_PRICE_V.Rows.Add(
                            oSupplier(0).sSupplierName,
                            oCostPrice(i).sCostPrice,
                            oTool.BeforeToTax(oCostPrice(i).sCostPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc),
                            oCostPrice(i).sCostPrice + oTool.BeforeToTax(oCostPrice(i).sCostPrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc),
                            oSupplier(0).sSupplierCode
                    )
                End If
                '2019.8.8 A.Komita To

            Next i
        End If

        '販売価格情報セット
        RecordCount = oMstSalePriceDBIO.getPriceMst(oSalePrice, PRODUCT_CODE_T.Text, Nothing, oTran)
        If RecordCount > 0 Then
            For i = 0 To SALE_PRICE_V.Rows.Count
                SALE_PRICE_V.Rows.Clear()
            Next i

            '表示設定
            ReDim oChannel(0)
            oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
            For i = 0 To oSalePrice.Length - 1
                oChannelDBIO.getChannelMst(oChannel, oSalePrice(i).sChannelCode, Nothing, Nothing, Nothing, oTran)

                '2019.8.8 A.Komita From
                If RTAX_RATE_T.Text = String.Empty Then
                    SALE_PRICE_V.Rows.Add(
                            oChannel(0).sChannelName,
                            oSalePrice(i).sSalePrice,
                            oTool.BeforeToTax(oSalePrice(i).sSalePrice, oConf(0).sTax, oConf(0).sFracProc),
                            oTool.BeforeToAfterTax(oSalePrice(i).sSalePrice, oConf(0).sTax, oConf(0).sFracProc),
                            oSalePrice(i).sStartDate,
                            oSalePrice(i).sEndDate,
                            oSalePrice(i).sChannelCode
                    )

                Else
                    SALE_PRICE_V.Rows.Add(
                            oChannel(0).sChannelName,
                            oSalePrice(i).sSalePrice,
                            oTool.BeforeToTax(oSalePrice(i).sSalePrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc),
                            oTool.BeforeToAfterTax(oSalePrice(i).sSalePrice, oProduct(0).sReducedTaxRate, oConf(0).sFracProc),
                            oSalePrice(i).sStartDate,
                            oSalePrice(i).sEndDate,
                            oSalePrice(i).sChannelCode
                    )

                End If
                '2019.8.8 A.Komita To

            Next i
        End If

        '----------------------------------------------------
        '2015/06/20
        '及川和彦
        'トランザクション追加
        'FROM
        '----------------------------------------------------
        RecordCount = oNetInfoDBIO.getNetInfo(oNetInfo, PRODUCT_CODE_T.Text, oTran)
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        If RecordCount > 0 Then
            PRODUCT_CODE_T.Text = oNetInfo(0).sProductCode
            DIRECTRY_ID_T.Text = oNetInfo(0).sDirectryID
            PATH_T.Text = oNetInfo(0).sPath
            META_KEYWORD_T.Text = oNetInfo(0).sMETATag
            META_DESCRIPTION_T.Text = oNetInfo(0).sMETADescription
            CATCH_COPY_T.Text = oNetInfo(0).sCatchCopy
            PRODUCT_INFO_T.Text = oNetInfo(0).sInformation
            PRODUCT_DESCRIPTION_T.Text = oNetInfo(0).sDescription
            MATERIAL_T.Text = oNetInfo(0).sMaterial
            SIZE_HEIGHT_T.Text = oNetInfo(0).sSizeHeight
            SIZE_WIDE_T.Text = oNetInfo(0).sSizeWide
            SIZE_DEPTH_T.Text = oNetInfo(0).sSizeDepth
            SIZE_NECK_T.Text = oNetInfo(0).sSizeNeck
            SIZE_BUST_T.Text = oNetInfo(0).sSizeBust
            SIZE_WAIST_T.Text = oNetInfo(0).sSizeWaist
            SIZE_LENGTH_T.Text = oNetInfo(0).sSizeLength
            RECOMMENDATION_T.Text = oNetInfo(0).sRecommendation

            '販売状況情報セット
            oSalesDBIO = New cMstSalesDBIO(oConn, oCommand, oDataReader)
            RecordCount = oSalesDBIO.getSales(oSales, PRODUCT_CODE_T.Text, oTran)

            For i = 0 To NETUP_V.Rows.Count
                NETUP_V.Rows.Clear()
            Next i

            '表示設定
            If RecordCount > 0 Then
                For i = 0 To oSales.Length - 1
                    NETUP_V.Rows.Add(
                            oSales(i).sChannelName,
                            oSales(i).sStartDate,
                            oSales(i).sEndDate
                    )
                Next i
                oSalesDBIO = Nothing
                NETUP_V.ReadOnly = True
            End If
            ' FileStream を開く
            If oNetInfo(0).sPicture1 <> "" Then
                If oNetInfo(0).sPicture1 <> "" Then
                    tPath = oTool.RegistryRead("File1") & "\Temp" & oNetInfo(0).sPicture1.Substring(
                                            oNetInfo(0).sPicture1.LastIndexOf("\"c),
                                            oNetInfo(0).sPicture1.Length - oNetInfo(0).sPicture1.LastIndexOf("\"c)
                                        )
                Else
                    tPath = ""
                End If
                'ProductPicture→Tempへファイルの移動
                System.IO.File.Copy(oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture1, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P1_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P1_PB.Text = tPath
                hStream.Close()
            End If

            If oNetInfo(0).sPicture2 <> "" Then
                If oNetInfo(0).sPicture2 <> "" Then
                    tPath = oTool.RegistryRead("File1") & "\Temp" & oNetInfo(0).sPicture2.Substring(
                                            oNetInfo(0).sPicture2.IndexOf("\"c),
                                            oNetInfo(0).sPicture2.Length - oNetInfo(0).sPicture2.IndexOf("\"c)
                                        )
                Else
                    tPath = ""
                End If
                'ProductPicture→Tempへファイルの移動
                System.IO.File.Copy(oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture2, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P2_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P2_PB.Text = tPath
                hStream.Close()
            End If

            If oNetInfo(0).sPicture3 <> "" Then
                If oNetInfo(0).sPicture3 <> "" Then
                    tPath = oTool.RegistryRead("File1") & "\Temp" & oNetInfo(0).sPicture3.Substring(
                                            oNetInfo(0).sPicture3.IndexOf("\"c),
                                            oNetInfo(0).sPicture3.Length - oNetInfo(0).sPicture3.IndexOf("\"c)
                                        )
                Else
                    tPath = ""
                End If
                'ProductPicture→Tempへファイルの移動
                System.IO.File.Copy(oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture3, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P3_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P3_PB.Text = tPath
                hStream.Close()
            End If

            If oNetInfo(0).sPicture4 <> "" Then
                If oNetInfo(0).sPicture4 <> "" Then
                    tPath = oTool.RegistryRead("File1") & "\Temp" & oNetInfo(0).sPicture4.Substring(
                                            oNetInfo(0).sPicture4.IndexOf("\"c),
                                            oNetInfo(0).sPicture4.Length - oNetInfo(0).sPicture4.IndexOf("\"c)
                                        )
                Else
                    tPath = ""
                End If
                'ProductPicture→Tempへファイルの移動
                System.IO.File.Copy(oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture4, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P4_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P4_PB.Text = tPath
                hStream.Close()
            End If

            If oNetInfo(0).sPicture5 <> "" Then
                If oNetInfo(0).sPicture5 <> "" Then
                    tPath = oTool.RegistryRead("File1") & "\Temp" & oNetInfo(0).sPicture5.Substring(
                                            oNetInfo(0).sPicture5.IndexOf("\"c),
                                            oNetInfo(0).sPicture5.Length - oNetInfo(0).sPicture5.IndexOf("\"c)
                                        )
                Else
                    tPath = ""
                End If
                'ProductPicture→Tempへファイルの移動
                System.IO.File.Copy(oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture5, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P5_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P5_PB.Text = tPath
                hStream.Close()
            End If
        End If

        '商品コードセット
        SEARCH_PRODUCT_CODE = oProduct(0).sProductCode

        'カテゴリセット
        ReDim oCategory1(0)


        RecordCount = oCategoryDBIO.getCategory1(oCategory1, PRODUCT_CODE_T.Text.Substring(0, 1), Nothing, oTran)
        SEARCH_CATEGORY_1 = oCategory1(0).sCategory1Name

        RecordCount = oCategoryDBIO.getCategory2(oCategory2, PRODUCT_CODE_T.Text.Substring(0, 1), PRODUCT_CODE_T.Text.Substring(1, 1), Nothing, oTran)
        SEARCH_CATEGORY_2 = oCategory2(0).sCategory2Name

        CATEGORY_1_L.Visible = False
        CATEGORY_1_T.Visible = True
        CATEGORY_1_T.Text = SEARCH_CATEGORY_1
        CATEGORY_ID_1_T.Text = oCategory1(0).sCategory1ID
        CATEGORY_2_L.Visible = False
        CATEGORY_2_T.Visible = True
        CATEGORY_2_T.Text = SEARCH_CATEGORY_2
        CATEGORY_ID_2_T.Text = oCategory2(0).sCategory2ID

    End Sub

    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer

        '仕入先コンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません",
                                                "仕入先マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

    End Sub


    '*************************************
    'ディレクトリー_1リストボックスセット
    '*************************************
    Private Sub DIRECTRY_1_SET()
        Dim DirectryID As String
        Dim i As Long

        'リストBOX再描画停止
        DIRECTRY_1_L.BeginUpdate()

        'ディレクトリー_1コンボ初期化
        For i = 0 To DIRECTRY_1_L.Items.Count - 1
            DIRECTRY_1_L.Items.Clear()
        Next
        DIRECTRY_1_L.Text = ""
        DIRECTRY_2_L.Text = ""
        DIRECTRY_3_L.Text = ""
        DIRECTRY_4_L.Text = ""
        DIRECTRY_5_L.Text = ""

        'ディレクトリー_1コンボ内容設定
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID

        'リストボックスへの値セット
        For i = 0 To oDirectry.Length - 1
            DIRECTRY_1_L.Items.Add(oDirectry(i).sPath1)
        Next

        'リストBOX再描画開始
        DIRECTRY_1_L.EndUpdate()
    End Sub
    '*************************************
    'ディレクトリー_2リストボックスセット
    '*************************************
    Private Sub DIRECTRY_2_SET()
        Dim DirectryID As String
        Dim i As Long

        'リストBOX再描画停止
        DIRECTRY_2_L.BeginUpdate()

        'ディレクトリー_2コンボ初期化
        For i = 0 To DIRECTRY_2_L.Items.Count - 1
            DIRECTRY_2_L.Items.Clear()
        Next
        DIRECTRY_2_L.Text = ""
        DIRECTRY_3_L.Text = ""
        DIRECTRY_4_L.Text = ""
        DIRECTRY_5_L.Text = ""

        'ディレクトリー_2内容設定
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, DIRECTRY_1_L.Text, Nothing, Nothing, Nothing, Nothing, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID

        'リストボックスへの値セット
        For i = 0 To oDirectry.Length - 1
            DIRECTRY_2_L.Items.Add(oDirectry(i).sPath2)
        Next

        'リストBOX再描画開始
        DIRECTRY_2_L.EndUpdate()

    End Sub
    '*************************************
    'ディレクトリー_3リストボックスセット
    '*************************************
    Private Sub DIRECTRY_3_SET()
        Dim DirectryID As String
        Dim i As Long

        'リストBOX再描画停止
        DIRECTRY_3_L.BeginUpdate()

        'ディレクトリー_3コンボ初期化
        For i = 0 To DIRECTRY_3_L.Items.Count - 1
            DIRECTRY_3_L.Items.Clear()
        Next
        DIRECTRY_3_L.Text = ""
        DIRECTRY_4_L.Text = ""
        DIRECTRY_5_L.Text = ""

        'ディレクトリー_3内容設定
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, DIRECTRY_1_L.Text, DIRECTRY_2_L.Text, Nothing, Nothing, Nothing, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID

        'リストボックスへの値セット
        For i = 0 To oDirectry.Length - 1
            DIRECTRY_3_L.Items.Add(oDirectry(i).sPath3)
        Next

        'リストBOX再描画開始
        DIRECTRY_3_L.EndUpdate()

    End Sub
    '*************************************
    'ディレクトリー_4リストボックスセット
    '*************************************
    Private Sub DIRECTRY_4_SET()
        Dim DirectryID As String
        Dim i As Long

        'リストBOX再描画停止
        DIRECTRY_4_L.BeginUpdate()

        'ディレクトリー_4コンボ初期化
        For i = 0 To DIRECTRY_4_L.Items.Count - 1
            DIRECTRY_4_L.Items.Clear()
        Next
        DIRECTRY_4_L.Text = ""
        DIRECTRY_5_L.Text = ""

        'ディレクトリー_4内容設定
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, DIRECTRY_1_L.Text, DIRECTRY_2_L.Text, DIRECTRY_3_L.Text, Nothing, Nothing, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID

        'リストボックスへの値セット
        For i = 0 To oDirectry.Length - 1
            DIRECTRY_4_L.Items.Add(oDirectry(i).sPath4)
        Next

        'リストBOX再描画開始
        DIRECTRY_4_L.EndUpdate()

    End Sub
    '*************************************
    'ディレクトリー_5リストボックスセット
    '*************************************
    Private Sub DIRECTRY_5_SET()
        Dim DirectryID As String
        Dim i As Long

        'リストBOX再描画停止
        DIRECTRY_5_L.BeginUpdate()

        'ディレクトリー_5コンボ初期化
        For i = 0 To DIRECTRY_5_L.Items.Count - 1
            DIRECTRY_5_L.Items.Clear()
        Next
        DIRECTRY_5_L.Text = ""

        'ディレクトリー_5内容設定
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, DIRECTRY_1_L.Text, DIRECTRY_2_L.Text, DIRECTRY_3_L.Text, DIRECTRY_4_L.Text, Nothing, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID

        'リストボックスへの値セット
        For i = 0 To oDirectry.Length - 1
            DIRECTRY_5_L.Items.Add(oDirectry(i).sPath5)
        Next

        'リストBOX再描画開始
        DIRECTRY_5_L.EndUpdate()

    End Sub
    '*************************************
    'ディレクトリー_IDセット
    '*************************************
    Private Sub DIRECTRY_ID_SET()
        Dim DirectryID As String

        'ディレクトリー_ID取得
        oDirectry = Nothing
        DirectryID = oDirectryDBIO.getDirectry(oDirectry, DIRECTRY_1_L.Text, DIRECTRY_2_L.Text, DIRECTRY_3_L.Text, DIRECTRY_4_L.Text, DIRECTRY_5_L.Text, oTran)
        If oDirectry.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oDirectry.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタが登録されていません",
                                                "ディレクトリIDマスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ディレクトリIDマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ディレクトリーIDへの値セット
        DIRECTRY_ID_T.Text = DirectryID
    End Sub

    '*************************************
    'カテゴリ1リストボックスセット
    '*************************************
    Private Sub CATEGORY_1_SET()
        Dim CATEGORYID As String
        Dim i As Long

        'リストBOX再描画停止
        CATEGORY_1_L.BeginUpdate()

        'カテゴリ1コンボ初期化
        For i = 0 To CATEGORY_1_L.Items.Count - 1
            CATEGORY_1_L.Items.Clear()
        Next

        If SEARCH_CATEGORY_1 = "" Then
            CATEGORY_1_L.Text = ""
            CATEGORY_2_L.Text = ""
        Else
            CATEGORY_1_L.Text = SEARCH_CATEGORY_1
            CATEGORY_2_L.Text = SEARCH_CATEGORY_2
        End If

        CATEGORY_1_L.Text = ""
        CATEGORY_2_L.Text = ""


        'カテゴリ1コンボ内容設定
        ReDim oCategory1(0)
        CATEGORYID = oCategoryDBIO.getCategory1(oCategory1, Nothing, Nothing, oTran)

        If oCategory1.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oCategory1.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ１マスタが登録されていません",
                                                "カテゴリ１マスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "カテゴリ１マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To oCategory1.Length - 1
            CATEGORY_1_L.Items.Add(oCategory1(i).sCategory1Name)
        Next

        'リストBOX再描画開始
        CATEGORY_1_L.EndUpdate()

    End Sub

    '*************************************
    'カテゴリ2リストボックスセット
    '*************************************
    Private Sub CATEGORY_2_SET()
        Dim CATEGORYID As String
        Dim i As Long

        'リストBOX再描画停止
        CATEGORY_2_L.BeginUpdate()

        'カテゴリ1コンボ初期化
        If CATEGORY_2_L.Items.Count > 0 Then
            For i = 0 To CATEGORY_2_L.Items.Count - 1
                CATEGORY_2_L.Items.Clear()
            Next
        End If

        If SEARCH_CATEGORY_2 = "" Then
            CATEGORY_2_L.Text = ""
        Else
            CATEGORY_2_L.Text = SEARCH_CATEGORY_2
        End If

        Dim wCategoryId As String = ""
        For i = 0 To oCategory1.Length - 1
            If oCategory1(i).sCategory1Name = CATEGORY_1_L.Text Then
                wCategoryId = oCategory1(i).sCategory1ID
            End If
        Next

        'カテゴリ1コンボ内容設定
        ReDim oCategory2(0)

        'CATEGORYID = oCategoryDBIO.getCategory2(oCategory2, CATEGORY_ID_1_T.Text, Nothing, Nothing, oTran)
        CATEGORYID = oCategoryDBIO.getCategory2(oCategory2, wCategoryId, Nothing, Nothing, oTran)



        If oCategory2.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oCategory2.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２マスタが登録されていません",
                                                "カテゴリ２マスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To oCategory2.Length - 1
            CATEGORY_2_L.Items.Add(oCategory2(i).sCategory2Name)
        Next

        'リストBOX再描画開始
        CATEGORY_2_L.EndUpdate()
    End Sub
    '*************************************
    'ネット掲載パス_1リストボックスセット
    '*************************************
    Private Sub PATH_1_SET()
        Dim PATHID As String
        Dim i As Long

        'リストBOX再描画停止
        PATH_1_L.BeginUpdate()

        'ネット掲載パス_1コンボ初期化
        For i = 0 To PATH_1_L.Items.Count - 1
            PATH_1_L.Items.Clear()
        Next
        PATH_1_L.Text = ""
        PATH_2_L.Text = ""


        'ネット掲載パス_1コンボ内容設定
        oCategory1 = Nothing
        PATHID = oCategoryDBIO.getCategory1(oCategory1, Nothing, Nothing, oTran)

        If oCategory1.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If oCategory1.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ１マスタが登録されていません",
                                                "カテゴリ１マスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "カテゴリ１マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ネット掲載パスIDへの値セット
        PATH_T.Text = ""

        'リストボックスへの値セット
        For i = 0 To oCategory1.Length - 1
            PATH_1_L.Items.Add(oCategory1(i).sCategory1Name)
        Next

        'リストBOX再描画開始
        PATH_1_L.EndUpdate()
    End Sub
    '*************************************
    'ネット掲載パス_2リストボックスセット
    '*************************************
    Private Sub PATH_2_SET()
        Dim RecordCnt As Integer
        Dim i As Long
        Dim pCategoryFull() As cStructureLib.sViewCategoryFull

        'リストBOX再描画停止
        PATH_2_L.BeginUpdate()

        'ネット掲載パス_2コンボ初期化
        For i = 0 To PATH_2_L.Items.Count - 1
            PATH_2_L.Items.Clear()
        Next
        PATH_2_L.Text = ""


        'ネット掲載パス_2内容設定
        ReDim pCategoryFull(0)
        RecordCnt = oCategoryDBIO.getCategoryFull(pCategoryFull, Nothing, PATH_1_L.Text, Nothing, Nothing, oTran)

        If pCategoryFull.Length < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If pCategoryFull.Length = 0 Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２マスタが登録されていません",
                                                "カテゴリ２マスタの更新を実行してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'ネット掲載パスIDへの値セット
        PATH_T.Text = PATH_1_L.Text

        'リストボックスへの値セット
        For i = 0 To pCategoryFull.Length - 1
            PATH_2_L.Items.Add(pCategoryFull(i).sCategory2Name)
        Next

        'リストBOX再描画開始
        PATH_2_L.EndUpdate()
        pCategoryFull = Nothing

    End Sub

    Private Sub DIRECTRY_1_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DIRECTRY_1_L.SelectedIndexChanged
        DIRECTRY_2_SET()
    End Sub

    Private Sub DIRECTRY_2_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DIRECTRY_2_L.SelectedIndexChanged
        DIRECTRY_3_SET()
    End Sub

    Private Sub DIRECTRY_3_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DIRECTRY_3_L.SelectedIndexChanged
        DIRECTRY_4_SET()
    End Sub
    Private Sub DIRECTRY_4_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DIRECTRY_4_L.SelectedIndexChanged
        DIRECTRY_5_SET()
    End Sub
    Private Sub DIRECTRY_5_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DIRECTRY_5_L.SelectedIndexChanged
        DIRECTRY_ID_SET()
    End Sub

    Private Sub PATH_1_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PATH_1_L.SelectedIndexChanged
        PATH_2_SET()
    End Sub

    Private Sub PATH_2_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PATH_2_L.SelectedIndexChanged
        PATH_T.Text = PATH_1_L.Text & "\" & PATH_2_L.Text
    End Sub

    Private Sub CATEGORY_1_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CATEGORY_1_L.SelectedIndexChanged
        Dim RecordCount As Long

        CATEGORY_2_SET()

        'カテゴリ1コンボ内容設定
        oCategory1 = Nothing
        RecordCount = oCategoryDBIO.getCategory1(oCategory1, Nothing, CATEGORY_1_L.Text, oTran)

        If RecordCount = 1 Then
            CATEGORY_ID_1_T.Text = oCategory1(0).sCategory1ID
        End If
        If SEARCH_PRODUCT_CODE = "" Then
            PRODUCT_CODE_T.Text = ""
        Else
            PRODUCT_CODE_T.Text = SEARCH_PRODUCT_CODE
        End If

    End Sub

    Private Sub CATEGORY_2_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CATEGORY_2_L.SelectedIndexChanged
        Dim RecordCount As Long

        'カテゴリ2コンボ内容設定
        oCategory2 = Nothing

        RecordCount = oCategoryDBIO.getCategory2(oCategory2, CATEGORY_ID_1_T.Text, Nothing, CATEGORY_2_L.Text, oTran)

        If RecordCount = 1 Then
            CATEGORY_ID_2_T.Text = oCategory2(0).sCategory2ID
        End If

        'If PRODUCT_CODE_T.Text = "" Then
        '----------------------------------------------------
        '2015/07/03
        '及川和彦
        '更新の時に上書きしないための判断
        'FROM
        '----------------------------------------------------
        If MODE_T.Text = "（新規）" Then
            '----------------------------------------------------
            'HERE
            '----------------------------------------------------
            '新規商品
            PRODUCT_CODE_T.Text = CREATE_PRODUCT_CODE()
        End If
    End Sub
    Private Sub PRODUCT_P1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P1_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        If PRODUCT_CODE_T.Text = "" Then

        End If

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = oTool.RegistryRead("File1") & "\Temp\" & PRODUCT_CODE_T.Text & "_1.jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            PRODUCT_P1_PB.Image = System.Drawing.Image.FromStream(hStream)
            PRODUCT_P1_PB.Text = tPath

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
    End Sub
    Private Sub PRODUCT_P2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P2_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        If PRODUCT_CODE_T.Text = "" Then

        End If

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = oTool.RegistryRead("File1") & "\Temp\" & PRODUCT_CODE_T.Text & "_2.jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            PRODUCT_P2_PB.Image = System.Drawing.Image.FromStream(hStream)
            PRODUCT_P2_PB.Text = tPath

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
    End Sub
    Private Sub PRODUCT_P3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P3_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        If PRODUCT_CODE_T.Text = "" Then

        End If

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = oTool.RegistryRead("File1") & "\Temp\" & PRODUCT_CODE_T.Text & "_3.jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            PRODUCT_P3_PB.Image = System.Drawing.Image.FromStream(hStream)
            PRODUCT_P3_PB.Text = tPath

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
    End Sub
    Private Sub PRODUCT_P4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P4_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        If PRODUCT_CODE_T.Text = "" Then

        End If

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = oTool.RegistryRead("File1") & "\Temp\" & PRODUCT_CODE_T.Text & "_4.jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            PRODUCT_P4_PB.Image = System.Drawing.Image.FromStream(hStream)
            PRODUCT_P4_PB.Text = tPath

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
    End Sub
    Private Sub PRODUCT_P5_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P5_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        If PRODUCT_CODE_T.Text = "" Then

        End If

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = oTool.RegistryRead("File1") & "\Temp\" & PRODUCT_CODE_T.Text & "_5.jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            PRODUCT_P5_PB.Image = System.Drawing.Image.FromStream(hStream)
            PRODUCT_P5_PB.Text = tPath

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
    End Sub
    Private Function GET_TAGET_PATH(ByVal sPath As String) As String
        Dim tPath As String

        tPath = "ProductPicture" & sPath.Substring(sPath.LastIndexOf("\"c), sPath.Length - sPath.LastIndexOf("\"c))
        GET_TAGET_PATH = tPath

    End Function

    '必須項目入力確認
    Private Function INPUT_CHECK() As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim sortColumn As System.Windows.Forms.DataGridViewColumn

        INPUT_CHECK = 0

        If MODE_T.Text = "（新規）" Then
            If MODE_T.BackColor = Drawing.Color.Red Then
                '商品カテゴリ(1)
                'If CATEGORY_1_L.Text = "" Then
                If CATEGORY_1_L.Text = "" And CATEGORY_1_T.Text = "" Then

                    'メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                          "商品カテゴリを選択して",
                                                          "再度登録処理を行って下さい。",
                                                          Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing

                    CATEGORY_1_L.Focus()

                    INPUT_CHECK = 1
                    Exit Function
                End If

                '商品カテゴリ(2)
                'If CATEGORY_2_L.Text = "" Then
                If CATEGORY_2_L.Text = "" And CATEGORY_2_T.Text = "" Then

                    'メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                          "商品カテゴリを選択して",
                                                          "再度登録処理を行って下さい。",
                                                          Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing

                    CATEGORY_2_L.Focus()

                    INPUT_CHECK = 1
                    Exit Function
                End If
            Else
                '商品カテゴリ(1)
                If CATEGORY_ID_1_T.Text = "" Then

                    'メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                              "商品カテゴリを選択して",
                                                              "再度登録処理を行って下さい。",
                                                              Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing

                    CATEGORY_ID_1_T.Focus()

                    INPUT_CHECK = 1
                    Exit Function
                End If

                '商品カテゴリ(2)
                If CATEGORY_ID_2_T.Text = "" Then

                    'メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                              "商品カテゴリを選択して",
                                                              "再度登録処理を行って下さい。",
                                                              Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing

                    CATEGORY_ID_2_T.Focus()

                    INPUT_CHECK = 1
                    Exit Function
                End If
            End If
        End If

        'JANコード
        If JANCODE_T.Text.ToString.Length < 3 Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "JANコード(3桁以上)を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            JANCODE_T.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        '商品名称
        If PRODUCT_NAME_T.Text = "" Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "商品名称を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            PRODUCT_NAME_T.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        '商品略称
        If PRODUCT_S_NAME_T.Text = "" Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "商品略称を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            PRODUCT_S_NAME_T.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        'メーカー名称
        If MAKER_NAME_T.Text = "" Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "メーカー名称を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            MAKER_NAME_T.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        '適正在庫数
        If MIN_STOCK_T.Text = "" Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "適正在庫数を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            MIN_STOCK_T.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        '仕入先
        If COST_PRICE_V.Rows.Count = 1 Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "仕入先を選択して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            COST_PRICE_V.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If

        '販売価格情報
        '適用開始日順にソート
        'sortColumn = SALE_PRICE_V.Columns.Item(2)
        '----------------------------------------------------
        '2015/07/03
        '及川和彦
        '適用開始日ではなく、消費税額でソートを行っていた
        'FROM
        '----------------------------------------------------
        sortColumn = SALE_PRICE_V.Columns.Item(4)
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------
        SALE_PRICE_V.Sort(sortColumn, System.ComponentModel.ListSortDirection.Ascending)
        'チャネルコード順にソート
        sortColumn = SALE_PRICE_V.Columns.Item(0)
        SALE_PRICE_V.Sort(sortColumn, System.ComponentModel.ListSortDirection.Ascending)


        If SALE_PRICE_V.Rows.Count = 1 Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                      "販売価格を入力して",
                                                      "再度登録処理を行って下さい。",
                                                      Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            SALE_PRICE_V.Focus()

            INPUT_CHECK = 1
            Exit Function
        End If
        On Error Resume Next
        'For i = 0 To SALE_PRICE_V.RowCount - 2
        '----------------------------------------------------
        '2015/07/02
        '及川和彦
        '商品登録のチャネル名称が空欄のデータが存在する際に、登録が行えない為、追加
        'FROM
        '----------------------------------------------------

        For i = SALE_PRICE_V.RowCount - 2 To 0 Step -1
            If (SALE_PRICE_V("チャネル名称", i).Value = "") Or (SALE_PRICE_V("チャネル名称", i).Value = Nothing) Then
                SALE_PRICE_V.Rows.RemoveAt(i)
                Continue For
            End If

            '----------------------------------------------------
            'HERE
            '----------------------------------------------------
            If IsNothing(SALE_PRICE_V("消費税", i).Value) = True Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません",
                                                            "消費税を入力して",
                                                            "再度登録処理を行って下さい。",
                                                          Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing

                SALE_PRICE_V.Focus()

                INPUT_CHECK = 1
                Exit Function
            End If
            If IsNothing(SALE_PRICE_V("税込価格", i).Value) = True Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, Nothing,
                                                          "販売価格を入力して下さい。",
                                                          Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing

                SALE_PRICE_V.Focus()

                INPUT_CHECK = 1
                Exit Function
            End If
            If CDate(SALE_PRICE_V("適用開始日", i).Value) > CDate(SALE_PRICE_V("適用終了日", i).Value) Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "販売価格の適用期間が不正です。",
                                                          "適用期間を確認して",
                                                          "再度登録処理を行って下さい。",
                                                          Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing

                SALE_PRICE_V.Focus()

                INPUT_CHECK = 1
                Exit Function
            End If
            If i > 0 Then
                If SALE_PRICE_V("チャネル名称", i).Value = SALE_PRICE_V("チャネル名称", i - 1).Value Then
                    If CDate(SALE_PRICE_V("適用開始日", i).Value) <= CDate(SALE_PRICE_V("適用終了日", i - 1).Value) Then
                        'メッセージウィンドウ表示
                        Message_form = New cMessageLib.fMessage(1, "販売価格の適用期間に重複があります。",
                                                                  "適用期間を確認して",
                                                                  "再度登録処理を行って下さい。",
                                                                  Nothing)
                        Message_form.ShowDialog()
                        Message_form.Dispose()
                        Message_form = Nothing

                        SALE_PRICE_V.Focus()

                        INPUT_CHECK = 1
                        Exit Function
                    End If
                End If
            End If
        Next
        ''ディレクトリID
        'If DIRECTRY_ID_T.Text = "" Then

        '    'メッセージウィンドウ表示
        '    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません", _
        '                                          "ディレクトリIDを入力して", _
        '                                          "再度登録処理を行って下さい。", _
        '                                          Nothing)
        '    Message_form.ShowDialog()
        '    Message_form.Dispose()
        '    Message_form = Nothing

        '    DIRECTRY_ID_T.Focus()

        '    INPUT_CHECK = 1
        '    Exit Function
        'End If

        ''商品キャッチコピー
        'If CATCH_COPY_T.Text = "" Then

        '    'メッセージウィンドウ表示
        '    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません", _
        '                                          "商品キャッチコピーを入力して", _
        '                                          "再度登録処理を行って下さい。", _
        '                                          Nothing)
        '    Message_form.ShowDialog()
        '    Message_form.Dispose()
        '    Message_form = Nothing

        '    CATCH_COPY_T.Focus()

        '    INPUT_CHECK = 1
        '    Exit Function
        'End If

        ''商品情報
        'If PRODUCT_INFO_T.Text = "" Then

        '    'メッセージウィンドウ表示
        '    Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません", _
        '                                          "商品情報を入力して", _
        '                                          "再度登録処理を行って下さい。", _
        '                                          Nothing)
        '    Message_form.ShowDialog()
        '    Message_form.Dispose()
        '    Message_form = Nothing

        '    PRODUCT_INFO_T.Focus()

        '    INPUT_CHECK = 1
        '    Exit Function
        'End If


        '----------------------------------------------------
        '2017/02/02
        '及川和彦
        '先頭「99」のJANコードは自動採番以外で登録できないようにする
        'FROM
        '----------------------------------------------------
        If CREATE_JANCD_B.Enabled = True Then
            If JANCODE_T.Text.ToString.Substring(0, 2) = "99" Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "JANコードが不正です。",
                                                        "JANコードを変更し",
                                                        "再度登録処理を行って下さい。",
                                                      Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing

                SALE_PRICE_V.Focus()

                INPUT_CHECK = 1
                Exit Function
            End If
        Else
            CREATE_JANCD_B.Enabled = False
        End If
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

    End Function


    '----------------------------------------------------
    '2015/07/03
    '及川和彦
    '削除ボタンを押した際に、新規モードならば、入力があるか確認
    'FROM
    '----------------------------------------------------

    '必須項目入力確認
    Private Function DELETE_INPUT_CHECK() As Integer

        DELETE_INPUT_CHECK = 0

        '商品カテゴリ(1)
        If (CATEGORY_1_L.Text <> "") Or (CATEGORY_1_L.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '商品カテゴリ(2)
        If (CATEGORY_2_L.Text <> "") Or (CATEGORY_2_L.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        'JANコード
        If (JANCODE_T.Text.ToString.Length <> "") Or (JANCODE_T.Text.ToString.Length <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '商品名称
        If (PRODUCT_NAME_T.Text <> "") Or (PRODUCT_NAME_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '商品略称
        If (PRODUCT_S_NAME_T.Text <> "") Or (PRODUCT_S_NAME_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        'メーカー名称
        If (MAKER_NAME_T.Text <> "") Or (MAKER_NAME_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '適正在庫数
        If (MIN_STOCK_T.Text <> "") Or (MIN_STOCK_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '仕入先
        If COST_PRICE_V.Rows.Count <> 1 Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        If SALE_PRICE_V.Rows.Count <> 1 Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        'ディレクトリID
        If (DIRECTRY_ID_T.Text <> "") Or (DIRECTRY_ID_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '商品キャッチコピー
        If (CATCH_COPY_T.Text <> "") Or (CATCH_COPY_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

        '商品情報
        If (PRODUCT_INFO_T.Text <> "") Or (PRODUCT_INFO_T.Text <> Nothing) Then
            DELETE_INPUT_CHECK = 1
            Exit Function
        End If

    End Function


    '----------------------------------------------------
    'HERE
    '----------------------------------------------------



    Private Sub WRITE_DATA_SET()
        Dim i As Integer

        '商品マスタ情報セット
        ReDim oProduct(0)
        oProduct(0).sProductCode = PRODUCT_CODE_T.Text
        oProduct(0).sSEQCode = Asc(PRODUCT_CODE_T.Text.ToString.Substring(0, 1)) &
                                Asc(PRODUCT_CODE_T.Text.ToString.Substring(1, 1)) &
                                PRODUCT_CODE_T.Text.ToString.Substring(2, 3)
        oProduct(0).sPLUCode = PLU_CODE_T.Text
        oProduct(0).sJANCode = JANCODE_T.Text
        If SYUBETU_1_R.Checked = True Then
            oProduct(0).sProductClass = 1
        Else
            If SYUBETU_2_R.Checked = True Then
                oProduct(0).sProductClass = 2
            Else
                oProduct(0).sProductClass = 3
            End If
        End If
        oProduct(0).sProductName = PRODUCT_NAME_T.Text
        oProduct(0).sProductShortName = PRODUCT_S_NAME_T.Text
        oProduct(0).sMakerName = MAKER_NAME_T.Text
        oProduct(0).sOption1 = OPTION1_T.Text
        oProduct(0).sOption2 = OPTION2_T.Text
        oProduct(0).sOption3 = OPTION3_T.Text
        oProduct(0).sOption4 = OPTION4_T.Text
        oProduct(0).sOption5 = OPTION5_T.Text
        oProduct(0).sMemo = MEMO_T.Text
        oProduct(0).sStopSaleFlg = STOPSALE_C.Checked
        oProduct(0).sStopSupplieFlg = STOPSUPPLIER_C.Checked
        oProduct(0).sYahooFlg = YAHOO_C.Checked
        oProduct(0).sRakutenFlg = RAKUTEN_C.Checked
        oProduct(0).sAmazonFlg = AMAZON_C.Checked
        oProduct(0).seShopFlg = ORIGINAL_C.Checked

        '2019.8.8 A.Komita From
        If RTAX_RATE_T.Text = String.Empty Then

            oProduct(0).sReducedTaxRate = String.Empty
        Else
            oProduct(0).sReducedTaxRate = RTAX_RATE_T.Text
        End If
        '2019.8.8 A.Komita To

        If PRICE_T.Text = String.Empty Then
            oProduct(0).sListPrice = 0
        Else
            oProduct(0).sListPrice = CLng(PRICE_T.Text)
        End If
        oProduct(0).sMinStock = CLng(MIN_STOCK_T.Text)
        oProduct(0).sPLUCode = PLU_CODE_T.Text

        '掲載マスタ情報セット
        ReDim oNetInfo(0)
        oNetInfo(0).sProductCode = PRODUCT_CODE_T.Text
        oNetInfo(0).sDirectryID = DIRECTRY_ID_T.Text
        oNetInfo(0).sPath = PATH_T.Text
        oNetInfo(0).sMETATag = META_KEYWORD_T.Text
        oNetInfo(0).sMETADescription = META_DESCRIPTION_T.Text
        oNetInfo(0).sCatchCopy = CATCH_COPY_T.Text
        oNetInfo(0).sInformation = PRODUCT_INFO_T.Text
        oNetInfo(0).sDescription = PRODUCT_DESCRIPTION_T.Text
        oNetInfo(0).sMaterial = MATERIAL_T.Text
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeHeight = 0
        Else
            oNetInfo(0).sSizeHeight = SIZE_HEIGHT_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeWide = 0
        Else
            oNetInfo(0).sSizeWide = SIZE_WIDE_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeDepth = 0
        Else
            oNetInfo(0).sSizeDepth = SIZE_DEPTH_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeNeck = 0
        Else
            oNetInfo(0).sSizeNeck = SIZE_NECK_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeBust = 0
        Else
            oNetInfo(0).sSizeBust = SIZE_BUST_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeWaist = 0
        Else
            oNetInfo(0).sSizeWaist = SIZE_WAIST_T.Text
        End If
        If SIZE_HEIGHT_T.Text = "" Then
            oNetInfo(0).sSizeLength = 0
        Else
            oNetInfo(0).sSizeLength = SIZE_LENGTH_T.Text
        End If
        oNetInfo(0).sRecommendation = RECOMMENDATION_T.Text
        If PRODUCT_P1_PB.Text = "" Then
            oNetInfo(0).sPicture1 = ""
        Else
            oNetInfo(0).sPicture1 = GET_TAGET_PATH(PRODUCT_P1_PB.Text)
        End If
        If PRODUCT_P2_PB.Text = "" Then
            oNetInfo(0).sPicture2 = ""
        Else
            oNetInfo(0).sPicture2 = GET_TAGET_PATH(PRODUCT_P2_PB.Text)
        End If
        If PRODUCT_P3_PB.Text = "" Then
            oNetInfo(0).sPicture3 = ""
        Else
            oNetInfo(0).sPicture3 = GET_TAGET_PATH(PRODUCT_P3_PB.Text)
        End If
        If PRODUCT_P4_PB.Text = "" Then
            oNetInfo(0).sPicture4 = ""
        Else
            oNetInfo(0).sPicture4 = GET_TAGET_PATH(PRODUCT_P4_PB.Text)
        End If
        If PRODUCT_P5_PB.Text = "" Then
            oNetInfo(0).sPicture5 = ""
        Else
            oNetInfo(0).sPicture5 = GET_TAGET_PATH(PRODUCT_P5_PB.Text)
        End If


        '----------------------------------------------------
        '2015/07/02
        '及川和彦
        '商品登録のチャネル名称、仕入先名称が空欄のデータが存在する際に、登録が行えない為、追加
        'FROM
        '----------------------------------------------------
        '仕入価格マスタ情報セット
        oCostPrice = Nothing
        For i = 0 To COST_PRICE_V.Rows.Count - 2
            If (COST_PRICE_V("仕入先名称", i).Value <> "") Or (COST_PRICE_V("仕入先名称", i).Value <> Nothing) Then
                If oCostPrice Is Nothing Then
                    ReDim oCostPrice(0)
                Else
                    ReDim Preserve oCostPrice(oCostPrice.Length)
                End If
                oCostPrice(UBound(oCostPrice)).sProductCode = PRODUCT_CODE_T.Text
                oCostPrice(UBound(oCostPrice)).sSupplierCode = CInt(COST_PRICE_V("仕入先コード", i).Value)
                oCostPrice(UBound(oCostPrice)).sCostPrice = CLng(COST_PRICE_V("仕入価格", i).Value)
            End If
        Next i

        '販売価格マスタ情報セット
        oSalePrice = Nothing
        For i = 0 To SALE_PRICE_V.Rows.Count - 2
            If (SALE_PRICE_V("チャネル名称", i).Value <> "") Or (SALE_PRICE_V("チャネル名称", i).Value <> Nothing) Then
                If oSalePrice Is Nothing Then
                    ReDim oSalePrice(0)
                Else
                    ReDim Preserve oSalePrice(oSalePrice.Length)
                End If
                oSalePrice(i).sProductCode = PRODUCT_CODE_T.Text
                oSalePrice(i).sChannelCode = CInt(SALE_PRICE_V("チャネルコード", i).Value)
                oSalePrice(i).sSalePrice = CLng(SALE_PRICE_V("販売価格", i).Value)
                oSalePrice(i).sStartDate = String.Format("{0:yyyy/MM/dd}", CDate(SALE_PRICE_V("適用開始日", i).Value))
                oSalePrice(i).sEndDate = String.Format("{0:yyyy/MM/dd}", CDate(SALE_PRICE_V("適用終了日", i).Value))
            End If
        Next i
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------


        '在庫情報セット
        ReDim oStock(0)
        oStock(0).sProductCode = PRODUCT_CODE_T.Text
        oStock(0).sStockCount = 0

    End Sub
    Private Function WRITE_PROC() As Boolean
        Dim RecordCount As Long
        Dim i As Long

        WRITE_PROC = False

        '---トランザクション開始
        If SUB_MODE = False Then
            oTran = oConn.BeginTransaction
        End If

        '---------------- 新規登録 -----------------
        If MODE_T.Text = "（新規）" Then
            '商品マスタ登録
            RecordCount = oMstProductDBIO.insertProductMst(oProduct, oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If

            'ネット掲載マスタ登録
            RecordCount = oNetInfoDBIO.insertNetInfoMst(oNetInfo(0), oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If

            '仕入売価格マスタ登録
            For i = 0 To oCostPrice.Length - 1
                RecordCount = oMstCostPriceDBIO.insertPriceMst(oCostPrice(i), oTran)
                If RecordCount = False Then
                    oTran.Rollback()
                    WRITE_PROC = False
                    Exit Function
                End If
            Next i

            '販売価格マスタ登録
            For i = 0 To oSalePrice.Length - 1
                RecordCount = oMstSalePriceDBIO.insertPriceMst(oSalePrice(i), oTran)
                If RecordCount = False Then
                    oTran.Rollback()
                    WRITE_PROC = False
                    Exit Function
                End If
            Next i

            '在庫マスタ登録
            RecordCount = oMstStockDBIO.insertStock(oStock(0), oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If
        Else
            '---------------- 更新 -----------------
            '商品マスタ更新
            RecordCount = oMstProductDBIO.updateProductMst(oProduct, oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If

            'ネット掲載マスタ更新
            RecordCount = oNetInfoDBIO.deleteNetInfoMst(PRODUCT_CODE_T.Text, oTran)
            RecordCount = oNetInfoDBIO.insertNetInfoMst(oNetInfo(0), oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If

            '販売価格マスタ更新
            RecordCount = oMstSalePriceDBIO.deletePriceMst(PRODUCT_CODE_T.Text, oTran)
            For i = 0 To oSalePrice.Length - 1
                RecordCount = oMstSalePriceDBIO.insertPriceMst(oSalePrice(i), oTran)
                If RecordCount = False Then
                    oTran.Rollback()
                    WRITE_PROC = False
                    Exit Function
                End If
            Next i

            '仕入売価格マスタ登録
            RecordCount = oMstCostPriceDBIO.deletePriceMst(PRODUCT_CODE_T.Text, oTran)
            For i = 0 To oCostPrice.Length - 1
                RecordCount = oMstCostPriceDBIO.insertPriceMst(oCostPrice(i), oTran)
                If RecordCount = False Then
                    oTran.Rollback()
                    WRITE_PROC = False
                    Exit Function
                End If
            Next i

        End If

        '----------------------------------------------------
        '2015/06/21
        '及川和彦
        'メインモード以外の場合のコミットを無効化
        'FROM
        '----------------------------------------------------
        '---トランザクション終了
        If SUB_MODE = False Then
            oTran.Commit()
        End If
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------


        WRITE_PROC = True

    End Function
    Private Sub COPY_PICTURE()

        If PRODUCT_P1_PB.Text <> "" Then
            oNetInfo(0).sPicture1 = GET_TAGET_PATH(PRODUCT_P1_PB.Text)
            'ファイルのコピー
            System.IO.File.Copy(PRODUCT_P1_PB.Text, oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture1, True)
            PRODUCT_P1_PB.Image = Nothing
            System.IO.File.Delete(PRODUCT_P1_PB.Text)
        End If

        If PRODUCT_P2_PB.Text <> "" Then
            oNetInfo(0).sPicture2 = GET_TAGET_PATH(PRODUCT_P2_PB.Text)
            'ファイルのコピー
            System.IO.File.Copy(PRODUCT_P2_PB.Text, oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture2, True)
            PRODUCT_P2_PB.Image = Nothing
            System.IO.File.Delete(PRODUCT_P2_PB.Text)
        End If

        If PRODUCT_P3_PB.Text <> "" Then
            oNetInfo(0).sPicture3 = GET_TAGET_PATH(PRODUCT_P3_PB.Text)
            'ファイルのコピー
            System.IO.File.Copy(PRODUCT_P3_PB.Text, oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture3, True)
            PRODUCT_P3_PB.Image = Nothing
            System.IO.File.Delete(PRODUCT_P3_PB.Text)
        End If

        If PRODUCT_P4_PB.Text <> "" Then
            oNetInfo(0).sPicture4 = GET_TAGET_PATH(PRODUCT_P4_PB.Text)
            'ファイルのコピー
            System.IO.File.Copy(PRODUCT_P4_PB.Text, oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture4, True)
            PRODUCT_P4_PB.Image = Nothing
            System.IO.File.Delete(PRODUCT_P4_PB.Text)
        End If

        If PRODUCT_P5_PB.Text <> "" Then
            oNetInfo(0).sPicture5 = GET_TAGET_PATH(PRODUCT_P5_PB.Text)
            'ファイルのコピー
            System.IO.File.Copy(PRODUCT_P5_PB.Text, oTool.RegistryRead("File1") & "\" & oNetInfo(0).sPicture5, True)
            PRODUCT_P5_PB.Image = Nothing
            System.IO.File.Delete(PRODUCT_P5_PB.Text)
        End If

    End Sub

    Private Sub PRODUCT_P1_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P1_CLR_B.Click
        PRODUCT_P1_PB.Image = Nothing
        PRODUCT_P1_PB.Text = ""
    End Sub

    Private Sub PRODUCT_P2_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P2_CLR_B.Click
        PRODUCT_P2_PB.Image = Nothing
        PRODUCT_P2_PB.Text = ""
    End Sub

    Private Sub PRODUCT_P3_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P3_CLR_B.Click
        PRODUCT_P3_PB.Image = Nothing
        PRODUCT_P3_PB.Text = ""
    End Sub

    Private Sub PRODUCT_P4_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P4_CLR_B.Click
        PRODUCT_P4_PB.Image = Nothing
        PRODUCT_P4_PB.Text = ""
    End Sub

    Private Sub PRODUCT_P5_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_P5_CLR_B.Click
        PRODUCT_P5_PB.Image = Nothing
        PRODUCT_P5_PB.Text = ""
    End Sub
    Private Function CREATE_PRODUCT_CODE() As String
        Dim KeyCategory As String
        Dim KeyProductCode As String
        Dim productPrefix As String


        KeyProductCode = oMstProductDBIO.read_Same_PrdMstCode(PRODUCT_NAME_T.Text, CATEGORY_ID_1_T.Text & CATEGORY_ID_2_T.Text, Nothing)
        If KeyProductCode = Nothing Then
            KeyCategory = CATEGORY_ID_1_T.Text & CATEGORY_ID_2_T.Text
            KeyProductCode = oMstProductDBIO.readMaxPrdMstCode(KeyCategory, Nothing)
            If KeyProductCode = Nothing Then
                KeyProductCode = CATEGORY_ID_1_T.Text & CATEGORY_ID_2_T.Text & "000-01"
                CREATE_PRODUCT_CODE = KeyProductCode.Substring(0, 2) & String.Format("{0:000}", CInt(KeyProductCode.Substring(2, 3)) + 1) & "-01"
            Else
                If KeyProductCode.Substring(2, 3) = "999" Then
                    CREATE_PRODUCT_CODE = oMstProductDBIO.read_UnUse_PrdMstCode(KeyCategory, Nothing) & "-01"
                Else
                    CREATE_PRODUCT_CODE = KeyProductCode.Substring(0, 2) & String.Format("{0:000}", CInt(KeyProductCode.Substring(2, 3)) + 1) & "-01"
                End If
            End If
        Else
            If KeyProductCode = "-1" Then
                CREATE_PRODUCT_CODE = -1
            Else
                'CREATE_PRODUCT_CODE = KeyProductCode.Substring(0, 6) & String.Format("{0:00}", CInt(KeyProductCode.Substring(6, 2)) + 1)

                '----------------------------------------------------
                '2015/06/27
                '及川和彦
                '商品マスタ登録を行う際に、カテゴリ1、カテゴリ2、商品名称で商品番号を決定する
                '新規登録の商品名称を完全に含む商品がマスタに存在する際に、該当する商品の内、
                '最大の商品番号の上3桁の数字に1を足した商品番号を用いることになるが、
                '稀に該当の商品番号が使用されていることがある
                'その際にエラーとなるので、回避する為に追加
                'FROM
                '----------------------------------------------------
                productPrefix = KeyProductCode.Substring(0, 5)
                KeyProductCode = oMstProductDBIO.readPrdMstCode(productPrefix, oProduct, Nothing)
                CREATE_PRODUCT_CODE = oTool.GetKeyProduct(productPrefix, oProduct)
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------


            End If
        End If
    End Function
    Private Sub OPTION_SET()
        If oConf(0).sOptionName1 <> "" Then
            OPTION1_L.Text = oConf(0).sOptionName1 & "："
        Else
            OPTION1_L.Text = "-----："
            OPTION1_T.Enabled = False
        End If
        If oConf(0).sOptionName2 <> "" Then
            OPTION2_L.Text = oConf(0).sOptionName2 & "："
        Else
            OPTION2_L.Text = "-----："
            OPTION2_T.Enabled = False
        End If
        If oConf(0).sOptionName3 <> "" Then
            OPTION3_L.Text = oConf(0).sOptionName3 & "："
        Else
            OPTION3_L.Text = "-----："
            OPTION3_T.Enabled = False
        End If
        If oConf(0).sOptionName4 <> "" Then
            OPTION4_L.Text = oConf(0).sOptionName4 & "："
        Else
            OPTION4_L.Text = "-----："
            OPTION4_T.Enabled = False
        End If
        If oConf(0).sOptionName5 <> "" Then
            OPTION5_L.Text = oConf(0).sOptionName5 & "："
        Else
            OPTION5_L.Text = "-----："
            OPTION5_T.Enabled = False
        End If
    End Sub

    Private Sub SALE_PRICE_V_CellValueChanged(ByVal sender As Object, ByVal e As Windows.Forms.DataGridViewCellEventArgs) Handles SALE_PRICE_V.CellValueChanged
        Dim RecordCount As Long

        If IVENT_FLG = True Then
            IVENT_FLG = False
            If SALE_PRICE_V("チャネル名称", e.RowIndex).Value = "" Then
                SALE_PRICE_V.Rows.RemoveAt(e.RowIndex)
            Else
                Select Case e.ColumnIndex
                    Case 0  'チャネル名称変更
                        'チャネルが変更された際に隠しチャネルコードカラムにチャネルコードをセット
                        ReDim oChannel(0)
                        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, SALE_PRICE_V("チャネル名称", e.RowIndex).Value, True, oTran)

                        SALE_PRICE_V("チャネルコード", e.RowIndex).Value = oChannel(0).sChannelCode

                        If PRICE_T.Text <> "" Then
                            '税抜仕入価格セット
                            SALE_PRICE_V("販売価格", e.RowIndex).Value = CLng(PRICE_T.Text)

                            If RTAX_RATE_T.Text = String.Empty Then
                                SALE_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(PRICE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                            Else
                                SALE_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(PRICE_T.Text), CInt(RTAX_RATE_T.Text), oConf(0).sFracProc)
                            End If

                            '税込価格セット
                            SALE_PRICE_V("税込価格", e.RowIndex).Value = CLng(SALE_PRICE_V("販売価格", e.RowIndex).Value) + CLng(SALE_PRICE_V("消費税", e.RowIndex).Value)
                        Else
                            '税抜仕入価格セット
                            SALE_PRICE_V("販売価格", e.RowIndex).Value = 0
                            '消費税セット
                            SALE_PRICE_V("消費税", e.RowIndex).Value = 0
                            '税込価格セット
                            SALE_PRICE_V("税込価格", e.RowIndex).Value = 0
                        End If

                        '登録日時のセット
                        SALE_PRICE_V("適用開始日", e.RowIndex).Value = String.Format("{0:yyyy/MM/dd}", Now)
                        SALE_PRICE_V("適用終了日", e.RowIndex).Value = String.Format("{0:yyyy/MM/dd}", CDate("2099/12/31"))


                    Case 1  '販売価格変更
                        '----------------------------------------------------
                        '2015/07/03
                        '及川和彦
                        '販売価格に数値以外が入力された際に0に変更する
                        'FROM
                        '----------------------------------------------------
                        If IsNumeric(SALE_PRICE_V("販売価格", e.RowIndex).Value) = False Then
                            SALE_PRICE_V("販売価格", e.RowIndex).Value = 0
                        End If
                        '----------------------------------------------------
                        'HERE
                        '----------------------------------------------------

                        '2019.8.8 A.Komita From
                        If RTAX_RATE_T.Text = String.Empty Then
                            SALE_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(SALE_PRICE_V("販売価格", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            SALE_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(SALE_PRICE_V("販売価格", e.RowIndex).Value), RTAX_RATE_T.Text, oConf(0).sFracProc)
                        End If
                        '2019.8.8 A.Komita To
                        SALE_PRICE_V("税込価格", e.RowIndex).Value = CLng(SALE_PRICE_V("販売価格", e.RowIndex).Value) + CLng(SALE_PRICE_V("消費税", e.RowIndex).Value)

                    Case 3  '税込価格変更
                        '----------------------------------------------------
                        '2015/07/03
                        '及川和彦
                        '税込価格に数値以外が入力された際に0に変更する
                        'FROM
                        '----------------------------------------------------
                        If IsNumeric(SALE_PRICE_V("税込価格", e.RowIndex).Value) = False Then
                            SALE_PRICE_V("税込価格", e.RowIndex).Value = 0
                        End If
                        '----------------------------------------------------
                        'HERE
                        '----------------------------------------------------

                        '2019.8.8 A.Komita From
                        If RTAX_RATE_T.Text = String.Empty Then
                            SALE_PRICE_V("販売価格", e.RowIndex).Value = oTool.AfterToBeforeTax(CLng(SALE_PRICE_V("税込価格", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            SALE_PRICE_V("販売価格", e.RowIndex).Value = oTool.AfterToBeforeTax(CLng(SALE_PRICE_V("税込価格", e.RowIndex).Value), CInt(RTAX_RATE_T.Text), oConf(0).sFracProc)
                        End If
                        '2019.8.8 A.Komita To

                        SALE_PRICE_V("消費税", e.RowIndex).Value = CLng(SALE_PRICE_V("税込価格", e.RowIndex).Value) - CLng(SALE_PRICE_V("販売価格", e.RowIndex).Value)

                End Select
            End If
            IVENT_FLG = True
        End If
    End Sub

    Private Sub COST_PRICE_V_CellValueChanged(ByVal sender As Object, ByVal e As Windows.Forms.DataGridViewCellEventArgs) Handles COST_PRICE_V.CellValueChanged
        Dim oSupplier() As cStructureLib.sSupplier
        Dim oSupplierDBIO As cMstSupplierDBIO
        Dim RecordCount As Long

        If COST_PRICE_V("仕入先名称", e.RowIndex).Value = "" Then
            COST_PRICE_V.Rows.RemoveAt(e.RowIndex)
        Else
            If IVENT_FLG = True Then

                IVENT_FLG = False

                Select Case e.ColumnIndex
                    Case 0  '仕入先変更
                        'チャネルが変更された際に隠しチャネルコードカラムにチャネルコードをセット
                        ReDim oSupplier(0)
                        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
                        RecordCount = oSupplierDBIO.getSupplier(oSupplier, Nothing, COST_PRICE_V("仕入先名称", e.RowIndex).Value, oTran)
                        COST_PRICE_V("仕入先コード", e.RowIndex).Value = oSupplier(0).sSupplierCode

                        oSupplierDBIO = Nothing

                    Case 1  '仕入価格変更
                        '2019.8.8 A.Komita From
                        If RTAX_RATE_T.Text = String.Empty Then
                            COST_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(COST_PRICE_V("仕入価格", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            COST_PRICE_V("消費税", e.RowIndex).Value = oTool.BeforeToTax(CLng(COST_PRICE_V("仕入価格", e.RowIndex).Value), RTAX_RATE_T.Text, oConf(0).sFracProc)
                        End If
                        '2019.8.8 A.Komita To
                        COST_PRICE_V("税込価格", e.RowIndex).Value = CLng(COST_PRICE_V("仕入価格", e.RowIndex).Value) + CLng(COST_PRICE_V("消費税", e.RowIndex).Value)

                    Case 2  '消費税
                        '2019.8.8 A.Komita From
                        If RTAX_RATE_T.Text = String.Empty Then
                            COST_PRICE_V("仕入価格", e.RowIndex).Value = oTool.TaxToBeforeTax(CLng(COST_PRICE_V("消費税", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            COST_PRICE_V("仕入価格", e.RowIndex).Value = oTool.TaxToBeforeTax(CLng(COST_PRICE_V("消費税", e.RowIndex).Value), CInt(RTAX_RATE_T.Text), oConf(0).sFracProc)
                        End If
                        '2019.8.8 A.Komita To
                        COST_PRICE_V("税込価格", e.RowIndex).Value = CLng(COST_PRICE_V("仕入価格", e.RowIndex).Value) + CLng(COST_PRICE_V("消費税", e.RowIndex).Value)

                    Case 3  '税込価格
                        '2019.8.8 A.Komita From
                        If RTAX_RATE_T.Text = String.Empty Then
                            COST_PRICE_V("仕入価格", e.RowIndex).Value = oTool.AfterToBeforeTax(CLng(COST_PRICE_V("税込価格", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        Else
                            COST_PRICE_V("仕入価格", e.RowIndex).Value = oTool.AfterToBeforeTax(CLng(COST_PRICE_V("税込価格", e.RowIndex).Value), CInt(RTAX_RATE_T.Text), oConf(0).sFracProc)
                        End If
                        '2019.8.8 A.Komita To
                        COST_PRICE_V("消費税", e.RowIndex).Value = CLng(COST_PRICE_V("税込価格", e.RowIndex).Value) - CLng(COST_PRICE_V("仕入価格", e.RowIndex).Value)

                End Select
                IVENT_FLG = True
            End If
        End If

    End Sub

    '2019,10,17 A.Komita 適用開始日欄に、決まった形 (日付) 以外で入力が行える状態を防ぐ為追加 From
    Private Sub SALE_PRICE_V_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles SALE_PRICE_V.LostFocus

        For i = 0 To SALE_PRICE_V.Rows.Count - 2

            If SALE_PRICE_V("適用開始日", i).Value <> String.Format("{0:yyyy/MM/dd}", CDate(SALE_PRICE_V("適用開始日", i).Value)) Then

                SALE_PRICE_V("適用開始日", i).Value = String.Format("{0:yyyy/MM/dd}", CDate(SALE_PRICE_V("適用開始日", i).Value))

            End If
        Next
    End Sub
    '2019,10,17 A.Komita 追加 To

    Private Sub PRICE_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles PRICE_T.LostFocus
        '2019.12.10 R.Takashima FROM
        '定価欄が空白の場合にフォーカスを失うとキャストエラーになるため修正
        '定価が空白の場合は処理を行わない
        If PRICE_T.Text <> String.Empty Then

            '2019.8.8 A.Komita From
            If RTAX_RATE_T.Text = String.Empty Then
                TAX_PRICE_T.Text = oTool.BeforeToTax(CLng(PRICE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            Else
                TAX_PRICE_T.Text = oTool.BeforeToTax(CLng(PRICE_T.Text), RTAX_RATE_T.Text, oConf(0).sFracProc)
            End If
            '2019.8.8 A.Komita To

            BEFORETAX_PRICE_T.Text = CLng(PRICE_T.Text) + CLng(TAX_PRICE_T.Text)
        End If

        '2019.12.10 R.Takashima TO

    End Sub

    '2019.8.9 A.Komita From
    Private Sub RTAX_RATE_T_LostFocus(sender As Object, e As EventArgs) Handles RTAX_RATE_T.LostFocus
        '2019.12.10 R.Takashima FROM
        '定価欄が空白の場合にフォーカスを失うとキャストエラーになるため修正
        '定価が空白の場合は処理を行わない
        If PRICE_T.Text <> String.Empty Then


            If RTAX_RATE_T.Text = String.Empty Then
                TAX_PRICE_T.Text = oTool.BeforeToTax(CLng(PRICE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            Else
                TAX_PRICE_T.Text = oTool.BeforeToTax(CLng(PRICE_T.Text), RTAX_RATE_T.Text, oConf(0).sFracProc)
            End If
            BEFORETAX_PRICE_T.Text = CLng(PRICE_T.Text) + CLng(TAX_PRICE_T.Text)

            '2019.8.14 A.Komita From
            For i = 0 To COST_PRICE_V.Rows.Count - 2

                If RTAX_RATE_T.Text = String.Empty Then
                    COST_PRICE_V("消費税", i).Value = oTool.BeforeToTax(CLng(COST_PRICE_V("仕入価格", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                Else
                    COST_PRICE_V("消費税", i).Value = oTool.BeforeToTax(CLng(COST_PRICE_V("仕入価格", i).Value), RTAX_RATE_T.Text, oConf(0).sFracProc)
                End If
            Next

            For x = 0 To SALE_PRICE_V.Rows.Count - 2
                If RTAX_RATE_T.Text = String.Empty Then
                    SALE_PRICE_V("消費税", x).Value = oTool.BeforeToTax(CLng(SALE_PRICE_V("販売価格", x).Value), oConf(0).sTax, oConf(0).sFracProc)
                Else
                    SALE_PRICE_V("消費税", x).Value = oTool.BeforeToTax(CLng(SALE_PRICE_V("販売価格", x).Value), RTAX_RATE_T.Text, oConf(0).sFracProc)
                End If
                '2019.8.15 A.Komita From
                SALE_PRICE_V("税込価格", x).Value = CLng(SALE_PRICE_V("販売価格", x).Value) + CLng(SALE_PRICE_V("消費税", x).Value)
                '2019.8.15 A.Komita To
            Next
            '2019.8.14 A.Komita To

        End If
        '2019.12.10 R.Takashima TO
    End Sub
    '2019.8.9 A.Komita To

    Private Sub CREATE_JANCD_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CREATE_JANCD_B.Click
        Dim KeyJANCode As String

        KeyJANCode = oMstProductDBIO.readMaxJANCode(oTran)
        If KeyJANCode = Nothing Then
            KeyJANCode = "999" & String.Format("{0:000000000}", 1)
        Else
            KeyJANCode = "999" & String.Format("{0:000000000}", CLng(KeyJANCode.Substring(3, 9)) + 1)
        End If
        JANCODE_T.Text = oTool.JANCD(KeyJANCode)

        '2017.02.02 K.Oikawa
        '自動採番以外で先頭「99」のJANコードが入力されないようにする
        CREATE_JANCD_B.Enabled = False

    End Sub

    Private Sub MAKER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAKER_SEARCH_B.Click
        Dim fMakerSearch_form As cSelectLib.fMakerSearch

        fMakerSearch_form = New cSelectLib.fMakerSearch(oConn, oCommand, oDataReader, MAKER_NAME_T, oTran)
        fMakerSearch_form.ShowDialog()
        fMakerSearch_form = Nothing

    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        'スタッフ入力ウィンドウ表示
        Dim product_search_form As cSelectLib.fProductSearch

        If IsNothing(oTran) = False Then
            oTran = Nothing
        End If
        product_search_form = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, Nothing, oTran)
        product_search_form.ShowDialog()
        If product_search_form.DialogResult = Windows.Forms.DialogResult.OK Then
            PRODUCT_CODE_T.Text = product_search_form.S_PRODUCT_CODE_T.Text
            UPDATE_PRODUCT_SET()
            PRODUCT_CODE_T.ReadOnly = True
            CATEGORY_1_L.Enabled = False
            CATEGORY_2_L.Enabled = False

            '2017.02.02 K.Oikawa
            '自動採番が2回されることがあるか確認

            '2017.09.27 Y.Sato 削除 From
            'If product_search_form.S_JAN_CODE_T.Text.ToString.Substring(0, 2) = "99" Then
            '   CREATE_JANCD_B.Enabled = True
            'End If
            '2017.09.27 Y.Sato 削除 To

            '2017.09.27 Y.Sato 追加 From
            If JANCODE_T.Text.Length > 2 Then
                If JANCODE_T.Text.ToString.Substring(0, 2) = "99" Then
                    CREATE_JANCD_B.Enabled = False
                Else
                    CREATE_JANCD_B.Enabled = True
                End If
            Else
                CREATE_JANCD_B.Enabled = True
            End If
            '2017.09.27 Y.Sato 追加 To


        End If
        product_search_form = Nothing
    End Sub

    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage


        '----------------------------------------------------
        '2015/07/02
        '及川和彦
        '入庫処理画面から商品マスタの仕入れ価格を変更した際に、登録が行われたか判断するため、追加
        'FROM
        '----------------------------------------------------
        Message_form = New cMessageLib.fMessage(2, "現在の商品情報は破棄されます",
                                                "よろしいですか？",
                                                Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form.Dispose()
            Message_form = Nothing
            Exit Sub
        End If
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        '2016.05.18 K.Oikawa s
        '課代表.No92 トランザクションが２重に実行される場合が存在する
        'oTran = oConn.BeginTransaction()
        If oTran Is Nothing Then
            oTran = oConn.BeginTransaction()
        End If
        '2016.05.18 K.Oikawa e

        '商品マスタ削除
        ret = oMstProductDBIO.deleteProduct(PRODUCT_CODE_T.Text, oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "商品マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            oTran.Rollback()
            Exit Sub
        End If
        '販売価格マスタ削除
        ret = oMstSalePriceDBIO.deletePriceMst(PRODUCT_CODE_T.Text, oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "価格マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            oTran.Rollback()
            Exit Sub
        End If

        '在庫マスタ削除
        ret = oMstStockDBIO.deleteStock(PRODUCT_CODE_T.Text, oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "在庫マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            oTran.Rollback()
            Exit Sub
        End If




        '----------------------------------------------------
        '2015/06/27
        '及川和彦
        '削除する際に、仕入価格マスタとネット掲載マスタが削除されていないため、追加
        'FROM
        '----------------------------------------------------

        '仕入価格マスタ削除
        ret = oMstCostPriceDBIO.deletePriceMst(PRODUCT_CODE_T.Text, oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "仕入価格マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            oTran.Rollback()
            Exit Sub
        End If

        'ネット掲載マスタ削除
        ret = oNetInfoDBIO.deleteNetInfoMst(PRODUCT_CODE_T.Text, oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "ネット掲載マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            oTran.Rollback()
            Exit Sub
        End If



        '----------------------------------------------------
        'HERE
        '----------------------------------------------------




        oTran.Commit()

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(1, "削除が完了しました。", "新規モードに移行します。", Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form.Dispose()
        Message_form = Nothing

        INIT_PROC()

        MODE_T.Text = "（新規）"
        '2016.05.16 K.Oikawa s
        '課代表.No17 削除で色が戻っていないため追加
        MODE_T.BackColor = Drawing.Color.Red
        '2016.05.16 K.Oikawa e
        If PRODUCT_CODE <> Nothing Then
            Me.Close()
            Me.Dispose()
        End If

        CATEGORY_1_L.Focus()

    End Sub

    Private Sub COPY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COPY_B.Click
        Dim ret As Boolean
        Dim sPath As String
        Dim tPath As String
        Dim Message_form As cMessageLib.fMessage

        '必須入力確認
        ret = INPUT_CHECK()
        If ret <> 0 Then
            Exit Sub
        End If

        '登録データのバッファセット
        WRITE_DATA_SET()

        'DB登録処理
        ret = WRITE_PROC()
        If ret = True Then
            MODE_T.Text = "（新規）"
            '2016.05.16 K.Oikawa s
            '課代表.No17 コピー登録時に色が戻っていないため追加
            MODE_T.BackColor = Drawing.Color.Red

            '2016.05.16 K.Oikawa e
            CATEGORY_1_L.Enabled = True
            CATEGORY_2_L.Enabled = True

            '画像ファールのコピー
            COPY_PICTURE()

            '新規商品
            PRODUCT_CODE_T.Text = CREATE_PRODUCT_CODE()

            ' FileStream を開く
            If PRODUCT_P1_PB.Text <> "" Then
                tPath = "Temp\" & PRODUCT_CODE_T.Text & ".jpg"
                sPath = "ProductPicture" & PRODUCT_P1_PB.Text.Substring(
                                        PRODUCT_P1_PB.Text.LastIndexOf("\"c),
                                        PRODUCT_P1_PB.Text.Length - PRODUCT_P1_PB.Text.LastIndexOf("\"c)
                                    )
                'Temp→ProductPictureへファイルの移動
                System.IO.File.Copy(sPath, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P1_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P1_PB.Text = tPath
                hStream.Close()
            Else
                PRODUCT_P1_PB.Image = Nothing
            End If

            If PRODUCT_P2_PB.Text <> "" Then
                tPath = "Temp\" & PRODUCT_CODE_T.Text & "_2.jpg"
                sPath = "ProductPicture" & PRODUCT_P2_PB.Text.Substring(
                                        PRODUCT_P2_PB.Text.LastIndexOf("\"c),
                                        PRODUCT_P2_PB.Text.Length - PRODUCT_P2_PB.Text.LastIndexOf("\"c)
                                    )
                'Temp→ProductPictureへファイルの移動
                System.IO.File.Copy(sPath, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P2_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P2_PB.Text = tPath
                hStream.Close()
            Else
                PRODUCT_P2_PB.Image = Nothing
            End If

            If PRODUCT_P3_PB.Text <> "" Then
                tPath = "Temp\" & PRODUCT_CODE_T.Text & "_3.jpg"
                sPath = "ProductPicture" & PRODUCT_P3_PB.Text.Substring(
                                        PRODUCT_P3_PB.Text.LastIndexOf("\"c),
                                        PRODUCT_P3_PB.Text.Length - PRODUCT_P3_PB.Text.LastIndexOf("\"c)
                                    )
                'Temp→ProductPictureへファイルの移動
                System.IO.File.Copy(sPath, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P3_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P3_PB.Text = tPath
                hStream.Close()
            Else
                PRODUCT_P3_PB.Image = Nothing
            End If

            If PRODUCT_P4_PB.Text <> "" Then
                tPath = "Temp\" & PRODUCT_CODE_T.Text & "_4.jpg"
                sPath = "ProductPicture" & PRODUCT_P4_PB.Text.Substring(
                                        PRODUCT_P4_PB.Text.LastIndexOf("\"c),
                                        PRODUCT_P4_PB.Text.Length - PRODUCT_P4_PB.Text.LastIndexOf("\"c)
                                    )
                'Temp→ProductPictureへファイルの移動
                System.IO.File.Copy(sPath, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P4_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P4_PB.Text = tPath
                hStream.Close()
            Else
                PRODUCT_P4_PB.Image = Nothing
            End If

            If PRODUCT_P5_PB.Text <> "" Then
                tPath = "Temp\" & PRODUCT_CODE_T.Text & "_5.jpg"
                sPath = "ProductPicture" & PRODUCT_P5_PB.Text.Substring(
                                        PRODUCT_P5_PB.Text.LastIndexOf("\"c),
                                        PRODUCT_P5_PB.Text.Length - PRODUCT_P5_PB.Text.LastIndexOf("\"c)
                                    )
                'Temp→ProductPictureへファイルの移動
                System.IO.File.Copy(sPath, tPath, True)

                ' FileStream から画像を読み込んで表示
                Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)
                PRODUCT_P5_PB.Image = System.Drawing.Image.FromStream(hStream)
                PRODUCT_P5_PB.Text = tPath
                hStream.Close()
            Else
                PRODUCT_P5_PB.Image = Nothing
            End If

            '一時保存メッセージの追加
            'Message_form = New cMessageLib.fMessage(1, "登録が完了しました。", "新規モードに移行します。", Nothing, Nothing)

            If SUB_MODE = True Then
                Message_form = New cMessageLib.fMessage(1, "一時保存が完了しました。", "作業が中断された場合には登録れません。", Nothing, Nothing)
            Else
                Message_form = New cMessageLib.fMessage(1, "登録が完了しました。", "新規モードに移行します。", Nothing, Nothing)
            End If

            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            MODE_T.Text = "（新規）"

            PRODUCT_CODE_T.Text = CREATE_PRODUCT_CODE()
            JANCODE_T.Text = ""
        Else
            Message_form = New cMessageLib.fMessage(1, "登録が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

        End If

        PRODUCT_CODE_T.Text = CREATE_PRODUCT_CODE()

        '2017.09.27 Y.Sato 追加 From
        JANCODE_T.Text = ""
        CREATE_JANCD_B.Enabled = True
        '2017.09.27 Y.Sato 追加 To



    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage

        '必須入力確認
        ret = INPUT_CHECK()
        If ret <> 0 Then
            Exit Sub
        End If

        If MODE_T.Text = "（新規）" And PRODUCT_CODE_T.Text = "" Then
            PRODUCT_CODE_T.Text = CREATE_PRODUCT_CODE()
        End If

        '登録データのバッファセット
        WRITE_DATA_SET()

        'DB登録処理
        ret = WRITE_PROC()
        If ret = True Then
            '画像ファールのコピー
            COPY_PICTURE()
            INIT_PROC()

            '一時保存メッセージ追加
            'メッセージウィンドウ表示
            'Message_form = New cMessageLib.fMessage(1, "登録が完了しました。", "新規モードに移行します。", Nothing, Nothing)

            If SUB_MODE = True Then
                Message_form = New cMessageLib.fMessage(1, "一時保存が完了しました。", "作業が中断された場合には登録れません。", Nothing, Nothing)
            Else
                Message_form = New cMessageLib.fMessage(1, "登録が完了しました。", "新規モードに移行します。", Nothing, Nothing)
            End If

            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

            MODE_T.Text = "（新規）"
            MODE_T.BackColor = Drawing.Color.Red

            If PRODUCT_CODE <> Nothing Then

                '----------------------------------------------------
                '2015/06/27
                '及川和彦
                '入庫処理画面から商品マスタの仕入れ価格を変更した際に、登録が行われたか判断するため、追加
                'FROM
                '----------------------------------------------------
                DialogResult = Windows.Forms.DialogResult.Yes
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------
                Me.Close()
                Me.Dispose()
            End If

            CATEGORY_1_L.Focus()

            CATEGORY_1_L.Enabled = True
            CATEGORY_2_L.Enabled = True

        Else
            Message_form = New cMessageLib.fMessage(1, "登録が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing

        End If

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click

        '----------------------------------------------------
        '2015/07/02
        '及川和彦
        '入庫処理画面から商品マスタの仕入れ価格を変更した際に、登録が行われたか判断するため、追加
        'FROM
        '----------------------------------------------------
        Dim Message_form As cMessageLib.fMessage
        Message_form = New cMessageLib.fMessage(2, "現在の変更は破棄されます",
                                                "よろしいですか？",
                                                Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            oConn = Nothing
            'oStaffDBIO = Nothing
            oSupplierDBIO = Nothing
            oMstProductDBIO = Nothing
            oMstConfigDBIO = Nothing
            oTool = Nothing
            oChannelDBIO = Nothing

            Me.DialogResult = Windows.Forms.DialogResult.No
            Me.Dispose()
        End If
        Message_form = Nothing

        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

    End Sub

    Private Sub IN_DIRECTRY_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IN_DIRECTRY_B.Click
        Dim sPath As String
        Dim tPath As String
        Dim RecordCount As Long
        Dim st_buff As String
        Dim i_fnum As Integer
        Dim splitString() As String
        Dim i As Long
        Dim j As Integer
        Dim cnt As Integer
        Dim FileRowCnt As Long
        'インポートファイルをテンポラリーにコピー
        sPath = oTool.FileSearch("ファイル選択", Nothing)
        tPath = "Temp\DirectryID.csv"

        If sPath <> "" Then

            'ファイルのコピー
            File.Copy(sPath, tPath, True)
            File.SetAttributes(tPath, FileAttributes.Normal)

        End If

        ' テキストファイルの読み込み
        i_fnum = FreeFile()
        FileOpen(i_fnum, tPath, OpenMode.Input)

        'テキストファイルレコード数取得
        FileRowCnt = 0
        Do While Not EOF(i_fnum)
            st_buff = LineInput(i_fnum)
            If FileRowCnt = 0 Then
                If st_buff <> "ディレクトリID, パス名 " Then
                    Dim Message_form As cMessageLib.fMessage
                    Message_form = New cMessageLib.fMessage(1, "指定されたファイルは",
                                                    "ディレクトリIDファイルではありません",
                                                    "再度ファイルを指定して下さい。",
                                                    Nothing)

                    Message_form.ShowDialog()
                    Message_form = Nothing
                    FileClose(i_fnum)
                    Exit Sub
                End If
            End If
            FileRowCnt = FileRowCnt + 1
        Loop
        FileClose(i_fnum)

        'メッセージウィンドウ表示
        Dim ProgressMessage_form As cMessageLib.fProgressMessage

        ProgressMessage_form = New cMessageLib.fProgressMessage(0, "データインポート中", "しばらくお待ちください")
        ProgressMessage_form.Show()
        Windows.Forms.Application.DoEvents()

        'ディレクトリーIDマスタの初期化
        RecordCount = oDirectryDBIO.deleteDirectryMst(oTran)

        'インポート処理
        i = 0
        FileOpen(i_fnum, tPath, OpenMode.Input)
        ProgressMessage_form.ProgressBar.Value = 10
        Windows.Forms.Application.DoEvents()
        Do While Not EOF(i_fnum)
            st_buff = LineInput(i_fnum)
            If i > 0 Then
                st_buff = st_buff.Replace(">", ",")

                splitString = st_buff.Split(",")
                cnt = splitString.Length
                If cnt < 6 Then
                    ReDim Preserve splitString(5)
                    For j = cnt To 6 - 1
                        splitString(j) = ""
                    Next j
                End If
                oDirectry(0).sDirectryID = splitString(0).ToString
                oDirectry(0).sPath1 = splitString(1).ToString
                oDirectry(0).sPath2 = splitString(2).ToString
                oDirectry(0).sPath3 = splitString(3).ToString
                oDirectry(0).sPath4 = splitString(4).ToString
                oDirectry(0).sPath5 = splitString(5).ToString
                RecordCount = oDirectryDBIO.insertDirectryMst(oDirectry, oTran)
            End If
            i = i + 1
            ProgressMessage_form.ProgressBar.Value = Int(i / FileRowCnt * 100)
            Windows.Forms.Application.DoEvents()
        Loop
        FileClose(i_fnum)

        'メッセージウィンドウのクリア
        ProgressMessage_form.Dispose()
        ProgressMessage_form = Nothing

    End Sub

    Private Sub MODE_T_TextChanged(sender As Object, e As EventArgs) Handles MODE_T.TextChanged
        If MODE_T.Text = "（新規）" Then
            DELETE_B.Enabled = False
        Else
            DELETE_B.Enabled = True
        End If
    End Sub

    Private Sub BUMON_LINK_B_Click(sender As Object, e As EventArgs) Handles BUMON_LINK_B.Click
        Dim SelectBumon_form As New cSelectLib.fSelectBumon(oConn,
                     oCommand,
                     oDataReader,
                     oConf,
                     oTran)
        SelectBumon_form.ShowDialog()
        JANCODE_T.Text = SelectBumon_form.BUMON_CODE_T.Text
        SelectBumon_form = Nothing
    End Sub

    Private Sub JANCODE_T_LostFocus(sender As Object, e As EventArgs) Handles JANCODE_T.LostFocus

        '2017.09.27 Y.Sato 追加 From

        Try

            '2019,10,16 A.Komita 追加 From
            JANCODE_T.Text = JANCODE_T.Text
            '2019,10,16 A.Komita 追加 To

        Catch
            If JANCODE_T.Text.Substring(0, 2) = "99" Then
                CREATE_JANCD_B.Enabled = False
            Else
                CREATE_JANCD_B.Enabled = True
            End If

        End Try
        '2017.09.27 Y.Sato 追加 To

    End Sub
End Class
