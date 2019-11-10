Public Class cMstApplicationDBIO
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
    '　機能：プロパティの取引コードのレコードが部門マスタに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ApplicationMstExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM アプリケーションマスタ WHERE アプリケーションコード = @ApplicationCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ApplicationCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@ApplicationCode").Value = KeyString

            '部門マスタから該当取引コードのレコード数読込 
            Dim recCount As Integer
            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                Return True
            Else
                'レコードが存在しない時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstApplicationDBIO.ApplicationMstExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getApplication(ByRef parApplication() As cStructureLib.sApplication, _
                                ByVal keyApplicationID As String, _
                                ByVal keyGroupID As String, _
                                ByVal keyGroupName As String, _
                                ByVal keyMenuName As String, _
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

            strSelect = "SELECT * FROM アプリケーションマスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyApplicationID <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyGroupID <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyGroupName <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If keyMenuName <> Nothing Then
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
                            strSelect = strSelect & "アプリケーションID Like ""%" & keyApplicationID & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "グループID Like ""%" & keyGroupID & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "グループ名称 Like ""%" & keyGroupName & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "メニュー名称 Like ""%" & keyMenuName & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getApplication = 0

            While pDataReader.Read()
                ReDim Preserve parApplication(i)

                'レコードが取得できた時の処理
                'アプリケーションID
                parApplication(i).sApplicationID = pDataReader("アプリケーションID").ToString
                'グループID
                parApplication(i).sGroupID = pDataReader("グループID").ToString
                'グループ名称
                parApplication(i).sGroupName = pDataReader("グループ名称").ToString
                'メニュー名称
                parApplication(i).sMenuName = pDataReader("メニュー名称").ToString
                'コントロール名称
                parApplication(i).sControlName = pDataReader("コントロール名称").ToString
                '実行モジュール名称
                parApplication(i).sExeName = pDataReader("実行モジュール名称").ToString
                '登録日
                parApplication(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parApplication(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parApplication(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parApplication(i).sUpdateTime = pDataReader("最終更新時間").ToString
                i = i + 1

            End While

            getApplication = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstApplicationDBIO.getApplication)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertApplicationMst(ByVal parApplication As cStructureLib.sApplication, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsertOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsertOrder = "INSERT INTO アプリケーションマスタ ( " & _
                                "アプリケーションID, " & _
                                "グループID, " & _
                                "グループ名称, " & _
                                "メニュー名称, " & _
                                "コントロール名称, " & _
                                "実行モジュール名称, " & _
                                "登録日, " & _
                                "登録時間, " & _
                                "最終更新日, " & _
                                "最終更新時間 " & _
                            ") VALUES (" & _
                                "@ApplicationID, " & _
                                "@GroupID, " & _
                                "@GroupName, " & _
                                "@MenuName, " & _
                                "@ControlName, " & _
                                "@ExeName, " & _
                                "@CreateDate, " & _
                                "@CreateTime, " & _
                                "@UpdateDate, " & _
                                "@UpdateTime " & _
                            ")"

            pCommand.CommandText = strInsertOrder

            '***********************
            '   パラメータの設定
            '***********************

            'アプリケーションID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ApplicationID", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@ApplicationID").Value = parApplication.sApplicationID
            'グループID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GroupID", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@GroupID").Value = parApplication.sGroupID
            'グループ名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GroupName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@GroupName").Value = parApplication.sGroupName
            'メニュー名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MenuName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@MenuName").Value = parApplication.sMenuName
            'コントロール名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ControlName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ControlName").Value = parApplication.sControlName
            '実行モジュール名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ExeName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ExeName").Value = parApplication.sExeName
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

            'アプリケーションマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertApplicationMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstApplicationDBIO.insertApplicationMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：アプリケーションマスタの１レコードを更新するメソッド
    '　引数：in cApplicationオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateApplicationMst(ByVal parApplication As cStructureLib.sApplication, ByVal KeyApplicationCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE アプリケーションマスタ SET " & _
                        "アプリケーションID = """ & parApplication.sApplicationID & """, " & _
                        "グループID = """ & parApplication.sGroupID & """, " & _
                        "グループ名称 = """ & parApplication.sGroupName & """, " & _
                        "メニュー名称 = """ & parApplication.sMenuName & """, " & _
                        "コントロール名称 = """ & parApplication.sControlName & """, " & _
                        "実行モジュール名称 = """ & parApplication.sExeName & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE アプリケーションマスタ.アプリケーションコード= """ & KeyApplicationCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'アプリケーションマスタ更新SQL文実行
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstApplicationDBIO.updateApplication)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteApplicationMst(ByVal KeyApplicationID As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            '*********************************
            '発注情報データ削除SQL文の設定
            '*********************************
            strDelete = "DELETE アプリケーションID FROM アプリケーションマスタ " & _
                "WHERE アプリケーションID=@ApplicationID"

            pCommand.CommandText = strDelete

            '***********************
            '   パラメータの設定
            '***********************

            '発注番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ApplicationID", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ApplicationID").Value = KeyApplicationID

            '発注情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteApplicationMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstApplicationDBIO.deleteApplicationMst)", Nothing, Nothing, oExcept.ToString)
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
