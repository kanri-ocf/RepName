Public Class cViewCandidateDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage
    Private pToolDBIO As cToolDBIO

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader

        pToolDBIO = New cToolDBIO
    End Sub

    Private Sub SQL_MAKE(ByRef pc As Integer, _
                            ByRef maxpc As Integer, _
                            ByRef strSelect As String, _
                            ByRef KeyFromDate As String, _
                            ByRef KeyToDate As String, _
                            ByRef KeyCycleDate As String, _
                            ByRef KeyMinCount As String, _
                            ByVal KeyProductName As String, _
                            ByVal KeyOptionName As String, _
                            ByVal KeyProductCode As String, _
                            ByVal KeyJANCode As String, _
                            ByVal KeySelStatus As String, _
                            ByRef KeyBumonName As String, _
                            ByRef KeySupplierName As String)

        Dim strSelect1 As String
        Dim strSelect2 As String
        Dim strWhere As String
        Dim strGroup As String
        Dim strHaving As String
        Dim strOrderBy As String
        Dim scnt As Integer
        Dim i As Long

        strSelect1 = ""
        strSelect2 = ""
        strWhere = ""
        strGroup = ""
        strHaving = ""
        strOrderBy = ""

        '抽出期間のデータを抽出
        strSelect = strSelect & _
                    "SELECT " & _
                    "発注候補選択状態データ.選択状態 AS 選択状態, " & _
                    "日次取引明細データ.商品コード AS 商品コード, " & _
                    "First(日次取引明細データ.商品名称) AS 商品名称, " & _
                    "First(日次取引明細データ.JANコード) AS JANコード, " & _
                    "First(日次取引明細データ.オプション1) AS オプション1, " & _
                    "First(日次取引明細データ.オプション2) AS オプション2, " & _
                    "First(日次取引明細データ.オプション3) AS オプション3, " & _
                    "First(日次取引明細データ.オプション4) AS オプション4, " & _
                    "First(日次取引明細データ.オプション5) AS オプション5, " & _
                    "First(日次取引明細データ.定価) AS 定価, " & _
                    "First(仕入先マスタ.仕入先名称) AS 仕入先名称, " & _
                    "First(仕入価格マスタ.仕入単価) AS 仕入単価, " & _
                    "Sum(日次取引明細データ.取引数量) AS 数量, " & _
                    "Sum(日次取引明細データ.取引税込金額) AS 税込金額, " & _
                    "在庫マスタ.在庫数 " & _
                "FROM " & _
                    "( " & _
                        "仕入先マスタ RIGHT JOIN " & _
                        "( " & _
                            "( " & _
                                "仕入価格マスタ RIGHT JOIN  " & _
                                "( " & _
                                    "( " & _
                                        "日次取引データ LEFT JOIN 日次取引明細データ  " & _
                                        "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード " & _
                                    ")  " & _
                                    "LEFT JOIN 在庫マスタ  " & _
                                    " ON 日次取引明細データ.商品コード = 在庫マスタ.商品コード " & _
                                ")  " & _
                                "ON 仕入価格マスタ.商品コード = 日次取引明細データ.商品コード " & _
                            ")  " & _
                            "LEFT JOIN 発注候補選択状態データ  " & _
                            "ON 日次取引明細データ.商品コード = 発注候補選択状態データ.商品コード " & _
                        ")  " & _
                        "ON 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " & _
                    ")  " & _
                    "LEFT JOIN 部門マスタ  " & _
                    "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード  "

        '************************
        'パラメータ指定がある場合
        '************************

        ' Where区生成
        If maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1      'KeyFromDate
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "日次取引データ.日次締め日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1

                    Case 2      'KeyToDate
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "日次取引データ.日次締め日 <= """ & KeyToDate & """ "
                        scnt = scnt + 1
                    Case 4      'KeyCycleDate
                        scnt = scnt + 1
                    Case 8      'KeyMinCount
                        scnt = scnt + 1
                    Case 16      'KeyProductName
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "日次取引明細データ.商品名称 Like ""%" & KeyProductName & "%"" "
                        scnt = scnt + 1
                    Case 32      'KeyOptionName
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "(日次取引明細データ.オプション1 Like ""%" & KeyOptionName & "%"" "
                        strWhere = strWhere & "OR 日次取引明細データ.オプション2 Like ""%" & KeyOptionName & "%"" "
                        strWhere = strWhere & "OR 日次取引明細データ.オプション3 Like ""%" & KeyOptionName & "%"" "
                        strWhere = strWhere & "OR 日次取引明細データ.オプション4 Like ""%" & KeyOptionName & "%"" "
                        strWhere = strWhere & "OR 日次取引明細データ.オプション5 Like ""%" & KeyOptionName & "%"") "
                        scnt = scnt + 1
                    Case 64      'KeyProductCode
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "日次取引明細データ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 128      'KeyJANCode
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "日次取引明細データ.JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                    Case 256      'KeySelStatus
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "発注候補選択状態データ.選択状態 = " & KeySelStatus & " "
                        scnt = scnt + 1
                    Case 512      'KeyBumonName
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "部門マスタ.部門名称 = """ & KeyBumonName & """ "
                        scnt = scnt + 1
                    Case 1024      'KeySupplierName
                        If scnt > 0 Then
                            strWhere = strWhere & "AND "
                        Else
                            strWhere = strWhere & "WHERE "
                        End If
                        strWhere = strWhere & "仕入先マスタ.仕入先名称 = """ & KeySupplierName & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        '売上サイクル内のデータ抽出
        strWhere = strWhere & "AND 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " & _
                                    "AND 日次取引明細データ.商品コード IN ( " & _
                                        "SELECT DISTINCT " & _
                                            "日次取引明細データ.商品コード " & _
                                         "FROM " & _
                                            "日次取引明細データ RIGHT JOIN 日次取引データ " & _
                                            "ON 日次取引明細データ.取引コード = 日次取引データ.取引コード " & _
                                         "WHERE " & _
                                            "(日次取引明細データ.商品コード Is Not Null) " & _
                                            "AND (日次取引明細データ.商品コード <> """") " & _
                                            "AND 日次取引データ.日次締め日 >= """ & KeyCycleDate & """ " & _
                                            "AND 日次取引データ.日次締め日 < """ & KeyFromDate & """ " & _
                                    ") "

        ' Group区生成
        strGroup = strGroup & "GROUP BY " & _
                                "発注候補選択状態データ.選択状態, " & _
                                "日次取引明細データ.商品コード, " & _
                                "在庫マスタ.在庫数 "

        ' Having区生成
        If maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1      'KeyFromDate
                        scnt = scnt + 1
                    Case 2      'KeyToDate
                        scnt = scnt + 1
                    Case 4      'KeyBumonName
                        scnt = scnt + 1
                    Case 8      'KeySupplierName
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        If strHaving = "" Then
            strHaving = strHaving & "HAVING "
        Else
            strHaving = strHaving & "AND "
        End If
        strHaving = strHaving & "(" & _
                                         "(日次取引明細データ.商品コード) Is Not Null " & _
                                         "AND Not (日次取引明細データ.商品コード) = """") " & _
                                         "AND Sum(日次取引明細データ.取引数量) >= " & KeyMinCount & " "


        ' ORDER BY区生成
        strOrderBy = strOrderBy & "ORDER BY Sum(日次取引明細データ.取引数量) DESC "

        strSelect = strSelect & strWhere & strGroup & strHaving & strOrderBy

    End Sub
    '----------------------------------------------------------------------
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getCandidate(ByRef parCandidate() As cStructureLib.sViewCandidate, _
                                   ByVal KeyFromDate As String, _
                                   ByVal KeyToDate As String, _
                                   ByVal KeyCycleDate As String, _
                                   ByVal KeyMinCount As String, _
                                   ByVal KeyProductName As String, _
                                   ByVal KeyOptionName As String, _
                                   ByVal KeyProductCode As String, _
                                   ByVal KeyJANCode As String, _
                                   ByVal KeySelStatus As Boolean, _
                                   ByVal KeyBumonName As String, _
                                   ByVal KeySupplierName As String, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim maxpc As Integer
        Dim ret As Boolean
        Dim pSelStatus As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '選択状態のステータス設定
        If KeySelStatus = False Then
            pSelStatus = Nothing
        Else
            pSelStatus = KeySelStatus
        End If

        ret = pToolDBIO.argCal( _
                            pc, _
                            maxpc, _
                            KeyFromDate, _
                            KeyToDate, _
                            KeyCycleDate, _
                            KeyMinCount, _
                            KeyProductName, _
                            KeyOptionName, _
                            KeyProductCode, _
                            KeyJANCode, _
                            pSelStatus, _
                            KeyBumonName, _
                            KeySupplierName _
                        )

        strSelect = ""

        SQL_MAKE( _
                pc, _
                maxpc, _
                strSelect, _
                KeyFromDate, _
                KeyToDate, _
                KeyCycleDate, _
                KeyMinCount, _
                KeyProductName, _
                KeyOptionName, _
                KeyProductCode, _
                KeyJANCode, _
                pSelStatus, _
                KeyBumonName, _
                KeySupplierName _
            )

        getCandidate = -1

        'SQL文の設定
        pCommand.CommandText = strSelect

        Try
            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parCandidate(i)

                '選択状態
                If IsDBNull(pDataReader("選択状態")) Then
                    parCandidate(i).sStatus = False
                Else
                    parCandidate(i).sStatus = CBool(pDataReader("選択状態"))
                End If

                '仕入先名称
                parCandidate(i).sSupplierName = pDataReader("仕入先名称").ToString
                'JANコード
                parCandidate(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parCandidate(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parCandidate(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parCandidate(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2"
                parCandidate(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3"
                parCandidate(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4"
                parCandidate(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5"
                parCandidate(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = False Then
                    parCandidate(i).sPrice = CLng(pDataReader("定価"))
                Else
                    parCandidate(i).sPrice = 0
                End If
                '仕入価格
                If IsDBNull(pDataReader("仕入単価")) = False Then
                    parCandidate(i).sCostPrice = CLng(pDataReader("仕入単価"))
                Else
                    parCandidate(i).sCostPrice = 0
                End If
                '数量
                If IsDBNull(pDataReader("数量")) = False Then
                    parCandidate(i).sCount = CInt(pDataReader("数量"))
                Else
                    parCandidate(i).sCount = 0
                End If
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = False Then
                    parCandidate(i).sStockCount = CInt(pDataReader("在庫数"))
                Else
                    parCandidate(i).sStockCount = 0
                End If

                i = i + 1

            End While

            getCandidate = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewCandidateDBIO.getCandidate)", Nothing, Nothing, oExcept.ToString)
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
    ''　機能：日次取引データの一定期間の販売ランキングを抽出
    ''　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    ''　戻値：抽出件数
    ''----------------------------------------------------------------------
    'Public Function getCandidateCount(ByVal KeyFromDate As String, _
    '                                    ByVal KeyToDate As String, _
    '                                    ByVal KeyCycleDate As String, _
    '                                    ByVal KeyProductName As String, _
    '                                    ByVal KeyOptionName As String, _
    '                                    ByVal KeyProductCode As String, _
    '                                    ByVal KeyJANCode As String, _
    '                                    ByVal KeyBumonName As String, _
    '                                    ByVal KeySupplierName As String, _
    '                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

    '    Dim strSelect As String
    '    Dim pc As Integer
    '    Dim maxpc As Integer
    '    Dim ret As Boolean

    '    'コマンドオブジェクトの生成
    '    pCommand = pConn.CreateCommand()
    '    pCommand.Transaction = Tran

    '    ret = pToolDBIO.argCal( _
    '                        pc, _
    '                        maxpc, _
    '                        KeyFromDate, _
    '                        KeyToDate, _
    '                        KeyCycleDate, _
    '                        KeyProductName, _
    '                        KeyOptionName, _
    '                        KeyProductCode, _
    '                        KeyJANCode, _
    '                        KeyBumonName, _
    '                        KeySupplierName, _
    '                        Nothing _
    '                    )

    '    strSelect = ""

    '    SQL_MAKE( _
    '            pc, _
    '            maxpc, _
    '            strSelect, _
    '            KeyFromDate, _
    '            KeyToDate, _
    '            KeyCycleDate, _
    '            KeyProductName, _
    '            KeyOptionName, _
    '            KeyProductCode, _
    '            KeyJANCode, _
    '            KeyBumonName, _
    '            KeySupplierName, _
    '            True _
    '        )
    '    getCandidateCount = -1

    '    'SQL文の設定
    '    pCommand.CommandText = strSelect

    '    Try
    '        getCandidateCount = pCommand.ExecuteScalar

    '    Catch oExcept As Exception
    '        '例外が発生した時の処理
    '        pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewCandidateDBIO.getCandidate)", Nothing, Nothing, oExcept.ToString)
    '        pMessageBox.ShowDialog()
    '        pMessageBox.Dispose()
    '        pMessageBox = Nothing
    '        Environment.Exit(1)
    '    Finally
    '        If IsNothing(pDataReader) = False Then
    '            pDataReader.Close()
    '        End If
    '    End Try

    'End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        pToolDBIO = Nothing
    End Sub
End Class
