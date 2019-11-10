
Public Class cMstSalesDBIO
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
    '　機能：商品販売マスタから１レコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteSalesMst(ByVal KeyProductCode As String, _
                                   ByVal KeyChannelCode As Integer, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction _
                    ) As Long

        Const strDeletePrdMst As String = "DELETE FROM 商品販売マスタ WHERE 商品コード=@ProductCode AND チャネルコード=@ChannelCode"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            pCommand.CommandText = strDeletePrdMst

            'SQL文パラメータの設定
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyProductCode

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ProductCode").Value = KeyChannelCode

            deleteSalesMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalesDBIO.deleteSalesMst)", Nothing, Nothing, oExcept.ToString)
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

    '-------------------------------------------------------------------------------
    '　機能：商品販売マスタから該当レコードを取得する関数
    '　引数：Byval parSales()　：データセットバッファ（sSales Structureの配列）
    '　　　：KeyProductCode　：キー情報
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getSales(ByRef parSales() As cStructureLib.sViewSales, _
                                    ByVal KeyProductCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT 商品販売状況マスタ.商品コード AS 商品コード, " & _
                        "商品販売状況マスタ.チャネルコード AS チャネルコード, " & _
                        "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                        "商品販売状況マスタ.掲載開始日 AS 掲載開始日, " & _
                        "商品販売状況マスタ.掲載終了日 AS 掲載終了日, " & _
                        "チャネルマスタ.売上計上フラグ AS 売上計上フラグ, " & _
                        "商品販売状況マスタ.登録日 AS 登録日, " & _
                        "商品販売状況マスタ.登録時間 AS 登録時間, " & _
                        "商品販売状況マスタ.最終更新日 AS 最終更新日, " & _
                        "商品販売状況マスタ.最終更新時間 AS 最終更新時間 " & _
                        "FROM 商品販売状況マスタ LEFT JOIN チャネルマスタ " & _
                        "ON 商品販売状況マスタ.チャネルコード = チャネルマスタ.チャネルコード " & _
                        "WHERE チャネルマスタ.売上計上フラグ = True "


            'パラメータ指定がある場合
            If KeyProductCode <> Nothing Then
                strSelect = strSelect & "AND 商品コード=@ProductCode"
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyProductCode

            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parSales(i)

                '商品コード
                parSales(i).sProductCode = pDataReader("商品コード").ToString
                'チャネルコード
                parSales(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                'チャネル名称
                parSales(i).sChannelName = pDataReader("チャネル名称").ToString
                '掲載開始日
                parSales(i).sStartDate = pDataReader("掲載開始日").ToString
                '掲載終了日
                parSales(i).sEndDate = pDataReader("掲載終了日").ToString
                '登録日
                parSales(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSales(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSales(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSales(i).sUpdateTime = pDataReader("最終更新時間").ToString



                'レコードが取得できた時の処理
                i = i + 1
            End While

            getSales = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalesDBIO.getSales)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品販売マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSalesMst(ByRef parSales As cStructureLib.sViewSales, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 商品販売マスタ " & _
                                            "( 商品コード, チャネルコード, 掲載開始日, 掲載終了日, " & _
                                            "登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                                            "VALUES ( @ProductCode, @ChannelCode, @StartDate, @endDate, " & _
                                            "@CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

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
            pCommand.Parameters("@ProductCode").Value = parSales.sProductCode.ToString

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parSales.sChannelCode

            '掲載開始日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StartDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@StartDate").Value = parSales.sStartDate.ToString

            '掲載終了日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@endDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@endDate").Value = parSales.sEndDate.ToString

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parSales.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parSales.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parSales.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parSales.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '商品販売マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertSalesMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalesDBIO.insertSalesMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品販売マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateSalesMst(ByRef parSales As cStructureLib.sViewSales, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strUpdate As String = "UPDATE 商品販売マスタ " & _
                                            "SET 商品コード=@ProductCode, " & _
                                            "チャネルコード=@ChannelCode, " & _
                                            "掲載開始日=@StartDate, " & _
                                            "掲載終了日=@endDate, " & _
                                            "登録日=@CreateDate, " & _
                                            "登録時間=@CreateTime, " & _
                                            "最終更新日=@UpdateDate, " & _
                                            "最終更新時間=@UpdateTime " & _
                                            "WHERE 商品コード=@ProductCode"

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
            pCommand.Parameters("@ProductCode").Value = parSales.sProductCode.ToString

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parSales.sChannelCode

            '掲載開始日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StartDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@StartDate").Value = parSales.sStartDate.ToString

            '掲載終了日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@endDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@endDate").Value = parSales.sEndDate.ToString

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '商品販売マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            updateSalesMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSalesDBIO.updateSalesMst)", Nothing, Nothing, oExcept.ToString)
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
