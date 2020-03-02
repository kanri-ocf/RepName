Public Class fTaxClassSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTaxClass() As cStructureLib.sViewTaxClassFull
    Private oTaxClassDBIO As cMstTaxClassDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private S_TaxClass As System.Windows.Forms.Control
    Public S_TaxClassCode As Integer
    Public S_TaxClassName As String

    Private MODE As String  '0:コードをリターン    1: 名称をリターン

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    'KeyMode = 0 税区分コードをリターン
    'KeyMode = 1 税区分名称をリターン
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef KeyString As System.Windows.Forms.Control, _
            ByRef KeyMode As Integer, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        S_TaxClass = KeyString

        MODE = KeyMode

        oTaxClassDBIO = New cMstTaxClassDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool
    End Sub

    Private Sub fTaxClassSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        CLASS_V.RowHeadersVisible = False
        CLASS_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        CLASS_V.ColumnHeadersHeight = 25
        CLASS_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "税区分コード"
        CLASS_V.Columns.Add(column1)
        column1.Width = 80
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.Name = "税区分コード"

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "税区分名称"
        CLASS_V.Columns.Add(column2)
        column2.Width = 150
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.Name = "税区分名称"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "業種"
        CLASS_V.Columns.Add(column3)
        column3.Width = 150
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.Name = "業種"

        '背景色を白に設定
        CLASS_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        CLASS_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer

        For i = 0 To CLASS_V.Rows.Count
            CLASS_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oTaxClass.Length - 1
            CLASS_V.Rows.Add(
                oTaxClass(i).sTaxClassCode, _
                oTaxClass(i).sTaxClassName, _
                oTaxClass(i).sBusinessClass _
            )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim RecordCnt As Long
        Dim i As Long

        '明細行クリア
        For i = 0 To CLASS_V.Rows.Count - 1
            CLASS_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '税区分データの読み込みバッファ初期化
        oTaxClass = Nothing

        '税区分データの読み込み
        RecordCnt = oTaxClassDBIO.getTaxClassFull(oTaxClass, Nothing, Nothing, Nothing, oTran)

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


    Private Sub CLASS_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CLASS_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = CLASS_V.CurrentRow.Index

        If MODE = 0 Then
            S_TaxClass.Text = CLASS_V("税区分コード", SelRow).Value.ToString()
        Else
            S_TaxClass.Text = CLASS_V("税区分名称", SelRow).Value.ToString()
        End If

        S_TaxClassCode = CInt(CLASS_V("税区分コード", SelRow).Value)
        S_TaxClassName = CLASS_V("税区分名称", SelRow).Value.ToString()

        oTaxClassDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        '税区分選択ウィンドウを閉じる
    End Sub
End Class
