
Public Class cMstDownloadColumnDBIO
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
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parDownloadColumn()　：データセットバッファ（sDownloadColumn Structureの配列）
    '　　　：KeyString　：キー情報（Mode=DownloadColumn_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（DownloadColumn_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getDownloadColumn(ByRef parDownload() As cStructureLib.sDownloadColumn, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyDataClass As Integer, _
                                    ByVal KeyColumnName As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT * FROM ダウンロードカラムマスタ " & _
                    "WHERE チャネルコード=" & KeyChannelCode & _
                    " AND データ種別=" & KeyDataClass
        If KeyColumnName = "" Then
            strSelect = strSelect & " AND DLカラム名称 Is Null"
        Else
            strSelect = strSelect & " AND DLカラム名称=""" & KeyColumnName & """"
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parDownload(i)

                'チャネルコード
                parDownload(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                'データ種別
                parDownload(i).sDataClass = CInt(pDataReader("データ種別"))

                'DBカラムNo
                parDownload(i).sDBColumnNo = CInt(pDataReader("DBカラムNo"))

                'DBカラム名称
                parDownload(i).sDBColumnName = pDataReader("DBカラム名称").ToString

                'DBカラムタイプ
                parDownload(i).sDBColumnType = CInt(pDataReader("DBカラムタイプ"))

                'DLカラムNo
                If IsDBNull(pDataReader("DLカラムNo")) Then
                    parDownload(i).sDLColumnNo = Nothing
                Else
                    parDownload(i).sDLColumnNo = CInt(pDataReader("DLカラムNo"))
                End If

                'DLカラム名称
                parDownload(i).sDLColumnName = pDataReader("DLカラム名称").ToString

                '適用
                parDownload(i).sDescription = pDataReader("適用").ToString

                'デリミタ
                parDownload(i).sDerimita = pDataReader("デリミタ").ToString

                '区画No
                parDownload(i).sSplitNo = CInt(pDataReader("区画No"))

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getDownloadColumn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDownloadColumnDBIO.getDownloadColumn)", Nothing, Nothing, oExcept.ToString)
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

    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parDownloadColumn()　：データセットバッファ（sDownloadColumn Structureの配列）
    '　　　：KeyString　：キー情報（Mode=DownloadColumn_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（DownloadColumn_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getDLColumn(ByRef parDownload() As cStructureLib.sDownloadColumn, _
                                    ByVal KeyChannelCode As Integer, _
                                    ByVal KeyDataClass As Integer, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT * FROM ダウンロードカラムマスタ " & _
                    "WHERE チャネルコード=" & KeyChannelCode & _
                    " AND データ種別=" & KeyDataClass & _
                    " AND DLカラムNo " & _
                    " AND DLカラムNo Is Not Null " & _
                    "ORDER BY DLカラムNo "
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parDownload(i)

                'チャネルコード
                parDownload(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                'データ種別
                parDownload(i).sDataClass = CInt(pDataReader("データ種別"))

                'DBカラムNo
                parDownload(i).sDBColumnNo = CInt(pDataReader("DBカラムNo"))

                'DBカラム名称
                parDownload(i).sDBColumnName = pDataReader("DBカラム名称").ToString

                'DBカラムタイプ
                parDownload(i).sDBColumnType = CInt(pDataReader("DBカラムタイプ"))

                'DLカラムNo
                If IsDBNull(pDataReader("DLカラムNo")) Then
                    parDownload(i).sDLColumnNo = Nothing
                Else
                    parDownload(i).sDLColumnNo = CInt(pDataReader("DLカラムNo"))
                End If

                'DLカラム名称
                parDownload(i).sDLColumnName = pDataReader("DLカラム名称").ToString

                '適用
                parDownload(i).sDescription = pDataReader("適用").ToString

                'デリミタ
                parDownload(i).sDerimita = pDataReader("デリミタ").ToString

                '区画No
                parDownload(i).sSplitNo = CInt(pDataReader("区画No"))

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getDLColumn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDownloadColumnDBIO.getDLColumn)", Nothing, Nothing, oExcept.ToString)
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
    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parDownloadColumn()　：データセットバッファ（sDownloadColumn Structureの配列）
    '　　　：KeyString　：キー情報（Mode=DownloadColumn_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（DownloadColumn_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getMaxDBColumn(ByRef parDownload() As cStructureLib.sDownloadColumn, _
                                   ByVal KeyChannelCode As Integer, _
                                    ByVal KeyDataClass As Integer, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long


        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT * FROM ダウンロードカラムマスタ " & _
                    "WHERE チャネルコード=" & KeyChannelCode & _
                    " AND データ種別=" & KeyDataClass & _
                    " ORDER BY DBカラムNo DESC"

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parDownload(i)

                'チャネルコード
                parDownload(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                'データ種別
                parDownload(i).sDataClass = CInt(pDataReader("データ種別"))

                'DBカラムNo
                parDownload(i).sDBColumnNo = CInt(pDataReader("DBカラムNo"))

                'DBカラム名称
                parDownload(i).sDBColumnName = pDataReader("DBカラム名称").ToString

                'DBカラムタイプ
                parDownload(i).sDBColumnType = CInt(pDataReader("DBカラムタイプ"))

                'DLカラムNo
                If IsDBNull(pDataReader("DLカラムNo")) Then
                    parDownload(i).sDLColumnNo = Nothing
                Else
                    parDownload(i).sDLColumnNo = CInt(pDataReader("DLカラムNo"))
                End If

                'DLカラム名称
                parDownload(i).sDLColumnName = pDataReader("DLカラム名称").ToString

                '適用
                parDownload(i).sDescription = pDataReader("適用").ToString

                'デリミタ
                parDownload(i).sDerimita = pDataReader("デリミタ").ToString

                '区画No
                parDownload(i).sSplitNo = CInt(pDataReader("区画No"))

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getMaxDBColumn = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDownloadColumnDBIO.getMaxDBColumn)", Nothing, Nothing, oExcept.ToString)
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

    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parDownloadColumn()　：データセットバッファ（sDownloadColumn Structureの配列）
    '　　　：KeyString　：キー情報（Mode=DownloadColumn_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（DownloadColumn_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getDBColumnCount(ByVal KeyChannelCode As Integer, ByVal KeyDataClass As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT DBカラムNo FROM ダウンロードカラムマスタ " & _
                    "WHERE チャネルコード=" & KeyChannelCode & " AND データ種別=" & KeyDataClass & " " & _
                    "ORDER BY DBカラムNo DESC"

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            If (pDataReader.Read()) Then
                getDBColumnCount = CInt(pDataReader("DBカラムNo"))
            Else
                getDBColumnCount = 0
            End If


        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDownloadColumnDBIO.getDBColumnCount)", Nothing, Nothing, oExcept.ToString)
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



    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '-------------------------------------------------------------------------------
    Public Sub getDBColumn(ByRef parDownload() As cStructureLib.sDownloadColumn, _
                                   ByVal KeyChannelCode As Integer, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction)


        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""
        strSelect = "SELECT * FROM ダウンロードカラムマスタ " & _
                    "WHERE チャネルコード=" & KeyChannelCode

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parDownload(i)

                'チャネルコード
                parDownload(i).sChannelCode = CInt(pDataReader("チャネルコード"))

                'データ種別
                parDownload(i).sDataClass = CInt(pDataReader("データ種別"))

                'DBカラムNo
                parDownload(i).sDBColumnNo = CInt(pDataReader("DBカラムNo"))

                'DBカラム名称
                parDownload(i).sDBColumnName = pDataReader("DBカラム名称").ToString

                'DBカラムタイプ
                parDownload(i).sDBColumnType = CInt(pDataReader("DBカラムタイプ"))

                'DLカラムNo
                If IsDBNull(pDataReader("DLカラムNo")) Then
                    parDownload(i).sDLColumnNo = Nothing
                Else
                    parDownload(i).sDLColumnNo = CInt(pDataReader("DLカラムNo"))
                End If

                'DLカラム名称
                parDownload(i).sDLColumnName = pDataReader("DLカラム名称").ToString

                '適用
                parDownload(i).sDescription = pDataReader("適用").ToString

                'デリミタ
                parDownload(i).sDerimita = pDataReader("デリミタ").ToString

                '区画No
                parDownload(i).sSplitNo = CInt(pDataReader("区画No"))

                'レコードが取得できた時の処理
                i = i + 1
            End While

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstDownloadColumnDBIO.getMaxDBColumn)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Sub

End Class
