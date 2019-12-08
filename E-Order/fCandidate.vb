Public Class fCandidate
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oViewCandidate() As cStructureLib.sViewCandidate
    Private oViewCandiDateDBIO As cViewCandidateDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oCandidateStatus As cStructureLib.sCandidateStatus
    Private oDataCandidateStatusDBIO As cDataCandidateStatusDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO

    Private oTool As cTool

    Private CandidateCheck As CheckBox()
    Private RECORD_COUNT As Integer
    Private SEL_COUNT As Integer
    Private TOTAL_COUNT As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private DB_CONNECT As Boolean

    Private oSupplierCode As Integer

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iSupplierCode As Integer, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oDataCandidateStatusDBIO = New cDataCandidateStatusDBIO(oConn, oCommand, oDataReader)
        oViewCandiDateDBIO = New cViewCandidateDBIO(oConn, oCommand, oDataReader)

        oSupplierCode = iSupplierCode

        oTool = New cTool

        '2019.12.7 R.Takashima FROM
        '環境マスタの取得
        oMstConfigDBIO.getConfMst(oConf, oTran)
        '2019.12.7 R.Takashima tO

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

    End Sub

    Private Sub fCandiDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '2019.11.30 R.Takashima FROM
        '仕入先を条件としないため隠す
        SUPPLIER_L.Visible = False
        Label2.Visible = False
        '2019.11.30 R.Takashima TO

        '仕入先リストボックスセット
        SUPPLIER_SET()

        '部門リストボックスセット
        BUMON_SET()

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '変数初期化
        TOTAL_COUNT = 0

        '表示初期化処理
        INIT_PROC()

        '2019.12.1 R.Takashima FROM
        '選択数のセット
        SET_ORDER_STATUS()
        '2019.12.1 R.Takashima TO

        '初期表示検索
        SEARCH_PROC()
    End Sub
    Private Sub INIT_PROC()
        Dim RecordCnt As Integer
        Dim i As Integer

        '注文状態データ初期化
        RecordCnt = oDataCandidateStatusDBIO.deleteCandidateStatus(Nothing, oTran)

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        ON_B.Enabled = False
        OFF_B.Enabled = False

        '2019.12.7 R.Takashima FROM
        '環境マスタにデフォルトの設定があるためそちらを反映させる
        KIKAN_T.Text = oConf(0).sOrderListTerm
        CYCLE_T.Text = oConf(0).sSalesTerm
        MIN_COUNT_T.Text = oConf(0).sMinimumCount
        'KIKAN_T.Text = 3
        'CYCLE_T.Text = 6
        'MIN_COUNT_T.Text = 1
        '2019.12.7 R.Takashima TO

        PRODUCT_NAME_T.Text = ""
        OPTION_NAME_T.Text = ""
        PRODUCT_CODE_T.Text = ""
        JANCODE_T.Text = ""
        SUPPLIER_L.Text = ""
        SEL_COUNT_T.Text = 0

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
        column1.HeaderText = "選択"
        PRODUCT_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "選択"

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
        column4.Width = 190
        column4.ReadOnly = True
        column4.Name = "商品名称"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "オプション"
        PRODUCT_V.Columns.Add(column5)
        column5.Width = 190
        column5.ReadOnly = True
        column5.Name = "オプション"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "定価"
        PRODUCT_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.DefaultCellStyle.BackColor = Color.Wheat
        column6.Name = "定価"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "仕入価格"
        PRODUCT_V.Columns.Add(column7)
        column7.Width = 100
        column7.ReadOnly = True
        column7.DefaultCellStyle.Format = "c"
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "仕入価格"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "販売数"
        PRODUCT_V.Columns.Add(column8)
        column8.Width = 70
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "販売数"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "在庫数"
        PRODUCT_V.Columns.Add(column9)
        column9.Width = 70
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "在庫数"

        '2019.11.30 R.Takashima FROM
        '仕入先を削除
        '2019.11.29 R.Takashima FROM
        'グリッドビューに仕入先を追加
        'Dim column10 As New DataGridViewTextBoxColumn
        'column10.HeaderText = "仕入先"
        'PRODUCT_V.Columns.Add(column10)
        'column10.Width = 120
        'column10.ReadOnly = True
        'column10.Name = "仕入先"
        '2019.11.29 R.Takashima TO
        '2019.11.30 R.Takashima TO

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

        ReDim CandidateCheck(RECORD_COUNT)

        '表示設定
        For i = 0 To RECORD_COUNT - 1
            str = ""
            For j = 1 To 5
                Select Case j
                    Case 1
                        If oViewCandidate(i).sOption1 <> "" Then
                            str = str & oViewCandidate(i).sOption1 & "："
                        End If
                    Case 2
                        If oViewCandidate(i).sOption2 <> "" Then
                            str = str & oViewCandidate(i).sOption2 & "："
                        End If
                    Case 3
                        If oViewCandidate(i).sOption3 <> "" Then
                            str = str & oViewCandidate(i).sOption3 & "："
                        End If
                    Case 4
                        If oViewCandidate(i).sOption4 <> "" Then
                            str = str & oViewCandidate(i).sOption4 & "："
                        End If
                    Case 5
                        If oViewCandidate(i).sOption5 <> "" Then
                            str = str & oViewCandidate(i).sOption5 & "："
                        End If
                End Select
            Next

            '2019.11.29 R.Takashima FROM
            '仕入先名称を追加
            '2019.11.30 R.Takashima FROM
            '仕入先名称を条件としない
            PRODUCT_V.Rows.Add(
                    oViewCandidate(i).sStatus,
                    oViewCandidate(i).sJANCode,
                    oViewCandidate(i).sProductCode,
                    oViewCandidate(i).sProductName,
                    str,
                    oViewCandidate(i).sPrice,
                    oViewCandidate(i).sCostPrice,
                    oViewCandidate(i).sCount,
                    oViewCandidate(i).sStockCount
            )

            'PRODUCT_V.Rows.Add(
            '        oViewCandidate(i).sStatus,
            '        oViewCandidate(i).sJANCode,
            '        oViewCandidate(i).sProductCode,
            '        oViewCandidate(i).sProductName,
            '        str,
            '        oViewCandidate(i).sPrice,
            '        oViewCandidate(i).sCostPrice,
            '        oViewCandidate(i).sCount,
            '        oViewCandidate(i).sStockCount,
            '        oViewCandidate(i).sSupplierName
            ')
            '2019.11.30 R.Takashima TO
            '2019.11.29 R.Takashima TO
        Next i
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_V.CellClick
        'チェックボックスの列かどうか調べる
        '2019.12.8 R.Takashima
        'カラム名が表示されている行をクリックすると実行されRowIndexでエラーが発生するため
        '処理を行わないように変更
        If e.RowIndex >= 0 Then
            If e.ColumnIndex <> 0 Then
                If PRODUCT_V("選択", e.RowIndex).Value = False Then
                    PRODUCT_V("選択", e.RowIndex).Value = True
                Else
                    PRODUCT_V("選択", e.RowIndex).Value = False
                End If
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
        CANDIDATE_STATUS_UPDATE(e.RowIndex, PRODUCT_V("商品コード", e.RowIndex).Value, PRODUCT_V(e.ColumnIndex, e.RowIndex).Value)
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '発注候補選択状態データの更新
    '*****************************************************
    Private Sub CANDIDATE_STATUS_UPDATE(ByVal Index As Integer, ByVal ProductCode As String, ByVal CheckStatus As Boolean)

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oCandidateStatus.sProductCode = ProductCode
        oCandidateStatus.sCheck = CheckStatus
        oCandidateStatus.sCount = 1

        If CheckStatus = True Then  'チェック済みの場合
            If oDataCandidateStatusDBIO.CandidateStatusExist(oCandidateStatus.sProductCode, oTran) Then
                ''すでに注文状態レコードが存在した場合（通常はありえない）
                'RecordCnt = oDataCandidateStatusDBIO.updateOrderStatus(oCandidateStatus, oTran)
            Else
                '選択状態レコードの作成
                RecordCnt = oDataCandidateStatusDBIO.insertCandidateStatus(oCandidateStatus, oTran)
            End If
            '合計注文金額の生成
            CAL_MONEY(1, Index)
        Else                        'チェック解除の場合
            '注文状態レコードの削除
            RecordCnt = oDataCandidateStatusDBIO.deleteCandidateStatus(ProductCode, oTran)
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
            SEL_COUNT = SEL_COUNT - 1
        Else    'チェックOn
            SEL_COUNT = SEL_COUNT + 1
        End If

        '表示設定
        SEL_COUNT_T.Text = String.Format("{0,9:#,##0}", SEL_COUNT)
    End Function
    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません", _
                                                "仕入先マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            SUPPLIER_L.Items.Add(oSupplier(i).sSupplierName)
        Next
        oDataReader = Nothing
    End Sub
    '***************************
    '部門リストボックスセット
    '***************************
    Private Sub BUMON_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oBumon = Nothing
        '2016.05.17 K.Oikawa s
        'TODO:要確認
        '後から追加された「KeyTaxClassCode」が反映されていない
        'RecordCnt = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        RecordCnt = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        '2016.05.17 K.Oikawa e
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "部門マスタが登録されていません",
                                                "部門マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "部門マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            BUMON_L.Items.Add(oBumon(i).sBumonName)
        Next
        oDataReader = Nothing
    End Sub

    '2019.12.1 R.Takashima FROM
    '***************************
    'OrderStatus取得、選択数セット
    '***************************
    Private Sub SET_ORDER_STATUS()
        Dim status As cStructureLib.sOrderStatus()
        Dim orderStatusDBIO As cDataOrderStatusDBIO
        Dim recordCount As Long

        ReDim status(0)
        orderStatusDBIO = New cDataOrderStatusDBIO(oConn, oCommand, oDataReader)

        '発注状態データ取得
        recordCount = orderStatusDBIO.getOrderStatus(status, Nothing, oTran)

        '選択されている商品を数え、発注候補選択状態データに挿入
        For Each arry In status
            If arry.sCheck = True Then
                SEL_COUNT += 1
                oCandidateStatus.sProductCode = arry.sProductCode
                oCandidateStatus.sCheck = arry.sCheck
                oCandidateStatus.sCount = arry.sCount
                oDataCandidateStatusDBIO.insertCandidateStatus(oCandidateStatus, oTran)
            End If
        Next

        'テキストボックスに挿入
        SEL_COUNT_T.Text = SEL_COUNT
    End Sub
    '2019.12.1 R.Takashiam TO

    '***********************************************************
    '合計消費税のテキストボックスにキャレットを表示出来なくする
    '***********************************************************

    Private Sub TOTAL_TAX_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SEL_COUNT_T.GotFocus
        Call HideCaret(SEL_COUNT_T.Handle)
    End Sub

    Private Sub SUPPLIER_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_L.SelectedIndexChanged
        If SUPPLIER_L.SelectedIndex <> -1 Then
            SUPPLIER_CODE_T.Text = oSupplier(SUPPLIER_L.SelectedIndex).sSupplierCode
        End If
        SEARCH_B.Focus()

    End Sub
    Private Sub BUMON_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUMON_L.SelectedIndexChanged
        If BUMON_L.SelectedIndex <> -1 Then
            BUMON_CODE_T.Text = oBumon(BUMON_L.SelectedIndex).sBumonCode
        End If
        SEARCH_B.Focus()

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

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        SEARCH_PROC()
    End Sub

    Private Sub SEARCH_PROC()
        Dim RecordCnt As Long
        Dim i As Long
        Dim pFromDate As String
        Dim pToDate As String
        Dim pCycleDate As String

        '明細行クリア
        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        'FROM日付設定
        pFromDate = String.Format("{0:yyyy/MM/dd}", Now.AddMonths(CInt(KIKAN_T.Text) * -1))
        pToDate = String.Format("{0:yyyy/MM/dd}", Now)
        pCycleDate = String.Format("{0:yyyy/MM/dd}", Now.AddMonths(CInt(CYCLE_T.Text) * -1))

        '商品在庫データの抽出数確認
        '呼び出しの変更
        '2019.11.27 R.Takashima FROM
        'RecordCnt = oViewCandiDateDBIO.getCandidate(
        '        oViewCandidate,
        '        pFromDate,
        '        pToDate,
        '        pCycleDate,
        '        MIN_COUNT_T.Text,
        '        PRODUCT_NAME_T.Text,
        '        OPTION_NAME_T.Text,
        '        PRODUCT_CODE_T.Text,
        '        JANCODE_T.Text,
        '        SEL_C.Checked,
        '        BUMON_L.Text,
        '        SUPPLIER_L.Text,
        '        oTran
        ')

        RecordCnt = oViewCandiDateDBIO.getCandidateData(
                oViewCandidate,
                pFromDate,
                pToDate,
                pCycleDate,
                MIN_COUNT_T.Text,
                PRODUCT_NAME_T.Text,
                OPTION_NAME_T.Text,
                PRODUCT_CODE_T.Text,
                JANCODE_T.Text,
                SEL_C.Checked,
                BUMON_L.Text,
                SUPPLIER_L.Text,
                oTran
       )
        '2019.11.27 R.Takashima

        '検索MAX値の確認
        If RecordCnt > DISP_ROW_MAX Then
            Message_form.Dispose()
            Message_form = Nothing
            'Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています",
            '                            "条件を変更して再建策して下さい",
            '                            Nothing, Nothing)
            Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています",
                                        "条件を変更して再検索して下さい",
                                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If

        '検索結果の画面セット
        RECORD_COUNT = RecordCnt

        '抽出結果の画面セット
        SEARCH_RESULT_SET()

        '抽出件数セット
        TOTAL_COUNT_T.Text = RecordCnt

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
            PRODUCT_V("選択", i).Value = True
        Next i

    End Sub

    Private Sub OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To PRODUCT_V.Rows.Count - 1
            PRODUCT_V("選択", i).Value = False
        Next i

    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oSupplierDBIO = Nothing
        oCandidateStatus = Nothing
        oDataCandidateStatusDBIO = Nothing
        oViewCandiDateDBIO = Nothing
        oTool = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

End Class
