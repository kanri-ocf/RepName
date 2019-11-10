<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fServiceMst
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.S_SERVICE_CODE_T = New System.Windows.Forms.TextBox()
        Me.S_SERVICE_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NEW_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TARGET_O_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_P_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_A_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_E_C = New System.Windows.Forms.CheckBox()
        Me.TARGET_C_C = New System.Windows.Forms.CheckBox()
        Me.CLASS_IN_C = New System.Windows.Forms.CheckBox()
        Me.CLASS_OUT_C = New System.Windows.Forms.CheckBox()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DATA_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle6
        Me.DATA_V.Location = New System.Drawing.Point(18, 131)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DATA_V.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(751, 282)
        Me.DATA_V.TabIndex = 4
        Me.DATA_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(25, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "サービスコード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'S_SERVICE_CODE_T
        '
        Me.S_SERVICE_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_SERVICE_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.S_SERVICE_CODE_T.Location = New System.Drawing.Point(128, 18)
        Me.S_SERVICE_CODE_T.Name = "S_SERVICE_CODE_T"
        Me.S_SERVICE_CODE_T.Size = New System.Drawing.Size(163, 20)
        Me.S_SERVICE_CODE_T.TabIndex = 0
        '
        'S_SERVICE_NAME_T
        '
        Me.S_SERVICE_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_SERVICE_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.S_SERVICE_NAME_T.Location = New System.Drawing.Point(128, 41)
        Me.S_SERVICE_NAME_T.Name = "S_SERVICE_NAME_T"
        Me.S_SERVICE_NAME_T.Size = New System.Drawing.Size(351, 20)
        Me.S_SERVICE_NAME_T.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "サービス名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(82, 433)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 28
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "担当者"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(187, 433)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(640, 40)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(129, 68)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "検　索"
        '
        'NEW_B
        '
        Me.NEW_B.ColorBottom = System.Drawing.Color.Tan
        Me.NEW_B.Location = New System.Drawing.Point(545, 419)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(109, 48)
        Me.NEW_B.TabIndex = 5
        Me.NEW_B.TextButton = "新規登録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(660, 419)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.TextButton = "終　了"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CLASS_IN_C)
        Me.GroupBox1.Controls.Add(Me.CLASS_OUT_C)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(181, 58)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【サービス区分】"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TARGET_O_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_P_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_A_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_E_C)
        Me.GroupBox2.Controls.Add(Me.TARGET_C_C)
        Me.GroupBox2.Location = New System.Drawing.Point(234, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(389, 58)
        Me.GroupBox2.TabIndex = 3
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
        'CLASS_IN_C
        '
        Me.CLASS_IN_C.AutoSize = True
        Me.CLASS_IN_C.Location = New System.Drawing.Point(103, 25)
        Me.CLASS_IN_C.Name = "CLASS_IN_C"
        Me.CLASS_IN_C.Size = New System.Drawing.Size(48, 16)
        Me.CLASS_IN_C.TabIndex = 5
        Me.CLASS_IN_C.Text = "社販"
        Me.CLASS_IN_C.UseVisualStyleBackColor = True
        '
        'CLASS_OUT_C
        '
        Me.CLASS_OUT_C.AutoSize = True
        Me.CLASS_OUT_C.Location = New System.Drawing.Point(24, 25)
        Me.CLASS_OUT_C.Name = "CLASS_OUT_C"
        Me.CLASS_OUT_C.Size = New System.Drawing.Size(48, 16)
        Me.CLASS_OUT_C.TabIndex = 4
        Me.CLASS_OUT_C.Text = "顧客"
        Me.CLASS_OUT_C.UseVisualStyleBackColor = True
        '
        'fServiceMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(781, 479)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.S_SERVICE_NAME_T)
        Me.Controls.Add(Me.S_SERVICE_CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DATA_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fServiceMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "サービスマスタ検索画面"
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents S_SERVICE_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents S_SERVICE_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents NEW_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TARGET_O_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_P_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_A_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_E_C As System.Windows.Forms.CheckBox
    Friend WithEvents TARGET_C_C As System.Windows.Forms.CheckBox
    Friend WithEvents CLASS_IN_C As System.Windows.Forms.CheckBox
    Friend WithEvents CLASS_OUT_C As System.Windows.Forms.CheckBox

End Class
