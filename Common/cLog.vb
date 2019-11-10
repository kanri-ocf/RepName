Option Explicit On

Imports System.IO
Imports System.Text

Public Class cLog

    Private saveDirPath As String
    Private logPrefix As String
    Private sWriter As StreamWriter
    Private sTWTListener As TextWriterTraceListener

    Public Sub New( _
                ByVal saveDirPath As String, _
                ByVal logPrefix As String _
                )
        Me.saveDirPath = saveDirPath
        Me.logPrefix = logPrefix
    End Sub

    Private Sub delete()
        '翌日分のログファイルを削除(ログファイルの保持期間を1ヶ月とする為)
        If System.IO.File.Exists(Me.saveDirPath & "\" & Me.logPrefix & Now.AddDays(1).ToString("dd") & ".log") = True Then
            System.IO.File.Delete(Me.saveDirPath & "\" & Me.logPrefix & Now.AddDays(1).ToString("dd") & ".log")
        End If
    End Sub

    Public Sub open()
        delete()
        Me.sWriter = New StreamWriter( _
            Me.saveDirPath & "\" & Me.logPrefix & Now.ToString("dd") & ".log", _
            True, _
            Encoding.GetEncoding("Shift_JIS"))
        Me.sWriter.AutoFlush = True
        Me.sTWTListener = New TextWriterTraceListener(TextWriter.Synchronized(Me.sWriter), "LogFile")
        Trace.Listeners.Add(Me.sTWTListener)
    End Sub

    Public Sub close()
        Me.sTWTListener.Close() : Me.sTWTListener = Nothing
        Me.sWriter.Close() : Me.sWriter = Nothing
    End Sub

    Public Sub write(ByVal msg As String)
        Me.sTWTListener.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & vbTab & msg)
    End Sub

    Public Sub write(ByVal msg As String, ByRef ex As Exception)
        write(msg)
        Me.sTWTListener.WriteLine("   " & ex.ToString)
    End Sub

    Public Sub write(ByRef ex As Exception)
        write("例外発生：")
        Me.sTWTListener.WriteLine("   " & ex.ToString)
    End Sub

End Class
