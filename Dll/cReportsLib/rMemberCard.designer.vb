<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rMemberCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rMemberCard))
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.MEMBER_NAME = New DataDynamics.ActiveReports.TextBox
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.Picture1 = New DataDynamics.ActiveReports.Picture
        Me.OPTION_3_L = New DataDynamics.ActiveReports.Label
        Me.OPTION_2_L = New DataDynamics.ActiveReports.Label
        Me.OPTION_1_L = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.END_REG_DATE = New DataDynamics.ActiveReports.TextBox
        Me.MEMBER_CODE = New DataDynamics.ActiveReports.Barcode
        Me.BIRTHDAY = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.ADDRESS = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.SUBMEMBER_NAME = New DataDynamics.ActiveReports.TextBox
        Me.OPTION_3_T = New DataDynamics.ActiveReports.TextBox
        Me.OPTION_2_T = New DataDynamics.ActiveReports.TextBox
        Me.OPTION_1_T = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.MEMBER_PIC = New DataDynamics.ActiveReports.Picture
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Shape3 = New DataDynamics.ActiveReports.Shape
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line8 = New DataDynamics.ActiveReports.Line
        Me.Line9 = New DataDynamics.ActiveReports.Line
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line12 = New DataDynamics.ActiveReports.Line
        Me.Line13 = New DataDynamics.ActiveReports.Line
        Me.Line14 = New DataDynamics.ActiveReports.Line
        Me.Line15 = New DataDynamics.ActiveReports.Line
        Me.ST_REG_DATE = New DataDynamics.ActiveReports.TextBox
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
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMBER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_3_L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_2_L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_1_L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.END_REG_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BIRTHDAY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUBMEMBER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_3_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_2_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_1_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMBER_PIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ST_REG_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Label7
        '
        Me.Label7.Height = 0.1999999!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.09724358!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label7.Text = "お名前"
        Me.Label7.Top = 0.07677142!
        Me.Label7.Width = 0.4783466!
        '
        'MEMBER_NAME
        '
        Me.MEMBER_NAME.DataField = "MEMBER_NAME"
        Me.MEMBER_NAME.Height = 0.2!
        Me.MEMBER_NAME.Left = 0.7003932!
        Me.MEMBER_NAME.Name = "MEMBER_NAME"
        Me.MEMBER_NAME.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.MEMBER_NAME.Text = "MEMBER_NAME"
        Me.MEMBER_NAME.Top = 0.07677142!
        Me.MEMBER_NAME.Width = 1.176772!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Shape2, Me.Picture1, Me.OPTION_3_L, Me.OPTION_2_L, Me.OPTION_1_L, Me.Label6, Me.END_REG_DATE, Me.MEMBER_CODE, Me.BIRTHDAY, Me.Label4, Me.ADDRESS, Me.MEMBER_NAME, Me.Label3, Me.Label2, Me.Label7, Me.SUBMEMBER_NAME, Me.OPTION_3_T, Me.OPTION_2_T, Me.OPTION_1_T, Me.Label5, Me.Line1, Me.Line2, Me.MEMBER_PIC, Me.Label1, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line8, Me.Line9, Me.Line11, Me.Line12, Me.Line13, Me.Line14, Me.Line15, Me.ST_REG_DATE, Me.Line16, Me.Line17, Me.Line18, Me.Line19, Me.Line20, Me.Line21, Me.Line22, Me.Line23, Me.Line24, Me.Line25, Me.Line26, Me.Line27, Me.Shape3, Me.Line10})
        Me.Detail.Height = 2.285596!
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.Height = 2.165354!
        Me.Shape1.Left = 0.04409489!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 0.04763846!
        Me.Shape1.Width = 3.543307!
        '
        'Shape2
        '
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
        Me.Picture1.Left = 3.743308!
        Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Picture1.LineStyle = DataDynamics.ActiveReports.LineStyle.Solid
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Top = 0.1267716!
        Me.Picture1.Width = 3.405512!
        '
        'OPTION_3_L
        '
        Me.OPTION_3_L.Height = 0.1377954!
        Me.OPTION_3_L.HyperLink = Nothing
        Me.OPTION_3_L.Left = 2.263781!
        Me.OPTION_3_L.Name = "OPTION_3_L"
        Me.OPTION_3_L.Style = "font-size: 8.25pt; text-align: center; vertical-align: middle"
        Me.OPTION_3_L.Text = "物販"
        Me.OPTION_3_L.Top = 1.848426!
        Me.OPTION_3_L.Width = 0.5330709!
        '
        'OPTION_2_L
        '
        Me.OPTION_2_L.Height = 0.1377954!
        Me.OPTION_2_L.HyperLink = Nothing
        Me.OPTION_2_L.Left = 1.642126!
        Me.OPTION_2_L.Name = "OPTION_2_L"
        Me.OPTION_2_L.Style = "font-size: 8.25pt; text-align: center; vertical-align: middle"
        Me.OPTION_2_L.Text = "シャンプー"
        Me.OPTION_2_L.Top = 1.848425!
        Me.OPTION_2_L.Width = 0.5330709!
        '
        'OPTION_1_L
        '
        Me.OPTION_1_L.Height = 0.1377954!
        Me.OPTION_1_L.HyperLink = Nothing
        Me.OPTION_1_L.Left = 1.038189!
        Me.OPTION_1_L.Name = "OPTION_1_L"
        Me.OPTION_1_L.Style = "font-size: 8.25pt; text-align: center; vertical-align: middle"
        Me.OPTION_1_L.Text = "トリミング"
        Me.OPTION_1_L.Top = 1.848425!
        Me.OPTION_1_L.Width = 0.5330709!
        '
        'Label6
        '
        Me.Label6.Height = 0.1999999!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.09724358!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label6.Text = "適応種別"
        Me.Label6.Top = 1.901968!
        Me.Label6.Width = 0.7519687!
        '
        'END_REG_DATE
        '
        Me.END_REG_DATE.DataField = "END_REG_DATE"
        Me.END_REG_DATE.Height = 0.231496!
        Me.END_REG_DATE.Left = 0.05433017!
        Me.END_REG_DATE.Name = "END_REG_DATE"
        Me.END_REG_DATE.OutputFormat = resources.GetString("END_REG_DATE.OutputFormat")
        Me.END_REG_DATE.Style = "background-color: #8080FF; font-size: 11.25pt; font-weight: bold; text-align: cen" & _
            "ter; vertical-align: middle"
        Me.END_REG_DATE.Text = "END_REG_DATE"
        Me.END_REG_DATE.Top = 0.7940943!
        Me.END_REG_DATE.Width = 2.270866!
        '
        'MEMBER_CODE
        '
        Me.MEMBER_CODE.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.MEMBER_CODE.DataField = "MEMBER_CODE"
        Me.MEMBER_CODE.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.MEMBER_CODE.Height = 0.4480315!
        Me.MEMBER_CODE.Left = 0.09724358!
        Me.MEMBER_CODE.Name = "MEMBER_CODE"
        Me.MEMBER_CODE.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.MEMBER_CODE.Text = "9900000000011"
        Me.MEMBER_CODE.Top = 1.042913!
        Me.MEMBER_CODE.Width = 2.166536!
        '
        'BIRTHDAY
        '
        Me.BIRTHDAY.DataField = "BIRTHDAY"
        Me.BIRTHDAY.Height = 0.2!
        Me.BIRTHDAY.Left = 2.437795!
        Me.BIRTHDAY.Name = "BIRTHDAY"
        Me.BIRTHDAY.OutputFormat = resources.GetString("BIRTHDAY.OutputFormat")
        Me.BIRTHDAY.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.BIRTHDAY.Text = "BIRTHDAY"
        Me.BIRTHDAY.Top = 0.08622022!
        Me.BIRTHDAY.Width = 1.062599!
        '
        'Label4
        '
        Me.Label4.Height = 0.1999999!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 1.956693!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label4.Text = "誕生日"
        Me.Label4.Top = 0.07677142!
        Me.Label4.Width = 0.4811024!
        '
        'ADDRESS
        '
        Me.ADDRESS.DataField = "ADDRESS"
        Me.ADDRESS.Height = 0.2!
        Me.ADDRESS.Left = 0.7003932!
        Me.ADDRESS.Name = "ADDRESS"
        Me.ADDRESS.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.ADDRESS.Text = "ADDRESS"
        Me.ADDRESS.Top = 0.3334643!
        Me.ADDRESS.Width = 2.8!
        '
        'Label3
        '
        Me.Label3.Height = 0.1999999!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.09724358!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label3.Text = "発行日"
        Me.Label3.Top = 0.579921!
        Me.Label3.Width = 0.5405512!
        '
        'Label2
        '
        Me.Label2.Height = 0.1999999!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.09724358!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label2.Text = "住　所"
        Me.Label2.Top = 0.3129918!
        Me.Label2.Width = 0.4783466!
        '
        'SUBMEMBER_NAME
        '
        Me.SUBMEMBER_NAME.DataField = "SUBMEMBER_NAME"
        Me.SUBMEMBER_NAME.Height = 0.2!
        Me.SUBMEMBER_NAME.Left = 1.009449!
        Me.SUBMEMBER_NAME.Name = "SUBMEMBER_NAME"
        Me.SUBMEMBER_NAME.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.SUBMEMBER_NAME.Text = "SUBMEMBER_NAME"
        Me.SUBMEMBER_NAME.Top = 1.583858!
        Me.SUBMEMBER_NAME.Width = 2.490945!
        '
        'OPTION_3_T
        '
        Me.OPTION_3_T.DataField = "B_FLG"
        Me.OPTION_3_T.Height = 0.131496!
        Me.OPTION_3_T.Left = 2.263781!
        Me.OPTION_3_T.Name = "OPTION_3_T"
        Me.OPTION_3_T.Style = "font-size: 6.75pt; text-align: center; vertical-align: middle"
        Me.OPTION_3_T.Text = "●"
        Me.OPTION_3_T.Top = 2.03819!
        Me.OPTION_3_T.Width = 0.5330709!
        '
        'OPTION_2_T
        '
        Me.OPTION_2_T.DataField = "S_FLG"
        Me.OPTION_2_T.Height = 0.131496!
        Me.OPTION_2_T.Left = 1.642126!
        Me.OPTION_2_T.Name = "OPTION_2_T"
        Me.OPTION_2_T.Style = "font-size: 6.75pt; text-align: center; vertical-align: middle"
        Me.OPTION_2_T.Text = "●"
        Me.OPTION_2_T.Top = 2.038976!
        Me.OPTION_2_T.Width = 0.5330709!
        '
        'OPTION_1_T
        '
        Me.OPTION_1_T.DataField = "T_FLG"
        Me.OPTION_1_T.Height = 0.131496!
        Me.OPTION_1_T.Left = 1.038189!
        Me.OPTION_1_T.Name = "OPTION_1_T"
        Me.OPTION_1_T.Style = "font-size: 6.75pt; text-align: center; vertical-align: middle"
        Me.OPTION_1_T.Text = "●"
        Me.OPTION_1_T.Top = 2.038976!
        Me.OPTION_1_T.Width = 0.5330709!
        '
        'Label5
        '
        Me.Label5.Height = 0.1999999!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.09724358!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label5.Text = "保護者氏名"
        Me.Label5.Top = 1.594094!
        Me.Label5.Width = 0.7519685!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.04409388!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.2972438!
        Me.Line1.Width = 3.543308!
        Me.Line1.X1 = 0.04409388!
        Me.Line1.X2 = 3.587402!
        Me.Line1.Y1 = 0.2972438!
        Me.Line1.Y2 = 0.2972438!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.04409398!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.5484249!
        Me.Line2.Width = 3.543308!
        Me.Line2.X1 = 0.04409398!
        Me.Line2.X2 = 3.587402!
        Me.Line2.Y1 = 0.5484249!
        Me.Line2.Y2 = 0.5484249!
        '
        'MEMBER_PIC
        '
        Me.MEMBER_PIC.DataField = "MEMBER_PIC"
        Me.MEMBER_PIC.Height = 0.9637796!
        Me.MEMBER_PIC.ImageData = CType(resources.GetObject("MEMBER_PIC.ImageData"), System.IO.Stream)
        Me.MEMBER_PIC.Left = 2.605118!
        Me.MEMBER_PIC.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MEMBER_PIC.LineStyle = DataDynamics.ActiveReports.LineStyle.Solid
        Me.MEMBER_PIC.LineWeight = 5.0!
        Me.MEMBER_PIC.Name = "MEMBER_PIC"
        Me.MEMBER_PIC.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.MEMBER_PIC.Top = 0.5791335!
        Me.MEMBER_PIC.Width = 0.9055118!
        '
        'Label1
        '
        Me.Label1.Height = 0.984252!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.31496!
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 10, 0, 10)
        Me.Label1.RightToLeft = True
        Me.Label1.Style = "color: #8080FF; text-align: center; text-justify: auto; vertical-align: middle"
        Me.Label1.Text = "会　員　証"
        Me.Label1.Top = 0.5586611!
        Me.Label1.Width = 0.2795275!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.04409398!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.561811!
        Me.Line3.Width = 3.543308!
        Me.Line3.X1 = 0.04409398!
        Me.Line3.X2 = 3.587402!
        Me.Line3.Y1 = 1.561811!
        Me.Line3.Y2 = 1.561811!
        '
        'Line4
        '
        Me.Line4.Height = 1.013386!
        Me.Line4.Left = 2.31496!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.5484249!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 2.31496!
        Me.Line4.X2 = 2.31496!
        Me.Line4.Y1 = 0.5484249!
        Me.Line4.Y2 = 1.561811!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.04409398!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 1.797244!
        Me.Line5.Width = 3.543308!
        Me.Line5.X1 = 0.04409398!
        Me.Line5.X2 = 3.587402!
        Me.Line5.Y1 = 1.797244!
        Me.Line5.Y2 = 1.797244!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.352756!
        Me.Shape3.Left = 0.9968505!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = 9.999999!
        Me.Shape3.Top = 1.827953!
        Me.Shape3.Width = 1.835039!
        '
        'Line6
        '
        Me.Line6.Height = 0.7425197!
        Me.Line6.Left = 0.648031!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.04763752!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.648031!
        Me.Line6.X2 = 0.648031!
        Me.Line6.Y1 = 0.04763752!
        Me.Line6.Y2 = 0.7901572!
        '
        'Line8
        '
        Me.Line8.Height = 0.415748!
        Me.Line8.Left = 0.9244086!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.797244!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.9244086!
        Me.Line8.X2 = 0.9244086!
        Me.Line8.Y1 = 1.797244!
        Me.Line8.Y2 = 2.212992!
        '
        'Line9
        '
        Me.Line9.Height = 0.2496063!
        Me.Line9.Left = 1.946457!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.04763752!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 1.946457!
        Me.Line9.X2 = 1.946457!
        Me.Line9.Y1 = 0.04763752!
        Me.Line9.Y2 = 0.2972438!
        '
        'Line10
        '
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 0.9968505!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 2.007481!
        Me.Line10.Width = 1.835042!
        Me.Line10.X1 = 0.9968505!
        Me.Line10.X2 = 2.831892!
        Me.Line10.Y1 = 2.007481!
        Me.Line10.Y2 = 2.007481!
        '
        'Line11
        '
        Me.Line11.Height = 0.3527559!
        Me.Line11.Left = 1.601182!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 1.827952!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 1.601182!
        Me.Line11.X2 = 1.601182!
        Me.Line11.Y1 = 1.827952!
        Me.Line11.Y2 = 2.180708!
        '
        'Line12
        '
        Me.Line12.Height = 0.3527569!
        Me.Line12.Left = 2.215749!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.827952!
        Me.Line12.Width = 0.0!
        Me.Line12.X1 = 2.215749!
        Me.Line12.X2 = 2.215749!
        Me.Line12.Y1 = 1.827952!
        Me.Line12.Y2 = 2.180709!
        '
        'Line13
        '
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 0.05433017!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.7901573!
        Me.Line13.Width = 2.26063!
        Me.Line13.X1 = 0.05433017!
        Me.Line13.X2 = 2.31496!
        Me.Line13.Y1 = 0.7901573!
        Me.Line13.Y2 = 0.7901573!
        '
        'Line14
        '
        Me.Line14.Height = 0.249606!
        Me.Line14.Left = 2.396851!
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.04685013!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 2.396851!
        Me.Line14.X2 = 2.396851!
        Me.Line14.Y1 = 0.04685013!
        Me.Line14.Y2 = 0.2964561!
        '
        'Line15
        '
        Me.Line15.Height = 0.244095!
        Me.Line15.Left = 0.9307085!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.553149!
        Me.Line15.Width = 0.0!
        Me.Line15.X1 = 0.9307085!
        Me.Line15.X2 = 0.9307085!
        Me.Line15.Y1 = 1.553149!
        Me.Line15.Y2 = 1.797244!
        '
        'ST_REG_DATE
        '
        Me.ST_REG_DATE.DataField = "ST_REG_DATE"
        Me.ST_REG_DATE.Height = 0.2!
        Me.ST_REG_DATE.Left = 0.7003932!
        Me.ST_REG_DATE.Name = "ST_REG_DATE"
        Me.ST_REG_DATE.OutputFormat = resources.GetString("ST_REG_DATE.OutputFormat")
        Me.ST_REG_DATE.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.ST_REG_DATE.Text = "ST_REG_DATE"
        Me.ST_REG_DATE.Top = 0.579921!
        Me.ST_REG_DATE.Width = 1.614568!
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
        'rMemberCard
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
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMBER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_3_L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_2_L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_1_L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.END_REG_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BIRTHDAY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUBMEMBER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_3_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_2_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_1_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMBER_PIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ST_REG_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents MEMBER_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents END_REG_DATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Private WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape3 As DataDynamics.ActiveReports.Shape
    Private WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents MEMBER_CODE As DataDynamics.ActiveReports.Barcode
    Friend WithEvents BIRTHDAY As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ADDRESS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ST_REG_DATE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SUBMEMBER_NAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_1_L As DataDynamics.ActiveReports.Label
    Friend WithEvents OPTION_2_L As DataDynamics.ActiveReports.Label
    Friend WithEvents OPTION_3_L As DataDynamics.ActiveReports.Label
    Friend WithEvents OPTION_1_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_2_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_3_T As DataDynamics.ActiveReports.TextBox
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
    Private WithEvents MEMBER_PIC As DataDynamics.ActiveReports.Picture
End Class
