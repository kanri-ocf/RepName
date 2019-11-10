Public Class fMakerSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oMaker() As String
    Private oMstProductDBIO As cMstProductDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private S_MAKER As System.Windows.Forms.Control

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef KeyString As System.Windows.Forms.Control, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        S_MAKER = KeyString

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

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()
        SEARCH_PROC()

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
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        MAKER_V.RowHeadersVisible = False
        MAKER_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        MAKER_V.ColumnHeadersHeight = 25
        MAKER_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "メーカー名称"
        MAKER_V.Columns.Add(column1)
        column1.Width = 600
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '背景色を白に設定
        MAKER_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        MAKER_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer

        For i = 0 To MAKER_V.Rows.Count
            MAKER_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oMaker.Length - 1
            MAKER_V.Rows.Add(oMaker(i))
        Next i
    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SEARCH_PROC()
    End Sub
    Private Sub SEARCH_PROC()
        Dim RecordCnt As Long
        Dim i As Long

        '明細行クリア
        For i = 0 To MAKER_V.Rows.Count - 1
            MAKER_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oMaker = Nothing

        '商品在庫データの読み込み
        RecordCnt = oMstProductDBIO.getMaker(oMaker, MAKER_NAME_T.Text, oTran)

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

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub MAKER_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MAKER_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = MAKER_V.CurrentRow.Index

        S_MAKER.Text = MAKER_V(0, SelRow).Value.ToString()

        'oStaffDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'メーカー選択ウィンドウを閉じる
    End Sub

    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        SEARCH_PROC()

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub

    Private Sub MAKER_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MAKER_NAME_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub MAKER_V_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MAKER_V.KeyUp
        Dim SelRow As Integer

        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                'タイトル行の下の行を1行目として返す
                SelRow = MAKER_V.CurrentRow.Index - 1

                S_MAKER.Text = MAKER_V(0, SelRow).Value.ToString()

                oMstProductDBIO = Nothing
                oMstConfigDBIO = Nothing
                oTool = Nothing

                Me.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                'メーカー選択ウィンドウを閉じる
            End If
        End If
    End Sub
End Class
