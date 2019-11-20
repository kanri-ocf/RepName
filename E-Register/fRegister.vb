'#Const HARDWARE = CONNECT     '周辺機器の接続状態(開発用) NONE:未接続　CONNECT:接続


Public Class fRegister

    '2019.10.6 R.Takashima
    '数が多く見づらいのでアウトラインでまとめる。
#Region "定数関連"
    Private Const D_READ = 1
    Private Const D_KATEGORY = 2
    Private Const D_RATE = 3
    Private Const D_TOTAL = 4
    Private Const D_POSTAGE = 5
    Private Const D_FEE = 6
    Private Const D_CHANGE = 7
    Private Const D_MESSAGE = 8

    Private Const DISCOUNT_R = "%"
    Private Const DISCOUNT_K = "\"

    Private Const POSTAGE = 1
    Private Const FEE = 2

    Private Const CANCEL = -1
    Private Const CASH = 1
    Private Const CREGIT = 2
    Private Const POINT = 3

    '2019.10.9 R.Takashima コメント追加
    'M_○○という定数は取引明細区分(SUBTRNCLASS変数)の定数
    Private Const M_SALE = 1         '通常売上
    Private Const M_DISCOUNT_U = 2   '単品値引
    Private Const M_POSTAGE = 3      '送料
    Private Const M_FEE = 4          '手数料
    Private Const M_DISCOUNT_M = 5   '会員値引
    Private Const M_DISCOUNT_P = 6   'ポイント値引
    Private Const M_DISCOUNT_C = 7   'チケット値引
    Private Const M_DISCOUNT_T = 8   '合計値引
    Private Const M_MORE = 9         '同一商品ボタン

    Private Const RECEIPT_LEFT_MARGIN_STAR = "   "

    '2019.10.16 R.Takashima FROM
    Private Const REDUCE_TAX As Integer = 8 '軽減消費税率
    '2019.10.16 R.Takashima TO

    '2019.10.18 R.Takashima FROM
    'レシート印刷時に軽減税率対象商品かを判別するために使う
    Private Const REDUCE_TAX_MARK As String = "☆" ' 軽減税率対象マーク
    '2019.10.18 R.Takashima TO

#End Region

#Region "DBアクセス関連"
    '------------------------------------
    Private oTool As cTool
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTrn() As cStructureLib.sTrn
    Private oDataTrnDBIO As cDataTrnDBIO

    Private oSubTrn() As cStructureLib.sSubTrn
    Private oSubDataTrnDBIO As cDataTrnSubDBIO

    Private oMstStockDBIO As cMstStockDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oViewBom() As cStructureLib.sViewBom
    Private oMstBomDBIO As cMstBomDBIO

    Private oStaffFull() As cStructureLib.sViewStaffFull
    Private oStaffDBIO As cMstStaffDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductSalePrice() As cStructureLib.sViewProductSalePrice
    Private oMstProductDBIO As cMstProductDBIO

    Private oAdjust() As cStructureLib.sAdjust
    Private oMstAdjustDBIO As cDataAdjustDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMstOPOSDBIO As cMstOPOSDBIO
    Private oOPOS() As cStructureLib.sOPOS

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oServiceRate() As cStructureLib.sServiceRate
    Private oMstServiceDBIO As cMstServiceDBIO

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private oPointData() As cStructureLib.sPoint
    Private oDataPointDBIO As cDataPointDBIO

    Private oMeisai() As cStructureLib.sViewMeisai

    Private oDisplay As cOPOSControlLib.cDisplay
    Private oDrawer As cOPOSControlLib.cDrawer
    Private oPrinter As cOPOSControlLib.cPrinter

#End Region

#Region "変数"
    Private strPath As String
    Private CATEGORY() As String        '売上カテゴリ用
    Private CATEGORY_MAX As Integer     '売上カテゴリボタンの個数
    Private T_MODE As Integer           'トラン入力状態フラグ　0：未入力状態　　1:入力中状態  2：修正中
    Private S_MODE As Integer           'サブトラン入力状態フラグ　0：未入力状態　　1:入力中状態  
    Private D_MODE As Integer           'データ入力状態　0：未入力状態　　1:入力中状態
    Private G_MODE As Boolean           '合計ボタンの押下状態　No:Off　　Yes:On
    Private TRNCODE As Long             '取引コード
    Private OLDTRNCODE As Long          '旧取引コード（返品処理時に使用）
    Private SUB_TRNCODE As Long         '取引明細番号
    Private TRNCLASS As String          '取引区分（売上 / 返品 / 中止 / 販促 / 社販）
    Private SUBTRNCLASS As String       '取引明細区分（1:売上・2:入金・3:出金・4:戻入・5:値引）
    Private UPRICE As Long              '単価
    Private UCOUNT As Single            '数量
    Private UCASH As Long               '単品販売価格
    Private UPOSTAGE_CASH As Long       '送料
    Private UFEE_CASH As Long           '手数料
    Private UDISCOUNT As Long           '単品値引き
    Private POSTAGE_CASH As Long        '送料
    Private FEE_CASH As Long            '手数料
    Private TOTAL_CASH As Long          '合計金額
    Private POINT_CASH As Long          'ポイント値引き
    Private TICKET_CASH As Long         'チケット値引き
    Private RECEIVE_CASH As Long        'お預り金額
    Private CHANGE_CASH As Long         'おつり金額
    Private DISCOUNT_CASH As Long       '合計お値引き金額
    Private DISCOUNT_RATE As Integer    '値引き率
    Private PRODUCT_i As Integer      'お買上げ商品数カウンタ
    Private SEISAN_MODE As Integer      'CASH or CREGIT or POINT
    Private BUMON_COUNT As Integer      '登録部門数
    Private CHANNEL_CODE As Integer     'チャネルコード
    Private POINT_i As Long           '保有ポイント数
    Private ADD_POINT_i As Long       '付与ポイント数
    Private USE_POINT_i As Long       '使用ポイント数


    Private BUMON_INDEX As Integer
    '顧客情報用
    Private MEMBER_CODE As String       '会員コード
    Private POINT_MEMBER_CODE As String 'ポイント会員コード

    Private SEX As String               '性別
    Private GENERATION As Integer       '年代
    Private WEATHER As String           '天気

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private PRINTER_MAKER As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    '2016.06.28 K.Oikawa s
    Private returnOver As Integer
    '2016.06.28 K.Oikawa e

    '2019.10.18 R.Takashima コメント追加
    'レシート再発行モード
    '2016.07.04 K.Oikawa s
    Private R_MODE As Boolean
    '2016.07.04 K.Oikawa e

    '2019.10.17 R.Takashima FROM
    Private sumDiscountFlag As Boolean '合計値引きが押されたかを判別
    '2019.10.17 R.Takashima TO

    '2019.10.19 R.Takashima FROM
    'ラインディスプレイの接続状態
    Private LINE_DISPLAY_OPEN As Boolean
    'ドロワーの接続状態
    Private DRAWER_OPEN As Boolean
    '2019.10.19 R.Takashima TO

    '2019.10.24 R.Takashima FROM
    '顧客情報入力画面
    '使うたびに破棄すると天気情報が引き継げないため追加
    Private Customer_form As fCustomer
    '2019.10.24 R.Takashima TO

