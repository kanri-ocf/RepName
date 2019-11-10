<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rOrderReport
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
    Private WithEvents GroupHeader9 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rOrderReport))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.SUPPLIER_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.POSTAL_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.ADDRESS = New DataDynamics.ActiveReports.TextBox()
        Me.CORP_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.TEL = New DataDynamics.ActiveReports.TextBox()
        Me.FAX = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.TANTOU_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.BARCODE = New DataDynamics.ActiveReports.Barcode()
        Me.ORDER_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_BEFORE_TAX_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.MAKE_DATE = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.REQUEST_DATE = New DataDynamics.ActiveReports.TextBox()
        Me.REQUEST_PLACE = New DataDynamics.ActiveReports.TextBox()
        Me.PAYMENT = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.TOTAL_TAX_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.RTAX_RATE_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.REPORT_PEACE = New DataDynamics.ActiveReports.TextBox()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.TOTAL_AFTER_TAX_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader9 = New DataDynamics.ActiveReports.Detail()
        Me.No = New DataDynamics.ActiveReports.TextBox()
        Me.CNT = New DataDynamics.ActiveReports.TextBox()
        Me.JAN_CODE = New DataDynamics.ActiveReports.TextBox()
        Me.OPTION_VALUE = New DataDynamics.ActiveReports.TextBox()
        Me.PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.COST = New DataDynamics.ActiveReports.TextBox()
        Me.PRODUCT_NAME = New DataDynamics.ActiveReports.TextBox()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.TAX = New DataDynamics.ActiveReports.TextBox()
        Me.T_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Line18 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.MEMO = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.IN_TAX_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.POINT_DISCOUNT = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.RTAX_RATE = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.DISCOUNT = New DataDynamics.ActiveReports.TextBox()
        Me.TAX_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.NO_TAX_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.FEE = New DataDynamics.ActiveReports.TextBox()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        Me.POSTAGE = New DataDynamics.ActiveReports.TextBox()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader8 = New DataDynamics.ActiveReports.GroupHeader()
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox2 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox3 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox4 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox5 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox6 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox7 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionBox8 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.CrossSectionLine1 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine2 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine3 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine4 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine5 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine6 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine7 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine8 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.CrossSectionLine9 = New DataDynamics.ActiveReports.CrossSectionLine()
        Me.GroupFooter8 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TOTAL_COST = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_CNT = New DataDynamics.ActiveReports.TextBox()
        Me.TOTAL_T_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.TOTAL_PRICE = New DataDynamics.ActiveReports.TextBox()
        Me.CrossSectionLine10 = New DataDynamics.ActiveReports.CrossSectionLine()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUPPLIER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POSTAL_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TANTOU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORDER_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_BEFORE_TAX_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REQUEST_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REQUEST_PLACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAYMENT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_TAX_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RTAX_RATE_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORT_PEACE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_AFTER_TAX_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JAN_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IN_TAX_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POINT_DISCOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RTAX_RATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DISCOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAX_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NO_TAX_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FEE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POSTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_COST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.SUPPLIER_NAME, Me.Label2, Me.Line1, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.POSTAL_CODE, Me.ADDRESS, Me.CORP_NAME, Me.TEL, Me.FAX, Me.Label10, Me.TANTOU_NAME, Me.BARCODE, Me.ORDER_CODE, Me.TOTAL_BEFORE_TAX_PRICE, Me.Line3, Me.Line2, Me.MAKE_DATE, Me.ReportInfo2, Me.REQUEST_DATE, Me.REQUEST_PLACE, Me.PAYMENT, Me.Line4, Me.Line5, Me.Line6, Me.Label8, Me.TOTAL_TAX_PRICE, Me.Line9, Me.Label9, Me.RTAX_RATE_PRICE, Me.Line10, Me.REPORT_PEACE, Me.Label28, Me.Line13, Me.TOTAL_AFTER_TAX_PRICE})
        Me.PageHeader.Height = 2.577236!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.3043307!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.355!
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New DataDynamics.ActiveReports.PaddingEx(20, 0, 20, 0)
        Me.Label1.Style = "background-color: #8080FF; font-family: ＭＳ Ｐゴシック; font-size: 14.25pt; font-weight" &
    ": bold; text-align: justify; text-justify: distribute-all-lines; vertical-align:" &
    " middle"
        Me.Label1.Text = "御注文書"
        Me.Label1.Top = 0!
        Me.Label1.Width = 2.364567!
        '
        'SUPPLIER_NAME
        '
        Me.SUPPLIER_NAME.DataField = "SUPPLIER_NAME"
        Me.SUPPLIER_NAME.Height = 0.2!
        Me.SUPPLIER_NAME.Left = 0!
        Me.SUPPLIER_NAME.Name = "SUPPLIER_NAME"
        Me.SUPPLIER_NAME.Style = "font-size: 12pt; text-align: center; vertical-align: middle"
        Me.SUPPLIER_NAME.Text = "SUPPLIER_NAME"
        Me.SUPPLIER_NAME.Top = 0.329!
        Me.SUPPLIER_NAME.Width = 2.364567!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 2.365!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 14.25pt; text-align: left; text-justify: auto"
        Me.Label2.Text = "御中"
        Me.Label2.Top = 0.329!
        Me.Label2.Width = 0.5102364!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.529!
        Me.Line1.Width = 2.874803!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 2.874803!
        Me.Line1.Y1 = 0.529!
        Me.Line1.Y2 = 0.529!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.144!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label3.Text = "注文番号："
        Me.Label3.Top = 0.58!
        Me.Label3.Width = 1.156693!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.144!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label4.Text = "注文金額："
        Me.Label4.Top = 0.8060001!
        Me.Label4.Width = 1.156693!
        '
        'Label5
        '
        Me.Label5.Height = 0.1999999!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.144!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label5.Text = "納品期限："
        Me.Label5.Top = 1.766!
        Me.Label5.Width = 1.156693!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.144!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label6.Text = "納品場所："
        Me.Label6.Top = 1.971!
        Me.Label6.Width = 1.156693!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.144!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label7.Text = "支払方法："
        Me.Label7.Top = 2.232!
        Me.Label7.Width = 1.156693!
        '
        'POSTAL_CODE
        '
        Me.POSTAL_CODE.DataField = "POSTAL_CODE"
        Me.POSTAL_CODE.Height = 0.2!
        Me.POSTAL_CODE.Left = 4.267!
        Me.POSTAL_CODE.Name = "POSTAL_CODE"
        Me.POSTAL_CODE.Text = "POSTAL_CODE"
        Me.POSTAL_CODE.Top = 1.272!
        Me.POSTAL_CODE.Width = 1.677166!
        '
        'ADDRESS
        '
        Me.ADDRESS.DataField = "ADDRESS"
        Me.ADDRESS.Height = 0.2!
        Me.ADDRESS.Left = 4.267!
        Me.ADDRESS.Name = "ADDRESS"
        Me.ADDRESS.Text = "ADDRESS"
        Me.ADDRESS.Top = 1.478!
        Me.ADDRESS.Width = 2.644!
        '
        'CORP_NAME
        '
        Me.CORP_NAME.DataField = "CORP_NAME"
        Me.CORP_NAME.Height = 0.1590551!
        Me.CORP_NAME.Left = 4.262!
        Me.CORP_NAME.Name = "CORP_NAME"
        Me.CORP_NAME.Text = "CORP_NAME"
        Me.CORP_NAME.Top = 1.673!
        Me.CORP_NAME.Width = 2.649!
        '
        'TEL
        '
        Me.TEL.DataField = "TEL"
        Me.TEL.Height = 0.1999999!
        Me.TEL.Left = 4.26693!
        Me.TEL.Name = "TEL"
        Me.TEL.OutputFormat = resources.GetString("TEL.OutputFormat")
        Me.TEL.Text = "TEL"
        Me.TEL.Top = 1.83189!
        Me.TEL.Width = 1.29607!
        '
        'FAX
        '
        Me.FAX.DataField = "FAX"
        Me.FAX.Height = 0.1999999!
        Me.FAX.Left = 5.563!
        Me.FAX.Name = "FAX"
        Me.FAX.Text = "FAX"
        Me.FAX.Top = 1.83189!
        Me.FAX.Width = 1.348!
        '
        'Label10
        '
        Me.Label10.Height = 0.1999999!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.262!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.Label10.Text = "発注担当者："
        Me.Label10.Top = 2.032!
        Me.Label10.Width = 0.7397637!
        '
        'TANTOU_NAME
        '
        Me.TANTOU_NAME.DataField = "TANTOU_NAME"
        Me.TANTOU_NAME.Height = 0.2!
        Me.TANTOU_NAME.Left = 5.069292!
        Me.TANTOU_NAME.Name = "TANTOU_NAME"
        Me.TANTOU_NAME.Text = "TANTOU_NAME"
        Me.TANTOU_NAME.Top = 2.03189!
        Me.TANTOU_NAME.Width = 1.841708!
        '
        'BARCODE
        '
        Me.BARCODE.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.BARCODE.DataField = "BARCODE"
        Me.BARCODE.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.BARCODE.Height = 0.635433!
        Me.BARCODE.Left = 4.277!
        Me.BARCODE.Name = "BARCODE"
        Me.BARCODE.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.BARCODE.Top = 0.58!
        Me.BARCODE.Width = 2.634!
        '
        'ORDER_CODE
        '
        Me.ORDER_CODE.DataField = "ORDER_CODE"
        Me.ORDER_CODE.Height = 0.2!
        Me.ORDER_CODE.Left = 1.345!
        Me.ORDER_CODE.Name = "ORDER_CODE"
        Me.ORDER_CODE.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.ORDER_CODE.Text = "ORDER_CODE"
        Me.ORDER_CODE.Top = 0.58!
        Me.ORDER_CODE.Width = 2.031102!
        '
        'TOTAL_BEFORE_TAX_PRICE
        '
        Me.TOTAL_BEFORE_TAX_PRICE.DataField = "TOTAL_BEFORE_TAX_PRICE"
        Me.TOTAL_BEFORE_TAX_PRICE.Height = 0.2!
        Me.TOTAL_BEFORE_TAX_PRICE.Left = 1.345!
        Me.TOTAL_BEFORE_TAX_PRICE.Name = "TOTAL_BEFORE_TAX_PRICE"
        Me.TOTAL_BEFORE_TAX_PRICE.OutputFormat = resources.GetString("TOTAL_BEFORE_TAX_PRICE.OutputFormat")
        Me.TOTAL_BEFORE_TAX_PRICE.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.TOTAL_BEFORE_TAX_PRICE.Text = "TOTAL_BEFORE_TAX_PRICE"
        Me.TOTAL_BEFORE_TAX_PRICE.Top = 0.8060001!
        Me.TOTAL_BEFORE_TAX_PRICE.Width = 2.031102!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.144!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.006!
        Me.Line3.Width = 3.232284!
        Me.Line3.X1 = 0.144!
        Me.Line3.X2 = 3.376284!
        Me.Line3.Y1 = 1.006!
        Me.Line3.Y2 = 1.006!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.144!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.78!
        Me.Line2.Width = 3.232284!
        Me.Line2.X1 = 0.144!
        Me.Line2.X2 = 3.376284!
        Me.Line2.Y1 = 0.78!
        Me.Line2.Y2 = 0.78!
        '
        'MAKE_DATE
        '
        Me.MAKE_DATE.DataField = "MAKE_DATE"
        Me.MAKE_DATE.FormatString = "作成日:{RunDateTime:yyyy年M月d日}"
        Me.MAKE_DATE.Height = 0.1692913!
        Me.MAKE_DATE.Left = 4.72!
        Me.MAKE_DATE.Name = "MAKE_DATE"
        Me.MAKE_DATE.Style = "text-align: right"
        Me.MAKE_DATE.Top = 0.231!
        Me.MAKE_DATE.Width = 2.191001!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{PageNumber} / {PageCount} ページ"
        Me.ReportInfo2.Height = 0.2!
        Me.ReportInfo2.Left = 4.729!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "text-align: right"
        Me.ReportInfo2.Top = 0.031!
        Me.ReportInfo2.Width = 2.173!
        '
        'REQUEST_DATE
        '
        Me.REQUEST_DATE.DataField = "REQUEST_DATE"
        Me.REQUEST_DATE.Height = 0.2!
        Me.REQUEST_DATE.Left = 1.345!
        Me.REQUEST_DATE.Name = "REQUEST_DATE"
        Me.REQUEST_DATE.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.REQUEST_DATE.Text = "REQUEST_DATE"
        Me.REQUEST_DATE.Top = 1.766!
        Me.REQUEST_DATE.Width = 2.031103!
        '
        'REQUEST_PLACE
        '
        Me.REQUEST_PLACE.DataField = "REQUEST_PLACE"
        Me.REQUEST_PLACE.Height = 0.2!
        Me.REQUEST_PLACE.Left = 1.345!
        Me.REQUEST_PLACE.Name = "REQUEST_PLACE"
        Me.REQUEST_PLACE.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.REQUEST_PLACE.Text = "REQUEST_PLACE"
        Me.REQUEST_PLACE.Top = 1.971!
        Me.REQUEST_PLACE.Width = 2.031103!
        '
        'PAYMENT
        '
        Me.PAYMENT.DataField = "PAYMENT"
        Me.PAYMENT.Height = 0.2!
        Me.PAYMENT.Left = 1.345!
        Me.PAYMENT.Name = "PAYMENT"
        Me.PAYMENT.Style = "font-size: 9.75pt; vertical-align: middle"
        Me.PAYMENT.Text = "PAYMENT"
        Me.PAYMENT.Top = 2.232!
        Me.PAYMENT.Width = 2.031103!
        '
        'Line4
        '
        Me.Line4.Height = 0.005118012!
        Me.Line4.Left = 0.144!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.965882!
        Me.Line4.Width = 3.232284!
        Me.Line4.X1 = 0.144!
        Me.Line4.X2 = 3.376284!
        Me.Line4.Y1 = 1.971!
        Me.Line4.Y2 = 1.965882!
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 0.144!
        Me.Line5.LineWeight = 2.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 2.171!
        Me.Line5.Width = 3.232284!
        Me.Line5.X1 = 0.144!
        Me.Line5.X2 = 3.376284!
        Me.Line5.Y1 = 2.171!
        Me.Line5.Y2 = 2.171!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 0.144!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 2.406!
        Me.Line6.Width = 3.232284!
        Me.Line6.X1 = 0.144!
        Me.Line6.X2 = 3.376284!
        Me.Line6.Y1 = 2.406!
        Me.Line6.Y2 = 2.406!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.144!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label8.Text = "消費税："
        Me.Label8.Top = 1.027!
        Me.Label8.Width = 1.156693!
        '
        'TOTAL_TAX_PRICE
        '
        Me.TOTAL_TAX_PRICE.DataField = "TOTAL_TAX_PRICE"
        Me.TOTAL_TAX_PRICE.Height = 0.2!
        Me.TOTAL_TAX_PRICE.Left = 1.345!
        Me.TOTAL_TAX_PRICE.Name = "TOTAL_TAX_PRICE"
        Me.TOTAL_TAX_PRICE.OutputFormat = resources.GetString("TOTAL_TAX_PRICE.OutputFormat")
        Me.TOTAL_TAX_PRICE.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.TOTAL_TAX_PRICE.Text = "TOTAL_TAX_PRICE"
        Me.TOTAL_TAX_PRICE.Top = 1.027!
        Me.TOTAL_TAX_PRICE.Width = 2.031102!
        '
        'Line9
        '
        Me.Line9.Height = 0!
        Me.Line9.Left = 0.144!
        Me.Line9.LineWeight = 2.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.227!
        Me.Line9.Width = 3.232284!
        Me.Line9.X1 = 0.144!
        Me.Line9.X2 = 3.376284!
        Me.Line9.Y1 = 1.227!
        Me.Line9.Y2 = 1.227!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.144!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label9.Text = "注文金額(税込み)："
        Me.Label9.Top = 1.53!
        Me.Label9.Width = 1.156693!
        '
        'RTAX_RATE_PRICE
        '
        Me.RTAX_RATE_PRICE.DataField = "RTAX_RATE_PRICE"
        Me.RTAX_RATE_PRICE.Height = 0.2!
        Me.RTAX_RATE_PRICE.Left = 1.345!
        Me.RTAX_RATE_PRICE.Name = "RTAX_RATE_PRICE"
        Me.RTAX_RATE_PRICE.OutputFormat = resources.GetString("RTAX_RATE_PRICE.OutputFormat")
        Me.RTAX_RATE_PRICE.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.RTAX_RATE_PRICE.Text = "RTAX_RATE_PRICE"
        Me.RTAX_RATE_PRICE.Top = 1.272!
        Me.RTAX_RATE_PRICE.Width = 2.031102!
        '
        'Line10
        '
        Me.Line10.Height = 0!
        Me.Line10.Left = 0.144!
        Me.Line10.LineWeight = 2.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 1.73!
        Me.Line10.Width = 3.232284!
        Me.Line10.X1 = 0.144!
        Me.Line10.X2 = 3.376284!
        Me.Line10.Y1 = 1.73!
        Me.Line10.Y2 = 1.73!
        '
        'REPORT_PEACE
        '
        Me.REPORT_PEACE.DataField = "REPORT_PEACE"
        Me.REPORT_PEACE.Height = 0.2!
        Me.REPORT_PEACE.Left = 5.069!
        Me.REPORT_PEACE.Name = "REPORT_PEACE"
        Me.REPORT_PEACE.Style = "text-align: right; vertical-align: bottom"
        Me.REPORT_PEACE.Text = "REPORT_PEACE"
        Me.REPORT_PEACE.Top = 2.232!
        Me.REPORT_PEACE.Width = 1.833!
        '
        'Label28
        '
        Me.Label28.Height = 0.2!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.144!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label28.Text = "軽減税："
        Me.Label28.Top = 1.272!
        Me.Label28.Width = 1.156693!
        '
        'Line13
        '
        Me.Line13.Height = 0!
        Me.Line13.Left = 0.144!
        Me.Line13.LineWeight = 2.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 1.472!
        Me.Line13.Width = 3.232284!
        Me.Line13.X1 = 0.144!
        Me.Line13.X2 = 3.376284!
        Me.Line13.Y1 = 1.472!
        Me.Line13.Y2 = 1.472!
        '
        'TOTAL_AFTER_TAX_PRICE
        '
        Me.TOTAL_AFTER_TAX_PRICE.DataField = "TOTAL_AFTER_TAX_PRICE"
        Me.TOTAL_AFTER_TAX_PRICE.Height = 0.2000001!
        Me.TOTAL_AFTER_TAX_PRICE.Left = 1.345!
        Me.TOTAL_AFTER_TAX_PRICE.Name = "TOTAL_AFTER_TAX_PRICE"
        Me.TOTAL_AFTER_TAX_PRICE.OutputFormat = resources.GetString("TOTAL_AFTER_TAX_PRICE.OutputFormat")
        Me.TOTAL_AFTER_TAX_PRICE.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.TOTAL_AFTER_TAX_PRICE.Text = "TOTAL_AFTER_TAX_PRICE"
        Me.TOTAL_AFTER_TAX_PRICE.Top = 1.53!
        Me.TOTAL_AFTER_TAX_PRICE.Width = 2.031102!
        '
        'GroupHeader9
        '
        Me.GroupHeader9.ColumnSpacing = 0!
        Me.GroupHeader9.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.No, Me.CNT, Me.JAN_CODE, Me.OPTION_VALUE, Me.PRICE, Me.COST, Me.PRODUCT_NAME, Me.Line7, Me.TAX, Me.T_PRICE})
        Me.GroupHeader9.Height = 0.2219907!
        Me.GroupHeader9.Name = "GroupHeader9"
        '
        'No
        '
        Me.No.DataField = "No"
        Me.No.Height = 0.221!
        Me.No.Left = 0.009000001!
        Me.No.Name = "No"
        Me.No.Style = "font-size: 9pt; text-align: center; vertical-align: middle"
        Me.No.Text = "No"
        Me.No.Top = 0!
        Me.No.Width = 0.36!
        '
        'CNT
        '
        Me.CNT.DataField = "CNT"
        Me.CNT.Height = 0.221!
        Me.CNT.Left = 5.317!
        Me.CNT.Name = "CNT"
        Me.CNT.OutputFormat = resources.GetString("CNT.OutputFormat")
        Me.CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.CNT.Style = "text-align: right; vertical-align: middle"
        Me.CNT.Text = "CNT"
        Me.CNT.Top = 0!
        Me.CNT.Width = 0.3944407!
        '
        'JAN_CODE
        '
        Me.JAN_CODE.DataField = "JAN_CODE"
        Me.JAN_CODE.Height = 0.221!
        Me.JAN_CODE.Left = 1.854!
        Me.JAN_CODE.Name = "JAN_CODE"
        Me.JAN_CODE.Style = "font-size: 9pt; text-align: center; vertical-align: middle"
        Me.JAN_CODE.Text = "JAN_CODE"
        Me.JAN_CODE.Top = 0!
        Me.JAN_CODE.Width = 0.9055118!
        '
        'OPTION_VALUE
        '
        Me.OPTION_VALUE.DataField = "OPTION_VALUE"
        Me.OPTION_VALUE.Height = 0.221!
        Me.OPTION_VALUE.Left = 2.76!
        Me.OPTION_VALUE.Name = "OPTION_VALUE"
        Me.OPTION_VALUE.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.OPTION_VALUE.Text = "OPTION_VALUE"
        Me.OPTION_VALUE.Top = 0!
        Me.OPTION_VALUE.Width = 1.358!
        '
        'PRICE
        '
        Me.PRICE.DataField = "PRICE"
        Me.PRICE.Height = 0.221!
        Me.PRICE.Left = 4.118!
        Me.PRICE.Name = "PRICE"
        Me.PRICE.OutputFormat = resources.GetString("PRICE.OutputFormat")
        Me.PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.PRICE.Style = "text-align: right; vertical-align: middle"
        Me.PRICE.Text = "PRICE"
        Me.PRICE.Top = 0!
        Me.PRICE.Width = 0.6080001!
        '
        'COST
        '
        Me.COST.DataField = "COST"
        Me.COST.Height = 0.221!
        Me.COST.Left = 4.726!
        Me.COST.Name = "COST"
        Me.COST.OutputFormat = resources.GetString("COST.OutputFormat")
        Me.COST.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.COST.Style = "text-align: right; vertical-align: middle"
        Me.COST.Text = "COST"
        Me.COST.Top = 0!
        Me.COST.Width = 0.5905514!
        '
        'PRODUCT_NAME
        '
        Me.PRODUCT_NAME.DataField = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Height = 0.221!
        Me.PRODUCT_NAME.Left = 0.369!
        Me.PRODUCT_NAME.Name = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.PRODUCT_NAME.Text = "PRODUCT_NAME"
        Me.PRODUCT_NAME.Top = 0!
        Me.PRODUCT_NAME.Width = 1.485!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 0!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0!
        Me.Line7.Width = 6.9!
        Me.Line7.X1 = 0!
        Me.Line7.X2 = 6.9!
        Me.Line7.Y1 = 0!
        Me.Line7.Y2 = 0!
        '
        'TAX
        '
        Me.TAX.DataField = "TAX"
        Me.TAX.Height = 0.221!
        Me.TAX.Left = 6.377!
        Me.TAX.Name = "TAX"
        Me.TAX.OutputFormat = resources.GetString("TAX.OutputFormat")
        Me.TAX.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TAX.Style = "text-align: right; vertical-align: middle"
        Me.TAX.Text = "TAX"
        Me.TAX.Top = 0!
        Me.TAX.Width = 0.5340004!
        '
        'T_PRICE
        '
        Me.T_PRICE.DataField = "T_PRICE"
        Me.T_PRICE.Height = 0.221!
        Me.T_PRICE.Left = 5.711!
        Me.T_PRICE.Name = "T_PRICE"
        Me.T_PRICE.OutputFormat = resources.GetString("T_PRICE.OutputFormat")
        Me.T_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.T_PRICE.Style = "text-align: right; vertical-align: middle"
        Me.T_PRICE.Text = "T_PRICE"
        Me.T_PRICE.Top = 0!
        Me.T_PRICE.Width = 0.6659999!
        '
        'Label13
        '
        Me.Label13.Height = 0.1874016!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.276!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "background-color: #8080FF; text-align: center"
        Me.Label13.Text = "商品名称（商品番号）"
        Me.Label13.Top = 0!
        Me.Label13.Width = 1.578!
        '
        'Label14
        '
        Me.Label14.Height = 0.1874016!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 1.854!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "background-color: #8080FF; text-align: center"
        Me.Label14.Text = "JANコード"
        Me.Label14.Top = 0!
        Me.Label14.Width = 0.9055118!
        '
        'Label15
        '
        Me.Label15.Height = 0.1874016!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 2.76!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "background-color: #8080FF; text-align: center"
        Me.Label15.Text = "オプション"
        Me.Label15.Top = 0!
        Me.Label15.Width = 1.367!
        '
        'Label16
        '
        Me.Label16.Height = 0.1874016!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.127!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "background-color: #8080FF; text-align: center"
        Me.Label16.Text = "定価"
        Me.Label16.Top = 0!
        Me.Label16.Width = 0.6080005!
        '
        'Label18
        '
        Me.Label18.Height = 0.1874016!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 4.726!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "background-color: #8080FF; text-align: center"
        Me.Label18.Text = "仕入価格"
        Me.Label18.Top = 0!
        Me.Label18.Width = 0.5910006!
        '
        'Label19
        '
        Me.Label19.Height = 0.1874016!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 5.317!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "background-color: #8080FF; text-align: center"
        Me.Label19.Text = "数量"
        Me.Label19.Top = 0!
        Me.Label19.Width = 0.3944407!
        '
        'Label20
        '
        Me.Label20.Height = 0.187!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.711!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "background-color: #8080FF; text-align: center"
        Me.Label20.Text = "金額"
        Me.Label20.Top = 0!
        Me.Label20.Width = 0.6659999!
        '
        'Label30
        '
        Me.Label30.Height = 0.1874016!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 6.32!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "background-color: #8080FF; text-align: center"
        Me.Label30.Text = "税率(%)"
        Me.Label30.Top = 0!
        Me.Label30.Width = 0.591!
        '
        'Label33
        '
        Me.Label33.Height = 0.1874016!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "background-color: #8080FF; text-align: center"
        Me.Label33.Text = "No"
        Me.Label33.Top = 0!
        Me.Label33.Width = 0.369!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line18})
        Me.GroupHeader1.Height = 0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Line18
        '
        Me.Line18.Height = 0!
        Me.Line18.Left = 0!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.1874016!
        Me.Line18.Width = 7.177166!
        Me.Line18.X1 = 0!
        Me.Line18.X2 = 7.177166!
        Me.Line18.Y1 = 0.1874016!
        Me.Line18.Y2 = 0.1874016!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label23, Me.MEMO, Me.Line8, Me.Label31, Me.IN_TAX_TOTAL, Me.Label25, Me.POINT_DISCOUNT})
        Me.GroupFooter1.Height = 2.050469!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label23
        '
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-size: 9.75pt; text-align: left; vertical-align: middle"
        Me.Label23.Text = "【備考】"
        Me.Label23.Top = 0.647!
        Me.Label23.Width = 0.6874019!
        '
        'MEMO
        '
        Me.MEMO.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.DataField = "MEMO"
        Me.MEMO.Height = 0.9945991!
        Me.MEMO.Left = 0.009000001!
        Me.MEMO.Name = "MEMO"
        Me.MEMO.Text = resources.GetString("MEMO.Text")
        Me.MEMO.Top = 0.899!
        Me.MEMO.Width = 6.902!
        '
        'Line8
        '
        Me.Line8.Height = 0!
        Me.Line8.Left = 0!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0!
        Me.Line8.Width = 6.9!
        Me.Line8.X1 = 0!
        Me.Line8.X2 = 6.9!
        Me.Line8.Y1 = 0!
        Me.Line8.Y2 = 0!
        '
        'Label31
        '
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Height = 0.197!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0!
        Me.Label31.Name = "Label31"
        Me.Label31.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label31.Style = "background-color: #8080FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label31.Text = "税込発注金額"
        Me.Label31.Top = 0.2!
        Me.Label31.Width = 4.735!
        '
        'IN_TAX_TOTAL
        '
        Me.IN_TAX_TOTAL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_TAX_TOTAL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_TAX_TOTAL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_TAX_TOTAL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.IN_TAX_TOTAL.DataField = "IN_TAX_TOTAL"
        Me.IN_TAX_TOTAL.Height = 0.197!
        Me.IN_TAX_TOTAL.Left = 4.729!
        Me.IN_TAX_TOTAL.Name = "IN_TAX_TOTAL"
        Me.IN_TAX_TOTAL.OutputFormat = resources.GetString("IN_TAX_TOTAL.OutputFormat")
        Me.IN_TAX_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.IN_TAX_TOTAL.Style = "background-color: #8080FF; text-align: right; vertical-align: middle"
        Me.IN_TAX_TOTAL.SummaryGroup = "TOTAL"
        Me.IN_TAX_TOTAL.Text = " IN_TAX_TOTAL"
        Me.IN_TAX_TOTAL.Top = 0.2!
        Me.IN_TAX_TOTAL.Width = 2.182001!
        '
        'Label25
        '
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Height = 0.1968504!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0!
        Me.Label25.Name = "Label25"
        Me.Label25.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label25.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label25.Text = "ポイント値引き"
        Me.Label25.Top = 0!
        Me.Label25.Width = 4.726!
        '
        'POINT_DISCOUNT
        '
        Me.POINT_DISCOUNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_DISCOUNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_DISCOUNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_DISCOUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_DISCOUNT.Height = 0.2!
        Me.POINT_DISCOUNT.Left = 4.726!
        Me.POINT_DISCOUNT.Name = "POINT_DISCOUNT"
        Me.POINT_DISCOUNT.OutputFormat = resources.GetString("POINT_DISCOUNT.OutputFormat")
        Me.POINT_DISCOUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.POINT_DISCOUNT.Style = "background-color: #C0C0FF; color: Red; text-align: right; vertical-align: middle"
        Me.POINT_DISCOUNT.Text = "POINT_DISCOUNT"
        Me.POINT_DISCOUNT.Top = 0!
        Me.POINT_DISCOUNT.Width = 2.185!
        '
        'Label21
        '
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.1968504!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.009000001!
        Me.Label21.Name = "Label21"
        Me.Label21.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label21.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label21.Text = "軽減税" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label21.Top = 0!
        Me.Label21.Width = 4.726!
        '
        'RTAX_RATE
        '
        Me.RTAX_RATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.RTAX_RATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.RTAX_RATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.RTAX_RATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.RTAX_RATE.DataField = "RTAX_RATE"
        Me.RTAX_RATE.Height = 0.2!
        Me.RTAX_RATE.Left = 4.726!
        Me.RTAX_RATE.Name = "RTAX_RATE"
        Me.RTAX_RATE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.RTAX_RATE.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.RTAX_RATE.SummaryGroup = "TOTAL"
        Me.RTAX_RATE.Text = "RTAX_RATE"
        Me.RTAX_RATE.Top = 0!
        Me.RTAX_RATE.Width = 2.185!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0.01041667!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label17, Me.DISCOUNT})
        Me.GroupFooter2.Height = 0.2!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Label17
        '
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.1968504!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0!
        Me.Label17.Name = "Label17"
        Me.Label17.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label17.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label17.Text = "値引き"
        Me.Label17.Top = 0!
        Me.Label17.Width = 4.726!
        '
        'DISCOUNT
        '
        Me.DISCOUNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.DISCOUNT.Height = 0.2!
        Me.DISCOUNT.Left = 4.726!
        Me.DISCOUNT.Name = "DISCOUNT"
        Me.DISCOUNT.OutputFormat = resources.GetString("DISCOUNT.OutputFormat")
        Me.DISCOUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.DISCOUNT.Style = "background-color: #C0C0FF; color: Red; text-align: right; vertical-align: middle"
        Me.DISCOUNT.Text = "DISCOUNT"
        Me.DISCOUNT.Top = 0!
        Me.DISCOUNT.Width = 2.185!
        '
        'TAX_TOTAL
        '
        Me.TAX_TOTAL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TAX_TOTAL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TAX_TOTAL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TAX_TOTAL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TAX_TOTAL.DataField = "TAX_TOTAL"
        Me.TAX_TOTAL.Height = 0.197!
        Me.TAX_TOTAL.Left = 4.726!
        Me.TAX_TOTAL.Name = "TAX_TOTAL"
        Me.TAX_TOTAL.OutputFormat = resources.GetString("TAX_TOTAL.OutputFormat")
        Me.TAX_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TAX_TOTAL.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.TAX_TOTAL.Text = "TAX_TOTAL"
        Me.TAX_TOTAL.Top = 0!
        Me.TAX_TOTAL.Width = 2.185!
        '
        'Label22
        '
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.1968504!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0!
        Me.Label22.Name = "Label22"
        Me.Label22.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label22.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label22.Text = "消費税"
        Me.Label22.Top = 0!
        Me.Label22.Width = 4.726!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line12})
        Me.GroupHeader3.Height = 0!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'Line12
        '
        Me.Line12.Height = 0!
        Me.Line12.Left = 0!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0.1874016!
        Me.Line12.Width = 7.165354!
        Me.Line12.X1 = 0!
        Me.Line12.X2 = 7.165354!
        Me.Line12.Y1 = 0.1874016!
        Me.Line12.Y2 = 0.1874016!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label21, Me.RTAX_RATE})
        Me.GroupFooter3.Height = 0.19525!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'Label26
        '
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Height = 0.1968504!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 0.009000001!
        Me.Label26.Name = "Label26"
        Me.Label26.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label26.Style = "background-color: #FFFFC0; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label26.Text = "税抜発注金額"
        Me.Label26.Top = 1.396984E-9!
        Me.Label26.Width = 4.717!
        '
        'NO_TAX_TOTAL
        '
        Me.NO_TAX_TOTAL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NO_TAX_TOTAL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NO_TAX_TOTAL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NO_TAX_TOTAL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NO_TAX_TOTAL.DataField = "NO_TAX_TOTAL"
        Me.NO_TAX_TOTAL.Height = 0.2!
        Me.NO_TAX_TOTAL.Left = 4.726!
        Me.NO_TAX_TOTAL.Name = "NO_TAX_TOTAL"
        Me.NO_TAX_TOTAL.OutputFormat = resources.GetString("NO_TAX_TOTAL.OutputFormat")
        Me.NO_TAX_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.NO_TAX_TOTAL.Style = "background-color: #FFFFC0; text-align: right; vertical-align: middle"
        Me.NO_TAX_TOTAL.Text = "NO_TAX_TOTAL"
        Me.NO_TAX_TOTAL.Top = 0!
        Me.NO_TAX_TOTAL.Width = 2.185!
        '
        'GroupHeader4
        '
        Me.GroupHeader4.Height = 0.01041667!
        Me.GroupHeader4.Name = "GroupHeader4"
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label22, Me.TAX_TOTAL})
        Me.GroupFooter4.Height = 0.2!
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'GroupHeader5
        '
        Me.GroupHeader5.Height = 0!
        Me.GroupHeader5.Name = "GroupHeader5"
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label26, Me.NO_TAX_TOTAL})
        Me.GroupFooter5.Height = 0.2!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'GroupHeader6
        '
        Me.GroupHeader6.Height = 0!
        Me.GroupHeader6.Name = "GroupHeader6"
        '
        'GroupFooter6
        '
        Me.GroupFooter6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.FEE, Me.Label27})
        Me.GroupFooter6.Height = 0.2!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'FEE
        '
        Me.FEE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE.DataField = "FEE"
        Me.FEE.Height = 0.2!
        Me.FEE.Left = 4.726!
        Me.FEE.Name = "FEE"
        Me.FEE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.FEE.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.FEE.Text = "FEE"
        Me.FEE.Top = 0!
        Me.FEE.Width = 2.185!
        '
        'Label27
        '
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Height = 0.1968504!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0!
        Me.Label27.Name = "Label27"
        Me.Label27.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label27.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label27.Text = "手数料"
        Me.Label27.Top = 0!
        Me.Label27.Width = 4.726!
        '
        'GroupHeader7
        '
        Me.GroupHeader7.Height = 0!
        Me.GroupHeader7.Name = "GroupHeader7"
        '
        'GroupFooter7
        '
        Me.GroupFooter7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.POSTAGE, Me.Label11})
        Me.GroupFooter7.Height = 0.2!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'POSTAGE
        '
        Me.POSTAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE.DataField = "POSTAGE"
        Me.POSTAGE.Height = 0.2!
        Me.POSTAGE.Left = 4.7!
        Me.POSTAGE.Name = "POSTAGE"
        Me.POSTAGE.OutputFormat = resources.GetString("POSTAGE.OutputFormat")
        Me.POSTAGE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.POSTAGE.Style = "background-color: #C0C0FF; text-align: right; vertical-align: middle"
        Me.POSTAGE.Text = "POSTAGE"
        Me.POSTAGE.Top = 0!
        Me.POSTAGE.Width = 2.211!
        '
        'Label11
        '
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.1968504!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = -2.793968E-9!
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label11.Style = "background-color: #C0C0FF; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label11.Text = "送料"
        Me.Label11.Top = 0!
        Me.Label11.Width = 4.726!
        '
        'GroupHeader8
        '
        Me.GroupHeader8.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CrossSectionBox1, Me.CrossSectionBox2, Me.CrossSectionBox3, Me.CrossSectionBox4, Me.CrossSectionBox5, Me.CrossSectionBox6, Me.CrossSectionBox7, Me.CrossSectionBox8, Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.CrossSectionLine6, Me.CrossSectionLine7, Me.CrossSectionLine8, Me.Label33, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label18, Me.Label19, Me.Label20, Me.Label30, Me.CrossSectionLine9, Me.CrossSectionLine10})
        Me.GroupHeader8.Height = 0.1791897!
        Me.GroupHeader8.Name = "GroupHeader8"
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0!
        Me.CrossSectionBox1.Left = 0!
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Right = 0!
        Me.CrossSectionBox1.Top = 0!
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.Bottom = 0!
        Me.CrossSectionBox2.Left = 0!
        Me.CrossSectionBox2.LineWeight = 1.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Right = 0!
        Me.CrossSectionBox2.Top = 0!
        '
        'CrossSectionBox3
        '
        Me.CrossSectionBox3.Bottom = 0!
        Me.CrossSectionBox3.Left = 0!
        Me.CrossSectionBox3.LineWeight = 1.0!
        Me.CrossSectionBox3.Name = "CrossSectionBox3"
        Me.CrossSectionBox3.Right = 0!
        Me.CrossSectionBox3.Top = 0!
        '
        'CrossSectionBox4
        '
        Me.CrossSectionBox4.Bottom = 0!
        Me.CrossSectionBox4.Left = 0!
        Me.CrossSectionBox4.LineWeight = 1.0!
        Me.CrossSectionBox4.Name = "CrossSectionBox4"
        Me.CrossSectionBox4.Right = 0!
        Me.CrossSectionBox4.Top = 0!
        '
        'CrossSectionBox5
        '
        Me.CrossSectionBox5.Bottom = 0!
        Me.CrossSectionBox5.Left = 0!
        Me.CrossSectionBox5.LineWeight = 1.0!
        Me.CrossSectionBox5.Name = "CrossSectionBox5"
        Me.CrossSectionBox5.Right = 0!
        Me.CrossSectionBox5.Top = 0!
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
        'CrossSectionBox7
        '
        Me.CrossSectionBox7.Bottom = 0!
        Me.CrossSectionBox7.Left = 0!
        Me.CrossSectionBox7.LineWeight = 1.0!
        Me.CrossSectionBox7.Name = "CrossSectionBox7"
        Me.CrossSectionBox7.Right = 0!
        Me.CrossSectionBox7.Top = 0!
        '
        'CrossSectionBox8
        '
        Me.CrossSectionBox8.Bottom = 0!
        Me.CrossSectionBox8.Left = 0!
        Me.CrossSectionBox8.LineWeight = 1.0!
        Me.CrossSectionBox8.Name = "CrossSectionBox8"
        Me.CrossSectionBox8.Right = 0!
        Me.CrossSectionBox8.Top = 0!
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
        Me.CrossSectionLine2.Left = 1.854!
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Top = 0!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.Bottom = 0!
        Me.CrossSectionLine3.Left = 2.76!
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Top = 0!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.Bottom = 0.198125!
        Me.CrossSectionLine4.Left = 4.118!
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Top = 0!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.Bottom = 0!
        Me.CrossSectionLine5.Left = 4.726!
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Top = 0!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.Bottom = 0!
        Me.CrossSectionLine6.Left = 5.317!
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Top = 0!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.Bottom = 0!
        Me.CrossSectionLine7.Left = 5.711!
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Top = 0!
        '
        'CrossSectionLine8
        '
        Me.CrossSectionLine8.Bottom = 0!
        Me.CrossSectionLine8.Left = 6.377!
        Me.CrossSectionLine8.LineWeight = 1.0!
        Me.CrossSectionLine8.Name = "CrossSectionLine8"
        Me.CrossSectionLine8.Top = 0!
        '
        'CrossSectionLine9
        '
        Me.CrossSectionLine9.Bottom = 0!
        Me.CrossSectionLine9.Left = 0.369!
        Me.CrossSectionLine9.LineWeight = 1.0!
        Me.CrossSectionLine9.Name = "CrossSectionLine9"
        Me.CrossSectionLine9.Top = 0!
        '
        'GroupFooter8
        '
        Me.GroupFooter8.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TOTAL_COST, Me.TOTAL_CNT, Me.TOTAL_T_PRICE, Me.Label24, Me.TOTAL_PRICE})
        Me.GroupFooter8.Height = 0.2104167!
        Me.GroupFooter8.Name = "GroupFooter8"
        '
        'TOTAL_COST
        '
        Me.TOTAL_COST.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_COST.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_COST.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_COST.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_COST.DataField = "COST"
        Me.TOTAL_COST.Height = 0.2!
        Me.TOTAL_COST.Left = 4.726!
        Me.TOTAL_COST.Name = "TOTAL_COST"
        Me.TOTAL_COST.OutputFormat = resources.GetString("TOTAL_COST.OutputFormat")
        Me.TOTAL_COST.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_COST.Style = "background-color: #FFFFC0; text-align: right; vertical-align: middle"
        Me.TOTAL_COST.SummaryGroup = "GroupHeader3"
        Me.TOTAL_COST.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_COST.Text = "TOTAL_COST"
        Me.TOTAL_COST.Top = 0!
        Me.TOTAL_COST.Width = 0.5910001!
        '
        'TOTAL_CNT
        '
        Me.TOTAL_CNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.DataField = "CNT"
        Me.TOTAL_CNT.Height = 0.2!
        Me.TOTAL_CNT.Left = 5.317!
        Me.TOTAL_CNT.Name = "TOTAL_CNT"
        Me.TOTAL_CNT.OutputFormat = resources.GetString("TOTAL_CNT.OutputFormat")
        Me.TOTAL_CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_CNT.Style = "background-color: #FFFFC0; text-align: right; vertical-align: middle"
        Me.TOTAL_CNT.SummaryGroup = "GroupHeader3"
        Me.TOTAL_CNT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_CNT.Text = "TOTAL_CNT"
        Me.TOTAL_CNT.Top = 0!
        Me.TOTAL_CNT.Width = 0.3940001!
        '
        'TOTAL_T_PRICE
        '
        Me.TOTAL_T_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.DataField = "T_PRICE"
        Me.TOTAL_T_PRICE.Height = 0.2!
        Me.TOTAL_T_PRICE.Left = 5.711!
        Me.TOTAL_T_PRICE.Name = "TOTAL_T_PRICE"
        Me.TOTAL_T_PRICE.OutputFormat = resources.GetString("TOTAL_T_PRICE.OutputFormat")
        Me.TOTAL_T_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_T_PRICE.Style = "background-color: #FFFFC0; text-align: right; vertical-align: middle"
        Me.TOTAL_T_PRICE.SummaryGroup = "GroupHeader3"
        Me.TOTAL_T_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_T_PRICE.Text = "TOTAL_T_PRICE"
        Me.TOTAL_T_PRICE.Top = 0!
        Me.TOTAL_T_PRICE.Width = 1.2!
        '
        'Label24
        '
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Height = 0.2!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = -2.793968E-9!
        Me.Label24.Name = "Label24"
        Me.Label24.Padding = New DataDynamics.ActiveReports.PaddingEx(130, 0, 130, 0)
        Me.Label24.Style = "background-color: #FFFFC0; text-align: justify; text-justify: distribute-all-line" &
    "s; vertical-align: middle"
        Me.Label24.Text = "小計"
        Me.Label24.Top = 0!
        Me.Label24.Width = 4.717!
        '
        'TOTAL_PRICE
        '
        Me.TOTAL_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.DataField = "PRICE"
        Me.TOTAL_PRICE.Height = 0.2!
        Me.TOTAL_PRICE.Left = 4.118!
        Me.TOTAL_PRICE.Name = "TOTAL_PRICE"
        Me.TOTAL_PRICE.OutputFormat = resources.GetString("TOTAL_PRICE.OutputFormat")
        Me.TOTAL_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_PRICE.Style = "background-color: #FFFFC0; text-align: right; vertical-align: middle"
        Me.TOTAL_PRICE.SummaryGroup = "GroupHeader3"
        Me.TOTAL_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_PRICE.Text = "TOTAL_PRICE"
        Me.TOTAL_PRICE.Top = 0!
        Me.TOTAL_PRICE.Width = 0.599!
        '
        'CrossSectionLine10
        '
        Me.CrossSectionLine10.Bottom = 0.052!
        Me.CrossSectionLine10.Left = 6.911!
        Me.CrossSectionLine10.LineWeight = 1.0!
        Me.CrossSectionLine10.Name = "CrossSectionLine10"
        Me.CrossSectionLine10.Top = 0!
        '
        'rOrderReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.921666!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.GroupHeader5)
        Me.Sections.Add(Me.GroupHeader6)
        Me.Sections.Add(Me.GroupHeader7)
        Me.Sections.Add(Me.GroupHeader8)
        Me.Sections.Add(Me.GroupHeader9)
        Me.Sections.Add(Me.GroupFooter8)
        Me.Sections.Add(Me.GroupFooter7)
        Me.Sections.Add(Me.GroupFooter6)
        Me.Sections.Add(Me.GroupFooter5)
        Me.Sections.Add(Me.GroupFooter4)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUPPLIER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POSTAL_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDRESS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TANTOU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORDER_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_BEFORE_TAX_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REQUEST_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REQUEST_PLACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAYMENT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_TAX_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RTAX_RATE_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORT_PEACE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_AFTER_TAX_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JAN_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_VALUE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IN_TAX_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POINT_DISCOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RTAX_RATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DISCOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAX_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NO_TAX_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FEE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POSTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_COST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents SUPPLIER_NAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents POSTAL_CODE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ADDRESS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CORP_NAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TEL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FAX As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents TANTOU_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents BARCODE As DataDynamics.ActiveReports.Barcode
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents No As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents JAN_CODE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_VALUE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents COST As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PRODUCT_NAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents T_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ORDER_CODE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TOTAL_BEFORE_TAX_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MAKE_DATE As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents REQUEST_DATE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents REQUEST_PLACE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PAYMENT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MEMO As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line18 As DataDynamics.ActiveReports.Line
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents TAX_TOTAL As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TOTAL_TAX_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents RTAX_RATE_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents REPORT_PEACE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line12 As DataDynamics.ActiveReports.Line
    Private WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader6 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label26 As DataDynamics.ActiveReports.Label
    Private WithEvents NO_TAX_TOTAL As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label25 As DataDynamics.ActiveReports.Label
    Private WithEvents POINT_DISCOUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents DISCOUNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Private WithEvents Label27 As DataDynamics.ActiveReports.Label
    Private WithEvents POSTAGE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader8 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Private WithEvents Label14 As DataDynamics.ActiveReports.Label
    Private WithEvents Label15 As DataDynamics.ActiveReports.Label
    Private WithEvents Label18 As DataDynamics.ActiveReports.Label
    Private WithEvents Label19 As DataDynamics.ActiveReports.Label
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox2 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox3 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox4 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox5 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox6 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox7 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents CrossSectionBox8 As DataDynamics.ActiveReports.CrossSectionBox
    Private WithEvents GroupFooter8 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents TOTAL_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_COST As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_CNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents TOTAL_T_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label24 As DataDynamics.ActiveReports.Label
    Private WithEvents CrossSectionLine1 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine2 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine3 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine4 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine5 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine6 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine7 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents Label28 As DataDynamics.ActiveReports.Label
    Private WithEvents Line13 As DataDynamics.ActiveReports.Line
    Private WithEvents TOTAL_AFTER_TAX_PRICE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label30 As DataDynamics.ActiveReports.Label
    Private WithEvents TAX As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label31 As DataDynamics.ActiveReports.Label
    Private WithEvents IN_TAX_TOTAL As DataDynamics.ActiveReports.TextBox
    Private WithEvents CrossSectionLine8 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents Label16 As DataDynamics.ActiveReports.Label
    Private WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents RTAX_RATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents FEE As DataDynamics.ActiveReports.TextBox
    Private WithEvents CrossSectionLine9 As DataDynamics.ActiveReports.CrossSectionLine
    Private WithEvents CrossSectionLine10 As DataDynamics.ActiveReports.CrossSectionLine
End Class
