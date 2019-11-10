<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rStaffCard_Fore
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rStaffCard_Fore))
        Me.STAFF_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.LOGO_PIC = New DataDynamics.ActiveReports.Picture
        Me.STAFF_BARCODE_B = New DataDynamics.ActiveReports.Barcode
        Me.STAFF_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.ROLE_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.STAFF_PIC = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        CType(Me.STAFF_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LOGO_PIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFF_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ROLE_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFF_PIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.DataField = "STAFF_NAME"
        Me.STAFF_NAME_T.Height = 0.2476379!
        Me.STAFF_NAME_T.Left = 1.441732!
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Style = "font-size: 14.25pt; vertical-align: bottom"
        Me.STAFF_NAME_T.Text = "STAFF_NAME"
        Me.STAFF_NAME_T.Top = 0.5358268!
        Me.STAFF_NAME_T.Width = 1.803544!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.LOGO_PIC, Me.STAFF_BARCODE_B, Me.STAFF_CODE_T, Me.STAFF_NAME_T, Me.ROLE_NAME_T, Me.STAFF_PIC, Me.Line1, Me.Line2, Me.Line3})
        Me.Detail.Height = 2.125984!
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Empty
        Me.Shape1.Height = 2.047244!
        Me.Shape1.Left = 0.04094489!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 0.03070866!
        Me.Shape1.Width = 3.307086!
        '
        'LOGO_PIC
        '
        Me.LOGO_PIC.DataField = "LOGO_PIC"
        Me.LOGO_PIC.Height = 0.4606299!
        Me.LOGO_PIC.ImageData = Nothing
        Me.LOGO_PIC.Left = 0.1551181!
        Me.LOGO_PIC.Name = "LOGO_PIC"
        Me.LOGO_PIC.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.LOGO_PIC.Title = "LOGO_PIC"
        Me.LOGO_PIC.Top = 1.502756!
        Me.LOGO_PIC.Width = 3.017323!
        '
        'STAFF_BARCODE_B
        '
        Me.STAFF_BARCODE_B.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.STAFF_BARCODE_B.DataField = "STAFF_BARCODE"
        Me.STAFF_BARCODE_B.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.STAFF_BARCODE_B.Height = 0.568504!
        Me.STAFF_BARCODE_B.Left = 1.441732!
        Me.STAFF_BARCODE_B.Name = "STAFF_BARCODE_B"
        Me.STAFF_BARCODE_B.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.STAFF_BARCODE_B.Text = "9900000000011"
        Me.STAFF_BARCODE_B.Top = 0.8818898!
        Me.STAFF_BARCODE_B.Width = 1.803544!
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.DataField = "STAFF_CODE"
        Me.STAFF_CODE_T.Height = 0.2!
        Me.STAFF_CODE_T.Left = 1.441732!
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.OutputFormat = resources.GetString("STAFF_CODE_T.OutputFormat")
        Me.STAFF_CODE_T.Style = "font-size: 9.75pt; vertical-align: bottom"
        Me.STAFF_CODE_T.Text = "STAFF_CODE"
        Me.STAFF_CODE_T.Top = 0.3255906!
        Me.STAFF_CODE_T.Width = 1.166929!
        '
        'ROLE_NAME_T
        '
        Me.ROLE_NAME_T.DataField = "ROLE_NAME"
        Me.ROLE_NAME_T.Height = 0.2!
        Me.ROLE_NAME_T.Left = 1.441732!
        Me.ROLE_NAME_T.Name = "ROLE_NAME_T"
        Me.ROLE_NAME_T.OutputFormat = resources.GetString("ROLE_NAME_T.OutputFormat")
        Me.ROLE_NAME_T.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.ROLE_NAME_T.Text = "ROLE_NAME"
        Me.ROLE_NAME_T.Top = 0.1051181!
        Me.ROLE_NAME_T.Width = 1.657087!
        '
        'STAFF_PIC
        '
        Me.STAFF_PIC.DataField = "STAFF_PIC"
        Me.STAFF_PIC.Height = 1.307087!
        Me.STAFF_PIC.HyperLink = Nothing
        Me.STAFF_PIC.ImageData = Nothing
        Me.STAFF_PIC.Left = 0.1244095!
        Me.STAFF_PIC.LineColor = System.Drawing.Color.LightSteelBlue
        Me.STAFF_PIC.LineStyle = DataDynamics.ActiveReports.LineStyle.Solid
        Me.STAFF_PIC.LineWeight = 2.0!
        Me.STAFF_PIC.Name = "STAFF_PIC"
        Me.STAFF_PIC.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.STAFF_PIC.Top = 0.1433071!
        Me.STAFF_PIC.Width = 1.179134!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 1.441732!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.3255906!
        Me.Line1.Width = 1.803544!
        Me.Line1.X1 = 1.441732!
        Me.Line1.X2 = 3.245276!
        Me.Line1.Y1 = 0.3255906!
        Me.Line1.Y2 = 0.3255906!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 1.441732!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.5358268!
        Me.Line2.Width = 1.803543!
        Me.Line2.X1 = 1.441732!
        Me.Line2.X2 = 3.245275!
        Me.Line2.Y1 = 0.5358268!
        Me.Line2.Y2 = 0.5358268!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 1.441732!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.7767717!
        Me.Line3.Width = 1.803543!
        Me.Line3.X1 = 1.441732!
        Me.Line3.X2 = 3.245275!
        Me.Line3.Y1 = 0.7767717!
        Me.Line3.Y2 = 0.7767717!
        '
        'rStaffCard_Fore
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 21.25984!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "ユーザー定義のサイズ"
        Me.PageSettings.PaperWidth = 33.85827!
        Me.PrintWidth = 3.385827!
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.STAFF_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LOGO_PIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFF_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ROLE_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFF_PIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents STAFF_NAME_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Private WithEvents STAFF_BARCODE_B As DataDynamics.ActiveReports.Barcode
    Friend WithEvents ROLE_NAME_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents LOGO_PIC As DataDynamics.ActiveReports.Picture
    Private WithEvents STAFF_CODE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents STAFF_PIC As DataDynamics.ActiveReports.Picture
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
End Class
