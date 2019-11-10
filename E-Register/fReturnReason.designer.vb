<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReturnReason
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
        Me.MESSAGE_1_T = New System.Windows.Forms.Label()
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REASON_SET_G = New System.Windows.Forms.GroupBox()
        Me.REASON_4_R = New System.Windows.Forms.RadioButton()
        Me.REASON_3_R = New System.Windows.Forms.RadioButton()
        Me.REASON_2_R = New System.Windows.Forms.RadioButton()
        Me.REASON_1_R = New System.Windows.Forms.RadioButton()
        Me.RESALE_1_R = New System.Windows.Forms.RadioButton()
        Me.RESALE_2_R = New System.Windows.Forms.RadioButton()
        Me.RESALE_SET_G = New System.Windows.Forms.GroupBox()
        Me.CREDIT_SET_G = New System.Windows.Forms.GroupBox()
        Me.CREDIT_2_R = New System.Windows.Forms.RadioButton()
        Me.CREDIT_1_R = New System.Windows.Forms.RadioButton()
        Me.REASON_SET_G.SuspendLayout()
        Me.RESALE_SET_G.SuspendLayout()
        Me.CREDIT_SET_G.SuspendLayout()
        Me.SuspendLayout()
        '
        'MESSAGE_1_T
        '
        Me.MESSAGE_1_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE_1_T.Location = New System.Drawing.Point(12, 13)
        Me.MESSAGE_1_T.Name = "MESSAGE_1_T"
        Me.MESSAGE_1_T.Size = New System.Drawing.Size(407, 43)
        Me.MESSAGE_1_T.TabIndex = 15
        Me.MESSAGE_1_T.Text = "戻入の内容を指定して下さい。"
        Me.MESSAGE_1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(157, 265)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(123, 43)
        Me.OK_B.TabIndex = 4
        Me.OK_B.TextButton = "決定"
        '
        'REASON_SET_G
        '
        Me.REASON_SET_G.Controls.Add(Me.REASON_4_R)
        Me.REASON_SET_G.Controls.Add(Me.REASON_3_R)
        Me.REASON_SET_G.Controls.Add(Me.REASON_2_R)
        Me.REASON_SET_G.Controls.Add(Me.REASON_1_R)
        Me.REASON_SET_G.Location = New System.Drawing.Point(58, 58)
        Me.REASON_SET_G.Name = "REASON_SET_G"
        Me.REASON_SET_G.Size = New System.Drawing.Size(158, 185)
        Me.REASON_SET_G.TabIndex = 30
        Me.REASON_SET_G.TabStop = False
        Me.REASON_SET_G.Text = "【返品理由】"
        '
        'REASON_4_R
        '
        Me.REASON_4_R.AutoSize = True
        Me.REASON_4_R.Location = New System.Drawing.Point(33, 140)
        Me.REASON_4_R.Name = "REASON_4_R"
        Me.REASON_4_R.Size = New System.Drawing.Size(71, 16)
        Me.REASON_4_R.TabIndex = 3
        Me.REASON_4_R.Text = "長期不在"
        Me.REASON_4_R.UseVisualStyleBackColor = True
        '
        'REASON_3_R
        '
        Me.REASON_3_R.AutoSize = True
        Me.REASON_3_R.Location = New System.Drawing.Point(33, 106)
        Me.REASON_3_R.Name = "REASON_3_R"
        Me.REASON_3_R.Size = New System.Drawing.Size(71, 16)
        Me.REASON_3_R.TabIndex = 2
        Me.REASON_3_R.Text = "運送破損"
        Me.REASON_3_R.UseVisualStyleBackColor = True
        '
        'REASON_2_R
        '
        Me.REASON_2_R.AutoSize = True
        Me.REASON_2_R.Location = New System.Drawing.Point(33, 71)
        Me.REASON_2_R.Name = "REASON_2_R"
        Me.REASON_2_R.Size = New System.Drawing.Size(81, 16)
        Me.REASON_2_R.TabIndex = 1
        Me.REASON_2_R.Text = "お客様都合"
        Me.REASON_2_R.UseVisualStyleBackColor = True
        '
        'REASON_1_R
        '
        Me.REASON_1_R.AutoSize = True
        Me.REASON_1_R.Checked = True
        Me.REASON_1_R.Location = New System.Drawing.Point(33, 36)
        Me.REASON_1_R.Name = "REASON_1_R"
        Me.REASON_1_R.Size = New System.Drawing.Size(71, 16)
        Me.REASON_1_R.TabIndex = 0
        Me.REASON_1_R.TabStop = True
        Me.REASON_1_R.Text = "商品不良"
        Me.REASON_1_R.UseVisualStyleBackColor = True
        '
        'RESALE_1_R
        '
        Me.RESALE_1_R.AutoSize = True
        Me.RESALE_1_R.Checked = True
        Me.RESALE_1_R.Location = New System.Drawing.Point(33, 26)
        Me.RESALE_1_R.Name = "RESALE_1_R"
        Me.RESALE_1_R.Size = New System.Drawing.Size(47, 16)
        Me.RESALE_1_R.TabIndex = 0
        Me.RESALE_1_R.TabStop = True
        Me.RESALE_1_R.Text = "可能"
        Me.RESALE_1_R.UseVisualStyleBackColor = True
        '
        'RESALE_2_R
        '
        Me.RESALE_2_R.AutoSize = True
        Me.RESALE_2_R.Location = New System.Drawing.Point(33, 52)
        Me.RESALE_2_R.Name = "RESALE_2_R"
        Me.RESALE_2_R.Size = New System.Drawing.Size(47, 16)
        Me.RESALE_2_R.TabIndex = 1
        Me.RESALE_2_R.Text = "不可"
        Me.RESALE_2_R.UseVisualStyleBackColor = True
        '
        'RESALE_SET_G
        '
        Me.RESALE_SET_G.Controls.Add(Me.RESALE_2_R)
        Me.RESALE_SET_G.Controls.Add(Me.RESALE_1_R)
        Me.RESALE_SET_G.Location = New System.Drawing.Point(222, 59)
        Me.RESALE_SET_G.Name = "RESALE_SET_G"
        Me.RESALE_SET_G.Size = New System.Drawing.Size(158, 87)
        Me.RESALE_SET_G.TabIndex = 31
        Me.RESALE_SET_G.TabStop = False
        Me.RESALE_SET_G.Text = "【再販可否】"
        '
        'CREDIT_SET_G
        '
        Me.CREDIT_SET_G.Controls.Add(Me.CREDIT_2_R)
        Me.CREDIT_SET_G.Controls.Add(Me.CREDIT_1_R)
        Me.CREDIT_SET_G.Location = New System.Drawing.Point(222, 156)
        Me.CREDIT_SET_G.Name = "CREDIT_SET_G"
        Me.CREDIT_SET_G.Size = New System.Drawing.Size(158, 87)
        Me.CREDIT_SET_G.TabIndex = 32
        Me.CREDIT_SET_G.TabStop = False
        Me.CREDIT_SET_G.Text = "【クレジット返金可否】"
        '
        'CREDIT_2_R
        '
        Me.CREDIT_2_R.AutoSize = True
        Me.CREDIT_2_R.Location = New System.Drawing.Point(33, 52)
        Me.CREDIT_2_R.Name = "CREDIT_2_R"
        Me.CREDIT_2_R.Size = New System.Drawing.Size(47, 16)
        Me.CREDIT_2_R.TabIndex = 1
        Me.CREDIT_2_R.Text = "不可"
        Me.CREDIT_2_R.UseVisualStyleBackColor = True
        '
        'CREDIT_1_R
        '
        Me.CREDIT_1_R.AutoSize = True
        Me.CREDIT_1_R.Checked = True
        Me.CREDIT_1_R.Location = New System.Drawing.Point(33, 26)
        Me.CREDIT_1_R.Name = "CREDIT_1_R"
        Me.CREDIT_1_R.Size = New System.Drawing.Size(47, 16)
        Me.CREDIT_1_R.TabIndex = 0
        Me.CREDIT_1_R.TabStop = True
        Me.CREDIT_1_R.Text = "可能"
        Me.CREDIT_1_R.UseVisualStyleBackColor = True
        '
        'fReturnReason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(431, 328)
        Me.Controls.Add(Me.CREDIT_SET_G)
        Me.Controls.Add(Me.RESALE_SET_G)
        Me.Controls.Add(Me.REASON_SET_G)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.MESSAGE_1_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fReturnReason"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "返品理由指定"
        Me.REASON_SET_G.ResumeLayout(False)
        Me.REASON_SET_G.PerformLayout()
        Me.RESALE_SET_G.ResumeLayout(False)
        Me.RESALE_SET_G.PerformLayout()
        Me.CREDIT_SET_G.ResumeLayout(False)
        Me.CREDIT_SET_G.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OrderReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MESSAGE_1_T As System.Windows.Forms.Label
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents REASON_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents REASON_4_R As System.Windows.Forms.RadioButton
    Friend WithEvents REASON_3_R As System.Windows.Forms.RadioButton
    Friend WithEvents REASON_2_R As System.Windows.Forms.RadioButton
    Friend WithEvents REASON_1_R As System.Windows.Forms.RadioButton
    Friend WithEvents RESALE_1_R As System.Windows.Forms.RadioButton
    Friend WithEvents RESALE_2_R As System.Windows.Forms.RadioButton
    Friend WithEvents RESALE_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents CREDIT_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents CREDIT_2_R As System.Windows.Forms.RadioButton
    Friend WithEvents CREDIT_1_R As System.Windows.Forms.RadioButton
End Class
