Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rStaffCard_Back
    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oConf As cStructureLib.sConfig

    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConf As cStructureLib.sConfig)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConf = iConf

        RECORD_NO = 0
    End Sub

    Private Sub rStaffCard_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("ADDRESS")
        Fields.Add("TEL")
        Fields.Add("FAX")

    End Sub

    Private Sub rStaffCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        If RECORD_NO = 0 Then
            Fields("ADDRESS").Value = oConf.sPostCode & " " & oConf.sAdderess1 & oConf.sAdderess2
            Fields("TEL").Value = "TEL " & oConf.sTEL
            Fields("FAX").Value = "FAX " & oConf.sFAX
        Else
            eArgs.EOF = True
        End If
        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
