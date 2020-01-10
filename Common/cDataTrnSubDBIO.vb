
Public Class cDataTrnSubDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    Public Function TrnExist(ByVal KeyString As String, ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Const strSelectTrn As String =
        "SELECT COUNT(*) FROM 日次取引明細データ WHERE 取引コード = @TrnCode"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@TrnCode").Value = KeyString

            '取引テーブルから該当取引コードのレコード数読込 
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.TrnExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSubTrn(ByRef parSubTrn() As cStructureLib.sSubTrn, _
                              ByVal KeyTrnCode As Long, _
                              ByVal KeySubTrnCode As Long, _
                              ByVal KeySubTrnClass As Integer, _
                              ByVal KeyProductCode As String, _
                              ByVal KeyProductName As String, _
                              ByVal KeyJANCode As String, _
                              ByVal KeyMemo As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT * FROM 日次取引明細データ "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeySubTrnClass <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyProductName <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyJANCode <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyMemo <> Nothing Then
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
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "取引明細コード = " & KeySubTrnCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "売上明細区分 = " & KeySubTrnClass & " "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品名称 Like ""%" & KeyProductName & "%"" "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "備考 Like ""%" & KeyMemo & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If
        strSelect = strSelect + "ORDER BY 取引コード, 取引明細コード "
        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSubTrn(i)

                '取引コード
                If IsDBNull(pDataReader("取引コード")) = True Then
                    parSubTrn(i).sTrnCode = 0
                Else
                    parSubTrn(i).sTrnCode = CLng(pDataReader("取引コード"))
                End If
                '取引明細コード
                If IsDBNull(pDataReader("取引明細コード")) = True Then
                    parSubTrn(i).sSubTrnCode = 0
                Else
                    parSubTrn(i).sSubTrnCode = CLng(pDataReader("取引明細コード"))
                End If
                '売上状態
                parSubTrn(i).sStatus = pDataReader("売上状態").ToString
                '売上明細区分
                If IsDBNull(pDataReader("売上明細区分")) = True Then
                    parSubTrn(i).sSubTrnClass = 0
                Else
                    parSubTrn(i).sSubTrnClass = CInt(pDataReader("売上明細区分"))
                End If
                '部門コード
                parSubTrn(i).sBumonCode = pDataReader("部門コード").ToString
                '商品コード
                parSubTrn(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parSubTrn(i).sProductName = pDataReader("商品名称").ToString
                'JANコード
                parSubTrn(i).sJANCode = pDataReader("JANコード").ToString
                'オプション1
                parSubTrn(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parSubTrn(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parSubTrn(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parSubTrn(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parSubTrn(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parSubTrn(i).sListPrice = 0
                Else
                    parSubTrn(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parSubTrn(i).sCostPrice = 0
                Else
                    parSubTrn(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '取引商品単価
                If IsDBNull(pDataReader("取引商品単価")) = True Then
                    parSubTrn(i).sUnitPrice = 0
                Else
                    parSubTrn(i).sUnitPrice = CLng(pDataReader("取引商品単価"))
                End If
                '取引数量
                If IsDBNull(pDataReader("取引数量")) = True Then
                    parSubTrn(i).sCount = 0
                Else
                    parSubTrn(i).sCount = CInt(pDataReader("取引数量"))
                End If
                '取引税抜商品金額
                If IsDBNull(pDataReader("取引税抜商品金額")) = True Then
                    parSubTrn(i).sNoTaxProductPrice = 0
                Else
                    parSubTrn(i).sNoTaxProductPrice = CLng(pDataReader("取引税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parSubTrn(i).sShipCharge = 0
                Else
                    parSubTrn(i).sShipCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parSubTrn(i).sPayCharge = 0
                Else
                    parSubTrn(i).sPayCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parSubTrn(i).sDiscountPrice = 0
                Else
                    parSubTrn(i).sDiscountPrice = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parSubTrn(i).sPointDiscountPrice = 0
                Else
                    parSubTrn(i).sPointDiscountPrice = CLng(pDataReader("ポイント値引き"))
                End If
                'チケット値引き
                If IsDBNull(pDataReader("チケット値引き")) = True Then
                    parSubTrn(i).sTicketDiscountPrice = 0
                Else
                    parSubTrn(i).sTicketDiscountPrice = CLng(pDataReader("チケット値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引税抜金額")) = True Then
                    parSubTrn(i).sNoTaxPrice = 0
                Else
                    parSubTrn(i).sNoTaxPrice = CLng(pDataReader("取引税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引消費税額")) = True Then
                    parSubTrn(i).sTaxPrice = 0
                Else
                    parSubTrn(i).sTaxPrice = CLng(pDataReader("取引消費税額"))
                End If

                '2019.10.16 R.Takashima FROM
                '取引軽減消費税額
                If IsDBNull(pDataReader("取引軽減消費税額")) = True Then
                    parSubTrn(i).sReducedTaxRatePrice = 0
                Else
                    parSubTrn(i).sReducedTaxRatePrice = CLng(pDataReader("取引軽減消費税額"))
                End If
                '2019.10.16 R.Takashima TO

                '2019,12,23 A.Komita 追加 From
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parSubTrn(i).sReducedTaxRate = 0
                Else
                    parSubTrn(i).sReducedTaxRate = CLng(pDataReader("軽減税率"))
                End If
                '2019,12,23 A.Komita 追加 To

                '取引税込金額
                If IsDBNull(pDataReader("取引税込金額")) = True Then
                    parSubTrn(i).sPrice = 0
                Else
                    parSubTrn(i).sPrice = CLng(pDataReader("取引税込金額"))
                End If
                '備考
                parSubTrn(i).sMemo = pDataReader("備考").ToString
                '登録日
                parSubTrn(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSubTrn(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日

                parSubTrn(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSubTrn(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1

            End While

            getSubTrn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSumCount(ByRef parSubTrn() As cStructureLib.sSubTrn, _
                              ByVal KeyTrnCode As Long, _
                              ByVal KeyProductCode As String, _
                              ByVal KeyJANCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT " & _
                        "日次取引明細データ.取引コード, " & _
                        "日次取引明細データ.商品コード, " & _
                        "日次取引明細データ.JANコード, " & _
                        "Sum(日次取引明細データ.取引数量) AS 数量の合計 " & _
                    "FROM 日次取引明細データ " & _
                    "GROUP BY 日次取引明細データ.取引コード, 日次取引明細データ.商品コード, 日次取引明細データ.JANコード "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyJANCode <> Nothing Then
            maxpc = 4
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
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("数量の合計")) Then
                    getSumCount = 0
                Else
                    '取引コードインクリメント
                    getSumCount = CLng(pDataReader("数量の合計"))
                End If
            Else
                getSumCount = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSumCount)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getSumPrice(ByRef parSubTrn() As cStructureLib.sSubTrn,
                               ByVal KeyTrnCode As Long,
                               ByVal KeySubTrnClass As Integer,
                               ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        strSelect = "SELECT " &
                        "日次取引明細データ.取引コード, " &
                        "日次取引明細データ.売上明細区分, " &
                        "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計 " &
                    "FROM 日次取引明細データ " &
                    "GROUP BY 日次取引明細データ.取引コード, 日次取引明細データ.売上明細区分 "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnClass <> Nothing Then
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
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "HAVING "
                        End If
                        strSelect = strSelect & "売上明細区分 = " & KeySubTrnClass & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand.CommandText = strSelect
            pCommand.Transaction = Tran

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("税込金額の合計")) Then
                    getSumPrice = 0
                Else
                    '取引コードインクリメント
                    getSumPrice = CLng(pDataReader("税込金額の合計"))
                End If
            Else
                getSumPrice = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.getSumPrice)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSubTrn(ByVal parSubTrn As cStructureLib.sSubTrn, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        '2020,1,7 A.Komita 追加 From
        Dim strInsertTrn As String
        '2020,1,7 A.Komita 追加 To

        Try

            '2019.10.5 R.Takashima
            '軽減消費税額の追加
            'SQL文の設定
            strInsertTrn = "INSERT INTO 日次取引明細データ (" &
                                                "取引コード, " &
                                                "取引明細コード, " &
                                                "売上状態, " &
                                                "売上明細区分, " &
                                                "部門コード, " &
                                                "商品コード, " &
                                                "商品名称, " &
                                                "JANコード, " &
                                                "オプション1, " &
                                                "オプション2, " &
                                                "オプション3, " &
                                                "オプション4, " &
                                                "オプション5, " &
                                                "定価, " &
                                                "仕入単価, " &
                                                "取引商品単価, " &
                                                "取引数量, " &
                                                "取引税抜商品金額, " &
                                                "送料, " &
                                                "手数料, " &
                                                "値引き, " &
                                                "ポイント値引き, " &
                                                "チケット値引き, " &
                                                "取引税抜金額, " &
                                                "取引消費税額, " &
                                                "取引軽減消費税額, " &
                                                "軽減税率, " &
                                                "取引税込金額, " &
                                                "備考, " &
                                                "登録日, " &
                                                "登録時間, " &
                                                "最終更新日, " &
                                                "最終更新時間 " &
                                            ") VALUES ( " &
                                                "@TrnCode, " &
                                                "@SubTrnCode, " &
                                                "@Status, " &
                                                "@SubTrnClass, " &
                                                "@BumonCode, " &
                                                "@ProductCode, " &
                                                "@ProductName, " &
                                                "@JANCode, " &
                                                "@Option1, " &
                                                "@Option2, " &
                                                "@Option3, " &
                                                "@Option4, " &
                                                "@Option5, " &
                                                "@ListPrice, " &
                                                "@CostPrice, " &
                                                "@UnitPrice, " &
                                                "@Count, " &
                                                "@NoTaxProductPrice, " &
                                                "@ShipCharge, " &
                                                "@PayCharge, " &
                                                "@DiscountPrice, " &
                                                "@PointDiscountPrice, " &
                                                "@TicketDiscountPrice, " &
                                                "@NoTaxPrice, " &
                                                "@TaxPrice, " &
                                                "@ReduceTaxPrice, " &
                                                "@ReducedTaxRate, " &
                                                "@Price, " &
                                                "@Memo, " &
                                                "@CreateDate, " &
                                                "@CreateTime, " &
                                                "@UpdateDate, " &
                                                "@UpdateTime " &
                                            ")"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertTrn

            '***********************
            '   パラメータの設定
            '***********************

            '取引コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TrnCode").Value = parSubTrn.sTrnCode
            '取引明細コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubTrnCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SubTrnCode").Value = parSubTrn.sSubTrnCode
            '売上状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Status", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@Status").Value = parSubTrn.sStatus
            '売上明細区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubTrnClass", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@SubTrnClass").Value = parSubTrn.sSubTrnClass
            '部門コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BumonCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@BumonCode").Value = parSubTrn.sBumonCode
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parSubTrn.sProductCode
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@ProductName").Value = parSubTrn.sProductName
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parSubTrn.sJANCode
            'オプション1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option1", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option1").Value = parSubTrn.sOption1
            'オプション2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option2", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option2").Value = parSubTrn.sOption2
            'オプション3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option3", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option3").Value = parSubTrn.sOption3
            'オプション4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option4", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option4").Value = parSubTrn.sOption4
            'オプション5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option5", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option5").Value = parSubTrn.sOption5
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ListPrice").Value = parSubTrn.sListPrice
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CostPrice").Value = parSubTrn.sCostPrice
            '取引商品単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@UnitPrice").Value = parSubTrn.sUnitPrice
            '取引数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@Count").Value = parSubTrn.sCount
            '取引税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxProductPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxProductPrice").Value = parSubTrn.sNoTaxProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShipCharge").Value = parSubTrn.sShipCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PayCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PayCharge").Value = parSubTrn.sPayCharge
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@DiscountPrice").Value = parSubTrn.sDiscountPrice
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDiscountPrice").Value = parSubTrn.sPointDiscountPrice
            'チケット値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TicketDiscountPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TicketDiscountPrice").Value = parSubTrn.sTicketDiscountPrice
            '取引税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NoTaxPrice").Value = parSubTrn.sNoTaxPrice
            '取引消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxPrice").Value = parSubTrn.sTaxPrice
            '取引軽減消費税額 2019.10.5 R.Takashima FROM
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReduceTaxPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ReduceTaxPrice").Value = parSubTrn.sReducedTaxRatePrice
            '2019.10.5 R.Takashima TO

            '2019,12,23 A.Komita 追加 From
            '軽減税率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Numeric, 10))
            If IsNothing(parSubTrn.sReducedTaxRate) = True Then
                pCommand.Parameters("@ReducedTaxRate").Value = 0
            Else
                pCommand.Parameters("@ReducedTaxRate").Value = parSubTrn.sReducedTaxRate
            End If
            '2019,12,23 A.Komita 追加 To

            '取引税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Price").Value = parSubTrn.sPrice
            '備考
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Memo").Value = parSubTrn.sMemo
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

            '取引テーブル挿入処理実行
            'pCommand.ExecuteNonQuery()

            insertSubTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.insertSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateSubTrn(ByVal parSubTrn As cStructureLib.sSubTrn, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = ""
        strUpdate = "UPDATE 日次取引明細データ SET " &
                            "取引コード=" & parSubTrn.sTrnCode & " , " &
                            "取引明細コード=" & parSubTrn.sSubTrnCode & " , " &
                            "売上状態=""" & parSubTrn.sStatus.ToString & """ , " &
                            "売上明細区分=" & parSubTrn.sSubTrnClass & " , " &
                            "部門コード=""" & parSubTrn.sBumonCode.ToString & """ , " &
                            "商品コード=""" & parSubTrn.sProductCode.ToString & """ , " &
                            "商品名称=""" & parSubTrn.sProductName.ToString & """ , " &
                            "JANコード=""" & parSubTrn.sJANCode.ToString & """ , " &
                            "オプション1=""" & parSubTrn.sOption1.ToString & """ , " &
                            "オプション2=""" & parSubTrn.sOption2.ToString & """ , " &
                            "オプション3=""" & parSubTrn.sOption3.ToString & """ , " &
                            "オプション4=""" & parSubTrn.sOption4.ToString & """ , " &
                            "オプション5=""" & parSubTrn.sOption5.ToString & """ , " &
                            "定価=" & parSubTrn.sPrice & " , " &
                            "仕入単価=" & parSubTrn.sCostPrice & " , " &
                            "取引商品単価=" & parSubTrn.sUnitPrice & " , " &
                            "取引数量=" & parSubTrn.sCount & " , " &
                            "取引税抜商品金額=" & parSubTrn.sNoTaxProductPrice & " , " &
                            "送料=" & parSubTrn.sShipCharge & " , " &
                            "手数料=" & parSubTrn.sPayCharge & " , " &
                            "値引き=" & parSubTrn.sDiscountPrice & " , " &
                            "ポイント値引き=" & parSubTrn.sPointDiscountPrice & " , " &
                            "チケット値引き=" & parSubTrn.sTicketDiscountPrice & " , " &
                            "取引税抜金額=" & parSubTrn.sNoTaxPrice & " , " &
                            "取引消費税額=" & parSubTrn.sPointDiscountPrice & " , " &
                            "取引軽減消費税額=" & parSubTrn.sReducedTaxRatePrice & " , " &
                            "軽減税率=" & parSubTrn.sReducedTaxRate & " , " &
                            "取引税込金額=" & parSubTrn.sPrice & " , " &
                            "備考=""" & parSubTrn.sMemo & """ , " &
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " &
                        "WHERE 取引コード=" & parSubTrn.sTrnCode & " " &
                        "AND 取引明細コード=" & parSubTrn.sSubTrnCode
        '取引軽減消費税率 追加 2019.10.05 R.Takashima

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate


            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateSubTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.updateSubTrn)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteSubTrn(
                                    ByVal KeyTrnCode As Long,
                                    ByVal KeySubTrnCode As Long,
                                    ByVal KeyShipmentCode As String,
                                    ByRef Tran As OleDb.OleDbTransaction
                                ) As Boolean

        Dim strDeleteSubTrn As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim cnt As Long

        cnt = 0
        strDeleteSubTrn = ""

        'SQL文の設定
        strDeleteSubTrn = "DELETE * FROM 日次取引明細データ "

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeySubTrnCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyShipmentCode <> "" Then
            maxpc = 4
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
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "取引コード= " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "取引明細コード= " & KeySubTrnCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strDeleteSubTrn = strDeleteSubTrn & "AND "
                        Else
                            strDeleteSubTrn = strDeleteSubTrn & "WHERE "
                        End If
                        strDeleteSubTrn = strDeleteSubTrn & "出荷コード= """ & KeyShipmentCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteSubTrn

            '取引明細テーブル挿入処理実行
            cnt = pCommand.ExecuteNonQuery()

            If cnt <= 0 Then
                deleteSubTrn = False
            Else
                deleteSubTrn = True
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataSubTrnSubDBIO.deleteSubTrn)", Nothing, Nothing, oExcept.ToString)
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
