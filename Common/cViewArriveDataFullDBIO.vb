
Public Class cViewArriveDataFullDBIO
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
    '　機能：入庫情報データから該当入庫番号のデータを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getArriveSearch(ByRef parArriveDataFull() As cStructureLib.sViewArriveDataFull, _
                                 ByVal KeyOrderCode As String, _
                                 ByVal KeyArriveNo As Integer, _
                                 ByVal KeySupplierCode As String, _
                                 ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim Maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '2020,4,7 A.Komita SQLに入庫軽減税額を追加 From
        strSelect = ""
        strSelect = "SELECT " &
                        "入庫情報データ.発注コード, " &
                        "Count(入庫情報データ.入庫番号) AS 入庫番号, " &
                        "入庫情報データ.仕入先コード, " &
                        "仕入先マスタ.仕入先名称, " &
                        "入庫情報データ.支払方法コード, " &
                        "支払方法マスタ.支払方法名称, " &
                        "Sum(入庫情報データ.入庫税抜商品金額) AS 入庫税抜商品金額, " &
                        "Sum(入庫情報データ.送料) AS 送料, " &
                        "Sum(入庫情報データ.手数料) AS 手数料, " &
                        "Sum(入庫情報データ.値引き) AS 値引き, " &
                        "Sum(入庫情報データ.ポイント値引き) AS ポイント値引き, " &
                        "Sum(入庫情報データ.入庫税抜金額) AS 入庫税抜金額, " &
                        "Sum(入庫情報データ.入庫消費税額) AS 入庫消費税額, " &
                        "Sum(入庫情報データ.入庫軽減税額) AS 入庫軽減税額, " &
                        "Sum(入庫情報データ.入庫税込金額) AS 入庫税込金額, " &
                        "Sum(入庫情報データ.完納フラグ) AS 完納フラグ, " &
                        "入庫情報データ.入庫担当者コード AS 入庫担当者コード, " &
                        "スタッフマスタ.スタッフ名称 AS 入庫担当者名称 " &
                    "FROM スタッフマスタ RIGHT JOIN (仕入先マスタ RIGHT JOIN (支払方法マスタ RIGHT JOIN " &
                        "入庫情報データ ON 支払方法マスタ.支払方法コード = 入庫情報データ.支払方法コード) " &
                        "ON 仕入先マスタ.仕入先コード = 入庫情報データ.仕入先コード) " &
                        "ON スタッフマスタ.スタッフコード = 入庫情報データ.入庫担当者コード "
        '2020,4,7 A.Komita 追加 To


        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If KeyOrderCode <> Nothing Then
            Maxpc = 1
            pc = pc Or Maxpc
        End If
        If KeyArriveNo <> Nothing Then
            Maxpc = 2
            pc = pc Or Maxpc
        End If
        If KeySupplierCode <> Nothing Then
            Maxpc = 4
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
                        strSelect = strSelect & "入庫情報データ.発注コード Like ""%" & KeyOrderCode & "%"" "
                        scnt = scnt + 1

                    Case 2  '入庫番号
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "入庫情報データ.入庫番号 = " & KeyArriveNo & " "
                        scnt = scnt + 1
                    Case 4  '仕入先コード
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "入庫情報データ.仕入先コード = " & KeySupplierCode & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "GROUP BY " & _
                                    "入庫情報データ.発注コード, " & _
                                    "入庫情報データ.仕入先コード, " & _
                                    "仕入先マスタ.仕入先名称, " & _
                                    "入庫情報データ.支払方法コード, " & _
                                    "支払方法マスタ.支払方法名称, " & _
                                    "入庫情報データ.入庫担当者コード, " & _
                                    "スタッフマスタ.スタッフ名称 "


        i = 0

        'SQL文の設定
        pCommand.CommandText = strSelect

        Try
            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parArriveDataFull(i)

                '発注コード
                parArriveDataFull(i).sOrderCode = pDataReader("発注コード").ToString
                '入庫番号
                If IsDBNull(pDataReader("入庫番号")) = True Then
                    parArriveDataFull(i).sArrivalNo = 0
                Else
                    parArriveDataFull(i).sArrivalNo = CLng(pDataReader("入庫番号"))
                End If
                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parArriveDataFull(i).sSupplierCode = 0
                Else
                    parArriveDataFull(i).sSupplierCode = CLng(pDataReader("仕入先コード"))
                End If
                '仕入先名称
                parArriveDataFull(i).sSupplierName = pDataReader("仕入先名称").ToString
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parArriveDataFull(i).sPaymentCode = 0
                Else
                    parArriveDataFull(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '支払方法名称
                parArriveDataFull(i).sPaymentName = pDataReader("支払方法名称").ToString
                '入庫税抜商品金額
                If IsDBNull(pDataReader("入庫税抜商品金額")) = True Then
                    parArriveDataFull(i).sNoTaxTotalProductPrice = 0
                Else
                    parArriveDataFull(i).sNoTaxTotalProductPrice = CLng(pDataReader("入庫税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parArriveDataFull(i).sShippingCharge = 0
                Else
                    parArriveDataFull(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parArriveDataFull(i).sPaymentCharge = 0
                Else
                    parArriveDataFull(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                ''値引き
                'If IsDBNull(pDataReader("値引き")) = True Then
                '    parArriveDataFull(i).sPointDisCount = 0
                'Else
                '    parArriveDataFull(i).sPointDisCount = CLng(pDataReader("値引き"))
                'End If
                ''ポイント値引き
                'If IsDBNull(pDataReader("ポイント値引き")) = True Then
                '    parArriveDataFull(i).sDiscount = 0
                'Else
                '    parArriveDataFull(i).sDiscount = CLng(pDataReader("ポイント値引き"))
                'End If



                '---------------------------------------------------------------------------------
                '2015/06/19
                '及川和彦
                '分納を行った入庫データを再度読み込んだ際に、
                '既納入の値引きとポイント値引きが逆になっていたため、修正
                'FROM
                '---------------------------------------------------------------------------------

                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parArriveDataFull(i).sDiscount = 0
                Else
                    parArriveDataFull(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parArriveDataFull(i).sPointDisCount = 0
                Else
                    parArriveDataFull(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If

                '---------------------------------------------------------------------------------
                'HERE
                '---------------------------------------------------------------------------------


                '入庫税抜金額
                If IsDBNull(pDataReader("入庫税抜金額")) = True Then
                    parArriveDataFull(i).sNoTaxTotalPrice = 0
                Else
                    parArriveDataFull(i).sNoTaxTotalPrice = CLng(pDataReader("入庫税抜金額"))
                End If
                '入庫消費税額
                If IsDBNull(pDataReader("入庫消費税額")) = True Then
                    parArriveDataFull(i).sTaxTotal = 0
                Else
                    parArriveDataFull(i).sTaxTotal = CLng(pDataReader("入庫消費税額"))
                End If

                '2020,4,7 A.Komita 追加 From
                '入庫軽減税額
                If IsDBNull(pDataReader("入庫軽減税額")) = True Then
                    parArriveDataFull(i).sReducedTaxRate = 0
                Else
                    parArriveDataFull(i).sReducedTaxRate = CLng(pDataReader("入庫軽減税額"))
                End If
                '2020,4,7 A.Komita 追加 To

                '入庫税込金額
                If IsDBNull(pDataReader("入庫税込金額")) = True Then
                    parArriveDataFull(i).sTotalPrice = 0
                Else
                    parArriveDataFull(i).sTotalPrice = CLng(pDataReader("入庫税込金額"))
                End If
                '入庫担当者コード
                parArriveDataFull(i).sStaffCode = pDataReader("入庫担当者コード").ToString
                '完納フラグ
                parArriveDataFull(i).sFinishFlg = CBool(pDataReader("完納フラグ"))
                '入庫担当者名称
                parArriveDataFull(i).sStaffName = pDataReader("入庫担当者名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getArriveSearch = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataArriveDBIO.getArriveSearch)", Nothing, Nothing, oExcept.ToString)
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
