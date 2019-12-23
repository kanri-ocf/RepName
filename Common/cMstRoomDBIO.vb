Public Class cMstRoomDBIO
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
    Public Function getRoom(ByRef parRoom() As cStructureLib.sRoom, _
                            ByVal keyRoomCode As String, _
                            ByVal keyChannelCode As Integer, _
                            ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT * FROM ルームマスタ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keyRoomCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyChannelCode <> Nothing Then
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
                        strSelect = strSelect & "ルームコード =" & keyRoomCode & " "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード =" & keyChannelCode & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY ルームコード, チャネルコード "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parRoom(i)

                'レコードが取得できた時の処理
                'ルームコード
                If IsDBNull(pDataReader("ルームコード")) = True Then
                    parRoom(i).sRoomCode = 0
                Else
                    parRoom(i).sRoomCode = CInt(pDataReader("ルームコード"))
                End If
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRoom(i).sChannelCode = 0
                Else
                    parRoom(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'ルーム名称
                parRoom(i).sRoomName = pDataReader("ルーム名称").ToString
                '登録日
                parRoom(i).sUpdateDate = pDataReader("登録日").ToString
                '登録日時
                parRoom(i).sUpdateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRoom(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parRoom(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getRoom = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.getRoom)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getRoomBumon(ByRef parRoomBumon() As cStructureLib.sRoomBumon, _
                            ByVal keyRoomCode As Integer, _
                            ByVal keyBumonCode As String, _
                            ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT * FROM ルーム利用分野マスタ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keyRoomCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyBumonCode <> Nothing Then
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
                        strSelect = strSelect & "ルームコード =" & keyRoomCode & " "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "部門コード =""" & keyBumonCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY ルームコード, 部門コード "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parRoomBumon(i)

                'レコードが取得できた時の処理
                'ルームコード
                If IsDBNull(pDataReader("ルームコード")) = True Then
                    parRoomBumon(i).sRoomCode = 0
                Else
                    parRoomBumon(i).sRoomCode = CInt(pDataReader("ルームコード"))
                End If
                '部門コード
                If IsDBNull(pDataReader("部門コード")) = True Then
                    parRoomBumon(i).sBumonCode = 0
                Else
                    parRoomBumon(i).sBumonCode = CLng(pDataReader("部門コード"))
                End If
                '登録日
                parRoomBumon(i).sUpdateDate = pDataReader("登録日").ToString
                '登録日時
                parRoomBumon(i).sUpdateTime = pDataReader("登録時間").ToString
                '最終更新日
                parRoomBumon(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parRoomBumon(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getRoomBumon = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.getRoomBumon)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getRoomFull(ByRef parRoomFull() As cStructureLib.sViewRoomFull, _
                        ByVal keyRoomCode As String, _
                        ByVal keyRoomName As String, _
                        ByVal keyChannelCode As Integer, _
                        ByVal keyChannelName As Integer, _
                        ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT " & _
                        "ルームマスタ.ルームコード AS ルームコード, " & _
                        "ルームマスタ.ルーム名称 AS ルーム名称, " & _
                        "チャネルマスタ.チャネルコード AS チャネルコード, " & _
                        "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                        "チャネルマスタ.チャネル種別 AS チャネル種別, " & _
                        "チャネルマスタ.URL AS URL, " & _
                        "チャネルマスタ.レシート印刷フラグ AS レシート印刷フラグ, " & _
                        "チャネルマスタ.売上計上フラグ AS 売上計上フラグ, " & _
                        "チャネルマスタ.注文データファイル有無 AS 注文データファイル有無, " & _
                        "チャネルマスタ.注文明細データファイル有無 AS 注文明細データファイル有無, " & _
                        "チャネルマスタ.CMSタイプ AS CMSタイプ, " & _
                        "チャネルマスタ.OR受注コード名称 AS OR受注コード名称 " & _
                    "FROM ルームマスタ LEFT JOIN チャネルマスタ ON ルームマスタ.チャネルコード = チャネルマスタ.チャネルコード "

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keyRoomCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyRoomName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If keyChannelCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If keyChannelName <> Nothing Then
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
                        strSelect = strSelect & "ルームマスタ.ルームコード =" & keyRoomCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "ルームマスタ.ルーム名称 Like ""%" & keyRoomName & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルマスタ.チャネルコード =" & keyChannelCode & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルマスタ.チャネル名称 Like ""%" & keyChannelName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY チャネルマスタ.チャネルコード, ルームマスタ.ルームコード  "

        Try

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parRoomFull(i)

                'レコードが取得できた時の処理
                'ルームコード
                If IsDBNull(pDataReader("ルームコード")) = True Then
                    parRoomFull(i).sRoomCode = 0
                Else
                    parRoomFull(i).sRoomCode = CInt(pDataReader("ルームコード"))
                End If
                'ルーム名称
                parRoomFull(i).sRoomName = pDataReader("ルーム名称").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRoomFull(i).sChannelCode = 0
                Else
                    parRoomFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'チャネル名称
                parRoomFull(i).sChannelName = pDataReader("チャネル名称").ToString
                'チャネル種別
                parRoomFull(i).sChannelClass = CInt(pDataReader("チャネル種別"))
                'URL
                parRoomFull(i).sURL = pDataReader("URL").ToString
                'レシート印刷フラグ
                parRoomFull(i).sReceiptPrint = CBool(pDataReader("レシート印刷フラグ"))
                '売上計上フラグ
                parRoomFull(i).sSaleRegist = CBool(pDataReader("売上計上フラグ"))
                '注文データファイル有無
                parRoomFull(i).sRequestFileFlg = CBool(pDataReader("注文データファイル有無"))
                '注文明細データファイル有無
                parRoomFull(i).sRequestSubFileFlg = CBool(pDataReader("注文明細データファイル有無"))
                'CMSタイプ
                parRoomFull(i).sCMSType = CInt(pDataReader("CMSタイプ"))
                'OR受注コードフィールド名
                parRoomFull(i).sORRequestCodeFieldName = pDataReader("OR受注コード名称").ToString

                i = i + 1
            End While

            getRoomFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.getRoomFull)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getNewRoomCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim strSelect As String

        strSelect = "SELECT Max([ルームコード]) AS 最終ルームコード FROM ルームマスタ "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            If IsDBNull(pDataReader("最終ルームコード")) Then
                getNewRoomCode = 1
            Else
                getNewRoomCode = CInt(pDataReader("最終ルームコード")) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.getNewRoomCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertRoom(ByRef parRoom As cStructureLib.sRoom, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        'SQL文の設定
        Const strInsert As String = "INSERT INTO ルームマスタ " & _
                                            "( ルームコード, チャネルコード, ルーム名称, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                                            "VALUES ( @RoomCode, @ChannelCode, @RoomName, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            'ルームコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoomCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@RoomCode").Value = parRoom.sRoomCode

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@ChannelCode").Value = parRoom.sChannelCode

            'ルーム名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoomName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@RoomName").Value = parRoom.sRoomName

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parRoom.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parRoom.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parRoom.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parRoom.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            'ルームマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertRoom = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.insertRoom)", Nothing, Nothing, oExcept.ToString)
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

    Public Function insertRoomBumon(ByRef parRoomBumon As cStructureLib.sRoomBumon, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        'SQL文の設定
        Const strInsert As String = "INSERT INTO ルーム利用分野マスタ " & _
                                            "( ルームコード, 部門コード, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                                            "VALUES ( @RoomCode, @BumonCode, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            'ルームコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RoomCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@RoomCode").Value = parRoomBumon.sRoomCode

            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parRoomBumon.sBumonCode

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parRoomBumon.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parRoomBumon.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parRoomBumon.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parRoomBumon.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            'ルームマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertRoomBumon = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.insertRoomBumon)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ルームマスタの１レコードを更新するメソッド
    '　引名称：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateRoom(ByVal parRoom() As cStructureLib.sRoom, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordName As Integer
        Dim strUpdate As String

        strUpdate = "UPDATE ルームマスタ SET " & _
                            "チャネルコード=" & parRoom(0).sChannelCode & ", " & _
                            "ルーム名称=""" & parRoom(0).sRoomName & """, " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE ルームコード=" & parRoom(0).sRoomCode & " "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'ルームマスタ更新SQL文実行
            RecordName = pCommand.ExecuteNonQuery()
            If RecordName > 0 Then
                '更新成功
                updateRoom = True
            Else
                '更新するレコードがなかった時の処理
                updateRoom = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.updateRoom)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ルームマスタの１レコードを削除するメソッド
    '　引名称：ルームコード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteRoom(ByVal KeyRoomCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM ルームマスタ WHERE ルームコード=" & KeyRoomCode & " "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            'ルームマスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteRoom = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.deleteRoom)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ルームマスタの１レコードを削除するメソッド
    '　引名称：ルームコード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteRoomBumon(ByVal KeyRoomCode As Integer, ByVal KeyBumonCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'SQL文の設定
        strDelete = "DELETE * FROM ルーム利用分野マスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If KeyRoomCode <> Nothing Then
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
                            strDelete = strDelete & "ルームコード =" & KeyRoomCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "部門コード =""" & KeyBumonCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            'ルームマスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteRoomBumon = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.deleteRoomBumon)", Nothing, Nothing, oExcept.ToString)
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
