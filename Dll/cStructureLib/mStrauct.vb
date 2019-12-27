'-------------- Table(マスタ)定義 ---------------------------
#Region "マスタ定義"

#Region "環境マスタ"
Public Structure sConfig
    'DBファイルパス
    Public sDBFilePath As String
    'Tempファイルパス
    Public sTempFilePath As String
    'BKファイルパス
    Public sBKFilePath As String
    'No
    Public sNo As Integer
    'レシートプリンタ機器種別
    Public sRecertPrinterProductClass As Integer
    'ドロワ機器種別
    Public sDrawerProductClass As Integer
    'カスタマディスプレー機器種別
    Public sCustomerDisplayProducttClass As Integer
    '磁気カードリーダー機器種別
    Public sCardReaderProducttClass As Integer

    '2016.06.30 K.Oikawa s
    'バーコードスキャナー(star)
    Public sBarcodeScannerClass As Integer
    '2016.06.30 K.Oikawa e

    '自動釣銭機機器種別
    Public sAutoChangerProducttClass As Integer
    'CTI機器種別
    Public sCTIProducttClass As Integer
    'カードプリンター機器種別
    Public sCardPrinterClass As Integer
    'レジチャネルコード
    Public sRegChannelCode As Integer
    'レジ端末No
    Public sRegPCNo As Integer
    'レシートロゴファイルパス
    Public sRLogoPass As String
    '領収書ロゴパス
    Public sBLogoPass As String
    'DB保有期間
    Public sDataPeriod As Integer
    'CTI接続ポート
    Public sCTIPort As String
    '事業所名称
    Public sCorpName As String
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAdderess1 As String
    '住所２
    Public sAdderess2 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'URL
    Public sURL As String
    'メッセージ１
    Public sMessage1 As String
    'メッセージ２
    Public sMessage2 As String
    'メッセージ３
    Public sMessage3 As String
    '端数処理
    Public sFracProc As Integer
    '消費税率
    Public sTax As Integer
    '会計処理区分
    Public sFinClass As Integer
    '税区分
    Public sTaxClass As Integer
    '締め日
    Public sCloseDay As Integer
    '標準仕切率
    Public sRate As Integer
    '連携会計ソフトコード
    Public sFinSoftCode As Integer
    '連携配送伝票出力ソフトコード
    Public sDeliverySoftCode As Integer
    'プログラム1名称
    Public sFunc_Name1 As String
    'プログラム1パス
    Public sFunc_Path1 As String
    'プログラム2名称
    Public sFunc_Name2 As String
    'プログラム2パス
    Public sFunc_Path2 As String
    'プログラム3名称
    Public sFunc_Name3 As String
    'プログラム3パス
    Public sFunc_Path3 As String
    'プログラム4名称
    Public sFunc_Name4 As String
    'プログラム4パス
    Public sFunc_Path4 As String
    'プログラム5名称
    Public sFunc_Name5 As String
    'プログラム5パス
    Public sFunc_Path5 As String
    'プログラム6名称
    Public sFunc_Name6 As String
    'プログラム6パス
    Public sFunc_Path6 As String
    'オプション1項目名
    Public sOptionName1 As String
    'オプション2項目名
    Public sOptionName2 As String
    'オプション3項目名
    Public sOptionName3 As String
    'オプション4項目名
    Public sOptionName4 As String
    'オプション5項目名
    Public sOptionName5 As String

    'LINEメッセージ
    Public sLineMsg As String

    'YAHOOビジネスユーザーID
    Public sYahooBisID As String
    'YAHOOビジネスユーザーIDLINKプログラム
    Public sYahooBisIDLinkPG As String
    'YAHOOビジネスユーザーIDLINKプログラムパラメータ
    Public sYahooBisIDLinkPR As String

    'YAHOOビジネスユーザーPASS
    Public sYahooBisPASS As String
    'YAHOOビジネスユーザーPASSLINKプログラム
    Public sYahooBisPASSLinkPG As String
    'YAHOOビジネスユーザーPASSLINKプログラムパラメータ
    Public sYahooBisPASSLinkPR As String

    'YAHOOユーザーID
    Public sYahooUserID As String
    'YAHOOユーザーIDLINKプログラム
    Public sYahooUserIDLinkPG As String
    'YAHOOユーザーIDLINKプログラムパラメータ
    Public sYahooUserIDLinkPR As String

    'YAHOOユーザーPASS
    Public sYahooUserPASS As String
    'YAHOOユーザーPASS_LINKプログラム
    Public sYahooUserPASSLinkPG As String
    'YAHOOユーザーPASS_LINKプログラムパラメータ
    Public sYahooUserPASSLinkPR As String

    ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
    'YAHOOストアアカウント
    Public sYahooStoreAccount As String
    'YAHOO ApiKey
    Public sYahooApiKey As String
    'YAHOOカスタムURI
    Public sYahooRedirectUri As String
    ' ** 2016.08.26 K.Oikawa →　受注API対応 ***

    '楽天RMSユーザーID
    Public sRakutenRMSUserID As String
    '楽天RMSユーザーID_LINKプログラム
    Public sRakutenRMSUserIDLinkPG As String
    '楽天RMSユーザーID_LINKプログラムパラメータ
    Public sRakutenRMSUserIDLinkPR As String

    '楽天RMSユーザーPASS
    Public sRakutenRMSUserPASS As String
    '楽天RMSユーザーLINKプログラム
    Public sRakutenRMSUserPASSLinkPG As String
    '楽天RMSユーザーLINKプログラムパラメータ
    Public sRakutenRMSUserPASSLinkPR As String

    '楽天ユーザーID
    Public sRakutenUserID As String
    '楽天ユーザーID_LINKプログラム
    Public sRakutenUserIDLinkPG As String
    '楽天ユーザーID_LINKプログラムパラメータ
    Public sRakutenUserIDLinkPR As String

    '楽天ユーザーPASS
    Public sRakutenUserPASS As String
    '楽天ユーザーPASS_LINKプログラム
    Public sRakutenUserPASSLinkPG As String
    '楽天ユーザーPASS_LINKプログラムパラメータ
    Public sRakutenUserPASSLinkPR As String

    '楽天CSVダウンロードユーザーID
    Public sRakutenCSVDownloadID As String
    '楽天CSVダウンロードユーザーID_LINKプログラム
    Public sRakutenCSVDownloadIDLinkPG As String
    '楽天CSVダウンロードユーザーID_LINKプログラムパラメータ
    Public sRakutenCSVDownloadIDLinkPR As String

    '楽天CSVダウンロードユーザーPASS
    Public sRakutenCSVDownloadPASS As String
    '楽天CSVダウンロードユーザーLINKプログラム
    Public sRakutenCSVDownloadPASSLinkPG As String
    '楽天CSVダウンロードユーザーLINKプログラムパラメータ
    Public sRakutenCSVDownloadPASSLinkPR As String

    ' ** 2016.08.09 K.Minagawa →　受注API対応 ***
    '楽天API用serviceSecret
    Public sRakutenAPIUrl As String
    '楽天API用licenseKey
    Public sRakutenAPIServiceSecret As String
    '楽天API用URL
    Public sRakutenAPILicenseKey As String
    ' ** 2016.08.09 K.Minagawa →　受注API対応 ***

    '*** START MINAGAWA 2013/6/20 ***
    'Amazon出品者ID
    Public sAmazonSellerID As String
    'Amazon出品者ID
    Public sAmazonSellerIDLinkPG As String
    'Amazon出品者ID
    Public sAmazonSellerIDLinkPR As String

    'AmazonWebサービスアクセスキーId
    Public sAmazonWebServiceAccesskeyID As String
    'AmazonWebサービスアクセスキーId
    Public sAmazonWebServiceAccesskeyIDLinkPG As String
    'AmazonWebサービスアクセスキーId
    Public sAmazonWebServiceAccesskeyIDLinkPR As String

    'AmazonマーケットプレイスId
    Public sAmazonMarketPlaceID As String
    'AmazonマーケットプレイスId
    Public sAmazonMarketPlaceIDLinkPG As String
    'AmazonマーケットプレイスId
    Public sAmazonMarketPlaceIDLinkPR As String

    'Amazon秘密キー
    Public sAmazonSecretKey As String
    'Amazon秘密キー
    Public sAmazonSecretKeyLinkPG As String
    'Amazon秘密キー
    Public sAmazonSecretKeyLinkPR As String

    'ショップサーブユーザーID
    Public sShopServID As String
    'ショップサーブユーザーID_LINKプログラム
    Public sShopServIDLinkPG As String
    'ショップサーブユーザーID_LINKプログラムパラメータ
    Public sShopServIDLinkPR As String

    'ショップサーブユーザーPASS
    Public sShopServPass As String
    'ショップサーブユーザーPASS_LINKプログラム
    Public sShopServPassLinkPG As String
    'ショップサーブユーザーPASS_LINKプログラムパラメータ
    Public sShopServPassLinkPR As String
    '*** END   MINAGAWA 2013/6/20 ***

    '営業時間-開始時
    Public sOpenHour As Integer
    '営業時間-開始分
    Public sOpenMinute As Integer
    '営業時間-終了時
    Public sCloseHour As Integer
    '営業時間-終了分
    Public sCloseMinute As Integer

    '*** START MINAGAWA 2013/6/20 ***
    '統計対象時間_開始時
    Public sStStartHour As Integer
    '統計対象時間_開始分
    Public sStStartMinute As Integer
    '統計対象時間_終了時
    Public sStEndHour As Integer
    '統計対象時間_終了分
    Public sStEndMinute As Integer
    '発注候補抽出期間
    Public sOrderListTerm As Integer
    '売上サイクル
    Public sSalesTerm As Integer
    '最低売上数量
    Public sMinimumCount As Integer
    '*** END   MINAGAWA 2013/6/20 ***

    'ポイント付与率（円）  ポイント付与は「ポイント付与率（円）」で「ポイント付与率（ポイント）」付与
    Public sPointEN As Integer
    'ポイント付与率（ポイント）
    Public sPointRATE As Integer
    'ポイント有効期限(月)
    Public sPointEnableMonth As Integer
    'ポイントカードフォアファイルパス
    Public sPointForePass As String
    'ポイントカードバックファイルパス
    Public sPointBackPass As String
    'ポイントカードメッセージ
    Public sPointCardMsg As String

    '会員カード更新期間(月)
    Public sMemberEnableMonth As Integer
    '会員カードバックファイルパス
    Public sMemberBackPass As String
    '会員カードメッセージ
    Public sMemberCardMsg As String

    '予約カードメッセージ
    Public sReservCardMsg As String

    '登録日
    Public sCraeteDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "OPOSマスタ"
