
Public Class cMstProductDBIO
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
    '　機能：商品マスタおよび価格マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProductPrice(ByRef parProductPrice() As cStructureLib.sViewProductPrice,
                               ByVal KeyChannelCode As Integer,
                               ByVal KeyProductCode As String,
                               ByVal KeyJanCode As String,
                               ByVal KeySupplierCode As Integer,
                               ByRef Tran As OleDb.OleDbTransaction) As Long

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

            strSelect = "SELECT DISTINCT 商品マスタ.商品コード AS 商品コード, " &
                                "販売価格マスタ.チャネルコード AS チャネルコード, " &
                                "チャネルマスタ.チャネル名称 AS チャネル名称, " &
                                "仕入先マスタ.仕入先コード AS 仕入先コード, " &
                                "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                                "商品マスタ.SEQコード AS SEQコード, " &
                                "商品マスタ.JANコード AS JANコード, " &
                                "商品マスタ.商品種別 AS 商品種別, " &
                                "商品マスタ.商品名称 AS 商品名称, " &
                                "商品マスタ.商品略称 AS 商品略称, " &
                                "商品マスタ.メーカー名称 AS メーカー名称, " &
                                "商品マスタ.オプション1 AS オプション1, " &
                                "商品マスタ.オプション2 AS オプション2, " &
                                "商品マスタ.オプション3 AS オプション3, " &
                                "商品マスタ.オプション4 AS オプション4, " &
                                "商品マスタ.オプション5 AS オプション5, " &
                                "商品マスタ.適用 AS 適用, " &
                                "商品マスタ.定価 AS 定価, " &
                                "仕入価格マスタ.仕入単価 AS 仕入価格, " &
                                "販売価格マスタ.販売単価 AS 販売価格, " &
                                "商品マスタ.適正在庫数 AS 適正在庫数, " &
                                "商品マスタ.PLUコード AS PLUコード, " &
                                "商品マスタ.販売停止フラグ AS 販売停止フラグ, " &
                                "商品マスタ.仕入停止フラグ AS 仕入停止フラグ, " &
                                "商品マスタ.Yahoo掲載フラグ AS Yahoo掲載フラグ, " &
                                "商品マスタ.楽天掲載フラグ AS 楽天掲載フラグ, " &
                                "商品マスタ.Amazon掲載フラグ AS Amazon掲載フラグ, " &
                                "商品マスタ.eShop掲載フラグ AS eShop掲載フラグ, " &
                                "商品マスタ.登録日 AS 登録日, " &
                                "商品マスタ.登録時間 AS 登録時間, " &
                                "商品マスタ.最終更新日 AS 最終更新日, " &
                                "商品マスタ.最終更新時間 AS 最終更新時間, " &
                                "商品マスタ.軽減税率 AS 軽減税率 " &
                            "FROM (((商品マスタ LEFT JOIN 仕入価格マスタ ON " &
                                    "商品マスタ.商品コード = 仕入価格マスタ.商品コード) LEFT JOIN " &
                                    "仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード) " &
                                    "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " &
                                    "LEFT JOIN チャネルマスタ ON 販売価格マスタ.チャネルコード = チャネルマスタ.チャネルコード " &
                            "WHERE 適用開始日 <= """ & String.Format("{0:yyyy/MM/dd}", Now) & """" &
                                " AND 適用終了日 >= """ & String.Format("{0:yyyy/MM/dd}", Now) & """" &
                                " AND 商品マスタ.販売停止フラグ = False "


            'パラメータ数のカウント
            pc = 0
            If KeyChannelCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyProductCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyJanCode <> Nothing Then
                maxpc = 4
                pc = pc Or maxpc
            End If
            If KeySupplierCode <> Nothing Then
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
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJanCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "仕入先マスタ.仕入先コード = " & KeySupplierCode & " "
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


                ReDim Preserve parProductPrice(i)

                '商品コード
                parProductPrice(i).sProductCode = pDataReader("商品コード").ToString
                'チャネルコード
                parProductPrice(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                'チャネル名称
                parProductPrice(i).sChannelName = pDataReader("チャネル名称").ToString
                '仕入先コード
                parProductPrice(i).sSupplierCode = CInt(pDataReader("仕入先コード"))
                '仕入先名称
                parProductPrice(i).sSupplierName = pDataReader("仕入先名称").ToString
                'SEQコード
                parProductPrice(i).sSEQCode = pDataReader("SEQコード").ToString
                'JANコード
                parProductPrice(i).sJANCode = pDataReader("JANコード").ToString
                '商品種別
                parProductPrice(i).sProductClass = CInt(pDataReader("商品種別"))
                '商品名称
                parProductPrice(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductPrice(i).sProductShortName = pDataReader("商品略称").ToString
                'メーカー名称
                parProductPrice(i).sMakerName = pDataReader("メーカー名称").ToString
                'オプション1
                parProductPrice(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductPrice(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductPrice(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductPrice(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductPrice(i).sOption5 = pDataReader("オプション5").ToString
                '適用
                parProductPrice(i).sMemo = pDataReader("適用").ToString
                '定価
                parProductPrice(i).sPrice = CLng(pDataReader("定価"))
                '仕入価格
                parProductPrice(i).sCostPrice = CLng(pDataReader("仕入価格"))
                '販売価格
                parProductPrice(i).sSalePrice = CLng(pDataReader("販売価格"))
                '適正在庫数
                parProductPrice(i).sMinStock = CLng(pDataReader("適正在庫数"))
                'PLUコード
                parProductPrice(i).sPLUCode = pDataReader("PLUコード").ToString
                '販売停止フラグ
                parProductPrice(i).sStopSaleFlg = pDataReader("販売停止フラグ")
                '仕入停止フラグ
                parProductPrice(i).sSupplieStopFlg = pDataReader("仕入停止フラグ")
                'Yahoo掲載フラグ
                parProductPrice(i).sYahooFlg = pDataReader("Yahoo掲載フラグ")
                '楽天掲載フラグ
                parProductPrice(i).sRakutenFlg = pDataReader("楽天掲載フラグ")
                'Amazon掲載フラグ
                parProductPrice(i).sAmazonFlg = pDataReader("Amazon掲載フラグ")
                'eShop掲載フラグ
                parProductPrice(i).seShopFlg = pDataReader("eShop掲載フラグ")

                '2019/08/07 shimizu add start'
                '軽減税率
                parProductPrice(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '2019/08/07 shimizu add end'

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProductPrice = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProductPrice)", Nothing, Nothing, oExcept.ToString)
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



    '----------------------------------------------------
    '2015/06/20
    '及川和彦
    '入庫処理時に商品マスタを変更した際に商品価格を反映する
    'FROM
    '----------------------------------------------------
    '-------------------------------------------------------------------------------
    '　機能：商品マスタおよび価格マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProductPriceArrival(ByRef parProductPrice() As cStructureLib.sViewProductPrice,
                                           ByVal KeyProductCode As String,
                                           ByVal KeySupplierName As String,
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

            strSelect = "SELECT DISTINCT 商品マスタ.商品コード AS 商品コード, " &
                                "仕入先マスタ.仕入先コード AS 仕入先コード, " &
                                "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                                "商品マスタ.SEQコード AS SEQコード, " &
                                "商品マスタ.JANコード AS JANコード, " &
                                "商品マスタ.商品種別 AS 商品種別, " &
                                "商品マスタ.商品名称 AS 商品名称, " &
                                "商品マスタ.商品略称 AS 商品略称, " &
                                "商品マスタ.メーカー名称 AS メーカー名称, " &
                                "商品マスタ.オプション1 AS オプション1, " &
                                "商品マスタ.オプション2 AS オプション2, " &
                                "商品マスタ.オプション3 AS オプション3, " &
                                "商品マスタ.オプション4 AS オプション4, " &
                                "商品マスタ.オプション5 AS オプション5, " &
                                "商品マスタ.適用 AS 適用, " &
                                "商品マスタ.定価 AS 定価, " &
                                "仕入価格マスタ.仕入単価 AS 仕入価格, " &
                                "商品マスタ.適正在庫数 AS 適正在庫数, " &
                                "商品マスタ.PLUコード AS PLUコード, " &
                                "商品マスタ.販売停止フラグ AS 販売停止フラグ, " &
                                "商品マスタ.仕入停止フラグ AS 仕入停止フラグ, " &
                                "商品マスタ.Yahoo掲載フラグ AS Yahoo掲載フラグ, " &
                                "商品マスタ.楽天掲載フラグ AS 楽天掲載フラグ, " &
                                "商品マスタ.Amazon掲載フラグ AS Amazon掲載フラグ, " &
                                "商品マスタ.eShop掲載フラグ AS eShop掲載フラグ, " &
                                "商品マスタ.登録日 AS 登録日, " &
                                "商品マスタ.登録時間 AS 登録時間, " &
                                "商品マスタ.最終更新日 AS 最終更新日, " &
                                "商品マスタ.最終更新時間 AS 最終更新時間 " &
                                "商品マスタ.軽減税率 AS 軽減税率 " &
                            "FROM ((商品マスタ LEFT JOIN 仕入価格マスタ ON " &
                                    "商品マスタ.商品コード = 仕入価格マスタ.商品コード) LEFT JOIN " &
                                    "仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード) "

            '----------------------------------------------------
            'ocf　鈴木　2019/09/20　end
            '----------------------------------------------------

            'パラメータ数のカウント
            pc = 0
            If KeyProductCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeySupplierName <> Nothing Then
                maxpc = 2
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
                            strSelect = strSelect & "商品マスタ.商品コード =""" & KeyProductCode & """ "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "仕入先マスタ.仕入先名称 = """ & KeySupplierName & """ "
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


                ReDim Preserve parProductPrice(i)

                parProductPrice(i).sProductCode = pDataReader("商品コード")
                parProductPrice(i).sProductName = pDataReader("商品名称")
                parProductPrice(i).sProductShortName = pDataReader("商品略称")
                parProductPrice(i).sJANCode = pDataReader("JANコード")
                parProductPrice(i).sOption1 = pDataReader("オプション1")
                parProductPrice(i).sOption2 = pDataReader("オプション2")
                parProductPrice(i).sOption3 = pDataReader("オプション3")
                parProductPrice(i).sOption4 = pDataReader("オプション4")
                parProductPrice(i).sOption5 = pDataReader("オプション5")
                parProductPrice(i).sCostPrice = CLng(pDataReader("仕入価格"))
                '----------------------------------------------------
                'ocf　鈴木　2019/09/20
                '----------------------------------------------------
                parProductPrice(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '----------------------------------------------------
                'end
                '----------------------------------------------------

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProductPriceArrival = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProductPrice)", Nothing, Nothing, oExcept.ToString)
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

    '----------------------------------------------------
    'HERE
    '----------------------------------------------------



    '-------------------------------------------------------------------------------
    '　機能：商品マスタおよび価格マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProductSalePrice(ByRef parProductSalePrice() As cStructureLib.sViewProductSalePrice,
                               ByVal KeyChannelCode As Integer,
                               ByVal KeyProductCode As String,
                               ByVal KeyJanCode As String,
                               ByRef Tran As OleDb.OleDbTransaction) As Long

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

            strSelect = "SELECT DISTINCT " &
                                "商品マスタ.商品コード, " &
                                "販売価格マスタ.チャネルコード, " &
                                "商品マスタ.JANコード, " &
                                "商品マスタ.商品種別, " &
                                "商品マスタ.商品名称, " &
                                "商品マスタ.商品略称, " &
                                "商品マスタ.メーカー名称, " &
                                "商品マスタ.オプション1, " &
                                "商品マスタ.オプション2, " &
                                "商品マスタ.オプション3, " &
                                "商品マスタ.オプション4, " &
                                "商品マスタ.オプション5, " &
                                "商品マスタ.適用, " &
                                "商品マスタ.定価, " &
                                "商品マスタ.軽減税率, " &
                                "販売価格マスタ.販売単価 " &
                            "FROM 商品マスタ LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード " &
                            "WHERE 適用開始日 <= """ & String.Format("{0:yyyy/MM/dd}", Now) & """" &
                                " AND 適用終了日 >= """ & String.Format("{0:yyyy/MM/dd}", Now) & """" &
                                " AND 商品マスタ.販売停止フラグ = False "
            '商品マスタ.軽減税率 追加 R.Takashima 2019.10.5
            '
            'パラメータ数のカウント
            pc = 0
            If KeyChannelCode <> Nothing Then
                maxpc = 1
                pc = pc Or maxpc
            End If
            If KeyProductCode <> Nothing Then
                maxpc = 2
                pc = pc Or maxpc
            End If
            If KeyJanCode <> Nothing Then
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
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            strSelect = strSelect & "AND "
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJanCode & "%"" "
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

                ReDim Preserve parProductSalePrice(i)

                '商品コード
                parProductSalePrice(i).sProductCode = pDataReader("商品コード").ToString
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parProductSalePrice(i).sChannelCode = 0
                Else
                    parProductSalePrice(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'JANコード
                parProductSalePrice(i).sJANCode = pDataReader("JANコード").ToString
                '商品種別
                If IsDBNull(pDataReader("商品種別")) = True Then
                    parProductSalePrice(i).sProductClass = 0
                Else
                    parProductSalePrice(i).sProductClass = CInt(pDataReader("商品種別"))
                End If
                '商品名称
                parProductSalePrice(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProductSalePrice(i).sProductShortName = pDataReader("商品略称").ToString
                'メーカー名称
                parProductSalePrice(i).sMakerName = pDataReader("メーカー名称").ToString
                'オプション1
                parProductSalePrice(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductSalePrice(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductSalePrice(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductSalePrice(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductSalePrice(i).sOption5 = pDataReader("オプション5").ToString
                '適用
                parProductSalePrice(i).sMemo = pDataReader("適用").ToString
                '定価
                If IsDBNull(pDataReader("定価")) = True Then
                    parProductSalePrice(i).sListPrice = 0
                Else
                    parProductSalePrice(i).sListPrice = CLng(pDataReader("定価"))
                End If

                '2019.10.5 R.Takashima FROM
                '軽減税率
                If pDataReader("軽減税率").ToString = "" Or pDataReader("軽減税率").ToString = "0" Then
                    parProductSalePrice(i).sReducedTaxRate = False
                Else
                    parProductSalePrice(i).sReducedTaxRate = True
                End If
                '2019.10.5 R.Takashima TO

                '販売単価
                If IsDBNull(pDataReader("販売単価")) = True Then
                    parProductSalePrice(i).sSalePrice = 0
                Else
                    parProductSalePrice(i).sSalePrice = CLng(pDataReader("販売単価"))
                End If
                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProductSalePrice = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProductSalePrice)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProduct(ByRef parProduct() As cStructureLib.sProduct,
                                    ByVal KeyJANCode As String,
                                    ByVal KeyProductCode As String,
                                    ByVal KeyProductName As String,
                                    ByVal KeyOptionName As String,
                                    ByVal KeySupplierName As String,
                                    ByVal KeyMakerName As String,
                                    ByVal KeySalseQuitFlg As Boolean,
                                    ByVal KeySupplieStopFlg As Boolean,
                                    ByVal KeyProductClass As Integer,
                                    ByRef Tran As System.Data.OleDb.OleDbTransaction
                               ) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        '----------------------------------------------------
        'ocf　鈴木　2019/09/20
        '----------------------------------------------------
        strSelect = ""

        strSelect = "SELECT DISTINCT 商品マスタ.商品コード as 商品コード, " &
                             "商品マスタ.SEQコード as SEQコード, " &
                             "商品マスタ.JANコード as JANコード, " &
                             "商品マスタ.商品種別 as 商品種別, " &
                             "商品マスタ.商品名称 as 商品名称, " &
                             "商品マスタ.商品略称 as 商品略称, " &
                             "商品マスタ.メーカー名称 as メーカー名称, " &
                             "商品マスタ.オプション1 as オプション1, " &
                             "商品マスタ.オプション2 as オプション2, " &
                             "商品マスタ.オプション3 as オプション3, " &
                             "商品マスタ.オプション4 as オプション4, " &
                             "商品マスタ.オプション5 as オプション5, " &
                             "商品マスタ.適用 as 適用, " &
                             "商品マスタ.定価 as 定価, " &
                             "商品マスタ.PLUコード as PLUコード, " &
                             "商品マスタ.販売停止フラグ as 販売停止フラグ, " &
                             "商品マスタ.仕入停止フラグ as 仕入停止フラグ, " &
                             "商品マスタ.Yahoo掲載フラグ as Yahoo掲載フラグ, " &
                             "商品マスタ.楽天掲載フラグ as 楽天掲載フラグ, " &
                             "商品マスタ.Amazon掲載フラグ as Amazon掲載フラグ, " &
                             "商品マスタ.eShop掲載フラグ as eShop掲載フラグ, " &
                             "商品マスタ.適正在庫数 as 適正在庫数, " &
                             "商品マスタ.登録日 as 登録日, " &
                             "商品マスタ.登録時間 as 登録時間, " &
                             "商品マスタ.最終更新日 as 最終更新日, " &
                             "商品マスタ.最終更新時間 as 最終更新時間, " &
                             "商品マスタ.軽減税率 AS 軽減税率 " &
                             "FROM (商品マスタ LEFT JOIN 仕入価格マスタ ON " &
                                    "商品マスタ.商品コード = 仕入価格マスタ.商品コード) LEFT JOIN " &
                                    "仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード "

        '----------------------------------------------------
        'ocf　鈴木　2019/09/20　end
        '----------------------------------------------------

        'パラメータ数のカウント
        pc = 0
        If KeyJANCode <> Nothing And KeyJANCode <> "" Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyProductCode <> Nothing And KeyProductCode <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyProductName <> Nothing And KeyProductName <> "" Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyOptionName <> Nothing And KeyOptionName <> "" Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeySupplierName <> Nothing And KeySupplierName <> "" Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyMakerName <> Nothing And KeyMakerName <> "" Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeySalseQuitFlg <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If
        If KeySupplieStopFlg <> Nothing Then
            maxpc = 128
            pc = pc Or maxpc
        End If
        If KeyProductClass <> Nothing Then
            maxpc = 256
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
                        strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "("
                        strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                        strSelect = strSelect & "OR (商品マスタ.オプション2 Like ""%" & KeyOptionName & "%"") "
                        strSelect = strSelect & "OR (商品マスタ.オプション3 Like ""%" & KeyOptionName & "%"") "
                        strSelect = strSelect & "OR (商品マスタ.オプション4 Like ""%" & KeyOptionName & "%"") "
                        strSelect = strSelect & "OR (商品マスタ.オプション5 Like ""%" & KeyOptionName & "%"") "
                        strSelect = strSelect & ") "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(仕入先マスタ.仕入先名称) Like ""%" & KeySupplierName & "%"" "
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.メーカー名称 Like ""%" & KeyMakerName & "%"" "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.販売停止フラグ=" & KeySalseQuitFlg & " "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.仕入停止フラグ=" & KeySupplieStopFlg & " "
                        scnt = scnt + 1
                    Case 256
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品マスタ.商品種別=" & KeyProductClass & " "
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

            While pDataReader.Read()


                ReDim Preserve parProduct(i)

                '商品コード
                parProduct(i).sProductCode = pDataReader("商品コード").ToString
                'SEQコード
                parProduct(i).sSEQCode = pDataReader("SEQコード").ToString
                'JANコード
                parProduct(i).sJANCode = pDataReader("JANコード").ToString
                '商品種別
                parProduct(i).sProductClass = CInt(pDataReader("商品種別"))
                '商品名称
                parProduct(i).sProductName = pDataReader("商品名称").ToString
                '商品略称
                parProduct(i).sProductShortName = pDataReader("商品略称").ToString
                'メーカー名称
                parProduct(i).sMakerName = pDataReader("メーカー名称").ToString
                'オプション1
                parProduct(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProduct(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProduct(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProduct(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProduct(i).sOption5 = pDataReader("オプション5").ToString
                '適用
                parProduct(i).sMemo = pDataReader("適用").ToString
                '定価
                parProduct(i).sListPrice = CLng(pDataReader("定価"))
                'PLUコード
                parProduct(i).sPLUCode = pDataReader("PLUコード").ToString
                '販売停止フラグ
                parProduct(i).sStopSaleFlg = pDataReader("販売停止フラグ")
                '仕入停止フラグ
                parProduct(i).sStopSupplieFlg = pDataReader("仕入停止フラグ")
                'Yahoo掲載フラグ
                parProduct(i).sYahooFlg = pDataReader("Yahoo掲載フラグ")
                '楽天掲載フラグ
                parProduct(i).sRakutenFlg = pDataReader("楽天掲載フラグ")
                'Amazon掲載フラグ
                parProduct(i).sAmazonFlg = pDataReader("Amazon掲載フラグ")
                'eShop掲載フラグ
                parProduct(i).seShopFlg = pDataReader("eShop掲載フラグ")
                '登録日
                parProduct(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                parProduct(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日
                parProduct(i).sUpdateDate = pDataReader("最終更新日").ToString
                '最終更新時間
                parProduct(i).sUpdateTime = pDataReader("最終更新時間").ToString

                '----------------------------------------------------
                'ocf　鈴木　2019/09/20
                '----------------------------------------------------
                '軽減税率
                parProduct(i).sReducedTaxRate = pDataReader("軽減税率").ToString
                '----------------------------------------------------
                'ocf　鈴木　2019/09/20　end
                '----------------------------------------------------

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProduct = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProduct)", Nothing, Nothing, oExcept.ToString)
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

    '
    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getNetProduct(ByRef parProduct() As cStructureLib.sViewProductPlusSalePrice,
                                    ByVal KeyProductCode As String,
                                    ByVal KeyNetProductCode As String,
                                    ByVal KeyChannelCode As Integer,
                                    ByRef Tran As OleDb.OleDbTransaction
                               ) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT DISTINCT 商品コード変換マスタ.商品コード as 商品コード, " &
                             "販売価格マスタ.販売単価 as 販売価格 " &
                             "FROM 商品コード変換マスタ LEFT JOIN 販売価格マスタ " &
                                    "ON (商品コード変換マスタ.商品コード = 販売価格マスタ.商品コード) " &
                                    "AND (商品コード変換マスタ.チャネルコード = 販売価格マスタ.チャネルコード) "


        'パラメータ数のカウント
        pc = 0
        If KeyProductCode <> Nothing And KeyProductCode <> "" Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyNetProductCode <> Nothing And KeyNetProductCode <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyChannelCode <> Nothing Then
            maxpc = 4
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
                        strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "商品コード変換マスタ.チャネル商品コード Like ""%" & KeyNetProductCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        If scnt > 0 Then
            strSelect = strSelect & "AND "
        Else
            strSelect = strSelect & "WHERE "
        End If
        strSelect = strSelect & "販売価格マスタ.適用開始日 <= """ & String.Format("{0:yyyy/MM/dd}", Now) &
                                """ AND  販売価格マスタ.適用終了日 >= """ & String.Format("{0:yyyy/MM/dd}", Now) & """ "

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parProduct(i)

                '商品コード
                parProduct(i).sProductCode = pDataReader("商品コード").ToString
                '販売価格
                parProduct(i).sSalePrice = CLng(pDataReader("販売価格"))

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getNetProduct = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getNetProduct)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタからユニークなメーカー名称を取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getMaker(ByRef parMakerName() As String, ByVal KeyMakerName As String, ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT DISTINCT 商品マスタ.メーカー名称 AS メーカー名称 " &
                        "FROM 商品マスタ "

        If KeyMakerName <> "" Then
            strSelect = strSelect & "WHERE 商品マスタ.メーカー名称 Like ""%" & KeyMakerName & "%"" "
        End If

        strSelect = strSelect & "ORDER BY 商品マスタ.メーカー名称 "

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parMakerName(i)

                '商品コード
                parMakerName(i) = pDataReader("メーカー名称").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getMaker = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getMaker)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Windows.Forms.Application.Exit()
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Function readMaxPrdMstCode(ByVal KeyProductCode As String, ByRef Tran As OleDb.OleDbTransaction) As String
        Dim strSelectPrd As String

        readMaxPrdMstCode = ""

        strSelectPrd = "SELECT 商品コード FROM 商品マスタ " &
                                            "WHERE 商品コード Like ""%" & KeyProductCode & "%"" " &
                                            "ORDER BY 商品コード DESC"

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectPrd

            '商品マスタから該当MAX商品コードのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() = Nothing Then
                readMaxPrdMstCode = Nothing
            Else
                readMaxPrdMstCode = pDataReader("商品コード").ToString
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.readMaxPrdMstCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Windows.Forms.Application.Exit()
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    Public Function read_UnUse_PrdMstCode(ByVal KeyCategory As String, ByRef Tran As OleDb.OleDbTransaction) As String
        Dim strSelectPrd As String

        read_UnUse_PrdMstCode = ""

        strSelectPrd = "SELECT MIN(A.SEQコード + 1) AS UnUseCode " &
                            "FROM (SELECT SEQコード FROM 商品マスタ WHERE 商品コード Like ""%" & KeyCategory & "%"") AS A " &
                            "WHERE NOT EXISTS " &
                            "(SELECT * FROM 商品マスタ " &
                            "WHERE SEQコード =A.SEQコード + 1) "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectPrd

            '商品マスタから該当MAX商品コードのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() = Nothing Then
                read_UnUse_PrdMstCode = Nothing
            Else
                read_UnUse_PrdMstCode = Chr(CInt((pDataReader("UnUseCode").ToString.Substring(0, 2)))) &
                                        Chr(CInt((pDataReader("UnUseCode").ToString.Substring(2, 2)))) &
                                        pDataReader("UnUseCode").ToString.Substring(4, 3)
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.read_UnUse_PrdMstCode)", Nothing, Nothing, oExcept.ToString)
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
    Public Function read_Same_PrdMstCode(ByVal KeyProductName As String,
                                            ByVal KeyCategory As String,
                                            ByRef Tran As OleDb.OleDbTransaction) As String
        Dim strSelectPrd As String

        read_Same_PrdMstCode = ""

        strSelectPrd = "SELECT 商品コード, 商品名称 " &
                            "FROM 商品マスタ " &
                            "WHERE 商品名称 Like ""%" & KeyProductName & "%"" " &
                            "AND 商品コード Like ""%" & KeyCategory & "%"" " &
                            "ORDER BY 商品コード DESC "

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelectPrd

            '商品マスタから該当MAX商品コードのレコード読込 
            '取得レコードが1件の時は、引数にCommandBehavior.SingleRowを指定
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() = Nothing Or KeyProductName = "" Then
                read_Same_PrdMstCode = Nothing
            Else
                read_Same_PrdMstCode = pDataReader("商品コード").ToString.Substring(0, 6) &
                                        String.Format("{0:00}", CInt(pDataReader("商品コード").ToString.Substring(6, 2)))
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.read_Same_PrdMstCode)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertProductMst(ByRef parProduct() As cStructureLib.sProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strInsert As String
        '----------------------------------------------------
        'ocf　鈴木　2019/09/20
        '----------------------------------------------------
        'SQL文の設定
        strInsert = "INSERT INTO 商品マスタ ( " &
                        "商品コード, " &
                        "SEQコード, " &
                        "JANコード, " &
                        "商品種別, " &
                        "商品名称, " &
                        "商品略称, " &
                        "メーカー名称, " &
                        "オプション1, " &
                        "オプション2, " &
                        "オプション3, " &
                        "オプション4, " &
                        "オプション5, " &
                        "適用, " &
                        "定価, " &
                        "適正在庫数, " &
                        "PLUコード, " &
                        "販売停止フラグ, " &
                        "仕入停止フラグ, " &
                        "Yahoo掲載フラグ, " &
                        "楽天掲載フラグ, " &
                        "Amazon掲載フラグ, " &
                        "eShop掲載フラグ, " &
                        "登録日, " &
                        "登録時間, " &
                        "最終更新日, " &
                        "最終更新時間, " &
                        "軽減税率" &
                    ") VALUES (" &
                        "@ProductCode, " &
                        "@SEQCode, " &
                        "@JANCode, " &
                        "@ProductClass, " &
                        "@ProductName, " &
                        "@ProductShortName, " &
                        "@MakerName, " &
                        "@Option1, " &
                        "@Option2, " &
                        "@Option3, " &
                        "@Option4, " &
                        "@Option5, " &
                        "@Memo, " &
                        "@ListPrice, " &
                        "@MinStock, " &
                        "@PLUCode, " &
                        "@StopSaleFlg, " &
                        "@StopSupplieFlg, " &
                        "@YahooFlg, " &
                        "@RakutenFlg, " &
                        "@AmazonFlg, " &
                        "@OriginalFlg, " &
                        "@CreateDate, " &
                        "@CreateTime, " &
                        "@UpdateDate, " &
                        "@UpdateTime, " &
                        "@ReducedTaxRatea " &
                    ")"
        '----------------------------------------------------
        'ocf　鈴木　2019/09/20　end
        '----------------------------------------------------

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try
            pCommand.CommandText = strInsert

            '***********************
            '   パラメータの設定
            '***********************

            '商品コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductCode", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ProductCode").Value = parProduct(0).sProductCode
            'SEQコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@SEQCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@SEQCode").Value = parProduct(0).sSEQCode
            'JANコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@JANCode", OleDb.OleDbType.Char, 13))
            pCommand.Parameters("@JANCode").Value = parProduct(0).sJANCode
            '商品種別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductClass", OleDb.OleDbType.Numeric, 1))
            pCommand.Parameters("@ProductClass").Value = parProduct(0).sProductClass
            '商品名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductName", OleDb.OleDbType.Char, 100))
            pCommand.Parameters("@ProductName").Value = parProduct(0).sProductName
            '商品略称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ProductShortName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@ProductShortName").Value = parProduct(0).sProductShortName
            'メーカー名称
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MakerName", OleDb.OleDbType.Char, 30))
            pCommand.Parameters("@MakerName").Value = parProduct(0).sMakerName
            'オプション1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option1", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option1").Value = parProduct(0).sOption1
            'オプション2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option2", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option2").Value = parProduct(0).sOption2
            'オプション3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option3", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option3").Value = parProduct(0).sOption3
            'オプション4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option4", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option4").Value = parProduct(0).sOption4
            'オプション5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Option5", OleDb.OleDbType.Char, 20))
            pCommand.Parameters("@Option5").Value = parProduct(0).sOption5
            '適用
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Memo", OleDb.OleDbType.Char, 50))
            pCommand.Parameters("@Memo").Value = parProduct(0).sMemo
            '定価
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ListPrice", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@ListPrice").Value = parProduct(0).sListPrice
            '適正在庫数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MinStock", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@MinStock").Value = parProduct(0).sMinStock
            'PLUコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PLUCode", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@PLUCode").Value = parProduct(0).sPLUCode
            '販売停止フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StopSaleFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@StopSaleFlg").Value = parProduct(0).sStopSaleFlg
            '仕入停止フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StopSupplieFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@StopSupplieFlg").Value = parProduct(0).sStopSupplieFlg
            'Yahoo掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@YahooFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@YahooFlg").Value = parProduct(0).sYahooFlg
            '楽天掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RakutenFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@RakutenFlg").Value = parProduct(0).sRakutenFlg
            'Amazon掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AmazonFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@AmazonFlg").Value = parProduct(0).sAmazonFlg
            'eShop掲載フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OriginalFlg", OleDb.OleDbType.Boolean, 1))
            pCommand.Parameters("@OriginalFlg").Value = parProduct(0).seShopFlg
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

            '----------------------------------------------------
            'ocf　鈴木　2019/09/20
            '----------------------------------------------------
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ReducedTaxRatea", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@ReducedTaxRatea").Value = parProduct(0).sReducedTaxRate
            '----------------------------------------------------
            'ocf　鈴木　2019/09/20　end
            '----------------------------------------------------

            '商品マスタ挿入処理実行
            pCommand.ExecuteNonQuery()

            insertProductMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.insertProductMst)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateProductMst(ByRef parProduct() As cStructureLib.sProduct, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        '----------------------------------------------------
        'ocf　鈴木　2019/09/20
        '----------------------------------------------------

        'SQL文の設定
        strUpdate = "UPDATE 商品マスタ SET " &
                            "SEQコード=""" & parProduct(0).sSEQCode.ToString & """, " &
                            "JANコード=""" & parProduct(0).sJANCode.ToString & """, " &
                            "商品種別=""" & parProduct(0).sProductClass.ToString & """, " &
                            "商品名称=""" & parProduct(0).sProductName.ToString & """, " &
                            "商品略称=""" & parProduct(0).sProductShortName.ToString & """, " &
                            "メーカー名称=""" & parProduct(0).sMakerName.ToString & """, " &
                            "オプション1=""" & parProduct(0).sOption1.ToString & """, " &
                            "オプション2=""" & parProduct(0).sOption2.ToString & """, " &
                            "オプション3=""" & parProduct(0).sOption3.ToString & """, " &
                            "オプション4=""" & parProduct(0).sOption4.ToString & """, " &
                            "オプション5=""" & parProduct(0).sOption5.ToString & """, " &
                            "適用=""" & parProduct(0).sMemo.ToString & """, " &
                            "定価=" & CLng(parProduct(0).sListPrice) & ", " &
                            "適正在庫数=" & CLng(parProduct(0).sMinStock) & ", " &
                            "PLUコード=""" & parProduct(0).sPLUCode.ToString & """, " &
                            "販売停止フラグ=" & parProduct(0).sStopSaleFlg & ", " &
                            "仕入停止フラグ=" & parProduct(0).sStopSupplieFlg & ", " &
                            "Yahoo掲載フラグ=" & parProduct(0).sYahooFlg & ", " &
                            "楽天掲載フラグ=" & parProduct(0).sRakutenFlg & ", " &
                            "Amazon掲載フラグ=" & parProduct(0).sAmazonFlg & ", " &
                            "eShop掲載フラグ=" & parProduct(0).seShopFlg & ", " &
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """, " &
                            "軽減税率=""" & parProduct(0).sReducedTaxRate.ToString & """ " &
                            "WHERE 商品コード=""" & parProduct(0).sProductCode.ToString & """ "
        '----------------------------------------------------
        'ocf　鈴木　2019/09/20　end
        '----------------------------------------------------

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateProductMst = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.updateProductMst)", Nothing, Nothing, oExcept.ToString)
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

    '------------------------------- JANコード関連 ------------------------------------------
    Public Function readMaxJANCode(ByRef Tran As OleDb.OleDbTransaction) As String
        Dim strSelect As String

        readMaxJANCode = ""

        strSelect = "SELECT JANコード FROM 商品マスタ " &
                                            "WHERE JANコード Like ""999%"" " &
                                            "ORDER BY JANコード DESC"

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
                readMaxJANCode = Nothing
            Else
                readMaxJANCode = pDataReader("JANコード").ToString
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.readMaxJANCode)", Nothing, Nothing, oExcept.ToString)
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
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getProduct_JANNull(ByRef parProduct() As cStructureLib.sProduct, ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT 商品コード, JANコード FROM 商品マスタ WHERE JANコード Is Null "

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parProduct(i)

                '商品コード
                parProduct(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProduct(i).sJANCode = pDataReader("JANコード").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getProduct_JANNull = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProduct_JANNull)", Nothing, Nothing, oExcept.ToString)
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
    '　機能：商品マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateNetStatus(ByRef parProductCode As String,
                                    ByRef KeyYahooStatus As Boolean,
                                    ByRef KeyRakutenStatus As Boolean,
                                    ByRef KeyAmazonStatus As Boolean,
                                    ByRef KeyeShopStatus As Boolean,
                                    ByRef KeyeSaleStopFlg As Boolean,
                                    ByRef KeySupplieStopFlg As Boolean,
                                    ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 商品マスタ SET Yahoo掲載フラグ=" & KeyYahooStatus & ", " &
                                            "楽天掲載フラグ=" & KeyRakutenStatus & ", " &
                                            "Amazon掲載フラグ=" & KeyAmazonStatus & ", " &
                                            "eShop掲載フラグ=" & KeyeShopStatus & ", " &
                                            "販売停止フラグ=" & KeyeSaleStopFlg & ", " &
                                            "仕入停止フラグ=" & KeySupplieStopFlg & ", " &
                                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " &
                                            "WHERE 商品コード=""" & parProductCode & """ "

        updateNetStatus = False

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateNetStatus = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.updateNetStatus)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Windows.Forms.Application.Exit()
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：商品マスタの１レコードを更新するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function updateJANCode(ByRef parProduct As cStructureLib.sProduct, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 商品マスタ SET " &
                            "JANコード=""" & parProduct.sJANCode.ToString & """, " &
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " &
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " &
                            "WHERE 商品コード=""" & parProduct.sProductCode.ToString & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            pCommand.ExecuteNonQuery()

            updateJANCode = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProduct_JANNull)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Windows.Forms.Application.Exit()
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：商品マスタの１レコードを削除するメソッド
    '　引数：商品コード
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteProduct(ByVal KeyProductCode As String, ByRef Tran As OleDb.OleDbTransaction) As Boolean
        Dim strDelete As String

        'SQL文の設定
        strDelete = "DELETE * FROM 商品マスタ WHERE 商品コード=""" & KeyProductCode & """"

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDelete

            '商品マスタ削除処理実行()
            pCommand.ExecuteNonQuery()

            deleteProduct = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.deleteProduct)", Nothing, Nothing, oExcept.ToString)
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


    '----------------------------------------------------
    '2015/07/01
    '及川和彦
    'FROM
    '----------------------------------------------------
    '-------------------------------------------------------------------------------
    '　機能：商品マスタから該当レコードを取得する関数
    '　引数：Byref parProduct()　：データセットバッファ（sProduct Structureの配列）
    '　　　：KeyString　：キー情報（Mode=PRODUCT_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（PRODUCT_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function readPrdMstCode(ByVal KeyProductCode As String, ByRef parProduct() As cStructureLib.sProduct, ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long

        strSelect = ""

        strSelect = "SELECT 商品コード FROM 商品マスタ " &
                                            "WHERE 商品コード Like ""%" & KeyProductCode & "%"" " &
                                            "ORDER BY 商品コード"
        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()


                ReDim Preserve parProduct(i)

                '商品コード
                parProduct(i).sProductCode = pDataReader("商品コード").ToString

                'レコードが取得できた時の処理
                i = i + 1
            End While

            readPrdMstCode = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProduct_JANNull)", Nothing, Nothing, oExcept.ToString)
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





    '----------------------------------------------------
    'HERE
    '----------------------------------------------------






    '----------------------------------------------------
    '2015/06/20
    '及川和彦
    '入庫処理時に商品マスタを変更した際に商品価格を反映する
    'FROM
    '----------------------------------------------------
    Public Function getProductNet(ByVal KeyProductCode As String, ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String

        strSelect = ""

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = "SELECT COUNT(*) AS CNT FROM 商品マスタ WHERE 商品コード = """ & KeyProductCode & """" &
                                                        " AND ( Yahoo掲載フラグ = TRUE" &
                                                        " OR 楽天掲載フラグ = TRUE" &
                                                        " OR Amazon掲載フラグ = TRUE" &
                                                        " OR eShop掲載フラグ = TRUE)"

            'SQL文の設定
            pCommand.CommandText = strSelect
            pDataReader = pCommand.ExecuteReader()
            pDataReader.Read()
            getProductNet = CLng(pDataReader("CNT"))

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cMstProductDBIO.getProductPrice)", Nothing, Nothing, oExcept.ToString)
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
    '----------------------------------------------------
    'HERE
    '----------------------------------------------------

    Public Function getProductList(ByRef parProductList() As cStructureLib.sViewProductList,
                                    ByVal KeyJANCode As String,
                                    ByVal KeyProductCode As String,
                                    ByVal KeyProductName As String,
                                    ByVal KeyOptionName As String,
                                    ByVal KeyMakerName As String,
                                     ByVal KeyYahooCheck As Boolean,
                                     ByVal KeyRakutenCheck As Boolean,
                                     ByVal KeyAmazonCheck As Boolean,
                                     ByVal KeyeShopCheck As Boolean,
                                    ByVal KeySelectCheck As Boolean,
                                    ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim MaxPc As Integer
        Dim KeyChannelCode As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            '検索キーチャネルコード=楽天(2)固定
            KeyChannelCode = 2

            strSelect = "SELECT DISTINCT " &
                            "発注状態データ.選択状態 AS 選択状態, " &
                            "商品マスタ.商品コード AS 商品コード, " &
                            "商品マスタ.商品名称 AS 商品名称, " &
                            "商品マスタ.JANコード AS JANコード, " &
                            "商品マスタ.オプション1 AS オプション1, " &
                            "商品マスタ.オプション2 AS オプション2, " &
                            "商品マスタ.オプション3 AS オプション3, " &
                            "商品マスタ.オプション4 AS オプション4, " &
                            "商品マスタ.オプション5 AS オプション5, " &
                            "商品マスタ.定価 AS 定価, " &
                            "仕入価格マスタ.仕入単価 AS 仕入価格, " &
                            "仕入価格マスタ.仕入先コード AS 仕入先コード, " &
                            "仕入先マスタ.仕入先名称 AS 仕入先名称, " &
                            "販売価格マスタ.チャネルコード AS チャネルコード, " &
                            "販売価格マスタ.販売単価 AS 販売単価, " &
                            "在庫マスタ.在庫数 AS 在庫数, " &
                            "販売価格マスタ.適用開始日 AS 適用開始日, " &
                            "販売価格マスタ.適用終了日 AS 適用終了日 " &
                        "FROM ((((商品マスタ " &
                                "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " &
                                "LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " &
                                "LEFT JOIN 発注状態データ ON 商品マスタ.商品コード = 商品リスト状態データ.商品コード) " &
                                "LEFT JOIN 仕入価格マスタ ON 商品マスタ.商品コード = 仕入価格マスタ.商品コード) " &
                                "LEFT JOIN 仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード "

            'パラメータ数のカウント
            pc = 0
            MaxPc = 0
            If KeyChannelCode <> Nothing Then
                MaxPc = 1
                pc = pc Or MaxPc
            End If
            If KeyJANCode <> Nothing Then
                MaxPc = 2
                pc = pc Or MaxPc
            End If
            If KeyProductCode <> Nothing Then
                MaxPc = 4
                pc = pc Or MaxPc
            End If
            If KeyProductName <> Nothing Then
                MaxPc = 8
                pc = pc Or MaxPc
            End If
            If KeyOptionName <> Nothing Then
                MaxPc = 16
                pc = pc Or MaxPc
            End If
            If KeyMakerName <> Nothing Then
                MaxPc = 32
                pc = pc Or MaxPc
            End If
            If KeyYahooCheck = True Then
                MaxPc = 64
                pc = pc Or MaxPc
            End If
            If KeyRakutenCheck = True Then
                MaxPc = 128
                pc = pc Or MaxPc
            End If
            If KeyAmazonCheck = True Then
                MaxPc = 256
                pc = pc Or MaxPc
            End If
            If KeyeShopCheck = True Then
                MaxPc = 512
                pc = pc Or MaxPc
            End If
            If KeySelectCheck = True Then
                MaxPc = 1024
                pc = pc Or MaxPc
            End If

            'パラメータ指定がある場合
            If MaxPc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= MaxPc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.メーカー名称 Like ""%" & KeyMakerName & "%"") "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Yahoo掲載フラグ =" & KeyYahooCheck
                            scnt = scnt + 1
                        Case 128
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Rakuten掲載フラグ =" & KeyRakutenCheck
                            scnt = scnt + 1
                        Case 256
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Amazon掲載フラグ =" & KeyAmazonCheck
                            scnt = scnt + 1
                        Case 512
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.eShop掲載フラグ =" & KeyeShopCheck
                            scnt = scnt + 1
                        Case 1024
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品リスト状態データ.選択状態 =" & KeySelectCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " &
                          "AND 販売価格マスタ.適用終了日>=Now() "

            strSelect = strSelect & " ORDER BY 商品マスタ.商品名称, " &
                        "商品マスタ.オプション1, " &
                        "商品マスタ.オプション2, " &
                        "商品マスタ.オプション3, " &
                        "商品マスタ.オプション4, " &
                        "商品マスタ.オプション5 "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader

            i = 0
            ReDim parProductList(0)

            While pDataReader.Read()

                ReDim Preserve parProductList(i)

                '選択状態
                If IsDBNull(pDataReader("選択状態")) Then
                    parProductList(i).sStatus = False
                Else
                    parProductList(i).sStatus = pDataReader("選択状態")
                End If

                '商品コード
                parProductList(i).sProductCode = pDataReader("商品コード").ToString
                'JANコード
                parProductList(i).sJANCode = pDataReader("JANコード").ToString
                '商品名称
                parProductList(i).sProductName = pDataReader("商品名称").ToString
                'オプション1
                parProductList(i).sOption1 = pDataReader("オプション1").ToString
                'オプション2
                parProductList(i).sOption2 = pDataReader("オプション2").ToString
                'オプション3
                parProductList(i).sOption3 = pDataReader("オプション3").ToString
                'オプション4
                parProductList(i).sOption4 = pDataReader("オプション4").ToString
                'オプション5
                parProductList(i).sOption5 = pDataReader("オプション5").ToString
                '定価
                parProductList(i).sPrice = CLng(pDataReader("定価"))
                'チャネルコード
                parProductList(i).sChannelCode = pDataReader("チャネルコード").ToString
                '販売価格
                If IsDBNull(pDataReader("販売単価")) = True Then
                    parProductList(i).sSalePrice = 0
                Else
                    parProductList(i).sSalePrice = CLng(pDataReader("販売単価"))
                End If
                'メーカー名称
                parProductList(i).sMakerName = pDataReader("メーカー名称").ToString

                i = i + 1

            End While

            getProductList = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductList)", Nothing, Nothing, oExcept.ToString)
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

    Public Function getProductListCount(
                                     ByVal KeyJANCode As String,
                                     ByVal KeyProductCode As String,
                                     ByVal KeyProductName As String,
                                     ByVal KeyOptionName As String,
                                     ByVal KeyMakerName As String,
                                     ByVal KeyYahooCheck As Boolean,
                                     ByVal KeyRakutenCheck As Boolean,
                                     ByVal KeyAmazonCheck As Boolean,
                                     ByVal KeyeShopCheck As Boolean,
                                     ByVal KeySelectCheck As Boolean,
                                     ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim MaxPc As Integer
        Dim KeyChannelCode As Integer

        Try
            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            strSelect = ""

            '検索キーチャネルコード=楽天(2)固定
            KeyChannelCode = 2

            strSelect = "SELECT DISTINCT  COUNT(商品マスタ.商品コード) AS 商品数" &
                        "FROM ((((商品マスタ " &
                                "LEFT JOIN 販売価格マスタ ON 商品マスタ.商品コード = 販売価格マスタ.商品コード) " &
                                "LEFT JOIN 在庫マスタ ON 商品マスタ.商品コード = 在庫マスタ.商品コード) " &
                                "LEFT JOIN 発注状態データ ON 商品マスタ.商品コード = 商品リスト状態データ.商品コード) " &
                                "LEFT JOIN 仕入価格マスタ ON 商品マスタ.商品コード = 仕入価格マスタ.商品コード) " &
                                "LEFT JOIN 仕入先マスタ ON 仕入価格マスタ.仕入先コード = 仕入先マスタ.仕入先コード "

            'パラメータ数のカウント
            pc = 0
            MaxPc = 0
            If KeyChannelCode <> Nothing Then
                MaxPc = 1
                pc = pc Or MaxPc
            End If
            If KeyJANCode <> Nothing Then
                MaxPc = 2
                pc = pc Or MaxPc
            End If
            If KeyProductCode <> Nothing Then
                MaxPc = 4
                pc = pc Or MaxPc
            End If
            If KeyProductName <> Nothing Then
                MaxPc = 8
                pc = pc Or MaxPc
            End If
            If KeyOptionName <> Nothing Then
                MaxPc = 16
                pc = pc Or MaxPc
            End If
            If KeyMakerName <> Nothing Then
                MaxPc = 32
                pc = pc Or MaxPc
            End If
            If KeyYahooCheck = True Then
                MaxPc = 64
                pc = pc Or MaxPc
            End If
            If KeyRakutenCheck = True Then
                MaxPc = 128
                pc = pc Or MaxPc
            End If
            If KeyAmazonCheck = True Then
                MaxPc = 256
                pc = pc Or MaxPc
            End If
            If KeyeShopCheck = True Then
                MaxPc = 512
                pc = pc Or MaxPc
            End If
            If KeySelectCheck = True Then
                MaxPc = 1024
                pc = pc Or MaxPc
            End If

            'パラメータ指定がある場合
            If MaxPc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= MaxPc
                    Select Case i And pc
                        Case 1
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "販売価格マスタ.チャネルコード = " & KeyChannelCode & " "
                            scnt = scnt + 1
                        Case 2
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.JANコード Like ""%" & KeyJANCode & "%"" "
                            scnt = scnt + 1
                        Case 4
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品コード Like ""%" & KeyProductCode & "%"" "
                            scnt = scnt + 1
                        Case 8
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.商品名称 Like ""%" & KeyProductName & "%"" "
                            scnt = scnt + 1
                        Case 16
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "(商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"" "
                            strSelect = strSelect & "OR 商品マスタ.オプション1 Like ""%" & KeyOptionName & "%"") "
                            scnt = scnt + 1
                        Case 32
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.メーカー名称 Like ""%" & KeyMakerName & "%"") "
                            scnt = scnt + 1
                        Case 64
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Yahoo掲載フラグ =" & KeyYahooCheck
                            scnt = scnt + 1
                        Case 128
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Rakuten掲載フラグ =" & KeyRakutenCheck
                            scnt = scnt + 1
                        Case 256
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.Amazon掲載フラグ =" & KeyAmazonCheck
                            scnt = scnt + 1
                        Case 512
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品マスタ.eShop掲載フラグ =" & KeyeShopCheck
                            scnt = scnt + 1
                        Case 1024
                            If scnt > 0 Then
                                strSelect = strSelect & "AND "
                            Else
                                strSelect = strSelect & "WHERE "
                            End If
                            strSelect = strSelect & "商品リスト状態データ.選択状態 =" & KeySelectCheck
                            scnt = scnt + 1
                    End Select
                    i = i * 2
                End While
            End If

            If scnt > 0 Then
                strSelect = strSelect & " AND "
            Else
                strSelect = strSelect & " WHERE "
            End If

            strSelect = strSelect & " 販売価格マスタ.適用開始日<=Now() " &
                          "AND 販売価格マスタ.適用終了日>=Now() "

            strSelect = strSelect & " ORDER BY 商品マスタ.商品名称, " &
                        "商品マスタ.オプション1, " &
                        "商品マスタ.オプション2, " &
                        "商品マスタ.オプション3, " &
                        "商品マスタ.オプション4, " &
                        "商品マスタ.オプション5 "

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            pDataReader.Read()

            getProductListCount = CLng(pDataReader("商品数"))


        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cViewProductStockDBIO.getProductListCount)", Nothing, Nothing, oExcept.ToString)
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



