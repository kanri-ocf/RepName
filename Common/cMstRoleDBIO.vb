Public Class cMstRoleDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    '----------------------------------------------------------------------
    '　機能：日次部門マスタから１レコードを取得する関名称
    '　引名称：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getRole(ByRef parRole() As cStructureLib.sRole, ByVal keyRoleCode As String, ByVal keyRoleName As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

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

            strSelect = "SELECT * FROM 役割マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyRoleCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyRoleName <> Nothing Then
                maxpc = 2
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
                            strSelect = strSelect & "役割コード Like ""%" & keyRoleCode & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "役割名称 Like ""%" & keyRoleName & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getRole = 0

            While pDataReader.Read()
                ReDim Preserve parRole(i)

                '役割コード
                If IsDBNull(pDataReader("役割コード")) = True Then
                    parRole(i).sRoleCode = 0
                Else
                    parRole(i).sRoleCode = CInt(pDataReader("役割コード"))
                End If
                '役割名称
                parRole(i).sRoleName = pDataReader("役割名称").ToString
                '登録日
                parRole(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parRole(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRole(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parRole(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getRole = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoleDBIO.getRole)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ネット掲載マスタに１レコードを登録するメソッド
    '　引名称：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertRole(ByRef parRole As cStructureLib.sRole, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        'SQL文の設定
        Const strInsert As String = "INSERT INTO 役割マスタ " & _
                                            "( 役割コード, 役割名称, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                                            "VALUES ( @RoleCode, @RoleName, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            '役割コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoleCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@RoleCode").Value = parRole.sRoleCode

            '役割名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoleName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@RoleName").Value = parRole.sRoleName

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parRole.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parRole.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parRole.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parRole.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '役割マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertRole = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoleDBIO.insertRole)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：役割マスタの１レコードを更新するメソッド
    '　引名称：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateRole(ByVal parRole() As cStructureLib.sRole, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordName As Integer
        Dim strRole As String

        strRole = "UPDATE 役割マスタ " & _
                            "SET 役割名称=""" & parRole(0).sRoleName & """, " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 役割コード=" & parRole(0).sRoleCode

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strRole

            '役割マスタ更新SQL文実行
            RecordName = pCommand.ExecuteNonQuery()
            If RecordName > 0 Then
                '更新成功
                updateRole = True
            Else
                '更新するレコードがなかった時の処理
                updateRole = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoleDBIO.updateRole)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：役割マスタの１レコードを削除するメソッド
    '　引名称：役割コード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteRole(ByVal KeyRoleCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 役割マスタ WHERE 役割コード=" & KeyRoleCode & " "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '役割マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteRole = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoleDBIO.deleteRole)", Nothing, Nothing, oExcept.ToString)
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