Public Structure sOPOS
    'OPOS_ID
    Public sOPOS_ID As Integer
    'メーカー名称
    Public sMakerName As String
    'モデル名称
    Public sModelName As String
    'デバイス名称
    Public sDeviceName As String
    'OPOSバージョン
    Public sVersion As String
    '機器種別
    Public sProductClass As Integer
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "アプリケーションマスタ"
Public Structure sApplication
    'アプリケーションID
    Public sApplicationID As String
    'グループID
    Public sGroupID As String
    'グループ名称
    Public sGroupName As String
    'メニュー名称
    Public sMenuName As String
    'コントロール名称
    Public sControlName As String
    '実行モジュール名称
    Public sExeName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "商品マスタ"
Public Structure sProduct
    '商品コード
    Public sProductCode As String
    'SEQコード
    Public sSEQCode As Long
    'JANコード
    Public sJANCode As String
    '商品種別
    Public sProductClass As Integer
    '商品名称
    Public sProductName As String
    '商品略称
    Public sProductShortName As String
    'メーカー名称
    Public sMakerName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '適用
    Public sMemo As String
    '定価
    Public sListPrice As Long
    '適正在庫数
    Public sMinStock As Long
    'PLUコード
    Public sPLUCode As String
    '販売停止フラグ
    Public sStopSaleFlg As Boolean
    '仕入停止フラグ
    Public sStopSupplieFlg As Boolean
    'Yahoo掲載フラグ
    Public sYahooFlg As Boolean
    '楽天掲載フラグ
    Public sRakutenFlg As Boolean
    'Amazon掲載フラグ
    Public sAmazonFlg As Boolean
    '自社サイト掲載フラグ
    Public seShopFlg As Boolean
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String

    '2019.8.7 A.Komita From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.8.7 A.Komita To

End Structure
#End Region

#Region "構成マスタ"
Public Structure sBom
    '構成コード
    Public sStructureCode As Integer
    'ノード番号
    Public sNodeNo As Integer
    '階層番号
    Public sHiearchyNo As Integer
    '親ノード番号
    Public sParentNodeNo As Integer
    '商品コード
    Public sProductCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ネット掲載マスタ"
Public Structure sNetInfo
    '商品コード
    Public sProductCode As String
    'ディレクトリID
    Public sDirectryID As String
    '掲載パス
    Public sPath As String
    'METAタグ
    Public sMETATag As String
    'META説明
    Public sMETADescription As String
    '商品キャッチコピー
    Public sCatchCopy As String
    '商品情報
    Public sInformation As String
    '商品説明文
    Public sDescription As String
    '素材
    Public sMaterial As String
    '寸法－縦
    Public sSizeHeight As Single
    '寸法－横
    Public sSizeWide As Single
    '寸法－深さ
    Public sSizeDepth As Single
    '寸法－首回り
    Public sSizeNeck As Single
    '寸法－バスト
    Public sSizeBust As Single
    '寸法－ウエスト
    Public sSizeWaist As Single
    '寸法－着丈
    Public sSizeLength As Single
    'おすすめ商品
    Public sRecommendation As String
    '写真－１
    Public sPicture1 As String
    '写真－２
    Public sPicture2 As String
    '写真－３
    Public sPicture3 As String
    '写真－４
    Public sPicture4 As String
    '写真－５
    Public sPicture5 As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日付
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "部門マスタ"
Public Structure sBumon
    '部門コード
    Public sBumonCode As String
    '部門名称
    Public sBumonName As String
    '部門略称
    Public sBumonShortName As String
    '部門種別
    Public sBumonClass As Integer
    '予約フラグ
    Public sReservFlg As Boolean
    '予約単位
    Public sReservPeace As String
    '税区分コード
    Public sTaxClassCode As Integer
    '会員割引率
    'Public sMemberRate As Integer
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "仕入価格マスタ"
Public Structure sCostPrice
    '商品コード
    Public sProductCode As String
    '仕入先コード
    Public sSupplierCode As Integer
    '仕入単価
    Public sCostPrice As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "販売価格マスタ"
Public Structure sSalePrice
    '商品コード
    Public sProductCode As String
    'チャネルコード
    Public sChannelCode As Integer
    '販売単価
    Public sSalePrice As Long
    '適用開始日
    Public sStartDate As String
    '適用終了日
    Public sEndDate As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ネット掲載状況マスタ"
Public Structure sNetSales
    '商品コード
    Public sProductCode As String
    'チャネルコード
    Public sChannelCode As Integer
    '掲載開始日
    Public sStartDate As String
    '掲載終了日
    Public SendDate As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "仕入先マスタ"
Public Structure sSupplier
    '仕入先コード
    Public sSupplierCode As Integer
    '仕入先名称
    Public sSupplierName As String
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAddress1 As String
    '住所２
    Public sAddress2 As String
    '住所２
    Public sAddress3 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'URL
    Public sURL As String
    '担当者名称
    Public sPersonName As String
    '閉め日
    Public sCloseDate As Integer
    '標準仕切率
    Public sStanderedRate As Single
    '標準ロット数
    Public sStanderedLot As Integer
    '支払方法コード1
    Public sPaymentCode1 As Integer
    '支払方法コード2
    Public sPaymentCode2 As Integer
    '支払方法コード3
    Public sPaymentCode3 As Integer
    '取引条件
    Public sTrnRule As String
    '備考
    Public sMemo As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "在庫マスタ"
Public Structure sStock
    '商品コード
    Public sProductCode As String
    '在庫数
    Public sStockCount As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "支払方法マスタ"
Public Structure sPayment
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '掛け取引フラグ
    Public sCreditFlg As Boolean
    '受注フラグ
    Public sRequestFlg As Boolean
    '出荷フラグ
    Public sShipmentFlg As Boolean
    '発注フラグ
    Public sOrderFlg As Boolean
    '入荷フラグ
    Public sArriveFlg As Boolean
    '返品フラグ
    Public sReturnFlg As Boolean
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "チャネル別支払方法マスタ"
Public Structure sChannelPayment
    'チャネル支払コード
    Public sChannelPaymentCode As Integer
    'チャネルコード
    Public sChannelCode As Integer
    '支払方法コード
    Public sPaymentCode As Integer
    'チャネル別支払方法名称
    Public sChannelPaymentName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "チャネルマスタ"
Public Structure sChannel
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    'チャネル種別
    Public sChannelClass As Integer
    'URL
    Public sURL As String
    'レシート印刷フラグ
    Public sReceiptPrint As Boolean
    '売上計上フラグ
    Public sSaleRegist As Boolean
    '注文データファイル有無
    Public sRequestFileFlg As Boolean
    '注文明細データファイル有無
    Public sRequestSubFileFlg As Boolean
    'CMSタイプ
    Public sCMSType As Integer
    'OR受注コードフィールド名
    Public sORRequestCodeFieldName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ルームマスタ"
Public Structure sRoom
    'ルームコード
    Public sRoomCode As Integer
    'チャネルコード
    Public sChannelCode As Integer
    'ルーム名称
    Public sRoomName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ルーム利用部門マスタ"
Public Structure sRoomBumon
    'ルームコード
    Public sRoomCode As Integer
    '部門コード
    Public sBumonCode As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "カテゴリ1マスタ"
Public Structure sCategory1
    'カテゴリID_1
    Public sCategory1ID As String
    'カテゴリ名称_1
    Public sCategory1Name As String
End Structure
#End Region

#Region "カテゴリ2マスタ"
Public Structure sCategory2
    'カテゴリID_1
    Public sCategory1ID As String
    'カテゴリID_2
    Public sCategory2ID As String
    'カテゴリ名称_2
    Public sCategory2Name As String
End Structure
#End Region

#Region "スタッフマスタ"
Public Structure sStaff
    'スタッフコード
    Public sStaffCode As String
    '役割コード
    Public sRoleCode As Integer
    'スタッフ種別
    Public sStaffClass As String
    '部門コード
    Public sBumonCode As String
    '社販レート
    Public sRate As Long
    'スタッフ名称
    Public sStaffName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日付
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "スタッフ権限マスタ"
Public Structure sStaffAuthority
    'スタッフコード
    Public sStaffCode As String
    'アプリケーションID
    Public sApplicationID As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "役割マスタ"
Public Structure sRole
    '役割コード
    Public sRoleCode As Integer
    '役割名称
    Public sRoleName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ポイント会員マスタ"
Public Structure sPointMember
    'ポイント会員コード
    Public sPointMemberCode As String
    'ポイント会員名称
    Public sPointMemberName As String
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAddress1 As String
    '住所２
    Public sAddress2 As String
    '住所３
    Public sAddress3 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'メールアドレス
    Public sMailAddress As String
    '性別
    Public sSex As String
    '生年月日
    Public sBirthDay As String
    '年齢
    Public sAge As Integer
    '入会日
    Public sEntryDate As String
    '退会日
    Public sResignDate As String
    '契約開始日
    Public sStartRegistDate As String
    '契約満了日
    Public sEndRegistDate As String
    '更新回数
    Public sUpdateCount As Integer
    '備考
    Public sMemo As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "会員マスタ"
Public Structure sMember
    '会員コード
    Public sMemberCode As String
    '会員名称
    Public sMemberName As String
    'サービスコード
    Public sServiceCode As Integer
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAddress1 As String
    '住所２
    Public sAddress2 As String
    '住所３
    Public sAddress3 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'メールアドレス
    Public sMailAddress As String
    '性別
    Public sSex As String
    '生年月日
    Public sBirthday As String
    '年齢
    Public sAge As Integer
    '入会日
    Public sEntryDate As String
    '退会日
    Public sResignDate As String
    '属性１（品種）
    Public sAttr1 As String
    '属性２（種別）
    Public sAttr2 As String
    '属性３（狂犬病注射日））
    Public sAttr3 As String
    '属性４（ワクチン注射日）
    Public sAttr4 As String
    '属性５（ワクチン名称）
    Public sAttr5 As String
    '契約開始日
    Public sStartRegistDate As String
    '契約満了日
    Public sEndRegistDate As String
    '更新回数
    Public sUpdateCount As Integer
    '補助会員名称
    Public sSubMemberName As String
    '補助会員性別
    Public sSubMemberSex As String
    '補助会員生年月日
    Public sSubMemberBirthDay As String
    '補助会員年齢
    Public sSubMemberAge As Integer
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

