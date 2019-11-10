Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cMstConfigDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage
    Private oTool As cTool

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader

        oTool = New cTool

    End Sub

    '----------------------------------------------------------------------
    '　機能：環境マスタに存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ConfExist(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelectTrn As String = _
        "SELECT COUNT(*) FROM 環境マスタ"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            'テーブルから該当取引コードのレコード数読込 
            Dim recCount As Integer
            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                Return True
            Else
                'レコードが存在しない時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstConfigDBIO.ConfExist)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：環境マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された環境マスタを設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getConfMst(ByRef parConf() As cStructureLib.sConfig, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim strSelect As String
        Try
            strSelect = "SELECT * FROM 環境マスタ WHERE 環境マスタ.No = 1 ORDER BY 環境マスタ.No"

            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect

            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()
            i = 0
            While pDataReader.Read()

                ReDim Preserve parConf(i)

                'レコードが取得できた時の処理
                'DBファイルパス
                parConf(i).sDBFilePath = oTool.RegistryRead("File1")
                'BKファイルパス
                parConf(i).sBKFilePath = oTool.RegistryRead("File2")
                'Tempファイルパス
                parConf(i).sTempFilePath = oTool.RegistryRead("File3")

                'No
                parConf(i).sNo = CInt(pDataReader("No"))
                'レシートプリンタ機器種別
                If IsDBNull(pDataReader("レシートプリンタ機器種別")) = True Then
                    parConf(i).sRecertPrinterProductClass = 0
                Else
                    parConf(i).sRecertPrinterProductClass = CInt(pDataReader("レシートプリンタ機器種別"))
                End If
                'ドロワ機器種別
                If IsDBNull(pDataReader("ドロワ機器種別")) = True Then
                    parConf(i).sDrawerProductClass = 0
                Else
                    parConf(i).sDrawerProductClass = CInt(pDataReader("ドロワ機器種別"))
                End If
                'カスタマディスプレー機器種別
                If IsDBNull(pDataReader("カスタマディスプレー機器種別")) = True Then
                    parConf(i).sCustomerDisplayProducttClass = 0
                Else
                    parConf(i).sCustomerDisplayProducttClass = CInt(pDataReader("カスタマディスプレー機器種別"))
                End If
                '磁気カードリーダー機器種別
                If IsDBNull(pDataReader("磁気カードリーダー機器種別")) = True Then
                    parConf(i).sCardReaderProducttClass = 0
                Else
                    parConf(i).sCardReaderProducttClass = CInt(pDataReader("磁気カードリーダー機器種別"))
                End If
                '自動釣銭機機器種別
                If IsDBNull(pDataReader("自動釣銭機機器種別")) = True Then
                    parConf(i).sAutoChangerProducttClass = 0
                Else
                    parConf(i).sAutoChangerProducttClass = CInt(pDataReader("自動釣銭機機器種別"))
                End If
                'CTI機器種別
                If IsDBNull(pDataReader("CTI機器種別")) = True Then
                    parConf(i).sCTIProducttClass = 0
                Else
                    parConf(i).sCTIProducttClass = CInt(pDataReader("CTI機器種別"))
                End If
                'CardPrinter機器種別
                If IsDBNull(pDataReader("カードプリンター機器種別")) = True Then
                    parConf(i).sCardPrinterClass = 0
                Else
                    parConf(i).sCardPrinterClass = CInt(pDataReader("カードプリンター機器種別"))
                End If
                'レジチャネルコード
                parConf(i).sRegChannelCode = CInt(pDataReader("レジチャネルコード"))
                'レジ端末No
                parConf(i).sRegPCNo = CInt(pDataReader("レジ端末No"))
                'レシートロゴパス
                parConf(i).sRLogoPass = pDataReader("レシートロゴファイルパス").ToString
                '領収書ロゴパス
                parConf(i).sBLogoPass = pDataReader("領収書ロゴファイルパス").ToString
                'データ保有期間
                If IsDBNull(pDataReader("データ保有期間")) = True Then
                    parConf(i).sDataPeriod = 0
                Else
                    parConf(i).sDataPeriod = CInt(pDataReader("データ保有期間"))
                End If
                'CTI接続ポート
                parConf(i).sCTIPort = pDataReader("CTI接続ポート").ToString
                '事業所名称
                parConf(i).sCorpName = pDataReader("事業所名称").ToString
                '郵便番号
                parConf(i).sPostCode = pDataReader("郵便番号").ToString
                '住所1
                parConf(i).sAdderess1 = pDataReader("住所1").ToString
                '住所2
                parConf(i).sAdderess2 = pDataReader("住所2").ToString
                'TEL
                parConf(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parConf(i).sFAX = pDataReader("FAX").ToString
                'URL
                parConf(i).sURL = pDataReader("URL").ToString
                'メッセージ1
                parConf(i).sMessage1 = pDataReader("メッセージ1").ToString
                'メッセージ2
                parConf(i).sMessage2 = pDataReader("メッセージ2").ToString
                'メッセージ3
                parConf(i).sMessage3 = pDataReader("メッセージ3").ToString
                '端数処理
                parConf(i).sFracProc = CInt(pDataReader("端数処理"))
                '消費税率
                parConf(i).sTax = CInt(pDataReader("消費税率"))
                '会計処理区分
                parConf(i).sFinClass = CInt(pDataReader("会計処理区分"))
                '税区分
                parConf(i).sTaxClass = CInt(pDataReader("税区分"))
                '締め日
                parConf(i).sCloseDay = CInt(pDataReader("締め日"))
                '標準仕切率
                parConf(i).sRate = CInt(pDataReader("標準仕切率"))
                '連携会計ソフトコード
                parConf(i).sFinSoftCode = CInt(pDataReader("連携会計ソフトコード"))
                '連携配送伝票出力ソフトコード
                parConf(i).sDeliverySoftCode = CInt(pDataReader("連携配送伝票出力ソフトコード"))
                'プログラム1名称
                parConf(i).sFunc_Name1 = pDataReader("プログラム1名称").ToString
                'プログラム1名称
                parConf(i).sFunc_Path1 = pDataReader("プログラム1パス").ToString
                'プログラム2名称
                parConf(i).sFunc_Name2 = pDataReader("プログラム2名称").ToString
                'プログラム2名称
                parConf(i).sFunc_Path2 = pDataReader("プログラム2パス").ToString
                'プログラム3名称
                parConf(i).sFunc_Name3 = pDataReader("プログラム3名称").ToString
                'プログラム3名称
                parConf(i).sFunc_Path3 = pDataReader("プログラム3パス").ToString
                'プログラム4名称
                parConf(i).sFunc_Name4 = pDataReader("プログラム4名称").ToString
                'プログラム4名称
                parConf(i).sFunc_Path4 = pDataReader("プログラム4パス").ToString
                'プログラム5名称
                parConf(i).sFunc_Name5 = pDataReader("プログラム5名称").ToString
                'プログラム5名称
                parConf(i).sFunc_Path5 = pDataReader("プログラム5パス").ToString
                'オプション1項目名
                parConf(i).sOptionName1 = pDataReader("オプション1項目名").ToString
                'オプション2項目名
                parConf(i).sOptionName2 = pDataReader("オプション2項目名").ToString
                'オプション3項目名
                parConf(i).sOptionName3 = pDataReader("オプション3項目名").ToString
                'オプション4項目名
                parConf(i).sOptionName4 = pDataReader("オプション4項目名").ToString
                'オプション5項目名
                parConf(i).sOptionName5 = pDataReader("オプション5項目名").ToString
                'LINEメッセージ
                parConf(i).sLineMsg = pDataReader("LINEメッセージ").ToString

                'YAHOOビジネスユーザーID
                parConf(i).sYahooBisID = pDataReader("YAHOOビジネスユーザーID").ToString
                'YahooビジネスID_LINKプログラム
                parConf(i).sYahooBisIDLinkPG = pDataReader("YahooビジネスID_LINKプログラム").ToString
                'YahooビジネスID_LINKプログラムパラメータ
                parConf(i).sYahooBisIDLinkPR = pDataReader("YahooビジネスID_LINKプログラムパラメータ").ToString

                'YAHOOビジネスユーザーPASS
                parConf(i).sYahooBisPASS = pDataReader("YAHOOビジネスユーザーPASS").ToString
                'YahooビジネスPASS_LINKプログラム
                parConf(i).sYahooBisPASSLinkPG = pDataReader("YahooビジネスPASS_LINKプログラム").ToString
                'YahooビジネスPASS_LINKプログラムパラメータ
                parConf(i).sYahooBisPASSLinkPR = pDataReader("YahooビジネスPASS_LINKプログラムパラメータ").ToString

                'YAHOOユーザーID
                parConf(i).sYahooUserID = pDataReader("YAHOOユーザーID").ToString
                'Yahooユーザー_LINKプログラム
                parConf(i).sYahooUserIDLinkPG = pDataReader("YahooユーザーID_LINKプログラム").ToString
                'Yahooユーザー_LINKプログラムパラメータ
                parConf(i).sYahooUserIDLinkPR = pDataReader("YahooユーザーID_LINKプログラムパラメータ").ToString

                'YAHOOユーザーPASS
                parConf(i).sYahooUserPASS = pDataReader("YAHOOユーザーPASS").ToString
                'YahooユーザーPASS_LINKプログラム
                parConf(i).sYahooUserPASSLinkPG = pDataReader("YahooユーザーPASS_LINKプログラム").ToString
                'YahooユーザーPASS_LINKプログラムパラメータ
                parConf(i).sYahooUserPASSLinkPR = pDataReader("YahooユーザーPASS_LINKプログラムパラメータ").ToString

                ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
                'YAHOOストアアカウント
                parConf(i).sYahooStoreAccount = pDataReader("YAHOOストアアカウント").ToString
                'YAHOOApiKey
                parConf(i).sYahooApiKey = pDataReader("YAHOOApiKey").ToString
                'YAHOOカスタムURI
                parConf(i).sYahooRedirectUri = pDataReader("YAHOOカスタムURI").ToString
                ' ** 2016.08.26 K.Oikawa →　受注API対応 ***


                '楽天RMSユーザーID
                parConf(i).sRakutenRMSUserID = pDataReader("楽天RMSユーザーID").ToString
                '楽天RMSユーザーID_LINKプログラム
                parConf(i).sRakutenRMSUserIDLinkPG = pDataReader("楽天RMSユーザーID_LINKプログラム").ToString
                '楽天RMSユーザーID_LINKプログラムパラメータ
                parConf(i).sRakutenRMSUserIDLinkPR = pDataReader("楽天RMSユーザーID_LINKプログラムパラメータ").ToString

                '楽天RMSユーザーPASS
                parConf(i).sRakutenRMSUserPASS = pDataReader("楽天RMSユーザーPASS").ToString
                '楽天RMSユーザーPASS_LINKプログラム
                parConf(i).sRakutenRMSUserPASSLinkPG = pDataReader("楽天RMSユーザーPASS_LINKプログラム").ToString
                '楽天RMSユーザーPASS_LINKプログラムパラメータ
                parConf(i).sRakutenRMSUserPASSLinkPR = pDataReader("楽天RMSユーザーPASS_LINKプログラムパラメータ").ToString

                '楽天ユーザーID
                parConf(i).sRakutenUserID = pDataReader("楽天ユーザーID").ToString
                '楽天ユーザーID_LINKプログラム
                parConf(i).sRakutenUserIDLinkPG = pDataReader("楽天ユーザーID_LINKプログラム").ToString
                '楽天ユーザー_ID_LINKプログラムパラメータ
                parConf(i).sRakutenUserIDLinkPR = pDataReader("楽天ユーザーID_LINKプログラムパラメータ").ToString

                '楽天ユーザーPASS
                parConf(i).sRakutenUserPASS = pDataReader("楽天ユーザーPASS").ToString
                '楽天ユーザーPASS_LINKプログラム
                parConf(i).sRakutenUserPASSLinkPG = pDataReader("楽天ユーザーPASS_LINKプログラム").ToString
                '楽天ユーザー_LINKプログラムパラメータ
                parConf(i).sRakutenUserPASSLinkPR = pDataReader("楽天ユーザーPASS_LINKプログラムパラメータ").ToString

                '楽天CSVダウンロードID
                parConf(i).sRakutenCSVDownloadID = pDataReader("楽天CSVダウンロードID").ToString
                '楽天CSVダウンロードID_LINKプログラム
                parConf(i).sRakutenCSVDownloadIDLinkPG = pDataReader("楽天CSVダウンロードID_LINKプログラム").ToString
                '楽天CSVダウンロードID_LINKプログラムパラメータ
                parConf(i).sRakutenCSVDownloadIDLinkPR = pDataReader("楽天CSVダウンロードID_LINKプログラムパラメータ").ToString

                '楽天CSVダウンロードPASS
                parConf(i).sRakutenCSVDownloadPASS = pDataReader("楽天CSVダウンロードPASS").ToString
                '楽天CSVダウンロードPASS_LINKプログラム
                parConf(i).sRakutenCSVDownloadPASSLinkPG = pDataReader("楽天CSVダウンロードPASS_LINKプログラム").ToString
                '楽天CSVダウンロードPASS_LINKプログラムパラメータ
                parConf(i).sRakutenCSVDownloadPASSLinkPR = pDataReader("楽天CSVダウンロードPASS_LINKプログラムパラメータ").ToString

                ' ** 2016.08.09 K.Minagawa →　受注API対応 ***
                '楽天API用serviceSecret
                parConf(i).sRakutenAPIServiceSecret = pDataReader("楽天API用serviceSecret").ToString
                '楽天API用licenseKey
                parConf(i).sRakutenAPILicenseKey = pDataReader("楽天API用licenseKey").ToString
                '楽天API用URL
                parConf(i).sRakutenAPIUrl = pDataReader("楽天API用URL").ToString
                ' ** 2016.08.09 K.Minagawa →　受注API対応 ***


                '*** START MINAGAWA 2013/6/20 ***
                'Amazon出品者ID
                parConf(i).sAmazonSellerID = pDataReader("Amazon出品者ID").ToString
                'Amazon出品者ID
                parConf(i).sAmazonSellerIDLinkPG = pDataReader("Amazon出品者ID_LINKプログラム").ToString
                'Amazon出品者ID
                parConf(i).sAmazonSellerIDLinkPR = pDataReader("Amazon出品者ID_LINKプログラムパラメータ").ToString

                'AmazonWebサービスアクセスキーID
                parConf(i).sAmazonWebServiceAccesskeyID = pDataReader("AmazonWebサービスアクセスキーID").ToString
                'AmazonWebサービスアクセスキーID
                parConf(i).sAmazonWebServiceAccesskeyIDLinkPG = pDataReader("AmazonWebサービスアクセスキーID_LINKプログラム").ToString
                'AmazonWebサービスアクセスキーID
                parConf(i).sAmazonWebServiceAccesskeyIDLinkPR = pDataReader("AmazonWebサービスアクセスキーID_LINKプログラムパラメータ").ToString

                'AmazonマーケットプレイスID
                parConf(i).sAmazonMarketPlaceID = pDataReader("AmazonマーケットプレイスID").ToString
                'AmazonマーケットプレイスID
                parConf(i).sAmazonMarketPlaceIDLinkPG = pDataReader("AmazonマーケットプレイスID_LINKプログラム").ToString
                'AmazonマーケットプレイスID
                parConf(i).sAmazonMarketPlaceIDLinkPR = pDataReader("AmazonマーケットプレイスID_LINKプログラムパラメータ").ToString

                'Amazon秘密キー
                parConf(i).sAmazonSecretKey = pDataReader("Amazon秘密キー").ToString
                'Amazon秘密キー
                parConf(i).sAmazonSecretKeyLinkPG = pDataReader("Amazon秘密キー_LINKプログラム").ToString
                'Amazon秘密キー
                parConf(i).sAmazonSecretKeyLinkPR = pDataReader("Amazon秘密キー_LINKプログラムパラメータ").ToString

                'ショップサーブユーザーID
                parConf(i).sShopServID = pDataReader("ショップサーブユーザーID").ToString
                'ショップサーブユーザーID_LINKプログラム
                parConf(i).sShopServIDLinkPG = pDataReader("ショップサーブユーザーID_LINKプログラム").ToString
                'ショップサーブユーザーID_LINKプログラムパラメータ
                parConf(i).sShopServIDLinkPR = pDataReader("ショップサーブユーザーID_LINKプログラムパラメータ").ToString

                'ショップサーブユーザーPASS
                parConf(i).sShopServPass = pDataReader("ショップサーブユーザーPASS").ToString
                'ショップサーブユーザーPASS_LINKプログラム
                parConf(i).sShopServPassLinkPG = pDataReader("ショップサーブユーザーPASS_LINKプログラム").ToString
                'ショップサーブユーザーPASS_LINKプログラムパラメータ
                parConf(i).sShopServPassLinkPR = pDataReader("ショップサーブユーザーPASS_LINKプログラムパラメータ").ToString
                '*** END   MINAGAWA 2013/6/20 ***

                '営業時間_開始時
                If IsDBNull(pDataReader("営業時間_開始時")) = True Then
                    parConf(i).sOpenHour = 0
                Else
                    parConf(i).sOpenHour = CInt(pDataReader("営業時間_開始時"))
                End If
                '営業時間_開始分
                If IsDBNull(pDataReader("営業時間_開始分")) = True Then
                    parConf(i).sOpenMinute = 0
                Else
                    parConf(i).sOpenMinute = CInt(pDataReader("営業時間_開始分"))
                End If
                '営業時間_終了時
                If IsDBNull(pDataReader("営業時間_終了時")) = True Then
                    parConf(i).sCloseHour = 0
                Else
                    parConf(i).sCloseHour = CInt(pDataReader("営業時間_終了時"))
                End If
                '営業時間_終了分
                If IsDBNull(pDataReader("営業時間_終了分")) = True Then
                    parConf(i).sCloseMinute = 0
                Else
                    parConf(i).sCloseMinute = CInt(pDataReader("営業時間_終了分"))
                End If

                '*** START MINAGAWA 2013/6/20 ***
                '統計対象時間_開始時
                If IsDBNull(pDataReader("統計対象時間_開始時")) = True Then
                    parConf(i).sStStartHour = 0
                Else
                    parConf(i).sStStartHour = CInt(pDataReader("統計対象時間_開始時"))
                End If
                '統計対象時間_開始分
                If IsDBNull(pDataReader("統計対象時間_開始分")) = True Then
                    parConf(i).sStStartMinute = 0
                Else
                    parConf(i).sStStartMinute = CInt(pDataReader("統計対象時間_開始分"))
                End If
                '統計対象時間_終了時
                If IsDBNull(pDataReader("統計対象時間_終了時")) = True Then
                    parConf(i).sStEndHour = 0
                Else
                    parConf(i).sStEndHour = CInt(pDataReader("統計対象時間_終了時"))
                End If
                '統計対象時間_終了分
                If IsDBNull(pDataReader("統計対象時間_終了分")) = True Then
                    parConf(i).sStEndMinute = 0
                Else
                    parConf(i).sStEndMinute = CInt(pDataReader("統計対象時間_終了分"))
                End If
                '発注候補抽出期間
                If IsDBNull(pDataReader("発注候補抽出期間")) = True Then
                    parConf(i).sOrderListTerm = 0
                Else
                    parConf(i).sOrderListTerm = CInt(pDataReader("発注候補抽出期間"))
                End If
                '売上サイクル
                If IsDBNull(pDataReader("売上サイクル")) = True Then
                    parConf(i).sSalesTerm = 0
                Else
                    parConf(i).sSalesTerm = CInt(pDataReader("売上サイクル"))
                End If
                '最低売上数量
                If IsDBNull(pDataReader("最低売上数量")) = True Then
                    parConf(i).sMinimumCount = 0
                Else
                    parConf(i).sMinimumCount = CInt(pDataReader("最低売上数量"))
                End If
                '*** END   MINAGAWA 2013/6/20 ***

                'ポイント付与円
                If IsDBNull(pDataReader("ポイント付与円")) = True Then
                    parConf(i).sPointEN = 0
                Else
                    parConf(i).sPointEN = CInt(pDataReader("ポイント付与円"))
                End If
                'ポイント付与率
                If IsDBNull(pDataReader("ポイント付与率")) = True Then
                    parConf(i).sPointRATE = 0
                Else
                    parConf(i).sPointRATE = CInt(pDataReader("ポイント付与率"))
                End If
                'ポイント有効期限
                If IsDBNull(pDataReader("ポイント有効期限")) = True Then
                    parConf(i).sPointEnableMonth = 0
                Else
                    parConf(i).sPointEnableMonth = CInt(pDataReader("ポイント有効期限"))
                End If

                'ポイントカードフォアファイルパス
                parConf(i).sPointForePass = pDataReader("ポイントカードフォアファイルパス").ToString
                'ポイントカードバックファイルパス
                parConf(i).sPointBackPass = pDataReader("ポイントカードバックファイルパス").ToString
                'ポイントカードメッセージ
                parConf(i).sPointCardMsg = pDataReader("ポイントカードメッセージ").ToString

                '会員有効期限
                If IsDBNull(pDataReader("会員有効期限")) = True Then
                    parConf(i).sMemberEnableMonth = 0
                Else
                    parConf(i).sMemberEnableMonth = CInt(pDataReader("会員有効期限"))
                End If
                '会員カードバックファイルパス
                parConf(i).sMemberBackPass = pDataReader("会員カードバックファイルパス").ToString
                '会員カードメッセージ
                parConf(i).sMemberCardMsg = pDataReader("会員カードメッセージ").ToString

                '予約カードメッセージ
                parConf(i).sReservCardMsg = pDataReader("予約カードメッセージ").ToString

                '登録日
                parConf(i).sCraeteDate = pDataReader("登録日").ToString
                '登録時間
                parConf(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parConf(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parConf(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getConfMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstConfigDBIO.getConfMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：環境マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertConfMst(ByRef parConf() As cStructureLib.sConfig, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String
        Dim regkey As Microsoft.Win32.RegistryKey

        'レジストリへの書き込み
        '（「HKEY_CURRENT_USER\」に書き込む）
        'キーを開く
        regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Ocf\Eazy_POS\")

        'レジストリへの書き込み
        '文字列を書き込む（REG_SZで書き込まれる）
        'DBファイルパス
        regkey.SetValue("File1", parConf(0).sDBFilePath)
        'BKファイルパス
        regkey.SetValue("File2", parConf(0).sBKFilePath)
        'Tempファイルパス
        regkey.SetValue("File3", parConf(0).sTempFilePath)

        'SQL文の設定
        strUpdate = "INSERT INTO 予約データ (" & _
                        "No, " & _
                        "レシートプリンタ機器種別, " & _
                        "ドロワ機器種別, " & _
                        "カスタマディスプレー機器種別, " & _
                        "磁気カードリーダー機器種別, " & _
                        "自動釣銭機機器種別, " & _
                        "CTI機器種別, " & _
                        "カードプリンター機器種別, " & _
                        "レジチャネルコード, " & _
                        "レジ端末No, " & _
                        "レシートロゴファイルパス, " & _
                        "領収書ロゴファイルパス, " & _
                        "データ保有期間, " & _
                        "CTI接続ポート, " & _
                        "事業所名称, " & _
                        "郵便番号, " & _
                        "住所1, " & _
                        "住所2, " & _
                        "TEL, " & _
                        "FAX, " & _
                        "URL, " & _
                        "メッセージ1, " & _
                        "メッセージ2, " & _
                        "メッセージ3, " & _
                        "端数処理, " & _
                        "消費税率, " & _
                        "会計処理区分, " & _
                        "税区分, " & _
                        "締め日, " & _
                        "標準仕切率, " & _
                        "連携会計ソフトコード" & _
                        "連携配送伝票出力ソフトコード" & _
                        "プログラム1名称, " & _
                        "プログラム1パス, " & _
                        "プログラム2名称, " & _
                        "プログラム2パス, " & _
                        "プログラム3名称, " & _
                        "プログラム3パス, " & _
                        "プログラム4名称, " & _
                        "プログラム4パス, " & _
                        "プログラム5名称, " & _
                        "プログラム5パス, " & _
                        "オプション1項目名, " & _
                        "オプション2項目名, " & _
                        "オプション3項目名, " & _
                        "オプション4項目名, " & _
                        "オプション5項目名, " & _
                        "LINEメッセージ, " & _
                        "YahooビジネスユーザーID, " & _
                        "YahooビジネスID_LINKプログラム, " & _
                        "YahooビジネスID_LINKプログラムパラメータ, " & _
                        "YahooビジネスユーザーPASS, " & _
                        "YahooビジネスPASS_LINKプログラム, " & _
                        "YahooビジネスPASS_LINKプログラムパラメータ, " & _
                        "YahooユーザーID, " & _
                        "YahooユーザーID_LINKプログラム, " & _
                        "YahooユーザーID_LINKプログラムパラメータ, " & _
                        "YahooユーザーPASS, " & _
                        "YahooユーザーPASS_LINKプログラム, " & _
                        "YahooユーザーPASS_LINKプログラムパラメータ, " & _
                        "YAHOOストアアカウント, " & _
                        "YAHOOApiKey, " & _
                        "YAHOOカスタムURI, " & _
                        "楽天RMSユーザーID, " & _
                        "楽天RMSユーザーID_LINKプログラム, " & _
                        "楽天RMSユーザーID_LINKプログラムパラメータ, " & _
                        "楽天RMSユーザーPASS, " & _
                        "楽天RMSユーザーPASS_LINKプログラム, " & _
                        "楽天RMSユーザーPASS_LINKプログラムパラメータ, " & _
                        "楽天ユーザーID, " & _
                        "楽天ユーザーID_LINKプログラム, " & _
                        "楽天ユーザーID_LINKプログラムパラメータ, " & _
                        "楽天ユーザーPASS, " & _
                        "楽天ユーザーPASS_LINKプログラム, " & _
                        "楽天ユーザーPASS_LINKプログラムパラメータ, " & _
                        "楽天CSVダウンロードID, " & _
                        "楽天CSVダウンロードID_LINKプログラム, " & _
                        "楽天CSVダウンロードID_LINKプログラムパラメータ, " & _
                        "楽天CSVダウンロードPASS, " & _
                        "楽天CSVダウンロードPASS_LINKプログラム, " & _
                        "楽天CSVダウンロードPASS_LINKプログラムパラメータ, " & _
                        "楽天API用serviceSecret, " & _
                        "楽天API用licenseKey, " & _
                        "楽天API用URL, " & _
                        "Amazon出品者ID, " & _
                        "Amazon出品者ID_LINKプログラム, " & _
                        "Amazon出品者ID_LINKプログラムパラメータ, " & _
                        "AmazonWebサービスアクセスキーID, " & _
                        "AmazonWebサービスアクセスキーID_LINKプログラム, " & _
                        "AmazonWebサービスアクセスキーID_LINKプログラムパラメータ, " & _
                        "AmazonマーケットプレイスID, " & _
                        "AmazonマーケットプレイスID_LINKプログラム, " & _
                        "AmazonマーケットプレイスID_LINKプログラムパラメータ, " & _
                        "Amazon秘密キー, " & _
                        "Amazon秘密キー_LINKプログラム, " & _
                        "Amazon秘密キー_LINKプログラムパラメータ, " & _
                        "ショップサーブユーザーID, " & _
                        "ショップサーブユーザーID_LINKプログラム, " & _
                        "ショップサーブユーザーID_LINKプログラムパラメータ, " & _
                        "ショップサーブユーザーPASS, " & _
                        "ショップサーブユーザーPASS_LINKプログラム, " & _
                        "ショップサーブユーザーPASS_LINKプログラムパラメータ, " & _
                        "営業時間_開始時, " & _
                        "営業時間_開始分, " & _
                        "営業時間_終了時, " & _
                        "営業時間_終了分, " & _
                        "統計対象時間_開始時, " & _
                        "統計対象時間_開始分, " & _
                        "統計対象時間_終了時, " & _
                        "統計対象時間_終了分, " & _
                        "発注候補抽出期間, " & _
                        "売上サイクル, " & _
                        "最低売上数量, " & _
                        "ポイント付与円, " & _
                        "ポイント付与率, " & _
                        "ポイント有効期限, " & _
                        "ポイントカードフォアファイルパス, " & _
                        "ポイントカードバックファイルパス, " & _
                        "ポイントカードメッセージ, " & _
                        "会員有効期限, " & _
                        "会員カードバックファイルパス, " & _
                        "会員カードメッセージ, " & _
                        "予約カードメッセージ, " & _
                        "登録日, " & _
                        "登録時間, " & _
                        "最終更新日, " & _
                        "最終更新時間 " & _
                    ") VALUES ( " & _
                        parConf(0).sNo & ", " & _
                        parConf(0).sRecertPrinterProductClass & ", " & _
                        parConf(0).sDrawerProductClass & ", " & _
                        parConf(0).sCustomerDisplayProducttClass & ", " & _
                        parConf(0).sCardReaderProducttClass & ", " & _
                        parConf(0).sAutoChangerProducttClass & ", " & _
                        parConf(0).sCTIProducttClass & ", " & _
                        parConf(0).sCardPrinterClass & ", " & _
                        parConf(0).sRegChannelCode & ", " & _
                        parConf(0).sRegPCNo & ", " & _
                        """" & parConf(0).sRLogoPass & """, " & _
                        """" & parConf(0).sBLogoPass & """, " & _
                        parConf(0).sDataPeriod & ", " & _
                        """" & parConf(0).sCTIPort & """, " & _
                        """" & parConf(0).sCorpName & """, " & _
                        """" & parConf(0).sPostCode & """, " & _
                        """" & parConf(0).sAdderess1 & """, " & _
                        """" & parConf(0).sAdderess2 & """, " & _
                        """" & parConf(0).sTEL & """, " & _
                        """" & parConf(0).sFAX & """, " & _
                        """" & parConf(0).sURL & """, " & _
                        """" & parConf(0).sMessage1 & """, " & _
                        """" & parConf(0).sMessage2 & """, " & _
                        """" & parConf(0).sMessage3 & """, " & _
                        parConf(0).sFracProc & ", " & _
                        parConf(0).sTax & ", " & _
                        parConf(0).sFinClass & ", " & _
                        parConf(0).sTaxClass & ", " & _
                        parConf(0).sCloseDay & ", " & _
                        parConf(0).sRate & ", " & _
                        parConf(0).sFinSoftCode & ", " & _
                        parConf(0).sDeliverySoftCode & ", " & _
                        """" & parConf(0).sFunc_Name1 & """, " & _
                        """" & parConf(0).sFunc_Path1 & """, " & _
                        """" & parConf(0).sFunc_Name2 & """, " & _
                        """" & parConf(0).sFunc_Path2 & """, " & _
                        """" & parConf(0).sFunc_Name3 & """, " & _
                        """" & parConf(0).sFunc_Path3 & """, " & _
                        """" & parConf(0).sFunc_Name4 & """, " & _
                        """" & parConf(0).sFunc_Path4 & """, " & _
                        """" & parConf(0).sFunc_Name5 & """, " & _
                        """" & parConf(0).sFunc_Path5 & """, " & _
                        """" & parConf(0).sOptionName1 & """, " & _
                        """" & parConf(0).sOptionName2 & """, " & _
                        """" & parConf(0).sOptionName3 & """, " & _
                        """" & parConf(0).sOptionName4 & """, " & _
                        """" & parConf(0).sOptionName5 & """, " & _
                        """" & parConf(0).sLineMsg & """, " & _
                        """" & parConf(0).sYahooBisID & """, " & _
                        """" & parConf(0).sYahooBisIDLinkPG & """, " & _
                        """" & parConf(0).sYahooBisIDLinkPR & """, " & _
                        """" & parConf(0).sYahooBisPASS & """, " & _
                        """" & parConf(0).sYahooBisPASSLinkPG & """, " & _
                        """" & parConf(0).sYahooBisPASSLinkPR & """, " & _
                        """" & parConf(0).sYahooUserID & """, " & _
                        """" & parConf(0).sYahooUserIDLinkPG & """, " & _
                        """" & parConf(0).sYahooUserIDLinkPR & """, " & _
                        """" & parConf(0).sYahooUserPASS & """, " & _
                        """" & parConf(0).sYahooUserPASSLinkPG & """, " & _
                        """" & parConf(0).sYahooUserPASSLinkPR & """, " & _
                        """" & parConf(0).sYahooStoreAccount & """, " & _
                        """" & parConf(0).sYahooApiKey & """, " & _
                        """" & parConf(0).sYahooRedirectUri & """, " & _
                        """" & parConf(0).sRakutenRMSUserID & """, " & _
                        """" & parConf(0).sRakutenRMSUserIDLinkPG & """, " & _
                        """" & parConf(0).sRakutenRMSUserIDLinkPR & """, " & _
                        """" & parConf(0).sRakutenRMSUserPASS & """, " & _
                        """" & parConf(0).sRakutenRMSUserPASSLinkPG & """, " & _
                        """" & parConf(0).sRakutenRMSUserPASSLinkPR & """, " & _
                        """" & parConf(0).sRakutenUserID & """, " & _
                        """" & parConf(0).sRakutenUserIDLinkPG & """, " & _
                        """" & parConf(0).sRakutenUserIDLinkPR & """, " & _
                        """" & parConf(0).sRakutenUserPASS & """, " & _
                        """" & parConf(0).sRakutenUserPASSLinkPG & """, " & _
                        """" & parConf(0).sRakutenUserPASSLinkPR & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadID & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadIDLinkPG & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadIDLinkPR & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadPASS & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadPASSLinkPG & """, " & _
                        """" & parConf(0).sRakutenCSVDownloadPASSLinkPR & """, " & _
                        """" & parConf(0).sRakutenAPIServiceSecret & """, " & _
                        """" & parConf(0).sRakutenAPILicenseKey & """, " & _
                        """" & parConf(0).sRakutenAPIUrl & """, " & _
                        """" & parConf(0).sAmazonSellerID & """, " & _
                        """" & parConf(0).sAmazonSellerIDLinkPG & """, " & _
                        """" & parConf(0).sAmazonSellerIDLinkPR & """, " & _
                        """" & parConf(0).sAmazonWebServiceAccesskeyID & """, " & _
                        """" & parConf(0).sAmazonWebServiceAccesskeyIDLinkPG & """, " & _
                        """" & parConf(0).sAmazonWebServiceAccesskeyIDLinkPR & """, " & _
                        """" & parConf(0).sAmazonMarketPlaceID & """, " & _
                        """" & parConf(0).sAmazonMarketPlaceIDLinkPG & """, " & _
                        """" & parConf(0).sAmazonMarketPlaceIDLinkPR & """, " & _
                        """" & parConf(0).sAmazonSecretKey & """, " & _
                        """" & parConf(0).sAmazonSecretKeyLinkPG & """, " & _
                        """" & parConf(0).sAmazonSecretKeyLinkPR & """, " & _
                        """" & parConf(0).sShopServID & """, " & _
                        """" & parConf(0).sShopServIDLinkPG & """, " & _
                        """" & parConf(0).sShopServIDLinkPR & """, " & _
                        """" & parConf(0).sShopServPass & """, " & _
                        """" & parConf(0).sShopServPassLinkPG & """, " & _
                        """" & parConf(0).sShopServPassLinkPR & """, " & _
                        parConf(0).sOpenHour & ", " & _
                        parConf(0).sOpenMinute & ", " & _
                        parConf(0).sCloseHour & ", " & _
                        parConf(0).sCloseMinute & ", " & _
                        parConf(0).sStStartHour & ", " & _
                        parConf(0).sStStartMinute & ", " & _
                        parConf(0).sStEndHour & ", " & _
                        parConf(0).sStEndMinute & ", " & _
                        parConf(0).sOrderListTerm & ", " & _
                        parConf(0).sSalesTerm & ", " & _
                        parConf(0).sMinimumCount & ", " & _
                        parConf(0).sPointEN & ", " & _
                        parConf(0).sPointRATE & ", " & _
                        parConf(0).sPointEnableMonth & ", " & _
                        """" & parConf(0).sPointForePass.ToString & """, " & _
                        """" & parConf(0).sPointBackPass.ToString & """, " & _
                        """" & parConf(0).sPointCardMsg.ToString & """, " & _
                        parConf(0).sMemberEnableMonth & ", " & _
                        """" & parConf(0).sMemberBackPass.ToString & """, " & _
                        """" & parConf(0).sMemberCardMsg.ToString & """, " & _
                        """" & parConf(0).sReservCardMsg.ToString & """, " & _
                       "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss""), " & _
                        "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss"") " & _
                    ") "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            insertConfMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstConfigDBIO.insertConfMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：環境マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateConfMst(ByRef parConf() As cStructureLib.sConfig, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        Dim regkey As Microsoft.Win32.RegistryKey

        'レジストリへの書き込み
        '（「HKEY_CURRENT_USER\」に書き込む）
        'キーを開く
        regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Ocf\Eazy_POS\")

        'レジストリへの書き込み
        '文字列を書き込む（REG_SZで書き込まれる）
        'DBファイルパス
        regkey.SetValue("File1", parConf(0).sDBFilePath)
        'BKファイルパス
        regkey.SetValue("File2", parConf(0).sBKFilePath)
        'Tempファイルパス
        regkey.SetValue("File3", parConf(0).sTempFilePath)

        'SQL文の設定
        strUpdate = "UPDATE 環境マスタ SET " & _
                            "環境マスタ.レジチャネルコード=" & parConf(0).sRegChannelCode & ",  " & _
                            "環境マスタ.レシートプリンタ機器種別 = " & parConf(0).sRecertPrinterProductClass & ", " & _
                            "環境マスタ.ドロワ機器種別 = " & parConf(0).sDrawerProductClass & ", " & _
                            "環境マスタ.カスタマディスプレー機器種別 = " & parConf(0).sCustomerDisplayProducttClass & ", " & _
                            "環境マスタ.磁気カードリーダー機器種別 = " & parConf(0).sCardReaderProducttClass & ", " & _
                            "環境マスタ.自動釣銭機機器種別 = " & parConf(0).sAutoChangerProducttClass & ", " & _
                            "環境マスタ.CTI機器種別 = " & parConf(0).sCTIProducttClass & ", " & _
                            "環境マスタ.カードプリンター機器種別 = " & parConf(0).sCardPrinterClass & ", " & _
                            "環境マスタ.レジ端末No=" & parConf(0).sRegPCNo & ",  " & _
                            "環境マスタ.レシートロゴファイルパス=""" & parConf(0).sRLogoPass.ToString & """,  " & _
                            "環境マスタ.領収書ロゴファイルパス=""" & parConf(0).sBLogoPass.ToString & """,  " & _
                            "環境マスタ.データ保有期間=" & parConf(0).sDataPeriod & ",  " & _
                            "環境マスタ.CTI接続ポート=""" & parConf(0).sCTIPort.ToString & """,  " & _
                            "環境マスタ.事業所名称=""" & parConf(0).sCorpName.ToString & """,  " & _
                            "環境マスタ.郵便番号=""" & parConf(0).sPostCode.ToString & """,  " & _
                            "環境マスタ.住所1=""" & parConf(0).sAdderess1.ToString & """,  " & _
                            "環境マスタ.住所2=""" & parConf(0).sAdderess2.ToString & """,  " & _
                            "環境マスタ.TEL=""" & parConf(0).sTEL.ToString & """,  " & _
                            "環境マスタ.FAX=""" & parConf(0).sFAX.ToString & """,  " & _
                            "環境マスタ.URL=""" & parConf(0).sURL.ToString & """,  " & _
                            "環境マスタ.メッセージ1=""" & parConf(0).sMessage1.ToString & """,  " & _
                            "環境マスタ.メッセージ2=""" & parConf(0).sMessage2.ToString & """,  " & _
                            "環境マスタ.メッセージ3=""" & parConf(0).sMessage3.ToString & """,  " & _
                            "環境マスタ.端数処理=" & parConf(0).sFracProc & ",  " & _
                            "環境マスタ.消費税率=" & parConf(0).sTax.ToString & ",  " & _
                            "環境マスタ.会計処理区分=" & parConf(0).sFinClass.ToString & ",  " & _
                            "環境マスタ.税区分=" & parConf(0).sTaxClass.ToString & ",  " & _
                            "環境マスタ.締め日=" & parConf(0).sCloseDay.ToString & ",  " & _
                            "環境マスタ.標準仕切率=" & parConf(0).sRate.ToString & ",  " & _
                            "環境マスタ.連携会計ソフトコード=" & parConf(0).sFinSoftCode & ",  " & _
                            "環境マスタ.連携配送伝票出力ソフトコード=" & parConf(0).sDeliverySoftCode & ",  " & _
                            "環境マスタ.プログラム1名称=""" & parConf(0).sFunc_Name1.ToString & """,  " & _
                            "環境マスタ.プログラム1パス=""" & parConf(0).sFunc_Path1.ToString & """,  " & _
                            "環境マスタ.プログラム2名称=""" & parConf(0).sFunc_Name2.ToString & """,  " & _
                            "環境マスタ.プログラム2パス=""" & parConf(0).sFunc_Path2.ToString & """,  " & _
                            "環境マスタ.プログラム3名称=""" & parConf(0).sFunc_Name3.ToString & """,  " & _
                            "環境マスタ.プログラム3パス=""" & parConf(0).sFunc_Path3.ToString & """,  " & _
                            "環境マスタ.プログラム4名称=""" & parConf(0).sFunc_Name4.ToString & """,  " & _
                            "環境マスタ.プログラム4パス=""" & parConf(0).sFunc_Path4.ToString & """,  " & _
                            "環境マスタ.プログラム5名称=""" & parConf(0).sFunc_Name5.ToString & """,  " & _
                            "環境マスタ.プログラム5パス=""" & parConf(0).sFunc_Path5.ToString & """,  " & _
                            "環境マスタ.オプション1項目名=""" & parConf(0).sOptionName1.ToString & """,  " & _
                            "環境マスタ.オプション2項目名=""" & parConf(0).sOptionName2.ToString & """,  " & _
                            "環境マスタ.オプション3項目名=""" & parConf(0).sOptionName3.ToString & """,  " & _
                            "環境マスタ.オプション4項目名=""" & parConf(0).sOptionName4.ToString & """,  " & _
                            "環境マスタ.オプション5項目名=""" & parConf(0).sOptionName5.ToString & """,  " & _
                            "環境マスタ.YahooビジネスユーザーID=""" & parConf(0).sYahooBisID.ToString & """,  " & _
                            "環境マスタ.YahooビジネスID_LINKプログラム=""" & parConf(0).sYahooBisIDLinkPG.ToString & """,  " & _
                            "環境マスタ.YahooビジネスID_LINKプログラムパラメータ=""" & parConf(0).sYahooBisIDLinkPR.ToString & """,  " & _
                            "環境マスタ.YahooビジネスユーザーPASS=""" & parConf(0).sYahooBisPASS.ToString & """,  " & _
                            "環境マスタ.YahooビジネスPASS_LINKプログラム=""" & parConf(0).sYahooBisPASSLinkPG.ToString & """,  " & _
                            "環境マスタ.YahooビジネスPASS_LINKプログラムパラメータ=""" & parConf(0).sYahooBisPASSLinkPR.ToString & """,  " & _
                            "環境マスタ.YahooユーザーID=""" & parConf(0).sYahooUserID.ToString & """,  " & _
                            "環境マスタ.YahooユーザーID_LINKプログラム=""" & parConf(0).sYahooUserIDLinkPG.ToString & """,  " & _
                            "環境マスタ.YahooユーザーID_LINKプログラムパラメータ=""" & parConf(0).sYahooUserIDLinkPR.ToString & """,  " & _
                            "環境マスタ.YahooユーザーPASS=""" & parConf(0).sYahooUserPASS.ToString & """,  " & _
                            "環境マスタ.YahooユーザーPASS_LINKプログラム=""" & parConf(0).sYahooUserPASSLinkPG.ToString & """,  " & _
                            "環境マスタ.YahooユーザーPASS_LINKプログラムパラメータ=""" & parConf(0).sYahooUserPASSLinkPR.ToString & """,  " & _
                            "環境マスタ.YAHOOストアアカウント=""" & parConf(0).sYahooStoreAccount.ToString & """,  " & _
                            "環境マスタ.YAHOOApiKey=""" & parConf(0).sYahooApiKey.ToString & """,  " & _
                            "環境マスタ.YAHOOカスタムURI=""" & parConf(0).sYahooRedirectUri.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーID=""" & parConf(0).sRakutenRMSUserID.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーID_LINKプログラム=""" & parConf(0).sRakutenRMSUserIDLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーID_LINKプログラムパラメータ=""" & parConf(0).sRakutenRMSUserIDLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーPASS=""" & parConf(0).sRakutenRMSUserPASS.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーPASS_LINKプログラム=""" & parConf(0).sRakutenRMSUserPASSLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天RMSユーザーPASS_LINKプログラムパラメータ=""" & parConf(0).sRakutenRMSUserPASSLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーID=""" & parConf(0).sRakutenUserID.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーID_LINKプログラム=""" & parConf(0).sRakutenUserIDLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーID_LINKプログラムパラメータ=""" & parConf(0).sRakutenUserIDLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーPASS=""" & parConf(0).sRakutenUserPASS.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーPASS_LINKプログラム=""" & parConf(0).sRakutenUserPASSLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天ユーザーPASS_LINKプログラムパラメータ=""" & parConf(0).sRakutenUserPASSLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードID=""" & parConf(0).sRakutenCSVDownloadID.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードID_LINKプログラム=""" & parConf(0).sRakutenCSVDownloadIDLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードID_LINKプログラムパラメータ=""" & parConf(0).sRakutenCSVDownloadIDLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードPASS=""" & parConf(0).sRakutenCSVDownloadPASS.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードPASS_LINKプログラム=""" & parConf(0).sRakutenCSVDownloadPASSLinkPG.ToString & """,  " & _
                            "環境マスタ.楽天CSVダウンロードPASS_LINKプログラムパラメータ=""" & parConf(0).sRakutenCSVDownloadPASSLinkPR.ToString & """,  " & _
                            "環境マスタ.楽天API用serviceSecret=""" & parConf(0).sRakutenAPIServiceSecret.ToString & """,  " & _
                            "環境マスタ.楽天API用licenseKey=""" & parConf(0).sRakutenAPILicenseKey.ToString & """,  " & _
                            "環境マスタ.楽天API用URL=""" & parConf(0).sRakutenAPIUrl.ToString & """,  " & _
                            "環境マスタ.LINEメッセージ=""" & parConf(0).sLineMsg.ToString & """,  " & _
                            "環境マスタ.Amazon出品者ID=""" & parConf(0).sAmazonSellerID.ToString & """,  " & _
                            "環境マスタ.Amazon出品者ID_LINKプログラム=""" & parConf(0).sAmazonSellerIDLinkPG.ToString & """,  " & _
                            "環境マスタ.Amazon出品者ID_LINKプログラムパラメータ=""" & parConf(0).sAmazonSellerIDLinkPR.ToString & """,  " & _
                            "環境マスタ.AmazonWebサービスアクセスキーID=""" & parConf(0).sAmazonWebServiceAccesskeyID.ToString & """,  " & _
                            "環境マスタ.AmazonWebサービスアクセスキーID_LINKプログラム=""" & parConf(0).sAmazonWebServiceAccesskeyIDLinkPG.ToString & """,  " & _
                            "環境マスタ.AmazonWebサービスアクセスキーID_LINKプログラムパラメータ=""" & parConf(0).sAmazonWebServiceAccesskeyIDLinkPR.ToString & """,  " & _
                            "環境マスタ.AmazonマーケットプレイスID=""" & parConf(0).sAmazonMarketPlaceID.ToString & """,  " & _
                            "環境マスタ.AmazonマーケットプレイスID_LINKプログラム=""" & parConf(0).sAmazonMarketPlaceIDLinkPG.ToString & """,  " & _
                            "環境マスタ.AmazonマーケットプレイスID_LINKプログラムパラメータ=""" & parConf(0).sAmazonMarketPlaceIDLinkPR.ToString & """,  " & _
                            "環境マスタ.Amazon秘密キー=""" & parConf(0).sAmazonSecretKey.ToString & """,  " & _
                            "環境マスタ.Amazon秘密キー_LINKプログラム=""" & parConf(0).sAmazonSecretKeyLinkPG.ToString & """,  " & _
                            "環境マスタ.Amazon秘密キー_LINKプログラムパラメータ=""" & parConf(0).sAmazonSecretKeyLinkPR.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーID=""" & parConf(0).sShopServID.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーID_LINKプログラム=""" & parConf(0).sShopServIDLinkPG.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーID_LINKプログラムパラメータ=""" & parConf(0).sShopServIDLinkPR.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーPASS=""" & parConf(0).sShopServPass.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーPASS_LINKプログラム=""" & parConf(0).sShopServPassLinkPG.ToString & """,  " & _
                            "環境マスタ.ショップサーブユーザーPASS_LINKプログラムパラメータ=""" & parConf(0).sShopServPassLinkPR.ToString & """,  " & _
                            "環境マスタ.営業時間_開始時=" & parConf(0).sOpenHour & ",  " & _
                            "環境マスタ.営業時間_開始分=" & parConf(0).sOpenMinute & ",  " & _
                            "環境マスタ.営業時間_終了時=" & parConf(0).sCloseHour & ",  " & _
                            "環境マスタ.営業時間_終了分=" & parConf(0).sCloseMinute & ",  " & _
                            "環境マスタ.統計対象時間_開始時=" & parConf(0).sStStartHour & ",  " & _
                            "環境マスタ.統計対象時間_開始分=" & parConf(0).sStStartMinute & ",  " & _
                            "環境マスタ.統計対象時間_終了時=" & parConf(0).sStEndHour & ",  " & _
                            "環境マスタ.統計対象時間_終了分=" & parConf(0).sStEndMinute & ",  " & _
                            "環境マスタ.発注候補抽出期間=" & parConf(0).sOrderListTerm & ",  " & _
                            "環境マスタ.売上サイクル=" & parConf(0).sSalesTerm & ",  " & _
                            "環境マスタ.最低売上数量=" & parConf(0).sMinimumCount & ",  " & _
                            "環境マスタ.ポイント付与円=" & parConf(0).sPointEN & ",  " & _
                            "環境マスタ.ポイント付与率=" & parConf(0).sPointRATE & ",  " & _
                            "環境マスタ.ポイント有効期限=" & parConf(0).sPointEnableMonth & ",  " & _
                            "環境マスタ.ポイントカードフォアファイルパス=""" & parConf(0).sPointForePass.ToString & """,  " & _
                            "環境マスタ.ポイントカードバックファイルパス=""" & parConf(0).sPointBackPass.ToString & """,  " & _
                            "環境マスタ.ポイントカードメッセージ=""" & parConf(0).sPointCardMsg.ToString & """,  " & _
                            "環境マスタ.会員有効期限=" & parConf(0).sMemberEnableMonth & ",  " & _
                            "環境マスタ.会員カードバックファイルパス=""" & parConf(0).sMemberBackPass.ToString & """,  " & _
                            "環境マスタ.会員カードメッセージ=""" & parConf(0).sMemberCardMsg.ToString & """,  " & _
                            "環境マスタ.予約カードメッセージ=""" & parConf(0).sReservCardMsg.ToString & """,  " & _
                            "環境マスタ.最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "環境マスタ.最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 環境マスタ.No=1 "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateConfMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstConfigDBIO.updateConfMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
End Class
