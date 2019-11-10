Public Class cMstCostPriceDBIO
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
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getPriceMst(ByRef parPrice() As cStructureLib.sCostPrice,
                                ByVal keyProductCode As String,
                                ByVal KeySupplierCode As Integer,
                                ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT " &
                                 "仕入価格マスタ.商品コード, " &
                                 "仕入先マスタ.仕入先コード, " &
                                 "仕入先マスタ.仕入先名称, " &
                                 "仕入価格マスタ.仕入単価, " &
                                 "仕入価格マスタ.登録日, " &
                                 "仕入価格マスタ.登録時間, " &
                                 "仕入価格マスタ.最終更新日, " &
                                 "仕入価格マスタ.最終更新時間 " &
                             "FROM 仕入先マスタ LEFT JOIN 仕入価格マスタ " &
                             "ON 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " &
                             "WHERE(仕入価格マスタ.商品コード = """ & keyProductCode & """) "

            If KeySupplierCode <> Nothing Then
                strSelect = strSelect & " And (仕入価格マスタ.仕入先コード = " & KeySupplierCode & ") "
            End If

            strSelect = strSelect & "ORDER BY 仕入価格マスタ.仕入先コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = keyProductCode

            If KeySupplierCode <> Nothing Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 1))
                pCommand.Parameters("@SupplierCode").Value = KeySupplierCode
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parPrice(i)

                'レコードが取得できた時の処理
                '商品格コード
                parPrice(i).sProductCode = pDataReader("商品コード").ToString
                '仕入先コード
                parPrice(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                '仕入価格
                parPrice(i).sCostPrice = CLng(pDataReader("仕入単価"))
                '登録日
                parPrice(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parPrice(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parPrice(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parPrice(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getPriceMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.getPriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getAvgCostPrice(ByRef parAvgCostPrice() As cStructureLib.sViewAvgCostPrice, _
                                ByVal keyProductCode As String, _
                                ByVal KeySupplierCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT DISTINCT " & _
                                 "仕入価格マスタ.商品コード AS 商品コード, " & _
                                 "AVG(仕入価格マスタ.仕入単価) AS 標準単価 " & _
                             "FROM 仕入価格マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyProductCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeySupplierCode <> Nothing Then
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
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品コード = """ & keyProductCode & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "仕入先コード = " & KeySupplierCode
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "GROUP BY 仕入価格マスタ.商品コード, 仕入価格マスタ.仕入先コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() Then
                ReDim Preserve parAvgCostPrice(0)

                'レコードが取得できた時の処理
                '商品格コード
                parAvgCostPrice(0).sProductCode = pDataReader("商品コード").ToString
                '標準単価
                parAvgCostPrice(0).sAvgCostPrice = CLng(pDataReader("標準単価"))

            End If

            getAvgCostPrice = CLng(pDataReader("標準単価"))

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.getAvgCostPrice)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getFirstPrice(ByRef parPrice() As cStructureLib.sCostPrice, _
                                ByVal keyProductCode As String, _
                                ByVal KeyOperetion As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT " & _
                                 "仕入価格マスタ.商品コード, " & _
                                 "仕入先マスタ.仕入先コード, " & _
                                 "仕入先マスタ.仕入先名称, " & _
                                 "仕入価格マスタ.仕入単価, " & _
                                 "仕入価格マスタ.登録日, " & _
                                 "仕入価格マスタ.登録時間, " & _
                                 "仕入価格マスタ.最終更新日, " & _
                                 "仕入価格マスタ.最終更新時間 " & _
                             "FROM 仕入先マスタ LEFT JOIN 仕入価格マスタ " & _
                             "ON 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " & _
                             "WHERE(仕入価格マスタ.商品コード = """ & keyProductCode & """) "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parPrice(i)

                'レコードが取得できた時の処理
                '商品格コード
                parPrice(i).sProductCode = pDataReader("商品コード").ToString
                '仕入先コード
                parPrice(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                '仕入単価
                parPrice(i).sCostPrice = CLng(pDataReader("仕入単価"))
                '登録日
                parPrice(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parPrice(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parPrice(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parPrice(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getFirstPrice = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.getFirstPrice)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次発注情報データから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getUnionSupplier(ByRef parSupplierCode() As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Long

        Try
            strSelect = ""

            'strSelect = "SELECT 仕入価格マスタ.仕入先コード " & _
            '                "FROM [SELECT Count(発注状態データ.選択状態) AS 選択商品数 FROM 発注状態データ " & _
            '                "HAVING (((Count(発注状態データ.選択状態))=True))]. AS 選択状態, " & _
            '                "発注状態データ " & _
            '                "INNER JOIN 仕入価格マスタ " & _
            '                "ON 発注状態データ.商品コード = 仕入価格マスタ.商品コード " & _
            '                "GROUP BY 仕入価格マスタ.仕入先コード, 選択状態.選択商品数 " & _
            '                "HAVING (((Count(発注状態データ.商品コード))=[選択商品数]))"

            strSelect = "SELECT 仕入価格マスタ.仕入先コード " & _
                        "FROM " & _
                            "[ " & _
                                "SELECT Count(発注状態データ.選択状態) AS 選択商品数 FROM 発注状態データ " & _
                                "HAVING (Count(発注状態データ.選択状態)=True)" & _
                            "]. AS 選択状態, " & _
                            "発注状態データ INNER JOIN 仕入価格マスタ " & _
                            "ON 発注状態データ.商品コード = 仕入価格マスタ.商品コード " & _
                        "GROUP BY 仕入価格マスタ.仕入先コード, 選択状態.選択商品数 " & _
                        "HAVING (Count(発注状態データ.商品コード)=[選択商品数]) "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parSupplierCode(i)

                'レコードが取得できた時の処理
                '仕入先コード
                parSupplierCode(i) = CInt(pDataReader("仕入先コード"))

                i = i + 1
            End While

            getUnionSupplier = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.getUnionSupplier)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：仕入価格マスタに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertPriceMst(ByVal parCostPrice As cStructureLib.sCostPrice, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 仕入価格マスタ (" & _
                                        "商品コード, " & _
                                        "仕入先コード, " & _
                                        "仕入単価, " & _
                                        "登録日, " & _
                                        "登録時間, " & _
                                        "最終更新日, " & _
                                        "最終更新時間 " & _
                                    ") VALUES (" & _
                                        "@ProductCode, " & _
                                        "@SupplierCode, " & _
                                        "@CostPrice, " & _
                                        "@CreateDate, " & _
                                        "@CreateTime, " & _
                                        "@UpdateDate, " & _
                                        "@UpdateTime " & _
                                    ")"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parCostPrice.sProductCode
            '仕入先コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@SupplierCode").Value = parCostPrice.sSupplierCode
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CostPrice").Value = parCostPrice.sCostPrice
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

            '仕入価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertPriceMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.insertPriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：仕入価格マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updatePriceMst(ByRef parPrice() As cStructureLib.sCostPrice, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strUpdate As String

        Try

            'SQL文の設定
            strUpdate = "UPDATE 仕入価格マスタ SET " & _
                                "仕入単価=@SalePrice, " & _
                                "最終更新日=@UpdateDate, " & _
                                "最終更新時間=@UpdateTime " & _
                                "WHERE 商品コード= @ProductCode AND 仕入先コード=@SupplierCode"


            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            '位置修正
            'Try

            pCommand.CommandText = strUpdate

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータの順番がSQL通りでなければいけないので修正(パラメータを使用する際)
            ''商品コード
            'pCommand.Parameters.Add _
            '(New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            'pCommand.Parameters("@ProductCode").Value = parPrice(0).sProductCode.ToString

            ''仕入先コード
            'pCommand.Parameters.Add _
            '(New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 1))
            'pCommand.Parameters("@SupplierCode").Value = parPrice(0).sSupplierCode

            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SalePrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SalePrice").Value = parPrice(0).sCostPrice

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)


            'パラメータの順番がSQL通りでなければいけないので修正(パラメータを使用する際)
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parPrice(0).sProductCode.ToString

            '仕入先コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@SupplierCode").Value = parPrice(0).sSupplierCode



            '仕入価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            updatePriceMst = 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.updatePriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：仕入価格マスタから当該商品コードレコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deletePriceMst(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 仕入価格マスタ WHERE 商品コード=""" & KeyProductCode & """"

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '在庫マスタ削除処理実行()
            deletePriceMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCostPriceDBIO.deletePriceMst)", Nothing, Nothing, oExcept.ToString)
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
