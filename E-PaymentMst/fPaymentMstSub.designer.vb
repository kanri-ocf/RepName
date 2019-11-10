<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPaymentMstSub
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RETURN_B = New System.Windows.Forms.Button()
        Me.COMMIT_B = New System.Windows.Forms.Button()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.DELETE_B = New System.Windows.Forms.Button()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHANNEL_PAYMENT_V = New System.Windows.Forms.DataGridView()
        Me.PAYMENT_NAME_T = New System.Windows.Forms.TextBox()
        Me.CREDIT_C = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RETURN_C = New System.Windows.Forms.CheckBox()
        Me.ARRIVE_C = New System.Windows.Forms.CheckBox()
        Me.ORDER_C = New System.Windows.Forms.CheckBox()
        Me.SHIPMENT_C = New System.Windows.Forms.CheckBox()
        Me.REQUEST_C = New System.Windows.Forms.CheckBox()
        Me.PAYMENT_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SUB_DELETE_B = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CHANNEL_PAYMENT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RETURN_B
        '
        Me.RETURN_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RETURN_B.Location = New System.Drawing.Point(449, 427)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 44)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.Text = "戻　る"
        Me.RETURN_B.UseVisualStyleBackColor = False
        '
        'COMMIT_B
        '
        Me.COMMIT_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMMIT_B.Location = New System.Drawing.Point(345, 427)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 44)
        Me.COMMIT_B.TabIndex = 5
        Me.COMMIT_B.Text = "登　録"
        Me.COMMIT_B.UseVisualStyleBackColor = False
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(19, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(532, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "新規"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DELETE_B
        '
        Me.DELETE_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DELETE_B.Location = New System.Drawing.Point(241, 427)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(98, 44)
        Me.DELETE_B.TabIndex = 40
        Me.DELETE_B.Text = "削　除"
        Me.DELETE_B.UseVisualStyleBackColor = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(68, 448)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(167, 20)
        Me.STAFF_NAME_T.TabIndex = 73
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(68, 427)
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
        Me.Label15.Location = New System.Drawing.Point(13, 427)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "担当者"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SUB_DELETE_B)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CHANNEL_PAYMENT_V)
        Me.GroupBox2.Controls.Add(Me.PAYMENT_NAME_T)
        Me.GroupBox2.Controls.Add(Me.CREDIT_C)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.PAYMENT_CODE_T)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 389)
        Me.GroupBox2.TabIndex = 133
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(27, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(478, 22)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "※ 各チャネル別のCSVデータにおける支払い種別の名称を登録します。"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 19)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "【チャネル別支払名称】"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHANNEL_PAYMENT_V
        '
        Me.CHANNEL_PAYMENT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.CHANNEL_PAYMENT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHANNEL_PAYMENT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.CHANNEL_PAYMENT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CHANNEL_PAYMENT_V.DefaultCellStyle = DataGridViewCellStyle10
        Me.CHANNEL_PAYMENT_V.Location = New System.Drawing.Point(27, 122)
        Me.CHANNEL_PAYMENT_V.Name = "CHANNEL_PAYMENT_V"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHANNEL_PAYMENT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.CHANNEL_PAYMENT_V.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.CHANNEL_PAYMENT_V.RowTemplate.Height = 21
        Me.CHANNEL_PAYMENT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CHANNEL_PAYMENT_V.Size = New System.Drawing.Size(478, 200)
        Me.CHANNEL_PAYMENT_V.TabIndex = 143
        Me.CHANNEL_PAYMENT_V.TabStop = False
        '
        'PAYMENT_NAME_T
        '
        Me.PAYMENT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PAYMENT_NAME_T.Location = New System.Drawing.Point(137, 42)
        Me.PAYMENT_NAME_T.Name = "PAYMENT_NAME_T"
        Me.PAYMENT_NAME_T.Size = New System.Drawing.Size(311, 22)
        Me.PAYMENT_NAME_T.TabIndex = 133
        '
        'CREDIT_C
        '
        Me.CREDIT_C.AutoSize = True
        Me.CREDIT_C.Location = New System.Drawing.Point(223, 19)
        Me.CREDIT_C.Name = "CREDIT_C"
        Me.CREDIT_C.Size = New System.Drawing.Size(60, 16)
        Me.CREDIT_C.TabIndex = 142
        Me.CREDIT_C.Text = "掛取引"
        Me.CREDIT_C.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RETURN_C)
        Me.GroupBox1.Controls.Add(Me.ARRIVE_C)
        Me.GroupBox1.Controls.Add(Me.ORDER_C)
        Me.GroupBox1.Controls.Add(Me.SHIPMENT_C)
        Me.GroupBox1.Controls.Add(Me.REQUEST_C)
        Me.GroupBox1.Location = New System.Drawing.Point(137, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 33)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        '
        'RETURN_C
        '
        Me.RETURN_C.AutoSize = True
        Me.RETURN_C.Location = New System.Drawing.Point(308, 11)
        Me.RETURN_C.Name = "RETURN_C"
        Me.RETURN_C.Size = New System.Drawing.Size(48, 16)
        Me.RETURN_C.TabIndex = 8
        Me.RETURN_C.Text = "返品"
        Me.RETURN_C.UseVisualStyleBackColor = True
        '
        'ARRIVE_C
        '
        Me.ARRIVE_C.AutoSize = True
        Me.ARRIVE_C.Location = New System.Drawing.Point(241, 11)
        Me.ARRIVE_C.Name = "ARRIVE_C"
        Me.ARRIVE_C.Size = New System.Drawing.Size(48, 16)
        Me.ARRIVE_C.TabIndex = 7
        Me.ARRIVE_C.Text = "入庫"
        Me.ARRIVE_C.UseVisualStyleBackColor = True
        '
        'ORDER_C
        '
        Me.ORDER_C.AutoSize = True
        Me.ORDER_C.Location = New System.Drawing.Point(169, 11)
        Me.ORDER_C.Name = "ORDER_C"
        Me.ORDER_C.Size = New System.Drawing.Size(48, 16)
        Me.ORDER_C.TabIndex = 6
        Me.ORDER_C.Text = "発注"
        Me.ORDER_C.UseVisualStyleBackColor = True
        '
        'SHIPMENT_C
        '
        Me.SHIPMENT_C.AutoSize = True
        Me.SHIPMENT_C.Location = New System.Drawing.Point(86, 11)
        Me.SHIPMENT_C.Name = "SHIPMENT_C"
        Me.SHIPMENT_C.Size = New System.Drawing.Size(48, 16)
        Me.SHIPMENT_C.TabIndex = 5
        Me.SHIPMENT_C.Text = "出荷"
        Me.SHIPMENT_C.UseVisualStyleBackColor = True
        '
        'REQUEST_C
        '
        Me.REQUEST_C.AutoSize = True
        Me.REQUEST_C.Location = New System.Drawing.Point(16, 11)
        Me.REQUEST_C.Name = "REQUEST_C"
        Me.REQUEST_C.Size = New System.Drawing.Size(48, 16)
        Me.REQUEST_C.TabIndex = 4
        Me.REQUEST_C.Text = "受注"
        Me.REQUEST_C.UseVisualStyleBackColor = True
        '
        'PAYMENT_CODE_T
        '
        Me.PAYMENT_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PAYMENT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PAYMENT_CODE_T.Location = New System.Drawing.Point(137, 14)
        Me.PAYMENT_CODE_T.Name = "PAYMENT_CODE_T"
        Me.PAYMENT_CODE_T.ReadOnly = True
        Me.PAYMENT_CODE_T.Size = New System.Drawing.Size(45, 22)
        Me.PAYMENT_CODE_T.TabIndex = 136
        Me.PAYMENT_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "支払方法コード："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(25, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "対象イベント："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(24, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 19)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "支払方法名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SUB_DELETE_B
        '
        Me.SUB_DELETE_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUB_DELETE_B.Location = New System.Drawing.Point(407, 335)
        Me.SUB_DELETE_B.Name = "SUB_DELETE_B"
        Me.SUB_DELETE_B.Size = New System.Drawing.Size(98, 44)
        Me.SUB_DELETE_B.TabIndex = 134
        Me.SUB_DELETE_B.Text = "チャネル支払" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "名称削除"
        Me.SUB_DELETE_B.UseVisualStyleBackColor = False
        '
        'fPaymentMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(568, 483)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.MODE_L)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPaymentMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "支払方法マスタ管理"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CHANNEL_PAYMENT_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RETURN_B As System.Windows.Forms.Button
    Friend WithEvents COMMIT_B As System.Windows.Forms.Button
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents DELETE_B As System.Windows.Forms.Button
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CHANNEL_PAYMENT_V As System.Windows.Forms.DataGridView
    Friend WithEvents PAYMENT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents CREDIT_C As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RETURN_C As System.Windows.Forms.CheckBox
    Friend WithEvents ARRIVE_C As System.Windows.Forms.CheckBox
    Friend WithEvents ORDER_C As System.Windows.Forms.CheckBox
    Friend WithEvents SHIPMENT_C As System.Windows.Forms.CheckBox
    Friend WithEvents REQUEST_C As System.Windows.Forms.CheckBox
    Friend WithEvents PAYMENT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SUB_DELETE_B As System.Windows.Forms.Button

End Class
