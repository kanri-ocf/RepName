Public Class fBomMain

    Private Sub fBomMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oBomMst = New cMasterMenteLib.fBomMst

        Me.Visible = False
        oBomMst.ShowDialog()
        Me.Dispose()

    End Sub
End Class