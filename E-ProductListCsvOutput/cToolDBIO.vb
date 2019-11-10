Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class cToolDBIO
    Public Function argCal( _
                        ByRef pc As Integer, _
                        ByRef maxpc As Integer, _
                        ByRef arg1 As String, _
                        ByRef arg2 As String, _
                        ByRef arg3 As String, _
                        ByRef arg4 As String, _
                        ByRef arg5 As String, _
                        ByRef arg6 As String, _
                        ByRef arg7 As String, _
                        ByRef arg8 As String, _
                        ByRef arg9 As String, _
                        ByRef arg10 As String, _
                        ByRef arg11 As String _
                        ) As Boolean

        '***********************
        '   パラメータの設定
        '***********************

        'パラメータ数のカウント
        pc = 0
        If arg1 <> Nothing Then
            maxpc = 1
            pc = pc Or maxpc
        End If

        If arg2 <> Nothing Then
            maxpc = 2
            pc = pc Or maxpc
        End If

        If arg3 <> Nothing Then
            maxpc = 4
            pc = pc Or maxpc
        End If

        If arg4 <> Nothing Then
            maxpc = 8
            pc = pc Or maxpc
        End If

        If arg5 <> Nothing Then
            maxpc = 16
            pc = pc Or maxpc
        End If

        If arg6 <> Nothing Then
            maxpc = 32
            pc = pc Or maxpc
        End If

        If arg7 <> Nothing Then
            maxpc = 64
            pc = pc Or maxpc
        End If

        If arg8 <> Nothing Then
            maxpc = 128
            pc = pc Or maxpc
        End If

        If arg9 <> Nothing Then
            maxpc = 256
            pc = pc Or maxpc
        End If

        If arg10 <> Nothing Then
            maxpc = 512
            pc = pc Or maxpc
        End If
        If arg11 <> Nothing Then
            maxpc = 1024
            pc = pc Or maxpc
        End If
    End Function
End Class