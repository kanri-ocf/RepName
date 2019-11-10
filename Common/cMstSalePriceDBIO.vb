Public Class cMstSalePriceDBIO
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
    Public Function getPriceMst(ByRef parPrice() As cStructureLib.sSalePrice, _
                                ByVal keyProductCode As String, _
                                ByVal KeyChannelCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        strSelect = "SELECT " & _
                        "販売価格マスタ.商品コード, " & _
                        "チャネルマスタ.チャネルコード, " & _
                        "チャネルマスタ.チャネル名称, " & _
                        "販売価格マスタ.販売単価, " & _
                        "販売価格マスタ.適用開始日, " & _
                        "販売価格マスタ.適用終了日, " & _
                        "販売価格マスタ.登録日, " & _
                        "販売価格マスタ.登録時間, " & _
                        "販売価格マスタ.最終更新日, " & _
                        "販売価格マスタ.最終更新時間 " & _
                    "FROM チャネルマスタ LEFT JOIN 販売価格マスタ " & _
                        "ON チャネルマスタ.チャネルコード = 販売価格マスタ.チャネルコード " & _
                    "WHERE 販売価格マスタ.商品コード = @ProductCode " & _
                        "AND 販売価格マスタ.適用終了日 >= Format(Now(), ""yyyy/mm/dd"") "

        If KeyChannelCode <> Nothing Then
            strSelect = strSelect & " And (販売価格マスタ.チャネルコード=@ChannelCode) "
        End If

        strSelect = strSelect & "ORDER BY 販売価格マスタ.チャネルコード, 販売価格マスタ.適用開始日 "

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
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = keyProductCode

            If KeyChannelCode <> Nothing Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
                pCommand.Parameters("@ChannelCode").Value = KeyChannelCode
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parPrice(i)

                'レコードが取得できた時の処理
                '商品格コード
                parPrice(i).sProductCode = pDataReader("商品コード").ToString
                'チャネルコード
                parPrice(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                '販売価格
                parPrice(i).sSalePrice = CLng(pDataReader("販売単価"))
                '適用開始日
                parPrice(i).sStartDate = pDataReader("適用開始日").ToString
                '適用終了日
                parPrice(i).sEndDate = pDataReader("適用終了日").ToString
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalePriceDBIO.getPriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：販売価格マスタに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertPriceMst(ByVal parPrice As cStructureLib.sSalePrice, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 販売価格マスタ " & _
        "( 商品コード, チャネルコード, 販売単価, 適用開始日, 適用終了日, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
        "VALUES (@ProductCode, @ChannelCode, @SalePrice, @StartDate, @EndDate, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

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
            pCommand.Parameters("@ProductCode").Value = parPrice.sProductCode.ToString

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parPrice.sChannelCode

            '販売価格
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SalePrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SalePrice").Value = parPrice.sSalePrice

            '適用開始日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StartDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@StartDate").Value = parPrice.sStartDate.ToString

            '適用終了日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EndDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@EndDate").Value = parPrice.sEndDate.ToString

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parPrice.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parPrice.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parPrice.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parPrice.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '販売価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertPriceMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalePriceDBIO.insertPriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：販売価格マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updatePriceMst(ByRef parPrice() As cStructureLib.sSalePrice, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 販売価格マスタ SET " & _
                            "販売単価=@SalePrice, " & _
                            "適用開始日=@StartDate, " & _
                            "適用終了日=@EndDate, " & _
                            "最終更新日=@UpdateDate, " & _
                            "最終更新時間=@UpdateTime " & _
                            "WHERE 商品コード=@ProductCode AND チャネルコード=@ChannelCode"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strUpdate

            '***********************
            '   パラメータの設定
            '***********************
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parPrice(0).sProductCode.ToString

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parPrice(0).sChannelCode

            '販売価格
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SalePrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SalePrice").Value = parPrice(0).sSalePrice

            '適用開始日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StartDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@StartDate").Value = parPrice(0).sStartDate.ToString

            '適用終了日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EndDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@EndDate").Value = parPrice(0).sEndDate.ToString

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '販売価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            updatePriceMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalePriceDBIO.updatePriceMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：販売価格マスタから当該商品コードレコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deletePriceMst(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 販売価格マスタ WHERE 商品コード=""" & KeyProductCode & """"

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '在庫マスタ削除処理実行()
            deletePriceMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalePriceDBIO.deletePriceMst)", Nothing, Nothing, oExcept.ToString)
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
