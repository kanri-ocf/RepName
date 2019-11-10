Public Class cMstSoftDBIO

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
    '　機能：プロパティの取引コードのレコードが取引テーブルに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function SoftExist(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelectTrn As String = _
        "SELECT COUNT(*) FROM 連携ソフトマスタ"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            'テーブルから該当取引コードのレコード数読込 
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSoftDBIO.SoftExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：連携ソフトテーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSoftMst(ByRef parSoft() As cStructureLib.sSoft, _
                               ByVal KeySoftCode As Integer, _
                               ByVal KeySoftName As String, _
                               ByVal KeySoftVersion As String, _
                               ByVal KeySoftClass As Integer, _
                               ByVal KeyCorpCode As Integer, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim strSelect As String

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            strSelect = "SELECT " & _
                           "連携ソフトマスタ.ソフトコード, " & _
                           "連携ソフトマスタ.ソフト名称, " & _
                           "連携ソフトマスタ.バージョン, " & _
                           "連携ソフトマスタ.ソフト種別, " & _
                           "連携ソフトマスタ.業者コード, " & _
                           "連携ソフトマスタ.登録日, " & _
                           "連携ソフトマスタ.登録時間, " & _
                           "連携ソフトマスタ.最終更新日, " & _
                           "連携ソフトマスタ.最終更新時間 " & _
                        "FROM 連携ソフトマスタ "

            'パラメータ数のカウント
            pc = 0
            maxpc = 0
            If KeySoftCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeySoftName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeySoftVersion <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeySoftClass <> Nothing Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If KeyCorpCode <> Nothing Then
                maxpc = 16
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
                            strSelect = strSelect & "ソフトコード = " & KeySoftCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "ソフト名称 = """ & KeySoftName & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "バージョン =""" & KeySoftVersion & """ "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "ソフト種別 =" & KeySoftClass & " "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "業者コード =" & KeyCorpCode & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strSelect

            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSoft(i)

                'ソフトコード
                If IsDBNull(pDataReader("ソフトコード")) = True Then
                    parSoft(i).sSoftCode = 0
                Else
                    parSoft(i).sSoftCode = CInt(pDataReader("ソフトコード"))
                End If

                'ソフト名称
                parSoft(i).sSoftName = pDataReader("ソフト名称").ToString
                'バージョン
                parSoft(i).sVersion = pDataReader("バージョン").ToString
                'ソフト種別
                If IsDBNull(pDataReader("ソフト種別")) = True Then
                    parSoft(i).sSoftClass = 0
                Else
                    parSoft(i).sSoftClass = CInt(pDataReader("ソフト種別"))
                End If
                '業者コード
                If IsDBNull(pDataReader("業者コード")) = True Then
                    parSoft(i).sSoftClass = 0
                Else
                    parSoft(i).sSoftClass = CInt(pDataReader("業者コード"))
                End If
                '登録日
                parSoft(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSoft(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSoft(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSoft(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getSoftMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSoftDBIO.getSoftMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：連携ソフトマスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSoftMst(ByRef parSoft() As cStructureLib.sSoft, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "INSERT INTO 予約データ (" & _
                       "ソフトコード, " & _
                       "ソフト名称, " & _
                       "バージョン, " & _
                       "ソフト種別, " & _
                       "業者コード, " & _
                       "登録日, " & _
                       "登録時間, " & _
                       "最終更新日, " & _
                       "最終更新時間 " & _
                    ") VALUES ( " & _
                       parSoft(0).sSoftCode & ", " & _
                       """" & parSoft(0).sSoftName & """, " & _
                       """" & parSoft(0).sVersion & """, " & _
                       parSoft(0).sSoftClass & ", " & _
                       parSoft(0).sCorpCode & ", " & _
                        "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss""), " & _
                        "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss"") " & _
                    ") "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            insertSoftMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSoftDBIO.insertSoftMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：連携ソフトマスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateSoftMst(ByRef parSoft() As cStructureLib.sSoft, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 連携ソフトマスタ SET " & _
                        "ソフト名称 = """ & parSoft(0).sSoftName & """, " & _
                        "バージョン = """ & parSoft(0).sVersion & """, " & _
                        "ソフト種別 = " & parSoft(0).sSoftClass & ", " & _
                        "業者コード = " & parSoft(0).sCorpCode & ", " & _
                    "WHERE 連携ソフトマスタ.ソフトコード=" & parSoft(0).sSoftCode
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateSoftMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSoftDBIO.updateSoftMst)", Nothing, Nothing, oExcept.ToString)
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
