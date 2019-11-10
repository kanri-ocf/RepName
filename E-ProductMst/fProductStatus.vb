Public Class fProductStatus
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProductStatus() As cStructureLib.sProductStatus
    Private oProductStatusDBIO As cDataProductStatusDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private oDefaultProductClass As Integer

    Private UPDATE_FLG As Boolean

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()


        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oProductStatusDBIO = New cDataProductStatusDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = Nothing
        STAFF_NAME = Nothing
    End Sub

    Private Sub fProductStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.fStaffEntry

        staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
        staff_form.ShowDialog()
        Application.DoEvents()
        If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
            '担当者セット
            STAFF_CODE_T.Text = staff_form.STAFF_CODE
            STAFF_NAME_T.Text = staff_form.STAFF_NAME
            staff_form = Nothing
        Else
            staff_form = Nothing
        End If

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

        UPDATE_FLG = False

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
        column2.Width = 65
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.Name = "商品コード"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "商品名称"
        PRODUCT_V.Columns.Add(column3)
        column3.Width = 180
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

        Dim column9 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column9.HeaderText = "Yahoo"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 55
        column9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column9.Name = "Yahoo掲載"

        Dim column10 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column10.HeaderText = "楽天"
        PRODUCT_V.Columns.Add(column10)
        column10.Width = 55
        column10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column10.Name = "楽天掲載"

        Dim column11 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column11.HeaderText = "Amazon"
        PRODUCT_V.Columns.Add(column11)
        column11.Width = 55
        column11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column11.Name = "Amazon掲載"

        Dim column12 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column12.HeaderText = "e-Shop"
        PRODUCT_V.Columns.Add(column12)
        column12.Width = 55
        column12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column12.Name = "e-Shop掲載"

        Dim column13 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column13.HeaderText = "販売停止"
        PRODUCT_V.Columns.Add(column13)
        column13.Width = 70
        column13.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column13.Name = "販売停止"

        Dim column14 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column14.HeaderText = "仕入停止"
        PRODUCT_V.Columns.Add(column14)
        column14.Width = 70
        column14.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column14.Name = "仕入停止"

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

         '表示設定
        For i = 0 To oProduct.Length - 1
            PRODUCT_V.Rows.Add( _
                    oProduct(i).sJANCode, _
                    oProduct(i).sProductCode, _
                    oProduct(i).sProductName, _
                    oProduct(i).sOption1, _
                    oProduct(i).sOption2, _
                    oProduct(i).sOption3, _
                    oProduct(i).sOption4, _
                    oProduct(i).sOption5, _
                    oProduct(i).sYahooFlg, _
                    oProduct(i).sRakutenFlg, _
                    oProduct(i).sAmazonFlg, _
                    oProduct(i).seShopFlg, _
                    oProduct(i).sStopSaleFlg, _
                    oProduct(i).sStopSupplieFlg _
            )
        Next i
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
        SUPPLIER_L.Text = ""

        oDataReader = Nothing
    End Sub
    Private Sub UPDATE_PROC()
        Dim i As Integer

        If UPDATE_FLG = True Then
            For i = 0 To PRODUCT_V.Rows.Count - 1
                oProductDBIO.updateNetStatus(PRODUCT_V("商品コード", i).Value, _
                                                PRODUCT_V("Yahoo掲載", i).Value, _
                                                PRODUCT_V("楽天掲載", i).Value, _
                                                PRODUCT_V("Amazon掲載", i).Value, _
                                                PRODUCT_V("e-Shop掲載", i).Value, _
                                                PRODUCT_V("販売停止", i).Value, _
                                                PRODUCT_V("仕入停止", i).Value, _
                                                oTran)
            Next
        End If
        UPDATE_FLG = False
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

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim RecordCnt As Long
        Dim StopSales As Integer
        Dim StopSupplier As Integer
        Dim ProductClass As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim i As Integer

        If UPDATE_FLG = True Then
            Message_form = New cMessageLib.fMessage(2, "データが変更されています。", "データを更新しますか？", Nothing, Nothing)
            Message_form.ShowDialog()

            If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                oTran = oConn.BeginTransaction()
                UPDATE_PROC()
                oTran.Commit()
            End If
            Message_form = Nothing

        End If

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        UPDATE_FLG = False

        'メッセージウィンドウ表示
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

        '商品マスタの読み込みバッファ初期化
        ReDim oProduct(0)

        '商品マスタの読み込み
        RecordCnt = oProductDBIO.getProduct( _
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

        SELECT_CNT_T.Text = RecordCnt

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim Message_form As cMessageLib.fMessage

        If UPDATE_FLG = True Then
            Message_form = New cMessageLib.fMessage(2, "データが変更されています。", "データを更新しますか？", Nothing, Nothing)
            Message_form.ShowDialog()

            If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                UPDATE_PROC()
                oTran.Commit()
            Else
                If Not IsNothing(oTran.Connection) Then
                    oTran.Rollback()
                End If

            End If
            Message_form = Nothing

        End If

        oConn = Nothing
        oSupplierDBIO = Nothing
        oProductDBIO = Nothing
        oProductStatusDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub

    Private Sub PRODUCT_V_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellValueChanged
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        'Dim SelRow As Integer
        'Dim pProductStatus() As cStructureLib.sProductStatus

        '選択行がタイトル行の場合はリターン
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        ''タイトル行の下の行を1行目として返す
        'SelRow = PRODUCT_V.CurrentRow.Index

        'UPDATE_FLG = False

        Select Case dgv.Columns(e.ColumnIndex).Name
            Case "Yahoo掲載"
                UPDATE_FLG = True
            Case "楽天掲載"
                UPDATE_FLG = True
            Case "Amazon掲載"
                UPDATE_FLG = True
            Case "e-Shop掲載"
                UPDATE_FLG = True
            Case "販売停止"
                UPDATE_FLG = True
            Case "仕入停止"
                UPDATE_FLG = True
        End Select

        'If UPDATE_FLG = True Then
        '    ReDim oProductStatus(0)
        '    oProductStatus(0).sProductCode = PRODUCT_V("商品コード", SelRow).Value.ToString
        '    oProductStatus(0).sStopSaleFlg = PRODUCT_V("販売停止", SelRow).Value
        '    oProductStatus(0).sStopSupplieFlg = PRODUCT_V("仕入停止", SelRow).Value
        '    oProductStatus(0).sYahooFlg = PRODUCT_V("Yahoo掲載", SelRow).Value
        '    oProductStatus(0).sRakutenFlg = PRODUCT_V("楽天掲載", SelRow).Value
        '    oProductStatus(0).sAmazonFlg = PRODUCT_V("Amazon掲載", SelRow).Value
        '    oProductStatus(0).seShopFlg = PRODUCT_V("e-Shop掲載", SelRow).Value
        '    If oProductStatusDBIO.getProductStatus(pProductStatus, PRODUCT_V("商品コード", SelRow).Value.ToString, oTran) = 1 Then
        '        oProductStatusDBIO.updateProductStatus(oProductStatus, oTran)
        '    Else
        '        oProductStatusDBIO.insertProductStatus(oProductStatus, oTran)
        '    End If
        'End If
    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "今までの更新内容がすべて登録されます。", "よろしいですか？", Nothing, Nothing)
        Message_form.ShowDialog()

        If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            oTran = oConn.BeginTransaction
            UPDATE_PROC()
            oTran.Commit()
        End If

        Message_form = Nothing

        INIT_PROC()

    End Sub

    'Private Sub PRODUCT_V_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles PRODUCT_V.CurrentCellDirtyStateChanged
    '    Dim dgv As DataGridView = DirectCast(sender, DataGridView)
    '    Dim SelRow As Integer

    '    '選択行がタイトル行の場合はリターン
    '    If PRODUCT_V.CurrentRow.Index = -1 Then
    '        Exit Sub
    '    End If

    '    'タイトル行の下の行を1行目として返す
    '    SelRow = PRODUCT_V.CurrentRow.Index

    '    UPDATE_FLG = False

    '    Select Case dgv.Columns(PRODUCT_V.CurrentCell.ColumnIndex).Name
    '        Case "Yahoo掲載"
    '            UPDATE_FLG = True
    '        Case "楽天掲載"
    '            UPDATE_FLG = True
    '        Case "Amazon掲載"
    '            UPDATE_FLG = True
    '        Case "e-Shop掲載"
    '            UPDATE_FLG = True
    '        Case "販売停止"
    '            UPDATE_FLG = True
    '        Case "仕入停止"
    '            UPDATE_FLG = True
    '    End Select

    '    If UPDATE_FLG = True Then
    '        ReDim oProductStatus(0)
    '        oProductStatus(0).sProductCode = PRODUCT_V("商品コード", SelRow).Value.ToString
    '        oProductStatus(0).sStopSaleFlg = PRODUCT_V("販売停止", SelRow).Value
    '        oProductStatus(0).sStopSupplieFlg = PRODUCT_V("仕入停止", SelRow).Value
    '        oProductStatus(0).sYahooFlg = PRODUCT_V("Yahoo掲載", SelRow).Value
    '        oProductStatus(0).sRakutenFlg = PRODUCT_V("楽天掲載", SelRow).Value
    '        oProductStatus(0).sAmazonFlg = PRODUCT_V("Amazon掲載", SelRow).Value
    '        oProductStatus(0).seShopFlg = PRODUCT_V("e-Shop掲載", SelRow).Value
    '        If oProductStatusDBIO.getProductStatus(oProductStatus, PRODUCT_V("商品コード", SelRow).Value.ToString, oTran) = 1 Then
    '            oProductStatusDBIO.updateProductStatus(oProductStatus, oTran)
    '        Else
    '            oProductStatusDBIO.insertProductStatus(oProductStatus, oTran)
    '        End If
    '    End If

    'End Sub


End Class
