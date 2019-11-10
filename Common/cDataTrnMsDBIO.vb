Public Class cDataTrnMsDBIO

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
    ' 機能：取引明細を用途別に集計する関数
    ' 引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '       mode    (1)チャネル別に商品ごとの売上を集計する
    '               (2)部門別に商品を売上金額順で集計する
    '               (3)担当者別に売上金額を集計する
    ' 戻値：レコードの取得件数
    '----------------------------------------------------------------------
    Public Function getTrnMs(ByRef parTrnMs() As cStructureLib.sViewDataTrnMs, _
                             ByVal keyCloseDate As String, _
                             ByVal modeCode As String, _
                             ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer

        Try
            strSelectTrn = _
                "SELECT "
            ' modeCodeがチャネル別集計、スタッフ別集計である場合
            If modeCode = 1 _
            Or modeCode = 3 Then
                strSelectTrn = strSelectTrn & _
                    "日次取引データ.チャネルコード, " & _
                    "チャネルマスタ.チャネル名称, "
            Else
                strSelectTrn = strSelectTrn & _
                    "NULL, " & _
                    "NULL, "
            End If

            strSelectTrn = strSelectTrn & _
                    "日次取引明細データ.部門コード, " & _
                    "部門マスタ.部門名称, " & _
                    "日次取引明細データ.商品コード, " & _
                    "日次取引明細データ.商品名称, " & _
                    "日次取引明細データ.オプション1, " & _
                    "日次取引明細データ.オプション2, " & _
                    "日次取引明細データ.オプション3, " & _
                    "日次取引明細データ.オプション4, " & _
                    "日次取引明細データ.オプション5, " & _
                    "日次取引明細データ.定価, " & _
                    "日次取引明細データ.仕入単価, " & _
                    "Sum(日次取引明細データ.値引き) AS 値引き額の合計, " & _
                    "Sum(日次取引明細データ.取引数量) AS 取引数量の合計, " & _
                    "Sum(日次取引明細データ.取引税込金額) AS 取引税込金額の合計, "

            ' modeCodeが担当者別集計である場合
            If modeCode = "3" Then
                strSelectTrn = strSelectTrn & _
                                 "日次取引データ.取引担当者コード, " & _
                                 "スタッフマスタ.スタッフ名称 "
            Else
                ' 上記以外の場合、NULLを取得
                strSelectTrn = strSelectTrn & _
                                "NULL, " & _
                                "NULL "
            End If

            strSelectTrn = strSelectTrn & _
                "FROM "

            ' modeCodeが担当者別集計の場合
            If modeCode <> "3" Then
                strSelectTrn = strSelectTrn & _
                        "((日次取引データ INNER JOIN 日次取引明細データ " & _
                            "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                        "INNER JOIN 部門マスタ " & _
                            "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード) " & _
                        "INNER JOIN チャネルマスタ " & _
                            "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード "
            Else
                strSelectTrn = strSelectTrn & _
                        "(((日次取引データ INNER JOIN 日次取引明細データ " & _
                            "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                        "INNER JOIN 部門マスタ " & _
                            "ON 日次取引明細データ.部門コード = 部門マスタ.部門コード) " & _
                        "INNER JOIN チャネルマスタ " & _
                            "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード) " & _
                        "INNER JOIN スタッフマスタ " & _
                             "ON 日次取引データ.取引担当者コード = スタッフマスタ.スタッフコード "
            End If

            strSelectTrn = strSelectTrn & _
                   "WHERE "

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn & _
                                "(日次取引データ.日次締め日 IS NULL " & _
                                    "OR 日次取引データ.日次締め日 = """") "
            Else
                strSelectTrn = strSelectTrn & _
                            "日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            ' 部門別集計の場合、商品コードが指定されていないデータを除外する
            If modeCode = "2" Then
                strSelectTrn = strSelectTrn & _
                            "AND (日次取引明細データ.商品コード <> """" " & _
                                "AND 日次取引明細データ.商品コード IS NOT NULL) "
            End If

            strSelectTrn = strSelectTrn & _
                     "AND ((日次取引データ.取引区分) = ""売上""  " & _
                            "OR (日次取引データ.取引区分) = ""戻入"" ) " & _
                   "GROUP BY "


            ' modeCodeが担当者別集計の場合
            If modeCode = "3" Then
                strSelectTrn = strSelectTrn & _
                                    "日次取引データ.取引担当者コード, " & _
                                    "スタッフマスタ.スタッフ名称, "
            End If

            ' modeCodeがチャネル別集計、スタッフ別集計である場合
            If modeCode = 1 _
            Or modeCode = 3 Then
                strSelectTrn = strSelectTrn & _
                                    "日次取引データ.チャネルコード, " & _
                                    "チャネルマスタ.チャネル名称, "
            End If

            strSelectTrn = strSelectTrn & _
                                "日次取引明細データ.部門コード, " & _
                                "部門マスタ.部門名称, " & _
                                "日次取引明細データ.商品コード, " & _
                                "日次取引明細データ.商品名称, " & _
                                "日次取引明細データ.オプション1, " & _
                                "日次取引明細データ.オプション2, " & _
                                "日次取引明細データ.オプション3, " & _
                                "日次取引明細データ.オプション4, " & _
                                "日次取引明細データ.オプション5, " & _
                                "日次取引明細データ.定価, " & _
                                "日次取引明細データ.仕入単価, " & _
                                "日次取引明細データ.値引き " & _
                            "ORDER BY "

            ' modeCodeがチャネル別集計である場合
            If modeCode = 1 Then
                strSelectTrn = strSelectTrn & _
                                        "日次取引データ.チャネルコード, " & _
                                        "日次取引明細データ.部門コード, "
            ElseIf modeCode = 3 Then
                strSelectTrn = strSelectTrn & _
                    "日次取引データ.チャネルコード, " & _
                    "日次取引データ.取引担当者コード, "
            Else
                strSelectTrn = strSelectTrn & _
                                        "日次取引明細データ.部門コード, "
            End If

            ' modeCodeが売上金額順集計である場合
            If modeCode = 2 Then
                strSelectTrn = strSelectTrn & _
                    "Sum(日次取引明細データ.取引税込金額) DESC, "
            End If

            strSelectTrn = strSelectTrn & _
                                "日次取引明細データ.商品コード = """" DESC, " & _
                                "日次取引明細データ.商品コード"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            ' レコードが取得できた時の処理
            While pDataReader.Read()

                ReDim Preserve parTrnMs(i)

                ' modeCodeがチャネル別集計、スタッフ別集計である場合
                If modeCode = 1 _
                Or modeCode = 3 Then
                    ' チャネルコード
                    parTrnMs(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                    ' チャネル名称
                    parTrnMs(i).sChannelName = pDataReader("チャネル名称").ToString
                Else
                    ' チャネルコード
                    parTrnMs(i).sChannelCode = ""

                    ' チャネル名称
                    parTrnMs(i).sChannelName = ""
                End If

                ' 部門コード
                parTrnMs(i).sBumonCode = pDataReader("部門コード").ToString

                ' 部門名称
                parTrnMs(i).sBumonName = pDataReader("部門名称").ToString

                ' 商品コード
                parTrnMs(i).sProductCode = pDataReader("商品コード").ToString

                ' 商品名称
                parTrnMs(i).sProductName = pDataReader("商品名称").ToString

                ' オプション1
                parTrnMs(i).sOption1 = pDataReader("オプション1").ToString

                ' オプション2
                parTrnMs(i).sOption2 = pDataReader("オプション2").ToString

                ' オプション3
                parTrnMs(i).sOption3 = pDataReader("オプション3").ToString

                ' オプション4
                parTrnMs(i).sOption4 = pDataReader("オプション4").ToString

                ' オプション5
                parTrnMs(i).sOption5 = pDataReader("オプション5").ToString

                ' 定価
                parTrnMs(i).sListPrice = CLng(pDataReader("定価"))

                ' 仕入単価
                parTrnMs(i).sCostPrice = CLng(pDataReader("仕入単価"))

                ' 値引き額の合計
                parTrnMs(i).sDiscountPrice = CLng(pDataReader("値引き額の合計"))

                ' 取引数量の合計
                parTrnMs(i).sCount = CInt(pDataReader("取引数量の合計"))

                ' 取引税込金額の合計
                parTrnMs(i).sPrice = CLng(pDataReader("取引税込金額の合計"))

                ' 取引担当者コード
                If modeCode <> "3" Then
                    parTrnMs(i).sStaffCode = ""
                Else
                    parTrnMs(i).sStaffCode = pDataReader("取引担当者コード").ToString
                End If

                ' スタッフ名称
                If modeCode <> "3" Then
                    parTrnMs(i).sStaffName = ""
                Else
                    parTrnMs(i).sStaffName = pDataReader("スタッフ名称").ToString
                End If

                i = i + 1
            End While

            getTrnMs = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnMsDBIO.getTrnMs)", Nothing, Nothing, oExcept.ToString)
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
    ' 日次の売上明細を取得する関数
    ' 引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    ' 戻値：レコードの取得件数
    '----------------------------------------------------------------------
    Function getDaySaleMs(ByRef parDayTrhkMs() As cStructureLib.sViewDayTrhkMs, _
                          ByVal keyCloseDate As String, _
                          ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer

        Try
            ' SQL分の生成
            strSelectTrn = _
                        "SELECT " & _
                            "チャネルマスタ.チャネル名称, " & _
                            "日次取引明細データ.取引コード, " & _
                            "日次取引明細データ.取引明細コード, " & _
                            "日次取引データ.取引区分, " & _
                            "日次取引明細データ.売上状態, " & _
                            "日次取引明細データ.商品コード, " & _
                            "日次取引明細データ.商品名称, " & _
                            "日次取引明細データ.オプション1, " & _
                            "日次取引明細データ.オプション2, " & _
                            "日次取引明細データ.オプション3, " & _
                            "日次取引明細データ.オプション4, " & _
                            "日次取引明細データ.オプション5, " & _
                            "日次取引明細データ.定価, " & _
                            "日次取引明細データ.取引数量, " & _
                            "日次取引明細データ.取引税込金額 " & _
                        "FROM " & _
                            "(日次取引データ LEFT JOIN 日次取引明細データ " & _
                                "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                                    "INNER JOIN チャネルマスタ " & _
                                        "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード " & _
                        "WHERE " & _
                            " ((日次取引データ.取引区分) = ""売上""  " & _
                            "OR (日次取引データ.取引区分) = ""戻入"" ) "

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn & _
                            "AND 日次取引データ.日次締め日 Is Null " & _
                                "OR 日次取引データ.日次締め日 = """" "
            Else
                strSelectTrn = strSelectTrn & _
                            "AND 日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            strSelectTrn = strSelectTrn & _
                        "ORDER BY " & _
                            "日次取引データ.チャネルコード, " & _
                            "日次取引明細データ.取引コード, " & _
                            "日次取引明細データ.取引明細コード"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            ' レコードが取得できた時の処理
            While pDataReader.Read()

                ReDim Preserve parDayTrhkMs(i)

                ' チャネル名称
                parDayTrhkMs(i).sChannelName = pDataReader("チャネル名称").ToString

                ' 取引コード
                parDayTrhkMs(i).sTrhkCode = pDataReader("取引コード").ToString

                ' 取引明細コード
                parDayTrhkMs(i).sTrhkMsCode = pDataReader("取引明細コード").ToString

                ' 取引区分
                parDayTrhkMs(i).sTrhkKbn = pDataReader("取引区分").ToString

                ' 売上状態
                parDayTrhkMs(i).sStatus = pDataReader("売上状態").ToString

                ' 商品コード
                parDayTrhkMs(i).sProductCode = pDataReader("商品コード").ToString

                ' 商品名称
                parDayTrhkMs(i).sProductName = pDataReader("商品名称").ToString

                ' オプション1
                parDayTrhkMs(i).sOption1 = pDataReader("オプション1").ToString

                ' オプション2
                parDayTrhkMs(i).sOption2 = pDataReader("オプション2").ToString

                ' オプション3
                parDayTrhkMs(i).sOption3 = pDataReader("オプション3").ToString

                ' オプション4
                parDayTrhkMs(i).sOption4 = pDataReader("オプション4").ToString

                ' オプション5
                parDayTrhkMs(i).sOption5 = pDataReader("オプション5").ToString

                ' 定価
                parDayTrhkMs(i).sListPrice = pDataReader("定価").ToString

                ' 取引数量
                parDayTrhkMs(i).sCount = pDataReader("取引数量").ToString

                ' 取引税込金額
                parDayTrhkMs(i).sPrice = pDataReader("取引税込金額").ToString

                i = i + 1

            End While

            getDaySaleMs = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnMsDBIO.getSaleMs)", Nothing, Nothing, oExcept.ToString)
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
    ' リアル店舗での時間ごとの売り上げを算出
    ' 引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    ' 戻値：レコードの取得件数
    '----------------------------------------------------------------------
    Function getRealShopSales(ByRef parTimeSales() As cStructureLib.sViewTimeSales, _
                              ByVal keyCloseDate As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer = 0

        Try
            ' リアル店舗のデータを結合して取得する
            strSelectTrn = _
                "SELECT " & _
                    "日次取引データ.チャネルコード AS チャネルコード, " & _
                    "チャネルマスタ.チャネル名称 AS チャネル名称, " & _
                    "Sum(日次取引データ.取引税込金額) AS 合計金額, " & _
                    "Format(日次取引データ.登録時間,""HH"") AS 時間帯 " & _
                "FROM " & _
                    "日次取引データ INNER JOIN チャネルマスタ " & _
                        "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード " & _
                "WHERE " & _
                    "チャネルマスタ.チャネル種別 = 1 " & _
                    "AND ((日次取引データ.取引区分) = ""売上""  " & _
                        "OR (日次取引データ.取引区分) = ""戻入"" ) "

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn & _
                            "AND 日次取引データ.日次締め日 Is Null " & _
                                "OR 日次取引データ.日次締め日 = """" "
            Else
                strSelectTrn = strSelectTrn & _
                            "AND 日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            strSelectTrn = strSelectTrn & _
                "GROUP BY " & _
                    "日次取引データ.チャネルコード, " & _
                    "チャネルマスタ.チャネル名称, " & _
                    "Format(日次取引データ.登録時間, ""HH"") " & _
                "ORDER BY " & _
                    "日次取引データ.チャネルコード, " & _
                    "Format(日次取引データ.登録時間, ""HH"") "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            ' レコードが取得できた時の処理
            While pDataReader.Read()

                ReDim Preserve parTimeSales(i)

                ' チャネルコード
                parTimeSales(i).sChannelCode = pDataReader("チャネルコード").ToString
                ' チャネル名
                parTimeSales(i).sChannelName = pDataReader("チャネル名称").ToString
                ' 時間帯
                parTimeSales(i).sTimeZone = pDataReader("時間帯").ToString
                ' 金額の合計
                parTimeSales(i).sTimeSales = CLng(pDataReader("合計金額"))

                i = i + 1
            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnMsDBIO.getTimeSales)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

        getRealShopSales = i
    End Function
    '----------------------------------------------------------------------
    ' ネット店舗での時間ごとの売り上げを算出
    ' 引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '               (1)最終営業日と精算日の間に店休日を挟まない場合
    '               (2)最終営業日と精算日の間に店休日を挟む場合
    ' 戻値：レコードの取得件数
    ' 備考：抽出条件-日次取引データ.出荷コード = "0" は
    '       Amazonとe-shopのデータの取込み機能が追加されるまでの暫定対応
    '----------------------------------------------------------------------
    Function getNetShopSales(ByRef parTimeSales() As cStructureLib.sViewTimeSales,
                          ByVal keyCloseDate As String,
                          ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer = 0

        Try
            ' ネット店舗のデータを取得する
            ' ※日次取引データの出荷コードが0の場合、例外処理が走るため、
            ' 　抽出条件の「日次取引データ.出荷コード <> "0"」は暫定対応とする
            strSelectTrn =
                "SELECT " &
                    "日次取引データ.チャネルコード AS チャネルコード, " &
                    "チャネルマスタ.チャネル名称 AS チャネル名称, " &
                    "Sum(受注情報データ.受注税込金額) AS 合計金額, " &
                    "Format(受注情報データ.受注時間,""HH"") AS 時間帯 " &
                "FROM " &
                    "((日次取引データ LEFT JOIN 出荷情報データ " &
                        "ON 日次取引データ.出荷コード = 出荷情報データ.出荷コード) LEFT JOIN 受注情報データ " &
                            "ON 出荷情報データ.受注コード = 受注情報データ.受注コード) LEFT JOIN チャネルマスタ " &
                                "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード " &
                "WHERE " &
                        "チャネルマスタ.チャネル種別 = 2 " &
                    "AND " &
                        "日次取引データ.出荷コード <> ""0"" "

            If keyCloseDate = Nothing Then
                strSelectTrn = strSelectTrn &
                            "AND 日次取引データ.日次締め日 Is Null " &
                                "OR 日次取引データ.日次締め日 = """" "
            Else
                strSelectTrn = strSelectTrn &
                            "AND 日次取引データ.日次締め日 = """ & keyCloseDate & """ "
            End If

            strSelectTrn = strSelectTrn &
                "GROUP BY " &
                    "日次取引データ.チャネルコード, " &
                    "チャネルマスタ.チャネル名称, " &
                    "Format(受注情報データ.受注時間, ""HH"") " &
                "ORDER BY " &
                    "日次取引データ.チャネルコード, " &
                    "Format(受注情報データ.受注時間, ""HH"") "

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            ' レコードが取得できた時の処理
            While pDataReader.Read()

                ReDim Preserve parTimeSales(i)

                ' チャネルコード
                parTimeSales(i).sChannelCode = pDataReader("チャネルコード").ToString
                ' チャネル名
                parTimeSales(i).sChannelName = pDataReader("チャネル名称").ToString
                ' 時間帯
                parTimeSales(i).sTimeZone = pDataReader("時間帯").ToString
                ' 金額の合計
                If IsDBNull(pDataReader("合計金額")) = True Then
                    parTimeSales(i).sTimeSales = 0
                Else
                    parTimeSales(i).sTimeSales = CLng(pDataReader("合計金額"))
                End If


                i = i + 1
            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnMsDBIO.getTimeSales)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

        getNetShopSales = i
    End Function


    '2016.06.07 K.OIkawa s
    '取引履歴の表示を行う
    Public Function getHstTrn(ByRef perHstTrn() As cStructureLib.sViewHstTrn, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyRequestFromDate As String, _
                                    ByVal KeyRequestToDate As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyJanCode As String, _
                                    ByVal KeyProductName As String, _
                                    ByVal KeyMemberCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String
        Dim i As Integer
        Dim pc As Integer
        Dim cnt As Integer

        Try
            strSelectTrn = _
                "SELECT "

            '取得カラム
            strSelectTrn = strSelectTrn & _
                        "日次取引データ.登録日, " & _
                        "日次取引データ.登録時間, " & _
                        "日次取引明細データ.商品名称, " & _
                        "IIf(IsNull(日次取引明細データ.取引商品単価),0,日次取引明細データ.取引商品単価) AS 取引商品単価 , " & _
                        "IIf(IsNull(日次取引明細データ.取引数量),0,日次取引明細データ.取引数量) " & _
                        "+ IIf(IsNull(B.取引数量),0,B.取引数量) " & _
                        " AS 取引数量 , " & _
                        "会員マスタ.会員名称, " & _
                        "チャネルマスタ.チャネル名称, " & _
                        "スタッフマスタ.スタッフ名称, " & _
                        "日次取引データ.取引コード, " & _
                        "日次取引データ.チャネルコード, " & _
                        "日次取引明細データ.オプション1, " & _
                        "日次取引明細データ.オプション2, " & _
                        "日次取引明細データ.オプション3, " & _
                        "日次取引明細データ.オプション4, " & _
                        "日次取引明細データ.オプション5, " & _
                        "支払方法マスタ.支払方法名称, " & _
                        "日次取引明細データ.JANコード "

            strSelectTrn = strSelectTrn & _
                        "FROM ((((((日次取引データ " & _
                        "LEFT JOIN 日次取引明細データ " & _
                        "ON 日次取引データ.取引コード = 日次取引明細データ.取引コード) " & _
                        "LEFT JOIN 会員マスタ " & _
                        "ON 日次取引データ.会員コード = 会員マスタ.会員コード) " & _
                        "LEFT JOIN チャネルマスタ " & _
                        "ON 日次取引データ.チャネルコード = チャネルマスタ.チャネルコード) " & _
                        "LEFT JOIN スタッフマスタ " & _
                        "ON 日次取引データ.取引担当者コード = スタッフマスタ.スタッフコード) " & _
                        "LEFT JOIN 支払方法マスタ " & _
                        "ON 日次取引データ.支払方法コード = 支払方法マスタ.支払方法コード) " & _
                        "LEFT JOIN 日次取引明細データ AS B " & _
                        "ON B.備考 LIKE 日次取引明細データ.取引コード & ""-"" & 日次取引明細データ.取引明細コード & ""-%"" ) " & _
                        "WHERE (日次取引明細データ.送料 + 日次取引明細データ.手数料 + 日次取引明細データ.値引き + 日次取引明細データ.ポイント値引き + 日次取引明細データ.チケット値引き) = 0 " & _
                        "AND EXISTS( " & _
                        "SELECT 取引コード , 商品コード , SUM(取引数量) " & _
                        "FROM( " & _
                        "SELECT B.取引コード , A.商品コード , A.取引数量 FROM 日次取引明細データ AS A INNER JOIN 日次取引明細データ AS B ON A.商品コード = B.商品コード WHERE A.備考 <> """" AND A.備考 like B.取引コード & ""-%"" " & _
                        "UNION " & _
                        "SELECT 取引コード , 商品コード, 取引数量 FROM 日次取引明細データ " & _
                        ") " & _
                        "GROUP BY 取引コード, 商品コード " & _
                        "HAVING 取引コード = 日次取引明細データ.取引コード " & _
                        "AND 商品コード = 日次取引明細データ.商品コード " & _
                        "AND SUM(取引数量) > 0 " & _
                        ") "

                    'パラメータ数のカウント
            pc = 0
            If KeyChannelCode <> Nothing Then           'チャネルコード
                pc = pc Or 1
                    End If
            If KeyRequestFromDate <> Nothing Then       'From
                pc = pc Or 2
                    End If
            If KeyRequestToDate <> Nothing Then         'To
                pc = pc Or 4
                    End If
            If KeyProductCode <> Nothing Then           '商品コード
                pc = pc Or 8
                    End If
            If KeyJanCode <> Nothing Then               'JANコード
                pc = pc Or 16
                    End If
            If KeyProductName <> Nothing Then            '商品名
                pc = pc Or 32
                    End If
            If KeyMemberCode <> Nothing Then             '会員コード
                pc = pc Or 64
            End If

            cnt = 0

            'パラメータ指定がある場合
            If 1024 And pc > 0 Then
                i = 1
                While i <= 1024
                    Select Case i And pc
                        Case 1      'チャネルコード
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引データ.チャネルコード= " & KeyChannelCode & " "
                            'cnt = cnt + 1
                        Case 2      'From
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引データ.登録日 >= """ & KeyRequestFromDate & """ "
                            'cnt = cnt + 1
                        Case 4      'To
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引データ.登録日 <= """ & KeyRequestToDate & """ "
                            'cnt = cnt + 1
                        Case 8      '商品コード
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引明細データ.商品コード Like ""%" & KeyProductCode & "%"" "
                            'cnt = cnt + 1
                        Case 16     '商品JANコード

                            '2016.09.12 K.Oikawa s
                            '課題表No.165 修正漏れ
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            '    strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "AND "
                            '2016.09.12 K.Oikawa e

                            strSelectTrn = strSelectTrn & "日次取引明細データ.JANコード Like ""%" & KeyJanCode & "%"" "
                            cnt = cnt + 1
                        Case 32     '商品名
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引明細データ.商品名称 Like ""%" & KeyProductName & "%"" "
                            'cnt = cnt + 1
                        Case 64     '会員コード
                            'If cnt = 0 Then
                            '    strSelectTrn = strSelectTrn & "WHERE "
                            'Else
                            strSelectTrn = strSelectTrn & "AND "
                            'End If
                            strSelectTrn = strSelectTrn & "日次取引データ.会員コード Like ""%" & KeyMemberCode & "%"" "
                            'cnt = cnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'コマンドオブジェクトの生成
                    pCommand = pConn.CreateCommand()
                    pCommand.Transaction = Tran

                    pCommand.CommandText = strSelectTrn

                    pDataReader = pCommand.ExecuteReader()

                    i = 0

                    ' レコードが取得できた時の処理
                    While pDataReader.Read()

                        ReDim Preserve perHstTrn(i)


                        ' 登録日
                        perHstTrn(i).sRequestDate = pDataReader("登録日").ToString

                        ' 登録時間
                        perHstTrn(i).sRequesTime = pDataReader("登録時間").ToString

                        ' 商品名称
                        perHstTrn(i).sProductName = pDataReader("商品名称").ToString

                        If pDataReader("オプション1").ToString <> "" Then
                            perHstTrn(i).sProductName = perHstTrn(i).sProductName & "_" & pDataReader("オプション1").ToString
                        End If
                        If pDataReader("オプション2").ToString <> "" Then
                            perHstTrn(i).sProductName = perHstTrn(i).sProductName & "_" & pDataReader("オプション2").ToString
                        End If
                        If pDataReader("オプション3").ToString <> "" Then
                            perHstTrn(i).sProductName = perHstTrn(i).sProductName & "_" & pDataReader("オプション3").ToString
                        End If
                        If pDataReader("オプション4").ToString <> "" Then
                            perHstTrn(i).sProductName = perHstTrn(i).sProductName & "_" & pDataReader("オプション4").ToString
                        End If
                        If pDataReader("オプション5").ToString <> "" Then
                            perHstTrn(i).sProductName = perHstTrn(i).sProductName & "_" & pDataReader("オプション5").ToString
                        End If

                        '商品JANコード
                        perHstTrn(i).sJanCode = pDataReader("JANコード").ToString

                        ' 取引商品単価
                        perHstTrn(i).sUnitPrice = CInt(pDataReader("取引商品単価").ToString)

                        ' 取引数量
                        perHstTrn(i).sCount = CInt(pDataReader("取引数量").ToString)

                        ' 会員名称
                        perHstTrn(i).sMemberName = pDataReader("会員名称").ToString

                        ' チャネル名称
                        perHstTrn(i).sChannelName = pDataReader("チャネル名称").ToString

                        ' 担当者
                        perHstTrn(i).sStaffName = pDataReader("スタッフ名称").ToString

                        ' JANコード
                        perHstTrn(i).sTrnCode = pDataReader("取引コード").ToString

                        ' チャネルコード
                        perHstTrn(i).sChannelCode = CInt(pDataReader("チャネルコード").ToString)

                        ' 支払方法名称
                        perHstTrn(i).sPaymentMethod = pDataReader("支払方法名称").ToString

                        i = i + 1
                    End While

                    getHstTrn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnMsDBIO.getTrnMs)", Nothing, Nothing, oExcept.ToString)
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
    '2016.06.07 K.OIkawa e

End Class
