Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cMstDeliveryClassDBIO

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
    '　機能：配送種別マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getDeliveryClassMst(ByRef parDeliveryClass() As cStructureLib.sDeliveryClass, _
                                  ByVal KeyDeliveryClassCode As Integer, _
                                  ByVal KeyItemName As String, _
                                  ByVal KeyClassCode As String, _
                                  ByVal KeyClassName As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 配送種別マスタ "

        pc = 0

        'パラメータ数のカウント
        pc = 0
        If KeyDeliveryClassCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyItemName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyClassCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyClassName <> Nothing Then
            maxpc = 8
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
                        strSelect = strSelect & "配送種別コード = " & KeyDeliveryClassCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "項目名称 like ""%" & KeyItemName & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "種別コード like ""%" & KeyClassCode & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "種別名称 like ""%" & KeyClassName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 配送種別コード "
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()
            i = 0
            While pDataReader.Read()

                ReDim Preserve parDeliveryClass(CInt(i))

                '配送種別コード
                If IsDBNull(pDataReader("配送種別コード")) = True Then
                    parDeliveryClass(i).sDeliveryClassCode = 0
                Else
                    parDeliveryClass(i).sDeliveryClassCode = CInt(pDataReader("配送種別コード"))
                End If
                '項目名称
                parDeliveryClass(i).sItemName = pDataReader("項目名称").ToString
                '種別コード
                parDeliveryClass(i).sClassCode = pDataReader("種別コード").ToString
                '種別名称
                parDeliveryClass(i).sClassName = pDataReader("種別名称").ToString
                '登録日
                parDeliveryClass(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parDeliveryClass(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parDeliveryClass(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parDeliveryClass(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getDeliveryClassMst = i
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.getDeliveryClassMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：配送種別マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getItemName(ByRef parData() As String, _
                                  ByVal KeyDeliveryClassCode As Integer, _
                                  ByVal KeyItemName As String, _
                                  ByVal KeyClassCode As String, _
                                  ByVal KeyClassName As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT DISTINCT 項目名称 FROM 配送種別マスタ "

        pc = 0

        'パラメータ数のカウント
        pc = 0
        If KeyDeliveryClassCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyItemName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyClassCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyClassName <> Nothing Then
            maxpc = 8
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
                        strSelect = strSelect & "配送種別コード = " & KeyDeliveryClassCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "項目名称 = """ & KeyItemName & """ "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "種別コード = """ & KeyClassCode & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "種別名称 = """ & KeyClassName & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()
            i = 0
            While pDataReader.Read()

                ReDim Preserve parData(CInt(i))

                '項目名称
                parData(i) = pDataReader("項目名称").ToString

                i = i + 1
            End While

            getItemName = i
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.getItemName)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getNewDeliveryClassCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Long

        strSelect = ""
        strSelect = "SELECT Max([配送種別コード]) AS 最大配送種別コード FROM 配送種別マスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getNewDeliveryClassCode = -1

            pDataReader.Read()

            '最大チャネル支払コード
            If IsDBNull(pDataReader("最大配送種別コード")) Then
                getNewDeliveryClassCode = 1
            Else
                getNewDeliveryClassCode = CInt(pDataReader("最大配送種別コード").ToString) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.getNewDeliveryClassCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertDeliveryClassMst(ByVal parDeliveryClass As cStructureLib.sDeliveryClass, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO 配送種別マスタ ( " & _
                            "配送種別コード, " & _
                            "項目名称, " & _
                            "種別コード, " & _
                            "種別名称, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@DeliveryClassCode, " & _
                            "@ItemName, " & _
                            "@ClassCode, " & _
                            "@ClassName, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '配送種別コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DeliveryClassCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@DeliveryClassCode").Value = parDeliveryClass.sDeliveryClassCode
            '項目名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ItemName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@ItemName").Value = parDeliveryClass.sItemName
            '種別コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ClassCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@ClassCode").Value = parDeliveryClass.sClassCode
            '種別名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ClassName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@ClassName").Value = parDeliveryClass.sClassName
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

            '配送種別マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertDeliveryClassMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.insertDeliveryClassMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：配送種別マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateDeliveryClassMst(ByVal parDeliveryClass As cStructureLib.sDeliveryClass, ByVal KeyDeliveryClassCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 配送種別マスタ SET " & _
                        "配送種別コード = " & parDeliveryClass.sDeliveryClassCode & ", " & _
                        "項目名称 = """ & parDeliveryClass.sItemName & """, " & _
                        "種別コード = """ & parDeliveryClass.sClassCode & """, " & _
                        "種別名称 = """ & parDeliveryClass.sClassName & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE 配送種別マスタ.配送種別コード= " & KeyDeliveryClassCode & " "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '配送種別マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                Return True
            Else
                '更新するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.updateDeliveryClassMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの伝票印刷モードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteDeliveryClassMst( _
                                    ByVal KeyDeliveryClassCode As String, _
                                    ByVal KeyItemName As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strDelete = ""

            strDelete = "DELETE * FROM 配送種別マスタ "

            pc = 0

            'パラメータ数のカウント
            pc = 0
            If KeyDeliveryClassCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyItemName <> Nothing Then
                maxpc = 2
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
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "配送種別コード = " & KeyDeliveryClassCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "項目名称 = """ & KeyItemName & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            '配送種別マスタの削除処理実行
            deleteDeliveryClassMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDeliveryClassDBIO.deleteDeliveryClassMst)", Nothing, Nothing, oExcept.ToString)
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
