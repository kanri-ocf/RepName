Public Class cMstChannelPaymentDBIO

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
    '　機能：チャネル別支払方法マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得されたレコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getChannelPaymentMst(ByRef parChannelPayment() As cStructureLib.sChannelPayment, _
                                  ByVal keyChannelPaymentCode As Integer, _
                                  ByVal keyChannelCode As Integer, _
                                  ByVal keyPaymentCode As Integer, _
                                  ByVal keyChannelPaymentName As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = "SELECT * FROM チャネル別支払方法マスタ "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        maxpc = 0
        If keyChannelPaymentCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyChannelCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If keyPaymentCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If keyChannelPaymentName <> Nothing Then
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
                        strSelect = strSelect & "チャネル支払コード = " & keyChannelPaymentCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード = " & keyChannelCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法コード = " & keyPaymentCode & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネル別支払方法名称 like ""%" & keyChannelPaymentName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        pCommand.CommandText = strSelect

        Try

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parChannelPayment(CInt(i))

                'レコードが取得できた時の処理

                'チャネル支払コード
                parChannelPayment(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                'チャネルコード
                parChannelPayment(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                '支払方法コード
                parChannelPayment(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                'チャネル別支払方法名称
                parChannelPayment(i).sChannelPaymentName = pDataReader("チャネル別支払方法名称").ToString
                '登録日
                parChannelPayment(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parChannelPayment(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parChannelPayment(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parChannelPayment(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getChannelPaymentMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.getChannelPaymentMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：チャネル別支払方法マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得されたレコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getChannelPaymentFull(ByRef parChannelPaymentFull() As cStructureLib.sViewChannelPaymentFull, _
                                  ByVal keyChannelPaymentCode As Integer, _
                                  ByVal keyChannelCode As Integer, _
                                  ByVal keyPaymentCode As Integer, _
                                  ByVal keyChannelPaymentName As String, _
                                  ByVal keyPaymentName As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = "SELECT " & _
                        "チャネル別支払方法マスタ.チャネル支払コード AS チャネル支払コード, " & _
                        "チャネル別支払方法マスタ.チャネルコード AS チャネルコード, " & _
                        "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                        "支払方法マスタ.支払方法コード AS 支払方法コード, " & _
                        "支払方法マスタ.支払方法名称 AS 支払方法名称, " & _
                        "チャネル別支払方法マスタ.チャネル別支払方法名称 AS チャネル別支払方法名称, " & _
                        "支払方法マスタ.掛取引フラグ AS 掛取引フラグ, " & _
                        "支払方法マスタ.受注フラグ AS 受注フラグ, " & _
                        "支払方法マスタ.出荷フラグ AS 出荷フラグ, " & _
                        "支払方法マスタ.発注フラグ AS 発注フラグ, " & _
                        "支払方法マスタ.入荷フラグ AS 入荷フラグ, " & _
                        "支払方法マスタ.返品フラグ AS 返品フラグ, " & _
                        "支払方法マスタ.配送時代引きフラグ AS 配送時代引きフラグ " & _
                    "FROM " & _
                        "(" & _
                            "(" & _
                                "支払方法マスタ LEFT JOIN チャネル別支払方法マスタ " & _
                                "ON 支払方法マスタ.支払方法コード = チャネル別支払方法マスタ.支払方法コード" & _
                            ") " & _
                            "LEFT JOIN チャネルマスタ " & _
                            "ON チャネル別支払方法マスタ.チャネルコード = チャネルマスタ.チャネルコード" & _
                        ") "
        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        maxpc = 0
        If keyChannelPaymentCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyChannelCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If keyPaymentCode <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If keyChannelPaymentName <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If keyChannelPaymentName <> Nothing Then
            maxpc = 16
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
                        strSelect = strSelect & "チャネル別支払方法マスタ.チャネル支払コード = " & keyChannelPaymentCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネル別支払方法マスタ.チャネルコード = " & keyChannelCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法マスタ.支払方法コード = " & keyPaymentCode & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネル別支払方法名称 like ""%" & keyChannelPaymentName & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法マスタ.支払方法名称 like ""%" & keyChannelPaymentName & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        pCommand.CommandText = strSelect

        Try

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parChannelPaymentFull(CInt(i))

                'レコードが取得できた時の処理

                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parChannelPaymentFull(i).sChannelPaymentCode = 0
                Else
                    parChannelPaymentFull(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parChannelPaymentFull(i).sChannelCode = 0
                Else
                    parChannelPaymentFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'チャネル名称
                parChannelPaymentFull(i).sChannelName = pDataReader("チャネル名称").ToString
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parChannelPaymentFull(i).sPaymentCode = 0
                Else
                    parChannelPaymentFull(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                'チャネル別支払方法名称
                parChannelPaymentFull(i).sChannelPaymentName = pDataReader("チャネル別支払方法名称").ToString
                '支払方法名称
                parChannelPaymentFull(i).sPaymentName = pDataReader("支払方法名称").ToString
                '掛け取引フラグ
                If IsDBNull(pDataReader("掛取引フラグ")) = True Then
                    parChannelPaymentFull(i).sCreditFlg = False
                Else
                    parChannelPaymentFull(i).sCreditFlg = CBool(pDataReader("掛取引フラグ"))
                End If
                '受注フラグ
                If IsDBNull(pDataReader("受注フラグ")) = True Then
                    parChannelPaymentFull(i).sRequestFlg = False
                Else
                    parChannelPaymentFull(i).sRequestFlg = CBool(pDataReader("受注フラグ"))
                End If
                '出荷フラグ
                If IsDBNull(pDataReader("出荷フラグ")) = True Then
                    parChannelPaymentFull(i).sShipmentFlg = False
                Else
                    parChannelPaymentFull(i).sShipmentFlg = CBool(pDataReader("出荷フラグ"))
                End If
                '発注フラグ
                If IsDBNull(pDataReader("発注フラグ")) = True Then
                    parChannelPaymentFull(i).sOrderFlg = False
                Else
                    parChannelPaymentFull(i).sOrderFlg = CBool(pDataReader("発注フラグ"))
                End If
                '入荷フラグ
                If IsDBNull(pDataReader("入荷フラグ")) = True Then
                    parChannelPaymentFull(i).sArrivalFlg = False
                Else
                    parChannelPaymentFull(i).sArrivalFlg = CBool(pDataReader("入荷フラグ"))
                End If
                '返品フラグ
                If IsDBNull(pDataReader("返品フラグ")) = True Then
                    parChannelPaymentFull(i).sReturnFlg = False
                Else
                    parChannelPaymentFull(i).sReturnFlg = CBool(pDataReader("返品フラグ"))
                End If

                '配送時代引きフラグ
                If IsDBNull(pDataReader("配送時代引きフラグ")) = True Then
                    parChannelPaymentFull(i).sDaibikiFlg = False
                Else
                    parChannelPaymentFull(i).sDaibikiFlg = CBool(pDataReader("配送時代引きフラグ"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getChannelPaymentFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.getChannelPaymentFull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getNewChannelPaymentCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String

        getNewChannelPaymentCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT Max([チャネル支払コード]) AS 最大チャネル支払コード FROM チャネル別支払方法マスタ "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            '最大チャネル支払コード
            If IsDBNull(pDataReader("最大チャネル支払コード")) Then
                getNewChannelPaymentCode = 1
            Else
                getNewChannelPaymentCode = CInt(pDataReader("最大チャネル支払コード").ToString) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.getNewChannelPaymentCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertChannelPaymentMst(ByVal parChannelPayment As cStructureLib.sChannelPayment, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO チャネル別支払方法マスタ ( " & _
                            "チャネル支払コード, " & _
                            "チャネルコード, " & _
                            "支払方法コード, " & _
                            "チャネル別支払方法名称, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@ChannelPaymentCode, " & _
                            "@ChannelCode, " & _
                            "@PaymentCode, " & _
                            "@ChannelPaymentName, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'チャネル支払コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelPaymentCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@ChannelPaymentCode").Value = parChannelPayment.sChannelPaymentCode
            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@ChannelCode").Value = parChannelPayment.sChannelCode
            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@PaymentCode").Value = parChannelPayment.sPaymentCode
            'チャネル別支払方法名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelPaymentName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ChannelPaymentName").Value = parChannelPayment.sChannelPaymentName
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

            'チャネル別支払方法マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertChannelPaymentMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.insertChannelPaymentMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：チャネル別支払方法マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateChannelPaymentMst(ByVal parChannelPayment As cStructureLib.sChannelPayment, ByVal KeyChannelPaymentCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE チャネル別支払方法マスタ SET " & _
                        "チャネル支払コード = " & parChannelPayment.sChannelPaymentCode & ", " & _
                        "チャネルコード = " & parChannelPayment.sChannelCode & ", " & _
                        "支払方法コード = " & parChannelPayment.sPaymentCode & ", " & _
                        "チャネル別支払方法名称 = """ & parChannelPayment.sChannelPaymentName & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE チャネル別支払方法マスタ.チャネル支払コード= " & KeyChannelPaymentCode & " "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'チャネル別支払方法マスタ更新SQL文実行
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.updateChannelPaymentMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteChannelPaymentMst(ByVal KeyChannelPaymentCode As Integer, _
                                            ByVal KeyChannelCode As Integer, _
                                            ByVal KeyPaymentCode As Integer, _
                                            ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE * FROM チャネル別支払方法マスタ "

            'パラメータ数のカウント
            pc = 0
            maxpc = 0
            If KeyChannelPaymentCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyChannelCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyPaymentCode <> Nothing Then
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
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "チャネル支払コード = " & KeyChannelPaymentCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "チャネルコード = " & keyChannelCode & " "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "支払方法コード = " & KeyPaymentCode & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            'チャネル別支払方法マスタの削除処理実行
            deleteChannelPaymentMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelPaymentDBIO.deleteChannelPaymentMst)", Nothing, Nothing, oExcept.ToString)
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
