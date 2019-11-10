Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography.HMACSHA256
Imports System.Xml
Imports System.Web

Imports SHDocVw



Public Class cBufferYahooCSV
    Private CHARSET As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")
    Private pSignature As String
    Private Const SLEEP_MSEC As Integer = 2000
    Private hColumnName As Hashtable

    'テスト用
    'Private Const wUrl As String = "https://test.circus.shopping.yahooapis.jp/ShoppingWebService/V1/orderList"
    Private Const wUrl As String = "https://circus.shopping.yahooapis.jp/ShoppingWebService/V1/orderList"

    Private Const ORDER_CSV_NAME As String = "Yahoo_Order"
    Private Const PRODUCT_CSV_NAME As String = "Yahoo_Product"
    Private Const LOG_PREFIX As String = "yahoo"

    Private userID As String
    Private userPass As String
    Private CSVsavePath As String
    Private ApiKey As String
    Private storeAccount As String
    Private redirectUri As String
    Private programStartTime As Date

    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader
    Private oTran As System.Data.OleDb.OleDbTransaction

    Private cMstDownloadColumnDBIO As cMstDownloadColumnDBIO
    Private oChannelDBIO As cMstChannelDBIO
    Private oDataRequestTMPDBIO As cDataRequestTMPDBIO

    Sub New( _
                ByRef iConn As OleDb.OleDbConnection, _
                ByRef iCommand As OleDb.OleDbCommand, _
                ByRef iDataReader As OleDb.OleDbDataReader, _
                ByVal iTran As System.Data.OleDb.OleDbTransaction, _
                ByVal userID As String, _
                ByVal userPass As String, _
                ByVal CSVsavePath As String, _
                ByVal ApiKey As String, _
                ByVal storeAccount As String, _
                ByVal redirectUri As String _
                )

        Me.userID = userID
        Me.userPass = userPass
        Me.CSVsavePath = CSVsavePath & "\"
        Me.ApiKey = ApiKey
        Me.storeAccount = storeAccount
        Me.redirectUri = redirectUri
        Me.programStartTime = Now

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oDataRequestTMPDBIO = New cDataRequestTMPDBIO(oConn, oCommand, oDataReader)
    End Sub


    '----------------------------------------------------------------------------------
    '受注情報取得
    '　Yahooショップの受注情報を取得する
    '----------------------------------------------------------------------------------
    Public Sub download()
        '認証コード
        Dim nCode As String
        'アクセストークン
        Dim accessToken As String
        'オーダーID
        Dim orderId As ArrayList

        Try

            '------------------------------------------------------------------------------------
            '認証コードの取得
            '------------------------------------------------------------------------------------
            nCode = pbfGetAuthorization()

            '------------------------------------------------------------------------------------
            'アクセストークンの取得
            '------------------------------------------------------------------------------------
            accessToken = pbfGetAccessToken(nCode)
            If accessToken Is Nothing Then
                Exit Sub
            End If


            '------------------------------------------------------------------------------------
            '列名取得
            '------------------------------------------------------------------------------------
            pbfGetColumnName()

            '------------------------------------------------------------------------------------
            'オーダーID取得
            '------------------------------------------------------------------------------------
            orderId = getOrderListData(accessToken)

            'xmlファイルの削除
            If System.IO.File.Exists(CSVsavePath & ORDER_CSV_NAME & ".xml") Then
                System.IO.File.Delete(CSVsavePath & ORDER_CSV_NAME & ".xml")
            End If

            '------------------------------------------------------------------------------------
            '注文情報取得
            '------------------------------------------------------------------------------------
            If orderId.Count <> 0 Then
                '注文情報の取得
                getOrderDetailData(accessToken, orderId)
                'xmlファイルの削除
                For i = 0 To orderId.Count - 1
                    If System.IO.File.Exists(CSVsavePath & orderId(i).ToString & ".xml") Then
                        System.IO.File.Delete(CSVsavePath & orderId(i).ToString & ".xml")
                    End If
                Next
            End If

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub








    ' --------------------------------------------------------
    '認証コード取得
    '　　引　数：なし
    '　　戻り値：認証コード(String)
    ' --------------------------------------------------------
    Public Function pbfGetAuthorization() As String
        'URL
        Dim TargetURL As String
        'IEコントロール
        Dim ie As New SHDocVw.InternetExplorer

        '------------------------------------------------------------------------------------
        'APIの呼び出し(ログインURLの取得)
        '------------------------------------------------------------------------------------
        TargetURL = "https://auth.login.yahoo.co.jp/yconnect/v1/authorization?" & _
                    "response_type=code" & _
                    "&client_id=" & ApiKey & _
                    "&redirect_uri=" & redirectUri & _
                    "&state=hoge&scope=openid"

        '------------------------------------------------------------------------------------
        'IE操作
        '------------------------------------------------------------------------------------
        ie.Visible = False
        ' --------------------------------------------------------
        '開始ページを読込(上で指定したURL)
        ' --------------------------------------------------------
        ie.Navigate(TargetURL)
        sleep("030", ie)

        ' --------------------------------------------------------
        'ログイン
        ' --------------------------------------------------------
        If 1 <= InStr(ie.LocationName, "ログイン - Yahoo! JAPAN") Then
            ie.Document.login_form.login.value = userID
            ie.Document.login_form.passwd.value = userPass
            ie.Document.login_form.Submit()
        End If
        ' --------------------------------------------------------
        '再ログイン
        ' --------------------------------------------------------
        If 1 <= InStr(ie.LocationName, "パスワードの再確認 - Yahoo! JAPAN") Then
            ie.Document.login_form.passwd.value = userPass
            ie.Document.login_form.Submit()
        End If
        '一秒間（1000ミリ秒）停止する
        System.Threading.Thread.Sleep(2000)

        ' --------------------------------------------------------
        '同意
        ' --------------------------------------------------------
        ' 当該ページが表示されない場合があるためページタイトルを確認
        If 1 <= InStr(ie.LocationName, "同意画面 - Yahoo! JAPAN") Then
            ie.Document.Forms(0).Submit()
        End If
        '一秒間（1000ミリ秒）停止する
        System.Threading.Thread.Sleep(2000)

        '------------------------------------------------------------------------------------
        '取得結果から認証コードを抽出(URL)
        '------------------------------------------------------------------------------------        
        pbfGetAuthorization = fPullOut(ie.Document.url.ToString, "code=", "&state=")

        '------------------------------------------------------------------------------------
        'IE終了
        '------------------------------------------------------------------------------------     
        If Not (ie Is Nothing) Then
            ie.Quit() : ie = Nothing
        End If

    End Function


    Private Sub sleep(ByVal seq As String, ByRef ie As SHDocVw.InternetExplorer)
        While ie.Busy Or ie.ReadyState <> tagREADYSTATE.READYSTATE_COMPLETE
            System.Threading.Thread.Sleep(SLEEP_MSEC)
        End While

        Dim s As String = "seq--> " & seq & vbCrLf
        Try
            s += vbCrLf & "return html:" & vbCrLf & ie.Document.body.innerHtml
        Finally
            writeHistory(s)
        End Try
    End Sub

    Private Function writeHistory(ByRef history As String) As String
        Dim sw As System.IO.StreamWriter = Nothing
        Dim path As String = getFullDumpFilePath()
        Try
            sw = New IO.StreamWriter(path, True, System.Text.Encoding.Default)
            sw.WriteLine("######################################################################################")
            sw.WriteLine("######################################################################################")
            sw.WriteLine("######################################################################################")
            sw.WriteLine(history)
        Finally
            If sw IsNot Nothing Then
                sw.Close() : sw = Nothing
            End If
        End Try
        Return path

    End Function

    Private Function getFullDumpFilePath() As String
        Return Application.StartupPath & "\Net" & "\Dump\" & LOG_PREFIX & programStartTime.ToString("yyyyMMdd-HHmmss") & ".dmp"
    End Function

    ' --------------------------------------------------------
    'アクセストークン取得
    '　　引　数：認証コード(nCode:String)
    '　　戻り値：アクセストークン(String)
    ' --------------------------------------------------------
    Public Function pbfGetAccessToken(ByVal nCode As String) As String
        Dim postData As String
        Dim oUrl As String
        Dim accessToken As String

        'POST送信する文字列を作成
        postData = _
            "client_id=" & System.Web.HttpUtility.UrlEncode(ApiKey, CHARSET) & _
            "&grant_type=" & System.Web.HttpUtility.UrlEncode("authorization_code", CHARSET) & _
            "&code=" & System.Web.HttpUtility.UrlEncode(nCode, CHARSET) & _
            "&redirect_uri=" & System.Web.HttpUtility.UrlEncode(redirectUri, CHARSET)

        'WebRequestの作成
        oUrl = "https://auth.login.yahoo.co.jp/yconnect/v1/token"

        'POST送信
        accessToken = post(postData, oUrl, Nothing, "application/x-www-form-urlencoded")
        If accessToken Is Nothing Then
            pbfGetAccessToken = Nothing
        End If

        pbfGetAccessToken = fPullOut(accessToken, "access_token"":""", """,""token_type")

    End Function




    '------------------------------------------------------------------------------------------------------------------------------------------------------------
    'POST通信で取得したXMLを返す
    '引　数：sPostData(ボディに入れるXML),sUrl(指定のURL),sAccessToken(アクセストークンが必要な場合),sContentType("application/x-www-form-urlencoded")
    '戻り値：XML形式
    '------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function post(ByVal sPostData As String, ByVal sUrl As String, ByVal sAccessToken As String, ByVal sContentType As String) As String
        Dim postDataBytes As Byte()
        Dim req As System.Net.WebRequest
        Dim reqStream As System.IO.Stream
        Dim res As System.Net.WebResponse
        Dim resStream As System.IO.Stream
        Dim sr As System.IO.StreamReader

        Dim dictRequest As ArrayList = New ArrayList

        Try

            'バイト型配列に変換
            postDataBytes = System.Text.Encoding.UTF8.GetBytes(sPostData)

            'WebRequestの作成
            req = System.Net.WebRequest.Create(sUrl)

            'メソッドにPOSTを指定
            req.Method = "POST"
            If sAccessToken <> Nothing Then
                'アクセストークンの指定
                req.Headers.Add(HttpRequestHeader.Authorization, "Bearer " & sAccessToken)
            End If

            'ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = sContentType
            'POST送信するデータの長さを指定
            req.ContentLength = postDataBytes.Length

            'データをPOST送信するためのStreamを取得
            reqStream = req.GetRequestStream()
            '送信するデータを書き込む
            reqStream.Write(postDataBytes, 0, postDataBytes.Length)
            reqStream.Close()

            'サーバーからの応答を受信するためのWebResponseを取得
            res = req.GetResponse()

            '応答データを受信するためのStreamを取得
            resStream = res.GetResponseStream()
            '受信して表示
            sr = New System.IO.StreamReader(resStream, CHARSET)

            post = sr.ReadToEnd()
        Catch ex As Exception
            post = Nothing
        End Try
    End Function


    '--------------------------------------------------------
    '注文一覧取得
    '　・指定期間の注文一覧をXML形式で取得
    '　・カンマ区切りのCSV形式に変換
    '　・オーダーIDを抽出
    '
    '　　引　数：アクセストークン(accessToken:String)
    '　　戻り値：オーダーID(ArrayList)
    '--------------------------------------------------------
    Public Function getOrderListData(ByVal accessToken As String) As ArrayList
        '列名
        Dim columnName As ArrayList
        '注文一覧
        Dim orderListData As ArrayList
        'オーダーID
        Dim orderId As ArrayList
        '注文一覧の検索条件(受注日時)
        Dim orderTimeFrom As String
        '作業用Array
        Dim wArray As ArrayList

        '------------------------------------------------------------------------------------
        '注文一覧の列名
        '------------------------------------------------------------------------------------
        columnName = hColumnName("orderList")

        '------------------------------------------------------------------------------------
        '検索条件(前回最後に取得した日時)
        '------------------------------------------------------------------------------------
        orderTimeFrom = oDataRequestTMPDBIO.getMaxRegisteredDate(oTran)

        '------------------------------------------------------------------------------------
        '注文一覧XML取得(ネットからXML出力)
        '------------------------------------------------------------------------------------
        pbsOrderListDownload(accessToken, columnName(0).ToString, orderTimeFrom)

        '------------------------------------------------------------------------------------
        'オーダーIDだけ取ってくる
        '------------------------------------------------------------------------------------
        wArray = New ArrayList
        wArray.Add(columnName(0).ToString)

        '------------------------------------------------------------------------------------
        '注文一覧データ取得(XMLから取得)
        '------------------------------------------------------------------------------------
        orderListData = New ArrayList
        orderListData = getOrderListXml(CSVsavePath & ORDER_CSV_NAME & ".xml", wArray)

        '------------------------------------------------------------------------------------
        '注文一覧CSV出力
        '------------------------------------------------------------------------------------
        '注文一覧からOrderIDを取得
        orderId = New ArrayList

        For i = 0 To orderListData.Count - 1
            'カンマ区切りで取得
            Dim stArrayData As String() = orderListData(i).ToString.Split(","c)
            orderId.Add(stArrayData(0))
        Next

        getOrderListData = orderId

    End Function








    '--------------------------------------------------------
    '注文詳細取得
    '　・指定オーダーIDの注文詳細をXML形式で取得
    '　・カンマ区切りのCSV形式に変換
    '
    '　　引　数：アクセストークン(accessToken:String)
    '　　　　　　オーダーID(orderId:ArrayList)
    '--------------------------------------------------------
    Public Sub getOrderDetailData(ByVal accessToken As String, ByVal orderId As ArrayList)
        '配列の作業用変数
        Dim wArray As ArrayList

        '注文詳細データ
        Dim orderDetailData As Hashtable
        '注文詳細(商品)データ
        Dim orderItemData As Hashtable

        '------------------------------------------------------------------------------------
        '注文一覧取得
        '------------------------------------------------------------------------------------
        orderDetailData = New Hashtable
        orderDetailData = orderData("orderList", accessToken, orderId)
        writeAll(orderDetailData("orderList"), CSVsavePath & ORDER_CSV_NAME & ".csv")

        '------------------------------------------------------------------------------------
        '注文詳細取得
        '------------------------------------------------------------------------------------
        orderDetailData = New Hashtable
        orderDetailData = orderData("orderDetail", accessToken, orderId)

        '------------------------------------------------------------------------------------
        '注文詳細(商品情報)取得
        '------------------------------------------------------------------------------------
        orderItemData = New Hashtable
        orderItemData = orderData("orderItem", accessToken, orderId)

        '------------------------------------------------------------------------------------
        '注文詳細データ結合
        '------------------------------------------------------------------------------------
        wArray = New ArrayList

        wArray.Add(orderDetailData("header") & "," & orderItemData("header"))

        For i = 0 To orderId.Count - 1
            For Each itemLine As String In orderItemData(orderId(i).ToString)
                wArray.Add(orderDetailData(orderId(i).ToString) & "," & itemLine)
            Next
        Next

        '------------------------------------------------------------------------------------
        '注文詳細CSV出力
        '------------------------------------------------------------------------------------
        writeAll(wArray, CSVsavePath & PRODUCT_CSV_NAME & ".csv")

    End Sub






    '--------------------------------------------------------
    '注文詳細取得
    '　・指定オーダーIDの注文詳細をXML形式で取得
    '　・カンマ区切りのCSV形式に変換
    '
    '　　引　数：モード[orderDetail:orderItem](mode:String)
    '　　　　　　アクセストークン(accessToken:String)
    '　　　　　　オーダーID(orderId:ArrayList)
    '　　戻り値：注文詳細データ(Hashtable)
    '--------------------------------------------------------
    Public Function orderData(ByVal mode As String, ByVal accessToken As String, ByVal orderId As ArrayList) As Hashtable
        '列名
        Dim columnName As ArrayList
        '作業用文字列
        Dim wStr As String
        '作業用Array
        Dim wArray As ArrayList
        '作業用Array
        Dim wArray2 As ArrayList

        '作業用hash
        Dim wHash As Hashtable

        '------------------------------------------------------------------------------------
        '注文詳細の列名
        '------------------------------------------------------------------------------------
        columnName = hColumnName(mode)

        '------------------------------------------------------------------------------------
        '列名をカンマ区切りの一列に
        '------------------------------------------------------------------------------------
        wStr = ""
        For i = 0 To columnName.Count - 1
            If i = 0 Then
                wStr = columnName(i).ToString
            Else
                wStr = wStr & "," & columnName(i).ToString
            End If
        Next

        '------------------------------------------------------------------------------------
        '注文詳細XML取得(ネットからXML出力)
        '------------------------------------------------------------------------------------
        '注文詳細取得(XML出力)
        For i = 0 To orderId.Count - 1
            pbsDownloadDetail(orderId(i).ToString, wStr, accessToken)
        Next

        '------------------------------------------------------------------------------------
        '注文詳細データ取得(XMLから取得)
        '------------------------------------------------------------------------------------
        'ヘッダ行設定
        wHash = New Hashtable
        wHash.Add("header", wStr)

        '明細のデータをXMLから展開してCSVに変換
        wArray = New ArrayList
        For i = 0 To orderId.Count - 1
            Select Case mode
                Case "orderList"
                    '注文詳細XMLをカンマ区切りの文字列のリストで取得
                    wArray = getOrderDetailXml(CSVsavePath & orderId(i).ToString & ".xml", columnName)
                Case "orderDetail"
                    '注文詳細XMLをカンマ区切りの文字列のリストで取得
                    wArray = getOrderDetailXml(CSVsavePath & orderId(i).ToString & ".xml", columnName)
                Case "orderItem"
                    '注文詳細XMLをカンマ区切りの文字列のリストで取得
                    wArray = getOrderItemXml(CSVsavePath & orderId(i).ToString & ".xml", columnName)
            End Select

            'データを格納
            For Idx = 0 To wArray.Count - 1
                If mode = "orderList" Then
                    If wHash.Contains("orderList") = False Then
                        wArray2 = New ArrayList
                        wArray2.Add(wStr)
                        wHash.Add("orderList", wArray2)
                    End If
                    wHash(mode).add(wArray(Idx).ToString)
                Else
                    wHash.Add(orderId(i).ToString, wArray(Idx))
                End If
            Next
        Next

        orderData = wHash

    End Function








    '--------------------------------------------------------
    '注文一覧取得(XML出力)
    '引数
    'accessToken：アクセストークン
    'strRequest ：取得する項目名(カンマ区切りの文字列)
    ' -------------------------------------------------------
    Public Sub pbsOrderListDownload(ByVal accessToken As String, ByVal strRequest As String, ByVal orderTimeFrom As String)
        '一時保存
        Dim wRtn As String
        'XML
        Dim postData As String

        'POST送信する文字列を作成
        postData = _
                "<Req>" & _
                "<Search>" & _
                    "<Result>999</Result>" & _
                    "<Condition>" & _
                        "<OrderTimeFrom>" & orderTimeFrom & "</OrderTimeFrom>" & _
                        "<SellerId>" & storeAccount & "</SellerId>" & _
                    "</Condition>" & _
                    "<Field>" & strRequest & "</Field>" & _
                "</Search>" & _
                "<SellerId>" & storeAccount & "</SellerId>" & _
             "</Req>"

        'POST送信
        wRtn = ""
        wRtn = post(postData, wUrl, accessToken, "application/x-www-form-urlencoded")
        If wRtn Is Nothing Then
            Exit Sub
        End If

        '出力
        write(wRtn, CSVsavePath & ORDER_CSV_NAME & ".xml")

    End Sub







    ' --------------------------------------------------------
    '項目名取得
    ' --------------------------------------------------------
    Public Sub pbfGetColumnName()
        '注文一覧
        Dim orderList As ArrayList
        '注文詳細
        Dim orderDetail As ArrayList
        '注文詳細(商品情報)
        Dim orderItem As ArrayList

        '本番はDBから(ダウンロードカラムマスタ)

        ' ダウンロードカラムマスタ読込み
        Dim dc() As cStructureLib.sDownloadColumn = Nothing
        Dim oChannel() As cStructureLib.sChannel
        ReDim oChannel(0)
        oChannelDBIO.getChannelMst(oChannel, Nothing, 2, Nothing, True, oTran)

        cMstDownloadColumnDBIO = New cMstDownloadColumnDBIO(oConn, oCommand, oDataReader)
        For i = 0 To oChannel.Length - 1
            If oChannel(i).sCMSType = 1 Then
                cMstDownloadColumnDBIO.getDBColumn(dc, oChannel(i).sChannelCode, oTran)
                Exit For
            End If
        Next

        '注文一覧
        orderList = New ArrayList
        '注文詳細
        orderDetail = New ArrayList
        '注文詳細(商品情報)
        orderItem = New ArrayList
        For i = 0 To dc.Length - 1
            Select Case dc(i).sDLColumnNo
                Case 1
                    If orderList.Contains(dc(i).sDLColumnName) = False Then
                        orderList.Add(dc(i).sDLColumnName)
                    End If
                Case 2
                    If orderDetail.Contains(dc(i).sDLColumnName) = False Then
                        orderDetail.Add(dc(i).sDLColumnName)
                    End If
                Case 3
                    If orderItem.Contains(dc(i).sDLColumnName) = False Then
                        orderItem.Add(dc(i).sDLColumnName)
                    End If
                Case Else
                    Continue For
            End Select
        Next

        hColumnName = New Hashtable
        hColumnName.Add("orderList", orderList)
        hColumnName.Add("orderDetail", orderDetail)
        hColumnName.Add("orderItem", orderItem)

    End Sub







    ' --------------------------------------------------------
    '注文詳細情報取得(XML出力)
    ' --------------------------------------------------------
    Public Sub pbsDownloadDetail(ByVal OrderId As String, ByVal strRequest As String, ByVal accessToken As String)
        '一時保存
        Dim wRtn As String
        'XML
        Dim postData As String
        'APIUrl
        Dim ApiUrl As String

        'POST送信する文字列を作成
        postData = _
                "<Req>" & _
                "<Target>" & _
                    "<OrderId>" & OrderId & "</OrderId>" & _
                    "<Field>" & strRequest & "</Field>" & _
                "</Target>" & _
                "<SellerId>" & storeAccount & "</SellerId>" & _
             "</Req>"

        'POST送信
        'テスト用
        'ApiUrl = "https://test.circus.shopping.yahooapis.jp/ShoppingWebService/V1/orderInfo"
        ApiUrl = "https://circus.shopping.yahooapis.jp/ShoppingWebService/V1/orderInfo"

        wRtn = ""
        wRtn = post(postData, ApiUrl, accessToken, "application/x-www-form-urlencoded")
        If wRtn Is Nothing Then
            Exit Sub
        End If

        '出力
        write(wRtn, CSVsavePath & OrderId & ".xml")

    End Sub






    '注文一覧解析
    Public Function getOrderListXml(ByVal filePath As String, ByVal dictRequest As ArrayList) As ArrayList
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xColList As XmlNodeList

        Dim xTemporary As ArrayList
        xTemporary = New ArrayList

        Call xDocument.Load(filePath) 'XMLファイルをロード

        xRoot = xDocument.DocumentElement 'XMLドキュメントからルート要素を取り出す   

        If xRoot IsNot Nothing Then
            'Call MessageBox.Show(xRoot.Name)
        Else
            MsgBox("失敗")
        End If

        xDataList = xRoot.GetElementsByTagName("OrderInfo") 'ルート要素から親リストを取得する   

        For Each xElement As XmlElement In xDataList '親リストから親要素を取り出す   
            Dim xCol As String = ""
            For i = 0 To dictRequest.Count - 1
                xColList = xElement.GetElementsByTagName(dictRequest(i))
                For Each xColElem As XmlElement In xColList
                    If xColElem.InnerText Is Nothing Then
                        xCol = xCol & ","
                        Continue For
                    End If
                    If xCol = "" Then
                        xCol = xColElem.InnerText.ToString
                    Else
                        xCol = xCol & "," & xColElem.InnerText.ToString
                    End If
                Next
            Next
            xTemporary.Add(xCol)
        Next xElement

        getOrderListXml = xTemporary

    End Function



    '注文詳細解析
    Public Function getOrderDetailXml(ByVal filePath As String, ByVal dictRequest As ArrayList) As ArrayList
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xColList As XmlNodeList
        Dim hTaihi As Hashtable
        Dim Idx As Integer
        Dim xTemporary As ArrayList

        Dim staihi As String

        xTemporary = New ArrayList

        'XMLファイルをロード
        Call xDocument.Load(filePath)

        'XMLドキュメントからルート要素を取り出す   
        xRoot = xDocument.DocumentElement

        'XML開けたか確認
        If xRoot IsNot Nothing Then
            'Call MessageBox.Show(xRoot.Name)
        Else
            MsgBox("失敗")
        End If

        'ルート要素から親リストを取得する  
        xDataList = xRoot.GetElementsByTagName("OrderInfo")

        For Each xElement As XmlElement In xDataList '親リストから親要素を取り出す   
            'xTemporary.Add(xElement.FirstChild.FirstChild.Value) '親要素の中の子リストを取り出す
            Dim xCol As String = ""

            hTaihi = New Hashtable

            Dim sOrderId As String
            sOrderId = ""

            Dim sStr As String
            sStr = ""

            For i = 0 To dictRequest.Count - 1

                xColList = xElement.GetElementsByTagName(dictRequest(i))

                Idx = 0
                staihi = ""

                Dim bFlg As Boolean
                bFlg = False

                For Each xColElem As XmlElement In xColList

                    'この回のOrderId確保
                    If i = 0 Then
                        sOrderId = xColElem.InnerText.ToString
                    End If

                    If Idx = 0 Then
                        If xColElem.InnerText Is Nothing Then
                            xCol = xCol & ","
                            Continue For
                        End If
                        If xCol = "" Then
                            xCol = xColElem.InnerText.ToString
                        Else
                            xCol = xCol & "," & xColElem.InnerText.ToString
                        End If
                    Else
                        '2週目以降なら
                        If xColElem.InnerText Is Nothing Then
                            staihi = staihi & ","
                            Continue For
                        End If
                        If staihi = "" Then
                            staihi = xColElem.InnerText.ToString
                        Else
                            staihi = staihi & "," & xColElem.InnerText.ToString
                        End If
                        bFlg = True
                    End If

                    Idx = Idx + 1

                Next

                If bFlg = True Then
                    If sStr = "" Then
                        sStr = staihi
                    Else
                        sStr = sStr & "," & staihi
                    End If
                End If

            Next

            If sStr <> "" Then
                hTaihi.Add(sOrderId, sStr)
            End If

            xTemporary.Add(xCol)
        Next xElement

        getOrderDetailXml = xTemporary

    End Function

    '商品情報解析
    Public Function getOrderItemXml(ByVal filePath As String, ByVal dictRequest As ArrayList) As ArrayList
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xColList As XmlNodeList
        Dim hTaihi As Hashtable
        Dim Idx As Integer
        Dim xTemporary As ArrayList

        xTemporary = New ArrayList

        'XMLファイルをロード
        Call xDocument.Load(filePath)

        'XMLドキュメントからルート要素を取り出す   
        xRoot = xDocument.DocumentElement

        'XML開けたか確認
        If xRoot IsNot Nothing Then
            'Call MessageBox.Show(xRoot.Name)
        Else
            MsgBox("失敗")
        End If

        'ルート要素から親リストを取得する  
        xDataList = xRoot.GetElementsByTagName("OrderInfo")

        For Each xElement As XmlElement In xDataList '親リストから親要素を取り出す   
            'xTemporary.Add(xElement.FirstChild.FirstChild.Value) '親要素の中の子リストを取り出す
            Dim xCol() As String
            ReDim xCol(0)

            hTaihi = New Hashtable

            Dim sOrderId As String
            sOrderId = ""

            Dim sStr As String
            sStr = ""

            Dim ItemLineNo As Integer
            ItemLineNo = 0

            Idx = 0

            For i = 0 To dictRequest.Count - 1

                xColList = xElement.GetElementsByTagName(dictRequest(i).ToString)

                Idx = 0

                For Each xColElem As XmlElement In xColList


                    If i = 0 Then
                        ItemLineNo = ItemLineNo + 1
                    End If

                    If ItemLineNo > Idx Then
                        Idx = Idx + 1
                    End If

                    If i = 0 Then
                        ReDim Preserve xCol(ItemLineNo - 1)
                    End If

                    'この回のOrderId確保
                    If i = 0 Then
                        sOrderId = xColElem.InnerText.ToString
                    End If

                    If xColElem.InnerText.ToString Is Nothing Then
                        xCol(Idx - 1) = xCol(Idx - 1) & ","
                        Continue For
                    End If

                    If xCol(Idx - 1) = "" Then
                        xCol(Idx - 1) = xColElem.InnerText.ToString
                    Else
                        xCol(Idx - 1) = xCol(Idx - 1) & "," & xColElem.InnerText.ToString
                    End If

                Next

            Next

            If sStr <> "" Then
                hTaihi.Add(sOrderId, sStr)
            End If

            xTemporary.Add(xCol)
        Next xElement

        getOrderItemXml = xTemporary
    End Function

    Public Function fPullOut(ByVal str As String, ByVal beforeStr As String, ByVal afterStr As String) As String
        Dim wRtn As String
        Dim startPosition As Integer
        Dim endPosition As Integer

        wRtn = ""
        startPosition = 0
        endPosition = 0

        '取得位置
        startPosition = str.IndexOf(beforeStr) + beforeStr.Length + 1
        endPosition = str.IndexOf(afterStr) - (startPosition - 1)

        '文字列取得
        wRtn = Mid(str, startPosition, endPosition)

        fPullOut = wRtn
    End Function


    Public Sub write(ByVal str As String, ByVal saveFile As String)
        '書き込み用
        Dim wSr As System.IO.StreamWriter
        Dim wRtn As Integer

        wRtn = 0

        Try

            wRtn = directoryCheck(saveFile)

            If wRtn = 1 Then
                '書き込みファイルを作成
                directoryCreate(saveFile)
            End If

            '書き込みファイルを開く
            wSr = New System.IO.StreamWriter(saveFile, False, CHARSET)

            '書き込み
            wSr.Write(str)

            '閉じる
            wSr.Close()
        Catch ex As Exception
            ex.ToString()
        Finally

        End Try

    End Sub


    '追記用
    Public Sub writeAll(ByVal str As ArrayList, ByVal saveFile As String)
        '書き込み用
        Dim wRtn As Integer

        wRtn = 0

        Try

            wRtn = directoryCheck(saveFile)

            If wRtn = 1 Then
                '書き込みファイルを作成
                directoryCreate(saveFile)
            End If

            ''書き込み
            'My.Computer.FileSystem.WriteAllText(saveFile, str, True)

            Dim sw As New System.IO.StreamWriter(saveFile, False, CHARSET)

            For Each line As String In str
                sw.WriteLine(line)
            Next
            sw.Close()
        Catch ex As Exception
        Finally

        End Try

    End Sub


    'Directoryの存在チェック
    '引数:path
    '戻り値:数値(0:正常(存在する)　1:正常(存在しない)　-1:異常)
    Public Function directoryCheck(ByVal path As String) As Integer
        Dim wRtn As Integer
        wRtn = 0

        If System.IO.File.Exists(path) Then
            '存在する
            wRtn = 0
        Else
            '存在しない
            wRtn = 1
        End If

        directoryCheck = wRtn

    End Function

    Public Sub directoryCreate(ByVal path As String)
        'pathからDirectoryのみ取得
        Dim directory As String
        'DirectoryInfoのオブジェクトを作成します。
        Dim di As System.IO.DirectoryInfo

        'Directoryのみ取得
        directory = System.IO.Path.GetDirectoryName(path)

        'Directoryオブジェクト作成
        di = New System.IO.DirectoryInfo(directory)

        'Createメソッドでフォルダを作成します。
        di.Create()
    End Sub

End Class
