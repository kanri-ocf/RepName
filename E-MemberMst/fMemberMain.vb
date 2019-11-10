Public Class fMemberMain

    Private Sub fMemberMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oMemberMst = New cMasterMenteLib.fMemberMst

        Me.Visible = False
        oMemberMst.ShowDialog()
        oMemberMst = Nothing
        Me.Close()
        Me.Dispose()

    End Sub
End Class
