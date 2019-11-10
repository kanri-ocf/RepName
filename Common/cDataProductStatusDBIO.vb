
Public Class cDataProductStatusDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    '-------------------------------------------------------------------------------
    '　機能：商品マスタおよび価格マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProductStatus(ByRef parProductStatus() As cStructureLib.sProductStatus, _
                               ByVal KeyProductCode As String, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

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

            strSelect = "SELECT 商品コード AS 商品コード, " & _
                                "販売停止フラグ AS 販売停止フラグ, " & _
                                "仕入停止フラグ AS 仕入停止フラグ, " & _
                                "Yahoo掲載フラグ AS Yahoo掲載フラグ, " & _
                                "楽天掲載フラグ AS 楽天掲載フラグ, " & _
                                "Amazon掲載フラグ AS Amazon掲載フラグ, " & _
                                "自社サイト掲載フラグ AS 自社サイト掲載フラグ " & _
                        "FROM 商品ステータス状態データ "
 
            'パラメータ数のカウント
            pc = 0
            If KeyProductCode <> Nothing Then
                maxpc = 1
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
                            strSelect = strSelect & "商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()


                ReDim Preserve parProductStatus(i)

                '商品コード
                parProductStatus(i).sProductCode = pDataReader("商品コード").ToString
                '販売停止フラグ
                parProductStatus(i).sStopSaleFlg = pDataReader("販売停止フラグ")
                '仕入停止フラグ
                parProductStatus(i).sStopSupplieFlg = pDataReader("仕入停止フラグ")
                'Yahoo掲載フラグ
                parProductStatus(i).sYahooFlg = pDataReader("Yahoo掲載フラグ")
                '楽天掲載フラグ
                parProductStatus(i).sRakutenFlg = pDataReader("楽天掲載フラグ")
                'Amazon掲載フラグ
                parProductStatus(i).sAmazonFlg = pDataReader("Amazon掲載フラグ")
                '自社サイト掲載フラグ
                parProductStatus(i).seShopFlg = pDataReader("自社サイト掲載フラグ")

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProductStatus = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProductStatus)", Nothing, Nothing, oExcept.ToString)
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


    Public Function insertProductStatus(ByRef parProductStatus() As cStructureLib.sProductStatus, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 商品ステータス状態データ ( " & _
                        "商品コード, " & _
                        "販売停止フラグ, " & _
                        "仕入停止フラグ, " & _
                        "Yahoo掲載フラグ, " & _
                        "楽天掲載フラグ, " & _
                        "Amazon掲載フラグ, " & _
                        "自社サイト掲載フラグ " & _
                    ") VALUES (" & _
                        "@ProductCode, " & _
                        "@StopSaleFlg, " & _
                        "@StopSupplieFlg, " & _
                        "@YahooFlg, " & _
                        "@RakutenFlg, " & _
                        "@AmazonFlg, " & _
                        "@eShopFlg " & _
                     ")"

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
            pCommand.Parameters("@ProductCode").Value = parProductStatus(0).sProductCode
            '販売停止フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StopSaleFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@StopSaleFlg").Value = parProductStatus(0).sStopSaleFlg
            '仕入停止フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StopSupplieFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@StopSupplieFlg").Value = parProductStatus(0).sStopSupplieFlg
            'Yahoo掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@YahooFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@YahooFlg").Value = parProductStatus(0).sYahooFlg
            '楽天掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RakutenFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@RakutenFlg").Value = parProductStatus(0).sRakutenFlg
            'Amazon掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AmazonFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@AmazonFlg").Value = parProductStatus(0).sAmazonFlg
            '自社サイト掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OriginalFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@OriginalFlg").Value = parProductStatus(0).seShopFlg

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertProductStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.insertProductStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateProductStatus(ByRef parProductStatus() As cStructureLib.sProductStatus, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 商品ステータス状態データ SET " & _
                            "販売停止フラグ=" & parProductStatus(0).sStopSaleFlg & ", " & _
                            "仕入停止フラグ=" & parProductStatus(0).sStopSupplieFlg & ", " & _
                            "Yahoo掲載フラグ=" & parProductStatus(0).sYahooFlg & ", " & _
                            "楽天掲載フラグ=" & parProductStatus(0).sRakutenFlg & ", " & _
                            "Amazon掲載フラグ=" & parProductStatus(0).sAmazonFlg & ", " & _
                            "自社サイト掲載フラグ=" & parProductStatus(0).seShopFlg & " " & _
                            "WHERE 商品コード=""" & parProductStatus(0).sProductCode.ToString & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateProductStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.updateProductStatus)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteProductStatus(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 商品ステータス状態データ WHERE 商品コード=""" & KeyProductCode & """"

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '商品マスタ削除処理実行()
            deleteProductStatus = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.deleteProductStatus)", Nothing, Nothing, oExcept.ToString)
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



