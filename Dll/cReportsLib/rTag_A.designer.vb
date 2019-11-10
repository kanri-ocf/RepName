<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rTag_A
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rTag_A))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PRODUCT_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.PRODUCT_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.OPTION_VALUE = New DataDynamics.ActiveReports.TextBox()
        Me.BARCODE = New DataDynamics.ActiveReports.Barcode()
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
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PRODUCT_NAME, Me.PRODUCT_CODE, Me.OPTION_VALUE, Me.BARCODE, Me.SALE_PRICE})
        Me.Detail.Height = 1.0!
        Me.Detail.Name = "Detail"
        '
        'PRODUCT_NAME
        '
        Me.PRODUCT_NAME.DataField = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Height = 0.2413386!
        Me.PRODUCT_NAME.Left = 0.04212599!
        Me.PRODUCT_NAME.Name = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Style = "font-size: 8.25pt"
        Me.PRODUCT_NAME.Text = "０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９"
        Me.PRODUCT_NAME.Top = 0.07244095!
        Me.PRODUCT_NAME.Width = 1.781102!
        '
        'PRODUCT_CODE
        '
        Me.PRODUCT_CODE.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.DistinctField = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Height = 0.1267717!
        Me.PRODUCT_CODE.Left = 0.04212599!
        Me.PRODUCT_CODE.Name = "PRODUCT_CODE"
        Me.PRODUCT_CODE.Style = "color: Black; font-size: 6.75pt"
        Me.PRODUCT_CODE.Text = "XXNNN-NN"
        Me.PRODUCT_CODE.Top = 0.865748!
        Me.PRODUCT_CODE.Width = 0.5208662!
        '
        'OPTION_VALUE
        '
        Me.OPTION_VALUE.DataField = "OPTION_VALUE"
        Me.OPTION_VALUE.Height = 0.2287402!
        Me.OPTION_VALUE.Left = 0.04212599!
        Me.OPTION_VALUE.Name = "OPTION_VALUE"
        Me.OPTION_VALUE.Style = "font-size: 8.25pt"
        Me.OPTION_VALUE.Text = "０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９"
        Me.OPTION_VALUE.Top = 0.6472442!
        Me.OPTION_VALUE.Width = 1.781102!
        '
        'BARCODE
        '
        Me.BARCODE.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.BARCODE.DataField = "BARCODE"
        Me.BARCODE.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.BARCODE.Height = 0.3437009!
        Me.BARCODE.Left = 0.1149606!
        Me.BARCODE.Name = "BARCODE"
        Me.BARCODE.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.BARCODE.Top = 0.3035433!
        Me.BARCODE.Width = 1.651969!
        '
        'SALE_PRICE
        '
        Me.SALE_PRICE.DataField = "SALE_PRICE"
        Me.SALE_PRICE.Height = 0.1787402!
        Me.SALE_PRICE.Left = 0.6775591!
        Me.SALE_PRICE.Name = "SALE_PRICE"
        Me.SALE_PRICE.Style = "color: Black; font-size: 9.75pt; text-align: right"
        Me.SALE_PRICE.Text = "XXNNN-NN"
        Me.SALE_PRICE.Top = 0.8137795!
        Me.SALE_PRICE.Width = 1.145669!
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
        'rTag_A
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.3464567!
        Me.PageSettings.Margins.Left = 0.3307087!
        Me.PageSettings.Margins.Right = 0.3307087!
        Me.PageSettings.Margins.Top = 0.3464567!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.559055!
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
    Private WithEvents BARCODE As DataDynamics.ActiveReports.Barcode
    Friend WithEvents SALE_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
End Class
