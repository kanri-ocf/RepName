Public Class cMstPaymentDBIO
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
    Public Function PaymentExist(ByVal KeyString As String, ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Const strSelect As String =
        "SELECT COUNT(*) FROM スタッフマスタ WHERE 支払方法マスタ = @PaymentCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@PaymentCode").Value = KeyString

            '部門マスタから該当取引コードのレコード数読込 
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.PaymentExist)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getPayment(ByRef parPayment() As cStructureLib.sPayment, _
                               ByVal KeyPaymentCode As Integer, _
                               ByVal KeyPaymentName As String, _
                               ByVal keyCreditFlg As Boolean, _
                               ByVal keyRequestFlg As Boolean, _
                               ByVal keyShipFlg As Boolean, _
                               ByVal keyOrderFlg As Boolean, _
                               ByVal KeyArrivFlg As Boolean, _
                               ByVal KeyReturnFlg As Boolean, _
                               ByVal KeyDaibikiFlg As Boolean, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""
        strSelect = "SELECT * FROM 支払方法マスタ "

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyPaymentCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyPaymentName <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If keyCreditFlg <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If keyRequestFlg <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If keyShipFlg <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If keyOrderFlg <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyArrivFlg <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If
        If KeyReturnFlg <> Nothing Then
            maxpc = 128
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
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法コード= " & KeyPaymentCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "支払方法名称 Like ""%" & KeyPaymentName & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "掛取引フラグ= " & keyCreditFlg & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注フラグ= " & keyRequestFlg & " "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷フラグ= " & keyShipFlg & " "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注フラグ= " & keyOrderFlg & " "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "入荷フラグ= " & KeyArrivFlg & " "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "返品フラグ= " & KeyReturnFlg & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        i = 0

        'SQL文の設定
        pCommand.CommandText = strSelect

        Try
            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parPayment(i)

                'レコードが取得できた時の処理
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parPayment(i).sPaymentCode = 0
                Else
                    parPayment(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parPayment(i).sPaymentName = pDataReader("支払方法名称").ToString
                '掛取引フラグ
                If IsDBNull(pDataReader("掛取引フラグ")) = True Then
                    parPayment(i).sCreditFlg = False
                Else
                    parPayment(i).sCreditFlg = CBool(pDataReader("掛取引フラグ"))
                End If
                '受注フラグ
                If IsDBNull(pDataReader("受注フラグ")) = True Then
                    parPayment(i).sRequestFlg = False
                Else
                    parPayment(i).sRequestFlg = CBool(pDataReader("受注フラグ"))
                End If
                '出荷フラグ
                If IsDBNull(pDataReader("出荷フラグ")) = True Then
                    parPayment(i).sShipmentFlg = False
                Else
                    parPayment(i).sShipmentFlg = CBool(pDataReader("出荷フラグ"))
                End If
                '発注フラグ
                If IsDBNull(pDataReader("発注フラグ")) = True Then
                    parPayment(i).sOrderFlg = False
                Else
                    parPayment(i).sOrderFlg = CBool(pDataReader("発注フラグ"))
                End If
                '入荷フラグ
                If IsDBNull(pDataReader("入荷フラグ")) = True Then
                    parPayment(i).sArriveFlg = False
                Else
                    parPayment(i).sArriveFlg = CBool(pDataReader("入荷フラグ"))
                End If
                '返品フラグ
                If IsDBNull(pDataReader("返品フラグ")) = True Then
                    parPayment(i).sReturnFlg = False
                Else
                    parPayment(i).sReturnFlg = CBool(pDataReader("返品フラグ"))
                End If
                '登録日
                parPayment(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parPayment(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parPayment(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parPayment(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1
            End While

            getPayment = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.getPayment)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getPaymentCode(ByVal KeyPaymentName As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Long

        strSelect = ""
        strSelect = "SELECT 支払方法コード FROM 支払方法マスタ WHERE 支払方法名称 Like ""%" & KeyPaymentName & "%"" "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getPaymentCode = -1
            While pDataReader.Read()
                i = i + 1
                '支払方法コード
                getPaymentCode = CInt(pDataReader("支払方法コード"))

            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.getPaymentCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getNewPaymentCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Long

        strSelect = ""
        strSelect = "SELECT Max([支払方法コード]) AS 最大支払方法コード FROM 支払方法マスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getNewPaymentCode = -1

            pDataReader.Read()

            '最大チャネル支払コード
            If IsDBNull(pDataReader("最大支払方法コード")) Then
                getNewPaymentCode = 1
            Else
                getNewPaymentCode = CInt(pDataReader("最大支払方法コード").ToString) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.getNewPaymentCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報明細テーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertPaymentMst(ByVal parPayment As cStructureLib.sPayment, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO 支払方法マスタ ( " & _
                            "支払方法コード, " & _
                            "支払方法名称, " & _
                            "掛取引フラグ, " & _
                            "受注フラグ, " & _
                            "出荷フラグ, " & _
                            "発注フラグ, " & _
                            "入荷フラグ, " & _
                            "返品フラグ, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@PaymentCode, " & _
                            "@PaymentName, " & _
                            "@CreditFlg, " & _
                            "@RequestFlg, " & _
                            "@ShipmentFlg, " & _
                            "@OrderFlg, " & _
                            "@ArriveFlg, " & _
                            "@ReturnFlg, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@PaymentCode").Value = parPayment.sPaymentCode
            '支払方法名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@PaymentName").Value = parPayment.sPaymentName
            '掛取引フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreditFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@CreditFlg").Value = parPayment.sCreditFlg
            '受注フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@RequestFlg").Value = parPayment.sRequestFlg
            '出荷フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipmentFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ShipmentFlg").Value = parPayment.sShipmentFlg
            '発注フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OrderFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@OrderFlg").Value = parPayment.sOrderFlg
            '入荷フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ArriveFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ArriveFlg").Value = parPayment.sArriveFlg
            '返品フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReturnFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ReturnFlg").Value = parPayment.sReturnFlg
            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '支払方法マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertPaymentMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.insertPaymentMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：支払方法マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updatePaymentMst(ByVal parPayment As cStructureLib.sPayment, ByVal KeyPaymentCode As Integer, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 支払方法マスタ SET " &
                        "支払方法コード = " & parPayment.sPaymentCode & ", " &
                        "支払方法名称 = """ & parPayment.sPaymentName & """, " &
                        "掛取引フラグ = " & parPayment.sCreditFlg & ", " &
                        "受注フラグ = " & parPayment.sRequestFlg & ", " &
                        "出荷フラグ = " & parPayment.sShipmentFlg & ", " &
                        "発注フラグ = " & parPayment.sOrderFlg & ", " &
                        "入荷フラグ = " & parPayment.sArriveFlg & ", " &
                        "返品フラグ = " & parPayment.sReturnFlg & ", " &
                         "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " &
                    "WHERE 支払方法マスタ.支払方法コード= " & KeyPaymentCode & " "
        '"配送区分コード = " & parPayment.sDeliveryClassCode & ", " & _

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '支払方法マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                Return True
            Else
                '更新するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.updatePaymentMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの伝票印刷モードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deletePaymentMst(ByVal KeyPaymentCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE * FROM 支払方法マスタ " &
                        "WHERE 支払方法マスタ.支払方法コード = " & KeyPaymentCode & " "

            pCommand.CommandText = strDelete

            '支払方法マスタの削除処理実行
            deletePaymentMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPaymentDBIO.deletePaymentMst)", Nothing, Nothing, oExcept.ToString)
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
