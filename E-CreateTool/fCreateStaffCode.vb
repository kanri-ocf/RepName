Public Class fCreateStaffCode

    Private oTool As New cTool
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If SYAIN_CODE_T.Text <> Nothing Then
            STAFF_CODE_T.Text = oTool.JANCD("9901" & String.Format("{0:00000000}", CLng(SYAIN_CODE_T.Text)))
        End If
    End Sub
End Class