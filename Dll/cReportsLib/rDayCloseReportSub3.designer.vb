<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub3
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rDayCloseReportSub3))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.RANK_NO = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT_CODE = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT = New DataDynamics.ActiveReports.TextBox
        Me.SALE_COUNT = New DataDynamics.ActiveReports.TextBox
        Me.SALE_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.BUMON_NAME = New DataDynamics.ActiveReports.TextBox
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionLine1 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine2 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine3 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.CrossSectionLine4 = New DataDynamics.ActiveReports.CrossSectionLine
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.RANK_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BUMON_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.RANK_NO, Me.PRODUCT_CODE, Me.PRODUCT, Me.SALE_COUNT, Me.SALE_PRICE})
        Me.Detail.Height = 0.177!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'RANK_NO
        '
        Me.RANK_NO.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.RANK_NO.CountNullValues = True
        Me.RANK_NO.DataField = "RANK_NO"
        Me.RANK_NO.Height = 0.177!
        Me.RANK_NO.Left = 0.0!
        Me.RANK_NO.Name = "RANK_NO"
        Me.RANK_NO.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: center"
        Me.RANK_NO.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.RANK_NO.SummaryGroup = "GroupHeader1"
        Me.RANK_NO.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.RANK_NO.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.RANK_NO.Text = "順位"
        Me.RANK_NO.Top = 0.0!
        Me.RANK_NO.Width = 0.76!
        '
        'PRODUCT_CODE
        '
        Me.PRODUCT_CODE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT_CODE.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Height = 0.177!
        Me.PRODUCT_CODE.Left = 0.7600001!
        Me.PRODUCT_CODE.Name = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.PRODUCT_CODE.Text = "商品番号"
        Me.PRODUCT_CODE.Top = 0.0!
        Me.PRODUCT_CODE.Width = 0.9!
        '
        'PRODUCT
        '
        Me.PRODUCT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PRODUCT.DataField = "PRODUCT"
        Me.PRODUCT.Height = 0.177!
        Me.PRODUCT.Left = 1.66!
        Me.PRODUCT.Name = "PRODUCT"
        Me.PRODUCT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.PRODUCT.Text = "商品名"
        Me.PRODUCT.Top = 2.793968E-9!
        Me.PRODUCT.Width = 2.444!
        '
        'SALE_COUNT
        '
        Me.SALE_COUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_COUNT.DataField = "SALE_COUNT"
        Me.SALE_COUNT.Height = 0.177!
        Me.SALE_COUNT.Left = 4.104!
        Me.SALE_COUNT.Name = "SALE_COUNT"
        Me.SALE_COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALE_COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALE_COUNT.Text = "販売数量"
        Me.SALE_COUNT.Top = 9.313226E-10!
        Me.SALE_COUNT.Width = 0.6599997!
        '
        'SALE_PRICE
        '
        Me.SALE_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_PRICE.DataField = "SALE_PRICE"
        Me.SALE_PRICE.Height = 0.177!
        Me.SALE_PRICE.Left = 4.764!
        Me.SALE_PRICE.Name = "SALE_PRICE"
        Me.SALE_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALE_PRICE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALE_PRICE.Text = "売上金額"
        Me.SALE_PRICE.Top = 9.313226E-10!
        Me.SALE_PRICE.Width = 0.6599997!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Label7, Me.Label8, Me.Label10, Me.Label11, Me.BUMON_NAME, Me.CrossSectionBox1, Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4})
        Me.GroupHeader1.DataField = "BUMON_NAME"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 0.3963336!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'Label3
        '
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.177!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: " & _
            "normal; text-align: center"
        Me.Label3.Text = "順位"
        Me.Label3.Top = 0.219!
        Me.Label3.Width = 0.76!
        '
        'Label7
        '
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1770833!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.7600001!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label7.Text = "商品番号"
        Me.Label7.Top = 0.219!
        Me.Label7.Width = 0.9!
        '
        'Label8
        '
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1770833!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.66!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label8.Text = "商品名"
        Me.Label8.Top = 0.219!
        Me.Label8.Width = 2.444!
        '
        'Label10
        '
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.177!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.104!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label10.Text = "販売数量"
        Me.Label10.Top = 0.219!
        Me.Label10.Width = 0.66!
        '
        'Label11
        '
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.177!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 4.764!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label11.Text = "売上金額"
        Me.Label11.Top = 0.219!
        Me.Label11.Width = 0.66!
        '
        'BUMON_NAME
        '
        Me.BUMON_NAME.DataField = "BUMON_NAME"
        Me.BUMON_NAME.DistinctField = "BUMON_NAME"
        Me.BUMON_NAME.Height = 0.177!
        Me.BUMON_NAME.Left = 0.0!
        Me.BUMON_NAME.Name = "BUMON_NAME"
        Me.BUMON_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; text-align: left; dd" & _
            "o-char-set: 1"
        Me.BUMON_NAME.SummaryGroup = "GroupHeader1"
        Me.BUMON_NAME.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.BUMON_NAME.Text = "【部門名】"
        Me.BUMON_NAME.Top = 0.0!
        Me.BUMON_NAME.Width = 1.676772!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.09375!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox1.Text = "【売上ランキング】"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.0!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1})
        Me.GroupHeader2.Height = 0.25!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'rDayCloseReportSub3
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.0!
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
        CType(Me.RANK_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BUMON_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents RANK_NO As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALE_COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALE_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents BUMON_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionLine1 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine2 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine3 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine4 As DataDynamics.ActiveReports.CrossSectionLine
End Class
