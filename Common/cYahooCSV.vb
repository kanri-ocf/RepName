Option Explicit On

Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports SHDocVw

Public Class cBufferYahooCSV

    Private Const START_URL As String = "https://login.bizmanager.yahoo.co.jp/login"
    Private Const ORDER_CSV_NAME As String = "Yahoo_Order.csv"
    Private Const PRODUCT_CSV_NAME As String = "Yahoo_Product.csv"
    Private Const SLEEP_MSEC As Integer = 2000
    Private Const MIME_EXCEL As String = "MIME\Database\Content Type\application/msexcel"
    Private Const CLSID_IE As String = "{25336920-03F9-11cf-8FD0-00AA00686F13}"
    Private Const LOG_PREFIX As String = "yahoo"

    Private businessID As String
    Private businessPass As String
    Private userID As String
    Private userPass As String
    Private CSVsavePath As String

    Public Sub New( _
                ByVal businessID As String, _
                ByVal businessPass As String, _
                ByVal userID As String, _
                ByVal userPass As String, _
                ByVal CSVsavePath As String _
                )
        Me.businessID = businessID
        Me.businessPass = businessPass
        Me.userID = userID
        Me.userPass = userPass
        Me.CSVsavePath = CSVsavePath

    End Sub

    Private Sub waitURLLoadComplete(ByRef ie As InternetExplorer)
        While ie.Busy Or ie.ReadyState <> tagREADYSTATE.READYSTATE_COMPLETE
            System.Threading.Thread.Sleep(SLEEP_MSEC)
        End While
    End Sub

    Public Function download() As Integer
        Dim rtnStatus As Integer = 0

        Dim ie As New InternetExplorer
        Dim l As New cLog(Me.CSVsavePath & "\log", LOG_PREFIX)
        Dim i As Integer
        Dim msg As String

        ' デバッグ用
        'ie.Visible = True

        Try
            ' LOGオープン
            l.open()

            ' --------------------------------------------------------
            msg = "CSVダウンロード開始" : l.write(msg)
            ' --------------------------------------------------------
            'msg = "businessID: " & Me.businessID : l.write(msg)
            'msg = "businessPass: " & Me.businessPass : l.write(msg)
            'msg = "userID: " & Me.userID : l.write(msg)
            'msg = "userPass: " & Me.userPass : l.write(msg)
            'msg = "CSVsavePath: " & Me.CSVsavePath : l.write(msg)


            ' --------------------------------------------------------
            msg = "MIME(application/msexcel)の追加" : l.write(msg)
            ' --------------------------------------------------------
            ' MIME設定によりCSVダウンロード先をIE画面にする(ダウンロードダイアログ表示を回避するため)
            If Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(MIME_EXCEL, False) Is Nothing Then
                Dim regkey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(MIME_EXCEL)
                regkey.SetValue("CLSID", CLSID_IE, Microsoft.Win32.RegistryValueKind.String)
                regkey.SetValue("Extension", ".csv", Microsoft.Win32.RegistryValueKind.String)
                regkey.Close() : regkey = Nothing
            End If


            ' --------------------------------------------------------
            msg = "開始ページを読込" : l.write(msg)
            ' --------------------------------------------------------
            ie.Navigate(START_URL)
            waitURLLoadComplete(ie)


            ' --------------------------------------------------------
            msg = "Yahoo!ビジネスマネージャーへログイン" : l.write(msg)
            ' --------------------------------------------------------
            ie.Document.login_form.user_name.value = Me.businessID
            ie.Document.login_form.password.value = Me.businessPass
            ie.Document.login_form.Submit()
            waitURLLoadComplete(ie)


            ' --------------------------------------------------------
            msg = "リンク先へ遷移(ストアマネージャー)" : l.write(msg)
            ' --------------------------------------------------------
            For i = 0 To ie.Document.links.length
                If 1 <= InStr(ie.Document.links(i).innerText, "ストアマネージャー") Then
                    ie.Navigate(ie.Document.links(i).href)
                    Exit For
                End If
            Next
            waitURLLoadComplete(ie)

            ' パスワードの再入力を促される場合があるため遷移先ページの内容を確認
            Dim HTMLText As String = ie.Document.body.innerHtml
            If 1 <= InStr(HTMLText, "<H2>パスワードの再確認</H2>") Then
                ie.Document.login_form.password.value = Me.businessPass
                For Each item In ie.Document.Forms(0).All
                    If TypeName(item) = "HTMLInputElement" Then
                        If item.alt = "ログイン" Then
                            Call item.Click()
                            Exit For
                        End If
                    End If
                Next
                waitURLLoadComplete(ie)
            End If


            ' --------------------------------------------------------
            msg = "Yahoo!ストアへログイン" : l.write(msg)
            ' --------------------------------------------------------
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If 1 <= InStr(ie.LocationName, "ログイン - Yahoo! JAPAN") Then
                ie.Document.login_form.username.value = Me.userID
                ie.Document.login_form.passwd.value = Me.userPass
                ie.Document.login_form.Submit()
                waitURLLoadComplete(ie)
            End If


            ' --------------------------------------------------------
            msg = "「お客様の個人情報の取り扱いについて」を同意" : l.write(msg)
            ' --------------------------------------------------------
            ' 当該ページが表示されない場合があるためページタイトルを確認
            If 1 <= InStr(ie.LocationName, "お客様の個人情報の取り扱いについて") Then
                ie.Document.Forms(0).Submit()
                waitURLLoadComplete(ie)
            End If


            ' --------------------------------------------------------
            msg = "リンク先へ遷移(新規注文)" : l.write(msg)
            ' --------------------------------------------------------
            For i = 0 To ie.Document.links.length
                If 1 <= InStr(ie.Document.links(i).innerText, "新規注文") Then
                    ie.Navigate(ie.Document.links(i).href)
                    Exit For
                End If
            Next
            waitURLLoadComplete(ie)

            ' --------------------------------------------------------
            msg = "新規注文の存在確認" : l.write(msg)
            ' --------------------------------------------------------
            HTMLText = ie.Document.body.innerHtml
            ' 新規注文が存在しない場合、ログアウト
            If 1 <= InStr(HTMLText, "一致する注文はありませんでした") Then
                For i = 0 To ie.Document.links.length
                    If 1 <= InStr(ie.Document.links(i).innerText, "ログアウト") Then
                        ie.Navigate(ie.Document.links(i).href)
                        Exit For
                    End If
                Next
                waitURLLoadComplete(ie)
                ' 終了ステータスの返却
                Return rtnStatus
            End If

            ' 注文選択のチェックボックスをオン、メール送信チェックボックスをオフ
            For Each item In ie.Document.Forms(1)
                If Regex.IsMatch(item.Name, "F[0-9]+") Then
                    item.Checked = Not item.checked
                End If
            Next
            ' 注文伝票ダウンロードのボタンをクリック(CSVダウンロード画面へ遷移)
            For Each item In ie.Document.Forms(1)
                If item.Value = "注文情報ダウンロード" Then
                    item.Click() : Exit For
                End If
            Next
            waitURLLoadComplete(ie)


            ' --------------------------------------------------------
            msg = "order.csv のURL取得" : l.write(msg)
            ' --------------------------------------------------------
            HTMLText = ie.Document.body.innerHtml
            Dim orderCSVURL As String = ""
            Dim r As Regex = New Regex("order\.csv.*?href=""([^""]*?)""", RegexOptions.Singleline)
            Dim s As String = (r.Match(HTMLText)).Groups(1).Value()
            ' 相対URL→絶対URLに変換
            For i = 0 To ie.Document.links.length
                If 1 <= InStr(ie.Document.links(i).href, s) Then
                    orderCSVURL = ie.Document.links(i).href
                    Exit For
                End If
            Next


            ' --------------------------------------------------------
            msg = "product.csv のURL取得" : l.write(msg)
            ' --------------------------------------------------------
            Dim productCSVURL = ""
            r = New Regex("product\.csv.*?href=""([^""]*?)""", RegexOptions.Singleline)
            s = (r.Match(HTMLText)).Groups(1).Value()
            ' 相対URL→絶対URLに変換
            For i = 0 To ie.Document.links.length
                If 1 <= InStr(ie.Document.links(i).href, s) Then
                    productCSVURL = ie.Document.links(i).href
                    Exit For
                End If
            Next


            ' --------------------------------------------------------
            msg = "order.csv のダウンロード" : l.write(msg)
            ' --------------------------------------------------------
            ie.Navigate(orderCSVURL)
            waitURLLoadComplete(ie)
            ' ファイル出力
            Dim sw As IO.StreamWriter = New IO.StreamWriter( _
                                        CSVsavePath & "\" & ORDER_CSV_NAME, _
                                        False, _
                                        System.Text.Encoding.Default _
                                        )
            ' 改行がスペースに変更されているため、スペースを改行に置換する
            sw.Write( _
                Regex.Replace( _
                    ie.Document.body.innerText(), _
                    """ (?<ORDERID>[0-9]+),""", _
                    """" & vbCrLf & "${ORDERID},""" _
                    ) _
                )
            sw.Close() : sw = Nothing


            ' --------------------------------------------------------
            msg = "product.csv のダウンロード" : l.write(msg)
            ' --------------------------------------------------------
            ie.Navigate(productCSVURL)
            waitURLLoadComplete(ie)
            ' ファイル出力
            sw = New IO.StreamWriter( _
                                        CSVsavePath & "\" & PRODUCT_CSV_NAME, _
                                        False, _
                                        System.Text.Encoding.Default _
                                        )
            ' 改行がスペースに変更されているため、スペースを改行に置換する
            sw.Write( _
                Regex.Replace( _
                    ie.Document.body.innerText(), _
                    " (?<ORDERID>[0-9]+),", _
                    vbCrLf & "${ORDERID}," _
                    ) _
                )
            sw.Close() : sw = Nothing


            ' --------------------------------------------------------
            msg = "MIME(application/msexcel)の削除" : l.write(msg)
            ' --------------------------------------------------------
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(MIME_EXCEL)



            ' --------------------------------------------------------
            msg = "CSVダウンロード終了" : l.write(msg)
            ' --------------------------------------------------------

        Catch ex As Exception
            rtnStatus = -1
            l.write(ex)
            l.write("HTMLダンプ：" & vbCrLf & ie.Document.body.innerHtml)

        Finally
            ' IE終了
            If Not (ie Is Nothing) Then
                ie.Quit() : ie = Nothing
            End If
            ' LOGクローズ
            If Not (l Is Nothing) Then
                l.close() : l = Nothing
            End If

        End Try

        ' 終了ステータスの返却
        Return rtnStatus

    End Function
End Class
