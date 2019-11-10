'#Const HARDWARE = CONNECT     '周辺機器の接続状態(開発用) NONE:未接続　CONNECT:接続


Public Class fCustomerOrder
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

    Private Const M_SALE = 1
    Private Const M_DISCOUNT_U = 2
    Private Const M_POSTAGE = 3
    Private Const M_FEE = 4
    Private Const M_DISCOUNT_M = 5
    Private Const M_DISCOUNT_P = 6
    Private Const M_DISCOUNT_C = 7
    Private Const M_DISCOUNT_T = 8
    Private Const M_MORE = 9

    Private Const RECEIPT_LEFT_MARGIN_STAR = "   "
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oTool As cTool
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTrn() As cStructureLib.sTrn
    Private oDataTrnDBIO As cDataTrnDBIO

    Private oSubTrn() As cStructureLib.sSubTrn
    Private oSubDataTrnDBIO As cDataTrnSubDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oViewBom() As cStructureLib.sViewBom
    Private oMstBomDBIO As cMstBomDBIO

    Private oStaffFull() As cStructureLib.sViewStaffFull
    Private oStaffDBIO As cMstStaffDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductSalePrice() As cStructureLib.sViewProductSalePrice
    Private oProductAndSales() As cStructureLib.sProductAndSales
    Private oMstProductDBIO As cMstProductDBIO

    Private oBufferNetImportCSV As cBufferNetImportCSV
    Private oDataRequestDBIO As cDataRequestDBIO
    Private oDataRequestSubDBIO As cDataRequestSubDBIO
    Private oDataRequestTMPDBIO As cDataRequestTMPDBIO
    Private oDataRequestSubTMPDBIO As cDataRequestSubTMPDBIO

    Private oMstMemberDBIO As cMstMemberDBIO
    Private oMember() As cStructureLib.sMember

    Private oDataPointDBIO As cDataPointDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMstOPOSDBIO As cMstOPOSDBIO
    Private oOPOS() As cStructureLib.sOPOS

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private parSubRequest() As cStructureLib.sRequestSubData
    Private oMemberCode() As cStructureLib.sMemberAndOrder
    Private oMstCustomerDBIO As cMstCustomerDBIO

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private oMstSalePriceDBIO As cMstSalePriceDBIO
    Private oPrice() As cStructureLib.sSalePrice

    Private oMeisai() As cStructureLib.sViewMeisai

    Private oDisplay As cOPOSControlLib.cDisplay
    Private oDrawer As cOPOSControlLib.cDrawer
    Private oPrinter As cOPOSControlLib.cPrinter
    Private oRequestData() As cStructureLib.sRequestData

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
    Private StackEventFlag As Boolean 'JANコード二重イベント回避用
    Private STACKCELL As String

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
    Private StackJanCode As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    '2016.06.28 K.Oikawa s
    Private returnOver As Integer
    '2016.06.28 K.Oikawa e

    '2016.07.04 K.Oikawa s
    Private R_MODE As Boolean
    '2016.07.04 K.Oikawa e

    Private StackHashtable As Hashtable
    Private StaticArrayList As ArrayList

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
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oMstBomDBIO = New cMstBomDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)
        oMstSalePriceDBIO = New cMstSalePriceDBIO(oConn, oCommand, oDataReader)
        oBufferNetImportCSV = New cBufferNetImportCSV(oConn, oCommand, oDataReader, oTran, 0)
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oDataRequestTMPDBIO = New cDataRequestTMPDBIO(oConn, oCommand, oDataReader)
        oDataRequestSubTMPDBIO = New cDataRequestSubTMPDBIO(oConn, oCommand, oDataReader)
        oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)
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

        Dim RecordCount As Long


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

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Environment.Exit(1)
            Exit Sub
        End If
        oMstConfigDBIO = Nothing


        '画面初期化
        DISP_INIT("MEMBER")
        DISP_INIT("REG")
        DISP_INIT("PRODUCT")
        DISP_INIT("SUM")

 
        'スタッフ入力ウィンドウ表示
        'STAFF_ENTRY()

        'STAFF_CODE_T.Text = STAFF_CODE
        ''STAFF_NAME_T.Text = STAFF_NAME

        'RecordCount = oStaffDBIO.getStaffFull(oStaffFull, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)


        '明細表示用データグリッドの生成
        GRIDVIEW_CREATE()

        '二重イベント回避フラグ
        StackEventFlag = False

        'JANコードにセットフォーカス
        JAN_CODE_T.Focus()

        '支払方法のセット
        PAYNEBT()

        'トランザクションの開始
        oTran = oConn.BeginTransaction

        'ハッシュテーブルの作成
        getAddress()

        '新規受注番号の用意
        REQUEST_NUMBER_CREATE(oConf(0).sRegChannelCode)


    End Sub


    '****************************************************************************************************************************
    '***********************************************************ボタン処理***********************************************
    '****************************************************************************************************************************

    '**************************************************
    '値引きー％ボタンクリック
    '[引数]
    '   規定値
    '[戻り値]
    '   なし
    '**************************************************


    Private Sub CHANNEL_CHANGED(ByVal sender As System.Object, ByVal CHECK_STATUS As Windows.Forms.RadioButton)
        If sender.Text <> "" And CHECK_STATUS.Checked = True Then
            oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, sender.Text, Nothing, oTran)
            CHANNEL_CODE = oChannel(0).sChannelCode

        End If
    End Sub

    Private Sub JAN_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JAN_CODE_T.GotFocus
        Me.JAN_CODE_T.SelectAll()
        StackJanCode = JAN_CODE_T.Text
    End Sub


    Private Function TRN_SEARCH(ByVal pTrnCode As String) As Boolean
        Dim recCount As Long
        Dim message_form As cMessageLib.fMessage

        ReDim oTrn(0)
        recCount = oDataTrnDBIO.getTrn(oTrn, pTrnCode.ToString.Substring(3, 9), CHANNEL_CODE, Nothing, Nothing, Nothing, oTran)
        If recCount = 0 Then
            message_form = New cMessageLib.fMessage(1, "取引コードが登録されていません。", _
                                                  "取引コードを確認して下さい。", _
                                                  "", _
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

        message_form = New cMessageLib.fMessage(2, _
                                  "取引データの修正モードに移行します。", _
                                  "よろしいですか？", _
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


    Private Sub MEISAI_UPDATE()
        Dim i As Integer
        Dim pMeisai() As cStructureLib.sViewMeisai
        Dim pgMode As Boolean

        'キー入力音出力
        oTool.PlaySound()

        If MEISAI_V.Rows.Count = 0 Then
            Exit Sub
        End If

        '日次取引明細データの削除
        oSubDataTrnDBIO.deleteSubTrn(TRNCODE, Nothing, Nothing, oTran)

        ReDim pMeisai(0)

        '明細エリアの退避
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


    End Sub

    Private Sub MEISAI_V_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MEISAI_V.CellClick
        If T_MODE = 2 Then
            MEISAI_V.CurrentCell = Nothing
            Exit Sub
        End If

    End Sub

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
            Select Case MEISAI_V("商品名称", i).Value.ToString
                Case "(値引き)"
                    If T_MODE <> 2 Then
                        sdiscount = sdiscount + MEISAI_V("値引き", i).Value        '単品値引き合計算出
                    Else
                        sdiscount = sdiscount + MEISAI_V("返金額", i).Value        '単品値引き合計算出（返品時）
                    End If
                Case "(会員値引き)"
                    If T_MODE <> 2 Then
                        sdiscount = sdiscount + MEISAI_V("値引き", i).Value        '単品値引き合計算出
                    Else
                        sdiscount = sdiscount + MEISAI_V("返金額", i).Value        '単品値引き合計算出（返品時）
                    End If
                Case "(合計値引き)"
                    If T_MODE <> 2 Then
                        tdiscount = tdiscount + MEISAI_V("値引き", i).Value         '合計値引き合計算出
                    Else
                        tdiscount = tdiscount + MEISAI_V("返金額", i).Value         '合計値引き合計算出（返品時）
                    End If
                Case "(ポイント値引き)"
                    If T_MODE <> 2 Then
                        pdiscount = pdiscount + MEISAI_V("値引き", i).Value         'ポイント値引き合計算出
                    Else
                        pdiscount = pdiscount + MEISAI_V("返金額", i).Value         'ポイント値引き合計算出（返品時）
                    End If
                Case "(チケット値引き)"
                    If T_MODE <> 2 Then
                        cdiscount = cdiscount + MEISAI_V("値引き", i).Value         'チケット値引き合計算出
                    Else
                        cdiscount = cdiscount + MEISAI_V("返金額", i).Value         'チケット値引き合計算出（返品時）
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
                    If T_MODE <> 2 Then
                        If MEISAI_V("数量", i).Value <> 0 Then
                            scount = scount + CInt(MEISAI_V("数量", i).Value)                 '数量合計算出
                        End If
                        If MEISAI_V("金額", i).Value <> 0 Then
                            stotal = stotal + CLng(MEISAI_V("金額", i).Value)                 '単価合計算出
                        End If
                    Else
                        If (CLng(MEISAI_V("返金額", i).Value) / CLng(MEISAI_V("販売価格", i).Value)) <> 0 Then
                            scount = scount + (CLng(MEISAI_V("返金額", i).Value) / CLng(MEISAI_V("販売価格", i).Value))             '数量合計算出
                        End If
                        If MEISAI_V("返金額", i).Value <> 0 Then
                            stotal = stotal + CLng(MEISAI_V("返金額", i).Value)                 '単価合計算出
                        End If
                    End If
            End Select
        Next i

        '2016.06.28 K.Oikawa s
        '課題表No125 返品モードの値引き額はマイナスで入ってくる
        'sbill = stotal - sdiscount                                              '合計金額算出
        'tbill = sbill + tdelivaly + tfee - tdiscount - pdiscount - cdiscount    '請求金額算出
        If T_MODE <> 2 Then
            sbill = stotal - sdiscount                                              '合計金額算出
            tbill = sbill + tdelivaly + tfee - tdiscount - pdiscount - cdiscount    '請求金額算出
        Else
            sbill = stotal + sdiscount                                              '合計金額算出
            tbill = sbill + tdelivaly + tfee + tdiscount + pdiscount + cdiscount    '請求金額算出
        End If
        '2016.06.28 K.Oikawa e

        If tbill < 0 Then
            tbill = 0
        End If

        '請求情報表示用変数
        Me.PRICE_T.Text = String.Format("{0,9:C}", stotal)             '商品代金画面セット
        Me.DISCOUNT_T.Text = String.Format("{0,9:C}", sdiscount)       '値引き画面セット
        '2016.06.02 K.Oikawa s
        '課代表.No90 税抜き金額を表示すべき箇所に税込み金額が表示されていたので修正
        'Me.SBILL_T.Text = String.Format("{0,9:C}", sbill)               '金額画面セット
        Me.OTHER_DISCOUNT_T.Text = String.Format("{0,9:C}", oTool.AfterToBeforeTax(sbill, oConf(0).sTax, oConf(0).sFracProc))               '金額画面セット
        '2016.06.02 K.Oikawa e

        Me.TAX_T.Text = String.Format("{0,9:C}", tdiscount)       '合計値引き画面セット
        Me.BILLING_AMOUNT_T.Text = String.Format("{0,9:C}", pdiscount)       'ポイント値引き画面セット
        Me.POSTAGE_T.Text = String.Format("{0,9:C}", tdelivaly)       '送料画面セット
        Me.TFEE_T.Text = String.Format("{0,9:C}", tfee)                 '手数料画面セット
        Me.ADVANCE_RECEIVED_T.Text = String.Format("{0,9:C}", tbill)               '請求金額画面セット
        Me.REMAINING_MONEY_T.Text = String.Format("{0,9:C}", oTool.AfterToTax(tbill, oConf(0).sTax, oConf(0).sFracProc))      '消費税画面セット

    End Sub
    '****************************************************************************************************************************
    '***********************************************************共通ファンクション***********************************************
    '****************************************************************************************************************************

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
                'MEMBER_CODE_T.Text = ""
                'MEMBER_NAME_T.Text = ""

                'POINT_MEMBER_CODE = ""
                'POINT_MEMBER_CODE_T.Text = ""
                'POINT_MEMBER_NAME_T.Text = ""

                USE_POINT_i = 0
                ADD_POINT_i = 0
                POINT_i = 0

            Case "REG"
                CNT_T.Text = 1
                JAN_CODE_T.Text = ""
            Case "SUM"
                PRICE_T.Text = 0
                DISCOUNT_T.Text = 0
                OTHER_DISCOUNT_T.Text = 0

                TAX_T.Text = 0
                POSTAGE_T.Text = 0
                TFEE_T.Text = 0
                ADVANCE_RECEIVED_T.Text = 0
                REMAINING_MONEY_T.Text = 0
        End Select
    End Sub

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

        oTrn = Nothing
        ReDim oTrn(0)

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
        oTrn(0).sNoTaxTotalProductPrice = (oTool.AfterToBeforeTax(CLng(PRICE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sShippingCharge = (oTool.AfterToBeforeTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sPaymentCharge = (oTool.AfterToBeforeTax(CLng(TFEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sDiscount = (oTool.AfterToBeforeTax(CLng(DISCOUNT_T.Text) + CLng(TAX_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * -1 * Ope
        oTrn(0).sPointDiscount = (oTool.AfterToBeforeTax(CLng(BILLING_AMOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * -1 * Ope
        oTrn(0).sTotalPrice = (CLng(ADVANCE_RECEIVED_T.Text)) * Ope
        oTrn(0).sTaxTotal = (CLng(REMAINING_MONEY_T.Text)) * Ope
        oTrn(0).sNoTaxTotalPrice = oTrn(0).sTotalPrice - oTrn(0).sTaxTotal
        oTrn(0).sDifference = oTrn(0).sNoTaxTotalPrice - _
                                  ( _
                                    (oTrn(0).sNoTaxTotalProductPrice * Ope) + _
                                    (oTrn(0).sShippingCharge * Ope) + _
                                    (oTrn(0).sPaymentCharge * Ope) + _
                                    (oTrn(0).sDiscount * Ope) + _
                                    (oTrn(0).sPointDiscount * Ope) + _
                                    (oTrn(0).sTicketDiscount * Ope) _
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

        oTrn = Nothing
        ReDim oTrn(0)

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
        oTrn(0).sNoTaxTotalProductPrice = (oTool.AfterToBeforeTax(CLng(PRICE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sShippingCharge = (oTool.AfterToBeforeTax(CLng(POSTAGE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sPaymentCharge = (oTool.AfterToBeforeTax(CLng(TFEE_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * Ope
        oTrn(0).sDiscount = (oTool.AfterToBeforeTax(CLng(DISCOUNT_T.Text) + CLng(TAX_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * -1 * Ope
        oTrn(0).sPointDiscount = (oTool.AfterToBeforeTax(CLng(BILLING_AMOUNT_T.Text), oConf(0).sTax, oConf(0).sFracProc)) * -1 * Ope

        '2016.06.28 K.Oikawa s
        'ポイントが足りない場合はここで減算
        'oTrn(0).sTotalPrice = (CLng(TBILL_T.Text)) * Ope
        oTrn(0).sTotalPrice = (CLng(ADVANCE_RECEIVED_T.Text - returnOver)) * Ope
        '2016.06.28 K.Oikawa e

        oTrn(0).sTaxTotal = (CLng(REMAINING_MONEY_T.Text)) * Ope
        oTrn(0).sNoTaxTotalPrice = oTrn(0).sTotalPrice - oTrn(0).sTaxTotal
        oTrn(0).sDifference = oTrn(0).sNoTaxTotalPrice - _
                                  ( _
                                    (oTrn(0).sNoTaxTotalProductPrice * Ope) + _
                                    (oTrn(0).sShippingCharge * Ope) + _
                                    (oTrn(0).sPaymentCharge * Ope) + _
                                    (oTrn(0).sDiscount * Ope) + _
                                    (oTrn(0).sPointDiscount * Ope) + _
                                    (oTrn(0).sTicketDiscount * Ope) _
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
                MEISAI_V.Rows.Add( _
                        parSubTrn.sJANCode, _
                        parSubTrn.sProductCode, _
                        parSubTrn.sProductName, _
                        opt, _
                        oTool.BeforeToAfterTax(parSubTrn.sListPrice, oConf(0).sTax, oConf(0).sFracProc), _
                        oTool.BeforeToAfterTax(parSubTrn.sUnitPrice, oConf(0).sTax, oConf(0).sFracProc), _
                        parSubTrn.sCount, _
                        parSubTrn.sPrice, _
                        oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc), _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
                )
                i = MEISAI_V.Rows.Count

                MEISAI_V.CurrentCell = MEISAI_V("JANコード", i - 1)

                ReDim Preserve oMeisai(i - 1)

                'On Error Resume Next
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
                oMeisai(i - 1).sJANCode = parSubTrn.sJANCode
                oMeisai(i - 1).sProductCode = parSubTrn.sProductCode
                oMeisai(i - 1).sProductName = parSubTrn.sProductName
                oMeisai(i - 1).sOption = opt
                oMeisai(i - 1).sPrice = oTool.BeforeToAfterTax(parSubTrn.sListPrice, oConf(0).sTax, oConf(0).sFracProc)
                oMeisai(i - 1).sSale_Price = oTool.BeforeToAfterTax(parSubTrn.sUnitPrice, oConf(0).sTax, oConf(0).sFracProc)
                oMeisai(i - 1).sCnt = parSubTrn.sCount
                oMeisai(i - 1).sTPrice = parSubTrn.sPrice
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc)
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
                MEISAI_V.Rows.Add( _
                        str2, _
                        str3, _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        0, _
                        DISCOUNT_CASH, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc)
                oMeisai(i - 1).sTrnCode = parSubTrn.sTrnCode
                oMeisai(i - 1).sSubTrnCode = parSubTrn.sSubTrnCode
            Case M_POSTAGE   '送料の場合
                str1 = "(送料)"
                MEISAI_V.Rows.Add( _
                        "", _
                        "", _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        POSTAGE_CASH, _
                        0, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                MEISAI_V.Rows.Add( _
                        "", _
                        "", _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        FEE_CASH, _
                        0, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                MEISAI_V.Rows.Add( _
                        str2, _
                        str3, _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        0, _
                        DISCOUNT_CASH, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                MEISAI_V.Rows.Add( _
                        str2, _
                        str3, _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        0, _
                        POINT_CASH, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                MEISAI_V.Rows.Add( _
                        str2, _
                        str3, _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        0, _
                        TICKET_CASH, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                MEISAI_V.Rows.Add( _
                        str2, _
                        str3, _
                        str1, _
                        "", _
                        0, _
                        0, _
                        0, _
                        0, _
                        DISCOUNT_CASH, _
                        parSubTrn.sTrnCode, _
                        parSubTrn.sSubTrnCode, _
                        0, _
                        0 _
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
                oMeisai(i - 1).sDPrice = oTool.BeforeToAfterTax(parSubTrn.sDiscountPrice, oConf(0).sTax, oConf(0).sFracProc)
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
            Dim message_form As New cMessageLib.fMessage(1, _
                                              errMsg, _
                                              "開発元に連絡して下さい", _
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
            Dim message_form As New cMessageLib.fMessage(1, _
                                              errMsg, _
                                              "開発元に連絡して下さい", _
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
            Dim message_form As New cMessageLib.fMessage(1, _
                                              errMsg, _
                                              "開発元に連絡して下さい", _
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
                    Case "(会員値引き)"
                        oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(送料)"
                        oSubTrn(0).sShipCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(手数料)"
                        oSubTrn(0).sPayCharge = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(合計値引き)"
                        oSubTrn(0).sDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(ポイント値引き)"
                        oSubTrn(0).sPointDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
                    Case "(チケット値引き)"
                        oSubTrn(0).sTicketDiscountPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc)
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

                '2016.06.28 K.Oikawa s
                'ポイントが足りない場合はここで減算
                'oSubTrn(0).sPrice = CLng(MEISAI_V("返金額", i).Value) * -1
                'oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax(CLng(MEISAI_V("返金額", i).Value), oConf(0).sTax, oConf(0).sFracProc) * -1
                oSubTrn(0).sPrice = (CLng(MEISAI_V("返金額", i).Value) - returnOver) * -1
                oSubTrn(0).sNoTaxPrice = oTool.AfterToBeforeTax((CLng(MEISAI_V("返金額", i).Value) - returnOver), oConf(0).sTax, oConf(0).sFracProc) * -1
                '2016.06.28 K.Oikawa e


                oSubTrn(0).sTaxPrice = oSubTrn(0).sPrice - oSubTrn(0).sNoTaxPrice
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
            Dim message_form As New cMessageLib.fMessage(1, _
                                              errMsg, _
                                              "開発元に連絡して下さい", _
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
            Dim message_form As New cMessageLib.fMessage(1, _
                                              errMsg, _
                                              "開発元に連絡して下さい", _
                                              Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
        End If

    End Function

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
        column1.HeaderText = "商品コード"
        MEISAI_V.Columns.Add(column1)
        MEISAI_V.Columns(0).ReadOnly = True
        column1.Width = 75
        column1.SortMode = DataGridViewColumnSortMode.NotSortable
        column1.Name = "商品コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "JANコード"
        MEISAI_V.Columns.Add(column2)
        MEISAI_V.Columns(1).ReadOnly = True
        column2.Width = 110
        column2.SortMode = DataGridViewColumnSortMode.NotSortable
        column2.Name = "JANコード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "商品名称"
        MEISAI_V.Columns.Add(column3)
        MEISAI_V.Columns(2).ReadOnly = True
        column3.Width = 210
        column3.SortMode = DataGridViewColumnSortMode.NotSortable
        column3.Name = "商品名称"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "オプション"
        MEISAI_V.Columns.Add(column4)
        MEISAI_V.Columns(3).ReadOnly = True
        column4.Width = 240
        column4.SortMode = DataGridViewColumnSortMode.NotSortable
        column4.Name = "オプション"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "定価"
        MEISAI_V.Columns.Add(column5)
        MEISAI_V.Columns(4).ReadOnly = True
        column5.Width = 70
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.DefaultCellStyle.BackColor = Color.Wheat
        column5.SortMode = DataGridViewColumnSortMode.NotSortable
        column5.Name = "定価"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "販売価格"
        MEISAI_V.Columns.Add(column6)
        MEISAI_V.Columns(5).ReadOnly = True
        column6.Width = 70
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.SortMode = DataGridViewColumnSortMode.NotSortable
        column6.Name = "販売価格"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "数量"
        MEISAI_V.Columns.Add(column7)
        MEISAI_V.Columns(6).ReadOnly = False
        column7.Width = 60
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.SortMode = DataGridViewColumnSortMode.NotSortable
        column7.Name = "数量"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "金額"
        MEISAI_V.Columns.Add(column8)
        MEISAI_V.Columns(7).ReadOnly = True
        column8.Width = 70
        column8.DefaultCellStyle.Format = "c"
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column8.SortMode = DataGridViewColumnSortMode.NotSortable
        column8.Name = "金額"

        '行列の幅調整
        'MEISAI.ColumnHeadersHeight = 30

        '背景色を白に設定
        MEISAI_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        MEISAI_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************
    '   各種変数初期化処理
    '[引数]
    '   Mode　　：0 表示内容クリア
    '             1 ALLクリア
    '***********************************

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

    Function TRNCODE_CREATE() As Long

        TRNCODE = oDataTrnDBIO.readMaxTrnCode(oTran)

        TRN_CODE_T.Text = TRNCODE
        TRNCODE_CREATE = TRNCODE
    End Function


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



    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fAdjustCount_form As New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 3, oTran)

        '現金情報入力画面表示
        fAdjustCount_form.ShowDialog()
        fAdjustCount_form = Nothing
    End Sub

    Private Sub STAFF_ENTRY()
        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.cStaffEntry
        staff_form = New cStaffEntryLib.cStaffEntry(oConn, oCommand, oDataReader, STAFF_CODE, STAFF_NAME, oTran)
        staff_form = Nothing
    End Sub

    Private Sub INPUT_MONEY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 1, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub


    Private Sub INPUT_MONEY_B_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 1, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub

    Private Sub OUTPUT_MONEY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adjust_form As cAdjustLib.fAdjustCount

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, 2, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        adjust_form.Dispose()
        adjust_form = Nothing

    End Sub

    'セルがダブルクリックされた場合、選択行の削除をする
    Private Sub MEISAI_V_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MEISAI_V.CellDoubleClick
        Dim message_form As cMessageLib.fMessage

        message_form = New cMessageLib.fMessage(5, "", _
                                "明細を削除します。。", _
                                "よろしいですか？", _
                                "")
        message_form.ShowDialog()

        If message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            Dim StaticRowIndex As Integer = MEISAI_V.CurrentCell.RowIndex
            MEISAI_V.Rows.RemoveAt(StaticRowIndex)
        Else

        End If

    End Sub

    Private Sub MEISAI_V_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles MEISAI_V.CellValueChanged
        Dim message_form As cMessageLib.fMessage
        Dim StaticRowIndex As Integer = MEISAI_V.CurrentCell.RowIndex
        If IsNumeric(MEISAI_V.SelectedCells.ToString) Then
            '現在のセルの行インデックスを表示

            Dim StaticPrice As Integer = MEISAI_V.Rows(StaticRowIndex).Cells(5).Value
            Dim StaticQuantity As Integer = MEISAI_V.Rows(StaticRowIndex).Cells(6).Value

            MEISAI_V(7, StaticRowIndex).Value = StaticPrice * StaticQuantity
        Else
            message_form = New cMessageLib.fMessage(1, "", _
                                    "数量には数字を入力してください。", _
                                    "", _
                                    "")
            message_form.ShowDialog()

            MEISAI_V.Focus()
            MEISAI_V.CurrentCell.Value = STACKCELL
        End If

    End Sub

    Private Sub MEISAI_V_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MEISAI_V.KeyPress
        If T_MODE = 2 Then
            MEISAI_V.CurrentCell = Nothing
            Exit Sub
        End If

    End Sub

    Private Sub MEISAI_V_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles MEISAI_V.CellBeginEdit
        STACKCELL = MEISAI_V.CurrentCell.Value

    End Sub

    '顧客検索ボタンが押下された場合
    Private Sub CUSTOMER_SEARCH_B_Click(sender As Object, e As EventArgs) Handles CUSTOMER_SEARCH_B.Click
        Dim StackSearch As fC_Search

        Dim Cell As cStructureLib.sMemberAndOrder = Nothing

        StackSearch = New fC_Search(oConn, oCommand, oDataReader, oTran, Cell)

        StackSearch.ShowDialog()

        If StackSearch.DialogResult = Windows.Forms.DialogResult.OK Then
            Cell = StackSearch.proCell

            MENBERS_CODE_T.Text = Cell.sMemberCode
            POSTAL_CODE_T.Text = Cell.sPostCode
            ADDRESS_T.Text = Cell.sAddress
            COMPANY_NAME_T.Text = Cell.sCorpName
            FULL_NAME_T.Text = Cell.sMemberName
            PHONE_NUMBER_T.Text = Cell.sTEL

        Else
            MEMBER_INIT()
        End If

        StackSearch = Nothing

    End Sub

    Private Sub EXIT_B_Click(sender As Object, e As EventArgs) Handles EXIT_B.Click
        oConn = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Abort

        Me.Close()
    End Sub

    Private Sub MEMBER_INIT()
        MENBERS_CODE_T.Text = ""
        POSTAL_CODE_T.Text = ""
        ADDRESS_T.Text = ""
        COMPANY_NAME_T.Text = ""
        FULL_NAME_T.Text = ""
        PHONE_NUMBER_T.Text = ""

    End Sub

    'コピーボタンが押下されたとき
    Private Sub COPY_B_Click(sender As Object, e As EventArgs) Handles COPY_B.Click

        SEND_POST_T.Text = POSTAL_CODE_T.Text
        SEND_ADDRESS_T.Text = ADDRESS_T.Text
        SEND_COMPANY_T.Text = COMPANY_NAME_T.Text
        SEND_NAME_T.Text = FULL_NAME_T.Text
        SEND_TEL_T.Text = PHONE_NUMBER_T.Text

    End Sub

    '支払方法のセット
    Private Sub PAYNEBT()
        Dim oMstChannelPaymentDBIO As cMstChannelPaymentDBIO
        Dim oChannelPayment() As cStructureLib.sChannelPayment

        oMstChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)
        ReDim oChannelPayment(0)

        oMstChannelPaymentDBIO.getChannelPaymentMst(oChannelPayment, Nothing, oConf(0).sRegChannelCode, Nothing, Nothing, oTran)

        For idx As Integer = 0 To UBound(oChannelPayment)
            PAYMENT_C.Items.Add(oChannelPayment(idx).sChannelPaymentName)
        Next

    End Sub

    '郵便番号からFocusが離れたときの処理
    Private Sub POSTAL_CODE_T_LostFocus(sender As Object, e As EventArgs) Handles POSTAL_CODE_T.LostFocus
        '住所欄が空白の場合のみ住所を自動的にセットする
        If ADDRESS_T.Text = "" Then
            '郵便番号に-がある場合に削除する
            Dim StaticPostCode As String = POSTAL_CODE_T.Text.Replace("-", "")

            'TODO:郵便番号をどうするか

            If StackHashtable.ContainsKey(StaticPostCode) Then
                ADDRESS_T.Text = StackHashtable(StaticPostCode)
            End If
        End If
    End Sub

    '郵便番号をキーにした住所情報のhashテーブルの作成
    Private Sub getAddress()
        Dim oMstPostCodeDBIO As cMstPostCodeDBIO
        Dim ParPostCode() As cStructureLib.sPostCode

        oMstPostCodeDBIO = New cMstPostCodeDBIO(oConn, oCommand, oDataReader)
        ReDim ParPostCode(0)

        StackHashtable = New Hashtable

        oMstPostCodeDBIO.getAddress(StackHashtable, oTran)

    End Sub

    'JANコードからフォーカスが離れた場合
    Private Sub JAN_CODE_T_LostFocus(sender As Object, e As EventArgs) Handles JAN_CODE_T.LostFocus
        If StackEventFlag = False Then
            StackEventFlag = True

            If (JAN_CODE_T.Text <> "") Then
                JAN_CODE_SEARCH(JAN_CODE_T.Text, Nothing)
            End If
            StackEventFlag = False
        End If
    End Sub

    Private Sub JAN_CODE_SEARCH(ByVal JanCode As String, ByVal ProductCode As String)
        Dim message_form As cMessageLib.fMessage
        ReDim parSubRequest(0)

        If JanCode.Length <= 3 Then
            Exit Sub
        End If

        oTool.PlaySound()

        D_MODE = 1

        Select Case JanCode.ToString.Substring(0, 3)
            Case "992"      '受注コード
                '入力されたときのJANコードが違う場合のみ実行する
                If JanCode <> StackJanCode Then
                    '注文者情報エリアと送付先情報エリアの情報を取得
                    oDataRequestDBIO.getOrdererInformation(oRequestData, _
                                                           JanCode, _
                                                           oTran)
                    '明細エリアの情報を取得
                    oDataRequestSubDBIO.OrderInformationItem(parSubRequest, _
                                                             JanCode, _
                                                             oTran)
                    '販売単価を取得する
                    For i = 0 To parSubRequest.Length - 1
                        oMstSalePriceDBIO.getSellingPrice(oPrice, _
                                                         parSubRequest(i).sProductCode, _
                                                         oConf(0).sRegChannelCode, _
                                                         oTran)
                    Next

                    '注文者情報と送付先情報をセットする
                    SET_INFORMATION()

                    '受注情報をセットする
                    RESULT_SET()

                    NEW_REGISTRATION_L.Visible = False
                    UPDATE_L.Visible = True

                    ORDER_NUMBER_T.Text = JanCode
                End If


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
            Case Else       'JANコード
                If PRODUCT_INFORMATION(JanCode) = 1 Then            '商品コードと販売価格が見つかった場合
                    If Not oPrice Is Nothing Then
                        SEARCH_RESULT_SET()
                    Else
                        message_form = New cMessageLib.fMessage(1, "", _
                                    "販売価格が登録されていません。", _
                                    "管理者にご連絡ください。", _
                                    "")
                        message_form.ShowDialog()
                    End If

                ElseIf PRODUCT_INFORMATION(JanCode) = 2 Then        '商品コードが見つからなかった場合
                    message_form = New cMessageLib.fMessage(1, "", _
                                    "商品コードが登録されていません。", _
                                    "管理者にご連絡ください。", _
                                    "")
                    message_form.ShowDialog()
                Else
                    message_form = New cMessageLib.fMessage(1, "", _
                                    "販売価格が登録されていません。", _
                                    "管理者にご連絡ください。", _
                                    "")
                    message_form.ShowDialog()
                End If

        End Select
    End Sub

    Private Function PRODUCT_INFORMATION(ByVal sJanCode As String)
        oProductAndSales = Nothing
        oPrice = Nothing
        '商品マスタから該当レコードを取得する
        oMstProductDBIO.getProductSearch(oProductAndSales, _
                                         sJanCode, _
                                         oTran)

        '上記の該当のレコードの商品コードを使い販売価格マスタから販売価格を取得する
        If Not oProductAndSales Is Nothing Then
            oMstSalePriceDBIO.getSellingPrice(oPrice, _
                                  oProductAndSales(0).sProductCode, _
                                  oConf(0).sRegChannelCode, _
                                  oTran)
            PRODUCT_INFORMATION = 1         '商品マスタが見つかった場合
        Else
            PRODUCT_INFORMATION = 2         '商品マスタが見つからなかった場合
        End If

    End Function

    Private Function MEMBER_SEARCH(ByVal pMemberCode As String) As Boolean
        Dim message_form As cMessageLib.fMessage

        Select Case oMstMemberDBIO.getMemberStatus(pMemberCode, oTran)
            Case -1     '無効会員
                message_form = New cMessageLib.fMessage(1, "", _
                                                "会員カードが無効です。", _
                                                "契約期間を確認して下さい。", _
                                                "")
                message_form.ShowDialog()
                message_form.Dispose()
                message_form = Nothing
                MEMBER_SEARCH = False
                Exit Function
            Case -2     '登録なし
                message_form = New cMessageLib.fMessage(1, "", _
                                                "会員コードが登録されていません。", _
                                                "", _
                                                "")
                message_form.Show()
                message_form.Dispose()
                message_form = Nothing
                MEMBER_SEARCH = False
                Exit Function
        End Select

        MEMBER_SEARCH = True

    End Function

    Private Sub MEMBER_SET(ByVal pMemberCode As String)
        Dim RecordCnt As Long

        ReDim oMember(0)
        RecordCnt = oMstMemberDBIO.getMember(oMember, pMemberCode, Nothing, Nothing, True, oTran)

        MEMBER_CODE = pMemberCode
        READ_MENBER_CODE_T.Text = pMemberCode
        MENBER_NAME_T.Text = oMember(0).sSubMemberName

        MENBERS_CODE_T.Text = oMember(0).sMemberCode
        POSTAL_CODE_T.Text = oMember(0).sPostCode
        ADDRESS_T.Text = oMember(0).sAddress1 & oMember(0).sAddress2 & oMember(0).sAddress3
        COMPANY_NAME_T.Text = ""
        FULL_NAME_T.Text = oMember(0).sSubMemberName
        PHONE_NUMBER_T.Text = oMember(0).sTEL


    End Sub

    Private Function POINT_MEMBER_SEARCH(ByVal pPointMemberCode As String) As Boolean
        Dim message_form As cMessageLib.fMessage

        Select Case oMstPointMemberDBIO.getPointMemberStatus(pPointMemberCode, oTran)
            Case -1
                message_form = New cMessageLib.fMessage(1, "", _
                                        "ポイント会員カードが無効です。", _
                                        "契約期間を確認して下さい。", _
                                        "")
                message_form.ShowDialog()
                message_form.Dispose()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
            Case -2
                message_form = New cMessageLib.fMessage(1, "ポイント会員コードが登録されていません。", _
                       "ポイント会員カードが有効か確認して下さい。", _
                       "", _
                       "")
                message_form.ShowDialog()
                message_form.Dispose()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
            Case -3
                message_form = New cMessageLib.fMessage(1, "ポイント会員コードが登録されていません。", _
                         "ポイント会員カードが有効か確認して下さい。", _
                         "", _
                         "")
                message_form.ShowDialog()
                message_form.Dispose()
                message_form = Nothing
                POINT_MEMBER_SEARCH = False
                Exit Function
        End Select

        POINT_MEMBER_SEARCH = True
    End Function

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
                message_form = New cMessageLib.fMessage(1, _
                                                 "ポイントカードの有効期限が切れています。", _
                                                 "カードを確認して下さい。", _
                                                 Nothing, Nothing)
                message_form.ShowDialog()
                message_form.Dispose()
                message_form = Nothing
                Exit Sub
            End If
        End If

        'ポイント会員の保有ポイント数取得
        POINT_i = oDataPointDBIO.getPoint(pPointMemberCode, oTran)

        POINT_MEMBER_CODE = pPointMemberCode
        READ_MENBER_CODE_T.Text = pPointMemberCode
        MENBER_NAME_T.Text = oPointMember(0).sPointMemberName

    End Sub

    '***********************************************
    '結果を明細画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        '明細画面の初期化
        MEISAI_V.Rows.Clear()

        '表示設定
        For i As Integer = 0 To oProductAndSales.Length - 1
            MEISAI_V.Rows.Add( _
                    oProductAndSales(i).sProductCode, _
                    oProductAndSales(i).sJANCode, _
                    oProductAndSales(i).sProductName, _
                    oProductAndSales(i).sOption, _
                    oProductAndSales(i).sListPrice, _
                    oPrice(i).sSalePrice, _
                    CNT_T.Text, _
                    oPrice(i).sSalePrice * CNT_T.Text
             )
        Next
        '請求商品代金を出す
        TOTAL_CALCULATION()

    End Sub
    '**********************
    '受注番号発番処理
    '**********************
    Private Sub REQUEST_NUMBER_CREATE(ByVal ChannelCode As Integer)
        Dim ORDER_NUMBER As String
        Dim MaxRequestCode As Long
        Dim MaxCode1 As Long
        Dim MaxCode2 As Long

        '受注情報データと受注情報データTMPから、最大の受注番号を取得
        MaxCode1 = oDataRequestDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        MaxCode2 = oDataRequestTMPDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        If MaxCode1 > MaxCode2 Then
            MaxRequestCode = MaxCode1
        Else
            MaxRequestCode = MaxCode2
        End If

        ORDER_NUMBER = "992" & String.Format("{0:0}", ChannelCode) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:00}", MaxRequestCode)

        'チェックデジットの生成
        JAN_CODE_T.Text = oTool.JANCD(ORDER_NUMBER)

        NEW_REGISTRATION_L.Visible = True

    End Sub

    '**********************
    '受注番号読込処理
    '**********************
    Private Function REQUEST_NUMBER_READ(ByVal ORRequestCode As String) As String
        Dim RecordCount As Long
        ReDim oRequestData(0)

        'OR受注コードが同じである、受注情報データの存在確認
        RecordCount = oDataRequestDBIO.getRequest(oRequestData, Nothing, Nothing, Nothing, Nothing, Nothing, ORRequestCode, Nothing, Nothing, Nothing, Nothing, 1, Nothing, Nothing, Nothing, oTran)

        'OR受注コードが同じである、受注情報データTMPの存在確認
        If RecordCount = 0 Then
            RecordCount = oDataRequestTMPDBIO.getRequest(oRequestData, Nothing, Nothing, Nothing, Nothing, ORRequestCode, oTran)
        End If

        REQUEST_NUMBER_READ = oRequestData(0).sRequestCode
    End Function
    '***********************************************
    '結果を明細画面にセット
    '***********************************************
    Sub RESULT_SET()

        '明細画面の初期化
        MEISAI_V.Rows.Clear()

        '表示設定
        For i As Integer = 0 To parSubRequest.Length - 1
            MEISAI_V.Rows.Add( _
                    parSubRequest(i).sProductCode, _
                    parSubRequest(i).sJANCode, _
                    parSubRequest(i).sProductName, _
                    parSubRequest(i).sOptionName & parSubRequest(i).sOptionValue, _
                    parSubRequest(i).sListPrice, _
                    oPrice(i).sSalePrice, _
                    parSubRequest(i).sCount, _
                    oPrice(i).sSalePrice * parSubRequest(i).sCount
             )
        Next
        '請求商品代金を出す
        TOTAL_CALCULATION()

    End Sub

    '請求商品代金を出す
    Private Sub TOTAL_CALCULATION()
        Dim stotal As Long

        stotal = 0

        For i = 0 To MEISAI_V.Rows.Count - 1
        stotal = stotal + CLng(MEISAI_V("金額", i).Value)
        Next

        PRICE_T.Text = stotal
    End Sub

    '注文者情報と送付先情報をセットする
    Private Sub SET_INFORMATION()

        MENBERS_CODE_T.Text = oRequestData(0).sBillPostCode1 * oRequestData(0).sBillPostCode2

    End Sub
End Class

