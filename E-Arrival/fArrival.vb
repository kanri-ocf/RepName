Public Class fArrival
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oArriveDataFull() As cStructureLib.sViewArriveDataFull
    Private oViewArriveDataFullDBIO As cViewArriveDataFullDBIO

    Private oOrderDataFull() As cStructureLib.sViewOrderDataFull
    Private oOrderDataDBIO As cViewOrderDataFullDBIO

    '2019,10,10 A.Komita 追加 From
    Private oOrderData() As cStructureLib.sOrderData
    Private oDataOrderDBIO As cDataOrderDBIO
    '2019,10,10 A.Komita 追加 To

    Private oOrderSubData() As cStructureLib.sOrderSubData
    Private oDataOrderSubDBIO As cDataOrderSubDBIO

    Private oArrivalData() As cStructureLib.sArrivalData
    Private oDataArrivalDBIO As cDataArrivalDBIO

    Private oArrivalSubData() As cStructureLib.sArrivalSubData
    Private oDataArrivalSubDBIO As cDataArrivalSubDBIO

    'TODO:now 商品情報の更新
    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    'ここまで


    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oStaff() As cStructureLib.sStaff

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMstStockDBIO As cMstStockDBIO

    Private oTagPrintStatusDBIO As cDataTagPrintStatusDBIO

    Private oTool As cTool

    Private SUPPLIER_CODE As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private ARRIVAL_NO As Integer
    Private ARRIVAL_CNT As Long

    Private IVENT_STOP As Boolean
    Private INIT_FLG As Boolean     'フォーム初期化中 = True
    '2019,10,10 A.Komita 追加 From
    Private JAN_CODE_FLG As Boolean = 0 'JANコード読込時に送料,手数料,値引き,ポイント値引きを表示させるフラグ
    '2019,10,10 A.Komita 追加 To

    Private oTran As OleDb.OleDbTransaction

    '2019,11,1 A.Komita 追加 From
    Private B_Brefore_Product As Integer
    Private B_Postage As Integer
    Private B_Fee As Integer
    Private B_Before_Bill_Price As Integer
    Private B_Tax As Integer
    Private B_Rtax As Integer
    Private B_Discount As Integer
    Private B_Point_Discount As Integer
    Private B_AfterBill_Price As Integer
    '2019,11,1 A.Komita 追加 To

    '-----------------------------------------------------------------------------------------
    '2015/06/20
    '及川和彦
    'FROM
    '-----------------------------------------------------------------------------------------

    Private POSTAGE_SWITCH As Boolean            '入力があった
    Private POSTAGE_MODE As Boolean              '送料入力時の税モード　True:税込み  False:税抜き
    Private POSTAGE_VALUE As Long                '送料入力時の金額

    Private FEE_SWITCH As Boolean            '入力があった
    Private FEE_MODE As Boolean              '手数料入力時の税モード　True:税込み  False:税抜き
    Private FEE_VALUE As Long                '手数料入力時の金額

    Private DISCOUNT_SWITCH As Boolean            '入力があった
    Private DISCOUNT_MODE As Boolean              '値引き入力時の税モード    True:税込み  False:税抜き
    Private DISCOUNT_VALUE As Long                '値引き入力時の金額

    Private POINT_DISCOUNT_SWITCH As Boolean            '入力があった
    Private POINT_DISCOUNT_MODE As Boolean              'ポイント値引き入力時の税モード    True:税込み  False:税抜き
    Private POINT_DISCOUNT_VALUE As Long                'ポイント値引き入力時の金額

    Private STOP_VALUE As Boolean         'ValueChangeの繰り返し阻止

    Private ORDER_V_MODE() As Boolean              '納入単価の変更時の税モード    True:税込み  False:税抜き
    Private ORDER_V_VALUE() As Long                '納入単価の変更時の金額
    Private ORDER_V_COUNT() As Long                '納入単価の変更時の行


    Private S_B_ZEI_MODE As Long
    Private S_B_BREFORE_PRODUCT_T As Long
    Private S_B_POSTAGE_T As Long
    Private S_B_FEE_T As Long
    Private S_B_BEFORE_BILL_PRICE_T As Long
    Private S_B_TAX_T As Long

    '2019,10,3 A.Komita 追加 From
    Private S_B_RTAX_T As Long
    '2019,10,3 A.Komita 追加To

    Private S_B_DISCOUNT_T As Long
    Private S_B_POINT_DISCOUNT_T As Long
    Private S_B_AFTER_BILL_PRICE_T As Long

    Private ORDER_CODE_T_Lost_S As Long
    Private STOP_S As Boolean



    '-----------------------------------------------------------------------------------------
    'HERE
    '-----------------------------------------------------------------------------------------


    'TODO:税モード
    Private AFTER_TAX As Boolean


    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        INIT_FLG = True

        ReDim ORDER_V_MODE(50)
        ReDim ORDER_V_COUNT(50)
        ReDim ORDER_V_VALUE(50)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oDataArrivalDBIO = New cDataArrivalDBIO(oConn, oCommand, oDataReader)
        oDataArrivalSubDBIO = New cDataArrivalSubDBIO(oConn, oCommand, oDataReader)

        '2019,10,10 A.Komita 追加 From
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        '2019,10,10 A.Komita 追加 To

        oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)
        oTagPrintStatusDBIO = New cDataTagPrintStatusDBIO(oConn, oCommand, oDataReader)
        oOrderDataDBIO = New cViewOrderDataFullDBIO(oConn, oCommand, oDataReader)
        oViewArriveDataFullDBIO = New cViewArriveDataFullDBIO(oConn, oCommand, oDataReader)
        oMstStockDBIO = New cMstStockDBIO(oConn, oCommand, oDataReader)

        'TODO:now 商品情報の更新
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)

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

    Private Sub fArrival_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        End If

        'スタッフ入力ウィンドウ表示
        If STAFF_CODE = Nothing Then
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            Application.DoEvents()
            If staff_form.DialogResult = DialogResult.OK Then
                '担当者セット
                STAFF_CODE = staff_form.STAFF_CODE
                STAFF_NAME = staff_form.STAFF_NAME
                staff_form = Nothing
            Else
                staff_form = Nothing
                Environment.Exit(1)
            End If
        End If

        '担当者画面セット
        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        'デフォルト入庫日セット
        ARRIVAL_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)

        'デフォルト請求金額セット
        T_BREFORE_PRODUCT_T.Text = 0

        '注文情報データグリッド生成
        GRIDVIEW_CREATE()

        INIT_FLG = False

        '画面初期化
        INIT_PROC(1)

        'TODO:税モード
        AFTER_TAX_R.Checked = True

        ORDER_CODE_T.Focus()

    End Sub

    Private Sub ORDER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles ORDER_CODE_T.LostFocus
        Dim RecordCount As Long
        Dim i As Integer

        '注文コード未入力の場合
        If ORDER_CODE_T.Text = "" Then
            ORDER_CODE_T.Focus()
            Exit Sub
        End If


        '------------------------------------------------------------------------------------------
        '2015/06/20
        '及川和彦
        '中止処理のトランザクション開始
        'FROM
        '------------------------------------------------------------------------------------------
        'トランザクションの開始
        On Error Resume Next
        oTran.Rollback()
        oTran = oConn.BeginTransaction
        On Error GoTo 0

        '------------------------------------------------------------------------------------------
        'HERE
        '------------------------------------------------------------------------------------------

        'データクリア
        For i = 0 To ORDER_V.Rows.Count - 1
            ORDER_V.Rows.Clear()
        Next

        '------------------------------------------------
        '2015/06/20
        '及川和彦
        '注文コードからロストFocusする際に、送料などが初期化されないため、追加
        'FROM
        '------------------------------------------------
        ORDER_CODE_T_Lost_S = ORDER_CODE_T.Text
        INIT_PROC(2)
        ORDER_CODE_T.Text = ORDER_CODE_T_Lost_S
        '------------------------------------------------
        'HERE
        '------------------------------------------------

        'データセット
        RecordCount = ORDER_SET()

        '該当注文コードのデータが存在しない場合
        If RecordCount = 0 Then
            ORDER_CODE_T.Text = ""
            ORDER_CODE_T.Focus()
        End If

        JANCODE_T.Focus()

        'TODO:税モード
        If AFTER_TAX = False Then
            AFTER_TAX_R.Checked = True
        Else
            BEFORE_TAX_R.Checked = True
        End If



    End Sub

    Private Sub JANCODE_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles JANCODE_T.LostFocus
        If JANCODE_T.Text <> "" Then
            If UPDATE_ORDER_V(JANCODE_T.Text) = True Then
                COMMIT_B.Enabled = True
            End If
        End If
    End Sub
    Private Sub JANCODE_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles JANCODE_T.GotFocus
        JANCODE_T.SelectAll()
    End Sub
    Private Sub JANCODE_T_MouseDown(ByVal sender As Object, ByVal e As EventArgs) Handles JANCODE_T.MouseDown
        JANCODE_T.SelectAll()
    End Sub


    Private Sub COUNT_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles COUNT_T.LostFocus
        JANCODE_T.Focus()
    End Sub
    Private Sub COUNT_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles COUNT_T.GotFocus
        COUNT_T.SelectAll()
    End Sub
    Private Sub COUNT_T_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles COUNT_T.MouseDown
        COUNT_T.SelectAll()
    End Sub


    Private Sub T_POSTAGE_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        T_POSTAGE_T.SelectAll()
    End Sub
    Private Sub T_POSTAGE_T_MouseDown(ByVal sender As Object, ByVal e As EventArgs) Handles T_POSTAGE_T.MouseDown
        T_POSTAGE_T.SelectAll()
    End Sub

    Private Sub T_FEE_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        T_FEE_T.SelectAll()
    End Sub


    Private Sub T_TAX_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If T_TAX_T.Text <> "" Then
            T_TAX_T.Text = String.Format("{0:C}", CLng(T_TAX_T.Text))
        End If
    End Sub
    Private Sub T_TAX_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        T_TAX_T.SelectAll()
    End Sub

    '2019,10,3 A.Komita 追加 From
    Private Sub T_RAX_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If T_RTAX_T.Text <> "" Then
            T_RTAX_T.Text = String.Format("{0:C}", CLng(T_RTAX_T.Text))
        End If
    End Sub
    Private Sub T_RTAX_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        T_RTAX_T.SelectAll()
    End Sub
    '2019,10,3 A.Komita 追加 To

    Private Sub T_ARRIVAL_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs) 'デザイン上当てはまるTBが見つからない
        T_BREFORE_PRODUCT_T.SelectAll()
    End Sub
    Private Sub T_ARRIVAL_T_MouseDown(ByVal sender As Object, ByVal e As EventArgs) Handles T_BREFORE_PRODUCT_T.MouseDown
        T_BREFORE_PRODUCT_T.SelectAll()
    End Sub


    Private Sub T_ORDER_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) 'デザイン上当てはまるTBが見つからない
        If T_BREFORE_PRODUCT_T.Text <> "" Then
            T_BREFORE_PRODUCT_T.Text = String.Format("{0:C}", CLng(T_BREFORE_PRODUCT_T.Text))
        End If
    End Sub


    '-----------------------------------------< 内部関数 >-------------------------------------------

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
        column0.ReadOnly = False
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column0.Name = "JANコード"

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        ORDER_V.Columns.Add(column1)
        column1.Width = 85
        column1.ReadOnly = True
        column1.Name = "商品コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        ORDER_V.Columns.Add(column2)
        column2.Width = 150
        column2.ReadOnly = True
        column2.Name = "商品名称"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        ORDER_V.Columns.Add(column3)
        column3.Width = 100
        column3.ReadOnly = True
        column3.Name = "オプション"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "発注単価"
        ORDER_V.Columns.Add(column4)
        column4.Width = 80
        column4.ReadOnly = True
        column4.DefaultCellStyle.Format = "#,##0"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "発注単価"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "納入単価"
        ORDER_V.Columns.Add(column5)
        column5.Width = 80
        column5.Name = "ArrivePrice"
        column5.ReadOnly = False
        column5.DefaultCellStyle.Format = "#,##0"
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.DefaultCellStyle.BackColor = Color.Wheat
        column5.DefaultCellStyle.SelectionBackColor = Color.White
        column5.Name = "納入単価"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "注文数"
        ORDER_V.Columns.Add(column6)
        column6.Width = 50
        column6.ReadOnly = True
        column6.DefaultCellStyle.Format = "#,##0"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.Name = "注文数"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "納入数"
        ORDER_V.Columns.Add(column7)
        column7.Width = 50
        column7.Name = "ArriveCnt"
        column7.ReadOnly = False
        column7.DefaultCellStyle.Format = "#,##0"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.DefaultCellStyle.BackColor = Color.Wheat
        column7.DefaultCellStyle.SelectionBackColor = Color.White
        column7.Name = "納入数"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "納入金額"
        ORDER_V.Columns.Add(column8)
        column8.Width = 80
        column8.ReadOnly = True
        column8.DefaultCellStyle.Format = "#,##0"
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "納入金額"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "納入残"
        ORDER_V.Columns.Add(column9)
        column9.Width = 50
        column9.ReadOnly = True
        column9.DefaultCellStyle.Format = "#,##0"
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "納入残"

        Dim column10 As New DataGridViewTextBoxColumn
        column10.HeaderText = "発注明細コード"
        ORDER_V.Columns.Add(column10)
        column10.Width = 65
        column10.ReadOnly = True
        column10.Visible = False
        column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column10.Name = "発注明細コード"

        Dim column11 As New DataGridViewTextBoxColumn
        column11.HeaderText = "発注中止事由"
        ORDER_V.Columns.Add(column11)
        column11.Width = 105
        column11.ReadOnly = True
        column11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column11.Name = "発注中止事由"

        '2019,10,3 A.Komita 追加 From
        Dim column12 As New DataGridViewTextBoxColumn
        column12.HeaderText = "税率"
        ORDER_V.Columns.Add(column12)
        column12.Width = 40
        column12.ReadOnly = True
        column12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column12.Name = "税率"
        '2019,10,3 A.Komita 追加 To

        '直前の納入数（入力値）
        Dim column13 As New DataGridViewTextBoxColumn
        column13.HeaderText = ""
        ORDER_V.Columns.Add(column13)
        column13.Visible = False
        column13.Name = "直前の納入数"

        '画面読込み時のJANコード
        Dim column14 As New DataGridViewTextBoxColumn
        column14.HeaderText = ""
        ORDER_V.Columns.Add(column14)
        column14.Visible = False
        column14.Name = "画面読込み時のJANコード"

        '画面読込み時の納入単価
        Dim column15 As New DataGridViewTextBoxColumn
        column15.HeaderText = ""
        ORDER_V.Columns.Add(column15)
        column15.Visible = False
        column15.Name = "画面読込み時の納入単価"

        '画面読込み時の納入残数
        Dim column16 As New DataGridViewTextBoxColumn
        column16.HeaderText = ""
        ORDER_V.Columns.Add(column16)
        column16.Visible = False
        column16.Name = "画面読込み時の納入残数"

        '背景色を白に設定
        ORDER_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        ORDER_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '注文明細を画面にセット
    '***********************************************
    Private Function ORDER_SET() As Long
        Dim RecordCnt As Integer
        Dim Message_form As cMessageLib.fMessage


        '注文情報データの読み込み
        RecordCnt = oOrderDataDBIO.getOrderSearch(oOrderDataFull, ORDER_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        If RecordCnt = 0 Then
            '注文コード該当なし→メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "該当発注コードが",
                                            "発注データに存在しません",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            ORDER_CODE_T.Text = ""
            ORDER_CODE_T.Focus()
            Exit Function
        End If

        '発注情報の画面セット
        SUPPLIER_CODE = oOrderDataFull(0).sSupplierCode
        SUPPLIER_T.Text = oOrderDataFull(0).sSupplierName
        PAYMENT_T.Text = oOrderDataFull(0).sPaymentName
        TOTAL_ORDER_T.Text = String.Format("{0:C}", oOrderDataFull(0).sTotalPrice)
        TOTAL_TAX_T.Text = String.Format("{0:C}", oOrderDataFull(0).sTaxTotal)

        '2019,10,3 A.Komita 追加 From
        RTAX_RATE_T.Text = String.Format("{0:C}", oOrderDataFull(0).sReducedTaxRateTotal)
        '2019,10,3 A.Komita 追加 To

        RQ_DATE_T.Text = oOrderDataFull(0).sRequestDate
        RQ_PLACE_T.Text = oOrderDataFull(0).sRequestPlace
        OSTAFF_CODE_T.Text = oOrderDataFull(0).sStaffCode
        OSTAFF_NAME_T.Text = oOrderDataFull(0).sStaffName


        '入庫情報データの読み込み

        RecordCnt = oViewArriveDataFullDBIO.getArriveSearch(oArriveDataFull, ORDER_CODE_T.Text, Nothing, Nothing, oTran)

        '2019.11.20 R.Takashima FROM
        '既入庫情報の画面セット
        '一つのメソッドにまとめた為、以下一部除きコメントアウト
        ' B_TEXT_INIT(True, oArriveDataFull)
        If RecordCnt = 0 Then

            ''完納フラグ
            'FINISH_C.Checked = False
            ''納入回数
            'ARRIVE_COUNT_T.Text = 1
            ''商品代金
            'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", 0)
            ''送料の数値変換
            'B_POSTAGE_T.Text = String.Format("{0:#,##0}", 0)
            ''手数料の数値変換
            'B_FEE_T.Text = String.Format("{0:#,##0}", 0)
            ''税抜き請求金額
            'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", 0)
            ''消費税額
            'B_TAX_T.Text = String.Format("{0:#,##0}", 0)

            ''2019,10,3 A.Komita 追加 From
            ''軽減税額
            'B_RTAX_T.Text = String.Format("{0:#,##0}", 0)
            ''2019,10,3 A.Komita 追加 To

            ''値引きの数値変換
            'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", 0)
            ''ポイント値引きの数値変換
            'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", 0)
            ''税込み請求金額
            'B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", 0)

        Else
            ''完納フラグ
            'FINISH_C.Checked = oArriveDataFull(0).sFinishFlg
            ''納入回数
            'ARRIVE_COUNT_T.Text = oArriveDataFull(0).sArrivalNo + 1
            ''商品代金
            'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sNoTaxTotalProductPrice)
            ''送料の数値変換
            'B_POSTAGE_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sShippingCharge)
            ''手数料の数値変換
            'B_FEE_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sPaymentCharge)
            ''-------------------------------------------------------------------
            ''2019/10/26 suzuki 
            ''-------------------------------------------------------------------
            '''税抜き請求金額
            ''B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sNoTaxTotalPrice)
            ''請求金額
            'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", (oArriveDataFull(0).sNoTaxTotalProductPrice + oArriveDataFull(0).sShippingCharge + oArriveDataFull(0).sPaymentCharge))
            ''-------------------------------------------------------------------
            ''2019/10/26 suzuki 
            ''-------------------------------------------------------------------
            ''消費税額
            'B_TAX_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sTaxTotal)

            ''2019,10,3 A.Komita 追加 From
            ''軽減税額
            'B_RTAX_T.Text = String.Format("{0:#,##0}", oOrderDataFull(0).sReducedTaxRateTotal)
            ''2019,10,3 A.Komita 追加 To

            ''値引きの数値変換
            'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sDiscount)
            ''ポイント値引きの数値変換
            'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sPointDisCount)
            ''税込み請求金額
            'B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", oArriveDataFull(0).sTotalPrice)


            'S_B_BREFORE_PRODUCT_T = B_BREFORE_PRODUCT_T.Text
            'S_B_POSTAGE_T = B_POSTAGE_T.Text
            'S_B_FEE_T = B_FEE_T.Text
            'S_B_BEFORE_BILL_PRICE_T = B_BEFORE_BILL_PRICE_T.Text
            'S_B_TAX_T = B_TAX_T.Text

            ''2019,10,3 A.Komita 追加 From
            'S_B_RTAX_T = B_RTAX_T.Text
            ''2019,10,3 A.Komita 追加 To

            'S_B_DISCOUNT_T = B_DISCOUNT_T.Text
            'S_B_POINT_DISCOUNT_T = B_POINT_DISCOUNT_T.Text
            'S_B_AFTER_BILL_PRICE_T = B_AFTER_BILL_PRICE_T.Text


            '2019,11,1 A.Komita 追加 From
            'ORDER_DATA()
            'ORDER_SUB_DATA()

            '税込の商品代金を表示する際に使用(CAL_PROCメソッド内)
            'B_Brefore_Product = oOrderSubData(0).sListPrice
            'B_Before_Bill_Price = oOrderData(0).sNoTaxTotalPrice + oOrderData(0).sTaxTotal + oOrderData(0).sReducedTaxRateTotal
            'B_AfterBill_Price = oOrderData(0).sTotalPrice
            '2019,11,1 A.Komita 追加 To

            ''-----------------------------------------------------------------------------------------
            ''2015/06/20
            ''及川和彦
            ''既納入情報を税モードで変更するため、初期値をstatic変数に代入(税抜き金額)
            ''FROM
            ''-----------------------------------------------------------------------------------------

        End If


        'If AFTER_TAX_R.Checked = True Then
        '--------------------------------------------------------------------
        '2019/10/26 suzuki 初期値を税率とするので税率計算変更
        ''商品代金
        'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_BREFORE_PRODUCT_T, oConf(0).sTax, oConf(0).sFracProc))
        ''送料の数値変換
        'B_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POSTAGE_T, oConf(0).sTax, oConf(0).sFracProc))
        ''手数料の数値変換
        'B_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_FEE_T, oConf(0).sTax, oConf(0).sFracProc))
        ''値引きの数値変換
        'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_DISCOUNT_T, oConf(0).sTax, oConf(0).sFracProc))
        ''ポイント値引きの数値変換
        'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POINT_DISCOUNT_T, oConf(0).sTax, oConf(0).sFracProc))
        '--------------------------------------------------------------------
        ''商品代金
        'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", (S_B_BREFORE_PRODUCT_T))
        '    '送料の数値変換
        '    B_POSTAGE_T.Text = String.Format("{0:#,##0}", (S_B_POSTAGE_T))
        '    '手数料の数値変換
        '    B_FEE_T.Text = String.Format("{0:#,##0}", (S_B_FEE_T))
        '    '値引きの数値変換
        '    B_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_DISCOUNT_T))
        '    'ポイント値引きの数値変換
        '    B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_POINT_DISCOUNT_T))
        '--------------------------------------------------------------------
        '2019/10/26 suzuki 初期値を税率とするので税率計算変更　END
        '--------------------------------------------------------------------

        ''税抜き請求金額
        'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", S_B_BEFORE_BILL_PRICE_T)
        '    '消費税額
        '    B_TAX_T.Text = 0

        '    '2019,10,3 A.Komita 追加 From
        '    '軽減税額
        '    B_RTAX_T.Text = 0
        '    '2019,10,3 A.Komita 追加 To

        '    '税込み請求金額
        '    B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", (S_B_AFTER_BILL_PRICE_T))

        'Else
        '--------------------------------------------------------------------
        '2019/10/26 suzuki 初期値を税率とするので税率計算変更
        ''商品代金
        'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", (S_B_BREFORE_PRODUCT_T))
        ''送料の数値変換
        'B_POSTAGE_T.Text = String.Format("{0:#,##0}", (S_B_POSTAGE_T))
        ''手数料の数値変換
        'B_FEE_T.Text = String.Format("{0:#,##0}", (S_B_FEE_T))
        ''値引きの数値変換
        'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_DISCOUNT_T))
        ''ポイント値引きの数値変換
        'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_POINT_DISCOUNT_T))
        '--------------------------------------------------------------------
        '商品代金
        'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_BREFORE_PRODUCT_T, oConf(0).sTax, oConf(0).sFracProc))
        '    '送料の数値変換
        '    B_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POSTAGE_T, oConf(0).sTax, oConf(0).sFracProc))
        '    '手数料の数値変換
        '    B_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_FEE_T, oConf(0).sTax, oConf(0).sFracProc))
        '    '値引きの数値変換
        '    B_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_DISCOUNT_T))
        '    'ポイント値引きの数値変換
        '    B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", (S_B_POINT_DISCOUNT_T))
        '    '--------------------------------------------------------------------
        '    '2019/10/26 suzuki 初期値を税率とするので税率計算変更　END
        '    '--------------------------------------------------------------------
        '    '税抜き請求金額
        '    B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", (S_B_BEFORE_BILL_PRICE_T))
        '    '消費税額
        '    B_TAX_T.Text = String.Format("{0:#,##0}", (S_B_AFTER_BILL_PRICE_T) - S_B_BEFORE_BILL_PRICE_T)

        '    '2019,10,3 A.Komita 追加 From
        '    '軽減税額
        '    B_RTAX_T.Text = String.Format("{0:#,##0}", (S_B_AFTER_BILL_PRICE_T) - (S_B_BEFORE_BILL_PRICE_T) - (S_B_TAX_T))
        '    '2019,10,3 A.Komita 追加 To

        '    '税込み請求金額
        '    B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", (S_B_AFTER_BILL_PRICE_T))

        'End If


        ''-----------------------------------------------------------------------------------------
        ''HERE
        ''-----------------------------------------------------------------------------------------


        'End If

        RecordCnt = ORDER_DETAIL_SET()
        ORDER_SET = RecordCnt

    End Function
    '***********************************************
    '注文明細を画面にセット
    '***********************************************
    Private Function ORDER_DETAIL_SET() As Long
        Dim i As Integer
        Dim j As Integer
        Dim str As String
        Dim RecordCnt As Integer
        Dim Rest As Integer
        Dim ArrivePrice As Long
        Dim CostPrice As Long
        Dim ret As Integer

        '注文明細データの読み込み
        RecordCnt = oDataOrderSubDBIO.getOrderSubData(oOrderSubData, ORDER_CODE_T.Text, Nothing, oTran)
        Me.SuspendLayout()

        '表示設定
        For i = 0 To RecordCnt - 1
            '納入金額・納入残数の読込み
            ret = oDataArrivalSubDBIO.getSitffnessCount(oArrivalSubData, oOrderSubData(i).sOrderCode, oOrderSubData(i).sOrderSubCode, oTran)

            '-----------------------------------------------------------
            '当該注文番号において初回の入庫で入庫データが存在しない場合
            '納入残数に発注数量をセット
            '-----------------------------------------------------------
            If ret < 0 Then
                Rest = oOrderSubData(i).sCount
                ArrivePrice = 0
            Else
                Rest = oArrivalSubData(0).sArrivalStiffness
                ArrivePrice = 0
            End If

            '-----------------------------------------------------------
            '納入単価の読込み
            '当該注文番号における最終入庫時の納入単価を取得
            '-----------------------------------------------------------
            ret = oDataArrivalSubDBIO.getLastArrivalSubData(oArrivalSubData, oOrderSubData(i).sOrderCode, oOrderSubData(i).sOrderSubCode, Nothing, oTran)
            If ret <= 0 Then
                CostPrice = oOrderSubData(i).sCostPrice
            Else
                CostPrice = oArrivalSubData(0).sCostPrice
            End If

            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oOrderSubData(i).sOption1 <> "" Then
                            str = str & oOrderSubData(i).sOption1 & "："
                        End If
                    Case 2
                        If oOrderSubData(i).sOption2 <> "" Then
                            str = str & oOrderSubData(i).sOption2 & "："
                        End If
                    Case 3
                        If oOrderSubData(i).sOption3 <> "" Then
                            str = str & oOrderSubData(i).sOption3 & "："
                        End If
                    Case 4
                        If oOrderSubData(i).sOption4 <> "" Then
                            str = str & oOrderSubData(i).sOption4 & "："
                        End If
                    Case 5
                        If oOrderSubData(i).sOption5 <> "" Then
                            str = str & oOrderSubData(i).sOption5 & "："
                        End If
                End Select

            Next

            '2019,10,6 A.Komita 税込ボタンを押下してから注文番号を入力すると
            '消費税が二重に計算される為修正-------------------------------------　　

            ORDER_V.Rows.Add(
                    oOrderSubData(i).sJANCode,'JANコード
                    oOrderSubData(i).sProductCode,'商品コード
                    oOrderSubData(i).sProductName,'商品名称
                    str,'オプション
                    oOrderSubData(i).sCostPrice,'発注単価
                    CostPrice,'納入単価 
                    oOrderSubData(i).sCount,'注文数
                    0,'納入数,
                    ArrivePrice,'納入金額
                    Rest'納入残
                        )

            '2019,10,6 A.Komita 修正 End----------------------------------------


            ARRIVAL_CNT = ARRIVAL_CNT + Rest

        Next i
        Me.ResumeLayout(False)

        ORDER_DETAIL_SET = i
        Cal_Proc_View(True)
    End Function

    '***********************************************
    '注文明細の一行更新
    '***********************************************
    Private Function ORDER_DETAIL_LINE_UPDATE(ByVal LineNo As Integer, ByVal OrderCode As String, ByVal OrderSubCode As Integer) As Boolean
        Dim j As Integer
        Dim str As String
        Dim RecordCnt As Integer
        Dim pOrderSubData() As cStructureLib.sOrderSubData

        '注文明細データの読み込み
        ReDim pOrderSubData(0)

        RecordCnt = oDataOrderSubDBIO.getOrderSubData(pOrderSubData, OrderCode, OrderSubCode, oTran)
        Me.SuspendLayout()

        '表示設定
        str = ""
        For j = 1 To 5
            Select Case j
                Case 1
                    If pOrderSubData(0).sOption1 <> "" Then
                        str = str & pOrderSubData(0).sOption1 & "："
                    End If
                Case 2
                    If pOrderSubData(0).sOption2 <> "" Then
                        str = str & pOrderSubData(0).sOption2 & "："
                    End If
                Case 3
                    If pOrderSubData(0).sOption3 <> "" Then
                        str = str & pOrderSubData(0).sOption3 & "："
                    End If
                Case 4
                    If pOrderSubData(0).sOption4 <> "" Then
                        str = str & pOrderSubData(0).sOption4 & "："
                    End If
                Case 5
                    If pOrderSubData(0).sOption5 <> "" Then
                        str = str & pOrderSubData(0).sOption5 & "："
                    End If
            End Select
        Next

        ORDER_V("JANコード", LineNo).Value = pOrderSubData(0).sJANCode
        ORDER_V("商品名称", LineNo).Value = pOrderSubData(0).sProductName
        ORDER_V("オプション", LineNo).Value = str
        ORDER_V("納入単価", LineNo).Value = pOrderSubData(0).sCostPrice
        ORDER_V("商品コード", LineNo).Value = pOrderSubData(0).sProductCode
        ORDER_V("発注中止事由", LineNo).Value = pOrderSubData(0).sCancelReason

        ORDER_DETAIL_LINE_UPDATE = True
    End Function


    '----------------------------------------------------
    '2015/06/21
    '及川和彦
    'FROM
    '----------------------------------------------------
    '***********************************************
    '注文明細の発注中止事由更新(中止登録)
    '***********************************************
    Private Function ORDER_DETAIL_CANCEL_UPDATE(ByVal LineNo As Integer, ByVal OrderCode As String, ByVal OrderSubCode As Integer) As Boolean
        Dim RecordCnt As Integer
        Dim pOrderSubData() As cStructureLib.sOrderSubData

        '注文明細データの読み込み
        ReDim pOrderSubData(0)

        RecordCnt = oDataOrderSubDBIO.getOrderSubData(pOrderSubData, OrderCode, OrderSubCode, oTran)
        Me.SuspendLayout()


        'ORDER_V("発注中止事由", LineNo).Value = pOrderSubData(0).sOrderCancelFlg


        '----------------------------------------------------
        '2015/06/24
        '及川和彦
        '中止登録後、事由がTrueになるため、修正
        'FROM
        '----------------------------------------------------
        ORDER_V("発注中止事由", LineNo).Value = pOrderSubData(0).sCancelReason

        '----------------------------------------------------
        'HERE
        '----------------------------------------------------



        ORDER_DETAIL_CANCEL_UPDATE = True
    End Function


    '***********************************************
    '注文明細の納入単価更新
    '***********************************************
    Private Function ORDER_DETAIL_ARRIVAL_UPDATE(ByVal LineNo As Integer, ByVal OrderCode As String, ByVal OrderSubCode As Integer) As Boolean
        Dim RecordCnt As Integer
        Dim pProduct() As cStructureLib.sViewProductPrice
        Dim pProductDBIO As cMstProductDBIO

        ReDim pProduct(0)
        pProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)

        RecordCnt = pProductDBIO.getProductPriceArrival(pProduct,
                                                        ORDER_V("商品コード", LineNo).Value,
                                                        SUPPLIER_T.Text,
                                                        oTran)


        Me.SuspendLayout()


        ReDim Preserve pProduct(0)

        If AFTER_TAX_R.Checked = True Then
            ORDER_V("納入単価", LineNo).Value = oTool.BeforeToAfterTax(pProduct(0).sCostPrice, oConf(0).sTax, oConf(0).sFracProc)
        Else
            ORDER_V("納入単価", LineNo).Value = CLng(pProduct(0).sCostPrice)
        End If


        pProductDBIO = Nothing
        pProduct = Nothing

        ORDER_DETAIL_ARRIVAL_UPDATE = True

    End Function
    '----------------------------------------------------
    'HERE
    '----------------------------------------------------



    '-----------------------------------------------------------
    '2015/06/20
    '及川和彦
    '初期化のパターン追加
    '-----------------------------------------------------------
    Private Sub INIT_PROC(ByVal Mode As Integer)
        Dim i As Integer

        ReDim ORDER_V_MODE(50)
        ReDim ORDER_V_COUNT(50)
        ReDim ORDER_V_VALUE(50)

        IVENT_STOP = False


        For i = 0 To ORDER_V.Rows.Count - 1
            ORDER_V.Rows.Clear()
        Next



        ORDER_CODE_T.Text = ""
        JANCODE_T.Text = ""
        ARRIVAL_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)
        T_BREFORE_PRODUCT_T.Text = 0
        T_BEFORE_BILL_PRICE_T.Text = 0
        T_TAX_T.Text = 0

        '2019,10,3 A.Komita 追加 From
        T_RTAX_T.Text = 0
        '2019,10,3 A.Komita 追加 To

        T_AFTER_BILL_PRICE_T.Text = 0
        ARRIVAL_CNT = 0

        '-------------------------------------------------------------------
        '2015/06/19
        '及川和彦
        '登録後、既納入情報が初期化されていないため、修正・追加
        'FROM0
        '-------------------------------------------------------------------
        T_POSTAGE_T.Text = 0
        T_FEE_T.Text = 0
        T_DISCOUNT_T.Text = 0
        T_POINT_DISCOUNT_T.Text = 0

        B_BREFORE_PRODUCT_T.Text = 0
        B_POSTAGE_T.Text = 0
        B_FEE_T.Text = 0
        B_BEFORE_BILL_PRICE_T.Text = 0
        B_TAX_T.Text = 0

        '2019,10,3 A.Komita 追加 From
        B_RTAX_T.Text = 0
        '2019,10,3 A.Komita 追加 To

        B_DISCOUNT_T.Text = 0
        B_POINT_DISCOUNT_T.Text = 0
        B_AFTER_BILL_PRICE_T.Text = 0
        '-------------------------------------------------------------------
        'HERE
        '-------------------------------------------------------------------

        '-------------------------------------------------------------------
        '2015/06/19
        '及川和彦
        '分納の2度目の入庫時に1度目の送料が初期値として表示されてしまうため、追加
        'FROM0
        '-------------------------------------------------------------------
        POSTAGE_VALUE = 0
        FEE_VALUE = 0
        DISCOUNT_VALUE = 0
        POINT_DISCOUNT_VALUE = 0
        '-------------------------------------------------------------------
        'HERE
        '-------------------------------------------------------------------

        '-------------------------------------------------------------------
        '2015/06/19
        '及川和彦
        '既納入の税モード切り替え用の変数を初期化
        'FROM0
        '-------------------------------------------------------------------
        S_B_BREFORE_PRODUCT_T = 0
        S_B_POSTAGE_T = 0
        S_B_FEE_T = 0
        S_B_BEFORE_BILL_PRICE_T = 0
        S_B_TAX_T = 0

        '2019,10,3 A.Komita 追加 From
        S_B_RTAX_T = 0
        '2019,10,3 A.Komita 追加 To

        S_B_DISCOUNT_T = 0
        S_B_POINT_DISCOUNT_T = 0
        S_B_AFTER_BILL_PRICE_T = 0
        '-------------------------------------------------------------------
        'HERE
        '-------------------------------------------------------------------



        '-------------------------------------------------------------------
        '2015/06/19
        '及川和彦
        '税込みモードを初期値に
        'FROM0
        '-------------------------------------------------------------------
        AFTER_TAX_R.Checked = True
        '-------------------------------------------------------------------
        'HERE
        '-------------------------------------------------------------------


        FINISH_C.Checked = False

        COMMIT_B.Enabled = False


        If Mode = 1 Then
            ORDER_CODE_T.Focus()
        End If
    End Sub

    ''----------------------------------------------------
    ''2015/06/28
    ''及川和彦
    ''FROM
    ''----------------------------------------------------
    Private Sub UNIT_PRICE_PROC(ByVal count As Integer)
        ORDER_V_MODE(count) = AFTER_TAX_R.Checked
        ORDER_V_COUNT(count) = count
        ORDER_V_VALUE(count) = CLng(ORDER_V("納入単価", count).Value)
    End Sub


    '----------------------------------------------------
    'HERE
    '----------------------------------------------------

    '*********************************************
    '2015/06/19
    '及川和彦
    ' 集計
    '   <引数>
    '       ChangeMode  True    :税モードの変更による
    '                   False   :その他
    '       InitFlg     True    :値変更:直接入力
    '                   False   :値変更:その他
    'FROM
    '**********************************************

    Private Sub CAL_PROC(ByVal ChangeMode As Boolean,
                         ByVal InitFlg As Boolean)

        Dim TOTAL_PRODUCT_ARRIVAL As Long
        Dim goukei As Long
        '2019 11.20 A.Komita 送料手数料をユーザーが変更した際にメッセージボックスを出力する為追加 From
        Dim Message_form As cMessageLib.fMessage
        '2019 11.20 A.Komita 追加 To




        If ChangeMode = True Then                       '税モードの切り替えで動作した場合
            goukei = T_AFTER_BILL_PRICE_T.Text          '税込合計金額を確保

        Else                                            'その他の要因で動作した場合

        End If


        '2019,10,09 A.Komita 追加 From

        Dim taxSumOnly = 0 '消費税のみの合計
        Dim RtaxSumOnly = 0 '軽減税のみの合計
        Dim selfTaxPrice As Integer = 0 '商品xの消費税を含めた値
        Dim selfNoTaxPrice As Integer = 0 '商品xの単価
        Dim Postage As Integer = 0
        Dim Fee As Integer = 0

        '2019.11.20 R.Takashima FROM
        '税率変数
        Dim taxRate As Integer = 0
        '2019.11.20 R.Takashima TO

        '2019,10,09 A.Komita 追加 To


        '税込み・税抜き表示切り替え

        For i = 0 To ORDER_V.Rows.Count - 1


            '2019,10,09 A.Komita 追加 From
            selfNoTaxPrice = oOrderSubData(i).sNoTaxPrice '税モードで計算分岐

            '発注単価の計算
            If oOrderSubData(i).sReducedTaxRate = String.Empty Then '軽減税率が適用されていない
                selfTaxPrice = oTool.BeforeToAfterTax(oOrderSubData(i).sNoTaxPrice, oConf(0).sTax, oConf(0).sFracProc)

            Else 'それ以外は軽減税率が適用されている
                selfTaxPrice = oTool.BeforeToAfterTax(oOrderSubData(i).sNoTaxPrice, oOrderSubData(i).sReducedTaxRate, oConf(0).sFracProc)

            End If
            '2019,10,09 A.Komita 追加 To


            '送料,手数料,値引き,ポイント値引きの数値変換
            If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                If T_POSTAGE_T.Modified = False And T_FEE_T.Modified = False Then
                    If AFTER_TAX_R.Checked = True Then
                        T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
                        T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))

                    Else
                        T_POSTAGE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sShippingCharge.ToString.Replace(",", ""))
                        T_FEE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPaymentCharge.ToString.Replace(",", ""))

                    End If
                End If
                T_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sDiscount.ToString.Replace(",", ""))
                T_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPointDisCount.ToString.Replace(",", ""))

            End If


            '2019.11.20 R.Takashima FROM
            '税モードを切り替えたときの値が正しくなるように変更
            If ChangeMode = True Then

                '税抜きモードなら
                If BEFORE_TAX_R.Checked = True Then
                    '発注単価の計算
                    ORDER_V("発注単価", i).Value = selfNoTaxPrice


                    '納入単価の計算
                    'ORDER_V_MODE = 納入単価を変更したとき税込みモード = TRUE
                    If ORDER_V_MODE(i) = True And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then

                        If oOrderSubData(i).sReducedTaxRate = String.Empty Then
                            taxRate = oConf(0).sTax
                        Else
                            taxRate = CLng(oOrderSubData(i).sReducedTaxRate)
                        End If

                        ORDER_V("納入単価", i).Value = oTool.AfterToBeforeTax(ORDER_V_VALUE(i), taxRate, oConf(0).sFracProc)

                        'ORDER_V_MODE = 納入高を変更したとき税抜きモード = FALSE
                    ElseIf ORDER_V_MODE(i) = False And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then

                        ORDER_V("納入単価", i).Value = ORDER_V_VALUE(i)

                    Else
                        '初期値
                        ORDER_V("納入単価", i).Value = selfNoTaxPrice

                    End If


                Else 'それ以外なら税込みモード

                    ORDER_V("発注単価", i).Value = selfTaxPrice
                    '納入単価の計算
                    'ORDER_V_MODE = 納入単価を変更したとき税込みモード = TRUE
                    If ORDER_V_MODE(i) = True And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then
                        ORDER_V("納入単価", i).Value = ORDER_V_VALUE(i)

                        'ORDER_V_MODE = 納入高を変更したとき税抜きモード = FALSE
                    ElseIf ORDER_V_MODE(i) = False And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then

                        If oOrderSubData(i).sReducedTaxRate = String.Empty Then
                            taxRate = oConf(0).sTax
                        Else
                            taxRate = CLng(oOrderSubData(i).sReducedTaxRate)
                        End If

                        ORDER_V("納入単価", i).Value = oTool.BeforeToAfterTax(ORDER_V_VALUE(i), taxRate, oConf(0).sFracProc)

                    Else
                        '初期値
                        ORDER_V("納入単価", i).Value = selfTaxPrice

                    End If
                End If

            End If

            '2019,11,21 A.Komita  納入単価を手入力で修正した時に送料手数料の価格が変動しない様にif文を追加 From
            If ORDER_V("納入単価", i).Value <> selfTaxPrice Then

                If T_POSTAGE_T.Modified = True And ChangeMode = False Then
                    If T_POSTAGE_T.Text <> String.Empty Then
                        T_POSTAGE_T.Text = T_POSTAGE_T.Text

                    Else
                        T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))

                    End If
                End If


                If T_FEE_T.Modified = True And ChangeMode = False Then
                    If T_FEE_T.Text <> String.Empty Then
                        T_FEE_T.Text = T_FEE_T.Text

                    Else
                        T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))

                    End If
                End If

                selfNoTaxPrice = ORDER_V("納入単価", i).Value

            End If



            '2019,11,21 A.Komita 追加 To

            'If ChangeMode = True Then

            '    '税抜きモードなら
            '    If BEFORE_TAX_R.Checked = True Then
            '        '発注単価の計算
            '        ORDER_V("発注単価", i).Value = selfNoTaxPrice
            '        '納入単価の計算
            '        If ORDER_V_MODE(i) = False And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then
            '            ORDER_V("納入単価", i).Value = ORDER_V_VALUE(i)

            '        Else
            '            ORDER_V("納入単価", i).Value = selfNoTaxPrice

            '        End If
            '    Else 'それ以外なら税込みモード

            '        ORDER_V("発注単価", i).Value = selfTaxPrice
            '        '納入単価の計算
            '        If ORDER_V_MODE(i) = True And ORDER_V_COUNT(i) = i And ORDER_V_VALUE(i) > 0 Then
            '            ORDER_V("納入単価", i).Value = ORDER_V_VALUE(i)
            '        Else
            '            ORDER_V("納入単価", i).Value = selfTaxPrice
            '        End If
            '    End If

            'End If
            '2019.11.20 R.Takashima TO

            '納入金額の計算
            ORDER_V("納入金額", i).Value = ORDER_V("納入単価", i).Value * ORDER_V("納入数", i).Value


            '商品ごとの消費税計算'商品ごとの消費税込みを取りたい
            If BEFORE_TAX_R.Checked = True Then

                If oOrderSubData(i).sReducedTaxRate.Length = 0 Then
                    If selfNoTaxPrice = oOrderSubData(i).sNoTaxPrice Then
                        taxSumOnly += (selfTaxPrice * ORDER_V("納入数", i).Value) - (selfNoTaxPrice * ORDER_V("納入数", i).Value)

                    Else
                        taxSumOnly += oTool.BeforeToTax(selfNoTaxPrice, oConf(0).sTax, oConf(0).sFracProc) * ORDER_V("納入数", i).Value

                    End If
                Else
                    If selfNoTaxPrice = oOrderSubData(i).sNoTaxPrice Then
                        RtaxSumOnly += (selfTaxPrice * ORDER_V("納入数", i).Value) - (selfNoTaxPrice * ORDER_V("納入数", i).Value)

                    Else
                        RtaxSumOnly += oTool.BeforeToTax(selfNoTaxPrice, oOrderSubData(i).sReducedTaxRate, oConf(0).sFracProc) * ORDER_V("納入数", i).Value

                    End If
                End If
            End If



            '商品代金集計
            TOTAL_PRODUCT_ARRIVAL = TOTAL_PRODUCT_ARRIVAL + ORDER_V("納入金額", i).Value


            '2019,10,3 A.Komita 追加 From

            If oOrderSubData(i).sReducedTaxRate = String.Empty Then
                ORDER_V("税率", i).Value = oConf(0).sTax.ToString & "%"


            Else '2019,11,15 A.Komita 税込モードで送料手数料の値を変更した際、軽減税の計算を行ってしまう為if文を追加 From

                ORDER_V("税率", i).Value = oOrderSubData(i).sReducedTaxRate & "%"
                'If BEFORE_TAX_R.Checked = True Then
                '    T_RTAX_T.Text += oTool.BeforeToTax((ORDER_V("納入金額", i).Value), oOrderSubData(i).sReducedTaxRate, oConf(0).sFracProc)

                'Else
                '    T_RTAX_T.Text = 0

                'End If
            End If
            'InitFlg = False

            '2019,10,3 A.Komita 追加 To


        Next i



        If InitFlg = False Then
            '---------------------------
            '    集計エリア表示設定
            '---------------------------

            '2019,10,10 A.Komita 修正 Start---------------------------------------------------------------------------------
            ORDER_DATA()
            JAN_CODE_FLG = False

            '商品代金
            T_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", TOTAL_PRODUCT_ARRIVAL)

            '''送料,手数料,値引き,ポイント値引きの数値変換
            'If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
            '    T_POSTAGE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sShippingCharge.ToString.Replace(",", ""))
            '    T_FEE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPaymentCharge.ToString.Replace(",", ""))
            '    T_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sDiscount.ToString.Replace(",", ""))
            '    T_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPointDisCount.ToString.Replace(",", ""))

            'End If


            'JAN_CODE_FLG = True

            '2019,10,10 A.Komita 修正 End-----------------------------------------------------------------------------------

            '税抜き請求金額
            T_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                           CLng(T_BREFORE_PRODUCT_T.Text.ToString.Replace(",", "")))

            '消費税額
            T_TAX_T.Text = taxSumOnly
            T_RTAX_T.Text = RtaxSumOnly

        End If



        '集計エリアの計算
        If AFTER_TAX_R.Checked = True Then  '税込みモードの場合
            If InitFlg = False Then

                'T_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", TOTAL_PRODUCT_ARRIVAL)

                '2019,10,30 A.Komita 修正 Start---------------------------------------------------------------------------------------------------

                '2019,11,21 A.Komita 納入単価を手入力で修正した時に送料手数料の価格が変動しない様にif文を追加 From
                If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                    T_POSTAGE_T.Text = T_POSTAGE_T.Text
                    T_FEE_T.Text = T_FEE_T.Text

                End If

                If T_BREFORE_PRODUCT_T.Text <> 0 And ChangeMode = True Then
                    T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                    T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))

                    'Else
                    '    If T_POSTAGE_T.Text = oOrderData(0).sShippingCharge Or T_FEE_T.Text = oOrderData(0).sPaymentCharge Then
                    '        T_POSTAGE_T.Text = T_POSTAGE_T.Text
                    '        T_FEE_T.Text = T_FEE_T.Text

                Else
                        If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                            T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
                            T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))

                        ElseIf ChangeMode = True Then
                            T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc))
                            T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))

                        End If
                    End If
                'End If

                '2019,11,21 A.Komita 追加 To

                '2019,10,30 A.Komita 修正 End-----------------------------------------------------------------------------------------------------


                '2019,10,9 A.Komita 修正 Start-----------------------------------------------------------


                T_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                                                       CLng(T_BREFORE_PRODUCT_T.Text) +
                                                                       CLng(T_POSTAGE_T.Text) +
                                                                       CLng(T_FEE_T.Text))

                '2019,10,9 A.Komita 修正 End-------------------------------------------------------------

                T_TAX_T.Text = 0

                T_RTAX_T.Text = 0

                T_DISCOUNT_T.Text = T_DISCOUNT_T.Text

                T_POINT_DISCOUNT_T.Text = T_POINT_DISCOUNT_T.Text


                '2019,11,15 A.Komita 税込モードで送料手数料の値を変更した際の再計算を行うif文を追加 From
            ElseIf InitFlg = True Then 'Elseだとテキストボックスにカーソルを合わせただけで分岐に入ってしまうのでElseifの条件で記述している

                If T_POSTAGE_T.Modified = True Then 'ユーザーによってテキストボックスの値が変更されたかを判断する
                    T_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc))

                End If
                T_POSTAGE_T.Modified = False

                If T_FEE_T.Modified = True Then
                    T_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc))

                End If
                T_FEE_T.Modified = False


                '2019,11,20 A.Komita メッセージボックスを追加 From
                If T_POSTAGE_T.Modified = True Or T_FEE_T.Modified = True Then

                    Message_form = New cMessageLib.fMessage(2, "税抜で変更する必要があります。",
                                                           "宜しいですか？",
                                                           Nothing, Nothing)

                    Message_form.ShowDialog()

                    If Message_form.DialogResult = DialogResult.No Then
                        Return

                    ElseIf Message_form.DialogResult = DialogResult.Yes Then
                        '2019,11,20 A.Komita 追加  To


                        T_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                                                       CLng(T_BREFORE_PRODUCT_T.Text) +
                                                                       CLng(T_POSTAGE_T.Text) +
                                                                       CLng(T_FEE_T.Text))
                        '2019,11,15 A.Komita 追加 To

                    End If
                End If
            End If

                '2019,10,9 A.Komita 追加 From

                T_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                                              CLng(T_BEFORE_BILL_PRICE_T.Text) +
                                                              CLng(T_TAX_T.Text) +
                                                              CLng(T_RTAX_T.Text) +
                                                              CLng(T_DISCOUNT_T.Text) +
                                                              CLng(T_POINT_DISCOUNT_T.Text)
                                                              )


            '2019,10,9 A.Komita 追加 To

            '----------------------------------------------------------------
            '2019/10/26 suzuki 税率計算修正
            ''商品代金
            'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", S_B_BREFORE_PRODUCT_T)
            ''送料の数値変換
            'B_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POSTAGE_T, oConf(0).sTax, oConf(0).sFracProc))
            ''手数料の数値変換
            'B_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_FEE_T, oConf(0).sTax, oConf(0).sFracProc))
            ''値引きの数値変換
            'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_DISCOUNT_T, oConf(0).sTax, oConf(0).sFracProc))
            ''ポイント値引きの数値変換
            'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POINT_DISCOUNT_T, oConf(0).sTax, oConf(0).sFracProc))
            ''税抜き請求金額
            'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", S_B_AFTER_BILL_PRICE_T)
            '----------------------------------------------------------------


            '2019,11,1 A.Komita 修正 Start-----------------------------------------------------------------------------------------------

            ''商品代金
            'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", B_Brefore_Product)
            ''送料の数値変換
            'B_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_POSTAGE_T, oConf(0).sTax, oConf(0).sFracProc))
            ''手数料の数値変換
            'B_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(S_B_FEE_T, oConf(0).sTax, oConf(0).sFracProc))
            ''税抜き請求金額
            'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", B_Before_Bill_Price)
            ''消費税額
            'B_TAX_T.Text = String.Format("{0:#,##0}", 0)
            ''軽減税額
            'B_RTAX_T.Text = String.Format("{0:#,##0}", 0)
            ''値引きの数値変換
            'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", S_B_DISCOUNT_T)
            ''ポイント値引きの数値変換
            'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", S_B_POINT_DISCOUNT_T)
            ''税込合計の数値変換
            'B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", B_AfterBill_Price)

            '2019,11,1 A.Komita 修正 End--------------------------------------------------------------------------------------------------

            '----------------------------------------------------------------
            '2019/10/26 suzuki 税率計算修正
            '----------------------------------------------------------------

        Else    '税抜きモードの場合
            If InitFlg = False Then

                T_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", TOTAL_PRODUCT_ARRIVAL)

                '2019,10,30 A.Komita 修正 Start----------------------------------------------------------------------------------------------------- 

                '2019,11,21 A.Komita 納入単価を手入力で修正した時と税モード切替時に送料手数料の価格が変動しない様にif文を追加 From
                If T_POSTAGE_T.Modified = False Then
                    If InitFlg = False Or JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                        T_POSTAGE_T.Text = oTool.AfterToBeforeTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                    ElseIf JAN_CODE_FLG = False And T_POSTAGE_T.Modified = True Then
                        T_POSTAGE_T.Text = oTool.AfterToBeforeTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                    ElseIf T_POSTAGE_T.Modified = True Then
                        T_POSTAGE_T.Text = T_POSTAGE_T.Text

                    ElseIf B_POSTAGE_T.Text <> 0 Then
                        T_POSTAGE_T.Text = 0

                    End If

                    'T_POSTAGE_T.Modified = True


                    If T_FEE_T.Modified = False Then
                        If InitFlg = False Or JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                            T_FEE_T.Text = oTool.AfterToBeforeTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                        ElseIf JAN_CODE_FLG = False And T_FEE_T.Modified = True Then
                            T_FEE_T.Text = oTool.AfterToBeforeTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                        ElseIf T_FEE_T.Modified = True Then
                            T_FEE_T.Text = T_FEE_T.Text

                        ElseIf B_FEE_T.Text <> 0 Then
                            T_FEE_T.Text = 0

                        End If
                    End If

                    'T_FEE_T.Modified = True

                    '2019,11,21 A.Komita 追加 To


                    '2019,12,15 A.Komita  送料手数料の消費税額が税モード切替で変動しないようにコードを追加 From
                    Postage = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
                    Postage = String.Format("{0:#,##0}", oTool.AfterToTax(Postage, oConf(0).sTax, oConf(0).sFracProc))

                    Fee = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(oOrderData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
                    Fee = String.Format("{0:#,##0}", oTool.AfterToTax(Fee, oConf(0).sTax, oConf(0).sFracProc))

                    If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Or T_BREFORE_PRODUCT_T.Text <> 0 Then
                        T_TAX_T.Text += Postage + Fee

                    End If

                    '2019,12,15 A.Komita 追加 To 

                    '2019,10,30 A.Komita 修正 End-------------------------------------------------------------------------------------------------------

                    T_DISCOUNT_T.Text = T_DISCOUNT_T.Text

                        T_POINT_DISCOUNT_T.Text = T_POINT_DISCOUNT_T.Text

                        '2019,11,21 A.Komita 追加 From

                    ElseIf InitFlg = True Then

                        If T_POSTAGE_T.Modified = True Then

                        T_POSTAGE_T.Text = T_POSTAGE_T.Text

                    End If
                    T_POSTAGE_T.Modified = False

                    If T_FEE_T.Modified = True Then

                        T_FEE_T.Text = T_FEE_T.Text

                    End If


                End If
                T_FEE_T.Modified = False

                '2019,12,12 A.Komita 注文番号読込後すぐ税抜モードに切り替えてJANコードを読みこんだ時に送料手数料の値をはめ込むコードを追加 From
                If InitFlg = False Then
                    If JAN_CODE_FLG = False And JANCODE_T.Text <> String.Empty Then
                        T_POSTAGE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sShippingCharge)
                        T_FEE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPaymentCharge)

                    End If
                End If
                '2019,12,12 A.Komita 追加 To


                '20191,11,21 A.Komita 追加 To

                '--------------------------------------------------------------------------

                If ChangeMode = False Then
                        goukei = goukei + oTool.BeforeToAfterTax(CLng(T_BREFORE_PRODUCT_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                        If POSTAGE_MODE = True Then
                            goukei = goukei + POSTAGE_VALUE
                        Else
                            goukei = goukei + oTool.BeforeToAfterTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        End If

                        If FEE_MODE = True Then
                            goukei = goukei + FEE_VALUE
                        Else
                            goukei = goukei + oTool.BeforeToAfterTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        End If

                        If DISCOUNT_MODE = True Then
                            goukei = goukei + DISCOUNT_VALUE
                        Else
                            goukei = goukei + oTool.BeforeToAfterTax(CLng(T_DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        End If

                        If POINT_DISCOUNT_MODE = True Then
                            goukei = goukei + POINT_DISCOUNT_VALUE
                        Else
                            goukei = goukei + oTool.BeforeToAfterTax(CLng(T_POINT_DISCOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        End If
                    End If
                    '--------------------------------------------------------------------------

                    T_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                                                   CLng(T_BREFORE_PRODUCT_T.Text) +
                                                                   CLng(T_POSTAGE_T.Text) +
                                                                   CLng(T_FEE_T.Text))


                    T_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}",
                                                              CLng(T_BEFORE_BILL_PRICE_T.Text) +
                                                              CLng(T_TAX_T.Text) +
                                                              CLng(T_RTAX_T.Text) +
                                                              CLng(T_DISCOUNT_T.Text) +
                                                              CLng(T_POINT_DISCOUNT_T.Text)
                                                              )


                    ''商品代金
                    'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sNoTaxTotalProductPrice)
                    ''送料の数値変換
                    'B_POSTAGE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sShippingCharge)
                    ''手数料の数値変換
                    'B_FEE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPaymentCharge)
                    ''税抜き請求金額
                    'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", CLng(B_BREFORE_PRODUCT_T.Text) + CLng(B_POSTAGE_T.Text) + CLng(B_FEE_T.Text))
                    ''消費税額
                    'B_TAX_T.Text = String.Format("{0:#,##0}", oOrderData(0).sTaxTotal)
                    ''軽減税額
                    'B_RTAX_T.Text = String.Format("{0:#,##0}", oOrderData(0).sReducedTaxRateTotal)
                    ''値引きの数値変換
                    'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sDiscount)
                    ''ポイント値引きの数値変換
                    'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", oOrderData(0).sPointDisCount)
                    ''税込合計の数値変換
                    'B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", oOrderData(0).sTotalPrice)


                    '2019,11,1 A.Komita 修正 Start-----------------------------------------------------

                    ''商品代金
                    'B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", S_B_BREFORE_PRODUCT_T)
                    ''送料の数値変換
                    'B_POSTAGE_T.Text = String.Format("{0:#,##0}", S_B_POSTAGE_T)
                    ''手数料の数値変換
                    'B_FEE_T.Text = String.Format("{0:#,##0}", S_B_FEE_T)
                    ''税抜き請求金額
                    'B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", S_B_BEFORE_BILL_PRICE_T)
                    ''消費税額
                    'B_TAX_T.Text = String.Format("{0:#,##0}", S_B_TAX_T)
                    ''軽減税額
                    'B_RTAX_T.Text = String.Format("{0:#,##0}", S_B_RTAX_T)
                    ''値引きの数値変換
                    'B_DISCOUNT_T.Text = String.Format("{0:#,##0}", S_B_DISCOUNT_T)
                    ''ポイント値引きの数値変換
                    'B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", S_B_POINT_DISCOUNT_T)
                    ''税込合計の数値変換
                    'B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", S_B_AFTER_BILL_PRICE_T)

                    '2019,11,1 A.Komita 修正 End--------------------------------------------------------

                End If
            End If
    End Sub

    '*************************************************
    'HERE
    '*************************************************


    '2019.11.20 R.Takashima FROM
    '既納入情報欄を別のメソッドに分ける
Private Sub B_TEXT_INIT(ByVal ChangeMode As Boolean, ByVal ArrivalData() As cStructureLib.sViewArriveDataFull)
        Dim ArrivalTax As Integer = 0
        Dim bTaxKeep As Integer = 0
        Dim bRtaxKeep As Integer = 0
        Dim bPostage As Integer = 0
        Dim bFee As Integer = 0

        ORDER_DATA()
        ORDER_SUB_DATA()
        ARRIVAL_DATA()

        '2019,12,13 A.Komita 注文番号を読み込む前に税モード切替を行った時、下記if文で例外が発生する為意図的に処理を終了させる From
        If SUPPLIER_T.Text = "" And ChangeMode = True Then
            STOP_VALUE = True
            Exit Sub
        End If

        If B_BREFORE_PRODUCT_T.Text = 0 Then
            ARRIVE_COUNT_T.Text = 1
        End If
        '2019,12,13 A.Komita 追加 To

        Try
            '前回の入庫データがない場合 
            If IsNothing(ArrivalData) = True Or oOrderSubData(0).sOrderCode <> ArrivalData(0).sOrderCode Then

                '完納フラグ
                FINISH_C.Checked = False
                '納入回数
                ARRIVE_COUNT_T.Text = 1
                '商品代金
                B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", 0)
                '送料の数値変換
                B_POSTAGE_T.Text = String.Format("{0:#,##0}", 0)
                '手数料の数値変換
                B_FEE_T.Text = String.Format("{0:#,##0}", 0)
                '税抜き請求金額
                B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", 0)
                '消費税額
                B_TAX_T.Text = String.Format("{0:#,##0}", 0)
                '軽減税額
                B_RTAX_T.Text = String.Format("{0:#,##0}", 0)
                '値引きの数値変換
                B_DISCOUNT_T.Text = String.Format("{0:#,##0}", 0)
                'ポイント値引きの数値変換
                B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", 0)
                '税込み請求金額
                B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", 0)


                '前回のデータがあり、税込みモードの場合
            ElseIf AFTER_TAX_R.Checked = True Then

                '完納フラグ
                FINISH_C.Checked = oArriveDataFull(0).sFinishFlg
                '納入回数
                ARRIVE_COUNT_T.Text = oArriveDataFull(0).sArrivalNo + 1
                '商品代金
                bPostage = oTool.BeforeToTax(ArrivalData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc)
                bFee = oTool.BeforeToTax(ArrivalData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc)
                bTaxKeep = oArrivalData(0).sTaxTotal - bPostage - bFee
                bRtaxKeep = oArrivalData(0).sReducedTaxRate
                B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sNoTaxTotalProductPrice + bTaxKeep + bRtaxKeep)
                '送料の数値変換
                B_POSTAGE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(ArrivalData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc))
                '手数料の数値変換
                B_FEE_T.Text = String.Format("{0:#,##0}", oTool.BeforeToAfterTax(ArrivalData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc))
                '税抜き請求金額
                B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", CLng(B_BREFORE_PRODUCT_T.Text) + CLng(B_POSTAGE_T.Text) + CLng(B_FEE_T.Text))
                '消費税額
                B_TAX_T.Text = String.Format("{0:#,##0}", 0)
                '軽減税額
                B_RTAX_T.Text = String.Format("{0:#,##0}", 0)
                '値引きの数値変換
                B_DISCOUNT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sDiscount)
                'ポイント値引きの数値変換
                B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sPointDisCount)
                '税込合計の数値変換
                B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", CLng(B_BEFORE_BILL_PRICE_T.Text)) +
                                                            ArrivalData(0).sDiscount +
                                                            ArrivalData(0).sPointDisCount



                '2019,12,5 A.Komita グリッドビューに発注中止事由を表示させる為に追加 From
                For i = 0 To ORDER_V.Rows.Count - 1

                    If oOrderSubData(0).sCancelReason <> String.Empty Then
                        ORDER_V("発注中止事由", i).Value = oOrderSubData(i).sCancelReason

                    End If
                Next
                '2019,12,5 A.Komita 追加 To


                '前回のデータがあり、税抜きモードの場合
            ElseIf AFTER_TAX_R.Checked = False Then

                '完納フラグ
                FINISH_C.Checked = oArriveDataFull(0).sFinishFlg
                '納入回数
                ARRIVE_COUNT_T.Text = oArriveDataFull(0).sArrivalNo + 1
                '商品代金
                B_BREFORE_PRODUCT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sNoTaxTotalProductPrice)
                '送料の数値変換
                B_POSTAGE_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sShippingCharge)
                '手数料の数値変換
                B_FEE_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sPaymentCharge)
                '税抜き請求金額
                B_BEFORE_BILL_PRICE_T.Text = String.Format("{0:#,##0}", CLng(B_BREFORE_PRODUCT_T.Text) + CLng(B_POSTAGE_T.Text) + CLng(B_FEE_T.Text))
                '消費税額
                B_TAX_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sTaxTotal)
                '軽減税額
                B_RTAX_T.Text = String.Format("{0:#,##0}", oArrivalData(0).sReducedTaxRate)
                '値引きの数値変換
                B_DISCOUNT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sDiscount)
                'ポイント値引きの数値変換
                B_POINT_DISCOUNT_T.Text = String.Format("{0:#,##0}", ArrivalData(0).sPointDisCount)
                '税込合計の数値変換
                B_AFTER_BILL_PRICE_T.Text = String.Format("{0:#,##0}", CLng(B_BEFORE_BILL_PRICE_T.Text)) +
                                                                    ArrivalData(0).sTaxTotal +
                                                                    oArrivalData(0).sReducedTaxRate +
                                                                    ArrivalData(0).sDiscount +
                                                                    ArrivalData(0).sPointDisCount


                '2019,12,5 A.Komita グリッドビューに発注中止事由を表示させる為に追加 From
                For i = 0 To ORDER_V.Rows.Count - 1

                    If oOrderSubData(0).sCancelReason <> String.Empty Then
                        ORDER_V("発注中止事由", i).Value = oOrderSubData(i).sCancelReason

                    End If
                Next
                '2019,12,5 A.Komita 追加 To



            End If

        Catch

        End Try

    End Sub

    '2019.11.20 R.Takashima TO



    Private Function UPDATE_ORDER_V(ByVal JanCode As String) As Boolean
        Dim i As Integer
        Dim cnt As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim SelectJAN_form As cSelectLib.fSelectJAN
        Dim PRODUCT_CODE As String


        'JANコード重複の確認
        cnt = 0
        PRODUCT_CODE = ""
        For i = 0 To ORDER_V.Rows.Count - 1
            If ORDER_V("JANコード", i).Value = JanCode Then
                cnt = cnt + 1
                PRODUCT_CODE = ORDER_V("商品コード", i).Value
            End If
        Next
        Select Case cnt
            Case 0
                'JANコード該当なし→メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "該当JANコードが",
                                                "発注データに存在しません",
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing

                JANCODE_T.Text = ""
                COUNT_T.Text = 1
                JANCODE_T.Focus()
                UPDATE_ORDER_V = False
                Exit Function
            Case 1

            Case Else
                'JANコード対象商品重複→メッセージウィンドウ表示
                SelectJAN_form = New cSelectLib.fSelectJAN(oConn, oCommand, oDataReader, Nothing, JanCode, oConf, oTran)
                SelectJAN_form.ShowDialog()
                PRODUCT_CODE = SelectJAN_form.PRODUCT_CODE_T.Text
        End Select
        For i = 0 To ORDER_V.Rows.Count - 1


            If ORDER_V("JANコード", i).Value = JanCode And ORDER_V("商品コード", i).Value = PRODUCT_CODE Then
                'カレントセルの変更
                ORDER_V.CurrentCell = ORDER_V("納入数", i)
                If ORDER_V("納入残", i).Value = 0 Then
                    '納入残が０の場合→メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "納入済みデータです",
                                                    "再度ご確認下さい",
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing

                    JANCODE_T.Text = ""
                    COUNT_T.Text = 1
                    JANCODE_T.Focus()
                    Exit Function
                End If
                IVENT_STOP = True

                '2019,11,15 A.Komita 追加 From

                If COUNT_T.Text > ORDER_V("納入残", i).Value Then
                    Message_form = New cMessageLib.fMessage(1, "入庫数量が超過しています",
                                                   "再度ご確認下さい",
                                                   Nothing, Nothing)
                    Message_form.ShowDialog()

                    If Message_form.DialogResult = DialogResult.OK Then
                        Return (False)
                        Message_form = Nothing


                    End If
                End If
                '2019,11,5 A.Komita 追加 To

                '納入数更新
                ORDER_V("納入数", i).Value = CInt(ORDER_V("納入数", i).Value) + CInt(COUNT_T.Text)

                'CAL_PROC(False, False)

                IVENT_STOP = False

            End If
        Next
        JANCODE_T.Text = ""
        COUNT_T.Text = 1
        JANCODE_T.Focus()
        UPDATE_ORDER_V = True

    End Function

    '****************
    '在庫マスタ更新
    '****************
    Private Sub UPDATE_ALL_ARRIVE_DATE(ByVal OrderCode As String)
        Dim oDataOrderDBIO As cDataOrderDBIO
        Dim ret As Boolean

        '発注情報データ⇒完納日の更新
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        ret = oDataOrderDBIO.updateAllArrivedDate(OrderCode, String.Format("{0:yyyy/MM/dd}", Now), oTran)
    End Sub
    '****************
    '在庫マスタ更新
    '****************
    Private Function UPDATE_STOCK() As Long
        Dim i As Integer
        Dim ret As Boolean
        Dim sCount As Integer
        Dim RecordCount As Integer
        Dim oStock() As cStructureLib.sStock      '登録用
        Dim pStock() As cStructureLib.sStock      '現行在庫数取得用
        Dim UpdateCount As Long

        UpdateCount = 0

        '読込みバッファーのクリア
        ReDim oStock(0)

        For i = 0 To ORDER_V.Rows.Count - 1
            '現在の在庫マスタデータの読込み 
            ReDim pStock(0)
            RecordCount = oMstStockDBIO.getStock(pStock, ORDER_V("商品コード", i).Value, oTran)
            If CInt(ORDER_V("納入数", i).Value) > 0 Then
                '現行在庫数の退避
                sCount = pStock(0).sStockCount

                '商品コード
                oStock(0).sProductCode = ORDER_V("商品コード", i).Value
                '在庫数
                oStock(0).sStockCount = sCount + ORDER_V("納入数", i).Value

                ret = oMstStockDBIO.updateStock(oStock, oTran)

                UpdateCount = UpdateCount + 1
            End If
        Next

        UPDATE_STOCK = UpdateCount
    End Function


    Private Sub ARRIVAL_INSERT(ByRef OrderNo As String)
        Dim ret As Boolean
        Dim sProduct As Long
        Dim sPostage As Long
        Dim sFee As Long
        Dim sDiscount As Long
        Dim sPointDiscount As Long
        Dim sBeforePrice As Long
        Dim sAfterPrice As Long
        Dim sPostageTaxKeep As Long
        Dim sFeeTaxKeep As Long
        Dim sTaxKeep As Long
        Dim sRtaxKeep As Long



        '2015/06/24
        '及川和彦
        '入庫登録の際に、税モードが税込みならば、税込みで、税抜きならば税抜きでデータベースに
        '登録されてしまうため、追加
        'FROM
        '----------------------------------------------------------------------------------
        ' AFTER_TAX_R.Checked = True

        '入庫税抜商品金額
        sProduct = CLng(T_BREFORE_PRODUCT_T.Text)
        '送料
        sPostage = CLng(T_POSTAGE_T.Text)
        '手数料
        sFee = CLng(T_FEE_T.Text)
        '値引き
        sDiscount = CLng(T_DISCOUNT_T.Text)
        'ポイント値引き
        sPointDiscount = CLng(T_POINT_DISCOUNT_T.Text)
        '入庫税抜金額
        sBeforePrice = CLng(T_BEFORE_BILL_PRICE_T.Text)
        '入庫税込金額
        sAfterPrice = CLng(T_AFTER_BILL_PRICE_T.Text)

        'BEFORE_TAX_R.Checked = True

        '----------------------------------------------------------------------------------
        'HERE
        '----------------------------------------------------------------------------------



        ARRIVAL_NO = oDataArrivalDBIO.getMaxArrivalNo(oArrivalData, oOrderDataFull(0).sOrderCode, oTran)
        If ARRIVAL_NO > 0 Then
            ARRIVAL_NO = ARRIVAL_NO + 1
        Else
            ARRIVAL_NO = 1
        End If

        ReDim oArrivalData(0)

        '発注コード
        oArrivalData(0).sOrderCode = OrderNo
        '入庫番号
        oArrivalData(0).sArrivalNo = ARRIVAL_NO
        '入庫日
        oArrivalData(0).sArrivalDate = ARRIVAL_DATE_T.Text
        '仕入先コード
        oArrivalData(0).sSupplierCode = oOrderDataFull(0).sSupplierCode
        '支払方法コード
        oArrivalData(0).sPaymentCode = oOrderDataFull(0).sPaymentCode
        '完納フラグ
        oArrivalData(0).sFinishFlg = FINISH_C.Checked
        '入庫担当者コード
        oArrivalData(0).sStaffCode = STAFF_CODE_T.Text



        '----------------------------------------------------------------------------------
        '2015/06/24
        '及川和彦
        '入庫登録の際に、税モードが税込みならば、税込みで、税抜きならば税抜きでデータベースに
        '登録されてしまうため、追加
        'FROM
        '----------------------------------------------------------------------------------

        If AFTER_TAX_R.Checked = True Then '税込モードで登録をする時に税抜きに直す  

            ORDER_SUB_DATA()

            '2019,11,17 A.Komita 消費税額と軽減税額を変数に保持させるコードを追加 From
            For i = 0 To ORDER_V.Rows.Count - 1

                '入庫税抜商品金額
                If ORDER_V("納入数", i).Value <> 0 Then
                    If oOrderSubData(i).sReducedTaxRate = String.Empty Then
                        oArrivalData(0).sNoTaxTotalProductPrice += oTool.AfterToBeforeTax(CLng(ORDER_V("納入金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        sTaxKeep += oTool.AfterToTax(CLng(ORDER_V("納入金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Else
                        oArrivalData(0).sNoTaxTotalProductPrice += oTool.AfterToBeforeTax(CLng(ORDER_V("納入金額", i).Value), oOrderSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        sRtaxKeep += oTool.AfterToTax(CLng(ORDER_V("納入金額", i).Value), oOrderSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                    End If
                End If
            Next

            '2019,11,17 A.Komita 追加 To

            '2019,11,20 A.Komita 送料と手数料の消費税額を変数に保持させるコードを追加 From
            '送料
            If T_POSTAGE_T.Text <> 0 Then
                oArrivalData(0).sShippingCharge = oTool.AfterToBeforeTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                sPostageTaxKeep = oTool.AfterToTax(CLng(T_POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            End If
            '手数料
            If T_FEE_T.Text <> 0 Then
                oArrivalData(0).sPaymentCharge = oTool.AfterToBeforeTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                sFeeTaxKeep = oTool.AfterToTax(CLng(T_FEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            End If
            '2019,11,20 A.Komita 追加 To

            '入庫税抜金額
            oArrivalData(0).sNoTaxTotalPrice = oArrivalData(0).sNoTaxTotalProductPrice + oArrivalData(0).sShippingCharge + oArrivalData(0).sPaymentCharge

            '入庫消費税額　消費税額を保持した変数をここで使用
            oArrivalData(0).sTaxTotal = sTaxKeep + sPostageTaxKeep + sFeeTaxKeep

            '2019,10,3 A.Komita 追加 From
            '入庫軽減税額　軽減税額を保持した変数をここで使用
            oArrivalData(0).sReducedTaxRate = sRtaxKeep
            '2019,10,3 A.Komita 追加 To

            '値引き
            If T_DISCOUNT_T.Text <> 0 Then
                oArrivalData(0).sDiscount = CLng(T_DISCOUNT_T.Text)
            End If
            'ポイント値引き
            If T_POINT_DISCOUNT_T.Text <> 0 Then
                oArrivalData(0).sPointDisCount = CLng(T_POINT_DISCOUNT_T.Text)
            End If

            '入庫税込金額
            oArrivalData(0).sTotalPrice = (oArrivalData(0).sNoTaxTotalPrice + oArrivalData(0).sTaxTotal + oArrivalData(0).sReducedTaxRate) +
                                          (oArrivalData(0).sDiscount + oArrivalData(0).sPointDisCount)

        Else

            '入庫税抜商品金額
            oArrivalData(0).sNoTaxTotalProductPrice = (CLng(T_BREFORE_PRODUCT_T.Text))
            '送料
            If T_POSTAGE_T.Text <> 0 Then
                oArrivalData(0).sShippingCharge = CLng(T_POSTAGE_T.Text)
            End If
            '手数料
            If T_FEE_T.Text <> 0 Then
                oArrivalData(0).sPaymentCharge = CLng(T_FEE_T.Text)
            End If

            '入庫税抜金額
            oArrivalData(0).sNoTaxTotalPrice = CLng(T_BEFORE_BILL_PRICE_T.Text)

            '入庫消費税額
            oArrivalData(0).sTaxTotal = CLng(T_TAX_T.Text)

            '2019,10,3 A.Komita 追加 From
            '入庫軽減税額
            oArrivalData(0).sReducedTaxRate = CLng(T_RTAX_T.Text)
            '2019,10,3 A.Komita 追加 To

            '値引き
            If T_DISCOUNT_T.Text <> 0 Then
                oArrivalData(0).sDiscount = CLng(T_DISCOUNT_T.Text)
            End If
            'ポイント値引き
            If T_POINT_DISCOUNT_T.Text <> 0 Then
                oArrivalData(0).sPointDisCount = CLng(T_POINT_DISCOUNT_T.Text)
            End If

            '入庫税込金額
            oArrivalData(0).sTotalPrice = sAfterPrice

        End If
        '----------------------------------------------------------------------------------
        'HERE
        '----------------------------------------------------------------------------------

        ret = oDataArrivalDBIO.insertArrivalData(oArrivalData(0), oTran)
        If ret = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "入庫情報データの挿入に失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.Show()
            Application.DoEvents()
            Message_form = Nothing
        End If
    End Sub

    Private Function ARRIVAL_SUB_INSERT() As Integer
        Dim ret As Boolean
        Dim i As Integer
        Dim Rest As Integer

        ReDim oArrivalSubData(0)

        Rest = 0

        For i = 0 To ORDER_V.Rows.Count - 1

            '発注コード
            oArrivalSubData(0).sOrderCode = oOrderSubData(i).sOrderCode
            '発注明細コード
            oArrivalSubData(0).sOrderDetailNo = oOrderSubData(i).sOrderSubCode
            '入庫番号
            oArrivalSubData(0).sArrivalNo = ARRIVAL_NO
            'JANコード
            oArrivalSubData(0).sJANCode = oOrderSubData(i).sJANCode
            '商品コード
            oArrivalSubData(0).sProductCode = oOrderSubData(i).sProductCode
            '商品名称
            oArrivalSubData(0).sProductName = oOrderSubData(i).sProductName
            'オプション1
            oArrivalSubData(0).sOption1 = oOrderSubData(i).sOption1
            'オプション2
            oArrivalSubData(0).sOption2 = oOrderSubData(i).sOption2
            'オプション3
            oArrivalSubData(0).sOption3 = oOrderSubData(i).sOption3
            'オプション4
            oArrivalSubData(0).sOption4 = oOrderSubData(i).sOption4
            'オプション5
            oArrivalSubData(0).sOption5 = oOrderSubData(i).sOption5
            '定価
            oArrivalSubData(0).sListPrice = oOrderSubData(i).sListPrice
            '仕入単価
            If AFTER_TAX_R.Checked = True Then
                oArrivalSubData(0).sCostPrice = oTool.AfterToBeforeTax(CLng(ORDER_V("発注単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
            Else
                oArrivalSubData(0).sCostPrice = CLng(ORDER_V("発注単価", i).Value)
            End If
            '入庫商品単価
            If AFTER_TAX_R.Checked = True Then
                oArrivalSubData(0).sUnitPrice = oTool.AfterToBeforeTax(CLng(ORDER_V("納入単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
            Else
                oArrivalSubData(0).sUnitPrice = CLng(ORDER_V("納入単価", i).Value)
            End If
            '入庫数量
            oArrivalSubData(0).sCount = CInt(ORDER_V("納入数", i).Value)


            '----------------------------------------------------
            '2015/06/27
            '及川和彦
            '入庫情報データに登録された、入庫税込金額が正しくないため、修正
            'FROM
            '----------------------------------------------------

            '2019,10,3 A.Komita 追加 From
            '入庫税込金額
            If ORDER_V_VALUE(i) > 0 Then

                If ORDER_V_MODE(i) = True Then

                    oArrivalSubData(0).sPrice = ORDER_V_VALUE(i) * oArrivalSubData(0).sCount

                Else
                    If oOrderSubData(0).sReducedTaxRate = String.Empty Then

                        oArrivalSubData(0).sPrice = oTool.BeforeToAfterTax(ORDER_V_VALUE(i), oConf(0).sTax, oConf(0).sFracProc) * oArrivalSubData(0).sCount
                    Else
                        oArrivalSubData(0).sPrice = oTool.BeforeToAfterTax(ORDER_V_VALUE(i), oOrderSubData(0).sReducedTaxRate, oConf(0).sFracProc) * oArrivalSubData(0).sCount
                    End If

                End If

                '入庫税抜金額
                If oOrderSubData(0).sReducedTaxRate = String.Empty Then

                    oArrivalSubData(0).sNoTaxPrice = oTool.AfterToBeforeTax(ORDER_V_VALUE(i), oConf(0).sTax, oConf(0).sFracProc) * oArrivalSubData(0).sCount
                Else
                    oArrivalSubData(0).sNoTaxPrice = oTool.AfterToBeforeTax(ORDER_V_VALUE(i), oOrderSubData(0).sReducedTaxRate, oConf(0).sFracProc) * oArrivalSubData(0).sCount
                End If

            Else

                If AFTER_TAX_R.Checked = True Then

                    If oOrderSubData(0).sReducedTaxRate = String.Empty Then

                        oArrivalSubData(0).sPrice = CLng(ORDER_V("納入単価", i).Value) * oArrivalSubData(0).sCount

                        '入庫税抜金額
                        oArrivalSubData(0).sNoTaxPrice = oTool.AfterToBeforeTax(CLng(ORDER_V("納入単価", i).Value), oConf(0).sTax, oConf(0).sFracProc) * oArrivalSubData(0).sCount

                    Else
                        oArrivalSubData(0).sPrice = CLng(ORDER_V("納入単価", i).Value) * oArrivalSubData(0).sCount

                        '入庫税抜金額
                        oArrivalSubData(0).sNoTaxPrice = oTool.AfterToBeforeTax(CLng(ORDER_V("納入単価", i).Value), oOrderSubData(0).sReducedTaxRate, oConf(0).sFracProc) * oArrivalSubData(0).sCount

                    End If

                Else
                    If oOrderSubData(0).sReducedTaxRate = String.Empty Then

                        oArrivalSubData(0).sPrice = oTool.BeforeToAfterTax(CLng(ORDER_V("納入単価", i).Value), oConf(0).sTax, oConf(0).sFracProc) * oArrivalSubData(0).sCount

                        '入庫税抜金額
                        oArrivalSubData(0).sNoTaxPrice = CLng(ORDER_V("納入単価", i).Value) * oArrivalSubData(0).sCount

                    Else

                        oArrivalSubData(0).sPrice = oTool.BeforeToAfterTax(CLng(ORDER_V("納入単価", i).Value), oOrderSubData(0).sReducedTaxRate, oConf(0).sFracProc) * oArrivalSubData(0).sCount

                        '入庫税抜金額
                        oArrivalSubData(0).sNoTaxPrice = CLng(ORDER_V("納入単価", i).Value) * oArrivalSubData(0).sCount

                    End If
                    '2019,10,3 A.Komita 追加 To

                End If
            End If

            '入庫消費税額
            oArrivalSubData(0).sTaxPrice = oOrderData(0).sTaxTotal


            '2019,10,3 A.Komita 追加 From
            '入庫軽減税額
            oArrivalSubData(0).sReducedTaxRate = oOrderData(0).sReducedTaxRateTotal


            'oArrivalSubData(0).sPrice - oArrivalSubData(0).sNoTaxPrice - oArrivalSubData(0).sTaxPrice
            '2019,10,3 A.Komita 追加 To

            '----------------------------------------------------
            'HERE
            '----------------------------------------------------



            '納入残数
            oArrivalSubData(0).sArrivalStiffness = CInt(ORDER_V("納入残", i).Value)

            Rest = Rest + oArrivalSubData(0).sArrivalStiffness
            'データ書込み
            ret = oDataArrivalSubDBIO.insertArrivalSubData(oArrivalSubData(0), oTran)
        Next i

        ARRIVAL_SUB_INSERT = Rest

    End Function




    Private Sub ORDER_V_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles ORDER_V.CellDoubleClick
        Dim Message_form As cMessageLib.fMessage
        Dim fOrderCancel_form As New cMasterMenteLib.fOrderCancel(
                    oConn,
                    oCommand,
                    oDataReader,
                    ORDER_CODE_T.Text,
                    ORDER_V("発注明細コード", ORDER_V.CurrentRow.Index).Value,
                    STAFF_CODE,
                    STAFF_NAME,
                    oTran
        )



        '----------------------------------------------------
        '2015/06/28
        '及川和彦
        'ダブルクリック後に「入庫」ボタンをクリックすると、
        '2回入庫された状態になるため、ChangeValueを無効化するために追加
        'FROM
        '----------------------------------------------------
        STOP_VALUE = True
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------


        fOrderCancel_form.ShowDialog()

        Select Case fOrderCancel_form.DialogResult
            Case DialogResult.OK
                ORDER_DETAIL_LINE_UPDATE(ORDER_V.CurrentRow.Index, ORDER_CODE_T.Text, ORDER_V("発注明細コード", ORDER_V.CurrentRow.Index).Value)

                '----------------------------------------------------
                '2015/06/21
                '及川和彦
                'データベース読み込みの追加
                'FROM
                '----------------------------------------------------
            Case DialogResult.Abort
                ORDER_DETAIL_CANCEL_UPDATE(ORDER_V.CurrentRow.Index, ORDER_CODE_T.Text, ORDER_V("発注明細コード", ORDER_V.CurrentRow.Index).Value)
                COMMIT_B.Enabled = True
            Case DialogResult.Yes

                'TODO:now 商品情報の取得
                Dim RecordCnt As Integer
                RecordCnt = oProductDBIO.getProduct(oProduct, Nothing, ORDER_V("商品コード", e.RowIndex).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                RecordCnt = oCostPriceDBIO.getPriceMst(oCostPrice, ORDER_V("商品コード", e.RowIndex).Value, SUPPLIER_CODE, oTran)


                'TODO:now 商品情報を画面に設定する
                ORDER_V("JANコード", ORDER_V.CurrentRow.Index).Value = oProduct(0).sJANCode
                ORDER_V("商品名称", ORDER_V.CurrentRow.Index).Value = oProduct(0).sProductName
                ORDER_V("発注中止事由", ORDER_V.CurrentRow.Index).Value = oOrderSubData(0).sCancelReason

                'TODO:now オプションの設定
                Dim wString As String
                wString = oProduct(0).sOption1

                If oProduct(0).sOption2 <> "" Then
                    wString = wString & ":" & oProduct(0).sOption2
                End If
                If oProduct(0).sOption3 <> "" Then
                    wString = wString & ":" & oProduct(0).sOption3
                End If
                If oProduct(0).sOption4 <> "" Then
                    wString = wString & ":" & oProduct(0).sOption4
                End If
                If oProduct(0).sOption5 <> "" Then
                    wString = wString & ":" & oProduct(0).sOption5
                End If
                ORDER_V("オプション", ORDER_V.CurrentRow.Index).Value = wString

                'TODO:now 納入単価の設定


                '今回納入情報の表示値を変更するため、一時的にChangeValueを許可する
                STOP_VALUE = False

                ORDER_DETAIL_ARRIVAL_UPDATE(ORDER_V.CurrentRow.Index, ORDER_CODE_T.Text, ORDER_V("発注明細コード", ORDER_V.CurrentRow.Index).Value)

                STOP_VALUE = True
            Case DialogResult.No

            Case DialogResult.Cancel '中止解除を入力するとここに来る
                ORDER_V("発注中止事由", ORDER_V.CurrentRow.Index).Value = ""
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------

            Case DialogResult.Ignore

                If ORDER_V("納入残", ORDER_V.CurrentRow.Index).Value = 0 Then
                    '納入残が０の場合→メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "納入済みデータです",
                                                    "再度ご確認下さい",
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing

                    JANCODE_T.Text = ""
                    COUNT_T.Text = 1
                    JANCODE_T.Focus()
                    Exit Sub
                End If



                '合計納入金額算出
                'CAL_PROC(False)
                CAL_PROC(False, False)
                COMMIT_B.Enabled = True


        End Select

        STOP_VALUE = False

    End Sub




    Private Sub ORDER_V_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles ORDER_V.CellValueChanged
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim pProduct() As cStructureLib.sProduct
        Dim pProductDBIO As cMstProductDBIO
        Dim pCostPrice() As cStructureLib.sCostPrice
        Dim pCostPriceDBIO As cMstCostPriceDBIO
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim LestCnt As Integer


        '----------------------------------------------------
        '2015/06/28
        '及川和彦
        '納入単価、納入数、納入残の変更があった際に、複数回の処理を回避するため追加
        '例、納入数の値を変更した際に1回目、納入数が変わったことにより、変化した納入残により
        '2回目の処理が行われていた
        'FROM
        '----------------------------------------------------
        If STOP_VALUE = True Then
            Exit Sub
        End If

        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Select Case dgv.Columns(e.ColumnIndex).Name
            Case "JANコード"      'JANCODE変更
                IVENT_STOP = True
                '商品マスタJanCode更新の確認メッセージ
                Message_form = New cMessageLib.fMessage(2, "JanCodeが変更されました",
                                                "マスタのJanCodeを更新しますか？",
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                If Message_form.DialogResult = DialogResult.Yes Then
                    '商品マスタのJANコード更新
                    ReDim pProduct(0)
                    pProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
                    RecordCnt = pProductDBIO.getProduct(pProduct, Nothing, ORDER_V("商品コード", e.RowIndex).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                    pProduct(0).sJANCode = ORDER_V("JANコード", e.RowIndex).Value

                    'TODO:Transactionが渡っていない
                    'RecordCnt = pProductDBIO.updateProductMst(pProduct, Nothing)
                    RecordCnt = pProductDBIO.updateProductMst(pProduct, oTran)

                    pProductDBIO = Nothing
                    pProduct = Nothing
                End If
                Message_form = Nothing

                IVENT_STOP = False

            Case "納入単価"      '納入価格変更

                '----------------------------------------------------
                '2015/06/28
                '及川和彦
                '納入単価の変更値を保持
                'FROM
                '----------------------------------------------------
                UNIT_PRICE_PROC(ORDER_V.CurrentRow.Index)
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------

                If BEFORE_TAX_R.Checked = True Then
                    If ORDER_V("納入単価", e.RowIndex).Value = ORDER_V("画面読込み時の納入単価", e.RowIndex).Value Then
                        Exit Select
                    End If
                Else
                    If oTool.AfterToBeforeTax(ORDER_V("納入単価", e.RowIndex).Value, oConf(0).sTax, oConf(0).sFracProc) = ORDER_V("画面読込み時の納入単価", e.RowIndex).Value Then
                        Exit Select
                    End If
                End If
                IVENT_STOP = True
                '商品マスタ仕入価格更新の確認メッセージ

                '2019,11,17 A.Komita 価格変更の際、登録する価格が税込か税抜かを間違えない様にする為メッセージボックスを追加 From

                Message_form = New cMessageLib.fMessage(2, "税込モード→税込価格 税抜モード→税抜価格",
                                                "で修正していますか？",
                                                Nothing, Nothing)

                Message_form.ShowDialog()
                If Message_form.DialogResult = DialogResult.No Then
                    Return

                Else '2019,11,17 A.Komita 追加 To

                    Message_form = New cMessageLib.fMessage(2, "納入価格が変更されました",
                                                "マスタの仕入価格を更新しますか？",
                                                Nothing, Nothing)

                    Message_form.ShowDialog()

                    If Message_form.DialogResult = DialogResult.Yes Then
                        ReDim pCostPrice(0)

                        '仕入価格の更新
                        pCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
                        RecordCnt = pCostPriceDBIO.getPriceMst(pCostPrice, ORDER_V("商品コード", e.RowIndex).Value, SUPPLIER_CODE, oTran)

                        If BEFORE_TAX_R.Checked = True Then
                            pCostPrice(0).sCostPrice = ORDER_V("納入単価", e.RowIndex).Value
                        Else
                            '税込み金額⇒税抜き金額に変換
                            pCostPrice(0).sCostPrice = oTool.AfterToBeforeTax(CLng(ORDER_V("納入単価", e.RowIndex).Value), oConf(0).sTax, oConf(0).sFracProc)
                        End If

                        RecordCnt = pCostPriceDBIO.updatePriceMst(pCostPrice, oTran)
                        pCostPriceDBIO = Nothing
                        pCostPrice = Nothing

                    End If
                End If
                Message_form = Nothing

                '合計納入金額算出
                'CAL_PROC(False)
                CAL_PROC(False, False)

                COMMIT_B.Enabled = True

                IVENT_STOP = False
            Case "納入数"      '納入数変更
                IVENT_STOP = True
                If ORDER_V("納入残", e.RowIndex).Value = 0 Then
                    '納入残が０の場合→メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "納入済みデータです",
                                                    "再度ご確認下さい",
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing

                    STOP_VALUE = True

                    '入力された納入数を入力前の値に戻す
                    ORDER_V("納入数", e.RowIndex).Value = ORDER_V("直前の納入数", e.RowIndex).Value

                    STOP_VALUE = False

                    JANCODE_T.Text = ""
                    COUNT_T.Text = 1
                    IVENT_STOP = False
                    Exit Sub
                End If


                ''2019,10,10 A.Komita 修正 Start---------------------------------------

                '納入残更新
                LestCnt = CInt(ORDER_V("納入残", e.RowIndex).Value) - CInt(COUNT_T.Text)
                ORDER_V("納入残", e.RowIndex).Value = LestCnt

                ''2019,10,10 A.Komita 修正 End-----------------------------------------

                '入力された納入数をテンプエリアにセット
                ORDER_V("直前の納入数", e.RowIndex).Value = ORDER_V("納入数", e.RowIndex).Value

                CAL_PROC(False, False)

                COMMIT_B.Enabled = True

                IVENT_STOP = False
        End Select

        If REST_COUNT() = 0 Then
            FINISH_C.Checked = True
        End If


    End Sub
    Private Function REST_COUNT() As Long
        Dim i As Integer
        Dim cnt As Long

        cnt = 0
        For i = 0 To ORDER_V.Rows.Count - 1
            cnt = cnt + CLng(ORDER_V("納入残", i).Value)
        Next
        REST_COUNT = cnt
    End Function


    '税込み、税抜きの切り替え
    Private Sub AFTER_TAX_R_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AFTER_TAX_R.CheckedChanged


        If INIT_FLG = False Then
            Cal_Proc_View(True)
        End If


    End Sub



    Private Sub COMMIT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim UpdateCount As Long
        Dim oTagStatus As cStructureLib.sTagPrintStatus
        Dim ret As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim cnt As Integer

        '入庫数確認
        If ARRIVAL_CNT = 0 Then
            Message_form = New cMessageLib.fMessage(1, "登録データが存在しません。", "中止の場合は、「終了」ボタンを押下して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_BREFORE_PRODUCT_T.Focus()
            Exit Sub
        End If
        '必須確認
        If T_BREFORE_PRODUCT_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "入庫金額を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_BREFORE_PRODUCT_T.Focus()
            Exit Sub
        End If
        If T_TAX_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "入庫金額（消費税額）を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_TAX_T.Focus()
            Exit Sub
        End If
        If T_RTAX_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "入庫金額（軽減税額）を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_RTAX_T.Focus()
        End If
        If T_POSTAGE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "納入送料を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_POSTAGE_T.Focus()
            Exit Sub
        End If
        If T_FEE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "納入手数料を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            T_FEE_T.Focus()
            Exit Sub
        End If
        If ARRIVAL_DATE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "入庫日を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            ARRIVAL_DATE_T.Focus()
            Exit Sub
        End If

        'JANコード登録状況確認
        cnt = 0
        For i = 0 To ORDER_V.Rows.Count - 1
            If (ORDER_V("納入数", i).Value <> 0) Then
                If (ORDER_V("JANコード", i).Value.ToString.Length < 3) Then
                    Message_form = New cMessageLib.fMessage(1, "JANコード不正の商品があります",
                                                                "当該行をダブルクリックし",
                                                                "商品マスタにJANコードを登録して下さい",
                                                                Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing
                    ARRIVAL_DATE_T.Focus()
                    Exit Sub
                End If
            End If
        Next i

        '2019,10,17 A.Komita 追加 From
        Message_form = New cMessageLib.fMessage(2, "登録情報に相違ありませんか",
                                                           "分納の場合,送料,手数料,値引き,ポイント値引きは",
                                                           "手入力で修正する必要があります",
                                                           Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = DialogResult.No Then
            Return

        ElseIf Message_form.DialogResult = DialogResult.Yes Then

            '入庫情報明細データ登録
            i = ARRIVAL_SUB_INSERT()
            ARRIVAL_INSERT(ORDER_CODE_T.Text)

            '2019,10,17 A.Komita 追加 To


            '納入残が０の場合
            If i = 0 Then
                '発注情報データ⇒完納日の更新
                UPDATE_ALL_ARRIVE_DATE(ORDER_CODE_T.Text)
            End If

            '在庫マスタ更新
            UpdateCount = UPDATE_STOCK()

            'トランザクションのコミット
            oTran.Commit()

            If UpdateCount > 0 Then
                'タグ印刷


                Message_form = New cMessageLib.fMessage(2, "タグを印刷しますか？",
                                "タグ印刷をキャンセルしても",
                                "データは更新されますのでご注意下さい。",
                                Nothing)
                Message_form.ShowDialog()
                If Message_form.DialogResult = DialogResult.Yes Then
                    Message_form.Dispose()
                    Message_form = Nothing
                    'バーコードタグ印刷
                    If cnt <> 0 Then
                        Message_form = New cMessageLib.fMessage(2, "バーコード付きのタグを印刷します。",
                                                       "A-One 31516用紙をセットして下さい。",
                                                       "準備が出来たら、""はい""を押下して下さい。",
                                                       Nothing)
                        Message_form.ShowDialog()

                        If Message_form.DialogResult = DialogResult.Yes Then
                            Message_form.Dispose()
                            Message_form = Nothing

                            Dim oReportPage = New cReportsLib.fTagReportPage(oConn, oCommand, oDataReader, Nothing, 1, oTran)
                            oReportPage.ShowDialog()
                            If oReportPage.DialogResult = DialogResult.Yes Then
                                '画面初期化
                                INIT_PROC(1)
                            End If
                            oReportPage.Dispose()
                            oReportPage = Nothing
                        End If
                    End If
                End If

            ElseIf Message_form.DialogResult = DialogResult.No Then


                'タグ出力テーブル更新
                oTagPrintStatusDBIO.deleteTagPrintStatus(Nothing)

                cnt = 0
                For i = 0 To ORDER_V.Rows.Count - 1
                    If (ORDER_V("納入数", i).Value <> 0) Then
                        If (ORDER_V("JANコード", i).Value.ToString.Substring(0, 3) = "999") Then
                            For j = 1 To ORDER_V("納入数", i).Value
                                oTagStatus.sProductCode = ORDER_V("商品コード", i).Value
                                oTagStatus.sCount = 1
                                oTagStatus.sTagPrintCheck = True
                                ret = oTagPrintStatusDBIO.insertTagPrintStatus(oTagStatus)
                                cnt = cnt + 1
                            Next j
                        End If
                    End If
                Next i

                '    'バーコードタグ印刷
                '    If cnt <> 0 Then
                '        Message_form = New cMessageLib.fMessage(2, "バーコード付きのタグを印刷します。",
                '                                       "A-One 31516用紙をセットして下さい。",
                '                                       "準備が出来たら、""はい""を押下して下さい。",
                '                                       Nothing)
                '        Message_form.ShowDialog()

                '        If Message_form.DialogResult = DialogResult.Yes Then
                '            Message_form.Dispose()
                '            Message_form = Nothing

                '            Dim oReportPage = New cReportsLib.fTagReportPage(oConn, oCommand, oDataReader, Nothing, 1, oTran)
                '            oReportPage.ShowDialog()
                '            If oReportPage.DialogResult = DialogResult.Yes Then
                '                '画面初期化
                '                INIT_PROC(1)
                '            End If
                '            oReportPage.Dispose()
                '            oReportPage = Nothing
                '        End If
                '    End If
                'End If

                'タグ出力テーブル更新
                oTagPrintStatusDBIO.deleteTagPrintStatus(Nothing)

                cnt = 0
                For i = 0 To ORDER_V.Rows.Count - 1

                    If (ORDER_V("注文数", i).Value <> 0) And (ORDER_V("JANコード", i).Value.ToString.Substring(0, 3) <> "999") Then
                        For j = 1 To ORDER_V("納入数", i).Value
                            oTagStatus.sProductCode = ORDER_V("商品コード", i).Value
                            oTagStatus.sCount = 1
                            oTagStatus.sTagPrintCheck = True
                            ret = oTagPrintStatusDBIO.insertTagPrintStatus(oTagStatus)
                            cnt = cnt + 1
                        Next j
                    End If
                Next i

                'バーコードタグ印刷
                If cnt <> 0 Then
                    Message_form = New cMessageLib.fMessage(2, "バーコード無しのタグを印刷します。",
                                              "A-One 28879用紙をセットして下さい。",
                                              "準備が出来たら、""はい""を押下して下さい。",
                                              Nothing)
                    Message_form.ShowDialog()

                    If Message_form.DialogResult = DialogResult.Yes Then
                        Message_form.Dispose()
                        Message_form = Nothing

                        Dim oReportPage = New cReportsLib.fTagReportPage(oConn, oCommand, oDataReader, Nothing, 2, oTran)
                        oReportPage.ShowDialog()
                        If oReportPage.DialogResult = DialogResult.Yes Then
                            '画面初期化
                            INIT_PROC(1)
                        End If
                        oReportPage.Dispose()
                        oReportPage = Nothing
                    End If
                End If
            Else
                '画面初期化
                INIT_PROC(1)
            End If

        Else
            Message_form = New cMessageLib.fMessage(2, "更新対象のデータが存在しません",
                                "画面をクリアしてよろしいですか？",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = DialogResult.Yes Then
                '画面初期化
                INIT_PROC(1)
            End If
            Message_form.Dispose()
            Message_form = Nothing
        End If

        '画面初期化
        INIT_PROC(1)

        'TODO:税モード
        'BEFORE_TAX_R.Checked = True


    End Sub

    Private Sub RETURN_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RETURN_B.Click
        Dim i As Integer
        Dim Message_form As cMessageLib.fMessage

        For i = 0 To ORDER_V.Rows.Count - 1
            If ORDER_V("JANコード", i).Value <> ORDER_V("画面読込み時のJANコード", i).Value _
                Or ORDER_V("納入単価", i).Value <> ORDER_V("画面読込み時の納入単価", i).Value _
                Or ORDER_V("納入数", i).Value <> ORDER_V("画面読込み時の納入残数", i).Value Then

                Message_form = New cMessageLib.fMessage(2, "データが変更されています。",
                                                            "登録せずに終了してよろしいですか？",
                                                            Nothing,
                                                            Nothing)

                Message_form.ShowDialog()
                If Message_form.DialogResult = DialogResult.No Then
                    Message_form = Nothing
                    Exit Sub
                Else
                    Me.DialogResult = DialogResult.Cancel
                    Me.Dispose()
                    Exit Sub
                End If
            End If
        Next
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
        Exit Sub

    End Sub


    '-------------------------------------------------------
    '2015/06/18　及川和彦
    '送料追加時の請求金額への反映
    '合計納入金額算出
    'FROM
    '-------------------------------------------------------
    Private Sub T_POSTAGE_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_POSTAGE_T.KeyPress

        POSTAGE_SWITCH = True
        If AFTER_TAX_R.Checked = True Then
            POSTAGE_MODE = True
        Else
            POSTAGE_MODE = False
        End If
    End Sub
    Private Sub T_POSTAGE_T_LostFocus(sender As Object, e As EventArgs) Handles T_POSTAGE_T.LostFocus
        If POSTAGE_SWITCH = True Then
            If T_POSTAGE_T.Text = "" Then
                T_POSTAGE_T.Text = 0
            End If

            POSTAGE_VALUE = String.Format("{0:c}", CLng(T_POSTAGE_T.Text))

            CAL_PROC(False, True)

            T_POSTAGE_T.Text = CLng(T_POSTAGE_T.Text)
            POSTAGE_SWITCH = False
        End If

    End Sub

    Private Sub T_FEE_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_FEE_T.KeyPress
        FEE_SWITCH = True
        If AFTER_TAX_R.Checked = True Then
            FEE_MODE = True
        Else
            FEE_MODE = False
        End If
    End Sub
    Private Sub T_FEE_T_LostFocus(sender As Object, e As EventArgs) Handles T_FEE_T.LostFocus
        If FEE_SWITCH = True Then
            If T_FEE_T.Text = "" Then
                T_FEE_T.Text = 0
            End If
            FEE_VALUE = String.Format("{0:c}", CLng(T_FEE_T.Text))

            CAL_PROC(False, True)

            T_FEE_T.Text = CLng(T_FEE_T.Text)
            FEE_SWITCH = False
        End If
    End Sub

    Private Sub T_DISCOUNT_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_DISCOUNT_T.KeyPress
        DISCOUNT_SWITCH = True
        If AFTER_TAX_R.Checked = True Then
            DISCOUNT_MODE = True
        Else
            DISCOUNT_MODE = False
        End If
    End Sub

    Private Sub T_DISCOUNT_T_LostFocus(sender As Object, e As EventArgs) Handles T_DISCOUNT_T.LostFocus
        If DISCOUNT_SWITCH = True Then
            If T_DISCOUNT_T.Text = "" Then
                T_DISCOUNT_T.Text = 0
            End If
            DISCOUNT_VALUE = String.Format("{0:c}", CLng(T_DISCOUNT_T.Text))

            CAL_PROC(False, True)

            T_DISCOUNT_T.Text = CLng(T_DISCOUNT_T.Text)

            DISCOUNT_SWITCH = False
        End If
    End Sub

    Private Sub T_POINT_DISCOUNT_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_POINT_DISCOUNT_T.KeyPress
        POINT_DISCOUNT_SWITCH = True
        If AFTER_TAX_R.Checked = True Then
            POINT_DISCOUNT_MODE = True
        Else
            POINT_DISCOUNT_MODE = False
        End If
    End Sub

    Private Sub T_POINT_DISCOUNT_T_LostFocus(sender As Object, e As EventArgs) Handles T_POINT_DISCOUNT_T.LostFocus
        If POINT_DISCOUNT_SWITCH = True Then
            If T_POINT_DISCOUNT_T.Text = "" Then
                T_POINT_DISCOUNT_T.Text = 0
            End If

            POINT_DISCOUNT_VALUE = String.Format("{0:c}", CLng(T_POINT_DISCOUNT_T.Text))

            CAL_PROC(False, True)

            T_POINT_DISCOUNT_T.Text = CLng(T_POINT_DISCOUNT_T.Text)

            POINT_DISCOUNT_SWITCH = False
        End If
    End Sub

    Private Function ORDER_DATA() As Long
        Dim RecordCnt As Integer

        RecordCnt = oDataOrderDBIO.getOrderData(oOrderData, ORDER_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

    End Function

    Private Function ORDER_SUB_DATA() As Long
        Dim RecordCnt As Integer

        RecordCnt = oDataOrderSubDBIO.getOrderSubData(oOrderSubData, ORDER_CODE_T.Text, Nothing, oTran)

    End Function

    Private Function ARRIVAL_DATA() As Long
        Dim RecordCnt As Integer

        RecordCnt = oDataArrivalDBIO.getArrivalData(oArrivalData, ORDER_CODE_T.Text, Nothing, Nothing, oTran)

    End Function

    'Orderで税抜登録→Arrivalのデフォルトが税込なので発注単価と納入単価を税込にするメソッド
    Private Sub Cal_Proc_View(ByVal stopValue As Boolean)
        STOP_VALUE = stopValue

        '2019.11.20 R.Takashima FROM
        '既納入情報入力
        B_TEXT_INIT(True, oArriveDataFull)
        '2019.11.20 R.Takashima TO

        CAL_PROC(True, False)
        STOP_VALUE = False
    End Sub

    '-------------------------------------------------------
    'HERE
    '-------------------------------------------------------

End Class
