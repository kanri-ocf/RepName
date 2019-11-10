<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fBumonMstSub
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BUMON_CODE_T = New System.Windows.Forms.TextBox()
        Me.BUMON_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BUMON_SHORT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.BUMON_CLASS_G = New System.Windows.Forms.GroupBox()
        Me.SERVICE_R = New System.Windows.Forms.RadioButton()
        Me.PRODUCT_R = New System.Windows.Forms.RadioButton()
        Me.LINK_JAN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TIME_R = New System.Windows.Forms.RadioButton()
        Me.DAY_R = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RESERV_YES_R = New System.Windows.Forms.RadioButton()
        Me.RESERV_NO_R = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TAX_CLASS_NAME_T = New System.Windows.Forms.TextBox()
        Me.TAX_CLASS_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TAX_CLASS_CODE_T = New System.Windows.Forms.TextBox()
        Me.BUMON_CLASS_G.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(21, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "部門コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BUMON_CODE_T
        '
        Me.BUMON_CODE_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.BUMON_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BUMON_CODE_T.Location = New System.Drawing.Point(111, 45)
        Me.BUMON_CODE_T.MaxLength = 13
        Me.BUMON_CODE_T.Name = "BUMON_CODE_T"
        Me.BUMON_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.BUMON_CODE_T.TabIndex = 1
        Me.BUMON_CODE_T.TabStop = False
        '
        'BUMON_NAME_T
        '
        Me.BUMON_NAME_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.BUMON_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BUMON_NAME_T.Location = New System.Drawing.Point(111, 103)
        Me.BUMON_NAME_T.MaxLength = 30
        Me.BUMON_NAME_T.Name = "BUMON_NAME_T"
        Me.BUMON_NAME_T.Size = New System.Drawing.Size(398, 20)
        Me.BUMON_NAME_T.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "部門名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "部門種別"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BUMON_SHORT_NAME_T
        '
        Me.BUMON_SHORT_NAME_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.BUMON_SHORT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_SHORT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BUMON_SHORT_NAME_T.Location = New System.Drawing.Point(111, 129)
        Me.BUMON_SHORT_NAME_T.Name = "BUMON_SHORT_NAME_T"
        Me.BUMON_SHORT_NAME_T.Size = New System.Drawing.Size(221, 20)
        Me.BUMON_SHORT_NAME_T.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "部門略称"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(12, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(497, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "新規"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BUMON_CLASS_G
        '
        Me.BUMON_CLASS_G.Controls.Add(Me.SERVICE_R)
        Me.BUMON_CLASS_G.Controls.Add(Me.PRODUCT_R)
        Me.BUMON_CLASS_G.Location = New System.Drawing.Point(111, 68)
        Me.BUMON_CLASS_G.Name = "BUMON_CLASS_G"
        Me.BUMON_CLASS_G.Size = New System.Drawing.Size(157, 30)
        Me.BUMON_CLASS_G.TabIndex = 3
        Me.BUMON_CLASS_G.TabStop = False
        '
        'SERVICE_R
        '
        Me.SERVICE_R.AutoSize = True
        Me.SERVICE_R.Location = New System.Drawing.Point(79, 10)
        Me.SERVICE_R.Name = "SERVICE_R"
        Me.SERVICE_R.Size = New System.Drawing.Size(60, 16)
        Me.SERVICE_R.TabIndex = 2
        Me.SERVICE_R.Text = "サービス"
        Me.SERVICE_R.UseVisualStyleBackColor = True
        '
        'PRODUCT_R
        '
        Me.PRODUCT_R.AutoSize = True
        Me.PRODUCT_R.Checked = True
        Me.PRODUCT_R.Location = New System.Drawing.Point(16, 10)
        Me.PRODUCT_R.Name = "PRODUCT_R"
        Me.PRODUCT_R.Size = New System.Drawing.Size(47, 16)
        Me.PRODUCT_R.TabIndex = 1
        Me.PRODUCT_R.TabStop = True
        Me.PRODUCT_R.Text = "物販"
        Me.PRODUCT_R.UseVisualStyleBackColor = True
        '
        'LINK_JAN_B
        '
        Me.LINK_JAN_B.ColorBottom = System.Drawing.Color.Tan
        Me.LINK_JAN_B.Location = New System.Drawing.Point(263, 39)
        Me.LINK_JAN_B.Name = "LINK_JAN_B"
        Me.LINK_JAN_B.Size = New System.Drawing.Size(142, 30)
        Me.LINK_JAN_B.TabIndex = 2
        Me.LINK_JAN_B.TextButton = "商品連携用コード発番"
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELETE_B.Location = New System.Drawing.Point(203, 242)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(98, 41)
        Me.DELETE_B.TabIndex = 11
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(307, 242)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 41)
        Me.COMMIT_B.TabIndex = 12
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(411, 242)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 41)
        Me.RETURN_B.TabIndex = 13
        Me.RETURN_B.TextButton = "戻　る"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TIME_R)
        Me.GroupBox1.Controls.Add(Me.DAY_R)
        Me.GroupBox1.Location = New System.Drawing.Point(332, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 30)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'TIME_R
        '
        Me.TIME_R.AutoSize = True
        Me.TIME_R.Location = New System.Drawing.Point(65, 10)
        Me.TIME_R.Name = "TIME_R"
        Me.TIME_R.Size = New System.Drawing.Size(47, 16)
        Me.TIME_R.TabIndex = 2
        Me.TIME_R.Text = "時間"
        Me.TIME_R.UseVisualStyleBackColor = True
        '
        'DAY_R
        '
        Me.DAY_R.AutoSize = True
        Me.DAY_R.Checked = True
        Me.DAY_R.Location = New System.Drawing.Point(16, 10)
        Me.DAY_R.Name = "DAY_R"
        Me.DAY_R.Size = New System.Drawing.Size(35, 16)
        Me.DAY_R.TabIndex = 1
        Me.DAY_R.TabStop = True
        Me.DAY_R.Text = "日"
        Me.DAY_R.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(242, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Tag = ""
        Me.Label1.Text = "予約単位"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RESERV_YES_R)
        Me.GroupBox2.Controls.Add(Me.RESERV_NO_R)
        Me.GroupBox2.Location = New System.Drawing.Point(111, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 30)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'RESERV_YES_R
        '
        Me.RESERV_YES_R.AutoSize = True
        Me.RESERV_YES_R.Location = New System.Drawing.Point(65, 10)
        Me.RESERV_YES_R.Name = "RESERV_YES_R"
        Me.RESERV_YES_R.Size = New System.Drawing.Size(35, 16)
        Me.RESERV_YES_R.TabIndex = 2
        Me.RESERV_YES_R.Text = "可"
        Me.RESERV_YES_R.UseVisualStyleBackColor = True
        '
        'RESERV_NO_R
        '
        Me.RESERV_NO_R.AutoSize = True
        Me.RESERV_NO_R.Checked = True
        Me.RESERV_NO_R.Location = New System.Drawing.Point(16, 10)
        Me.RESERV_NO_R.Name = "RESERV_NO_R"
        Me.RESERV_NO_R.Size = New System.Drawing.Size(47, 16)
        Me.RESERV_NO_R.TabIndex = 1
        Me.RESERV_NO_R.TabStop = True
        Me.RESERV_NO_R.Text = "不可"
        Me.RESERV_NO_R.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(21, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 43
        Me.Label6.Tag = ""
        Me.Label6.Text = "予約可否"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(21, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 44
        Me.Label8.Tag = ""
        Me.Label8.Text = "税区分名称"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TAX_CLASS_NAME_T
        '
        Me.TAX_CLASS_NAME_T.BackColor = System.Drawing.Color.White
        Me.TAX_CLASS_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_CLASS_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TAX_CLASS_NAME_T.Location = New System.Drawing.Point(111, 197)
        Me.TAX_CLASS_NAME_T.MaxLength = 13
        Me.TAX_CLASS_NAME_T.Name = "TAX_CLASS_NAME_T"
        Me.TAX_CLASS_NAME_T.Size = New System.Drawing.Size(190, 20)
        Me.TAX_CLASS_NAME_T.TabIndex = 9
        Me.TAX_CLASS_NAME_T.TabStop = False
        '
        'TAX_CLASS_B
        '
        Me.TAX_CLASS_B.ColorBottom = System.Drawing.Color.Tan
        Me.TAX_CLASS_B.Location = New System.Drawing.Point(307, 194)
        Me.TAX_CLASS_B.Name = "TAX_CLASS_B"
        Me.TAX_CLASS_B.Size = New System.Drawing.Size(76, 30)
        Me.TAX_CLASS_B.TabIndex = 10
        Me.TAX_CLASS_B.TextButton = "税区分"
        '
        'TAX_CLASS_CODE_T
        '
        Me.TAX_CLASS_CODE_T.BackColor = System.Drawing.Color.Gray
        Me.TAX_CLASS_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_CLASS_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TAX_CLASS_CODE_T.Location = New System.Drawing.Point(277, 197)
        Me.TAX_CLASS_CODE_T.MaxLength = 13
        Me.TAX_CLASS_CODE_T.Name = "TAX_CLASS_CODE_T"
        Me.TAX_CLASS_CODE_T.ReadOnly = True
        Me.TAX_CLASS_CODE_T.Size = New System.Drawing.Size(24, 20)
        Me.TAX_CLASS_CODE_T.TabIndex = 45
        Me.TAX_CLASS_CODE_T.TabStop = False
        Me.TAX_CLASS_CODE_T.Visible = False
        '
        'fBumonMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(534, 298)
        Me.Controls.Add(Me.TAX_CLASS_CODE_T)
        Me.Controls.Add(Me.TAX_CLASS_B)
        Me.Controls.Add(Me.TAX_CLASS_NAME_T)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.LINK_JAN_B)
        Me.Controls.Add(Me.BUMON_CODE_T)
        Me.Controls.Add(Me.BUMON_CLASS_G)
        Me.Controls.Add(Me.MODE_L)
        Me.Controls.Add(Me.BUMON_SHORT_NAME_T)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BUMON_NAME_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fBumonMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部門マスタ管理"
        Me.BUMON_CLASS_G.ResumeLayout(False)
        Me.BUMON_CLASS_G.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BUMON_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BUMON_SHORT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents BUMON_CLASS_G As System.Windows.Forms.GroupBox
    Friend WithEvents SERVICE_R As System.Windows.Forms.RadioButton
    Friend WithEvents PRODUCT_R As System.Windows.Forms.RadioButton
    Friend WithEvents LINK_JAN_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TIME_R As System.Windows.Forms.RadioButton
    Friend WithEvents DAY_R As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RESERV_YES_R As System.Windows.Forms.RadioButton
    Friend WithEvents RESERV_NO_R As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TAX_CLASS_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_CLASS_B As Softgroup.NetButton.NetButton
    Friend WithEvents TAX_CLASS_CODE_T As System.Windows.Forms.TextBox

End Class
