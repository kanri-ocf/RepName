Option Strict On       'プロジェクトのプロパティでも設定可能

Public Class cViewStaffAuthorityDBIO

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
    '　機能：配送種別マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getStaffAuthority(ByRef parViewStaffAuthority() As cStructureLib.sViewStaffAuthority, _
                                  ByVal KeyStaffCode As String, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strSelect As String
        Dim i As Integer
        Dim oTool As New cTool
        Dim ExeName As String

        ExeName = oTool.GetRunExe

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT " & _
                        "スタッフ権限マスタ.スタッフコード, " & _
                        "スタッフ権限マスタ.アプリケーションID, " & _
                        "アプリケーションマスタ.グループID, " & _
                        "アプリケーションマスタ.グループ名称, " & _
                        "アプリケーションマスタ.メニュー名称, " & _
                        "アプリケーションマスタ.コントロール名称, " & _
                        "アプリケーションマスタ.実行モジュール名称 " & _
                    "FROM " & _
                        "アプリケーションマスタ RIGHT JOIN スタッフ権限マスタ " & _
                        "ON アプリケーションマスタ.アプリケーションID = スタッフ権限マスタ.アプリケーションID " & _
                    "WHERE " & _
                        "スタッフ権限マスタ.スタッフコード =""" & KeyStaffCode & """ " & _
                        "AND アプリケーションマスタ.実行モジュール名称 =""" & ExeName & """ "
        Try

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parViewStaffAuthority(CInt(i))

                'スタッフコード
                parViewStaffAuthority(i).sStaffCode = pDataReader("スタッフコード").ToString
                'アプリケーションID
                parViewStaffAuthority(i).sApplicationID = pDataReader("アプリケーションID").ToString
                'グループID
                parViewStaffAuthority(i).sGroupID = pDataReader("グループID").ToString
                'グループ名称
                parViewStaffAuthority(i).sGroupName = pDataReader("グループ名称").ToString
                'メニュー名称
                parViewStaffAuthority(i).sMenuName = pDataReader("メニュー名称").ToString
                'コントロール名称
                parViewStaffAuthority(i).sControlName = pDataReader("コントロール名称").ToString
                '実行モジュール名称
                parViewStaffAuthority(i).sExeName = pDataReader("実行モジュール名称").ToString
                i = i + 1
            End While

            If i > 0 Then
                getStaffAuthority = True
            Else
                getStaffAuthority = False
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewStaffAuthorityDBIO.getStaffAuthority)", Nothing, Nothing, oExcept.ToString)
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
