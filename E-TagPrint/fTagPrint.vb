Public Class fTagPrint
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProductStock() As cStructureLib.sViewProductStock
    Private oProductMstStockDBIO As cViewProductStockDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oMstSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTagPrintStatus As cStructureLib.sTagPrintStatus
    Private oTagPrintStatusDBIO As cDataTagPrintStatusDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oTool As cTool

    Private TagPrintCheck As CheckBox()
    Private RECORD_COUNT As Integer
    Private TOTAL_ORDER As Long
    Private TOTAL_TAX As Single

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
        oMstSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oProductMstStockDBIO = New cViewProductStockDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oTagPrintStatusDBIO = New cDataTagPrintStatusDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

    End Sub
    Private Sub fOrder_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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

        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        'チャネルリストボックスセット
        CHANNEL_SET()

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '変数初期化
        TOTAL_ORDER = 0
        TOTAL_TAX = 0

    End Sub
    Private Sub INIT_PROC()
        Dim RecordCnt As Integer
        Dim i As Integer

        '注文状態データ初期化
        RecordCnt = oTagPrintStatusDBIO.deleteTagPrintStatus("")

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        CHANNEL_NAME_L.Text = ""

        YEAR_T.Text = String.Format("{0:yyyy}", Now)
        MONTH_T.Text = String.Format("{0:MM}", Now)
        DAY_T.Text = String.Format("{0:dd}", Now)
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

    Private Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        PRODUCT_V.RowHeadersVisible = False
        PRODUCT_V.RowTemplate.Height = 30
        PRODUCT_V.ColumnHeadersHeight = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewCheckBoxColumn
        column1.HeaderText = "印刷"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "印刷"

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
        column5.HeaderText = "オプション名称"
        PRODUCT_V.Columns.Add(column5)
        column5.Width = 180
        column5.ReadOnly = True
        column5.Name = "オプション名称"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "定価"
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 75
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.DefaultCellStyle.BackColor = Color.Wheat
        column7.Name = "定価"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 80
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "印刷枚数"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 85
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "印刷枚数"

        '背景色を白に設定
        PRODUCT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        PRODUCT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RecordCnt As Long
        Dim i As Long
        Dim Message_form As cMessageLib.fMessage

        If CHANNEL_NAME_L.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "チャネルを選択して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        oProductStock = Nothing
        '商品在庫データの読み込み
        RecordCnt = oProductMstStockDBIO.getProductTagPrint(
                        oProductStock,
                        CHANNEL_CODE_T.Text,
                        JANCODE_T.Text.ToString,
                        PRODUCT_CODE_T.Text.ToString,
                        PRODUCT_NAME_T.Text.ToString,
                        PRINT_C.Checked,
                        Trim(YEAR_T.Text) & "/" & Trim(MONTH_T.Text) & "/" & Trim(DAY_T.Text),
                        oTran)

        '検索結果の画面セット
        RECORD_COUNT = RecordCnt
        SEARCH_RESULT_SET()

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub
    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim PrintCnt As Integer
        Dim str As String

        ReDim TagPrintCheck(RECORD_COUNT)

        '表示設定
        For i = 0 To RECORD_COUNT - 1
            If oProductStock(i).sTagPrintCount = 0 Then
                PrintCnt = 1
            Else
                PrintCnt = oProductStock(i).sTagPrintCount
            End If
            str = ""
            str = oProductStock(i).sOption1 & ":" & oProductStock(i).sOption2 & ":" & oProductStock(i).sOption3 & ":" & oProductStock(i).sOption4 & ":" & oProductStock(i).sOption5
            PRODUCT_V.Rows.Add( _
                    oProductStock(i).sStatus, _
                    oProductStock(i).sJANCode, _
                    oProductStock(i).sProductCode, _
                    oProductStock(i).sProductName, _
                    str, _
                    oProductStock(i).sPrice, _
                    oProductStock(i).sStockCount, _
                    PrintCnt, _
                    oProductStock(i).sSupplierName _
            )
        Next i
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        'チェックボックスの列かどうか調べる
        If e.RowIndex > 0 Then
            If e.ColumnIndex <> 0 And e.ColumnIndex <> 8 Then
                If PRODUCT_V("印刷", e.RowIndex).Value = False Then
                    PRODUCT_V("印刷", e.RowIndex).Value = True
                Else
                    PRODUCT_V("印刷", e.RowIndex).Value = False
                End If
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

        'チェックボックスの列かどうか調べる
        If e.ColumnIndex = 0 Or e.ColumnIndex = 8 Then
            '処理内容
            ORDER_STATUS_UPDATE(e.RowIndex, _
                                PRODUCT_V("商品コード", e.RowIndex).Value, _
                                PRODUCT_V(e.ColumnIndex, e.RowIndex).Value, _
                                PRODUCT_V("印刷枚数", e.RowIndex).Value _
            )
        End If
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '注文状態データの更新
    '*****************************************************
    Private Sub ORDER_STATUS_UPDATE(ByVal Index As Integer, ByVal ProductCode As String, ByVal CheckStatus As Boolean, ByVal Count As Long)

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oTagPrintStatus.sProductCode = ProductCode
        oTagPrintStatus.sTagPrintCheck = CheckStatus
        oTagPrintStatus.sCount = Count

        If CheckStatus = True Then  'チェック済みの場合
            If oTagPrintStatusDBIO.TagPrintStatusExist(oTagPrintStatus.sProductCode) Then
                'すでに注文状態レコードが存在した場合（通常はありえない）
                RecordCnt = oTagPrintStatusDBIO.updateTagPrintStatus(oTagPrintStatus)
            Else
                '注文状態レコードの作成
                RecordCnt = oTagPrintStatusDBIO.insertTagPrintStatus(oTagPrintStatus)
            End If
        Else                        'チェック解除の場合
            '注文状態レコードの削除
            RecordCnt = oTagPrintStatusDBIO.deleteTagPrintStatus(ProductCode)
        End If
        SELECT_CNT.Text = oTagPrintStatusDBIO.TagPrintStatusExist(Nothing)

    End Sub

    '***************************
    'チャネルリストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oChannel = Nothing
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタが登録されていません", _
                                                "チャネルマスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CHANNEL_NAME_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing
    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        oMstSupplierDBIO = Nothing
        oProductMstStockDBIO = Nothing
        oMstConfigDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTagPrintStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()
    End Sub

    Private Sub CHANNEL_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_L.SelectedIndexChanged
        If CHANNEL_NAME_L.SelectedIndex <> -1 Then
            ReDim oChannel(0)
            oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_L.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If

    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim RecordCnt As Long
        Dim i As Long
        Dim Message_form As cMessageLib.fMessage

        If CHANNEL_NAME_L.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "チャネルを選択して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            Exit Sub
        End If

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        oProductStock = Nothing
        '商品在庫データの読み込み
        RecordCnt = oProductMstStockDBIO.getProductTagPrint(
                        oProductStock,
                        CHANNEL_CODE_T.Text,
                        JANCODE_T.Text.ToString,
                        PRODUCT_CODE_T.Text.ToString,
                        PRODUCT_NAME_T.Text.ToString,
                        PRINT_C.Checked,
                        Trim(YEAR_T.Text) & "/" & Trim(MONTH_T.Text) & "/" & Trim(DAY_T.Text),
                        oTran)

        '検索結果の画面セット
        RECORD_COUNT = RecordCnt
        SEARCH_RESULT_SET()

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub TAGPRINT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAGPRINT_B.Click
        Dim ReportPage As New cReportsLib.cReportsLib
        Dim ret As Boolean

        '2016.09.16 K.Oikawa s
        'TODO:課題表No183 印刷対象として選択されている行数が1以上であることを確認する方法を要確認
        '選択行がない場合に印刷をしないよう修正が必要
        If SELECT_CNT.Text = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "商品が選択されていません", _
                                            "印刷する商品を選択して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub
        End If
        '2016.09.16 K.Oikawa e

        'タグ印刷画面を開く
        ret = ReportPage.TagPrint(oConn, oCommand, oDataReader, CHANNEL_CODE_T.Text, 0, oTran)

        If ret = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        ReportPage = Nothing

    End Sub

    Private Sub ON_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ON_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 2
            PRODUCT_V("印刷", i).Value = True
        Next i

    End Sub

    Private Sub OFF_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 2
            PRODUCT_V("印刷", i).Value = False
        Next i

    End Sub

    Private Sub CLOSE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        Me.Dispose()
        Environment.Exit(1)

    End Sub
End Class
