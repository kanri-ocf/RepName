Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rDayCloseReportSub6
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oCloseDate As String

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oTimeSales() As cStructureLib.sViewTimeSales
    Private oDataTrnMsDBIO As cDataTrnMsDBIO

    Private RECORD_CNT As Long
    Private RECORD_NO As Long

    Private oBumonType As Integer

    Private tLastChannelName As String
    Private tLastBsDate As String
    Private tTimeZone As Integer

    Private tOpenHour As Integer
    Private tCloseHour As Integer

    Private oTool As cTool
    Private oTran As System.Data.OleDb.OleDbTransaction
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCloseDate As String, _
            ByVal iBumonType As Integer, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oCloseDate = iCloseDate
        oTran = iTran
        oBumonType = iBumonType

        tTimeZone = 0

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

        ' リアル店舗である場合
        If oBumonType = 1 Then
            TIME_SALES.ChartAreas(0).Axes("AxisX").Max = (oConf(0).sCloseHour + 1).ToString
            tCloseHour = oConf(0).sCloseHour

            TIME_SALES.ChartAreas(0).Axes("AxisX").Min = (oConf(0).sOpenHour + 1).ToString
            tOpenHour = oConf(0).sOpenHour
        ElseIf oBumonType = 2 Then
            TIME_SALES.ChartAreas(0).Axes("AxisX").Max = 25
            tCloseHour = 25

            TIME_SALES.ChartAreas(0).Axes("AxisX").Min = 1
            tOpenHour = 1
        End If

        oConfMstDBIO = Nothing
        oDataTrnMsDBIO = Nothing

        oTool = New cTool
    End Sub
    Private Sub rDayCloseReportSub6_DataInitialize(ByVal sender As Object, _
                                           ByVal e As System.EventArgs) Handles Me.DataInitialize
        Fields.Add("CHANNEL_NAME")
        Fields.Add("CREATE_DATE")
    End Sub
    Private Sub Detail_FetchData(ByVal sender As Object, _
                                 ByVal eArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) _
                                 Handles Me.FetchData

        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)


        ' リアル店舗である場合
        If oBumonType = 1 Then
            RECORD_CNT = oDataTrnMsDBIO.getRealShopSales(oTimeSales, oCloseDate, oTran)
        ElseIf oBumonType = 2 Then
            ' ネット店舗である場合、見出しを非表示
            Label1.Visible = False
            RECORD_CNT = oDataTrnMsDBIO.getNetShopSales(oTimeSales, oCloseDate, oTran)
        End If

        ' 集計したデータを帳票に設定
        If RECORD_NO < RECORD_CNT Then

            ' 初回の読み込みである場合、登録日とチャネル名を退避
            If RECORD_NO = 0 Then
                tLastBsDate = oTimeSales(RECORD_NO).sBusinessDate
                tLastChannelName = oTimeSales(RECORD_NO).sChannelName
            End If

            ' 前回レコードとチャネル・営業日が異なる場合
            If (tLastBsDate <> oTimeSales(RECORD_NO).sBusinessDate _
            Or tLastChannelName <> oTimeSales(RECORD_NO).sChannelName) _
            And RECORD_NO > 0 Then
                ' 前回レコードのチャネル・営業日のグラフを描画する
                While tTimeZone < 24
                    Dim xDataPoint As New DataDynamics.ActiveReports.Chart.DataPoint

                    ' 時間帯
                    xDataPoint.XValue = tTimeZone

                    ' 売上額
                    xDataPoint.YValues.Item(0) = 0

                    TIME_SALES.Series(0).Points.Add(xDataPoint)

                    tTimeZone = tTimeZone + 1
                End While

                ' 営業日・チャネル名を退避し、時間帯を初期化する
                tLastBsDate = oTimeSales(RECORD_NO).sBusinessDate
                tLastChannelName = oTimeSales(RECORD_NO).sChannelName

                tTimeZone = 0

                ' 印書する箇所を移動する
                TIME_SALES.ChartAreas(0).Axes("AxisX").Max = _
                                             TIME_SALES.ChartAreas(0).Axes("AxisX").Max + 48
                TIME_SALES.ChartAreas(0).Axes("AxisX").Min = _
                                             TIME_SALES.ChartAreas(0).Axes("AxisX").Min + 48

            End If

            ' チャネル名
            Fields("CHANNEL_NAME").Value = "【" & oTimeSales(RECORD_NO).sChannelName & "】"

            ' 登録日
            If oBumonType = 1 Then
                Fields("CREATE_DATE").Value = oTimeSales(RECORD_NO).sBusinessDate & "売上分"
            ElseIf oBumonType = 2 Then
                Fields("CREATE_DATE").Value = oTimeSales(RECORD_NO).sBusinessDate & "受注分"
            End If

            ' 
            While tTimeZone < 24

                ' 取得した時間帯・売上をグラフに描画
                If tTimeZone = oTimeSales(RECORD_NO).sTimeZone Then
                    Dim xDataPoint As New DataDynamics.ActiveReports.Chart.DataPoint

                    ' 時間帯
                    xDataPoint.XValue = tTimeZone

                    ' 売上額
                    xDataPoint.YValues.Item(0) = oTimeSales(RECORD_NO).sTimeSales

                    TIME_SALES.Series(0).Points.Add(xDataPoint)

                    RECORD_NO = RECORD_NO + 1
                Else
                    Dim xDataPoint As New DataDynamics.ActiveReports.Chart.DataPoint

                    ' 時間帯
                    xDataPoint.XValue = tTimeZone

                    ' 売上額
                    xDataPoint.YValues.Item(0) = 0

                    TIME_SALES.Series(0).Points.Add(xDataPoint)
                End If

                tTimeZone = tTimeZone + 1

                ' 取得したデータをすべて読み込んだ場合、編集中のチャネル・営業日の空データを設定
                If oTimeSales.Length() = RECORD_NO Then
                    While tTimeZone < 24
                        Dim xDataPoint As New DataDynamics.ActiveReports.Chart.DataPoint

                        ' 時間帯
                        xDataPoint.XValue = tTimeZone

                        ' 売上額
                        xDataPoint.YValues.Item(0) = 0

                        TIME_SALES.Series(0).Points.Add(xDataPoint)

                        tTimeZone = tTimeZone + 1

                    End While

                End If

            End While

            If tTimeZone = 24 _
                And oTimeSales.Length <> RECORD_NO Then
                tTimeZone = 0
            End If

            eArgs.EOF = False
        Else
            eArgs.EOF = True
        End If
    End Sub
End Class
