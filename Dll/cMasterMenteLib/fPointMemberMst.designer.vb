<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointMemberMst
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.POINT_ADD_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.CHANNEL_NAME_T = New System.Windows.Forms.TextBox
        Me.POINT_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.END_REG_CLR_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMO_T = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.REG_UPDATE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RESIGNDATE_CLR_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ADDDR_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.BIRTHDAY_CLR_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.END_REG_DATE_D = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.UPDATE_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.ST_REG_DATE_D = New System.Windows.Forms.DateTimePicker
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.RESIGN_DATE_D = New System.Windows.Forms.DateTimePicker
        Me.ENTRY_DATE_D = New System.Windows.Forms.DateTimePicker
        Me.Label18 = New System.Windows.Forms.Label
        Me.MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.BIRTHDAY_D = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ADDRESS3_T = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ADDRESS2_T = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.ADDRESS1_C = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.SEX_G = New System.Windows.Forms.GroupBox
        Me.SEX_M_R = New System.Windows.Forms.RadioButton
        Me.SEX_F_R = New System.Windows.Forms.RadioButton
        Me.AGE_T = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.E_MAIL_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.FAX_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TEL_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.POST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.MEMBER_NAME_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.MODE_L = New System.Windows.Forms.Label
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SEX_G.SuspendLayout()
        Me.SuspendLayout()
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(177, 484)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(192, 19)
        Me.STAFF_NAME_T.TabIndex = 0
        Me.STAFF_NAME_T.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "担当者："
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(84, 484)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(87, 19)
        Me.STAFF_CODE_T.TabIndex = 12
        Me.STAFF_CODE_T.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.POINT_ADD_B)
        Me.GroupBox1.Controls.Add(Me.CHANNEL_CODE_T)
        Me.GroupBox1.Controls.Add(Me.CHANNEL_NAME_T)
        Me.GroupBox1.Controls.Add(Me.POINT_COUNT_T)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.END_REG_CLR_B)
        Me.GroupBox1.Controls.Add(Me.MEMO_T)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.REG_UPDATE_B)
        Me.GroupBox1.Controls.Add(Me.RESIGNDATE_CLR_B)
        Me.GroupBox1.Controls.Add(Me.ADDDR_SEARCH_B)
        Me.GroupBox1.Controls.Add(Me.BIRTHDAY_CLR_B)
        Me.GroupBox1.Controls.Add(Me.MEMBER_SEARCH_B)
        Me.GroupBox1.Controls.Add(Me.END_REG_DATE_D)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.UPDATE_COUNT_T)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.ST_REG_DATE_D)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.RESIGN_DATE_D)
        Me.GroupBox1.Controls.Add(Me.ENTRY_DATE_D)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.MEMBER_CODE_T)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.BIRTHDAY_D)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ADDRESS3_T)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.ADDRESS2_T)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.ADDRESS1_C)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.SEX_G)
        Me.GroupBox1.Controls.Add(Me.AGE_T)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.E_MAIL_T)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.FAX_T)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TEL_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.POST_CODE_T)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.MEMBER_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(32, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(916, 421)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'POINT_ADD_B
        '
        Me.POINT_ADD_B.ColorBottom = System.Drawing.Color.Wheat
        Me.POINT_ADD_B.Location = New System.Drawing.Point(697, 67)
        Me.POINT_ADD_B.Name = "POINT_ADD_B"
        Me.POINT_ADD_B.Size = New System.Drawing.Size(85, 33)
        Me.POINT_ADD_B.TabIndex = 158
        Me.POINT_ADD_B.TextButton = "ポイント付与"
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(282, 69)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.ReadOnly = True
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(55, 20)
        Me.CHANNEL_CODE_T.TabIndex = 157
        Me.CHANNEL_CODE_T.TabStop = False
        Me.CHANNEL_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CHANNEL_CODE_T.Visible = False
        '
        'CHANNEL_NAME_T
        '
        Me.CHANNEL_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.CHANNEL_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_T.Location = New System.Drawing.Point(96, 67)
        Me.CHANNEL_NAME_T.Name = "CHANNEL_NAME_T"
        Me.CHANNEL_NAME_T.ReadOnly = True
        Me.CHANNEL_NAME_T.Size = New System.Drawing.Size(171, 20)
        Me.CHANNEL_NAME_T.TabIndex = 156
        Me.CHANNEL_NAME_T.TabStop = False
        Me.CHANNEL_NAME_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'POINT_COUNT_T
        '
        Me.POINT_COUNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.POINT_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_COUNT_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.POINT_COUNT_T.Location = New System.Drawing.Point(511, 69)
        Me.POINT_COUNT_T.Name = "POINT_COUNT_T"
        Me.POINT_COUNT_T.ReadOnly = True
        Me.POINT_COUNT_T.Size = New System.Drawing.Size(180, 31)
        Me.POINT_COUNT_T.TabIndex = 154
        Me.POINT_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(463, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "【保有ポイント数】"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'END_REG_CLR_B
        '
        Me.END_REG_CLR_B.ColorBottom = System.Drawing.Color.Wheat
        Me.END_REG_CLR_B.Location = New System.Drawing.Point(802, 172)
        Me.END_REG_CLR_B.Name = "END_REG_CLR_B"
        Me.END_REG_CLR_B.Size = New System.Drawing.Size(105, 29)
        Me.END_REG_CLR_B.TabIndex = 153
        Me.END_REG_CLR_B.TextButton = "期間満了日クリア"
        '
        'MEMO_T
        '
        Me.MEMO_T.BackColor = System.Drawing.Color.White
        Me.MEMO_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO_T.Location = New System.Drawing.Point(512, 241)
        Me.MEMO_T.Multiline = True
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Size = New System.Drawing.Size(395, 79)
        Me.MEMO_T.TabIndex = 151
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(471, 241)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 152
        Me.Label24.Text = "備考："
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'REG_UPDATE_B
        '
        Me.REG_UPDATE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REG_UPDATE_B.Location = New System.Drawing.Point(551, 200)
        Me.REG_UPDATE_B.Name = "REG_UPDATE_B"
        Me.REG_UPDATE_B.Size = New System.Drawing.Size(100, 29)
        Me.REG_UPDATE_B.TabIndex = 21
        Me.REG_UPDATE_B.TextButton = "契約更新"
        '
        'RESIGNDATE_CLR_B
        '
        Me.RESIGNDATE_CLR_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RESIGNDATE_CLR_B.Location = New System.Drawing.Point(643, 142)
        Me.RESIGNDATE_CLR_B.Name = "RESIGNDATE_CLR_B"
        Me.RESIGNDATE_CLR_B.Size = New System.Drawing.Size(109, 29)
        Me.RESIGNDATE_CLR_B.TabIndex = 17
        Me.RESIGNDATE_CLR_B.TextButton = "退会日クリア"
        '
        'ADDDR_SEARCH_B
        '
        Me.ADDDR_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ADDDR_SEARCH_B.Location = New System.Drawing.Point(176, 175)
        Me.ADDDR_SEARCH_B.Name = "ADDDR_SEARCH_B"
        Me.ADDDR_SEARCH_B.Size = New System.Drawing.Size(91, 29)
        Me.ADDDR_SEARCH_B.TabIndex = 7
        Me.ADDDR_SEARCH_B.TextButton = "住所検索"
        '
        'BIRTHDAY_CLR_B
        '
        Me.BIRTHDAY_CLR_B.ColorBottom = System.Drawing.Color.Wheat
        Me.BIRTHDAY_CLR_B.Location = New System.Drawing.Point(228, 122)
        Me.BIRTHDAY_CLR_B.Name = "BIRTHDAY_CLR_B"
        Me.BIRTHDAY_CLR_B.Size = New System.Drawing.Size(109, 29)
        Me.BIRTHDAY_CLR_B.TabIndex = 4
        Me.BIRTHDAY_CLR_B.TextButton = "生年月日クリア"
        '
        'MEMBER_SEARCH_B
        '
        Me.MEMBER_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_SEARCH_B.Location = New System.Drawing.Point(787, 18)
        Me.MEMBER_SEARCH_B.Name = "MEMBER_SEARCH_B"
        Me.MEMBER_SEARCH_B.Size = New System.Drawing.Size(122, 45)
        Me.MEMBER_SEARCH_B.TabIndex = 3
        Me.MEMBER_SEARCH_B.TextButton = "会員検索"
        '
        'END_REG_DATE_D
        '
        Me.END_REG_DATE_D.CalendarFont = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.END_REG_DATE_D.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.END_REG_DATE_D.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.END_REG_DATE_D.Location = New System.Drawing.Point(672, 177)
        Me.END_REG_DATE_D.Margin = New System.Windows.Forms.Padding(5)
        Me.END_REG_DATE_D.Name = "END_REG_DATE_D"
        Me.END_REG_DATE_D.Size = New System.Drawing.Size(122, 19)
        Me.END_REG_DATE_D.TabIndex = 19
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(43, 69)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 127
        Me.Label28.Text = "チャネル："
        '
        'UPDATE_COUNT_T
        '
        Me.UPDATE_COUNT_T.BackColor = System.Drawing.Color.White
        Me.UPDATE_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UPDATE_COUNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.UPDATE_COUNT_T.Location = New System.Drawing.Point(512, 205)
        Me.UPDATE_COUNT_T.Name = "UPDATE_COUNT_T"
        Me.UPDATE_COUNT_T.Size = New System.Drawing.Size(30, 20)
        Me.UPDATE_COUNT_T.TabIndex = 20
        Me.UPDATE_COUNT_T.Text = "0"
        Me.UPDATE_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(446, 209)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "更新回数："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.Location = New System.Drawing.Point(644, 180)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(20, 13)
        Me.Label40.TabIndex = 111
        Me.Label40.Text = "～"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ST_REG_DATE_D
        '
        Me.ST_REG_DATE_D.CalendarFont = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ST_REG_DATE_D.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ST_REG_DATE_D.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ST_REG_DATE_D.Location = New System.Drawing.Point(512, 177)
        Me.ST_REG_DATE_D.Margin = New System.Windows.Forms.Padding(5)
        Me.ST_REG_DATE_D.Name = "ST_REG_DATE_D"
        Me.ST_REG_DATE_D.Size = New System.Drawing.Size(122, 19)
        Me.ST_REG_DATE_D.TabIndex = 18
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.Location = New System.Drawing.Point(446, 181)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(66, 13)
        Me.Label41.TabIndex = 108
        Me.Label41.Text = "契約期間："
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.Location = New System.Drawing.Point(459, 149)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(53, 13)
        Me.Label39.TabIndex = 107
        Me.Label39.Text = "退会日："
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RESIGN_DATE_D
        '
        Me.RESIGN_DATE_D.CalendarFont = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RESIGN_DATE_D.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RESIGN_DATE_D.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.RESIGN_DATE_D.Location = New System.Drawing.Point(512, 147)
        Me.RESIGN_DATE_D.Margin = New System.Windows.Forms.Padding(5)
        Me.RESIGN_DATE_D.Name = "RESIGN_DATE_D"
        Me.RESIGN_DATE_D.Size = New System.Drawing.Size(122, 19)
        Me.RESIGN_DATE_D.TabIndex = 16
        '
        'ENTRY_DATE_D
        '
        Me.ENTRY_DATE_D.CalendarFont = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ENTRY_DATE_D.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ENTRY_DATE_D.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ENTRY_DATE_D.CausesValidation = False
        Me.ENTRY_DATE_D.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ENTRY_DATE_D.Location = New System.Drawing.Point(512, 122)
        Me.ENTRY_DATE_D.Margin = New System.Windows.Forms.Padding(5)
        Me.ENTRY_DATE_D.Name = "ENTRY_DATE_D"
        Me.ENTRY_DATE_D.Size = New System.Drawing.Size(122, 19)
        Me.ENTRY_DATE_D.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(458, 126)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "入会日："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MEMBER_CODE_T
        '
        Me.MEMBER_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_CODE_T.Location = New System.Drawing.Point(96, 39)
        Me.MEMBER_CODE_T.Name = "MEMBER_CODE_T"
        Me.MEMBER_CODE_T.ReadOnly = True
        Me.MEMBER_CODE_T.Size = New System.Drawing.Size(171, 20)
        Me.MEMBER_CODE_T.TabIndex = 0
        Me.MEMBER_CODE_T.TabStop = False
        Me.MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(29, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "会員コード："
        '
        'BIRTHDAY_D
        '
        Me.BIRTHDAY_D.CalendarFont = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BIRTHDAY_D.Cursor = System.Windows.Forms.Cursors.Default
        Me.BIRTHDAY_D.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BIRTHDAY_D.Location = New System.Drawing.Point(96, 126)
        Me.BIRTHDAY_D.Margin = New System.Windows.Forms.Padding(5)
        Me.BIRTHDAY_D.Name = "BIRTHDAY_D"
        Me.BIRTHDAY_D.Size = New System.Drawing.Size(122, 19)
        Me.BIRTHDAY_D.TabIndex = 3
        Me.BIRTHDAY_D.Value = New Date(2009, 5, 28, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(227, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 12)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "(スラッシュなし半角数字-20090101)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(271, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 12)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "(ハイフンなし半角数字-1234567)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ADDRESS3_T
        '
        Me.ADDRESS3_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ADDRESS3_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDRESS3_T.Location = New System.Drawing.Point(95, 260)
        Me.ADDRESS3_T.Name = "ADDRESS3_T"
        Me.ADDRESS3_T.Size = New System.Drawing.Size(317, 20)
        Me.ADDRESS3_T.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(54, 263)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "以下："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ADDRESS2_T
        '
        Me.ADDRESS2_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ADDRESS2_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDRESS2_T.Location = New System.Drawing.Point(95, 234)
        Me.ADDRESS2_T.Name = "ADDRESS2_T"
        Me.ADDRESS2_T.Size = New System.Drawing.Size(317, 20)
        Me.ADDRESS2_T.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(29, 239)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "市区町村："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ADDRESS1_C
        '
        Me.ADDRESS1_C.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ADDRESS1_C.FormattingEnabled = True
        Me.ADDRESS1_C.Location = New System.Drawing.Point(95, 208)
        Me.ADDRESS1_C.Name = "ADDRESS1_C"
        Me.ADDRESS1_C.Size = New System.Drawing.Size(121, 20)
        Me.ADDRESS1_C.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(29, 212)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "都道府県："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(30, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "生年月日："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SEX_G
        '
        Me.SEX_G.Controls.Add(Me.SEX_M_R)
        Me.SEX_G.Controls.Add(Me.SEX_F_R)
        Me.SEX_G.ForeColor = System.Drawing.Color.Black
        Me.SEX_G.Location = New System.Drawing.Point(96, 286)
        Me.SEX_G.Name = "SEX_G"
        Me.SEX_G.Size = New System.Drawing.Size(178, 39)
        Me.SEX_G.TabIndex = 11
        Me.SEX_G.TabStop = False
        Me.SEX_G.Text = "【 性別 】"
        '
        'SEX_M_R
        '
        Me.SEX_M_R.AutoSize = True
        Me.SEX_M_R.Location = New System.Drawing.Point(22, 18)
        Me.SEX_M_R.Name = "SEX_M_R"
        Me.SEX_M_R.Size = New System.Drawing.Size(35, 16)
        Me.SEX_M_R.TabIndex = 0
        Me.SEX_M_R.TabStop = True
        Me.SEX_M_R.Text = "男"
        Me.SEX_M_R.UseVisualStyleBackColor = True
        '
        'SEX_F_R
        '
        Me.SEX_F_R.AutoSize = True
        Me.SEX_F_R.Location = New System.Drawing.Point(99, 18)
        Me.SEX_F_R.Name = "SEX_F_R"
        Me.SEX_F_R.Size = New System.Drawing.Size(35, 16)
        Me.SEX_F_R.TabIndex = 1
        Me.SEX_F_R.TabStop = True
        Me.SEX_F_R.Text = "女"
        Me.SEX_F_R.UseVisualStyleBackColor = True
        '
        'AGE_T
        '
        Me.AGE_T.BackColor = System.Drawing.Color.White
        Me.AGE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AGE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.AGE_T.Location = New System.Drawing.Point(96, 153)
        Me.AGE_T.Name = "AGE_T"
        Me.AGE_T.Size = New System.Drawing.Size(30, 20)
        Me.AGE_T.TabIndex = 5
        Me.AGE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "年齢："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'E_MAIL_T
        '
        Me.E_MAIL_T.BackColor = System.Drawing.Color.White
        Me.E_MAIL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.E_MAIL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.E_MAIL_T.Location = New System.Drawing.Point(96, 382)
        Me.E_MAIL_T.Name = "E_MAIL_T"
        Me.E_MAIL_T.Size = New System.Drawing.Size(316, 20)
        Me.E_MAIL_T.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(49, 386)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "E-Mail："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FAX_T
        '
        Me.FAX_T.BackColor = System.Drawing.Color.White
        Me.FAX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FAX_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.FAX_T.Location = New System.Drawing.Point(96, 357)
        Me.FAX_T.Name = "FAX_T"
        Me.FAX_T.Size = New System.Drawing.Size(178, 20)
        Me.FAX_T.TabIndex = 13
        Me.FAX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(60, 361)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "FAX："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TEL_T
        '
        Me.TEL_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TEL_T.Location = New System.Drawing.Point(96, 332)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.Size = New System.Drawing.Size(178, 20)
        Me.TEL_T.TabIndex = 12
        Me.TEL_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(61, 336)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "TEL："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'POST_CODE_T
        '
        Me.POST_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.POST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.POST_CODE_T.Location = New System.Drawing.Point(95, 179)
        Me.POST_CODE_T.Name = "POST_CODE_T"
        Me.POST_CODE_T.Size = New System.Drawing.Size(75, 20)
        Me.POST_CODE_T.TabIndex = 6
        Me.POST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "郵便番号："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MEMBER_NAME_T
        '
        Me.MEMBER_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.MEMBER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMBER_NAME_T.Location = New System.Drawing.Point(96, 96)
        Me.MEMBER_NAME_T.Name = "MEMBER_NAME_T"
        Me.MEMBER_NAME_T.Size = New System.Drawing.Size(178, 20)
        Me.MEMBER_NAME_T.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "会員名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Blue
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(29, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(919, 15)
        Me.MODE_L.TabIndex = 97
        Me.MODE_L.Text = "（更新）"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.QUIT_B.Location = New System.Drawing.Point(643, 468)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(98, 46)
        Me.QUIT_B.TabIndex = 4
        Me.QUIT_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(747, 468)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 46)
        Me.COMMIT_B.TabIndex = 5
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(850, 468)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 46)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.TextButton = "終　了"
        '
        'fPointMemberMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(976, 527)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPointMemberMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "会員情報入力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SEX_G.ResumeLayout(False)
        Me.SEX_G.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ADDRESS3_T As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ADDRESS2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ADDRESS1_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SEX_G As System.Windows.Forms.GroupBox
    Friend WithEvents SEX_M_R As System.Windows.Forms.RadioButton
    Friend WithEvents SEX_F_R As System.Windows.Forms.RadioButton
    Friend WithEvents AGE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents E_MAIL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents POST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MEMBER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BIRTHDAY_D As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents END_REG_DATE_D As System.Windows.Forms.DateTimePicker
    Friend WithEvents ST_REG_DATE_D As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents RESIGN_DATE_D As System.Windows.Forms.DateTimePicker
    Friend WithEvents ENTRY_DATE_D As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UPDATE_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Public WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MEMBER_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents BIRTHDAY_CLR_B As Softgroup.NetButton.NetButton
    Friend WithEvents ADDDR_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RESIGNDATE_CLR_B As Softgroup.NetButton.NetButton
    Friend WithEvents REG_UPDATE_B As Softgroup.NetButton.NetButton
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMO_T As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents END_REG_CLR_B As Softgroup.NetButton.NetButton
    Public WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents CHANNEL_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents POINT_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents POINT_ADD_B As Softgroup.NetButton.NetButton
End Class
