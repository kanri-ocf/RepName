Public Class fChannelMst
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

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

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = Nothing
        STAFF_NAME = Nothing

    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If STAFF_CODE = Nothing Then
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            Application.DoEvents()
            STAFF_CODE_T.Text = staff_form.STAFF_CODE
            STAFF_NAME_T.Text = staff_form.STAFF_NAME
            staff_form = Nothing
        End If


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '検索処理
        SEARCH_PROC()

    End Sub
    Private Sub INIT_PROC()

        CHANNEL_REAL_CLASS_R.Checked = False
        CHANNEL_NET_CLASS_R.Checked = False

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
        column1.HeaderText = "チャネルコード"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 100
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "チャネル種別"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 180

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "チャネル名称"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 180

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
        Dim str As String

        '表示設定
        For i = 0 To oChannel.Length - 1
            If oChannel(i).sChannelClass = 1 Then
                str = "リアル販売チャネル"
            Else
                str = "ネット販売チャネル"
            End If
            DATA_V.Rows.Add( _
                    oChannel(i).sChannelCode, _
                    str, _
                    oChannel(i).sChannelName _
            )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pChannelCode As String
        Dim pChannelName As String
        Dim pChannelClass As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Integer

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '一覧クリア
        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        'チャネルマスタ読み込みバッファ初期化
        oChannel = Nothing
        pChannelCode = Nothing
        pChannelName = Nothing
        pChannelClass = Nothing

        If CHANNEL_CODE_T.Text <> "" Then
            pChannelCode = CHANNEL_CODE_T.Text
        End If
        If CHANNEL_NAME_T.Text <> "" Then
            pChannelName = CHANNEL_NAME_T.Text
        End If
        If CHANNEL_REAL_CLASS_R.Checked = True Then
            pChannelClass = 1
        Else
            If CHANNEL_NET_CLASS_R.Checked = True Then
                pChannelClass = 2
            Else
                pChannelClass = Nothing
            End If
        End If

        'チャネルマスタの読み込み
        RecordCnt = oMstChannelDBIO.getChannelMst( _
                        oChannel, _
                        pChannelCode, _
                        pChannelClass, _
                        pChannelName, _
                        Nothing, _
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

    Private Sub DATA_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        Dim fChannelSub_form As New fChannelMstSub(oConn, oCommand, oDataReader, DATA_V(0, SelRow).Value.ToString(), oTran)
        fChannelSub_form.ShowDialog()
        fChannelSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        'チャネルコードにフォカスセット
        Channel_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click
        Dim Message_form As cMessageLib.fMessage

        If DATA_V.RowCount > 8 Then
            Message_form = New cMessageLib.fMessage(1, "チャネルマスタは8件まで登録可能です。", _
                            "追加する場合は、未使用のレコードを削除してから", _
                            "再度、登録して下さい。", Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        Else
            Dim fChannelSub_form As New fChannelMstSub(oConn, oCommand, oDataReader, Nothing, oTran)
            fChannelSub_form.ShowDialog()
            fChannelSub_form = Nothing

            '検索処理
            SEARCH_PROC()

        End If

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oMstChannelDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
