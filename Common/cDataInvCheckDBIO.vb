Public Class cDataInvCheckDBIO
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
    Public Function getInvCheck(ByRef parInvCheck() As cStructureLib.sInvCheck, ByVal KeyProductCode As String, ByVal KeyCheckDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        strSelect = "SELECT * FROM 棚卸データ "

        If KeyProductCode <> Nothing Then
            strSelect = strSelect & "WHERE 商品コード = """ & KeyProductCode & """ "
        End If

        If KeyCheckDate <> Nothing Then
            If KeyProductCode <> Nothing Then
                strSelect = strSelect & "AND 棚卸日 = """ & KeyCheckDate & """ "
            Else
                strSelect = strSelect & "WHERE 棚卸日 = """ & KeyCheckDate & """ "
            End If
        End If

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parInvCheck(i)

                'レコードが取得できた時の処理
                '棚卸日
                parInvCheck(i).sInvCheckDate = pDataReader("棚卸日").ToString
                '商品コード
                parInvCheck(i).sProductCode = pDataReader("商品コード").ToString
                '在庫数
                parInvCheck(i).sStockCount = CInt(pDataReader("在庫数"))
                '登録日
                parInvCheck(i).sUpdateDate = pDataReader("登録日").ToString
                '登録日時
                parInvCheck(i).sUpdateTime = pDataReader("登録時間").ToString
                '最終更新日
                parInvCheck(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parInvCheck(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
                getInvCheck = i
            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataInvCheckDBIO.getInvCheck)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：棚卸データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertInvCheck(ByRef parInvCheck() As cStructureLib.sInvCheck, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 棚卸データ " & _
                                "(棚卸日, 商品コード, 在庫数, " & _
                                "登録日, 登録時間, 最終更新日, 最終更新時間) " & _
                                "VALUES (" & _
                                    """" & parInvCheck(0).sInvCheckDate.ToString & """, " & _
                                    """" & parInvCheck(0).sProductCode.ToString & """, " & _
                                    """" & parInvCheck(0).sStockCount.ToString & """, " & _
                                    """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                    """" & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                                    """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                    """" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                                ")"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertInvCheck = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataInvCheckDBIO.insertInvCheck)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：棚卸データの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateInvCheck(ByVal parInvCheck() As cStructureLib.sInvCheck, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strInvCheck As String

        strInvCheck = "UPDATE 棚卸データ SET " & _
                            "在庫数=" & parInvCheck(0).sStockCount & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 商品コード=""" & parInvCheck(0).sProductCode & """ " & _
                            "AND 棚卸日=""" & parInvCheck(0).sInvCheckDate & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strInvCheck

            '棚卸データ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updateInvCheck = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataInvCheckDBIO.updateInvCheck)", Nothing, Nothing, oExcept.ToString)
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
