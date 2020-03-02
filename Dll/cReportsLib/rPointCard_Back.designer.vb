<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rPointCard_Back
    Inherits DataDynamics.ActiveReports.ActiveReport

    'ActiveReport がコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'If disposing Then
        '    hStream.Close()
        '    hStream = Nothing
        'End If

        'MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReport デザイナで必要です。
    'ActiveReport デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rPointCard_Back))
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.BARCODE = New DataDynamics.ActiveReports.Barcode
        Me.PICTURE = New DataDynamics.ActiveReports.Picture
        Me.LABEL1 = New DataDynamics.ActiveReports.Label
        Me.LABEL3 = New DataDynamics.ActiveReports.Label
        Me.LABEL2 = New DataDynamics.ActiveReports.Label
        Me.LABEL4 = New DataDynamics.ActiveReports.Label
        Me.MESSAGE = New DataDynamics.ActiveReports.TextBox
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.PICTURE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LABEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LABEL3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LABEL2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LABEL4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MESSAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.Empty
        Me.Detail.CanGrow = False
        Me.Detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.BARCODE, Me.PICTURE, Me.LABEL1, Me.LABEL3, Me.LABEL2, Me.LABEL4, Me.MESSAGE})
        Me.Detail.Height = 2.125984!
        Me.Detail.Name = "Detail"
        '
        'BARCODE
        '
        Me.BARCODE.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.BARCODE.DataField = "BARCODE"
        Me.BARCODE.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.BARCODE.Height = 0.4976377!
        Me.BARCODE.Left = 1.780709!
        Me.BARCODE.Name = "BARCODE"
        Me.BARCODE.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.BARCODE.Text = "9900000000011"
        Me.BARCODE.Top = 0.6326772!
        Me.BARCODE.Width = 1.479134!
        '
        'PICTURE
        '
        Me.PICTURE.DataField = "PICTURE"
        Me.PICTURE.Height = 0.492126!
        Me.PICTURE.ImageData = CType(resources.GetObject("PICTURE.ImageData"), System.IO.Stream)
        Me.PICTURE.Left = 1.625197!
        Me.PICTURE.Name = "PICTURE"
        Me.PICTURE.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.PICTURE.Top = 0.103937!
        Me.PICTURE.Width = 1.673228!
        '
        'LABEL1
        '
        Me.LABEL1.DataField = "LABEL1"
        Me.LABEL1.Height = 0.2!
        Me.LABEL1.HyperLink = Nothing
        Me.LABEL1.Left = 0.08307113!
        Me.LABEL1.Name = "LABEL1"
        Me.LABEL1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set: 128"
        Me.LABEL1.Text = "（御署名）"
        Me.LABEL1.Top = 0.07637793!
        Me.LABEL1.Width = 1.0!
        '
        'LABEL3
        '
        Me.LABEL3.DataField = "LABEL3"
        Me.LABEL3.Height = 0.2!
        Me.LABEL3.HyperLink = Nothing
        Me.LABEL3.Left = 0.08307113!
        Me.LABEL3.Name = "LABEL3"
        Me.LABEL3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.LABEL3.Text = "（発行日）"
        Me.LABEL3.Top = 0.5858265!
        Me.LABEL3.Width = 1.0!
        '
        'LABEL2
        '
        Me.LABEL2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL2.DataField = "LABEL2"
        Me.LABEL2.Height = 0.2952756!
        Me.LABEL2.HyperLink = Nothing
        Me.LABEL2.Left = 0.08307113!
        Me.LABEL2.LineSpacing = 1.0!
        Me.LABEL2.Name = "LABEL2"
        Me.LABEL2.Style = ""
        Me.LABEL2.Text = ""
        Me.LABEL2.Top = 0.2074803!
        Me.LABEL2.Width = 1.574803!
        '
        'LABEL4
        '
        Me.LABEL4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LABEL4.DataField = "LABEL4"
        Me.LABEL4.Height = 0.2952756!
        Me.LABEL4.HyperLink = Nothing
        Me.LABEL4.Left = 0.08307113!
        Me.LABEL4.LineSpacing = 1.0!
        Me.LABEL4.Name = "LABEL4"
        Me.LABEL4.Style = "vertical-align: middle"
        Me.LABEL4.Text = "　　　　　年　　　月　　　日"
        Me.LABEL4.Top = 0.7169291!
        Me.LABEL4.Width = 1.574803!
        '
        'MESSAGE
        '
        Me.MESSAGE.CanGrow = False
        Me.MESSAGE.DataField = "MESSAGE"
        Me.MESSAGE.Height = 0.8354331!
        Me.MESSAGE.Left = 0.08307111!
        Me.MESSAGE.Name = "MESSAGE"
        Me.MESSAGE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 6pt"
        Me.MESSAGE.Text = "MESSAGE"
        Me.MESSAGE.Top = 1.198031!
        Me.MESSAGE.Width = 3.215355!
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
        'rPointCard_Back
        '
        Me.MasterReport = False
        Me.PageSettings.Collate = DataDynamics.ActiveReports.PageSettings.PrinterCollate.DontCollate
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Duplex = System.Drawing.Printing.Duplex.Simplex
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
        CType(Me.PICTURE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LABEL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LABEL3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LABEL2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LABEL4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MESSAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents BARCODE As DataDynamics.ActiveReports.Barcode
    Private WithEvents PICTURE As DataDynamics.ActiveReports.Picture
    Private WithEvents LABEL1 As DataDynamics.ActiveReports.Label
    Private WithEvents LABEL4 As DataDynamics.ActiveReports.Label
    Private WithEvents LABEL3 As DataDynamics.ActiveReports.Label
    Private WithEvents LABEL2 As DataDynamics.ActiveReports.Label
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Private WithEvents MESSAGE As DataDynamics.ActiveReports.TextBox
End Class
