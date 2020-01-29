Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cDataOrderSubDBIO

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
    Public Function OrderSubExist(ByVal KeyString As String,
                                  ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Const strSelectOrder As String =
        "SELECT COUNT(*) FROM 発注情報明細データ WHERE 発注コード = @OrderCode"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectOrder

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@OrderCode").Value = KeyString

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
    '　機能：発注情報テーブルから該当発注コード・発注明細コードのデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getOrderSubData(ByRef parOrderSubData() As cStructureLib.sOrderSubData,
                                ByVal KeyOrderCode As String,
                                ByVal KeyOrderSubCode As Integer,
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim strSelectOrder As String

        Try
            strSelectOrder = "SELECT  " &
                                "発注情報明細データ.発注コード, " &
                                "発注情報明細データ.発注明細コード, " &
                                "発注情報明細データ.JANコード, " &
                                "発注情報明細データ.商品コード, " &
                                "発注情報明細データ.商品名称, " &
                                "発注情報明細データ.オプション1, " &
                                "発注情報明細データ.オプション2, " &
                                "発注情報明細データ.オプション3, " &
                                "発注情報明細データ.オプション4, " &
                                "発注情報明細データ.オプション5, " &
                                "発注情報明細データ.定価, " &
                                "発注情報明細データ.仕入単価, " &
                                "発注情報明細データ.発注商品単価, " &
                                "発注情報明細データ.発注数量, " &
                                "発注情報明細データ.発注税抜金額, " &
                                "発注情報明細データ.軽減税率, " &
                                "発注情報明細データ.発注消費税額, " &
                                "発注情報明細データ.発注税込金額, " &
                                "発注情報明細データ.発注中止フラグ, " &
                                "発注情報明細データ.発注中止事由, " &
                                "発注情報明細データ.登録日, " &
                                "発注情報明細データ.登録時間, " &
                                "発注情報明細データ.最終更新日, " &
                                "発注情報明細データ.最終更新時間 " &
                            "FROM 発注情報明細データ " &
                            "WHERE 発注情報明細データ.発注コード = @OrderCode "

            If KeyOrderSubCode <> Nothing Then
                strSelectOrder = strSelectOrder & "AND 発注情報明細データ.発注明細コード = @OrderSubCode "
            End If

            strSelectOrder = strSelectOrder & "ORDER BY 発注情報明細データ.商品名称, " &
                                "発注情報明細データ.オプション1, " &
                                "発注情報明細データ.オプション2, " &
                                "発注情報明細データ.オプション3, " &
                                "発注情報明細データ.オプション4, " &
                                "発注情報明細データ.オプション5 "


            ''コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectOrder

            '***********************
            '   パラメータの設定
            '***********************

            '2020,1,14 A.Komita Nothing判定時のelseを追加 From
            '発注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            If KeyOrderCode <> Nothing Then
                pCommand.Parameters("@OrderCode").Value = KeyOrderCode
            Else
                pCommand.Parameters("@OrderCode").Value = ""
            End If

            '発注明細コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@OrderSubCode", OleDb.OleDbType.Numeric, 2))
            If KeyOrderSubCode <> Nothing Then
                pCommand.Parameters("@OrderSubCode").Value = KeyOrderSubCode
            Else
                pCommand.Parameters("@OrderSubCode").Value = 0
            End If
            '2020,1,14 A.Komita 追加 To 

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parOrderSubData(i)

                '発注コード
                parOrderSubData(i).sOrderCode = pDataReader("発注コード").ToString
                '発注明細コード
                If IsDBNull(pDataReader("発注明細コード")) = True Then
                    parOrderSubData(i).sOrderSubCode = 0
                Else
                    parOrderSubData(i).sOrderSubCode = CInt(pDataReader("発注明細コード"))
                End If
                'JANコード
                parOrderSubData(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parOrderSubData(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parOrderSubData(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parOrderSubData(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parOrderSubData(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parOrderSubData(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parOrderSubData(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parOrderSubData(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parOrderSubData(i).sListPrice = 0
                Else
                    parOrderSubData(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parOrderSubData(i).sCostPrice = 0
                Else
                    parOrderSubData(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '発注商品単価
                If IsDBNull(pDataReader("発注商品単価")) = True Then
                    parOrderSubData(i).sUnitPrice = 0
                Else
                    parOrderSubData(i).sUnitPrice = CLng(pDataReader("発注商品単価"))
                End If
                '発注数量
                If IsDBNull(pDataReader("発注数量")) = True Then
                    parOrderSubData(i).sCount = 0
                Else
                    parOrderSubData(i).sCount = CLng(pDataReader("発注数量"))
                End If
                '発注税抜金額
                If IsDBNull(pDataReader("発注税抜金額")) = True Then
                    parOrderSubData(i).sNoTaxPrice = 0
                Else
                    parOrderSubData(i).sNoTaxPrice = CLng(pDataReader("発注税抜金額"))
                End If

                '2019/9/22 shimizu add start
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parOrderSubData(i).sReducedTaxRate = String.Empty
                Else
                    parOrderSubData(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                End If
                '2019/9/22 shimizu add end

                '発注消費税額
                If IsDBNull(pDataReader("発注消費税額")) = True Then
                    parOrderSubData(i).sTaxPrice = 0
                Else
                    parOrderSubData(i).sTaxPrice = CLng(pDataReader("発注消費税額"))
                End If
                '発注税込金額
                If IsDBNull(pDataReader("発注税込金額")) = True Then
                    parOrderSubData(i).sPrice = 0
                Else
                    parOrderSubData(i).sPrice = CLng(pDataReader("発注税込金額"))
                End If
                '発注中止フラグ
                If IsDBNull(pDataReader("発注中止フラグ")) = True Then
                    parOrderSubData(i).sOrderCancelFlg = Nothing
                Else
                    parOrderSubData(i).sOrderCancelFlg = CBool(pDataReader("発注中止フラグ"))
                End If
                '発注中止事由
                parOrderSubData(i).sCancelReason = pDataReader("発注中止事由").ToString
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
    '　機能：発注情報明細テーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertOrderSubData(ByVal parOrderSubData As cStructureLib.sOrderSubData,
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertOrder As String

        Try

            'SQL文の設定
            strInsertOrder = "INSERT INTO 発注情報明細データ ( " &
                                "発注コード, " &
                                "発注明細コード, " &
                                "JANコード, " &
                                "商品コード, " &
                                "商品名称, " &
                                "オプション1, " &
                                "オプション2, " &
                                "オプション3, " &
                                "オプション4, " &
                                "オプション5, " &
                                "定価, " &
                                "仕入単価, " &
                                "発注商品単価, " &
                                "発注数量, " &
                                "発注税抜金額, " &
                                "軽減税率, " &
                                "発注消費税額, " &
                                "発注税込金額, " &
                                "発注中止フラグ, " &
                                "発注中止事由, " &
                                "登録日, " &
                                "登録時間, " &
                                "最終更新日, " &
                                "最終更新時間 " &
                            ") VALUES (" &
                                "@OrderCode, " &
                                "@OrderSubCode, " &
                                "@JANCode, " &
                                "@ProductCode, " &
                                "@ProductName, " &
                                "@Option1, " &
                                "@Option2, " &
                                "@Option3, " &
                                "@Option4, " &
                                "@Option5, " &
                                "@ListPrice, " &
                                "@CostPrice, " &
                                "@UnitPrice, " &
                                "@Count, " &
                                "@NoTaxPrice, " &
                                "@ReducedTaxRate, " &
                                "@TaxPrice, " &
                                "@Price, " &
                                "@OrderCancelFlg, " &
                                "@CancelReason, " &
                                "@CreateDate, " &
                                "@CreateTime, " &
                                "@UpdateDate, " &
                                "@UpdateTime " &
                            ")"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertOrder

            '***********************
            '   パラメータの設定
            '***********************

            '"'発注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@OrderCode").Value = parOrderSubData.sOrderCode
            '発注明細コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderSubCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@OrderSubCode").Value = parOrderSubData.sOrderSubCode
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parOrderSubData.sJANCode
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parOrderSubData.sProductCode
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@ProductName").Value = parOrderSubData.sProductName
            'オプション1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option1", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option1").Value = parOrderSubData.sOption1
            'オプション2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option2", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option2").Value = parOrderSubData.sOption2
            'オプション3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option3", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option3").Value = parOrderSubData.sOption3
            'オプション4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option4", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option4").Value = parOrderSubData.sOption4
            'オプション5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option5", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option5").Value = parOrderSubData.sOption5
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ListPrice").Value = parOrderSubData.sListPrice
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CostPrice").Value = parOrderSubData.sCostPrice
            '発注商品単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@UnitPrice").Value = parOrderSubData.sUnitPrice
            '発注数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Count").Value = parOrderSubData.sCount
            '発注税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxPrice").Value = parOrderSubData.sNoTaxPrice

            '2019/9/22 shimizu add start
            '軽減税率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ReducedTaxRate").Value = parOrderSubData.sReducedTaxRate
            '2019/9/22 shimizu add end

            '発注消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxPrice").Value = parOrderSubData.sTaxPrice
            '発注税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Price").Value = parOrderSubData.sPrice
            '発注中止フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCancelFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@OrderCancelFlg").Value = False
            '発注中止事由
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CancelReason", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@CancelReason").Value = ""
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

            '発注情報明細データ挿入処理実行
            pCommand.ExecuteNonQuery()

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
    '　機能：発注情報明細データの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateOrderSub(ByVal parOrderSubData() As cStructureLib.sOrderSubData,
                                   ByVal KeyOrderCode As String,
                                   ByVal KeyOrderSubCode As String,
                                   ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        strUpdate = "UPDATE 発注情報明細データ " &
                        "SET 発注中止フラグ=" & parOrderSubData(0).sOrderCancelFlg & ", " &
                        "発注中止事由=""" & parOrderSubData(0).sCancelReason & """ " &
                        "WHERE 発注コード=""" & KeyOrderCode & """ " & "AND 発注明細コード=" & KeyOrderSubCode

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '発注情報明細データ更新SQL文実行
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
    Public Function deleteOrderSubData(ByVal OrderNumber As String,
                                       ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strDeleteOrder As String

        Try
            '*********************************
            '発注情報明細データ削除SQL文の設定
            '*********************************
            strDeleteOrder = "DELETE 発注情報明細データ.発注コード FROM 発注情報明細データ " &
                "WHERE 発注情報明細データ.発注コード=@OrderNumber"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

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



    '----------------------------------------------------
    '2015/07/07
    '及川和彦
    '商品コードで絞込
    'FROM
    '----------------------------------------------------

    Public Function getOrderSubProduct(ByVal KeyProductCode As String, ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelect As String


        Try
            strSelect = ""
            strSelect = "SELECT COUNT(*) AS CNT FROM 発注情報明細データ WHERE 商品コード = """ & KeyProductCode & """"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()

            getOrderSubProduct = CLng(pDataReader("CNT"))

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cArrivalDataSubDBIO.getArrivalSubData)", Nothing, Nothing, oExcept.ToString)
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
    '----------------------------------------------------
    'HERE
    '----------------------------------------------------




End Class
