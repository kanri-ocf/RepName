Public Class cMstPointMemberDBIO
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
    '　機能：ポイント会員マスタから該当レコードを取得する関数
    '----------------------------------------------------------------------
    Public Function getPointMember(ByRef parPointMember() As cStructureLib.sPointMember, _
                              ByVal keyFromPointMemberCode As String, _
                              ByVal keyToPointMemberCode As String, _
                              ByVal keyMemberName As String, _
                              ByVal keyMemberTEL As String, _
                              ByVal keyMemberClass As Integer, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM ポイント会員マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyFromPointMemberCode <> "" Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyToPointMemberCode <> "" Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyMemberName <> "" Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If keyMemberTEL <> "" Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If keyMemberClass = 1 Then
                maxpc = 16
                pc = pc Or maxpc
            End If
            If keyMemberClass = 2 Then
                maxpc = 32
                pc = pc Or maxpc
            End If
            If keyMemberClass = 3 Then
                maxpc = 64
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
                            strSelect = strSelect & "ポイント会員コード >= """ & keyFromPointMemberCode & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "ポイント会員コード <= """ & keyToPointMemberCode & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "ポイント会員名称 Like ""%" & keyMemberName & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "TEL Like ""%" & keyMemberTEL.ToString.Replace("-"c, "%"c) & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(契約開始日 <= Now() AND 契約満了日 >= Now()) "
                            strSelect = strSelect & "AND 退会日 = """" "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(契約開始日 > Now() OR 契約満了日 < Now() "
                            strSelect = strSelect & "OR 退会日 <> """") AND 退会日 <> ""0000/00/00"" "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "契約開始日 = ""0000/00/00"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parPointMember(i)

                'ポイント会員コード
                parPointMember(i).sPointMemberCode = pDataReader("ポイント会員コード").ToString
                'ポイント会員名称
                parPointMember(i).sPointMemberName = pDataReader("ポイント会員名称").ToString
                '郵便番号
                parPointMember(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                parPointMember(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                parPointMember(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                parPointMember(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                parPointMember(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parPointMember(i).sFAX = pDataReader("FAX").ToString
                'メールアドレス
                parPointMember(i).sMailAddress = pDataReader("メールアドレス").ToString
                '性別
                parPointMember(i).sSex = pDataReader("性別").ToString
                '生年月日
                parPointMember(i).sBirthDay = pDataReader("生年月日").ToString
                '年齢
                parPointMember(i).sAge = CInt(pDataReader("年齢"))
                '入会日
                parPointMember(i).sEntryDate = pDataReader("入会日").ToString
                '退会日
                parPointMember(i).sResignDate = pDataReader("退会日").ToString
                '契約開始日
                parPointMember(i).sStartRegistDate = pDataReader("契約開始日").ToString
                '契約満了日
                parPointMember(i).sEndRegistDate = pDataReader("契約満了日").ToString
                '更新回数
                parPointMember(i).sUpdateCount = CInt(pDataReader("更新回数"))
                '備考
                parPointMember(i).sMemo = pDataReader("備考").ToString
                '登録日
                parPointMember(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parPointMember(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parPointMember(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parPointMember(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While
            getPointMember = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.getPointMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：指定会員コードの状態を返す
    '  戻り：0      有効会員
    '      ：-1     無効会員
    '      ：-2     仮登録
    '      ：-3     該当なし
    '----------------------------------------------------------------------
    Public Function getPointMemberStatus(ByVal keyPointMemberCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM ポイント会員マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyPointMemberCode <> "" Then
                maxpc = 1
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
                            strSelect = strSelect & "ポイント会員コード Like ""%" & keyPointMemberCode & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            getPointMemberStatus = -3

            If pDataReader.Read() = True Then

                If pDataReader("契約開始日").ToString = "0000/00/00" Then
                    getPointMemberStatus = -2
                Else
                    If (CDate(pDataReader("契約開始日").ToString) <= Now()) And (CDate(pDataReader("契約満了日").ToString) >= Now()) Then
                        getPointMemberStatus = 0
                    End If
                    If (CDate(pDataReader("契約開始日").ToString) > Now()) Or (CDate(pDataReader("契約満了日").ToString) < Now()) Then
                        getPointMemberStatus = -1
                    End If
                End If
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPoint_MemberDBIO.getPointMemberStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイント会員マスタから新規会員コード取得する関数
    '----------------------------------------------------------------------
    Public Function getPointMemberCode(ByVal keyPointMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String
        Dim i As Long
        Dim j As Integer
        Dim PointMemberCode_H As String

        getPointMemberCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM ポイント会員マスタ WHERE ポイント会員コード Like ""%" & keyPointMemberCode & "%"" " & _
                        "ORDER BY ポイント会員コード"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            getPointMemberCode = ""
            PointMemberCode_H = ""

            'ポイント会員コード
            i = 0
            While pDataReader.Read()
                PointMemberCode_H = pDataReader("ポイント会員コード").ToString.Substring(0, 4)
                j = CLng(pDataReader("ポイント会員コード").ToString.Substring(5, 7))
                If i < j Then
                    getPointMemberCode = PointMemberCode_H & String.Format("{0:00000000}", i)
                    Exit While
                End If
                i = i + 1
            End While
            If getPointMemberCode = "" Then
                getPointMemberCode = PointMemberCode_H & String.Format("{0:00000000}", i)
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.getPointMemberCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function readMaxPointMemberCode(ByVal KeyChannelCode As Integer, _
                                           ByVal KeyYear As String, _
                                           ByRef Tran As System.Data.OleDb.OleDbTransaction) As String
        Dim strSelect As String

        readMaxPointMemberCode = ""

        strSelect = "SELECT ポイント会員コード FROM ポイント会員マスタ " & _
                                            "WHERE ポイント会員コード Like ""997" & KeyChannelCode & KeyYear & "%"" " & _
                                            "ORDER BY ポイント会員コード DESC"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            '商品マスタから該当MAX商品コードのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() = False Then
                readMaxPointMemberCode = Nothing
            Else
                readMaxPointMemberCode = pDataReader("ポイント会員コード").ToString
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.readMaxPointMemberCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイント会員マスタの１レコードを更新するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function insertPointMember(ByVal parPointMember As cStructureLib.sPointMember, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strInsert As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            strInsert = "INSERT INTO ポイント会員マスタ (" & _
                            "ポイント会員コード, " & _
                            "ポイント会員名称, " & _
                            "郵便番号, " & _
                            "住所１, " & _
                            "住所２, " & _
                            "住所３, " & _
                            "TEL, " & _
                            "FAX, " & _
                            "メールアドレス, " & _
                            "性別, " & _
                            "生年月日, " & _
                            "年齢, " & _
                            "入会日, " & _
                            "退会日, " & _
                            "契約開始日, " & _
                            "契約満了日, " & _
                            "更新回数, " & _
                            "備考, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            """" & parPointMember.sPointMemberCode & """, " & _
                            """" & parPointMember.sPointMemberName & """, " & _
                            """" & parPointMember.sPostCode & """, " & _
                            """" & parPointMember.sAddress1 & """, " & _
                            """" & parPointMember.sAddress2 & """, " & _
                            """" & parPointMember.sAddress3 & """, " & _
                            """" & parPointMember.sTEL & """, " & _
                            """" & parPointMember.sFAX & """, " & _
                            """" & parPointMember.sMailAddress & """, " & _
                            """" & parPointMember.sSex & """, " & _
                            """" & parPointMember.sBirthDay & """, " & _
                            parPointMember.sAge & ", " & _
                            """" & parPointMember.sEntryDate & """, " & _
                            """" & parPointMember.sResignDate & """, " & _
                            """" & parPointMember.sStartRegistDate & """, " & _
                            """" & parPointMember.sEndRegistDate & """, " & _
                            parPointMember.sUpdateCount & ", " & _
                            """" & parPointMember.sMemo & """, " & _
                            """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            """" & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                            """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            """" & String.Format("{0:HH:mm:ss}", Now) & """" & _
                        " )"


            'SQL文の設定
            pCommand.CommandText = strInsert

            'ポイント会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            insertPointMember = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.insertPointMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイント会員マスタの１レコードを更新するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updatePointMember(ByVal parPointMember As cStructureLib.sPointMember, ByVal KeyPointMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE ポイント会員マスタ " & _
                                "SET ポイント会員コード=""" & parPointMember.sPointMemberCode.ToString & """, " & _
                                "ポイント会員名称=""" & parPointMember.sPointMemberName.ToString & """, " & _
                                "郵便番号=""" & parPointMember.sPostCode.ToString & """, " & _
                                "住所１=""" & parPointMember.sAddress1.ToString & """, " & _
                                "住所２=""" & parPointMember.sAddress2.ToString & """, " & _
                                "住所３=""" & parPointMember.sAddress3.ToString & """, " & _
                                "TEL=""" & parPointMember.sTEL.ToString & """, " & _
                                "FAX=""" & parPointMember.sFAX.ToString & """, " & _
                                "メールアドレス=""" & parPointMember.sMailAddress.ToString & """, " & _
                                "性別=""" & parPointMember.sSex.ToString & """, " & _
                                "生年月日=""" & parPointMember.sBirthDay.ToString & """, " & _
                                "年齢=" & parPointMember.sAge & ", " & _
                                "入会日=""" & parPointMember.sEntryDate.ToString & """, " & _
                                "退会日=""" & parPointMember.sResignDate.ToString & """, " & _
                                "契約開始日=""" & parPointMember.sStartRegistDate.ToString & """, " & _
                                "契約満了日=""" & parPointMember.sEndRegistDate.ToString & """, " & _
                                "更新回数=" & parPointMember.sUpdateCount & ", " & _
                                "備考=""" & parPointMember.sMemo & """, " & _
                                "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE ポイント会員コード=""" & KeyPointMemberCode & """ "

        Try

            updatePointMember = False

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'ポイント会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updatePointMember = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.updatePointMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイント会員マスタの１レコードを更新するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updatePointMemberEndDate(ByVal KeyPointMemberCode As String, ByVal ValueEndDate As String, ByVal ValueMemo As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE ポイント会員マスタ " & _
                                "SET 退会日=""" & ValueEndDate & """, " & _
                                "備考 = """ & ValueMemo & """, " & _
                                "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE ポイント会員コード=""" & KeyPointMemberCode & """ "

        Try

            updatePointMemberEndDate = False

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'ポイント会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updatePointMemberEndDate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.updatePointMemberEndDate)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイント会員マスタの１レコードを削除するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function deletePointMember(ByVal KeyPointMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "DELETE * FROM ポイント会員マスタ " & _
                            "WHERE ポイント会員マスタ.ポイント会員コード=@KeyPointMemberCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'パラメータの設定

            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@KeyPointMemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@KeyPointMemberCode").Value = KeyPointMemberCode

            'ポイント会員マスタ更新SQL文実行
            deletePointMember = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPointMemberDBIO.deletePointMember)", Nothing, Nothing, oExcept.ToString)
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
