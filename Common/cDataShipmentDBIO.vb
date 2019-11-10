
Public Class cDataShipmentDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    '-------------------------------------------------------------------------------
    '　機能：出荷情報データから該当レコードを取得する関数
    '　引数：Byref parShipment()　：データセットバッファ（sShipment Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Shipment_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Shipment_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getShipment(ByRef parShipmentData() As cStructureLib.sShipmentData,
                                    ByVal KeyRequestCode As String,
                                    ByVal KeyChannelCode As Integer,
                                    ByVal KeyShipCode As String,
                                    ByVal KeyShipDate As String,
                                    ByVal KeysDeleveryCSVOutoutFlg As Boolean,
                                    ByVal KeyFromDate As String,
                                    ByVal KeyToDate As String,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction
                               ) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim maxpc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 出荷情報データ "
        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyChannelCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyShipCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyShipDate <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeysDeleveryCSVOutoutFlg <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyFromDate <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyToDate <> Nothing Then
            maxpc = 64
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
                        strSelect = strSelect & "受注コード= """ & KeyRequestCode & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= " & KeyShipCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷コード= """ & KeyShipCode & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 Like ""%" & KeyShipDate & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "配送伝票CSV出力フラグ = " & KeysDeleveryCSVOutoutFlg & " "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷日 >= """ & KeyShipDate & """ "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷日 <= """ & KeyShipDate & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parShipmentData(i)

                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parShipmentData(i).sChannelCode = 0
                Else
                    parShipmentData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                '出荷コード
                parShipmentData(i).sShipCode = pDataReader("出荷コード").ToString
                '受注コード
                parShipmentData(i).sRequestCode = pDataReader("受注コード").ToString
                '出荷日
                parShipmentData(i).sShipDate = pDataReader("出荷日").ToString
                '荷物受渡番号
                parShipmentData(i).sDeliveryNumber = pDataReader("荷物受渡番号").ToString
                '出荷先電話番号
                parShipmentData(i).sTel = pDataReader("出荷先電話番号").ToString
                '出荷先郵便番号
                parShipmentData(i).sPostalCode = pDataReader("出荷先郵便番号").ToString
                '出荷先住所1
                parShipmentData(i).sAddress1 = pDataReader("出荷先住所1").ToString
                '出荷先住所2
                parShipmentData(i).sAddress2 = pDataReader("出荷先住所2").ToString
                '出荷先住所3
                parShipmentData(i).sAddress3 = pDataReader("出荷先住所3").ToString
                '出荷先姓
                parShipmentData(i).sFirstName = pDataReader("出荷先姓").ToString
                '出荷先名
                parShipmentData(i).sLastName = pDataReader("出荷先名").ToString
                '配達日
                parShipmentData(i).sShipRequestDate = pDataReader("配達日").ToString
                '配達指定時間帯
                parShipmentData(i).sShipRequestTimeClass = pDataReader("配達指定時間帯").ToString
                '配達指定時間
                parShipmentData(i).sShipRequestTime = pDataReader("配達指定時間").ToString
                '配送業者コード
                If IsDBNull(pDataReader("配送業者コード")) = True Then
                    parShipmentData(i).sShipCorpCode = 0
                Else
                    parShipmentData(i).sShipCorpCode = CInt(pDataReader("配送業者コード"))
                End If
                '営業店コード
                parShipmentData(i).sShipOfficeCode = pDataReader("営業店コード").ToString
                '代引金額
                If IsDBNull(pDataReader("代引金額")) = True Then
                    parShipmentData(i).sDaibikiPrice = 0
                Else
                    parShipmentData(i).sDaibikiPrice = CLng(pDataReader("代引金額"))
                End If
                '出荷税抜商品金額
                If IsDBNull(pDataReader("出荷税抜商品金額")) = True Then
                    parShipmentData(i).sNoTaxTotalProductPrice = 0
                Else
                    parShipmentData(i).sNoTaxTotalProductPrice = CLng(pDataReader("出荷税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parShipmentData(i).sShippingCharge = 0
                Else
                    parShipmentData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parShipmentData(i).sPaymentCharge = 0
                Else
                    parShipmentData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parShipmentData(i).sDiscount = 0
                Else
                    parShipmentData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parShipmentData(i).sPointDisCount = 0
                Else
                    parShipmentData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '出荷税抜金額
                If IsDBNull(pDataReader("出荷税抜金額")) = True Then
                    parShipmentData(i).sNoTaxTotalPrice = 0
                Else
                    parShipmentData(i).sNoTaxTotalPrice = CLng(pDataReader("出荷税抜金額"))
                End If

                '2019/10/9 shimizu add start
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parShipmentData(i).sReducedTaxRate = String.Empty
                Else
                    parShipmentData(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                End If
                '2019/10/9 shimizu add end

                '出荷消費税額
                If IsDBNull(pDataReader("出荷消費税額")) = True Then
                    parShipmentData(i).sTaxTotal = 0
                Else
                    parShipmentData(i).sTaxTotal = CLng(pDataReader("出荷消費税額"))
                End If

                '2019/10/9 shimizu add start
                '出荷軽減消費税額
                If IsDBNull(pDataReader("出荷軽減消費税額")) = True Then
                    parShipmentData(i).sReducedTaxRateTotal = 0
                Else
                    parShipmentData(i).sReducedTaxRateTotal = CLng(pDataReader("出荷軽減消費税額"))
                End If
                '2019/10/9 shimizu add end

                '出荷税込金額
                If IsDBNull(pDataReader("出荷税込金額")) = True Then
                    parShipmentData(i).sTotalPrice = 0
                Else
                    parShipmentData(i).sTotalPrice = CLng(pDataReader("出荷税込金額"))
                End If
                '荷姿コード
                If IsDBNull(pDataReader("荷姿コード")) = True Then
                    parShipmentData(i).sLookFeelCode = 0
                Else
                    parShipmentData(i).sLookFeelCode = CInt(pDataReader("荷姿コード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parShipmentData(i).sShipPaymentCode = 0
                Else
                    parShipmentData(i).sShipPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '決済種別
                If IsDBNull(pDataReader("決済種別")) = True Then
                    parShipmentData(i).sShipPaymentClass = 0
                Else
                    parShipmentData(i).sShipPaymentClass = CInt(pDataReader("決済種別"))
                End If
                '便種（スピード）
                parShipmentData(i).sDeliveryClassSpeed = pDataReader("便種スピード").ToString
                '便種（商品）
                parShipmentData(i).sDeliveryClassProduct = pDataReader("便種商品").ToString
                '指定シール1
                parShipmentData(i).sSeal1 = pDataReader("指定シール1").ToString
                '指定シール2
                parShipmentData(i).sSeal2 = pDataReader("指定シール2").ToString
                '指定シール3
                parShipmentData(i).sSeal3 = pDataReader("指定シール3").ToString
                '元着区分
                If IsDBNull(pDataReader("元着区分")) = True Then
                    parShipmentData(i).sMotoCyakuClass = 0
                Else
                    parShipmentData(i).sMotoCyakuClass = CInt(pDataReader("元着区分"))
                End If
                '出荷完了フラグ
                If IsDBNull(pDataReader("出荷完了フラグ")) = True Then
                    parShipmentData(i).sFinishFlg = 0
                Else
                    parShipmentData(i).sFinishFlg = CInt(pDataReader("出荷完了フラグ"))
                End If
                '再出荷事由
                parShipmentData(i).sReShopMemo = pDataReader("再出荷事由").ToString
                '出荷メモ
                parShipmentData(i).sShipMemo = pDataReader("出荷メモ").ToString
                '配送伝票CSV出力フラグ
                If IsDBNull(pDataReader("配送伝票CSV出力フラグ")) = True Then
                    parShipmentData(i).sDeleveryCSVOutoutFlg = False
                Else
                    parShipmentData(i).sDeleveryCSVOutoutFlg = CBool(pDataReader("配送伝票CSV出力フラグ"))
                End If
                '出荷担当者コード
                parShipmentData(i).sShipStaffCode = pDataReader("出荷担当者コード").ToString
                '登録日
                parShipmentData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parShipmentData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parShipmentData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parShipmentData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getShipment = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.getShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function

    Public Function getShipmentCount(ByVal KeyRequestCode As String,
                                     ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT Count(出荷コード) AS 出荷回数 " &
                        "FROM 出荷情報データ " &
                        "WHERE 受注コード = """ & KeyRequestCode & """ " &
                        "GROUP BY 受注コード"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            getShipmentCount = 0

            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("出荷回数")) = True Then
                    getShipmentCount = 0
                Else
                    getShipmentCount = CLng(pDataReader("出荷回数"))
                End If

            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.getShipmentCount)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function

    Public Function getLastShipment(ByVal KeyRequestCode As String,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction
                               ) As Boolean

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim maxpc As Integer
        Dim scnt As Integer
        Dim pShipFlg As Boolean

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT " &
                        "出荷情報データ.受注コード, " &
                        "出荷情報データ.出荷日, " &
                        "出荷情報データ.出荷完了フラグ, " &
                        "出荷情報データ.登録日, " &
                        "出荷情報データ.登録時間 " &
                    "FROM 出荷情報データ "

        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> Nothing Then
            maxpc = 1
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
                        strSelect = strSelect & "受注コード= """ & KeyRequestCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY " &
                                    "出荷情報データ.出荷日 DESC , " &
                                    "出荷情報データ.登録日 DESC , " &
                                    "出荷情報データ.登録時間 DESC "

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            '出荷完了フラグ
            If IsDBNull(pDataReader("出荷完了フラグ")) = True Then
                pShipFlg = 0
            Else
                pShipFlg = CInt(pDataReader("出荷完了フラグ"))
            End If

            getLastShipment = pShipFlg

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.getLastShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：出荷情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertShipment(ByRef parShipmentData As cStructureLib.sShipmentData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim i As Integer
        Dim strInsert As String

        'SQL文の設定
        strInsert = ""
        strInsert = "INSERT INTO 出荷情報データ (" &
                        "チャネルコード, " &
                        "出荷コード, " &
                        "受注コード, " &
                        "出荷日, " &
                        "荷物受渡番号, " &
                        "出荷先電話番号, " &
                        "出荷先郵便番号, " &
                        "出荷先住所1, " &
                        "出荷先住所2, " &
                        "出荷先住所3, " &
                        "出荷先姓, " &
                        "出荷先名, " &
                        "配達日, " &
                        "配達指定時間帯, " &
                        "配達指定時間, " &
                        "配送業者コード, " &
                        "営業店コード, " &
                        "代引金額, " &
                        "出荷税抜商品金額, " &
                        "送料, " &
                        "手数料, " &
                        "値引き, " &
                        "ポイント値引き, " &
                        "出荷税抜金額, " &
                        "軽減税率, " &
                        "出荷消費税額, " &
                        "出荷軽減消費税額, " &
                        "出荷税込金額, " &
                        "荷姿コード, " &
                        "支払方法コード, " &
                        "決済種別, " &
                        "便種スピード, " &
                        "便種商品, " &
                        "指定シール1, " &
                        "指定シール2, " &
                        "指定シール3, " &
                        "元着区分, " &
                        "出荷完了フラグ, " &
                        "再出荷事由, " &
                        "出荷メモ, " &
                        "配送伝票CSV出力フラグ, " &
                        "出荷担当者コード, " &
                        "登録日, " &
                        "登録時間, " &
                        "最終更新日, " &
                        "最終更新時間 " &
                    ") VALUES ( " &
                        "@ChannelCode, " &
                        "@ShipCode, " &
                        "@RequestCode, " &
                        "@ShipDate, " &
                        "@DeliveryNumber, " &
                        "@Tel, " &
                        "@PostalCode, " &
                        "@Address1, " &
                        "@Address2, " &
                        "@Address3, " &
                        "@FirstName, " &
                        "@LastName, " &
                        "@ShipRequestDate, " &
                        "@ShipRequestTimeClass, " &
                        "@ShipRequestTime, " &
                        "@ShipCorpCode, " &
                        "@ShipOfficeCode, " &
                        "@DaibikiPrice, " &
                        "@NoTaxTotalProductPrice, " &
                        "@ShippingCharge, " &
                        "@PaymentCharge, " &
                        "@Discount, " &
                        "@PointDisCount, " &
                        "@NoTaxTotalPrice, " &
                        "@ReducedTaxRate, " &
                        "@TaxTotal, " &
                        "@ReducedTaxRateTotal, " &
                        "@TotalPrice, " &
                        "@LookFeelCode, " &
                        "@ShipPaymentCode, " &
                        "@ShipPaymentClass, " &
                        "@DeliveryClassSpeed, " &
                        "@DeliveryClassProduct, " &
                        "@Seal1, " &
                        "@Seal2, " &
                        "@Seal3, " &
                        "@MotoCyakuClass, " &
                        "@FinishFlg, " &
                        "@ReShopMemo, " &
                        "@ShipMemo, " &
                        "@DeleveryCSVOutoutFlg, " &
                        "@ShipStaffCode, " &
                        "@CreateDate, " &
                        "@CreateTime, " &
                        "@UpdateDate, " &
                        "@UpdateTime " &
                    ") "

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            i = 0

            '***********************
            'パラメータの設定()
            '***********************
            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parShipmentData.sChannelCode
            '出荷コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipCode").Value = parShipmentData.sShipCode
            '受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = parShipmentData.sRequestCode
            '出荷日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ShipDate").Value = parShipmentData.sShipDate
            '荷物受渡番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DeliveryNumber", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@DeliveryNumber").Value = parShipmentData.sDeliveryNumber
            '出荷先電話番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Tel", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@Tel").Value = parShipmentData.sTel
            '出荷先郵便番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PostalCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@PostalCode").Value = parShipmentData.sPostalCode
            '出荷先住所1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address1", OleDb.OleDbType.Char, 16))
            pCommand.Parameters("@Address1").Value = parShipmentData.sAddress1
            '出荷先住所2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address2", OleDb.OleDbType.Char, 16))
            pCommand.Parameters("@Address2").Value = parShipmentData.sAddress2
            '出荷先住所3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address3", OleDb.OleDbType.Char, 16))
            pCommand.Parameters("@Address3").Value = parShipmentData.sAddress3
            '出荷先姓
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@FirstName", OleDb.OleDbType.Char, 16))
            pCommand.Parameters("@FirstName").Value = parShipmentData.sFirstName
            '出荷先名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@LastName", OleDb.OleDbType.Char, 16))
            pCommand.Parameters("@LastName").Value = parShipmentData.sLastName
            '配達日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ShipRequestDate").Value = parShipmentData.sShipRequestDate
            '配達指定時間帯
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestTimeClass", OleDb.OleDbType.Char, 2))
            pCommand.Parameters("@ShipRequestTimeClass").Value = parShipmentData.sShipRequestTimeClass
            '配達指定時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ShipRequestTime").Value = parShipmentData.sShipRequestTime
            '配送業者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCorpCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ShipCorpCode").Value = parShipmentData.sShipCorpCode
            '営業店コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipOfficeCode", OleDb.OleDbType.Char, 4))
            pCommand.Parameters("@ShipOfficeCode").Value = parShipmentData.sShipOfficeCode
            '代引金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DaibikiPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@DaibikiPrice").Value = parShipmentData.sDaibikiPrice
            '出荷税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalProductPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxTotalProductPrice").Value = parShipmentData.sNoTaxTotalProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShippingCharge").Value = parShipmentData.sShippingCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PaymentCharge").Value = parShipmentData.sPaymentCharge
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Discount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Discount").Value = parShipmentData.sDiscount
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDisCount").Value = parShipmentData.sPointDisCount
            '出荷税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxTotalPrice").Value = parShipmentData.sNoTaxTotalPrice

            '2019/10/9 shimizu add start
            '軽減税率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@ReducedTaxRate").Value = parShipmentData.sReducedTaxRate
            '2019/10/9 shimizu add end

            '出荷消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxTotal").Value = parShipmentData.sTaxTotal

            '2019/10/9 shimizu add start
            '出荷消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRateTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ReducedTaxRateTotal").Value = parShipmentData.sReducedTaxRateTotal
            '2019/10/9 shimizu add end

            '出荷税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TotalPrice").Value = parShipmentData.sTotalPrice
            '荷姿コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@LookFeelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@LookFeelCode").Value = parShipmentData.sLookFeelCode
            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPaymentCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ShipPaymentCode").Value = parShipmentData.sShipPaymentCode
            '決済種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPaymentClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ShipPaymentClass").Value = parShipmentData.sShipPaymentClass
            '便種（スピード）
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DeliveryClassSpeed", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@DeliveryClassSpeed").Value = parShipmentData.sSeal1
            '便種（商品）
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DeliveryClassProduct", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@DeliveryClassProduct").Value = parShipmentData.sSeal2
            '指定シール1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Seal1", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@Seal1").Value = parShipmentData.sSeal1
            '指定シール2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Seal2", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@Seal2").Value = parShipmentData.sSeal2
            '指定シール3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Seal3", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@Seal3").Value = parShipmentData.sSeal3
            '元着区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MotoCyakuClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@MotoCyakuClass").Value = parShipmentData.sMotoCyakuClass
            '出荷完了フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@FinishFlg", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@FinishFlg").Value = parShipmentData.sFinishFlg
            '再出荷事由
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReShopMemo", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@ReShopMemo").Value = parShipmentData.sReShopMemo
            '出荷メモ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipMemo", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@ShipMemo").Value = parShipmentData.sShipMemo
            '配送伝票CSV出力フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DeleveryCSVOutoutFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@DeleveryCSVOutoutFlg").Value = parShipmentData.sDeleveryCSVOutoutFlg
            '出荷担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipStaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipStaffCode").Value = parShipmentData.sShipStaffCode
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

            '出荷情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertShipment = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.insertShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    Public Function updateShipment(ByRef parShipmentData() As cStructureLib.sShipmentData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdateTrn As String

        'SQL文の設定
        strUpdateTrn = "UPDATE 出荷情報データ SET " &
                            "チャネルコード = " & parShipmentData(0).sChannelCode & ", " &
                            "出荷コード = """ & parShipmentData(0).sShipCode & """, " &
                            "受注コード = """ & parShipmentData(0).sRequestCode & """, " &
                            "出荷日 = """ & parShipmentData(0).sShipDate & """, " &
                            "荷物受渡番号 = """ & parShipmentData(0).sDeliveryNumber & """, " &
                            "出荷先電話番号 = """ & parShipmentData(0).sTel & """, " &
                            "出荷先郵便番号 = """ & parShipmentData(0).sPostalCode & """, " &
                            "出荷先住所1 = """ & parShipmentData(0).sAddress1 & """, " &
                            "出荷先住所2 = """ & parShipmentData(0).sAddress2 & """, " &
                            "出荷先住所3 = """ & parShipmentData(0).sAddress3 & """, " &
                            "出荷先姓 = """ & parShipmentData(0).sFirstName & """, " &
                            "出荷先名 = """ & parShipmentData(0).sLastName & """, " &
                            "配達日 = """ & parShipmentData(0).sShipRequestDate & """, " &
                            "配達指定時間帯 = """ & parShipmentData(0).sShipRequestTimeClass & """, " &
                            "配達指定時間 = """ & parShipmentData(0).sShipRequestTime & """, " &
                            "配送業者コード = " & parShipmentData(0).sShipCorpCode & ", " &
                            "営業店コード = """ & parShipmentData(0).sShipOfficeCode & """, " &
                            "代引金額 = " & parShipmentData(0).sDaibikiPrice & ", " &
                            "出荷税抜商品金額 = " & parShipmentData(0).sNoTaxTotalProductPrice & ", " &
                            "送料 = " & parShipmentData(0).sShippingCharge & ", " &
                            "手数料 = " & parShipmentData(0).sPaymentCharge & ", " &
                            "値引き = " & parShipmentData(0).sDiscount & ", " &
                            "ポイント値引き = " & parShipmentData(0).sPointDisCount & ", " &
                            "出荷税抜金額 = " & parShipmentData(0).sNoTaxTotalPrice & ", " &
                            "軽減税率 = " & parShipmentData(0).sReducedTaxRate & ", " &
                            "出荷消費税額 = " & parShipmentData(0).sTaxTotal & ", " &
                            "出荷軽減消費税額 = " & parShipmentData(0).sReducedTaxRateTotal & ", " &
                            "出荷税込金額 = " & parShipmentData(0).sTotalPrice & ", " &
                            "荷姿コード = " & parShipmentData(0).sLookFeelCode & ", " &
                            "支払方法コード = " & parShipmentData(0).sShipPaymentCode & ", " &
                            "決済種別 = " & parShipmentData(0).sShipPaymentClass & ", " &
                            "便種スピード = """ & parShipmentData(0).sDeliveryClassSpeed.Trim & """, " &
                            "便種商品 = """ & parShipmentData(0).sDeliveryClassProduct.Trim & """, " &
                            "指定シール1 = """ & parShipmentData(0).sSeal1 & """, " &
                            "指定シール2 = """ & parShipmentData(0).sSeal2 & """, " &
                            "指定シール3 = """ & parShipmentData(0).sSeal3 & """, " &
                            "元着区分 = " & parShipmentData(0).sMotoCyakuClass & ", " &
                            "出荷完了フラグ = " & parShipmentData(0).sFinishFlg & ", " &
                            "再出荷事由 = """ & parShipmentData(0).sReShopMemo & """, " &
                            "出荷メモ = """ & parShipmentData(0).sShipMemo & """, " &
                            "配送伝票CSV出力フラグ = " & parShipmentData(0).sDeleveryCSVOutoutFlg & ", " &
                            "出荷担当者コード = """ & parShipmentData(0).sShipStaffCode & """, " &
                            "登録日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "登録時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """, " &
                            "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " &
                        "WHERE 出荷番号 = @ShipNumber"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran
        Try

            pCommand.CommandText = strUpdateTrn

            updateShipment = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.updateShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：出荷情報データから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getMaxShipmentNo(ByVal KeyChannelCode As Integer, ByVal KeyDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT 出荷コード FROM 出荷情報データ " &
                        "WHERE 出荷コード Like ""995" & String.Format("{0:0}", KeyChannelCode) & String.Format("{0:yyMMdd}", CDate(KeyDate)) & "%"" " &
                        "ORDER BY 出荷コード DESC"

            'SQL文の設定
            pCommand.CommandText = strSelect

            getMaxShipmentNo = 0

            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("出荷コード")) = True Then
                    getMaxShipmentNo = 0
                Else
                    getMaxShipmentNo = CLng(Mid(pDataReader("出荷コード").ToString, 11, 2)) + 1
                End If

            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentDBIO.getMaxShipmentNo)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
End Class
