<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fOrderSearch
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
        Me.ORDER_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SUPPLIER_L = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ORDER_V = New System.Windows.Forms.DataGridView
        Me.SUPPLIER_CODE_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ARRIVED_C = New System.Windows.Forms.CheckBox
        Me.HALF_ARRIVE_C = New System.Windows.Forms.CheckBox
        Me.NON_ARRIVE_C = New System.Windows.Forms.CheckBox
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.S_ORDERNUMBER_T = New System.Windows.Forms.TextBox
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.COUNT_L = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.FROM_ORDER_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.TO_ORDER_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.TO_ARRIVE_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.FROM_ARRIVE_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.ORDER_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ORDER_CODE_T
        '
        Me.ORDER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ORDER_CODE_T.Location = New System.Drawing.Point(146, 26)
        Me.ORDER_CODE_T.Name = "ORDER_CODE_T"
        Me.ORDER_CODE_T.Size = New System.Drawing.Size(152, 20)
        Me.ORDER_CODE_T.TabIndex = 1
        Me.ORDER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "発注伝票番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SUPPLIER_L
        '
        Me.SUPPLIER_L.DropDownHeight = 300
        Me.SUPPLIER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_L.FormattingEnabled = True
        Me.SUPPLIER_L.IntegralHeight = False
        Me.SUPPLIER_L.Location = New System.Drawing.Point(466, 63)
        Me.SUPPLIER_L.Name = "SUPPLIER_L"
        Me.SUPPLIER_L.Size = New System.Drawing.Size(222, 21)
        Me.SUPPLIER_L.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(407, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "仕入先："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ORDER_V
        '
        Me.ORDER_V.AllowUserToAddRows = False
        Me.ORDER_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.ORDER_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ORDER_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ORDER_V.ColumnHeadersHeight = 30
        Me.ORDER_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ORDER_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.ORDER_V.Location = New System.Drawing.Point(24, 135)
        Me.ORDER_V.Name = "ORDER_V"
        Me.ORDER_V.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ORDER_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.ORDER_V.RowTemplate.Height = 21
        Me.ORDER_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ORDER_V.Size = New System.Drawing.Size(907, 355)
        Me.ORDER_V.TabIndex = 15
        Me.ORDER_V.TabStop = False
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(647, 63)
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.SUPPLIER_CODE_T.TabIndex = 21
        Me.SUPPLIER_CODE_T.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Tan
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(377, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "伝票作成日："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(566, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "～"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ARRIVED_C)
        Me.GroupBox1.Controls.Add(Me.HALF_ARRIVE_C)
        Me.GroupBox1.Controls.Add(Me.NON_ARRIVE_C)
        Me.GroupBox1.Location = New System.Drawing.Point(466, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(222, 37)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'ARRIVED_C
        '
        Me.ARRIVED_C.AutoSize = True
        Me.ARRIVED_C.Location = New System.Drawing.Point(153, 12)
        Me.ARRIVED_C.Name = "ARRIVED_C"
        Me.ARRIVED_C.Size = New System.Drawing.Size(60, 16)
        Me.ARRIVED_C.TabIndex = 12
        Me.ARRIVED_C.Text = "入庫済"
        Me.ARRIVED_C.UseVisualStyleBackColor = True
        '
        'HALF_ARRIVE_C
        '
        Me.HALF_ARRIVE_C.AutoSize = True
        Me.HALF_ARRIVE_C.Location = New System.Drawing.Point(75, 12)
        Me.HALF_ARRIVE_C.Name = "HALF_ARRIVE_C"
        Me.HALF_ARRIVE_C.Size = New System.Drawing.Size(72, 16)
        Me.HALF_ARRIVE_C.TabIndex = 11
        Me.HALF_ARRIVE_C.Text = "部分入庫"
        Me.HALF_ARRIVE_C.UseVisualStyleBackColor = True
        '
        'NON_ARRIVE_C
        '
        Me.NON_ARRIVE_C.AutoSize = True
        Me.NON_ARRIVE_C.Checked = True
        Me.NON_ARRIVE_C.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NON_ARRIVE_C.Location = New System.Drawing.Point(10, 12)
        Me.NON_ARRIVE_C.Name = "NON_ARRIVE_C"
        Me.NON_ARRIVE_C.Size = New System.Drawing.Size(60, 16)
        Me.NON_ARRIVE_C.TabIndex = 10
        Me.NON_ARRIVE_C.Text = "未入庫"
        Me.NON_ARRIVE_C.UseVisualStyleBackColor = True
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(146, 49)
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
        Me.Label5.Location = New System.Drawing.Point(69, 52)
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
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(146, 72)
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
        Me.Label6.Location = New System.Drawing.Point(72, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "商品名称："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'S_ORDERNUMBER_T
        '
        Me.S_ORDERNUMBER_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_ORDERNUMBER_T.Location = New System.Drawing.Point(299, 26)
        Me.S_ORDERNUMBER_T.Name = "S_ORDERNUMBER_T"
        Me.S_ORDERNUMBER_T.Size = New System.Drawing.Size(21, 19)
        Me.S_ORDERNUMBER_T.TabIndex = 37
        Me.S_ORDERNUMBER_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(146, 95)
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
        Me.Label7.Location = New System.Drawing.Point(49, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "オプション名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Tan
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(566, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "～"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Tan
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(407, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "納品日："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label10.Location = New System.Drawing.Point(392, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "入庫状況："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FROM_ORDER_DATE_T
        '
        Me.FROM_ORDER_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_ORDER_DATE_T.Location = New System.Drawing.Point(466, 18)
        Me.FROM_ORDER_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_ORDER_DATE_T.Name = "FROM_ORDER_DATE_T"
        Me.FROM_ORDER_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_ORDER_DATE_T.TabIndex = 5
        Me.FROM_ORDER_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_ORDER_DATE_T
        '
        Me.TO_ORDER_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_ORDER_DATE_T.Location = New System.Drawing.Point(588, 18)
        Me.TO_ORDER_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_ORDER_DATE_T.Name = "TO_ORDER_DATE_T"
        Me.TO_ORDER_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_ORDER_DATE_T.TabIndex = 6
        Me.TO_ORDER_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_ARRIVE_DATE_T
        '
        Me.TO_ARRIVE_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_ARRIVE_DATE_T.Location = New System.Drawing.Point(588, 40)
        Me.TO_ARRIVE_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_ARRIVE_DATE_T.Name = "TO_ARRIVE_DATE_T"
        Me.TO_ARRIVE_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_ARRIVE_DATE_T.TabIndex = 8
        Me.TO_ARRIVE_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FROM_ARRIVE_DATE_T
        '
        Me.FROM_ARRIVE_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_ARRIVE_DATE_T.Location = New System.Drawing.Point(466, 40)
        Me.FROM_ARRIVE_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_ARRIVE_DATE_T.Name = "FROM_ARRIVE_DATE_T"
        Me.FROM_ARRIVE_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_ARRIVE_DATE_T.TabIndex = 7
        Me.FROM_ARRIVE_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(698, 63)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(113, 57)
        Me.SEARCH_B.TabIndex = 13
        Me.SEARCH_B.TextButton = "検　索"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(818, 63)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(113, 57)
        Me.RETURN_B.TabIndex = 14
        Me.RETURN_B.TextButton = "戻　る"
        '
        'fOrderSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(958, 518)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.COUNT_L)
        Me.Controls.Add(Me.SUPPLIER_CODE_T)
        Me.Controls.Add(Me.SUPPLIER_L)
        Me.Controls.Add(Me.TO_ARRIVE_DATE_T)
        Me.Controls.Add(Me.FROM_ARRIVE_DATE_T)
        Me.Controls.Add(Me.TO_ORDER_DATE_T)
        Me.Controls.Add(Me.FROM_ORDER_DATE_T)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.ORDER_CODE_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.S_ORDERNUMBER_T)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ORDER_V)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fOrderSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "発注書検索画面"
        CType(Me.ORDER_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ORDER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SUPPLIER_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ORDER_V As System.Windows.Forms.DataGridView
    Friend WithEvents SUPPLIER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NON_ARRIVE_C As System.Windows.Forms.CheckBox
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents COUNT_L As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FROM_ORDER_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_ORDER_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_ARRIVE_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents FROM_ARRIVE_DATE_T As System.Windows.Forms.MaskedTextBox
    Public WithEvents S_ORDERNUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Public WithEvents ARRIVED_C As System.Windows.Forms.CheckBox
    Public WithEvents HALF_ARRIVE_C As System.Windows.Forms.CheckBox
    Public WithEvents SEARCH_B As Softgroup.NetButton.NetButton

End Class
