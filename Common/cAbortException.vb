Option Strict On           'プロジェクトのプロパティで設定可能

'--------------- 例外クラス--------------- 
Public Class cAbortException
    Inherits ApplicationException

    Public Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub

End Class
