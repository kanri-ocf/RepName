Public Class cMstSupplierDBIO

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
    Public Function SupplierExist(ByVal KeyString As Integer, ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Const strSelectSupplier As String =
        "SELECT COUNT(*) FROM 仕入先マスタ WHERE 取引コード = @SupplierCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectSupplier

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@TrnCode").Value = KeyString

            SupplierExist = CInt(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.SupplierExist)", Nothing, Nothing, oExcept.ToString)
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

    ''----------------------------------------------------------------------
    ''　機能：仕入先マスタから１レコードを取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getSupplier(ByRef parSupplier() As cStructureLib.sSupplier,
                                ByVal KeySupplierCode As String, ByVal KeySupplierName As String,
                                ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim StrSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer

        StrSelect = "SELECT * FROM 仕入先マスタ "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'パラメータ数のカウント
            pc = 0
            If KeySupplierCode <> Nothing Then
                mpc = 1
                pc = pc Or mpc
            End If
            If KeySupplierName <> Nothing Then
                mpc = 2
                pc = pc Or mpc
            End If

            'パラメータ指定がある場合
            If mpc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= mpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "仕入先コード= " & KeySupplierCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "仕入先名称 Like ""%" & KeySupplierName & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            StrSelect = StrSelect & "ORDER BY 仕入先コード "

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSupplier(i)

                'レコードが取得できた時の処理

                '仕入先コード
                If IsDBNull(pDataReader("仕入先コード")) = True Then
                    parSupplier(i).sSupplierCode = 0
                Else
                    parSupplier(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                End If
                '仕入先名称
                parSupplier(i).sSupplierName = pDataReader("仕入先名称").ToString
                '郵便番号
                parSupplier(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                parSupplier(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                parSupplier(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                parSupplier(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                parSupplier(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parSupplier(i).sFAX = pDataReader("FAX").ToString
                'URL
                parSupplier(i).sURL = pDataReader("URL").ToString
                '担当者名称
                parSupplier(i).sPersonName = pDataReader("担当者名称").ToString
                '締め日
                If IsDBNull(pDataReader("締め日")) = True Then
                    parSupplier(i).sCloseDate = 0
                Else
                    parSupplier(i).sCloseDate = CLng(pDataReader("締め日"))
                End If
                '標準仕切率
                If IsDBNull(pDataReader("標準仕切率")) = True Then
                    parSupplier(i).sStanderedRate = 0
                Else
                    parSupplier(i).sStanderedRate = CLng(pDataReader("標準仕切率"))
                End If
                '標準ロット数
                If IsDBNull(pDataReader("標準ロット数")) = True Then
                    parSupplier(i).sStanderedLot = 0
                Else
                    parSupplier(i).sStanderedLot = CLng(pDataReader("標準ロット数"))
                End If
                '支払方法コード1
                If IsDBNull(pDataReader("支払方法コード1")) = True Then
                    parSupplier(i).sPaymentCode1 = 0
                Else
                    parSupplier(i).sPaymentCode1 = CInt(pDataReader("支払方法コード1"))
                End If
                '支払方法コード2
                If IsDBNull(pDataReader("支払方法コード2")) = True Then
                    parSupplier(i).sPaymentCode2 = 0
                Else
                    parSupplier(i).sPaymentCode2 = CInt(pDataReader("支払方法コード2"))
                End If
                '支払方法コード3
                If IsDBNull(pDataReader("支払方法コード3")) = True Then
                    parSupplier(i).sPaymentCode3 = 0
                Else
                    parSupplier(i).sPaymentCode3 = CInt(pDataReader("支払方法コード3"))
                End If
                '取引条件
                parSupplier(i).sTrnRule = pDataReader("取引条件").ToString
                '備考
                parSupplier(i).sMemo = pDataReader("備考").ToString
                '登録日
                parSupplier(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parSupplier(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日付
                parSupplier(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parSupplier(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getSupplier = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.getSupplier)", Nothing, Nothing, oExcept.ToString)
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


    ''----------------------------------------------------------------------
    ''　機能：仕入先名称から取得する関数
    ''　引数：Byref DataTable型オブジェクト(取得された仕入先レコード値を設定)
    ''　戻値：True  --> レコードの取得成功
    ''　　　　False --> 取得するレコードなし
    ''----------------------------------------------------------------------
    Public Function getSupplierCode(ByRef parSupplier() As cStructureLib.sSupplier, ByVal KeySupplierName As String, ByRef Tran As OleDb.OleDbTransaction) As Long
        Dim i As Integer
        Dim StrSelect As String

        If KeySupplierName = "" Then
            StrSelect = "SELECT * FROM 仕入先マスタ"
        Else
            StrSelect = "SELECT * FROM 仕入先マスタ WHERE 仕入先名称 =  @SupplierName"
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            '商品コード
            If KeySupplierName <> "" Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@SupplierName", OleDb.OleDbType.Char, 50))
                pCommand.Parameters("@SupplierName").Value = KeySupplierName
            End If

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parSupplier(CInt(i))

                'レコードが取得できた時の処理
                '仕入先コード
                parSupplier(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                '仕入先名称
                parSupplier(i).sSupplierName = pDataReader("仕入先名称").ToString
                '郵便番号
                parSupplier(i).sPostCode = pDataReader("郵便番号").ToString
                '住所1
                parSupplier(i).sAddress1 = pDataReader("住所1").ToString
                '住所2
                parSupplier(i).sAddress2 = pDataReader("住所2").ToString
                '住所3
                parSupplier(i).sAddress3 = pDataReader("住所3").ToString
                'TEL
                parSupplier(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parSupplier(i).sFAX = pDataReader("FAX").ToString
                'URL
                parSupplier(i).sURL = pDataReader("URL").ToString
                '担当者名称
                parSupplier(i).sPersonName = pDataReader("担当者名称").ToString
                '締め日
                parSupplier(i).sCloseDate = CInt(pDataReader("締め日"))
                '標準仕切率
                parSupplier(i).sStanderedRate = CSng(pDataReader("標準仕切率"))
                '標準ロット数
                parSupplier(i).sStanderedLot = CInt(pDataReader("標準ロット数"))
                '支払方法コード1
                If IsDBNull(pDataReader("支払方法コード1")) Then
                    parSupplier(i).sPaymentCode1 = 0
                Else
                    parSupplier(i).sPaymentCode1 = CInt(pDataReader("支払方法コード1"))
                End If
                '支払方法コード2
                If IsDBNull(pDataReader("支払方法コード2")) Then
                    parSupplier(i).sPaymentCode2 = 0
                Else
                    parSupplier(i).sPaymentCode2 = CInt(pDataReader("支払方法コード2"))
                End If
                '支払方法コード3
                If IsDBNull(pDataReader("支払方法コード3")) Then
                    parSupplier(i).sPaymentCode3 = 0
                Else
                    parSupplier(i).sPaymentCode3 = CInt(pDataReader("支払方法コード3"))
                End If
                '取引条件
                parSupplier(i).sTrnRule = pDataReader("取引条件").ToString
                '備考
                parSupplier(i).sMemo = pDataReader("備考").ToString
                '登録日
                parSupplier(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                parSupplier(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parSupplier(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                parSupplier(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getSupplierCode = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.getSupplierCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function getNewSupplierCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Long

        strSelect = ""
        strSelect = "SELECT Max([仕入先コード]) AS 最大仕入先コード FROM 仕入先マスタ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getNewSupplierCode = -1

            pDataReader.Read()

            '最大チャネル支払コード
            If IsDBNull(pDataReader("最大仕入先コード")) Then
                getNewSupplierCode = 1
            Else
                getNewSupplierCode = CInt(pDataReader("最大仕入先コード").ToString) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.getNewSupplierCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報明細テーブルに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertSupplierMst(ByVal parSupplier As cStructureLib.sSupplier,
                                    ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO 仕入先マスタ ( " &
                            "仕入先コード, " &
                            "仕入先名称, " &
                            "郵便番号, " &
                            "住所１, " &
                            "住所２, " &
                            "住所３, " &
                            "TEL, " &
                            "FAX, " &
                            "URL, " &
                            "担当者名称, " &
                            "締め日, " &
                            "標準仕切率, " &
                            "標準ロット数, " &
                            "支払方法コード1, " &
                            "支払方法コード2, " &
                            "支払方法コード3, " &
                            "取引条件, " &
                            "備考, " &
                            "登録日, " &
                            "登録時間, " &
                            "最終更新日, " &
                            "最終更新時間 " &
                        ") VALUES (" &
                            "@SupplierCode, " &
                            "@SupplierName, " &
                            "@PostCode, " &
                            "@Address1, " &
                            "@Address2, " &
                            "@Address3, " &
                            "@TEL, " &
                            "@FAX, " &
                            "@URL, " &
                            "@PersonName, " &
                            "@CloseDate, " &
                            "@StanderedRate, " &
                            "@StanderedLot, " &
                            "@PaymentCode1, " &
                            "@PaymentCode2, " &
                            "@PaymentCode3, " &
                            "@TrnRule, " &
                            "@Memo, " &
                            "@CreateDate, " &
                            "@CreateTime, " &
                            "@UpdateDate, " &
                            "@UpdateTime " &
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '仕入先コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierCode", OleDb.OleDbType.Numeric, 5))
            pCommand.Parameters("@SupplierCode").Value = parSupplier.sSupplierCode
            '仕入先名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SupplierName", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@SupplierName").Value = parSupplier.sSupplierName
            '郵便番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PostCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@PostCode").Value = parSupplier.sPostCode
            '住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address1", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@Address1").Value = parSupplier.sAddress1
            '住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address2", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@Address2").Value = parSupplier.sAddress2
            '住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address3", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@Address3").Value = parSupplier.sAddress3
            'TEL
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TEL", OleDb.OleDbType.Char, 12))
            pCommand.Parameters("@TEL").Value = parSupplier.sTEL
            'FAX
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@FAX", OleDb.OleDbType.Char, 12))
            pCommand.Parameters("@FAX").Value = parSupplier.sFAX
            'URL
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@URL", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@URL").Value = parSupplier.sURL
            '担当者名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PersonName", OleDb.OleDbType.Char, 25))
            pCommand.Parameters("@PersonName").Value = parSupplier.sPersonName
            '締め日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CloseDate", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@CloseDate").Value = parSupplier.sCloseDate
            '標準仕切率
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StanderedRate", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@StanderedRate").Value = parSupplier.sStanderedRate
            '標準ロット数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StanderedLot", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@StanderedLot").Value = parSupplier.sStanderedLot
            '支払方法コード1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode1", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@PaymentCode1").Value = parSupplier.sPaymentCode1
            '支払方法コード2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode2", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@PaymentCode2").Value = parSupplier.sPaymentCode2
            '支払方法コード3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCode3", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@PaymentCode3").Value = parSupplier.sPaymentCode3
            '取引条件
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TrnRule", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@TrnRule").Value = parSupplier.sTrnRule
            '備考
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@Memo").Value = parSupplier.sMemo
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

            '仕入先マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertSupplierMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.insertSupplierMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：仕入先マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateSupplierMst(ByVal parSupplier As cStructureLib.sSupplier, ByVal KeySupplierCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 仕入先マスタ SET " & _
                        "仕入先コード = " & parSupplier.sSupplierCode & ", " & _
                        "仕入先名称 = """ & parSupplier.sSupplierName & """, " & _
                        "郵便番号 = """ & parSupplier.sPostCode & """, " & _
                        "住所１ = """ & parSupplier.sAddress1 & """, " & _
                        "住所２ = """ & parSupplier.sAddress2 & """, " & _
                        "住所３ = """ & parSupplier.sAddress3 & """, " & _
                        "TEL = """ & parSupplier.sTEL & """, " & _
                        "FAX = """ & parSupplier.sFAX & """, " & _
                        "URL = """ & parSupplier.sURL & """, " & _
                        "担当者名称 = """ & parSupplier.sPersonName & """, " & _
                        "締め日 = " & parSupplier.sCloseDate & ", " & _
                        "標準仕切率 = " & parSupplier.sStanderedRate & ", " & _
                        "標準ロット数 = " & parSupplier.sStanderedLot & ", " & _
                        "支払方法コード1 = """ & parSupplier.sPaymentCode1 & """, " & _
                        "支払方法コード2 = """ & parSupplier.sPaymentCode2 & """, " & _
                        "支払方法コード3 = """ & parSupplier.sPaymentCode3 & """, " & _
                        "取引条件 = """ & parSupplier.sTrnRule & """, " & _
                        "備考 = """ & parSupplier.sMemo & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE 仕入先マスタ.仕入先コード= " & KeySupplierCode & " "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '仕入先マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()
            If RecordCount > 0 Then
                '更新成功
                Return True
            Else
                '更新するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.updateSupplierMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データの伝票印刷モードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteSupplierMst(ByVal KeySupplierCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE 仕入先マスタ.仕入先コード FROM 仕入先マスタ " & _
                        "WHERE 仕入先マスタ.仕入先コード=" & KeySupplierCode & " "

            pCommand.CommandText = strDelete

            '仕入先マスタの削除処理実行
            deleteSupplierMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSupplierDBIO.deleteSupplierMst)", Nothing, Nothing, oExcept.ToString)
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
