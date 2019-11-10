Public Class fServiceMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oService() As cStructureLib.sService
    Private oMstServiceDBIO As cMstServiceDBIO

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

        oMstServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

    End Sub
    Private Sub fServiceMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        column1.HeaderText = "コード"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 70
        column1.Name = "サービスコード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "サービス名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 180
        column2.Name = "サービス名称"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "区分"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 80
        column3.Name = "サービス区分"

        Dim column4 As New DataGridViewCheckBoxColumn
        column4.HeaderText = "顧客"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 80
        column4.Name = "顧客"

        Dim column5 As New DataGridViewCheckBoxColumn
        column5.HeaderText = "社員"
        DATA_V.Columns.Add(column5)
        column5.ReadOnly = True
        column5.Width = 80
        column5.Name = "社員"

        Dim column6 As New DataGridViewCheckBoxColumn
        column6.HeaderText = "アルバイト"
        DATA_V.Columns.Add(column6)
        column6.ReadOnly = True
        column6.Width = 80
        column6.Name = "アルバイト"

        Dim column7 As New DataGridViewCheckBoxColumn
        column7.HeaderText = "パート"
        DATA_V.Columns.Add(column7)
        column7.ReadOnly = True
        column7.Width = 80
        column7.Name = "パート"

        Dim column8 As New DataGridViewCheckBoxColumn
        column8.HeaderText = "その他"
        DATA_V.Columns.Add(column8)
        column8.ReadOnly = True
        column8.Width = 80
        column8.Name = "その他"

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
        Dim RecordCnt As Long

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        If IsNothing(oService) = True Then
            RecordCnt = 0
        Else
            RecordCnt = oService.Length
        End If

        For i = 0 To RecordCnt - 1
            str = ""
            If oService(i).sServiceClass = 0 Then
                str = "顧客向け"
            Else
                str = "社内向け"
            End If

            DATA_V.Rows.Add( _
                        oService(i).sServiceCode, _
                        oService(i).sServiceName, _
                        str, _
                        oService(i).sTarget_C, _
                        oService(i).sTarget_E, _
                        oService(i).sTarget_A, _
                        oService(i).sTarget_P, _
                        oService(i).sTarget_O _
                )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pServiceCode As String
        Dim pServiceName As String
        Dim pServiceClass As Integer
        Dim pTarget_C As Boolean
        Dim pTarget_E As Boolean
        Dim pTarget_A As Boolean
        Dim pTarget_P As Boolean
        Dim pTarget_O As Boolean

        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        'サービスマスタ読み込みバッファ初期化
        oService = Nothing
        pServiceCode = Nothing
        pServiceName = Nothing

        'サービスコード
        If S_SERVICE_CODE_T.Text <> "" Then
            pServiceCode = S_SERVICE_CODE_T.Text
        End If

        'サービス名称
        If S_SERVICE_NAME_T.Text <> "" Then
            pServiceName = S_SERVICE_NAME_T.Text
        End If

        'サービス区分（顧客）
        If CLASS_OUT_C.Checked = True Then
            If CLASS_IN_C.Checked = True Then
                pServiceClass = Nothing
            Else
                pServiceClass = 0
            End If
        Else
            If CLASS_IN_C.Checked = True Then
                pServiceClass = 1
            Else
                pServiceClass = Nothing
            End If
        End If

        'サービス対象ー顧客
        If TARGET_C_C.Checked = True Then
            pTarget_C = True
        Else
            pTarget_C = Nothing
        End If

        'サービス対象ー社員
        If TARGET_E_C.Checked = True Then
            pTarget_E = True
        Else
            pTarget_E = Nothing
        End If

        'サービス対象ーアルバイト
        If TARGET_A_C.Checked = True Then
            pTarget_A = True
        Else
            pTarget_A = Nothing
        End If

        'サービス対象ーパート
        If TARGET_P_C.Checked = True Then
            pTarget_P = True
        Else
            pTarget_P = Nothing
        End If

        'サービス対象ーその他
        If TARGET_O_C.Checked = True Then
            pTarget_O = True
        Else
            pTarget_O = Nothing
        End If

        'サービスマスタの読み込み
        RecordCnt = oMstServiceDBIO.getService( _
                        oService, _
                        pServiceCode, _
                        pServiceName, _
                        pServiceClass, _
                        pTarget_C, _
                        pTarget_E, _
                        pTarget_A, _
                        pTarget_P, _
                        pTarget_O, _
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
        End If

        '検索結果の画面セット
        SEARCH_RESULT_SET()

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

        Dim fServiceSub_form As New fServiceMstSub(oConn, oCommand, oDataReader, oConf, DATA_V("サービスコード", SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fServiceSub_form.ShowDialog()
        fServiceSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        'サービスコードにフォカスセット
        S_SERVICE_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fServiceSub_form As New fServiceMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
        fServiceSub_form.ShowDialog()
        fServiceSub_form = Nothing

        '検索処理
        SEARCH_PROC()
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstServiceDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        'サービスマスタ管理ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
