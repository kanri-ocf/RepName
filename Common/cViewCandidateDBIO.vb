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
    Public Function getCandidate(ByRef parCandidate() As cStructureLib.sViewCandidate,
                                   ByVal KeyFromDate As String,
                                   ByVal KeyToDate As String,
                                   ByVal KeyCycleDate As String,
                                   ByVal KeyMinCount As String,
                                   ByVal KeyProductName As String,
                                   ByVal KeyOptionName As String,
                                   ByVal KeyProductCode As String,
                                   ByVal KeyJANCode As String,
                                   ByVal KeySelStatus As Boolean,
                                   ByVal KeyBumonName As String,
                                   ByVal KeySupplierName As String,
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

        ret = pToolDBIO.argCal(
                            pc,
                            maxpc,
                            KeyFromDate,
                            KeyToDate,
                            KeyCycleDate,
                            KeyMinCount,
                            KeyProductName,
                            KeyOptionName,
                            KeyProductCode,
                            KeyJANCode,
                            pSelStatus,
                            KeyBumonName,
                            KeySupplierName
                        )

        strSelect = ""

        SQL_MAKE(
                pc,
                maxpc,
                strSelect,
                KeyFromDate,
                KeyToDate,
                KeyCycleDate,
                KeyMinCount,
                KeyProductName,
                KeyOptionName,
                KeyProductCode,
                KeyJANCode,
                pSelStatus,
                KeyBumonName,
                KeySupplierName
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


    '2019.11.30 R.Takashima FROM
    '候補抽出期間、売上サイクルを条件として商品のデータを抽出する
    '戻り値には抽出した商品の個数
    Public Function getCandidateData(ByRef parCandidate() As cStructureLib.sViewCandidate,
                                   ByVal KeyFromDate As String,
                                   ByVal KeyToDate As String,
                                   ByVal KeyCycleDate As String,
                                   ByVal KeyMinCount As String,
                                   ByVal KeyProductName As String,
                                   ByVal KeyOptionName As String,
                                   ByVal KeyProductCode As String,
                                   ByVal KeyJANCode As String,
                                   ByVal KeySelStatus As Boolean,
                                   ByVal KeyBumonName As String,
                                   ByVal KeySupplierName As String,
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim strWhere As String
        Dim strOrderBy As String
        Dim scnt As Integer
        Dim i As Long
        Dim pc As Integer
        Dim maxpc As Integer
        Dim dayCloseDate As String()

        strSelect = ""
        strWhere = ""
        strOrderBy = ""
        ReDim dayCloseDate(0)

        '抽出期間のデータを抽出
        strSelect = strSelect &
                    "SELECT " &
                    "発注候補選択状態データ.選択状態 AS 選択状態, " &
                    "日次取引明細データ.商品コード AS 商品コード, " &
                    "日次取引明細データ.商品名称 AS 商品名称, " &
                    "日次取引明細データ.JANコード AS JANコード, " &
                    "日次取引明細データ.オプション1 AS オプション1, " &
                    "日次取引明細データ.オプション2 AS オプション2, " &
                    "日次取引明細データ.オプション3 AS オプション3, " &
                    "日次取引明細データ.オプション4 AS オプション4, " &
                    "日次取引明細データ.オプション5 AS オプション5, " &
                    "日次取引明細データ.定価 AS 定価, " &
                    "日次取引明細データ.取引数量 AS 取引数量," &
                    "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                    "仕入価格マスタ.仕入単価 AS 仕入単価, " &
                    "在庫マスタ.在庫数, " &
                    "日次取引データ.日次締め日 AS 日次締め日 " &
                "FROM " &
                    "( " &
                        "( " &
                            "仕入先マスタ RIGHT JOIN " &
                            "( " &
                                "( " &
                                    "仕入価格マスタ RIGHT JOIN  " &
                                    "( " &
                                        "( " &
                                            "日次取引データ LEFT JOIN 日次取引明細データ  " &
                                            "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード " &
                                        ")  " &
                                        "LEFT JOIN 在庫マスタ  " &
                                        " ON 日次取引明細データ.商品コード = 在庫マスタ.商品コード " &
                                    ")  " &
                                    "ON 仕入価格マスタ.商品コード = 日次取引明細データ.商品コード " &
                                ")  " &
                                "LEFT JOIN 発注候補選択状態データ  " &
                                "ON 日次取引明細データ.商品コード = 発注候補選択状態データ.商品コード " &
                            ")  " &
                            "ON 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " &
                        ")  " &
                        "LEFT JOIN 部門マスタ  " &
                        "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード  " &
                    ") " &
                    "LEFT JOIN 商品マスタ " &
                    "ON 日次取引明細データ.商品コード = 商品マスタ.商品コード "



        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyFromDate <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If

        If KeyToDate <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        If KeyCycleDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If

        If KeyMinCount <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If

        If KeyProductName <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If

        If KeyOptionName <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If

        If KeyProductCode <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If

        If KeyJANCode <> Nothing Then
            maxpc = 128
            pc = pc Or maxpc
        End If

        If KeySelStatus <> Nothing Then
            maxpc = 256
            pc = pc Or maxpc
        End If

        If KeyBumonName <> Nothing Then
            maxpc = 512
            pc = pc Or maxpc
        End If
        If KeySupplierName <> Nothing Then
            maxpc = 1024
            pc = pc Or maxpc
        End If

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
                        '候補抽出期間と売上サイクルの最大値で抽出する
                        '例：最大値                                                       最大値
                        '                                        |----------------------------------------------------|
                        '                                                    売上サイクル           候補抽出期間      
                        '                                        |------------------------------|---------------------|
                        ' |-------------------------------------------------------------------------------------------|
                        '                                                                       |
                        '                                                                     売上Ａ

                        '**********************************************************************************************

                        '例：上記以外                                                     最大ではない
                        '                                                |--------------------------------------------|
                        '                                                           売上サイクル
                        '                                                |------------------------------|
                        '                                                                            候補抽出期間      
                        '                                                                       |---------------------|
                        ' |-------------------------------------------------------------------------------------------|
                        '                                                                               |
                        '                                                                             売上Ａ

                        strWhere = strWhere & "日次取引データ.日次締め日 >= """ &
                            DateAdd("m", DateDiff("m", KeyToDate, KeyFromDate) + DateDiff("m", KeyToDate, KeyCycleDate), KeyToDate) & """ "
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

        strWhere = strWhere & "AND 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード " &
                                    "AND 日次取引明細データ.商品コード IN ( " &
                                        "SELECT DISTINCT " &
                                            "日次取引明細データ.商品コード " &
                                         "FROM " &
                                            "日次取引明細データ RIGHT JOIN 日次取引データ " &
                                            "ON 日次取引明細データ.取引コード = 日次取引データ.取引コード " &
                                         "WHERE " &
                                            "(日次取引明細データ.商品コード Is Not Null) " &
                                            "AND (日次取引明細データ.商品コード <> """") " &
                                    ") " &
                                    "AND 日次取引データ.取引区分 = ""売上"" OR 日次取引データ.取引区分 = ""戻入"" "
        '2019.12.5 R.Takashima
        '戻入時は売上数から戻入数だけ引く
        'AND 日次取引データ.取引区分 = ""売上"" "

        '適正在庫数が現在の在庫数以下
        strWhere = strWhere & "AND 在庫マスタ.在庫数 <= 商品マスタ.適正在庫数 "


        ' ORDER BY区生成
        strOrderBy = strOrderBy & "ORDER BY (日次取引明細データ.商品コード) ASC "

        strSelect = strSelect & strWhere & strOrderBy


        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        'SQL文の設定
        pCommand.CommandText = strSelect

        Try
            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parCandidate(i)
                ReDim Preserve dayCloseDate(i)

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
                '2019.12.5 R.Takashima FROM
                '取引数量
                If IsDBNull(pDataReader("取引数量")) = False Then
                    parCandidate(i).sCount = CLng(pDataReader("取引数量"))
                Else
                    parCandidate(i).sCount = 0
                End If
                '2019.12.5 R.Takashima TO
                '仕入価格
                If IsDBNull(pDataReader("仕入単価")) = False Then
                    parCandidate(i).sCostPrice = CLng(pDataReader("仕入単価"))
                Else
                    parCandidate(i).sCostPrice = 0
                End If
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = False Then
                    parCandidate(i).sStockCount = CInt(pDataReader("在庫数"))
                Else
                    parCandidate(i).sStockCount = 0
                End If
                '日次締め日
                dayCloseDate(i) = pDataReader("日次締め日").ToString

                i = i + 1

            End While

            'SQLが思いつかなかったためVB上でデータの入れ替えや売上個数、売上サイクルの計算を行っている
            If i > 0 Then
                getCandidateData = setCandidateCycleData(parCandidate, i, dayCloseDate, KeyCycleDate, KeyFromDate, KeyMinCount)
            End If

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
    '2019.11.30 R.Takashima TO


    '2019.11.30 R.Takashiam FROM
    '----------------------------------------------------------------------
    '　機能：売上サイクル内に存在している商品を仕入先別に数量を計算し並び替える
    '　引数：Byref sViewCandidate       取得した商品のデータ
    '        Byval count                取得した商品の数量
    '        Byval closeDate            取得した商品の日次締め日（売上が発生した日）
    '        Byval cycleDate            売上サイクル
    '        Byval fromDate             候補抽出期間
    '        Byval minCount             最低売上数量
    '　戻値：データの数量
    '----------------------------------------------------------------------
    Private Function setCandidateCycleData(ByRef svc As cStructureLib.sViewCandidate(),
                                      ByVal count As Long,
                                      ByVal closeDate() As String,
                                      ByVal cycleDate As String,
                                      ByVal fromDate As String,
                                      ByVal minCount As Long
                                      ) As Long
        '変数宣言
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim productCode As String  '商品コード
        Dim latestDate As String   '最新日次締め日（最終売上）
        Dim buyCount As Long       '商品購入数
        Dim tempCandidate As cStructureLib.sViewCandidate()
        Dim latestFlag As Boolean  '最新日時フラグ

        k = 0
        buyCount = 0
        ReDim tempCandidate(count - 1)
        latestFlag = False


        For i = 0 To count - 1
            productCode = svc(k).sProductCode
            latestDate = fromDate
            latestFlag = false

            For j = k To count - 1

                If productCode = svc(j).sProductCode Then

                    '候補抽出期間内で最新のデータを検索
                    If DateTime.Parse(closeDate(j)) >= DateTime.Parse(latestDate) Then
                        latestDate = closeDate(j)
                        latestFlag = True
                    End If

                Else

                    For k = k To j - 1
                        '2019.12.5 R.Takashima
                        '候補抽出期間内の商品のみ実行する
                        If latestFlag = True Then

                            '最新の売上から売上サイクル期間までに商品があるか検索
                            'あれば最新のデータを除き挿入
                            'ない場合はNothingを挿入
                            If DateTime.Parse(closeDate(k)) > DateTime.Parse(DateAdd("m", DateDiff("m", Now(), cycleDate), latestDate)) Then
                                If DateTime.Parse(closeDate(k)) < DateTime.Parse(latestDate) Then
                                    tempCandidate(k) = svc(k)
                                Else
                                    tempCandidate(k) = Nothing
                                End If
                            End If

                        Else

                            tempCandidate(k) = Nothing

                        End If
                    Next

                    Exit For
                End If

                '最終ループ時
                If j = count - 1 Then
                    For k = k To j
                        '最新の売上から売上サイクル期間までに商品があるか検索
                        'あれば最新のデータを除き挿入
                        'ない場合はNothingを挿入
                        If DateTime.Parse(closeDate(k)) > DateTime.Parse(DateAdd("m", DateDiff("m", Now(), cycleDate), latestDate)) Then
                            If DateTime.Parse(closeDate(k)) < DateTime.Parse(latestDate) Then
                                tempCandidate(k) = svc(k)
                            Else
                                tempCandidate(k) = Nothing
                            End If
                        End If
                    Next
                    'k = データの個数  --> ループの終了
                    i = k
                End If
            Next
        Next


        '売上サイクル期間内に売上がある場合、最新の売上データを入れる
        For i = 0 To count - 1
            If tempCandidate(i).sProductCode <> Nothing Then
                For j = 0 To count - 1
                    If tempCandidate(i).sProductCode = svc(j).sProductCode Then
                        tempCandidate(j) = svc(j)
                    End If
                Next
            End If
        Next

        j = 0
        k = 0

        'Nothingを詰める
        For i = 0 To count - 1
            If tempCandidate(i).sProductCode <> Nothing Then
                ReDim Preserve svc(j)
                svc(j) = tempCandidate(i)
                j += 1
            End If

            '全てNothingの場合、処理を終了させる
            If i = count - 1 And j = 0 Then
                ReDim svc(0)
                Return 0
                Exit Function
            End If
        Next

        count = svc.Length
        ReDim tempCandidate(0)

        '同じ商品の売上数量
        For i = 0 To count - 1
            If k < count - 1 Then
                ReDim Preserve tempCandidate(i)
                tempCandidate(i) = svc(k)

                For j = k To count - 1

                    '2019.11.30 R.Takashima FROM
                    '仕入先を条件としないため変更

                    '仕入先別に商品の売上数量を算出する
                    'If tempCandidate(i).sProductCode = svc(j).sProductCode And tempCandidate(i).sSupplierName = svc(j).sSupplierName Then
                    If tempCandidate(i).sProductCode = svc(j).sProductCode Then
                        '2019.11.30 R.Takashima TO

                        '2019.12.5 R.Takashima FROM
                        '仕入先ごとに個数を足しているため販売数が倍以上になってしまう
                        'そのため仕入先を一つとみなして販売数を計算
                        If tempCandidate(i).sSupplierName = svc(j).sSupplierName Then
                            'buyCount += 1
                            buyCount += svc(j).sCount
                        End If
                        '2019.12.5 R.Takashima TO

                    Else
                        tempCandidate(i).sCount = buyCount
                        k = j
                        buyCount = 0
                        Exit For

                    End If

                    '最終ループ時
                    If j = count - 1 Then
                        tempCandidate(i).sCount = buyCount
                        k = j

                    End If
                Next
            Else
                Exit For
            End If
        Next

        count = i
        j = 0

        '最低売上数量以上のものだけ表示する
        For i = 0 To count - 1
            If tempCandidate(i).sCount >= minCount Then
                ReDim Preserve svc(j)
                svc(j) = tempCandidate(i)
                j += 1
            End If
        Next

        count = j
        ReDim tempCandidate(0)
        '売上数量が大きい順に並び替える（降順）
        '選択ソート
        '商品の個数が０や１の場合は並び替える必要は無い
        If count > 1 Then
            For i = 0 To count - 1

                '2019.12.5 R.Takashima
                'iとjが同じ場所を参照してしまい、値の入れ替え時に値が消えてしまうため同じ場所を参照しないように変更
                'For j = i To count - 1
                For j = i + 1 To count - 1
                    If svc(i).sCount < svc(j).sCount Then

                        '2019.12.5 R.Takashima FROM
                        'ELSE部分で余計に値を入れていたため、値が重複することがあり修正
                        tempCandidate(0) = svc(i)
                        svc(i) = svc(j)
                        svc(j) = tempCandidate(0)

                        '    tempCandidate(i) = svc(j)
                        '    tempCandidat(j) = svc(i)
                        'Else
                        '    tempCandidate(j) = svc(j)

                    End If
                Next
            Next

            'データを代入する
            'svc = tempCandidate
            '2019.12.5 R.Takashima TO
        End If

        Return svc.Length

    End Function

    '2019.11.30 R.Takashima TO



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
