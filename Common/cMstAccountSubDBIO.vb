Public Class cMstAccountSubDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub

    ''----------------------------------------------------------------------
    ''　機能：仕入先マスタから１レコードを取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getSubAccount(ByRef parSubAccount() As cStructureLib.sSubAccount, _
                                  ByVal KeyAccountCode As Integer, _
                                    ByVal KeySubAccountCode As Integer, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim StrSelect As String

        If KeySubAccountCode = -1 Then
            StrSelect = "SELECT * FROM  勘定科目補助マスタ " & _
                        "WHERE 勘定科目コード=@AccountCode"
        Else
            StrSelect = "SELECT * FROM 勘定科目補助マスタ " & _
                        "WHERE 勘定科目コード=@AccountCode " & _
                        "AND 補助勘定科目コード=@SubAccountCode"
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '勘定科目コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@AccountCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@AccountCode").Value = KeyAccountCode

            '補助勘定科目コード
            If KeySubAccountCode > 0 Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SubAccountCode", OleDb.OleDbType.Numeric, 10))
                pCommand.Parameters("@SubAccountCode").Value = KeySubAccountCode
            End If

            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSubAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parSubAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '補助勘定科目コード
                parSubAccount(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                parSubAccount(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                '登録日
                parSubAccount(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parSubAccount(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSubAccount(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parSubAccount(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getSubAccount = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountSubDBIO.getSubAccount)", Nothing, Nothing, oExcept.ToString)
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


    ''----------------------------------------------------------------------
    ''　機能：仕入先名称から取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getSubAccountCode(ByRef parSubAccount() As cStructureLib.sSubAccount, _
                                    ByVal KeyAccountName As String, _
                                    ByVal KeySubAccountName As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim StrSelect As String


        If KeySubAccountName = "" Then
            StrSelect = "SELECT * FROM  勘定科目補助マスタ" & _
                        "WHERE 勘定科目名称=@AccountName"
        Else
            StrSelect = "SELECT 勘定科目マスタ.勘定科目コード as 勘定科目コード, " & _
                        "勘定科目補助マスタ.補助勘定科目コード as 補助勘定科目コード, " & _
                        "勘定科目補助マスタ.補助勘定科目名称 as 補助勘定科目名称, " & _
                        "勘定科目補助マスタ.登録日 as 登録日, " & _
                        "勘定科目補助マスタ.登録時間 as 登録時間, " & _
                        "勘定科目補助マスタ.最終更新日 as 最終更新日, " & _
                        "勘定科目補助マスタ.最終更新時間 as 最終更新時間 " & _
                        "FROM 勘定科目マスタ LEFT JOIN 勘定科目補助マスタ " & _
                        "ON 勘定科目マスタ.勘定科目ｺｰﾄﾞ=勘定科目補助マスタ.勘定科目コード " & _
                        "WHERE 勘定科目名称=@AccountName " & _
                        "AND 補助勘定科目名称=@SubAccountName"
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '勘定科目コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@AccountName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@AccountName").Value = KeyAccountName

            '補助勘定科目コード
            If KeySubAccountName <> "" Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SubAccountName", OleDb.OleDbType.Char, 30))
                pCommand.Parameters("@SubAccountName").Value = KeySubAccountName
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSubAccount(CInt(i))

                'レコードが取得できた時の処理
                '勘定科目コード
                parSubAccount(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '補助勘定科目コード
                parSubAccount(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                parSubAccount(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                '登録日
                parSubAccount(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parSubAccount(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSubAccount(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parSubAccount(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While
            getSubAccountCode = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstAccountSubDBIO.getSubAccountCode)", Nothing, Nothing, oExcept.ToString)
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
