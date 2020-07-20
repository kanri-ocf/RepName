Public Class cDataTagPrintStatusDBIO
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
    Public Function TagPrintStatusExist(ByVal KeyString As String) As Long

        Dim strSelect As String

        strSelect = "SELECT COUNT(*) FROM タグ印刷状態データ "

        If KeyString <> Nothing Then
            strSelect = strSelect & "WHERE 商品コード = @ProductCode"
        End If

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyString

            TagPrintStatusExist = CInt(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cTagPrintStatusDBIO.TagPrintStatusExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getTagPrintStatus(ByRef parTagPrintStatus() As cStructureLib.sTagPrintStatus, ByVal keyProductCode As String, ByVal KeyStatus As Boolean) As Long

        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer

        strSelect = ""

        strSelect = "SELECT * FROM タグ印刷状態データ "

        'パラメータ数のカウント
        pc = 0
        If keyProductCode <> Nothing Then
            pc = pc Or 1
        End If
        If KeyStatus <> Nothing Then
            pc = pc Or 2
        End If

        'パラメータ指定がある場合
        If (3 And pc) > 0 Then
            i = 1
            scnt = 0
            While i <= 2
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード Like ""%" & keyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "タグ印刷状態 = " & KeyStatus & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parTagPrintStatus(i)

                'レコードが取得できた時の処理
                '商品コード
                parTagPrintStatus(i).sProductCode = pDataReader("商品コード").ToString
                'タグ印刷状態
                If IsDBNull(pDataReader("タグ印刷状態")) = True Then
                    parTagPrintStatus(i).sTagPrintCheck = False
                Else
                    parTagPrintStatus(i).sTagPrintCheck = CBool(pDataReader("タグ印刷状態"))
                End If
                '枚数
                parTagPrintStatus(i).sCount = CLng(pDataReader("枚数"))

                getTagPrintStatus = i
                i = i + 1
            End While

            getTagPrintStatus = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cTagPrintStatusDBIO.getTagPrintStatus)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertTagPrintStatus(ByVal parTagPrintStatus As cStructureLib.sTagPrintStatus) As Boolean ', ByRef Tran As System.Data.OleDb.OleDbTransaction
        Dim strInsert As String

        Try

            'SQL文の設定
            strInsert = "INSERT INTO タグ印刷状態データ" &
                            "( 商品コード, タグ印刷状態, 枚数 ) VALUES (" &
                            """" & parTagPrintStatus.sProductCode & """, " &
                            parTagPrintStatus.sTagPrintCheck & ", " &
                            parTagPrintStatus.sCount & ")"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()

            pCommand.CommandText = strInsert

            '発注状態データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertTagPrintStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cTagPrintStatusDBIO.insertTagPrintStatus)", Nothing, Nothing, oExcept.ToString)
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
    Public Function updateTagPrintStatus(ByVal parTagPrintStatus As cStructureLib.sTagPrintStatus) As Boolean
        Dim strUpdate As String
        Dim count As Integer

        strUpdate = "UPDATE タグ印刷状態データ " & _
                            "SET タグ印刷状態=" & parTagPrintStatus.sTagPrintCheck & ", " & _
                            "枚数=" & parTagPrintStatus.sCount & " " & _
                            "WHERE 商品コード=""" & parTagPrintStatus.sProductCode & """"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()

            'SQL文の設定
            pCommand.CommandText = strUpdate

            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                '更新成功
                updateTagPrintStatus = True
            Else
                '更新するレコードがなかった時の処理
                updateTagPrintStatus = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cTagPrintStatusDBIO.updateTagPrintStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in sTagPrintStatusオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteTagPrintStatus(ByVal KeyString As String) As Boolean
        Dim StrDelete As String

        Try

            deleteTagPrintStatus = False

            If KeyString = Nothing Then
                'SQL文の設定
                StrDelete = "DELETE * FROM タグ印刷状態データ"
            Else
                'SQL文の設定
                StrDelete = "DELETE * FROM タグ印刷状態データ WHERE 商品コード = @ProductCode"
            End If

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()

            pCommand.CommandText = StrDelete

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyString

            pCommand.ExecuteNonQuery()

            deleteTagPrintStatus = True
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cTagPrintStatusDBIO.deleteTagPrintStatus)", Nothing, Nothing, oExcept.ToString)
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
