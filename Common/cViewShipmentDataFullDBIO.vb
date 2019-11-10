
Public Class cViewShipmentDataFullDBIO
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
    Public Function getShipmentFull(ByRef parShipmentDataFull() As cStructureLib.sViewShipmentDataFull, _
                                    ByVal KeyRequestCode As String, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyOptionName As String, _
                                    ByVal KeyCorpCode As Integer, _
                                    ByVal KeyFromRequestDate As String, _
                                    ByVal KeyToRequestDate As String, _
                                    ByVal KeyFromShiptDate As String, _
                                    ByVal KeyToShipDate As String, _
                                    ByVal KeyPostCode As String, _
                                    ByVal KeyAddr As String, _
                                    ByVal KeyName As String, _
                                    ByVal KeyCheck As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction _
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

        strSelect = "SELECT " & _
                        "出荷伝表出力データ.出荷状態 AS 出荷状態, " & _
                        "出荷情報データ.出荷コード AS 出荷コード, " & _
                        "出荷情報データ.チャネルコード AS チャネルコード, " & _
                        "出荷情報データ.受注コード AS 受注コード, " & _
                        "出荷情報データ.出荷日 AS 出荷日, " & _
                        "出荷情報データ.荷物受渡番号 AS 荷物受渡番号, " & _
                        "出荷情報データ.出荷先電話番号 AS 出荷先電話番号, " & _
                        "出荷情報データ.出荷先郵便番号 AS 出荷先郵便番号, " & _
                        "出荷情報データ.出荷先住所1 AS 出荷先住所1, " & _
                        "出荷情報データ.出荷先住所2 AS 出荷先住所2, " & _
                        "出荷情報データ.出荷先住所3 AS 出荷先住所3, " & _
                        "出荷情報データ.出荷先姓 AS 出荷先姓, " & _
                        "出荷情報データ.出荷先名 AS 出荷先名, " & _
                        "出荷情報データ.配達日 AS 配達日, " & _
                        "出荷情報データ.配達指定時間帯 AS 配達指定時間帯, " & _
                        "出荷情報データ.配達指定時間 AS 配達指定時間, " & _
                        "出荷情報データ.配送業者コード AS 配送業者コード, " & _
                        "出荷情報データ.営業店コード AS 営業店コード, " & _
                        "出荷情報データ.代引金額 AS 代引金額, " & _
                        "出荷情報データ.出荷税抜商品金額 AS 合計出荷税抜商品金額, " & _
                        "出荷情報データ.送料 AS 送料, " & _
                        "出荷情報データ.手数料 AS 手数料, " & _
                        "出荷情報データ.値引き AS 値引き, " & _
                        "出荷情報データ.ポイント値引き AS ポイント値引き, " & _
                        "出荷情報データ.出荷税抜金額 AS 合計出荷税抜金額, " & _
                        "出荷情報データ.出荷消費税額 AS 合計出荷消費税額, " & _
                        "出荷情報データ.出荷税込金額 AS 合計出荷税込金額, " & _
                        "出荷情報データ.荷姿コード AS 荷姿コード, " & _
                        "出荷情報データ.支払方法コード AS 支払方法コード, " & _
                        "出荷情報データ.決済種別 AS 決済種別, " & _
                        "出荷情報データ.便種スピード AS 便種スピード, " & _
                        "出荷情報データ.便種商品 AS 便種商品, " & _
                        "出荷情報データ.指定シール1 AS 指定シール1, " & _
                        "出荷情報データ.指定シール2 AS 指定シール2, " & _
                        "出荷情報データ.指定シール3 AS 指定シール3, " & _
                        "出荷情報データ.元着区分 AS 元着区分, " & _
                        "出荷情報データ.出荷完了フラグ AS 出荷完了フラグ, " & _
                        "出荷情報データ.再出荷事由 AS 再出荷事由, " & _
                        "出荷情報データ.出荷メモ AS 出荷メモ, " & _
                        "出荷情報データ.配送伝票CSV出力フラグ AS 配送伝票CSV出力フラグ, " & _
                        "出荷情報データ.出荷担当者コード AS 出荷担当者コード, " & _
                        "出荷情報明細データ.受注明細コード AS 受注明細コード, " & _
                        "出荷情報明細データ.商品コード AS 商品コード, " & _
                        "出荷情報明細データ.JANコード AS JANコード, " & _
                        "出荷情報明細データ.商品名称 AS 商品名称, " & _
                        "出荷情報明細データ.オプション名称 AS オプション名称, " & _
                        "出荷情報明細データ.オプション値 AS オプション値, " & _
                        "出荷情報明細データ.定価 AS 定価, " & _
                        "出荷情報明細データ.仕入単価 AS 仕入単価, " & _
                        "出荷情報明細データ.出荷商品単価 AS 出荷商品単価, " & _
                        "出荷情報明細データ.出荷数量 AS 出荷数量, " & _
                        "出荷情報明細データ.出荷税抜金額 AS 出荷税抜金額, " & _
                        "出荷情報明細データ.出荷消費税額 AS 出荷消費税額, " & _
                        "出荷情報明細データ.出荷税込金額 AS 出荷税込金額 " & _
                    "FROM " & _
                        "(" & _
                            "出荷情報データ LEFT JOIN 出荷情報明細データ ON 出荷情報データ.出荷コード = 出荷情報明細データ.出荷コード " & _
                        ") " & _
                        "LEFT JOIN 出荷伝表出力データ ON 出荷情報明細データ.出荷コード = 出荷伝表出力データ.出荷コード "

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
        If KeyProductCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyOptionName <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyCorpCode <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyFromRequestDate <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyToRequestDate <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If
        If KeyFromShiptDate <> Nothing Then
            maxpc = 128
            pc = pc Or maxpc
        End If

        If KeyToShipDate <> Nothing Then
            maxpc = 256
            pc = pc Or maxpc
        End If
        If KeyPostCode <> Nothing Then
            maxpc = 512
            pc = pc Or maxpc
        End If
        If KeyAddr <> Nothing Then
            maxpc = 1024
            pc = pc Or maxpc
        End If
        If KeyName <> Nothing Then
            maxpc = 2048
            pc = pc Or maxpc
        End If
        If KeyCheck <> Nothing Then
            maxpc = 4096
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
                        strSelect = strSelect & "出荷情報データ.受注コード= """ & KeyRequestCode & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.チャネルコード= " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報明細データ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報明細データ.オプション値 Like ""%" & KeyOptionName & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.配送業者コード = " & KeyCorpCode & " "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.受注日 >= """ & KeyFromRequestDate & """ "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.受注日 >= """ & KeyToRequestDate & """ "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.出荷日 >= """ & KeyFromShiptDate & """ "
                        scnt = scnt + 1
                    Case 256
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.出荷日 >= """ & KeyToShipDate & """ "
                        scnt = scnt + 1
                    Case 512
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷情報データ.出荷先郵便番号 Like """ & KeyPostCode & """ "
                        scnt = scnt + 1
                    Case 1024
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "( 出荷情報データ.出荷先住所1 Like """ & KeyAddr & """ "
                        strSelect = strSelect & "Or 出荷情報データ.出荷先住所2 Like """ & KeyAddr & """ "
                        strSelect = strSelect & "Or 出荷情報データ.出荷先住所3 Like """ & KeyAddr & """) "
                        scnt = scnt + 1
                    Case 2048
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "( 出荷情報データ.出荷先姓 Like """ & KeyAddr & """ "
                        strSelect = strSelect & "Or 出荷情報データ.出荷先名 Like """ & KeyAddr & """ ) "
                        scnt = scnt + 1
                    Case 4096
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷伝表出力データ.出荷状態 =" & KeyCheck & " "
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

                ReDim Preserve parShipmentDataFull(i)

                '出荷状態
                If IsDBNull(pDataReader("出荷状態")) = True Then
                    parShipmentDataFull(i).sShipCheck = False
                Else
                    parShipmentDataFull(i).sShipCheck = CBool(pDataReader("出荷状態"))
                End If
                '出荷コード
                parShipmentDataFull(i).sShipCode = pDataReader("出荷コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parShipmentDataFull(i).sChannelCode = 0
                Else
                    parShipmentDataFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                '受注コード
                parShipmentDataFull(i).sRequestCode = pDataReader("受注コード").ToString
                '出荷日
                parShipmentDataFull(i).sShipDate = pDataReader("出荷日").ToString
                '荷物受渡番号
                parShipmentDataFull(i).sDeliveryNumber = pDataReader("荷物受渡番号").ToString
                '出荷先電話番号
                parShipmentDataFull(i).sTel = pDataReader("出荷先電話番号").ToString
                '出荷先郵便番号
                parShipmentDataFull(i).sPostalCode = pDataReader("出荷先郵便番号").ToString
                '出荷先住所1
                parShipmentDataFull(i).sAddress1 = pDataReader("出荷先住所1").ToString
                '出荷先住所2
                parShipmentDataFull(i).sAddress2 = pDataReader("出荷先住所2").ToString
                '出荷先住所3
                parShipmentDataFull(i).sAddress3 = pDataReader("出荷先住所3").ToString
                '出荷先姓
                parShipmentDataFull(i).sFirstName = pDataReader("出荷先姓").ToString
                '出荷先名
                parShipmentDataFull(i).sLastName = pDataReader("出荷先名").ToString
                '配達日
                parShipmentDataFull(i).sShipRequestDate = pDataReader("配達日").ToString
                '配達指定時間帯
                parShipmentDataFull(i).sShipRequestTimeClass = pDataReader("配達指定時間帯").ToString
                '配達指定時間
                parShipmentDataFull(i).sShipRequestTime = pDataReader("配達指定時間").ToString
                '配送業者コード
                If IsDBNull(pDataReader("配送業者コード")) = True Then
                    parShipmentDataFull(i).sShipCorpCode = 0
                Else
                    parShipmentDataFull(i).sShipCorpCode = CInt(pDataReader("配送業者コード"))
                End If
                '営業店コード
                parShipmentDataFull(i).sShipOfficeCode = pDataReader("営業店コード").ToString
                '代引金額
                If IsDBNull(pDataReader("代引金額")) = True Then
                    parShipmentDataFull(i).sDaibikiPrice = 0
                Else
                    parShipmentDataFull(i).sDaibikiPrice = CLng(pDataReader("代引金額"))
                End If
                '出荷税抜商品金額
                If IsDBNull(pDataReader("合計出荷税抜商品金額")) = True Then
                    parShipmentDataFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parShipmentDataFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("合計出荷税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parShipmentDataFull(i).sShippingCharge = 0
                Else
                    parShipmentDataFull(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parShipmentDataFull(i).sPaymentCharge = 0
                Else
                    parShipmentDataFull(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parShipmentDataFull(i).sDiscount = 0
                Else
                    parShipmentDataFull(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parShipmentDataFull(i).sPointDisCount = 0
                Else
                    parShipmentDataFull(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '出荷税抜金額
                If IsDBNull(pDataReader("合計出荷税抜金額")) = True Then
                    parShipmentDataFull(i).sNoTaxTotalPrice = 0
                Else
                    parShipmentDataFull(i).sNoTaxTotalPrice = CLng(pDataReader("合計出荷税抜金額"))
                End If
                '出荷消費税額
                If IsDBNull(pDataReader("合計出荷消費税額")) = True Then
                    parShipmentDataFull(i).sTaxTotal = 0
                Else
                    parShipmentDataFull(i).sTaxTotal = CLng(pDataReader("合計出荷消費税額"))
                End If
                '出荷税込金額
                If IsDBNull(pDataReader("合計出荷税込金額")) = True Then
                    parShipmentDataFull(i).sTotalPrice = 0
                Else
                    parShipmentDataFull(i).sTotalPrice = CLng(pDataReader("合計出荷税込金額"))
                End If
                '荷姿コード
                If IsDBNull(pDataReader("荷姿コード")) = True Then
                    parShipmentDataFull(i).sLookFeelCode = 0
                Else
                    parShipmentDataFull(i).sLookFeelCode = CInt(pDataReader("荷姿コード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parShipmentDataFull(i).sShipPaymentCode = 0
                Else
                    parShipmentDataFull(i).sShipPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '決済種別
                If IsDBNull(pDataReader("決済種別")) = True Then
                    parShipmentDataFull(i).sShipPaymentClass = 0
                Else
                    parShipmentDataFull(i).sShipPaymentClass = CInt(pDataReader("決済種別"))
                End If
                '便種スピード
                If IsDBNull(pDataReader("便種スピード")) = True Then
                    parShipmentDataFull(i).sDeliveryClassSpeed = ""
                Else
                    parShipmentDataFull(i).sDeliveryClassSpeed = pDataReader("便種スピード").ToString
                End If
                '便種商品
                If IsDBNull(pDataReader("便種商品")) = True Then
                    parShipmentDataFull(i).sDeliveryClassProduct = ""
                Else
                    parShipmentDataFull(i).sDeliveryClassProduct = pDataReader("便種商品").ToString
                End If
                '指定シール1
                parShipmentDataFull(i).sSeal1 = pDataReader("指定シール1").ToString
                '指定シール2
                parShipmentDataFull(i).sSeal2 = pDataReader("指定シール2").ToString
                '指定シール3
                parShipmentDataFull(i).sSeal3 = pDataReader("指定シール3").ToString
                '元着区分
                If IsDBNull(pDataReader("元着区分")) = True Then
                    parShipmentDataFull(i).sMotoCyakuClass = 0
                Else
                    parShipmentDataFull(i).sMotoCyakuClass = CInt(pDataReader("元着区分"))
                End If
                '出荷完了フラグ
                If IsDBNull(pDataReader("出荷完了フラグ")) = True Then
                    parShipmentDataFull(i).sFinishFlg = 0
                Else
                    parShipmentDataFull(i).sFinishFlg = CInt(pDataReader("出荷完了フラグ"))
                End If
                '再出荷事由
                parShipmentDataFull(i).sReShopMemo = pDataReader("再出荷事由").ToString
                '出荷メモ
                parShipmentDataFull(i).sShipMemo = pDataReader("出荷メモ").ToString
                '配送伝票CSV出力フラグ
                If IsDBNull(pDataReader("配送伝票CSV出力フラグ")) = True Then
                    parShipmentDataFull(i).sDeleveryCSVOutoutFlg = False
                Else
                    parShipmentDataFull(i).sDeleveryCSVOutoutFlg = CBool(pDataReader("配送伝票CSV出力フラグ"))
                End If
                '出荷担当者コード
                parShipmentDataFull(i).sShipStaffCode = pDataReader("出荷担当者コード").ToString
                '受注明細コード
                If IsDBNull(pDataReader("受注明細コード")) = True Then
                    parShipmentDataFull(i).sRequestSubCode = 0
                Else
                    parShipmentDataFull(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))
                End If
                '商品コード
                parShipmentDataFull(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parShipmentDataFull(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parShipmentDataFull(i).sProductName = pDataReader("商品名称").ToString
                'オプション名称
                parShipmentDataFull(i).sOptionName = pDataReader("オプション名称").ToString
                'オプション値
                parShipmentDataFull(i).sOptionValue = pDataReader("オプション値").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parShipmentDataFull(i).sListPrice = 0
                Else
                    parShipmentDataFull(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parShipmentDataFull(i).sCostPrice = 0
                Else
                    parShipmentDataFull(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '出荷商品単価
                If IsDBNull(pDataReader("出荷商品単価")) = True Then
                    parShipmentDataFull(i).sUnitPrice = 0
                Else
                    parShipmentDataFull(i).sUnitPrice = CLng(pDataReader("出荷商品単価"))
                End If
                '出荷数量
                If IsDBNull(pDataReader("出荷数量")) = True Then
                    parShipmentDataFull(i).sCount = 0
                Else
                    parShipmentDataFull(i).sCount = CInt(pDataReader("出荷数量"))
                End If
                '出荷税抜金額
                If IsDBNull(pDataReader("出荷税抜金額")) = True Then
                    parShipmentDataFull(i).sNoTaxPrice = 0
                Else
                    parShipmentDataFull(i).sNoTaxPrice = CLng(pDataReader("出荷税抜金額"))
                End If
                '出荷消費税額
                If IsDBNull(pDataReader("出荷消費税額")) = True Then
                    parShipmentDataFull(i).sTaxPrice = 0
                Else
                    parShipmentDataFull(i).sTaxPrice = CLng(pDataReader("出荷消費税額"))
                End If
                '出荷税込金額
                If IsDBNull(pDataReader("出荷税込金額")) = True Then
                    parShipmentDataFull(i).sPrice = 0
                Else
                    parShipmentDataFull(i).sPrice = CLng(pDataReader("出荷税込金額"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getShipmentFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewShipmentDataFullDBIO.getShipmentFull)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function

End Class