#End Region

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

        oDataTrnDBIO = New cDataTrnDBIO(oConn, oCommand, oDataReader)
        oSubDataTrnDBIO = New cDataTrnSubDBIO(oConn, oCommand, oDataReader)
        oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oMstBomDBIO = New cMstBomDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        oMstServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        oMstStockDBIO = New cMstStockDBIO(oConn, oCommand, oDataReader)

        oDisplay = New cOPOSControlLib.cDisplay(oConn, oCommand, oDataReader, oTran)
        oDrawer = New cOPOSControlLib.cDrawer(oConn, oCommand, oDataReader, oTran)
        oPrinter = New cOPOSControlLib.cPrinter(oConn, oCommand, oDataReader, oTran)

        oTool = New cTool

        CATEGORY_MAX = 8
        ReDim CATEGORY(CATEGORY_MAX - 1)

        '2016.07.04 K.Oikawa s
        'レシート再発行用
        R_MODE = False
        '2016.07.04 K.Oikawa e

    End Sub

    '<System.RuntiMe.CNTnteropServices.DllImport("winmm.dll", EntryPoint:="PlaySound")> _
    'Private Shared Function PlaySound(<System.RuntiMe.CNTnteropServices.MarshalAs( _
    '                        System.RuntiMe.CNTnteropServices.UnmanagedType.LPStr)> _
    '    ByVal pszSound As String, _
    '    ByVal hModule As Integer, _
    '    ByVal dwFlags As Integer) _
    '    As Integer
    'End Function
    'WAVEファイルを再生する
    ' ''******************************************************************
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
    ''******************************************************************
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
    'フォームロード処理
    '******************************************************************
    Private Sub Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ret As Integer
        Dim RecordCount As Long
        Dim pInAdjustCode As Long
        Dim pCloseAdjustCode As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        ''プログラム起動フォルダパスの取得
        'strPath = Application.StartupPath


        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCount < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Environment.Exit(1)
            Exit Sub
        End If
        oMstConfigDBIO = Nothing

        ReDim oOPOS(0)
        oMstOPOSDBIO = New cMstOPOSDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sRecertPrinterProductClass, oTran)
        If RecordCount < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "OPOSマスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstOPOSDBIO = Nothing
            Environment.Exit(1)
            Exit Sub
        End If
        oMstOPOSDBIO = Nothing

        PRINTER_MAKER = oOPOS(0).sMakerName

        '---------------------
        '   周辺機器オープン
        '---------------------


        'TODO:課題表No88ドロワー接続失敗のメッセージが表示されない
        '機器が存在しているのか確認する方法を要調査

        'ドロワーオープン
        DRAWER_OPEN = oDrawer.DrawerInit()
        '2016.07.05 K.Oikawa s
        '課題表No88 周辺機器の接続確認修正
        'If ret Then
        If DRAWER_OPEN = False Then
            '2016.07.05 K.Oikawa e
            MSG_T.Text = "ドロワ接続エラー = " & Trim(Str(ret))
            Dim message_form As New cMessageLib.fMessage(1,
                                              "ドロワの",
                                              "接続に失敗しました(ERRCODE:" & Trim(Str(ret)),
                                              "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If


        'プリンターオープン
        ret = oPrinter.PrinterInit()

        '2016.07.05 K.Oikawa s
        '課題表No88 周辺機器の接続確認修正
        'If ret Then
        If ret = False Then
            '2016.07.05 K.Oikawa e           
            MSG_T.Text = "レシートプリンター接続エラー = " & Trim(Str(ret))
            Dim message_form As New cMessageLib.fMessage(1,
                                              "レシートプリンターの",
                                              "接続に失敗しました(ERRCODE:" & Trim(Str(ret)),
                                              "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If


        'ラインディスプレーオープン
        LINE_DISPLAY_OPEN = oDisplay.DisplayInit()
        '2016.07.05 K.Oikawa s
        '課題表No88 周辺機器の接続確認修正
        'If ret Then
        If LINE_DISPLAY_OPEN = False Then
            '2016.07.05 K.Oikawa e           
            MSG_T.Text = "ラインディスプレー初期化エラー = " & Trim(Str(ret))
            Dim message_form As New cMessageLib.fMessage(1,
                                              "ラインディスプレーの",
                                              "初期化に失敗しました(ERRCODE:" & Trim(Str(ret)),
                                              "開発元に連絡して下さい", Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

        '画面初期化
        DISP_INIT("MEMBER")
        DISP_INIT("REG")
        DISP_INIT("PRODUCT")
        DISP_INIT("SUM")

        '変数初期化
        VALUE_INIT(0)

        '部門設定
        BUMON_SET()

        'チャネル名称設定
        CHANNEL_SET()

        'ファンクションボタン設定
        FUNC_SET()

        '----------------------------- ハードウェア初期化終了 -----------------------------
        '入金確認
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
            oMstAdjustDBIO = Nothing
            Application.DoEvents()
            Environment.Exit(1)
            Exit Sub
        End If

        'スタッフ入力ウィンドウ表示
        STAFF_ENTRY()

        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        RecordCount = oStaffDBIO.getStaffFull(oStaffFull, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

        '会員入力
        Customer_form = New fCustomer(oConn, oCommand, oDataReader, oDrawer, oTran)
        CUSTMOER_ENTRY()

        '明細表示用データグリッドの生成
        GRIDVIEW_CREATE()

        'JANコードにセットフォーカス
        JAN_CODE_T.Focus()

        'トランザクションの開始
        oTran = oConn.BeginTransaction
    End Sub



    '***********************************************************************
    '                              JANコード処理
    '***********************************************************************
    Private Sub JAN_CODE_SEARCH(ByVal JanCode As String, ByVal ProductCode As String)

        '2016.06.27 K.Oikawa s
        'JANコード不正な状態で入ってくる可能性があるので修正
        '1､会員登録ボタンを押下し、何もせずに登録ボタンを押下するとエラーで落ちる
        '2､不正なJANコードが入力された場合（数値以外を含む、桁数が1桁以下など）
        '一先ずJANが空の場合に処理を行わないよう修正

        '2017.02.06 K.Oikawa s
        '海外JANが12桁で入ってくる場合が存在するので、12桁も通る必要がある
        '数値であることと3桁以上入っていることが担保できれば下の処理で処理できるので、桁数変更
        'If JanCode.Length <= 13 Then

        '2019.10.04 R.Takashima
        'JANコード不正メッセージの挿入
        If JanCode.Length <= 3 Then
            Dim message_form As cMessageLib.fMessage
            message_form = New cMessageLib.fMessage(1, "JANコードが不正な値です。", "JANコードを確認して下さい。", "", "")
            message_form.ShowDialog()
            message_form = Nothing

            '2017.02.06 K.Oikawa e
            Exit Sub
        End If
        '2016.06.27 K.Oikawa e

        'キー入力音出力
        ' PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)
        oTool.PlaySound()

        D_MODE = 1

        Select Case JanCode.ToString.Substring(0, 2)
            Case "98"       '取引コード
                '取引データ検索
                If TRN_SEARCH(JanCode) = False Then
                    Exit Sub
                End If

                MSG_T.BackColor = Color.Pink
                MSG_T.Text = "取引データ修正モード"

                T_MODE = 2    '修正モード設定

                TRN_SET(oTrn)

            Case Else
                Select Case JanCode.ToString.Substring(0, 3)

                    Case "993"      '会員コード
                        If MEMBER_SEARCH(JanCode) = False Then
                            JAN_CODE_T.Text = ""
                            JAN_CODE_T.Focus()
                            Exit Sub
                        Else
                            '会員設定
                            MEMBER_SET(JanCode)
                        End If

                        '入力中モードの解除
                        D_MODE = 0

                        '明細更新
                        MEISAI_UPDATE()

                    Case "997"      'ポイント会員コード

                        'ポイント会員設定
                        If POINT_MEMBER_SEARCH(JanCode) = False Then
                            JAN_CODE_T.Text = ""
                            JAN_CODE_T.Focus()
                            Exit Sub
                        Else
                            'ポイント会員設定
                            POINT_MEMBER_SET(JanCode)
                        End If

                        '入力中モードの解除
                        D_MODE = 0

                    Case Else       '商品コード
                        If T_MODE = 2 Then
                            EDIT_TRN(JanCode, ProductCode)
                        Else
                            NEW_TRN(JanCode, ProductCode)
                        End If

                End Select

                G_MODE = False

                '精算ボタンディスイネーブル
                CASH_B.Enabled = False
                CREDIT_B.Enabled = False
                TRADE_RETURN_B.Enabled = False
                NOVEL_B.Enabled = False
                IN_SALES_B.Enabled = False
        End Select

        JAN_CODE_T.Text = ""
        JAN_CODE_T.Focus()

    End Sub

    '***********************************************************************
    '                                   END 
    '***********************************************************************



    '***********************************************************************
    '                              数字ボタン処理
    '***********************************************************************

    '入力された文字をDISPLAYエリアにセットする処理
    '[引数]
    '   D_MODE　0：入力確定後ファーストの入力
    '          1：数値の継続入力中
    '   NUM    ：入力された文字（数値）
    '***********************************************************************
    Function KEY_INPUT(ByRef D_MODE As Integer, ByVal NUM As String) As Integer

        'キー入力音出力
        oTool.PlaySound()

        '入力された数字を表示
        If D_MODE <> 0 Then    '１明細の入力途中の場合
            Select Case NUM
                Case "×"
                    UCOUNT = DISPLAY_T.Text
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(DISPLAY_T.Text, "0")
                    VALUE_INIT(2)
                Case "CLR"
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(1, TOTAL_CASH)
                    VALUE_INIT(2)
                Case Else
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(CNT_T.Text, DISPLAY_T.Text & NUM)
            End Select
        Else                    '1明細の最初の入力の場合
            Select Case NUM
                Case "CLR"
                    'DISPLAY_T.Text = TOTAL_CASH
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(CNT_T.Text, TOTAL_CASH)
                    UCOUNT = 1
                    VALUE_INIT(2)
                Case "×"
                    'Me.CNT_T.Text = Me.DISPLAY_T.Text
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(DISPLAY_T.Text, "0")
                    VALUE_INIT(2)
                Case "．"
                    VALUE_INIT(2)
                Case Else
                    'DISPLAY_T.Text = NUM
                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(CNT_T.Text, NUM)
                    D_MODE = 1           '入力中モードに変更
            End Select
        End If

        'JANコードにセットフォーカス
        JAN_CODE_T.Focus()


    End Function
    Private Sub NUM_00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DISPLAY_T.Text = "" Then
            Exit Sub
        End If
        KEY_INPUT(D_MODE, "00")

    End Sub
    Private Sub NUM_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DISPLAY_T.Text = "" Then
            Exit Sub
        End If
        KEY_INPUT(D_MODE, "0")

    End Sub
    Private Sub NUM_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "1")
    End Sub
    Private Sub NUM_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "2")
    End Sub
    Private Sub NUM_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "3")
    End Sub
    Private Sub NUM_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "4")
    End Sub
    Private Sub NUM_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "5")
    End Sub
    Private Sub NUM_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "6")
    End Sub
    Private Sub NUM_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "7")
    End Sub
    Private Sub NUM_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "8")
    End Sub
    Private Sub NUM_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "9")
    End Sub
    Private Sub NUM_DOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DISPLAY_T.Text = "" Then
            Exit Sub
        End If
        If (D_MODE = 1) Then
            KEY_INPUT(D_MODE, ".")
        Else
            KATEGORY_1_B.Focus()
        End If
    End Sub

    '***********************************************************************
    '                                End
    '***********************************************************************



    '***********************************************************************
    '                            カテゴリボタン
    '***********************************************************************

    '**************************************************
    'カテゴリボタンクリック時の共通処理
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************

    '2019.10.6 R.Takashima
    '同様の処理をしているPRODUCT_SET_PROCに統合したため現在は使われていない
    Private Sub KATEGOTY_BUTTOM_PROC(ByVal sender As Softgroup.NetButton.NetButton, ByVal BumonName As String)

        Dim ret As Boolean
        Dim RecordCount As Integer

        '2016.09.14 K.Oikawa s
        '課題表No.163 以前使用したデータが残っている
        oProductSalePrice = Nothing
        '2016.09.14 K.Oikawa e

        'キー入力音出力
        oTool.PlaySound()

        If BumonName = Nothing Then
            BUMON_INDEX = BUMON_INDEX_GET(sender.TextButton)
        Else
            BUMON_INDEX = BUMON_INDEX_GET(BumonName)

        End If

        SUBTRNCLASS = 1

        '部門種別＝サービスの場合
        If BUMON_INDEX >= 0 Then
            If CLng(oBumon(BUMON_INDEX).sBumonCode) >= 9900000000000 Then
                RecordCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice,
                                                        CHANNEL_CODE,
                                                        Nothing,
                                                        oBumon(BUMON_INDEX).sBumonCode,
                                                        oTran)
                If RecordCount > 1 Then
                    Dim SelectJAN_form As New cSelectLib.fSelectJAN(oConn,
                                         oCommand,
                                         oDataReader,
                                         CHANNEL_CODE,
                                         oBumon(BUMON_INDEX).sBumonCode,
                                         oConf,
                                         oTran)

                    SelectJAN_form.ShowDialog()
                    If SelectJAN_form.DialogResult = Windows.Forms.DialogResult.OK Then
                        RecordCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice,
                                                                 CHANNEL_CODE,
                                                                 SelectJAN_form.PRODUCT_CODE_T.Text,
                                                                 Nothing,
                                                                 oTran)
                    Else
                        Dim message_form As New cMessageLib.fMessage(1,
                                          "対象商品が登録されていません",
                                          "価格を入力して下さい",
                                          Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing

                        '変数初期化
                        VALUE_INIT(1)

                        'JANコードにセットフォーカス
                        JAN_CODE_T.Focus()

                        Exit Sub
                    End If
                    SelectJAN_form = Nothing
                End If
            End If
        End If

        '選択商品情報を画面にセット
        If IsNothing(oProductSalePrice) = True Then
            ReDim oProductSalePrice(0)
        End If
        If oProductSalePrice(0).sProductCode = Nothing Then
            If D_MODE = 0 Then
                Exit Sub
            End If

            JAN_CODE_T.Text = ""
            PRODUCT_CODE_T.Text = ""
            PRODUCT_NAME_T.Text = sender.TextButton
            OPTION_1_T.Text = ""
            OPTION_2_T.Text = ""
            OPTION_3_T.Text = ""
            OPTION_4_T.Text = ""
            OPTION_5_T.Text = ""
            PRICE_T.Text = ""
            SALE_PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
        Else
            JAN_CODE_T.Text = oProductSalePrice(0).sJANCode
            PRODUCT_CODE_T.Text = oProductSalePrice(0).sProductCode
            PRODUCT_NAME_T.Text = oProductSalePrice(0).sProductShortName
            OPTION_1_T.Text = oProductSalePrice(0).sOption1
            OPTION_2_T.Text = oProductSalePrice(0).sOption2
            OPTION_3_T.Text = oProductSalePrice(0).sOption3
            OPTION_4_T.Text = oProductSalePrice(0).sOption4
            OPTION_5_T.Text = oProductSalePrice(0).sOption5
            PRICE_T.Text = oTool.BeforeToAfterTax(oProductSalePrice(0).sListPrice, oConf(0).sTax, oConf(0).sFracProc)
            SALE_PRICE_T.Text = oTool.BeforeToAfterTax(oProductSalePrice(0).sSalePrice, oConf(0).sTax, oConf(0).sFracProc)
            DISPLAY_T.Text = oTool.BeforeToAfterTax(oProductSalePrice(0).sSalePrice, oConf(0).sTax, oConf(0).sFracProc)
        End If
        D_MODE = 1

        If Me.DISPLAY_T.Text = "0" Then  '未入力状態

            JAN_CODE_T.Focus()
            Beep()
            MSG_T.Text = "価格が入力されていません"
            Dim message_form As New cMessageLib.fMessage(1,
                                              "価格が入力されていません",
                                              "価格を入力して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        Else
            UPRICE = Me.DISPLAY_T.Text
            UCOUNT = Me.CNT_T.Text
            If D_MODE = 1 Then
                ret = CAL_PROC(Nothing)      '集計（カテゴリ番号）

                '日次取引明細データ更新
                DAY_SUBTRN_INSERT(Nothing, Nothing)

                '明細行の表示
                ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), Nothing)

                '集計エリア表示
                SUM_DISPLAY()

                'ラインディスプレー表示 
                LINE_DISPLAY(D_KATEGORY)

                '商品価格表示セット
                Me.DISPLAY_T.Text = UPRICE * UCOUNT

                '入力モード=未入力状態をセット
                D_MODE = 0

                '数量イニシャライズ
                CNT_T.Text = 1

                '会員割引設定
                If MEMBER_CODE_T.Text <> "" Then
                    '会員割引率が0以外の場合
                    oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                    If IsNothing(oServiceRate) Then
                        ReDim oServiceRate(0)
                        oServiceRate(0).sRate = 0
                    End If
                    If oServiceRate(0).sRate <> 0 Then

                        '取引明細番号インクリメント
                        SUB_TRNCODE = SUB_TRNCODE + 1

                        '割引率を画面セット
                        oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                        DISPLAY_T.Text = oServiceRate(0).sRate

                        '入力中モードをセット
                        D_MODE = 1

                        '取引明細区分=値引きを設定
                        SUBTRNCLASS = M_DISCOUNT_M

                        DISCOUNT_PROC(DISCOUNT_R)
                    End If
                End If
                JAN_CODE_T.Focus()
            End If

            '取引明細番号のインクリメント
            SUB_TRNCODE = SUB_TRNCODE + 1

            JAN_CODE_T.Text = ""

            TRN_CODE_T.Text = TRNCODE
            TRNSUB_CODE.Text = SUB_TRNCODE

        End If

        'バッファ初期化
        ReDim oProductSalePrice(0)

        '変数初期化
        VALUE_INIT(1)

        'JANコードにセットフォーカス
        JAN_CODE_T.Focus()

    End Sub

    '***********************************************************************
    '                                End
    '***********************************************************************



    '***********************************************************************
    '                 値引き、付加料金欄のボタン処理
    '***********************************************************************
    Private Sub EDIT_FEE_TRN()
        Dim recCount As Long
        Dim message_form As cMessageLib.fMessage
        'Dim pBumon() As cStructureLib.sBumon
        Dim pSubTrn() As cStructureLib.sSubTrn
        Dim i As Integer
        'Dim j As Integer
        Dim pPrice As Long
        Dim mPrice As Long
        Dim DisCountPrice As Long
        Dim BuyPrice As Long
        Dim ProcStr As String = ""

        pPrice = CLng(DISPLAY_T.Text)

        ReDim pSubTrn(0)
        recCount = oSubDataTrnDBIO.getSubTrn(pSubTrn, TRNCODE, Nothing, SUBTRNCLASS, Nothing, Nothing, Nothing, Nothing, oTran)

        Select Case SUBTRNCLASS
            Case M_POSTAGE   '送料の場合
                ProcStr = "送料"
            Case M_FEE   '手数料の場合
                ProcStr = "手数料"
        End Select

        '登録情報の取得
        If recCount = 0 Then
            MSG_T.Text = ProcStr & "の明細が存在しません。"
            message_form = New cMessageLib.fMessage(1,
                                              ProcStr & "の明細が存在しません。",
                                              "入力を確認して下さい。",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Beep()
            D_MODE = 0
            JAN_CODE_T.Text = ""
            Exit Sub
        End If

        ReDim pSubTrn(0)
        BuyPrice = oSubDataTrnDBIO.getSumPrice(pSubTrn, TRNCODE, SUBTRNCLASS, oTran)
        If pPrice > BuyPrice Then
            MSG_T.Text = ProcStr & "の金額が不足しています。"
            message_form = New cMessageLib.fMessage(1,
                                              ProcStr & "の金額が不足しています。",
                                              "入力を確認して下さい。",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Beep()
            D_MODE = 0

            '2019.10.10 R.Takashima
            SET_TEXT_ABOVE_WINDOW(1, "0", "")
            'JAN_CODE_T.Text = ""
            'DISPLAY_T.Text = 0
            'CNT_T.Text = 1
            Exit Sub
        End If

        'ラインディスプレー表示
        'LINE_DISPLAY(D_READ)

        D_MODE = 1
        S_MODE = 1

        '返品数確認
        For i = 0 To MEISAI_V.RowCount - 1
            mPrice = 0
            DisCountPrice = 0
            mPrice = CLng(MEISAI_V("金額", i).Value)
            If MEISAI_V("商品名称", i).Value = "(" & ProcStr & ")" And mPrice > 0 Then
                MEISAI_V.Rows(i).DefaultCellStyle.ForeColor = Color.Red

                If mPrice <= pPrice Then
                    MEISAI_V("返金額", i).Value = MEISAI_V("返金額", i).Value + CLng(MEISAI_V("金額", i).Value)
                    MEISAI_V("金額", i).Value = 0
                Else
                    MEISAI_V("返金額", i).Value = MEISAI_V("返金額", i).Value + pPrice
                    MEISAI_V("金額", i).Value = mPrice - pPrice
                End If
                pPrice = pPrice - mPrice
                If pPrice = 0 Then
                    Exit For
                End If
            End If
        Next

        GOUKEI_B.Enabled = True
        MEISAI_V.CurrentCell = Nothing

        SUM_DISPLAY()

    End Sub

    '***********************************************************************
    '                                End
    '***********************************************************************



    '***********************************************************************
    '                 清算欄内にあるボタン処理
    '***********************************************************************

    Private Sub SEISAN_PROC(ByVal sender As Softgroup.NetButton.NetButton)
        Dim pGetPointi As Long
        Dim RecordCount As Long

        '合計ボタンが押下されているかの確認
        If D_MODE <> 0 And G_MODE <> True Then
            Dim message_form As New cMessageLib.fMessage(1,
                                  "価格が確定されていません",
                                  "カテゴリを確定してから精算ボタンを押下して下さい。",
                                  Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            JAN_CODE_T.Focus()
            Exit Sub
        End If

        '預かり金未入力の場合は、請求金額を預かり金としてセット
        If sender.TextButton = "現　金" Then
            RECEIVE_CASH = Me.DISPLAY_T.Text
        Else
            RECEIVE_CASH = TOTAL_CASH
        End If
        CHANGE_CASH = RECEIVE_CASH - TOTAL_CASH

        '2019.10.15 R.Takashima FROM
        '預かり金額が請求金額よりも少ない場合の処理を追加
        If CHANGE_CASH < 0 Then
            Dim message_form As New cMessageLib.fMessage(1,
                                            String.Format("預かり金額が{0:C}足りていません。", CHANGE_CASH * -1),
                                            "預かり金額を入力してください。",
                                            Nothing,
                                            Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            D_MODE = 0
            JAN_CODE_T.Focus()

            LINE_DISPLAY(D_CHANGE)
            Exit Sub
        End If
        '2019.10.15 R.Takashima TO

        SET_TEXT_ABOVE_WINDOW(CNT_T.Text, CHANGE_CASH)
        'Me.DISPLAY_T.Text = CHANGE_CASH


        '2016.06.03 K.Oikawa s
        '課代表.No62 返品処理の実装
        ''日次取引データ登録
        'If T_MODE = 2 Then  '返品処理
        '    RETURN_DAY_SUBTRN_INSERT()
        '    RETURN_DAY_TRN_INSERT(sender)
        'Else
        '    DAY_TRN_INSERT(sender)
        'End If

        ''取引区分="戻入"の場合は、取引明細データの金額をマイナスに更新
        ''取引区分="販促"の場合は、取引明細データの金額を0に更新
        'Select Case sender.TextButton
        '    Case "戻入"
        '        If T_MODE <> 2 Then
        '            DAY_SUBTRN_UPDATE(sender.TextButton)
        '        End If
        '    Case "販促"
        '        DAY_SUBTRN_UPDATE(sender.TextButton)
        'End Select

        ''在庫更新
        'UPDATE_STOCK(sender)

        ''ポイントデータ更新
        'If POINT_MEMBER_CODE_T.Text <> "" Then
        '    pGetPointi = oTool.ToRoundDown(TOTAL_CASH * (oConf(0).sPointRATE / oConf(0).sPointEN), 0)
        '    ADD_POINT_i = pGetPointi
        '    POINT_i = POINT_INSERT(ADD_POINT_i, 0)
        'Else
        '    POINT_i = 0
        'End If


        If sender.TextButton = "戻入" Then      '返品処理
            '備考
            Dim pMemo As String
            pMemo = ""

            '返品理由の確認
            Dim Select_Form As New fReturnReason()
            Select_Form.ShowDialog()

            '返品理由の確認
            '取引情報の取得
            Dim pStockUpdFlg As Integer '0:変更なし 1:加算 2:減算
            Dim pTrnUpdFlg As Integer '0:変更なし 1:加算 2:減算

            pStockUpdFlg = 0

            Select Case True
                Case Select_Form.REASON_1_R.Checked
                    pMemo = "商品不良"
                Case Select_Form.REASON_2_R.Checked
                    pMemo = "お客様都合"
                Case Select_Form.REASON_3_R.Checked
                    pMemo = "運送破損"
                Case Select_Form.REASON_4_R.Checked
                    pMemo = "長期不在"
            End Select


            '返品内容に応じて処理を行う

            Select Case True '再販可否
                Case Select_Form.RESALE_1_R.Checked '再販可能
                    '【在庫数：加算】
                    pStockUpdFlg = 1 '加算
                    pMemo = pMemo & "-返品対応-再販可能"
                Case Select_Form.RESALE_2_R.Checked '再販不可
                    '【在庫数：更新なし】
                    pStockUpdFlg = 0
                    pMemo = pMemo & "-返品対応-再販不可"
            End Select


            'クレジット返金可否
            Select Case True '再販可否
                Case Select_Form.CREDIT_1_R.Checked '再販可能
                    '【現金(ポイント)：減算】
                    pTrnUpdFlg = 1 '減算
                Case Select_Form.CREDIT_2_R.Checked '再販不可
                    '【現金(ポイント)：更新なし】
                    pTrnUpdFlg = 0
            End Select



            '上記の条件ごとに以下の処理を実行する
            '在庫：更新パターン (0:変更なし 1:加算 2:減算）

            '在庫更新
            If pStockUpdFlg <> 0 Then
                '在庫更新
                UPDATE_STOCK_RETURN(pStockUpdFlg)
            End If


            '2019.11.02 R.Takashima From
            '返品時ポイントは戻さないためコメントアウト

            '返品対象の商品購入時に使用したポイントを戻す
            '使用したポイントを取得する
            'ADD_POINT_i = CLng(PDISCOUNT_T.Text)
            'If ADD_POINT_i <> 0 Then
            '    '使用ポイントの取り消し
            '    POINT_i = POINT_INSERT(0, ADD_POINT_i)
            'End If


            '返品対象商品の購入時に取得したポイントの減算
            'If POINT_MEMBER_CODE_T.Text <> "" Then

            '    '現所有ポイント
            '    Dim getPoint As Integer
            '    getPoint = oDataPointDBIO.getPoint(POINT_MEMBER_CODE_T.Text, oTran)

            '    '購入時に得たポイントを取得する
            '    pGetPointi = oTool.ToRoundDown(TOTAL_CASH * (oConf(0).sPointRATE / oConf(0).sPointEN), 0)

            '    If getPoint < pGetPointi Then
            '        'ポイントの減算

            '        'ポイントをある分だけ減算する
            '        POINT_i = POINT_INSERT((getPoint * -1), 0)

            '        '返金額の減算
            '        returnOver = pGetPointi - getPoint

            '    Else
            '        '購入時に得たポイントを減算
            '        POINT_i = POINT_INSERT((pGetPointi * -1), 0)
            '        returnOver = 0
            '    End If
            'Else
            '    POINT_i = 0
            '    returnOver = 0
            'End If
            '2019.11.02 R.Takashima

            If pTrnUpdFlg <> 0 Then
                '現金更新
                '日次取引データ登録
                RETURN_DAY_SUBTRN_INSERT(pMemo)
                RETURN_DAY_TRN_INSERT(sender)

                ''取引明細データの金額をマイナスに更新
                'DAY_SUBTRN_UPDATE(sender.TextButton)

            End If

        Else     '返品以外

            '日次取引データ登録
            DAY_TRN_INSERT(sender)

            '取引区分="販促"の場合は、取引明細データの金額を0に更新
            Select Case sender.TextButton
                Case "販促"
                    DAY_SUBTRN_UPDATE(sender.TextButton)
            End Select

            '在庫更新
            UPDATE_STOCK(sender)

            'ポイントデータ更新
            If POINT_MEMBER_CODE_T.Text <> "" Then
                pGetPointi = oTool.ToRoundDown(TOTAL_CASH * (oConf(0).sPointRATE / oConf(0).sPointEN), 0)
                ADD_POINT_i = pGetPointi
                POINT_i = POINT_INSERT(ADD_POINT_i, 0)
            Else
                POINT_i = 0
            End If

            '2016.07.06 K.Oikawa s
            '課題表No18 返品時のみレシートの印刷は行わない
            'レシート印刷
            'oMstChannelDBIO.getChannelMst(oChannel, CHANNEL_CODE, Nothing, Nothing, Nothing, oTran)
            'If oChannel(0).sReceiptPrint = True Then
            '    RECEIPT_PRINTING()
            'End If
            '2016.07.06 K.Oikawa e

        End If
        '2016.06.03 K.Oikawa e

        '2016.07.06 K.Oikawa s
        '課題表No18 返品時にレシートの印刷は行わない
        '2019.11.02 R.Takashima
        '返品時もレシートの印刷をするように変更
        ''レシート印刷
        oMstChannelDBIO.getChannelMst(oChannel, CHANNEL_CODE, Nothing, Nothing, Nothing, oTran)
        If oChannel(0).sReceiptPrint = True Then
            RECEIPT_PRINTING()
        End If
        '2016.07.06 K.Oikawa e

        'ラインディスプレー表示 
        LINE_DISPLAY(D_CHANGE)

        'Wait
        oTool.Wait(1)

        'ドロワーオープン 
        DROWER_OPEN()

        '変数初期化
        VALUE_INIT(0)

        '画面初期化
        DISP_INIT("MEMBER")
        DISP_INIT("REG")
        DISP_INIT("PRODUCT")
        DISP_INIT("SUM")

        'ラインディスプレー表示 
        LINE_DISPLAY(D_MESSAGE)

        'トランザクションのコミット
        oTran.Commit()
        oTran = Nothing


        STAFF_ENTRY()

        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        RecordCount = oStaffDBIO.getStaffFull(oStaffFull, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

        'TRN完了モード設定
        T_MODE = 0

        '会員入力
        CUSTMOER_ENTRY()

        'JANコードにフォーカスセット
        JAN_CODE_T.Focus()

        'トランザクションの開始
        oTran = oConn.BeginTransaction

    End Sub

    '***********************************************************************
    '                                End
    '***********************************************************************



    '***********************************************************************
    '                           その他ボタン処理
    '***********************************************************************
    Private Sub CHANNEL_CHANGED(ByVal sender As System.Object, ByVal CHECK_STATUS As Windows.Forms.RadioButton)
        If sender.Text <> "" And CHECK_STATUS.Checked = True Then
            oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, sender.Text, Nothing, oTran)
            CHANNEL_CODE = oChannel(0).sChannelCode

        End If
    End Sub

    '**************************************************
    '値引きー％ボタンクリック
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************
    Private Sub DISCOUNT_RATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '取引明細区分=単品値引きを設定
        If G_MODE = False Then                          '合計値引きモード＝Offの場合
            SUBTRNCLASS = M_DISCOUNT_U
        Else
            SUBTRNCLASS = M_DISCOUNT_T
        End If

        DISCOUNT_PROC(DISCOUNT_R)

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fAdjustCount_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 3, oTran)

        '現金情報入力画面表示
        fAdjustCount_form.ShowDialog()
        fAdjustCount_form = Nothing
    End Sub

    Private Sub CLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        KEY_INPUT(D_MODE, "CLR")
        DISPLAY_CLR(0)
    End Sub

    Private Sub DROWER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ドローワーオープン
        DROWER_OPEN()
    End Sub

    Private Sub GOUKEI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '合計金額表示
        DISPLAY_T.Text = TOTAL_CASH

        '変数クリア
        VALUE_INIT(1)

        '表示クリア
        DISPLAY_CLR(0)

        'ラインディスプレー表示 
        LINE_DISPLAY(D_TOTAL)

        '合計モード On
        G_MODE = True

    End Sub
    Private Sub BILLT_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If STAFF_CODE_T.Text = "" Then
            Dim message_form As New cMessageLib.fMessage(1,
                                  Nothing,
                                  "担当者を設定して下さい",
                                  Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            JAN_CODE_T.Focus()
            Exit Sub
        End If
        Bill_PRINTING(TRNCODE - 1, CHANNEL_CODE)

    End Sub

    '***********************************************************************
    '                                End
    '***********************************************************************



    '****************************************************************************************************************************
    '***********************************************************共通ファンクション***********************************************
    '****************************************************************************************************************************


    Private Sub NEW_TRN(ByVal JanCode As String, ByVal ProductCode As String)
        Dim recCount As Long
        Dim message_form As cMessageLib.fMessage
        Dim pBumon() As cStructureLib.sBumon

        recCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice, CHANNEL_CODE, ProductCode, Trim(JanCode), oTran)

        '登録情報の取得
        Select Case recCount
            Case 0 '該当JANコードが存在しなかった場合

                '2016.06.23 K.Oikawa s
                '課代表.No111 無限ループ回避
                JAN_CODE_T.Text = ""
                '2016.06.23 K.Oikawa e

                MSG_T.Text = "該当のJANコードが登録されていません"
                message_form = New cMessageLib.fMessage(1,
                                                  "該当のJANコードが登録されていません",
                                                  "商品登録を行って下さい",
                                                  Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Beep()
                D_MODE = 0
                JanCode = ""
            Case 1 '該当JANコードが1レコード存在した場合
                If oProductSalePrice(0).sSalePrice > 0 Then

                    '2019.10.10 R.Takashima
                    '呼び出しを場所を変更 > PRODUCT_SET_PROCへ
                    'PRODUCT_SET(oProductSalePrice(0))

                    '2019.10.10 R.Takashima
                    'ラインディスプレー呼び出し場所を変更 > PRODUCT_SET_PROCへ
                    'ラインディスプレー表示
                    'LINE_DISPLAY(D_READ)

                    D_MODE = 1
                    S_MODE = 1

                    ReDim pBumon(0)

                    '2019.10.6 R.Takashima
                    '引数の場所が間違っていたため修正
                    'この引数だと部門種別が取りたいのに部門コードを取りにいってしまい正確に値が帰ってこない
                    'oBumonDBIO.getBumonMst(pBumon,  oProductSalePrice(0).sProductClass, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                    oBumonDBIO.getBumonMst(pBumon, Nothing, Nothing, oProductSalePrice(0).sProductClass, Nothing, Nothing, Nothing, oTran)

                    '2019.10.6 R.Takashima
                    '部門種別(sBumonClass)内で重複するものがあるためここでどの部門名称なのか確定させる。
                    '部門マスタの部門コードはJANコードと共通として使っているようなので
                    'この条件になっている。
                    If (pBumon(0).sBumonClass = 2) Then
                        For Each bumon As cStructureLib.sBumon In pBumon
                            If bumon.sBumonCode = oProductSalePrice(0).sJANCode Then
                                pBumon(0) = bumon
                            End If
                        Next
                    End If

                    message_form = New cMessageLib.fMessage(0,
                                                            Nothing,
                                                            "レジ登録中です。",
                                                            Nothing,
                                                            Nothing)
                    message_form.Show()
                    Application.DoEvents()

                    '2016.09.14 K.Oikawa s
                    '課題表No.163 以前使用したデータが残っている件で、残す必要のあった処理を切り分ける
                    '(カテゴリーボタンを押した際の処理にて同様の動作を行っていたので、流用していた。ここを通る際にカテゴリボタンを押下していることはない)
                    'KATEGOTY_BUTTOM_PROC(Nothing, pBumon(0).sBumonShortName)

                    PRODUCT_SET_PROC(Nothing, pBumon(0).sBumonShortName)
                    '2016.09.14 K.Oikawa e

                    message_form.Dispose()

                    MORE_B.Enabled = True

                Else
                    MSG_T.Text = "販売価格が登録されていません"
                    message_form = New cMessageLib.fMessage(1,
                                                      "販売価格が登録されていません",
                                                      "商品情報を確認して下さい",
                                                      Nothing, Nothing)
                    message_form.ShowDialog()
                    message_form = Nothing
                    Beep()
                End If

                '入力中モードの解除
                D_MODE = 0

            Case Else '該当JANコードが複数存在した場合
                '重複JANコード商品の選択画面表示
                Dim SelectJAN_form As New cSelectLib.fSelectJAN(oConn,
                                                     oCommand,
                                                     oDataReader,
                                                     CHANNEL_CODE,
                                                     JanCode,
                                                     oConf,
                                                     oTran)
                SelectJAN_form.ShowDialog()

                '選択画面で選択された商品コードを取得
                ProductCode = SelectJAN_form.PRODUCT_CODE_T.Text

                '選択画面クラスの破棄
                SelectJAN_form = Nothing

                '商品情報セット
                recCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice, CHANNEL_CODE, ProductCode, Nothing, oTran)

                '2019.10.10 R.Takashima
                '呼び出しを場所を変更 > PRODUCT_SET_PROCへ
                'PRODUCT_SET(oProductSalePrice(0))

                '2019.10.10 R.Takashima
                'ラインディスプレー呼び出し場所を変更 > PRODUCT_SET_PROCへ
                'ラインディスプレー表示
                'LINE_DISPLAY(D_READ)

                D_MODE = 1
                S_MODE = 1

                ReDim pBumon(0)

                '2019.10.6 R.Takashima
                '引数の場所が間違っていたため修正
                'この引数だと部門種別が取りたいのに部門コードを取りにいってしまい正確に値が帰ってこない
                'oBumonDBIO.getBumonMst(pBumon,  oProductSalePrice(0).sProductClass, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                oBumonDBIO.getBumonMst(pBumon, Nothing, Nothing, oProductSalePrice(0).sProductClass, Nothing, Nothing, Nothing, oTran)

                '2019.10.6 R.Takashima
                '部門種別(sBumonClass)内で重複するものがあるためここでどの部門名称なのか確定させる。
                '部門マスタの部門コードはJANコードと共通として使っているようなので
                'この条件になっている。  部門コード = JANコード
                If (pBumon(0).sBumonClass = 2) Then
                    For Each bumon As cStructureLib.sBumon In pBumon
                        If bumon.sBumonCode = oProductSalePrice(0).sJANCode Then
                            pBumon(0) = bumon
                        End If
                    Next
                End If


                '2016.09.14 K.Oikawa s
                '課題表No.163 以前使用したデータが残っている件で、残す必要のあった処理を切り分ける
                '(カテゴリーボタンを押した際の処理にて同様の動作を行っていたので、流用していた。ここを通る際にカテゴリボタンを押下していることはない)
                'KATEGOTY_BUTTOM_PROC(Nothing, pBumon(0).sBumonShortName)

                PRODUCT_SET_PROC(Nothing, pBumon(0).sBumonShortName)
                '2016.09.14 K.Oikawa e

                MORE_B.Enabled = True
        End Select
    End Sub

    Private Sub EDIT_TRN(ByVal JanCode As String, ByVal ProductCode As String)
        Dim recCount As Long
        Dim message_form As cMessageLib.fMessage
        'Dim pBumon() As cStructureLib.sBumon
        Dim pSubTrn() As cStructureLib.sSubTrn
        Dim i As Integer
        Dim j As Integer
        Dim pCnt As Integer
        Dim mCnt As Integer
        Dim DisCountPrice As Long
        Dim BuyCount As Integer

        '2019.10.26 R.Takashima From
        '総返金額
        Dim totalReturnPrice As Long
        '総返金額がある明細行
        Dim totalReturnRowCount As Integer
        '2019.10.26 R.Takashima To

        pCnt = CInt(CNT_T.Text)

        ReDim pSubTrn(0)
        recCount = oSubDataTrnDBIO.getSubTrn(pSubTrn, TRNCODE, Nothing, Nothing, ProductCode, Nothing, JAN_CODE_T.Text, Nothing, oTran)

        '登録情報の取得
        Select Case recCount
            Case 0 '該当JANコードが存在しなかった場合
                MSG_T.Text = "該当の商品が購入されていません。"
                message_form = New cMessageLib.fMessage(1,
                                                  "該当のJANコードは購入されていません。",
                                                  "JANコードを確認して下さい。",
                                                  Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                Beep()
                D_MODE = 0
                JAN_CODE_T.Text = ""
                Exit Sub
            Case Else '該当JANコードが複数存在した場合
                '重複JANコード商品の選択画面表示
                If recCount > 1 Then
                    If ProductCode = Nothing Then
                        Dim SelectJAN_form As New cSelectLib.fSelectJAN(oConn,
                                                             oCommand,
                                                             oDataReader,
                                                             CHANNEL_CODE,
                                                             JanCode,
                                                             oConf,
                                                             oTran)
                        SelectJAN_form.ShowDialog()

                        '選択画面で選択された商品コードを取得
                        ProductCode = SelectJAN_form.PRODUCT_CODE_T.Text

                        '選択画面クラスの破棄
                        SelectJAN_form = Nothing
                    End If
                End If

                ReDim pSubTrn(0)
                BuyCount = oSubDataTrnDBIO.getSumCount(pSubTrn, TRNCODE, ProductCode, JAN_CODE_T.Text, oTran)
                If pCnt > BuyCount Then
                    MSG_T.Text = "該当の商品の購入数が不足しています。"
                    message_form = New cMessageLib.fMessage(1,
                                                      "該当の商品の購入数が不足しています。",
                                                      "数量を確認して下さい。",
                                                      Nothing, Nothing)
                    message_form.ShowDialog()
                    message_form = Nothing
                    Beep()
                    D_MODE = 0

                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(1, "0", "")
                    'JAN_CODE_T.Text = ""
                    'DISPLAY_T.Text = 0
                    'CNT_T.Text = 1
                    Exit Sub
                End If

                '商品情報セット
                ReDim pSubTrn(0)
                recCount = oSubDataTrnDBIO.getSubTrn(pSubTrn, TRNCODE, Nothing, Nothing, ProductCode, Nothing, JAN_CODE_T.Text, Nothing, oTran)
                If recCount = 0 Then
                    MSG_T.Text = "該当の商品が購入されていません。"
                    message_form = New cMessageLib.fMessage(1,
                                                      "該当の商品は購入されていません。",
                                                      "商品を確認して下さい。",
                                                      Nothing, Nothing)
                    message_form.ShowDialog()
                    message_form = Nothing
                    Beep()
                    D_MODE = 0

                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(1, "0", "")
                    'JAN_CODE_T.Text = ""
                    'DISPLAY_T.Text = 0
                    'CNT_T.Text = 1
                    Exit Sub
                End If

                'ラインディスプレー表示
                'LINE_DISPLAY(D_READ)

                D_MODE = 1
                S_MODE = 1

        End Select

        totalReturnPrice = 0
        totalReturnRowCount = 0

        '返品明細の更新
        For i = 0 To MEISAI_V.RowCount - 1
            mCnt = 0
            DisCountPrice = 0
            mCnt = CInt(MEISAI_V("数量", i).Value)

            If MEISAI_V("商品コード", i).Value = pSubTrn(0).sProductCode And mCnt > 0 Then
                MEISAI_V.Rows(i).DefaultCellStyle.ForeColor = Color.Red



                '2019.10.26 R.Takashima From
                'pCntはメソッド最初のほうでテキストボックスのカウントを取っているので
                '返品数だと思われる。
                'mCntは購入されている商品数
                If mCnt <= pCnt Then
                    pCnt = mCnt
                    '返品後の数量
                    MEISAI_V("数量", i).Value = 0
                Else
                    '返品後の数量
                    MEISAI_V("数量", i).Value = mCnt - pCnt
                End If

                MEISAI_V("返金額", i).Value = MEISAI_V("販売価格", i).Value * pCnt

                For j = i + 1 To MEISAI_V.RowCount - 1 Step 1
                    If MEISAI_V("商品名称", j).Value = "(会員値引き)" Or
                       MEISAI_V("商品名称", j).Value = "(値引き)" Or
                       MEISAI_V("商品名称", j).Value = "(ポイント値引き)" Then

                        MEISAI_V.Rows(j).DefaultCellStyle.ForeColor = Color.Red

                        DisCountPrice = MEISAI_V("値引き", j).Value * MEISAI_V("返金額", i).Value / MEISAI_V("金額", i).Value
                        MEISAI_V("返金額", j).Value = DisCountPrice * -1
                    Else
                        i = j - 1
                        Exit For
                    End If
                Next



                '2019.10.26 R.Takashima From
                'ここの計算は税抜き計算と税込計算が混ざっており若干の誤差が出ている

                'この処理は全てコメントアウトする
                'If mCnt <= pCnt Then

                '    MEISAI_V("数量", i).Value = 0
                '    MEISAI_V("返金額", i).Value = MEISAI_V("返金額", i).Value + CLng(MEISAI_V("金額", i).Value)

                '    '2016.06.08 K.Oikawa s
                '    '課代表.No102 返品モードで伝票情報を画面にセットする処理で
                '    '商品だけのような場合にエラーとなるので修正
                '    'For j = i + 1 To 100
                '    For j = i + 1 To MEISAI_V.RowCount - 1
                '        '2016.06.08 K.Oikawa e

                '        '2016.06.28 K.Oikawa s
                '        'ポイント値引きが含まれていない
                '        'If MEISAI_V("商品名称", j).Value = "(会員値引き)" Or MEISAI_V("商品名称", j).Value = "(値引き)" Then
                '        If MEISAI_V("商品名称", j).Value = "(会員値引き)" Or MEISAI_V("商品名称", j).Value = "(値引き)" Or MEISAI_V("商品名称", j).Value = "(ポイント値引き)" Then
                '            '2016.06.28 K.Oikawa e

                '            MEISAI_V.Rows(j).DefaultCellStyle.ForeColor = Color.Red

                '            MEISAI_V("返金額", j).Value = (MEISAI_V("返金額", j).Value + CLng(MEISAI_V("値引き", j).Value)) * -1
                '        Else
                '            i = j + 1
                '            Exit For
                '        End If
                '    Next j
                'Else
                '    MEISAI_V("数量", i).Value = mCnt - pCnt
                '    MEISAI_V("返金額", i).Value = MEISAI_V("返金額", i).Value + (CLng(MEISAI_V("販売価格", i).Value) * pCnt)

                '    '2016.06.08 K.Oikawa s
                '    '課代表.No102 返品モードで伝票情報を画面にセットする処理で
                '    '商品だけのような場合にエラーとなるので修正
                '    'For j = i + 1 To 100
                '    For j = i + 1 To MEISAI_V.RowCount - 1
                '        '2016.06.08 K.Oikawa e

                '        '2016.06.28 K.Oikawa s
                '        'ポイント値引きが含まれていない
                '        'If MEISAI_V("商品名称", j).Value = "(会員値引き)" Or MEISAI_V("商品名称", j).Value = "(値引き)" Then
                '        If MEISAI_V("商品名称", j).Value = "(会員値引き)" Or MEISAI_V("商品名称", j).Value = "(値引き)" Or MEISAI_V("商品名称", j).Value = "(ポイント値引き)" Then
                '            '2016.06.28 K.Oikawa e

                '            MEISAI_V.Rows(j).DefaultCellStyle.ForeColor = Color.Red
                '            DisCountPrice = CLng(MEISAI_V("値引き", j).Value)
                '            MEISAI_V("値引き", j).Value = (pSubTrn(0).sUnitPrice * pCnt) * (DisCountPrice / (oSubTrn(0).sPrice))

                '            MEISAI_V("返金額", j).Value = (MEISAI_V("返金額", j).Value + CLng(MEISAI_V("値引き", j).Value)) * -1
                '        Else
                '            i = j + 1
                '            Exit For
                '        End If
                '    Next j
                'End If
                'pCnt = pCnt - mCnt
                'If pCnt = 0 Then
                '    Exit For
                'End If

                '2019.10.26 R.Takashima To


                '2019.10.26 R.Takashima
                '総返金額
            ElseIf MEISAI_V("商品名称", i).Value = "(合計値引き)" Then
                totalReturnRowCount = i
                For j = 0 To MEISAI_V.RowCount - 1
                    If IsNothing(MEISAI_V("返金額", j).Value) <> True And MEISAI_V("商品名称", j).Value <> "(合計値引き)" Then
                        totalReturnPrice += MEISAI_V("返金額", j).Value
                    End If
                Next
            End If
        Next

        '総合計値引き返金額
        '
        '単品値引きなどを含んだ総返金額     *      合計値引き額
        '-------------------------------------------------------
        '            合計値引きを除いた総合計金額

        If totalReturnPrice > 0 And totalReturnRowCount > 0 Then
            MEISAI_V("返金額", totalReturnRowCount).Value = (
                totalReturnPrice * MEISAI_V("値引き", totalReturnRowCount).Value /
                (oTrn(0).sTotalPrice + MEISAI_V("値引き", totalReturnRowCount).Value) * -1
                )

        End If

        GOUKEI_B.Enabled = True
        MEISAI_V.CurrentCell = Nothing

        SUM_DISPLAY()

    End Sub
    Private Function TRN_SEARCH(ByVal pTrnCode As String) As Boolean
        Dim recCount As Long
        Dim message_form As cMessageLib.fMessage

        ReDim oTrn(0)
        recCount = oDataTrnDBIO.getTrn(oTrn, pTrnCode.ToString.Substring(3, 9), CHANNEL_CODE, Nothing, Nothing, Nothing, oTran)
        If recCount = 0 Then
            message_form = New cMessageLib.fMessage(1, "取引コードが登録されていません。",
                                                  "取引コードを確認して下さい。",
                                                  "",
                                                  "")
            message_form.ShowDialog()
            message_form = Nothing
            TRN_SEARCH = False
            Exit Function
        End If

        '2016.07.04 K.Oikawa s
        If R_MODE = True Then
            '伝票再発行モード
            Return True
        End If
        '2016.07.04 K.Oikawa e

        message_form = New cMessageLib.fMessage(2,
                                  "取引データの修正モードに移行します。",
                                  "よろしいですか？",
                                  Nothing, Nothing)

        '2016.06.16 K.Oikawa s
        '課代表.No76 無限ループの原因となるのでここで消す
        JAN_CODE_T.Text = ""
        '2016.06.16 K.Oikawa e

        message_form.ShowDialog()
        If message_form.DialogResult = Windows.Forms.DialogResult.No Then
            TRN_SEARCH = False
        Else
            TRN_SEARCH = True
        End If
        message_form = Nothing


    End Function
    Private Function MEMBER_SEARCH(ByVal pMemberCode As String) As Boolean
        Dim message_form As cMessageLib.fMessage

        Select Case oMstMemberDBIO.getMemberStatus(pMemberCode, oTran)
            Case -1     '無効会員
                message_form = New cMessageLib.fMessage(1, "",
                                                "会員カードが無効です。",
                                                "契約期間を確認して下さい。",
                                                "")
                message_form.ShowDialog()
                message_form = Nothing
                MEMBER_SEARCH = False
                Exit Function
            Case -2     '登録なし
                message_form = New cMessageLib.fMessage(1, "",
                                                "会員コードが登録されていません。",
                                                "",
                                                "")
                message_form.ShowDialog()
                message_form = Nothing
                MEMBER_SEARCH = False
                Exit Function
        End Select

        MEMBER_SEARCH = True

    End Function
    Private Function POINT_MEMBER_SEARCH(ByVal pPointMemberCode As String) As Boolean
        Dim message_form As cMessageLib.fMessage

        Select Case oMstPointMemberDBIO.getPointMemberStatus(pPointMemberCode, oTran)
            Case -1
                message_form = New cMessageLib.fMessage(1, "",
                                        "ポイント会員カードが無効です。",
                                        "契約期間を確認して下さい。",
                                        "")
                message_form.ShowDialog()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
            Case -2
                message_form = New cMessageLib.fMessage(1, "ポイント会員コードが登録されていません。",
                       "ポイント会員カードが有効か確認して下さい。",
                       "",
                       "")
                message_form.ShowDialog()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
            Case -3
                message_form = New cMessageLib.fMessage(1, "ポイント会員コードが登録されていません。",
                         "ポイント会員カードが有効か確認して下さい。",
                         "",
                         "")
                message_form.ShowDialog()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
        End Select

        POINT_MEMBER_SEARCH = True
    End Function
    Private Function TRN_SET(ByRef pTrn() As cStructureLib.sTrn) As Boolean
        Dim pSubTrn() As cStructureLib.sSubTrn
        Dim rSubTrn() As cStructureLib.sSubTrn
        Dim RecordCnt1 As Integer
        Dim RecordCnt2 As Integer
        Dim i As Integer
        Dim j As Integer
        'Dim opt As String
        'Dim pJanCode As String
        'Dim pProductName As String
        Dim pMemo As String


        '2016.07.04 K.Oikawa s
        'VALUE_INIT(5)
        If R_MODE = True Then
            VALUE_INIT(0)
        Else
            VALUE_INIT(5)
        End If
        '2016.07.04 K.Oikawa e

        OLDTRNCODE = pTrn(0).sTrnCode

        MEISAI_V.RowHeadersDefaultCellStyle.BackColor = Color.Red

        '2019.10.10 R.Takashima
        SET_TEXT_ABOVE_WINDOW(CNT_T.Text, pTrn(0).sTotalPrice)
        'DISPLAY_T.Text = pTrn(0).sTotalPrice

        ReDim pSubTrn(0)
        RecordCnt1 = oSubDataTrnDBIO.getSubTrn(pSubTrn, pTrn(0).sTrnCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        For i = 0 To RecordCnt1 - 1
            SUBTRNCLASS = pSubTrn(i).sSubTrnClass
            Select Case SUBTRNCLASS
                Case M_SALE
                Case M_DISCOUNT_U   '単品値引の場合
                    DISCOUNT_CASH = pSubTrn(i).sPrice * -1
                Case M_POSTAGE   '送料の場合
                    POSTAGE_CASH = pSubTrn(i).sPrice
                Case M_FEE   '手数料の場合
                    FEE_CASH = pSubTrn(i).sPrice
                Case M_DISCOUNT_M   '会員値引の場合
                    DISCOUNT_CASH = pSubTrn(i).sPrice * -1
                Case M_DISCOUNT_P   'ポイント値引の場合
                    POINT_CASH = pSubTrn(i).sPrice * -1
                Case M_DISCOUNT_C   'チケット値引の場合
                    TICKET_CASH = pSubTrn(i).sPrice * -1
                Case M_DISCOUNT_T   '合計値引の場合
                    DISCOUNT_CASH = pSubTrn(i).sPrice * -1
            End Select
            DAY_SUBTRN_DISPLAY(pSubTrn(i), Nothing)
        Next

        '会員情報セット
        If pTrn(0).sMemberCode <> "" Then
            If MEMBER_SEARCH(pTrn(0).sMemberCode) = False Then
                JAN_CODE_T.Text = ""
                JAN_CODE_T.Focus()
                Exit Function
            Else
                '会員設定
                MEMBER_SET(pTrn(0).sMemberCode)

            End If
        End If

        'ポイント会員情報セット
        If pTrn(0).sPointMemberCode <> "" Then
            If POINT_MEMBER_SEARCH(pTrn(0).sPointMemberCode) = False Then
                JAN_CODE_T.Text = ""
                JAN_CODE_T.Focus()
                Exit Function
            Else
                'ポイント会員設定
                POINT_MEMBER_SET(pTrn(0).sPointMemberCode)

            End If
        End If

        '既返品分の更新
        For i = 0 To MEISAI_V.RowCount - 1
            pMemo = ""
            pMemo = MEISAI_V("取引コード", i).Value.ToString & "-" & MEISAI_V("取引明細コード", i).Value.ToString
            ReDim rSubTrn(0)
            RecordCnt2 = oSubDataTrnDBIO.getSubTrn(rSubTrn, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, pMemo, oTran)
            If RecordCnt2 = 0 Then
                MEISAI_V.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            Else
                MEISAI_V.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If
            For j = 0 To RecordCnt2 - 1
                Select Case MEISAI_V("商品名称", i).Value
                    Case "(送料)"
                        'MEISAI_V("金額", i).Value = CInt(MEISAI_V("金額", i).Value) + rSubTrn(j).sPrice
                    Case "(手数料)"
                        'MEISAI_V("金額", i).Value = CInt(MEISAI_V("金額", i).Value) + rSubTrn(j).sPrice
                    Case "(単品値引き)"
                        'MEISAI_V("値引き", i).Value = CInt(MEISAI_V("値引き", i).Value) - rSubTrn(j).sPrice
                    Case "(合計値引き)"
                        'MEISAI_V("値引き", i).Value = CInt(MEISAI_V("値引き", i).Value) - rSubTrn(j).sPrice
                    Case "(会員値引き)"
                        'MEISAI_V("値引き", i).Value = CInt(MEISAI_V("値引き", i).Value) - rSubTrn(j).sPrice
                    Case "(ポイント値引き)"
                        'MEISAI_V("値引き", i).Value = CInt(MEISAI_V("値引き", i).Value) - rSubTrn(j).sPrice
                    Case "(チケット値引き)"
                        'MEISAI_V("値引き", i).Value = CInt(MEISAI_V("値引き", i).Value) - rSubTrn(j).sPrice
                    Case Else
                        MEISAI_V("数量", i).Value = CInt(MEISAI_V("数量", i).Value) + rSubTrn(j).sCount
                        'MEISAI_V("金額", i).Value = CInt(MEISAI_V("金額", i).Value) + rSubTrn(j).sPrice
                End Select
            Next
        Next

        MEISAI_V.ResumeLayout()

        MEISAI_V.CurrentCell = Nothing

        TRNCODE = oTrn(0).sTrnCode

        SUM_DISPLAY()

        JAN_CODE_T.Text = ""
        JAN_CODE_T.Focus()
    End Function
    Private Sub MEMBER_SET(ByVal pMemberCode As String)
        Dim RecordCnt As Long

        ReDim oMember(0)
        RecordCnt = oMstMemberDBIO.getMember(oMember, pMemberCode, Nothing, Nothing, True, oTran)

        MEMBER_CODE = pMemberCode
        MEMBER_CODE_T.Text = pMemberCode
        MEMBER_NAME_T.Text = oMember(0).sMemberName

        '会員LEDの表示切換え
        LED_CHANGE()

    End Sub
    Private Sub POINT_MEMBER_SET(ByVal pPointMemberCode As String)
        Dim RecordCnt As Long
        Dim message_form As cMessageLib.fMessage

        ReDim oPointMember(0)
        RecordCnt = oMstPointMemberDBIO.getPointMember(oPointMember, pPointMemberCode, pPointMemberCode, Nothing, Nothing, Nothing, oTran)

        '2016.06.28 K.Oikawa s
        '課代表No118 直接ポイントを入力してポイント会員の選択をせずに「完了」するとエラー
        '有効期限が設定されていない場合は空文字（「"0000/00/00"」はどのような場合に入ってくるのか確認する）
        '一先ず空文字の場合に有効期限の確認を行わないよう修正する
        'If oPointMember(0).sResignDate <> "0000/00/00" Then
        If oPointMember(0).sResignDate <> "0000/00/00" And oPointMember(0).sResignDate <> "" Then
            '2016.06.28 K.Oikawa e

            '課代表No118 直接ポイントを入力してポイント会員の選択をせずに「完了」するとエラー
            '呼び元で対応
            '通常の方法で読み込んでもエラー
            If CDate(oPointMember(0).sResignDate) < CDate(String.Format("{0:yyyy/MM/dd}", Now)) Then
                message_form = New cMessageLib.fMessage(1,
                                                 "ポイントカードの有効期限が切れています。",
                                                 "カードを確認して下さい。",
                                                 Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                VALUE_INIT(4)
                Exit Sub
            End If
        End If

        'ポイント会員の保有ポイント数取得
        POINT_i = oDataPointDBIO.getPoint(pPointMemberCode, oTran)

        POINT_MEMBER_CODE = pPointMemberCode
        POINT_MEMBER_CODE_T.Text = pPointMemberCode
        POINT_MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName

        '会員LEDの表示切換え
        LED_CHANGE()


    End Sub

    Private Sub MEISAI_UPDATE()
        Dim i As Integer
        Dim pMeisai() As cStructureLib.sViewMeisai
        Dim ret As Integer
        Dim pgMode As Boolean

        'キー入力音出力
        oTool.PlaySound()

        If MEISAI_V.Rows.Count = 0 Then
            Exit Sub
        End If

        '日次取引明細データの削除
        oSubDataTrnDBIO.deleteSubTrn(TRNCODE, Nothing, Nothing, oTran)

        ReDim pMeisai(0)

        '明細エイアの退避
        For i = 0 To MEISAI_V.Rows.Count - 1
            ReDim Preserve pMeisai(i)
            pMeisai(i).sJANCode = MEISAI_V("JANコード", i).Value
            pMeisai(i).sProductCode = MEISAI_V("商品コード", i).Value
            pMeisai(i).sProductName = MEISAI_V("商品名称", i).Value
            pMeisai(i).sOption = MEISAI_V("オプション", i).Value
            If MEISAI_V("定価", i).Value.ToString = "" Then
                pMeisai(i).sPrice = 0
            Else
                pMeisai(i).sPrice = MEISAI_V("定価", i).Value
            End If
            If MEISAI_V("販売価格", i).Value.ToString = "" Then
                pMeisai(i).sSale_Price = 0
            Else
                pMeisai(i).sSale_Price = MEISAI_V("販売価格", i).Value
            End If
            If MEISAI_V("数量", i).Value.ToString = "" Then
                pMeisai(i).sCnt = 0
            Else
                pMeisai(i).sCnt = MEISAI_V("数量", i).Value
            End If
            If MEISAI_V("金額", i).Value.ToString = "" Then
                pMeisai(i).sTPrice = 0
            Else
                pMeisai(i).sTPrice = MEISAI_V("金額", i).Value
            End If
            If MEISAI_V("値引き", i).Value.ToString = "" Then
                pMeisai(i).sDPrice = 0
            Else
                pMeisai(i).sDPrice = MEISAI_V("値引き", i).Value
            End If
            pMeisai(i).sTrnCode = MEISAI_V("取引コード", i).Value
            pMeisai(i).sSubTrnCode = MEISAI_V("取引明細コード", i).Value
        Next

        '合計モードの退避
        pgMode = G_MODE

        '変数初期化
        VALUE_INIT(0)

        '明細エリアリメイク
        For i = 0 To pMeisai.Length - 1
            Select Case pMeisai(i).sJANCode
                Case "(値引き)"
                    SUBTRNCLASS = M_DISCOUNT_U
                    D_MODE = 1
                    If pMeisai(i).sProductCode = "\" Then
                        DISPLAY_T.Text = pMeisai(i).sDPrice
                        DISCOUNT_PROC(DISCOUNT_K)
                    Else
                        DISPLAY_T.Text = pMeisai(i).sProductName
                        DISCOUNT_PROC(DISCOUNT_R)
                    End If
                Case "(合計値引き)"
                    SUBTRNCLASS = M_DISCOUNT_T
                    DISPLAY_T.Text = pMeisai(i).sDPrice
                    If pMeisai(i).sProductCode = "\" Then
                        DISCOUNT_PROC(DISCOUNT_K)
                    Else
                        DISCOUNT_PROC(DISCOUNT_R)
                    End If
                Case "(会員値引き)"
                    'If MEMBER_CODE <> "" Then
                    '    SUBTRNCLASS = M_DISCOUNT_M
                    '    UPRICE = pMeisai(i).sSale_Price
                    '    UCOUNT = pMeisai(i).scnt
                    '    DISPLAY_T.Text = pMeisai(i).sTPrice

                    '    ret = CAL_PROC(Nothing)      '集計（カテゴリ番号）

                    '    '日次取引明細データ更新
                    '    DAY_SUBTRN_INSERT()

                    '    '明細行の表示
                    '    ret = DAY_SUBTRN_DISPLAY(oSubTrn, Nothing)

                    '    '集計エリア表示
                    '    SUM_DISPLAY()
                    'End If
                Case "(送料)"
                    SUBTRNCLASS = M_POSTAGE
                    DISPLAY_T.Text = pMeisai(i).sTPrice
                    OTHER_PROC(POSTAGE)
                Case "(手数料)"
                    SUBTRNCLASS = M_FEE
                    DISPLAY_T.Text = pMeisai(i).sTPrice
                    OTHER_PROC(FEE)
                Case "(ポイント値引き)"
                    If POINT_MEMBER_CODE <> "" Then
                        SUBTRNCLASS = M_DISCOUNT_P
                        UPRICE = pMeisai(i).sSale_Price
                        UCOUNT = pMeisai(i).sCnt
                        DISPLAY_T.Text = pMeisai(i).sTPrice

                        ret = CAL_PROC(Nothing)      '集計（カテゴリ番号）

                        '日次取引明細データ更新
                        DAY_SUBTRN_INSERT(DISCOUNT_K, POINT_CASH)

                        '明細行の表示
                        ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), Nothing)

                        '集計エリア表示
                        SUM_DISPLAY()
                    End If
                Case Else
                    SUBTRNCLASS = M_SALE
                    UPRICE = pMeisai(i).sSale_Price
                    UCOUNT = pMeisai(i).sCnt
                    DISPLAY_T.Text = pMeisai(i).sTPrice

                    ret = CAL_PROC(Nothing)      '集計（カテゴリ番号）

                    oMstProductDBIO.getProductSalePrice(oProductSalePrice, CHANNEL_CODE, pMeisai(i).sProductCode, Nothing, oTran)
                    PRODUCT_SET(oProductSalePrice(0))


                    '日次取引明細データ更新
                    DAY_SUBTRN_INSERT(Nothing, Nothing)

                    '明細行の表示
                    ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), Nothing)

                    '集計エリア表示
                    SUM_DISPLAY()

                    '会員値引き追加
                    Select Case pMeisai(i).sJANCode
                        Case "(値引き)"
                        Case "(合計値引き)"
                        Case "(会員値引き)"
                        Case Else
                            '会員割引率が0以外の場合
                            oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                            If oServiceRate(0).sRate <> 0 Then

                                '取引明細番号インクリメント
                                SUB_TRNCODE = SUB_TRNCODE + 1

                                '割引率を画面セット
                                oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                                DISPLAY_T.Text = oServiceRate(0).sRate

                                '入力中モードをセット
                                D_MODE = 1

                                '取引明細区分=値引きを設定
                                SUBTRNCLASS = M_DISCOUNT_M

                                DISCOUNT_PROC(DISCOUNT_R)
                            End If
                    End Select

            End Select
        Next

        '合計モードの復元
        G_MODE = pgMode
        GOUKEI_B.Enabled = True

        pMeisai = Nothing

        DISPLAY_CLR(0)

        '変数初期化
        If MEISAI_V.RowCount > 0 Then
            VALUE_INIT(1)
        Else
            VALUE_INIT(0)
        End If

        DISPLAY_T.Text = TBILL_T.Text.Replace(" ", "").Replace(",", "").Remove(0, 1)
        TOTAL_CASH = DISPLAY_T.Text

    End Sub

    '2019.10.5 R.Takashima
    'PRODUCT_SET
    'デザイン画面では返品処理中とある場所にテキストボックスがあり
    'このテキストボックスに商品詳細を入れている。
    Private Sub PRODUCT_SET(ByVal iProductSalePrice As cStructureLib.sViewProductSalePrice)
        '2019.10.5 R.Takashima From
        Dim tax As Long
        '2019.10.5 R.Takashima To
        Dim pStock() As cStructureLib.sStock


        PRODUCT_CODE_T.Text = iProductSalePrice.sProductCode
        PRODUCT_NAME_T.Text = iProductSalePrice.sProductShortName

        If iProductSalePrice.sOption1 <> "" Then
            OPTION_1_T.Text = iProductSalePrice.sOption1
        Else
            OPTION_1_T.Text = ""
        End If

        If iProductSalePrice.sOption2 <> "" Then
            OPTION_2_T.Text = iProductSalePrice.sOption2
        Else
            OPTION_2_T.Text = ""
        End If
        If iProductSalePrice.sOption3 <> "" Then
            OPTION_3_T.Text = iProductSalePrice.sOption3
        Else
            OPTION_3_T.Text = ""
        End If
        If iProductSalePrice.sOption4 <> "" Then
            OPTION_4_T.Text = iProductSalePrice.sOption4
        Else
            OPTION_4_T.Text = ""
        End If
        If iProductSalePrice.sOption5 <> "" Then
            OPTION_5_T.Text = iProductSalePrice.sOption5
        Else
            OPTION_5_T.Text = ""
        End If

        '2019.10.5 R.Takashima
        'PRICE_T：定価       SALE_PRICE_T：販売価格     TAX_PRICE_T.Text：税額
        '軽減税率の項目を追加
        If iProductSalePrice.sReducedTaxRate = True Then '軽減税率対象商品のとき
            tax = REDUCE_TAX
        Else                                             '軽減税率対象外のとき
            tax = oConf(0).sTax
        End If

        PRICE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(iProductSalePrice.sListPrice, tax, oConf(0).sFracProc))
        SALE_PRICE_T.Text = String.Format("{0,9:C}", oTool.BeforeToAfterTax(iProductSalePrice.sSalePrice, tax, oConf(0).sFracProc))
        TAX_PRICE_T.Text = String.Format("{0,9:C}", oTool.BeforeToTax(iProductSalePrice.sSalePrice, tax, oConf(0).sFracProc))


        '2016.09.14 K.Oikawa s
        '課題表No.167 必ず社販扱いとなっている　社販の設定を別途設ける必要あり

        ''販売金額の算出
        'pSalePrice = oTool.BeforeToAfterTax(iProductSalePrice.sSalePrice, oConf(0).sTax, oConf(0).sFracProc)

        ''社販割引の計算
        'oStaffDBIO.getStaffFull(oStaffFull, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)
        'Select Case oConf(0).sFracProc  '端数処理
        '    Case 0  '四捨五入
        '        DISPLAY_T.Text = oTool.ToHalfAdjust(pSalePrice * (oStaffFull(0).sRate / 100), 0)
        '    Case 1  '切り捨て
        '        DISPLAY_T.Text = oTool.ToRoundDown(pSalePrice * (oStaffFull(0).sRate / 100), 0)
        '    Case 2  '切り上げ
        '        DISPLAY_T.Text = oTool.ToRoundUp(pSalePrice * (oStaffFull(0).sRate / 100), 0)
        'End Select

        '2019.10.10 R.Takashima FROM
        SET_TEXT_ABOVE_WINDOW(CNT_T.Text,
                              oTool.BeforeToAfterTax(iProductSalePrice.sSalePrice, tax, oConf(0).sFracProc),
                              oProductSalePrice(0).sJANCode)
        'DISPLAY_T.Text = oTool.BeforeToAfterTax(iProductSalePrice.sSalePrice, oConf(0).sTax, oConf(0).sFracProc)
        '2016.09.14 K.Oikawa e
        '2019.10.10 R.Takashima TO

        '在庫情報の取得
        ReDim pStock(0)
        oMstStockDBIO.getStock(pStock, iProductSalePrice.sProductCode, oTran)

        STOCK_CNT_T.Text = pStock(0).sStockCount

    End Sub

    '2016.09.14 K.Oikawa s
    '課題表No.163 以前使用したデータが残っている件で、残す必要のあった処理を切り分ける

    '2019.10.5 R.Takashima
    'グローバル変数アクセスをローカル変数にアクセスするように変更
    'Private Sub PRODUCT_SET_PROC(ByVal sender As Softgroup.NetButton.NetButton, ByVal BumonName As String)

    '2019 10.6 R.Takashima 
    '同じ動作をするメソッドがあったためPRODUCT_SET_PROCに統合した
    Private Sub PRODUCT_SET_PROC(ByVal sender As Softgroup.NetButton.NetButton, ByVal BumonName As String)

        Dim ret As Boolean
        Dim RecordCount As Integer

        'キー入力音出力
        oTool.PlaySound()

        If BumonName = Nothing Then
            BUMON_INDEX = BUMON_INDEX_GET(sender.TextButton)
        Else
            BUMON_INDEX = BUMON_INDEX_GET(BumonName)
        End If

        SUBTRNCLASS = 1

        '部門種別＝サービスの場合
        If BUMON_INDEX >= 0 Then
            If CLng(oBumon(BUMON_INDEX).sBumonCode) >= 9900000000000 Then
                RecordCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice,
                                                        CHANNEL_CODE,
                                                        Nothing,
                                                        oBumon(BUMON_INDEX).sBumonCode,
                                                        oTran)
                '商品が１つでもあったらウィンドウを表示させる
                'If RecordCount > 1 Then
                If RecordCount > 0 Then
                    Dim SelectJAN_form As New cSelectLib.fSelectJAN(oConn,
                                         oCommand,
                                         oDataReader,
                                         CHANNEL_CODE,
                                         oBumon(BUMON_INDEX).sBumonCode,
                                         oConf,
                                         oTran)
                    SelectJAN_form.ShowDialog()
                    If SelectJAN_form.DialogResult = Windows.Forms.DialogResult.OK Then
                        RecordCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice,
                                                                 CHANNEL_CODE,
                                                                 SelectJAN_form.PRODUCT_CODE_T.Text,
                                                                 Nothing,
                                                                 oTran)
                        '2019.11.15 R.Takashima From
                        '戻るボタン押下の処理を追加
                    ElseIf SelectJAN_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        '変数初期化
                        VALUE_INIT(1)

                        'JANコードにセットフォーカス
                        JAN_CODE_T.Focus()

                        '初期化をする
                        ReDim oProductSalePrice(0)
                        Exit Sub
                        '2019.11.15 R.Takashima To
                    Else
                        Dim message_form As New cMessageLib.fMessage(1,
                                          "対象商品が登録されていません",
                                          "価格を入力して下さい",
                                          Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing

                        '変数初期化
                        VALUE_INIT(1)

                        'JANコードにセットフォーカス
                        JAN_CODE_T.Focus()

                        Exit Sub
                    End If
                    SelectJAN_form = Nothing
                Else
                    '2019.11.15 R.Takashima From
                    '該当商品が見つからないときにメッセージを表示する
                    Dim message_form As New cMessageLib.fMessage(1,
                                          Nothing,
                                          "該当する商品がありません。",
                                          Nothing, Nothing)
                    message_form.ShowDialog()
                    message_form = Nothing

                    '変数初期化
                    VALUE_INIT(1)

                    'JANコードにセットフォーカス
                    JAN_CODE_T.Focus()

                    Exit Sub

                    '2019.11.15 R.Takashima To
                End If
            End If
        End If


        '選択商品情報を画面にセット
        If IsNothing(oProductSalePrice) = True Then
            ReDim oProductSalePrice(0)
        End If
        If oProductSalePrice(0).sProductCode = Nothing Then
            If D_MODE = 0 Then
                Exit Sub
            End If

            JAN_CODE_T.Text = ""
            PRODUCT_CODE_T.Text = ""
            PRODUCT_NAME_T.Text = sender.TextButton
            OPTION_1_T.Text = ""
            OPTION_2_T.Text = ""
            OPTION_3_T.Text = ""
            OPTION_4_T.Text = ""
            OPTION_5_T.Text = ""
            PRICE_T.Text = ""
            SALE_PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
        Else
            '2019.10.9 R.Takashima
            '商品情報をテキストボックスにセット
            PRODUCT_SET(oProductSalePrice(0))

        End If
        D_MODE = 1

        If Me.DISPLAY_T.Text = "0" Then  '未入力状態

            JAN_CODE_T.Focus()
            Beep()
            MSG_T.Text = "価格が入力されていません"
            Dim message_form As New cMessageLib.fMessage(1,
                                              "価格が入力されていません",
                                              "価格を入力して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        Else
            UPRICE = Me.DISPLAY_T.Text
            UCOUNT = Me.CNT_T.Text

            '2019.10.10 R.Takashima
            'D_MODE = 1がセットされているため、IF文はいらない
            'If D_MODE = 1 Then

            ret = CAL_PROC(Nothing)      '集計（カテゴリ番号）

            '日次取引明細データ更新
            DAY_SUBTRN_INSERT(Nothing, Nothing)

            '明細行の表示
            ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), Nothing)

            '集計エリア表示
            SUM_DISPLAY()

            'ラインディスプレー表示
            LINE_DISPLAY(D_READ)
            LINE_DISPLAY(D_KATEGORY)

            '商品価格表示セット
            '数量イニシャライズ
            SET_TEXT_ABOVE_WINDOW(1, UPRICE * UCOUNT)
            'Me.DISPLAY_T.Text = UPRICE * UCOUNT

            'CNT_T.Text = 1

            '入力モード=未入力状態をセット
            D_MODE = 0

            '会員割引設定
            If MEMBER_CODE_T.Text <> "" Then
                '会員割引率が0以外の場合
                oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                If IsNothing(oServiceRate) Then
                    ReDim oServiceRate(0)
                    oServiceRate(0).sRate = 0
                End If
                If oServiceRate(0).sRate <> 0 Then

                    '取引明細番号インクリメント
                    SUB_TRNCODE = SUB_TRNCODE + 1

                    '割引率を画面セット
                    oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)

                    '2019.10.10 R.Takashima
                    SET_TEXT_ABOVE_WINDOW(CNT_T.Text, oServiceRate(0).sRate)
                    'DISPLAY_T.Text = oServiceRate(0).sRate

                    '入力中モードをセット
                    D_MODE = 1

                    '取引明細区分=値引きを設定
                    SUBTRNCLASS = M_DISCOUNT_M

                    DISCOUNT_PROC(DISCOUNT_R)
                End If
            End If
            JAN_CODE_T.Focus()
            'End If

            '取引明細番号のインクリメント
            SUB_TRNCODE = SUB_TRNCODE + 1

            JAN_CODE_T.Text = ""

            TRN_CODE_T.Text = TRNCODE
            TRNSUB_CODE.Text = SUB_TRNCODE

        End If

        'バッファ初期化
        ReDim oProductSalePrice(0)

        '変数初期化
        VALUE_INIT(1)

        'JANコードにセットフォーカス
        JAN_CODE_T.Focus()

    End Sub
    '2016.09.14 K.Oikawa e

    Private Sub SUM_DISPLAY()
        Dim scount As Long
        Dim stotal As Long
        Dim sdiscount As Long
        Dim sbill As Long
        Dim tdiscount As Long
        Dim pdiscount As Long
        Dim cdiscount As Long
        Dim tdelivaly As Long
        Dim tfee As Long
        Dim tbill As Long

        '2019.10.17 R.Takashima FROM
        Dim tax As Integer

        '商品合計金額(割引なし)
        Dim sTotalTaxPrice As Long
        '割引税額合計
        Dim sDiscountTotalTax As Long
        '合計値引き税額
        Dim tDiscountTotalTax As Long

        Dim sumTax As Long
        Dim product As cStructureLib.sViewProductSalePrice()

        tax = oConf(0).sTax
        sTotalTaxPrice = 0
        sDiscountTotalTax = 0
        tDiscountTotalTax = 0
        sumTax = 0
        '2019.10.17 R.Takashima TO


        '購買状況表示用変数
        scount = 0
        stotal = 0
        sdiscount = 0
        sbill = 0
        '請求情報表示用変数
        tdiscount = 0
        pdiscount = 0
        cdiscount = 0
        tdelivaly = 0
        tfee = 0
        tbill = 0

        For i = 0 To MEISAI_V.Rows.Count - 1

            '値引き計算で小数が出る場合があるので全て切り捨てする。
            Select Case MEISAI_V("商品名称", i).Value.ToString
                Case "(値引き)"
                    If T_MODE <> 2 Then
                        sdiscount = sdiscount + MEISAI_V("値引き", i).Value      '単品値引き合計算出
                        '2019.10.27 R.Takashima 税別ごとに消費税のみの金額を算出
                        sDiscountTotalTax += oTool.AfterToTax(MEISAI_V("値引き", i).Value, tax, oConf(0).sFracProc)
                    Else
                        sdiscount = sdiscount + MEISAI_V("返金額", i).Value       '単品値引き合計算出（返品時）
                        '2019.10.27 R.Takashima 税別ごとに消費税のみの金額を算出
                        sDiscountTotalTax += oTool.AfterToTax(MEISAI_V("返金額", i).Value, tax, oConf(0).sFracProc)
                    End If
                Case "(会員値引き)"
                    If T_MODE <> 2 Then
                        sdiscount = sdiscount + MEISAI_V("値引き", i).Value       '単品値引き合計算出
                        '2019.10.27 R.Takashima 税別ごとに消費税のみの金額を算出
                        sDiscountTotalTax += oTool.AfterToTax(MEISAI_V("値引き", i).Value, tax, oConf(0).sFracProc)
                    Else
                        sdiscount = sdiscount + MEISAI_V("返金額", i).Value      '単品値引き合計算出（返品時）
                        '2019.10.27 R.Takashima 税別ごとに消費税のみの金額を算出
                        sDiscountTotalTax += oTool.AfterToTax(MEISAI_V("返金額", i).Value, tax, oConf(0).sFracProc)
                    End If
                Case "(合計値引き)"
                    If T_MODE <> 2 Then
                        tdiscount = tdiscount + MEISAI_V("値引き", i).Value       '合計値引き合計算出
                    Else
                        tdiscount = tdiscount + MEISAI_V("返金額", i).Value       '合計値引き合計算出（返品時）
                    End If
                Case "(ポイント値引き)"
                    If T_MODE <> 2 Then
                        pdiscount = pdiscount + MEISAI_V("値引き", i).Value     'ポイント値引き合計算出
                    Else
                        pdiscount = pdiscount + MEISAI_V("返金額", i).Value        'ポイント値引き合計算出（返品時）
                    End If
                Case "(チケット値引き)"
                    If T_MODE <> 2 Then
                        cdiscount = cdiscount + MEISAI_V("値引き", i).Value        'チケット値引き合計算出
                    Else
                        cdiscount = cdiscount + MEISAI_V("返金額", i).Value        'チケット値引き合計算出（返品時）
                    End If
                Case "(送料)"
                    If T_MODE <> 2 Then
                        tdelivaly = tdelivaly + MEISAI_V("金額", i).Value           '送料合計算出
                    Else
                        tdelivaly = tdelivaly + MEISAI_V("返金額", i).Value           '送料合計算出（返品時）
                    End If
                Case "(手数料)"
                    If T_MODE <> 2 Then
                        tfee = tfee + MEISAI_V("金額", i).Value                     '手数料合計算出
                    Else
                        tfee = tfee + MEISAI_V("返金額", i).Value                     '手数料合計算出（返品時）
                    End If
                Case Else

                    '2019.10.17 R.Takashima
                    '軽減税率判別のために商品データを取得
                    ReDim product(0)
                    oMstProductDBIO.getProductSalePrice(product,
                                                CHANNEL_CODE,
                                                MEISAI_V("商品コード", i).Value,
                                                MEISAI_V("JANコード", i).Value,
                                                oTran
                                                )
                    If product(0).sReducedTaxRate = True Then
                        tax = REDUCE_TAX
                    Else
                        tax = oConf(0).sTax
                    End If
                    '2019.10.17 R.Takashima

                    If T_MODE <> 2 Then

                        If MEISAI_V("数量", i).Value <> 0 Then
                            scount = scount + CInt(MEISAI_V("数量", i).Value)                 '数量合計算出
                        End If
                        If MEISAI_V("金額", i).Value <> 0 Then

                            '2019.10.17 R.Takashima FROM
                            '税別ごとに税額を算出し合計税額に入れていく
                            sTotalTaxPrice += oTool.AfterToTax(MEISAI_V("金額", i).Value, tax, oConf(0).sFracProc)
                            '2019.10.17 R.Takashima TO

                            stotal = stotal + CLng(MEISAI_V("金額", i).Value)                 '単価合計算出
                        End If
                    Else
                        If (CLng(MEISAI_V("返金額", i).Value) / CLng(MEISAI_V("販売価格", i).Value)) <> 0 Then
                            scount = scount + (CLng(MEISAI_V("返金額", i).Value) / CLng(MEISAI_V("販売価格", i).Value))             '数量合計算出
                        End If
                        If MEISAI_V("返金額", i).Value <> 0 Then

                            '2019.10.17 R.Takashima FROM
                            '税別ごとに税額を算出し合計税額に入れていく
                            sTotalTaxPrice += oTool.AfterToTax(MEISAI_V("返金額", i).Value, tax, oConf(0).sFracProc)
                            '2019.10.17 R.Takashima TO

                            stotal = stotal + CLng(MEISAI_V("返金額", i).Value)                 '単価合計算出
                        End If
                    End If
            End Select
        Next i

        '2019.10.30 R.Takashima 
        '合計値引き時は按分する
        If tdiscount > 0 Then
            Dim reducetax As Long = 0
            Dim normaltax As Long = 0

            For i = 0 To MEISAI_V.RowCount - 1
                If MEISAI_V("金額", i).Value > 0 And IsNothing(MEISAI_V("金額", i).Value) = False Then
                    ReDim product(0)
                    If oMstProductDBIO.getProductSalePrice(product,
                                                        CHANNEL_CODE,
                                                        MEISAI_V("商品コード", i).Value,
                                                        MEISAI_V("JANコード", i).Value,
                                                        oTran
                                                        ) > 0 Then

                        If product(0).sReducedTaxRate = True Then
                            reducetax += MEISAI_V("金額", i).Value / stotal * tdiscount
                        Else
                            normaltax += MEISAI_V("金額", i).Value / stotal * tdiscount
                        End If
                    End If
                End If
            Next

            tDiscountTotalTax += oTool.AfterToTax(reducetax, REDUCE_TAX, oConf(0).sFracProc)
            tDiscountTotalTax += oTool.AfterToTax(normaltax, oConf(0).sTax, oConf(0).sFracProc)
        End If


        '2016.06.28 K.Oikawa s
        '課題表No125 返品モードの値引き額はマイナスで入ってくる
        'sbill = stotal - sdiscount                                              '合計金額算出
        'tbill = sbill + tdelivaly + tfee - tdiscount - pdiscount - cdiscount    '請求金額算出
        If T_MODE <> 2 Then
            sbill = stotal - sdiscount                                              '合計金額算出
            tbill = sbill + tdelivaly + tfee - tdiscount - pdiscount - cdiscount    '請求金額算出

            '2019.10.17 R.Takashima FROM
            sDiscountTotalTax *= -1

            sumTax = sTotalTaxPrice + sDiscountTotalTax - tDiscountTotalTax - oTool.AfterToTax(pdiscount + cdiscount,
                                             oConf(0).sTax, oConf(0).sFracProc)     '合計税額
            '2019.10.17 R.Takashima TO

        Else
            sbill = stotal + sdiscount                                              '合計金額算出
            tbill = sbill + tdelivaly + tfee + tdiscount + pdiscount + cdiscount    '請求金額算出

            '2019.10.17 R.Takashima FROM
            sDiscountTotalTax *= -1

            sumTax = sTotalTaxPrice - sDiscountTotalTax + tDiscountTotalTax + oTool.AfterToTax(pdiscount + cdiscount,
                                             oConf(0).sTax, oConf(0).sFracProc)     '合計税額
            '2019.10.17 R.Takashima TO

        End If
        '2016.06.28 K.Oikawa e

        If tbill < 0 Then
            tbill = 0
        End If


        '請求情報表示用変数
        Me.STOTAL_T.Text = String.Format("{0,9:C}", stotal)             '商品代金画面セット
        Me.SCOUNT_T.Text = String.Format("{0,9:#,##0}", scount)         '数量画面セット
        Me.SDISCOUNT_T.Text = String.Format("{0,9:C}", sdiscount)       '値引き画面セット

        '2016.06.02 K.Oikawa s
        '課代表.No90 税抜き金額を表示すべき箇所に税込み金額が表示されていたので修正
        'Me.SBILL_T.Text = String.Format("{0,9:C}", sbill)               '金額画面セット

        '2019.10.17 R.Takashima FROM
        'Me.SBILL_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(sbill, oConf(0).sTax, oConf(0).sFracProc))               '金額画面セット
        Me.SBILL_T.Text = String.Format("{0,9:C}", sbill - (sTotalTaxPrice + sDiscountTotalTax))
        '2019.10.17 R.Takashima TO

        '2016.06.02 K.Oikawa e

        Me.TDISCOUNT_T.Text = String.Format("{0,9:C}", tdiscount)       '合計値引き画面セット
        Me.PDISCOUNT_T.Text = String.Format("{0,9:C}", pdiscount)       'ポイント値引き画面セット
        Me.CDISCOUNT_T.Text = String.Format("{0,9:C}", cdiscount)       'チケット値引き画面セット
        Me.TDELIVALY_T.Text = String.Format("{0,9:C}", tdelivaly)       '送料画面セット
        Me.TFEE_T.Text = String.Format("{0,9:C}", tfee)                 '手数料画面セット
        Me.TBILL_T.Text = String.Format("{0,9:C}", tbill)               '請求金額画面セット

        '2019.10.17 R.Takashima FROM
        'Me.TTAX_T.Text = String.Format("{0,9:C}", oTool.AfterToTax(tbill, oConf(0).sTax, oConf(0).sFracProc))      '消費税画面セット
        Me.TTAX_T.Text = String.Format("{0,9:C}", sumTax)
        '2019.10.17 R.Takashima TO

    End Sub


    '**************************************************
    '画面を初期状態に戻す
    '[引数]
    '   Mode    "MEMBER"    ：会員情報エリア    
    '           "REG"       ：レジ表示エリア
    '　　　　　 "PRODUCT"　 ：商品情報表示エリア
    '           "SUM"       ：集計値表示エリア
    '**************************************************
    Private Sub DISP_INIT(ByVal Mode As String)
        Select Case Mode
            Case "MEMBER"
                MEMBER_CODE = ""
                MEMBER_CODE_T.Text = ""
                MEMBER_NAME_T.Text = ""

                POINT_MEMBER_CODE = ""
                POINT_MEMBER_CODE_T.Text = ""
                POINT_MEMBER_NAME_T.Text = ""

                USE_POINT_i = 0
                ADD_POINT_i = 0
                POINT_i = 0

                '会員LEDの表示切換え
                LED_CHANGE()
            Case "REG"
                '2019.10.10 R.Takashima
                SET_TEXT_ABOVE_WINDOW(1, "0", "")
                'DISPLAY_T.Text = 0
                'CNT_T.Text = 1
                'JAN_CODE_T.Text = ""
            Case "PRODUCT"
                PRODUCT_CODE_T.Text = ""
                PRODUCT_NAME_T.Text = ""
                OPTION_1_T.Text = ""
                OPTION_2_T.Text = ""
                OPTION_3_T.Text = ""
                OPTION_4_T.Text = ""
                OPTION_5_T.Text = ""
                PRICE_T.Text = ""
                SALE_PRICE_T.Text = ""
                TAX_PRICE_T.Text = ""
                STOCK_CNT_T.Text = ""
            Case "SUM"
                SCOUNT_T.Text = 0
                STOTAL_T.Text = 0
                SDISCOUNT_T.Text = 0
                SBILL_T.Text = 0

                TDISCOUNT_T.Text = 0
                TDELIVALY_T.Text = 0
                TFEE_T.Text = 0
                TBILL_T.Text = 0
                TTAX_T.Text = 0

                '2019.11.15 R.Takashima From
                'ポイント値引き、チケット値引きの値が初期化されていないため追加
                PDISCOUNT_T.Text = 0
                CDISCOUNT_T.Text = 0
                '2019.11.15 R.Takashima To
        End Select
    End Sub

    '**************************************************
    '計算処理
    '[引数]
    '   1  '売上明細区分＝売上
    '   2  '値引きモード
    '   3 '合計値引きモード
    '**************************************************
    Function CAL_PROC(ByVal Mode As String) As Boolean
        Dim INPUT As Long
        Dim oTool As cTool
        Dim i As Integer
        Dim ProductPrice As Long

        oTool = New cTool

        If D_MODE <> 0 Then     '1商品確定後、未入力の場合 D_MODE = 0
            Select Case SUBTRNCLASS
                Case M_SALE  '売上明細区分＝売上
                    UPRICE = DISPLAY_T.Text
                    INPUT = oTool.ToHalfAdjust(UPRICE * UCOUNT, 0)      '現在入力中の商品価格
                    TOTAL_CASH = TOTAL_CASH + INPUT                     '本商品までの合計金額を計算
                    DISCOUNT_CASH = 0                                   '値引き額の設定
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_DISCOUNT_U  '単品値引きモード
                    Select Case Mode
                        Case DISCOUNT_R     '％値引き
                            For i = MEISAI_V.RowCount - 1 To 0 Step -1

                                '2019.10.19 R.Takashima FROM
                                If IsNothing(MEISAI_V("JANコード", i).Value) = True Then
                                    Continue For
                                    '2019.10.19 R.Takashima TO
                                ElseIf MEISAI_V("JANコード", i).Value.ToString.Length > 1 Then
                                    ProductPrice = MEISAI_V("金額", i).Value
                                    Exit For
                                End If
                            Next i
                            DISCOUNT_RATE = CInt(DISPLAY_T.Text)        '値引率
                            INPUT = ProductPrice * (DISCOUNT_RATE / 100)
                            PRODUCT_NAME_T.Text = "％値引き(" & CInt(DISPLAY_T.Text) & "%)"
                        Case DISCOUNT_K         '金額値引き
                            INPUT = CInt(DISPLAY_T.Text)                '単品金額値引き
                            PRODUCT_NAME_T.Text = "金額値引き(" & CInt(DISPLAY_T.Text) & "円)"
                    End Select
                    UPRICE = UPRICE - INPUT
                    UDISCOUNT = INPUT                                   '単品値引き額
                    DISCOUNT_CASH = INPUT                               '値引金額
                    TOTAL_CASH = TOTAL_CASH - DISCOUNT_CASH             '本商品までの合計金額を計算
                    DISPLAY_T.Text = DISCOUNT_CASH                      '合計金額を画面に表示
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_POSTAGE  '送料モード
                    INPUT = CInt(DISPLAY_T.Text)                        '単品金額値引き
                    UPOSTAGE_CASH = INPUT                               '送料
                    TOTAL_CASH = TOTAL_CASH + INPUT                     '本商品までの合計金額を計算
                Case M_FEE  '手数料モード
                    INPUT = CInt(DISPLAY_T.Text)                        '単品金額値引き
                    UFEE_CASH = INPUT                                   '手数料
                    TOTAL_CASH = TOTAL_CASH + INPUT                     '本商品までの合計金額を計算
                Case M_DISCOUNT_M  '会員値引きモード
                    Select Case Mode
                        Case DISCOUNT_R     '％値引き
                            oMstServiceDBIO.getServiceRate(oServiceRate, oMember(0).sServiceCode, oBumon(BUMON_INDEX).sBumonCode, oTran)
                            DISCOUNT_RATE = oServiceRate(0).sRate        '値引率
                            INPUT = UPRICE * UCOUNT * (DISCOUNT_RATE / 100)
                            PRODUCT_NAME_T.Text = "％値引き(" & CInt(DISPLAY_T.Text) & "%)"
                        Case DISCOUNT_K         '金額値引き
                            INPUT = CInt(DISPLAY_T.Text)                '単品金額値引き
                            PRODUCT_NAME_T.Text = "金額値引き(" & CInt(DISPLAY_T.Text) & "円)"
                    End Select
                    UPRICE = UPRICE - INPUT
                    UDISCOUNT = INPUT                                   '単品値引き額
                    DISCOUNT_CASH = INPUT                               '値引金額
                    TOTAL_CASH = TOTAL_CASH - DISCOUNT_CASH             '本商品までの合計金額を計算
                    DISPLAY_T.Text = TOTAL_CASH                         '合計金額を画面に表示
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_DISCOUNT_P  'ポイント値引きモード
                    INPUT = CInt(DISPLAY_T.Text)                        '単品金額値引き
                    PRODUCT_NAME_T.Text = "ポイント値引き(" & CInt(DISPLAY_T.Text) & "円)"
                    TOTAL_CASH = TOTAL_CASH - INPUT                     '本商品までの合計金額を計算
                    If TOTAL_CASH < 0 Then
                        TOTAL_CASH = 0
                    End If
                    POINT_CASH = INPUT                                  'ポイント値引き額
                    DISCOUNT_CASH = INPUT                               '値引金額

                    '2019.11.16 R.Takashima From
                    '既に行っている計算をさらに行っているため値がおかしくなっている
                    'TOTAL_CASH = TOTAL_CASH - DISCOUNT_CASH             '本商品までの合計金額を計算
                    '2019.11.16 R.Takashima To

                    DISPLAY_T.Text = TOTAL_CASH                         '合計金額を画面に表示
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_DISCOUNT_C  'チケット値引きモード
                    INPUT = CInt(DISPLAY_T.Text)                        '単品金額値引き
                    PRODUCT_NAME_T.Text = "チケット値引き(" & CInt(DISPLAY_T.Text) & "円)"
                    DISCOUNT_CASH = INPUT                               '値引金額
                    TOTAL_CASH = TOTAL_CASH - DISCOUNT_CASH             '本商品までの合計金額を計算
                    If TOTAL_CASH < 0 Then
                        TOTAL_CASH = 0
                    End If
                    TICKET_CASH = INPUT                                 'チケット値引き額
                    DISPLAY_T.Text = TOTAL_CASH                         '合計金額を画面に表示
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_DISCOUNT_T '合計値引きモード
                    Select Case Mode
                        Case DISCOUNT_R     '％値引き
                            DISCOUNT_RATE = CInt(DISPLAY_T.Text)        '値引率
                            INPUT = TOTAL_CASH * (CInt(DISPLAY_T.Text) / 100)
                            PRODUCT_NAME_T.Text = "％値引き(" & CInt(DISPLAY_T.Text) & "%)"
                        Case DISCOUNT_K         '金額値引き
                            INPUT = CInt(DISPLAY_T.Text)                '単品金額値引き
                            PRODUCT_NAME_T.Text = "金額値引き(" & CInt(DISPLAY_T.Text) & "円)"
                    End Select
                    TOTAL_CASH = TOTAL_CASH - INPUT                     '本商品までの合計金額を計算
                    If TOTAL_CASH < 0 Then
                        TOTAL_CASH = 0
                    End If
                    DISCOUNT_CASH = INPUT                               '値引金額
                    DISPLAY_T.Text = TOTAL_CASH                         '合計金額を画面に表示
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
                Case M_MORE  '同一商品モード
                    UPRICE = DISPLAY_T.Text
                    INPUT = oTool.ToHalfAdjust(UPRICE * UCOUNT, 0)      '現在入力中の商品価格
                    TOTAL_CASH = TOTAL_CASH + INPUT                     '本商品までの合計金額を計算
                    DISPLAY_T.Text = TOTAL_CASH                         '合計金額を画面に表示
                    DISCOUNT_CASH = 0                                   '値引き額の設定
                    D_MODE = 0                                          '入力中フラグをリセット
                    CAL_PROC = True
            End Select
        Else
            CAL_PROC = False
        End If

        oTool = Nothing

    End Function

    '**************************************************
    '日次取引データ挿入処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_TRN_INSERT(ByVal sender As Softgroup.NetButton.NetButton) As Boolean

        Dim boolRet As Boolean
        Dim Ope As Integer

        '2019.10.16 R.Takashima FROM
        Dim tax As Integer = 0
        Dim productCount As Integer
        Dim noTaxTotalPrice As Long = 0
        Dim productSalePrice As cStructureLib.sViewProductSalePrice()
        '2019.10.16 R.Takashima TO

        oTrn = Nothing
        ReDim oTrn(0)

        '2019.10.16 R.Takashima FROM
        For i As Integer = 0 To MEISAI_V.Rows.Count - 1
            If MEISAI_V("商品コード", i).Value <> "" Then '商品コードがある明細は実際にある商品
                productCount = oMstProductDBIO.getProductSalePrice(productSalePrice,
                                                    CHANNEL_CODE,
                                                    MEISAI_V("商品コード", i).Value,
                                                    MEISAI_V("JANコード", i).Value,
                                                    oTran)

                '条件に合う商品が一つしかないとき（条件が全て同じの商品が複数ある場合は条件を追加したほうがよい）
                If productCount = 1 Then
                    If productSalePrice(0).sReducedTaxRate Then
                        tax = REDUCE_TAX
                    Else
                        tax = oConf(0).sTax
                    End If
                Else
                    tax = oConf(0).sTax
                End If


                noTaxTotalPrice += oTool.AfterToBeforeTax(MEISAI_V("販売価格", i).Value, tax, oConf(0).sFracProc)
            End If
        Next

        tax = oConf(0).sTax
        '2019.10.16 R.Takashima TO

        oTrn(0).sTrnCode = TRNCODE
        oTrn(0).sTrnClass = TRNCLASS
        oTrn(0).sChannel = CHANNEL_CODE
        oTrn(0).sRequestDate = String.Format("{0:yyyy/MM/dd}", Now)
        oTrn(0).sRequestTime = String.Format("{0:HH:mm:ss}", Now)
        oTrn(0).sPaymentCode = SEISAN_MODE
        Select Case sender.TextButton
            Case "戻入"
                Ope = -1
            Case "販促"
                Ope = 0
            Case Else
                Ope = 1
        End Select
        oTrn(0).sNoTaxTotalProductPrice = noTaxTotalPrice * Ope
        oTrn(0).sShippingCharge = (oTool.AfterToBeforeTax(CLng(TDELIVALY_T.Text), tax, oConf(0).sFracProc)) * Ope
        oTrn(0).sPaymentCharge = (oTool.AfterToBeforeTax(CLng(TFEE_T.Text), tax, oConf(0).sFracProc)) * Ope
        oTrn(0).sDiscount = (CLng(SDISCOUNT_T.Text) + CLng(TDISCOUNT_T.Text)) * -1 * Ope
        oTrn(0).sPointDiscount = CLng(PDISCOUNT_T.Text) * -1 * Ope
        oTrn(0).sTicketDiscount = CLng(CDISCOUNT_T.Text) * -1 * Ope
        oTrn(0).sTotalPrice = (CLng(TBILL_T.Text)) * Ope
        oTrn(0).sTaxTotal = (CLng(TTAX_T.Text)) * Ope
        oTrn(0).sNoTaxTotalPrice = oTrn(0).sTotalPrice - oTrn(0).sTaxTotal
        oTrn(0).sDifference = oTrn(0).sNoTaxTotalPrice -
                                  (
                                    (oTrn(0).sNoTaxTotalProductPrice * Ope) +
                                    (oTrn(0).sShippingCharge * Ope) +
                                    (oTrn(0).sPaymentCharge * Ope) +
                                    (oTrn(0).sDiscount * Ope) +
                                    (oTrn(0).sPointDiscount * Ope) +
                                    (oTrn(0).sTicketDiscount * Ope)
                                 )
        oTrn(0).sShipCode = 0
        oTrn(0).sMemberCode = MEMBER_CODE
        oTrn(0).sPointMemberCode = POINT_MEMBER_CODE
        oTrn(0).sSex = SEX
        oTrn(0).sGeneration = GENERATION
        oTrn(0).sWeather = WEATHER
        oTrn(0).sStaffCode = STAFF_CODE_T.Text.ToString
        oTrn(0).sDayCloseDate = ""
        oTrn(0).sMonthCloseDate = ""
        oTrn(0).sMemo = ""

        '日次取引データを更新
        boolRet = oDataTrnDBIO.insertTrn(oTrn(0), oTran)
        If boolRet = True Then
            Me.MSG_T.Text = "日次取引データを更新しました"
        End If

    End Function
    '**************************************************
    '日次取引データ挿入処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function RETURN_DAY_TRN_INSERT(ByVal sender As Softgroup.NetButton.NetButton) As Boolean

        Dim boolRet As Boolean
        Dim Ope As Integer

        '2019.10.16 R.Takashima FROM
        Dim tax As Integer = 0

        Dim noTaxTotalPrice As Long = 0
        Dim productSalePrice As cStructureLib.sViewProductSalePrice()
        '2019.10.16 R.Takashima TO

        oTrn = Nothing
        ReDim oTrn(0)

        '2019.10.16 R.Takashima FROM
        '返金する商品を検索し、軽減税率対象の商品か通常の税率かを調べ税抜金額を計算する。
        For i As Integer = 0 To MEISAI_V.Rows.Count - 1
            '返金対象のデータを取得する。
            If MEISAI_V("返金額", i).Value <> 0 Then
                oMstProductDBIO.getProductSalePrice(productSalePrice,
                                                    CHANNEL_CODE,
                                                    MEISAI_V("商品コード", i).Value,
                                                    MEISAI_V("JANコード", i).Value,
                                                    oTran)

                If productSalePrice(0).sReducedTaxRate Then
                    tax = REDUCE_TAX
                Else
                    tax = oConf(0).sTax
                End If
                noTaxTotalPrice = oTool.AfterToBeforeTax(CLng(STOTAL_T.Text), tax, oConf(0).sFracProc)
                Exit For

            Else
                If i = MEISAI_V.Rows.Count - 1 Then '最後の行までに返金対象のデータが取得できなかったとき
                    Dim mesForm As cMessageLib.fMessage
                    mesForm = New cMessageLib.fMessage(1,
                                                    "返金対象商品が見つかりませんでした。",
                                                    Nothing,
                                                    "日次取引データの更新が失敗しました。",
                                                    Nothing)
                    mesForm.ShowDialog()
                    RETURN_DAY_TRN_INSERT = False
                    Exit Function
                End If
            End If
        Next

        tax = oConf(0).sTax
        '2019.10.16 R.Takashima TO

        oTrn(0).sTrnCode = TRNCODE
        oTrn(0).sTrnClass = TRNCLASS
        oTrn(0).sChannel = CHANNEL_CODE
        oTrn(0).sRequestDate = String.Format("{0:yyyy/MM/dd}", Now)
        oTrn(0).sRequestTime = String.Format("{0:HH:mm:ss}", Now)
        oTrn(0).sPaymentCode = SEISAN_MODE
        Select Case sender.TextButton
            Case "戻入"
                Ope = -1
            Case "販促"
                Ope = 0
            Case Else
                Ope = 1
        End Select
        'oTrn(0).sNoTaxTotalProductPrice = (oTool.AfterToBeforeTax(CLng(STOTAL_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sNoTaxTotalProductPrice = noTaxTotalPrice * Ope
        oTrn(0).sShippingCharge = (oTool.AfterToBeforeTax(CLng(TDELIVALY_T.Text), tax, oConf(0).sFracProc)) * Ope
        oTrn(0).sPaymentCharge = (oTool.AfterToBeforeTax(CLng(TFEE_T.Text), tax, oConf(0).sFracProc)) * Ope
        oTrn(0).sDiscount = (CLng(SDISCOUNT_T.Text) + CLng(TDISCOUNT_T.Text)) * -1 * Ope
        oTrn(0).sPointDiscount = CLng(PDISCOUNT_T.Text) * -1 * Ope
        oTrn(0).sTicketDiscount = CLng(CDISCOUNT_T.Text) * -1 * Ope

        '2016.06.28 K.Oikawa s
        'ポイントが足りない場合はここで減算
        'oTrn(0).sTotalPrice = (CLng(TBILL_T.Text)) * Ope
        oTrn(0).sTotalPrice = (CLng(TBILL_T.Text - returnOver)) * Ope
        '2016.06.28 K.Oikawa e

        oTrn(0).sTaxTotal = (CLng(TTAX_T.Text)) * Ope
        oTrn(0).sNoTaxTotalPrice = oTrn(0).sTotalPrice - oTrn(0).sTaxTotal
        oTrn(0).sDifference = oTrn(0).sNoTaxTotalPrice -
                                  (
                                    (oTrn(0).sNoTaxTotalProductPrice * Ope) +
                                    (oTrn(0).sShippingCharge * Ope) +
                                    (oTrn(0).sPaymentCharge * Ope) +
                                    (oTrn(0).sDiscount * Ope) +
                                    (oTrn(0).sPointDiscount * Ope) +
                                    (oTrn(0).sTicketDiscount * Ope)
                                 )
        oTrn(0).sShipCode = 0
        oTrn(0).sMemberCode = MEMBER_CODE
        oTrn(0).sPointMemberCode = POINT_MEMBER_CODE
        oTrn(0).sSex = SEX
        oTrn(0).sGeneration = GENERATION
        oTrn(0).sWeather = WEATHER
        oTrn(0).sStaffCode = STAFF_CODE_T.Text.ToString
        oTrn(0).sDayCloseDate = ""
        oTrn(0).sMonthCloseDate = ""
        oTrn(0).sMemo = OLDTRNCODE

        '日次取引データを更新
        boolRet = oDataTrnDBIO.insertTrn(oTrn(0), oTran)
        If boolRet = True Then
            Me.MSG_T.Text = "日次取引データを更新しました"
        End If

    End Function

    '**************************************************
    '日次取引明細データ挿入処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_SUBTRN_INSERT(ByVal Mode As String, ByVal Rate As Integer) As Boolean

        Dim boolRet As Boolean
        Dim oTool As cTool
        Dim RecordCount As Long
        Dim oAvgCostPrice() As cStructureLib.sViewAvgCostPrice
        Dim oMstCostPriceDBIO As cMstCostPriceDBIO
        Dim oArrivalSubData() As cStructureLib.sArrivalSubData
        Dim oDataArrivalSubDBIO As cDataArrivalSubDBIO
        Dim pStrcutureNo As Integer

        '2019.10.11 R.Takashima FROM
        Dim tax As Integer

        '2019.10.27 R.Takashima
        Dim subTrn As cStructureLib.sSubTrn()

        '軽減税率が適用されるものは商品のみのため（送料などは通常の税率）
        If SUBTRNCLASS = M_SALE Then
            If oProductSalePrice(0).sReducedTaxRate = True Then
                tax = REDUCE_TAX
            Else
                tax = oConf(0).sTax
            End If
        ElseIf SUBTRNCLASS = M_POSTAGE Or SUBTRNCLASS = M_FEE Then
            tax = oConf(0).sTax
            '2019.10.11 R.Takashima TO

            '2019.10.26 R.Takashima From
            '割引時の計算について税率を全て１０％で計算していたため、
            '軽減税率時は８％で計算するよう変更
        ElseIf SUBTRNCLASS <> M_SALE Then
            ReDim subTrn(0)
            oSubDataTrnDBIO.getSubTrn(subTrn, TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)


            For i = MEISAI_V.RowCount - 1 To 0 Step -1
                If subTrn(i).sSubTrnClass = M_SALE Then
                    If subTrn(i).sReducedTaxRatePrice > 0 Then
                        tax = REDUCE_TAX
                    Else
                        tax = oConf(0).sTax
                    End If
                    Exit For
                End If
            Next
        End If
        '2019.10.26 R.Takashima To


        oTool = New cTool
        oSubTrn = Nothing
        ReDim oSubTrn(0)

        oSubTrn(0).sTrnCode = TRNCODE
        oSubTrn(0).sSubTrnCode = SUB_TRNCODE
        If T_MODE <> 2 Then
            oSubTrn(0).sStatus = "登録"
        Else
            oSubTrn(0).sStatus = "訂正"
        End If
        oSubTrn(0).sSubTrnClass = SUBTRNCLASS

        If BUMON_INDEX = -1 Then
            oSubTrn(0).sBumonCode = 3
        Else
            oSubTrn(0).sBumonCode = oBumon(BUMON_INDEX).sBumonCode
        End If

        Select Case SUBTRNCLASS
            Case M_SALE  '売上
                If Me.PRODUCT_CODE_T.Text <> "" Then
                    oSubTrn(0).sProductCode = Me.PRODUCT_CODE_T.Text
                Else
                    oSubTrn(0).sProductCode = ""
                End If

                If Me.PRODUCT_NAME_T.Text <> "" Then
                    oSubTrn(0).sProductName = Me.PRODUCT_NAME_T.Text
                Else
                    oSubTrn(0).sProductName = ""
                End If
                If Me.JAN_CODE_T.Text <> "" Then
                    oSubTrn(0).sJANCode = Me.JAN_CODE_T.Text
                Else
                    oSubTrn(0).sJANCode = ""
                End If
                If Me.OPTION_1_T.Text <> "" Then
                    oSubTrn(0).sOption1 = Me.OPTION_1_T.Text
                Else
                    oSubTrn(0).sOption1 = ""
                End If
                If Me.OPTION_2_T.Text <> "" Then
                    oSubTrn(0).sOption2 = Me.OPTION_2_T.Text
                Else
                    oSubTrn(0).sOption2 = ""
                End If
                If Me.OPTION_3_T.Text <> "" Then
                    oSubTrn(0).sOption3 = Me.OPTION_3_T.Text
                Else
                    oSubTrn(0).sOption3 = ""
                End If
                If Me.OPTION_4_T.Text <> "" Then
                    oSubTrn(0).sOption4 = Me.OPTION_4_T.Text
                Else
                    oSubTrn(0).sOption4 = ""
                End If
                If Me.OPTION_5_T.Text <> "" Then
                    oSubTrn(0).sOption5 = Me.OPTION_5_T.Text
                Else
                    oSubTrn(0).sOption5 = ""
                End If
                oSubTrn(0).sListPrice = oProductSalePrice(0).sListPrice
                '仕入価格取得
                If PRODUCT_CODE_T.Text <> "" Then
                    Select Case oSubTrn(0).sBumonCode
                        Case 1
                            oDataArrivalSubDBIO = New cDataArrivalSubDBIO(oConn, oCommand, oDataReader)
                            ReDim oArrivalSubData(0)
                            RecordCount = oDataArrivalSubDBIO.getLastArrivalSubData(oArrivalSubData, Nothing, Nothing, Me.PRODUCT_CODE_T.Text, oTran)
                            oDataArrivalSubDBIO = Nothing

                            Select Case RecordCount
                                Case 0
                                    oMstCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
                                    ReDim oAvgCostPrice(0)
                                    oSubTrn(0).sCostPrice = oMstCostPriceDBIO.getAvgCostPrice(oAvgCostPrice, Me.PRODUCT_CODE_T.Text, Nothing, oTran)
                                    oMstCostPriceDBIO = Nothing
                                Case Else
                                    oSubTrn(0).sCostPrice = oArrivalSubData(0).sCostPrice
                            End Select
                        Case 3
                            oMstBomDBIO.getFullBom(oViewBom, Nothing, oSubTrn(0).sProductCode, 0, Nothing, oTran)
                            pStrcutureNo = oViewBom(0).sStructureCode
                            oMstBomDBIO.getFullBom(oViewBom, pStrcutureNo, Nothing, Nothing, Nothing, oTran)

                        Case Else
                            oSubTrn(0).sCostPrice = 0
                    End Select
                Else
                    oSubTrn(0).sCostPrice = 0
                End If
                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sUnitPrice = oTool.AfterToBeforeTax(UPRICE, oConf(0).sTax, oConf(0).sFracProc)
                oSubTrn(0).sUnitPrice = oTool.AfterToBeforeTax(UPRICE, tax, oConf(0).sFracProc)
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sCount = UCOUNT
                oSubTrn(0).sNoTaxProductPrice = oSubTrn(0).sUnitPrice * oSubTrn(0).sCount
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0
                oSubTrn(0).sDiscountPrice = 0
                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = UPRICE * UCOUNT

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(UPRICE * UCOUNT, oConf(0).sTax, oConf(0).sFracProc)
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(UPRICE * UCOUNT, tax, oConf(0).sFracProc)

                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                End If
                '2019.10.11 R.Takashima TO

            Case M_DISCOUNT_U  '単品値引き
                oSubTrn(0).sProductCode = "99999-02"
                oSubTrn(0).sProductName = "(単品値引き)" & "-" & Mode & "-" & Rate
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sDiscountPrice = DISCOUNT_CASH * -1
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = DISCOUNT_CASH * -1
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, tax, oConf(0).sFracProc) * -1

                '2019.10.11 R.Takashima FROM
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                End If
                '2019.10.11 R.Takashima TO

            Case M_POSTAGE  '送料
                oSubTrn(0).sProductCode = "99999-00"
                oSubTrn(0).sProductName = "(送料)"
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sShipCharge = oTool.AfterToBeforeTax(POSTAGE_CASH, oConf(0).sTax, oConf(0).sFracProc)
                oSubTrn(0).sShipCharge = oTool.AfterToBeforeTax(POSTAGE_CASH, tax, oConf(0).sFracProc)
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sPayCharge = 0
                oSubTrn(0).sDiscountPrice = 0
                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = POSTAGE_CASH
                oSubTrn(0).sNoTaxPrice = oSubTrn(0).sShipCharge

                '2019.10.11 R.Takashima FROM
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                End If
                '2019.10.11 R.Takashima TO

            Case M_FEE  '手数料
                oSubTrn(0).sProductCode = "99999-01"
                oSubTrn(0).sProductName = "(手数料)"
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(FEE_CASH, oConf(0).sTax, oConf(0).sFracProc)
                oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(FEE_CASH, tax, oConf(0).sFracProc)
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sDiscountPrice = 0
                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = FEE_CASH
                oSubTrn(0).sNoTaxPrice = oSubTrn(0).sPayCharge

                '2019.10.11 R.Takashima FROM
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                End If
                '2019.10.11 R.Takashima TO

            Case M_DISCOUNT_M  '会員値引き
                oSubTrn(0).sProductCode = "99999-04"
                oSubTrn(0).sProductName = "(会員値引き)" & "-" & Mode & "-" & Rate
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sDiscountPrice = DISCOUNT_CASH * -1
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = DISCOUNT_CASH * -1
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, tax, oConf(0).sFracProc) * -1

                '2019.10.11 R.Takashima FROM
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                End If
                '2019.10.11 R.Takashima TO

            Case M_DISCOUNT_P  'ポイント値引き
                oSubTrn(0).sProductCode = "99999-05"
                oSubTrn(0).sProductName = "(ポイント値引き)"
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0
                oSubTrn(0).sDiscountPrice = 0

                Dim totalPrice As Long
                Dim discountNormalPrice As Long '通常税率分の値引き額
                Dim discountReducePrice As Long '軽減税率分の値引き額

                totalPrice = 0
                discountNormalPrice = 0
                discountReducePrice = 0
                ReDim subTrn(0)

                oSubDataTrnDBIO.getSubTrn(subTrn, TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

                '2019.10.27 R.Takashima From
                '商品の税率ごとに値引き税額を算出する
                For i = 0 To MEISAI_V.RowCount - 1

                    totalPrice += MEISAI_V("金額", i).Value

                    For j = i + 1 To MEISAI_V.RowCount - 1
                        If IsNothing(MEISAI_V("値引き", j).Value) = False And MEISAI_V("値引き", j).Value > 0 Then
                            totalPrice -= MEISAI_V("値引き", j).Value
                        Else
                            i = j - 1
                            Exit For
                        End If
                    Next

                    If subTrn(i).sReducedTaxRatePrice > 0 Then
                        discountReducePrice += totalPrice / (TOTAL_CASH + DISCOUNT_CASH) * DISCOUNT_CASH
                    Else
                        discountNormalPrice += totalPrice / (TOTAL_CASH + DISCOUNT_CASH) * DISCOUNT_CASH
                    End If
                    totalPrice = 0
                Next

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sPointDiscountPrice = oTool.AfterToBeforeTax(POINT_CASH, oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sPointDiscountPrice = POINT_CASH * -1
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = oSubTrn(0).sPointDiscountPrice
                'oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(POINT_CASH, tax, oConf(0).sFracProc) * -1
                oSubTrn(0).sNoTaxPrice = (oTool.AfterToBeforeTax(discountReducePrice, REDUCE_TAX, oConf(0).sFracProc) +
                                         oTool.AfterToBeforeTax(discountNormalPrice, oConf(0).sTax, oConf(0).sFracProc)) * -1

                '2019.10.11 R.Takashima FROM
                'If tax = REDUCE_TAX Then
                '    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                'Else
                '    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                'End If
                '2019.10.11 R.Takashima TO
                oSubTrn(0).sReducedTaxRatePrice = oTool.AfterToTax(discountReducePrice, REDUCE_TAX, oConf(0).sFracProc) * -1
                oSubTrn(0).sTaxPrice = oTool.AfterToTax(discountNormalPrice, oConf(0).sTax, oConf(0).sFracProc) * -1

                '2019.11.02 R.Takashima

            Case M_DISCOUNT_C  'チケット値引き
                oSubTrn(0).sProductCode = "99999-06"
                oSubTrn(0).sProductName = "(チケット値引き)"
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0
                oSubTrn(0).sDiscountPrice = 0
                oSubTrn(0).sPointDiscountPrice = 0



                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sTicketDiscountPrice = oTool.AfterToBeforeTax(TICKET_CASH, oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sTicketDiscountPrice = TICKET_CASH * -1
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sPrice = oSubTrn(0).sTicketDiscountPrice
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(TICKET_CASH, tax, oConf(0).sFracProc) * -1

                '2019.10.11 R.Takashima FROM
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                    oSubTrn(0).sTaxPrice = 0
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                    oSubTrn(0).sReducedTaxRatePrice = 0
                End If
                '2019.10.11 R.Takashima TO

            Case M_DISCOUNT_T  '合計値引き
                oSubTrn(0).sProductCode = "99999-03"
                oSubTrn(0).sProductName = "(合計値引き)" & "-" & Mode & "-" & Rate
                oSubTrn(0).sJANCode = ""
                oSubTrn(0).sOption1 = ""
                oSubTrn(0).sOption2 = ""
                oSubTrn(0).sOption3 = ""
                oSubTrn(0).sOption4 = ""
                oSubTrn(0).sOption5 = ""
                oSubTrn(0).sListPrice = 0
                oSubTrn(0).sCostPrice = 0
                oSubTrn(0).sUnitPrice = 0
                oSubTrn(0).sCount = 0
                oSubTrn(0).sNoTaxProductPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0

                Dim totalPrice As Long

                Dim discountNormalPrice As Long '通常税率分の値引き額
                Dim discountReducePrice As Long '軽減税率分の値引き額

                totalPrice = 0
                discountNormalPrice = 0
                discountReducePrice = 0
                ReDim subTrn(0)

                oSubDataTrnDBIO.getSubTrn(subTrn, TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

                '2019.10.27 R.Takashima From
                '商品の税率ごとに値引き税額を算出する
                For i = 0 To MEISAI_V.RowCount - 1

                    totalPrice += MEISAI_V("金額", i).Value

                    For j = i + 1 To MEISAI_V.RowCount - 1
                        If IsNothing(MEISAI_V("値引き", j).Value) = False And MEISAI_V("値引き", j).Value > 0 Then
                            totalPrice -= MEISAI_V("値引き", j).Value
                        Else
                            i = j - 1
                            Exit For
                        End If
                    Next

                    If subTrn(i).sReducedTaxRatePrice > 0 Then
                        discountReducePrice += totalPrice / (TOTAL_CASH + DISCOUNT_CASH) * DISCOUNT_CASH
                    Else
                        discountNormalPrice += totalPrice / (TOTAL_CASH + DISCOUNT_CASH) * DISCOUNT_CASH
                    End If
                    totalPrice = 0
                Next

                '2019.10.11 R.Takashima FROM
                'oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sDiscountPrice = DISCOUNT_CASH * -1
                '2019.10.11 R.Takashima TO

                oSubTrn(0).sPointDiscountPrice = 0
                oSubTrn(0).sTicketDiscountPrice = 0
                oSubTrn(0).sPrice = oSubTrn(0).sDiscountPrice
                'oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(DISCOUNT_CASH, tax, oConf(0).sFracProc) * -1
                oSubTrn(0).sNoTaxPrice = (oTool.AfterToBeforeTax(discountReducePrice, REDUCE_TAX, oConf(0).sFracProc) +
                                         oTool.AfterToBeforeTax(discountNormalPrice, oConf(0).sTax, oConf(0).sFracProc)) * -1

                '2019.10.11 R.Takashima FROM
                'If tax = REDUCE_TAX Then
                '    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                'Else
                '    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                'End If
                '2019.10.11 R.Takashima TO
                '
                '税額を入れたいのに税率ごとの割引額を入れていたので修正
                'oSubTrn(0).sReducedTaxRatePrice = reduceTaxPrice
                'oSubTrn(0).sTaxPrice = normalTaxPrice
                oSubTrn(0).sReducedTaxRatePrice = oTool.AfterToTax(discountReducePrice, REDUCE_TAX, oConf(0).sFracProc) * -1
                oSubTrn(0).sTaxPrice = oTool.AfterToTax(discountNormalPrice, oConf(0).sTax, oConf(0).sFracProc) * -1

                '2019.10.27 R.Takashima To

        End Select
        oSubTrn(0).sMemo = ""

        boolRet = oSubDataTrnDBIO.insertSubTrn(oSubTrn(0), oTran)
        If boolRet = True Then
            Me.MSG_T.Text = "日次取引明細データを更新しました"
        Else
            Dim errMsg As String = "更新に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              Nothing,
                                              errMsg,
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

        oTool = Nothing

    End Function
    '**************************************************
    '取引明細表示処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_SUBTRN_DISPLAY(ByVal parSubTrn As cStructureLib.sSubTrn, ByVal Mode As String) As Boolean
        Dim str1 As String
        Dim str2 As String
        Dim str3 As String
        Dim i As Integer
        Dim opt As String
        Dim tax As Integer

        '2019.10.11 R.Takashima
        If parSubTrn.sReducedTaxRatePrice = 0 Then '軽減消費税額が0のときは通常税率で計算されている
            tax = oConf(0).sTax
        Else
            tax = REDUCE_TAX
        End If
        '2019.10.11 R.Takashima

        str1 = ""
        str2 = ""
        str3 = ""

        'JANコード,商品コード,商品名称,サイズ,カラー,定価,販売価格,数量,金額,値引き
        Select Case SUBTRNCLASS
            Case M_SALE
                opt = ""
                If parSubTrn.sOption1 <> "" Then
                    opt = opt & parSubTrn.sOption1 & "："
                End If
                If parSubTrn.sOption2 <> "" Then
                    opt = opt & parSubTrn.sOption2 & "："
                End If
                If parSubTrn.sOption3 <> "" Then
                    opt = opt & parSubTrn.sOption3 & "："
                End If
                If parSubTrn.sOption4 <> "" Then
                    opt = opt & parSubTrn.sOption4 & "："
                End If
                If parSubTrn.sOption5 <> "" Then
                    opt = opt & parSubTrn.sOption5 & "："
                End If
                MEISAI_V.Rows.Add(
                        parSubTrn.sJANCode,
                        parSubTrn.sProductCode,
                        parSubTrn.sProductName,
                        opt,
                        oTool.BeforeToAfterTax(parSubTrn.sListPrice, tax, oConf(0).sFracProc),
                        oTool.BeforeToAfterTax(parSubTrn.sUnitPrice, tax, oConf(0).sFracProc),
                        parSubTrn.sCount,
                        parSubTrn.sPrice,
                        oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, tax, oConf(0).sFracProc),
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                MEISAI_V.CurrentCell = MEISAI_V("JANコード", i - 1)

                ReDim Preserve oMeisai(i - 1)

                '2019.10.11 R.Takashima FROM
                'すでに行っている処理を繰り返しているためコメントアウト
                'On Error Resume Next
                'opt = ""
                'If parSubTrn.sOption1 <> "" Then
                '    opt = opt & parSubTrn.sOption1 & "："
                'End If
                'If parSubTrn.sOption2 <> "" Then
                '    opt = opt & parSubTrn.sOption2 & "："
                'End If
                'If parSubTrn.sOption3 <> "" Then
                '    opt = opt & parSubTrn.sOption3 & "："
                'End If
                'If parSubTrn.sOption4 <> "" Then
                '    opt = opt & parSubTrn.sOption4 & "："
                'End If
                'If parSubTrn.sOption5 <> "" Then
                '    opt = opt & parSubTrn.sOption5 & "："
                'End If
                '2019.10.11 R.Takashima TO

                oMeisai(i - 1).sJANCode = parSubTrn.sJANCode
                oMeisai(i - 1).sProductCode = parSubTrn.sProductCode
                oMeisai(i - 1).sProductName = parSubTrn.sProductName
                oMeisai(i - 1).sOption = opt
                oMeisai(i - 1).sPrice = oTool.BeforeToAfterTax(parSubTrn.sListPrice, tax, oConf(0).sFracProc)
                oMeisai(i - 1).sSale_Price = oTool.BeforeToAfterTax(parSubTrn.sUnitPrice, tax, oConf(0).sFracProc)
                oMeisai(i - 1).sCnt = parSubTrn.sCount
                oMeisai(i - 1).sTPrice = parSubTrn.sPrice
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, tax, oConf(0).sFracProc)
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode

            Case M_DISCOUNT_U   '単品値引の場合
                str1 = "(値引き)"
                str2 = Mode
                If Mode = DISCOUNT_R Then
                    str3 = DISCOUNT_RATE
                Else
                    str3 = DISCOUNT_CASH
                End If

                MEISAI_V.Rows.Add(
                        str2,
                        "",
                        str1,
                        str3,
                        0,
                        0,
                        0,
                        0,
                        DISCOUNT_CASH,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )

                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = str2
                oMeisai(i - 1).sProductName = str3
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = ""
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, tax, oConf(0).sFracProc)
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_POSTAGE   '送料の場合
                str1 = "(送料)"
                MEISAI_V.Rows.Add(
                        "",
                        "",
                        str1,
                        "",
                        0,
                        0,
                        0,
                        POSTAGE_CASH,
                        0,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = ""
                oMeisai(i - 1).sProductName = ""
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = parSubTrn.sPrice
                oMeisai(i - 1).sDPrice = ""
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_FEE   '手数料の場合
                str1 = "(手数料)"
                MEISAI_V.Rows.Add(
                        "",
                        "",
                        str1,
                        "",
                        0,
                        0,
                        0,
                        FEE_CASH,
                        0,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = ""
                oMeisai(i - 1).sProductName = ""
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = parSubTrn.sPrice
                oMeisai(i - 1).sDPrice = ""
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_DISCOUNT_M   '会員値引の場合
                str1 = "(会員値引き)"
                str2 = Mode
                If Mode = DISCOUNT_R Then
                    str3 = DISCOUNT_RATE
                End If
                MEISAI_V.Rows.Add(
                        str2,
                        "",
                        str1,
                        str3,
                        0,
                        0,
                        0,
                        0,
                        DISCOUNT_CASH,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = str2
                oMeisai(i - 1).sProductName = str3
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = ""
                oMeisai(i - 1).sDPrice = parSubTrn.sPointDiscountPrice
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_DISCOUNT_P   'ポイント値引の場合
                str1 = "(ポイント値引き)"
                str2 = Mode
                If Mode = DISCOUNT_R Then
                    str3 = DISCOUNT_RATE
                End If
                MEISAI_V.Rows.Add(
                        str2,
                        "",
                        str1,
                        str3,
                        0,
                        0,
                        0,
                        0,
                        POINT_CASH,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = str2
                oMeisai(i - 1).sProductName = str3
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = ""
                oMeisai(i - 1).sDPrice = parSubTrn.sPointDiscountPrice
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_DISCOUNT_C   'チケット値引の場合
                str1 = "(チケット値引き)"
                str2 = Mode
                If Mode = DISCOUNT_R Then
                    str3 = DISCOUNT_RATE
                End If
                MEISAI_V.Rows.Add(
                        str2,
                        "",
                        str1,
                        str3,
                        0,
                        0,
                        0,
                        0,
                        TICKET_CASH,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = str2
                oMeisai(i - 1).sProductName = str3
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = ""
                oMeisai(i - 1).sDPrice = parSubTrn.sTicketDiscountPrice
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_DISCOUNT_T   '合計値引の場合
                str1 = "(合計値引き)"
                str2 = Mode
                If Mode = DISCOUNT_R Then
                    str3 = DISCOUNT_RATE
                Else
                    str3 = DISCOUNT_CASH
                End If
                MEISAI_V.Rows.Add(
                        str2,
                        "",
                        str1,
                        str3,
                        0,
                        0,
                        0,
                        0,
                        DISCOUNT_CASH,
                        parSubTrn.sTrnCode,
                        parSubTrn.sSubTrnCode,
                        0,
                        0
                )
                i = MEISAI_V.Rows.Count

                ReDim Preserve oMeisai(i - 1)

                On Error Resume Next
                oMeisai(i - 1).sJANCode = str1
                oMeisai(i - 1).sProductCode = str2
                oMeisai(i - 1).sProductName = str3
                oMeisai(i - 1).sOption = ""
                oMeisai(i - 1).sPrice = ""
                oMeisai(i - 1).sSale_Price = ""
                oMeisai(i - 1).sCnt = ""
                oMeisai(i - 1).sTPrice = ""
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, tax, oConf(0).sFracProc)
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
        End Select

    End Function
    '**************************************************
    '日次取引明細データ修正処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_SUBTRN_EDIT() As Boolean

        Dim Recordi As Long

        '日次取引明細データの読み込み
        Recordi = oSubDataTrnDBIO.getSubTrn(oSubTrn, TRNCODE, SUB_TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        If Recordi > 0 Then
            Me.MSG_T.Text = "日次取引明細データを更新しました"
        Else
            Dim errMsg As String = "訂正対象日次明細データの読み込みに失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

        oSubTrn(0).sProductName = "訂正"
        oSubTrn(0).sUnitPrice = oSubTrn(0).sUnitPrice * -1
        oSubTrn(0).sCount = oSubTrn(0).sCount * -1
        oSubTrn(0).sPrice = oSubTrn(0).sPrice * -1
        oSubTrn(0).sUpdateDate = Format(Now, "yyyy/MM/dd")
        oSubTrn(0).sUpdateTime = Format(Now, "HH:mm:ss")

        '日次取引明細データを更新
        Recordi = oSubDataTrnDBIO.insertSubTrn(oSubTrn(0), oTran)
        If Recordi = 1 Then
            Me.MSG_T.Text = "日次取引明細データを更新しました"
        Else
            Dim errMsg As String = "更新に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

    End Function
    '**************************************************
    '日次取引明細データ更新処理（通常売上）
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function DAY_SUBTRN_UPDATE(ByVal Mode As String) As Boolean

        Dim Recordi As Long
        Dim i As Integer

        '日次取引明細データの読み込み
        Recordi = oSubDataTrnDBIO.getSubTrn(oSubTrn, TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        For i = 0 To Recordi - 1
            Select Case Mode
                Case "戻入"
                    oSubTrn(i).sCount = oSubTrn(i).sCount * -1
                    oSubTrn(i).sNoTaxProductPrice = oSubTrn(i).sNoTaxProductPrice * -1
                    oSubTrn(i).sShipCharge = oSubTrn(i).sShipCharge * -1
                    oSubTrn(i).sPayCharge = oSubTrn(i).sPayCharge * -1
                    oSubTrn(i).sCount = oSubTrn(i).sCount * -1
                    oSubTrn(i).sDiscountPrice = oSubTrn(i).sDiscountPrice * -1
                    oSubTrn(i).sPointDiscountPrice = oSubTrn(i).sPointDiscountPrice * -1
                    oSubTrn(i).sNoTaxPrice = oSubTrn(i).sNoTaxPrice * -1
                    oSubTrn(i).sTaxPrice = oSubTrn(i).sTaxPrice * -1
                    oSubTrn(i).sPrice = oSubTrn(i).sPrice * -1
                    oSubTrn(i).sUpdateDate = Format(Now, "yyyy/MM/dd")
                    oSubTrn(i).sUpdateTime = Format(Now, "HH:mm:ss")
                Case "販促"
                    oSubTrn(i).sNoTaxProductPrice = 0
                    oSubTrn(i).sShipCharge = 0
                    oSubTrn(i).sPayCharge = 0
                    oSubTrn(i).sCount = 0
                    oSubTrn(i).sDiscountPrice = 0
                    oSubTrn(i).sPointDiscountPrice = 0
                    oSubTrn(i).sNoTaxPrice = 0
                    oSubTrn(i).sTaxPrice = 0
                    oSubTrn(i).sPrice = 0
                    oSubTrn(i).sUpdateDate = Format(Now, "yyyy/MM/dd")
                    oSubTrn(i).sUpdateTime = Format(Now, "HH:mm:ss")
            End Select
            '日次取引明細データを更新
            Recordi = oSubDataTrnDBIO.updateSubTrn(oSubTrn(i), oTran)
        Next i

        If Recordi = True Then
            Me.MSG_T.Text = "日次取引明細データを更新しました"
        Else
            Dim errMsg As String = "更新に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

    End Function
    '**************************************************
    '日次取引明細データ更新処理(返品処理）
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function RETURN_DAY_SUBTRN_INSERT(pMemo As String) As Boolean

        Dim RecordCnt As Long
        Dim i As Integer
        'Dim j As Integer
        Dim pTrnCode As Long
        Dim pSubTrnCode As Integer

        Dim tax As Integer

        TRNCODE = TRNCODE_CREATE()
        pTrnCode = TRNCODE
        pSubTrnCode = 1
        For i = 0 To MEISAI_V.RowCount - 1
            If MEISAI_V("返金額", i).Value <> 0 Then
                '日次取引明細データの読み込み
                RecordCnt = oSubDataTrnDBIO.getSubTrn(oSubTrn, CLng(MEISAI_V("取引コード", i).Value), CLng(MEISAI_V("取引明細コード", i).Value), Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

                oSubTrn(0).sCount = (oSubTrn(0).sCount - CInt(MEISAI_V("数量", i).Value)) * -1
                oSubTrn(0).sNoTaxProductPrice = oSubTrn(0).sUnitPrice * (oSubTrn(0).sCount - CInt(MEISAI_V("数量", i).Value))
                oSubTrn(0).sDiscountPrice = 0
                oSubTrn(0).sShipCharge = 0
                oSubTrn(0).sPayCharge = 0
                oSubTrn(0).sPointDiscountPrice = 0

                Select Case MEISAI_V("商品名称", i).Value
                    Case "(値引き)" '2019.10.27 R.Takashima 単品値引きが無かったため追加
                        oSubTrn(0).sDiscountPrice = CLng(MEISAI_V("返金額", i).Value)
                    Case "(会員値引き)"
                        oSubTrn(0).sDiscountPrice = CLng(MEISAI_V("返金額", i).Value)
                    Case "(送料)"
                        oSubTrn(0).sShipCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(手数料)"
                        oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(合計値引き)"
                        oSubTrn(0).sDiscountPrice = CLng(MEISAI_V("返金額", i).Value)
                    Case "(ポイント値引き)"
                        oSubTrn(0).sPointDiscountPrice = CLng(MEISAI_V("返金額", i).Value)
                    Case "(チケット値引き)"
                        oSubTrn(0).sTicketDiscountPrice = CLng(MEISAI_V("返金額", i).Value)
                End Select

                'For j = i + 1 To MEISAI_V.RowCount - 1
                '    If MEISAI_V("返金額", j).Value <> 0 Then
                '        If MEISAI_V("商品コード", j).Value <> "" Then
                '            Select Case MEISAI_V("商品名称", i + 1).Value
                '                Case "(会員値引き)"
                '                    oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '                Case "(送料)"
                '                    oSubTrn(0).sShipCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '                Case "(手数料)"
                '                    oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '                Case "(合計値引き)"
                '                    oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '                Case "(ポイント値引き)"
                '                    oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '                Case "(チケット値引き)"
                '                    oSubTrn(0).sTicketDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", j).Value), oConf(0).sTax, oConf(0).sFracProc)
                '            End Select
                '        End If
                '    Else
                '        Exit For
                '    End If
                'Next

                '2019.10.16 R.Takashima FROM
                '軽減税率追加
                If oSubTrn(0).sReducedTaxRatePrice = 0 Then
                    tax = oConf(0).sTax
                Else
                    tax = REDUCE_TAX
                End If
                '2019.10.16 R.Takashima TO

                '2016.06.28 K.Oikawa s
                'ポイントが足りない場合はここで減算
                'oSubTrn(0).sPrice = CLng(MEISAI_V("返金額", i).Value) * -1
                'oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sPrice = (CLng(MEISAI_V("返金額", i).Value) - returnOver) * -1
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax((CLng(MEISAI_V("返金額", i).Value) - returnOver), tax, oConf(0).sFracProc) * -1
                '2016.06.28 K.Oikawa e

                '2019.10.16 R.Takashima FROM
                '税率によって保管する場所が違うので分けている。
                'sReducedTaxRatePrice = DB:軽減取引消費税額
                'sTaxPrice            = DB:取引消費税額
                If tax = REDUCE_TAX Then
                    oSubTrn(0).sReducedTaxRatePrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                    oSubTrn(0).sTaxPrice = 0
                Else
                    oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
                    oSubTrn(0).sReducedTaxRatePrice = 0
                End If
                '2019.10.16 R.Takashima TO

                oSubTrn(0).sTrnCode = pTrnCode
                oSubTrn(0).sSubTrnCode = pSubTrnCode

                '2016.06.09 K.Oikawa s
                '課代表.No62(返品処理) 返品処理を行う際には、「日次取引明細データ.備考」に返品理由の記載を行う
                'oSubTrn(0).sMemo = MEISAI_V("取引コード", i).Value & "-" & MEISAI_V("取引明細コード", i).Value
                oSubTrn(0).sMemo = MEISAI_V("取引コード", i).Value & "-" & MEISAI_V("取引明細コード", i).Value & "-" & pMemo
                '2016.06.09 K.Oikawa e
                '日次取引明細データを挿入
                RecordCnt = oSubDataTrnDBIO.insertSubTrn(oSubTrn(0), oTran)
                pSubTrnCode = pSubTrnCode + 1
                'i = j - 1
            End If
        Next i

        If RecordCnt = True Then
            Me.MSG_T.Text = "日次取引明細データを登録しました"
        Else
            Dim errMsg As String = "登録に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

    End Function
    '**************************************************
    '日次取引明細データ更新処理(社販処理）
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Function INTRN_DAY_SUBTRN_INSERT() As Boolean

        Dim Recordi As Long
        Dim i As Integer

        '日次取引明細データの読み込み
        Recordi = oSubDataTrnDBIO.getSubTrn(oSubTrn, TRNCODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        For i = 0 To Recordi - 1
            oSubTrn(i).sNoTaxProductPrice = 0
            oSubTrn(i).sShipCharge = 0
            oSubTrn(i).sPayCharge = 0
            oSubTrn(i).sCount = 0
            oSubTrn(i).sDiscountPrice = 0
            oSubTrn(i).sPointDiscountPrice = 0
            oSubTrn(i).sNoTaxPrice = 0
            oSubTrn(i).sTaxPrice = 0
            oSubTrn(i).sPrice = 0
            oSubTrn(i).sUpdateDate = Format(Now, "yyyy/MM/dd")
            oSubTrn(i).sUpdateTime = Format(Now, "HH:mm:ss")
            '日次取引明細データを更新
            Recordi = oSubDataTrnDBIO.updateSubTrn(oSubTrn(i), oTran)
        Next i

        If Recordi = True Then
            Me.MSG_T.Text = "日次取引明細データを更新しました"
        Else
            Dim errMsg As String = "更新に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

    End Function


    '****************
    '在庫マスタ更新
    '****************
    Private Function UPDATE_STOCK(ByVal sender As Softgroup.NetButton.NetButton) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim ret As Boolean
        Dim sCount As Integer
        Dim RecordCount As Integer
        Dim oStock() As cStructureLib.sStock      '登録用
        Dim pStock() As cStructureLib.sStock      '現行在庫数取得用
        Dim pSubTrn() As cStructureLib.sSubTrn      '取引明細データ用
        Dim pProductCode() As String
        Dim pBomCode As Integer
        Dim pProduct() As cStructureLib.sProduct

        '読込みバッファーのクリア
        ReDim oStock(0)
        ReDim oViewBom(0)

        For i = 0 To MEISAI_V.Rows.Count - 1
            If MEISAI_V("商品コード", i).Value <> "" Then
                ReDim pProductCode(0)

                '商品種別の判定（構成品<疑似品目>の判定）
                RecordCount = oMstBomDBIO.getFullBom(oViewBom, Nothing, MEISAI_V("商品コード", i).Value, 1, Nothing, oTran)
                If RecordCount = 1 Then
                    pBomCode = oViewBom(0).sStructureCode
                    ReDim oViewBom(0)
                    RecordCount = oMstBomDBIO.getFullBom(oViewBom, pBomCode, Nothing, Nothing, 1, oTran)

                    pProductCode(0) = MEISAI_V("商品コード", i).Value

                    For j = 0 To RecordCount - 1
                        ReDim Preserve pProductCode(j)
                        pProductCode(j) = oViewBom(j).sProductCode
                    Next
                Else
                    'If oViewBom(0).sProductClass = 1 Then
                    pProductCode(0) = MEISAI_V("商品コード", i).Value
                    'End If
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

                        '-------------------------------
                        '在庫品の場合は在庫更新を行う
                        '-------------------------------
                        ReDim pProduct(0)
                        RecordCount = oMstProductDBIO.getProduct(pProduct, Nothing, oStock(0).sProductCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                        If pProduct(0).sProductClass = 1 Then
                            '*******************
                            '     在庫数算出
                            '*******************
                            Select Case sender.TextButton
                                Case "戻入"
                                    If T_MODE = 2 Then
                                        ReDim pSubTrn(0)
                                        oSubDataTrnDBIO.getSubTrn(pSubTrn, MEISAI_V("取引コード", i).Value, MEISAI_V("取引明細コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                                        oStock(0).sStockCount = sCount + (pSubTrn(0).sCount - CInt(MEISAI_V("数量", i).Value))
                                    Else
                                        oStock(0).sStockCount = sCount + CInt(MEISAI_V("数量", i).Value)
                                    End If
                                    ret = oMstStockDBIO.updateStock(oStock, oTran)
                                Case Else
                                    '現行在庫が０の場合（在庫管理異常の場合）
                                    '現在のレジ作業を留めないため在庫数を０として処理は続行する
                                    If MEISAI_V("数量", i).Value.ToString <> "" Then
                                        If sCount < CInt(MEISAI_V("数量", i).Value) Then
                                            MSG_T.Text = "在庫数が不足しています"
                                            Dim message_form As New cMessageLib.fMessage(1,
                                                                              pProductCode(j) & "の在庫数が０になっています",
                                                                              "在庫情報を確認して下さい",
                                                                              "今回は在庫数０で更新されます", Nothing)
                                            message_form.ShowDialog()
                                            message_form.Dispose()
                                            message_form = Nothing
                                            oStock(0).sStockCount = 0

                                        Else    '現行在庫数が1以上の場合
                                            oStock(0).sStockCount = sCount - CInt(MEISAI_V("数量", i).Value)
                                        End If
                                    End If
                            End Select
                            ret = oMstStockDBIO.updateStock(oStock, oTran)
                        End If
                    Next j
                End If
            End If
        Next i
    End Function

    '2016.06.08 K.Oikawa s
    '課代表.No62 返品用に追加
    '****************
    '在庫マスタ更新　戻入
    '****************
    Private Function UPDATE_STOCK_RETURN(ByVal mode As Integer) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim ret As Boolean
        Dim sCount As Integer
        Dim RecordCount As Integer
        Dim oStock() As cStructureLib.sStock      '登録用
        Dim pStock() As cStructureLib.sStock      '現行在庫数取得用
        Dim pSubTrn() As cStructureLib.sSubTrn      '取引明細データ用
        Dim pProductCode() As String
        Dim pBomCode As Integer
        Dim pProduct() As cStructureLib.sProduct

        '読込みバッファーのクリア
        ReDim oStock(0)
        ReDim oViewBom(0)

        For i = 0 To MEISAI_V.Rows.Count - 1
            If MEISAI_V("商品コード", i).Value <> "" Then
                ReDim pProductCode(0)

                '商品種別の判定（構成品<疑似品目>の判定）
                RecordCount = oMstBomDBIO.getFullBom(oViewBom, Nothing, MEISAI_V("商品コード", i).Value, 1, Nothing, oTran)
                If RecordCount = 1 Then
                    pBomCode = oViewBom(0).sStructureCode
                    ReDim oViewBom(0)
                    RecordCount = oMstBomDBIO.getFullBom(oViewBom, pBomCode, Nothing, Nothing, 1, oTran)

                    pProductCode(0) = MEISAI_V("商品コード", i).Value

                    For j = 0 To RecordCount - 1
                        ReDim Preserve pProductCode(j)
                        pProductCode(j) = oViewBom(j).sProductCode
                    Next
                Else
                    'If oViewBom(0).sProductClass = 1 Then
                    pProductCode(0) = MEISAI_V("商品コード", i).Value
                    'End If
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

                        '-------------------------------
                        '在庫品の場合は在庫更新を行う
                        '-------------------------------
                        ReDim pProduct(0)
                        RecordCount = oMstProductDBIO.getProduct(pProduct, Nothing, oStock(0).sProductCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                        If pProduct(0).sProductClass = 1 Then
                            '*******************
                            '     在庫数算出
                            '*******************
                            If mode = 1 Then '加算
                                If T_MODE = 2 Then
                                    ReDim pSubTrn(0)
                                    oSubDataTrnDBIO.getSubTrn(pSubTrn, MEISAI_V("取引コード", i).Value, MEISAI_V("取引明細コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                                    oStock(0).sStockCount = sCount + (pSubTrn(0).sCount - CInt(MEISAI_V("数量", i).Value))
                                Else
                                    oStock(0).sStockCount = sCount + CInt(MEISAI_V("数量", i).Value)
                                End If
                                ret = oMstStockDBIO.updateStock(oStock, oTran)
                            ElseIf mode = 2 Then '減算
                                If T_MODE = 2 Then
                                    ReDim pSubTrn(0)
                                    oSubDataTrnDBIO.getSubTrn(pSubTrn, MEISAI_V("取引コード", i).Value, MEISAI_V("取引明細コード", i).Value, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                                    oStock(0).sStockCount = sCount - (pSubTrn(0).sCount - CInt(MEISAI_V("数量", i).Value))
                                Else
                                    oStock(0).sStockCount = sCount - CInt(MEISAI_V("数量", i).Value)
                                End If
                                ret = oMstStockDBIO.updateStock(oStock, oTran)
                            End If

                        End If
                    Next j
                End If
            End If
        Next i
    End Function
    '2016.06.08 K.Oikawa e


    '**************************************************
    '付与ポイントデータ作成処理
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************

    Function POINT_INSERT(ByVal pAddPoint As Long, ByVal pUsePoint As Long) As Long

        Dim Recordi As Long

        ReDim oPointData(0)

        oPointData(0).sDate = String.Format("{0:yyyy/MM/dd}", Now)
        oPointData(0).sPointMemberCode = POINT_MEMBER_CODE_T.Text
        oPointData(0).sAddPoint = pAddPoint
        oPointData(0).sUsePoint = pUsePoint
        oPointData(0).sPoint = POINT_i + pAddPoint - pUsePoint
        oPointData(0).sEnableFlg = True
        oPointData(0).sStaffCode = STAFF_CODE

        'ポイントデータを挿入
        Recordi = oDataPointDBIO.insertPoint(oPointData(0), oTran)

        If Recordi = True Then
            Me.MSG_T.Text = "ポイントデータを更新しました"
        Else
            Dim errMsg As String = "ポイントデータ更新に失敗しました"
            Dim message_form As New cMessageLib.fMessage(1,
                                              errMsg,
                                              "開発元に連絡して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If
        POINT_INSERT = oPointData(0).sPoint
    End Function


    '**************************************************
    'ラインディスプレー表示処理処理
    '[引数]
    '   mode　  1：JANコード読み込み時
    '           2：部門確定時の表示
    '           3：ご請求金額の表示
    '           4：お預かり／おつりの表示
    '           5：メッセージ表示
    '**************************************************
    Private Sub LINE_DISPLAY(ByVal mode As Integer)
        Dim ret As Integer
        Dim STR As String

        '2019.10.24 R.Takashima 
        'ラインディスプレイがない場合は処理を行わないようにする
        If (LINE_DISPLAY_OPEN = True) Then

            Select Case mode
                Case D_READ          'JANコード読み込み時の表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    oDisplay.DisplayText(Me.PRODUCT_NAME_T.Text, DISP_DT_NORMAL)

                    STR = String.Format("  {0,9:C} ×   {1,3:##0}{2}", CLng(Me.SALE_PRICE_T.Text), CInt(Me.CNT_T.Text), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_KATEGORY          '部門確定時の表示
                    STR = String.Format("ご購入金額:{0,9:C}{1}", CLng(Me.SALE_PRICE_T.Text) * CInt(Me.CNT_T.Text), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_RATE          '値引きの表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    STR = String.Format("お値引き:  {0,9:C}{1}", CLng(DISCOUNT_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                    STR = String.Format("ご購入金額:{0,9:C}{1}", CLng(TOTAL_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_POSTAGE          '送料の表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    STR = String.Format("送料:      {0,9:C}{1}", CLng(POSTAGE_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                    STR = String.Format("ご購入金額:{0,9:C}{1}", CLng(TOTAL_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_FEE              '手数料の表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    STR = String.Format("手数料:    {0,9:C}{1}", CLng(FEE_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                    STR = String.Format("ご購入金額:{0,9:C}{1}", CLng(TOTAL_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_TOTAL          'ご請求金額の表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    STR = String.Format("ご請求金額:{0,9:C}{1}", CLng(TOTAL_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                Case D_CHANGE          'お預かり／おつりの表示
                    '表示領域の初期化
                    oDisplay.ClearText()
                    oDisplay.DestroyWindow()

                    STR = "お預かり：" & String.Format("{0,9:C}{1}", CLng(RECEIVE_CASH), vbCrLf)
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)

                    '2019.10.15 R.Takashima FROM
                    'おつりが０以上だったら表示する
                    If CHANGE_CASH >= 0 Then
                        STR = "おつり：  " & String.Format("{0,9:C}{1}", CLng(CHANGE_CASH), vbCrLf)
                        oDisplay.DisplayText(STR, DISP_DT_NORMAL)
                    End If
                '2019.10.15 R.Takashima TO

                Case D_MESSAGE          'メッセージ表示

                    '表示領域の初期化
                    oDisplay.ScrollText(DISP_ST_LEFT, 100)

                    STR = oConf(0).sLineMsg

                    'ビューポートは、２行目すべて使用する。
                    ' Window自体の大きさは１行５０桁
                    oDisplay.CreateWindow(1, 0, 1, oDisplay.Columns(), 1, STR.Length * 2)
                    'マーキー初期化モード
                    oDisplay.SetMarqueeType(DISP_MT_INIT)
                    ret = oDisplay.ResultCode()
                    oDisplay.DisplayText(STR, DISP_DT_NORMAL)
                    oDisplay.SetMarqueeUnitWait(150)
                    oDisplay.SetMarqueeType(DISP_MT_LEFT)
                    ret = oDisplay.ResultCode()
            End Select
        End If
    End Sub

    '**************************************************
    'ドローワーオープン
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************
    Sub DROWER_OPEN()
        'Dim i As Long

        '2019.10.23 R.Takashima  FROM
        '課題No.74 ドロワーを閉めるメッセージを表示する
        If DRAWER_OPEN Then
            Dim message_form As New cMessageLib.fMessage(0,
                                          Nothing,
                                          "ドロワーを閉じて下さい。",
                                          Nothing, Nothing)
            message_form.Show()
            Application.DoEvents()

            oTool.Wait(10)

            oDrawer.OpenDrawer()

            message_form.Dispose()

            '2019.10.23 R.Takashima TO

            message_form = New cMessageLib.fMessage(2,
                                              Nothing,
                                              "領収書を発行しますか？",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            If message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                Bill_PRINTING(TRNCODE, CHANNEL_CODE)
            End If
            message_form = Nothing
            Application.DoEvents()

            'For i = 0 To 10000
            '    '...Wait
            'Next

            'While oDrawer.DrawerOpened
            '    'ドロワーが閉まるまでWait....
            'End While
        End If
    End Sub


    '******************************************
    '      レシート印刷
    '******************************************
    Sub RECEIPT_PRINTING()
        Dim ret As Integer
        Dim pData As String
        Dim i As Integer
        Dim oTool As cTool
        Dim str As String
        Dim SYUKEI As Long
        Dim DGOUKEI As Long
        Dim DPGOUKEI As Long
        Dim DTGOUKEI As Long
        Dim SOURYOU As Long
        Dim TESUURYOU As Long
        Dim ITEM_i As Integer

        '2019.10.18 R.Takashima FROM
        Dim tax As Integer
        Dim trnCode As Long
        Dim sumPriceOfNormalTax As Long '通常税率合計金額
        Dim sumPriceOfReduceTax As Long '軽減税率合計金額
        Dim normalTemp As Long '通常税率合計金額退避変数
        Dim reduceTemp As Long '軽減税率合計金額退避変数
        Dim sumDiscount As Long '値引き、会員値引きの合計
        'Dim product As cStructureLib.sViewProductSalePrice()
        Dim product As cStructureLib.sSubTrn()
        Dim sumPrice As Long

        tax = oConf(0).sTax
        sumPriceOfNormalTax = 0
        sumPriceOfReduceTax = 0
        normalTemp = 0
        reduceTemp = 0
        sumDiscount = 0
        sumPrice = 0
        '2019.10.18 R.Takashima TO


        '2019.10.24 R.Takashima From
        '取引コードがない場合（見つからない場合）は印刷はしない
        If (IsNothing(Me.TRNCODE) = False And Me.TRNCODE <> 0) Then
            trnCode = Me.TRNCODE

            '取引コードから取引データを取得する
            'レシート発行時は取引コードを取得して日次取引明細データから発行するように変更する
            '既に計算しているデータを使うため新たに計算する必要がなくなる。
            ReDim product(0)
            oSubDataTrnDBIO.getSubTrn(product, trnCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        Else
            Dim mes As cMessageLib.fMessage = New cMessageLib.fMessage(1,
                                                                Nothing,
                                                                "レシート印刷に失敗しました。",
                                                                "最後に行った取引が取得できませんでした。",
                                                                Nothing)
            mes.ShowDialog()
            mes.Dispose()
            Exit Sub
        End If
        '2019.10.24 R.Takashima To

        '2019.11.02 R.Takashima From
        'レシートを発行するかの確認メッセージ
        Dim mess As cMessageLib.fMessage = New cMessageLib.fMessage(2,
                                                                    Nothing,
                                                                    "レシートを発行します。",
                                                                    "よろしいですか。",
                                                                    Nothing)

        If mess.ShowDialog = DialogResult.No Then
            mess.Dispose()
            Exit Sub
        End If
        '2019.11.02 R.Takashima To


        oTool = New cTool

        '同期印刷On
        oPrinter.SetAsyncMode(True)

        '一括印刷　On
        oPrinter.TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)

        '2019.10.18 R.Takashima FROM
        '再発行時にデータを取得
        If R_MODE = True Then
            TOTAL_CASH = oTrn(0).sTotalPrice
        End If
        '2019.10.18 R.Takashima TO

        'ロゴ印刷
        'レシートBitMapの読込み
        str = "Picture\" & oConf(0).sRLogoPass
        ret = oPrinter.SetBitmap(1, PTR_S_RECEIPT, str, PTR_BM_ASIS, PTR_BM_CENTER)
        pData = Chr(27) & "|1B" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '住所・TEL/FAX・URL印刷
        pData = Chr(27) & "|cA" & String.Format("〒{0} {1}", oConf(0).sPostCode, oConf(0).sAdderess1) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & String.Format("              {0}", oConf(0).sAdderess2) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & "TEL " & oConf(0).sTEL & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & "FAX " & oConf(0).sFAX & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & oConf(0).sURL & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '日付時間印刷
        pData = Chr(27) & "|cA" & Format(Now, "yyyy/MM/dd dddddd HH:mm:ss") & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '2019.11.1 R.Takashima From
        For Each p In product

            Select Case p.sSubTrnClass

                Case M_DISCOUNT_U '単品値引き

                    If p.sProductName.Substring(0, 9) = "(単品値引き)-%" Then
                        Select Case PRINTER_MAKER
                            Case "TEC"
                                pData = String.Format("(単品値引き)  {0,2:###}%         {1,9:C}",
                                                    CLng(p.sProductName.Substring(10)),
                                                    CLng(p.sPrice)) & Chr(10)
                            Case "EPSON"
                                pData = String.Format("(単品値引き)  {0,2:###}%    {1,9:C}",
                                                    CLng(p.sProductName.Substring(10)),
                                                    CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa s
                                '課題表No138 Star追加
                            Case "STAR"
                                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  {0,2:###}%    {1,9:C}",
                                                    CLng(p.sProductName.Substring(10)),
                                                    CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa e
                        End Select

                    Else

                        Select Case PRINTER_MAKER
                            Case "TEC"
                                pData = String.Format("(単品値引き)  \           {0,9:C}",
                                        CLng(p.sPrice)) & Chr(10)
                            Case "EPSON"
                                pData = String.Format("(単品値引き)  \      {0,9:C}",
                                        CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa s
                                '課題表No138 Star追加
                            Case "STAR"
                                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  \      {0,9:C}",
                                        CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa e
                        End Select

                    End If

                    ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                    'sPriceは値引き時にマイナスが入っているため集計を足している。
                    SYUKEI = SYUKEI + p.sPrice
                    sumDiscount += p.sPrice

                    '2019.11.02 R.Takashima From
                    If p.sTaxPrice < 0 Then
                        sumPriceOfNormalTax += p.sPrice
                    ElseIf p.sReducedTaxRatePrice < 0 Then
                        sumPriceOfReduceTax += p.sPrice
                    End If
                    '2019.11.02 R.Takashima To

                Case M_DISCOUNT_M '会員値引き

                    If p.sProductName.Substring(0, 9) = "(会員値引き)-%" Then
                        Select Case PRINTER_MAKER
                            Case "TEC"
                                pData = String.Format("(会員値引き)  {0,2:###}%         {1,9:C}",
                                                CLng(p.sProductName.Substring(10)),
                                                CLng(p.sPrice)) & Chr(10)
                            Case "EPSON"
                                pData = String.Format("(会員値引き)  {0,2:###}%    {1,9:C}",
                                                CLng(p.sProductName.Substring(10)),
                                                CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa s
                                '課題表No138 Star追加
                            Case "STAR"
                                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(会員値引き)  {0,2:###}%    {1,9:C}",
                                                CLng(p.sProductName.Substring(10)),
                                                CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa e
                        End Select

                    Else

                        Select Case PRINTER_MAKER
                            Case "TEC"
                                pData = String.Format("(単品値引き)  \           {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                            Case "EPSON"
                                pData = String.Format("(単品値引き)  \      {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa s
                                '課題表No138 Star追加
                            Case "STAR"
                                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  \      {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                                '2016.07.01 K.Oikawa e
                        End Select
                    End If

                    ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                    'sPriceは値引き時にマイナスが入っているため集計を足している。
                    SYUKEI = SYUKEI + p.sPrice
                    sumDiscount += p.sPrice

                    '2019.11.02 R.Takashima From
                    If p.sTaxPrice < 0 Then
                        sumPriceOfNormalTax += p.sPrice
                    ElseIf p.sReducedTaxRatePrice < 0 Then
                        sumPriceOfReduceTax += p.sPrice
                    End If
                    '2019.11.02 R.Takashima To

                Case M_POSTAGE '送料
                    SOURYOU += p.sPrice

                Case M_FEE '手数料
                    TESUURYOU += p.sPrice

                Case M_DISCOUNT_P 'ポイント値引き
                    '返品時は通常の値引きで対応する
                    If T_MODE = 2 Then
                        Select Case PRINTER_MAKER
                            Case "TEC"
                                pData = String.Format("(単品値引き)  \           {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                            Case "EPSON"
                                pData = String.Format("(単品値引き)  \      {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                            Case "STAR"
                                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  \      {0,9:C}",
                                    CLng(p.sPrice)) & Chr(10)
                        End Select
                        USE_POINT_i = 0
                        ADD_POINT_i = 0
                        DPGOUKEI = p.sPrice
                        SYUKEI += p.sPrice
                    Else
                        '値引き時はマイナスのためプラスに直す
                        DPGOUKEI += p.sPrice * -1
                    End If

                Case M_DISCOUNT_C 'チケット値引き
                    '値引き時はマイナスのためプラスに直す
                    DTGOUKEI += p.sPrice * -1

                Case M_DISCOUNT_T '合計値引き
                    '値引き時はマイナスのためプラスに直す
                    DGOUKEI += p.sPrice * -1

                Case M_SALE '売上

                    Select Case PRINTER_MAKER

                        Case "TEC"
                            '単品明細（販売額）印刷
                            '商品名　カラー　サイズ

                            pData = RECEIPT_LEFT_MARGIN_STAR & oTool.MidB(p.sProductName, 1, 20) & " "

                            '取引明細データには個別にオプションが入っているため全て一つの文字列としてあわせる。
                            '区切りにはコロン（：）を付けている
                            If p.sOption1 <> "" Then
                                pData = pData & oTool.MidB(p.sOption1, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption2 <> "" Then
                                pData = pData & oTool.MidB(p.sOption2, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption3 <> "" Then
                                pData = pData & oTool.MidB(p.sOption3, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption4 <> "" Then
                                pData = pData & oTool.MidB(p.sOption4, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption5 <> "" Then
                                pData = pData & oTool.MidB(p.sOption5, 1, 20)
                            End If

                            If p.sReducedTaxRatePrice > 0 Then
                                pData += REDUCE_TAX_MARK
                            End If

                            pData = pData & Chr(10)

                            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                            pData = RECEIPT_LEFT_MARGIN_STAR & String.Format(" {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
                                            CLng(p.sUnitPrice + p.sTaxPrice + p.sReducedTaxRatePrice),
                                            CInt(p.sCount),
                                            CLng(p.sPrice)
                                            ) & Chr(10)

                        Case "EPSON"

                            '単品明細（販売額）印刷
                            '商品名　カラー　サイズ
                            pData = RECEIPT_LEFT_MARGIN_STAR & oTool.MidB(p.sProductName, 1, 20) & " "

                            '取引明細データには個別にオプションが入っているため全て一つの文字列としてあわせる。
                            '区切りにはコロン（：）を付けている
                            If p.sOption1 <> "" Then
                                pData = pData & oTool.MidB(p.sOption1, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption2 <> "" Then
                                pData = pData & oTool.MidB(p.sOption2, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption3 <> "" Then
                                pData = pData & oTool.MidB(p.sOption3, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption4 <> "" Then
                                pData = pData & oTool.MidB(p.sOption4, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption5 <> "" Then
                                pData = pData & oTool.MidB(p.sOption5, 1, 20)
                            End If

                            If p.sReducedTaxRatePrice > 0 Then
                                pData += REDUCE_TAX_MARK
                            End If

                            pData = pData & Chr(10)

                            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                            pData = RECEIPT_LEFT_MARGIN_STAR & String.Format(" {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
                                            CLng(p.sUnitPrice + p.sTaxPrice + p.sReducedTaxRatePrice),
                                            CInt(p.sCount),
                                            CLng(p.sPrice)
                                            ) & Chr(10)

                            '2016.07.01 K.Oikawa s
                            '課題表No138 Star追加

                        Case "STAR"

                            '単品明細（販売額）印刷
                            '商品名　カラー　サイズ
                            pData = RECEIPT_LEFT_MARGIN_STAR & oTool.MidB(p.sProductName, 1, 20) & " "

                            '取引明細データには個別にオプションが入っているため全て一つの文字列としてあわせる。
                            '区切りにはコロン（：）を付けている
                            If p.sOption1 <> "" Then
                                pData = pData & oTool.MidB(p.sOption1, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption2 <> "" Then
                                pData = pData & oTool.MidB(p.sOption2, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption3 <> "" Then
                                pData = pData & oTool.MidB(p.sOption3, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption4 <> "" Then
                                pData = pData & oTool.MidB(p.sOption4, 1, 20)
                                pData = pData & " : "
                            End If
                            If p.sOption5 <> "" Then
                                pData = pData & oTool.MidB(p.sOption5, 1, 20)
                            End If

                            If p.sReducedTaxRatePrice > 0 Then
                                pData += REDUCE_TAX_MARK
                            End If

                            pData = pData & Chr(10)

                            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                            pData = RECEIPT_LEFT_MARGIN_STAR & String.Format(" {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
                                            CLng(p.sNoTaxPrice + p.sTaxPrice + p.sReducedTaxRatePrice),
                                            CInt(p.sCount),
                                            CLng(p.sPrice)
                                            ) & Chr(10)
                            '2016.07.01 K.Oikawa e
                    End Select

                    ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                    SYUKEI = SYUKEI + CLng(p.sPrice)
                    ITEM_i = ITEM_i + CInt(p.sCount)

                    '2019.11.02 R.Takashima From
                    If p.sTaxPrice > 0 Then
                        sumPriceOfNormalTax += p.sPrice
                    ElseIf p.sReducedTaxRatePrice > 0 Then
                        sumPriceOfReduceTax += p.sPrice
                    End If
                    '2019.11.02 R.Takashima To

            End Select
        Next
        '2019.11.1 R.Takashima To


        '2019.11.02 R.Takashima From
        '値の退避
        normalTemp = sumPriceOfNormalTax
        reduceTemp = sumPriceOfReduceTax

        'ポイント値引きの按分計算
        If DPGOUKEI > 0 Then
            sumPriceOfNormalTax -= DPGOUKEI * normalTemp / SYUKEI
            sumPriceOfReduceTax -= DPGOUKEI * reduceTemp / SYUKEI

        End If

        'チケット値引きの按分計算
        'If DTGOUKEI > 0 Then
        '            sumPriceOfNormalTax -= DTGOUKEI * normalTemp / SYUKEI
        '            sumPriceOfReduceTax -= DTGOUKEI * reduceTemp / SYUKEI
        'End If
        'チケット値引きは今は通常税率で計算する
        'もし税率を分けるときは上のコードを使う
        If DTGOUKEI > 0 Then
            sumPriceOfNormalTax -= DTGOUKEI
        End If

        '合計値引きの按分計算
        If DGOUKEI > 0 Then

            sumPriceOfNormalTax -= DGOUKEI * normalTemp / SYUKEI
            sumPriceOfReduceTax -= DGOUKEI * reduceTemp / SYUKEI

        End If

        '2019.11.02 R.Takashima To



        '2019.11.02 R.Takashima From
        'コメントアウト

        'SYUKEI = 0
        'ITEM_i = 0
        'For i = 0 To MEISAI_V.Rows.Count - 1
        '    Select Case oMeisai(i).sJANCode
        '        Case "(値引き)"
        '            If oMeisai(i).sProductCode = "%" Then
        '                Select Case PRINTER_MAKER
        '                    Case "TEC"
        '                        pData = String.Format("(単品値引き)  {0,2:###}%         {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                    Case "EPSON"
        '                        pData = String.Format("(単品値引き)  {0,2:###}%    {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa s
        '                        '課題表No138 Star追加
        '                    Case "STAR"
        '                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  {0,2:###}%    {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa e
        '                End Select
        '            Else
        '                Select Case PRINTER_MAKER
        '                    Case "TEC"
        '                        pData = String.Format("(単品値引き)  \           {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                    Case "EPSON"
        '                        pData = String.Format("(単品値引き)  \      {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa s
        '                        '課題表No138 Star追加
        '                    Case "STAR"
        '                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  \      {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa e
        '                End Select
        '            End If
        '            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '            SYUKEI = SYUKEI - MEISAI_V("値引き", i).Value
        '            sumDiscount += MEISAI_V("値引き", i).Value
        '        Case "(会員値引き)"
        '            If oMeisai(i).sProductCode = "%" Then
        '                Select Case PRINTER_MAKER
        '                    Case "TEC"
        '                        pData = String.Format("(会員値引き)  {0,2:###}%         {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                    Case "EPSON"
        '                        pData = String.Format("(会員値引き)  {0,2:###}%    {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa s
        '                        '課題表No138 Star追加
        '                    Case "STAR"
        '                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(会員値引き)  {0,2:###}%    {1,9:C}",
        '                                            CLng(MEISAI_V("オプション", i).Value),
        '                                            CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa e
        '                End Select
        '            Else
        '                Select Case PRINTER_MAKER
        '                    Case "TEC"
        '                        pData = String.Format("(単品値引き)  \           {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                    Case "EPSON"
        '                        pData = String.Format("(単品値引き)  \      {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa s
        '                        '課題表No138 Star追加
        '                    Case "STAR"
        '                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(単品値引き)  \      {0,9:C}",
        '                                CLng(MEISAI_V("値引き", i).Value)) & Chr(10)
        '                        '2016.07.01 K.Oikawa e
        '                End Select
        '            End If
        '            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '            SYUKEI = SYUKEI - MEISAI_V("値引き", i).Value
        '            sumDiscount += MEISAI_V("値引き", i).Value
        '        Case "(合計値引き)"
        '            DGOUKEI = DGOUKEI - MEISAI_V("値引き", i).Value
        '        Case "(送料)"
        '            SOURYOU = SOURYOU + MEISAI_V("金額", i).Value
        '        Case "(手数料)"
        '            TESUURYOU = TESUURYOU + MEISAI_V("金額", i).Value
        '        Case "(ポイント値引き)"
        '            DPGOUKEI = DPGOUKEI - MEISAI_V("値引き", i).Value
        '        Case "(チケット値引き)"
        '            DTGOUKEI = DTGOUKEI - MEISAI_V("値引き", i).Value
        '        Case Else

        '            ReDim product(0)
        '            'If oMstProductDBIO.getProductSalePrice(product,
        '            '                            CHANNEL_CODE,
        '            '                            MEISAI_V("商品コード", i).Value,
        '            '                            MEISAI_V("JANコード", i).Value,
        '            '                            oTran
        '            '                            ) <> 0 Then
        '            If True Then
        '                '販売価格 × 数量 = 金額
        '                Select Case PRINTER_MAKER
        '                    Case "TEC"
        '                        '単品明細（販売額）印刷
        '                        '商品名　カラー　サイズ
        '                        pData = oTool.MidB(oMeisai(i).sProductName, 1, 20) & " "
        '                        pData = pData & oTool.MidB(MEISAI_V("オプション", i).Value, 1, 20)

        '                        '2019.10.18 R.Takashima FROM
        '                        'If product(0).sReducedTaxRate = True Then
        '                        '    pData += REDUCE_TAX_MARK & Chr(10)
        '                        '    sumPriceOfReduceTax += MEISAI_V("金額", i).Value
        '                        'Else
        '                        '    sumPriceOfNormalTax += MEISAI_V("金額", i).Value
        '                        'End If
        '                        '2019.10.18 R.Takashima TO

        '                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '                        pData = String.Format("      {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
        '                                   CLng(MEISAI_V("販売価格", i).Value),
        '                                   CInt(MEISAI_V("数量", i).Value),
        '                                   CLng(MEISAI_V("金額", i).Value)
        '                                   ) & Chr(10)
        '                    Case "EPSON"
        '                        '単品明細（販売額）印刷
        '                        '商品名　カラー　サイズ
        '                        pData = oTool.MidB(oMeisai(i).sProductName, 1, 20) & " "
        '                        pData = pData & oTool.MidB(MEISAI_V("オプション", i).Value, 1, 20)

        '                        '2019.10.18 R.Takashima FROM
        '                        'If product(0).sReducedTaxRate = True Then
        '                        '    pData += REDUCE_TAX_MARK & Chr(10)
        '                        '    sumPriceOfReduceTax += MEISAI_V("金額", i).Value
        '                        'Else
        '                        '    sumPriceOfNormalTax += MEISAI_V("金額", i).Value
        '                        'End If
        '                        '2019.10.18 R.Takashima TO

        '                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '                        pData = String.Format(" {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
        '                                        CLng(MEISAI_V("販売価格", i).Value),
        '                                        CInt(MEISAI_V("数量", i).Value),
        '                                        CLng(MEISAI_V("金額", i).Value)
        '                                        ) & Chr(10)
        '                    '2016.07.01 K.Oikawa s
        '                    '課題表No138 Star追加
        '                    Case "STAR"
        '                        '単品明細（販売額）印刷
        '                        '商品名　カラー　サイズ
        '                        pData = RECEIPT_LEFT_MARGIN_STAR & oTool.MidB(oMeisai(i).sProductName, 1, 20) & " "
        '                        pData = pData & oTool.MidB(MEISAI_V("オプション", i).Value, 1, 20)

        '                        '2019.10.18 R.Takashima FROM
        '                        'If product(0).sReducedTaxRate = True Then
        '                        '    pData += REDUCE_TAX_MARK & Chr(10)
        '                        '    sumPriceOfReduceTax += MEISAI_V("金額", i).Value
        '                        'Else
        '                        '    pData += Chr(10)
        '                        '    sumPriceOfNormalTax += MEISAI_V("金額", i).Value
        '                        'End If
        '                        '2019.10.18 R.Takashima TO

        '                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format(" {0,6:C} × {1,7:#,##0.#} = {2,9:C}",
        '                                        CLng(MEISAI_V("販売価格", i).Value),
        '                                        CInt(MEISAI_V("数量", i).Value),
        '                                        CLng(MEISAI_V("金額", i).Value)
        '                                        ) & Chr(10)
        '                        '2016.07.01 K.Oikawa e
        '                End Select
        '                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '                SYUKEI = SYUKEI + CLng(MEISAI_V("金額", i).Value)
        '                ITEM_i = ITEM_i + CInt(MEISAI_V("数量", i).Value)

        '            End If
        '    End Select
        'Next i
        '2019.11.1 R.Takashima To


        '小計行印刷
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = "-----------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                pData = String.Format("小計                      {0,9:C}", SYUKEI) & Chr(10)
            Case "EPSON"
                pData = "------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                pData = String.Format("小計                 {0,9:C}", SYUKEI) & Chr(10)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & "------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("小計                 {0,9:C}", SYUKEI) & Chr(10)
                '2016.07.01 K.Oikawa e
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '合計値引き額印刷
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("(合計値引き)  \           {0,9:C}", System.Math.Abs(DGOUKEI)) & Chr(10)
            Case "EPSON"
                pData = String.Format("(合計値引き)  \      {0,9:C}", System.Math.Abs(DGOUKEI)) & Chr(10)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                '2019.10.23　文字の微調整により空白を追加
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(合計値引き)  \      {0,9:C}", System.Math.Abs(DGOUKEI)) & Chr(10)
                '2016.07.01 K.Oikawa e
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ポイント値引き額印刷

        '2019.11.1 R.Takashima From
        '会員ではなくても明細には表示させる
        'If POINT_MEMBER_CODE <> "" Then
        '2019.11.1 R.Takashima To

        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("(ポイント値引き)  \       {0,9:C}", System.Math.Abs(DPGOUKEI)) & Chr(10)
            Case "EPSON"
                pData = String.Format("(ポイント値引き)  \  {0,9:C}", System.Math.Abs(DPGOUKEI)) & Chr(10)
                    '2016.07.01 K.Oikawa s
                    '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(ポイント値引き)  \  {0,9:C}", System.Math.Abs(DPGOUKEI)) & Chr(10)
                '2016.07.01 K.Oikawa e
        End Select
            ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        'End If


        'チケット値引き額印刷
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("(チケット値引き)  \       {0,9:C}", System.Math.Abs(DTGOUKEI)) & Chr(10)
            Case "EPSON"
                pData = String.Format("(チケット値引き)  \  {0,9:C}", System.Math.Abs(DTGOUKEI)) & Chr(10)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(チケット値引き)  \  {0,9:C}", System.Math.Abs(DTGOUKEI)) & Chr(10)
                '2016.07.01 K.Oikawa e
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '送料印刷
        Select Case PRINTER_MAKER
            '2019.11.02 R.Takashima From
            '明細読み込み時にデータを入れているのに使われていなかったため変更
            Case "TEC"
                'pData = String.Format("(送料)  \            {0,9:C}", POSTAGE_CASH) & Chr(10)
                pData = String.Format("(送料)  \            {0,9:C}", SOURYOU) & Chr(10)
            Case "EPSON"
                'pData = String.Format("(送料)  \            {0,9:C}", POSTAGE_CASH) & Chr(10)
                pData = String.Format("(送料)  \            {0,9:C}", SOURYOU) & Chr(10)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                'pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(送料)  \             {0,9:C}", POSTAGE_CASH) & Chr(10)
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(送料)  \            {0,9:C}", SOURYOU) & Chr(10)
                '2016.07.01 K.Oikawa e
                '2019.11.02 R.Takashima To
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '手数料印刷
        Select Case PRINTER_MAKER
            '2019.11.02 R.Takashima From
            '明細読み込み時にデータを入れているのに使われていなかったため変更
            Case "TEC"
                'pData = String.Format("(手数料)  \               {0,9:C}", FEE_CASH) & Chr(10)
                pData = String.Format("(手数料)  \               {0,9:C}", TESUURYOU) & Chr(10)
            Case "EPSON"
                'pData = String.Format("(手数料)  \          {0,9:C}", FEE_CASH) & Chr(10)
                pData = String.Format("(手数料)  \          {0,9:C}", TESUURYOU) & Chr(10)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                'pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(手数料)  \           {0,9:C}", FEE_CASH) & Chr(10)
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("(手数料)  \          {0,9:C}", TESUURYOU) & Chr(10)
                '2016.07.01 K.Oikawa e
                '2019.11.02 R.Takashima To
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '2019.11.02 R.Takashima From
        '請求金額の合計を追加
        sumPrice = SYUKEI - DGOUKEI - DPGOUKEI - DTGOUKEI + SOURYOU + TESUURYOU
        '2019.11.02 R.Takashima To


        '最終請求額印刷
        Select Case PRINTER_MAKER
            '2019.11.02 R.Takashima From
            'TOTAL_CASHを変更
            Case "TEC"
                pData = "-----------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                'pData = Chr(27) & "|bC" &
                '        String.Format("ご請求金額                {0,9:C}", TOTAL_CASH) & Chr(10)
                pData = Chr(27) & "|bC" &
                        String.Format("ご請求金額                 {0,9:C}", sumPrice) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
            Case "EPSON"
                pData = "------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                'pData = Chr(27) & "|bC" &
                '        String.Format("ご請求金額           {0,9:C}", TOTAL_CASH) & Chr(10)
                pData = Chr(27) & "|bC" &
                        String.Format("ご請求金額                 {0,9:C}", sumPrice) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & "------------------------------" & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

                'pData = Chr(27) & "|bC" &
                '        RECEIPT_LEFT_MARGIN_STAR & String.Format("ご請求金額           {0,9:C}", TOTAL_CASH) & Chr(10)

                pData = Chr(27) & "|bC" &
                        RECEIPT_LEFT_MARGIN_STAR & String.Format("ご請求金額           {0,9:C}", sumPrice) & Chr(10)

                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa e
                '2019.11.02 R.Takashima
        End Select

        '2019.10.18 R.Takashima From
        'コメントアウト
        ''消費税
        'Select Case PRINTER_MAKER
        '    Case "TEC"
        '        pData = Chr(27) & "|bC" &
        '                String.Format("（内消費税）              {0,9:C}", oTool.AfterToTax(TOTAL_CASH, oConf(0).sTax, oConf(0).sFracProc)) & Chr(10)
        '    Case "EPSON"
        '        pData = Chr(27) & "|bC" &
        '                String.Format("（内消費税）         {0,9:C}", oTool.AfterToTax(TOTAL_CASH, oConf(0).sTax, oConf(0).sFracProc)) & Chr(10)
        '        '2016.07.01 K.Oikawa s
        '        '課題表No138 Star追加
        '    Case "STAR"
        '        pData = Chr(27) & "|bC" &
        '                RECEIPT_LEFT_MARGIN_STAR & String.Format("（内消費税）         {0,9:C}", oTool.AfterToTax(TOTAL_CASH, oConf(0).sTax, oConf(0).sFracProc)) & Chr(10)
        '        '2016.07.01 K.Oikawa e
        'End Select
        '2019.10.18 R.Takashima To



        '2019.10.18 R.Takashima FROM
        '税区分ごとの消費税

        '2019.11.02 R.Takashima From
        '送料と手数料以外は既に計算してあるのでここでは計算しない
        'sumPriceOfNormalTax = sumPriceOfNormalTax + POSTAGE_CASH + FEE_CASH + DGOUKEI + DPGOUKEI + DTGOUKEI - sumDiscount
        sumPriceOfNormalTax += POSTAGE_CASH + FEE_CASH
        '2019.11.02 R.Takashima To
        Select Case PRINTER_MAKER
            Case "TEC"
                tax = oConf(0).sTax
                pData = Chr(27) & "|bC" & String.Format("（１０％対象）          {0,9:C}", sumPriceOfNormalTax) & Chr(10)
                pData += Chr(27) & "|bC" &
                        String.Format("     （内消費税）       {0,9:C}", oTool.AfterToTax(sumPriceOfNormalTax, tax, oConf(0).sFracProc)) & Chr(10)

                tax = REDUCE_TAX
                pData += Chr(27) & "|bC" & String.Format("（８％対象）            {0,9:C}", sumPriceOfReduceTax) & Chr(10)
                pData += Chr(27) & "|bC" &
                        String.Format("     （内消費税）       {0,9:C}", oTool.AfterToTax(sumPriceOfNormalTax, tax, oConf(0).sFracProc)) & Chr(10)

            Case "EPSON"
                tax = oConf(0).sTax
                pData = Chr(27) & "|bC" & String.Format("（１０％対象）          {0,9:C}", sumPriceOfNormalTax) & Chr(10)
                pData += Chr(27) & "|bC" &
                        String.Format("     （内消費税）       {0,9:C}", oTool.AfterToTax(sumPriceOfNormalTax, tax, oConf(0).sFracProc)) & Chr(10)

                tax = REDUCE_TAX
                pData += Chr(27) & "|bC" & String.Format("（８％対象）            {0,9:C}", sumPriceOfReduceTax) & Chr(10)
                pData += Chr(27) & "|bC" &
                        String.Format("     （内消費税）       {0,9:C}", oTool.AfterToTax(sumPriceOfNormalTax, tax, oConf(0).sFracProc)) & Chr(10)

            Case "STAR"
                tax = oConf(0).sTax
                pData = RECEIPT_LEFT_MARGIN_STAR & Chr(27) & "|bC" & String.Format("（１０%対象）        {0,9:C}", sumPriceOfNormalTax) & Chr(10)
                pData += RECEIPT_LEFT_MARGIN_STAR & Chr(27) & "|bC" &
                        String.Format("     （内消費税）    {0,9:C}", oTool.AfterToTax(sumPriceOfNormalTax, tax, oConf(0).sFracProc)) & Chr(10)

                tax = REDUCE_TAX
                pData += RECEIPT_LEFT_MARGIN_STAR & Chr(27) & "|bC" & String.Format("（８%対象）          {0,9:C}", sumPriceOfReduceTax) & Chr(10)
                pData += RECEIPT_LEFT_MARGIN_STAR & Chr(27) & "|bC" &
                        String.Format("     （内消費税）    {0,9:C}", oTool.AfterToTax(sumPriceOfReduceTax, tax, oConf(0).sFracProc)) & Chr(10)

        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)



        Select Case SEISAN_MODE
            Case CASH
                Select Case PRINTER_MAKER
                    Case "TEC"
                        pData = String.Format("お預り金額                {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                        pData = String.Format("おつり                    {0,9:C}", CHANGE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                    Case "EPSON"
                        pData = String.Format("お預り金額           {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                        pData = String.Format("おつり               {0,9:C}", CHANGE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                        '2016.07.01 K.Oikawa s
                        '課題表No138 Star追加
                    Case "STAR"
                        '2019.10.23　文字の微調整により空白を追加
                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("お預り金額           {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("おつり               {0,9:C}", CHANGE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                        '2016.07.01 K.Oikawa e
                End Select
            Case CREGIT
                Select Case PRINTER_MAKER
                    Case "TEC"
                        pData = String.Format("クレジットご請求金額      {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                    Case "EPSON"
                        pData = String.Format("クレジットご請求金額      {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                    Case "STAR"
                        pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("クレジットご請求金額 {0,9:C}", RECEIVE_CASH) & Chr(10)
                        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                End Select
            Case POINT
        End Select
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("お買上げ点数            {0,9:#,##0}点", ITEM_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
            Case "EPSON"
                pData = String.Format("お買上げ点数       {0,9:#,##0}点", ITEM_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                '2019.10.23　文字の微調整により空白を追加
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("お買上げ点数       {0,9:#,##0}点", ITEM_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa e
        End Select

        '今回ご利用ポイント数
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("今回ご利用ポイント数    {0,9:#,##0}点", USE_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
            Case "EPSON"
                pData = String.Format("ご利用ポイント数   {0,9:#,##0}点", USE_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                '2019.10.23 R.Takashima 文字の微調整
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("ご利用ポイント数   {0,9:#,##0}点", USE_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa e
        End Select

        '今回取得ポイント数
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("今回取得ポイント数      {0,9:#,##0}点", ADD_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
            Case "EPSON"
                pData = String.Format("取得ポイント数     {0,9:#,##0}点", ADD_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("取得ポイント数     {0,9:#,##0}点", ADD_POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa e
        End Select

        '残りポイント数
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = String.Format("残りポイント数          {0,9:#,##0}点", POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
            Case "EPSON"
                pData = String.Format("残りポイント数     {0,9:#,##0}点", POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa s
                '課題表No138 Star追加
            Case "STAR"
                pData = RECEIPT_LEFT_MARGIN_STAR & String.Format("残りポイント数     {0,9:#,##0}点", POINT_i) & Chr(10)
                ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
                '2016.07.01 K.Oikawa e
        End Select

        '2019.10.18 R.Takashima FROM
        '☆が軽減税率であることを表示する
        pData = RECEIPT_LEFT_MARGIN_STAR & "「☆」は軽減税率対象商品です。" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '2019.10.18 R.Takashima TO



        '2019.10.24 R.Takashima From
        '課題No.99 すぐには使う予定が無いため例として作ってある
        '改行
        'pData = "" & Chr(10) & Chr(10)
        'ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        'Dim campaignMessage As String = Chr(27) & "|cA" & "これはテストです。" & vbCrLf & "キャンペーンなどを入力または代入" & Chr(10)
        'str = campaignMessage
        'ret = oPrinter.PrintNormal(PTR_S_RECEIPT, str)
        'str = "Picture\QRCode" etc...
        'ret = oPrinter.SetBitmap(1, PTR_S_RECEIPT, str, PTR_BM_ASIS, PTR_BM_LEFT)
        '2019.10.24 R.Takashima To


        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '挨拶メッセージ印刷
        pData = Chr(27) & "|cA" & oConf(0).sMessage1 & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & oConf(0).sMessage2 & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & oConf(0).sMessage3 & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '取引番号バーコード印刷
        pData = oTool.JANCD("98" _
                          & String.Format("{0:0}", CHANNEL_CODE) _
                          & String.Format("{0:000000000}", TRNCODE)
                         )
        str = oTool.JANCD(pData)    'JANコードチェックデジットの生成
        ret = oPrinter.PrintBarCode(PTR_S_RECEIPT, str, PTR_BCS_JAN13, 50, 100, PTR_BC_CENTER, PTR_BC_TEXT_BELOW) & Chr(10)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '2016.07.01 K.Oikawa s
        '課題表No139 カット
        'ラインフィード＆用紙カット
        'pData = Chr(27) & "|fP"
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = Chr(27) & "|fP"
            Case "EPSON"
                pData = Chr(27) & "|fP"
            Case "STAR"
                pData = Chr(27) & "|95fP"
        End Select
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '2016.07.01 K.Oikawa e


        '一括印刷　Off
        oPrinter.TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)

        oTool = Nothing
    End Sub

    '******************************************
    '      領収書印刷
    '******************************************
    Private Sub Bill_PRINTING(ByVal P_TrnCode As Long, ByVal ChannelCode As Integer)
        Dim ret As Integer
        Dim pData As String

        ret = oDataTrnDBIO.getTrn(oTrn, P_TrnCode, ChannelCode, Nothing, Nothing, Nothing, oTran)
        If ret = 0 Then
            Exit Sub
        End If

        '同期印刷On
        oPrinter.SetAsyncMode(True)

        '一括印刷　On
        oPrinter.TransactionPrint(PTR_S_RECEIPT, PTR_TP_TRANSACTION)



        Select Case PRINTER_MAKER
            Case "TEC"
                BILL_PRINT_ROTATE()
            Case "EPSON"
                BILL_PRINT_ROTATE()
            Case "STAR"
                BILL_PRINT_NOMAL()
        End Select
    End Sub

    Private Sub BILL_PRINT_NOMAL()


        Dim ret As Integer
        Dim pData As String
        Dim str As String
        Dim oTool As cTool

        oTool = New cTool

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '「領収書」を印刷
        pData = Chr(27) & "|4C" & "   領  収  書　" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '日付時間印刷
        pData = Chr(27) & "|1C" & Format(Now, "                     yyyy年MM月dd日") & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)


        '取引番号印刷
        str = "0000000000" & oTrn(0).sTrnCode
        str = oTool.MidB(str.ToString, str.Length - 9, 10)

        pData = Chr(27) & "|1C" &
               String.Format("                取引番号:{0,10:##0}", str) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '宛名印刷部分を印刷
        pData = Chr(27) & "|1uC" & Chr(27) & "|4C" & "　　　　　　　　様" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '請求金額を印刷
        pData = Chr(27) & "|1uC" & Chr(27) & "|4C" &
            String.Format("     {0,9:C}.-  ", oTrn(0).sTotalPrice)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData) & Chr(10)

        pData = Chr(27) & "|1C" & String.Format("                       (消費税込み)") & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '但し書き部分印刷
        '2019.11.15 R.Takashima From
        '但し書き部分が少なかったので
        '改行して表示するよう変更

        'pData = Chr(27) & "|1C" &
        '       String.Format("（但し　　    として領収致しました）") & Chr(10)

        pData = Chr(10) & Chr(27) & "|1C" &
               String.Format("（但し") & Chr(10) & Chr(10)
        pData = pData & "　　　　　    として領収致しました）" & Chr(10)
        '2019.11.15 R.Takashima To

        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ローテート印刷 On (90度回転印刷モード設定)
        '領収書BitMapの読込み
        ret = oPrinter.SetBitmap(2, PTR_S_RECEIPT, CStr(oConf(0).sBLogoPass), PTR_BM_ASIS, PTR_BM_CENTER)
        pData = Chr(27) & "|2B"
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ローテート印刷 Off (通常印刷モード設定)
        'ret = oPrinter.RotatePrint(PTR_S_RECEIPT, PTR_RP_NORMAL)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ロゴ印刷
        'レシートBitMapの読込み
        str = "Picture\" & oConf(0).sRLogoPass
        ret = oPrinter.SetBitmap(1, PTR_S_RECEIPT, str, PTR_BM_ASIS, PTR_BM_CENTER)
        pData = Chr(27) & "|1B" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '住所・TEL/FAX・URL印刷
        pData = Chr(27) & "|cA" & String.Format("〒{0} {1}", oConf(0).sPostCode, oConf(0).sAdderess1) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & String.Format("              {0}", oConf(0).sAdderess2) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & "TEL " & oConf(0).sTEL & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & "FAX " & oConf(0).sFAX & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        pData = Chr(27) & "|cA" & oConf(0).sURL & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '一括印刷　Off
        oPrinter.TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)

        '2016.07.13 K.Oikawa s 
        '課題表No151 領収書のカット設定追加(Star)
        'ラインフィード＆用紙カット
        'pData = Chr(27) & "|fP"
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = Chr(27) & "|fP"
            Case "EPSON"
                pData = Chr(27) & "|fP"
            Case "STAR"
                pData = Chr(27) & "|95fP"
        End Select
        '2016.07.13 K.Oikawa e
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

    End Sub
    Private Sub BILL_PRINT_ROTATE()


        Dim ret As Integer
        Dim pData As String
        Dim str As String
        Dim oTool As cTool

        oTool = New cTool


        'TODO:Starの領収書が正しい向きに印刷されていない
        'ローテート印刷 On (90度回転印刷モード設定)
        oPrinter.RotatePrint(PTR_S_RECEIPT, PTR_RP_RIGHT90)

        '改行
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '日付時間印刷
        pData = Chr(27) & "|cA" & Format(Now, "yyyy年MM月dd日")
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '「領収書」を印刷
        pData = Chr(27) & "|4C" & "  領  収  書　"
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '取引番号印刷
        str = "0000000000" & oTrn(0).sTrnCode
        str = oTool.MidB(str.ToString, str.Length - 9, 10)

        pData = Chr(27) & "|1C" &
               String.Format("取引番号:{0,10:##0}", str) & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '宛名印刷部分を印刷
        pData = Chr(27) & "|1uC" & Chr(27) & "|4C" & "　　　　　　　　　　様" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '請求金額を印刷
        pData = Chr(27) & "|1uC" & Chr(27) & "|4C" &
            String.Format("         {0,9:C}.-  ", oTrn(0).sTotalPrice)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        pData = Chr(27) & "|0uC" & Chr(27) & "|1C" &
            String.Format("  (消費税込み)") & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '但し書き部分印刷
        pData = Chr(27) & "|1C" &
               String.Format("（但し　　　　　　　として領収致しました）") & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)
        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ローテート印刷 On (90度回転印刷モード設定)
        '領収書BitMapの読込み
        ret = oPrinter.SetBitmap(2, PTR_S_RECEIPT, CStr(oConf(0).sBLogoPass), PTR_BM_ASIS, PTR_BM_CENTER)
        pData = Chr(27) & "|2B"
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        'ローテート印刷 Off (通常印刷モード設定)
        ret = oPrinter.RotatePrint(PTR_S_RECEIPT, PTR_RP_NORMAL)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '改行()
        pData = "" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

        '一括印刷　Off
        oPrinter.TransactionPrint(PTR_S_RECEIPT, PTR_TP_NORMAL)

        '2016.07.13 K.Oikawa s 
        '課題表No151 領収書のカット設定追加(Star)
        'ラインフィード＆用紙カット
        'pData = Chr(27) & "|fP"
        Select Case PRINTER_MAKER
            Case "TEC"
                pData = Chr(27) & "|fP"
            Case "EPSON"
                pData = Chr(27) & "|fP"
            Case "STAR"
                pData = Chr(27) & "|95fP"
        End Select
        '2016.07.13 K.Oikawa e
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

    End Sub


    Private Sub LED_CHANGE()
        If MEMBER_CODE_T.Text = "" Then
            GRAY_AKA_P.Visible = True
            AKA_P.Visible = False

            MEMBER_CODE = ""
            MEMBER_CODE_T.Text = ""
            MEMBER_NAME_T.Text = ""

            MEMBER_CODE_T.Visible = True
            MEMBER_NAME_T.Visible = True
        Else
            GRAY_AKA_P.Visible = False
            AKA_P.Visible = True

            MEMBER_CODE = MEMBER_CODE_T.Text
            MEMBER_CODE_T.Visible = True
            MEMBER_NAME_T.Visible = True

        End If

        If POINT_MEMBER_CODE_T.Text = "" Then
            GRAY_AO_P.Visible = True
            AO_P.Visible = False

            POINT_MEMBER_CODE = ""
            POINT_MEMBER_CODE_T.Text = ""
            POINT_MEMBER_NAME_T.Text = ""
        Else
            GRAY_AO_P.Visible = False
            AO_P.Visible = True

            POINT_MEMBER_CODE = POINT_MEMBER_CODE_T.Text
            POINT_MEMBER_CODE_T.Visible = True
            POINT_MEMBER_NAME_T.Visible = True
        End If

    End Sub

    '***********************************
    '   各種変数初期化処理
    '[引数]
    '   Mode　　：0 表示内容クリア
    '             1 ALLクリア
    '***********************************
    Sub VALUE_INIT(ByVal Mode As Integer)
        Dim i As Integer

        Select Case Mode
            Case 0
                T_MODE = 0
                PRODUCT_i = 0
                S_MODE = 0
                D_MODE = 0
                TRNCODE = TRNCODE_CREATE()
                OLDTRNCODE = 0
                SUB_TRNCODE = 1
                POSTAGE_CASH = 0
                FEE_CASH = 0
                TDELIVALY_T.Text = 0
                TFEE_T.Text = 0
                TRNCLASS = "売上"

                '明細行クリア
                For i = 0 To MEISAI_V.RowCount - 1
                    MEISAI_V.Rows.Clear()
                Next i

                UPRICE = 0
                UCOUNT = 0
                UCASH = 0
                UDISCOUNT = 0
                TOTAL_CASH = 0
                RECEIVE_CASH = 0
                CHANGE_CASH = 0
                DISCOUNT_CASH = 0
                DISCOUNT_RATE = 0
                PRODUCT_i = 0

                TRADE_CANCEL_B.Enabled = False
                GOUKEI_B.Enabled = False
                CASH_B.Enabled = False
                CREDIT_B.Enabled = False
                TRADE_RETURN_B.Enabled = False
                NOVEL_B.Enabled = False
                IN_SALES_B.Enabled = False

                '2019.10.17 R.Takashima
                sumDiscountFlag = False

                MORE_B.Enabled = False

                '会員LEDの表示切換え
                LED_CHANGE()

                CHANNEL_1_R.Enabled = True
                CHANNEL_2_R.Enabled = True
                CHANNEL_3_R.Enabled = True
                CHANNEL_4_R.Enabled = True
                CHANNEL_5_R.Enabled = True

                '返品モードラベル
                RETURN_MODE_L.Visible = False
            Case 1
                T_MODE = 1
                S_MODE = 0
                D_MODE = 0
                G_MODE = False
                TRADE_CANCEL_B.Enabled = True
                GOUKEI_B.Enabled = True
                If CHANNEL_1_R.Checked = True Then
                    CHANNEL_2_R.Enabled = False
                    CHANNEL_3_R.Enabled = False
                    CHANNEL_4_R.Enabled = False
                    CHANNEL_5_R.Enabled = False
                Else
                    If CHANNEL_2_R.Checked = True Then
                        CHANNEL_1_R.Enabled = False
                        CHANNEL_3_R.Enabled = False
                        CHANNEL_4_R.Enabled = False
                        CHANNEL_5_R.Enabled = False
                    Else
                        If CHANNEL_3_R.Checked = True Then
                            CHANNEL_1_R.Enabled = False
                            CHANNEL_2_R.Enabled = False
                            CHANNEL_4_R.Enabled = False
                            CHANNEL_5_R.Enabled = False
                        Else
                            If CHANNEL_4_R.Checked = True Then
                                CHANNEL_1_R.Enabled = False
                                CHANNEL_2_R.Enabled = False
                                CHANNEL_3_R.Enabled = False
                                CHANNEL_5_R.Enabled = False
                            Else
                                If CHANNEL_5_R.Checked = True Then
                                    CHANNEL_1_R.Enabled = False
                                    CHANNEL_2_R.Enabled = False
                                    CHANNEL_3_R.Enabled = False
                                    CHANNEL_4_R.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            Case 2
                'T_MODE = 1
                S_MODE = 1
                D_MODE = 0
            Case 3
                '明細バッファクリア
                ReDim oMeisai(-1)
            Case 4
                POINT_i = 0
                POINT_MEMBER_CODE = 0
                POINT_MEMBER_CODE_T.Text = ""
                POINT_MEMBER_NAME_T.Text = ""

                '会員LEDの表示切換え
                LED_CHANGE()
            Case 5  '返品モード
                T_MODE = 2
                PRODUCT_i = 0
                S_MODE = 0
                D_MODE = 0
                TRNCODE = TRNCODE_CREATE()
                OLDTRNCODE = 0
                SUB_TRNCODE = 1
                POSTAGE_CASH = 0
                FEE_CASH = 0
                TDELIVALY_T.Text = 0
                TFEE_T.Text = 0
                TRNCLASS = "売上"

                '明細行クリア
                For i = 0 To MEISAI_V.RowCount - 1
                    MEISAI_V.Rows.Clear()
                Next i

                UPRICE = 0
                UCOUNT = 0
                UCASH = 0
                UDISCOUNT = 0
                TOTAL_CASH = 0
                RECEIVE_CASH = 0
                CHANGE_CASH = 0
                DISCOUNT_CASH = 0
                DISCOUNT_RATE = 0
                PRODUCT_i = 0

                '2016.06.13 K.Oikawa s
                '課代表.No78　戻入(返品)処理でも処理の取り消しを行えるようにする
                'TRADE_CANCEL_B.Enabled = False
                TRADE_CANCEL_B.Enabled = True
                '2016.06.13 K.Oikawa e

                GOUKEI_B.Enabled = False
                CASH_B.Enabled = False
                CREDIT_B.Enabled = False
                TRADE_RETURN_B.Enabled = False
                NOVEL_B.Enabled = False
                IN_SALES_B.Enabled = False

                MORE_B.Enabled = False

                '会員LEDの表示切換え
                LED_CHANGE()

                CHANNEL_1_R.Enabled = True
                CHANNEL_2_R.Enabled = True
                CHANNEL_3_R.Enabled = True
                CHANNEL_4_R.Enabled = True
                CHANNEL_5_R.Enabled = True

                DISPLAY_T.Text = ""

                '返品モードラベル
                RETURN_MODE_L.Visible = True

        End Select
    End Sub
    '**************************************************
    '商品情報クリア処理処理
    '   （クリア対象項目）
    '       1）JANコード
    '       2）商品コード
    '       3）商品名称
    '       4）サイズ
    '       5）カラー
    '       6）定価
    '       7）販売価格
    '       8）仕入価格
    '      ------ これ以降はモード１の場合のみ -----------
    '       9）会員コード
    '      10）会員名称
    '[引数]
    '   なし
    '**************************************************
    Function DISPLAY_CLR(ByVal Mode As Integer) As Boolean
        JAN_CODE_T.Text = ""
        PRODUCT_CODE_T.Text = ""
        PRODUCT_NAME_T.Text = ""
        OPTION_1_T.Text = ""
        OPTION_2_T.Text = ""
        OPTION_3_T.Text = ""
        OPTION_4_T.Text = ""
        OPTION_5_T.Text = ""
        PRICE_T.Text = ""
        SALE_PRICE_T.Text = ""
        TAX_PRICE_T.Text = ""
        STOCK_CNT_T.Text = ""

        If Mode = 1 Then
            '会員LEDの表示切換え
            LED_CHANGE()
        End If
    End Function

    Function TRNCODE_CREATE() As Long

        TRNCODE = oDataTrnDBIO.readMaxTrnCode(oTran)

        TRN_CODE_T.Text = TRNCODE
        TRNCODE_CREATE = TRNCODE
    End Function

    '2019.10.15 R.Takashima FROM
    '値引時の商品情報をセットする。
    Private Sub DISCOUNT_SET(ByVal discountClass As String)
        OPTION_1_T.Text = ""
        OPTION_2_T.Text = ""
        OPTION_3_T.Text = ""
        OPTION_4_T.Text = ""
        OPTION_5_T.Text = ""

        PRICE_T.Text = ""
        SALE_PRICE_T.Text = ""
        TAX_PRICE_T.Text = ""

        Select Case discountClass
            Case "(値引き)"
                '明細行のJANコードがどちらの値引きか判断し、オプションに金額または割合かを判断
                If MEISAI_V("JANコード", MEISAI_V.CurrentCell.RowIndex).Value = DISCOUNT_R Then
                    PRODUCT_NAME_T.Text = "％値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "%)"
                Else
                    PRODUCT_NAME_T.Text = "金額値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "円)"
                End If

            Case "(送料)"
                PRODUCT_NAME_T.Text = "送料(" & MEISAI_V("金額", MEISAI_V.CurrentCell.RowIndex).Value & "円)"

            Case "(手数料)"
                PRODUCT_NAME_T.Text = "手数料(" & MEISAI_V("金額", MEISAI_V.CurrentCell.RowIndex).Value & "円)"

            Case "(会員値引き)"
                '明細行のJANコードがどちらの値引きか判断し、オプションに金額または割合かを判断
                If MEISAI_V("JANコード", MEISAI_V.CurrentCell.RowIndex).Value = DISCOUNT_R Then
                    PRODUCT_NAME_T.Text = "％値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "%)"
                Else
                    PRODUCT_NAME_T.Text = "金額値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "円)"
                End If

            Case "(ポイント値引き)"
                PRODUCT_NAME_T.Text = "ポイント値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "円)"

            Case "(チケット値引き)"
                PRODUCT_NAME_T.Text = "チケット値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "円)"

            Case "(合計値引き)"
                '明細行のJANコードがどちらの値引きか判断し、オプションに金額または割合かを判断
                If MEISAI_V("JANコード", MEISAI_V.CurrentCell.RowIndex).Value = DISCOUNT_R Then
                    PRODUCT_NAME_T.Text = "％値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "%)"
                Else
                    PRODUCT_NAME_T.Text = "金額値引き(" & MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value & "円)"
                End If

            Case Else
                Exit Sub
        End Select

    End Sub
    '2019.10.15 R.Takashima TO

    Private Sub DISCOUNT_PROC(ByVal Mode As String)
        Dim ret As Boolean

        'キー入力音出力
        oTool.PlaySound()

        '2019.10.17 R.Takashima FROM
        '合計値引きが既に入力されている場合は合計値引きをしないようにする。
        If sumDiscountFlag = True And SUBTRNCLASS = M_DISCOUNT_T Then
            Beep()
            Dim message_form As New cMessageLib.fMessage(1,
                                              "合計値引きが既に入力されています。",
                                              "既に入力されているデータを削除してから",
                                              "もう一度入力をして下さい。", Nothing)

            message_form.ShowDialog()
            '表示クリア
            SET_TEXT_ABOVE_WINDOW(1, "0", "")

            JAN_CODE_T.Focus()
            message_form.Dispose()
            '2019.10.17 R.Takashima TO

        Else
            If Me.DISPLAY_T.Text = "0" Then            '未入力状態の場合
                Beep()
                MSG_T.Text = "価格が入力されていません"
                Dim message_form = New cMessageLib.fMessage(1,
                                              "価格が入力されていません",
                                              "価格を入力して下さい",
                                              Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                JAN_CODE_T.Focus()
            Else                                    '入力ありの場合
                ret = CAL_PROC(Mode)      '集計（カテゴリ番号）

                '2019.11.16 R.Takashima From
                '値引き額が入力されていないとき（D_MODE = 0）は
                '入力を促すメッセージを表示し、処理を終了させる
                If ret = False Then
                    Dim mes = New cMessageLib.fMessage(1,
                                                "金額が入力されていません。",
                                                "入力してから割引ボタンを押下してください。",
                                                Nothing,
                                                Nothing
                                                )
                    mes.ShowDialog()
                    mes.Dispose()

                    '入力モードのリセット
                    D_MODE = 0

                    '取引データ入力中を設定
                    T_MODE = 1

                    '取引明細区分=売上を設定
                    SUBTRNCLASS = 1

                    Exit Sub
                End If
                '2019.11.16 R.Takashima To

                '日次取引明細データ更新
                If Mode = "%" Then
                    DAY_SUBTRN_INSERT(Mode, DISCOUNT_RATE)
                Else
                    DAY_SUBTRN_INSERT(Mode, DISCOUNT_CASH)
                End If

                '明細行の表示
                ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), Mode)

                'ラインディスプレー表示 
                LINE_DISPLAY(D_RATE)

                '取引明細番号インクリメント
                SUB_TRNCODE = SUB_TRNCODE + 1

                '集計エリア表示
                SUM_DISPLAY()

                '表示クリア
                SET_TEXT_ABOVE_WINDOW(1, DISPLAY_T.Text, "")
                'JAN_CODE_T.Text = ""

                JAN_CODE_T.Focus()
                D_MODE = 0
                'CNT_T.Text = 1

                TRN_CODE_T.Text = TRNCODE
                TRNSUB_CODE.Text = SUB_TRNCODE

                If SUBTRNCLASS = M_DISCOUNT_T Then
                    sumDiscountFlag = True
                End If

            End If
        End If

        '取引データ入力中を設定
        T_MODE = 1

        '取引明細区分=売上を設定
        SUBTRNCLASS = 1

    End Sub
    Sub OTHER_PROC(ByVal Mode As Integer)
        Dim ret As Boolean

        'キー入力音出力
        oTool.PlaySound()

        If Me.DISPLAY_T.Text = "" Then            '未入力状態の場合
            Beep()
            MSG_T.Text = "価格が入力されていません"
            Dim message_form As New cMessageLib.fMessage(1,
                                              "価格が入力されていません",
                                              "価格を入力して下さい",
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            JAN_CODE_T.Focus()
        Else                                    '入力ありの場合
            If SUBTRNCLASS = M_POSTAGE Then     '送料入力の場合
                JAN_CODE_T.Text = ""
                PRODUCT_CODE_T.Text = ""
                PRODUCT_NAME_T.Text = "送料"
                OPTION_1_T.Text = ""
                OPTION_2_T.Text = ""
                OPTION_3_T.Text = ""
                OPTION_4_T.Text = ""
                OPTION_5_T.Text = ""
                PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
                SALE_PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)

                POSTAGE_CASH = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
                TDELIVALY_T.Text = DISPLAY_T.Text
                TOTAL_CASH = TOTAL_CASH + POSTAGE_CASH
            Else                                '手数料入力の場合
                JAN_CODE_T.Text = ""
                PRODUCT_CODE_T.Text = ""
                PRODUCT_NAME_T.Text = "手数料"
                OPTION_1_T.Text = ""
                OPTION_2_T.Text = ""
                OPTION_3_T.Text = ""
                OPTION_4_T.Text = ""
                OPTION_5_T.Text = ""
                PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
                SALE_PRICE_T.Text = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)

                FEE_CASH = CLng(DISPLAY_T.Text) * CInt(CNT_T.Text)
                TFEE_T.Text = DISPLAY_T.Text
                TOTAL_CASH = TOTAL_CASH + FEE_CASH
            End If

            '日次取引明細データ更新
            DAY_SUBTRN_INSERT(Nothing, Nothing)

            '明細行の表示
            ret = DAY_SUBTRN_DISPLAY(oSubTrn(0), -1)

            'ラインディスプレー表示 
            If Mode = POSTAGE Then
                LINE_DISPLAY(D_POSTAGE)
            Else
                LINE_DISPLAY(D_FEE)
            End If

            '取引明細番号のインクリメント
            SUB_TRNCODE = SUB_TRNCODE + 1

            '集計エリア表示
            SUM_DISPLAY()

            '表示クリア
            ret = DISPLAY_CLR(0)

            JAN_CODE_T.Focus()
            D_MODE = 0
            SET_TEXT_ABOVE_WINDOW(1)

            'KEY_LED_D_MODE("CATEGORY_1")
            TRN_CODE_T.Text = TRNCODE
            TRNSUB_CODE.Text = SUB_TRNCODE
        End If

        '取引データ入力中を設定
        T_MODE = 1

        '取引明細区分=売上を設定
        SUBTRNCLASS = 1

    End Sub

    Private Function BUMON_INDEX_GET(ByVal BumonName As String) As Integer
        Dim i As Integer

        For i = 0 To oBumon.Count - 1
            If BumonName = oBumon(i).sBumonShortName Then
                BUMON_INDEX_GET = i
                Exit For
            Else
                BUMON_INDEX_GET = -1
            End If
        Next
    End Function
    Private Sub FORECOLOR_CHANGE(ByVal sender)
        Dim con As RadioButton

        'バックカラー設定
        con = sender
        If con.Checked = True Then
            con.BackColor = Color.LightSalmon
        Else
            '2016.09.12 K.Oikawa s
            '課題表No.155 クリック前後で色が異なるので修正
            'con.BackColor = Color.Wheat
            con.BackColor = Color.Tan
            '2016.09.12 K.Oikawa e
        End If
    End Sub


    Private Sub BUMON_SET()
        Dim i As Integer
        Dim Con(CATEGORY_MAX - 1) As Softgroup.NetButton.NetButton

        Con(0) = Me.KATEGORY_1_B
        Con(1) = Me.KATEGORY_2_B
        Con(2) = Me.KATEGORY_3_B
        Con(3) = Me.KATEGORY_4_B
        Con(4) = Me.KATEGORY_5_B
        Con(5) = Me.KATEGORY_6_B
        Con(6) = Me.KATEGORY_7_B
        Con(7) = Me.KATEGORY_8_B

        BUMON_COUNT = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To BUMON_COUNT - 1
            Con(i).TextButton = oBumon(i).sBumonShortName
            Con(i).Enabled = True
        Next i
        For i = BUMON_COUNT To CATEGORY_MAX - 1
            Con(i).TextButton = ""
            Con(i).Enabled = False
        Next i

    End Sub

    Private Sub CHANNEL_SET()
        Dim i As Integer
        Dim RecordCount As Integer
        Dim Con(4) As Control
        Dim Seti As Integer

        Con(0) = Me.CHANNEL_1_R
        Con(1) = Me.CHANNEL_2_R
        Con(2) = Me.CHANNEL_3_R
        Con(3) = Me.CHANNEL_4_R
        Con(4) = Me.CHANNEL_5_R

        Seti = 1
        'リアル販売チャネルセット
        RecordCount = oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, True, oTran)
        For i = 0 To 4
            If oChannel(i).sChannelCode = oConf(0).sRegChannelCode Then
                CHANNEL_CODE = oChannel(i).sChannelCode
                Con(0).Text = oChannel(i).sChannelName
                Con(0).Enabled = True
            Else
                If i < RecordCount Then
                    Con(Seti).Text = oChannel(i).sChannelName
                    Con(Seti).Enabled = True
                Else
                    Con(Seti).Enabled = False
                End If
                Seti = Seti + 1
            End If
        Next i
    End Sub

    '******************************
    '     DataGridViewの設定
    '        ヘッダー生成
    '******************************
    Sub GRIDVIEW_CREATE()

        'レコードセレクタを非表示に設定
        MEISAI_V.RowHeadersVisible = False
        MEISAI_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "JANコード"
        MEISAI_V.Columns.Add(column1)
        column1.Width = 110
        column1.SortMode = DataGridViewColumnSortMode.NotSortable
        column1.Name = "JANコード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品コード"
        MEISAI_V.Columns.Add(column2)
        column2.Width = 75
        column2.SortMode = DataGridViewColumnSortMode.NotSortable
        column2.Name = "商品コード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "商品名称"
        MEISAI_V.Columns.Add(column3)
        column3.Width = 210
        column3.SortMode = DataGridViewColumnSortMode.NotSortable
        column3.Name = "商品名称"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "オプション"
        MEISAI_V.Columns.Add(column4)
        column4.Width = 240
        column4.SortMode = DataGridViewColumnSortMode.NotSortable
        column4.Name = "オプション"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "定価"
        MEISAI_V.Columns.Add(column5)
        column5.Width = 70
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.DefaultCellStyle.BackColor = Color.Wheat
        column5.SortMode = DataGridViewColumnSortMode.NotSortable
        column5.Name = "定価"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "販売価格"
        MEISAI_V.Columns.Add(column6)
        column6.Width = 70
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.SortMode = DataGridViewColumnSortMode.NotSortable
        column6.Name = "販売価格"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "数量"
        MEISAI_V.Columns.Add(column7)
        column7.Width = 60
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.SortMode = DataGridViewColumnSortMode.NotSortable
        column7.Name = "数量"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "金額"
        MEISAI_V.Columns.Add(column8)
        column8.Width = 70
        column8.DefaultCellStyle.Format = "c"
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.SortMode = DataGridViewColumnSortMode.NotSortable
        column8.Name = "金額"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "値引き"
        MEISAI_V.Columns.Add(column9)
        column9.Width = 70
        column9.DefaultCellStyle.Format = "c"
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.SortMode = DataGridViewColumnSortMode.NotSortable
        column9.Name = "値引き"

        Dim column10 As New DataGridViewTextBoxColumn
        column10.HeaderText = "取引コード"
        MEISAI_V.Columns.Add(column10)
        column10.Width = 70
        column10.Visible = False
        column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column10.SortMode = DataGridViewColumnSortMode.NotSortable
        column10.Name = "取引コード"

        Dim column11 As New DataGridViewTextBoxColumn
        column11.HeaderText = "取引明細コード"
        MEISAI_V.Columns.Add(column11)
        column11.Width = 70
        column11.Visible = False
        column11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column11.SortMode = DataGridViewColumnSortMode.NotSortable
        column11.Name = "取引明細コード"

        Dim column12 As New DataGridViewTextBoxColumn
        column12.HeaderText = "返金額"
        MEISAI_V.Columns.Add(column12)
        column12.Width = 70
        column12.Visible = False
        column12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column12.SortMode = DataGridViewColumnSortMode.NotSortable
        column12.Name = "返金額"


        '行列の幅調整
        'MEISAI.ColumnHeadersHeight = 30

        '背景色を白に設定
        MEISAI_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        MEISAI_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub STAFF_ENTRY()
        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.cStaffEntry
        staff_form = New cStaffEntryLib.cStaffEntry(oConn, oCommand, oDataReader, STAFF_CODE, STAFF_NAME, oTran)
        staff_form = Nothing
    End Sub
    Private Sub CUSTMOER_ENTRY()
        '顧客属性ウィンドウ表示
        Customer_form.STAFF_CODE_T.Text = STAFF_CODE_T.Text
        Customer_form.STAFF_NAME_T.Text = STAFF_NAME_T.Text

        Customer_form.ShowDialog(WEATHER)

        '会員登録画面を"決定"で終了した場合
        If Customer_form.DialogResult <> Windows.Forms.DialogResult.Cancel Then
            If Customer_form.MEMBER_CODE_T.Text <> "" Then
                'MEMBER_CODE = Customer_form.MEMBER_CODE_T.Text
                'MEMBER_CODE_T.Text = Customer_form.MEMBER_CODE_T.Text
                'MEMBER_NAME_T.Text = Customer_form.MEMBER_NAME_T.Text

                MEMBER_SET(Customer_form.MEMBER_CODE_T.Text)

            Else
                MEMBER_CODE = ""
                MEMBER_CODE_T.Text = ""
                MEMBER_NAME_T.Text = ""

                '会員LEDの表示切換え
                LED_CHANGE()
            End If
            SEX = Customer_form.SEX_T.Text
            GENERATION = Customer_form.GEN_T.Text
            WEATHER = Customer_form.WEATHER_T.Text
        Else
            Customer_form.Dispose()
            Application.DoEvents()
            Application.Exit()
        End If
    End Sub
    Public Sub FUNC_SET()
        If oConf(0).sFunc_Name1 = Nothing Then
            PG_1_B.Enabled = False
            PG_1_B.TextButton = "－"
        Else
            PG_1_B.Enabled = True
            PG_1_B.TextButton = oConf(0).sFunc_Name1
        End If
        If oConf(0).sFunc_Name2 = Nothing Then
            PG_2_B.Enabled = False
            PG_2_B.TextButton = "－"
        Else
            PG_2_B.Enabled = True
            PG_2_B.TextButton = oConf(0).sFunc_Name2
        End If
        If oConf(0).sFunc_Name3 = Nothing Then
            PG_3_B.Enabled = False
            PG_3_B.TextButton = "－"
        Else
            PG_3_B.Enabled = True
            PG_3_B.TextButton = oConf(0).sFunc_Name3
        End If
        If oConf(0).sFunc_Name4 = Nothing Then
            PG_4_B.Enabled = False
            PG_4_B.TextButton = "－"
        Else
            PG_4_B.Enabled = True
            PG_4_B.TextButton = oConf(0).sFunc_Name4
        End If
        If oConf(0).sFunc_Name5 = Nothing Then
            PG_5_B.Enabled = False
            PG_5_B.TextButton = "－"
        Else
            PG_5_B.Enabled = True
            PG_5_B.TextButton = oConf(0).sFunc_Name5
        End If

    End Sub



    '2019.10.10 R.Takashima FROM
    '***************************************************
    ' レジスター画面上部にあるテキストボックスに値を入れる
    ' 別のオーバーロードされているメソッドから呼び出されている。
    '[引数]
    '    count     : 商品の個数   int
    '    salePrice : 販売価格     string
    '    janCode   : JANコード    string
    '[変数]
    '    notChange : テキストボックス内の値を変えたくないときに使う
    '***************************************************

    Private Overloads Sub SET_TEXT_ABOVE_WINDOW(ByVal count As Integer, ByVal salePrice As String, ByVal janCode As String)
        Dim notChange As String = "NOT_CHANGE"

        CNT_T.Text = count

        If salePrice <> notChange Then
            DISPLAY_T.Text = salePrice
        End If

        If janCode <> notChange Then
            JAN_CODE_T.Text = janCode
        End If
    End Sub

    '***************************************************
    '              
    '[引数]
    '    count     : 商品の個数   int
    '    salePrice : 販売価格     string
    '***************************************************
    Private Overloads Sub SET_TEXT_ABOVE_WINDOW(ByVal count As Integer, ByVal salePrice As String)
        SET_TEXT_ABOVE_WINDOW(count, salePrice, "NOT_CHANGE")
    End Sub

    '***************************************************
    '              
    '[引数]
    '    count                 : 商品の個数
    '***************************************************
    Private Overloads Sub SET_TEXT_ABOVE_WINDOW(ByVal count As Integer)
        SET_TEXT_ABOVE_WINDOW(count, "NOT_CHANGE", "NOT_CHANGE")
    End Sub

    '***************************************************      
    '[引数]
    '    sViewProductSalePrice : 構造体  
    '    count                 : 商品の個数
    '***************************************************
    Private Overloads Sub SET_TEXT_ABOVE_WINDOW(ByVal count As Integer, ByVal pProductSalePrice As cStructureLib.sViewProductSalePrice)
        Dim p As String = pProductSalePrice.sSalePrice
        Dim j As String = pProductSalePrice.sJANCode

        '2019.10.11 条件式の追加
        If IsNothing(p) Then
            p = "NOT_CHANGE"
        End If
        If IsNothing(j) Then
            j = "NOT_CHANGE"
        End If

        SET_TEXT_ABOVE_WINDOW(count, p, j)
    End Sub
    '2019.10.10 R.Takashima TO



    '2019.10.6 R.Takashima コメントの追加
    '***********************************************************************
    '                       以下イベント受取メソッド
    '***********************************************************************
#Region "イベント受取"
    '2019.10.6 R.Takashima
    Private Sub JAN_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JAN_CODE_T.GotFocus
        Me.JAN_CODE_T.SelectAll()
    End Sub

    '**************************************************
    'JANコード－フォーカスアウト
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************
    Private Sub JAN_CODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JAN_CODE_T.LostFocus
        If (JAN_CODE_T.Text <> "") Then
            JAN_CODE_SEARCH(JAN_CODE_T.Text, Nothing)
        End If
    End Sub


    '2019.10.6 R.Takashima CASH_Click　こちらに移動
    '**************************************************
    '現金ボタンクリック
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************
    Private Sub CASH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '精算モード設定
        SEISAN_MODE = CASH

        SEISAN_PROC(sender)

    End Sub

    Private Sub INPUT_MONEY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 1, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub

    '2019.10.6 R.Takashima
    'MEISAI_V_CellClick , MEISAI_V_DoubleClick
    'こちらに移動
    Private Sub MEISAI_V_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MEISAI_V.CellClick
        If T_MODE = 2 Then
            MEISAI_V.CurrentCell = Nothing
            Exit Sub
        End If

    End Sub

    '**************************************************
    '選択した明細行を削除する
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************
    Private Sub MEISAI_V_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEISAI_V.DoubleClick
        Dim RowNo As Integer

        '2016.06.23 K.Oikawa s
        '課代表.No117 ヘッダのみの状態でヘッダをクリックした際にエラー発生
        'ヘッダのみの場合は処理を行わない
        If MEISAI_V.RowCount = 0 Then
            Exit Sub
        End If
        '2016.06.23 K.Oikawa e

        If T_MODE = 2 Then
            MEISAI_V.CurrentCell = Nothing
            Exit Sub
        End If

        Dim message_form As New cMessageLib.fMessage(2,
                                      "明細を削除します",
                                      "よろしいですか？",
                                      Nothing, Nothing)
        message_form.ShowDialog()
        If message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            '取引明細データ削除
            RowNo = MEISAI_V.CurrentRow.Index
            oSubDataTrnDBIO.deleteSubTrn(CLng(MEISAI_V("取引コード", RowNo).Value), CLng(MEISAI_V("取引明細コード", RowNo).Value), Nothing, oTran)

            '2016.06.24 K.Oikawa s
            '課代表.No94 値引き等の金額は空文字ではなく0となっている
            'If MEISAI_V("金額", RowNo).Value.ToString = "" Then
            If MEISAI_V("金額", RowNo).Value.ToString = 0 Then
                '2016.06.24 K.Oikawa e

                '2019.10.17 R.Takashima FROM
                '合計値引きが削除されたら入力できるようにする。
                If MEISAI_V("商品名称", RowNo).Value.ToString = "(合計値引き)" Then
                    sumDiscountFlag = False
                End If
                '2019.10.17 R.Takashima TO

                TOTAL_CASH = TOTAL_CASH - MEISAI_V("値引き", RowNo).Value  '本商品までの合計金額を計算
                MEISAI_V.Rows.RemoveAt(RowNo)

            Else
                    TOTAL_CASH = TOTAL_CASH - MEISAI_V("金額", RowNo).Value + MEISAI_V("値引き", RowNo).Value  '本商品までの合計金額を計算

                '2016.06.23 K.Oikawa s
                '課代表.No87 参照できない行数を参照してしまうためエラーとなるので修正
                'If MEISAI_V.RowCount > 1 Then
                If MEISAI_V.RowCount > RowNo + 1 Then
                    '2016.06.23 K.Oikawa e
                    '2016.06.24 K.Oikawa s
                    '課代表.No93 商品に対する値引き等の削除が機能していない
                    'If MEISAI_V("金額", RowNo + 1).Value.ToString = "" Then
                    If MEISAI_V("金額", RowNo + 1).Value.ToString = 0 Then
                        '2016.06.24 K.Oikawa e
                        MEISAI_V.Rows.RemoveAt(RowNo + 1)
                    End If
                End If
                MEISAI_V.Rows.RemoveAt(RowNo)
            End If

            DISPLAY_T.Text = TOTAL_CASH                             '合計金額を画面に表示
            DISCOUNT_CASH = 0                                       '値引き額の設定
            D_MODE = 0                                              '入力中フラグをリセット
            SUM_DISPLAY()

            DISPLAY_T.Text = CLng(SBILL_T.Text)
            TOTAL_CASH = CLng(SBILL_T.Text)

            ' 課題表No.170対応 2016.09.05 K.Minagawa START
            PRODUCT_CODE_T.Text = ""
            PRODUCT_NAME_T.Text = ""
            PRICE_T.Text = ""
            OPTION_1_T.Text = ""
            OPTION_2_T.Text = ""
            OPTION_3_T.Text = ""
            OPTION_4_T.Text = ""
            OPTION_5_T.Text = ""
            STOCK_CNT_T.Text = ""
            PRICE_T.Text = ""
            SALE_PRICE_T.Text = ""
            TAX_PRICE_T.Text = ""
            ' 課題表No.170対応 2016.09.05 K.Minagawa END

        End If
        If MEISAI_V.RowCount = 0 Then
            VALUE_INIT(0)
        End If
        JAN_CODE_T.Focus()
        message_form = Nothing
    End Sub
    Private Sub MEISAI_V_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MEISAI_V.CellEnter
        '2019.10.9 R.Takashima FROM
        'IF文とELSE以下のコメントアウト
        'オプションがない商品の場合テキストボックス内の金額が表示されないため
        'If MEISAI_V("オプション", MEISAI_V.CurrentCell.RowIndex).Value <> "" Then

        '2019.10.15 R.Takashima FROM
        'ifの追加
        If MEISAI_V("商品コード", MEISAI_V.CurrentCell.RowIndex).Value <> "" Then
            oMstProductDBIO.getProductSalePrice(oProductSalePrice,
                                             CHANNEL_CODE,
                                             MEISAI_V("商品コード", MEISAI_V.CurrentCell.RowIndex).Value,
                                             Nothing,
                                             oTran)

            PRODUCT_SET(oProductSalePrice(0))

            '2019.11.15 R.Takashima From
            '初期化をしないと別の場所で異なる値が入る
            ReDim oProductSalePrice(0)
            '2019.11.15 R.Takashima To

        Else
            '2019.10.15 R.Takashima FROM
            '値引時の商品情報を処理
            DISCOUNT_SET(MEISAI_V("商品名称", MEISAI_V.CurrentCell.RowIndex).Value)
            '2019.10.15 R.Takashima TO
        End If

        JAN_CODE_T.Text = ""


        '2016.09.14 K.Oikawa s
        '課題表No.181 物販等の画面下部変更追加
        'Else
        '    PRODUCT_CODE_T.Text = MEISAI_V("商品コード", MEISAI_V.CurrentCell.RowIndex).Value
        '    PRODUCT_NAME_T.Text = MEISAI_V("商品名称", MEISAI_V.CurrentCell.RowIndex).Value
        '    OPTION_1_T.Text = ""
        '    OPTION_2_T.Text = ""
        '    OPTION_3_T.Text = ""
        '    OPTION_4_T.Text = ""
        '    OPTION_5_T.Text = ""
        '    PRICE_T.Text = 0
        '    SALE_PRICE_T.Text = String.Format("{0,9:C}", CInt(MEISAI_V("販売価格", MEISAI_V.CurrentCell.RowIndex).Value))
        '    TAX_PRICE_T.Text = 0

        '    DISPLAY_T.Text = MEISAI_V("販売価格", MEISAI_V.CurrentCell.RowIndex).Value

        'STOCK_CNT_T.Text = 0
        ''2016.09.14 K.Oikawa e
        'End If

        '2019.10.10 R.Takashima TO

    End Sub

    '2019.10.6 R.Takashima
    'CHANNELラジオボタンがクリックされたときに呼び出されるメソッドを
    'こちらに移動
    Private Sub CHANNEL_1_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_1_R.CheckedChanged
        FORECOLOR_CHANGE(sender)
        CHANNEL_CHANGED(sender, CHANNEL_1_R)
    End Sub

    Private Sub CHANNEL_2_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_2_R.CheckedChanged
        FORECOLOR_CHANGE(sender)
        CHANNEL_CHANGED(sender, CHANNEL_2_R)
    End Sub

    Private Sub CHANNEL_3_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_3_R.CheckedChanged
        FORECOLOR_CHANGE(sender)
        CHANNEL_CHANGED(sender, CHANNEL_3_R)
    End Sub

    Private Sub CHANNEL_4_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_4_R.CheckedChanged
        FORECOLOR_CHANGE(sender)
        CHANNEL_CHANGED(sender, CHANNEL_4_R)
    End Sub

    Private Sub CHANNEL_5_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_5_R.CheckedChanged
        FORECOLOR_CHANGE(sender)
        CHANNEL_CHANGED(sender, CHANNEL_5_R)
    End Sub

    '2019.10.6 R.Takashima CHANNEL_G_LostFocusメソッドをこちらに移動
    Private Sub CHANNEL_G_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_G.LostFocus
        Dim selectButton As RadioButton
        Dim i As Integer

        i = 0
        For Each selectButton In CHANNEL_G.Controls
            If selectButton.Checked Then
                oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, sender.text, Nothing, oTran)
                CHANNEL_CODE = oChannel(0).sChannelCode
                Exit For
            End If
            i = i + 1
        Next
    End Sub

    Private Sub PG_1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_1_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path1
        'process1.StartInfo.FileName = oConf(0).sFunc_Path1
        process1.Start()

    End Sub

    Private Sub PG_2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_2_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path2
        process1.StartInfo.Arguments = MEMBER_CODE_T.Text & " " & CHANNEL_CODE & " " & STAFF_CODE_T.Text
        process1.Start()

    End Sub

    Private Sub PG_3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_3_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path3
        process1.Start()

    End Sub

    Private Sub PG_4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_4_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path4
        process1.Start()

    End Sub

    Private Sub PG_5_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_5_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path5
        process1.Start()

    End Sub

    Private Sub PG_6_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim process1 As New Process

        process1.StartInfo.FileName = oConf(0).sFunc_Path6
        process1.Start()

    End Sub

    Private Sub KATEGORY_1_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_1_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_2_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_2_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_3_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_3_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_4_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_4_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_5_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_5_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_6_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_6_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_7_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_7_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub KATEGORY_8_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles KATEGORY_8_B.Click
        '2019.10.6 R.Takashima
        '同様の処理をしているため統合
        'KATEGOTY_BUTTOM_PROC(sender, Nothing)
        PRODUCT_SET_PROC(sender, Nothing)

    End Sub

    Private Sub MORE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MORE_B.Click
        Dim i As Integer

        D_MODE = 1

        'カレント商品のブロックの最下位行を検索
        For i = (MEISAI_V.RowCount - 1) To 0 Step -1
            If MEISAI_V("JANコード", i).Value = "(値引き)" Or
                MEISAI_V("JANコード", i).Value = "(会員値引き)" Or
                MEISAI_V("JANコード", i).Value = "(合計値引き)" Then
            Else
                JAN_CODE_SEARCH(MEISAI_V("JANコード", i).Value, MEISAI_V("商品コード", i).Value)
                Exit For
            End If
        Next

    End Sub

    Private Sub CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLR_B.Click
        If DISPLAY_T.Text = "" Then
            Exit Sub
        End If
        KEY_INPUT(D_MODE, "CLR")
        DISPLAY_CLR(0)

    End Sub

    Private Sub COUNT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COUNT_B.Click
        KEY_INPUT(D_MODE, "×")

    End Sub

    Private Sub MANEN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANEN_B.Click
        '2019.10.9 R.Takashima 
        '最初の初期化時にDISPLAY_Tは０に設定してあるため
        '条件式を"0"に変更
        'If DISPLAY_T.Text = "" Then
        If DISPLAY_T.Text <> "0" Then
            KEY_INPUT(D_MODE, "0000")
        End If
    End Sub

    Private Sub DROWER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DROWER_B.Click
        'ドローワーオープン
        DROWER_OPEN()

    End Sub

    Private Sub NUM_7_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_7_B.Click
        KEY_INPUT(D_MODE, "7")

    End Sub

    Private Sub NUM_8_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_8_B.Click
        KEY_INPUT(D_MODE, "8")

    End Sub

    Private Sub NUM_9_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_9_B.Click
        KEY_INPUT(D_MODE, "9")

    End Sub

    Private Sub NUM_4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_4_B.Click
        KEY_INPUT(D_MODE, "4")

    End Sub

    Private Sub NUM_5_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_5_B.Click
        KEY_INPUT(D_MODE, "5")

    End Sub

    Private Sub NUM_6_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_6_B.Click
        KEY_INPUT(D_MODE, "6")

    End Sub

    Private Sub NUM_1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_1_B.Click
        KEY_INPUT(D_MODE, "1")

    End Sub

    Private Sub NUM_2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_2_B.Click
        KEY_INPUT(D_MODE, "2")

    End Sub

    Private Sub NUM_3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_3_B.Click
        KEY_INPUT(D_MODE, "3")

    End Sub

    Private Sub NUM_0_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_0_B.Click
        '2019.10.9 R.Takashima 
        '最初の初期化時にDISPLAY_Tは０に設定してあるため
        '条件式を"0"に変更
        'If DISPLAY_T.Text = "" Then
        If DISPLAY_T.Text <> "0" Then
            KEY_INPUT(D_MODE, "0")
        End If
    End Sub

    Private Sub NUM_00_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_00_B.Click
        '2019.10.9 R.Takashima 
        '最初の初期化時にDISPLAY_Tは０に設定してあるため
        '条件式を"0"に変更
        'If DISPLAY_T.Text = "" Then
        If DISPLAY_T.Text <> "0" Then
            KEY_INPUT(D_MODE, "00")
        End If
    End Sub

    Private Sub NUM_DOT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUM_DOT_B.Click
        If DISPLAY_T.Text = "" Then
            Exit Sub
        End If
        If (D_MODE = 1) Then
            KEY_INPUT(D_MODE, ".")
        Else
            KATEGORY_1_B.Focus()
        End If

    End Sub

    Private Sub DISCOUNT_RATE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISCOUNT_RATE_B.Click
        '取引明細区分=単品値引きを設定
        If G_MODE = False Then                          '合計値引きモード＝Offの場合
            SUBTRNCLASS = M_DISCOUNT_U
        Else
            SUBTRNCLASS = M_DISCOUNT_T
        End If

        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            DISCOUNT_PROC(DISCOUNT_R)
        End If
    End Sub

    Private Sub DISCOUNT_CASH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISCOUNT_CASH_B.Click

        '取引明細区分=値引きを設定
        If G_MODE = False Then                          '合計値引きモード＝Offの場合
            SUBTRNCLASS = M_DISCOUNT_U
        Else
            SUBTRNCLASS = M_DISCOUNT_T
        End If

        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            DISCOUNT_PROC(DISCOUNT_K)
        End If
    End Sub

    Private Sub DISCOUNT_POINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISCOUNT_POINT_B.Click
        Dim fPointCheck_form As fPointCheck
        Dim fPointCardRead_form As fPointCardRead
        Dim pUsePoint As Long

        If POINT_MEMBER_CODE_T.Text = "" Then
            fPointCardRead_form = New fPointCardRead(oConn, oCommand, oDataReader, oTran)
            fPointCardRead_form.ShowDialog()
            If fPointCardRead_form.DialogResult = Windows.Forms.DialogResult.OK Then
                POINT_MEMBER_CODE_T.Text = fPointCardRead_form.POINT_MEMBER_CODE_T.Text
                POINT_MEMBER_CODE = fPointCardRead_form.POINT_MEMBER_CODE_T.Text

                '2016.06.27 K.Oikawa s
                '課代表No118 直接ポイントを入力してポイント会員の選択をせずに「完了」するとエラー
                'ポイント会員コードが空なら処理しない
                If POINT_MEMBER_CODE = "" Then
                    Exit Sub
                End If
                '2016.06.27 K.Oikawa e

                'ポイント会員設定
                POINT_MEMBER_SET(POINT_MEMBER_CODE)
            Else
                fPointCardRead_form.Dispose()
                fPointCardRead_form = Nothing
                Exit Sub
            End If
        End If

        'ポイントチェックウィンドウ表示
        If D_MODE = 0 Then
            pUsePoint = 0
        Else
            pUsePoint = CLng(DISPLAY_T.Text)
        End If

        fPointCheck_form = New fPointCheck(oConn, oCommand, oDataReader, oConf(0), POINT_MEMBER_CODE, TOTAL_CASH, pUsePoint, oTran)

        fPointCheck_form.ShowDialog()
        If fPointCheck_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
            fPointCheck_form.Dispose()
            fPointCheck_form = Nothing
            Exit Sub
        End If
        USE_POINT_i = USE_POINT_i + CLng(fPointCheck_form.USE_POINT_T.Text)
        POINT_i = POINT_INSERT(0, CLng(fPointCheck_form.USE_POINT_T.Text))
        DISPLAY_T.Text = fPointCheck_form.USE_POINT_T.Text
        D_MODE = 1

        '取引明細区分=値引きを設定
        SUBTRNCLASS = M_DISCOUNT_P
        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            DISCOUNT_PROC(Nothing)
        End If
    End Sub

    Private Sub TICKET_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TICKET_B.Click

        '取引明細区分=値引きを設定
        SUBTRNCLASS = M_DISCOUNT_C

        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            DISCOUNT_PROC(Nothing)
        End If
    End Sub

    Private Sub POSTAGE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSTAGE_B.Click

        '取引明細区分=送料を設定
        SUBTRNCLASS = M_POSTAGE

        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            OTHER_PROC(POSTAGE)
        End If

    End Sub

    Private Sub FEE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEE_B.Click

        '取引明細区分=手数料を設定
        SUBTRNCLASS = M_FEE

        If T_MODE = 2 Then
            EDIT_FEE_TRN()
        Else
            OTHER_PROC(Nothing)
        End If
    End Sub

    Private Sub INPUT_MONEY_B_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INPUT_MONEY_B.Click
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 1, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub

    Private Sub OUTPUT_MONEY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUTPUT_MONEY_B.Click
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 2, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub

    Private Sub PRODUCT_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_SEARCH_B.Click
        Dim fProductSearch As cSelectLib.fProductSearch
        Dim ProductCode As String
        Dim recCount As Long

        fProductSearch = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, Nothing, oTran)
        fProductSearch.ShowDialog()
        ProductCode = fProductSearch.S_PRODUCT_CODE_T.Text
        fProductSearch.Dispose()
        fProductSearch = Nothing

        Application.DoEvents()

        '商品情報セット
        If ProductCode <> "" Then
            ReDim oProductSalePrice(0)
            recCount = oMstProductDBIO.getProductSalePrice(oProductSalePrice, CHANNEL_CODE, ProductCode, Nothing, oTran)
            If recCount = 0 Then
                Dim message_form As New cMessageLib.fMessage(1,
                      "指定チャネルの価格が設定されていません",
                      "価格設定を確認して下さい。",
                      Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
            Else

                'JAN_CODE_T.Text = oProductSalePrice(0).sJANCode

                'DISPLAY_T.Text = oProductSalePrice(0).sSalePrice

                '2019.10.10 R.Takashima
                SET_TEXT_ABOVE_WINDOW(CNT_T.Text,
                                      oProductSalePrice(0).sSalePrice,
                                      oProductSalePrice(0).sJANCode)

                JAN_CODE_SEARCH(JAN_CODE_T.Text, oProductSalePrice(0).sProductCode)

                'D_MODE = 1

                'pBumonName = oBumonDBIO.getBumonShortName(oProductSalePrice(0).sProductClass, oTran)

                'KATEGOTY_BUTTOM_PROC(Nothing, pBumonName)

            End If
        End If

    End Sub

    Private Sub BILL_PRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BILL_PRINT_B.Click
        If STAFF_CODE_T.Text = "" Then
            Dim message_form As New cMessageLib.fMessage(1,
                                  Nothing,
                                  "担当者を設定して下さい",
                                  Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            JAN_CODE_T.Focus()
            Exit Sub
        End If
        Bill_PRINTING(TRNCODE - 1, CHANNEL_CODE)

    End Sub

    Private Sub REPRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPRINT_B.Click

        '2016.07.04 K.Oikawa s
        'RECEIPT_PRINTING()
        '課題表No134　再発行が機能していない ここで画面に取引コードをセットし直すなどの処理が必要
        'フラグ設定：取引コードを読み込むが、返品処理ではない
        If Not IsNumeric(TRNCODE) Then
            Exit Sub
        End If

        R_MODE = True

        '取得したJANコード(取引コード)を使って読み込み
        If TRN_SEARCH(oTool.JANCD("98" _
                  & String.Format("{0:0}", CHANNEL_CODE) _
                  & String.Format("{0:000000000}", TRNCODE - 1)
                 )) Then

            TRN_SET(oTrn)

            RECEIPT_PRINTING()

            VALUE_INIT(0)

            R_MODE = False

        End If
        '2016.07.04 K.Oikawa e

        '2019.10.25 R.Takashima From
        '返品時や取引中止時にはレシート発行しないが
        '再発行時はレシートの発行が出来るため、出来ないように修正

        'R_MODE = True

        ''取得したJANコード(取引コード)を使って読み込み
        'While True
        '    If TRN_SEARCH(oTool.JANCD("98" _
        '          & String.Format("{0:0}", CHANNEL_CODE) _
        '          & String.Format("{0:000000000}", TRNCODE - 1)
        '         )) Then
        '        If oTrn(0).sTrnClass <> "中止" And oTrn(0).sTrnClass <> "戻入" Then

        '            TRN_SET(oTrn)

        '            RECEIPT_PRINTING()

        '            VALUE_INIT(0)

        '            R_MODE = False
        '        Else
        '            TRNCODE -= 1
        '        End If
        '    Else
        '        Exit While
        '    End If
        'End While
        '2019.10.25 R.Takashima To
        '2016.07.04 K.Oikawa e
    End Sub

    Private Sub FEED_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEED_B.Click
        Dim ret As Integer
        Dim pData As String

        pData = Chr(27) & "|uF" & Chr(10)
        ret = oPrinter.PrintNormal(PTR_S_RECEIPT, pData)

    End Sub

    Private Sub TRADE_CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRADE_CANCEL_B.Click
        If MEISAI_V.Rows.Count >= 0 Then
            Dim message_form As New cMessageLib.fMessage(2,
                                      "現在入力中の取引を中止します。",
                                      "よろしいですか？",
                                      Nothing, Nothing)
            message_form.ShowDialog()
            If message_form.DialogResult = Windows.Forms.DialogResult.No Then
                message_form = Nothing
                Exit Sub
            End If
            message_form = Nothing

            '取引区分設定
            TRNCLASS = "中止"

            '精算モード設定
            SEISAN_MODE = CANCEL

            '取引コードの再取得
            If sender.TextButton = "取引中止" Then
                TRNCODE = TRNCODE_CREATE()
            End If

            '日次取引データ登録
            DAY_TRN_INSERT(sender)

            'ラインディスプレー表示 
            LINE_DISPLAY(D_MESSAGE)
        End If

        oTran.Commit()
        oTran = Nothing

        '画面初期化
        DISP_INIT("MEMBER")
        DISP_INIT("REG")
        DISP_INIT("PRODUCT")
        DISP_INIT("SUM")

        '変数初期化
        VALUE_INIT(0)

        'TRN完了モード設定
        T_MODE = 0

        'JANコードにフォーカスセット
        JAN_CODE_T.Focus()

        'トランザクションの開始
        oTran = oConn.BeginTransaction

    End Sub

    Private Sub GOUKEI_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GOUKEI_B.Click
        Dim fPointCheck_form As fPointCheck

        '2019.10.15 R.Takashima
        '合計ボタン押下前に数字ボタンを入力すると預かり金額を入力時に
        '数字が残ってしまうため入力モードを変更している。
        D_MODE = 0

        If T_MODE <> 2 Then     '返品モード以外の場合
            'ポイントメンバーの場合、利用ポイント数の入力
            If POINT_MEMBER_CODE <> "" Then
                fPointCheck_form = New fPointCheck(oConn, oCommand, oDataReader, oConf(0), POINT_MEMBER_CODE, TOTAL_CASH, 0, oTran)
                fPointCheck_form.ShowDialog()
                If fPointCheck_form.DialogResult = Windows.Forms.DialogResult.Cancel Or CLng(fPointCheck_form.USE_POINT_T.Text) = 0 Then
                    fPointCheck_form.Dispose()
                    fPointCheck_form = Nothing
                Else
                    USE_POINT_i = USE_POINT_i + CLng(fPointCheck_form.USE_POINT_T.Text)
                    POINT_i = POINT_INSERT(0, CLng(fPointCheck_form.USE_POINT_T.Text))
                    DISPLAY_T.Text = fPointCheck_form.USE_POINT_T.Text
                    fPointCheck_form.Dispose()
                    fPointCheck_form = Nothing

                    D_MODE = 1

                    '取引明細区分=値引きを設定
                    SUBTRNCLASS = M_DISCOUNT_P

                    DISCOUNT_PROC(Nothing)
                End If
            End If

            'キー入力音出力
            oTool.PlaySound()

            '取引明細区分=値引きを設定
            SUBTRNCLASS = M_DISCOUNT_T


            '合計算出
            TOTAL_CASH = CLng(TBILL_T.Text)

            '合計金額表示
            DISPLAY_T.Text = TOTAL_CASH

            'ラインディスプレー表示 
            LINE_DISPLAY(D_TOTAL)

            DISP_INIT("PRODUCT")

            '精算ボタンイネーブル
            '2019.11.15 R.Takashima From
            'チャンネルによって信用払いのみの場合があるため修正
            'CASH_B.Enabled = True
            'CREDIT_B.Enabled = True
            If oChannel(0).sChannelClass = 1 Then
                CASH_B.Enabled = True
                CREDIT_B.Enabled = True
                NOVEL_B.Enabled = True
                IN_SALES_B.Enabled = True
            ElseIf oChannel(0).sChannelClass = 2 Then
                CASH_B.Enabled = False
                CREDIT_B.Enabled = True
                NOVEL_B.Enabled = False
                IN_SALES_B.Enabled = False
            End If
            '2016.09.12 K.Oikawa s
            '課題表No.169 返品モード以外で「戻入」は使用しない
            'TRADE_RETURN_B.Enabled = True
            TRADE_RETURN_B.Enabled = False
            '2016.09.12 K.Oikawa e

            'NOVEL_B.Enabled = True
            'IN_SALES_B.Enabled = True

            '2019.11.15 R.Takashima To

            '合計モード On
            G_MODE = True

                MORE_B.Enabled = False
            Else    '返品モードの場合

                '2016.06.28 K.Oikawa s
                'ポイントメンバーの場合、利用ポイント数の入力
                'If POINT_MEMBER_CODE <> "" Then
                '    fPointCheck_form = New fPointCheck(oConn, oCommand, oDataReader, oConf(0), POINT_MEMBER_CODE, TOTAL_CASH * -1, 0, oTran)
                '    fPointCheck_form.ShowDialog()
                '    If fPointCheck_form.DialogResult = Windows.Forms.DialogResult.Cancel Or CLng(fPointCheck_form.USE_POINT_T.Text) = 0 Then
                '        fPointCheck_form.Dispose()
                '        fPointCheck_form = Nothing
                '    Else
                '        USE_POINT_i = USE_POINT_i + CLng(fPointCheck_form.USE_POINT_T.Text)
                '        POINT_i = POINT_INSERT(0, CLng(fPointCheck_form.USE_POINT_T.Text))
                '        DISPLAY_T.Text = fPointCheck_form.USE_POINT_T.Text
                '        fPointCheck_form.Dispose()
                '        fPointCheck_form = Nothing

                '        D_MODE = 1

                '        '取引明細区分=値引きを設定
                '        SUBTRNCLASS = M_DISCOUNT_P

                '        DISCOUNT_PROC(Nothing)
                '    End If
                'End If
                '2016.06.28 K.Oikawa e

                'キー入力音出力
                oTool.PlaySound()

            '取引明細区分=値引きを設定
            SUBTRNCLASS = M_DISCOUNT_T


            '合計算出
            TOTAL_CASH = CLng(TBILL_T.Text)

            '合計金額表示
            DISPLAY_T.Text = TOTAL_CASH

            'ラインディスプレー表示 
            LINE_DISPLAY(D_TOTAL)

            DISP_INIT("PRODUCT")

            '精算ボタンイネーブル
            CASH_B.Enabled = False
            CREDIT_B.Enabled = False
            TRADE_RETURN_B.Enabled = True
            NOVEL_B.Enabled = False
            IN_SALES_B.Enabled = False

            '合計モード On
            G_MODE = True

            MORE_B.Enabled = False
        End If
        JAN_CODE_T.Focus()

    End Sub
    'Private Sub MEMBER_DISCOUNT()
    '    '会員割引設定
    '    If MEMBER_CODE_T.Text <> "" Then
    '        '会員割引率が0以外の場合
    '        If oBumon(BUMON_INDEX).sMemberRate <> 0 Then

    '            '取引明細番号インクリメント
    '            SUB_TRNCODE = SUB_TRNCODE + 1

    '            '割引率を画面セット
    '            DISPLAY_T.Text = oBumon(BUMON_INDEX).sMemberRate

    '            '入力中モードをセット
    '            D_MODE = 1

    '            '取引明細区分=値引きを設定
    '            SUBTRNCLASS = 2

    '            DISCOUNT_PROC(DISCOUNT_R)
    '        End If
    '    End If

    '    JAN_CODE_T.Focus()
    'End Sub
    Private Sub TRADE_RETURN_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles TRADE_RETURN_B.Click
        '精算モード設定
        '2016.06.09 K.Oikawa s
        '課代表.No63 クレジット購入の商品を返品したい場合もあるので修正
        'SEISAN_MODE = CASH
        SEISAN_MODE = oTrn(0).sPaymentCode
        '2016.06.09 K.Oikawa e
        TRNCLASS = "戻入"
        SEISAN_PROC(sender)

    End Sub

    Private Sub NOVEL_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles NOVEL_B.Click
        '精算モード設定
        SEISAN_MODE = CASH
        TRNCLASS = "販促"
        SEISAN_PROC(sender)

    End Sub

    Private Sub IN_SALES_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles IN_SALES_B.Click
        '精算モード設定
        SEISAN_MODE = CASH
        TRNCLASS = "社販"
        SEISAN_PROC(sender)

    End Sub

    Private Sub CREDIT_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles CREDIT_B.Click
        '精算モード設定
        SEISAN_MODE = CREGIT

        SEISAN_PROC(sender)

    End Sub

    Private Sub CASH_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles CASH_B.Click
        '精算モード設定
        SEISAN_MODE = CASH

        SEISAN_PROC(sender)

    End Sub

    'Private Sub MEMBER_B_Click(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles MEMBER_B.Click
    '    Dim fMember_form As cSelectLib.fMemberSearch
    '    Dim RecordCount As Integer

    '    '繧ｭ繝ｼ蜈･蜉幃浹蜃ｺ蜉・
    '    PlaySound("C:\WINDOWS\Media\Windows XP Balloon.wav", 0, &H1)

    '    fMember_form = New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
    '    fMember_form.ShowDialog()
    '    If fMember_form.DialogResult = Windows.Forms.DialogResult.OK Then
    '        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)

    '        RecordCount = oMstMemberDBIO.getMember(oMember, _
    '                                               fMember_form.MEMBER_CODE_T.Text, _
    '                                               "", _
    '                                               "", _
    '                                               Nothing, _
    '                                               oTran)
    '        MEMBER_CODE_T.Text = oMember(0).sMemberCode
    '        MEMBER_NAME_T.Text = oMember(0).sMemberName
    '        LED_CHANGE()
    '    End If

    'End Sub

    Private Sub EXIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXIT_B.Click
        '#If HARDWARE <> NONE Then

        '2019.10.24 R.Takashima
        '顧客情報ウィンドウを閉じる
        Customer_form.Dispose()

        '---------------------
        '   周辺機器オープン
        '---------------------

        'ドロワークローズ処理
        oDrawer.DrawerClose()
        oDrawer.SetDeviceEnabled(False)

        'プリンタークローズ処理
        oPrinter.Close()
        oDrawer.SetDeviceEnabled(False)

        'ラインディスプレークローズ処理
        oDisplay.ClearText()
        oDisplay.Close()
        oDrawer.SetDeviceEnabled(False)
        '#End If

        oConn = Nothing

        oDataTrnDBIO = Nothing
        oSubDataTrnDBIO = Nothing
        oBumonDBIO = Nothing
        oStaffDBIO = Nothing
        oMstProductDBIO = Nothing

        oTool = Nothing

        Application.Exit()

    End Sub

    Private Sub MEMBER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_B.Click
        Dim pMemberSearch = New fMemberSearch(oConn, oCommand, oDataReader, STAFF_CODE, STAFF_NAME, oTran)
        Dim message_form As cMessageLib.fMessage

        message_form = Nothing
        pMemberSearch.ShowDialog()
        If pMemberSearch.DialogResult = Windows.Forms.DialogResult.OK Then

            Select Case oMstMemberDBIO.getMemberStatus(pMemberSearch.MEMBER_CODE_T.Text, oTran)
                Case -1     '無効会員
                    message_form = New cMessageLib.fMessage(1, "",
                                                    "会員カードが無効です契約期間を確認して下さい。",
                                                    "",
                                                    "")
                    message_form.ShowDialog()
                    message_form = Nothing

                    MEMBER_CODE = ""
                    MEMBER_CODE_T.Text = ""
                    MEMBER_NAME_T.Text = ""

                Case -2     '登録なし
                    message_form = New cMessageLib.fMessage(1, "",
                                                    "会員コードが登録されていません。",
                                                    "",
                                                    "")
                    message_form.ShowDialog()

                    MEMBER_CODE = ""
                    MEMBER_CODE_T.Text = ""
                    MEMBER_NAME_T.Text = ""

                Case Else
                    MEMBER_CODE = ""
                    MEMBER_CODE_T.Text = ""
                    MEMBER_NAME_T.Text = ""
                    JAN_CODE_T.Text = pMemberSearch.MEMBER_CODE_T.Text
                    JAN_CODE_SEARCH(JAN_CODE_T.Text, Nothing)

            End Select


            If IsNothing(message_form) = False Then
                message_form = Nothing
            End If

            pMemberSearch.Dispose()
            pMemberSearch = Nothing

        End If
    End Sub

    Private Sub POINT_MEMBER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_MEMBER_B.Click
        Dim pPointMemberSearch = New fPointMemberSearch(oConn, oCommand, oDataReader, STAFF_CODE, STAFF_NAME, oTran)
        Dim message_form As cMessageLib.fMessage

        message_form = Nothing
        pPointMemberSearch.ShowDialog()
        If pPointMemberSearch.DialogResult = Windows.Forms.DialogResult.OK Then

            Select Case oMstPointMemberDBIO.getPointMemberStatus(pPointMemberSearch.POINT_MEMBER_CODE_T.Text, oTran)
                Case -1     '無効会員
                    message_form = New cMessageLib.fMessage(1, "",
                                                    "ポイント会員カードが無効です契約期間を確認して下さい。",
                                                    "",
                                                    "")
                    message_form.ShowDialog()
                    message_form = Nothing

                    POINT_MEMBER_CODE = ""
                    POINT_MEMBER_CODE_T.Text = ""
                    POINT_MEMBER_NAME_T.Text = ""

                Case -2     '登録なし
                    message_form = New cMessageLib.fMessage(1, "",
                                                    "ポイント会員コードが登録されていません。",
                                                    "",
                                                    "")
                    message_form.ShowDialog()

                    POINT_MEMBER_CODE = ""
                    POINT_MEMBER_CODE_T.Text = ""
                    POINT_MEMBER_NAME_T.Text = ""

                Case Else
                    POINT_MEMBER_CODE = ""
                    POINT_MEMBER_CODE_T.Text = ""
                    POINT_MEMBER_NAME_T.Text = ""
                    JAN_CODE_T.Text = pPointMemberSearch.POINT_MEMBER_CODE_T.Text
                    JAN_CODE_SEARCH(JAN_CODE_T.Text, Nothing)

            End Select


            If IsNothing(message_form) = False Then
                message_form = Nothing
            End If

            pPointMemberSearch.Dispose()
            pPointMemberSearch = Nothing

        End If

    End Sub

    Private Sub MEISAI_V_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MEISAI_V.KeyPress
        If T_MODE = 2 Then
            MEISAI_V.CurrentCell = Nothing
            Exit Sub
        End If

    End Sub


    '2016.06.07 K.OIkawa s
    '課題表.No116 レシートがない場合の返品処理用に、過去の伝票を確認できるようにする
    Private Sub TRAN_HISTORY_B_Click(sender As Object, e As EventArgs) Handles TRAN_HISTORY_B.Click
        '履歴画面表示
        Dim TRAN_HIST_FORM As New cSelectLib.fTranHistSearch(oConn, oCommand, oDataReader, MEMBER_CODE, CHANNEL_CODE, oTran)
        TRAN_HIST_FORM.ShowDialog()
        '選択された履歴から取引情報を「返品処理」として表示する
        If TRAN_HIST_FORM.DialogResult = Windows.Forms.DialogResult.OK Then
            '取引コードで検索を行い返品(戻入)モードに切り替える
            If TRAN_HIST_FORM.TRN_CODE <> 0 Then

                'チャネル更新
                '差異判定
                CHANNEL_CHANGE(TRAN_HIST_FORM.CHANNEL_NAME)
                CHANNEL_CODE = TRAN_HIST_FORM.CHANNEL_CODE

                '取得したJANコード(取引コード)を使って返品モードへ移行する
                JAN_CODE_SEARCH(oTool.JANCD("98" _
                          & String.Format("{0:0}", TRAN_HIST_FORM.CHANNEL_CODE) _
                          & String.Format("{0:000000000}", TRAN_HIST_FORM.TRN_CODE)
                         ), Nothing)
                '指定した商品をJANコードを使って返品対象に指定
                JAN_CODE_SEARCH(String.Format("{0:0000000000000}", TRAN_HIST_FORM.JAN_CODE), Nothing)
            End If
        End If

        TRAN_HIST_FORM.Dispose()
        TRAN_HIST_FORM = Nothing

    End Sub


    Public Sub CHANNEL_CHANGE(ByVal CHANNEL_NAME As String)
        If CHANNEL_NAME <> "" Then
            Dim flg As Boolean = False
            '差異判定
            Select Case True
                Case Me.CHANNEL_1_R.Checked
                    If Me.CHANNEL_1_R.Text <> CHANNEL_NAME Then
                        Me.CHANNEL_1_R.BackColor = Color.Wheat
                        Me.CHANNEL_1_R.Checked = False
                        flg = True
                    End If
                Case Me.CHANNEL_2_R.Checked
                    If Me.CHANNEL_2_R.Text <> CHANNEL_NAME Then
                        Me.CHANNEL_2_R.BackColor = Color.Wheat
                        Me.CHANNEL_2_R.Checked = False
                        flg = True
                    End If
                Case Me.CHANNEL_3_R.Checked
                    If Me.CHANNEL_3_R.Text <> CHANNEL_NAME Then
                        Me.CHANNEL_3_R.BackColor = Color.Wheat
                        Me.CHANNEL_3_R.Checked = False
                        flg = True
                    End If
                Case Me.CHANNEL_4_R.Checked
                    If Me.CHANNEL_4_R.Text <> CHANNEL_NAME Then
                        Me.CHANNEL_4_R.BackColor = Color.Wheat
                        Me.CHANNEL_4_R.Checked = False
                        flg = True
                    End If
            End Select
            '変更があれば修正
            If flg = True Then
                Select Case CHANNEL_NAME
                    Case Me.CHANNEL_1_R.Text
                        Me.CHANNEL_1_R.BackColor = Color.LightSalmon
                        Me.CHANNEL_1_R.Checked = True
                    Case Me.CHANNEL_2_R.Text
                        Me.CHANNEL_2_R.BackColor = Color.LightSalmon
                        Me.CHANNEL_2_R.Checked = True
                    Case Me.CHANNEL_3_R.Text
                        Me.CHANNEL_3_R.BackColor = Color.LightSalmon
                        Me.CHANNEL_3_R.Checked = True
                    Case Me.CHANNEL_4_R.Text
                        Me.CHANNEL_4_R.BackColor = Color.LightSalmon
                        Me.CHANNEL_4_R.Checked = True
                End Select
            End If
        End If
    End Sub


    '2016.06.07 K.OIkawa e
#End Region
    '***********************************************************************
    '                               以上
    '***********************************************************************
End Class


