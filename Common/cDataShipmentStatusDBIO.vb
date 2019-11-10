Public Class cDataShipmentStatusDBIO
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
    '　機能：プロパティの取引コードのレコードが発注情報データに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ShipStatusExist(ByVal KeyShipCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 出荷伝表出力データ WHERE 出荷コード = @ShipCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipCode").Value = KeyShipCode

            '発注譲歩マスタから該当取引コードのレコード数読込 
            Dim recCount As Integer

            recCount = CInt(pCommand.ExecuteScalar())
            If recCount > 0 Then
                'レコードが存在する時の処理
                ShipStatusExist = True
            Else
                'レコードが存在しない時の処理
                ShipStatusExist = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.ShipStatusExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次発注情報データから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getShipStatus(ByRef parShipStatus() As cStructureLib.sShipStatus, _
                                   ByVal keyShipCode As String, _
                                   ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        Try
            strSelect = ""

            If keyShipCode = Nothing Then
                strSelect = "SELECT * FROM 出荷伝表出力データ"
            Else
                strSelect = "SELECT * FROM 出荷伝表出力データ WHERE 出荷コード = @ShipCode"
            End If

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            '***********************
            '   パラメータの設定
            '***********************

            '出荷コード
            If keyShipCode <> "" Then

                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ShipCode", OleDb.OleDbType.Char, 13))
                pCommand.Parameters("@ShipCode").Value = keyShipCode
            End If

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()
                ReDim Preserve parShipStatus(i)

                'レコードが取得できた時の処理
                '商品コード
                parShipStatus(i).sShipCode = pDataReader("出荷コード").ToString
                '発注状態
                parShipStatus(i).sShipCheck = pDataReader("出荷状態")

                getShipStatus = i
                i = i + 1
            End While

            getShipStatus = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.getShipStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：プロパティの取引コードのレコードが発注情報データに
    '　　　　 存在するか否かを調べるメソッド
    '　引数：なし
    '　戻値：True  --> 存在する.  False --> 存在しない
    '----------------------------------------------------------------------
    Public Function ShipStatusCount(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Const strSelect As String = _
        "SELECT COUNT(*) FROM 出荷伝表出力データ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            ShipStatusCount = CLng(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.ShipStatusCount)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データに１レコードを登録するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertShipStatus(ByVal parShipStatus As cStructureLib.sShipStatus, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        Try

            'SQL文の設定
            strInsert = "INSERT INTO 出荷伝表出力データ (" & _
                            "出荷コード, " & _
                            "出荷状態 " & _
                        ") VALUES (" & _
                            """" & parShipStatus.sShipCode & """, " & _
                            parShipStatus.sShipCheck & ") "


            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsert


            '出荷伝表出力データ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertShipStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.insertShipStatus)", Nothing, Nothing, oExcept.ToString)
            System.Windows.Forms.Application.DoEvents()
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
    '　機能：発注情報データの１レコードを更新するメソッド
    '　引数：in cSubPrdMstオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateShipStatus(ByVal parShipStatus As cStructureLib.sShipStatus, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        strUpdate = "UPDATE 出荷伝表出力データ " & _
                        "SET 出荷状態 = " & parShipStatus.sShipCheck & ", " & _
                    "WHERE 出荷コード = """ & parShipStatus.sShipCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'SQL文パラメータの設定
            '出荷コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@ShipCode").Value = parShipStatus.sShipCode
            '出荷状態
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipStatus", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@ShipStatus").Value = parShipStatus.sShipCheck

            '発注情報データ更新SQL文実行
            Dim count As Integer

            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                '更新成功
                updateShipStatus = True
            Else
                '更新するレコードがなかった時の処理
                updateShipStatus = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.updateShipStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：発注情報データに１レコードを登録するメソッド
    '　引数：in sShipStatusオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteShipStatus(ByVal KeyShipCode As String, _
                                      ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim StrDelete As String
        Dim count As Integer

        Try
            If KeyShipCode = Nothing Then
                'SQL文の設定
                StrDelete = "DELETE * FROM 出荷伝表出力データ"
            Else
                'SQL文の設定
                StrDelete = "DELETE * FROM 出荷伝表出力データ WHERE 出荷コード = """ & KeyShipCode & """ "
            End If

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            pCommand.CommandText = StrDelete

            '発注情報データ削除SQL文実行
            count = pCommand.ExecuteNonQuery()
            If count > 0 Then
                '更新成功
                deleteShipStatus = True
            Else
                '更新するレコードがなかった時の処理
                deleteShipStatus = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataShipStatusDBIO.deleteShipStatus)", Nothing, Nothing, oExcept.ToString)
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
