Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rMemberCard_Fore
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oServiceFull() As cStructureLib.sViewServiceFull
    Private oMstServiceDBIO As cMstServiceDBIO

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
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        MEMBER_NUMBER = iMemberCode


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

        ReDim oServiceFull(0)
        oMstServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstServiceDBIO.getServiceFull(oServiceFull, oMember(0).sServiceCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        ReDim Preserve oServiceFull(10)

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

        Fields.Add("OPTION_1_L")
        Fields.Add("OPTION_2_L")
        Fields.Add("OPTION_3_L")
        Fields.Add("OPTION_4_L")
        Fields.Add("OPTION_5_L")
        Fields.Add("OPTION_6_L")
        Fields.Add("OPTION_7_L")
        Fields.Add("OPTION_8_L")
        Fields.Add("OPTION_9_L")
        Fields.Add("OPTION_10_L")

        Fields.Add("OPTION_1_FLG")
        Fields.Add("OPTION_2_FLG")
        Fields.Add("OPTION_3_FLG")
        Fields.Add("OPTION_4_FLG")
        Fields.Add("OPTION_5_FLG")
        Fields.Add("OPTION_6_FLG")
        Fields.Add("OPTION_7_FLG")
        Fields.Add("OPTION_8_FLG")
        Fields.Add("OPTION_9_FLG")
        Fields.Add("OPTION_10_FLG")

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
                Dim hStream As New System.IO.FileStream("MemberPhoto\" & oMember(0).sMemberCode & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Fields("MEMBER_PIC").Value = System.Drawing.Image.FromStream(hStream)
                hStream = Nothing
            Else
                Fields("MEMBER_PIC").Value = Nothing
            End If

            Fields("OPTION_1_L").Value = oServiceFull(0).sBumonName
            Fields("OPTION_2_L").Value = oServiceFull(1).sBumonName
            Fields("OPTION_3_L").Value = oServiceFull(2).sBumonName
            Fields("OPTION_4_L").Value = oServiceFull(3).sBumonName
            Fields("OPTION_5_L").Value = oServiceFull(4).sBumonName
            Fields("OPTION_6_L").Value = oServiceFull(5).sBumonName
            Fields("OPTION_7_L").Value = oServiceFull(6).sBumonName
            Fields("OPTION_8_L").Value = oServiceFull(7).sBumonName
            Fields("OPTION_9_L").Value = oServiceFull(8).sBumonName
            Fields("OPTION_10_L").Value = oServiceFull(9).sBumonName

            If oServiceFull(0).sRate > 0 Then
                Fields("OPTION_1_FLG").Value = "●"
            Else
                Fields("OPTION_1_FLG").Value = ""
            End If
            If oServiceFull(1).sRate > 0 Then
                Fields("OPTION_2_FLG").Value = "●"
            Else
                Fields("OPTION_2_FLG").Value = ""
            End If
            If oServiceFull(2).sRate > 0 Then
                Fields("OPTION_3_FLG").Value = "●"
            Else
                Fields("OPTION_3_FLG").Value = ""
            End If
            If oServiceFull(3).sRate > 0 Then
                Fields("OPTION_4_FLG").Value = "●"
            Else
                Fields("OPTION_4_FLG").Value = ""
            End If
            If oServiceFull(4).sRate > 0 Then
                Fields("OPTION_5_FLG").Value = "●"
            Else
                Fields("OPTION_5_FLG").Value = ""
            End If
            If oServiceFull(5).sRate > 0 Then
                Fields("OPTION_6_FLG").Value = "●"
            Else
                Fields("OPTION_6_FLG").Value = ""
            End If
            If oServiceFull(6).sRate > 0 Then
                Fields("OPTION_7_FLG").Value = "●"
            Else
                Fields("OPTION_7_FLG").Value = ""
            End If
            If oServiceFull(7).sRate > 0 Then
                Fields("OPTION_8_FLG").Value = "●"
            Else
                Fields("OPTION_8_FLG").Value = ""
            End If
            If oServiceFull(8).sRate > 0 Then
                Fields("OPTION_9_FLG").Value = "●"
            Else
                Fields("OPTION_9_FLG").Value = ""
            End If
            If oServiceFull(9).sRate > 0 Then
                Fields("OPTION_10_FLG").Value = "●"
            Else
                Fields("OPTION_10_FLG").Value = ""
            End If

            eArgs.EOF = False
        End If

        RECORD_NO = RECORD_NO + 1

    End Sub

    Protected Overrides Sub Finalize()
        oMstConfigDBIO = Nothing
        oMstMemberDBIO = Nothing
        oMstServiceDBIO = Nothing

        MyBase.Finalize()
    End Sub
End Class
