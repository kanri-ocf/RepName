Imports System.Text

Public Class cEncode

    Private enc As Encoding

    Public Sub New(ByVal encStr As String)
        enc = Encoding.GetEncoding(encStr)
    End Sub

    Public Function Encode(ByVal str As String) As String
        Return Convert.ToBase64String(enc.GetBytes(str))
    End Function

    Public Function Decode(ByVal str As String) As String
        Return enc.GetString(Convert.FromBase64String(str))
    End Function

End Class
