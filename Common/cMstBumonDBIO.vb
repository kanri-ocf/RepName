Public Class cMstBumonDBIO
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
    Public Function BumonExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 部門マスタ WHERE 部門コード = @BumonCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = KeyString

            BumonExist = CInt(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.BumonMstExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getBumonMst(ByRef parBumon() As cStructureLib.sBumon, _
                                ByVal keyBumonCode As String, _
                                ByVal KeyBumonName As String, _
                                ByVal KeyBumonClass As Integer, _
                                ByVal KeyReservFlg As Boolean, _
                                ByVal KeyReservPeace As String, _
                                ByVal KeyTaxClassCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM 部門マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyBumonCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyBumonName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyBumonClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeyReservFlg <> Nothing Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If KeyReservPeace <> Nothing Then
                maxpc = 16
                pc = pc Or maxpc
            End If
            If KeyTaxClassCode <> Nothing Then
                maxpc = 32
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
                            strSelect = strSelect & "部門マスタ.部門コード Like ""%" & keyBumonCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.部門名称 Like ""%" & KeyBumonName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.部門種別 =" & KeyBumonClass & " "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.予約フラグ =" & KeyReservFlg & " "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.予約単位 =""" & KeyReservPeace & """ "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.税区分コード =" & KeyTaxClassCode & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 部門マスタ.部門コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parBumon(i)

                'レコードが取得できた時の処理
                '部門コード
                parBumon(i).sBumonCode = CStr(pDataReader("部門コード"))
                '部門コード
                parBumon(i).sBumonName = CStr(pDataReader("部門名称"))
                '部門名称
                parBumon(i).sBumonShortName = CStr(pDataReader("部門略称"))
                '部門種別
                parBumon(i).sBumonClass = CInt(pDataReader("部門種別"))
                '予約フラグ
                parBumon(i).sReservFlg = CBool(pDataReader("予約フラグ"))
                '予約単位
                parBumon(i).sReservPeace = pDataReader("予約単位").ToString
                '税区分コード
                If IsDBNull(pDataReader("税区分コード")) = True Then
                    parBumon(i).sTaxClassCode = 0
                Else
                    parBumon(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                End If
                '会員割引率
                'parBumon(i).sMemberRate = CInt(pDataReader("会員割引率"))

                i = i + 1

            End While

            getBumonMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.getBumonMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getBumonFull(ByRef parBumon() As cStructureLib.sViewBumonFull, _
                                ByVal keyBumonCode As String, _
                                ByVal KeyBumonName As String, _
                                ByVal KeyBumonClass As Integer, _
                                ByVal KeyReservFlg As Boolean, _
                                ByVal KeyReservPeace As String, _
                                ByVal KeyTaxClassCode As Integer, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT " & _
                            "部門マスタ.部門コード AS 部門コード, " & _
                           "部門マスタ.部門名称 AS 部門名称, " & _
                          "部門マスタ.部門種別 AS 部門種別, " & _
                          "部門マスタ.予約フラグ AS 予約フラグ, " & _
                          "部門マスタ.予約単位 AS 予約単位, " & _
                          "部門マスタ.税区分コード AS 税区分コード, " & _
                          "税区分マスタ.税区分名称 AS 税区分名称 " & _
                        "FROM " & _
                            "部門マスタ LEFT JOIN 税区分マスタ ON 部門マスタ.税区分コード = 税区分マスタ.税区分コード "

            'パラメータ数のカウント
            pc = 0
            If keyBumonCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyBumonName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyBumonClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeyReservFlg <> Nothing Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If KeyReservPeace <> Nothing Then
                maxpc = 16
                pc = pc Or maxpc
            End If
            If KeyTaxClassCode <> Nothing Then
                maxpc = 32
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
                            strSelect = strSelect & "部門コード Like ""%" & keyBumonCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門名称 Like ""%" & KeyBumonName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門種別 =" & KeyBumonClass & " "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "予約フラグ =" & KeyReservFlg & " "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "予約単位 =""" & KeyReservPeace & """ "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "税区分コード =" & KeyTaxClassCode & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 部門コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parBumon(i)

                'レコードが取得できた時の処理
                '部門コード
                parBumon(i).sBumonCode = pDataReader("部門コード").ToString
                '部門名称
                parBumon(i).sBumonName = pDataReader("部門名称").ToString
                '部門種別
                parBumon(i).sBumonClass = pDataReader("部門種別").ToString
                '予約フラグ
                parBumon(i).sReservFlg = CBool(pDataReader("予約フラグ"))
                '予約単位
                parBumon(i).sReservPeace = pDataReader("予約単位").ToString
                '税区分コード
                If IsDBNull(pDataReader("税区分コード")) = True Then
                    parBumon(i).sTaxClassCode = 0
                Else
                    parBumon(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                End If
                '税区分名称
                parBumon(i).sTaxClassName = pDataReader("税区分名称").ToString

                i = i + 1

            End While

            getBumonFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.getBumonFull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getBumonShortName(ByVal keyBumonCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        getBumonShortName = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM 部門マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyBumonCode <> Nothing Then
                maxpc = 1
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
                            strSelect = strSelect & "部門マスタ.部門コード = """ & keyBumonCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 部門マスタ.部門コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                '部門名称
                getBumonShortName = CStr(pDataReader("部門略称"))

                i = i + 1

            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.getBumonShortName)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getNewBumonCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String

        getNewBumonCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT 部門コード FROM 部門マスタ WHERE Len([部門コード]) < 3 ORDER BY 部門コード DESC"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            '最大部門コード
            getNewBumonCode = CInt(pDataReader("部門コード").ToString) + 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.getNewBumonCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：部門マスタに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertBumonMst(ByVal parBumon As cStructureLib.sBumon, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO 部門マスタ " &
        "( 部門コード, 部門名称, 部門略称, 部門種別, 予約フラグ, 予約単位, 税区分コード, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " &
        "VALUES (@BumonCode, @BumonName, @BumonShortName, @BumonClass, @ReservFlg, @ReservPeace, @TaxClassName, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parBumon.sBumonCode.ToString

            '部門名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@BumonName").Value = parBumon.sBumonName.ToString

            '部門略称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonShortName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@BumonShortName").Value = parBumon.sBumonShortName.ToString

            '部門種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@BumonClass").Value = parBumon.sBumonClass

            '予約フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReservFlg", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@ReservFlg").Value = parBumon.sReservFlg

            '予約単位
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReservPeace", OleDb.OleDbType.Char))
            pCommand.Parameters("@ReservPeace").Value = parBumon.sReservPeace

            '税区分コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxClassName", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@TaxClassName").Value = parBumon.sTaxClassCode

            ''会員割引率
            'pCommand.Parameters.Add _
            '(New OleDb.OleDbParameter("@Rate", OleDb.OleDbType.Numeric, 3))
            'pCommand.Parameters("@Rate").Value = parBumon.sMemberRate

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parBumon.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parBumon.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parBumon.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parBumon.sCreateTime.ToString
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

            insertBumonMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.insertBumonMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteBumonMst(ByVal keyBumonCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 部門マスタ WHERE 部門コード=""" & keyBumonCode & """ "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '商品マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteBumonMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.deleteBumonMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：部門マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateBumonMst(ByRef parBumon As cStructureLib.sBumon, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 部門マスタ SET " &
                            "部門名称=""" & parBumon.sBumonName & """, " &
                            "部門略称=""" & parBumon.sBumonShortName & """, " &
                            "部門種別=" & parBumon.sBumonClass & ", " &
                            "予約フラグ=" & parBumon.sReservFlg & ", " &
                            "予約単位=""" & parBumon.sReservPeace & """, " &
                            "税区分コード=" & parBumon.sTaxClassCode & ", " &
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " &
                            "WHERE 部門コード=""" & parBumon.sBumonCode & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateBumonMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBumonDBIO.updateBumonMst)", Nothing, Nothing, oExcept.ToString)
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
