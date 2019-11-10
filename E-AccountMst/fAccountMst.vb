Public Class fAccountMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oAccountFull() As cStructureLib.sViewAccountFull
    Private oMstAccountDBIO As cMstAccountDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
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

        oMstAccountDBIO = New cMstAccountDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

    End Sub
    Private Sub fAccountMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

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


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        'チャネルリストボックスセット
        CHANNEL_SET()

        '表示初期化処理
        INIT_PROC()

        '検索処理
        SEARCH_PROC()

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
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '勘定科目コンボ内容設定
        ReDim oChannel(0)
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 1, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "勘定科目マスタが登録されていません", _
                                                "勘定科目マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "勘定科目マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            S_TAX_CLASS_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing

    End Sub

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        DATA_V.RowHeadersVisible = False
        DATA_V.ColumnHeadersHeight = 30
        DATA_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "勘定科目コード"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 110
        column1.Name = "勘定科目コード"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "勘定科目名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 200
        column2.Name = "勘定科目名称"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "連携マスタ"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 150
        column3.Name = "連携マスタ"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "税区分"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 120
        column4.Name = "税区分"

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oAccountFull.Length - 1
            DATA_V.Rows.Add( _
                        oAccountFull(i).sAccountCode, _
                        oAccountFull(i).sAccountName, _
                        oAccountFull(i).sLinkMasterName, _
                        oAccountFull(i).sTaxClassName _
                )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pAccountCode As String
        Dim pAccountName As String
        Dim pLinkMasterName As String
        Dim pTaxClassName As String
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '勘定科目マスタ読み込みバッファ初期化
        oAccountFull = Nothing
        pAccountCode = Nothing
        pAccountName = Nothing
        pLinkMasterName = Nothing
        pTaxClassName = Nothing

        '勘定科目コード
        If S_ACCOUNT_CODE_T.Text <> "" Then
            pAccountCode = S_ACCOUNT_CODE_T.Text
        End If

        '勘定科目名称
        If S_ACCOUNT_NAME_T.Text <> "" Then
            pAccountName = S_ACCOUNT_NAME_T.Text
        End If

        '連携マスタ名称
        If S_LINK_MASTER_L.Text <> "" Then
            pLinkMasterName = S_LINK_MASTER_L.Text
        End If

        '税区分名称
        If S_TAX_CLASS_L.Text <> "" Then
            pTaxClassName = S_TAX_CLASS_L.Text
        End If

        '勘定科目マスタの読み込み
        RecordCnt = oMstAccountDBIO.getAccountFull( _
                        oAccountFull, _
                        pAccountCode, _
                        pAccountName, _
                        pLinkMasterName, _
                        Nothing, _
                        pTaxClassName, _
                        oTran _
        )

        If RecordCnt > 0 Then
            '検索MAX値の確認
            If RecordCnt > DISP_COW_MAX Then
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

    Private Sub DATA_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        Dim fAccountSub_form As New fAccountMstSub(oConn, oCommand, oDataReader, oConf, DATA_V("勘定科目コード", SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fAccountSub_form.ShowDialog()
        fAccountSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        '役割コードにフォカスセット
        S_ACCOUNT_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fAccountSub_form As New fAccountMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
        fAccountSub_form.ShowDialog()
        fAccountSub_form = Nothing

        '検索処理
        SEARCH_PROC()
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstAccountDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '勘定科目マスタ管理ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
