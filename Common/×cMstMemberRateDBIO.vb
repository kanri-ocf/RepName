Public Class cMstMemberRateDBIO
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
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getMemberRate(ByRef parMemberRate() As cStructureLib.sMemberRate, _
                                ByVal keyMemberClass As String, _
                                ByVal keyBumonCode As String, _
                                ByVal keyRateClass As String, _
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

            strSelect = "SELECT * FROM 会員割引率マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyMemberClass <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyBumonCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyRateClass <> Nothing Then
                maxpc = 4
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
                            strSelect = strSelect & "メンバー種別 Like ""%" & keyMemberClass & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門コード Like ""%" & keyBumonCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "割引率種別 Like ""%" & keyRateClass & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getMemberRate = 0

            While pDataReader.Read()
                ReDim Preserve parMemberRate(i)

                'レコードが取得できた時の処理

                'メンバー種別
                parMemberRate(i).sMemberClass = pDataReader("メンバー種別").ToString
                '部門コード
                parMemberRate(i).sBumonCode = pDataReader("部門コード").ToString
                '割引率種別
                parMemberRate(i).sRateClass = pDataReader("割引率種別").ToString
                '割引率
                If IsDBNull(pDataReader("割引率")) = True Then
                    parMemberRate(i).sRate = 0
                Else
                    parMemberRate(i).sRate = CInt(pDataReader("割引率"))
                End If
                '登録日
                parMemberRate(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parMemberRate(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parMemberRate(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parMemberRate(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getMemberRate = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberRateDBIO.getMemberRate)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getMemberRateFull(ByRef parMemberRateFull() As cStructureLib.sViewMemberRateFull, _
                                ByVal keyMemberClass As String, _
                                ByVal keyBumonCode As String, _
                                ByVal keyRateClass As String, _
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

            strSelect = "SELECT " & _
                            "会員割引率マスタ.メンバー種別 AS メンバー種別, " & _
                            "会員割引率マスタ.部門コード AS 部門コード, " & _
                            "部門マスタ.部門名称 AS 部門名称, " & _
                            "会員割引率マスタ.割引率種別 AS 割引率種別, " & _
                            "会員割引率マスタ.割引率 AS 割引率 " & _
                        "FROM 会員割引率マスタ LEFT JOIN 部門マスタ ON 会員割引率マスタ.部門コード = 部門マスタ.部門コード "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyMemberClass <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyBumonCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyRateClass <> Nothing Then
                maxpc = 4
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
                            strSelect = strSelect & "メンバー種別 Like ""%" & keyMemberClass & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門コード Like ""%" & keyBumonCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "割引率種別 Like ""%" & keyRateClass & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getMemberRateFull = 0

            While pDataReader.Read()
                ReDim Preserve parMemberRateFull(i)

                'レコードが取得できた時の処理

                'メンバー種別
                parMemberRateFull(i).sMemberClass = pDataReader("メンバー種別").ToString
                '部門コード
                parMemberRateFull(i).sBumonCode = pDataReader("部門コード").ToString
                '部門名称
                parMemberRateFull(i).sBumonName = pDataReader("部門名称").ToString
                '割引率種別
                parMemberRateFull(i).sRateClass = pDataReader("割引率種別").ToString
                '割引率
                If IsDBNull(pDataReader("割引率")) = True Then
                    parMemberRateFull(i).sRate = 0
                Else
                    parMemberRateFull(i).sRate = CInt(pDataReader("割引率"))
                End If

                i = i + 1

            End While

            getMemberRateFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberRateDBIO.getMemberRateFull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getMemberClass(ByRef parMemberClass() As cStructureLib.sViewMemberClass, _
                                ByVal keyMemberClass As String, _
                                ByVal keyRateClass As String, _
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

            strSelect = "SELECT DISTINCT 割引率種別 FROM 会員割引率マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keyMemberClass <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyRateClass <> Nothing Then
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
                            strSelect = strSelect & "メンバー種別 Like ""%" & keyMemberClass & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "割引率種別 Like ""%" & keyRateClass & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getMemberClass = 0

            While pDataReader.Read()
                ReDim Preserve parMemberClass(i)

                'レコードが取得できた時の処理

                'メンバー種別
                parMemberClass(i).sMemberClass = pDataReader("割引率種別").ToString

                i = i + 1

            End While

            getMemberClass = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberRateDBIO.getMemberClass)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertMemberRate(ByVal parMemberRate As cStructureLib.sMemberRate, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO スタッフマスタ ( " & _
                                "メンバー種別, " & _
                                "部門コード, " & _
                                "割引率種別, " & _
                                "割引率, " & _
                                "登録日, " & _
                                "登録時間, " & _
                                "最終更新日, " & _
                                "最終更新時間 " & _
                            ") VALUES (" & _
                                "@MemberClass, " & _
                                "@BumonCode, " & _
                                "@RateClass, " & _
                                "@Rate, " & _
                                "@CreateDate, " & _
                                "@CreateTime, " & _
                                "@UpdateDate, " & _
                                "@UpdateTime " & _
                            ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'メンバー種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberClass", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@MemberClass").Value = parMemberRate.sMemberClass
            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parMemberRate.sBumonCode
            '割引率種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RateClass", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@RateClass").Value = parMemberRate.sRateClass
            '割引率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Rate", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@Rate").Value = parMemberRate.sRate
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

            insertMemberRate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberRateDBIO.insertMemberRate)", Nothing, Nothing, oExcept.ToString)
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
    Public Function updateMemberRate(ByVal parMemberRate As cStructureLib.sMemberRate, _
                                   ByVal KeyStaffCode As String, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE スタッフマスタ SET " & _
                        "メンバー種別 = """ & parMemberRate.sMemberClass & """, " & _
                        "部門コード = """ & parMemberRate.sBumonCode & """, " & _
                        "割引率種別 = """ & parMemberRate.sRateClass & """, " & _
                        "割引率 = " & parMemberRate.sRate & ", " & _
                        "登録日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "登録時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                    "WHERE スタッフマスタ.スタッフコード= """ & KeyStaffCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'スタッフマスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updateMemberRate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberRateDBIO.updateMemberRate)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteMemberRate(ByVal KeyMemberClass As String, _
                                     ByVal KeyBumonCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            '*********************************
            '発注情報データ削除SQL文の設定
            '*********************************
            strDelete = "DELETE * FROM 会員割引率マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If KeyMemberClass <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyBumonCode <> Nothing Then
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
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "メンバーコード Like ""%" & KeyMemberClass & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "部門コード Like ""%" & KeyBumonCode & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            '発注情報データ挿入処理実行
            deleteMemberRate = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstStaffDBIO.deleteOrderData)", Nothing, Nothing, oExcept.ToString)
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
