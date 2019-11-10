
Public Class cMstBomDBIO
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
    '　機能：構成マスタから該当レコードを取得する関数
    '　引数：Byref parBom()　：データセットバッファ（sBom Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Bom_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Bom_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getFullBom(ByRef parViewBom() As cStructureLib.sViewBom, _
                               ByVal KeyStructureCode As Integer, _
                               ByVal KeyProductCode As String, _
                               ByVal KeyHiearchyNo As Integer, _
                               ByVal KeyProductClass As Integer, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        strSelect = ""

        Try

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT " & _
                            "構成マスタ.構成コード, " & _
                            "構成マスタ.ノード番号, " & _
                            "構成マスタ.階層番号, " & _
                            "構成マスタ.親ノード番号, " & _
                            "構成マスタ.商品コード, " & _
                            "商品マスタ.商品種別, " & _
                            "商品マスタ.商品名称, " & _
                            "商品マスタ.オプション1, " & _
                            "商品マスタ.オプション2, " & _
                            "商品マスタ.オプション3, " & _
                            "商品マスタ.オプション4, " & _
                            "商品マスタ.オプション5, " & _
                            "商品マスタ.定価 " & _
                       "FROM " & _
                            "構成マスタ LEFT JOIN 商品マスタ " & _
                            "ON 構成マスタ.商品コード = 商品マスタ.商品コード "

            'パラメータ数のカウント
            pc = 0
            If KeyStructureCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyProductCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyHiearchyNo <> 0 Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeyProductClass <> Nothing Then
                maxpc = 8
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
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "構成マスタ.構成コード = " & KeyStructureCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "構成マスタ.商品コード = """ & KeyProductCode & """ "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "構成マスタ.階層番号 = " & KeyHiearchyNo & " "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品種別 = " & KeyProductClass & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            strSelect = strSelect & "ORDER BY 構成マスタ.構成コード, 構成マスタ.ノード番号 "
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()


                ReDim Preserve parViewBom(i)

                '構成コード
                If IsDBNull(pDataReader("構成コード")) = True Then
                    parViewBom(i).sStructureCode = 0
                Else
                    parViewBom(i).sStructureCode = CInt(pDataReader("構成コード"))
                End If
                'ノード番号
                If IsDBNull(pDataReader("ノード番号")) = True Then
                    parViewBom(i).sNodeNo = 0
                Else
                    parViewBom(i).sNodeNo = CInt(pDataReader("ノード番号"))
                End If
                '階層番号
                If IsDBNull(pDataReader("階層番号")) = True Then
                    parViewBom(i).sHiearchyNo = 0
                Else
                    parViewBom(i).sHiearchyNo = CInt(pDataReader("階層番号"))
                End If
                '親ノード番号
                If IsDBNull(pDataReader("親ノード番号")) = True Then
                    parViewBom(i).sParentNodeNo = 0
                Else
                    parViewBom(i).sParentNodeNo = CInt(pDataReader("親ノード番号"))
                End If
                '商品コード
                parViewBom(i).sProductCode = pDataReader("商品コード").ToString
                '商品種別
                If IsDBNull(pDataReader("商品種別")) = True Then
                    parViewBom(i).sProductClass = 0
                Else
                    parViewBom(i).sProductClass = CInt(pDataReader("商品種別"))
                End If
                '商品名称
                parViewBom(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parViewBom(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parViewBom(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parViewBom(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parViewBom(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parViewBom(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parViewBom(i).sListPrice = 0
                Else
                    parViewBom(i).sListPrice = CLng(pDataReader("定価"))
                End If

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getFullBom = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBomDBIO.getBomPrice)", Nothing, Nothing, oExcept.ToString)
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

    Public Function readMaxBomCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        strSelect = "SELECT 構成コード FROM 構成マスタ ORDER BY 構成コード DESC"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("構成コード")) Then
                    readMaxBomCode = 0
                Else
                    '取引コードインクリメント
                    If CLng(pDataReader("構成コード")) < 999999999 Then
                        readMaxBomCode = CLng(pDataReader("構成コード"))
                    Else
                        readMaxBomCode = 1
                    End If
                End If
            Else
                readMaxBomCode = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataBomDBIO.readMaxBomCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertBomMst(ByRef parBom() As cStructureLib.sBom, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 構成マスタ ( " & _
                        "構成コード, " & _
                        "ノード番号, " & _
                        "階層番号, " & _
                        "親ノード番号, " & _
                        "商品コード, " & _
                        "登録日, " & _
                        "登録時間, " & _
                        "最終更新日, " & _
                        "最終更新時間 " & _
                    ") VALUES (" & _
                        "@StructureCode, " & _
                        "@sNodeNo, " & _
                        "@sHiearchyNo, " & _
                        "@sParentNodeNo, " & _
                        "@ProductCode, " & _
                        "@CreateDate, " & _
                        "@CreateTime, " & _
                        "@UpdateDate, " & _
                        "@UpdateTime " & _
                    ")"

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '構成コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StructureCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@StructureCode").Value = parBom(0).sStructureCode
            'コード番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NodeNo", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@NodeNo").Value = parBom(0).sNodeNo
            '階層番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@HiearchyNo", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@HiearchyNo").Value = parBom(0).sHiearchyNo
            '親コード番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ParentNodeNo", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ParentNodeNo").Value = parBom(0).sParentNodeNo
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parBom(0).sProductCode
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

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertBomMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBomDBIO.insertBomMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：構成マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateBomMst(ByRef parBom() As cStructureLib.sBom, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 構成マスタ SET " & _
                            "構成コード=" & parBom(0).sStructureCode & ", " & _
                            "ノード番号=" & parBom(0).sNodeNo & ", " & _
                            "階層番号=" & parBom(0).sHiearchyNo & ", " & _
                            "親ノード番号=" & parBom(0).sParentNodeNo & ", " & _
                            "商品コード=""" & parBom(0).sProductCode.ToString & """, " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE 構成コード=" & parBom(0).sStructureCode & " " & _
                            "AND ノード番号 = " & parBom(0).sNodeNo & " "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '構成マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateBomMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBomDBIO.updateBomMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：構成マスタの１レコードを削除するメソッド
    '　引数：商品コード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteBom(ByVal KeyBomStructureCode As integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 構成マスタ WHERE 構成コード=" & KeyBomStructureCode & " "

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '構成マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteBom = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstBomDBIO.deleteBom)", Nothing, Nothing, oExcept.ToString)
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
    '2015/07/07
    '及川和彦
    '商品コードで絞込
    'FROM
    '----------------------------------------------------

    Public Function getBomSubProduct(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String

        Try
            strSelect = ""
            strSelect = "SELECT COUNT(*) AS CNT FROM 構成マスタ WHERE 商品コード = """ & KeyProductCode & """"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()

            getBomSubProduct = CLng(pDataReader("CNT"))

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
