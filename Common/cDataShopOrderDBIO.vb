    '----------------------------------------------------------------------
    '　クラス名：店頭注文情報データのDB処理クラス
    '　
    '
    '----------------------------------------------------------------------
Public Class cDataShopOrderDBIO
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
    '　機能：店頭注文情報データから該当発注番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getShopOrderData(ByRef parShopOrderData() As cStructureLib.sShopOrderData, _
                                 ByVal KeyRequestCode As String, _
                                 ByVal KeyProductCode As String, _
                                 ByVal KeyFromDate As String, _
                                 ByVal KeyToDate As String, _
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
        strSelect = "Select " & _
                        "店頭注文データ.受注コード, " & _
                        "店頭注文データ.会員コード, " & _
                        "店頭注文データ.状態, " & _
                        "店頭注文データ.納品予定日, " & _
                        "店頭注文データ.注文形態, " & _
                        "店頭注文データ.受渡方法, " & _
                        "店頭注文データ.前受金, " & _
                        "店頭注文データ.客先FAX番号, " & _
                        "店頭注文データ.登録日, " & _
                        "店頭注文データ.登録時間, " & _
                        "店頭注文データ.最終更新日, " & _
                        "店頭注文データ.最終更新時間 " & _
                    "FROM 店頭注文データ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing Then
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
                        strSelect = strSelect & "受注コード Like ""%" & KeyRequestCode & "%"" "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード  Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyToDate & """ "
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

                ReDim Preserve parShopOrderData(i)

                '発注コード
                parShopOrderData(i).sRequestCode = pDataReader("受注コード").ToString
                '会員コード
                parShopOrderData(i).sMemberCode = pDataReader("会員コード").ToString
                '状態
                parShopOrderData(i).sOrderStatus = pDataReader("状態").ToString
                '納品予定日
                If IsDBNull(pDataReader("納品予定日")) = True Then
                    parShopOrderData(i).sScheSippingDate = ""
                Else
                    parShopOrderData(i).sScheSippingDate = pDataReader("納品予定日")
                End If

                If IsDBNull(pDataReader("注文形態")) = True Then
                    parShopOrderData(i).sOrderMode = 0
                Else
                    parShopOrderData(i).sOrderMode = CInt(pDataReader("注文形態"))
                End If
                '
                If IsDBNull(pDataReader("受渡方法")) = True Then
                    parShopOrderData(i).sShippingType = 0
                Else
                    parShopOrderData(i).sShippingType = CInt(pDataReader("受渡方法"))
                End If
                '
                If IsDBNull(pDataReader("前受金")) = True Then
                    parShopOrderData(i).sTemporaryDeposit = 0
                Else
                    parShopOrderData(i).sTemporaryDeposit = CLng(pDataReader("前受金"))
                End If
                '
                If IsDBNull(pDataReader("客先FAX番号")) = True Then
                    parShopOrderData(i).sShipFaxNo = ""
                Else
                    parShopOrderData(i).sShipFaxNo = pDataReader("客先FAX番号")
                End If
                '登録日
                parShopOrderData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parShopOrderData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parShopOrderData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parShopOrderData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getShopOrderData = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShopOrderDBIO.getShopOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文情報データテーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertShopOrderData(ByVal parShopOrderData As cStructureLib.sShopOrderData, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsertOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try


            'SQL文の設定
            strInsertOrder = "INSERT INTO 店頭注文データ ( " & _
                                "受注コード, " & _
                                "会員コード, " & _
                                "状態, " & _
                                "納品予定日, " & _
                                "注文形態, " & _
                                "受渡方法, " & _
                                "前受金, " & _
                                "客先FAX番号, " & _
                                "税込送料, " & _
                                "税込手数料, " & _
                                "登録日, " & _
                                "登録時間, " & _
                                "最終更新日, " & _
                                "最終更新時間 " & _
                            ") VALUES (" & _
                                "@RequestCode, " & _
                                "@MemberCode, " & _
                                "@OrderStatus, " & _
                                "@ScheSippingDate, " & _
                                "@OrderMode, " & _
                                "@ShippingType, " & _
                                "@TemporaryDeposit, " & _
                                "@ShipFaxNo, " & _
                                "TaxShippingCharge, " & _
                                "TaxPaymentCharge, " & _
                                "@CreateDate, " & _
                                "@CreateTime, " & _
                                "@UpdateDate, " & _
                                "@UpdateTime " & _
                            ")"


            pCommand.CommandText = strInsertOrder

            '***********************
            '   パラメータの設定
            '***********************
            '注文コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = parShopOrderData.sRequestCode
            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@MemberCode").Value = parShopOrderData.sMemberCode
            '注文状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderStatus", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@OrderStatus").Value = parShopOrderData.sOrderStatus
            '納品予定日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ScheSippingDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ScheSippingDate").Value = parShopOrderData.sScheSippingDate
            '注文形態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderMode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@OrderMode").Value = parShopOrderData.sOrderMode
            '受渡方法
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingType", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ShippingType").Value = parShopOrderData.sShippingType
            '前受金
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TemporaryDeposit", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TemporaryDeposit").Value = parShopOrderData.sTemporaryDeposit
            '客先FAX番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipFaxNo", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ShipFaxNo").Value = parShopOrderData.sShipFaxNo
            '税込送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxShippingCharge").Value = parShopOrderData.sTaxShippingCharge
            '税込手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxPaymentCharge").Value = parShopOrderData.sTaxPaymentCharge
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

            '店頭注文情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertShopOrderData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShopOrderDBIO.insertOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文情報データテーブルの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function UpdateShopOrderData(ByVal parShopOrderData As cStructureLib.sShopOrderData, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strUpdateShopOrder As String = ""
        Dim sb As New System.Text.StringBuilder

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            '2014/04/23 Soeda Modify
            sb.Append("UPDATE 店頭注文データ SET ")
            sb.Append("会員コード = @MemberCode, ")
            sb.Append("状態 = @OrderStatus, ")
            sb.Append("納品予定日 = @ScheSippingDate, ")
            sb.Append("注文形態 = @OrderMode, ")
            sb.Append("受渡方法 = @ShippingType, ")
            sb.Append("前受金 = @TemporaryDeposit, ")
            sb.Append("客先FAX番号 = @ShipFaxNo, ")
            sb.Append("税込送料 = @TaxShippingCharge, ")
            sb.Append("税込手数料 = @TaxPaymentCharge, ")
            sb.Append("最終更新日 = @UpdateDate, ")
            sb.Append("最終更新時間 = @UpdateTime ")
            sb.Append("WHERE 受注コード = @RequestCode ")

            strUpdateShopOrder = sb.ToString
            pCommand.CommandText = strUpdateShopOrder

            '***********************
            '   パラメータの設定
            '***********************
            '注文コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = parShopOrderData.sRequestCode
            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@MemberCode").Value = parShopOrderData.sMemberCode
            '注文状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderStatus", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@OrderStatus").Value = parShopOrderData.sOrderStatus
            '納品予定日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ScheSippingDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ScheSippingDate").Value = parShopOrderData.sScheSippingDate
            '注文形態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderMode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@OrderMode").Value = parShopOrderData.sOrderMode
            '受渡方法
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingType", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ShippingType").Value = parShopOrderData.sShippingType
            '前受金
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TemporaryDeposit", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TemporaryDeposit").Value = parShopOrderData.sTemporaryDeposit
            '客先FAX番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipFaxNo", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@ShipFaxNo").Value = parShopOrderData.sShipFaxNo
            '税込送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxShippingCharge").Value = parShopOrderData.sTaxShippingCharge
            '税込手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxPaymentCharge").Value = parShopOrderData.sTaxPaymentCharge
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '店頭注文情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            UpdateShopOrderData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShopOrderDBIO.UpdateShopOrderData)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：店頭注文情報明細テーブルに１レコードを削除するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteShopOrderData(ByVal OrderNumber As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDeleteOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            '*********************************
            '店頭注文情報データ削除SQL文の設定
            '*********************************
            strDeleteOrder = "DELETE 店頭注文情報データ.発注コード FROM 店頭注文情報データ " & _
                "WHERE 店頭注文情報データ.発注コード=@OrderNumber"

            pCommand.CommandText = strDeleteOrder

            '***********************
            '   パラメータの設定
            '***********************

            '注文番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = OrderNumber

            '店頭注文情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteShopOrderData = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShopOrderDBIO.deleteShopOrderData)", Nothing, Nothing, oExcept.ToString)
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
