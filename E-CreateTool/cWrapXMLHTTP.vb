Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Public Class cWrapXMLHTTP
    Implements IDisposable

    Private xh As MSXML2.XMLHTTP60
    Private LogSavePath As String
    Private programName As String
    Private programStartTime As Date

    Public Sub New( _
        ByVal LogSavePath As String, _
        ByVal programName As String _
        )
        Me.LogSavePath = LogSavePath
        Me.programName = programName
        Me.xh = New MSXML2.XMLHTTP60
        Me.programStartTime = Now
    End Sub

    Public Sub setRequestHeaders()
        xh.setRequestHeader("Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-ms-application, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-ms-xbap, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*")
        xh.setRequestHeader("Accept-Language", "ja")
        xh.setRequestHeader("UA-CPU", "x86")
        xh.setRequestHeader("Accept-Encoding", "gzip, deflate")
        xh.setRequestHeader("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; YTB720; SLCC1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.5.30729; .NET CLR 3.0.30618; .NET4.0C)")
        xh.setRequestHeader("Connection", "Keep-Alive")
    End Sub

    Public Function getResponseText() As String
        Dim html As String = xh.responseText()
        html = Regex.Replace(html, "<!--(.*?)-->", "")
        Return html
    End Function

    Public Sub sendGet(ByVal seq As String, ByVal url As String, ByVal referer As String)
        Dim s As String = "http GET:" & vbCrLf
        Try
            s += "seq--> " & seq & vbCrLf
            s += "referer--> " & referer & vbCrLf
            s += "request url--> " & url & vbCrLf

            xh.open("GET", url, False)
            setRequestHeaders()
            If referer <> Nothing Then
                xh.setRequestHeader("Referer", referer)
            End If
            xh.send()
            cWebTool.sleep(xh)

            s += vbCrLf & "return response Headers:" & vbCrLf & xh.getAllResponseHeaders & vbCrLf
            s += vbCrLf & "return html:" & vbCrLf & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub sendGetImage(ByVal seq As String, ByVal url As String, ByVal referer As String)
        Dim s As String = "http GET(Image):" & vbCrLf
        Try
            s += "seq--> " & seq & vbCrLf
            s += "referer--> " & referer & vbCrLf
            s += "request url--> " & url & vbCrLf

            xh.open("GET", url, False)
            setRequestHeaders()
            If referer <> Nothing Then
                xh.setRequestHeader("Referer", referer)
            End If
            xh.setRequestHeader("Accept", "image/png,image/*;q=0.8,*/*;q=0.5")
            xh.send()
            cWebTool.sleep(xh)

            s += vbCrLf & "return response Headers:" & vbCrLf & xh.getAllResponseHeaders & vbCrLf
            s += vbCrLf & "return html:" & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub sendPost( _
            ByVal seq As String, _
            ByVal url As String, _
            ByVal referer As String, _
            ByVal pText As String _
            )

        Dim s As String = "http POST:" & vbCrLf
        Try
            s += "seq--> " & seq & vbCrLf
            s += "referer--> " & referer & vbCrLf
            s += "request url--> " & url & vbCrLf
            s += "pText--> " & pText & vbCrLf

            xh.open("POST", url, False)
            setRequestHeaders()
            xh.setRequestHeader("Referer", referer)
            xh.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            xh.setRequestHeader("Content-Length", pText.Length)
            xh.send(pText)
            cWebTool.sleep(xh)

            s += vbCrLf & "return response Headers:" & vbCrLf & xh.getAllResponseHeaders & vbCrLf
            s += vbCrLf & "return html:" & getResponseText()
        Finally
            writeHistory(s)
        End Try
    End Sub

    Public Sub downloadCSV(ByVal CSVsavePath As String, ByVal fileName As String)
        Dim s As ADODB.Stream = Nothing
        Try
            s = New ADODB.Stream
            s.Type = ADODB.StreamTypeEnum.adTypeBinary
            s.Open()
            s.Write(xh.responseBody)
            s.SaveToFile(CSVsavePath & "\" & fileName, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
        Finally
            If s IsNot Nothing Then
                s.Close()
                cWebTool.releaseCOM(s, True)
                s = Nothing
            End If
        End Try
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

    Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 他の状態を解放します (マネージ オブジェクト)。
            End If

            ' TODO: ユーザー独自の状態を解放します (アンマネージ オブジェクト)。
            ' TODO: 大きなフィールドを null に設定します。
            cWebTool.releaseCOM(Me.xh, True) : Me.xh = Nothing

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
