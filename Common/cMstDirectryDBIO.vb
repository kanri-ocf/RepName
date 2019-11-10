Public Class cMstDirectryDBIO
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
    '　機能：ディレクトリーIDマスタから該当パスの情報を取得
    '　引数：なし
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function getDirectry(ByRef parDirectry() As cStructureLib.sDirectryMst, _
                                    ByVal KeyPath1 As String, _
                                    ByVal KeyPath2 As String, _
                                    ByVal KeyPath3 As String, _
                                    ByVal KeyPath4 As String, _
                                    ByVal KeyPath5 As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String
        Dim parStr As String
        Dim orderStr As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        getDirectry = ""

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT DISTINCT パス1 "
        parStr = ""
        orderStr = "ORDER BY パス1 "

        'パラメータ数のカウント
        pc = 0
        If KeyPath1 <> "" Then
            pc = pc Or 1
        End If
        If KeyPath2 <> "" Then
            pc = pc Or 2
        End If
        If KeyPath3 <> "" Then
            pc = pc Or 4
        End If
        If KeyPath4 <> "" Then
            pc = pc Or 8
        End If
        If KeyPath5 <> "" Then
            pc = pc Or 16
        End If
        'パラメータ指定がある場合
        If 31 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 16
                Select Case i And pc
                    Case 1
                        strSelect = strSelect & ", パス2 "
                        If scnt > 0 Then
                            parStr = parStr & "AND "
                        Else
                            parStr = parStr & "WHERE "
                        End If
                        parStr = parStr & "パス1 Like ""%" & KeyPath1 & "%"" "
                        orderStr = orderStr & ", パス2 "
                        scnt = scnt + 1
                    Case 2
                        strSelect = strSelect & ", パス3 "
                        If scnt > 0 Then
                            parStr = parStr & "AND "
                        Else
                            parStr = parStr & "WHERE "
                        End If
                        parStr = parStr & "パス2 Like ""%" & KeyPath2 & "%"" "
                        orderStr = orderStr & ", パス3 "
                        scnt = scnt + 1
                    Case 4
                        strSelect = strSelect & ", パス4 "
                        If scnt > 0 Then
                            parStr = parStr & "AND "
                        Else
                            parStr = parStr & "WHERE "
                        End If
                        parStr = parStr & "パス3 Like ""%" & KeyPath3 & "%"" "
                        orderStr = orderStr & ", パス4 "
                        scnt = scnt + 1
                    Case 8
                        strSelect = strSelect & ", パス5 "
                        If scnt > 0 Then
                            parStr = parStr & "AND "
                        Else
                            parStr = parStr & "WHERE "
                        End If
                        parStr = parStr & "パス4 Like ""%" & KeyPath4 & "%"" "
                        orderStr = orderStr & ", パス5 "
                        scnt = scnt + 1
                    Case 16
                        strSelect = strSelect & ", ディレクトリID "
                        If scnt > 0 Then
                            parStr = parStr & "AND "
                        Else
                            parStr = parStr & "WHERE "
                        End If
                        parStr = parStr & "パス5 Like ""%" & KeyPath5 & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If
        strSelect = strSelect & "FROM ディレクトリーIDマスタ " & parStr & orderStr
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parDirectry(i)

                'パス1
                parDirectry(i).sPath1 = pDataReader("パス1").ToString
                If pc >= 1 Then
                    'パス2
                    parDirectry(i).sPath2 = pDataReader("パス2").ToString
                End If
                If pc >= 3 Then
                    'パス3
                    parDirectry(i).sPath3 = pDataReader("パス3").ToString
                End If
                If pc >= 7 Then
                    'パス4
                    parDirectry(i).sPath4 = pDataReader("パス4").ToString
                End If
                If pc >= 15 Then
                    'パス5
                    parDirectry(i).sPath5 = pDataReader("パス5").ToString
                End If
                If pc >= 31 Then
                    'ディレクトリーID
                    parDirectry(i).sDirectryID = pDataReader("ディレクトリID").ToString
                End If
                'レコードが取得できた時の処理
                i = i + 1
            End While
            If i = 1 Then
                strSelect = "SELECT ディレクトリID FROM ディレクトリーIDマスタ " & parStr

                'SQL文の設定
                pCommand = Nothing
                pDataReader = Nothing
                pCommand = pConn.CreateCommand()
                pCommand.CommandText = strSelect
                pDataReader = pCommand.ExecuteReader()

                pDataReader.Read()

                getDirectry = pDataReader("ディレクトリID").ToString

            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDirectryDBIO.getDirectry)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ディレクトリーIDマスタに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertDirectryMst(ByVal parDirectryMst() As cStructureLib.sDirectryMst, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Try

            'SQL文の設定
            Const strInsert As String = "INSERT INTO ディレクトリーIDマスタ " & _
            "( ディレクトリID, パス1, パス2, パス3, パス4, パス5 ) " & _
            "VALUES (@DirectryID, @Path1, @Path2, @Path3, @Path4, @Path5)"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            'ディレクトリID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DirectryID", OleDb.OleDbType.Char, 6))
            pCommand.Parameters("@DirectryID").Value = parDirectryMst(0).sDirectryID
            'パス1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path1", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Path1").Value = parDirectryMst(0).sPath1
            'パス2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path2", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Path2").Value = parDirectryMst(0).sPath2
            'パス3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path3", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Path3").Value = parDirectryMst(0).sPath3
            'パス4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path4", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Path4").Value = parDirectryMst(0).sPath4
            'パス5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path5", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Path5").Value = parDirectryMst(0).sPath5

            'ディレクトリーIDマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertDirectryMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDirectryDBIO.insertDirectryMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ディレクトリーIDマスタの全レコードを削除
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteDirectryMst(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE FROM ディレクトリーIDマスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            'ディレクトリーIDマスタ挿入処理実行
            deleteDirectryMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDirectryDBIO.insertDirectryMst)", Nothing, Nothing, oExcept.ToString)
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
