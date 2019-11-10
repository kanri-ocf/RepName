<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub2
    Inherits DataDynamics.ActiveReports.ActiveReport

    'ActiveReport がコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReport デザイナで必要です。
    'ActiveReport デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rDayCloseReportSub2))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.PRODUCT_CODE = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT = New DataDynamics.ActiveReports.TextBox
        Me.LIST_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.COUNT = New DataDynamics.ActiveReports.TextBox
        Me.SALES = New DataDynamics.ActiveReports.TextBox
        Me.MARGIN = New DataDynamics.ActiveReports.TextBox
        Me.PROFIT_RATE = New DataDynamics.ActiveReports.TextBox
        Me.BUMON = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.CHANNEL = New DataDynamics.ActiveReports.TextBox
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.SUM_COUNT = New DataDynamics.ActiveReports.TextBox
        Me.SUM_SALES = New DataDynamics.ActiveReports.TextBox
        Me.SUM_MARGIN = New DataDynamics.ActiveReports.TextBox
        Me.SUM_PROFIT_RATE = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.SUB_COUNT = New DataDynamics.ActiveReports.TextBox
        Me.SUB_SALES = New DataDynamics.ActiveReports.TextBox
        Me.SUB_MARGIN = New DataDynamics.ActiveReports.TextBox
        Me.SUB_PROFIT_RATE = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        Me.Field2 = New DataDynamics.ActiveReports.Field
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader
        Me.CrossSectionLine1 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine2 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine3 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine4 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine5 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine6 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine7 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter
        Me.CrossSectionBox2 = New DataDynamics.ActiveReports.CrossSectionBox
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LIST_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MARGIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROFIT_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BUMON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHANNEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUM_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUM_SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUM_MARGIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUM_PROFIT_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUB_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUB_SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUB_MARGIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUB_PROFIT_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'PRODUCT_CODE
        '
        Me.PRODUCT_CODE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT_CODE.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Height = 0.177!
        Me.PRODUCT_CODE.Left = 0.7700787!
        Me.PRODUCT_CODE.Name = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; white-space: inherit"
        Me.PRODUCT_CODE.Text = "商品番号"
        Me.PRODUCT_CODE.Top = 0.0!
        Me.PRODUCT_CODE.Width = 0.9000001!
        '
        'PRODUCT
        '
        Me.PRODUCT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT.DataField = "PRODUCT"
        Me.PRODUCT.Height = 0.177!
        Me.PRODUCT.Left = 1.679921!
        Me.PRODUCT.Name = "PRODUCT"
        Me.PRODUCT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt"
        Me.PRODUCT.Text = "商品名" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.PRODUCT.Top = 0.0!
        Me.PRODUCT.Width = 2.444!
        '
        'LIST_PRICE
        '
        Me.LIST_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LIST_PRICE.DataField = "LIST_PRICE"
        Me.LIST_PRICE.Height = 0.177!
        Me.LIST_PRICE.Left = 4.103937!
        Me.LIST_PRICE.Name = "LIST_PRICE"
        Me.LIST_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.LIST_PRICE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.LIST_PRICE.Text = "販売価格" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LIST_PRICE.Top = 0.0!
        Me.LIST_PRICE.Width = 0.669!
        '
        'COUNT
        '
        Me.COUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.COUNT.DataField = "COUNT"
        Me.COUNT.Height = 0.177!
        Me.COUNT.Left = 4.772835!
        Me.COUNT.Name = "COUNT"
        Me.COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.COUNT.Text = "販売数量"
        Me.COUNT.Top = 0.0!
        Me.COUNT.Width = 0.6599998!
        '
        'SALES
        '
        Me.SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALES.DataField = "SALES"
        Me.SALES.Height = 0.177!
        Me.SALES.Left = 5.433071!
        Me.SALES.Name = "SALES"
        Me.SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALES.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SALES.Text = "売上金額"
        Me.SALES.Top = 0.0!
        Me.SALES.Width = 0.6599998!
        '
        'MARGIN
        '
        Me.MARGIN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MARGIN.DataField = "MARGIN"
        Me.MARGIN.Height = 0.1771654!
        Me.MARGIN.Left = 6.083071!
        Me.MARGIN.Name = "MARGIN"
        Me.MARGIN.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.MARGIN.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.MARGIN.Text = "粗利"
        Me.MARGIN.Top = 0.0!
        Me.MARGIN.Width = 0.6500001!
        '
        'PROFIT_RATE
        '
        Me.PROFIT_RATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PROFIT_RATE.DataField = "PROFIT_RATE"
        Me.PROFIT_RATE.Height = 0.1771654!
        Me.PROFIT_RATE.Left = 6.742914!
        Me.PROFIT_RATE.Name = "PROFIT_RATE"
        Me.PROFIT_RATE.OutputFormat = "0.0"
        Me.PROFIT_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.PROFIT_RATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.PROFIT_RATE.Text = "利益率"
        Me.PROFIT_RATE.Top = 0.0!
        Me.PROFIT_RATE.Width = 0.4472442!
        '
        'BUMON
        '
        Me.BUMON.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.BUMON.DataField = "BUMON"
        Me.BUMON.DistinctField = "BUMON"
        Me.BUMON.Height = 0.1771654!
        Me.BUMON.Left = 0.0!
        Me.BUMON.Name = "BUMON"
        Me.BUMON.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; white-space: nowrap"
        Me.BUMON.SummaryGroup = "GroupHeader2"
        Me.BUMON.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.BUMON.Text = "部門"
        Me.BUMON.Top = 0.0!
        Me.BUMON.Width = 0.7700787!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.03125!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.Label6, Me.Label7, Me.Label8, Me.CHANNEL, Me.CrossSectionBox1, Me.Label1, Me.Label2, Me.Label3, Me.Label9, Me.Label10, Me.Label12, Me.Label5, Me.CrossSectionBox2})
        Me.GroupHeader1.DataField = "CHANNEL"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 0.3543307!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'Label11
        '
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.177!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.433071!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label11.Text = "売上金額"
        Me.Label11.Top = 0.1665354!
        Me.Label11.Width = 0.6500003!
        '
        'Label6
        '
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.1770833!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label6.Text = "部門"
        Me.Label6.Top = 0.178!
        Me.Label6.Width = 0.7604167!
        '
        'Label7
        '
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1770833!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.7600001!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label7.Text = "商品番号"
        Me.Label7.Top = 0.178!
        Me.Label7.Width = 0.9!
        '
        'Label8
        '
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1770833!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.67!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label8.Text = "商品名"
        Me.Label8.Top = 0.178!
        Me.Label8.Width = 2.444!
        '
        'CHANNEL
        '
        Me.CHANNEL.DataField = "CHANNEL"
        Me.CHANNEL.Height = 0.177!
        Me.CHANNEL.Left = 0.0!
        Me.CHANNEL.Name = "CHANNEL"
        Me.CHANNEL.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; font-weight: bold; white-space: nowrap; dd" & _
            "o-char-set: 1"
        Me.CHANNEL.SummaryGroup = "GroupHeader1"
        Me.CHANNEL.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.CHANNEL.Text = "【チャネル】"
        Me.CHANNEL.Top = 0.0!
        Me.CHANNEL.Width = 1.687008!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.End = CType(resources.GetObject("CrossSectionBox1.End"), System.Drawing.PointF)
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Start = CType(resources.GetObject("CrossSectionBox1.Start"), System.Drawing.PointF)
        Me.CrossSectionBox1.Top = 0.0!
        '
        'Label1
        '
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.1770833!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.679921!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label1.Text = "商品名"
        Me.Label1.Top = 0.1665354!
        Me.Label1.Width = 2.444!
        '
        'Label2
        '
        Me.Label2.Height = 0.1770833!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.00984252!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label2.Text = "部門"
        Me.Label2.Top = 0.1665354!
        Me.Label2.Width = 0.7604167!
        '
        'Label3
        '
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.1770833!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.7700787!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label3.Text = "商品番号"
        Me.Label3.Top = 0.1665354!
        Me.Label3.Width = 0.9!
        '
        'Label9
        '
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.177!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.103937!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label9.Text = "販売価格"
        Me.Label9.Top = 0.1665354!
        Me.Label9.Width = 0.6689997!
        '
        'Label10
        '
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.177!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.772835!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label10.Text = "販売数量"
        Me.Label10.Top = 0.1665354!
        Me.Label10.Width = 0.66!
        '
        'Label12
        '
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1771654!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.083071!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label12.Text = "粗利"
        Me.Label12.Top = 0.1665354!
        Me.Label12.Width = 0.65!
        '
        'Label5
        '
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.1771654!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 6.742914!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label5.Text = "利益率"
        Me.Label5.Top = 0.1665354!
        Me.Label5.Width = 0.4472441!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label20, Me.SUM_COUNT, Me.SUM_SALES, Me.SUM_MARGIN, Me.SUM_PROFIT_RATE})
        Me.GroupFooter1.Height = 0.3543307!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label20
        '
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.1771654!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.0!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " & _
            "center"
        Me.Label20.Text = "合計"
        Me.Label20.Top = 0.004!
        Me.Label20.Width = 4.772835!
        '
        'SUM_COUNT
        '
        Me.SUM_COUNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_COUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_COUNT.DataField = "SUM_COUNT"
        Me.SUM_COUNT.Height = 0.1771654!
        Me.SUM_COUNT.Left = 4.772835!
        Me.SUM_COUNT.Name = "SUM_COUNT"
        Me.SUM_COUNT.OutputFormat = ""
        Me.SUM_COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUM_COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUM_COUNT.Text = "販売数量"
        Me.SUM_COUNT.Top = 0.0!
        Me.SUM_COUNT.Width = 0.6598426!
        '
        'SUM_SALES
        '
        Me.SUM_SALES.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_SALES.DataField = "SUM_SALES"
        Me.SUM_SALES.Height = 0.1771654!
        Me.SUM_SALES.Left = 5.433071!
        Me.SUM_SALES.Name = "SUM_SALES"
        Me.SUM_SALES.OutputFormat = ""
        Me.SUM_SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUM_SALES.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUM_SALES.Text = "売上金額"
        Me.SUM_SALES.Top = 0.0!
        Me.SUM_SALES.Width = 0.6598426!
        '
        'SUM_MARGIN
        '
        Me.SUM_MARGIN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_MARGIN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_MARGIN.DataField = "SUM_MARGIN"
        Me.SUM_MARGIN.Height = 0.1771654!
        Me.SUM_MARGIN.Left = 6.083071!
        Me.SUM_MARGIN.Name = "SUM_MARGIN"
        Me.SUM_MARGIN.OutputFormat = ""
        Me.SUM_MARGIN.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUM_MARGIN.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUM_MARGIN.Text = "粗利"
        Me.SUM_MARGIN.Top = 0.0!
        Me.SUM_MARGIN.Width = 0.65!
        '
        'SUM_PROFIT_RATE
        '
        Me.SUM_PROFIT_RATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_PROFIT_RATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUM_PROFIT_RATE.DataField = "SUM_PROFIT_RATE"
        Me.SUM_PROFIT_RATE.Height = 0.1771654!
        Me.SUM_PROFIT_RATE.Left = 6.742914!
        Me.SUM_PROFIT_RATE.Name = "SUM_PROFIT_RATE"
        Me.SUM_PROFIT_RATE.OutputFormat = ""
        Me.SUM_PROFIT_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUM_PROFIT_RATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SUM_PROFIT_RATE.Text = "利益率"
        Me.SUM_PROFIT_RATE.Top = 0.0!
        Me.SUM_PROFIT_RATE.Width = 0.4472441!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox1.Text = "【売上明細】"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.677!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.BUMON})
        Me.GroupHeader2.DataField = "BUMON"
        Me.GroupHeader2.Height = 0.1771654!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.UnderlayNext = True
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.SUB_COUNT, Me.SUB_SALES, Me.SUB_MARGIN, Me.SUB_PROFIT_RATE})
        Me.GroupFooter2.Height = 0.1771654!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Label4
        '
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.1771654!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " & _
            "center"
        Me.Label4.Text = "小計"
        Me.Label4.Top = 0.0!
        Me.Label4.Width = 4.772835!
        '
        'SUB_COUNT
        '
        Me.SUB_COUNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_COUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_COUNT.DataField = "SUB_COUNT"
        Me.SUB_COUNT.Height = 0.177!
        Me.SUB_COUNT.Left = 4.772835!
        Me.SUB_COUNT.Name = "SUB_COUNT"
        Me.SUB_COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUB_COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUB_COUNT.Text = "販売数量"
        Me.SUB_COUNT.Top = 0.0!
        Me.SUB_COUNT.Width = 0.6599998!
        '
        'SUB_SALES
        '
        Me.SUB_SALES.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_SALES.DataField = "SUB_SALES"
        Me.SUB_SALES.Height = 0.177!
        Me.SUB_SALES.Left = 5.433071!
        Me.SUB_SALES.Name = "SUB_SALES"
        Me.SUB_SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUB_SALES.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUB_SALES.Text = "売上金額"
        Me.SUB_SALES.Top = 0.0!
        Me.SUB_SALES.Width = 0.6599998!
        '
        'SUB_MARGIN
        '
        Me.SUB_MARGIN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_MARGIN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_MARGIN.DataField = "SUB_MARGIN"
        Me.SUB_MARGIN.Height = 0.1771654!
        Me.SUB_MARGIN.Left = 6.083071!
        Me.SUB_MARGIN.Name = "SUB_MARGIN"
        Me.SUB_MARGIN.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUB_MARGIN.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: right"
        Me.SUB_MARGIN.Text = "粗利"
        Me.SUB_MARGIN.Top = 0.0!
        Me.SUB_MARGIN.Width = 0.65!
        '
        'SUB_PROFIT_RATE
        '
        Me.SUB_PROFIT_RATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_PROFIT_RATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_PROFIT_RATE.DataField = "SUB_PROFIT_RATE"
        Me.SUB_PROFIT_RATE.Height = 0.1771654!
        Me.SUB_PROFIT_RATE.Left = 6.742914!
        Me.SUB_PROFIT_RATE.Name = "SUB_PROFIT_RATE"
        Me.SUB_PROFIT_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SUB_PROFIT_RATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SUB_PROFIT_RATE.Text = "利益率"
        Me.SUB_PROFIT_RATE.Top = 0.0!
        Me.SUB_PROFIT_RATE.Width = 0.4472441!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1})
        Me.GroupHeader3.Height = 0.25!
        Me.GroupHeader3.KeepTogether = True
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'Field2
        '
        Me.Field2.DefaultValue = Nothing
        Me.Field2.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None
        Me.Field2.Formula = "SUB_MARGIN/SUB_SALES"
        Me.Field2.Name = "Field2"
        Me.Field2.Tag = Nothing
        '
        'GroupHeader4
        '
        Me.GroupHeader4.CanShrink = True
        Me.GroupHeader4.ColumnLayout = False
        Me.GroupHeader4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PRODUCT_CODE, Me.PRODUCT, Me.LIST_PRICE, Me.COUNT, Me.SALES, Me.MARGIN, Me.PROFIT_RATE})
        Me.GroupHeader4.DataField = "PRODUCT_CODE"
        Me.GroupHeader4.Height = 0.1771654!
        Me.GroupHeader4.Name = "GroupHeader4"
        Me.GroupHeader4.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'CrossSectionLine1
        '
        Me.CrossSectionLine1.End = CType(resources.GetObject("CrossSectionLine1.End"), System.Drawing.PointF)
        Me.CrossSectionLine1.LineWeight = 1.0!
        Me.CrossSectionLine1.Name = "CrossSectionLine1"
        Me.CrossSectionLine1.Start = CType(resources.GetObject("CrossSectionLine1.Start"), System.Drawing.PointF)
        Me.CrossSectionLine1.Top = 0.0!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.End = CType(resources.GetObject("CrossSectionLine2.End"), System.Drawing.PointF)
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Start = CType(resources.GetObject("CrossSectionLine2.Start"), System.Drawing.PointF)
        Me.CrossSectionLine2.Top = 0.0!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.End = CType(resources.GetObject("CrossSectionLine3.End"), System.Drawing.PointF)
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Start = CType(resources.GetObject("CrossSectionLine3.Start"), System.Drawing.PointF)
        Me.CrossSectionLine3.Top = 0.0!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.End = CType(resources.GetObject("CrossSectionLine4.End"), System.Drawing.PointF)
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Start = CType(resources.GetObject("CrossSectionLine4.Start"), System.Drawing.PointF)
        Me.CrossSectionLine4.Top = 0.0!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.End = CType(resources.GetObject("CrossSectionLine5.End"), System.Drawing.PointF)
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Start = CType(resources.GetObject("CrossSectionLine5.Start"), System.Drawing.PointF)
        Me.CrossSectionLine5.Top = 0.0!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.End = CType(resources.GetObject("CrossSectionLine6.End"), System.Drawing.PointF)
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Start = CType(resources.GetObject("CrossSectionLine6.Start"), System.Drawing.PointF)
        Me.CrossSectionLine6.Top = 0.0!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.End = CType(resources.GetObject("CrossSectionLine7.End"), System.Drawing.PointF)
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Start = CType(resources.GetObject("CrossSectionLine7.Start"), System.Drawing.PointF)
        Me.CrossSectionLine7.Top = 0.0!
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Height = 0.0!
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'GroupHeader5
        '
        Me.GroupHeader5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.CrossSectionLine6, Me.CrossSectionLine7})
        Me.GroupHeader5.Height = 0.0!
        Me.GroupHeader5.Name = "GroupHeader5"
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Height = 0.0!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.End = CType(resources.GetObject("CrossSectionBox2.End"), System.Drawing.PointF)
        Me.CrossSectionBox2.LineWeight = 1.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Start = CType(resources.GetObject("CrossSectionBox2.Start"), System.Drawing.PointF)
        Me.CrossSectionBox2.Top = 0.1665355!
        '
        'rDayCloseReportSub2
        '
        Me.CalculatedFields.Add(Me.Field2)
        Me.PageSettings.Margins.Bottom = 0.39!
        Me.PageSettings.Margins.Left = 0.39!
        Me.PageSettings.Margins.Right = 0.39!
        Me.PageSettings.Margins.Top = 0.39!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.292028!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader5)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter4)
        Me.Sections.Add(Me.GroupFooter5)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LIST_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MARGIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROFIT_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BUMON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHANNEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUM_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUM_SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUM_MARGIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUM_PROFIT_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUB_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUB_SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUB_MARGIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUB_PROFIT_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Private WithEvents BUMON As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT As DataDynamics.ActiveReports.TextBox
    Private WithEvents LIST_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SUM_SALES As DataDynamics.ActiveReports.TextBox
    Private WithEvents SUM_MARGIN As DataDynamics.ActiveReports.TextBox
    Private WithEvents CHANNEL As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents SUM_COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALES As DataDynamics.ActiveReports.TextBox
    Private WithEvents MARGIN As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents SUB_COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SUB_SALES As DataDynamics.ActiveReports.TextBox
    Private WithEvents SUB_MARGIN As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents PROFIT_RATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents SUM_PROFIT_RATE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Field1 As DataDynamics.ActiveReports.Field
    Friend WithEvents Field2 As DataDynamics.ActiveReports.Field
    Private WithEvents SUB_PROFIT_RATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionLine1 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine2 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine3 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine4 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine5 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine6 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine7 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionBox2 As DataDynamics.ActiveReports.CrossSectionBox
End Class
