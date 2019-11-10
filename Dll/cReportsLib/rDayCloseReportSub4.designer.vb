<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub4
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rDayCloseReportSub4))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.STAFF_NO = New DataDynamics.ActiveReports.TextBox
        Me.STAFF_NAME = New DataDynamics.ActiveReports.TextBox
        Me.SALE_COUNT = New DataDynamics.ActiveReports.TextBox
        Me.DISCOUNT_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.SALE_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.CHANNEL_NAME = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.DISCOUNT_RATE = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFF_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFF_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DISCOUNT_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DISCOUNT_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.158!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold"
        Me.Label1.Text = "【スタッフ別売上】"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.187!
        '
        'Label2
        '
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.177!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label2.Text = "スタッフNO"
        Me.Label2.Top = 0.2291339!
        Me.Label2.Width = 0.906!
        '
        'Label3
        '
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.177!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.9059056!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label3.Text = "スタッフ氏名"
        Me.Label3.Top = 0.2291339!
        Me.Label3.Width = 1.74!
        '
        'Label10
        '
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.177!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 2.646063!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label10.Text = "販売数量"
        Me.Label10.Top = 0.2291339!
        Me.Label10.Width = 0.66!
        '
        'Label4
        '
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.177!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.296063!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label4.Text = "値引額"
        Me.Label4.Top = 0.2291339!
        Me.Label4.Width = 0.66!
        '
        'Label5
        '
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.177!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.955512!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label5.Text = "売上金額"
        Me.Label5.Top = 0.2291339!
        Me.Label5.Width = 0.66!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'STAFF_NO
        '
        Me.STAFF_NO.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.STAFF_NO.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.STAFF_NO.DataField = "STAFF_NO"
        Me.STAFF_NO.Height = 0.177!
        Me.STAFF_NO.Left = 0.0!
        Me.STAFF_NO.Name = "STAFF_NO"
        Me.STAFF_NO.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.STAFF_NO.Text = "スタッフNO"
        Me.STAFF_NO.Top = 0.0!
        Me.STAFF_NO.Width = 0.906!
        '
        'STAFF_NAME
        '
        Me.STAFF_NAME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.STAFF_NAME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.STAFF_NAME.DataField = "STAFF_NAME"
        Me.STAFF_NAME.Height = 0.177!
        Me.STAFF_NAME.Left = 0.9059055!
        Me.STAFF_NAME.Name = "STAFF_NAME"
        Me.STAFF_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.STAFF_NAME.Text = "スタッフ氏名"
        Me.STAFF_NAME.Top = 0.0!
        Me.STAFF_NAME.Width = 1.74!
        '
        'SALE_COUNT
        '
        Me.SALE_COUNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_COUNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_COUNT.DataField = "SALE_COUNT"
        Me.SALE_COUNT.Height = 0.1771654!
        Me.SALE_COUNT.Left = 2.646063!
        Me.SALE_COUNT.Name = "SALE_COUNT"
        Me.SALE_COUNT.OutputFormat = resources.GetString("SALE_COUNT.OutputFormat")
        Me.SALE_COUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALE_COUNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALE_COUNT.Text = "販売数量"
        Me.SALE_COUNT.Top = 0.0!
        Me.SALE_COUNT.Width = 0.6598426!
        '
        'DISCOUNT_PRICE
        '
        Me.DISCOUNT_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT_PRICE.DataField = "DISCOUNT_PRICE"
        Me.DISCOUNT_PRICE.Height = 0.177!
        Me.DISCOUNT_PRICE.Left = 3.296063!
        Me.DISCOUNT_PRICE.Name = "DISCOUNT_PRICE"
        Me.DISCOUNT_PRICE.OutputFormat = resources.GetString("DISCOUNT_PRICE.OutputFormat")
        Me.DISCOUNT_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.DISCOUNT_PRICE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.DISCOUNT_PRICE.Text = "値引額"
        Me.DISCOUNT_PRICE.Top = 0.0!
        Me.DISCOUNT_PRICE.Width = 0.6699997!
        '
        'SALE_PRICE
        '
        Me.SALE_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_PRICE.DataField = "SALE_PRICE"
        Me.SALE_PRICE.DistinctField = "STAFF_NO"
        Me.SALE_PRICE.Height = 0.177!
        Me.SALE_PRICE.Left = 3.955512!
        Me.SALE_PRICE.Name = "SALE_PRICE"
        Me.SALE_PRICE.OutputFormat = resources.GetString("SALE_PRICE.OutputFormat")
        Me.SALE_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.SALE_PRICE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.SALE_PRICE.Text = "売上金額"
        Me.SALE_PRICE.Top = 1.862645E-9!
        Me.SALE_PRICE.Width = 0.6699997!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CHANNEL_NAME, Me.Label6, Me.Label2, Me.Label3, Me.Label10, Me.Label4, Me.Label5})
        Me.GroupHeader1.DataField = "CHANNEL_NAME"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 0.3996391!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'CHANNEL_NAME
        '
        Me.CHANNEL_NAME.DataField = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Height = 0.158!
        Me.CHANNEL_NAME.HyperLink = Nothing
        Me.CHANNEL_NAME.Left = -9.313224E-10!
        Me.CHANNEL_NAME.Name = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold"
        Me.CHANNEL_NAME.Text = "【チャネル名】"
        Me.CHANNEL_NAME.Top = 0.03149607!
        Me.CHANNEL_NAME.Width = 1.187!
        '
        'Label6
        '
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.177!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 4.625984!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: c" & _
            "enter"
        Me.Label6.Text = "値引率"
        Me.Label6.Top = 0.2291339!
        Me.Label6.Width = 0.66!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'DISCOUNT_RATE
        '
        Me.DISCOUNT_RATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT_RATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT_RATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT_RATE.DataField = "DISCOUNT_RATE"
        Me.DISCOUNT_RATE.Height = 0.1771654!
        Me.DISCOUNT_RATE.Left = 4.625984!
        Me.DISCOUNT_RATE.Name = "DISCOUNT_RATE"
        Me.DISCOUNT_RATE.OutputFormat = resources.GetString("DISCOUNT_RATE.OutputFormat")
        Me.DISCOUNT_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.DISCOUNT_RATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.DISCOUNT_RATE.Text = "値引率"
        Me.DISCOUNT_RATE.Top = 0.0!
        Me.DISCOUNT_RATE.Width = 0.6598426!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1})
        Me.GroupHeader3.Height = 0.1771654!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.CanShrink = True
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.STAFF_NO, Me.STAFF_NAME, Me.SALE_COUNT, Me.DISCOUNT_PRICE, Me.SALE_PRICE, Me.DISCOUNT_RATE})
        Me.GroupHeader2.DataField = "STAFF_NO"
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader2.Height = 0.1771654!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'rDayCloseReportSub4
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.0!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFF_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFF_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DISCOUNT_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DISCOUNT_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents STAFF_NO As DataDynamics.ActiveReports.TextBox
    Private WithEvents STAFF_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALE_COUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents DISCOUNT_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents SALE_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents DISCOUNT_RATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents CHANNEL_NAME As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
End Class
