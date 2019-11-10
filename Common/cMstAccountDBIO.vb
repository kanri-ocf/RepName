Public Class cMstAccountDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    ''----------------------------------------------------------------------
    ''　機能：仕入先マスタから１レコードを取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getAccount(ByRef parAccount() As cStructureLib.sAccount, _
                               ByVal KeyAccountCode As Integer, _
                               ByVal KeyAccountName As String, _
                               ByVal KeyLinkMasterName As String, _
                               ByVal KeyTaxClass As String, _
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

        strSelect = "SELECT * FROM 勘定科目マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyAccountCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyAccountName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyLinkMasterName <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyTaxClass <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If 127 And pc > 0 Then
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
                        strSelect = strSelect & "勘定科目コード = " & KeyAccountCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "勘定科目名称 Like ""%" & KeyAccountName & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "連携マスタ名称 Like ""%" & KeyLinkMasterName & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "税区分名称 Like ""%" & KeyTaxClass & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 勘定科目名称 "

        Try

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                parAccount(i).sAccountName = pDataReader("勘定科目名称").ToString
                '連携マスタ名称
                parAccount(i).sLinkMasterName = pDataReader("連携マスタ名称").ToString
                '税区分コード
                If IsDBNull(pDataReader("税区分コード")) = True Then
                    parAccount(i).sTaxClassCode = 0
                Else
                    parAccount(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                End If
                '登録日
                parAccount(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parAccount(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parAccount(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parAccount(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getAccount = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.getAccount)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getSubAccount(ByRef parSubAccount() As cStructureLib.sSubAccount, _
                               ByVal KeyAccountCode As Integer, _
                               ByVal KeySubAccountCode As Integer, _
                               ByVal KeySubAccountName As String, _
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

        strSelect = "SELECT * FROM 勘定科目補助マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyAccountCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubAccountCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeySubAccountName <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If 127 And pc > 0 Then
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
                        strSelect = strSelect & "勘定科目コード = " & KeyAccountCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "補助勘定科目コード = " & KeySubAccountCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "補助勘定科目名称 Like ""%" & KeySubAccountName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 補助勘定科目名称 "

        Try

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parSubAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parSubAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '補助勘定科目コード
                parSubAccount(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                parSubAccount(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                '登録日
                parSubAccount(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parSubAccount(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSubAccount(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parSubAccount(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getSubAccount = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.getSubAccount)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getAccountFull(ByRef parAccount() As cStructureLib.sViewAccountFull, _
                               ByVal KeyAccountCode As Integer, _
                               ByVal KeyAccountName As String, _
                               ByVal KeyLinkMasterName As String, _
                               ByVal KeyTaxClassCode As Integer, _
                               ByVal KeyTaxClassName As String, _
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

        strSelect = "SELECT " & _
                        "勘定科目マスタ.勘定科目コード AS 勘定科目コード, " & _
                        "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
                        "勘定科目マスタ.連携マスタ名称 AS 連携マスタ名称, " & _
                        "税区分マスタ.税区分コード AS 税区分コード, " & _
                        "税区分マスタ.税区分名称 AS 税区分名称 " & _
                    "FROM 勘定科目マスタ LEFT JOIN 税区分マスタ ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード "

        'パラメータ数のカウント
        pc = 0
        If KeyAccountCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyAccountName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyLinkMasterName <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyTaxClassCode <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyTaxClassName <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If 127 And pc > 0 Then
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
                        strSelect = strSelect & "勘定科目コード = " & KeyAccountCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "勘定科目名称 Like ""%" & KeyAccountName & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "連携マスタ名称 Like ""%" & KeyLinkMasterName & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "税区分コード = " & KeyTaxClassCode & " "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "税区分名称 Like ""%" & KeyTaxClassName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 勘定科目名称 "

        Try

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                parAccount(i).sAccountName = pDataReader("勘定科目名称").ToString
                '連携マスタ名称
                parAccount(i).sLinkMasterName = pDataReader("連携マスタ名称").ToString
                '税区分コード
                If IsDBNull(pDataReader("税区分コード")) = True Then
                    parAccount(i).sTaxClassCode = 0
                Else
                    parAccount(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                End If
                '税区分名称
                parAccount(i).sTaxClassName = pDataReader("税区分名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getAccountFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.getAccountFull)", Nothing, Nothing, oExcept.ToString)
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

    ''----------------------------------------------------------------------
    ''　機能：仕入先名称から取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getAccountCode(ByRef parAccount() As cStructureLib.sAccount, ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim StrSelect As String

        If KeyString = "" Then
            StrSelect = "SELECT * FROM 勘定科目マスタ"
        Else
            StrSelect = "SELECT * FROM 勘定科目マスタ WHERE 勘定科目名称= @AccountName"
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '商品コード
            If KeyString <> "" Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@AccountName", OleDb.OleDbType.Char, 50))
                pCommand.Parameters("@AccountName").Value = KeyString
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                parAccount(i).sAccountName = pDataReader("勘定科目名称").ToString
                '連携マスタ名称()
                parAccount(i).sLinkMasterName = pDataReader("連携マスタ名称").ToString
                '登録日
                parAccount(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parAccount(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parAccount(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parAccount(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getAccountCode = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.getAccountCode)", Nothing, Nothing, oExcept.ToString)
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


    Public Function getNewAccountCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String

        getNewAccountCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT 勘定科目コード FROM 勘定科目マスタ WHERE Len([勘定科目コード]) < 3 ORDER BY 勘定科目コード DESC"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            '最大勘定科目コード
            getNewAccountCode = CInt(pDataReader("勘定科目コード").ToString) + 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.getNewAccountCode)", Nothing, Nothing, oExcept.ToString)
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

    Public Function insertAccount(ByVal parAccount As cStructureLib.sAccount, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 勘定科目マスタ " & _
        "( 勘定科目コード, 勘定科目名称, 連携マスタ名称, 税区分コード, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
        "VALUES (@AccountCode, @AccountName, @LinkMasterName, @TaxClassCode, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '勘定科目コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AccountCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@AccountCode").Value = CInt(parAccount.sAccountCode)

            '勘定科目名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AccountName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@AccountName").Value = parAccount.sAccountName.ToString

            '連携マスタ名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@LinkMasterName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@LinkMasterName").Value = parAccount.sLinkMasterName.ToString

            '税区分コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxClassCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@TaxClassCode").Value = parAccount.sTaxClassCode

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parAccount.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parAccount.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parAccount.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parAccount.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.insertAccount)", Nothing, Nothing, oExcept.ToString)
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

    Public Function insertSubAccount(ByVal parSubAccount As cStructureLib.sSubAccount, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 勘定科目補助マスタ " & _
        "( 勘定科目コード, 補助勘定科目コード, 補助勘定科目名称, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
        "VALUES (@AccountCode, @SubAccountCode, @SubAccountName, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '勘定科目コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AccountCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@AccountCode").Value = CInt(parSubAccount.sAccountCode)

            '補助勘定科目コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubAccountCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@SubAccountCode").Value = CInt(parSubAccount.sSubAccountCode)

            '補助勘定科目名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubAccountName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@SubAccountName").Value = parSubAccount.sSubAccountName.ToString

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parSubAccount.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parSubAccount.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parSubAccount.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parSubAccount.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '価格マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertSubAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSubAccountDBIO.insertSubAccount)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：勘定科目マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteAccount(ByVal keyAccountCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 勘定科目マスタ WHERE 勘定科目コード=" & keyAccountCode & " "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '商品マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteSubAccount(keyAccountCode, Nothing, Tran)

            deleteAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.deleteAccount)", Nothing, Nothing, oExcept.ToString)
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

    Public Function deleteSubAccount( _
                                ByVal keyAccountCode As Integer, _
                                ByVal keySubAccountCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDelete As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strDelete = ""

        strDelete = "DELETE * FROM 勘定科目補助マスタ "

        'パラメータ数のカウント
        pc = 0
        If keyAccountCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keySubAccountCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If 127 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strDelete = strDelete & "AND "
                        Else
                            strDelete = strDelete & "WHERE "
                        End If
                        strDelete = strDelete & "勘定科目コード = " & keyAccountCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strDelete = strDelete & "AND "
                        Else
                            strDelete = strDelete & "WHERE "
                        End If
                        strDelete = strDelete & "補助勘定科目コード = " & keySubAccountCode & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            pCommand.CommandText = strDelete

            '勘定科目マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteSubAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSubAccountDBIO.deleteSubAccount)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：勘定科目マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateAccount(ByRef parAccount As cStructureLib.sAccount, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 勘定科目マスタ SET " & _
                            "勘定科目名称=""" & parAccount.sAccountName & """, " & _
                            "連携マスタ名称=""" & parAccount.sLinkMasterName & """, " & _
                            "税区分コード=" & parAccount.sTaxClassCode & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 勘定科目コード=" & parAccount.sAccountCode & " "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountDBIO.updateAccount)", Nothing, Nothing, oExcept.ToString)
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

    Public Function updateSubAccount(ByRef parSubAccount As cStructureLib.sSubAccount, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 勘定科目補助マスタ SET " & _
                            "補助勘定科目名称=""" & parSubAccount.sSubAccountName & """, " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 補助勘定科目コード=" & parSubAccount.sAccountCode & " " & _
                            "AND 補助勘定科目コード=" & parSubAccount.sSubAccountCode & " "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateSubAccount = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSubAccountDBIO.updateSubAccount)", Nothing, Nothing, oExcept.ToString)
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
