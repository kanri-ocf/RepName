<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPaymentMst
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.SEARCH_B = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.S_PAYMENT_CODE_T = New System.Windows.Forms.TextBox()
        Me.RETURN_B = New System.Windows.Forms.Button()
        Me.S_PAYMENT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.NEW_B = New System.Windows.Forms.Button()
        Me.CLASS_FLG_G = New System.Windows.Forms.GroupBox()
        Me.S_RETURN_C = New System.Windows.Forms.CheckBox()
        Me.S_ARRIVE_C = New System.Windows.Forms.CheckBox()
        Me.S_ORDER_C = New System.Windows.Forms.CheckBox()
        Me.S_SHIP_C = New System.Windows.Forms.CheckBox()
        Me.S_REQUEST_C = New System.Windows.Forms.CheckBox()
        Me.S_CREDIT_C = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CLASS_FLG_G.SuspendLayout()
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
        Me.DATA_V.ColumnHeadersHeight = 25
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle6
        Me.DATA_V.Location = New System.Drawing.Point(28, 105)
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
        Me.DATA_V.Size = New System.Drawing.Size(603, 249)
        Me.DATA_V.TabIndex = 4
        Me.DATA_V.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEARCH_B.Location = New System.Drawing.Point(523, 18)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(108, 56)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.Text = "検　索"
        Me.SEARCH_B.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(25, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "支払方法コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'S_PAYMENT_CODE_T
        '
        Me.S_PAYMENT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_PAYMENT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.S_PAYMENT_CODE_T.Location = New System.Drawing.Point(148, 18)
        Me.S_PAYMENT_CODE_T.Name = "S_PAYMENT_CODE_T"
        Me.S_PAYMENT_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.S_PAYMENT_CODE_T.TabIndex = 0
        '
        'RETURN_B
        '
        Me.RETURN_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RETURN_B.Location = New System.Drawing.Point(523, 371)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.Text = "終　了"
        Me.RETURN_B.UseVisualStyleBackColor = False
        '
        'S_PAYMENT_NAME_T
        '
        Me.S_PAYMENT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_PAYMENT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.S_PAYMENT_NAME_T.Location = New System.Drawing.Point(148, 44)
        Me.S_PAYMENT_NAME_T.Name = "S_PAYMENT_NAME_T"
        Me.S_PAYMENT_NAME_T.Size = New System.Drawing.Size(368, 20)
        Me.S_PAYMENT_NAME_T.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "支払方法名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(89, 387)
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
        Me.Label1.Location = New System.Drawing.Point(34, 387)
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
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(194, 387)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'NEW_B
        '
        Me.NEW_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NEW_B.Location = New System.Drawing.Point(408, 371)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(109, 49)
        Me.NEW_B.TabIndex = 5
        Me.NEW_B.Text = "新規登録"
        Me.NEW_B.UseVisualStyleBackColor = False
        '
        'CLASS_FLG_G
        '
        Me.CLASS_FLG_G.Controls.Add(Me.S_RETURN_C)
        Me.CLASS_FLG_G.Controls.Add(Me.S_ARRIVE_C)
        Me.CLASS_FLG_G.Controls.Add(Me.S_ORDER_C)
        Me.CLASS_FLG_G.Controls.Add(Me.S_SHIP_C)
        Me.CLASS_FLG_G.Controls.Add(Me.S_REQUEST_C)
        Me.CLASS_FLG_G.Location = New System.Drawing.Point(149, 66)
        Me.CLASS_FLG_G.Name = "CLASS_FLG_G"
        Me.CLASS_FLG_G.Size = New System.Drawing.Size(368, 33)
        Me.CLASS_FLG_G.TabIndex = 1
        Me.CLASS_FLG_G.TabStop = False
        '
        'S_RETURN_C
        '
        Me.S_RETURN_C.AutoSize = True
        Me.S_RETURN_C.Location = New System.Drawing.Point(308, 11)
        Me.S_RETURN_C.Name = "S_RETURN_C"
        Me.S_RETURN_C.Size = New System.Drawing.Size(48, 16)
        Me.S_RETURN_C.TabIndex = 8
        Me.S_RETURN_C.Text = "返品"
        Me.S_RETURN_C.UseVisualStyleBackColor = True
        '
        'S_ARRIVE_C
        '
        Me.S_ARRIVE_C.AutoSize = True
        Me.S_ARRIVE_C.Location = New System.Drawing.Point(241, 11)
        Me.S_ARRIVE_C.Name = "S_ARRIVE_C"
        Me.S_ARRIVE_C.Size = New System.Drawing.Size(48, 16)
        Me.S_ARRIVE_C.TabIndex = 7
        Me.S_ARRIVE_C.Text = "入庫"
        Me.S_ARRIVE_C.UseVisualStyleBackColor = True
        '
        'S_ORDER_C
        '
        Me.S_ORDER_C.AutoSize = True
        Me.S_ORDER_C.Location = New System.Drawing.Point(169, 11)
        Me.S_ORDER_C.Name = "S_ORDER_C"
        Me.S_ORDER_C.Size = New System.Drawing.Size(48, 16)
        Me.S_ORDER_C.TabIndex = 6
        Me.S_ORDER_C.Text = "発注"
        Me.S_ORDER_C.UseVisualStyleBackColor = True
        '
        'S_SHIP_C
        '
        Me.S_SHIP_C.AutoSize = True
        Me.S_SHIP_C.Location = New System.Drawing.Point(86, 11)
        Me.S_SHIP_C.Name = "S_SHIP_C"
        Me.S_SHIP_C.Size = New System.Drawing.Size(48, 16)
        Me.S_SHIP_C.TabIndex = 5
        Me.S_SHIP_C.Text = "出荷"
        Me.S_SHIP_C.UseVisualStyleBackColor = True
        '
        'S_REQUEST_C
        '
        Me.S_REQUEST_C.AutoSize = True
        Me.S_REQUEST_C.Location = New System.Drawing.Point(16, 11)
        Me.S_REQUEST_C.Name = "S_REQUEST_C"
        Me.S_REQUEST_C.Size = New System.Drawing.Size(48, 16)
        Me.S_REQUEST_C.TabIndex = 4
        Me.S_REQUEST_C.Text = "受注"
        Me.S_REQUEST_C.UseVisualStyleBackColor = True
        '
        'S_CREDIT_C
        '
        Me.S_CREDIT_C.AutoSize = True
        Me.S_CREDIT_C.Location = New System.Drawing.Point(318, 22)
        Me.S_CREDIT_C.Name = "S_CREDIT_C"
        Me.S_CREDIT_C.Size = New System.Drawing.Size(60, 16)
        Me.S_CREDIT_C.TabIndex = 31
        Me.S_CREDIT_C.Text = "掛取引"
        Me.S_CREDIT_C.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(26, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 19)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "適用業務"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fPaymentMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(660, 432)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.S_CREDIT_C)
        Me.Controls.Add(Me.S_PAYMENT_NAME_T)
        Me.Controls.Add(Me.S_PAYMENT_CODE_T)
        Me.Controls.Add(Me.CLASS_FLG_G)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.DATA_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPaymentMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "支払方法マスタ検索画面"
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CLASS_FLG_G.ResumeLayout(False)
        Me.CLASS_FLG_G.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents SEARCH_B As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents S_PAYMENT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents RETURN_B As System.Windows.Forms.Button
    Friend WithEvents S_PAYMENT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents NEW_B As System.Windows.Forms.Button
    Friend WithEvents CLASS_FLG_G As System.Windows.Forms.GroupBox
    Friend WithEvents S_ARRIVE_C As System.Windows.Forms.CheckBox
    Friend WithEvents S_ORDER_C As System.Windows.Forms.CheckBox
    Friend WithEvents S_SHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents S_REQUEST_C As System.Windows.Forms.CheckBox
    Friend WithEvents S_RETURN_C As System.Windows.Forms.CheckBox
    Friend WithEvents S_CREDIT_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
