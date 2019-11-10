Option Strict On       'プロジェクトのプロパティでも設定可能

'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cMstPostCodeDBIO
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
    '　機能：郵便番号マスタから該当郵便番号以上のレコードを取得する関数
    '　引数：ParPostCode 取得データセット用バッファ
    '        KeyPostCodeCode 郵便番号
    '        Mode          1:指定郵便番号のデータ取得
    '                      2:指定郵便番号以上のデータ取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getPostCode(ByRef ParPostCode() As cStructureLib.sPostCode, _
                              ByVal KeyPostCodeCode As Long, _
                              ByVal Mode As Integer, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String

        If Mode = 1 Then
            StrSelect = "SELECT * FROM 郵便番号マスタ WHERE 郵便番号8 = @PostCodeCode "
        Else
            StrSelect = "SELECT * FROM 郵便番号マスタ WHERE 郵便番号8 >= @PostCodeCode ORDER BY 郵便番号8"
        End If

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '郵便番号
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@PostCodeCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@PostCodeCode").Value = KeyPostCodeCode

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParPostCode(CInt(i))

                'レコードが取得できた時の処理
                '郵便番号
                ParPostCode(i).sPostCode3 = pDataReader("郵便番号3").ToString
                '郵便番号
                ParPostCode(i).sPostCode5 = pDataReader("郵便番号5").ToString
                '郵便番号
                ParPostCode(i).sPostCode8 = pDataReader("郵便番号8").ToString
                '住所カナ－都道府県
                ParPostCode(i).sAddr1Kana = pDataReader("住所カナ－都道府県").ToString
                '住所カナ－市区町村
                ParPostCode(i).sAddr2Kana = pDataReader("住所カナ－市区町村").ToString
                '住所カナ－町域
                ParPostCode(i).sAddr3Kana = pDataReader("住所カナ－町域").ToString
                '住所－都道府県
                ParPostCode(i).sAddr1 = pDataReader("住所－都道府県").ToString
                '住所－市区町村
                ParPostCode(i).sAddr2 = pDataReader("住所－市区町村").ToString
                '住所－町域
                ParPostCode(i).sAddr3 = pDataReader("住所－町域").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getPostCode = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPostCodeDBIO.getPostCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：郵便番号マスタから該当郵便番号以上のレコードを取得する関数
    '　引数：ParPostCode 取得データセット用バッファ
    '        KeyPostCodeCode 郵便番号
    '        Mode          1:指定郵便番号のデータ取得
    '                      2:指定郵便番号以上のデータ取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getCity(ByRef ParCity() As cStructureLib.sCity, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String


        StrSelect = "SELECT DISTINCT Left([郵便番号5],2) AS 県番号, " & _
                        "郵便番号マスタ.住所－都道府県 " & _
                        "FROM 郵便番号マスタ"
        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParCity(CInt(i))

                'レコードが取得できた時の処理
                '郵便番号
                ParCity(i).sCityNo = pDataReader("県番号").ToString
                '郵便番号
                ParCity(i).sCityName = pDataReader("住所－都道府県").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getCity = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstPostCodeDBIO.getCity)", Nothing, Nothing, oExcept.ToString)
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
