<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rTag_B
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
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rTag_B))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PRODUCT_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.PRODUCT_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.OPTION_VALUE = New DataDynamics.ActiveReports.TextBox()
        Me.SALE_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnCount = 4
        Me.Detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PRODUCT_NAME, Me.PRODUCT_CODE, Me.OPTION_VALUE, Me.SALE_PRICE})
        Me.Detail.Height = 0.6299213!
        Me.Detail.Name = "Detail"
        '
        'PRODUCT_NAME
        '
        Me.PRODUCT_NAME.DataField = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Height = 0.2062992!
        Me.PRODUCT_NAME.Left = 0.1141732!
        Me.PRODUCT_NAME.Name = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Style = "font-size: 6.75pt"
        Me.PRODUCT_NAME.Text = "０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９"
        Me.PRODUCT_NAME.Top = 0.1236221!
        Me.PRODUCT_NAME.Width = 1.333858!
        '
        'PRODUCT_CODE
        '
        Me.PRODUCT_CODE.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.DistinctField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Height = 0.1059056!
        Me.PRODUCT_CODE.Left = 0.1141732!
        Me.PRODUCT_CODE.Name = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Style = "font-size: 6.75pt; vertical-align: bottom"
        Me.PRODUCT_CODE.Text = "XXNNN-NN"
        Me.PRODUCT_CODE.Top = 0.4523622!
        Me.PRODUCT_CODE.Width = 0.6149607!
        '
        'OPTION_VALUE
        '
        Me.OPTION_VALUE.DataField = "OPTION_VALUE"
        Me.OPTION_VALUE.Height = 0.1937008!
        Me.OPTION_VALUE.Left = 0.1141732!
        Me.OPTION_VALUE.Name = "OPTION_VALUE"
        Me.OPTION_VALUE.Style = "font-size: 6.75pt"
        Me.OPTION_VALUE.Text = "０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９"
        Me.OPTION_VALUE.Top = 0.2889764!
        Me.OPTION_VALUE.Width = 1.333858!
        '
        'SALE_PRICE
        '
        Me.SALE_PRICE.DataField = "SALE_PRICE"
        Me.SALE_PRICE.Height = 0.1787402!
        Me.SALE_PRICE.Left = 0.7291339!
        Me.SALE_PRICE.Name = "SALE_PRICE"
        Me.SALE_PRICE.Style = "font-size: 9.75pt; text-align: right; vertical-align: bottom"
        Me.SALE_PRICE.Text = "XXNNN-NN"
        Me.SALE_PRICE.Top = 0.3897638!
        Me.SALE_PRICE.Width = 0.7188976!
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'rTag_B
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.8661417!
        Me.PageSettings.Margins.Left = 0.984252!
        Me.PageSettings.Margins.Right = 0.984252!
        Me.PageSettings.Margins.Top = 0.8661417!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.299212!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
            "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents PRODUCT_NAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PRODUCT_CODE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_VALUE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SALE_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
End Class
