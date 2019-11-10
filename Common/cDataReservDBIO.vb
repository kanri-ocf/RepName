'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cDataReservDBIO
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
    '　機能：予約データから該当予約コード以上のレコードを取得する関数
    '　引数：ParReserv 取得データセット用バッファ
    '        KeyReservCode 予約コード
    '        Mode          1:指定予約コードのデータ取得
    '                      2:指定予約コード以上の入金データ取得
    '                      3:最後の予約レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getReserv(ByRef ParReservData() As cStructureLib.sReserv, _
                              ByVal KeyReservCode As Long, _
                              ByVal KeyFromReservDate As String, _
                              ByVal KeyToReservDate As String, _
                              ByVal KeyBumonCode As String, _
                              ByVal KeyRoomCode As Integer, _
                              ByVal KeyStaffCode As String, _
                              ByVal KeyReservHour As Integer, _
                              ByVal KeyReservMinute As Integer, _
                              ByVal KeyChannelCode As Integer, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        StrSelect = "SELECT " & _
                       "予約データ.予約コード, " & _
                       "予約データ.予約日FROM, " & _
                       "予約データ.予約日TO, " & _
                       "予約データ.チャネルコード, " & _
                       "予約データ.ルームコード, " & _
                       "予約データ.開始時, " & _
                       "予約データ.開始分, " & _
                       "予約データ.終了時, " & _
                       "予約データ.終了分, " & _
                       "予約データ.サービス部門コード, " & _
                       "予約データ.サービス担当者コード, " & _
                       "予約データ.会員コード, " & _
                       "予約データ.名称, " & _
                       "予約データ.郵便番号, " & _
                       "予約データ.住所１, " & _
                       "予約データ.住所２, " & _
                       "予約データ.住所３, " & _
                       "予約データ.TEL, " & _
                       "予約データ.FAX, " & _
                       "予約データ.メールアドレス, " & _
                       "予約データ.性別, " & _
                       "予約データ.生年月日, " & _
                       "予約データ.年齢, " & _
                       "予約データ.備考1, " & _
                       "予約データ.備考2, " & _
                       "予約データ.備考3, " & _
                       "予約データ.予約担当者コード, " & _
                       "予約データ.登録日, " & _
                       "予約データ.登録時間, " & _
                       "予約データ.最終更新日, " & _
                       "予約データ.最終更新時間 " & _
                    "FROM 予約データ "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyReservCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyFromReservDate <> Nothing And KeyToReservDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyFromReservDate <> Nothing And KeyToReservDate = Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyFromReservDate = Nothing And KeyToReservDate <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyBumonCode <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyRoomCode <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyStaffCode <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If
        If KeyReservHour <> Nothing Then
            maxpc = 128
            pc = pc Or maxpc
        End If
        If KeyReservMinute <> Nothing Then
            maxpc = 256
            pc = pc Or maxpc
        End If
        If KeyChannelCode <> Nothing Then
            maxpc = 512
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
                        StrSelect = StrSelect & "予約コード =" & KeyReservCode & " "
                        scnt = scnt + 1

                    Case 2
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約日FROM <= """ & KeyFromReservDate & """ AND 予約日TO >= """ & KeyToReservDate & """ "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約日FROM Like ""%" & KeyFromReservDate & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約日TOM Like ""%" & KeyToReservDate & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "サービス部門コード = """ & KeyBumonCode & """ "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "ルームコード = " & KeyRoomCode & " "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "サービス担当者コード = """ & KeyStaffCode & """ "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "開始時 <= " & KeyReservHour & " AND 終了時 >= " & KeyReservHour & " "
                        scnt = scnt + 1
                    Case 256
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "開始分 <= " & KeyReservMinute & " AND 終了分 <= " & KeyReservMinute & " "
                        scnt = scnt + 1
                    Case 512
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.チャネルコード = " & KeyChannelCode & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        StrSelect = StrSelect & "ORDER BY 予約データ.予約日FROM, 予約データ.ルームコード, 予約データ.サービス担当者コード "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParReservData(CInt(i))

                'レコードが取得できた時の処理
                '予約コード
                ParReservData(i).sReserveCode = CLng(pDataReader("予約コード"))
                '予約日FROM
                ParReservData(i).sFromReserveDate = pDataReader("予約日FROM").ToString
                '予約日TO
                ParReservData(i).sToReserveDate = pDataReader("予約日TO").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    ParReservData(i).sChannelCode = 0
                Else
                    ParReservData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'ルームコード
                If IsDBNull(pDataReader("ルームコード")) = True Then
                    ParReservData(i).sRoomCode = 0
                Else
                    ParReservData(i).sRoomCode = CInt(pDataReader("ルームコード"))
                End If
                '開始時
                If IsDBNull(pDataReader("開始時")) = True Then
                    ParReservData(i).sFromHour = 0
                Else
                    ParReservData(i).sFromHour = CInt(pDataReader("開始時"))
                End If
                '開始分
                If IsDBNull(pDataReader("開始分")) = True Then
                    ParReservData(i).sFromMinute = 0
                Else
                    ParReservData(i).sFromMinute = CInt(pDataReader("開始分"))
                End If
                '終了時
                If IsDBNull(pDataReader("終了時")) = True Then
                    ParReservData(i).sToHour = 0
                Else
                    ParReservData(i).sToHour = CInt(pDataReader("終了時"))
                End If
                '終了分
                If IsDBNull(pDataReader("終了分")) = True Then
                    ParReservData(i).sToMinute = 0
                Else
                    ParReservData(i).sToMinute = CInt(pDataReader("終了分"))
                End If
                'サービス部門コード
                ParReservData(i).sBumonCode = pDataReader("サービス部門コード").ToString
                'サービス担当者コード
                ParReservData(i).sServiceStaffCode = pDataReader("サービス担当者コード").ToString
                '会員コード
                ParReservData(i).sMemberCode = pDataReader("会員コード").ToString
                '名称
                ParReservData(i).sName = pDataReader("名称").ToString
                '郵便番号
                ParReservData(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                ParReservData(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                ParReservData(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                ParReservData(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                ParReservData(i).sTEL = pDataReader("TEL").ToString
                'FAX
                ParReservData(i).sFAX = pDataReader("FAX").ToString
                'メールアドレス
                ParReservData(i).sMailAddress = pDataReader("メールアドレス").ToString
                '性別
                ParReservData(i).sSex = pDataReader("性別").ToString
                '生年月日
                ParReservData(i).sBirthDay = pDataReader("生年月日").ToString
                '年齢
                If IsDBNull(pDataReader("年齢")) = True Then
                    ParReservData(i).sGeneration = 0
                Else
                    ParReservData(i).sGeneration = CInt(pDataReader("年齢"))
                End If
                '備考1
                ParReservData(i).sMemo1 = pDataReader("備考1").ToString
                '備考2
                ParReservData(i).sMemo2 = pDataReader("備考2").ToString
                '備考3
                ParReservData(i).sMemo3 = pDataReader("備考3").ToString
                '予約担当者コード
                ParReservData(i).sBirthDay = pDataReader("予約担当者コード").ToString
                '登録日
                ParReservData(i).sCreateDate = pDataReader("登録日").ToString
                '登録日
                ParReservData(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                ParReservData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParReservData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                ParReservData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getReserv = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.getReserv)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：予約データから該当予約コード以上のレコードを取得する関数
    '　引数：ParReserv 取得データセット用バッファ
    '        KeyReservCode 予約コード
    '        Mode          1:指定予約コードのデータ取得
    '                      2:指定予約コード以上の入金データ取得
    '                      3:最後の予約レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getReservFull(ByRef ParReservData() As cStructureLib.sViewReservFull, _
                              ByVal KeyReservCode As Long, _
                              ByVal KeyFromReservDate As String, _
                              ByVal KeyReservDate As String, _
                              ByVal KeyReservHour As Integer, _
                              ByVal KeyReservMinute As Integer, _
                              ByVal KeyChannelCode As Integer, _
                              ByVal KeyBumonCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        StrSelect = "SELECT " & _
                       "予約データ.予約コード AS 予約コード, " & _
                       "予約データ.予約日FROM AS 予約日FROM, " & _
                       "予約データ.予約日TO AS 予約日TO, " & _
                       "予約データ.チャネルコード AS チャネルコード, " & _
                       "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                       "予約データ.ルームコード AS ルームコード, " & _
                       "ルームマスタ.ルーム名称 AS ルーム名称, " & _
                       "予約データ.開始時 AS 開始時, " & _
                       "予約データ.開始分 AS 開始分, " & _
                       "予約データ.終了時 AS 終了時, " & _
                       "予約データ.終了分 AS 終了分, " & _
                       "予約データ.サービス部門コード AS サービス部門コード, " & _
                       "部門マスタ.部門名称 AS サービス商品名称 , " & _
                       "予約データ.サービス担当者コード AS サービス担当者コード, " & _
                       "スタッフマスタ.スタッフ名称 AS サービス担当者名称, " & _
                       "予約データ.会員コード AS 会員コード, " & _
                       "予約データ.名称 AS 名称, " & _
                       "予約データ.郵便番号 AS 郵便番号, " & _
                       "予約データ.住所１ AS 住所１, " & _
                       "予約データ.住所２ AS 住所２, " & _
                       "予約データ.住所３ AS 住所３, " & _
                       "予約データ.TEL AS TEL, " & _
                       "予約データ.FAX AS FAX, " & _
                       "予約データ.メールアドレス AS メールアドレス, " & _
                       "予約データ.性別 AS 性別, " & _
                       "予約データ.生年月日 AS 生年月日, " & _
                       "予約データ.年齢 AS 年齢, " & _
                       "予約データ.備考1 AS 備考1, " & _
                       "予約データ.備考2 AS 備考2, " & _
                       "予約データ.備考3 AS 備考3 " & _
                    "FROM 部門マスタ " & _
                        "RIGHT JOIN (((チャネルマスタ RIGHT JOIN 予約データ " & _
                        "ON チャネルマスタ.チャネルコード = 予約データ.チャネルコード) " & _
                        "LEFT JOIN ルームマスタ " & _
                        "ON 予約データ.ルームコード = ルームマスタ.ルームコード) " & _
                        "LEFT JOIN スタッフマスタ " & _
                        "ON 予約データ.サービス担当者コード = スタッフマスタ.スタッフコード) " & _
                        "ON 部門マスタ.部門コード = 予約データ.サービス部門コード "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyReservCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyFromReservDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyReservDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyReservHour <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyReservMinute <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyChannelCode <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyBumonCode <> Nothing Then
            maxpc = 64
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
                        StrSelect = StrSelect & "予約データ.予約コード =" & KeyReservCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.予約日FROM Like ""%" & KeyFromReservDate & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "(予約データ.予約日FROM Like ""%" & KeyReservDate & "%"" "
                        StrSelect = StrSelect & " OR 予約データ.予約日TO Like ""%" & KeyReservDate & "%"") "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.開始時 <= " & KeyReservHour & " AND 予約データ.終了時 >= " & KeyReservHour & " "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.開始分 <= " & KeyReservMinute & " AND 予約データ.終了分 >= " & KeyReservHour & " "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.チャネルコード = " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            StrSelect = StrSelect & "AND "
                        Else
                            StrSelect = StrSelect & "WHERE "
                        End If
                        StrSelect = StrSelect & "予約データ.サービス部門コード = """ & KeyBumonCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        StrSelect = StrSelect & "ORDER BY 予約データ.予約日FROM, 予約データ.ルームコード, 予約データ.サービス担当者コード "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParReservData(CInt(i))

                'レコードが取得できた時の処理
                '予約コード
                ParReservData(i).sReserveCode = CLng(pDataReader("予約コード"))
                '予約日FROM
                ParReservData(i).sFromReserveDate = pDataReader("予約日FROM").ToString
                '予約日TO
                ParReservData(i).sToReserveDate = pDataReader("予約日TO").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    ParReservData(i).sChannelCode = 0
                    ParReservData(i).sChannelName = ""
                Else
                    ParReservData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                    ParReservData(i).sChannelName = pDataReader("チャネル名称").ToString
                End If
                'ルームコード
                If IsDBNull(pDataReader("ルームコード")) = True Then
                    ParReservData(i).sRoomCode = 0
                    ParReservData(i).sRoomName = 0
                Else
                    ParReservData(i).sRoomCode = CInt(pDataReader("ルームコード"))
                    ParReservData(i).sRoomName = pDataReader("ルーム名称").ToString
                End If
                '開始時
                If IsDBNull(pDataReader("開始時")) = True Then
                    ParReservData(i).sFromHour = 0
                Else
                    ParReservData(i).sFromHour = CInt(pDataReader("開始時"))
                End If
                '開始分
                If IsDBNull(pDataReader("開始分")) = True Then
                    ParReservData(i).sFromMinute = 0
                Else
                    ParReservData(i).sFromMinute = CInt(pDataReader("開始分"))
                End If
                '終了時
                If IsDBNull(pDataReader("終了時")) = True Then
                    ParReservData(i).sToHour = 0
                Else
                    ParReservData(i).sToHour = CInt(pDataReader("終了時"))
                End If
                '終了分
                If IsDBNull(pDataReader("終了分")) = True Then
                    ParReservData(i).sToMinute = 0
                Else
                    ParReservData(i).sToMinute = CInt(pDataReader("終了分"))
                End If
                'サービス部門コード
                ParReservData(i).sBumonCode = pDataReader("サービス部門コード").ToString
                ParReservData(i).sBumonName = pDataReader("サービス商品名称").ToString
                'サービス担当者コード
                ParReservData(i).sServiceStaffCode = pDataReader("サービス担当者コード").ToString
                ParReservData(i).sServiceStaffName = pDataReader("サービス担当者名称").ToString
                '会員コード
                ParReservData(i).sMemberCode = pDataReader("会員コード").ToString
                '名称
                ParReservData(i).sName = pDataReader("名称").ToString
                '郵便番号
                ParReservData(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                ParReservData(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                ParReservData(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                ParReservData(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                ParReservData(i).sTEL = pDataReader("TEL").ToString
                'FAX
                ParReservData(i).sFAX = pDataReader("FAX").ToString
                'メールアドレス
                ParReservData(i).sMailAddress = pDataReader("メールアドレス").ToString
                '性別
                ParReservData(i).sSex = pDataReader("性別").ToString
                '生年月日
                ParReservData(i).sBirthDay = pDataReader("生年月日").ToString
                '年齢
                If IsDBNull(pDataReader("年齢")) = True Then
                    ParReservData(i).sGeneration = 0
                Else
                    ParReservData(i).sGeneration = CInt(pDataReader("年齢"))
                End If
                '備考1
                ParReservData(i).sMemo1 = pDataReader("備考1").ToString
                '備考2
                ParReservData(i).sMemo2 = pDataReader("備考2").ToString
                '備考3
                ParReservData(i).sMemo3 = pDataReader("備考3").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getReservFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.getReservFull)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in cSubReservオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertReserv(ByRef parReserv As cStructureLib.sReserv, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertReserv As String

        Try

            'SQL文の設定
            strInsertReserv = "INSERT INTO 予約データ " & _
            "( " & _
                "予約コード, " & _
                "予約日FROM, " & _
                "予約日TO, " & _
                "チャネルコード, " & _
                "ルームコード, " & _
                "開始時, " & _
                "開始分, " & _
                "終了時, " & _
                "終了分, " & _
                "サービス部門コード, " & _
                "サービス担当者コード, " & _
                "会員コード, " & _
                "名称, " & _
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
                "備考1, " & _
                "備考2, " & _
                "備考3, " & _
                "予約担当者コード, " & _
                "登録日, " & _
                "登録時間, " & _
                "最終更新日, " & _
                "最終更新時間 " & _
            ") VALUES ( " & _
                parReserv.sReserveCode & ", " & _
                """" & parReserv.sFromReserveDate & """, " & _
                """" & parReserv.sToReserveDate & """, " & _
                parReserv.sChannelCode & ", " & _
                parReserv.sRoomCode & ", " & _
                parReserv.sFromHour & ", " & _
                parReserv.sFromMinute & ", " & _
                parReserv.sToHour & ", " & _
                parReserv.sToMinute & ", " & _
                """" & parReserv.sBumonCode & """, " & _
                """" & parReserv.sServiceStaffCode & """, " & _
                """" & parReserv.sMemberCode & """, " & _
                """" & parReserv.sName & """, " & _
                """" & parReserv.sPostCode & """, " & _
                """" & parReserv.sAddress1 & """, " & _
                """" & parReserv.sAddress2 & """, " & _
                """" & parReserv.sAddress3 & """, " & _
                """" & parReserv.sTEL & """, " & _
                """" & parReserv.sFAX & """, " & _
                """" & parReserv.sMailAddress & """, " & _
                """" & parReserv.sSex & """, " & _
                """" & parReserv.sBirthDay & """, " & _
                parReserv.sGeneration & ", " & _
                """" & parReserv.sMemo1 & """, " & _
                """" & parReserv.sMemo2 & """, " & _
                """" & parReserv.sMemo3 & """, " & _
                """" & parReserv.sStaffCode & """, " & _
                """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                """" & String.Format("{0:HH:mm:ss}", Now) & """, " & _
                """" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                """" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
            ") "

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertReserv

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            insertReserv = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.insertReserv)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in cSubReservオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateReserv(ByRef parReserv As cStructureLib.sReserv, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertReserv As String

        Try

            'SQL文の設定
            strInsertReserv = "UPDATE 予約データ SET " & _
                                "予約コード = " & parReserv.sReserveCode & ", " & _
                                "予約日FROM = """ & parReserv.sFromReserveDate & """, " & _
                                "予約日TO = """ & parReserv.sToReserveDate & """, " & _
                                "チャネルコード = " & parReserv.sChannelCode & ", " & _
                                "ルームコード = " & parReserv.sRoomCode & ", " & _
                                "開始時 = " & parReserv.sFromHour & ", " & _
                                "開始分 = " & parReserv.sFromMinute & ", " & _
                                "終了時 = " & parReserv.sToHour & ", " & _
                                "終了分 = " & parReserv.sToMinute & ", " & _
                                "サービス部門コード = """ & parReserv.sBumonCode & """, " & _
                                "サービス担当者コード = """ & parReserv.sServiceStaffCode & """, " & _
                                "会員コード = """ & parReserv.sMemberCode & """, " & _
                                "名称 = """ & parReserv.sName & """, " & _
                                "郵便番号 = """ & parReserv.sPostCode & """, " & _
                                "住所１ = """ & parReserv.sAddress1 & """, " & _
                                "住所２ = """ & parReserv.sAddress2 & """, " & _
                                "住所３ = """ & parReserv.sAddress3 & """, " & _
                                "TEL = """ & parReserv.sTEL & """, " & _
                                "FAX = """ & parReserv.sFAX & """, " & _
                                "メールアドレス = """ & parReserv.sMailAddress & """, " & _
                                "性別 = """ & parReserv.sSex & """, " & _
                                "生年月日 = """ & parReserv.sBirthDay & """, " & _
                                "年齢 = " & parReserv.sGeneration & ", " & _
                                "備考1 = """ & parReserv.sMemo1 & """, " & _
                                "備考2 = """ & parReserv.sMemo2 & """, " & _
                                "備考3 = """ & parReserv.sMemo3 & """, " & _
                                "予約担当者コード = """ & parReserv.sStaffCode & """, " & _
                                "最終更新日 = """ & parReserv.sUpdateDate & """, " & _
                                "最終更新時間 = """ & parReserv.sUpdateTime & """ " & _
                            "WHERE 予約コード = " & parReserv.sReserveCode & " "

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertReserv

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateReserv = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.updateReserv)", Nothing, Nothing, oExcept.ToString)
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
    Public Function readMaxReservCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT MAX(予約コード) AS 最大予約コード FROM 予約データ"

        Try
            pCommand.CommandText = strSelect

            '予約データから該当MAX取引IDのレコード読込 
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("最大予約コード")) Then
                    readMaxReservCode = 0
                Else
                    readMaxReservCode = CLng(pDataReader("最大予約コード")) + 1
                End If
            Else
                readMaxReservCode = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.readMaxReservCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引明細テーブルから該当レコードを削除するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteReserv(ByVal KetReservCode As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strDeleteReserv As String

        Try

            'SQL文の設定

            strDeleteReserv = "DELETE * FROM 予約データ " & _
                            "WHERE 予約コード=@ReservCode"


            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteReserv

            '***********************
            '   パラメータの設定
            '***********************

            '予約コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReservCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ReservCode").Value = KetReservCode

            '取引テーブル挿入処理実行
            deleteReserv = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataReservDBIO.deleteReserv)", Nothing, Nothing, oExcept.ToString)
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
