'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cDataPointDBIO
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
    '　機能：ポイントデータから該当予約コード以上のレコードを取得する関数
    '　引数：ParPoint 取得データセット用バッファ
    '        KeyPointCode 予約コード
    '        Mode          1:指定予約コードのデータ取得
    '                      2:指定予約コード以上の入金データ取得
    '                      3:最後の予約レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getPointData(ByRef ParPointData() As cStructureLib.sPoint, _
                              ByVal KeyDate As String, _
                              ByVal KeyPointMemberCode As String, _
                              ByVal KeyFromAddPoint As Long, _
                              ByVal KeyToAddPoint As Long, _
                              ByVal KeyFromUsePoint As Long, _
                              ByVal KeyToUsePoint As Long, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        StrSelect = "SELECT  *  FROM ポイントデータ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyDate <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyPointMemberCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyFromAddPoint <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyToAddPoint <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyFromUsePoint <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyToUsePoint <> Nothing Then
            maxpc = 32
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
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "処理日 Like ""%" & KeyDate & "%"" "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "ポイント会員コード = """ & KeyPointMemberCode & """ "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "付与ポイント数 <= " & KeyFromAddPoint & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "付与ポイント数 <= " & KeyFromAddPoint & " "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "利用ポイント数 <= " & KeyFromUsePoint & " "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "利用ポイント数 <= " & KeyToUsePoint & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        StrSelect = StrSelect & "ORDER BY ポイントデータ.処理日 "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParPointData(CInt(i))

                'レコードが取得できた時の処理

                '処理日
                ParPointData(i).sDate = pDataReader("処理日").ToString
                'ポイント会員コード
                ParPointData(i).sPointMemberCode = pDataReader("ポイント会員コード").ToString
                '付与ポイント数
                If IsDBNull(pDataReader("付与ポイント数")) = True Then
                    ParPointData(i).sAddPoint = 0
                Else
                    ParPointData(i).sAddPoint = CLng(pDataReader("付与ポイント数"))
                End If
                '利用ポイント数
                If IsDBNull(pDataReader("利用ポイント数")) = True Then
                    ParPointData(i).sUsePoint = 0
                Else
                    ParPointData(i).sUsePoint = CLng(pDataReader("利用ポイント数"))
                End If
                '保有ポイント数
                If IsDBNull(pDataReader("保有ポイント数")) = True Then
                    ParPointData(i).sPoint = 0
                Else
                    ParPointData(i).sPoint = CLng(pDataReader("保有ポイント数"))
                End If
                '有効フラグ
                ParPointData(i).sEnableFlg = CLng(pDataReader("有効フラグ"))
                '担当者コード
                ParPointData(i).sStaffCode = pDataReader("担当者コード").ToString
                '登録日
                ParPointData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                ParPointData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParPointData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                ParPointData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getPointData = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataPointDBIO.getPoint)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ポイントデータから該当ポイント会員コードの保有ポイント数を算出
    '　引数：ParPoint 取得データセット用バッファ
    '        KeyPointCode 予約コード
    '        Mode          1:指定予約コードのデータ取得
    '                      2:指定予約コード以上の入金データ取得
    '                      3:最後の予約レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getPoint(ByVal KeyPointMemberCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String

        StrSelect = "SELECT 保有ポイント数 FROM ポイントデータ WHERE ポイント会員コード = """ & KeyPointMemberCode & """ " & _
                    "ORDER BY ポイントデータ.登録日 DESC, ポイントデータ.登録時間 DESC;"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getPoint = 0
            If pDataReader.Read() Then
                getPoint = CLng(pDataReader("保有ポイント数"))
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataPointDBIO.getPointFull)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubPointオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertPoint(ByRef parPointData As cStructureLib.sPoint, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertPoint As String

        Try

            'SQL文の設定
            strInsertPoint = "INSERT INTO ポイントデータ " & _
            "( " & _
                "処理日, " & _
                "ポイント会員コード, " & _
                "付与ポイント数, " & _
                "利用ポイント数, " & _
                "保有ポイント数, " & _
                "有効フラグ, " & _
                "担当者コード, " & _
                "登録日, " & _
                "登録時間, " & _
                "最終更新日, " & _
                "最終更新時間 " & _
            ") VALUES ( " & _
                """" & parPointData.sDate & """, " & _
                """" & parPointData.sPointMemberCode & """, " & _
                parPointData.sAddPoint & ", " & _
                parPointData.sUsePoint & ", " & _
                parPointData.sPoint & ", " & _
                parPointData.sEnableFlg & ", " & _
                """" & parPointData.sStaffCode & """, "

            If parPointData.sCreateDate <> "" Then
                strInsertPoint = strInsertPoint & _
                                """" & parPointData.sCreateDate & """, " & _
                                """" & parPointData.sCreateTime & """, " & _
                                """" & parPointData.sUpdateDate & """, " & _
                                """" & parPointData.sUpdateTime & """ "
            Else
                strInsertPoint = strInsertPoint & _
                                """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                """" & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                                """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                """" & String.Format("{0:HH:mm:ss}", Now) & """ "

            End If

            strInsertPoint = strInsertPoint & ") "

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertPoint

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            insertPoint = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataPointDBIO.insertPoint)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubPointオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updatePointEnable(ByVal KeyDate As String, ByVal KeyPointMemberCode As String, ByVal ValueEnableFlg As Boolean, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim i As Integer
        Dim RecordCount As Integer
        Dim StrUpdate As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim flg As Boolean

        'SQL文の設定
        If ValueEnableFlg = Nothing Then
            flg = False
        Else
            flg = ValueEnableFlg
        End If
        StrUpdate = "UPDATE ポイントデータ SET " & _
                            "有効フラグ=" & flg & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ "

        Try

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If KeyDate <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyPointMemberCode <> Nothing Then
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
                                StrUpdate = StrUpdate & "AND "
                            Else
                                StrUpdate = StrUpdate & "WHERE "
                            End If
                            StrUpdate = StrUpdate & "処理日 Like ""%" & KeyDate & "%"" "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                StrUpdate = StrUpdate & "AND "
                            Else
                                StrUpdate = StrUpdate & "WHERE "
                            End If
                            StrUpdate = StrUpdate & "ポイント会員コード = """ & KeyPointMemberCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            updatePointEnable = False

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = StrUpdate

            'ポイント会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updatePointEnable = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataPointDBIO.updatePointEnable)", Nothing, Nothing, oExcept.ToString)
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
