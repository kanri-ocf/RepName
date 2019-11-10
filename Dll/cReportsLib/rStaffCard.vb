Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rStaffCard
    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private ROLE_NAME As String

    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New( _
            ByVal iStaff_Code As String, _
            ByVal iStaff_Name As String, _
            ByVal iStaffRoleName As String _
        )

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name
        ROLE_NAME = iStaffRoleName

        RECORD_NO = 0
    End Sub

    Private Sub rStaffCard_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("STAFF_BARCODE")
        Fields.Add("STAFF_CODE")
        Fields.Add("STAFF_NAME")
        Fields.Add("ROLE_NAME")

    End Sub

    Private Sub rStaffCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        If RECORD_NO = 0 Then
            Fields("STAFF_BARCODE").Value = STAFF_CODE
            Fields("STAFF_CODE").Value = STAFF_CODE
            Fields("STAFF_NAME").Value = STAFF_NAME
            Fields("ROLE_NAME").Value = ROLE_NAME
        Else
            eArgs.EOF = True
        End If
        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
