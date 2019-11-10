Public Class cMstStockDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    '----------------------------------------------------------------------
    '　機能：プロパティの取引コードのレコードが部門マスタに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function StockExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 在庫マスタ WHERE 商品コード = @ProductCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ProductCode").Value = KeyString

            '部門マスタから該当取引コードのレコード数読込 
            StockExist = CInt(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStockDBIO.StockExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getStock(ByRef parStock() As cStructureLib.sStock, ByVal keyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        strSelect = ""

        If keyProductCode = "" Then
            strSelect = "SELECT * FROM 在庫マスタ"
        Else
            strSelect = "SELECT * FROM 在庫マスタ WHERE 商品コード = @ProductCode"
        End If

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            If keyProductCode <> "" Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 13))
                pCommand.Parameters("@ProductCode").Value = keyProductCode
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parStock(i)

                'レコードが取得できた時の処理
                '商品コード
                parStock(i).sProductCode = pDataReader("商品コード").ToString
                '在庫数
                parStock(i).sStockCount = CInt(pDataReader("在庫数"))
                '登録日
                parStock(i).sUpdateDate = pDataReader("登録日").ToString
                '登録日時
                parStock(i).sUpdateTime = pDataReader("登録時間").ToString
                '最終更新日
                parStock(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parStock(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getStock = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStockDBIO.getStock)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ネット掲載マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertStock(ByRef parStock As cStructureLib.sStock, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        'SQL文の設定
        Const strInsert As String = "INSERT INTO 在庫マスタ " & _
                                            "( 商品コード, 在庫数, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                                            "VALUES ( @ProductCode, @StockCount, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parStock.sProductCode.ToString

            '在庫数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StockCount", OleDb.OleDbType.Numeric, 4))
            pCommand.Parameters("@StockCount").Value = CLng(parStock.sStockCount)

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parStock.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parStock.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parStock.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parStock.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '在庫マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertStock = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStockDBIO.insertStock)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：在庫マスタの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateStock(ByVal parStock() As cStructureLib.sStock, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strStock As String

        strStock = "UPDATE 在庫マスタ " & _
                            "SET 在庫数=" & parStock(0).sStockCount & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 商品コード=""" & parStock(0).sProductCode & """"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strStock

            '在庫マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                updateStock = True
            Else
                '更新するレコードがなかった時の処理
                updateStock = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStockDBIO.updateStock)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：在庫マスタの１レコードを削除するメソッド
    '　引数：商品コード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteStock(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 在庫マスタ WHERE 商品コード=""" & KeyProductCode & """"

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '在庫マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteStock = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStockDBIO.deleteStock)", Nothing, Nothing, oExcept.ToString)
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
