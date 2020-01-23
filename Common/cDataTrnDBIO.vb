
'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cDataTrnDBIO
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
    '　機能：プロパティの取引コードのレコードが取引テーブルに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function TrnExist(ByVal KeyString As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 日次取引データ WHERE 取引コード = @TrnCode"

        Try

            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@TrnCode").Value = KeyString

            '取引テーブルから該当取引コードのレコード数読込 
            Dim recCount As Integer
            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                Return True
            Else
                'レコードが存在しない時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.TrnExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getTrn(ByRef parTrn() As cStructureLib.sTrn, _
                           ByVal KeyTrnCode As Long, _
                           ByVal KeyChannelCode As Integer, _
                           ByVal KeyTrnDate As String, _
                           ByVal KeyFromDate As String, _
                           ByVal KeyToDate As String, _
                           ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim strSelectTrn As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelectTrn = "SELECT * FROM 日次取引データ "


        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyChannelCode <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyTrnDate <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyFromDate <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyToDate <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If (maxpc And pc) > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelectTrn = strSelectTrn & "AND "
                        Else
                            strSelectTrn = strSelectTrn & "WHERE "
                        End If
                        strSelectTrn = strSelectTrn & "取引コード = " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelectTrn = strSelectTrn & "AND "
                        Else
                            strSelectTrn = strSelectTrn & "WHERE "
                        End If
                        strSelectTrn = strSelectTrn & "チャネルコード = " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelectTrn = strSelectTrn & "AND "
                        Else
                            strSelectTrn = strSelectTrn & "WHERE "
                        End If
                        strSelectTrn = strSelectTrn & "登録日 Like ""%" & KeyTrnDate & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelectTrn = strSelectTrn & "AND "
                        Else
                            strSelectTrn = strSelectTrn & "WHERE "
                        End If
                        strSelectTrn = strSelectTrn & "日次締め日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelectTrn = strSelectTrn & "AND "
                        Else
                            strSelectTrn = strSelectTrn & "WHERE "
                        End If
                        strSelectTrn = strSelectTrn & "日次締め日 <= """ & KeyToDate & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            pDataReader = pCommand.ExecuteReader()

            i = 0
            ReDim parTrn(0)
            While pDataReader.Read()

                ReDim Preserve parTrn(i)
                'レコードが取得できた時の処理
                '取引コード
                If IsDBNull(pDataReader("取引コード")) = True Then
                    parTrn(i).sTrnCode = 0
                Else
                    parTrn(i).sTrnCode = CLng(pDataReader("取引コード"))
                End If
                '取引区分
                parTrn(i).sTrnClass = pDataReader("取引区分").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parTrn(i).sChannel = 0
                Else
                    parTrn(i).sChannel = CInt(pDataReader("チャネルコード"))
                End If
                '受注日
                parTrn(i).sRequestDate = pDataReader("受注日").ToString
                '受注時間
                parTrn(i).sRequestTime = pDataReader("受注時間").ToString
                '支払方法コード
                If IsDBNull(pDataReader("支払方法コード")) = True Then
                    parTrn(i).sPaymentCode = 0
                Else
                    parTrn(i).sPaymentCode = CInt(pDataReader("支払方法コード"))
                End If
                '取引税抜商品金額
                If IsDBNull(pDataReader("取引税抜商品金額")) = True Then
                    parTrn(i).sNoTaxTotalProductPrice = 0
                Else
                    parTrn(i).sNoTaxTotalProductPrice = CLng(pDataReader("取引税抜商品金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parTrn(i).sShippingCharge = 0
                Else
                    parTrn(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parTrn(i).sPaymentCharge = 0
                Else
                    parTrn(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parTrn(i).sDiscount = 0
                Else
                    parTrn(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parTrn(i).sPointDiscount = 0
                Else
                    parTrn(i).sPointDiscount = CLng(pDataReader("ポイント値引き"))
                End If
                'チケット値引き
                If IsDBNull(pDataReader("チケット値引き")) = True Then
                    parTrn(i).sTicketDiscount = 0
                Else
                    parTrn(i).sTicketDiscount = CLng(pDataReader("チケット値引き"))
                End If
                '差額
                If IsDBNull(pDataReader("差額")) = True Then
                    parTrn(i).sDifference = 0
                Else
                    parTrn(i).sDifference = CLng(pDataReader("差額"))
                End If
                '取引税抜金額
                If IsDBNull(pDataReader("取引税抜金額")) = True Then
                    parTrn(i).sNoTaxTotalPrice = 0
                Else
                    parTrn(i).sNoTaxTotalPrice = CLng(pDataReader("取引税抜金額"))
                End If
                '取引消費税額
                If IsDBNull(pDataReader("取引消費税額")) = True Then
                    parTrn(i).sTaxTotal = 0
                Else
                    parTrn(i).sTaxTotal = CLng(pDataReader("取引消費税額"))
                End If
                '取引税込金額
                If IsDBNull(pDataReader("取引税込金額")) = True Then
                    parTrn(i).sTotalPrice = 0
                Else
                    parTrn(i).sTotalPrice = CLng(pDataReader("取引税込金額"))
                End If
                '出荷コード
                parTrn(i).sShipCode = pDataReader("出荷コード").ToString
                '会員コード
                parTrn(i).sMemberCode = pDataReader("会員コード").ToString
                'ポイント会員コード
                parTrn(i).sPointMemberCode = pDataReader("ポイント会員コード").ToString
                '性別
                parTrn(i).sSex = pDataReader("性別").ToString
                '年代
                If IsDBNull(pDataReader("年代")) = True Then
                    parTrn(i).sGeneration = 0
                Else
                    parTrn(i).sGeneration = CInt(pDataReader("年代"))
                End If
                '天気
                parTrn(i).sWeather = pDataReader("天気").ToString
                '日次締め日
                parTrn(i).sDayCloseDate = pDataReader("日次締め日").ToString
                '月次締め日
                parTrn(i).sMonthCloseDate = pDataReader("月次締め日").ToString
                '備考
                parTrn(i).sMemo = pDataReader("備考").ToString
                '取引担当者コード
                parTrn(i).sStaffCode = pDataReader("取引担当者コード").ToString
                '登録日
                parTrn(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parTrn(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parTrn(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parTrn(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getTrn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.getTrn)", Nothing, Nothing, oExcept.ToString)
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
    Public Function readMaxTrnCode(ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim strSelectTrn As String

        'strSelectTrn = "SELECT 取引コード FROM 日次取引データ WHERE チャネルコード= " & ChannelCode & " ORDER BY 取引コード DESC"
        strSelectTrn = "SELECT MAX(取引コード) AS 最大取引コード FROM 日次取引データ"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            '日次取引データから該当MAX取引IDのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("最大取引コード")) Then
                    readMaxTrnCode = 0
                Else
                    '取引コードインクリメント
                    If CLng(pDataReader("最大取引コード")) < 999999999 Then
                        readMaxTrnCode = CLng(pDataReader("最大取引コード")) + 1
                    Else
                        readMaxTrnCode = 1
                    End If
                End If
            Else
                readMaxTrnCode = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.readMaxTrnCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertTrn(ByRef parTrn As cStructureLib.sTrn, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strInsertTrn As String


        Try

            'SQL文の設定
            strInsertTrn = "INSERT INTO 日次取引データ (" &
                                "取引コード, " &
                                "取引区分, " &
                                "チャネルコード, " &
                                "受注日, " &
                                "受注時間, " &
                                "支払方法コード, " &
                                "取引税抜商品金額, " &
                                "送料, " &
                                "手数料, " &
                                "値引き, " &
                                "ポイント値引き, " &
                                "チケット値引き, " &
                                "差額, " &
                                "取引税抜金額, " &
                                "取引消費税額, " &
                                "取引税込金額, " &
                                "出荷コード, " &
                                "会員コード, " &
                                "ポイント会員コード, " &
                                "性別, " &
                                "年代, " &
                                "天気, " &
                                "日次締め日, " &
                                "月次締め日, " &
                                "備考, " &
                                "取引担当者コード, " &
                                "登録日, " &
                                "登録時間, " &
                                "最終更新日, " &
                                "最終更新時間 " &
                        ") VALUES (" &
                                "@TrnCode, " &
                                "@TrnClass, " &
                                "@Channel, " &
                                "@RequestDate, " &
                                "@RequestTime, " &
                                "@PaymentCode, " &
                                "@NoTaxProductPrice, " &
                                "@ShippingCharge, " &
                                "@PaymentCharge, " &
                                "@Discount, " &
                                "@PointDisCount, " &
                                "@TicketDisCount, " &
                                "@Difference, " &
                                "@NoTaxTotalPrice, " &
                                "@TaxTotal, " &
                                "@TotalPrice, " &
                                "@ShipCode, " &
                                "@MemberCode, " &
                                "@PointMemberCode, " &
                                "@Sex, " &
                                "@Generation, " &
                                "@Weather, " &
                                "@DayCloseDate, " &
                                "@MonthCloseDate, " &
                                "@Memo, " &
                                "@StaffCode, " &
                                "@CreateDate, " &
                                "@CreateTime, " &
                                "@UpdateDate, " &
                                "@UpdateTime " &
                        ")"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertTrn

            '***********************
            '   パラメータの設定
            '***********************

            '取引コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TrnCode").Value = parTrn.sTrnCode
            '取引区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnClass", OleDb.OleDbType.Char, 4))
            pCommand.Parameters("@TrnClass").Value = parTrn.sTrnClass
            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Channel", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@Channel").Value = parTrn.sChannel
            '受注日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@RequestDate").Value = parTrn.sRequestDate
            '受注時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@RequestTime").Value = parTrn.sRequestTime
            '支払方法コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@PaymentCode").Value = parTrn.sPaymentCode
            '取引税抜商品金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxProductPrice", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@NoTaxProductPrice").Value = parTrn.sNoTaxTotalProductPrice
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ShippingCharge").Value = parTrn.sShippingCharge
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PaymentCharge").Value = parTrn.sPaymentCharge
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Discount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Discount").Value = parTrn.sDiscount
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PointDisCount").Value = parTrn.sPointDiscount
            'チケット値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TicketDisCount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TicketDisCount").Value = parTrn.sTicketDiscount
            '差額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Difference", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Difference").Value = parTrn.sDifference
            '取引税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 0))
            pCommand.Parameters("@NoTaxTotalPrice").Value = parTrn.sNoTaxTotalPrice
            '取引消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TaxTotal").Value = parTrn.sTaxTotal
            '取引税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@TotalPrice").Value = parTrn.sTotalPrice
            '出荷コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipCode").Value = parTrn.sShipCode
            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@MemberCode").Value = parTrn.sMemberCode
            'ポイント会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointMemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@PointMemberCode").Value = parTrn.sPointMemberCode
            '性別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Sex", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Sex").Value = parTrn.sSex
            '年代
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Generation", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@Generation").Value = parTrn.sGeneration
            '天気
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Weather", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Weather").Value = parTrn.sWeather
            '日次締め日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DayCloseDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@DayCloseDate").Value = parTrn.sDayCloseDate
            '月次締め日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MonthCloseDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@MonthCloseDate").Value = parTrn.sMonthCloseDate

            '備考
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Memo").Value = parTrn.sMemo

            '取引担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@StaffCode").Value = parTrn.sStaffCode
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

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()


            insertTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.insertTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに日次締め日を登録するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateTrn(ByVal parTrn() As cStructureLib.sTrn, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        Try

            'SQL文の設定
            strUpdate = "UPDATE 日次取引データ " & _
                                    "SET " & _
                                        "取引コード = " & parTrn(0).sTrnCode & ", " & _
                                        "取引区分 = """ & parTrn(0).sTrnClass & """, " & _
                                        "チャネルコード = " & parTrn(0).sChannel & ", " & _
                                        "受注日 = """ & parTrn(0).sRequestDate & """, " & _
                                        "受注時間 = """ & parTrn(0).sRequestTime & """, " & _
                                        "支払方法コード = " & parTrn(0).sPaymentCode & ", " & _
                                        "取引税抜商品金額 = " & parTrn(0).sNoTaxTotalProductPrice & ", " & _
                                        "送料 = " & parTrn(0).sShippingCharge & ", " & _
                                        "手数料 = " & parTrn(0).sPaymentCharge & ", " & _
                                        "値引き = " & parTrn(0).sDiscount & ", " & _
                                        "ポイント値引き = " & parTrn(0).sPointDiscount & ", " & _
                                        "チケット値引き = " & parTrn(0).sTicketDiscount & ", " & _
                                        "差額 = " & parTrn(0).sDifference & ", " & _
                                        "取引税抜金額 = " & parTrn(0).sNoTaxTotalPrice & ", " & _
                                        "取引消費税額 = " & parTrn(0).sTaxTotal & ", " & _
                                        "取引税込金額 = " & parTrn(0).sTotalPrice & ", " & _
                                        "出荷コード = """ & parTrn(0).sShipCode & """, " & _
                                        "会員コード = """ & parTrn(0).sMemberCode & """, " & _
                                        "ポイント会員コード = """ & parTrn(0).sPointMemberCode & """, " & _
                                        "性別 = """ & parTrn(0).sSex & """, " & _
                                        "年代 = " & parTrn(0).sGeneration & ", " & _
                                        "天気 = """ & parTrn(0).sWeather & """, " & _
                                        "日次締め日 = """ & parTrn(0).sDayCloseDate & """, " & _
                                        "月次締め日 = """ & parTrn(0).sMonthCloseDate & """, " & _
                                        "備考 = """ & parTrn(0).sMemo & """, " & _
                                        "取引担当者コード = """ & parTrn(0).sStaffCode & """, " & _
                                        "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                        "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                                    "WHERE 日次取引データ.取引コード=" & parTrn(0).sTrnCode

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '取引テーブル更新処理実行
            pCommand.ExecuteNonQuery()

            updateTrn = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.updateTrn)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルに日次締め日を登録するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateTrnCloseDay(ByVal KeyCloseDay As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdateTrn As String

        Try

            'SQL文の設定
            strUpdateTrn = "UPDATE 日次取引データ " & _
                                            "SET 日次取引データ.日次締め日=@CloseDay, " & _
                                                "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                                "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                                            "WHERE 日次取引データ.日次締め日="""" " & _
                                            "OR 日次取引データ.日次締め日 Is Null"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdateTrn

            '***********************
            '   パラメータの設定
            '***********************

            '日次締め日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CloseDay", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CloseDay").Value = KeyCloseDay

            '取引テーブル更新処理実行
            pCommand.ExecuteNonQuery()

            updateTrnCloseDay = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnDBIO.updateTrnCloseDay)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引テーブルから該当レコードを削除するメソッド
    '　引数：in cTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteTrn(ByVal KeyTrnCode As Long, ByVal KeyShipmentCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDeleteTrn As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim cnt As Long

        cnt = 0
        strDeleteTrn = ""

        'SQL文の設定
        strDeleteTrn = "DELETE * FROM 日次取引データ "

        'パラメータ数のカウント
        pc = 0
        If KeyTrnCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyShipmentCode <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        'パラメータ指定がある場合
        If maxpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= maxpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strDeleteTrn = strDeleteTrn & "AND "
                        Else
                            strDeleteTrn = strDeleteTrn & "WHERE "
                        End If
                        strDeleteTrn = strDeleteTrn & "取引コード= " & KeyTrnCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strDeleteTrn = strDeleteTrn & "AND "
                        Else
                            strDeleteTrn = strDeleteTrn & "WHERE "
                        End If
                        strDeleteTrn = strDeleteTrn & "出荷コード= """ & KeyShipmentCode & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteTrn

            '取引テーブル挿入処理実行
            cnt = pCommand.ExecuteNonQuery()

            If cnt <= 0 Then
                deleteTrn = False
            Else
                deleteTrn = True
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataTrnSubDBIO.deleteTrn)", Nothing, Nothing, oExcept.ToString)
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
