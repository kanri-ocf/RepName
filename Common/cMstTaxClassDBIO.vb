Public Class cMstTaxClassDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub
    Public Function getTaxClass(ByRef parTaxClass() As cStructureLib.sTaxClass, _
                                ByVal KeyTaxClassCode As Integer, _
                                ByVal KeyTaxClassName As String, _
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

            strSelect = "SELECT * FROM 税区分マスタ "

            'パラメータ数のカウント
            pc = 0
            If KeyTaxClassCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyTaxClassName <> Nothing Then
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
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "税区分コード = " & KeyTaxClassCode & " "
                            scnt = scnt + 1
                        Case 2
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

            strSelect = strSelect & "ORDER BY 税区分マスタ.税区分コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parTaxClass(i)

                'レコードが取得できた時の処理
                '税区分コード
                parTaxClass(i).sTaxClassCode = CStr(pDataReader("税区分コード"))
                '税区分名称
                parTaxClass(i).sTaxClassName = CStr(pDataReader("税区分名称"))

                i = i + 1

            End While

            getTaxClass = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstTaxClassDBIO.getTaxClass)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getTaxClassFull(ByRef parTaxClass() As cStructureLib.sViewTaxClassFull, _
                                ByVal KeyTaxClassCode As Integer, _
                                ByVal KeyTaxClassName As String, _
                                ByVal keyBusinessClass As String, _
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
                            "税区分マスタ.税区分コード AS 税区分コード, " & _
                            "税区分マスタ.税区分名称 AS 税区分名称, " & _
                            "業種マスタ.業種 AS 業種 " & _
                        "FROM 業種マスタ LEFT JOIN 税区分マスタ ON 業種マスタ.税区分コード = 税区分マスタ.税区分コード "

            'パラメータ数のカウント
            pc = 0
            If KeyTaxClassCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyTaxClassName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyBusinessClass <> Nothing Then
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
                            strSelect = strSelect & "税区分コード = %" & KeyTaxClassCode & " "
                            scnt = scnt + 1
                            i = i * 2
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "税区分名称 Like ""%" & KeyTaxClassName & "%"" "
                            scnt = scnt + 1
                            i = i * 2
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "業種 Like ""%" & keyBusinessClass & "%"" "
                            scnt = scnt + 1
                    End Select
                End While
            End If

            strSelect = strSelect & "ORDER BY 税区分マスタ.税区分コード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parTaxClass(i)

                'レコードが取得できた時の処理
                '税区分コード
                parTaxClass(i).sTaxClassCode = CStr(pDataReader("税区分コード"))
                '税区分名称
                parTaxClass(i).sTaxClassName = CStr(pDataReader("税区分名称"))
                '業種
                parTaxClass(i).sBusinessClass = CStr(pDataReader("業種"))

                i = i + 1

            End While

            getTaxClassFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstTaxClassDBIO.getTaxClassFull)", Nothing, Nothing, oExcept.ToString)
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
