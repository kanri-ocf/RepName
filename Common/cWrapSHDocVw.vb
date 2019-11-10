Imports System.Text.RegularExpressions
Imports SHDocVw

Public Class cWrapSHDocVw
    Implements IDisposable

    Private Const SLEEP_MSEC As Integer = 2000

    Private NavigateCompleteFlag As Boolean = False
    Private LogSavePath As String
    Private programName As String
    Private programStartTime As Date


    ' COM関連オブジェクト
    Private ie As SHDocVw.InternetExplorer = Nothing
    Private wb As IWebBrowserApp = Nothing
    Private HTMLDoc As mshtml.HTMLDocument
    Private HTMLCollection As mshtml.IHTMLElementCollection
    Private element As mshtml.IHTMLElement = Nothing
    Private body As mshtml.IHTMLElement
    Private HTMLFormElements As mshtml.HTMLFormElementClass


    Public Sub New( _
        ByVal LogSavePath As String, _
        ByVal programName As String _
        )
        Me.LogSavePath = LogSavePath
        Me.programName = programName
        Me.ie = New SHDocVw.InternetExplorer()
        SetAllEvents()
        Me.wb = CType(Me.ie, IWebBrowserApp)
        ' DEBUG用
        'wb.Visible = True
    End Sub

    Private Sub sleep()
        While (NavigateCompleteFlag = False)
            System.Threading.Thread.Sleep(SLEEP_MSEC)
        End While

        If cWebTool.isCancellationPending Then Throw New cAbortException("ユーザーにより終了されました")

        ' バグと思われるが、上記だけではhtmlページの読込が完了していない場合があるため、2重にhtmlページ読込完了を確認する
        While ie.Busy Or ie.ReadyState <> tagREADYSTATE.READYSTATE_COMPLETE
            System.Threading.Thread.Sleep(SLEEP_MSEC)
        End While

        If cWebTool.isCancellationPending Then Throw New cAbortException("ユーザーにより終了されました")
    End Sub

    Public Function getResponseText() As String
        HTMLDoc = wb.Document
        body = HTMLDoc.body
        Dim html As String = body.innerHTML
        html = Regex.Replace(html, "<!--(.*?)-->", "")
        Return html
    End Function

    Public Function getTitle() As String
        Return wb.LocationName
    End Function

    Public Sub submit(ByVal seq As String)
        Dim s As String = "request action is submit:" & vbCrLf
        try
	        s += "seq--> " & seq & vbCrLf

	        HTMLDoc = wb.Document
	        HTMLCollection = HTMLDoc.getElementsByTagName("input")
	        For Each Me.element In HTMLCollection
	            If element.type = "submit" Then
	                element.click()
	                sleep()
	                Exit For
	            End If
	        Next

	        s += vbCrLf & "return url:" & vbCrLf & wb.LocationURL & vbCrLf
	        s += vbCrLf & "return page title:" & vbCrLf & wb.LocationName & vbCrLf
	        s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub followLinkByText(ByVal seq As String, ByVal text As String)
        Dim s As String = "request action is follow link:" & vbCrLf
        try
	        s += "seq--> " & seq & vbCrLf
	        s += "link name pattern--> " & text & vbCrLf

	        Dim url As String = ""
	        HTMLDoc = wb.Document
	        HTMLCollection = HTMLDoc.getElementsByTagName("a")
	        For Each Me.element In HTMLCollection
	            If element.innerText = text Then
	                url = element.href
	                wb.Navigate(url)
	                sleep()
	                Exit For
	            End If
	        Next

	        s += vbCrLf & "return url:" & vbCrLf & wb.LocationURL & vbCrLf
	        s += vbCrLf & "return page title:" & vbCrLf & wb.LocationName & vbCrLf
	        s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub followLinkByTextRegex(ByVal seq As String, ByVal pattern As String)
        Dim s As String = "request action is follow link by Regex:" & vbCrLf
        try
	        s += "seq--> " & seq & vbCrLf
	        s += "link name pattern--> " & pattern & vbCrLf

	        Dim url As String = ""
	        HTMLDoc = wb.Document
	        HTMLCollection = HTMLDoc.getElementsByTagName("a")
	        For Each Me.element In HTMLCollection
	            If Regex.IsMatch(element.innerText, pattern) Then
	                Console.WriteLine("click link name:")
	                Console.WriteLine(element.innerText)
	                url = element.href
	                wb.Navigate(url)
	                sleep()
	                Exit For
	            End If
	        Next

	        s += vbCrLf & "return url:" & vbCrLf & wb.LocationURL & vbCrLf
	        s += vbCrLf & "return page title:" & vbCrLf & wb.LocationName & vbCrLf
	        s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub clickButton(ByVal seq As String, ByVal buttonName As String)
        Dim s As String = "request action is click button:" & vbCrLf
        try
	        s += "seq--> " & seq & vbCrLf
	        s += "button name--> " & buttonName & vbCrLf

	        Dim result As Boolean = False
	        HTMLDoc = wb.Document
	        HTMLCollection = HTMLDoc.getElementsByTagName("input")
	        For Each Me.element In HTMLCollection
	            Select Case element.type
	                Case "image"
	                    If Trim(element.alt) = buttonName Then
	                        element.click()
	                        sleep()
	                        Exit For
	                    End If
	                Case Else
	                    If Trim(element.value) = buttonName Then
	                        element.click()
	                        sleep()
	                        Exit For
	                    End If
	            End Select
	        Next

	        s += vbCrLf & "return url:" & vbCrLf & wb.LocationURL & vbCrLf
	        s += vbCrLf & "return page title:" & vbCrLf & wb.LocationName & vbCrLf
	        s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub sendGet(ByVal seq As String, ByVal url As String)
        Dim s As String = "request action is http GET:" & vbCrLf
        try
	        s += "seq--> " & seq & vbCrLf
	        s += "request url--> " & url & vbCrLf

	        wb.Navigate(url)
	        sleep()

	        s += vbCrLf & "return url:" & vbCrLf & wb.LocationURL & vbCrLf
	        s += vbCrLf & "return page title:" & vbCrLf & wb.LocationName & vbCrLf
	        s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub setFieldValue(ByVal fieldName As String, ByVal fieldValue As String)
        Dim isExist As Boolean = False
        HTMLDoc = wb.Document
        HTMLCollection = HTMLDoc.getElementsByTagName("input")
        For Each Me.element In HTMLCollection
            If element.name = fieldName Then
                isExist = True
                Exit For
            End If
        Next
        If Not isExist Then
            HTMLCollection = HTMLDoc.getElementsByTagName("textarea")
            For Each Me.element In HTMLCollection
                If element.name = fieldName Then
                    isExist = True
                    Exit For
                End If
            Next
        End If

        If isExist Then
            element.value = fieldValue
        End If
    End Sub

    Public Function getFieldValue(ByVal fieldName As String) As String
        Dim isExist As Boolean = False
        Dim result As String = ""
        HTMLDoc = wb.Document
        HTMLCollection = HTMLDoc.getElementsByTagName("input")
        For Each Me.element In HTMLCollection
            If element.name = fieldName Then
                isExist = True
                Exit For
            End If
        Next
        If Not isExist Then
            HTMLCollection = HTMLDoc.getElementsByTagName("textarea")
            For Each Me.element In HTMLCollection
                If element.name = fieldName Then
                    isExist = True
                    Exit For
                End If
            Next
        End If

        If isExist Then
            result = element.value()
        End If
        Return result
    End Function

    ' 確認ダイアログの非表示化＋確認ダイアログのOKボタンの自動押下
    'Public Sub setAutoOKConfirmDialogBox()
    '    element = wb.Document.createElement("SCRIPT")
    '    element.Type = "text/javascript"
    '    element.Text = "function confirm() { return true; }"
    '    wb.Document.body.appendChild(element)
    'End Sub

    ' 確認ダイアログの非表示化＋確認ダイアログのOKボタンの自動押下(javascript：confirm関数を書換え)
    Public Sub setAutoOKConfirmDialogBox()
        HTMLDoc = wb.Document
        element = HTMLDoc.createElement("SCRIPT")
        element.Type = "text/javascript"
        element.Text = "function confirm() { return true; }"
        body = HTMLDoc.body
        body.appendChild(element)
    End Sub

    Public Function getFullDumpFilePath() As String
        Return LogSavePath & "\Dump\" & programName & programStartTime.ToString("yyyyMMdd-HHmmss") & ".dmp"
    End Function

    Public Function writeHistory(ByRef history As String) As String
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

    Public Sub setSEOTag(ByVal fieldName As String, ByVal fieldValueMaxByteSize As Integer)
        Dim filedValue As String = getFieldValue(fieldName)
        If Not ((filedValue Is Nothing) Or (filedValue = "")) Then
            If Not Regex.IsMatch(filedValue, "<FONT COLOR=""WHITE"">TAG#[0-9]+</FONT>") Then
                filedValue &= "<FONT COLOR=""WHITE"">TAG#" & cWebTool.getRandomNumber().ToString & "</FONT>"
            Else
                filedValue = Regex.Replace(filedValue, _
                                      "<FONT COLOR=""WHITE"">TAG#[0-9]+</FONT>", _
                                      "<FONT COLOR=""WHITE"">TAG#" & cWebTool.getRandomNumber().ToString & "</FONT>")
            End If
            If cWebTool.LenB(filedValue) <= fieldValueMaxByteSize Then
                setFieldValue(fieldName, filedValue)
            End If
        End If
    End Sub

    Private Sub SetAllEvents()
        If Not (ie Is Nothing) Then
            Dim BeforeNavigateE As DWebBrowserEvents2_BeforeNavigate2EventHandler = New DWebBrowserEvents2_BeforeNavigate2EventHandler(AddressOf OnBeforeNavigate)
            AddHandler ie.BeforeNavigate2, AddressOf OnBeforeNavigate

            Dim DTitleChangeE As DWebBrowserEvents2_TitleChangeEventHandler = New DWebBrowserEvents2_TitleChangeEventHandler(AddressOf OnTitleChange)
            AddHandler ie.TitleChange, DTitleChangeE

            Dim NavigateCompleteE As DWebBrowserEvents2_NavigateComplete2EventHandler = New DWebBrowserEvents2_NavigateComplete2EventHandler(AddressOf OnNavigateComplete)
            AddHandler ie.NavigateComplete2, AddressOf OnNavigateComplete

            Dim NavigateErrorE As DWebBrowserEvents2_NavigateErrorEventHandler = New DWebBrowserEvents2_NavigateErrorEventHandler(AddressOf NavigateError)
            AddHandler ie.NavigateError, AddressOf NavigateError
        End If
    End Sub

    '----------------------------------------------------------------
    ' イベントハンドラ
    Public Sub OnBeforeNavigate(ByVal pDisp As Object, ByRef URL As Object, ByRef Flags As Object, ByRef TargetFrameName As Object, _
                                ByRef PostData As Object, ByRef Headers As Object, ByRef Cancel As Boolean)
        Console.WriteLine("OnBeforeNavigate")
        NavigateCompleteFlag = False
    End Sub

    Public Sub OnTitleChange(ByVal sText As String)
        Console.WriteLine("Title changes to {0}", sText)
    End Sub

    Public Sub OnNavigateComplete(ByVal o1 As Object, ByRef o2 As Object)
        Console.WriteLine("OnNavigateComplete")
        NavigateCompleteFlag = True
    End Sub

    Public Sub NavigateError(ByVal pDisp As Object, ByRef URL As Object, ByRef Frame As Object, _
                             ByRef StatusCode As Object, ByRef Cancel As Boolean)
        Console.WriteLine("NavigateError")
    End Sub


    Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 他の状態を解放します (マネージ オブジェクト)。
            End If

            ' TODO: ユーザー独自の状態を解放します (アンマネージ オブジェクト)。
            ' TODO: 大きなフィールドを null に設定します。

            ' COMオブジェクトの開放
            wb.Quit() : cWebTool.releaseCOM(wb, True) : wb = Nothing
            cWebTool.releaseCOM(ie, True) : ie = Nothing
            cWebTool.releaseCOM(HTMLDoc, True) : HTMLDoc = Nothing
            cWebTool.releaseCOM(HTMLCollection, True) : HTMLCollection = Nothing
            cWebTool.releaseCOM(element, True) : element = Nothing
            cWebTool.releaseCOM(body, True) : body = Nothing
            cWebTool.releaseCOM(HTMLFormElements, True) : HTMLFormElements = Nothing

        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class


