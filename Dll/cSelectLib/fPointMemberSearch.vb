Public Class fPointMemberSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

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

        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
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

        If POINT_MEMBER_CODE_T.Text <> "" Or POINT_MEMBER_NAME_T.Text <> "" Or TEL_T.Text <> "" Then
            DATA_SET()
        End If

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To POINT_MEMBER_V.Rows.Count - 1
            POINT_MEMBER_V.Rows.Clear()
        Next i

        '有効会員のみ抽出
        ENABLE_R.Checked = True
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
        POINT_MEMBER_V.RowHeadersVisible = False
        POINT_MEMBER_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        POINT_MEMBER_V.ColumnHeadersHeight = 25
        POINT_MEMBER_V.RowTemplate.Height = 25

        '行高の設定
        POINT_MEMBER_V.ColumnHeadersHeight = 30
        POINT_MEMBER_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。

        Dim column0 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column0.HeaderText = "会員コード"
        POINT_MEMBER_V.Columns.Add(column0)
        column0.Width = 85
        column0.ReadOnly = True
        column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column0.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "会員名称"
        POINT_MEMBER_V.Columns.Add(column1)
        column1.Width = 100
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "〒"
        POINT_MEMBER_V.Columns.Add(column2)
        column2.Width = 60
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "住所"
        POINT_MEMBER_V.Columns.Add(column3)
        column3.Width = 200
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "TEL"
        POINT_MEMBER_V.Columns.Add(column4)
        column4.Width = 80
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "FAX"
        POINT_MEMBER_V.Columns.Add(column5)
        column5.Width = 80
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "E-Mail"
        POINT_MEMBER_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column7 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column7.HeaderText = "性別"
        POINT_MEMBER_V.Columns.Add(column7)
        column7.Width = 40
        column7.ReadOnly = True
        column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column8 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column8.HeaderText = "年齢"
        POINT_MEMBER_V.Columns.Add(column8)
        column8.Width = 40
        column8.ReadOnly = True
        column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        Dim column9 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column9.HeaderText = "入会日"
        POINT_MEMBER_V.Columns.Add(column9)
        column9.Width = 70
        column9.ReadOnly = True
        column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column10 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column10.HeaderText = "開始日"
        POINT_MEMBER_V.Columns.Add(column10)
        column10.Width = 70
        column10.ReadOnly = True
        column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Dim column11 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column11.HeaderText = "満了日"
        POINT_MEMBER_V.Columns.Add(column11)
        column11.Width = 70
        column11.ReadOnly = True
        column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        '背景色を白に設定
        POINT_MEMBER_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        POINT_MEMBER_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub
    Private Sub DATA_SET()
        Dim RecordCnt As Long
        Dim i As Long
        Dim PointMemberClass As Integer '1:有効　2:無効  3:仮登録

        POINT_MEMBER_V.SuspendLayout()

        '明細行クリア
        For i = 0 To POINT_MEMBER_V.Rows.Count - 1
            POINT_MEMBER_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        oPointMember = Nothing

        'ポイント会員状態セット
        If ENABLE_R.Checked = True Then
            PointMemberClass = 1
        End If
        If DISENABLE_R.Checked = True Then
            PointMemberClass = 2
        End If
        If PRE_R.Checked = True Then
            PointMemberClass = 3
        End If

        'ポイント会員マスタの読み込み
        RecordCnt = oMstPointMemberDBIO.getPointMember( _
                        oPointMember, _
                        POINT_MEMBER_CODE_T.Text.ToString, _
                        POINT_MEMBER_CODE_T.Text.ToString, _
                        POINT_MEMBER_NAME_T.Text.ToString, _
                        TEL_T.Text.ToString, _
                        PointMemberClass, _
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

        POINT_MEMBER_V.ResumeLayout()

    End Sub
    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET(ByVal RecordCount As Integer)
        Dim i As Integer

        '表示設定
        For i = 0 To RecordCount - 1
            POINT_MEMBER_V.Rows.Add( _
                    oPointMember(i).sPointMemberCode, _
                    oPointMember(i).sPointMemberName, _
                    oPointMember(i).sPostCode, _
                    oPointMember(i).sAddress1 & oPointMember(i).sAddress2 & oPointMember(i).sAddress3, _
                    oPointMember(i).sTEL, _
                    oPointMember(i).sFAX, _
                    oPointMember(i).sMailAddress, _
                    oPointMember(i).sSex, _
                    oPointMember(i).sAge, _
                    oPointMember(i).sEntryDate, _
                    oPointMember(i).sStartRegistDate, _
                    oPointMember(i).sEndRegistDate _
            )
        Next i
    End Sub

    Private Sub POINT_MEMBER_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles POINT_MEMBER_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = POINT_MEMBER_V.CurrentRow.Index

        On Error Resume Next
        If POINT_MEMBER_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        POINT_MEMBER_CODE_T.Text = POINT_MEMBER_V(0, SelRow).Value.ToString()

        'ポイント会員選択ウィンドウを閉じる

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        DATA_SET()

    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oConn = Nothing
        oMstPointMemberDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()

    End Sub
End Class
