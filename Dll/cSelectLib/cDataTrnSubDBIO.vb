
Public Class cDataTrnSubDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    Public Function TrnExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelectTrn As String = _
        "SELECT COUNT(*) FROM 日次取引明細データ WHERE 取引コード = @TrnCode"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@TrnCode").Value = KeyString

            '取引テーブルから該当取引コードのレコード数読込 
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.TrnExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSubTrn(ByRef parSubTrn() As cStructureLib.sSubTrn, _
                              ByVal KeyTrnCode As Long, _
                              ByVal KeySubTrnCode As Long, _
                              ByVal KeySubTrnClass As Integer, _
                              ByVal KeyProductCode As String, _
                              ByVal KeyProductName As String, _
                              ByVal KeyJANCode As String, _
                              ByVal KeyMemo As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT * FROM 日次取引明細データ "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeySubTrnClass <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyProductName <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyJANCode <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyMemo <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If (maxpc And pc) > 0 Then
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
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "取引明細コード = " & KeySubTrnCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "売上明細区分 = " & KeySubTrnClass & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品名称 Like ""%" & KeyProductName & "%"" "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "備考 Like ""%" & KeyMemo & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If
        strSelect = strSelect + "ORDER BY 取引コード, 取引明細コード "
        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSubTrn(i)

                '取引コード
                If IsDBNull(pDataReader("取引コード")) = True Then
                    parSubTrn(i).sTrnCode = 0
                Else
                    parSubTrn(i).sTrnCode = CLng(pDataReader("取引コード"))
                End If
                '取引明細コード
                If IsDBNull(pDataReader("取引明細コード")) = True Then
                    parSubTrn(i).sSubTrnCode = 0
                Else
                    parSubTrn(i).sSubTrnCode = CLng(pDataReader("取引明細コード"))
                End If
                '売上状態
                parSubTrn(i).sStatus = pDataReader("売上状態").ToString
                '売上明細区分
                If IsDBNull(pDataReader("売上明細区分")) = True Then
                    parSubTrn(i).sSubTrnClass = 0
                Else
                    parSubTrn(i).sSubTrnClass = CInt(pDataReader("売上明細区分"))
                End If
                '部門コード
                parSubTrn(i).sBumonCode = pDataReader("部門コード").ToString
                '商品コード
                parSubTrn(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parSubTrn(i).sProductName = pDataReader("商品名称").ToString
                'JANコード
                parSubTrn(i).sJANCode = pDataReader("JANコード").ToString
                'オプション1
                parSubTrn(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parSubTrn(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parSubTrn(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parSubTrn(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parSubTrn(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parSubTrn(i).sListPrice = 0
                Else
                    parSubTrn(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parSubTrn(i).sCostPrice = 0
                Else
                    parSubTrn(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '取引商品単価
                If IsDBNull(pDataReader("取引商品単価")) = True Then
                    parSubTrn(i).sUnitPrice = 0
                Else
                    parSubTrn(i).sUnitPrice = CLng(pDataReader("取引商品単価"))
                End If
                '取引数量
                If IsDBNull(pDataReader("取引数量")) = True Then
                    parSubTrn(i).sCount = 0
                Else
                    parSubTrn(i).sCount = CInt(pDataReader("取引数量"))
                End If
                '取引税抜商品金額
                If IsDBNull(pDataReader("取引税抜商品金額")) = True Then
                    parSubTrn(i).sNoTaxProductPrice = 0
                Else
                    parSubTrn(i).sNoTaxProductPrice = CLng(pDataReader("取引税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parSubTrn(i).sShipCharge = 0
                Else
                    parSubTrn(i).sShipCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parSubTrn(i).sPayCharge = 0
                Else
                    parSubTrn(i).sPayCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parSubTrn(i).sDiscountPrice = 0
                Else
                    parSubTrn(i).sDiscountPrice = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parSubTrn(i).sPointDiscountPrice = 0
                Else
                    parSubTrn(i).sPointDiscountPrice = CLng(pDataReader("ポイント値引き"))
                End If
                'チケット値引き
                If IsDBNull(pDataReader("チケット値引き")) = True Then
                    parSubTrn(i).sTicketDiscountPrice = 0
                Else
                    parSubTrn(i).sTicketDiscountPrice = CLng(pDataReader("チケット値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引税抜金額")) = True Then
                    parSubTrn(i).sNoTaxPrice = 0
                Else
                    parSubTrn(i).sNoTaxPrice = CLng(pDataReader("取引税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引消費税額")) = True Then
                    parSubTrn(i).sTaxPrice = 0
                Else
                    parSubTrn(i).sTaxPrice = CLng(pDataReader("取引消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引税込金額")) = True Then
                    parSubTrn(i).sPrice = 0
                Else
                    parSubTrn(i).sPrice = CLng(pDataReader("取引税込金額"))
                End If
                '備考
                parSubTrn(i).sMemo = pDataReader("備考").ToString
                '登録日
                parSubTrn(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSubTrn(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSubTrn(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSubTrn(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1

            End While

            getSubTrn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：受注情報データから該当レコードを取得する関数
    '　引数：Byref parRequestData()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Request_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getSubTrn2(ByRef parRequestData() As cStructureLib.sRequestData, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyRequestFromDate As String, _
                                    ByVal KeyRequestToDate As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyJanCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyOptionName As String, _
                                    ByVal KeyMemberCode As String, _
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
        If KeyChannelCode <> Nothing Then           'チャネルコード
            pc = pc Or 1
        End If
        If KeyRequestFromDate <> Nothing Then       'From
            pc = pc Or 2
        End If
        If KeyRequestToDate <> Nothing Then         'To
            pc = pc Or 4
        End If
        If KeyProductCode <> Nothing Then           '商品コード
            pc = pc Or 8
        End If
        If KeyJanCode <> Nothing Then               '商品JANコード
            pc = pc Or 16
        End If
        If KeyProductName = Nothing Then            '商品名
            pc = pc Or 32
        End If
        If KeyOptionName = Nothing Then             'オプション名
            pc = pc Or 64
        End If
        If KeyMemberCode = Nothing Then             '会員コード
            pc = pc Or 128
        End If

        'パラメータ指定がある場合
        If 1024 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 1024
                Select Case i And pc
                    Case 1      'チャネルコード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 2      'From
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyRequestFromDate & """ "
                        scnt = scnt + 1
                    Case 4      'To
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyRequestToDate & """ "
                        scnt = scnt + 1
                    Case 8      '商品コード
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
                    Case 16     '商品JANコード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報明細データ.JANコード Like ""%" & KeyJanCode & "%"" "
                        scnt = scnt + 1
                    Case 32     '商品名
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
                    Case 64     'オプション名
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
                    Case 128    '会員コード
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

            getSubTrn2 = i

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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSumCount(ByRef parSubTrn() As cStructureLib.sSubTrn, _
                              ByVal KeyTrnCode As Long, _
                              ByVal KeyProductCode As String, _
                              ByVal KeyJANCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT " & _
                        "日次取引明細データ.取引コード, " & _
                        "日次取引明細データ.商品コード, " & _
                        "日次取引明細データ.JANコード, " & _
                        "Sum(日次取引明細データ.取引数量) AS 数量の合計 " & _
                    "FROM 日次取引明細データ " & _
                    "GROUP BY 日次取引明細データ.取引コード, 日次取引明細データ.商品コード, 日次取引明細データ.JANコード "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyJANCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        'パラメータ指定がある場合
        If (maxpc And pc) > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("数量の合計")) Then
                    getSumCount = 0
                Else
                    '取引コードインクリメント
                    getSumCount = CLng(pDataReader("数量の合計"))
                End If
            Else
                getSumCount = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSumCount)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getSumPrice(ByRef parSubTrn() As cStructureLib.sSubTrn, _
                               ByVal KeyTrnCode As Long, _
                               ByVal KeySubTrnClass As Integer, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT " & _
                        "日次取引明細データ.取引コード, " & _
                        "日次取引明細データ.売上明細区分, " & _
                        "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計 " & _
                    "FROM 日次取引明細データ " & _
                    "GROUP BY 日次取引明細データ.取引コード, 日次取引明細データ.売上明細区分 "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnClass <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        'パラメータ指定がある場合
        If (maxpc And pc) > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "売上明細区分 = " & KeySubTrnClass & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("税込金額の合計")) Then
                    getSumPrice = 0
                Else
                    '取引コードインクリメント
                    getSumPrice = CLng(pDataReader("税込金額の合計"))
                End If
            Else
                getSumPrice = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSumPrice)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSubTrn(ByVal parSubTrn As cStructureLib.sSubTrn, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Try

            'SQL文の設定
            Const strInsertTrn As String = "INSERT INTO 日次取引明細データ (" & _
                                                "取引コード, " & _
                                                "取引明細コード, " & _
                                                "売上状態, " & _
                                                "売上明細区分, " & _
                                                "部門コード, " & _
                                                "商品コード, " & _
                                                "商品名称, " & _
                                                "JANコード, " & _
                                                "オプション1, " & _
                                                "オプション2, " & _
                                                "オプション3, " & _
                                                "オプション4, " & _
                                                "オプション5, " & _
                                                "定価, " & _
                                                "仕入単価, " & _
                                                "取引商品単価, " & _
                                                "取引数量, " & _
                                                "取引税抜商品金額, " & _
                                                "送料, " & _
                                                "手数料, " & _
                                                "値引き, " & _
                                                "ポイント値引き, " & _
                                                "チケット値引き, " & _
                                                "取引税抜金額, " & _
                                                "取引消費税額, " & _
                                                "取引税込金額, " & _
                                                "備考, " & _
                                                "登録日, " & _
                                                "登録時間, " & _
                                                "最終更新日, " & _
                                                "最終更新時間 " & _
                                            ") VALUES ( " & _
                                                "@TrnCode, " & _
                                                "@SubTrnCode, " & _
                                                "@Status, " & _
                                                "@SubTrnClass, " & _
                                                "@BumonCode, " & _
                                                "@ProductCode, " & _
                                                "@ProductName, " & _
                                                "@JANCode, " & _
                                                "@Option1, " & _
                                                "@Option2, " & _
                                                "@Option3, " & _
                                                "@Option4, " & _
                                                "@Option5, " & _
                                                "@ListPrice, " & _
                                                "@CostPrice, " & _
                                                "@UnitPrice, " & _
                                                "@Count, " & _
                                                "@NoTaxProductPrice, " & _
                                                "@ShipCharge, " & _
                                                "@PayCharge, " & _
                                                "@DiscountPrice, " & _
                                                "@PointDiscountPrice, " & _
                                                "@TicketDiscountPrice, " & _
                                                "@NoTaxPrice, " & _
                                                "@TaxPrice, " & _
                                                "@Price, " & _
                                                "@Memo, " & _
                                                "@CreateDate, " & _
                                                "@CreateTime, " & _
                                                "@UpdateDate, " & _
                                                "@UpdateTime " & _
                                            ")"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertTrn

            '***********************
            '   パラメータの設定
            '***********************

            '取引コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TrnCode").Value = parSubTrn.sTrnCode
            '取引明細コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubTrnCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SubTrnCode").Value = parSubTrn.sSubTrnCode
            '売上状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Status", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@Status").Value = parSubTrn.sStatus
            '売上明細区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubTrnClass", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@SubTrnClass").Value = parSubTrn.sSubTrnClass
            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parSubTrn.sBumonCode
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parSubTrn.sProductCode
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@ProductName").Value = parSubTrn.sProductName
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parSubTrn.sJANCode
            'オプション1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option1", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option1").Value = parSubTrn.sOption1
            'オプション2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option2", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option2").Value = parSubTrn.sOption2
            'オプション3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option3", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option3").Value = parSubTrn.sOption3
            'オプション4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option4", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option4").Value = parSubTrn.sOption4
            'オプション5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option5", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option5").Value = parSubTrn.sOption5
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ListPrice").Value = parSubTrn.sListPrice
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CostPrice").Value = parSubTrn.sCostPrice
            '取引商品単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@UnitPrice").Value = parSubTrn.sUnitPrice
            '取引数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@Count").Value = parSubTrn.sCount
            '取引税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxProductPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxProductPrice").Value = parSubTrn.sNoTaxProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShipCharge").Value = parSubTrn.sShipCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PayCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PayCharge").Value = parSubTrn.sPayCharge
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@DiscountPrice").Value = parSubTrn.sDiscountPrice
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDiscountPrice").Value = parSubTrn.sPointDiscountPrice
            'チケット値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TicketDiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TicketDiscountPrice").Value = parSubTrn.sTicketDiscountPrice
            '取引税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxPrice").Value = parSubTrn.sNoTaxPrice
            '取引消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxPrice").Value = parSubTrn.sTaxPrice
            '取引税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Price").Value = parSubTrn.sPrice
            '備考
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Memo").Value = parSubTrn.sMemo
            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            insertSubTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.insertSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateSubTrn(ByVal parSubTrn As cStructureLib.sSubTrn, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = ""
        strUpdate = "UPDATE 日次取引明細データ SET " & _
                            "取引コード=" & parSubTrn.sTrnCode & " , " & _
                            "取引明細コード=" & parSubTrn.sSubTrnCode & " , " & _
                            "売上状態=""" & parSubTrn.sStatus.ToString & """ , " & _
                            "売上明細区分=" & parSubTrn.sSubTrnClass & " , " & _
                            "部門コード=""" & parSubTrn.sBumonCode.ToString & """ , " & _
                            "商品コード=""" & parSubTrn.sProductCode.ToString & """ , " & _
                            "商品名称=""" & parSubTrn.sProductName.ToString & """ , " & _
                            "JANコード=""" & parSubTrn.sJANCode.ToString & """ , " & _
                            "オプション1=""" & parSubTrn.sOption1.ToString & """ , " & _
                            "オプション2=""" & parSubTrn.sOption2.ToString & """ , " & _
                            "オプション3=""" & parSubTrn.sOption3.ToString & """ , " & _
                            "オプション4=""" & parSubTrn.sOption4.ToString & """ , " & _
                            "オプション5=""" & parSubTrn.sOption5.ToString & """ , " & _
                            "定価=" & parSubTrn.sPrice & " , " & _
                            "仕入単価=" & parSubTrn.sCostPrice & " , " & _
                            "取引商品単価=" & parSubTrn.sUnitPrice & " , " & _
                            "取引数量=" & parSubTrn.sCount & " , " & _
                            "取引税抜商品金額=" & parSubTrn.sNoTaxProductPrice & " , " & _
                            "送料=" & parSubTrn.sShipCharge & " , " & _
                            "手数料=" & parSubTrn.sPayCharge & " , " & _
                            "値引き=" & parSubTrn.sDiscountPrice & " , " & _
                            "ポイント値引き=" & parSubTrn.sPointDiscountPrice & " , " & _
                            "チケット値引き=" & parSubTrn.sTicketDiscountPrice & " , " & _
                            "取引税抜金額=" & parSubTrn.sNoTaxPrice & " , " & _
                            "取引消費税額=" & parSubTrn.sPointDiscountPrice & " , " & _
                            "取引税込金額=" & parSubTrn.sPrice & " , " & _
                            "備考=""" & parSubTrn.sMemo & """ , " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                        "WHERE 取引コード=" & parSubTrn.sTrnCode & " " & _
                        "AND 取引明細コード=" & parSubTrn.sSubTrnCode

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate


            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateSubTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.updateSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引明細テーブルから該当レコードを削除するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteSubTrn( _
                                    ByVal KeyTrnCode As Long, _
                                    ByVal KeySubTrnCode As Long, _
                                    ByVal KeyShipmentCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                ) As Boolean

        Dim strDeleteSubTrn As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim cnt As Long

        cnt = 0
        strDeleteSubTrn = ""

        'SQL文の設定
        strDeleteSubTrn = "DELETE * FROM 日次取引明細データ "

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyShipmentCode <> "" Then
            maxpc = 4
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
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "取引コード= " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "取引明細コード= " & KeySubTrnCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "出荷コード= """ & KeyShipmentCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteSubTrn

            '取引明細テーブル挿入処理実行
            cnt = pCommand.ExecuteNonQuery()

            If cnt <= 0 Then
                deleteSubTrn = False
            Else
                deleteSubTrn = True
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataSubTrnSubDBIO.deleteSubTrn)", Nothing, Nothing, oExcept.ToString)
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
