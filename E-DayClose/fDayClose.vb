Public Class fDayClose
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTrnFull() As cStructureLib.sViewTrnFull
    Private oTrnFullDBIO As cViewTrnFullDBIO

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oAdjust() As cStructureLib.sAdjust
    Private oAdjustDBIO As cDataAdjustDBIO

    Private oTrnSummary() As cStructureLib.sViewTrnSummary
    Private oTrnSummaryDBIO As cViewTrnSummaryDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    ' *** START K.MINAGAWA 2013/04/29 ***
    Private oMstStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO
    ' *** END   K.MINAGAWA 2013/04/29 ***

    Private oCalc(1) As cStructureLib.sCalc
    Private oCalcDBIO As cDataCalcDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private ARRIVAL_NO As Integer

    Private PRINT_FLG As Boolean
    Private REPRINT_MODE As Boolean

    ' *** START K.MINAGAWA 2013/04/29 ***
    Private MS_PRINT_FLG As Boolean
    Private STAFF_RIGHTS_FLG As Boolean
    ' *** END   K.MINAGAWA 2013/04/29 ***

    Private SOU_CASH As Long
    Private DIS_CASH As Long
    Private COUNT_CASH As Integer
    Private SOU_CARD As Long
    Private DIS_CARD As Long
    Private COUNT_CARD As Integer
    Private BUMON_PRICE() As Long
    Private BUMON_CNT() As Integer

    Private STIFFNESS_CASH As Long

    Private OpenCash As Long
    Private InputCash As Long
    Private InputCashCnt As Integer
    Private OutPutCash As Long
    Private OutPutCashCnt As Integer
    Private ReturnCash As Long
    Private AdujustCash As Long
    Private CalCash As Long

    Private CUST_COUNT(24) As Integer

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private Const M_SALE = 1
    Private Const M_DISCOUNT_U = 2
    Private Const M_POSTAGE = 3
    Private Const M_FEE = 4
    Private Const M_DISCOUNT_M = 5
    Private Const M_DISCOUNT_P = 6
    Private Const M_DISCOUNT_C = 7
    Private Const M_DISCOUNT_T = 8
    Private Const M_MORE = 9

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


    End Sub
    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
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

    Private Sub fDayClose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTrnFullDBIO = New cViewTrnFullDBIO(oConn, oCommand, oDataReader)
        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oAdjustDBIO = New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        oTrnSummaryDBIO = New cViewTrnSummaryDBIO(oConn, oCommand, oDataReader)
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oCalcDBIO = New cDataCalcDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, oTran)
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

        'スタッフ入力ウィンドウ表示
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

        '担当者画面セット
        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        'トランザクションの開始
        oTran = Nothing
        oTran = oConn.BeginTransaction

    End Sub

    Private Sub fDayClose_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        REPRINT_MODE = False

        '現金情報入力画面表示
        Dim fAdjust_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, STAFF_CODE, Nothing, STAFF_NAME, 3, oTran)
        fAdjust_form.ShowDialog()

        STIFFNESS_CASH = CLng(fAdjust_form.TPRICE_T.Text)

        Select Case fAdjust_form.DialogResult
            Case Windows.Forms.DialogResult.Cancel  '精算画面を「戻る」で終了
                fAdjust_form.Dispose()
                fAdjust_form = Nothing
                CLOSE_PROC()
                Me.Dispose()
                Exit Sub
            Case Windows.Forms.DialogResult.Abort   '精算処理必要なし
                fAdjust_form.Dispose()
                fAdjust_form = Nothing
                Dim Message_form As cMessageLib.fMessage

                Message_form = New cMessageLib.fMessage(2, "精算の必要はありません。", _
                                                "過去分の売上伝票出力に移行しますか？", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                    Message_form = Nothing
                    Application.DoEvents()
                    CLOSE_PROC()
                    Me.Dispose()
                    'Application.Exit()
                    Exit Sub
                End If
                REPRINT_MODE = True
                Message_form = Nothing
            Case Else       '精算画面を「決定」終了
                Me.Show()
                fAdjust_form.Dispose()
                fAdjust_form = Nothing


        End Select

        '初期化処理
        INIT_PROC()

        If REPRINT_MODE = False Then
            'デフォルト値セット
            CLOSE_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)        '締め日
            TOTAL_SALE_PRICE_T.Text = 0                                     '合計金額
            PRINT_FLG = False
            '印刷完了フラグ
            'データグリッドヘッダー生成
            GRIDVIEW_CREATE()

            'If REPRINT_MODE = False Then
            '取引情報セット
            TRN_SET(Nothing)

            'サマリー集計
            SUM_SET(Nothing)

            '集計
            CAL_PROC(Nothing)

        Else
            'デフォルト値セット
            CLOSE_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", DateAdd(DateInterval.Day, CDbl(-1), Now))        '締め日
            TOTAL_SALE_PRICE_T.Text = 0                                     '合計金額
            PRINT_FLG = False
            '印刷完了フラグ
            'データグリッドヘッダー生成
            GRIDVIEW_CREATE()

            '取引情報セット
            TRN_SET(CLOSE_DATE_T.Text)

            'サマリー集計
            SUM_SET(CLOSE_DATE_T.Text)

            '集計
            CAL_PROC(CLOSE_DATE_T.Text)
        End If

        PRINT_B.Focus()

    End Sub
    Private Sub DIFF_CASH_PROC()
        Dim OPE As Single
        Dim DIFF_CASH As Long

        oAdjust(0).sAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran)    '精算コード
        oAdjustDBIO.updateAdjustCode(oAdjust(0).sAdjustCode, oAdjust(0).sAdjustCode + 1, oTran)

        '精算区分
        If CLng(DIFF_CASH_T.Text) > 0 Then
            oAdjust(0).sAdjustClass = "入金"
            OPE = -1
        Else
            oAdjust(0).sAdjustClass = "出金"
            OPE = 1
        End If

        DIFF_CASH = oTool.ToRoundDown((DIFF_CASH_T.Text), 0) * OPE

        '金額
        oAdjust(0).sTotalPrice = DIFF_CASH

        '勘定科目コード
        oAdjust(0).sAccountCode = 1

        '補助勘定科目コード
        oAdjust(0).sSubAccountCode = 0

        'レジ（ドロワー）入金
        oAdjust(0).sDTotalPrice = DIFF_CASH

        oAdjust(0).sD10000Yen = oTool.ToRoundDown((DIFF_CASH / 10000), 0)
        oAdjust(0).sD5000Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - ((10000 * oAdjust(0).sD10000Yen))) / 5000), 0)
        oAdjust(0).sD1000Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen)) / 1000), 0)
        oAdjust(0).sD500Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen)) / 500), 0)
        oAdjust(0).sD100Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen) _
                                     - (500 * oAdjust(0).sD500Yen)) / 100), 0)
        oAdjust(0).sD50Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen) _
                                     - (500 * oAdjust(0).sD500Yen) _
                                     - (100 * oAdjust(0).sD100Yen)) / 50), 0)
        oAdjust(0).sD10Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen) _
                                     - (500 * oAdjust(0).sD500Yen) _
                                     - (100 * oAdjust(0).sD100Yen) _
                                     - (50 * oAdjust(0).sD50Yen)) / 10), 0)
        oAdjust(0).sD5Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen) _
                                     - (500 * oAdjust(0).sD500Yen) _
                                     - (100 * oAdjust(0).sD100Yen) _
                                     - (50 * oAdjust(0).sD50Yen) _
                                     - (10 * oAdjust(0).sD10Yen)) / 5), 0)
        oAdjust(0).sD1Yen = oTool.ToRoundDown(((DIFF_CASH _
                                     - (10000 * oAdjust(0).sD10000Yen) _
                                     - (5000 * oAdjust(0).sD5000Yen) _
                                     - (1000 * oAdjust(0).sD1000Yen) _
                                     - (500 * oAdjust(0).sD500Yen) _
                                     - (100 * oAdjust(0).sD100Yen) _
                                     - (50 * oAdjust(0).sD50Yen) _
                                     - (10 * oAdjust(0).sD10Yen) _
                                     - (5 * oAdjust(0).sD5Yen)) / 1), 0)
        '金庫入金
        oAdjust(0).sKTotalPrice = 0
        oAdjust(0).sK10000Yen = 0
        oAdjust(0).sK5000Yen = 0
        oAdjust(0).sK1000Yen = 0
        oAdjust(0).sK500Yen = 0
        oAdjust(0).sK100Yen = 0
        oAdjust(0).sK50Yen = 0
        oAdjust(0).sK10Yen = 0
        oAdjust(0).sK5Yen = 0
        oAdjust(0).sK1Yen = 0

        oAdjustDBIO.insertAdjust(oAdjust(0), oTran)
    End Sub
    '----------------------------------------- < 内部関数 > -------------------------------------------
    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        TRN_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim column As New DataGridViewTextBoxColumn
        column.HeaderText = "ﾁｬﾈﾙ名称"
        TRN_V.Columns.Add(column)
        column.Width = 70
        column.ReadOnly = True
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column.Name = "チャネル名称"

        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "取引ｺｰﾄﾞ"
        TRN_V.Columns.Add(column0)
        column0.Width = 60
        column0.ReadOnly = True
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column0.Name = "取引ｺｰﾄﾞ"

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "明細ｺｰﾄﾞ"
        TRN_V.Columns.Add(column1)
        column1.Width = 60
        column1.ReadOnly = True
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column1.Name = "明細ｺｰﾄﾞ"

        '取引方法（支払方法）
        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "取引方法"
        TRN_V.Columns.Add(column2)
        column2.Width = 65
        column2.ReadOnly = True
        column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column2.Name = "取引方法"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "売上状態"
        TRN_V.Columns.Add(column3)
        column3.Width = 65
        column3.ReadOnly = True
        column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column3.Name = "売上状態"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "商品コード"
        TRN_V.Columns.Add(column4)
        column4.Width = 70
        column4.ReadOnly = True
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column4.Name = "商品コード"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "商品名称"
        TRN_V.Columns.Add(column5)
        column5.Width = 210
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column5.Name = "商品名称"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "オプション"
        TRN_V.Columns.Add(column6)
        column6.Width = 220
        column6.ReadOnly = True
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column6.Name = "オプション"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "数量"
        TRN_V.Columns.Add(column7)
        column7.Width = 55
        column7.ReadOnly = True
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "数量"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "金額"
        TRN_V.Columns.Add(column8)
        column8.Width = 80
        column8.ReadOnly = True
        column8.DefaultCellStyle.Format = "c"
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "金額"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "値引き"
        TRN_V.Columns.Add(column9)
        column9.Width = 80
        column9.ReadOnly = True
        column9.Visible = False
        column9.DefaultCellStyle.Format = "c"
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "値引き"

        Dim column10 As New DataGridViewTextBoxColumn
        column10.HeaderText = "部門コード"
        TRN_V.Columns.Add(column10)
        column10.Width = 0
        column10.ReadOnly = True
        column10.Visible = False
        column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column10.Name = "部門コード"

        '背景色を白に設定
        TRN_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        TRN_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------サマリー用グリッド----------------------
        'レコードセレクタを非表示に設定

        SUM_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim Scolumn0 As New DataGridViewTextBoxColumn
        Scolumn0.HeaderText = "区分"
        SUM_V.Columns.Add(Scolumn0)
        Scolumn0.Width = 65
        Scolumn0.ReadOnly = True
        Scolumn0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Scolumn0.Name = "区分"

        Dim Scolumn1 As New DataGridViewTextBoxColumn
        Scolumn1.HeaderText = "チャネル名"
        SUM_V.Columns.Add(Scolumn1)
        Scolumn1.Width = 65
        Scolumn1.ReadOnly = True
        Scolumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Scolumn1.Name = "チャネル名"

        Dim Scolumn2 As New DataGridViewTextBoxColumn
        Scolumn2.HeaderText = "部門名"
        SUM_V.Columns.Add(Scolumn2)
        Scolumn2.Width = 65
        Scolumn2.ReadOnly = True
        ' *** START K.MINAGAWA 2013/04/04 ***
        ' Scolumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Scolumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' *** END   K.MINAGAWA 2013/04/04 ***
        Scolumn2.Name = "部門名"

        Dim Scolumn3 As New DataGridViewTextBoxColumn
        Scolumn3.HeaderText = "支払方法"
        SUM_V.Columns.Add(Scolumn3)
        Scolumn3.Width = 65
        Scolumn3.ReadOnly = True
        Scolumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Scolumn3.Name = "支払方法"

        Dim Scolumn4 As New DataGridViewTextBoxColumn
        Scolumn4.HeaderText = "数量"
        SUM_V.Columns.Add(Scolumn4)
        Scolumn4.Width = 55
        Scolumn4.ReadOnly = True
        Scolumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Scolumn4.Name = "数量"

        Dim Scolumn5 As New DataGridViewTextBoxColumn
        Scolumn5.HeaderText = "売上"
        SUM_V.Columns.Add(Scolumn5)
        Scolumn5.Width = 65
        Scolumn5.ReadOnly = True
        Scolumn5.DefaultCellStyle.Format = "c"
        Scolumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Scolumn5.Name = "売上"

        Dim Scolumn6 As New DataGridViewTextBoxColumn
        Scolumn6.HeaderText = "送料"
        SUM_V.Columns.Add(Scolumn6)
        Scolumn6.Width = 65
        Scolumn6.ReadOnly = True
        Scolumn6.DefaultCellStyle.Format = "c"
        Scolumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Scolumn6.Name = "送料"

        Dim Scolumn7 As New DataGridViewTextBoxColumn
        Scolumn7.HeaderText = "手数料"
        SUM_V.Columns.Add(Scolumn7)
        Scolumn7.Width = 65
        Scolumn7.ReadOnly = True
        Scolumn7.DefaultCellStyle.Format = "c"
        Scolumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Scolumn7.Name = "手数料"

        '背景色を白に設定
        SUM_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        SUM_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon
    End Sub

    '***********************************************
    '取引情報をを画面にセット
    '***********************************************
    Private Function TRN_SET(ByVal KeyCloseDate As String) As Long
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim opt As String

        '取引データの読み込み
        If KeyCloseDate = Nothing Then
            RecordCnt = oTrnFullDBIO.getTrnFull(oTrnFull, "-1", Nothing, oTran)
        Else
            RecordCnt = oTrnFullDBIO.getTrnFull(oTrnFull, CLOSE_DATE_T.Text, Nothing, oTran)
        End If

        Me.SuspendLayout()

        '表示設定
        For i = 0 To RecordCnt - 1
            Select Case oTrnFull(i).sSubTrnClass
                Case M_DISCOUNT_U
                    oTrnFull(i).sProductCode = "(値引き)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sTotalDiscount
                Case M_POSTAGE
                    oTrnFull(i).sProductCode = "(送料)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sShippingCharge
                Case M_FEE
                    oTrnFull(i).sProductCode = "(手数料)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sPaymentCharge
                Case M_DISCOUNT_M
                    oTrnFull(i).sProductCode = "(値引き)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sTotalDiscount
                Case M_DISCOUNT_P
                    oTrnFull(i).sProductCode = "(値引き)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sTotalDiscount
                Case M_DISCOUNT_C
                    oTrnFull(i).sProductCode = "(値引き)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sTotalDiscount
                Case M_DISCOUNT_T
                    oTrnFull(i).sProductCode = "(値引き)"
                    'oTrnFull(i).sPrice = oTrnFull(i).sTotalDiscount
            End Select
            opt = ""
            If oTrnFull(i).sOption1 <> "" Then
                opt = opt & oTrnFull(i).sOption1 & "："
            End If
            If oTrnFull(i).sOption2 <> "" Then
                opt = opt & oTrnFull(i).sOption2 & "："
            End If
            If oTrnFull(i).sOption3 <> "" Then
                opt = opt & oTrnFull(i).sOption3 & "："
            End If
            If oTrnFull(i).sOption4 <> "" Then
                opt = opt & oTrnFull(i).sOption4 & "："
            End If
            If oTrnFull(i).sOption5 <> "" Then
                opt = opt & oTrnFull(i).sOption5 & "："
            End If
            TRN_V.Rows.Add( _
                    oTrnFull(i).sChannelName, _
                    oTrnFull(i).sTrnCode, _
                    oTrnFull(i).sSubTrnCode, _
                    oTrnFull(i).sPaymentName, _
                    oTrnFull(i).sTrnClass, _
                    oTrnFull(i).sProductCode, _
                    oTrnFull(i).sProductName, _
                    opt, _
                    oTrnFull(i).sCount, _
                    oTrnFull(i).sPrice, _
                    oTrnFull(i).sDiscountPrice, _
                    oTrnFull(i).sBumonCode _
            )
        Next i

        Me.ResumeLayout(False)
        TRN_SET = i
    End Function
    Private Sub INIT_PROC()
        Dim i As Integer

        CLOSE_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)

        For i = 0 To SUM_V.Rows.Count - 1
            SUM_V.Rows.Clear()
        Next

        For i = 0 To TRN_V.Rows.Count - 1
            TRN_V.Rows.Clear()
        Next
        INPUT_CASH_T.Text = String.Format("{0:C}", 0)
        INPUT_CASH_T.ReadOnly = True
        INPUT_CASH_T.TabStop = False

        OUTPUT_CASH_T.Text = String.Format("{0:C}", 0)
        OUTPUT_CASH_T.ReadOnly = True
        OUTPUT_CASH_T.TabStop = False

        RETURN_CASH_T.Text = String.Format("{0:C}", 0)
        RETURN_CASH_T.ReadOnly = True
        RETURN_CASH_T.TabStop = False

        TOTAL_SALE_PRICE_T.Text = String.Format("{0:C}", 0)
        TOTAL_SALE_PRICE_T.ReadOnly = True
        TOTAL_SALE_PRICE_T.TabStop = False

        CAL_CASH_T.Text = String.Format("{0:C}", 0)
        CAL_CASH_T.ReadOnly = True
        CAL_CASH_T.TabStop = False

        STIFFNESS_CASH_T.Text = String.Format("{0:C}", 0)
        STIFFNESS_CASH_T.ReadOnly = True
        STIFFNESS_CASH_T.TabStop = False

        DIFF_CASH_T.Text = String.Format("{0:C}", 0)
        DIFF_CASH_T.ReadOnly = True
        DIFF_CASH_T.TabStop = False

        If REPRINT_MODE = True Then
            CLOSE_DATE_T.ReadOnly = True
            CLOSE_DATE_T.TabStop = False

            RET_CASH_T.Text = String.Format("{0:C}", 0)
            RET_CASH_T.ReadOnly = True
            RET_CASH_T.TabStop = False

            RET_CASH_B.Enabled = False
            SEARCH_B.Enabled = True
            RETURN_B.Enabled = False
            COMMIT_B.Enabled = True

            MODE_L.Text = "日計集計表確認モード"
            MODE_L.BackColor = Color.Red
        Else
            CLOSE_DATE_T.ReadOnly = False
            CLOSE_DATE_T.TabStop = True

            RET_CASH_T.Text = String.Format("{0:C}", 0)
            RET_CASH_T.ReadOnly = False
            RET_CASH_T.TabStop = True

            RET_CASH_B.Enabled = True
            SEARCH_B.Enabled = True
            RETURN_B.Enabled = True
            COMMIT_B.Enabled = True

            MODE_L.Text = "日次締め処理モード"
            MODE_L.BackColor = Color.DarkBlue
        End If

        PRINT_B.Focus()

    End Sub

    Private Sub TRN_V_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles TRN_V.CellPainting
        '列ヘッダーかどうか調べる
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)

            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画が完了したことを知らせる
            e.Handled = True
        End If

    End Sub
    Private Function UPDATE_CLOSEDAY(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim pTrnDBIO As New cDataTrnDBIO(oConn, oCommand, oDataReader)
        Dim pAdjustDBIO As New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        Dim ret As Boolean

        'Tran = Nothing
        'oConn.BeginTransaction()

        '日次取引データの日次締め日を更新
        ret = pTrnDBIO.updateTrnCloseDay(String.Format("{0:yyyy/MM/dd}", DateTime.Parse(CLOSE_DATE_T.Text)), Tran)
        pTrnDBIO = Nothing
        If ret = False Then
            Tran.Rollback()
            UPDATE_CLOSEDAY = False
            Exit Function
        End If

        UPDATE_CLOSEDAY = True

        ''精算データの月次締め日を更新
        'ret = pAdjustDBIO.updateCloseDate(String.Format("{0:yyyy/MM/dd}", DateTime.Parse(CLOSE_DATE_T.Text)), Tran)
        'pAdjustDBIO = Nothing
        'If ret = False Then
        '    Tran.Rollback()
        '    Exit Sub
        'End If
        'Tran.Commit()
    End Function
    Private Sub CAL_DATA_CREATE()

        oCalc(0).sCalcCode = oCalcDBIO.readMaxCalcCode(oTran) + 1
        oCalc(0).sCalcClass = "日次"
        oCalc(0).sCalcDate = String.Format("{0:yyyy/MM/dd}", Now)
        oCalc(0).sCalcTime = String.Format("{0:HH:mm:ss}", Now)
        oCalc(0).sCashSales = SOU_CASH
        oCalc(0).sCashSalesCnt = COUNT_CASH
        oCalc(0).sCashDiscount = DIS_CASH
        oCalc(0).sCreditSales = SOU_CARD
        oCalc(0).sCreditSalesCnt = COUNT_CARD
        oCalc(0).sCreditDiscount = DIS_CARD
        oCalc(0).sInCash = InputCash
        oCalc(0).sInCashCnt = InputCashCnt
        oCalc(0).sOutCash = OutPutCash
        oCalc(0).sOutCashCnt = OutPutCashCnt
        If RET_CASH_T.Text = "" Then
            oCalc(0).sRetCash = 0
        Else
            oCalc(0).sRetCash = CLng(RET_CASH_T.Text)
        End If
        oCalc(0).sBalance = CalCash
        oCalc(0).sCustCnt_0_1 = CUST_COUNT(0)
        oCalc(0).sCustCnt_1_2 = CUST_COUNT(1)
        oCalc(0).sCustCnt_2_3 = CUST_COUNT(2)
        oCalc(0).sCustCnt_3_4 = CUST_COUNT(3)
        oCalc(0).sCustCnt_4_5 = CUST_COUNT(4)
        oCalc(0).sCustCnt_5_6 = CUST_COUNT(5)
        oCalc(0).sCustCnt_6_7 = CUST_COUNT(6)
        oCalc(0).sCustCnt_7_8 = CUST_COUNT(7)
        oCalc(0).sCustCnt_8_9 = CUST_COUNT(8)
        oCalc(0).sCustCnt_9_10 = CUST_COUNT(9)
        oCalc(0).sCustCnt_10_11 = CUST_COUNT(10)
        oCalc(0).sCustCnt_11_12 = CUST_COUNT(11)
        oCalc(0).sCustCnt_12_13 = CUST_COUNT(12)
        oCalc(0).sCustCnt_13_14 = CUST_COUNT(13)
        oCalc(0).sCustCnt_14_15 = CUST_COUNT(14)
        oCalc(0).sCustCnt_15_16 = CUST_COUNT(15)
        oCalc(0).sCustCnt_16_17 = CUST_COUNT(16)
        oCalc(0).sCustCnt_17_18 = CUST_COUNT(17)
        oCalc(0).sCustCnt_18_19 = CUST_COUNT(18)
        oCalc(0).sCustCnt_19_20 = CUST_COUNT(19)
        oCalc(0).sCustCnt_20_21 = CUST_COUNT(20)
        oCalc(0).sCustCnt_21_22 = CUST_COUNT(21)
        oCalc(0).sCustCnt_22_23 = CUST_COUNT(22)
        oCalc(0).sCustCnt_23_24 = CUST_COUNT(23)

        If oCalcDBIO.insertCalc(oCalc, oTran) = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            Message_form = New cMessageLib.fMessage(1, "集計データの登録に失敗しました。", _
                                            "システムの開発元に連絡して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        End If

    End Sub
    Private Sub CAL_PROC(ByVal KeyCloseDate As String)
        Dim i As Integer
        'Dim j As Integer
        Dim RecordCount As Integer
        Dim DiffCash As Long
        Dim Count As Long
        Dim FromAdjustCode As Long
        Dim ToAdjustCode As Long

        '現金集計計算
        OpenCash = 0
        InputCash = 0
        OutPutCash = 0
        ReturnCash = 0
        AdujustCash = 0
        Count = 0
        InputCashCnt = 0
        OutPutCashCnt = 0

        ReDim oAdjust(0)
        If KeyCloseDate = Nothing Then

            '2016.07.14 K.Oikawa s
            '最終の「レジ入金」の精算コードを取得
            FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", Nothing, Nothing, oTran)
            '最終の精算コードを取得
            ToAdjustCode = oAdjustDBIO.getBeforeAdjust(FromAdjustCode, oTran)
            ''課題表No最終の「精算」の精算コードを取得
            'FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
            ''最終の精算コードを取得
            'ToAdjustCode = oAdjustDBIO.getBeforeAdjust(ToAdjustCode, oTran)
            '2016.07.14 K.Oikawa e

            If ToAdjustCode < FromAdjustCode Then
                ToAdjustCode = Nothing
            End If

            '2016.06.09 K.Oikawa s
            'mode廃止
            'RecordCount = oAdjustDBIO.getAdjust(oAdjust, FromAdjustCode, ToAdjustCode, Nothing, cStructureLib.GetAdjustMode.OrderOverAdjustCode, oTran)
            RecordCount = oAdjustDBIO.getAdjust3(oAdjust, FromAdjustCode, ToAdjustCode, Nothing, Nothing, Nothing, oTran)
            '2016.06.09 K.Oikawa e

        Else
            ''指定締め日当日の精算データを取得

            '2016.06.09 K.Oikawa s
            'mode廃止
            'RecordCount = oAdjustDBIO.getAdjust(oAdjust, Nothing, Nothing, KeyCloseDate, cStructureLib.GetAdjustMode.AdjustDate, oTran)
            RecordCount = oAdjustDBIO.getAdjust3(oAdjust, Nothing, Nothing, KeyCloseDate, Nothing, Nothing, oTran)
            '2016.06.09 K.Oikawa e

            If RecordCount = 0 Then
                Exit Sub
            End If
        End If


        For i = 0 To oAdjust.Count - 1
            Select Case oAdjust(i).sAdjustClass
                Case "レジ入金"
                    OpenCash = OpenCash + CLng(oAdjust(i).sTotalPrice)

                Case "入金"
                    InputCash = InputCash + CLng(oAdjust(i).sTotalPrice)
                    InputCashCnt = InputCashCnt + 1
                Case "出金"
                    If oAdjust(i).sAccountCode = 0 And oAdjust(i).sSubAccountCode = 0 Then
                        RET_CASH_T.Text = String.Format("{0:C}", System.Math.Abs(oAdjust(i).sTotalPrice))
                    Else
                        OutPutCash = OutPutCash + CLng(oAdjust(i).sTotalPrice)
                        OutPutCashCnt = OutPutCashCnt + 1
                    End If
                Case "戻入"
                    ReturnCash = ReturnCash + CLng(oAdjust(i).sTotalPrice)
                Case "精算"
                    AdujustCash = AdujustCash + CLng(oAdjust(i).sTotalPrice)
                    STIFFNESS_CASH = CLng(oAdjust(i).sTotalPrice)

            End Select
        Next i

        '計算
        If TOTAL_SALE_PRICE_T.Text = "" Then
            '2016.07.12 K.Oikawa s
            CalCash = AdujustCash + InputCash + OutPutCash + ReturnCash + 0
            'CalCash = OpenCash + InputCash + OutPutCash + ReturnCash + 0
            '2016.07.12 K.Oikawa e
        Else
            '2016.07.12 K.Oikawa s
            'TODO:課題表N　算出の方法要確認
            CalCash = oAdjust(0).sTotalPrice + InputCash + OutPutCash + ReturnCash + CLng(TOTAL_SALE_PRICE_T.Text)
            'CalCash = OpenCash + InputCash + OutPutCash + ReturnCash + CLng(TOTAL_SALE_PRICE_T.Text)
            '2016.07.12 K.Oikawa e
        End If


        If STIFFNESS_CASH = 0 Then
            DiffCash = 0
        Else
            DiffCash = CLng(STIFFNESS_CASH) - CalCash
        End If

        '画面セット
        INPUT_CASH_T.Text = String.Format("{0:C}", InputCash)
        OUTPUT_CASH_T.Text = String.Format("{0:C}", OutPutCash)
        RETURN_CASH_T.Text = String.Format("{0:C}", ReturnCash)
        CAL_CASH_T.Text = String.Format("{0:C}", CalCash)
        STIFFNESS_CASH_T.Text = String.Format("{0:C}", STIFFNESS_CASH)
        DIFF_CASH_T.Text = String.Format("{0:C}", DiffCash)

        If DiffCash <> 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "現金差額が発生しております。", _
                                            "再度、現金残高を確認して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            PRINT_B.Enabled = False
            DIFF_CASH_T.ForeColor = Color.Red
        Else
            PRINT_B.Enabled = True
            DIFF_CASH_T.ForeColor = Color.Black
        End If

        ''帳票用集計
        'ReDim oBumon(0)
        'ReDim BUMON_CNT(0)
        'ReDim BUMON_PRICE(0)

        'RecordCount = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, oTran)
        'ReDim BUMON_CNT(oBumon.Count - 1)
        'ReDim BUMON_PRICE(oBumon.Count - 1)

        '計算処理
        'If IsDBNull(oTrnFull) <> False Then
        '    For i = 0 To oTrnFull.Length - 1
        '        '部門毎売上合計／売上数量の取得
        '        For j = 0 To oBumon.Count - 1
        '            If oTrnFull(i).sBumonCode = oBumon(j).sBumonCode Then
        '                '売上金額
        '                BUMON_PRICE(j) = BUMON_PRICE(j) + oTrnFull(i).sNoTaxProductPrice       '売上金額
        '                BUMON_PRICE(j) = BUMON_PRICE(j) - oTrnFull(i).sDiscountPrice    '値引き金額
        '                BUMON_PRICE(j) = BUMON_PRICE(j) + oTrnFull(i).sPostage          '送料
        '                BUMON_PRICE(j) = BUMON_PRICE(j) + oTrnFull(i).sFee              '手数料

        '                '売上個数
        '                BUMON_CNT(j) = BUMON_CNT(j) + oTrnFull(i).sCount
        '            End If
        '        Next j

        '        '支払方法別集計
        '        If oTrnFull(i).sTrnClass = "売上" Then
        '            Select Case oTrnFull(i).sp
        '                Case "現金"
        '                    SOU_CASH = SOU_CASH + oTrnFull(i).sSalePrice
        '                    COUNT_CASH = COUNT_CASH + oTrnFull(i).sCnt
        '                Case "信用"
        '                    SOU_CARD = SOU_CARD + oTrnFull(i).sSalePrice
        '                    COUNT_CARD = COUNT_CARD + oTrnFull(i).sCnt
        '            End Select
        '        End If

        '        '値引き額の集計
        '        If oTrnFull(i).sDiscountPrice > 0 Then
        '            Select Case TRN_V("取引方法", i).Value
        '                Case "現金"
        '                    DIS_CASH = DIS_CASH + oTrnFull(i).sDiscountPrice
        '                Case "信用"
        '                    DIS_CARD = DIS_CARD + oTrnFull(i).sDiscountPrice
        '            End Select
        '        End If
        '    Next i
        'End If

        '集計データ作成
        CAL_DATA_CREATE()

    End Sub
    Private Sub SUM_SET(ByVal KeyCloseDate As String)
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim TotalCash As Long

        '取引サマリーデータの読み込み
        '-------------------------------------------------------------------------------------------
        '2019/10/5 suzuki「送料の合計」と「手数料の合計」を正しく取るためのメゾット呼び出し追加
        '-------------------------------------------------------------------------------------------
        ReDim oTrnSummary(0)
        If KeyCloseDate = Nothing Then
            RecordCnt = oTrnSummaryDBIO.getTrnSummary(oTrnSummary, Nothing, oTran)
            oTrnSummaryDBIO.GetTrnSummary2(oTrnSummary, Nothing, oTran)
        Else
            RecordCnt = oTrnSummaryDBIO.getTrnSummary(oTrnSummary, CLOSE_DATE_T.Text.ToString.Replace(" ", ""), oTran)
            oTrnSummaryDBIO.GetTrnSummary2(oTrnSummary, CLOSE_DATE_T.Text.ToString.Replace(" ", ""), oTran)
        End If
        '-------------------------------------------------------------------------------------------
        '2019/10/5 suzuki「送料の合計」と「手数料の合計」を正しく取るためのメゾット呼び出し追加 END
        '-------------------------------------------------------------------------------------------
        Me.SuspendLayout()

        '表示設定
        TotalCash = 0
        For i = 0 To RecordCnt - 1
            SUM_V.Rows.Add( _
                    oTrnSummary(i).sTrnClass, _
                    oTrnSummary(i).sChannelName, _
                    oTrnSummary(i).sBumonShortName, _
                    oTrnSummary(i).sPaymentName, _
                    oTrnSummary(i).sCount, _
                    oTrnSummary(i).sPrice, _
                    oTrnSummary(i).sShippingCharge, _
                    oTrnSummary(i).sPaymentCharge _
            )
            Select Case oTrnSummary(i).sPaymentName
                Case "現金払い"
                    If oTrnSummary(i).sTrnClass <> "販促" Then
                        TotalCash = TotalCash + oTrnSummary(i).sPrice
                        SOU_CASH = TotalCash
                    End If
                Case "クレジットカード払い"
            End Select
        Next i
        TOTAL_SALE_PRICE_T.Text = String.Format("{0:C}", TotalCash)
        Me.ResumeLayout(False)

    End Sub
    Private Sub CLOSE_PROC()
        oConn = Nothing
        oCommand = Nothing
        oDataReader = Nothing

        oTrnFullDBIO = Nothing
        oConfMstDBIO = Nothing
        oAdjustDBIO = Nothing
        oTrnSummaryDBIO = Nothing
        oBumonDBIO = Nothing
        oCalcDBIO = Nothing
        oTool = Nothing

        Me.Dispose()
    End Sub
    '-------------------------- ジャーナル印刷 -------------------------------

    '******************************************
    '      日次ジャーナル印刷
    '******************************************
    Private Function JURNAL_PRINTING() As Boolean
        Dim ret As Integer
        Dim pData As String
        Dim i As Integer
        Dim j As Integer
        Dim str As String
        Dim RecordCount As Long

        JURNAL_PRINTING = False

        oTool = New cTool

        'プリンターオープン
        OPOSPrinter1.Close()
        ret = OPOSPrinter1.Open("TRST56U")
        If ret Then
            Dim message_form As New cMessageLib.fMessage(1, _
                                  "レシートプリンターの", _
                                  "接続に失敗しました(ERRCODE:" & Trim(CStr(ret)), _
                                  "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

        ret = OPOSPrinter1.ClaimDevice(1000)
        If ret Then
            Dim message_form As New cMessageLib.fMessage(1, _
                                  "レシートプリンターの", _
                                  "初期化に失敗しました(ERRCODE:" & Trim(CStr(ret)), _
                                  "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If
        OPOSPrinter1.DeviceEnabled = True

        ReDim oBumon(0)
        ReDim BUMON_CNT(0)
        ReDim BUMON_PRICE(0)

        RecordCount = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        ReDim BUMON_CNT(oBumon.Count - 1)
        ReDim BUMON_PRICE(oBumon.Count - 1)

        '計算処理
        For i = 0 To TRN_V.Rows.Count - 1

            '部門毎売上合計／売上数量の取得
            For j = 0 To oBumon.Count - 1
                If TRN_V("明細ｺｰﾄﾞ", i).Value = oBumon(j).sBumonCode Then

                    '売上金額
                    BUMON_PRICE(j) = BUMON_PRICE(j) + CLng(TRN_V("値引き", i).Value)
                    BUMON_PRICE(j) = BUMON_PRICE(j) - CLng(TRN_V("明細ｺｰﾄﾞ", i).Value)
                    BUMON_PRICE(j) = BUMON_PRICE(j) + CLng(TRN_V("明細ｺｰﾄﾞ", i).Value)
                    BUMON_PRICE(j) = BUMON_PRICE(j) + CLng(TRN_V("明細ｺｰﾄﾞ", i).Value)

                    '売上個数
                    BUMON_CNT(j) = BUMON_CNT(j) + CInt(TRN_V("金額", i).Value)
                End If
            Next j

            '支払方法別集計
            Select Case TRN_V("取引方法", i).Value
                Case "現金"
                    SOU_CASH = SOU_CASH + CLng(TRN_V("値引き", i).Value)
                    COUNT_CASH = COUNT_CASH + CInt(TRN_V("金額", i).Value)
                Case "信用"
                    SOU_CARD = SOU_CARD + CLng(TRN_V("値引き", i).Value)
                    COUNT_CARD = COUNT_CARD + CInt(TRN_V("金額", i).Value)
            End Select

            '値引き額の集計
            If CLng(TRN_V("明細ｺｰﾄﾞ", i).Value) > 0 Then
                Select Case TRN_V("取引方法", i).Value
                    Case "現金"
                        DIS_CASH = DIS_CASH + CLng(TRN_V("明細ｺｰﾄﾞ", i).Value)
                    Case "信用"
                        DIS_CARD = DIS_CARD + CLng(TRN_V("明細ｺｰﾄﾞ", i).Value)
                End Select
            End If
        Next i

        '同期印刷On
        OPOSPrinter1.AsyncMode = True

        '一括印刷　On
        OPOSPrinter1.TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)

        'ロゴ印刷
        'レシートBitMapの読込み
        ret = OPOSPrinter1.SetBitmap(1, PTR_S_RECEIPT, oConf(0).sRLogoPass, PTR_BM_ASIS, PTR_BM_CENTER)
        pData = Chr(27) & "|1B" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '印刷日時
        pData = Chr(27) & "|cA" & String.Format("精算{0:yyyy/MM/dd dddddd HH:mm:ss}", Now) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '担当者
        pData = Chr(27) & "|cA" & "担当者:" & STAFF_NAME_T.Text.ToString & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        'タイトル（日計明細）
        pData = Chr(27) & "|cA" & "<< 日計明細 >>" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '売上総合集計
        pData = String.Format("総売上高                   {0,9:C}", SOU_CASH + SOU_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("値引き額合計               {0,9:C}", DIS_CASH + DIS_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("総売上点数               {0,9:#,##0}点", COUNT_CASH + COUNT_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("現金売上額                 {0,9:C}", SOU_CASH) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("現金値引き額合計           {0,9:C}", DIS_CASH) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("現金売上点数             {0,9:#,##0}点", COUNT_CASH) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("信用売上額                 {0,9:C}", SOU_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("信用値引き額合計           {0,9:C}", DIS_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        pData = String.Format("信用売上点数　　         {0,9:#,##0}点", COUNT_CARD) & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)


        'ライン
        pData = "-----------------------------------" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '部門別集計結果印刷
        For i = 0 To oBumon.Count - 1
            str = oBumon(i).sBumonShortName & "                          "
            pData = oTool.MidB(str, 1, 26) & " " & _
                    String.Format("{0,9:C}", BUMON_PRICE(i)) & Chr(10)
            ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)
            pData = String.Format("                         {0,9:#,##0}点", BUMON_CNT(i)) & Chr(10)
            ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)
        Next i

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        'ラインフィード＆用紙カット
        pData = Chr(27) & "|fP"
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '一括印刷　Off
        OPOSPrinter1.TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)

        JURNAL_PRINTING = True
    End Function
    Private Function REPORT_PRINTING() As Boolean
        Dim oReportsLib As New cReportsLib.cReportsLib

        If REPRINT_MODE = False Then
            REPORT_PRINTING = oReportsLib.DayClosePrint(oConn, oCommand, oDataReader, oCalc, oTrnSummary, STAFF_CODE, _
                                                                        STAFF_NAME, Nothing, CLOSE_DATE_T.Text, MS_PRINT_FLG, oTran)
        Else
            REPORT_PRINTING = oReportsLib.DayClosePrint(oConn, oCommand, oDataReader, oCalc, oTrnSummary, STAFF_CODE, _
                                                                        STAFF_NAME, CLOSE_DATE_T.Text, CLOSE_DATE_T.Text, MS_PRINT_FLG, oTran)
        End If

        Application.DoEvents()
    End Function

    Private Sub RET_CASH_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RET_CASH_T.GotFocus
        Dim fAdjust_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, CLOSE_DATE_T.Text, STAFF_CODE, STAFF_NAME, 5, oTran)

        fAdjust_form.ShowDialog()
        If fAdjust_form.DialogResult = Windows.Forms.DialogResult.OK Then
            RET_CASH_T.Text = String.Format("{0:C}", CLng(fAdjust_form.TPRICE_T.Text))
            oCalc(0).sRetCash = CLng(RET_CASH_T.Text)
        End If

        fAdjust_form.Dispose()
        fAdjust_form = Nothing
        Application.DoEvents()

    End Sub

    Private Sub PRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINT_B.Click
        Dim ret As Boolean
        Dim AdjustCode As Long
        ' *** START K.MINAGAWA 2013/04/29 ***
        Dim Check_Form As cMessageLib.fCheckMessage
        Dim RecordCount As Long


        ' 明細部の出力要否を確認する
        MS_PRINT_FLG = False
        STAFF_RIGHTS_FLG = False

        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstStaffDBIO.getStaff(oMstStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        ' 社員のみ、チェックボックスを操作可能にする
        If oMstStaff(0).sStaffClass = "E" Then
            STAFF_RIGHTS_FLG = True
        End If

        Check_Form = New cMessageLib.fCheckMessage("明細部を印書しますか？", _
                                                   "明細を印書する。", _
                                                   MS_PRINT_FLG, _
                                                   STAFF_RIGHTS_FLG)
        Check_Form.ShowDialog()

        Application.DoEvents()

        If Check_Form.DialogResult = Windows.Forms.DialogResult.Yes Then
            MS_PRINT_FLG = True
        Else
            MS_PRINT_FLG = False
        End If
        ' *** END   K.MINAGAWA 2013/04/29 ***

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage
        Message_form = New cMessageLib.fMessage(0, "日次集計表を印刷中です。", _
                                        "しばらくお待ちください。", _
                                        Nothing, Nothing)
        Message_form.Show()

        Application.DoEvents()

        AdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, "=", oTran)
        oAdjustDBIO.updateDayCloseDate(AdjustCode, oTool.MaskClear(CLOSE_DATE_T.Text), oTran)

        If OUTPUT1_R.Checked = True Then
            ret = JURNAL_PRINTING()
        Else
            ret = REPORT_PRINTING()
        End If
        If ret = True Then
            PRINT_FLG = True
        End If

        ' *** START K.MINAGAWA 2013/04/29 ***
        Check_Form.Dispose()
        ' *** END   K.MINAGAWA 2013/04/29 ***
        Message_form.Dispose()

    End Sub

    Private Sub RET_CASH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RET_CASH_B.Click
        Dim fAdjust_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, CLOSE_DATE_T.Text, STAFF_CODE, STAFF_NAME, 5, oTran)

        fAdjust_form.ShowDialog()
        If fAdjust_form.DialogResult = Windows.Forms.DialogResult.OK Then
            RET_CASH_T.Text = String.Format("{0:C}", CLng(fAdjust_form.TPRICE_T.Text))
            oCalc(0).sRetCash = CLng(RET_CASH_T.Text)
        End If

        fAdjust_form.Dispose()
        fAdjust_form = Nothing
        Application.DoEvents()

    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim fInputDate As New fCloseDateInput
        Dim pCloseDate As String

        fInputDate.ShowDialog()
        If fInputDate.DialogResult = Windows.Forms.DialogResult.Cancel Then
            fInputDate = Nothing
            Exit Sub
        End If

        pCloseDate = fInputDate.CLOSE_DATE_T.Text.ToString.Replace(" ", "")

        REPRINT_MODE = True

        '画面初期化
        INIT_PROC()

        MODE_L.Text = "日計集計表確認モード"
        MODE_L.BackColor = Color.Red

        CLOSE_DATE_T.Text = pCloseDate

        '取引情報セット
        TRN_SET(pCloseDate)

        'サマリー集計
        SUM_SET(pCloseDate)

        '集計
        CAL_PROC(pCloseDate)

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim fAdjust_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, CLOSE_DATE_T.Text, STAFF_CODE, STAFF_NAME, 4, oTran)

        fAdjust_form.ShowDialog()
        If fAdjust_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Application.DoEvents()
            Application.Exit()
            Exit Sub
        End If

        '2016.07.13 K.Oikawa s
        '課題表No153 再計算後、再計算結果が反映されていなかった
        STIFFNESS_CASH = CLng(fAdjust_form.TPRICE_T.Text)
        '2016.07.13 K.Oikawa e

        '初期化処理
        INIT_PROC()

        If REPRINT_MODE = False Then
            'デフォルト値セット
            CLOSE_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", Now)        '締め日
            TOTAL_SALE_PRICE_T.Text = 0                                     '合計金額
            PRINT_FLG = False
            '印刷完了フラグ
            ''データグリッドヘッダー生成
            'GRIDVIEW_CREATE()

            'If REPRINT_MODE = False Then
            '取引情報セット
            TRN_SET(Nothing)

            'サマリー集計
            SUM_SET(Nothing)

            '集計
            CAL_PROC(Nothing)

        Else
            'デフォルト値セット
            CLOSE_DATE_T.Text = String.Format("{0:yyyy/MM/dd}", DateAdd(DateInterval.Day, CDbl(-1), Now))        '締め日
            TOTAL_SALE_PRICE_T.Text = 0                                     '合計金額
            PRINT_FLG = False
            '印刷完了フラグ
            'データグリッドヘッダー生成
            GRIDVIEW_CREATE()

            '取引情報セット
            TRN_SET(CLOSE_DATE_T.Text)

            'サマリー集計
            SUM_SET(CLOSE_DATE_T.Text)

            '集計
            CAL_PROC(CLOSE_DATE_T.Text)
        End If

        PRINT_B.Focus()

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(2, Nothing, _
                                        "今回の締め処理は無効となります。", _
                                        "よろしいですか？", Nothing)
        Message_form.ShowDialog()
        '確認ダイアログでNOが選択された場合
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If
        Message_form = Nothing

        oTran.Rollback()

        CLOSE_PROC()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim FromAdjustCode As String
        Dim ToAdjustCode As String
        Dim i As Integer
        Dim cnt As Integer

        If REPRINT_MODE = False Then
            If CLng(DIFF_CASH_T.Text) <> 0 Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(2, "現金差額が生じています。", _
                                                "レジ差額として処理して終了します。", _
                                                "よろしいですか？", Nothing)
                Message_form.ShowDialog()
                '確認ダイアログでNOが選択された場合
                If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                    Message_form = Nothing
                    Exit Sub
                End If
                Message_form = Nothing
                DIFF_CASH_PROC()

                'サマリー集計
                SUM_SET(Nothing)

                '集計
                CAL_PROC(Nothing)

                Exit Sub
            End If

            If PRINT_FLG = False Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(2, "集計表が印刷されていません。", _
                                                "今回の締め処理は無効となります。", _
                                                "よろしいですか？", Nothing)
                Message_form.ShowDialog()
                '確認ダイアログでNOが選択された場合
                If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                    Message_form = Nothing
                    Exit Sub
                End If
                Message_form = Nothing

                '削除対象の精算コード取得
                FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
                ToAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran)
                '精算データ削除
                cnt = 0
                For i = FromAdjustCode To ToAdjustCode
                    If oAdjustDBIO.deleteAdjust(i, oTran) = True Then
                        cnt = cnt + 1
                    End If
                Next i
                If cnt <> ToAdjustCode - FromAdjustCode + 1 Then
                    oTran.Rollback()
                    oTran = Nothing
                End If
            Else
                '日次取引データ・精算データの締め日更新
                UPDATE_CLOSEDAY(oTran)
                oTran.Commit()
                oTran = Nothing
            End If
        End If
        CLOSE_PROC()

    End Sub
End Class