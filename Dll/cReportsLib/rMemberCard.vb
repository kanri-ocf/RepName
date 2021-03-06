﻿Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rMemberCard
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private MEMBER_NUMBER As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
        ByRef iCommand As OleDb.OleDbCommand, _
        ByRef iDataReader As OleDb.OleDbDataReader, _
        ByRef iMemberCode As String, _
        ByVal iStaff_Code As String, _
        ByVal iStaff_Name As String, _
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        MEMBER_NUMBER = iMemberCode
        STAFF_CODE = iStaff_Code
        STAFF_NAME = iStaff_Name


        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If
        oMstConfigDBIO = Nothing

        '会員マスタ読込み
        ReDim oMember(1)
        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        RECORD_CNT = oMstMemberDBIO.getMember(oMember, MEMBER_NUMBER, Nothing, Nothing, Nothing, oTran)

        RECORD_NO = 0
    End Sub

    Private Sub rMemberCard_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("MEMBER_NAME")
        Fields.Add("BIRTHDAY")
        Fields.Add("ADDRESS")
        Fields.Add("ST_REG_DATE")
        Fields.Add("END_REG_DATE")
        Fields.Add("MEMBER_CODE")
        Fields.Add("SUBMEMBER_NAME")

        Fields.Add("MEMBER_PIC")

        Fields.Add("T_FLG")
        Fields.Add("S_FLG")
        Fields.Add("B_FLG")

    End Sub

    Private Sub rMemberCard_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData

        If RECORD_NO >= RECORD_CNT Then
            eArgs.EOF = True
        Else
            Fields("MEMBER_NAME").Value = oMember(0).sMemberName
            Fields("BIRTHDAY").Value = oMember(0).sBirthday
            Fields("ADDRESS").Value = oMember(0).sAddress1 & oMember(0).sAddress2 & oMember(0).sAddress3
            Fields("ST_REG_DATE").Value = oMember(0).sStartRegistDate
            Fields("END_REG_DATE").Value = oMember(0).sEndRegistDate
            Fields("MEMBER_CODE").Value = oMember(0).sMemberCode
            Fields("SUBMEMBER_NAME").Value = oMember(0).sSubMemberName
            ' FileStream を開く

            If System.IO.File.Exists("MemberPhoto\" & oMember(0).sMemberCode & ".jpg") Then
                Dim hStream As New System.IO.FileStream("MemberPhoto\" & oMember(0).sMemberCode & ".jpg", System.IO.FileMode.Open)
                Fields("MEMBER_PIC").Value = System.Drawing.Image.FromStream(hStream)
                hStream = Nothing
            Else
                Fields("MEMBER_PIC").Value = Nothing
            End If

            Fields("T_FLG").Value = "●"
            Fields("S_FLG").Value = "●"
            Fields("B_FLG").Value = "●"

            eArgs.EOF = False
            End If

            RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        oMstConfigDBIO = Nothing
        oMstMemberDBIO = Nothing

        MyBase.Finalize()
    End Sub
End Class