'#Region "会員割引率マスタ"
'Public Structure sMemberRate
'    'メンバー種別
'    Public sMemberClass As String
'    '部門コード
'    Public sBumonCode As String
'    '割引率種別
'    Public sRateClass As String
'    '割引率
'    Public sRate As Integer
'    '登録日
'    Public sCreateDate As String
'    '登録時間
'    Public sCreateTime As String
'    '最終更新日
'    Public sUpdateDate As String
'    '最終更新時間
'    Public sUpdateTime As String
'End Structure
'#End Region

#Region "サービスマスタ"
Public Structure sService
    'サービスコード
    Public sServiceCode As Integer
    'サービス名称
    Public sServiceName As String
    'サービス区分
    Public sServiceClass As Integer
    'サービス対象－顧客
    Public sTarget_C As Boolean
    'サービス対象－社員
    Public sTarget_E As Boolean
    'サービス対象－アルバイト
    Public sTarget_A As Boolean
    'サービス対象－パート
    Public sTarget_P As Boolean
    'サービス対象－その他
    Public sTarget_O As Boolean
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "サービス詳細マスタ"
Public Structure sServiceRate
    'サービスコード
    Public sServiceCode As Integer
    '部門コード
    Public sBumonCode As String
    '割引率
    Public sRate As Integer
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "勘定科目マスタ"
Public Structure sAccount
    '勘定科目コード
    Public sAccountCode As Integer
    '勘定科目名称
    Public sAccountName As String
    '連動マスタ名称
    Public sLinkMasterName As String
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "補助勘定科目マスタ"
Public Structure sSubAccount
    '勘定科目コード
    Public sAccountCode As Integer
    '勘定科目コード
    Public sSubAccountCode As Integer
    '勘定科目名称
    Public sSubAccountName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "郵便番号マスタ"
Public Structure sPostCode
    '郵便番号（5桁）
    Public sPostCode5 As String
    '郵便番号（3桁）
    Public sPostCode3 As String
    '郵便番号（8桁）
    Public sPostCode8 As String
    '住所カナ－都道府県
    Public sAddr1Kana As String
    '住所カナ－市区町村
    Public sAddr2Kana As String
    '住所カナ－町域
    Public sAddr3Kana As String
    '住所－都道府県
    Public sAddr1 As String
    '住所－市区町村
    Public sAddr2 As String
    '住所－町域
    Public sAddr3 As String
End Structure
#End Region

#Region "配送種別マスタ"
Public Structure sDeliveryClass
    '配送種別コード
    Public sDeliveryClassCode As Integer
    '項目名称
    Public sItemName As String
    '種別コード
    Public sClassCode As String
    '種別名称
    Public sClassName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "税区分マスタ"
Public Structure sTaxClass
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "連携ソフトマスタ"
Public Structure sSoft
    'ソフトコード
    Public sSoftCode As Integer
    'ソフト名称
    Public sSoftName As String
    'バージョン
    Public sVersion As String
    'ソフト種別
    Public sSoftClass As Integer
    '業者コード
    Public sCorpCode As Integer
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ディレクトリーIDマスタ"
Public Structure sDirectryMst
    'ディレクトリーID
    Public sDirectryID As String
    'パス1
    Public sPath1 As String
    'パス2
    Public sPath2 As String
    'パス3
    Public sPath3 As String
    'パス4
    Public sPath4 As String
    'パス5
    Public sPath5 As String
End Structure
#End Region

#Region "ダウンロードカラムマスタ"
Public Structure sDownloadColumn
    'チャネルコード
    Public sChannelCode As Integer
    'データ種別
    Public sDataClass As Integer
    'DBカラムNo
    Public sDBColumnNo As Integer
    'DBカラム名称
    Public sDBColumnName As String
    'DBカラムタイプ
    Public sDBColumnType As Integer
    'DLカラムNo
    Public sDLColumnNo As Integer
    'DLカラム名称
    Public sDLColumnName As String
    '適用
    Public sDescription As String
    'デリミタ
    Public sDerimita As String
    '区画No
    Public sSplitNo As String
End Structure
#End Region

#Region "CSVレイアウトマスタ"
Public Structure sCsvLayout
    'ソフトコード
    Public sSoftCode As Integer
    'No
    Public sDataClass As Integer
    '項目名称
    Public sColumnNo As String
    '長さ
    Public sColumnName As Integer
    '型
    Public sColumnType As String
End Structure
#End Region

'---------- 未使用? ------------------
#Region "配送業者マスタ"
Public Structure sDelivery
    '配送業者コード
    Public sDeliveryCode As Integer
    '配送業者名称
    Public sDeliveryName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "郵便番号マスタ(県名取得用）"
Public Structure sCity
    '県番号
    Public sCityNo As String
    '県名称
    Public sCityName As String
End Structure
#End Region

#Region "支払方法名称変換マスタ"
Public Structure sCnvPayment
    'チャネルコード
    Public sChannelCode As Integer
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日付
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

'-------------------------------------
#End Region

'-------------- Table(データ)定義 ---------------------------
#Region "データ定義"

#Region "発注情報データ"
Public Structure sOrderData
    '発注コード
    Public sOrderCode As String
    '発注日
    Public sOrderDate As String
    '発注モード
    Public sOrderMode As Integer
    '発注税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '発注値引き
    Public sDiscount As Long
    '発注ポイント値引き
    Public sPointDisCount As Long
    '発注税抜金額
    Public sNoTaxTotalPrice As Long
    '発注消費税額
    Public sTaxTotal As Long

    '2019.9.1 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.9.1 A.Komita 追加 To

    '2019,9,20 A.Komita 追加 From
    '発注軽減消費税額
    Public sReducedTaxRateTotal As Long
    '2019,9,20 A.Komita 追加 To

    '発注税込金額
    Public sTotalPrice As Long
    '仕入先コード
    Public sSupplierCode As Integer
    '支払方法コード
    Public sPaymentCode As Integer
    '希望納品日
    Public sRequestDate As String
    '希望納品場所
    Public sRequestPlace As String
    '発注担当者コード
    Public sStaffCode As String
    '備考
    Public sMemo As String
    '伝票印刷モード
    Public sPrintMode As Integer
    '完納日
    Public sAllArrivedDate As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String

End Structure
#End Region

#Region "発注情報明細データ"
Public Structure sOrderSubData
    '発注コード
    Public sOrderCode As String
    '発注明細コード
    Public sOrderSubCode As Integer
    'JANコード
    Public sJANCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '発注商品単価
    Public sUnitPrice As Long
    '発注数量
    Public sCount As Long
    '発注税抜金額
    Public sNoTaxPrice As Long

    '2019.9.1 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.9.1 A.Komita 追加 To

    '発注消費税額
    Public sTaxPrice As Long
    '発注税込金額
    Public sPrice As Long
    '発注中止フラグ
    Public sOrderCancelFlg As Boolean
    '発注中止事由
    Public sCancelReason As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String

End Structure
#End Region

#Region "発注状態データ"
Public Structure sOrderStatus
    '商品コード
    Public sProductCode As String
    '選択状態
    Public sCheck As Boolean
    '数量
    Public sCount As Integer
End Structure
#End Region

#Region "発注候補選択状態データ"
Public Structure sCandidateStatus
    '商品コード
    Public sProductCode As String
    '選択状態
    Public sCheck As Boolean
    '数量
    Public sCount As Integer
End Structure
#End Region

#Region "受注情報データ"
Public Structure sRequestData
    '受注コード
    Public sRequestCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'OR受注コード
    Public sORRequestCode As String
    '受注サイト
    Public sRequestSite As String
    '受注媒体
    Public sRequestMedia As String
    'モバイルフラグ
    Public sMobileFlg As String
    'アフェリエイトフラグ
    Public sAffiliateFlg As String
    '受注日
    Public sRequestDate As String
    '受注時間
    Public sRequestTime As String
    '出荷先－会社名
    Public sShipCorpName As String
    '出荷先－支店名
    Public sShipDivName As String
    '出荷先－姓カナ
    Public sShipKanaShip1stName As String
    '出荷先－名カナ
    Public sShipKanaShip2ndName As String
    '出荷先－住所１カナ
    Public sShipKanaAdder1 As String
    '出荷先－住所２カナ
    Public sShipKanaAdder2 As String
    '出荷先－住所市区町村カナ
    Public sShipKanaCity As String
    '出荷先－都道府県カナ
    Public sShipKanaState As String
    '出荷先－姓
    Public sShip1stName As String
    '出荷先－名
    Public sShip2ndName As String
    '出荷先－住所１
    Public sShipAdder1 As String
    '出荷先－住所２
    Public sShipAdder2 As String
    '出荷先－住所市区町村
    Public sShipCity As String
    '出荷先－都道府県
    Public sShipState As String
    '出荷先－国名
    Public sShipCountry As String
    '出荷先－郵便番号1
    Public sShipPostCode1 As String
    '出荷先－郵便番号2
    Public sShipPostCode2 As String
    '出荷先－電話番号
    Public sShipTel As String
    '請求先－会社名
    Public sBillCorpName As String
    '請求先－支店名
    Public sBillDivName As String
    '請求先－姓カナ
    Public sBillKanaBill1stName As String
    '請求先－名カナ
    Public sBillKanaBill2ndName As String
    '請求先－住所１カナ
    Public sBillKanaAdder1 As String
    '請求先－住所２カナ
    Public sBillKanaAdder2 As String
    '請求先－住所市区町村カナ
    Public sBillKanaCity As String
    '請求先－都道府県カナ
    Public sBillKanaState As String
    '請求先－姓
    Public sBill1stName As String
    '請求先－名
    Public sBill2ndName As String
    '請求先－住所１
    Public sBillAdder1 As String
    '請求先－住所２
    Public sBillAdder2 As String
    '請求先－住所市区町村
    Public sBillCity As String
    '請求先－都道府県
    Public sBillState As String
    '請求先－国名
    Public sBillCountry As String
    '請求先－郵便番号1
    Public sBillPostCode1 As String
    '請求先－郵便番号2
    Public sBillPostCode2 As String
    '請求先－電話番号
    Public sBillTel As String
    'メールアドレス
    Public sMailAdderss As String
    'コメント
    Public sComment As String
    'ステータス
    Public sStatus As String
    'エントリーポイント
    Public sEntryPoint As String
    'リンク先
    Public sLink As String
    'カード支払方法
    Public sCardPayment As String
    '配達希望日
    Public sShipRequestDate As String
    '配達希望時間
    Public sShipRequestTime As String
    '配達希望メモ
    Public sShipMemo As String
    '配送業者
    Public sShipCorp As String
    'チャネル支払コード
    Public sChannelPaymentCode As Integer
    'ギフト梱包希望
    Public sGiftRequest As String
    '取得ポイント数
    Public sGetPoint As Long
    '受注商品税抜金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    '受注税抜金額
    Public sNoTaxTotalPrice As Long
    '受注消費税額
    Public sTaxTotal As Long
    '受注税込金額
    Public sTotalPrice As Long
    'ギフト梱包材料
    Public sGiftWrapKind As String
    'ギフト梱包料金
    Public sGiftWrapKindPrice As Long
    'のし希望
    Public sNoshiType As String
    'のし記載内容
    Public sNoshiName As String
    '注文者性別
    Public sBillSex As String
    '注文者誕生日
    Public sBillBirthDay As String
    '楽天バンク決済手数料
    Public sRakutenCharge As Long
    '受注伝票出力フラグ
    Public sPrintFlg As Boolean
    '受注担当者コード
    Public sStaffCode As String
    '会員コード
    Public sMemberCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "受注情報明細データ"
