<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub5 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rDayCloseReportSub5))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.TRN_CODE = New DataDynamics.ActiveReports.TextBox
        Me.STATUS = New DataDynamics.ActiveReports.TextBox
        Me.SALE_COUNT = New DataDynamics.ActiveReports.TextBox
        Me.SALES = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT = New DataDynamics.ActiveReports.TextBox
        Me.TRN_NAME = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT_CODE = New DataDynamics.ActiveReports.TextBox
        Me.LIST_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.CHANNEL_NAME = New DataDynamics.ActiveReports.TextBox
        Me.取引コード = New DataDynamics.ActiveReports.TextBox
        Me.取引方法 = New DataDynamics.ActiveReports.TextBox
        Me.売上状態 = New DataDynamics.ActiveReports.TextBox
        Me.商品コード = New DataDynamics.ActiveReports.TextBox
        Me.商品名称 = New DataDynamics.ActiveReports.TextBox
        Me.数量 = New DataDynamics.ActiveReports.TextBox
        Me.金額 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionLine1 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine2 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine3 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine4 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine5 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine6 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine7 = New DataDynamics.ActiveReports.CrossSectionLine
        CType(Me.TRN_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STATUS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LIST_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.取引コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.取引方法, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.売上状態, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.商品コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.商品名称, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.金額, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TRN_CODE, Me.STATUS, Me.SALE_COUNT, Me.SALES, Me.PRODUCT, Me.TRN_NAME, Me.PRODUCT_CODE, Me.LIST_PRICE})
        Me.Detail.Height = 0.15625!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'TRN_CODE
        '
        Me.TRN_CODE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TRN_CODE.DataField = "TRN_CODE"
        Me.TRN_CODE.Height = 0.177!
        Me.TRN_CODE.Left = 0.0!
        Me.TRN_CODE.Name = "TRN_CODE"
        Me.TRN_CODE.Padding = New DataDynamics.ActiveReports.PaddingEx(5, 0, 0, 0)
        Me.TRN_CODE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.TRN_CODE.Text = "9999999999-9999"
        Me.TRN_CODE.Top = 0.0!
        Me.TRN_CODE.Width = 0.9580001!
        '
        'STATUS
        '
        Me.STATUS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.STATUS.DataField = "STATUS"
        Me.STATUS.Height = 0.177!
        Me.STATUS.Left = 1.447!
        Me.STATUS.Name = "STATUS"
        Me.STATUS.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.STATUS.Text = "ＸＸ"
        Me.STATUS.Top = 0.0!
        Me.STATUS.Width = 0.4890001!
        '
        'SALE_COUNT
        '
        Me.SALE_COUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_COUNT.DataField = "SALE_COUNT"
        Me.SALE_COUNT.Height = 0.177!
        Me.SALE_COUNT.Left = 5.809!
        Me.SALE_COUNT.Name = "SALE_COUNT"
        Me.SALE_COUNT.OutputFormat = "#,##0"
        Me.SALE_COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALE_COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALE_COUNT.Text = "9999"
        Me.SALE_COUNT.Top = 0.0!
        Me.SALE_COUNT.Width = 0.4159994!
        '
        'SALES
        '
        Me.SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALES.DataField = "SALES"
        Me.SALES.Height = 0.177!
        Me.SALES.Left = 6.215!
        Me.SALES.Name = "SALES"
        Me.SALES.OutputFormat = "#,##0"
        Me.SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALES.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALES.Text = "9999999999"
        Me.SALES.Top = 0.0!
        Me.SALES.Width = 0.7080002!
        '
        'PRODUCT
        '
        Me.PRODUCT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT.DataField = "PRODUCT"
        Me.PRODUCT.Height = 0.177!
        Me.PRODUCT.Left = 2.561!
        Me.PRODUCT.Name = "PRODUCT"
        Me.PRODUCT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.PRODUCT.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.PRODUCT.Top = 0.0!
        Me.PRODUCT.Width = 2.54!
        '
        'TRN_NAME
        '
        Me.TRN_NAME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TRN_NAME.DataField = "TRN_NAME"
        Me.TRN_NAME.Height = 0.177!
        Me.TRN_NAME.Left = 0.9580001!
        Me.TRN_NAME.Name = "TRN_NAME"
        Me.TRN_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.TRN_NAME.Text = "ＸＸＸＸ"
        Me.TRN_NAME.Top = 0.0!
        Me.TRN_NAME.Width = 0.4890001!
        '
        'PRODUCT_CODE
        '
        Me.PRODUCT_CODE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT_CODE.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Height = 0.177!
        Me.PRODUCT_CODE.Left = 1.936!
        Me.PRODUCT_CODE.Name = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.PRODUCT_CODE.Text = "XXXXXXXX"
        Me.PRODUCT_CODE.Top = 0.0!
        Me.PRODUCT_CODE.Width = 0.625!
        '
        'LIST_PRICE
        '
        Me.LIST_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LIST_PRICE.DataField = "LIST_PRICE"
        Me.LIST_PRICE.Height = 0.177!
        Me.LIST_PRICE.Left = 5.101!
        Me.LIST_PRICE.Name = "LIST_PRICE"
        Me.LIST_PRICE.OutputFormat = "#,##0"
        Me.LIST_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.LIST_PRICE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.LIST_PRICE.Text = "9999999999"
        Me.LIST_PRICE.Top = 0.0!
        Me.LIST_PRICE.Width = 0.708!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.01041666!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CHANNEL_NAME, Me.取引コード, Me.取引方法, Me.売上状態, Me.商品コード, Me.商品名称, Me.数量, Me.金額, Me.TextBox2, Me.CrossSectionBox1, Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.CrossSectionLine6, Me.CrossSectionLine7})
        Me.GroupHeader1.DataField = "CHANNEL_NAME"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 0.397!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'CHANNEL_NAME
        '
        Me.CHANNEL_NAME.DataField = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Height = 0.158!
        Me.CHANNEL_NAME.Left = 0.0!
        Me.CHANNEL_NAME.Name = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1"
        Me.CHANNEL_NAME.Text = "【チャネル名】"
        Me.CHANNEL_NAME.Top = 0.0!
        Me.CHANNEL_NAME.Width = 1.177165!
        '
        '取引コード
        '
        Me.取引コード.Height = 0.177!
        Me.取引コード.Left = 0.0!
        Me.取引コード.Name = "取引コード"
        Me.取引コード.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.取引コード.Text = "取引コード"
        Me.取引コード.Top = 0.217!
        Me.取引コード.Width = 0.9580001!
        '
        '取引方法
        '
        Me.取引方法.Height = 0.177!
        Me.取引方法.Left = 0.9580001!
        Me.取引方法.Name = "取引方法"
        Me.取引方法.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.取引方法.Text = "取引方法"
        Me.取引方法.Top = 0.22!
        Me.取引方法.Width = 0.4890001!
        '
        '売上状態
        '
        Me.売上状態.Height = 0.177!
        Me.売上状態.Left = 1.447!
        Me.売上状態.Name = "売上状態"
        Me.売上状態.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.売上状態.Text = "売上状態"
        Me.売上状態.Top = 0.22!
        Me.売上状態.Width = 0.4890001!
        '
        '商品コード
        '
        Me.商品コード.Height = 0.177!
        Me.商品コード.Left = 1.936!
        Me.商品コード.Name = "商品コード"
        Me.商品コード.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.商品コード.Text = "商品コード"
        Me.商品コード.Top = 0.22!
        Me.商品コード.Width = 0.625!
        '
        '商品名称
        '
        Me.商品名称.Height = 0.177!
        Me.商品名称.Left = 2.561!
        Me.商品名称.Name = "商品名称"
        Me.商品名称.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.商品名称.Text = "商品名称"
        Me.商品名称.Top = 0.22!
        Me.商品名称.Width = 2.54!
        '
        '数量
        '
        Me.数量.Height = 0.177!
        Me.数量.Left = 5.809!
        Me.数量.Name = "数量"
        Me.数量.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.数量.Text = "数量"
        Me.数量.Top = 0.217!
        Me.数量.Width = 0.4060001!
        '
        '金額
        '
        Me.金額.Height = 0.177!
        Me.金額.Left = 6.215!
        Me.金額.Name = "金額"
        Me.金額.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.金額.Text = "売上金額"
        Me.金額.Top = 0.217!
        Me.金額.Width = 0.7080002!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.177!
        Me.TextBox2.Left = 5.101!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.TextBox2.Text = "販売価格"
        Me.TextBox2.Top = 0.22!
        Me.TextBox2.Width = 0.708!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1})
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader2.Height = 0.21875!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 128"
        Me.Label1.Text = "【商品別売上明細】"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.167!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.End = CType(resources.GetObject("CrossSectionBox1.End"), System.Drawing.PointF)
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Start = CType(resources.GetObject("CrossSectionBox1.Start"), System.Drawing.PointF)
        Me.CrossSectionBox1.Top = 0.2169292!
        '
        'CrossSectionLine1
        '
        Me.CrossSectionLine1.End = CType(resources.GetObject("CrossSectionLine1.End"), System.Drawing.PointF)
        Me.CrossSectionLine1.LineWeight = 1.0!
        Me.CrossSectionLine1.Name = "CrossSectionLine1"
        Me.CrossSectionLine1.Start = CType(resources.GetObject("CrossSectionLine1.Start"), System.Drawing.PointF)
        Me.CrossSectionLine1.Top = 0.2169292!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.End = CType(resources.GetObject("CrossSectionLine2.End"), System.Drawing.PointF)
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Start = CType(resources.GetObject("CrossSectionLine2.Start"), System.Drawing.PointF)
        Me.CrossSectionLine2.Top = 0.2200788!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.End = CType(resources.GetObject("CrossSectionLine3.End"), System.Drawing.PointF)
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Start = CType(resources.GetObject("CrossSectionLine3.Start"), System.Drawing.PointF)
        Me.CrossSectionLine3.Top = 0.2200788!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.End = CType(resources.GetObject("CrossSectionLine4.End"), System.Drawing.PointF)
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Start = CType(resources.GetObject("CrossSectionLine4.Start"), System.Drawing.PointF)
        Me.CrossSectionLine4.Top = 0.2200788!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.End = CType(resources.GetObject("CrossSectionLine5.End"), System.Drawing.PointF)
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Start = CType(resources.GetObject("CrossSectionLine5.Start"), System.Drawing.PointF)
        Me.CrossSectionLine5.Top = 0.2169292!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.End = CType(resources.GetObject("CrossSectionLine6.End"), System.Drawing.PointF)
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Start = CType(resources.GetObject("CrossSectionLine6.Start"), System.Drawing.PointF)
        Me.CrossSectionLine6.Top = 0.2200788!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.End = CType(resources.GetObject("CrossSectionLine7.End"), System.Drawing.PointF)
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Start = CType(resources.GetObject("CrossSectionLine7.Start"), System.Drawing.PointF)
        Me.CrossSectionLine7.Top = 0.2169292!
        '
        'rDayCloseReportSub5
        '
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.020833!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TRN_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STATUS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LIST_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.取引コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.取引方法, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.売上状態, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.商品コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.商品名称, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.金額, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CHANNEL_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents 取引コード As DataDynamics.ActiveReports.TextBox
    Private WithEvents 取引方法 As DataDynamics.ActiveReports.TextBox
    Private WithEvents 売上状態 As DataDynamics.ActiveReports.TextBox
    Private WithEvents 商品コード As DataDynamics.ActiveReports.TextBox
    Private WithEvents 商品名称 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TRN_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents 数量 As DataDynamics.ActiveReports.TextBox
    Private WithEvents 金額 As DataDynamics.ActiveReports.TextBox
    Private WithEvents STATUS As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALE_COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALES As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT As DataDynamics.ActiveReports.TextBox
    Private WithEvents TRN_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents LIST_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionLine1 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine2 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine3 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine4 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine5 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine6 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine7 As DataDynamics.ActiveReports.CrossSectionLine
End Class 
