Option Explicit On

Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO

Public Class cBufferNetImportCSV

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private sColumn() As cStructureLib.sDownloadColumn
    Private cMstDownloadColumnDBIO As cMstDownloadColumnDBIO

    Private oMstCnvProductCdDBIO As cMstCnvProductCdDBIO
    Private oDataRequestDBIO As cDataRequestDBIO
    Private oDataRequestTMPDBIO As cDataRequestTMPDBIO
    Private oDataRequestSubTMPDBIO As cDataRequestSubTMPDBIO

    Private oChannelDBIO As cMstChannelDBIO

    Private oChannelPayment() As cStructureLib.sChannelPayment
    Private oMstChannelMstPaymentDBIO As cMstChannelPaymentDBIO


    Private oProduct() As cStructureLib.sViewProductPlusSalePrice
    Private oMstProductDBIO As cMstProductDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private WindowMode As Integer

    Private l As cLog = Nothing

    Private Const PRICE_MARG = 3

    Private Const ITEM_CNT = 48

    Sub New( _
        ByRef iConn As OleDb.OleDbConnection, _
        ByRef iCommand As OleDb.OleDbCommand, _
        ByRef iDataReader As OleDb.OleDbDataReader, _
        ByRef iTran As System.Data.OleDb.OleDbTransaction, _
        ByVal iWindowMode As Integer)
        'WindowMode = 0　ウィンドウ無し　　1:ウィンドウ有り

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oDataRequestTMPDBIO = New cDataRequestTMPDBIO(oConn, oCommand, oDataReader)
        oDataRequestSubTMPDBIO = New cDataRequestSubTMPDBIO(oConn, oCommand, oDataReader)
        oMstCnvProductCdDBIO = New cMstCnvProductCdDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstChannelMstPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oTool = New cTool


        WindowMode = iWindowMode
    End Sub

    Public Sub IMPORT(Optional ByVal path As String = "")
        Dim i As Integer
        Dim Path1 As String
        Dim Path2 As String
        Dim msg As String
        Dim tempFilePath As String
        Dim isOverWriteMode As Boolean
        Dim oChannel() As cStructureLib.sChannel

        'Try
        ReDim oConf(0)
        oMstConfigDBIO.getConfMst(oConf, oTran)

        'ログハンドル
        l = New cLog(Application.StartupPath & "\Net\Log", "NetImport")
        l.open()

        'ログハンドルの設定 (受注情報データTMP、受注情報明細データTMP)
        oDataRequestTMPDBIO.setLogWriter(l)
        oDataRequestSubTMPDBIO.setLogWriter(l)

        'DBメタ情報の設定 (受注情報データTMP、受注情報明細データTMP)
        oDataRequestTMPDBIO.setMetaInfo(oTran)
        oDataRequestSubTMPDBIO.setMetaInfo(oTran)

        ReDim oChannel(0)
        oChannelDBIO.getChannelMst(oChannel, Nothing, 2, Nothing, True, oTran)

        ReDim oChannelPayment(0)
        oMstChannelMstPaymentDBIO.getChannelPaymentMst(oChannelPayment, Nothing, Nothing, Nothing, Nothing, oTran)

        ' path変数に値が指定されている場合は画面からのCSVインポート
        If path = "" Then
            tempFilePath = oConf(0).sTempFilePath
            isOverWriteMode = False
        Else
            tempFilePath = path
            isOverWriteMode = True
        End If


        ' --------------------------------------------------------
        msg = "CSVインポート開始" : l.write(msg)
        ' --------------------------------------------------------

        For i = 0 To oChannel.Length - 1
            'Try
            '---トランザクション開始
            'oTran = oConn.BeginTransaction

            Select Case oChannel(i).sCMSType
                Case 1
                    If System.IO.File.Exists(tempFilePath & "\Yahoo_Order.csv") Then
                        ' --------------------------------------------------------
                        msg = "Yahooインポート開始" : l.write(msg)
                        ' --------------------------------------------------------

                        Path1 = tempFilePath & "\Yahoo_Order.csv"
                        Path2 = tempFilePath & "\Yahoo_Product.csv"

                        ''---トランザクション開始
                        'Tran = oConn.BeginTransaction
                        CSV_IMPORT(oChannel(i).sChannelCode, Path1, Path2, isOverWriteMode)
                        ' 読み取り専用属性がある場合は、読み取り専用属性を解除する
                        Dim cFileInfo As New System.IO.FileInfo(Path1)
                        If (cFileInfo.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                            cFileInfo.Attributes = System.IO.FileAttributes.Normal
                        End If
                        System.IO.File.Delete(tempFilePath & "\Yahoo_Order.csv")
                        System.IO.File.Delete(tempFilePath & "\Yahoo_Product.csv")

                        ' --------------------------------------------------------
                        msg = "Yahooインポート終了" : l.write(msg)
                        ' --------------------------------------------------------
                    End If
                Case 2
                    If System.IO.File.Exists(tempFilePath & "\Rakuten_Order.csv") Then
                        ' --------------------------------------------------------
                        msg = "楽天インポート開始" : l.write(msg)
                        ' --------------------------------------------------------

                        Path1 = tempFilePath & "\Rakuten_Order.csv"

                        ''---トランザクション開始
                        'Tran = oConn.BeginTransaction
                        CSV_IMPORT(oChannel(i).sChannelCode, Path1, Nothing, isOverWriteMode)
                        System.IO.File.Delete(tempFilePath & "\Rakuten_Order.csv")

                        ' --------------------------------------------------------
                        msg = "楽天インポート終了" : l.write(msg)
                        ' --------------------------------------------------------
                    End If
                Case 3
                    If System.IO.File.Exists(tempFilePath & "\ShopServ_Order.csv") Then
                        ' -----------------------------------------w---------------
                        msg = "ショップサーブインポート開始" : l.write(msg)
                        ' --------------------------------------------------------

                        Path1 = tempFilePath & "\ShopServ_Order.csv"

                        ''---トランザクション開始
                        'Tran = oConn.BeginTransaction
                        CSV_IMPORT(oChannel(i).sChannelCode, Path1, Nothing, isOverWriteMode)
                        '課題表No67 CSV開放処理追加
                        System.IO.File.Delete(tempFilePath & "\ShopServ_Order.csv")

                        ' --------------------------------------------------------
                        msg = "ショップサーブインポート終了" : l.write(msg)
                        ' --------------------------------------------------------
                    End If
                Case 4
                    If System.IO.File.Exists(tempFilePath & "\Amazon_Order.csv") Then
                        ' --------------------------------------------------------
                        msg = "Amazonインポート開始" : l.write(msg)
                        ' --------------------------------------------------------

                        Path1 = tempFilePath & "\Amazon_Order.csv"

                        ''---トランザクション開始
                        'Tran = oConn.BeginTransaction
                        CSV_IMPORT(oChannel(i).sChannelCode, Path1, Nothing, isOverWriteMode)
                        '課題表No67 CSV開放処理追加
                        System.IO.File.Delete(tempFilePath & "\Amazon_Order.csv")

                        ' --------------------------------------------------------
                        msg = "Amazonインポート終了" : l.write(msg)
                        ' --------------------------------------------------------
                    End If
            End Select

            '商品コード変換マスタのインポート
            oMstCnvProductCdDBIO.importCnvProductCdMst(oTran)

        Next i

        ' --------------------------------------------------------
        msg = "CSVインポート終了" : l.write(msg)
        ' --------------------------------------------------------
        'Catch ex As Exception
        '    l.write(ex)
        'Finally
        l.close() : l = Nothing
        'End Try
    End Sub

    Sub WriteLog(ByVal OrderNum As String, ByVal csvFileName As String, ByRef ex As Exception, ByVal csvColumnName As String, ByVal csvValue As String)
        Dim s As String = "@WARNING" & vbCrLf
        s &= "CSVからDBへの項目マップ失敗 (注文番号：" & OrderNum & ")：" & vbCrLf
        s &= "CSVファイル名    → " & csvFileName & vbCrLf
        s &= "エラー内容       → " & ex.ToString & vbCrLf
        s &= "CSV項目名        → " & csvColumnName & vbCrLf
        s &= "CSV項目値        → " & csvValue & vbCrLf
        s &= "ダウンロードカラムマスタの定義：" & vbCrLf
        For i As Integer = 0 To sColumn.Length - 1
            s &= "[" & i.ToString & "]" & vbCrLf
            s &= "ChannelCode  → " & sColumn(i).sChannelCode & vbCrLf
            s &= "DataClass    → " & sColumn(i).sDataClass & vbCrLf
            s &= "DBColumnNo   → " & sColumn(i).sDBColumnNo & vbCrLf
            s &= "DBColumnName → " & sColumn(i).sDBColumnName & vbCrLf
            s &= "DBColumnType → " & sColumn(i).sDBColumnType & vbCrLf
            s &= "DLColumnNo   → " & sColumn(i).sDLColumnNo & vbCrLf
            s &= "DLColumnName → " & sColumn(i).sDLColumnName & vbCrLf
            s &= "Description  → " & sColumn(i).sDescription & vbCrLf
            s &= "Derimita     → " & sColumn(i).sDerimita & vbCrLf
            s &= "SplitNo      → " & sColumn(i).sSplitNo
        Next
        l.write(s)
    End Sub


    Private Sub Mapping(ByRef ht As Hashtable, ByRef row As String(), ByVal i As Integer)

        'ReDim Preserve row(ITEM_CNT)

        Select Case sColumn(0).sDerimita
            Case "-", " ", "　"
                Dim st As String

                st = ""
                ' 分割
                Dim tkn As String() = row(i).Split(sColumn(0).sDerimita)
                Select Case tkn.Length
                    Case 1
                        ht.Add(sColumn(0).sDBColumnName, tkn(0))
                        ht.Add(sColumn(1).sDBColumnName, "")
                    Case 2
                        ht.Add(sColumn(0).sDBColumnName, tkn(0))
                        ht.Add(sColumn(1).sDBColumnName, tkn(1))
                    Case 3
                        ht.Add(sColumn(0).sDBColumnName, tkn(0))
                        ht.Add(sColumn(1).sDBColumnName, tkn(1) & " " & tkn(2))
                    Case 4
                        ht.Add(sColumn(0).sDBColumnName, tkn(0) & " " & tkn(1))
                        ht.Add(sColumn(1).sDBColumnName, tkn(2) & " " & tkn(3))
                    Case Else
                        ht.Add(sColumn(0).sDBColumnName, tkn(0) & " " & tkn(1))
                        st = ""
                        For j = 2 To tkn.Length - 1
                            st = st & " " & tkn(j)
                            If j <= tkn.Length - 1 Then ht.Add(sColumn(1).sDBColumnName, st)
                        Next

                End Select
            Case "&"
                ' 結合
                ' @TODO 文字間の間隔を取るため使用する文字は要検討
                If Not ht.ContainsKey(sColumn(0).sDBColumnName) Then
                    ht.Add(sColumn(0).sDBColumnName, row(i))
                Else
                    Dim s As String = ht(sColumn(0).sDBColumnName)
                    ht.Remove(sColumn(0).sDBColumnName) : ht.Add(sColumn(0).sDBColumnName, s & " " & row(i))
                End If
            Case "+"
                ' 合算
                If Not ht.ContainsKey(sColumn(0).sDBColumnName) Then
                    ht.Add(sColumn(0).sDBColumnName, IIf(row(i) = "", "0", row(i)))
                Else
                    ht.Remove(sColumn(0).sDBColumnName)
                    ht.Add(sColumn(0).sDBColumnName, (CLng(ht(sColumn(0).sDBColumnName)) + CLng(IIf(row(i) = "", "0", row(i)))).ToString)
                End If
            Case "U"
                ' 書式(大文字へ)
                ht.Add(sColumn(0).sDBColumnName, UCase(row(i)))
            Case "INTAX"
                '税込み→税抜きへ
                ht.Add(sColumn(0).sDBColumnName, oTool.AfterToBeforeTax(CLng(IIf(row(i) = "", "0", row(i))), oConf(0).sTax, oConf(0).sFracProc).ToString)
            Case "DIS"
                'プラス→マイナスへ
                ht.Add(sColumn(0).sDBColumnName, oTool.AfterToBeforeTax(CLng(IIf(row(i) = "", "0", row(i) * -1)), oConf(0).sTax, oConf(0).sFracProc).ToString)
            Case "1"
                ' 特殊パターン-1(Rakuten：文字列分割)
                Dim r As Regex
                Dim s As String
                For j = 0 To sColumn.Length - 1
                    Select Case sColumn(j).sDBColumnName
                        Case "配達希望日"
                            r = New Regex("\[配送日時指定:\].*?([0-9]{4}-[0-9]{2}-[0-9]{2}\([月火水木金土日]\))", RegexOptions.Singleline)
                            s = IIf(r.Match(row(i)).Success, r.Match(row(i)).Groups(1).Value(), "")
                            ht.Add(sColumn(j).sDBColumnName, s)
                        Case "配達希望時間"
                            r = New Regex("\[配送日時指定:\].*?((午前中|[0-9]{2}:[0-9]{2}～[0-9]{2}:[0-9]{2}))", RegexOptions.Singleline)
                            s = IIf(r.Match(row(i)).Success, r.Match(row(i)).Groups(1).Value(), "")
                            ht.Add(sColumn(j).sDBColumnName, s)
                        Case "配達希望メモ"
                            r = New Regex("\[備考欄:\](.*)", RegexOptions.Singleline)
                            s = IIf(r.Match(row(i)).Success, Regex.Replace(r.Match(row(i)).Groups(1).Value(), vbCrLf, ""), "")
                            ht.Add(sColumn(j).sDBColumnName, s)
                    End Select
                Next
            Case "2"
                ' 特殊パターン-2(Rakuten：文字置換)
                Dim s As String = row(i)
                s = Regex.Replace(s, "生", "")
                s = Regex.Replace(s, "[年月日]", "/")
                s = Regex.Replace(s, "\・", "-")
                ht.Add(sColumn(0).sDBColumnName, s)
            Case "5"
                ' 特殊パターン-5(SHOPSERV：モバイルフラグ)
                Select Case row(i)
                    Case "パソコン"
                        ht.Add(sColumn(0).sDBColumnName, "0")
                    Case Else
                        '@TODO(パターン洗い出しが必要)
                        ht.Add(sColumn(0).sDBColumnName, "9")
                End Select
            Case "6"
                ' 特殊パターン-6(かな→カナ へ変換)
                ht.Add(sColumn(0).sDBColumnName, StrConv(row(i), VbStrConv.Katakana))
            Case "7"
                ' 特殊パターン-7(SHOPSERV：ギフト包装希望)
                '@TODO
                ht.Add(sColumn(0).sDBColumnName, IIf(row(i) = "", "0", "1"))
            Case "8"
                ' 特殊パターン-8(SHOPSERV：商品名、チャネルオプション)
                Dim tkn As String() = row(i).Split("/")
                If tkn.Length = 1 Then
                    ' 0:商品名、1:チャネルオプション
                    ht.Add(sColumn(0).sDBColumnName, tkn(0))
                    ht.Add(sColumn(1).sDBColumnName, "")
                Else
                    ' 0:商品名、1:チャネルオプション
                    ht.Add(sColumn(0).sDBColumnName, tkn(0))
                    ht.Add(sColumn(1).sDBColumnName, String.Join("/", tkn.Skip(1).Take(tkn.Length - 1).ToArray()))
                End If
            Case "9"
                ' 特殊パターン-9(Yahoo：郵便番号1、郵便番号2)
                Dim tkn As String() = row(i).Split("-")
                If tkn.Length = 1 Then
                    ' 0:上3桁-郵便番号、1:下4桁-郵便番号
                    ht.Add(sColumn(0).sDBColumnName, row(i).Substring(0, 3))
                    ht.Add(sColumn(1).sDBColumnName, row(i).Substring(3, row(i).Length - 3))
                Else
                    ' 0:上3桁-郵便番号、1:下4桁-郵便番号
                    ht.Add(sColumn(0).sDBColumnName, tkn(0))
                    ht.Add(sColumn(1).sDBColumnName, String.Join("", tkn.Skip(1).Take(tkn.Length - 1).ToArray()))
                End If
            Case "10"
                ' 特殊パターン-10(Yahoo：チャネルオプション)
                If Not ht.ContainsKey(sColumn(0).sDBColumnName) Then
                    ' オプション名称
                    Dim s As String = row(i)
                    If s <> "" Then
                        s = Regex.Replace(s, "[:：]+/", "/")
                        s = Regex.Replace(s, "[:：]$", "")
                        s = Regex.Replace(s, "[:：]", "|")
                        s = Regex.Replace(s, "=", "-")
                    End If
                    ht.Add(sColumn(0).sDBColumnName, s)
                Else
                    ' オプション値
                    Dim s As String = row(i)
                    If s <> "" Then
                        s = Regex.Replace(s, "[:：]", "|")
                        s = Regex.Replace(s, "=", "-")
                        Dim optNames As String() = Split(ht(sColumn(0).sDBColumnName), "/")
                        Dim optValues As String() = Split(s, "/")
                        Dim buff As String = ""
                        ' 配列の添字超過エラーを回避するためオプション値の配列サイズを拡張
                        If optNames.Length > optValues.Length Then
                            ReDim Preserve optValues(optNames.Length - 1)
                        End If
                        ' オプション名称とオプション値を連結
                        For j = 0 To optNames.Length - 1
                            ' 名入の場合はオプション値を"*" へ変換
                            If Regex.IsMatch(optNames(j), "^[0-9]行目") Then optValues(j) = "*"
                            If j = 0 Then
                                buff &= (optNames(0) & "=" & IIf(optValues(0) Is Nothing, "", optValues(0)))
                            Else
                                buff &= (":" & optNames(j) & "=" & IIf(optValues(j) Is Nothing, "", optValues(j)))
                            End If
                        Next
                        ht.Remove(sColumn(0).sDBColumnName) : ht.Add(sColumn(0).sDBColumnName, buff)
                    End If
                End If
            Case "11"
                ' 特殊パターン-11(Rakuten：電話番号)
                ' 電話番号の区切文字が間違って含まれる場合があるため削除
                Dim s As String = Regex.Replace(row(i), "-", "")
                If s <> "" Then
                    If Not ht.ContainsKey(sColumn(0).sDBColumnName) Then
                        ht.Add(sColumn(0).sDBColumnName, s)
                    Else
                        Dim s2 As String = ht(sColumn(0).sDBColumnName)
                        ht.Remove(sColumn(0).sDBColumnName)
                        ht.Add(sColumn(0).sDBColumnName, s2 & "-" & s)
                    End If
                End If
            Case "12"
                ' 特殊パターン-12(Rakuten：チャネルオプション)
                Dim s As String = row(i)
                If s <> "" Then
                    s = Regex.Replace(s, "=", "-")
                    s = Regex.Replace(s, "[:：]*:", "=")
                    s = Regex.Replace(s, "[\r\n]+", ":")
                End If
                ht.Add(sColumn(0).sDBColumnName, s)
            Case "13"
                ' 特殊パターン-13(Rakuten：受注日)
                Dim s As String = row(i)
                If s <> "" Then
                    s = Regex.Replace(s, "-", "/")
                End If
                ht.Add(sColumn(0).sDBColumnName, s)
            Case "14"
                ' 特殊パターン-14(Amazon：受注日(YYYY-MM-DDTHH:MM:SS+00:00)→YYYY/MM/DD
                Dim s As String = row(i)
                Dim str() As String

                ReDim str(0)

                If s <> "" Then
                    str = s.Split("T")
                    s = Regex.Replace(str(0), "-", "/")
                    's = s.Substring(12, 8)
                End If
                ht.Add(sColumn(0).sDBColumnName, s)
                ht.Add(sColumn(1).sDBColumnName, str(1).Substring(0, 8))

            Case "15"
                ' 特殊パターン-14(Amazon：受注日(YYYY-MM-DDTHH:MM:SS+00:00)→HH:MM:SS
                Dim s As String = row(i)
                Dim str() As String

                If s <> "" Then
                    str = s.Split("T+")
                    s = Regex.Replace(str(1), "-", "/")
                    s = str(1).Substring(0, 8)
                End If
                ht.Add(sColumn(0).sDBColumnName, s)
            Case "99"
                'マッピング対象外
            Case Else
                ' 無加工(CSV項目を複数のDB項目へマッピングする場合を考慮してループ処理とする)
                For j = 0 To sColumn.Length - 1
                    ht.Add(sColumn(j).sDBColumnName, row(i))
                Next
        End Select



        ''TODO:テスト
        'Catch ex As Exception
        '    MsgBox("エラー")
        'End Try



    End Sub

    Private Sub setChannelPaymentCode(ByRef ht As Hashtable)
        Dim result As Integer = -9
        Dim channelCode As Integer = CInt(ht("チャネルコード"))
        Dim paymentName As String = ht("チャネル支払コード")

        For Each o As cStructureLib.sChannelPayment In oChannelPayment
            If (o.sChannelCode = channelCode) And (o.sChannelPaymentName = paymentName) Then
                result = o.sChannelPaymentCode
                Exit For
            End If
        Next
        ht.Remove("チャネル支払コード")
        ht.Add("チャネル支払コード", result.ToString)
    End Sub

    ''Private Function getTax(ByVal amout As Long) As Long
    ''    Dim d As Double = amout * (oConf(0).sTax / (100 + oConf(0).sTax))
    ''    Dim tax As Long
    ''    Select Case oConf(0).sFracProc
    ''        Case 0
    ''            tax = oTool.ToHalfAdjust(d, 0)
    ''        Case 1
    ''            tax = oTool.ToRoundDown(d, 0)
    ''        Case 2
    ''            tax = oTool.ToRoundUp(d, 0)
    ''    End Select
    ''    Return tax
    ''End Function

    'Private Function getUnitPrice(ByVal amout As Long, ByVal qty As Integer) As Long
    '    Dim d As Double = amout / qty
    '    Dim unitPrice As Long
    '    Select Case oConf(0).sFracProc
    '        Case 0
    '            unitPrice = oTool.ToHalfAdjust(d, 0)
    '        Case 1
    '            unitPrice = oTool.ToRoundDown(d, 0)
    '        Case 2
    '            unitPrice = oTool.ToRoundUp(d, 0)
    '    End Select
    '    Return unitPrice
    'End Function



    ' 2016.8.30 既存不具合対応 K.Oikawa Start
    'Private Sub setPricesAndTaxForHeader(ByRef ht As Hashtable, ByRef pCMSType As Integer)

    '    Select Case pCMSType
    '        'Case 1  'Yahoo
    '        '    YahooHeaderPriceInfoSet(ht)
    '        Case 2  '楽天
    '            RakutenHeaderPriceInfoSet(ht)
    '        Case 3  'e-Shop
    '            eShopHeaderPriceInfoSet(ht)
    '        Case 4  'Amazon
    '            AmazonHeaderPriceInfoSet(ht)
    '    End Select
    'End Sub
    Private Sub setPricesAndTaxForHeader(ByRef ht As Hashtable, ByRef row() As String, ByVal UNIT_PRICE_COL As Integer, ByRef pCMSType As Integer)

        Select Case pCMSType
            'Case 1  'Yahoo
            '    YahooHeaderPriceInfoSet(ht)
            Case 2  '楽天
                RakutenHeaderPriceInfoSet(ht, row, UNIT_PRICE_COL)
            Case 3  'e-Shop
                eShopHeaderPriceInfoSet(ht)
            Case 4  'Amazon
                AmazonHeaderPriceInfoSet(ht)
        End Select
    End Sub
    ' 2016.8.30 既存不具合対応 K.Oikawa End


    Private Sub YahooHeaderPriceInfoSet(ByRef ht As Hashtable)

        If ht("受注消費税額") = "" Then '税込みモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", _
                                       oTool.AfterToBeforeTax(CLng(ht("受注商品税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額")).ToString
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", (oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注税抜金額") = oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
            Else
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

        Else '税抜きモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString))
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税抜金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString)
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
            Else
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額"))
            End If

        End If


        Dim charge1 As Long = 0
        If ht("送料") = "" Then ht("送料") = "0"
        If ht.ContainsKey("送料") Then charge1 = CLng(oTool.AfterToBeforeTax(ht("送料"), oConf(0).sTax, oConf(0).sFracProc))
        ht.Remove("送料") : ht.Add("送料", charge1.ToString)

        Dim charge2 As Long = 0
        If ht("手数料") = "" Then ht("手数料") = "0"
        If ht.ContainsKey("手数料") Then charge2 = CLng(oTool.AfterToBeforeTax(ht("手数料"), oConf(0).sTax, oConf(0).sFracProc))
        ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge3 As Long = 0
        If ht("値引き") = "" Then ht("値引き") = "0"
        If ht.ContainsKey("値引き") Then charge3 = CLng(oTool.AfterToBeforeTax(ht("値引き"), oConf(0).sTax, oConf(0).sFracProc))
        charge3 = charge3 * -1 : ht.Remove("値引き") : ht.Add("値引き", charge3.ToString)

        Dim charge4 As Long = 0
        If ht("ポイント値引き") = "" Then ht("ポイント値引き") = "0"
        If ht.ContainsKey("ポイント値引き") Then charge4 = CLng(oTool.AfterToBeforeTax(ht("ポイント値引き"), oConf(0).sTax, oConf(0).sFracProc))
        charge4 = charge4 * -1 : ht.Remove("ポイント値引き") : ht.Add("ポイント値引き", charge4.ToString)

        Dim charge5 As Long = 0
        If ht("ギフト梱包料金") = "" Then ht("ギフト梱包料金") = "0"
        If ht.ContainsKey("ギフト梱包料金") Then charge5 = CLng(oTool.AfterToBeforeTax(ht("ギフト梱包料金"), oConf(0).sTax, oConf(0).sFracProc))
        charge2 = charge2 + (charge5 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge6 As Long = 0
        If ht("楽天バンク決済手数料") = "" Then ht("楽天バンク決済手数料") = "0"
        If ht.ContainsKey("楽天バンク決済手数料") Then charge6 = CLng(oTool.AfterToBeforeTax(ht("楽天バンク決済手数料"), oConf(0).sTax, oConf(0).sFracProc))
        charge2 = charge2 + (charge6 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    End Sub





    ' 2016.8.30 既存不具合対応 K.Oikawa Start
    'Private Sub RakutenHeaderPriceInfoSet(ByRef ht As Hashtable)

    '    If ht("受注消費税額") = "" Then '税込みモードの場合

    '        '受注商品税抜金額
    '        If Not ht.ContainsKey("受注商品税抜金額") Then
    '            ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", _
    '                                   oTool.AfterToBeforeTax(CLng(ht("受注商品税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
    '        Else
    '            ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
    '        End If

    '    Else '税抜きモードの場合

    '        '受注商品税抜金額
    '        If Not ht.ContainsKey("受注商品税抜金額") Then
    '            ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString))
    '        Else
    '            ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
    '        End If

    '    End If

    '    Dim charge1 As Long = 0
    '    If ht("送料") = "" Then ht("送料") = "0"
    '    If ht.ContainsKey("送料") Then charge1 = CLng(oTool.AfterToBeforeTax(ht("送料"), oConf(0).sTax, oConf(0).sFracProc))
    '    ht.Remove("送料") : ht.Add("送料", charge1.ToString)

    '    Dim charge2 As Long = 0
    '    If ht("手数料") = "" Then ht("手数料") = "0"
    '    If ht.ContainsKey("手数料") Then charge2 = CLng(oTool.AfterToBeforeTax(ht("手数料"), oConf(0).sTax, oConf(0).sFracProc))
    '    ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    '    Dim charge3 As Long = 0
    '    If ht("値引き") = "" Then ht("値引き") = "0"
    '    If ht.ContainsKey("値引き") Then charge3 = CLng(oTool.AfterToBeforeTax(ht("値引き"), oConf(0).sTax, oConf(0).sFracProc))
    '    charge3 = charge3 * -1 : ht.Remove("値引き") : ht.Add("値引き", charge3.ToString)

    '    Dim charge4 As Long = 0
    '    If ht("ポイント値引き") = "" Then ht("ポイント値引き") = "0"
    '    If ht.ContainsKey("ポイント値引き") Then charge4 = CLng(oTool.AfterToBeforeTax(ht("ポイント値引き"), oConf(0).sTax, oConf(0).sFracProc))
    '    charge4 = charge4 * -1 : ht.Remove("ポイント値引き") : ht.Add("ポイント値引き", charge4.ToString)

    '    Dim charge5 As Long = 0
    '    If ht("ギフト梱包料金") = "" Then ht("ギフト梱包料金") = "0"
    '    If ht.ContainsKey("ギフト梱包料金") Then charge5 = CLng(oTool.AfterToBeforeTax(ht("ギフト梱包料金"), oConf(0).sTax, oConf(0).sFracProc))
    '    charge2 = charge2 + (charge5 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    '    Dim charge6 As Long = 0
    '    If ht("楽天バンク決済手数料") = "" Then ht("楽天バンク決済手数料") = "0"
    '    If ht.ContainsKey("楽天バンク決済手数料") Then charge6 = CLng(oTool.AfterToBeforeTax(ht("楽天バンク決済手数料"), oConf(0).sTax, oConf(0).sFracProc))
    '    charge2 = charge2 + (charge6 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    '    '受注税抜金額
    '    If Not ht.ContainsKey("受注税抜金額") Then
    '        ht.Add("受注税抜金額", IIf(ht("受注税込金額") = "", "0", _
    '                             CLng(ht("受注商品税抜金額")) + CLng(ht("送料")) + CLng(ht("手数料")) + CLng(ht("値引き")) + CLng(ht("ポイント値引き"))).ToString)
    '    Else
    '        ht("受注税抜金額") = IIf(ht("受注税込金額") = "", "0", _
    '                           CLng(ht("受注商品税抜金額")) + CLng(ht("送料")) + CLng(ht("手数料")) + CLng(ht("値引き")) + CLng(ht("ポイント値引き"))).ToString
    '    End If

    '    ' 受注消費税額
    '    If Not ht.ContainsKey("受注消費税額") Then
    '        ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
    '    Else
    '        ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
    '    End If

    'End Sub
    Private Sub RakutenHeaderPriceInfoSet(ByRef ht As Hashtable, ByVal row() As String, ByVal UNIT_PRICE_COL As Integer)

        If ht("受注消費税額") = "" Then '税込みモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(row(UNIT_PRICE_COL) = "", "0", _
                                       oTool.AfterToBeforeTax(CLng(row(UNIT_PRICE_COL)), oConf(0).sTax, 1)).ToString)
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

        Else '税抜きモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(row(UNIT_PRICE_COL) = "", "0", row(UNIT_PRICE_COL)))
            Else
                ht("受注商品税抜金額") = IIf(row(UNIT_PRICE_COL) = "", "0", row(UNIT_PRICE_COL).ToString)
            End If

        End If

        Dim charge1 As Long = 0
        If ht("送料") = "" Then ht("送料") = "0"
        If ht.ContainsKey("送料") Then charge1 = CLng(oTool.AfterToBeforeTax(ht("送料"), oConf(0).sTax, 1))
        ht.Remove("送料") : ht.Add("送料", charge1.ToString)

        Dim charge2 As Long = 0
        If ht("手数料") = "" Then ht("手数料") = "0"
        If ht.ContainsKey("手数料") Then charge2 = CLng(oTool.AfterToBeforeTax(ht("手数料"), oConf(0).sTax, 1))
        ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge3 As Long = 0
        If ht("値引き") = "" Then ht("値引き") = "0"
        If ht.ContainsKey("値引き") Then charge3 = CLng(oTool.AfterToBeforeTax(ht("値引き"), oConf(0).sTax, 1))
        charge3 = charge3 * -1 : ht.Remove("値引き") : ht.Add("値引き", charge3.ToString)

        Dim charge4 As Long = 0
        If ht("ポイント値引き") = "" Then ht("ポイント値引き") = "0"
        If ht.ContainsKey("ポイント値引き") Then charge4 = CLng(oTool.AfterToBeforeTax(ht("ポイント値引き"), oConf(0).sTax, 1))
        charge4 = charge4 * -1 : ht.Remove("ポイント値引き") : ht.Add("ポイント値引き", charge4.ToString)

        Dim charge5 As Long = 0
        If ht("ギフト梱包料金") = "" Then ht("ギフト梱包料金") = "0"
        If ht.ContainsKey("ギフト梱包料金") Then charge5 = CLng(oTool.AfterToBeforeTax(ht("ギフト梱包料金"), oConf(0).sTax, 1))
        charge2 = charge2 + (charge5 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge6 As Long = 0
        If ht("楽天バンク決済手数料") = "" Then ht("楽天バンク決済手数料") = "0"
        If ht.ContainsKey("楽天バンク決済手数料") Then charge6 = CLng(oTool.AfterToBeforeTax(ht("楽天バンク決済手数料"), oConf(0).sTax, 1))
        charge2 = charge2 + (charge6 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        '受注税抜金額
        If Not ht.ContainsKey("受注税抜金額") Then
            ht.Add("受注税抜金額", IIf(ht("受注税込金額") = "", "0", _
                                 CLng(ht("受注商品税抜金額")) + CLng(ht("送料")) + CLng(ht("手数料")) + CLng(ht("値引き")) + CLng(ht("ポイント値引き"))).ToString)
        Else
            ht("受注税抜金額") = IIf(ht("受注税込金額") = "", "0", _
                               CLng(ht("受注商品税抜金額")) + CLng(ht("送料")) + CLng(ht("手数料")) + CLng(ht("値引き")) + CLng(ht("ポイント値引き"))).ToString
        End If

        ' 受注消費税額
        If Not ht.ContainsKey("受注消費税額") Then
            ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
        Else
            ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
        End If

    End Sub
    ' 2016.8.30 既存不具合対応 K.Oikawa End





    Private Sub eShopHeaderPriceInfoSet(ByRef ht As Hashtable)

        If ht("受注消費税額") = "" Then '税込みモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", _
                                       oTool.AfterToBeforeTax(CLng(ht("受注商品税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額")).ToString
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", (oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注税抜金額") = oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
            Else
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

        Else '税抜きモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString))
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税抜金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString)
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
            Else
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額"))
            End If

        End If


        Dim charge1 As Long = 0
        If ht("送料") = "" Then ht("送料") = "0"
        If ht.ContainsKey("送料") Then charge1 = CLng(oTool.AfterToBeforeTax(ht("送料"), oConf(0).sTax, oConf(0).sFracProc))
        ht.Remove("送料") : ht.Add("送料", charge1.ToString)

        Dim charge2 As Long = 0
        If ht("手数料") = "" Then ht("手数料") = "0"
        If ht.ContainsKey("手数料") Then charge2 = CLng(oTool.AfterToBeforeTax(ht("手数料"), oConf(0).sTax, oConf(0).sFracProc))
        ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge3 As Long = 0
        If ht("値引き") = "" Then ht("値引き") = "0"
        If ht.ContainsKey("値引き") Then charge3 = CLng(oTool.AfterToBeforeTax(ht("値引き"), oConf(0).sTax, oConf(0).sFracProc))
        charge3 = charge3 * -1 : ht.Remove("値引き") : ht.Add("値引き", charge3.ToString)

        Dim charge4 As Long = 0
        If ht("ポイント値引き") = "" Then ht("ポイント値引き") = "0"
        If ht.ContainsKey("ポイント値引き") Then charge4 = CLng(oTool.AfterToBeforeTax(ht("ポイント値引き"), oConf(0).sTax, oConf(0).sFracProc))
        charge4 = charge4 * -1 : ht.Remove("ポイント値引き") : ht.Add("ポイント値引き", charge4.ToString)

        Dim charge5 As Long = 0
        If ht("ギフト梱包料金") = "" Then ht("ギフト梱包料金") = "0"
        If ht.ContainsKey("ギフト梱包料金") Then charge5 = CLng(oTool.AfterToBeforeTax(ht("ギフト梱包料金"), oConf(0).sTax, oConf(0).sFracProc))
        charge2 = charge2 + (charge5 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        Dim charge6 As Long = 0
        If ht("楽天バンク決済手数料") = "" Then ht("楽天バンク決済手数料") = "0"
        If ht.ContainsKey("楽天バンク決済手数料") Then charge6 = CLng(oTool.AfterToBeforeTax(ht("楽天バンク決済手数料"), oConf(0).sTax, oConf(0).sFracProc))
        charge2 = charge2 + (charge6 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    End Sub

    '2016.05.26 K.Oikawa Amazonの数量は明細の更新時に都度更新するよう修正するため、この機能は使用しない
    Private Sub AmazonHeaderPriceInfoSet(ByRef ht As Hashtable)

        If ht("受注消費税額") = "" Then '税込みモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", _
                                       oTool.AfterToBeforeTax(CLng(ht("受注商品税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額")).ToString
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", (oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            Else
                ht("受注税抜金額") = oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)

                'Else
                '    ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

        Else '税抜きモードの場合

            '受注商品税抜金額
            If Not ht.ContainsKey("受注商品税抜金額") Then
                ht.Add("受注商品税抜金額", IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString))
            Else
                ht("受注商品税抜金額") = IIf(ht("受注商品税抜金額") = "", "0", ht("受注商品税抜金額").ToString)
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税抜金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString)
            End If

            ' 受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString)
            Else
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                ht.Add("受注税込金額", IIf(ht("受注税込金額") = "", "0", ht("受注税込金額").ToString))
            Else
                ht("受注税込金額") = IIf(ht("受注税込金額") = "", "0", ht("受注税込金額"))
            End If

        End If

        'この辺はコピペしたのがそのまま残っている　Amazonでは使用しない
        'Dim charge1 As Long = 0
        'If ht("送料") = "" Then ht("送料") = "0"
        'If ht.ContainsKey("送料") Then charge1 = CLng(oTool.AfterToBeforeTax(ht("送料"), oConf(0).sTax, oConf(0).sFracProc))
        'ht.Remove("送料") : ht.Add("送料", charge1.ToString)

        'Dim charge2 As Long = 0
        'If ht("手数料") = "" Then ht("手数料") = "0"
        'If ht.ContainsKey("手数料") Then charge2 = CLng(oTool.AfterToBeforeTax(ht("手数料"), oConf(0).sTax, oConf(0).sFracProc))
        'ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

        'Dim charge3 As Long = 0
        'If ht("値引き") = "" Then ht("値引き") = "0"
        'If ht.ContainsKey("値引き") Then charge3 = CLng(oTool.AfterToBeforeTax(ht("値引き"), oConf(0).sTax, oConf(0).sFracProc))
        'charge3 = charge3 * -1 : ht.Remove("値引き") : ht.Add("値引き", charge3.ToString)

        'Dim charge4 As Long = 0
        'If ht("ポイント値引き") = "" Then ht("ポイント値引き") = "0"
        'If ht.ContainsKey("ポイント値引き") Then charge4 = CLng(oTool.AfterToBeforeTax(ht("ポイント値引き"), oConf(0).sTax, oConf(0).sFracProc))
        'charge4 = charge4 * -1 : ht.Remove("ポイント値引き") : ht.Add("ポイント値引き", charge4.ToString)

        'Dim charge5 As Long = 0
        'If ht("ギフト梱包料金") = "" Then ht("ギフト梱包料金") = "0"
        'If ht.ContainsKey("ギフト梱包料金") Then charge5 = CLng(oTool.AfterToBeforeTax(ht("ギフト梱包料金"), oConf(0).sTax, oConf(0).sFracProc))
        'charge2 = charge2 + (charge5 * -1) : ht.Remove("手数料") : ht.Add("手数料", charge2.ToString)

    End Sub

    Private Function setPricesAndTaxForLine(ByRef ht As Hashtable, ByRef pChannelCode As Integer, ByRef pCMSType As Integer) As Boolean
        Dim ret As Boolean

        ret = True
        Select Case pCMSType
            Case 1  'Yahoo
                YahooPriceInfoSet(ht)
            Case 2  '楽天
                RakutenPriceInfoSet(ht, pChannelCode)
            Case 3  'e-Shop
                eShopPriceInfoSet(ht)
            Case 4  'Amazon
                ret = AmazonPriceInfoSet(ht)
        End Select

        setPricesAndTaxForLine = ret

    End Function
    Private Sub YahooPriceInfoSet(ByRef ht As Hashtable)
        ' 受注税込金額
        If Not ht.ContainsKey("受注税込金額") Then _
            ht.Add("受注税込金額", (CLng(ht("受注商品単価")) * CInt(ht("受注数量"))).ToString)
        Dim total As Long = CLng(ht("受注税込金額"))

        ' 受注消費税額
        If IsNothing(ht("受注消費税額")) = True Then
            ht.Add("受注消費税額", oTool.AfterToTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc))
        End If

        ' 定価
        If IsNothing(ht("定価")) = True Then
            ht.Add("定価", "0")
        End If

        ' 仕入単価
        If IsNothing(ht("仕入単価")) = True Then
            ht.Add("仕入単価", "0")
        End If

        ' 受注商品単価
        If ht.ContainsKey("受注商品単価") Then ht.Remove("受注商品単価")
        If IsNothing(ht("受注商品単価")) = True Then
            ht.Add("受注商品単価", ((CLng(ht("受注税込金額")) - CLng(ht("受注消費税額"))) / CInt(ht("受注数量"))).ToString)
        End If

        ' 受注税抜金額
        If IsNothing(ht("受注税抜金額")) = True Then
            ht.Add("受注税抜金額", (CLng(ht("受注税込金額")) - CLng(ht("受注消費税額"))).ToString)
        End If

    End Sub
    Private Sub RakutenPriceInfoSet(ByRef ht As Hashtable, ByRef pChannelCode As Integer)
        Dim RecordCount As Integer

        ' 定価
        If IsNothing(ht("定価")) = True Then
            ht.Add("定価", "0")
        End If

        ' 仕入単価
        If IsNothing(ht("仕入単価")) = True Then
            ht.Add("仕入単価", "0")
        End If

        '2016.05.19 K.Oikawa s
        'チャネル商品コードがなかった場合の処理
        Dim ProductCode As String
        If IsNothing(ht("チャネル商品コード")) Then
            ProductCode = Nothing
        Else
            ProductCode = ht("チャネル商品コード").ToString
        End If

        '2016.05.19 K.Oikawa e

        '商品マスタの定価を取得
        ReDim oProduct(1)
        'RecordCount = oMstProductDBIO.getNetProduct(oProduct, Nothing, ht("チャネル商品コード").ToString, pChannelCode, oTran)
        RecordCount = oMstProductDBIO.getNetProduct(oProduct, Nothing, ProductCode, pChannelCode, oTran)

        If RecordCount < 1 Then
            oProduct(0).sSalePrice = 0
        End If

        '--------------------------------------------------------------------------------
        '楽天の場合税抜き表記になっている商品と税込み表記の商品が混在した場合、
        '先頭レコードに税抜き表記の商品分の消費税がまとめて付与されてくるため
        '当該レコードの単価が税込みか税抜きかの判断のため「定価（税抜き）より
        '販売単価が高い場合は税抜きモードと判定
        '--------------------------------------------------------------------------------
        If (CLng(ht("受注商品単価")) > oProduct(0).sSalePrice + CInt(PRICE_MARG)) Then
            '-------------- 税込みモードの場合 -----------------

            ''受注商品単価
            'ht("受注商品単価") = oTool.AfterToBeforeTax(CLng(ht("受注商品単価")), oConf(0).sTax, oConf(0).sFracProc).ToString
            '受注商品単価
            ht("受注商品単価") = oTool.AfterToBeforeTax(CLng(ht("受注商品単価")), oConf(0).sTax, 1).ToString

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", (CLng(ht("受注商品単価")) * CInt(ht("受注数量"))).ToString)
            Else
                ht("受注税抜金額") = (CLng(ht("受注商品単価")) * CInt(ht("受注数量"))).ToString
            End If

            ' 2016.8.25 既存不具合対応 K.Minagawa Start
            '' 受注税込金額
            'ht.Add("受注税込金額", oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc).ToString)
            ' 受注税込金額
            ht.Add("受注税込金額", oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, 1).ToString)
            ' 2016.8.25 既存不具合対応 K.Minagawa End

            '受注消費税額
            If Not ht.ContainsKey("受注消費税額") Then
                ht.Add("受注消費税額", (CLng(ht("受注税込金額")) - CInt(ht("受注税抜金額"))).ToString)
            Else
                '受注税込金額に税抜金額がセットされる場合に対処
                ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString
            End If

        Else
            '-------------- 税抜きモードの場合 -----------------

            '受注税込金額
            If Not ht.ContainsKey("受注税込金額") Then
                'ht.Add("受注税込金額", (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
                ht.Add("受注税込金額", ((oTool.BeforeToAfterTax(CLng(ht("受注商品単価")), oConf(0).sTax, 1)).ToString * CInt(ht("受注数量"))).ToString)
            Else
                'ht("受注税込金額") = (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString
                ht("受注税込金額") = ((oTool.BeforeToAfterTax(CLng(ht("受注商品単価")), oConf(0).sTax, 1)).ToString * CInt(ht("受注数量"))).ToString
            End If

            '受注税抜金額
            If Not ht.ContainsKey("受注税抜金額") Then
                ht.Add("受注税抜金額", (CLng(ht("受注商品単価")) * CInt(ht("受注数量"))).ToString)
            Else
                ht("受注税抜金額") = (CLng(ht("受注商品単価")) * CInt(ht("受注数量"))).ToString
            End If

            '受注消費税額
            ht("受注消費税額") = (CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))).ToString

            ''受注税込金額
            'If Not ht.ContainsKey("受注税込金額") Then
            '    'ht.Add("受注税込金額", (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString)
            '    ht.Add("受注税込金額", (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, 1)).ToString)
            'Else
            '    'ht("受注税込金額") = (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc)).ToString
            '    ht("受注税込金額") = (oTool.BeforeToAfterTax(CLng(ht("受注税抜金額")), oConf(0).sTax, 1)).ToString
            'End If

        End If

    End Sub
    Private Sub eShopPriceInfoSet(ByRef ht As Hashtable)

    End Sub
    Private Function AmazonPriceInfoSet(ByRef ht As Hashtable) As Boolean
        '---------------------------------------------------------------------
        'プロモーション
        'Amazonにおいては、以下のマッピング先をプロモーション情報として代用
        '登録日　　　＝　購入プロモーションID
        '登録時間　　＝　購入プロモーション金額
        '最終更新日　＝　配送プロモーションID
        '最終更新時間＝　配送プロモーション金額
        '---------------------------------------------------------------------
        Dim Mode As String
        Dim ret As Boolean
        Dim i As Long
        Dim pc As Integer
        Dim scnt As Integer
        Dim maxpc As Integer

        Mode = ""
        ret = False

        '***************************
        '   パラメータの配置設定
        '***************************

        pc = 0

        '2016.05.26 K.Oikawa s
        '仮の置き場を使用していないカラムに変更
        '「登録時間」→「オプション名称」
        '「最終更新時間」→「オプション値」

        ''購入プロモーションIDがセットされている場合
        'If ht("登録時間") <> "0" And ht("登録時間") <> "" Then
        '    maxpc = 1
        '    pc = pc Or maxpc
        '    ret = True
        'End If

        ''配送プロモーションIDがセットされている場合
        'If ht("最終更新時間") <> "0" And ht("最終更新時間") <> "" Then
        '    maxpc = 2
        '    pc = pc Or maxpc
        '    ret = True
        'End If

        '購入プロモーションIDがセットされている場合
        If ht("オプション名称") <> "0" And ht("オプション名称") <> "" Then
            maxpc = 1
            pc = pc Or maxpc
            ret = True
        End If

        '配送プロモーションIDがセットされている場合
        If ht("オプション値") <> "0" And ht("オプション値") <> "" Then
            maxpc = 2
            pc = pc Or maxpc
            ret = True
        End If

        '明細に「手数料」のカラムが存在しないため、仮の置き場として「定価」カラムを使用
        '手数料の場合
        If ht("定価") <> "" Then
            maxpc = 4
            pc = pc Or maxpc
            ret = True
        End If

        '明細に「送料」のカラムが存在しないため、仮の置き場として「仕入単価」カラムを使用
        '送料の場合
        If ht("仕入単価") <> "" Then
            maxpc = 8
            pc = pc Or maxpc
            ret = True
        End If

        '明細に「ギフト梱包料金」のカラムが存在しないため、仮の置き場として「受注税抜金額」カラムを使用
        '送料の場合
        If ht("受注税抜金額") <> "" Then
            maxpc = 16
            pc = pc Or maxpc
            ret = True
        End If
        '2016.05.26 K.Oikawa e

        If ret = True Then
            'プロモーションレコードの場合、数量=1をセット
            If Not ht.ContainsKey("受注数量") Then
                ht.Add("受注数量", "1")
            Else
                If ht("受注数量") = "" Then
                    ht("受注数量") = "1"
                End If
            End If

            'パラメータ指定がある場合
            If maxpc And pc > 0 Then
                i = 1
                scnt = 0
                While i <= maxpc
                    Select Case i And pc
                        Case 1  '購入プロモーション
                            '購入プロモーションIDがセットされている場合

                            '2016.05.26 K.Oikawa s
                            '仮の置き場を使用していないカラムに変更
                            '「登録時間」→「オプション名称」
                            'ヘッダーレコードの値引きを更新
                            'oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "値引き", oTool.AfterToBeforeTax(CLng(ht("登録時間")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            ''受注税込金額に購入プロモーション金額をセット
                            'ht("受注税込金額") = ht("登録時間")
                            ''ht("チャネル商品コード") = "ZZZZZ-01"

                            'If ht.ContainsKey("登録日") Then
                            '    ht.Remove("登録日")
                            '    ht.Remove("登録時間")
                            'End If

                            oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "値引き", oTool.AfterToBeforeTax(CLng(ht("オプション名称")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            '受注税込金額に購入プロモーション金額をセット
                            If ht("受注税込金額") <> "" Then
                                ht("受注税込金額") = (CLng(ht("受注税込金額")) + CLng(ht("オプション名称"))).ToString
                            Else
                                ht("受注税込金額") = ht("オプション名称")
                            End If

                            If ht.ContainsKey("オプション名称") Then
                                ht.Remove("オプション名称")
                            End If
                            '2016.05.26 K.Oikawa e

                            scnt = scnt + 1

                        Case 2  '配送プロモーション
                            '配送プロモーションIDがセットされている場合

                            '2016.05.26 K.Oikawa s
                            '仮の置き場を使用していないカラムに変更
                            '「最終更新時間」→「オプション値」
                            'ヘッダーレコードの送料を更新
                            'oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "送料", oTool.AfterToBeforeTax(CLng(ht("最終更新時間")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            ''受注税込金額に配送プロモーション金額をセット
                            'ht("受注税込金額") = ht("最終更新時間")
                            ''ht("チャネル商品コード") = "ZZZZZ-02"

                            'If ht.ContainsKey("最終更新日") Then
                            '    ht.Remove("最終更新日")
                            '    ht.Remove("最終更新時間")
                            'End If

                            oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "値引き", oTool.AfterToBeforeTax(CLng(ht("オプション値")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            '受注税込金額に購入プロモーション金額をセット
                            If ht("受注税込金額") <> "" Then
                                ht("受注税込金額") = (CLng(ht("受注税込金額")) + CLng(ht("オプション値"))).ToString
                            Else
                                ht("受注税込金額") = ht("オプション値")
                            End If

                            If ht.ContainsKey("オプション値") Then
                                ht.Remove("オプション値")
                            End If
                            '2016.05.26 K.Oikawa e

                            scnt = scnt + 1

                        Case 4  '手数料
                            '手数料がセットされている場合
                            'ヘッダーレコードの手数料を更新
                            oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "手数料", oTool.AfterToBeforeTax(CLng(ht("定価")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            If ht("受注税込金額") <> "" Then
                                ht("受注税込金額") = (CLng(ht("受注税込金額")) + CLng(ht("定価"))).ToString
                            Else
                                ht("受注税込金額") = ht("定価")
                            End If

                            If ht.ContainsKey("定価") Then
                                ht.Remove("定価")
                            End If

                            scnt = scnt + 1

                            '2016.05.25 K.Oikawa s
                            '送料をヘッダに加算する
                        Case 8  '送料
                            '手数料がセットされている場合
                            'ヘッダーレコードの手数料を更新
                            oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "送料", oTool.AfterToBeforeTax(CLng(ht("仕入単価")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            If ht("受注税込金額") <> "" Then
                                ht("受注税込金額") = (CLng(ht("受注税込金額")) + CLng(ht("仕入単価"))).ToString
                            Else
                                ht("受注税込金額") = ht("仕入単価")
                            End If

                            If ht.ContainsKey("仕入単価") Then
                                ht.Remove("仕入単価")
                            End If

                            scnt = scnt + 1


                        Case 16  '
                            'ヘッダーレコードの手数料を更新
                            oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "ギフト梱包料金", oTool.AfterToBeforeTax(CLng(ht("受注税抜金額")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

                            If ht("受注税込金額") <> "" Then
                                ht("受注税込金額") = (CLng(ht("受注税込金額")) + CLng(ht("受注税抜金額"))).ToString
                            Else
                                ht("受注税込金額") = ht("受注税抜金額")
                            End If

                            If ht.ContainsKey("受注税抜金額") Then
                                ht.Remove("受注税抜金額")
                            End If

                            scnt = scnt + 1

                            '2016.05.25 K.Oikawa e

                    End Select
                    i = i * 2
                End While
            End If

            'Select Case Mode
            '    Case "購入プロモーション"
            '        '購入プロモーションIDがセットされている場合

            '        'ヘッダーレコードの値引きを更新
            '        oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "値引き", oTool.AfterToBeforeTax(CLng(ht("登録時間")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

            '        '受注税込金額に購入プロモーション金額をセット
            '        ht("受注税込金額") = ht("登録時間")
            '        'ht("チャネル商品コード") = "ZZZZZ-01"

            '        If ht.ContainsKey("登録日") Then
            '            ht.Remove("登録日")
            '            ht.Remove("登録時間")
            '        End If

            '    Case "配送プロモーション"
            '        '配送プロモーションIDがセットされている場合

            '        'ヘッダーレコードの送料を更新
            '        oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "送料", oTool.AfterToBeforeTax(CLng(ht("最終更新時間")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

            '        '受注税込金額に配送プロモーション金額をセット
            '        ht("受注税込金額") = ht("最終更新時間")
            '        'ht("チャネル商品コード") = "ZZZZZ-02"

            '        If ht.ContainsKey("最終更新日") Then
            '            ht.Remove("最終更新日")
            '            ht.Remove("最終更新時間")
            '        End If
            '    Case "手数料"
            '        '手数料がセットされている場合

            '        'ヘッダーレコードの手数料を更新
            '        oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "手数料", oTool.AfterToBeforeTax(CLng(ht("定価")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

            '    Case "ポイント値引き"
            '        'ポイント値引き（先払い）がセットされている場合

            '        'ヘッダーレコードのポイント値引きを更新
            '        oDataRequestTMPDBIO.updateRequestMst2(ht("受注コード").ToString, "ポイント値引き", oTool.AfterToBeforeTax(CLng(ht("仕入単価")), oConf(0).sTax, oConf(0).sFracProc), "+", oTran)

            '    Case "購入商品情報"
            'End Select

        End If

        If ht.ContainsKey("受注税込金額") Then
            If ht("受注税込金額") = "" Then
                ht("受注税込金額") = "0"
            End If
            If CLng(ht("受注税込金額")) > 0 Then
                If oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc) = 0 Then

                    '2016.05.25 K.Oikawa s
                    '受注税抜金額がここより前に作られることがあるのでの存在確認追加
                    'ht.Add("受注税抜金額", CLng(ht("受注税込金額")).ToString)
                    If ht.Contains("受注税抜金額") Then
                        ht("受注税抜金額") = CLng(ht("受注税込金額")).ToString
                    Else
                        ht.Add("受注税抜金額", CLng(ht("受注税込金額")).ToString)
                    End If
                    '2016.05.25 K.Oikawa e

                Else

                    '2016.05.25 K.Oikawa s
                    '受注税抜金額がここより前に作られることがあるのでの存在確認追加
                    'ht.Add("受注税抜金額", oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString)
                    If ht.Contains("受注税抜金額") Then
                        ht("受注税抜金額") = oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString
                    Else
                        ht.Add("受注税抜金額", oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString)
                    End If
                    '2016.05.25 K.Oikawa e

                End If
                ht("受注消費税額") = CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))
                ht.Add("受注商品単価", CLng(ht("受注税抜金額")) / CLng(ht("受注数量")))

                ret = True
            End If

        End If

        AmazonPriceInfoSet = ret
    End Function

    ' Yahoo：特殊フォーマット( Yahoo受注日 YYYY/M/D → YYYY/MM/DD )
    Private Sub formatOrderDateForYahoo(ByRef ht As Hashtable)
        '2016.05.13 K.Oikawa s
        'カラム名"受注日"が存在しない場合にも実行されるので修正
        If ht.Contains("受注日") <> True Then
            Exit Sub
        End If
        '2016.05.13 K.Oikawa e
        Dim d As String = ht("受注日")
        If d.Length < 10 Then
            ht.Remove("受注日")
            ht.Add("受注日", String.Format("{0:yyyy/MM/dd}", CDate(d)))
        End If
    End Sub

    '2016.05.13 K.Oikawa s
    ' Yahoo：特殊フォーマット( Yahoo受注日 YYYY/M/D → YYYY/MM/DD )
    Private Sub PriceOrderDateForYahoo(ByRef ht As Hashtable)
        ht("受注税抜金額") = oTool.AfterToBeforeTax(CLng(ht("受注税込金額")), oConf(0).sTax, oConf(0).sFracProc).ToString
        ht("受注消費税額") = CLng(ht("受注税込金額")) - CLng(ht("受注税抜金額"))
        Dim wPrice As Integer = 0
        wPrice = CLng(ht("受注税込金額"))
        If ht.Contains("送料") Then
            wPrice = wPrice - CLng(ht("送料"))
            ht("送料") = oTool.AfterToBeforeTax(CLng(ht("送料")), oConf(0).sTax, oConf(0).sFracProc).ToString
        End If
        If ht.Contains("手数料") Then
            wPrice = wPrice - CLng(ht("手数料"))
            ht("手数料") = oTool.AfterToBeforeTax(CLng(ht("手数料")), oConf(0).sTax, oConf(0).sFracProc).ToString
        End If
        If ht.Contains("値引き") Then
            wPrice = wPrice + CLng(ht("値引き"))
            ht("値引き") = oTool.AfterToBeforeTax(CLng(ht("値引き")), oConf(0).sTax, oConf(0).sFracProc).ToString
        End If
        If ht.Contains("ポイント値引き") Then
            wPrice = wPrice + CLng(ht("ポイント値引き"))
            ht("ポイント値引き") = oTool.AfterToBeforeTax(CLng(ht("ポイント値引き")), oConf(0).sTax, oConf(0).sFracProc).ToString
        End If

        ht("受注商品税抜金額") = oTool.AfterToBeforeTax(wPrice, oConf(0).sTax, oConf(0).sFracProc).ToString
    End Sub
    '2016.05.13 K.Oikawa e

    Private Function CSV_IMPORT(ByVal ChannelCode As Integer, ByVal FilePath1 As String, ByVal FilePath2 As String, ByVal isOverWriteMode As Boolean) As Long

        Dim oDataShipmentDBIO As cDataShipmentDBIO
        Dim oShipment() As cStructureLib.sShipmentData
        Dim ORDER_ORREQUEST_CODE_COL As Integer
        Dim ITEM_ORREQUEST_CODE_COL As Integer
        Dim commitCnt As Long = 0
        Dim commitOrderNumInfo As New Hashtable
        Dim fieldNames As String() : ReDim fieldNames(0)
        Dim fieldNames2 As String() : ReDim fieldNames2(0)
        Dim fieldPosInfo As New Hashtable
        Dim rows As New List(Of String())
        Dim headers As New List(Of Hashtable)
        Dim lines As New List(Of Hashtable)
        Dim pChannel() As cStructureLib.sChannel
        Dim pSalePrice As Long
        Dim ht As Hashtable
        Dim requestDataColInfo As New Hashtable
        Dim requestSubDataColInfo As New Hashtable
        Dim lineNum As Integer = 0
        Dim RequestCode As String
        Dim ORRequestCode As String
        Dim preORRequestCode As String = "-999"
        Dim pRequestCode As String
        Dim fProgress As cMessageLib.fProgressMessage = Nothing
        Dim result As Integer
        Dim pIsOverWriteMode As Boolean
        Dim i As Integer
        Dim UNIT_PRICE_COL As Integer = 0



        ' プログレスバーの処理経過表示用
        Dim nowRow As Integer = 0


        If WindowMode = 1 Then
            fProgress = New cMessageLib.fProgressMessage(0, "注文情報データ読込み中", Nothing)
            fProgress.Show() : Application.DoEvents()
        End If

        Try
            oTran = oConn.BeginTransaction

            oDataShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)

            ReDim pChannel(0)
            oChannelDBIO.getChannelMst(pChannel, ChannelCode, Nothing, Nothing, Nothing, oTran)

            ' CSVファイル読込み
            Dim tfp As TextFieldParser = Nothing
            'Try
            tfp = New TextFieldParser(FilePath1, System.Text.Encoding.Default)
            tfp.TextFieldType = FileIO.FieldType.Delimited
            tfp.SetDelimiters(",", vbTab)
            tfp.HasFieldsEnclosedInQuotes = True
            tfp.TrimWhiteSpace = True

            If Not tfp.EndOfData Then
                ' CSVヘッダ(1行目)
                fieldNames = tfp.ReadFields()
                For i = 0 To fieldNames.Length - 1
                    If fieldNames(i) = pChannel(0).sORRequestCodeFieldName Then
                        ORDER_ORREQUEST_CODE_COL = i
                    End If

                    'fieldPosInfo.Add(fieldNames(i), i)
                    If fieldPosInfo.ContainsKey(fieldNames(i)) = False Then
                        fieldPosInfo.Add(fieldNames(i), i)
                    End If

                    If fieldNames(i) = "合計" Then
                        UNIT_PRICE_COL = i
                    End If

                Next
                ' CSVデータ(2行目以降)
                While Not tfp.EndOfData
                    rows.Add(tfp.ReadFields())
                End While
            End If
            'Finally
            If tfp IsNot Nothing Then
                tfp.Close() : tfp = Nothing
            End If
            'End Try


            ' ダウンロードカラムマスタ読込み
            cMstDownloadColumnDBIO = New cMstDownloadColumnDBIO(oConn, oCommand, oDataReader)
            If FilePath2 IsNot Nothing Then
                ' 受注明細が別ファイルとなるパターン(Yahoo)
                For i = 0 To fieldNames.Length - 1
                    ' 注文情報データTMP
                    Dim dc() As cStructureLib.sDownloadColumn = Nothing
                    Dim cnt As Integer = cMstDownloadColumnDBIO.getDownloadColumn(dc, ChannelCode, 1, fieldNames(i), oTran)
                    If cnt > 0 Then
                        requestDataColInfo.Add(fieldNames(i), dc)
                    End If
                Next
            Else
                ' 受注明細が別ファイルとならないパターン(楽天、Amazon、Shopserv)
                For i = 0 To fieldNames.Length - 1
                    ' 注文情報データTMP
                    Dim dc() As cStructureLib.sDownloadColumn = Nothing
                    Dim cnt As Integer = cMstDownloadColumnDBIO.getDownloadColumn(dc, ChannelCode, 1, fieldNames(i), oTran)
                    If cnt > 0 Then
                        requestDataColInfo.Add(fieldNames(i), dc)
                    End If
                    ' 注文明細情報データTMP
                    Dim dc2() As cStructureLib.sDownloadColumn = Nothing
                    Dim cnt2 As Integer = cMstDownloadColumnDBIO.getDownloadColumn(dc2, ChannelCode, 2, fieldNames(i), oTran)
                    If cnt2 > 0 Then
                        requestSubDataColInfo.Add(fieldNames(i), dc2)
                    End If
                Next
            End If


            '---------------------------------------------
            '     DB登録処理(注文情報データTMP)
            '---------------------------------------------


            For Each row As String() In rows

                pIsOverWriteMode = True

                ' プログレスバー設定
                If WindowMode = 1 Then
                    nowRow += 1
                    fProgress.MESSAGE2_L.Text = nowRow & "/" & rows.Count & "を処理中"
                    fProgress.ProgressBar.Value = nowRow / rows.Count * 100
                    Application.DoEvents()
                End If

                ' OR受注コードの取得
                ORRequestCode = row(ORDER_ORREQUEST_CODE_COL)

                If commitOrderNumInfo.ContainsKey(ORRequestCode) <> True Then
                    ' マッピング開始
                    ht = New Hashtable

                    ' 受注情報データTMPと受注情報データに対し、OR受注コードの存在確認
                    RequestCode = REQUEST_NUMBER_READ(ORRequestCode)
                    If RequestCode <> Nothing Then
                        ' 受注コード
                        ht.Add("受注コード", RequestCode)

                        ReDim oShipment(0)
                        '未出荷の場合
                        'If oDataShipmentDBIO.getShipment(oShipment, RequestCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran) = 0 Then

                        '受注情報データTMP（ヘッダー＆明細）削除
                        result = oDataRequestTMPDBIO.deleteSetData(ORRequestCode, oTran)
                        '受注情報データ（ヘッダー＆明細）削除
                        result = oDataRequestDBIO.deleteSetData(ORRequestCode, oTran)


                        'Else    '出荷済みの場合
                        '    pIsOverWriteMode = False
                        'End If
                        '' 上書モードでなく、かつ、既に登録済の場合は受注をインポートしない
                        'If Not isOverWriteMode Then Continue For
                    End If

                    ' 受注コード
                    If ht.ContainsKey("受注コード") = False Then
                        ht.Add("受注コード", REQUEST_NUMBER_CREATE(ChannelCode))
                    End If


                    ' チャネルコード
                    ht.Add("チャネルコード", ChannelCode)

                    '2016.07.11 K.Oikawa s
                    '課題表No68 Yahoo取り込み時エラー
                    '' 受注サイト
                    'ht.Add("受注サイト", pChannel(0).sChannelName)
                    If pChannel(0).sChannelName <> "Yahoo店" Then
                        ' 受注サイト
                        ht.Add("受注サイト", pChannel(0).sChannelName)
                    End If
                    '2016.07.11 K.Oikawa e

                    '※注意
                    'Yahoo: CSVの最終行について、最終列とEOFの間に余分な半角スペースが付加されている。
                    'それが原因で、CSV最終行のみ1列余分な値がrow配列に格納され、配列添え字エラーの現象が発生している。
                    '現象を回避するため、ループ終了の判定条件は、以下のようにする必要あり。
                    '[ For i = 0 To row.Length - 1 ]　→　[ For i = 0 To fieldNames.Length - 1 ] 

                    For i = 0 To fieldNames.Length - 1
                        ' マッピング対象外
                        If Not requestDataColInfo.ContainsKey(fieldNames(i)) Then
                            Continue For
                        End If

                        sColumn = requestDataColInfo(fieldNames(i))
                        Try
                            Mapping(ht, row, i)
                        Catch ex As Exception
                            Dim orderNum As String = ORRequestCode
                            Dim csvFileName As String = _
                                (New Regex(".*\\(.+)$", RegexOptions.Singleline)).Match(FilePath1).Groups(1).Value()
                            Dim csvColumnName As String = fieldNames(i)
                            Dim csvValue As String = row(i)
                            WriteLog(orderNum, csvFileName, ex, csvColumnName, csvValue)
                        End Try
                    Next

                    ''Amazonにおけるクレジット支払い時の支払いコードセット
                    'If pChannel(0).sCMSType = 4 And ht("チャネル支払コード") = "" Then
                    '    ht("チャネル支払コード") = "17"
                    'End If

                    ' チャネル支払コード
                    setChannelPaymentCode(ht)

                    '2016.05.26 K.Oikawa s
                    '金額はここでまとめずに都度更新に変更
                    ' 受注商品税抜金額、受注税抜金額、受注消費税額
                    'setPricesAndTaxForHeader(ht, pChannel(0).sCMSType)
                    '2016.05.26 K.Oikawa e

                    ' 受注商品税抜金額、受注税抜金額、受注消費税額
                    setPricesAndTaxForHeader(ht, row, UNIT_PRICE_COL, pChannel(0).sCMSType)

                    ' 受注伝票出力フラグ
                    ht.Add("受注伝票出力フラグ", "0")
                    ' 受注担当者コード @TODO
                    ht.Add("受注担当者コード", "9999999999999")
                    ' 登録日
                    ht.Add("登録日", String.Format("{0:yyyy/MM/dd}", Now))
                    ' 登録時間
                    ht.Add("登録時間", String.Format("{0:HH:mm:ss}", Now))
                    ' 最終更新日
                    ht.Add("最終更新日", String.Format("{0:yyyy/MM/dd}", Now))
                    ' 最終更新時間
                    ht.Add("最終更新時間", String.Format("{0:HH:mm:ss}", Now))

                    ' 楽天：受注税込金額がマイナス値の場合は受注をインポートしない（ポイント未承認）
                    If ht("受注税込金額") = "-99999" Then Continue For

                    ' Yahoo：特殊フォーマット( Yahoo受注日 YYYY/M/D → YYYY/MM/DD )
                    formatOrderDateForYahoo(ht)

                    If pChannel(0).sChannelName = "Yahoo店" Then
                        ' Yahoo：金額設定
                        PriceOrderDateForYahoo(ht)
                    End If

                    ' DB登録
                    commitCnt += oDataRequestTMPDBIO.insertRequestMst2(ht, oTran)

                    '2016.05.26 K.Oikawa s
                    'htにOR受注コードが存在しないためエラー発生 取得元を変更
                    'commitOrderNumInfo.Add(ht("OR受注コード"), ht("受注コード"))
                    commitOrderNumInfo.Add(ORRequestCode, ht("受注コード"))
                    '2016.05.26 K.Oikawa e

                End If
                ht = Nothing
            Next

            If WindowMode = 1 Then
                fProgress.Dispose()
                fProgress = Nothing : Application.DoEvents()
            End If

            '---------------------------------------------
            '      DB登録処理(注文明細情報データTMP)
            '---------------------------------------------
            If commitCnt > 0 Then

                If WindowMode = 1 Then
                    fProgress = New cMessageLib.fProgressMessage(0, "注文情報明細データ読込み中", Nothing)
                    fProgress.Show() : Application.DoEvents()
                End If

                ' 受注明細が別ファイルとなるパターン(Yahoo)
                If FilePath2 IsNot Nothing Then
                    fieldPosInfo = New Hashtable
                    rows = New List(Of String())

                    'Try
                    tfp = New TextFieldParser(FilePath2, System.Text.Encoding.Default)
                    tfp.TextFieldType = FileIO.FieldType.Delimited
                    tfp.SetDelimiters(",")
                    tfp.HasFieldsEnclosedInQuotes = True
                    tfp.TrimWhiteSpace = True
                    If Not tfp.EndOfData Then
                        ' CSVヘッダ(1行目)
                        ReDim fieldNames(0)
                        fieldNames = tfp.ReadFields()
                        For i = 0 To fieldNames.Length - 1
                            If fieldNames(i) = pChannel(0).sORRequestCodeFieldName Then
                                ITEM_ORREQUEST_CODE_COL = i
                            End If
                            fieldPosInfo.Add(fieldNames(i), i)
                        Next
                        ' CSVデータ(2行目以降)
                        While Not tfp.EndOfData
                            rows.Add(tfp.ReadFields())
                        End While
                    End If
                    'Finally
                    If tfp IsNot Nothing Then
                        tfp.Close() : tfp = Nothing
                    End If
                    'End Try

                    Dim cnt2 As Integer
                    Dim dc2() As cStructureLib.sDownloadColumn

                    ' ダウンロードカラムマスタ
                    For i = 0 To fieldNames.Length - 1
                        ' 注文明細情報データTMP
                        ReDim dc2(0)
                        cnt2 = cMstDownloadColumnDBIO.getDownloadColumn(dc2, ChannelCode, 2, fieldNames(i), oTran)
                        If cnt2 > 0 Then
                            requestSubDataColInfo.Add(fieldNames(i), dc2)
                        End If
                    Next
                End If

                ' プログレスバーの処理経過表示用
                nowRow = 0

                '受注税込金額の集計用変数初期化
                pSalePrice = 0
                ORRequestCode = ""

                ' DB登録処理
                For Each row As String() In rows
                    ' 処理中プログレスバー設定
                    If WindowMode = 1 Then
                        nowRow += 1
                        fProgress.MESSAGE2_L.Text = nowRow & "/" & rows.Count & "を処理中"
                        fProgress.ProgressBar.Value = nowRow / rows.Count * 100
                    End If

                    ' OR受注コードの取得
                    ORRequestCode = row(ITEM_ORREQUEST_CODE_COL)

                    ' 受注情報データが未登録である場合は受注明細データをインポートしない
                    If Not commitOrderNumInfo.ContainsKey(ORRequestCode) Then Continue For

                    ' マッピング開始
                    ht = New Hashtable

                    ' 受注コード
                    ht.Add("受注コード", commitOrderNumInfo(ORRequestCode))
                    pRequestCode = ht("受注コード")

                    ' 受注明細コード
                    If preORRequestCode <> ORRequestCode Then
                        lineNum = 1
                    End If
                    ht.Add("受注明細コード", lineNum.ToString)

                    '※注意
                    'Yahoo: CSVの最終行について、最終列とEOFの間に余分な半角スペースが付加されている。
                    'それが原因で、CSV最終行のみ1列余分な値がrow配列に格納され、配列添え字エラーの現象が発生している。
                    '現象を回避するため、ループ終了の判定条件は、以下のようにする必要あり。
                    '[ For i = 0 To row.Length - 1 ]　→　[ For i = 0 To fieldNames.Length - 1 ] 

                    For i = 0 To fieldNames.Length - 1
                        ' マッピング対象外
                        If (Not requestSubDataColInfo.ContainsKey(fieldNames(i))) Or (fieldNames(i) = "") Then
                            Continue For
                        End If

                        sColumn = requestSubDataColInfo(fieldNames(i))
                        Try
                            Mapping(ht, row, i)
                        Catch ex As Exception
                            Dim orderNum As String = ORRequestCode
                            Dim csvFileName As String = _
                                (New Regex(".*\\(.+)$", RegexOptions.Singleline)).Match(FilePath1).Groups(1).Value()
                            Dim csvColumnName As String = fieldNames(i)
                            Dim csvValue As String = row(i)
                            WriteLog(orderNum, csvFileName, ex, csvColumnName, csvValue)
                        End Try
                    Next

                    ' 商品コード
                    If IsNothing(ht("商品コード")) = True Then
                        ht.Add("商品コード", "")
                    End If

                    ' JANコード
                    If IsNothing(ht("JANコード")) = True Then
                        ht.Add("JANコード", "")
                    End If
                    ' 商品名称
                    If IsNothing(ht("商品名称")) = True Then
                        ht.Add("商品名称", "")
                    End If

                    ' 定価、仕入単価、受注商品単価、受注税抜金額、受注消費税額、受注税込金額
                    If setPricesAndTaxForLine(ht, ChannelCode, pChannel(0).sCMSType) = True Then

                        If Not ht.ContainsKey("登録日") Then
                            ' 登録日
                            ht.Add("登録日", String.Format("{0:yyyy/MM/dd}", Now))
                            ' 登録時間
                            ht.Add("登録時間", String.Format("{0:HH:mm:ss}", Now))
                        Else
                            ' 登録日
                            ht("登録日") = String.Format("{0:yyyy/MM/dd}", Now)
                            ' 登録時間
                            ht("登録時間") = String.Format("{0:HH:mm:ss}", Now)

                        End If

                        If Not ht.ContainsKey("最終更新日") Then
                            ' 最終更新日
                            ht.Add("最終更新日", String.Format("{0:yyyy/MM/dd}", Now))
                            ' 最終更新時間
                            ht.Add("最終更新時間", String.Format("{0:HH:mm:ss}", Now))
                        Else
                            ' 登録日
                            ht("登録日") = String.Format("{0:yyyy/MM/dd}", Now)
                            ' 登録時間
                            ht("登録時間") = String.Format("{0:HH:mm:ss}", Now)

                        End If

                        ' DB登録

                        '    If ht("数量") = "" Then ht("数量") = 1
                        If ht("受注税込金額") = "0" Or ht("受注税込金額") = "" Then
                        Else
                            oDataRequestSubTMPDBIO.insertSubRequestMst2(ht, oTran)
                            lineNum = lineNum + 1
                        End If

                    End If

                    preORRequestCode = ORRequestCode
                    ht = Nothing

                Next

                'ヘッダ再更新
                EditHeader(pChannel(0).sCMSType, oTran)


                If WindowMode = 1 Then
                    fProgress.Dispose()
                    fProgress = Nothing : Application.DoEvents()
                End If

            End If

            cMstDownloadColumnDBIO = Nothing
            requestDataColInfo = Nothing
            requestSubDataColInfo = Nothing


            rows.Clear()


        Catch ex As Exception

            If oTran IsNot Nothing Then
                '---トランザクション取消
                oTran.Rollback()
                oTran.Dispose() : oTran = Nothing
            End If
            l.write(ex)
            commitCnt = 0
        Finally
            If oTran IsNot Nothing Then
                '---トランザクション終了
                oTran.Commit()
                oTran.Dispose() : oTran = Nothing
            End If
        End Try

        Return commitCnt

    End Function
    Sub AmazonHeaderUpdate(ByRef pTran As System.Data.OleDb.OleDbTransaction)
        oDataRequestTMPDBIO.updateHeaderPrice(oConf, oTran)
    End Sub
    Sub EditHeader(ByVal pCMSType As Integer, ByRef pTran As System.Data.OleDb.OleDbTransaction)

        Select Case pCMSType
            Case 1  'Yahoo
            Case 2  '楽天
            Case 3  'e-Shop
            Case 4  'Amazon
                AmazonHeaderUpdate(pTran)
        End Select

    End Sub
    '**********************
    '受注番号発番処理
    '**********************
    Private Function REQUEST_NUMBER_CREATE(ByVal ChannelCode As Integer) As String
        Dim ORDER_NUMBER As String
        Dim MaxRequestCode As Long
        Dim MaxCode1 As Long
        Dim MaxCode2 As Long
        Dim JanCode As String

        '受注情報データと受注情報データTMPから、最大の受注番号を取得
        MaxCode1 = oDataRequestDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        MaxCode2 = oDataRequestTMPDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        If MaxCode1 > MaxCode2 Then
            MaxRequestCode = MaxCode1
        Else
            MaxRequestCode = MaxCode2
        End If

        ORDER_NUMBER = "992" & String.Format("{0:0}", ChannelCode) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:00}", MaxRequestCode)

        'チェックデジットの生成
        JanCode = oTool.JANCD(ORDER_NUMBER)

        REQUEST_NUMBER_CREATE = JanCode
    End Function
    '**********************
    '受注番号読込処理
    '**********************
    Private Function REQUEST_NUMBER_READ(ByVal ORRequestCode As String) As String
        Dim RecordCount As Long
        Dim oRequestData() As cStructureLib.sRequestData : ReDim oRequestData(0)

        'OR受注コードが同じである、受注情報データの存在確認
        RecordCount = oDataRequestDBIO.getRequest(oRequestData, Nothing, Nothing, Nothing, Nothing, Nothing, ORRequestCode, Nothing, Nothing, Nothing, Nothing, 1, Nothing, Nothing, Nothing, oTran)

        'OR受注コードが同じである、受注情報データTMPの存在確認
        If RecordCount = 0 Then
            RecordCount = oDataRequestTMPDBIO.getRequest(oRequestData, Nothing, Nothing, Nothing, Nothing, ORRequestCode, oTran)
        End If

        REQUEST_NUMBER_READ = oRequestData(0).sRequestCode
    End Function

    Protected Overrides Sub Finalize()
        oMstConfigDBIO = Nothing
        oDataRequestDBIO = Nothing
        oDataRequestTMPDBIO = Nothing
        oDataRequestSubTMPDBIO = Nothing
        oMstCnvProductCdDBIO = Nothing
        oChannelDBIO = Nothing
        oMstChannelMstPaymentDBIO = Nothing
        oTool = Nothing

        MyBase.Finalize()
    End Sub
End Class
