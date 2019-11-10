<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProductListCsvOutput
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MAKER_L = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.PRODUCT_V = New System.Windows.Forms.DataGridView()
        Me.YAHOO_C = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TOTAL_COUNT_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.JANCODE_T = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ORDER_REPORT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ORDER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ORDER_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ON_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OFF_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ORDER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.E_SHOP_C = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AMAZON_C = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RAKUTEN_C = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SELECT_C = New System.Windows.Forms.CheckBox()
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(111, 72)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(110, 20)
        Me.PRODUCT_CODE_T.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "商品番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MAKER_L
        '
        Me.MAKER_L.DropDownHeight = 300
        Me.MAKER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MAKER_L.FormattingEnabled = True
        Me.MAKER_L.IntegralHeight = False
        Me.MAKER_L.Location = New System.Drawing.Point(299, 75)
        Me.MAKER_L.Name = "MAKER_L"
        Me.MAKER_L.Size = New System.Drawing.Size(264, 21)
        Me.MAKER_L.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "メーカー名："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(111, 26)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(452, 20)
        Me.PRODUCT_NAME_T.TabIndex = 1
        '
        'PRODUCT_V
        '
        Me.PRODUCT_V.AllowUserToAddRows = False
        Me.PRODUCT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.PRODUCT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.PRODUCT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCT_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.PRODUCT_V.Location = New System.Drawing.Point(24, 143)
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
        Me.PRODUCT_V.Size = New System.Drawing.Size(986, 544)
        Me.PRODUCT_V.TabIndex = 8
        Me.PRODUCT_V.TabStop = False
        '
        'YAHOO_C
        '
        Me.YAHOO_C.AutoSize = True
        Me.YAHOO_C.Location = New System.Drawing.Point(78, 15)
        Me.YAHOO_C.Name = "YAHOO_C"
        Me.YAHOO_C.Size = New System.Drawing.Size(15, 14)
        Me.YAHOO_C.TabIndex = 6
        Me.YAHOO_C.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Yahoo："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(812, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "選択商品数："
        '
        'TOTAL_COUNT_T
        '
        Me.TOTAL_COUNT_T.BackColor = System.Drawing.Color.Wheat
        Me.TOTAL_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_COUNT_T.Location = New System.Drawing.Point(892, 21)
        Me.TOTAL_COUNT_T.Multiline = True
        Me.TOTAL_COUNT_T.Name = "TOTAL_COUNT_T"
        Me.TOTAL_COUNT_T.ReadOnly = True
        Me.TOTAL_COUNT_T.Size = New System.Drawing.Size(105, 28)
        Me.TOTAL_COUNT_T.TabIndex = 17
        Me.TOTAL_COUNT_T.TabStop = False
        Me.TOTAL_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(395, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "JANコード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(458, 49)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(105, 20)
        Me.JANCODE_T.TabIndex = 4
        Me.JANCODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ORDER_REPORT_B)
        Me.GroupBox1.Controls.Add(Me.ORDER_SEARCH_B)
        Me.GroupBox1.Controls.Add(Me.ORDER_CODE_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(338, 693)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 59)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'ORDER_REPORT_B
        '
        Me.ORDER_REPORT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ORDER_REPORT_B.CornerRadius = 15
        Me.ORDER_REPORT_B.Location = New System.Drawing.Point(372, 11)
        Me.ORDER_REPORT_B.Name = "ORDER_REPORT_B"
        Me.ORDER_REPORT_B.Size = New System.Drawing.Size(110, 43)
        Me.ORDER_REPORT_B.TabIndex = 3
        Me.ORDER_REPORT_B.TextButton = "発注書再印刷"
        '
        'ORDER_SEARCH_B
        '
        Me.ORDER_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ORDER_SEARCH_B.CornerRadius = 15
        Me.ORDER_SEARCH_B.Location = New System.Drawing.Point(256, 11)
        Me.ORDER_SEARCH_B.Name = "ORDER_SEARCH_B"
        Me.ORDER_SEARCH_B.Size = New System.Drawing.Size(110, 43)
        Me.ORDER_SEARCH_B.TabIndex = 2
        Me.ORDER_SEARCH_B.TextButton = "発注書呼出"
        '
        'ORDER_CODE_T
        '
        Me.ORDER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ORDER_CODE_T.Location = New System.Drawing.Point(86, 19)
        Me.ORDER_CODE_T.Name = "ORDER_CODE_T"
        Me.ORDER_CODE_T.Size = New System.Drawing.Size(161, 26)
        Me.ORDER_CODE_T.TabIndex = 1
        Me.ORDER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "発注番号："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(122, 707)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(117, 20)
        Me.STAFF_CODE_T.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 710)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "担当者コード："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(122, 727)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(190, 20)
        Me.STAFF_NAME_T.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 730)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "担当者名称："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(111, 49)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(268, 20)
        Me.OPTION_NAME_T.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "オプション名称："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1024, 771)
        Me.ShapeContainer1.TabIndex = 14
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Sienna
        Me.RectangleShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(804, 16)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(203, 38)
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.CornerRadius = 10
        Me.SEARCH_B.Location = New System.Drawing.Point(621, 71)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(130, 65)
        Me.SEARCH_B.TabIndex = 7
        Me.SEARCH_B.TextButton = "検　索"
        '
        'ON_B
        '
        Me.ON_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ON_B.CornerRadius = 10
        Me.ON_B.Location = New System.Drawing.Point(757, 71)
        Me.ON_B.Name = "ON_B"
        Me.ON_B.Size = New System.Drawing.Size(103, 30)
        Me.ON_B.TabIndex = 13
        Me.ON_B.TextButton = "すべてOn"
        '
        'OFF_B
        '
        Me.OFF_B.ColorBottom = System.Drawing.Color.Wheat
        Me.OFF_B.CornerRadius = 10
        Me.OFF_B.Location = New System.Drawing.Point(757, 107)
        Me.OFF_B.Name = "OFF_B"
        Me.OFF_B.Size = New System.Drawing.Size(103, 30)
        Me.OFF_B.TabIndex = 14
        Me.OFF_B.TextButton = "すべてOff"
        '
        'ORDER_B
        '
        Me.ORDER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ORDER_B.CornerRadius = 10
        Me.ORDER_B.Location = New System.Drawing.Point(866, 71)
        Me.ORDER_B.Name = "ORDER_B"
        Me.ORDER_B.Size = New System.Drawing.Size(144, 66)
        Me.ORDER_B.TabIndex = 9
        Me.ORDER_B.TextButton = "注文書作成"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CLOSE_B.CornerRadius = 15
        Me.CLOSE_B.Location = New System.Drawing.Point(866, 697)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(144, 55)
        Me.CLOSE_B.TabIndex = 15
        Me.CLOSE_B.TextButton = "終　了"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.E_SHOP_C)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.AMAZON_C)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.RAKUTEN_C)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.YAHOO_C)
        Me.GroupBox2.Location = New System.Drawing.Point(111, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 41)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(272, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "e-Shop："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'E_SHOP_C
        '
        Me.E_SHOP_C.AutoSize = True
        Me.E_SHOP_C.Location = New System.Drawing.Point(329, 15)
        Me.E_SHOP_C.Name = "E_SHOP_C"
        Me.E_SHOP_C.Size = New System.Drawing.Size(15, 14)
        Me.E_SHOP_C.TabIndex = 18
        Me.E_SHOP_C.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(182, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Amazon："
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AMAZON_C
        '
        Me.AMAZON_C.AutoSize = True
        Me.AMAZON_C.Location = New System.Drawing.Point(239, 15)
        Me.AMAZON_C.Name = "AMAZON_C"
        Me.AMAZON_C.Size = New System.Drawing.Size(15, 14)
        Me.AMAZON_C.TabIndex = 16
        Me.AMAZON_C.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(110, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "楽天："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RAKUTEN_C
        '
        Me.RAKUTEN_C.AutoSize = True
        Me.RAKUTEN_C.Location = New System.Drawing.Point(150, 16)
        Me.RAKUTEN_C.Name = "RAKUTEN_C"
        Me.RAKUTEN_C.Size = New System.Drawing.Size(15, 14)
        Me.RAKUTEN_C.TabIndex = 14
        Me.RAKUTEN_C.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(47, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "掲載状況："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(509, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "選択："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SELECT_C
        '
        Me.SELECT_C.AutoSize = True
        Me.SELECT_C.Location = New System.Drawing.Point(548, 111)
        Me.SELECT_C.Name = "SELECT_C"
        Me.SELECT_C.Size = New System.Drawing.Size(15, 14)
        Me.SELECT_C.TabIndex = 38
        Me.SELECT_C.UseVisualStyleBackColor = True
        '
        'fProductListCsvOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 771)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.SELECT_C)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TOTAL_COUNT_T)
        Me.Controls.Add(Me.JANCODE_T)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.MAKER_L)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PRODUCT_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.OFF_B)
        Me.Controls.Add(Me.ON_B)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.ORDER_B)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fProductListCsvOutput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "発注画面"
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MAKER_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_V As System.Windows.Forms.DataGridView
    Friend WithEvents YAHOO_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TOTAL_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ORDER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents ON_B As Softgroup.NetButton.NetButton
    Friend WithEvents OFF_B As Softgroup.NetButton.NetButton
    Friend WithEvents ORDER_B As Softgroup.NetButton.NetButton
    Friend WithEvents ORDER_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents ORDER_REPORT_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents E_SHOP_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents AMAZON_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents RAKUTEN_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SELECT_C As System.Windows.Forms.CheckBox

End Class
