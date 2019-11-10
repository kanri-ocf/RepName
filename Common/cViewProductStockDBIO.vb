Public Class cViewProductStockDBIO
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
    Public Function getProductStockCount(ByVal KeyChannelCode As Integer, _
                                    ByVal KeyJANCode As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyOptionName As String, _
                                    ByVal KeySupplierCode As Long, _
                                    ByVal KeyOrderCheck As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim MaxPc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT DISTINCT Count(商品マスタ.商品コード) AS 商品数 " & _
                        "FROM ((((商品マスタ " & _
                            "LEFT JOIN 販売価格マスタ " & _
                                "ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " & _
                            "LEFT JOIN 在庫マスタ " & _
                                "ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " & _
                            "LEFT JOIN 発注状態データ " & _
                                "ON 商品マスタ.商品コード = 発注状態データ.商品コード) " & _
                            "LEFT JOIN " & _
                                "[" & _
                                    "SELECT " & _
                                        "仕入価格マスタ.商品コード, " & _
                                        "Min(仕入価格マスタ.仕入単価) AS 最小仕入価格, " & _
                                        "Min(仕入価格マスタ.仕入先コード) AS 最小仕入先コード " & _
                                    "FROM 仕入価格マスタ " & _
                                    "GROUP BY " & _
                                        "仕入価格マスタ.商品コード " & _
                                "]. AS 最安値 " & _
                                "ON 商品マスタ.商品コード = 最安値.商品コード) "


            'パラメータ数のカウント
            pc = 0
            MaxPc = 0
            If KeyChannelCode <> Nothing Then
                MaxPc = 1
                pc = pc Or MaxPc
            End If
            If KeyJANCode <> Nothing Then
                MaxPc = 2
                pc = pc Or MaxPc
            End If
            If KeyProductCode <> Nothing Then
                MaxPc = 4
                pc = pc Or MaxPc
            End If
            If KeyProductName <> Nothing Then
                MaxPc = 8
                pc = pc Or MaxPc
            End If
            If KeyOptionName <> Nothing Then
                MaxPc = 16
                pc = pc Or MaxPc
            End If
            If KeySupplierCode <> Nothing Then
                MaxPc = 32
                pc = pc Or MaxPc
            End If
            If KeyOrderCheck = True Then
                MaxPc = 64
                pc = pc Or MaxPc
            End If

            'パラメータ指定がある場合
            If MaxPc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= MaxPc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "最小仕入先コード=" & KeySupplierCode & " "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注状態データ.選択状態 =" & KeyOrderCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " & _
                          "AND 販売価格マスタ.適用終了日>=Now() " & _
                          "AND 商品マスタ.仕入停止フラグ=False "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()


            '商品数
            If IsDBNull(pDataReader("商品数")) Then
                getProductStockCount = 0
            Else
                getProductStockCount = CLng(pDataReader("商品数"))
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductStockCount)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getProductStock(ByRef parProductStock() As cStructureLib.sViewProductStock, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyJANCode As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyOptionName As String, _
                                    ByVal KeySupplierCode As Long, _
                                    ByVal KeyOrderCheck As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim MaxPc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT DISTINCT " & _
                            "発注状態データ.選択状態 AS 選択状態, " & _
                            "商品マスタ.商品コード AS 商品コード, " & _
                            "商品マスタ.商品名称 AS 商品名称, " & _
                            "商品マスタ.商品略称 AS 商品略称, " & _
                            "商品マスタ.JANコード AS JANコード, " & _
                            "商品マスタ.オプション1 AS オプション1, " & _
                            "商品マスタ.オプション2 AS オプション2, " & _
                            "商品マスタ.オプション3 AS オプション3, " & _
                            "商品マスタ.オプション4 AS オプション4, " & _
                            "商品マスタ.オプション5 AS オプション5, " & _
                            "商品マスタ.定価 AS 定価, " & _
                            "最安値.最小仕入価格 AS 仕入価格, " & _
                            "最安値.最小仕入先コード AS 仕入先コード, " & _
                            "仕入先マスタ.仕入先名称 AS 仕入先名称, " & _
                            "販売価格マスタ.チャネルコード AS チャネルコード, " & _
                            "販売価格マスタ.販売単価 AS 販売単価, " & _
                            "在庫マスタ.在庫数 AS 在庫数, " & _
                            "販売価格マスタ.適用開始日 AS 適用開始日, " & _
                            "販売価格マスタ.適用終了日 AS 適用終了日 " & _
                        "FROM ((((商品マスタ " & _
                                "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " & _
                                "LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " & _
                                "LEFT JOIN 発注状態データ ON 商品マスタ.商品コード = 発注状態データ.商品コード) " & _
                                "LEFT JOIN " & _
                                "[" & _
                                    "SELECT " & _
                                        "仕入価格マスタ.商品コード, " & _
                                        "Min(仕入価格マスタ.仕入単価) AS 最小仕入価格, " & _
                                        "Min(仕入価格マスタ.仕入先コード) AS 最小仕入先コード " & _
                                    "FROM " & _
                                        "仕入価格マスタ LEFT JOIN 仕入先マスタ " & _
                                        "ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード " & _
                                    "GROUP BY 仕入価格マスタ.商品コード " & _
                                "]. AS 最安値 " & _
                                "ON 商品マスタ.商品コード = 最安値.商品コード) " & _
                                "LEFT JOIN 仕入先マスタ ON 最安値.最小仕入先コード = 仕入先マスタ.仕入先コード "

            'パラメータ数のカウント
            pc = 0
            MaxPc = 0
            If KeyChannelCode <> Nothing Then
                MaxPc = 1
                pc = pc Or MaxPc
            End If
            If KeyJANCode <> Nothing Then
                MaxPc = 2
                pc = pc Or MaxPc
            End If
            If KeyProductCode <> Nothing Then
                MaxPc = 4
                pc = pc Or MaxPc
            End If
            If KeyProductName <> Nothing Then
                MaxPc = 8
                pc = pc Or MaxPc
            End If
            If KeyOptionName <> Nothing Then
                MaxPc = 16
                pc = pc Or MaxPc
            End If
            If KeySupplierCode <> Nothing Then
                MaxPc = 32
                pc = pc Or MaxPc
            End If
            If KeyOrderCheck = True Then
                MaxPc = 64
                pc = pc Or MaxPc
            End If

            'パラメータ指定がある場合
            If MaxPc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= MaxPc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "最小仕入先コード=" & KeySupplierCode & " "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注状態データ.選択状態 =" & KeyOrderCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " & _
                          "AND 販売価格マスタ.適用終了日>=Now() " & _
                          "AND 商品マスタ.仕入停止フラグ=False "

            strSelect = strSelect & " ORDER BY 商品マスタ.商品名称, " & _
                        "商品マスタ.オプション1, " & _
                        "商品マスタ.オプション2, " & _
                        "商品マスタ.オプション3, " & _
                        "商品マスタ.オプション4, " & _
                        "商品マスタ.オプション5 "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader

            i = 0
            ReDim parProductStock(0)

            While pDataReader.Read()

                ReDim Preserve parProductStock(i)

                '選択状態
                If IsDBNull(pDataReader("選択状態")) Then
                    parProductStock(i).sStatus = False
                Else
                    parProductStock(i).sStatus = pDataReader("選択状態")
                End If

                '商品コード
                parProductStock(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProductStock(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parProductStock(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductStock(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parProductStock(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductStock(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductStock(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductStock(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductStock(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parProductStock(i).sPrice = CLng(pDataReader("定価"))
                'チャネルコード
                parProductStock(i).sChannelCode = pDataReader("チャネルコード").ToString
                '販売価格
                If IsDBNull(pDataReader("販売単価")) = True Then
                    parProductStock(i).sSalePrice = 0
                Else
                    parProductStock(i).sSalePrice = CLng(pDataReader("販売単価"))
                End If
                '仕入価格
                If IsDBNull(pDataReader("仕入価格")) = True Then
                    parProductStock(i).sCostPrice = 0
                Else
                    parProductStock(i).sCostPrice = CLng(pDataReader("仕入価格"))
                End If
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parProductStock(i).sCostPrice = 0
                Else
                    parProductStock(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '仕入先名称
                parProductStock(i).sSupplierName = pDataReader("仕入先名称").ToString
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = True Then
                    parProductStock(i).sStockCount = 0
                Else
                    parProductStock(i).sStockCount = CLng(pDataReader("在庫数"))
                End If
                '適用開始日
                parProductStock(i).sStartDate = pDataReader("適用開始日").ToString
                '適用終了日
                parProductStock(i).sEndDate = pDataReader("適用終了日").ToString

                i = i + 1

            End While

            getProductStock = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductStock)", Nothing, Nothing, oExcept.ToString)
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
    '   2015/06/11 及川和彦
    '   元となったFunction(getProductStock)は仕入れ価格が最小の仕入先を抽出対象としていたため
    '   仕入先を指定して抽出を行う際、指定仕入先が最小仕入れ価格の仕入先で無かった場合抽出されない
    '   という不具合が発生、当該不具合対応の為、当Functionを追加
    '   FROM
    '----------------------------------------------------------------------
    Public Function getSupplierProductStock(ByRef parProductStock() As cStructureLib.sViewProductStock, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyJANCode As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyOptionName As String, _
                                                                       ByVal KeySupplierCode As Long, _
 ByVal KeyOrderCheck As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim MaxPc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT DISTINCT " & _
                            "発注状態データ.選択状態 AS 選択状態, " & _
                            "商品マスタ.商品コード AS 商品コード, " & _
                            "商品マスタ.商品名称 AS 商品名称, " & _
                            "商品マスタ.商品略称 AS 商品略称, " & _
                            "商品マスタ.JANコード AS JANコード, " & _
                            "商品マスタ.オプション1 AS オプション1, " & _
                            "商品マスタ.オプション2 AS オプション2, " & _
                            "商品マスタ.オプション3 AS オプション3, " & _
                            "商品マスタ.オプション4 AS オプション4, " & _
                            "商品マスタ.オプション5 AS オプション5, " & _
                            "商品マスタ.定価 AS 定価, " & _
                            "仕入価格マスタ.仕入単価 AS 仕入価格, " & _
                            "仕入価格マスタ.仕入先コード AS 仕入先コード, " & _
                            "仕入先マスタ.仕入先名称 AS 仕入先名称, " & _
                            "販売価格マスタ.チャネルコード AS チャネルコード, " & _
                            "販売価格マスタ.販売単価 AS 販売単価, " & _
                            "在庫マスタ.在庫数 AS 在庫数, " & _
                            "販売価格マスタ.適用開始日 AS 適用開始日, " & _
                            "販売価格マスタ.適用終了日 AS 適用終了日 " & _
                        "FROM ((((商品マスタ " & _
                                "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " & _
                                "LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " & _
                                "LEFT JOIN 発注状態データ ON 商品マスタ.商品コード = 発注状態データ.商品コード) " & _
                                "LEFT JOIN 仕入価格マスタ ON 商品マスタ.商品コード = 仕入価格マスタ.商品コード) " & _
                                "LEFT JOIN 仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード "

            'パラメータ数のカウント
            pc = 0
            MaxPc = 0
            If KeyChannelCode <> Nothing Then
                MaxPc = 1
                pc = pc Or MaxPc
            End If
            If KeyJANCode <> Nothing Then
                MaxPc = 2
                pc = pc Or MaxPc
            End If
            If KeyProductCode <> Nothing Then
                MaxPc = 4
                pc = pc Or MaxPc
            End If
            If KeyProductName <> Nothing Then
                MaxPc = 8
                pc = pc Or MaxPc
            End If
            If KeyOptionName <> Nothing Then
                MaxPc = 16
                pc = pc Or MaxPc
            End If
            If KeySupplierCode <> Nothing Then
                MaxPc = 32
                pc = pc Or MaxPc
            End If
            If KeyOrderCheck = True Then
                MaxPc = 64
                pc = pc Or MaxPc
            End If

            'パラメータ指定がある場合
            If MaxPc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= MaxPc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "仕入価格マスタ.仕入先コード=" & KeySupplierCode & " "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注状態データ.選択状態 =" & KeyOrderCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " & _
                          "AND 販売価格マスタ.適用終了日>=Now() " & _
                          "AND 商品マスタ.仕入停止フラグ=False "

            strSelect = strSelect & " ORDER BY 商品マスタ.商品名称, " & _
                        "商品マスタ.オプション1, " & _
                        "商品マスタ.オプション2, " & _
                        "商品マスタ.オプション3, " & _
                        "商品マスタ.オプション4, " & _
                        "商品マスタ.オプション5 "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader

            i = 0
            ReDim parProductStock(0)

            While pDataReader.Read()

                ReDim Preserve parProductStock(i)

                '選択状態
                If IsDBNull(pDataReader("選択状態")) Then
                    parProductStock(i).sStatus = False
                Else
                    parProductStock(i).sStatus = pDataReader("選択状態")
                End If

                '商品コード
                parProductStock(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProductStock(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parProductStock(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductStock(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parProductStock(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductStock(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductStock(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductStock(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductStock(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parProductStock(i).sPrice = CLng(pDataReader("定価"))
                'チャネルコード
                parProductStock(i).sChannelCode = pDataReader("チャネルコード").ToString
                '販売価格
                If IsDBNull(pDataReader("販売単価")) = True Then
                    parProductStock(i).sSalePrice = 0
                Else
                    parProductStock(i).sSalePrice = CLng(pDataReader("販売単価"))
                End If
                '仕入価格
                If IsDBNull(pDataReader("仕入価格")) = True Then
                    parProductStock(i).sCostPrice = 0
                Else
                    parProductStock(i).sCostPrice = CLng(pDataReader("仕入価格"))
                End If
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parProductStock(i).sCostPrice = 0
                Else
                    parProductStock(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '仕入先名称
                parProductStock(i).sSupplierName = pDataReader("仕入先名称").ToString
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = True Then
                    parProductStock(i).sStockCount = 0
                Else
                    parProductStock(i).sStockCount = CLng(pDataReader("在庫数"))
                End If
                '適用開始日
                parProductStock(i).sStartDate = pDataReader("適用開始日").ToString
                '適用終了日
                parProductStock(i).sEndDate = pDataReader("適用終了日").ToString

                i = i + 1

            End While

            getSupplierProductStock = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getSupplierProductStock)", Nothing, Nothing, oExcept.ToString)
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
    '   HERE
    '----------------------------------------------------------------------


    '----------------------------------------------------------------------
    '　機能：日次部門マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getOrderProductStock(ByRef parProductStock() As cStructureLib.sViewProductStock, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyJANCode As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeySupplierName As String, _
                                    ByVal KeyOrderCheck As Boolean, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT DISTINCT " & _
                            "発注状態データ.選択状態, " & _
                            "商品マスタ.商品コード, " & _
                            "商品マスタ.商品名称, " & _
                            "商品マスタ.商品略称, " & _
                            "商品マスタ.JANコード, " & _
                            "商品マスタ.オプション1, " & _
                            "商品マスタ.オプション2, " & _
                            "商品マスタ.オプション3, " & _
                            "商品マスタ.オプション4, " & _
                            "商品マスタ.オプション5, " & _
                            "商品マスタ.定価, " & _
                            "仕入価格マスタ仕入単価, " & _
                            "販売価格マスタ.チャネルコード, " & _
                            "販売価格マスタ販売単価, " & _
                            "在庫マスタ.在庫数, " & _
                            "仕入先マスタ.仕入先名称, " & _
                            "販売価格マスタ.適用開始日, " & _
                            "販売価格マスタ.適用終了日 " & _
                        "FROM 商品マスタ " & _
                            "LEFT JOIN (仕入先マスタ " & _
                            "RIGHT JOIN 仕入価格マスタ " & _
                            "ON 仕入先マスタ.仕入先コード = 仕入価格マスタ.仕入先コード) " & _
                            "ON 商品マスタ.商品コード = 仕入価格マスタ.商品コード) " & _
                            "LEFT JOIN 販売価格マスタ " & _
                            "ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " & _
                            "LEFT JOIN 発注状態データ " & _
                            "ON 商品マスタ.商品コード = 発注状態データ.商品コード) " & _
                            "LEFT JOIN 在庫マスタ " & _
                            "ON 商品マスタ.商品コード = 在庫マスタ.商品コード "

            'パラメータ数のカウント
            pc = 0
            If KeyChannelCode <> Nothing Then
                pc = pc Or 1
            End If
            If KeyJANCode <> Nothing Then
                pc = pc Or 2
            End If
            If KeyProductCode <> Nothing Then
                pc = pc Or 4
            End If
            If KeyProductName <> Nothing Then
                pc = pc Or 8
            End If
            If KeySupplierName <> Nothing Then
                pc = pc Or 16
            End If
            If KeyOrderCheck = True Then
                pc = pc Or 32
            End If

            'パラメータ指定がある場合
            If 31 And pc > 0 Then
                i = 1
                scnt = 0
                While i <= 32
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "仕入先マスタ.仕入先名称 Like ""%" & KeySupplierName & "%"" "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注状態データ.選択状態 =" & KeyOrderCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " & _
                          "AND 販売価格マスタ.適用終了日>=Now() " & _
                          "AND 商品マスタ.仕入停止フラグ=False "

            strSelect = strSelect & " ORDER BY 商品マスタ.商品名称, " & _
                        "商品マスタ.オプション1, " & _
                        "商品マスタ.オプション2, " & _
                        "商品マスタ.オプション3, " & _
                        "商品マスタ.オプション4, " & _
                        "商品マスタ.オプション5 "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parProductStock(i)

                '選択状態
                If IsDBNull(pDataReader("選択状態")) Then
                    parProductStock(i).sStatus = False
                Else
                    parProductStock(i).sStatus = pDataReader("選択状態")
                End If

                '商品コード
                parProductStock(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProductStock(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parProductStock(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductStock(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parProductStock(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductStock(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductStock(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductStock(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductStock(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parProductStock(i).sPrice = CLng(pDataReader("定価"))
                'チャネルコード
                parProductStock(i).sChannelCode = pDataReader("チャネルコード").ToString
                '販売価格
                If IsDBNull(pDataReader("販売価格")) = True Then
                    parProductStock(i).sSalePrice = 0
                Else
                    parProductStock(i).sSalePrice = CLng(pDataReader("販売価格"))
                End If
                '仕入価格
                parProductStock(i).sCostPrice = CLng(pDataReader("仕入価格"))
                '仕入先コード
                parProductStock(i).sSupplierCode = pDataReader("仕入先名称").ToString
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = True Then
                    parProductStock(i).sStockCount = 0
                Else
                    parProductStock(i).sStockCount = CLng(pDataReader("在庫数"))
                End If
                '適用開始日
                parProductStock(i).sStartDate = pDataReader("適用開始日").ToString
                '適用終了日
                parProductStock(i).sEndDate = pDataReader("適用終了日").ToString

                i = i + 1

            End While

            getOrderProductStock = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getOrderProductStock)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getProductTagPrint(ByRef parProductStock() As cStructureLib.sViewProductStock, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyJANCode As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyTagPrintCheck As Boolean, _
                                    ByVal KeyDate As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT DISTINCT " & _
                            "タグ印刷状態データ.タグ印刷状態, " & _
                            "商品マスタ.商品コード AS 商品コード, " & _
                            "商品マスタ.商品名称 AS 商品名称, " & _
                            "商品マスタ.商品略称 AS 商品略称, " & _
                            "商品マスタ.JANコード AS JANコード, " & _
                            "商品マスタ.オプション1 AS オプション1, " & _
                            "商品マスタ.オプション2 AS オプション2, " & _
                            "商品マスタ.オプション3 AS オプション3, " & _
                            "商品マスタ.オプション4 AS オプション4, " & _
                            "商品マスタ.オプション5 AS オプション5, " & _
                            "商品マスタ.定価 AS 定価, " & _
                            "販売価格マスタ.販売単価 AS 販売単価, " & _
                            "在庫マスタ.在庫数 AS 在庫数, " & _
                            "タグ印刷状態データ.枚数 AS 枚数, " & _
                            "販売価格マスタ.適用開始日 AS 適用開始日, " & _
                            "販売価格マスタ.適用終了日 AS 適用終了日 " & _
                        "FROM (" & _
                                "(" & _
                                    "タグ印刷状態データ RIGHT JOIN 商品マスタ " & _
                                    "ON タグ印刷状態データ.商品コード = 商品マスタ.商品コード" & _
                                ") " & _
                                "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード" & _
                            ") " & _
                            "LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード " & _
                        "WHERE " & _
                            "販売価格マスタ.チャネルコード = " & KeyChannelCode & " " & _
                            "AND 商品マスタ.販売停止フラグ = False "

            'パラメータ数のカウント
            pc = 0
            mpc = 0

            If KeyJANCode <> "" Then
                mpc = 1
                pc = pc Or mpc
            End If
            If KeyProductCode <> "" Then
                mpc = 2
                pc = pc Or mpc
            End If
            If KeyProductName <> "" Then
                mpc = 4
                pc = pc Or mpc
            End If
            If KeyTagPrintCheck = True Then
                mpc = 8
                pc = pc Or mpc
            End If
            If KeyDate <> "" Then
                mpc = 16
                pc = pc Or mpc
            End If

            'パラメータ指定がある場合
            If 31 And pc > 0 Then
                i = 1
                scnt = 0
                While i <= mpc
                    Select Case i And pc
                        Case 1
                            strSelect = strSelect & "AND 商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            strSelect = strSelect & "AND 商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            strSelect = strSelect & "AND 商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 8
                            strSelect = strSelect & "AND タグ印刷状態データ.タグ印刷状態 =" & KeyTagPrintCheck & " "
                            scnt = scnt + 1
                        Case 16
                            strSelect = strSelect & "AND 販売価格マスタ.適用開始日 <= """ & KeyDate & """ " & _
                                                    "AND 販売価格マスタ.適用終了日 >= """ & KeyDate & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 商品マスタ.商品名称, 商品マスタ.オプション1, 商品マスタ.オプション2, 商品マスタ.オプション3 "
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parProductStock(i)

                'タグ印刷状態
                If IsDBNull(pDataReader("タグ印刷状態")) Then
                    parProductStock(i).sStatus = False
                Else
                    parProductStock(i).sStatus = pDataReader("タグ印刷状態")
                End If

                '商品コード
                parProductStock(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProductStock(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parProductStock(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductStock(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parProductStock(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductStock(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductStock(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductStock(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductStock(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parProductStock(i).sPrice = CLng(pDataReader("定価"))
                '販売単価
                If IsDBNull(pDataReader("販売単価")) = True Then
                    parProductStock(i).sSalePrice = 0
                Else
                    parProductStock(i).sSalePrice = CLng(pDataReader("販売単価"))
                End If
                '在庫数
                If IsDBNull(pDataReader("在庫数")) = True Then
                    parProductStock(i).sStockCount = 0
                Else
                    parProductStock(i).sStockCount = CLng(pDataReader("在庫数"))
                End If
                'タグ印刷枚数数
                If IsDBNull(pDataReader("枚数")) = True Then
                    parProductStock(i).sTagPrintCount = 0
                Else
                    parProductStock(i).sTagPrintCount = CLng(pDataReader("枚数"))
                End If
                '適用開始日
                parProductStock(i).sStartDate = pDataReader("適用開始日").ToString
                '適用終了日
                parProductStock(i).sEndDate = pDataReader("適用終了日").ToString

                i = i + 1

            End While

            getProductTagPrint = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductTagPrint)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getProductStockCount(ByRef parProductStock() As cStructureLib.sViewProductStock, _
                                         ByVal KeyJANCode As String, _
                                         ByVal KeyProductCode As String, _
                                         ByVal KeyProductName As String, _
                                         ByVal KeySupplierName As String, _
                                         ByVal KeyOrderCheck As Boolean, _
                                         ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT COUNT(商品マスタ.商品コード) AS 商品数 " & _
                        "FROM 発注状態データ RIGHT JOIN ((価格マスタ LEFT JOIN " & _
                        "(商品マスタ LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " & _
                        "ON 価格マスタ.商品コード = 商品マスタ.商品コード) LEFT JOIN 仕入先マスタ " & _
                        "ON 商品マスタ.仕入先コード = 仕入先マスタ.仕入先コード) " & _
                        "ON 発注状態データ.商品コード = 商品マスタ.商品コード "

            'パラメータ数のカウント
            pc = 0
            If KeyJANCode <> "" Then
                pc = pc Or 1
            End If
            If KeyProductCode <> "" Then
                pc = pc Or 2
            End If
            If KeyProductName <> "" Then
                pc = pc Or 4
            End If
            If KeySupplierName <> "" Then
                pc = pc Or 8
            End If
            If KeyOrderCheck = True Then
                pc = pc Or 16
            End If

            'パラメータ指定がある場合
            If 31 And pc > 0 Then
                i = 1
                scnt = 0
                While i <= 16
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "仕入先マスタ.仕入先名称 Like ""%" & KeySupplierName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "発注状態データ.選択状態 =" & KeyOrderCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            pDataReader.Read()

            getProductStockCount = CLng(pDataReader("商品数"))
            pCommand = Nothing
            pDataReader = Nothing

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductStockCount)", Nothing, Nothing, oExcept.ToString)
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
