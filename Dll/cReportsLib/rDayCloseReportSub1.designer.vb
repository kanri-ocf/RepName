<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub1
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rDayCloseReportSub1))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.Label34 = New DataDynamics.ActiveReports.Label
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.Label37 = New DataDynamics.ActiveReports.Label
        Me.Label46 = New DataDynamics.ActiveReports.Label
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.KANJYOU = New DataDynamics.ActiveReports.TextBox
        Me.SUB_KANJYOU = New DataDynamics.ActiveReports.TextBox
        Me.MEMO = New DataDynamics.ActiveReports.TextBox
        Me.IN_CASH = New DataDynamics.ActiveReports.TextBox
        Me.OUT_CASH = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.T_IN_CASH = New DataDynamics.ActiveReports.TextBox
        Me.T_OUT_CASH = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KANJYOU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUB_KANJYOU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IN_CASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT_CASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_IN_CASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_OUT_CASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label31
        '
        Me.Label31.Height = 0.2!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.0!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "font-size: 8.25pt; font-weight: bold; text-align: left"
        Me.Label31.Text = "【入出金明細表】"
        Me.Label31.Top = 0.0!
        Me.Label31.Width = 1.281102!
        '
        'Label33
        '
        Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Height = 0.169685!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 1.002756!
        Me.Label33.Name = "Label33"
        Me.Label33.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label33.Style = "background-color: Silver; font-size: 8.25pt; text-align: center"
        Me.Label33.Text = "補助勘定科目"
        Me.Label33.Top = 0.1964567!
        Me.Label33.Width = 1.312992!
        '
        'Label34
        '
        Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Height = 0.1696851!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.0!
        Me.Label34.Name = "Label34"
        Me.Label34.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label34.Style = "background-color: Silver; font-size: 8.25pt; text-align: center"
        Me.Label34.Text = "勘定科目"
        Me.Label34.Top = 0.1964567!
        Me.Label34.Width = 1.002756!
        '
        'Label35
        '
        Me.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Height = 0.1696851!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 4.225591!
        Me.Label35.Name = "Label35"
        Me.Label35.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label35.Style = "background-color: Silver; font-size: 8.25pt; text-align: center"
        Me.Label35.Text = "入金額"
        Me.Label35.Top = 0.1968504!
        Me.Label35.Width = 1.296458!
        '
        'Label37
        '
        Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Height = 0.1696851!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 5.522048!
        Me.Label37.Name = "Label37"
        Me.Label37.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label37.Style = "background-color: Silver; font-size: 8.25pt; text-align: center"
        Me.Label37.Text = "出金額"
        Me.Label37.Top = 0.1968504!
        Me.Label37.Width = 1.296457!
        '
        'Label46
        '
        Me.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Height = 0.169685!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 2.315748!
        Me.Label46.Name = "Label46"
        Me.Label46.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label46.Style = "background-color: Silver; font-size: 8.25pt; text-align: center"
        Me.Label46.Text = "適用"
        Me.Label46.Top = 0.1968504!
        Me.Label46.Width = 1.909843!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.KANJYOU, Me.SUB_KANJYOU, Me.MEMO, Me.IN_CASH, Me.OUT_CASH})
        Me.Detail.Height = 0.16875!
        Me.Detail.Name = "Detail"
        '
        'KANJYOU
        '
        Me.KANJYOU.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.KANJYOU.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.KANJYOU.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.KANJYOU.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.KANJYOU.DataField = "KANJYOU"
        Me.KANJYOU.Height = 0.1688976!
        Me.KANJYOU.Left = 0.00275588!
        Me.KANJYOU.Name = "KANJYOU"
        Me.KANJYOU.Style = "font-size: 8.25pt"
        Me.KANJYOU.Text = "TextBox1"
        Me.KANJYOU.Top = 0.0!
        Me.KANJYOU.Width = 1.0!
        '
        'SUB_KANJYOU
        '
        Me.SUB_KANJYOU.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_KANJYOU.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_KANJYOU.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_KANJYOU.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SUB_KANJYOU.DataField = "SUB_KANJYOU"
        Me.SUB_KANJYOU.Height = 0.1688976!
        Me.SUB_KANJYOU.Left = 1.002756!
        Me.SUB_KANJYOU.Name = "SUB_KANJYOU"
        Me.SUB_KANJYOU.Style = "font-size: 8.25pt"
        Me.SUB_KANJYOU.Text = "TextBox1"
        Me.SUB_KANJYOU.Top = 0.0!
        Me.SUB_KANJYOU.Width = 1.312992!
        '
        'MEMO
        '
        Me.MEMO.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.DataField = "MEMO"
        Me.MEMO.Height = 0.1688976!
        Me.MEMO.Left = 2.315748!
        Me.MEMO.Name = "MEMO"
        Me.MEMO.Style = "font-size: 8.25pt"
        Me.MEMO.Text = "TextBox1"
        Me.MEMO.Top = 0.0!
        Me.MEMO.Width = 1.909842!
        '
        'IN_CASH
        '
        Me.IN_CASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_CASH.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_CASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_CASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_CASH.DataField = "IN_CASH"
        Me.IN_CASH.Height = 0.1688976!
        Me.IN_CASH.Left = 4.225591!
        Me.IN_CASH.Name = "IN_CASH"
        Me.IN_CASH.OutputFormat = resources.GetString("IN_CASH.OutputFormat")
        Me.IN_CASH.Style = "font-size: 8.25pt; text-align: right"
        Me.IN_CASH.Text = "TextBox1"
        Me.IN_CASH.Top = 0.0!
        Me.IN_CASH.Width = 1.296457!
        '
        'OUT_CASH
        '
        Me.OUT_CASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OUT_CASH.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OUT_CASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OUT_CASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OUT_CASH.DataField = "OUT_CASH"
        Me.OUT_CASH.Height = 0.1688976!
        Me.OUT_CASH.Left = 5.522047!
        Me.OUT_CASH.Name = "OUT_CASH"
        Me.OUT_CASH.OutputFormat = resources.GetString("OUT_CASH.OutputFormat")
        Me.OUT_CASH.Style = "font-size: 8.25pt; text-align: right"
        Me.OUT_CASH.Text = "TextBox1"
        Me.OUT_CASH.Top = 0.0!
        Me.OUT_CASH.Width = 1.296457!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.01041663!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.1582677!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New DataDynamics.ActiveReports.PaddingEx(100, 0, 100, 0)
        Me.Label1.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: justify; text-justify: " & _
            "distribute-all-lines"
        Me.Label1.Text = "合　　計"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 4.225591!
        '
        'T_IN_CASH
        '
        Me.T_IN_CASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_IN_CASH.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_IN_CASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_IN_CASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_IN_CASH.DataField = "IN_CASH"
        Me.T_IN_CASH.Height = 0.1582677!
        Me.T_IN_CASH.Left = 4.225591!
        Me.T_IN_CASH.Name = "T_IN_CASH"
        Me.T_IN_CASH.OutputFormat = resources.GetString("T_IN_CASH.OutputFormat")
        Me.T_IN_CASH.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right"
        Me.T_IN_CASH.SummaryGroup = "GroupHeader1"
        Me.T_IN_CASH.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.T_IN_CASH.Text = "TextBox1"
        Me.T_IN_CASH.Top = 2.793968E-9!
        Me.T_IN_CASH.Width = 1.296457!
        '
        'T_OUT_CASH
        '
        Me.T_OUT_CASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_OUT_CASH.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_OUT_CASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_OUT_CASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.T_OUT_CASH.DataField = "OUT_CASH"
        Me.T_OUT_CASH.Height = 0.1582677!
        Me.T_OUT_CASH.Left = 5.522047!
        Me.T_OUT_CASH.Name = "T_OUT_CASH"
        Me.T_OUT_CASH.OutputFormat = resources.GetString("T_OUT_CASH.OutputFormat")
        Me.T_OUT_CASH.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right"
        Me.T_OUT_CASH.SummaryGroup = "GroupHeader1"
        Me.T_OUT_CASH.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.T_OUT_CASH.Text = "TextBox1"
        Me.T_OUT_CASH.Top = 0.0!
        Me.T_OUT_CASH.Width = 1.296457!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label31, Me.Label34, Me.Label33, Me.Label35, Me.Label37, Me.Label46})
        Me.GroupHeader1.Height = 0.3438978!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.T_IN_CASH, Me.T_OUT_CASH})
        Me.GroupFooter1.Height = 0.15625!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rDayCloseReportSub1
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.864583!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KANJYOU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUB_KANJYOU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IN_CASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT_CASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_IN_CASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_OUT_CASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label34 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label46 As DataDynamics.ActiveReports.Label
    Private WithEvents KANJYOU As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SUB_KANJYOU As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MEMO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents IN_CASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OUT_CASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents T_IN_CASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents T_OUT_CASH As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
End Class
