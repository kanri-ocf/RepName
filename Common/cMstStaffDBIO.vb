Public Class cMstStaffDBIO
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
    Public Function StaffMstExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM スタッフマスタ WHERE スタッフコード = @StaffCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@StaffCode").Value = KeyString

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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.StaffMstExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getStaff(ByRef parStaff() As cStructureLib.sStaff, _
                                ByVal keyStaffCode As String, _
                                ByVal keyStaffName As String, _
                                ByVal keyStaffClass As String, _
                                ByVal keyStaffBumon As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim j As Integer

        strSelect = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT * FROM スタッフマスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyStaffCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyStaffName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyStaffClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If keyStaffBumon <> Nothing Then
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
                            strSelect = strSelect & "スタッフコード Like ""%" & keyStaffCode & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "スタッフ名称 Like ""%" & keyStaffName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "("
                            For j = 0 To keyStaffClass.Length - 1
                                If j > 0 Then
                                    strSelect = strSelect & "Or "
                                End If
                                strSelect = strSelect & "スタッフ種別 = """ & keyStaffClass.Substring(j, 1) & """ "
                            Next j
                            scnt = scnt + 1
                            strSelect = strSelect & ") "
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門コード = """ & keyStaffBumon & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getStaff = 0

            While pDataReader.Read()
                ReDim Preserve parStaff(i)

                'レコードが取得できた時の処理
                'スタッフコード
                parStaff(i).sStaffCode = pDataReader("スタッフコード").ToString
                '役割コード
                If IsDBNull(pDataReader("役割コード")) = True Then
                    parStaff(i).sRoleCode = 0
                Else
                    parStaff(i).sRoleCode = CInt(pDataReader("役割コード"))
                End If
                'スタッフ種別
                parStaff(i).sStaffClass = pDataReader("スタッフ種別").ToString
                '部門コード
                parStaff(i).sBumonCode = pDataReader("部門コード").ToString
                '社販レート
                If IsDBNull(pDataReader("社販レート")) = True Then
                    parStaff(i).sRate = 0
                Else
                    parStaff(i).sRate = CLng(pDataReader("社販レート"))
                End If
                'スタッフ名称
                parStaff(i).sStaffName = pDataReader("スタッフ名称").ToString
                '登録日
                parStaff(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parStaff(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parStaff(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parStaff(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getStaff = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.getStaffMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getStaffAuthority(ByRef parStaffAuthority() As cStructureLib.sStaffAuthority, _
                                ByVal keyStaffCode As String, _
                                ByVal keyApplicationID As String, _
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

            strSelect = "SELECT * FROM スタッフ権限マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyStaffCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyApplicationID <> Nothing Then
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
                            strSelect = strSelect & "スタッフコード Like ""%" & keyStaffCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "アプリケーションID Like ""%" & keyApplicationID & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getStaffAuthority = 0

            While pDataReader.Read()
                ReDim Preserve parStaffAuthority(i)

                'レコードが取得できた時の処理
                'スタッフコード
                parStaffAuthority(i).sStaffCode = pDataReader("スタッフコード").ToString
                'アプリケーションID
                parStaffAuthority(i).sApplicationID = pDataReader("アプリケーションID").ToString
                '登録日
                parStaffAuthority(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parStaffAuthority(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parStaffAuthority(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parStaffAuthority(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getStaffAuthority = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.getStaffAuthority)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：スタッフマスタから新規スタッフコード取得する関数
    '----------------------------------------------------------------------
    Public Function getStaffCodeNull(ByRef parStaff() As cStructureLib.sStaff, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM スタッフマスタ WHERE スタッフコード Not Like ""990%"" "

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getStaffCodeNull = 0

            While pDataReader.Read()

                ReDim Preserve parStaff(i)

                'スタッフコード
                parStaff(i).sStaffCode = pDataReader("スタッフコード").ToString
                '役割コード
                If IsDBNull(pDataReader("役割コード")) = True Then
                    parStaff(i).sRoleCode = 0
                Else
                    parStaff(i).sRoleCode = CInt(pDataReader("役割コード"))
                End If
                'スタッフ種別
                parStaff(i).sStaffClass = pDataReader("スタッフ種別").ToString
                '部門コード
                parStaff(i).sBumonCode = pDataReader("部門コード").ToString
                '社販レート
                If IsDBNull(pDataReader("社販レート")) = True Then
                    parStaff(i).sRate = 0
                Else
                    parStaff(i).sRate = CLng(pDataReader("社販レート"))
                End If
                'スタッフ名称
                parStaff(i).sStaffName = pDataReader("スタッフ名称").ToString
                '登録日
                parStaff(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parStaff(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parStaff(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parStaff(i).sUpdateTime = pDataReader("最終更新時間").ToString
                i = i + 1
            End While

            getStaffCodeNull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.getStaffCodeNull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getStaffFull(ByRef parStaffFull() As cStructureLib.sViewStaffFull, _
                                          ByVal keyStaffCode As String, _
                                          ByVal keyStaffName As String, _
                                          ByVal keyStaffClass As String, _
                                          ByVal keyGroupName As String, _
                                          ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim j As Integer

        strSelect = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT " & _
                            "スタッフマスタ.スタッフコード AS スタッフコード, " & _
                            "スタッフマスタ.役割コード AS 役割コード, " & _
                            "役割マスタ.役割名称 AS 役割名称, " & _
                            "スタッフマスタ.スタッフ種別 AS スタッフ種別, " & _
                            "スタッフマスタ.部門コード AS 部門コード, " & _
                            "スタッフマスタ.社販レート AS 社販レート, " & _
                            "スタッフマスタ.スタッフ名称 AS スタッフ名称, " & _
                            "スタッフ権限マスタ.アプリケーションID AS アプリケーションID, " & _
                            "アプリケーションマスタ.グループID AS グループID, " & _
                            "アプリケーションマスタ.グループ名称 AS グループ名称, " & _
                            "アプリケーションマスタ.メニュー名称 AS メニュー名称, " & _
                            "アプリケーションマスタ.コントロール名称 AS コントロール名称, " & _
                            "アプリケーションマスタ.実行モジュール名称 AS 実行モジュール名称 " & _
                        "FROM " & _
                            "役割マスタ RIGHT JOIN ((スタッフマスタ LEFT JOIN スタッフ権限マスタ " & _
                            "ON スタッフマスタ.スタッフコード = スタッフ権限マスタ.スタッフコード) " & _
                            "LEFT JOIN アプリケーションマスタ " & _
                            "ON スタッフ権限マスタ.アプリケーションID = アプリケーションマスタ.アプリケーションID) " & _
                            "ON 役割マスタ.役割コード = スタッフマスタ.役割コード "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyStaffCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyStaffName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyStaffClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If keyGroupName <> Nothing Then
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
                            strSelect = strSelect & "スタッフマスタ.スタッフコード Like ""%" & keyStaffCode & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "スタッフマスタ.スタッフ名称 Like ""%" & keyStaffName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "("
                            For j = 0 To keyStaffClass.Length - 1
                                If j > 0 Then
                                    strSelect = strSelect & "Or "
                                End If
                                strSelect = strSelect & "スタッフマスタ.スタッフ種別 = """ & keyStaffClass.Substring(j, 1) & """) "
                            Next j
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "アプリケーションマスタ.グループ名称 Like ""%" & keyGroupName & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            ReDim parStaffFull(0)

            While pDataReader.Read()
                ReDim Preserve parStaffFull(i)

                'レコードが取得できた時の処理
                'スタッフコード
                parStaffFull(i).sStaffCode = pDataReader("スタッフコード").ToString
                '役割コード
                If IsDBNull(pDataReader("役割コード")) = True Then
                    parStaffFull(i).sRoleCode = 0
                Else
                    parStaffFull(i).sRoleCode = CInt(pDataReader("役割コード"))
                End If
                '役割名称
                parStaffFull(i).sRoleName = pDataReader("役割名称").ToString
                'スタッフ種別
                parStaffFull(i).sStaffClass = pDataReader("スタッフ種別").ToString
                '部門コード
                parStaffFull(i).sBumonCode = pDataReader("部門コード").ToString
                '社販レート
                If IsDBNull(pDataReader("社販レート")) = True Then
                    parStaffFull(i).sRate = 0
                Else
                    parStaffFull(i).sRate = CLng(pDataReader("社販レート"))
                End If                'スタッフ名称
                parStaffFull(i).sStaffName = pDataReader("スタッフ名称").ToString
                'アクセス可能アプリケーションID
                parStaffFull(i).sApplicationID = pDataReader("アプリケーションID").ToString
                'グループID
                parStaffFull(i).sGroupID = pDataReader("グループID").ToString
                'グループ名称
                parStaffFull(i).sGroupName = pDataReader("グループ名称").ToString
                'メニュー名称
                parStaffFull(i).sMenuName = pDataReader("メニュー名称").ToString
                'コントロール名称
                parStaffFull(i).sControlName = pDataReader("コントロール名称").ToString
                '実行モジュール名称
                parStaffFull(i).sExeName = pDataReader("実行モジュール名称").ToString

                i = i + 1

            End While

            getStaffFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.getStaffFull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertStaffMst(ByVal parStaff As cStructureLib.sStaff, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsertOrder As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsertOrder = "INSERT INTO スタッフマスタ ( " & _
                                "スタッフコード, " & _
                                "役割コード, " & _
                                "スタッフ種別, " & _
                                "部門コード, " & _
                                "社販レート, " & _
                                "スタッフ名称, " & _
                                "登録日, " & _
                                "登録時間, " & _
                                "最終更新日, " & _
                                "最終更新時間 " & _
                            ") VALUES (" & _
                                "@StaffCode, " & _
                                "@RoleCode, " & _
                                "@StaffClass, " & _
                                "@BumonCode, " & _
                                "@Rate, " & _
                                "@StaffName, " & _
                                "@CreateDate, " & _
                                "@CreateTime, " & _
                                "@UpdateDate, " & _
                                "@UpdateTime " & _
                            ")"

            pCommand.CommandText = strInsertOrder

            '***********************
            '   パラメータの設定
            '***********************

            'スタッフコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@StaffCode").Value = parStaff.sStaffCode
            '役割コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoleCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@RoleCode").Value = parStaff.sRoleCode
            'スタッフ種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffClass", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@StaffClass").Value = parStaff.sStaffClass
            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parStaff.sBumonCode
            '社販レート
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Rate", OleDb.OleDbType.Numeric, 1.2))
            pCommand.Parameters("@Rate").Value = parStaff.sRate
            'スタッフ名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffName", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@StaffName").Value = parStaff.sStaffName
            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CreateTime").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            'スタッフマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertStaffMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.insertStaffMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertStaffAuthorityMst(ByVal parStaffAuthority As cStructureLib.sStaffAuthority, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO スタッフ権限マスタ ( " & _
                                "スタッフコード, " & _
                                "アプリケーションID, " & _
                                "登録日, " & _
                                "登録時間, " & _
                                "最終更新日, " & _
                                "最終更新時間 " & _
                            ") VALUES (" & _
                                "@StaffCode, " & _
                                "@ApplicationID, " & _
                                "@CreateDate, " & _
                                "@CreateTime, " & _
                                "@UpdateDate, " & _
                                "@UpdateTime " & _
                            ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'スタッフコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@StaffCode").Value = parStaffAuthority.sStaffCode
            'アプリケーションID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ApplicationID", OleDb.OleDbType.Char, 3))
            pCommand.Parameters("@ApplicationID").Value = parStaffAuthority.sApplicationID
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

            'スタッフマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertStaffAuthorityMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.insertStaffAuthorityMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：スタッフマスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateStaffMst(ByVal parStaff As cStructureLib.sStaff, ByVal KeyStaffCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE スタッフマスタ SET " & _
                        "スタッフコード = """ & parStaff.sStaffCode & """, " & _
                        "スタッフ名称 = """ & parStaff.sStaffName & """, " & _
                        "役割コード = " & parStaff.sRoleCode & ", " & _
                        "スタッフ種別 = """ & parStaff.sStaffClass & """, " & _
                        "部門コード = """ & parStaff.sBumonCode & """, " & _
                        "社販レート = " & parStaff.sRate & ", " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE スタッフマスタ.スタッフコード= """ & KeyStaffCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'スタッフマスタ更新SQL文実行
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.updateStaff)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteStaffMst(ByVal KeyStaffCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE スタッフマスタ.スタッフコード FROM スタッフマスタ " & _
                        "WHERE スタッフマスタ.スタッフコード=""" & KeyStaffCode & """ "

            pCommand.CommandText = strDelete

            'スタッフマスタの削除処理実行
            deleteStaffMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.deleteStaffMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteStaffAuthorityMst(ByVal KeyStaffCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE スタッフ権限マスタ.スタッフコード FROM スタッフ権限マスタ " & _
                        "WHERE スタッフ権限マスタ.スタッフコード=""" & KeyStaffCode & """ "

            pCommand.CommandText = strDelete

            'スタッフマスタの削除処理実行
            deleteStaffAuthorityMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.deleteStaffAuthorityMst)", Nothing, Nothing, oExcept.ToString)
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
