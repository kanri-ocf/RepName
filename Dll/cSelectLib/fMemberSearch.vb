Public Class fMemberSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oTran As System.Data.OleDb.OleDbTransaction
    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
    End Sub
    Private Sub fMemberSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        If MEMBER_CODE_T.Text <> "" Or MEMBER_NAME_T.Text <> "" Or TEL_T.Text <> "" Then
            DATA_SET()
        End If

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To MEMBER_V.Rows.Count - 1
            MEMBER_V.Rows.Clear()
        Next i

        '有効会員のみ抽出
        Enable_C.Checked = True
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
        MEMBER_V.RowHeadersVisible = False
        MEMBER_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        MEMBER_V.ColumnHeadersHeight = 25
        MEMBER_V.RowTemplate.Height = 25

        '行高の設定
        MEMBER_V.ColumnHeadersHeight = 30
        MEMBER_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。

        Dim column0 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column0.HeaderText = "会員コード"
        MEMBER_V.Columns.Add(column0)
        column0.Width = 85
        column0.ReadOnly = True
        column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column0.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "会員名称"
        MEMBER_V.Columns.Add(column1)
        column1.Width = 100
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "〒"
        MEMBER_V.Columns.Add(column2)
        column2.Width = 60
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "住所"
        MEMBER_V.Columns.Add(column3)
        column3.Width = 200
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "TEL"
        MEMBER_V.Columns.Add(column4)
        column4.Width = 80
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "FAX"
        MEMBER_V.Columns.Add(column5)
        column5.Width = 80
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "E-Mail"
        MEMBER_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column7 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column7.HeaderText = "性別"
        MEMBER_V.Columns.Add(column7)
        column7.Width = 40
        column7.ReadOnly = True
        column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column8 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column8.HeaderText = "年齢"
        MEMBER_V.Columns.Add(column8)
        column8.Width = 40
        column8.ReadOnly = True
        column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column9 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column9.HeaderText = "入会日"
        MEMBER_V.Columns.Add(column9)
        column9.Width = 70
        column9.ReadOnly = True
        column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column10 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column10.HeaderText = "開始日"
        MEMBER_V.Columns.Add(column10)
        column10.Width = 70
        column10.ReadOnly = True
        column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column11 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column11.HeaderText = "満了日"
        MEMBER_V.Columns.Add(column11)
        column11.Width = 70
        column11.ReadOnly = True
        column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        '背景色を白に設定
        MEMBER_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        MEMBER_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DATA_SET()
    End Sub
    Private Sub DATA_SET()
        Dim RecordCnt As Long
        Dim i As Long

        '明細行クリア
        For i = 0 To MEMBER_V.Rows.Count - 1
            MEMBER_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        oMember = Nothing
        '会員マスタの読み込み
        RecordCnt = oMstMemberDBIO.getMember( _
                        oMember, _
                        MEMBER_CODE_T.Text.ToString, _
                        MEMBER_NAME_T.Text.ToString, _
                        TEL_T.Text.ToString, _
                        Enable_C.Checked, _
                        oTran)

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
        SEARCH_RESULT_SET(RecordCnt)

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub
    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET(ByVal RecordCount As Integer)
        Dim i As Integer

        '表示設定
        For i = 0 To RecordCount - 1
            MEMBER_V.Rows.Add( _
                    oMember(i).sMemberCode, _
                    oMember(i).sMemberName, _
                    oMember(i).sPostCode, _
                    oMember(i).sAddress1 & oMember(i).sAddress2 & oMember(i).sAddress3, _
                    oMember(i).sTEL, _
                    oMember(i).sFAX, _
                    oMember(i).sMailAddress, _
                    oMember(i).sSex, _
                    oMember(i).sAge, _
                    oMember(i).sEntryDate, _
                    oMember(i).sStartRegistDate, _
                    oMember(i).sEndRegistDate _
            )
        Next i
    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        oMstMemberDBIO = Nothing

        Me.Close()
    End Sub

    Private Sub MEMBER_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MEMBER_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = MEMBER_V.CurrentRow.Index

        On Error Resume Next
        If MEMBER_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        MEMBER_CODE_T.Text = MEMBER_V(0, SelRow).Value.ToString()

        Me.DialogResult = Windows.Forms.DialogResult.OK

        '商品選択ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        DATA_SET()

    End Sub

    Private Sub CLOSE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oConn = Nothing
        oMstMemberDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Abort

        Me.Close()

    End Sub
End Class
