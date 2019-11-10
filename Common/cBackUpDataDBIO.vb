Public Class cBackUpDataDBIO
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
    '　機能：日次取引情報を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getTrnFull(ByRef parTrnFull() As cStructureLib.sViewTrnFull, _
                               ByVal keyFromCloseDate As String, _
                               ByVal keyToCloseDate As String, _
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

            strSelect = "SELECT  " & _
                            "日次取引データ.取引コード AS 取引コード, " & _
                            "日次取引明細データ.取引明細コード AS 取引明細コード, " & _
                            "日次取引データ.取引区分 AS 取引区分, " & _
                            "日次取引データ.チャネルコード AS チャネルコード, " & _
                            "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                            "日次取引データ.支払方法コード AS 支払方法コード, " & _
                            "支払方法マスタ.支払方法名称 AS 支払方法名称, " & _
                            "日次取引データ.取引税抜商品金額 AS 取引合計税抜商品金額, " & _
                            "日次取引データ.送料 AS 送料, " & _
                            "日次取引データ.手数料 AS 手数料, " & _
                            "日次取引データ.値引き AS 合計値引き, " & _
                            "日次取引データ.ポイント値引き AS 合計ポイント値引き, " & _
                            "日次取引データ.取引税抜金額 AS 取引合計税抜金額, " & _
                            "日次取引データ.取引消費税額 AS 取引合計消費税額, " & _
                            "日次取引データ.取引税込金額 AS 取引合計税込金額, " & _
                            "日次取引データ.出荷コード AS 出荷コード, " & _
                            "日次取引データ.会員コード AS 会員コード, " & _
                            "日次取引データ.性別 AS 性別, " & _
                            "日次取引データ.年代 AS 年代, " & _
                            "日次取引データ.天気 AS 天気, " & _
                            "日次取引データ.日次締め日 AS 日次締め日, " & _
                            "日次取引データ.月次締め日 AS 月次締め日, " & _
                            "日次取引データ.取引担当者コード AS 取引担当者コード, " & _
                            "日次取引明細データ.売上状態 AS 売上状態, " & _
                            "日次取引明細データ.売上明細区分 AS 売上明細区分, " & _
                            "日次取引明細データ.部門コード AS 部門コード, " & _
                            "日次取引明細データ.商品コード AS 商品コード, " & _
                            "日次取引明細データ.商品名称 AS 商品名称, " & _
                            "日次取引明細データ.JANコード AS JANコード, " & _
                            "日次取引明細データ.オプション1 AS オプション1, " & _
                            "日次取引明細データ.オプション2 AS オプション2, " & _
                            "日次取引明細データ.オプション3 AS オプション3, " & _
                            "日次取引明細データ.オプション4 AS オプション4, " & _
                            "日次取引明細データ.オプション5 AS オプション5, " & _
                            "日次取引明細データ.定価 AS 定価, " & _
                            "日次取引明細データ.仕入単価 AS 仕入単価, " & _
                            "日次取引明細データ.取引商品単価 AS 取引商品単価, " & _
                            "日次取引明細データ.取引数量 AS 取引数量, " & _
                            "日次取引明細データ.取引税抜商品金額 AS 取引税抜商品金額, " & _
                            "日次取引明細データ.値引き AS 単品値引き, " & _
                            "日次取引明細データ.ポイント値引き AS 単品ポイント値引き, " & _
                            "日次取引明細データ.取引税抜金額 AS 取引税抜金額, " & _
                            "日次取引明細データ.取引消費税額 AS 取引消費税額, " & _
                            "日次取引明細データ.取引税込金額 AS 取引税込金額 " & _
                        "FROM ( " & _
                            "(日次取引データ LEFT JOIN 日次取引明細データ " & _
                            "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                            "LEFT JOIN 支払方法マスタ " & _
                            "ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード) " & _
                            "LEFT JOIN チャネルマスタ " & _
                            "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード "

            'パラメータ数のカウント
            pc = 0
            maxpc = 0
            If keyFromCloseDate <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyToCloseDate <> Nothing Then
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
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            If keyFromCloseDate = "-1" Then
                                strSelect = strSelect & "日次取引データ.日次締め日 = """" " & _
                                                            " Or 日次取引データ.日次締め日 Is Null "
                            Else
                                If keyToCloseDate = Nothing Then
                                    strSelect = strSelect & "日次取引データ.日次締め日 = """ & keyFromCloseDate & """ "
                                Else
                                    strSelect = strSelect & "日次取引データ.日次締め日 >= """ & keyFromCloseDate & """ "
                                End If
                            End If
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "日次取引データ.日次締め日 <= """ & keyToCloseDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If



            strSelect = strSelect & "ORDER BY 日次取引データ.取引コード, 日次取引明細データ.取引明細コード"


            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parTrnFull(i)

                '取引コード
                If IsDBNull(pDataReader("取引コード")) = True Then
                    parTrnFull(i).sTrnCode = 0
                Else
                    parTrnFull(i).sTrnCode = CLng(pDataReader("取引コード"))
                End If
                '取引明細コード
                If IsDBNull(pDataReader("取引明細コード")) = True Then
                    parTrnFull(i).sSubTrnCode = 0
                Else
                    parTrnFull(i).sSubTrnCode = CLng(pDataReader("取引明細コード"))
                End If
                '取引区分
                parTrnFull(i).sTrnClass = pDataReader("取引区分").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parTrnFull(i).sChannelCode = 0
                    parTrnFull(i).sChannelName = ""
                Else
                    parTrnFull(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                    parTrnFull(i).sChannelName = pDataReader("チャネル名称").ToString
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parTrnFull(i).sPaymentCode = 0
                Else
                    parTrnFull(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parTrnFull(i).sPaymentName = pDataReader("支払方法名称").ToString
                '取引合計税抜商品金額
                If IsDBNull(pDataReader("取引合計税抜商品金額")) = True Then
                    parTrnFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parTrnFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("取引合計税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parTrnFull(i).sShippingCharge = 0
                Else
                    parTrnFull(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parTrnFull(i).sPaymentCharge = 0
                Else
                    parTrnFull(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("合計値引き")) = True Then
                    parTrnFull(i).sTotalDiscount = 0
                Else
                    parTrnFull(i).sTotalDiscount = CLng(pDataReader("合計値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("合計ポイント値引き")) = True Then
                    parTrnFull(i).sTotalPointDisCount = 0
                Else
                    parTrnFull(i).sTotalPointDisCount = CLng(pDataReader("合計ポイント値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引合計税抜金額")) = True Then
                    parTrnFull(i).sNoTaxTotalPrice = 0
                Else
                    parTrnFull(i).sNoTaxTotalPrice = CLng(pDataReader("取引合計税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引合計消費税額")) = True Then
                    parTrnFull(i).sTaxTotal = 0
                Else
                    parTrnFull(i).sTaxTotal = CLng(pDataReader("取引合計消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引合計税込金額")) = True Then
                    parTrnFull(i).sTotalPrice = 0
                Else
                    parTrnFull(i).sTotalPrice = CLng(pDataReader("取引合計税込金額"))
                End If
                '出荷コード
                parTrnFull(i).sShipCode = pDataReader("出荷コード").ToString
                '会員コード
                parTrnFull(i).sMemberCode = pDataReader("会員コード").ToString
                '性別
                parTrnFull(i).sSex = pDataReader("性別").ToString
                '年代
                If IsDBNull(pDataReader("年代")) = True Then
                    parTrnFull(i).sGeneration = 0
                Else
                    parTrnFull(i).sGeneration = CInt(pDataReader("年代"))
                End If
                '天気
                parTrnFull(i).sWeather = pDataReader("天気").ToString
                '日次締め日
                parTrnFull(i).sDayCloseDate = pDataReader("日次締め日").ToString
                '月次締め日
                parTrnFull(i).sMonthCloseDate = pDataReader("月次締め日").ToString
                '取引担当者コード
                parTrnFull(i).sStaffCode = pDataReader("取引担当者コード").ToString
                '売上状態
                parTrnFull(i).sStatus = pDataReader("売上状態").ToString
                '売上明細区分
                If IsDBNull(pDataReader("売上明細区分")) = True Then
                    parTrnFull(i).sSubTrnClass = 0
                Else
                    parTrnFull(i).sSubTrnClass = CInt(pDataReader("売上明細区分"))
                End If
                '部門コード
                parTrnFull(i).sBumonCode = pDataReader("部門コード").ToString
                '商品コード
                parTrnFull(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parTrnFull(i).sProductName = pDataReader("商品名称").ToString
                'JANコード
                parTrnFull(i).sJANCode = pDataReader("JANコード").ToString
                'オプション1
                parTrnFull(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parTrnFull(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parTrnFull(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parTrnFull(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parTrnFull(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parTrnFull(i).sListPrice = 0
                Else
                    parTrnFull(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parTrnFull(i).sCostPrice = 0
                Else
                    parTrnFull(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '取引商品単価
                If IsDBNull(pDataReader("取引商品単価")) = True Then
                    parTrnFull(i).sUnitPrice = 0
                Else
                    parTrnFull(i).sUnitPrice = CLng(pDataReader("取引商品単価"))
                End If
                '取引数量
                If IsDBNull(pDataReader("取引数量")) = True Then
                    parTrnFull(i).sCount = 0
                Else
                    parTrnFull(i).sCount = CInt(pDataReader("取引数量"))
                End If
                '取引税抜商品金額
                If IsDBNull(pDataReader("取引税抜商品金額")) = True Then
                    parTrnFull(i).sNoTaxProductPrice = 0
                Else
                    parTrnFull(i).sNoTaxProductPrice = CLng(pDataReader("取引税抜商品金額"))
                End If
                '単品値引き
                If IsDBNull(pDataReader("単品値引き")) = True Then
                    parTrnFull(i).sDiscountPrice = 0
                Else
                    parTrnFull(i).sDiscountPrice = CLng(pDataReader("単品値引き"))
                End If
                '単品ポイント値引き
                If IsDBNull(pDataReader("単品ポイント値引き")) = True Then
                    parTrnFull(i).sPointDiscountPrice = 0
                Else
                    parTrnFull(i).sPointDiscountPrice = CLng(pDataReader("単品ポイント値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引税抜金額")) = True Then
                    parTrnFull(i).sNoTaxPrice = 0
                Else
                    parTrnFull(i).sNoTaxPrice = CLng(pDataReader("取引税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引消費税額")) = True Then
                    parTrnFull(i).sTaxPrice = 0
                Else
                    parTrnFull(i).sTaxPrice = CLng(pDataReader("取引消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引税込金額")) = True Then
                    parTrnFull(i).sPrice = 0
                Else
                    parTrnFull(i).sPrice = CLng(pDataReader("取引税込金額"))
                End If
                i = i + 1
            End While

            getTrnFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnFullDBIO.getTrnFull)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引情報を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getFinTrnFull(ByRef parFinTrnFull() As cStructureLib.sViewFinTrnFull, _
                               ByVal keyFromCloseDate As String, _
                               ByVal keyToCloseDate As String, _
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
                            "日次取引データ.取引コード AS 取引コード, " & _
                            "日次取引データ.取引区分 AS 取引区分, " & _
                            "日次取引データ.チャネルコード AS チャネルコード, " & _
                            "日次取引データ.支払方法コード AS 支払方法コード, " & _
                            "支払方法マスタ.支払方法名称 AS 支払方法名称, " & _
                            "日次取引データ.取引税抜商品金額 AS 取引合計税抜商品金額, " & _
                            "日次取引データ.送料 AS 送料, " & _
                            "日次取引データ.手数料 AS 手数料, " & _
                            "日次取引データ.値引き AS 合計値引き, " & _
                            "日次取引データ.ポイント値引き AS 合計ポイント値引き, " & _
                            "日次取引データ.取引税抜金額 AS 取引合計税抜金額, " & _
                            "日次取引データ.取引消費税額 AS 取引合計消費税額, " & _
                            "日次取引データ.取引税込金額 AS 取引合計税込金額, " & _
                            "日次取引データ.日次締め日 AS 日次締め日, " & _
                            "日次取引データ.月次締め日 AS 月次締め日, " & _
                            "日次取引明細データ.売上状態 AS 売上状態, " & _
                            "日次取引明細データ.部門コード AS 部門コード, " & _
                            "部門マスタ.部門名称 AS 部門名称, " & _
                            "Sum(日次取引明細データ.取引税抜商品金額) AS 取引税抜商品金額, " & _
                            "Sum(日次取引明細データ.値引き) AS 単品値引き, " & _
                            "Sum(日次取引明細データ.ポイント値引き) AS 単品ポイント値引き, " & _
                            "Sum(日次取引明細データ.取引税抜金額) AS 取引税抜金額, " & _
                            "Sum(日次取引明細データ.取引消費税額) AS 取引消費税額, " & _
                            "Sum(日次取引明細データ.取引税込金額) AS 取引税込金額 " & _
                        "FROM " & _
                            "((日次取引データ LEFT JOIN 日次取引明細データ " & _
                                "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                            "LEFT JOIN 支払方法マスタ " & _
                                "ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード) " & _
                            "LEFT JOIN 部門マスタ " & _
                                "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード " & _
                        "GROUP BY " & _
                            "日次取引データ.取引コード, " & _
                            "日次取引データ.取引区分, " & _
                            "日次取引データ.チャネルコード, " & _
                            "日次取引データ.支払方法コード, " & _
                            "支払方法マスタ.支払方法名称, " & _
                            "日次取引データ.取引税抜商品金額, " & _
                            "日次取引データ.送料, " & _
                            "日次取引データ.手数料, " & _
                            "日次取引データ.値引き, " & _
                            "日次取引データ.ポイント値引き, " & _
                            "日次取引データ.取引税抜金額, " & _
                            "日次取引データ.取引消費税額, " & _
                            "日次取引データ.取引税込金額, " & _
                            "日次取引データ.日次締め日, " & _
                            "日次取引データ.月次締め日, " & _
                            "日次取引明細データ.売上状態, " & _
                            "日次取引明細データ.部門コード, " & _
                            "部門マスタ.部門名称 "

            'パラメータ数のカウント
            pc = 0
            maxpc = 0
            If keyFromCloseDate <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyToCloseDate <> Nothing Then
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
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "HAVING "
                            End If
                            If keyFromCloseDate = "-1" Then
                                strSelect = strSelect & "日次取引データ.日次締め日 = """" " & _
                                                            " Or 日次取引データ.日次締め日 Is Null "
                            Else
                                If keyToCloseDate = Nothing Then
                                    strSelect = strSelect & "日次取引データ.日次締め日 = """ & keyFromCloseDate & """ "
                                Else
                                    strSelect = strSelect & "日次取引データ.日次締め日 >= """ & keyFromCloseDate & """ "
                                End If
                            End If
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "HAVING "
                            End If
                            strSelect = strSelect & "日次取引データ.日次締め日 <= """ & keyToCloseDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parFinTrnFull(i)

                '取引コード
                If IsDBNull(pDataReader("取引コード")) = True Then
                    parFinTrnFull(i).sTrnCode = 0
                Else
                    parFinTrnFull(i).sTrnCode = CLng(pDataReader("取引コード"))
                End If
                '取引区分
                parFinTrnFull(i).sTrnClass = pDataReader("取引区分").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parFinTrnFull(i).sChannel = 0
                Else
                    parFinTrnFull(i).sChannel = CInt(pDataReader("チャネルコード"))
                End If
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parFinTrnFull(i).sPaymentCode = 0
                Else
                    parFinTrnFull(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parFinTrnFull(i).sPaymentName = pDataReader("支払方法名称").ToString
                '取引合計税抜商品金額
                If IsDBNull(pDataReader("取引合計税抜商品金額")) = True Then
                    parFinTrnFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parFinTrnFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("取引合計税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parFinTrnFull(i).sShippingCharge = 0
                Else
                    parFinTrnFull(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parFinTrnFull(i).sPaymentCharge = 0
                Else
                    parFinTrnFull(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("合計値引き")) = True Then
                    parFinTrnFull(i).sTotalDiscount = 0
                Else
                    parFinTrnFull(i).sTotalDiscount = CLng(pDataReader("合計値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("合計ポイント値引き")) = True Then
                    parFinTrnFull(i).sTotalPointDisCount = 0
                Else
                    parFinTrnFull(i).sTotalPointDisCount = CLng(pDataReader("合計ポイント値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引合計税抜金額")) = True Then
                    parFinTrnFull(i).sNoTaxTotalPrice = 0
                Else
                    parFinTrnFull(i).sNoTaxTotalPrice = CLng(pDataReader("取引合計税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引合計消費税額")) = True Then
                    parFinTrnFull(i).sTaxTotal = 0
                Else
                    parFinTrnFull(i).sTaxTotal = CLng(pDataReader("取引合計消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引合計税込金額")) = True Then
                    parFinTrnFull(i).sTotalPrice = 0
                Else
                    parFinTrnFull(i).sTotalPrice = CLng(pDataReader("取引合計税込金額"))
                End If
                '日次締め日
                parFinTrnFull(i).sDayCloseDate = pDataReader("日次締め日").ToString
                '月次締め日
                parFinTrnFull(i).sMonthCloseDate = pDataReader("月次締め日").ToString
                '売上状態
                parFinTrnFull(i).sStatus = pDataReader("売上状態").ToString
                '部門コード
                parFinTrnFull(i).sBumonCode = pDataReader("部門コード").ToString
                '部門名称
                parFinTrnFull(i).sBumonName = pDataReader("部門名称").ToString
                '取引税抜商品金額
                If IsDBNull(pDataReader("取引税抜商品金額")) = True Then
                    parFinTrnFull(i).sNoTaxProductPrice = 0
                Else
                    parFinTrnFull(i).sNoTaxProductPrice = CLng(pDataReader("取引税抜商品金額"))
                End If
                '単品値引き
                If IsDBNull(pDataReader("単品値引き")) = True Then
                    parFinTrnFull(i).sDiscountPrice = 0
                Else
                    parFinTrnFull(i).sDiscountPrice = CLng(pDataReader("単品値引き"))
                End If
                '単品ポイント値引き
                If IsDBNull(pDataReader("単品ポイント値引き")) = True Then
                    parFinTrnFull(i).sPointDiscountPrice = 0
                Else
                    parFinTrnFull(i).sPointDiscountPrice = CLng(pDataReader("単品ポイント値引き"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引税抜金額")) = True Then
                    parFinTrnFull(i).sNoTaxPrice = 0
                Else
                    parFinTrnFull(i).sNoTaxPrice = CLng(pDataReader("取引税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引消費税額")) = True Then
                    parFinTrnFull(i).sTaxPrice = 0
                Else
                    parFinTrnFull(i).sTaxPrice = CLng(pDataReader("取引消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引税込金額")) = True Then
                    parFinTrnFull(i).sPrice = 0
                Else
                    parFinTrnFull(i).sPrice = CLng(pDataReader("取引税込金額"))
                End If
                i = i + 1
            End While

            getFinTrnFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewTrnFullDBIO.getFinTrnFull)", Nothing, Nothing, oExcept.ToString)
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
