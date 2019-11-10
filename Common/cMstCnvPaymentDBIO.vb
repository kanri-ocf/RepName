Public Class cMstCnvMstPaymentDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    '----------------------------------------------------------------------
    '　機能：支払方法名称変換マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getCnvPayment(ByRef parCnvPayment() As sCnvPayment, _
                                  ByVal KeyChannelCode As Integer, _
                                  ByVal KeyPaymentCode As Integer, _
                                  ByVal KeyNetPaymentName As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 支払方法名称変換マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyChannelCode <> Nothing Then
            pc = pc Or 1
        End If
        If KeyPaymentCode <> "" Then
            pc = pc Or 2
        End If
        If KeyNetPaymentName <> "" Then
            pc = pc Or 4
        End If

        'パラメータ指定がある場合
        If 31 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 4
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法コード= " & KeyPaymentCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法名称= """ & KeyNetPaymentName & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            'SQL文の設定
            pCommand.CommandText = strSelect


            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parCnvPayment(i)

                'レコードが取得できた時の処理
                'チャネルコード
                parCnvPayment(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                '支払方法コード
                parCnvPayment(i).sPaymentCode = CInt(pDataReader("支払方法コード"))

                '支払方法名称
                parCnvPayment(i).sPaymentName = pDataReader("支払方法名称").ToString

                '登録日
                parCnvPayment(i).sCreateDate = pDataReader("登録日").ToString

                '登録時間
                parCnvPayment(i).sCreateTime = pDataReader("登録時間").ToString

                '最終更新日付
                parCnvPayment(i).sUpdateDate = pDataReader("最終更新日付").ToString

                '最終更新時間

                i = i + 1

            End While

            getCnvPayment = i
        Catch oExcept As Exception
            getCnvPayment = -1
            Throw New cException(oExcept.ToString)

        Finally
        End Try

    End Function
End Class
