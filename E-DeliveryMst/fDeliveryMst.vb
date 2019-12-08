Public Class fDeliveryMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oMstDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oData() As cStructureLib.sViewUnionMaster

    Private oTool As cTool

    Private CLASS_MODE As Integer

    Private IVENT_FLG As Boolean

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

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        IVENT_FLG = False
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

        'スタッフ入力ウィンドウ表示
        Dim StaffEntry_form As cStaffEntryLib.fStaffEntry

        StaffEntry_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
        StaffEntry_form.ShowDialog()
        Application.DoEvents()
        STAFF_CODE_T.Text = StaffEntry_form.STAFF_CODE
        STAFF_NAME_T.Text = StaffEntry_form.STAFF_NAME
        StaffEntry_form = Nothing


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        IVENT_FLG = True

        '項目名称リストボックスセット
        ITEM_CLASS_SET()

        '表示初期化処理
        INIT_PROC()

        '検索処理
        SEARCH_PROC()

    End Sub
    Private Sub ITEM_CLASS_SET()
        Dim i As Integer
        Dim pData() As String

        ReDim pData(0)
        oMstDeliveryClassDBIO.getItemName(pData, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To pData.Length - 1
            ITEM_CLASS_L.Items.Add(pData(i))
        Next
    End Sub
    Private Sub INIT_PROC()
        CODE_T.Text = ""
        NAME_T.Text = ""
        ITEM_CLASS_L.Text = ""

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
        column1.Width = 80
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column1.Name = "コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "項目名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 300
        column2.Name = "項目名称"

        'グリッドのヘッダーを作成します。
        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "種別名称"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 80
        column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column3.Name = "種別名称"

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET(ByRef Data() As cStructureLib.sViewUnionMaster)
        Dim i As Integer

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To Data.Length - 1
            DATA_V.Rows.Add(
                    Data(i).sCode,
                    Data(i).sName,
                    Data(i).sSubName
            )
        Next i
    End Sub
    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_LISET()
        Dim i As Integer

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i
    End Sub


    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click

        '検索処理
        SEARCH_PROC()

    End Sub
    Private Sub SEARCH_PROC()
        Dim pCode As Integer
        Dim pItemName As String
        Dim pName As String
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Integer

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '配送種別マスタ読み込みバッファ初期化
        pCode = Nothing
        pName = Nothing

        '配送種別コード
        If CODE_T.Text <> "" Then
            pCode = CInt(CODE_T.Text)
        Else
            pItemName = Nothing
        End If
        '項目名称
        If ITEM_CLASS_L.Text <> "" Then
            pItemName = ITEM_CLASS_L.Text
        Else
            pItemName = Nothing
        End If
        '種別名称
        If NAME_T.Text <> "" Then
            pName = NAME_T.Text
        Else
            pName = Nothing
        End If

        'マスタの読み込み
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, pCode, pItemName, Nothing, pName, oTran)

        ReDim oData(0)
        For i = 0 To oDeliveryClass.Length - 1
            ReDim Preserve oData(i)
            oData(i).sCode = oDeliveryClass(i).sDeliveryClassCode
            oData(i).sName = oDeliveryClass(i).sItemName
            oData(i).sSubName = oDeliveryClass(i).sClassName
        Next

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
            SEARCH_RESULT_SET(oData)
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
        Dim fDeliveryTypeSub_form As New fDeliveryMstSub(oConn, oCommand, oDataReader, CInt(DATA_V("コード", SelRow).Value), STAFF_CODE_T.Text, STAFF_NAME_T.Text, oTran)
        fDeliveryTypeSub_form.ShowDialog()
        fDeliveryTypeSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        '支払方法コードにフォカスセット
        CODE_T.Focus()
    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Message_form As cMessageLib.fMessage

        If DATA_V.RowCount > 8 Then
            Message_form = New cMessageLib.fMessage(1, "支払方法マスタは8件まで登録可能です。", _
                            "追加する場合は、未使用のレコードを削除してから", _
                            "再度、登録して下さい。", Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        Else
            Dim fDeliveryTypeSub_form As New fDeliveryMstSub(oConn, oCommand, oDataReader, Nothing, CInt(STAFF_CODE_T.Text), STAFF_NAME_T.Text, oTran)
            fDeliveryTypeSub_form.ShowDialog()
            fDeliveryTypeSub_form = Nothing

            '検索処理
            SEARCH_PROC()

        End If
    End Sub

    Private Sub SEARCH_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click
        Dim fDeliveryTypeSub_form As New fDeliveryMstSub(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, oTran)

        fDeliveryTypeSub_form.ShowDialog()
        fDeliveryTypeSub_form = Nothing

        '検索処理
        SEARCH_PROC()

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstDeliveryClassDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
