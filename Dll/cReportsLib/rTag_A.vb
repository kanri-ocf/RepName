Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rTag_A
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private CHANNEL_CODE As Integer

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oDataTagPrintStatusDBIO As cDataTagPrintStatusDBIO
    Private oTagPrint() As cStructureLib.sTagPrintStatus

    Private oProductDBIO As cMstProductDBIO
    Private oProductPrice() As cStructureLib.sViewProductPrice

    Private RecordCnt As Long
    Private RECORD_NO As Long
    Private START_POINT As Integer
    Private REAL_POINT As Integer
    Private COUNT_NO As Integer

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iChannelCode As Integer, _
            ByVal iStartPoint As Integer, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction _
            )

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oConf = iConf
        oTran = iTran

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oTool = New cTool

        CHANNEL_CODE = iChannelCode
        START_POINT = iStartPoint

        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oDataTagPrintStatusDBIO = New cDataTagPrintStatusDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oDataTagPrintStatusDBIO.getTagPrintStatus(oTagPrint, Nothing, True)

        RECORD_NO = 0
        REAL_POINT = 1
        COUNT_NO = 1
    End Sub
    Private Sub rTag_A_DataInitialize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.DataInitialize
        Fields.Add("PRODUCT_NAME")
        Fields.Add("BARCODE")
        Fields.Add("OPTION_VALUE")
        Fields.Add("PRODUCT_CODE")
        Fields.Add("SALE_PRICE")
    End Sub

    Private Sub rTag_A_FetchData(ByVal sender As Object, ByVal eArgs As FetchEventArgs) Handles Me.FetchData
        Dim str As String

        If REAL_POINT >= START_POINT Then
            If RECORD_NO < oTagPrint.Length Then
                RecordCnt = oProductDBIO.getProductPrice(oProductPrice, CHANNEL_CODE, oTagPrint(RECORD_NO).sProductCode, Nothing, Nothing, oTran)

                Fields("PRODUCT_NAME").Value = oProductPrice(0).sProductShortName
                Fields("BARCODE").Value = oProductPrice(0).sJANCode

                str = ""
                For j = 1 To 5
                    Select Case j
                        Case 1
                            If oProductPrice(0).sOption1 <> "" Then
                                str = str & oProductPrice(0).sOption1 & "："
                            End If
                        Case 2
                            If oProductPrice(0).sOption2 <> "" Then
                                str = str & oProductPrice(0).sOption2 & "　"
                            End If
                        Case 3
                            If oProductPrice(0).sOption3 <> "" Then
                                str = str & oProductPrice(0).sOption3 & "　"
                            End If
                        Case 4
                            If oProductPrice(0).sOption4 <> "" Then
                                str = str & oProductPrice(0).sOption4 & "　"
                            End If
                        Case 5
                            If oProductPrice(0).sOption5 <> "" Then
                                str = str & oProductPrice(0).sOption5 & "　"
                            End If
                    End Select
                Next

                Fields("OPTION_VALUE").Value = str
                Fields("PRODUCT_CODE").Value = oProductPrice(0).sProductCode

                '2019,11,30 A.Komita 追加 From
                If oProductPrice(0).sReducedTaxRate = String.Empty Then
                    Fields("SALE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oProductPrice(0).sSalePrice, oConf(0).sTax, oConf(0).sFracProc))
                Else
                    Fields("SALE_PRICE").Value = String.Format("{0:C}", oTool.BeforeToAfterTax(oProductPrice(0).sSalePrice, oProductPrice(0).sReducedTaxRate, oConf(0).sFracProc))
                End If
                '2019,11,30 A.Komita 追加 To


                eArgs.EOF = False
                If oTagPrint(RECORD_NO).sCount = COUNT_NO Then
                    RECORD_NO = RECORD_NO + 1
                    COUNT_NO = 1
                Else
                    COUNT_NO = COUNT_NO + 1
                End If
            Else
                eArgs.EOF = True
            End If
        Else
            eArgs.EOF = False
        End If

        REAL_POINT = REAL_POINT + 1

    End Sub
End Class
