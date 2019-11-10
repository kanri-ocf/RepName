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

    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

        'DB_PATH レジストリー読込み
        DB_PATH_T.Text = oTool.RegistryRead("File1")

        If INIT_PROC() Then

            'If oConn.State = ConnectionState.Open Then
            'チャネルコンボセット
            ReDim oChannel(0)
            oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
            RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, 0, Nothing, 1, Tran)
            CHANNEL_NAME_C.Items.Add("")
            For i = 0 To oChannel.Length - 1
                CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
            Next i
            oChannelDBIO = Nothing
        End If


    End Sub
    Private Function INIT_PROC() As Boolean
        Dim StrPath As String
        Dim RecordCnt As Integer

        If System.IO.File.Exists(DB_PATH_T.Text & "\OwP-DB.mdb") Then
            StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_PATH_T.Text & "\OwP-DB.mdb;"
            oConn = New OleDb.OleDbConnection(StrPath)

            'ＤＢ接続を開く
            oConn.Open()

            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            RecordCnt = oMstConfigDBIO.getConfMst(oConf, Tran)
            If RecordCnt > 0 Then
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

            FIND_B.Focus()
            System.Windows.Forms.Application.DoEvents()

            INIT_PROC = False
        End If

    End Function
    'TabControl1のDrawItemイベントハンドラ
    Private Sub TabControl1_DrawItem(ByVal sender As Object, _
                                     ByVal e As System.Windows.Forms.DrawItemEventArgs)

        '対象のTabControlを取得
        Dim tab As System.Windows.Forms.TabControl = CType(sender, System.Windows.Forms.TabControl)

        'タブページのテキストを取得
        Dim txt As String = tab.TabPages(e.Index).Text

        'タブのテキストと背景を描画するためのブラシを決定する
        Dim foreBrush, backBrush As System.Drawing.Brush

        '選択されているタブのテキストを赤、背景を青とする
        foreBrush = System.Drawing.Brushes.Black
        backBrush = System.Drawing.Brushes.Tan

        'StringFormatを作成
        Dim sf As New System.Drawing.StringFormat

        '中央に表示する
        sf.Alignment = System.Drawing.StringAlignment.Center
        sf.LineAlignment = System.Drawing.StringAlignment.Center

        '背景の描画
        e.Graphics.FillRectangle(backBrush, e.Bounds)

        'Textの描画
        e.Graphics.DrawString(txt, e.Font, foreBrush, System.Drawing.RectangleF.op_Implicit(e.Bounds), sf)
    End Sub

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

        '-----------------------
        '   システム設定項目
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

        'レシートロゴファイル名
        RLOGO_T.Text = oConf(0).sRLogoPass
        '領収書ロゴファイル名
        BLOGO_T.Text = oConf(0).sBLogoPass
        'レシートメッセージ（1行目）
        RMSG_1_T.Text = oConf(0).sMessage1
        'レシートメッセージ（2行目）
        RMSG_2_T.Text = oConf(0).sMessage2
        'レシートメッセージ（3行目）
        RMSG_3_T.Text = oConf(0).sMessage3

        'ラインディスプレーメッセージ
        L_MSG_T.Text = oConf(0).sLineMsg

        '---------------------
        '   レジ端末情報
        '---------------------
        'レジチャネル名称
        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, oConf(0).sRegChannelCode, 4, Tran)
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
        '   セキュリティ設定項目
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
    End Sub
    Private Sub DATA_INIT_TO_DISP()
        '-----------------------
        '   システム設定項目
        '-----------------------
        '端数処理
        TROUND_R.Checked = True

        '消費税率
        TAX_T.Text = ""

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

        'レシートロゴファイル名
        RLOGO_T.Text = ""
        '領収書ロゴファイル名
        BLOGO_T.Text = ""
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
        '   セキュリティ設定項目
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
    End Sub

    Private Sub DATA_SET_TO_DB()
        '-----------------------
        '   システム設定項目
        '-----------------------
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
        '
        'レシートロゴファイル名
        oConf(0).sRLogoPass = RLOGO_T.Text
        '領収書ロゴファイル名
        oConf(0).sBLogoPass = BLOGO_T.Text
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
        'レジ端末情報
        '---------------------
        oConf(0).sRegChannelCode = CInt(CHANNEL_CODE_T.Text)
        oConf(0).sRegPCNo = CInt(PC_NO_T.Text)

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
        'セキュリティ設定項目
        '---------------------------
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
        '
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

    Private Sub DB_PATH_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If DB_PATH_T.Text <> "" Then
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
        End If
    End Sub

    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RecordCount As Integer
        Dim oChannel() As cStructureLib.sChannel
        Dim oChannelDBIO As cMstChannelDBIO

        ReDim oChannel(0)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, CHANNEL_NAME_C.Text, Nothing, Nothing, 3, Tran)
        CHANNEL_CODE_T.Text = oConf(0).sRegChannelCode
        oChannelDBIO = Nothing

    End Sub

    Private Sub WRITE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WRITE_B.Click
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

        'DB更新
        DATA_SET_TO_DB()

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(1, Nothing, "登録が完了しました。", _
                                        Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

    End Sub

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

End Class
