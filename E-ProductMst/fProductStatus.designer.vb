<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProductStatus
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
        Me.SUPPLIER_L = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.PRODUCT_V = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.JANCODE_T = New System.Windows.Forms.TextBox()
        Me.SUPPLIER_CODE_T = New System.Windows.Forms.TextBox()
        Me.S_PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.MAKER_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.S_JAN_CODE_T = New System.Windows.Forms.TextBox()
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.STOPSUPPLIE_C = New System.Windows.Forms.CheckBox()
        Me.STOPSALE_C = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SYUBETU_3_R = New System.Windows.Forms.RadioButton()
        Me.SYUBETU_2_R = New System.Windows.Forms.RadioButton()
        Me.SYUBETU_1_R = New System.Windows.Forms.RadioButton()
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.S_PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.S_OPTION_NAME_T = New System.Windows.Forms.TextBox()
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SELECT_CNT_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(126, 65)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(52, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "商品番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SUPPLIER_L
        '
        Me.SUPPLIER_L.DropDownHeight = 300
        Me.SUPPLIER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_L.FormattingEnabled = True
        Me.SUPPLIER_L.IntegralHeight = False
        Me.SUPPLIER_L.Location = New System.Drawing.Point(337, 88)
        Me.SUPPLIER_L.Name = "SUPPLIER_L"
        Me.SUPPLIER_L.Size = New System.Drawing.Size(232, 21)
        Me.SUPPLIER_L.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(277, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "仕入先："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Tan
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(52, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(126, 19)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(350, 20)
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
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.PRODUCT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCT_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.PRODUCT_V.Location = New System.Drawing.Point(23, 117)
        Me.PRODUCT_V.Name = "PRODUCT_V"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.PRODUCT_V.RowTemplate.Height = 21
        Me.PRODUCT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PRODUCT_V.Size = New System.Drawing.Size(975, 505)
        Me.PRODUCT_V.TabIndex = 11
        Me.PRODUCT_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Tan
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(40, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "JANコード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(126, 88)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(130, 20)
        Me.JANCODE_T.TabIndex = 4
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(536, 90)
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(15, 19)
        Me.SUPPLIER_CODE_T.TabIndex = 21
        Me.SUPPLIER_CODE_T.Visible = False
        '
        'S_PRODUCT_CODE_T
        '
        Me.S_PRODUCT_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_PRODUCT_CODE_T.Location = New System.Drawing.Point(207, 65)
        Me.S_PRODUCT_CODE_T.Name = "S_PRODUCT_CODE_T"
        Me.S_PRODUCT_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.S_PRODUCT_CODE_T.TabIndex = 23
        Me.S_PRODUCT_CODE_T.Visible = False
        '
        'MAKER_NAME_T
        '
        Me.MAKER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MAKER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MAKER_NAME_T.Location = New System.Drawing.Point(337, 65)
        Me.MAKER_NAME_T.Name = "MAKER_NAME_T"
        Me.MAKER_NAME_T.Size = New System.Drawing.Size(139, 20)
        Me.MAKER_NAME_T.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(247, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "メーカー名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'S_JAN_CODE_T
        '
        Me.S_JAN_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_JAN_CODE_T.Location = New System.Drawing.Point(237, 89)
        Me.S_JAN_CODE_T.Name = "S_JAN_CODE_T"
        Me.S_JAN_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.S_JAN_CODE_T.TabIndex = 27
        Me.S_JAN_CODE_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(126, 42)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(350, 20)
        Me.OPTION_NAME_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Tan
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(29, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "オプション名称："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.STOPSUPPLIE_C)
        Me.GroupBox3.Controls.Add(Me.STOPSALE_C)
        Me.GroupBox3.Location = New System.Drawing.Point(642, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(177, 46)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "【取扱状況】"
        '
        'STOPSUPPLIE_C
        '
        Me.STOPSUPPLIE_C.AutoSize = True
        Me.STOPSUPPLIE_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STOPSUPPLIE_C.Location = New System.Drawing.Point(89, 18)
        Me.STOPSUPPLIE_C.Name = "STOPSUPPLIE_C"
        Me.STOPSUPPLIE_C.Size = New System.Drawing.Size(78, 17)
        Me.STOPSUPPLIE_C.TabIndex = 159
        Me.STOPSUPPLIE_C.Text = "仕入停止"
        Me.STOPSUPPLIE_C.UseVisualStyleBackColor = True
        '
        'STOPSALE_C
        '
        Me.STOPSALE_C.AutoSize = True
        Me.STOPSALE_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STOPSALE_C.Location = New System.Drawing.Point(9, 18)
        Me.STOPSALE_C.Name = "STOPSALE_C"
        Me.STOPSALE_C.Size = New System.Drawing.Size(78, 17)
        Me.STOPSALE_C.TabIndex = 141
        Me.STOPSALE_C.Text = "販売停止"
        Me.STOPSALE_C.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SYUBETU_3_R)
        Me.GroupBox1.Controls.Add(Me.SYUBETU_2_R)
        Me.GroupBox1.Controls.Add(Me.SYUBETU_1_R)
        Me.GroupBox1.Location = New System.Drawing.Point(519, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(300, 45)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【商品種別】"
        '
        'SYUBETU_3_R
        '
        Me.SYUBETU_3_R.AutoSize = True
        Me.SYUBETU_3_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_3_R.Location = New System.Drawing.Point(214, 17)
        Me.SYUBETU_3_R.Name = "SYUBETU_3_R"
        Me.SYUBETU_3_R.Size = New System.Drawing.Size(77, 17)
        Me.SYUBETU_3_R.TabIndex = 15
        Me.SYUBETU_3_R.Text = "疑似品目"
        Me.SYUBETU_3_R.UseVisualStyleBackColor = True
        '
        'SYUBETU_2_R
        '
        Me.SYUBETU_2_R.AutoSize = True
        Me.SYUBETU_2_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_2_R.Location = New System.Drawing.Point(102, 17)
        Me.SYUBETU_2_R.Name = "SYUBETU_2_R"
        Me.SYUBETU_2_R.Size = New System.Drawing.Size(92, 17)
        Me.SYUBETU_2_R.TabIndex = 1
        Me.SYUBETU_2_R.Text = "サービス品目"
        Me.SYUBETU_2_R.UseVisualStyleBackColor = True
        '
        'SYUBETU_1_R
        '
        Me.SYUBETU_1_R.AutoSize = True
        Me.SYUBETU_1_R.Checked = True
        Me.SYUBETU_1_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_1_R.Location = New System.Drawing.Point(8, 16)
        Me.SYUBETU_1_R.Name = "SYUBETU_1_R"
        Me.SYUBETU_1_R.Size = New System.Drawing.Size(77, 17)
        Me.SYUBETU_1_R.TabIndex = 14
        Me.SYUBETU_1_R.TabStop = True
        Me.SYUBETU_1_R.Text = "在庫品目"
        Me.SYUBETU_1_R.UseVisualStyleBackColor = True
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(885, 637)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(113, 46)
        Me.RETURN_B.TabIndex = 12
        Me.RETURN_B.TextButton = "終了"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(825, 63)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(177, 46)
        Me.SEARCH_B.TabIndex = 10
        Me.SEARCH_B.TextButton = "検　索"
        '
        'S_PRODUCT_NAME_T
        '
        Me.S_PRODUCT_NAME_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_PRODUCT_NAME_T.Location = New System.Drawing.Point(482, 19)
        Me.S_PRODUCT_NAME_T.Name = "S_PRODUCT_NAME_T"
        Me.S_PRODUCT_NAME_T.Size = New System.Drawing.Size(19, 19)
        Me.S_PRODUCT_NAME_T.TabIndex = 30
        Me.S_PRODUCT_NAME_T.Visible = False
        '
        'S_OPTION_NAME_T
        '
        Me.S_OPTION_NAME_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_OPTION_NAME_T.Location = New System.Drawing.Point(482, 39)
        Me.S_OPTION_NAME_T.Name = "S_OPTION_NAME_T"
        Me.S_OPTION_NAME_T.Size = New System.Drawing.Size(19, 19)
        Me.S_OPTION_NAME_T.TabIndex = 31
        Me.S_OPTION_NAME_T.Visible = False
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(754, 637)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(113, 46)
        Me.COMMIT_B.TabIndex = 32
        Me.COMMIT_B.TextButton = "登録"
        '
        'SELECT_CNT_T
        '
        Me.SELECT_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SELECT_CNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SELECT_CNT_T.Location = New System.Drawing.Point(898, 24)
        Me.SELECT_CNT_T.Name = "SELECT_CNT_T"
        Me.SELECT_CNT_T.Size = New System.Drawing.Size(100, 22)
        Me.SELECT_CNT_T.TabIndex = 33
        Me.SELECT_CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Tan
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(825, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "抽出件数："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(75, 650)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(87, 19)
        Me.STAFF_CODE_T.TabIndex = 36
        Me.STAFF_CODE_T.TabStop = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(168, 650)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(192, 19)
        Me.STAFF_NAME_T.TabIndex = 35
        Me.STAFF_NAME_T.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 654)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "担当者："
        '
        'fProductStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 695)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.SELECT_CNT_T)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.S_OPTION_NAME_T)
        Me.Controls.Add(Me.S_PRODUCT_NAME_T)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.SUPPLIER_CODE_T)
        Me.Controls.Add(Me.S_JAN_CODE_T)
        Me.Controls.Add(Me.S_PRODUCT_CODE_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MAKER_NAME_T)
        Me.Controls.Add(Me.SUPPLIER_L)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.JANCODE_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PRODUCT_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fProductStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品ステータス更新画面"
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SUPPLIER_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents SUPPLIER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MAKER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents STOPSALE_C As System.Windows.Forms.CheckBox
    Friend WithEvents STOPSUPPLIE_C As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SYUBETU_2_R As System.Windows.Forms.RadioButton
    Friend WithEvents SYUBETU_1_R As System.Windows.Forms.RadioButton
    Public WithEvents S_PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents S_JAN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents SYUBETU_3_R As System.Windows.Forms.RadioButton
    Public WithEvents S_PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Public WithEvents S_OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents SELECT_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