Public Structure sRequestSubData
    '受注コード
    Public sRequestCode As String
    'OR受注コード
    Public sORRequestCode As String
    '受注明細コード
    Public sRequestSubCode As Integer
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション名称
    Public sOptionName As String
    'オプション値
    Public sOptionValue As String
    '定価
    Public sListPrice As Long
    '仕入単価ArriveDataFull
    Public sCostPrice As Long
    '軽減税率
    Public sReducedTaxRate As String
    '受注商品単価
    Public sUnitPrice As Long
    '受注数量
    Public sCount As Integer
    '受注税抜金額
    Public sNoTaxPrice As Long
    '受注消費税額
    Public sTaxPrice As Long
    '受注税込金額
    Public sPrice As Long
    'チャネル商品コード
    Public sChannelProductCode As String
    'チャネル商品名称
    Public sChannelProductName As String
    'チャネルオプション
    Public sChannelOptionNameAndValue As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "受注状態データ"
Public Structure sRequestStatus
    '商品コード
    Public sProductCode As String
    '選択状態
    Public sCheck As Boolean
    '数量
    Public sCount As Integer
End Structure
#End Region

#Region "出荷情報データ"
Public Structure sShipmentData
    'チャネルコード
    Public sChannelCode As Integer
    '出荷コード
    Public sShipCode As String
    '受注コード
    Public sRequestCode As String
    '出荷日
    Public sShipDate As String
    '荷物受渡番号
    Public sDeliveryNumber As String
    '出荷先電話番号
    Public sTel As String
    '出荷先郵便番号
    Public sPostalCode As String
    '出荷先住所1
    Public sAddress1 As String
    '出荷先住所2
    Public sAddress2 As String
    '出荷先住所3
    Public sAddress3 As String
    '出荷先姓
    Public sFirstName As String
    '出荷先名
    Public sLastName As String
    '配達日
    Public sShipRequestDate As String
    '配達指定時間帯
    Public sShipRequestTimeClass As String
    '配達指定時間
    Public sShipRequestTime As String
    '配送業者コード
    Public sShipCorpCode As Integer
    '営業店コード
    Public sShipOfficeCode As String
    '代引金額
    Public sDaibikiPrice As Long
    '出荷税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    '出荷税抜金額
    Public sNoTaxTotalPrice As Long
    '軽減税率
    Public sReducedTaxRate As String
    '出荷消費税額
    Public sTaxTotal As Long
    '出荷軽減消費税額
    Public sReducedTaxRateTotal As Long
    '出荷税込金額
    Public sTotalPrice As Long
    '荷姿コード
    Public sLookFeelCode As Integer
    '支払方法コード
    Public sShipPaymentCode As Integer
    '決済種別
    Public sShipPaymentClass As Integer
    '便種スピード
    Public sDeliveryClassSpeed As String
    '便種商品
    Public sDeliveryClassProduct As String
    '指定シール1
    Public sSeal1 As String
    '指定シール2
    Public sSeal2 As String
    '指定シール3
    Public sSeal3 As String
    '元着区分
    Public sMotoCyakuClass As Integer
    '出荷完了フラグ
    Public sFinishFlg As Integer
    '再出荷事由
    Public sReShopMemo As String
    '出荷メモ
    Public sShipMemo As String
    '配送伝票CSV出力フラグ
    Public sDeleveryCSVOutoutFlg As Long
    '出荷担当者コード
    Public sShipStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "出荷情報明細データ"
Public Structure sShipmentSubData
    '受注コード
    Public sRequestCode As String
    '出荷コード
    Public sShipNumber As String
    '受注明細コード
    Public sRequestSubCode As Integer
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション名称
    Public sOptionName As String
    'オプション値
    Public sOptionValue As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '出荷商品単価
    Public sUnitPrice As Long
    '出荷数量
    Public sCount As Integer
    '出荷税抜金額
    Public sNoTaxPrice As Long
    '軽減税率
    Public sReducedTaxRate As String
    '出荷消費税額
    Public sTaxPrice As Long
    '出荷軽減消費税額
    Public sReducedTaxRatePrice As Long
    '出荷税込金額
    Public sPrice As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "出荷伝表出力データ"
Public Structure sShipStatus
    '出荷コード
    Public sShipCode As String
    '出荷状態
    Public sShipCheck As Boolean
End Structure
#End Region

#Region "入庫情報データ"
Public Structure sArrivalData
    '発注コード
    Public sOrderCode As String
    '入庫番号
    Public sArrivalNo As Long
    '入庫日
    Public sArrivalDate As String
    '仕入先コード
    Public sSupplierCode As Integer
    '支払方法コード
    Public sPaymentCode As Integer
    '入庫税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    '入庫税抜金額
    Public sNoTaxTotalPrice As Long
    '入庫消費税額
    Public sTaxTotal As Long

    '2019,10,3 A.Komita 追加 From
    '入庫軽減税額
    Public sReducedTaxRate As Long
    '2019,10,3 A.Komita 追加 To

    '入庫税込金額
    Public sTotalPrice As Long
    '完納フラグ
    Public sFinishFlg As Boolean
    '入庫担当者コード
    Public sStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "入庫情報明細データ"
Public Structure sArrivalSubData
    '発注コード
    Public sOrderCode As String
    '発注明細コード
    Public sOrderDetailNo As Integer
    '入庫番号
    Public sArrivalNo As Integer
    'JANコード
    Public sJANCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '入庫商品単価
    Public sUnitPrice As Long
    '入庫数量
    Public sCount As Integer
    '入庫税抜金額
    Public sNoTaxPrice As Long
    '入庫消費税額
    Public sTaxPrice As Long

    '2019,10,3 A.Komita 追加 From
    '入庫軽減税額
    Public sReducedTaxRate As Long
    '2019,10,3 A.Komita 追加 To

    '入庫税込金額
    Public sPrice As Long
    '納入残数
    Public sArrivalStiffness As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public ScreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "精算データ"
Public Structure sAdjust
    '精算コード
    Public sAdjustCode As Long
    '精算区分
    Public sAdjustClass As String
    '精算日
    Public sAdjustDate As String
    '精算時間
    Public sAdjustTime As String
    '金額
    Public sTotalPrice As Long
    '勘定科目コード
    Public sAccountCode As Integer
    '勘定科目名称
    Public sAccountName As String
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
    '補助勘定科目コード
    Public sSubAccountCode As Integer
    '補助勘定科目名称
    Public sSubAccountName As String
    'レジ入金金額
    Public sDTotalPrice As Long
    '既レジ入金金額
    Public sAlreadyDTotalPrice As Long
    '10000円
    Public sD10000Yen As Integer
    '5000円
    Public sD5000Yen As Integer
    '1000円
    Public sD1000Yen As Integer
    '500円
    Public sD500Yen As Integer
    '100円
    Public sD100Yen As Integer
    '50円
    Public sD50Yen As Integer
    '10円
    Public sD10Yen As Integer
    '50円
    Public sD5Yen As Integer
    '1円
    Public sD1Yen As Integer
    '金庫入金金額
    Public sKTotalPrice As Long
    '10000円
    Public sK10000Yen As Integer
    '5000円
    Public sK5000Yen As Integer
    '1000円
    Public sK1000Yen As Integer
    '500円
    Public sK500Yen As Integer
    '100円
    Public sK100Yen As Integer
    '50円
    Public sK50Yen As Integer
    '10円
    Public sK10Yen As Integer
    '50円
    Public sK5Yen As Integer
    '1円
    Public sK1Yen As Integer
    '月次締日
    Public sCloseDate As String
    '精算担当者コード
    Public sAdjustStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "集計データ"
