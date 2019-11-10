Option Explicit On

Imports System.Data.OleDb
Imports cStructureLib
Imports System.IO
Imports System.Xml
Imports System.Net
Imports System.Net.WebRequest
Imports System.Text
Imports System.Collections

Public Class cBufferRakutenCSV

    Private Const PROGRAM_NAME As String = "RAKUTEN"
    Private Const DATE_TYPE_ORDER As Integer = 1 ' 注文日ベース

    Private Const STATUS_UNISSUED As String = "新規受付"

    Private Const LAST_WEEK As Integer = -7

    Private Const CSV_FILE_NAME As String = "Rakuten_Order.csv"
    Private Const TMP_FILE_NAME As String = "Rakuten_Order_tmp.csv"
    Private Const TMP_XML_NAME As String = "tmp_rakuten.xml"

    Private Const REQUEST_METHOD_POST As String = "POST"
    Private Const WEB_REQ_URL As String = "https://api.rms.rakuten.co.jp/es/1.0/order/ws"
    Private Const CONTENT_TYPE_TEXT_XML As String = "text/xml;charset=UTF-8"

    Private Const STATUS_SUCCESS As String = "N00-000"
    Private Const STATUS_CNT_ZERO As String = "E10-001"

    Private Const WRAPPING_PAPER As String = "包装紙"
    Private Const WRAPPING_RIBBON As String = "リボン"

    Private userId As String
    Private csvSavePath As String
    Private channelCode As String

    Private shopUrl As String
    Private userName As String
    Private serviseSecret As String
    Private lisenceKey As String

    Private conn As OleDbConnection
    Private command As OleDbCommand
    Private dataReader As OleDbDataReader
    Private tran As OleDbTransaction

    Private log As cLog
    Private msg As String

    Private rakutenCsv As StreamWriter
    Private rakutenTmp As StreamWriter
    Private tmpXml As StreamWriter

    'ほしいのはユーザーID、ショップURL、ユーザー名、認証キー、DBセッション情報など
    Public Sub New( _
                   ByVal iConn As OleDbConnection, _
                   ByVal iCommand As OleDbCommand, _
                   ByVal iDataReader As OleDbDataReader, _
                   ByVal iTran As OleDbTransaction, _
                   ByVal iUserId As String, _
                   ByVal iChannelCode As String, _
                   ByVal iCsvSavePath As String _
                   )
        Me.conn = iConn
        Me.command = iCommand
        Me.dataReader = iDataReader
        Me.tran = iTran
        Me.userId = iUserId
        Me.channelCode = iChannelCode
        Me.csvSavePath = iCsvSavePath

        log = New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)

    End Sub
    ' -------------------------------------------------------------------- 
    ' 楽天APIから受注データをダウンロード
    ' -------------------------------------------------------------------- 
    Public Sub downLoad()
        Dim serviceSecret As String
        Dim licenseKey As String
        Dim shopUrl As String

        msg = ""
        serviceSecret = ""
        licenseKey = ""
        shopUrl = ""

        ' DBからAPI接続情報の取得、CSVファイルのオープンなど
        Call subinit(serviceSecret, licenseKey, shopUrl)

        ' 主処理(パラメータ生成、API実行、ファイル形式変換など)
        Call submain(serviceSecret, licenseKey, shopUrl)

        ' 終了処理
        Call subend()

    End Sub
    ' --------------------------------------------------------------------  
    ' 初期処理
    ' -------------------------------------------------------------------- 
    Private Sub subinit(ByRef iServiceSecret As String, ByRef iLicenseKey As String, ByRef iShopUrl As String)
        Dim enc As Encoding

        enc = System.Text.Encoding.GetEncoding("UTF-8")

        ' DBから接続情報を取得
        getConnInfo(iServiceSecret, iLicenseKey, iShopUrl)

        ' 一時ファイルが存在していれば、削除
        If File.Exists(csvSavePath & "\" & TMP_FILE_NAME) Then
            File.Delete(csvSavePath & "\" & TMP_FILE_NAME)
        End If

        ' XMLファイルが存在していれば、削除
        If File.Exists(csvSavePath & "\" & TMP_XML_NAME) Then
            File.Delete(csvSavePath & "\" & TMP_XML_NAME)
        End If
        
        ' 一時ファイルのオープン
        rakutenTmp = New StreamWriter(csvSavePath & "\" & TMP_FILE_NAME, False, enc)

        ' XMLファイルのオープン
        tmpXml = New StreamWriter(csvSavePath & "\tmp_rakuten.xml", False, enc)

    End Sub
    ' -------------------------------------------------------------------- 
    ' API接続情報を取得
    ' -------------------------------------------------------------------- 
    Private Sub getConnInfo(ByRef iServiceSecret As String, ByRef iLicenseKey As String, ByRef iShopUrl As String)
        Dim configItem As cMstConfigDBIO
        Dim config() As sConfig

        Dim returnCnt As Long

        configItem = New cMstConfigDBIO(conn, command, dataReader)
        ReDim config(0)

        Try
            ' 環境マスタから認証情報を抽出
            returnCnt = configItem.getConfMst(config, tran)

            ' 取得結果を引数に設定
            iServiceSecret = config(0).sRakutenAPIServiceSecret
            iLicenseKey = config(0).sRakutenAPILicenseKey
            iShopUrl = config(0).sRakutenAPIUrl

        Catch ex As Exception
            log.write(msg)
            log.write(ex)
        Finally
            configItem = Nothing
            config = Nothing
        End Try

    End Sub
    ' -------------------------------------------------------------------- 
    ' メイン処理
    ' -------------------------------------------------------------------- 
    Private Sub submain(ByVal iServiceSecret As String, ByVal iLicenseKey As String, ByVal iShopUrl As String)
        Dim userAuthModel As cUserAuthModel
        Dim orderRequestModel As cGetOrderRequestModel

        Dim xmlDoc As String
        Dim xmlHeader As String ' SOAP規格のXMLヘッダ
        Dim xmlBody As String ' SOAP規格のXMLボディ
        Dim xmlArg0 As String ' パラメータの認証キー部分
        Dim xmlArg1 As String ' パラメータの受注情報部分

        Dim xmlDocBytes As Byte()

        Dim xmlResponse As StreamReader

        ' XMLヘッダの作成
        xmlHeader = makeSoapHeader()

        ' 認証キー部分の生成
        userAuthModel = New cUserAuthModel
        xmlArg0 = makeAuthKey(userAuthModel, iServiceSecret, iLicenseKey, iShopUrl)

        ' 受注情報部分の生成
        orderRequestModel = New cGetOrderRequestModel
        xmlArg1 = makeReqParameter(orderRequestModel)

        ' XMLのボディ部分の生成
        xmlBody = makeXmlBody(xmlArg0, xmlArg1)

        ' XMLの生成
        xmlDoc = makeXmlDoc(xmlHeader, xmlBody)

        xmlDocBytes = System.Text.Encoding.UTF8.GetBytes(xmlDoc)

        ' APIの呼び出し
        xmlResponse = sendHttpRequest(REQUEST_METHOD_POST, WEB_REQ_URL, xmlDocBytes)

        ' XMLファイルからCSVファイル(一時保存用)へ変換
        changeXmlToCsv(xmlResponse.ReadToEnd())

        ' CSVファイル(一時保存用)からCSVファイル(取込用)へ変換
        editRakutenCSV()

    End Sub
    ' -------------------------------------------------------------------- 
    ' XMLのヘッダを作成
    ' -------------------------------------------------------------------- 
    Private Function makeSoapHeader() As String
        Dim xmlHeader As String

        xmlHeader = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" " & _
                        " xmlns:ws=""http://orderapi.rms.rakuten.co.jp/rms/mall/order/api/ws"">" & _
                        "<soapenv:Header/>"

        Return xmlHeader
    End Function
    ' -------------------------------------------------------------------- 
    ' 認証キーを生成
    ' -------------------------------------------------------------------- 
    Private Function makeAuthKey(ByRef iUserAuthModel As cUserAuthModel, _
                                 ByVal iServiceSecret As String, _
                                 ByVal iLicenseKey As String, _
                                 ByVal iShopUrl As String) _
                     As String
        Dim base64 As cEncode
        Dim xmlArg0 As String

        iUserAuthModel.setUserName(userId)

        iUserAuthModel.setShopUrl(iShopUrl)

        base64 = New cEncode("UTF-8")
        iUserAuthModel.setAuthKey("ESA " & base64.Encode(iServiceSecret & ":" & iLicenseKey))

        xmlArg0 = iUserAuthModel.xmlauthkey & _
                  iUserAuthModel.xmlShopUrl & _
                  iUserAuthModel.xmlUserName

        Return xmlArg0
    End Function
    ' -------------------------------------------------------------------- 
    ' 受注情報取得パラメータ設定
    ' -------------------------------------------------------------------- 
    Private Function makeReqParameter(ByRef orderRequestModel As cGetOrderRequestModel) As String
        Dim xmlArg1 As String

        ' 受注情報取得フラグ  
        orderRequestModel.setIsOrderNumberOnlyFlg(False)

        ' 受注検索モデルのパラメータを取得
        orderRequestModel.setOrderSearchModel(makeOrderSeachModel)

        xmlArg1 = orderRequestModel.xmlIsOrderNumberOnlyFlg & _
                  orderRequestModel.xmlOrderSearchModel

        Return xmlArg1
    End Function
    ' -------------------------------------------------------------------- 
    ' 受注検索モデルのパラメータを取得
    ' -------------------------------------------------------------------- 
    Private Function makeOrderSeachModel() As String
        Dim xmlSub As String
        Dim orderSearchModel As cOrderSearchModel

        orderSearchModel = New cOrderSearchModel

         ' 受注ステータス(新規受付)→注・今はひとつだけですが、複数指定の場合、ここを修正する必要あります
        orderSearchModel.setStatus(STATUS_UNISSUED)

        ' 期間検索種別
        orderSearchModel.setDateType(DATE_TYPE_ORDER)

        ' 期間FROM
        orderSearchModel.setStartDate(Now.AddDays(LAST_WEEK))

        ' 期間TO
        orderSearchModel.setEndDate(Now)

        xmlSub = orderSearchModel.xmlStatus & _
                 orderSearchModel.xmlDateType & _
                 orderSearchModel.xmlStartDate & _
                 orderSearchModel.xmlEndDate

        Return xmlSub
    End Function
    ' -------------------------------------------------------------------- 
    ' XMLのボディ部分を生成
    ' -------------------------------------------------------------------- 
    Private Function makeXmlBody(ByVal xmlArg0 As String, ByVal xmlArg1 As String) As String
        Dim xmlBody As String

        xmlBody = "<soapenv:Body>" & _
                      "<ws:getOrder>" & _
                         "<arg0>" & _
                           xmlArg0 & _
                         "</arg0>" & _
                         "<arg1>" & _
                           xmlArg1 & _
                         "</arg1>" & _
                      "</ws:getOrder>" & _
                  "</soapenv:Body>"

        Return xmlBody
    End Function
    ' -------------------------------------------------------------------- 
    ' XMLを生成
    ' -------------------------------------------------------------------- 
    Private Function makeXmlDoc(ByVal xmlHeader As String, ByVal xmlBody As String) As String
        Dim xmlDoc As String

        xmlDoc = xmlHeader & _
                 xmlBody & _
                 "</soapenv:Envelope>"

        Return xmlDoc
    End Function
    ' -------------------------------------------------------------------- 
    ' 終了処理
    ' -------------------------------------------------------------------- 
    Private Sub subend()
        ' 処理なし
    End Sub
    ' -------------------------------------------------------------------- 
    ' HTTPへのリクエスト情報を送信
    ' -------------------------------------------------------------------- 
    Private Function sendHttpRequest(ByVal iMethod As String, ByVal iUrl As String, iXmlDocBytes As Byte()) As StreamReader
        Dim xmlResponse As StreamReader
        Dim webRequest As WebRequest
        Dim webResponse As WebResponse
        Dim reqStream As Stream
        Dim resStream As Stream
        Dim enc As Encoding

        enc = System.Text.Encoding.GetEncoding("UTF-8")

        ' WebRequestの作成
        webRequest = Create(iUrl)
        ' メソッドにPOSTを指定
        webRequest.Method = iMethod
        ' ContentTypeを[text/xml;charset=UTF-8]に指定
        webRequest.ContentType = CONTENT_TYPE_TEXT_XML
        ' 対象データの長さを指定
        webRequest.ContentLength = iXmlDocBytes.Length()

        ' 送信対象の情報を取得
        reqStream = webRequest.GetRequestStream()

        ' 送信内容をセット
        reqStream.Write(iXmlDocBytes, 0, iXmlDocBytes.Length)
        reqStream.Close()

        'サーバーからの応答を受信するためのWebResponseを取得
        webResponse = webRequest.GetResponse()

        '応答データを受信するためのStreamを取得
        resStream = webResponse.GetResponseStream()
        '受信して表示
        xmlResponse = New System.IO.StreamReader(resStream, enc)

        Return xmlResponse
    End Function
    ' -------------------------------------------------------------------- 
    ' XMLからCSファイルへの変換を行う
    ' -------------------------------------------------------------------- 
    Private Sub changeXmlToCsv(ByVal strResponse As String)
        Dim xmlDoc As XmlDocument

        Dim orderList As XmlNodeList
        Dim orderNode As XmlNode
        Dim orderElement As XmlElement
        Dim csvOrder(0) As String

        Dim personList As XmlNodeList
        Dim personNode As XmlNode
        Dim personElement As XmlElement
        Dim csvPersonModel(0) As String

        Dim normalOrderList As XmlNodeList
        Dim normalOrderNode As XmlNode
        Dim normalOrderElement As XmlElement
        Dim csvNormalOrder(0) As String

        Dim saOrderList As XmlNodeList
        Dim saOrderNode As XmlNode
        Dim saOrderElement As XmlElement
        Dim csvSaOrder(0) As String

        Dim guOrderList As XmlNodeList
        Dim guOrderNode As XmlNode
        Dim guOrderElement As XmlElement
        Dim csvGuOrder(0) As String

        Dim settlementList As XmlNodeList
        Dim settlementNode As XmlNode
        Dim settlementElement As XmlElement
        Dim csvSettlement(0) As String

        Dim cardList As XmlNodeList
        Dim cardNode As XmlNode
        Dim cardElement As XmlElement
        Dim csvCard(0) As String

        Dim deliverytList As XmlNodeList
        Dim deliveryNode As XmlNode
        Dim deliveryElement As XmlElement
        Dim csvDelivery(0) As String

        Dim pointList As XmlNodeList
        Dim pointNode As XmlNode
        Dim pointElement As XmlElement
        Dim csvPoint(0) As String

        Dim bankList As XmlNodeList
        Dim bankNode As XmlNode
        Dim bankElement As XmlElement
        Dim csvBank(0) As String

        Dim wrapping1List As XmlNodeList
        Dim wrapping1Node As XmlNode
        Dim wrapping1Element As XmlElement
        Dim csvWrapping1(0) As String

        Dim wrapping2List As XmlNodeList
        Dim wrapping2Node As XmlNode
        Dim wrapping2Element As XmlElement
        Dim csvWrapping2(0) As String

        Dim packageList As XmlNodeList
        Dim packageNode As XmlNode
        Dim packageElement As XmlElement
        Dim csvPackage(0) As String
        Dim tmpPackage(0) As String

        Dim senderList As XmlNodeList
        Dim senderNode As XmlNode
        Dim senderElement As XmlElement
        Dim csvSender(0) As String

        Dim cvsList As XmlNodeList
        Dim cvsNode As XmlNode
        Dim cvsElement As XmlElement
        Dim csvCvs(0) As String

        Dim itemList As XmlNodeList
        Dim itemNode As XmlNode
        Dim itemElement As XmlElement
        Dim csvItem(0) As String

        Dim normalItemList As XmlNodeList
        Dim normalItemNode As XmlNode
        Dim normalItemElement As XmlElement
        Dim csvNormalItem(0) As String

        Dim groupItemList As XmlNodeList
        Dim groupItemNode As XmlNode
        Dim groupItemElement As XmlElement
        Dim csvGroupItem(0) As String

        Dim groupChoiceList As XmlNodeList
        Dim groupChoiceNode As XmlNode
        Dim groupChoiceElement As XmlElement
        Dim csvGroupChoice(0) As String

        Dim groupInvList As XmlNodeList
        Dim groupInvNode As XmlNode
        Dim groupInvElement As XmlElement
        Dim csvGroupInv(0) As String

        Dim couponList As XmlNodeList
        Dim couponNode As XmlNode
        Dim couponElement As XmlElement
        Dim csvCoupon(0) As String

        Try
            ' 一時ファイルにデータを書き込む
            tmpXml.Write(strResponse)

            tmpXml.Close()

            xmlDoc = New XmlDocument()
            xmlDoc.Load(csvSavePath & TMP_XML_NAME)

            ' 正常終了と取得件数が0件の場合、ログを出力せずに処理を継続
            ' →エラーメッセージは1件だけ
            If xmlDoc.GetElementsByTagName("errorCode")(0).InnerText <> STATUS_SUCCESS _
            And xmlDoc.GetElementsByTagName("errorCode")(0).InnerText <> STATUS_CNT_ZERO Then
                ' エラーコードをログに書き込む
                log.write(msg)
                log.write(xmlDoc.GetElementsByTagName("errorCode")(0).InnerText)
                log.write(xmlDoc.GetElementsByTagName("message")(0).InnerText)
            End If

            ' 受注モデルのデータを取得
            orderList = xmlDoc.GetElementsByTagName("orderModel")

            ' 受注モデルのデータ全件の処理を行う
            For i As Integer = 0 To orderList.Count - 1
                orderNode = orderList.Item(i)

                orderElement = orderNode

                ReDim csvOrder(0)

                ' 受注番号
                If orderElement.GetElementsByTagName("orderNumber").Count > 0 Then
                    csvOrder(0) = editCsvColmun(orderElement.GetElementsByTagName("orderNumber")(0).InnerText)
                Else
                    csvOrder(0) = editCsvColmun("")
                End If

                ' 受注ステータス 
                If orderElement.GetElementsByTagName("status").Count = 1 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("status")(0).InnerText)
                ElseIf orderElement.GetElementsByTagName("status").Count = 2 Then ' ポイントを使用していると、タグ"status"が2回発生するため
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("status")(1).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 決済ステータス
                If orderElement.GetElementsByTagName("cardStatus").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("cardStatus")(0).InnerText)

                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 入金日
                If orderElement.GetElementsByTagName("paymentDate").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("paymentDate")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 配送日
                If orderElement.GetElementsByTagName("shippingDate").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("shippingDate")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 希望時間帯
                If orderElement.GetElementsByTagName("shippingTerm").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("shippingTerm")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 配送希望日
                If orderElement.GetElementsByTagName("wishDeliveryDate").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("wishDeliveryDate")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 担当者
                If orderElement.GetElementsByTagName("operator").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("operator")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' ひとことメモ
                If orderElement.GetElementsByTagName("memo").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("memo")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' メール差込文(お客様へのメッセージ)
                If orderElement.GetElementsByTagName("mailPlugSentence").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("mailPlugSentence")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 初期購入合計金額
                If orderElement.GetElementsByTagName("firstAmount").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("firstAmount")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 利用端末
                If orderElement.GetElementsByTagName("carrierCode").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("carrierCode")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' メールキャリアコード
                If orderElement.GetElementsByTagName("emailCarrierCode").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("emailCarrierCode")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' ギフト配送希望
                If orderElement.GetElementsByTagName("isGiftCheck").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("isGiftCheck")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 更新シーケンスID
                If orderElement.GetElementsByTagName("seqId").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("seqId")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' コメント(→物理名はオプションですが、マッピングに間違いはありません。。。)
                If orderElement.GetElementsByTagName("option").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("option")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 注文日時
                If orderElement.GetElementsByTagName("orderDate").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("orderDate")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 注文種別
                If orderElement.GetElementsByTagName("orderType").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("orderType")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 複数送付先フラグ
                If orderElement.GetElementsByTagName("isGift").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("isGift")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 警告表示注文
                If orderElement.GetElementsByTagName("isBlackUser").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("isBlackUser")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 楽天会員フラグ
                If orderElement.GetElementsByTagName("isRakutenMember").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("isRakutenMember")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 消費税再計算フラグ
                If orderElement.GetElementsByTagName("isTaxRecalc").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("isTaxRecalc")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱可能フラグ
                If orderElement.GetElementsByTagName("canEnclosure").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("canEnclosure")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  商品合計金額
                If orderElement.GetElementsByTagName("goodsPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("goodsPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  消費税
                If orderElement.GetElementsByTagName("goodsTax").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("goodsTax")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  送料合計
                If orderElement.GetElementsByTagName("postagePrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("postagePrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  代引料
                If orderElement.GetElementsByTagName("deliveryPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("deliveryPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  請求金額
                If orderElement.GetElementsByTagName("requestPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("requestPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  合計金額
                If orderElement.GetElementsByTagName("totalPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("totalPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 同梱子注文モデルリスト

                '  同梱ID
                If orderElement.GetElementsByTagName("enclosureId").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureId")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱商品合計金額
                If orderElement.GetElementsByTagName("enclosureGoodsPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureGoodsPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱送料合計
                If orderElement.GetElementsByTagName("enclosurePostagePrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosurePostagePrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱代引料合計
                If orderElement.GetElementsByTagName("enclosureDeliveryPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureDeliveryPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱消費税合計
                If orderElement.GetElementsByTagName("enclosureGoodsTax").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureGoodsTax")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱ステータス
                If orderElement.GetElementsByTagName("enclosureStatus").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureStatus")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱請求金額
                If orderElement.GetElementsByTagName("enclosureRequestPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureRequestPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱合計金額
                If orderElement.GetElementsByTagName("enclosureTotalPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureTotalPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱楽天バンク決済振替手数料
                If orderElement.GetElementsByTagName("enclosureRbankTransferCommission").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureRbankTransferCommission")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱ポイント利用合計
                If orderElement.GetElementsByTagName("enclosurePointPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosurePointPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  同梱クーポン利用合計
                If orderElement.GetElementsByTagName("enclosureCouponPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("enclosureCouponPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  購入履歴修正アイコンフラグ
                If orderElement.GetElementsByTagName("modify").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("modify")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  あす楽希望フラグ
                If orderElement.GetElementsByTagName("asurakuFlg").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("asurakuFlg")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  クーポン利用総額
                If orderElement.GetElementsByTagName("couponAllTotalPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponAllTotalPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  店舗発行クーポン利用額
                If orderElement.GetElementsByTagName("couponShopPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponShopPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  楽天発行クーポン利用額
                If orderElement.GetElementsByTagName("couponOtherPrice").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponOtherPrice")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  クーポン利用数総合計
                If orderElement.GetElementsByTagName("couponAllTotalUnit").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponAllTotalUnit")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  店舗発行クーポン利用数
                If orderElement.GetElementsByTagName("couponShopTotalUnit").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponShopTotalUnit")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  楽天発行クーポン利用数
                If orderElement.GetElementsByTagName("couponOtherTotalUnit").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("couponOtherTotalUnit")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  医薬品情報
                If orderElement.GetElementsByTagName("drugCategory").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("drugCategory")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                '  楽天スーパーDEAL
                If orderElement.GetElementsByTagName("deal").Count > 0 Then
                    csvOrder(0) = csvOrder(0) & editCsvColmun(orderElement.GetElementsByTagName("deal")(0).InnerText)
                Else
                    csvOrder(0) = csvOrder(0) & editCsvColmun("")
                End If

                ' 注文者情報モデル
                personList = orderElement.GetElementsByTagName("ordererModel")

                If personList.Count = 0 Then
                    ReDim csvPersonModel(0)
                    ' 空のカラムを生成する
                    csvPersonModel(0) = brankCsv(18)
                Else
                    ReDim csvPersonModel(personList.Count - 1)

                    For j As Integer = 0 To personList.Count - 1
                        personNode = personList.Item(j)

                        personElement = personNode

                        '  郵便番号1
                        If personElement.GetElementsByTagName("zipCode1").Count > 0 Then
                            csvPersonModel(j) = editCsvColmun(personElement.GetElementsByTagName("zipCode1")(0).InnerText)
                        Else
                            csvPersonModel(j) = editCsvColmun("")
                        End If

                        '  郵便番号2
                        If personElement.GetElementsByTagName("zipCode2").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("zipCode2")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  都道府県
                        If personElement.GetElementsByTagName("prefecture").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("prefecture")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  市区町村
                        If personElement.GetElementsByTagName("city").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("city")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  それ以降の住所
                        If personElement.GetElementsByTagName("subAddress").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("subAddress")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  姓漢字
                        If personElement.GetElementsByTagName("familyName").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("familyName")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  名漢字
                        If personElement.GetElementsByTagName("firstName").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("firstName")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  姓カナ
                        If personElement.GetElementsByTagName("familyNameKana").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("familyNameKana")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  名カナ
                        If personElement.GetElementsByTagName("firstNameKana").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("firstNameKana")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  電話番号1
                        If personElement.GetElementsByTagName("phoneNumber1").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("phoneNumber1")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  電話番号2
                        If personElement.GetElementsByTagName("phoneNumber2").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("phoneNumber2")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  電話番号3
                        If personElement.GetElementsByTagName("phoneNumber3").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("phoneNumber3")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  メールアドレス
                        If personElement.GetElementsByTagName("emailAddress").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("emailAddress")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  性別
                        If personElement.GetElementsByTagName("sex").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("sex")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  誕生日(年)
                        If personElement.GetElementsByTagName("birthYear").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("birthYear")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  誕生日(月)
                        If personElement.GetElementsByTagName("birthMonth").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("birthMonth")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  誕生日(日)
                        If personElement.GetElementsByTagName("birthDay").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("birthDay")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                        '  ニックネーム
                        If personElement.GetElementsByTagName("nickname").Count > 0 Then
                            csvPersonModel(j) = _
                                csvPersonModel(j) & editCsvColmun(personElement.GetElementsByTagName("nickname")(0).InnerText)
                        Else
                            csvPersonModel(j) = csvPersonModel(j) & editCsvColmun("")
                        End If

                    Next j
                End If ' END：注文者情報モデル

                ' 通常注文モデル
                normalOrderList = orderElement.GetElementsByTagName("normalOrderModel")

                If normalOrderList.Count = 0 Then
                    ReDim csvNormalOrder(0)
                    ' 空のカラムを生成する
                    csvNormalOrder(0) = brankCsv(4)
                Else
                    ReDim csvNormalOrder(normalOrderList.Count - 1)

                    For k As Integer = 0 To normalOrderList.Count - 1
                        normalOrderNode = normalOrderList.Item(k)

                        normalOrderElement = normalOrderNode

                        '  定期購入申込番号
                        If normalOrderElement.GetElementsByTagName("reserveNumber").Count > 0 Then
                            csvNormalOrder(k) = editCsvColmun(normalOrderElement.GetElementsByTagName("reserveNumber")(0).InnerText)
                        Else
                            csvNormalOrder(k) = editCsvColmun("")
                        End If

                        '  定期購入詳細ID
                        If normalOrderElement.GetElementsByTagName("detailId").Count > 0 Then
                            csvNormalOrder(k) = _
                                csvNormalOrder(k) & editCsvColmun(normalOrderElement.GetElementsByTagName("detailId")(0).InnerText)
                        Else
                            csvNormalOrder(k) = csvNormalOrder(k) & editCsvColmun("")
                        End If

                        '  定期購入商品種別
                        If normalOrderElement.GetElementsByTagName("reserveType").Count > 0 Then
                            csvNormalOrder(k) = _
                                csvNormalOrder(k) & editCsvColmun(normalOrderElement.GetElementsByTagName("reserveType")(0).InnerText)
                        Else
                            csvNormalOrder(k) = csvNormalOrder(k) & editCsvColmun("")
                        End If

                        '  定期購入申込日時
                        If normalOrderElement.GetElementsByTagName("reserveDatetime").Count > 0 Then
                            csvNormalOrder(k) = _
                                csvNormalOrder(k) & editCsvColmun(normalOrderElement.GetElementsByTagName("reserveDatetime")(0).InnerText)
                        Else
                            csvNormalOrder(k) = csvNormalOrder(k) & editCsvColmun("")
                        End If

                    Next k
                End If ' END：通常注文モデル

                ' オークション注文モデル
                saOrderList = orderElement.GetElementsByTagName("saOrderModel")

                If saOrderList.Count = 0 Then
                    ReDim csvSaOrder(0)
                    ' 空のカラムを生成する
                    csvSaOrder(0) = brankCsv(3)
                Else
                    ReDim csvSaOrder(saOrderList.Count - 1)

                    For l As Integer = 0 To saOrderList.Count - 1

                        saOrderNode = saOrderList.Item(l)

                        saOrderElement = saOrderNode

                        '  ビッドID
                        If saOrderElement.GetElementsByTagName("bidId").Count > 0 Then
                            csvSaOrder(l) = editCsvColmun(saOrderElement.GetElementsByTagName("bidId")(0).InnerText)
                        Else
                            csvSaOrder(l) = editCsvColmun("")
                        End If

                        '  結果発表日
                        If saOrderElement.GetElementsByTagName("regDate").Count > 0 Then
                            csvSaOrder(l) = _
                                csvSaOrder(l) & editCsvColmun(saOrderElement.GetElementsByTagName("regDate")(0).InnerText)
                        Else
                            csvSaOrder(l) = csvSaOrder(l) & editCsvColmun("")
                        End If

                        '  コメント
                        If saOrderElement.GetElementsByTagName("comment").Count > 0 Then
                            csvSaOrder(l) = _
                                csvSaOrder(l) & editCsvColmun(saOrderElement.GetElementsByTagName("comment")(0).InnerText)
                        Else
                            csvSaOrder(l) = csvSaOrder(l) & editCsvColmun("")
                        End If

                    Next l
                End If ' END：オークション注文モデル

                ' 共同購入注文モデル
                guOrderList = orderElement.GetElementsByTagName("gbuyOrderModel")

                If guOrderList.Count = 0 Then
                    ReDim csvGuOrder(0)
                    ' 空のカラムを生成する
                    csvGuOrder(0) = brankCsv(2)
                Else
                    ReDim csvGuOrder(guOrderList.Count - 1)

                    For m As Integer = 0 To guOrderList.Count - 1
                        guOrderNode = guOrderList.Item(m)

                        guOrderElement = guOrderNode

                        '  ビッドID
                        If guOrderElement.GetElementsByTagName("bidId").Count > 0 Then
                            csvGuOrder(m) = editCsvColmun(guOrderElement.GetElementsByTagName("bidId")(0).InnerText)
                        Else
                            csvGuOrder(m) = editCsvColmun("")
                        End If

                        '  コメント
                        If guOrderElement.GetElementsByTagName("comment").Count > 0 Then
                            csvGuOrder(m) = _
                                csvGuOrder(m) & editCsvColmun(guOrderElement.GetElementsByTagName("comment")(0).InnerText)
                        Else
                            csvGuOrder(m) = csvGuOrder(m) & editCsvColmun("")
                        End If
                    Next m
                End If ' END：共同購入注文モデル

                ' 支払方法モデル
                settlementList = orderElement.GetElementsByTagName("settlementModel")

                If settlementList.Count = 0 Then
                    ReDim csvSettlement(0)
                    ' 空のカラムを生成する
                    csvSettlement(0) = brankCsv(6)
                Else
                    ReDim csvSettlement(settlementList.Count - 1)

                    For n As Integer = 0 To settlementList.Count - 1
                        settlementNode = settlementList.Item(n)

                        settlementElement = settlementNode

                        ' 支払方法名
                        If settlementElement.GetElementsByTagName("settlementName").Count > 0 Then
                            csvSettlement(n) = editCsvColmun(settlementElement.GetElementsByTagName("settlementName")(0).InnerText)
                        Else
                            csvSettlement(n) = editCsvColmun("")
                        End If

                        ' クレジットカードモデル
                        cardList = settlementElement.GetElementsByTagName("cardModel")

                        If cardList.Count = 0 Then
                            ReDim csvCard(0)
                            ' 空のカラムを生成する
                            csvCard(0) = brankCsv(6)
                        Else
                            ReDim csvCard(cardList.Count - 1)

                            For o As Integer = 0 To cardList.Count - 1
                                cardNode = cardList.Item(o)

                                cardElement = cardNode

                                ' ブランド名
                                If cardElement.GetElementsByTagName("brandName").Count > 0 Then
                                    csvCard(o) = editCsvColmun(cardElement.GetElementsByTagName("brandName")(0).InnerText)
                                Else
                                    csvCard(o) = editCsvColmun("")
                                End If

                                ' カード番号
                                If cardElement.GetElementsByTagName("cardNo").Count > 0 Then
                                    csvCard(o) = _
                                        csvCard(o) & editCsvColmun(cardElement.GetElementsByTagName("cardNo")(0).InnerText)
                                Else
                                    csvCard(o) = csvCard(o) & editCsvColmun("")
                                End If

                                ' 名義人
                                If cardElement.GetElementsByTagName("ownerName").Count > 0 Then
                                    csvCard(o) = _
                                        csvCard(o) & editCsvColmun(cardElement.GetElementsByTagName("ownerName")(0).InnerText)
                                Else
                                    csvCard(o) = csvCard(o) & editCsvColmun("")
                                End If

                                ' 有効期限
                                If cardElement.GetElementsByTagName("expYM").Count > 0 Then
                                    csvCard(o) = _
                                        csvCard(o) & editCsvColmun(cardElement.GetElementsByTagName("expYM")(0).InnerText)
                                Else
                                    csvCard(o) = csvCard(o) & editCsvColmun("")
                                End If

                                ' 分割選択（支払種別）
                                If cardElement.GetElementsByTagName("payType").Count > 0 Then
                                    csvCard(o) = _
                                        csvCard(o) & editCsvColmun(cardElement.GetElementsByTagName("payType")(0).InnerText)
                                Else
                                    csvCard(o) = csvCard(o) & editCsvColmun("")
                                End If

                                ' 分割備考
                                If cardElement.GetElementsByTagName("installmentDesc").Count > 0 Then
                                    csvCard(o) = _
                                        csvCard(o) & editCsvColmun(cardElement.GetElementsByTagName("installmentDesc")(0).InnerText)
                                Else
                                    csvCard(o) = csvCard(o) & editCsvColmun("")
                                End If

                            Next o
                        End If ' END：クレジットカードモデル

                    Next n
                End If ' END：支払方法モデル

                ' 配送方法モデル
                deliverytList = orderElement.GetElementsByTagName("deliveryModel")

                If deliverytList.Count = 0 Then
                    ReDim csvDelivery(0)
                    ' 空のカラムを生成する
                    csvDelivery(0) = brankCsv(2)
                Else
                    ReDim csvDelivery(deliverytList.Count - 1)

                    For p As Integer = 0 To deliverytList.Count - 1
                        deliveryNode = deliverytList.Item(p)

                        deliveryElement = deliveryNode

                        ' 配送方法名
                        If deliveryElement.GetElementsByTagName("deliveryName").Count > 0 Then
                            csvDelivery(p) = editCsvColmun(deliveryElement.GetElementsByTagName("deliveryName")(0).InnerText)
                        Else
                            csvDelivery(p) = editCsvColmun("")
                        End If

                        ' 配送区分
                        If deliveryElement.GetElementsByTagName("deliveryClass").Count > 0 Then
                            csvDelivery(p) = _
                                csvDelivery(p) & editCsvColmun(deliveryElement.GetElementsByTagName("deliveryClass")(0).InnerText)
                        Else
                            csvDelivery(p) = csvDelivery(p) & editCsvColmun("")
                        End If

                    Next p
                End If ' END:配送方法モデル

                ' ポイントモデル
                pointList = orderElement.GetElementsByTagName("pointModel")

                If pointList.Count = 0 Then
                    ReDim csvPoint(0)
                    ' 空のカラムを生成する
                    csvPoint(0) = brankCsv(3)
                Else
                    ReDim csvPoint(pointList.Count - 1)

                    For q As Integer = 0 To pointList.Count - 1
                        pointNode = pointList.Item(q)

                        pointElement = pointNode

                        ' 充当ポイント
                        If pointElement.GetElementsByTagName("usedPoint").Count > 0 Then
                            csvPoint(q) = editCsvColmun(pointElement.GetElementsByTagName("usedPoint")(0).InnerText)
                        Else
                            csvPoint(q) = editCsvColmun("")
                        End If

                        ' 使用条件
                        If pointElement.GetElementsByTagName("pointUsage").Count > 0 Then
                            csvPoint(q) = _
                                csvPoint(q) & editCsvColmun(pointElement.GetElementsByTagName("pointUsage")(0).InnerText)
                        Else
                            csvPoint(q) = csvPoint(q) & editCsvColmun("")
                        End If

                        ' 承認状態
                        If pointElement.GetElementsByTagName("status").Count > 0 Then
                            csvPoint(q) = _
                                csvPoint(q) & editCsvColmun(pointElement.GetElementsByTagName("status")(0).InnerText)
                        Else
                            csvPoint(q) = csvPoint(q) & editCsvColmun("")
                        End If

                    Next q
                End If ' END：ポイントモデル

                ' 楽天バンクモデル
                bankList = orderElement.GetElementsByTagName("pointModel")

                If bankList.Count = 0 Then
                    ReDim csvBank(0)
                    ' 空のカラムを生成する
                    csvBank(0) = brankCsv(5)
                Else
                    ReDim csvBank(bankList.Count - 1)

                    For r As Integer = 0 To bankList.Count - 1
                        bankNode = bankList.Item(r)

                        bankElement = bankNode

                        ' 充当ポイント
                        If bankElement.GetElementsByTagName("orderNumber").Count > 0 Then
                            csvBank(r) = editCsvColmun(bankElement.GetElementsByTagName("orderNumber")(0).InnerText)
                        Else
                            csvBank(r) = editCsvColmun("")
                        End If

                        ' 店舗ID
                        If bankElement.GetElementsByTagName("shopId").Count > 0 Then
                            csvBank(r) = _
                                csvBank(r) & editCsvColmun(bankElement.GetElementsByTagName("shopId")(0).InnerText)
                        Else
                            csvBank(r) = csvBank(r) & editCsvColmun("")
                        End If

                        ' 楽天バンク決済ステータス
                        If bankElement.GetElementsByTagName("rbankStatus").Count > 0 Then
                            csvBank(r) = _
                                csvBank(r) & editCsvColmun(bankElement.GetElementsByTagName("rbankStatus")(0).InnerText)
                        Else
                            csvBank(r) = csvBank(r) & editCsvColmun("")
                        End If

                        ' 振替手数料負担区分
                        If bankElement.GetElementsByTagName("rbCommissionPayer").Count > 0 Then
                            csvBank(r) = _
                                csvBank(r) & editCsvColmun(bankElement.GetElementsByTagName("rbCommissionPayer")(0).InnerText)
                        Else
                            csvBank(r) = csvBank(r) & editCsvColmun("")
                        End If

                        ' 振替手数料
                        If bankElement.GetElementsByTagName("transferCommission").Count > 0 Then
                            csvBank(r) = _
                                csvBank(r) & editCsvColmun(bankElement.GetElementsByTagName("transferCommission")(0).InnerText)
                        Else
                            csvBank(r) = csvBank(r) & editCsvColmun("")
                        End If

                    Next r
                End If ' END：楽天バンクモデル

                ' ラッピングモデル1
                wrapping1List = orderElement.GetElementsByTagName("wrappingModel1")

                If wrapping1List.Count = 0 Then
                    ReDim csvWrapping1(0)
                    ' 空のカラムを生成する
                    csvWrapping1(0) = brankCsv(5)
                Else
                    ReDim csvWrapping1(wrapping1List.Count - 1)

                    For s As Integer = 0 To wrapping1List.Count - 1
                        wrapping1Node = wrapping1List.Item(s)

                        wrapping1Element = wrapping1Node

                        ' ラッピングタイトル
                        If wrapping1Element.GetElementsByTagName("title").Count > 0 Then
                            csvWrapping1(s) = editCsvColmun(wrapping1Element.GetElementsByTagName("title")(0).InnerText)
                        Else
                            csvWrapping1(s) = editCsvColmun("")
                        End If

                        ' ラッピング名
                        If wrapping1Element.GetElementsByTagName("name").Count > 0 Then
                            csvWrapping1(s) = _
                                csvWrapping1(s) & editCsvColmun(wrapping1Element.GetElementsByTagName("name")(0).InnerText)
                        Else
                            csvWrapping1(s) = csvWrapping1(s) & editCsvColmun("")
                        End If

                        ' 料金
                        If wrapping1Element.GetElementsByTagName("price").Count > 0 Then
                            csvWrapping1(s) = _
                                csvWrapping1(s) & editCsvColmun(wrapping1Element.GetElementsByTagName("price")(0).InnerText)
                        Else
                            csvWrapping1(s) = csvWrapping1(s) & editCsvColmun("")
                        End If

                        ' 税込別
                        If wrapping1Element.GetElementsByTagName("isIncludedTax").Count > 0 Then
                            csvWrapping1(s) = _
                                csvWrapping1(s) & editCsvColmun(wrapping1Element.GetElementsByTagName("isIncludedTax")(0).InnerText)
                        Else
                            csvWrapping1(s) = csvWrapping1(s) & editCsvColmun("")
                        End If

                        ' ラッピング削除フラグ
                        If wrapping1Element.GetElementsByTagName("deleteWrappingFlg").Count > 0 Then
                            csvWrapping1(s) = _
                                csvWrapping1(s) & editCsvColmun(wrapping1Element.GetElementsByTagName("deleteWrappingFlg")(0).InnerText)
                        Else
                            csvWrapping1(s) = csvWrapping1(s) & editCsvColmun("")
                        End If

                    Next s
                End If ' END：ラッピングモデル1

                ' ラッピングモデル2
                wrapping2List = orderElement.GetElementsByTagName("wrappingModel2")

                If wrapping2List.Count = 0 Then
                    ReDim csvWrapping2(0)
                    ' 空のカラムを生成する
                    csvWrapping2(0) = brankCsv(5)
                Else
                    ReDim csvWrapping2(wrapping2List.Count - 1)

                    For t As Integer = 0 To wrapping2List.Count - 1
                        wrapping2Node = wrapping2List.Item(t)

                        wrapping2Element = wrapping2Node

                        ' ラッピングタイトル
                        If wrapping2Element.GetElementsByTagName("title").Count > 0 Then
                            csvWrapping2(t) = editCsvColmun(wrapping2Element.GetElementsByTagName("title")(0).InnerText)
                        Else
                            csvWrapping2(t) = editCsvColmun("")
                        End If

                        ' ラッピング名
                        If wrapping2Element.GetElementsByTagName("name").Count > 0 Then
                            csvWrapping2(t) = _
                                csvWrapping2(t) & editCsvColmun(wrapping2Element.GetElementsByTagName("name")(0).InnerText)
                        Else
                            csvWrapping2(t) = csvWrapping2(t) & editCsvColmun("")
                        End If

                        ' 料金
                        If wrapping2Element.GetElementsByTagName("price").Count > 0 Then
                            csvWrapping2(t) = _
                                csvWrapping2(t) & editCsvColmun(wrapping2Element.GetElementsByTagName("price")(0).InnerText)
                        Else
                            csvWrapping2(t) = csvWrapping2(t) & editCsvColmun("")
                        End If

                        ' 税込別
                        If wrapping2Element.GetElementsByTagName("isIncludedTax").Count > 0 Then
                            csvWrapping2(t) = _
                                csvWrapping2(t) & editCsvColmun(wrapping2Element.GetElementsByTagName("isIncludedTax")(0).InnerText)
                        Else
                            csvWrapping2(t) = csvWrapping2(t) & editCsvColmun("")
                        End If

                        ' ラッピング削除フラグ
                        If wrapping2Element.GetElementsByTagName("deleteWrappingFlg").Count > 0 Then
                            csvWrapping2(t) = _
                                csvWrapping2(t) & editCsvColmun(wrapping2Element.GetElementsByTagName("deleteWrappingFlg")(0).InnerText)
                        Else
                            csvWrapping2(t) = csvWrapping2(t) & editCsvColmun("")
                        End If

                    Next t
                End If ' END：ラッピングモデル2

                ' 送付先モデルリスト
                packageList = orderElement.GetElementsByTagName("packageModel")

                ReDim tmpPackage(0)
                ReDim csvPackage(0)

                If packageList.Count = 0 Then
                    ' 空のカラムを生成する
                    tmpPackage(0) = brankCsv(70)
                Else

                    For u As Integer = 0 To packageList.Count - 1

                        ReDim tmpPackage(0)

                        packageNode = packageList.Item(u)

                        packageElement = packageNode

                        ' 送付先キー
                        If packageElement.GetElementsByTagName("basketId").Count > 0 Then
                            tmpPackage(0) = editCsvColmun(packageElement.GetElementsByTagName("basketId")(0).InnerText)
                        Else
                            tmpPackage(0) = editCsvColmun("")
                        End If

                        ' 送料
                        If packageElement.GetElementsByTagName("postagePrice").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("postagePrice")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 代引料合計
                        If packageElement.GetElementsByTagName("deliveryPrice").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("deliveryPrice")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 消費税合計
                        If packageElement.GetElementsByTagName("goodsTax").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("goodsTax")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 商品合計金額
                        If packageElement.GetElementsByTagName("goodsPrice").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("goodsPrice")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' のし
                        If packageElement.GetElementsByTagName("noshi").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("noshi")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 発送番号
                        If packageElement.GetElementsByTagName("shippingNumber").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("shippingNumber")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 削除フラグ
                        If packageElement.GetElementsByTagName("deleteFlg").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("deleteFlg")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 配送業者ID
                        If packageElement.GetElementsByTagName("deliveryCompanyId").Count > 0 Then
                            tmpPackage(0) = _
                                tmpPackage(0) & editCsvColmun(packageElement.GetElementsByTagName("deliveryCompanyId")(0).InnerText)
                        Else
                            tmpPackage(0) = tmpPackage(0) & editCsvColmun("")
                        End If

                        ' 送付者情報モデル
                        senderList = packageElement.GetElementsByTagName("senderModel")

                        If senderList.Count = 0 Then
                            ReDim csvSender(0)
                            ' 空のカラムを生成する
                            csvSender(0) = brankCsv(18)
                        Else
                            ReDim csvSender(senderList.Count - 1)

                            For v As Integer = 0 To senderList.Count - 1
                                senderNode = senderList.Item(v)

                                senderElement = senderNode

                                '  郵便番号1
                                If senderElement.GetElementsByTagName("zipCode1").Count > 0 Then
                                    csvSender(v) = editCsvColmun(senderElement.GetElementsByTagName("zipCode1")(0).InnerText)
                                Else
                                    csvSender(v) = editCsvColmun("")
                                End If

                                '  郵便番号2
                                If senderElement.GetElementsByTagName("zipCode2").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("zipCode2")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  都道府県
                                If senderElement.GetElementsByTagName("prefecture").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("prefecture")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  市区町村
                                If senderElement.GetElementsByTagName("city").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("city")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  それ以降の住所
                                If senderElement.GetElementsByTagName("subAddress").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("subAddress")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  姓漢字
                                If senderElement.GetElementsByTagName("familyName").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("familyName")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  名漢字
                                If senderElement.GetElementsByTagName("firstName").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("firstName")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  姓カナ
                                If senderElement.GetElementsByTagName("familyNameKana").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("familyNameKana")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  名カナ
                                If senderElement.GetElementsByTagName("firstNameKana").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("firstNameKana")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  電話番号1
                                If senderElement.GetElementsByTagName("phoneNumber1").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("phoneNumber1")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  電話番号2
                                If senderElement.GetElementsByTagName("phoneNumber2").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("phoneNumber2")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  電話番号3
                                If senderElement.GetElementsByTagName("phoneNumber3").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("phoneNumber3")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  メールアドレス
                                If senderElement.GetElementsByTagName("emailAddress").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("emailAddress")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  性別
                                If senderElement.GetElementsByTagName("sex").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("sex")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  誕生日(年)
                                If senderElement.GetElementsByTagName("birthYear").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("birthYear")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  誕生日(月)
                                If senderElement.GetElementsByTagName("birthMonth").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("birthMonth")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  誕生日(日)
                                If senderElement.GetElementsByTagName("birthDay").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("birthDay")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                                '  ニックネーム
                                If senderElement.GetElementsByTagName("nickname").Count > 0 Then
                                    csvSender(v) = _
                                        csvSender(v) & editCsvColmun(senderElement.GetElementsByTagName("nickname")(0).InnerText)
                                Else
                                    csvSender(v) = csvSender(v) & editCsvColmun("")
                                End If

                            Next v
                        End If ' END：送付者情報モデル

                        mergeString(tmpPackage, csvSender)

                        ' コンビニ配送情報
                        cvsList = packageElement.GetElementsByTagName("deliveryCvsModel")

                        If cvsList.Count = 0 Then
                            ReDim csvCvs(0)
                            ' 空のカラムを生成する
                            csvCvs(0) = brankCsv(12)
                        Else
                            ReDim csvCvs(cvsList.Count - 1)

                            For w As Integer = 0 To cvsList.Count - 1

                                cvsNode = cvsList.Item(w)

                                cvsElement = cvsNode

                                '  コンビニコード
                                If cvsElement.GetElementsByTagName("cvsCode").Count > 0 Then
                                    csvCvs(w) = editCsvColmun(cvsElement.GetElementsByTagName("cvsCode")(0).InnerText)
                                Else
                                    csvCvs(w) = editCsvColmun("")
                                End If

                                ' ストア分類コード
                                If cvsElement.GetElementsByTagName("storeGenreCode").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storeGenreCode")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' ストアコード
                                If cvsElement.GetElementsByTagName("storeCode").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storeCode")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' ストア名称
                                If cvsElement.GetElementsByTagName("storeName").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storeName")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 郵便番号
                                If cvsElement.GetElementsByTagName("storeZip").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storeZip")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 都道府県
                                If cvsElement.GetElementsByTagName("storePrefecture").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storePrefecture")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' その他住所
                                If cvsElement.GetElementsByTagName("storeAddress").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("storeAddress")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 発注エリアコード
                                If cvsElement.GetElementsByTagName("areaCode").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("areaCode")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' センターデポコード
                                If cvsElement.GetElementsByTagName("depo").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("depo")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 開店時間
                                If cvsElement.GetElementsByTagName("cvsOpenTime").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("cvsOpenTime")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 閉店時間
                                If cvsElement.GetElementsByTagName("cvsCloseTime").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("cvsCloseTime")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                                ' 特記事項
                                If cvsElement.GetElementsByTagName("cvsBikou").Count > 0 Then
                                    csvCvs(w) = _
                                        csvCvs(w) & editCsvColmun(cvsElement.GetElementsByTagName("cvsBikou")(0).InnerText)
                                Else
                                    csvCvs(w) = csvCvs(w) & editCsvColmun("")
                                End If

                            Next w
                        End If ' END：コンビニ配送情報

                        mergeString(tmpPackage, csvCvs)

                        ' 商品モデルリスト
                        itemList = packageElement.GetElementsByTagName("itemModel")

                        If itemList.Count = 0 Then
                            ReDim csvItem(0)
                            ' 空のカラムを生成する
                            csvItem(0) = brankCsv(31)
                        Else
                            ReDim csvItem(itemList.Count - 1)

                            For x As Integer = 0 To itemList.Count - 1
                                itemNode = itemList.Item(x)

                                itemElement = itemNode

                                '  商品キー
                                If itemElement.GetElementsByTagName("basketId").Count > 0 Then
                                    csvItem(x) = editCsvColmun(itemElement.GetElementsByTagName("basketId")(0).InnerText)
                                Else
                                    csvItem(x) = editCsvColmun("")
                                End If

                                ' 商品ID
                                If itemElement.GetElementsByTagName("itemId").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("itemId")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 商品名
                                If itemElement.GetElementsByTagName("itemName").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("itemName")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 商品番号
                                If itemElement.GetElementsByTagName("itemNumber").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("itemNumber")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 商品URL
                                If itemElement.GetElementsByTagName("pageURL").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("pageURL")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 単価
                                If itemElement.GetElementsByTagName("price").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("price")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 個数
                                If itemElement.GetElementsByTagName("units").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("units")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 送料込別
                                If itemElement.GetElementsByTagName("isIncludedPostage").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("isIncludedPostage")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 税込別
                                If itemElement.GetElementsByTagName("isIncludedTax").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("isIncludedTax")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 代引手数料込別
                                If itemElement.GetElementsByTagName("isIncludedCashOnDeliveryPostage").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("isIncludedCashOnDeliveryPostage")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 項目・選択肢
                                If itemElement.GetElementsByTagName("selectedChoice").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("selectedChoice")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' ポイントレート
                                If itemElement.GetElementsByTagName("pointRate").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("pointRate")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' ポイントタイプ
                                If itemElement.GetElementsByTagName("pointType").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("pointType")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 商品削除フラグ
                                If itemElement.GetElementsByTagName("deleteItemFlg").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("deleteItemFlg")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 在庫連動オプション
                                If itemElement.GetElementsByTagName("restoreInventoryFlag").Count > 0 Then
                                    csvItem(x) = _
                                        csvItem(x) & editCsvColmun(itemElement.GetElementsByTagName("restoreInventoryFlag")(0).InnerText)
                                Else
                                    csvItem(x) = csvItem(x) & editCsvColmun("")
                                End If

                                ' 通常商品モデル
                                normalItemList = itemElement.GetElementsByTagName("normalItemModel")

                                If normalItemList.Count = 0 Then
                                    ReDim csvNormalItem(0)
                                    ' 空のカラムを生成する
                                    csvNormalItem(0) = brankCsv(2)
                                Else
                                    ReDim csvNormalItem(normalItemList.Count - 1)

                                    For y As Integer = 0 To normalItemList.Count - 1

                                        normalItemNode = normalItemList.Item(y)

                                        normalItemElement = normalItemNode

                                        '  納期情報
                                        If normalItemElement.GetElementsByTagName("delvdateInfo").Count > 0 Then
                                            csvNormalItem(y) = editCsvColmun(normalItemElement.GetElementsByTagName("delvdateInfo")(0).InnerText)
                                        Else
                                            csvNormalItem(y) = editCsvColmun("")
                                        End If

                                        ' 在庫タイプ
                                        If normalItemElement.GetElementsByTagName("inventoryType").Count > 0 Then
                                            csvNormalItem(y) = _
                                                csvNormalItem(y) & editCsvColmun(normalItemElement.GetElementsByTagName("inventoryType")(0).InnerText)
                                        Else
                                            csvNormalItem(y) = csvNormalItem(y) & editCsvColmun("")
                                        End If

                                    Next y
                                End If

                                mergeString(csvItem, csvNormalItem)

                                ' オークション商品モデル
                                ' 参照付加項目として定義されているので、マッピングしない

                                ' 共同購入商品モデル
                                groupItemList = itemElement.GetElementsByTagName("gbuyItemModel")

                                If groupItemList.Count = 0 Then
                                    ReDim csvGroupItem(0)
                                    ' 空のカラムを生成する
                                    csvGroupItem(0) = brankCsv(14)
                                Else
                                    ReDim csvGroupItem(groupItemList.Count - 1)

                                    For z As Integer = 0 To groupItemList.Count - 1

                                        groupItemNode = groupItemList.Item(z)

                                        groupItemElement = groupItemNode

                                        '  移行済
                                        If groupItemElement.GetElementsByTagName("isShiftStatus").Count > 0 Then
                                            csvGroupItem(z) = editCsvColmun(groupItemElement.GetElementsByTagName("isShiftStatus")(0).InnerText)
                                        Else
                                            csvGroupItem(z) = editCsvColmun("")
                                        End If

                                        ' 移行日時
                                        If groupItemElement.GetElementsByTagName("shiftDate").Count > 0 Then
                                            csvGroupItem(z) = _
                                                csvGroupItem(z) & editCsvColmun(groupItemElement.GetElementsByTagName("shiftDate")(0).InnerText)
                                        Else
                                            csvGroupItem(z) = csvGroupItem(z) & editCsvColmun("")
                                        End If

                                        ' 商品単位
                                        If groupItemElement.GetElementsByTagName("unitText").Count > 0 Then
                                            csvGroupItem(z) = _
                                                csvGroupItem(z) & editCsvColmun(groupItemElement.GetElementsByTagName("unitText")(0).InnerText)
                                        Else
                                            csvGroupItem(z) = csvGroupItem(z) & editCsvColmun("")
                                        End If

                                        ' 実販売数
                                        If groupItemElement.GetElementsByTagName("currentSumAmount").Count > 0 Then
                                            csvGroupItem(z) = _
                                                csvGroupItem(z) & editCsvColmun(groupItemElement.GetElementsByTagName("currentSumAmount")(0).InnerText)
                                        Else
                                            csvGroupItem(z) = csvGroupItem(z) & editCsvColmun("")
                                        End If

                                        ' 共同購入商品内訳モデルリスト
                                        groupChoiceList = groupItemElement.GetElementsByTagName("gbuyGchoiceModel")

                                        If groupChoiceList.Count = 0 Then
                                            ReDim csvGroupChoice(0)
                                            ' 空のカラムを生成する
                                            csvGroupChoice(0) = brankCsv(8)
                                        Else
                                            ReDim csvGroupChoice(groupChoiceList.Count - 1)

                                            For a As Integer = 0 To itemList.Count - 1

                                                groupChoiceNode = groupChoiceList.Item(z)

                                                groupChoiceElement = groupChoiceNode

                                                '  商品内訳ID
                                                If groupChoiceElement.GetElementsByTagName("gchoiceId").Count > 0 Then
                                                    csvGroupChoice(a) = editCsvColmun(groupChoiceElement.GetElementsByTagName("gchoiceId")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = editCsvColmun("")
                                                End If

                                                ' 商品ID
                                                If groupChoiceElement.GetElementsByTagName("itemId").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("itemId")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 表示順序
                                                If groupChoiceElement.GetElementsByTagName("orderby").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("orderby")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 項目名
                                                If groupChoiceElement.GetElementsByTagName("gchoiceName").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("gchoiceName")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 取り扱い個数
                                                If groupChoiceElement.GetElementsByTagName("gchoiceInvtry").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("gchoiceInvtry")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 最大購入個数
                                                If groupChoiceElement.GetElementsByTagName("gchoiceMaxUnits").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("gchoiceMaxUnits")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 内訳購入数量合計
                                                If groupChoiceElement.GetElementsByTagName("sumAmount").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("sumAmount")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                                ' 売り切れフラグ
                                                If groupChoiceElement.GetElementsByTagName("soldFlag").Count > 0 Then
                                                    csvGroupChoice(a) = _
                                                         csvGroupChoice(a) & editCsvColmun(groupChoiceElement.GetElementsByTagName("soldFlag")(0).InnerText)
                                                Else
                                                    csvGroupChoice(a) = csvGroupChoice(a) & editCsvColmun("")
                                                End If

                                            Next a
                                        End If ' END：共同購入商品内訳モデルリスト

                                        ' 共同購入商品内訳モデルリスト
                                        groupInvList = groupItemElement.GetElementsByTagName("gbuyBidInventoryModel")

                                        If groupInvList.Count = 0 Then
                                            ReDim csvGroupInv(0)
                                            ' 空のカラムを生成する
                                            csvGroupInv(0) = brankCsv(2)
                                        Else
                                            ReDim csvGroupInv(groupInvList.Count - 1)

                                            For b As Integer = 0 To groupInvList.Count - 1

                                                groupInvNode = groupInvList.Item(z)

                                                groupInvElement = groupInvNode

                                                '  商品内訳ID
                                                If groupInvElement.GetElementsByTagName("gchoiceId").Count > 0 Then
                                                    csvGroupInv(b) = editCsvColmun(groupInvElement.GetElementsByTagName("gchoiceId")(0).InnerText)
                                                Else
                                                    csvGroupInv(b) = editCsvColmun("")
                                                End If

                                                ' 購入数
                                                If groupInvElement.GetElementsByTagName("bidUnits").Count > 0 Then
                                                    csvGroupInv(b) = _
                                                        csvGroupInv(b) & editCsvColmun(groupInvElement.GetElementsByTagName("bidUnits")(0).InnerText)
                                                Else
                                                    csvGroupInv(b) = csvGroupInv(b) & editCsvColmun("")
                                                End If

                                            Next b
                                        End If ' END：共同購入商品内訳モデルリスト

                                    Next z
                                End If ' END：共同購入商品モデル

                            Next x
                        End If ' END：商品モデルリスト

                        mergeString(csvGroupItem, csvGroupChoice)

                        mergeString(csvGroupItem, csvGroupInv)

                        mergeString(csvItem, csvGroupItem)

                        mergeString(tmpPackage, csvItem)

                        For c As Integer = 0 To tmpPackage.Count - 1

                            If csvPackage.Length = 1 _
                            And csvPackage(0) = Nothing Then
                                csvPackage(0) = tmpPackage(c)
                            ElseIf csvPackage.Length >= 1 _
                            And csvPackage(0) <> Nothing Then

                                ReDim Preserve csvPackage(csvPackage.Length)

                                csvPackage(csvPackage.Length - 1) = tmpPackage(c)
                            End If

                        Next c
                    Next u
                End If ' END：送付先モデルリスト

                ' クーポンモデルリスト
                couponList = orderElement.GetElementsByTagName("couponModel")

                If couponList.Count = 0 Then
                    ReDim csvCoupon(0)
                    ' 空のカラムを生成する
                    csvCoupon(0) = brankCsv(12)
                Else
                    ReDim csvCoupon(couponList.Count - 1)

                    For c As Integer = 0 To couponList.Count - 1

                        couponNode = couponList.Item(c)

                        couponElement = couponNode

                        '  クーポンコード
                        If couponElement.GetElementsByTagName("couponCode").Count > 0 Then
                            csvCoupon(c) = editCsvColmun(couponElement.GetElementsByTagName("couponCode")(0).InnerText)
                        Else
                            csvCoupon(c) = editCsvColmun("")
                        End If

                        ' 商品ID
                        If couponElement.GetElementsByTagName("itemId").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("itemId")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン名
                        If couponElement.GetElementsByTagName("couponName").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponName")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン効果(サマリー)
                        If couponElement.GetElementsByTagName("couponSummary").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponSummary")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン利用方法
                        If couponElement.GetElementsByTagName("couponUsage").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponUsage")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン利用数
                        If couponElement.GetElementsByTagName("couponUnit").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponUnit")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン原資コード
                        If couponElement.GetElementsByTagName("couponCapital").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponCapital")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン割引単価
                        If couponElement.GetElementsByTagName("couponPrice").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponPrice")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' 割引タイプ
                        If couponElement.GetElementsByTagName("discountType").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("discountType")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' 有効期限
                        If couponElement.GetElementsByTagName("expiryDate").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("expiryDate")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' 課金フラグ
                        If couponElement.GetElementsByTagName("feeFlag").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("feeFlag")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                        ' クーポン利用金額
                        If couponElement.GetElementsByTagName("couponTotalPrice").Count > 0 Then
                            csvCoupon(c) = _
                                csvCoupon(c) & editCsvColmun(couponElement.GetElementsByTagName("couponTotalPrice")(0).InnerText)
                        Else
                            csvCoupon(c) = csvCoupon(c) & editCsvColmun("")
                        End If

                    Next c
                End If

                mergeString(csvOrder, csvPersonModel)

                mergeString(csvOrder, csvNormalOrder)

                mergeString(csvOrder, csvSaOrder)

                mergeString(csvOrder, csvGuOrder)

                mergeString(csvSettlement, csvCard)

                mergeString(csvOrder, csvSettlement)

                mergeString(csvOrder, csvDelivery)

                mergeString(csvOrder, csvPoint)

                mergeString(csvOrder, csvBank)

                mergeString(csvOrder, csvWrapping1)

                mergeString(csvOrder, csvWrapping2)

                mergeString(csvOrder, csvPackage)

                mergeString(csvOrder, csvCoupon)

                ' 受注番号ごとにCSVファイルへ出力
                For Each Line As String In csvOrder
                    rakutenTmp.WriteLine(Line)
                Next

            Next i

            ' 一時ファイルをクローズ
            rakutenTmp.Close()

        Catch ex As Exception
            log.write(msg)
            log.write(ex)
        Finally
            xmlDoc = Nothing

        End Try
    End Sub
    ' -------------------------------------------------------------------- 
    ' 空項目を作成
    ' -------------------------------------------------------------------- 
    Private Function brankCsv(ByVal columnCount As Integer) As String
        Dim brankData As String

        brankData = ""

        ' パラメータで指定された回数分の空のカラムを生成する
        For i As Integer = 0 To columnCount - 1
            brankData = brankData & editCsvColmun("")
        Next i

        Return brankData
    End Function
    ' -------------------------------------------------------------------- 
    ' 親階層と子階層をマージ
    ' -------------------------------------------------------------------- 
    Private Sub mergeString(ByRef baseString() As String, ByRef addString() As String)
        Dim tmpString1() As String
        Dim tmpString2() As String
        Dim tmpCount As Integer

        Dim m As Integer

        ' マージ対象の文字列が設定されていることを確認
        If addString.Length > 0 _
        And addString(0) <> Nothing Then

            tmpCount = baseString.Length * addString.Length

            ReDim tmpString1(tmpCount - 1)
            ReDim tmpString2(tmpCount - 1)

            ' 親レコードの件数と子レコードの件数が一致しない場合
            If baseString.Length <> addString.Length Then

                m = 0

                ' 親レコードの件数分ループ
                For k As Integer = 0 To baseString.Length - 1

                    ' 子レコードの件数分ループ
                    For l As Integer = 0 To addString.Length - 1
                        tmpString1(m) = baseString(k)
                        tmpString2(m) = addString(l)

                        m = m + 1
                    Next l

                Next k
            Else
                tmpString1 = baseString
                tmpString2 = addString

            End If

            ReDim baseString(tmpCount - 1)

            ' 親レコードの末尾に子レコードを追加する
            For k As Integer = 0 To baseString.Length - 1
                baseString(k) = tmpString1(k) & tmpString2(k)
            Next k

        End If

    End Sub
    ' -------------------------------------------------------------------- 
    ' CSVファイル(一時用)からCSVファイル(取込用)へマッピング処理
    ' -------------------------------------------------------------------- 
    Private Sub editRakutenCSV()
        Dim tmpCsv As FileIO.TextFieldParser
        Dim enc As Encoding
        Dim tmpFields As String()
        Dim tmpData As New System.Collections.ArrayList


        Dim rakutenCsv As StreamWriter

        Dim tmpCount As Integer
        Dim paperType As String
        Dim paperSummary As Integer
        Dim ribbonType As String
        Dim ribbonSummary As Integer

        Dim titleCsv As String
        Dim datCsv() As String

        Dim csvHeader() As String = {"受注番号", "レコードナンバー", "注文日", "注文時間", "商品名" _
                                     , "商品番号", "個数", "単価", "項目・選択肢", "注文者名字" _
                                    , "注文者名前", "注文者名字フリガナ", "注文者名前フリガナ" _
                                    , "メールアドレス", "注文者郵便番号１", "注文者郵便番号２" _
                                    , "注文者住所：都道府県", "注文者住所：都市区", "注文者住所：町以降" _
                                    , "注文者電話番号１", "注文者電話番号２", "注文者電話番号３" _
                                    , "注文者性別", "注文者誕生日", "送付先名字", "送付先名前" _
                                    , "送付先名字フリガナ", "送付先名前フリガナ", "送付先郵便番号１" _
                                    , "送付先郵便番号２", "送付先住所：都道府県", "送付先住所：都市区" _
                                    , "送付先住所：町以降", "送付先電話番号１", "送付先電話番号２" _
                                    , "送付先電話番号３", "のし", "決済方法", "クレジットカード種類" _
                                    , "クレジットカード番号", "クレジットカード名義人", "クレジットカード有効期限" _
                                    , "クレジットカード分割選択", "クレジットカード分割備考", "配送方法" _
                                    , "コメント", "ラッピング種類(包装紙)", "ラッピング種類(リボン)" _
                                    , "ラッピング料金(包装紙)", "ラッピング料金(リボン)", "ギフトチェック（0:なし/1:あり）" _
                                    , "合計", "送料(-99999=無効値)", "消費税(-99999=無効値)", "代引料(-99999=無効値)" _
                                    , "請求金額(-99999=無効値)", "利用端末", "ポイント利用有無" _
                                    , "ポイント利用条件", "ポイント利用額", "ポイントステータス" _
                                    , "合計金額(-99999=無効値)", "楽天バンク決済手数料", "ひとことメモ"}

        enc = System.Text.Encoding.GetEncoding("UTF-8")

        tmpCsv = New FileIO.TextFieldParser(csvSavePath & "\" & TMP_FILE_NAME, enc)

        tmpCsv.TextFieldType = FileIO.FieldType.Delimited

        tmpCsv.Delimiters = New String() {","}

        tmpCsv.HasFieldsEnclosedInQuotes = True

        tmpCsv.TrimWhiteSpace = True


        tmpCount = 0

        ' 一時ファイルの全データを読み込む
        While Not tmpCsv.EndOfData
            tmpFields = tmpCsv.ReadFields()
            tmpData.Add(tmpFields)

 tmpCount = tmpCount + 1
        End While

        ' 一時CSVのデータが抽出できた場合、取込用CSVを作成する
        ' →画面からダウンロードする際、0件であれば取込用CSVを作成していない
        If tmpCount > 0 Then

            titleCsv = ""

            ' CSVファイルのオープン
            rakutenCsv = New StreamWriter(csvSavePath & "\" & CSV_FILE_NAME, False, enc)

            ' ヘッダを作成
            For j As Integer = 0 To csvHeader.Length - 1
                titleCsv = titleCsv & editCsvColmun(csvHeader(j))
            Next j

            ReDim datCsv(tmpData.Count - 1)

            ' 読み込んだ要素数分、レコードを編集する
            For i As Integer = 0 To tmpData.Count - 1

                ' 受注番号
                datCsv(i) = editCsvColmun(CType(tmpData.Item(i)(0), String))

                ' レコードナンバー
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(143), String))

                ' 注文日
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(16), Date).ToString("d"))

                ' 注文時間
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(16), Date).ToString("HH:mm:ss"))

                ' (商品情報)商品名
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(145), String))

                ' (商品情報)商品番号
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(146), String))

                ' (商品情報)個数
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(149), String))

                ' (商品情報)単価
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(148), String))

                ' (商品情報)項目・選択肢
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(153), String))

                ' (注文者情報)姓漢字
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(55), String))

                ' (注文者情報)名漢字
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(56), String))

                ' (注文者情報)姓カナ
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(57), String))

                ' (注文者情報)名カナ
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(58), String))

                ' (注文者情報)メールアドレス
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(62), String))

                ' (注文者情報)郵便番号1
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(50), String))

                ' (注文者情報)郵便番号2
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(51), String))

                ' (注文者情報)都道府県
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(52), String))

                ' (注文者情報)市区町村
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(53), String))

                ' (注文者情報)それ以降の住所
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(54), String))

                ' (注文者情報)電話番号1
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(59), String))

                ' (注文者情報)電話番号2
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(60), String))

                ' (注文者情報)電話番号3
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(61), String))

                ' (注文者情報)性別
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(63), String))

                ' 注文者誕生日
                ' →マッピング元項目が存在しないため、固定値を設定
                datCsv(i) = datCsv(i) & _
                            editCsvColmun("-年-月-日")

                ' (送付者情報)姓漢字
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(118), String))

                ' (送付者情報)名漢字
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(119), String))

                ' (送付者情報)姓カナ
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(120), String))

                ' (送付者情報)名カナ
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(121), String))

                ' (送付者情報)郵便番号1
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(113), String))

                ' (送付者情報)郵便番号2
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(114), String))

                ' (送付者情報)都道府県
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(115), String))

                ' (送付者情報)市区町村
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(116), String))

                ' (送付者情報)それ以降の住所
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(117), String))

                ' (送付者情報)電話番号1
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(122), String))

                ' (送付者情報)電話番号2
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(123), String))

                ' (送付者情報)電話番号3
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(124), String))

                ' (送付先情報)のし
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(109), String))

                ' 支払方法名
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(77), String))

                ' (クレジットカード情報)ブランド名
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(78), String))

                ' クレジットカード番号、クレジットカード名義人、クレジットカード有効期限
                ' →固定値
                datCsv(i) = datCsv(i) & editCsvColmun("（非表示）") & _
                                        editCsvColmun("（非表示）") & _
                                        editCsvColmun("（非表示）")

                ' クレジットカード分割選択
                If CType(tmpData.Item(i)(82), String) <> Nothing Then

                    Select Case CType(tmpData.Item(i)(82), String)
                        Case "0"
                            ' 一括払いの場合
                            datCsv(i) = datCsv(i) & editCsvColmun("0")
                        Case "1"
                            ' リボ払いの場合
                            datCsv(i) = datCsv(i) & editCsvColmun("1")
                        Case "3"
                            ' その他の場合
                            datCsv(i) = datCsv(i) & editCsvColmun("3")
                        Case "4"
                            ' ボーナス一括の場合
                            datCsv(i) = datCsv(i) & editCsvColmun("4")
                        Case "103", "105", "106", "110", "112", "115", "118", "120", "124"
                            ' 分割の場合
                            datCsv(i) = datCsv(i) & editCsvColmun("2")
                        Case Else
                            datCsv(i) = datCsv(i) & editCsvColmun("0")
                    End Select
                Else
                    datCsv(i) = datCsv(i) & editCsvColmun("0")
                End If

                ' クレジットカード分割備考
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(83) & "回", String))

                ' 配送方法
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(84), String))

                ' コメント
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(15), String))

                ' ラッピング情報の集計
                paperType = ""
                paperSummary = 0
                ribbonType = ""
                ribbonSummary = 0

                summaryWrapping(CType(tmpData.Item(i)(94), String), _
                                CType(tmpData.Item(i)(95), String), _
                                CType(tmpData.Item(i)(96), String), _
                                CType(tmpData.Item(i)(99), String), _
                                CType(tmpData.Item(i)(100), String), _
                                CType(tmpData.Item(i)(101), String), _
                                paperType, _
                                paperSummary, _
                                ribbonType, _
                                ribbonSummary)

                ' ラッピング種類(包装紙)
                datCsv(i) = datCsv(i) & editCsvColmun(paperType)

                ' ラッピング種類(リボン)
                datCsv(i) = datCsv(i) & editCsvColmun(ribbonType)

                ' ラッピング料金(包装紙)
                datCsv(i) = datCsv(i) & editCsvColmun(paperSummary.ToString)

                ' ラッピング料金(リボン)
                datCsv(i) = datCsv(i) & editCsvColmun(ribbonSummary.ToString)

                ' ギフトチェック（0:なし/1:あり）
                If CType(tmpData.Item(i)(13), Boolean) Then
                    datCsv(i) = datCsv(i) & editCsvColmun("1")
                Else
                    datCsv(i) = datCsv(i) & editCsvColmun("0")
                End If

                ' 合計
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(23), String))

                ' 送料
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(25), String))

                ' 消費税
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(24), String))

                ' 代引料
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(26), String))

                ' 請求金額
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(27), String))

                ' 利用端末
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(11), String))

                ' ポイント利用有無(ポイント利用額の設定有無で判断)
                If CType(tmpData.Item(i)(86), String) <> Nothing Then
                    datCsv(i) = datCsv(i) & editCsvColmun("1")
                Else
                    datCsv(i) = datCsv(i) & editCsvColmun("0")
                End If

                ' ポイント利用条件　
                ' →該当項目がAPIで抽出されていないため、ブランクを設定
                datCsv(i) = datCsv(i) & editCsvColmun("")

                ' ポイント利用額
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(86), String))

                ' ポイントステータス
                If CType(tmpData.Item(i)(88), String) <> Nothing Then
                    datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(88), String))
                Else
                    datCsv(i) = datCsv(i) & editCsvColmun("0")
                End If

                ' 合計金額
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(28), String))

                ' 楽天バンク決済手数料
                If CType(tmpData.Item(i)(93), String) <> Nothing Then
                    datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(93), String))
                Else
                    datCsv(i) = datCsv(i) & editCsvColmun("0")
                End If

                ' ひとことメモ
                datCsv(i) = datCsv(i) & editCsvColmun(CType(tmpData.Item(i)(8), String))

            Next i

            ' ヘッダ部をCSVファイルに書き込み
            rakutenCsv.WriteLine(titleCsv)

            ' データ部を全行CSVファイルに書き込み
            For Each line As String In datCsv

                rakutenCsv.WriteLine(line)

            Next

            ' 取込用CSVをクローズ
            rakutenCsv.Close()

        End If

        ' 一時CSVをクローズ
        tmpCsv.Close()

    End Sub
    ' -------------------------------------------------------------------- 
    ' CSVのカラムを編集
    ' -------------------------------------------------------------------- 
    Private Function editCsvColmun(ByVal datStr As String) As String
        Dim editData As String

        editData = """" & datStr & ""","

        Return editData
    End Function
    ' -------------------------------------------------------------------- 
    ' ラッピング項目の集計
    ' -------------------------------------------------------------------- 
    Private Sub summaryWrapping(ByVal wrappingTitle1 As String, _
                                ByVal wrappingName1 As String, _
                                ByVal wrappingPrice1 As String, _
                                ByVal wrappingTitle2 As String, _
                                ByVal wrappingName2 As String, _
                                ByVal wrappingPrice2 As String, _
                                ByRef paperType As String, _
                                ByRef paperSummary As Integer, _
                                ByRef ribbonType As String, _
                                ByRef ribbonSummary As Integer)

        ' 包装紙の項目集計
        If wrappingTitle1 = WRAPPING_PAPER Then
            paperType = wrappingTitle1 & ":" & wrappingName1
            paperSummary = Integer.Parse(wrappingPrice1)
        ElseIf wrappingTitle2 = WRAPPING_PAPER Then
            paperType = wrappingTitle2 & ":" & wrappingName2
            paperSummary = Integer.Parse(wrappingPrice2)
        Else
            paperType = ""
            paperSummary = 0
        End If

        ' リボンの項目集計
        If wrappingTitle1 = WRAPPING_RIBBON Then
            ribbonType = wrappingTitle1 & ":" & wrappingName1
            ribbonSummary = Integer.Parse(wrappingPrice1)
        ElseIf wrappingTitle2 = WRAPPING_RIBBON Then
            ribbonType = wrappingTitle2 & ":" & wrappingName2
            ribbonSummary = Integer.Parse(wrappingPrice2)
        Else
            ribbonType = ""
            ribbonSummary = 0
        End If

    End Sub

End Class
