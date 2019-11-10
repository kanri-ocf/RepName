<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShopRequestReport
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
        Me.ORDER_NUMBER_L = New System.Windows.Forms.Label
        Me.REQUEST_CODE_T = New System.Windows.Forms.TextBox
        Me.MEMO_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.REQUEST_V = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.TITLE_L = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.FEE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.POSTAGE_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.P_DISCOUNT_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DISCOUNT_T = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BEFORE_TAX_PRODUCT_T = New System.Windows.Forms.TextBox
        Me.TOTAL_L = New System.Windows.Forms.Label
        Me.BEFORE_TAX_REQUEST_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.AFTER_TAX_REQUEST_T = New System.Windows.Forms.TextBox
        Me.TAX_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.EDIT_L = New System.Windows.Forms.Label
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PRINT_START_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.EXIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BILL_TEL_T = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.BILL_CUSTOMER_2ND_NAME_T = New System.Windows.Forms.TextBox
        Me.BILL_CUSTOMER_1ST_NAME_T = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.BILL_ADDR_4_T = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.BILL_ADDR_3_T = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BILL_ADDR_2_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.BILL_ADDR_1_T = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.REQUEST_DATE_T = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.SHIP_TEL_T = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.SHIP_CUSTOMER_2ND_NAME_T = New System.Windows.Forms.TextBox
        Me.SHIP_CUSTOMER_1ST_NAME_T = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.SHIP_ADDR_4_T = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.SHIP_ADDR_3_T = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.SHIP_ADDR_2_T = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.SHIP_ADDR_1_T = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ORDER_NUMBER_L
        '
        Me.ORDER_NUMBER_L.AutoSize = True
        Me.ORDER_NUMBER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_NUMBER_L.Location = New System.Drawing.Point(27, 48)
        Me.ORDER_NUMBER_L.Name = "ORDER_NUMBER_L"
        Me.ORDER_NUMBER_L.Size = New System.Drawing.Size(66, 13)
        Me.ORDER_NUMBER_L.TabIndex = 5
        Me.ORDER_NUMBER_L.Text = "注文番号："
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(91, 44)
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.ReadOnly = True
        Me.REQUEST_CODE_T.Size = New System.Drawing.Size(142, 20)
        Me.REQUEST_CODE_T.TabIndex = 4
        Me.REQUEST_CODE_T.TabStop = False
        '
        'MEMO_T
        '
        Me.MEMO_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO_T.Location = New System.Drawing.Point(553, 464)
        Me.MEMO_T.Margin = New System.Windows.Forms.Padding(20)
        Me.MEMO_T.MaxLength = 496
        Me.MEMO_T.Multiline = True
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Size = New System.Drawing.Size(443, 103)
        Me.MEMO_T.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(550, 448)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "備考  (７０文字 × ７行 以内)"
        '
        'REQUEST_V
        '
        Me.REQUEST_V.AllowUserToAddRows = False
        Me.REQUEST_V.AllowUserToDeleteRows = False
        Me.REQUEST_V.AllowUserToResizeColumns = False
        Me.REQUEST_V.AllowUserToResizeRows = False
        Me.REQUEST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.REQUEST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.REQUEST_V.ColumnHeadersHeight = 21
        Me.REQUEST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.REQUEST_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.REQUEST_V.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQUEST_V.Location = New System.Drawing.Point(26, 251)
        Me.REQUEST_V.MultiSelect = False
        Me.REQUEST_V.Name = "REQUEST_V"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.REQUEST_V.RowTemplate.Height = 21
        Me.REQUEST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.REQUEST_V.Size = New System.Drawing.Size(970, 179)
        Me.REQUEST_V.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(553, 578)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "注文担当者："
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(558, 595)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(99, 20)
        Me.STAFF_CODE_T.TabIndex = 25
        Me.STAFF_CODE_T.TabStop = False
        Me.STAFF_CODE_T.Text = "1234567890123"
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(558, 616)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(175, 20)
        Me.STAFF_NAME_T.TabIndex = 27
        Me.STAFF_NAME_T.TabStop = False
        '
        'TITLE_L
        '
        Me.TITLE_L.BackColor = System.Drawing.Color.Red
        Me.TITLE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TITLE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TITLE_L.ForeColor = System.Drawing.Color.White
        Me.TITLE_L.Location = New System.Drawing.Point(26, 11)
        Me.TITLE_L.Name = "TITLE_L"
        Me.TITLE_L.Size = New System.Drawing.Size(970, 18)
        Me.TITLE_L.TabIndex = 30
        Me.TITLE_L.Text = "注文伝票作成中"
        Me.TITLE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.BurlyWood
        Me.GroupBox2.Controls.Add(Me.FEE_T)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.POSTAGE_T)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.P_DISCOUNT_T)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DISCOUNT_T)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.BEFORE_TAX_PRODUCT_T)
        Me.GroupBox2.Controls.Add(Me.TOTAL_L)
        Me.GroupBox2.Controls.Add(Me.BEFORE_TAX_REQUEST_T)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.AFTER_TAX_REQUEST_T)
        Me.GroupBox2.Controls.Add(Me.TAX_T)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox2.Location = New System.Drawing.Point(553, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(252, 192)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【注文金額】"
        '
        'FEE_T
        '
        Me.FEE_T.BackColor = System.Drawing.Color.White
        Me.FEE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FEE_T.Location = New System.Drawing.Point(100, 51)
        Me.FEE_T.Name = "FEE_T"
        Me.FEE_T.Size = New System.Drawing.Size(140, 20)
        Me.FEE_T.TabIndex = 2
        Me.FEE_T.Text = "0"
        Me.FEE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "手数料："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'POSTAGE_T
        '
        Me.POSTAGE_T.BackColor = System.Drawing.Color.White
        Me.POSTAGE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAGE_T.Location = New System.Drawing.Point(100, 31)
        Me.POSTAGE_T.Name = "POSTAGE_T"
        Me.POSTAGE_T.Size = New System.Drawing.Size(140, 20)
        Me.POSTAGE_T.TabIndex = 1
        Me.POSTAGE_T.Text = "0"
        Me.POSTAGE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(57, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "送料："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_DISCOUNT_T
        '
        Me.P_DISCOUNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.P_DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_DISCOUNT_T.Location = New System.Drawing.Point(100, 91)
        Me.P_DISCOUNT_T.Name = "P_DISCOUNT_T"
        Me.P_DISCOUNT_T.Size = New System.Drawing.Size(140, 20)
        Me.P_DISCOUNT_T.TabIndex = 4
        Me.P_DISCOUNT_T.Text = "0"
        Me.P_DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "ポイント値引き："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DISCOUNT_T
        '
        Me.DISCOUNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DISCOUNT_T.Location = New System.Drawing.Point(100, 71)
        Me.DISCOUNT_T.Name = "DISCOUNT_T"
        Me.DISCOUNT_T.Size = New System.Drawing.Size(140, 20)
        Me.DISCOUNT_T.TabIndex = 3
        Me.DISCOUNT_T.Text = "0"
        Me.DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "値引き："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BEFORE_TAX_PRODUCT_T
        '
        Me.BEFORE_TAX_PRODUCT_T.BackColor = System.Drawing.Color.Wheat
        Me.BEFORE_TAX_PRODUCT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BEFORE_TAX_PRODUCT_T.Location = New System.Drawing.Point(100, 11)
        Me.BEFORE_TAX_PRODUCT_T.Name = "BEFORE_TAX_PRODUCT_T"
        Me.BEFORE_TAX_PRODUCT_T.ReadOnly = True
        Me.BEFORE_TAX_PRODUCT_T.Size = New System.Drawing.Size(140, 20)
        Me.BEFORE_TAX_PRODUCT_T.TabIndex = 1
        Me.BEFORE_TAX_PRODUCT_T.TabStop = False
        Me.BEFORE_TAX_PRODUCT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TOTAL_L
        '
        Me.TOTAL_L.AutoSize = True
        Me.TOTAL_L.BackColor = System.Drawing.Color.BurlyWood
        Me.TOTAL_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_L.Location = New System.Drawing.Point(31, 15)
        Me.TOTAL_L.Name = "TOTAL_L"
        Me.TOTAL_L.Size = New System.Drawing.Size(66, 13)
        Me.TOTAL_L.TabIndex = 38
        Me.TOTAL_L.Text = "商品代金："
        Me.TOTAL_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BEFORE_TAX_REQUEST_T
        '
        Me.BEFORE_TAX_REQUEST_T.BackColor = System.Drawing.Color.Wheat
        Me.BEFORE_TAX_REQUEST_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BEFORE_TAX_REQUEST_T.Location = New System.Drawing.Point(100, 118)
        Me.BEFORE_TAX_REQUEST_T.Name = "BEFORE_TAX_REQUEST_T"
        Me.BEFORE_TAX_REQUEST_T.ReadOnly = True
        Me.BEFORE_TAX_REQUEST_T.Size = New System.Drawing.Size(140, 20)
        Me.BEFORE_TAX_REQUEST_T.TabIndex = 35
        Me.BEFORE_TAX_REQUEST_T.TabStop = False
        Me.BEFORE_TAX_REQUEST_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "税抜発注金額："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AFTER_TAX_REQUEST_T
        '
        Me.AFTER_TAX_REQUEST_T.BackColor = System.Drawing.Color.Wheat
        Me.AFTER_TAX_REQUEST_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AFTER_TAX_REQUEST_T.Location = New System.Drawing.Point(100, 165)
        Me.AFTER_TAX_REQUEST_T.Name = "AFTER_TAX_REQUEST_T"
        Me.AFTER_TAX_REQUEST_T.ReadOnly = True
        Me.AFTER_TAX_REQUEST_T.Size = New System.Drawing.Size(140, 20)
        Me.AFTER_TAX_REQUEST_T.TabIndex = 23
        Me.AFTER_TAX_REQUEST_T.TabStop = False
        Me.AFTER_TAX_REQUEST_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAX_T
        '
        Me.TAX_T.BackColor = System.Drawing.Color.Wheat
        Me.TAX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_T.Location = New System.Drawing.Point(100, 139)
        Me.TAX_T.Name = "TAX_T"
        Me.TAX_T.ReadOnly = True
        Me.TAX_T.Size = New System.Drawing.Size(140, 20)
        Me.TAX_T.TabIndex = 26
        Me.TAX_T.TabStop = False
        Me.TAX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "税込発注金額："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(32, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "消費税額："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 15)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(246, 174)
        Me.ShapeContainer1.TabIndex = 48
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Brown
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 2
        Me.LineShape2.X2 = 243
        Me.LineShape2.Y1 = 146
        Me.LineShape2.Y2 = 147
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Brown
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 2
        Me.LineShape1.X2 = 243
        Me.LineShape1.Y1 = 99
        Me.LineShape1.Y2 = 100
        '
        'EDIT_L
        '
        Me.EDIT_L.BackColor = System.Drawing.Color.Red
        Me.EDIT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EDIT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EDIT_L.ForeColor = System.Drawing.Color.White
        Me.EDIT_L.Location = New System.Drawing.Point(26, 646)
        Me.EDIT_L.Name = "EDIT_L"
        Me.EDIT_L.Size = New System.Drawing.Size(970, 18)
        Me.EDIT_L.TabIndex = 34
        Me.EDIT_L.Text = "注文伝票作成中"
        Me.EDIT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(829, 44)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(167, 60)
        Me.RETURN_B.TabIndex = 10
        Me.RETURN_B.TextButton = "検索画面に戻る"
        '
        'PRINT_START_B
        '
        Me.PRINT_START_B.ColorBottom = System.Drawing.Color.Tan
        Me.PRINT_START_B.Location = New System.Drawing.Point(750, 585)
        Me.PRINT_START_B.Name = "PRINT_START_B"
        Me.PRINT_START_B.Size = New System.Drawing.Size(120, 58)
        Me.PRINT_START_B.TabIndex = 8
        Me.PRINT_START_B.TextButton = "登録／伝票印刷"
        '
        'EXIT_B
        '
        Me.EXIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.EXIT_B.Location = New System.Drawing.Point(876, 585)
        Me.EXIT_B.Name = "EXIT_B"
        Me.EXIT_B.Size = New System.Drawing.Size(120, 58)
        Me.EXIT_B.TabIndex = 9
        Me.EXIT_B.TextButton = "終 了"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BILL_TEL_T)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.BILL_CUSTOMER_2ND_NAME_T)
        Me.GroupBox1.Controls.Add(Me.BILL_CUSTOMER_1ST_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.BILL_ADDR_4_T)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.BILL_ADDR_3_T)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.BILL_ADDR_2_T)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BILL_ADDR_1_T)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 169)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【注文者情報】"
        '
        'BILL_TEL_T
        '
        Me.BILL_TEL_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BILL_TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_TEL_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_TEL_T.Location = New System.Drawing.Point(80, 141)
        Me.BILL_TEL_T.Name = "BILL_TEL_T"
        Me.BILL_TEL_T.Size = New System.Drawing.Size(289, 20)
        Me.BILL_TEL_T.TabIndex = 58
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "電話番号："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(44, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(334, 13)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "住所：------------------------------------------"
        '
        'BILL_CUSTOMER_2ND_NAME_T
        '
        Me.BILL_CUSTOMER_2ND_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BILL_CUSTOMER_2ND_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_CUSTOMER_2ND_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_CUSTOMER_2ND_NAME_T.Location = New System.Drawing.Point(226, 14)
        Me.BILL_CUSTOMER_2ND_NAME_T.Name = "BILL_CUSTOMER_2ND_NAME_T"
        Me.BILL_CUSTOMER_2ND_NAME_T.Size = New System.Drawing.Size(143, 20)
        Me.BILL_CUSTOMER_2ND_NAME_T.TabIndex = 55
        '
        'BILL_CUSTOMER_1ST_NAME_T
        '
        Me.BILL_CUSTOMER_1ST_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BILL_CUSTOMER_1ST_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_CUSTOMER_1ST_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_CUSTOMER_1ST_NAME_T.Location = New System.Drawing.Point(81, 14)
        Me.BILL_CUSTOMER_1ST_NAME_T.Name = "BILL_CUSTOMER_1ST_NAME_T"
        Me.BILL_CUSTOMER_1ST_NAME_T.Size = New System.Drawing.Size(143, 20)
        Me.BILL_CUSTOMER_1ST_NAME_T.TabIndex = 54
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(7, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 53
        Me.Label30.Text = "お客様名称："
        '
        'BILL_ADDR_4_T
        '
        Me.BILL_ADDR_4_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_ADDR_4_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_ADDR_4_T.Location = New System.Drawing.Point(80, 120)
        Me.BILL_ADDR_4_T.Name = "BILL_ADDR_4_T"
        Me.BILL_ADDR_4_T.Size = New System.Drawing.Size(424, 20)
        Me.BILL_ADDR_4_T.TabIndex = 51
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(14, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 12)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "(上記以降)："
        '
        'BILL_ADDR_3_T
        '
        Me.BILL_ADDR_3_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_ADDR_3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_ADDR_3_T.Location = New System.Drawing.Point(81, 99)
        Me.BILL_ADDR_3_T.Name = "BILL_ADDR_3_T"
        Me.BILL_ADDR_3_T.Size = New System.Drawing.Size(423, 20)
        Me.BILL_ADDR_3_T.TabIndex = 49
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(38, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 12)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "(番地)："
        '
        'BILL_ADDR_2_T
        '
        Me.BILL_ADDR_2_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_ADDR_2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_ADDR_2_T.Location = New System.Drawing.Point(81, 78)
        Me.BILL_ADDR_2_T.Name = "BILL_ADDR_2_T"
        Me.BILL_ADDR_2_T.Size = New System.Drawing.Size(288, 20)
        Me.BILL_ADDR_2_T.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(14, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 12)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "(市区町村)："
        '
        'BILL_ADDR_1_T
        '
        Me.BILL_ADDR_1_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILL_ADDR_1_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.BILL_ADDR_1_T.Location = New System.Drawing.Point(81, 57)
        Me.BILL_ADDR_1_T.Name = "BILL_ADDR_1_T"
        Me.BILL_ADDR_1_T.Size = New System.Drawing.Size(143, 20)
        Me.BILL_ADDR_1_T.TabIndex = 45
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Blue
        Me.Label31.Location = New System.Drawing.Point(51, 62)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(31, 12)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "(県)："
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 436)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(291, 35)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "【出荷方法】"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(180, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "配送希望"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(68, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(79, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "店頭引取り"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'REQUEST_DATE_T
        '
        Me.REQUEST_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_DATE_T.Location = New System.Drawing.Point(294, 44)
        Me.REQUEST_DATE_T.Name = "REQUEST_DATE_T"
        Me.REQUEST_DATE_T.ReadOnly = True
        Me.REQUEST_DATE_T.Size = New System.Drawing.Size(173, 20)
        Me.REQUEST_DATE_T.TabIndex = 47
        Me.REQUEST_DATE_T.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(242, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "注文日："
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SHIP_TEL_T)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.SHIP_CUSTOMER_2ND_NAME_T)
        Me.GroupBox4.Controls.Add(Me.SHIP_CUSTOMER_1ST_NAME_T)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR_4_T)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR_3_T)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR_2_T)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR_1_T)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Location = New System.Drawing.Point(26, 474)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(521, 169)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "【出荷先情報】"
        '
        'SHIP_TEL_T
        '
        Me.SHIP_TEL_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SHIP_TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_TEL_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_TEL_T.Location = New System.Drawing.Point(80, 141)
        Me.SHIP_TEL_T.Name = "SHIP_TEL_T"
        Me.SHIP_TEL_T.Size = New System.Drawing.Size(289, 20)
        Me.SHIP_TEL_T.TabIndex = 58
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "電話番号："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(44, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(334, 13)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "住所：------------------------------------------"
        '
        'SHIP_CUSTOMER_2ND_NAME_T
        '
        Me.SHIP_CUSTOMER_2ND_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SHIP_CUSTOMER_2ND_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_CUSTOMER_2ND_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_CUSTOMER_2ND_NAME_T.Location = New System.Drawing.Point(226, 14)
        Me.SHIP_CUSTOMER_2ND_NAME_T.Name = "SHIP_CUSTOMER_2ND_NAME_T"
        Me.SHIP_CUSTOMER_2ND_NAME_T.Size = New System.Drawing.Size(143, 20)
        Me.SHIP_CUSTOMER_2ND_NAME_T.TabIndex = 55
        '
        'SHIP_CUSTOMER_1ST_NAME_T
        '
        Me.SHIP_CUSTOMER_1ST_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SHIP_CUSTOMER_1ST_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_CUSTOMER_1ST_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_CUSTOMER_1ST_NAME_T.Location = New System.Drawing.Point(81, 14)
        Me.SHIP_CUSTOMER_1ST_NAME_T.Name = "SHIP_CUSTOMER_1ST_NAME_T"
        Me.SHIP_CUSTOMER_1ST_NAME_T.Size = New System.Drawing.Size(143, 20)
        Me.SHIP_CUSTOMER_1ST_NAME_T.TabIndex = 54
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "お客様名称："
        '
        'SHIP_ADDR_4_T
        '
        Me.SHIP_ADDR_4_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR_4_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_ADDR_4_T.Location = New System.Drawing.Point(80, 120)
        Me.SHIP_ADDR_4_T.Name = "SHIP_ADDR_4_T"
        Me.SHIP_ADDR_4_T.Size = New System.Drawing.Size(424, 20)
        Me.SHIP_ADDR_4_T.TabIndex = 51
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(14, 125)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 12)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "(上記以降)："
        '
        'SHIP_ADDR_3_T
        '
        Me.SHIP_ADDR_3_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR_3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_ADDR_3_T.Location = New System.Drawing.Point(81, 99)
        Me.SHIP_ADDR_3_T.Name = "SHIP_ADDR_3_T"
        Me.SHIP_ADDR_3_T.Size = New System.Drawing.Size(423, 20)
        Me.SHIP_ADDR_3_T.TabIndex = 49
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(38, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 12)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "(番地)："
        '
        'SHIP_ADDR_2_T
        '
        Me.SHIP_ADDR_2_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR_2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_ADDR_2_T.Location = New System.Drawing.Point(81, 78)
        Me.SHIP_ADDR_2_T.Name = "SHIP_ADDR_2_T"
        Me.SHIP_ADDR_2_T.Size = New System.Drawing.Size(288, 20)
        Me.SHIP_ADDR_2_T.TabIndex = 47
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(14, 83)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 12)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "(市区町村)："
        '
        'SHIP_ADDR_1_T
        '
        Me.SHIP_ADDR_1_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR_1_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SHIP_ADDR_1_T.Location = New System.Drawing.Point(81, 57)
        Me.SHIP_ADDR_1_T.Name = "SHIP_ADDR_1_T"
        Me.SHIP_ADDR_1_T.Size = New System.Drawing.Size(143, 20)
        Me.SHIP_ADDR_1_T.TabIndex = 45
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(51, 62)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 12)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "(県)："
        '
        'fShopRequestReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(1028, 679)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.REQUEST_DATE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.EXIT_B)
        Me.Controls.Add(Me.PRINT_START_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.EDIT_L)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.MEMO_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.REQUEST_CODE_T)
        Me.Controls.Add(Me.TITLE_L)
        Me.Controls.Add(Me.REQUEST_V)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ORDER_NUMBER_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fShopRequestReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ORDER_NUMBER_L As System.Windows.Forms.Label
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MEMO_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents TITLE_L As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AFTER_TAX_REQUEST_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EDIT_L As System.Windows.Forms.Label
    Friend WithEvents BEFORE_TAX_REQUEST_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents P_DISCOUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DISCOUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BEFORE_TAX_PRODUCT_T As System.Windows.Forms.TextBox
    Friend WithEvents TOTAL_L As System.Windows.Forms.Label
    Friend WithEvents FEE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents POSTAGE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRINT_START_B As Softgroup.NetButton.NetButton
    Friend WithEvents EXIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BILL_CUSTOMER_2ND_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents BILL_CUSTOMER_1ST_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents BILL_ADDR_4_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BILL_ADDR_3_T As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BILL_ADDR_2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BILL_ADDR_1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents BILL_TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents REQUEST_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SHIP_TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents SHIP_CUSTOMER_2ND_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SHIP_CUSTOMER_1ST_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR_4_T As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR_3_T As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR_2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR_1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
