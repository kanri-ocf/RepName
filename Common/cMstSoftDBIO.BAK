Public Class cMstOPOSDBIO

    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage


    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader)
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
    Public Function OPOSExist(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Const strSelectTrn As String = _
        "SELECT COUNT(*) FROM OPOSマスタ"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectTrn

            'テーブルから該当取引コードのレコード数読込 
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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstOPOSDBIO.OPOSExist)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：日次取引テーブルから１レコードを取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：True  --> レコードの取得成功
    '　　　　False --> 取得するレコードなし
    '----------------------------------------------------------------------
    Public Function getOPOSMst(ByRef parOPOS() As cStructureLib.sOPOS, _
                               ByVal KeyModelName As String, _
                               ByVal KeyProductClass As Integer, _
                               ByVal KeyOPOS_ID As Integer, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer
        Dim strSelect As String

        'SQL文の設定
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            strSelect = "SELECT " & _
                           "OPOSマスタ.OPOS_ID, " & _
                           "OPOSマスタ.メーカー名称, " & _
                           "OPOSマスタ.モデル名称, " & _
                           "OPOSマスタ.デバイス名称, " & _
                           "OPOSマスタ.OPOSバージョン, " & _
                           "OPOSマスタ.機器種別, " & _
                           "OPOSマスタ.登録日, " & _
                           "OPOSマスタ.登録時間, " & _
                           "OPOSマスタ.最終更新日, " & _
                           "OPOSマスタ.最終更新時間 " & _
                        "FROM OPOSマスタ "

            'パラメータ数のカウント
            pc = 0
            maxpc = 0
            If KeyModelName <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyProductClass <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyOPOS_ID <> Nothing Then
                maxpc = 4
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
                            strSelect = strSelect & "モデル名称 = """ & KeyModelName & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "機器種別 = " & KeyProductClass & " "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "OPOS_ID =" & KeyOPOS_ID & " "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strSelect

            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve parOPOS(i)

                'レコードが取得できた時の処理
                'OPOS_ID
                If IsDBNull(pDataReader("OPOS_ID")) = True Then
                    parOPOS(i).sOPOS_ID = 0
                Else
                    parOPOS(i).sOPOS_ID = CInt(pDataReader("OPOS_ID"))
                End If
                'メーカー名称
                parOPOS(i).sMakerName = pDataReader("メーカー名称").ToString
                'モデル名称
                parOPOS(i).sModelName = pDataReader("モデル名称").ToString
                'モデル名称
                parOPOS(i).sDeviceName = pDataReader("デバイス名称").ToString
                'OPOSバージョン
                parOPOS(i).sVersion = pDataReader("OPOSバージョン").ToString
                '機器種別
                If IsDBNull(pDataReader("機器種別")) = True Then
                    parOPOS(i).sProductClass = 0
                Else
                    parOPOS(i).sProductClass = CInt(pDataReader("機器種別"))
                End If
                '登録日
                parOPOS(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parOPOS(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parOPOS(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parOPOS(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While
            getOPOSMst = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstOPOSDBIO.getOPOSMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：OPOSマスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertOPOSMst(ByRef parOPOS() As cStructureLib.sOPOS, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "INSERT INTO 予約データ (" & _
                        "OPOS_ID, " & _
                        "メーカー名称, " & _
                        "モデル名称, " & _
                        "デバイス名称, " & _
                        "OPOSバージョン, " & _
                        "機器種別, " & _
                        "登録日, " & _
                        "登録時間, " & _
                        "最終更新日, " & _
                        "最終更新時間 " & _
                    ") VALUES ( " & _
                        parOPOS(0).sOPOS_ID & ", " & _
                        """" & parOPOS(0).sMakerName & """, " & _
                        """" & parOPOS(0).sModelName & """, " & _
                        """" & parOPOS(0).sDeviceName & """, " & _
                        """" & parOPOS(0).sVersion & """, " & _
                        parOPOS(0).sProductClass & ", " & _
                        "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss""), " & _
                        "FORMAT(NOW, ""yyyy/mm/dd""), " & _
                        "FORMAT(NOW, ""hh:nn:ss"") " & _
                    ") "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            insertOPOSMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstOPOSDBIO.insertOPOSMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：OPOSマスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateOPOSMst(ByRef parOPOS() As cStructureLib.sOPOS, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE OPOSマスタ SET " & _
                            "OPOSマスタ.OPOS_ID = " & parOPOS(0).sOPOS_ID & ", " & _
                            "OPOSマスタ.メーカー名称 = """ & parOPOS(0).sMakerName & """, " & _
                            "OPOSマスタ.モデル名称 = """ & parOPOS(0).sModelName & """, " & _
                            "OPOSマスタ.デバイス名称 = """ & parOPOS(0).sDeviceName & """, " & _
                            "OPOSマスタ.OPOSバージョン = """ & parOPOS(0).sVersion & """, " & _
                            "OPOSマスタ.機器種別 = " & parOPOS(0).sProductClass & ", " & _
                            "OPOSマスタ.最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "OPOSマスタ.最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE OPOSマスタ.No=1 "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateOPOSMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstOPOSDBIO.updateOPOSMst)", Nothing, Nothing, oExcept.ToString)
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
