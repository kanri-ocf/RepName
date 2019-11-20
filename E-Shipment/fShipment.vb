Imports System.ComponentModel

Public Class fShipment
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader
    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oRequest() As cStructureLib.sRequestData
    Private oDataRequestDBIO As cDataRequestDBIO

    Private oRequest1() As cStructureLib.sRequestData

    Private oRequestSubData() As cStructureLib.sRequestSubData
    Private oDataRequestSubDBIO As cDataRequestSubDBIO

    Private oShipment() As cStructureLib.sShipmentData
    Private oDataShipmentDBIO As cDataShipmentDBIO

    Private oShipmentSubData() As cStructureLib.sShipmentSubData
    Private oDataShipmentSubDBIO As cDataShipmentSubDBIO

    Private oViewBom() As cStructureLib.sViewBom
    Private oMstBomDBIO As cMstBomDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductPrice() As cStructureLib.sViewProductPrice
    Private oMstProductDBIO As cMstProductDBIO

    Private oChannelPaymentFull() As cStructureLib.sViewChannelPaymentFull
    Private oChannelPaymentDBIO As cMstChannelPaymentDBIO

    Private oMstPaymentDBIO As cMstPaymentDBIO

    Private oTrn() As cStructureLib.sTrn
    Private oDataTrnDBIO As cDataTrnDBIO

    Private oSubTrn() As cStructureLib.sSubTrn
    Private oDataSubTrnDBIO As cDataTrnSubDBIO

    Private oConf() As cStructureLib.sConfig

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oMstDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oTool As cTool

    Private REQUEST_CODE As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private SHIPMENT_NO As String

    Private RESHIP_FLG As Boolean '再出荷モード　あほみたいなグローバル汚染すんならその変数がどういうもので何のために使われているか明確に記述しろカス
    Private RESHIP_MSG As String

    Private IVENT_FLG As Boolean        'イベント２重発生予防フラグ
    Private START_FLG As Boolean        'フォームのイニシャライズ完了のフラグ

    Private WRITE_FLG As Boolean        'データの登録状態

    Private USUALLY_PRICE As Long　　　　　　'出荷する商品の金額合計を保持する値(通常商品)
    Private REDUCE_PRICE As Long             '出荷する商品の金額合計を保持する値(軽減税率)
    Private REDUCE_TAX_FLG As Long           '出荷する商品に軽減税率対象商品が含まれているかのフラグ


    '正の数値入力テキストボックスの配列作成
    Private Sub NumTextBoxHandler_Create()
        '正の数値入力のみを受け付けるテキストボックスの配列
        Dim NumTextArr = New TextBox() {BT_POSTAGE_P_T, BT_FEE_P_T, BT_DISCOUNT_P_T, BT_P_DISCOUNT_P_T}
        'ハンドラを追加
        For Each ctl As TextBox In NumTextArr
            AddHandler ctl.KeyPress, AddressOf NumOnly_KeyPress
            AddHandler ctl.Validated, AddressOf NumOnly_Validated
            ctl.MaxLength = 18 '最大桁の設定
        Next
    End Sub

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        START_FLG = False

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        oDataShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oDataShipmentSubDBIO = New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)

        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstBomDBIO = New cMstBomDBIO(oConn, oCommand, oDataReader)

        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)

        oDataTrnDBIO = New cDataTrnDBIO(oConn, oCommand, oDataReader)
        oDataSubTrnDBIO = New cDataTrnSubDBIO(oConn, oCommand, oDataReader)


        oTool = New cTool

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

    '******************************************************************
    'フォームロードイベント
    '******************************************************************
    Private Sub fShipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ハンドラのセット
        Dim RecordCnt As Integer
        Dim oMstConfigDBIO As New cMstConfigDBIO(oConn, oCommand, oDataReader)

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------


        '----------------------------- ハードウェア初期化終了 -----------------------------

        '---------------------------------------------------------------------------------------
        '2019/11/6 suzuki レジオープンの確認処理の追加
        '---------------------------------------------------------------------------------------
        Dim pInAdjustCode As Long
        Dim pCloseAdjustCode As Long


        Dim oDataAdjustDBIO As New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        pCloseAdjustCode = oDataAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
        pInAdjustCode = oDataAdjustDBIO.readMaxAdjustCode("レジ入金", Nothing, Nothing, oTran)
        If (pInAdjustCode = 0) Or (pInAdjustCode < pCloseAdjustCode) Then
            Dim message_form As New cMessageLib.fMessage(1,
                                     "入金処理が完了していません",
                                 "入金処理を行ってからレジ登録を実行して下さい",
                               Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Application.DoEvents()
            Environment.Exit(1)
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------
        '2019/11/6 suzuki レジオープンの確認処理の追加　END
        '---------------------------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing
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

        '注文情報データグリッド生成
        GRIDVIEW_CREATE()

        '配送業者コンボボックスセット
        DELIVERY_SET()

        '元着区分コンボボックスセット
        MOTOCYAKU_CLASS_SET()

        '便種（スピード）コンボボックスセット
        SPEED_CLASS_SET()

        '便種（商品）コンボボックスセット
        PRODUCT_CLASS_SET()

        '時間帯コンボボックスセット
        JIKANTAI_CLASS_SET()

        '画面初期化
        INIT_PROC(True)

        START_FLG = True
        IVENT_FLG = True

        REQ_CODE_T.Focus()

        'ハンドラの作成
        NumTextBoxHandler_Create()
    End Sub

    '******************************************************************
    '書き込み処理
    '******************************************************************
    Private Function WRITE_PROC(ByVal INIT_MODE As String) As Boolean
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim Mode As String
        Dim pTrnCode As Long
        Dim ret As Boolean

        '必須確認
        If CORP_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "配送業者を指定して下さい", Nothing, Nothing)
            Application.DoEvents()
            Message_form.ShowDialog()
            Message_form = Nothing
            CORP_NAME_C.Focus()
            WRITE_PROC = False
            Exit Function

        End If
        If MOTOCYAKU_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "元着区分を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            MOTOCYAKU_CLASS_C.Focus()
            WRITE_PROC = False
            Exit Function
        End If
        If TIME_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "時間帯を入力して下さい", Nothing, Nothing)
            Application.DoEvents()
            Message_form.ShowDialog()
            Message_form = Nothing
            TIME_NAME_C.Focus()
            WRITE_PROC = False
            Exit Function
        End If
        If SHIP_NAME1_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "氏名１を入力して下さい", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            SHIP_NAME1_T.Focus()
            WRITE_PROC = False
            Exit Function
        End If
        If SHIP_ADDR1_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "住所１を入力して下さい", Nothing, Nothing)
            Application.DoEvents()
            Message_form.ShowDialog()
            Message_form = Nothing
            SHIP_ADDR1_T.Focus()
            WRITE_PROC = False
            Exit Function
        End If
        If SHIP_ADDR2_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "住所２を入力して下さい", Nothing, Nothing)
            Application.DoEvents()
            Message_form.ShowDialog()
            Message_form = Nothing
            SHIP_ADDR2_T.Focus()
            WRITE_PROC = False
            Exit Function
        End If

        RecordCnt = oDataShipmentDBIO.getShipment(oShipment, Nothing, Nothing, SHIPMENT_NO, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCnt = 0 Then
            Mode = "INSERT"
        Else
            Mode = "UPDATE"
        End If

        '出荷処理トランザクション開始
        If IsNothing(oTran) = True Then
            oTran = oConn.BeginTransaction()
        End If

        '取引データ登録
        pTrnCode = DAY_TRN_INSERT(Mode)

        '日次取引明細データ登録
        pTrnCode = DAY_SUBTRN_INSERT(pTrnCode, Mode)

        '出庫情報データ登録
        ret = SHIPMENT_INSERT(Mode)

        If ret = True Then
            '在庫マスタ更新
            UPDATE_STOCK()
        End If

        If INIT_MODE = "INIT" Then

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, Nothing, "登録が完了しました", Nothing, Nothing)
            Message_form.Show()
            Message_form.Dispose()

            '画面初期化
            INIT_PROC(True)
        End If

        WRITE_PROC = True

    End Function

    Private Sub DELIVERY_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '配送業者コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "配送業者", Nothing, Nothing, oTran)

        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタが登録されていません",
                                                "配送種別マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CORP_NAME_C.Items.Add(oDeliveryClass(i).sClassName)
        Next
    End Sub

    Private Sub MOTOCYAKU_CLASS_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '元着コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "元着区分", Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタに元着区分がが登録されていません",
                                                "配送種別マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            MOTOCYAKU_CLASS_C.Items.Add(oDeliveryClass(i).sClassName)
        Next
    End Sub

    Private Sub SPEED_CLASS_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '便種（スピード）コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "便種(スピード)", Nothing, Nothing, oTran)

        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタが登録されていません",
                                                "配送種別マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            SPEED_NAME_C.Items.Add(oDeliveryClass(i).sClassName)
        Next
    End Sub

    Private Sub PRODUCT_CLASS_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '便種（スピード）コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "便種(商品)", Nothing, Nothing, oTran)

        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタが登録されていません",
                                                "配送種別マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            PRODUCT_NAME_C.Items.Add(oDeliveryClass(i).sClassName)
        Next
    End Sub

    Private Sub JIKANTAI_CLASS_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '時間帯コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "時間帯", Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタに時間帯が登録されていません",
                                                "配送種別マスタを登録してください",
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました",
                                                "開発元にお問い合わせ下さい",
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        TIME_NAME_C.Items.Add("")
        For i = 0 To RecordCnt - 1
            TIME_NAME_C.Items.Add(oDeliveryClass(i).sClassName)
        Next
    End Sub

    Private Sub SEARCH_PROC()
        Dim RecordCount As Long
        Dim MaxCd As Integer

        '受注番号コード未入力の場合は処理を抜ける
        If REQ_CODE_T.Text = "" Then Exit Sub


        REQUEST_CODE = REQ_CODE_T.Text

        'データクリア
        INIT_PROC(False)

        'データセット
        RecordCount = SHIPMENT_SET()
        RecordCount = SHIPMENT_V_SET()

        '計算開始
        CAL_PROC(True, True)

        '該当注文コードのデータカウントが0の場合
        If RecordCount = 0 Then
            REQ_CODE_T.Text = ""
            REQ_CODE_T.Focus()
        Else
            '出荷コード生成
            MaxCd = oDataShipmentDBIO.getMaxShipmentNo(oRequest1(0).sChannelCode, String.Format("{0:yyyy/MM/dd}", Now), oTran)
            SHIPMENT_NO = oTool.JANCD("995" & String.Format("{0:0}", oRequest1(0).sChannelCode) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:00}", MaxCd))
        End If

    End Sub

    '-----------------------------------------< 内部関数 >-------------------------------------------

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        SHIPMENT_V.RowHeadersVisible = False

        SHIPMENT_V.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        'JANコード
        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "JANコード"
        SHIPMENT_V.Columns.Add(column0)
        column0.Width = 85
        column0.ReadOnly = False
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column0.Name = "JANコード"

        '商品コード
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        SHIPMENT_V.Columns.Add(column1)
        column1.Width = 65
        column1.ReadOnly = True
        column1.Name = "商品コード"

        '商品名称
        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        SHIPMENT_V.Columns.Add(column2)
        column2.Width = 230
        column2.ReadOnly = True
        column2.Name = "商品名称"

        'オプション
        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        SHIPMENT_V.Columns.Add(column3)
        column3.Width = 190
        column3.ReadOnly = True
        column3.Name = "オプション"

        '注文単価
        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "注文単価"
        SHIPMENT_V.Columns.Add(column4)
        column4.Width = 70
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "注文単価"

        '注文数
        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "注文数"
        SHIPMENT_V.Columns.Add(column5)
        column5.Width = 50
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "注文数"

        '注文金額
        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "注文金額"
        SHIPMENT_V.Columns.Add(column6)
        column6.Width = 80
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.Name = "注文金額"

        '出荷数
        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "出荷数"
        SHIPMENT_V.Columns.Add(column7)
        column7.Width = 50
        column7.ReadOnly = False
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.DefaultCellStyle.BackColor = Color.Wheat
        column7.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        column7.Name = "出荷数"

        '出荷額
        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "出荷額"
        SHIPMENT_V.Columns.Add(column8)
        column8.Width = 80
        column8.DefaultCellStyle.Format = "c"
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.Name = "出荷額"

        '出荷残
        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "出荷残"
        SHIPMENT_V.Columns.Add(column9)
        column9.Width = 50
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.Name = "出荷残"

        '受注明細コード
        Dim column10 As New DataGridViewTextBoxColumn
        column10.HeaderText = "受注明細コード"
        SHIPMENT_V.Columns.Add(column10)
        column10.Visible = False
        column10.ReadOnly = True
        column10.Name = "受注明細コード"

        '税込単価
        Dim column11 As New DataGridViewTextBoxColumn
        column11.HeaderText = "税込単価"
        SHIPMENT_V.Columns.Add(column11)
        column11.Visible = False
        column11.ReadOnly = True
        column11.Name = "税込単価"

        'Default出荷残
        Dim column12 As New DataGridViewTextBoxColumn
        column12.HeaderText = "Default出荷残"
        SHIPMENT_V.Columns.Add(column12)
        column12.Width = 50
        column12.Visible = False
        column12.ReadOnly = True
        column12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column12.Name = "Default出荷残"

        '2019/10/3 shimizu add start
        '税率
        Dim column13 As New DataGridViewTextBoxColumn
        column13.HeaderText = "税率"
        SHIPMENT_V.Columns.Add(column13)
        column13.Width = 40
        column13.ReadOnly = True
        column13.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column13.Name = "税率"
        '2019/10/3 shimizu add end

        '背景色を白に設定
        SHIPMENT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        SHIPMENT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub
    '***********************************************
    '注文情報を画面にセット
    '***********************************************
    Private Function SHIPMENT_SET() As Long
        Dim RecordCnt As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As New cMstChannelDBIO(oConn, oCommand, oDataReader)

        '出荷回数の取得
        RecordCnt = oDataShipmentDBIO.getShipmentCount(REQ_CODE_T.Text, oTran)
        If RecordCnt = 0 Then
            SHIP_CNT_L.Text = "初回"

        Else

            '出荷状態の取得
            SHIP_FIX_C.Checked = oDataShipmentDBIO.getLastShipment(REQ_CODE_T.Text, oTran)
            If SHIP_FIX_C.Checked = True Then
                RESHIP_L.Visible = True
                RESHIP_FLG = True
                RESHIP_B.Enabled = True
            End If
            SHIP_CNT_L.Text = RecordCnt + 1

        End If


        '注文情報データの読み込み
        RecordCnt = oDataRequestDBIO.getRequest(oRequest,
                                                Nothing,
                                                REQUEST_CODE,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                oTran)

        '--------------------------------------------------

        '注文情報データの読み込み
        RecordCnt = oDataRequestDBIO.getRequest(oRequest1,
                                                Nothing,
                                                REQUEST_CODE,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                Nothing,
                                                oTran)


        '--------------------------------------------------


        '2019/10/3 shimizu upd start
        '--------------------------------------------------

        '注文情報明細データの読み込み
        oDataRequestSubDBIO.getSubRequest(oRequestSubData, REQUEST_CODE, Nothing, oTran)

        '--------------------------------------------------
        '2019/10/3 shimizu upd end



        If RecordCnt = 0 Then
            '注文コード該当なし→メッセージウィンドウ表示
            REQ_CODE_T.Text = "" 'テキストコードがメッセージフォーム出力の後だと無限ループ
            REQ_CODE_T.Focus()
            Message_form = New cMessageLib.fMessage(1, "未出荷の受注コードが",
                                            "注文データに存在しません",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Function
        End If


        '配送情報の画面セット

        '受注情報の画面セット
        RQ_NAME_T.Text = oRequest(0).sBill1stName & " " & oRequest(0).sBill2ndName
        ReDim oChannel(0)
        oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, oRequest(0).sChannelCode, 4, oTran)
        RQ_CHANNEL_T.Text = oChannel(0).sChannelName
        RQ_ADDR_T.Text = oRequest(0).sBillState & oRequest(0).sBillCity & oRequest(0).sBillAdder1 & " " & oRequest(0).sBillAdder2
        RQ_PONE_T.Text = oRequest(0).sBillTel
        RQ_MAIL_T.Text = oRequest(0).sMailAdderss
        RQ_DATE_T.Text = oRequest(0).sRequestDate
        RQ_TIME_T.Text = oRequest(0).sRequestTime
        SHIP_RQ_DATE_T.Text = oRequest(0).sShipRequestDate
        SHIP_RQ_TIME_T.Text = oRequest(0).sShipRequestTime
        oChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oChannelPaymentDBIO.getChannelPaymentFull(oChannelPaymentFull,
                                                              oRequest(0).sChannelPaymentCode,
                                                              Nothing,
                                                              Nothing,
                                                              Nothing,
                                                              Nothing,
                                                              oTran)
        oChannelPaymentDBIO = Nothing
        RQ_PAYMENT_CODE_T.Text = oChannelPaymentFull(0).sPaymentCode
        'TODO:配送時代引きフラグはない
        'RQ_DAIBIKI_C.Checked = oChannelPaymentFull(0).sDaibikiFlg
        If RQ_DAIBIKI_C.Checked = False Then
            SHIP_PAY_T.Enabled = False
        Else
            SHIP_PAY_T.Enabled = True
        End If
        RQ_CHANNEL_T.Text = oChannelPaymentFull(0).sChannelName
        RQ_PAYMENT_T.Text = oChannelPaymentFull(0).sPaymentName

        '2019/10/3 shimizu upd start
        'RQ_PRODUCT_P_T.Text = String.Format("{0:C}", oTool.BeforeToAfterTax(oRequest(0).sNoTaxTotalProductPrice, oConf(0).sTax, oConf(0).sFracProc))
        Dim PRODUCT_TOTAL As Long = 0 '商品受注代金合計
        For i = 0 To oRequestSubData.Length - 1
            If IN_TAX_R.Checked = True Then
                If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                    PRODUCT_TOTAL = String.Format("{0:C}", oTool.BeforeToAfterTax(oRequestSubData(i).sNoTaxPrice, oConf(0).sTax, oConf(0).sFracProc))
                Else
                    PRODUCT_TOTAL = String.Format("{0:C}", oTool.BeforeToAfterTax(oRequestSubData(i).sNoTaxPrice, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc))
                End If
            Else
                PRODUCT_TOTAL = String.Format("{0:C}", oRequestSubData(i).sNoTaxPrice)
            End If
            RQ_PRODUCT_P_T.Text = CLng(RQ_PRODUCT_P_T.Text) + PRODUCT_TOTAL
        Next
        '2019/10/3 shimizu upd end

        RQ_TAX_P_T.Text = oTool.BeforeToAfterTax(oRequest(0).sTaxTotal, oConf(0).sTax, oConf(0).sFracProc)
        RQ_POSTAGE_P_T.Text = oTool.BeforeToAfterTax(oRequest(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc)
        RQ_FEE_P_T.Text = oTool.BeforeToAfterTax(oRequest(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc)


        RQ_DISCOUNT_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sDiscount))
        RQ_P_DISCOUNT_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sPointDisCount))

        RQ_BILL_P_T.Text = String.Format("{0:C}", oTool.BeforeToAfterTax(oRequest(0).sTotalPrice, oConf(0).sTax, oConf(0).sFracProc))

        '出荷額情報の画面セット
        BT_PRODUCT_P_T.Text = 0
        BT_TAX_P_T.Text = 0
        BT_POSTAGE_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sShippingCharge))
        BT_FEE_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sPaymentCharge))
        BT_DISCOUNT_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sDiscount))
        BT_P_DISCOUNT_P_T.Text = String.Format("{0:C}", CLng(oRequest(0).sPointDisCount))
        BT_BILL_P_T.Text = 0

        '出荷情報の画面セット
        SHIP_NAME1_T.Text = oRequest(0).sShip1stName
        SHIP_NAME2_T.Text = oRequest(0).sShip2ndName
        SHIP_POSTCODE_T.Text = oRequest(0).sShipPostCode1 & "-" & oRequest(0).sShipPostCode2
        SHIP_ADDR1_T.Text = oRequest(0).sShipState
        SHIP_ADDR2_T.Text = oRequest(0).sShipCity
        SHIP_ADDR3_T.Text = oRequest(0).sShipAdder1 & " " & oRequest(0).sShipAdder2
        SHIP_PONE_T.Text = oRequest(0).sShipTel

        oChannelDBIO = Nothing
    End Function
    '***********************************************
    '注文情報明細を画面にセット
    '***********************************************
    Private Function SHIPMENT_V_SET() As Long
        Dim i As Integer
        Dim j As Integer
        Dim RecordCnt As Integer
        Dim oName() As String
        Dim oValue() As String
        Dim str As String
        Dim shipedCnt As Integer

        '2019/10/3 shimizu add start
        '軽減税率(受注情報詳細データ)
        Dim RTR As String
        '注文単
        Dim RSD As Long
        '2019/10/3 shimizu add start

        '注文明細データの読み込み
        ReDim oRequestSubData(0)
        RecordCnt = oDataRequestSubDBIO.getSubRequest(oRequestSubData, REQUEST_CODE, Nothing, oTran)
        'Me.SuspendLayout()

        '表示設定
        shipedCnt = 0
        For i = 0 To RecordCnt - 1
            If oRequestSubData(i).sProductName <> "送料" And
                oRequestSubData(i).sProductName <> "手数料" And
                oRequestSubData(i).sProductName <> "ポイント値引き" Then
                oName = oRequestSubData(i).sOptionName.Split(":")
                oValue = oRequestSubData(i).sOptionValue.Split(":")
                str = ""
                For j = 0 To oName.Length - 1
                    If str <> "" And oValue(j) <> "" Then
                        str = str & Chr(10)
                    End If
                    If oValue(j) <> "" Then
                        str = str & oName(j) & "=" & oValue(j)
                    End If
                Next

                '2019/10/3 shimizu add start
                If oRequestSubData(i).sReducedTaxRate = String.Empty Then

                    RTR = oConf(0).sTax.ToString & "%"
                    RSD = oTool.BeforeToAfterTax(oRequestSubData(i).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc)
                Else

                    RTR = oRequestSubData(i).sReducedTaxRate & "%"
                    RSD = oTool.BeforeToAfterTax(oRequestSubData(i).sUnitPrice, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)

                End If
                '2019/10/3 shimizu add end

                '2019/10/3 shimizu upd start
                'SHIPMENT_V.Rows.Add(
                '        oRequestSubData(i).sJANCode,
                '        oRequestSubData(i).sProductCode,
                '        oRequestSubData(i).sProductName,
                '        str,
                '        oTool.BeforeToAfterTax(oRequestSubData(i).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc),
                '        oRequestSubData(i).sCount,
                '        oRequestSubData(i).sPrice,
                '        0,
                '        0,
                '        oRequestSubData(i).sCount - oDataShipmentSubDBIO.getShipmentCount(oRequestSubData(i).sRequestCode, oRequestSubData(i).sRequestSubCode, oTran),
                '        oRequestSubData(i).sRequestSubCode,
                '        oRequestSubData(i).sUnitPrice,
                '        oRequestSubData(i).sCount - oDataShipmentSubDBIO.getShipmentCount(oRequestSubData(i).sRequestCode, oRequestSubData(i).sRequestSubCode, oTran)
                ')

                SHIPMENT_V.Rows.Add(
                      oRequestSubData(i).sJANCode,
                      oRequestSubData(i).sProductCode,
                      oRequestSubData(i).sProductName,
                      str,
                      RSD,
                      oRequestSubData(i).sCount,
                      oRequestSubData(i).sPrice,
                      0,
                      0,
                      oRequestSubData(i).sCount - oDataShipmentSubDBIO.getShipmentCount(oRequestSubData(i).sRequestCode, oRequestSubData(i).sRequestSubCode, oTran),
                      oRequestSubData(i).sRequestSubCode,
                      oRequestSubData(i).sUnitPrice,
                      oRequestSubData(i).sCount - oDataShipmentSubDBIO.getShipmentCount(oRequestSubData(i).sRequestCode, oRequestSubData(i).sRequestSubCode, oTran),
                      RTR
              )

                '2019/10/3 shimizu upd end

            End If
        Next i
        'Me.ResumeLayout(False)

        SHIPMENT_V_SET = i
    End Function

    '画面初期化処理
    Private Sub INIT_PROC(ByVal RQ_CODE_T_Clear As Boolean)
        Dim i As Integer

        JANCODE_T.Text = ""
        SHIP_CNT_L.Text = ""

        'データ登録フラグ初期化
        WRITE_FLG = False

        '配送伝票データ出力ボタン初期化
        DELIVERY_DATA_OUTPUT_B.Enabled = False

        '税モード初期化
        IN_TAX_R.Checked = True

        '出荷完了フラグ初期化
        SHIP_FIX_C.Checked = False

        '配送情報
        '配送業者
        '元着区分
        '出荷個数
        '代引金額
        '配達希望日
        '配達希望時間
        CORP_NAME_C.SelectedIndex = Nothing
        MOTOCYAKU_CLASS_C.SelectedIndex = Nothing
        SHIP_COUNT_T.Text = 1
        SHIP_PAY_T.Text = 0
        ARRIVE_DATE_T.Text = ""
        TIME_NAME_C.Text = ""

        '受注情報の画面セット
        RQ_NAME_T.Text = ""
        RQ_CHANNEL_T.Text = ""
        RQ_ADDR_T.Text = ""
        RQ_PONE_T.Text = ""
        RQ_MAIL_T.Text = ""
        RQ_DATE_T.Text = ""

        '2019/10/25 add shimizu start
        RQ_TIME_T.Text = ""
        SHIP_RQ_DATE_T.Text = ""
        '2019/10/25 add shimizu end

        SHIP_RQ_TIME_T.Text = ""
        RQ_PAYMENT_T.Text = ""
        RQ_PRODUCT_P_T.Text = 0
        RQ_TAX_P_T.Text = 0

        '2019/10/3 shimizu add start
        RQ_RTAX_RATE_P_T.Text = 0
        '2019/10/3 shimizu add start

        RQ_POSTAGE_P_T.Text = 0
        RQ_FEE_P_T.Text = 0
        RQ_P_DISCOUNT_P_T.Text = 0
        RQ_DISCOUNT_P_T.Text = 0
        RQ_BILL_P_T.Text = 0

        '出荷情報の画面セット
        SHIP_NAME1_T.Text = ""
        SHIP_NAME2_T.Text = ""
        SHIP_POSTCODE_T.Text = ""
        SHIP_ADDR1_T.Text = ""
        SHIP_ADDR2_T.Text = ""
        SHIP_ADDR3_T.Text = ""
        SHIP_ADDR4_T.Text = ""
        SHIP_PONE_T.Text = ""

        '出荷額情報の画面セット
        BT_PRODUCT_P_T.Text = 0
        BT_TAX_P_T.Text = 0

        '2019/10/3 shimizu add start
        BT_RTAX_RATE_P_T.Text = 0
        '2019/10/3 shimizu add start

        BT_POSTAGE_P_T.Text = 0
        BT_FEE_P_T.Text = 0
        BT_DISCOUNT_P_T.Text = 0
        BT_P_DISCOUNT_P_T.Text = 0
        BT_BILL_P_T.Text = 0

        '2019,11,7 A.Komita 追加 From
        USUALLY_PRICE = 0
        REDUCE_PRICE = 0
        '2019,11,7 A.Komita 追加 To

        RESHIP_B.Enabled = True

        COMMIT_B.Enabled = False
        DELIVERY_PRINT_B.Enabled = False

        For i = 0 To SHIPMENT_V.Rows.Count - 1
            SHIPMENT_V.Rows.Clear()
        Next

        If RQ_CODE_T_Clear = True Then
            REQ_CODE_T.Text = ""
            REQ_CODE_T.Focus()
        End If

        '再出荷モード解除
        RESHIP_L.Visible = False
        RESHIP_FLG = False

        '再出荷事由
        RESHIP_MSG = ""

    End Sub

    '*********************************************
    ' 集計
    '   <引数>
    '       CalMode True    :集計欄全体を再計算
    '               False   :再計算の範囲を限定
    '       InitFlg True    :初期化時の処理
    '               False   :初期化時でない処理
    '**********************************************

    Private Sub CAL_PROC(ByVal CalMode As Boolean, ByVal InitFlg As Boolean)
        '変数設定
        Dim pSALE As Long = 0
        Dim pRSALE As Long = 0
        Dim pRemnant As Integer = 0
        Dim RQ_TAX As Long = 0
        Dim RQ_RTAX_RATE As Long = 0 '【受注金額情報】軽減税
        Dim BT_TAX As Long = 0       　'【出荷金額情報】消費税
        Dim BT_RTAX_RATE As Long = 0  '【出荷金額情報】軽減税
        Dim RQ_POSTAGE_TAX As Long = 0 '【受注金額情報】送料の消費税
        Dim RQ_FEE_TAX As Long = 0     '【受注金額情報】手数料の消費税
        Dim BT_POSTAGE_TAX As Long = 0 '【出荷金額情報】送料の消費税
        Dim BT_FEE_TAX As Long = 0     '【出荷金額情報】手数料の消費税

        '明細画面更新および出荷情報の集計
        For i = 0 To SHIPMENT_V.RowCount - 1
            If IN_TAX_R.Checked = True Then  '税込みモードの場合

                '2019/10/3 shimizu upd start
                '単価
                If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                    SHIPMENT_V("注文単価", i).Value = oTool.BeforeToAfterTax(SHIPMENT_V("税込単価", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                Else
                    SHIPMENT_V("注文単価", i).Value = oTool.BeforeToAfterTax(SHIPMENT_V("税込単価", i).Value, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                End If
                '2019/10/3 shimizu add end

            Else        '税抜きモードの場合
                '単価
                SHIPMENT_V("注文単価", i).Value = SHIPMENT_V("税込単価", i).Value

                If CalMode = True Then
                    '消費税、軽減税率を入れる
                    If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                        RQ_TAX = oTool.BeforeToTax(SHIPMENT_V("注文単価", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                        RQ_TAX_P_T.Text = RQ_TAX_P_T.Text + RQ_TAX
                    Else
                        RQ_RTAX_RATE = oTool.BeforeToTax(SHIPMENT_V("注文単価", i).Value, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        RQ_RTAX_RATE_P_T.Text = RQ_RTAX_RATE_P_T.Text + RQ_RTAX_RATE
                    End If

                End If

            End If
            '注文金額
            SHIPMENT_V("注文金額", i).Value = CLng(SHIPMENT_V("注文単価", i).Value) * CLng(SHIPMENT_V("注文数", i).Value)
            '納入金額
            SHIPMENT_V("出荷額", i).Value = CLng(SHIPMENT_V("注文単価", i).Value) * CLng(SHIPMENT_V("出荷数", i).Value)

            If RESHIP_FLG = False Then
                SHIPMENT_V("出荷残", i).Value = CLng(SHIPMENT_V("Default出荷残", i).Value) - CLng(SHIPMENT_V("出荷数", i).Value)

                If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                    pSALE = pSALE + SHIPMENT_V("出荷額", i).Value
                    USUALLY_PRICE = pSALE
                Else
                    pRSALE = pRSALE + SHIPMENT_V("出荷額", i).Value
                    REDUCE_PRICE = pRSALE

                    If pRSALE <> 0 Then
                        REDUCE_TAX_FLG = oRequestSubData(i).sReducedTaxRate
                    End If
                End If
                pRemnant = pRemnant + SHIPMENT_V("出荷残", i).Value

                '消費税、軽減税率を入れる
                If IN_TAX_R.Checked = False Then '税抜きモードの場合
                    If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                        BT_TAX = oTool.BeforeToTax(pSALE, oConf(0).sTax, oConf(0).sFracProc)
                        BT_TAX_P_T.Text = BT_TAX
                    Else
                        BT_RTAX_RATE = oTool.BeforeToTax(pRSALE, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        BT_RTAX_RATE_P_T.Text = BT_RTAX_RATE
                    End If
                End If
            End If
        Next

        '出荷残量=0の場合
        If pRemnant = 0 Then
            '出荷完了フラグ=On
            SHIP_FIX_C.Checked = True
        Else
            SHIP_FIX_C.Checked = False
        End If

        '集計エリアの計算
        If IN_TAX_R.Checked = True Then  '税込みモードの場合
            If CalMode = True Then 'CalモードがTrueなら下記の処理を実行
                RQ_PRODUCT_P_T.Text = 0
                Dim PRODUCT3 As Long
                For i = 0 To SHIPMENT_V.RowCount - 1
                    If oRequestSubData(i).sReducedTaxRate = String.Empty Then
                        PRODUCT3 = oTool.BeforeToAfterTax(SHIPMENT_V("税込単価", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                    Else
                        PRODUCT3 = oTool.BeforeToAfterTax(SHIPMENT_V("税込単価", i).Value, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                    End If
                    RQ_PRODUCT_P_T.Text = RQ_PRODUCT_P_T.Text + PRODUCT3
                Next
                RQ_POSTAGE_P_T.Text = oTool.BeforeToAfterTax(CLng(RQ_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                RQ_FEE_P_T.Text = oTool.BeforeToAfterTax(CLng(RQ_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                RQ_DISCOUNT_P_T.Text = CLng(RQ_DISCOUNT_P_T.Text)
                RQ_P_DISCOUNT_P_T.Text = CLng(RQ_P_DISCOUNT_P_T.Text)

                RQ_TAX_P_T.Text = 0
                RQ_RTAX_RATE_P_T.Text = 0

                RQ_BILL_P_T.Text = CLng(RQ_PRODUCT_P_T.Text) +
                                        CLng(RQ_POSTAGE_P_T.Text) +
                                        CLng(RQ_FEE_P_T.Text) +
                                        CLng(RQ_DISCOUNT_P_T.Text) +
                                        CLng(RQ_P_DISCOUNT_P_T.Text)

                '再出荷モードフラグがTrueなら
                If RESHIP_FLG = True Then
                    BT_POSTAGE_P_T.Text = 0
                    BT_FEE_P_T.Text = 0
                    BT_DISCOUNT_P_T.Text = 0
                    BT_P_DISCOUNT_P_T.Text = 0
                Else
                    BT_POSTAGE_P_T.Text = oTool.BeforeToAfterTax(CLng(BT_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                    BT_FEE_P_T.Text = oTool.BeforeToAfterTax(CLng(BT_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                    BT_DISCOUNT_P_T.Text = CLng(BT_DISCOUNT_P_T.Text)
                    BT_P_DISCOUNT_P_T.Text = CLng(BT_P_DISCOUNT_P_T.Text)
                End If

            End If

            BT_PRODUCT_P_T.Text = pSALE + pRSALE
            BT_TAX_P_T.Text = 0
            BT_RTAX_RATE_P_T.Text = 0

            '再出荷モードフラグがTrueなら
            If RESHIP_FLG = True Then
                BT_BILL_P_T.Text = 0
            Else
                BT_BILL_P_T.Text = CLng(BT_PRODUCT_P_T.Text) +
                        CLng(BT_POSTAGE_P_T.Text) +
                        CLng(BT_FEE_P_T.Text) +
                        CLng(BT_DISCOUNT_P_T.Text) +
                        CLng(BT_P_DISCOUNT_P_T.Text)
                'BT_BILL_P_T.Textが0以下なら0に
                If BT_BILL_P_T.Text < 0 Then BT_BILL_P_T.Text = 0
            End If


        Else    '税抜きモードの場合

            If CalMode = True Then 'Calモード??????????????????????????????

                If oRequestSubData IsNot Nothing Then
                    RQ_PRODUCT_P_T.Text = oRequest(0).sNoTaxTotalProductPrice
                    RQ_POSTAGE_P_T.Text = oRequest(0).sShippingCharge
                    RQ_FEE_P_T.Text = oRequest(0).sPaymentCharge
                    RQ_DISCOUNT_P_T.Text = oRequest(0).sDiscount
                    RQ_P_DISCOUNT_P_T.Text = oRequest(0).sPointDisCount
                    RQ_POSTAGE_TAX = oTool.BeforeToTax(CLng(RQ_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                    RQ_FEE_TAX = oTool.BeforeToTax(CLng(RQ_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                    RQ_TAX_P_T.Text = CLng(RQ_TAX_P_T.Text) + RQ_POSTAGE_TAX + RQ_FEE_TAX

                    If RESHIP_FLG = True Then '再出荷モードがTrue?
                        BT_POSTAGE_P_T.Text = 0
                        BT_FEE_P_T.Text = 0
                        BT_DISCOUNT_P_T.Text = 0
                        BT_P_DISCOUNT_P_T.Text = 0
                    Else
                        BT_POSTAGE_P_T.Text = oTool.AfterToBeforeTax(CLng(BT_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        BT_FEE_P_T.Text = oTool.AfterToBeforeTax(CLng(BT_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                        BT_DISCOUNT_P_T.Text = CLng(BT_DISCOUNT_P_T.Text)
                        BT_P_DISCOUNT_P_T.Text = CLng(BT_P_DISCOUNT_P_T.Text)
                    End If

                End If
            End If

            BT_PRODUCT_P_T.Text = pSALE + pRSALE

            If RESHIP_FLG = False Then
                If RQ_POSTAGE_P_T.Text = BT_POSTAGE_P_T.Text And
                    RQ_FEE_P_T.Text = BT_FEE_P_T.Text And
                    RQ_DISCOUNT_P_T.Text = BT_DISCOUNT_P_T.Text And
                    RQ_P_DISCOUNT_P_T.Text = BT_P_DISCOUNT_P_T.Text Then

                    BT_POSTAGE_TAX = oTool.BeforeToTax(CLng(BT_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                    BT_FEE_TAX = oTool.BeforeToTax(CLng(BT_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)

                    BT_TAX_P_T.Text = CLng(BT_TAX_P_T.Text) + BT_POSTAGE_TAX + BT_FEE_TAX


                    BT_BILL_P_T.Text = (CLng(BT_PRODUCT_P_T.Text) +
                                             CLng(BT_POSTAGE_P_T.Text) +
                                             CLng(BT_FEE_P_T.Text) +
                                             CLng(BT_TAX_P_T.Text) +
                                             CLng(BT_RTAX_RATE_P_T.Text) +
                                             CLng(BT_DISCOUNT_P_T.Text) +
                                             CLng(BT_P_DISCOUNT_P_T.Text))

                    If BT_BILL_P_T.Text < 0 Then
                        BT_BILL_P_T.Text = 0
                    End If

                Else
                    BT_TAX_P_T.Text = CLng(BT_TAX_P_T.Text) + oTool.BeforeToTax(
                                             CLng(BT_POSTAGE_P_T.Text) +
                                             CLng(BT_FEE_P_T.Text),
                                            oConf(0).sTax, oConf(0).sFracProc)

                    BT_BILL_P_T.Text = CLng(BT_PRODUCT_P_T.Text) +
                                             CLng(BT_POSTAGE_P_T.Text) +
                                             CLng(BT_FEE_P_T.Text) +
                                             CLng(BT_TAX_P_T.Text) +
                                             CLng(BT_RTAX_RATE_P_T.Text) +
                                             CLng(BT_DISCOUNT_P_T.Text) +
                                             CLng(BT_P_DISCOUNT_P_T.Text)

                End If
            Else
                BT_BILL_P_T.Text = 0
                BT_TAX_P_T.Text = 0
            End If
        End If

    End Sub

    Private Sub UPDATE_SHIPMENT_V(ByVal JanCode As String, ByRef e As System.EventArgs)
        Dim i As Integer
        Dim cnt As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim SelectJAN_form As cSelectLib.fSelectJAN
        Dim PRODUCT_CODE As String


        'JANコード重複の確認
        cnt = 0
        PRODUCT_CODE = ""

        'データ登録フラグセット（データの変更あり）
        WRITE_FLG = True

        For i = 0 To SHIPMENT_V.Rows.Count - 1
            If SHIPMENT_V("JANコード", i).Value = JanCode Then
                cnt = cnt + 1
                PRODUCT_CODE = SHIPMENT_V("商品コード", i).Value
            End If
        Next
        Select Case cnt
            Case 0
                'JANコード該当なし→メッセージウィンドウ表示
                JANCODE_T.Text = ""
                COUNT_T.Text = 1
                JANCODE_T.Focus()
                Message_form = New cMessageLib.fMessage(1, "該当JANコードが",
                                                "発注データに存在しません",
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            Case 1

            Case Else
                'JANコード対象商品重複→メッセージウィンドウ表示
                SelectJAN_form = New cSelectLib.fSelectJAN(oConn, oCommand, oDataReader, Nothing, JanCode, oConf, oTran)
                SelectJAN_form.ShowDialog()
                PRODUCT_CODE = SelectJAN_form.PRODUCT_CODE_T.Text
        End Select

        For i = 0 To SHIPMENT_V.Rows.Count - 1
            If SHIPMENT_V("JANコード", i).Value = JanCode And SHIPMENT_V("商品コード", i).Value = PRODUCT_CODE Then
                'カレントセルの変更
                'SHIPMENT_V.CurrentCell = SHIPMENT_V("出荷額", i)
                Select Case RESHIP_FLG
                    Case False
                        If SHIPMENT_V("出荷残", i).Value = 0 Then
                            '納入残が０の場合→メッセージウィンドウ表示
                            Message_form = New cMessageLib.fMessage(1, "納入済みデータです",
                                                            "再度ご確認下さい",
                                                            Nothing, Nothing)
                            Message_form.ShowDialog()
                            Message_form = Nothing

                            JANCODE_T.Text = ""
                            COUNT_T.Text = 1
                            JANCODE_T.Focus()
                            Exit Sub
                        End If
                    Case True
                        SHIPMENT_V("出荷残", i).Value = 0
                End Select

                '出荷数算出
                SHIPMENT_V("出荷数", i).Value = CInt(SHIPMENT_V("出荷数", i).Value) + CInt(COUNT_T.Text)

                '合計納入金額算出
                CAL_PROC(False, False)
            End If
        Next
        JANCODE_T.Text = ""
        COUNT_T.Text = 1
        JANCODE_T.Focus()
    End Sub

    '****************
    '在庫マスタ更新
    '****************
    Private Function UPDATE_STOCK() As Long
        Dim i As Integer
        Dim j As Integer
        Dim ret As Boolean
        Dim sCount As Integer
        Dim RecordCount As Integer
        Dim oMstStockDBIO As New cMstStockDBIO(oConn, oCommand, oDataReader)
        Dim oStock() As cStructureLib.sStock      '登録用
        Dim pStock() As cStructureLib.sStock      '現行在庫数取得用
        'Dim oProduct() As cStructureLib.sProduct
        Dim pProductCode() As String
        Dim pBomCode As Integer

        '読込みバッファーのクリア
        ReDim oStock(0)
        ReDim pProductCode(0)
        ReDim oViewBom(0)

        '読込みバッファーのクリア
        ReDim oStock(0)

        For i = 0 To SHIPMENT_V.Rows.Count - 1
            If SHIPMENT_V("商品コード", i).Value.ToString.Length = 8 Then
                '商品種別の判定（構成品<疑似品目>の判定）
                RecordCount = oMstBomDBIO.getFullBom(oViewBom, Nothing, SHIPMENT_V("商品コード", i).Value, 1, Nothing, oTran)
                If RecordCount = 1 Then
                    pBomCode = oViewBom(0).sStructureCode
                    ReDim oViewBom(0)
                    RecordCount = oMstBomDBIO.getFullBom(oViewBom, pBomCode, Nothing, Nothing, 1, oTran)

                    pProductCode(0) = SHIPMENT_V("商品コード", i).Value

                    For j = 0 To RecordCount - 1
                        ReDim Preserve pProductCode(j)
                        pProductCode(j) = oViewBom(j).sProductCode
                    Next
                Else
                    pProductCode(0) = SHIPMENT_V("商品コード", i).Value
                End If

                If pProductCode(0) <> Nothing Then
                    For j = 0 To pProductCode.Length - 1
                        '現在の在庫マスタデータの読込み 
                        ReDim pStock(0)
                        RecordCount = oMstStockDBIO.getStock(pStock, pProductCode(j), oTran)
                        '現行在庫数の退避
                        sCount = pStock(0).sStockCount

                        '商品コード
                        oStock(0).sProductCode = pProductCode(j)

                        '現行在庫が０の場合（在庫管理異常の場合）
                        '現在のレジ作業を留めないため在庫数を０として処理は続行する
                        If sCount < CInt(SHIPMENT_V("出荷数", i).Value) Then
                            Dim message_form As New cMessageLib.fMessage(1,
                                                              pProductCode(j) & "の在庫数が０になっています",
                                                              "在庫情報を確認して下さい",
                                                              "今回は在庫数０で更新されます", Nothing)
                            message_form.ShowDialog()
                            message_form.Dispose()
                            message_form = Nothing
                            oStock(0).sStockCount = 0

                        Else    '現行在庫数が1以上の場合
                            oStock(0).sStockCount = sCount - CInt(SHIPMENT_V("出荷数", i).Value)
                        End If
                        ret = oMstStockDBIO.updateStock(oStock, oTran)
                    Next j
                End If
            End If
        Next i

        oMstStockDBIO = Nothing

        UPDATE_STOCK = sCount
    End Function

    Private Function SHIPMENT_INSERT(ByVal MODE As String) As Boolean
        Dim ret As Boolean
        Dim i As Integer
        Dim ShipCnt As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim RemCount As Integer

        SHIPMENT_INSERT = False

        '出荷数および納入残数サマリー計算
        ShipCnt = 0
        RemCount = 0
        For i = 0 To SHIPMENT_V.RowCount - 1
            '今回出荷合計数の算出
            ShipCnt = ShipCnt + CInt(SHIPMENT_V("出荷数", i).Value)
            '出荷残数の算出
            RemCount = RemCount + CInt(SHIPMENT_V("注文数", i).Value) -
                                CInt(SHIPMENT_V("出荷数", i).Value) +
                                (
                                    CInt(SHIPMENT_V("注文数", i).Value) -
                                    (
                                        CInt(SHIPMENT_V("出荷数", i).Value) +
                                        CInt(SHIPMENT_V("出荷残", i).Value)
                                    )
                                )

        Next

        If ShipCnt > 0 Then

            ReDim oShipment(0)

            'チャネルコード
            oShipment(0).sChannelCode = oRequest(0).sChannelCode
            '出荷コード
            oShipment(0).sShipCode = SHIPMENT_NO
            '受注コード
            oShipment(0).sRequestCode = REQ_CODE_T.Text
            '出荷日
            oShipment(0).sShipDate = String.Format("{0:yyyy/MM/dd}", Now)
            '荷物受渡番号
            oShipment(0).sDeliveryNumber = ""
            '出荷先電話番号
            oShipment(0).sTel = oRequest(0).sShipTel
            '出荷先郵便番号
            oShipment(0).sPostalCode = oRequest(0).sShipPostCode1 & "-" & oRequest(0).sShipPostCode2
            '出荷先住所1
            oShipment(0).sAddress1 = StrConv(oRequest(0).sShipState, VbStrConv.Wide)
            '出荷先住所2
            oShipment(0).sAddress2 = StrConv(oRequest(0).sShipCity, VbStrConv.Wide)
            '出荷先住所3
            oShipment(0).sAddress3 = StrConv(oRequest(0).sShipAdder1 & " " & oRequest(0).sShipAdder2, VbStrConv.Wide)
            '出荷先姓
            oShipment(0).sFirstName = StrConv(oRequest(0).sShip1stName, VbStrConv.Wide)
            '出荷先名
            oShipment(0).sLastName = StrConv(oRequest(0).sShip2ndName, VbStrConv.Wide)
            '配達日
            If oTool.MaskClear(ARRIVE_DATE_T.Text) = Nothing Then
                oShipment(0).sShipRequestDate = ""
            Else
                oShipment(0).sShipRequestDate = oTool.MaskClear(ARRIVE_DATE_T.Text)
            End If
            '配達指定時間帯
            oShipment(0).sShipRequestTimeClass = TIME_CODE_T.Text
            '配達指定時間
            oShipment(0).sShipRequestTime = ""
            '配送業者名称
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "配送業者", Nothing, CORP_NAME_C.Text, oTran)
            oShipment(0).sShipCorpCode = oDeliveryClass(0).sDeliveryClassCode
            '営業店コード
            oShipment(0).sShipOfficeCode = CORP_CODE_T.Text
            '代引金額
            If SHIP_PAY_T.Text <> "" Then
                oShipment(0).sDaibikiPrice = CLng(SHIP_PAY_T.Text)
            Else
                oShipment(0).sDaibikiPrice = 0
            End If

            If IN_TAX_R.Checked = True Then

                '出荷税抜商品金額
                oShipment(0).sNoTaxTotalProductPrice = oTool.AfterToBeforeTax(USUALLY_PRICE, oConf(0).sTax, oConf(0).sFracProc) + oTool.AfterToBeforeTax(REDUCE_PRICE, REDUCE_TAX_FLG, oConf(0).sFracProc)
                '送料
                oShipment(0).sShippingCharge = oTool.AfterToBeforeTax(CLng(BT_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
                '手数料
                oShipment(0).sPaymentCharge = oTool.AfterToBeforeTax(CLng(BT_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)

            Else
                '出荷税抜商品金額
                oShipment(0).sNoTaxTotalProductPrice = CLng(BT_PRODUCT_P_T.Text)
                '送料
                oShipment(0).sShippingCharge = CLng(BT_POSTAGE_P_T.Text)
                '手数料
                oShipment(0).sPaymentCharge = CLng(BT_FEE_P_T.Text)

            End If

            '値引き
            oShipment(0).sDiscount = CLng(BT_DISCOUNT_P_T.Text)
            'ポイント値引き
            oShipment(0).sPointDisCount = CLng(BT_P_DISCOUNT_P_T.Text)


            '出荷税抜金額
            oShipment(0).sNoTaxTotalPrice = oShipment(0).sNoTaxTotalProductPrice +
                                                oShipment(0).sShippingCharge +
                                                oShipment(0).sPaymentCharge +
                                                oShipment(0).sDiscount +
                                                oShipment(0).sPointDisCount
            '2019/10/5 shimizu upd start

            ''出荷消費税額
            'oShipment(0).sTaxTotal = oTool.BeforeToTax(oShipment(0).sNoTaxTotalPrice, oConf(0).sTax, oConf(0).sFracProc)
            ''出荷税込金額
            'oShipment(0).sTotalPrice = oShipment(0).sNoTaxTotalPrice + oShipment(0).sTaxTotal

            If IN_TAX_R.Checked = True Then

                '出荷消費税額
                oShipment(0).sTaxTotal = oTool.BeforeToTax(oTool.AfterToBeforeTax(USUALLY_PRICE, oConf(0).sTax, oConf(0).sFracProc), oConf(0).sTax, oConf(0).sFracProc) +
                    oTool.BeforeToTax(oShipment(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc) +
                    oTool.BeforeToTax(oShipment(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc)

                '出荷軽減消費税額
                oShipment(0).sReducedTaxRateTotal = oTool.BeforeToTax(oTool.AfterToBeforeTax(REDUCE_PRICE, REDUCE_TAX_FLG, oConf(0).sFracProc), REDUCE_TAX_FLG, oConf(0).sFracProc)

            Else

                '出荷消費税額
                oShipment(0).sTaxTotal = CLng(BT_TAX_P_T.Text)
                '出荷軽減消費税額
                oShipment(0).sReducedTaxRateTotal = CLng(BT_RTAX_RATE_P_T.Text)

            End If

            '出荷税込金額
            oShipment(0).sTotalPrice = oShipment(0).sNoTaxTotalPrice + oShipment(0).sTaxTotal + oShipment(0).sReducedTaxRateTotal
            '軽減税率
            If REDUCE_TAX_FLG <> 0 Then
                oShipment(0).sReducedTaxRate = REDUCE_TAX_FLG
            Else
                oShipment(0).sReducedTaxRate = String.Empty
            End If

            '2019/10/5 shimizu upd end

            '荷姿コード
            oShipment(0).sLookFeelCode = "001"
            '支払方法コード
            oShipment(0).sShipPaymentCode = 0
            '決済種別
            oShipment(0).sShipPaymentClass = 0
            '便種スピード
            oShipment(0).sDeliveryClassSpeed = SPEED_CODE_T.Text
            '便種商品
            oShipment(0).sDeliveryClassProduct = PRODUCT_CODE_T.Text
            'シール1
            oShipment(0).sSeal1 = ""
            'シール2
            oShipment(0).sSeal2 = ""
            'シール3
            oShipment(0).sSeal3 = ""
            '元着区分
            oShipment(0).sMotoCyakuClass = MOTOCYAKU_CODE_T.Text
            '出荷完了フラグ
            If SHIP_FIX_C.Checked = True Then
                If RESHIP_FLG = True Then
                    oShipment(0).sFinishFlg = 2
                Else
                    oShipment(0).sFinishFlg = 1
                End If
            Else
                oShipment(0).sFinishFlg = 0
            End If
            '再出荷事由
            oShipment(0).sReShopMemo = RESHIP_MSG
            '出荷メモ
            oShipment(0).sShipMemo = SHIP_MEMO.Text
            '配送伝票CSV出力フラグ
            oShipment(0).sDeleveryCSVOutoutFlg = False
            '出荷担当者コード
            oShipment(0).sShipStaffCode = STAFF_CODE_T.Text

            '出荷情報新規登録
            If MODE = "INSERT" Then
                ret = oDataShipmentDBIO.insertShipment(oShipment(0), oTran)
            Else
                ret = oDataShipmentDBIO.updateShipment(oShipment, oTran)
            End If
            If ret = False Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "出荷情報データの挿入に失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
                Message_form.Show()
                Application.DoEvents()
                Message_form.Dispose()
            End If

            '出庫情報明細データ登録
            SHIPMENT_SUB_INSERT(MODE)

            SHIPMENT_INSERT = True

        Else
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(2, "登録対象のデータが存在しません",
                                        "画面を初期化してよろしいですか？",
                                        Nothing, Nothing)
            Message_form.Show()
            If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                INIT_PROC(True)
            End If
            Message_form.Dispose()
        End If

    End Function

    Private Sub SHIPMENT_SUB_INSERT(ByVal MODE As String)
        Dim ret As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim str() As String
        Dim OptionName As String
        Dim OptionValue As String
        Dim pShipmentSubData() As cStructureLib.sShipmentSubData
        Dim RecCnt As Long

        ReDim oShipmentSubData(0)

        For i = 0 To SHIPMENT_V.Rows.Count - 1
            OptionName = ""
            OptionValue = ""

            If SHIPMENT_V("注文金額", i).Value > 0 Then
                '受注コード
                oShipmentSubData(0).sRequestCode = REQ_CODE_T.Text
                '出荷コード
                oShipmentSubData(0).sShipNumber = SHIPMENT_NO
                '受注明細コード
                oShipmentSubData(0).sRequestSubCode = i + 1
                '商品コード
                oShipmentSubData(0).sProductCode = SHIPMENT_V("商品コード", i).Value
                'JANコード
                oShipmentSubData(0).sJANCode = SHIPMENT_V("JANコード", i).Value
                '商品名称
                oShipmentSubData(0).sProductName = SHIPMENT_V("商品名称", i).Value
                'オプション名称
                str = SHIPMENT_V("オプション", i).Value.ToString.Split("=")
                For j = 0 To str.Length - 1
                    If j Mod 2 = 0 Then
                        If OptionName <> "" Then
                            OptionName = OptionName & "/"
                        End If
                        OptionName = OptionName & str(j)
                    Else
                        If OptionValue <> "" Then
                            OptionValue = OptionValue & "/"
                        End If
                        OptionValue = OptionValue & str(j)
                    End If
                Next
                oShipmentSubData(0).sOptionName = OptionName
                'オプション値
                oShipmentSubData(0).sOptionValue = OptionValue
                '定価********************
                If IN_TAX_R.Checked = True Then
                    oShipmentSubData(0).sListPrice = SHIPMENT_V("注文単価", i).Value
                    '出荷商品単価
                    oShipmentSubData(0).sUnitPrice = SHIPMENT_V("注文単価", i).Value
                    '出荷数量
                    oShipmentSubData(0).sCount = SHIPMENT_V("出荷数", i).Value

                    '2019/10/5 shimizu upd start
                    ''出荷消費税
                    'oShipmentSubData(0).sTaxPrice = oTool.AfterToTax(SHIPMENT_V("出荷額", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                    If SHIPMENT_V("税率", i).Value = oConf(0).sTax & "%" Then
                        oShipmentSubData(0).sTaxPrice = oTool.AfterToTax(SHIPMENT_V("出荷額", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                        oShipmentSubData(0).sReducedTaxRatePrice = 0
                    Else
                        oShipmentSubData(0).sReducedTaxRatePrice = oTool.AfterToTax(SHIPMENT_V("出荷額", i).Value, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oShipmentSubData(0).sTaxPrice = 0
                    End If
                    '2019/10/5 shimizu upd start


                    '出荷税込金額
                    oShipmentSubData(0).sPrice = SHIPMENT_V("出荷額", i).Value

                    '出荷税抜金額
                    oShipmentSubData(0).sNoTaxPrice = oShipmentSubData(0).sPrice - oShipmentSubData(0).sTaxPrice - oShipmentSubData(0).sReducedTaxRatePrice
                Else

                    '2019/10/5 shimizu upd start
                    'oShipmentSubData(0).sListPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    ''出荷商品単価
                    'oShipmentSubData(0).sUnitPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    ''出荷数量
                    'oShipmentSubData(0).sCount = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷数", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    ''出荷消費税
                    'oShipmentSubData(0).sTaxPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    ''出荷税込金額
                    'oShipmentSubData(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)

                    If SHIPMENT_V("税率", i).Value = oConf(0).sTax & "%" Then
                        oShipmentSubData(0).sListPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        '出荷商品単価
                        oShipmentSubData(0).sUnitPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        '出荷数量
                        oShipmentSubData(0).sCount = SHIPMENT_V("出荷数", i).Value
                        '出荷消費税
                        oShipmentSubData(0).sTaxPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        oShipmentSubData(0).sTaxPrice = oTool.AfterToTax(oShipmentSubData(0).sTaxPrice, oConf(0).sTax, oConf(0).sFracProc)
                        '出荷軽減消費税
                        oShipmentSubData(0).sReducedTaxRatePrice = 0
                        '出荷税込金額
                        oShipmentSubData(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Else
                        oShipmentSubData(0).sListPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        '出荷商品単価
                        oShipmentSubData(0).sUnitPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("注文単価", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        '出荷数量
                        oShipmentSubData(0).sCount = SHIPMENT_V("出荷数", i).Value
                        '出荷消費税
                        oShipmentSubData(0).sTaxPrice = 0
                        '出荷軽減消費税
                        oShipmentSubData(0).sReducedTaxRatePrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oShipmentSubData(0).sReducedTaxRatePrice = oTool.AfterToTax(oShipmentSubData(0).sReducedTaxRatePrice, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        '出荷税込金額
                        oShipmentSubData(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                    End If

                    '出荷税抜金額
                    oShipmentSubData(0).sNoTaxPrice = oShipmentSubData(0).sPrice - oShipmentSubData(0).sTaxPrice - oShipmentSubData(0).sReducedTaxRatePrice
                    '2019/10/5 shimizu upd end

                End If

                '2019/10/9 shimizu add start
                '軽減税率
                If SHIPMENT_V("税率", i).Value = oConf(0).sTax & "%" Then
                    oShipmentSubData(0).sReducedTaxRate = String.Empty
                Else
                    oShipmentSubData(0).sReducedTaxRate = oRequestSubData(i).sReducedTaxRate
                End If
                '2019/10/9 shimizu add end


                '更新データか否かの確認
                ReDim pShipmentSubData(0)
                RecCnt = oDataShipmentSubDBIO.getSubShipment(pShipmentSubData, REQ_CODE_T.Text, SHIPMENT_NO, i + 1, oTran)

                'データ書込み
                If MODE = "INSERT" Then
                    ret = oDataShipmentSubDBIO.insertSubShipmentMst(oShipmentSubData(0), oTran)
                Else
                    ret = oDataShipmentSubDBIO.updateSubShipmentMst(oShipmentSubData, oTran)
                End If
            End If
        Next i

    End Sub

    '**************************************************
    '日次取引データ挿入処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_TRN_INSERT(ByVal MODE As String) As Long

        Dim boolRet As Boolean
        Dim RecCount As Long

        oTrn = Nothing
        ReDim oTrn(0)

        If MODE = "UPDATE" Then
            oDataTrnDBIO.deleteTrn(Nothing, oShipment(0).sShipCode, oTran)
        End If

        oTrn(0).sTrnCode = TRNCODE_CREATE()

        oTrn(0).sTrnClass = "売上"
        RecCount = oDataRequestDBIO.getRequest(oRequest,
                                               Nothing,
                                               REQ_CODE_T.Text,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               oTran)
        oTrn(0).sChannel = oRequest(0).sChannelCode
        oTrn(0).sRequestDate = RQ_DATE_T.Text
        oTrn(0).sRequestTime = RQ_TIME_T.Text
        oTrn(0).sPaymentCode = CInt(RQ_PAYMENT_CODE_T.Text)
        If IN_TAX_R.Checked = True Then    '税込みモードの場合


            '2019/10/24 shimizu upd start
            'oTrn(0).sNoTaxTotalProductPrice = oTool.AfterToBeforeTax(CLng(BT_PRODUCT_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)

            oTrn(0).sNoTaxTotalProductPrice = oTool.AfterToBeforeTax(USUALLY_PRICE, oConf(0).sTax, oConf(0).sFracProc) + oTool.AfterToBeforeTax(REDUCE_PRICE, REDUCE_TAX_FLG, oConf(0).sFracProc)

            oTrn(0).sShippingCharge = oTool.AfterToBeforeTax(CLng(BT_POSTAGE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            oTrn(0).sPaymentCharge = oTool.AfterToBeforeTax(CLng(BT_FEE_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            'oTrn(0).sDiscount = oTool.AfterToBeforeTax(CLng(BT_DISCOUNT_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            'oTrn(0).sPointDiscount = oTool.AfterToBeforeTax(CLng(BT_P_DISCOUNT_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            oTrn(0).sDiscount = CLng(BT_DISCOUNT_P_T.Text)
            oTrn(0).sPointDiscount = CLng(BT_P_DISCOUNT_P_T.Text)
            'oTrn(0).sNoTaxTotalPrice = oTool.AfterToBeforeTax(CLng(BT_BILL_P_T.Text), oConf(0).sTax, oConf(0).sFracProc)
            oTrn(0).sTotalPrice = CLng(BT_BILL_P_T.Text)
            'oTrn(0).sTaxTotal = oTrn(0).sTotalPrice - oTrn(0).sNoTaxTotalPrice


            '出荷消費税額
            oTrn(0).sTaxTotal = oTool.BeforeToTax(oTool.AfterToBeforeTax(USUALLY_PRICE, oConf(0).sTax, oConf(0).sFracProc), oConf(0).sTax, oConf(0).sFracProc) +
                oTool.BeforeToTax(oTrn(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc) +
                oTool.BeforeToTax(oTrn(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc) +
                oTool.BeforeToTax(oTool.AfterToBeforeTax(REDUCE_PRICE, REDUCE_TAX_FLG, oConf(0).sFracProc), REDUCE_TAX_FLG, oConf(0).sFracProc)

        Else
            oTrn(0).sNoTaxTotalProductPrice = CLng(BT_PRODUCT_P_T.Text)
            oTrn(0).sShippingCharge = CLng(BT_POSTAGE_P_T.Text)
            oTrn(0).sPaymentCharge = CLng(BT_FEE_P_T.Text)
            oTrn(0).sDiscount = CLng(BT_DISCOUNT_P_T.Text)
            oTrn(0).sPointDiscount = CLng(BT_P_DISCOUNT_P_T.Text)
            'oTrn(0).sNoTaxTotalPrice = CLng(BT_BILL_P_T.Text)
            oTrn(0).sTotalPrice = CLng(BT_BILL_P_T.Text)
            oTrn(0).sTaxTotal = CLng(BT_TAX_P_T.Text) + CLng(BT_RTAX_RATE_P_T.Text)
        End If

        '取引税抜金額
        oTrn(0).sNoTaxTotalPrice = oTrn(0).sNoTaxTotalProductPrice +
                                                oTrn(0).sShippingCharge +
                                                oTrn(0).sPaymentCharge +
                                                oTrn(0).sDiscount +
                                                oTrn(0).sPointDiscount


        'oTrn(0).sTaxTotal = oTrn(0).sTotalPrice - oTrn(0).sNoTaxTotalPrice
        oTrn(0).sDifference = oTrn(0).sNoTaxTotalPrice - (oTrn(0).sTotalPrice - oTrn(0).sTaxTotal)
        oTrn(0).sShipCode = SHIPMENT_NO
        oTrn(0).sMemberCode = ""
        oTrn(0).sPointMemberCode = ""
        oTrn(0).sSex = ""
        oTrn(0).sGeneration = 8
        oTrn(0).sWeather = ""
        oTrn(0).sMemo = ""
        oTrn(0).sStaffCode = STAFF_CODE_T.Text.ToString
        oTrn(0).sDayCloseDate = ""
        oTrn(0).sMonthCloseDate = ""

        '日次取引データを更新
        boolRet = oDataTrnDBIO.insertTrn(oTrn(0), oTran)

        DAY_TRN_INSERT = oTrn(0).sTrnCode
    End Function
    '**************************************************
    '日次取引明細データ挿入処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_SUBTRN_INSERT(ByVal pTrnCode As Long, ByVal MODE As String) As Boolean

        Dim boolRet As Boolean
        Dim i As Integer
        Dim RecCount As Long
        Dim RowCount As Integer
        Dim oProduct() As cStructureLib.sProduct

        If MODE = "UPDATE" Then
            boolRet = oDataSubTrnDBIO.deleteSubTrn(Nothing, Nothing, oShipment(0).sShipCode, oTran)
        End If

        oSubTrn = Nothing

        ReDim oSubTrn(0)

        ReDim oProduct(0)
        RowCount = 1
        For i = 0 To SHIPMENT_V.Rows.Count - 1
            RecCount = oMstProductDBIO.getProduct(oProduct, Nothing, SHIPMENT_V("商品コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

            If SHIPMENT_V("注文金額", i).Value > 0 Then
                oSubTrn(0).sTrnCode = pTrnCode
                oSubTrn(0).sSubTrnCode = RowCount
                oSubTrn(0).sStatus = "登録"
                oSubTrn(0).sSubTrnClass = 1
                oSubTrn(0).sBumonCode = 1
                oSubTrn(0).sProductCode = oProduct(0).sProductCode
                oSubTrn(0).sProductName = oProduct(0).sProductName
                oSubTrn(0).sJANCode = oProduct(0).sJANCode
                oSubTrn(0).sOption1 = oProduct(0).sOption1
                oSubTrn(0).sOption2 = oProduct(0).sOption2
                oSubTrn(0).sOption3 = oProduct(0).sOption3
                oSubTrn(0).sOption4 = oProduct(0).sOption4
                oSubTrn(0).sOption5 = oProduct(0).sOption5
                ReDim oProductPrice(0)
                RecCount = oMstProductDBIO.getProductPrice(oProductPrice, Nothing, SHIPMENT_V("商品コード", i).Value, Nothing, Nothing, oTran)
                oSubTrn(0).sListPrice = oProductPrice(0).sPrice
                oSubTrn(0).sCostPrice = oProductPrice(0).sCostPrice


                '2019/10/24 shimizu upd start
                'If IN_TAX_R.Checked = True Then
                '    oSubTrn(0).sUnitPrice = oTool.AfterToBeforeTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                '    oSubTrn(0).sTaxPrice = oTool.AfterToTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                '    oSubTrn(0).sPrice = CLng(SHIPMENT_V("出荷額", i).Value)
                'Else
                '    oSubTrn(0).sUnitPrice = CLng(SHIPMENT_V("注文単価", i).Value)
                '    oSubTrn(0).sTaxPrice = CLng(SHIPMENT_V("出荷額", i).Value)
                '    oSubTrn(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                'End If
                If IN_TAX_R.Checked = True Then

                    If SHIPMENT_V("税率", i).Value = oConf(0).sTax & "%" Then
                        oSubTrn(0).sUnitPrice = oTool.AfterToBeforeTax(CLng(SHIPMENT_V("注文単価", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        oSubTrn(0).sTaxPrice = oTool.AfterToTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        oSubTrn(0).sReducedTaxRatePrice = 0
                        oSubTrn(0).sPrice = CLng(SHIPMENT_V("出荷額", i).Value)
                        oSubTrn(0).sCount = SHIPMENT_V("出荷数", i).Value
                        oSubTrn(0).sNoTaxProductPrice = oTool.AfterToBeforeTax(SHIPMENT_V("出荷額", i).Value, oConf(0).sTax, oConf(0).sFracProc)
                    Else
                        oSubTrn(0).sUnitPrice = oTool.AfterToBeforeTax(CLng(SHIPMENT_V("注文単価", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oSubTrn(0).sTaxPrice = 0
                        oSubTrn(0).sReducedTaxRatePrice = oTool.AfterToTax(CLng(SHIPMENT_V("出荷額", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oSubTrn(0).sPrice = CLng(SHIPMENT_V("出荷額", i).Value)
                        oSubTrn(0).sCount = SHIPMENT_V("出荷数", i).Value
                        oSubTrn(0).sNoTaxProductPrice = oTool.AfterToBeforeTax(SHIPMENT_V("出荷額", i).Value, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                    End If

                Else
                    oSubTrn(0).sUnitPrice = CLng(SHIPMENT_V("注文単価", i).Value)

                    If SHIPMENT_V("税率", i).Value = oConf(0).sTax & "%" Then

                        oSubTrn(0).sTaxPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                        oSubTrn(0).sTaxPrice = oTool.AfterToTax(oSubTrn(0).sTaxPrice, oConf(0).sTax, oConf(0).sFracProc)
                        oSubTrn(0).sReducedTaxRatePrice = 0
                        oSubTrn(0).sCount = SHIPMENT_V("出荷数", i).Value
                        oSubTrn(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oConf(0).sTax, oConf(0).sFracProc)

                    Else
                        oSubTrn(0).sTaxPrice = 0
                        oSubTrn(0).sReducedTaxRatePrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oSubTrn(0).sReducedTaxRatePrice = oTool.AfterToTax(oSubTrn(0).sReducedTaxRatePrice, oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)
                        oSubTrn(0).sCount = SHIPMENT_V("出荷数", i).Value
                        oSubTrn(0).sPrice = oTool.BeforeToAfterTax(CLng(SHIPMENT_V("出荷額", i).Value), oRequestSubData(i).sReducedTaxRate, oConf(0).sFracProc)

                    End If


                    oSubTrn(0).sNoTaxProductPrice = CLng(SHIPMENT_V("出荷額", i).Value)


                End If
                '2019/10/24 shimizu upd end


                '2019/10/24 shimizu upd start
                'oSubTrn(0).sCount = SHIPMENT_V("出荷数", i).Value
                'oSubTrn(0).sNoTaxProductPrice = oTool.AfterToBeforeTax(SHIPMENT_V("出荷額", i).Value, oConf(0).sTax, oConf(0).sFracProc)



                'oSubTrn(0).sShipCharge = 0
                'oSubTrn(0).sPayCharge = 0
                'oSubTrn(0).sDiscountPrice = 0
                'oSubTrn(0).sPointDiscountPrice = 0
                'oSubTrn(0).sTicketDiscountPrice = 0

                oSubTrn(0).sShipCharge = CLng(BT_POSTAGE_P_T.Text)
                oSubTrn(0).sPayCharge = CLng(BT_FEE_P_T.Text)
                oSubTrn(0).sDiscountPrice = CLng(BT_DISCOUNT_P_T.Text)
                oSubTrn(0).sPointDiscountPrice = CLng(BT_P_DISCOUNT_P_T.Text)
                oSubTrn(0).sTicketDiscountPrice = 0

                'oSubTrn(0).sNoTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sTaxPrice
                oSubTrn(0).sNoTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sTaxPrice - oSubTrn(0).sReducedTaxRatePrice
                '2019/10/24 shimizu upd end


                oSubTrn(0).sMemo = ""

                '日次取引明細データを更新
                boolRet = oDataSubTrnDBIO.insertSubTrn(oSubTrn(0), oTran)
                RowCount = RowCount + 1
            End If
        Next i
    End Function
    Function TRNCODE_CREATE() As Long
        Dim TrnCode As Long

        TrnCode = oDataTrnDBIO.readMaxTrnCode(oTran)

        TRNCODE_CREATE = TrnCode
    End Function

    Private Sub DELIVERY_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELIVERY_PRINT_B.Click
        Dim ret As Boolean
        Dim oReportPage As New cReportsLib.cReportsLib()
        Dim Message_form As cMessageLib.fMessage

        '2019,11,6 A.Komita 分納の場合に数値入力のミスを防ぐ為にメッセージを追加 From
        Dim messageResult = ShowMessageForm(2, "分納の場合,送料,手数料,値引き,ポイント値引きは", "手入力で修正する必要があります")

        If messageResult = DialogResult.No Then Exit Sub
        '2019,11,6 A.Komita To

        '印刷開始
        Message_form = New cMessageLib.fMessage(0, "納品伝票を印刷中です。", "しばらくお待ちください。", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()
        'ShowMessageForm(0, "納品伝票を印刷中です。", "しばらくお待ちください。")

        ret = WRITE_PROC("NONINIT")
        If ret = False Then
            oTran.Rollback()
            oTran = Nothing
            Exit Sub
        End If

        ret = oReportPage.ShipmentPrint(oConn, oCommand, oDataReader, SHIPMENT_NO, STAFF_CODE, STAFF_NAME, RESHIP_FLG, oTran)

        oReportPage = Nothing
        Message_form.Dispose()
        Message_form = Nothing

        If ret = False Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "納品伝票の印刷に失敗しました。",
                                            "システム管理者にお問い合わせ下さい。",
                                            Nothing, Nothing)
            Message_form.Show()
        End If
        COMMIT_B.Enabled = True
        DELIVERY_DATA_OUTPUT_B.Enabled = True

        Application.DoEvents()

    End Sub

    '税込み、税抜きの切り替え
    Private Sub AFTER_TAX_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IN_TAX_R.CheckedChanged
        If START_FLG = True Then
            CAL_PROC(True, False)
        End If
    End Sub

    '******************************************************************
    '注文検索ボタンのクリック
    '******************************************************************
    Private Sub REQUEST_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQUEST_SEARCH_B.Click
        Dim fRequest_Search As cSelectLib.fRequestSearch
        fRequest_Search = New cSelectLib.fRequestSearch(oConn, oCommand, oDataReader, Nothing, oTran)
        fRequest_Search.ShowDialog()
        REQUEST_CODE = fRequest_Search.S_REQUESTNUMBER
        REQ_CODE_T.Text = REQUEST_CODE
        fRequest_Search = Nothing
        SEARCH_PROC()
    End Sub

    Private Sub CORP_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CORP_NAME_C.SelectedIndexChanged
        If CORP_NAME_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, CORP_NAME_C.Text, oTran)
            CORP_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If

    End Sub

    Private Sub MOTOCYAKU_CLASS_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MOTOCYAKU_CLASS_C.SelectedIndexChanged
        If MOTOCYAKU_CLASS_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, MOTOCYAKU_CLASS_C.Text, oTran)
            MOTOCYAKU_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If

    End Sub

    Private Sub SPPED_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SPEED_NAME_C.SelectedIndexChanged
        If SPEED_NAME_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, SPEED_NAME_C.Text, oTran)
            SPEED_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If

    End Sub

    Private Sub PRODUCT_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRODUCT_NAME_C.SelectedIndexChanged
        If PRODUCT_NAME_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, PRODUCT_NAME_C.Text, oTran)
            PRODUCT_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If

    End Sub

    Private Sub TIME_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIME_NAME_C.SelectedIndexChanged
        If TIME_NAME_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, TIME_NAME_C.Text, oTran)
            TIME_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If


    End Sub

    '******************************************************************
    '再出荷ボタンのクリック
    '******************************************************************
    Private Sub RESHIP_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESHIP_B.Click

        '再出荷事由入力画面表示
        Dim ReShipMemo_form As fReShipMemo

        ReShipMemo_form = New fReShipMemo()
        ReShipMemo_form.ShowDialog()


        If ReShipMemo_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            RESHIP_MSG = ReShipMemo_form.RESHIP_MEMO_T.Text
            '---------------------------------------------------------------------------------------
            '2019/11/6 suzuki 再送時のDB登録処理の追加
            '---------------------------------------------------------------------------------------

            If IsNothing(oTran) = False Then
                oTran.Commit()
                oTran = Nothing
            End If
            INIT_PROC(True)
            '---------------------------------------------------------------------------------------
            '2019/11/6 suzuki 再送時のDB登録処理の追加　END
            '---------------------------------------------------------------------------------------

            ReShipMemo_form = Nothing
        Else
            ReShipMemo_form = Nothing
            Exit Sub
        End If


        RESHIP_L.Visible = True
        RESHIP_FLG = True
        RESHIP_B.Enabled = False

        DELIVERY_PRINT_B.Enabled = True
        DELIVERY_PRINT_B.Focus()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        If IsNothing(oTran) = False Then
            oTran.Commit()
            oTran = Nothing
        End If
        INIT_PROC(True)

    End Sub

    '******************************************************************
    '終了ボタンのクリック
    '******************************************************************
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click

        If WRITE_FLG = True Then
            Dim result = ShowMessageForm(2, "データが変更されています。", "登録せずに終了してよろしいですか？")
            If result = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If IsNothing(oTran) = False Then
            oTran.Rollback()
        End If
        oDataRequestDBIO = Nothing
        oDataRequestSubDBIO = Nothing
        oDataShipmentDBIO = Nothing
        oDataShipmentSubDBIO = Nothing
        oMstProductDBIO = Nothing
        oTool = New cTool

        Environment.Exit(1)

    End Sub

    Private Sub DELIVERY_DATA_OUTPUT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELIVERY_DATA_OUTPUT_B.Click
        Dim oDataShipmentStatusDBIO As cDataShipmentStatusDBIO
        Dim oShipmentStatus() As cStructureLib.sShipStatus
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCount As Integer

        oDataShipmentStatusDBIO = New cDataShipmentStatusDBIO(oConn, oCommand, oDataReader)

        ReDim oShipmentStatus(0)
        oShipmentStatus(0).sShipCode = SHIPMENT_NO
        oShipmentStatus(0).sShipCheck = True

        RecordCount = oDataShipmentStatusDBIO.getShipStatus(oShipmentStatus, SHIPMENT_NO, oTran)
        If RecordCount < 1 Then
            oDataShipmentStatusDBIO.insertShipStatus(oShipmentStatus(0), oTran)
        End If

        Message_form = New cMessageLib.fMessage(1, "配送伝票出力予約に登録しました。",
                                                  "実際のデータ出力は、メインメニューの",
                                                  "配送伝票データ出力から行って下さい。", Nothing)
        Message_form.ShowDialog()

        oShipmentStatus = Nothing
        oDataShipmentStatusDBIO = Nothing
    End Sub



    Private Sub BT_BILL_P_T_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_BILL_P_T.TextChanged
        If RQ_DAIBIKI_C.Checked = True Then
            SHIP_PAY_T.Text = BT_BILL_P_T.Text
        End If
    End Sub


    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★
    '//
    '//コントロールイベント
    '//
    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★

    '****受注番号のフォーカスが外れた場合の処理
    Private Sub REQ_CODE_T_Leave(sender As Object, e As EventArgs) Handles REQ_CODE_T.Leave
        SEARCH_PROC()
    End Sub

    '****JANコードのフォーカスが外れた場合の処理
    Private Sub JANCODE_T_Leave(sender As Object, e As EventArgs) Handles JANCODE_T.Leave
        If JANCODE_T.Text = "" Then Exit Sub '空白なら処理を抜ける
        UPDATE_SHIPMENT_V(JANCODE_T.Text, e)
        DELIVERY_PRINT_B.Enabled = True
    End Sub

    '****数値のみの入力テキストボックスのコントロール関数****

    '//**************************************************
    '//KeyPress
    '//**************************************************
    '//ハンドラ
    Private Sub NumOnly_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        KeyNumOnly(e)
    End Sub

    '//キーの文字列入力の無効化
    Private Sub KeyNumOnly(e As System.Windows.Forms.KeyPressEventArgs)
        '0～9と、バックスペース以外の時は、イベントをキャンセルする
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back AndAlso
            e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    '//**************************************************
    '//Validated
    '//**************************************************

    'ハンドラ関数
    Private Sub NumOnly_Validated(sender As Object, e As EventArgs)
        senderValidatedNum(sender)
    End Sub

    '数値入力後の処理
    Private Sub senderValidatedNum(sender As Object)
        sender.Text = NumShaping(sender.Text)
        CAL_PROC(False, False)
    End Sub

    '渡された文字列から先頭の0を消去,数値に変換できない値なら0にする関数
    Private Function NumShaping(str As String)
        str = str.TrimStart(“0”)
        If (str = "" Or Not IsNumeric(str)) Then
            str = "0"
        End If
        Return str
    End Function




    '****数値と文字列入力のテキストボックスのコントロール関数****

    '****データテーブルのコントロール関数****
    '******************************************************************
    'CellValidating
    '******************************************************************
    Private Sub SHIPMENT_V_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles SHIPMENT_V.CellValidating
        WRITE_FLG = True
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        '新しい行のセルでなく、セルの内容が変更されている時だけ検証する 
        If e.RowIndex = dgv.NewRowIndex OrElse Not dgv.IsCurrentCellDirty Then Exit Sub

        Me.SuspendLayout()
        '入力した値を変数に格納
        Dim inputValue = e.FormattedValue
        'e.ColumnIndexのケースによる処理分け
        Select Case e.ColumnIndex
            Case 0, 4, 6, 8
                If (IsNumeric(inputValue) = False) Then
                    '入力チェック
                    ShowMessageForm(1, "数値に文字列が含まれています", "再度ご確認ください")
                    e.Cancel = True
                    dgv.CancelEdit()
                End If
            Case 7  '出荷数
                Dim errText As String = ""
                '入力チェック
                If (IsNumeric(inputValue) = False) Then
                    errText = "数値に文字列が含まれています"
                    '出荷数チェック
                ElseIf RESHIP_FLG = False And SHIPMENT_V("Default出荷残", e.RowIndex).Value < inputValue Then  'デフォルト出荷残とeに入力された値を比較する
                    errText = "出荷モード::出荷数が出荷残数を超えています"
                ElseIf RESHIP_FLG = True And SHIPMENT_V("注文数", e.RowIndex).Value < inputValue Then
                    errText = "再出荷モード::出荷数が注文数を超えています"
                End If

                'errTextが空白でない場合エラーとして処理
                If errText <> "" Then
                    '出荷数が異常値の場合→メッセージウィンドウ表示
                    ShowMessageForm(1, errText, "再度ご確認ください")
                    COUNT_T.Text = 1
                    e.Cancel = True
                    dgv.CancelEdit()
                Else
                    SHIPMENT_V("出荷数", e.RowIndex).Value = inputValue
                    '集計処理
                    CAL_PROC(False, False)
                    If CLng(BT_PRODUCT_P_T.Text) > 0 Then
                        DELIVERY_PRINT_B.Enabled = True
                    End If
                End If
        End Select
        Me.ResumeLayout(False)
        Application.DoEvents()
    End Sub
    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★
    '//
    '//その他
    '//
    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★

    'メッセージダイアログを出力する関数
    Private Function ShowMessageForm(formType As Integer, errtext1 As String, errtext2 As String)
        Dim Message_form As cMessageLib.fMessage
        Message_form = New cMessageLib.fMessage(formType, errtext1,
                                                            errtext2,
                                                            Nothing, Nothing)
        Message_form.ShowDialog()
        Application.DoEvents()
        Return Message_form.DialogResult 'typeが0なら別のものを返し、プロックを実行させる
    End Function

End Class
