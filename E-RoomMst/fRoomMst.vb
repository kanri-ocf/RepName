Public Class fRoomMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oRoomFull() As cStructureLib.sViewRoomFull
    Private oMstRoomDBIO As cMstRoomDBIO

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

        oMstRoomDBIO = New cMstRoomDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

    End Sub
    Private Sub fRoomMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'ルームコンボ内容設定
        ReDim oChannel(0)
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 1, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "ルームマスタが登録されていません", _
                                                "ルームマスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "ルームマスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            S_CHANNEL_NAME_L.Items.Add(oChannel(i).sChannelName)
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
        column1.HeaderText = "チャネル名称"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 200
        column1.Name = "チャネル名称"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "ルームコード"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 100
        column2.Name = "ルームコード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "ルーム名称"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 270
        column3.Name = "ルーム名称"

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

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        str = ""
        For i = 0 To oRoomFull.Length - 1
            DATA_V.Rows.Add( _
                        oRoomFull(i).sChannelName, _
                        oRoomFull(i).sRoomCode, _
                        oRoomFull(i).sRoomName _
                )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pRoomCode As String
        Dim pRoomName As String
        Dim pChannelCode As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        'ルームマスタ読み込みバッファ初期化
        oRoomFull = Nothing
        pRoomCode = Nothing
        pRoomName = Nothing

        'ルームコード
        If S_ROOM_CODE_T.Text <> "" Then
            pRoomCode = S_ROOM_CODE_T.Text
        End If

        'ルーム名称
        If S_ROOM_NAME_T.Text <> "" Then
            pRoomName = S_ROOM_NAME_T.Text
        End If

        'ルーム名称
        If S_CHANNEL_CODE_T.Text <> "" Then
            pChannelCode = S_CHANNEL_CODE_T.Text
        End If

        'ルームマスタの読み込み
        RecordCnt = oMstRoomDBIO.getRoomFull( _
                        oRoomFull, _
                        pRoomCode, _
                        pRoomName, _
                        pChannelCode, _
                        Nothing, _
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

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If

        Dim fRoomSub_form As New fRoomMstSub(oConn, oCommand, oDataReader, oConf, DATA_V("ルームコード", SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fRoomSub_form.ShowDialog()
        fRoomSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        '役割コードにフォカスセット
        S_ROOM_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fRoomSub_form As New fRoomMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
        fRoomSub_form.ShowDialog()
        fRoomSub_form = Nothing

        '検索処理
        SEARCH_PROC()
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstRoomDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        'ルームマスタ管理ウィンドウを閉じる
        Me.Close()

    End Sub

    Private Sub S_CHANNEL_NAME_L_SelectedValueChanged(sender As Object, e As EventArgs) Handles S_CHANNEL_NAME_L.SelectedValueChanged
        If S_CHANNEL_NAME_L.SelectedIndex <> -1 Then
            S_CHANNEL_CODE_T.Text = oChannel(S_CHANNEL_NAME_L.SelectedIndex).sChannelCode
        End If

    End Sub
End Class
