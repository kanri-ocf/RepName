Public Class cDataRequestSubTMPDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Private metaInfo As Hashtable
    Private l As cLog

    Private Shared columnNames As String()
    Private Shared paramNames As String()

    Shared Sub New()
        Dim c As New List(Of String)
        Dim p As New List(Of String)
        c.Add("受注コード") : p.Add("@RequestCode")
        c.Add("OR受注コード") : p.Add("@ORRequestCode")
        c.Add("受注明細コード") : p.Add("@RequestSubCode")
        c.Add("商品コード") : p.Add("@ProductCode")
        c.Add("JANコード") : p.Add("@JANCode")
        c.Add("商品名称") : p.Add("@ProductName")
        c.Add("オプション名称") : p.Add("@OptionName")
        c.Add("オプション値") : p.Add("@OptionValue")
        c.Add("定価") : p.Add("@ListPrice")
        c.Add("仕入単価") : p.Add("@CostPrice")
        c.Add("受注商品単価") : p.Add("@UnitPrice")
        c.Add("受注数量") : p.Add("@Count")


        c.Add("受注税抜金額") : p.Add("@NoTaxPrice")
        c.Add("受注消費税額") : p.Add("@TaxPrice")
        c.Add("受注税込金額") : p.Add("@Price")
        c.Add("チャネル商品コード") : p.Add("@ChannelProductCode")
        c.Add("チャネル商品名称") : p.Add("@ChannelProductName")
        c.Add("チャネルオプション") : p.Add("@ChannelOptionNameAndValue")
        c.Add("登録日") : p.Add("@CreateDate")
        c.Add("登録時間") : p.Add("@CreateTime")
        c.Add("最終更新日") : p.Add("@UpdateDate")
        c.Add("最終更新時間") : p.Add("@UpdateTime")
        columnNames = c.ToArray
        paramNames = p.ToArray
    End Sub


    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub


    '-------------------------------------------------------------------------------
    '　機能：受注情報明細データTMPから該当レコードを取得する関数
    '　引数：Byref parSubRequest()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getSubRequest(ByRef parSubRequest() As cStructureLib.sRequestSubData, _
                                    ByVal KeyRequestCode As String, _
                                    ByVal KeyShipmentCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報明細データTMP "

        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> "" Then
            pc = pc Or 1
        End If
        'If KeyShipmentCode <> "" Then
        '    pc = pc Or 2
        'End If

        'パラメータ指定がある場合
        If (2 And pc) > 0 Then
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

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************
            If (2 And pc) > 0 Then
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


                '受注明細コード

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getSubRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubTMPDBIO.getSubRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：注文明細情報データTMPに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSubRequestMst2(ByRef parSubRequestInfo As Hashtable, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim rowCnt As Integer
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 受注情報明細データTMP (" & _
                        "受注コード, OR受注コード, 受注明細コード, 商品コード, JANコード, 商品名称, オプション名称, オプション値, 定価, 仕入単価, 受注商品単価, 受注数量, 受注税抜金額, 受注消費税額, 受注税込金額, チャネル商品コード, チャネル商品名称, チャネルオプション, 登録日, 登録時間, 最終更新日, 最終更新時間" & _
                    ") VALUES (" & _
                        "@RequestCode, @ORRequestCode, @RequestSubCode, @ProductCode, @JANCode, @ProductName, @OptionName, @OptionValue, @ListPrice, @CostPrice, @UnitPrice, @Count, @NoTaxPrice, @TaxPrice, @Price, @ChannelProductCode, @ChannelProductName, @ChannelOptionNameAndValue, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime" & _
                    ")"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            'パラメータの設定()
            '***********************
            For i = 0 To columnNames.Length - 1
                If parSubRequestInfo.ContainsKey(columnNames(i)) Then
                    ' ダウンロードカラムマスタで定義しているDB項目について
                    Dim ht As Hashtable = metaInfo(columnNames(i))
                    Dim dataType As String = CType(ht("DataType"), String)
                    Dim columnSize As Integer = CType(ht("ColumnSize"), Integer)

                    Select Case dataType
                        Case "System.String"
                            Dim s As String = parSubRequestInfo(columnNames(i))
                            If s Is Nothing Then s = ""
                            If s.Length > columnSize Then
                                s = Left(s, columnSize)
                                Dim msg As String = "DBカラムサイズオーバーのため値を切捨て (注文番号：" & parSubRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parSubRequestInfo(columnNames(i)) & " → " & s
                                l.write(msg)
                            End If
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Char))
                            pCommand.Parameters(paramNames(i)).Value = s
                        Case "System.Int16"
                            Dim s As String = parSubRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim n16 As Integer
                            Try
                                n16 = CInt(s)
                            Catch ex As Exception
                                n16 = 0
                                Dim msg As String = "文字列から数値への変換エラー：値を0へ置換え (注文番号：" & parSubRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parSubRequestInfo(columnNames(i)) & " → 0"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = n16
                        Case "System.Int32"
                            Dim s As String = parSubRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim n32 As Long
                            Try
                                n32 = CLng(s)
                            Catch ex As Exception
                                n32 = 0L
                                Dim msg As String = "文字列から数値への変換エラー：値を0へ置換え (注文番号：" & parSubRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parSubRequestInfo(columnNames(i)) & " → 0"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = n32
                        Case "System.Boolean"
                            Dim s As String = parSubRequestInfo(columnNames(i))
                            If s Is Nothing Then s = "0" : If s = "" Then s = "0"
                            Dim b As Boolean
                            Try
                                b = CBool(parSubRequestInfo(columnNames(i)))
                            Catch ex As Exception
                                b = False
                                Dim msg As String = "文字列からブール値への変換エラー：値をFALSEへ置換え (注文番号：" & parSubRequestInfo("OR受注コード") & ")：" & vbCrLf
                                msg &= "DBテーブル名    → " & "受注情報データTMP" & vbCrLf
                                msg &= "DB項目名        → " & columnNames(i) & "(サイズ：" & columnSize.ToString & ")" & vbCrLf
                                msg &= "DB項目値        → " & parSubRequestInfo(columnNames(i)) & " → FALSE"
                                l.write(msg)
                            End Try
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Boolean))
                            pCommand.Parameters(paramNames(i)).Value = b
                        Case Else
                            Throw New Exception("システムエラー(非対応のデータ型が当該テーブルに定義されています)")
                    End Select
                Else
                    ' ダウンロードカラムマスタで未定義のDB項目について
                    Dim ht As Hashtable = metaInfo(columnNames(i))
                    Dim dataType As String = CType(ht("DataType"), String)
                    Select Case dataType
                        Case "System.String"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Char))
                            pCommand.Parameters(paramNames(i)).Value = ""
                        Case "System.Int16"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = 0
                        Case "System.Int32"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Numeric))
                            pCommand.Parameters(paramNames(i)).Value = 0L
                        Case "System.Boolean"
                            pCommand.Parameters.Add(New OleDb.OleDbParameter(paramNames(i), OleDb.OleDbType.Boolean))
                            pCommand.Parameters(paramNames(i)).Value = False
                        Case Else
                            Throw New Exception("システムエラー(非対応のデータ型が当該テーブルに定義されています)")
                    End Select
                End If
            Next

            '受注情報データ挿入処理実行
            rowCnt = pCommand.ExecuteNonQuery()
            Return rowCnt

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubTMPDBIO.insertSubRequestMst2)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Sub setMetaInfo(ByRef Tran As System.Data.OleDb.OleDbTransaction)
        Dim strSelect As String
        Dim dt As DataTable

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT TOP 1 * FROM 受注情報明細データTMP "

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()

            '当該テーブルのメタ情報を取得
            dt = pDataReader.GetSchemaTable()

            metaInfo = New Hashtable

            For Each row As DataRow In dt.Rows
                Dim key As String = ""
                Dim ht As New Hashtable
                For Each col As DataColumn In dt.Columns
                    Select Case col.ColumnName
                        Case "ColumnName"
                            key = row(col).ToString()
                        Case "ColumnSize"
                            ht.Add("ColumnSize", row(col).ToString())
                        Case "DataType"
                            ht.Add("DataType", row(col).ToString())
                    End Select
                Next
                metaInfo.Add(key, ht)
            Next

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestSubTMPDBIO.setMetaInfo)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            dt = Nothing
        End Try

    End Sub

    Public Sub setLogWriter(ByRef l As cLog)
        Me.l = l
    End Sub

End Class
