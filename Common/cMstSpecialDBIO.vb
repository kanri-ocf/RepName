Public Class cMstSpecialDBIO
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
    '　機能：特典マスタから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getSpecial(ByRef paSpecial() As cStructureLib.sSpecial, _
                                ByVal keySpecialCode As String, _
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

            strSelect = "SELECT * FROM 特典マスタ "

            '***********************
            '   パラメータの設定
            '***********************

            'パラメータ数のカウント
            pc = 0
            If keySpecialCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If

            'パラメータ指定がある場合
            If maxpc And pc > 0 Then
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
                            strSelect = strSelect & "特典コード = " & keySpecialCode & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0
            getSpecial = 0

            While pDataReader.Read()
                ReDim Preserve parSpecial(i)

                'レコードが取得できた時の処理

				'特典コード
				If IsDBNull(pDataReader("特典コード"))=True Then
					parSpecial(i).sSpecialCode=0
				Else
				  parSpecial(i).sSpecialCode=Cint(pDataReader("特典コード"))
				EndIf
				
				'特典名称
				parSpecial(i).sServiceSubCode=pDataReader("特典名称").ToString
				
				'対象部門コード
				parSpecial(i).sBumonCode=pDataReader("対象部門コード").ToString
				
				'割引率
				If IsDBNull(pDataReader("割引率"))=True Then
					parSpecial(i).sDiscountRate=0
				Else
				  parSpecial(i).sDiscountRate=Cint(pDataReader("割引率"))
				EndIf
				
				'割引金額
				If IsDBNull(pDataReader("割引金額"))=True Then
				parSpecial(i).sDiscountPrice=0
				Else
				  parSpecial(i).sDiscountPrice=Cint(pDataReader("割引金額"))
				EndIf
				
				'登録日
				parSpecial(i).sCreateDate=pDataReader("登録日").ToString
				   
				'登録時間
				parSpecial(i).sCreateTime=pDataReader("登録時間").ToString
				   
				'最終更新日
				parSpecial(i).sUpdateDate=pDataReader("最終更新日").ToString
				   
				'最終更新時間
				parSpecial(i).sUpdateTime=pDataReader("最終更新時間").ToString

                i = i + 1

            End While

            getSpecial = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstSpecialDBIO.getSpecial)", Nothing, Nothing, oExcept.ToString)
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
