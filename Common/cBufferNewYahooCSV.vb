Option Explicit On

Imports System.Text
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography.HMACSHA256

Public Class cBufferAmazonCSV

    Private Const PROGRAM_NAME As String = "Amazon"
    Private Const COLUMN_CNT As Integer = 43

    Private CHARSET As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")

    Private accessKeyId As String
    Private marketplaceId As String
    Private signature As String
    Private sellerId As String
    Private secretKey As String
    Private CSVsavePath As String

    Private pSignature As String

    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oChannelCode As Integer

    Public Sub New( _
                ByRef iConn As OleDb.OleDbConnection, _
                ByRef iCommand As OleDb.OleDbCommand, _
                ByRef iDataReader As OleDb.OleDbDataReader, _
                ByVal accessKeyId As String, _
                ByVal marketplaceId As String, _
                ByVal signature As String, _
                ByVal sellerId As String, _
                ByVal secretKey As String, _
                ByVal CSVsavePath As String, _
                ByVal iChannelCode As Integer, _
                ByVal iTran As System.Data.OleDb.OleDbTransaction _
                )
        Me.accessKeyId = accessKeyId
        Me.marketplaceId = marketplaceId
        Me.signature = signature
        Me.sellerId = sellerId
        Me.secretKey = secretKey
        Me.CSVsavePath = CSVsavePath

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oChannelCode = iChannelCode

    End Sub
    Public Function DownLoad() As Long
        Dim amazonReportId() As String

        ReDim amazonReportId(0)
        If ReportIdDownLoad(amazonReportId) Then
            OrderDownLoad(amazonReportId)
        End If

    End Function

    Public Function ReportIdDownLoad(ByRef amazonReportId() As String) As Long
        Dim rtnStatus As Integer = 0

        Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        Dim msg As String = ""

        'Dim postListOrder As String

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim o As Integer = 0
        Dim p As Integer = 0
        Dim q As Integer = 0
        Dim r As Integer = 0

        Dim recordOrderCnt As Integer = 0
        Dim recordItemCnt As Integer = 0

        Dim xmlStream As String

        Dim csvListOrder As StreamWriter

        Dim xmlDoc As XmlDocument

        Dim xmlListElement As XmlElement

        'Dim xListDoc As Object
        'Dim httpObj As Object

        Try
            ' Logファイルオープン
            l.open()

            ReportIdDownLoad = 0

            '****************************************
            '       受注データのレポートIDを取得
            '****************************************
            '' --------------------------------------------------------
            'msg = "Amazon apiリクエストの生成（受注一覧）" : l.write(msg)
            '' --------------------------------------------------------
            'postListOrder = getAmazonReportList()

            '' --------------------------------------------------------
            'msg = "Amazon apiリクエストを送信（受注一覧）" : l.write(msg)
            '' --------------------------------------------------------
            'httpObj = CreateObject("Microsoft.XMLHTTP")

            'httpObj.Open("POST", postListOrder, False)

            'httpObj.send("")

            'xListDoc = httpObj.ResponseXML

            ' --------------------------------------------------------
            msg = "取得したXMLをCSVファイルに設定（受注一覧）" : l.write(msg)
            ' --------------------------------------------------------
            ' Stream取得
            xmlStream = getAmazonReportList()

            xmlDoc = New XmlDocument

            xmlDoc.LoadXml(xmlStream)

            xmlListElement = xmlDoc.DocumentElement

            ' 要素数を取得
            recordOrderCnt = xmlListElement.FirstChild.ChildNodes.Count

            If recordOrderCnt > 0 Then
                ' 取得Reportの件数分のレコード出力
                For i = 2 To recordOrderCnt - 1
                    ReDim Preserve amazonReportId(i - 2)
                    '2016.05.31 K.Oikawa s
                    'TODO:ReportIdの取得処理が間違っていたためにエラーが発生していた
                    'amazonReportId(i - 2) = xmlListElement.FirstChild.ChildNodes(i).ChildNodes(0).InnerText
                    For j = 0 To xmlListElement.FirstChild.ChildNodes(i).ChildNodes.Count - 1
                        If xmlListElement.FirstChild.ChildNodes(i).ChildNodes(j).Name = "ReportId" Then
                            amazonReportId(i - 2) = xmlListElement.FirstChild.ChildNodes(i).ChildNodes(j).InnerText
                        End If
                    Next j
                    '2016.05.31 K.Oikawa e
                Next i
            End If

            ReportIdDownLoad = recordOrderCnt - 2

        Catch ex As Exception
            l.write(msg)
            l.write(ex)
            'l.write("以下パスにXMLファイルを出力：" & vbCrLf & xmlDoc.InnerXml)
            rtnStatus = -1
        Finally
            xmlDoc = Nothing
            csvListOrder = Nothing
            l.close()
            l = Nothing
        End Try

    End Function
    Public Function OrderDownLoad(ByVal amazonReportId() As String) As Long
        Dim rtnStatus As Integer = 0

        Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        Dim msg As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        Dim csvListItem As StreamWriter

        Dim xItemDoc As String

        Dim csvData() As String
        Dim csvDataTemp() As String
        Dim csvDataPre() As String
        Dim csvStr As String
        'Dim ProductStr() As String
        'Dim str As String

        Dim pDownLoadColumn() As cStructureLib.sDownloadColumn
        Dim pDownLoadColumnDBIO As New cMstDownloadColumnDBIO(oConn, oCommand, oDataReader)
        'Dim pDownLoadCount As Integer

        'Dim skuNo As Integer
        'Dim ProductNameNo As Integer
        'Dim quantityNo As Integer
        'Dim ShippingPriceNo As Integer
        'Dim itemPriceNo As Integer
        'Dim ItemPromotionIdNo As Integer
        'Dim ItemPromotionPriceNo As Integer
        'Dim ShipPromotionIdNo As Integer
        'Dim ShipPromotionPriceNo As Integer
        'Dim PurchaseDateNo As Integer
        Dim OrderCode As New Hashtable
        Dim RecordNo As Integer
        'Dim PromotionType As Integer
        Dim pItemPromotion As New Hashtable
        Dim pShipPromotion As New Hashtable
        'Dim HeaderSize As Integer

        Dim LastFlg As Boolean

        Try
            ' Logファイルオープン
            l.open()

            '**********************************
            '       受注データCSVの生成
            '**********************************
            csvListItem = New StreamWriter(CSVsavePath & "\Amazon_Order.csv", False, System.Text.Encoding.GetEncoding("shift_jis"))

            ReDim csvData(0)
            ReDim csvDataTemp(0)
            ReDim csvDataPre(0)
            csvStr = ""
            LastFlg = False
            ' --------------------------------------------------------
            msg = "Amazon apiリクエストの生成（受注明細）" : l.write(msg)
            ' --------------------------------------------------------
            'ReDim pDownLoadColumn(0)
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "sku", oTran)
            'skuNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "product-name", oTran)
            'ProductNameNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "quantity-purchased", oTran)
            'quantityNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "shipping-price", oTran)
            'ShippingPriceNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "item-price", oTran)
            'itemPriceNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "item-promotion-id", oTran)
            'ItemPromotionIdNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "item-promotion-discount", oTran)
            'ItemPromotionPriceNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "ship-promotion-id", oTran)
            'ShipPromotionIdNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 2, "ship-promotion-discount", oTran)
            'ShipPromotionPriceNo = pDownLoadColumn(0).sDLColumnNo - 1
            'pDownLoadCount = pDownLoadColumnDBIO.getDownloadColumn(pDownLoadColumn, oChannelCode, 1, "purchase-date", oTran)
            'PurchaseDateNo = pDownLoadColumn(0).sDLColumnNo - 1

            RecordNo = 0

            '----------------------------
            '  i = レポート数分ループ
            '----------------------------
            For i = 0 To amazonReportId.Length - 1
                If amazonReportId(i) <> "0" Then

                    ReDim pDownLoadColumn(0)

                    'Amazon受注レポートの受信
                    xItemDoc = getAmazonReport(amazonReportId(i))

                    ' ------------------------------------------------------------------------------------
                    msg = "取得したフラット(TAB区切り)をCSVファイルに設定（受注情報）" : l.write(msg)
                    ' ------------------------------------------------------------------------------------

                    ' レコード分割
                    csvData = xItemDoc.Replace(vbLf, "").Split(vbCr)

                    ReDim csvDataPre(0)
                    '----------------------------
                    '  j = レコード数分ループ
                    '----------------------------
                    For j = 0 To (csvData.Length - 1)

                        ''プロモーションタイプの初期化
                        'PromotionType = 0

                        If csvData(j) <> "" Then    '空レコードでなければ・・・
                            If i = 0 Or j > 0 Then
                                '項目毎に分割
                                csvDataTemp = csvData(j).Split(vbTab)

                                csvStr = """" & String.Join(""",""", csvDataTemp) & """"
                                csvListItem.Write(csvStr & vbCr + vbLf)

                                '        'レポート内の重複OrderNoの読み飛ばし
                                '        If (OrderCode.ContainsKey(csvDataTemp(0)) = False) Or (csvDataPre(0) = csvDataTemp(0)) Then

                                '            'オーダーコードテーブルの作成
                                '            If OrderCode.ContainsKey(csvDataTemp(0)) = False Then
                                '                OrderCode.Add(csvDataTemp(0), csvDataTemp(0))
                                '            End If

                                '            Select Case RecordNo
                                '                Case 0  '今回ダウンロードデータの先頭行（先頭レポートの先頭行の場合
                                '                    csvStr = """" & String.Join(""",""", csvDataTemp) & """"
                                '                    csvListItem.Write(csvStr & vbCr + vbLf)

                                '                    'ヘッダー項目数の取得
                                '                    HeaderSize = csvDataTemp.Length
                                '                    ReDim Preserve csvDataPre(HeaderSize)

                                '                Case Else
                                '                    Select Case j
                                '                        Case 0  '２レポート目移行のヘッダーレコードの場合　→　読み飛ばし

                                '                        Case Else
                                '                            If csvDataTemp(PurchaseDateNo) <> "" Then
                                '                                '当該レコードの確定
                                '                                csvStr = """" & String.Join(""",""", csvDataTemp) & """"
                                '                                csvListItem.Write(csvStr & vbCr + vbLf)
                                '                            Else

                                '                                If csvDataPre(0) = csvDataTemp(0) Then  'OrderIDが同一の場合
                                '                                    If csvDataPre(1) = csvDataTemp(1) Then  'ItemIDが同一の場合
                                '                                        '-------------------------------------------------------------
                                '                                        '  同一オーダー内の同一商品のプロモーションレコードの場合
                                '                                        '-------------------------------------------------------------

                                '                                        'プロモーションタイプの判定

                                '                                        '購入割引プロモーションの場合
                                '                                        If csvDataTemp(ItemPromotionPriceNo) <> "0" Then
                                '                                            PromotionType = 1
                                '                                        End If

                                '                                        '配送無料プロモーションの場合
                                '                                        If csvDataTemp(ShipPromotionPriceNo) <> "0" Then
                                '                                            PromotionType = 2
                                '                                        End If

                                '                                        '告知のみのプロモーションの場合
                                '                                        If csvDataTemp(ItemPromotionPriceNo) = "0" And csvDataTemp(ShipPromotionPriceNo) = "0" Then
                                '                                            PromotionType = 3
                                '                                        End If

                                '                                        Select Case PromotionType
                                '                                            Case 1  '購入割引プロモーションの場合
                                '                                                'プロモーション名を商品名称に設定
                                '                                                If csvDataTemp(ItemPromotionIdNo) <> "" Then
                                '                                                    ProductStr = csvDataTemp(ItemPromotionIdNo).Split(" ")
                                '                                                    str = ""
                                '                                                    For k = 0 To ProductStr.Length - 3
                                '                                                        If k > 0 Then
                                '                                                            str = str & " "
                                '                                                        End If
                                '                                                        str = str & ProductStr(k)
                                '                                                    Next
                                '                                                    csvDataTemp(ProductNameNo) = str
                                '                                                End If
                                '                                                csvDataTemp(itemPriceNo) = CLng(csvDataPre(ItemPromotionPriceNo)) + CLng(csvDataTemp(ItemPromotionPriceNo))
                                '                                                csvDataTemp(quantityNo) = "1"

                                '                                                'If pItemPromotion.ContainsKey(csvDataTemp(ProductNameNo)) Then
                                '                                                '    pItemPromotion(csvDataTemp(ProductNameNo)) = CType(csvDataTemp(ProductNameNo), Long) + CLng(csvDataTemp(ItemPromotionPriceNo))
                                '                                                'Else
                                '                                                '    pItemPromotion.Add(csvDataTemp(ProductNameNo), CLng(csvDataTemp(ItemPromotionPriceNo)))
                                '                                                'End If

                                '                                            Case 2  '配送無料プロモーションの場合
                                '                                                'shipプロモーション適用されている場合
                                '                                                If csvDataTemp(ShipPromotionPriceNo) <> "0" And csvDataTemp(ShipPromotionPriceNo) <> "" Then
                                '                                                    'プロモーション名を商品名称に設定
                                '                                                    If csvDataTemp(ShipPromotionIdNo) <> "" Then
                                '                                                        ProductStr = csvDataTemp(ShipPromotionIdNo).Split(" ")
                                '                                                        str = ""
                                '                                                        For k = 0 To ProductStr.Length - 3
                                '                                                            If k > 0 Then
                                '                                                                str = str & " "
                                '                                                            End If
                                '                                                            str = str & ProductStr(k)
                                '                                                        Next
                                '                                                        csvDataTemp(ProductNameNo) = str
                                '                                                    End If
                                '                                                    csvDataTemp(itemPriceNo) = CLng(csvDataPre(ShipPromotionPriceNo)) + CLng(csvDataTemp(ShipPromotionPriceNo))
                                '                                                    csvDataTemp(quantityNo) = "1"
                                '                                                End If

                                '                                                'If pShipPromotion.ContainsKey(csvDataTemp(ProductNameNo)) Then
                                '                                                '    pShipPromotion(csvDataTemp(ProductNameNo)) = CType(csvDataTemp(ProductNameNo), Long) + CLng(csvDataTemp(ShipPromotionPriceNo))
                                '                                                'Else
                                '                                                '    pShipPromotion.Add(csvDataTemp(ProductNameNo), CLng(csvDataTemp(ShipPromotionPriceNo)))
                                '                                                'End If

                                '                                            Case 3  '告知のみのプロモーションの場合

                                '                                        End Select
                                '                                    Else
                                '                                        pItemPromotion.Clear()
                                '                                    End If
                                '                                Else
                                '                                    '--------------------------------------------
                                '                                    '  オーダーが切替った場合
                                '                                    '--------------------------------------------

                                '                                    'Preレコードの書出し
                                '                                    csvStr = """" & String.Join(""",""", csvDataPre) & """"
                                '                                    csvListItem.Write(csvStr & vbCr + vbLf)

                                '                                    'プロモーションレコードの生成
                                '                                    For Each key As String In pShipPromotion.Keys
                                '                                        csvDataPre(ProductNameNo) = key
                                '                                        csvDataPre(itemPriceNo) = pShipPromotion(key)

                                '                                        'プロモーションレコードの書出し
                                '                                        csvStr = """" & String.Join(""",""", csvDataPre) & """"
                                '                                        csvListItem.Write(csvStr & vbCr + vbLf)
                                '                                    Next

                                '                                    'プロモーションテーブルの初期化
                                '                                    pShipPromotion.Clear()

                                '                                End If
                                '                            End If
                                '                    End Select
                                '            End Select
                                '        End If
                                '    End If

                                '    csvDataPre = csvDataTemp

                                '    '複数レポートにおける連番の処理レコード番号をインクリメント
                                '    RecordNo = RecordNo + 1
                                'Next j

                                ''iTemプロモーションレコードの生成
                                'For Each key As String In pItemPromotion.Keys
                                '    csvDataPre(ProductNameNo) = key
                                '    csvDataPre(itemPriceNo) = pItemPromotion(key)

                                '    'プロモーションレコードの書出し
                                '    csvStr = """" & String.Join(""",""", csvDataPre) & """"
                                '    csvListItem.Write(csvStr & vbCr + vbLf)
                                'Next

                                ''Shipプロモーションレコードの生成
                                'For Each key As String In pShipPromotion.Keys
                                '    csvDataPre(ProductNameNo) = key
                                '    csvDataPre(ShippingPriceNo) = pShipPromotion(key)

                                '    'プロモーションレコードの書出し
                                '    csvStr = """" & String.Join(""",""", csvDataPre) & """"
                                '    csvListItem.Write(csvStr & vbCr + vbLf)
                                'Next

                            End If
                        End If
                    Next j
                    'Amazonレポート受信済みの署名
                    xItemDoc = setAcknowledgements(amazonReportId(i))
                End If
            Next i

            csvListItem.Close()


        Catch ex As Exception
            l.write(msg)
            l.write(ex)
            'l.write("以下パスにXMLファイルを出力：" & vbCrLf & xmlDoc.InnerXml)
            rtnStatus = -1
        Finally
            csvListItem = Nothing
            OrderCode = Nothing
            l.close()
            l = Nothing
        End Try

    End Function


    '-------------------------------------------------------------------
    ' アマゾンへの受注一覧のリクエストパラメータ、署名を作成
    '-------------------------------------------------------------------
    Private Function getAmazonReportList() As String
        'Dim dictRequest As New Dictionary(Of String, String)

        'Dim lastDate As String
        'Dim strNow As String
        'Dim FromTime As String
        'Dim pastTime As String

        'Dim sortString As String

        'Dim builder As New System.Text.StringBuilder()
        'Dim qsBuilder As New System.Text.StringBuilder()
        'Dim hashSignature As String

        'Dim utcNowTime As Date

        '' システム日時を標準時間で取得(システム日時だとAmazonからエラーが返されるため、ここで取得・変換する)
        'utcNowTime = Now.ToUniversalTime

        '' 当日日付を取得(ISO8601形式)
        'strNow = Left(utcNowTime.ToString("o"), 23) & "Z"

        '' 7日前日付を取得(ISO8601形式)
        'FromTime = Left(utcNowTime.AddDays(-30).ToString("o"), 23) & "Z"
        'Dim dt As New DateTime(2012, 5, 1, 0, 0, 0)

        '''UTCに変換する
        ''Dim utcTime As DateTime = System.TimeZoneInfo.ConvertTimeToUtc(dt)
        ''FromTime = Left(utcTime.ToString("o"), 23) & "Z"

        '' 2分前の時間を取得
        'pastTime = Left(utcNowTime.AddDays(-2).ToString("o"), 23) & "Z"

        '' 1週間前の日付を取得
        'lastDate = Left(DateAdd("ww", -1, utcNowTime).ToString("s"), 23) & "Z"

        ''リクエストパラメータをハッシュテーブルに保存
        'dictRequest("AWSAccessKeyId") = accessKeyId
        'dictRequest("Version") = "2009-01-01"
        'dictRequest("Merchant") = sellerId
        'dictRequest("SignatureVersion") = "2"
        'dictRequest("SignatureMethod") = "HmacSHA256"
        'Dim dteNow As DateTime = DateTime.UtcNow
        'Dim sTimeStamp As String = dteNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
        ''タイムスタンプはGMT
        'dictRequest("Timestamp") = sTimeStamp

        ''dictRequest("Timestamp") = "2014-08-25T06:37:10Z"


        'dictRequest("Action") = "GetReportList"
        'dictRequest("ReportTypeList.Type.1") = "_GET_FLAT_FILE_ORDERS_DATA_"


        'Dim pc As New ParamComparer()
        'Dim sortedHash As New SortedDictionary(Of String, String)(dictRequest, pc)
        'Dim canonicalQS As String = ConstructCanonicalQueryString(sortedHash)

        'builder.Append("POST").Append(vbLf). _
        '        Append(CStr("mws.amazonservices.jp").ToLower()).Append(vbLf). _
        '        Append("/").Append(vbLf). _
        '        Append(canonicalQS)

        'Dim stringToSign As String = builder.ToString()
        'Dim toSign As Byte() = System.Text.Encoding.UTF8.GetBytes(stringToSign)

        'Dim secret As Byte()
        'secret = System.Text.Encoding.UTF8.GetBytes(secretKey)
        'Dim signer As System.Security.Cryptography.HMACSHA256
        'signer = New System.Security.Cryptography.HMACSHA256(secret)

        'Dim sigBytes As Byte() = signer.ComputeHash(toSign)
        'Dim signature As String = PercentEncodeRfc3986(Convert.ToBase64String(sigBytes))

        '' URLを生成
        'qsBuilder.Append("https://"). _
        '          Append("mws.amazonservices.jp"). _
        '            Append("/?"). _
        '            Append(canonicalQS). _
        '            Append("&Signature=" & signature)

        'makeAmazonReportList = qsBuilder.ToString()


        Dim dictRequest As New Dictionary(Of String, String)
        Dim wc As New System.Net.WebClient()

        Dim strNow As String

        Dim sortString As String
        Dim stringToSign As String
        Dim toSign As Byte()
        Dim secret As Byte()
        Dim sigBytes As Byte()

        Dim pc As New ParamComparer()
        Dim builder As New System.Text.StringBuilder()
        Dim qsBuilder As New System.Text.StringBuilder()
        Dim signer As System.Security.Cryptography.HMAC

        Dim hashSignature As String
        Dim utcNowTime As Date

        ' システム日時を標準時間で取得(システム日時だとAmazonからエラーが返されるため、ここで取得・変換する)
        utcNowTime = Now.ToUniversalTime

        ' 当日日付を取得(ISO8601形式)
        'strNow = Left(Now.ToUniversalTime.ToString("o"), 23) & "Z"
        strNow = Left(utcNowTime.ToString("o"), 23) & "Z"

        'リクエストパラメータをハッシュテーブルに保存
        dictRequest("AWSAccessKeyId") = accessKeyId
        dictRequest("Version") = "2009-01-01"
        dictRequest("SignatureVersion") = "2"
        dictRequest("SignatureMethod") = "HmacSHA256"
        dictRequest("Timestamp") = strNow

        dictRequest("MarketplaceId.Id") = marketplaceId
        dictRequest("Merchant") = sellerId
        dictRequest("Action") = "GetReportList"
        dictRequest("ReportTypeList.Type.1") = "_GET_FLAT_FILE_ORDERS_DATA_"

        Dim sortedHash As New SortedDictionary(Of String, String)(dictRequest, pc)

        sortString = ConstructCanonicalQueryString(sortedHash)

        ' 署名にする文字列を作成
        builder.Append("POST").Append(vbLf). _
                Append(CStr("mws.amazonservices.jp").ToLower()).Append(vbLf). _
                Append("/").Append(vbLf). _
                Append(sortString)

        stringToSign = builder.ToString()

        ' 署名対象文字列・秘密キーをバイト文字列に変換
        toSign = System.Text.Encoding.UTF8.GetBytes(stringToSign)
        secret = System.Text.Encoding.UTF8.GetBytes(signature)

        ' 署名を作成
        signer = New System.Security.Cryptography.HMACSHA256(secret)

        sigBytes = signer.ComputeHash(toSign)
        hashSignature = Convert.ToBase64String(sigBytes)

        ' URLを生成
        qsBuilder.Append("https://"). _
                  Append("mws.amazonservices.jp"). _
                    Append("/?"). _
                    Append(sortString). _
                    Append("&Signature=").Append(PercentEncodeRfc3986(hashSignature))


        '文字コードを指定する()
        wc.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

        'データを送信し、また受信する
        getAmazonReportList = wc.UploadString(qsBuilder.ToString(), "")
        wc.Dispose()
        wc = Nothing

    End Function
    '-------------------------------------------------------------------
    ' アマゾンへの受注明細のリクエストパラメータ、署名を作成
    '-------------------------------------------------------------------
    Private Function getAmazonReport(ByVal pReportId As String) As String
        Dim dictRequest As New Dictionary(Of String, String)
        Dim wc As New System.Net.WebClient()

        Dim strNow As String

        Dim sortString As String
        Dim stringToSign As String
        Dim toSign As Byte()
        Dim secret As Byte()
        Dim sigBytes As Byte()

        Dim pc As New ParamComparer()
        Dim builder As New System.Text.StringBuilder()
        Dim qsBuilder As New System.Text.StringBuilder()
        Dim signer As System.Security.Cryptography.HMAC

        Dim hashSignature As String
        Dim utcNowTime As Date

        ' システム日時を標準時間で取得(システム日時だとAmazonからエラーが返されるため、ここで取得・変換する)
        utcNowTime = Now.ToUniversalTime

        ' 当日日付を取得(ISO8601形式)
        'strNow = Left(Now.ToUniversalTime.ToString("o"), 23) & "Z"
        strNow = Left(utcNowTime.ToString("o"), 23) & "Z"

        'リクエストパラメータをハッシュテーブルに保存
        dictRequest("AWSAccessKeyId") = accessKeyId
        dictRequest("Version") = "2009-01-01"
        dictRequest("SignatureVersion") = "2"
        dictRequest("SignatureMethod") = "HmacSHA256"
        dictRequest("Timestamp") = strNow

        dictRequest("Action") = "GetReport"
        dictRequest("MarketplaceId.Id") = marketplaceId
        dictRequest("Merchant") = sellerId
        dictRequest("ReportId") = pReportId

        Dim sortedHash As New SortedDictionary(Of String, String)(dictRequest, pc)

        sortString = ConstructCanonicalQueryString(sortedHash)

        ' 署名にする文字列を作成
        builder.Append("POST").Append(vbLf). _
                Append(CStr("mws.amazonservices.jp").ToLower()).Append(vbLf). _
                Append("/").Append(vbLf). _
                Append(sortString)

        stringToSign = builder.ToString()

        ' 署名対象文字列・秘密キーをバイト文字列に変換
        toSign = System.Text.Encoding.UTF8.GetBytes(stringToSign)
        secret = System.Text.Encoding.UTF8.GetBytes(signature)

        ' 署名を作成
        signer = New System.Security.Cryptography.HMACSHA256(secret)

        sigBytes = signer.ComputeHash(toSign)
        hashSignature = Convert.ToBase64String(sigBytes)

        ' URLを生成
        qsBuilder.Append("https://"). _
                  Append("mws.amazonservices.jp"). _
                    Append("/?"). _
                    Append(sortString). _
                    Append("&Signature=").Append(PercentEncodeRfc3986(hashSignature))


        '文字コードを指定する()
        wc.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

        'データを送信し、また受信する
        getAmazonReport = wc.UploadString(qsBuilder.ToString(), "")
        wc.Dispose()
        wc = Nothing

    End Function
    '-------------------------------------------------------------------
    ' アマゾンへの受信済みレポートへの署名
    '-------------------------------------------------------------------
    Private Function setAcknowledgements(ByVal pReportId As String) As String
        Dim dictRequest As New Dictionary(Of String, String)
        Dim wc As New System.Net.WebClient()

        Dim strNow As String

        Dim sortString As String
        Dim stringToSign As String
        Dim toSign As Byte()
        Dim secret As Byte()
        Dim sigBytes As Byte()

        Dim pc As New ParamComparer()
        Dim builder As New System.Text.StringBuilder()
        Dim qsBuilder As New System.Text.StringBuilder()
        Dim signer As System.Security.Cryptography.HMAC

        Dim hashSignature As String
        Dim utcNowTime As Date

        ' システム日時を標準時間で取得(システム日時だとAmazonからエラーが返されるため、ここで取得・変換する)
        utcNowTime = Now.ToUniversalTime

        ' 当日日付を取得(ISO8601形式)
        'strNow = Left(Now.ToUniversalTime.ToString("o"), 23) & "Z"
        strNow = Left(utcNowTime.ToString("o"), 23) & "Z"

        'リクエストパラメータをハッシュテーブルに保存
        dictRequest("AWSAccessKeyId") = accessKeyId
        dictRequest("Version") = "2009-01-01"
        dictRequest("SignatureVersion") = "2"
        dictRequest("SignatureMethod") = "HmacSHA256"
        dictRequest("Timestamp") = strNow

        dictRequest("Action") = "UpdateReportAcknowledgements"
        dictRequest("MarketplaceId.Id") = marketplaceId
        dictRequest("Merchant") = sellerId
        dictRequest("ReportIdList.Id.1") = pReportId

        Dim sortedHash As New SortedDictionary(Of String, String)(dictRequest, pc)

        sortString = ConstructCanonicalQueryString(sortedHash)

        ' 署名にする文字列を作成
        builder.Append("POST").Append(vbLf). _
                Append(CStr("mws.amazonservices.jp").ToLower()).Append(vbLf). _
                Append("/").Append(vbLf). _
                Append(sortString)

        stringToSign = builder.ToString()

        ' 署名対象文字列・秘密キーをバイト文字列に変換
        toSign = System.Text.Encoding.UTF8.GetBytes(stringToSign)
        secret = System.Text.Encoding.UTF8.GetBytes(signature)

        ' 署名を作成
        signer = New System.Security.Cryptography.HMACSHA256(secret)

        sigBytes = signer.ComputeHash(toSign)
        hashSignature = Convert.ToBase64String(sigBytes)

        ' URLを生成
        qsBuilder.Append("https://"). _
                  Append("mws.amazonservices.jp"). _
                    Append("/?"). _
                    Append(sortString). _
                    Append("&Signature=").Append(PercentEncodeRfc3986(hashSignature))


        '文字コードを指定する()
        wc.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

        'データを送信し、また受信する
        setAcknowledgements = wc.UploadString(qsBuilder.ToString(), "")
        wc.Dispose()
        wc = Nothing

    End Function

    Private Function PercentEncodeRfc3986(ByVal str As String) As String
        str = System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8)
        'str.Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~")
        str = str.Replace("'", "%27"). _
                Replace("(", "%28"). _
                Replace(")", "%29"). _
                Replace("*", "%2A"). _
                Replace("!", "%21"). _
                Replace("%7e", "~"). _
                Replace("=", "%2F"). _
                Replace("/", "%3D"). _
                Replace("+", "%2B")

        Dim sbuilder As New System.Text.StringBuilder(str)
        For i As Integer = 0 To sbuilder.Length - 1

            If sbuilder(i) = "%"c Then
                'コメント化
                'If [Char].IsDigit(sbuilder(i + 1)) AndAlso [Char].IsLetter(sbuilder(i + 2)) Then
                sbuilder(i + 1) = [Char].ToUpper(sbuilder(i + 1)) '日本語対策で追加
                sbuilder(i + 2) = [Char].ToUpper(sbuilder(i + 2))
                'End If
            End If

        Next
        Return sbuilder.ToString()
    End Function


    Private Function ConstructCanonicalQueryString(ByVal sortedParamMap As SortedDictionary(Of String, String)) As String
        Dim builder As New System.Text.StringBuilder()

        If sortedParamMap.Count = 0 Then
            builder.Append("")
            Return builder.ToString()
        End If
        For Each kvp As KeyValuePair(Of String, String) In sortedParamMap

            builder.Append(PercentEncodeRfc3986(kvp.Key))
            builder.Append("=")
            builder.Append(PercentEncodeRfc3986(kvp.Value))
            builder.Append("&")
        Next
        Dim canonicalString As String = builder.ToString()
        canonicalString = canonicalString.Substring(0, canonicalString.Length - 1)
        Return canonicalString
    End Function
    Class ParamComparer
        Implements IComparer(Of String)
        Public Function Compare(ByVal p1 As String, ByVal p2 As String) As Integer Implements IComparer(Of String).Compare
            Return String.CompareOrdinal(p1, p2)
        End Function
    End Class
End Class
