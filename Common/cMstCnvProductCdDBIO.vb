
Public Class cMstCnvProductCdDBIO
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
    '　機能：商品コード変換マスタから１レコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteCnvProductCdMst(ByRef parCnvProductCd() As cStructureLib.sViewCnvProductCd, ByVal index As Long, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDeletePrdMst As String = "DELETE FROM 商品コード変換マスタ " + _
                                        "WHERE チャネルコード  =" & parCnvProductCd(index).sChannelCode & " " & _
                                        "AND チャネル商品コード= """ & parCnvProductCd(index).sChannelProductCode & """ " & _
                                        "AND チャネル商品名称= """ & parCnvProductCd(index).sChannelProductName & """ "

        If parCnvProductCd(index).sChannelOptionNameAndValue IsNot Nothing Then
            strDeletePrdMst &= " AND チャネルオプション= """ & parCnvProductCd(index).sChannelOptionNameAndValue & """ "
        End If


        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            pCommand.CommandText = strDeletePrdMst

            '商品マスタ削除SQL文実行
            Dim count As Integer

            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                'レコードの削除が成功した時の処理
                Return True
            Else
                '削除するレコードがなかった時の処理
                Return False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.deleteCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品コード変換マスタから１レコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteCnvProductCdMst(ByRef parCnvProductCd() As cStructureLib.sViewCnvProductCd, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        deleteCnvProductCdMst(parCnvProductCd, 0, Tran)
    End Function

    '-------------------------------------------------------------------------------
    '　機能：商品コード変換マスタから該当レコードを取得する関数
    '　引数：Byref parCnvProductCd()　：データセットバッファ（sCnvProductCd Structureの配列）
    '　　　：KeyString　：キー情報
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getCnvProductCdMst(ByRef parCnvProductCd() As cStructureLib.sViewCnvProductCd, _
                                    ByVal KeyChannelName As String, _
                                    ByVal KeyChannelProductCode As String, _
                                    ByVal KeyChannelProductName As String, _
                                    ByVal KeyProductCode As String, _
                                    ByVal KeyProductCodeIsNull As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT  商品コード変換マスタ.チャネルコード as チャネルコード, " & _
                            "チャネルマスタ.チャネル名称 as チャネル名称, " & _
                            "商品コード変換マスタ.チャネル商品コード as チャネル商品コード, " & _
                            "商品コード変換マスタ.チャネル商品名称 as チャネル商品名称, " & _
                            "商品コード変換マスタ.チャネルオプション as チャネルオプション, " & _
                            "商品コード変換マスタ.商品コード as 商品コード, " & _
                            "商品コード変換マスタ.登録日 as 登録日, " & _
                            "商品コード変換マスタ.登録時間 as 登録時間, " & _
                            "商品コード変換マスタ.最終更新日 as 最終更新日, " & _
                            "商品コード変換マスタ.最終更新時間 as 最終更新時間 " & _
                    "FROM 商品コード変換マスタ INNER JOIN チャネルマスタ " & _
                    "ON 商品コード変換マスタ.チャネルコード = チャネルマスタ.チャネルコード "

        'パラメータ数のカウント
        pc = 0
        If KeyChannelName <> "" Then
            pc = pc Or 1
        End If
        If KeyChannelProductCode <> "" Then
            pc = pc Or 2
        End If
        If KeyChannelProductName <> "" Then
            pc = pc Or 4
        End If
        If KeyProductCode <> "" Then
            pc = pc Or 8
        End If
        If KeyProductCodeIsNull <> "" AndAlso KeyProductCodeIsNull = "True" Then
            pc = pc Or 16
        End If

        'パラメータ指定がある場合
        If 31 And pc > 0 Then
            i = 1
            scnt = 0
            While i <= 16
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルマスタ.チャネル名称 Like ""%" & KeyChannelName & "%"" "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード変換マスタ.チャネル商品コード Like ""%" & KeyChannelProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード変換マスタ.チャネル商品名称 Like ""%" & KeyChannelProductName & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード変換マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード変換マスタ.商品コード = '' "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parCnvProductCd(i)
                parCnvProductCd(i).sIsDataChanged = False
                'parCnvProductCd(i).sID = pDataReader("ID")
                parCnvProductCd(i).sChannelCode = pDataReader("チャネルコード")
                parCnvProductCd(i).sChannelName = pDataReader("チャネル名称")
                parCnvProductCd(i).sChannelProductCode = pDataReader("チャネル商品コード")
                parCnvProductCd(i).sChannelProductName = pDataReader("チャネル商品名称")
                parCnvProductCd(i).sChannelOptionNameAndValue = _
                    IIf(IsDBNull(pDataReader("チャネルオプション")), Nothing, pDataReader("チャネルオプション"))
                parCnvProductCd(i).sProductCode = _
                    IIf(IsDBNull(pDataReader("商品コード")), Nothing, pDataReader("商品コード"))
                parCnvProductCd(i).sCreateDate = pDataReader("登録日")
                parCnvProductCd(i).sCreateTime = pDataReader("登録時間")
                parCnvProductCd(i).sUpdateDate = pDataReader("最終更新日")
                parCnvProductCd(i).sUpdateTime = pDataReader("最終更新時間")

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getCnvProductCdMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.getCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品コード変換マスタに１レコードを登録するメソッド
    '　引数：Byref parCnvProductCd()　：データセットバッファ（sCnvProductCd Structureの配列）
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertCnvProductCdMst(ByRef parCnvProductCd As cStructureLib.sViewPenddingCnvProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 商品コード変換マスタ (" & _
                                    "チャネルコード, " & _
                                    "チャネル商品コード, " & _
                                    "チャネル商品名称, " & _
                                    "チャネルオプション, " & _
                                    "商品コード, " & _
                                    "登録日, " & _
                                    "登録時間, " & _
                                    "最終更新日, " & _
                                    "最終更新時間 " & _
                                ") VALUES (" & _
                                    parCnvProductCd.sChannelCode.ToString & "," & _
                                    """" & parCnvProductCd.sChannelProductCode & """," & _
                                    """" & parCnvProductCd.sChannelProductName.Replace("""", """""") & """," & _
                                    """" & parCnvProductCd.sChannelOptionNameAndValue.Replace("""", """""") & """," & _
                                    """" & parCnvProductCd.sProductCode & """," & _
                                    """" & String.Format("{0:yyyy/MM/dd}", Now) & """," & _
                                    """" & String.Format("{0:HH:mm:ss}", Now) & """," & _
                                    """" & String.Format("{0:yyyy/MM/dd}", Now) & """," & _
                                    """" & String.Format("{0:HH:mm:ss}", Now) & """" & _
                                ") "

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertCnvProductCdMst = 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.insertCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品コード変換マスタに１レコードを登録するメソッド
    '　引数：Byref parCnvProductCd()　：データセットバッファ（sCnvProductCd Structureの配列）
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteCnvProductCdMst(ByRef parCnvProductCd As cStructureLib.sViewPenddingCnvProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE FROM 商品コード変換マスタ WHERE " & _
                        "チャネルコード = " & parCnvProductCd.sChannelCode & _
                        "AND チャネル商品コード = """ & parCnvProductCd.sChannelProductCode & """ " & _
                        "AND チャネル商品名称 =  """ & parCnvProductCd.sChannelProductName & """ " & _
                        "AND チャネルオプション =  """ & parCnvProductCd.sChannelOptionNameAndValue & """ " & _
                        "AND 商品コード = """" OR 商品コード IS NULL "

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strDelete

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteCnvProductCdMst = 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.deleteCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品コード変換マスタの１レコードを更新するメソッド
    '　引数：Byref parCnvProductCd()　：データセットバッファ（sCnvProductCd Structureの配列）
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateCnvProductCdMst(ByRef parCnvProductCd As cStructureLib.sViewPenddingCnvProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 商品コード変換マスタ SET " & _
                            "商品コード=""" & parCnvProductCd.sProductCode & """," & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """," & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """" & _
                            "WHERE チャネルコード =" & parCnvProductCd.sChannelCode & " " & _
                            "AND チャネル商品コード = """ & parCnvProductCd.sChannelProductCode & """" & _
                            "AND チャネル商品名称 = """ & parCnvProductCd.sChannelProductName & """"
        If parCnvProductCd.sChannelOptionNameAndValue IsNot Nothing Then
            strUpdate &= " AND チャネルオプション = """ & parCnvProductCd.sChannelOptionNameAndValue & """"
        End If

        Try

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateCnvProductCdMst = 1

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.updateCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：受注情報明細データTMPから商品コード変換マスタにレコードを登録するメソッド
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function importCnvProductCdMst(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim rConvBuff As cStructureLib.sViewPenddingCnvProduct
        Dim i As Integer
        Dim sDataReader As OleDb.OleDbDataReader

        sDataReader = Nothing

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'SQL文の設定
        strSelect = "SELECT " & _
                        "受注情報データTMP.チャネルコード AS チャネルコード, " & _
                        "受注情報明細データTMP.チャネル商品コード AS チャネル商品コード, " & _
                        "受注情報明細データTMP.チャネル商品名称 AS チャネル商品名称, " & _
                        "受注情報明細データTMP.チャネルオプション AS チャネルオプション " & _
                    "FROM " & _
                        "( " & _
                            "受注情報データTMP LEFT JOIN 受注情報明細データTMP " & _
                            "ON 受注情報データTMP.受注コード = 受注情報明細データTMP.受注コード) " & _
                            "LEFT JOIN 商品コード変換マスタ " & _
                            "ON (受注情報明細データTMP.チャネルオプション = 商品コード変換マスタ.チャネルオプション) " & _
                            "AND (受注情報明細データTMP.チャネル商品名称 = 商品コード変換マスタ.チャネル商品名称) " & _
                            "AND (受注情報明細データTMP.チャネル商品コード = 商品コード変換マスタ.チャネル商品コード) " & _
                    "WHERE " & _
                        "((Not (受注情報明細データTMP.チャネル商品コード)="""") " & _
                        "AND ((商品コード変換マスタ.商品コード) Is Null)) "
        Try

            'SQL文の設定
            pCommand.CommandText = strSelect
            sDataReader = pCommand.ExecuteReader()

            i = 0
            rConvBuff = Nothing

            While sDataReader.Read()
                rConvBuff.sChannelCode = CInt(sDataReader("チャネルコード"))
                rConvBuff.sChannelProductCode = sDataReader("チャネル商品コード")
                rConvBuff.sChannelProductName = sDataReader("チャネル商品名称")
                rConvBuff.sChannelOptionNameAndValue = sDataReader("チャネルオプション")
                rConvBuff.sProductCode = ""

                insertCnvProductCdMst(rConvBuff, Tran)
                i = i + 1
            End While

            importCnvProductCdMst = i

            '"INSERT INTO 商品コード変換マスタ ( " & _
            '"    チャネルコード, " & _
            '"    チャネル商品コード, " & _
            '"    チャネル商品名称, " & _
            '"    チャネルオプション, " & _
            '"    商品コード, " & _
            '"    登録日, " & _
            '"    登録時間, " & _
            '"    最終更新日, " & _
            '"    最終更新時間 " & _
            '"    ) " & _
            '"SELECT  受注情報データTMP.チャネルコード         AS  チャネルコード, " & _
            '"        受注情報明細データTMP.チャネル商品コード AS  チャネル商品コード, " & _
            '"        受注情報明細データTMP.チャネル商品名称   AS  チャネル商品名称, " & _
            '"        受注情報明細データTMP.チャネルオプション AS  チャネルオプション, " & _
            '"        ''                                       AS  商品コード, " & _
            '"        Format(Now(), 'YYYY/MM/DD')              AS  登録日, " & _
            '"        Format(Now(), 'HH:MM:SS')                AS  登録時間, " & _
            '"        Format(Now(), 'YYYY/MM/DD')              AS  最終更新日, " & _
            '"        Format(Now(), 'HH:MM:SS')                AS  最終更新時間 " & _
            '"FROM    受注情報データTMP, 受注情報明細データTMP " & _
            '"WHERE   受注情報データTMP.受注コード = 受注情報明細データTMP.受注コード " & _
            '"AND NOT EXISTS( " & _
            '    "SELECT 1 FROM 商品コード変換マスタ " & _
            '    "WHERE 商品コード変換マスタ.チャネルコード   = 受注情報データTMP.チャネルコード " & _
            '    "AND 商品コード変換マスタ.チャネル商品コード = 受注情報明細データTMP.チャネル商品コード " & _
            '    "AND 商品コード変換マスタ.チャネル商品名称   = 受注情報明細データTMP.チャネル商品名称 " & _
            '    "AND ( " & _
            '    "        商品コード変換マスタ.チャネルオプション = 受注情報明細データTMP.チャネルオプション " & _
            '    "    OR " & _
            '    "        (" & _
            '    "            商品コード変換マスタ.チャネルオプション IS NULL " & _
            '    "        AND " & _
            '    "            受注情報明細データTMP.チャネルオプション IS NULL" & _
            '    "        ) " & _
            '    "    ) " & _
            '    ") " & _
            '"GROUP BY 受注情報データTMP.チャネルコード, 受注情報明細データTMP.チャネル商品コード, " & _
            '"         受注情報明細データTMP.チャネル商品名称, 受注情報明細データTMP.チャネルオプション "



        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.importCnvProductCdMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                sDataReader.Close()
                pDataReader.Close()
            End If
        End Try

    End Function
    '-------------------------------------------------------------------------------
    '　機能：受注情報データTMPから該当レコードを取得する関数
    '　引数：Byref parRequest()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Request_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getPenddingCnvProduct(ByRef parPendding() As cStructureLib.sViewPenddingCnvProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT DISTINCT " & _
                        "商品コード変換マスタ.商品コード AS 商品コード, " & _
                        "チャネルマスタ.チャネルコード AS チャネルコード, " & _
                        "チャネルマスタ.チャネル名称  AS チャネル名称, " & _
                        "受注情報明細データTMP.チャネル商品コード AS チャネル商品コード, " & _
                        "受注情報明細データTMP.チャネル商品名称 AS チャネル商品名称, " & _
                        "受注情報明細データTMP.チャネルオプション AS チャネルオプション, " & _
                        "商品コード変換マスタ.チャネル商品コード AS CHGチャネル商品コード, " & _
                        "受注情報明細データTMP.商品コード AS TMP商品コード " & _
                    "FROM " & _
                        "( " & _
                            "(受注情報データTMP LEFT JOIN 受注情報明細データTMP ON 受注情報データTMP.受注コード = 受注情報明細データTMP.受注コード) " & _
                            "LEFT JOIN 商品コード変換マスタ ON 受注情報明細データTMP.チャネル商品コード = 商品コード変換マスタ.チャネル商品コード " & _
                        ") " & _
                        "LEFT JOIN チャネルマスタ ON 受注情報データTMP.チャネルコード = チャネルマスタ.チャネルコード " & _
                    "WHERE " & _
                        "( " & _
                            "((商品コード変換マスタ.商品コード Is Null) Or (商品コード変換マスタ.商品コード = """")) " & _
                            "AND ((受注情報明細データTMP.チャネル商品コード) Not Like """"))"

        'strSelect = "SELECT DISTINCT " & _
        '                "商品コード変換マスタ.商品コード              AS 商品コード,         " & _
        '                "商品コード変換マスタ.チャネルコード          AS チャネルコード,     " & _
        '                "チャネルマスタ.チャネル名称                  AS チャネル名称,       " & _
        '                "商品コード変換マスタ.チャネル商品コード      AS チャネル商品コード, " & _
        '                "商品コード変換マスタ.チャネル商品名称        AS チャネル商品名称,   " & _
        '                "商品コード変換マスタ.チャネルオプション      AS チャネルオプション  " & _
        '            "FROM  受注情報データTMP, チャネルマスタ, 受注情報明細データTMP, 商品コード変換マスタ " & _
        '            "WHERE チャネルマスタ.チャネルコード           = 受注情報データTMP.チャネルコード " & _
        '            "AND   受注情報明細データTMP.受注コード        = 受注情報データTMP.受注コード " & _
        '            "AND   商品コード変換マスタ.チャネルコード     = 受注情報データTMP.チャネルコード " & _
        '            "AND   商品コード変換マスタ.チャネル商品コード = 受注情報明細データTMP.チャネル商品コード " & _
        '            "AND   商品コード変換マスタ.チャネル商品名称   = 受注情報明細データTMP.チャネル商品名称 " & _
        '            "AND   ( " & _
        '            "          (商品コード変換マスタ.チャネルオプション = 受注情報明細データTMP.チャネルオプション) " & _
        '            "      OR " & _
        '            "          ((商品コード変換マスタ.チャネルオプション IS NULL) AND (受注情報明細データTMP.チャネルオプション IS NULL)) " & _
        '            "      ) " & _
        '            "AND (商品コード変換マスタ.商品コード) Is Null "
        '                    "AND   ( " & _
        '                        "(商品コード変換マスタ.商品コード IS NULL) " & _
        '                        "OR (商品コード変換マスタ.商品コード = """") " & _
        '                   ") "

        Try
            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()
            i = 0
            While pDataReader.Read()

                ReDim Preserve parPendding(i)

                '商品コード
                parPendding(i).sProductCode = pDataReader("商品コード").ToString

                'チャネルコード
                parPendding(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                'チャネル名称
                parPendding(i).sChannelName = pDataReader("チャネル名称").ToString

                'チャネル商品コード
                parPendding(i).sChannelProductCode = pDataReader("チャネル商品コード").ToString

                'チャネル商品名称
                parPendding(i).sChannelProductName = pDataReader("チャネル商品名称").ToString

                'チャネルオプシュン
                parPendding(i).sChannelOptionNameAndValue = pDataReader("チャネルオプション").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getPenddingCnvProduct = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCnvProductCdDBIO.getPenddingCnvProduct)", Nothing, Nothing, oExcept.ToString)
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
