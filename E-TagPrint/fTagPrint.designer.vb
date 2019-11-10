<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fTagPrint
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.PRODUCT_V = New System.Windows.Forms.DataGridView
        Me.PRINT_C = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.JANCODE_T = New System.Windows.Forms.TextBox
        Me.CHANNEL_NAME_L = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SELECT_CNT = New System.Windows.Forms.TextBox
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TAGPRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ON_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OFF_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.YEAR_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.MONTH_T = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.DAY_T = New System.Windows.Forms.TextBox
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(110, 44)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "商品番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(110, 87)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(415, 20)
        Me.PRODUCT_NAME_T.TabIndex = 4
        '
        'PRODUCT_V
        '
        Me.PRODUCT_V.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.PRODUCT_V.AllowUserToAddRows = False
        Me.PRODUCT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.PRODUCT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCT_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.PRODUCT_V.Location = New System.Drawing.Point(24, 114)
        Me.PRODUCT_V.Name = "PRODUCT_V"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.PRODUCT_V.RowTemplate.Height = 21
        Me.PRODUCT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PRODUCT_V.Size = New System.Drawing.Size(859, 538)
        Me.PRODUCT_V.TabIndex = 7
        Me.PRODUCT_V.TabStop = False
        '
        'PRINT_C
        '
        Me.PRINT_C.AutoSize = True
        Me.PRINT_C.Location = New System.Drawing.Point(395, 67)
        Me.PRINT_C.Name = "PRINT_C"
        Me.PRINT_C.Size = New System.Drawing.Size(15, 14)
        Me.PRINT_C.TabIndex = 5
        Me.PRINT_C.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(313, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "印刷チェック"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "JANコード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(110, 65)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(176, 20)
        Me.JANCODE_T.TabIndex = 3
        '
        'CHANNEL_NAME_L
        '
        Me.CHANNEL_NAME_L.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHANNEL_NAME_L.DropDownHeight = 300
        Me.CHANNEL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_L.FormattingEnabled = True
        Me.CHANNEL_NAME_L.IntegralHeight = False
        Me.CHANNEL_NAME_L.Location = New System.Drawing.Point(110, 20)
        Me.CHANNEL_NAME_L.Name = "CHANNEL_NAME_L"
        Me.CHANNEL_NAME_L.Size = New System.Drawing.Size(182, 21)
        Me.CHANNEL_NAME_L.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "チャネル："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(701, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "出力タグ枚数："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SELECT_CNT
        '
        Me.SELECT_CNT.BackColor = System.Drawing.Color.Wheat
        Me.SELECT_CNT.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SELECT_CNT.Location = New System.Drawing.Point(798, 15)
        Me.SELECT_CNT.Name = "SELECT_CNT"
        Me.SELECT_CNT.ReadOnly = True
        Me.SELECT_CNT.Size = New System.Drawing.Size(83, 26)
        Me.SELECT_CNT.TabIndex = 26
        Me.SELECT_CNT.TabStop = False
        Me.SELECT_CNT.Text = "0"
        Me.SELECT_CNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(258, 20)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.ReadOnly = True
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(14, 19)
        Me.CHANNEL_CODE_T.TabIndex = 27
        Me.CHANNEL_CODE_T.Visible = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(221, 678)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(171, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(90, 678)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(125, 20)
        Me.STAFF_CODE_T.TabIndex = 28
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 681)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "担当者"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(540, 45)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(129, 62)
        Me.SEARCH_B.TabIndex = 9
        Me.SEARCH_B.TextButton = "検  索"
        '
        'TAGPRINT_B
        '
        Me.TAGPRINT_B.ColorBottom = System.Drawing.Color.Tan
        Me.TAGPRINT_B.Location = New System.Drawing.Point(754, 45)
        Me.TAGPRINT_B.Name = "TAGPRINT_B"
        Me.TAGPRINT_B.Size = New System.Drawing.Size(129, 62)
        Me.TAGPRINT_B.TabIndex = 12
        Me.TAGPRINT_B.TextButton = "タグ印刷"
        '
        'ON_B
        '
        Me.ON_B.ColorBottom = System.Drawing.Color.Tan
        Me.ON_B.Location = New System.Drawing.Point(672, 45)
        Me.ON_B.Name = "ON_B"
        Me.ON_B.Size = New System.Drawing.Size(80, 29)
        Me.ON_B.TabIndex = 10
        Me.ON_B.TextButton = "すべてOn"
        '
        'OFF_B
        '
        Me.OFF_B.ColorBottom = System.Drawing.Color.Tan
        Me.OFF_B.Location = New System.Drawing.Point(672, 78)
        Me.OFF_B.Name = "OFF_B"
        Me.OFF_B.Size = New System.Drawing.Size(80, 29)
        Me.OFF_B.TabIndex = 11
        Me.OFF_B.TextButton = "すべてOff"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Tan
        Me.CLOSE_B.Location = New System.Drawing.Point(754, 658)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(129, 56)
        Me.CLOSE_B.TabIndex = 13
        Me.CLOSE_B.TextButton = "終　了"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(298, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "適用日付："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'YEAR_T
        '
        Me.YEAR_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.YEAR_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.YEAR_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.YEAR_T.Location = New System.Drawing.Point(369, 21)
        Me.YEAR_T.MaxLength = 4
        Me.YEAR_T.Name = "YEAR_T"
        Me.YEAR_T.Size = New System.Drawing.Size(41, 20)
        Me.YEAR_T.TabIndex = 6
        Me.YEAR_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(409, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "年"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(457, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "月"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MONTH_T
        '
        Me.MONTH_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.MONTH_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MONTH_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MONTH_T.Location = New System.Drawing.Point(429, 21)
        Me.MONTH_T.MaxLength = 2
        Me.MONTH_T.Name = "MONTH_T"
        Me.MONTH_T.Size = New System.Drawing.Size(27, 20)
        Me.MONTH_T.TabIndex = 7
        Me.MONTH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(505, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 15)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "日"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DAY_T
        '
        Me.DAY_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.DAY_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DAY_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DAY_T.Location = New System.Drawing.Point(478, 21)
        Me.DAY_T.MaxLength = 2
        Me.DAY_T.Name = "DAY_T"
        Me.DAY_T.Size = New System.Drawing.Size(27, 20)
        Me.DAY_T.TabIndex = 8
        Me.DAY_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'fTagPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(910, 726)
        Me.Controls.Add(Me.DAY_T)
        Me.Controls.Add(Me.MONTH_T)
        Me.Controls.Add(Me.YEAR_T)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.OFF_B)
        Me.Controls.Add(Me.ON_B)
        Me.Controls.Add(Me.TAGPRINT_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.SELECT_CNT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CHANNEL_NAME_L)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.JANCODE_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PRINT_C)
        Me.Controls.Add(Me.PRODUCT_V)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fTagPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "タグ印刷画面"
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_V As System.Windows.Forms.DataGridView
    Friend WithEvents PRINT_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SELECT_CNT As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents TAGPRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents ON_B As Softgroup.NetButton.NetButton
    Friend WithEvents OFF_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YEAR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MONTH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DAY_T As System.Windows.Forms.TextBox

End Class
