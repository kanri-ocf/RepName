<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rReservCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rReservCard))
        Me.Detail = New DataDynamics.ActiveReports.Detail
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.FROM_DATE = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TO_DATE = New DataDynamics.ActiveReports.TextBox
        Me.FROM_TIME = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.TO_TIME = New DataDynamics.ActiveReports.TextBox
        Me.CUSTOMER_NAME = New DataDynamics.ActiveReports.TextBox
        Me.SERVICE_NAME = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.ROOM_NAME = New DataDynamics.ActiveReports.TextBox
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.SERVICE_STAFF_NAME = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LOGO = New DataDynamics.ActiveReports.Picture
        Me.MEMO = New DataDynamics.ActiveReports.RichTextBox
        Me.CORP_NAME = New DataDynamics.ActiveReports.TextBox
        Me.ADDR1 = New DataDynamics.ActiveReports.TextBox
        Me.TEL = New DataDynamics.ActiveReports.TextBox
        Me.FAX = New DataDynamics.ActiveReports.TextBox
        Me.ADDR2 = New DataDynamics.ActiveReports.TextBox
        Me.POST_CODE = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.FRONT_STAFF_NAME = New DataDynamics.ActiveReports.TextBox
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FROM_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TO_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FROM_TIME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TO_TIME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SERVICE_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ROOM_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SERVICE_STAFF_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POST_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FRONT_STAFF_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.FROM_DATE, Me.TO_DATE, Me.FROM_TIME, Me.Label6, Me.TO_TIME, Me.CUSTOMER_NAME, Me.SERVICE_NAME, Me.Label7, Me.ROOM_NAME, Me.Label8, Me.SERVICE_STAFF_NAME, Me.Label9, Me.LOGO, Me.MEMO, Me.CORP_NAME, Me.ADDR1, Me.TEL, Me.FAX, Me.ADDR2, Me.POST_CODE, Me.Label5, Me.Label10, Me.FRONT_STAFF_NAME})
        Me.Detail.Height = 4.7292!
        Me.Detail.Name = "Detail"
        '
        'Label1
        '
        Me.Label1.Height = 0.40625!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.1023622!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 18pt; text-align: center; vertical-align: middle"
        Me.Label1.Text = "≪ご予約票≫"
        Me.Label1.Top = 0.06220473!
        Me.Label1.Width = 7.183072!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.1023622!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 12pt; text-align: right"
        Me.Label2.Text = "お客様名称："
        Me.Label2.Top = 0.8228344!
        Me.Label2.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.1023621!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 12pt; text-align: right"
        Me.Label3.Text = "サービス内容："
        Me.Label3.Top = 1.134646!
        Me.Label3.Width = 1.0!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.1023621!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 12pt; text-align: right"
        Me.Label4.Text = "ご予約日時："
        Me.Label4.Top = 1.488189!
        Me.Label4.Width = 1.0!
        '
        'FROM_DATE
        '
        Me.FROM_DATE.DataField = "FROM_DATE"
        Me.FROM_DATE.Height = 0.2!
        Me.FROM_DATE.Left = 1.175198!
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.Style = "color: Red; font-size: 14.25pt; font-weight: bold; text-align: left"
        Me.FROM_DATE.Text = "2012/12/31"
        Me.FROM_DATE.Top = 1.488189!
        Me.FROM_DATE.Width = 1.198031!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.332284!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 12pt; text-align: center"
        Me.Label5.Text = "～"
        Me.Label5.Top = 1.488189!
        Me.Label5.Width = 0.3543305!
        '
        'TO_DATE
        '
        Me.TO_DATE.DataField = "TO_DATE"
        Me.TO_DATE.Height = 0.2!
        Me.TO_DATE.Left = 2.686614!
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.Style = "color: Red; font-size: 14.25pt; font-weight: bold; text-align: left"
        Me.TO_DATE.Text = "2012/12/31"
        Me.TO_DATE.Top = 1.488189!
        Me.TO_DATE.Width = 1.343701!
        '
        'FROM_TIME
        '
        Me.FROM_TIME.DataField = "FROM_TIME"
        Me.FROM_TIME.Height = 0.2!
        Me.FROM_TIME.Left = 1.175198!
        Me.FROM_TIME.Name = "FROM_TIME"
        Me.FROM_TIME.Style = "color: Red; font-size: 14.25pt; font-weight: bold; text-align: left"
        Me.FROM_TIME.Text = "10:30"
        Me.FROM_TIME.Top = 1.75!
        Me.FROM_TIME.Width = 0.5519679!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.706693!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 12pt; text-align: center"
        Me.Label6.Text = "～"
        Me.Label6.Top = 1.75!
        Me.Label6.Width = 0.3543305!
        '
        'TO_TIME
        '
        Me.TO_TIME.DataField = "TO_TIME"
        Me.TO_TIME.Height = 0.2!
        Me.TO_TIME.Left = 2.081496!
        Me.TO_TIME.Name = "TO_TIME"
        Me.TO_TIME.Style = "color: Red; font-size: 14.25pt; font-weight: bold; text-align: left"
        Me.TO_TIME.Text = "19:00"
        Me.TO_TIME.Top = 1.75!
        Me.TO_TIME.Width = 0.5519686!
        '
        'CUSTOMER_NAME
        '
        Me.CUSTOMER_NAME.DataField = "CUSTOMER_NAME"
        Me.CUSTOMER_NAME.Height = 0.2!
        Me.CUSTOMER_NAME.Left = 1.175198!
        Me.CUSTOMER_NAME.Name = "CUSTOMER_NAME"
        Me.CUSTOMER_NAME.Style = "font-size: 14.25pt; text-align: left"
        Me.CUSTOMER_NAME.Text = "CUSTOMER_NAME"
        Me.CUSTOMER_NAME.Top = 0.8228344!
        Me.CUSTOMER_NAME.Width = 3.072835!
        '
        'SERVICE_NAME
        '
        Me.SERVICE_NAME.DataField = "SERVICE_NAME"
        Me.SERVICE_NAME.Height = 0.2!
        Me.SERVICE_NAME.Left = 1.175198!
        Me.SERVICE_NAME.Name = "SERVICE_NAME"
        Me.SERVICE_NAME.Style = "font-size: 14.25pt; text-align: left"
        Me.SERVICE_NAME.Text = "SERVICE_NAME"
        Me.SERVICE_NAME.Top = 1.134646!
        Me.SERVICE_NAME.Width = 3.072835!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.102362!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 12pt; text-align: right"
        Me.Label7.Text = "ルーム名称："
        Me.Label7.Top = 2.041732!
        Me.Label7.Width = 1.0!
        '
        'ROOM_NAME
        '
        Me.ROOM_NAME.DataField = "ROOM_NAME"
        Me.ROOM_NAME.Height = 0.2!
        Me.ROOM_NAME.Left = 1.175198!
        Me.ROOM_NAME.Name = "ROOM_NAME"
        Me.ROOM_NAME.Style = "font-size: 14.25pt; text-align: left"
        Me.ROOM_NAME.Text = "ROOM_NAME"
        Me.ROOM_NAME.Top = 2.041732!
        Me.ROOM_NAME.Width = 3.072835!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.1023617!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 12pt; text-align: right"
        Me.Label8.Text = "スタッフ名称："
        Me.Label8.Top = 2.322834!
        Me.Label8.Width = 1.0!
        '
        'SERVICE_STAFF_NAME
        '
        Me.SERVICE_STAFF_NAME.DataField = "SERVICE_STAFF_NAME"
        Me.SERVICE_STAFF_NAME.Height = 0.2!
        Me.SERVICE_STAFF_NAME.Left = 1.175198!
        Me.SERVICE_STAFF_NAME.Name = "SERVICE_STAFF_NAME"
        Me.SERVICE_STAFF_NAME.Style = "font-size: 14.25pt; text-align: left"
        Me.SERVICE_STAFF_NAME.Text = "SERVICE_STAFF_NAME"
        Me.SERVICE_STAFF_NAME.Top = 2.322834!
        Me.SERVICE_STAFF_NAME.Width = 3.072835!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.1023622!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 12pt; text-align: left"
        Me.Label9.Text = "≪メモ≫"
        Me.Label9.Top = 2.747638!
        Me.Label9.Width = 1.0!
        '
        'LOGO
        '
        Me.LOGO.DataField = "LOGO"
        Me.LOGO.Height = 0.666142!
        Me.LOGO.ImageData = Nothing
        Me.LOGO.Left = 4.503544!
        Me.LOGO.Name = "LOGO"
        Me.LOGO.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.LOGO.Top = 0.468504!
        Me.LOGO.Width = 2.781497!
        '
        'MEMO
        '
        Me.MEMO.AutoReplaceFields = True
        Me.MEMO.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.MEMO.DataField = "MEMO"
        Me.MEMO.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.MEMO.Height = 1.5!
        Me.MEMO.Left = 0.1023622!
        Me.MEMO.Name = "MEMO"
        Me.MEMO.RTF = resources.GetString("MEMO.RTF")
        Me.MEMO.Top = 2.991733!
        Me.MEMO.Width = 7.183072!
        '
        'CORP_NAME
        '
        Me.CORP_NAME.DataField = "CORP_NAME"
        Me.CORP_NAME.Height = 0.2!
        Me.CORP_NAME.Left = 4.503544!
        Me.CORP_NAME.Name = "CORP_NAME"
        Me.CORP_NAME.Style = "font-size: 12pt; text-align: left"
        Me.CORP_NAME.Text = "CORP_NAME"
        Me.CORP_NAME.Top = 1.190551!
        Me.CORP_NAME.Width = 2.781496!
        '
        'ADDR1
        '
        Me.ADDR1.DataField = "ADDR1"
        Me.ADDR1.Height = 0.2!
        Me.ADDR1.Left = 4.503544!
        Me.ADDR1.Name = "ADDR1"
        Me.ADDR1.Style = "font-size: 11.25pt; text-align: left"
        Me.ADDR1.Text = "ADDR1"
        Me.ADDR1.Top = 1.595276!
        Me.ADDR1.Width = 2.781496!
        '
        'TEL
        '
        Me.TEL.DataField = "TEL"
        Me.TEL.Height = 0.2!
        Me.TEL.Left = 4.503544!
        Me.TEL.Name = "TEL"
        Me.TEL.Style = "font-size: 11.25pt; text-align: left"
        Me.TEL.Text = "TEL"
        Me.TEL.Top = 2.020473!
        Me.TEL.Width = 1.396063!
        '
        'FAX
        '
        Me.FAX.DataField = "FAX"
        Me.FAX.Height = 0.2!
        Me.FAX.Left = 5.88937!
        Me.FAX.Name = "FAX"
        Me.FAX.Style = "font-size: 11.25pt; text-align: left"
        Me.FAX.Text = "FAX"
        Me.FAX.Top = 2.020473!
        Me.FAX.Width = 1.396063!
        '
        'ADDR2
        '
        Me.ADDR2.DataField = "ADDR2"
        Me.ADDR2.Height = 0.1999999!
        Me.ADDR2.Left = 4.503544!
        Me.ADDR2.Name = "ADDR2"
        Me.ADDR2.Style = "font-size: 11.25pt; text-align: left"
        Me.ADDR2.Text = "ADDR2"
        Me.ADDR2.Top = 1.81063!
        Me.ADDR2.Width = 2.781496!
        '
        'POST_CODE
        '
        Me.POST_CODE.DataField = "POST_CODE"
        Me.POST_CODE.Height = 0.2!
        Me.POST_CODE.Left = 4.503544!
        Me.POST_CODE.Name = "POST_CODE"
        Me.POST_CODE.Style = "font-size: 11.25pt; text-align: left"
        Me.POST_CODE.Text = "POST_CODE"
        Me.POST_CODE.Top = 1.390551!
        Me.POST_CODE.Width = 2.781496!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.503542!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 11.25pt; text-align: left"
        Me.Label10.Text = "スタッフ名称："
        Me.Label10.Top = 2.322835!
        Me.Label10.Width = 0.9165373!
        '
        'FRONT_STAFF_NAME
        '
        Me.FRONT_STAFF_NAME.DataField = "FRONT_STAFF_NAME"
        Me.FRONT_STAFF_NAME.Height = 0.2!
        Me.FRONT_STAFF_NAME.Left = 5.420079!
        Me.FRONT_STAFF_NAME.Name = "FRONT_STAFF_NAME"
        Me.FRONT_STAFF_NAME.Style = "font-size: 11.25pt; text-align: left"
        Me.FRONT_STAFF_NAME.Text = "FRONT_STAFF_NAME"
        Me.FRONT_STAFF_NAME.Top = 2.322835!
        Me.FRONT_STAFF_NAME.Width = 1.865355!
        '
        'rReservCard
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.409629!
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FROM_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TO_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FROM_TIME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TO_TIME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SERVICE_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ROOM_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SERVICE_STAFF_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LOGO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORP_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POST_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FRONT_STAFF_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents FROM_DATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents TO_DATE As DataDynamics.ActiveReports.TextBox
    Private WithEvents FROM_TIME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents TO_TIME As DataDynamics.ActiveReports.TextBox
    Private WithEvents CUSTOMER_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents SERVICE_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents ROOM_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents SERVICE_STAFF_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents LOGO As DataDynamics.ActiveReports.Picture
    Private WithEvents MEMO As DataDynamics.ActiveReports.RichTextBox
    Private WithEvents CORP_NAME As DataDynamics.ActiveReports.TextBox
    Private WithEvents ADDR1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TEL As DataDynamics.ActiveReports.TextBox
    Private WithEvents FAX As DataDynamics.ActiveReports.TextBox
    Private WithEvents ADDR2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents POST_CODE As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents FRONT_STAFF_NAME As DataDynamics.ActiveReports.TextBox
End Class
