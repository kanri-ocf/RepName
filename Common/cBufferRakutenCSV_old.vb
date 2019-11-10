Option Explicit On

Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Text

Public Class cBufferRakutenCSV

    Private Const START_URL As String = "https://glogin.rms.rakuten.co.jp/"
    Private Const ORDER_CSV_NAME As String = "Rakuten_Order.csv"
    Private Const PROGRAM_NAME As String = "rakuten"
    Private Const CHARSET As String = "EUC-JP"
    Private Const CHARSET2 As String = "UTF-8"

    Private Const GET_DAYS As Integer = -7

    Private businessID As String
    Private businessPass As String
    Private userID As String
    Private userPass As String
    Private CSVsavePath As String
    Private downloadID As String
    Private downloadPass As String

    Public Sub New( _
                ByVal businessID As String, _
                ByVal businessPass As String, _
                ByVal userID As String, _
                ByVal userPass As String, _
                ByVal downloadID As String, _
                ByVal downloadPass As String, _
                ByVal CSVsavePath As String _
                )
        Me.businessID = businessID
        Me.businessPass = businessPass
        Me.userID = userID
        Me.userPass = userPass
        Me.CSVsavePath = CSVsavePath
        Me.downloadID = downloadID
        Me.downloadPass = downloadPass
    End Sub


    Public Function download() As Integer
        Dim rtnStatus As Integer = 0

        Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        Dim msg As String = ""
        Dim html As String = ""
        Dim url As String = ""
        Dim referer As String
        Dim r As Regex
        Dim params As List(Of String)
        Dim pText As String
        Dim wxh As New cWrapXMLHTTP(Application.StartupPath & "\Net", PROGRAM_NAME)

        Try
            ' LOGオープン
            l.open()

            ' --------------------------------------------------------
            msg = "CSVダウンロード開始" : l.write(msg)
            ' --------------------------------------------------------



            ' --------------------------------------------------------
            msg = "開始ページを読込"
            ' --------------------------------------------------------
            url = START_URL
            wxh.sendGet("010", url, Nothing)


            ' --------------------------------------------------------
            msg = "R-Login IDの認証"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<form action=""([^""]*?)"".*?" & _
                "<input type=""hidden"" name=""module"" value=""([^""]*?)"">.*?" & _
                "<input type=""hidden"" name=""action"" value=""([^""]*?)"">.*?" & _
                "<input type=""submit"" .*?value=""([^""]*?)"">", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            params = New List(Of String)
            params.Add("module=" & r.Match(html).Groups(2).Value())
            params.Add("action=" & r.Match(html).Groups(3).Value())
            params.Add("login_id=" & Me.businessID)
            params.Add("passwd=" & Me.businessPass)
            params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(4).Value(), Encoding.GetEncoding(CHARSET)))
            pText = String.Join("&", params.ToArray)
            wxh.sendPost("020", url, referer, pText)


            ' --------------------------------------------------------
            msg = "楽天会員の認証"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If Regex.IsMatch(html, "<title>【楽天】 R-Login ログイン </title>") Then
                r = New Regex( _
                    "<form action=""([^""]*?)"".*?" & _
                    "<input type=""hidden"" name=""module"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""action"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""biz_login_id"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""business_id"" value=""([^""]*?)"">.*?" & _
                    "<input .*?type=""submit"" .*?value=""([^""]*?)"">", _
                    RegexOptions.Singleline _
                    )
                referer = url : url = r.Match(html).Groups(1).Value()
                params = New List(Of String)
                params.Add("module=" & r.Match(html).Groups(2).Value())
                params.Add("action=" & r.Match(html).Groups(3).Value())
                params.Add("biz_login_id=" & r.Match(html).Groups(4).Value())
                params.Add("business_id=" & r.Match(html).Groups(5).Value())
                params.Add("user_id=" & Me.userID)
                params.Add("user_passwd=" & Me.userPass)
                params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(6).Value(), Encoding.GetEncoding(CHARSET)))
                pText = String.Join("&", params.ToArray)
                wxh.sendPost("030", url, referer, pText)
            End If


            ' --------------------------------------------------------
            msg = "楽天からのお知らせページ、ボタンのリンク先へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If Regex.IsMatch(html, "<title> 【楽天】 R-Login 楽天からのお知らせ </title>") Then
                r = New Regex( _
                    "<form action=""([^""]*?)"".*?" & _
                    "<input type=""hidden"" name=""module"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""action"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""__suid"" value=""([^""]*?)"">.*?" & _
                    "<input .*?type=""submit"" .*?value=""([^""]*?)"">", _
                    RegexOptions.Singleline _
                    )
                referer = url : url = r.Match(html).Groups(1).Value()
                params = New List(Of String)
                params.Add("module=" & r.Match(html).Groups(2).Value())
                params.Add("action=" & r.Match(html).Groups(3).Value())
                params.Add("__suid=" & r.Match(html).Groups(4).Value())
                params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(5).Value(), Encoding.GetEncoding(CHARSET)))
                pText = String.Join("&", params.ToArray)
                wxh.sendPost("040", url, referer, pText)
            End If


            ' --------------------------------------------------------
            msg = "「ＲＭＳ利用」の同意1"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            ' 当該ページが表示されない場合があるためページ内容を確認
            If Regex.IsMatch(html, "<input type=""submit"" value=""上記を遵守していることを確認の上、RMSを利用します"">") Then
                r = New Regex( _
                    "<form action=""([^""]*?)"".*?" & _
                    "<input .*?type=""submit"" .*?value=""([^""]*?)"">", _
                    RegexOptions.Singleline _
                    )
                referer = url : url = r.Match(html).Groups(1).Value()
                params = New List(Of String)
                params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(2).Value(), Encoding.GetEncoding(CHARSET2)))
                pText = String.Join("&", params.ToArray)
                wxh.sendPost("050", url, referer, pText)
            End If


            ' --------------------------------------------------------
            msg = "リンク(ＲＭＳ)先へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)"">ＲＭＳ</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("060", url, referer)


            ' --------------------------------------------------------
            msg = "「ＲＭＳ利用」の同意2"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            ' 当該ページが表示されない場合があるためページ内容を確認
            If Regex.IsMatch(html, "<input type=""submit"" value=""上記を遵守していることを確認の上、RMSを利用します"">") Then
                r = New Regex( _
                    "<form action=""([^""]*?)"".*?" & _
                    "<input .*?type=""submit"" .*?value=""([^""]*?)"">", _
                    RegexOptions.Singleline _
                    )
                referer = url : url = r.Match(html).Groups(1).Value()
                params = New List(Of String)
                params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(2).Value(), Encoding.GetEncoding(CHARSET2)))
                pText = String.Join("&", params.ToArray)
                wxh.sendPost("070", url, referer, pText)
            End If


            ' --------------------------------------------------------
            msg = "ダミー画像を読込み、新規受付ページで必要な Cookie を取得"
            ' --------------------------------------------------------
            html = wxh.getResponseText()

            ' ページタイトルの確認
            If Not (Regex.IsMatch(html, "<title>【楽天市場】RMS メインメニュー </title>")) Then
                Throw New Exception("ページタイトルが不一致です。")
            End If

            r = New Regex( _
                "<img src=""(https://order\.rms\.rakuten\.co\.jp/rms/mall/rj/login\?[^""]*?)"" width=""1"" height=""1"">", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGetImage("080", url, referer)
            url = referer


            ' --------------------------------------------------------
            msg = "ダミー画像を読込み、データダウンロード(有料)ページで必要な Cookie を取得"
            ' --------------------------------------------------------
            'html = wxh.getResponseText()
            r = New Regex( _
                "<img src=""(https://csvdl\.rms\.rakuten\.co\.jp/rms/mall/csvdl/login\?[^""]*?)"" width=""1"" height=""1"">", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGetImage("090", url, referer)
            url = referer

            ' --------------------------------------------------------
            msg = "リンク先(受注・受付管理)へ遷移"
            ' --------------------------------------------------------
            'html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)""><span>2-1</span>受注・受付管理</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("100", url, referer)

            ' --------------------------------------------------------
            msg = "リンク先(ポイント利用注文一覧)へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)"">ポイント利用注文一覧</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("120", url, referer)

            ' --------------------------------------------------------
            msg = "ポイント承認"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            Dim mc As MatchCollection = r.Matches(html)
            r = New Regex( _
                "<form action=""([^""]*?)"".*?" & _
                "<input type=""hidden"" name=""__event"" value=""([^""]*?)"">.*?" & _
                "<input type=""hidden"" name=""token_key"" value=""([^""]*?)"">.*?" & _
                "<select name=""to_year"">.*?<option value=""([^""]*?)"" +selected>.*?</select>.*?" & _
                "<select name=""to_month"">.*?<option value=""([^""]*?)"" +selected>.*?</select>.*?" & _
                "<select name=""to_day"">.*?<option value=""([^""]*?)"" +selected>.*?</select>.*?" & _
                "<input .*?type=""submit"" .*?value=""([^""]*?)"">", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            params = New List(Of String)
            params.Add("__event=" & r.Match(html).Groups(2).Value())
            params.Add("token_key=" & r.Match(html).Groups(3).Value())
            params.Add("from_year=" & Now.AddDays(GET_DAYS).Year)
            params.Add("from_month=" & Now.AddDays(GET_DAYS).Month)
            params.Add("from_day=" & Now.AddDays(GET_DAYS).Day)
            params.Add("to_year=" & Now.Year)
            params.Add("to_month=" & Now.Month)
            params.Add("to_day=" & Now.Day)
            params.Add("point_type=3")
            params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(7).Value(), Encoding.GetEncoding(CHARSET2)))
            pText = String.Join("&", params.ToArray)
            wxh.sendPost("130", url, referer, pText)

            ' --------------------------------------------------------
            msg = "問合せ結果を確認"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            If (Regex.IsMatch(html, "<input type=""submit"" value=""ポイント承認を行う"">")) Then
                r = New Regex( _
                    "<input type=""checkbox"" name=""order_number"".*?value=""([^""]*?)"" onClick", _
                    RegexOptions.Singleline _
                    )
                mc = r.Matches(html)

                r = New Regex( _
                    "<input type=""submit"" value=""絞り込み表示"">.*?" & _
                    "<form method=""post"" action=""([^""]*?)"".*?" & _
                    "<input type=""hidden"" name=""__event"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""token_key"" value=""([^""]*?)"">.*?" & _
                    "<input type=""hidden"" name=""view_trans_key"" value=""([^""]*?)"".*?>" & _
                    "<input type=""submit"" .*?value=""([^""]*?)"">", _
                    RegexOptions.Singleline _
                    )
                referer = url : url = r.Match(html).Groups(1).Value()
                params = New List(Of String)
                params.Add("__event=" & r.Match(html).Groups(2).Value())
                params.Add("token_key=" & r.Match(html).Groups(3).Value())
                params.Add("view_trans_key=" & r.Match(html).Groups(4).Value())
                For Each m As Match In mc
                    params.Add("order_number=" & m.Groups(1).Value)
                Next
                params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(5).Value(), Encoding.GetEncoding(CHARSET2)))
                pText = String.Join("&", params.ToArray)
                wxh.sendPost("131", url, referer, pText)
            End If

            ' --------------------------------------------------------
            msg = "RMSメインメニューへ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                 "<a href=""([^""]*?)"">RMSメインメニュー</a>.*?", _
                 RegexOptions.Singleline _
                 )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("132", url, referer)

            ' --------------------------------------------------------
            msg = "リンク先(受注・受付管理)へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)""><span>2-1</span>受注・受付管理</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("100", url, referer)

            ' --------------------------------------------------------
            msg = "リンク先(データダウンロード(有料))へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)"">データダウンロード（有料）</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = r.Match(html).Groups(1).Value()
            wxh.sendGet("110", url, referer)
            ' --------------------------------------------------------
            msg = "リンク先(通常購入データ)へ遷移"
            ' --------------------------------------------------------
            html = wxh.getResponseText()
            r = New Regex( _
                "<a href=""([^""]*?)""><font size=""-1"">通常購入データ</font></a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = "https://csvdl.rms.rakuten.co.jp" & r.Match(html).Groups(1).Value()
            wxh.sendGet("120", url, referer)

            ' --------------------------------------------------------
            msg = "CSVダウンロード"
            ' --------------------------------------------------------
            html = wxh.getResponseText()

            ' ページタイトルの確認
            If Not (Regex.IsMatch(html, "<title> 【楽天市場】R-Backoffice データダウンロード（通常購入） </title>")) Then
                Throw New Exception("ページタイトルが不一致です。")
            End If

            r = New Regex( _
                "<input type=""hidden"" name=""org.apache.struts.taglib.html.TOKEN"" value=""([^""]*?)"">.*?" & _
                "<input type=""hidden"" name=""dataType"" value=""([^""]*?)"">.*?" & _
                "<a href=""([^""]*?)"">データダウンロードサービストップページへ</a>", _
                RegexOptions.Singleline _
                )
            referer = url : url = cWebTool.getAbsoluteUrl(referer, "/rms/mall/csvdl/CD02_01_012")
            params = New List(Of String)
            params.Add("org.apache.struts.taglib.html.TOKEN=" & r.Match(html).Groups(1).Value())
            params.Add("dataType=" & r.Match(html).Groups(2).Value())
            params.Add("fromYmd=" & String.Format("{0:yyyy-MM-dd}", Now.AddDays(-7)))
            params.Add("fromH=0")
            params.Add("fromM=0")
            params.Add("toYmd=" & String.Format("{0:yyyy-MM-dd}", Now))
            params.Add("toH=23")
            params.Add("toM=59")
            params.Add("dateType=1")
            params.Add("orderStatusId=-10")
            params.Add("orderStatusName=" & HttpUtility.UrlEncode("新規受付", Encoding.GetEncoding(CHARSET)))
            params.Add("carrier=0")
            params.Add("settlementId=-10")
            params.Add("cardStatusId=-10")
            params.Add("rbankStatusId=-10")
            params.Add("deliveryId=-10")
            params.Add("templateId=-2")
            params.Add("templateName=" & HttpUtility.UrlEncode("全カラムダウンロード用", Encoding.GetEncoding(CHARSET)))
            params.Add("tmp_u=")
            params.Add("user=" & Me.downloadID)
            params.Add("tmp_p=")
            params.Add("passwd=" & Me.downloadPass)
            pText = String.Join("&", params.ToArray)
            wxh.sendPost("160", url, referer, pText)

            Dim urlBack As String = cWebTool.getAbsoluteUrl(referer, r.Match(html).Groups(3).Value())

            ' ダウンロード
            html = wxh.getResponseText()
            r = New Regex( _
                "<form name=""CD03_02_002Form"" method=""post"" action=""([^""]*?)"">.*?" & _
                "<input type=""hidden"" name=""org.apache.struts.taglib.html.TOKEN"" value=""([^""]*?)"">.*?" & _
                "<input type=""submit"" value=""([^""]*?)"">.*?" & _
                "<input type=""hidden"" name=""logId"" value=""([^""]*?)"">", _
                RegexOptions.Singleline _
                )
            referer = url : url = cWebTool.getAbsoluteUrl(referer, r.Match(html).Groups(1).Value())
            params = New List(Of String)
            params.Add("org.apache.struts.taglib.html.TOKEN=" & r.Match(html).Groups(2).Value())
            params.Add("submit=" & HttpUtility.UrlEncode(r.Match(html).Groups(3).Value(), Encoding.GetEncoding(CHARSET)))
            params.Add("logId=" & r.Match(html).Groups(4).Value())
            pText = String.Join("&", params.ToArray)
            wxh.sendPost("170", url, referer, pText)

            wxh.downloadCSV(CSVsavePath, ORDER_CSV_NAME)

            ' データダウンロードサービストップページへ
            wxh.sendGet("180", urlBack, referer)

            ' CSVバックアップ
            cWebTool.backUp(CSVsavePath, ORDER_CSV_NAME)

            ' CSV内容確認
            If Not (cWebTool.isCSV(CSVsavePath, ORDER_CSV_NAME, "^""受注番号"",")) Then
                System.IO.File.Delete(CSVsavePath & "\" & ORDER_CSV_NAME)
                Throw New Exception("CSVファイルの内容が正しくないため削除しました。")
            End If

            ' --------------------------------------------------------
            msg = "CSVダウンロード終了" : l.write(msg)
            ' --------------------------------------------------------

        Catch ex As Exception
            l.write(msg)
            l.write(ex)
            l.write("以下パスにHTMLダンプを出力：" & vbCrLf & wxh.getFullDumpFilePath())
            rtnStatus = -1

        Finally
            ' HTMLダンプの削除
            If rtnStatus <> -1 Then System.IO.File.Delete(wxh.getFullDumpFilePath())

            ' LOGクローズ
            l.close() : l = Nothing
            wxh.Dispose() : wxh = Nothing

        End Try

        ' 終了ステータスの返却
        Return rtnStatus

    End Function
End Class
