<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rPointCard_Fore
    Inherits DataDynamics.ActiveReports.ActiveReport

    'ActiveReport がコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        '    If disposing Then
        '        hStream.Close()
        '        hStream = Nothing
        '    End If
        '    MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReport デザイナで必要です。
    'ActiveReport デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rPointCard_Fore))
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.PICTURE_1 = New DataDynamics.ActiveReports.Picture
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.PICTURE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.Empty
        Me.Detail.CanGrow = False
        Me.Detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PICTURE_1})
        Me.Detail.Height = 2.125984!
        Me.Detail.Name = "Detail"
        '
        'PICTURE_1
        '
        Me.PICTURE_1.DataField = "PICTURE_1"
        Me.PICTURE_1.Height = 2.047244!
        Me.PICTURE_1.ImageData = CType(resources.GetObject("PICTURE_1.ImageData"), System.IO.Stream)
        Me.PICTURE_1.Left = 0.04094489!
        Me.PICTURE_1.Name = "PICTURE_1"
        Me.PICTURE_1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.PICTURE_1.Top = 0.02047244!
        Me.PICTURE_1.Width = 3.307086!
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
        'rPointCard_Fore
        '
        Me.MasterReport = False
        Me.PageSettings.Collate = DataDynamics.ActiveReports.PageSettings.PrinterCollate.DontCollate
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Duplex = System.Drawing.Printing.Duplex.Vertical
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 21.26!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "ユーザー定義のサイズ"
        Me.PageSettings.PaperWidth = 33.86!
        Me.PrintWidth = 3.385827!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.PICTURE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents PICTURE_1 As DataDynamics.ActiveReports.Picture
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
End Class
