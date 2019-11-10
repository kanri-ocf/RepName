Imports System.Data.OleDb

Public Class cDataRequestTMPDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Private metaInfo As Hashtable

    Private l As cLog

    Private Shared columnNames As String()
    Private Shared paramNames As String()
    Private oTool As cTool

    Shared Sub New()
        Dim c As New List(Of String)
        Dim p As New List(Of String)
        c.Add("受注コード") : p.Add("@RequestCode")
        c.Add("チャネルコード") : p.Add("@ChannelCode")
        c.Add("OR受注コード") : p.Add("@ORRequestCode")
        c.Add("受注サイト") : p.Add("@RequestSite")
        c.Add("受注媒体") : p.Add("@RequestMedia")
        c.Add("モバイルフラグ") : p.Add("@MobileFlg")
        c.Add("アフェリエイトフラグ") : p.Add("@AffiliateFlg")
        c.Add("受注日") : p.Add("@RequestDate")
        c.Add("受注時間") : p.Add("@RequestTime")
        c.Add("出荷先－会社名") : p.Add("@ShipCorpName")
        c.Add("出荷先－支店名") : p.Add("@ShipDivName")
        c.Add("出荷先－姓カナ") : p.Add("@ShipKanaShip1stName")
        c.Add("出荷先－名カナ") : p.Add("@ShipKanaShip2ndName")
        c.Add("出荷先－住所１カナ") : p.Add("@ShipKanaAdder1")
        c.Add("出荷先－住所２カナ") : p.Add("@ShipKanaAdder2")
        c.Add("出荷先－住所市区町村カナ") : p.Add("@ShipKanaCity")
        c.Add("出荷先－都道府県カナ") : p.Add("@ShipKanaState")
        c.Add("出荷先－姓") : p.Add("@Ship1stName")
        c.Add("出荷先－名") : p.Add("@Ship2ndName")
        c.Add("出荷先－住所１") : p.Add("@ShipAdder1")
        c.Add("出荷先－住所２") : p.Add("@ShipAdder2")
        c.Add("出荷先－住所市区町村") : p.Add("@ShipCity")
        c.Add("出荷先－都道府県") : p.Add("@ShipState")
        c.Add("出荷先－国名") : p.Add("@ShipCountry")
        c.Add("出荷先－郵便番号1") : p.Add("@ShipPostCode1")
        c.Add("出荷先－郵便番号2") : p.Add("@ShipPostCode2")
        c.Add("出荷先－電話番号") : p.Add("@ShipTel")
        c.Add("請求先－会社名") : p.Add("@BillCorpName")
        c.Add("請求先－支店名") : p.Add("@BillDivName")
        c.Add("請求先－姓カナ") : p.Add("@BillKanaBill1stName")
        c.Add("請求先－名カナ") : p.Add("@BillKanaBill2ndName")
        c.Add("請求先－住所１カナ") : p.Add("@BillKanaAdder1")
        c.Add("請求先－住所２カナ") : p.Add("@BillKanaAdder2")
        c.Add("請求先－住所市区町村カナ") : p.Add("@BillKanaCity")
        c.Add("請求先－都道府県カナ") : p.Add("@BillKanaState")
        c.Add("請求先－姓") : p.Add("@Bill1stName")
        c.Add("請求先－名") : p.Add("@Bill2ndName")
        c.Add("請求先－住所１") : p.Add("@BillAdder1")
        c.Add("請求先－住所２") : p.Add("@BillAdder2")
        c.Add("請求先－住所市区町村") : p.Add("@BillCity")
        c.Add("請求先－都道府県") : p.Add("@BillState")
        c.Add("請求先－国名") : p.Add("@BillCountry")
        c.Add("請求先－郵便番号1") : p.Add("@BillPostCode1")
        c.Add("請求先－郵便番号2") : p.Add("@BillPostCode2")
        c.Add("請求先－電話番号") : p.Add("@BillTel")
        c.Add("メールアドレス") : p.Add("@MailAdderss")
        c.Add("コメント") : p.Add("@Comment")
        c.Add("ステータス") : p.Add("@Status")
        c.Add("エントリーポイント") : p.Add("@EntryPoint")
        c.Add("リンク先") : p.Add("@Link")
        c.Add("カード支払方法") : p.Add("@CardPayment")
        c.Add("配達希望日") : p.Add("@ShipRequestDate")
        c.Add("配達希望時間") : p.Add("@ShipRequestTime")
        c.Add("配達希望メモ") : p.Add("@ShipMemo")
        c.Add("配送業者") : p.Add("@ShipCorp")
        c.Add("チャネル支払コード") : p.Add("@ChannelPaymentCode")
        c.Add("ギフト梱包希望") : p.Add("@GiftRequest")
        c.Add("取得ポイント数") : p.Add("@GetPoint")
        c.Add("受注商品税抜金額") : p.Add("@NoTaxTotalProductPrice")
        c.Add("送料") : p.Add("@ShippingCharge")
        c.Add("手数料") : p.Add("@PaymentCharge")
        c.Add("値引き") : p.Add("@Discount")
        c.Add("ポイント値引き") : p.Add("@PointDisCount")
        c.Add("受注税抜金額") : p.Add("@NoTaxTotalPrice")
        c.Add("受注消費税額") : p.Add("@TaxTotal")
        c.Add("受注税込金額") : p.Add("@TotalPrice")
        c.Add("ギフト梱包材料") : p.Add("@GiftWrapKind")
        c.Add("ギフト梱包料金") : p.Add("@GiftWrapKindPrice")
        c.Add("のし希望") : p.Add("@NoshiType")
        c.Add("のし記載内容") : p.Add("@NoshiName")
        c.Add("注文者性別") : p.Add("@BillSex")
        c.Add("注文者誕生日") : p.Add("@BillBirthDay")
        c.Add("楽天バンク決済手数料") : p.Add("@RakutenCharge")
        c.Add("受注伝票出力フラグ") : p.Add("@PrintFlg")
        c.Add("受注担当者コード") : p.Add("@StaffCode")
        c.Add("登録日") : p.Add("@CreateDate")
        c.Add("登録時間") : p.Add("@CreateTime")
        c.Add("最終更新日") : p.Add("@UpdateDate")
        c.Add("最終更新時間") : p.Add("@UpdateTime")

        columnNames = c.ToArray
        paramNames = p.ToArray


    End Sub


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader

        oTool = New cTool

    End Sub


    '-------------------------------------------------------------------------------
    '　機能：受注情報データTMPから該当レコードを取得する関数
    '　引数：Byref parRequest()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Request_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getRequest(ByRef parRequest() As cStructureLib.sRequestData, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyRequestCode As String, _
                                    ByVal KeyRequestDate As String, _
                                    ByVal KeyCustmorName As String, _
                                    ByVal KeyOriginalOrderCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報データTMP "
        'パラメータ数のカウント
        pc = 0
        If KeyChannelCode <> Nothing Then
            pc = pc Or 1
        End If
        If KeyRequestCode <> "" Then
            pc = pc Or 2
        End If
        If KeyRequestDate <> "" Then
            pc = pc Or 4
        End If
        If KeyCustmorName <> "" Then
            pc = pc Or 8
        End If
        If KeyOriginalOrderCode <> "" Then
            pc = pc Or 16
        End If

        'パラメータ指定がある場合
        If 31 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 16
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= @ChannelCode "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード= @RequestCode "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 Like ""%" & KeyRequestDate & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "([請求先－姓] & [請求先－名]) Like ""%" & KeyCustmorName & "%"""
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(OR受注コード = @ORRequestCode) "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************
            If 15 And pc > 0 Then
                i = 1
                scnt = 0
                While i <= 16
                    Select Case i And pc
                        Case 1
                            'チャネルコードコード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric))
                            pCommand.Parameters("@ChannelCode").Value = KeyChannelCode
                            scnt = scnt + 1
                        Case 2
                            '受注コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char))
                            pCommand.Parameters("@RequestCode").Value = KeyRequestCode
                            scnt = scnt + 1
                        Case 4
                            '受注日
                            scnt = scnt + 1
                        Case 8
                            '請求者－氏名
                            scnt = scnt + 1
                        Case 16
                            'オリジナル受注コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@ORRequestCode", OleDb.OleDbType.Char))
                            pCommand.Parameters("@ORRequestCode").Value = KeyOriginalOrderCode
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            i = 0

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parRequest(i)


                '受注コード
                parRequest(i).sRequestCode = pDataReader("受注コード").ToString
                'チャネルコード
                parRequest(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                'OR受注コード
                parRequest(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注サイト
                parRequest(i).sRequestSite = pDataReader("受注サイト").ToString
                '受注媒体
                parRequest(i).sRequestMedia = pDataReader("受注媒体").ToString
                'モバイルフラグ
                parRequest(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                'アフェリエイトフラグ
                parRequest(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                '受注日
                parRequest(i).sRequestDate = pDataReader("受注日").ToString
                '受注時間
                parRequest(i).sRequestTime = pDataReader("受注時間").ToString
                '出荷先－会社名
                parRequest(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                '出荷先－支店名
                parRequest(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                '出荷先－姓カナ
                parRequest(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                '出荷先－名カナ
                parRequest(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                '出荷先－住所１カナ
                parRequest(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                '出荷先－住所２カナ
                parRequest(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                '出荷先－住所市区町村カナ
                parRequest(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                '出荷先－都道府県カナ
                parRequest(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                '出荷先－姓
                parRequest(i).sShip1stName = pDataReader("出荷先－姓").ToString
                '出荷先－名
                parRequest(i).sShip2ndName = pDataReader("出荷先－名").ToString
                '出荷先－住所１
                parRequest(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                '出荷先－住所２
                parRequest(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                '出荷先－住所市区町村
                parRequest(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                '出荷先－都道府県
                parRequest(i).sShipState = pDataReader("出荷先－都道府県").ToString
                '出荷先－国名
                parRequest(i).sShipCountry = pDataReader("出荷先－国名").ToString
                '出荷先－郵便番号1
                parRequest(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                '出荷先－郵便番号2
                parRequest(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                '出荷先－電話番号
                parRequest(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                '請求先－会社名
                parRequest(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                '請求先－支店名
                parRequest(i).sBillDivName = pDataReader("請求先－支店名").ToString
                '請求先－姓カナ
                parRequest(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                '請求先－名カナ
                parRequest(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                '請求先－住所１カナ
                parRequest(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                '請求先－住所２カナ
                parRequest(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                '請求先－住所市区町村カナ
                parRequest(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                '請求先－都道府県カナ
                parRequest(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                '請求先－姓
                parRequest(i).sBill1stName = pDataReader("請求先－姓").ToString
                '請求先－名
                parRequest(i).sBill2ndName = pDataReader("請求先－名").ToString
                '請求先－住所１
                parRequest(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                '請求先－住所２
                parRequest(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                '請求先－住所市区町村
                parRequest(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                '請求先－都道府県
                parRequest(i).sBillState = pDataReader("請求先－都道府県").ToString
                '請求先－国名
                parRequest(i).sBillCountry = pDataReader("請求先－国名").ToString
                '請求先－郵便番号1
                parRequest(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                '請求先－郵便番号2
                parRequest(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                '請求先－電話番号
                parRequest(i).sBillTel = pDataReader("請求先－電話番号").ToString
                'メールアドレス
                parRequest(i).sMailAdderss = pDataReader("メールアドレス").ToString
                'コメント
                parRequest(i).sComment = pDataReader("コメント").ToString
                'ステータス
                parRequest(i).sStatus = pDataReader("ステータス").ToString
                'エントリーポイント
                parRequest(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                'リンク先
                parRequest(i).sLink = pDataReader("リンク先").ToString
                'カード支払方法
                parRequest(i).sCardPayment = pDataReader("カード支払方法").ToString
                '配達希望日
                parRequest(i).sShipRequestDate = pDataReader("配達希望日").ToString
                '配達希望時間
                parRequest(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                '配達希望メモ
                parRequest(i).sShipMemo = pDataReader("配達希望メモ").ToString
                '配送業者
                parRequest(i).sShipCorp = pDataReader("配送業者").ToString
                'チャネル支払コード
                parRequest(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                'ギフト梱包希望
                parRequest(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                parRequest(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                '受注商品税抜金額
                parRequest(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                '送料
                parRequest(i).sShippingCharge = CLng(pDataReader("送料"))
                '手数料
                parRequest(i).sPaymentCharge = CLng(pDataReader("手数料"))
                '値引き
                parRequest(i).sDiscount = CLng(pDataReader("値引き"))
                'ポイント値引き
                parRequest(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                '受注税抜金額
                parRequest(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                '受注消費税額
                parRequest(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                '受注税込金額
                parRequest(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                'ギフト梱包材料
                parRequest(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                parRequest(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                'のし希望
                parRequest(i).sNoshiType = pDataReader("のし希望").ToString
                'のし記載内容
                parRequest(i).sNoshiName = pDataReader("のし記載内容").ToString
                '注文者性別
                parRequest(i).sBillSex = pDataReader("注文者性別").ToString
                '注文者誕生日
                parRequest(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                '楽天バンク決済手数料
                parRequest(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                '受注伝票出力フラグ
                parRequest(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                '受注担当者コード
                parRequest(i).sStaffCode = pDataReader("受注担当者コード").ToString
                '登録日
                parRequest(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parRequest(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRequest(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parRequest(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Function insertRequestMst2(ByRef parRequestInfo As Hashtable, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strInsert As String
        Dim rowCnt As Integer

        'SQL文の設定
        strInsert = "INSERT INTO 受注情報データTMP (" & _
                        "受注コード, " & _
                        "チャネルコード, " & _
                        "OR受注コード, " & _
                        "受注サイト, " & _
                        "受注媒体, " & _
                        "モバイルフラグ, " & _
                        "アフェリエイトフラグ, " & _
                        "受注日, " & _
                        "受注時間, " & _
                        "出荷先－会社名, " & _
                        "出荷先－支店名, " & _
                        "出荷先－姓カナ, " & _
                        "出荷先－名カナ, " & _
                        "出荷先－住所１カナ, " & _
                        "出荷先－住所２カナ, " & _
                        "出荷先－住所市区町村カナ, " & _
                        "出荷先－都道府県カナ, " & _
                        "出荷先－姓, " & _
                        "出荷先－名, " & _
                        "出荷先－住所１, " & _
                        "出荷先－住所２, " & _
                        "出荷先－住所市区町村, " & _
                        "出荷先－都道府県, " & _
                        "出荷先－国名, " & _
                        "出荷先－郵便番号1, " & _
                        "出荷先－郵便番号2, " & _
                        "出荷先－電話番号, " & _
                        "請求先－会社名, " & _
                        "請求先－支店名, " & _
                        "請求先－姓カナ, " & _
                        "請求先－名カナ, " & _
                        "請求先－住所１カナ, " & _
                        "請求先－住所２カナ, " & _
                        "請求先－住所市区町村カナ, " & _
                        "請求先－都道府県カナ, " & _
                        "請求先－姓, " & _
                        "請求先－名, " & _
                        "請求先－住所１, " & _
                        "請求先－住所２, " & _
                        "請求先－住所市区町村, " & _
                        "請求先－都道府県, " & _
                        "請求先－国名, " & _
                        "請求先－郵便番号1, " & _
                        "請求先－郵便番号2, " & _
                        "請求先－電話番号, " & _
                        "メールアドレス, " & _
                        "コメント, " & _
                        "ステータス, " & _
                        "エントリーポイント, " & _
                        "リンク先, " & _
                        "カード支払方法, " & _
                        "配達希望日, " & _
                        "配達希望時間, " & _
                        "配達希望メモ, " & _
                        "配送業者, " & _
                        "チャネル支払コード, " & _
                        "ギフト梱包希望, " & _
                        "取得ポイント数, " & _
                        "受注商品税抜金額, " & _
                        "送料, " & _
                        "手数料, " & _
                        "値引き, " & _
                        "ポイント値引き, " & _
                        "受注税抜金額, " & _
                        "受注消費税額, " & _
                        "受注税込金額, " & _
                        "ギフト梱包材料, " & _
                        "ギフト梱包料金, " & _
                        "のし希望, " & _
                        "のし記載内容, " & _
                        "注文者性別, " & _
                        "注文者誕生日, " & _
                        "楽天バンク決済手数料, " & _
                        "受注伝票出力フラグ, " & _
                        "受注担当者コード, " & _
                        "登録日, " & _
                        "登録時間, " & _
                        "最終更新日, " & _
                        "最終更新時間" & _
                    ") VALUES (" & _
                        "@RequestCode, " & _
                        "@ChannelCode, " & _
                        "@ORRequestCode, " & _
                        "@RequestSite, " & _
                        "@RequestMedia, " & _
                        "@MobileFlg, " & _
                        "@AffiliateFlg, " & _
                        "@RequestDate, " & _
                        "@RequestTime, " & _
                        "@ShipCorpName, " & _
                        "@ShipDivName, " & _
                        "@ShipKanaShip1stName, " & _
                        "@ShipKanaShip2ndName, " & _
                        "@ShipKanaAdder1, " & _
                        "@ShipKanaAdder2, " & _
                        "@ShipKanaCity, " & _
                        "@ShipKanaState, " & _
                        "@Ship1stName, " & _
                        "@Ship2ndName, " & _
                        "@ShipAdder1, " & _
                        "@ShipAdder2, " & _
                        "@ShipCity, " & _
                        "@ShipState, " & _
                        "@ShipCountry, " & _
                        "@ShipPostCode1, " & _
                        "@ShipPostCode2, " & _
                        "@ShipTel, " & _
                        "@BillCorpName, " & _
                        "@BillDivName, " & _
                        "@BillKanaBill1stName, " & _
                        "@BillKanaBill2ndName, " & _
                        "@BillKanaAdder1, " & _
                        "@BillKanaAdder2, " & _
                        "@BillKanaCity, " & _
                        "@BillKanaState, " & _
                        "@Bill1stName, " & _
                        "@Bill2ndName, " & _
                        "@BillAdder1, " & _
                        "@BillAdder2, " & _
                        "@BillCity, " & _
                        "@BillState, " & _
                        "@BillCountry, " & _
                        "@BillPostCode1, " & _
                        "@BillPostCode2, " & _
                        "@BillTel, " & _
                        "@MailAdderss, " & _
                        "@Comment, " & _
                        "@Status, " & _
                        "@EntryPoint, " & _
                        "@Link, " & _
                        "@CardPayment, " & _
                        "@ShipRequestDate, " & _
                        "@ShipRequestTime, " & _
                        "@ShipMemo, " & _
                        "@ShipCorp, " & _
                        "@ChannelPaymentCode, " & _
                        "@GiftRequest, " & _
                        "@GetPoint, " & _
                        "@NoTaxTotalProductPrice, " & _
                        "@ShippingCharge, " & _
                        "@PaymentCharge, " & _
                        "@Discount, " & _
                        "@PointDisCount, " & _
                        "@NoTaxTotalPrice, " & _
                        "@TaxTotal, " & _
                        "@TotalPrice, " & _
                        "@GiftWrapKind, " & _
                        "@GiftWrapKindPrice, " & _
                        "@NoshiType, " & _
                        "@NoshiName, " & _
                        "@BillSex, " & _
                        "@BillBirthDay, " & _
                        "@RakutenCharge, " & _
                        "@PrintFlg, " & _
                        "@StaffCode, " & _
                        "@CreateDate, " & _
                        "@CreateTime, " & _
                        "@UpdateDate, " & _
                        "@UpdateTime" & _
                    ")"
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            'パラメータの設定()
            '***********************
            For i = 0 To columnNames.Length - 1
                If parRequestInfo.ContainsKey(columnNames(i)) Then
                    ' ダウンロードカラムマスタで定義しているDB項目について
                    Dim ht As Hashtable = metaInfo(columnNames(i))
                    Dim dataType As String = CType(ht("DataType"), String)
                    Dim columnSize As Integer = CType(ht("ColumnSize"), Integer)

                    Select Case dataType
                        Case "System.String"
                            Dim s As String = parRequestInfo(columnNames(i))
                            If s Is Nothing Then s = ""
                            If s.Length > columnSize Then
                                s = Left(s, columnSize)
                                Dim msg As String = "DBカラムサイズオーバーのため値を切捨て (注文番号：" & parRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parRequestInfo(columnNames(i)) & " → " & s
                                l.write(msg)
                            End If
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Char))
                            pCommand.Parameters(paramNames(i)).Value = s
                        Case "System.Int16"
                            Dim s As String = parRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim n16 As Integer
                            Try
                                n16 = CInt(s)
                            Catch ex As Exception
                                n16 = 0
                                Dim msg As String = "文字列から数値への変換エラー：値を0へ置換え (注文番号：" & parRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parRequestInfo(columnNames(i)) & " → 0"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = n16
                        Case "System.Int32"
                            Dim s As String = parRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim n32 As Long
                            Try
                                n32 = CLng(s)
                            Catch ex As Exception
                                n32 = 0L
                                Dim msg As String = "文字列から数値への変換エラー：値を0へ置換え (注文番号：" & parRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parRequestInfo(columnNames(i)) & " → 0"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = n32
                        Case "System.Boolean"
                            Dim s As String = parRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim b As Boolean
                            Try
                                b = CBool(parRequestInfo(columnNames(i)))
                            Catch ex As Exception
                                b = False
                                Dim msg As String = "文字列からブール値への変換エラー：値をFALSEへ置換え (注文番号：" & parRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parRequestInfo(columnNames(i)) & " → FALSE"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Boolean))
                            pCommand.Parameters(paramNames(i)).Value = b
                        Case Else
                            Throw New Exception("システムエラー(非対応のデータ型が当該テーブルに定義されています)")
                    End Select
                Else
                    ' ダウンロードカラムマスタで未定義のDB項目について
                    Dim ht As Hashtable = metaInfo(columnNames(i))
                    Dim dataType As String = CType(ht("DataType"), String)
                    Select Case dataType
                        Case "System.String"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Char))
                            pCommand.Parameters(paramNames(i)).Value = ""
                        Case "System.Int16"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = 0
                        Case "System.Int32"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = 0L
                        Case "System.Boolean"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Boolean))
                            pCommand.Parameters(paramNames(i)).Value = False
                        Case Else
                            Throw New Exception("システムエラー(非対応のデータ型が当該テーブルに定義されています)")
                    End Select
                End If
            Next

            '受注情報データ挿入処理実行
            rowCnt = pCommand.ExecuteNonQuery()
            Return rowCnt

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.insertRequestMst2)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：受注情報データTMPから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getMaxRequestCode(ByVal KeyChannelCode As Integer, ByVal KeyDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxRequestNo As Long

        strSelect = ""

        Try

            strSelect = "SELECT 受注コード FROM 受注情報データTMP " & _
                        "WHERE 受注コード Like ""992" & String.Format("{0:0}", KeyChannelCode) & KeyDate & "%"" " & _
                        "ORDER BY 受注コード DESC"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxRequestNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("受注コード")) = True Then
                    MaxRequestNo = 0
                Else
                    MaxRequestNo = CLng(Mid(pDataReader("受注コード").ToString, 11, 2))
                    If MaxRequestNo = 99 Then
                        MaxRequestNo = -1
                    Else
                        MaxRequestNo += 1
                    End If
                End If

            End If
            getMaxRequestCode = MaxRequestNo

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.getMaxRequestCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：受注情報データTMPから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getPrice(ByVal KeyRequestCode As String, ByVal KeyFieldName As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxRequestNo As Long

        strSelect = ""

        Try

            strSelect = "SELECT " & KeyFieldName & " FROM 受注情報データTMP " & _
                        "WHERE 受注コード = """ & KeyRequestCode & """ "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxRequestNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader(0)) = True Then
                    getPrice = 0
                Else
                    getPrice = pDataReader(0)
                End If

            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.getPrice)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Function deleteSetData(ByVal KeyORRequestCode As String, _
                                     ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim result As Integer = 0
        Dim strSQL As String
        Try
            strSQL = "DELETE FROM 受注情報明細データTMP " & _
                     "WHERE OR受注コード=""" & KeyORRequestCode & """ "
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran
            pCommand.CommandText = strSQL
            result = pCommand.ExecuteNonQuery()
            If result > 0 Then
                strSQL = "DELETE FROM 受注情報データTMP " & _
                         "WHERE OR受注コード=""" & KeyORRequestCode & """ "
                pCommand = pConn.CreateCommand
                pCommand.Transaction = Tran
                pCommand.CommandText = strSQL
                result = pCommand.ExecuteNonQuery()
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.deleteForRewrite)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Sub setMetaInfo(ByRef Tran As System.Data.OleDb.OleDbTransaction)
        Dim strSelect As String
        Dim dt As DataTable

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT TOP 1 * FROM 受注情報データTMP "

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()

            '当該テーブルのメタ情報を取得
            dt = pDataReader.GetSchemaTable()

            metaInfo = New Hashtable

            For Each row As DataRow In dt.Rows
                Dim key As String = ""
                Dim ht As New Hashtable
                For Each col As DataColumn In dt.Columns
                    Select Case col.ColumnName
                        Case "ColumnName"
                            key = row(col).ToString()
                        Case "ColumnSize"
                            ht.Add("ColumnSize", row(col).ToString())
                        Case "DataType"
                            ht.Add("DataType", row(col).ToString())
                    End Select
                Next
                metaInfo.Add(key, ht)
            Next

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.setMetaInfo)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            dt = Nothing
        End Try

    End Sub

    Public Sub setLogWriter(ByRef l As cLog)
        Me.l = l
    End Sub

    Public Function updateRequestMst2(ByVal KeyRequestCode As String, _
                                      ByVal FieldName As String, _
                                      ByVal Value As Integer, _
                                      ByVal Ope As String, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                    ) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String
        Dim strSelect As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        'SQL文の設定
        If Ope <> Nothing Then
            strSelect = "SELECT " & FieldName & " FROM 受注情報データTMP WHERE 受注コード = """ & KeyRequestCode & """"
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()

            Select Case Ope
                Case "+"
                    Value = CLng(pDataReader(0)) + Value
                Case "-"
                    Value = CLng(pDataReader(0)) - Value
                Case "*"
                    Value = CLng(pDataReader(0)) * Value
                Case "/"
                    Value = CLng(pDataReader(0)) / Value
            End Select
        End If

        pDataReader.Close
        strUpdate = "UPDATE 受注情報データTMP SET "

        strUpdate = strUpdate & _
                        FieldName & " = " & Value & ", "

        strUpdate = strUpdate & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                        "WHERE 受注情報データTMP.受注コード= """ & KeyRequestCode & """ "

        Try
            ''コマンドオブジェクトの生成
            'pCommand = pConn.CreateCommand()
            'pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'チャネルマスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                Return True
            Else
                '更新するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.updateRequestMst2)", Nothing, Nothing, oExcept.ToString)
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
    Public Function updateHeaderPrice(ByRef KeyConf() As cStructureLib.sConfig, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                ) As Boolean

        Dim RecordCount As Integer
        Dim strUpdate As String
        Dim strSelect As String
        Dim pNoTaxProductPrice As Long
        Dim pPostagePrice As Long
        Dim pFeePrice As Long
        Dim pDiscountPrice As Long
        Dim pPointDiscountPrice As Long
        Dim pNoTaxPrice As Long
        Dim pTaxPrice As Long
        Dim pPrice As Long
        Dim pRequestCode As String
        Dim rCommand As OleDb.OleDbCommand
        Dim rDatareader As OleDb.OleDbDataReader

        rDatareader = Nothing

        Try
            'コマンドオブジェクトの生成
            rCommand = pConn.CreateCommand()
            rCommand.Transaction = Tran

            '-----------------------
            '   商品代金合計の算出
            '-----------------------

            'ヘッダーの抽出
            strSelect = "SELECT " & _
                            "受注コード, " & _
                            "受注税込金額, " & _
                            "送料, " & _
                            "手数料, " & _
                            "値引き, " & _
                            "ポイント値引き " & _
                        "FROM " & _
                            "受注情報データTMP "

            'SQL文の設定
            rCommand.CommandText = strSelect

            rDatareader = rCommand.ExecuteReader()

            RecordCount = 0

            While rDatareader.Read()

                pRequestCode = rDatareader("受注コード")

                If IsDBNull(rDatareader("受注税込金額")) = True Then
                    pPrice = 0
                Else
                    pPrice = CLng(rDatareader("受注税込金額"))
                End If
                If IsDBNull(rDatareader("送料")) = True Then
                    pPostagePrice = 0
                Else
                    pPostagePrice = CLng(rDatareader("送料"))
                End If
                If IsDBNull(rDatareader("手数料")) = True Then
                    pFeePrice = 0
                Else
                    pFeePrice = CLng(rDatareader("手数料"))
                End If
                If IsDBNull(rDatareader("値引き")) = True Then
                    pDiscountPrice = 0
                Else
                    pDiscountPrice = CLng(rDatareader("値引き"))
                End If
                If IsDBNull(rDatareader("ポイント値引き")) = True Then
                    pPointDiscountPrice = 0
                Else
                    pPointDiscountPrice = CLng(rDatareader("ポイント値引き"))
                End If

                pCommand = pConn.CreateCommand()
                pCommand.Transaction = Tran

                '明細の集計
                strSelect = "SELECT " & _
                                "Sum(受注情報明細データTMP.受注税抜金額) AS 受注税抜金額の合計 " & _
                            "FROM " & _
                                "受注情報明細データTMP " & _
                            "WHERE " & _
                                "受注情報明細データTMP.チャネル商品コード <> """" " & _
                            "GROUP BY " & _
                                "受注情報明細データTMP.受注コード " & _
                            "HAVING " & _
                                "(受注情報明細データTMP.受注コード = """ & pRequestCode & """) "


                'SQL文の設定
                pCommand.CommandText = strSelect

                pDataReader = pCommand.ExecuteReader()

                RecordCount = 0

                pDataReader.Read()

                '2016.05.25 K.Oikawa s
                '上記SQLの結果が取得できなかった場合処理追加
                'If IsDBNull(pDataReader("受注税抜金額の合計")) = True Then
                '   pNoTaxProductPrice = CLng(pDataReader("受注税抜金額の合計"))
                'End If
                If pDataReader.HasRows = False Then
                    pNoTaxProductPrice = 0
                Else
                    pNoTaxProductPrice = CLng(pDataReader("受注税抜金額の合計"))
                End If
                '2016.05.25 K.Oikawa e

                pDataReader.Close()

                If pDiscountPrice > 0 Then
                    pDiscountPrice = pDiscountPrice
                End If
                If pPointDiscountPrice > 0 Then
                    pPointDiscountPrice = pPointDiscountPrice
                End If

                If pPrice = 0 Then
                    pPrice = oTool.BeforeToAfterTax(pNoTaxProductPrice + pPostagePrice + pFeePrice + pDiscountPrice + pPointDiscountPrice, KeyConf(0).sTax, KeyConf(0).sFracProc)
                End If
                pNoTaxPrice = pNoTaxProductPrice + pPostagePrice + pFeePrice + pDiscountPrice + pPointDiscountPrice
                pTaxPrice = pPrice - pNoTaxPrice

                'SQL文の設定
                strUpdate = "UPDATE 受注情報データTMP SET " & _
                                "受注商品税抜金額 = " & pNoTaxProductPrice & ", " & _
                                "受注税抜金額 = " & pNoTaxPrice & ", " & _
                                "受注消費税額 = " & pTaxPrice & ", " & _
                                "受注税込金額 = " & pPrice & ", " & _
                                "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 受注情報データTMP.受注コード= """ & pRequestCode & """ "


                'SQL文の設定
                pCommand.CommandText = strUpdate

                'チャネルマスタ更新SQL文実行
                RecordCount = pCommand.ExecuteNonQuery()
            End While

            '更新成功
            Return True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.updatePrpductPrice)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                rDatareader.Close()
                pDataReader.Close()
            End If
        End Try
    End Function
    Public Function AmazonHeaderupdate(ByVal KeyORRequestCode As String, _
                                       ByRef pConf() As cStructureLib.sConfig, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                ) As Boolean

        Dim RecordCount As Integer
        Dim strUpdate As String
        Dim strSelect As String
        Dim pNoTaxProductPrice As Long
        Dim pDiscountPrice As Long
        Dim pTotalProductPrice As Long
        Dim pitemDiscountPrice As Long
        Dim pPostagePrice As Long
        Dim pFeePrice As Long
        Dim pPointDiscountPrice As Long
        Dim pNoTaxPrice As Long
        Dim pPrice As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            '------------------------------
            '   購入商品金額の集計
            '------------------------------
            strSelect = "SELECT " & _
                            "受注情報明細データTMP.受注コード, " & _
                            "Sum(受注情報明細データTMP.受注税込金額) AS 受注税込金額の合計 " & _
                        "FROM " & _
                            "受注情報明細データTMP " & _
                        "WHERE " & _
                            "受注情報明細データTMP.チャネル商品コード Not Like "" * ZZZZZ * "" " & _
                        "GROUP BY " & _
                            "受注情報明細データTMP.受注コード " & _
                        "HAVING " & _
                            "受注情報明細データTMP.OR受注コード =""" & KeyORRequestCode & """ "


            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()
            If IsDBNull(pDataReader("受注税込金額の合計")) = True Then
                pTotalProductPrice = 0
            Else
                pTotalProductPrice = CLng(pDataReader("受注税込金額の合計"))
            End If

            '------------------------------
            '   購入プロモーションの集計
            '------------------------------
            strSelect = "SELECT " & _
                            "受注情報明細データTMP.受注コード, " & _
                            "受注情報明細データTMP.チャネル商品コード, " & _
                            "Sum(受注情報明細データTMP.受注税抜金額) AS 購入プロモーション計 " & _
                        "FROM " & _
                            "受注情報明細データTMP " & _
                        "GROUP BY " & _
                            "受注情報明細データTMP.受注コード, " & _
                            "受注情報明細データTMP.チャネル商品コード " & _
                        "HAVING " & _
                            "受注情報明細データTMP.OR受注コード)=""" & KeyORRequestCode & """ " & _
                            "AND 受注情報明細データTMP.チャネル商品コード)=""ZZZZZ-01"""

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()
            If IsDBNull(pDataReader("購入プロモーション計")) = True Then
                pitemDiscountPrice = 0
            Else
                pitemDiscountPrice = CLng(pDataReader("購入プロモーション計"))
            End If

            '------------------------------
            '   配送プロモーションの集計
            '------------------------------
            strSelect = "SELECT " & _
                            "受注情報データTMP.受注コード, " & _
                            "受注情報明細データTMP.チャネル商品コード, " & _
                            "受注情報データTMP.送料, " & _
                            "Sum(受注情報明細データTMP.受注税抜金額) AS 配送プロモーション計, " & _
                            "[受注情報データTMP].[送料]+Sum([受注情報明細データTMP].[受注税抜金額]) AS 更新送料 " & _
                        "FROM " & _
                            "受注情報データTMP LEFT JOIN 受注情報明細データTMP " & _
                            "ON 受注情報データTMP.受注コード = 受注情報明細データTMP.受注コード " & _
                        "GROUP BY " & _
                            "受注情報データTMP.受注コード, " & _
                            "受注情報明細データTMP.チャネル商品コード, " & _
                            "受注情報データTMP.送料 " & _
                        "HAVING " & _
                            "(((受注情報データTMP.OR受注コード)=""" & KeyORRequestCode & """) " & _
                            "AND ((受注情報明細データTMP.チャネル商品コード)=""ZZZZZ-02""))"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()
            If IsDBNull(pDataReader("更新送料")) = True Then
                pPostagePrice = 0
            Else
                pPostagePrice = oTool.AfterToBeforeTax(CLng(pDataReader("更新送料")), pConf(0).sTax, pConf(0).sFracProc)
            End If

            '更新データ作成
            pNoTaxProductPrice = oTool.AfterToBeforeTax(pTotalProductPrice, pConf(0).sTax, pConf(0).sFracProc)

            'SQL文の設定
            strUpdate = "UPDATE 受注情報データTMP SET " & _
                            "受注商品税抜金額 = " & pNoTaxProductPrice & ", " & _
                            "送料 = " & oTool.AfterToBeforeTax(pPostagePrice, pConf(0).sTax, pConf(0).sFracProc) & ", " & _
                            "手数料 = " & (pNoTaxPrice - pPointDiscountPrice - pDiscountPrice - pFeePrice - pPostagePrice - pNoTaxProductPrice) * -1 & ", " & _
                            "値引き = " & (pNoTaxPrice - pPointDiscountPrice - pDiscountPrice - pFeePrice - pPostagePrice - pNoTaxProductPrice) * -1 & ", " & _
                            "ポイント値引き = " & (pNoTaxPrice - pPointDiscountPrice - pDiscountPrice - pFeePrice - pPostagePrice - pNoTaxProductPrice) * -1 & ", " & _
                            "受注税抜金額 = " & pNoTaxPrice & ", " & _
                            "受注消費税額 = " & pPrice - pNoTaxPrice & ", " & _
                            "受注税込金額 = " & pTotalProductPrice & ", " & _
                            "値引き = " & (pNoTaxPrice - pPointDiscountPrice - pDiscountPrice - pFeePrice - pPostagePrice - pNoTaxProductPrice) * -1 & ", " & _
                            "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                        "WHERE 受注情報データTMP.受注コード= """ & KeyORRequestCode & """ "


            'SQL文の設定
            pCommand.CommandText = strUpdate

            'チャネルマスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            If RecordCount > 0 Then
                '更新成功
                Return True
            Else
                '更新するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestTMPDBIO.updatePrpductPrice)", Nothing, Nothing, oExcept.ToString)
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





    '-------------------------------------------------------------------------------
    '　機能：受注情報データから最後に登録作業を行った日時を取得する
    '-------------------------------------------------------------------------------
    Public Function getMaxRegisteredDate(ByRef Tran As System.Data.OleDb.OleDbTransaction) As String
        Dim strSelect As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT IIf(IsNull(Max(日時)),""20160801000000"",Max(日時)) AS 登録日時 " & _
                        "FROM ( " & _
                            "SELECT Format(登録日, ""yyyymmdd"") &Format(登録時間, ""hhnnss"") AS 日時 FROM 受注情報データ WHERE チャネルコード = 1 AND 登録日 > Date()-2 " & _
                            "UNION " & _
                            "SELECT Format(登録日, ""yyyymmdd"") &Format(登録時間, ""hhnnss"") AS 日時 FROM 受注情報データTMP WHERE チャネルコード = 1 AND 登録日 > Date()-2 " & _
                        ")"

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()
            '商品コード
            getMaxRegisteredDate = pDataReader("登録日時").ToString

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.getMaxRegisteredDate)", Nothing, Nothing, oExcept.ToString)
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
