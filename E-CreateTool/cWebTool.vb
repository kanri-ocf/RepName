Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO

Public Class cWebTool

    Private Const SLEEP_MSEC As Integer = 2000
    Private Shared random As New System.Random()

    Public Shared bgWorker As System.ComponentModel.BackgroundWorker


    '' スレッドを分けた形でWeb操作プログラムを実行する場合において強制終了メッセージ伝達に使用
    'Private Shared _abortThread As Boolean = False
    'Public Shared Property abortThread() As Boolean
    '    Get
    '        Return _abortThread
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _abortThread = value
    '    End Set
    'End Property

    Public Shared Function isCancellationPending() As Boolean
        Dim result As Boolean = False
        If bgWorker IsNot Nothing Then
            If bgWorker.CancellationPending Then
                result = bgWorker.CancellationPending
            End If
        End If
        Return result
    End Function

    Public Shared Sub setListFromCSV( _
        ByVal path As String, ByVal fileName As String, ByVal fieldName As String, ByRef fieldValues As List(Of String))
        Dim tfp As TextFieldParser = Nothing
        Try
            tfp = New TextFieldParser(path & "\" & fileName, System.Text.Encoding.Default)
            tfp.TextFieldType = FileIO.FieldType.Delimited
            tfp.SetDelimiters(",")
            tfp.HasFieldsEnclosedInQuotes = True
            tfp.TrimWhiteSpace = True
            If Not tfp.EndOfData Then
                Dim fieldPosInfo As New Hashtable
                Dim fieldNames As String() = tfp.ReadFields()
                For i = 0 To fieldNames.Length - 1
                    fieldPosInfo.Add(fieldNames(i), i)
                Next
                While Not tfp.EndOfData
                    Dim row As String() = tfp.ReadFields()
                    fieldValues.Add(row(CInt(fieldPosInfo(fieldName))))
                End While
            End If
        Finally
            If tfp IsNot Nothing Then
                tfp.Close() : tfp = Nothing
            End If
        End Try
    End Sub

    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

    Public Shared Function getRandomNumber() As Integer
        Return random.Next()
    End Function

    Public Shared Function getAbsoluteUrl(ByVal baseUrl As String, ByVal relativeUrl As String) As String
        Dim u As Uri = New Uri(New Uri(baseUrl), relativeUrl)
        Return u.AbsoluteUri
    End Function

    Public Shared Function isCSV(ByVal CSVsavePath As String, ByVal fileName As String, ByVal pattern As String) As Boolean
        Dim sr As System.IO.StreamReader = Nothing
        Dim result As Boolean = False
        Try
            sr = New System.IO.StreamReader(CSVsavePath & "\" & fileName, System.Text.Encoding.Default)
            If Regex.IsMatch(sr.ReadLine(), pattern) Then
                result = True
            End If
        Catch
            result = False
        Finally
            If sr IsNot Nothing Then
                sr.Close() : sr = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Sub backUp(ByVal CSVsavePath As String, ByVal fileName As String)
        Dim prefix As String = Regex.Replace(fileName, "\.csv", "")
        Dim backupPath As String = Application.StartupPath & "\Net\BackUp"
        ' 翌日分のバックアップを削除(バックアップ保持期間を1ヶ月とする為)
        For Each fn As String In System.IO.Directory.GetFiles(backupPath, prefix & "*.csv")
            If Regex.IsMatch(fn, prefix & "[0-9]{4}[0-9]{2}" & Now.AddDays(1).ToString("dd") & "-") Then
                System.IO.File.Delete(fn)
            End If
        Next
        System.IO.File.Copy( _
            CSVsavePath & "\" & fileName, _
            backupPath & "\" & prefix & Now.ToString("yyyyMMdd-HHmmss") & ".csv", _
            True _
            )
    End Sub

    Public Shared Sub dump(ByRef xh As MSXML2.XMLHTTP60)
        Console.Write(xh.responseText)
    End Sub

    Public Shared Sub sleep(ByRef xh As MSXML2.XMLHTTP60)
        While (xh.readyState <> 4)
            xh.waitForResponse(SLEEP_MSEC)
        End While
    End Sub

    Public Shared Sub releaseCOM(Of T As Class) _
          (ByRef objCom As T, Optional ByVal force As Boolean = False)
        If objCom Is Nothing Then
            Return
        End If
        Try
            If System.Runtime.InteropServices.Marshal.IsComObject(objCom) Then
                If force Then
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objCom)
                Else
                    Dim count As Integer = System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)
                    If count > 0 Then
                        Debug.Print(count.ToString())
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objCom)
                    End If
                End If
            End If
        Finally
            objCom = Nothing
        End Try
    End Sub

    'Private Function guess_charset(ByRef xh As MSXML2.XMLHTTP60) As String
    '    Dim r As Regex
    '    Dim result As String
    '    r = New Regex( _
    '        "Content-Type:.*?charset=(EUC-JP)" & vbCrLf , _
    '        RegexOptions.Singleline _
    '        )
    '    result = r.Match(html).Groups(1).Value()

    '    Return result
    'End Function

End Class
