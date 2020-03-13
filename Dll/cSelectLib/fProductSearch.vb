Public Class fProductSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProduct() As cStructureLib.sProduct
    Private oMstProductDBIO As cMstProductDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private oDefaultProductClass As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iDefaultProductClass As Integer, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oDefaultProductClass = iDefaultProductClass

        oTran = iTran

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing

        '初期表示商品種別設定
        Select Case oDefaultProductClass
            Case 1
                SYUBETU_1_R.Checked = True
            Case 2
                SYUBETU_2_R.Checked = True
            Case 3
                SYUBETU_3_R.Checked = True
        End Select

        '仕入先リストボックスセット
        SUPPLIER_SET()


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        SUPPLIER_L.Text = ""
    End Sub

    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function
    '******************************
    '     System.Windows.Forms.DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        PRODUCT_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "JANコード"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 85
        column1.ReadOnly = True
        column1.DefaultCellStyle.Format = "c"
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.Name = "JANコード"

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "商品コード"
        PRODUCT_V.Columns.Add(column2)
        column2.Width = 90
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.Name = "商品コード"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "商品名称"
        PRODUCT_V.Columns.Add(column3)
        column3.Width = 230
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.Name = "商品名称"

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = oConf(0).sOptionName1
        PRODUCT_V.Columns.Add(column4)
        column4.Width = 85
        column4.ReadOnly = True
        If oConf(0).sOptionName1 = "" Then
            column4.Visible = False
        Else
            column4.Visible = True
        End If
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.Name = oConf(0).sOptionName1

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = oConf(0).sOptionName2
        PRODUCT_V.Columns.Add(column5)
        column5.Width = 85
        column5.ReadOnly = True
        If oConf(0).sOptionName2 = "" Then
            column5.Visible = False
        Else
            column5.Visible = True
        End If
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.Name = oConf(0).sOptionName2

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = oConf(0).sOptionName3
        PRODUCT_V.Columns.Add(column6)
        column6.Width = 85
        column6.ReadOnly = True
        If oConf(0).sOptionName3 = "" Then
            column6.Visible = False
        Else
            column6.Visible = True
        End If
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.Name = oConf(0).sOptionName3

        Dim column7 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column7.HeaderText = oConf(0).sOptionName4
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 85
        column7.ReadOnly = True
        If oConf(0).sOptionName4 = "" Then
            column7.Visible = False
        Else
            column7.Visible = True
        End If
        column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column7.Name = oConf(0).sOptionName4

        Dim column8 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column8.HeaderText = oConf(0).sOptionName5
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 85
        column8.ReadOnly = True
        If oConf(0).sOptionName5 = "" Then
            column8.Visible = False
        Else
            column8.Visible = True
        End If
        column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column8.Name = oConf(0).sOptionName5

        Dim column9 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column9.HeaderText = "定価(税込)"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 80
        column9.ReadOnly = True
        column9.DefaultCellStyle.Format = "c"
        column9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column9.DefaultCellStyle.BackColor = System.Drawing.Color.Wheat
        column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column9.Name = "定価"

        '--------------------------------------------------------------------
        '2019/10/9 suzuki 
        '「メーカー名称ヘッダーのサイズ変更」
        'Dim column10 As New System.Windows.Forms.DataGridViewTextBoxColumn
        'column10.HeaderText = "メーカー名称"
        'PRODUCT_V.Columns.Add(column10)
        'column10.Width = 200
        'column10.ReadOnly = True
        'column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        'column10.Name = "メーカー名称"
        '「軽減税率のヘッダー追加」
        '--------------------------------------------------------------------
        Dim column10 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column10.HeaderText = "メーカー名称"
        PRODUCT_V.Columns.Add(column10)
        column10.Width = 140
        column10.ReadOnly = True
        column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column10.Name = "メーカー名称"

        Dim column11 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column11.HeaderText = "軽減税率"
        PRODUCT_V.Columns.Add(column11)
        column11.Width = 60
        column11.ReadOnly = True
        column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column11.Name = "軽減税率"

        '--------------------------------------------------------------------
        '2019/10/9 suzuki 
        '「メーカー名称ヘッダーのサイズ変更」
        '「軽減税率のヘッダー追加」
        '--------------------------------------------------------------------

        '背景色を白に設定
        PRODUCT_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        PRODUCT_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        '--------------------------------------------------------------------
        '2019/10/9 suzuki 軽減税率対応時の計算結果を入れる変数追記
        '--------------------------------------------------------------------
        Dim Praice As Long
        '--------------------------------------------------------------------
        '2019/10/9 suzuki 軽減税率対応時の計算結果を入れる変数追記　end
        '--------------------------------------------------------------------

        PRODUCT_V.SuspendLayout()

        For i = 0 To PRODUCT_V.Rows.Count
            PRODUCT_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oProduct.Length - 1
            '--------------------------------------------------------------------
            '2019/10/9 suzuki 軽減税率対応時の計算分岐
            'oTool.BeforeToAfterTax(oProduct(i).sListPrice, oConf(0).sTax, oConf(0).sFracProc), _
            '--------------------------------------------------------------------
            If oProduct(i).sReducedTaxRate = String.Empty Then
                Praice = oTool.BeforeToAfterTax(oProduct(i).sListPrice, oConf(0).sTax, oConf(0).sFracProc)
            Else
                Praice = oTool.BeforeToAfterTax(oProduct(i).sListPrice, oProduct(i).sReducedTaxRate, oConf(0).sFracProc)
            End If
            '--------------------------------------------------------------------
            '2019/10/9 suzuki 軽減税率対応時の計算分岐　end
            '--------------------------------------------------------------------

            PRODUCT_V.Rows.Add(
                    oProduct(i).sJANCode,
                    oProduct(i).sProductCode,
                    oProduct(i).sProductName,
                    oProduct(i).sOption1,
                    oProduct(i).sOption2,
                    oProduct(i).sOption3,
                    oProduct(i).sOption4,
                    oProduct(i).sOption5,
                    Praice,
                    oProduct(i).sMakerName,
                    oProduct(i).sReducedTaxRate
            )
        Next i

            PRODUCT_V.ResumeLayout()
    End Sub

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
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            SUPPLIER_L.Items.Add(oSupplier(i).sSupplierName)
        Next
        oDataReader = Nothing
    End Sub

    Private Sub SUPPLIER_L_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SUPPLIER_L.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub


    Private Sub SUPPLIER_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_L.SelectedIndexChanged
        If SUPPLIER_L.SelectedIndex <> -1 Then
            SUPPLIER_CODE_T.Text = oSupplier(SUPPLIER_L.SelectedIndex).sSupplierCode
        End If
    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RecordCnt As Long
        Dim i As Long
        Dim StopSales As Integer
        Dim StopSupplier As Integer
        Dim ProductClass As Integer

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '販売停止フラグ設定
        If STOPSALE_C.Checked = True Then
            StopSales = 1
        Else
            StopSales = 0
        End If

        '仕入停止フラグ設定
        If STOPSUPPLIE_C.Checked = True Then
            StopSupplier = 1
        Else
            StopSupplier = 0
        End If

        '商品種別設定
        If SYUBETU_1_R.Checked = False And SYUBETU_2_R.Checked = False Then
            ProductClass = Nothing
        Else
            If SYUBETU_1_R.Checked = True Then
                ProductClass = 1
            Else
                ProductClass = 2
            End If
        End If

        '商品在庫データの読み込みバッファ初期化
        ReDim oProduct(0)

        '商品在庫データの読み込み
        RecordCnt = oMstProductDBIO.getProduct( _
                        oProduct, _
                        JANCODE_T.Text.ToString, _
                        PRODUCT_CODE_T.Text.ToString, _
                        PRODUCT_NAME_T.Text.ToString, _
                        OPTION_NAME_T.Text.ToString, _
                        SUPPLIER_L.Text.ToString, _
                        MAKER_NAME_T.Text.ToString, _
                        StopSales, _
                        StopSupplier, _
                        ProductClass, _
                        oTran _
        )

        If RecordCnt > 0 Then
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

            '検索結果の画面セット
            SEARCH_RESULT_SET()

        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = PRODUCT_V.CurrentRow.Index
        If PRODUCT_V("商品コード", SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        S_PRODUCT_CODE_T.Text = PRODUCT_V("商品コード", SelRow).Value.ToString()
        S_PRODUCT_NAME_T.Text = PRODUCT_V("商品名称", SelRow).Value.ToString()
        If PRODUCT_V(oConf(0).sOptionName1, SelRow).Value.ToString() <> "" Then
            If S_OPTION_NAME_T.Text = "" Then
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & " ("
            Else
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ","
            End If
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & PRODUCT_V(oConf(0).sOptionName1, SelRow).Value.ToString()
        End If
        If PRODUCT_V(oConf(0).sOptionName2, SelRow).Value.ToString() <> "" Then
            If S_OPTION_NAME_T.Text = "" Then
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & " ("
            Else
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ","
            End If
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & PRODUCT_V(oConf(0).sOptionName2, SelRow).Value.ToString()
        End If
        If PRODUCT_V(oConf(0).sOptionName3, SelRow).Value.ToString() <> "" Then
            If S_OPTION_NAME_T.Text = "" Then
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & " ("
            Else
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ","
            End If
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & PRODUCT_V(oConf(0).sOptionName3, SelRow).Value.ToString()
        End If
        If PRODUCT_V(oConf(0).sOptionName4, SelRow).Value.ToString() <> "" Then
            If S_OPTION_NAME_T.Text = "" Then
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & " ("
            Else
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ","
            End If
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & PRODUCT_V(oConf(0).sOptionName4, SelRow).Value.ToString()
        End If
        If PRODUCT_V(oConf(0).sOptionName5, SelRow).Value.ToString() <> "" Then
            If S_OPTION_NAME_T.Text = "" Then
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & " ("
            Else
                S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ","
            End If
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & PRODUCT_V(oConf(0).sOptionName5, SelRow).Value.ToString()
        End If
        If S_OPTION_NAME_T.Text <> "" Then
            S_OPTION_NAME_T.Text = S_OPTION_NAME_T.Text & ")"
        End If

        S_JAN_CODE_T.Text = PRODUCT_V("JANコード", SelRow).Value.ToString()


        'shimizu
        'REDUCED_TAX_RATE = oProduct(0).sTax.ToString
        'shimizu

        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        '商品選択ウィンドウを閉じる
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub JANCODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JANCODE_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub PRODUCT_CODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_CODE_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub PRODUCT_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_NAME_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub OPTION_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OPTION_NAME_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub MAKER_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MAKER_NAME_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub MAKER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fMakerSearch_form As fMakerSearch

        fMakerSearch_form = New fMakerSearch(oConn, oCommand, oDataReader, MAKER_NAME_T, oTran)
        fMakerSearch_form.ShowDialog()
        If fMakerSearch_form.DialogResult = Windows.Forms.DialogResult.OK Then
            fMakerSearch_form = Nothing
        End If
        System.Windows.Forms.Application.DoEvents()

        SEARCH_B.Focus()
    End Sub

    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim RecordCnt As Long
        Dim i As Long
        Dim StopSales As Integer
        Dim StopSupplier As Integer
        Dim ProductClass As Integer

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '販売停止フラグ設定
        If STOPSALE_C.Checked = True Then
            StopSales = 1
        Else
            StopSales = 0
        End If

        '仕入停止フラグ設定
        If STOPSUPPLIE_C.Checked = True Then
            StopSupplier = 1
        Else
            StopSupplier = 0
        End If

        '商品種別設定
        If SYUBETU_1_R.Checked = False And SYUBETU_2_R.Checked = False And SYUBETU_3_R.Checked = False Then
            ProductClass = Nothing
        Else
            If SYUBETU_1_R.Checked = True Then
                ProductClass = 1
            Else
                If SYUBETU_2_R.Checked = True Then
                    ProductClass = 2
                Else
                    ProductClass = 3
                End If
            End If
        End If

        '商品在庫データの読み込みバッファ初期化
        ReDim oProduct(0)

        '商品在庫データの読み込み
        RecordCnt = oMstProductDBIO.getProduct( _
                        oProduct, _
                        JANCODE_T.Text.ToString, _
                        PRODUCT_CODE_T.Text.ToString, _
                        PRODUCT_NAME_T.Text.ToString, _
                        OPTION_NAME_T.Text.ToString, _
                        SUPPLIER_L.Text.ToString, _
                        MAKER_NAME_T.Text.ToString, _
                        StopSales, _
                        StopSupplier, _
                        ProductClass, _
                        oTran _
        )

        If RecordCnt > 0 Then
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

            '検索結果の画面セット
            SEARCH_RESULT_SET()

        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing


    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub

    Private Sub MAKER_SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAKER_SEARCH_B.Click
        Dim fMakerSearch_form As fMakerSearch

        fMakerSearch_form = New fMakerSearch(oConn, oCommand, oDataReader, MAKER_NAME_T, oTran)
        fMakerSearch_form.ShowDialog()
        If fMakerSearch_form.DialogResult = Windows.Forms.DialogResult.OK Then
            fMakerSearch_form = Nothing
        End If
        System.Windows.Forms.Application.DoEvents()

        SEARCH_B.Focus()

    End Sub

    Private Sub PRODUCT_V_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_V.KeyUp
        Dim SelRow As Integer

        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                'タイトル行の下の行を1行目として返す

                SelRow = PRODUCT_V.CurrentRow.Index - 1
                If PRODUCT_V("商品コード", SelRow).Value.ToString() = Nothing Then
                    Exit Sub
                End If
                S_PRODUCT_CODE_T.Text = PRODUCT_V("商品コード", SelRow).Value.ToString()
                S_JAN_CODE_T.Text = PRODUCT_V("JANコード", SelRow).Value.ToString()

                oSupplierDBIO = Nothing
                oMstProductDBIO = Nothing
                oMstConfigDBIO = Nothing
                oTool = Nothing

                '商品選択ウィンドウを閉じる
                Me.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If

    End Sub
End Class
