Public Class fOrderSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oOrder() As cStructureLib.sOrderData
    Private oOrderFull() As cStructureLib.sViewOrderDataFull
    Private oViewOrderDataFullDBIO As cViewOrderDataFullDBIO

    Private oArrival() As cStructureLib.sArrivalData
    Private oArrivelDataDBIO As cDataArrivalDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iOrder_Code As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oViewOrderDataFullDBIO = New cViewOrderDataFullDBIO(oConn, oCommand, oDataReader)
        oArrivelDataDBIO = New cDataArrivalDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        ORDER_CODE_T.Text = iOrder_Code
    End Sub

    Private Sub fOrderSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        '仕入先リストボックスセット
        SUPPLIER_SET()


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        If ORDER_CODE_T.Text <> "" Then
            SEARCH_PROC()
        End If
    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To ORDER_V.Rows.Count - 1
            ORDER_V.Rows.Clear()
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
        ORDER_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "伝票番号"
        ORDER_V.Columns.Add(column1)
        column1.Width = 85
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "仕入先"
        ORDER_V.Columns.Add(column2)
        column2.Width = 200
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "伝票発行日"
        ORDER_V.Columns.Add(column3)
        column3.Width = 150
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "合計金額（税込）"
        ORDER_V.Columns.Add(column4)
        column4.Width = 150
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "最終納品日"
        ORDER_V.Columns.Add(column5)
        column5.Width = 150
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "状態"
        ORDER_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        '背景色を白に設定
        ORDER_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        ORDER_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim RecordCnt As Long
        Dim cnt As Long

        For i = 0 To ORDER_V.Rows.Count
            ORDER_V.Rows.Clear()
        Next i

        '表示設定
        cnt = 0
        For i = 0 To oOrderFull.Length - 1
            '状態判定
            RecordCnt = oArrivelDataDBIO.getArrivalData(oArrival, oOrderFull(i).sOrderCode, Nothing, Nothing, oTran)

            '状態判定
            If RecordCnt = 0 Then
                ORDER_V.Rows.Add( _
                        oOrderFull(i).sOrderCode, _
                        oOrderFull(i).sSupplierName, _
                        oOrderFull(i).sOrderDate, _
                        oOrderFull(i).sTotalPrice, _
                        oOrderFull(i).sAllArrivedDate, _
                        "未納" _
                )
                cnt = cnt + 1
            End If
            If oOrderFull(i).sAllArrivedDate = "" And RecordCnt > 0 Then
                ORDER_V.Rows.Add( _
                        oOrderFull(i).sOrderCode, _
                        oOrderFull(i).sSupplierName, _
                        oOrderFull(i).sOrderDate, _
                        oOrderFull(i).sTotalPrice, _
                        oOrderFull(i).sAllArrivedDate, _
                        "一部納品" _
                )
                cnt = cnt + 1
            End If
            If oOrderFull(i).sAllArrivedDate <> "" Then
                ORDER_V.Rows.Add( _
                        oOrderFull(i).sOrderCode, _
                        oOrderFull(i).sSupplierName, _
                        oOrderFull(i).sOrderDate, _
                        oOrderFull(i).sTotalPrice, _
                        oOrderFull(i).sAllArrivedDate, _
                        "完納" _
                )
                cnt = cnt + 1
            End If
        Next i
        COUNT_L.Text = cnt
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


    Private Sub SUPPLIER_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_L.SelectedIndexChanged
        If SUPPLIER_L.SelectedIndex <> -1 Then
            SUPPLIER_CODE_T.Text = oSupplier(SUPPLIER_L.SelectedIndex).sSupplierCode
        End If
    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Long

        '明細行クリア
        For i = 0 To ORDER_V.Rows.Count - 1
            ORDER_V.Rows.Clear()
        Next i

        'データ検索中メッセージ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oOrder = Nothing

        '商品在庫データの読み込み
        RecordCnt = oViewOrderDataFullDBIO.getOrderSearch( _
                        oOrderFull, _
                        ORDER_CODE_T.Text.ToString, _
                        SUPPLIER_CODE_T.Text, _
                        oTool.MaskClear(FROM_ORDER_DATE_T.Text), _
                        oTool.MaskClear(TO_ORDER_DATE_T.Text), _
                        PRODUCT_CODE_T.Text, _
                        PRODUCT_NAME_T.Text, _
                        OPTION_NAME_T.Text, _
                        oTool.MaskClear(FROM_ARRIVE_DATE_T.Text), _
                        oTool.MaskClear(TO_ARRIVE_DATE_T.Text), _
                        oTran _
        )

        '検索結果の画面セット
        If RecordCnt > 0 Then
            SEARCH_RESULT_SET()
        Else
            'メッセージウィンドウのクリア
            Message_form.Dispose()
            Message_form = Nothing

            Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。", _
                                                  "条件を変更後再度検索して下さい。", _
                                                  Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oViewOrderDataFullDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ORDER_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = ORDER_V.CurrentRow.Index

        If ORDER_V(1, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        S_ORDERNUMBER_T.Text = ORDER_V(0, SelRow).Value.ToString()

        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oViewOrderDataFullDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        '商品選択ウィンドウを閉じる
    End Sub

    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        SEARCH_PROC()
    End Sub
    Private Sub SEARCH_PROC()
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Long

        ORDER_V.SuspendLayout()

        '明細行クリア
        For i = 0 To ORDER_V.Rows.Count - 1
            ORDER_V.Rows.Clear()
        Next i

        'データ検索中メッセージ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oOrder = Nothing

        '商品在庫データの読み込み
        RecordCnt = oViewOrderDataFullDBIO.getOrderSearch( _
                        oOrderFull, _
                        ORDER_CODE_T.Text.ToString, _
                        SUPPLIER_CODE_T.Text, _
                        oTool.MaskClear(FROM_ORDER_DATE_T.Text), _
                        oTool.MaskClear(TO_ORDER_DATE_T.Text), _
                        PRODUCT_CODE_T.Text, _
                        PRODUCT_NAME_T.Text, _
                        OPTION_NAME_T.Text, _
                        oTool.MaskClear(FROM_ARRIVE_DATE_T.Text), _
                        oTool.MaskClear(TO_ARRIVE_DATE_T.Text), _
                        oTran _
        )

        '検索結果の画面セット
        If RecordCnt > 0 Then
            SEARCH_RESULT_SET()
        Else
            'メッセージウィンドウのクリア
            Message_form.Dispose()
            Message_form = Nothing

            Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。", _
                                                  "条件を変更後再度検索して下さい。", _
                                                  Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        ORDER_V.ResumeLayout()

    End Sub
    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oSupplierDBIO = Nothing
        oViewOrderDataFullDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
