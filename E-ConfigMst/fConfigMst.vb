Public Class fConfigMst
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTool As cTool

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oOPOS() As cStructureLib.sOPOS
    Private oMstOPOSDBIO As cMstOPOSDBIO

    Private oSoft() As cStructureLib.sSoft
    Private oMstSoftDBIO As cMstSoftDBIO

    Private oDB_Path As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

        'DB_PATH レジストリー読込み
        DB_PATH_T.Text = oTool.RegistryRead("File1")
        BK_PATH_T.Text = oTool.RegistryRead("File2")
        If BK_PATH_T.Text = "" Then
            BK_PATH_T.Text = Application.StartupPath & "\BackUp"
        End If

        TEMP_PATH_T.Text = oTool.RegistryRead("File3")
        If TEMP_PATH_T.Text = "" Then
            TEMP_PATH_T.Text = Application.StartupPath & "\Temp"
        End If

        oDB_Path = DB_PATH_T.Text

        TABPAGE.SelectedTab = TabPage_SYSTEM

        INIT_PROC()

    End Sub
    Private Sub DISP_INIT()
        Dim RecordCount As Integer

        RecordCount = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCount > 0 Then
            DATA_SET_TO_DISP()
        Else
            DATA_INIT_TO_DISP()
        End If

    End Sub
    Private Function INIT_PROC() As Boolean

        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO
        Dim StrPath As String

        If System.IO.File.Exists(DB_PATH_T.Text & "\OwP-DB.mdb") Then

            StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_PATH_T.Text & "\OwP-DB.mdb;"
            oConn = New OleDb.OleDbConnection(StrPath)

            'ＤＢ接続を開く
            oConn.Open()

            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oMstOPOSDBIO = New cMstOPOSDBIO(oConn, oCommand, oDataReader)

            'チャネルコンボセット
            ReDim oChannel(0)
            oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
            RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, 0, Nothing, 1, oTran)
            CHANNEL_NAME_C.Items.Add("")
            For i = 0 To oChannel.Length - 1
                CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
            Next i
            oChannelDBIO = Nothing

            'レシートプリンタコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, RECIRT_PRINTER, Nothing, oTran)
            RECIRT_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    RECIRT_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            RECIRT_C.SelectedIndex = 0

            'ドロワコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, CASH_DRAWER, Nothing, oTran)
            DRAWER_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    DRAWER_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            DRAWER_C.SelectedIndex = 0

            'カスタマディスプレーコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, CUSTOMER_DISPLAY, Nothing, oTran)
            DISPLAY_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    DISPLAY_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            DISPLAY_C.SelectedIndex = 0

            '磁気カードリーダーコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, CARD_READER, Nothing, oTran)
            CARD_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    CARD_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            CARD_C.SelectedIndex = 0

            '自動釣銭機コンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, AUTO_CHANGEER, Nothing, oTran)
            CHANGE_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    CHANGE_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            CHANGE_C.SelectedIndex = 0

            'CTIコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, CTI, Nothing, oTran)
            CTI_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    CTI_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            CTI_C.SelectedIndex = 0

            'CARD Printerコンボセット
            ReDim oOPOS(0)
            RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, CARD_PRINTER, Nothing, oTran)
            CARDP_C.Items.Add("未接続")
            If RecordCount > 0 Then
                For i = 0 To oOPOS.Length - 1
                    CARDP_C.Items.Add(oOPOS(i).sModelName)
                Next i
            End If
            CARDP_C.SelectedIndex = 0

            '連携ソフト（会計）コンボセット
            ReDim oSoft(0)
            oMstSoftDBIO = New cMstSoftDBIO(oConn, oCommand, oDataReader)
            RecordCount = oMstSoftDBIO.getSoftMst(oSoft, Nothing, Nothing, Nothing, 1, Nothing, oTran)
            FIN_SOFT_NAME_C.Items.Add("未使用")
            For i = 0 To oSoft.Length - 1
                FIN_SOFT_NAME_C.Items.Add(oSoft(i).sSoftName)
            Next i
            FIN_SOFT_NAME_C.SelectedIndex = 0

            '連携ソフト（配送伝票）コンボセット
            ReDim oSoft(0)
            RecordCount = oMstSoftDBIO.getSoftMst(oSoft, Nothing, Nothing, Nothing, 2, Nothing, oTran)
            DELIVERY_SOFT_NAME_C.Items.Add("未使用")
            For i = 0 To oSoft.Length - 1
                DELIVERY_SOFT_NAME_C.Items.Add(oSoft(i).sSoftName)
            Next i
            DELIVERY_SOFT_NAME_C.SelectedIndex = 0

            RecordCount = oMstConfigDBIO.getConfMst(oConf, oTran)
            If RecordCount > 0 Then
                DATA_SET_TO_DISP()
            Else
                DATA_INIT_TO_DISP()
            End If

            INIT_PROC = True

        Else
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "データベースの接続が出来ません。", _
                                            "DB Pathを設定して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            DATA_INIT_TO_DISP()

            DB_PATH_T.Focus()
            System.Windows.Forms.Application.DoEvents()

            INIT_PROC = False
        End If

    End Function

    Private Sub FIND1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            FUNC_PATH1_T.Text = sPath.ToString
        End If
    End Sub

    Private Sub FIND2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            FUNC_PATH2_T.Text = sPath.ToString
        End If
    End Sub

    Private Sub FIND3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            FUNC_PATH3_T.Text = sPath.ToString
        End If
    End Sub

    Private Sub FIND4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            FUNC_PATH4_T.Text = sPath.ToString
        End If
    End Sub

    Private Sub FIND5_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            FUNC_PATH5_T.Text = sPath.ToString
        End If
    End Sub

    Private Sub DATA_SET_TO_DISP()
        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO
        Dim sPath As String
        Dim tPath As String
        Dim asm As System.Reflection.Assembly

        '現在実行しているAssemblyを取得する
        asm = System.Reflection.Assembly.GetExecutingAssembly()

        ''-----------------------
        ''   パス設定項目
        ''-----------------------
        ''Tempパス
        'TEMP_PATH_T.Text = oConf(0).sTempFilePass

        '-----------------------
        '   周辺機器情報
        '-----------------------
        'レシートプリンタ
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sRecertPrinterProductClass, oTran)
        RECIRT_C.Text = oOPOS(0).sModelName

        'ドローワ
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sDrawerProductClass, oTran)
        DRAWER_C.Text = oOPOS(0).sModelName

        'カスタマディスプレー
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sCustomerDisplayProducttClass, oTran)
        DISPLAY_C.Text = oOPOS(0).sModelName

        '磁気カードリーダー
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sCardReaderProducttClass, oTran)
        CARD_C.Text = oOPOS(0).sModelName

        '自動釣銭機
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sAutoChangerProducttClass, oTran)
        CHANGE_C.Text = oOPOS(0).sModelName

        'CTI
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sCTIProducttClass, oTran)
        CTI_C.Text = oOPOS(0).sModelName
        If IsDBNull(oOPOS(0).sModelName) Then
            CTI_PORT_T.Enabled = False
        End If

        'Card Printer
        ReDim oOPOS(0)
        oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sCardPrinterClass, oTran)
        CARDP_C.Text = oOPOS(0).sModelName

        '-----------------------
        '   システム設定項目
        '-----------------------
        'DB保有期間
        TRN_PERIOD_T.Text = oConf(0).sDataPeriod
        'CTI接続ポート
        CTI_PORT_T.Text = oConf(0).sCTIPort

        '-----------------------
        '   消費税設定項目
        '-----------------------
        '端数処理
        Select Case oConf(0).sFracProc
            Case 0  '四捨五入
                TROUND_R.Checked = True
            Case 1  '切捨て
                TCUT_R.Checked = True
            Case 2  '切上げ
                TUP_R.Checked = True
        End Select

        '消費税率
        TAX_T.Text = oConf(0).sTax

        '会計処理区分
        Select Case oConf(0).sFinClass
            Case 0  '税込経理
                FIN_IN_R.Checked = True
            Case 1  '税抜経理
                FIN_OUT_R.Checked = True
        End Select

        '税区分
        Select Case oConf(0).sTaxClass
            Case 0  '原則課税
                GENSOKU_TAX_R.Checked = True
            Case 1  '簡易課税
                KANI_TAX_R.Checked = True
        End Select

        '-----------------------
        '   事業所情報
        '-----------------------
        '事業所名
        CORP_NAME_T.Text = oConf(0).sCorpName
        '郵便番号
        POSTCODE_1_T.Text = oConf(0).sPostCode.Substring(0, 3)
        POSTCODE_2_T.Text = oConf(0).sPostCode.Substring(oConf(0).sPostCode.Length - 4, 4)
        '住所1
        ADDR_1_T.Text = oConf(0).sAdderess1
        '住所2
        ADDR_2_T.Text = oConf(0).sAdderess2
        'TEL
        TEL_T.Text = oConf(0).sTEL
        'FAX
        FAX_T.Text = oConf(0).sFAX
        'URL
        URL_T.Text = oConf(0).sURL
        '標準仕切率
        RATE_T.Text = oConf(0).sRate
        '営業時間-開店時間-時
        OPEN_HOUR_T.Text = String.Format("{0:00}", oConf(0).sOpenHour)
        '営業時間-開店時間-分
        OPEN_MINUTE_T.Text = String.Format("{0:00}", oConf(0).sOpenMinute)
        '営業時間-閉店時間-時
        CLOSE_HOUR_T.Text = String.Format("{0:00}", oConf(0).sCloseHour)
        '営業時間-閉店時間-分
        CLOSE_MINUTE_T.Text = String.Format("{0:00}", oConf(0).sCloseMinute)

        '締め日
        CLOSEDAY_T.Text = oConf(0).sCloseDay

        '-----------------------
        '   連携ソフト情報
        '-----------------------
        '連携ソフト情報（会計）
        ReDim oSoft(0)
        oMstSoftDBIO.getSoftMst(oSoft, oConf(0).sFinSoftCode, Nothing, Nothing, Nothing, Nothing, oTran)
        FIN_SOFT_NAME_C.Text = oSoft(0).sSoftName

        '連携ソフト情報（配送伝票出力）
        ReDim oSoft(0)
        oMstSoftDBIO.getSoftMst(oSoft, oConf(0).sDeliverySoftCode, Nothing, Nothing, Nothing, Nothing, oTran)
        DELIVERY_SOFT_NAME_C.Text = oSoft(0).sSoftName

        '-----------------------
        '   レジ設定項目
        '-----------------------
        'レシートロゴファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Picture\rLogo.BMP"
        tPath = System.Windows.Forms.Application.StartupPath & "\Temp\rLogo.BMP"

        'Tempのメンバー写真を削除
        System.IO.File.Delete(tPath)

        If System.IO.File.Exists(sPath) Then
            '定義済みファイルをTempに退避
            System.IO.File.Copy(sPath, tPath)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            RLOGO_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        Else
            RLOGO_P.Image = Nothing
        End If

        '領収書ロゴファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Picture\bLogo.BMP"
        tPath = System.Windows.Forms.Application.StartupPath & "\Temp\bLogo.BMP"

        'Tempのメンバー写真を削除
        System.IO.File.Delete(tPath)

        If System.IO.File.Exists(sPath) Then
            '定義済みファイルをTempに退避
            System.IO.File.Copy(sPath, tPath)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            BLOGO_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        Else
            BLOGO_P.Image = Nothing
        End If

        'レシートメッセージ（1行目）
        RMSG_1_T.Text = oConf(0).sMessage1
        RMSG1_L.Text = oConf(0).sMessage1
        'レシートメッセージ（2行目）
        RMSG_2_T.Text = oConf(0).sMessage2
        RMSG2_L.Text = oConf(0).sMessage2
        'レシートメッセージ（3行目）
        RMSG_3_T.Text = oConf(0).sMessage3
        RMSG3_L.Text = oConf(0).sMessage3

        'ラインディスプレーメッセージ
        L_MSG_T.Text = oConf(0).sLineMsg

        '---------------------
        '   レジ端末情報
        '---------------------
        'レジチャネル名称
        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, True, oTran)
        CHANNEL_NAME_C.Text = oChannel(0).sChannelName
        CHANNEL_CODE_T.Text = oConf(0).sRegChannelCode
        oChannelDBIO = Nothing

        'レジ端末No
        PC_NO_T.Text = oConf(0).sRegPCNo

        '---------------------
        '   自由設定項目
        '---------------------
        'ファンクション設定
        FUNC_NAME1_T.Text = oConf(0).sFunc_Name1
        FUNC_PATH1_T.Text = oConf(0).sFunc_Path1
        FUNC_NAME2_T.Text = oConf(0).sFunc_Name2
        FUNC_PATH2_T.Text = oConf(0).sFunc_Path2
        FUNC_NAME3_T.Text = oConf(0).sFunc_Name3
        FUNC_PATH3_T.Text = oConf(0).sFunc_Path3
        FUNC_NAME4_T.Text = oConf(0).sFunc_Name4
        FUNC_PATH4_T.Text = oConf(0).sFunc_Path4
        FUNC_NAME5_T.Text = oConf(0).sFunc_Name5
        FUNC_PATH5_T.Text = oConf(0).sFunc_Path5

        'オプション項目設定
        OPTION_1_T.Text = oConf(0).sOptionName1
        OPTION_2_T.Text = oConf(0).sOptionName2
        OPTION_3_T.Text = oConf(0).sOptionName3
        OPTION_4_T.Text = oConf(0).sOptionName4
        OPTION_5_T.Text = oConf(0).sOptionName5

        '---------------------------
        '   アカウント設定項目
        '---------------------------
        'YahooビジネスID情報
        YAHOO_B_ID_T.Text = oConf(0).sYahooBisID
        YB_ID_LINK_P_T.Text = oConf(0).sYahooBisIDLinkPG
        YB_ID_LINK_P_P_T.Text = oConf(0).sYahooBisIDLinkPR

        'YahooビジネスPASS情報
        YAHOO_B_PASS_T.Text = oConf(0).sYahooBisPASS
        YB_PASS_LINK_P_T.Text = oConf(0).sYahooBisPASSLinkPG
        YB_PASS_LINK_P_P_T.Text = oConf(0).sYahooBisPASSLinkPR

        'YahooユーザーID情報
        YAHOO_U_ID_T.Text = oConf(0).sYahooUserID
        YU_ID_LINK_P_T.Text = oConf(0).sYahooUserIDLinkPG
        YU_ID_LINK_P_P_T.Text = oConf(0).sYahooUserIDLinkPR

        'YahooユーザーPASS情報
        YAHOO_U_PASS_T.Text = oConf(0).sYahooUserPASS
        YU_PASS_LINK_P_T.Text = oConf(0).sYahooUserPASSLinkPG
        YU_PASS_LINK_P_P_T.Text = oConf(0).sYahooUserPASSLinkPR

        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 START ***
        ' Yahooストアアカウント
        YAHOO_STORE_ACCOUNT.Text = oConf(0).sYahooStoreAccount

        ' YahooApiKey
        YAHOO_API_KEY.Text = oConf(0).sYahooApiKey

        ' YahooカスタムURI
        YAHOO_REDIRECT_URI.Text = oConf(0).sYahooRedirectUri
        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 END ***

        '楽天RMSID情報
        RMS_ID_T.Text = oConf(0).sRakutenRMSUserID
        RMS_ID_LINK_P_T.Text = oConf(0).sRakutenRMSUserIDLinkPG
        RMS_ID_LINK_P_P_T.Text = oConf(0).sRakutenRMSUserIDLinkPR

        '楽天RMSPASS情報
        RMS_PASS_T.Text = oConf(0).sRakutenRMSUserPASS
        RMS_PASS_LINK_P_T.Text = oConf(0).sRakutenRMSUserPASSLinkPG
        RMS_PASS_LINK_P_P_T.Text = oConf(0).sRakutenRMSUserPASSLinkPR

        '楽天ユーザーID情報
        RAKUTEN_ID_T.Text = oConf(0).sRakutenUserID
        RAKUTEN_ID_P_T.Text = oConf(0).sRakutenUserIDLinkPG
        RAKUTEN_ID_P_P_T.Text = oConf(0).sRakutenUserIDLinkPR

        '楽天ユーザーPASS情報
        RAKUTEN_PASS_T.Text = oConf(0).sRakutenUserPASS
        RAKUTEN_PASS_P_T.Text = oConf(0).sRakutenUserPASSLinkPG
        RAKUTEN_PASS_P_P_T.Text = oConf(0).sRakutenUserPASSLinkPR

        '楽天CSVダウンロードID情報
        RAKUTEN_CSV_ID_T.Text = oConf(0).sRakutenCSVDownloadID
        RAKUTEN_CSV_ID_P_T.Text = oConf(0).sRakutenCSVDownloadIDLinkPG
        RAKUTEN_CSV_ID_P_P_T.Text = oConf(0).sRakutenCSVDownloadIDLinkPR

        '楽天CSVダウンロードPASS情報
        RAKUTEN_CSV_PASS_T.Text = oConf(0).sRakutenCSVDownloadPASS
        RAKUTEN_CSV_PASS_P_T.Text = oConf(0).sRakutenCSVDownloadPASSLinkPG
        RAKUTEN_CSV_PASS_P_P_T.Text = oConf(0).sRakutenCSVDownloadPASSLinkPR

        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 START ***
        ' 楽天API用serviceSecret
        RAKUTEN_API_SERVICE_SECRET.Text = oConf(0).sRakutenAPIServiceSecret

        ' 楽天API用licenseKey
        RAKUTEN_API_LICENSE_KEY.Text = oConf(0).sRakutenAPILicenseKey

        ' 楽天API用URL
        RAKUTEN_API_URL.Text = oConf(0).sRakutenAPIUrl
        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 END ***

        'Amazon出品者ID
        AMAZON_ID_T.Text = oConf(0).sAmazonSellerID
        AMAZON_ID_LINK_P_T.Text = oConf(0).sAmazonSellerIDLinkPG
        AMAZON_ID_LINK_P_P_T.Text = oConf(0).sAmazonSellerIDLinkPR

        'AmazonWebサービスアクセスキーId
        AMAZON_ACCESS_KEY_T.Text = oConf(0).sAmazonWebServiceAccesskeyID
        AMAZON_ACCESS_KEY_LINK_P_T.Text = oConf(0).sAmazonWebServiceAccesskeyIDLinkPG
        AMAZON_ACCESS_KEY_LINK_P_P_T.Text = oConf(0).sAmazonWebServiceAccesskeyIDLinkPR

        'AmazonマーケットプレイスID
        AMAZON_MARKET_ID_T.Text = oConf(0).sAmazonMarketPlaceID
        AMAZON_MARKET_ID_LINK_P_T.Text = oConf(0).sAmazonMarketPlaceIDLinkPG
        AMAZON_MARKET_ID_LINK_P_P_T.Text = oConf(0).sAmazonMarketPlaceIDLinkPR

        'Amazon秘密キー
        AMAZON_SECURITY_KEY_T.Text = oConf(0).sAmazonSecretKey
        AMAZON_SECURITY_KEY_LINK_P_T.Text = oConf(0).sAmazonSecretKeyLinkPG
        AMAZON_SECURITY_KEY_LINK_P_P_T.Text = oConf(0).sAmazonSecretKeyLinkPR

        'ショップサーブユーザーID
        ESHOP_ID_T.Text = oConf(0).sShopServID
        ESHOP_ID_LINK_P_T.Text = oConf(0).sShopServIDLinkPG
        ESHOP_ID_LINK_P_P_T.Text = oConf(0).sShopServIDLinkPR

        'ショップサーブユーザーPASS
        ESHOP_PASS_T.Text = oConf(0).sShopServPass
        ESHOP_PASS_LINK_P_T.Text = oConf(0).sShopServPassLinkPG
        ESHOP_PASS_LINK_P_P_T.Text = oConf(0).sShopServPassLinkPR

        '---------------------------
        '   カード設定項目
        '---------------------------
        'ポイント付与単位（円）
        POINT_EN_T.Text = oConf(0).sPointEN
        'ポイント付与率（ポイント）
        POINT_RATE_T.Text = oConf(0).sPointRATE
        'ポイント有効期限
        If oConf(0).sPointEnableMonth = 0 Then
            POINT_ENABLE_T.Text = "無期限"
        Else
            POINT_ENABLE_T.Text = oConf(0).sPointEnableMonth
        End If

        'ポイントカード（表）画像ファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Picture\PointCardFore.BMP"
        tPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardFore.BMP"

        'Tempのポイントカード（表）を削除
        System.IO.File.Delete(tPath)

        If System.IO.File.Exists(sPath) Then
            '定義済みファイルをTempに退避
            System.IO.File.Copy(sPath, tPath)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            POINT_CARD_FORE_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

        'ポイントカード（裏）画像ファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Picture\PointCardBack.BMP"
        tPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardBack.BMP"

        'Tempのポイントカード（裏）を削除
        System.IO.File.Delete(tPath)

        If System.IO.File.Exists(sPath) Then
            '定義済みファイルをTempに退避
            System.IO.File.Copy(sPath, tPath)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            POINT_CARD_BACK_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
        'ポイントカードメッセージ
        POINT_CARD_MSG_T.Text = oConf(0).sPointCardMsg

        '会員有効期限
        If oConf(0).sMemberEnableMonth = 0 Then
            MEMBER_ENABLE_T.Text = "無期限"
        Else
            MEMBER_ENABLE_T.Text = oConf(0).sMemberEnableMonth
        End If

        '会員カード（裏）画像ファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Picture\PointCardBack.BMP"
        tPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardBack.BMP"

        'Tempの会員カード（裏）を削除
        System.IO.File.Delete(tPath)

        If System.IO.File.Exists(sPath) Then
            '定義済みファイルをTempに退避
            System.IO.File.Copy(sPath, tPath)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            MEMBER_CARD_BACK_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If
        '会員カードメッセージ
        MEMBER_CARD_MSG_T.Text = oConf(0).sMemberCardMsg

        '---------------------------
        '   予約票設定項目
        '---------------------------
        '予約票メッセージ
        RESERV_CARD_MSG_T.Text = oConf(0).sReservCardMsg

        '---------------------------
        '   分析パラメータ
        '---------------------------
        'グラフ作成期間
        GRAPH_OFFSET_OPEN_HOUR_T.Text = oConf(0).sStStartHour
        GRAPH_OFFSET_OPEN_MIN_T.Text = oConf(0).sStStartMinute
        GRAPH_OFFSET_CLOSE_HOUR_T.Text = oConf(0).sStEndHour
        GRAPH_OFFSET_CLOSE_MIN_T.Text = oConf(0).sStEndMinute

        MAKE_TIME_SET()

        '発注候補リスト抽出条件
        ORDER_LIST_TERM_T.Text = oConf(0).sOrderListTerm
        SALES_TERM_T.Text = oConf(0).sSalesTerm
        MINIMUM_COUNT_T.Text = oConf(0).sMinimumCount

    End Sub
    Private Sub DATA_INIT_TO_DISP()

        '-----------------------
        '   ファイルパス情報
        '-----------------------
        DB_PATH_T.Text = oTool.RegistryRead("File1")
        BK_PATH_T.Text = oTool.RegistryRead("File2")
        If BK_PATH_T.Text = "" Then
            BK_PATH_T.Text = Application.StartupPath
        End If

        TEMP_PATH_T.Text = oTool.RegistryRead("File3")
        If TEMP_PATH_T.Text = "" Then
            TEMP_PATH_T.Text = Application.StartupPath
        End If

        '-----------------------
        '   周辺機器情報
        '-----------------------
        RECIRT_C.Text = "未接続"
        DRAWER_C.Text = "未接続"
        DISPLAY_C.Text = "未接続"
        CARD_C.Text = "未接続"
        CHANGE_C.Text = "未接続"
        CTI_C.Text = "未接続"
        CARDP_C.Text = "未接続"
        CTI_PORT_T.Enabled = False

        '-----------------------
        '   システム設定項目
        '-----------------------
        'DB保有期間
        TRN_PERIOD_T.Text = ""
        'CTI接続ポート
        CTI_PORT_T.Text = ""
        '端数処理
        TROUND_R.Checked = True
        '消費税率
        TAX_T.Text = ""
        '会計処理区分
        FIN_IN_R.Checked = True
        '税区分
        GENSOKU_TAX_R.Checked = True
        '締め日
        CLOSEDAY_T.Text = ""

        '事業所名
        CORP_NAME_T.Text = ""
        '郵便番号
        POSTCODE_1_T.Text = ""
        POSTCODE_2_T.Text = ""
        '住所1
        ADDR_1_T.Text = ""
        '住所2
        ADDR_2_T.Text = ""
        'TEL
        TEL_T.Text = ""
        'FAX
        FAX_T.Text = ""
        'URL
        URL_T.Text = ""
        '標準仕切率
        RATE_T.Text = ""
        '営業時間-開店時間-時
        OPEN_HOUR_T.Text = ""
        '営業時間-開店時間-分
        OPEN_MINUTE_T.Text = ""
        '営業時間-閉店時間-時
        CLOSE_HOUR_T.Text = ""
        '営業時間-閉店時間-分
        CLOSE_MINUTE_T.Text = ""

        '-----------------------
        '   レジ設定項目
        '-----------------------
        'チャネル情報
        CHANNEL_NAME_C.Text = ""
        CHANNEL_CODE_T.Text = ""
        '端末番号
        PC_NO_T.Text = 1

        'レシートロゴファイル名
        RLOGO_P.Image = Nothing
        '領収書ロゴファイル名
        BLOGO_P.Image = Nothing
        'レシートメッセージ（1行目）
        RMSG_1_T.Text = ""
        'レシートメッセージ（2行目）
        RMSG_2_T.Text = ""
        'レシートメッセージ（3行目）
        RMSG_3_T.Text = ""

        'ラインディスプレーメッセージ
        L_MSG_T.Text = ""

        '---------------------
        '   自由設定項目
        '---------------------
        'ファンクション設定
        FUNC_NAME1_T.Text = ""
        FUNC_PATH1_T.Text = ""
        FUNC_NAME2_T.Text = ""
        FUNC_PATH2_T.Text = ""
        FUNC_NAME3_T.Text = ""
        FUNC_PATH3_T.Text = ""
        FUNC_NAME4_T.Text = ""
        FUNC_PATH4_T.Text = ""
        FUNC_NAME5_T.Text = ""
        FUNC_PATH5_T.Text = ""

        'オプション項目設定
        OPTION_1_T.Text = ""
        OPTION_2_T.Text = ""
        OPTION_3_T.Text = ""
        OPTION_4_T.Text = ""
        OPTION_5_T.Text = ""

        '---------------------------
        '   アカウント設定項目
        '---------------------------
        'YahooビジネスID情報
        YAHOO_B_ID_T.Text = ""
        YB_ID_LINK_P_T.Text = ""
        YB_ID_LINK_P_P_T.Text = ""

        'YahooビジネスPASS情報
        YAHOO_B_PASS_T.Text = ""
        YB_PASS_LINK_P_T.Text = ""
        YB_PASS_LINK_P_P_T.Text = ""

        'YahooユーザーID情報
        YAHOO_U_ID_T.Text = ""
        YU_ID_LINK_P_T.Text = ""
        YU_ID_LINK_P_P_T.Text = ""

        'YahooユーザーPASS情報
        YAHOO_U_PASS_T.Text = ""
        YU_PASS_LINK_P_T.Text = ""
        YU_PASS_LINK_P_P_T.Text = ""

        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 START ***
        ' Yahooストアアカウント
        YAHOO_STORE_ACCOUNT.Text = ""

        ' YahooApiKey
        YAHOO_API_KEY.Text = ""

        ' YahooカスタムURI
        YAHOO_REDIRECT_URI.Text = ""
        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 END ***

        '楽天RMSID情報
        RMS_ID_T.Text = ""
        RMS_ID_LINK_P_T.Text = ""
        RMS_ID_LINK_P_P_T.Text = ""

        '楽天RMSPASS情報
        RMS_PASS_T.Text = ""
        RMS_PASS_LINK_P_T.Text = ""
        RMS_PASS_LINK_P_P_T.Text = ""

        '楽天ユーザーID情報
        RAKUTEN_ID_T.Text = ""
        RAKUTEN_ID_P_T.Text = ""
        RAKUTEN_ID_P_P_T.Text = ""

        '楽天ユーザーPASS情報
        RAKUTEN_PASS_T.Text = ""
        RAKUTEN_PASS_P_T.Text = ""
        RAKUTEN_PASS_P_P_T.Text = ""

        '楽天CSVダウンロードID情報
        RAKUTEN_CSV_ID_T.Text = ""
        RAKUTEN_CSV_ID_P_T.Text = ""
        RAKUTEN_CSV_ID_P_P_T.Text = ""

        '楽天CSVダウンロードPASS情報
        RAKUTEN_CSV_PASS_T.Text = ""
        RAKUTEN_CSV_PASS_P_T.Text = ""
        RAKUTEN_CSV_PASS_P_P_T.Text = ""

        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 START ***
        '楽天API用serviceSecret
        RAKUTEN_API_SERVICE_SECRET.Text = ""

        '楽天API用licenseKey
        RAKUTEN_API_LICENSE_KEY.Text = ""

        '楽天API用URL
        RAKUTEN_API_URL.Text = ""
        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 END ***

        'Amazon出品者ID
        AMAZON_ID_T.Text = ""
        AMAZON_ID_LINK_P_T.Text = ""
        AMAZON_ID_LINK_P_P_T.Text = ""

        'AmazonWebサービスアクセスキーId
        AMAZON_ACCESS_KEY_T.Text = ""
        AMAZON_ACCESS_KEY_LINK_P_T.Text = ""
        AMAZON_ACCESS_KEY_LINK_P_P_T.Text = ""

        'AmazonマーケットプレイスID
        AMAZON_MARKET_ID_T.Text = ""
        AMAZON_MARKET_ID_LINK_P_T.Text = ""
        AMAZON_MARKET_ID_LINK_P_P_T.Text = ""

        'Amazon秘密キー
        AMAZON_SECURITY_KEY_T.Text = ""
        AMAZON_SECURITY_KEY_LINK_P_T.Text = ""
        AMAZON_SECURITY_KEY_LINK_P_P_T.Text = ""

        'ショップサーブユーザーID
        ESHOP_ID_T.Text = ""
        ESHOP_ID_LINK_P_T.Text = ""
        ESHOP_ID_LINK_P_P_T.Text = ""

        'ショップサーブユーザーPASS
        ESHOP_PASS_T.Text = ""
        ESHOP_PASS_LINK_P_T.Text = ""
        ESHOP_PASS_LINK_P_P_T.Text = ""

        '---------------------------
        '   カード設定項目
        '---------------------------
        'ポイント情報項目
        POINT_EN_T.Text = 100
        POINT_RATE_T.Text = 1
        POINT_ENABLE_T.Text = "無期限"

        'ポイントカード画像（表）ファイルパス
        POINT_CARD_FORE_P.Image = Nothing
        'ポイントカード画像（裏）ファイルパス
        POINT_CARD_BACK_P.Image = Nothing
        'ポイントカードメッセージ
        POINT_CARD_MSG_T.Text = ""

        '会員カード画像（裏）ファイルパス
        MEMBER_CARD_BACK_P.Image = Nothing
        '会員カードメッセージ
        MEMBER_CARD_MSG_T.Text = ""

        '---------------------------
        '   予約票設定項目
        '---------------------------
        '予約票メッセージ
        RESERV_CARD_MSG_T.Text = ""

        '---------------------------
        '   分析パラメータ
        '---------------------------
        'グラフ作成期間
        GRAPH_OFFSET_OPEN_HOUR_T.Text = ""
        GRAPH_OFFSET_OPEN_MIN_T.Text = ""
        GRAPH_OFFSET_CLOSE_HOUR_T.Text = ""
        GRAPH_OFFSET_CLOSE_MIN_T.Text = ""

        MAKE_TIME_SET()

        '発注候補リスト抽出条件
        ORDER_LIST_TERM_T.Text = ""
        SALES_TERM_T.Text = ""
        MINIMUM_COUNT_T.Text = ""

    End Sub

    Private Sub DATA_SET_TO_DB()
        Dim sPath As String
        Dim tPath As String

        '-----------------------
        '   パス設定項目
        '-----------------------
        oConf(0).sDBFilePath = DB_PATH_T.Text
        oConf(0).sTempFilePath = TEMP_PATH_T.Text
        oConf(0).sBKFilePath = BK_PATH_T.Text

        '-----------------------
        '   周辺機器情報
        '-----------------------
        oConf(0).sRecertPrinterProductClass = CInt(RECIRT_T.Text)
        oConf(0).sDrawerProductClass = CInt(DRAWER_T.Text)
        oConf(0).sCustomerDisplayProducttClass = CInt(DISPLAY_T.Text)
        oConf(0).sCardReaderProducttClass = CInt(CARD_T.Text)
        oConf(0).sAutoChangerProducttClass = CInt(CHANGE_T.Text)
        oConf(0).sCTIProducttClass = CInt(CTI_T.Text)
        oConf(0).sCardPrinterClass = CInt(CARDP_T.Text)

        '-----------------------
        '   システム設定
        '-----------------------
        oConf(0).sDataPeriod = CInt(TRN_PERIOD_T.Text)
        oConf(0).sCTIPort = CTI_PORT_T.Text

        '-----------------------
        '   システム設定項目
        '-----------------------
        '事業所名
        oConf(0).sCorpName = CORP_NAME_T.Text
        '郵便番号
        oConf(0).sPostCode = POSTCODE_1_T.Text & "-" & POSTCODE_2_T.Text
        '住所1
        oConf(0).sAdderess1 = ADDR_1_T.Text
        '住所2
        oConf(0).sAdderess2 = ADDR_2_T.Text
        'TEL
        oConf(0).sTEL = TEL_T.Text
        'FAX
        oConf(0).sFAX = FAX_T.Text
        'URL
        oConf(0).sURL = URL_T.Text
        '標準仕切率
        oConf(0).sRate = RATE_T.Text
        '営業時間-開店時間-時
        oConf(0).sOpenHour = CInt(OPEN_HOUR_T.Text)
        '営業時間-開店時間-分
        oConf(0).sOpenMinute = CInt(OPEN_MINUTE_T.Text)
        '営業時間-閉店時間-時
        oConf(0).sCloseHour = CInt(CLOSE_HOUR_T.Text)
        '営業時間-閉店時間-分
        oConf(0).sCloseMinute = CInt(CLOSE_MINUTE_T.Text)

        '*** START MINAGAWA 2013/6/20 ***
        '統計対象時間_開始時
        oConf(0).sStStartHour = CInt(OPEN_HOUR_T.Text) - 2
        '統計対象時間_開始分
        oConf(0).sStStartMinute = CInt(OPEN_MINUTE_T.Text)
        '統計対象時間_終了時
        oConf(0).sStEndHour = CInt(CLOSE_HOUR_T.Text) + 2
        '統計対象時間_終了分
        oConf(0).sStEndMinute = CInt(CLOSE_MINUTE_T.Text)
        '*** END   MINAGAWA 2013/6/20 ***

        '端数処理
        If TROUND_R.Checked = True Then '四捨五入
            oConf(0).sFracProc = 0
        End If
        If TCUT_R.Checked = True Then '切捨て
            oConf(0).sFracProc = 1
        End If
        If TUP_R.Checked = True Then '切上げ
            oConf(0).sFracProc = 2
        End If

        '消費税率
        oConf(0).sTax = CInt(TAX_T.Text)

        '会計処理区分
        If FIN_IN_R.Checked = True Then '税込経理
            oConf(0).sFinClass = 0
        End If
        If FIN_OUT_R.Checked = True Then '税抜経理
            oConf(0).sFinClass = 1
        End If

        '税区分
        If GENSOKU_TAX_R.Checked = True Then '原則課税
            oConf(0).sTaxClass = 0
        End If
        If KANI_TAX_R.Checked = True Then '簡易課税
            oConf(0).sTaxClass = 1
        End If

        '締め日
        oConf(0).sCloseDay = CInt(CLOSEDAY_T.Text)

        '連携ソフト情報（会計）
        oConf(0).sFinSoftCode = CInt(FIN_SOFT_CODE_T.Text)

        '連携ソフト情報（配送伝票出力）
        oConf(0).sDeliverySoftCode = CInt(DELIVERY_SOFT_CODE_T.Text)

        '-----------------------
        '   レジ設定項目
        '-----------------------
        'チャネル情報
        oConf(0).sRegChannelCode = CInt(CHANNEL_CODE_T.Text)
        '端末番号
        oConf(0).sRegPCNo = CInt(PC_NO_T.Text)

        'レシートロゴファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\rLogo.BMP"
        If System.IO.File.Exists(sPath) = True Then
            oConf(0).sBLogoPass = "rLogo.BMP"
            tPath = System.Windows.Forms.Application.StartupPath & "\Picture\rLogo.BMP"
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
        Else
            oConf(0).sBLogoPass = ""
        End If

        '領収書ロゴファイル名
        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\bLogo.BMP"
        If System.IO.File.Exists(sPath) = True Then
            oConf(0).sBLogoPass = "bLogo.BMP"
            tPath = System.Windows.Forms.Application.StartupPath & "\Picture\bLogo.BMP"
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
        Else
            oConf(0).sBLogoPass = ""
        End If
        'レシートメッセージ（1行目）
        oConf(0).sMessage1 = RMSG_1_T.Text
        'レシートメッセージ（2行目）
        oConf(0).sMessage2 = RMSG_2_T.Text
        'レシートメッセージ（3行目）
        oConf(0).sMessage3 = RMSG_3_T.Text
        '
        'ラインディスプレーメッセージ
        oConf(0).sLineMsg = L_MSG_T.Text
        '
        '---------------------
        '自由設定項目
        '---------------------
        'ファンクション設定
        oConf(0).sFunc_Name1 = FUNC_NAME1_T.Text
        oConf(0).sFunc_Path1 = FUNC_PATH1_T.Text
        oConf(0).sFunc_Name2 = FUNC_NAME2_T.Text
        oConf(0).sFunc_Path2 = FUNC_PATH2_T.Text
        oConf(0).sFunc_Name3 = FUNC_NAME3_T.Text
        oConf(0).sFunc_Path3 = FUNC_PATH3_T.Text
        oConf(0).sFunc_Name4 = FUNC_NAME4_T.Text
        oConf(0).sFunc_Path4 = FUNC_PATH4_T.Text
        oConf(0).sFunc_Name5 = FUNC_NAME5_T.Text
        oConf(0).sFunc_Path5 = FUNC_PATH5_T.Text
        '
        'オプション項目設定
        oConf(0).sOptionName1 = OPTION_1_T.Text
        oConf(0).sOptionName2 = OPTION_2_T.Text
        oConf(0).sOptionName3 = OPTION_3_T.Text
        oConf(0).sOptionName4 = OPTION_4_T.Text
        oConf(0).sOptionName5 = OPTION_5_T.Text
        '
        '---------------------------
        'アカウント設定項目
        '---------------------------

        '*****************************
        '*            Yahoo          *
        '*****************************

        'YahooビジネスID情報
        oConf(0).sYahooBisID = YAHOO_B_ID_T.Text
        oConf(0).sYahooBisIDLinkPG = YB_ID_LINK_P_T.Text
        oConf(0).sYahooBisIDLinkPR = YB_ID_LINK_P_P_T.Text
        '
        'YahooビジネスPASS情報
        oConf(0).sYahooBisPASS = YAHOO_B_PASS_T.Text
        oConf(0).sYahooBisPASSLinkPG = YB_PASS_LINK_P_T.Text
        oConf(0).sYahooBisPASSLinkPR = YB_PASS_LINK_P_P_T.Text
        '
        'YahooユーザーID情報
        oConf(0).sYahooUserID = YAHOO_U_ID_T.Text
        oConf(0).sYahooUserIDLinkPG = YU_ID_LINK_P_T.Text
        oConf(0).sYahooUserIDLinkPR = YU_ID_LINK_P_P_T.Text
        '
        'YahooユーザーPASS情報
        oConf(0).sYahooUserPASS = YAHOO_U_PASS_T.Text
        oConf(0).sYahooUserPASSLinkPG = YU_PASS_LINK_P_T.Text
        oConf(0).sYahooUserPASSLinkPR = YU_PASS_LINK_P_P_T.Text

        ' *** 受注情報の自動取込対応 K.Minagawa 2016.08.29 START ***
        ' Yahooストアアカウント
        oConf(0).sYahooStoreAccount = YAHOO_STORE_ACCOUNT.Text

        ' YahooApiKey
        oConf(0).sYahooApiKey = YAHOO_API_KEY.Text

        ' YahooカスタムURI
        oConf(0).sYahooRedirectUri = YAHOO_REDIRECT_URI.Text
        ' *** 受注情報の自動取込対応 K.Minagawa 2016.08.29 END ***

        '*****************************
        '*            楽天           *
        '*****************************

        '楽天RMSID情報
        oConf(0).sRakutenRMSUserID = RMS_ID_T.Text
        oConf(0).sRakutenRMSUserIDLinkPG = RMS_ID_LINK_P_T.Text
        oConf(0).sRakutenRMSUserIDLinkPR = RMS_ID_LINK_P_P_T.Text
        '
        '楽天RMSPASS情報
        oConf(0).sRakutenRMSUserPASS = RMS_PASS_T.Text
        oConf(0).sRakutenRMSUserPASSLinkPG = RMS_PASS_LINK_P_T.Text
        oConf(0).sRakutenRMSUserPASSLinkPR = RMS_PASS_LINK_P_P_T.Text
        '
        '楽天ユーザーID情報
        oConf(0).sRakutenUserID = RAKUTEN_ID_T.Text
        oConf(0).sRakutenUserIDLinkPG = RAKUTEN_ID_P_T.Text
        oConf(0).sRakutenUserIDLinkPR = RAKUTEN_ID_P_P_T.Text
        '
        '楽天ユーザーPASS情報
        oConf(0).sRakutenUserPASS = RAKUTEN_PASS_T.Text
        oConf(0).sRakutenUserPASSLinkPG = RAKUTEN_PASS_P_T.Text
        oConf(0).sRakutenUserPASSLinkPR = RAKUTEN_PASS_P_P_T.Text
        '
        '楽天CSVダウンロードID情報
        oConf(0).sRakutenCSVDownloadID = RAKUTEN_CSV_ID_T.Text
        oConf(0).sRakutenCSVDownloadIDLinkPG = RAKUTEN_CSV_ID_P_T.Text
        oConf(0).sRakutenCSVDownloadIDLinkPR = RAKUTEN_CSV_ID_P_P_T.Text
        '
        '楽天CSVダウンロードPASS情報
        oConf(0).sRakutenCSVDownloadPASS = RAKUTEN_CSV_PASS_T.Text
        oConf(0).sRakutenCSVDownloadPASSLinkPG = RAKUTEN_CSV_PASS_P_T.Text
        oConf(0).sRakutenCSVDownloadPASSLinkPR = RAKUTEN_CSV_PASS_P_P_T.Text

        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 START ***
        ' 楽天API用serviceSecret
        oConf(0).sRakutenAPIServiceSecret = RAKUTEN_API_SERVICE_SECRET.Text

        ' 楽天API用licenseKey
        oConf(0).sRakutenAPILicenseKey = RAKUTEN_API_LICENSE_KEY.Text

        ' 楽天API用URL
        oConf(0).sRakutenAPIUrl = RAKUTEN_API_URL.Text
        ' *** 受注情報の自動取込対応　K.Minagawa 2016.08.29 END ***

        '*****************************
        '*           Amazon          *
        '*****************************
        oConf(0).sAmazonSellerID = AMAZON_ID_T.Text
        oConf(0).sAmazonSellerIDLinkPG = AMAZON_ID_LINK_P_T.Text
        oConf(0).sAmazonSellerIDLinkPR = AMAZON_ID_LINK_P_P_T.Text

        oConf(0).sAmazonWebServiceAccesskeyID = AMAZON_ACCESS_KEY_T.Text
        oConf(0).sAmazonWebServiceAccesskeyIDLinkPG = AMAZON_ACCESS_KEY_LINK_P_T.Text
        oConf(0).sAmazonWebServiceAccesskeyIDLinkPR = AMAZON_ACCESS_KEY_LINK_P_P_T.Text

        oConf(0).sAmazonMarketPlaceID = AMAZON_MARKET_ID_T.Text
        oConf(0).sAmazonMarketPlaceIDLinkPG = AMAZON_MARKET_ID_LINK_P_T.Text
        oConf(0).sAmazonMarketPlaceIDLinkPR = AMAZON_MARKET_ID_LINK_P_P_T.Text

        oConf(0).sAmazonSecretKey = AMAZON_SECURITY_KEY_T.Text
        oConf(0).sAmazonSecretKeyLinkPG = AMAZON_SECURITY_KEY_LINK_P_T.Text
        oConf(0).sAmazonSecretKeyLinkPR = AMAZON_SECURITY_KEY_LINK_P_P_T.Text

        '*****************************
        '*            eShop          *
        '*****************************
        oConf(0).sShopServID = ESHOP_ID_T.Text
        oConf(0).sShopServIDLinkPG = ESHOP_ID_LINK_P_T.Text
        oConf(0).sShopServIDLinkPR = ESHOP_ID_LINK_P_P_T.Text

        oConf(0).sShopServPass = ESHOP_PASS_T.Text
        oConf(0).sShopServPassLinkPG = ESHOP_PASS_LINK_P_T.Text
        oConf(0).sShopServPassLinkPR = ESHOP_PASS_LINK_P_P_T.Text

        '---------------------------
        'カード設定項目
        '---------------------------
        'ポイント付与単位（円）
        If POINT_EN_T.Text = "" Then
            oConf(0).sPointEN = 0
        Else
            oConf(0).sPointEN = CInt(POINT_EN_T.Text)
        End If

        'ポイント付与率（ポイント）
        If POINT_RATE_T.Text = "" Then
            oConf(0).sPointRATE = 0
        Else
            oConf(0).sPointRATE = CInt(POINT_RATE_T.Text)
        End If

        'ポイント有効期限
        If POINT_ENABLE_T.Text = "無期限" Or POINT_ENABLE_T.Text = "" Then
            oConf(0).sPointEnableMonth = 0
        Else
            oConf(0).sPointEnableMonth = CInt(POINT_ENABLE_T.Text)
        End If

        'ポイントカード（表）ファイルパス
        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardFore.BMP"
        If System.IO.File.Exists(sPath) = True Then
            oConf(0).sPointForePass = "PointCardFore.BMP"
            tPath = System.Windows.Forms.Application.StartupPath & "\Picture\PointCardFore.BMP"
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
        Else
            oConf(0).sPointForePass = ""
        End If
        'ポイントカード（裏）ファイルパス
        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardBack.BMP"
        If System.IO.File.Exists(sPath) = True Then
            oConf(0).sPointBackPass = "PointCardBack.BMP"
            tPath = System.Windows.Forms.Application.StartupPath & "\Picture\PointCardBack.BMP"
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
        Else
            oConf(0).sPointBackPass = ""
        End If
        'ポイントカードメッセージ
        oConf(0).sPointCardMsg = POINT_CARD_MSG_T.Text

        '会員有効期限
        If MEMBER_ENABLE_T.Text = "無期限" Or MEMBER_ENABLE_T.Text = "" Then
            oConf(0).sMemberEnableMonth = 0
        Else
            oConf(0).sMemberEnableMonth = CInt(MEMBER_ENABLE_T.Text)
        End If

        '会員カード（裏）ファイルパス
        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\MemberCardBack.BMP"
        If System.IO.File.Exists(sPath) = True Then
            oConf(0).sMemberBackPass = "memberCardBack.BMP"
            tPath = System.Windows.Forms.Application.StartupPath & "\Picture\memberCardBack.BMP"
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
        Else
            oConf(0).sMemberBackPass = ""
        End If
        '会員カードメッセージ
        oConf(0).sMemberCardMsg = MEMBER_CARD_MSG_T.Text

        '---------------------------
        '予約票設定項目
        '---------------------------
        '予約票メッセージ
        oConf(0).sReservCardMsg = RESERV_CARD_MSG_T.Text

        '---------------------------
        '   分析パラメータ
        '---------------------------
        'グラフ作成期間
        oConf(0).sStStartHour = GRAPH_OFFSET_OPEN_HOUR_T.Text
        oConf(0).sStStartMinute = GRAPH_OFFSET_OPEN_MIN_T.Text
        oConf(0).sStEndHour = GRAPH_OFFSET_CLOSE_HOUR_T.Text
        oConf(0).sStEndMinute = GRAPH_OFFSET_CLOSE_MIN_T.Text

        '発注候補リスト抽出条件
        oConf(0).sOrderListTerm = ORDER_LIST_TERM_T.Text
        oConf(0).sSalesTerm = SALES_TERM_T.Text
        oConf(0).sMinimumCount = MINIMUM_COUNT_T.Text

        '*************
        '*  DB更新   *
        '*************
        oMstConfigDBIO.updateConfMst(oConf, Nothing)


    End Sub
    Private Sub LINK_Y_1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            YB_ID_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_Y_2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            YB_PASS_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_Y_3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            YU_ID_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_Y_4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            YU_PASS_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RMS_ID_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RMS_PASS_LINK_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_3_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RAKUTEN_ID_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_4_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RAKUTEN_PASS_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_5_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RAKUTEN_CSV_ID_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub LINK_R_6_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            RAKUTEN_CSV_PASS_P_T.Text = sPath.ToString
        End If
    End Sub
    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, CHANNEL_NAME_C.Text, Nothing, Nothing, 3, oTran)
        CHANNEL_CODE_T.Text = oConf(0).sRegChannelCode
        oChannelDBIO = Nothing

    End Sub

    Private Sub WRITE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WRITE_B.Click
        Dim regkey As Microsoft.Win32.RegistryKey

        If INPUT_CHECK() = True Then
            'レジストリへの書き込み
            '（「HKEY_CURRENT_USER\」に書き込む）
            'キーを開く
            regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Ocf\Eazy_POS\")

            'レジストリへの書き込み
            '文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue("File2", BK_PATH_T.Text)
            regkey.SetValue("File3", TEMP_PATH_T.Text)

            '閉じる
            regkey.Close()

            'DB更新
            DATA_SET_TO_DB()

            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, Nothing, "登録が完了しました。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
        End If
    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        If TEMP_PATH_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "Tempパスが未入力です。", _
                                            "Tempパスを入力して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            TEMP_PATH_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If OPEN_HOUR_T.Text <> "" Then
            If OPEN_MINUTE_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "営業時間(開店時間-分)が未入力です。", _
                                                "営業時間を確認して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                OPEN_MINUTE_T.Focus()
                INPUT_CHECK = False
                Exit Function
            End If
            If CLOSE_HOUR_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "営業時間(閉店時間-時)が未入力です。", _
                                                "営業時間を確認して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                CLOSE_HOUR_T.Focus()
                INPUT_CHECK = False
                Exit Function
            End If
            If CLOSE_MINUTE_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "営業時間(閉店時間-分)が未入力です。", _
                                                "営業時間を確認して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                CLOSE_MINUTE_T.Focus()
                INPUT_CHECK = False
                Exit Function
            End If
            If CInt(OPEN_HOUR_T.Text) > CInt(CLOSE_HOUR_T.Text) Then
                Message_form = New cMessageLib.fMessage(1, "営業時間が不正です。", _
                                                "営業時間を確認して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing

            End If
        End If
        INPUT_CHECK = True
    End Function

    Private Sub END_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles END_B.Click
        oConf = Nothing
        oConn = Nothing
        oCommand = Nothing
        oDataReader = Nothing
        Me.Dispose()

    End Sub

    Private Sub FIND_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sPath As String
        Dim pLen As Integer

        sPath = oTool.FileSearch("フォルダー選択", Nothing, "OwP-DB.MDB")
        If sPath <> "" Then
            pLen = sPath.LastIndexOf("\")
            DB_PATH_T.Text = sPath.Substring(0, pLen)
        End If

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "接続先データベースを切り替えます。", _
                                        "よろしいですか？", _
                                        Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
            'DBパスのレジストリ登録
            If DB_PATH_T.Text = "" Then
                Return
            End If

            'レジストリへの書き込み
            '（「HKEY_CURRENT_USER\」に書き込む）
            'キーを開く
            Dim regkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Ocf\Eazy_POS\")

            'レジストリへの書き込み
            '文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue("File1", DB_PATH_T.Text)

            '閉じる
            regkey.Close()

            '環境情報の読込み
            INIT_PROC()

        End If
        Message_form = Nothing

    End Sub

    Private Sub FIND_DB_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_DB_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            DB_PATH_T.Text = sPath.ToString.Substring(0, sPath.ToString.LastIndexOf("\"))
        End If
        DB_PATH_T.Focus()
    End Sub

    Private Sub FIND_BK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_BK_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            BK_PATH_T.Text = sPath.ToString.Substring(0, sPath.ToString.LastIndexOf("\"))
        End If
        BK_PATH_T.Focus()
    End Sub

    Private Sub FIND_TEMP_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_TEMP_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            TEMP_PATH_T.Text = sPath.ToString.Substring(0, sPath.ToString.LastIndexOf("\"))
        End If

    End Sub


    Private Sub DB_PATH_T_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DB_PATH_T.Validated
        Dim pMessage_form As cMessageLib.fMessage
        Dim regkey As Microsoft.Win32.RegistryKey

        If DB_PATH_T.Text <> oDB_Path Then

            pMessage_form = New cMessageLib.fMessage(2, "接続先データベースを切り替えます。", _
                                            "よろしいですか？", _
                                            Nothing, Nothing)
            pMessage_form.ShowDialog()
            If pMessage_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                'DBパスのレジストリ登録
                If DB_PATH_T.Text = "" Then
                    DB_PATH_T.Text = oDB_Path
                Else

                    'レジストリへの書き込み
                    '（「HKEY_CURRENT_USER\」に書き込む）
                    'キーを開く
                    regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Ocf\Eazy_POS\")

                    'レジストリへの書き込み
                    '文字列を書き込む（REG_SZで書き込まれる）
                    regkey.SetValue("File1", DB_PATH_T.Text)

                    '閉じる
                    regkey.Close()

                    oDB_Path = DB_PATH_T.Text

                    '環境情報の読込み
                    INIT_PROC()
                End If
            Else
                DB_PATH_T.Text = oDB_Path
            End If

            pMessage_form.Dispose()
            pMessage_form = Nothing
        End If

    End Sub

    Private Sub CHANNEL_NAME_C_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_C.Text, Nothing, oTran)
        CHANNEL_NAME_C.Text = oChannel(0).sChannelName
        CHANNEL_CODE_T.Text = oConf(0).sRegChannelCode
        oChannelDBIO = Nothing

    End Sub

    Private Sub RECIRT_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECIRT_C.SelectedIndexChanged
        If RECIRT_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, RECIRT_C.Text, Nothing, Nothing, oTran)
            RECIRT_C.Text = oOPOS(0).sModelName
            RECIRT_T.Text = oOPOS(0).sOPOS_ID
        Else
            RECIRT_C.Text = "未接続"
            RECIRT_T.Text = -1
        End If
    End Sub

    Private Sub DRAWER_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DRAWER_C.SelectedIndexChanged
        If DRAWER_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, DRAWER_C.Text, Nothing, Nothing, oTran)
            DRAWER_C.Text = oOPOS(0).sModelName
            DRAWER_T.Text = oOPOS(0).sOPOS_ID
        Else
            DRAWER_C.Text = "未接続"
            DRAWER_T.Text = -1
        End If
    End Sub

    Private Sub DISPLAY_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISPLAY_C.SelectedIndexChanged
        If DISPLAY_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, DISPLAY_C.Text, Nothing, Nothing, oTran)
            DISPLAY_C.Text = oOPOS(0).sModelName
            DISPLAY_T.Text = oOPOS(0).sOPOS_ID
        Else
            DISPLAY_C.Text = "未接続"
            DISPLAY_T.Text = -1
        End If
    End Sub

    Private Sub CARD_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARD_C.SelectedIndexChanged
        If CARD_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, CARD_C.Text, Nothing, Nothing, oTran)
            CARD_C.Text = oOPOS(0).sModelName
            CARD_T.Text = oOPOS(0).sOPOS_ID
        Else
            CARD_C.Text = "未接続"
            CARD_T.Text = -1
        End If
    End Sub

    Private Sub CHANGE_C_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANGE_C.SelectedIndexChanged
        If CHANGE_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, CHANGE_C.Text, Nothing, Nothing, oTran)
            CHANGE_C.Text = oOPOS(0).sModelName
            CHANGE_T.Text = oOPOS(0).sOPOS_ID
        Else
            CHANGE_C.Text = "未接続"
            CHANGE_T.Text = -1
        End If
    End Sub

    Private Sub CTI_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CTI_C.SelectedIndexChanged
        If CTI_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, CTI_C.Text, Nothing, Nothing, oTran)
            CTI_C.Text = oOPOS(0).sModelName
            CTI_T.Text = oOPOS(0).sOPOS_ID
            CTI_PORT_T.Enabled = True
        Else
            CTI_C.Text = "未接続"
            CTI_T.Text = -1
            CTI_PORT_T.Text = ""
            CTI_PORT_T.Enabled = False
        End If
    End Sub
    Private Sub CARDP_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CARDP_C.SelectedIndexChanged
        If CARDP_C.SelectedIndex > 0 Then
            ReDim oOPOS(0)
            oMstOPOSDBIO.getOPOSMst(oOPOS, CARDP_C.Text, Nothing, Nothing, oTran)
            CARDP_C.Text = oOPOS(0).sModelName
            CARDP_T.Text = oOPOS(0).sOPOS_ID
        Else
            CARDP_C.Text = "未接続"
            CARDP_T.Text = -1
        End If
    End Sub

    Private Sub FIND_RLOGO_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_RLOGO_B.Click
        Dim sPath As String
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\rLogo.BMP"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            RLOGO_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub FIND_BLOGO_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_BLOGO_B.Click
        Dim sPath As String
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\bLogo.BMP"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            BLOGO_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub POINT_CARD_FORE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_CARD_FORE_B.Click
        Dim sPath As String
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardFore.BMP"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            POINT_CARD_FORE_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub POINT_CARD_BACK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_CARD_BACK_B.Click
        Dim sPath As String
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\PointCardBack.BMP"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            POINT_CARD_BACK_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub FIN_SOFT_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FIN_SOFT_NAME_C.SelectedIndexChanged
        If FIN_SOFT_NAME_C.SelectedIndex > 0 Then
            ReDim oSoft(0)
            oMstSoftDBIO.getSoftMst(oSoft, Nothing, FIN_SOFT_NAME_C.Text, Nothing, 1, Nothing, oTran)
            FIN_SOFT_NAME_C.Text = oSoft(0).sSoftName
            FIN_SOFT_CODE_T.Text = oSoft(0).sSoftCode
        Else
            FIN_SOFT_NAME_C.Text = "未使用"
            FIN_SOFT_CODE_T.Text = -1
        End If

    End Sub

    Private Sub DELIVERY_SOFT_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DELIVERY_SOFT_NAME_C.SelectedIndexChanged
        If DELIVERY_SOFT_NAME_C.SelectedIndex > 0 Then
            ReDim oSoft(0)
            oMstSoftDBIO.getSoftMst(oSoft, Nothing, DELIVERY_SOFT_NAME_C.Text, Nothing, 2, Nothing, oTran)
            DELIVERY_SOFT_NAME_C.Text = oSoft(0).sSoftName
            DELIVERY_SOFT_CODE_T.Text = oSoft(0).sSoftCode
        Else
            DELIVERY_SOFT_NAME_C.Text = "未使用"
            DELIVERY_SOFT_CODE_T.Text = -1
        End If

    End Sub
    Private Sub MAKE_TIME_SET()

        '------------------------------------------------------------------------------------------
        '2016/05/11
        '及川和彦
        'レジストリが存在しない場合の処理を追加
        'FROM
        '------------------------------------------------------------------------------------------

        'MAKE_TIME_T.Text = String.Format("{0:00} : {1:00} ～ {2:00} : {3:00}", _
        '            CInt(OPEN_HOUR_T.Text) - CInt(GRAPH_OFFSET_OPEN_HOUR_T.Text), _
        '            CInt(OPEN_MINUTE_T.Text) - CInt(GRAPH_OFFSET_OPEN_MIN_T.Text), _
        '            CInt(CLOSE_HOUR_T.Text) - CInt(GRAPH_OFFSET_CLOSE_HOUR_T.Text), _
        '            CInt(CLOSE_MINUTE_T.Text) - CInt(GRAPH_OFFSET_CLOSE_MIN_T.Text))

        If OPEN_HOUR_T.Text <> "" Then
            MAKE_TIME_T.Text = String.Format("{0:00} : {1:00} ～ {2:00} : {3:00}", _
                                CInt(OPEN_HOUR_T.Text) - CInt(GRAPH_OFFSET_OPEN_HOUR_T.Text), _
                                CInt(OPEN_MINUTE_T.Text) - CInt(GRAPH_OFFSET_OPEN_MIN_T.Text), _
                                CInt(CLOSE_HOUR_T.Text) - CInt(GRAPH_OFFSET_CLOSE_HOUR_T.Text), _
                                CInt(CLOSE_MINUTE_T.Text) - CInt(GRAPH_OFFSET_CLOSE_MIN_T.Text))
        Else
            MAKE_TIME_T.Text = String.Format("{0:00} : {1:00} ～ {2:00} : {3:00}", 0, 0, 0, 0)
        End If

        '------------------------------------------------------------------------------------------
        'HERE
        '------------------------------------------------------------------------------------------
    End Sub

    Private Sub GRAPH_OFFSET_OPEN_HOUR_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRAPH_OFFSET_OPEN_HOUR_T.LostFocus
        MAKE_TIME_SET()
    End Sub

    Private Sub GRAPH_OFFSET_OPEN_MIN_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRAPH_OFFSET_OPEN_MIN_T.LostFocus
        MAKE_TIME_SET()
    End Sub

    Private Sub GRAPH_OFFSET_CLOSE_MIN_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRAPH_OFFSET_CLOSE_MIN_T.LostFocus
        MAKE_TIME_SET()
    End Sub

    Private Sub GRAPH_OFFSET_CLOSE_HOUR_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRAPH_OFFSET_CLOSE_HOUR_T.LostFocus
        MAKE_TIME_SET()
    End Sub

    Private Sub MEMBER_CARD_BACK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_CARD_BACK_B.Click
        Dim sPath As String
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\MemberCardBack.BMP"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            MEMBER_CARD_BACK_P.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub RMSG_1_T_Leave(sender As Object, e As EventArgs) Handles RMSG_1_T.Leave
        RMSG1_L.Text = RMSG_1_T.Text
    End Sub
    Private Sub RMSG_2_T_Leave(sender As Object, e As EventArgs) Handles RMSG_2_T.Leave
        RMSG2_L.Text = RMSG_2_T.Text
    End Sub
    Private Sub RMSG_3_T_Leave(sender As Object, e As EventArgs) Handles RMSG_3_T.Leave
        RMSG3_L.Text = RMSG_3_T.Text
    End Sub

    Private Sub POINT_ENABLE_T_Leave(sender As Object, e As EventArgs) Handles POINT_ENABLE_T.Leave
        If POINT_ENABLE_T.Text = "" Then
            POINT_ENABLE_T.Text = "無期限"
        End If
    End Sub
End Class
