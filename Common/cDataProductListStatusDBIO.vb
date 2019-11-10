Public Class cDataProductListStatusDBIO
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
    '　機能：プロパティの取引コードのレコードが発注情報データに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ProductListStatusExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 商品リスト状態データ WHERE 商品コード = @ProductCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyString

            '発注譲歩マスタから該当取引コードのレコード数読込 
            Dim recCount As Integer

            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                ProductListStatusExist = True
            Else
                'レコードが存在しない時の処理
                ProductListStatusExist = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataProductListStatusDBIO.ProductListStatusExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getProductStatus(ByRef parProductListStatus() As cStructureLib.sProductListStatus, _
                                   ByVal keyString As String, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            strSelect = ""

            If keyString = Nothing Then
                strSelect = "SELECT * FROM 商品リスト状態データ"
            Else
                strSelect = "SELECT * FROM 商品リスト状態データ WHERE 商品コード = @ProductCode"
            End If

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            If keyString <> "" Then

                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
                pCommand.Parameters("@ProductCode").Value = keyString
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parProductListStatus(i)

                'レコードが取得できた時の処理
                '商品コード
                parProductListStatus(i).sProductCode = pDataReader("商品コード").ToString
                '選択状態
                parProductListStatus(i).sCheck = pDataReader("選択状態")

                getProductStatus = i
                i = i + 1
            End While

            getProductStatus = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataProductListStatusDBIO.getProductStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertProductListStatus(ByVal parProductListStatus As cStructureLib.sProductListStatus, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        Try

            'SQL文の設定
            strInsert = "INSERT INTO 商品リスト状態データ( 商品コード, 選択状態, 数量 ) VALUES ( " & _
                """" & parProductListStatus.sProductCode & """, " & _
                parProductListStatus.sCheck & ") "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsert

            '商品リスト状態データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertProductListStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataProductListStatusDBIO.insertProductListStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateProductListStatus(ByVal parProductListStatus As cStructureLib.sProductListStatus, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        strUpdate = "UPDATE 商品リスト状態データ " & _
                        "SET 選択状態 = " & parProductListStatus.sCheck & ", " & _
                        "数量 = " & parProductListStatus.sCount & " " & _
                    "WHERE 商品コード = """ & parProductListStatus.sProductCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'SQL文パラメータの設定
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parProductListStatus.sProductCode
            '選択状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductListStatus", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ProductListStatus").Value = parProductListStatus.sCheck
            '数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 4))
            pCommand.Parameters("@Count").Value = parProductListStatus.sCount

            '発注情報データ更新SQL文実行
            Dim count As Integer

            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                '更新成功
                updateProductListStatus = True
            Else
                '更新するレコードがなかった時の処理
                updateProductListStatus = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataProductListStatusDBIO.updateProductListStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データに１レコードを登録するメソッド
    '　引数：in sProductListStatusオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteProductListStatus(ByVal KeyProductCode As String, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim StrDelete As String

        Try
            If KeyProductCode = Nothing Then
                'SQL文の設定
                StrDelete = "DELETE * FROM 商品リスト状態データ"
            Else
                'SQL文の設定
                StrDelete = "DELETE * FROM 商品リスト状態データ WHERE 商品コード = @ProductCode"
            End If

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = StrDelete

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyProductCode

            '発注情報データ削除SQL文実行
            Dim count As Integer

            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                '更新成功
                deleteProductListStatus = True
            Else
                '更新するレコードがなかった時の処理
                deleteProductListStatus = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataProductListStatusDBIO.deleteProductListStatus)", Nothing, Nothing, oExcept.ToString)
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
