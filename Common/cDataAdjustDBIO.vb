Public Class cDataAdjustDBIO
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
    Public Function AdjustExist(ByVal KeyString As String, ByRef Tran As OleDb.OleDbTransaction) As Boolean

        Const strSelect As String =
        "SELECT COUNT(*) FROM 精算データ WHERE 精算コード = @AdjustCode"

        Try

            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AdjustCode", OleDb.OleDbType.Char, 5))
            pCommand.Parameters("@AdjustCode").Value = KeyString

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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.AdjustExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：精算データから該当精算コード以上のレコードを取得する関数
    '　引数：ParAdjust 取得データセット用バッファ
    '        KeyAdjustCode 精算コード
    '        Mode          1:指定精算コードのデータ取得
    '                      2:指定精算コード以上の入金データ取得
    '                      3:最後の精算レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getAdjust(ByRef ParAdjust() As cStructureLib.sAdjust, _
                              ByVal KeyFromAdjustCode As Long, _
                              ByVal KeyToAdjustCode As Long, _
                              ByVal KeyAdjustDate As String, _
                              ByVal KeyAdjustClass1 As String, _
                              ByVal KeyAdjustClass2 As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer

        StrSelect = "SELECT 精算データ.精算コード AS 精算コード, " & _
                            "精算データ.精算区分 AS 精算区分, " & _
                            "精算データ.精算日 AS 精算日, " & _
                            "精算データ.金額 AS 金額, " & _
                            "精算データ.勘定科目コード AS 勘定科目コード, " & _
                            "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
                            "勘定科目マスタ.税区分コード AS 税区分コード, " & _
                            "税区分マスタ.税区分名称 AS 税区分名称, " & _
                            "精算データ.補助勘定科目コード AS 補助勘定科目コード, " & _
                            "勘定科目補助マスタ.補助勘定科目名称 AS 補助勘定科目名称, " & _
                            "精算データ.レジ入金金額 AS レジ入金金額, " & _
                            "精算データ.既レジ入金金額 AS 既レジ入金金額, " & _
                            "精算データ.D10000円 AS D10000円, " & _
                            "精算データ.D5000円 AS D5000円, " & _
                            "精算データ.D1000円 AS D1000円, " & _
                            "精算データ.D500円 AS D500円, " & _
                            "精算データ.D100円 AS D100円, " & _
                            "精算データ.D50円 AS D50円, " & _
                            "精算データ.D10円 AS D10円, " & _
                            "精算データ.D5円 AS D5円, " & _
                            "精算データ.D1円 AS D1円, " & _
                            "精算データ.金庫入金金額 AS 金庫入金金額, " & _
                            "精算データ.K10000円 AS K10000円, " & _
                            "精算データ.K5000円 AS K5000円, " & _
                            "精算データ.K1000円 AS K1000円, " & _
                            "精算データ.K500円 AS K500円, " & _
                            "精算データ.K100円 AS K100円, " & _
                            "精算データ.K50円 AS K50円, " & _
                            "精算データ.K10円 AS K10円, " & _
                            "精算データ.K5円 AS K5円, " & _
                            "精算データ.K1円 AS K1円, " & _
                            "精算データ.精算担当者コード AS 精算担当者コード, " & _
                            "精算データ.登録日 AS 登録日, " & _
                            "精算データ.登録時間 AS 登録時間, " & _
                            "精算データ.最終更新日 AS 最終更新日, " & _
                            "精算データ.最終更新時間 AS 最終更新時間 " & _
                    "FROM ((勘定科目マスタ INNER JOIN 税区分マスタ " & _
                    "ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード) " & _
                    "INNER JOIN 勘定科目補助マスタ " & _
                    "ON 勘定科目マスタ.勘定科目コード = 勘定科目補助マスタ.勘定科目コード) " & _
                    "INNER JOIN 精算データ " & _
                    "ON (精算データ.補助勘定科目コード = 勘定科目補助マスタ.補助勘定科目コード) " & _
                    "AND (勘定科目マスタ.勘定科目コード = 精算データ.勘定科目コード) "



        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'パラメータ数のカウント
            pc = 0
            If KeyFromAdjustCode <> Nothing Then
                mpc = 1
                pc = pc Or mpc
            End If
            If KeyToAdjustCode <> Nothing Then
                mpc = 2
                pc = pc Or mpc
            End If
            If KeyAdjustDate <> Nothing Then
                mpc = 4
                pc = pc Or mpc
            End If
            If KeyAdjustClass1 <> Nothing Then
                mpc = 8
                pc = pc Or mpc
            End If
            If KeyAdjustClass2 <> Nothing Then
                mpc = 16
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

                            StrSelect = StrSelect & "精算コード >= " & KeyFromAdjustCode & " "

                            scnt = scnt + 1
                        Case 2
                            '2016.07.14 K.Oikawa s
                            'If scnt > 0 Then
                            '    StrSelect = StrSelect & "AND "
                            'Else
                            '    StrSelect = StrSelect & "WHERE "
                            'End If
                            'StrSelect = StrSelect & "精算コード <= " & KeyToAdjustCode & " "
                            'scnt = scnt + 1
                            If KeyToAdjustCode <> -1 Then
                                If scnt > 0 Then
                                    StrSelect = StrSelect & "AND "
                                Else
                                    StrSelect = StrSelect & "WHERE "
                                End If
                                StrSelect = StrSelect & "精算コード <= " & KeyToAdjustCode & " "
                                scnt = scnt + 1
                            End If
                            '2016.07.14 K.Oikawa e
                        Case 4
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算日 Like ""%" & KeyAdjustDate & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算区分 Like ""%" & KeyAdjustClass1 & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                StrSelect = StrSelect & "OR "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算区分 Like ""%" & KeyAdjustClass2 & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParAdjust(CInt(i))

                'レコードが取得できた時の処理
                '精算コード
                ParAdjust(i).sAdjustCode = CLng(pDataReader("精算コード"))
                '精算区分
                ParAdjust(i).sAdjustClass = pDataReader("精算区分").ToString
                '精算日
                ParAdjust(i).sAdjustDate = pDataReader("精算日").ToString
                '金額
                ParAdjust(i).sTotalPrice = CLng(pDataReader("金額"))
                '勘定科目コード
                ParAdjust(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                ParAdjust(i).sAccountName = pDataReader("勘定科目名称").ToString
                '税区分コード
                ParAdjust(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                '税区分名称
                ParAdjust(i).sTaxClassName = pDataReader("税区分名称").ToString
                '補助勘定科目コード
                ParAdjust(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                ParAdjust(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                'レジ入金金額
                ParAdjust(i).sDTotalPrice = CLng(pDataReader("レジ入金金額"))
                '既レジ入金金額
                ParAdjust(i).sAlreadyDTotalPrice = CLng(pDataReader("既レジ入金金額"))
                'D10000円
                ParAdjust(i).sD10000Yen = CInt(pDataReader("D10000円"))
                'D5000円
                ParAdjust(i).sD5000Yen = CInt(pDataReader("D5000円"))
                'D1000円
                ParAdjust(i).sD1000Yen = CInt(pDataReader("D1000円"))
                'D500円
                ParAdjust(i).sD500Yen = CInt(pDataReader("D500円"))
                'D100円
                ParAdjust(i).sD100Yen = CInt(pDataReader("D100円"))
                'D50円
                ParAdjust(i).sD50Yen = CInt(pDataReader("D50円"))
                'D10円
                ParAdjust(i).sD10Yen = CInt(pDataReader("D10円"))
                'D5円
                ParAdjust(i).sD5Yen = CInt(pDataReader("D5円"))
                'D1円
                ParAdjust(i).sD1Yen = CInt(pDataReader("D1円"))

                '金庫入金金額
                ParAdjust(i).sKTotalPrice = CLng(pDataReader("金庫入金金額"))
                'D10000円
                ParAdjust(i).sK10000Yen = CInt(pDataReader("K10000円"))
                'K5000円
                ParAdjust(i).sK5000Yen = CInt(pDataReader("K5000円"))
                'K1000円
                ParAdjust(i).sK1000Yen = CInt(pDataReader("K1000円"))
                'K500円
                ParAdjust(i).sK500Yen = CInt(pDataReader("K500円"))
                'K100円
                ParAdjust(i).sK100Yen = CInt(pDataReader("K100円"))
                'K50円
                ParAdjust(i).sK50Yen = CInt(pDataReader("K50円"))
                'K10円
                ParAdjust(i).sK10Yen = CInt(pDataReader("K10円"))
                'K5円
                ParAdjust(i).sK5Yen = CInt(pDataReader("K5円"))
                'K1円
                ParAdjust(i).sK1Yen = CInt(pDataReader("K1円"))

                '締め日
                'ParAdjust(i).sCloseDate = pDataReader("月次締日").ToString

                '精算担当者コード
                ParAdjust(i).sAdjustStaffCode = pDataReader("精算担当者コード").ToString

                '登録日
                ParAdjust(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                ParAdjust(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParAdjust(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                ParAdjust(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getAdjust = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getAdjust)", Nothing, Nothing, oExcept.ToString)
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






    '2016.07.21 K.Oikawa s
    Public Function getAdjust2(ByRef ParAdjust() As cStructureLib.sAdjust, _
                              ByVal KeyFromAdjustCode As Long, _
                              ByVal KeyToAdjustCode As Long, _
                              ByVal KeyAdjustDate As String, _
                              ByVal KeyAdjustClass1 As String, _
                              ByVal KeyAdjustClass2 As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer


        StrSelect = "SELECT 精算データ.精算コード AS 精算コード, " & _
                            "精算データ.精算区分 AS 精算区分, " & _
                            "精算データ.精算日 AS 精算日, " & _
                            "精算データ.金額 AS 金額, " & _
                            "精算データ.勘定科目コード AS 勘定科目コード, " & _
                            "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
                            "勘定科目マスタ.税区分コード AS 税区分コード, " & _
                            "税区分マスタ.税区分名称 AS 税区分名称, " & _
                            "精算データ.補助勘定科目コード AS 補助勘定科目コード, " & _
                            "勘定科目補助マスタ.補助勘定科目名称 AS 補助勘定科目名称, " & _
                            "精算データ.レジ入金金額 AS レジ入金金額, " & _
                            "精算データ.既レジ入金金額 AS 既レジ入金金額, " & _
                            "精算データ.D10000円 AS D10000円, " & _
                            "精算データ.D5000円 AS D5000円, " & _
                            "精算データ.D1000円 AS D1000円, " & _
                            "精算データ.D500円 AS D500円, " & _
                            "精算データ.D100円 AS D100円, " & _
                            "精算データ.D50円 AS D50円, " & _
                            "精算データ.D10円 AS D10円, " & _
                            "精算データ.D5円 AS D5円, " & _
                            "精算データ.D1円 AS D1円, " & _
                            "精算データ.金庫入金金額 AS 金庫入金金額, " & _
                            "精算データ.K10000円 AS K10000円, " & _
                            "精算データ.K5000円 AS K5000円, " & _
                            "精算データ.K1000円 AS K1000円, " & _
                            "精算データ.K500円 AS K500円, " & _
                            "精算データ.K100円 AS K100円, " & _
                            "精算データ.K50円 AS K50円, " & _
                            "精算データ.K10円 AS K10円, " & _
                            "精算データ.K5円 AS K5円, " & _
                            "精算データ.K1円 AS K1円, " & _
                            "精算データ.精算担当者コード AS 精算担当者コード, " & _
                            "精算データ.登録日 AS 登録日, " & _
                            "精算データ.登録時間 AS 登録時間, " & _
                            "精算データ.最終更新日 AS 最終更新日, " & _
                            "精算データ.最終更新時間 AS 最終更新時間 " & _
                    "FROM ((精算データ " & _
                    "LEFT JOIN 勘定科目マスタ " & _
                    "  ON 精算データ.勘定科目コード = 勘定科目マスタ.勘定科目コード) " & _
                    "LEFT JOIN 勘定科目補助マスタ " & _
                    "  ON 精算データ.勘定科目コード = 勘定科目補助マスタ.勘定科目コード " & _
                    " AND 精算データ.補助勘定科目コード = 勘定科目補助マスタ.補助勘定科目コード) " & _
                    "LEFT JOIN 税区分マスタ " & _
                    "  ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード " & _
                    "WHERE 精算コード >= " & KeyFromAdjustCode & " " & _
                    "AND (精算区分 = """ & KeyAdjustClass1 & """ " & _
                    "OR 精算区分 = """ & KeyAdjustClass2 & """) "
        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran


            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParAdjust(CInt(i))

                'レコードが取得できた時の処理
                '精算コード
                ParAdjust(i).sAdjustCode = CLng(pDataReader("精算コード"))
                '精算区分
                ParAdjust(i).sAdjustClass = pDataReader("精算区分").ToString
                '精算日
                ParAdjust(i).sAdjustDate = pDataReader("精算日").ToString
                '金額
                ParAdjust(i).sTotalPrice = CLng(pDataReader("金額"))
                '勘定科目コード
                ParAdjust(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                ParAdjust(i).sAccountName = pDataReader("勘定科目名称").ToString
                '税区分コード
                ParAdjust(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                '税区分名称
                ParAdjust(i).sTaxClassName = pDataReader("税区分名称").ToString
                '補助勘定科目コード
                ParAdjust(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                ParAdjust(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                'レジ入金金額
                ParAdjust(i).sDTotalPrice = CLng(pDataReader("レジ入金金額"))
                '既レジ入金金額
                ParAdjust(i).sAlreadyDTotalPrice = CLng(pDataReader("既レジ入金金額"))
                'D10000円
                ParAdjust(i).sD10000Yen = CInt(pDataReader("D10000円"))
                'D5000円
                ParAdjust(i).sD5000Yen = CInt(pDataReader("D5000円"))
                'D1000円
                ParAdjust(i).sD1000Yen = CInt(pDataReader("D1000円"))
                'D500円
                ParAdjust(i).sD500Yen = CInt(pDataReader("D500円"))
                'D100円
                ParAdjust(i).sD100Yen = CInt(pDataReader("D100円"))
                'D50円
                ParAdjust(i).sD50Yen = CInt(pDataReader("D50円"))
                'D10円
                ParAdjust(i).sD10Yen = CInt(pDataReader("D10円"))
                'D5円
                ParAdjust(i).sD5Yen = CInt(pDataReader("D5円"))
                'D1円
                ParAdjust(i).sD1Yen = CInt(pDataReader("D1円"))

                '金庫入金金額
                ParAdjust(i).sKTotalPrice = CLng(pDataReader("金庫入金金額"))
                'D10000円
                ParAdjust(i).sK10000Yen = CInt(pDataReader("K10000円"))
                'K5000円
                ParAdjust(i).sK5000Yen = CInt(pDataReader("K5000円"))
                'K1000円
                ParAdjust(i).sK1000Yen = CInt(pDataReader("K1000円"))
                'K500円
                ParAdjust(i).sK500Yen = CInt(pDataReader("K500円"))
                'K100円
                ParAdjust(i).sK100Yen = CInt(pDataReader("K100円"))
                'K50円
                ParAdjust(i).sK50Yen = CInt(pDataReader("K50円"))
                'K10円
                ParAdjust(i).sK10Yen = CInt(pDataReader("K10円"))
                'K5円
                ParAdjust(i).sK5Yen = CInt(pDataReader("K5円"))
                'K1円
                ParAdjust(i).sK1Yen = CInt(pDataReader("K1円"))

                '締め日
                'ParAdjust(i).sCloseDate = pDataReader("月次締日").ToString

                '精算担当者コード
                ParAdjust(i).sAdjustStaffCode = pDataReader("精算担当者コード").ToString

                '登録日
                ParAdjust(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                ParAdjust(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParAdjust(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                ParAdjust(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getAdjust2 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getAdjust)", Nothing, Nothing, oExcept.ToString)
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
    '　勘定科目が結び付けられない精算データも取得できるようSQL修正
    '----------------------------------------------------------------------
    Public Function getAdjust3(ByRef ParAdjust() As cStructureLib.sAdjust, _
                              ByVal KeyFromAdjustCode As Long, _
                              ByVal KeyToAdjustCode As Long, _
                              ByVal KeyAdjustDate As String, _
                              ByVal KeyAdjustClass1 As String, _
                              ByVal KeyAdjustClass2 As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer


        StrSelect = "SELECT 精算データ.精算コード AS 精算コード, " & _
                            "精算データ.精算区分 AS 精算区分, " & _
                            "精算データ.精算日 AS 精算日, " & _
                            "精算データ.金額 AS 金額, " & _
                            "精算データ.勘定科目コード AS 勘定科目コード, " & _
                            "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
                            "勘定科目マスタ.税区分コード AS 税区分コード, " & _
                            "税区分マスタ.税区分名称 AS 税区分名称, " & _
                            "精算データ.補助勘定科目コード AS 補助勘定科目コード, " & _
                            "勘定科目補助マスタ.補助勘定科目名称 AS 補助勘定科目名称, " & _
                            "精算データ.レジ入金金額 AS レジ入金金額, " & _
                            "精算データ.既レジ入金金額 AS 既レジ入金金額, " & _
                            "精算データ.D10000円 AS D10000円, " & _
                            "精算データ.D5000円 AS D5000円, " & _
                            "精算データ.D1000円 AS D1000円, " & _
                            "精算データ.D500円 AS D500円, " & _
                            "精算データ.D100円 AS D100円, " & _
                            "精算データ.D50円 AS D50円, " & _
                            "精算データ.D10円 AS D10円, " & _
                            "精算データ.D5円 AS D5円, " & _
                            "精算データ.D1円 AS D1円, " & _
                            "精算データ.金庫入金金額 AS 金庫入金金額, " & _
                            "精算データ.K10000円 AS K10000円, " & _
                            "精算データ.K5000円 AS K5000円, " & _
                            "精算データ.K1000円 AS K1000円, " & _
                            "精算データ.K500円 AS K500円, " & _
                            "精算データ.K100円 AS K100円, " & _
                            "精算データ.K50円 AS K50円, " & _
                            "精算データ.K10円 AS K10円, " & _
                            "精算データ.K5円 AS K5円, " & _
                            "精算データ.K1円 AS K1円, " & _
                            "精算データ.精算担当者コード AS 精算担当者コード, " & _
                            "精算データ.登録日 AS 登録日, " & _
                            "精算データ.登録時間 AS 登録時間, " & _
                            "精算データ.最終更新日 AS 最終更新日, " & _
                            "精算データ.最終更新時間 AS 最終更新時間 " & _
                    "FROM ((精算データ " & _
                    "LEFT JOIN 勘定科目マスタ " & _
                    "  ON 精算データ.勘定科目コード = 勘定科目マスタ.勘定科目コード) " & _
                    "LEFT JOIN 勘定科目補助マスタ " & _
                    "  ON 精算データ.勘定科目コード = 勘定科目補助マスタ.勘定科目コード " & _
                    " AND 精算データ.補助勘定科目コード = 勘定科目補助マスタ.補助勘定科目コード) " & _
                    "LEFT JOIN 税区分マスタ " & _
                    "  ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'パラメータ数のカウント
            pc = 0
            If KeyFromAdjustCode <> Nothing Then
                mpc = 1
                pc = pc Or mpc
            End If
            If KeyToAdjustCode <> Nothing Then
                mpc = 2
                pc = pc Or mpc
            End If
            If KeyAdjustDate <> Nothing Then
                mpc = 4
                pc = pc Or mpc
            End If
            If KeyAdjustClass1 <> Nothing Then
                mpc = 8
                pc = pc Or mpc
            End If
            If KeyAdjustClass2 <> Nothing Then
                mpc = 16
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

                            StrSelect = StrSelect & "精算コード >= " & KeyFromAdjustCode & " "

                            scnt = scnt + 1
                        Case 2
                            '2016.07.14 K.Oikawa s
                            'If scnt > 0 Then
                            '    StrSelect = StrSelect & "AND "
                            'Else
                            '    StrSelect = StrSelect & "WHERE "
                            'End If
                            'StrSelect = StrSelect & "精算コード <= " & KeyToAdjustCode & " "
                            'scnt = scnt + 1
                            If KeyToAdjustCode <> -1 Then
                                If scnt > 0 Then
                                    StrSelect = StrSelect & "AND "
                                Else
                                    StrSelect = StrSelect & "WHERE "
                                End If
                                StrSelect = StrSelect & "精算コード <= " & KeyToAdjustCode & " "
                                scnt = scnt + 1
                            End If
                            '2016.07.14 K.Oikawa e
                        Case 4
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算日 Like ""%" & KeyAdjustDate & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                StrSelect = StrSelect & "AND "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算区分 Like ""%" & KeyAdjustClass1 & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                StrSelect = StrSelect & "OR "
                            Else
                                StrSelect = StrSelect & "WHERE "
                            End If
                            StrSelect = StrSelect & "精算区分 Like ""%" & KeyAdjustClass2 & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParAdjust(CInt(i))

                'レコードが取得できた時の処理
                '精算コード
                ParAdjust(i).sAdjustCode = CLng(pDataReader("精算コード"))
                '精算区分
                ParAdjust(i).sAdjustClass = pDataReader("精算区分").ToString
                '精算日
                ParAdjust(i).sAdjustDate = pDataReader("精算日").ToString
                '金額
                ParAdjust(i).sTotalPrice = CLng(pDataReader("金額"))
                '勘定科目コード
                ParAdjust(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                ParAdjust(i).sAccountName = pDataReader("勘定科目名称").ToString
                '税区分コード
                ParAdjust(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
                '税区分名称
                ParAdjust(i).sTaxClassName = pDataReader("税区分名称").ToString
                '補助勘定科目コード
                ParAdjust(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                ParAdjust(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                'レジ入金金額
                ParAdjust(i).sDTotalPrice = CLng(pDataReader("レジ入金金額"))
                '既レジ入金金額
                ParAdjust(i).sAlreadyDTotalPrice = CLng(pDataReader("既レジ入金金額"))
                'D10000円
                ParAdjust(i).sD10000Yen = CInt(pDataReader("D10000円"))
                'D5000円
                ParAdjust(i).sD5000Yen = CInt(pDataReader("D5000円"))
                'D1000円
                ParAdjust(i).sD1000Yen = CInt(pDataReader("D1000円"))
                'D500円
                ParAdjust(i).sD500Yen = CInt(pDataReader("D500円"))
                'D100円
                ParAdjust(i).sD100Yen = CInt(pDataReader("D100円"))
                'D50円
                ParAdjust(i).sD50Yen = CInt(pDataReader("D50円"))
                'D10円
                ParAdjust(i).sD10Yen = CInt(pDataReader("D10円"))
                'D5円
                ParAdjust(i).sD5Yen = CInt(pDataReader("D5円"))
                'D1円
                ParAdjust(i).sD1Yen = CInt(pDataReader("D1円"))

                '金庫入金金額
                ParAdjust(i).sKTotalPrice = CLng(pDataReader("金庫入金金額"))
                'D10000円
                ParAdjust(i).sK10000Yen = CInt(pDataReader("K10000円"))
                'K5000円
                ParAdjust(i).sK5000Yen = CInt(pDataReader("K5000円"))
                'K1000円
                ParAdjust(i).sK1000Yen = CInt(pDataReader("K1000円"))
                'K500円
                ParAdjust(i).sK500Yen = CInt(pDataReader("K500円"))
                'K100円
                ParAdjust(i).sK100Yen = CInt(pDataReader("K100円"))
                'K50円
                ParAdjust(i).sK50Yen = CInt(pDataReader("K50円"))
                'K10円
                ParAdjust(i).sK10Yen = CInt(pDataReader("K10円"))
                'K5円
                ParAdjust(i).sK5Yen = CInt(pDataReader("K5円"))
                'K1円
                ParAdjust(i).sK1Yen = CInt(pDataReader("K1円"))

                '締め日
                'ParAdjust(i).sCloseDate = pDataReader("月次締日").ToString

                '精算担当者コード
                ParAdjust(i).sAdjustStaffCode = pDataReader("精算担当者コード").ToString

                '登録日
                ParAdjust(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                ParAdjust(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParAdjust(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                ParAdjust(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getAdjust3 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getAdjust)", Nothing, Nothing, oExcept.ToString)
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

    '2016.07.21 K.Oikawa e




    'Public Function getAdjust(ByRef ParAdjust() As cStructureLib.sAdjust, _
    '                          ByVal KeyFromAdjustCode As Long, _
    '                          ByVal KeyToAdjustCode As Long, _
    '                          ByVal KeyAdjustDate As String, _
    '                          ByVal KeyClass As String, _
    '                          ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

    '    Dim i As Integer
    '    Dim StrSelect As String

    '    StrSelect = "SELECT 精算データ.精算コード AS 精算コード, " & _
    '                        "精算データ.精算区分 AS 精算区分, " & _
    '                        "精算データ.精算日 AS 精算日, " & _
    '                        "精算データ.金額 AS 金額, " & _
    '                        "精算データ.勘定科目コード AS 勘定科目コード, " & _
    '                        "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
    '                        "勘定科目マスタ.税区分コード AS 税区分コード, " & _
    '                        "税区分マスタ.税区分名称 AS 税区分名称, " & _
    '                        "精算データ.補助勘定科目コード AS 補助勘定科目コード, " & _
    '                        "勘定科目補助マスタ.補助勘定科目名称 AS 補助勘定科目名称, " & _
    '                        "精算データ.レジ入金金額 AS レジ入金金額, " & _
    '                        "精算データ.既レジ入金金額 AS 既レジ入金金額, " & _
    '                        "精算データ.D10000円 AS D10000円, " & _
    '                        "精算データ.D5000円 AS D5000円, " & _
    '                        "精算データ.D1000円 AS D1000円, " & _
    '                        "精算データ.D500円 AS D500円, " & _
    '                        "精算データ.D100円 AS D100円, " & _
    '                        "精算データ.D50円 AS D50円, " & _
    '                        "精算データ.D10円 AS D10円, " & _
    '                        "精算データ.D5円 AS D5円, " & _
    '                        "精算データ.D1円 AS D1円, " & _
    '                        "精算データ.金庫入金金額 AS 金庫入金金額, " & _
    '                        "精算データ.K10000円 AS K10000円, " & _
    '                        "精算データ.K5000円 AS K5000円, " & _
    '                        "精算データ.K1000円 AS K1000円, " & _
    '                        "精算データ.K500円 AS K500円, " & _
    '                        "精算データ.K100円 AS K100円, " & _
    '                        "精算データ.K50円 AS K50円, " & _
    '                        "精算データ.K10円 AS K10円, " & _
    '                        "精算データ.K5円 AS K5円, " & _
    '                        "精算データ.K1円 AS K1円, " & _
    '                        "精算データ.精算担当者コード AS 精算担当者コード, " & _
    '                        "精算データ.登録日 AS 登録日, " & _
    '                        "精算データ.登録時間 AS 登録時間, " & _
    '                        "精算データ.最終更新日 AS 最終更新日, " & _
    '                        "精算データ.最終更新時間 AS 最終更新時間 " & _
    '                "FROM ((勘定科目マスタ INNER JOIN 税区分マスタ " & _
    '                "ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード) " & _
    '                "INNER JOIN 勘定科目補助マスタ " & _
    '                "ON 勘定科目マスタ.勘定科目コード = 勘定科目補助マスタ.勘定科目コード) " & _
    '                "INNER JOIN 精算データ " & _
    '                "ON (精算データ.補助勘定科目コード = 勘定科目補助マスタ.補助勘定科目コード) " & _
    '                "AND (勘定科目マスタ.勘定科目コード = 精算データ.勘定科目コード) "

    '    Select Case Mode
    '        Case CInt(cStructureLib.GetAdjustMode.FromToAdjustCode)
    '            If IsNothing(KeyToAdjustCode) = True Then
    '                StrSelect = StrSelect & "WHERE 精算コード = @FromAdjustCode "
    '            Else
    '                StrSelect = StrSelect & "WHERE 精算コード >= @FromAdjustCode AND 精算コード <= @ToAdjustCode　"
    '            End If
    '        Case CInt(cStructureLib.GetAdjustMode.OrderOverAdjustCodeInPutClass)
    '            StrSelect = StrSelect & "WHERE 精算コード >= @FromAdjustCode AND 精算区分 = ""レジ入金"" ORDER BY 精算コード"
    '        Case CInt(cStructureLib.GetAdjustMode.DescOrderAll)
    '            StrSelect = StrSelect & "ORDER BY 精算コード DESC"
    '        Case CInt(cStructureLib.GetAdjustMode.OrderOverAdjustCode)
    '            StrSelect = StrSelect & "WHERE 精算コード >= @FromAdjustCode ORDER BY 精算コード"
    '        Case CInt(cStructureLib.GetAdjustMode.OrderDateInOutClass)
    '            'StrSelect = StrSelect & "WHERE 精算コード >= @FromAdjustCode " & _
    '            '                            "AND 精算コード <= @ToAdjustCode " & _
    '            StrSelect = StrSelect & "WHERE 精算日 = @AdjustDate " & _
    '                                        "AND (精算区分 = ""入金"" OR 精算区分 = ""出金"") " & _
    '                                        "ORDER BY 精算コード"
    '        Case CInt(cStructureLib.GetAdjustMode.AdjustDate)
    '            StrSelect = StrSelect & "WHERE 精算日 = @AdjustDate "
    '    End Select

    '    Try
    '        'SQL文の設定
    '        pCommand = pConn.CreateCommand
    '        pCommand.Transaction = Tran

    '        pCommand.CommandText = StrSelect

    '        '検索対象「From精算コード」指定
    '        If IsNothing(KeyFromAdjustCode) = False Then
    '            pCommand.Parameters.Add _
    '                (New OleDb.OleDbParameter("@FromAdjustCode", OleDb.OleDbType.Numeric, 10))
    '            pCommand.Parameters("@FromAdjustCode").Value = KeyFromAdjustCode
    '        End If
    '        '検索対象「To精算コード」指定
    '        If IsNothing(KeyToAdjustCode) = False Then
    '            pCommand.Parameters.Add _
    '                (New OleDb.OleDbParameter("@ToAdjustCode", OleDb.OleDbType.Numeric, 10))
    '            pCommand.Parameters("@ToAdjustCode").Value = KeyToAdjustCode
    '        End If
    '        '検索対象「精算日」指定
    '        If IsNothing(KeyAdjustDate) = False Then
    '            pCommand.Parameters.Add _
    '                (New OleDb.OleDbParameter("@AdjustDate", OleDb.OleDbType.Char, 10))
    '            pCommand.Parameters("@AdjustDate").Value = KeyAdjustDate
    '        End If

    '        pDataReader = pCommand.ExecuteReader()

    '        i = 0
    '        While pDataReader.Read()

    '            ReDim Preserve ParAdjust(CInt(i))

    '            'レコードが取得できた時の処理
    '            '精算コード
    '            ParAdjust(i).sAdjustCode = CLng(pDataReader("精算コード"))
    '            '精算区分
    '            ParAdjust(i).sAdjustClass = pDataReader("精算区分").ToString
    '            '精算日
    '            ParAdjust(i).sAdjustDate = pDataReader("精算日").ToString
    '            '金額
    '            ParAdjust(i).sTotalPrice = CLng(pDataReader("金額"))
    '            '勘定科目コード
    '            ParAdjust(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
    '            '勘定科目名称
    '            ParAdjust(i).sAccountName = pDataReader("勘定科目名称").ToString
    '            '税区分コード
    '            ParAdjust(i).sTaxClassCode = CInt(pDataReader("税区分コード"))
    '            '税区分名称
    '            ParAdjust(i).sTaxClassName = pDataReader("税区分名称").ToString
    '            '補助勘定科目コード
    '            ParAdjust(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
    '            '補助勘定科目名称
    '            ParAdjust(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
    '            'レジ入金金額
    '            ParAdjust(i).sDTotalPrice = CLng(pDataReader("レジ入金金額"))
    '            '既レジ入金金額
    '            ParAdjust(i).sAlreadyDTotalPrice = CLng(pDataReader("既レジ入金金額"))
    '            'D10000円
    '            ParAdjust(i).sD10000Yen = CInt(pDataReader("D10000円"))
    '            'D5000円
    '            ParAdjust(i).sD5000Yen = CInt(pDataReader("D5000円"))
    '            'D1000円
    '            ParAdjust(i).sD1000Yen = CInt(pDataReader("D1000円"))
    '            'D500円
    '            ParAdjust(i).sD500Yen = CInt(pDataReader("D500円"))
    '            'D100円
    '            ParAdjust(i).sD100Yen = CInt(pDataReader("D100円"))
    '            'D50円
    '            ParAdjust(i).sD50Yen = CInt(pDataReader("D50円"))
    '            'D10円
    '            ParAdjust(i).sD10Yen = CInt(pDataReader("D10円"))
    '            'D5円
    '            ParAdjust(i).sD5Yen = CInt(pDataReader("D5円"))
    '            'D1円
    '            ParAdjust(i).sD1Yen = CInt(pDataReader("D1円"))

    '            '金庫入金金額
    '            ParAdjust(i).sKTotalPrice = CLng(pDataReader("金庫入金金額"))
    '            'D10000円
    '            ParAdjust(i).sK10000Yen = CInt(pDataReader("K10000円"))
    '            'K5000円
    '            ParAdjust(i).sK5000Yen = CInt(pDataReader("K5000円"))
    '            'K1000円
    '            ParAdjust(i).sK1000Yen = CInt(pDataReader("K1000円"))
    '            'K500円
    '            ParAdjust(i).sK500Yen = CInt(pDataReader("K500円"))
    '            'K100円
    '            ParAdjust(i).sK100Yen = CInt(pDataReader("K100円"))
    '            'K50円
    '            ParAdjust(i).sK50Yen = CInt(pDataReader("K50円"))
    '            'K10円
    '            ParAdjust(i).sK10Yen = CInt(pDataReader("K10円"))
    '            'K5円
    '            ParAdjust(i).sK5Yen = CInt(pDataReader("K5円"))
    '            'K1円
    '            ParAdjust(i).sK1Yen = CInt(pDataReader("K1円"))

    '            '締め日
    '            'ParAdjust(i).sCloseDate = pDataReader("月次締日").ToString

    '            '精算担当者コード
    '            ParAdjust(i).sAdjustStaffCode = pDataReader("精算担当者コード").ToString

    '            '登録日
    '            ParAdjust(i).sCreateDate = pDataReader("登録日").ToString
    '            '登録日時
    '            ParAdjust(i).sCreateTime = pDataReader("登録時間").ToString
    '            '最終更新日
    '            ParAdjust(i).sUpdateDate = pDataReader("最終更新日").ToString
    '            '最終更新日時
    '            ParAdjust(i).sUpdateTime = pDataReader("最終更新時間").ToString
    '            'レコードが取得できた時の処理
    '            i = i + 1
    '        End While

    '        getAdjust = i

    '    Catch oExcept As Exception
    '        '例外が発生した時の処理
    '        pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getAdjust)", Nothing, Nothing, oExcept.ToString)
    '        pMessageBox.ShowDialog()
    '        pMessageBox.Dispose()
    '        pMessageBox = Nothing
    '        Environment.Exit(1)
    '    Finally
    '        If IsNothing(pDataReader) = False Then
    '            pDataReader.Close()
    '        End If
    '    End Try

    'End Function

    '----------------------------------------------------------------------
    '　機能：精算データから該当精算コード以上のレコードを取得する関数
    '　引数：ParAdjust 取得データセット用バッファ
    '        KeyAdjustCode 精算コード
    '        Mode          1:指定精算コードのデータ取得
    '                      2:指定精算コード以上の入金データ取得
    '                      3:最後の精算レコードを取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getBetweenAdjust(ByRef ParAdjust() As cStructureLib.sAdjust, _
                              ByVal KeyFromAdjustDate As String, _
                              ByVal KeyToAdjustDate As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String

        StrSelect = "SELECT 精算データ.精算コード AS 精算コード, " & _
                            "精算データ.精算区分 AS 精算区分, " & _
                            "精算データ.精算日 AS 精算日, " & _
                            "精算データ.金額 AS 金額, " & _
                            "精算データ.勘定科目コード AS 勘定科目コード, " & _
                            "勘定科目マスタ.勘定科目名称 AS 勘定科目名称, " & _
                            "税区分マスタ.税区分名称 AS 税区分名称, " & _
                            "精算データ.補助勘定科目コード AS 補助勘定科目コード, " & _
                            "勘定科目補助マスタ.補助勘定科目名称 AS 補助勘定科目名称, " & _
                            "精算データ.レジ入金金額 AS レジ入金金額, " & _
                            "精算データ.既レジ入金金額 AS 既レジ入金金額, " & _
                            "精算データ.D10000円 AS D10000円, " & _
                            "精算データ.D5000円 AS D5000円, " & _
                            "精算データ.D1000円 AS D1000円, " & _
                            "精算データ.D500円 AS D500円, " & _
                            "精算データ.D100円 AS D100円, " & _
                            "精算データ.D50円 AS D50円, " & _
                            "精算データ.D10円 AS D10円, " & _
                            "精算データ.D5円 AS D5円, " & _
                            "精算データ.D1円 AS D1円, " & _
                            "精算データ.金庫入金金額 AS 金庫入金金額, " & _
                            "精算データ.K10000円 AS K10000円, " & _
                            "精算データ.K5000円 AS K5000円, " & _
                            "精算データ.K1000円 AS K1000円, " & _
                            "精算データ.K500円 AS K500円, " & _
                            "精算データ.K100円 AS K100円, " & _
                            "精算データ.K50円 AS K50円, " & _
                            "精算データ.K10円 AS K10円, " & _
                            "精算データ.K5円 AS K5円, " & _
                            "精算データ.K1円 AS K1円, " & _
                            "精算データ.精算担当者コード AS 精算担当者コード, " & _
                            "精算データ.登録日 AS 登録日, " & _
                            "精算データ.登録時間 AS 登録時間, " & _
                            "精算データ.最終更新日 AS 最終更新日, " & _
                            "精算データ.最終更新時間 AS 最終更新時間 " & _
                    "FROM ((精算データ LEFT JOIN 勘定科目マスタ ON 精算データ.勘定科目コード = 勘定科目マスタ.勘定科目コード) " & _
                    "LEFT JOIN 税区分マスタ ON 勘定科目マスタ.税区分コード = 税区分マスタ.税区分コード) " & _
                    "LEFT JOIN 勘定科目補助マスタ " & _
                    "ON (精算データ.勘定科目コード = 勘定科目補助マスタ.勘定科目コード) " & _
                    "AND (精算データ.補助勘定科目コード = 勘定科目補助マスタ.補助勘定科目コード) " & _
                    "WHERE (精算日 >= """ & KeyFromAdjustDate & """ AND 精算日 <= """ & KeyToAdjustDate & """ )" & _
                    "AND (精算区分 = ""出金"" Or 精算区分 = ""入金"") "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParAdjust(CInt(i))

                'レコードが取得できた時の処理
                '精算コード
                ParAdjust(i).sAdjustCode = CLng(pDataReader("精算コード"))
                '精算区分
                ParAdjust(i).sAdjustClass = pDataReader("精算区分").ToString
                '精算日
                ParAdjust(i).sAdjustDate = pDataReader("精算日").ToString
                '金額
                ParAdjust(i).sTotalPrice = CLng(pDataReader("金額"))
                '勘定科目コード
                ParAdjust(i).sAccountCode = CInt(pDataReader("勘定科目コード"))
                '勘定科目名称
                ParAdjust(i).sAccountName = pDataReader("勘定科目名称").ToString
                '税区分名称
                ParAdjust(i).sTaxClassName = pDataReader("税区分名称").ToString
                '補助勘定科目コード
                ParAdjust(i).sSubAccountCode = CInt(pDataReader("補助勘定科目コード"))
                '補助勘定科目名称
                ParAdjust(i).sSubAccountName = pDataReader("補助勘定科目名称").ToString
                'レジ入金金額
                ParAdjust(i).sDTotalPrice = CLng(pDataReader("レジ入金金額"))
                '既レジ入金金額()
                ParAdjust(i).sAlreadyDTotalPrice = CLng(pDataReader("既レジ入金金額"))
                'D10000円
                ParAdjust(i).sD10000Yen = CInt(pDataReader("D10000円"))
                'D5000円
                ParAdjust(i).sD5000Yen = CInt(pDataReader("D5000円"))
                'D1000円
                ParAdjust(i).sD1000Yen = CInt(pDataReader("D1000円"))
                'D500円
                ParAdjust(i).sD500Yen = CInt(pDataReader("D500円"))
                'D100円
                ParAdjust(i).sD100Yen = CInt(pDataReader("D100円"))
                'D50円
                ParAdjust(i).sD50Yen = CInt(pDataReader("D50円"))
                'D10円
                ParAdjust(i).sD10Yen = CInt(pDataReader("D10円"))
                'D5円
                ParAdjust(i).sD5Yen = CInt(pDataReader("D5円"))
                'D1円
                ParAdjust(i).sD1Yen = CInt(pDataReader("D1円"))

                '金庫入金金額
                ParAdjust(i).sKTotalPrice = CLng(pDataReader("金庫入金金額"))
                'D10000円
                ParAdjust(i).sK10000Yen = CInt(pDataReader("K10000円"))
                'K5000円
                ParAdjust(i).sK5000Yen = CInt(pDataReader("K5000円"))
                'K1000円
                ParAdjust(i).sK1000Yen = CInt(pDataReader("K1000円"))
                'K500円
                ParAdjust(i).sK500Yen = CInt(pDataReader("K500円"))
                'K100円
                ParAdjust(i).sK100Yen = CInt(pDataReader("K100円"))
                'K50円
                ParAdjust(i).sK50Yen = CInt(pDataReader("K50円"))
                'K10円
                ParAdjust(i).sK10Yen = CInt(pDataReader("K10円"))
                'K5円
                ParAdjust(i).sK5Yen = CInt(pDataReader("K5円"))
                'K1円
                ParAdjust(i).sK1Yen = CInt(pDataReader("K1円"))

                '締め日
                'ParAdjust(i).sCloseDate = pDataReader("月次締日").ToString

                '精算担当者コード
                ParAdjust(i).sAdjustStaffCode = pDataReader("精算担当者コード").ToString

                '登録日
                ParAdjust(i).sCreateDate = pDataReader("登録日").ToString
                '登録日時
                ParAdjust(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                ParAdjust(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新日時
                ParAdjust(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getBetweenAdjust = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getBetweenAdjust)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：精算データから最終の精算時の精算番号を取得する関数
    '　引数：ParAdjust 取得データセット用バッファ
    '　戻値：精算コード
    '----------------------------------------------------------------------
    Public Function getBeforeAdjust(ByVal KeyAdjustCode As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim StrSelect As String

        Try
            StrSelect = "SELECT * FROM 精算データ WHERE 精算コード < @AdjustCode " & _
                        "AND 精算区分 = ""精算"" " & _
                        "ORDER BY 精算コード DESC"

            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '精算コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@AdjustCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@AdjustCode").Value = KeyAdjustCode

            ''検索対象Min精算コード指定
            'If MinAdjustCode <> Nothing Then
            '    pCommand.Parameters.Add _
            '        (New OleDb.OleDbParameter("@MinAdjustCode", OleDb.OleDbType.Numeric, 10))
            '    pCommand.Parameters("@MinAdjustCode").Value = MinAdjustCode
            'End If

            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() Then
                getBeforeAdjust = CLng(pDataReader("精算コード"))
            Else
                getBeforeAdjust = -1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getBeforeAdjust)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：精算データから最終の精算時の精算番号を取得する関数
    '　引数：ParAdjust 取得データセット用バッファ
    '　戻値：精算コード
    '----------------------------------------------------------------------
    Public Function getAfterAdjust(ByVal KeyAdjustCode As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim StrSelect As String

        Try
            StrSelect = "SELECT * FROM 精算データ WHERE 精算コード > @AdjustCode " & _
                        "AND 精算区分 = ""レジ入金"" " & _
                        "ORDER BY 精算コード "

            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '精算コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@AdjustCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@AdjustCode").Value = KeyAdjustCode

            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() Then
                getAfterAdjust = CLng(pDataReader("精算コード")) - 1
            Else
                pDataReader.Close()
                StrSelect = "SELECT Max(精算コード) AS 最終精算コード FROM 精算データ"
                pCommand.CommandText = StrSelect
                pDataReader = pCommand.ExecuteReader()

                If pDataReader.Read() Then
                    getAfterAdjust = CLng(pDataReader("最終精算コード"))
                Else
                    getAfterAdjust = -1
                End If
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.getAfterAdjust)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：in cSubAdjustオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertAdjust(ByRef parAdjust As cStructureLib.sAdjust, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsertAdjust As String

        Try

            'SQL文の設定
            strInsertAdjust = "INSERT INTO 精算データ" & _
            "( 精算コード, 精算区分, 精算日, 金額, 勘定科目コード, 補助勘定科目コード, " & _
            "レジ入金金額, 既レジ入金金額, D10000円, D5000円, D1000円, D500円, D100円, D50円, D10円, D5円, D1円, " & _
            "金庫入金金額, K10000円, K5000円, K1000円, K500円, K100円, K50円, K10円, K5円, K1円, " & _
            "精算担当者コード, 登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
            "VALUES ( " & _
                parAdjust.sAdjustCode & ", " & _
                """" & parAdjust.sAdjustClass & """, " & _
                "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                parAdjust.sTotalPrice & ", " & _
                parAdjust.sAccountCode & ", " & _
                parAdjust.sSubAccountCode & ", " & _
                parAdjust.sDTotalPrice & ", " & _
                parAdjust.sAlreadyDTotalPrice & ", " & _
                parAdjust.sD10000Yen & ", " & _
                parAdjust.sD5000Yen & ", " & _
                parAdjust.sD1000Yen & ", " & _
                parAdjust.sD500Yen & ", " & _
                parAdjust.sD100Yen & ", " & _
                parAdjust.sD50Yen & ", " & _
                parAdjust.sD10Yen & ", " & _
                parAdjust.sD5Yen & ", " & _
                parAdjust.sD1Yen & ", " & _
                parAdjust.sKTotalPrice & ", " & _
                parAdjust.sK10000Yen & ", " & _
                parAdjust.sK5000Yen & ", " & _
                parAdjust.sK1000Yen & ", " & _
                parAdjust.sK500Yen & ", " & _
                parAdjust.sK100Yen & ", " & _
                parAdjust.sK50Yen & ", " & _
                parAdjust.sK10Yen & ", " & _
                parAdjust.sK5Yen & ", " & _
                parAdjust.sK1Yen & ", " & _
                """" & parAdjust.sAdjustStaffCode & """, " & _
                "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                "FORMAT(NOW, ""hh:nn:ss""), " & _
                "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                "FORMAT(NOW, ""hh:nn:ss"")) "

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertAdjust

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            insertAdjust = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.insertAdjust)", Nothing, Nothing, oExcept.ToString)
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
    Public Function readMaxAdjustCode(ByVal KeyAdjustClass As String, _
                                        ByVal KeyCloseDate As String, _
                                        ByVal KeyOperetor As String, _
                                        ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT 精算コード FROM 精算データ "

        'パラメータ数のカウント
        pc = 0
        If KeyAdjustClass <> Nothing Then
            pc = pc Or 1
        End If
        If KeyCloseDate <> Nothing Then
            pc = pc Or 2
        End If

        'パラメータ指定がある場合
        If pc > 0 Then
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
                        strSelect = strSelect & "精算区分=""" & KeyAdjustClass & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "精算日" & KeyOperetor & """" & KeyCloseDate & """ "
                        scnt = scnt + 1

                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 精算コード DESC"

        Try
            pCommand.CommandText = strSelect

            '精算データから該当MAX取引IDのレコード読込 
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("精算コード")) Then
                    readMaxAdjustCode = 0
                Else
                    readMaxAdjustCode = CLng(pDataReader("精算コード"))
                End If
            Else
                readMaxAdjustCode = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.readMaxAdjustCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引明細テーブルから該当レコードを削除するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteAdjust(ByVal KetAdjustCode As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strDeleteAdjust As String

        Try

            'SQL文の設定

            strDeleteAdjust = "DELETE * FROM 精算データ " & _
                            "WHERE 精算コード=@AdjustCode"


            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteAdjust

            '***********************
            '   パラメータの設定
            '***********************

            '精算コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AdjustCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@AdjustCode").Value = KetAdjustCode

            '取引テーブル挿入処理実行
            deleteAdjust = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.deleteAdjust)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：取引明細テーブルの該当レコードの精算コードを変更するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateAdjustCode(ByVal KetFromAdjustCode As Long, ByVal KetToAdjustCode As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strUpdate As String

        Try

            'SQL文の設定

            strUpdate = "UPDATE 精算データ SET " & _
                            "精算コード=" & KetToAdjustCode & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 精算コード=" & KetFromAdjustCode

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateAdjustCode = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.updateAdjustCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：精算データの締め日未入力レコードに指定締め日を設定
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateDayCloseDate(ByVal KeyAdjustCode As Long, ByVal KeyCloseDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strUpdate As String

        Try

            'SQL文の設定

            strUpdate = "UPDATE 精算データ SET " & _
                            "精算日=""" & KeyCloseDate & """ " & _
                            "WHERE 精算コード= " & KeyAdjustCode

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateDayCloseDate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.updateDayCloseDate)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：精算データの締め日未入力レコードに指定締め日を設定
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateMonthCloseDate(ByVal KeyCloseDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strUpdate As String

        Try

            'SQL文の設定

            strUpdate = "UPDATE 精算データ SET " & _
                            "月次締日=" & KeyCloseDate & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 締め日="""""

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            updateMonthCloseDate = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataAdjustDBIO.updateMonthCloseDate)", Nothing, Nothing, oExcept.ToString)
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
