Option Explicit On

Imports System.Text.RegularExpressions
Imports System.Web

Public Class cYahooProductWebCtl

    Private Const SLEEP_MSEC As Integer = 4000

    Private Const START_URL As String = "https://login.bizmanager.yahoo.co.jp/login"
    Private Const PROGRAM_NAME As String = "yahooUpdateItemForSEO"

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
        Dim html As String = ""
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
            wsv.setFieldValue("user_name", Me.businessID)
            wsv.setFieldValue("password", Me.businessPass)
            wsv.clickButton("020", "ログイン")


            ' --------------------------------------------------------
            msg = "リンク先へ遷移(ストアマネージャー)"
            ' --------------------------------------------------------
            wsv.followLinkByText("030", "ストアマネージャー")

            ' パスワードの再入力を促される場合があるため遷移先ページの内容を確認
            If Regex.IsMatch(wsv.getResponseText(), "<H2>パスワードの再確認</H2>") Then
                wsv.setFieldValue("password", Me.businessPass)
                wsv.clickButton("040", "ログイン")
            End If


            ' --------------------------------------------------------
            msg = "Yahoo!ストアへログイン"
            ' --------------------------------------------------------
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If Regex.IsMatch(wsv.getTitle(), "ログイン - Yahoo! JAPAN") Then
                wsv.setFieldValue("login", Me.userID)
                wsv.setFieldValue("passwd", Me.userPass)
                wsv.clickButton("050", "ログイン")
            End If


            ' --------------------------------------------------------
            msg = "「お客様の個人情報の取り扱いについて」を同意"
            ' --------------------------------------------------------
            '当該ページが表示されない場合があるためページ内容を確認
            If Regex.IsMatch(wsv.getTitle(), "お客様の個人情報の取り扱いについて") Then
                wsv.submit("060")
            End If


            ' --------------------------------------------------------
            msg = "リンク先へ遷移(商品管理)"
            ' --------------------------------------------------------
            wsv.followLinkByText("070", "商品管理")


            ' --------------------------------------------------------
            msg = "CMS掲載済の全商品コードを取得"
            ' --------------------------------------------------------
            ' @TODO
            ' 商品コードを取得
            Dim itemCds As New List(Of String)
            cWebTool.setListFromCSV(Application.StartupPath & "\Net", "Products.csv", "Product Code", itemCds)


            ' --------------------------------------------------------
            msg = "商品マスタ更新"
            ' --------------------------------------------------------

            Dim itemUpdCnt As Integer = 0
            For Each itemCd As String In itemCds
                ' --------------------------------------------------------
                msg = "商品マスタを検索"
                ' --------------------------------------------------------
                wsv.setFieldValue("w", itemCd)
                wsv.setFieldValue("passwd", Me.userPass)
                wsv.clickButton("090-" & itemCd, "検索")

                ' @TODO
                System.Threading.Thread.Sleep(SLEEP_MSEC * 1.5)

                ' --------------------------------------------------------
                msg = "商品編集画面へ遷移"
                ' --------------------------------------------------------
                html = wsv.getResponseText
                ' タグの一部が大文字に変化、ダブルクゥオーテション が欠落、
                ' HTMLエンコードされる　等、元ソースと差異あり 
                r = New Regex( _
                    "<TD class=tLeft>" & itemCd & "</TD>.*?<TD class=tLeft><A href=""[^""]*?"">(.*?)</A></TD>", _
                    RegexOptions.Singleline + RegexOptions.IgnoreCase _
                    )
                Dim linkText As String = r.Match(html).Groups(1).Value()
                linkText = Regex.Replace(linkText, "<BR>", vbCrLf)
                linkText = HttpUtility.HtmlDecode(linkText)
                wsv.followLinkByText("100-" & itemCd, linkText)
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "商品を更新"
                ' --------------------------------------------------------
                wsv.setSEOTag("caption", 10000)
                wsv.clickButton("110-" & itemCd, "更新")
                System.Threading.Thread.Sleep(SLEEP_MSEC)


                ' --------------------------------------------------------
                msg = "リンク先へ遷移(商品管理)"
                ' --------------------------------------------------------
                wsv.followLinkByText("120-" & itemCd, "商品管理")
                System.Threading.Thread.Sleep(SLEEP_MSEC)

                itemUpdCnt += 1

                '@DEBUG
                l.write(itemUpdCnt.ToString & " → " & itemCd)
            Next


            ' --------------------------------------------------------
            msg = "リンク先へ遷移(反映管理)"
            ' --------------------------------------------------------
            wsv.followLinkByText("130", "反映管理")


            ' --------------------------------------------------------
            msg = "反映ボタン押下"
            ' --------------------------------------------------------
            wsv.clickButton("140", "反映")


            ' --------------------------------------------------------
            msg = "はいボタン押下"
            ' --------------------------------------------------------
            wsv.clickButton("150", "はい")



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

