Public Class cViewOrderReportDBIO
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
    Public Function getOrderReport(ByRef parOrderReport() As cStructureLib.sViewOrderReport,
                                   ByVal KeySupplierCode As Integer,
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            '---------------------------------------------
            '2019/9/5 鈴木
            '---------------------------------------------

            strSelect = "SELECT DISTINCT " &
                            "発注状態データ.商品コード, " &
                            "商品マスタ.JANコード, " &
                            "商品マスタ.商品名称, " &
                            "商品マスタ.商品略称, " &
                            "商品マスタ.オプション1, " &
                            "商品マスタ.オプション2, " &
                            "商品マスタ.オプション3, " &
                            "商品マスタ.オプション4, " &
                            "商品マスタ.オプション5, " &
                            "商品マスタ.定価, " &
                            "仕入価格マスタ.仕入単価, " &
                            "商品マスタ.軽減税率, " &
                            "発注状態データ.数量, " &
                            "在庫マスタ.在庫数 " &
                        "FROM 在庫マスタ " &
                            "RIGHT JOIN (仕入価格マスタ " &
                            "RIGHT JOIN (発注状態データ " &
                            "LEFT JOIN 商品マスタ " &
                            "ON 発注状態データ.商品コード = 商品マスタ.商品コード) " &
                            "ON 仕入価格マスタ.商品コード = 発注状態データ.商品コード) " &
                            "ON 在庫マスタ.商品コード = 発注状態データ.商品コード "
            '---------------------------------------------
            '2019/9/5 鈴木 end
            '---------------------------------------------

            If KeySupplierCode <> Nothing Then
                strSelect = strSelect & "WHERE 仕入価格マスタ.仕入先コード = " & KeySupplierCode & " "
            End If

            strSelect = strSelect & "ORDER BY 商品マスタ.商品名称, " &
                                        "商品マスタ.オプション1, " &
                                        "商品マスタ.オプション2, " &
                                        "商品マスタ.オプション3, " &
                                        "商品マスタ.オプション4, " &
                                        "商品マスタ.オプション5 "


            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parOrderReport(i)

                'JANコード
                parOrderReport(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parOrderReport(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parOrderReport(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parOrderReport(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parOrderReport(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2"
                parOrderReport(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3"
                parOrderReport(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4"
                parOrderReport(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5"
                parOrderReport(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parOrderReport(i).sPrice = CLng(pDataReader("定価"))
                '仕入価格
                parOrderReport(i).sCostPrice = CLng(pDataReader("仕入単価"))
                '---------------------------------------------
                '2019/9/5 鈴木
                '---------------------------------------------
                '軽減税率
                parOrderReport(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '---------------------------------------------
                '2019/9/5 鈴木 end
                '---------------------------------------------
                '数量
                If IsDBNull(pDataReader("数量")) = False Then
                    parOrderReport(i).sCount = CInt(pDataReader("数量"))
                Else
                    parOrderReport(i).sCount = 0
                End If
                ''金額
                'If IsDBNull(pDataReader("金額")) = False Then
                '    parOrderReport(i).sOrderPrice = CLng(pDataReader("金額"))
                'End If
                '在庫数
                parOrderReport(i).sStock = CInt(pDataReader("在庫数"))

                i = i + 1

            End While

            getOrderReport = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewOrderReportDBIO.getOrderReport)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getOrderReReport(ByRef parOrderReport() As cStructureLib.sViewOrderReport,
                                ByVal KeyOrderCode As String,
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT " &
                            "発注情報明細データ.発注コード, " &
                            "発注情報明細データ.商品コード, " &
                            "商品マスタ.JANコード, " &
                            "商品マスタ.商品名称, " &
                            "商品マスタ.商品略称, " &
                            "商品マスタ.オプション1, " &
                            "商品マスタ.オプション2, " &
                            "商品マスタ.オプション3, " &
                            "商品マスタ.オプション4, " &
                            "商品マスタ.オプション5, " &
                            "発注情報明細データ.定価, " &
                            "発注情報明細データ.仕入単価, " &
                            "発注情報明細データ.数量, " &
                            "軽減税率, " &
                            "在庫マスタ.在庫数 " &
                        "FROM 在庫マスタ RIGHT JOIN (発注情報明細データ LEFT JOIN 商品マスタ " &
                            "ON 発注情報明細データ.商品コード = 商品マスタ.商品コード) " &
                            "ON 在庫マスタ.商品コード = 発注情報明細データ.商品コード "

            If KeyOrderCode <> Nothing Then
                strSelect = strSelect & "WHERE 発注情報明細データ.発注コード = """ & KeyOrderCode & """ "
            End If

            strSelect = strSelect & "ORDER BY 商品マスタ.商品名称, " &
                                        "商品マスタ.オプション1, " &
                                        "商品マスタ.オプション2, " &
                                        "商品マスタ.オプション3, " &
                                        "商品マスタ.オプション4, " &
                                        "商品マスタ.オプション5 "


            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parOrderReport(i)

                'JANコード
                parOrderReport(i).sJANCode = pDataReader("JANコード").ToString
                '商品コード
                parOrderReport(i).sProductCode = pDataReader("商品コード").ToString
                '商品名称
                parOrderReport(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parOrderReport(i).sProductShortName = pDataReader("商品略称").ToString
                'オプション1
                parOrderReport(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2"
                parOrderReport(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3"
                parOrderReport(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4"
                parOrderReport(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5"
                parOrderReport(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parOrderReport(i).sPrice = CLng(pDataReader("定価"))
                '仕入価格
                parOrderReport(i).sCostPrice = CLng(pDataReader("仕入単価"))
                '数量
                If IsDBNull(pDataReader("数量")) = False Then
                    parOrderReport(i).sCount = CInt(pDataReader("数量"))
                Else
                    parOrderReport(i).sCount = 0
                End If
                '---------------------------------------------
                '2019/9/5 鈴木
                '---------------------------------------------
                '軽減税率
                parOrderReport(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '---------------------------------------------
                '2019/9/5 鈴木 end
                '---------------------------------------------
                '在庫数
                parOrderReport(i).sStock = CInt(pDataReader("在庫数"))

                i = i + 1

            End While

            getOrderReReport = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewOrderReportDBIO.getOrderReReport)", Nothing, Nothing, oExcept.ToString)
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