Public Structure sCalc
    '集計コード
    Public sCalcCode As Long
    '集計区分
    Public sCalcClass As String
    '集計日
    Public sCalcDate As String
    '集計時間
    Public sCalcTime As String
    '現金売上
    Public sCashSales As Long
    '現金売上数
    Public sCashSalesCnt As Integer
    '現金値引き額
    Public sCashDiscount As Long
    'クレジット売上
    Public sCreditSales As Long
    'クレジット売上数
    Public sCreditSalesCnt As Integer
    'クレジット値引き額
    Public sCreditDiscount As Long
    '入金額
    Public sInCash As Long
    '入金回数
    Public sInCashCnt As Integer
    '出金額
    Public sOutCash As Long
    '出金回数
    Public sOutCashCnt As Integer
    '回収金額
    Public sRetCash As Long
    '残高
    Public sBalance As Long
    '顧客数_0_1
    Public sCustCnt_0_1 As Long
    '顧客数_1_2
    Public sCustCnt_1_2 As Long
    '顧客数_2_3
    Public sCustCnt_2_3 As Long
    '顧客数_3_4
    Public sCustCnt_3_4 As Long
    '顧客数_4_5
    Public sCustCnt_4_5 As Long
    '顧客数_5_6
    Public sCustCnt_5_6 As Long
    '顧客数_6_7
    Public sCustCnt_6_7 As Long
    '顧客数_7_8
    Public sCustCnt_7_8 As Long
    '顧客数_8_9
    Public sCustCnt_8_9 As Long
    '顧客数_9_10
    Public sCustCnt_9_10 As Long
    '顧客数_10_11
    Public sCustCnt_10_11 As Long
    '顧客数_11_12
    Public sCustCnt_11_12 As Long
    '顧客数_12_13
    Public sCustCnt_12_13 As Long
    '顧客数_13_14
    Public sCustCnt_13_14 As Long
    '顧客数_14_15
    Public sCustCnt_14_15 As Long
    '顧客数_15_16
    Public sCustCnt_15_16 As Long
    '顧客数_16_17
    Public sCustCnt_16_17 As Long
    '顧客数_17_18
    Public sCustCnt_17_18 As Long
    '顧客数_18_19
    Public sCustCnt_18_19 As Long
    '顧客数_19_20
    Public sCustCnt_19_20 As Long
    '顧客数_20_21
    Public sCustCnt_20_21 As Long
    '顧客数_21_22
    Public sCustCnt_21_22 As Long
    '顧客数_22_23
    Public sCustCnt_22_23 As Long
    '顧客数_23_24
    Public sCustCnt_23_24 As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日付
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "日次取引データ"
Public Structure sTrn
    '取引コード
    Public sTrnCode As Long
    '取引区分
    Public sTrnClass As String
    'チャネルコード
    Public sChannel As Integer
    '受注日
    Public sRequestDate As String
    '受注時間
    Public sRequestTime As String
    '支払方法コード
    Public sPaymentCode As Integer
    '取引税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDiscount As Long
    'チケット値引き
    Public sTicketDiscount As Long
    '差額
    Public sDifference As Long
    '取引税抜金額
    Public sNoTaxTotalPrice As Long
    '取引消費税額
    Public sTaxTotal As Long
    '取引税込金額
    Public sTotalPrice As Long

    '2016.07.05 K.Oikawa s
    '課題表No131 取得ポイント追加
    '取得ポイント
    Public sGetPoint As Long
    '2016.07.05 K.Oikawa e

    '出荷コード
    Public sShipCode As String
    '会員コード
    Public sMemberCode As String
    'ポイント会員コード
    Public sPointMemberCode As String
    '性別
    Public sSex As String
    '年代
    Public sGeneration As Integer
    '天気
    Public sWeather As String
    '日次締め日
    Public sDayCloseDate As String
    '月次締め日
    Public sMonthCloseDate As String
    '備考
    Public sMemo As String
    '取引担当者コード
    Public sStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "日次取引明細データ"
Public Structure sSubTrn
    '取引コード
    Public sTrnCode As Long
    '取引明細コード
    Public sSubTrnCode As Long
    '売上状態
    Public sStatus As String
    '売上明細区分
    Public sSubTrnClass As Integer
    '部門コード
    Public sBumonCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'JANコード
    Public sJANCode As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '取引商品単価
    Public sUnitPrice As Long
    '取引数量
    Public sCount As Integer
    '取引税抜商品金額
    Public sNoTaxProductPrice As Long
    '送料
    Public sShipCharge As Long
    '手数料
    Public sPayCharge As Long
    '値引き
    Public sDiscountPrice As Long
    'ポイント値引き
    Public sPointDiscountPrice As Long
    'チケット値引き
    Public sTicketDiscountPrice As Long
    '取引税抜金額
    Public sNoTaxPrice As Long
    '取引消費税額
    Public sTaxPrice As Long
    '取引軽減消費税額  2019/10/3 R.Takashima
    Public sReducedTaxRatePrice As Long

    '2019,12,23 A.Komita 追加 From
    '軽減税率 
    Public sReducedTaxRate As String
    '2019,12,23 A.Komita 追加 To

    '取引税込金額
    Public sPrice As Long
    '備考
    Public sMemo As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "棚卸データ"
Public Structure sInvCheck
    '棚卸日
    Public sInvCheckDate As String
    '商品コード
    Public sProductCode As String
    '在庫数
    Public sStockCount As Long
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "予約データ"
Public Structure sReserv
    '予約コード
    Public sReserveCode As Long
    '予約日FROM
    Public sFromReserveDate As String
    '予約日TO
    Public sToReserveDate As String
    'チャネルコード
    Public sChannelCode As Integer
    'ルームコード
    Public sRoomCode As Integer
    '開始時
    Public sFromHour As Integer
    '開始分
    Public sFromMinute As Integer
    '終了時
    Public sToHour As Integer
    '終了分
    Public sToMinute As Integer
    'サービス商品番号
    Public sBumonCode As String
    'サービス担当者コード
    Public sServiceStaffCode As String
    '会員コード
    Public sMemberCode As String
    '名称
    Public sName As String
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAddress1 As String
    '住所２
    Public sAddress2 As String
    '住所３
    Public sAddress3 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'メールアドレス
    Public sMailAddress As String
    '性別
    Public sSex As String
    '生年月日
    Public sBirthDay As String
    '年齢
    Public sGeneration As Integer
    '備考1
    Public sMemo1 As String
    '備考2
    Public sMemo2 As String
    '備考3
    Public sMemo3 As String
    '予約担当者コード
    Public sStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "ポイントデータ"
Public Structure sPoint
    '処理日
    Public sDate As String
    'ポイント会員コード
    Public sPointMemberCode As String
    '付与ポイント数
    Public sAddPoint As Long
    '利用ポイント数
    Public sUsePoint As Long
    '保有ポイント数
    Public sPoint As Long
    '有効フラグ
    Public sEnableFlg As Boolean
    '担当者コード
    Public sStaffCode As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "タグ印刷状態データ"
Public Structure sTagPrintStatus
    '商品コード
    Public sProductCode As String
    'タグ印刷状態
    Public sTagPrintCheck As Boolean
    '枚数
    Public sCount As Long
End Structure
#End Region

#Region "商品ステータス状態"
Public Structure sProductStatus
    '商品コード
    Public sProductCode As String
    '販売停止フラグ
    Public sStopSaleFlg As Boolean
    '仕入停止フラグ
    Public sStopSupplieFlg As Boolean
    'Yahoo掲載フラグ
    Public sYahooFlg As Boolean
    '楽天掲載フラグ
    Public sRakutenFlg As Boolean
    'Amazon掲載フラグ
    Public sAmazonFlg As Boolean
    '自社サイト掲載フラグ
    Public seShopFlg As Boolean
End Structure
#End Region

#Region "商品リスト状態データ"
Public Structure sProductListStatus
    '商品コード
    Public sProductCode As String
    '選択状態
    Public sCheck As Boolean
End Structure
#End Region

#End Region

#Region "View定義"

#Region "商品フルビュー"
Public Structure sViewProductPrice
    '商品コード
    Public sProductCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    '仕入先コード
    Public sSupplierCode As Integer
    '仕入先名称
    Public sSupplierName As String
    'SEQコード
    Public sSEQCode As String
    'JANコード
    Public sJANCode As String
    '商品種別
    Public sProductClass As Integer
    '商品名称
    Public sProductName As String
    '商品略称
    Public sProductShortName As String
    'メーカー名称
    Public sMakerName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '適用
    Public sMemo As String
    '定価
    Public sPrice As Long
    '仕入価格
    Public sCostPrice As Long
    '販売価格
    Public sSalePrice As Long
    '適正在庫数
    Public sMinStock As Integer
    'PLUコード
    Public sPLUCode As String
    '販売停止フラグ
    Public sStopSaleFlg As Boolean
    '仕入停止フラグ
    Public sSupplieStopFlg As Boolean
    'Yahoo掲載フラグ
    Public sYahooFlg As Boolean
    '楽天掲載フラグ
    Public sRakutenFlg As Boolean
    'Amazon掲載フラグ
    Public sAmazonFlg As Boolean
    '自社サイト掲載フラグ
    Public seShopFlg As Boolean

    '2019.8.7 A.Komita From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.8.7 A.Komita To

End Structure
#End Region

#Region "商品販売価格ビュー"
Public Structure sViewProductSalePrice
    '商品コード
    Public sProductCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'JANコード
    Public sJANCode As String
    '商品種別
    Public sProductClass As Integer
    '商品名称
    Public sProductName As String
    '商品略称
    Public sProductShortName As String
    'メーカー名称
    Public sMakerName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '適用
    Public sMemo As String
    '定価
    Public sListPrice As Long
    '販売単価
    Public sSalePrice As Long

    '2019.10.5 R.Takashima
    '軽減税率
    Public sReducedTaxRate As Boolean
    '2019.10.5 R.Takashima
End Structure
#End Region

#Region "商品マスタ＋販売価格"
Public Structure sViewProductPlusSalePrice
    '商品コード
    Public sProductCode As String
    '販売価格
    Public sSalePrice As Long
End Structure
#End Region

#Region "商品在庫ビュー"
Public Structure sViewProductStock
    '注文状態
    Public sStatus As Boolean
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    '商品略称
    Public sProductShortName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sPrice As Long
    'チャネルコード
    Public sChannelCode As Integer
    '仕入価格
    Public sCostPrice As Long
    '販売価格
    Public sSalePrice As Long
    '適正在庫数
    Public sMinStockCount As Long
    '在庫数
    Public sStockCount As Long
    'タグ印刷枚数
    Public sTagPrintCount As Integer
    '仕入先コード
    Public sSupplierCode As Integer
    '仕入先名称
    Public sSupplierName As String
    'PLUコード
    Public sPLUCode As String
    '適用開始日
    Public sStartDate As String
    '適用終了日
    Public sEndDate As String
End Structure
#End Region

#Region "商品リスト"
Public Structure sViewProductList
    '選択状態
    Public sStatus As Boolean
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sPrice As Long
    'チャネルコード
    Public sChannelCode As Integer
    '販売価格
    Public sSalePrice As Long
    'メーカー名称
    Public sMakerName As String
End Structure
#End Region

#Region "構成情報ビュー"
Public Structure sViewBom
    '構成コード
    Public sStructureCode As Integer
    'ノード番号
    Public sNodeNo As Integer
    '階層番号
    Public sHiearchyNo As Integer
    '親ノード番号
    Public sParentNodeNo As Integer
    '商品コード
    Public sProductCode As String
    '商品種別
    Public sProductClass As Integer
    '商品名称
    Public sProductName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sListPrice As Long
End Structure
#End Region

#Region "発注レポートビュー"
Public Structure sViewOrderReport
    'JANコード
    Public sJANCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    '商品略称
    Public sProductShortName As String
    'オプション1
    Public sOption1 As String
    'オプション1
    Public sOption2 As String
    'オプション1
    Public sOption3 As String
    'オプション1
    Public sOption4 As String
    'オプション1
    Public sOption5 As String
    '定価
    Public sPrice As Long
    '仕入価格
    Public sCostPrice As Long
    '数量
    Public sCount As Long
    '金額
    Public sOrderPrice As Long
    '在庫数
    Public sStock As Integer

    '2019,9,5 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.9.5 A.Komita 追加 To

