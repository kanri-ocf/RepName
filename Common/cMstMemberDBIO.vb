Public Class cMstMemberDBIO
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
    '　機能：会員マスタから該当レコードを取得する関数
    '----------------------------------------------------------------------
    Public Function getMember(ByRef parMember() As cStructureLib.sMember, _
                              ByVal keyMemberCode As String, _
                              ByVal keyMemberName As String, _
                              ByVal keyMemberTEL As String, _
                              ByVal keyEnable As Boolean, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM 会員マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyMemberCode <> "" Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If keyMemberName <> "" Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If keyMemberTEL <> "" Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If keyEnable = True Then
                maxpc = 8
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
                            strSelect = strSelect & "会員コード Like ""%" & keyMemberCode & "%"" "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "会員名称 Like ""%" & keyMemberName & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "TEL Like ""%" & keyMemberTEL.ToString.Replace("-"c, "%"c) & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(契約開始日 <= Now() AND 契約満了日 >= Now())"

                            '2019.11.16 R.Takashima From
                            'データベースの退会日において空白とNULLが混在しており
                            '値の抽出ができなったため、変更
                            'strSelect = strSelect & "AND 退会日 = """" "
                            strSelect = strSelect & "AND (退会日 = """" Or 退会日 IS NULL) "
                            '2019.11.16 R.Takashima To

                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parMember(i)

                '会員コード
                parMember(i).sMemberCode = pDataReader("会員コード").ToString
                '会員名称
                parMember(i).sMemberName = pDataReader("会員名称").ToString
                'サービスコード
                parMember(i).sServiceCode = CInt(pDataReader("サービスコード"))
                '郵便番号
                parMember(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                parMember(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                parMember(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                parMember(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                parMember(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parMember(i).sFAX = pDataReader("FAX").ToString
                'メールアドレス
                parMember(i).sMailAddress = pDataReader("メールアドレス").ToString
                '性別
                parMember(i).sSex = pDataReader("性別").ToString
                '生年月日
                parMember(i).sBirthday = pDataReader("生年月日").ToString
                '年齢
                parMember(i).sAge = CInt(pDataReader("年齢"))
                '入会日
                parMember(i).sEntryDate = pDataReader("入会日").ToString
                '退会日
                parMember(i).sResignDate = pDataReader("退会日").ToString
                '属性1
                parMember(i).sAttr1 = pDataReader("属性1").ToString
                '属性2
                parMember(i).sAttr2 = pDataReader("属性2").ToString
                '属性3
                parMember(i).sAttr3 = pDataReader("属性3").ToString
                '属性4
                parMember(i).sAttr4 = pDataReader("属性4").ToString
                '属性5
                parMember(i).sAttr5 = pDataReader("属性5").ToString
                '契約開始日
                parMember(i).sStartRegistDate = pDataReader("契約開始日").ToString
                '契約満了日
                parMember(i).sEndRegistDate = pDataReader("契約満了日").ToString
                '更新回数
                parMember(i).sUpdateCount = CInt(pDataReader("更新回数"))
                '補助会員名称
                parMember(i).sSubMemberName = pDataReader("補助会員名称").ToString
                '補助会員性別
                parMember(i).sSubMemberSex = pDataReader("補助会員性別").ToString

                '補助会員生年月日
                parMember(i).sSubMemberBirthDay = pDataReader("補助会員生年月日").ToString

                '補助会員年齢
                If IsDBNull(pDataReader("補助会員年齢")) = False Then
                    parMember(i).sSubMemberAge = CInt(pDataReader("補助会員年齢"))
                Else
                    parMember(i).sSubMemberAge = Nothing
                End If
                '登録日
                parMember(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parMember(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parMember(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parMember(i).sUpdateTime = pDataReader("最終更新時間").ToString

                i = i + 1

            End While
            getMember = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.getMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：指定会員コードの状態を返す
    '  戻り：0      有効会員
    '      ：-1     無効会員
    '      ：-2     該当なし
    '----------------------------------------------------------------------
    Public Function getMemberStatus(ByVal keyMemberCode As String, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Integer

        Dim strSelect As String
        Dim i As Integer
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM 会員マスタ "

            'パラメータ数のカウント
            pc = 0
            If keyMemberCode <> "" Then
                maxpc = 1
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
                            strSelect = strSelect & "会員コード Like ""%" & keyMemberCode & "%"" "
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            getMemberStatus = -2

            If pDataReader.Read() = True Then

                If (CDate(pDataReader("契約開始日").ToString) <= Now()) And (CDate(pDataReader("契約満了日").ToString) >= Now()) Then
                    getMemberStatus = 0
                End If
                If (CDate(pDataReader("契約開始日").ToString) > Now()) Or (CDate(pDataReader("契約満了日").ToString) < Now()) Then
                    getMemberStatus = -1
                End If
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.getMemberStatus)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：会員マスタから新規会員コード取得する関数
    '----------------------------------------------------------------------
    Public Function getMemberCode(ByVal keyMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As String

        Dim strSelect As String
        Dim i As Long
        Dim j As Integer
        Dim MemberCode_H As String

        getMemberCode = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            strSelect = "SELECT * FROM 会員マスタ WHERE 会員コード Like ""%" & keyMemberCode & "%"" " & _
                        "ORDER BY 会員コード"

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            getMemberCode = ""
            MemberCode_H = ""

            '会員コード
            i = 0
            While pDataReader.Read()
                MemberCode_H = pDataReader("会員コード").ToString.Substring(0, 4)
                j = CLng(pDataReader("会員コード").ToString.Substring(5, 7))
                If i < j Then
                    getMemberCode = MemberCode_H & String.Format("{0:00000000}", i)
                    Exit While
                End If
                i = i + 1
            End While
            If getMemberCode = "" Then
                getMemberCode = MemberCode_H & String.Format("{0:00000000}", i)
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.getMemberCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：会員マスタから新規会員コード取得する関数
    '----------------------------------------------------------------------
    Public Function getMemberCodeNull(ByRef parMember() As cStructureLib.sMember, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 会員マスタ WHERE 会員コード Not Like ""9931%"" "

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            i = 0

            While pDataReader.Read()

                ReDim Preserve parMember(i)

                '会員コード
                parMember(i).sMemberCode = pDataReader("会員コード").ToString
                '会員名称
                parMember(i).sMemberName = pDataReader("会員名称").ToString
                'サービスコード
                parMember(i).sServiceCode = CInt(pDataReader("サービスコード"))
                '郵便番号
                parMember(i).sPostCode = pDataReader("郵便番号").ToString
                '住所１
                parMember(i).sAddress1 = pDataReader("住所１").ToString
                '住所２
                parMember(i).sAddress2 = pDataReader("住所２").ToString
                '住所３
                parMember(i).sAddress3 = pDataReader("住所３").ToString
                'TEL
                parMember(i).sTEL = pDataReader("TEL").ToString
                'FAX
                parMember(i).sFAX = pDataReader("FAX").ToString
                'メールアドレス
                parMember(i).sMailAddress = pDataReader("メールアドレス").ToString
                '性別
                parMember(i).sSex = pDataReader("性別").ToString
                '生年月日
                parMember(i).sBirthday = pDataReader("生年月日").ToString
                '年齢
                If IsDBNull(pDataReader("年齢")) = False Then
                    parMember(i).sAge = CInt(pDataReader("年齢"))
                Else
                    parMember(i).sAge = Nothing
                End If
                '入会日
                parMember(i).sEntryDate = pDataReader("入会日").ToString
                '退会日
                parMember(i).sResignDate = pDataReader("退会日").ToString
                '属性1
                parMember(i).sAttr1 = pDataReader("属性1").ToString
                '属性2
                parMember(i).sAttr2 = pDataReader("属性2").ToString
                '属性3
                parMember(i).sAttr3 = pDataReader("属性3").ToString
                '属性4
                parMember(i).sAttr4 = pDataReader("属性4").ToString
                '属性5
                parMember(i).sAttr5 = pDataReader("属性5").ToString
                '契約開始日
                parMember(i).sStartRegistDate = pDataReader("契約開始日").ToString
                '契約満了日
                parMember(i).sEndRegistDate = pDataReader("契約満了日").ToString
                '更新回数
                parMember(i).sUpdateCount = CInt(pDataReader("更新回数"))
                '補助会員名称
                parMember(i).sSubMemberName = pDataReader("補助会員名称").ToString
                '補助会員性別
                parMember(i).sSubMemberSex = pDataReader("補助会員性別").ToString
                '補助会員生年月日
                parMember(i).sSubMemberBirthDay = pDataReader("補助会員生年月日").ToString
                '補助会員年齢
                If IsDBNull(pDataReader("補助会員年齢")) = False Then
                    parMember(i).sSubMemberAge = CInt(pDataReader("補助会員年齢"))
                Else
                    parMember(i).sSubMemberAge = Nothing
                End If
                '登録日
                parMember(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parMember(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parMember(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parMember(i).sUpdateTime = pDataReader("最終更新時間").ToString
                i = i + 1
            End While

            getMemberCodeNull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.getMemberCodeNull)", Nothing, Nothing, oExcept.ToString)
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
    Public Function readMaxMemberCode(ByVal KeyChannelCode As Integer, ByRef Tran As System.Data.OleDb.OleDbTransaction) As String
        Dim strSelect As String

        readMaxMemberCode = ""

        strSelect = "SELECT 会員コード FROM 会員マスタ " & _
                                            "WHERE 会員コード Like ""993" & KeyChannelCode & "%"" " & _
                                            "ORDER BY 会員コード DESC"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            '商品マスタから該当MAX商品コードのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader()

            If pDataReader.Read() = False Then
                readMaxMemberCode = Nothing
            Else
                readMaxMemberCode = pDataReader("会員コード").ToString
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.readMaxMemberCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：会員マスタの１レコードを更新するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function insertMember(ByVal parMember As cStructureLib.sMember, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO 会員マスタ " & _
                        "(会員コード, 会員名称, サービスコード, 郵便番号, 住所１, 住所２, 住所３, " & _
                        "TEL, FAX, メールアドレス, 性別, 生年月日, 年齢, 入会日, 退会日, " & _
                        "属性1, 属性2, 属性3, 属性4, 属性5, 契約開始日, 契約満了日, " & _
                        "更新回数, 補助会員名称, 補助会員性別, 補助会員生年月日, 補助会員年齢, " & _
                        "登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                        "VALUES " & _
                        "( @MemberCode, @MemberName, @ServiceCode, @PostCode, @Address1, @Address2, @Address3, " & _
                        "@TEL, @FAX, @MailAddress, @Sex, @Birthday, @Age, @EntryDate, @ResignDate, " & _
                        "@Attr1, @Attr2, @Attr3, @Attr4, @Attr5, @StartRegistDate, @EndRegistDate, " & _
                        "@UpdateCount, @SubMemberName, @SubMemberSex, @SubMemberBirthday, @SubMemberAge, " & _
                        "@CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strInsert

            'パラメータの設定

            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@MemberCode").Value = parMember.sMemberCode.ToString
            '会員名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MemberName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@MemberName").Value = parMember.sMemberName.ToString
            'サービスコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ServiceCode", OleDb.OleDbType.Numeric))
            pCommand.Parameters("@ServiceCode").Value = parMember.sServiceCode
            '郵便番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PostCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@PostCode").Value = parMember.sPostCode.ToString
            '住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address1", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Address1").Value = parMember.sAddress1.ToString
            '住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address2", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Address2").Value = parMember.sAddress2.ToString
            '住所３
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Address3", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Address3").Value = parMember.sAddress3.ToString
            'TEL
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TEL", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@TEL").Value = parMember.sTEL.ToString
            'FAX
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@FAX", OleDb.OleDbType.Char, 12))
            pCommand.Parameters("@FAX").Value = parMember.sFAX.ToString
            'メールアドレス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MaiAddress", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@MaiAddress").Value = parMember.sMailAddress.ToString
            '性別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Sex", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@Sex").Value = parMember.sSex.ToString
            '生年月日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Birthday", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@Birthday").Value = parMember.sBirthday.ToString
            '年齢
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Age", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@Age").Value = CInt(parMember.sAge)
            '入会日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EntryDate", OleDb.OleDbType.Date))
            pCommand.Parameters("@EntryDate").Value = parMember.sEntryDate.ToString
            '退会日
            If parMember.sResignDate = Nothing Then
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ResignDate", OleDb.OleDbType.Char, 10))
                pCommand.Parameters("@ResignDate").Value = DBNull.Value
            Else
                pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@ResignDate", OleDb.OleDbType.Char, 10))
                pCommand.Parameters("@ResignDate").Value = parMember.sResignDate.ToString
            End If
            '属性1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Attr1", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Attr1").Value = parMember.sAttr1.ToString
            '属性2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Attr2", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Attr2").Value = parMember.sAttr2.ToString
            '属性3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Attr3", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Attr3").Value = parMember.sAttr3.ToString
            '属性4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Attr4", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Attr4").Value = parMember.sAttr4.ToString
            '属性5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Attr5", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Attr5").Value = parMember.sAttr5.ToString
            '契約開始日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StartRegistDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@StartRegistDate").Value = parMember.sStartRegistDate.ToString
            '契約満了日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EndRegistDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@EndRegistDate").Value = parMember.sEndRegistDate.ToString
            '更新回数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateCount", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@UpdateCount").Value = CInt(parMember.sUpdateCount)
            '補助会員名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubMemberName", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@SubMemberName").Value = parMember.sSubMemberName.ToString
            '補助会員性別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubMemberSex", OleDb.OleDbType.Char, 1))
            pCommand.Parameters("@SubMemberSex").Value = parMember.sSubMemberSex.ToString
            '補助会員生年月日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubMemberBirthday", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@SubMemberBirthday").Value = parMember.sSubMemberBirthDay.ToString
            '補助会員年齢
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SubMemberAge", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@SubMemberAge").Value = CInt(parMember.sSubMemberAge)
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

            '会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            insertMember = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.insertMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：会員マスタの１レコードを更新するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function updateMember(ByVal parMember As cStructureLib.sMember, ByVal KeyMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim RecordCount As Integer
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 会員マスタ " & _
                                "SET 会員コード=""" & parMember.sMemberCode.ToString & """, " & _
                                "会員名称=""" & parMember.sMemberName.ToString & """, " & _
                                "サービスコード=" & parMember.sServiceCode & ", " & _
                                "郵便番号=""" & parMember.sPostCode.ToString & """, " & _
                                "住所１=""" & parMember.sAddress1.ToString & """, " & _
                                "住所２=""" & parMember.sAddress2.ToString & """, " & _
                                "住所３=""" & parMember.sAddress3.ToString & """, " & _
                                "TEL=""" & parMember.sTEL.ToString & """, " & _
                                "FAX=""" & parMember.sFAX.ToString & """, " & _
                                "メールアドレス=""" & parMember.sMailAddress.ToString & """, " & _
                                "性別=""" & parMember.sSex.ToString & """, " & _
                                "生年月日=""" & parMember.sBirthday.ToString & """, " & _
                                "年齢=" & parMember.sAge & ", " & _
                                "入会日=""" & parMember.sEntryDate.ToString & """, " & _
                                "退会日=""" & parMember.sResignDate.ToString & """, " & _
                                "属性1=""" & parMember.sAttr1.ToString & """, " & _
                                "属性2=""" & parMember.sAttr2.ToString & """, " & _
                                "属性3=""" & parMember.sAttr3.ToString & """, " & _
                                "属性4=""" & parMember.sAttr4.ToString & """, " & _
                                "属性5=""" & parMember.sAttr5.ToString & """, " & _
                                "契約開始日=""" & parMember.sStartRegistDate.ToString & """, " & _
                                "契約満了日=""" & parMember.sEndRegistDate.ToString & """, " & _
                                "更新回数=" & parMember.sUpdateCount & ", " & _
                                "補助会員名称=""" & parMember.sSubMemberName.ToString & """, " & _
                                "補助会員性別=""" & parMember.sSubMemberSex.ToString & """, " & _
                                "補助会員生年月日=""" & parMember.sSubMemberBirthDay.ToString & """, " & _
                                "補助会員年齢=" & parMember.sSubMemberAge & ", " & _
                                "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                                "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 会員コード=""" & KeyMemberCode & """ "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            '会員マスタ更新SQL文実行
            RecordCount = pCommand.ExecuteNonQuery()

            updateMember = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.updateMember)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：会員マスタの１レコードを削除するメソッド
    '　引数：in cMemberオブジェクト
    '　戻値：True  --> 更新成功.  False --> 更新失敗
    '----------------------------------------------------------------------
    Public Function deleteMember(ByVal KeyMemberCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "DELETE * FROM 会員マスタ " & _
                            "WHERE 会員マスタ.会員コード=@KeyMemberCode"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strUpdate

            'パラメータの設定

            '会員コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@KeyMemberCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@KeyMemberCode").Value = KeyMemberCode

            '会員マスタ更新SQL文実行
            deleteMember = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstMemberDBIO.deleteMember)", Nothing, Nothing, oExcept.ToString)
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
