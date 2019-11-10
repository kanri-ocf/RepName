<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rDayCloseReportSub6 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rDayCloseReportSub6))
        Dim ChartArea1 As DataDynamics.ActiveReports.Chart.ChartArea = New DataDynamics.ActiveReports.Chart.ChartArea
        Dim Axis1 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis2 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis3 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis4 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis5 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Legend1 As DataDynamics.ActiveReports.Chart.Legend = New DataDynamics.ActiveReports.Chart.Legend
        Dim Title1 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim Title2 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim Series1 As DataDynamics.ActiveReports.Chart.Series = New DataDynamics.ActiveReports.Chart.Series
        Dim Title3 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.TIME_SALES = New DataDynamics.ActiveReports.ChartControl
        Me.CHANNEL_NAME = New DataDynamics.ActiveReports.TextBox
        Me.CREATE_DATE = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.チャネル名 = New DataDynamics.ActiveReports.Field
        Me.登録日 = New DataDynamics.ActiveReports.Field
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.TIME_SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CREATE_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TIME_SALES})
        Me.Detail.Height = 4.531496!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'TIME_SALES
        '
        Me.TIME_SALES.AutoRefresh = True
        Me.TIME_SALES.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.SteelBlue, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, Nothing, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched)
        Axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical
        Axis1.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis1.Labels.AddRange(New String() {""})
        Axis1.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line, New DataDynamics.ActiveReports.Chart.Graphics.Line, 1, 0.0!, False)
        Axis1.Max = 25
        Axis1.Min = 1
        Axis1.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line, New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0), 1, 5.0!, True)
        Axis1.Title = "時間帯"
        Axis1.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("ＭＳ Ｐゴシック", 8.0!))
        Axis2.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical
        Axis2.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis2.LabelsGap = 0
        Axis2.LabelsVisible = False
        Axis2.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis2.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 1.0!, False)
        Axis2.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis2.Position = 0
        Axis2.TickOffset = 0
        Axis2.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis2.Visible = False
        Axis3.DisplayScale = True
        Axis3.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis3.LabelFormat = "{0:#,##0}"
        Axis3.Labels.AddRange(New String() {""})
        '        Axis3.LabelsAtBottom = True
        Axis3.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line, 1000, 5.0!)
        Axis3.Min = 0
        Axis3.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line, New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Black, 0), 500, 0.0!, False)
        Axis3.Position = -1
        Axis3.Title = "売上高"
        Axis3.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("ＭＳ Ｐゴシック", 8.0!))
        Axis4.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis4.LabelsVisible = False
        Axis4.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis4.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 1.0!, True)
        Axis4.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, True)
        Axis4.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis4.Visible = False
        Axis5.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis5.LabelsGap = 0
        Axis5.LabelsVisible = False
        Axis5.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis5.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis5.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis5.Position = 0
        Axis5.TickOffset = 0
        Axis5.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis5.Visible = False
        ChartArea1.Axes.AddRange(New DataDynamics.ActiveReports.Chart.AxisBase() {Axis1, Axis2, Axis3, Axis4, Axis5})
        ChartArea1.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, Nothing, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched)
        ChartArea1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        ChartArea1.Light = New DataDynamics.ActiveReports.Chart.Light(New DataDynamics.ActiveReports.Chart.Graphics.Point3d(10.0!, 40.0!, 20.0!), DataDynamics.ActiveReports.Chart.LightType.InfiniteDirectional, 0.3!)
        ChartArea1.Name = "TIME_SALES"
        ChartArea1.WallXY = New DataDynamics.ActiveReports.Chart.PlaneItem(DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.None)
        ChartArea1.WallXZ = New DataDynamics.ActiveReports.Chart.PlaneItem(New DataDynamics.ActiveReports.Chart.Graphics.Backdrop, False, 0.0!)
        ChartArea1.WallYZ = New DataDynamics.ActiveReports.Chart.PlaneItem(New DataDynamics.ActiveReports.Chart.Graphics.Backdrop, False, 0.0!)
        ChartArea1.ZDepthRatio = 0.0!
        Me.TIME_SALES.ChartAreas.AddRange(New DataDynamics.ActiveReports.Chart.ChartArea() {ChartArea1})
        Me.TIME_SALES.ChartBorder = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Me.TIME_SALES.Height = 4.51063!
        Me.TIME_SALES.Left = 0.0!
        Legend1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right
        Legend1.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(System.Drawing.Color.White, CType(128, Byte))
        Legend1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line, 0, System.Drawing.Color.Black)
        Legend1.DockArea = Nothing
        Title1.Backdrop = New DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, Nothing, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched)
        Title1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Title1.DockArea = Nothing
        Title1.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title1.Name = ""
        Title1.Text = ""
        Title1.Visible = False
        Legend1.Footer = Title1
        Legend1.GridLayout = New DataDynamics.ActiveReports.Chart.GridLayout(0, 1)
        Title2.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 2), 0, System.Drawing.Color.Black)
        Title2.DockArea = Nothing
        Title2.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title2.Name = ""
        Title2.Text = "Legend"
        Legend1.Header = Title2
        Legend1.LabelsFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Legend1.MarginX = 20
        Legend1.MarginY = 20
        Legend1.Name = "defaultLegend"
        Legend1.Visible = False
        Me.TIME_SALES.Legends.AddRange(New DataDynamics.ActiveReports.Chart.Legend() {Legend1})
        Me.TIME_SALES.Name = "TIME_SALES"
        Series1.AxisX = Axis1
        Series1.AxisY = Axis3
        Series1.ChartArea = ChartArea1
        Series1.Legend = Nothing
        Series1.LegendText = ""
        Series1.Name = "TIME_SALES"
        Series1.Properties = New DataDynamics.ActiveReports.Chart.CustomProperties(New DataDynamics.ActiveReports.Chart.KeyValuePair() {New DataDynamics.ActiveReports.Chart.KeyValuePair("Gap", 10.0!), New DataDynamics.ActiveReports.Chart.KeyValuePair("BarType", DataDynamics.ActiveReports.Chart.BarType.Bar)})
        Series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar2D
        Series1.ValueMembersY = "TIME_SALES"
        Series1.ValueMemberX = "TIME_ZONE"
        Me.TIME_SALES.Series.AddRange(New DataDynamics.ActiveReports.Chart.Series() {Series1})
        Title3.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center
        Title3.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Title3.DockArea = Nothing
        Title3.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("ＭＳ Ｐゴシック", 8.0!))
        Title3.Name = "時間別売上推移"
        Title3.Text = "時間別売上推移"
        Title3.Visible = False
        Me.TIME_SALES.Titles.AddRange(New DataDynamics.ActiveReports.Chart.Title() {Title3})
        Me.TIME_SALES.Top = 0.02086614!
        Me.TIME_SALES.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting
        Me.TIME_SALES.Width = 7.187008!
        '
        'CHANNEL_NAME
        '
        Me.CHANNEL_NAME.DataField = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Height = 0.1480315!
        Me.CHANNEL_NAME.Left = 0.0!
        Me.CHANNEL_NAME.Name = "CHANNEL_NAME"
        Me.CHANNEL_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 128"
        Me.CHANNEL_NAME.Text = "【チャネル名】"
        Me.CHANNEL_NAME.Top = 0.0!
        Me.CHANNEL_NAME.Width = 1.520866!
        '
        'CREATE_DATE
        '
        Me.CREATE_DATE.DataField = "CREATE_DATE"
        Me.CREATE_DATE.Height = 0.2!
        Me.CREATE_DATE.Left = 0.0!
        Me.CREATE_DATE.Name = "CREATE_DATE"
        Me.CREATE_DATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 128"
        Me.CREATE_DATE.Text = "登録日"
        Me.CREATE_DATE.Top = 0.0!
        Me.CREATE_DATE.Width = 1.520866!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label1
        '
        Me.Label1.Height = 0.2291667!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1"
        Me.Label1.Text = "【時間帯別売上集計】"
        Me.Label1.Top = 3.72529E-9!
        Me.Label1.Width = 1.208!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1})
        Me.GroupHeader1.Height = 0.1041667!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'チャネル名
        '
        Me.チャネル名.DefaultValue = Nothing
        Me.チャネル名.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.[String]
        Me.チャネル名.Formula = Nothing
        Me.チャネル名.Name = "チャネル名"
        Me.チャネル名.Tag = Nothing
        '
        '登録日
        '
        Me.登録日.DefaultValue = Nothing
        Me.登録日.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.[String]
        Me.登録日.Formula = Nothing
        Me.登録日.Name = "登録日"
        Me.登録日.Tag = Nothing
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CHANNEL_NAME})
        Me.GroupHeader2.DataField = "CHANNEL_NAME"
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader2.Height = 0.15625!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CREATE_DATE})
        Me.GroupHeader3.DataField = "CREATE_DATE"
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader3.Height = 0.15625!
        Me.GroupHeader3.KeepTogether = True
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'rDayCloseReportSub6
        '
        Me.MasterReport = False
        Me.CalculatedFields.Add(Me.チャネル名)
        Me.CalculatedFields.Add(Me.登録日)
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.21875!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TIME_SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHANNEL_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CREATE_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents チャネル名 As DataDynamics.ActiveReports.Field
    Private WithEvents 登録日 As DataDynamics.ActiveReports.Field
    Private WithEvents CHANNEL_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents CREATE_DATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Public WithEvents TIME_SALES As DataDynamics.ActiveReports.ChartControl
End Class
