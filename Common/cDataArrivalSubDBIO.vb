Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cDataArrivalSubDBIO

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
    '　機能：注文情報テーブルから該当注文コード・注文明細コードのデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getArrivalSubData(ByRef parArrivalSubData() As cStructureLib.sArrivalSubData, _
                                ByVal KeyArrivalCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer

        Try
            Const strSelectArrival As String = _
            "SELECT * FROM 入庫情報明細データ WHERE 発注コード = @OrderCode"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectArrival

            '***********************
            '   パラメータの設定
            '***********************

            '2020,1,14 A.Komita Nothing判定時のelseを追加 From
            '取引コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderCode", OleDb.OleDbType.Char, 13))
            If KeyArrivalCode <> Nothing Then
                pCommand.Parameters("@OrderCode").Value = KeyArrivalCode
            Else
                pCommand.Parameters("@OrderCode").Value = ""
            End If
            '2020,1,14 A.Komita 追加 To 

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parArrivalSubData(i)

                '発注コード
                parArrivalSubData(i).sOrderCode = pDataReader("発注コード").ToString
                '発注明細コード
                If IsDBNull(pDataReader("発注明細コード")) = True Then
                    parArrivalSubData(i).sOrderDetailNo = 0
                Else
                    parArrivalSubData(i).sOrderDetailNo = CInt(pDataReader("発注明細コード"))
                End If
                '入庫番号
                If IsDBNull(pDataReader("入庫番号")) = True Then
                    parArrivalSubData(i).sArrivalNo = 0
                Else
                    parArrivalSubData(i).sArrivalNo = CInt(pDataReader("入庫番号"))
                End If
                'JANコード
                parArrivalSubData(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parArrivalSubData(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parArrivalSubData(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parArrivalSubData(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parArrivalSubData(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parArrivalSubData(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parArrivalSubData(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parArrivalSubData(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parArrivalSubData(i).sListPrice = 0
                Else
                    parArrivalSubData(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parArrivalSubData(i).sCostPrice = 0
                Else
                    parArrivalSubData(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '入庫商品単価
                If IsDBNull(pDataReader("入庫商品単価")) = True Then
                    parArrivalSubData(i).sUnitPrice = 0
                Else
                    parArrivalSubData(i).sUnitPrice = CLng(pDataReader("入庫商品単価"))
                End If
                '入庫数量
                If IsDBNull(pDataReader("入庫数量")) = True Then
                    parArrivalSubData(i).sCount = 0
                Else
                    parArrivalSubData(i).sCount = CInt(pDataReader("入庫数量"))
                End If
                '入庫税抜金額
                If IsDBNull(pDataReader("入庫税抜金額")) = True Then
                    parArrivalSubData(i).sNoTaxPrice = 0
                Else
                    parArrivalSubData(i).sNoTaxPrice = CLng(pDataReader("入庫税抜金額"))
                End If
                '入庫消費税額
                If IsDBNull(pDataReader("入庫消費税額")) = True Then
                    parArrivalSubData(i).sTaxPrice = 0
                Else
                    parArrivalSubData(i).sTaxPrice = CLng(pDataReader("入庫消費税額"))
                End If
                '入庫税込金額
                If IsDBNull(pDataReader("入庫税込金額")) = True Then
                    parArrivalSubData(i).sPrice = 0
                Else
                    parArrivalSubData(i).sPrice = CLng(pDataReader("入庫税込金額"))
                End If
                '納入残数
                If IsDBNull(pDataReader("納入残数")) = True Then
                    parArrivalSubData(i).sArrivalStiffness = 0
                Else
                    parArrivalSubData(i).sArrivalStiffness = CLng(pDataReader("納入残数"))
                End If
                '登録日
                parArrivalSubData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parArrivalSubData(i).ScreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parArrivalSubData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parArrivalSubData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                i = i + 1

            End While
            getArrivalSubData = i

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
    '----------------------------------------------------------------------
    '　機能：注文情報テーブルから該当注文コード・注文明細コードの入庫残数を取得
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSitffnessCount(ByRef parArrivalSubData() As cStructureLib.sArrivalSubData, _
                                ByVal KeyOrderCode As String, _
                                ByVal KeyOrderSubCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim i As Integer
        Dim strSelectArrival As String

        Try
            strSelectArrival = "SELECT " & _
                                    "入庫情報明細データ.発注コード, " & _
                                    "入庫情報明細データ.発注明細コード, " & _
                                    "入庫情報明細データ.商品コード, " & _
                                    "Min(入庫情報明細データ.納入残数) AS 納入残数 " & _
                                "FROM(入庫情報明細データ) " & _
                                "GROUP BY " & _
                                    "入庫情報明細データ.発注コード, " & _
                                    "入庫情報明細データ.発注明細コード, " & _
                                    "入庫情報明細データ.商品コード " & _
                                "HAVING (((入庫情報明細データ.発注コード)= """ & KeyOrderCode & """) " & _
                                "AND ((入庫情報明細データ.発注明細コード)= " & KeyOrderSubCode & "))"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectArrival

            pDataReader = pCommand.ExecuteReader()

            i = 0

            If pDataReader.Read() Then

                ReDim Preserve parArrivalSubData(i)

                '発注コード
                parArrivalSubData(i).sOrderCode = pDataReader("発注コード").ToString
                '発注明細コード
                If IsDBNull(pDataReader("発注明細コード")) = True Then
                    parArrivalSubData(i).sOrderDetailNo = 0
                Else
                    parArrivalSubData(i).sOrderDetailNo = CInt(pDataReader("発注明細コード"))
                End If
                '商品コード
                parArrivalSubData(i).sProductCode = pDataReader("商品コード").ToString
                '納入残数
                parArrivalSubData(i).sArrivalStiffness = CInt(pDataReader("納入残数"))

                getSitffnessCount = CInt(pDataReader("納入残数"))
            Else
                getSitffnessCount = -1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cArrivalDataSubDBIO.getSitffnessCount)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：注文情報テーブルから該当注文コード・注文明細コードの入庫残数を取得
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getLastArrivalSubData(ByRef parArrivalSubData() As cStructureLib.sArrivalSubData, _
                                ByVal KeyOrderCode As String, _
                                ByVal KeyOrderSubCode As Integer, _
                                ByVal KeyProductCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim strSelectArrival As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer

        Try
            strSelectArrival = "SELECT * FROM 入庫情報明細データ "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'パラメータ数のカウント
            pc = 0
            mpc = 0
            If KeyOrderCode <> Nothing Then
                mpc = 1
                pc = pc Or mpc
            End If
            If KeyOrderSubCode <> Nothing Then
                mpc = 2
                pc = pc Or mpc
            End If
            If KeyProductCode <> Nothing Then
                mpc = 4
                pc = pc Or mpc
            End If

            'パラメータ指定がある場合
            If (mpc And pc) > 0 Then
                i = 1
                scnt = 0
                While i <= mpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelectArrival = strSelectArrival & "AND "
                            Else
                                strSelectArrival = strSelectArrival & "WHERE "
                            End If
                            strSelectArrival = strSelectArrival & "発注コード= """ & KeyOrderCode & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelectArrival = strSelectArrival & "AND "
                            Else
                                strSelectArrival = strSelectArrival & "WHERE "
                            End If
                            strSelectArrival = strSelectArrival & "発注明細コード= " & KeyOrderSubCode & " "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelectArrival = strSelectArrival & "AND "
                            Else
                                strSelectArrival = strSelectArrival & "WHERE "
                            End If
                            strSelectArrival = strSelectArrival & "商品コード= """ & KeyProductCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelectArrival = strSelectArrival & "ORDER BY 入庫番号 DESC "

            'SQL文の設定
            pCommand.CommandText = strSelectArrival

            pDataReader = pCommand.ExecuteReader()

            i = 0

            If pDataReader.Read() Then

                ReDim Preserve parArrivalSubData(i)

                '発注コード
                parArrivalSubData(i).sOrderCode = pDataReader("発注コード").ToString
                '発注明細コード
                If IsDBNull(pDataReader("発注明細コード")) = True Then
                    parArrivalSubData(i).sOrderDetailNo = 0
                Else
                    parArrivalSubData(i).sOrderDetailNo = CInt(pDataReader("発注明細コード"))
                End If
                '入庫番号
                If IsDBNull(pDataReader("入庫番号")) = True Then
                    parArrivalSubData(i).sArrivalNo = 0
                Else
                    parArrivalSubData(i).sArrivalNo = CInt(pDataReader("入庫番号"))
                End If
                'JANコード
                parArrivalSubData(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parArrivalSubData(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parArrivalSubData(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parArrivalSubData(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parArrivalSubData(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parArrivalSubData(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parArrivalSubData(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parArrivalSubData(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parArrivalSubData(i).sListPrice = 0
                Else
                    parArrivalSubData(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parArrivalSubData(i).sCostPrice = 0
                Else
                    parArrivalSubData(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '入庫商品単価
                If IsDBNull(pDataReader("入庫商品単価")) = True Then
                    parArrivalSubData(i).sUnitPrice = 0
                Else
                    parArrivalSubData(i).sUnitPrice = CLng(pDataReader("入庫商品単価"))
                End If
                '入庫数量
                If IsDBNull(pDataReader("入庫数量")) = True Then
                    parArrivalSubData(i).sCount = 0
                Else
                    parArrivalSubData(i).sCount = CInt(pDataReader("入庫数量"))
                End If
                '入庫税抜金額
                If IsDBNull(pDataReader("入庫税抜金額")) = True Then
                    parArrivalSubData(i).sNoTaxPrice = 0
                Else
                    parArrivalSubData(i).sNoTaxPrice = CLng(pDataReader("入庫税抜金額"))
                End If
                '入庫消費税額
                If IsDBNull(pDataReader("入庫消費税額")) = True Then
                    parArrivalSubData(i).sTaxPrice = 0
                Else
                    parArrivalSubData(i).sTaxPrice = CLng(pDataReader("入庫消費税額"))
                End If
                '入庫税込金額
                If IsDBNull(pDataReader("入庫税込金額")) = True Then
                    parArrivalSubData(i).sPrice = 0
                Else
                    parArrivalSubData(i).sPrice = CLng(pDataReader("入庫税込金額"))
                End If
                '納入残数
                If IsDBNull(pDataReader("納入残数")) = True Then
                    parArrivalSubData(i).sArrivalStiffness = 0
                Else
                    parArrivalSubData(i).sArrivalStiffness = CLng(pDataReader("納入残数"))
                End If
                '登録日
                parArrivalSubData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parArrivalSubData(i).ScreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parArrivalSubData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parArrivalSubData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                getLastArrivalSubData = CInt(pDataReader("納入残数"))
            Else
                getLastArrivalSubData = -1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cArrivalDataSubDBIO.getLastArrivalSubData)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertArrivalSubData(ByVal parArrivalSubData As cStructureLib.sArrivalSubData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertArrival As String

        Try

            'SQL文の設定
            strInsertArrival = "INSERT INTO 入庫情報明細データ (" &
                                    "発注コード, " &
                                    "発注明細コード, " &
                                    "入庫番号, " &
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
                                    "入庫商品単価, " &
                                    "入庫数量, " &
                                    "入庫税抜金額, " &
                                    "入庫消費税額, " &
                                    "入庫軽減税額, " &
                                    "入庫税込金額, " &
                                    "納入残数, " &
                                    "登録日, " &
                                    "登録時間, " &
                                    "最終更新日, " &
                                    "最終更新時間 " &
                            ") VALUES (" &
                                    "@OrderCode, " &
                                    "@OrderDetailNo, " &
                                    "@ArrivalNo, " &
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
                                    "@TaxPrice, " &
                                    "@ReducedTaxRate, " &
                                    "@Price, " &
                                    "@ArrivalStiffness, " &
                                    "@CreateDate, " &
                                    "@createTime, " &
                                    "@UpdateDate, " &
                                    "@UpdateTime " &
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
            pCommand.Parameters("@OrderCode").Value = parArrivalSubData.sOrderCode
            '発注明細コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderDetailNo", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@OrderDetailNo").Value = parArrivalSubData.sOrderDetailNo
            '入庫番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ArrivalNo", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@ArrivalNo").Value = parArrivalSubData.sArrivalNo
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parArrivalSubData.sJANCode
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parArrivalSubData.sProductCode
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@ProductName").Value = parArrivalSubData.sProductName
            'オプション1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option1", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option1").Value = parArrivalSubData.sOption1
            'オプション2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option2", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option2").Value = parArrivalSubData.sOption2
            'オプション3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option3", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option3").Value = parArrivalSubData.sOption3
            'オプション4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option4", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option4").Value = parArrivalSubData.sOption4
            'オプション5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option5", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option5").Value = parArrivalSubData.sOption5
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@ListPrice").Value = parArrivalSubData.sListPrice
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@CostPrice").Value = parArrivalSubData.sCostPrice
            '入庫商品単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@UnitPrice").Value = parArrivalSubData.sUnitPrice
            '入庫数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@Count").Value = parArrivalSubData.sCount
            '入庫税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@NoTaxPrice").Value = parArrivalSubData.sNoTaxPrice
            '入庫消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@TaxPrice").Value = parArrivalSubData.sTaxPrice

            '2019,11,15 A.Komita 追加 From
            '入庫軽減税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@ReducedTaxRate").Value = parArrivalSubData.sReducedTaxRate
            '2019,11,15 A.Komita 追加 To

            '入庫税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@Price").Value = parArrivalSubData.sPrice
            '納入残数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ArrivalStiffness", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@ArrivalStiffness").Value = parArrivalSubData.sArrivalStiffness
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

            '注文情報明細データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertArrivalSubData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cArrivalDataSubDBIO.insertArrivalSubData)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getArrivalSubProduct(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        Try
            strSelect = ""
            strSelect = "SELECT COUNT(*) AS CNT FROM 入庫情報明細データ WHERE 商品コード = """ & KeyProductCode & """"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()
            getArrivalSubProduct = CLng(pDataReader("CNT"))

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
