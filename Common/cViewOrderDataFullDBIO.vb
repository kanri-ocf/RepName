
Public Class cViewOrderDataFullDBIO
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
    '　機能：発注情報データから該当発注番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getOrderSearch(ByRef parOrderDataFull() As cStructureLib.sViewOrderDataFull, _
                                 ByVal KeyOrderNumber As String, _
                                 ByVal KeySupplierCode As String, _
                                 ByVal KeyFromCreateDate As String, _
                                 ByVal KeyToCreateDate As String, _
                                 ByVal KeyProductCode As String, _
                                 ByVal KeyProductName As String, _
                                 ByVal KeyOptionName As String, _
                                 ByVal KeyFromAllArrivedDate As String, _
                                 ByVal KeyToAllArrivedDate As String, _
                                 ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim Maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT DISTINCT " &
                        "発注情報データ.発注コード AS 発注コード, " &
                        "発注情報データ.発注日 AS 発注日, " &
                        "発注情報データ.発注モード AS 発注モード, " &
                        "発注情報データ.発注税抜商品金額 AS 発注税抜商品金額, " &
                        "発注情報データ.送料 AS 送料, " &
                        "発注情報データ.手数料 AS 手数料, " &
                        "発注情報データ.値引き AS 値引き, " &
                        "発注情報データ.ポイント値引き AS ポイント値引き, " &
                        "発注情報データ.発注税抜金額 AS 発注税抜金額, " &
                        "発注情報データ.発注消費税額 AS 発注消費税額, " &
                        "発注情報データ.軽減税率 AS 軽減税率, " &
                        "発注情報データ.発注軽減消費税額 AS 発注軽減消費税額, " &
                        "発注情報データ.発注税込金額 AS 発注税込金額, " &
                        "発注情報データ.仕入先コード AS 仕入先コード, " &
                        "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                        "発注情報データ.支払方法コード AS 支払方法コード, " &
                        "支払方法マスタ.支払方法名称 AS 支払方法名称, " &
                        "発注情報データ.希望納品日 AS 希望納品日, " &
                        "発注情報データ.希望納品場所 AS 希望納品場所, " &
                        "発注情報データ.発注担当者コード AS 発注担当者コード, " &
                        "スタッフマスタ.スタッフ名称 AS 発注担当者名称, " &
                        "発注情報データ.備考 AS 備考, " &
                        "発注情報データ.伝票印刷モード AS 伝票印刷モード, " &
                        "発注情報データ.完納日 AS 完納日 " &
                    "FROM スタッフマスタ " &
                        "RIGHT JOIN (支払方法マスタ " &
                        "RIGHT JOIN ((発注情報データ " &
                        "LEFT JOIN 発注情報明細データ " &
                        "ON 発注情報データ.発注コード = 発注情報明細データ.発注コード) " &
                        "LEFT JOIN 仕入先マスタ " &
                        "ON 発注情報データ.仕入先コード = 仕入先マスタ.仕入先コード) " &
                        "ON 支払方法マスタ.支払方法コード = 発注情報データ.支払方法コード) " &
                        "ON スタッフマスタ.スタッフコード = 発注情報データ.発注担当者コード "

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyOrderNumber <> Nothing Then
            Maxpc = 1
            pc = pc Or Maxpc
        End If
        If KeySupplierCode <> Nothing Then
            Maxpc = 2
            pc = pc Or Maxpc
        End If
        If KeyFromCreateDate <> Nothing Then
            Maxpc = 4
            pc = pc Or Maxpc
        End If
        If KeyToCreateDate <> Nothing Then
            Maxpc = 8
            pc = pc Or Maxpc
        End If
        If KeyProductCode <> Nothing Then
            Maxpc = 16
            pc = pc Or Maxpc
        End If
        If KeyProductName <> Nothing Then
            Maxpc = 32
            pc = pc Or Maxpc
        End If
        If KeyFromAllArrivedDate <> Nothing Then
            Maxpc = 64
            pc = pc Or Maxpc
        End If
        If KeyToAllArrivedDate <> Nothing Then
            Maxpc = 128
            pc = pc Or Maxpc
        End If

        'パラメータ指定がある場合
        If Maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= Maxpc
                Select Case i And pc
                    Case 1  '発注コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.発注コード Like ""%" & KeyOrderNumber & "%"" "
                        scnt = scnt + 1

                    Case 2  '仕入先コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.仕入先コード = " & KeySupplierCode & " "
                        scnt = scnt + 1
                    Case 4  '発注日
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.発注日 >= """ & KeyFromCreateDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.発注日 <= """ & KeyToCreateDate & """ "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報明細データ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報明細データ.商品名称 Like ""%" & KeyProductName & "%"" "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.完納日 >= """ & KeyFromAllArrivedDate & """ "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "発注情報データ.完納日 <= """ & KeyToAllArrivedDate & """ "
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

                ReDim Preserve parOrderDataFull(i)

                '発注コード
                parOrderDataFull(i).sOrderCode = pDataReader("発注コード").ToString
                '発注日
                parOrderDataFull(i).sOrderDate = pDataReader("発注日").ToString
                '発注モード
                If IsDBNull(pDataReader("発注モード")) = True Then
                    parOrderDataFull(i).sOrderMode = 0
                Else
                    parOrderDataFull(i).sOrderMode = CInt(pDataReader("発注モード"))
                End If
                '発注税抜商品金額
                If IsDBNull(pDataReader("発注税抜商品金額")) = True Then
                    parOrderDataFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parOrderDataFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("発注税抜商品金額"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parOrderDataFull(i).sPointDisCount = 0
                Else
                    parOrderDataFull(i).sPointDisCount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parOrderDataFull(i).sDiscount = 0
                Else
                    parOrderDataFull(i).sDiscount = CLng(pDataReader("ポイント値引き"))
                End If
                '発注税抜金額
                If IsDBNull(pDataReader("発注税抜金額")) = True Then
                    parOrderDataFull(i).sNoTaxTotalPrice = 0
                Else
                    parOrderDataFull(i).sNoTaxTotalPrice = CLng(pDataReader("発注税抜金額"))
                End If
                '発注消費税額
                If IsDBNull(pDataReader("発注消費税額")) = True Then
                    parOrderDataFull(i).sTaxTotal = 0
                Else
                    parOrderDataFull(i).sTaxTotal = CLng(pDataReader("発注消費税額"))
                End If

                '2019,9,22 A.Komita 追加 From
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parOrderDataFull(i).sReducedTaxRate = String.Empty
                Else
                    parOrderDataFull(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                End If
                '2019,9,22 A.Komita 追加 To

                '2019,9,22 A.Komita 追加 From
                '発注軽減消費税額
                If IsDBNull(pDataReader("発注軽減消費税額")) = True Then
                    parOrderDataFull(i).sReducedTaxRateTotal = 0
                Else
                    parOrderDataFull(i).sReducedTaxRateTotal = pDataReader("発注軽減消費税額")
                End If

                '発注税込金額
                If IsDBNull(pDataReader("発注税込金額")) = True Then
                    parOrderDataFull(i).sTotalPrice = 0
                Else
                    parOrderDataFull(i).sTotalPrice = CLng(pDataReader("発注税込金額"))
                End If
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parOrderDataFull(i).sSupplierCode = 0
                Else
                    parOrderDataFull(i).sSupplierCode = CLng(pDataReader("仕入先コード"))
                End If
                '仕入先名称
                parOrderDataFull(i).sSupplierName = pDataReader("仕入先名称").ToString
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parOrderDataFull(i).sPaymentCode = 0
                Else
                    parOrderDataFull(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parOrderDataFull(i).sPaymentName = pDataReader("支払方法名称").ToString
                '希望納品日
                parOrderDataFull(i).sRequestDate = pDataReader("希望納品日").ToString
                '希望納品場所
                parOrderDataFull(i).sRequestPlace = pDataReader("希望納品場所").ToString
                '発注担当者コード
                parOrderDataFull(i).sStaffCode = pDataReader("発注担当者コード").ToString
                '発注担当者名称
                parOrderDataFull(i).sStaffName = pDataReader("発注担当者名称").ToString
                '備考
                parOrderDataFull(i).sMemo = pDataReader("備考").ToString
                '伝票印刷モード
                If IsDBNull(pDataReader("伝票印刷モード")) = True Then
                    parOrderDataFull(i).sPrintMode = 0
                Else
                    parOrderDataFull(i).sPrintMode = CInt(pDataReader("伝票印刷モード"))
                End If
                '完納日
                parOrderDataFull(i).sStaffName = pDataReader("完納日").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getOrderSearch = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataOrderDBIO.getOrderSearch)", Nothing, Nothing, oExcept.ToString)
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
