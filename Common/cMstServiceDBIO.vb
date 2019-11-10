Public Class cMstServiceDBIO
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
    '　機能：プロパティの取引コードのレコードがサービスマスタに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ServiceExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Const strSelect As String = _
        "SELECT COUNT(*) FROM サービスマスタ WHERE サービスコード = @ServiceCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ServiceCode").Value = KeyString

            ServiceExist = CInt(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.ServiceMstExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次サービスマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getService(ByRef parService() As cStructureLib.sService, _
                                ByVal keyServiceCode As String, _
                                ByVal KeyServiceName As String, _
                                ByVal KeyServiceClass As Integer, _
                                ByVal KeyTarget_C As Boolean, _
                                ByVal KeyTarget_E As Boolean, _
                                ByVal KeyTarget_A As Boolean, _
                                ByVal KeyTarget_P As Boolean, _
                                ByVal KeyTarget_O As Boolean, _
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

            strSelect = "SELECT * FROM サービスマスタ "

            'パラメータ数のカウント
            pc = 0
            If keyServiceCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyServiceName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyServiceClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeyTarget_C <> Nothing Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If KeyTarget_E <> Nothing Then
                maxpc = 16
                pc = pc Or maxpc
            End If
            If KeyTarget_A <> Nothing Then
                maxpc = 32
                pc = pc Or maxpc
            End If
            If KeyTarget_P <> Nothing Then
                maxpc = 64
                pc = pc Or maxpc
            End If
            If KeyTarget_O <> Nothing Then
                maxpc = 128
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
                            strSelect = strSelect & "サービスコード = " & keyServiceCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス名称 Like ""%" & KeyServiceName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス区分 = " & KeyServiceClass & " "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス対象－顧客 =" & KeyTarget_C & " "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス対象－社員 =" & KeyTarget_E & " "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス対象－アルバイト =" & KeyTarget_A & " "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス対象－パート =" & KeyTarget_P & " "
                            scnt = scnt + 1
                        Case 128
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－その他 =" & KeyTarget_O & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY サービスコード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parService(i)

                'レコードが取得できた時の処理
                'サービスコード
                parService(i).sServiceCode = CStr(pDataReader("サービスコード"))
                'サービス名称
                parService(i).sServiceName = CStr(pDataReader("サービス名称"))
                'サービス区分
                parService(i).sServiceClass = CInt(pDataReader("サービス区分"))
                'サービス対象－顧客
                parService(i).sTarget_C = CBool(pDataReader("サービス対象－顧客"))
                'サービス対象－社員
                parService(i).sTarget_E = CBool(pDataReader("サービス対象－社員"))
                'サービス対象－アルバイト
                parService(i).sTarget_A = CBool(pDataReader("サービス対象－アルバイト"))
                'サービス対象－パート
                parService(i).sTarget_P = CBool(pDataReader("サービス対象－パート"))
                'サービス対象－その他
                parService(i).sTarget_O = CBool(pDataReader("サービス対象－その他"))

                i = i + 1

            End While

            getService = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.getService)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getServiceRate(ByRef parServiceRate() As cStructureLib.sServiceRate, _
                             ByVal keyServiceCode As String, _
                             ByVal KeyBumonCode As String, _
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

            strSelect = "SELECT * FROM サービス内容マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyServiceCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyBumonCode <> Nothing Then
                maxpc = 2
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
                            strSelect = strSelect & "サービスコード = " & keyServiceCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            'strSelect = strSelect & "部門コード Like ""%" & KeyBumonCode & "%"" "
                            strSelect = strSelect & "部門コード = """ & KeyBumonCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY サービスコード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parServiceRate(i)

                'レコードが取得できた時の処理
                'サービスコード
                parServiceRate(i).sServiceCode = CStr(pDataReader("サービスコード"))
                '部門コード
                parServiceRate(i).sBumonCode = CStr(pDataReader("部門コード"))
                '割引率
                parServiceRate(i).sRate = CInt(pDataReader("割引率"))

                i = i + 1

            End While

            getServiceRate = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.getServiceRate)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getServiceFull(ByRef parServiceFull() As cStructureLib.sViewServiceFull, _
                                ByVal keyServiceCode As String, _
                                ByVal KeyServiceName As String, _
                                ByVal KeyServiceClass As Integer, _
                                ByVal KeyTarget_C As Boolean, _
                                ByVal KeyTarget_E As Boolean, _
                                ByVal KeyTarget_A As Boolean, _
                                ByVal KeyTarget_P As Boolean, _
                                ByVal KeyTarget_O As Boolean, _
                                ByVal KeyBumonCode As String, _
                                ByVal KeyBumonName As String, _
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
                            "サービスマスタ.サービスコード AS サービスコード, " & _
                            "サービスマスタ.サービス名称 AS サービス名称, " & _
                            "サービスマスタ.サービス区分 AS サービス区分, " & _
                            "サービスマスタ.サービス対象－顧客 AS サービス対象－顧客, " & _
                            "サービスマスタ.サービス対象－社員 AS サービス対象－社員, " & _
                            "サービスマスタ.サービス対象－アルバイト AS サービス対象－アルバイト, " & _
                            "サービスマスタ.サービス対象－パート AS サービス対象－パート, " & _
                            "サービスマスタ.サービス対象－その他 AS サービス対象－その他, " & _
                            "サービス内容マスタ.部門コード AS 部門コード, " & _
                            "部門マスタ.部門名称 AS 部門名称, " & _
                            "サービス内容マスタ.割引率 AS 割引率 " & _
                        "FROM " & _
                            "(サービスマスタ LEFT JOIN サービス内容マスタ " & _
                            "ON サービスマスタ.サービスコード = サービス内容マスタ.サービスコード) " & _
                            "LEFT JOIN 部門マスタ ON サービス内容マスタ.部門コード = 部門マスタ.部門コード "

            'パラメータ数のカウント
            pc = 0
            If keyServiceCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyServiceName <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyServiceClass <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeyTarget_C <> Nothing Then
                maxpc = 8
                pc = pc Or maxpc
            End If
            If KeyTarget_E <> Nothing Then
                maxpc = 16
                pc = pc Or maxpc
            End If
            If KeyTarget_A <> Nothing Then
                maxpc = 32
                pc = pc Or maxpc
            End If
            If KeyTarget_P <> Nothing Then
                maxpc = 64
                pc = pc Or maxpc
            End If
            If KeyTarget_O <> Nothing Then
                maxpc = 128
                pc = pc Or maxpc
            End If
            If KeyBumonCode <> Nothing Then
                maxpc = 256
                pc = pc Or maxpc
            End If
            If KeyBumonName <> Nothing Then
                maxpc = 512
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
                            strSelect = strSelect & "サービスマスタ.サービスコード = " & keyServiceCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス名称 Like ""%" & KeyServiceName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス区分 = " & KeyServiceClass & " "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－顧客 =" & KeyTarget_C & " "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－社員 =" & KeyTarget_E & " "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－アルバイト =" & KeyTarget_A & " "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－パート =" & KeyTarget_P & " "
                            scnt = scnt + 1
                        Case 128
                            If scnt > 0 Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービスマスタ.サービス対象－その他 =" & KeyTarget_O & " "
                            scnt = scnt + 1
                        Case 256
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "サービス内容マスタ.部門コード Like ""&" & KeyBumonCode & "%"" "
                            scnt = scnt + 1
                        Case 512
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "部門マスタ.部門名称 Like ""&" & KeyBumonName & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY サービスマスタ.サービスコード "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parServiceFull(i)

                'レコードが取得できた時の処理
                'サービスコード
                parServiceFull(i).sServiceCode = CInt(pDataReader("サービスコード"))
                'サービス名称
                parServiceFull(i).sServiceName = CStr(pDataReader("サービス名称"))
                'サービス区分
                parServiceFull(i).sServiceClass = CInt(pDataReader("サービス区分"))
                'サービス対象－顧客
                parServiceFull(i).sTarget_C = CBool(pDataReader("サービス対象－顧客"))
                'サービス対象－社員
                parServiceFull(i).sTarget_E = CBool(pDataReader("サービス対象－社員"))
                'サービス対象－アルバイト
                parServiceFull(i).sTarget_A = CBool(pDataReader("サービス対象－アルバイト"))
                'サービス対象－パート
                parServiceFull(i).sTarget_P = CBool(pDataReader("サービス対象－パート"))
                'サービス対象－その他
                parServiceFull(i).sTarget_O = CBool(pDataReader("サービス対象－その他"))
                '部門コード
                parServiceFull(i).sBumonCode = CStr(pDataReader("部門コード"))
                'サービス区分
                parServiceFull(i).sBumonName = CStr(pDataReader("部門名称"))
                '割引率
                parServiceFull(i).sRate = CInt(pDataReader("割引率"))

                i = i + 1

            End While

            getServiceFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.getServiceFull)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次サービスマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getNewServiceCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String

        getNewServiceCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT サービスコード FROM サービスマスタ WHERE Len([サービスコード]) < 3 ORDER BY サービスコード DESC"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() = False Then
                getNewServiceCode = 1
            Else
                '最大サービスコード
                getNewServiceCode = CInt(pDataReader("サービスコード").ToString) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.getNewServiceCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：サービスマスタに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertService(ByVal parService As cStructureLib.sService, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO サービスマスタ " & _
        "( サービスコード, サービス名称, サービス区分, サービス対象－顧客, サービス対象－社員, サービス対象－アルバイト, " & _
        "サービス対象－パート, サービス対象－その他, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
        "VALUES (@ServiceCode, @ServiceName, @ServiceClass, @Target_C, @Target_E, @Target_A, @Target_P, @Target_O, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'サービスコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ServiceCode").Value = parService.sServiceCode.ToString

            'サービス名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ServiceName").Value = parService.sServiceName.ToString

            'サービス区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ServiceClass").Value = parService.sServiceClass

            'サービス対象－顧客
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Target_C", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@Target_C").Value = parService.sTarget_C

            'サービス対象－社員
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Target_E", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@Target_E").Value = parService.sTarget_E

            'サービス対象－アルバイト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Target_A", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@Target_A").Value = parService.sTarget_A

            'サービス対象－パート
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Target_P", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@Target_P").Value = parService.sTarget_P

            'サービス対象－その他
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Target_O", OleDb.OleDbType.Boolean))
            pCommand.Parameters("@Target_O").Value = parService.sTarget_O

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parService.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parService.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parService.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parService.sCreateTime.ToString
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

            insertService = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.insertService)", Nothing, Nothing, oExcept.ToString)
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

    Public Function insertServiceRate(ByVal parServiceRate As cStructureLib.sServiceRate, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strInsert As String = "INSERT INTO サービス内容マスタ " & _
        "( サービスコード, 部門コード, 割引率, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
        "VALUES (@ServiceRateCode, @BomonCode, @Rate, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'サービスコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceRateCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@ServiceRateCode").Value = parServiceRate.sServiceCode

            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parServiceRate.sBumonCode

            '割引率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceRateClass", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@ServiceRateClass").Value = parServiceRate.sRate

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parServiceRate.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parServiceRate.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parServiceRate.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parServiceRate.sCreateTime.ToString
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

            insertServiceRate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceRateDBIO.insertServiceRate)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：サービスマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteService(ByVal keyServiceCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM サービスマスタ WHERE サービスコード=""" & keyServiceCode & """ "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '商品マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteService = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.deleteService)", Nothing, Nothing, oExcept.ToString)
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

    Public Function deleteServiceRate( _
                                ByVal KeyServiceCode As Integer, _
                                ByVal KeyBumonCode As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'SQL文の設定
        strDelete = "DELETE * FROM サービス内容マスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If KeyServiceCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyBumonCode <> Nothing Then
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
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "サービスコード =" & KeyServiceCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "部門コード =""" & KeyBumonCode & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            'サービスマスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteServiceRate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstRoomDBIO.deleteServiceRate)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：サービスマスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateService(ByRef parService As cStructureLib.sService, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE サービスマスタ SET " & _
                            "サービス名称=""" & parService.sServiceName & """, " & _
                            "サービス区分=" & parService.sServiceClass & ", " & _
                            "サービス対象－顧客 = " & parService.sTarget_C & ", " & _
                            "サービス対象－社員 = " & parService.sTarget_E & ", " & _
                            "サービス対象－アルバイト = " & parService.sTarget_A & ", " & _
                            "サービス対象－パート = " & parService.sTarget_P & ", " & _
                            "サービス対象－その他 = " & parService.sTarget_O & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE サービスコード=" & parService.sServiceCode & " "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            'サービスマスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateService = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.updateService)", Nothing, Nothing, oExcept.ToString)
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

    Public Function updateServiceRate(ByRef parServiceRate As cStructureLib.sServiceRate, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE サービス内容マスタ SET " & _
                            "割引率 = " & parServiceRate.sRate & ", " & _
                           "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE サービスコード = " & parServiceRate.sServiceCode & " " & _
                            "AND 部門コード=""" & parServiceRate.sServiceCode & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateServiceRate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstServiceDBIO.updateServiceRate)", Nothing, Nothing, oExcept.ToString)
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
