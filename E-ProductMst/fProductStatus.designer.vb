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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(168, 81)
        Me.PRODUCT_CODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(132, 20)
        Me.PRODUCT_CODE_T.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(69, 85)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.SUPPLIER_L.Location = New System.Drawing.Point(449, 110)
        Me.SUPPLIER_L.Margin = New System.Windows.Forms.Padding(4)
        Me.SUPPLIER_L.Name = "SUPPLIER_L"
        Me.SUPPLIER_L.Size = New System.Drawing.Size(308, 21)
        Me.SUPPLIER_L.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(369, 115)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.Label3.Location = New System.Drawing.Point(69, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(168, 24)
        Me.PRODUCT_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(465, 20)
        Me.PRODUCT_NAME_T.TabIndex = 1
        '
        'PRODUCT_V
        '
        Me.PRODUCT_V.AllowUserToAddRows = False
        Me.PRODUCT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.PRODUCT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.PRODUCT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCT_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.PRODUCT_V.Location = New System.Drawing.Point(31, 146)
        Me.PRODUCT_V.Margin = New System.Windows.Forms.Padding(4)
        Me.PRODUCT_V.Name = "PRODUCT_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.PRODUCT_V.RowTemplate.Height = 21
        Me.PRODUCT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PRODUCT_V.Size = New System.Drawing.Size(1300, 631)
        Me.PRODUCT_V.TabIndex = 11
        Me.PRODUCT_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Tan
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(53, 111)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 24)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "JANコード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(168, 110)
        Me.JANCODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(172, 20)
        Me.JANCODE_T.TabIndex = 4
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(715, 112)
        Me.SUPPLIER_CODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.SUPPLIER_CODE_T.TabIndex = 21
        Me.SUPPLIER_CODE_T.Visible = False
        '
        'S_PRODUCT_CODE_T
        '
        Me.S_PRODUCT_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_PRODUCT_CODE_T.Location = New System.Drawing.Point(276, 81)
        Me.S_PRODUCT_CODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.S_PRODUCT_CODE_T.Name = "S_PRODUCT_CODE_T"
        Me.S_PRODUCT_CODE_T.Size = New System.Drawing.Size(24, 19)
        Me.S_PRODUCT_CODE_T.TabIndex = 23
        Me.S_PRODUCT_CODE_T.Visible = False
        '
        'MAKER_NAME_T
        '
        Me.MAKER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MAKER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MAKER_NAME_T.Location = New System.Drawing.Point(449, 81)
        Me.MAKER_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.MAKER_NAME_T.Name = "MAKER_NAME_T"
        Me.MAKER_NAME_T.Size = New System.Drawing.Size(184, 20)
        Me.MAKER_NAME_T.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(329, 86)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "メーカー名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'S_JAN_CODE_T
        '
        Me.S_JAN_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_JAN_CODE_T.Location = New System.Drawing.Point(316, 111)
        Me.S_JAN_CODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.S_JAN_CODE_T.Name = "S_JAN_CODE_T"
        Me.S_JAN_CODE_T.Size = New System.Drawing.Size(24, 19)
        Me.S_JAN_CODE_T.TabIndex = 27
        Me.S_JAN_CODE_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(168, 52)
        Me.OPTION_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(465, 20)
        Me.OPTION_NAME_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Tan
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(39, 54)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.GroupBox3.Location = New System.Drawing.Point(856, 79)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(236, 58)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "【取扱状況】"
        '
        'STOPSUPPLIE_C
        '
        Me.STOPSUPPLIE_C.AutoSize = True
        Me.STOPSUPPLIE_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STOPSUPPLIE_C.Location = New System.Drawing.Point(119, 22)
        Me.STOPSUPPLIE_C.Margin = New System.Windows.Forms.Padding(4)
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
        Me.STOPSALE_C.Location = New System.Drawing.Point(12, 22)
        Me.STOPSALE_C.Margin = New System.Windows.Forms.Padding(4)
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
        Me.GroupBox1.Location = New System.Drawing.Point(692, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(400, 56)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【商品種別】"
        '
        'SYUBETU_3_R
        '
        Me.SYUBETU_3_R.AutoSize = True
        Me.SYUBETU_3_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_3_R.Location = New System.Drawing.Point(285, 21)
        Me.SYUBETU_3_R.Margin = New System.Windows.Forms.Padding(4)
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
        Me.SYUBETU_2_R.Location = New System.Drawing.Point(136, 21)
        Me.SYUBETU_2_R.Margin = New System.Windows.Forms.Padding(4)
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
        Me.SYUBETU_1_R.Location = New System.Drawing.Point(11, 20)
        Me.SYUBETU_1_R.Margin = New System.Windows.Forms.Padding(4)
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
        Me.RETURN_B.Location = New System.Drawing.Point(1180, 796)
        Me.RETURN_B.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(151, 58)
        Me.RETURN_B.TabIndex = 12
        Me.RETURN_B.TextButton = "終了"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(1100, 79)
        Me.SEARCH_B.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(236, 58)
        Me.SEARCH_B.TabIndex = 10
        Me.SEARCH_B.TextButton = "検　索"
        '
        'S_PRODUCT_NAME_T
        '
        Me.S_PRODUCT_NAME_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_PRODUCT_NAME_T.Location = New System.Drawing.Point(643, 24)
        Me.S_PRODUCT_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.S_PRODUCT_NAME_T.Name = "S_PRODUCT_NAME_T"
        Me.S_PRODUCT_NAME_T.Size = New System.Drawing.Size(24, 19)
        Me.S_PRODUCT_NAME_T.TabIndex = 30
        Me.S_PRODUCT_NAME_T.Visible = False
        '
        'S_OPTION_NAME_T
        '
        Me.S_OPTION_NAME_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_OPTION_NAME_T.Location = New System.Drawing.Point(643, 49)
        Me.S_OPTION_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.S_OPTION_NAME_T.Name = "S_OPTION_NAME_T"
        Me.S_OPTION_NAME_T.Size = New System.Drawing.Size(24, 19)
        Me.S_OPTION_NAME_T.TabIndex = 31
        Me.S_OPTION_NAME_T.Visible = False
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(1005, 796)
        Me.COMMIT_B.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(151, 58)
        Me.COMMIT_B.TabIndex = 32
        Me.COMMIT_B.TextButton = "登録"
        '
        'SELECT_CNT_T
        '
        Me.SELECT_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SELECT_CNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SELECT_CNT_T.Location = New System.Drawing.Point(1197, 30)
        Me.SELECT_CNT_T.Margin = New System.Windows.Forms.Padding(4)
        Me.SELECT_CNT_T.Name = "SELECT_CNT_T"
        Me.SELECT_CNT_T.Size = New System.Drawing.Size(132, 22)
        Me.SELECT_CNT_T.TabIndex = 33
        Me.SELECT_CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Tan
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(1100, 35)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(100, 812)
        Me.STAFF_CODE_T.Margin = New System.Windows.Forms.Padding(4)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(115, 19)
        Me.STAFF_CODE_T.TabIndex = 36
        Me.STAFF_CODE_T.TabStop = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(224, 812)
        Me.STAFF_NAME_T.Margin = New System.Windows.Forms.Padding(4)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(255, 19)
        Me.STAFF_NAME_T.TabIndex = 35
        Me.STAFF_NAME_T.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 818)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "担当者："
        '
        'fProductStatus
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1365, 869)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fProductStatus"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
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
