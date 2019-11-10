
Public Class cViewRequestDataFullDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Private oTool As cTool

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader

        oTool = New cTool
    End Sub


    '----------------------------------------------------------------------
    '　機能：受注情報データから該当受注番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getRequest(ByRef parViewRequestDataFull() As cStructureLib.sViewRequestDataFull, _
                                 ByVal KeyRequestNumber As String, _
                                 ByVal KeyPhoneNumber As String, _
                                 ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim Maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT " & _
                        "受注情報データ.受注コード, " & _
                         "受注情報データ.チャネルコード, " & _
                         "受注情報データ.OR受注コード, " & _
                         "受注情報データ.受注サイト, " & _
                         "受注情報データ.受注媒体, " & _
                         "受注情報データ.モバイルフラグ, " & _
                         "受注情報データ.アフェリエイトフラグ, " & _
                         "受注情報データ.受注日, " & _
                         "受注情報データ.受注時間, " & _
                         "受注情報データ.出荷先－会社名, " & _
                         "受注情報データ.出荷先－支店名, " & _
                         "受注情報データ.出荷先－姓カナ, " & _
                         "受注情報データ.出荷先－名カナ, " & _
                         "受注情報データ.出荷先－住所１カナ, " & _
                         "受注情報データ.出荷先－住所２カナ, " & _
                         "受注情報データ.出荷先－住所市区町村カナ, " & _
                         "受注情報データ.出荷先－都道府県カナ, " & _
                         "受注情報データ.出荷先－姓, " & _
                         "受注情報データ.出荷先－名, " & _
                         "受注情報データ.出荷先－住所１, " & _
                         "受注情報データ.出荷先－住所２, " & _
                         "受注情報データ.出荷先－住所市区町村, " & _
                         "受注情報データ.出荷先－都道府県, " & _
                         "受注情報データ.出荷先－国名, " & _
                         "受注情報データ.出荷先－郵便番号1, " & _
                         "受注情報データ.出荷先－郵便番号2, " & _
                         "受注情報データ.出荷先－電話番号, " & _
                         "受注情報データ.請求先－会社名, " & _
                         "受注情報データ.請求先－支店名, " & _
                         "受注情報データ.請求先－姓カナ, " & _
                         "受注情報データ.請求先－名カナ, " & _
                         "受注情報データ.請求先－住所１カナ, " & _
                         "受注情報データ.請求先－住所２カナ, " & _
                         "受注情報データ.請求先－住所市区町村カナ, " & _
                         "受注情報データ.請求先－都道府県カナ, " & _
                         "受注情報データ.請求先－姓, " & _
                         "受注情報データ.請求先－名, " & _
                         "受注情報データ.請求先－住所１, " & _
                         "受注情報データ.請求先－住所２, " & _
                         "受注情報データ.請求先－住所市区町村, " & _
                         "受注情報データ.請求先－都道府県, " & _
                         "受注情報データ.請求先－国名, " & _
                         "受注情報データ.請求先－郵便番号1, " & _
                         "受注情報データ.請求先－郵便番号2, " & _
                         "受注情報データ.請求先－電話番号, " & _
                         "受注情報データ.メールアドレス, " & _
                         "受注情報データ.コメント, " & _
                         "受注情報データ.ステータス, " & _
                         "受注情報データ.エントリーポイント, " & _
                         "受注情報データ.リンク先, " & _
                         "受注情報データ.カード支払方法, " & _
                         "受注情報データ.配達希望日, " & _
                         "受注情報データ.配達希望時間, " & _
                         "受注情報データ.配達希望メモ, " & _
                         "受注情報データ.配送業者, " & _
                         "受注情報データ.チャネル支払コード, " & _
                         "受注情報データ.ギフト梱包希望, " & _
                         "受注情報データ.取得ポイント数, " & _
                         "受注情報データ.受注商品税抜金額, " & _
                         "受注情報データ.送料, " & _
                         "受注情報データ.手数料, " & _
                         "受注情報データ.値引き, " & _
                         "受注情報データ.ポイント値引き, " & _
                         "受注情報データ.受注税抜金額, " & _
                         "受注情報データ.受注消費税額, " & _
                         "受注情報データ.受注税込金額, " & _
                         "受注情報データ.ギフト梱包材料, " & _
                         "受注情報データ.ギフト梱包料金, " & _
                         "受注情報データ.のし希望, " & _
                         "受注情報データ.のし記載内容, " & _
                         "受注情報データ.注文者性別, " & _
                         "受注情報データ.注文者誕生日, " & _
                         "受注情報データ.楽天バンク決済手数料, " & _
                         "受注情報データ.受注担当者コード, " & _
                         "受注情報データ.受注伝票出力フラグ, " & _
                         "受注情報データ.受注担当者コード, " & _
                         "出荷情報データ.出荷日, " & _
                         "出荷情報データ.荷物受渡番号, " & _
                         "出荷情報データ.出荷先電話番号, " & _
                         "出荷情報データ.出荷先郵便番号, " & _
                         "出荷情報データ.出荷先住所1, " & _
                         "出荷情報データ.出荷先住所2, " & _
                         "出荷情報データ.出荷先住所3, " & _
                         "出荷情報データ.出荷先姓, " & _
                         "出荷情報データ.出荷先名, " & _
                         "出荷情報データ.配達日, " & _
                         "出荷情報データ.配達指定時間帯, " & _
                         "出荷情報データ.配達指定時間, " & _
                         "出荷情報データ.配送業者コード, " & _
                         "出荷情報データ.営業店コード, " & _
                         "出荷情報データ.代引金額, " & _
                         "出荷情報データ.出荷税抜商品金額, " & _
                         "出荷情報データ.送料 AS 出荷時－送料, " & _
                         "出荷情報データ.手数料 AS 出荷時－手数料, " & _
                         "出荷情報データ.値引き AS 出荷時－値引き, " & _
                         "出荷情報データ.ポイント値引き AS 出荷時－ポイント値引き, " & _
                         "出荷情報データ.出荷税抜金額, " & _
                         "出荷情報データ.出荷消費税額, " & _
                         "出荷情報データ.出荷税込金額, " & _
                         "出荷情報データ.荷姿コード, " & _
                         "出荷情報データ.支払方法コード, " & _
                         "出荷情報データ.決済種別, " & _
                         "出荷情報データ.便種スピード, " & _
                         "出荷情報データ.便種商品, " & _
                         "出荷情報データ.指定シール1, " & _
                         "出荷情報データ.指定シール2, " & _
                         "出荷情報データ.指定シール3, " & _
                         "出荷情報データ.元着区分, " & _
                         "出荷情報データ.出荷完了フラグ, " & _
                         "出荷情報データ.再出荷事由, " & _
                         "出荷情報データ.出荷メモ, " & _
                         "出荷情報データ.配送伝票CSV出力フラグ, " & _
                         "出荷情報データ.出荷担当者コード " & _
                    "FROM " & _
                        "(" & _
                            "(受注情報データ LEFT JOIN 受注情報明細データ ON 受注情報データ.受注コード = 受注情報明細データ.受注コード) " & _
                            "LEFT JOIN 出荷情報明細データ ON (受注情報明細データ.受注明細コード = 出荷情報明細データ.受注明細コード) " & _
                            "AND " & _
                            "(受注情報明細データ.受注コード = 出荷情報明細データ.受注コード)" & _
                        ") LEFT JOIN 出荷情報データ ON 受注情報明細データ.受注コード = 出荷情報データ.受注コード "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyRequestNumber <> Nothing Then
            Maxpc = 1
            pc = pc Or Maxpc
        End If
        If KeyPhoneNumber <> Nothing Then
            Maxpc = 2
            pc = pc Or Maxpc
        End If

        'パラメータ指定がある場合
        If Maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= Maxpc
                Select Case i And pc
                    Case 1  '受注コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.受注コード Like ""%" & KeyRequestNumber & "%"" "
                        scnt = scnt + 1

                    Case 2  '電話番号コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.請求先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "
                        strSelect = strSelect & "Or 受注情報データ.出荷先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "

                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        i = 0

        'SQL文の設定
        Try
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader

            i = 0

            While pDataReader.Read()

                ReDim Preserve parViewRequestDataFull(i)

                '受注コード
                parViewRequestDataFull(i).sRequestCode = pDataReader("受注コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parViewRequestDataFull(i).sChannelCode = 0
                Else
                    parViewRequestDataFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                parViewRequestDataFull(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注サイト
                parViewRequestDataFull(i).sRequestSite = pDataReader("受注サイト").ToString
                '受注媒体
                parViewRequestDataFull(i).sRequestMedia = pDataReader("受注媒体").ToString
                'モバイルフラグ
                parViewRequestDataFull(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                'アフェリエイトフラグ
                parViewRequestDataFull(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                '受注日
                parViewRequestDataFull(i).sRequestDate = pDataReader("受注日").ToString
                '受注時間
                parViewRequestDataFull(i).sRequestTime = pDataReader("受注時間").ToString
                '出荷先－会社名
                parViewRequestDataFull(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                '出荷先－支店名
                parViewRequestDataFull(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                '出荷先－姓カナ
                parViewRequestDataFull(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                '出荷先－名カナ
                parViewRequestDataFull(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                '出荷先－住所１カナ
                parViewRequestDataFull(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                '出荷先－住所２カナ
                parViewRequestDataFull(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                '出荷先－住所市区町村カナ
                parViewRequestDataFull(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                '出荷先－都道府県カナ
                parViewRequestDataFull(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                '出荷先－姓
                parViewRequestDataFull(i).sShip1stName = pDataReader("出荷先－姓").ToString
                '出荷先－名
                parViewRequestDataFull(i).sShip2ndName = pDataReader("出荷先－名").ToString
                '出荷先－住所１
                parViewRequestDataFull(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                '出荷先－住所２
                parViewRequestDataFull(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                '出荷先－住所市区町村
                parViewRequestDataFull(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                '出荷先－都道府県
                parViewRequestDataFull(i).sShipState = pDataReader("出荷先－都道府県").ToString
                '出荷先－国名
                parViewRequestDataFull(i).sShipCountry = pDataReader("出荷先－国名").ToString
                '出荷先－郵便番号1
                parViewRequestDataFull(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                '出荷先－郵便番号2
                parViewRequestDataFull(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                '出荷先－電話番号
                parViewRequestDataFull(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                '請求先－会社名
                parViewRequestDataFull(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                '請求先－支店名
                parViewRequestDataFull(i).sBillDivName = pDataReader("請求先－支店名").ToString
                '請求先－姓カナ
                parViewRequestDataFull(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                '請求先－名カナ
                parViewRequestDataFull(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                '請求先－住所１カナ
                parViewRequestDataFull(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                '請求先－住所２カナ
                parViewRequestDataFull(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                '請求先－住所市区町村カナ
                parViewRequestDataFull(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                '請求先－都道府県カナ
                parViewRequestDataFull(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                '請求先－姓
                parViewRequestDataFull(i).sBill1stName = pDataReader("請求先－姓").ToString
                '請求先－名
                parViewRequestDataFull(i).sBill2ndName = pDataReader("請求先－名").ToString
                '請求先－住所１
                parViewRequestDataFull(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                '請求先－住所２
                parViewRequestDataFull(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                '請求先－住所市区町村
                parViewRequestDataFull(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                '請求先－都道府県
                parViewRequestDataFull(i).sBillState = pDataReader("請求先－都道府県").ToString
                '請求先－国名
                parViewRequestDataFull(i).sBillCountry = pDataReader("請求先－国名").ToString
                '請求先－郵便番号1
                parViewRequestDataFull(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                '請求先－郵便番号2
                parViewRequestDataFull(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                '請求先－電話番号
                parViewRequestDataFull(i).sBillTel = pDataReader("請求先－電話番号").ToString
                'メールアドレス
                parViewRequestDataFull(i).sMailAdderss = pDataReader("メールアドレス").ToString
                'コメント
                parViewRequestDataFull(i).sComment = pDataReader("コメント").ToString
                'ステータス
                parViewRequestDataFull(i).sStatus = pDataReader("ステータス").ToString
                'エントリーポイント
                parViewRequestDataFull(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                'リンク先
                parViewRequestDataFull(i).sLink = pDataReader("リンク先").ToString
                'カード支払方法
                parViewRequestDataFull(i).sCardPayment = pDataReader("カード支払方法").ToString
                '配達希望日
                parViewRequestDataFull(i).sShipRequestDate = pDataReader("配達希望日").ToString
                '配達希望時間
                parViewRequestDataFull(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                '配達希望メモ
                parViewRequestDataFull(i).sShipMemo = pDataReader("配達希望メモ").ToString
                '配送業者
                parViewRequestDataFull(i).sShipCorp = pDataReader("配送業者").ToString
                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parViewRequestDataFull(i).sChannelPaymentCode = 0
                Else
                    parViewRequestDataFull(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'ギフト梱包希望
                parViewRequestDataFull(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                If IsDBNull(pDataReader("取得ポイント数")) = True Then
                    parViewRequestDataFull(i).sGetPoint = 0
                Else
                    parViewRequestDataFull(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                End If
                '受注商品税抜金額
                If IsDBNull(pDataReader("受注商品税抜金額")) = True Then
                    parViewRequestDataFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parViewRequestDataFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parViewRequestDataFull(i).sShippingCharge = 0
                Else
                    parViewRequestDataFull(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parViewRequestDataFull(i).sPaymentCharge = 0
                Else
                    parViewRequestDataFull(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parViewRequestDataFull(i).sDiscount = 0
                Else
                    parViewRequestDataFull(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parViewRequestDataFull(i).sPointDisCount = 0
                Else
                    parViewRequestDataFull(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parViewRequestDataFull(i).sNoTaxTotalPrice = 0
                Else
                    parViewRequestDataFull(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parViewRequestDataFull(i).sTaxTotal = 0
                Else
                    parViewRequestDataFull(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                End If
                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parViewRequestDataFull(i).sTotalPrice = 0
                Else
                    parViewRequestDataFull(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                End If
                'ギフト梱包材料
                parViewRequestDataFull(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                If IsDBNull(pDataReader("ギフト梱包料金")) = True Then
                    parViewRequestDataFull(i).sGiftWrapKindPrice = 0
                Else
                    parViewRequestDataFull(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                End If
                'のし希望
                parViewRequestDataFull(i).sNoshiType = pDataReader("のし希望").ToString
                'のし記載内容
                parViewRequestDataFull(i).sNoshiName = pDataReader("のし記載内容").ToString
                '注文者性別
                parViewRequestDataFull(i).sBillSex = pDataReader("注文者性別").ToString
                '注文者誕生日
                parViewRequestDataFull(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                '楽天バンク決済手数料
                If IsDBNull(pDataReader("楽天バンク決済手数料")) = True Then
                    parViewRequestDataFull(i).sRakutenCharge = 0
                Else
                    parViewRequestDataFull(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                End If
                '受注伝票出力フラグ
                If IsDBNull(pDataReader("受注伝票出力フラグ")) = True Then
                    parViewRequestDataFull(i).sPrintFlg = False
                Else
                    parViewRequestDataFull(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                End If
                '出荷日
                parViewRequestDataFull(i).sShipDate = pDataReader("出荷日").ToString
                '荷物受渡番号
                parViewRequestDataFull(i).sDeliveryNumber = pDataReader("荷物受渡番号").ToString
                '出荷先電話番号
                parViewRequestDataFull(i).sTel = pDataReader("出荷先電話番号").ToString
                '出荷先郵便番号
                parViewRequestDataFull(i).sPostalCode = pDataReader("出荷先郵便番号").ToString
                '出荷先住所1
                parViewRequestDataFull(i).sAddress1 = pDataReader("出荷先住所1").ToString
                '出荷先住所2
                parViewRequestDataFull(i).sAddress2 = pDataReader("出荷先住所2").ToString
                '出荷先住所3
                parViewRequestDataFull(i).sAddress3 = pDataReader("出荷先住所3").ToString
                '出荷先姓
                parViewRequestDataFull(i).sFirstName = pDataReader("出荷先姓").ToString
                '出荷先名
                parViewRequestDataFull(i).sLastName = pDataReader("出荷先名").ToString
                '配達日
                parViewRequestDataFull(i).sShipRequestDate = pDataReader("配達日").ToString
                '配達指定時間
                parViewRequestDataFull(i).sShipRequestTime = pDataReader("配達指定時間").ToString
                '配送業者コード
                If IsDBNull(pDataReader("配送業者コード")) = True Then
                    parViewRequestDataFull(i).sShipCorpCode = 0
                Else
                    parViewRequestDataFull(i).sShipCorpCode = CInt(pDataReader("配送業者コード"))
                End If
                '営業店コード
                parViewRequestDataFull(i).sShipOfficeCode = pDataReader("営業店コード").ToString
                '代引金額
                If IsDBNull(pDataReader("代引金額")) = True Then
                    parViewRequestDataFull(i).sDaibikiPrice = 0
                Else
                    parViewRequestDataFull(i).sDaibikiPrice = CLng(pDataReader("代引金額"))
                End If
                '出荷税抜商品金額
                If IsDBNull(pDataReader("出荷税抜商品金額")) = True Then
                    parViewRequestDataFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parViewRequestDataFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("出荷税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("出荷時－送料")) = True Then
                    parViewRequestDataFull(i).sShippingCharge = 0
                Else
                    parViewRequestDataFull(i).sShippingCharge = CLng(pDataReader("出荷時－送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("出荷時－手数料")) = True Then
                    parViewRequestDataFull(i).sPaymentCharge = 0
                Else
                    parViewRequestDataFull(i).sPaymentCharge = CLng(pDataReader("出荷時－手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("出荷時－値引き")) = True Then
                    parViewRequestDataFull(i).sDiscount = 0
                Else
                    parViewRequestDataFull(i).sDiscount = CLng(pDataReader("出荷時－値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("出荷時－ポイント値引き")) = True Then
                    parViewRequestDataFull(i).sPointDisCount = 0
                Else
                    parViewRequestDataFull(i).sPointDisCount = CLng(pDataReader("出荷時－ポイント値引き"))
                End If
                '出荷税抜金額
                If IsDBNull(pDataReader("出荷税抜金額")) = True Then
                    parViewRequestDataFull(i).sNoTaxTotalPrice = 0
                Else
                    parViewRequestDataFull(i).sNoTaxTotalPrice = CLng(pDataReader("出荷税抜金額"))
                End If
                '出荷消費税額
                If IsDBNull(pDataReader("出荷消費税額")) = True Then
                    parViewRequestDataFull(i).sTaxTotal = 0
                Else
                    parViewRequestDataFull(i).sTaxTotal = CLng(pDataReader("出荷消費税額"))
                End If
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewRequestDataFullDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getRequestSub(ByRef parViewRequestSubDataFull() As cStructureLib.sViewRequestSubDataFull, _
                             ByVal KeyRequestNumber As String, _
                             ByVal KeyPhoneNumber As String, _
                             ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim Maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT " & _
                        "受注情報データ.受注コード, " & _
                         "受注情報データ.チャネルコード, " & _
                         "受注情報明細データ.受注明細コード, " & _
                         "受注情報明細データ.商品コード, " & _
                         "受注情報明細データ.JANコード, " & _
                         "受注情報明細データ.商品名称, " & _
                         "受注情報明細データ.オプション名称, " & _
                         "受注情報明細データ.オプション値, " & _
                         "受注情報明細データ.定価, " & _
                         "受注情報明細データ.仕入単価, " & _
                         "受注情報明細データ.受注商品単価, " & _
                         "受注情報明細データ.受注数量, " & _
                         "受注情報明細データ.受注税抜金額, " & _
                         "受注情報明細データ.受注消費税額, " & _
                         "受注情報明細データ.受注税込金額, " & _
                         "受注情報明細データ.チャネル商品コード, " & _
                         "受注情報明細データ.チャネル商品名称, " & _
                         "受注情報明細データ.チャネルオプション, " & _
                         "出荷情報明細データ.出荷数量, " & _
                    "FROM " & _
                        "受注情報明細データ LEFT JOIN 出荷情報明細データ " & _
                        "ON (受注情報明細データ.受注明細コード = 出荷情報明細データ.受注明細コード) " & _
                        "AND (受注情報明細データ.受注コード = 出荷情報明細データ.受注コード) " & _
                        "ORDER BY 受注情報明細データ.受注コード, 受注情報明細データ.受注明細コード"

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyRequestNumber <> Nothing Then
            Maxpc = 1
            pc = pc Or Maxpc
        End If
        If KeyPhoneNumber <> Nothing Then
            Maxpc = 2
            pc = pc Or Maxpc
        End If

        'パラメータ指定がある場合
        If Maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= Maxpc
                Select Case i And pc
                    Case 1  '受注コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.受注コード Like ""%" & KeyRequestNumber & "%"" "
                        scnt = scnt + 1

                    Case 2  '電話番号コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.請求先－電話番号－ハイフン無し = " & KeyPhoneNumber & " "
                        strSelect = strSelect & "Or 受注情報データ.出荷先－電話番号－ハイフン無し = " & KeyPhoneNumber & " "

                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        i = 0

        'SQL文の設定
        pCommand.CommandText = strSelect

        Try
            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parViewRequestSubDataFull(i)

                '受注コード
                parViewRequestSubDataFull(i).sRequestCode = pDataReader("受注コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parViewRequestSubDataFull(i).sChannelCode = 0
                Else
                    parViewRequestSubDataFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                parViewRequestSubDataFull(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注明細コード
                If IsDBNull(pDataReader("受注明細コード")) = True Then
                    parViewRequestSubDataFull(i).sRequestSubCode = 0
                Else
                    parViewRequestSubDataFull(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))
                End If
                '商品コード
                parViewRequestSubDataFull(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parViewRequestSubDataFull(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parViewRequestSubDataFull(i).sProductName = pDataReader("商品名称").ToString
                'オプション名称
                parViewRequestSubDataFull(i).sOptionName = pDataReader("オプション名称").ToString
                'オプション値
                parViewRequestSubDataFull(i).sOptionValue = pDataReader("オプション値").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parViewRequestSubDataFull(i).sListPrice = 0
                Else
                    parViewRequestSubDataFull(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parViewRequestSubDataFull(i).sCostPrice = 0
                Else
                    parViewRequestSubDataFull(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '受注商品単価
                If IsDBNull(pDataReader("受注商品単価")) = True Then
                    parViewRequestSubDataFull(i).sUnitPrice = 0
                Else
                    parViewRequestSubDataFull(i).sUnitPrice = CLng(pDataReader("受注商品単価"))
                End If
                '受注数量
                If IsDBNull(pDataReader("受注数量")) = True Then
                    parViewRequestSubDataFull(i).sCount = 0
                Else
                    parViewRequestSubDataFull(i).sCount = CInt(pDataReader("受注数量"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parViewRequestSubDataFull(i).sNoTaxPrice = 0
                Else
                    parViewRequestSubDataFull(i).sNoTaxPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parViewRequestSubDataFull(i).sTaxPrice = 0
                Else
                    parViewRequestSubDataFull(i).sTaxPrice = CLng(pDataReader("受注消費税額"))
                End If
                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parViewRequestSubDataFull(i).sPrice = 0
                Else
                    parViewRequestSubDataFull(i).sPrice = CLng(pDataReader("受注税込金額"))
                End If
                'チャネル商品コード
                parViewRequestSubDataFull(i).sChannelProductCode = pDataReader("チャネル商品コード").ToString
                'チャネル商品名称
                parViewRequestSubDataFull(i).sChannelProductName = pDataReader("チャネル商品名称").ToString
                'チャネルオプション
                parViewRequestSubDataFull(i).sChannelOptionNameAndValue = pDataReader("チャネルオプション").ToString
                '出荷数量
                If IsDBNull(pDataReader("出荷数量")) = True Then
                    parViewRequestSubDataFull(i).sCount = 0
                Else
                    parViewRequestSubDataFull(i).sCount = CInt(pDataReader("出荷数量"))
                End If
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequestSub = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewRequestDataFullDBIO.getRequestSub)", Nothing, Nothing, oExcept.ToString)
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
