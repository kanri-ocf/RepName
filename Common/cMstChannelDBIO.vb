Public Class cMstChannelDBIO

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
    '　機能：チャネルマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getChannelMst(ByRef parChannel() As cStructureLib.sChannel, _
                                  ByVal KeyChannelCode As Integer, _
                                  ByVal KeyChannelClass As Integer, _
                                  ByVal KeyChannelName As String, _
                                  ByVal KeysSaleRegist As Boolean, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim mpc As Integer

        strSelect = "SELECT * FROM チャネルマスタ "

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        'パラメータ数のカウント
        pc = 0
        mpc = 0
        If KeyChannelCode <> Nothing Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyChannelClass <> Nothing Then
            pc = pc Or 2
            mpc = 2
        End If
        If KeyChannelName <> Nothing Then
            pc = pc Or 4
            mpc = 4
        End If
        If KeysSaleRegist <> Nothing Then
            pc = pc Or 8
            mpc = 8
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            scnt = 0
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード = " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネル種別 = " & KeyChannelClass & " "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネル名称 Like ""%" & KeyChannelName & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "売上計上フラグ =" & KeysSaleRegist & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect + "ORDER BY レシート印刷フラグ, 売上計上フラグ "
        pCommand.CommandText = strSelect

        Try

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parChannel(CInt(i))

                'レコードが取得できた時の処理
                'チャネルコード
                parChannel(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                'チャネル名称
                parChannel(i).sChannelName = pDataReader("チャネル名称").ToString
                'チャネル種別
                parChannel(i).sChannelClass = CInt(pDataReader("チャネル種別"))
                'URL
                parChannel(i).sURL = pDataReader("URL").ToString
                'レシート印刷フラグ
                parChannel(i).sReceiptPrint = CBool(pDataReader("レシート印刷フラグ"))
                '売上計上フラグ
                parChannel(i).sSaleRegist = CBool(pDataReader("売上計上フラグ"))
                '注文データファイル有無
                parChannel(i).sRequestFileFlg = CBool(pDataReader("注文データファイル有無"))
                '注文明細データファイル有無
                parChannel(i).sRequestSubFileFlg = CBool(pDataReader("注文明細データファイル有無"))
                'CMSタイプ
                parChannel(i).sCMSType = CInt(pDataReader("CMSタイプ"))
                'OR受注コードフィールド名
                parChannel(i).sORRequestCodeFieldName = pDataReader("OR受注コード名称").ToString
                '登録日
                parChannel(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parChannel(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parChannel(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parChannel(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getChannelMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.getChannelMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：チャネルマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function ExistCMSType(ByRef parChannel() As cStructureLib.sChannel, _
                                  ByVal KeyCMSType As Integer, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strSelect As String
        Dim i As Long

        strSelect = "SELECT * FROM チャネルマスタ WHERE CMSタイプ = " & KeyCMSType

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        pCommand.CommandText = strSelect

        Try

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parChannel(CInt(i))

                'レコードが取得できた時の処理
                'チャネルコード
                parChannel(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                'チャネル名称
                parChannel(i).sChannelName = pDataReader("チャネル名称").ToString
                'チャネル種別
                parChannel(i).sChannelClass = CInt(pDataReader("チャネル種別"))
                'URL
                parChannel(i).sURL = pDataReader("URL").ToString
                'レシート印刷フラグ
                parChannel(i).sReceiptPrint = CBool(pDataReader("レシート印刷フラグ"))
                '売上計上フラグ
                parChannel(i).sSaleRegist = CBool(pDataReader("売上計上フラグ"))
                '注文データファイル有無
                parChannel(i).sRequestFileFlg = CBool(pDataReader("注文データファイル有無"))
                '注文明細データファイル有無
                parChannel(i).sRequestSubFileFlg = CBool(pDataReader("注文明細データファイル有無"))
                'CMSタイプ
                parChannel(i).sCMSType = CInt(pDataReader("CMSタイプ"))
                'OR受注コードフィールド名
                parChannel(i).sORRequestCodeFieldName = pDataReader("OR受注コード名称").ToString
                '登録日
                parChannel(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parChannel(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parChannel(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parChannel(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            If i > 0 Then
                ExistCMSType = True
            Else
                ExistCMSType = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.ExistCMSType)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：チャネルマスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getNewChannelCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer
        Dim strSelect As String

        strSelect = "SELECT Max([チャネルコード]) AS 最終チャネルコード FROM チャネルマスタ "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()

            pDataReader.Read()

            If IsDBNull(pDataReader("最終チャネルコード")) Then
                getNewChannelCode = 1
            Else
                getNewChannelCode = CInt(pDataReader("最終チャネルコード")) + 1
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.getNewChannelCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function insertChannelMst(ByVal parChannel As cStructureLib.sChannel, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO チャネルマスタ ( " & _
                            "チャネルコード, " & _
                            "チャネル名称, " & _
                            "チャネル種別, " & _
                            "URL, " & _
                            "レシート印刷フラグ, " & _
                            "売上計上フラグ, " & _
                            "注文データファイル有無, " & _
                            "注文明細データファイル有無, " & _
                            "CMSタイプ, " & _
                            "OR受注コード名称, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@ChannelCode, " & _
                            "@ChannelName, " & _
                            "@ChannelClass, " & _
                            "@URL, " & _
                            "@ReceiptPrint, " & _
                            "@SaleRegist, " & _
                            "@RequestFileFlg, " & _
                            "@RequestSubFileFlg, " & _
                            "@CMSType, " & _
                            "@ORRequestCodeName, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelCode").Value = parChannel.sChannelCode
            'チャネル名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ChannelName").Value = parChannel.sChannelName
            'チャネル種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ChannelClass").Value = parChannel.sChannelClass
            'URL
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@URL", OleDb.OleDbType.Char, 255))
            pCommand.Parameters("@URL").Value = parChannel.sURL
            'レシート印刷フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReceiptPrint", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ReceiptPrint").Value = parChannel.sReceiptPrint
            '売上計上フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SaleRegist", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@SaleRegist").Value = parChannel.sSaleRegist
            '注文データファイル有無
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestFileFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@RequestFileFlg").Value = parChannel.sRequestFileFlg
            '注文明細データファイル有無
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestSubFileFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@RequestSubFileFlg").Value = parChannel.sRequestSubFileFlg
            'CMSタイプ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CMSType", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@CMSType").Value = parChannel.sCMSType
            'OR受注コード名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ORRequestCodeName", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@ORRequestCodeName").Value = parChannel.sORRequestCodeFieldName
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

            'チャネルマスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertChannelMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.insertChannelMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：チャネルマスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateChannelMst(ByVal parChannel As cStructureLib.sChannel, ByVal KeyChannelCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE チャネルマスタ SET " & _
                        "チャネルコード = " & parChannel.sChannelCode & ", " & _
                        "チャネル名称 = """ & parChannel.sChannelName & """, " & _
                        "チャネル種別 = " & parChannel.sChannelClass & ", " & _
                        "URL = """ & parChannel.sURL & """, " & _
                        "レシート印刷フラグ = " & parChannel.sReceiptPrint & ", " & _
                        "売上計上フラグ = " & parChannel.sSaleRegist & ", " & _
                        "注文データファイル有無 = " & parChannel.sRequestFileFlg & ", " & _
                        "注文明細データファイル有無 = " & parChannel.sRequestSubFileFlg & ", " & _
                        "CMSタイプ = " & parChannel.sCMSType & ", " & _
                        "OR受注コード名称 = """ & parChannel.sORRequestCodeFieldName & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE チャネルマスタ.チャネルコード= " & KeyChannelCode & " "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'チャネルマスタ更新SQL文実行
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.updateChannelMst)", Nothing, Nothing, oExcept.ToString)
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
    Public Function deleteChannelMst(ByVal KeyChannelCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE チャネルマスタ.チャネルコード FROM チャネルマスタ " & _
                        "WHERE チャネルマスタ.チャネルコード=" & KeyChannelCode & " "

            pCommand.CommandText = strDelete

            'チャネルマスタの削除処理実行
            deleteChannelMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.deleteChannelMst)", Nothing, Nothing, oExcept.ToString)
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
