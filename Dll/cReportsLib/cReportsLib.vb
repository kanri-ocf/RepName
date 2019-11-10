<ComClass(cReportsLib.ClassId, cReportsLib.InterfaceId, cReportsLib.EventsId)> _
Public Class cReportsLib

#Region "COM GUID"
    ' これらの GUID は、このクラスおよびその COM インターフェイスの COM ID を 
    ' 指定します。この値を変更すると、 
    ' 既存のクライアントはクラスにアクセスできなくなります。
    Public Const ClassId As String = "eb00a2b8-2ba0-46cd-8819-2b5a67356a46"
    Public Const InterfaceId As String = "b3a422f2-5219-4e8f-ab64-7998829d24cf"
    Public Const EventsId As String = "b77c9f0f-1818-4e29-b6cb-37904ced6f7b"
#End Region

    ' 作成可能な COM クラスにはパラメータなしの Public Sub New() を指定しなければ 
    ' なりません。これを行わないと、クラスは COM レジストリに登録されず、 
    ' CreateObject 経由で 
    ' 作成できません。
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function RequestPrint(ByRef pConn As OleDb.OleDbConnection,
                               ByRef pCommand As OleDb.OleDbCommand,
                               ByRef pDataReader As OleDb.OleDbDataReader,
                               ByRef pREQUEST_V As Windows.Forms.DataGridView,
                               ByRef pSelectCnt As Long,
                               ByRef pTran As OleDb.OleDbTransaction) As Boolean
        Dim pReportPage1 As rRequestReportPage
        Dim pReportPage2 As rRequestReportPage
        Dim i As Integer
        Dim SelCnt As Integer

        pReportPage1 = Nothing

        SelCnt = 0

        For i = 0 To pREQUEST_V.Rows.Count - 1
            If pREQUEST_V("選択", i).Value = True Then
                If SelCnt = 0 Then
                    pReportPage1 = Nothing
                    pReportPage1 = New rRequestReportPage(pConn, pCommand, pDataReader, pREQUEST_V("受注コード", i).Value, pSelectCnt, pTran)

                    pReportPage1.Run(False)
                Else
                    pReportPage2 = Nothing
                    pReportPage2 = New rRequestReportPage(pConn, pCommand, pDataReader, pREQUEST_V("受注コード", i).Value, pSelectCnt, pTran)

                    pReportPage2.Run(False)

                    pReportPage1.Document.Pages.Insert(pReportPage1.Document.Pages.Count, pReportPage2.Document.Pages(0).Clone)
                End If

                SelCnt = SelCnt + 1

            End If
        Next i
        RequestPrint = pReportPage1.Document.Print(True, False)

        pReportPage1 = Nothing
        pReportPage2 = Nothing
    End Function
    Public Function OrderPrint(ByRef pConn As OleDb.OleDbConnection,
                               ByRef pCommand As OleDb.OleDbCommand,
                               ByRef pDataReader As OleDb.OleDbDataReader,
                               ByRef pOrderCode As String,
                               ByRef pStaffCode As String,
                               ByRef pStaffName As String,
                               ByRef pReportMode As String,
                               ByRef pTran As OleDb.OleDbTransaction) As Boolean
        Dim pReportPage = New rOrderReport(pConn, pCommand, pDataReader, pOrderCode, pStaffCode, pStaffName, pReportMode, pTran)

        pReportPage.Run()
        OrderPrint = pReportPage.Document.Print(True, True, True)

        pReportPage = Nothing

    End Function

    Public Function ReturnOrderPrint(ByRef pConn As OleDb.OleDbConnection,
                               ByRef pCommand As OleDb.OleDbCommand,
                               ByRef pDataReader As OleDb.OleDbDataReader,
                               ByRef pOrderCode As String,
                               ByRef pStaffCode As String,
                               ByRef pStaffName As String,
                               ByRef pReportMode As String,
                               ByRef pTran As OleDb.OleDbTransaction) As Boolean
        Dim pReportPage = New rReturnOrderReport(pConn, pCommand, pDataReader, pOrderCode, pStaffCode, pStaffName, pReportMode, pTran)

        pReportPage.Run()
        ReturnOrderPrint = pReportPage.Document.Print(True, True, True)

        pReportPage = Nothing

    End Function

    Public Function ShipmentPrint(ByRef pConn As OleDb.OleDbConnection,
                            ByRef pCommand As OleDb.OleDbCommand,
                            ByRef pDataReader As OleDb.OleDbDataReader,
                            ByRef pShipmentNo As String,
                            ByRef pStaffCode As String,
                            ByRef pStaffName As String,
                            ByRef pReShipFlg As Boolean,
                            ByRef pTran As OleDb.OleDbTransaction) As Boolean
        Dim pReportPage = New rShipmentReport(pConn, pCommand, pDataReader, pShipmentNo, pStaffCode, pStaffName, pReShipFlg, pTran)

        pReportPage.Run()
        ShipmentPrint = pReportPage.Document.Print(True, True)

        pReportPage = Nothing

    End Function
    Public Function DayClosePrint(ByRef pConn As OleDb.OleDbConnection,
                                  ByRef pCommand As OleDb.OleDbCommand,
                                  ByRef pDataReader As OleDb.OleDbDataReader,
                                  ByRef pCalc() As cStructureLib.sCalc,
                                  ByRef oTrnSummary() As cStructureLib.sViewTrnSummary,
                                  ByRef pStaffCode As String,
                                  ByRef pStaffName As String,
                                  ByRef pCloseDate As String,
                                  ByRef pSubDate As String,
                                  ByRef pMeisaiPrintFlg As Boolean,
                                  ByRef pTran As OleDb.OleDbTransaction) As Boolean
        Dim pReportPage = New rDayCloseReport(pConn, pCommand, pDataReader, pCalc, oTrnSummary, pStaffCode, pStaffName,
                                                    pCloseDate, pSubDate, pMeisaiPrintFlg, pTran)

        pReportPage.Run()
        DayClosePrint = pReportPage.Document.Print(True, False)

        pReportPage = Nothing

    End Function
    'Public Function StaffCardPrint(ByRef pConn As OleDb.OleDbConnection, _
    '                              ByRef pCommand As OleDb.OleDbCommand, _
    '                              ByRef pDataReader As OleDb.OleDbDataReader, _
    '                              ByRef iStaffCode As String, _
    '                              ByRef iStaffName As String, _
    '                              ByRef iStaffRole As String, _
    '                              ByRef pTran As System.Data.OleDb.OleDbTransaction) As Boolean
    '    Dim pStaffCard As New fStaffCardReportPage(pConn, pCommand, pDataReader, oconf, iStaffCode, iStaffName, iStaffRole, pTran)
    '    pStaffCard.ShowDialog()

    '    pStaffCard = Nothing



    'End Function

    Public Function MemberCardPrint(ByRef pConn As OleDb.OleDbConnection,
                                  ByRef pCommand As OleDb.OleDbCommand,
                                  ByRef pDataReader As OleDb.OleDbDataReader,
                                  ByVal MemberCode As String,
                                  ByRef pTran As OleDb.OleDbTransaction) As Boolean

        Dim pMemberCard As New fMemberCardReportPage(pConn, pCommand, pDataReader, MemberCode, pTran)
        pMemberCard.ShowDialog()
        ''TODO:課題表No107 ここで結果を取得？
        'If pMemberCard.DialogResult <> Windows.Forms.DialogResult.OK Then

        'End If

        pMemberCard = Nothing

    End Function

    Public Function TagPrint(ByRef pConn As OleDb.OleDbConnection,
                                ByRef pCommand As OleDb.OleDbCommand,
                                ByRef pDataReader As OleDb.OleDbDataReader,
                                ByVal ChannelCode As Integer,
                                ByVal Mode As Integer,
                                ByVal pTran As OleDb.OleDbTransaction) As Boolean
        Dim orderReport_form As fTagReportPage

        orderReport_form = New fTagReportPage(pConn, pCommand, pDataReader, ChannelCode, Mode, pTran)
        orderReport_form.ShowDialog()

        TagPrint = orderReport_form.DialogResult

        orderReport_form = Nothing
    End Function
End Class


