Imports cReportsLib

Public Class fMonthClose
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oTrnSummary() As cStructureLib.sViewTrnSummary
    Private oTrnSummaryDBIO As cViewTrnSummaryDBIO

    Private oChannelDBIO As cMstChannelDBIO
    Private oChannel() As cStructureLib.sChannel

    Private oSupplierDBIO As cMstSupplierDBIO
    Private oSupplier() As cStructureLib.sSupplier

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTool As cTool

    Private oTran As OleDb.OleDbTransaction

    Private pProductTotal As Long
    Private pProductSaleTotal As Long
    Private pPostageTotal As Long
    Private pFeeTotal As Long
    Private pDiscountTotal As Long
    Private pServiceTotal As Long
    Private pSaleTotal As Long
    Private pStockTotal As Long
    Private pProfit As Long

    '2019,12,23 A.Komita 追加 From
    Private ORDER_MODE As Integer
    '2019,12,23 A.Komita 追加 To

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
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property

    Private Sub fMonthClose_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oTrnSummaryDBIO = New cViewTrnSummaryDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
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

        '期間情報セット
        If Now.Day < oConf(0).sCloseDay Then
            CLOSE_YEAR_T.Text = String.Format("{0:0000}", Now.AddMonths(-1).Year)
            CLOSE_MONTH_T.Text = String.Format("{0:00}", Now.AddMonths(-1).Month)
        Else
            CLOSE_YEAR_T.Text = String.Format("{0:0000}", Now.Year)
            CLOSE_MONTH_T.Text = String.Format("{0:00}", Now.Month)
        End If

        DEFAULT_DATE_SET()

        'チャネルリストボックスセット
        CHANNEL_SET()

        '仕入先リストボックスセット
        SUPPLIER_SET()

        'DataView生成
        GRIDVIEW_CREATE()

        '初期化
        INIT_PROC()

        '集計処理
        CAL_PROC()

        '初期表示タブ設定
        SALER_AREA.SelectedTab = SALER_TAB

        CLOSE_YEAR_T.Focus()
    End Sub

    Private Sub fMonthClose_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        '初期化処理
        INIT_PROC()

    End Sub

    '----------------------------------------- < 内部関数 > -------------------------------------------
    '***************************
    'チャネルリストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oChannel = Nothing
        RecordCnt = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタが登録されていません",
                                                "チャネルマスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        CHANNEL_NAME_C.Items.Add("指定なし")
        For i = 0 To RecordCnt - 1
            CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_CODE_T.Text = -1
    End Sub
    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません",
                                                "仕入先マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        SUPPLIER_NAME_C.Items.Add("指定なし")
        For i = 0 To RecordCnt - 1
            SUPPLIER_NAME_C.Items.Add(oSupplier(i).sSupplierName)
        Next
        SUPPLIER_CODE_T.Text = -1
    End Sub
    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    Sub GRIDVIEW_CREATE()
        '-------------チャネル別用グリッド----------------------
        'レコードセレクタを非表示に設定
        CHANNEL_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim channel0 As New DataGridViewTextBoxColumn
        channel0.HeaderText = "ﾁｬﾈﾙ名称"
        CHANNEL_V.Columns.Add(channel0)
        channel0.Width = 170
        channel0.ReadOnly = True
        channel0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        channel0.Name = "チャネル名称"

        Dim channel1 As New DataGridViewTextBoxColumn
        channel1.HeaderText = "売上数量"
        CHANNEL_V.Columns.Add(channel1)
        channel1.Width = 120
        channel1.ReadOnly = True
        channel1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        channel1.DefaultCellStyle.Format = "#,0"
        channel1.Name = "売上数量"

        Dim channel2 As New DataGridViewTextBoxColumn
        channel2.HeaderText = "売上金額"
        CHANNEL_V.Columns.Add(channel2)
        channel2.Width = 120
        channel2.ReadOnly = True
        channel2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        channel2.DefaultCellStyle.Format = "#,0"
        channel2.Name = "売上金額"

        '背景色を白に設定
        CHANNEL_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        CHANNEL_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------部門別用グリッド----------------------
        'レコードセレクタを非表示に設定

        BUMON_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim bumon0 As New DataGridViewTextBoxColumn
        bumon0.HeaderText = "部門名称"
        BUMON_V.Columns.Add(bumon0)
        bumon0.Width = 170
        bumon0.ReadOnly = True
        bumon0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        bumon0.Name = "部門名称"

        Dim bumon1 As New DataGridViewTextBoxColumn
        bumon1.HeaderText = "売上数量ﾞ"
        BUMON_V.Columns.Add(bumon1)
        bumon1.Width = 120
        bumon1.ReadOnly = True
        bumon1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        bumon1.DefaultCellStyle.Format = "#,0"
        bumon1.Name = "売上数量"

        Dim bumon2 As New DataGridViewTextBoxColumn
        bumon2.HeaderText = "売上金額"
        BUMON_V.Columns.Add(bumon2)
        bumon2.Width = 120
        bumon2.ReadOnly = True
        bumon2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        bumon2.DefaultCellStyle.Format = "#,0"
        bumon2.Name = "売上金額"

        '背景色を白に設定
        BUMON_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        BUMON_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------支払い方法別用グリッド----------------------
        'レコードセレクタを非表示に設定

        PAYMENT_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim payment0 As New DataGridViewTextBoxColumn
        payment0.HeaderText = "ﾁｬﾈﾙ名称"
        PAYMENT_V.Columns.Add(payment0)
        payment0.Width = 170
        payment0.ReadOnly = True
        payment0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        payment0.Name = "チャネル名称"

        Dim payment1 As New DataGridViewTextBoxColumn
        payment1.HeaderText = "売上数量ﾞ"
        PAYMENT_V.Columns.Add(payment1)
        payment1.Width = 120
        payment1.ReadOnly = True
        payment1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        payment1.DefaultCellStyle.Format = "#,0"
        payment1.Name = "売上数量"

        Dim payment2 As New DataGridViewTextBoxColumn
        payment2.HeaderText = "売上金額"
        PAYMENT_V.Columns.Add(payment2)
        payment2.Width = 120
        payment2.ReadOnly = True
        payment2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        payment2.DefaultCellStyle.Format = "#,0"
        payment2.Name = "売上金額"

        '背景色を白に設定
        PAYMENT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        PAYMENT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------カテゴリ別用グリッド----------------------
        'レコードセレクタを非表示に設定
        CATEGORY_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim category0 As New DataGridViewTextBoxColumn
        category0.HeaderText = "ｶﾃｺﾞﾘ名称"
        CATEGORY_V.Columns.Add(category0)
        category0.Width = 170
        category0.ReadOnly = True
        category0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        category0.Name = "カテゴリ名称"

        Dim category1 As New DataGridViewTextBoxColumn
        category1.HeaderText = "売上数量ﾞ"
        CATEGORY_V.Columns.Add(category1)
        category1.Width = 120
        category1.ReadOnly = True
        category1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        category1.DefaultCellStyle.Format = "#,0"
        category1.Name = "売上数量"

        Dim category2 As New DataGridViewTextBoxColumn
        category2.HeaderText = "売上金額"
        CATEGORY_V.Columns.Add(category2)
        category2.Width = 120
        category2.ReadOnly = True
        category2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        category2.DefaultCellStyle.Format = "#,0"
        category2.Name = "売上金額"

        '背景色を白に設定
        CATEGORY_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        CATEGORY_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------------------------------------------------
        '-------------ランキング用グリッド----------------------
        '-------------------------------------------------------
        'レコードセレクタを非表示に設定
        RANK_V.RowHeadersVisible = False

        'グリッドのヘッダーを作成します。
        Dim rank0 As New DataGridViewTextBoxColumn
        rank0.HeaderText = "商品コード"
        RANK_V.Columns.Add(rank0)
        rank0.Width = 100
        rank0.ReadOnly = True
        rank0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        rank0.Name = "商品コード"

        Dim rank1 As New DataGridViewTextBoxColumn
        rank1.HeaderText = "商品名称"
        RANK_V.Columns.Add(rank1)
        rank1.Width = 300
        rank1.ReadOnly = True
        rank1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        rank1.Name = "商品名称"

        Dim rank2 As New DataGridViewTextBoxColumn
        rank2.HeaderText = "オプション"
        RANK_V.Columns.Add(rank2)
        rank2.Width = 370
        rank2.ReadOnly = True
        rank2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        rank2.Name = "オプション"

        Dim rank3 As New DataGridViewTextBoxColumn
        rank3.HeaderText = "売上金額"
        RANK_V.Columns.Add(rank3)
        rank3.Width = 120
        rank3.ReadOnly = True
        rank3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        rank3.DefaultCellStyle.Format = "#,0"
        rank3.Name = "売上金額"

        '背景色を白に設定
        RANK_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        RANK_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------------------------------------------------
        '-------------仕入情報用グリッド----------------------
        '-------------------------------------------------------
        'レコードセレクタを非表示に設定
        SUPPLIER_V.RowHeadersVisible = False
        SUPPLIER_V.AllowUserToResizeColumns = True

        'グリッドのヘッダーを作成します。
        Dim supplier0 As New DataGridViewTextBoxColumn
        supplier0.HeaderText = "入庫日"
        SUPPLIER_V.Columns.Add(supplier0)
        supplier0.Width = 70
        supplier0.ReadOnly = True
        supplier0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier0.Name = "入庫日"

        Dim supplier1 As New DataGridViewTextBoxColumn
        supplier1.HeaderText = "仕入先名称"
        SUPPLIER_V.Columns.Add(supplier1)
        supplier1.Width = 100
        supplier1.ReadOnly = True
        supplier1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier1.Name = "仕入先名称"

        Dim supplier2 As New DataGridViewTextBoxColumn
        supplier2.HeaderText = "JANコード"
        SUPPLIER_V.Columns.Add(supplier2)
        supplier2.Width = 100
        supplier2.ReadOnly = True
        supplier2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier2.Name = "JANコード"

        Dim supplier3 As New DataGridViewTextBoxColumn
        supplier3.HeaderText = "商品コード"
        SUPPLIER_V.Columns.Add(supplier3)
        supplier3.Width = 70
        supplier3.ReadOnly = True
        supplier3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier3.Name = "商品コード"

        Dim supplier4 As New DataGridViewTextBoxColumn
        supplier4.HeaderText = "商品名称"
        SUPPLIER_V.Columns.Add(supplier4)
        supplier4.Width = 200
        supplier4.ReadOnly = True
        supplier4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier4.Name = "商品名称"

        Dim supplier5 As New DataGridViewTextBoxColumn
        supplier5.HeaderText = "オプション"
        SUPPLIER_V.Columns.Add(supplier5)
        supplier5.Width = 150
        supplier5.ReadOnly = True
        supplier5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        supplier5.Name = "オプション"

        Dim supplier6 As New DataGridViewTextBoxColumn
        supplier6.HeaderText = "単価"
        SUPPLIER_V.Columns.Add(supplier6)
        supplier6.Width = 50
        supplier6.ReadOnly = True
        supplier6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        supplier6.DefaultCellStyle.Format = "#,0"
        supplier6.Name = "単価"

        Dim supplier7 As New DataGridViewTextBoxColumn
        supplier7.HeaderText = "数量"
        SUPPLIER_V.Columns.Add(supplier7)
        supplier7.Width = 50
        supplier7.ReadOnly = True
        supplier7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        supplier7.DefaultCellStyle.Format = "#,0"
        supplier7.Name = "数量"

        Dim supplier8 As New DataGridViewTextBoxColumn
        supplier8.HeaderText = "売上金額"
        SUPPLIER_V.Columns.Add(supplier8)
        supplier8.Width = 90
        supplier8.ReadOnly = True
        supplier8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        supplier8.DefaultCellStyle.Format = "#,0"
        supplier8.Name = "売上金額"

        '背景色を白に設定
        SUPPLIER_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        SUPPLIER_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '集計期間情報をを画面にセット
    '***********************************************
    Private Function DEFAULT_DATE_SET() As Long
        Dim dt As Date
        'Dim Message_form As cMessageLib.fMessage


        '2019.12.18 R.Takashima
        '日付処理部分を１つにまとめたためコメントアウト

        'If CInt(CLOSE_YEAR_T.Text) < 2013 Or CInt(CLOSE_YEAR_T.Text) > 2099 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "締め日の「年」指定が不正です。",
        '                                        "締め日「年」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        CLOSE_YEAR_T.Focus()
        '        Message_form = Nothing
        '        Exit Function
        '    Else
        '        If CLOSE_YEAR_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'If CInt(CLOSE_MONTH_T.Text) < 1 Or CInt(CLOSE_MONTH_T.Text) > 12 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "締め日の「月」指定が不正です。",
        '                                        "締め日「月」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        CLOSE_MONTH_T.Focus()
        '        Message_form = Nothing
        '        Exit Function
        '    Else
        '        If CLOSE_MONTH_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If
        '2019.12.18 R.Takashima TO

        dt = CDate(CLOSE_YEAR_T.Text & "/" & CLOSE_MONTH_T.Text & "/" & String.Format("{0:00}", oConf(0).sCloseDay))

        FROM_YEAR_T.Text = String.Format("{0:00}", dt.AddMonths(-1).Year)
        FROM_MONTH_T.Text = String.Format("{0:00}", dt.AddMonths(-1).Month)
        FROM_DAY_T.Text = String.Format("{0:00}", oConf(0).sCloseDay + 1)

        TO_YEAR_T.Text = CLOSE_YEAR_T.Text
        TO_MONTH_T.Text = CLOSE_MONTH_T.Text
        TO_DAY_T.Text = String.Format("{0:00}", oConf(0).sCloseDay)

    End Function


    '***********************************************
    '製品別情報をを画面にセット
    '***********************************************
    Private Function DATA_SET_CAHNNEL() As Long
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim oMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary
        Dim pPrice As Long

        For i = 0 To CHANNEL_V.Rows.Count - 1
            CHANNEL_V.Rows.Clear()
        Next

        ReDim oMonthTrnSummary(0)
        RecordCnt = oTrnSummaryDBIO.getChannelTrnSummary(
                            oMonthTrnSummary,
                            Nothing,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)
        pPrice = 0

        For i = 0 To oMonthTrnSummary.Length - 1

            If IN_R.Checked = True Then     '税込みモードの場合
                pPrice = oMonthTrnSummary(i).sPrice
            Else    '税抜きモードの場合
                '2019.12.19 R.Takashima FROM
                '軽減税率が含まれていると数値がずれるため修正
                'pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oConf(0).sTax, oConf(0).sFracProc)
                pPrice = oMonthTrnSummary(i).sPrice - (oMonthTrnSummary(i).sTaxPrice + oMonthTrnSummary(i).sReduceTaxPrice)
                '2019.12.19 R.Takashima TO
            End If

            CHANNEL_V.Rows.Add(
                                oMonthTrnSummary(i).sName,
                                oMonthTrnSummary(i).sCount,
                                pPrice
                    )
        Next i

        Me.ResumeLayout(False)

        DATA_SET_CAHNNEL = i
    End Function
    Private Sub INIT_PROC()
        IN_R.Checked = True
        CHANNEL_NAME_C.SelectedIndex = 0
        SUPPLIER_NAME_C.SelectedIndex = 0

        'TOTAL_NOTAX_PRICE_T.Text = 0
        'TOTAL_TAX_T.Text = 0
        'TOTAL_PRICE_T.Text = 0
    End Sub

    '***********************************************
    '部門別情報をを画面にセット
    '***********************************************
    Private Function DATA_SET_BUMON() As Long
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim oMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary
        Dim pPrice As Long

        For i = 0 To BUMON_V.Rows.Count - 1
            BUMON_V.Rows.Clear()
        Next

        ReDim oMonthTrnSummary(0)
        RecordCnt = oTrnSummaryDBIO.getBumonTrnSummary(
                            oMonthTrnSummary,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)

        pProductTotal = 0
        pServiceTotal = 0
        pPrice = 0

        For i = 0 To oMonthTrnSummary.Length - 1

            If IN_R.Checked = True Then     '税込みモードの場合
                pPrice = oMonthTrnSummary(i).sPrice
            Else    '税抜きモードの場合
                '2019.12.20 A.Komita From
                '軽減税率が含まれていると数値がずれるため修正
                'pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oConf(0).sTax, oConf(0).sFracProc)
                pPrice = oMonthTrnSummary(i).sPrice - (oMonthTrnSummary(i).sTaxPrice + oMonthTrnSummary(i).sReduceTaxPrice)
                '2019.12.20 A.Komita To
            End If

            BUMON_V.Rows.Add(
                            oMonthTrnSummary(i).sName,
                            oMonthTrnSummary(i).sCount,
                            pPrice
                )

            Select Case oMonthTrnSummary(i).sBumonClass
                Case 1
                    pProductTotal = pProductTotal + pPrice
                Case 2
                    pServiceTotal = pServiceTotal + pPrice
            End Select
        Next i

        Me.ResumeLayout(False)

        DATA_SET_BUMON = i
    End Function
    '***********************************************
    '支払い方法別情報をを画面にセット
    '***********************************************
    Private Function DATA_SET_PAYMENT() As Long
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim oMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary
        Dim pPrice As Long

        For i = 0 To PAYMENT_V.Rows.Count - 1
            PAYMENT_V.Rows.Clear()
        Next

        ReDim oMonthTrnSummary(0)
        RecordCnt = oTrnSummaryDBIO.getPaymentTrnSummary(
                            oMonthTrnSummary,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)

        pPrice = 0

        For i = 0 To oMonthTrnSummary.Length - 1

            If IN_R.Checked = True Then     '税込みモードの場合
                pPrice = oMonthTrnSummary(i).sPrice
            Else    '税抜きモードの場合
                '2019.12.20 A.Komita From
                '軽減税率が含まれていると数値がずれるため修正
                'pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oConf(0).sTax, oConf(0).sFracProc)
                pPrice = oMonthTrnSummary(i).sPrice - (oMonthTrnSummary(i).sTaxPrice + oMonthTrnSummary(i).sReduceTaxPrice)
                '2019.12.20 A.Komita To
            End If

            PAYMENT_V.Rows.Add(
                            oMonthTrnSummary(i).sName,
                            oMonthTrnSummary(i).sCount,
                            pPrice
                )
        Next i

        Me.ResumeLayout(False)

        DATA_SET_PAYMENT = i
    End Function
    '***********************************************
    'カテゴリ別情報をを画面にセット
    '***********************************************
    Private Function DATA_SET_CATEGORY() As Long
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim oMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary
        Dim pPrice As Long

        For i = 0 To CATEGORY_V.Rows.Count - 1
            CATEGORY_V.Rows.Clear()
        Next

        ReDim oMonthTrnSummary(0)
        RecordCnt = oTrnSummaryDBIO.getCategoryTrnSummary(
                            oMonthTrnSummary,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)

        pPrice = 0

        For i = 0 To oMonthTrnSummary.Length - 1

            If IN_R.Checked = True Then     '税込みモードの場合
                pPrice = oMonthTrnSummary(i).sPrice
            Else    '税抜きモードの場合
                '2019.12.20 A.Komita From
                '軽減税率が含まれていると数値がずれるため修正
                'pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oConf(0).sTax, oConf(0).sFracProc)
                pPrice = oMonthTrnSummary(i).sPrice - (oMonthTrnSummary(i).sTaxPrice + oMonthTrnSummary(i).sReduceTaxPrice)
                '2019.12.20 A.Komita To
            End If

            CATEGORY_V.Rows.Add(
                            oMonthTrnSummary(i).sName,
                            oMonthTrnSummary(i).sCount,
                            pPrice
                )
        Next i

        Me.ResumeLayout(False)

        DATA_SET_CATEGORY = i
    End Function
    '-------------------------- ジャーナル印刷 -------------------------------

    '******************************************
    '      日次ジャーナル印刷
    '******************************************
    Private Function JURNAL_PRINTING() As Boolean
        Dim ret As Integer
        Dim pData As String

        JURNAL_PRINTING = False

        oTool = New cTool

        'プリンターオープン
        OPOSPrinter1.Close()
        ret = OPOSPrinter1.Open("TRST56U")
        If ret Then
            Dim message_form As New cMessageLib.fMessage(1,
                                  "レシートプリンターの",
                                  "接続に失敗しました(ERRCODE:" & Trim(CStr(ret)),
                                  "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

        ret = OPOSPrinter1.ClaimDevice(1000)
        If ret Then
            Dim message_form As New cMessageLib.fMessage(1,
                                  "レシートプリンターの",
                                  "初期化に失敗しました(ERRCODE:" & Trim(CStr(ret)),
                                  "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If
        OPOSPrinter1.DeviceEnabled = True

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
        pData = Chr(27) & "|cA" & "<< 月次明細 >>" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)


        'ライン
        pData = "-----------------------------------" & Chr(10)
        ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)

        ''部門別集計結果印刷
        'For i = 0 To oBumon.Count - 1
        '    str = oBumon(i).sBumonShortName & "                          "
        '    pData = oTool.MidB(str, 1, 26) & " " & _
        '            String.Format("{0,9:C}", BUMON_PRICE(i)) & Chr(10)
        '    ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)
        '    pData = String.Format("                         {0,9:#,##0}点", BUMON_CNT(i)) & Chr(10)
        '    ret = OPOSPrinter1.PrintNormal(PTR_S_RECEIPT, pData)
        'Next i

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

        'Dim oReportPage = New rMonthCloseReport(oConn, oCommand, oDataReader, oCalc, oTrnSummary, STAFF_CODE, STAFF_NAME, CLOSE_YEAR_T.Text, oTran)

        'REPORT_PRINTING = False

        'oReportPage.Run()

        'REPORT_PRINTING = oReportPage.Document.Print(True, False)
        'Application.DoEvents()
    End Function


    Private Sub QUIT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles QUIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(2, Nothing,
                                        "今回の締め処理は無効となります。",
                                        "よろしいですか？", Nothing)
        Message_form.ShowDialog()
        '確認ダイアログでNOが選択された場合
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If
        Message_form = Nothing

        Me.Close()
    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(2,
                                        oConf(0).sDataPeriod & "ヶ月以前のデータは",
                                        "バックアップ後、削除されます。",
                                        "よろしいですか？", Nothing)
        Message_form.ShowDialog()
        '確認ダイアログでNOが選択された場合
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If
        Message_form = Nothing

        'データバックアップ処理
        BACKUP_PROC()
        CLOSE_PROC()

        Me.Close()
    End Sub
    Private Sub CLOSE_PROC()
        oConfMstDBIO = Nothing
        oTrnSummaryDBIO = Nothing
        oChannelDBIO = Nothing
        oSupplierDBIO = Nothing

        oTool = Nothing

    End Sub
    Private Sub CAL_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CAL_B.Click

        '2019.12.18 R.Takashima FROM
        '日付の範囲指定にて開始月が終了日以上にならないように変更
        Dim fromDate = New DateTime(CLng(FROM_YEAR_T.Text), CLng(FROM_MONTH_T.Text), CLng(FROM_DAY_T.Text))
        Dim toDate = New DateTime(CLng(TO_YEAR_T.Text), CLng(TO_MONTH_T.Text), CLng(TO_DAY_T.Text))
        If DateDiff("d", fromDate, toDate) >= 0 Then
            CAL_PROC()
        Else
            Dim mes = New cMessageLib.fMessage(1, "開始日が終了日より大きいです。",
                                    "修正をしてください。",
                                    Nothing, Nothing).ShowDialog
        End If
        '2019.12.18 R.Takashima TO
    End Sub
    Private Sub CAL_PROC()
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(1, "データ集計中・・・",
                                    "しばらくお待ち下さい。",
                                    Nothing, Nothing)

        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()


        '売上集計タブ
        DATA_SET_CAHNNEL()
        DATA_SET_BUMON()
        DATA_SET_PAYMENT()
        DATA_SET_CATEGORY()

        '売上ランキングおよびグラフ生成
        DATA_SET_RANK()

        '仕入状況
        DATA_SET_SUPPLIER()

        PRODUCT_TOTAL_L.Text = String.Format("{0:c}", pProductTotal)
        SERVICE_TOTAL_L.Text = String.Format("{0:c}", pServiceTotal)

        pSaleTotal = pProductTotal + pServiceTotal
        SALE_TOTAL_L.Text = String.Format("{0:c}", pSaleTotal)

        pProfit = pSaleTotal - pStockTotal
        PROFIT_L.Text = String.Format("{0:c}", pProfit)

        Message_form.Dispose()
        Message_form = Nothing

    End Sub
    Private Sub DATA_SET_RANK()
        Dim RecordCnt As Integer
        Dim oMonthTrnSummary() As cStructureLib.sGraphData
        'Dim ds() As cStructureLib.sGraphDataSet
        Dim ds() As Integer
        Dim dn() As String
        Dim cs() As Integer
        Dim cn() As String
        Dim i As Integer
        Dim ch As Integer
        Dim name As String
        Dim d_total As Long
        Dim d_subtotal As Long
        Dim c_total As Long
        Dim c_subtotal As Long

        If CHANNEL_CODE_T.Text = "-1" Then
            ch = Nothing
        Else
            ch = CInt(CHANNEL_CODE_T.Text)
        End If

        'グラフデータ集計
        ReDim oMonthTrnSummary(0)
        RecordCnt = oTrnSummaryDBIO.getGraphSummary(
                            oMonthTrnSummary,
                            ch,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)

        'ランキングデータセット
        RANK_GRID_CREATE(oMonthTrnSummary)

        ReDim ds(0)
        ReDim dn(0)
        ReDim cs(0)
        ReDim cn(0)

        If RecordCnt > 0 Then
            '----合計算出
            d_total = 0
            c_total = 0
            For i = 0 To oMonthTrnSummary.Length - 1
                d_total = d_total + oMonthTrnSummary(i).sPrice
                c_total = c_total + oMonthTrnSummary(i).sCount
            Next

            d_subtotal = 0
            c_subtotal = 0

            For i = 0 To oMonthTrnSummary.Length - 1
                If i >= 4 Then
                    ReDim Preserve ds(4)
                    ReDim Preserve dn(4)
                    dn(4) = "その他"
                    d_subtotal = d_subtotal + oMonthTrnSummary(i).sPrice
                    ds(4) = CInt((d_subtotal / d_total) * 100)
                Else
                    ReDim Preserve ds(i)
                    ReDim Preserve dn(i)
                    dn(i) = oMonthTrnSummary(i).sProductName & "(" & oMonthTrnSummary(i).sOption & ")"
                    ds(i) = CInt((oMonthTrnSummary(i).sPrice / d_total) * 100)
                End If
            Next

            '----グラフ生成
            If oMonthTrnSummary.Length > 0 Then
                name = ""
                With ALL_Chart
                    .Series.Clear()         '系列を初期化
                    .Legends.Clear()

                    .Legends.Add("Legend1")
                    .Legends("Legend1").Enabled = True
                    .Series.Add("ALL")
                    .Series("ALL").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                    For i = 0 To ds.Length - 1
                        .Series("ALL").Points.AddXY(0, ds(i))
                        If i >= 4 Then
                            .Series("ALL").Points(i).LegendText = "その他"
                        Else
                            .Series("ALL").Points(i).LegendText = oMonthTrnSummary(i).sProductName & "(" & oMonthTrnSummary(i).sOption & ")"
                        End If
                        .Series("ALL").Label = "#VALY" & "%"

                        '円グラフの分割
                        If i = 0 Then
                            .Series(0).Points(i)("Exploded") = True
                        End If

                        '円グラフのタイトルを引き出す
                        .Series(0).Points(i)("PieLabelStyle") = "Outside"

                        '引き出し線の奥行き
                        .Series(0).Points(i)("3DLabelLineSize") = "0"

                        'グラフの3D表示
                        .ChartAreas(0).Area3DStyle.Enable3D = True

                    Next

                End With
            End If
        End If
    End Sub
    Private Sub RANK_GRID_CREATE(ByRef oMonthTrnSummary() As cStructureLib.sGraphData)
        Dim i As Integer
        Dim pPrice As Long
        Dim pTotal As Long

        For i = 0 To RANK_V.Rows.Count - 1
            RANK_V.Rows.Clear()
        Next

        pProductSaleTotal = 0
        pPostageTotal = 0
        pFeeTotal = 0
        pDiscountTotal = 0
        pPrice = 0
        pTotal = 0


        For i = 0 To oMonthTrnSummary.Length - 1

            If IN_R.Checked = True Then     '税込みモードの場合
                pPrice = oMonthTrnSummary(i).sPrice
                pTotal = pTotal + oMonthTrnSummary(i).sPrice
                pPostageTotal = pPostageTotal + oTool.BeforeToAfterTax(oMonthTrnSummary(i).sPostage, oConf(0).sTax, oConf(0).sFracProc)
                pFeeTotal = pFeeTotal + oTool.BeforeToAfterTax(oMonthTrnSummary(i).sFee, oConf(0).sTax, oConf(0).sFracProc)
                pDiscountTotal = pDiscountTotal + oTool.BeforeToAfterTax(oMonthTrnSummary(i).sDisCount + oMonthTrnSummary(i).sPointDisCount + oMonthTrnSummary(i).sTicketDisCount, oConf(0).sTax, oConf(0).sFracProc)

                '2020,1,7 A.Komita 軽減税率計算の分岐を追加 From
            Else    '税抜きモードの場合              
                If oMonthTrnSummary(i).sReducedTaxRate = 0 Then
                    pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oConf(0).sTax, oConf(0).sFracProc)
                Else
                    pPrice = oTool.AfterToBeforeTax(oMonthTrnSummary(i).sPrice, oMonthTrnSummary(i).sReducedTaxRate, oConf(0).sFracProc)
                End If
                pTotal = pTotal + oMonthTrnSummary(i).sPrice
                pPostageTotal = pPostageTotal + oMonthTrnSummary(i).sPostage
                pFeeTotal = pFeeTotal + oMonthTrnSummary(i).sFee
                pDiscountTotal = pDiscountTotal + oMonthTrnSummary(i).sDisCount + oMonthTrnSummary(i).sPointDisCount + oMonthTrnSummary(i).sTicketDisCount
            End If
            '2020,1,7 A.Komita 追加 To

            If pPrice > 0 Then
                RANK_V.Rows.Add( _
                    oMonthTrnSummary(i).sProductCode, _
                    oMonthTrnSummary(i).sProductName, _
                    oMonthTrnSummary(i).sOption, _
                    pPrice _
                )
                pProductSaleTotal = pProductSaleTotal + pPrice
            Else
                pDiscountTotal = pDiscountTotal + pPrice
            End If
        Next

        RANK_SALE_L.Text = String.Format("{0:c}", oTool.BeforeToAfterTax(pProductSaleTotal, oConf(0).sTax, oConf(0).sFracProc))
        RANK_POSTAGE_L.Text = String.Format("{0:c}", oTool.BeforeToAfterTax(pPostageTotal, oConf(0).sTax, oConf(0).sFracProc))
        RANK_FEE_L.Text = String.Format("{0:c}", oTool.BeforeToAfterTax(pFeeTotal, oConf(0).sTax, oConf(0).sFracProc))
        RANK_DISCOUNT_L.Text = String.Format("{0:c}", oTool.BeforeToAfterTax(pDiscountTotal, oConf(0).sTax, oConf(0).sFracProc))
        RANK_TOTAL_L.Text = String.Format("{0:c}", pTotal)
        RANK_TAX_L.Text = String.Format("{0:c}", oTool.AfterToTax(pTotal, oConf(0).sTax, oConf(0).sFracProc))
        RANK_NOTAX_L.Text = String.Format("{0:c}", CLng(RANK_TOTAL_L.Text) - CLng(RANK_TAX_L.Text))

    End Sub

    Private Sub DATA_SET_SUPPLIER()
        Dim i As Integer
        Dim RecordCnt As Integer
        Dim oArrivalSummary() As cStructureLib.sViewArrivalSummary
        Dim supplierCode As Integer
        Dim pUnitPrice As Long
        Dim pPrice As Long
        Dim pTotal As Long

        '仕入額全合計算出
        pStockTotal = 0

        ReDim oArrivalSummary(0)
        RecordCnt = oTrnSummaryDBIO.getArrivalSummary( _
                            oArrivalSummary, _
                            supplierCode, _
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text, _
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text, _
                            oTran)

        pStockTotal = 0

        For i = 0 To oArrivalSummary.Length - 1
            '税込みモードの場合
            If IN_R.Checked = True Then
                pStockTotal = pStockTotal + oArrivalSummary(i).sPrice
            Else    '税抜きモードの場合
                pStockTotal = pStockTotal + oArrivalSummary(i).sNoTaxPrice
            End If
        Next
        STOCK_TOTAL_L.Text = String.Format("{0:c}", pStockTotal)

        '--------------------------------------
        '              仕入状況作成
        '--------------------------------------
        For i = 0 To SUPPLIER_V.Rows.Count - 1
            SUPPLIER_V.Rows.Clear()
        Next

        If SUPPLIER_CODE_T.Text = "-1" Then
            supplierCode = Nothing
        Else
            supplierCode = CInt(SUPPLIER_CODE_T.Text)
        End If

        ReDim oArrivalSummary(0)
        RecordCnt = oTrnSummaryDBIO.getArrivalSummary(
                            oArrivalSummary,
                            supplierCode,
                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                            oTran)

        pUnitPrice = 0
        pPrice = 0
        pTotal = 0

        For i = 0 To oArrivalSummary.Length - 1

            '税込みモードの場合
            If IN_R.Checked = True Then
                pUnitPrice = oTool.BeforeToAfterTax(oArrivalSummary(i).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc)
                pPrice = oArrivalSummary(i).sPrice
            Else    '税抜きモードの場合
                pUnitPrice = oArrivalSummary(i).sUnitPrice
                pPrice = oArrivalSummary(i).sNoTaxPrice
            End If

            SUPPLIER_V.Rows.Add( _
                    oArrivalSummary(i).sArrivalDate, _
                    oArrivalSummary(i).sSupplierName, _
                    oArrivalSummary(i).sJANCode, _
                    oArrivalSummary(i).sProductCode, _
                    oArrivalSummary(i).sProductName, _
                    oArrivalSummary(i).sOption, _
                    pUnitPrice, _
                    oArrivalSummary(i).sCount, _
                    pPrice _
                )

            pTotal = pTotal + pPrice
        Next

        If IN_R.Checked = True Then
            SUPPLIER_NOTAX_L.Text = String.Format("{0:c}", oTool.AfterToBeforeTax(pTotal, oConf(0).sTax, oConf(0).sFracProc))
            SUPPLIER_TOTAL_L.Text = String.Format("{0:c}", pTotal)
            SUPPLIER_TAX_L.Text = String.Format("{0:c}", CLng(SUPPLIER_TOTAL_L.Text) - CLng(SUPPLIER_NOTAX_L.Text))
        Else
            SUPPLIER_TOTAL_L.Text = String.Format("{0:c}", oTool.BeforeToAfterTax(pTotal, oConf(0).sTax, oConf(0).sFracProc))
            SUPPLIER_NOTAX_L.Text = String.Format("{0:c}", pTotal)
            SUPPLIER_TAX_L.Text = String.Format("{0:c}", CLng(SUPPLIER_TOTAL_L.Text) - CLng(SUPPLIER_NOTAX_L.Text))
        End If

    End Sub

    Private Sub CLOSE_YEAR_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLOSE_YEAR_T.GotFocus
        CLOSE_YEAR_T.SelectAll()
    End Sub
    Private Sub CLOSE_YEAR_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLOSE_YEAR_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理部分を呼出
        SetDate(sender, 0)

        DEFAULT_DATE_SET()
    End Sub

    Private Sub CLOSE_MONTH_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLOSE_MONTH_T.GotFocus
        CLOSE_MONTH_T.SelectAll()
    End Sub

    Private Sub CLOSE_MONTH_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLOSE_MONTH_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理部分を呼出
        SetDate(sender, 1)

        DEFAULT_DATE_SET()
    End Sub

    Private Function BACKUP_PROC() As Boolean
        Dim StrPath As String
        Dim DB_Path As String
        Dim pConn As OleDb.OleDbConnection
        Dim ret As Boolean

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB_BK.mdb;"
        pConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        pConn.Open()

        '-----------------------
        '   移行データのコピー
        '-----------------------
        '<日次取引データ + 日次取引明細データ>
        ret = TRN_BACKUP(pConn)

        '<発注データ + 発注明細データ>
        ret = ORDER_BACKUP(pConn)

        '<受注データ + 受注明細データ>
        ret = REQUEST_BACKUP(pConn)

        '<入庫データ + 入庫明細データ>
        ret = ARRIVAL_BACKUP(pConn)

        '<出庫データ + 出庫明細データ>
        '移行済みデータの削除
        'マスターDBの最適化

    End Function
    Private Function TRN_BACKUP(ByVal pConn As OleDb.OleDbConnection) As Boolean
        Dim pCommand As OleDb.OleDbCommand
        Dim pDataReader As OleDb.OleDbDataReader
        Dim pTrnDBIO As cDataTrnDBIO
        Dim pTrn() As cStructureLib.sTrn
        Dim pTrnSubDBIO As cDataTrnSubDBIO
        Dim pTrnSub() As cStructureLib.sSubTrn
        Dim pTran As OleDb.OleDbTransaction
        Dim RecordCnt As Long
        Dim i As Long
        Dim j As Long

        'バックアップ元テーブルの接続
        pTrnDBIO = New cDataTrnDBIO(oConn, oCommand, oDataReader)
        ReDim pTrn(0)
        pTrnSubDBIO = New cDataTrnSubDBIO(oConn, oCommand, oDataReader)

        '移行対象ヘッダーデータの取得
        RecordCnt = pTrnDBIO.getTrn(pTrn, _
                          Nothing, _
                          Nothing, _
                          Nothing, _
                          FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text, _
                          TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text, _
                          oTran)
        pTrnDBIO = Nothing

        'バックアップ先へのデータ書出し
        pCommand = Nothing
        pDataReader = Nothing
        pTrnDBIO = New cDataTrnDBIO(pConn, pCommand, pDataReader)
        pTran = pConn.BeginTransaction
        For i = 0 To pTrn.Length - 1
            '移行対象ヘッダーデータのバックアップ先書込み
            If pTrnDBIO.insertTrn(pTrn(i), pTran) = False Then
                pTran.Rollback()
                TRN_BACKUP = False
                Exit Function
            End If

            '移行対象明細データの取得
            ReDim pTrnSub(0)
            'RecordCnt = pTrnSubDBIO.getSubTrn(pTrnSub, _
            '               pTrn(i).sTrnCode, _
            '               Nothing, _
            '               oTran)
            RecordCnt = pTrnSubDBIO.getSubTrn(pTrnSub,
                       pTrn(i).sTrnCode,
                       Nothing,
                       Nothing,
                       Nothing,
                       Nothing,
                       Nothing,
                       Nothing,
                       oTran)

            '2020,1,9 A.Komita トランザクション完了済みの為削除 Start
            'For j = 0 To pTrnSub.Length - 1
            '    '    移行対象明細データのバックアップ先書込み 
            '    If pTrnSubDBIO.insertSubTrn(pTrnSub(j), pTran) = False Then
            '        pTran.Rollback()
            '        TRN_BACKUP = False
            '        Exit Function
            '    End If
            'Next
            '2020,1,9 A.Komita 削除 End

        Next
        '2020,1,9 A.Komita トランザクション終了のコードを追加 Start
        pTran.Commit()
        '2020,1,9 A.Komita 追加 End
        pTrnDBIO = Nothing
        pTrnSubDBIO = Nothing
        pCommand = Nothing
        pDataReader = Nothing
        TRN_BACKUP = True

    End Function

    Private Function ORDER_BACKUP(ByVal pConn As OleDb.OleDbConnection) As Boolean
        Dim pCommand As OleDb.OleDbCommand
        Dim pDataReader As OleDb.OleDbDataReader
        Dim pOrderDBIO As cDataOrderDBIO
        Dim pOrder() As cStructureLib.sOrderData
        Dim pOrderSubDBIO As cDataOrderSubDBIO
        Dim pOrderSub() As cStructureLib.sOrderSubData
        Dim pTran As System.Data.OleDb.OleDbTransaction
        Dim RecordCnt As Long
        Dim i As Long
        Dim j As Long

        'バックアップ元テーブルの接続
        pOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        ReDim pOrder(0)
        pOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)

        '移行対象ヘッダーデータの取得
        RecordCnt = pOrderDBIO.getOrderData(pOrder, _
                          Nothing, _
                          Nothing, _
                          FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text, _
                          TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text, _
                          oTran)
        pOrderDBIO = Nothing

        'バックアップ先へのデータ書出し
        pCommand = Nothing
        pDataReader = Nothing
        pOrderDBIO = New cDataOrderDBIO(pConn, pCommand, pDataReader)
        pTran = pConn.BeginTransaction
        For i = 0 To pOrder.Length - 1
            '移行対象ヘッダーデータのバックアップ先書込み
            If pOrderDBIO.insertOrderData(pOrder(i), pTran) = False Then
                oTran.Rollback()
                ORDER_BACKUP = False
                Exit Function
            End If

            '移行対象明細データの取得
            ReDim pOrderSub(0)
            RecordCnt = pOrderSubDBIO.getOrderSubData(pOrderSub,
                           pOrder(i).sOrderCode,
                           Nothing,
                           oTran)

            '2020,1,9 A.Komita トランザクション完了済みの為削除 Start
            'For j = 0 To pOrderSub.Length - 1
            '    '移行対象明細データのバックアップ先書込み
            '    If pOrderSubDBIO.insertOrderSubData(pOrderSub(j), pTran) = False Then
            '        oTran.Rollback()
            '        ORDER_BACKUP = False
            '        Exit Function
            '    End If
            'Next
            '2020,1,9 A.Komita 削除 End

        Next
        '2020,1,9 A.Komita トランザクション終了のコードを追加 Start
        pTran.Commit()
        '2020,1,9 A.Komita 追加 End
        pOrderDBIO = Nothing
        pOrderSubDBIO = Nothing
        pCommand = Nothing
        pDataReader = Nothing
        ORDER_BACKUP = True

    End Function
    Private Function REQUEST_BACKUP(ByVal pConn As OleDb.OleDbConnection) As Boolean
        Dim pCommand As OleDb.OleDbCommand
        Dim pDataReader As OleDb.OleDbDataReader
        Dim pRequestDBIO As cDataRequestDBIO
        Dim pRequest() As cStructureLib.sRequestData
        Dim pRequestSubDBIO As cDataRequestSubDBIO
        Dim pRequestSub() As cStructureLib.sRequestSubData
        Dim pTran As System.Data.OleDb.OleDbTransaction
        Dim RecordCnt As Long
        Dim i As Long

        'バックアップ元テーブルの接続
        pRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        ReDim pRequest(0)
        pRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        '移行対象ヘッダーデータの取得
        RecordCnt = pRequestDBIO.getRequest2(pRequest,
                          Nothing,
                          Nothing,
                          FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                          TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                          oTran)
        pRequestDBIO = Nothing

        'バックアップ先へのデータ書出し
        pCommand = Nothing
        pDataReader = Nothing
        pRequestDBIO = New cDataRequestDBIO(pConn, pCommand, pDataReader)
        pTran = pConn.BeginTransaction
        For i = 0 To pRequest.Length - 1
            '移行対象ヘッダーデータのバックアップ先書込み
            If pRequestDBIO.insertRequestData(pRequest(i), pTran) = False Then
                pTran.Rollback()
                REQUEST_BACKUP = False
                Exit Function
            End If

            '移行対象明細データの取得
            ReDim pRequestSub(0)
            RecordCnt = pRequestSubDBIO.getSubRequest(pRequestSub,
                           pRequest(i).sRequestCode,
                           Nothing,
                           oTran)

            '2020,1,9 A.Komita トランザクション完了済みの為削除 Start
            '移行対象明細データのバックアップ先書込み
            'If pRequestSubDBIO.insertSubRequestData(pRequestSub, pTran) = False Then
            '    pTran.Rollback()
            '    REQUEST_BACKUP = False
            '    Exit Function
            'End If
            '2020,1,9 A.Komita 削除 End

        Next
        '2020,1,9 A.Komita トランザクション終了のコードを追加 Start
        pTran.Commit()
        '2020,1,9 A.Komita 追加 End
        pRequestDBIO = Nothing
        pRequestSubDBIO = Nothing
        pCommand = Nothing
        pDataReader = Nothing
        REQUEST_BACKUP = True

    End Function
    Private Function ARRIVAL_BACKUP(ByVal pConn As OleDb.OleDbConnection) As Boolean
        Dim pCommand As OleDb.OleDbCommand
        Dim pDataReader As OleDb.OleDbDataReader
        Dim pArrivalDBIO As cDataArrivalDBIO
        Dim pArrival() As cStructureLib.sArrivalData
        Dim pArrivalSubDBIO As cDataArrivalSubDBIO
        Dim pArrivalSub() As cStructureLib.sArrivalSubData
        Dim pTran As OleDb.OleDbTransaction
        Dim RecordCnt As Long
        Dim i As Long
        Dim j As Long

        'バックアップ元テーブルの接続
        pArrivalDBIO = New cDataArrivalDBIO(oConn, oCommand, oDataReader)
        ReDim pArrival(0)
        pArrivalSubDBIO = New cDataArrivalSubDBIO(oConn, oCommand, oDataReader)

        '移行対象ヘッダーデータの取得
        RecordCnt = pArrivalDBIO.getArrivalData(pArrival, _
                          Nothing, _
                          FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text, _
                          TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text, _
                          oTran)
        pArrivalDBIO = Nothing

        'バックアップ先へのデータ書出し
        pCommand = Nothing
        pDataReader = Nothing
        pArrivalDBIO = New cDataArrivalDBIO(pConn, pCommand, pDataReader)
        pTran = pConn.BeginTransaction
        For i = 0 To pArrival.Length - 1
            '移行対象ヘッダーデータのバックアップ先書込み
            If pArrivalDBIO.insertArrivalData(pArrival(i), pTran) = False Then
                pTran.Rollback()
                ARRIVAL_BACKUP = False
                Exit Function
            End If

            '移行対象明細データの取得
            ReDim pArrivalSub(0)
            RecordCnt = pArrivalSubDBIO.getArrivalSubData(pArrivalSub,
                           pArrival(i).sOrderCode,
                           oTran)

            '2020,1,9 A.Komita トランザクション完了済みの為削除 Start
            'For j = 0 To pArrivalSub.Length - 1
            '    '移行対象明細データのバックアップ先書込み
            '    If pArrivalSubDBIO.insertArrivalSubData(pArrivalSub(j), oTran) = False Then
            '        pTran.Rollback()
            '        ARRIVAL_BACKUP = False
            '        Exit Function
            '    End If
            'Next
            '2020,1,9 A.Komita 削除 End

        Next
        '2020,1,9 A.Komita トランザクション終了のコードを追加 Start
        pTran.Commit()
        '2020,1,9 A.Komita 追加 End
        pArrivalDBIO = Nothing
        pArrivalSubDBIO = Nothing
        pCommand = Nothing
        pDataReader = Nothing
        ARRIVAL_BACKUP = True

    End Function
    Private Function SHIPMENT_BACKUP(ByVal pConn As OleDb.OleDbConnection) As Boolean
        Dim pCommand As OleDb.OleDbCommand
        Dim pDataReader As OleDb.OleDbDataReader
        Dim pShipmentDBIO As cDataShipmentDBIO
        Dim pShipment() As cStructureLib.sShipmentData
        Dim pShipmentSubDBIO As cDataShipmentSubDBIO
        Dim pShipmentSub() As cStructureLib.sShipmentSubData
        Dim pTran As System.Data.OleDb.OleDbTransaction
        Dim RecordCnt As Long
        Dim i As Long
        Dim j As Long

        'バックアップ元テーブルの接続
        pShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        ReDim pShipment(0)
        pShipmentSubDBIO = New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)

        '移行対象ヘッダーデータの取得
        RecordCnt = pShipmentDBIO.getShipment(pShipment, _
                          Nothing, _
                          Nothing, _
                          Nothing, _
                          Nothing, _
                          Nothing, _
                          FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text, _
                          TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text, _
                          oTran)
        pShipmentDBIO = Nothing

        'バックアップ先へのデータ書出し
        pCommand = Nothing
        pDataReader = Nothing
        pShipmentDBIO = New cDataShipmentDBIO(pConn, pCommand, pDataReader)
        pTran = pConn.BeginTransaction
        For i = 0 To pShipment.Length - 1
            '移行対象ヘッダーデータのバックアップ先書込み
            If pShipmentDBIO.insertShipment(pShipment(i), pTran) = False Then
                pTran.Rollback()
                SHIPMENT_BACKUP = False
                Exit Function
            End If

            '移行対象明細データの取得
            ReDim pShipmentSub(0)
            RecordCnt = pShipmentSubDBIO.getSubShipment(pShipmentSub,
                           Nothing,
                           pShipment(i).sShipCode,
                           Nothing,
                           oTran)

            '2020,1,9 A.Komita トランザクション完了済みの為削除 Start
            'For j = 0 To pShipmentSub.Length - 1
            '    '移行対象明細データのバックアップ先書込み
            '    If pShipmentSubDBIO.insertSubShipmentMst(pShipmentSub(j), oTran) = False Then
            '        pTran.Rollback()
            '        SHIPMENT_BACKUP = False
            '        Exit Function
            '    End If
            'Next
            '2020,1,9 A.Komita 削除 End

        Next
        '2020,1,9 A.Komita トランザクション終了のコードを追加 Start
        pTran.Commit()
        '2020,1,9 A.Komita 追加 End
        pShipmentDBIO = Nothing
        pShipmentSubDBIO = Nothing
        pCommand = Nothing
        pDataReader = Nothing
        SHIPMENT_BACKUP = True

        pTran.Commit()

    End Function

    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_C.SelectedIndexChanged
        If CHANNEL_NAME_C.SelectedIndex <> -1 Then
            ReDim oChannel(0)
            oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_C.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If
        DATA_SET_RANK()
    End Sub

    Private Sub SUPPLIER_NAME_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_NAME_C.SelectedIndexChanged
        If SUPPLIER_NAME_C.SelectedIndex <> -1 Then
            ReDim oSupplier(0)
            oSupplierDBIO.getSupplier(oSupplier, Nothing, SUPPLIER_NAME_C.Text, oTran)
            SUPPLIER_CODE_T.Text = oSupplier(0).sSupplierCode
        End If
        DATA_SET_SUPPLIER()
    End Sub

    Private Sub IN_R_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IN_R.CheckedChanged
        CAL_PROC()
    End Sub

    Private Sub PRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINT_B.Click
        Dim form_MonthCloseReport As fMonthCloseReport
        Dim cnCode As Integer
        Dim spCode As Integer
        'Dim ret As Integer
        'Dim ReportMode As String
        'Dim oReportPage As New cReportsLib.cReportsLib

        If CHANNEL_NAME_C.Text = "" Then
            cnCode = Nothing
        Else
            cnCode = CInt(CHANNEL_CODE_T.Text)
        End If

        If SUPPLIER_NAME_C.Text = "" Then
            spCode = Nothing
        Else
            spCode = CInt(SUPPLIER_CODE_T.Text)
        End If

        form_MonthCloseReport = New fMonthCloseReport(
                                            oConn,
                                            oCommand,
                                            oDataReader,
                                            FROM_YEAR_T.Text & "/" & FROM_MONTH_T.Text & "/" & FROM_DAY_T.Text,
                                            TO_YEAR_T.Text & "/" & TO_MONTH_T.Text & "/" & TO_DAY_T.Text,
                                            cnCode,
                                            spCode,
                                            oTran)

        ''印刷開始
        'If ORDER_MODE = 0 Then      '発注伝票印刷
        '    ret = oReportPage.OrderPrint(oConn, oCommand, oDataReader, CLOSE_YEAR_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)
        '    oReportPage = Nothing
        'Else                        '返品伝票印刷
        '    ret = oReportPage.ReturnOrderPrint(oConn, oCommand, oDataReader, CLOSE_YEAR_T.Text, STAFF_CODE, STAFF_NAME, ReportMode, oTran)

        '    oReportPage = Nothing
        'End If


    End Sub

    Private Sub FROM_YEAR_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles FROM_YEAR_T.GotFocus
        FROM_YEAR_T.SelectAll()
    End Sub

    Private Sub FROM_YEAR_T_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles FROM_YEAR_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 0)

        'Dim Message_form As cMessageLib.fMessage

        'If CInt(FROM_YEAR_T.Text) < 2013 Or CInt(FROM_YEAR_T.Text) > 2099 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「開始年」指定が不正です。",
        '                                        "集計期間「開始年」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        Message_form = Nothing
        '        FROM_YEAR_T.Focus()
        '        Exit Sub
        '    Else
        '        If FROM_YEAR_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'FROM_YEAR_T.Text = String.Format("{0:0000}", CInt(FROM_YEAR_T.Text))

    End Sub

    Private Sub TO_YEAR_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_YEAR_T.GotFocus
        TO_YEAR_T.SelectAll()
    End Sub

    Private Sub TO_YEAR_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_YEAR_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 0)

        'Dim Message_form As cMessageLib.fMessage

        'If CInt(TO_YEAR_T.Text) < 2013 Or CInt(TO_YEAR_T.Text) > 2099 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「終了年」指定が不正です。",
        '                                        "集計期間「終了年」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        TO_YEAR_T.Focus()
        '        Message_form = Nothing
        '        Exit Sub
        '    Else
        '        If TO_YEAR_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'TO_YEAR_T.Text = String.Format("{0:0000}", CInt(TO_YEAR_T.Text))

    End Sub

    Private Sub FROM_MONTH_T_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles FROM_MONTH_T.GotFocus
        FROM_MONTH_T.SelectAll()
    End Sub


    Private Sub FROM_MONTH_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FROM_MONTH_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 1)

        'Dim Message_form As cMessageLib.fMessage

        'If CInt(FROM_MONTH_T.Text) < 1 Or CInt(FROM_MONTH_T.Text) > 12 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「開始月」指定が不正です。",
        '                                        "集計期間「開始月」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        FROM_MONTH_T.Focus()
        '        Message_form = Nothing
        '        Exit Sub
        '    Else
        '        If FROM_MONTH_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'FROM_MONTH_T.Text = String.Format("{0:00}", CInt(FROM_MONTH_T.Text))

    End Sub

    Private Sub FROM_DAY_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FROM_DAY_T.GotFocus
        FROM_DAY_T.SelectAll()
    End Sub

    Private Sub FROM_DAY_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FROM_DAY_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 2)


        'Dim Message_form As cMessageLib.fMessage

        'If CInt(FROM_DAY_T.Text) < 1 Or CInt(FROM_DAY_T.Text) > 31 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「開始日」指定が不正です。",
        '                                        "集計期間「開始日」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        FROM_DAY_T.Focus()
        '        Message_form = Nothing
        '        Exit Sub
        '    Else
        '        If FROM_DAY_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'FROM_DAY_T.Text = String.Format("{0:00}", CInt(FROM_DAY_T.Text))

    End Sub
    Private Sub TO_MONTH_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_MONTH_T.GotFocus
        TO_MONTH_T.SelectAll()
    End Sub
    Private Sub TO_MONTH_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_MONTH_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 1)

        'Dim Message_form As cMessageLib.fMessage

        'If CInt(TO_MONTH_T.Text) < 1 Or CInt(TO_MONTH_T.Text) > 12 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「終了月」指定が不正です。",
        '                                        "集計期間「終了月」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        TO_MONTH_T.Focus()
        '        Exit Sub
        '    Else
        '        If TO_MONTH_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'TO_MONTH_T.Text = String.Format("{0:00}", CInt(TO_MONTH_T.Text))

    End Sub


    Private Sub TO_DAY_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_DAY_T.GotFocus
        TO_DAY_T.SelectAll()
    End Sub
    Private Sub TO_DAY_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_DAY_T.LostFocus
        '2019.12.18 R.Takashima 
        'LostFocusの処理を１つにまとめたためコメントアウトし、処理部分を呼出
        SetDate(sender, 2)

        'Dim Message_form As cMessageLib.fMessage

        'If CInt(TO_DAY_T.Text) < 1 Or CInt(TO_DAY_T.Text) > 31 Then
        '    '2019.12.14 R.Takashima
        '    'メッセージフォームにフォーカスが行くことで
        '    'テキストボックスのフォーカスが失いさらにメッセージフォームにフォーカスが行きテキストボックスのフォーカスが失い・・・
        '    'という無限ループになるためメッセージが１回表示されたらそれ以降ループが起きないように修正
        '    If messageFlag <> True Then
        '        messageFlag = True
        '        Message_form = New cMessageLib.fMessage(1, "集計期間の「終了日」指定が不正です。",
        '                                        "集計期間「終了日」を訂正して下さい。",
        '                                        Nothing, Nothing)

        '        Message_form.ShowDialog()
        '        System.Windows.Forms.Application.DoEvents()
        '        TO_DAY_T.Focus()
        '        Exit Sub
        '    Else
        '        If TO_DAY_T.Equals(ActiveControl) = False Then
        '            messageFlag = False
        '        End If
        '    End If
        'End If

        'TO_DAY_T.Text = String.Format("{0:00}", CInt(TO_DAY_T.Text))

    End Sub

    '2019.12.18 R.Takashima FROM
    'LostFocusの処理を全てまとめる
    '-----------------------------
    '引数：num　日付の種別 | 0 : 年 | 1：月 | 2：日
    '-----------------------------

    Private Sub SetDate(ByRef control As Control, ByVal num As Integer)

        'メッセージが表示されていたか
        Static Dim messageFlag As Boolean

        '現在入力途中のコントロール
        Static Dim CurrentControl As Control

        'コントロールが無ければ（初期状態）現在のコントロールを代入
        'コントロールの値が同じでない場合は処理を終了
        If IsNothing(CurrentControl) Then
            CurrentControl = control
        ElseIf CurrentControl.Equals(control) <> True Then
            Exit Sub
        End If

        Select Case num
            Case 0

                If CInt(control.Text) < 2013 Or CInt(control.Text) > 2099 Then
                    If messageFlag <> True Then
                        messageFlag = True
                        setYear(control)
                        messageFlag = False
                    End If
                Else
                    If CurrentControl.Equals(control) Then
                        messageFlag = False
                        control.Text = String.Format("{0:0000}", CInt(control.Text))
                        CurrentControl = Nothing
                    End If
                End If

            Case 1

                If CInt(control.Text) < 1 Or CInt(control.Text) > 12 Then
                    If messageFlag <> True Then
                        messageFlag = True
                        setMonth(control)
                        messageFlag = False
                    End If
                Else
                    If CurrentControl.Equals(control) Then
                        messageFlag = False
                        control.Text = String.Format("{0:00}", CInt(control.Text))
                        CurrentControl = Nothing
                    End If
                End If

            Case 2

                If CInt(control.Text) < 1 Or CInt(control.Text) > 31 Then
                    If messageFlag <> True Then
                        messageFlag = True
                        setDay(control)
                        messageFlag = False
                    End If
                Else
                    If CurrentControl.Equals(control) Then
                        messageFlag = False
                        control.Text = String.Format("{0:00}", CInt(control.Text))
                        CurrentControl = Nothing
                    End If
                End If
        End Select

    End Sub

    Private Sub setYear(ByRef control As Control)
        Dim message_form As cMessageLib.fMessage
        Dim message(2) As String

        If control.Name = "CLOSE_YEAR_T" Then
            message(0) = "締め日の「年」指定が不正です。"
            message(1) = "締め日「年」を訂正して下さい。"
        ElseIf control.Name = "FROM_YEAR_T" Then
            message(0) = "集計期間の「開始年」指定が不正です。"
            message(1) = "集計期間「開始年」を訂正して下さい。"
        Else
            message(0) = "集計期間の「終了年」指定が不正です。"
            message(1) = "集計期間「終了年」を訂正して下さい。"
        End If

        message_form = New cMessageLib.fMessage(1, message(0),
                                                message(1),
                                                Nothing, Nothing)
        message_form.ShowDialog()
        control.Focus()
        System.Windows.Forms.Application.DoEvents()
        message_form = Nothing

    End Sub

    Private Sub setMonth(ByRef control As Control)
        Dim message_form As cMessageLib.fMessage
        Dim message(2) As String

        If control.Name = "CLOSE_MONTH_T" Then
            message(0) = "締め日の「月」指定が不正です。"
            message(1) = "締め日「月」を訂正して下さい。"
        ElseIf control.Name = "FROM_MONTH_T" Then
            message(0) = "集計期間の「開始月」指定が不正です。"
            message(1) = "集計期間「開始月」を訂正して下さい。"
        Else
            message(0) = "集計期間の「終了月」指定が不正です。"
            message(1) = "集計期間「終了月」を訂正して下さい。"
        End If

        message_form = New cMessageLib.fMessage(1, message(0),
                                        message(1),
                                        Nothing, Nothing)
        message_form.ShowDialog()
        control.Focus()
        System.Windows.Forms.Application.DoEvents()
        message_form = Nothing

    End Sub

    Private Sub setDay(ByRef control As Control)
        Dim message_form As cMessageLib.fMessage
        Dim message(2) As String

        If control.Name = "FROM_DAY_T" Then
            message(0) = "集計期間の「開始日」指定が不正です。"
            message(1) = "集計期間「開始日」を訂正して下さい。"
        Else
            message(0) = "集計期間の「終了日」指定が不正です。"
            message(1) = "集計期間「終了日」を訂正して下さい。"
        End If

        message_form = New cMessageLib.fMessage(1, message(0),
                                        message(1),
                                        Nothing, Nothing)
        message_form.ShowDialog()
        control.Focus()
        System.Windows.Forms.Application.DoEvents()
        message_form = Nothing

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    '2019.12.18 R.Takashima TO

End Class
