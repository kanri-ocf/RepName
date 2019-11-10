<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rStaffCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rStaffCard))
        Me.STAFF_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.Picture2 = New DataDynamics.ActiveReports.Picture
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.Picture1 = New DataDynamics.ActiveReports.Picture
        Me.STAFF_BARCODE_B = New DataDynamics.ActiveReports.Barcode
        Me.Line16 = New DataDynamics.ActiveReports.Line
        Me.Line17 = New DataDynamics.ActiveReports.Line
        Me.Line18 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.Line20 = New DataDynamics.ActiveReports.Line
        Me.Line21 = New DataDynamics.ActiveReports.Line
        Me.Line22 = New DataDynamics.ActiveReports.Line
        Me.Line23 = New DataDynamics.ActiveReports.Line
        Me.Line24 = New DataDynamics.ActiveReports.Line
        Me.Line25 = New DataDynamics.ActiveReports.Line
        Me.Line26 = New DataDynamics.ActiveReports.Line
        Me.Line27 = New DataDynamics.ActiveReports.Line
        Me.STAFF_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.ROLE_NAME_T = New DataDynamics.ActiveReports.TextBox
        CType(Me.STAFF_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFF_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ROLE_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.DataField = "STAFF_NAME"
        Me.STAFF_NAME_T.Height = 0.3248032!
        Me.STAFF_NAME_T.Left = 1.431496!
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Style = "font-size: 14.25pt; vertical-align: bottom"
        Me.STAFF_NAME_T.Text = "STAFF_NAME"
        Me.STAFF_NAME_T.Top = 1.002756!
        Me.STAFF_NAME_T.Width = 2.022441!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Picture2, Me.Shape2, Me.Picture1, Me.STAFF_BARCODE_B, Me.Line16, Me.Line17, Me.Line18, Me.Line19, Me.Line20, Me.Line21, Me.Line22, Me.Line23, Me.Line24, Me.Line25, Me.Line26, Me.Line27, Me.STAFF_CODE_T, Me.STAFF_NAME_T, Me.ROLE_NAME_T})
        Me.Detail.Height = 5.188189!
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Empty
        Me.Shape1.Height = 2.165354!
        Me.Shape1.Left = 0.04094489!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 0.0476378!
        Me.Shape1.Width = 3.543307!
        '
        'Picture2
        '
        Me.Picture2.Height = 0.7125986!
        Me.Picture2.ImageData = CType(resources.GetObject("Picture2.ImageData"), System.IO.Stream)
        Me.Picture2.Left = 0.2074803!
        Me.Picture2.Name = "Picture2"
        Me.Picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.Picture2.Top = 1.438977!
        Me.Picture2.Width = 3.246457!
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.Empty
        Me.Shape2.Height = 2.165354!
        Me.Shape2.Left = 3.68189!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape2.Top = 0.0476378!
        Me.Shape2.Width = 3.543307!
        '
        'Picture1
        '
        Me.Picture1.Height = 1.975197!
        Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"), System.IO.Stream)
        Me.Picture1.Left = 3.743307!
        Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Picture1.LineStyle = DataDynamics.ActiveReports.LineStyle.Solid
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Top = 0.1267717!
        Me.Picture1.Width = 3.405512!
        '
        'STAFF_BARCODE_B
        '
        Me.STAFF_BARCODE_B.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.STAFF_BARCODE_B.DataField = "STAFF_BARCODE"
        Me.STAFF_BARCODE_B.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.STAFF_BARCODE_B.Height = 0.6507874!
        Me.STAFF_BARCODE_B.Left = 0.8968505!
        Me.STAFF_BARCODE_B.Name = "STAFF_BARCODE_B"
        Me.STAFF_BARCODE_B.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.STAFF_BARCODE_B.Text = "9900000000011"
        Me.STAFF_BARCODE_B.Top = 0.1129922!
        Me.STAFF_BARCODE_B.Width = 2.066535!
        '
        'Line16
        '
        Me.Line16.Height = 0.0!
        Me.Line16.Left = 6.867717!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.005511811!
        Me.Line16.Width = 0.4031491!
        Me.Line16.X1 = 6.867717!
        Me.Line16.X2 = 7.270866!
        Me.Line16.Y1 = 0.005511811!
        Me.Line16.Y2 = 0.005511811!
        '
        'Line17
        '
        Me.Line17.Height = 0.0!
        Me.Line17.Left = 0.0!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.005511811!
        Me.Line17.Width = 0.3838583!
        Me.Line17.X1 = 0.0!
        Me.Line17.X2 = 0.3838583!
        Me.Line17.Y1 = 0.005511811!
        Me.Line17.Y2 = 0.005511811!
        '
        'Line18
        '
        Me.Line18.Height = 0.0!
        Me.Line18.Left = 0.0!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 2.268898!
        Me.Line18.Width = 0.3838583!
        Me.Line18.X1 = 0.0!
        Me.Line18.X2 = 0.3838583!
        Me.Line18.Y1 = 2.268898!
        Me.Line18.Y2 = 2.268898!
        '
        'Line19
        '
        Me.Line19.Height = 0.0!
        Me.Line19.Left = 6.878347!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 2.268898!
        Me.Line19.Width = 0.4031491!
        Me.Line19.X1 = 6.878347!
        Me.Line19.X2 = 7.281496!
        Me.Line19.Y1 = 2.268898!
        Me.Line19.Y2 = 2.268898!
        '
        'Line20
        '
        Me.Line20.Height = 0.335433!
        Me.Line20.Left = 7.270865!
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 1.933465!
        Me.Line20.Width = 0.001183033!
        Me.Line20.X1 = 7.272048!
        Me.Line20.X2 = 7.270865!
        Me.Line20.Y1 = 1.933465!
        Me.Line20.Y2 = 2.268898!
        '
        'Line21
        '
        Me.Line21.Height = 0.3354325!
        Me.Line21.Left = 7.269686!
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.005511811!
        Me.Line21.Width = 0.001180649!
        Me.Line21.X1 = 7.270867!
        Me.Line21.X2 = 7.269686!
        Me.Line21.Y1 = 0.005511811!
        Me.Line21.Y2 = 0.3409443!
        '
        'Line22
        '
        Me.Line22.Height = 0.3354325!
        Me.Line22.Left = 0.0011812!
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 0.0!
        Me.Line22.Width = 0.001180597!
        Me.Line22.X1 = 0.002361797!
        Me.Line22.X2 = 0.0011812!
        Me.Line22.Y1 = 0.0!
        Me.Line22.Y2 = 0.3354325!
        '
        'Line23
        '
        Me.Line23.Height = 0.335433!
        Me.Line23.Left = 0.0!
        Me.Line23.LineWeight = 1.0!
        Me.Line23.Name = "Line23"
        Me.Line23.Top = 2.151575!
        Me.Line23.Width = 0.001180597!
        Me.Line23.X1 = 0.001180597!
        Me.Line23.X2 = 0.0!
        Me.Line23.Y1 = 2.151575!
        Me.Line23.Y2 = 2.487008!
        '
        'Line24
        '
        Me.Line24.Height = 0.0!
        Me.Line24.Left = 3.432284!
        Me.Line24.LineWeight = 1.0!
        Me.Line24.Name = "Line24"
        Me.Line24.Top = 0.005511811!
        Me.Line24.Width = 0.4031448!
        Me.Line24.X1 = 3.432284!
        Me.Line24.X2 = 3.835429!
        Me.Line24.Y1 = 0.005511811!
        Me.Line24.Y2 = 0.005511811!
        '
        'Line25
        '
        Me.Line25.Height = 0.3354325!
        Me.Line25.Left = 3.636615!
        Me.Line25.LineWeight = 1.0!
        Me.Line25.Name = "Line25"
        Me.Line25.Top = 0.0!
        Me.Line25.Width = 0.001179934!
        Me.Line25.X1 = 3.637795!
        Me.Line25.X2 = 3.636615!
        Me.Line25.Y1 = 0.0!
        Me.Line25.Y2 = 0.3354325!
        '
        'Line26
        '
        Me.Line26.Height = 0.182677!
        Me.Line26.Left = 3.637795!
        Me.Line26.LineWeight = 1.0!
        Me.Line26.Name = "Line26"
        Me.Line26.Top = 2.109843!
        Me.Line26.Width = 0.001182079!
        Me.Line26.X1 = 3.638977!
        Me.Line26.X2 = 3.637795!
        Me.Line26.Y1 = 2.109843!
        Me.Line26.Y2 = 2.29252!
        '
        'Line27
        '
        Me.Line27.Height = 0.0!
        Me.Line27.Left = 3.453937!
        Me.Line27.LineWeight = 1.0!
        Me.Line27.Name = "Line27"
        Me.Line27.Top = 2.268898!
        Me.Line27.Width = 0.403146!
        Me.Line27.X1 = 3.453937!
        Me.Line27.X2 = 3.857083!
        Me.Line27.Y1 = 2.268898!
        Me.Line27.Y2 = 2.268898!
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.DataField = "STAFF_CODE"
        Me.STAFF_CODE_T.Height = 0.2!
        Me.STAFF_CODE_T.Left = 0.2645671!
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.OutputFormat = resources.GetString("STAFF_CODE_T.OutputFormat")
        Me.STAFF_CODE_T.Style = "font-size: 9.75pt; vertical-align: bottom"
        Me.STAFF_CODE_T.Text = "STAFF_CODE"
        Me.STAFF_CODE_T.Top = 1.127559!
        Me.STAFF_CODE_T.Width = 1.166929!
        '
        'ROLE_NAME_T
        '
        Me.ROLE_NAME_T.DataField = "ROLE_NAME"
        Me.ROLE_NAME_T.Height = 0.2!
        Me.ROLE_NAME_T.Left = 1.431496!
        Me.ROLE_NAME_T.Name = "ROLE_NAME_T"
        Me.ROLE_NAME_T.OutputFormat = resources.GetString("ROLE_NAME_T.OutputFormat")
        Me.ROLE_NAME_T.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.ROLE_NAME_T.Text = "ROLE_NAME"
        Me.ROLE_NAME_T.Top = 0.8539371!
        Me.ROLE_NAME_T.Width = 2.000788!
        '
        'rStaffCard
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.280987!
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.STAFF_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFF_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ROLE_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents STAFF_NAME_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Private WithEvents STAFF_BARCODE_B As DataDynamics.ActiveReports.Barcode
    Friend WithEvents ROLE_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Private WithEvents Line16 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line20 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line21 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line22 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line23 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line24 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line25 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line26 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line27 As DataDynamics.ActiveReports.Line
    Private WithEvents Picture2 As DataDynamics.ActiveReports.Picture
    Private WithEvents STAFF_CODE_T As DataDynamics.ActiveReports.TextBox
End Class
