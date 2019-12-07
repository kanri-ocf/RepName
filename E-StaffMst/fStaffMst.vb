Public Class fStaffMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private STAFF_CODE As String

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
        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = Nothing

    End Sub
    Private Sub fStaffMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
                '担当者セット
                STAFF_CODE_T.Text = staff_form.STAFF_CODE
                STAFF_NAME_T.Text = staff_form.STAFF_NAME
                staff_form = Nothing
            Else
                staff_form = Nothing
            End If
        End If


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '検索処理
        SEARCH_PROC()

    End Sub
    Private Sub INIT_PROC()

        S_E_CLASS_C.Checked = False
        S_A_CLASS_C.Checked = False
        S_P_CLASS_C.Checked = False
        S_O_CLASS_C.Checked = False

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
        column1.HeaderText = "スタッフコード"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 120
        column1.Name = "スタッフコード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "スタッフ名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 200
        column2.Name = "スタッフ名称"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "スタッフ種別"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 150
        column4.Name = "スタッフ種別"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "社販レート"
        DATA_V.Columns.Add(column5)
        column5.Width = 100
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "社販レート"

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

        For i = 0 To oStaff.Length - 1
            If oStaff(i).sStaffCode <> "0000000000000" Then
                Select Case oStaff(i).sStaffClass
                    Case "E"
                        str = "社員"
                    Case "A"
                        str = "アルバイト"
                    Case "P"
                        str = "パート"
                    Case "O"
                        str = "その他"

                End Select
                DATA_V.Rows.Add(
                            oStaff(i).sStaffCode,
                            oStaff(i).sStaffName,
                            str,
                            oStaff(i).sRate
                    )
            End If
        Next i
    End Sub
    '***********************************************
    '検索結果を画面にリセット
    '***********************************************
    Sub SEARCH_RESULT_LISET()
        Dim i As Integer
        Dim str As String

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        str = ""

    End Sub
    Private Sub SEARCH_PROC()
        Dim pStaffCode As String
        Dim pStaffName As String
        Dim pStaffClass As String
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        'スタッフマスタ読み込みバッファ初期化
        oStaff = Nothing
        pStaffCode = Nothing
        pStaffName = Nothing
        pStaffClass = Nothing

        'スタッフコード
        If S_STAFF_CODE_T.Text <> "" Then
            pStaffCode = S_STAFF_CODE_T.Text
        End If

        'スタッフ名称
        If S_STAFF_NAME_T.Text <> "" Then
            pStaffName = S_STAFF_NAME_T.Text
        End If

        'スタッフ種別
        pStaffClass = ""
        If S_E_CLASS_C.Checked = True Then
            pStaffClass = pStaffClass & "E"
        End If
        If S_A_CLASS_C.Checked = True Then
            pStaffClass = pStaffClass & "A"
        End If
        If S_P_CLASS_C.Checked = True Then
            pStaffClass = pStaffClass & "P"
        End If
        If S_O_CLASS_C.Checked = True Then
            pStaffClass = pStaffClass & "O"
        End If

        'スタッフマスタの読み込み
        RecordCnt = oMstStaffDBIO.getStaff( _
                        oStaff, _
                        pStaffCode, _
                        pStaffName, _
                        pStaffClass, _
                        Nothing, _
                        oTran _
        )

        If RecordCnt > 0 Then
            '検索MAX値の確認
            If RecordCnt > DISP_COW_MAX Then
                Message_form.Dispose()
                Message_form = Nothing
                Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています",
                                            "条件を変更して再建策して下さい",
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            End If

            '検索結果の画面セット
            SEARCH_RESULT_SET()
        ElseIf RecordCnt = 0 Then
            '検索結果の画面リセット
            SEARCH_RESULT_LISET()
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
        Dim fStaffSub_form As New fStaffMstSub(oConn, oCommand, oDataReader, oConf, DATA_V(0, SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fStaffSub_form.ShowDialog()
        fStaffSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        'スタッフコードにフォカスセット
        S_STAFF_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click
        Dim Message_form As cMessageLib.fMessage

        If DATA_V.RowCount > 99999999 Then
            Message_form = New cMessageLib.fMessage(1, "スタッフマスタは100,000,000件まで登録可能です。", _
                            "追加する場合は、未使用のレコードを削除してから", _
                            "再度、登録して下さい。", Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        Else
            Dim fStaffSub_form As New fStaffMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
            fStaffSub_form.ShowDialog()
            fStaffSub_form = Nothing

            '検索処理
            SEARCH_PROC()
        End If
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oMstStaffDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        'スタッフマスタ管理ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
