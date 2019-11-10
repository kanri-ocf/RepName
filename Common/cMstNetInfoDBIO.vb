
Public Class cMstNetInfoDBIO
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
    '　機能：ネット掲載マスタから該当レコードを取得する関数
    '　引数：Byval parNetInfo()　：データセットバッファ（sNetInfo Structureの配列）
    '　　　：KeyProductCode　：キー情報
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    'Public Function getNetInfo(ByRef parNetInfo() As cStructureLib.sNetInfo, _
    '                                ByVal KeyProductCode As String _
    '                           ) As Long


    '----------------------------------------------------
    '2015/06/20
    '及川和彦
    'トランザクション追加
    'FROM
    '----------------------------------------------------
    Public Function getNetInfo(ByRef parNetInfo() As cStructureLib.sNetInfo, _
                                    ByVal KeyProductCode As String, _
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction _
                               ) As Long
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------


        Dim strSelect As String
        Dim i As Long

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            '----------------------------------------------------
            '2015/06/20
            '及川和彦
            'トランザクション追加
            'FROM
            '----------------------------------------------------
            pCommand.Transaction = Tran
            '----------------------------------------------------
            'HERE
            '----------------------------------------------------


            strSelect = ""

            strSelect = "SELECT * FROM ネット掲載マスタ "

            'パラメータ指定がある場合
            If KeyProductCode <> Nothing Then
                strSelect = strSelect & "WHERE 商品コード=""" & KeyProductCode & """"
            End If

            'SQL文の設定
            pCommand.CommandText = strSelect

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyProductCode

            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parNetInfo(i)

                '商品コード
                parNetInfo(i).sProductCode = pDataReader("商品コード").ToString
                'ディレクトリID
                parNetInfo(i).sDirectryID = pDataReader("ディレクトリID").ToString
                '掲載パス
                parNetInfo(i).sPath = pDataReader("掲載パス").ToString
                'METAタグ
                parNetInfo(i).sMETATag = pDataReader("METAタグ").ToString
                'META説明
                parNetInfo(i).sMETADescription = pDataReader("META説明").ToString
                '商品キャッチコピー
                parNetInfo(i).sCatchCopy = pDataReader("商品キャッチコピー").ToString
                '商品情報
                parNetInfo(i).sInformation = pDataReader("商品情報").ToString
                '商品説明文
                parNetInfo(i).sDescription = pDataReader("商品説明文").ToString
                '素材
                parNetInfo(i).sMaterial = pDataReader("素材").ToString
                '寸法－縦
                parNetInfo(i).sSizeHeight = CSng(pDataReader("寸法－縦"))
                '寸法－横
                parNetInfo(i).sSizeWide = CSng(pDataReader("寸法－横"))
                '寸法－深さ
                parNetInfo(i).sSizeDepth = CSng(pDataReader("寸法－深さ"))
                '寸法－首回り
                parNetInfo(i).sSizeNeck = CSng(pDataReader("寸法－首回り"))
                '寸法－バスト
                parNetInfo(i).sSizeBust = CSng(pDataReader("寸法－バスト"))
                '寸法－ウエスト
                parNetInfo(i).sSizeWaist = CSng(pDataReader("寸法－ウエスト"))
                '寸法－着丈
                parNetInfo(i).sSizeLength = CSng(pDataReader("寸法－着丈"))
                'おすすめ商品
                parNetInfo(i).sRecommendation = pDataReader("おすすめ商品").ToString
                '写真－１
                parNetInfo(i).sPicture1 = pDataReader("写真－１").ToString
                '写真－２
                parNetInfo(i).sPicture2 = pDataReader("写真－２").ToString
                '写真－３
                parNetInfo(i).sPicture3 = pDataReader("写真－３").ToString
                '写真－４
                parNetInfo(i).sPicture4 = pDataReader("写真－４").ToString
                '写真－５
                parNetInfo(i).sPicture5 = pDataReader("写真－５").ToString
                '登録日
                parNetInfo(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parNetInfo(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日付
                parNetInfo(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parNetInfo(i).sUpdateTime = pDataReader("最終更新時間").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getNetInfo = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstNetInfoDBIO.getNetInfo)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ネット掲載マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertNetInfoMst(ByRef parNetInfo As cStructureLib.sNetInfo, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String

        'SQL文の設定
        strInsert = "INSERT INTO ネット掲載マスタ " & _
                            "( 商品コード, ディレクトリID, 掲載パス, METAタグ, META説明, 商品キャッチコピー, 商品情報, " & _
                            "商品説明文, 素材, 寸法－縦, 寸法－横, 寸法－深さ, 寸法－首回り, 寸法－バスト, " & _
                            "寸法－ウエスト, 寸法－着丈, おすすめ商品, " & _
                            "写真－１, 写真－２, 写真－３, 写真－４, 写真－５, " & _
                            "登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
                            "VALUES ( @ProductCode, @DirectryID, @Path, @METATag, @METADescription, @CatchCopy, @Information, " & _
                            "@Description, @Material, @SizeHeight, @SizeWide, @SizeDepth, @SizeNeck, @SizeBust, " & _
                            "@SizeWaist, @SizeLength, @Recommendation, " & _
                            "@Picture1, @Picture2, @Picture3, @Picture4, @Picture5, " & _
                            "@CreateDate, @CreateTime, @UpdateDate, @UpdateTime )"

        pCommand = pConn.CreateCommand
        If Tran.Connection.DataSource <> Nothing Then
            pCommand.Transaction = Tran
        End If

        Try

            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parNetInfo.sProductCode.ToString

            'ディレクトリID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DirectryID", OleDb.OleDbType.Char, 6))
            pCommand.Parameters("@DirectryID").Value = parNetInfo.sDirectryID.ToString

            '掲載パス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Path").Value = parNetInfo.sPath.ToString

            'METAタグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@METATag", OleDb.OleDbType.Char, 160))
            pCommand.Parameters("@METATag").Value = parNetInfo.sMETATag.ToString

            'META説明
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@METADescription", OleDb.OleDbType.Char, 160))
            pCommand.Parameters("@METADescription").Value = parNetInfo.sMETADescription.ToString

            '商品キャッチコピー
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CatchCopy", OleDb.OleDbType.Char, 60))
            pCommand.Parameters("@CatchCopy").Value = parNetInfo.sCatchCopy.ToString

            '商品情報
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Information", OleDb.OleDbType.VarWChar))
            pCommand.Parameters("@Information").Value = parNetInfo.sInformation.ToString

            '商品説明文
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Description", OleDb.OleDbType.VarWChar))
            pCommand.Parameters("@Description").Value = parNetInfo.sDescription.ToString

            '素材
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Material", OleDb.OleDbType.Char, 60))
            pCommand.Parameters("@Material").Value = parNetInfo.sMaterial.ToString

            '寸法－縦
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeHeight", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeHeight").Value = CSng(parNetInfo.sSizeHeight)

            '寸法－横
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeWide", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeWide").Value = CSng(parNetInfo.sSizeWide)

            '寸法－深さ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeDepth", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeDepth").Value = CSng(parNetInfo.sSizeDepth)

            '寸法－首回り
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeNeck", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeNeck").Value = CSng(parNetInfo.sSizeNeck)

            '寸法－バスト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeBust", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeBust").Value = CSng(parNetInfo.sSizeBust)

            '寸法－ウエスト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeWaist", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeWaist").Value = CSng(parNetInfo.sSizeWaist)

            '寸法－着丈
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeLength", OleDb.OleDbType.Single))
            pCommand.Parameters("@SizeLength").Value = CSng(parNetInfo.sSizeLength)

            'おすすめ商品
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Recommendation", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Recommendation").Value = parNetInfo.sRecommendation.ToString

            '写真－１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture1", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture1").Value = parNetInfo.sPicture1.ToString

            '写真－２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture2", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture2").Value = parNetInfo.sPicture2.ToString

            '写真－３
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture3", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture3").Value = parNetInfo.sPicture3.ToString

            '写真－４
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture4", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture4").Value = parNetInfo.sPicture4.ToString

            '写真－５
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture5", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture5").Value = parNetInfo.sPicture5.ToString

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            If parNetInfo.sCreateDate = Nothing Then
                pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            Else
                pCommand.Parameters("@CreateDate").Value = parNetInfo.sCreateDate.ToString
            End If

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            If parNetInfo.sCreateTime = Nothing Then
                pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)
            Else
                pCommand.Parameters("@CreateTime").Value = parNetInfo.sCreateTime.ToString
            End If

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            'ネット掲載マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertNetInfoMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstNetInfoDBIO.insertNetInfoMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ネット掲載マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateNetInfoMst(ByRef parNetInfo() As cStructureLib.sNetInfo, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        'SQL文の設定
        Const strUpdate As String = "UPDATE ネット掲載マスタ " & _
                                            "SET ディレクトリID=@DirectryID, 掲載パス=@Path, METAタグ=@METATag, " & _
                                            "META説明=@METADescripution, 商品キャッチコピー=@CatchCopy, 商品情報=@Information, " & _
                                            "商品説明文=@Description, 素材=@Material, 寸法－縦=@SizeHeight, 寸法－横=@SizeWide, " & _
                                            "寸法－深さ=@SizeDepth, 寸法－首回り=@SizeNeck, 寸法－バスト=@SizeBust, " & _
                                            "寸法－ウエスト=@SizeWaist, 寸法－着丈=@SizeLength, おすすめ商品=@Recommendation, " & _
                                            "写真－１=@Picture1, 写真－２=@Picture2, 写真－３=@Picture3, 写真－４=@Picture4, 写真－５=@Picture5, " & _
                                            "最終更新日=@UpdateDate, 最終更新時間=@UpdateTime " & _
                                            "WHERE 商品コード=@ProductCode"


        pCommand = pConn.CreateCommand
        If Tran.Connection.DataSource <> Nothing Then
            pCommand.Transaction = Tran
        End If

        Try

            pCommand.CommandText = strUpdate

            '***********************
            '   パラメータの設定
            '***********************
            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parNetInfo(0).sProductCode.ToString

            'ディレクトリID
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@DirectryID", OleDb.OleDbType.Char, 6))
            pCommand.Parameters("@DirectryID").Value = parNetInfo(0).sDirectryID.ToString

            '掲載パス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Path", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Path").Value = parNetInfo(0).sPath.ToString

            'METAタグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@METATag", OleDb.OleDbType.Char, 160))
            pCommand.Parameters("@METATag").Value = parNetInfo(0).sMETATag.ToString

            'META説明
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@METADescripution", OleDb.OleDbType.Char, 160))
            pCommand.Parameters("@METADescripution").Value = parNetInfo(0).sMETADescription.ToString

            '商品キャッチコピー
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CatchCopy", OleDb.OleDbType.Char, 60))
            pCommand.Parameters("@CatchCopy").Value = parNetInfo(0).sCatchCopy.ToString

            '商品情報
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Information", OleDb.OleDbType.Char, 1000))
            pCommand.Parameters("@Information").Value = parNetInfo(0).sInformation.ToString

            '商品説明文
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Description", OleDb.OleDbType.Char, 10000))
            pCommand.Parameters("@Description").Value = parNetInfo(0).sDescription.ToString

            '素材
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Material", OleDb.OleDbType.Char, 60))
            pCommand.Parameters("@Material").Value = parNetInfo(0).sMaterial.ToString

            '寸法－縦
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeHeight", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeHeight").Value = CSng(parNetInfo(0).sSizeHeight)

            '寸法－横
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeWide", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeWide").Value = CSng(parNetInfo(0).sSizeWide)

            '寸法－深さ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeDepth", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeDepth").Value = CSng(parNetInfo(0).sSizeDepth)

            '寸法－首回り
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeNeck", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeNeck").Value = CSng(parNetInfo(0).sSizeNeck)

            '寸法－バスト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeBust", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeBust").Value = CSng(parNetInfo(0).sSizeBust)

            '寸法－ウエスト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeWaist", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeWaist").Value = CSng(parNetInfo(0).sSizeWaist)

            '寸法－着丈
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SizeLength", OleDb.OleDbType.Numeric, 3, 2))
            pCommand.Parameters("@SizeLength").Value = CSng(parNetInfo(0).sSizeLength)

            'おすすめ商品
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Recommendation", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Recommendation").Value = parNetInfo(0).sRecommendation.ToString

            '写真－１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture1", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture1").Value = parNetInfo(0).sPicture1.ToString

            '写真－２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture2", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture2").Value = parNetInfo(0).sPicture2.ToString

            '写真－３
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture3", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture3").Value = parNetInfo(0).sPicture3.ToString

            '写真－４
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture4", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture4").Value = parNetInfo(0).sPicture4.ToString

            '写真－５
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Picture5", OleDb.OleDbType.Char, 128))
            pCommand.Parameters("@Picture5").Value = parNetInfo(0).sPicture5.ToString

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            'ネット掲載マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            updateNetInfoMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstNetInfoDBIO.updateNetInfoMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：ネット掲載マスタから１レコードを削除するメソッド
    '　引数：なし
    '　戻値：True  --> 削除完了  False --> 削除するレコードなし
    '----------------------------------------------------------------------
    Public Function deleteNetInfoMst(ByVal KeyProductCode As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Const strDeletePrdMst As String = "DELETE FROM ネット掲載マスタ WHERE 商品コード=@ProductCode "

        pCommand = pConn.CreateCommand
        If Tran.Connection.DataSource <> Nothing Then
            pCommand.Transaction = Tran
        End If

        Try
            'SQL文の設定
            pCommand.CommandText = strDeletePrdMst

            'SQL文パラメータの設定
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = KeyProductCode

            deleteNetInfoMst = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstNetInfoDBIO.deleteNetInfoMst)", Nothing, Nothing, oExcept.ToString)
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
