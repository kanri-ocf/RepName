<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rShopRequestReportPage
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rShopRequestReportPage))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.MAKE_DATE = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.NO_T = New DataDynamics.ActiveReports.TextBox
        Me.CNT_T = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.OPTION_VALUE_T = New DataDynamics.ActiveReports.TextBox
        Me.PRICE_T = New DataDynamics.ActiveReports.TextBox
        Me.PRODUCT_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.T_PRICE_T = New DataDynamics.ActiveReports.TextBox
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.B_TEL_T = New DataDynamics.ActiveReports.TextBox
        Me.Label28 = New DataDynamics.ActiveReports.Label
        Me.B_MAIL_T = New DataDynamics.ActiveReports.TextBox
        Me.S_POST_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label43 = New DataDynamics.ActiveReports.Label
        Me.Label44 = New DataDynamics.ActiveReports.Label
        Me.S_COUNTRY_T = New DataDynamics.ActiveReports.TextBox
        Me.Label45 = New DataDynamics.ActiveReports.Label
        Me.S_STATE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label46 = New DataDynamics.ActiveReports.Label
        Me.S_CITY_T = New DataDynamics.ActiveReports.TextBox
        Me.S_ADDRESS1_T = New DataDynamics.ActiveReports.TextBox
        Me.Label47 = New DataDynamics.ActiveReports.Label
        Me.Label48 = New DataDynamics.ActiveReports.Label
        Me.S_ADDRESS2_T = New DataDynamics.ActiveReports.TextBox
        Me.Label49 = New DataDynamics.ActiveReports.Label
        Me.S_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Label50 = New DataDynamics.ActiveReports.Label
        Me.S_TEL_T = New DataDynamics.ActiveReports.TextBox
        Me.SHIP_CORP_T = New DataDynamics.ActiveReports.TextBox
        Me.Label52 = New DataDynamics.ActiveReports.Label
        Me.Label53 = New DataDynamics.ActiveReports.Label
        Me.Label54 = New DataDynamics.ActiveReports.Label
        Me.SHIP_REQDATE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label55 = New DataDynamics.ActiveReports.Label
        Me.SHIP_REQTIME_T = New DataDynamics.ActiveReports.TextBox
        Me.Label59 = New DataDynamics.ActiveReports.Label
        Me.MEMO_T = New DataDynamics.ActiveReports.TextBox
        Me.Label62 = New DataDynamics.ActiveReports.Label
        Me.TOTAL_T = New DataDynamics.ActiveReports.TextBox
        Me.Label51 = New DataDynamics.ActiveReports.Label
        Me.Label63 = New DataDynamics.ActiveReports.Label
        Me.SALE_TOTAL_T = New DataDynamics.ActiveReports.TextBox
        Me.Label61 = New DataDynamics.ActiveReports.Label
        Me.POSTAGE_T = New DataDynamics.ActiveReports.TextBox
        Me.FEE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label60 = New DataDynamics.ActiveReports.Label
        Me.Label64 = New DataDynamics.ActiveReports.Label
        Me.POINT_T = New DataDynamics.ActiveReports.TextBox
        Me.REQUEST_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.ORG_REQUEST_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.CHANNEL_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.REQUEST_DATE_T = New DataDynamics.ActiveReports.TextBox
        Me.B_POST_CODE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.B_COUNTRY_T = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.B_STATE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.B_CITY_T = New DataDynamics.ActiveReports.TextBox
        Me.B_ADDRESS1_T = New DataDynamics.ActiveReports.TextBox
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.B_ADDRESS2_T = New DataDynamics.ActiveReports.TextBox
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.B_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Label32 = New DataDynamics.ActiveReports.Label
        Me.NOSHI_T = New DataDynamics.ActiveReports.TextBox
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.GIFT_TYPE_T = New DataDynamics.ActiveReports.TextBox
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.NOSHI_NAME_T = New DataDynamics.ActiveReports.TextBox
        Me.Label39 = New DataDynamics.ActiveReports.Label
        Me.GIFT_T = New DataDynamics.ActiveReports.TextBox
        Me.Label30 = New DataDynamics.ActiveReports.Label
        Me.PAYMENT_T = New DataDynamics.ActiveReports.TextBox
        Me.Label37 = New DataDynamics.ActiveReports.Label
        Me.Label41 = New DataDynamics.ActiveReports.Label
        Me.Label42 = New DataDynamics.ActiveReports.Label
        Me.PAY_COUNT_T = New DataDynamics.ActiveReports.TextBox
        Me.BARCODE_B = New DataDynamics.ActiveReports.Barcode
        Me.Label36 = New DataDynamics.ActiveReports.Label
        Me.OTHER_REQ_T = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox2 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox3 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox4 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox5 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox6 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.CrossSectionBox7 = New DataDynamics.ActiveReports.CrossSectionBox
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.TOTAL_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.TOTAL_CNT = New DataDynamics.ActiveReports.TextBox
        Me.TOTAL_T_PRICE = New DataDynamics.ActiveReports.TextBox
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label29 = New DataDynamics.ActiveReports.Label
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.Label34 = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.Label56 = New DataDynamics.ActiveReports.Label
        Me.Label57 = New DataDynamics.ActiveReports.Label
        Me.Label58 = New DataDynamics.ActiveReports.Label
        Me.Label65 = New DataDynamics.ActiveReports.Label
        Me.Label66 = New DataDynamics.ActiveReports.Label
        Me.Label67 = New DataDynamics.ActiveReports.Label
        Me.Label68 = New DataDynamics.ActiveReports.Label
        Me.Label69 = New DataDynamics.ActiveReports.Label
        Me.Label70 = New DataDynamics.ActiveReports.Label
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NO_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPTION_VALUE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCT_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PRICE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_TEL_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_MAIL_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_POST_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_COUNTRY_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_STATE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CITY_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_ADDRESS1_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_ADDRESS2_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_TEL_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHIP_CORP_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHIP_REQDATE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHIP_REQTIME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEMO_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SALE_TOTAL_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POSTAGE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FEE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POINT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REQUEST_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORG_REQUEST_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHANNEL_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REQUEST_DATE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_POST_CODE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_COUNTRY_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_STATE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_CITY_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_ADDRESS1_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_ADDRESS2_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOSHI_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GIFT_TYPE_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOSHI_NAME_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GIFT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAYMENT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAY_COUNT_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OTHER_REQ_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.MAKE_DATE, Me.ReportInfo2})
        Me.PageHeader.Height = 0.4!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.3043307!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.780315!
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New DataDynamics.ActiveReports.PaddingEx(10, 0, 10, 0)
        Me.Label1.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 14.25pt; font-weight" & _
            ": bold; text-align: justify; text-justify: distribute-all-lines; vertical-align:" & _
            " middle"
        Me.Label1.Text = "受注伝票"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.885433!
        '
        'MAKE_DATE
        '
        Me.MAKE_DATE.DataField = "MAKE_DATE"
        Me.MAKE_DATE.FormatString = "作成日:{RunDateTime:yyyy年M月d日}"
        Me.MAKE_DATE.Height = 0.1692913!
        Me.MAKE_DATE.Left = 4.819685!
        Me.MAKE_DATE.Name = "MAKE_DATE"
        Me.MAKE_DATE.Style = "text-align: right; vertical-align: middle"
        Me.MAKE_DATE.SummaryGroup = "GroupHeader1"
        Me.MAKE_DATE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.MAKE_DATE.Top = 0.2307087!
        Me.MAKE_DATE.Width = 2.272048!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{PageNumber} / {PageCount} ページ"
        Me.ReportInfo2.Height = 0.2!
        Me.ReportInfo2.Left = 4.935434!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "text-align: right; vertical-align: middle"
        Me.ReportInfo2.Top = 0.0!
        Me.ReportInfo2.Width = 2.1563!
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.NO_T, Me.CNT_T, Me.PRODUCT_CODE_T, Me.OPTION_VALUE_T, Me.PRICE_T, Me.PRODUCT_NAME_T, Me.T_PRICE_T, Me.Line7})
        Me.Detail.Height = 0.2!
        Me.Detail.Name = "Detail"
        '
        'NO_T
        '
        Me.NO_T.DataField = "NO"
        Me.NO_T.Height = 0.2!
        Me.NO_T.Left = 0.0!
        Me.NO_T.Name = "NO_T"
        Me.NO_T.Style = "font-size: 9pt; text-align: right; vertical-align: middle"
        Me.NO_T.Text = "NO"
        Me.NO_T.Top = 0.0!
        Me.NO_T.Width = 0.2929134!
        '
        'CNT_T
        '
        Me.CNT_T.DataField = "CNT"
        Me.CNT_T.Height = 0.2!
        Me.CNT_T.Left = 5.665749!
        Me.CNT_T.Name = "CNT_T"
        Me.CNT_T.OutputFormat = resources.GetString("CNT_T.OutputFormat")
        Me.CNT_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.CNT_T.Style = "text-align: right; vertical-align: middle"
        Me.CNT_T.Text = "CNT"
        Me.CNT_T.Top = 0.00000002980232!
        Me.CNT_T.Width = 0.5783463!
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.DataField = "PRODUCT_CODE"
        Me.PRODUCT_CODE_T.Height = 0.2!
        Me.PRODUCT_CODE_T.Left = 1.966929!
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.PRODUCT_CODE_T.Text = "PRODUCT_CODE"
        Me.PRODUCT_CODE_T.Top = 0.00000002980232!
        Me.PRODUCT_CODE_T.Width = 0.905512!
        '
        'OPTION_VALUE_T
        '
        Me.OPTION_VALUE_T.DataField = "OPTION_VALUE"
        Me.OPTION_VALUE_T.Height = 0.2!
        Me.OPTION_VALUE_T.Left = 2.872442!
        Me.OPTION_VALUE_T.Name = "OPTION_VALUE_T"
        Me.OPTION_VALUE_T.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.OPTION_VALUE_T.Text = "OPTION_VALUE"
        Me.OPTION_VALUE_T.Top = 0.00000002980232!
        Me.OPTION_VALUE_T.Width = 1.988976!
        '
        'PRICE_T
        '
        Me.PRICE_T.DataField = "PRICE"
        Me.PRICE_T.Height = 0.2!
        Me.PRICE_T.Left = 4.887009!
        Me.PRICE_T.Name = "PRICE_T"
        Me.PRICE_T.OutputFormat = resources.GetString("PRICE_T.OutputFormat")
        Me.PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.PRICE_T.Style = "text-align: right; vertical-align: middle"
        Me.PRICE_T.Text = "PRICE"
        Me.PRICE_T.Top = 0.00000002980232!
        Me.PRICE_T.Width = 0.7787404!
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.DataField = "PRODUCT_NAME"
        Me.PRODUCT_NAME_T.Height = 0.2!
        Me.PRODUCT_NAME_T.Left = 0.2929134!
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Style = "font-size: 9pt; text-align: left; vertical-align: middle"
        Me.PRODUCT_NAME_T.Text = "PRODUCT_NAME"
        Me.PRODUCT_NAME_T.Top = 0.0!
        Me.PRODUCT_NAME_T.Width = 1.674016!
        '
        'T_PRICE_T
        '
        Me.T_PRICE_T.DataField = "T_PRICE"
        Me.T_PRICE_T.Height = 0.2!
        Me.T_PRICE_T.Left = 6.244095!
        Me.T_PRICE_T.Name = "T_PRICE_T"
        Me.T_PRICE_T.OutputFormat = resources.GetString("T_PRICE_T.OutputFormat")
        Me.T_PRICE_T.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.T_PRICE_T.Style = "text-align: right; vertical-align: middle"
        Me.T_PRICE_T.Text = "T_PRICE"
        Me.T_PRICE_T.Top = 0.00000002980232!
        Me.T_PRICE_T.Width = 0.846457!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 0.0!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 7.090552!
        Me.Line7.X1 = 0.0!
        Me.Line7.X2 = 7.090552!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.0!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label27, Me.B_TEL_T, Me.Label28, Me.B_MAIL_T, Me.S_POST_CODE_T, Me.Label21, Me.Label43, Me.Label44, Me.S_COUNTRY_T, Me.Label45, Me.S_STATE_T, Me.Label46, Me.S_CITY_T, Me.S_ADDRESS1_T, Me.Label47, Me.Label48, Me.S_ADDRESS2_T, Me.Label49, Me.S_NAME_T, Me.Label50, Me.S_TEL_T, Me.SHIP_CORP_T, Me.Label52, Me.Label53, Me.Label54, Me.SHIP_REQDATE_T, Me.Label55, Me.SHIP_REQTIME_T, Me.Label59, Me.MEMO_T, Me.Label62, Me.TOTAL_T, Me.Label51, Me.Label63, Me.SALE_TOTAL_T, Me.Label61, Me.POSTAGE_T, Me.FEE_T, Me.Label60, Me.Label64, Me.POINT_T, Me.REQUEST_CODE_T, Me.Label2, Me.Label3, Me.Label4, Me.ORG_REQUEST_CODE_T, Me.Label5, Me.CHANNEL_NAME_T, Me.Label6, Me.REQUEST_DATE_T, Me.B_POST_CODE_T, Me.Label7, Me.Label8, Me.Label9, Me.B_COUNTRY_T, Me.Label10, Me.B_STATE_T, Me.Label22, Me.B_CITY_T, Me.B_ADDRESS1_T, Me.Label24, Me.Label25, Me.B_ADDRESS2_T, Me.Label26, Me.B_NAME_T, Me.Label32, Me.NOSHI_T, Me.Label33, Me.GIFT_TYPE_T, Me.Label35, Me.NOSHI_NAME_T, Me.Label39, Me.GIFT_T, Me.Label30, Me.PAYMENT_T, Me.Label37, Me.Label41, Me.Label42, Me.PAY_COUNT_T, Me.BARCODE_B, Me.Label36, Me.OTHER_REQ_T})
        Me.GroupHeader1.DataField = "REQUEST_CODE"
        Me.GroupHeader1.Height = 6.222376!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label27
        '
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Height = 0.2!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.0000008195639!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label27.Text = "電話番号"
        Me.Label27.Top = 2.70315!
        Me.Label27.Width = 1.0!
        '
        'B_TEL_T
        '
        Me.B_TEL_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_TEL_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_TEL_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_TEL_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_TEL_T.DataField = "B_TEL"
        Me.B_TEL_T.Height = 0.2!
        Me.B_TEL_T.Left = 1.0!
        Me.B_TEL_T.Name = "B_TEL_T"
        Me.B_TEL_T.Style = "vertical-align: middle"
        Me.B_TEL_T.Text = "B_TEL"
        Me.B_TEL_T.Top = 2.70315!
        Me.B_TEL_T.Width = 2.468898!
        '
        'Label28
        '
        Me.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Height = 0.2!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.0000009536743!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label28.Text = "メールアドレス"
        Me.Label28.Top = 2.90315!
        Me.Label28.Width = 1.0!
        '
        'B_MAIL_T
        '
        Me.B_MAIL_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_MAIL_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_MAIL_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_MAIL_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_MAIL_T.DataField = "B_MAIL"
        Me.B_MAIL_T.Height = 0.2!
        Me.B_MAIL_T.Left = 1.0!
        Me.B_MAIL_T.Name = "B_MAIL_T"
        Me.B_MAIL_T.Style = "vertical-align: middle"
        Me.B_MAIL_T.Text = "B_MAIL"
        Me.B_MAIL_T.Top = 2.90315!
        Me.B_MAIL_T.Width = 2.468898!
        '
        'S_POST_CODE_T
        '
        Me.S_POST_CODE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POST_CODE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POST_CODE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POST_CODE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POST_CODE_T.DataField = "S_POST_CODE"
        Me.S_POST_CODE_T.Height = 0.2!
        Me.S_POST_CODE_T.Left = 1.0!
        Me.S_POST_CODE_T.Name = "S_POST_CODE_T"
        Me.S_POST_CODE_T.Style = "vertical-align: middle"
        Me.S_POST_CODE_T.Text = "S_POST_CODE"
        Me.S_POST_CODE_T.Top = 3.611417!
        Me.S_POST_CODE_T.Width = 2.541732!
        '
        'Label21
        '
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.0000001192093!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label21.Text = "郵便番号"
        Me.Label21.Top = 3.611417!
        Me.Label21.Width = 1.0!
        '
        'Label43
        '
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Height = 0.2!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 0.0000002607703!
        Me.Label43.Name = "Label43"
        Me.Label43.Padding = New DataDynamics.ActiveReports.PaddingEx(100, 0, 100, 0)
        Me.Label43.Style = "background-color: LightGrey; text-align: justify; text-justify: distribute-all-li" & _
            "nes; vertical-align: middle"
        Me.Label43.Text = "送付先"
        Me.Label43.Top = 3.408269!
        Me.Label43.Width = 3.541732!
        '
        'Label44
        '
        Me.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Height = 0.2!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 0.0000003278255!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label44.Text = "国名"
        Me.Label44.Top = 3.811419!
        Me.Label44.Width = 1.0!
        '
        'S_COUNTRY_T
        '
        Me.S_COUNTRY_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_COUNTRY_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_COUNTRY_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_COUNTRY_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_COUNTRY_T.DataField = "S_COUNTRY"
        Me.S_COUNTRY_T.Height = 0.2!
        Me.S_COUNTRY_T.Left = 1.0!
        Me.S_COUNTRY_T.Name = "S_COUNTRY_T"
        Me.S_COUNTRY_T.Style = "vertical-align: middle"
        Me.S_COUNTRY_T.Text = "S_COUNTRY"
        Me.S_COUNTRY_T.Top = 3.811419!
        Me.S_COUNTRY_T.Width = 2.541732!
        '
        'Label45
        '
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Height = 0.2!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 0.000000603497!
        Me.Label45.Name = "Label45"
        Me.Label45.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label45.Text = "都道府県"
        Me.Label45.Top = 4.011418!
        Me.Label45.Width = 1.0!
        '
        'S_STATE_T
        '
        Me.S_STATE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_STATE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_STATE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_STATE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_STATE_T.DataField = "S_STATE"
        Me.S_STATE_T.Height = 0.2!
        Me.S_STATE_T.Left = 1.0!
        Me.S_STATE_T.Name = "S_STATE_T"
        Me.S_STATE_T.Style = "vertical-align: middle"
        Me.S_STATE_T.Text = "S_STATE"
        Me.S_STATE_T.Top = 4.011418!
        Me.S_STATE_T.Width = 2.541732!
        '
        'Label46
        '
        Me.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Height = 0.2!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 0.0000008195639!
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label46.Text = "市区町村"
        Me.Label46.Top = 4.211419!
        Me.Label46.Width = 1.0!
        '
        'S_CITY_T
        '
        Me.S_CITY_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CITY_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CITY_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CITY_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CITY_T.DataField = "S_CITY"
        Me.S_CITY_T.Height = 0.2!
        Me.S_CITY_T.Left = 1.0!
        Me.S_CITY_T.Name = "S_CITY_T"
        Me.S_CITY_T.Style = "vertical-align: middle"
        Me.S_CITY_T.Text = "S_CITY"
        Me.S_CITY_T.Top = 4.211419!
        Me.S_CITY_T.Width = 2.541732!
        '
        'S_ADDRESS1_T
        '
        Me.S_ADDRESS1_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS1_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS1_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS1_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS1_T.DataField = "S_ADDRESS1"
        Me.S_ADDRESS1_T.Height = 0.2!
        Me.S_ADDRESS1_T.Left = 1.0!
        Me.S_ADDRESS1_T.Name = "S_ADDRESS1_T"
        Me.S_ADDRESS1_T.Style = "vertical-align: middle"
        Me.S_ADDRESS1_T.Text = "S_ADDRESS1"
        Me.S_ADDRESS1_T.Top = 4.411418!
        Me.S_ADDRESS1_T.Width = 2.541732!
        '
        'Label47
        '
        Me.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Height = 0.2!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 0.0000002384186!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label47.Text = "住所１"
        Me.Label47.Top = 4.411418!
        Me.Label47.Width = 1.0!
        '
        'Label48
        '
        Me.Label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Height = 0.2031505!
        Me.Label48.HyperLink = Nothing
        Me.Label48.Left = 0.0000004470348!
        Me.Label48.Name = "Label48"
        Me.Label48.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label48.Text = "住所２"
        Me.Label48.Top = 4.611416!
        Me.Label48.Width = 1.0!
        '
        'S_ADDRESS2_T
        '
        Me.S_ADDRESS2_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS2_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS2_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS2_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_ADDRESS2_T.DataField = "S_ADDRESS2"
        Me.S_ADDRESS2_T.Height = 0.2031505!
        Me.S_ADDRESS2_T.Left = 1.0!
        Me.S_ADDRESS2_T.Name = "S_ADDRESS2_T"
        Me.S_ADDRESS2_T.Style = "vertical-align: middle"
        Me.S_ADDRESS2_T.Text = "S_ADDRESS2"
        Me.S_ADDRESS2_T.Top = 4.611416!
        Me.S_ADDRESS2_T.Width = 2.541732!
        '
        'Label49
        '
        Me.Label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Height = 0.1968493!
        Me.Label49.HyperLink = Nothing
        Me.Label49.Left = 0.0000007227063!
        Me.Label49.Name = "Label49"
        Me.Label49.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label49.Text = "氏名"
        Me.Label49.Top = 4.814568!
        Me.Label49.Width = 1.0!
        '
        'S_NAME_T
        '
        Me.S_NAME_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_NAME_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_NAME_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_NAME_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_NAME_T.DataField = "S_NAME"
        Me.S_NAME_T.Height = 0.1968493!
        Me.S_NAME_T.Left = 1.0!
        Me.S_NAME_T.Name = "S_NAME_T"
        Me.S_NAME_T.Style = "vertical-align: middle"
        Me.S_NAME_T.Text = "S_NAME"
        Me.S_NAME_T.Top = 4.814568!
        Me.S_NAME_T.Width = 2.541732!
        '
        'Label50
        '
        Me.Label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label50.Height = 0.2!
        Me.Label50.HyperLink = Nothing
        Me.Label50.Left = 0.0000009387729!
        Me.Label50.Name = "Label50"
        Me.Label50.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label50.Text = "電話番号"
        Me.Label50.Top = 5.011418!
        Me.Label50.Width = 1.0!
        '
        'S_TEL_T
        '
        Me.S_TEL_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_TEL_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_TEL_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_TEL_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_TEL_T.DataField = "S_TEL"
        Me.S_TEL_T.Height = 0.2!
        Me.S_TEL_T.Left = 1.0!
        Me.S_TEL_T.Name = "S_TEL_T"
        Me.S_TEL_T.Style = "vertical-align: middle"
        Me.S_TEL_T.Text = "S_TEL"
        Me.S_TEL_T.Top = 5.011418!
        Me.S_TEL_T.Width = 2.541732!
        '
        'SHIP_CORP_T
        '
        Me.SHIP_CORP_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_CORP_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_CORP_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_CORP_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_CORP_T.DataField = "SHIP_CORP"
        Me.SHIP_CORP_T.Height = 0.2031488!
        Me.SHIP_CORP_T.Left = 4.540945!
        Me.SHIP_CORP_T.Name = "SHIP_CORP_T"
        Me.SHIP_CORP_T.Style = "vertical-align: middle"
        Me.SHIP_CORP_T.Text = "SHIP_CORP"
        Me.SHIP_CORP_T.Top = 3.611417!
        Me.SHIP_CORP_T.Width = 2.550788!
        '
        'Label52
        '
        Me.Label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Height = 0.2031488!
        Me.Label52.HyperLink = Nothing
        Me.Label52.Left = 3.540945!
        Me.Label52.Name = "Label52"
        Me.Label52.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label52.Text = "配送業者"
        Me.Label52.Top = 3.611417!
        Me.Label52.Width = 1.0!
        '
        'Label53
        '
        Me.Label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Height = 0.2!
        Me.Label53.HyperLink = Nothing
        Me.Label53.Left = 3.540945!
        Me.Label53.Name = "Label53"
        Me.Label53.Padding = New DataDynamics.ActiveReports.PaddingEx(90, 0, 90, 0)
        Me.Label53.Style = "background-color: LightGrey; text-align: justify; text-justify: distribute-all-li" & _
            "nes; vertical-align: middle"
        Me.Label53.Text = "発送方法"
        Me.Label53.Top = 3.411419!
        Me.Label53.Width = 3.550788!
        '
        'Label54
        '
        Me.Label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Height = 0.2!
        Me.Label54.HyperLink = Nothing
        Me.Label54.Left = 3.540945!
        Me.Label54.Name = "Label54"
        Me.Label54.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label54.Text = "配送希望日"
        Me.Label54.Top = 3.814568!
        Me.Label54.Width = 1.0!
        '
        'SHIP_REQDATE_T
        '
        Me.SHIP_REQDATE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQDATE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQDATE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQDATE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQDATE_T.DataField = "SHIP_REQDATE"
        Me.SHIP_REQDATE_T.Height = 0.2!
        Me.SHIP_REQDATE_T.Left = 4.540945!
        Me.SHIP_REQDATE_T.Name = "SHIP_REQDATE_T"
        Me.SHIP_REQDATE_T.Style = "vertical-align: middle"
        Me.SHIP_REQDATE_T.Text = "SHIP_REQDATE"
        Me.SHIP_REQDATE_T.Top = 3.814568!
        Me.SHIP_REQDATE_T.Width = 2.550788!
        '
        'Label55
        '
        Me.Label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label55.Height = 0.2!
        Me.Label55.HyperLink = Nothing
        Me.Label55.Left = 3.540946!
        Me.Label55.Name = "Label55"
        Me.Label55.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label55.Text = "配送希望時間"
        Me.Label55.Top = 4.014567!
        Me.Label55.Width = 1.0!
        '
        'SHIP_REQTIME_T
        '
        Me.SHIP_REQTIME_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQTIME_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQTIME_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQTIME_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SHIP_REQTIME_T.DataField = "SHIP_REQTIME"
        Me.SHIP_REQTIME_T.Height = 0.2!
        Me.SHIP_REQTIME_T.Left = 4.540945!
        Me.SHIP_REQTIME_T.Name = "SHIP_REQTIME_T"
        Me.SHIP_REQTIME_T.Style = "vertical-align: middle"
        Me.SHIP_REQTIME_T.Text = "SHIP_REQTIME"
        Me.SHIP_REQTIME_T.Top = 4.014567!
        Me.SHIP_REQTIME_T.Width = 2.550788!
        '
        'Label59
        '
        Me.Label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label59.Height = 0.99685!
        Me.Label59.HyperLink = Nothing
        Me.Label59.Left = 3.540946!
        Me.Label59.Name = "Label59"
        Me.Label59.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label59.Text = "配送希望メモ"
        Me.Label59.Top = 4.214568!
        Me.Label59.Width = 1.0!
        '
        'MEMO_T
        '
        Me.MEMO_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO_T.DataField = "MEMO"
        Me.MEMO_T.Height = 0.99685!
        Me.MEMO_T.Left = 4.540945!
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Style = "vertical-align: middle"
        Me.MEMO_T.Text = "MEMO"
        Me.MEMO_T.Top = 4.214568!
        Me.MEMO_T.Width = 2.550788!
        '
        'Label62
        '
        Me.Label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label62.Height = 0.2!
        Me.Label62.HyperLink = Nothing
        Me.Label62.Left = 0.0!
        Me.Label62.Name = "Label62"
        Me.Label62.Padding = New DataDynamics.ActiveReports.PaddingEx(200, 0, 200, 0)
        Me.Label62.Style = "background-color: Silver; text-align: justify; text-justify: distribute-all-lines" & _
            "; vertical-align: middle"
        Me.Label62.Text = "送付先情報"
        Me.Label62.Top = 3.211418!
        Me.Label62.Width = 7.091736!
        '
        'TOTAL_T
        '
        Me.TOTAL_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T.DataField = "TOTAL"
        Me.TOTAL_T.Height = 0.2!
        Me.TOTAL_T.Left = 4.875985!
        Me.TOTAL_T.Name = "TOTAL_T"
        Me.TOTAL_T.OutputFormat = resources.GetString("TOTAL_T.OutputFormat")
        Me.TOTAL_T.Style = "text-align: right; vertical-align: middle"
        Me.TOTAL_T.Text = "TOTAL"
        Me.TOTAL_T.Top = 5.328741!
        Me.TOTAL_T.Width = 2.018898!
        '
        'Label51
        '
        Me.Label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label51.Height = 0.2!
        Me.Label51.HyperLink = Nothing
        Me.Label51.Left = 3.875985!
        Me.Label51.Name = "Label51"
        Me.Label51.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label51.Text = "購入金額"
        Me.Label51.Top = 5.328741!
        Me.Label51.Width = 1.0!
        '
        'Label63
        '
        Me.Label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label63.Height = 0.4602377!
        Me.Label63.HyperLink = Nothing
        Me.Label63.Left = 0.1665359!
        Me.Label63.Name = "Label63"
        Me.Label63.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label63.Text = "ご請求金額"
        Me.Label63.Top = 5.474803!
        Me.Label63.Width = 1.0!
        '
        'SALE_TOTAL_T
        '
        Me.SALE_TOTAL_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_TOTAL_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_TOTAL_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_TOTAL_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.SALE_TOTAL_T.DataField = "SALE_TOTAL"
        Me.SALE_TOTAL_T.Height = 0.4602391!
        Me.SALE_TOTAL_T.Left = 1.166536!
        Me.SALE_TOTAL_T.Name = "SALE_TOTAL_T"
        Me.SALE_TOTAL_T.OutputFormat = resources.GetString("SALE_TOTAL_T.OutputFormat")
        Me.SALE_TOTAL_T.Style = "font-size: 12pt; font-weight: bold; text-align: right; vertical-align: middle"
        Me.SALE_TOTAL_T.Text = "SALE_TOTAL"
        Me.SALE_TOTAL_T.Top = 5.474803!
        Me.SALE_TOTAL_T.Width = 2.550788!
        '
        'Label61
        '
        Me.Label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label61.Height = 0.2!
        Me.Label61.HyperLink = Nothing
        Me.Label61.Left = 3.875985!
        Me.Label61.Name = "Label61"
        Me.Label61.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label61.Text = "送料"
        Me.Label61.Top = 5.531889!
        Me.Label61.Width = 1.0!
        '
        'POSTAGE_T
        '
        Me.POSTAGE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POSTAGE_T.DataField = "POSTAGE"
        Me.POSTAGE_T.Height = 0.2!
        Me.POSTAGE_T.Left = 4.875985!
        Me.POSTAGE_T.Name = "POSTAGE_T"
        Me.POSTAGE_T.OutputFormat = resources.GetString("POSTAGE_T.OutputFormat")
        Me.POSTAGE_T.Style = "text-align: right; vertical-align: middle"
        Me.POSTAGE_T.Text = "POSTAGE"
        Me.POSTAGE_T.Top = 5.531889!
        Me.POSTAGE_T.Width = 2.018898!
        '
        'FEE_T
        '
        Me.FEE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FEE_T.DataField = "FEE"
        Me.FEE_T.Height = 0.1929147!
        Me.FEE_T.Left = 4.875198!
        Me.FEE_T.Name = "FEE_T"
        Me.FEE_T.OutputFormat = resources.GetString("FEE_T.OutputFormat")
        Me.FEE_T.Style = "text-align: right; vertical-align: middle"
        Me.FEE_T.Text = "FEE"
        Me.FEE_T.Top = 5.731889!
        Me.FEE_T.Width = 2.018898!
        '
        'Label60
        '
        Me.Label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label60.Height = 0.2!
        Me.Label60.HyperLink = Nothing
        Me.Label60.Left = 3.875198!
        Me.Label60.Name = "Label60"
        Me.Label60.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label60.Text = "手数料"
        Me.Label60.Top = 5.731889!
        Me.Label60.Width = 1.0!
        '
        'Label64
        '
        Me.Label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label64.Height = 0.2!
        Me.Label64.HyperLink = Nothing
        Me.Label64.Left = 3.875197!
        Me.Label64.Name = "Label64"
        Me.Label64.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label64.Text = "ポイント利用分"
        Me.Label64.Top = 5.924804!
        Me.Label64.Width = 1.0!
        '
        'POINT_T
        '
        Me.POINT_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.POINT_T.DataField = "POINT"
        Me.POINT_T.Height = 0.1999998!
        Me.POINT_T.Left = 4.875197!
        Me.POINT_T.Name = "POINT_T"
        Me.POINT_T.OutputFormat = resources.GetString("POINT_T.OutputFormat")
        Me.POINT_T.Style = "text-align: right; vertical-align: middle"
        Me.POINT_T.Text = "POINT"
        Me.POINT_T.Top = 5.924804!
        Me.POINT_T.Width = 2.018898!
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_CODE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_CODE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_CODE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_CODE_T.DataField = "REQUEST_CODE"
        Me.REQUEST_CODE_T.Height = 0.2!
        Me.REQUEST_CODE_T.Left = 1.0!
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.Style = "vertical-align: middle"
        Me.REQUEST_CODE_T.Text = "REQUEST_CODE"
        Me.REQUEST_CODE_T.Top = 0.2031494!
        Me.REQUEST_CODE_T.Width = 2.468898!
        '
        'Label2
        '
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label2.Text = "注文番号"
        Me.Label2.Top = 0.2031494!
        Me.Label2.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.000000141561!
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New DataDynamics.ActiveReports.PaddingEx(80, 0, 80, 0)
        Me.Label3.Style = "background-color: Silver; text-align: justify; text-justify: distribute-all-lines" & _
            "; vertical-align: middle"
        Me.Label3.Text = "注文情報"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 3.468898!
        '
        'Label4
        '
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0000002086163!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label4.Text = "サイト注文番号"
        Me.Label4.Top = 0.4031494!
        Me.Label4.Width = 1.0!
        '
        'ORG_REQUEST_CODE_T
        '
        Me.ORG_REQUEST_CODE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.ORG_REQUEST_CODE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.ORG_REQUEST_CODE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.ORG_REQUEST_CODE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.ORG_REQUEST_CODE_T.DataField = "ORG_REQUEST_CODE"
        Me.ORG_REQUEST_CODE_T.Height = 0.2!
        Me.ORG_REQUEST_CODE_T.Left = 1.0!
        Me.ORG_REQUEST_CODE_T.Name = "ORG_REQUEST_CODE_T"
        Me.ORG_REQUEST_CODE_T.Style = "vertical-align: middle"
        Me.ORG_REQUEST_CODE_T.Text = "ORG_REQUEST_CODE"
        Me.ORG_REQUEST_CODE_T.Top = 0.4031494!
        Me.ORG_REQUEST_CODE_T.Width = 2.468898!
        '
        'Label5
        '
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.0000004842877!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label5.Text = "チャネル名称"
        Me.Label5.Top = 0.6031497!
        Me.Label5.Width = 1.0!
        '
        'CHANNEL_NAME_T
        '
        Me.CHANNEL_NAME_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.CHANNEL_NAME_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.CHANNEL_NAME_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.CHANNEL_NAME_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.CHANNEL_NAME_T.DataField = "CHANNEL_NAME"
        Me.CHANNEL_NAME_T.Height = 0.2!
        Me.CHANNEL_NAME_T.Left = 1.0!
        Me.CHANNEL_NAME_T.Name = "CHANNEL_NAME_T"
        Me.CHANNEL_NAME_T.Style = "vertical-align: middle"
        Me.CHANNEL_NAME_T.Text = "CHANNEL_NAME"
        Me.CHANNEL_NAME_T.Top = 0.6031497!
        Me.CHANNEL_NAME_T.Width = 2.468898!
        '
        'Label6
        '
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0000007003549!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label6.Text = "注文日時"
        Me.Label6.Top = 0.8031497!
        Me.Label6.Width = 1.0!
        '
        'REQUEST_DATE_T
        '
        Me.REQUEST_DATE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_DATE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_DATE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_DATE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.REQUEST_DATE_T.DataField = "REQUEST_DATE"
        Me.REQUEST_DATE_T.Height = 0.2!
        Me.REQUEST_DATE_T.Left = 1.0!
        Me.REQUEST_DATE_T.Name = "REQUEST_DATE_T"
        Me.REQUEST_DATE_T.Style = "vertical-align: middle"
        Me.REQUEST_DATE_T.Text = "REQUEST_DATE"
        Me.REQUEST_DATE_T.Top = 0.8031497!
        Me.REQUEST_DATE_T.Width = 2.468898!
        '
        'B_POST_CODE_T
        '
        Me.B_POST_CODE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_POST_CODE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_POST_CODE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_POST_CODE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_POST_CODE_T.DataField = "B_POST_CODE"
        Me.B_POST_CODE_T.Height = 0.2!
        Me.B_POST_CODE_T.Left = 1.0!
        Me.B_POST_CODE_T.Name = "B_POST_CODE_T"
        Me.B_POST_CODE_T.Style = "vertical-align: middle"
        Me.B_POST_CODE_T.Text = "B_POST_CODE"
        Me.B_POST_CODE_T.Top = 1.30315!
        Me.B_POST_CODE_T.Width = 2.468898!
        '
        'Label7
        '
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label7.Text = "郵便番号"
        Me.Label7.Top = 1.30315!
        Me.Label7.Width = 1.0!
        '
        'Label8
        '
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.000000141561!
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New DataDynamics.ActiveReports.PaddingEx(80, 0, 80, 0)
        Me.Label8.Style = "background-color: Silver; text-align: justify; text-justify: distribute-all-lines" & _
            "; vertical-align: middle"
        Me.Label8.Text = "請求者情報"
        Me.Label8.Top = 1.1!
        Me.Label8.Width = 3.468898!
        '
        'Label9
        '
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0000002086163!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label9.Text = "国名"
        Me.Label9.Top = 1.503151!
        Me.Label9.Width = 1.0!
        '
        'B_COUNTRY_T
        '
        Me.B_COUNTRY_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_COUNTRY_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_COUNTRY_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_COUNTRY_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_COUNTRY_T.DataField = "B_COUNTRY"
        Me.B_COUNTRY_T.Height = 0.2!
        Me.B_COUNTRY_T.Left = 1.0!
        Me.B_COUNTRY_T.Name = "B_COUNTRY_T"
        Me.B_COUNTRY_T.Style = "vertical-align: middle"
        Me.B_COUNTRY_T.Text = "B_COUNTRY"
        Me.B_COUNTRY_T.Top = 1.503151!
        Me.B_COUNTRY_T.Width = 2.468898!
        '
        'Label10
        '
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0000004842877!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label10.Text = "都道府県"
        Me.Label10.Top = 1.703151!
        Me.Label10.Width = 1.0!
        '
        'B_STATE_T
        '
        Me.B_STATE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_STATE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_STATE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_STATE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_STATE_T.DataField = "B_STATE"
        Me.B_STATE_T.Height = 0.2!
        Me.B_STATE_T.Left = 1.0!
        Me.B_STATE_T.Name = "B_STATE_T"
        Me.B_STATE_T.Style = "vertical-align: middle"
        Me.B_STATE_T.Text = "B_STATE"
        Me.B_STATE_T.Top = 1.703151!
        Me.B_STATE_T.Width = 2.468898!
        '
        'Label22
        '
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.2!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.0000007003549!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label22.Text = "市区町村"
        Me.Label22.Top = 1.90315!
        Me.Label22.Width = 1.0!
        '
        'B_CITY_T
        '
        Me.B_CITY_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_CITY_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_CITY_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_CITY_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_CITY_T.DataField = "B_CITY"
        Me.B_CITY_T.Height = 0.2!
        Me.B_CITY_T.Left = 1.0!
        Me.B_CITY_T.Name = "B_CITY_T"
        Me.B_CITY_T.Style = "vertical-align: middle"
        Me.B_CITY_T.Text = "B_CITY"
        Me.B_CITY_T.Top = 1.90315!
        Me.B_CITY_T.Width = 2.468898!
        '
        'B_ADDRESS1_T
        '
        Me.B_ADDRESS1_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS1_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS1_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS1_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS1_T.DataField = "B_ADDRESS1"
        Me.B_ADDRESS1_T.Height = 0.2!
        Me.B_ADDRESS1_T.Left = 1.0!
        Me.B_ADDRESS1_T.Name = "B_ADDRESS1_T"
        Me.B_ADDRESS1_T.Style = "vertical-align: middle"
        Me.B_ADDRESS1_T.Text = "B_ADDRESS1"
        Me.B_ADDRESS1_T.Top = 2.10315!
        Me.B_ADDRESS1_T.Width = 2.468898!
        '
        'Label24
        '
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Height = 0.2!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.0000001192093!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label24.Text = "住所１"
        Me.Label24.Top = 2.10315!
        Me.Label24.Width = 1.0!
        '
        'Label25
        '
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Height = 0.2!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.0000003278255!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label25.Text = "住所２"
        Me.Label25.Top = 2.30315!
        Me.Label25.Width = 1.0!
        '
        'B_ADDRESS2_T
        '
        Me.B_ADDRESS2_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS2_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS2_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS2_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_ADDRESS2_T.DataField = "B_ADDRESS2"
        Me.B_ADDRESS2_T.Height = 0.2!
        Me.B_ADDRESS2_T.Left = 1.0!
        Me.B_ADDRESS2_T.Name = "B_ADDRESS2_T"
        Me.B_ADDRESS2_T.Style = "vertical-align: middle"
        Me.B_ADDRESS2_T.Text = "B_ADDRESS2"
        Me.B_ADDRESS2_T.Top = 2.30315!
        Me.B_ADDRESS2_T.Width = 2.468898!
        '
        'Label26
        '
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Height = 0.2!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 0.000000603497!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label26.Text = "氏名"
        Me.Label26.Top = 2.50315!
        Me.Label26.Width = 1.0!
        '
        'B_NAME_T
        '
        Me.B_NAME_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_NAME_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_NAME_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_NAME_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.B_NAME_T.DataField = "B_NAME"
        Me.B_NAME_T.Height = 0.2!
        Me.B_NAME_T.Left = 1.0!
        Me.B_NAME_T.Name = "B_NAME_T"
        Me.B_NAME_T.Style = "vertical-align: middle"
        Me.B_NAME_T.Text = "B_NAME"
        Me.B_NAME_T.Top = 2.50315!
        Me.B_NAME_T.Width = 2.468898!
        '
        'Label32
        '
        Me.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Height = 0.2110238!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 3.622835!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label32.Text = "のし"
        Me.Label32.Top = 1.698819!
        Me.Label32.Width = 1.260236!
        '
        'NOSHI_T
        '
        Me.NOSHI_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_T.DataField = "NOSHI"
        Me.NOSHI_T.Height = 0.2110238!
        Me.NOSHI_T.Left = 4.88307!
        Me.NOSHI_T.Name = "NOSHI_T"
        Me.NOSHI_T.Style = "vertical-align: middle"
        Me.NOSHI_T.Text = "NOSHI"
        Me.NOSHI_T.Top = 1.698819!
        Me.NOSHI_T.Width = 0.4783468!
        '
        'Label33
        '
        Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Height = 0.2!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 3.622836!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label33.Text = "ギフト梱包の種類"
        Me.Label33.Top = 2.103544!
        Me.Label33.Width = 1.260236!
        '
        'GIFT_TYPE_T
        '
        Me.GIFT_TYPE_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_TYPE_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_TYPE_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_TYPE_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_TYPE_T.DataField = "GIFT_TYPE"
        Me.GIFT_TYPE_T.Height = 0.1937006!
        Me.GIFT_TYPE_T.Left = 4.883072!
        Me.GIFT_TYPE_T.Name = "GIFT_TYPE_T"
        Me.GIFT_TYPE_T.Style = "vertical-align: middle"
        Me.GIFT_TYPE_T.Text = "GIFT_TYPE"
        Me.GIFT_TYPE_T.Top = 2.109844!
        Me.GIFT_TYPE_T.Width = 2.208661!
        '
        'Label35
        '
        Me.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.Height = 0.2!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 3.622835!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label35.Text = "のし名入れ"
        Me.Label35.Top = 1.909843!
        Me.Label35.Width = 1.260236!
        '
        'NOSHI_NAME_T
        '
        Me.NOSHI_NAME_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_NAME_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_NAME_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_NAME_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.NOSHI_NAME_T.DataField = "NOSHI_NAME"
        Me.NOSHI_NAME_T.Height = 0.2!
        Me.NOSHI_NAME_T.Left = 4.883071!
        Me.NOSHI_NAME_T.Name = "NOSHI_NAME_T"
        Me.NOSHI_NAME_T.Style = "vertical-align: middle"
        Me.NOSHI_NAME_T.Text = "NOSHI_NAME"
        Me.NOSHI_NAME_T.Top = 1.909843!
        Me.NOSHI_NAME_T.Width = 2.208661!
        '
        'Label39
        '
        Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Height = 0.2094483!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 5.361417!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label39.Text = "ギフト梱包"
        Me.Label39.Top = 1.700395!
        Me.Label39.Width = 1.260236!
        '
        'GIFT_T
        '
        Me.GIFT_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.GIFT_T.DataField = "GIFT"
        Me.GIFT_T.Height = 0.2094483!
        Me.GIFT_T.Left = 6.621655!
        Me.GIFT_T.Name = "GIFT_T"
        Me.GIFT_T.Style = "vertical-align: middle"
        Me.GIFT_T.Text = "GIFT"
        Me.GIFT_T.Top = 1.700395!
        Me.GIFT_T.Width = 0.4700789!
        '
        'Label30
        '
        Me.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Height = 0.2031495!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 3.622835!
        Me.Label30.Name = "Label30"
        Me.Label30.Padding = New DataDynamics.ActiveReports.PaddingEx(80, 0, 80, 0)
        Me.Label30.Style = "background-color: Silver; text-align: justify; text-justify: distribute-all-lines" & _
            "; vertical-align: middle"
        Me.Label30.Text = "依頼事項"
        Me.Label30.Top = 1.494883!
        Me.Label30.Width = 3.468898!
        '
        'PAYMENT_T
        '
        Me.PAYMENT_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAYMENT_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAYMENT_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAYMENT_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAYMENT_T.DataField = "PAYMENT"
        Me.PAYMENT_T.Height = 0.2!
        Me.PAYMENT_T.Left = 4.622836!
        Me.PAYMENT_T.Name = "PAYMENT_T"
        Me.PAYMENT_T.Style = "vertical-align: middle"
        Me.PAYMENT_T.Text = "PAYMENT"
        Me.PAYMENT_T.Top = 1.015749!
        Me.PAYMENT_T.Width = 2.468898!
        '
        'Label37
        '
        Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Height = 0.2!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 3.622836!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label37.Text = "支払方法"
        Me.Label37.Top = 1.015749!
        Me.Label37.Width = 1.0!
        '
        'Label41
        '
        Me.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Height = 0.2!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 3.622836!
        Me.Label41.Name = "Label41"
        Me.Label41.Padding = New DataDynamics.ActiveReports.PaddingEx(80, 0, 80, 0)
        Me.Label41.Style = "background-color: Silver; text-align: justify; text-justify: distribute-all-lines" & _
            "; vertical-align: middle"
        Me.Label41.Text = "お支払い情報"
        Me.Label41.Top = 0.8125987!
        Me.Label41.Width = 3.468898!
        '
        'Label42
        '
        Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Height = 0.2!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 3.622836!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label42.Text = "支払回数"
        Me.Label42.Top = 1.215749!
        Me.Label42.Width = 1.0!
        '
        'PAY_COUNT_T
        '
        Me.PAY_COUNT_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAY_COUNT_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAY_COUNT_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAY_COUNT_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.PAY_COUNT_T.DataField = "PAY_COUNT"
        Me.PAY_COUNT_T.Height = 0.2!
        Me.PAY_COUNT_T.Left = 4.622836!
        Me.PAY_COUNT_T.Name = "PAY_COUNT_T"
        Me.PAY_COUNT_T.Style = "vertical-align: middle"
        Me.PAY_COUNT_T.Text = "PAY_COUNT"
        Me.PAY_COUNT_T.Top = 1.215749!
        Me.PAY_COUNT_T.Width = 2.468898!
        '
        'BARCODE_B
        '
        Me.BARCODE_B.DataField = "BARCODE"
        Me.BARCODE_B.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.BARCODE_B.Height = 0.6031497!
        Me.BARCODE_B.Left = 3.9563!
        Me.BARCODE_B.Name = "BARCODE_B"
        Me.BARCODE_B.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN_13
        Me.BARCODE_B.Top = 0.05196851!
        Me.BARCODE_B.Width = 2.75!
        '
        'Label36
        '
        Me.Label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label36.Height = 0.7996063!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 3.622836!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "background-color: Gainsboro; vertical-align: middle"
        Me.Label36.Text = "その他ご要望事項"
        Me.Label36.Top = 2.303544!
        Me.Label36.Width = 1.260236!
        '
        'OTHER_REQ_T
        '
        Me.OTHER_REQ_T.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OTHER_REQ_T.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OTHER_REQ_T.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OTHER_REQ_T.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.OTHER_REQ_T.DataField = "OTHER_REQ"
        Me.OTHER_REQ_T.Height = 0.7996063!
        Me.OTHER_REQ_T.Left = 4.883072!
        Me.OTHER_REQ_T.Name = "OTHER_REQ_T"
        Me.OTHER_REQ_T.Style = "vertical-align: top"
        Me.OTHER_REQ_T.Text = "OTHER_REQ"
        Me.OTHER_REQ_T.Top = 2.303544!
        Me.OTHER_REQ_T.Width = 2.208661!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label19, Me.Label20, Me.Label11, Me.CrossSectionBox1, Me.CrossSectionBox2, Me.CrossSectionBox3, Me.CrossSectionBox4, Me.CrossSectionBox5, Me.CrossSectionBox6, Me.CrossSectionBox7})
        Me.GroupHeader2.Height = 0.4496392!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.0!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "background-color: Silver; text-align: center"
        Me.Label12.Text = "No"
        Me.Label12.Top = 0.2602362!
        Me.Label12.Width = 0.2929134!
        '
        'Label13
        '
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.2929134!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "background-color: Silver; text-align: center"
        Me.Label13.Text = "商品名称"
        Me.Label13.Top = 0.2602362!
        Me.Label13.Width = 1.673228!
        '
        'Label14
        '
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 1.966929!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "background-color: Silver; text-align: center"
        Me.Label14.Text = "商品コード"
        Me.Label14.Top = 0.2602362!
        Me.Label14.Width = 0.905512!
        '
        'Label15
        '
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 2.872442!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "background-color: Silver; text-align: center"
        Me.Label15.Text = "オプション"
        Me.Label15.Top = 0.2602362!
        Me.Label15.Width = 2.014567!
        '
        'Label16
        '
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.887009!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "background-color: Silver; text-align: center"
        Me.Label16.Text = "単価"
        Me.Label16.Top = 0.2602362!
        Me.Label16.Width = 0.7787404!
        '
        'Label19
        '
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.1875!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 5.665749!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "background-color: Silver; text-align: center"
        Me.Label19.Text = "数量"
        Me.Label19.Top = 0.2602362!
        Me.Label19.Width = 0.5783463!
        '
        'Label20
        '
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 6.244095!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "background-color: Silver; text-align: center"
        Me.Label20.Text = "金額"
        Me.Label20.Top = 0.2602362!
        Me.Label20.Width = 0.8523622!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.162992!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 9.75pt; text-align: right; vertical-align: middle"
        Me.Label11.Text = "単位：円(税込)"
        Me.Label11.Top = 0.05118111!
        Me.Label11.Width = 0.8854337!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0.00000002980232!
        Me.CrossSectionBox1.Left = 5.659449!
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Right = 6.243947!
        Me.CrossSectionBox1.Top = 0.2602363!
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.Bottom = 0.00000002980232!
        Me.CrossSectionBox2.Left = 4.871654!
        Me.CrossSectionBox2.LineWeight = 1.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Right = 5.665601!
        Me.CrossSectionBox2.Top = 0.2602363!
        '
        'CrossSectionBox3
        '
        Me.CrossSectionBox3.Bottom = 0.00000002980232!
        Me.CrossSectionBox3.Left = 2.872441!
        Me.CrossSectionBox3.LineWeight = 1.0!
        Me.CrossSectionBox3.Name = "CrossSectionBox3"
        Me.CrossSectionBox3.Right = 4.871506!
        Me.CrossSectionBox3.Top = 0.2602363!
        '
        'CrossSectionBox4
        '
        Me.CrossSectionBox4.Bottom = 0.00000002980232!
        Me.CrossSectionBox4.Left = 6.244095!
        Me.CrossSectionBox4.LineWeight = 1.0!
        Me.CrossSectionBox4.Name = "CrossSectionBox4"
        Me.CrossSectionBox4.Right = 7.091585!
        Me.CrossSectionBox4.Top = 0.2602363!
        '
        'CrossSectionBox5
        '
        Me.CrossSectionBox5.Bottom = 0.00000002980232!
        Me.CrossSectionBox5.Left = 1.966929!
        Me.CrossSectionBox5.LineWeight = 1.0!
        Me.CrossSectionBox5.Name = "CrossSectionBox5"
        Me.CrossSectionBox5.Right = 2.872293!
        Me.CrossSectionBox5.Top = 0.2602363!
        '
        'CrossSectionBox6
        '
        Me.CrossSectionBox6.Bottom = 0.0!
        Me.CrossSectionBox6.Left = 0.2929134!
        Me.CrossSectionBox6.LineWeight = 1.0!
        Me.CrossSectionBox6.Name = "CrossSectionBox6"
        Me.CrossSectionBox6.Right = 1.966929!
        Me.CrossSectionBox6.Top = 0.2602362!
        '
        'CrossSectionBox7
        '
        Me.CrossSectionBox7.Bottom = 0.0!
        Me.CrossSectionBox7.Left = 0.0!
        Me.CrossSectionBox7.LineWeight = 1.0!
        Me.CrossSectionBox7.Name = "CrossSectionBox7"
        Me.CrossSectionBox7.Right = 0.2929134!
        Me.CrossSectionBox7.Top = 0.2602362!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TOTAL_PRICE, Me.TOTAL_CNT, Me.TOTAL_T_PRICE, Me.Label23, Me.Label17, Me.Label18, Me.Label29, Me.Label31, Me.Label34, Me.Label38, Me.Label40, Me.Label56, Me.Label57, Me.Label58, Me.Label65, Me.Label66, Me.Label67, Me.Label68, Me.Label69, Me.Label70})
        Me.GroupFooter2.Height = 1.833335!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'TOTAL_PRICE
        '
        Me.TOTAL_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_PRICE.DataField = "PRICE"
        Me.TOTAL_PRICE.Height = 0.2!
        Me.TOTAL_PRICE.Left = 4.875985!
        Me.TOTAL_PRICE.Name = "TOTAL_PRICE"
        Me.TOTAL_PRICE.OutputFormat = resources.GetString("TOTAL_PRICE.OutputFormat")
        Me.TOTAL_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_PRICE.Style = "background-color: #E0E0E0; text-align: right; vertical-align: middle"
        Me.TOTAL_PRICE.SummaryGroup = "GroupHeader2"
        Me.TOTAL_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_PRICE.Text = "PRICE"
        Me.TOTAL_PRICE.Top = 0.00000002980232!
        Me.TOTAL_PRICE.Width = 0.7897644!
        '
        'TOTAL_CNT
        '
        Me.TOTAL_CNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_CNT.DataField = "CNT"
        Me.TOTAL_CNT.Height = 0.2!
        Me.TOTAL_CNT.Left = 5.665749!
        Me.TOTAL_CNT.Name = "TOTAL_CNT"
        Me.TOTAL_CNT.OutputFormat = resources.GetString("TOTAL_CNT.OutputFormat")
        Me.TOTAL_CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_CNT.Style = "background-color: #E0E0E0; text-align: right; vertical-align: middle"
        Me.TOTAL_CNT.SummaryGroup = "GroupHeader2"
        Me.TOTAL_CNT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_CNT.Text = "CNT"
        Me.TOTAL_CNT.Top = 0.00000002980232!
        Me.TOTAL_CNT.Width = 0.5783463!
        '
        'TOTAL_T_PRICE
        '
        Me.TOTAL_T_PRICE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TOTAL_T_PRICE.DataField = "T_PRICE"
        Me.TOTAL_T_PRICE.Height = 0.2!
        Me.TOTAL_T_PRICE.Left = 6.244095!
        Me.TOTAL_T_PRICE.Name = "TOTAL_T_PRICE"
        Me.TOTAL_T_PRICE.OutputFormat = resources.GetString("TOTAL_T_PRICE.OutputFormat")
        Me.TOTAL_T_PRICE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 3, 0)
        Me.TOTAL_T_PRICE.Style = "background-color: #E0E0E0; text-align: right; vertical-align: middle"
        Me.TOTAL_T_PRICE.SummaryGroup = "GroupHeader2"
        Me.TOTAL_T_PRICE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TOTAL_T_PRICE.Text = "T_PRICE"
        Me.TOTAL_T_PRICE.Top = 0.00000002980232!
        Me.TOTAL_T_PRICE.Width = 0.846457!
        '
        'Label23
        '
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.0!
        Me.Label23.Name = "Label23"
        Me.Label23.Padding = New DataDynamics.ActiveReports.PaddingEx(120, 0, 120, 0)
        Me.Label23.Style = "background-color: #E0E0E0; text-align: justify; text-justify: distribute-all-line" & _
            "s; vertical-align: middle"
        Me.Label23.Text = "合計"
        Me.Label23.Top = 0.0!
        Me.Label23.Width = 4.875985!
        '
        'Label17
        '
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.3751965!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.0!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "vertical-align: middle"
        Me.Label17.Text = "入金状況"
        Me.Label17.Top = 0.5188977!
        Me.Label17.Width = 0.8019686!
        '
        'Label18
        '
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.3751965!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.0!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "vertical-align: middle"
        Me.Label18.Text = "出荷状況"
        Me.Label18.Top = 0.8925198!
        Me.Label18.Width = 0.8019686!
        '
        'Label29
        '
        Me.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Height = 0.5208669!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 0.0!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "vertical-align: middle"
        Me.Label29.Text = "連絡状況"
        Me.Label29.Top = 1.268898!
        Me.Label29.Width = 0.8019686!
        '
        'Label31
        '
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Height = 0.3751965!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.8019686!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "vertical-align: middle"
        Me.Label31.Text = ""
        Me.Label31.Top = 0.5188976!
        Me.Label31.Width = 1.557087!
        '
        'Label34
        '
        Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Height = 0.3751965!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.8019686!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "vertical-align: middle"
        Me.Label34.Text = ""
        Me.Label34.Top = 0.8925198!
        Me.Label34.Width = 1.557087!
        '
        'Label38
        '
        Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Height = 0.5208669!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.8019686!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "vertical-align: middle"
        Me.Label38.Text = ""
        Me.Label38.Top = 1.268898!
        Me.Label38.Width = 1.557087!
        '
        'Label40
        '
        Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Height = 0.3751965!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 6.171654!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "vertical-align: middle"
        Me.Label40.Text = ""
        Me.Label40.Top = 0.5188977!
        Me.Label40.Width = 0.9188982!
        '
        'Label56
        '
        Me.Label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Height = 0.3751965!
        Me.Label56.HyperLink = Nothing
        Me.Label56.Left = 6.171654!
        Me.Label56.Name = "Label56"
        Me.Label56.Style = "vertical-align: middle"
        Me.Label56.Text = ""
        Me.Label56.Top = 0.8925194!
        Me.Label56.Width = 0.9188982!
        '
        'Label57
        '
        Me.Label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Height = 0.5208669!
        Me.Label57.HyperLink = Nothing
        Me.Label57.Left = 6.171654!
        Me.Label57.Name = "Label57"
        Me.Label57.Style = "vertical-align: middle"
        Me.Label57.Text = ""
        Me.Label57.Top = 1.268898!
        Me.Label57.Width = 0.9188981!
        '
        'Label58
        '
        Me.Label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Height = 0.218832!
        Me.Label58.HyperLink = Nothing
        Me.Label58.Left = 0.0!
        Me.Label58.Name = "Label58"
        Me.Label58.Style = "background-color: Silver; text-align: center; vertical-align: middle"
        Me.Label58.Text = "項目名称"
        Me.Label58.Top = 0.3!
        Me.Label58.Width = 0.8019687!
        '
        'Label65
        '
        Me.Label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Height = 0.218832!
        Me.Label65.HyperLink = Nothing
        Me.Label65.Left = 0.8019687!
        Me.Label65.Name = "Label65"
        Me.Label65.Style = "background-color: Silver; text-align: center; vertical-align: middle"
        Me.Label65.Text = "日付"
        Me.Label65.Top = 0.3!
        Me.Label65.Width = 1.557087!
        '
        'Label66
        '
        Me.Label66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label66.Height = 0.218832!
        Me.Label66.HyperLink = Nothing
        Me.Label66.Left = 6.171654!
        Me.Label66.Name = "Label66"
        Me.Label66.Style = "background-color: Silver; text-align: center; vertical-align: middle"
        Me.Label66.Text = "担当者"
        Me.Label66.Top = 0.3!
        Me.Label66.Width = 0.9188981!
        '
        'Label67
        '
        Me.Label67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label67.Height = 0.218832!
        Me.Label67.HyperLink = Nothing
        Me.Label67.Left = 2.359055!
        Me.Label67.Name = "Label67"
        Me.Label67.Style = "background-color: Silver; text-align: center; vertical-align: middle"
        Me.Label67.Text = "内容"
        Me.Label67.Top = 0.3!
        Me.Label67.Width = 3.812599!
        '
        'Label68
        '
        Me.Label68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label68.Height = 0.3751965!
        Me.Label68.HyperLink = Nothing
        Me.Label68.Left = 2.359055!
        Me.Label68.Name = "Label68"
        Me.Label68.Style = "vertical-align: middle"
        Me.Label68.Text = ""
        Me.Label68.Top = 0.5188976!
        Me.Label68.Width = 3.812599!
        '
        'Label69
        '
        Me.Label69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label69.Height = 0.3751965!
        Me.Label69.HyperLink = Nothing
        Me.Label69.Left = 2.359055!
        Me.Label69.Name = "Label69"
        Me.Label69.Style = "vertical-align: middle"
        Me.Label69.Text = ""
        Me.Label69.Top = 0.8925201!
        Me.Label69.Width = 3.812599!
        '
        'Label70
        '
        Me.Label70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label70.Height = 0.5208669!
        Me.Label70.HyperLink = Nothing
        Me.Label70.Left = 2.359055!
        Me.Label70.Name = "Label70"
        Me.Label70.Style = "vertical-align: middle"
        Me.Label70.Text = ""
        Me.Label70.Top = 1.268898!
        Me.Label70.Width = 3.812599!
        '
        'rRequestReportPage
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.114764!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NO_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPTION_VALUE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCT_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PRICE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_TEL_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_MAIL_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_POST_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_COUNTRY_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_STATE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CITY_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_ADDRESS1_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_ADDRESS2_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_TEL_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHIP_CORP_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHIP_REQDATE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHIP_REQTIME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEMO_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SALE_TOTAL_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POSTAGE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FEE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POINT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REQUEST_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORG_REQUEST_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHANNEL_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REQUEST_DATE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_POST_CODE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_COUNTRY_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_STATE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_CITY_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_ADDRESS1_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_ADDRESS2_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOSHI_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GIFT_TYPE_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOSHI_NAME_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GIFT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAYMENT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAY_COUNT_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OTHER_REQ_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTAL_T_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents NO_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CNT_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PRODUCT_CODE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OPTION_VALUE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PRICE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PRODUCT_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents T_PRICE_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Private WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Private WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_TEL_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label28 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_MAIL_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_POST_CODE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label43 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label44 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_COUNTRY_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_STATE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label46 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_CITY_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_ADDRESS1_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label47 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label48 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_ADDRESS2_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label49 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label50 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_TEL_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SHIP_CORP_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label52 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label53 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label54 As DataDynamics.ActiveReports.Label
    Friend WithEvents SHIP_REQDATE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label55 As DataDynamics.ActiveReports.Label
    Friend WithEvents SHIP_REQTIME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label59 As DataDynamics.ActiveReports.Label
    Friend WithEvents MEMO_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label62 As DataDynamics.ActiveReports.Label
    Friend WithEvents TOTAL_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label51 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label63 As DataDynamics.ActiveReports.Label
    Friend WithEvents SALE_TOTAL_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label61 As DataDynamics.ActiveReports.Label
    Friend WithEvents POSTAGE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FEE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label60 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label64 As DataDynamics.ActiveReports.Label
    Friend WithEvents POINT_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents REQUEST_CODE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents ORG_REQUEST_CODE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents CHANNEL_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents REQUEST_DATE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents B_POST_CODE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_COUNTRY_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_STATE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_CITY_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents B_ADDRESS1_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_ADDRESS2_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents B_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label32 As DataDynamics.ActiveReports.Label
    Friend WithEvents NOSHI_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents GIFT_TYPE_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents NOSHI_NAME_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label39 As DataDynamics.ActiveReports.Label
    Friend WithEvents GIFT_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label30 As DataDynamics.ActiveReports.Label
    Friend WithEvents PAYMENT_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label41 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label42 As DataDynamics.ActiveReports.Label
    Friend WithEvents PAY_COUNT_T As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BARCODE_B As DataDynamics.ActiveReports.Barcode
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents OTHER_REQ_T As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox2 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox3 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox4 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox5 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox6 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents CrossSectionBox7 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents TOTAL_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TOTAL_CNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TOTAL_T_PRICE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label29 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label34 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label40 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label56 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label57 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label58 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label65 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label66 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label67 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label68 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label69 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label70 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents MAKE_DATE As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo

    Private Sub rRequestReportPage_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd

    End Sub
End Class
