<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCustomer
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
        Me.components = New System.ComponentModel.Container()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SEX_C2 = New System.Windows.Forms.CheckBox()
        Me.SEX_C1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GEN_C7 = New System.Windows.Forms.CheckBox()
        Me.GEN_C6 = New System.Windows.Forms.CheckBox()
        Me.GEN_C5 = New System.Windows.Forms.CheckBox()
        Me.GEN_C4 = New System.Windows.Forms.CheckBox()
        Me.GEN_C3 = New System.Windows.Forms.CheckBox()
        Me.GEN_C2 = New System.Windows.Forms.CheckBox()
        Me.GEN_C1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.WEA_C4 = New System.Windows.Forms.CheckBox()
        Me.WEA_C3 = New System.Windows.Forms.CheckBox()
        Me.WEA_C2 = New System.Windows.Forms.CheckBox()
        Me.WEA_C1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.MEMBER_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WEATHER_T = New System.Windows.Forms.TextBox()
        Me.MEMBER_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.POST_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ADDRESS_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TEL_T = New System.Windows.Forms.TextBox()
        Me.FAX_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.E_MAIL_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SEX_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GEN_T = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ENTRY_DATE_T = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.REG_S_DATE = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.REG_E_DATE = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RESIGN_DATE_T = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MEMBER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_INS_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_EDIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DROWER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(81, 411)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(196, 22)
        Me.STAFF_NAME_T.TabIndex = 0
        Me.STAFF_NAME_T.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SEX_C2)
        Me.GroupBox1.Controls.Add(Me.SEX_C1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(28, 228)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 72)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "性別"
        '
        'SEX_C2
        '
        Me.SEX_C2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SEX_C2.Appearance = System.Windows.Forms.Appearance.Button
        Me.SEX_C2.BackColor = System.Drawing.Color.Wheat
        Me.SEX_C2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEX_C2.Location = New System.Drawing.Point(96, 17)
        Me.SEX_C2.Name = "SEX_C2"
        Me.SEX_C2.Size = New System.Drawing.Size(74, 49)
        Me.SEX_C2.TabIndex = 2
        Me.SEX_C2.Text = "女"
        Me.SEX_C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SEX_C2.UseVisualStyleBackColor = False
        '
        'SEX_C1
        '
        Me.SEX_C1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SEX_C1.Appearance = System.Windows.Forms.Appearance.Button
        Me.SEX_C1.BackColor = System.Drawing.Color.Wheat
        Me.SEX_C1.FlatAppearance.BorderSize = 10
        Me.SEX_C1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEX_C1.Location = New System.Drawing.Point(14, 17)
        Me.SEX_C1.Name = "SEX_C1"
        Me.SEX_C1.Size = New System.Drawing.Size(74, 49)
        Me.SEX_C1.TabIndex = 1
        Me.SEX_C1.Text = "男"
        Me.SEX_C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SEX_C1.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GEN_C7)
        Me.GroupBox2.Controls.Add(Me.GEN_C6)
        Me.GroupBox2.Controls.Add(Me.GEN_C5)
        Me.GroupBox2.Controls.Add(Me.GEN_C4)
        Me.GroupBox2.Controls.Add(Me.GEN_C3)
        Me.GroupBox2.Controls.Add(Me.GEN_C2)
        Me.GroupBox2.Controls.Add(Me.GEN_C1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(28, 308)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 72)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "年代"
        '
        'GEN_C7
        '
        Me.GEN_C7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C7.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C7.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C7.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C7.Location = New System.Drawing.Point(495, 18)
        Me.GEN_C7.Name = "GEN_C7"
        Me.GEN_C7.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C7.TabIndex = 9
        Me.GEN_C7.Text = "老人"
        Me.GEN_C7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C7.UseVisualStyleBackColor = False
        '
        'GEN_C6
        '
        Me.GEN_C6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C6.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C6.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C6.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C6.Location = New System.Drawing.Point(415, 18)
        Me.GEN_C6.Name = "GEN_C6"
        Me.GEN_C6.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C6.TabIndex = 8
        Me.GEN_C6.Text = "60代"
        Me.GEN_C6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C6.UseVisualStyleBackColor = False
        '
        'GEN_C5
        '
        Me.GEN_C5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C5.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C5.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C5.Location = New System.Drawing.Point(335, 17)
        Me.GEN_C5.Name = "GEN_C5"
        Me.GEN_C5.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C5.TabIndex = 7
        Me.GEN_C5.Text = "50代"
        Me.GEN_C5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C5.UseVisualStyleBackColor = False
        '
        'GEN_C4
        '
        Me.GEN_C4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C4.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C4.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C4.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C4.Location = New System.Drawing.Point(255, 17)
        Me.GEN_C4.Name = "GEN_C4"
        Me.GEN_C4.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C4.TabIndex = 6
        Me.GEN_C4.Text = "40代"
        Me.GEN_C4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C4.UseVisualStyleBackColor = False
        '
        'GEN_C3
        '
        Me.GEN_C3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C3.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C3.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C3.Location = New System.Drawing.Point(175, 17)
        Me.GEN_C3.Name = "GEN_C3"
        Me.GEN_C3.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C3.TabIndex = 5
        Me.GEN_C3.Text = "30代"
        Me.GEN_C3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C3.UseVisualStyleBackColor = False
        '
        'GEN_C2
        '
        Me.GEN_C2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C2.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C2.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C2.Location = New System.Drawing.Point(95, 17)
        Me.GEN_C2.Name = "GEN_C2"
        Me.GEN_C2.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C2.TabIndex = 4
        Me.GEN_C2.Text = "20代"
        Me.GEN_C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C2.UseVisualStyleBackColor = False
        '
        'GEN_C1
        '
        Me.GEN_C1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GEN_C1.Appearance = System.Windows.Forms.Appearance.Button
        Me.GEN_C1.BackColor = System.Drawing.Color.Wheat
        Me.GEN_C1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_C1.Location = New System.Drawing.Point(15, 17)
        Me.GEN_C1.Name = "GEN_C1"
        Me.GEN_C1.Size = New System.Drawing.Size(74, 49)
        Me.GEN_C1.TabIndex = 3
        Me.GEN_C1.Text = "子供"
        Me.GEN_C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GEN_C1.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.WEA_C4)
        Me.GroupBox3.Controls.Add(Me.WEA_C3)
        Me.GroupBox3.Controls.Add(Me.WEA_C2)
        Me.GroupBox3.Controls.Add(Me.WEA_C1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(266, 228)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(343, 72)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "天気"
        '
        'WEA_C4
        '
        Me.WEA_C4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WEA_C4.Appearance = System.Windows.Forms.Appearance.Button
        Me.WEA_C4.AutoCheck = False
        Me.WEA_C4.BackColor = System.Drawing.Color.Wheat
        Me.WEA_C4.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WEA_C4.Location = New System.Drawing.Point(255, 18)
        Me.WEA_C4.Name = "WEA_C4"
        Me.WEA_C4.Size = New System.Drawing.Size(74, 49)
        Me.WEA_C4.TabIndex = 13
        Me.WEA_C4.Text = "雪"
        Me.WEA_C4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WEA_C4.UseVisualStyleBackColor = False
        '
        'WEA_C3
        '
        Me.WEA_C3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WEA_C3.Appearance = System.Windows.Forms.Appearance.Button
        Me.WEA_C3.BackColor = System.Drawing.Color.Wheat
        Me.WEA_C3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WEA_C3.Location = New System.Drawing.Point(175, 18)
        Me.WEA_C3.Name = "WEA_C3"
        Me.WEA_C3.Size = New System.Drawing.Size(74, 49)
        Me.WEA_C3.TabIndex = 12
        Me.WEA_C3.Text = "曇り"
        Me.WEA_C3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WEA_C3.UseVisualStyleBackColor = False
        '
        'WEA_C2
        '
        Me.WEA_C2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WEA_C2.Appearance = System.Windows.Forms.Appearance.Button
        Me.WEA_C2.BackColor = System.Drawing.Color.Wheat
        Me.WEA_C2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WEA_C2.Location = New System.Drawing.Point(95, 18)
        Me.WEA_C2.Name = "WEA_C2"
        Me.WEA_C2.Size = New System.Drawing.Size(74, 49)
        Me.WEA_C2.TabIndex = 11
        Me.WEA_C2.Text = "雨"
        Me.WEA_C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WEA_C2.UseVisualStyleBackColor = False
        '
        'WEA_C1
        '
        Me.WEA_C1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WEA_C1.Appearance = System.Windows.Forms.Appearance.Button
        Me.WEA_C1.BackColor = System.Drawing.Color.Wheat
        Me.WEA_C1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WEA_C1.Location = New System.Drawing.Point(15, 18)
        Me.WEA_C1.Name = "WEA_C1"
        Me.WEA_C1.Size = New System.Drawing.Size(74, 49)
        Me.WEA_C1.TabIndex = 10
        Me.WEA_C1.Text = "晴れ"
        Me.WEA_C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WEA_C1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 392)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "担当者："
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(81, 386)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(116, 22)
        Me.STAFF_CODE_T.TabIndex = 12
        Me.STAFF_CODE_T.TabStop = False
        '
        'MEMBER_CODE_T
        '
        Me.MEMBER_CODE_T.BackColor = System.Drawing.Color.White
        Me.MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_CODE_T.Location = New System.Drawing.Point(107, 38)
        Me.MEMBER_CODE_T.MaxLength = 13
        Me.MEMBER_CODE_T.Name = "MEMBER_CODE_T"
        Me.MEMBER_CODE_T.Size = New System.Drawing.Size(178, 28)
        Me.MEMBER_CODE_T.TabIndex = 1
        Me.MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "会員コード："
        '
        'WEATHER_T
        '
        Me.WEATHER_T.BackColor = System.Drawing.Color.Tan
        Me.WEATHER_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WEATHER_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WEATHER_T.Location = New System.Drawing.Point(613, 278)
        Me.WEATHER_T.Name = "WEATHER_T"
        Me.WEATHER_T.ReadOnly = True
        Me.WEATHER_T.Size = New System.Drawing.Size(23, 22)
        Me.WEATHER_T.TabIndex = 19
        Me.WEATHER_T.TabStop = False
        Me.WEATHER_T.Visible = False
        '
        'MEMBER_NAME_T
        '
        Me.MEMBER_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.MEMBER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_NAME_T.Location = New System.Drawing.Point(105, 17)
        Me.MEMBER_NAME_T.Name = "MEMBER_NAME_T"
        Me.MEMBER_NAME_T.ReadOnly = True
        Me.MEMBER_NAME_T.Size = New System.Drawing.Size(178, 20)
        Me.MEMBER_NAME_T.TabIndex = 20
        Me.MEMBER_NAME_T.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "会員名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'POST_CODE_T
        '
        Me.POST_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.POST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POST_CODE_T.Location = New System.Drawing.Point(105, 59)
        Me.POST_CODE_T.Name = "POST_CODE_T"
        Me.POST_CODE_T.ReadOnly = True
        Me.POST_CODE_T.Size = New System.Drawing.Size(75, 20)
        Me.POST_CODE_T.TabIndex = 22
        Me.POST_CODE_T.TabStop = False
        Me.POST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "住所："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ADDRESS_T
        '
        Me.ADDRESS_T.BackColor = System.Drawing.Color.Wheat
        Me.ADDRESS_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS_T.Location = New System.Drawing.Point(183, 59)
        Me.ADDRESS_T.Name = "ADDRESS_T"
        Me.ADDRESS_T.ReadOnly = True
        Me.ADDRESS_T.Size = New System.Drawing.Size(317, 20)
        Me.ADDRESS_T.TabIndex = 24
        Me.ADDRESS_T.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "TEL："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TEL_T
        '
        Me.TEL_T.BackColor = System.Drawing.Color.Wheat
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.Location = New System.Drawing.Point(105, 80)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.ReadOnly = True
        Me.TEL_T.Size = New System.Drawing.Size(122, 20)
        Me.TEL_T.TabIndex = 26
        Me.TEL_T.TabStop = False
        Me.TEL_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FAX_T
        '
        Me.FAX_T.BackColor = System.Drawing.Color.Wheat
        Me.FAX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FAX_T.Location = New System.Drawing.Point(267, 81)
        Me.FAX_T.Name = "FAX_T"
        Me.FAX_T.ReadOnly = True
        Me.FAX_T.Size = New System.Drawing.Size(122, 20)
        Me.FAX_T.TabIndex = 28
        Me.FAX_T.TabStop = False
        Me.FAX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(231, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "FAX："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'E_MAIL_T
        '
        Me.E_MAIL_T.BackColor = System.Drawing.Color.Wheat
        Me.E_MAIL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.E_MAIL_T.Location = New System.Drawing.Point(105, 101)
        Me.E_MAIL_T.Name = "E_MAIL_T"
        Me.E_MAIL_T.ReadOnly = True
        Me.E_MAIL_T.Size = New System.Drawing.Size(178, 20)
        Me.E_MAIL_T.TabIndex = 30
        Me.E_MAIL_T.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(57, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "E-Mail："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SEX_T
        '
        Me.SEX_T.BackColor = System.Drawing.Color.Wheat
        Me.SEX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEX_T.Location = New System.Drawing.Point(327, 17)
        Me.SEX_T.Name = "SEX_T"
        Me.SEX_T.ReadOnly = True
        Me.SEX_T.Size = New System.Drawing.Size(30, 20)
        Me.SEX_T.TabIndex = 32
        Me.SEX_T.TabStop = False
        Me.SEX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(288, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "性別："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GEN_T
        '
        Me.GEN_T.BackColor = System.Drawing.Color.Wheat
        Me.GEN_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GEN_T.Location = New System.Drawing.Point(402, 17)
        Me.GEN_T.Name = "GEN_T"
        Me.GEN_T.ReadOnly = True
        Me.GEN_T.Size = New System.Drawing.Size(30, 20)
        Me.GEN_T.TabIndex = 34
        Me.GEN_T.TabStop = False
        Me.GEN_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(363, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "年齢："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ENTRY_DATE_T
        '
        Me.ENTRY_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.ENTRY_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ENTRY_DATE_T.Location = New System.Drawing.Point(105, 38)
        Me.ENTRY_DATE_T.Name = "ENTRY_DATE_T"
        Me.ENTRY_DATE_T.ReadOnly = True
        Me.ENTRY_DATE_T.Size = New System.Drawing.Size(89, 20)
        Me.ENTRY_DATE_T.TabIndex = 36
        Me.ENTRY_DATE_T.TabStop = False
        Me.ENTRY_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(53, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "入会日："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(200, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "契約期間："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'REG_S_DATE
        '
        Me.REG_S_DATE.BackColor = System.Drawing.Color.Wheat
        Me.REG_S_DATE.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REG_S_DATE.Location = New System.Drawing.Point(264, 38)
        Me.REG_S_DATE.Name = "REG_S_DATE"
        Me.REG_S_DATE.ReadOnly = True
        Me.REG_S_DATE.Size = New System.Drawing.Size(92, 20)
        Me.REG_S_DATE.TabIndex = 38
        Me.REG_S_DATE.TabStop = False
        Me.REG_S_DATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(361, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "～"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'REG_E_DATE
        '
        Me.REG_E_DATE.BackColor = System.Drawing.Color.Wheat
        Me.REG_E_DATE.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REG_E_DATE.Location = New System.Drawing.Point(381, 38)
        Me.REG_E_DATE.Name = "REG_E_DATE"
        Me.REG_E_DATE.ReadOnly = True
        Me.REG_E_DATE.Size = New System.Drawing.Size(92, 20)
        Me.REG_E_DATE.TabIndex = 40
        Me.REG_E_DATE.TabStop = False
        Me.REG_E_DATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RESIGN_DATE_T)
        Me.GroupBox4.Controls.Add(Me.REG_E_DATE)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.REG_S_DATE)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.ENTRY_DATE_T)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.GEN_T)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.SEX_T)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.E_MAIL_T)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.FAX_T)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.TEL_T)
        Me.GroupBox4.Controls.Add(Me.ADDRESS_T)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.POST_CODE_T)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.MEMBER_NAME_T)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(581, 140)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "【会員情報】"
        '
        'RESIGN_DATE_T
        '
        Me.RESIGN_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.RESIGN_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RESIGN_DATE_T.Location = New System.Drawing.Point(353, 102)
        Me.RESIGN_DATE_T.Name = "RESIGN_DATE_T"
        Me.RESIGN_DATE_T.ReadOnly = True
        Me.RESIGN_DATE_T.Size = New System.Drawing.Size(92, 20)
        Me.RESIGN_DATE_T.TabIndex = 43
        Me.RESIGN_DATE_T.TabStop = False
        Me.RESIGN_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(303, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "退会日："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MEMBER_SEARCH_B
        '
        Me.MEMBER_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_SEARCH_B.Location = New System.Drawing.Point(297, 29)
        Me.MEMBER_SEARCH_B.Name = "MEMBER_SEARCH_B"
        Me.MEMBER_SEARCH_B.Size = New System.Drawing.Size(100, 47)
        Me.MEMBER_SEARCH_B.TabIndex = 2
        Me.MEMBER_SEARCH_B.TextButton = "会員検索"
        '
        'MEMBER_INS_B
        '
        Me.MEMBER_INS_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_INS_B.Location = New System.Drawing.Point(403, 29)
        Me.MEMBER_INS_B.Name = "MEMBER_INS_B"
        Me.MEMBER_INS_B.Size = New System.Drawing.Size(100, 47)
        Me.MEMBER_INS_B.TabIndex = 6
        Me.MEMBER_INS_B.TextButton = "会員情報登録"
        '
        'MEMBER_EDIT_B
        '
        Me.MEMBER_EDIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_EDIT_B.Location = New System.Drawing.Point(509, 29)
        Me.MEMBER_EDIT_B.Name = "MEMBER_EDIT_B"
        Me.MEMBER_EDIT_B.Size = New System.Drawing.Size(100, 47)
        Me.MEMBER_EDIT_B.TabIndex = 7
        Me.MEMBER_EDIT_B.TextButton = "会員情報更新"
        '
        'DROWER_B
        '
        Me.DROWER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DROWER_B.Location = New System.Drawing.Point(304, 386)
        Me.DROWER_B.Name = "DROWER_B"
        Me.DROWER_B.Size = New System.Drawing.Size(98, 47)
        Me.DROWER_B.TabIndex = 9
        Me.DROWER_B.TextButton = "ドロワーオープン"
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.QUIT_B.Location = New System.Drawing.Point(408, 386)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(98, 47)
        Me.QUIT_B.TabIndex = 8
        Me.QUIT_B.TextButton = "戻　る"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(512, 386)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 47)
        Me.COMMIT_B.TabIndex = 5
        Me.COMMIT_B.TextButton = "決　定"
        '
        'fCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(639, 456)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.DROWER_B)
        Me.Controls.Add(Me.MEMBER_EDIT_B)
        Me.Controls.Add(Me.MEMBER_INS_B)
        Me.Controls.Add(Me.MEMBER_SEARCH_B)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.WEATHER_T)
        Me.Controls.Add(Me.MEMBER_CODE_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "顧客属性入力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SEX_C1 As System.Windows.Forms.CheckBox
    Friend WithEvents SEX_C2 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GEN_C6 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C5 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C4 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C3 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C2 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C1 As System.Windows.Forms.CheckBox
    Friend WithEvents GEN_C7 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents WEA_C4 As System.Windows.Forms.CheckBox
    Friend WithEvents WEA_C3 As System.Windows.Forms.CheckBox
    Friend WithEvents WEA_C2 As System.Windows.Forms.CheckBox
    Friend WithEvents WEA_C1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WEATHER_T As System.Windows.Forms.TextBox
    Friend WithEvents MEMBER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents POST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ADDRESS_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents FAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents E_MAIL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SEX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GEN_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ENTRY_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents REG_S_DATE As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents REG_E_DATE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents MEMBER_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_INS_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_EDIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents DROWER_B As Softgroup.NetButton.NetButton
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RESIGN_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
