Public Class cMstCategoryDBIO
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
    '　機能：カテゴリマスタから該当カテゴリ名称_の情報を取得
    '　引数：なし
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------

    'Public Function getCategory(ByRef parCategory() As cStructureLib.sCategoryMst, _
    '                            ByVal KeyCategory1 As String, _
    '                            ByVal KeyCategory2 As String _
    '                        ) As Long

    '----------------------------------------------------------------------
    '----------------------------------------------------
    '2015/06/20
    '及川和彦
    'トランザクション追加
    'FROM
    '----------------------------------------------------
    'Public Function getCategory(ByRef parCategory() As cStructureLib.sCategory, _
    '                                ByVal KeyCategory1 As String, _
    '                                ByVal KeyCategory2 As String, _
    '                                ByRef Tran As System.Data.OleDb.OleDbTransaction _
    '                            ) As Long
    '    '----------------------------------------------------
    '    'HERE
    '    '----------------------------------------------------


    '    Dim strSelect As String
    '    Dim parStr As String
    '    Dim orderStr As String
    '    Dim i As Long
    '    Dim pc As Integer
    '    Dim scnt As Integer

    '    'コマンドオブジェクトの生成
    '    pCommand = pConn.CreateCommand()
    '    '----------------------------------------------------
    '    '2015/06/20
    '    '及川和彦
    '    'トランザクション追加
    '    'FROM
    '    '----------------------------------------------------
    '    pCommand.Transaction = Tran
    '    '----------------------------------------------------
    '    'HERE
    '    '----------------------------------------------------


    '    strSelect = "SELECT DISTINCT カテゴリ1名称 "
    '    parStr = ""
    '    orderStr = "ORDER BY カテゴリ1名称 "

    '    'パラメータ数のカウント
    '    pc = 0
    '    If KeyCategory1 <> "" Then
    '        pc = pc Or 1
    '    End If
    '    If KeyCategory2 <> "" Then
    '        pc = pc Or 2
    '    End If

    '    'パラメータ指定がある場合
    '    If 3 And pc > 0 Then
    '        i = 1
    '        scnt = 0
    '        While i <= 2
    '            Select Case i And pc
    '                Case 1
    '                    strSelect = strSelect & ", カテゴリ2名称 "
    '                    If scnt > 0 Then
    '                        parStr = parStr & "AND "
    '                    Else
    '                        parStr = parStr & "WHERE "
    '                    End If
    '                    parStr = parStr & "カテゴリ1名称 Like ""%" & KeyCategory1 & "%"" "
    '                    orderStr = orderStr & ", カテゴリ2名称 "
    '                    scnt = scnt + 1
    '            End Select
    '            i = i * 2
    '        End While
    '    End If
    '    strSelect = strSelect & "FROM カテゴリマスタ " & parStr & orderStr
    '    Try
    '        i = 0

    '        'SQL文の設定
    '        pCommand.CommandText = strSelect

    '        pDataReader = pCommand.ExecuteReader()

    '        While pDataReader.Read()

    '            ReDim Preserve parCategory(i)

    '            'カテゴリ1名称
    '            parCategory(i).sCategory1Name = pDataReader("カテゴリ1名称").ToString
    '            If pc >= 1 Then
    '                'カテゴリ2名称
    '                parCategory(i).sCategory2Name = pDataReader("カテゴリ2名称").ToString
    '            End If
    '            'レコードが取得できた時の処理
    '            i = i + 1
    '        End While

    '        getCategory = i

    '    Catch oExcept As Exception
    '        '例外が発生した時の処理
    '        pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategory)", Nothing, Nothing, oExcept.ToString)
    '        pMessageBox.ShowDialog()
    '        pMessageBox.Dispose()
    '        pMessageBox = Nothing
    '        Environment.Exit(1)
    '    Finally
    '        If IsNothing(pDataReader) = False Then
    '            pDataReader.Close()
    '        End If
    '    End Try

    'End Function
    ''----------------------------------------------------------------------
    ''　機能：カテゴリマスタから該当カテゴリID_の情報を取得
    ''　引数：なし
    ''　戻値：True  --> 登録成功.  False --> 登録失敗
    ''----------------------------------------------------------------------
    ''Public Function getCategoryID(ByRef parCategory() As cStructureLib.sCategoryMst, _
    ''                                ByVal KeyCategory1 As String, _
    ''                                ByVal KeyCategory2 As String _
    ''                            ) As Long
    ''----------------------------------------------------
    ''2015/06/20
    ''及川和彦
    ''トランザクション追加
    ''FROM
    ''----------------------------------------------------
    'Public Function getCategoryID(ByRef parCategory() As cStructureLib.sCategory, _
    '                            ByVal KeyCategory1 As String, _
    '                            ByVal KeyCategory2 As String, _
    '                            ByRef Tran As System.Data.OleDb.OleDbTransaction _
    '                        ) As Long
    '    '----------------------------------------------------
    '    'HERE
    '    '----------------------------------------------------


    '    Dim strSelect As String
    '    Dim parStr As String
    '    Dim i As Long

    '    Try
    '        'コマンドオブジェクトの生成
    '        pCommand = pConn.CreateCommand()
    '        '----------------------------------------------------
    '        '2015/06/20
    '        '及川和彦
    '        'トランザクション追加
    '        'FROM
    '        '----------------------------------------------------
    '        pCommand.Transaction = Tran
    '        '----------------------------------------------------
    '        'HERE
    '        '----------------------------------------------------

    '        strSelect = "SELECT DISTINCT カテゴリ1ID, カテゴリ1名称 "
    '        parStr = "WHERE カテゴリ1名称 = """ & KeyCategory1 & """ "

    '        'パラメータ数のカウント
    '        If KeyCategory2 <> "" Then
    '            strSelect = strSelect & ", カテゴリ2ID, カテゴリ2名称 "
    '            parStr = parStr & "AND "
    '            parStr = parStr & "カテゴリ2名称 = """ & KeyCategory2 & """ "
    '        End If

    '        strSelect = strSelect & "FROM カテゴリマスタ " & parStr

    '        i = 0

    '        'SQL文の設定
    '        pCommand.CommandText = strSelect

    '        pDataReader = pCommand.ExecuteReader()

    '        While pDataReader.Read()

    '            ReDim Preserve parCategory(i)

    '            'カテゴリID_1
    '            parCategory(i).sCategory1ID = pDataReader("カテゴリ1ID").ToString
    '            'カテゴリ1名称
    '            parCategory(i).sCategory1Name = pDataReader("カテゴリ1名称").ToString
    '            If KeyCategory2 <> "" Then
    '                'カテゴリID_2
    '                parCategory(i).sCategory2ID = pDataReader("カテゴリ2ID").ToString
    '                'カテゴリ2名称
    '                parCategory(i).sCategory2Name = pDataReader("カテゴリ2名称").ToString
    '            End If
    '            'レコードが取得できた時の処理
    '            i = i + 1
    '        End While

    '        getCategoryID = i

    '    Catch oExcept As Exception
    '        '例外が発生した時の処理
    '        pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategoryID)", Nothing, Nothing, oExcept.ToString)
    '        pMessageBox.ShowDialog()
    '        pMessageBox.Dispose()
    '        pMessageBox = Nothing
    '        Environment.Exit(1)
    '    Finally
    '        If IsNothing(pDataReader) = False Then
    '            pDataReader.Close()
    '        End If
    '    End Try

    'End Function
    '----------------------------------------------------------------------
    '　機能：カテゴリマスタから該当カテゴリ名称_の情報を取得
    '　引数：なし
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function getCategory1(ByRef parCategory1() As cStructureLib.sCategory1, _
                                    ByVal KeyCategory1ID As String, _
                                    ByVal KeyCategory1Name As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Dim strSelect As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT カテゴリ1ID, カテゴリ1名称 FROM カテゴリ1マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyCategory1ID <> "" Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyCategory1Name <> "" Then
            pc = pc Or 2
            mpc = 2
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1ID = """ & KeyCategory1ID & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1名称 Like ""%" & KeyCategory1Name & "%"" "
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

            ReDim parCategory1(0)

            While pDataReader.Read()

                ReDim Preserve parCategory1(i)

                'カテゴリID_1
                parCategory1(i).sCategory1ID = pDataReader("カテゴリ1ID").ToString
                'カテゴリ1名称
                parCategory1(i).sCategory1Name = pDataReader("カテゴリ1名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getCategory1 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategory1)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getCategory2(ByRef parCategory2() As cStructureLib.sCategory2, _
                             ByVal KeyCategory1ID As String, _
                             ByVal KeyCategory2ID As String, _
                             ByVal KeyCategory2Name As String, _
                             ByRef Tran As System.Data.OleDb.OleDbTransaction _
                         ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Dim strSelect As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT カテゴリ1ID, カテゴリ2ID, カテゴリ2名称 FROM カテゴリ2マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyCategory1ID <> "" Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyCategory2ID <> "" Then
            pc = pc Or 2
            mpc = 2
        End If
        If KeyCategory2Name <> "" Then
            pc = pc Or 4
            mpc = 4
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1ID = """ & KeyCategory1ID & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2ID = """ & KeyCategory2ID & """ "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2名称 Like ""%" & KeyCategory2Name & "%"" "
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

            ReDim parCategory2(0)

            While pDataReader.Read()

                ReDim Preserve parCategory2(i)

                'カテゴリID_1
                parCategory2(i).sCategory1ID = pDataReader("カテゴリ1ID").ToString
                'カテゴリID_2
                parCategory2(i).sCategory2ID = pDataReader("カテゴリ2ID").ToString
                'カテゴリ2名称
                parCategory2(i).sCategory2Name = pDataReader("カテゴリ2名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getCategory2 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategory2)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getCategoryFull(ByRef parCategory() As cStructureLib.sViewCategoryFull, _
                                ByVal KeyCategory1ID As String, _
                                ByVal KeyCategory1Name As String, _
                                ByVal KeyCategory2ID As String, _
                                ByVal KeyCategory2Name As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction _
                            ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Dim strSelect As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT カテゴリ1マスタ.カテゴリ1ID, カテゴリ1マスタ.カテゴリ1名称, カテゴリ2マスタ.カテゴリ2ID, カテゴリ2マスタ.カテゴリ2名称 " & _
                     "FROM カテゴリ1マスタ LEFT JOIN カテゴリ2マスタ ON カテゴリ1マスタ.カテゴリ1ID = カテゴリ2マスタ.カテゴリ1ID "

        'パラメータ数のカウント
        pc = 0
        If KeyCategory1ID <> "" Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyCategory1Name <> "" Then
            pc = pc Or 2
            mpc = 2
        End If
        If KeyCategory2ID <> "" Then
            pc = pc Or 4
            mpc = 4
        End If
        If KeyCategory2Name <> "" Then
            pc = pc Or 8
            mpc = 8
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1マスタ.カテゴリ1ID = """ & KeyCategory1ID & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1マスタ.カテゴリ1名称 Like ""%" & KeyCategory1Name & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2マスタ.カテゴリ2ID = """ & KeyCategory2ID & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2マスタ.カテゴリ2名称 Like ""%" & KeyCategory2Name & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If
        strSelect = strSelect & "ORDER BY カテゴリ1マスタ.カテゴリ1ID, カテゴリ2マスタ.カテゴリ2ID "
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parCategory(i)

                'カテゴリID_1
                parCategory(i).sCategory1ID = pDataReader("カテゴリ1ID").ToString
                'カテゴリ1名称
                parCategory(i).sCategory1Name = pDataReader("カテゴリ1名称").ToString
                'カテゴリID_2
                parCategory(i).sCategory2ID = pDataReader("カテゴリ2ID").ToString
                'カテゴリ2名称
                parCategory(i).sCategory2Name = pDataReader("カテゴリ2名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getCategoryFull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategoryFull)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリ１マスタの１レコードを削除するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteCategory1(ByVal KeyCategory1ID As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE * FROM カテゴリ1マスタ " & _
                        "WHERE カテゴリ1ID = """ & KeyCategory1ID & """ "


            pCommand.CommandText = strDelete

            'チャネルマスタの削除処理実行
            deleteCategory1 = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.deleteCategory1)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリ２マスタの１レコードを削除するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteCategory2(ByVal KeyCategory1ID As String, _
                                    ByVal KeyCategory2ID As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            'SQL文の設定
            strDelete = "DELETE * FROM カテゴリ2マスタ " 

            'パラメータ数のカウント
            pc = 0
            If KeyCategory1ID <> "" Then
                pc = pc Or 1
                mpc = 1
            End If
            If KeyCategory2ID <> "" Then
                pc = pc Or 2
                mpc = 2
            End If
 
            'パラメータ指定がある場合
            If mpc And pc > 0 Then
                i = 1
                While i <= mpc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "カテゴリ1ID = """ & KeyCategory1ID & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strDelete = strDelete & "AND "
                            Else
                                strDelete = strDelete & "WHERE "
                            End If
                            strDelete = strDelete & "カテゴリ2ID = """ & KeyCategory2ID & """ "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            pCommand.CommandText = strDelete

            'チャネルマスタの削除処理実行
            deleteCategory2 = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.deleteCategory2)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリ１マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateCategory1(ByVal parCategory1 As cStructureLib.sCategory1, ByVal KeyCategory1ID As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE カテゴリ1マスタ SET " & _
                        "カテゴリ1名称 = """ & parCategory1.sCategory1Name & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE カテゴリ1ID = """ & KeyCategory1ID & """ "

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
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstChannelDBIO.updateCategory1)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリ１マスタの１レコードを更新するメソッド
    '　引数：in cStaffオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateCategory2(ByVal parCategory2 As cStructureLib.sCategory2, _
                                    ByVal KeyCategory1ID As String, _
                                    ByVal KeyCategory2ID As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE カテゴリ2マスタ SET " & _
                        "カテゴリ2名称 = """ & parCategory2.sCategory2Name & """, " & _
                        "最終更新日 = """ & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                        "最終更新時間 = """ & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                    "WHERE カテゴリ1ID = """ & KeyCategory1ID & """ " & _
                        "AND カテゴリ2ID = """ & KeyCategory2ID & """ "

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
            pMessageBox = New cMessageLib.fMessage(2, "システムエラー(cMstChannelDBIO.updateCategory2)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(2)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try
    End Function

    '----------------------------------------------------------------------
    '　機能：カテゴリマスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertCategory1(ByVal parCategory1 As cStructureLib.sCategory1, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO カテゴリ1マスタ ( " & _
                            "カテゴリ1ID, " & _
                            "カテゴリ1名称, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@Category1ID, " & _
                            "@Category1Name, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'カテゴリ1ID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Category1ID", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Category1ID").Value = parCategory1.sCategory1ID
            'カテゴリ1名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Category1Name", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Category1Name").Value = parCategory1.sCategory1Name
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

            'カテゴリ1マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertCategory1 = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.insertCategory1)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリマスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertCategory2(ByVal parCategory2 As cStructureLib.sCategory2, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strInsert As String

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            'SQL文の設定
            strInsert = "INSERT INTO カテゴリ2マスタ ( " & _
                            "カテゴリ1ID, " & _
                            "カテゴリ2ID, " & _
                            "カテゴリ2名称, " & _
                            "登録日, " & _
                            "登録時間, " & _
                            "最終更新日, " & _
                            "最終更新時間 " & _
                        ") VALUES (" & _
                            "@Category1ID, " & _
                            "@Category2ID, " & _
                            "@Category2Name, " & _
                            "@CreateDate, " & _
                            "@CreateTime, " & _
                            "@UpdateDate, " & _
                            "@UpdateTime " & _
                        ")"

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            'カテゴリ1ID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Category1ID", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Category1ID").Value = parCategory2.sCategory1ID
            'カテゴリ2ID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Category2ID", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Category2ID").Value = parCategory2.sCategory2ID
            'カテゴリ2名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CategoryName", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@CategoryName").Value = parCategory2.sCategory2Name
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

            'カテゴリ2マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertCategory2 = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.insertCategory2)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：カテゴリマスタから該当レコードの件数を取得
    '　引数：なし
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function getCategory1Count(ByVal KeyCategory1ID As String, _
                                    ByVal KeyCategory1Name As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction _
                                ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Dim strSelect As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT COUNT(*) FROM カテゴリ1マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyCategory1ID <> "" Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyCategory1Name <> "" Then
            pc = pc Or 2
            mpc = 2
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1ID = """ & KeyCategory1ID & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1名称 Like ""%" & KeyCategory1Name & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            getCategory1Count = CLng(pCommand.ExecuteScalar())


        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategory1Count)", Nothing, Nothing, oExcept.ToString)
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


    Public Function getCategory2Count(ByVal KeyCategory1ID As String, _
                             ByVal KeyCategory2ID As String, _
                             ByVal KeyCategory2Name As String, _
                             ByRef Tran As System.Data.OleDb.OleDbTransaction _
                         ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Dim strSelect As String
        Dim i As Long
        Dim scnt As Integer
        Dim pc As Integer
        Dim mpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = "SELECT COUNT(*) FROM カテゴリ2マスタ "

        'パラメータ数のカウント
        pc = 0
        If KeyCategory1ID <> "" Then
            pc = pc Or 1
            mpc = 1
        End If
        If KeyCategory2ID <> "" Then
            pc = pc Or 2
            mpc = 2
        End If
        If KeyCategory2Name <> "" Then
            pc = pc Or 4
            mpc = 4
        End If

        'パラメータ指定がある場合
        If mpc And pc > 0 Then
            i = 1
            While i <= mpc
                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ1ID = """ & KeyCategory1ID & """ "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2ID = """ & KeyCategory2ID & """ "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "カテゴリ2名称 Like ""%" & KeyCategory2Name & "%"" "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            getCategory2Count = CLng(pCommand.ExecuteScalar())

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstCategoryDBIO.getCategory2Count)", Nothing, Nothing, oExcept.ToString)
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