End Structure
#End Region

#Region "発注候補抽出ビュー"
Public Structure sViewCandidate
    '選択状態
    Public sStatus As Boolean
    '仕入先名称
    Public sSupplierName As String
    'JANコード
    Public sJANCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sPrice As Long
    '仕入価格
    Public sCostPrice As Long
    '数量
    Public sCount As Integer
    '在庫数
    Public sStockCount As Integer
End Structure
#End Region

#Region "日次取引フルビュー"
Public Structure sViewTrnFull
    '取引コード
    Public sTrnCode As Long
    '取引明細コード
    Public sSubTrnCode As Long
    '取引区分
    Public sTrnClass As String
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    '受注日
    Public sRequestDate As String
    '受注時間
    Public sRequesTime As String
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '取引税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sTotalDiscount As Long
    'ポイント値引き
    Public sTotalPointDisCount As Long
    '取引税抜金額
    Public sNoTaxTotalPrice As Long
    '取引消費税額
    Public sTaxTotal As Long
    '取引税込金額
    Public sTotalPrice As Long
    '出荷コード
    Public sShipCode As String
    '会員コード
    Public sMemberCode As String
    '性別
    Public sSex As String
    '年代
    Public sGeneration As Integer
    '天気
    Public sWeather As String
    '日次締め日
    Public sDayCloseDate As String
    '月次締め日
    Public sMonthCloseDate As String
    '担当者コード
    Public sStaffCode As String
    '売上状態
    Public sStatus As String
    '売上明細区分
    Public sSubTrnClass As Integer
    '部門コード
    Public sBumonCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'JANコード
    Public sJANCode As String
    'オプション1
    Public sOption1 As String
    'オプション2
    Public sOption2 As String
    'オプション3
    Public sOption3 As String
    'オプション4
    Public sOption4 As String
    'オプション5
    Public sOption5 As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '取引商品単価
    Public sUnitPrice As Long
    '取引数量
    Public sCount As Integer
    '取引税抜金額
    Public sNoTaxProductPrice As Long
    '値引き
    Public sDiscountPrice As Long
    'ポイント値引き
    Public sPointDiscountPrice As Long
    '取引税抜金額
    Public sNoTaxPrice As Long
    '取引消費税額
    Public sTaxPrice As Long
    '取引税込金額
    Public sPrice As Long
End Structure
#End Region

#Region "日次取引サマリービュー"
Public Structure sViewTrnSummary
    'チャネルコード
    Public sChannel As Integer
    'チャネル名称
    Public sChannelName As String
    '取引区分
    Public sTrnClass As String
    '部門コード
    Public sBumonCode As String

    '2019,12,24 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019,12,24 A.Komita 追加 To

    '部門略称
    Public sBumonShortName As String
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '数量の合計
    Public sCount As Integer
    '税抜金額の合計
    Public sNoTaxProductPrice As Long
    '送料の合計
    Public sShippingCharge As Long
    '手数料の合計
    Public sPaymentCharge As Long
    '値引きの合計
    Public sDiscountPrice As Long
    'ポイント値引きの合計
    Public sPointDiscountPrice As Long
    '税込金額の合計
    Public sPrice As Long
End Structure
#End Region

#Region "入庫集計ビュー"
Public Structure sViewArrivalSummary
    '入庫日
    Public sArrivalDate As String
    '仕入先コード
    Public sSupplierCode As Integer
    '仕入先名称
    Public sSupplierName As String
    'JANコード
    Public sJANCode As String
    '商品コード
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'オプション1～5
    Public sOption As String
    '定価
    Public sListPrice As Long
    '入庫商品単価
    Public sUnitPrice As Long
    '入庫数量
    Public sCount As Integer
    '入庫税抜金額
    Public sNoTaxPrice As Long
    '入庫消費税額
    Public sTaxPrice As Long

    '2019,12,26 A.Komita 追加 From
    '入庫軽減税額
    Public sReducedTaxRate As Long
    '2019,12,26 A.Komita 追加 To

    '入庫税込金額
    Public sPrice As Long
End Structure
#End Region

#Region "月次集計用サマリービュー"
Public Structure sViewMonthTrnSummary
    '名称
    Public sName As String
    '数量の合計
    Public sCount As Integer
    '税込金額の合計
    Public sPrice As Long
    '部門種別
    Public sBumonClass As Integer
    '2019.12.19 R.Takashima FROM
    '消費税額
    Public sTaxPrice As Long
    '軽減消費税額
    Public sReduceTaxPrice As Long
    '2019.12.19 R.Takashima TO

    '2019,12,26 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019,12,26 A.Komita 追加 To

End Structure
#End Region

#Region "日次取引会計用ビュー"
Public Structure sViewFinTrnFull
    '取引コード
    Public sTrnCode As Long
    '取引区分
    Public sTrnClass As String
    'チャネルコード
    Public sChannel As Integer
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '取引税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sTotalDiscount As Long
    'ポイント値引き
    Public sTotalPointDisCount As Long
    '取引税抜金額
    Public sNoTaxTotalPrice As Long
    '取引消費税額
    Public sTaxTotal As Long
    '取引税込金額
    Public sTotalPrice As Long
    '日次締め日
    Public sDayCloseDate As String
    '月次締め日
    Public sMonthCloseDate As String
    '売上状態
    Public sStatus As String
    '部門コード
    Public sBumonCode As String
    '部門名称
    Public sBumonName As String
    '取引税抜金額
    Public sNoTaxProductPrice As Long
    '値引き
    Public sDiscountPrice As Long
    'ポイント値引き
    Public sPointDiscountPrice As Long
    '取引税抜金額
    Public sNoTaxPrice As Long
    '取引消費税額
    Public sTaxPrice As Long
    '取引税込金額
    Public sPrice As Long
End Structure
#End Region

#Region "発注情報フルビュー"
Public Structure sViewOrderDataFull
    '発注コード
    Public sOrderCode As String
    '発注日
    Public sOrderDate As String
    '発注モード
    Public sOrderMode As Integer
    '発注税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '発注値引き
    Public sPointDisCount As Long
    '発注ポイント値引き
    Public sDiscount As Long
    '発注税抜金額
    Public sNoTaxTotalPrice As Long
    '発注消費税額
    Public sTaxTotal As Long

    '2019.9.22 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019.9.22 A.Komita 追加 To

    '2019,9,22 A.Komita 追加 From
    '発注軽減消費税額
    Public sReducedTaxRateTotal As Long
    '2019,9,22 A.Komita 追加 To

    '発注税込金額
    Public sTotalPrice As Long
    '仕入先コード
    Public sSupplierCode As Long
    '仕入先名称
    Public sSupplierName As String
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '希望納品日
    Public sRequestDate As String
    '希望納品場所
    Public sRequestPlace As String
    '発注担当者コード
    Public sStaffCode As String
    '発注担当者名称
    Public sStaffName As String
    '備考
    Public sMemo As String
    '伝票印刷モード
    Public sPrintMode As Integer
    '完納日
    Public sAllArrivedDate As String
End Structure
#End Region

#Region "受注情報フルビュー"
Public Structure sViewRequestDataFull
    '受注コード
    Public sRequestCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'OR受注コード
    Public sORRequestCode As String
    '受注サイト
    Public sRequestSite As String
    '受注媒体
    Public sRequestMedia As String
    'モバイルフラグ
    Public sMobileFlg As String
    'アフェリエイトフラグ
    Public sAffiliateFlg As String
    '受注日
    Public sRequestDate As String
    '受注時間
    Public sRequestTime As String
    '出荷先－会社名
    Public sShipCorpName As String
    '出荷先－支店名
    Public sShipDivName As String
    '出荷先－姓カナ
    Public sShipKanaShip1stName As String
    '出荷先－名カナ
    Public sShipKanaShip2ndName As String
    '出荷先－住所１カナ
    Public sShipKanaAdder1 As String
    '出荷先－住所２カナ
    Public sShipKanaAdder2 As String
    '出荷先－住所市区町村カナ
    Public sShipKanaCity As String
    '出荷先－都道府県カナ
    Public sShipKanaState As String
    '出荷先－姓
    Public sShip1stName As String
    '出荷先－名
    Public sShip2ndName As String
    '出荷先－住所１
    Public sShipAdder1 As String
    '出荷先－住所２
    Public sShipAdder2 As String
    '出荷先－住所市区町村
    Public sShipCity As String
    '出荷先－都道府県
    Public sShipState As String
    '出荷先－国名
    Public sShipCountry As String
    '出荷先－郵便番号1
    Public sShipPostCode1 As String
    '出荷先－郵便番号2
    Public sShipPostCode2 As String
    '出荷先－電話番号
    Public sShipTel As String
    '請求先－会社名
    Public sBillCorpName As String
    '請求先－支店名
    Public sBillDivName As String
    '請求先－姓カナ
    Public sBillKanaBill1stName As String
    '請求先－名カナ
    Public sBillKanaBill2ndName As String
    '請求先－住所１カナ
    Public sBillKanaAdder1 As String
    '請求先－住所２カナ
    Public sBillKanaAdder2 As String
    '請求先－住所市区町村カナ
    Public sBillKanaCity As String
    '請求先－都道府県カナ
    Public sBillKanaState As String
    '請求先－姓
    Public sBill1stName As String
    '請求先－名
    Public sBill2ndName As String
    '請求先－住所１
    Public sBillAdder1 As String
    '請求先－住所２
    Public sBillAdder2 As String
    '請求先－住所市区町村
    Public sBillCity As String
    '請求先－都道府県
    Public sBillState As String
    '請求先－国名
    Public sBillCountry As String
    '請求先－郵便番号1
    Public sBillPostCode1 As String
    '請求先－郵便番号2
    Public sBillPostCode2 As String
    '請求先－電話番号
    Public sBillTel As String
    'メールアドレス
    Public sMailAdderss As String
    'コメント
    Public sComment As String
    'ステータス
    Public sStatus As String
    'エントリーポイント
    Public sEntryPoint As String
    'リンク先
    Public sLink As String
    'カード支払方法
    Public sCardPayment As String
    '配達希望日
    Public sShipRequestDate As String
    '配達希望時間
    Public sShipRequestTime As String
    '配達希望メモ
    Public sShipMemo As String
    '配送業者
    Public sShipCorp As String
    'チャネル支払コード
    Public sChannelPaymentCode As Integer
    'ギフト梱包希望
    Public sGiftRequest As String
    '取得ポイント数
    Public sGetPoint As Long
    '受注商品税抜金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    '受注税抜金額
    Public sNoTaxTotalPrice As Long
    '受注消費税額
    Public sTaxTotal As Long
    '受注軽減税額
    Public sReducedTaxRate As Long
    '受注税込金額
    Public sTotalPrice As Long
    'ギフト梱包材料
    Public sGiftWrapKind As String
    'ギフト梱包料金
    Public sGiftWrapKindPrice As Long
    'のし希望
    Public sNoshiType As String
    'のし記載内容
    Public sNoshiName As String
    '注文者性別
    Public sBillSex As String
    '注文者誕生日
    Public sBillBirthDay As String
    '楽天バンク決済手数料
    Public sRakutenCharge As Long
    '受注伝票出力フラグ
    Public sPrintFlg As Boolean
    '受注担当者
    Public sRequestStaffCode As String
    '出荷日
    Public sShipDate As String
    '荷物受渡番号
    Public sDeliveryNumber As String
    '出荷先電話番号
    Public sTel As String
    '出荷先郵便番号
    Public sPostalCode As String
    '出荷先住所1
    Public sAddress1 As String
    '出荷先住所2
    Public sAddress2 As String
    '出荷先住所3
    Public sAddress3 As String
    '出荷先姓
    Public sFirstName As String
    '出荷先名
    Public sLastName As String
    '配送業者コード
    Public sShipCorpCode As Integer
    '営業店コード
    Public sShipOfficeCode As String
    '代引金額
    Public sDaibikiPrice As Long
    '出荷担当者
    Public sShipStaffCode As String

