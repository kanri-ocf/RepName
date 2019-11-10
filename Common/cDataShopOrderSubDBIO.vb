Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cDataShopOrderSubDBIO

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
    '　機能：プロパティの取引コードのレコードが取引テーブルに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function OrderSubExist(ByVal KeyString As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelectOrder As String = _
        "SELECT COUNT(*) FROM 店頭注文情報明細データ WHERE 受注コード = @RequestCode"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectOrder

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@RequestCode").Value = KeyString

            '取引テーブルから該当取引コードのレコード数読込 
            Dim recCount As Integer
            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                OrderSubExist = True
            Else
                'レコードが存在しない時の処理
                OrderSubExist = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cOrderDataSubDBIO.OrderSubExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文明細テーブルから該当受注コード・受注明細コードのデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getOrderSubData(ByRef parOrderSubData() As cStructureLib.sShopOderSubData, _
                                ByVal KeyRequestCode As String, _
                                ByVal KeyRequestSubCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim strSelectOrder As String

        Try

            strSelectOrder = "SELECT  " & _
                                "店頭注文明細データ.受注コード, " & _
                                "店頭注文明細データ.受注明細コード, " & _
                                "店頭注文明細データ.値引, " & _
                                "店頭注文明細データ.販売合計, " & _
                                "店頭注文明細データ.状態, " & _
                                "店頭注文明細データ.備考, " & _
                                "店頭注文明細データ.登録日, " & _
                                "店頭注文明細データ.登録時間, " & _
                                "店頭注文明細データ.最終更新日, " & _
                                "店頭注文明細データ.最終更新時間 " & _
                            "FROM 店頭注文明細データ " & _
                            "WHERE 店頭注文明細データ.受注コード=@RequestCode "

            If KeyRequestSubCode <> Nothing Then
                strSelectOrder = strSelectOrder & _
                "AND 店頭注文明細データ.受注明細コード=@RequestSubCode "
            End If

            strSelectOrder = strSelectOrder & "ORDER BY 店頭注文明細データ.受注コード, " & _
                                "店頭注文明細データ.受注明細コード "


            ''コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectOrder

            '***********************
            '   パラメータの設定
            '***********************

            '受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = KeyRequestCode

            If KeyRequestSubCode <> Nothing Then
                '発注明細コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@RequestSubCode", OleDb.OleDbType.Numeric, 2))
                pCommand.Parameters("@RequestSubCode").Value = KeyRequestSubCode
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parOrderSubData(i)

                '受注コード
                parOrderSubData(i).sRequestCode = pDataReader("受注コード").ToString
                '発注明細コード
                parOrderSubData(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))
                '値引
                parOrderSubData(i).sProductDiscount = CLng(pDataReader("値引").ToString)
                '販売合計　（販売単価 × 数量) 注：税抜 
                parOrderSubData(i).sSalesTotal = CLng(pDataReader("販売合計").ToString)
                '状態
                parOrderSubData(i).sSubState = CInt(pDataReader("状態").ToString)
                '備考
                parOrderSubData(i).sSubMemo = pDataReader("備考").ToString
                '登録日
                parOrderSubData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parOrderSubData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parOrderSubData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parOrderSubData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                i = i + 1

            End While
            getOrderSubData = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cOrderDataSubDBIO.getOrderSubData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文明細テーブルに複数レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertOrderSubData(ByVal parShopOrderSubData() As cStructureLib.sShopOderSubData, _
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim i As Integer
        Dim strInsertOrder As String

        Try
            'グリッドの行数分インサート実行する。
            For i = 0 To parShopOrderSubData.Count - 1

                'SQL文の設定
                strInsertOrder = "INSERT INTO 店頭注文明細データ ( " & _
                                    "受注コード, " & _
                                    "受注明細コード, " & _
                                    "値引, " & _
                                    "販売合計, " & _
                                    "状態, " & _
                                    "備考, " & _
                                    "登録日, " & _
                                    "登録時間, " & _
                                    "最終更新日, " & _
                                    "最終更新時間 " & _
                                ") VALUES (" & _
                                    "@RequestCode, " & _
                                    "@RequestSubCode, " & _
                                    "@ProductDiscount, " & _
                                    "@SalesTotal, " & _
                                    "@SubState, " & _
                                    "@SubMemo, " & _
                                    "@CreateDate, " & _
                                    "@CreateTime, " & _
                                    "@UpdateDate, " & _
                                    "@UpdateTime " & _
                                ")"

                pCommand = pConn.CreateCommand
                pCommand.Transaction = Tran

                pCommand.CommandText = strInsertOrder

                '***********************
                '   パラメータの設定
                '***********************

                '受注コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
                pCommand.Parameters("@RequestCode").Value = parShopOrderSubData(i).sRequestCode
                '受注明細コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@RequestSubCode", OleDb.OleDbType.Numeric, 2))
                pCommand.Parameters("@RequestSubCode").Value = parShopOrderSubData(i).sRequestSubCode
                '値引
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ProductDiscount", OleDb.OleDbType.Numeric, 10))
                pCommand.Parameters("@ProductDiscount").Value = parShopOrderSubData(i).sProductDiscount
                '販売合計
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SalesTotal", OleDb.OleDbType.Numeric, 10))
                pCommand.Parameters("@SalesTotal").Value = parShopOrderSubData(i).sSalesTotal
                '状態
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SubState", OleDb.OleDbType.Numeric, 1))
                pCommand.Parameters("@SubState").Value = parShopOrderSubData(i).sSubState
                '備考
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SubMemo", OleDb.OleDbType.Char, 50))
                pCommand.Parameters("@SubMemo").Value = parShopOrderSubData(i).sSubMemo
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

                '店頭注文情報明細データ挿入処理実行
                pCommand.ExecuteNonQuery()

            Next i

            insertOrderSubData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cOrderDataSubDBIO.insertOrderSubData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文情報明細データの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateOrderSub(ByVal parOrderSubData() As cStructureLib.sOrderSubData, _
                                   ByVal KeyRequestCode As String, _
                                   ByVal KeyRequestSubCode As String, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim RecordCount As Integer
        Dim strUpdate As String

        strUpdate = "UPDATE 店頭注文明細データ " & _
                        "SET 発注中止フラグ=" & parOrderSubData(0).sOrderCancelFlg & ", " & _
                        "発注中止事由=""" & parOrderSubData(0).sCancelReason & """ " & _
                        "WHERE 受注コード=""" & KeyRequestCode & """ " & "AND 発注明細コード=" & KeyRequestSubCode

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '店頭注文明細データ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                updateOrderSub = True
            Else
                '更新するレコードがなかった時の処理
                updateOrderSub = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cOrderDataSubDBIO.updateOrderSub)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteOrderSubData(ByVal OrderNumber As String, _
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDeleteOrder As String

        Try
            '*********************************
            '店頭注文情報明細データ削除SQL文の設定
            '*********************************
            strDeleteOrder = "DELETE 店頭注文明細データ.受注コード FROM 店頭注文明細データ " & _
                "WHERE 店頭注文明細データ.受注コード=@OrderNumber"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteOrder

            '***********************
            '   パラメータの設定
            '***********************

            '発注番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = OrderNumber

            '発注情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteOrderSubData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cOrderDataSubDBIO.deleteOrderSubData)", Nothing, Nothing, oExcept.ToString)
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
