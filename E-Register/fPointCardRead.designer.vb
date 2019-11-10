<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointCardRead
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
        Me.POINT_MEMBER_NAME_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.POST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ADDRESS_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TEL_T = New System.Windows.Forms.TextBox
        Me.FAX_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.E_MAIL_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SEX_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GEN_T = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ENTRY_DATE_T = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.REG_S_DATE = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.REG_E_DATE = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POINT_MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.POINT_MEMBER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'POINT_MEMBER_NAME_T
        '
        Me.POINT_MEMBER_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.POINT_MEMBER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_MEMBER_NAME_T.Location = New System.Drawing.Point(147, 22)
        Me.POINT_MEMBER_NAME_T.Name = "POINT_MEMBER_NAME_T"
        Me.POINT_MEMBER_NAME_T.ReadOnly = True
        Me.POINT_MEMBER_NAME_T.Size = New System.Drawing.Size(178, 20)
        Me.POINT_MEMBER_NAME_T.TabIndex = 20
        Me.POINT_MEMBER_NAME_T.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 26)
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
        Me.POST_CODE_T.Location = New System.Drawing.Point(147, 64)
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
        Me.Label4.Location = New System.Drawing.Point(108, 68)
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
        Me.ADDRESS_T.Location = New System.Drawing.Point(225, 64)
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
        Me.Label5.Location = New System.Drawing.Point(112, 89)
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
        Me.TEL_T.Location = New System.Drawing.Point(147, 85)
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
        Me.FAX_T.Location = New System.Drawing.Point(309, 86)
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
        Me.Label6.Location = New System.Drawing.Point(273, 90)
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
        Me.E_MAIL_T.Location = New System.Drawing.Point(147, 106)
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
        Me.Label7.Location = New System.Drawing.Point(99, 110)
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
        Me.SEX_T.Location = New System.Drawing.Point(369, 22)
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
        Me.Label8.Location = New System.Drawing.Point(330, 26)
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
        Me.GEN_T.Location = New System.Drawing.Point(444, 22)
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
        Me.Label9.Location = New System.Drawing.Point(405, 26)
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
        Me.ENTRY_DATE_T.Location = New System.Drawing.Point(147, 43)
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
        Me.Label10.Location = New System.Drawing.Point(95, 46)
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
        Me.Label11.Location = New System.Drawing.Point(244, 47)
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
        Me.REG_S_DATE.Location = New System.Drawing.Point(306, 43)
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
        Me.Label12.Location = New System.Drawing.Point(403, 46)
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
        Me.REG_E_DATE.Location = New System.Drawing.Point(423, 43)
        Me.REG_E_DATE.Name = "REG_E_DATE"
        Me.REG_E_DATE.ReadOnly = True
        Me.REG_E_DATE.Size = New System.Drawing.Size(92, 20)
        Me.REG_E_DATE.TabIndex = 40
        Me.REG_E_DATE.TabStop = False
        Me.REG_E_DATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.REG_E_DATE)
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
        Me.GroupBox4.Controls.Add(Me.POINT_MEMBER_NAME_T)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 80)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(581, 144)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "【会員情報】"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "ポイント会員コード："
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.QUIT_B.Location = New System.Drawing.Point(407, 240)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(98, 47)
        Me.QUIT_B.TabIndex = 3
        Me.QUIT_B.TextButton = "戻　る"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(511, 240)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 47)
        Me.COMMIT_B.TabIndex = 4
        Me.COMMIT_B.TextButton = "決　定"
        '
        'POINT_MEMBER_CODE_T
        '
        Me.POINT_MEMBER_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.POINT_MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_MEMBER_CODE_T.Location = New System.Drawing.Point(200, 21)
        Me.POINT_MEMBER_CODE_T.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.POINT_MEMBER_CODE_T.Name = "POINT_MEMBER_CODE_T"
        Me.POINT_MEMBER_CODE_T.Size = New System.Drawing.Size(244, 31)
        Me.POINT_MEMBER_CODE_T.TabIndex = 1
        Me.POINT_MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'POINT_MEMBER_SEARCH_B
        '
        Me.POINT_MEMBER_SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.POINT_MEMBER_SEARCH_B.Location = New System.Drawing.Point(461, 12)
        Me.POINT_MEMBER_SEARCH_B.Name = "POINT_MEMBER_SEARCH_B"
        Me.POINT_MEMBER_SEARCH_B.Size = New System.Drawing.Size(122, 53)
        Me.POINT_MEMBER_SEARCH_B.TabIndex = 2
        Me.POINT_MEMBER_SEARCH_B.TextButton = "ポイント会員検索"
        '
        'fPointCardRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(639, 310)
        Me.Controls.Add(Me.POINT_MEMBER_SEARCH_B)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.POINT_MEMBER_CODE_T)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPointCardRead"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ポイントカード読込"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents POINT_MEMBER_NAME_T As System.Windows.Forms.TextBox
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
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents POINT_MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents POINT_MEMBER_SEARCH_B As Softgroup.NetButton.NetButton
End Class
