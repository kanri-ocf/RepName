Public Class fShopRequest
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oProductStock() As cStructureLib.sViewProductStock
    Private oProductStockDBIO As cViewProductStockDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oDataRequest As cStructureLib.sRequestData
    Private oDataRequestDBIO As cDataRequestDBIO

    Private oDataSubRequest As cStructureLib.sRequestSubData
    Private oDataSubRequestDBIO As cDataRequestSubDBIO

    Private oRequestStatus As cStructureLib.sRequestStatus
    Private oDataRequestStatusDBIO As cDataRequestStatusDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oTool As cTool

    Private RequestCheck As CheckBox()
    Private RECORD_COUNT As Integer
    Private TOTAL_COUNT As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private DB_CONNECT As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        On Error Resume Next
        'ＤＢ接続を開く
        oConn.Open()

        If oConn.State = ConnectionState.Open Then
            DB_CONNECT = True
            oProductStockDBIO = New cViewProductStockDBIO(oConn, oCommand, oDataReader)
            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oDataRequestStatusDBIO = New cDataRequestStatusDBIO(oConn, oCommand, oDataReader)
        Else
            DB_CONNECT = False
        End If
    End Sub

    Private Sub fShopRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        If DB_CONNECT = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "データベースの接続に失敗しました。", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        Else
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
                Message_form = Nothing
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
                    STAFF_CODE = staff_form.STAFF_CODE
                    STAFF_NAME = staff_form.STAFF_NAME
                    staff_form = Nothing
                Else
                    staff_form = Nothing
                    Environment.Exit(1)
                End If
            End If

            '明細表示エリアタイトル行生成
            GRIDVIEW_CREATE()

            '変数初期化
            TOTAL_COUNT = 0

            '表示初期化処理
            INIT_PROC()
        End If

    End Sub
    Private Sub INIT_PROC()
        Dim RecordCnt As Integer
        Dim i As Integer

        '注文状態データ初期化
        RecordCnt = oDataRequestStatusDBIO.deleteRequestStatus(Nothing, oTran)

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        ON_B.Enabled = False
        OFF_B.Enabled = False

        PRODUCT_NAME_T.Text = ""
        OPTION_NAME_T.Text = ""
        PRODUCT_CODE_T.Text = ""
        JANCODE_T.Text = ""
        SUPPLIER_L.Text = ""
        TOTAL_COUNT_T.Text = 0

        PRODUCT_NAME_T.Focus()
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
        PRODUCT_V.RowHeadersVisible = False
        PRODUCT_V.ColumnHeadersHeight = 30
        PRODUCT_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewCheckBoxColumn
        column1.HeaderText = "注文"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "注文"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "JANコード"
        PRODUCT_V.Columns.Add(column2)
        column2.Width = 85
        column2.ReadOnly = True
        column2.DefaultCellStyle.Format = "c"
        column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column2.Name = "JANコード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "商品コード"
        PRODUCT_V.Columns.Add(column3)
        column3.Width = 90
        column3.ReadOnly = True
        column3.Name = "商品コード"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "商品名称"
        PRODUCT_V.Columns.Add(column4)
        column4.Width = 200
        column4.ReadOnly = True
        column4.Name = "商品名称"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "オプション"
        PRODUCT_V.Columns.Add(column5)
        column5.Width = 170
        column5.ReadOnly = True
        column5.Name = "オプション"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "定価"
        PRODUCT_V.Columns.Add(column6)
        column6.Width = 75
        column6.ReadOnly = True
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.DefaultCellStyle.BackColor = Color.Wheat
        column6.Name = "定価"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "仕入価格"
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 80
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "仕入価格"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "在庫数"
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "在庫数"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "仕入先"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 150
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column9.Name = "仕入先"

        '背景色を白に設定
        PRODUCT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        PRODUCT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim j As Integer
        Dim str As String

        ReDim RequestCheck(RECORD_COUNT)

        '表示設定
        For i = 0 To RECORD_COUNT - 1
            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oProductStock(i).sOption1 <> "" Then
                            str = str & oProductStock(i).sOption1 & "："
                        End If
                    Case 2
                        If oProductStock(i).sOption2 <> "" Then
                            str = str & oProductStock(i).sOption2 & "："
                        End If
                    Case 3
                        If oProductStock(i).sOption3 <> "" Then
                            str = str & oProductStock(i).sOption3 & "："
                        End If
                    Case 4
                        If oProductStock(i).sOption4 <> "" Then
                            str = str & oProductStock(i).sOption4 & "："
                        End If
                    Case 5
                        If oProductStock(i).sOption5 <> "" Then
                            str = str & oProductStock(i).sOption5 & "："
                        End If
                End Select
            Next

            ''仕入先名称の読込み
            'oSupplier = Nothing
            'oSupplierDBIO.getSupplier(oSupplier, oProductStock(i).sSupplierCode, Nothing, oTran)

            PRODUCT_V.Rows.Add( _
                    oProductStock(i).sStatus, _
                    oProductStock(i).sJANCode, _
                    oProductStock(i).sProductCode, _
                    oProductStock(i).sProductName, _
                    str, _
                    oProductStock(i).sPrice, _
                    oProductStock(i).sCostPrice, _
                    oProductStock(i).sStockCount, _
                    oProductStock(i).sSupplierName _
            )
        Next i
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        'チェックボックスの列かどうか調べる
        If e.ColumnIndex <> 0 Then
            If PRODUCT_V("注文", e.RowIndex).Value = False Then
                PRODUCT_V("注文", e.RowIndex).Value = True
            Else
                PRODUCT_V("注文", e.RowIndex).Value = False
            End If
        End If

    End Sub
    '***********************************************
    'チェックボックスがチェックされた直後に
    'CellValueChangedイベントが発生するようにする
    'CurrentCellDirtyStateChangedイベントハンドラ
    '***********************************************
    Private Sub PRODUCT_V_CurrentCellDirtyStateChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles PRODUCT_V.CurrentCellDirtyStateChanged

        If PRODUCT_V.CurrentCellAddress.X = 0 AndAlso _
            PRODUCT_V.IsCurrentCellDirty Then
            'コミットする
            PRODUCT_V.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    '***********************************************
    '注文のチェックボックスの状態が変更した際の処理
    'チェックボックスのカラムは０に固定
    '***********************************************
    Private Sub PRODUCT_V_CellValueChanged(ByVal sender As Object, _
            ByVal e As DataGridViewCellEventArgs) _
            Handles PRODUCT_V.CellValueChanged

        '処理内容
        REQUEST_STATUS_UPDATE(e.RowIndex, PRODUCT_V("商品コード", e.RowIndex).Value, PRODUCT_V(e.ColumnIndex, e.RowIndex).Value)
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '注文状態データの更新
    '*****************************************************
    Private Sub REQUEST_STATUS_UPDATE(ByVal Index As Integer, ByVal ProductCode As String, ByVal CheckStatus As Boolean)

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oRequestStatus.sProductCode = ProductCode
        oRequestStatus.sCheck = CheckStatus
        oRequestStatus.sCount = 1

        If CheckStatus = True Then  'チェック済みの場合
            If oDataRequestStatusDBIO.RequestStatusExist(oRequestStatus.sProductCode, oTran) Then
                ''すでに注文状態レコードが存在した場合（通常はありえない）
                'RecordCnt = oDataRequestStatusDBIO.updateRequestStatus(oRequestStatus, oTran)
            Else
                '受注状態レコードの作成
                RecordCnt = oDataRequestStatusDBIO.insertRequestStatus(oRequestStatus, oTran)
            End If
            '合計注文金額の生成
            CAL_MONEY(1, Index)
        Else                        'チェック解除の場合
            '注文状態レコードの削除
            RecordCnt = oDataRequestStatusDBIO.deleteRequestStatus(ProductCode, oTran)
            '合計注文金額の生成
            CAL_MONEY(0, Index)
        End If

    End Sub
    '************************************
    '合計金額／税　集計
    'Mode  0: チェック解除
    '      1: チェックOn
    'Index チェックが変更されたrow番号
    '************************************
    Private Function CAL_MONEY(ByVal Mode As Integer, ByVal Index As Integer) As Long

        '集計
        If Mode = 0 Then  'チェック解除
            TOTAL_COUNT = TOTAL_COUNT - 1
        Else    'チェックOn
            TOTAL_COUNT = TOTAL_COUNT + 1
        End If

        '表示設定
        TOTAL_COUNT_T.Text = String.Format("{0,9:#,##0}", TOTAL_COUNT)
    End Function


    Private Sub REQUEST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQUEST_B.Click
        REQUEST_REPORT_MAKE(0)
    End Sub
    Private Sub REQUEST_REPORT_MAKE(ByVal RequestMode As Integer)
        Dim RecordCnt As Long
        Dim TrueSupCode() As Integer
        Dim oCostPriceDBIO As New cMstCostPriceDBIO(oConn, oCommand, oDataReader)

        If TOTAL_COUNT = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "商品が選択されていません", _
                                            "受注する商品を選択して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub
        End If

        '仕入先コードをバッファセット
        ReDim TrueSupCode(0)
        RecordCnt = oCostPriceDBIO.getUnionSupplier(TrueSupCode, oTran)

        If RecordCnt = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "仕入先が異なる商品が選択されています。", _
                                            "受注書は仕入先毎に作成して下さい。", _
                                            "商品選択を変更して下さい。", Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub

        End If

        '注文書発行画面を開く
        Dim orderReport_form As fShopRequestReport

        orderReport_form = New fShopRequestReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            RequestMode, _
                                            REQUEST_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        orderReport_form.ShowDialog()

        If orderReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        orderReport_form = Nothing
    End Sub
    ''**********************
    ''注文情報登録
    ''**********************
    'Private Sub REQUEST_DATA_CREATE()
    '    Dim RecordCnt As Integer
    '    Dim REQUEST_NUMBER As String
    '    Dim MaxRequestCode As Long
    '    Dim ret As Boolean

    '    '注文情報データデータアクセスクラスの生成
    '    oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)


    '    ret = oDataRequestDBIO.insertRequestData(oRequestData)

    '    '注文情報明細データデータアクセスクラスの生成
    '    oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

    'End Sub

    '***********************************************************
    '合計消費税のテキストボックスにキャレットを表示出来なくする
    '***********************************************************

    Private Sub TOTAL_TAX_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TOTAL_COUNT_T.GotFocus
        Call HideCaret(TOTAL_COUNT_T.Handle)
    End Sub


    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        oProductStockDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataRequestStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()
    End Sub


    Private Sub PRODUCT_NAME_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_NAME_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub JANCODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JANCODE_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub PRODUCT_CODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PRODUCT_CODE_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub REQUEST_CODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                REQUEST_SEARCH_B.Focus()
            End If
        End If

    End Sub

    Private Sub GET_RESULT_SET(ByVal pRequest_Code As String)
        Dim oDataRequestDBIO As New cDataRequestDBIO(oConn, oCommand, oDataReader)
        Dim oRequestData() As cStructureLib.sRequestData
        Dim oDataRequestSubDBIO As New cDataRequestSubDBIO(oConn, oCommand, oDataReader)
        Dim oRequestSubData() As cStructureLib.sRequestSubData
        Dim RecordCnt As Long
        Dim i As Integer

        '初期化
        INIT_PROC()

        '-----------------------
        '    受注時状態の復元
        '-----------------------

        '受注情報取得
        ReDim oRequestData(0)
        RecordCnt = oDataRequestDBIO.getRequest(oRequestData, Nothing, pRequest_Code, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        '受注情報明細取得
        ReDim oRequestSubData(0)
        RecordCnt = oDataRequestSubDBIO.getSubRequest(oRequestSubData, pRequest_Code, Nothing, oTran)
        For i = 0 To RecordCnt - 1
            oRequestStatus.sCheck = True
            oRequestStatus.sProductCode = oRequestSubData(i).sProductCode
            oRequestStatus.sCount = oRequestSubData(i).sCount

            '受注状態データ作成
            oDataRequestStatusDBIO.insertRequestStatus(oRequestStatus, oTran)
        Next

        '商品選択数セット
        TOTAL_COUNT_T.Text = RecordCnt

        oDataRequestSubDBIO = Nothing
        oRequestSubData = Nothing

        '注文書発行画面を開く
        Dim orderReport_form As fShopRequestReport

        orderReport_form = New fShopRequestReport(oConn, _
                                            oCommand, _
                                            oDataReader, _
                                            Nothing, _
                                            REQUEST_CODE_T.Text, _
                                            STAFF_CODE, _
                                            STAFF_NAME, _
                                            oTran)
        orderReport_form.ShowDialog()

        If orderReport_form.DialogResult = Windows.Forms.DialogResult.OK Then
            INIT_PROC()
        End If
        orderReport_form = Nothing

        oDataRequestDBIO = Nothing
        oRequestData = Nothing
        oDataRequestSubDBIO = Nothing
        oRequestSubData = Nothing

    End Sub

    Private Sub REQUEST_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles REQUEST_CODE_T.LostFocus
        REQUEST_SEARCH_B.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim RecordCnt As Long
        Dim i As Long
        Dim num As Long

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        If SUPPLIER_CODE_T.Text = "" Then
            num = Nothing
        Else
            num = CLng(SUPPLIER_CODE_T.Text)
        End If
        '商品在庫データの集出数確認
        RecordCnt = oProductStockDBIO.getProductStockCount( _
                       oConf(0).sRegChannelCode, _
                       JANCODE_T.Text.ToString, _
                       PRODUCT_CODE_T.Text.ToString, _
                       PRODUCT_NAME_T.Text.ToString, _
                       OPTION_NAME_T.Text.ToString, _
                       num, _
                       REQUEST_C.Checked, _
                       oTran _
       )

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


        '商品在庫データの読み込み
        oProductStock = Nothing
        RecordCnt = oProductStockDBIO.getProductStock( _
                        oProductStock, _
                        oConf(0).sRegChannelCode, _
                        JANCODE_T.Text.ToString, _
                        PRODUCT_CODE_T.Text.ToString, _
                        PRODUCT_NAME_T.Text.ToString, _
                        OPTION_NAME_T.Text.ToString, _
                        num, _
                        REQUEST_C.Checked, _
                        oTran _
        )

        '検索結果の画面セット
        RECORD_COUNT = RecordCnt
        SEARCH_RESULT_SET()

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        ON_B.Enabled = True
        OFF_B.Enabled = True

        PRODUCT_V.Focus()

    End Sub

    Private Sub ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ON_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("注文", i).Value = True
        Next i

    End Sub

    Private Sub OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("注文", i).Value = False
        Next i

    End Sub

    Private Sub RETURN_REQUEST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        REQUEST_REPORT_MAKE(1)

    End Sub

    Private Sub REQUEST_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQUEST_SEARCH_B.Click
        Dim fRequest_Search As cSelectLib.fRequestSearch

        '受注書選択画面表示
        fRequest_Search = New cSelectLib.fRequestSearch(oConn, oCommand, oDataReader, REQUEST_CODE_T.Text, oTran)
        fRequest_Search.ShowDialog()
        If fRequest_Search.S_REQUESTNUMBER_T.Text <> "" Then
            REQUEST_CODE_T.Text = fRequest_Search.S_REQUESTNUMBER_T.Text
            fRequest_Search = Nothing

            GET_RESULT_SET(REQUEST_CODE_T.Text)
        End If

    End Sub

    Private Sub REQUEST_REPORT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQUEST_REPORT_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage
        Dim oReportPage As rShopRequestReportPage
        Dim ReportMode As String
        Dim ReportModeSelect_form As fShopRequestReportModeSelect
        Dim pDataRequestDBIO As New cDataRequestDBIO(oConn, oCommand, oDataReader)
        Dim pRequestData() As cStructureLib.sRequestData
        Dim RecordCnt As Long

        '受注データ確認処理
        RecordCnt = 0
        ReDim pRequestData(0)
        RecordCnt = pDataRequestDBIO.getRequest(pRequestData, Nothing, REQUEST_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCnt = 0 Then
            Message_form = New cMessageLib.fMessage(0, "該当データが存在しません。", _
                                "受注番号を確認して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()

            pDataRequestDBIO = Nothing
            pRequestData = Nothing
            REQUEST_CODE_T.Focus()
            Exit Sub
        End If

        '伝票印刷モード選択
        ReportModeSelect_form = New fShopRequestReportModeSelect(pRequestData(0).sPrintMode)
        ReportModeSelect_form.ShowDialog()
        If ReportModeSelect_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
            ReportModeSelect_form = Nothing
            Exit Sub
        Else
            If ReportModeSelect_form.BEFORE_TAX_R.Checked = True Then
                ReportMode = "税抜き"
            Else
                ReportMode = "税込み"
            End If
            ReportModeSelect_form = Nothing
        End If
        Application.DoEvents()

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "受注伝票を作成中です。", _
                                        "しばらくお待ちください。", _
                                        Nothing, Nothing)
        Message_form.Show()

        Application.DoEvents()

        oReportPage = New rShopRequestReportPage(oConn, oCommand, oDataReader, REQUEST_V, STAFF_CODE, STAFF_NAME, ReportMode, oTran)

        oReportPage.Run()

        ret = oReportPage.Document.Print(True, False)
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub CLOSE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oConn = Nothing
        oProductStockDBIO = Nothing
        oMstConfigDBIO = Nothing
        oDataRequestStatusDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub
End Class
