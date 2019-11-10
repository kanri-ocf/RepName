
Public Class cDataShipmentSubDBIO
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
    '　機能：出荷情報明細データから該当レコードを取得する関数
    '　引数：Byref parSubShipment()　：データセットバッファ（sShipment Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Shipment_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getSubShipment(ByRef parShipmentSubData() As cStructureLib.sShipmentSubData,
                                    ByVal KeyRequestCode As String,
                                    ByVal KeyShipmentCode As String,
                                    ByVal KeyRequestSubCode As Integer,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction
                               ) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 出荷情報明細データ "

        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> "" Then
            pc = pc Or 1
        End If
        If KeyShipmentCode <> "" Then
            pc = pc Or 2
        End If
        If KeyRequestSubCode <> Nothing Then
            pc = pc Or 4
        End If

        'パラメータ指定がある場合
        If 4 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 4
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード =@RequestCode "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "出荷コード =@ShipmentCode "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注明細コード =@RequestSubCode "
                        scnt = scnt + 1
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
            If 4 And pc > 0 Then
                i = 1
                scnt = 0
                While i <= 4
                    Select Case i And pc
                        Case 1
                            '受注コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
                            pCommand.Parameters("@RequestCode").Value = KeyRequestCode
                            scnt = scnt + 1
                        Case 2
                            '出荷コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@ShipmentCode", OleDb.OleDbType.Char, 13))
                            pCommand.Parameters("@ShipmentCode").Value = KeyShipmentCode
                            scnt = scnt + 1
                        Case 4
                            '受注明細コード
                            pCommand.Parameters.Add _
                            (New OleDb.OleDbParameter("@RequestSubCode", OleDb.OleDbType.Numeric, 5))
                            pCommand.Parameters("@RequestSubCode").Value = KeyRequestSubCode
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parShipmentSubData(i)

                '受注コード
                parShipmentSubData(i).sRequestCode = pDataReader("受注コード").ToString
                '出荷コード
                parShipmentSubData(i).sShipNumber = pDataReader("出荷コード").ToString
                '受注明細コード
                If IsDBNull(pDataReader("受注明細コード")) = True Then
                    parShipmentSubData(i).sRequestSubCode = 0
                Else
                    parShipmentSubData(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))
                End If
                '商品コード
                parShipmentSubData(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parShipmentSubData(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parShipmentSubData(i).sProductName = pDataReader("商品名称").ToString
                'オプション名称
                parShipmentSubData(i).sOptionName = pDataReader("オプション名称").ToString
                'オプション値
                parShipmentSubData(i).sOptionValue = pDataReader("オプション値").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parShipmentSubData(i).sListPrice = 0
                Else
                    parShipmentSubData(i).sListPrice = CLng(pDataReader("定価"))
                End If
                '仕入単価
                If IsDBNull(pDataReader("仕入単価")) = True Then
                    parShipmentSubData(i).sCostPrice = 0
                Else
                    parShipmentSubData(i).sCostPrice = CLng(pDataReader("仕入単価"))
                End If
                '出荷商品単価
                If IsDBNull(pDataReader("出荷商品単価")) = True Then
                    parShipmentSubData(i).sUnitPrice = 0
                Else
                    parShipmentSubData(i).sUnitPrice = CLng(pDataReader("出荷商品単価"))
                End If
                '出荷数量
                If IsDBNull(pDataReader("出荷数量")) = True Then
                    parShipmentSubData(i).sCount = 0
                Else
                    parShipmentSubData(i).sCount = CInt(pDataReader("出荷数量"))
                End If
                '出荷税抜金額
                If IsDBNull(pDataReader("出荷税抜金額")) = True Then
                    parShipmentSubData(i).sNoTaxPrice = 0
                Else
                    parShipmentSubData(i).sNoTaxPrice = CLng(pDataReader("出荷税抜金額"))
                End If

                '2019/10/09 shimizu add start
                '軽減税率
                If IsDBNull(pDataReader("軽減税率")) = True Then
                    parShipmentSubData(i).sReducedTaxRate = String.Empty
                Else
                    parShipmentSubData(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                End If
                '2019/10/09 shimizu add end


                '出荷消費税額
                If IsDBNull(pDataReader("出荷消費税額")) = True Then
                    parShipmentSubData(i).sTaxPrice = 0
                Else
                    parShipmentSubData(i).sTaxPrice = CLng(pDataReader("出荷消費税額"))
                End If

                '2019/10/25 shimizu add start
                '出荷軽減消費税額
                If IsDBNull(pDataReader("出荷軽減消費税額")) = True Then
                    parShipmentSubData(i).sReducedTaxRatePrice = 0
                Else
                    parShipmentSubData(i).sReducedTaxRatePrice = CLng(pDataReader("出荷軽減消費税額"))
                End If
                '2019/10/25 shimizu add end

                '出荷税込金額
                If IsDBNull(pDataReader("出荷税込金額")) = True Then
                    parShipmentSubData(i).sPrice = 0
                Else
                    parShipmentSubData(i).sPrice = CLng(pDataReader("出荷税込金額"))
                End If
                '登録日
                parShipmentSubData(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parShipmentSubData(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parShipmentSubData(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parShipmentSubData(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getSubShipment = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.getSubShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function

    '-------------------------------------------------------------------------------
    '　機能：出荷情報明細データから該当レコードを取得する関数
    '　引数：Byref parSubShipment()　：データセットバッファ（sShipment Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Shipment_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    'Public Function getSubShipmentQuery(ByRef parSubShipmentQuery() As sShipmentSubQuery, _
    '                                ByVal KeyRequestCode As String, _
    '                                ByVal KeyShipmentCode As String, _
    '                                ByRef Tran As System.Data.OleDb.OleDbTransaction _
    '                           ) As Long

    '    Dim strSelect As String
    '    Dim i As Long
    '    Dim pc As Integer
    '    Dim scnt As Integer

    '    'コマンドオブジェクトの生成
    '    pCommand = pConn.CreateCommand()
    '    pCommand.Transaction = Tran

    '    strSelect = ""

    '    strSelect = "SELECT * FROM Q_出荷明細クエリー "

    '    'パラメータ数のカウント
    '    pc = 0
    '    If KeyRequestCode <> "" Then
    '        pc = pc Or 1
    '    End If
    '    If KeyShipmentCode <> "" Then
    '        pc = pc Or 2
    '    End If

    '    'パラメータ指定がある場合
    '    If 2 And pc > 0 Then
    '        i = 1
    '        scnt = 0
    '        While i <= 2
    '            Select Case i And pc
    '                Case 1
    '                    If scnt > 0 Then
    '                        strSelect = strSelect & "AND "
    '                    Else
    '                        strSelect = strSelect & "WHERE "
    '                    End If
    '                    strSelect = strSelect & "受注コード =@RequestCode "
    '                    scnt = scnt + 1
    '                Case 1
    '                    If scnt > 0 Then
    '                        strSelect = strSelect & "AND "
    '                    Else
    '                        strSelect = strSelect & "WHERE "
    '                    End If
    '                    strSelect = strSelect & "出荷コード =@ShipmentCode "
    '                    scnt = scnt + 1
    '            End Select
    '            i = i * 2
    '        End While
    '    End If

    '    Try
    '        i = 0

    '        'SQL文の設定
    '        pCommand.CommandText = strSelect

    '        '***********************
    '        '   パラメータの設定
    '        '***********************
    '        If 2 And pc > 0 Then
    '            i = 1
    '            scnt = 0
    '            While i <= 2
    '                Select Case i And pc
    '                    Case 1
    '                        '受注コード
    '                        pCommand.Parameters.Add _
    '                        (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
    '                        pCommand.Parameters("@RequestCode").Value = KeyRequestCode
    '                        scnt = scnt + 1
    '                    Case 1
    '                        '出荷コード
    '                        pCommand.Parameters.Add _
    '                        (New OleDb.OleDbParameter("@ShipmentCode", OleDb.OleDbType.Char, 13))
    '                        pCommand.Parameters("@ShipmentCode").Value = KeyShipmentCode
    '                        scnt = scnt + 1
    '                End Select
    '                i = i * 2
    '            End While
    '        End If

    '        pDataReader = pCommand.ExecuteReader()

    '        i = 0

    '        While pDataReader.Read()

    '            ReDim Preserve parSubShipmentQuery(i)

    '            '受注コード
    '            parSubShipmentQuery(i).sRequestCode = pDataReader("受注コード").ToString

    '            '出荷コード
    '            parSubShipmentQuery(i).sShipCode = pDataReader("出荷コード").ToString

    '            '受注明細コード
    '            parSubShipmentQuery(i).sRequestSubCode = CInt(pDataReader("受注明細コード"))

    '            '商品コード
    '            parSubShipmentQuery(i).sProductCode = pDataReader("商品コード").ToString

    '            'JANコード
    '            parSubShipmentQuery(i).sJANCode = pDataReader("JANコード").ToString

    '            '商品名称
    '            parSubShipmentQuery(i).sProductName = pDataReader("商品名称").ToString

    '            'オプション名称
    '            parSubShipmentQuery(i).sOptionName = pDataReader("オプション名称").ToString

    '            'オプション値
    '            parSubShipmentQuery(i).sOptionValue = pDataReader("オプション値").ToString

    '            '出荷数量
    '            parSubShipmentQuery(i).sShipmentCount = CInt(pDataReader("出荷数量"))

    '            '定価
    '            parSubShipmentQuery(i).sUnitPrice = CLng(pDataReader("定価"))

    '            '販売価格
    '            parSubShipmentQuery(i).sSalePrice = CLng(pDataReader("販売価格"))

    '            '数量
    '            parSubShipmentQuery(i).sCount = CInt(pDataReader("数量"))

    '            '金額
    '            parSubShipmentQuery(i).sPrice = CLng(pDataReader("金額"))

    '            'レコードが取得できた時の処理
    '            i = i + 1
    '        End While

    '        getSubShipmentQuery = i

    '    Catch oExcept As Exception
    '        '例外が発生した時の処理
    '        MessageBox.Show(oExcept.ToString, "例外発生")

    '    Finally
    '        pCommand = Nothing

    '    End Try

    'End Function

    '----------------------------------------------------------------------
    '　機能：出荷明細情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSubShipmentMst(ByRef parShipmentSubData As cStructureLib.sShipmentSubData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim i As Integer
        Dim strInsert As String

        'SQL文の設定

        strInsert = "INSERT INTO 出荷情報明細データ (" &
                        "受注コード, " &
                        "出荷コード, " &
                        "受注明細コード, " &
                        "商品コード, " &
                        "JANコード, " &
                        "商品名称, " &
                        "オプション名称, " &
                        "オプション値, " &
                        "定価, " &
                        "仕入単価, " &
                        "出荷商品単価, " &
                        "出荷数量, " &
                        "出荷税抜金額, " &
                        "軽減税率, " &
                        "出荷消費税額, " &
                        "出荷軽減消費税額, " &
                        "出荷税込金額, " &
                        "登録日, " &
                        "登録時間, " &
                        "最終更新日, " &
                        "最終更新時間 " &
                    ") VALUES (" &
                        "@RequestCode, " &
                        "@ShipNumber, " &
                        "@RequestSubCode, " &
                        "@ProductCode, " &
                        "@JANCode, " &
                        "@ProductName, " &
                        "@OptionName, " &
                        "@OptionValue, " &
                        "@ListPrice, " &
                        "@CostPrice, " &
                        "@UnitPrice, " &
                        "@Count, " &
                        "@NoTaxPrice, " &
                        "@ReducedTaxRate, " &
                        "@TaxPrice, " &
                        "@ReducedTaxRatePrice, " &
                        "@Price, " &
                        "@CreateDate, " &
                        "@CreateTime, " &
                        "@UpdateDate, " &
                        "@UpdateTime " &
                    ")"

        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            i = 0
            '***********************
            '   パラメータの設定
            '***********************
            '受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@RequestCode").Value = parShipmentSubData.sRequestCode
            '出荷コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipNumber", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipNumber").Value = parShipmentSubData.sShipNumber
            '受注明細コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestSubCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@RequestSubCode").Value = parShipmentSubData.sRequestSubCode
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parShipmentSubData.sProductCode
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parShipmentSubData.sJANCode
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ProductName").Value = parShipmentSubData.sProductName
            'オプション名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OptionName", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@OptionName").Value = parShipmentSubData.sOptionName
            'オプション値
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OptionValue", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@OptionValue").Value = parShipmentSubData.sOptionValue
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@ListPrice").Value = parShipmentSubData.sListPrice
            '仕入単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CostPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@CostPrice").Value = parShipmentSubData.sCostPrice
            '出荷商品単価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UnitPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@UnitPrice").Value = parShipmentSubData.sUnitPrice
            '出荷数量
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Count", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@Count").Value = parShipmentSubData.sCount
            '出荷税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@NoTaxPrice").Value = parShipmentSubData.sNoTaxPrice

            '2019/10/09 shimizu add start
            '軽減税率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRate", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@ReducedTaxRate").Value = parShipmentSubData.sReducedTaxRate
            '2019/10/09 shimizu add end

            '出荷消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxPrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@TaxPrice").Value = parShipmentSubData.sTaxPrice

            '2019/10/25 shimizu add start
            '出荷軽減消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRatePrice", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@ReducedTaxRatePrice").Value = parShipmentSubData.sReducedTaxRatePrice
            '2019/10/25 shimizu add end


            '出荷税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Price", OleDb.OleDbType.Numeric, 6))
            pCommand.Parameters("@Price").Value = parShipmentSubData.sPrice
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

            '出荷情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertSubShipmentMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.insertSubShipmentMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：出荷明細情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateSubShipmentMst(ByRef parShipmentSubData() As cStructureLib.sShipmentSubData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定

        'SQL文の設定
        strUpdate = "UPDATE 出荷情報明細データ SET " &
                        "受注コード = """ & parShipmentSubData(0).sRequestCode & """, " &
                        "出荷コード = """ & parShipmentSubData(0).sShipNumber & """, " &
                        "受注明細コード = " & parShipmentSubData(0).sRequestSubCode & ", " &
                        "商品コード = """ & parShipmentSubData(0).sProductCode & """, " &
                        "JANコード = """ & parShipmentSubData(0).sJANCode & """, " &
                        "商品名称 = """ & parShipmentSubData(0).sProductName & """, " &
                        "オプション名称 = """ & parShipmentSubData(0).sOptionName & """, " &
                        "オプション値 = """ & parShipmentSubData(0).sOptionValue & """, " &
                        "定価 = " & parShipmentSubData(0).sListPrice & ", " &
                        "仕入単価 = " & parShipmentSubData(0).sCostPrice & ", " &
                        "出荷商品単価 = " & parShipmentSubData(0).sUnitPrice & ", " &
                        "出荷数量 = " & parShipmentSubData(0).sCount & ", " &
                        "出荷税抜金額 = " & parShipmentSubData(0).sNoTaxPrice & ", " &
                        "軽減税率 = " & parShipmentSubData(0).sReducedTaxRate & ", " &
                        "出荷消費税額 = " & parShipmentSubData(0).sTaxPrice & ", " &
                        "出荷軽減消費税額 = " & parShipmentSubData(0).sReducedTaxRatePrice & ", " &
                        "出荷税込金額 = " & parShipmentSubData(0).sPrice & ", " &
                        "登録日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                        "登録時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """, " &
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " &
                    "WHERE " &
                            "受注コード = """ & parShipmentSubData(0).sRequestCode & """ " &
                            "AND 出荷コード = """ & parShipmentSubData(0).sShipNumber & """ " &
                            "AND 受注明細コード = " & parShipmentSubData(0).sRequestSubCode & " "

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strUpdate

            '出荷情報データ挿入処理実行
            pCommand.ExecuteNonQuery()

            updateSubShipmentMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.updateSubShipmentMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    Public Function getShipmentCount(ByVal KeyRequestCode As String,
                                      ByVal KeyRequestSubCode As Integer,
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxShipmentNo As Long

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT 受注コード, 受注明細コード, Sum(出荷数量) AS 出荷数 " &
                        "FROM 出荷情報明細データ " &
                        "WHERE 受注コード = """ & KeyRequestCode & """ AND 受注明細コード = " & KeyRequestSubCode & " " &
                        "GROUP BY 受注コード, 受注明細コード"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxShipmentNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("出荷数")) = True Then
                    getShipmentCount = 0
                Else
                    getShipmentCount = CLng(pDataReader("出荷数"))
                End If

            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.getShipmentCount)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：出荷情報データから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getMaxShipmentCode(ByVal KeyChannelCode As Integer, ByVal KeyDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxShipmentNo As Long

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT 受注コード FROM 出荷情報データ " &
                        "WHERE 受注コード Like ""991" & String.Format("{0:00}", KeyChannelCode) & KeyDate & "%"" " &
                        "ORDER BY 受注コード DESC"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxShipmentNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("受注コード")) = True Then
                    MaxShipmentNo = 0
                Else
                    MaxShipmentNo = CLng(Mid(pDataReader("受注コード").ToString, 12, 1)) + 1
                End If

            End If
            getMaxShipmentCode = MaxShipmentNo

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.getMaxShipmentCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function

    '----------------------------------------------------
    '2015/07/07
    '及川和彦
    '商品コードで絞込
    'FROM
    '----------------------------------------------------
    Public Function getShipmentSubProduct(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""
            strSelect = "SELECT COUNT(*) as CNT FROM 出荷情報明細データ WHERE 商品コード = """ & KeyProductCode & """"

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()
            getShipmentSubProduct = CLng(pDataReader("CNT"))

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipmentSubDBIO.getSubShipment)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
        End Try

    End Function
    '----------------------------------------------------
    'HERE
    '----------------------------------------------------

End Class