End Structure
#End Region

#Region "受注明細情報フルビュー"
Public Structure sViewRequestSubDataFull
    '受注コード
    Public sRequestCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'OR受注コード
    Public sORRequestCode As String
    '受注明細コード
    Public sRequestSubCode As Integer
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション名称
    Public sOptionName As String
    'オプション値
    Public sOptionValue As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '受注商品単価
    Public sUnitPrice As Long
    '受注数量
    Public sCount As Integer
    '受注税抜金額
    Public sNoTaxPrice As Long
    '受注消費税額
    Public sTaxPrice As Long
    '受注税込金額
    Public sPrice As Long
    'チャネル商品コード
    Public sChannelProductCode As String
    'チャネル商品名称
    Public sChannelProductName As String
    'チャネルオプション
    Public sChannelOptionNameAndValue As String
    '出荷数量
    Public sShipmentCount As Integer

End Structure
#End Region

#Region "入庫情報フルビュー"
Public Structure sViewArriveDataFull
    '発注コード
    Public sOrderCode As String
    '入庫番号
    Public sArrivalNo As Long
    '仕入先コード
    Public sSupplierCode As Long
    '仕入先名称
    Public sSupplierName As String
    '支払方法コード
    Public sPaymentCode As Integer
    '支払方法名称
    Public sPaymentName As String
    '入庫税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sPointDisCount As Long
    'ポイント値引き
    Public sDiscount As Long
    '入庫税抜金額
    Public sNoTaxTotalPrice As Long

    '2019,10,19 A.Komita 追加 From
    '入庫消費税額
    Public sTaxTotal As Long
    '2019,10,19 A.Komita 追加 To

    '軽減税率
    Public sReducedTaxRate As String
    '入庫税込金額
    Public sTotalPrice As Long
    '完納フラグ 
    Public sFinishFlg As Boolean
    '入庫担当者コード
    Public sStaffCode As String
    '入庫担当者名称
    Public sStaffName As String
End Structure
#End Region

#Region "出荷情報フルビュー"
Public Structure sViewShipmentDataFull
    '選択状態
    Public sShipCheck As Boolean
    '出荷コード
    Public sShipCode As String
    'チャネルコード
    Public sChannelCode As Integer
    '受注コード
    Public sRequestCode As String
    '出荷日
    Public sShipDate As String
    '荷物受渡番号
    Public sDeliveryNumber As String
    '出荷先電話番号
    Public sTel As String
    '出荷先郵便番号
    Public sPostalCode As String
    '出荷先住所1
    Public sAddress1 As String
    '出荷先住所2
    Public sAddress2 As String
    '出荷先住所3
    Public sAddress3 As String
    '出荷先姓
    Public sFirstName As String
    '出荷先名
    Public sLastName As String
    '配達日
    Public sShipRequestDate As String
    '配達指定時間帯
    Public sShipRequestTimeClass As String
    '配達指定時間
    Public sShipRequestTime As String
    '配送業者コード
    Public sShipCorpCode As Integer
    '営業店コード
    Public sShipOfficeCode As String
    '代引金額
    Public sDaibikiPrice As Long
    '出荷税抜商品金額
    Public sNoTaxTotalProductPrice As Long
    '送料
    Public sShippingCharge As Long
    '手数料
    Public sPaymentCharge As Long
    '値引き
    Public sDiscount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    '出荷税抜金額
    Public sNoTaxTotalPrice As Long
    '出荷消費税額
    Public sTaxTotal As Long
    '出荷税込金額
    Public sTotalPrice As Long
    '荷姿コード
    Public sLookFeelCode As Integer
    '支払方法コード
    Public sShipPaymentCode As Integer
    '決済種別
    Public sShipPaymentClass As Integer
    '便種スピード
    Public sDeliveryClassSpeed As String
    '便種商品
    Public sDeliveryClassProduct As String
    '指定シール1
    Public sSeal1 As String
    '指定シール2
    Public sSeal2 As String
    '指定シール3
    Public sSeal3 As String
    '元着区分
    Public sMotoCyakuClass As Integer
    '出荷完了フラグ
    Public sFinishFlg As Integer
    '再出荷事由
    Public sReShopMemo As String
    '出荷メモ
    Public sShipMemo As String
    '配送伝票CSV出力フラグ
    Public sDeleveryCSVOutoutFlg As Boolean
    '出荷担当者コード
    Public sShipStaffCode As String
    '受注明細コード
    Public sRequestSubCode As Integer
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション名称
    Public sOptionName As String
    'オプション値
    Public sOptionValue As String
    '定価
    Public sListPrice As Long
    '仕入単価
    Public sCostPrice As Long
    '出荷商品単価
    Public sUnitPrice As Long
    '出荷数量
    Public sCount As Integer
    '出荷税抜金額
    Public sNoTaxPrice As Long
    '出荷消費税額
    Public sTaxPrice As Long
    '出荷税込金額
    Public sPrice As Long
End Structure
#End Region

#Region "チャネル別支払方法フルビュー"
Public Structure sViewChannelPaymentFull
    'チャネル支払コード
    Public sChannelPaymentCode As Integer
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    '支払方法コード
    Public sPaymentCode As Integer
    'チャネル別支払方法名称
    Public sChannelPaymentName As String
    '支払方法名称
    Public sPaymentName As String
    '掛取引フラグ
    Public sCreditFlg As Boolean
    '受注フラグ
    Public sRequestFlg As Boolean
    '出荷フラグ
    Public sShipmentFlg As Boolean
    '発注フラグ
    Public sOrderFlg As Boolean
    '入荷フラグ
    Public sArrivalFlg As Boolean
    '返品フラグ
    Public sReturnFlg As Boolean

    '配送時代引きフラグ
    Public sDaibikiFlg As Boolean

End Structure
#End Region

#Region "スタッフ権限フル"
Public Structure sViewStaffFull
    'スタッフコード
    Public sStaffCode As String
    '役割コード
    Public sRoleCode As Integer
    '役割名称
    Public sRoleName As String
    'スタッフ種別
    Public sStaffClass As String
    '部門コード
    Public sBumonCode As String
    '社販レート
    Public sRate As Long
    'スタッフ名称
    Public sStaffName As String
    'アプリケーションID
    Public sApplicationID As String
    'グループID
    Public sGroupID As String
    'グループ名称
    Public sGroupName As String
    'メニュー名称
    Public sMenuName As String
    'コントロール名称
    Public sControlName As String
    '実行モジュール名称
    Public sExeName As String
End Structure
#End Region

#Region "標準原価取得ビュー"
Public Structure sViewAvgCostPrice
    '商品コード
    Public sProductCode As String
    '仕入単価
    Public sAvgCostPrice As Long
End Structure
#End Region

'#Region "会員種別ビュー"
'Public Structure sViewMemberClass
'    'メンバー種別
'    Public sMemberClass As String
'End Structure
'#End Region

#Region "サービスフルビュー"
Public Structure sViewServiceFull
    'サービスコード
    Public sServiceCode As Integer
    'サービス名称
    Public sServiceName As String
    'サービス区分
    Public sServiceClass As Integer
    'サービス対象－顧客
    Public sTarget_C As Boolean
    'サービス対象－社員
    Public sTarget_E As Boolean
    'サービス対象－アルバイト
    Public sTarget_A As Boolean
    'サービス対象－パート
    Public sTarget_P As Boolean
    'サービス対象－その他
    Public sTarget_O As Boolean
    '部門コード
    Public sBumonCode As String
    '部門名称
    Public sBumonName As String
    '割引率種別
    Public sRateClass As String
    '割引率
    Public sRate As Integer
End Structure
#End Region

#Region "汎用マスタービュー"
Public Structure sViewUnionMaster
    'コード
    Public sCode As Integer
    '名称   
    Public sName As String
    'サブコード
    Public sSubCode As String
    'サブ名称   
    Public sSubName As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "予約データFull"
Public Structure sViewReservFull
    '予約コード
    Public sReserveCode As Long
    '予約日FROM
    Public sFromReserveDate As String
    '予約日TO
    Public sToReserveDate As String
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    'ルームコード
    Public sRoomCode As Integer
    'ルーム名称
    Public sRoomName As String
    '開始時
    Public sFromHour As Integer
    '開始分
    Public sFromMinute As Integer
    '終了時
    Public sToHour As Integer
    '終了分
    Public sToMinute As Integer
    'サービス部門コード
    Public sBumonCode As String
    'サービス部門名称
    Public sBumonName As String
    'サービス担当者コード
    Public sServiceStaffCode As String
    'サービス担当者名称
    Public sServiceStaffName As String
    '会員コード
    Public sMemberCode As String
    '名称
    Public sName As String
    '郵便番号
    Public sPostCode As String
    '住所１
    Public sAddress1 As String
    '住所２
    Public sAddress2 As String
    '住所３
    Public sAddress3 As String
    'TEL
    Public sTEL As String
    'FAX
    Public sFAX As String
    'メールアドレス
    Public sMailAddress As String
    '性別
    Public sSex As String
    '生年月日
    Public sBirthDay As String
    '年齢
    Public sGeneration As Integer
    '備考1
    Public sMemo1 As String
    '備考2
    Public sMemo2 As String
    '備考3
    Public sMemo3 As String
