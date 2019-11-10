Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rDayCloseReportSub4
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oCloseDate As String

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oDataTrnMs() As cStructureLib.sViewDataTrnMs
    Private oDataTrnMsDBIO As cDataTrnMsDBIO

    Private CLOSE_DATE As String

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private STAFF_COUNT As Long
    Private STAFF_DISCOUNT As Long
    Private STAFF_SALES As Long

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCloseDate As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oCloseDate = iCloseDate
        oTran = iTran

        '環境マスタ読込み
        ReDim oConf(1)

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RECORD_CNT = oConfMstDBIO.getConfMst(oConf, oTran)

        If RECORD_CNT < 1 Then
            'RECORD_CNT表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oConfMstDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If

        oConfMstDBIO = Nothing

        STAFF_COUNT = 0
        STAFF_DISCOUNT = 0
        STAFF_SALES = 0

        oTool = New cTool

    End Sub
    Private Sub rDayCloseReportSub4_DataInitialize(ByVal sender As Object, _
                                               ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("CHANNEL_NAME")
        Fields.Add("STAFF_NO")
        Fields.Add("STAFF_NAME")
        Fields.Add("SALE_COUNT")
        Fields.Add("DISCOUNT_PRICE")
        Fields.Add("SALE_PRICE")
        Fields.Add("DISCOUNT_RATE")
    End Sub
    Private Sub rDayCloseReportSub4_FetchData(ByVal sender As Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles Me.FetchData
        Dim tmpDiscount As Long

        ' 取引明細集計クラスの呼び出し(MODECODE:3)
        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)

        RECORD_CNT = oDataTrnMsDBIO.getTrnMs(oDataTrnMs, oCloseDate, "3", oTran)

        ' データを集計
        If RECORD_NO < RECORD_CNT Then

            If RECORD_NO = 1 Then
                GroupHeader1.Visible = True
            End If

            ' 販売数量
            STAFF_COUNT = STAFF_COUNT + oDataTrnMs(RECORD_NO).sCount

            ' 値引き
            tmpDiscount = oDataTrnMs(RECORD_NO).sDiscountPrice

            STAFF_DISCOUNT = STAFF_DISCOUNT + tmpDiscount

            ' 売上金額
            STAFF_SALES = STAFF_SALES + oDataTrnMs(RECORD_NO).sPrice

            RECORD_NO = RECORD_NO + 1

            ' すべてのレコードを読み終わっている場合、集計データを出力
            If RECORD_NO = RECORD_CNT Then

                Call visibleDat(True)

                ' チャネル名
                Fields("CHANNEL_NAME").Value = "【" & oDataTrnMs(RECORD_NO - 1).sChannelName & "】"

                ' スタッフNO
                Fields("STAFF_NO").Value = oDataTrnMs(RECORD_NO - 1).sStaffCode

                ' スタッフ名
                Fields("STAFF_NAME").Value = oDataTrnMs(RECORD_NO - 1).sStaffName

                ' 販売数量
                Fields("SALE_COUNT").Value = String.Format("{0:#,##0}", STAFF_COUNT)

                ' 値引き
                Fields("DISCOUNT_PRICE").Value = String.Format("{0:#,##0}", STAFF_DISCOUNT)

                ' 売上金額
                Fields("SALE_PRICE").Value = String.Format("{0:#,##0}", STAFF_SALES)

                ' 値引き率
                Fields("DISCOUNT_RATE").Value = String.Format("{0:0.0}", _
                                                  ((STAFF_DISCOUNT * (-1) / (STAFF_SALES - STAFF_DISCOUNT)) * 100))
            Else
                ' 前レコードとカレントレコードの部門名とスタッフコードのどちらかが異なっている場合
                If oDataTrnMs(RECORD_NO).sStaffCode <> oDataTrnMs(RECORD_NO - 1).sStaffCode _
                Or oDataTrnMs(RECORD_NO).sChannelCode <> oDataTrnMs(RECORD_NO - 1).sChannelCode Then
                    Call visibleDat(True)

                    ' チャネル名
                    Fields("CHANNEL_NAME").Value = "【" & oDataTrnMs(RECORD_NO - 1).sChannelName & "】"

                    ' スタッフNO
                    Fields("STAFF_NO").Value = oDataTrnMs(RECORD_NO - 1).sStaffCode

                    ' スタッフ名
                    Fields("STAFF_NAME").Value = oDataTrnMs(RECORD_NO - 1).sStaffName

                    ' 販売数量
                    Fields("SALE_COUNT").Value = String.Format("{0:#,##0}", STAFF_COUNT)

                    ' 値引き
                    Fields("DISCOUNT_PRICE").Value = String.Format("{0:#,##0}", STAFF_DISCOUNT)

                    ' 売上金額
                    Fields("SALE_PRICE").Value = String.Format("{0:#,##0}", STAFF_SALES)

                    ' 値引き率
                    Fields("DISCOUNT_RATE").Value = String.Format("{0:0.0}", _
                                                  ((STAFF_DISCOUNT * (-1) / (STAFF_SALES - STAFF_DISCOUNT)) * 100))

                    STAFF_COUNT = 0
                    STAFF_DISCOUNT = 0
                    STAFF_SALES = 0
                ElseIf RECORD_NO = 1 Then
                    Call visibleDat(False)
                End If
            End If

            eArgs.EOF = False
        Else
            eArgs.EOF = True
        End If
    End Sub
    '-------------------------------------------------
    ' 表の出力可否を設定する
    '-------------------------------------------------
    Private Sub visibleDat(ByVal judgeStr As Boolean)
        Label2.Visible = judgeStr
        Label3.Visible = judgeStr
        Label4.Visible = judgeStr
        Label5.Visible = judgeStr
        Label6.Visible = judgeStr
        Label10.Visible = judgeStr
        CHANNEL_NAME.Visible = judgeStr
        STAFF_NO.Visible = judgeStr
        STAFF_NAME.Visible = judgeStr
        SALE_COUNT.Visible = judgeStr
        DISCOUNT_PRICE.Visible = judgeStr
        SALE_PRICE.Visible = judgeStr
        DISCOUNT_RATE.Visible = judgeStr
    End Sub
End Class
