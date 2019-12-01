<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rShipmentReport
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rShipmentReport))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.ADDRESS = New DataDynamics.ActiveReports.TextBox()
        Me.CORP_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.TEL = New DataDynamics.ActiveReports.TextBox()
        Me.FAX = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.TANTOU_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.MAKE_DATE = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.LOGO_P = New DataDynamics.ActiveReports.Picture()
        Me.COSTOMER_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.POSTAL_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.BILL_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.TAX_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.PAYMENT_T = New DataDynamics.ActiveReports.TextBox()
        Me.Line14 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.RESHIP_SHAPE = New DataDynamics.ActiveReports.Shape()
        Me.RESHIP_L = New DataDynamics.ActiveReports.Label()
        Me.R_TAX_RATE_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Line17 = New DataDynamics.ActiveReports.Line()
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.No = New DataDynamics.ActiveReports.TextBox()
        Me.CNT = New DataDynamics.ActiveReports.TextBox()
        Me.JAN_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.OPTION_VALUE = New DataDynamics.ActiveReports.TextBox()
        Me.PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.PRODUCT_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.T_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.TAX_RATE = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox5 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.Line18 = New DataDynamics.ActiveReports.Line()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.CrossSectionBox6 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionLine1 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine2 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine3 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine4 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine5 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine6 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.POINT_DISCOUNT_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.DISCOUNT_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.MEMO = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_CNT = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_T_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.PRODUCT_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.POSTAGE_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.FEE_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.TAX_F_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Line15 = New DataDynamics.ActiveReports.Line()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.TOTAL_PRICE_T = New DataDynamics.ActiveReports.TextBox()
        Me.Line16 = New DataDynamics.ActiveReports.Line()
        Me.Line20 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line21 = New DataDynamics.ActiveReports.Line()
        Me.Line19 = New DataDynamics.ActiveReports.Line()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.R_TAX_RATE_F_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.Line22 = New DataDynamics.ActiveReports.Line()
        Me.CrossSectionLine7 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine8 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine9 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine10 = New DataDynamics.ActiveReports.CrossSectionLine()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TANTOU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LOGO_P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COSTOMER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POSTAL_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BILL_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAX_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAYMENT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RESHIP_L, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.R_TAX_RATE_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JAN_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAX_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POINT_DISCOUNT_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DISCOUNT_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POSTAGE_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FEE_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAX_F_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.R_TAX_RATE_F_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.ADDRESS, Me.CORP_NAME, Me.TEL, Me.FAX, Me.Label10, Me.TANTOU_NAME, Me.Label11, Me.MAKE_DATE, Me.ReportInfo2, Me.TextBox1, Me.TextBox2, Me.LOGO_P, Me.COSTOMER_NAME, Me.Line6, Me.POSTAL_CODE, Me.BILL_PRICE_T, Me.Label2, Me.TAX_PRICE_T, Me.Label17, Me.PAYMENT_T, Me.Line14, Me.Line1, Me.RESHIP_SHAPE, Me.RESHIP_L, Me.R_TAX_RATE_PRICE_T, Me.Line17})
        Me.PageHeader.Height = 2.743!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.6410002!
        Me.Shape1.Left = 0.06329972!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Shape1.LineWeight = 5.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 30.0!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 1.789!
        Me.Shape1.Width = 3.366143!
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.3043307!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.572836!
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New DataDynamics.ActiveReports.PaddingEx(20, 0, 20, 0)
        Me.Label1.Style = "background-color: #8080FF; color: Black; font-family: HG丸ｺﾞｼｯｸM-PRO; font-size: 1" &
    "4.25pt; font-weight: bold; text-align: justify; text-justify: distribute-all-lin" &
    "es; vertical-align: middle"
        Me.Label1.Text = "納品書"
        Me.Label1.Top = 0!
        Me.Label1.Width = 1.885433!
        '
        'ADDRESS
        '
        Me.ADDRESS.DataField = "ADDRESS"
        Me.ADDRESS.Height = 0.2!
        Me.ADDRESS.Left = 4.114962!
        Me.ADDRESS.Name = "ADDRESS"
        Me.ADDRESS.Text = "ADDRESS"
        Me.ADDRESS.Top = 1.672835!
        Me.ADDRESS.Width = 2.690552!
        '
        'CORP_NAME
        '
        Me.CORP_NAME.DataField = "CORP_NAME"
        Me.CORP_NAME.Height = 0.1590551!
        Me.CORP_NAME.Left = 4.110238!
        Me.CORP_NAME.Name = "CORP_NAME"
        Me.CORP_NAME.Text = "CORP_NAME"
        Me.CORP_NAME.Top = 1.816143!
        Me.CORP_NAME.Width = 2.695276!
        '
        'TEL
        '
        Me.TEL.DataField = "TEL"
        Me.TEL.Height = 0.2!
        Me.TEL.Left = 4.114962!
        Me.TEL.Name = "TEL"
        Me.TEL.OutputFormat = resources.GetString("TEL.OutputFormat")
        Me.TEL.Text = "TEL"
        Me.TEL.Top = 1.975198!
        Me.TEL.Width = 1.368898!
        '
        'FAX
        '
        Me.FAX.DataField = "FAX"
        Me.FAX.Height = 0.2!
        Me.FAX.Left = 5.483859!
        Me.FAX.Name = "FAX"
        Me.FAX.Text = "FAX"
        Me.FAX.Top = 1.975198!
        Me.FAX.Width = 1.321654!
        '
        'Label10
        '
        Me.Label10.Height = 0.1999999!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.114962!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.Label10.Text = "出荷担当者："
        Me.Label10.Top = 2.134254!
        Me.Label10.Width = 0.7397639!
        '
        'TANTOU_NAME
        '
        Me.TANTOU_NAME.DataField = "TANTOU_NAME"
        Me.TANTOU_NAME.Height = 0.2!
        Me.TANTOU_NAME.Left = 4.854723!
        Me.TANTOU_NAME.Name = "TANTOU_NAME"
        Me.TANTOU_NAME.Text = "TANTOU_NAME"
        Me.TANTOU_NAME.Top = 2.134254!
        Me.TANTOU_NAME.Width = 1.950788!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.825592!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label11.Text = "単位：円(税込み)"
        Me.Label11.Top = 2.426378!
        Me.Label11.Width = 0.9799216!
        '
        'MAKE_DATE
        '
        Me.MAKE_DATE.DataField = "MAKE_DATE"
        Me.MAKE_DATE.FormatString = "作成日:{RunDateTime:yyyy年M月d日}"
        Me.MAKE_DATE.Height = 0.1692913!
        Me.MAKE_DATE.Left = 4.612205!
        Me.MAKE_DATE.Name = "MAKE_DATE"
        Me.MAKE_DATE.Style = "text-align: right"
        Me.MAKE_DATE.Top = 0.2307087!
        Me.MAKE_DATE.Width = 2.272048!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{PageNumber} / {PageCount} ページ"
        Me.ReportInfo2.Height = 0.2!
        Me.ReportInfo2.Left = 4.727954!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "text-align: right"
        Me.ReportInfo2.Top = 0!
        Me.ReportInfo2.Width = 2.1563!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.7371736!
        Me.TextBox1.Left = 0.0000004917383!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 11.25pt"
        Me.TextBox1.Text = "この度は、弊社製品をお買い求め頂き誠に有難う御座います。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "下記の通り商品を納品させて頂きます。内容をご確認の上、" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "お気づきの点が御座いましたら、お手数では御座" &
    "いますが" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "左記までご一報頂けますよう、よろしくお願い申し上げます。"
        Me.TextBox1.Top = 0.935827!
        Me.TextBox1.Width = 3.977166!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2177163!
        Me.TextBox2.Left = 2.572836!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 14.25pt"
        Me.TextBox2.Text = "様"
        Me.TextBox2.Top = 0.5807087!
        Me.TextBox2.Width = 0.2897639!
        '
        'LOGO_P
        '
        Me.LOGO_P.DataField = "LOGO"
        Me.LOGO_P.Height = 0.7704722!
        Me.LOGO_P.HyperLink = Nothing
        Me.LOGO_P.ImageData = Nothing
        Me.LOGO_P.Left = 4.110238!
        Me.LOGO_P.Name = "LOGO_P"
        Me.LOGO_P.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.LOGO_P.Top = 0.6275591!
        Me.LOGO_P.Width = 2.695276!
        '
        'COSTOMER_NAME
        '
        Me.COSTOMER_NAME.DataField = "COSTOMER_NAME"
        Me.COSTOMER_NAME.Height = 0.2814961!
        Me.COSTOMER_NAME.Left = 0!
        Me.COSTOMER_NAME.Name = "COSTOMER_NAME"
        Me.COSTOMER_NAME.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.COSTOMER_NAME.Style = "font-family: HG丸ｺﾞｼｯｸM-PRO; font-size: 14.25pt; text-align: center; text-justify:" &
    " auto"
        Me.COSTOMER_NAME.Text = "COSTOMER_NAME"
        Me.COSTOMER_NAME.Top = 0.5476379!
        Me.COSTOMER_NAME.Width = 2.483859!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 0!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.7984243!
        Me.Line6.Width = 2.874803!
        Me.Line6.X1 = 0!
        Me.Line6.X2 = 2.874803!
        Me.Line6.Y1 = 0.7984243!
        Me.Line6.Y2 = 0.7984243!
        '
        'POSTAL_CODE
        '
        Me.POSTAL_CODE.DataField = "POSTAL_CODE"
        Me.POSTAL_CODE.Height = 0.2!
        Me.POSTAL_CODE.Left = 4.114962!
        Me.POSTAL_CODE.Name = "POSTAL_CODE"
        Me.POSTAL_CODE.Text = "POSTAL_CODE"
        Me.POSTAL_CODE.Top = 1.493308!
        Me.POSTAL_CODE.Width = 1.244095!
        '
        'BILL_PRICE_T
        '
        Me.BILL_PRICE_T.DataField = "BILL_PRICE"
        Me.BILL_PRICE_T.Height = 0.2311025!
        Me.BILL_PRICE_T.Left = 1.5023!
        Me.BILL_PRICE_T.Name = "BILL_PRICE_T"
        Me.BILL_PRICE_T.Style = "font-size: 14.25pt; font-weight: bold; text-align: center"
        Me.BILL_PRICE_T.Text = "BILL_PRICE_T"
        Me.BILL_PRICE_T.Top = 1.784!
        Me.BILL_PRICE_T.Width = 1.927166!
        '
        'Label2
        '
        Me.Label2.Height = 0.6315753!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.04929965!
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 10, 0)
        Me.Label2.Style = "background-color: #8080FF; font-family: HG丸ｺﾞｼｯｸM-PRO; font-size: 12pt; font-weig" &
    "ht: bold; text-align: right; vertical-align: middle"
        Me.Label2.Text = "ご購入金額："
        Me.Label2.Top = 1.797!
        Me.Label2.Width = 1.396063!
        '
        'TAX_PRICE_T
        '
        Me.TAX_PRICE_T.DataField = "TAX_PRICE"
        Me.TAX_PRICE_T.Height = 0.2!
        Me.TAX_PRICE_T.Left = 1.5023!
        Me.TAX_PRICE_T.Name = "TAX_PRICE_T"
        Me.TAX_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: center"
        Me.TAX_PRICE_T.Text = "TAX_PRICE_T"
        Me.TAX_PRICE_T.Top = 2.016!
        Me.TAX_PRICE_T.Width = 1.91378!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.04911063!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-family: HG丸ｺﾞｼｯｸM-PRO; font-size: 11.25pt; font-weight: bold; text-align: ri" &
    "ght; vertical-align: middle"
        Me.Label17.Text = "お支払方法："
        Me.Label17.Top = 2.543!
        Me.Label17.Width = 1.259055!
        '
        'PAYMENT_T
        '
        Me.PAYMENT_T.DataField = "PAYMENT"
        Me.PAYMENT_T.Height = 0.1492126!
        Me.PAYMENT_T.Left = 1.47785!
        Me.PAYMENT_T.Name = "PAYMENT_T"
        Me.PAYMENT_T.Style = "font-size: 11.25pt; font-weight: bold"
        Me.PAYMENT_T.Text = "PAYMENT_T"
        Me.PAYMENT_T.Top = 2.552842!
        Me.PAYMENT_T.Width = 1.855511!
        '
        'Line14
        '
        Me.Line14.Height = 0!
        Me.Line14.Left = 0!
        Me.Line14.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line14.LineWeight = 3.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 2.743!
        Me.Line14.Width = 3.364567!
        Me.Line14.X1 = 0!
        Me.Line14.X2 = 3.364567!
        Me.Line14.Y1 = 2.743!
        Me.Line14.Y2 = 2.743!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 1.4453!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.015!
        Me.Line1.Width = 1.970079!
        Me.Line1.X1 = 1.4453!
        Me.Line1.X2 = 3.415379!
        Me.Line1.Y1 = 2.015!
        Me.Line1.Y2 = 2.015!
        '
        'RESHIP_SHAPE
        '
        Me.RESHIP_SHAPE.Height = 0.4!
        Me.RESHIP_SHAPE.Left = 0.0000004917383!
        Me.RESHIP_SHAPE.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RESHIP_SHAPE.LineWeight = 5.0!
        Me.RESHIP_SHAPE.Name = "RESHIP_SHAPE"
        Me.RESHIP_SHAPE.RoundingRadius = 30.0!
        Me.RESHIP_SHAPE.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.RESHIP_SHAPE.Top = 0!
        Me.RESHIP_SHAPE.Width = 1.415748!
        '
        'RESHIP_L
        '
        Me.RESHIP_L.Height = 0.2!
        Me.RESHIP_L.HyperLink = Nothing
        Me.RESHIP_L.Left = 0.1992131!
        Me.RESHIP_L.Name = "RESHIP_L"
        Me.RESHIP_L.Style = "color: Red; font-size: 14.25pt; text-align: center"
        Me.RESHIP_L.Text = "再 出 荷"
        Me.RESHIP_L.Top = 0.1043307!
        Me.RESHIP_L.Width = 1.0!
        '
        'R_TAX_RATE_PRICE_T
        '
        Me.R_TAX_RATE_PRICE_T.DataField = "R_TAX_RATE_PRICE"
        Me.R_TAX_RATE_PRICE_T.Height = 0.2!
        Me.R_TAX_RATE_PRICE_T.Left = 1.5023!
        Me.R_TAX_RATE_PRICE_T.Name = "R_TAX_RATE_PRICE_T"
        Me.R_TAX_RATE_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: center"
        Me.R_TAX_RATE_PRICE_T.Text = "R_TAX_RATE_PRICE_T"
        Me.R_TAX_RATE_PRICE_T.Top = 2.229999!
        Me.R_TAX_RATE_PRICE_T.Width = 1.91378!
        '
        'Line17
        '
        Me.Line17.Height = 0!
        Me.Line17.Left = 1.4473!
        Me.Line17.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line17.LineWeight = 2.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 2.229999!
        Me.Line17.Width = 1.97008!
        Me.Line17.X1 = 1.4473!
        Me.Line17.X2 = 3.41738!
        Me.Line17.Y1 = 2.229999!
        Me.Line17.Y2 = 2.229999!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.No, Me.CNT, Me.JAN_CODE, Me.OPTION_VALUE, Me.PRICE, Me.PRODUCT_NAME, Me.T_PRICE, Me.Line7, Me.TAX_RATE})
        Me.Detail.Height = 0.2007874!
        Me.Detail.Name = "Detail"
        '
        'No
        '
        Me.No.DataField = "No"
        Me.No.Height = 0.2!
        Me.No.Left = 0!
        Me.No.Name = "No"
        Me.No.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 1, 0)
        Me.No.Style = "font-size: 9pt; text-align: right; vertical-align: middle"
        Me.No.Text = "No"
        Me.No.Top = 0!
        Me.No.Width = 0.2929134!
        '
        'CNT
        '
        Me.CNT.DataField = "CNT"
        Me.CNT.Height = 0.2007874!
        Me.CNT.Left = 4.87!
        Me.CNT.Name = "CNT"
        Me.CNT.OutputFormat = resources.GetString("CNT.OutputFormat")
        Me.CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.CNT.Style = "text-align: right; vertical-align: middle"
        Me.CNT.Text = "CNT"
        Me.CNT.Top = 0!
        Me.CNT.Width = 0.6200801!
        '
        'JAN_CODE
        '
        Me.JAN_CODE.DataField = "JAN_CODE"
        Me.JAN_CODE.Height = 0.2!
        Me.JAN_CODE.Left = 1.896851!
        Me.JAN_CODE.Name = "JAN_CODE"
        Me.JAN_CODE.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.JAN_CODE.Text = "JAN_CODE"
        Me.JAN_CODE.Top = 0!
        Me.JAN_CODE.Width = 0.9062994!
        '
        'OPTION_VALUE
        '
        Me.OPTION_VALUE.DataField = "OPTION_VALUE"
        Me.OPTION_VALUE.Height = 0.2!
        Me.OPTION_VALUE.Left = 2.80315!
        Me.OPTION_VALUE.Name = "OPTION_VALUE"
        Me.OPTION_VALUE.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.OPTION_VALUE.Text = "OPTION_VALUE"
        Me.OPTION_VALUE.Top = 0!
        Me.OPTION_VALUE.Width = 1.20085!
        '
        'PRICE
        '
        Me.PRICE.DataField = "PRICE"
        Me.PRICE.Height = 0.2!
        Me.PRICE.Left = 4.004!
        Me.PRICE.Name = "PRICE"
        Me.PRICE.OutputFormat = resources.GetString("PRICE.OutputFormat")
        Me.PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.PRICE.Style = "text-align: right; vertical-align: middle"
        Me.PRICE.Text = "PRICE"
        Me.PRICE.Top = 0!
        Me.PRICE.Width = 0.8484264!
        '
        'PRODUCT_NAME
        '
        Me.PRODUCT_NAME.DataField = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Height = 0.2!
        Me.PRODUCT_NAME.Left = 0.2929134!
        Me.PRODUCT_NAME.Name = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.PRODUCT_NAME.Text = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Top = 0!
        Me.PRODUCT_NAME.Width = 1.603937!
        '
        'T_PRICE
        '
        Me.T_PRICE.DataField = "T_PRICE"
        Me.T_PRICE.Height = 0.2!
        Me.T_PRICE.Left = 5.49!
        Me.T_PRICE.Name = "T_PRICE"
        Me.T_PRICE.OutputFormat = resources.GetString("T_PRICE.OutputFormat")
        Me.T_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.T_PRICE.Style = "text-align: right; vertical-align: middle"
        Me.T_PRICE.Text = "T_PRICE"
        Me.T_PRICE.Top = 0!
        Me.T_PRICE.Width = 1.05433!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 0!
        Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0!
        Me.Line7.Width = 7.164!
        Me.Line7.X1 = 0!
        Me.Line7.X2 = 7.164!
        Me.Line7.Y1 = 0!
        Me.Line7.Y2 = 0!
        '
        'TAX_RATE
        '
        Me.TAX_RATE.DataField = "TAX_RATE"
        Me.TAX_RATE.Height = 0.19!
        Me.TAX_RATE.Left = 6.56!
        Me.TAX_RATE.Name = "TAX_RATE"
        Me.TAX_RATE.OutputFormat = resources.GetString("TAX_RATE.OutputFormat")
        Me.TAX_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TAX_RATE.Style = "text-align: right; vertical-align: middle"
        Me.TAX_RATE.Text = "TAX_RATE"
        Me.TAX_RATE.Top = 0.01!
        Me.TAX_RATE.Width = 0.6200801!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label12, Me.CrossSectionBox1, Me.CrossSectionBox5, Me.Line18, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label19, Me.Label20, Me.CrossSectionBox6, Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.CrossSectionLine6, Me.Label18, Me.CrossSectionLine7, Me.CrossSectionLine8, Me.CrossSectionLine9, Me.CrossSectionLine10})
        Me.GroupHeader1.Height = 0.1875!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "background-color: #8080FF; text-align: center"
        Me.Label12.Text = "No"
        Me.Label12.Top = 0!
        Me.Label12.Width = 0.2929134!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0!
        Me.CrossSectionBox1.Left = 0!
        Me.CrossSectionBox1.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Right = 0!
        Me.CrossSectionBox1.Top = 0!
        '
        'CrossSectionBox5
        '
        Me.CrossSectionBox5.Bottom = 0!
        Me.CrossSectionBox5.Left = 0!
        Me.CrossSectionBox5.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CrossSectionBox5.LineWeight = 1.0!
        Me.CrossSectionBox5.Name = "CrossSectionBox5"
        Me.CrossSectionBox5.Right = 0!
        Me.CrossSectionBox5.Top = 0!
        '
        'Line18
        '
        Me.Line18.Height = 0!
        Me.Line18.Left = 0!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.1874016!
        Me.Line18.Width = 8.104722!
        Me.Line18.X1 = 0!
        Me.Line18.X2 = 8.104722!
        Me.Line18.Y1 = 0.1874016!
        Me.Line18.Y2 = 0.1874016!
        '
        'Label13
        '
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.2929134!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "background-color: #8080FF; text-align: center"
        Me.Label13.Text = "商品名称"
        Me.Label13.Top = 0!
        Me.Label13.Width = 1.603937!
        '
        'Label14
        '
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 1.896851!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "background-color: #8080FF; text-align: center"
        Me.Label14.Text = "JANコード"
        Me.Label14.Top = 0!
        Me.Label14.Width = 0.9062994!
        '
        'Label15
        '
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 2.80315!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "background-color: #8080FF; text-align: center"
        Me.Label15.Text = "オプション"
        Me.Label15.Top = 0!
        Me.Label15.Width = 1.20085!
        '
        'Label16
        '
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.004!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "background-color: #8080FF; text-align: center"
        Me.Label16.Text = "単価"
        Me.Label16.Top = 0!
        Me.Label16.Width = 0.8637806!
        '
        'Label19
        '
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.187!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 4.868!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "background-color: #8080FF; text-align: center"
        Me.Label19.Text = "数量"
        Me.Label19.Top = 0!
        Me.Label19.Width = 0.6220469!
        '
        'Label20
        '
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.184!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.49!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "background-color: #8080FF; text-align: center"
        Me.Label20.Text = "金額"
        Me.Label20.Top = 0.003!
        Me.Label20.Width = 1.05433!
        '
        'CrossSectionBox6
        '
        Me.CrossSectionBox6.Bottom = 0!
        Me.CrossSectionBox6.Left = 0!
        Me.CrossSectionBox6.LineWeight = 1.0!
        Me.CrossSectionBox6.Name = "CrossSectionBox6"
        Me.CrossSectionBox6.Right = 0!
        Me.CrossSectionBox6.Top = 0!
        '
        'CrossSectionLine1
        '
        Me.CrossSectionLine1.Bottom = 0!
        Me.CrossSectionLine1.Left = 0!
        Me.CrossSectionLine1.LineWeight = 1.0!
        Me.CrossSectionLine1.Name = "CrossSectionLine1"
        Me.CrossSectionLine1.Top = 0!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.Bottom = 0!
        Me.CrossSectionLine2.Left = 0!
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Top = 0!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.Bottom = 0!
        Me.CrossSectionLine3.Left = 0!
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Top = 0!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.Bottom = 0!
        Me.CrossSectionLine4.Left = 0!
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Top = 0.003149606!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.Bottom = 0.187!
        Me.CrossSectionLine5.Left = 3.977!
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Top = 0!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.Bottom = 0!
        Me.CrossSectionLine6.Left = 1.897!
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Top = 0!
        '
        'Label18
        '
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.187!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.546!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "background-color: #8080FF; text-align: center"
        Me.Label18.Text = "税率"
        Me.Label18.Top = 0!
        Me.Label18.Width = 0.6220469!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label21, Me.Shape2, Me.Label9, Me.POINT_DISCOUNT_PRICE_T, Me.Label8, Me.DISCOUNT_PRICE_T, Me.Label23, Me.MEMO, Me.TOTAL_PRICE, Me.TOTAL_CNT, Me.TOTAL_T_PRICE, Me.Line8, Me.Label5, Me.PRODUCT_PRICE_T, Me.Label6, Me.POSTAGE_PRICE_T, Me.Label7, Me.FEE_PRICE_T, Me.Line5, Me.Line4, Me.Line3, Me.Line2, Me.Line12, Me.Line13, Me.Label3, Me.TAX_F_PRICE_T, Me.Line15, Me.Label4, Me.TOTAL_PRICE_T, Me.Line16, Me.Line20, Me.Line9, Me.Line10, Me.Line21, Me.Line19, Me.Label22, Me.Label24, Me.R_TAX_RATE_F_PRICE, Me.Line11, Me.Line22})
        Me.GroupFooter1.Height = 2.039944!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label21
        '
        Me.Label21.Height = 0.2007874!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0!
        Me.Label21.Name = "Label21"
        Me.Label21.Padding = New DataDynamics.ActiveReports.PaddingEx(120, 0, 120, 0)
        Me.Label21.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label21.Text = "合計"
        Me.Label21.Top = 0!
        Me.Label21.Width = 4.416928!
        '
        'Shape2
        '
        Me.Shape2.Height = 1.257874!
        Me.Shape2.Left = 0!
        Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Shape2.LineWeight = 5.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 30.0!
        Me.Shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape2.Top = 0.4433071!
        Me.Shape2.Width = 5.004725!
        '
        'Label9
        '
        Me.Label9.Height = 0.1999999!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 5.13937!
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New DataDynamics.ActiveReports.PaddingEx(2, 0, 2, 0)
        Me.Label9.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label9.Text = "ポイント値引き"
        Me.Label9.Top = 1.117717!
        Me.Label9.Width = 0.8244097!
        '
        'POINT_DISCOUNT_PRICE_T
        '
        Me.POINT_DISCOUNT_PRICE_T.DataField = "POINT_DISCOUNT_PRICE"
        Me.POINT_DISCOUNT_PRICE_T.Height = 0.2000002!
        Me.POINT_DISCOUNT_PRICE_T.Left = 5.96378!
        Me.POINT_DISCOUNT_PRICE_T.Name = "POINT_DISCOUNT_PRICE_T"
        Me.POINT_DISCOUNT_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.POINT_DISCOUNT_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.POINT_DISCOUNT_PRICE_T.Text = "POINT_DISCOUNT_PRICE_T"
        Me.POINT_DISCOUNT_PRICE_T.Top = 1.117717!
        Me.POINT_DISCOUNT_PRICE_T.Width = 1.020079!
        '
        'Label8
        '
        Me.Label8.Height = 0.1999999!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.13937!
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.Label8.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label8.Text = "値引き"
        Me.Label8.Top = 0.9311021!
        Me.Label8.Width = 0.8244097!
        '
        'DISCOUNT_PRICE_T
        '
        Me.DISCOUNT_PRICE_T.DataField = "DISCOUNT_PRICE"
        Me.DISCOUNT_PRICE_T.Height = 0.2000002!
        Me.DISCOUNT_PRICE_T.Left = 5.96378!
        Me.DISCOUNT_PRICE_T.Name = "DISCOUNT_PRICE_T"
        Me.DISCOUNT_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.DISCOUNT_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.DISCOUNT_PRICE_T.Text = "DISCOUNT_PRICE_T"
        Me.DISCOUNT_PRICE_T.Top = 0.9311021!
        Me.DISCOUNT_PRICE_T.Width = 1.020079!
        '
        'Label23
        '
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.02047244!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label23.Text = "【備考】"
        Me.Label23.Top = 0.2433071!
        Me.Label23.Width = 0.6874019!
        '
        'MEMO
        '
        Me.MEMO.DataField = "MEMO"
        Me.MEMO.Height = 1.258662!
        Me.MEMO.Left = 0.02!
        Me.MEMO.Name = "MEMO"
        Me.MEMO.Padding = New DataDynamics.ActiveReports.PaddingEx(5, 5, 5, 5)
        Me.MEMO.Text = "MEMO"
        Me.MEMO.Top = 0.443!
        Me.MEMO.Width = 5.004725!
        '
        'TOTAL_PRICE
        '
        Me.TOTAL_PRICE.DataField = "PRICE"
        Me.TOTAL_PRICE.Height = 0.2!
        Me.TOTAL_PRICE.Left = 4.004!
        Me.TOTAL_PRICE.Name = "TOTAL_PRICE"
        Me.TOTAL_PRICE.OutputFormat = resources.GetString("TOTAL_PRICE.OutputFormat")
        Me.TOTAL_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_PRICE.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.TOTAL_PRICE.SummaryGroup = "GroupHeader1"
        Me.TOTAL_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TOTAL_PRICE.Text = "PRICE"
        Me.TOTAL_PRICE.Top = 0!
        Me.TOTAL_PRICE.Width = 0.8803153!
        '
        'TOTAL_CNT
        '
        Me.TOTAL_CNT.DataField = "CNT"
        Me.TOTAL_CNT.Height = 0.2007874!
        Me.TOTAL_CNT.Left = 4.87!
        Me.TOTAL_CNT.Name = "TOTAL_CNT"
        Me.TOTAL_CNT.OutputFormat = resources.GetString("TOTAL_CNT.OutputFormat")
        Me.TOTAL_CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_CNT.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.TOTAL_CNT.SummaryGroup = "GroupHeader1"
        Me.TOTAL_CNT.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TOTAL_CNT.Text = "CNT"
        Me.TOTAL_CNT.Top = 0!
        Me.TOTAL_CNT.Width = 0.6220469!
        '
        'TOTAL_T_PRICE
        '
        Me.TOTAL_T_PRICE.DataField = "T_PRICE"
        Me.TOTAL_T_PRICE.Height = 0.2!
        Me.TOTAL_T_PRICE.Left = 5.492!
        Me.TOTAL_T_PRICE.Name = "TOTAL_T_PRICE"
        Me.TOTAL_T_PRICE.OutputFormat = resources.GetString("TOTAL_T_PRICE.OutputFormat")
        Me.TOTAL_T_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_T_PRICE.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.TOTAL_T_PRICE.SummaryGroup = "GroupHeader1"
        Me.TOTAL_T_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TOTAL_T_PRICE.Text = "T_PRICE"
        Me.TOTAL_T_PRICE.Top = 0.001!
        Me.TOTAL_T_PRICE.Width = 1.05433!
        '
        'Line8
        '
        Me.Line8.Height = 0.001!
        Me.Line8.Left = 0!
        Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0!
        Me.Line8.Width = 7.18!
        Me.Line8.X1 = 0!
        Me.Line8.X2 = 7.18!
        Me.Line8.Y1 = 0!
        Me.Line8.Y2 = 0.001!
        '
        'Label5
        '
        Me.Label5.Height = 0.1999999!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.13937!
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.Label5.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label5.Text = "商品代金"
        Me.Label5.Top = 0.338189!
        Me.Label5.Width = 0.8244097!
        '
        'PRODUCT_PRICE_T
        '
        Me.PRODUCT_PRICE_T.DataField = "PRODUCT_PRICE"
        Me.PRODUCT_PRICE_T.Height = 0.2000002!
        Me.PRODUCT_PRICE_T.Left = 5.96378!
        Me.PRODUCT_PRICE_T.Name = "PRODUCT_PRICE_T"
        Me.PRODUCT_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.PRODUCT_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.PRODUCT_PRICE_T.Text = "PRODUCT_PRICE_T"
        Me.PRODUCT_PRICE_T.Top = 0.338189!
        Me.PRODUCT_PRICE_T.Width = 1.020079!
        '
        'Label6
        '
        Me.Label6.Height = 0.1999999!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.13937!
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.Label6.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label6.Text = "送料"
        Me.Label6.Top = 0.5377952!
        Me.Label6.Width = 0.8244097!
        '
        'POSTAGE_PRICE_T
        '
        Me.POSTAGE_PRICE_T.DataField = "POSTAGE_PRICE"
        Me.POSTAGE_PRICE_T.Height = 0.2000002!
        Me.POSTAGE_PRICE_T.Left = 5.96378!
        Me.POSTAGE_PRICE_T.Name = "POSTAGE_PRICE_T"
        Me.POSTAGE_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.POSTAGE_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.POSTAGE_PRICE_T.Text = "POSTAGE_PRICE_T"
        Me.POSTAGE_PRICE_T.Top = 0.5377952!
        Me.POSTAGE_PRICE_T.Width = 1.020079!
        '
        'Label7
        '
        Me.Label7.Height = 0.1999999!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 5.13937!
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.Label7.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label7.Text = "手数料"
        Me.Label7.Top = 0.731102!
        Me.Label7.Width = 0.8244097!
        '
        'FEE_PRICE_T
        '
        Me.FEE_PRICE_T.DataField = "FEE_PRICE"
        Me.FEE_PRICE_T.Height = 0.2000002!
        Me.FEE_PRICE_T.Left = 5.96378!
        Me.FEE_PRICE_T.Name = "FEE_PRICE_T"
        Me.FEE_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.FEE_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.FEE_PRICE_T.Text = "FEE_PRICE_T"
        Me.FEE_PRICE_T.Top = 0.731102!
        Me.FEE_PRICE_T.Width = 1.020079!
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 5.13937!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.9279528!
        Me.Line5.Width = 1.844491!
        Me.Line5.X1 = 5.13937!
        Me.Line5.X2 = 6.983861!
        Me.Line5.Y1 = 0.9279528!
        Me.Line5.Y2 = 0.9279528!
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 5.13937!
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.7381889!
        Me.Line4.Width = 1.844491!
        Me.Line4.X1 = 5.13937!
        Me.Line4.X2 = 6.983861!
        Me.Line4.Y1 = 0.7381889!
        Me.Line4.Y2 = 0.7381889!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 5.13937!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.5279528!
        Me.Line3.Width = 1.844491!
        Me.Line3.X1 = 5.13937!
        Me.Line3.X2 = 6.983861!
        Me.Line3.Y1 = 0.5279528!
        Me.Line3.Y2 = 0.5279528!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 5.13937!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.338189!
        Me.Line2.Width = 1.844491!
        Me.Line2.X1 = 5.13937!
        Me.Line2.X2 = 6.983861!
        Me.Line2.Y1 = 0.338189!
        Me.Line2.Y2 = 0.338189!
        '
        'Line12
        '
        Me.Line12.Height = 0!
        Me.Line12.Left = 5.13937!
        Me.Line12.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.127953!
        Me.Line12.Width = 1.844491!
        Me.Line12.X1 = 5.13937!
        Me.Line12.X2 = 6.983861!
        Me.Line12.Y1 = 1.127953!
        Me.Line12.Y2 = 1.127953!
        '
        'Line13
        '
        Me.Line13.Height = 0!
        Me.Line13.Left = 5.13937!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 1.314567!
        Me.Line13.Width = 1.844491!
        Me.Line13.X1 = 5.13937!
        Me.Line13.X2 = 6.983861!
        Me.Line13.Y1 = 1.314567!
        Me.Line13.Y2 = 1.314567!
        '
        'Label3
        '
        Me.Label3.Height = 0.1999998!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.129136!
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New DataDynamics.ActiveReports.PaddingEx(2, 0, 2, 0)
        Me.Label3.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label3.Text = "内消費税"
        Me.Label3.Top = 1.521654!
        Me.Label3.Width = 0.8244097!
        '
        'TAX_F_PRICE_T
        '
        Me.TAX_F_PRICE_T.DataField = "TAX_F_PRICE"
        Me.TAX_F_PRICE_T.Height = 0.2000002!
        Me.TAX_F_PRICE_T.Left = 5.953544!
        Me.TAX_F_PRICE_T.Name = "TAX_F_PRICE_T"
        Me.TAX_F_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TAX_F_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.TAX_F_PRICE_T.Text = "TAX_F_PRICE_T"
        Me.TAX_F_PRICE_T.Top = 1.521654!
        Me.TAX_F_PRICE_T.Width = 1.020079!
        '
        'Line15
        '
        Me.Line15.Height = 0!
        Me.Line15.Left = 5.118898!
        Me.Line15.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.721654!
        Me.Line15.Width = 1.864963!
        Me.Line15.X1 = 5.118898!
        Me.Line15.X2 = 6.983861!
        Me.Line15.Y1 = 1.721654!
        Me.Line15.Y2 = 1.721654!
        '
        'Label4
        '
        Me.Label4.Height = 0.1999998!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.13937!
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New DataDynamics.ActiveReports.PaddingEx(2, 0, 2, 0)
        Me.Label4.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label4.Text = "合計"
        Me.Label4.Top = 1.335039!
        Me.Label4.Width = 0.8244097!
        '
        'TOTAL_PRICE_T
        '
        Me.TOTAL_PRICE_T.DataField = "TOTAL_PRICE"
        Me.TOTAL_PRICE_T.Height = 0.2000002!
        Me.TOTAL_PRICE_T.Left = 5.96378!
        Me.TOTAL_PRICE_T.Name = "TOTAL_PRICE_T"
        Me.TOTAL_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TOTAL_PRICE_T.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.TOTAL_PRICE_T.Text = "TOTAL_PRICE_T"
        Me.TOTAL_PRICE_T.Top = 1.335039!
        Me.TOTAL_PRICE_T.Width = 1.020079!
        '
        'Line16
        '
        Me.Line16.Height = 0!
        Me.Line16.Left = 5.129134!
        Me.Line16.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 1.508662!
        Me.Line16.Width = 1.844491!
        Me.Line16.X1 = 5.129134!
        Me.Line16.X2 = 6.973625!
        Me.Line16.Y1 = 1.508662!
        Me.Line16.Y2 = 1.508662!
        '
        'Line20
        '
        Me.Line20.Height = 0!
        Me.Line20.Left = 0!
        Me.Line20.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 0!
        Me.Line20.Width = 1.844491!
        Me.Line20.X1 = 0!
        Me.Line20.X2 = 1.844491!
        Me.Line20.Y1 = 0!
        Me.Line20.Y2 = 0!
        '
        'Line9
        '
        Me.Line9.Height = 1.603!
        Me.Line9.Left = 5.119!
        Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.33!
        Me.Line9.Width = 0!
        Me.Line9.X1 = 5.119!
        Me.Line9.X2 = 5.119!
        Me.Line9.Y1 = 0.33!
        Me.Line9.Y2 = 1.933!
        '
        'Line10
        '
        Me.Line10.Height = 1.592!
        Me.Line10.Left = 6.99!
        Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.338!
        Me.Line10.Width = 0!
        Me.Line10.X1 = 6.99!
        Me.Line10.X2 = 6.99!
        Me.Line10.Y1 = 0.338!
        Me.Line10.Y2 = 1.93!
        '
        'Line21
        '
        Me.Line21.Height = 0!
        Me.Line21.Left = 5.129134!
        Me.Line21.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 1.314567!
        Me.Line21.Width = 1.844491!
        Me.Line21.X1 = 5.129134!
        Me.Line21.X2 = 6.973625!
        Me.Line21.Y1 = 1.314567!
        Me.Line21.Y2 = 1.314567!
        '
        'Line19
        '
        Me.Line19.Height = 0!
        Me.Line19.Left = 5.135433!
        Me.Line19.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 1.333071!
        Me.Line19.Width = 1.844491!
        Me.Line19.X1 = 5.135433!
        Me.Line19.X2 = 6.979924!
        Me.Line19.Y1 = 1.333071!
        Me.Line19.Y2 = 1.333071!
        '
        'Label22
        '
        Me.Label22.Height = 0.191!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 6.554!
        Me.Label22.Name = "Label22"
        Me.Label22.Padding = New DataDynamics.ActiveReports.PaddingEx(120, 0, 120, 0)
        Me.Label22.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label22.Text = "合計"
        Me.Label22.Top = 0.009!
        Me.Label22.Width = 0.618!
        '
        'Label24
        '
        Me.Label24.Height = 0.1999998!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 5.127!
        Me.Label24.Name = "Label24"
        Me.Label24.Padding = New DataDynamics.ActiveReports.PaddingEx(2, 0, 2, 0)
        Me.Label24.Style = "background-color: #C0C0FF; font-size: 9pt; text-align: justify; text-justify: dis" &
    "tribute-all-lines; vertical-align: middle"
        Me.Label24.Text = "内軽減税"
        Me.Label24.Top = 1.73!
        Me.Label24.Width = 0.8244097!
        '
        'R_TAX_RATE_F_PRICE
        '
        Me.R_TAX_RATE_F_PRICE.DataField = "R_TAX_RATE_F_PRICE"
        Me.R_TAX_RATE_F_PRICE.Height = 0.2000002!
        Me.R_TAX_RATE_F_PRICE.Left = 5.97!
        Me.R_TAX_RATE_F_PRICE.Name = "R_TAX_RATE_F_PRICE"
        Me.R_TAX_RATE_F_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.R_TAX_RATE_F_PRICE.Style = "font-size: 11.25pt; font-weight: normal; text-align: right"
        Me.R_TAX_RATE_F_PRICE.Text = "R_TAX_RATE_F_PRICE"
        Me.R_TAX_RATE_F_PRICE.Top = 1.733!
        Me.R_TAX_RATE_F_PRICE.Width = 1.020079!
        '
        'Line11
        '
        Me.Line11.Height = 1.603!
        Me.Line11.Left = 5.961!
        Me.Line11.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.33!
        Me.Line11.Width = 0.003000259!
        Me.Line11.X1 = 5.961!
        Me.Line11.X2 = 5.964!
        Me.Line11.Y1 = 0.33!
        Me.Line11.Y2 = 1.933!
        '
        'Line22
        '
        Me.Line22.Height = 0!
        Me.Line22.Left = 5.146!
        Me.Line22.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 1.93!
        Me.Line22.Width = 1.844493!
        Me.Line22.X1 = 5.146!
        Me.Line22.X2 = 6.990493!
        Me.Line22.Y1 = 1.93!
        Me.Line22.Y2 = 1.93!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.Bottom = 0.009000001!
        Me.CrossSectionLine7.Left = 2.803!
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Top = 0.009000001!
        '
        'CrossSectionLine8
        '
        Me.CrossSectionLine8.Bottom = 0.201!
        Me.CrossSectionLine8.Left = 4.855!
        Me.CrossSectionLine8.LineWeight = 1.0!
        Me.CrossSectionLine8.Name = "CrossSectionLine8"
        Me.CrossSectionLine8.Top = 0.014!
        '
        'CrossSectionLine9
        '
        Me.CrossSectionLine9.Bottom = 0.201!
        Me.CrossSectionLine9.Left = 5.484!
        Me.CrossSectionLine9.LineWeight = 1.0!
        Me.CrossSectionLine9.Name = "CrossSectionLine9"
        Me.CrossSectionLine9.Top = 0.014!
        '
        'CrossSectionLine10
        '
        Me.CrossSectionLine10.Bottom = 0.187!
        Me.CrossSectionLine10.Left = 6.544!
        Me.CrossSectionLine10.LineWeight = 1.0!
        Me.CrossSectionLine10.Name = "CrossSectionLine10"
        Me.CrossSectionLine10.Top = 0!
        '
        'rShipmentReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.154774!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TANTOU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LOGO_P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COSTOMER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POSTAL_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BILL_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAX_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAYMENT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RESHIP_L, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.R_TAX_RATE_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JAN_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAX_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POINT_DISCOUNT_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DISCOUNT_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POSTAGE_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FEE_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAX_F_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.R_TAX_RATE_F_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents ADDRESS As DataDynamics.ActiveReports.TextBox
    Private WithEvents CORP_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents TEL As DataDynamics.ActiveReports.TextBox
    Private WithEvents FAX As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents TANTOU_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents MAKE_DATE As DataDynamics.ActiveReports.ReportInfo
    Private WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents LOGO_P As DataDynamics.ActiveReports.Picture
    Private WithEvents COSTOMER_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents POSTAL_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents BILL_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents TAX_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Private WithEvents PAYMENT_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line14 As DataDynamics.ActiveReports.Line
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents RESHIP_SHAPE As DataDynamics.ActiveReports.Shape
    Private WithEvents RESHIP_L As DataDynamics.ActiveReports.Label
    Private WithEvents R_TAX_RATE_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line17 As DataDynamics.ActiveReports.Line
    Private WithEvents No As DataDynamics.ActiveReports.TextBox
    Private WithEvents CNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents JAN_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents OPTION_VALUE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents PRODUCT_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents T_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Private WithEvents TAX_RATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox5 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents Line18 As DataDynamics.ActiveReports.Line
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Private WithEvents Label14 As DataDynamics.ActiveReports.Label
    Private WithEvents Label15 As DataDynamics.ActiveReports.Label
    Private WithEvents Label16 As DataDynamics.ActiveReports.Label
    Private WithEvents Label19 As DataDynamics.ActiveReports.Label
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Private WithEvents CrossSectionBox6 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionLine1 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine2 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine3 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine4 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine5 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine6 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents Label18 As DataDynamics.ActiveReports.Label
    Private WithEvents Label21 As DataDynamics.ActiveReports.Label
    Private WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents POINT_DISCOUNT_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents DISCOUNT_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label23 As DataDynamics.ActiveReports.Label
    Private WithEvents MEMO As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_CNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_T_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line8 As DataDynamics.ActiveReports.Line
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents PRODUCT_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents POSTAGE_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents FEE_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line5 As DataDynamics.ActiveReports.Line
    Private WithEvents Line4 As DataDynamics.ActiveReports.Line
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents Line12 As DataDynamics.ActiveReports.Line
    Private WithEvents Line13 As DataDynamics.ActiveReports.Line
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents TAX_F_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line15 As DataDynamics.ActiveReports.Line
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents TOTAL_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line16 As DataDynamics.ActiveReports.Line
    Private WithEvents Line20 As DataDynamics.ActiveReports.Line
    Private WithEvents Line9 As DataDynamics.ActiveReports.Line
    Private WithEvents Line10 As DataDynamics.ActiveReports.Line
    Private WithEvents Line21 As DataDynamics.ActiveReports.Line
    Private WithEvents Line19 As DataDynamics.ActiveReports.Line
    Private WithEvents Label22 As DataDynamics.ActiveReports.Label
    Private WithEvents Label24 As DataDynamics.ActiveReports.Label
    Private WithEvents R_TAX_RATE_F_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line11 As DataDynamics.ActiveReports.Line
    Private WithEvents Line22 As DataDynamics.ActiveReports.Line
    Private WithEvents CrossSectionLine7 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine8 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine9 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine10 As DataDynamics.ActiveReports.CrossSectionLine
End Class
