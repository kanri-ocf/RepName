Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rStaffCard_Fore
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
        Fields.Add("STAFF_PIC")
        Fields.Add("LOGO_PIC")

    End Sub

    Private Sub rStaffCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        If RECORD_NO = 0 Then
            Fields("STAFF_BARCODE").Value = STAFF_CODE
            Fields("STAFF_CODE").Value = STAFF_CODE
            Fields("STAFF_NAME").Value = STAFF_NAME
            Fields("ROLE_NAME").Value = ROLE_NAME

            ' スタッフ写真用　FileStream を開く
            If System.IO.File.Exists("StaffPhoto\" & STAFF_CODE & ".jpg") Then
                Dim hStream1 As New System.IO.FileStream("StaffPhoto\" & STAFF_CODE & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Fields("STAFF_PIC").Value = System.Drawing.Image.FromStream(hStream1)
                hStream1 = Nothing
            Else
                Fields("STAFF_PIC").Value = Nothing
            End If

            ' ロゴ画像用　FileStream を開く
            If System.IO.File.Exists("Picture\StaffCardFore.BMP") Then
                Dim hStream2 As New System.IO.FileStream("Picture\StaffCardFore.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Fields("LOGO_PIC").Value = System.Drawing.Image.FromStream(hStream2)
                hStream2 = Nothing
            Else
                Fields("LOGO_PIC").Value = Nothing
            End If
        Else
            eArgs.EOF = True
        End If
        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
