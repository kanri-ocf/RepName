<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rMemberCard_Back
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rMemberCard_Back))
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.PIC_P = New DataDynamics.ActiveReports.Picture
        Me.MESSAGE = New DataDynamics.ActiveReports.TextBox
        CType(Me.PIC_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MESSAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.PIC_P, Me.MESSAGE})
        Me.Detail.Height = 2.125984!
        Me.Detail.Name = "Detail"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.White
        Me.Shape2.Height = 2.047244!
        Me.Shape2.Left = 0.04094489!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape2.Top = 0.03070866!
        Me.Shape2.Width = 3.307086!
        '
        'PIC_P
        '
        Me.PIC_P.DataField = "PIC"
        Me.PIC_P.Height = 0.760236!
        Me.PIC_P.ImageData = CType(resources.GetObject("PIC_P.ImageData"), System.IO.Stream)
        Me.PIC_P.Left = 0.2181102!
        Me.PIC_P.Name = "PIC_P"
        Me.PIC_P.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.PIC_P.Title = "PIC"
        Me.PIC_P.Top = 1.229528!
        Me.PIC_P.Width = 3.0!
        '
        'MESSAGE
        '
        Me.MESSAGE.CanGrow = False
        Me.MESSAGE.DataField = "MESSAGE"
        Me.MESSAGE.Height = 1.043701!
        Me.MESSAGE.Left = 0.1440945!
        Me.MESSAGE.Name = "MESSAGE"
        Me.MESSAGE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 6pt"
        Me.MESSAGE.Text = "MESSAGE"
        Me.MESSAGE.Top = 0.1271654!
        Me.MESSAGE.Width = 3.094489!
        '
        'rMemberCard_Back
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
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
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.PIC_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MESSAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Private WithEvents PIC_P As DataDynamics.ActiveReports.Picture
    Private WithEvents MESSAGE As DataDynamics.ActiveReports.TextBox
End Class
