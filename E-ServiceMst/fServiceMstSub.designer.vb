<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fServiceMstSub
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SERVICE_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxEX1 = New Dotnetrix.Controls.GroupBoxEX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TARGET_O_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_P_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_A_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_E_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_C_C = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SERVICE_CODE_T = New System.Windows.Forms.TextBox()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.CLASS_IN_R = New System.Windows.Forms.RadioButton()
        Me.CLASS_OUT_R = New System.Windows.Forms.RadioButton()
        Me.GroupBoxEX1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(19, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(608, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "（新規）"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(72, 440)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 73
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(72, 414)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 71
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Tan
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(17, 414)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "担当者"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELETE_B.ColorLight = System.Drawing.Color.Wheat
        Me.DELETE_B.ColorTop = System.Drawing.Color.Linen
        Me.DELETE_B.LightEffect = False
        Me.DELETE_B.Location = New System.Drawing.Point(288, 414)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(109, 59)
        Me.DELETE_B.TabIndex = 3
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.ColorLight = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorTop = System.Drawing.Color.Linen
        Me.COMMIT_B.LightEffect = False
        Me.COMMIT_B.Location = New System.Drawing.Point(403, 414)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(109, 59)
        Me.COMMIT_B.TabIndex = 4
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.ColorLight = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorTop = System.Drawing.Color.Linen
        Me.RETURN_B.LightEffect = False
        Me.RETURN_B.Location = New System.Drawing.Point(518, 414)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 59)
        Me.RETURN_B.TabIndex = 5
        Me.RETURN_B.TextButton = "戻　る"
        '
        'SERVICE_NAME_T
        '
        Me.SERVICE_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SERVICE_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SERVICE_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SERVICE_NAME_T.Location = New System.Drawing.Point(184, 35)
        Me.SERVICE_NAME_T.MaxLength = 8
        Me.SERVICE_NAME_T.Name = "SERVICE_NAME_T"
        Me.SERVICE_NAME_T.Size = New System.Drawing.Size(273, 22)
        Me.SERVICE_NAME_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(81, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "サービス名称："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEX1
        '
        Me.GroupBoxEX1.Controls.Add(Me.GroupBox2)
        Me.GroupBoxEX1.Controls.Add(Me.GroupBox1)
        Me.GroupBoxEX1.Controls.Add(Me.Label1)
        Me.GroupBoxEX1.Controls.Add(Me.SERVICE_CODE_T)
        Me.GroupBoxEX1.Controls.Add(Me.Label5)
        Me.GroupBoxEX1.Controls.Add(Me.SERVICE_NAME_T)
        Me.GroupBoxEX1.Location = New System.Drawing.Point(19, 32)
        Me.GroupBoxEX1.Name = "GroupBoxEX1"
        Me.GroupBoxEX1.Size = New System.Drawing.Size(608, 130)
        Me.GroupBoxEX1.TabIndex = 74
        Me.GroupBoxEX1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TARGET_O_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_P_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_A_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_E_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_C_C)
        Me.GroupBox2.Location = New System.Drawing.Point(212, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(389, 58)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【サービス対象】"
        '
        'TARGET_O_C
        '
        Me.TARGET_O_C.AutoSize = True
        Me.TARGET_O_C.Location = New System.Drawing.Point(314, 25)
        Me.TARGET_O_C.Name = "TARGET_O_C"
        Me.TARGET_O_C.Size = New System.Drawing.Size(55, 16)
        Me.TARGET_O_C.TabIndex = 4
        Me.TARGET_O_C.Text = "その他"
        Me.TARGET_O_C.UseVisualStyleBackColor = True
        '
        'TARGET_P_C
        '
        Me.TARGET_P_C.AutoSize = True
        Me.TARGET_P_C.Location = New System.Drawing.Point(244, 25)
        Me.TARGET_P_C.Name = "TARGET_P_C"
        Me.TARGET_P_C.Size = New System.Drawing.Size(52, 16)
        Me.TARGET_P_C.TabIndex = 3
        Me.TARGET_P_C.Text = "パート"
        Me.TARGET_P_C.UseVisualStyleBackColor = True
        '
        'TARGET_A_C
        '
        Me.TARGET_A_C.AutoSize = True
        Me.TARGET_A_C.Location = New System.Drawing.Point(164, 25)
        Me.TARGET_A_C.Name = "TARGET_A_C"
        Me.TARGET_A_C.Size = New System.Drawing.Size(70, 16)
        Me.TARGET_A_C.TabIndex = 2
        Me.TARGET_A_C.Text = "アルバイト"
        Me.TARGET_A_C.UseVisualStyleBackColor = True
        '
        'TARGET_E_C
        '
        Me.TARGET_E_C.AutoSize = True
        Me.TARGET_E_C.Location = New System.Drawing.Point(94, 25)
        Me.TARGET_E_C.Name = "TARGET_E_C"
        Me.TARGET_E_C.Size = New System.Drawing.Size(48, 16)
        Me.TARGET_E_C.TabIndex = 1
        Me.TARGET_E_C.Text = "社員"
        Me.TARGET_E_C.UseVisualStyleBackColor = True
        '
        'TARGET_C_C
        '
        Me.TARGET_C_C.AutoSize = True
        Me.TARGET_C_C.Location = New System.Drawing.Point(24, 25)
        Me.TARGET_C_C.Name = "TARGET_C_C"
        Me.TARGET_C_C.Size = New System.Drawing.Size(48, 16)
        Me.TARGET_C_C.TabIndex = 0
        Me.TARGET_C_C.Text = "顧客"
        Me.TARGET_C_C.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CLASS_IN_R)
        Me.GroupBox1.Controls.Add(Me.CLASS_OUT_R)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(181, 58)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【サービス区分】"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(81, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 19)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "サービスコード："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SERVICE_CODE_T
        '
        Me.SERVICE_CODE_T.BackColor = System.Drawing.Color.LightGreen
        Me.SERVICE_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SERVICE_CODE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SERVICE_CODE_T.Location = New System.Drawing.Point(184, 7)
        Me.SERVICE_CODE_T.MaxLength = 8
        Me.SERVICE_CODE_T.Name = "SERVICE_CODE_T"
        Me.SERVICE_CODE_T.ReadOnly = True
        Me.SERVICE_CODE_T.Size = New System.Drawing.Size(120, 22)
        Me.SERVICE_CODE_T.TabIndex = 115
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DATA_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle14
        Me.DATA_V.Location = New System.Drawing.Point(19, 168)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.DATA_V.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(608, 240)
        Me.DATA_V.TabIndex = 75
        Me.DATA_V.TabStop = False
        '
        'CLASS_IN_R
        '
        Me.CLASS_IN_R.AutoSize = True
        Me.CLASS_IN_R.Location = New System.Drawing.Point(91, 25)
        Me.CLASS_IN_R.Name = "CLASS_IN_R"
        Me.CLASS_IN_R.Size = New System.Drawing.Size(71, 16)
        Me.CLASS_IN_R.TabIndex = 5
        Me.CLASS_IN_R.Text = "社内販売"
        Me.CLASS_IN_R.UseVisualStyleBackColor = True
        '
        'CLASS_OUT_R
        '
        Me.CLASS_OUT_R.AutoSize = True
        Me.CLASS_OUT_R.Checked = True
        Me.CLASS_OUT_R.Location = New System.Drawing.Point(22, 26)
        Me.CLASS_OUT_R.Name = "CLASS_OUT_R"
        Me.CLASS_OUT_R.Size = New System.Drawing.Size(47, 16)
        Me.CLASS_OUT_R.TabIndex = 4
        Me.CLASS_OUT_R.TabStop = True
        Me.CLASS_OUT_R.Text = "顧客"
        Me.CLASS_OUT_R.UseVisualStyleBackColor = True
        '
        'fServiceMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(644, 488)
        Me.Controls.Add(Me.DATA_V)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBoxEX1)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fServiceMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "サービスマスタ管理"
        Me.GroupBoxEX1.ResumeLayout(False)
        Me.GroupBoxEX1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents SERVICE_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEX1 As Dotnetrix.Controls.GroupBoxEX
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SERVICE_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TARGET_O_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_P_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_A_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_E_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_C_C As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CLASS_IN_R As System.Windows.Forms.RadioButton
    Friend WithEvents CLASS_OUT_R As System.Windows.Forms.RadioButton

End Class
