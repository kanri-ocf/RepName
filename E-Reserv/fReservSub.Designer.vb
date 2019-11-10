<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReservSub
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.START_HOUR_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.START_MIN_T = New System.Windows.Forms.TextBox
        Me.END_MIN_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.END_HOUR_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.MEMBER_SERCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.FAX_T = New System.Windows.Forms.TextBox
        Me.TEL_T = New System.Windows.Forms.TextBox
        Me.MEMO3_T = New System.Windows.Forms.RichTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.MEMO2_T = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.MEMO1_T = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.AGE_T = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.MAIL_T = New System.Windows.Forms.TextBox
        Me.BIRTHDAY_T = New System.Windows.Forms.MaskedTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SEX_F_R = New System.Windows.Forms.RadioButton
        Me.SEX_M_R = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ADDR3_T = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ADDR2_T = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.ADDR1_T = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.POST_CODE_T = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.NAME_T = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQ_DATE_FROM_T = New System.Windows.Forms.MaskedTextBox
        Me.S_STAFF_NAME_C = New System.Windows.Forms.ComboBox
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.S_STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.REQ_CODE_T = New System.Windows.Forms.TextBox
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.BUMON_CODE_T = New System.Windows.Forms.TextBox
        Me.ROOM_CODE_T = New System.Windows.Forms.TextBox
        Me.BUMON_NAME_T = New System.Windows.Forms.TextBox
        Me.ROOM_NAME_T = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.REQ_DATE_TO_T = New System.Windows.Forms.MaskedTextBox
        Me.RESERV_CARD_PRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(68, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "予約日："
        '
        'REQUEST_DATE_T
        '
        Me.REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_DATE_T.Location = New System.Drawing.Point(138, 17)
        Me.REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.REQUEST_DATE_T.Name = "REQUEST_DATE_T"
        Me.REQUEST_DATE_T.Size = New System.Drawing.Size(100, 23)
        Me.REQUEST_DATE_T.TabIndex = 1
        Me.REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(53, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "予約時間："
        '
        'START_HOUR_T
        '
        Me.START_HOUR_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.START_HOUR_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.START_HOUR_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.START_HOUR_T.Location = New System.Drawing.Point(131, 57)
        Me.START_HOUR_T.Name = "START_HOUR_T"
        Me.START_HOUR_T.Size = New System.Drawing.Size(38, 22)
        Me.START_HOUR_T.TabIndex = 2
        Me.START_HOUR_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(170, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "："
        '
        'START_MIN_T
        '
        Me.START_MIN_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.START_MIN_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.START_MIN_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.START_MIN_T.Location = New System.Drawing.Point(185, 57)
        Me.START_MIN_T.Name = "START_MIN_T"
        Me.START_MIN_T.Size = New System.Drawing.Size(38, 22)
        Me.START_MIN_T.TabIndex = 3
        Me.START_MIN_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'END_MIN_T
        '
        Me.END_MIN_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.END_MIN_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.END_MIN_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.END_MIN_T.Location = New System.Drawing.Point(301, 57)
        Me.END_MIN_T.Name = "END_MIN_T"
        Me.END_MIN_T.Size = New System.Drawing.Size(38, 22)
        Me.END_MIN_T.TabIndex = 5
        Me.END_MIN_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(286, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "："
        '
        'END_HOUR_T
        '
        Me.END_HOUR_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.END_HOUR_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.END_HOUR_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.END_HOUR_T.Location = New System.Drawing.Point(247, 57)
        Me.END_HOUR_T.Name = "END_HOUR_T"
        Me.END_HOUR_T.Size = New System.Drawing.Size(38, 22)
        Me.END_HOUR_T.TabIndex = 4
        Me.END_HOUR_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(226, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "～"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(399, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "サービス部門："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(384, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "サービス担当者："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MEMBER_SERCH_B)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.FAX_T)
        Me.GroupBox2.Controls.Add(Me.TEL_T)
        Me.GroupBox2.Controls.Add(Me.MEMO3_T)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.MEMO2_T)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.MEMO1_T)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.AGE_T)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.MAIL_T)
        Me.GroupBox2.Controls.Add(Me.BIRTHDAY_T)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.ADDR3_T)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ADDR2_T)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.ADDR1_T)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.POST_CODE_T)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.NAME_T)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.MEMBER_CODE_T)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(732, 281)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'MEMBER_SERCH_B
        '
        Me.MEMBER_SERCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_SERCH_B.Location = New System.Drawing.Point(265, 14)
        Me.MEMBER_SERCH_B.Name = "MEMBER_SERCH_B"
        Me.MEMBER_SERCH_B.Size = New System.Drawing.Size(110, 41)
        Me.MEMBER_SERCH_B.TabIndex = 100
        Me.MEMBER_SERCH_B.TextButton = "会員検索"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(273, 227)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 13)
        Me.Label27.TabIndex = 99
        Me.Label27.Text = "(例：048-0001-0001)"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(273, 198)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(126, 13)
        Me.Label26.TabIndex = 98
        Me.Label26.Text = "(例：048-0001-0001)"
        '
        'FAX_T
        '
        Me.FAX_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FAX_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.FAX_T.Location = New System.Drawing.Point(118, 221)
        Me.FAX_T.MaxLength = 50
        Me.FAX_T.Name = "FAX_T"
        Me.FAX_T.Size = New System.Drawing.Size(154, 22)
        Me.FAX_T.TabIndex = 97
        '
        'TEL_T
        '
        Me.TEL_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TEL_T.Location = New System.Drawing.Point(118, 194)
        Me.TEL_T.MaxLength = 13
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.Size = New System.Drawing.Size(154, 22)
        Me.TEL_T.TabIndex = 96
        '
        'MEMO3_T
        '
        Me.MEMO3_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO3_T.Location = New System.Drawing.Point(467, 175)
        Me.MEMO3_T.MaxLength = 256
        Me.MEMO3_T.Name = "MEMO3_T"
        Me.MEMO3_T.Size = New System.Drawing.Size(244, 96)
        Me.MEMO3_T.TabIndex = 95
        Me.MEMO3_T.Text = ""
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(413, 178)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 15)
        Me.Label25.TabIndex = 94
        Me.Label25.Text = "備考3："
        '
        'MEMO2_T
        '
        Me.MEMO2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO2_T.Location = New System.Drawing.Point(467, 139)
        Me.MEMO2_T.MaxLength = 40
        Me.MEMO2_T.Name = "MEMO2_T"
        Me.MEMO2_T.Size = New System.Drawing.Size(244, 22)
        Me.MEMO2_T.TabIndex = 92
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(412, 143)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 15)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "備考2："
        '
        'MEMO1_T
        '
        Me.MEMO1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO1_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO1_T.Location = New System.Drawing.Point(467, 110)
        Me.MEMO1_T.MaxLength = 40
        Me.MEMO1_T.Name = "MEMO1_T"
        Me.MEMO1_T.Size = New System.Drawing.Size(244, 22)
        Me.MEMO1_T.TabIndex = 90
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(411, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 15)
        Me.Label23.TabIndex = 91
        Me.Label23.Text = "備考1："
        '
        'AGE_T
        '
        Me.AGE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AGE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.AGE_T.Location = New System.Drawing.Point(467, 81)
        Me.AGE_T.Name = "AGE_T"
        Me.AGE_T.Size = New System.Drawing.Size(45, 22)
        Me.AGE_T.TabIndex = 81
        Me.AGE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(419, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 15)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "年齢："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(44, 225)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 15)
        Me.Label19.TabIndex = 78
        Me.Label19.Text = "FAX番号："
        '
        'MAIL_T
        '
        Me.MAIL_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MAIL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MAIL_T.Location = New System.Drawing.Point(118, 248)
        Me.MAIL_T.MaxLength = 50
        Me.MAIL_T.Name = "MAIL_T"
        Me.MAIL_T.Size = New System.Drawing.Size(247, 22)
        Me.MAIL_T.TabIndex = 9
        '
        'BIRTHDAY_T
        '
        Me.BIRTHDAY_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BIRTHDAY_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BIRTHDAY_T.Location = New System.Drawing.Point(467, 52)
        Me.BIRTHDAY_T.Mask = "0000 / 00 / 00"
        Me.BIRTHDAY_T.Name = "BIRTHDAY_T"
        Me.BIRTHDAY_T.Size = New System.Drawing.Size(138, 22)
        Me.BIRTHDAY_T.TabIndex = 11
        Me.BIRTHDAY_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(389, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 15)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "生年月日："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SEX_F_R)
        Me.GroupBox1.Controls.Add(Me.SEX_M_R)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(467, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 34)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'SEX_F_R
        '
        Me.SEX_F_R.AutoSize = True
        Me.SEX_F_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEX_F_R.ForeColor = System.Drawing.Color.Black
        Me.SEX_F_R.Location = New System.Drawing.Point(51, 10)
        Me.SEX_F_R.Name = "SEX_F_R"
        Me.SEX_F_R.Size = New System.Drawing.Size(38, 17)
        Me.SEX_F_R.TabIndex = 1
        Me.SEX_F_R.TabStop = True
        Me.SEX_F_R.Text = "♀"
        Me.SEX_F_R.UseVisualStyleBackColor = True
        '
        'SEX_M_R
        '
        Me.SEX_M_R.AutoSize = True
        Me.SEX_M_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEX_M_R.ForeColor = System.Drawing.Color.Black
        Me.SEX_M_R.Location = New System.Drawing.Point(7, 11)
        Me.SEX_M_R.Name = "SEX_M_R"
        Me.SEX_M_R.Size = New System.Drawing.Size(38, 17)
        Me.SEX_M_R.TabIndex = 0
        Me.SEX_M_R.TabStop = True
        Me.SEX_M_R.Text = "♂"
        Me.SEX_M_R.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(419, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 15)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "性別："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(60, 252)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 15)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "E-Mail："
        '
        'ADDR3_T
        '
        Me.ADDR3_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDR3_T.Location = New System.Drawing.Point(118, 167)
        Me.ADDR3_T.MaxLength = 50
        Me.ADDR3_T.Name = "ADDR3_T"
        Me.ADDR3_T.Size = New System.Drawing.Size(257, 22)
        Me.ADDR3_T.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(62, 171)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 15)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "住所3："
        '
        'ADDR2_T
        '
        Me.ADDR2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDR2_T.Location = New System.Drawing.Point(118, 140)
        Me.ADDR2_T.MaxLength = 50
        Me.ADDR2_T.Name = "ADDR2_T"
        Me.ADDR2_T.Size = New System.Drawing.Size(257, 22)
        Me.ADDR2_T.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(62, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 15)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "住所2："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(40, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "電話番号："
        '
        'ADDR1_T
        '
        Me.ADDR1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR1_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDR1_T.Location = New System.Drawing.Point(118, 113)
        Me.ADDR1_T.MaxLength = 50
        Me.ADDR1_T.Name = "ADDR1_T"
        Me.ADDR1_T.Size = New System.Drawing.Size(257, 22)
        Me.ADDR1_T.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(62, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 15)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "住所1："
        '
        'POST_CODE_T
        '
        Me.POST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.POST_CODE_T.Location = New System.Drawing.Point(118, 87)
        Me.POST_CODE_T.Mask = "000-0000"
        Me.POST_CODE_T.Name = "POST_CODE_T"
        Me.POST_CODE_T.Size = New System.Drawing.Size(92, 22)
        Me.POST_CODE_T.TabIndex = 3
        Me.POST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(40, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "郵便番号："
        '
        'NAME_T
        '
        Me.NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.NAME_T.Location = New System.Drawing.Point(118, 61)
        Me.NAME_T.MaxLength = 20
        Me.NAME_T.Name = "NAME_T"
        Me.NAME_T.Size = New System.Drawing.Size(257, 22)
        Me.NAME_T.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(70, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "名称："
        '
        'MEMBER_CODE_T
        '
        Me.MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MEMBER_CODE_T.Location = New System.Drawing.Point(118, 23)
        Me.MEMBER_CODE_T.Name = "MEMBER_CODE_T"
        Me.MEMBER_CODE_T.Size = New System.Drawing.Size(138, 23)
        Me.MEMBER_CODE_T.TabIndex = 1
        Me.MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(37, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "会員コード："
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELETE_B.Location = New System.Drawing.Point(540, 418)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(100, 40)
        Me.DELETE_B.TabIndex = 10
        Me.DELETE_B.TextButton = "削除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(645, 418)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(100, 40)
        Me.COMMIT_B.TabIndex = 11
        Me.COMMIT_B.TextButton = "登録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(434, 418)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(100, 40)
        Me.RETURN_B.TabIndex = 9
        Me.RETURN_B.TextButton = "戻る"
        '
        'REQ_DATE_FROM_T
        '
        Me.REQ_DATE_FROM_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.REQ_DATE_FROM_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQ_DATE_FROM_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQ_DATE_FROM_T.Location = New System.Drawing.Point(131, 27)
        Me.REQ_DATE_FROM_T.Mask = "0000 / 00 / 00"
        Me.REQ_DATE_FROM_T.Name = "REQ_DATE_FROM_T"
        Me.REQ_DATE_FROM_T.Size = New System.Drawing.Size(138, 22)
        Me.REQ_DATE_FROM_T.TabIndex = 1
        Me.REQ_DATE_FROM_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'S_STAFF_NAME_C
        '
        Me.S_STAFF_NAME_C.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.S_STAFF_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_STAFF_NAME_C.FormattingEnabled = True
        Me.S_STAFF_NAME_C.Location = New System.Drawing.Point(492, 84)
        Me.S_STAFF_NAME_C.Name = "S_STAFF_NAME_C"
        Me.S_STAFF_NAME_C.Size = New System.Drawing.Size(205, 23)
        Me.S_STAFF_NAME_C.TabIndex = 7
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(78, 436)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 76
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(78, 412)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 74
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Tan
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(11, 412)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 18)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "担当者："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'S_STAFF_CODE_T
        '
        Me.S_STAFF_CODE_T.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.S_STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_STAFF_CODE_T.Location = New System.Drawing.Point(659, 86)
        Me.S_STAFF_CODE_T.Name = "S_STAFF_CODE_T"
        Me.S_STAFF_CODE_T.Size = New System.Drawing.Size(19, 22)
        Me.S_STAFF_CODE_T.TabIndex = 79
        Me.S_STAFF_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.S_STAFF_CODE_T.Visible = False
        '
        'REQ_CODE_T
        '
        Me.REQ_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQ_CODE_T.Location = New System.Drawing.Point(15, 406)
        Me.REQ_CODE_T.Name = "REQ_CODE_T"
        Me.REQ_CODE_T.Size = New System.Drawing.Size(27, 23)
        Me.REQ_CODE_T.TabIndex = 80
        Me.REQ_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.REQ_CODE_T.Visible = False
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(44, 407)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(27, 23)
        Me.CHANNEL_CODE_T.TabIndex = 81
        Me.CHANNEL_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CHANNEL_CODE_T.Visible = False
        '
        'BUMON_CODE_T
        '
        Me.BUMON_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_CODE_T.Location = New System.Drawing.Point(102, 407)
        Me.BUMON_CODE_T.Name = "BUMON_CODE_T"
        Me.BUMON_CODE_T.Size = New System.Drawing.Size(27, 23)
        Me.BUMON_CODE_T.TabIndex = 83
        Me.BUMON_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BUMON_CODE_T.Visible = False
        '
        'ROOM_CODE_T
        '
        Me.ROOM_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROOM_CODE_T.Location = New System.Drawing.Point(73, 407)
        Me.ROOM_CODE_T.Name = "ROOM_CODE_T"
        Me.ROOM_CODE_T.Size = New System.Drawing.Size(27, 23)
        Me.ROOM_CODE_T.TabIndex = 82
        Me.ROOM_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ROOM_CODE_T.Visible = False
        '
        'BUMON_NAME_T
        '
        Me.BUMON_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BUMON_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_NAME_T.Location = New System.Drawing.Point(492, 55)
        Me.BUMON_NAME_T.Name = "BUMON_NAME_T"
        Me.BUMON_NAME_T.Size = New System.Drawing.Size(195, 22)
        Me.BUMON_NAME_T.TabIndex = 84
        '
        'ROOM_NAME_T
        '
        Me.ROOM_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ROOM_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROOM_NAME_T.Location = New System.Drawing.Point(131, 86)
        Me.ROOM_NAME_T.Name = "ROOM_NAME_T"
        Me.ROOM_NAME_T.Size = New System.Drawing.Size(195, 22)
        Me.ROOM_NAME_T.TabIndex = 86
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(47, 90)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 15)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "ルーム名称："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(275, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 15)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "～"
        '
        'REQ_DATE_TO_T
        '
        Me.REQ_DATE_TO_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.REQ_DATE_TO_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQ_DATE_TO_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQ_DATE_TO_T.Location = New System.Drawing.Point(304, 27)
        Me.REQ_DATE_TO_T.Mask = "0000 / 00 / 00"
        Me.REQ_DATE_TO_T.Name = "REQ_DATE_TO_T"
        Me.REQ_DATE_TO_T.Size = New System.Drawing.Size(138, 22)
        Me.REQ_DATE_TO_T.TabIndex = 88
        Me.REQ_DATE_TO_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RESERV_CARD_PRINT_B
        '
        Me.RESERV_CARD_PRINT_B.ColorBottom = System.Drawing.Color.Tan
        Me.RESERV_CARD_PRINT_B.Location = New System.Drawing.Point(289, 418)
        Me.RESERV_CARD_PRINT_B.Name = "RESERV_CARD_PRINT_B"
        Me.RESERV_CARD_PRINT_B.Size = New System.Drawing.Size(123, 40)
        Me.RESERV_CARD_PRINT_B.TabIndex = 89
        Me.RESERV_CARD_PRINT_B.TextButton = "予約伝票発行"
        '
        'fReservSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(757, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.RESERV_CARD_PRINT_B)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.REQ_DATE_TO_T)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ROOM_NAME_T)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.BUMON_NAME_T)
        Me.Controls.Add(Me.BUMON_CODE_T)
        Me.Controls.Add(Me.ROOM_CODE_T)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.REQ_CODE_T)
        Me.Controls.Add(Me.S_STAFF_CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.S_STAFF_NAME_C)
        Me.Controls.Add(Me.REQ_DATE_FROM_T)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.END_MIN_T)
        Me.Controls.Add(Me.END_HOUR_T)
        Me.Controls.Add(Me.START_MIN_T)
        Me.Controls.Add(Me.START_HOUR_T)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fReservSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "予約詳細入力"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents START_HOUR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents START_MIN_T As System.Windows.Forms.TextBox
    Friend WithEvents END_MIN_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents END_HOUR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents NetButton1 As Softgroup.NetButton.NetButton
    Friend WithEvents NetButton2 As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MAIL_T As System.Windows.Forms.TextBox
    Friend WithEvents BIRTHDAY_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SEX_F_R As System.Windows.Forms.RadioButton
    Friend WithEvents SEX_M_R As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ADDR3_T As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ADDR2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ADDR1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents POST_CODE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQ_DATE_FROM_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents S_STAFF_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents S_STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents AGE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents REQ_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents ROOM_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents ROOM_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents REQ_DATE_TO_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RESERV_CARD_PRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents MEMO2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents MEMO1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents MEMO3_T As System.Windows.Forms.RichTextBox
    Friend WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents FAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents MEMBER_SERCH_B As Softgroup.NetButton.NetButton
End Class
