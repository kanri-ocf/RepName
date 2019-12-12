Public Class fProductMain

    Private Sub fProductMain_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PRODUCT_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRODUCT_B.Click
        '2019.12.8 R.Takashima
        'スペルミスの修正
        'Dim oPrpductMst = New cMasterMenteLib.fProductMst
        Dim oProductMst = New cMasterMenteLib.fProductMst

        Me.Visible = False
        oProductMst.ShowDialog()
        oProductMst = Nothing
        Me.Visible = True

    End Sub

    Private Sub NETSTATUS_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NETSTATUS_B.Click
        Dim oNetStatus = New fProductStatus

        Me.Visible = False
        oNetStatus.ShowDialog()
        oNetStatus = Nothing
        Me.Visible = True

    End Sub

    Private Sub RUTERN_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles RUTERN_B.Click
        Me.Dispose()
    End Sub
End Class