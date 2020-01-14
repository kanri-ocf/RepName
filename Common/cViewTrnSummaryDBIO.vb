Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cViewTrnSummaryDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '2019/10/19 SUZUKI 
    '---------------------------------------------------------------------------------------------------------

    '----------------------------------------------------------------------
    '　機能：取引の集計結果を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getTrnSummary(ByRef parTrnSummary() As cStructureLib.sViewTrnSummary, ByVal keyCloseDate As String, ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer


        '2019.11.17 R.Takashima FROM
        'Sum(日次取引明細データ.送料) AS 送料の合計
        'Sum(日次取引明細データ.手数料) AS 手数料の合計
        '追加
        Try
            strSelectTrn =
                "SELECT " &
                    "日次取引データ.チャネルコード AS チャネルコード, " &
                    "チャネルマスタ.チャネル名称 AS チャネル名称, " &
                    "日次取引データ.取引区分 AS 取引区分, " &
                    "日次取引明細データ.部門コード AS 部門コード, " &
                    "部門マスタ.部門略称 AS 部門略称, " &
                    "日次取引データ.支払方法コード AS 支払方法コード, " &
                    "支払方法マスタ.支払方法名称, " &
                    "Sum(日次取引明細データ.取引数量) AS 数量の合計, " &
                    "Sum(日次取引明細データ.取引税抜商品金額) AS 税抜金額の合計, " &
                    "Sum(日次取引明細データ.送料) AS 送料の合計, " &
                    "Sum(日次取引明細データ.手数料) AS 手数料の合計, " &
                    "Sum(日次取引明細データ.値引き) AS 値引きの合計, " &
                    "Sum(日次取引明細データ.ポイント値引き) AS ポイント値引きの合計, " &
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計 " &
       "FROM " &
                    "(((日次取引データ LEFT JOIN 日次取引明細データ " &
                        "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " &
                    "LEFT JOIN チャネルマスタ " &
                        "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード) " &
                    "LEFT JOIN 部門マスタ " &
                        "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード) " &
                    "LEFT JOIN 支払方法マスタ " &
                        "ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード "
            '2019.11.17 R.Takashima TO

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn & "WHERE (日次取引データ.日次締め日 Is Null " &
                    "OR 日次取引データ.日次締め日 = """") "
            Else
                strSelectTrn = strSelectTrn & "WHERE 日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            strSelectTrn = strSelectTrn & "AND (日次取引データ.取引区分=""売上"" " &
                    "OR 日次取引データ.取引区分=""戻入"" " &
                    "OR 日次取引データ.取引区分=""販促"" " &
                    "OR 日次取引データ.取引区分=""社販"") " &
                "GROUP BY " &
                    "日次取引データ.チャネルコード, " &
                    "チャネルマスタ.チャネル名称, " &
                    "日次取引データ.取引区分, " &
                    "日次取引明細データ.部門コード, " &
                    "日次取引明細データ.軽減税率, " &
                    "部門マスタ.部門略称, " &
                    "日次取引データ.支払方法コード, " &
                    "支払方法マスタ.支払方法名称 " &
                "ORDER BY " &
                    "日次取引データ.取引区分, " &
                    "日次取引データ.チャネルコード, " &
                    "日次取引明細データ.部門コード, " &
                    "日次取引明細データ.軽減税率, " &
                    "日次取引データ.支払方法コード"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parTrnSummary(i)

                'レコードが取得できた時の処理
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parTrnSummary(i).sChannel = 0
                Else
                    parTrnSummary(i).sChannel = CInt(pDataReader("チャネルコード"))
                End If
                'チャネル名称
                parTrnSummary(i).sChannelName = pDataReader("チャネル名称").ToString
                '取引区分
                parTrnSummary(i).sTrnClass = pDataReader("取引区分").ToString
                '部門コード
                parTrnSummary(i).sBumonCode = pDataReader("部門コード").ToString
                '部門略称
                parTrnSummary(i).sBumonShortName = pDataReader("部門略称").ToString
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parTrnSummary(i).sPaymentCode = 0
                Else
                    parTrnSummary(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parTrnSummary(i).sPaymentName = pDataReader("支払方法名称").ToString
                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parTrnSummary(i).sCount = 0
                Else
                    parTrnSummary(i).sCount = CInt(pDataReader("数量の合計"))
                End If
                '税抜金額の合計
                If IsDBNull(pDataReader("税抜金額の合計")) = True Then
                    parTrnSummary(i).sNoTaxProductPrice = 0
                Else
                    parTrnSummary(i).sNoTaxProductPrice = CLng(pDataReader("税抜金額の合計"))
                End If
                '送料の合計
                If IsDBNull(pDataReader("送料の合計")) = True Then
                    parTrnSummary(i).sShippingCharge = 0
                Else
                    parTrnSummary(i).sShippingCharge = CLng(pDataReader("送料の合計"))
                End If
                '手数料の合計
                If IsDBNull(pDataReader("手数料の合計")) = True Then
                    parTrnSummary(i).sPaymentCharge = 0
                Else
                    parTrnSummary(i).sPaymentCharge = CLng(pDataReader("手数料の合計"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引きの合計")) = True Then
                    parTrnSummary(i).sDiscountPrice = 0
                Else
                    parTrnSummary(i).sDiscountPrice = CLng(pDataReader("値引きの合計"))
                End If
                'ポイント値引きの合計
                If IsDBNull(pDataReader("ポイント値引きの合計")) = True Then
                    parTrnSummary(i).sPointDiscountPrice = 0
                Else
                    parTrnSummary(i).sPointDiscountPrice = CLng(pDataReader("ポイント値引きの合計"))
                End If
                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parTrnSummary(i).sPrice = 0
                Else
                    parTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getTrnSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引の集計結果を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getTrnSummary2(ByRef parTrnSummary() As cStructureLib.sViewTrnSummary, ByVal keyCloseDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer

        Try
            strSelectTrn =
                "SELECT " &
                    "G.チャネルコード AS チャネルコード, " &
                    "G.チャネル名称 AS チャネル名称, " &
                    "G.取引区分 AS 取引区分, " &
                    "G.支払方法コード AS 支払方法コード, " &
                    "G.支払方法名称, " &
                    "Sum(G.送料) AS 送料の合計, " &
                    "Sum(G.手数料) AS 手数料の合計 " &
       "FROM " &
                "(SELECT " &
                    "日次取引データ.チャネルコード AS チャネルコード, " &
                    "チャネルマスタ.チャネル名称 AS チャネル名称, " &
                    "日次取引データ.取引区分 AS 取引区分, " &
                    "日次取引データ.支払方法コード AS 支払方法コード, " &
                    "支払方法マスタ.支払方法名称, " &
                    "日次取引データ.送料 AS 送料, " &
                    "日次取引データ.手数料 AS 手数料 " &
       "FROM " &
                    "(((日次取引データ LEFT JOIN 日次取引明細データ " &
                        "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " &
                    "LEFT JOIN チャネルマスタ " &
                        "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード) " &
                    "LEFT JOIN 部門マスタ " &
                        "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード) " &
                    "LEFT JOIN 支払方法マスタ " &
                        "ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード "

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn & "WHERE (日次取引データ.日次締め日 Is Null " &
                    "OR 日次取引データ.日次締め日 = """") "
            Else
                strSelectTrn = strSelectTrn & "WHERE 日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            strSelectTrn = strSelectTrn & "AND (日次取引データ.取引区分=""売上"" " &
                    "OR 日次取引データ.取引区分=""戻入"" " &
                    "OR 日次取引データ.取引区分=""販促"" " &
                    "OR 日次取引データ.取引区分=""社販"") " &
                "GROUP BY " &
                    "日次取引データ.チャネルコード, " &
                    "チャネルマスタ.チャネル名称, " &
                    "日次取引データ.取引区分, " &
                    "日次取引データ.支払方法コード, " &
                    "支払方法マスタ.支払方法名称, " &
                    "日次取引データ.送料, " &
                    "日次取引データ.手数料) AS G " &
      "WHERE " &
                "(G.取引区分=""売上"" " &
                    "OR G.取引区分=""戻入"" " &
                    "OR G.取引区分=""販促"" " &
                    "OR G.取引区分=""社販"") " &
                "GROUP BY " &
                    "G.チャネルコード, " &
                    "G.チャネル名称, " &
                    "G.取引区分, " &
                    "G.支払方法コード, " &
                    "G.支払方法名称 " &
                "ORDER BY " &
                    "G.取引区分, " &
                    "G.チャネルコード, " &
                    "G.支払方法コード"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parTrnSummary(i)

                'レコードが取得できた時の処理

                '送料の合計
                If IsDBNull(pDataReader("送料の合計")) = True Then
                    parTrnSummary(i).sShippingCharge = 0
                Else
                    parTrnSummary(i).sShippingCharge = CLng(pDataReader("送料の合計"))
                End If
                '手数料の合計
                If IsDBNull(pDataReader("手数料の合計")) = True Then
                    parTrnSummary(i).sPaymentCharge = 0
                Else
                    parTrnSummary(i).sPaymentCharge = CLng(pDataReader("手数料の合計"))
                End If


                'レコードが取得できた時の処理
                i = i + 1
            End While



        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '---------------------------------------------------------------------------------------------------------
    '2019/10/19 SUZUKI END
    '---------------------------------------------------------------------------------------------------------

    '----------------------------------------------------------------------
    '　機能：取引の集計結果を取得する関数(チャネル別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getChannelTrnSummary(ByRef parMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary,
                                     ByVal keyChannelCode As Integer,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keyChannelCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyFromDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        If keyToDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If


        Try
            '2019.12.19 R.Takashima  SQLの追加
            'Sum(日次取引明細データ.取引消費税額) AS 通常税額
            'Sum(日次取引明細データ.取引軽減消費税額) AS 軽減税額
            strSelectTrn =
                "SELECT " &
                    "日次取引データ.チャネルコード AS チャネルコード, " &
                    "チャネルマスタ.チャネル名称 AS チャネル名称, " &
                    "Sum(日次取引明細データ.取引数量) AS 数量の合計, " &
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計, " &
                    "Sum(日次取引明細データ.取引消費税額) AS 通常税額, " &
                    "Sum(日次取引明細データ.取引軽減消費税額) AS 軽減税額, " &
                "FROM " &
                    "(日次取引データ LEFT JOIN チャネルマスタ ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード) " &
                    "LEFT JOIN 日次取引明細データ ON 日次取引データ.取引コード = 日次取引明細データ.取引コード "

            'パラメータ指定がある場
            If (maxpc And pc) > 0 Then
                i = 1
                scnt = 0
                While i <= maxpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "チャネルコード = " & keyChannelCode & " "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "日次取引データ.日次締め日 >= """ & keyFromDate & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "日次取引データ.日次締め日 <= """ & keyToDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If pc > 0 Then
                strSelectTrn = strSelectTrn & "AND "
            Else
                strSelectTrn = strSelectTrn & "WHERE "
            End If
            strSelectTrn = strSelectTrn & "(日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"") "

            strSelectTrn = strSelectTrn & "GROUP BY " &
                                            "日次取引データ.チャネルコード, チャネルマスタ.チャネル名称 " &
                                            "ORDER BY Sum(日次取引明細データ.取引税込金額) DESC "

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()


                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                'チャネル名称
                parMonthTrnSummary(i).sName = pDataReader("チャネル名称").ToString
                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CInt(pDataReader("数量の合計"))
                End If
                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If

                '2019.12.19 R.takashima FROM
                '通常税額
                If IsDBNull(pDataReader("通常税額")) = True Then
                    parMonthTrnSummary(i).sTaxPrice = 0
                Else
                    parMonthTrnSummary(i).sReduceTaxPrice = CLng(pDataReader("通常税額"))
                End If

                '軽減税額
                If IsDBNull(pDataReader("軽減税額")) = True Then
                    parMonthTrnSummary(i).sReduceTaxPrice = 0
                Else
                    parMonthTrnSummary(i).sReduceTaxPrice = CLng(pDataReader("軽減税額"))
                End If
                '2019.12.19 R.takashima TO

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getChannelTrnSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getChannelTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引の集計結果を取得する関数(部門別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getBumonTrnSummary(ByRef parMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer


        Try
            strSelectTrn =
                "SELECT " &
                    "日次取引明細データ.部門コード AS 部門コード, " &
                    "部門マスタ.部門名称 AS 部門名称, " &
                    "Sum(日次取引明細データ.取引数量) AS 数量の合計, " &
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計, " &
                    "部門マスタ.部門種別 AS 部門種別 " &
                "FROM " &
                    "(日次取引データ LEFT JOIN 日次取引明細データ ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " &
                    "LEFT JOIN 部門マスタ ON 日次取引明細データ.部門コード = 部門マスタ.部門コード "

            strSelectTrn = strSelectTrn & "WHERE 日次取引データ.日次締め日 BetWeen """ & keyFromDate & """ " &
                                            "AND """ & keyToDate & """ " &
                                            "AND (日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"") "

            strSelectTrn = strSelectTrn & "GROUP BY " &
                                            "日次取引明細データ.部門コード, 部門マスタ.部門名称, 部門マスタ.部門種別 " &
                                            "ORDER BY Sum(日次取引明細データ.取引税込金額) DESC "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                '部門名称
                parMonthTrnSummary(i).sName = pDataReader("部門名称").ToString

                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CInt(pDataReader("数量の合計"))
                End If

                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If
                '部門名称
                If IsDBNull(pDataReader("部門種別")) = True Then
                    parMonthTrnSummary(i).sBumonClass = 0
                Else
                    parMonthTrnSummary(i).sBumonClass = CInt(pDataReader("部門種別"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getBumonTrnSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getBumonTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引の集計結果を取得する関数(支払い方法別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getPaymentTrnSummary(ByRef parMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer

        Try
            strSelectTrn =
                "SELECT " &
                    "日次取引データ.支払方法コード AS 支払方法コード, " &
                    "支払方法マスタ.支払方法名称 AS 支払方法名称, " &
                    "Sum(日次取引明細データ.取引数量) AS 数量の合計, " &
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計 " &
                "FROM " &
                    "(日次取引データ LEFT JOIN 日次取引明細データ ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " &
                    "LEFT JOIN 支払方法マスタ ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード "

            strSelectTrn = strSelectTrn & "WHERE 日次取引データ.日次締め日 BetWeen """ & keyFromDate & """ " &
                                            "AND """ & keyToDate & """ " &
                                            "AND (日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"") "

            strSelectTrn = strSelectTrn & "GROUP BY " &
                                            "日次取引データ.支払方法コード, 支払方法マスタ.支払方法名称 " &
                                          "ORDER BY Sum(日次取引明細データ.取引税込金額) DESC "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                '支払方法名称
                parMonthTrnSummary(i).sName = pDataReader("支払方法名称").ToString

                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CInt(pDataReader("数量の合計"))
                End If

                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getPaymentTrnSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getPaymentTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引の集計結果を取得する関数(カテゴリ別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getCategoryTrnSummary(ByRef parMonthTrnSummary() As cStructureLib.sViewMonthTrnSummary,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer

        Try
            '2019.12.7 R.Takashima FROM
            'カテゴリマスタがカテゴリ１マスタとカテゴリ２マスタに分かれており存在しないため読み込むことができなくエラーが発生していた
            'カテゴリ１マスタ、カテゴリ２マスタに対応できるよう修正
            strSelectTrn =
                "SELECT " &
                    "カテゴリ1マスタ.カテゴリ1名称, " &
                    "カテゴリ2マスタ.カテゴリ2名称, " &
                    "サブクエリー.取引数量の合計 AS 数量の合計, " &
                    "サブクエリー.取引税込金額の合計 AS 税込金額の合計 " &
                "FROM " &
                    "(カテゴリ1マスタ RIGHT JOIN カテゴリ2マスタ " &
                        "ON カテゴリ1マスタ.カテゴリ1ID = カテゴリ2マスタ.カテゴリ1ID) " &
                    "LEFT JOIN " &
                        "( " &
                             "SELECT " &
                                "Mid([商品コード],1,2) AS カテゴリコード, " &
                                "Sum(日次取引明細データ.取引数量) AS 取引数量の合計, " &
                                "Sum(日次取引明細データ.取引税込金額) AS 取引税込金額の合計, " &
                                "Mid([商品コード],1,1) AS カテゴリ1, " &
                                "Mid([商品コード],2,1) AS カテゴリ2 " &
                             "FROM " &
                                "日次取引データ LEFT JOIN 日次取引明細データ " &
                                "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード " &
                             "WHERE " &
                                "日次取引データ.日次締め日 BetWeen """ & keyFromDate & """ " &
                                "AND """ & keyToDate & """ " &
                                "AND (日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"") " &
                             "GROUP BY " &
                                "Mid([商品コード],1,2), " &
                                "Mid([商品コード],1,1), " &
                                "Mid([商品コード],2,1)" &
                        ") AS サブクエリー " &
                    "ON (カテゴリ2マスタ.カテゴリ1ID = サブクエリー.カテゴリ1) AND (カテゴリ2マスタ.カテゴリ2ID = サブクエリー.カテゴリ2) " &
                "ORDER BY サブクエリー.取引税込金額の合計 DESC"


            'strSelectTrn =
            '    "SELECT " &
            '        "カテゴリマスタ.カテゴリ名称_1, " &
            '        "カテゴリマスタ.カテゴリ名称_2,  " &
            '        "サブクエリー.取引数量の合計 AS 数量の合計, " &
            '        "サブクエリー.取引税込金額の合計 AS 税込金額の合計 " &
            '    "FROM " &
            '        "カテゴリマスタ RIGHT JOIN " &
            '            "(" &
            '                "SELECT " &
            '                    "Mid([商品コード],1,2) AS カテゴリコード, " &
            '                    "Sum(日次取引明細データ.取引数量) AS 取引数量の合計, " &
            '                    "Sum(日次取引明細データ.取引税込金額) AS 取引税込金額の合計, " &
            '                    "Mid([商品コード],1,1) AS カテゴリ1, " &
            '                    "Mid([商品コード],2,1) AS カテゴリ2 " &
            '                "FROM " &
            '                    "日次取引データ LEFT JOIN 日次取引明細データ " &
            '                        "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード " &
            '                "WHERE " &
            '                    "日次取引データ.日次締め日 BetWeen """ & keyFromDate & """ " &
            '                    "AND """ & keyToDate & """ " &
            '                    "AND (日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"") " &
            '                "GROUP BY " &
            '                    "Mid([商品コード],1,2), " &
            '                    "Mid([商品コード],1,1), " &
            '                    "Mid([商品コード],2,1)" &
            '            ") AS サブクエリー " &
            '                "ON (カテゴリマスタ.カテゴリID1 = サブクエリー.カテゴリ1) AND (カテゴリマスタ.カテゴリID2 = サブクエリー.カテゴリ2) " &
            '    "ORDER BY サブクエリー.取引税込金額の合計 DESC"
            '2019.12.7 R.Takashima TO


            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                'カテゴリ名称
                'parMonthTrnSummary(i).sName = pDataReader("カテゴリ名称_1").ToString & "-" & pDataReader("カテゴリ名称_2").ToString
                parMonthTrnSummary(i).sName = pDataReader("カテゴリ1名称").ToString & "-" & pDataReader("カテゴリ2名称").ToString
                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CInt(pDataReader("数量の合計"))
                End If
                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getCategoryTrnSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getCategoryTrnSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引の集計結果を取得する関数(チャネル別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getGraphSummary(ByRef parMonthTrnSummary() As cStructureLib.sGraphData,
                                       ByVal keyChannelCode As Integer,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keyChannelCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyFromDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        If keyToDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If


        Try
            strSelectTrn =
                "SELECT " &
                    "日次取引明細データ.商品コード AS 商品コード, " &
                    "Max(日次取引明細データ.商品名称) AS 商品名称, " &
                    "Max(日次取引明細データ.オプション1) AS オプション1, " &
                    "Max(日次取引明細データ.オプション2) AS オプション2, " &
                    "Max(日次取引明細データ.オプション3) AS オプション3, " &
                    "Max(日次取引明細データ.オプション4) AS オプション4, " &
                    "Max(日次取引明細データ.オプション5) AS オプション5, " &
                    "Sum(日次取引明細データ.取引数量) AS 数量の合計, " &
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額の合計, " &
                    "Sum(日次取引データ.送料) AS 送料の合計, " &
                    "Sum(日次取引データ.手数料) AS 手数料の合計, " &
                    "Sum(日次取引データ.値引き) AS 値引きの合計, " &
                    "Sum(日次取引データ.ポイント値引き) AS ポイント値引きの合計, " &
                    "Sum(日次取引データ.チケット値引き) AS チケット値引きの合計 " &
                "FROM " &
                    "(チャネルマスタ RIGHT JOIN 日次取引データ " &
                    "ON チャネルマスタ.チャネルコード = 日次取引データ.チャネルコード) " &
                    "LEFT JOIN 日次取引明細データ " &
                    "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード "

            'パラメータ指定がある場合
            If (maxpc And pc) > 0 Then
                i = 1
                scnt = 0
                While i <= maxpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "チャネルマスタ.チャネルコード = " & keyChannelCode & " "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "日次取引データ.日次締め日 >= """ & keyFromDate & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "日次取引データ.日次締め日 <= """ & keyToDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If pc > 0 Then
                strSelectTrn = strSelectTrn & "AND "
            Else
                strSelectTrn = strSelectTrn & "WHERE "
            End If
            strSelectTrn = strSelectTrn & "(日次取引データ.取引区分 = ""売上"" Or 日次取引データ.取引区分 = ""戻入"") "

            strSelectTrn = strSelectTrn & "GROUP BY " &
                                            "チャネルマスタ.チャネルコード, " &
                                            "日次取引明細データ.商品コード " &
                                        "ORDER BY Sum(日次取引明細データ.取引税込金額) DESC "

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                'チャネル名称
                parMonthTrnSummary(i).sProductCode = pDataReader("商品コード").ToString

                '商品名称
                parMonthTrnSummary(i).sProductName = pDataReader("商品名称").ToString

                'オプション
                parMonthTrnSummary(i).sOption = pDataReader("オプション1").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション2").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション2").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション3").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション3").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション4").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション4").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション5").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション5").ToString

                '数量の合計
                If IsDBNull(pDataReader("数量の合計")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CLng(pDataReader("数量の合計"))
                End If

                '税込金額の合計
                If IsDBNull(pDataReader("税込金額の合計")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("税込金額の合計"))
                End If

                '送料の合計
                If IsDBNull(pDataReader("送料の合計")) = True Then
                    parMonthTrnSummary(i).sPostage = 0
                Else
                    parMonthTrnSummary(i).sPostage = CLng(pDataReader("送料の合計"))
                End If

                '手数料の合計
                If IsDBNull(pDataReader("手数料の合計")) = True Then
                    parMonthTrnSummary(i).sFee = 0
                Else
                    parMonthTrnSummary(i).sFee = CLng(pDataReader("手数料の合計"))
                End If

                '値引きの合計
                If IsDBNull(pDataReader("値引きの合計")) = True Then
                    parMonthTrnSummary(i).sDisCount = 0
                Else
                    parMonthTrnSummary(i).sDisCount = CLng(pDataReader("値引きの合計"))
                End If

                'ポイント値引きの合計
                If IsDBNull(pDataReader("ポイント値引きの合計")) = True Then
                    parMonthTrnSummary(i).sPointDisCount = 0
                Else
                    parMonthTrnSummary(i).sPointDisCount = CLng(pDataReader("ポイント値引きの合計"))
                End If

                'チケット値引きの合計
                If IsDBNull(pDataReader("チケット値引きの合計")) = True Then
                    parMonthTrnSummary(i).sTicketDisCount = 0
                Else
                    parMonthTrnSummary(i).sTicketDisCount = CLng(pDataReader("チケット値引きの合計"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getGraphSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getGraphSummary)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：入庫の集計結果を取得する関数(仕入先別)
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getArrivalSummary(ByRef parMonthTrnSummary() As cStructureLib.sViewArrivalSummary,
                                       ByVal keySupplierCode As Integer,
                                       ByVal keyFromDate As String,
                                       ByVal keyToDate As String,
                                       ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If keySupplierCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If keyFromDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        If keyToDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If


        Try
            strSelectTrn =
                "SELECT " &
                    "入庫情報データ.入庫日 AS 入庫日, " &
                    "入庫情報データ.仕入先コード AS 仕入先コード, " &
                    "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                    "入庫情報明細データ.商品コード AS 商品コード, " &
                    "Max(入庫情報明細データ.JANコード) AS JANコード, " &
                    "Max(入庫情報明細データ.商品名称) AS 商品名称, " &
                    "Max(入庫情報明細データ.オプション1) AS オプション1, " &
                    "Max(入庫情報明細データ.オプション2) AS オプション2, " &
                    "Max(入庫情報明細データ.オプション3) AS オプション3, " &
                    "Max(入庫情報明細データ.オプション4) AS オプション4, " &
                    "Max(入庫情報明細データ.オプション5) AS オプション5, " &
                    "Max(入庫情報明細データ.定価) AS 定価, " &
                    "Max(入庫情報明細データ.仕入単価) AS 仕入単価, " &
                    "Max(入庫情報明細データ.入庫商品単価) AS 入庫商品単価, " &
                    "Sum(入庫情報明細データ.入庫数量) AS 入庫数量, " &
                    "Sum(入庫情報明細データ.入庫税抜金額) AS 入庫商品税抜金額, " &
                    "Sum(入庫情報明細データ.入庫消費税額) AS 入庫商品消費税額, " &
                    "Sum(入庫情報明細データ.入庫軽減税額) AS 入庫商品軽減税額, " &
                    "Sum(入庫情報明細データ.入庫税込金額) AS 入庫商品税込金額 " &
                "FROM " &
                    "(入庫情報データ LEFT JOIN 入庫情報明細データ ON " &
                    "(入庫情報データ.入庫番号 = 入庫情報明細データ.入庫番号) " &
                    "AND " &
                    "(入庫情報データ.発注コード = 入庫情報明細データ.発注コード)) " &
                    "LEFT JOIN 仕入先マスタ ON 入庫情報データ.仕入先コード = 仕入先マスタ.仕入先コード  "

            'パラメータ指定がある場合
            If (maxpc And pc) > 0 Then
                i = 1
                scnt = 0
                While i <= maxpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "入庫情報データ.仕入先コード = " & keySupplierCode & " "
                            scnt = scnt + 1

                        Case 2
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "(入庫情報データ.入庫日 >= """ & keyFromDate & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelectTrn = strSelectTrn & "AND "
                            Else
                                strSelectTrn = strSelectTrn & "WHERE "
                            End If
                            strSelectTrn = strSelectTrn & "入庫情報データ.入庫日 <= """ & keyToDate & """) "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If pc > 0 Then
                strSelectTrn = strSelectTrn & "AND "
            Else
                strSelectTrn = strSelectTrn & "WHERE "
            End If
            strSelectTrn = strSelectTrn & "入庫情報明細データ.入庫数量 <> 0 "

            strSelectTrn = strSelectTrn & "GROUP BY " &
                                             "入庫情報データ.入庫日, " &
                                             "入庫情報データ.仕入先コード, " &
                                             "仕入先マスタ.仕入先名称, " &
                                             "入庫情報明細データ.商品コード " &
                                          "ORDER BY " &
                                             "入庫情報データ.入庫日, " &
                                             "入庫情報データ.仕入先コード "


            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parMonthTrnSummary(i)

                'レコードが取得できた時の処理
                '入庫日
                parMonthTrnSummary(i).sArrivalDate = pDataReader("入庫日").ToString

                '仕入先名称
                parMonthTrnSummary(i).sSupplierName = pDataReader("仕入先名称").ToString

                '商品コード
                parMonthTrnSummary(i).sProductCode = pDataReader("商品コード").ToString

                'JANコード
                parMonthTrnSummary(i).sJANCode = pDataReader("JANコード").ToString

                '商品名称
                parMonthTrnSummary(i).sProductName = pDataReader("商品名称").ToString

                'オプション
                parMonthTrnSummary(i).sOption = pDataReader("オプション1").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション2").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション2").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション3").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション3").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション4").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション4").ToString
                If parMonthTrnSummary(i).sOption <> "" And pDataReader("オプション5").ToString <> "" Then
                    parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & " / "
                End If
                parMonthTrnSummary(i).sOption = parMonthTrnSummary(i).sOption & pDataReader("オプション5").ToString

                '入庫商品単価
                If IsDBNull(pDataReader("入庫商品単価")) = True Then
                    parMonthTrnSummary(i).sUnitPrice = 0
                Else
                    parMonthTrnSummary(i).sUnitPrice = CLng(pDataReader("入庫商品単価"))
                End If

                '入庫数量
                If IsDBNull(pDataReader("入庫数量")) = True Then
                    parMonthTrnSummary(i).sCount = 0
                Else
                    parMonthTrnSummary(i).sCount = CInt(pDataReader("入庫数量"))
                End If

                '入庫商品税抜金額
                If IsDBNull(pDataReader("入庫商品税抜金額")) = True Then
                    parMonthTrnSummary(i).sNoTaxPrice = 0
                Else
                    parMonthTrnSummary(i).sNoTaxPrice = CLng(pDataReader("入庫商品税抜金額"))
                End If

                '入庫商品消費税額
                If IsDBNull(pDataReader("入庫商品消費税額")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("入庫商品消費税額"))
                End If

                '2019,12,16 A.Komita 追加 From
                '入庫商品軽減税額
                If IsDBNull(pDataReader("入庫商品軽減税額")) = True Then
                    parMonthTrnSummary(i).sReducedTaxRate = 0
                Else
                    parMonthTrnSummary(i).sReducedTaxRate = CLng(pDataReader("入庫商品軽減税額"))
                End If
                '2019,12,16 A.Komita 追加 To

                '入庫商品税込金額
                If IsDBNull(pDataReader("入庫商品税込金額")) = True Then
                    parMonthTrnSummary(i).sPrice = 0
                Else
                    parMonthTrnSummary(i).sPrice = CLng(pDataReader("入庫商品税込金額"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getArrivalSummary = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnSummaryDBIO.getArrivalSummary)", Nothing, Nothing, oExcept.ToString)
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
