<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRequestSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.REQUEST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.REQUEST_V = New System.Windows.Forms.DataGridView
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FINISH_SHIP_C = New System.Windows.Forms.CheckBox
        Me.NON_SHIP_C = New System.Windows.Forms.CheckBox
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.S_REQUESTNUMBER_T = New System.Windows.Forms.TextBox
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.COUNT_L = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.FROM_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.TO_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(136, 29)
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.Size = New System.Drawing.Size(152, 20)
        Me.REQUEST_CODE_T.TabIndex = 1
        Me.REQUEST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "受注伝票番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.DropDownHeight = 300
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.IntegralHeight = False
        Me.CHANNEL_L.Location = New System.Drawing.Point(466, 55)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(222, 21)
        Me.CHANNEL_L.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(376, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "チャネル名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'REQUEST_V
        '
        Me.REQUEST_V.AllowUserToAddRows = False
        Me.REQUEST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.REQUEST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.REQUEST_V.ColumnHeadersHeight = 30
        Me.REQUEST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.REQUEST_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.REQUEST_V.Location = New System.Drawing.Point(24, 135)
        Me.REQUEST_V.Name = "REQUEST_V"
        Me.REQUEST_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.REQUEST_V.RowTemplate.Height = 21
        Me.REQUEST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.REQUEST_V.Size = New System.Drawing.Size(907, 355)
        Me.REQUEST_V.TabIndex = 15
        Me.REQUEST_V.TabStop = False
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(647, 55)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.CHANNEL_CODE_T.TabIndex = 21
        Me.CHANNEL_CODE_T.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Tan
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(407, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "受注日："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(566, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "～"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FINISH_SHIP_C)
        Me.GroupBox1.Controls.Add(Me.NON_SHIP_C)
        Me.GroupBox1.Location = New System.Drawing.Point(466, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 37)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'FINISH_SHIP_C
        '
        Me.FINISH_SHIP_C.AutoSize = True
        Me.FINISH_SHIP_C.Location = New System.Drawing.Point(103, 12)
        Me.FINISH_SHIP_C.Name = "FINISH_SHIP_C"
        Me.FINISH_SHIP_C.Size = New System.Drawing.Size(72, 16)
        Me.FINISH_SHIP_C.TabIndex = 12
        Me.FINISH_SHIP_C.Text = "出荷完了"
        Me.FINISH_SHIP_C.UseVisualStyleBackColor = True
        '
        'NON_SHIP_C
        '
        Me.NON_SHIP_C.AutoSize = True
        Me.NON_SHIP_C.Checked = True
        Me.NON_SHIP_C.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NON_SHIP_C.Location = New System.Drawing.Point(24, 12)
        Me.NON_SHIP_C.Name = "NON_SHIP_C"
        Me.NON_SHIP_C.Size = New System.Drawing.Size(60, 16)
        Me.NON_SHIP_C.TabIndex = 10
        Me.NON_SHIP_C.Text = "未完了"
        Me.NON_SHIP_C.UseVisualStyleBackColor = True
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(136, 52)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 2
        Me.PRODUCT_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Tan
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(59, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "商品コード："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(136, 75)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(236, 20)
        Me.PRODUCT_NAME_T.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Tan
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(62, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "商品名称："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'S_REQUESTNUMBER_T
        '
        Me.S_REQUESTNUMBER_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_REQUESTNUMBER_T.Location = New System.Drawing.Point(289, 29)
        Me.S_REQUESTNUMBER_T.Name = "S_REQUESTNUMBER_T"
        Me.S_REQUESTNUMBER_T.Size = New System.Drawing.Size(21, 19)
        Me.S_REQUESTNUMBER_T.TabIndex = 37
        Me.S_REQUESTNUMBER_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(136, 98)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(236, 20)
        Me.OPTION_NAME_T.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Tan
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(39, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "オプション名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'COUNT_L
        '
        Me.COUNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.COUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COUNT_L.Location = New System.Drawing.Point(803, 18)
        Me.COUNT_L.Name = "COUNT_L"
        Me.COUNT_L.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.COUNT_L.Size = New System.Drawing.Size(99, 34)
        Me.COUNT_L.TabIndex = 44
        Me.COUNT_L.Text = "0"
        Me.COUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(720, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 23)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(905, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 23)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "件"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Tan
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(392, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "出荷状況："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FROM_REQUEST_DATE_T
        '
        Me.FROM_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_REQUEST_DATE_T.Location = New System.Drawing.Point(466, 33)
        Me.FROM_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_REQUEST_DATE_T.Name = "FROM_REQUEST_DATE_T"
        Me.FROM_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_REQUEST_DATE_T.TabIndex = 5
        Me.FROM_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_REQUEST_DATE_T
        '
        Me.TO_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_REQUEST_DATE_T.Location = New System.Drawing.Point(588, 33)
        Me.TO_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_REQUEST_DATE_T.Name = "TO_REQUEST_DATE_T"
        Me.TO_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_REQUEST_DATE_T.TabIndex = 6
        Me.TO_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(697, 62)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(114, 58)
        Me.SEARCH_B.TabIndex = 13
        Me.SEARCH_B.TextButton = "検　索"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(817, 62)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(114, 58)
        Me.RETURN_B.TabIndex = 14
        Me.RETURN_B.TextButton = "戻　る"
        '
        'fRequestSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(958, 518)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.COUNT_L)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.TO_REQUEST_DATE_T)
        Me.Controls.Add(Me.FROM_REQUEST_DATE_T)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.REQUEST_CODE_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.S_REQUESTNUMBER_T)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.REQUEST_V)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fRequestSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "発注書検索画面"
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_V As System.Windows.Forms.DataGridView
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FINISH_SHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents NON_SHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents COUNT_L As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FROM_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Public WithEvents S_REQUESTNUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton

End Class
