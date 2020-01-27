<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class rDayCloseReport
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rDayCloseReport))
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.STAFFNAME = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label47 = New DataDynamics.ActiveReports.Label()
        Me.MAKE_DATE = New DataDynamics.ActiveReports.ReportInfo()
        Me.CLOSEDATE = New DataDynamics.ActiveReports.TextBox()
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.S_CLASS = New DataDynamics.ActiveReports.TextBox()
        Me.S_BUMON = New DataDynamics.ActiveReports.TextBox()
        Me.S_CHANNEL = New DataDynamics.ActiveReports.TextBox()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.D_R10000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R5000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R1000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R500 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R100 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R50 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R10 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R5 = New DataDynamics.ActiveReports.TextBox()
        Me.D_R1 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K10000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K5000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K1000 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K500 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K100 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K50 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K10 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K5 = New DataDynamics.ActiveReports.TextBox()
        Me.D_K1 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.K_R10000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R5000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R1000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R500 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R100 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R50 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R10 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R5 = New DataDynamics.ActiveReports.TextBox()
        Me.K_R1 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K10000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K5000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K1000 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K500 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K100 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K50 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K10 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K5 = New DataDynamics.ActiveReports.TextBox()
        Me.K_K1 = New DataDynamics.ActiveReports.TextBox()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label48 = New DataDynamics.ActiveReports.Label()
        Me.D_R_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.D_K_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Label49 = New DataDynamics.ActiveReports.Label()
        Me.K_R_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.K_K_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Label50 = New DataDynamics.ActiveReports.Label()
        Me.D_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Label51 = New DataDynamics.ActiveReports.Label()
        Me.K_TOTAL = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.Line14 = New DataDynamics.ActiveReports.Line()
        Me.Line15 = New DataDynamics.ActiveReports.Line()
        Me.Line16 = New DataDynamics.ActiveReports.Line()
        Me.Line17 = New DataDynamics.ActiveReports.Line()
        Me.Line18 = New DataDynamics.ActiveReports.Line()
        Me.Line19 = New DataDynamics.ActiveReports.Line()
        Me.Line20 = New DataDynamics.ActiveReports.Line()
        Me.Line21 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.INOUT_DETAIL1 = New DataDynamics.ActiveReports.SubReport()
        Me.INOUT_DETAIL2 = New DataDynamics.ActiveReports.SubReport()
        Me.INOUT_DETAIL3 = New DataDynamics.ActiveReports.SubReport()
        Me.INOUT_DETAIL4 = New DataDynamics.ActiveReports.SubReport()
        Me.PageBreak1 = New DataDynamics.ActiveReports.PageBreak()
        Me.INOUT_DETAIL5 = New DataDynamics.ActiveReports.SubReport()
        Me.INOUT_DETAIL6 = New DataDynamics.ActiveReports.SubReport()
        Me.PageBreak2 = New DataDynamics.ActiveReports.PageBreak()
        Me.INOUT_DETAIL7 = New DataDynamics.ActiveReports.SubReport()
        Me.S_OUTCASH = New DataDynamics.ActiveReports.TextBox()
        Me.S_INCASH = New DataDynamics.ActiveReports.TextBox()
        Me.S_CALCASH = New DataDynamics.ActiveReports.TextBox()
        Me.S_RETCASH = New DataDynamics.ActiveReports.TextBox()
        Me.S_CCASH = New DataDynamics.ActiveReports.TextBox()
        Me.Label41 = New DataDynamics.ActiveReports.Label()
        Me.Label42 = New DataDynamics.ActiveReports.Label()
        Me.Label43 = New DataDynamics.ActiveReports.Label()
        Me.Label44 = New DataDynamics.ActiveReports.Label()
        Me.Label45 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.Label32 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.Label34 = New DataDynamics.ActiveReports.Label()
        Me.Label35 = New DataDynamics.ActiveReports.Label()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.Label37 = New DataDynamics.ActiveReports.Label()
        Me.Label38 = New DataDynamics.ActiveReports.Label()
        Me.Label39 = New DataDynamics.ActiveReports.Label()
        Me.Label46 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label52 = New DataDynamics.ActiveReports.Label()
        Me.Label53 = New DataDynamics.ActiveReports.Label()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.Label56 = New DataDynamics.ActiveReports.Label()
        Me.S_YCASH = New DataDynamics.ActiveReports.TextBox()
        Me.S_SALECNT = New DataDynamics.ActiveReports.TextBox()
        Me.S_SALECASH = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.S_OUTCNT = New DataDynamics.ActiveReports.TextBox()
        Me.S_INCNT = New DataDynamics.ActiveReports.TextBox()
        Me.sumS_SALES = New DataDynamics.ActiveReports.TextBox()
        Me.sumS_CNT = New DataDynamics.ActiveReports.TextBox()
        Me.sumS_DISCOUNT = New DataDynamics.ActiveReports.TextBox()
        Me.sumS_POSTAGE = New DataDynamics.ActiveReports.TextBox()
        Me.sumS_FEE = New DataDynamics.ActiveReports.TextBox()
        Me.Label40 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.CrossSectionBox1 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.Label55 = New DataDynamics.ActiveReports.Label()
        Me.CrossSectionBox2 = New DataDynamics.ActiveReports.CrossSectionBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.sumS_BILL = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.Label54 = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.S_PAYMENT = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        Me.S_CNT = New DataDynamics.ActiveReports.TextBox()
        Me.S_FEE = New DataDynamics.ActiveReports.TextBox()
        Me.S_DISCOUNT = New DataDynamics.ActiveReports.TextBox()
        Me.S_BILL = New DataDynamics.ActiveReports.TextBox()
        Me.S_POSTAGE = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.S_SALES = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STAFFNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLOSEDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CLASS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_BUMON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CHANNEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R10000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R5000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R500, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K10000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K5000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K500, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R10000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R5000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R500, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K10000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K5000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K500, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_R_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_K_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_R_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_K_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_OUTCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_INCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CALCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_RETCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_YCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_SALECNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_SALECASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_OUTCNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_INCNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_DISCOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_POSTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_FEE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sumS_BILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_PAYMENT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_FEE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_DISCOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_BILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_POSTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.S_SALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label3, Me.ReportInfo2, Me.STAFFNAME, Me.Label2, Me.Label47, Me.MAKE_DATE, Me.CLOSEDATE})
        Me.PageHeader.Height = 0.676919!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Height = 0.2208662!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "background-color: LightGrey; font-family: ＭＳ Ｐゴシック; font-size: 11.25pt; font-weig" &
    "ht: bold; text-align: center; vertical-align: middle"
        Me.Label1.Text = "日　次　集　計　表"
        Me.Label1.Top = 0!
        Me.Label1.Width = 7.540946!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.Label3.Text = "作成者："
        Me.Label3.Top = 0.4602363!
        Me.Label3.Width = 0.75!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{PageNumber} / {PageCount} ページ"
        Me.ReportInfo2.Height = 0.2!
        Me.ReportInfo2.Left = 4.872!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.ReportInfo2.Top = 0.291!
        Me.ReportInfo2.Width = 2.416536!
        '
        'STAFFNAME
        '
        Me.STAFFNAME.DataField = "STAFFNAME"
        Me.STAFFNAME.Height = 0.1770833!
        Me.STAFFNAME.Left = 0.7933071!
        Me.STAFFNAME.Name = "STAFFNAME"
        Me.STAFFNAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.STAFFNAME.Text = "STAFFNAME"
        Me.STAFFNAME.Top = 0.4602363!
        Me.STAFFNAME.Width = 1.53125!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.Label2.Text = "締め日："
        Me.Label2.Top = 0.2909449!
        Me.Label2.Width = 0.75!
        '
        'Label47
        '
        Me.Label47.Height = 0.2!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 4.987!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.Label47.Text = "作成日："
        Me.Label47.Top = 0.468!
        Me.Label47.Width = 0.75!
        '
        'MAKE_DATE
        '
        Me.MAKE_DATE.DataField = "MAKE_DATE"
        Me.MAKE_DATE.FormatString = "{RunDateTime:yyyy年M月d日}"
        Me.MAKE_DATE.Height = 0.1692913!
        Me.MAKE_DATE.Left = 5.757!
        Me.MAKE_DATE.Name = "MAKE_DATE"
        Me.MAKE_DATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: left"
        Me.MAKE_DATE.Top = 0.468!
        Me.MAKE_DATE.Width = 1.531103!
        '
        'CLOSEDATE
        '
        Me.CLOSEDATE.DataField = "CLOSEDATE"
        Me.CLOSEDATE.Height = 0.1770833!
        Me.CLOSEDATE.Left = 0.7933072!
        Me.CLOSEDATE.Name = "CLOSEDATE"
        Me.CLOSEDATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt"
        Me.CLOSEDATE.Text = "CLOSEDATE"
        Me.CLOSEDATE.Top = 0.2830709!
        Me.CLOSEDATE.Width = 1.53125!
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Detail.CanGrow = False
        Me.Detail.ColumnSpacing = 0!
        Me.Detail.Height = 0!
        Me.Detail.Name = "Detail"
        '
        'S_CLASS
        '
        Me.S_CLASS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CLASS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CLASS.ClassName = "B_LABEL"
        Me.S_CLASS.DataField = "S_CLASS"
        Me.S_CLASS.Height = 0.1374016!
        Me.S_CLASS.Left = 0!
        Me.S_CLASS.Name = "S_CLASS"
        Me.S_CLASS.Style = "background-color: White; font-size: 8.25pt; text-align: left; white-space: inheri" &
    "t; ddo-char-set: 128"
        Me.S_CLASS.Text = "売上"
        Me.S_CLASS.Top = 9.313226E-10!
        Me.S_CLASS.Width = 0.5417323!
        '
        'S_BUMON
        '
        Me.S_BUMON.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_BUMON.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_BUMON.ClassName = "B_LABEL"
        Me.S_BUMON.DataField = "S_BUMON"
        Me.S_BUMON.Height = 0.1374016!
        Me.S_BUMON.Left = 1.325197!
        Me.S_BUMON.Name = "S_BUMON"
        Me.S_BUMON.Style = "background-color: White; font-size: 8.25pt; text-align: left; vertical-align: mid" &
    "dle; ddo-char-set: 128"
        Me.S_BUMON.Text = "部門"
        Me.S_BUMON.Top = 0!
        Me.S_BUMON.Width = 1.011024!
        '
        'S_CHANNEL
        '
        Me.S_CHANNEL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CHANNEL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CHANNEL.ClassName = "B_LABEL"
        Me.S_CHANNEL.DataField = "S_CHANNEL"
        Me.S_CHANNEL.Height = 0.1374016!
        Me.S_CHANNEL.Left = 0.5519685!
        Me.S_CHANNEL.Name = "S_CHANNEL"
        Me.S_CHANNEL.Style = "background-color: White; font-size: 8.25pt; text-align: left; vertical-align: mid" &
    "dle; ddo-char-set: 128"
        Me.S_CHANNEL.Text = "チャネル名"
        Me.S_CHANNEL.Top = 0!
        Me.S_CHANNEL.Width = 0.7629923!
        '
        'Label4
        '
        Me.Label4.ClassName = "B_LABEL"
        Me.Label4.Height = 0.1795275!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "background-color: Silver; font-size: 8.25pt; ddo-char-set: 128"
        Me.Label4.Text = "入金状況"
        Me.Label4.Top = 0.1452756!
        Me.Label4.Width = 3.379134!
        '
        'Label6
        '
        Me.Label6.ClassName = "B_LABEL"
        Me.Label6.Height = 0.1480315!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; ddo-char-" &
    "set: 128"
        Me.Label6.Text = "紙幣・硬貨"
        Me.Label6.Top = 0.3248031!
        Me.Label6.Width = 0.7874016!
        '
        'Label7
        '
        Me.Label7.ClassName = "B_LABEL"
        Me.Label7.Height = 0.1480321!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.7933071!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set:" &
    " 128"
        Me.Label7.Text = "レジ入金"
        Me.Label7.Top = 0.3248032!
        Me.Label7.Width = 1.291733!
        '
        'Label8
        '
        Me.Label8.ClassName = "B_LABEL"
        Me.Label8.Height = 0.1480315!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.085039!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set:" &
    " 128"
        Me.Label8.Text = "金庫残高"
        Me.Label8.Top = 0.3248032!
        Me.Label8.Width = 1.291732!
        '
        'Label5
        '
        Me.Label5.ClassName = "B_LABEL"
        Me.Label5.Height = 0.1480315!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0!
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label5.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label5.Text = "10,000"
        Me.Label5.Top = 0.4728346!
        Me.Label5.Width = 0.7874016!
        '
        'Label9
        '
        Me.Label9.ClassName = "B_LABEL"
        Me.Label9.Height = 0.1480321!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0!
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label9.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label9.Text = "5,000"
        Me.Label9.Top = 0.6208662!
        Me.Label9.Width = 0.7933071!
        '
        'Label10
        '
        Me.Label10.ClassName = "B_LABEL"
        Me.Label10.Height = 0.1480321!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0!
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label10.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label10.Text = "1,000"
        Me.Label10.Top = 0.7688977!
        Me.Label10.Width = 0.7933071!
        '
        'Label11
        '
        Me.Label11.ClassName = "B_LABEL"
        Me.Label11.Height = 0.1492126!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0!
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label11.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label11.Text = "500"
        Me.Label11.Top = 0.907874!
        Me.Label11.Width = 0.7933071!
        '
        'Label12
        '
        Me.Label12.ClassName = "B_LABEL"
        Me.Label12.Height = 0.1492126!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0!
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label12.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label12.Text = "100"
        Me.Label12.Top = 1.057087!
        Me.Label12.Width = 0.7933071!
        '
        'Label13
        '
        Me.Label13.ClassName = "B_LABEL"
        Me.Label13.Height = 0.1480315!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0!
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label13.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label13.Text = "50"
        Me.Label13.Top = 1.206299!
        Me.Label13.Width = 0.7933071!
        '
        'Label14
        '
        Me.Label14.ClassName = "B_LABEL"
        Me.Label14.Height = 0.1480315!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0!
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label14.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label14.Text = "10"
        Me.Label14.Top = 1.355512!
        Me.Label14.Width = 0.7933071!
        '
        'Label15
        '
        Me.Label15.ClassName = "B_LABEL"
        Me.Label15.Height = 0.1480315!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0!
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label15.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label15.Text = "5"
        Me.Label15.Top = 1.504724!
        Me.Label15.Width = 0.7933063!
        '
        'Label16
        '
        Me.Label16.ClassName = "B_LABEL"
        Me.Label16.Height = 0.1480321!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0!
        Me.Label16.Name = "Label16"
        Me.Label16.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label16.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label16.Text = "1"
        Me.Label16.Top = 1.653937!
        Me.Label16.Width = 0.7933071!
        '
        'D_R10000
        '
        Me.D_R10000.DataField = "D_R10000"
        Me.D_R10000.Height = 0.138977!
        Me.D_R10000.Left = 0.7933071!
        Me.D_R10000.Name = "D_R10000"
        Me.D_R10000.OutputFormat = resources.GetString("D_R10000.OutputFormat")
        Me.D_R10000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R10000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R10000.Text = "TextBox1"
        Me.D_R10000.Top = 0.4728341!
        Me.D_R10000.Width = 1.291732!
        '
        'D_R5000
        '
        Me.D_R5000.DataField = "D_R5000"
        Me.D_R5000.Height = 0.1480317!
        Me.D_R5000.Left = 0.7933071!
        Me.D_R5000.Name = "D_R5000"
        Me.D_R5000.OutputFormat = resources.GetString("D_R5000.OutputFormat")
        Me.D_R5000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R5000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R5000.Text = "TextBox1"
        Me.D_R5000.Top = 0.6208662!
        Me.D_R5000.Width = 1.291732!
        '
        'D_R1000
        '
        Me.D_R1000.DataField = "D_R1000"
        Me.D_R1000.Height = 0.1480321!
        Me.D_R1000.Left = 0.7933071!
        Me.D_R1000.Name = "D_R1000"
        Me.D_R1000.OutputFormat = resources.GetString("D_R1000.OutputFormat")
        Me.D_R1000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R1000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R1000.Text = "TextBox1"
        Me.D_R1000.Top = 0.7688977!
        Me.D_R1000.Width = 1.291732!
        '
        'D_R500
        '
        Me.D_R500.DataField = "D_R500"
        Me.D_R500.Height = 0.1492136!
        Me.D_R500.Left = 0.7933071!
        Me.D_R500.Name = "D_R500"
        Me.D_R500.OutputFormat = resources.GetString("D_R500.OutputFormat")
        Me.D_R500.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R500.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R500.Text = "TextBox1"
        Me.D_R500.Top = 0.9078741!
        Me.D_R500.Width = 1.291732!
        '
        'D_R100
        '
        Me.D_R100.DataField = "D_R100"
        Me.D_R100.Height = 0.1480321!
        Me.D_R100.Left = 0.7933071!
        Me.D_R100.Name = "D_R100"
        Me.D_R100.OutputFormat = resources.GetString("D_R100.OutputFormat")
        Me.D_R100.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R100.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R100.Text = "TextBox1"
        Me.D_R100.Top = 1.057086!
        Me.D_R100.Width = 1.291732!
        '
        'D_R50
        '
        Me.D_R50.DataField = "D_R50"
        Me.D_R50.Height = 0.1480321!
        Me.D_R50.Left = 0.7933071!
        Me.D_R50.Name = "D_R50"
        Me.D_R50.OutputFormat = resources.GetString("D_R50.OutputFormat")
        Me.D_R50.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R50.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R50.Text = "TextBox1"
        Me.D_R50.Top = 1.206299!
        Me.D_R50.Width = 1.291732!
        '
        'D_R10
        '
        Me.D_R10.DataField = "D_R10"
        Me.D_R10.Height = 0.1480327!
        Me.D_R10.Left = 0.7933071!
        Me.D_R10.Name = "D_R10"
        Me.D_R10.OutputFormat = resources.GetString("D_R10.OutputFormat")
        Me.D_R10.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R10.Text = "TextBox1"
        Me.D_R10.Top = 1.355512!
        Me.D_R10.Width = 1.291732!
        '
        'D_R5
        '
        Me.D_R5.DataField = "D_R5"
        Me.D_R5.Height = 0.1480315!
        Me.D_R5.Left = 0.7933071!
        Me.D_R5.Name = "D_R5"
        Me.D_R5.OutputFormat = resources.GetString("D_R5.OutputFormat")
        Me.D_R5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R5.Text = "TextBox1"
        Me.D_R5.Top = 1.504724!
        Me.D_R5.Width = 1.291732!
        '
        'D_R1
        '
        Me.D_R1.DataField = "D_R1"
        Me.D_R1.Height = 0.1480321!
        Me.D_R1.Left = 0.7933071!
        Me.D_R1.Name = "D_R1"
        Me.D_R1.OutputFormat = resources.GetString("D_R1.OutputFormat")
        Me.D_R1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_R1.Text = "TextBox1"
        Me.D_R1.Top = 1.653937!
        Me.D_R1.Width = 1.291732!
        '
        'D_K10000
        '
        Me.D_K10000.DataField = "D_K10000"
        Me.D_K10000.Height = 0.1389764!
        Me.D_K10000.Left = 2.08504!
        Me.D_K10000.Name = "D_K10000"
        Me.D_K10000.OutputFormat = resources.GetString("D_K10000.OutputFormat")
        Me.D_K10000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K10000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K10000.Text = "TextBox1"
        Me.D_K10000.Top = 0.4728346!
        Me.D_K10000.Width = 1.291732!
        '
        'D_K5000
        '
        Me.D_K5000.DataField = "D_K5000"
        Me.D_K5000.Height = 0.1480315!
        Me.D_K5000.Left = 2.085039!
        Me.D_K5000.Name = "D_K5000"
        Me.D_K5000.OutputFormat = resources.GetString("D_K5000.OutputFormat")
        Me.D_K5000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K5000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K5000.Text = "TextBox1"
        Me.D_K5000.Top = 0.6208662!
        Me.D_K5000.Width = 1.291732!
        '
        'D_K1000
        '
        Me.D_K1000.DataField = "D_K1000"
        Me.D_K1000.Height = 0.1480315!
        Me.D_K1000.Left = 2.085039!
        Me.D_K1000.Name = "D_K1000"
        Me.D_K1000.OutputFormat = resources.GetString("D_K1000.OutputFormat")
        Me.D_K1000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K1000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K1000.Text = "TextBox1"
        Me.D_K1000.Top = 0.7688977!
        Me.D_K1000.Width = 1.291732!
        '
        'D_K500
        '
        Me.D_K500.DataField = "D_K500"
        Me.D_K500.Height = 0.1492126!
        Me.D_K500.Left = 2.085039!
        Me.D_K500.Name = "D_K500"
        Me.D_K500.OutputFormat = resources.GetString("D_K500.OutputFormat")
        Me.D_K500.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K500.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K500.Text = "TextBox1"
        Me.D_K500.Top = 0.9078741!
        Me.D_K500.Width = 1.291732!
        '
        'D_K100
        '
        Me.D_K100.DataField = "D_K100"
        Me.D_K100.Height = 0.1480315!
        Me.D_K100.Left = 2.085039!
        Me.D_K100.Name = "D_K100"
        Me.D_K100.OutputFormat = resources.GetString("D_K100.OutputFormat")
        Me.D_K100.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K100.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K100.Text = "TextBox1"
        Me.D_K100.Top = 1.057086!
        Me.D_K100.Width = 1.291732!
        '
        'D_K50
        '
        Me.D_K50.DataField = "D_K50"
        Me.D_K50.Height = 0.1480315!
        Me.D_K50.Left = 2.085039!
        Me.D_K50.Name = "D_K50"
        Me.D_K50.OutputFormat = resources.GetString("D_K50.OutputFormat")
        Me.D_K50.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K50.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K50.Text = "TextBox1"
        Me.D_K50.Top = 1.206299!
        Me.D_K50.Width = 1.291732!
        '
        'D_K10
        '
        Me.D_K10.DataField = "D_K10"
        Me.D_K10.Height = 0.1480315!
        Me.D_K10.Left = 2.085039!
        Me.D_K10.Name = "D_K10"
        Me.D_K10.OutputFormat = resources.GetString("D_K10.OutputFormat")
        Me.D_K10.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K10.Text = "TextBox1"
        Me.D_K10.Top = 1.355512!
        Me.D_K10.Width = 1.291732!
        '
        'D_K5
        '
        Me.D_K5.DataField = "D_K5"
        Me.D_K5.Height = 0.1480315!
        Me.D_K5.Left = 2.085039!
        Me.D_K5.Name = "D_K5"
        Me.D_K5.OutputFormat = resources.GetString("D_K5.OutputFormat")
        Me.D_K5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K5.Text = "TextBox1"
        Me.D_K5.Top = 1.504724!
        Me.D_K5.Width = 1.291732!
        '
        'D_K1
        '
        Me.D_K1.DataField = "D_K1"
        Me.D_K1.Height = 0.1480315!
        Me.D_K1.Left = 2.085039!
        Me.D_K1.Name = "D_K1"
        Me.D_K1.OutputFormat = resources.GetString("D_K1.OutputFormat")
        Me.D_K1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.D_K1.Text = "TextBox1"
        Me.D_K1.Top = 1.653937!
        Me.D_K1.Width = 1.291732!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label6, Me.Label7, Me.Label8, Me.Label5, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.D_R10000, Me.D_R5000, Me.D_R1000, Me.D_R500, Me.D_R100, Me.D_R50, Me.D_R10, Me.D_R5, Me.D_R1, Me.D_K10000, Me.D_K5000, Me.D_K1000, Me.D_K500, Me.D_K100, Me.D_K50, Me.D_K10, Me.D_K5, Me.D_K1, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28, Me.Label29, Me.K_R10000, Me.K_R5000, Me.K_R1000, Me.K_R500, Me.K_R100, Me.K_R50, Me.K_R10, Me.K_R5, Me.K_R1, Me.K_K10000, Me.K_K5000, Me.K_K1000, Me.K_K500, Me.K_K100, Me.K_K50, Me.K_K10, Me.K_K5, Me.K_K1, Me.Label30, Me.Label48, Me.D_R_TOTAL, Me.D_K_TOTAL, Me.Label49, Me.K_R_TOTAL, Me.K_K_TOTAL, Me.Label50, Me.D_TOTAL, Me.Label51, Me.K_TOTAL, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11, Me.Line12, Me.Line13, Me.Line14, Me.Line15, Me.Line16, Me.Line17, Me.Line18, Me.Line19, Me.Line20, Me.Line21})
        Me.GroupHeader1.Height = 2.17289!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label17
        '
        Me.Label17.ClassName = "B_LABEL"
        Me.Label17.Height = 0.1795275!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.379134!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "background-color: Silver; font-size: 8.25pt; ddo-char-set: 128"
        Me.Label17.Text = "精算状況"
        Me.Label17.Top = 0.1452756!
        Me.Label17.Width = 3.362205!
        '
        'Label18
        '
        Me.Label18.ClassName = "B_LABEL"
        Me.Label18.Height = 0.1480315!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.376772!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set:" &
    " 128"
        Me.Label18.Text = "紙幣・硬貨"
        Me.Label18.Top = 0.3248033!
        Me.Label18.Width = 0.7874016!
        '
        'Label19
        '
        Me.Label19.ClassName = "B_LABEL"
        Me.Label19.Height = 0.1480315!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 4.164174!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set:" &
    " 128"
        Me.Label19.Text = "レジ入金"
        Me.Label19.Top = 0.3248032!
        Me.Label19.Width = 1.291732!
        '
        'Label20
        '
        Me.Label20.ClassName = "B_LABEL"
        Me.Label20.Height = 0.1480321!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.449606!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "background-color: Silver; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; ddo-char-set:" &
    " 128"
        Me.Label20.Text = "金庫残高"
        Me.Label20.Top = 0.3236222!
        Me.Label20.Width = 1.291732!
        '
        'Label21
        '
        Me.Label21.ClassName = "B_LABEL"
        Me.Label21.Height = 0.1480315!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 3.379134!
        Me.Label21.Name = "Label21"
        Me.Label21.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label21.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label21.Text = "10,000"
        Me.Label21.Top = 0.4728348!
        Me.Label21.Width = 0.7874016!
        '
        'Label22
        '
        Me.Label22.ClassName = "B_LABEL"
        Me.Label22.Height = 0.1480315!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 3.379134!
        Me.Label22.Name = "Label22"
        Me.Label22.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label22.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label22.Text = "5,000"
        Me.Label22.Top = 0.6208663!
        Me.Label22.Width = 0.7874016!
        '
        'Label23
        '
        Me.Label23.ClassName = "B_LABEL"
        Me.Label23.Height = 0.1480315!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 3.379134!
        Me.Label23.Name = "Label23"
        Me.Label23.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label23.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label23.Text = "1,000"
        Me.Label23.Top = 0.7688978!
        Me.Label23.Width = 0.7874016!
        '
        'Label24
        '
        Me.Label24.ClassName = "B_LABEL"
        Me.Label24.Height = 0.1480315!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 3.379134!
        Me.Label24.Name = "Label24"
        Me.Label24.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label24.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label24.Text = "500"
        Me.Label24.Top = 0.9078742!
        Me.Label24.Width = 0.7874016!
        '
        'Label25
        '
        Me.Label25.ClassName = "B_LABEL"
        Me.Label25.Height = 0.1480315!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 3.379134!
        Me.Label25.Name = "Label25"
        Me.Label25.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label25.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label25.Text = "100"
        Me.Label25.Top = 1.057087!
        Me.Label25.Width = 0.7874016!
        '
        'Label26
        '
        Me.Label26.ClassName = "B_LABEL"
        Me.Label26.Height = 0.1480315!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 3.379134!
        Me.Label26.Name = "Label26"
        Me.Label26.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label26.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label26.Text = "50"
        Me.Label26.Top = 1.206299!
        Me.Label26.Width = 0.7874016!
        '
        'Label27
        '
        Me.Label27.ClassName = "B_LABEL"
        Me.Label27.Height = 0.1480316!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 3.379134!
        Me.Label27.Name = "Label27"
        Me.Label27.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label27.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label27.Text = "10"
        Me.Label27.Top = 1.355512!
        Me.Label27.Width = 0.7874015!
        '
        'Label28
        '
        Me.Label28.ClassName = "B_LABEL"
        Me.Label28.Height = 0.1480315!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 3.379134!
        Me.Label28.Name = "Label28"
        Me.Label28.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label28.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label28.Text = "5"
        Me.Label28.Top = 1.504725!
        Me.Label28.Width = 0.7874005!
        '
        'Label29
        '
        Me.Label29.ClassName = "B_LABEL"
        Me.Label29.Height = 0.1480321!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 3.379134!
        Me.Label29.Name = "Label29"
        Me.Label29.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label29.Style = "background-color: Silver; font-family: MS UI Gothic; font-size: 8.25pt; text-alig" &
    "n: right; ddo-char-set: 128"
        Me.Label29.Text = "1"
        Me.Label29.Top = 1.653937!
        Me.Label29.Width = 0.7874015!
        '
        'K_R10000
        '
        Me.K_R10000.DataField = "K_R10000"
        Me.K_R10000.Height = 0.1389762!
        Me.K_R10000.Left = 4.164175!
        Me.K_R10000.Name = "K_R10000"
        Me.K_R10000.OutputFormat = resources.GetString("K_R10000.OutputFormat")
        Me.K_R10000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R10000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R10000.Text = "TextBox1"
        Me.K_R10000.Top = 0.4728348!
        Me.K_R10000.Width = 1.283463!
        '
        'K_R5000
        '
        Me.K_R5000.DataField = "K_R5000"
        Me.K_R5000.Height = 0.1480321!
        Me.K_R5000.Left = 4.164174!
        Me.K_R5000.Name = "K_R5000"
        Me.K_R5000.OutputFormat = resources.GetString("K_R5000.OutputFormat")
        Me.K_R5000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R5000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R5000.Text = "TextBox1"
        Me.K_R5000.Top = 0.6208662!
        Me.K_R5000.Width = 1.283464!
        '
        'K_R1000
        '
        Me.K_R1000.DataField = "K_R1000"
        Me.K_R1000.Height = 0.1480321!
        Me.K_R1000.Left = 4.164174!
        Me.K_R1000.Name = "K_R1000"
        Me.K_R1000.OutputFormat = resources.GetString("K_R1000.OutputFormat")
        Me.K_R1000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R1000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R1000.Text = "TextBox1"
        Me.K_R1000.Top = 0.7688977!
        Me.K_R1000.Width = 1.283464!
        '
        'K_R500
        '
        Me.K_R500.DataField = "K_R500"
        Me.K_R500.Height = 0.1480321!
        Me.K_R500.Left = 4.164174!
        Me.K_R500.Name = "K_R500"
        Me.K_R500.OutputFormat = resources.GetString("K_R500.OutputFormat")
        Me.K_R500.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R500.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R500.Text = "TextBox1"
        Me.K_R500.Top = 0.9078741!
        Me.K_R500.Width = 1.283464!
        '
        'K_R100
        '
        Me.K_R100.DataField = "K_R100"
        Me.K_R100.Height = 0.1480321!
        Me.K_R100.Left = 4.164174!
        Me.K_R100.Name = "K_R100"
        Me.K_R100.OutputFormat = resources.GetString("K_R100.OutputFormat")
        Me.K_R100.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R100.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R100.Text = "TextBox1"
        Me.K_R100.Top = 1.057087!
        Me.K_R100.Width = 1.283464!
        '
        'K_R50
        '
        Me.K_R50.DataField = "K_R50"
        Me.K_R50.Height = 0.1480321!
        Me.K_R50.Left = 4.164174!
        Me.K_R50.Name = "K_R50"
        Me.K_R50.OutputFormat = resources.GetString("K_R50.OutputFormat")
        Me.K_R50.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R50.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R50.Text = "TextBox1"
        Me.K_R50.Top = 1.206299!
        Me.K_R50.Width = 1.283464!
        '
        'K_R10
        '
        Me.K_R10.DataField = "K_R10"
        Me.K_R10.Height = 0.1480316!
        Me.K_R10.Left = 4.164174!
        Me.K_R10.Name = "K_R10"
        Me.K_R10.OutputFormat = resources.GetString("K_R10.OutputFormat")
        Me.K_R10.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R10.Text = "TextBox1"
        Me.K_R10.Top = 1.355512!
        Me.K_R10.Width = 1.283464!
        '
        'K_R5
        '
        Me.K_R5.DataField = "K_R5"
        Me.K_R5.Height = 0.1480315!
        Me.K_R5.Left = 4.164174!
        Me.K_R5.Name = "K_R5"
        Me.K_R5.OutputFormat = resources.GetString("K_R5.OutputFormat")
        Me.K_R5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R5.Text = "TextBox1"
        Me.K_R5.Top = 1.504724!
        Me.K_R5.Width = 1.283464!
        '
        'K_R1
        '
        Me.K_R1.DataField = "K_R1"
        Me.K_R1.Height = 0.1480321!
        Me.K_R1.Left = 4.164174!
        Me.K_R1.Name = "K_R1"
        Me.K_R1.OutputFormat = resources.GetString("K_R1.OutputFormat")
        Me.K_R1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_R1.Text = "TextBox1"
        Me.K_R1.Top = 1.653937!
        Me.K_R1.Width = 1.283464!
        '
        'K_K10000
        '
        Me.K_K10000.DataField = "K_K10000"
        Me.K_K10000.Height = 0.1389764!
        Me.K_K10000.Left = 5.449607!
        Me.K_K10000.Name = "K_K10000"
        Me.K_K10000.OutputFormat = resources.GetString("K_K10000.OutputFormat")
        Me.K_K10000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K10000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K10000.Text = "TextBox1"
        Me.K_K10000.Top = 0.4728347!
        Me.K_K10000.Width = 1.291732!
        '
        'K_K5000
        '
        Me.K_K5000.DataField = "K_K5000"
        Me.K_K5000.Height = 0.1480321!
        Me.K_K5000.Left = 5.449607!
        Me.K_K5000.Name = "K_K5000"
        Me.K_K5000.OutputFormat = resources.GetString("K_K5000.OutputFormat")
        Me.K_K5000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K5000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K5000.Text = "TextBox1"
        Me.K_K5000.Top = 0.6208662!
        Me.K_K5000.Width = 1.291732!
        '
        'K_K1000
        '
        Me.K_K1000.DataField = "K_K1000"
        Me.K_K1000.Height = 0.1480321!
        Me.K_K1000.Left = 5.449607!
        Me.K_K1000.Name = "K_K1000"
        Me.K_K1000.OutputFormat = resources.GetString("K_K1000.OutputFormat")
        Me.K_K1000.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K1000.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K1000.Text = "TextBox1"
        Me.K_K1000.Top = 0.7598425!
        Me.K_K1000.Width = 1.291732!
        '
        'K_K500
        '
        Me.K_K500.DataField = "K_K500"
        Me.K_K500.Height = 0.1480321!
        Me.K_K500.Left = 5.449607!
        Me.K_K500.Name = "K_K500"
        Me.K_K500.OutputFormat = resources.GetString("K_K500.OutputFormat")
        Me.K_K500.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K500.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K500.Text = "TextBox1"
        Me.K_K500.Top = 0.9090551!
        Me.K_K500.Width = 1.291732!
        '
        'K_K100
        '
        Me.K_K100.DataField = "K_K100"
        Me.K_K100.Height = 0.1480321!
        Me.K_K100.Left = 5.449607!
        Me.K_K100.Name = "K_K100"
        Me.K_K100.OutputFormat = resources.GetString("K_K100.OutputFormat")
        Me.K_K100.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K100.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K100.Text = "TextBox1"
        Me.K_K100.Top = 1.058268!
        Me.K_K100.Width = 1.291732!
        '
        'K_K50
        '
        Me.K_K50.DataField = "K_K50"
        Me.K_K50.Height = 0.1480321!
        Me.K_K50.Left = 5.449607!
        Me.K_K50.Name = "K_K50"
        Me.K_K50.OutputFormat = resources.GetString("K_K50.OutputFormat")
        Me.K_K50.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K50.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K50.Text = "TextBox1"
        Me.K_K50.Top = 1.20748!
        Me.K_K50.Width = 1.291732!
        '
        'K_K10
        '
        Me.K_K10.DataField = "K_K10"
        Me.K_K10.Height = 0.1480316!
        Me.K_K10.Left = 5.449607!
        Me.K_K10.Name = "K_K10"
        Me.K_K10.OutputFormat = resources.GetString("K_K10.OutputFormat")
        Me.K_K10.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K10.Text = "TextBox1"
        Me.K_K10.Top = 1.356693!
        Me.K_K10.Width = 1.291732!
        '
        'K_K5
        '
        Me.K_K5.DataField = "K_K5"
        Me.K_K5.Height = 0.1480315!
        Me.K_K5.Left = 5.449606!
        Me.K_K5.Name = "K_K5"
        Me.K_K5.OutputFormat = resources.GetString("K_K5.OutputFormat")
        Me.K_K5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K5.Text = "TextBox1"
        Me.K_K5.Top = 1.505906!
        Me.K_K5.Width = 1.291732!
        '
        'K_K1
        '
        Me.K_K1.DataField = "K_K1"
        Me.K_K1.Height = 0.1480321!
        Me.K_K1.Left = 5.449607!
        Me.K_K1.Name = "K_K1"
        Me.K_K1.OutputFormat = resources.GetString("K_K1.OutputFormat")
        Me.K_K1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: right"
        Me.K_K1.Text = "TextBox1"
        Me.K_K1.Top = 1.653937!
        Me.K_K1.Width = 1.291732!
        '
        'Label30
        '
        Me.Label30.Height = 0.1440945!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 0!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; text-align: left"
        Me.Label30.Text = "【現金状況】"
        Me.Label30.Top = 0!
        Me.Label30.Width = 0.75!
        '
        'Label48
        '
        Me.Label48.ClassName = "B_LABEL"
        Me.Label48.Height = 0.1480321!
        Me.Label48.HyperLink = Nothing
        Me.Label48.Left = 0!
        Me.Label48.Name = "Label48"
        Me.Label48.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label48.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "center; ddo-char-set: 128"
        Me.Label48.Text = "小　計"
        Me.Label48.Top = 1.801969!
        Me.Label48.Width = 0.7933075!
        '
        'D_R_TOTAL
        '
        Me.D_R_TOTAL.DataField = "D_R_TOTAL"
        Me.D_R_TOTAL.Height = 0.1480321!
        Me.D_R_TOTAL.Left = 0.7933071!
        Me.D_R_TOTAL.Name = "D_R_TOTAL"
        Me.D_R_TOTAL.OutputFormat = resources.GetString("D_R_TOTAL.OutputFormat")
        Me.D_R_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_R_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.D_R_TOTAL.Text = "TextBox1"
        Me.D_R_TOTAL.Top = 1.801969!
        Me.D_R_TOTAL.Width = 1.291732!
        '
        'D_K_TOTAL
        '
        Me.D_K_TOTAL.DataField = "D_K_TOTAL"
        Me.D_K_TOTAL.Height = 0.1480315!
        Me.D_K_TOTAL.Left = 2.085039!
        Me.D_K_TOTAL.Name = "D_K_TOTAL"
        Me.D_K_TOTAL.OutputFormat = resources.GetString("D_K_TOTAL.OutputFormat")
        Me.D_K_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_K_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.D_K_TOTAL.Text = "TextBox1"
        Me.D_K_TOTAL.Top = 1.801969!
        Me.D_K_TOTAL.Width = 1.291732!
        '
        'Label49
        '
        Me.Label49.ClassName = "B_LABEL"
        Me.Label49.Height = 0.1480321!
        Me.Label49.HyperLink = Nothing
        Me.Label49.Left = 3.379134!
        Me.Label49.Name = "Label49"
        Me.Label49.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label49.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "center; ddo-char-set: 128"
        Me.Label49.Text = "小　計"
        Me.Label49.Top = 1.801969!
        Me.Label49.Width = 0.7874019!
        '
        'K_R_TOTAL
        '
        Me.K_R_TOTAL.DataField = "K_R_TOTAL"
        Me.K_R_TOTAL.Height = 0.1480321!
        Me.K_R_TOTAL.Left = 4.164174!
        Me.K_R_TOTAL.Name = "K_R_TOTAL"
        Me.K_R_TOTAL.OutputFormat = resources.GetString("K_R_TOTAL.OutputFormat")
        Me.K_R_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_R_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.K_R_TOTAL.Text = "TextBox1"
        Me.K_R_TOTAL.Top = 1.801969!
        Me.K_R_TOTAL.Width = 1.283464!
        '
        'K_K_TOTAL
        '
        Me.K_K_TOTAL.DataField = "K_K_TOTAL"
        Me.K_K_TOTAL.Height = 0.1480321!
        Me.K_K_TOTAL.Left = 5.449607!
        Me.K_K_TOTAL.Name = "K_K_TOTAL"
        Me.K_K_TOTAL.OutputFormat = resources.GetString("K_K_TOTAL.OutputFormat")
        Me.K_K_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_K_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.K_K_TOTAL.Text = "TextBox1"
        Me.K_K_TOTAL.Top = 1.794095!
        Me.K_K_TOTAL.Width = 1.291732!
        '
        'Label50
        '
        Me.Label50.ClassName = "B_LABEL"
        Me.Label50.Height = 0.1795275!
        Me.Label50.HyperLink = Nothing
        Me.Label50.Left = 0!
        Me.Label50.Name = "Label50"
        Me.Label50.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label50.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label50.Text = "合　計"
        Me.Label50.Top = 1.942126!
        Me.Label50.Width = 0.7933075!
        '
        'D_TOTAL
        '
        Me.D_TOTAL.DataField = "D_TOTAL"
        Me.D_TOTAL.Height = 0.1795276!
        Me.D_TOTAL.Left = 0.7933071!
        Me.D_TOTAL.Name = "D_TOTAL"
        Me.D_TOTAL.OutputFormat = resources.GetString("D_TOTAL.OutputFormat")
        Me.D_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.D_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.D_TOTAL.Text = "TextBox1"
        Me.D_TOTAL.Top = 1.942126!
        Me.D_TOTAL.Width = 2.583465!
        '
        'Label51
        '
        Me.Label51.ClassName = "B_LABEL"
        Me.Label51.Height = 0.1795275!
        Me.Label51.HyperLink = Nothing
        Me.Label51.Left = 3.379134!
        Me.Label51.Name = "Label51"
        Me.Label51.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label51.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label51.Text = "合　計"
        Me.Label51.Top = 1.942126!
        Me.Label51.Width = 0.7874019!
        '
        'K_TOTAL
        '
        Me.K_TOTAL.DataField = "K_TOTAL"
        Me.K_TOTAL.Height = 0.1795275!
        Me.K_TOTAL.Left = 4.164174!
        Me.K_TOTAL.Name = "K_TOTAL"
        Me.K_TOTAL.OutputFormat = resources.GetString("K_TOTAL.OutputFormat")
        Me.K_TOTAL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.K_TOTAL.Style = "background-color: #E0E0E0; font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; text-align: " &
    "right"
        Me.K_TOTAL.Text = "TextBox1"
        Me.K_TOTAL.Top = 1.942126!
        Me.K_TOTAL.Width = 2.577165!
        '
        'Line1
        '
        Me.Line1.Height = 0.001181096!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1440945!
        Me.Line1.Width = 6.74134!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 6.74134!
        Me.Line1.Y1 = 0.1452756!
        Me.Line1.Y2 = 0.1440945!
        '
        'Line2
        '
        Me.Line2.Height = 0.001181006!
        Me.Line2.Left = 0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.3236221!
        Me.Line2.Width = 6.741339!
        Me.Line2.X1 = 0!
        Me.Line2.X2 = 6.741339!
        Me.Line2.Y1 = 0.3248031!
        Me.Line2.Y2 = 0.3236221!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.00000005960464!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.4728346!
        Me.Line3.Width = 6.741338!
        Me.Line3.X1 = 0.00000005960464!
        Me.Line3.X2 = 6.741338!
        Me.Line3.Y1 = 0.4728346!
        Me.Line3.Y2 = 0.4728346!
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 0.00000005960464!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.6208662!
        Me.Line4.Width = 6.741338!
        Me.Line4.X1 = 0.00000005960464!
        Me.Line4.X2 = 6.741338!
        Me.Line4.Y1 = 0.6208662!
        Me.Line4.Y2 = 0.6208662!
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 0.00000005960464!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.7688977!
        Me.Line5.Width = 6.741339!
        Me.Line5.X1 = 0.00000005960464!
        Me.Line5.X2 = 6.741339!
        Me.Line5.Y1 = 0.7688977!
        Me.Line5.Y2 = 0.7688977!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 0.00000005960464!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.907874!
        Me.Line6.Width = 6.741339!
        Me.Line6.X1 = 0.00000005960464!
        Me.Line6.X2 = 6.741339!
        Me.Line6.Y1 = 0.907874!
        Me.Line6.Y2 = 0.907874!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 0.00000005960464!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.057087!
        Me.Line7.Width = 6.741339!
        Me.Line7.X1 = 0.00000005960464!
        Me.Line7.X2 = 6.741339!
        Me.Line7.Y1 = 1.057087!
        Me.Line7.Y2 = 1.057087!
        '
        'Line8
        '
        Me.Line8.Height = 0!
        Me.Line8.Left = 0.00000005960464!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.206299!
        Me.Line8.Width = 6.741339!
        Me.Line8.X1 = 0.00000005960464!
        Me.Line8.X2 = 6.741339!
        Me.Line8.Y1 = 1.206299!
        Me.Line8.Y2 = 1.206299!
        '
        'Line9
        '
        Me.Line9.Height = 0!
        Me.Line9.Left = 0.00000005960464!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.355512!
        Me.Line9.Width = 6.741339!
        Me.Line9.X1 = 0.00000005960464!
        Me.Line9.X2 = 6.741339!
        Me.Line9.Y1 = 1.355512!
        Me.Line9.Y2 = 1.355512!
        '
        'Line10
        '
        Me.Line10.Height = 0!
        Me.Line10.Left = 0.00000005960464!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 1.504724!
        Me.Line10.Width = 6.741339!
        Me.Line10.X1 = 0.00000005960464!
        Me.Line10.X2 = 6.741339!
        Me.Line10.Y1 = 1.504724!
        Me.Line10.Y2 = 1.504724!
        '
        'Line11
        '
        Me.Line11.Height = 0!
        Me.Line11.Left = 0.00000005960464!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 1.653937!
        Me.Line11.Width = 6.741339!
        Me.Line11.X1 = 0.00000005960464!
        Me.Line11.X2 = 6.741339!
        Me.Line11.Y1 = 1.653937!
        Me.Line11.Y2 = 1.653937!
        '
        'Line12
        '
        Me.Line12.Height = 0!
        Me.Line12.Left = 0!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.801969!
        Me.Line12.Width = 6.741339!
        Me.Line12.X1 = 0!
        Me.Line12.X2 = 6.741339!
        Me.Line12.Y1 = 1.801969!
        Me.Line12.Y2 = 1.801969!
        '
        'Line13
        '
        Me.Line13.Height = 0!
        Me.Line13.Left = 0.00000005960464!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 1.942126!
        Me.Line13.Width = 6.741339!
        Me.Line13.X1 = 0.00000005960464!
        Me.Line13.X2 = 6.741339!
        Me.Line13.Y1 = 1.942126!
        Me.Line13.Y2 = 1.942126!
        '
        'Line14
        '
        Me.Line14.Height = 0!
        Me.Line14.Left = 0.00000005960464!
        Me.Line14.LineWeight = 2.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 2.11811!
        Me.Line14.Width = 6.741339!
        Me.Line14.X1 = 0.00000005960464!
        Me.Line14.X2 = 6.741339!
        Me.Line14.Y1 = 2.11811!
        Me.Line14.Y2 = 2.11811!
        '
        'Line15
        '
        Me.Line15.Height = 1.972834!
        Me.Line15.Left = 0!
        Me.Line15.LineWeight = 2.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.1452756!
        Me.Line15.Width = 0!
        Me.Line15.X1 = 0!
        Me.Line15.X2 = 0!
        Me.Line15.Y1 = 0.1452756!
        Me.Line15.Y2 = 2.11811!
        '
        'Line16
        '
        Me.Line16.Height = 1.794095!
        Me.Line16.Left = 0.7948819!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.3248032!
        Me.Line16.Width = 0!
        Me.Line16.X1 = 0.7948819!
        Me.Line16.X2 = 0.7948819!
        Me.Line16.Y1 = 0.3248032!
        Me.Line16.Y2 = 2.118898!
        '
        'Line17
        '
        Me.Line17.Height = 1.617323!
        Me.Line17.Left = 2.085039!
        Me.Line17.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.3248032!
        Me.Line17.Width = 0!
        Me.Line17.X1 = 2.085039!
        Me.Line17.X2 = 2.085039!
        Me.Line17.Y1 = 0.3248032!
        Me.Line17.Y2 = 1.942126!
        '
        'Line18
        '
        Me.Line18.Height = 1.972834!
        Me.Line18.Left = 3.376772!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.1452756!
        Me.Line18.Width = 0!
        Me.Line18.X1 = 3.376772!
        Me.Line18.X2 = 3.376772!
        Me.Line18.Y1 = 0.1452756!
        Me.Line18.Y2 = 2.11811!
        '
        'Line19
        '
        Me.Line19.Height = 1.793307!
        Me.Line19.Left = 4.164173!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.3248031!
        Me.Line19.Width = 0!
        Me.Line19.X1 = 4.164173!
        Me.Line19.X2 = 4.164173!
        Me.Line19.Y1 = 0.3248031!
        Me.Line19.Y2 = 2.11811!
        '
        'Line20
        '
        Me.Line20.Height = 1.617323!
        Me.Line20.Left = 5.449607!
        Me.Line20.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 0.3248032!
        Me.Line20.Width = 0!
        Me.Line20.X1 = 5.449607!
        Me.Line20.X2 = 5.449607!
        Me.Line20.Y1 = 0.3248032!
        Me.Line20.Y2 = 1.942126!
        '
        'Line21
        '
        Me.Line21.Height = 1.972834!
        Me.Line21.Left = 6.741339!
        Me.Line21.LineWeight = 2.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.1452756!
        Me.Line21.Width = 0!
        Me.Line21.X1 = 6.741339!
        Me.Line21.X2 = 6.741339!
        Me.Line21.Y1 = 0.1452756!
        Me.Line21.Y2 = 2.11811!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.INOUT_DETAIL1, Me.INOUT_DETAIL2, Me.INOUT_DETAIL3, Me.INOUT_DETAIL4, Me.PageBreak1, Me.INOUT_DETAIL5, Me.INOUT_DETAIL6, Me.PageBreak2, Me.INOUT_DETAIL7})
        Me.GroupFooter1.Height = 4.260417!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'INOUT_DETAIL1
        '
        Me.INOUT_DETAIL1.CloseBorder = False
        Me.INOUT_DETAIL1.Height = 0.531!
        Me.INOUT_DETAIL1.Left = 0!
        Me.INOUT_DETAIL1.Name = "INOUT_DETAIL1"
        Me.INOUT_DETAIL1.Report = Nothing
        Me.INOUT_DETAIL1.Top = 0!
        Me.INOUT_DETAIL1.Width = 6.874016!
        '
        'INOUT_DETAIL2
        '
        Me.INOUT_DETAIL2.CloseBorder = False
        Me.INOUT_DETAIL2.Height = 0.5311024!
        Me.INOUT_DETAIL2.Left = 0!
        Me.INOUT_DETAIL2.Name = "INOUT_DETAIL2"
        Me.INOUT_DETAIL2.Report = Nothing
        Me.INOUT_DETAIL2.Top = 0.6043308!
        Me.INOUT_DETAIL2.Width = 7.237796!
        '
        'INOUT_DETAIL3
        '
        Me.INOUT_DETAIL3.CloseBorder = False
        Me.INOUT_DETAIL3.Height = 0.531!
        Me.INOUT_DETAIL3.Left = 0!
        Me.INOUT_DETAIL3.Name = "INOUT_DETAIL3"
        Me.INOUT_DETAIL3.Report = Nothing
        Me.INOUT_DETAIL3.Top = 1.229134!
        Me.INOUT_DETAIL3.Width = 6.874016!
        '
        'INOUT_DETAIL4
        '
        Me.INOUT_DETAIL4.CloseBorder = False
        Me.INOUT_DETAIL4.Height = 0.531!
        Me.INOUT_DETAIL4.Left = 0!
        Me.INOUT_DETAIL4.Name = "INOUT_DETAIL4"
        Me.INOUT_DETAIL4.Report = Nothing
        Me.INOUT_DETAIL4.Top = 1.823622!
        Me.INOUT_DETAIL4.Width = 6.874016!
        '
        'PageBreak1
        '
        Me.PageBreak1.Enabled = False
        Me.PageBreak1.Height = 0.01!
        Me.PageBreak1.Left = 0!
        Me.PageBreak1.Name = "PageBreak1"
        Me.PageBreak1.Size = New System.Drawing.SizeF(6.5!, 0.01!)
        Me.PageBreak1.Top = 0.5732284!
        Me.PageBreak1.Width = 6.5!
        '
        'INOUT_DETAIL5
        '
        Me.INOUT_DETAIL5.CloseBorder = False
        Me.INOUT_DETAIL5.Height = 0.531!
        Me.INOUT_DETAIL5.Left = 0!
        Me.INOUT_DETAIL5.Name = "INOUT_DETAIL5"
        Me.INOUT_DETAIL5.Report = Nothing
        Me.INOUT_DETAIL5.Top = 2.478347!
        Me.INOUT_DETAIL5.Width = 7.124001!
        '
        'INOUT_DETAIL6
        '
        Me.INOUT_DETAIL6.CloseBorder = False
        Me.INOUT_DETAIL6.Height = 0.531!
        Me.INOUT_DETAIL6.Left = 0.02086614!
        Me.INOUT_DETAIL6.Name = "INOUT_DETAIL6"
        Me.INOUT_DETAIL6.Report = Nothing
        Me.INOUT_DETAIL6.Top = 3.115355!
        Me.INOUT_DETAIL6.Width = 7.124001!
        '
        'PageBreak2
        '
        Me.PageBreak2.Enabled = False
        Me.PageBreak2.Height = 0.01!
        Me.PageBreak2.Left = 0!
        Me.PageBreak2.Name = "PageBreak2"
        Me.PageBreak2.Size = New System.Drawing.SizeF(6.5!, 0.01!)
        Me.PageBreak2.Top = 3.051969!
        Me.PageBreak2.Width = 6.5!
        '
        'INOUT_DETAIL7
        '
        Me.INOUT_DETAIL7.CloseBorder = False
        Me.INOUT_DETAIL7.Height = 0.531!
        Me.INOUT_DETAIL7.Left = 0!
        Me.INOUT_DETAIL7.Name = "INOUT_DETAIL7"
        Me.INOUT_DETAIL7.Report = Nothing
        Me.INOUT_DETAIL7.Top = 3.719292!
        Me.INOUT_DETAIL7.Width = 7.124!
        '
        'S_OUTCASH
        '
        Me.S_OUTCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_OUTCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_OUTCASH.ClassName = "B_LABEL"
        Me.S_OUTCASH.DataField = "S_OUTCASH"
        Me.S_OUTCASH.Height = 0.1838583!
        Me.S_OUTCASH.Left = 3.540945!
        Me.S_OUTCASH.Name = "S_OUTCASH"
        Me.S_OUTCASH.OutputFormat = resources.GetString("S_OUTCASH.OutputFormat")
        Me.S_OUTCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_OUTCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_OUTCASH.Text = "出金金額"
        Me.S_OUTCASH.Top = 0.538189!
        Me.S_OUTCASH.Width = 0.7074804!
        '
        'S_INCASH
        '
        Me.S_INCASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCASH.ClassName = "B_LABEL"
        Me.S_INCASH.DataField = "S_INCASH"
        Me.S_INCASH.Height = 0.1795276!
        Me.S_INCASH.Left = 3.540945!
        Me.S_INCASH.Name = "S_INCASH"
        Me.S_INCASH.OutputFormat = resources.GetString("S_INCASH.OutputFormat")
        Me.S_INCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_INCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_INCASH.Text = "入金金額"
        Me.S_INCASH.Top = 0.7141733!
        Me.S_INCASH.Width = 0.7074804!
        '
        'S_CALCASH
        '
        Me.S_CALCASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CALCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CALCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CALCASH.ClassName = "G_LABEL"
        Me.S_CALCASH.DataField = "S_CALCASH"
        Me.S_CALCASH.Height = 0.1795276!
        Me.S_CALCASH.Left = 3.540945!
        Me.S_CALCASH.Name = "S_CALCASH"
        Me.S_CALCASH.OutputFormat = resources.GetString("S_CALCASH.OutputFormat")
        Me.S_CALCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_CALCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_CALCASH.Text = "現金残高"
        Me.S_CALCASH.Top = 0.8940945!
        Me.S_CALCASH.Width = 0.7074804!
        '
        'S_RETCASH
        '
        Me.S_RETCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_RETCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_RETCASH.ClassName = "G_LABEL"
        Me.S_RETCASH.DataField = "S_RETCASH"
        Me.S_RETCASH.Height = 0.1795276!
        Me.S_RETCASH.Left = 3.540945!
        Me.S_RETCASH.Name = "S_RETCASH"
        Me.S_RETCASH.OutputFormat = resources.GetString("S_RETCASH.OutputFormat")
        Me.S_RETCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_RETCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_RETCASH.Text = "回収金額"
        Me.S_RETCASH.Top = 1.067323!
        Me.S_RETCASH.Width = 0.7074804!
        '
        'S_CCASH
        '
        Me.S_CCASH.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CCASH.ClassName = "G_LABEL"
        Me.S_CCASH.DataField = "S_CCASH"
        Me.S_CCASH.Height = 0.1795276!
        Me.S_CCASH.Left = 3.540945!
        Me.S_CCASH.Name = "S_CCASH"
        Me.S_CCASH.OutputFormat = resources.GetString("S_CCASH.OutputFormat")
        Me.S_CCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_CCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_CCASH.Text = "繰越金額"
        Me.S_CCASH.Top = 1.243701!
        Me.S_CCASH.Width = 0.7074804!
        '
        'Label41
        '
        Me.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label41.ClassName = "B_LABEL"
        Me.Label41.Height = 0.1795276!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 0!
        Me.Label41.Name = "Label41"
        Me.Label41.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label41.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label41.Text = "入　　金"
        Me.Label41.Top = 0.7141733!
        Me.Label41.Width = 3.529134!
        '
        'Label42
        '
        Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.ClassName = "B_LABEL"
        Me.Label42.Height = 0.1795276!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 0!
        Me.Label42.Name = "Label42"
        Me.Label42.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label42.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label42.Text = "出　　金"
        Me.Label42.Top = 0.538!
        Me.Label42.Width = 3.529134!
        '
        'Label43
        '
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.ClassName = "B_LABEL"
        Me.Label43.Height = 0.1795276!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 0!
        Me.Label43.Name = "Label43"
        Me.Label43.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label43.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label43.Text = "回収金額"
        Me.Label43.Top = 1.067323!
        Me.Label43.Width = 3.529134!
        '
        'Label44
        '
        Me.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.ClassName = "B_LABEL"
        Me.Label44.Height = 0.1795276!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 0!
        Me.Label44.Name = "Label44"
        Me.Label44.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label44.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label44.Text = "現金残高"
        Me.Label44.Top = 0.8940945!
        Me.Label44.Width = 3.529134!
        '
        'Label45
        '
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.ClassName = "B_LABEL"
        Me.Label45.Height = 0.1795276!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 0!
        Me.Label45.Name = "Label45"
        Me.Label45.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label45.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label45.Text = "繰越金額"
        Me.Label45.Top = 1.243701!
        Me.Label45.Width = 3.529134!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'Label31
        '
        Me.Label31.Height = 0.1165355!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8.25pt; font-weight: bold; text-align: left"
        Me.Label31.Text = "【集計状況】"
        Me.Label31.Top = 0.07165354!
        Me.Label31.Width = 0.75!
        '
        'Label32
        '
        Me.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.ClassName = "B_LABEL"
        Me.Label32.Height = 0.1688975!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 0!
        Me.Label32.Name = "Label32"
        Me.Label32.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label32.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label32.Text = "区分"
        Me.Label32.Top = 0.242126!
        Me.Label32.Width = 0.5417323!
        '
        'Label33
        '
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.ClassName = "B_LABEL"
        Me.Label33.Height = 0.1688976!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 1.325197!
        Me.Label33.Name = "Label33"
        Me.Label33.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label33.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label33.Text = "部門"
        Me.Label33.Top = 0.242126!
        Me.Label33.Width = 1.011024!
        '
        'Label34
        '
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.ClassName = "B_LABEL"
        Me.Label34.Height = 0.1688976!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.5519685!
        Me.Label34.Name = "Label34"
        Me.Label34.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label34.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label34.Text = "チャネル名"
        Me.Label34.Top = 0.242126!
        Me.Label34.Width = 0.7629921!
        '
        'Label35
        '
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label35.ClassName = "B_LABEL"
        Me.Label35.Height = 0.1688976!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 3.540945!
        Me.Label35.Name = "Label35"
        Me.Label35.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label35.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label35.Text = "販売金額"
        Me.Label35.Top = 0.2425197!
        Me.Label35.Width = 0.7074804!
        '
        'Label36
        '
        Me.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label36.ClassName = "B_LABEL"
        Me.Label36.Height = 0.1688976!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 4.258662!
        Me.Label36.Name = "Label36"
        Me.Label36.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label36.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label36.Text = "数量"
        Me.Label36.Top = 0.2425197!
        Me.Label36.Width = 0.45!
        '
        'Label37
        '
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.ClassName = "B_LABEL"
        Me.Label37.Height = 0.1688976!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 4.718898!
        Me.Label37.Name = "Label37"
        Me.Label37.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label37.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label37.Text = "値引き"
        Me.Label37.Top = 0.2425197!
        Me.Label37.Width = 0.6137795!
        '
        'Label38
        '
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.ClassName = "B_LABEL"
        Me.Label38.Height = 0.1688976!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 5.342914!
        Me.Label38.Name = "Label38"
        Me.Label38.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label38.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label38.Text = "送料"
        Me.Label38.Top = 0.2425197!
        Me.Label38.Width = 0.6153543!
        '
        'Label39
        '
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.ClassName = "B_LABEL"
        Me.Label39.Height = 0.1688976!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 5.970866!
        Me.Label39.Name = "Label39"
        Me.Label39.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label39.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label39.Text = "手数料"
        Me.Label39.Top = 0.2425197!
        Me.Label39.Width = 0.6275591!
        '
        'Label46
        '
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.ClassName = "B_LABEL"
        Me.Label46.Height = 0.1688976!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 2.346457!
        Me.Label46.Name = "Label46"
        Me.Label46.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label46.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label46.Text = "支払方法"
        Me.Label46.Top = 0.2425197!
        Me.Label46.Width = 1.182284!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_RETCASH, Me.Label42, Me.Label41, Me.Label43, Me.Label44, Me.Label45, Me.Label52, Me.Label53, Me.TextBox4, Me.Label56, Me.S_YCASH, Me.S_SALECNT, Me.S_SALECASH, Me.TextBox8, Me.TextBox9, Me.S_OUTCNT, Me.S_INCNT, Me.S_OUTCASH, Me.S_INCASH, Me.S_CCASH, Me.S_CALCASH})
        Me.GroupFooter2.Height = 1.520444!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Label52
        '
        Me.Label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.ClassName = "B_LABEL"
        Me.Label52.Height = 0.1838583!
        Me.Label52.HyperLink = Nothing
        Me.Label52.Left = 0!
        Me.Label52.Name = "Label52"
        Me.Label52.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label52.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label52.Text = "現金売上"
        Me.Label52.Top = 0.1740158!
        Me.Label52.Width = 3.529134!
        '
        'Label53
        '
        Me.Label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.ClassName = "B_LABEL"
        Me.Label53.Height = 0.1787402!
        Me.Label53.HyperLink = Nothing
        Me.Label53.Left = 0!
        Me.Label53.Name = "Label53"
        Me.Label53.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label53.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label53.Text = "前日繰越金額"
        Me.Label53.Top = 0!
        Me.Label53.Width = 3.529134!
        '
        'TextBox4
        '
        Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.ClassName = "B_LABEL"
        Me.TextBox4.Height = 0.1787402!
        Me.TextBox4.Left = 4.258662!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox4.Style = "background-color: White; font-size: 8.25pt; text-align: center; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.TextBox4.Text = "－"
        Me.TextBox4.Top = 0!
        Me.TextBox4.Width = 0.45!
        '
        'Label56
        '
        Me.Label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label56.ClassName = "B_LABEL"
        Me.Label56.Height = 0.1838583!
        Me.Label56.HyperLink = Nothing
        Me.Label56.Left = 0!
        Me.Label56.Name = "Label56"
        Me.Label56.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label56.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label56.Text = "クレジット売上"
        Me.Label56.Top = 0.354!
        Me.Label56.Width = 3.529134!
        '
        'S_YCASH
        '
        Me.S_YCASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_YCASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_YCASH.ClassName = "B_LABEL"
        Me.S_YCASH.DataField = "S_YCASH"
        Me.S_YCASH.Height = 0.1787402!
        Me.S_YCASH.Left = 3.540945!
        Me.S_YCASH.Name = "S_YCASH"
        Me.S_YCASH.OutputFormat = resources.GetString("S_YCASH.OutputFormat")
        Me.S_YCASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_YCASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_YCASH.Text = "前日繰越金額"
        Me.S_YCASH.Top = 0!
        Me.S_YCASH.Width = 0.7074804!
        '
        'S_SALECNT
        '
        Me.S_SALECNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALECNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALECNT.ClassName = "B_LABEL"
        Me.S_SALECNT.DataField = "S_SALECNT"
        Me.S_SALECNT.Height = 0.1787402!
        Me.S_SALECNT.Left = 4.258662!
        Me.S_SALECNT.Name = "S_SALECNT"
        Me.S_SALECNT.OutputFormat = resources.GetString("S_SALECNT.OutputFormat")
        Me.S_SALECNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_SALECNT.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_SALECNT.Text = "数量"
        Me.S_SALECNT.Top = 0.1740157!
        Me.S_SALECNT.Width = 0.45!
        '
        'S_SALECASH
        '
        Me.S_SALECASH.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALECASH.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALECASH.ClassName = "B_LABEL"
        Me.S_SALECASH.DataField = "S_SALECASH"
        Me.S_SALECASH.Height = 0.1787402!
        Me.S_SALECASH.Left = 3.540945!
        Me.S_SALECASH.Name = "S_SALECASH"
        Me.S_SALECASH.OutputFormat = resources.GetString("S_SALECASH.OutputFormat")
        Me.S_SALECASH.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_SALECASH.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_SALECASH.Text = "現金売上"
        Me.S_SALECASH.Top = 0.1740157!
        Me.S_SALECASH.Width = 0.7074804!
        '
        'TextBox8
        '
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.ClassName = "B_LABEL"
        Me.TextBox8.DataField = "S_SALECREDIT"
        Me.TextBox8.Height = 0.1838583!
        Me.TextBox8.Left = 3.540945!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox8.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.TextBox8.Text = "ｸﾚｼﾞｯﾄ売上"
        Me.TextBox8.Top = 0.353937!
        Me.TextBox8.Width = 0.7074804!
        '
        'TextBox9
        '
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.ClassName = "B_LABEL"
        Me.TextBox9.DataField = "S_CREDITCNT"
        Me.TextBox9.Height = 0.1838583!
        Me.TextBox9.Left = 4.258662!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox9.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.TextBox9.Text = "数量"
        Me.TextBox9.Top = 0.353937!
        Me.TextBox9.Width = 0.45!
        '
        'S_OUTCNT
        '
        Me.S_OUTCNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_OUTCNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_OUTCNT.ClassName = "B_LABEL"
        Me.S_OUTCNT.DataField = "S_OUTCNT"
        Me.S_OUTCNT.Height = 0.1838583!
        Me.S_OUTCNT.Left = 4.258662!
        Me.S_OUTCNT.Name = "S_OUTCNT"
        Me.S_OUTCNT.OutputFormat = resources.GetString("S_OUTCNT.OutputFormat")
        Me.S_OUTCNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_OUTCNT.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_OUTCNT.Text = "数量"
        Me.S_OUTCNT.Top = 0.538189!
        Me.S_OUTCNT.Width = 0.45!
        '
        'S_INCNT
        '
        Me.S_INCNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_INCNT.ClassName = "B_LABEL"
        Me.S_INCNT.DataField = "S_INCNT"
        Me.S_INCNT.Height = 0.1795276!
        Me.S_INCNT.Left = 4.258662!
        Me.S_INCNT.Name = "S_INCNT"
        Me.S_INCNT.OutputFormat = resources.GetString("S_INCNT.OutputFormat")
        Me.S_INCNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_INCNT.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_INCNT.Text = "数量"
        Me.S_INCNT.Top = 0.7141733!
        Me.S_INCNT.Width = 0.45!
        '
        'sumS_SALES
        '
        Me.sumS_SALES.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_SALES.ClassName = "G_LABEL"
        Me.sumS_SALES.DataField = "S_SALES"
        Me.sumS_SALES.Height = 0.1677165!
        Me.sumS_SALES.Left = 3.540945!
        Me.sumS_SALES.Name = "sumS_SALES"
        Me.sumS_SALES.OutputFormat = resources.GetString("sumS_SALES.OutputFormat")
        Me.sumS_SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.sumS_SALES.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_SALES.SummaryGroup = "GroupHeader3"
        Me.sumS_SALES.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_SALES.Text = "販売金額"
        Me.sumS_SALES.Top = 0!
        Me.sumS_SALES.Width = 0.7074804!
        '
        'sumS_CNT
        '
        Me.sumS_CNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_CNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_CNT.ClassName = "G_LABEL"
        Me.sumS_CNT.DataField = "S_CNT"
        Me.sumS_CNT.Height = 0.1677165!
        Me.sumS_CNT.Left = 4.258662!
        Me.sumS_CNT.Name = "sumS_CNT"
        Me.sumS_CNT.OutputFormat = resources.GetString("sumS_CNT.OutputFormat")
        Me.sumS_CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.sumS_CNT.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_CNT.SummaryGroup = "GroupHeader2"
        Me.sumS_CNT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_CNT.Text = "数量"
        Me.sumS_CNT.Top = 0!
        Me.sumS_CNT.Width = 0.45!
        '
        'sumS_DISCOUNT
        '
        Me.sumS_DISCOUNT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_DISCOUNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_DISCOUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_DISCOUNT.ClassName = "G_LABEL"
        Me.sumS_DISCOUNT.DataField = "S_DISCOUNT"
        Me.sumS_DISCOUNT.Height = 0.1677165!
        Me.sumS_DISCOUNT.Left = 4.718898!
        Me.sumS_DISCOUNT.Name = "sumS_DISCOUNT"
        Me.sumS_DISCOUNT.OutputFormat = resources.GetString("sumS_DISCOUNT.OutputFormat")
        Me.sumS_DISCOUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.sumS_DISCOUNT.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_DISCOUNT.SummaryGroup = "GroupHeader3"
        Me.sumS_DISCOUNT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_DISCOUNT.Text = "値引き"
        Me.sumS_DISCOUNT.Top = 0.0003937008!
        Me.sumS_DISCOUNT.Width = 0.6137795!
        '
        'sumS_POSTAGE
        '
        Me.sumS_POSTAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_POSTAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_POSTAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_POSTAGE.ClassName = "G_LABEL"
        Me.sumS_POSTAGE.DataField = "S_POSTAGE"
        Me.sumS_POSTAGE.Height = 0.1677165!
        Me.sumS_POSTAGE.Left = 5.342914!
        Me.sumS_POSTAGE.Name = "sumS_POSTAGE"
        Me.sumS_POSTAGE.OutputFormat = resources.GetString("sumS_POSTAGE.OutputFormat")
        Me.sumS_POSTAGE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.sumS_POSTAGE.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_POSTAGE.SummaryGroup = "GroupHeader3"
        Me.sumS_POSTAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_POSTAGE.Text = "送料"
        Me.sumS_POSTAGE.Top = 0!
        Me.sumS_POSTAGE.Width = 0.6153543!
        '
        'sumS_FEE
        '
        Me.sumS_FEE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_FEE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_FEE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_FEE.ClassName = "G_LABEL"
        Me.sumS_FEE.DataField = "S_FEE"
        Me.sumS_FEE.Height = 0.1677165!
        Me.sumS_FEE.Left = 5.970866!
        Me.sumS_FEE.Name = "sumS_FEE"
        Me.sumS_FEE.OutputFormat = resources.GetString("sumS_FEE.OutputFormat")
        Me.sumS_FEE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.sumS_FEE.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_FEE.SummaryGroup = "GroupHeader3"
        Me.sumS_FEE.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_FEE.Text = "手数料"
        Me.sumS_FEE.Top = 0!
        Me.sumS_FEE.Width = 0.6275591!
        '
        'Label40
        '
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.ClassName = "B_LABEL"
        Me.Label40.Height = 0.1681102!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 0!
        Me.Label40.Name = "Label40"
        Me.Label40.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label40.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label40.Text = "売上合計"
        Me.Label40.Top = 0!
        Me.Label40.Width = 3.529134!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label31, Me.CrossSectionBox1, Me.Label32, Me.Label34, Me.Label33, Me.Label46, Me.Label35, Me.Label36, Me.Label37, Me.Label38, Me.Label39, Me.Label55, Me.CrossSectionBox2})
        Me.GroupHeader3.Height = 0.4186844!
        Me.GroupHeader3.Name = "GroupHeader3"
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
        'Label55
        '
        Me.Label55.ClassName = "B_LABEL"
        Me.Label55.Height = 0.1688976!
        Me.Label55.HyperLink = Nothing
        Me.Label55.Left = 6.608661!
        Me.Label55.Name = "Label55"
        Me.Label55.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label55.Style = "background-color: Silver; font-size: 8.25pt; text-align: center; ddo-char-set: 12" &
    "8"
        Me.Label55.Text = "売上金額"
        Me.Label55.Top = 0.2425197!
        Me.Label55.Width = 0.6275591!
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.Bottom = 0.1666667!
        Me.CrossSectionBox2.Left = 0!
        Me.CrossSectionBox2.LineWeight = 1.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Right = 7.237796!
        Me.CrossSectionBox2.Top = 0.242126!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label40, Me.sumS_SALES, Me.sumS_CNT, Me.sumS_DISCOUNT, Me.sumS_POSTAGE, Me.sumS_FEE, Me.sumS_BILL})
        Me.GroupFooter3.Height = 0.1685039!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'sumS_BILL
        '
        Me.sumS_BILL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_BILL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.sumS_BILL.ClassName = "G_LABEL"
        Me.sumS_BILL.DataField = "S_BILL"
        Me.sumS_BILL.Height = 0.1677165!
        Me.sumS_BILL.Left = 6.608661!
        Me.sumS_BILL.Name = "sumS_BILL"
        Me.sumS_BILL.OutputFormat = resources.GetString("sumS_BILL.OutputFormat")
        Me.sumS_BILL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 7, 0)
        Me.sumS_BILL.Style = "background-color: Silver; font-size: 8.25pt; text-align: right; vertical-align: b" &
    "ottom; ddo-char-set: 128"
        Me.sumS_BILL.SummaryGroup = "GroupHeader3"
        Me.sumS_BILL.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.sumS_BILL.Text = "売上金額"
        Me.sumS_BILL.Top = 0!
        Me.sumS_BILL.Width = 0.6275591!
        '
        'GroupHeader5
        '
        Me.GroupHeader5.BackColor = System.Drawing.Color.Empty
        Me.GroupHeader5.CanGrow = False
        Me.GroupHeader5.ColumnLayout = False
        Me.GroupHeader5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_CHANNEL, Me.TextBox10})
        Me.GroupHeader5.DataField = "S_CHANNEL"
        Me.GroupHeader5.Height = 0.1377953!
        Me.GroupHeader5.Name = "GroupHeader5"
        Me.GroupHeader5.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        Me.GroupHeader5.UnderlayNext = True
        '
        'TextBox10
        '
        Me.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox10.Height = 0.1374016!
        Me.TextBox10.Left = 0!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0!
        Me.TextBox10.Width = 0.5417323!
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox3, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.Label54, Me.TextBox2})
        Me.GroupFooter5.Height = 0.1574803!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'TextBox1
        '
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.ClassName = "G_LABEL"
        Me.TextBox1.DataField = "S_SALES"
        Me.TextBox1.Height = 0.1570866!
        Me.TextBox1.Left = 3.540945!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox1.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox1.SummaryGroup = "GroupHeader5"
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox1.Text = "販売金額"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 0.7074804!
        '
        'TextBox3
        '
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.ClassName = "G_LABEL"
        Me.TextBox3.DataField = "S_DISCOUNT"
        Me.TextBox3.Height = 0.1570866!
        Me.TextBox3.Left = 4.718898!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox3.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox3.SummaryGroup = "GroupHeader5"
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox3.Text = "値引き"
        Me.TextBox3.Top = 0!
        Me.TextBox3.Width = 0.6137795!
        '
        'TextBox5
        '
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.ClassName = "G_LABEL"
        Me.TextBox5.DataField = "S_POSTAGE"
        Me.TextBox5.Height = 0.1570866!
        Me.TextBox5.Left = 5.342914!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox5.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox5.SummaryGroup = "GroupHeader5"
        Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox5.Text = "送料"
        Me.TextBox5.Top = 0!
        Me.TextBox5.Width = 0.6153543!
        '
        'TextBox6
        '
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.ClassName = "G_LABEL"
        Me.TextBox6.DataField = "S_FEE"
        Me.TextBox6.Height = 0.1570866!
        Me.TextBox6.Left = 5.970866!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox6.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox6.SummaryGroup = "GroupHeader5"
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox6.Text = "手数料"
        Me.TextBox6.Top = 0!
        Me.TextBox6.Width = 0.6275591!
        '
        'TextBox7
        '
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.ClassName = "G_LABEL"
        Me.TextBox7.DataField = "S_BILL"
        Me.TextBox7.Height = 0.1570866!
        Me.TextBox7.Left = 6.608661!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 7, 0)
        Me.TextBox7.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox7.SummaryGroup = "GroupHeader5"
        Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox7.Text = "売上金額"
        Me.TextBox7.Top = 0!
        Me.TextBox7.Width = 0.6275591!
        '
        'Label54
        '
        Me.Label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.ClassName = "B_LABEL"
        Me.Label54.Height = 0.1570866!
        Me.Label54.HyperLink = Nothing
        Me.Label54.Left = 0!
        Me.Label54.Name = "Label54"
        Me.Label54.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.Label54.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: center; ddo-char-set: 1" &
    "28"
        Me.Label54.Text = "小　　計"
        Me.Label54.Top = 0!
        Me.Label54.Width = 3.529134!
        '
        'TextBox2
        '
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.ClassName = "G_LABEL"
        Me.TextBox2.DataField = "S_CNT"
        Me.TextBox2.Height = 0.1570866!
        Me.TextBox2.Left = 4.258662!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.TextBox2.Style = "background-color: #E0E0E0; font-size: 8.25pt; text-align: right; vertical-align: " &
    "bottom; ddo-char-set: 128"
        Me.TextBox2.SummaryGroup = "GroupHeader5"
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox2.Text = "数量"
        Me.TextBox2.Top = 0!
        Me.TextBox2.Width = 0.45!
        '
        'GroupHeader6
        '
        Me.GroupHeader6.BackColor = System.Drawing.Color.Empty
        Me.GroupHeader6.CanGrow = False
        Me.GroupHeader6.ColumnLayout = False
        Me.GroupHeader6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_BUMON, Me.TextBox11, Me.TextBox14})
        Me.GroupHeader6.DataField = "S_BUMON"
        Me.GroupHeader6.Height = 0.1377953!
        Me.GroupHeader6.Name = "GroupHeader6"
        Me.GroupHeader6.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        Me.GroupHeader6.UnderlayNext = True
        '
        'TextBox11
        '
        Me.TextBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox11.Height = 0.1374016!
        Me.TextBox11.Left = 0!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0!
        Me.TextBox11.Width = 0.5417323!
        '
        'TextBox14
        '
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.Height = 0.1374016!
        Me.TextBox14.Left = 0.5519685!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = -1.862645E-9!
        Me.TextBox14.Width = 0.7629921!
        '
        'GroupFooter6
        '
        Me.GroupFooter6.Height = 0!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'GroupHeader7
        '
        Me.GroupHeader7.BackColor = System.Drawing.Color.Empty
        Me.GroupHeader7.CanGrow = False
        Me.GroupHeader7.ColumnLayout = False
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_PAYMENT, Me.TextBox12, Me.TextBox15, Me.TextBox17})
        Me.GroupHeader7.DataField = "S_PAYMENT"
        Me.GroupHeader7.Height = 0.1374016!
        Me.GroupHeader7.Name = "GroupHeader7"
        Me.GroupHeader7.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        Me.GroupHeader7.UnderlayNext = True
        '
        'S_PAYMENT
        '
        Me.S_PAYMENT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_PAYMENT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_PAYMENT.ClassName = "B_LABEL"
        Me.S_PAYMENT.DataField = "S_PAYMENT"
        Me.S_PAYMENT.Height = 0.1374016!
        Me.S_PAYMENT.Left = 2.359!
        Me.S_PAYMENT.Name = "S_PAYMENT"
        Me.S_PAYMENT.Style = "background-color: White; font-size: 8.25pt; text-align: left; vertical-align: mid" &
    "dle; ddo-char-set: 128"
        Me.S_PAYMENT.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.VarP
        Me.S_PAYMENT.SummaryGroup = "GroupHeader4"
        Me.S_PAYMENT.Text = "支払方法"
        Me.S_PAYMENT.Top = 0!
        Me.S_PAYMENT.Width = 1.182284!
        '
        'TextBox12
        '
        Me.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox12.Height = 0.1374016!
        Me.TextBox12.Left = 0!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0!
        Me.TextBox12.Width = 0.5417323!
        '
        'TextBox15
        '
        Me.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox15.Height = 0.1374016!
        Me.TextBox15.Left = 0.5519685!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 0!
        Me.TextBox15.Width = 0.7629923!
        '
        'TextBox17
        '
        Me.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox17.Height = 0.1374016!
        Me.TextBox17.Left = 1.325197!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 0!
        Me.TextBox17.Width = 1.011024!
        '
        'GroupFooter7
        '
        Me.GroupFooter7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_CNT, Me.S_FEE, Me.S_DISCOUNT, Me.S_BILL, Me.S_POSTAGE, Me.TextBox13, Me.TextBox16, Me.TextBox18, Me.S_SALES})
        Me.GroupFooter7.Height = 0.1374016!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'S_CNT
        '
        Me.S_CNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_CNT.ClassName = "B_LABEL"
        Me.S_CNT.DataField = "S_CNT"
        Me.S_CNT.Height = 0.1374016!
        Me.S_CNT.Left = 4.258662!
        Me.S_CNT.Name = "S_CNT"
        Me.S_CNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_CNT.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_CNT.Text = "数量"
        Me.S_CNT.Top = 0!
        Me.S_CNT.Width = 0.45!
        '
        'S_FEE
        '
        Me.S_FEE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_FEE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_FEE.ClassName = "B_LABEL"
        Me.S_FEE.DataField = "S_FEE"
        Me.S_FEE.Height = 0.1374016!
        Me.S_FEE.Left = 5.97126!
        Me.S_FEE.Name = "S_FEE"
        Me.S_FEE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_FEE.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_FEE.Text = "手数料"
        Me.S_FEE.Top = 0!
        Me.S_FEE.Width = 0.6275591!
        '
        'S_DISCOUNT
        '
        Me.S_DISCOUNT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_DISCOUNT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_DISCOUNT.ClassName = "B_LABEL"
        Me.S_DISCOUNT.DataField = "S_DISCOUNT"
        Me.S_DISCOUNT.Height = 0.1374016!
        Me.S_DISCOUNT.Left = 4.718898!
        Me.S_DISCOUNT.Name = "S_DISCOUNT"
        Me.S_DISCOUNT.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_DISCOUNT.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_DISCOUNT.Text = "値引き"
        Me.S_DISCOUNT.Top = 0!
        Me.S_DISCOUNT.Width = 0.6137795!
        '
        'S_BILL
        '
        Me.S_BILL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_BILL.ClassName = "B_LABEL"
        Me.S_BILL.DataField = "S_BILL"
        Me.S_BILL.Height = 0.1374016!
        Me.S_BILL.Left = 6.608661!
        Me.S_BILL.Name = "S_BILL"
        Me.S_BILL.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 7, 0)
        Me.S_BILL.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_BILL.Text = "売上金額"
        Me.S_BILL.Top = 0!
        Me.S_BILL.Width = 0.6275591!
        '
        'S_POSTAGE
        '
        Me.S_POSTAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POSTAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_POSTAGE.ClassName = "B_LABEL"
        Me.S_POSTAGE.DataField = "S_POSTAGE"
        Me.S_POSTAGE.Height = 0.1374016!
        Me.S_POSTAGE.Left = 5.342914!
        Me.S_POSTAGE.Name = "S_POSTAGE"
        Me.S_POSTAGE.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_POSTAGE.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_POSTAGE.Text = "送料"
        Me.S_POSTAGE.Top = 0!
        Me.S_POSTAGE.Width = 0.6153543!
        '
        'TextBox13
        '
        Me.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox13.Height = 0.1374016!
        Me.TextBox13.Left = 0!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0!
        Me.TextBox13.Width = 0.5417323!
        '
        'TextBox16
        '
        Me.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox16.Height = 0.1374016!
        Me.TextBox16.Left = 0.5519685!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 0!
        Me.TextBox16.Width = 0.7629923!
        '
        'TextBox18
        '
        Me.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox18.Height = 0.1374016!
        Me.TextBox18.Left = 1.325197!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Text = Nothing
        Me.TextBox18.Top = 0!
        Me.TextBox18.Width = 1.011024!
        '
        'S_SALES
        '
        Me.S_SALES.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALES.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.S_SALES.ClassName = "B_LABEL"
        Me.S_SALES.DataField = "S_SALES"
        Me.S_SALES.Height = 0.1374016!
        Me.S_SALES.Left = 3.540945!
        Me.S_SALES.Name = "S_SALES"
        Me.S_SALES.Padding = New DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0)
        Me.S_SALES.Style = "background-color: White; font-size: 8.25pt; text-align: right; vertical-align: bo" &
    "ttom; ddo-char-set: 128"
        Me.S_SALES.Text = "販売金額"
        Me.S_SALES.Top = 0!
        Me.S_SALES.Width = 0.7074804!
        '
        'GroupHeader4
        '
        Me.GroupHeader4.BackColor = System.Drawing.Color.Empty
        Me.GroupHeader4.CanGrow = False
        Me.GroupHeader4.ColumnLayout = False
        Me.GroupHeader4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.S_CLASS})
        Me.GroupHeader4.DataField = "S_CLASS"
        Me.GroupHeader4.Height = 0.1430036!
        Me.GroupHeader4.Name = "GroupHeader4"
        Me.GroupHeader4.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        Me.GroupHeader4.UnderlayNext = True
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Height = 0!
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'rDayCloseReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.240499!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.GroupHeader5)
        Me.Sections.Add(Me.GroupHeader6)
        Me.Sections.Add(Me.GroupHeader7)
        Me.Sections.Add(Me.Detail)
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
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "G_LABEL"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet1"), "B_LABEL"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STAFFNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAKE_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLOSEDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CLASS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_BUMON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CHANNEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R10000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R5000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R500, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K10000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K5000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K500, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R10000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R5000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R500, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K10000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K5000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K500, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_R_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_K_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_R_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_K_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_OUTCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_INCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CALCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_RETCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_YCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_SALECNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_SALECASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_OUTCNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_INCNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_DISCOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_POSTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_FEE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sumS_BILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_PAYMENT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_FEE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_DISCOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_BILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_POSTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.S_SALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents D_R10000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R5000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R1000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R500 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R100 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R50 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_R1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K10000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K5000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K1000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K500 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K100 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K50 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label28 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label29 As DataDynamics.ActiveReports.Label
    Friend WithEvents K_R10000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R5000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R1000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R500 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R100 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R50 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_R1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K10000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K5000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K1000 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K500 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K100 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K50 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label30 As DataDynamics.ActiveReports.Label
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_BUMON As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_CHANNEL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_OUTCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_INCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_CALCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_RETCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_CCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents sumS_SALES As DataDynamics.ActiveReports.TextBox
    Friend WithEvents sumS_CNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents sumS_DISCOUNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents sumS_POSTAGE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents sumS_FEE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label32 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label34 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label39 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label40 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label41 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label42 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label43 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label44 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label46 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_OUTCNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_INCNT As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents S_CLASS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label48 As DataDynamics.ActiveReports.Label
    Friend WithEvents D_R_TOTAL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents D_K_TOTAL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label49 As DataDynamics.ActiveReports.Label
    Friend WithEvents K_R_TOTAL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents K_K_TOTAL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label50 As DataDynamics.ActiveReports.Label
    Friend WithEvents D_TOTAL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label51 As DataDynamics.ActiveReports.Label
    Friend WithEvents K_TOTAL As DataDynamics.ActiveReports.TextBox
    Private WithEvents STAFFNAME As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label52 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_SALECASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_SALECNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label53 As DataDynamics.ActiveReports.Label
    Friend WithEvents S_YCASH As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Private WithEvents CrossSectionBox1 As DataDynamics.ActiveReports.CrossSectionBox
    Friend WithEvents INOUT_DETAIL1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label47 As DataDynamics.ActiveReports.Label
    Friend WithEvents MAKE_DATE As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents CLOSEDATE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label54 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label55 As DataDynamics.ActiveReports.Label
    Friend WithEvents sumS_BILL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Private WithEvents Line4 As DataDynamics.ActiveReports.Line
    Private WithEvents Line5 As DataDynamics.ActiveReports.Line
    Private WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Private WithEvents Line8 As DataDynamics.ActiveReports.Line
    Private WithEvents Line9 As DataDynamics.ActiveReports.Line
    Private WithEvents Line10 As DataDynamics.ActiveReports.Line
    Private WithEvents Line11 As DataDynamics.ActiveReports.Line
    Private WithEvents Line12 As DataDynamics.ActiveReports.Line
    Private WithEvents Line13 As DataDynamics.ActiveReports.Line
    Private WithEvents Line14 As DataDynamics.ActiveReports.Line
    Private WithEvents Line15 As DataDynamics.ActiveReports.Line
    Private WithEvents Line16 As DataDynamics.ActiveReports.Line
    Private WithEvents Line17 As DataDynamics.ActiveReports.Line
    Private WithEvents Line18 As DataDynamics.ActiveReports.Line
    Private WithEvents Line19 As DataDynamics.ActiveReports.Line
    Private WithEvents Line20 As DataDynamics.ActiveReports.Line
    Private WithEvents Line21 As DataDynamics.ActiveReports.Line
    Private WithEvents GroupHeader6 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents INOUT_DETAIL2 As DataDynamics.ActiveReports.SubReport
    Private WithEvents INOUT_DETAIL3 As DataDynamics.ActiveReports.SubReport
    Private WithEvents INOUT_DETAIL4 As DataDynamics.ActiveReports.SubReport
    Private WithEvents PageBreak1 As DataDynamics.ActiveReports.PageBreak
    Private WithEvents INOUT_DETAIL5 As DataDynamics.ActiveReports.SubReport
    Private WithEvents INOUT_DETAIL6 As DataDynamics.ActiveReports.SubReport
    Private WithEvents Label56 As DataDynamics.ActiveReports.Label
    Private WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Private WithEvents PageBreak2 As DataDynamics.ActiveReports.PageBreak
    Private WithEvents INOUT_DETAIL7 As DataDynamics.ActiveReports.SubReport
    Private WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents S_PAYMENT As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents S_SALES As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_CNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_FEE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_DISCOUNT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_BILL As DataDynamics.ActiveReports.TextBox
    Friend WithEvents S_POSTAGE As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents CrossSectionBox2 As DataDynamics.ActiveReports.CrossSectionBox
End Class
