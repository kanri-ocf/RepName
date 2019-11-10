Option Explicit On

Imports System.Text.RegularExpressions
Imports System.Web

Public Class cRakutenProductWebCtl

    Private Const SLEEP_MSEC As Integer = 4000

    Private Const START_URL As String = "https://glogin.rms.rakuten.co.jp/"
    Private Const PROGRAM_NAME As String = "rakutenUpdateItemForSEO"

    Private businessID As String
    Private businessPass As String
    Private userID As String
    Private userPass As String

    Public Sub New( _
                ByVal businessID As String, _
                ByVal businessPass As String, _
                ByVal userID As String, _
                ByVal userPass As String _
                )
        Me.businessID = businessID
        Me.businessPass = businessPass
        Me.userID = userID
        Me.userPass = userPass
    End Sub

    Public Function download() As Integer
        Dim rtnStatus As Integer = 0
        Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        Dim msg As String = ""
        Dim r As Regex

        Dim wsv As New cWrapSHDocVw(Application.StartupPath & "\Net", PROGRAM_NAME)

        Try
            ' LOGオープン
            l.open()

            ' --------------------------------------------------------
            msg = "商品マスタ更新開始" : l.write(msg)
            ' --------------------------------------------------------



            ' --------------------------------------------------------
            msg = "開始ページを読込"
            ' --------------------------------------------------------
            wsv.sendGet("010", START_URL)


            ' --------------------------------------------------------
            msg = "R-Login IDの認証"
            ' --------------------------------------------------------
            wsv.setFieldValue("login_id", Me.businessID)
            wsv.setFieldValue("passwd", Me.businessPass)
            wsv.submit("020")


            ' --------------------------------------------------------
            msg = "楽天会員の認証"
            ' --------------------------------------------------------
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If Regex.IsMatch(wsv.getTitle(), "【楽天】 R-Login ログイン") Then
                wsv.setFieldValue("user_id", Me.userID)
                wsv.setFieldValue("user_passwd", Me.userPass)
                wsv.submit("030")
            End If


            ' --------------------------------------------------------
            msg = "楽天からのお知らせページ、ボタンのリンク先へ遷移"
            ' --------------------------------------------------------
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If Regex.IsMatch(wsv.getTitle(), "【楽天】 R-Login 楽天からのお知らせ") Then
                wsv.submit("040")
            End If


            ' --------------------------------------------------------
            msg = "「ＲＭＳ利用」の同意1"
            ' --------------------------------------------------------
            '当該ページが表示されない場合があるためページ内容を確認
            If Regex.IsMatch(wsv.getResponseText(), "上記を遵守していることを確認の上、RMSを利用します") Then
                wsv.clickButton("050", "上記を遵守していることを確認の上、RMSを利用します")
            End If


            ' --------------------------------------------------------
            msg = "リンク(ＲＭＳ)先へ遷移"
            ' --------------------------------------------------------
            wsv.followLinkByText("060", "ＲＭＳ")


            ' --------------------------------------------------------
            msg = "「ＲＭＳ利用」の同意2"
            ' --------------------------------------------------------
            '当該ページが表示されない場合があるためページ内容を確認
            Dim ss = wsv.getResponseText()
            If Regex.IsMatch(wsv.getResponseText(), "上記を遵守していることを確認の上、RMSを利用します") Then
                wsv.clickButton("070", "上記を遵守していることを確認の上、RMSを利用します")
            End If


            ' --------------------------------------------------------
            msg = "リンク先(商品ページ設定)へ遷移"
            ' --------------------------------------------------------
            wsv.followLinkByText("080", "商品ページ設定")


            ' --------------------------------------------------------
            msg = "リンク先(商品ページ設定)へ遷移"
            ' --------------------------------------------------------
            wsv.followLinkByText("090", "商品個別編集(一覧表示)")


            ' --------------------------------------------------------
            msg = "リンク先(通常)へ遷移"
            ' --------------------------------------------------------
            wsv.followLinkByText("100", "通常")


            ' --------------------------------------------------------
            msg = "CMS掲載済の全商品コードを取得"
            ' --------------------------------------------------------
            ' 商品コードを取得
            Dim itemCds As New List(Of String)
            Dim pageCnt As Integer = 1
            While True
                Dim html As String = wsv.getResponseText()
                ' 注意：Aタグが大文字に変わる
                r = New Regex("<a href=""[^""]*?mng_number=([^""]*?) *"">変更</a>", RegexOptions.Singleline + RegexOptions.IgnoreCase)
                Dim mc As MatchCollection = r.Matches(html)
                For Each m As Match In mc
                    If Not itemCds.Contains(m.Groups(1).Value) Then
                        itemCds.Add(m.Groups(1).Value)
                    End If
                Next
                pageCnt += 1
                ' 注意：selectを囲っているダブルクゥオーテションが無くなる、Aタグが大文字に変わる
                Dim pattern As String = "<span class=""*select""*><a href=""([^""]*?)"">" & pageCnt.ToString & "</a></span>"
                If Not Regex.IsMatch(html, pattern, RegexOptions.IgnoreCase) Then
                    Exit While
                Else
                    r = New Regex(pattern, RegexOptions.IgnoreCase)
                    Dim url As String = r.Match(html).Groups(1).Value()
                    ' 注意："&amp;"→"&" とHTMLエンコードされる
                    url = HttpUtility.HtmlDecode(url)
                    wsv.sendGet("110-" & pageCnt.ToString, url)
                End If
            End While


            ' --------------------------------------------------------
            msg = "商品マスタ更新"
            ' --------------------------------------------------------

            Dim itemUpdCnt As Integer = 0
            For Each itemCd As String In itemCds
                ' --------------------------------------------------------
                msg = "リンク先(商品ページ設定)へ遷移"
                ' --------------------------------------------------------
                wsv.followLinkByText("120-" & itemCd, "商品ページ設定")
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "リンク先(商品個別編集(完全一致))へ遷移"
                ' --------------------------------------------------------
                wsv.followLinkByText("130-" & itemCd, "商品個別編集(完全一致)")
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "商品を検索"
                ' --------------------------------------------------------
                wsv.setFieldValue("mng_number", itemCd)
                wsv.clickButton("140-" & itemCd, "検索する")
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "リンク先(商品情報の変更をする)へ遷移"
                ' --------------------------------------------------------
                wsv.followLinkByText("150-" & itemCd, "商品情報の変更をする")
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "商品を更新"
                ' --------------------------------------------------------
                wsv.setAutoOKConfirmDialogBox()
                wsv.setSEOTag("catalog_caption", 10240)
                wsv.setSEOTag("mobile_caption", 1024)
                wsv.submit("160-" & itemCd)
                System.Threading.Thread.Sleep(SLEEP_MSEC)

                itemUpdCnt += 1
                '@DEBUG
                l.write(itemUpdCnt.ToString & " → " & itemCd)
            Next

            ' --------------------------------------------------------
            msg = "商品マスタ更新終了(更新件数: " & itemUpdCnt.ToString & " 件)" : l.write(msg)
            ' --------------------------------------------------------
            ' HTMLダンプの削除
            If System.IO.File.Exists(wsv.getFullDumpFilePath()) = True Then
                System.IO.File.Delete(wsv.getFullDumpFilePath())
            End If

        Catch ex As Exception
            l.write(msg)
            l.write(ex)
            l.write("以下パスにHTMLダンプを出力：" & vbCrLf & wsv.getFullDumpFilePath())
            rtnStatus = -1

        Finally
            ' LOGクローズ
            l.close() : l = Nothing
            wsv.Dispose() : wsv = Nothing

        End Try

        ' 終了ステータスの返却
        Return rtnStatus

    End Function

End Class
