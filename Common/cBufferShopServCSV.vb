Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Guid
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Text
Imports SHDocVw

Public Class cBufferShopServCSV

    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" _
      (ByVal hWnd1 As IntPtr, ByVal hWnd2 As IntPtr, _
       ByVal lpsz1 As String, ByVal lpsz2 As String) As IntPtr
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As IntPtr, ByVal wMsg As IntPtr, _
         ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
    Private Declare Function AccessibleObjectFromWindow Lib "oleacc" _
        (ByVal hWnd As IntPtr, ByVal dwId As IntPtr, _
        ByRef riid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObject As Object) As IntPtr
    'Declare Function AccessibleChildren Lib "oleacc" _
    '    (ByVal paccContainer As IAccessible, ByVal iChildStart As IntPtr, _
    '    ByVal cChildren As IntPtr, <[Out]()> ByVal rgvarChildren() As Object, ByRef pcObtained As IntPtr) As IntPtr

    Private Const WM_ACTIVATE = &H6
    Private Const BM_CLICK = &HF5
    Private Const WM_GETTEXT = &HD
    Private Const WM_QUIT = &H10

    Private Const NAVDIR_NEXT = &H5
    Private Const NAVDIR_FIRSTCHILD = &H7
    Private Const CHILDID_SELF = &H0
    Private Const OBJID_CLIENT = &HFFFFFFFC

    Private Const START_URL As String = "https://kanri.shopserve.jp/"
    Private Const MNG_URL As String = "https://kanri1.shopserve.jp/"
    Private Const ORDER_CSV_NAME As String = "ShopServ_Order.csv"
    Private Const PROGRAM_NAME As String = "shopServ"
    Private Const CHARSET As String = "EUC-JP"
    Private Const SLEEP_MSEC As Integer = 3000
    Private Const LOG_PREFIX As String = "shopServ"
    Private Const MIME_EXCEL As String = "MIME\Database\Content Type\application/msexcel"
    Private Const CLSID_IE As String = "{25336920-03F9-11cf-8FD0-00AA00686F13}"

    Private Const GET_DAYS As Integer = -7

    Private businessID As String
    Private businessPass As String
    Private CSVsavePath As String
    Private programStartTime As Date
    Private pBrowser As System.Windows.Forms.WebBrowser

    Private Function getFullDumpFilePath() As String
        Return Application.StartupPath & "\Net" & "\Dump\" & LOG_PREFIX & programStartTime.ToString("yyyyMMdd-HHmmss") & ".dmp"
    End Function
    Public Sub New( _
                ByRef Browser As System.Windows.Forms.WebBrowser, _
                ByVal businessID As String, _
                ByVal businessPass As String, _
                ByVal CSVsavePath As String _
                )
        Me.pBrowser = Browser
        Me.businessID = businessID
        Me.businessPass = businessPass
        Me.CSVsavePath = CSVsavePath
    End Sub
    Private Function writeHistory(ByRef history As String) As String
        Dim sw As System.IO.StreamWriter = Nothing
        Dim path As String = getFullDumpFilePath()
        Try
            sw = New IO.StreamWriter(path, True, System.Text.Encoding.Default)
            sw.WriteLine("######################################################################################")
            sw.WriteLine("######################################################################################")
            sw.WriteLine("######################################################################################")
            sw.WriteLine(history)
        Finally
            If sw IsNot Nothing Then
                sw.Close() : sw = Nothing
            End If
        End Try
        Return path
    End Function
    Private Sub sleep(ByVal seq As String, ByRef ie As SHDocVw.InternetExplorer)
        While ie.Busy Or (ie.ReadyState <> SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            System.Threading.Thread.Sleep(SLEEP_MSEC)
        End While

    End Sub

    Public Function download() As Integer
        Dim rtnStatus As Integer = 0

        Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        Dim msg As String = ""
        Dim html As String = ""
        Dim url As String = ""
        'Dim referer As String
        'Dim r As Regex
        'Dim params As List(Of String)
        'Dim pText As String
        Dim fromYMDs As New List(Of String)

        Dim ie As Object
        Dim WScript As Object
        Dim wxh As New cWrapXMLHTTP(Application.StartupPath & "\Net", PROGRAM_NAME)
        Dim HTMLText As String

        Try
            ' LOGオープン
            l.open()

            'オブジェクトを作成
            ie = CreateObject("InternetExplorer.Application")
            WScript = CreateObject("Wscript.Shell")

            answer_on_next_prompt(ie, "プロンプトにこの文章で応答します。", WScript)

            ' デバッグコード(運用時は削除)
            ie.Visible = True

            ' --------------------------------------------------------
            msg = "CSVダウンロード開始" : l.write(msg)
            ' --------------------------------------------------------

            '' --------------------------------------------------------
            'msg = "MIME(application/msexcel)の追加"
            '' --------------------------------------------------------
            '' MIME設定によりCSVダウンロード先をIE画面にする(ダウンロードダイアログ表示を回避するため)
            'If Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(MIME_EXCEL, False) Is Nothing Then
            '    Dim regkey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(MIME_EXCEL)
            '    regkey.SetValue("CLSID", CLSID_IE, Microsoft.Win32.RegistryValueKind.String)
            '    regkey.SetValue("Extension", ".csv", Microsoft.Win32.RegistryValueKind.String)
            '    regkey.Close() : regkey = Nothing
            'End If

            ' --------------------------------------------------------
            msg = "開始ページを読込" : l.write(msg)
            ' --------------------------------------------------------
            ie.Navigate(START_URL)
            pBrowser.Navigate(START_URL)
            sleep("010", ie)

            ' --------------------------------------------------------
            msg = "Login認証" : l.write(msg)
            ' -------------------------------------------------------- 
            ie.Document.ENTER.USERNAME.value = Me.businessID
            ie.Document.ENTER.PASSWD.value = Me.businessPass
            ie.Document.Script.setTimeOut("loginsetup();return false;", 20)
            sleep("020", ie)


            ' --------------------------------------------------------
            msg = "リンク(受注処理>受注台帳>受注台帳をみる)先へ遷移" : l.write(msg)
            ' --------------------------------------------------------
            ie.Navigate(MNG_URL & Me.businessID & "/func01/orderlist.cgi")
            sleep("030", ie)

            ie.Navigate(MNG_URL & Me.businessID & "/func01/orderlist.cgi")
            sleep("030", ie)

            ' --------------------------------------------------------
            msg = "新しい受注を確認する" : l.write(msg)
            ' --------------------------------------------------------
            ie.Document.all("topopup").Click()
            sleep("040", ie)

            ' --------------------------------------------------------
            msg = "表示件数を100件に設定" : l.write(msg)
            ' --------------------------------------------------------
            'ie.Document.all("list").item("range").selectedIndex = 6

            ' --------------------------------------------------------
            msg = "全選択" : l.write(msg)
            ' --------------------------------------------------------
            ie.Document.all("Submit_btn")(0).Click()
            sleep("050", ie)

            ' --------------------------------------------------------
            msg = "CSVダウンロード" : l.write(msg)
            ' --------------------------------------------------------
            ie.Document.all("Submit_btn")(8).Click()
            sleep("060", ie)


            ' CSVダウンロード
            HTMLText = ie.Document.body.innerHtml

            wxh.downloadCSV(CSVsavePath, ORDER_CSV_NAME)

            ' CSVバックアップ
            cWebTool.backUp(CSVsavePath, ORDER_CSV_NAME)

            ' CSV内容確認
            If Not (cWebTool.isCSV(CSVsavePath, ORDER_CSV_NAME, "^""受注番号"",")) Then
                System.IO.File.Delete(CSVsavePath & "\" & ORDER_CSV_NAME)
                Throw New Exception("CSVファイルの内容が正しくないため削除しました。")
            End If

            '' --------------------------------------------------------
            'msg = "MIME(application/msexcel)の削除"
            '' --------------------------------------------------------
            'Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(MIME_EXCEL)

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
    Private Sub execute_bookmarklet(ByRef ie As Object, ByVal func As String, ByRef WScript As Object)
        Dim str_address_bar As String = "javascript:(" & func.ToString() & ")();void(0)"

        ie.Navigate(str_address_bar)
        WScript.Sleep(1000)
    End Sub


    Private Sub answer_on_next_prompt(ByRef ie As Object, ByVal str As String, ByRef WScript As Object)
        ' prompt関数を上書きする
        execute_bookmarklet(ie, "new Function(window.prompt = function(){ return '" & str & """'; };"")", WScript)

    End Sub

    'Sub FileDownLoad_Proc()
    '    Dim strCaption As String
    '    Dim PWnd As IntPtr
    '    Dim cWnd As IntPtr
    '    Dim IID_IAccessible As Guid

    '    IID_IAccessible = New System.Guid

    '    ' 親ウィンドウ取得
    '    strCaption = "Ｅストアーショップサーブ管理画面 - Internet Explorer"
    '    While PWnd = 0
    '        PWnd = FindWindowEx(0, 0, "IEFrame", strCaption)
    '        System.Threading.Thread.Sleep(50)
    '    End While

    '    ' 通知バーのハンドル
    '    While cWnd = 0
    '        cWnd = FindWindowEx(PWnd, 0&, "Frame Notification Bar", vbNullString)
    '        System.Threading.Thread.Sleep(50)
    '    End While

    '    ' 通知バーボタン群のハンドル
    '    Dim hChild As IntPtr = FindWindowEx(cWnd, 0&, "DirectUIHWND", vbNullString)
    '    'Dim objAcc As IAccessible = Nothing

    '    AccessibleObjectFromWindow(hChild, OBJID_CLIENT, IID_IAccessible, objAcc)

    '    If Not IsNothing(objAcc) Then
    '        ClickPreserve(objAcc)
    '        While cWnd = 0
    '            cWnd = FindWindowEx(PWnd, 0&, "Frame Notification Bar", vbNullString)
    '            System.Threading.Thread.Sleep(50)
    '        End While
    '        SendMessage(cWnd, WM_QUIT, 0, 0&)

    '    End If

    'End Sub
    'Private Sub ClickPreserve(ByVal acc As IAccessible)

    '    Dim i As Long
    '    Dim count = acc.accChildCount
    '    Dim lst(count - 1) As Object

    '    If count > 0 Then
    '        AccessibleChildren(acc, 0, count, lst, 0)
    '        If Not IsNothing(lst) Then
    '            For i = LBound(lst) To UBound(lst)
    '                With lst(i)
    '                    'On Error Resume Next
    '                    'Debug.Print("ChildCount: " & .accChildCount)
    '                    'Debug.Print("Value: " & .accValue(CHILDID_SELF))
    '                    'Debug.Print("Name: " & .accName(CHILDID_SELF))
    '                    'Debug.Print("Description: " & .accDescription(CHILDID_SELF))
    '                    'On Error GoTo 0
    '                    '保存ボタンを見つけたらクリック（デフォルトアクション）する
    '                    If .accName(CHILDID_SELF) = "保存" Then

    '                        System.Threading.Thread.Sleep(500)
    '                        .accDoDefaultAction(CHILDID_SELF)
    '                        System.Threading.Thread.Sleep(500)
    '                    End If
    '                End With
    '                ClickPreserve(lst(i)) '再帰
    '            Next
    '        End If
    '    End If
    'End Sub

End Class
