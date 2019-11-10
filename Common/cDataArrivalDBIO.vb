
Public Class cDataArrivalDBIO
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
    '　機能：注文情報データから該当注文番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getArrivalData(ByRef parArrivalData() As cStructureLib.sArrivalData,
                                   ByVal KeyOrderCode As String,
                                   ByVal KeyFromDate As String,
                                   ByVal KeyToDate As String,
                                   ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT " &
                            "入庫情報データ.発注コード, " &
                            "入庫情報データ.入庫番号, " &
                            "入庫情報データ.入庫日, " &
                            "入庫情報データ.仕入先コード, " &
                            "入庫情報データ.支払方法コード, " &
                            "入庫情報データ.入庫税抜商品金額, " &
                            "入庫情報データ.送料, " &
                            "入庫情報データ.手数料, " &
                            "入庫情報データ.値引き, " &
                            "入庫情報データ.ポイント値引き, " &
                            "入庫情報データ.入庫税抜金額, " &
                            "入庫情報データ.入庫消費税額, " &
                            "入庫情報データ.入庫税込金額, " &
                            "入庫情報データ.入庫担当者コード, " &
                            "入庫情報データ.登録日, " &
                            "入庫情報データ.登録時間, " &
                            "入庫情報データ.最終更新日, " &
                            "入庫情報データ.最終更新時間 " &
                        "FROM 入庫情報データ "

            '***********************
            '   パラメータの設定
            '***********************
            'パラメータ数のカウント
            pc = 0
            If KeyOrderCode <> "" Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyFromDate <> "" Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyToDate <> "" Then
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
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注コード = """ & KeyOrderCode & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "入庫日 >= """ & KeyFromDate & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "入庫日 <= """ & KeyToDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 発注コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parArrivalData(i)

                '発注コード
                parArrivalData(i).sOrderCode = pDataReader("発注コード").ToString
                '入庫番号
                If IsDBNull(pDataReader("入庫番号")) = True Then
                    parArrivalData(i).sArrivalNo = 0
                Else
                    parArrivalData(i).sArrivalNo = CLng(pDataReader("入庫番号"))
                End If
                '入庫日
                parArrivalData(i).sArrivalDate = pDataReader("入庫日").ToString
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parArrivalData(i).sSupplierCode = 0
                Else
                    parArrivalData(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parArrivalData(i).sPaymentCode = 0
                Else
                    parArrivalData(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '入庫税抜商品金額
                If IsDBNull(pDataReader("入庫税抜商品金額")) = True Then
                    parArrivalData(i).sNoTaxTotalProductPrice = 0
                Else
                    parArrivalData(i).sNoTaxTotalProductPrice = CLng(pDataReader("入庫税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parArrivalData(i).sShippingCharge = 0
                Else
                    parArrivalData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parArrivalData(i).sPaymentCharge = 0
                Else
                    parArrivalData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parArrivalData(i).sDiscount = 0
                Else
                    parArrivalData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parArrivalData(i).sPointDisCount = 0
                Else
                    parArrivalData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '入庫税抜金額
                If IsDBNull(pDataReader("入庫税抜金額")) = True Then
                    parArrivalData(i).sNoTaxTotalPrice = 0
                Else
                    parArrivalData(i).sNoTaxTotalPrice = CLng(pDataReader("入庫税抜金額"))
                End If
                '入庫消費税額
                If IsDBNull(pDataReader("入庫消費税額")) = True Then
                    parArrivalData(i).sTaxTotal = 0
                Else
                    parArrivalData(i).sTaxTotal = CLng(pDataReader("入庫消費税額"))
                End If
                '入庫税込金額
                If IsDBNull(pDataReader("入庫税込金額")) = True Then
                    parArrivalData(i).sTotalPrice = 0
                Else
                    parArrivalData(i).sTotalPrice = CLng(pDataReader("入庫税込金額"))
                End If
                '入庫担当者コード
                parArrivalData(i).sStaffCode = pDataReader("入庫担当者コード").ToString
                '登録日
                parArrivalData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parArrivalData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parArrivalData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parArrivalData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getArrivalData = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataArrivalDBIO.getArrivalData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：注文情報テーブルから該当発注コード・注文明細コードの入庫残数を取得
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getMaxArrivalNo(ByRef parArrivalData() As cStructureLib.sArrivalData, _
                                ByVal KeyOrderCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim i As Integer
        Dim strSelectArrival As String

        Try
            strSelectArrival = "SELECT * FROM 入庫情報データ " & _
            "WHERE 発注コード = @OrderCode " & _
            "ORDER BY 入庫番号 DESC"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectArrival

            '***********************
            '   パラメータの設定
            '***********************

            '発注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@OrderCode").Value = KeyOrderCode

            pDataReader = pCommand.ExecuteReader()

            i = 0

            If pDataReader.Read() Then

                ReDim Preserve parArrivalData(i)

                '発注コード
                parArrivalData(i).sOrderCode = pDataReader("発注コード").ToString
                '入庫番号
                If IsDBNull(pDataReader("入庫番号")) = True Then
                    parArrivalData(i).sArrivalNo = 0
                Else
                    parArrivalData(i).sArrivalNo = CLng(pDataReader("入庫番号"))
                End If
                '入庫日
                parArrivalData(i).sArrivalDate = pDataReader("入庫日").ToString
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parArrivalData(i).sSupplierCode = 0
                Else
                    parArrivalData(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parArrivalData(i).sPaymentCode = 0
                Else
                    parArrivalData(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '入庫税抜商品金額
                If IsDBNull(pDataReader("入庫税抜商品金額")) = True Then
                    parArrivalData(i).sNoTaxTotalProductPrice = 0
                Else
                    parArrivalData(i).sNoTaxTotalProductPrice = CLng(pDataReader("入庫税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parArrivalData(i).sShippingCharge = 0
                Else
                    parArrivalData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parArrivalData(i).sPaymentCharge = 0
                Else
                    parArrivalData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parArrivalData(i).sDiscount = 0
                Else
                    parArrivalData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parArrivalData(i).sPointDisCount = 0
                Else
                    parArrivalData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '入庫税抜金額
                If IsDBNull(pDataReader("入庫税抜金額")) = True Then
                    parArrivalData(i).sNoTaxTotalPrice = 0
                Else
                    parArrivalData(i).sNoTaxTotalPrice = CLng(pDataReader("入庫税抜金額"))
                End If
                '入庫消費税額
                If IsDBNull(pDataReader("入庫消費税額")) = True Then
                    parArrivalData(i).sTaxTotal = 0
                Else
                    parArrivalData(i).sTaxTotal = CLng(pDataReader("入庫消費税額"))
                End If
                '入庫税込金額
                If IsDBNull(pDataReader("入庫税込金額")) = True Then
                    parArrivalData(i).sTotalPrice = 0
                Else
                    parArrivalData(i).sTotalPrice = CLng(pDataReader("入庫税込金額"))
                End If
                '入庫担当者コード
                parArrivalData(i).sStaffCode = pDataReader("入庫担当者コード").ToString
                '登録日
                parArrivalData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parArrivalData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parArrivalData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parArrivalData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                getMaxArrivalNo = CInt(pDataReader("入庫番号"))
            Else
                getMaxArrivalNo = -1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataArrivalDBIO.getMaxArrivalNo)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：注文情報明細テーブルに１レコードを登録するメソッド
    '　引数：in cSubArrivalオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertArrivalData(ByVal parArrivalData As cStructureLib.sArrivalData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertArrival As String

        Try

            'SQL文の設定
            strInsertArrival = "INSERT INTO 入庫情報データ (" & _
                                                "発注コード, " & _
                                                "入庫番号, " & _
                                                "入庫日, " & _
                                                "仕入先コード, " & _
                                                "支払方法コード, " & _
                                                "入庫税抜商品金額, " & _
                                                "送料, " & _
                                                "手数料, " & _
                                                "値引き, " & _
                                                "ポイント値引き, " & _
                                                "入庫税抜金額, " & _
                                                "入庫消費税額, " & _
                                                "入庫税込金額, " & _
                                                "完納フラグ, " & _
                                                "入庫担当者コード, " & _
                                                "登録日, " & _
                                                "登録時間, " & _
                                                "最終更新日, " & _
                                                "最終更新時間 " & _
                                            ") VALUES (" & _
                                                "@OrderCode, " & _
                                                "@ArrivalNo, " & _
                                                "@ArrivalDate, " & _
                                                "@SupplierCode, " & _
                                                "@PaymentCode, " & _
                                                "@NoTaxProductPrice, " & _
                                                "@ShippingCharge, " & _
                                                "@PaymentCharge, " & _
                                                "@Discount, " & _
                                                "@PointDisCount, " & _
                                                "@NoTaxTotalPrice, " & _
                                                "@TaxTotal, " & _
                                                "@TotalPrice, " & _
                                                "@FinishFlg, " & _
                                                "@StaffCode, " & _
                                                "@CreateDate, " & _
                                                "@CreateTime, " & _
                                                "@UpdateDate, " & _
                                                "@UpdateTime " & _
                                            ")"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertArrival

            '***********************
            '   パラメータの設定
            '***********************

            '発注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@OrderCode").Value = parArrivalData.sOrderCode
            '入庫番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ArrivalNo", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ArrivalNo").Value = parArrivalData.sArrivalNo
            '入庫日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ArrivalDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ArrivalDate").Value = parArrivalData.sArrivalDate
            '仕入先コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@SupplierCode").Value = parArrivalData.sSupplierCode
            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@PaymentCode").Value = parArrivalData.sPaymentCode
            '入庫税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxProductPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxProductPrice").Value = parArrivalData.sNoTaxTotalProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShippingCharge").Value = parArrivalData.sShippingCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PaymentCharge").Value = parArrivalData.sPaymentCharge
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Discount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Discount").Value = parArrivalData.sDiscount
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDisCount").Value = parArrivalData.sPointDisCount
            '入庫税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxTotalPrice").Value = parArrivalData.sNoTaxTotalPrice
            '入庫消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxTotal").Value = parArrivalData.sTaxTotal
            '入庫税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TotalPrice").Value = parArrivalData.sTotalPrice
            '完納フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@FinishFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@FinishFlg").Value = parArrivalData.sFinishFlg
            '入庫担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@StaffCode").Value = parArrivalData.sStaffCode
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

            '入庫情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertArrivalData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataArrivalDBIO.insertArrivalData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：入庫情報データの完納フラグを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateFinishFlg(ByVal KeyOrderNumber As String, _
                                    ByVal KeyArriveNo As Integer, _
                                    ByVal KeyFinishFlg As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'SQL文の設定
        strUpdate = "UPDATE 入庫情報データ SET " & _
                            "入庫情報データ.完納フラグ=" & KeyFinishFlg & " " & _
                            "WHERE 入庫情報データ.発注コード = """ & KeyOrderNumber & """ " & _
                            "AND 入庫情報データ.入庫番号 = " & KeyArriveNo
        Try
            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateFinishFlg = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataArrivalDBIO.updateFinishFlg)", Nothing, Nothing, oExcept.ToString)
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
