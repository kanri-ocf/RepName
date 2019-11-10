Public Class cStaffEntry
    Public Sub New(ByRef iConn As OleDb.OleDbConnection, _
        ByRef iCommand As OleDb.OleDbCommand, _
        ByRef iDataReader As OleDb.OleDbDataReader, _
        ByRef iStaffCode As String, _
        ByRef iStaffName As String, _
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        iStaffCode = Nothing
        iStaffName = Nothing

        While iStaffCode = Nothing
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(iConn, iCommand, iDataReader, iTran)
            staff_form.ShowDialog()
            'System.Windows.Forms.aApplication.DoEvents()
            Select Case staff_form.DialogResult
                Case Windows.Forms.DialogResult.OK
                    '担当者セット
                    iStaffCode = staff_form.STAFF_CODE
                    iStaffName = staff_form.STAFF_NAME
                    staff_form = Nothing
                Case Windows.Forms.DialogResult.Cancel  '999999999999入力あり
                    staff_form = Nothing
                    Environment.Exit(1)
                Case Windows.Forms.DialogResult.Abort   '権限なし
                    staff_form = Nothing
                    Environment.Exit(1)
            End Select
        End While
    End Sub
End Class
