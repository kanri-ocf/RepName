Public Class fOrder
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProductStock() As cStructureLib.sViewProductStock
    Private oProductStockDBIO As cViewProductStockDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oOrderStatus As cStructureLib.sOrderStatus
    Private oDataOrderStatusDBIO As cDataOrderStatusDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oTool As cTool

    Private OrderCheck As CheckBox()
    Private RECORD_COUNT As Integer
    Private TOTAL_COUNT As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private DB_CONNECT As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        On Error Resume Next
        'ＤＢ接続を開く
        oConn.Open()

        If oConn.State = ConnectionState.Open Then
            DB_CONNECT = True
            'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
            oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
            oProductStockDBIO = New cViewProductStockDBIO(oConn, oCommand, oDataReader)
            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oDataOrderStatusDBIO = New cDataOrderStatusDBIO(oConn, oCommand, oDataReader)
        Else
            DB_CONNECT = False
        End If
    End Sub

    Private Sub fOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        If DB_CONNECT = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "データベースの接続に失敗しました。", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        Else
            '環境マスタ読込み
            ReDim oConf(1)
            RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
            If RecordCnt < 1 Then
                'メッセージウィンドウ表示
                Dim Message_form As cMessageLib.fMessage

                Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Application.DoEvents()
                Application.Exit()
            End If

            If STAFF_CODE = Nothing Then
                'スタッフ入力ウィンドウ表示
                Dim staff_form As cStaffEntryLib.fStaffEntry

                staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
                staff_form.ShowDialog()
                Application.DoEvents()
                If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
                    '担当者セット
                    STAFF_CODE = staff_form.STAFF_CODE
                    STAFF_NAME = staff_form.STAFF_NAME
                    staff_form = Nothing
                Else
                    staff_form = Nothing
                    Environment.Exit(1)
                End If
            End If

            '仕入先リストボックスセット
            SUPPLIER_SET()

            '明細表示エリアタイトル行生成
            GRIDVIEW_CREATE()

            '変数初期化
            TOTAL_COUNT = 0

            '表示初期化処理
            INIT_PROC()
        End If

    End Sub
    Private Sub INIT_PROC()
        Dim RecordCnt As Integer
        Dim i As Integer

        '注文状態データ初期化
        RecordCnt = oDataOrderStatusDBIO.deleteOrderStatus(Nothing, oTran)

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        ON_B.Enabled = False
        OFF_B.Enabled = False

        PRODUCT_NAME_T.Text = ""
        OPTION_NAME_T.Text = ""
        PRODUCT_CODE_T.Text = ""
        JANCODE_T.Text = ""
        SUPPLIER_L.Text = ""
        TOTAL_COUNT_T.Text = 0

        PRODUCT_NAME_T.Focus()
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function
    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        PRODUCT_V.RowHeadersVisible = False
        PRODUCT_V.ColumnHeadersHeight = 30
        PRODUCT_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewCheckBoxColumn
        column1.HeaderText = "注文"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "注文"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "JANコード"
        PRODUCT_V.Columns.Add(column2)
        column2.Width = 85
        column2.ReadOnly = True
        column2.DefaultCellStyle.Format = "c"
        column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column2.Name = "JANコード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "商品コード"
        PRODUCT_V.Columns.Add(column3)
        column3.Width = 90
        column3.ReadOnly = True
        column3.Name = "商品コード"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "商品名称"
        PRODUCT_V.Columns.Add(column4)
        column4.Width = 200
        column4.ReadOnly = True
        column4.Name = "商品名称"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "オプション"
        PRODUCT_V.Columns.Add(column5)
        column5.Width = 170
        column5.ReadOnly = True
        column5.Name = "オプション"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "定価"
        PRODUCT_V.Columns.Add(column6)
        column6.Width = 75
        column6.ReadOnly = True
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.DefaultCellStyle.BackColor = Color.Wheat
        column6.Name = "定価"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "仕入価格"
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 80
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "仕入価格"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "在庫数"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "仕入先"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 150
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column9.Name = "仕入先"

        '背景色を白に設定
        PRODUCT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        PRODUCT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim j As Integer
        Dim str As String

        ReDim OrderCheck(RECORD_COUNT)

        '表示設定
        For i = 0 To RECORD_COUNT - 1
            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oProductStock(i).sOption1 <> "" Then
                            str = str & oProductStock(i).sOption1 & "："
                        End If
                    Case 2
                        If oProductStock(i).sOption2 <> "" Then
                            str = str & oProductStock(i).sOption2 & "："
                        End If
                    Case 3
                        If oProductStock(i).sOption3 <> "" Then
                            str = str & oProductStock(i).sOption3 & "："
                        End If
                    Case 4
                        If oProductStock(i).sOption4 <> "" Then
                            str = str & oProductStock(i).sOption4 & "："
                        End If
                    Case 5
                        If oProductStock(i).sOption5 <> "" Then
                            str = str & oProductStock(i).sOption5 & "："
                        End If
                End Select
            Next

            ''仕入先名称の読込み
            'oSupplier = Nothing
            'oSupplierDBIO.getSupplier(oSupplier, oProductStock(i).sSupplierCode, Nothing, oTran)

            PRODUCT_V.Rows.Add( _
                    oProductStock(i).sStatus, _
                    oProductStock(i).sJANCode, _
                    oProductStock(i).sProductCode, _
                    oProductStock(i).sProductName, _
                    str, _
                    oProductStock(i).sPrice, _
                    oProductStock(i).sCostPrice, _
                    oProductStock(i).sStockCount, _
                    oProductStock(i).sSupplierName _
            )
        Next i
    End Sub


    '***********************************************
    '選択中のレコードの背景色を変更する処理
    '***********************************************
    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        '2016.06.23 K.Oikawa s
        'ヘッダをクリックした際にエラー発生
        'ヘッダは対象外とする
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        '2016.06.23 K.Oikawa e

        'チェックボックスの列かどうか調べる
        If e.ColumnIndex <> 0 Then
            If PRODUCT_V("注文", e.RowIndex).Value = False Then
                PRODUCT_V("注文", e.RowIndex).Value = True
            Else
                PRODUCT_V("注文", e.RowIndex).Value = False
            End If
        End If

    End Sub
    '***********************************************
    'チェックボックスがチェックされた直後に
    'CellValueChangedイベントが発生するようにする
    'CurrentCellDirtyStateChangedイベントハンドラ
    '***********************************************
    Private Sub PRODUCT_V_CurrentCellDirtyStateChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles PRODUCT_V.CurrentCellDirtyStateChanged

        If PRODUCT_V.CurrentCellAddress.X = 0 AndAlso _
            PRODUCT_V.IsCurrentCellDirty Then
            'コミットする
            PRODUCT_V.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    '***********************************************
    '注文のチェックボックスの状態が変更した際の処理
    'チェックボックスのカラムは０に固定
    '***********************************************
    Private Sub PRODUCT_V_CellValueChanged(ByVal sender As Object, _
            ByVal e As DataGridViewCellEventArgs) _
            Handles PRODUCT_V.CellValueChanged

        '処理内容
        ORDER_STATUS_UPDATE(e.RowIndex, PRODUCT_V("商品コード", e.RowIndex).Value, PRODUCT_V(e.ColumnIndex, e.RowIndex).Value)
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '注文状態データの更新
    '*****************************************************
    Private Sub ORDER_STATUS_UPDATE(ByVal Index As Integer, ByVal ProductCode As String, ByVal CheckStatus As Boolean)

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oOrderStatus.sProductCode = ProductCode
        oOrderStatus.sCheck = CheckStatus
        oOrderStatus.sCount = 1

        If CheckStatus = True Then  'チェック済みの場合
            If oDataOrderStatusDBIO.OrderStatusExist(oOrderStatus.sProductCode, oTran) Then
                ''すでに注文状態レコードが存在した場合（通常はありえない）
                'RecordCnt = oDataOrderStatusDBIO.updateOrderStatus(oOrderStatus, oTran)
            Else
                '選択状態レコードの作成
                RecordCnt = oDataOrderStatusDBIO.insertOrderStatus(oOrderStatus, oTran)
            End If
            '合計注文金額の生成
            CAL_MONEY(1, Index)
        Else                        'チェック解除の場合
            '注文状態レコードの削除
            RecordCnt = oDataOrderStatusDBIO.deleteOrderStatus(ProductCode, oTran)
            '合計注文金額の生成
            CAL_MONEY(0, Index)
        End If

    End Sub
    '************************************
    '合計金額／税　集計
    'Mode  0: チェック解除
    '      1: チェックOn
    'Index チェックが変更されたrow番号
    '************************************
    Private Function CAL_MONEY(ByVal Mode As Integer, ByVal Index As Integer) As Long

        '集計
        If Mode = 0 Then  'チェック解除
            TOTAL_COUNT = TOTAL_COUNT - 1
        Else    'チェックOn
            TOTAL_COUNT = TOTAL_COUNT + 1
        End If

        '表示設定
        TOTAL_COUNT_T.Text = String.Format("{0,9:#,##0}", TOTAL_COUNT)
    End Function


    Private Sub ORDER_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ORDER_B.Click
        ORDER_REPORT_MAKE(0)
    End Sub
    Private Sub ORDER_REPORT_MAKE(ByVal OrderMode As Integer)
        Dim RecordCnt As Long
        Dim TrueSupCode() As Integer
        Dim oCostPriceDBIO As New cMstCostPriceDBIO(oConn, oCommand, oDataReader)

        If TOTAL_COUNT = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "商品が選択されていません", _
                                            "発注する商品を選択して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub
        End If

        '仕入先コードをバッファセット
        ReDim TrueSupCode(0)
        RecordCnt = oCostPriceDBIO.getUnionSupplier(TrueSupCode, oTran)

        If RecordCnt = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "仕入先が異なる商品が選択されています。", _
                                            "発注書は仕入先毎に作成して下さい。", _
                                            "商品選択を変更して下さい。", Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub

        End If

        '注文書発行画面を開く
        Dim orderReport_form As fOrderReport

        orderReport_form = New fOrderReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            TrueSupCode, _
                                            OrderMode, _
                                            ORDER_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        orderReport_form.ShowDialog()

        If orderReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        orderReport_form = Nothing
    End Sub
    ''**********************
    ''注文情報登録
    ''**********************
    'Private Sub ORDER_DATA_CREATE()
    '    Dim RecordCnt As Integer
    '    Dim ORDER_NUMBER As String
    '    Dim MaxOrderCode As Long
    '    Dim ret As Boolean

    '    '注文情報データデータアクセスクラスの生成
    '    oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)


    '    ret = oDataOrderDBIO.insertOrderData(oOrderData)

    '    '注文情報明細データデータアクセスクラスの生成
    '    oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)

    'End Sub

    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません", _
                                                "仕入先マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            SUPPLIER_L.Items.Add(oSupplier(i).sSupplierName)
        Next
        oDataReader = Nothing
    End Sub
    '***********************************************************
    '合計消費税のテキストボックスにキャレットを表示出来なくする
    '***********************************************************

    Private Sub TOTAL_TAX_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TOTAL_COUNT_T.GotFocus
        Call HideCaret(TOTAL_COUNT_T.Handle)
    End Sub

    Private Sub SUPPLIER_L_LostFocus(sender As Object, e As EventArgs) Handles SUPPLIER_L.LostFocus
        If SUPPLIER_L.Text = "" Then
            SUPPLIER_L.Text = "-"
        End If
    End Sub

    Private Sub SUPPLIER_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_L.SelectedIndexChanged
        If SUPPLIER_L.SelectedIndex <> -1 Then
            SUPPLIER_CODE_T.Text = oSupplier(SUPPLIER_L.SelectedIndex).sSupplierCode
        End If
        SEARCH_B.Focus()

    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oProductStockDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataOrderStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()
    End Sub


    Private Sub PRODUCT_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_NAME_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub JANCODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JANCODE_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub PRODUCT_CODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_CODE_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub ORDER_CODE_T_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                ORDER_SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub GET_RESULT_SET(ByVal pOrder_Code As String)
        Dim oDataOrderDBIO As New cDataOrderDBIO(oConn, oCommand, oDataReader)
        Dim oOrderData() As cStructureLib.sOrderData
        Dim oDataOrderSubDBIO As New cDataOrderSubDBIO(oConn, oCommand, oDataReader)
        Dim oOrderSubData() As cStructureLib.sOrderSubData
        Dim TrueSupCode() As Integer
        Dim RecordCnt As Long
        Dim i As Integer

        '初期化
        INIT_PROC()

        '-----------------------
        '    発注時状態の復元
        '-----------------------

        '発注情報取得
        ReDim oOrderData(0)
        RecordCnt = oDataOrderDBIO.getOrderData(oOrderData, pOrder_Code, Nothing, Nothing, Nothing, oTran)
        ReDim TrueSupCode(0)
        TrueSupCode(0) = oOrderData(0).sSupplierCode

        '発注情報明細取得
        ReDim oOrderSubData(0)
        RecordCnt = oDataOrderSubDBIO.getOrderSubData(oOrderSubData, pOrder_Code, Nothing, oTran)
        For i = 0 To RecordCnt - 1
            oOrderStatus.sCheck = True
            oOrderStatus.sProductCode = oOrderSubData(i).sProductCode
            oOrderStatus.sCount = oOrderSubData(i).sCount

            '発注状態データ作成
            oDataOrderStatusDBIO.insertOrderStatus(oOrderStatus, oTran)
        Next

        '商品選択数セット
        TOTAL_COUNT_T.Text = RecordCnt

        oDataOrderSubDBIO = Nothing
        oOrderSubData = Nothing

        '注文書発行画面を開く
        Dim orderReport_form As fOrderReport

        orderReport_form = New fOrderReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            TrueSupCode, _
                                            Nothing, _
                                            ORDER_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        orderReport_form.ShowDialog()

        If orderReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        orderReport_form = Nothing

        oDataOrderDBIO = Nothing
        oOrderData = Nothing
        oDataOrderSubDBIO = Nothing
        oOrderSubData = Nothing
        TrueSupCode = Nothing

    End Sub

    Private Sub ORDER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ORDER_CODE_T.LostFocus
        ORDER_SEARCH_B.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim RecordCnt As Long
        Dim i As Long
        Dim num As Long

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        If SUPPLIER_CODE_T.Text = "" Then
            num = Nothing
        Else
            num = CLng(SUPPLIER_CODE_T.Text)
        End If
        '商品在庫データの集出数確認
        RecordCnt = oProductStockDBIO.getProductStockCount( _
                       oConf(0).sRegChannelCode, _
                       JANCODE_T.Text.ToString, _
                       PRODUCT_CODE_T.Text.ToString, _
                       PRODUCT_NAME_T.Text.ToString, _
                       OPTION_NAME_T.Text.ToString, _
                       num, _
                       ORDER_C.Checked, _
                       oTran _
       )

        '検索MAX値の確認
        If RecordCnt > DISP_ROW_MAX Then
            Message_form.Dispose()
            Message_form = Nothing

            Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています",
                                        "条件を変更して再検索して下さい",
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If


        '商品在庫データの読み込み
        oProductStock = Nothing

        '        RecordCnt = oProductStockDBIO.getProductStock( _
        '                oProductStock, _
        '                oConf(0).sRegChannelCode, _
        '                JANCODE_T.Text.ToString, _
        '                PRODUCT_CODE_T.Text.ToString, _
        '                PRODUCT_NAME_T.Text.ToString, _
        '                OPTION_NAME_T.Text.ToString, _
        '                num, _
        '                ORDER_C.Checked, _
        '                oTran _
        ')

        '----------------------------------------------------------------------
        '   2015/06/11 及川和彦
        '   元となったFunction(getProductStock)は仕入れ価格が最小の仕入先を抽出対象としていたため
        '   仕入先を指定して抽出を行う際、指定仕入先が最小仕入れ価格の仕入先で無かった場合抽出されない
        '   という不具合が発生、当該不具合対応の為、追加したFunction(getSupplierProductStock)の呼び出しを追加
        '   FROM
        '----------------------------------------------------------------------

        If SUPPLIER_CODE_T.Text = "" Then

            RecordCnt = oProductStockDBIO.getProductStock( _
                            oProductStock, _
                            oConf(0).sRegChannelCode, _
                            JANCODE_T.Text.ToString, _
                            PRODUCT_CODE_T.Text.ToString, _
                            PRODUCT_NAME_T.Text.ToString, _
                            OPTION_NAME_T.Text.ToString, _
                            num, _
                            ORDER_C.Checked, _
                            oTran _
            )

        Else

            RecordCnt = oProductStockDBIO.getSupplierProductStock( _
                oProductStock, _
                oConf(0).sRegChannelCode, _
                JANCODE_T.Text.ToString, _
                PRODUCT_CODE_T.Text.ToString, _
                PRODUCT_NAME_T.Text.ToString, _
                OPTION_NAME_T.Text.ToString, _
                num, _
                ORDER_C.Checked, _
                oTran _
            )

        End If

        '----------------------------------------------------------------------
        '   HERE
        '----------------------------------------------------------------------

        '検索結果の画面セット
        RECORD_COUNT = RecordCnt
        SEARCH_RESULT_SET()

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        ON_B.Enabled = True
        OFF_B.Enabled = True

        PRODUCT_V.Focus()

    End Sub







    Private Sub ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ON_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("注文", i).Value = True
        Next i

    End Sub

    Private Sub OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("注文", i).Value = False
        Next i

    End Sub

    Private Sub RETURN_ORDER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_ORDER_B.Click
        ORDER_REPORT_MAKE(1)

    End Sub

    Private Sub ORDER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDER_SEARCH_B.Click
        Dim fOrder_Search As cSelectLib.fOrderSearch

        '発注書選択画面表示
        fOrder_Search = New cSelectLib.fOrderSearch(oConn, oCommand, oDataReader, ORDER_CODE_T.Text, oTran)
        fOrder_Search.HALF_ARRIVE_C.enabled = False
        fOrder_Search.ARRIVED_C.Enabled = False
        fOrder_Search.ShowDialog()
        If fOrder_Search.S_ORDERNUMBER_T.Text <> "" Then
            ORDER_CODE_T.Text = fOrder_Search.S_ORDERNUMBER_T.Text
            fOrder_Search = Nothing

            GET_RESULT_SET(ORDER_CODE_T.Text)
        End If

    End Sub

    Private Sub ORDER_REPORT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDER_REPORT_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage
        Dim oOrderReports As New cReportsLib.cReportsLib
        Dim ReportMode As String
        Dim ReportModeSelect_form As fOrderReportModeSelect
        Dim pDataOrderDBIO As New cDataOrderDBIO(oConn, oCommand, oDataReader)
        Dim pOrderData() As cStructureLib.sOrderData
        Dim RecordCnt As Long

        If ORDER_CODE_T.Text <> "" Then
            '発注データ確認処理
            RecordCnt = 0
            ReDim pOrderData(0)
            RecordCnt = pDataOrderDBIO.getOrderData(pOrderData, ORDER_CODE_T.Text, Nothing, Nothing, Nothing, oTran)
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。",
                                "発注番号を確認して下さい。",
                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Application.DoEvents()

                pDataOrderDBIO = Nothing
                pOrderData = Nothing
                ORDER_CODE_T.Focus()
                Exit Sub
            End If

            '伝票印刷モード選択
            ReportModeSelect_form = New fOrderReportModeSelect(pOrderData(0).sPrintMode)
            ReportModeSelect_form.ShowDialog()
            If ReportModeSelect_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
                ReportModeSelect_form = Nothing
                Exit Sub
            Else
                If ReportModeSelect_form.BEFORE_TAX_R.Checked = True Then
                    ReportMode = "税抜き"
                Else
                    ReportMode = "税込み"
                End If
                ReportModeSelect_form = Nothing
            End If
            Application.DoEvents()

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(0, "発注伝票を作成中です。",
                                        "しばらくお待ちください。",
                                        Nothing, Nothing)
            Message_form.Show()

            Application.DoEvents()

            ret = oOrderReports.OrderPrint(oConn, oCommand, oDataReader, ORDER_CODE_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)

            oOrderReports = Nothing

            Message_form.Dispose()
            Message_form = Nothing
        Else
            Message_form = New cMessageLib.fMessage(1, "発注番号が記入されていません。",
                "発注番号を確認して下さい。",
                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        End If


    End Sub

    Private Sub CLOSE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oProductStockDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataOrderStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub

    Private Sub CANDIDATE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANDIDATE_B.Click
        Dim candidate_form As fCandidate
        Dim num As Integer
        Dim pCandidateStatusDBIO As New cDataCandidateStatusDBIO(oConn, oCommand, oDataReader)
        Dim pCandidateStatus() As cStructureLib.sCandidateStatus
        Dim pOrderStatus() As cStructureLib.sOrderStatus
        Dim i As Long
        Dim RecordCnt As Long
        Dim cnt As Long

        If SUPPLIER_CODE_T.Text = "" Then
            num = Nothing
        Else
            num = CLng(SUPPLIER_CODE_T.Text)
        End If

        '発注候補選択画面を開く
        candidate_form = New fCandidate(oConn,
                                            oCommand,
                                            oDataReader,
                                            num,
                                            STAFF_CODE,
                                            STAFF_NAME,
                                            oTran)
        candidate_form.ShowDialog()
        If candidate_form.DialogResult = Windows.Forms.DialogResult.OK Then

            '選択商品の更新
            ReDim pCandidateStatus(0)
            ReDim pOrderStatus(0)
            RecordCnt = pCandidateStatusDBIO.getCandidateStatus(pCandidateStatus, Nothing, oTran)
            oDataOrderStatusDBIO.deleteOrderStatus(Nothing, oTran)

            '2019.12.1 R.Takashima FROM
            '事前に発注する商品を選択後、発注候補選択で同じ商品の選択をはずすと
            'DB上でデータが残っており選択状態が更新されないため変更
            If RecordCnt <> 0 Then
                For Each arry In pCandidateStatus
                    If arry.sCheck = True Then
                        pOrderStatus(0).sProductCode = arry.sProductCode
                        pOrderStatus(0).sCheck = arry.sCheck
                        pOrderStatus(0).sCount = arry.sCount
                        oDataOrderStatusDBIO.insertOrderStatus(pOrderStatus(0), oTran)

                        cnt += 1
                    End If
                Next
            End If
            TOTAL_COUNT = cnt
            TOTAL_COUNT_T.Text = cnt
            'If RecordCnt <> 0 Then
            '    For i = 0 To RecordCnt - 1
            '        'すでに選択済みか否かの判定
            '        cnt = oDataOrderStatusDBIO.getOrderStatus(pOrderStatus, pCandidateStatus(i).sProductCode, oTran)

            '        '選択済みでない場合
            '        If cnt = 0 Then
            '            pOrderStatus(0).sProductCode = pCandidateStatus(i).sProductCode
            '            pOrderStatus(0).sCheck = pCandidateStatus(i).sCheck
            '            pOrderStatus(0).sCount = 1
            '            oDataOrderStatusDBIO.insertOrderStatus(pOrderStatus(0), oTran)

            '            TOTAL_COUNT_T.Text = CInt(TOTAL_COUNT_T.Text) + 1
            '        End If
            '    Next
            'End If

            '2019.12.1 R.Takashima TO

        End If
        candidate_form = Nothing

        '発注候補選択で選択された商品がグリッドビューに更新されないため
        '検索処理を行わせグリッドビューを更新する
        If PRODUCT_V.Rows.Count <> 0 Then
            SEARCH_B_Click(Nothing, Nothing)
        End If

    End Sub
End Class
