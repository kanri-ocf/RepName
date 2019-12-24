Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document


Public Class rMonthCloseReportSub1
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oAdjust() As cStructureLib.sAdjust
    Private oAdjustDBIO As cDataAdjustDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oCalc() As cStructureLib.sCalc
    Private oTrnSummary() As cStructureLib.sViewTrnSummary

    Private Const SRCCOPY As Integer = &HCC0020

    Private IN_CASH_TOTAL As Long
    Private OUT_CASH_TOTAL As Long

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection,
        ByRef iCommand As OleDb.OleDbCommand,
        ByRef iDataReader As OleDb.OleDbDataReader,
        ByRef iCloseDate As String,
        ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim RecordCnt As Integer
        Dim FromAdjustCode As Long
        Dim ToAdjustCode As Long

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        '環境マスタ読込み
        ReDim oConf(1)

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oConfMstDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            oConfMstDBIO = Nothing
            Application.Exit()
        End If
        oConfMstDBIO = Nothing

        RECORD_CNT = 0
        IN_CASH_TOTAL = 0
        OUT_CASH_TOTAL = 0

        '入金状況
        oAdjustDBIO = New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", iCloseDate, "<=", oTran)
        ToAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, iCloseDate, "<=", oTran)
        'RECORD_CNT = oAdjustDBIO.getAdjust(oAdjust, Nothing, Nothing, iCloseDate, cStructureLib.GetAdjustMode.OrderDateInOutClass, oTran)
        RECORD_CNT = oAdjustDBIO.getAdjust(oAdjust, Nothing, Nothing, iCloseDate, cStructureLib.GetAdjustMode.OrderDateInOutClass, Nothing, oTran)
        oAdjustDBIO = Nothing
    End Sub
    Private Sub rMonthCloseReportSub1_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("KANJYOU")
        Fields.Add("SUB_KANJYOU")
        Fields.Add("MEMO")
        Fields.Add("IN_CASH")
        Fields.Add("OUT_CASH")
        Fields.Add("T_IN_CASH")
        Fields.Add("T_OUT_CASH")

    End Sub

    Private Sub rMonthCloseReportSub1_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        Dim oAccountDBIO As cMstAccountDBIO
        Dim oAccount() As cStructureLib.sAccount
        Dim oSupplierDBIO As cMstSupplierDBIO
        Dim oSupplier() As cStructureLib.sSupplier

        ReDim oAccount(0)
        ReDim oSupplier(0)

        If RECORD_NO < RECORD_CNT Then
            Fields("KANJYOU").Value = oAdjust(RECORD_NO).sAccountName
            If oAdjust(RECORD_NO).sSubAccountName = "" Then
                oAccountDBIO = New cMstAccountDBIO(oConn, oCommand, oDataReader)
                'oAccountDBIO.getAccount(oAccount, oAdjust(RECORD_NO).sAccountCode, oTran)
                oAccountDBIO.getAccount(oAccount, oAdjust(RECORD_NO).sAccountCode, Nothing, Nothing, Nothing, Nothing, oTran)
                Select Case oAccount(0).sLinkMasterName
                    Case "仕入先マスタ"
                        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
                        oSupplierDBIO.getSupplier(oSupplier, oAdjust(RECORD_NO).sSubAccountCode, Nothing, oTran)
                        Fields("SUB_KANJYOU").Value = oSupplier(0).sSupplierName
                        oSupplierDBIO = Nothing
                End Select
                oAccountDBIO = Nothing
            Else
                Fields("SUB_KANJYOU").Value = oAdjust(RECORD_NO).sSubAccountName
            End If
            Fields("MEMO").Value = ""
            Select Case oAdjust(RECORD_NO).sAdjustClass
                Case "入金"
                    Fields("IN_CASH").Value = oAdjust(RECORD_NO).sTotalPrice
                    Fields("OUT_CASH").Value = 0

                Case "出金"
                    Fields("IN_CASH").Value = 0
                    Fields("OUT_CASH").Value = oAdjust(RECORD_NO).sTotalPrice
            End Select
            eArgs.EOF = False
        Else
            eArgs.EOF = True
        End If

        RECORD_NO = RECORD_NO + 1

    End Sub
End Class