End Structure
#End Region

#Region "スタッフ権限ビュー"
Public Structure sViewStaffAuthority
    'スタッフコード
    Public sStaffCode As String
    'アプリケーションID
    Public sApplicationID As String
    'グループID
    Public sGroupID As String
    'グループ名称
    Public sGroupName As String
    'メニュー名称
    Public sMenuName As String
    'コントロール名称
    Public sControlName As String
    '実行モジュール名称
    Public sExeName As String
End Structure
#End Region

#Region "出荷情報明細クエリー"
Public Structure sViewShipmentSubQuery
    '受注コード
    Public sRequestCode As String
    '出荷コード
    Public sShipCode As Integer
    '受注明細コード
    Public sRequestSubCode As Integer
    '商品コード
    Public sProductCode As String
    'JANコード
    Public sJANCode As String
    '商品名称
    Public sProductName As String
    'オプション名称
    Public sOptionName As String
    'オプション値
    Public sOptionValue As String
    '出荷数量
    Public sShipmentCount As Integer
    '定価
    Public sUnitPrice As Long
    '販売価格
    Public sSalePrice As Long
    '数量
    Public sCount As Integer
    '金額
    Public sPrice As Long
End Structure
#End Region

#Region "商品販売状況マスタ"
Public Structure sViewSales
    '商品コード
    Public sProductCode As String
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    '掲載開始日
    Public sStartDate As String
    '掲載終了日
    Public sEndDate As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "レジ明細情報（DataGridView)"
Public Structure sViewMeisai
    Public sJANCode As String
    Public sProductCode As String
    Public sProductName As String
    Public sOption As String
    Public sPrice As Long
    Public sSale_Price As Long
    Public sCnt As Single
    Public sTPrice As Long
    Public sDPrice As Long
    Public sTrnCode As Long
    Public sSubTrnCode As Long
End Structure
#End Region

#Region "CSV読込みバッファ"
Public Structure sViewCSVReadBuff
    Public sRead() As String
End Structure
#End Region

#Region "仕入先分析用バッファ"
Public Structure sViewSupplierCode
    '仕入先コード
    Public sSupplierCode() As Integer
End Structure
#End Region

#Region "商品コード変換マスタ"
Public Structure sViewCnvProductCd
    Public sIsDataChanged As Boolean
    'Public sID As Integer
    Public sChannelCode As Integer
    Public sChannelName As String
    Public sChannelProductCode As String
    Public sChannelProductName As String
    Public sChannelOptionNameAndValue As String
    Public sProductCode As String
    Public sCreateDate As String
    Public sCreateTime As String
    Public sUpdateDate As String
    Public sUpdateTime As String
End Structure
#End Region

#Region "保留マッピングデータ"
Public Structure sViewPenddingCnvProduct
    Public sProductCode As String
    Public sChannelCode As Integer
    Public sChannelName As String
    Public sChannelProductCode As String
    Public sChannelProductName As String
    Public sChannelOptionNameAndValue As String
End Structure
#End Region

#Region "取引明細集計データ"
Public Structure sViewDataTrnMs
    ' 取引区分
    Public sThkKbn As String
    ' チャネルコード
    Public sChannelCode As String
    ' チャネル名称
    Public sChannelName As String
    ' 部門コード
    Public sBumonCode As String
    ' 部門名称
    Public sBumonName As String
    ' 商品コード
    Public sProductCode As String
    ' 商品名称
    Public sProductName As String
    ' オプション1
    Public sOption1 As String
    ' オプション2
    Public sOption2 As String
    ' オプション3
    Public sOption3 As String
    ' オプション4
    Public sOption4 As String
    ' オプション5
    Public sOption5 As String
    ' 定価
    Public sListPrice As Long
    ' 仕入単価
    Public sCostPrice As Long
    ' 値引き額の合計
    Public sDiscountPrice As Long
    ' 取引数量の合計
    Public sCount As Integer
    ' 取引税込金額の合計
    Public sPrice As Long
    ' 取引担当者コード
    Public sStaffCode As String
    ' スタッフ名称
    Public sStaffName As String
End Structure
#End Region

#Region "日次売上明細データ"
Public Structure sViewDayTrhkMs
    ' チャネル名称
    Public sChannelName As String
    ' 取引コード
    Public sTrhkCode As String
    ' 取引明細コード
    Public sTrhkMsCode As String
    ' 取引区分
    Public sTrhkKbn As String
    ' 売上状態
    Public sStatus As String
    ' 商品コード
    Public sProductCode As String
    ' 商品名称
    Public sProductName As String
    ' オプション1
    Public sOption1 As String
    ' オプション2
    Public sOption2 As String
    ' オプション3
    Public sOption3 As String
    ' オプション4
    Public sOption4 As String
    ' オプション5
    Public sOption5 As String
    ' 定価
    Public sListPrice As Long
    ' 取引数量
    Public sCount As Long
    ' 取引税込金額
    Public sPrice As Long
End Structure
#End Region

#Region "時間帯別売り上げデータ"
Public Structure sViewTimeSales
    ' チャネル名
    Public sChannelCode As String
    ' チャネル名
    Public sChannelName As String
    ' 登録日
    Public sBusinessDate As String
    ' 時間帯
    Public sTimeZone As String
    ' 売上額
    Public sTimeSales As Long
End Structure
#End Region

'2016.06.08 K.Oikawa s
#Region "取引履歴データ"
Public Structure sViewHstTrn
    '受注日
    Public sRequestDate As String
    '受注時間
    Public sRequesTime As String
    '商品コード
    Public sProductCode As String
    '商品名
    Public sProductName As String
    '商品JAN
    Public sJanCode As String
    '取引コード
    Public sTrnCode As String
    ''オプション1
    'Public sOption1 As String
    ''オプション2
    'Public sOption2 As String
    ''オプション3
    'Public sOption3 As String
    ''オプション4
    'Public sOption4 As String
    ''オプション5
    'Public sOption5 As String
    '取引商品単価
    Public sUnitPrice As Long
    '取引数量
    Public sCount As Integer
    ''取引合計金額
    'Public sPrice As Long
    '会員コード
    Public sMemberCode As String
    '会員名称
    Public sMemberName As String
    'チャネル名称
    Public sChannelCode As String
    Public sChannelName As String
    '担当者
    Public sStaffName As String
    '支払方法
    Public sPaymentMethod As String
End Structure
#End Region
'2016.06.08 K.Oikawa e

#Region "カテゴリマスタフル"
Public Structure sViewCategoryFull
    'カテゴリID_1
    Public sCategory1ID As String
    'カテゴリ名称_1
    Public sCategory1Name As String
    'カテゴリID_2
    Public sCategory2ID As String
    'カテゴリ名称_2
    Public sCategory2Name As String
End Structure
#End Region

#Region "ルームフル"
Public Structure sViewRoomFull
    'ルームコード
    Public sRoomCode As Integer
    'ルーム名称
    Public sRoomName As String
    'チャネルコード
    Public sChannelCode As Integer
    'チャネル名称
    Public sChannelName As String
    'チャネル種別
    Public sChannelClass As Integer
    'URL
    Public sURL As String
    'レシート印刷フラグ
    Public sReceiptPrint As Boolean
    '売上計上フラグ
    Public sSaleRegist As Boolean
    '注文データファイル有無
    Public sRequestFileFlg As Boolean
    '注文明細データファイル有無
    Public sRequestSubFileFlg As Boolean
    'CMSタイプ
    Public sCMSType As Integer
    'OR受注コードフィールド名
    Public sORRequestCodeFieldName As String
End Structure
#End Region

#Region "税区分フル"
Public Structure sViewTaxClassFull
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
    '業種
    Public sBusinessClass As String
    '登録日
    Public sCreateDate As String
    '登録時間
    Public sCreateTime As String
    '最終更新日
    Public sUpdateDate As String
    '最終更新時間
    Public sUpdateTime As String
End Structure
#End Region

#Region "勘定科目フル"
Public Structure sViewAccountFull
    '勘定科目コード
    Public sAccountCode As Integer
    '勘定科目名称
    Public sAccountName As String
    '連動マスタ名称
    Public sLinkMasterName As String
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
End Structure
#End Region

#Region "部門マスタフル"
Public Structure sViewBumonFull
    '部門コード
    Public sBumonCode As String
    '部門名称
    Public sBumonName As String
    '部門略称
    Public sBumonShortName As String
    '部門種別
    Public sBumonClass As Integer
    '予約フラグ
    Public sReservFlg As Boolean
    '予約単位
    Public sReservPeace As String
    '税区分コード
    Public sTaxClassCode As Integer
    '税区分名称
    Public sTaxClassName As String
End Structure
#End Region


#End Region

#Region "ストラクチャ定義"
'月次締め処理　グラフデータ用ストラクチャ
Public Structure sGraphData
    '商品番号
    Public sProductCode As String
    '商品名称
    Public sProductName As String
    'オプション値
    Public sOption As String
    '数量
    Public sCount As Long
    '金額
    Public sPrice As Long
    '送料
    Public sPostage As Long
    '手数料
    Public sFee As Long
    '値引き
    Public sDisCount As Long
    'ポイント値引き
    Public sPointDisCount As Long
    'チケット値引き
    Public sTicketDisCount As Long

    '2019,12,24 A.Komita 追加 From
    '軽減税率
    Public sReducedTaxRate As String
    '2019,12,24 A.Komita 追加 To
End Structure

'月次締め処理　グラフ生成用ストラクチャ
Public Structure sGraphDataSet
    '商品名称
    Public sName As String
    '金額
    Public sValue As Long
End Structure
#End Region

'--------------- Public定数定義 --------------------------
#Region "グローバル定数定義"
Public Enum GetAdjustMode As Long
    FromToAdjustCode = 1
    OrderOverAdjustCodeInPutClass = 2
    DescOrderAll = 3
    OrderOverAdjustCode = 4
    OrderDateInOutClass = 5
    AdjustDate = 6
End Enum
#End Region

#Region "列挙型の定義(ダウンロードカラムマスタ)"
Public Enum DBColumnType As Integer
    Str
    Number
End Enum
#End Region




