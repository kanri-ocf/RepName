Option Strict On       'プロジェクトのプロパティでも設定可能

'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cMstCsvLayoutDBIO
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
    '　機能：精算データから該当精算コード以上のレコードを取得する関数
    '　引数：ParCsvLayout 取得データセット用バッファ
    '        KeyCsvLayoutCode 精算コード
    '        Mode          1:指定精算コードのデータ取得
    '                      2:指定精算コード以上の入金データ取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getCsvLayout(ByRef ParCsvLayout() As cStructureLib.sCsvLayout, _
                              ByVal KeySoftCode As Integer, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String

        StrSelect = "SELECT * FROM CSVレイアウトマスタ WHERE ソフトコード = " & KeySoftCode & " ORDER BY No "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParCsvLayout(CInt(i))

                'レコードが取得できた時の処理
                'ソフトコード
                If IsDBNull(pDataReader("ソフトコード")) = True Then
                    ParCsvLayout(i).sSoftCode = 0
                Else
                    ParCsvLayout(i).sSoftCode = CInt(pDataReader("ソフトコード"))
                End If
                'No
                If IsDBNull(pDataReader("No")) = True Then
                    ParCsvLayout(i).sDataClass = 0
                Else
                    ParCsvLayout(i).sDataClass = CInt(pDataReader("No"))
                End If
                '項目名称
                ParCsvLayout(i).sColumnNo = pDataReader("項目名称").ToString
                '長さ
                If IsDBNull(pDataReader("長さ")) = True Then
                    ParCsvLayout(i).sColumnName = 0
                Else
                    ParCsvLayout(i).sColumnName = CInt(pDataReader("長さ"))
                End If
                '型
                ParCsvLayout(i).sColumnType = pDataReader("型").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getCsvLayout = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataCsvLayoutDBIO.getCsvLayout)", Nothing, Nothing, oExcept.ToString)
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
