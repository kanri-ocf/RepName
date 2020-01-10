
Public Class cDataRequestDBIO
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


    '-------------------------------------------------------------------------------
    '　機能：受注情報データから該当レコードを取得する関数
    '　引数：Byref parRequestData()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Request_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getRequest(ByRef parRequestData() As cStructureLib.sRequestData, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyRequestCode As String, _
                                    ByVal KeyRequestFromDate As String, _
                                    ByVal KeyRequestToDate As String, _
                                    ByVal KeyCustmorName As String, _
                                    ByVal KeyOriginalOrderCode As String, _
                                    ByVal KeyPrintedFlg As Boolean, _
                                    ByVal KeyUnPrintFlg As Boolean, _
                                    ByVal KeyShipedFlg As Boolean, _
                                    ByVal KeyUnShipFlg As Boolean, _
                                    ByVal KeyChannelClass As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyOptionName As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報データ "
        'パラメータ数のカウント
        pc = 0
        If KeyChannelCode <> Nothing Then
            pc = pc Or 1
        End If
        If KeyRequestCode <> "" Then
            pc = pc Or 2
        End If
        If KeyRequestFromDate <> "" Then
            pc = pc Or 4
        End If
        If KeyRequestToDate <> "" Then
            pc = pc Or 8
        End If
        If KeyCustmorName <> "" Then
            pc = pc Or 16
        End If
        If KeyOriginalOrderCode <> "" Then
            pc = pc Or 32
        End If
        If KeyPrintedFlg = True Then
            pc = pc Or 64
        End If
        If KeyUnPrintFlg = True Then
            pc = pc Or 128
        End If
        If KeyShipedFlg = True Then
            pc = pc Or 256
        End If
        If KeyUnShipFlg = True Then
            pc = pc Or 512
        End If
        If KeyChannelClass <> "" Then
            pc = pc Or 1024
        End If
        If KeyProductCode <> "" Then
            pc = pc Or 2048
        End If
        If KeyProductName <> "" Then
            pc = pc Or 4096
        End If
        If KeyOptionName <> "" Then
            pc = pc Or 8192
        End If

        'パラメータ指定がある場合
        If 1024 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 1024
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード Like ""%" & KeyRequestCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyRequestFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyRequestToDate & """ "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "([請求先－姓] & [請求先－名]) Like ""%" & KeyCustmorName & "%"""
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(OR受注コード = """ & KeyOriginalOrderCode & """) "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(受注伝票出力フラグ = True) "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            If KeyPrintedFlg = True Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "AND "
                            End If
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(受注伝票出力フラグ = False) "
                        scnt = scnt + 1
                    Case 256
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "EXISTS (SELECT 1 FROM 出荷情報データ " & _
                                                "WHERE 出荷情報データ.受注コード = 受注情報データ.受注コード AND 出荷情報データ.出荷完了フラグ = 1) "
                        scnt = scnt + 1
                    Case 512
                        If scnt > 0 Then
                            If KeyShipedFlg = True Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "AND "
                            End If
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "NOT EXISTS (SELECT 1 FROM 出荷情報データ " & _
                                                "WHERE 出荷情報データ.受注コード = 受注情報データ.受注コード AND 出荷情報データ.出荷完了フラグ = 1) "
                        scnt = scnt + 1
                    Case 1024
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & _
                                    "EXISTS(" & _
                                    "    SELECT 1 FROM チャネルマスタ " & _
                                    "    WHERE チャネルマスタ.チャネルコード = 受注情報データ.チャネルコード " & _
                                    "    AND   チャネルマスタ.チャネル種別 = 2" & _
                                    ") "
                        scnt = scnt + 1
                    Case 2048
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & _
                                    "EXISTS(" & _
                                    "    SELECT 1 FROM 受注情報明細データ " & _
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " & _
                                    "    AND   ( " & _
                                    "                  受注情報明細データ.商品コード = '" & KeyProductCode & "' " & _
                                    "              OR " & _
                                    "                  受注情報明細データ.チャネル商品コード = '" & KeyProductCode & "' " & _
                                    "           ) " & _
                                    ") "
                        scnt = scnt + 1
                    Case 4096
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & _
                                    "EXISTS(" & _
                                    "    SELECT 1 FROM 受注情報明細データ " & _
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " & _
                                    "    AND   ( " & _
                                    "                  受注情報明細データ.商品名称 = '" & KeyProductName & "' " & _
                                    "           ) " & _
                                    ") "
                        scnt = scnt + 1
                    Case 8192
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & _
                                    "EXISTS(" & _
                                    "    SELECT 1 FROM 受注情報明細データ " & _
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " & _
                                    "    AND   ( " & _
                                    "                  受注情報明細データ.オプション値 = '" & KeyOptionName & "' " & _
                                    "           ) " & _
                                    ") "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            i = 0

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parRequestData(i)

                '受注コード
                parRequestData(i).sRequestCode = pDataReader("受注コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRequestData(i).sChannelCode = 0
                Else
                    parRequestData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                parRequestData(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注サイト
                parRequestData(i).sRequestSite = pDataReader("受注サイト").ToString
                '受注媒体
                parRequestData(i).sRequestMedia = pDataReader("受注媒体").ToString
                'モバイルフラグ
                parRequestData(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                'アフェリエイトフラグ
                parRequestData(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                '受注日
                parRequestData(i).sRequestDate = pDataReader("受注日").ToString
                '受注時間
                parRequestData(i).sRequestTime = pDataReader("受注時間").ToString
                '出荷先－会社名
                parRequestData(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                '出荷先－支店名
                parRequestData(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                '出荷先－姓カナ
                parRequestData(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                '出荷先－名カナ
                parRequestData(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                '出荷先－住所１カナ
                parRequestData(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                '出荷先－住所２カナ
                parRequestData(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                '出荷先－住所市区町村カナ
                parRequestData(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                '出荷先－都道府県カナ
                parRequestData(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                '出荷先－姓
                parRequestData(i).sShip1stName = pDataReader("出荷先－姓").ToString
                '出荷先－名
                parRequestData(i).sShip2ndName = pDataReader("出荷先－名").ToString
                '出荷先－住所１
                parRequestData(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                '出荷先－住所２
                parRequestData(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                '出荷先－住所市区町村
                parRequestData(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                '出荷先－都道府県
                parRequestData(i).sShipState = pDataReader("出荷先－都道府県").ToString
                '出荷先－国名
                parRequestData(i).sShipCountry = pDataReader("出荷先－国名").ToString
                '出荷先－郵便番号1
                parRequestData(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                '出荷先－郵便番号2
                parRequestData(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                '出荷先－電話番号
                parRequestData(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                '請求先－会社名
                parRequestData(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                '請求先－支店名
                parRequestData(i).sBillDivName = pDataReader("請求先－支店名").ToString
                '請求先－姓カナ
                parRequestData(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                '請求先－名カナ
                parRequestData(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                '請求先－住所１カナ
                parRequestData(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                '請求先－住所２カナ
                parRequestData(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                '請求先－住所市区町村カナ
                parRequestData(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                '請求先－都道府県カナ
                parRequestData(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                '請求先－姓
                parRequestData(i).sBill1stName = pDataReader("請求先－姓").ToString
                '請求先－名
                parRequestData(i).sBill2ndName = pDataReader("請求先－名").ToString
                '請求先－住所１
                parRequestData(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                '請求先－住所２
                parRequestData(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                '請求先－住所市区町村
                parRequestData(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                '請求先－都道府県
                parRequestData(i).sBillState = pDataReader("請求先－都道府県").ToString
                '請求先－国名
                parRequestData(i).sBillCountry = pDataReader("請求先－国名").ToString
                '請求先－郵便番号1
                parRequestData(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                '請求先－郵便番号2
                parRequestData(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                '請求先－電話番号
                parRequestData(i).sBillTel = pDataReader("請求先－電話番号").ToString
                'メールアドレス
                parRequestData(i).sMailAdderss = pDataReader("メールアドレス").ToString
                'コメント
                parRequestData(i).sComment = pDataReader("コメント").ToString
                'ステータス
                parRequestData(i).sStatus = pDataReader("ステータス").ToString
                'エントリーポイント
                parRequestData(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                'リンク先
                parRequestData(i).sLink = pDataReader("リンク先").ToString
                'カード支払方法
                parRequestData(i).sCardPayment = pDataReader("カード支払方法").ToString
                '配達希望日
                parRequestData(i).sShipRequestDate = pDataReader("配達希望日").ToString
                '配達希望時間
                parRequestData(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                '配達希望メモ
                parRequestData(i).sShipMemo = pDataReader("配達希望メモ").ToString
                '配送業者
                parRequestData(i).sShipCorp = pDataReader("配送業者").ToString
                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parRequestData(i).sChannelPaymentCode = 0
                Else
                    parRequestData(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'ギフト梱包希望
                parRequestData(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                If IsDBNull(pDataReader("取得ポイント数")) = True Then
                    parRequestData(i).sGetPoint = 0
                Else
                    parRequestData(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                End If
                '受注商品税抜金額
                If IsDBNull(pDataReader("受注商品税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalProductPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parRequestData(i).sShippingCharge = 0
                Else
                    parRequestData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parRequestData(i).sPaymentCharge = 0
                Else
                    parRequestData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parRequestData(i).sDiscount = 0
                Else
                    parRequestData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parRequestData(i).sPointDisCount = 0
                Else
                    parRequestData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parRequestData(i).sTaxTotal = 0
                Else
                    parRequestData(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                End If
                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parRequestData(i).sTotalPrice = 0
                Else
                    parRequestData(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                End If
                'ギフト梱包材料
                parRequestData(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                If IsDBNull(pDataReader("ギフト梱包料金")) = True Then
                    parRequestData(i).sGiftWrapKindPrice = 0
                Else
                    parRequestData(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                End If
                'のし希望
                parRequestData(i).sNoshiType = pDataReader("のし希望").ToString
                'のし記載内容
                parRequestData(i).sNoshiName = pDataReader("のし記載内容").ToString
                '注文者性別
                parRequestData(i).sBillSex = pDataReader("注文者性別").ToString
                '注文者誕生日
                parRequestData(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                '楽天バンク決済手数料
                If IsDBNull(pDataReader("楽天バンク決済手数料")) = True Then
                    parRequestData(i).sRakutenCharge = 0
                Else
                    parRequestData(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                End If
                '受注伝票出力フラグ
                If IsDBNull(pDataReader("受注伝票出力フラグ")) = True Then
                    parRequestData(i).sPrintFlg = False
                Else
                    parRequestData(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                End If
                '受注担当者コード
                parRequestData(i).sStaffCode = pDataReader("受注担当者コード").ToString
                '登録日
                parRequestData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parRequestData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRequestData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parRequestData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getRequest2(ByRef parRequestData() As cStructureLib.sRequestData, _
                                ByVal KeyRequestCode As String, _
                                ByVal KeyPhoneNumber As String, _
                                ByVal KeyFromDate As String, _
                                ByVal KeyToDate As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報データ "
        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> "" Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyPhoneNumber <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyFromDate <> "" Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyToDate <> "" Then
            maxpc = 8
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード Like ""%" & KeyRequestCode & "%"" "
                        scnt = scnt + 1
                    Case 2  '電話番号
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.請求先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "
                        strSelect = strSelect & "Or 受注情報データ.出荷先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "

                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyToDate & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 受注情報データ.登録日 DESC , 受注情報データ.登録時間 DESC"

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            i = 0

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parRequestData(i)

                '受注コード
                parRequestData(i).sRequestCode = pDataReader("受注コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRequestData(i).sChannelCode = 0
                Else
                    parRequestData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                parRequestData(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注サイト
                parRequestData(i).sRequestSite = pDataReader("受注サイト").ToString
                '受注媒体
                parRequestData(i).sRequestMedia = pDataReader("受注媒体").ToString
                'モバイルフラグ
                parRequestData(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                'アフェリエイトフラグ
                parRequestData(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                '受注日
                parRequestData(i).sRequestDate = pDataReader("受注日").ToString
                '受注時間
                parRequestData(i).sRequestTime = pDataReader("受注時間").ToString
                '出荷先－会社名
                parRequestData(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                '出荷先－支店名
                parRequestData(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                '出荷先－姓カナ
                parRequestData(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                '出荷先－名カナ
                parRequestData(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                '出荷先－住所１カナ
                parRequestData(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                '出荷先－住所２カナ
                parRequestData(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                '出荷先－住所市区町村カナ
                parRequestData(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                '出荷先－都道府県カナ
                parRequestData(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                '出荷先－姓
                parRequestData(i).sShip1stName = pDataReader("出荷先－姓").ToString
                '出荷先－名
                parRequestData(i).sShip2ndName = pDataReader("出荷先－名").ToString
                '出荷先－住所１
                parRequestData(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                '出荷先－住所２
                parRequestData(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                '出荷先－住所市区町村
                parRequestData(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                '出荷先－都道府県
                parRequestData(i).sShipState = pDataReader("出荷先－都道府県").ToString
                '出荷先－国名
                parRequestData(i).sShipCountry = pDataReader("出荷先－国名").ToString
                '出荷先－郵便番号1
                parRequestData(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                '出荷先－郵便番号2
                parRequestData(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                '出荷先－電話番号
                parRequestData(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                '請求先－会社名
                parRequestData(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                '請求先－支店名
                parRequestData(i).sBillDivName = pDataReader("請求先－支店名").ToString
                '請求先－姓カナ
                parRequestData(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                '請求先－名カナ
                parRequestData(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                '請求先－住所１カナ
                parRequestData(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                '請求先－住所２カナ
                parRequestData(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                '請求先－住所市区町村カナ
                parRequestData(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                '請求先－都道府県カナ
                parRequestData(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                '請求先－姓
                parRequestData(i).sBill1stName = pDataReader("請求先－姓").ToString
                '請求先－名
                parRequestData(i).sBill2ndName = pDataReader("請求先－名").ToString
                '請求先－住所１
                parRequestData(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                '請求先－住所２
                parRequestData(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                '請求先－住所市区町村
                parRequestData(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                '請求先－都道府県
                parRequestData(i).sBillState = pDataReader("請求先－都道府県").ToString
                '請求先－国名
                parRequestData(i).sBillCountry = pDataReader("請求先－国名").ToString
                '請求先－郵便番号1
                parRequestData(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                '請求先－郵便番号2
                parRequestData(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                '請求先－電話番号
                parRequestData(i).sBillTel = pDataReader("請求先－電話番号").ToString
                'メールアドレス
                parRequestData(i).sMailAdderss = pDataReader("メールアドレス").ToString
                'コメント
                parRequestData(i).sComment = pDataReader("コメント").ToString
                'ステータス
                parRequestData(i).sStatus = pDataReader("ステータス").ToString
                'エントリーポイント
                parRequestData(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                'リンク先
                parRequestData(i).sLink = pDataReader("リンク先").ToString
                'カード支払方法
                parRequestData(i).sCardPayment = pDataReader("カード支払方法").ToString
                '配達希望日
                parRequestData(i).sShipRequestDate = pDataReader("配達希望日").ToString
                '配達希望時間
                parRequestData(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                '配達希望メモ
                parRequestData(i).sShipMemo = pDataReader("配達希望メモ").ToString
                '配送業者
                parRequestData(i).sShipCorp = pDataReader("配送業者").ToString
                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parRequestData(i).sChannelPaymentCode = 0
                Else
                    parRequestData(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'ギフト梱包希望
                parRequestData(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                If IsDBNull(pDataReader("取得ポイント数")) = True Then
                    parRequestData(i).sGetPoint = 0
                Else
                    parRequestData(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                End If
                '受注商品税抜金額
                If IsDBNull(pDataReader("受注商品税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalProductPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parRequestData(i).sShippingCharge = 0
                Else
                    parRequestData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parRequestData(i).sPaymentCharge = 0
                Else
                    parRequestData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parRequestData(i).sDiscount = 0
                Else
                    parRequestData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parRequestData(i).sPointDisCount = 0
                Else
                    parRequestData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parRequestData(i).sTaxTotal = 0
                Else
                    parRequestData(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                End If
                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parRequestData(i).sTotalPrice = 0
                Else
                    parRequestData(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                End If
                'ギフト梱包材料
                parRequestData(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                If IsDBNull(pDataReader("ギフト梱包料金")) = True Then
                    parRequestData(i).sGiftWrapKindPrice = 0
                Else
                    parRequestData(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                End If
                'のし希望
                parRequestData(i).sNoshiType = pDataReader("のし希望").ToString
                'のし記載内容
                parRequestData(i).sNoshiName = pDataReader("のし記載内容").ToString
                '注文者性別
                parRequestData(i).sBillSex = pDataReader("注文者性別").ToString
                '注文者誕生日
                parRequestData(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                '楽天バンク決済手数料
                If IsDBNull(pDataReader("楽天バンク決済手数料")) = True Then
                    parRequestData(i).sRakutenCharge = 0
                Else
                    parRequestData(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                End If
                '受注伝票出力フラグ
                If IsDBNull(pDataReader("受注伝票出力フラグ")) = True Then
                    parRequestData(i).sPrintFlg = False
                Else
                    parRequestData(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                End If
                '受注担当者コード
                parRequestData(i).sStaffCode = pDataReader("受注担当者コード").ToString
                '登録日
                parRequestData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parRequestData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRequestData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parRequestData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequest2 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：受注情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertRequestData(ByRef parRequestData As cStructureLib.sRequestData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strInsert As String

        'SQL文の設定
        'strInsert = "INSERT INTO 受注情報データ (" &
        '                "受注コード, チャネルコード, OR受注コード, 受注サイト, 受注媒体, モバイルフラグ, アフェリエイトフラグ,受注日, 受注時間, 出荷先－会社名, 出荷先－支店名, 出荷先－姓カナ, 出荷先－名カナ, 出荷先－住所１カナ, 出荷先－住所２カナ,出荷先－住所市区町村カナ, 出荷先－都道府県カナ, 出荷先－姓, 出荷先－名, 出荷先－住所１, 出荷先－住所２, 出荷先－住所市区町村,出荷先－都道府県, 出荷先－国名, 出荷先－郵便番号1, 出荷先－郵便番号2, 出荷先－電話番号, 請求先－会社名, 請求先－支店名, 請求先－姓カナ, 請求先－名カナ, 請求先－住所１カナ, 請求先－住所２カナ, 請求先－住所市区町村カナ, 請求先－都道府県カナ,請求先－姓, 請求先－名, 請求先－住所１, 請求先－住所２, 請求先－住所市区町村, 請求先－都道府県, 請求先－国名, 請求先－郵便番号1,請求先－郵便番号2, 請求先－電話番号, メールアドレス, コメント, ステータス, エントリーポイント, リンク先, カード支払方法, 配達希望日, 配達希望時間, 配達希望メモ, 配送業者, チャネル支払コード, ギフト梱包希望, 取得ポイント数, 受注商品税抜金額, 送料, 手数料, 値引き, ポイント値引き, 受注税抜金額, 受注消費税額, 受注税込金額, ギフト梱包材料, ギフト梱包料金, のし希望,のし記載内容, 注文者性別, 注文者誕生日, 楽天バンク決済手数料, 受注伝票出力フラグ, 受注担当者コード, 登録日, 登録時間, 最終更新日, 最終更新時間" &
        '            ") VALUES (" &
        '                "@RequestCode, @ChannelCode, @ORRequestCode, @RequestSite, @RequestMedia, @MobileFlg, @AffiliateFlg, @RequestDate, @RequestTime, @ShipCorpName, @ShipDivName, @ShipKanaShip1stName, @ShipKanaShip2ndName, @ShipKanaAdder1, @ShipKanaAdder2, @ShipKanaCity, @ShipKanaState, @Ship1stName, @Ship2ndName, @ShipAdder1, @ShipAdder2, @ShipCity, @ShipState, @ShipCountry, @ShipPostCode1, @ShipPostCode2, @ShipTel, @BillCorpName, @BillDivName, @BillKanaBill1stName, @BillKanaBill2ndName, @BillKanaAdder1, @BillKanaAdder2, @BillKanaCity, @BillKanaState, @Bill1stName, @Bill2ndName, @BillAdder1, @BillAdder2, @BillCity, @BillState, @BillCountry, @BillPostCode1, @BillPostCode2, @BillTel, @MailAdderss, @Comment, @Status, @EntryPoint, @Link, @CardPayment, @ShipRequestDate, @ShipRequestTime, @ShipMemo, @ShipCorp, @ChannelPaymentCode, @GiftRequest, @GetPoint, @NoTaxTotalProductPrice, @ShippingCharge, @PaymentCharge, @Discount, @PointDisCount, @NoTaxTotalPrice, @TaxTotal, @TotalPrice, @GiftWrapKind, @GiftWrapKindPrice, @NoshiType, @NoshiName, @BillSex, @BillBirthDay, @RakutenCharge, @PrintFlg, @StaffCode, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime" &
        '            ")"

        '2020,1,10 A.Komita SQL文の修正 Start
        strInsert = ""
        strInsert = "INSERT INTO 受注情報データ (" &
                               "受注コード, " &
                               "チャネルコード, " &
                               "OR受注コード, " &
                               "受注サイト, " &
                               "受注媒体, " &
                               "モバイルフラグ, " &
                               "アフェリエイトフラグ, " &
                               "受注日, " &
                               "受注時間, " &
                               "出荷先－会社名, " &
                               "出荷先－支店名, " &
                               "出荷先－姓カナ, " &
                               "出荷先－名カナ, " &
                               "出荷先－住所１カナ, " &
                               "出荷先－住所２カナ, " &
                               "出荷先－住所市区町村カナ, " &
                               "出荷先－都道府県カナ, " &
                               "出荷先－姓, " &
                               "出荷先－名, " &
                               "出荷先－住所１, " &
                               "出荷先－住所２, " &
                               "出荷先－住所市区町村, " &
                               "出荷先－都道府県, " &
                               "出荷先－国名, " &
                               "出荷先－郵便番号1, " &
                               "出荷先－郵便番号2, " &
                               "出荷先－電話番号, " &
                               "請求先－会社名, " &
                               "請求先－支店名, " &
                               "請求先－姓カナ, " &
                               "請求先－名カナ, " &
                               "請求先－住所１カナ, " &
                               "請求先－住所２カナ, " &
                               "請求先－住所市区町村カナ, " &
                               "請求先－都道府県カナ, " &
                               "請求先－姓, " &
                               "請求先－名, " &
                               "請求先－住所１, " &
                               "請求先－住所２, " &
                               "請求先－住所市区町村, " &
                               "請求先－都道府県, " &
                               "請求先－国名, " &
                               "請求先－郵便番号1, " &
                               "請求先－郵便番号2, " &
                               "請求先－電話番号, " &
                               "メールアドレス, " &
                               "コメント, " &
                               "ステータス, " &
                               "エントリーポイント, " &
                               "リンク先, " &
                               "カード支払方法, " &
                               "配達希望日, " &
                               "配達希望時間, " &
                               "配達希望メモ, " &
                               "配送業者, " &
                               "チャネル支払コード, " &
                               "ギフト梱包希望, " &
                               "取得ポイント数, " &
                               "受注商品税抜金額, " &
                               "送料, " &
                               "手数料, " &
                               "値引き, " &
                               "ポイント値引き, " &
                               "受注税抜金額, " &
                               "受注消費税額, " &
                               "受注税込金額, " &
                               "ギフト梱包材料, " &
                               "ギフト梱包料金, " &
                               "のし希望, " &
                               "のし記載内容, " &
                               "注文者性別, " &
                               "注文者誕生日, " &
                               "楽天バンク決済手数料, " &
                               "受注伝票出力フラグ, " &
                               "受注担当者コード, " &
                               "登録日, " &
                               "登録時間, " &
                               "最終更新日, " &
                               "最終更新時間 " &
                           ") VALUES (" &
                               "@RequestCode, " &
                               "@ChannelCode, " &
                               "@ORRequestCode, " &
                               "@RequestSite, " &
                               "@RequestMedia, " &
                               "@MobileFlg, " &
                               "@AffiliateFlg, " &
                               "@RequestDate, " &
                               "@RequestTime, " &
                               "@ShipCorpName, " &
                               "@ShipDivName, " &
                               "@ShipKanaShip1stName, " &
                               "@ShipKanaShip2ndName, " &
                               "@ShipKanaAdder1, " &
                               "@ShipKanaAdder2, " &
                               "@ShipKanaCity, " &
                               "@ShipKanaState, " &
                               "@Ship1stName, " &
                               "@Ship2ndName, " &
                               "@ShipAdder1, " &
                               "@ShipAdder2, " &
                               "@ShipCity, " &
                               "@ShipState, " &
                               "@ShipCountry, " &
                               "@ShipPostCode1, " &
                               "@ShipPostCode2, " &
                               "@ShipTel, " &
                               "@BillCorpName, " &
                               "@BillDivName, " &
                               "@BillKanaBill1stName, " &
                               "@BillKanaBill2ndName, " &
                               "@BillKanaAdder1, " &
                               "@BillKanaAdder2, " &
                               "@BillKanaCity, " &
                               "@BillKanaState, " &
                               "@Bill1stName, " &
                               "@Bill2ndName, " &
                               "@BillAdder1, " &
                               "@BillAdder2, " &
                               "@BillCity, " &
                               "@BillState, " &
                               "@BillCountry, " &
                               "@BillPostCode1, " &
                               "@BillPostCode2, " &
                               "@BillTel, " &
                               "@MailAdderss, " &
                               "@Comment, " &
                               "@Status, " &
                               "@EntryPoint, " &
                               "@Link, " &
                               "@CardPayment, " &
                               "@ShipRequestDate, " &
                               "@ShipRequestTime, " &
                               "@ShipMemo, " &
                               "@ShipCorp, " &
                               "@ChannelPaymentCode, " &
                               "@GiftRequest, " &
                               "@GetPoint, " &
                               "@NoTaxTotalProductPrice, " &
                               "@ShippingCharge, " &
                               "@PaymentCharge, " &
                               "@Discount, " &
                               "@PointDisCount, " &
                               "@NoTaxTotalPrice, " &
                               "@TaxTotal, " &
                               "@TotalPrice, " &
                               "@GiftWrapKind, " &
                               "@GiftWrapKindPrice, " &
                               "@NoshiType, " &
                               "@NoshiName, " &
                               "@BillSex, " &
                               "@BillBirthDay, " &
                               "@RakutenCharge, " &
                               "@PrintFlg, " &
                               "@StaffCode, " &
                               "@CreateDate, " &
                               "@CreateTime, " &
                               "@UpdateDate, " &
                               "@UpdateTime" &
                           ")"
        '2020,1,10 A.Komita 修正 End

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            'パラメータの設定()
            '***********************
            '2020,1,10 A.Komita Nothingでエラー判定が発生する為、空白を代入するif文を追加 From
            '受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@RequestCode").Value = Nothing Then
                pCommand.Parameters("@RequestCode").Value = ""
            Else
                pCommand.Parameters("@RequestCode").Value = parRequestData.sRequestCode
            End If
            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@ChannelCode").Value = Nothing Then
                pCommand.Parameters("@ChannelCode").Value = 0
            Else
                pCommand.Parameters("@ChannelCode").Value = parRequestData.sChannelCode
            End If
            'OR受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ORRequestCode", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ORRequestCode").Value = Nothing Then
                pCommand.Parameters("@ORRequestCode").Value = ""
            Else
                pCommand.Parameters("@ORRequestCode").Value = parRequestData.sORRequestCode
            End If
            '受注サイト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestSite", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@RequestSite").Value = Nothing Then
                pCommand.Parameters("@RequestSite").Value = ""
            Else
                pCommand.Parameters("@RequestSite").Value = parRequestData.sRequestSite
            End If
            '受注媒体
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestMedia", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@RequestMedia").Value = Nothing Then
                pCommand.Parameters("@RequestMedia").Value = ""
            Else
                pCommand.Parameters("@RequestMedia").Value = parRequestData.sRequestMedia
            End If
            'モバイルフラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MobileFlg", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@MobileFlg").Value = Nothing Then
                pCommand.Parameters("@MobileFlg").Value = ""
            Else
                pCommand.Parameters("@MobileFlg").Value = parRequestData.sMobileFlg
            End If
            'アフェリエイトフラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AffiliateFlg", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@AffiliateFlg").Value = Nothing Then
                pCommand.Parameters("@AffiliateFlg").Value = ""
            Else
                pCommand.Parameters("@AffiliateFlg").Value = parRequestData.sAffiliateFlg
            End If
            '受注日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestDate", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@RequestDate").Value = Nothing Then
                pCommand.Parameters("@RequestDate").Value = ""
            Else
                pCommand.Parameters("@RequestDate").Value = parRequestData.sRequestDate
            End If
            '受注時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestTime", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@RequestTime").Value = Nothing Then
                pCommand.Parameters("@RequestTime").Value = ""
            Else
                pCommand.Parameters("@RequestTime").Value = parRequestData.sRequestTime
            End If
            '出荷先－会社名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCorpName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipCorpName").Value = Nothing Then
                pCommand.Parameters("@ShipCorpName").Value = ""
            Else
                pCommand.Parameters("@ShipCorpName").Value = parRequestData.sShipCorpName
            End If
            '出荷先－支店名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipDivName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipDivName").Value = Nothing Then
                pCommand.Parameters("@ShipDivName").Value = ""
            Else
                pCommand.Parameters("@ShipDivName").Value = parRequestData.sShipDivName
            End If
            '出荷先－姓カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaShip1stName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaShip1stName").Value = Nothing Then
                pCommand.Parameters("@ShipKanaShip1stName").Value = ""
            Else
                pCommand.Parameters("@ShipKanaShip1stName").Value = parRequestData.sShipKanaShip1stName
            End If
            '出荷先－名カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaShip2ndName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaShip2ndName").Value = Nothing Then
                pCommand.Parameters("@ShipKanaShip2ndName").Value = ""
            Else
                pCommand.Parameters("@ShipKanaShip2ndName").Value = parRequestData.sShipKanaShip2ndName
            End If
            '出荷先－住所１カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaAdder1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaAdder1").Value = Nothing Then
                pCommand.Parameters("@ShipKanaAdder1").Value = ""
            Else
                pCommand.Parameters("@ShipKanaAdder1").Value = parRequestData.sShipKanaAdder1
            End If
            '出荷先－住所２カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaAdder2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaAdder2").Value = Nothing Then
                pCommand.Parameters("@ShipKanaAdder2").Value = ""
            Else
                pCommand.Parameters("@ShipKanaAdder2").Value = parRequestData.sShipKanaAdder2
            End If
            '出荷先－住所市区町村カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaCity", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaCity").Value = Nothing Then
                pCommand.Parameters("@ShipKanaCity").Value = ""
            Else
                pCommand.Parameters("@ShipKanaCity").Value = parRequestData.sShipKanaCity
            End If
            '出荷先－都道府県カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaState", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipKanaState").Value = Nothing Then
                pCommand.Parameters("@ShipKanaState").Value = ""
            Else
                pCommand.Parameters("@ShipKanaState").Value = parRequestData.sShipKanaState
            End If
            '出荷先－姓
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Ship1stName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Ship1stName").Value = Nothing Then
                pCommand.Parameters("@Ship1stName").Value = ""
            Else
                pCommand.Parameters("@Ship1stName").Value = parRequestData.sShip1stName
            End If
            '出荷先－名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Ship2ndName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Ship2ndName").Value = Nothing Then
                pCommand.Parameters("@Ship2ndName").Value = ""
            Else
                pCommand.Parameters("@Ship2ndName").Value = parRequestData.sShip2ndName
            End If
            '出荷先－住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipAdder1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipAdder1").Value = Nothing Then
                pCommand.Parameters("@ShipAdder1").Value = ""
            Else
                pCommand.Parameters("@ShipAdder1").Value = parRequestData.sShipAdder1
            End If
            '出荷先－住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipAdder2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipAdder2").Value = Nothing Then
                pCommand.Parameters("@ShipAdder2").Value = ""
            Else
                pCommand.Parameters("@ShipAdder2").Value = parRequestData.sShipAdder2
            End If
            '出荷先－住所市区町村
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCity", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipCity").Value = Nothing Then
                pCommand.Parameters("@ShipCity").Value = ""
            Else
                pCommand.Parameters("@ShipCity").Value = parRequestData.sShipCity
            End If
            '出荷先－都道府県
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipState", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipState").Value = Nothing Then
                pCommand.Parameters("@ShipState").Value = ""
            Else
                pCommand.Parameters("@ShipState").Value = parRequestData.sShipState
            End If
            '出荷先－国名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCountry", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipCountry").Value = Nothing Then
                pCommand.Parameters("@ShipCountry").Value = ""
            Else
                pCommand.Parameters("@ShipCountry").Value = parRequestData.sShipCountry
            End If
            '出荷先－郵便番号1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPostCode1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipPostCode1").Value = Nothing Then
                pCommand.Parameters("@ShipPostCode1").Value = ""
            Else
                pCommand.Parameters("@ShipPostCode1").Value = parRequestData.sShipPostCode1
            End If
            '出荷先－郵便番号2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPostCode2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipPostCode2").Value = Nothing Then
                pCommand.Parameters("@ShipPostCode2").Value = ""
            Else
                pCommand.Parameters("@ShipPostCode2").Value = parRequestData.sShipPostCode2
            End If
            '出荷先－電話番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipTel", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipTel").Value = Nothing Then
                pCommand.Parameters("@ShipTel").Value = ""
            Else
                pCommand.Parameters("@ShipTel").Value = parRequestData.sShipTel
            End If
            '請求先－会社名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCorpName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillCorpName").Value = Nothing Then
                pCommand.Parameters("@BillCorpName").Value = ""
            Else
                pCommand.Parameters("@BillCorpName").Value = parRequestData.sBillCorpName
            End If
            '請求先－支店名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillDivName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillDivName").Value = Nothing Then
                pCommand.Parameters("@BillDivName").Value = ""
            Else
                pCommand.Parameters("@BillDivName").Value = parRequestData.sBillDivName
            End If
            '請求先－姓カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaBill1stName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaBill1stName").Value = Nothing Then
                pCommand.Parameters("@BillKanaBill1stName").Value = ""
            Else
                pCommand.Parameters("@BillKanaBill1stName").Value = parRequestData.sBillKanaBill1stName
            End If
            '請求先－名カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaBill2ndName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaBill2ndName").Value = Nothing Then
                pCommand.Parameters("@BillKanaBill2ndName").Value = ""
            Else
                pCommand.Parameters("@BillKanaBill2ndName").Value = parRequestData.sBillKanaBill2ndName
            End If
            '請求先－住所１カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaAdder1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaAdder1").Value = Nothing Then
                pCommand.Parameters("@BillKanaAdder1").Value = ""
            Else
                pCommand.Parameters("@BillKanaAdder1").Value = parRequestData.sBillKanaAdder1
            End If
            '請求先－住所２カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaAdder2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaAdder2").Value = Nothing Then
                pCommand.Parameters("@BillKanaAdder2").Value = ""
            Else
                pCommand.Parameters("@BillKanaAdder2").Value = parRequestData.sBillKanaAdder2
            End If
            '請求先－住所市区町村カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaCity", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaCity").Value = Nothing Then
                pCommand.Parameters("@BillKanaCity").Value = ""
            Else
                pCommand.Parameters("@BillKanaCity").Value = parRequestData.sBillKanaCity
            End If
            '請求先－都道府県カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaState", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillKanaState").Value = Nothing Then
                pCommand.Parameters("@BillKanaState").Value = ""
            Else
                pCommand.Parameters("@BillKanaState").Value = parRequestData.sBillKanaState
            End If
            '請求先－姓
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Bill1stName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Bill1stName").Value = Nothing Then
                pCommand.Parameters("@Bill1stName").Value = ""
            Else
                pCommand.Parameters("@Bill1stName").Value = parRequestData.sBill1stName
            End If
            '請求先－名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Bill2ndName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Bill2ndName").Value = Nothing Then
                pCommand.Parameters("@Bill2ndName").Value = ""
            Else
                pCommand.Parameters("@Bill2ndName").Value = parRequestData.sBill2ndName
            End If
            '請求先－住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillAdder1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillAdder1").Value = Nothing Then
                pCommand.Parameters("@BillAdder1").Value = ""
            Else
                pCommand.Parameters("@BillAdder1").Value = parRequestData.sBillAdder1
            End If
            '請求先－住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillAdder2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillAdder2").Value = Nothing Then
                pCommand.Parameters("@BillAdder2").Value = ""
            Else
                pCommand.Parameters("@BillAdder2").Value = parRequestData.sBillAdder2
            End If
            '請求先－住所市区町村
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCity", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillCity").Value = Nothing Then
                pCommand.Parameters("@BillCity").Value = ""
            Else
                pCommand.Parameters("@BillCity").Value = parRequestData.sBillCity
            End If
            '請求先－都道府県
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillState", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillState").Value = Nothing Then
                pCommand.Parameters("@BillState").Value = ""
            Else
                pCommand.Parameters("@BillState").Value = parRequestData.sBillState
            End If
            '請求先－国名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCountry", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillCountry").Value = Nothing Then
                pCommand.Parameters("@BillCountry").Value = ""
            Else
                pCommand.Parameters("@BillCountry").Value = parRequestData.sBillCountry
            End If
            '請求先－郵便番号1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillPostCode1", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillPostCode1").Value = Nothing Then
                pCommand.Parameters("@BillPostCode1").Value = ""
            Else
                pCommand.Parameters("@BillPostCode1").Value = parRequestData.sBillPostCode1
            End If
            '請求先－郵便番号2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillPostCode2", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillPostCode2").Value = Nothing Then
                pCommand.Parameters("@BillPostCode2").Value = ""
            Else
                pCommand.Parameters("@BillPostCode2").Value = parRequestData.sBillPostCode2
            End If
            '請求先－電話番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillTel", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillTel").Value = Nothing Then
                pCommand.Parameters("@BillTel").Value = ""
            Else
                pCommand.Parameters("@BillTel").Value = parRequestData.sBillTel
            End If
            'メールアドレス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MailAdderss", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@MailAdderss").Value = Nothing Then
                pCommand.Parameters("@MailAdderss").Value = ""
            Else
                pCommand.Parameters("@MailAdderss").Value = parRequestData.sMailAdderss
            End If
            'コメント
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Comment", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Comment").Value = Nothing Then
                pCommand.Parameters("@Comment").Value = ""
            Else
                pCommand.Parameters("@Comment").Value = parRequestData.sComment
            End If
            'ステータス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Status", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Status").Value = Nothing Then
                pCommand.Parameters("@Status").Value = ""
            Else
                pCommand.Parameters("@Status").Value = parRequestData.sStatus
            End If
            'エントリーポイント
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EntryPoint", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@EntryPoint").Value = Nothing Then
                pCommand.Parameters("@EntryPoint").Value = ""
            Else
                pCommand.Parameters("@EntryPoint").Value = parRequestData.sEntryPoint
            End If
            'リンク先
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Link", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@Link").Value = Nothing Then
                pCommand.Parameters("@Link").Value = ""
            Else
                pCommand.Parameters("@Link").Value = parRequestData.sLink
            End If
            'カード支払方法
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CardPayment", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@CardPayment").Value = Nothing Then
                pCommand.Parameters("@CardPayment").Value = ""
            Else
                pCommand.Parameters("@CardPayment").Value = parRequestData.sCardPayment
            End If
            '配達希望日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestDate", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipRequestDate").Value = Nothing Then
                pCommand.Parameters("@ShipRequestDate").Value = ""
            Else
                pCommand.Parameters("@ShipRequestDate").Value = parRequestData.sShipRequestDate
            End If
            '配達希望時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestTime", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipRequestTime").Value = Nothing Then
                pCommand.Parameters("@ShipRequestTime").Value = ""
            Else
                pCommand.Parameters("@ShipRequestTime").Value = parRequestData.sShipRequestTime
            End If
            '配達希望メモ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipMemo", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipMemo").Value = Nothing Then
                pCommand.Parameters("@ShipMemo").Value = ""
            Else
                pCommand.Parameters("@ShipMemo").Value = parRequestData.sShipMemo
            End If
            '配送業者
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCorp", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@ShipCorp").Value = Nothing Then
                pCommand.Parameters("@ShipCorp").Value = ""
            Else
                pCommand.Parameters("@ShipCorp").Value = parRequestData.sShipCorp
            End If
            'チャネル支払コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelPaymentCode", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@ChannelPaymentCode").Value = Nothing Then
                pCommand.Parameters("@ChannelPaymentCode").Value = 0
            Else
                pCommand.Parameters("@ChannelPaymentCode").Value = parRequestData.sChannelPaymentCode
            End If
            'ギフト梱包希望
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftRequest", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@GiftRequest").Value = Nothing Then
                pCommand.Parameters("@GiftRequest").Value = ""
            Else
                pCommand.Parameters("@GiftRequest").Value = parRequestData.sGiftRequest
            End If
            '取得ポイント数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GetPoint", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@GetPoint").Value = Nothing Then
                pCommand.Parameters("@GetPoint").Value = 0
            Else
                pCommand.Parameters("@GetPoint").Value = parRequestData.sShippingCharge
            End If
            '受注商品税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalProductPrice", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@NoTaxTotalProductPrice").Value = Nothing Then
                pCommand.Parameters("@NoTaxTotalProductPrice").Value = 0
            Else
                pCommand.Parameters("@NoTaxTotalProductPrice").Value = parRequestData.sNoTaxTotalProductPrice
            End If
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@ShippingCharge").Value = Nothing Then
                pCommand.Parameters("@ShippingCharge").Value = 0
            Else
                pCommand.Parameters("@ShippingCharge").Value = parRequestData.sShippingCharge
            End If
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@PaymentCharge").Value = Nothing Then
                pCommand.Parameters("@PaymentCharge").Value = 0
            Else
                pCommand.Parameters("@PaymentCharge").Value = parRequestData.sPaymentCharge
            End If
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Discount", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@Discount").Value = Nothing Then
                pCommand.Parameters("@Discount").Value = 0
            Else
                pCommand.Parameters("@Discount").Value = parRequestData.sDiscount
            End If
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@PointDisCount").Value = Nothing Then
                pCommand.Parameters("@PointDisCount").Value = 0
            Else
                pCommand.Parameters("@PointDisCount").Value = parRequestData.sPointDisCount
            End If
            '受注税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@NoTaxTotalPrice").Value = Nothing Then
                pCommand.Parameters("@NoTaxTotalPrice").Value = 0
            Else
                pCommand.Parameters("@NoTaxTotalPrice").Value = parRequestData.sNoTaxTotalPrice
            End If
            '受注消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@TaxTotal").Value = Nothing Then
                pCommand.Parameters("@TaxTotal").Value = 0
            Else
                pCommand.Parameters("@TaxTotal").Value = parRequestData.sTaxTotal
            End If
            '受注税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@TotalPrice").Value = Nothing Then
                pCommand.Parameters("@TotalPrice").Value = 0
            Else
                pCommand.Parameters("@TotalPrice").Value = parRequestData.sTotalPrice
            End If
            'ギフト梱包材料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftWrapKind", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@GiftWrapKind").Value = Nothing Then
                pCommand.Parameters("@GiftWrapKind").Value = ""
            Else
                pCommand.Parameters("@GiftWrapKind").Value = parRequestData.sGiftWrapKind
            End If
            'ギフト梱包料金
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftWrapKindPrice", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@GiftWrapKindPrice").Value = Nothing Then
                pCommand.Parameters("@GiftWrapKindPrice").Value = 0
            Else
                pCommand.Parameters("@GiftWrapKindPrice").Value = parRequestData.sGiftWrapKindPrice
            End If
            'のし希望
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoshiType", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@NoshiType").Value = Nothing Then
                pCommand.Parameters("@NoshiType").Value = ""
            Else
                pCommand.Parameters("@NoshiType").Value = parRequestData.sNoshiType
            End If
            'のし記載内容
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoshiName", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@NoshiName").Value = Nothing Then
                pCommand.Parameters("@NoshiName").Value = ""
            Else
                pCommand.Parameters("@NoshiName").Value = parRequestData.sNoshiName
            End If
            '注文者性別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillSex", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillSex").Value = Nothing Then
                pCommand.Parameters("@BillSex").Value = ""
            Else
                pCommand.Parameters("@BillSex").Value = parRequestData.sBillSex
            End If
            '注文者誕生日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillBirthDay", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@BillBirthDay").Value = Nothing Then
                pCommand.Parameters("@BillBirthDay").Value = ""
            Else
                pCommand.Parameters("@BillBirthDay").Value = parRequestData.sBillBirthDay
            End If
            '楽天バンク決済手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RakutenCharge", OleDb.OleDbType.Numeric, 10))
            If pCommand.Parameters("@RakutenCharge").Value = Nothing Then
                pCommand.Parameters("@RakutenCharge").Value = 0
            Else
                pCommand.Parameters("@RakutenCharge").Value = parRequestData.sRakutenCharge
            End If
            '受注伝票出力フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PrintFlg", OleDb.OleDbType.Boolean, 1))
            If pCommand.Parameters("@PrintFlg").Value = Nothing Then
                pCommand.Parameters("@PrintFlg").Value = 0
            Else
                pCommand.Parameters("@PrintFlg").Value = parRequestData.sPrintFlg
            End If
            '受注担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@StaffCode").Value = Nothing Then
                pCommand.Parameters("@StaffCode").Value = "Nothing"
            Else
                pCommand.Parameters("@StaffCode").Value = parRequestData.sStaffCode
            End If
            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@CreateDate").Value = Nothing Then
                pCommand.Parameters("@CreateDate").Value = ""
            Else
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            End If
            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@CreateTime").Value = Nothing Then
                pCommand.Parameters("@CreateTime").Value = ""
            Else
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:yyyy/MM/dd}", Now)
            End If
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@UpdateDate").Value = Nothing Then
                pCommand.Parameters("@UpdateDate").Value = ""
            Else
                pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            End If
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 13))
            If pCommand.Parameters("@UpdateTime").Value = Nothing Then
                pCommand.Parameters("@UpdateTime").Value = ""
            Else
                            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:yyyy/MM/dd}", Now)
            End If
            '2020,1,10 A.Komita 追加 To

            '受注情報データ挿入処理実行
            insertRequestData = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.insertRequestMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：受注情報データから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getMaxRequestCode(ByVal KeyChannelCode As Integer, ByVal KeyDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxRequestNo As Long

        strSelect = ""

        Try

            strSelect = "SELECT 受注コード FROM 受注情報データ " & _
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getMaxRequestCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
    '        一時表から受注情報および受注情報明細をまとめて登録する
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            strSQL = "INSERT INTO 受注情報データ " & _
                     "SELECT * FROM 受注情報データTMP " & _
                     "WHERE NOT EXISTS( " & _
                         "SELECT 1 FROM 受注情報明細データTMP, 商品コード変換マスタ " & _
                         "WHERE 受注情報明細データTMP.受注コード      = 受注情報データTMP.受注コード " & _
                         "AND 商品コード変換マスタ.チャネルコード     = 受注情報データTMP.チャネルコード " & _
                         "AND 商品コード変換マスタ.チャネル商品コード = 受注情報明細データTMP.チャネル商品コード " & _
                         "AND 商品コード変換マスタ.チャネル商品名称   = 受注情報明細データTMP.チャネル商品名称 " & _
                         "AND ( " & _
                         "        (商品コード変換マスタ.チャネルオプション = 受注情報明細データTMP.チャネルオプション) " & _
                         "    OR " & _
                         "        ((商品コード変換マスタ.チャネルオプション IS NULL) AND (受注情報明細データTMP.チャネルオプション IS NULL)) " & _
                         "    OR " & _
                         "        ((商品コード変換マスタ.チャネルオプション = """") AND (受注情報明細データTMP.チャネルオプション = """")) " & _
                         "    ) " & _
                         "AND (ISNULL(商品コード変換マスタ.商品コード) OR 商品コード変換マスタ.商品コード = """") " & _
                     ") "

            pCommand.CommandText = strSQL
            insertTmpToRequest = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.insertTmpToRequest)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
    '        一時表から受注情報および受注情報明細をまとめて登録する
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String
        Dim executeCount As Long = 0

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            'コピー済み一時表データ(受注情報データTMP)の削除
            strSQL = "DELETE FROM 受注情報データTMP " & _
                     "WHERE EXISTS( " & _
                     "			SELECT	1 " & _
                     "			FROM	受注情報データ " & _
                     "			WHERE	受注情報データ.受注コード = 受注情報データTMP.受注コード " & _
                     "	   ) "
            pCommand.CommandText = strSQL
            deleteTmpToRequest = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.deleteTmpToRequest)", Nothing, Nothing, oExcept.ToString)
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
            strSQL = "DELETE FROM 受注情報明細データ " & _
                     "WHERE 受注情報明細データ.OR受注コード=""" & KeyORRequestCode & """ "
            '"AND NOT EXISTS ( SELECT 1 FROM 出荷情報データ WHERE 出荷情報データ.受注コード = 受注情報明細データ.受注コード )"
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran
            pCommand.CommandText = strSQL
            result = pCommand.ExecuteNonQuery()
            If result > 0 Then
                strSQL = "DELETE FROM 受注情報データ " & _
                         "WHERE OR受注コード=""" & KeyORRequestCode & """ "
                pCommand = pConn.CreateCommand
                pCommand.Transaction = Tran
                pCommand.CommandText = strSQL
                result = pCommand.ExecuteNonQuery()
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.deleteForRewrite)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updatePrintFlg(ByVal KeyRequestCode As String, ByVal KeyPrintFlg As Boolean, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 受注情報データ SET " & _
                            "受注伝票出力フラグ = " & KeyPrintFlg & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 受注コード=""" & KeyRequestCode & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            updatePrintFlg = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.updatePrintFlg)", Nothing, Nothing, oExcept.ToString)
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

End Class
