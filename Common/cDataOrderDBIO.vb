
Public Class cDataOrderDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    '----------------------------------------------------------------------
    '　機能：発注情報データから該当発注番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getOrderData(ByRef parOrderData() As cStructureLib.sOrderData,
                                 ByVal KeyOrderNumber As String,
                                 ByVal KeySupplierCode As Integer,
                                 ByVal KeyFromDate As String,
                                 ByVal KeyToDate As String,
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
        strSelect = "Select " &
                        "発注情報データ.発注コード, " &
                        "発注情報データ.発注日, " &
                        "発注情報データ.発注モード, " &
                        "発注情報データ.発注税抜商品金額, " &
                        "発注情報データ.送料, " &
                        "発注情報データ.手数料, " &
                        "発注情報データ.値引き, " &
                        "発注情報データ.ポイント値引き, " &
                        "発注情報データ.発注税抜金額, " &
                        "発注情報データ.発注消費税額, " &
                        "発注情報データ.軽減税率, " &
                        "発注情報データ.発注軽減消費税額, " &
                        "発注情報データ.発注税込金額, " &
                        "発注情報データ.仕入先コード, " &
                        "発注情報データ.支払方法コード, " &
                        "発注情報データ.希望納品日, " &
                        "発注情報データ.希望納品場所, " &
                        "発注情報データ.発注担当者コード, " &
                        "発注情報データ.備考, " &
                        "発注情報データ.伝票印刷モード, " &
                        "発注情報データ.完納日, " &
                        "発注情報データ.登録日, " &
                        "発注情報データ.登録時間, " &
                        "発注情報データ.最終更新日, " &
                        "発注情報データ.最終更新時間 " &
                    "FROM 発注情報データ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyOrderNumber <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySupplierCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyFromDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If

        If KeyToDate <> Nothing Then
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
                        strSelect = strSelect & "発注コード Like ""%" & KeyOrderNumber & "%"" "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "仕入先コード = " & KeySupplierCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注日 <= """ & KeyToDate & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        i = 0

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parOrderData(i)

                '発注コード
                parOrderData(i).sOrderCode = pDataReader("発注コード").ToString
                '発注日
                parOrderData(i).sOrderDate = pDataReader("発注日").ToString
                '発注モード
                If IsDBNull(pDataReader("発注モード")) = True Then
                    parOrderData(i).sOrderMode = 0
                Else
                    parOrderData(i).sOrderMode = CInt(pDataReader("発注モード"))
                End If
                '発注税抜商品金額
                If IsDBNull(pDataReader("発注税抜商品金額")) = True Then
                    parOrderData(i).sNoTaxTotalProductPrice = 0
                Else
                    parOrderData(i).sNoTaxTotalProductPrice = CLng(pDataReader("発注税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parOrderData(i).sShippingCharge = 0
                Else
                    parOrderData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parOrderData(i).sPaymentCharge = 0
                Else
                    parOrderData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '発注値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parOrderData(i).sDiscount = 0
                Else
                    parOrderData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                '発注ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parOrderData(i).sPointDisCount = 0
                Else
                    parOrderData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '発注税抜金額
                If IsDBNull(pDataReader("発注税抜金額")) = True Then
                    parOrderData(i).sNoTaxTotalPrice = 0
                Else
                    parOrderData(i).sNoTaxTotalPrice = CLng(pDataReader("発注税抜金額"))
                End If
                '発注消費税額
                If IsDBNull(pDataReader("発注消費税額")) = True Then
                    parOrderData(i).sTaxTotal = 0
                Else
                    parOrderData(i).sTaxTotal = CLng(pDataReader("発注消費税額"))
                End If

                '2019/9/22 shimizu add start
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parOrderData(i).sReducedTaxRate = String.Empty
                Else
                    parOrderData(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                End If
                '発注軽減消費税額
                If IsDBNull(pDataReader("発注軽減消費税額")) = True Then
                    parOrderData(i).sReducedTaxRateTotal = 0
                Else
                    parOrderData(i).sReducedTaxRateTotal = CLng(pDataReader("発注軽減消費税額"))
                End If
                '2019/9/22 shimizu add end

                '発注税込金額
                If IsDBNull(pDataReader("発注税込金額")) = True Then
                    parOrderData(i).sTotalPrice = 0
                Else
                    parOrderData(i).sTotalPrice = CLng(pDataReader("発注税込金額"))
                End If
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parOrderData(i).sSupplierCode = 0
                Else
                    parOrderData(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parOrderData(i).sPaymentCode = 0
                Else
                    parOrderData(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '希望納品日
                parOrderData(i).sRequestDate = pDataReader("希望納品日").ToString
                '希望納品場所
                parOrderData(i).sRequestPlace = pDataReader("希望納品場所").ToString
                '発注担当者コード
                parOrderData(i).sStaffCode = pDataReader("発注担当者コード").ToString
                '備考
                parOrderData(i).sMemo = pDataReader("備考").ToString
                '伝票印刷モード
                If IsDBNull(pDataReader("伝票印刷モード")) = True Then
                    parOrderData(i).sPrintMode = 0
                Else
                    parOrderData(i).sPrintMode = CInt(pDataReader("伝票印刷モード"))
                End If
                '完納日
                parOrderData(i).sAllArrivedDate = pDataReader("完納日").ToString
                '登録日
                parOrderData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parOrderData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parOrderData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parOrderData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getOrderData = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.getOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大発注番号
    '----------------------------------------------------------------------
    Public Function getMaxOrderCode(ByVal KeySupplierCode As Integer,
                                    ByVal KeyDate As String,
                                    ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxOrderNo As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT 発注コード FROM 発注情報データ " &
                    "WHERE 発注コード Like ""991" & String.Format("{0:00}", KeySupplierCode) & KeyDate & "%"" " &
                    "ORDER BY 発注コード DESC"

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxOrderNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("発注コード")) = True Then
                    MaxOrderNo = 0
                Else
                    MaxOrderNo = CLng(Mid(pDataReader("発注コード").ToString, 12, 1)) + 1
                End If

            End If
            getMaxOrderCode = MaxOrderNo

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.getMaxOrderCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報テーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertOrderData(ByVal parOrderData As cStructureLib.sOrderData,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsertOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsertOrder = "INSERT INTO 発注情報データ ( " &
                                "発注コード, " &
                                "発注日, " &
                                "発注モード, " &
                                "発注税抜商品金額, " &
                                "送料, " &
                                "手数料, " &
                                "値引き, " &
                                "ポイント値引き, " &
                                "発注税抜金額, " &
                                "発注消費税額, " &
                                "軽減税率, " &
                                "発注軽減消費税額, " &
                                "発注税込金額, " &
                                "仕入先コード, " &
                                "支払方法コード, " &
                                "希望納品日, " &
                                "希望納品場所, " &
                                "発注担当者コード, " &
                                "備考, " &
                                "伝票印刷モード, " &
                                "完納日, " &
                                "登録日, " &
                                "登録時間, " &
                                "最終更新日, " &
                                "最終更新時間 " &
                            ") VALUES (" &
                                "@OrderCode, " &
                                "@OrderDate, " &
                                "@OrderMode, " &
                                "@NoTaxProductPrice, " &
                                "@ShippingCharge, " &
                                "@PaymentCharge, " &
                                "@Discount, " &
                                "@PointDisCount, " &
                                "@NoTaxTotalPrice, " &
                                "@TaxTotal, " &
                                "@ReducedTaxRate, " &
                                "@ReducedTaxRateTotal, " &
                                "@TotalPrice, " &
                                "@SupplierCode, " &
                                "@PaymentCode, " &
                                "@RequestDate, " &
                                "@RequestPlace, " &
                                "@StaffCode, " &
                                "@Memo, " &
                                "@PrintMode, " &
                                "@AllArrivedDate, " &
                                "@CreateDate, " &
                                "@CreateTime, " &
                                "@UpdateDate, " &
                                "@UpdateTime " &
                            ")"

            pCommand.CommandText = strInsertOrder

            '***********************
            '   パラメータの設定
            '***********************

            '発注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@OrderCode").Value = parOrderData.sOrderCode
            '発注日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@OrderDate").Value = parOrderData.sOrderDate
            '発注モード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderMode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@OrderMode").Value = parOrderData.sOrderMode
            '発注税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxProductPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxProductPrice").Value = parOrderData.sNoTaxTotalProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShippingCharge").Value = parOrderData.sShippingCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PaymentCharge").Value = parOrderData.sPaymentCharge
            '発注値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@DisCount").Value = parOrderData.sDiscount
            '発注ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDisCount").Value = parOrderData.sPointDisCount
            '発注税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxTotalPrice").Value = parOrderData.sNoTaxTotalPrice
            '発注消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxTotal").Value = parOrderData.sTaxTotal

            '2019/9/22 shimizu add start
            '軽減税率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ReducedTaxRate").Value = parOrderData.sReducedTaxRate
            '発注軽減消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRateTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ReducedTaxRateTotal").Value = parOrderData.sReducedTaxRateTotal
            '2019/9/22 shimizu add end

            '発注税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TotalPrice").Value = parOrderData.sTotalPrice
            '仕入先コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@SupplierCode").Value = parOrderData.sSupplierCode
            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@PaymentCode").Value = parOrderData.sPaymentCode
            '希望納品日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@RequestDate").Value = parOrderData.sRequestDate
            '希望納品場所
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestPlace", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@RequestPlace").Value = parOrderData.sRequestPlace
            '発注担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@StaffCode").Value = parOrderData.sStaffCode
            '備考
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Memo").Value = parOrderData.sMemo
            '伝票印刷モード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PrintMode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@PrintMode").Value = parOrderData.sPrintMode
            '完納日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AllArrivedDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@AllArrivedDate").Value = ""
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


            '発注情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertOrderData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.insertOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報明細テーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteOrderData(ByVal OrderNumber As String,
                                    ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strDeleteOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            '*********************************
            '発注情報データ削除SQL文の設定
            '*********************************
            strDeleteOrder = "DELETE 発注情報データ.発注コード FROM 発注情報データ " &
                "WHERE 発注情報データ.発注コード=@OrderNumber"

            pCommand.CommandText = strDeleteOrder

            '***********************
            '   パラメータの設定
            '***********************

            '発注番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@OrderCode").Value = OrderNumber

            '発注情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteOrderData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.deleteOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの伝票印刷モードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updatePrintMode(ByVal KeyOrderNumber As String,
                                    ByVal PrintMode As Integer,
                                    ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'SQL文の設定
        strUpdate = "UPDATE 発注情報データ SET " &
                            "発注情報データ.伝票印刷モード=" & PrintMode & " " &
                            "WHERE 発注情報データ.発注コード = """ & KeyOrderNumber & """ "
        Try
            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updatePrintMode = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.updatePrintMode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの完納日を更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateAllArrivedDate(ByVal KeyOrderNumber As String,
                                    ByVal KeyAllArrivedDate As String,
                                    ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'SQL文の設定
        strUpdate = "UPDATE 発注情報データ SET " &
                            "発注情報データ.完納日=""" & KeyAllArrivedDate & """ " &
                            "WHERE 発注情報データ.発注コード = """ & KeyOrderNumber & """ "
        Try
            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateAllArrivedDate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.updateAllArrivedDate)", Nothing, Nothing, oExcept.ToString)
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
