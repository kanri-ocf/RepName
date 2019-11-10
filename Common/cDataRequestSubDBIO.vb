
Public Class cDataRequestSubDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    '-------------------------------------------------------------------------------
    '　機能：受注情報明細データから該当レコードを取得する関数
    '　引数：Byref parSubRequest()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getSubRequest(ByRef parSubRequest() As cStructureLib.sRequestSubData,
                                    ByVal KeyRequestCode As String,
                                    ByVal KeyShipmentCode As String,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報明細データ "

        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> "" Then
            pc = pc Or 1
        End If
        'If KeyShipmentCode <> "" Then
        '    pc = pc Or 2
        'End If

        'パラメータ指定がある場合
        If (3 And pc) > 0 Then
            i = 1
            scnt = 0
            While i <= 2
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード =@RequestCode "
                        scnt = scnt + 1
                        'Case 2
                        '    If scnt > 0 Then
                        '        strSelect = strSelect & "AND "
                        '    Else
                        '        strSelect = strSelect & "WHERE "
                        '    End If
                        '    strSelect = strSelect & "出荷コード =@ShipmentCode "
                        '    scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 受注コード, 受注明細コード "
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************
            If (3 And pc) > 0 Then
                i = 1
                scnt = 0
                While i <= 2
                    Select Case i And pc
                        Case 1
                            '受注コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char))
                            pCommand.Parameters("@RequestCode").Value = KeyRequestCode
                            scnt = scnt + 1
                            'Case 2
                            '    '出荷コード
                            '    pCommand.Parameters.Add _
                            '    (New OleDb.OleDbParameter("@ShipmentCode", OleDb.OleDbType.Char))
                            '    pCommand.Parameters("@ShipmentCode").Value = KeyShipmentCode
                            '    scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parSubRequest(i)

                '受注コード
                parSubRequest(i).sRequestCode = pDataReader("受注コード").ToString
                'OR受注コード
                parSubRequest(i).sORRequestCode = pDataReader("OR受注コード").ToString
                '受注明細コード
                parSubRequest(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))
                '商品コード
                parSubRequest(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parSubRequest(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parSubRequest(i).sProductName = pDataReader("商品名称").ToString
                'オプション名称
                parSubRequest(i).sOptionName = pDataReader("オプション名称").ToString
                'オプション値
                parSubRequest(i).sOptionValue = pDataReader("オプション値").ToString
                '定価
                parSubRequest(i).sListPrice = CLng(pDataReader("定価"))
                '仕入単価
                parSubRequest(i).sCostPrice = CLng(pDataReader("仕入単価"))

                '2019/10/4 shimizu add start
                '軽減税率
                parSubRequest(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '2019/10/4 shimizu add end

                '受注商品単価
                parSubRequest(i).sUnitPrice = CLng(pDataReader("受注商品単価"))
                '受注数量
                parSubRequest(i).sCount = CInt(pDataReader("受注数量"))
                '受注税抜金額
                parSubRequest(i).sNoTaxPrice = CLng(pDataReader("受注税抜金額"))
                '受注消費税額
                parSubRequest(i).sTaxPrice = CLng(pDataReader("受注消費税額"))
                '受注税込金額
                parSubRequest(i).sPrice = CLng(pDataReader("受注税込金額"))
                'チャネル商品コード
                parSubRequest(i).sChannelProductCode = pDataReader("チャネル商品コード").ToString
                'チャネル商品名称
                parSubRequest(i).sChannelProductName = pDataReader("チャネル商品名称").ToString
                'チャネルオプション
                parSubRequest(i).sChannelOptionNameAndValue = pDataReader("チャネルオプション").ToString
                '登録日
                parSubRequest(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSubRequest(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSubRequest(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSubRequest(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getSubRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubDBIO.getSubRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：注文明細情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSubRequestData(ByRef parSubRequest() As cStructureLib.sRequestSubData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strInsert As String
        Dim i As Long

        'SQL文の設定

        strInsert = "INSERT INTO 受注情報明細データ (" &
                        "受注コード, OR受注コード, 受注明細コード, 商品コード, JANコード, 商品名称, オプション名称, オプション値, 定価, 仕入単価, 受注商品単価, 受注数量, 受注税抜金額, 受注消費税額, 受注税込金額, チャネル商品コード, チャネル商品名称, チャネルオプション, 登録日, 登録時間, 最終更新日, 最終更新時間" &
                    ") VALUES (" &
                        "@RequestCode, @ORRequestCode, @RequestSubCode, @ProductCode, @JANCode, @ProductName, @OptionName, @OptionValue, @ListPrice, @CostPrice, @UnitPrice, @Count, @NoTaxPrice, @TaxPrice, @Price, @ChannelProductCode, @ChannelProductName, @ChannelOptionNameAndValue, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime" &
                    ")"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            For i = 0 To parSubRequest.Length - 1
                '受注コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char))
                pCommand.Parameters("@RequestCode").Value = parSubRequest(i).sRequestCode
                'OR受注コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ORRequestCode", OleDb.OleDbType.Char))
                pCommand.Parameters("@ORRequestCode").Value = parSubRequest(i).sORRequestCode
                '受注明細コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@RequestSubCode", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@RequestSubCode").Value = parSubRequest(i).sRequestSubCode
                '商品コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char))
                pCommand.Parameters("@ProductCode").Value = parSubRequest(i).sProductCode
                'JANコード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char))
                pCommand.Parameters("@JANCode").Value = parSubRequest(i).sJANCode
                '商品名称
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char))
                pCommand.Parameters("@ProductName").Value = parSubRequest(i).sProductName
                'オプション名称
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@OptionName", OleDb.OleDbType.Char))
                pCommand.Parameters("@OptionName").Value = parSubRequest(i).sOptionName
                'オプション値
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@OptionValue", OleDb.OleDbType.Char))
                pCommand.Parameters("@OptionValue").Value = parSubRequest(i).sOptionValue
                '定価
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@ListPrice").Value = parSubRequest(i).sListPrice
                '仕入単価
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@CostPrice").Value = parSubRequest(i).sCostPrice
                '受注商品単価
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@UnitPrice").Value = parSubRequest(i).sUnitPrice
                '受注数量
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@Count").Value = parSubRequest(i).sCount
                '受注税抜金額
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@NoTaxPrice").Value = parSubRequest(i).sNoTaxPrice
                '受注消費税額
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@TaxPrice").Value = parSubRequest(i).sTaxPrice
                '受注税込金額
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric))
                pCommand.Parameters("@Price").Value = parSubRequest(i).sPrice
                'チャネル商品コード
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ChannelProductCode", OleDb.OleDbType.Char))
                pCommand.Parameters("@ChannelProductCode").Value = parSubRequest(i).sChannelProductCode
                'チャネル商品名称
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ChannelProductName", OleDb.OleDbType.Char))
                pCommand.Parameters("@ChannelProductName").Value = parSubRequest(i).sChannelProductName
                'チャネルオプション
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ChannelOptionNameAndValue", OleDb.OleDbType.Char))
                pCommand.Parameters("@ChannelOptionNameAndValue").Value = parSubRequest(i).sChannelOptionNameAndValue
                '登録日
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char))
                pCommand.Parameters("@CreateDate").Value = parSubRequest(i).sCreateDate
                '登録時間
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char))
                pCommand.Parameters("@CreateTime").Value = parSubRequest(i).sCreateTime
                '最終更新日
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char))
                pCommand.Parameters("@UpdateDate").Value = parSubRequest(i).sUpdateDate
                '最終更新時間
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char))
                pCommand.Parameters("@UpdateTime").Value = parSubRequest(i).sUpdateTime


                '受注情報データ挿入処理実行
                pCommand.ExecuteNonQuery()
            Next i
            insertSubRequestData = i + 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubDBIO.insertSubRequestMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        End Try

    End Function

    Public Function insertTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String
        Dim executeCount As Long = 0

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            strSQL =
                    "INSERT INTO 受注情報明細データ ( " &
                        "受注コード," &
                        "OR受注コード," &
                        "受注明細コード," &
                        "商品コード," &
                        "JANコード," &
                        "商品名称," &
                        "オプション名称," &
                        "オプション値," &
                        "定価," &
                        "仕入単価," &
                        "受注商品単価," &
                        "受注数量," &
                        "受注税抜金額," &
                        "受注消費税額," &
                        "受注税込金額," &
                        "チャネル商品コード," &
                        "チャネル商品名称," &
                        "チャネルオプション," &
                        "登録日," &
                        "登録時間," &
                        "最終更新日," &
                        "最終更新時間" &
                    ") " &
                    "SELECT " &
                        "受注情報明細データTMP.受注コード, " &
                        "受注情報明細データTMP.OR受注コード, " &
                        "受注情報明細データTMP.受注明細コード, " &
                        "商品マスタ.商品コード, " &
                        "商品マスタ.JANコード, " &
                        "商品マスタ.商品名称, " &
                        "TRIM(" &
                        "    IIF((ISNULL(商品マスタ.オプション1) OR 商品マスタ.オプション1=""""), """", 環境M.オプション1項目名 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション2) OR 商品マスタ.オプション2=""""), """", 環境M.オプション2項目名 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション3) OR 商品マスタ.オプション3=""""), """", 環境M.オプション3項目名 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション4) OR 商品マスタ.オプション4=""""), """", 環境M.オプション4項目名 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション5) OR 商品マスタ.オプション5=""""), """", 環境M.オプション5項目名 & CHR(32))   " &
                        "    ), " &
                        "TRIM(" &
                        "    IIF((ISNULL(商品マスタ.オプション1) OR 商品マスタ.オプション1=""""), """", 商品マスタ.オプション1 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション2) OR 商品マスタ.オプション2=""""), """", 商品マスタ.オプション2 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション3) OR 商品マスタ.オプション3=""""), """", 商品マスタ.オプション3 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション4) OR 商品マスタ.オプション4=""""), """", 商品マスタ.オプション4 & CHR(32)) & " &
                        "    IIF((ISNULL(商品マスタ.オプション5) OR 商品マスタ.オプション5=""""), """", 商品マスタ.オプション5 & CHR(32))   " &
                        "    ), " &
                        "商品マスタ.定価, " &
                        "受注情報明細データTMP.仕入単価, " &
                        "受注情報明細データTMP.受注商品単価, " &
                        "受注情報明細データTMP.受注数量, " &
                        "受注情報明細データTMP.受注税抜金額, " &
                        "受注情報明細データTMP.受注消費税額, " &
                        "受注情報明細データTMP.受注税込金額, " &
                        "受注情報明細データTMP.チャネル商品コード, " &
                        "受注情報明細データTMP.チャネル商品名称, " &
                        "受注情報明細データTMP.チャネルオプション, " &
                        "受注情報明細データTMP.登録日, " &
                        "受注情報明細データTMP.登録時間, " &
                        "受注情報明細データTMP.最終更新日, " &
                        "受注情報明細データTMP.最終更新時間 " &
                    "FROM 受注情報明細データTMP, 受注情報データ, 商品コード変換マスタ, 商品マスタ, (SELECT * FROM 環境マスタ WHERE 環境マスタ.No = 1) 環境M " &
                    "WHERE 受注情報データ.受注コード = 受注情報明細データTMP.受注コード " &
                    "AND   商品コード変換マスタ.チャネルコード = 受注情報データ.チャネルコード " &
                    "AND   商品コード変換マスタ.チャネル商品コード = 受注情報明細データTMP.チャネル商品コード " &
                    "AND   商品コード変換マスタ.チャネル商品名称 = 受注情報明細データTMP.チャネル商品名称 " &
                    "AND   商品コード変換マスタ.チャネルオプション = 受注情報明細データTMP.チャネルオプション " &
                    "AND   商品マスタ.商品コード = 商品コード変換マスタ.商品コード "


            pCommand.CommandText = strSQL
            executeCount = pCommand.ExecuteNonQuery()

            insertTmpToRequest = executeCount

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubDBIO.insertTmpToRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
    '        一時表から受注情報および受注情報明細をまとめて登録する
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String
        Dim executeCount As Long = 0

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'コピー済み一時表データ(受注情報データTMP)の削除
            strSQL = "DELETE FROM 受注情報明細データTMP " &
                     "WHERE EXISTS( " &
                     "			SELECT	1 " &
                     "			FROM	受注情報データ " &
                     "			WHERE	受注情報データ.受注コード = 受注情報明細データTMP.受注コード " &
                     "	  ) "
            pCommand.CommandText = strSQL
            deleteTmpToRequest = pCommand.ExecuteNonQuery()
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubDBIO.deleteTmpToRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        End Try
    End Function

    '-------------------------------------------------------------------------------
    '　機能：受注情報明細データから該当レコードを取得する関数
    '　引数：Byref parSubRequest()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function insertChargeRecords(ByRef Tran As System.Data.OleDb.OleDbTransaction,
                                        ByRef oConf() As cStructureLib.sConfig) As Long

        Dim strSelect As String
        Dim i As Long
        Dim lineNum As Integer
        Dim price As Long = 0
        Dim description As String = ""
        Dim parSubRequest() As cStructureLib.sRequestSubData
        Dim oTool As New cTool

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT " &
                    "受注情報明細データTMP.受注コード          AS 受注コード, " &
                    "受注情報明細データTMP.OR受注コード        AS OR受注コード, " &
                    "MAX(受注情報明細データTMP.受注明細コード) AS 受注明細コード, " &
                    "受注情報データ.送料                       AS 送料," &
                    "受注情報データ.手数料                     AS 手数料," &
                    "受注情報データ.値引き                     AS 値引き," &
                    "受注情報データ.ポイント値引き             AS ポイント値引き " &
                "FROM 受注情報明細データTMP, 受注情報データ " &
                "WHERE 受注情報データ.受注コード = 受注情報明細データTMP.受注コード " &
                "GROUP BY 受注情報明細データTMP.受注コード, 受注情報明細データTMP.OR受注コード, 受注情報データ.送料, " &
                "受注情報データ.手数料, 受注情報データ.値引き, 受注情報データ.ポイント値引き "
        Try
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            ReDim parSubRequest(0)

            While pDataReader.Read()

                lineNum = CInt(pDataReader("受注明細コード"))

                For index As Integer = 1 To 4
                    Select Case index
                        Case 1
                            price = CLng(pDataReader("送料"))
                            description = "送料"
                        Case 2
                            price = CLng(pDataReader("手数料"))
                            description = "手数料"
                        Case 3
                            price = CLng(pDataReader("値引き"))
                            description = "値引き"
                        Case 4
                            price = CLng(pDataReader("ポイント値引き"))
                            description = "ポイント値引き"
                    End Select


                    If price <> 0 Then

                        ReDim Preserve parSubRequest(i)

                        lineNum += 1

                        '受注コード
                        parSubRequest(i).sRequestCode = pDataReader("受注コード").ToString
                        'OR受注コード
                        parSubRequest(i).sORRequestCode = pDataReader("OR受注コード").ToString
                        '受注明細コード
                        parSubRequest(i).sRequestSubCode = lineNum
                        '商品コード
                        parSubRequest(i).sProductCode = ""
                        'JANコード
                        parSubRequest(i).sJANCode = ""
                        '商品名称
                        parSubRequest(i).sProductName = description
                        'オプション名称
                        parSubRequest(i).sOptionName = ""
                        'オプション値
                        parSubRequest(i).sOptionValue = ""
                        '定価
                        parSubRequest(i).sListPrice = 0
                        '仕入単価
                        parSubRequest(i).sCostPrice = 0
                        '受注商品単価
                        parSubRequest(i).sUnitPrice = price
                        '受注数量
                        parSubRequest(i).sCount = 1
                        '受注税抜金額
                        parSubRequest(i).sNoTaxPrice = price
                        '受注消費税額
                        parSubRequest(i).sTaxPrice = oTool.BeforeToTax(price, oConf(0).sTax, oConf(0).sFracProc)
                        '受注税込金額
                        parSubRequest(i).sPrice = parSubRequest(i).sNoTaxPrice + parSubRequest(i).sTaxPrice
                        'チャネル商品コード
                        parSubRequest(i).sChannelProductCode = ""
                        'チャネル商品名称
                        parSubRequest(i).sChannelProductName = ""
                        'チャネルオプション
                        parSubRequest(i).sChannelOptionNameAndValue = ""
                        '登録日
                        parSubRequest(i).sCreateDate = String.Format("{0:yyyy/MM/dd}", Now)
                        '登録時間
                        parSubRequest(i).sCreateTime = String.Format("{0:HH:mm:ss}", Now)
                        '最終更新日
                        parSubRequest(i).sUpdateDate = String.Format("{0:yyyy/MM/dd}", Now)
                        '最終更新時間
                        parSubRequest(i).sUpdateTime = String.Format("{0:HH:mm:ss}", Now)

                        'レコードが取得できた時の処理
                        i = i + 1
                    End If
                Next

            End While

            If i > 0 Then
                insertChargeRecords = insertSubRequestData(parSubRequest, Tran)
            End If
            oTool = Nothing

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubDBIO.getSubRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        End Try

    End Function



    '----------------------------------------------------
    '2015/07/07
    '及川和彦
    '商品コードで絞込
    'FROM
    '----------------------------------------------------

    Public Function getRequestSubProduct(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        Try
            strSelect = ""
            strSelect = "SELECT COUNT(*) AS CNT FROM 受注情報明細データ WHERE 商品コード = """ & KeyProductCode & """"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()

            getRequestSubProduct = CLng(pDataReader("CNT"))

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cArrivalDataSubDBIO.getArrivalSubData)", Nothing, Nothing, oExcept.ToString)
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
    '----------------------------------------------------
    'HERE
    '----------------------------------------------------





End Class
