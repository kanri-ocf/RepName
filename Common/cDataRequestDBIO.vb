﻿
Public Class cDataRequestDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage
    Private oTool As cTool

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader

        oTool = New cTool
    End Sub


    '-------------------------------------------------------------------------------
    '　機能：受注情報データから該当レコードを取得する関数
    '　引数：Byref parRequestData()　：データセットバッファ（sRequest Structureの配列）
    '　　　：KeyString　：キー情報（Mode=Request_MODEの場合は商品コード)
    ' 　　　　　　　　　　　　　　（Mode=JAN_CODEの場合はJANコード）
    '　　　：Mode　：検索モード（Request_MODE(1)：商品コードをキーとする検索)
    '　　　　　　　　　　　　　（JAN_CODE(2)：JANコードをキーとする検索)
    '　戻値：取得レコード数
    '-------------------------------------------------------------------------------
    Public Function getRequest(ByRef parRequestData() As cStructureLib.sRequestData,
                                    ByVal KeyChannelCode As Integer,
                                    ByVal KeyRequestCode As String,
                                    ByVal KeyRequestFromDate As String,
                                    ByVal KeyRequestToDate As String,
                                    ByVal KeyCustmorName As String,
                                    ByVal KeyOriginalOrderCode As String,
                                    ByVal KeyPrintedFlg As Boolean,
                                    ByVal KeyUnPrintFlg As Boolean,
                                    ByVal KeyShipedFlg As Boolean,
                                    ByVal KeyUnShipFlg As Boolean,
                                    ByVal KeyChannelClass As String,
                                    ByVal KeyProductCode As String,
                                    ByVal KeyProductName As String,
                                    ByVal KeyOptionName As String,
                                    ByRef Tran As OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        '2020,4,17 A.Komita 追加 From
        Dim maxpc As Integer
        '2020,4,17 A.Komita 追加 To

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報データ "
        'パラメータ数のカウント
        '2020,4,17 A.Komita 62行目から117行目にかけて『 maxpc = 』と『pc = pc Or maxpc』を追加 From
        pc = 0
        If KeyChannelCode <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyRequestCode <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyRequestFromDate <> "" Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyRequestToDate <> "" Then
            maxpc = 8
            pc = pc Or maxpc
        End If
        If KeyCustmorName <> "" Then
            maxpc = 16
            pc = pc Or maxpc
        End If
        If KeyOriginalOrderCode <> "" Then
            maxpc = 32
            pc = pc Or maxpc
        End If
        If KeyPrintedFlg = True Then
            maxpc = 64
            pc = pc Or maxpc
        End If
        If KeyUnPrintFlg = True Then
            maxpc = 128
            pc = pc Or maxpc
        End If
        If KeyShipedFlg = True Then
            maxpc = 256
            pc = pc Or maxpc
        End If
        If KeyUnShipFlg = True Then
            maxpc = 512
            pc = pc Or maxpc
        End If
        If KeyChannelClass <> "" Then
            maxpc = 1024
            pc = pc Or maxpc
        End If
        If KeyProductCode <> "" Then
            maxpc = 2048
            pc = pc Or maxpc
        End If
        If KeyProductName <> "" Then
            maxpc = 4096
            pc = pc Or maxpc
        End If
        If KeyOptionName <> "" Then
            maxpc = 8192
            pc = pc Or maxpc
        End If
        '2020,4,17 A.Komita 追加 To

        'パラメータ指定がある場合
        If maxpc And pc > 0 Then

            '2020,4,17 A.Komita 削除 start----
            'If 1024 And pc > 0 Then
            '2020,4,17 A.Komita 削除 end------

            i = 1
            scnt = 0

            '2020,4,17 A.Komita While条件を『While i <= 1024』から『 While i <= maxpc』へ変更 start
            While i <= maxpc '1024
                '2020,4,17 A.Komita 変更 end

                Select Case i And pc
                    Case 1
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "チャネルコード= " & KeyChannelCode & " "
                        scnt = scnt + 1
                    Case 2
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注コード Like ""%" & KeyRequestCode & "%"" "
                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyRequestFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyRequestToDate & """ "
                        scnt = scnt + 1
                    Case 16
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "([請求先－姓] & [請求先－名]) Like ""%" & KeyCustmorName & "%"""
                        scnt = scnt + 1
                    Case 32
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(OR受注コード = """ & KeyOriginalOrderCode & """) "
                        scnt = scnt + 1
                    Case 64
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(受注伝票出力フラグ = True) "
                        scnt = scnt + 1
                    Case 128
                        If scnt > 0 Then
                            If KeyPrintedFlg = True Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "AND "
                            End If
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "(受注伝票出力フラグ = False) "
                        scnt = scnt + 1
                    Case 256
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "EXISTS (SELECT * FROM 出荷情報データ " &
                                                "WHERE 出荷情報データ.受注コード = 受注情報データ.受注コード AND 出荷情報データ.出荷完了フラグ = 1) "
                        scnt = scnt + 1
                    Case 512
                        If scnt > 0 Then
                            If KeyShipedFlg = True Then
                                strSelect = strSelect & "OR "
                            Else
                                strSelect = strSelect & "AND "
                            End If
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "NOT EXISTS (SELECT * FROM 出荷情報データ " &
                                                "WHERE 出荷情報データ.受注コード = 受注情報データ.受注コード AND 出荷情報データ.出荷完了フラグ = 1) "
                        scnt = scnt + 1
                    Case 1024
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect &
                                    "EXISTS(" &
                                    "    SELECT * FROM チャネルマスタ " &
                                    "    WHERE チャネルマスタ.チャネルコード = 受注情報データ.チャネルコード " &
                                    "    AND   チャネルマスタ.チャネル種別 = 2" &
                                    ") "
                        scnt = scnt + 1
                    Case 2048
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect &
                                    "EXISTS(" &
                                    "    SELECT * FROM 受注情報明細データ " &
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " &
                                    "    AND   ( " &
                                    "                  受注情報明細データ.商品コード = '" & KeyProductCode & "' " &
                                    "              OR " &
                                    "                  受注情報明細データ.チャネル商品コード = '" & KeyProductCode & "' " &
                                    "           ) " &
                                    ") "
                        scnt = scnt + 1
                    Case 4096
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect &
                                    "EXISTS(" &
                                    "    SELECT * FROM 受注情報明細データ " &
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " &
                                    "    AND   ( " &
                                    "                  受注情報明細データ.商品名称 = '" & KeyProductName & "' " &
                                    "           ) " &
                                    ") "
                        scnt = scnt + 1
                    Case 8192
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect &
                                    "EXISTS(" &
                                    "    SELECT * FROM 受注情報明細データ " &
                                    "    WHERE 受注情報明細データ.受注コード = 受注情報データ.受注コード " &
                                    "    AND   ( " &
                                    "                  受注情報明細データ.オプション値 = '" & KeyOptionName & "' " &
                                    "           ) " &
                                    ") "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            i = 0

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parRequestData(i)

                '2020,1,17 A.Komita バックアップ時に構造体へ追加する数値を取得するコードを追加 From
                '受注コード
                If IsDBNull(pDataReader("受注コード").ToString) = True Then
                    parRequestData(i).sRequestCode = ""
                Else
                    parRequestData(i).sRequestCode = pDataReader("受注コード").ToString
                End If
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRequestData(i).sChannelCode = 0
                Else
                    parRequestData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                If IsDBNull(pDataReader("OR受注コード").ToString) = True Then
                    parRequestData(i).sORRequestCode = ""
                Else
                    parRequestData(i).sORRequestCode = pDataReader("OR受注コード").ToString
                End If
                '受注サイト
                If IsDBNull(pDataReader("受注サイト").ToString) = True Then
                    parRequestData(i).sRequestSite = ""
                Else
                    parRequestData(i).sRequestSite = pDataReader("受注サイト").ToString
                End If
                '受注媒体
                If IsDBNull(pDataReader("受注媒体").ToString) = True Then
                    parRequestData(i).sRequestMedia = ""
                Else
                    parRequestData(i).sRequestMedia = pDataReader("受注媒体").ToString
                End If
                'モバイルフラグ
                If IsDBNull(pDataReader("モバイルフラグ").ToString) = True Then
                    parRequestData(i).sMobileFlg = ""
                Else
                    parRequestData(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                End If
                'アフェリエイトフラグ
                If IsDBNull(pDataReader("アフェリエイトフラグ").ToString) = True Then
                    parRequestData(i).sAffiliateFlg = ""
                Else
                    parRequestData(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                End If
                '受注日
                If IsDBNull(pDataReader("受注日").ToString) = True Then
                    parRequestData(i).sRequestDate = ""
                Else
                    parRequestData(i).sRequestDate = pDataReader("受注日").ToString
                End If
                '受注時間
                If IsDBNull(pDataReader("受注時間").ToString) = True Then
                    parRequestData(i).sRequestTime = ""
                Else
                    parRequestData(i).sRequestTime = pDataReader("受注時間").ToString
                End If
                '出荷先－会社名
                If IsDBNull(pDataReader("出荷先－会社名").ToString) = True Then
                    parRequestData(i).sShipCorpName = ""
                Else
                    parRequestData(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                End If
                '出荷先－支店名
                If IsDBNull(pDataReader("出荷先－支店名").ToString) = True Then
                    parRequestData(i).sShipDivName = ""
                Else
                    parRequestData(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                End If
                '出荷先－姓カナ
                If IsDBNull(pDataReader("出荷先－姓カナ").ToString) = True Then
                    parRequestData(i).sShipKanaShip1stName = ""
                Else
                    parRequestData(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                End If
                '出荷先－名カナ
                If IsDBNull(pDataReader("出荷先－名カナ").ToString) = True Then
                    parRequestData(i).sShipKanaShip2ndName = ""
                Else
                    parRequestData(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                End If
                '出荷先－住所１カナ
                If IsDBNull(pDataReader("出荷先－住所１カナ").ToString) = True Then
                    parRequestData(i).sShipKanaAdder1 = ""
                Else
                    parRequestData(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                End If
                '出荷先－住所２カナ
                If IsDBNull(pDataReader("出荷先－住所２カナ").ToString) = True Then
                    parRequestData(i).sShipKanaAdder2 = ""
                Else
                    parRequestData(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                End If
                '出荷先－住所市区町村カナ
                If IsDBNull(pDataReader("出荷先－住所市区町村カナ").ToString) = True Then
                    parRequestData(i).sShipKanaCity = ""
                Else
                    parRequestData(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                End If
                '出荷先－都道府県カナ
                If IsDBNull(pDataReader("出荷先－都道府県カナ").ToString) = True Then
                    parRequestData(i).sShipKanaState = ""
                Else
                    parRequestData(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                End If
                '出荷先－姓
                If IsDBNull(pDataReader("出荷先－姓").ToString) = True Then
                    parRequestData(i).sShip1stName = ""
                Else
                    parRequestData(i).sShip1stName = pDataReader("出荷先－姓").ToString
                End If
                '出荷先－名
                If IsDBNull(pDataReader("出荷先－名").ToString) = True Then
                    parRequestData(i).sShip2ndName = ""
                Else
                    parRequestData(i).sShip2ndName = pDataReader("出荷先－名").ToString
                End If
                '出荷先－住所１
                If IsDBNull(pDataReader("出荷先－住所１").ToString) = True Then
                    parRequestData(i).sShipAdder1 = ""
                Else
                    parRequestData(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                End If
                '出荷先－住所２
                If IsDBNull(pDataReader("出荷先－住所２").ToString) = True Then
                    parRequestData(i).sShipAdder2 = ""
                Else
                    parRequestData(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                End If
                '出荷先－住所市区町村
                If IsDBNull(pDataReader("出荷先－住所市区町村").ToString) = True Then
                    parRequestData(i).sShipCity = ""
                Else
                    parRequestData(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                End If
                '出荷先－都道府県
                If IsDBNull(pDataReader("出荷先－都道府県").ToString) = True Then
                    parRequestData(i).sShipState = ""
                Else
                    parRequestData(i).sShipState = pDataReader("出荷先－都道府県").ToString
                End If
                '出荷先－国名
                If IsDBNull(pDataReader("出荷先－国名").ToString) = True Then
                    parRequestData(i).sShipCountry = ""
                Else
                    parRequestData(i).sShipCountry = pDataReader("出荷先－国名").ToString
                End If
                '出荷先－郵便番号1
                If IsDBNull(pDataReader("出荷先－郵便番号1").ToString) = True Then
                    parRequestData(i).sShipPostCode1 = ""
                Else
                    parRequestData(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                End If
                '出荷先－郵便番号2
                If IsDBNull(pDataReader("出荷先－郵便番号2").ToString) = True Then
                    parRequestData(i).sShipPostCode2 = ""
                Else
                    parRequestData(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                End If
                '出荷先－電話番号
                If IsDBNull(pDataReader("出荷先－電話番号").ToString) = True Then
                    parRequestData(i).sShipTel = ""
                Else
                    parRequestData(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                End If
                '請求先－会社名
                If IsDBNull(pDataReader("請求先－会社名").ToString) = True Then
                    parRequestData(i).sBillCorpName = ""
                Else
                    parRequestData(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                End If
                '請求先－支店名
                If IsDBNull(pDataReader("請求先－支店名").ToString) = True Then
                    parRequestData(i).sBillDivName = ""
                Else
                    parRequestData(i).sBillDivName = pDataReader("請求先－支店名").ToString
                End If
                '請求先－姓カナ
                If IsDBNull(pDataReader("請求先－姓カナ").ToString) = True Then
                    parRequestData(i).sBillKanaBill1stName = ""
                Else
                    parRequestData(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                End If
                '請求先－名カナ
                If IsDBNull(pDataReader("請求先－名カナ").ToString) = True Then
                    parRequestData(i).sBillKanaBill2ndName = ""
                Else
                    parRequestData(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                End If
                '請求先－住所１カナ
                If IsDBNull(pDataReader("請求先－住所１カナ").ToString) = True Then
                    parRequestData(i).sBillKanaAdder1 = ""
                Else
                    parRequestData(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                End If
                '請求先－住所２カナ
                If IsDBNull(pDataReader("請求先－住所２カナ").ToString) = True Then
                    parRequestData(i).sBillKanaAdder2 = ""
                Else
                    parRequestData(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                End If
                '請求先－住所市区町村カナ
                If IsDBNull(pDataReader("請求先－住所市区町村カナ").ToString) = True Then
                    parRequestData(i).sBillKanaCity = ""
                Else
                    parRequestData(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                End If
                '請求先－都道府県カナ
                If IsDBNull(pDataReader("請求先－都道府県カナ").ToString) = True Then
                    parRequestData(i).sBillKanaState = ""
                Else
                    parRequestData(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                End If
                '請求先－姓
                If IsDBNull(pDataReader("請求先－姓").ToString) = True Then
                    parRequestData(i).sBill1stName = ""
                Else
                    parRequestData(i).sBill1stName = pDataReader("請求先－姓").ToString
                End If
                '請求先－名
                If IsDBNull(pDataReader("請求先－名").ToString) = True Then
                    parRequestData(i).sBill2ndName = ""
                Else
                    parRequestData(i).sBill2ndName = pDataReader("請求先－名").ToString
                End If
                '請求先－住所１
                If IsDBNull(pDataReader("請求先－住所１").ToString) = True Then
                    parRequestData(i).sBillAdder1 = ""
                Else
                    parRequestData(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                End If
                '請求先－住所２
                If IsDBNull(pDataReader("請求先－住所２").ToString) = True Then
                    parRequestData(i).sBillAdder2 = ""
                Else
                    parRequestData(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                End If
                '請求先－住所市区町村
                If IsDBNull(pDataReader("請求先－住所市区町村").ToString) = True Then
                    parRequestData(i).sBillCity = ""
                Else
                    parRequestData(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                End If
                '請求先－都道府県
                If IsDBNull(pDataReader("請求先－都道府県").ToString) = True Then
                    parRequestData(i).sBillState = ""
                Else
                    parRequestData(i).sBillState = pDataReader("請求先－都道府県").ToString
                End If
                '請求先－国名
                If IsDBNull(pDataReader("請求先－国名").ToString) = True Then
                    parRequestData(i).sBillCountry = ""
                Else
                    parRequestData(i).sBillCountry = pDataReader("請求先－国名").ToString
                End If
                '請求先－郵便番号1
                If IsDBNull(pDataReader("請求先－郵便番号1").ToString) = True Then
                    parRequestData(i).sBillPostCode1 = ""
                Else
                    parRequestData(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                End If
                '請求先－郵便番号2
                If IsDBNull(pDataReader("請求先－郵便番号2").ToString) = True Then
                    parRequestData(i).sBillPostCode2 = ""
                Else
                    parRequestData(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                End If
                '請求先－電話番号
                If IsDBNull(pDataReader("請求先－電話番号").ToString) = True Then
                    parRequestData(i).sBillTel = ""
                Else
                    parRequestData(i).sBillTel = pDataReader("請求先－電話番号").ToString
                End If
                'メールアドレス
                If IsDBNull(pDataReader("メールアドレス").ToString) = True Then
                    parRequestData(i).sMailAdderss = ""
                Else
                    parRequestData(i).sMailAdderss = pDataReader("メールアドレス").ToString
                End If
                'コメント
                If IsDBNull(pDataReader("コメント").ToString) = True Then
                    parRequestData(i).sComment = ""
                Else
                    parRequestData(i).sComment = pDataReader("コメント").ToString
                End If
                'ステータス
                If IsDBNull(pDataReader("ステータス").ToString) = True Then
                    parRequestData(i).sStatus = ""
                Else
                    parRequestData(i).sStatus = pDataReader("ステータス").ToString
                End If
                'エントリーポイント
                If IsDBNull(pDataReader("エントリーポイント").ToString) = True Then
                    parRequestData(i).sEntryPoint = ""
                Else
                    parRequestData(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                End If
                'リンク先
                If IsDBNull(pDataReader("リンク先").ToString) = True Then
                    parRequestData(i).sLink = ""
                Else
                    parRequestData(i).sLink = pDataReader("リンク先").ToString
                End If
                'カード支払方法
                If IsDBNull(pDataReader("カード支払方法").ToString) = True Then
                    parRequestData(i).sCardPayment = ""
                Else
                    parRequestData(i).sCardPayment = pDataReader("カード支払方法").ToString
                End If
                '配達希望日
                If IsDBNull(pDataReader("配達希望日").ToString) = True Then
                    parRequestData(i).sShipRequestDate = ""
                Else
                    parRequestData(i).sShipRequestDate = pDataReader("配達希望日").ToString
                End If
                '配達希望時間
                If IsDBNull(pDataReader("配達希望時間").ToString) = True Then
                    parRequestData(i).sShipRequestTime = ""
                Else
                    parRequestData(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                End If
                '配達希望メモ
                If IsDBNull(pDataReader("配達希望メモ").ToString) = True Then
                    parRequestData(i).sShipMemo = ""
                Else
                    parRequestData(i).sShipMemo = pDataReader("配達希望メモ").ToString
                End If
                '配送業者
                If IsDBNull(pDataReader("配送業者").ToString) = True Then
                    parRequestData(i).sShipCorp = ""
                Else
                    parRequestData(i).sShipCorp = pDataReader("配送業者").ToString
                End If
                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parRequestData(i).sChannelPaymentCode = 0
                Else
                    parRequestData(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'ギフト梱包希望
                parRequestData(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                If IsDBNull(pDataReader("取得ポイント数")) = True Then
                    parRequestData(i).sGetPoint = 0
                Else
                    parRequestData(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                End If
                '受注商品税抜金額
                If IsDBNull(pDataReader("受注商品税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalProductPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parRequestData(i).sShippingCharge = 0
                Else
                    parRequestData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parRequestData(i).sPaymentCharge = 0
                Else
                    parRequestData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parRequestData(i).sDiscount = 0
                Else
                    parRequestData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parRequestData(i).sPointDisCount = 0
                Else
                    parRequestData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parRequestData(i).sTaxTotal = 0
                Else
                    parRequestData(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                End If

                '2020,4,15 A.Komita 追加 From
                If IsDBNull(pDataReader("受注軽減税額")) = True Then
                    parRequestData(i).sReducedTaxRateTotal = 0
                Else
                    parRequestData(i).sReducedTaxRateTotal = CLng(pDataReader("受注軽減税額"))
                End If
                '2020,4,15 A.Komita 追加 To

                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parRequestData(i).sTotalPrice = 0
                Else
                    parRequestData(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                End If
                'ギフト梱包材料
                parRequestData(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                If IsDBNull(pDataReader("ギフト梱包料金")) = True Then
                    parRequestData(i).sGiftWrapKindPrice = 0
                Else
                    parRequestData(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                End If
                'のし希望
                If IsDBNull(pDataReader("のし希望").ToString) = True Then
                    parRequestData(i).sNoshiType = ""
                Else
                    parRequestData(i).sNoshiType = pDataReader("のし希望").ToString
                End If
                'のし記載内容
                If IsDBNull(pDataReader("のし記載内容").ToString) = True Then
                    parRequestData(i).sNoshiName = ""
                Else
                    parRequestData(i).sNoshiName = pDataReader("のし記載内容").ToString
                End If
                '注文者性別
                If IsDBNull(pDataReader("注文者性別").ToString) = True Then
                    parRequestData(i).sBillSex = ""
                Else
                    parRequestData(i).sBillSex = pDataReader("注文者性別").ToString
                End If
                '注文者誕生日
                If IsDBNull(pDataReader("注文者誕生日").ToString) = True Then
                    parRequestData(i).sBillBirthDay = ""
                Else
                    parRequestData(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                End If
                '楽天バンク決済手数料
                If IsDBNull(pDataReader("楽天バンク決済手数料")) = True Then
                    parRequestData(i).sRakutenCharge = 0
                Else
                    parRequestData(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                End If
                '受注伝票出力フラグ
                If IsDBNull(pDataReader("受注伝票出力フラグ")) = True Then
                    parRequestData(i).sPrintFlg = False
                Else
                    parRequestData(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                End If
                '受注担当者コード
                If IsDBNull(pDataReader("受注担当者コード").ToString) = True Then
                    parRequestData(i).sStaffCode = ""
                Else
                    parRequestData(i).sStaffCode = pDataReader("受注担当者コード").ToString
                End If
                '登録日
                If IsDBNull(pDataReader("登録日").ToString) = True Then
                    parRequestData(i).sCreateDate = ""
                Else
                    parRequestData(i).sCreateDate = pDataReader("登録日").ToString
                End If
                '登録時間
                If IsDBNull(pDataReader("登録時間").ToString) = True Then
                    parRequestData(i).sCreateTime = ""
                Else
                    parRequestData(i).sCreateTime = pDataReader("登録時間").ToString
                End If
                '最終更新日
                If IsDBNull(pDataReader("最終更新日").ToString) = True Then
                    parRequestData(i).sUpdateDate = ""
                Else
                    parRequestData(i).sUpdateDate = pDataReader("最終更新日").ToString
                End If
                '最終更新時間
                If IsDBNull(pDataReader("最終更新時間").ToString) = True Then
                    parRequestData(i).sUpdateTime = ""
                Else
                    parRequestData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                End If
                '2020,1,17 A.Komita 追加 To

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequest = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Function getRequest2(ByRef parRequestData() As cStructureLib.sRequestData, _
                                ByVal KeyRequestCode As String, _
                                ByVal KeyPhoneNumber As String, _
                                ByVal KeyFromDate As String, _
                                ByVal KeyToDate As String, _
                                ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        'コマンドオブジェクトの生成
        pCommand = pConn.CreateCommand()
        pCommand.Transaction = Tran

        strSelect = ""

        strSelect = "SELECT * FROM 受注情報データ "
        'パラメータ数のカウント
        pc = 0
        If KeyRequestCode <> "" Then
            maxpc = 1
            pc = pc Or maxpc
        End If
        If KeyPhoneNumber <> "" Then
            maxpc = 2
            pc = pc Or maxpc
        End If
        If KeyFromDate <> "" Then
            maxpc = 4
            pc = pc Or maxpc
        End If
        If KeyToDate <> "" Then
            maxpc = 8
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
                        strSelect = strSelect & "受注コード Like ""%" & KeyRequestCode & "%"" "
                        scnt = scnt + 1
                    Case 2  '電話番号
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注情報データ.請求先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "
                        strSelect = strSelect & "Or 受注情報データ.出荷先－電話番号 Like """ & oTool.DmyReplace(KeyPhoneNumber) & """ "

                        scnt = scnt + 1
                    Case 4
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 >= """ & KeyFromDate & """ "
                        scnt = scnt + 1
                    Case 8
                        If scnt > 0 Then
                            strSelect = strSelect & "AND "
                        Else
                            strSelect = strSelect & "WHERE "
                        End If
                        strSelect = strSelect & "受注日 <= """ & KeyToDate & """ "
                        scnt = scnt + 1
                End Select
                i = i * 2
            End While
        End If

        strSelect = strSelect & "ORDER BY 受注情報データ.登録日 DESC , 受注情報データ.登録時間 DESC"

        Try
            i = 0

            'SQL文の設定
            pCommand.CommandText = strSelect

            i = 0

            pDataReader = pCommand.ExecuteReader()

            While pDataReader.Read()

                ReDim Preserve parRequestData(i)

                '2020,1,17 A.Komita バックアップ時に構造体へ追加する数値を取得するコードを追加 From
                '受注コード
                If IsDBNull(pDataReader("受注コード").ToString) = True Then
                    parRequestData(i).sRequestCode = ""
                Else
                    parRequestData(i).sRequestCode = pDataReader("受注コード").ToString
                End If
                'チャネルコード
                If IsDBNull(pDataReader("チャネルコード")) = True Then
                    parRequestData(i).sChannelCode = 0
                Else
                    parRequestData(i).sChannelCode = CInt(pDataReader("チャネルコード"))
                End If
                'OR受注コード
                If IsDBNull(pDataReader("OR受注コード").ToString) = True Then
                    parRequestData(i).sORRequestCode = ""
                Else
                    parRequestData(i).sORRequestCode = pDataReader("OR受注コード").ToString
                End If
                '受注サイト
                If IsDBNull(pDataReader("受注サイト").ToString) = True Then
                    parRequestData(i).sRequestSite = ""
                Else
                    parRequestData(i).sRequestSite = pDataReader("受注サイト").ToString
                End If
                '受注媒体
                If IsDBNull(pDataReader("受注媒体").ToString) = True Then
                    parRequestData(i).sRequestMedia = ""
                Else
                    parRequestData(i).sRequestMedia = pDataReader("受注媒体").ToString
                End If
                'モバイルフラグ
                If IsDBNull(pDataReader("モバイルフラグ").ToString) = True Then
                    parRequestData(i).sMobileFlg = ""
                Else
                    parRequestData(i).sMobileFlg = pDataReader("モバイルフラグ").ToString
                End If
                'アフェリエイトフラグ
                If IsDBNull(pDataReader("アフェリエイトフラグ").ToString) = True Then
                    parRequestData(i).sAffiliateFlg = ""
                Else
                    parRequestData(i).sAffiliateFlg = pDataReader("アフェリエイトフラグ").ToString
                End If
                '受注日
                If IsDBNull(pDataReader("受注日").ToString) = True Then
                    parRequestData(i).sRequestDate = ""
                Else
                    parRequestData(i).sRequestDate = pDataReader("受注日").ToString
                End If
                '受注時間
                If IsDBNull(pDataReader("受注時間").ToString) = True Then
                    parRequestData(i).sRequestTime = ""
                Else
                    parRequestData(i).sRequestTime = pDataReader("受注時間").ToString
                End If
                '出荷先－会社名
                If IsDBNull(pDataReader("出荷先－会社名").ToString) = True Then
                    parRequestData(i).sShipCorpName = ""
                Else
                    parRequestData(i).sShipCorpName = pDataReader("出荷先－会社名").ToString
                End If
                '出荷先－支店名
                If IsDBNull(pDataReader("出荷先－支店名").ToString) = True Then
                    parRequestData(i).sShipDivName = ""
                Else
                    parRequestData(i).sShipDivName = pDataReader("出荷先－支店名").ToString
                End If
                '出荷先－姓カナ
                If IsDBNull(pDataReader("出荷先－姓カナ").ToString) = True Then
                    parRequestData(i).sShipKanaShip1stName = ""
                Else
                    parRequestData(i).sShipKanaShip1stName = pDataReader("出荷先－姓カナ").ToString
                End If
                '出荷先－名カナ
                If IsDBNull(pDataReader("出荷先－名カナ").ToString) = True Then
                    parRequestData(i).sShipKanaShip2ndName = ""
                Else
                    parRequestData(i).sShipKanaShip2ndName = pDataReader("出荷先－名カナ").ToString
                End If
                '出荷先－住所１カナ
                If IsDBNull(pDataReader("出荷先－住所１カナ").ToString) = True Then
                    parRequestData(i).sShipKanaAdder1 = ""
                Else
                    parRequestData(i).sShipKanaAdder1 = pDataReader("出荷先－住所１カナ").ToString
                End If
                '出荷先－住所２カナ
                If IsDBNull(pDataReader("出荷先－住所２カナ").ToString) = True Then
                    parRequestData(i).sShipKanaAdder2 = ""
                Else
                    parRequestData(i).sShipKanaAdder2 = pDataReader("出荷先－住所２カナ").ToString
                End If
                '出荷先－住所市区町村カナ
                If IsDBNull(pDataReader("出荷先－住所市区町村カナ").ToString) = True Then
                    parRequestData(i).sShipKanaCity = ""
                Else
                    parRequestData(i).sShipKanaCity = pDataReader("出荷先－住所市区町村カナ").ToString
                End If
                '出荷先－都道府県カナ
                If IsDBNull(pDataReader("出荷先－都道府県カナ").ToString) = True Then
                    parRequestData(i).sShipKanaState = ""
                Else
                    parRequestData(i).sShipKanaState = pDataReader("出荷先－都道府県カナ").ToString
                End If
                '出荷先－姓
                If IsDBNull(pDataReader("出荷先－姓").ToString) = True Then
                    parRequestData(i).sShip1stName = ""
                Else
                    parRequestData(i).sShip1stName = pDataReader("出荷先－姓").ToString
                End If
                '出荷先－名
                If IsDBNull(pDataReader("出荷先－名").ToString) = True Then
                    parRequestData(i).sShip2ndName = ""
                Else
                    parRequestData(i).sShip2ndName = pDataReader("出荷先－名").ToString
                End If
                '出荷先－住所１
                If IsDBNull(pDataReader("出荷先－住所１").ToString) = True Then
                    parRequestData(i).sShipAdder1 = ""
                Else
                    parRequestData(i).sShipAdder1 = pDataReader("出荷先－住所１").ToString
                End If
                '出荷先－住所２
                If IsDBNull(pDataReader("出荷先－住所２").ToString) = True Then
                    parRequestData(i).sShipAdder2 = ""
                Else
                    parRequestData(i).sShipAdder2 = pDataReader("出荷先－住所２").ToString
                End If
                '出荷先－住所市区町村
                If IsDBNull(pDataReader("出荷先－住所市区町村").ToString) = True Then
                    parRequestData(i).sShipCity = ""
                Else
                    parRequestData(i).sShipCity = pDataReader("出荷先－住所市区町村").ToString
                End If
                '出荷先－都道府県
                If IsDBNull(pDataReader("出荷先－都道府県").ToString) = True Then
                    parRequestData(i).sShipState = ""
                Else
                    parRequestData(i).sShipState = pDataReader("出荷先－都道府県").ToString
                End If
                '出荷先－国名
                If IsDBNull(pDataReader("出荷先－国名").ToString) = True Then
                    parRequestData(i).sShipCountry = ""
                Else
                    parRequestData(i).sShipCountry = pDataReader("出荷先－国名").ToString
                End If
                '出荷先－郵便番号1
                If IsDBNull(pDataReader("出荷先－郵便番号1").ToString) = True Then
                    parRequestData(i).sShipPostCode1 = ""
                Else
                    parRequestData(i).sShipPostCode1 = pDataReader("出荷先－郵便番号1").ToString
                End If
                '出荷先－郵便番号2
                If IsDBNull(pDataReader("出荷先－郵便番号2").ToString) = True Then
                    parRequestData(i).sShipPostCode2 = ""
                Else
                    parRequestData(i).sShipPostCode2 = pDataReader("出荷先－郵便番号2").ToString
                End If
                '出荷先－電話番号
                If IsDBNull(pDataReader("出荷先－電話番号").ToString) = True Then
                    parRequestData(i).sShipTel = ""
                Else
                    parRequestData(i).sShipTel = pDataReader("出荷先－電話番号").ToString
                End If
                '請求先－会社名
                If IsDBNull(pDataReader("請求先－会社名").ToString) = True Then
                    parRequestData(i).sBillCorpName = ""
                Else
                    parRequestData(i).sBillCorpName = pDataReader("請求先－会社名").ToString
                End If
                '請求先－支店名
                If IsDBNull(pDataReader("請求先－支店名").ToString) = True Then
                    parRequestData(i).sBillDivName = ""
                Else
                    parRequestData(i).sBillDivName = pDataReader("請求先－支店名").ToString
                End If
                '請求先－姓カナ
                If IsDBNull(pDataReader("請求先－姓カナ").ToString) = True Then
                    parRequestData(i).sBillKanaBill1stName = ""
                Else
                    parRequestData(i).sBillKanaBill1stName = pDataReader("請求先－姓カナ").ToString
                End If
                '請求先－名カナ
                If IsDBNull(pDataReader("請求先－名カナ").ToString) = True Then
                    parRequestData(i).sBillKanaBill2ndName = ""
                Else
                    parRequestData(i).sBillKanaBill2ndName = pDataReader("請求先－名カナ").ToString
                End If
                '請求先－住所１カナ
                If IsDBNull(pDataReader("請求先－住所１カナ").ToString) = True Then
                    parRequestData(i).sBillKanaAdder1 = ""
                Else
                    parRequestData(i).sBillKanaAdder1 = pDataReader("請求先－住所１カナ").ToString
                End If
                '請求先－住所２カナ
                If IsDBNull(pDataReader("請求先－住所２カナ").ToString) = True Then
                    parRequestData(i).sBillKanaAdder2 = ""
                Else
                    parRequestData(i).sBillKanaAdder2 = pDataReader("請求先－住所２カナ").ToString
                End If
                '請求先－住所市区町村カナ
                If IsDBNull(pDataReader("請求先－住所市区町村カナ").ToString) = True Then
                    parRequestData(i).sBillKanaCity = ""
                Else
                    parRequestData(i).sBillKanaCity = pDataReader("請求先－住所市区町村カナ").ToString
                End If
                '請求先－都道府県カナ
                If IsDBNull(pDataReader("請求先－都道府県カナ").ToString) = True Then
                    parRequestData(i).sBillKanaState = ""
                Else
                    parRequestData(i).sBillKanaState = pDataReader("請求先－都道府県カナ").ToString
                End If
                '請求先－姓
                If IsDBNull(pDataReader("請求先－姓").ToString) = True Then
                    parRequestData(i).sBill1stName = ""
                Else
                    parRequestData(i).sBill1stName = pDataReader("請求先－姓").ToString
                End If
                '請求先－名
                If IsDBNull(pDataReader("請求先－名").ToString) = True Then
                    parRequestData(i).sBill2ndName = ""
                Else
                    parRequestData(i).sBill2ndName = pDataReader("請求先－名").ToString
                End If
                '請求先－住所１
                If IsDBNull(pDataReader("請求先－住所１").ToString) = True Then
                    parRequestData(i).sBillAdder1 = ""
                Else
                    parRequestData(i).sBillAdder1 = pDataReader("請求先－住所１").ToString
                End If
                '請求先－住所２
                If IsDBNull(pDataReader("請求先－住所２").ToString) = True Then
                    parRequestData(i).sBillAdder2 = ""
                Else
                    parRequestData(i).sBillAdder2 = pDataReader("請求先－住所２").ToString
                End If
                '請求先－住所市区町村
                If IsDBNull(pDataReader("請求先－住所市区町村").ToString) = True Then
                    parRequestData(i).sBillCity = ""
                Else
                    parRequestData(i).sBillCity = pDataReader("請求先－住所市区町村").ToString
                End If
                '請求先－都道府県
                If IsDBNull(pDataReader("請求先－都道府県").ToString) = True Then
                    parRequestData(i).sBillState = ""
                Else
                    parRequestData(i).sBillState = pDataReader("請求先－都道府県").ToString
                End If
                '請求先－国名
                If IsDBNull(pDataReader("請求先－国名").ToString) = True Then
                    parRequestData(i).sBillCountry = ""
                Else
                    parRequestData(i).sBillCountry = pDataReader("請求先－国名").ToString
                End If
                '請求先－郵便番号1
                If IsDBNull(pDataReader("請求先－郵便番号1").ToString) = True Then
                    parRequestData(i).sBillPostCode1 = ""
                Else
                    parRequestData(i).sBillPostCode1 = pDataReader("請求先－郵便番号1").ToString
                End If
                '請求先－郵便番号2
                If IsDBNull(pDataReader("請求先－郵便番号2").ToString) = True Then
                    parRequestData(i).sBillPostCode2 = ""
                Else
                    parRequestData(i).sBillPostCode2 = pDataReader("請求先－郵便番号2").ToString
                End If
                '請求先－電話番号
                If IsDBNull(pDataReader("請求先－電話番号").ToString) = True Then
                    parRequestData(i).sBillTel = ""
                Else
                    parRequestData(i).sBillTel = pDataReader("請求先－電話番号").ToString
                End If
                'メールアドレス
                If IsDBNull(pDataReader("メールアドレス").ToString) = True Then
                    parRequestData(i).sMailAdderss = ""
                Else
                    parRequestData(i).sMailAdderss = pDataReader("メールアドレス").ToString
                End If
                'コメント
                If IsDBNull(pDataReader("コメント").ToString) = True Then
                    parRequestData(i).sComment = ""
                Else
                    parRequestData(i).sComment = pDataReader("コメント").ToString
                End If
                'ステータス
                If IsDBNull(pDataReader("ステータス").ToString) = True Then
                    parRequestData(i).sStatus = ""
                Else
                    parRequestData(i).sStatus = pDataReader("ステータス").ToString
                End If
                'エントリーポイント
                If IsDBNull(pDataReader("エントリーポイント").ToString) = True Then
                    parRequestData(i).sEntryPoint = ""
                Else
                    parRequestData(i).sEntryPoint = pDataReader("エントリーポイント").ToString
                End If
                'リンク先
                If IsDBNull(pDataReader("リンク先").ToString) = True Then
                    parRequestData(i).sLink = ""
                Else
                    parRequestData(i).sLink = pDataReader("リンク先").ToString
                End If
                'カード支払方法
                If IsDBNull(pDataReader("カード支払方法").ToString) = True Then
                    parRequestData(i).sCardPayment = ""
                Else
                    parRequestData(i).sCardPayment = pDataReader("カード支払方法").ToString
                End If
                '配達希望日
                If IsDBNull(pDataReader("配達希望日").ToString) = True Then
                    parRequestData(i).sShipRequestDate = ""
                Else
                    parRequestData(i).sShipRequestDate = pDataReader("配達希望日").ToString
                End If
                '配達希望時間
                If IsDBNull(pDataReader("配達希望時間").ToString) = True Then
                    parRequestData(i).sShipRequestTime = ""
                Else
                    parRequestData(i).sShipRequestTime = pDataReader("配達希望時間").ToString
                End If
                '配達希望メモ
                If IsDBNull(pDataReader("配達希望メモ").ToString) = True Then
                    parRequestData(i).sShipMemo = ""
                Else
                    parRequestData(i).sShipMemo = pDataReader("配達希望メモ").ToString
                End If
                '配送業者
                If IsDBNull(pDataReader("配送業者").ToString) = True Then
                    parRequestData(i).sShipCorp = ""
                Else
                    parRequestData(i).sShipCorp = pDataReader("配送業者").ToString
                End If
                'チャネル支払コード
                If IsDBNull(pDataReader("チャネル支払コード")) = True Then
                    parRequestData(i).sChannelPaymentCode = 0
                Else
                    parRequestData(i).sChannelPaymentCode = CInt(pDataReader("チャネル支払コード"))
                End If
                'ギフト梱包希望
                parRequestData(i).sGiftRequest = pDataReader("ギフト梱包希望").ToString
                '取得ポイント数
                If IsDBNull(pDataReader("取得ポイント数")) = True Then
                    parRequestData(i).sGetPoint = 0
                Else
                    parRequestData(i).sGetPoint = CLng(pDataReader("取得ポイント数"))
                End If
                '受注商品税抜金額
                If IsDBNull(pDataReader("受注商品税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalProductPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalProductPrice = CLng(pDataReader("受注商品税抜金額"))
                End If
                '送料
                If IsDBNull(pDataReader("送料")) = True Then
                    parRequestData(i).sShippingCharge = 0
                Else
                    parRequestData(i).sShippingCharge = CLng(pDataReader("送料"))
                End If
                '手数料
                If IsDBNull(pDataReader("手数料")) = True Then
                    parRequestData(i).sPaymentCharge = 0
                Else
                    parRequestData(i).sPaymentCharge = CLng(pDataReader("手数料"))
                End If
                '値引き
                If IsDBNull(pDataReader("値引き")) = True Then
                    parRequestData(i).sDiscount = 0
                Else
                    parRequestData(i).sDiscount = CLng(pDataReader("値引き"))
                End If
                'ポイント値引き
                If IsDBNull(pDataReader("ポイント値引き")) = True Then
                    parRequestData(i).sPointDisCount = 0
                Else
                    parRequestData(i).sPointDisCount = CLng(pDataReader("ポイント値引き"))
                End If
                '受注税抜金額
                If IsDBNull(pDataReader("受注税抜金額")) = True Then
                    parRequestData(i).sNoTaxTotalPrice = 0
                Else
                    parRequestData(i).sNoTaxTotalPrice = CLng(pDataReader("受注税抜金額"))
                End If
                '受注消費税額
                If IsDBNull(pDataReader("受注消費税額")) = True Then
                    parRequestData(i).sTaxTotal = 0
                Else
                    parRequestData(i).sTaxTotal = CLng(pDataReader("受注消費税額"))
                End If
                '受注税込金額
                If IsDBNull(pDataReader("受注税込金額")) = True Then
                    parRequestData(i).sTotalPrice = 0
                Else
                    parRequestData(i).sTotalPrice = CLng(pDataReader("受注税込金額"))
                End If
                'ギフト梱包材料
                parRequestData(i).sGiftWrapKind = pDataReader("ギフト梱包材料").ToString
                'ギフト梱包料金
                If IsDBNull(pDataReader("ギフト梱包料金")) = True Then
                    parRequestData(i).sGiftWrapKindPrice = 0
                Else
                    parRequestData(i).sGiftWrapKindPrice = CLng(pDataReader("ギフト梱包料金"))
                End If
                'のし希望
                If IsDBNull(pDataReader("のし希望").ToString) = True Then
                    parRequestData(i).sNoshiType = ""
                Else
                    parRequestData(i).sNoshiType = pDataReader("のし希望").ToString
                End If
                'のし記載内容
                If IsDBNull(pDataReader("のし記載内容").ToString) = True Then
                    parRequestData(i).sNoshiName = ""
                Else
                    parRequestData(i).sNoshiName = pDataReader("のし記載内容").ToString
                End If
                '注文者性別
                If IsDBNull(pDataReader("注文者性別").ToString) = True Then
                    parRequestData(i).sBillSex = ""
                Else
                    parRequestData(i).sBillSex = pDataReader("注文者性別").ToString
                End If
                '注文者誕生日
                If IsDBNull(pDataReader("注文者誕生日").ToString) = True Then
                    parRequestData(i).sBillBirthDay = ""
                Else
                    parRequestData(i).sBillBirthDay = pDataReader("注文者誕生日").ToString
                End If
                '楽天バンク決済手数料
                If IsDBNull(pDataReader("楽天バンク決済手数料")) = True Then
                    parRequestData(i).sRakutenCharge = 0
                Else
                    parRequestData(i).sRakutenCharge = CLng(pDataReader("楽天バンク決済手数料"))
                End If
                '受注伝票出力フラグ
                If IsDBNull(pDataReader("受注伝票出力フラグ")) = True Then
                    parRequestData(i).sPrintFlg = False
                Else
                    parRequestData(i).sPrintFlg = CBool(pDataReader("受注伝票出力フラグ"))
                End If
                '受注担当者コード
                If IsDBNull(pDataReader("受注担当者コード").ToString) = True Then
                    parRequestData(i).sStaffCode = ""
                Else
                    parRequestData(i).sStaffCode = pDataReader("受注担当者コード").ToString
                End If
                '登録日
                If IsDBNull(pDataReader("登録日").ToString) = True Then
                    parRequestData(i).sCreateDate = ""
                Else
                    parRequestData(i).sCreateDate = pDataReader("登録日").ToString
                End If
                '登録時間
                If IsDBNull(pDataReader("登録時間").ToString) = True Then
                    parRequestData(i).sCreateTime = ""
                Else
                    parRequestData(i).sCreateTime = pDataReader("登録時間").ToString
                End If
                '最終更新日
                If IsDBNull(pDataReader("最終更新日").ToString) = True Then
                    parRequestData(i).sUpdateDate = ""
                Else
                    parRequestData(i).sUpdateDate = pDataReader("最終更新日").ToString
                End If
                '最終更新時間
                If IsDBNull(pDataReader("最終更新時間").ToString) = True Then
                    parRequestData(i).sUpdateTime = ""
                Else
                    parRequestData(i).sUpdateTime = pDataReader("最終更新時間").ToString
                End If
                '2020,1,17 A.Komita 追加 To

                'レコードが取得できた時の処理
                i = i + 1
            End While

            getRequest2 = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function


    '----------------------------------------------------------------------
    '　機能：受注情報データに１レコードを登録するメソッド
    '　引数：in cSubOrderオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertRequestData(ByRef parRequestData As cStructureLib.sRequestData, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strInsert As String

        'SQL文の設定
        'strInsert = "INSERT INTO 受注情報データ (" &
        '                "受注コード, チャネルコード, OR受注コード, 受注サイト, 受注媒体, モバイルフラグ, アフェリエイトフラグ,受注日, 受注時間, 出荷先－会社名, 出荷先－支店名, 出荷先－姓カナ, 出荷先－名カナ, 出荷先－住所１カナ, 出荷先－住所２カナ,出荷先－住所市区町村カナ, 出荷先－都道府県カナ, 出荷先－姓, 出荷先－名, 出荷先－住所１, 出荷先－住所２, 出荷先－住所市区町村,出荷先－都道府県, 出荷先－国名, 出荷先－郵便番号1, 出荷先－郵便番号2, 出荷先－電話番号, 請求先－会社名, 請求先－支店名, 請求先－姓カナ, 請求先－名カナ, 請求先－住所１カナ, 請求先－住所２カナ, 請求先－住所市区町村カナ, 請求先－都道府県カナ,請求先－姓, 請求先－名, 請求先－住所１, 請求先－住所２, 請求先－住所市区町村, 請求先－都道府県, 請求先－国名, 請求先－郵便番号1,請求先－郵便番号2, 請求先－電話番号, メールアドレス, コメント, ステータス, エントリーポイント, リンク先, カード支払方法, 配達希望日, 配達希望時間, 配達希望メモ, 配送業者, チャネル支払コード, ギフト梱包希望, 取得ポイント数, 受注商品税抜金額, 送料, 手数料, 値引き, ポイント値引き, 受注税抜金額, 受注消費税額, 受注税込金額, ギフト梱包材料, ギフト梱包料金, のし希望,のし記載内容, 注文者性別, 注文者誕生日, 楽天バンク決済手数料, 受注伝票出力フラグ, 受注担当者コード, 登録日, 登録時間, 最終更新日, 最終更新時間" &
        '            ") VALUES (" &
        '                "@RequestCode, @ChannelCode, @ORRequestCode, @RequestSite, @RequestMedia, @MobileFlg, @AffiliateFlg, @RequestDate, @RequestTime, @ShipCorpName, @ShipDivName, @ShipKanaShip1stName, @ShipKanaShip2ndName, @ShipKanaAdder1, @ShipKanaAdder2, @ShipKanaCity, @ShipKanaState, @Ship1stName, @Ship2ndName, @ShipAdder1, @ShipAdder2, @ShipCity, @ShipState, @ShipCountry, @ShipPostCode1, @ShipPostCode2, @ShipTel, @BillCorpName, @BillDivName, @BillKanaBill1stName, @BillKanaBill2ndName, @BillKanaAdder1, @BillKanaAdder2, @BillKanaCity, @BillKanaState, @Bill1stName, @Bill2ndName, @BillAdder1, @BillAdder2, @BillCity, @BillState, @BillCountry, @BillPostCode1, @BillPostCode2, @BillTel, @MailAdderss, @Comment, @Status, @EntryPoint, @Link, @CardPayment, @ShipRequestDate, @ShipRequestTime, @ShipMemo, @ShipCorp, @ChannelPaymentCode, @GiftRequest, @GetPoint, @NoTaxTotalProductPrice, @ShippingCharge, @PaymentCharge, @Discount, @PointDisCount, @NoTaxTotalPrice, @TaxTotal, @TotalPrice, @GiftWrapKind, @GiftWrapKindPrice, @NoshiType, @NoshiName, @BillSex, @BillBirthDay, @RakutenCharge, @PrintFlg, @StaffCode, @CreateDate, @CreateTime, @UpdateDate, @UpdateTime" &
        '            ")"

        '2020,1,10 A.Komita SQL文の修正 Start
        strInsert = ""
        strInsert = "INSERT INTO 受注情報データ (" &
                               "受注コード, " &
                               "チャネルコード, " &
                               "OR受注コード, " &
                               "受注サイト, " &
                               "受注媒体, " &
                               "モバイルフラグ, " &
                               "アフェリエイトフラグ, " &
                               "受注日, " &
                               "受注時間, " &
                               "出荷先－会社名, " &
                               "出荷先－支店名, " &
                               "出荷先－姓カナ, " &
                               "出荷先－名カナ, " &
                               "出荷先－住所１カナ, " &
                               "出荷先－住所２カナ, " &
                               "出荷先－住所市区町村カナ, " &
                               "出荷先－都道府県カナ, " &
                               "出荷先－姓, " &
                               "出荷先－名, " &
                               "出荷先－住所１, " &
                               "出荷先－住所２, " &
                               "出荷先－住所市区町村, " &
                               "出荷先－都道府県, " &
                               "出荷先－国名, " &
                               "出荷先－郵便番号1, " &
                               "出荷先－郵便番号2, " &
                               "出荷先－電話番号, " &
                               "請求先－会社名, " &
                               "請求先－支店名, " &
                               "請求先－姓カナ, " &
                               "請求先－名カナ, " &
                               "請求先－住所１カナ, " &
                               "請求先－住所２カナ, " &
                               "請求先－住所市区町村カナ, " &
                               "請求先－都道府県カナ, " &
                               "請求先－姓, " &
                               "請求先－名, " &
                               "請求先－住所１, " &
                               "請求先－住所２, " &
                               "請求先－住所市区町村, " &
                               "請求先－都道府県, " &
                               "請求先－国名, " &
                               "請求先－郵便番号1, " &
                               "請求先－郵便番号2, " &
                               "請求先－電話番号, " &
                               "メールアドレス, " &
                               "コメント, " &
                               "ステータス, " &
                               "エントリーポイント, " &
                               "リンク先, " &
                               "カード支払方法, " &
                               "配達希望日, " &
                               "配達希望時間, " &
                               "配達希望メモ, " &
                               "配送業者, " &
                               "チャネル支払コード, " &
                               "ギフト梱包希望, " &
                               "取得ポイント数, " &
                               "受注商品税抜金額, " &
                               "送料, " &
                               "手数料, " &
                               "値引き, " &
                               "ポイント値引き, " &
                               "受注税抜金額, " &
                               "受注消費税額, " &
                               "受注税込金額, " &
                               "ギフト梱包材料, " &
                               "ギフト梱包料金, " &
                               "のし希望, " &
                               "のし記載内容, " &
                               "注文者性別, " &
                               "注文者誕生日, " &
                               "楽天バンク決済手数料, " &
                               "受注伝票出力フラグ, " &
                               "受注担当者コード, " &
                               "登録日, " &
                               "登録時間, " &
                               "最終更新日, " &
                               "最終更新時間 " &
                           ") VALUES (" &
                               "@RequestCode, " &
                               "@ChannelCode, " &
                               "@ORRequestCode, " &
                               "@RequestSite, " &
                               "@RequestMedia, " &
                               "@MobileFlg, " &
                               "@AffiliateFlg, " &
                               "@RequestDate, " &
                               "@RequestTime, " &
                               "@ShipCorpName, " &
                               "@ShipDivName, " &
                               "@ShipKanaShip1stName, " &
                               "@ShipKanaShip2ndName, " &
                               "@ShipKanaAdder1, " &
                               "@ShipKanaAdder2, " &
                               "@ShipKanaCity, " &
                               "@ShipKanaState, " &
                               "@Ship1stName, " &
                               "@Ship2ndName, " &
                               "@ShipAdder1, " &
                               "@ShipAdder2, " &
                               "@ShipCity, " &
                               "@ShipState, " &
                               "@ShipCountry, " &
                               "@ShipPostCode1, " &
                               "@ShipPostCode2, " &
                               "@ShipTel, " &
                               "@BillCorpName, " &
                               "@BillDivName, " &
                               "@BillKanaBill1stName, " &
                               "@BillKanaBill2ndName, " &
                               "@BillKanaAdder1, " &
                               "@BillKanaAdder2, " &
                               "@BillKanaCity, " &
                               "@BillKanaState, " &
                               "@Bill1stName, " &
                               "@Bill2ndName, " &
                               "@BillAdder1, " &
                               "@BillAdder2, " &
                               "@BillCity, " &
                               "@BillState, " &
                               "@BillCountry, " &
                               "@BillPostCode1, " &
                               "@BillPostCode2, " &
                               "@BillTel, " &
                               "@MailAdderss, " &
                               "@Comment, " &
                               "@Status, " &
                               "@EntryPoint, " &
                               "@Link, " &
                               "@CardPayment, " &
                               "@ShipRequestDate, " &
                               "@ShipRequestTime, " &
                               "@ShipMemo, " &
                               "@ShipCorp, " &
                               "@ChannelPaymentCode, " &
                               "@GiftRequest, " &
                               "@GetPoint, " &
                               "@NoTaxTotalProductPrice, " &
                               "@ShippingCharge, " &
                               "@PaymentCharge, " &
                               "@Discount, " &
                               "@PointDisCount, " &
                               "@NoTaxTotalPrice, " &
                               "@TaxTotal, " &
                               "@TotalPrice, " &
                               "@GiftWrapKind, " &
                               "@GiftWrapKindPrice, " &
                               "@NoshiType, " &
                               "@NoshiName, " &
                               "@BillSex, " &
                               "@BillBirthDay, " &
                               "@RakutenCharge, " &
                               "@PrintFlg, " &
                               "@StaffCode, " &
                               "@CreateDate, " &
                               "@CreateTime, " &
                               "@UpdateDate, " &
                               "@UpdateTime" &
                           ")"
        '2020,1,10 A.Komita 修正 End

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            pCommand.CommandText = strInsert

            '***********************
            'パラメータの設定()
            '***********************

            '2020,1,10 A.Komita Nothingでエラー判定が発生する為、空白もしくは0を代入するif文を追加 From
            '受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestCode", OleDb.OleDbType.Char, 13))
            If parRequestData.sRequestCode = Nothing Then
                pCommand.Parameters("@RequestCode").Value = ""
            Else
                pCommand.Parameters("@RequestCode").Value = parRequestData.sRequestCode
            End If
            'チャネルコード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelCode", OleDb.OleDbType.Numeric, 2))
            pCommand.Parameters("@ChannelCode").Value = parRequestData.sChannelCode
            'OR受注コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ORRequestCode", OleDb.OleDbType.Char, 50))
            If parRequestData.sORRequestCode = Nothing Then
                pCommand.Parameters("@ORRequestCode").Value = ""
            Else
                pCommand.Parameters("@ORRequestCode").Value = parRequestData.sORRequestCode
            End If
            '受注サイト
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestSite", OleDb.OleDbType.Char, 50))
            If parRequestData.sRequestSite = Nothing Then
                pCommand.Parameters("@RequestSite").Value = ""
            Else
                pCommand.Parameters("@RequestSite").Value = parRequestData.sRequestSite
            End If
            '受注媒体
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestMedia", OleDb.OleDbType.Char, 10))
            If parRequestData.sRequestMedia = Nothing Then
                pCommand.Parameters("@RequestMedia").Value = ""
            Else
                pCommand.Parameters("@RequestMedia").Value = parRequestData.sRequestMedia
            End If
            'モバイルフラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MobileFlg", OleDb.OleDbType.Char, 1))
            If parRequestData.sMobileFlg = Nothing Then
                pCommand.Parameters("@MobileFlg").Value = ""
            Else
                pCommand.Parameters("@MobileFlg").Value = parRequestData.sMobileFlg
            End If
            'アフェリエイトフラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@AffiliateFlg", OleDb.OleDbType.Char, 1))
            If parRequestData.sAffiliateFlg = Nothing Then
                pCommand.Parameters("@AffiliateFlg").Value = ""
            Else
                pCommand.Parameters("@AffiliateFlg").Value = parRequestData.sAffiliateFlg
            End If
            '受注日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestDate", OleDb.OleDbType.Char, 10))
            If parRequestData.sRequestDate = Nothing Then
                pCommand.Parameters("@RequestDate").Value = ""
            Else
                pCommand.Parameters("@RequestDate").Value = parRequestData.sRequestDate
            End If
            '受注時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RequestTime", OleDb.OleDbType.Char, 8))
            If parRequestData.sRequestTime = Nothing Then
                pCommand.Parameters("@RequestTime").Value = ""
            Else
                pCommand.Parameters("@RequestTime").Value = parRequestData.sRequestTime
            End If
            '出荷先－会社名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCorpName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipCorpName = Nothing Then
                pCommand.Parameters("@ShipCorpName").Value = ""
            Else
                pCommand.Parameters("@ShipCorpName").Value = parRequestData.sShipCorpName
            End If
            '出荷先－支店名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipDivName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipDivName = Nothing Then
                pCommand.Parameters("@ShipDivName").Value = ""
            Else
                pCommand.Parameters("@ShipDivName").Value = parRequestData.sShipDivName
            End If
            '出荷先－姓カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaShip1stName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipKanaShip1stName = Nothing Then
                pCommand.Parameters("@ShipKanaShip1stName").Value = ""
            Else
                pCommand.Parameters("@ShipKanaShip1stName").Value = parRequestData.sShipKanaShip1stName
            End If
            '出荷先－名カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaShip2ndName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipKanaShip2ndName = Nothing Then
                pCommand.Parameters("@ShipKanaShip2ndName").Value = ""
            Else
                pCommand.Parameters("@ShipKanaShip2ndName").Value = parRequestData.sShipKanaShip2ndName
            End If
            '出荷先－住所１カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaAdder1", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipKanaAdder1 = Nothing Then
                pCommand.Parameters("@ShipKanaAdder1").Value = ""
            Else
                pCommand.Parameters("@ShipKanaAdder1").Value = parRequestData.sShipKanaAdder1
            End If
            '出荷先－住所２カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaAdder2", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipKanaAdder2 = Nothing Then
                pCommand.Parameters("@ShipKanaAdder2").Value = ""
            Else
                pCommand.Parameters("@ShipKanaAdder2").Value = parRequestData.sShipKanaAdder2
            End If
            '出荷先－住所市区町村カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaCity", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipKanaCity = Nothing Then
                pCommand.Parameters("@ShipKanaCity").Value = ""
            Else
                pCommand.Parameters("@ShipKanaCity").Value = parRequestData.sShipKanaCity
            End If
            '出荷先－都道府県カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipKanaState", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipKanaState = Nothing Then
                pCommand.Parameters("@ShipKanaState").Value = ""
            Else
                pCommand.Parameters("@ShipKanaState").Value = parRequestData.sShipKanaState
            End If
            '出荷先－姓
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Ship1stName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShip1stName = Nothing Then
                pCommand.Parameters("@Ship1stName").Value = ""
            Else
                pCommand.Parameters("@Ship1stName").Value = parRequestData.sShip1stName
            End If
            '出荷先－名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Ship2ndName", OleDb.OleDbType.Char, 50))
            If parRequestData.sShip2ndName = Nothing Then
                pCommand.Parameters("@Ship2ndName").Value = ""
            Else
                pCommand.Parameters("@Ship2ndName").Value = parRequestData.sShip2ndName
            End If
            '出荷先－住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipAdder1", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipAdder1 = Nothing Then
                pCommand.Parameters("@ShipAdder1").Value = ""
            Else
                pCommand.Parameters("@ShipAdder1").Value = parRequestData.sShipAdder1
            End If
            '出荷先－住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipAdder2", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipAdder2 = Nothing Then
                pCommand.Parameters("@ShipAdder2").Value = ""
            Else
                pCommand.Parameters("@ShipAdder2").Value = parRequestData.sShipAdder2
            End If
            '出荷先－住所市区町村
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCity", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipCity = Nothing Then
                pCommand.Parameters("@ShipCity").Value = ""
            Else
                pCommand.Parameters("@ShipCity").Value = parRequestData.sShipCity
            End If
            '出荷先－都道府県
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipState", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipState = Nothing Then
                pCommand.Parameters("@ShipState").Value = ""
            Else
                pCommand.Parameters("@ShipState").Value = parRequestData.sShipState
            End If
            '出荷先－国名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCountry", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipCountry = Nothing Then
                pCommand.Parameters("@ShipCountry").Value = ""
            Else
                pCommand.Parameters("@ShipCountry").Value = parRequestData.sShipCountry
            End If
            '出荷先－郵便番号1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPostCode1", OleDb.OleDbType.Char, 3))
            If parRequestData.sShipPostCode1 = Nothing Then
                pCommand.Parameters("@ShipPostCode1").Value = ""
            Else
                pCommand.Parameters("@ShipPostCode1").Value = parRequestData.sShipPostCode1
            End If
            '出荷先－郵便番号2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipPostCode2", OleDb.OleDbType.Char, 4))
            If parRequestData.sShipPostCode2 = Nothing Then
                pCommand.Parameters("@ShipPostCode2").Value = ""
            Else
                pCommand.Parameters("@ShipPostCode2").Value = parRequestData.sShipPostCode2
            End If
            '出荷先－電話番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipTel", OleDb.OleDbType.Char, 13))
            If parRequestData.sShipTel = Nothing Then
                pCommand.Parameters("@ShipTel").Value = ""
            Else
                pCommand.Parameters("@ShipTel").Value = parRequestData.sShipTel
            End If
            '請求先－会社名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCorpName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillCorpName = Nothing Then
                pCommand.Parameters("@BillCorpName").Value = ""
            Else
                pCommand.Parameters("@BillCorpName").Value = parRequestData.sBillCorpName
            End If
            '請求先－支店名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillDivName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillDivName = Nothing Then
                pCommand.Parameters("@BillDivName").Value = ""
            Else
                pCommand.Parameters("@BillDivName").Value = parRequestData.sBillDivName
            End If
            '請求先－姓カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaBill1stName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillKanaBill1stName = Nothing Then
                pCommand.Parameters("@BillKanaBill1stName").Value = ""
            Else
                pCommand.Parameters("@BillKanaBill1stName").Value = parRequestData.sBillKanaBill1stName
            End If
            '請求先－名カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaBill2ndName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillKanaBill2ndName = Nothing Then
                pCommand.Parameters("@BillKanaBill2ndName").Value = ""
            Else
                pCommand.Parameters("@BillKanaBill2ndName").Value = parRequestData.sBillKanaBill2ndName
            End If
            '請求先－住所１カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaAdder1", OleDb.OleDbType.Char, 255))
            If parRequestData.sBillKanaAdder1 = Nothing Then
                pCommand.Parameters("@BillKanaAdder1").Value = ""
            Else
                pCommand.Parameters("@BillKanaAdder1").Value = parRequestData.sBillKanaAdder1
            End If
            '請求先－住所２カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaAdder2", OleDb.OleDbType.Char, 255))
            If parRequestData.sBillKanaAdder2 = Nothing Then
                pCommand.Parameters("@BillKanaAdder2").Value = ""
            Else
                pCommand.Parameters("@BillKanaAdder2").Value = parRequestData.sBillKanaAdder2
            End If
            '請求先－住所市区町村カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaCity", OleDb.OleDbType.Char, 255))
            If parRequestData.sBillKanaCity = Nothing Then
                pCommand.Parameters("@BillKanaCity").Value = ""
            Else
                pCommand.Parameters("@BillKanaCity").Value = parRequestData.sBillKanaCity
            End If
            '請求先－都道府県カナ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillKanaState", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillKanaState = Nothing Then
                pCommand.Parameters("@BillKanaState").Value = ""
            Else
                pCommand.Parameters("@BillKanaState").Value = parRequestData.sBillKanaState
            End If
            '請求先－姓
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Bill1stName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBill1stName = Nothing Then
                pCommand.Parameters("@Bill1stName").Value = ""
            Else
                pCommand.Parameters("@Bill1stName").Value = parRequestData.sBill1stName
            End If
            '請求先－名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Bill2ndName", OleDb.OleDbType.Char, 50))
            If parRequestData.sBill2ndName = Nothing Then
                pCommand.Parameters("@Bill2ndName").Value = ""
            Else
                pCommand.Parameters("@Bill2ndName").Value = parRequestData.sBill2ndName
            End If
            '請求先－住所１
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillAdder1", OleDb.OleDbType.Char, 5))
            If parRequestData.sBillAdder1 = Nothing Then
                pCommand.Parameters("@BillAdder1").Value = ""
            Else
                pCommand.Parameters("@BillAdder1").Value = parRequestData.sBillAdder1
            End If
            '請求先－住所２
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillAdder2", OleDb.OleDbType.Char, 255))
            If parRequestData.sBillAdder2 = Nothing Then
                pCommand.Parameters("@BillAdder2").Value = ""
            Else
                pCommand.Parameters("@BillAdder2").Value = parRequestData.sBillAdder2
            End If
            '請求先－住所市区町村
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCity", OleDb.OleDbType.Char, 255))
            If parRequestData.sBillCity = Nothing Then
                pCommand.Parameters("@BillCity").Value = ""
            Else
                pCommand.Parameters("@BillCity").Value = parRequestData.sBillCity
            End If
            '請求先－都道府県
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillState", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillState = Nothing Then
                pCommand.Parameters("@BillState").Value = ""
            Else
                pCommand.Parameters("@BillState").Value = parRequestData.sBillState
            End If
            '請求先－国名
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillCountry", OleDb.OleDbType.Char, 50))
            If parRequestData.sBillCountry = Nothing Then
                pCommand.Parameters("@BillCountry").Value = ""
            Else
                pCommand.Parameters("@BillCountry").Value = parRequestData.sBillCountry
            End If
            '請求先－郵便番号1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillPostCode1", OleDb.OleDbType.Char, 3))
            If parRequestData.sBillPostCode1 = Nothing Then
                pCommand.Parameters("@BillPostCode1").Value = ""
            Else
                pCommand.Parameters("@BillPostCode1").Value = parRequestData.sBillPostCode1
            End If
            '請求先－郵便番号2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillPostCode2", OleDb.OleDbType.Char, 4))
            If parRequestData.sBillPostCode2 = Nothing Then
                pCommand.Parameters("@BillPostCode2").Value = ""
            Else
                pCommand.Parameters("@BillPostCode2").Value = parRequestData.sBillPostCode2
            End If
            '請求先－電話番号
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillTel", OleDb.OleDbType.Char, 13))
            If parRequestData.sBillTel = Nothing Then
                pCommand.Parameters("@BillTel").Value = ""
            Else
                pCommand.Parameters("@BillTel").Value = parRequestData.sBillTel
            End If
            'メールアドレス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@MailAdderss", OleDb.OleDbType.Char, 50))
            If parRequestData.sMailAdderss = Nothing Then
                pCommand.Parameters("@MailAdderss").Value = ""
            Else
                pCommand.Parameters("@MailAdderss").Value = parRequestData.sMailAdderss
            End If
            'コメント
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Comment", OleDb.OleDbType.Char, 255))
            If parRequestData.sComment = Nothing Then
                pCommand.Parameters("@Comment").Value = ""
            Else
                pCommand.Parameters("@Comment").Value = parRequestData.sComment
            End If
            'ステータス
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Status", OleDb.OleDbType.Char, 50))
            If parRequestData.sStatus = Nothing Then
                pCommand.Parameters("@Status").Value = ""
            Else
                pCommand.Parameters("@Status").Value = parRequestData.sStatus
            End If
            'エントリーポイント
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@EntryPoint", OleDb.OleDbType.Char, 255))
            If parRequestData.sEntryPoint = Nothing Then
                pCommand.Parameters("@EntryPoint").Value = ""
            Else
                pCommand.Parameters("@EntryPoint").Value = parRequestData.sEntryPoint
            End If
            'リンク先
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Link", OleDb.OleDbType.Char, 255))
            If parRequestData.sLink = Nothing Then
                pCommand.Parameters("@Link").Value = ""
            Else
                pCommand.Parameters("@Link").Value = parRequestData.sLink
            End If
            'カード支払方法
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CardPayment", OleDb.OleDbType.Char, 50))
            If parRequestData.sCardPayment = Nothing Then
                pCommand.Parameters("@CardPayment").Value = ""
            Else
                pCommand.Parameters("@CardPayment").Value = parRequestData.sCardPayment
            End If
            '配達希望日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestDate", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipRequestDate = Nothing Then
                pCommand.Parameters("@ShipRequestDate").Value = ""
            Else
                pCommand.Parameters("@ShipRequestDate").Value = parRequestData.sShipRequestDate
            End If
            '配達希望時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipRequestTime", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipRequestTime = Nothing Then
                pCommand.Parameters("@ShipRequestTime").Value = ""
            Else
                pCommand.Parameters("@ShipRequestTime").Value = parRequestData.sShipRequestTime
            End If
            '配達希望メモ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipMemo", OleDb.OleDbType.Char, 255))
            If parRequestData.sShipMemo = Nothing Then
                pCommand.Parameters("@ShipMemo").Value = ""
            Else
                pCommand.Parameters("@ShipMemo").Value = parRequestData.sShipMemo
            End If
            '配送業者
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShipCorp", OleDb.OleDbType.Char, 50))
            If parRequestData.sShipCorp = Nothing Then
                pCommand.Parameters("@ShipCorp").Value = ""
            Else
                pCommand.Parameters("@ShipCorp").Value = parRequestData.sShipCorp
            End If
            'チャネル支払コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ChannelPaymentCode", OleDb.OleDbType.Numeric, 2))
            If parRequestData.sChannelPaymentCode = Nothing Then
                pCommand.Parameters("@ChannelPaymentCode").Value = 0
            Else
                pCommand.Parameters("@ChannelPaymentCode").Value = parRequestData.sChannelPaymentCode
            End If
            'ギフト梱包希望
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftRequest", OleDb.OleDbType.Char, 1))
            If parRequestData.sGiftRequest = Nothing Then
                pCommand.Parameters("@GiftRequest").Value = ""
            Else
                pCommand.Parameters("@GiftRequest").Value = parRequestData.sGiftRequest
            End If
            '取得ポイント数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GetPoint", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sShippingCharge = Nothing Then
                pCommand.Parameters("@GetPoint").Value = 0
            Else
                pCommand.Parameters("@GetPoint").Value = parRequestData.sShippingCharge
            End If
            '受注商品税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalProductPrice", OleDb.OleDbType.Numeric, 10))
            If parRequestData.sNoTaxTotalProductPrice = Nothing Then
                pCommand.Parameters("@NoTaxTotalProductPrice").Value = 0
            Else
                pCommand.Parameters("@NoTaxTotalProductPrice").Value = parRequestData.sNoTaxTotalProductPrice
            End If
            '送料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@ShippingCharge", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sShippingCharge = Nothing Then
                pCommand.Parameters("@ShippingCharge").Value = 0
            Else
                pCommand.Parameters("@ShippingCharge").Value = parRequestData.sShippingCharge
            End If
            '手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PaymentCharge", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sPaymentCharge = Nothing Then
                pCommand.Parameters("@PaymentCharge").Value = 0
            Else
                pCommand.Parameters("@PaymentCharge").Value = parRequestData.sPaymentCharge
            End If
            '値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Discount", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sDiscount = Nothing Then
                pCommand.Parameters("@Discount").Value = 0
            Else
                pCommand.Parameters("@Discount").Value = parRequestData.sDiscount
            End If
            'ポイント値引き
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PointDisCount", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sPointDisCount = Nothing Then
                pCommand.Parameters("@PointDisCount").Value = 0
            Else
                pCommand.Parameters("@PointDisCount").Value = parRequestData.sPointDisCount
            End If
            '受注税抜金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoTaxTotalPrice", OleDb.OleDbType.Numeric, 10))
            If parRequestData.sNoTaxTotalPrice = Nothing Then
                pCommand.Parameters("@NoTaxTotalPrice").Value = 0
            Else
                pCommand.Parameters("@NoTaxTotalPrice").Value = parRequestData.sNoTaxTotalPrice
            End If
            '受注消費税額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TaxTotal", OleDb.OleDbType.Numeric, 10))
            If parRequestData.sTaxTotal = Nothing Then
                pCommand.Parameters("@TaxTotal").Value = 0
            Else
                pCommand.Parameters("@TaxTotal").Value = parRequestData.sTaxTotal
            End If
            '受注税込金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@TotalPrice", OleDb.OleDbType.Numeric, 10))
            If parRequestData.sTotalPrice = Nothing Then
                pCommand.Parameters("@TotalPrice").Value = 0
            Else
                pCommand.Parameters("@TotalPrice").Value = parRequestData.sTotalPrice
            End If
            'ギフト梱包材料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftWrapKind", OleDb.OleDbType.Char, 50))
            If parRequestData.sGiftWrapKind = Nothing Then
                pCommand.Parameters("@GiftWrapKind").Value = ""
            Else
                pCommand.Parameters("@GiftWrapKind").Value = parRequestData.sGiftWrapKind
            End If
            'ギフト梱包料金
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@GiftWrapKindPrice", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sGiftWrapKindPrice = Nothing Then
                pCommand.Parameters("@GiftWrapKindPrice").Value = 0
            Else
                pCommand.Parameters("@GiftWrapKindPrice").Value = parRequestData.sGiftWrapKindPrice
            End If
            'のし希望
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoshiType", OleDb.OleDbType.Char, 1))
            If parRequestData.sNoshiType = Nothing Then
                pCommand.Parameters("@NoshiType").Value = ""
            Else
                pCommand.Parameters("@NoshiType").Value = parRequestData.sNoshiType
            End If
            'のし記載内容
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@NoshiName", OleDb.OleDbType.Char, 50))
            If parRequestData.sNoshiName = Nothing Then
                pCommand.Parameters("@NoshiName").Value = ""
            Else
                pCommand.Parameters("@NoshiName").Value = parRequestData.sNoshiName
            End If
            '注文者性別
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillSex", OleDb.OleDbType.Char, 6))
            If parRequestData.sBillSex = Nothing Then
                pCommand.Parameters("@BillSex").Value = ""
            Else
                pCommand.Parameters("@BillSex").Value = parRequestData.sBillSex
            End If
            '注文者誕生日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@BillBirthDay", OleDb.OleDbType.Char, 10))
            If parRequestData.sBillBirthDay = Nothing Then
                pCommand.Parameters("@BillBirthDay").Value = ""
            Else
                pCommand.Parameters("@BillBirthDay").Value = parRequestData.sBillBirthDay
            End If
            '楽天バンク決済手数料
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RakutenCharge", OleDb.OleDbType.Numeric, 5))
            If parRequestData.sRakutenCharge = Nothing Then
                pCommand.Parameters("@RakutenCharge").Value = 0
            Else
                pCommand.Parameters("@RakutenCharge").Value = parRequestData.sRakutenCharge
            End If
            '受注伝票出力フラグ
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@PrintFlg", OleDb.OleDbType.Boolean, 1))
            If parRequestData.sPrintFlg = Nothing Then
                pCommand.Parameters("@PrintFlg").Value = 0
            Else
                pCommand.Parameters("@PrintFlg").Value = parRequestData.sPrintFlg
            End If
            '受注担当者コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@StaffCode", OleDb.OleDbType.Char, 13))
            If parRequestData.sStaffCode = Nothing Then
                pCommand.Parameters("@StaffCode").Value = "0"
            Else
                pCommand.Parameters("@StaffCode").Value = parRequestData.sStaffCode
            End If
            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CreateTime").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:yyyy/MM/dd}", Now)
            '2020,1,10 A.Komita 追加 To

            '受注情報データ挿入処理実行
            insertRequestData = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.insertRequestMst)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：受注情報データから最大の発注番号を取得する関数
    '　引数：Byref DataTable型オブジェクト(取得された取引レコード値を設定)
    '　戻値：最大受注番号
    '----------------------------------------------------------------------
    Public Function getMaxRequestCode(ByVal KeyChannelCode As Integer, ByVal KeyDate As String, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim strSelect As String
        Dim MaxRequestNo As Long

        strSelect = ""

        Try

            strSelect = "SELECT 受注コード FROM 受注情報データ " & _
                        "WHERE 受注コード Like ""992" & String.Format("{0:0}", KeyChannelCode) & KeyDate & "%"" " & _
                        "ORDER BY 受注コード DESC"

            'コマンドオブジェクトの生成
            pCommand = pConn.CreateCommand()
            pCommand.Transaction = Tran

            'SQL文の設定
            pCommand.CommandText = strSelect

            pDataReader = pCommand.ExecuteReader()

            MaxRequestNo = 0
            If pDataReader.Read() Then

                '最大発注番号の抽出
                If IsDBNull(pDataReader("受注コード")) = True Then
                    MaxRequestNo = 0
                Else
                    MaxRequestNo = CLng(Mid(pDataReader("受注コード").ToString, 11, 2))
                    If MaxRequestNo = 99 Then
                        MaxRequestNo = -1
                    Else
                        MaxRequestNo += 1
                    End If
                End If

            End If
            getMaxRequestCode = MaxRequestNo

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.getMaxRequestCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function


    '----------------------------------------------------------------------
    '　機能：注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
    '        一時表から受注情報および受注情報明細をまとめて登録する
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String

        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            strSQL = "INSERT INTO 受注情報データ " & _
                     "SELECT * FROM 受注情報データTMP " & _
                     "WHERE NOT EXISTS( " & _
                         "SELECT 1 FROM 受注情報明細データTMP, 商品コード変換マスタ " & _
                         "WHERE 受注情報明細データTMP.受注コード      = 受注情報データTMP.受注コード " & _
                         "AND 商品コード変換マスタ.チャネルコード     = 受注情報データTMP.チャネルコード " & _
                         "AND 商品コード変換マスタ.チャネル商品コード = 受注情報明細データTMP.チャネル商品コード " & _
                         "AND 商品コード変換マスタ.チャネル商品名称   = 受注情報明細データTMP.チャネル商品名称 " & _
                         "AND ( " & _
                         "        (商品コード変換マスタ.チャネルオプション = 受注情報明細データTMP.チャネルオプション) " & _
                         "    OR " & _
                         "        ((商品コード変換マスタ.チャネルオプション IS NULL) AND (受注情報明細データTMP.チャネルオプション IS NULL)) " & _
                         "    OR " & _
                         "        ((商品コード変換マスタ.チャネルオプション = """") AND (受注情報明細データTMP.チャネルオプション = """")) " & _
                         "    ) " & _
                         "AND (ISNULL(商品コード変換マスタ.商品コード) OR 商品コード変換マスタ.商品コード = """") " & _
                     ") "

            pCommand.CommandText = strSQL
            insertTmpToRequest = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.insertTmpToRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    '----------------------------------------------------------------------
    '　機能：注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
    '        一時表から受注情報および受注情報明細をまとめて登録する
    '　引数：
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteTmpToRequest(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSQL As String
        Dim executeCount As Long = 0

        pCommand = pConn.CreateCommand
        pCommand.Transaction = Tran

        Try

            'コピー済み一時表データ(受注情報データTMP)の削除
            strSQL = "DELETE FROM 受注情報データTMP " & _
                     "WHERE EXISTS( " & _
                     "			SELECT	1 " & _
                     "			FROM	受注情報データ " & _
                     "			WHERE	受注情報データ.受注コード = 受注情報データTMP.受注コード " & _
                     "	   ) "
            pCommand.CommandText = strSQL
            deleteTmpToRequest = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.deleteTmpToRequest)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

    Public Function deleteSetData(ByVal KeyORRequestCode As String, _
                                 ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim result As Integer = 0
        Dim strSQL As String
        Try
            strSQL = "DELETE FROM 受注情報明細データ " & _
                     "WHERE 受注情報明細データ.OR受注コード=""" & KeyORRequestCode & """ "
            '"AND NOT EXISTS ( SELECT 1 FROM 出荷情報データ WHERE 出荷情報データ.受注コード = 受注情報明細データ.受注コード )"
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran
            pCommand.CommandText = strSQL
            result = pCommand.ExecuteNonQuery()
            If result > 0 Then
                strSQL = "DELETE FROM 受注情報データ " & _
                         "WHERE OR受注コード=""" & KeyORRequestCode & """ "
                pCommand = pConn.CreateCommand
                pCommand.Transaction = Tran
                pCommand.CommandText = strSQL
                result = pCommand.ExecuteNonQuery()
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.deleteForRewrite)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
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
    Public Function updatePrintFlg(ByVal KeyRequestCode As String, ByVal KeyPrintFlg As Boolean, ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strUpdate As String

        'SQL文の設定
        strUpdate = "UPDATE 受注情報データ SET " & _
                            "受注伝票出力フラグ = " & KeyPrintFlg & ", " & _
                            "最終更新日=""" & String.Format("{0:yyyy/MM/dd}", Now) & """, " & _
                            "最終更新時間=""" & String.Format("{0:HH:mm:ss}", Now) & """ " & _
                            "WHERE 受注コード=""" & KeyRequestCode & """ "
        Try
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strUpdate

            '商品マスタ挿入処理実行()
            updatePrintFlg = pCommand.ExecuteNonQuery()

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataRequestDBIO.updatePrintFlg)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            System.Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function

End Class
