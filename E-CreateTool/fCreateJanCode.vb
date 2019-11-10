Public Class fCreateJanCode

    Private oTool As New cTool
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ANY_CODE_T.Text <> Nothing Then
            JAN_CODE_T.Text = oTool.JANCD(String.Format("{0:000000000000}", CLng(ANY_CODE_T.Text)))
        End If
    End Sub
End Class