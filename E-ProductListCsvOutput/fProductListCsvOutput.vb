Public Class fProductListCsvOutput
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oProductListStatus As cStructureLib.sProductListStatus
    Private oDataProductListStatusDBIO As cDataProductListStatusDBIO

    Private oProductList() As cStructureLib.sViewProductList
    Private oProductDBIO As cMstProductDBIO

    Private oSalePrice() As cStructureLib.sSalePrice
    Private oSalePriceDBIO As cMstSalePriceDBIO

    Private oMaker() As String

    Private oTool As cTool

    Private ProductListCheck As CheckBox()
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
            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oDataProductListStatusDBIO = New cDataProductListStatusDBIO(oConn, oCommand, oDataReader)
            oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        Else
            DB_CONNECT = False
        End If
    End Sub

    Private Sub fProductList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            'メーカーコンボセット
            MAKER_SET()

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

        '商品リスト状態データ初期化
        RecordCnt = oDataProductListStatusDBIO.deleteProductListStatus(Nothing, oTran)

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
        MAKER_L.Text = ""
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
        column1.HeaderText = "選択"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "選択"

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
        column7.HeaderText = "販売価格"
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 80
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "販売価格"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "在庫数"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "メーカー名"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 150
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column9.Name = "メーカー名"

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

        ReDim ProductListCheck(RECORD_COUNT)

        '表示設定
        For i = 0 To RECORD_COUNT - 1
            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oProductList(i).sOption1 <> "" Then
                            str = str & oProductList(i).sOption1 & "："
                        End If
                    Case 2
                        If oProductList(i).sOption2 <> "" Then
                            str = str & oProductList(i).sOption2 & "："
                        End If
                    Case 3
                        If oProductList(i).sOption3 <> "" Then
                            str = str & oProductList(i).sOption3 & "："
                        End If
                    Case 4
                        If oProductList(i).sOption4 <> "" Then
                            str = str & oProductList(i).sOption4 & "："
                        End If
                    Case 5
                        If oProductList(i).sOption5 <> "" Then
                            str = str & oProductList(i).sOption5 & "："
                        End If
                End Select
            Next

            ''仕入先名称の読込み
            'oSupplier = Nothing
            'oSupplierDBIO.getSupplier(oSupplier, oProductList(i).sSupplierCode, Nothing, oTran)

            PRODUCT_V.Rows.Add( _
                    oProductList(i).sStatus, _
                    oProductList(i).sJANCode, _
                    oProductList(i).sProductCode, _
                    oProductList(i).sProductName, _
                    str, _
                    oProductList(i).sPrice, _
                    oProductList(i).sCostPrice, _
                    oProductList(i).sStockCount, _
                    oProductList(i).sSupplierName _
            )
        Next i
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        'チェックボックスの列かどうか調べる
        If e.ColumnIndex <> 0 Then
            If PRODUCT_V("選択", e.RowIndex).Value = False Then
                PRODUCT_V("選択", e.RowIndex).Value = True
            Else
                PRODUCT_V("選択", e.RowIndex).Value = False
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
    '選択のチェックボックスの状態が変更した際の処理
    'チェックボックスのカラムは０に固定
    '***********************************************
    Private Sub PRODUCT_V_CellValueChanged(ByVal sender As Object, _
            ByVal e As DataGridViewCellEventArgs) _
            Handles PRODUCT_V.CellValueChanged

        '処理内容
        ProductList_STATUS_UPDATE(e.RowIndex, PRODUCT_V("商品コード", e.RowIndex).Value, PRODUCT_V(e.ColumnIndex, e.RowIndex).Value)
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '選択状態データの更新
    '*****************************************************
    Private Sub ProductList_STATUS_UPDATE(ByVal Index As Integer, ByVal ProductCode As String, ByVal CheckStatus As Boolean)

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oProductListStatus.sProductCode = ProductCode
        oProductListStatus.sCheck = CheckStatus

        If CheckStatus = True Then  'チェック済みの場合
            If oDataProductListStatusDBIO.ProductListStatusExist(oProductListStatus.sProductCode, oTran) Then
                ''すでに選択状態レコードが存在した場合（通常はありえない）
                'RecordCnt = oDataProductListStatusDBIO.updateProductListStatus(oProductListStatus, oTran)
            Else
                '選択状態レコードの作成
                RecordCnt = oDataProductListStatusDBIO.insertProductListStatus(oProductListStatus, oTran)
            End If
        Else                        'チェック解除の場合
            '選択状態レコードの削除
            RecordCnt = oDataProductListStatusDBIO.deleteProductListStatus(ProductCode, oTran)
        End If

    End Sub

    Private Sub ProductList_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductList_B.Click
        ProductList_REPORT_MAKE(0)
    End Sub
    Private Sub ProductList_REPORT_MAKE(ByVal ProductListMode As Integer)
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

        '選択書発行画面を開く
        Dim ProductListReport_form As fProductListReport

        ProductListReport_form = New fProductListReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            TrueSupCode, _
                                            ProductListMode, _
                                            ProductList_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        ProductListReport_form.ShowDialog()

        If ProductListReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        ProductListReport_form = Nothing
    End Sub
    ''**********************
    ''選択情報登録
    ''**********************
    'Private Sub ProductList_DATA_CREATE()
    '    Dim RecordCnt As Integer
    '    Dim ProductList_NUMBER As String
    '    Dim MaxProductListCode As Long
    '    Dim ret As Boolean

    '    '選択情報データデータアクセスクラスの生成
    '    oProductDBIO = New cDataProductListDBIO(oConn, oCommand, oDataReader)


    '    ret = oProductDBIO.insertProductListData(oProductListData)

    '    '選択情報明細データデータアクセスクラスの生成
    '    oDataProductListSubDBIO = New cDataProductListSubDBIO(oConn, oCommand, oDataReader)

    'End Sub

    '***************************
    'メーカーリストボックスセット
    '***************************
    Private Sub MAKER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'メーカーコンボ内容設定
        oMaker = Nothing
        RecordCnt = oProductDBIO.getMaker(oMaker, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "商品マスタが登録されていません", _
                                                "商品マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "商品マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            MAKER_L.Items.Add(oMaker(i))
        Next
    End Sub

    Private Sub SUPPLIER_L_LostFocus(sender As Object, e As EventArgs) Handles MAKER_L.LostFocus
        If MAKER_L.Text = "" Then
            MAKER_L.Text = "-"
        End If
    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataProductListStatusDBIO = Nothing
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

    Private Sub GET_RESULT_SET(ByVal pProductList_Code As String)
        Dim oProductDBIO As New cDataProductListDBIO(oConn, oCommand, oDataReader)
        Dim oProductListData() As cStructureLib.sProductListData
        Dim oDataProductListSubDBIO As New cDataProductListSubDBIO(oConn, oCommand, oDataReader)
        Dim oProductListSubData() As cStructureLib.sProductListSubData
        Dim TrueSupCode() As Integer
        Dim RecordCnt As Long
        Dim i As Integer

        '初期化
        INIT_PROC()

        '-----------------------
        '    発注時状態の復元
        '-----------------------

        '発注情報取得
        ReDim oProductListData(0)
        RecordCnt = oProductDBIO.getProductListData(oProductListData, pProductList_Code, Nothing, Nothing, Nothing, oTran)
        ReDim TrueSupCode(0)
        TrueSupCode(0) = oProductListData(0).sSupplierCode

        '発注情報明細取得
        ReDim oProductListSubData(0)
        RecordCnt = oDataProductListSubDBIO.getProductListSubData(oProductListSubData, pProductList_Code, Nothing, oTran)
        For i = 0 To RecordCnt - 1
            oProductListStatus.sCheck = True
            oProductListStatus.sProductCode = oProductListSubData(i).sProductCode
            oProductListStatus.sCount = oProductListSubData(i).sCount

            '発注状態データ作成
            oDataProductListStatusDBIO.insertProductListStatus(oProductListStatus, oTran)
        Next

        '商品選択数セット
        TOTAL_COUNT_T.Text = RecordCnt

        oDataProductListSubDBIO = Nothing
        oProductListSubData = Nothing

        '選択書発行画面を開く
        Dim ProductListReport_form As fProductListReport

        ProductListReport_form = New fProductListReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            TrueSupCode, _
                                            Nothing, _
                                            ProductList_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        ProductListReport_form.ShowDialog()

        If ProductListReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        ProductListReport_form = Nothing

        oProductDBIO = Nothing
        oProductListData = Nothing
        oDataProductListSubDBIO = Nothing
        oProductListSubData = Nothing
        TrueSupCode = Nothing

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

        '商品在庫データの集出数確認
        RecordCnt = oProductDBIO.getProductListCount( _
                       JANCODE_T.Text.ToString, _
                       PRODUCT_CODE_T.Text.ToString, _
                       PRODUCT_NAME_T.Text.ToString, _
                       OPTION_NAME_T.Text.ToString, _
                       MAKER_L.Text, _
                       YAHOO_C.Checked, _
                       RAKUTEN_C.Checked, _
                       AMAZON_C.Checked, _
                       E_SHOP_C.Checked, _
                       SELECT_C.Checked, _
                       oTran _
       )

        '検索MAX値の確認
        If RecordCnt > DISP_ROW_MAX Then
            Message_form.Dispose()
            Message_form = Nothing
            Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています", _
                                        "条件を変更して再建策して下さい", _
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If


        '商品在庫データの読み込み
        oProductList = Nothing

        RecordCnt = oProductDBIO.getProductList( _
                        oProductList, _
                        JANCODE_T.Text.ToString, _
                        PRODUCT_CODE_T.Text.ToString, _
                        PRODUCT_NAME_T.Text.ToString, _
                        OPTION_NAME_T.Text.ToString, _
                        MAKER_L.Text, _
                        YAHOO_C.Checked, _
                        RAKUTEN_C.Checked, _
                        AMAZON_C.Checked, _
                        E_SHOP_C.Checked, _
                        SELECT_C.Checked, _
                        oTran _
            )

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
            PRODUCT_V("選択", i).Value = True
        Next i

    End Sub

    Private Sub OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("選択", i).Value = False
        Next i

    End Sub

    Private Sub CLOSE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oConn = Nothing
        oProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataProductListStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub
End Class
