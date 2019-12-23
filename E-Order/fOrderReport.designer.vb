<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fOrderReport
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SUPPLIER_L = New System.Windows.Forms.Label()
        Me.ORDER_NUMBER_L = New System.Windows.Forms.Label()
        Me.ORDER_CODE_T = New System.Windows.Forms.TextBox()
        Me.DATE_L = New System.Windows.Forms.Label()
        Me.RQ_DATE_T = New System.Windows.Forms.TextBox()
        Me.PLACE_L = New System.Windows.Forms.Label()
        Me.RQ_PLACE_T = New System.Windows.Forms.TextBox()
        Me.PAYMENT_L = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MEMO_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ORDER_V = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.SUPPLIER_C = New System.Windows.Forms.ComboBox()
        Me.TITLE_L = New System.Windows.Forms.Label()
        Me.SUPPER_CODE_T = New System.Windows.Forms.TextBox()
        Me.MEISAI_KINGAKU_G = New System.Windows.Forms.GroupBox()
        Me.AFTER_TAX_R = New System.Windows.Forms.RadioButton()
        Me.BEFORE_TAX_R = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.P_DISCOUNT_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DISCOUNT_T = New System.Windows.Forms.TextBox()
        Me.RTAX_RATE_T = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FEE_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.POSTAGE_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BEFORE_TAX_PRODUCT_T = New System.Windows.Forms.TextBox()
        Me.TOTAL_L = New System.Windows.Forms.Label()
        Me.BEFORE_TAX_ORDER_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AFTER_TAX_ORDER_T = New System.Windows.Forms.TextBox()
        Me.TAX_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.EDIT_L = New System.Windows.Forms.Label()
        Me.TRN_RULE_T = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PRINT_START_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.EXIT_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.ORDER_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MEISAI_KINGAKU_G.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SUPPLIER_L
        '
        Me.SUPPLIER_L.AutoSize = True
        Me.SUPPLIER_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_L.Location = New System.Drawing.Point(81, 130)
        Me.SUPPLIER_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.SUPPLIER_L.Name = "SUPPLIER_L"
        Me.SUPPLIER_L.Size = New System.Drawing.Size(118, 30)
        Me.SUPPLIER_L.TabIndex = 3
        Me.SUPPLIER_L.Text = "注文先："
        '
        'ORDER_NUMBER_L
        '
        Me.ORDER_NUMBER_L.AutoSize = True
        Me.ORDER_NUMBER_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_NUMBER_L.Location = New System.Drawing.Point(50, 83)
        Me.ORDER_NUMBER_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ORDER_NUMBER_L.Name = "ORDER_NUMBER_L"
        Me.ORDER_NUMBER_L.Size = New System.Drawing.Size(148, 30)
        Me.ORDER_NUMBER_L.TabIndex = 5
        Me.ORDER_NUMBER_L.Text = "注文番号："
        '
        'ORDER_CODE_T
        '
        Me.ORDER_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.ORDER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_CODE_T.Location = New System.Drawing.Point(208, 78)
        Me.ORDER_CODE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ORDER_CODE_T.Name = "ORDER_CODE_T"
        Me.ORDER_CODE_T.ReadOnly = True
        Me.ORDER_CODE_T.Size = New System.Drawing.Size(303, 33)
        Me.ORDER_CODE_T.TabIndex = 4
        Me.ORDER_CODE_T.TabStop = False
        '
        'DATE_L
        '
        Me.DATE_L.AutoSize = True
        Me.DATE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DATE_L.Location = New System.Drawing.Point(50, 259)
        Me.DATE_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.DATE_L.Name = "DATE_L"
        Me.DATE_L.Size = New System.Drawing.Size(148, 30)
        Me.DATE_L.TabIndex = 9
        Me.DATE_L.Text = "納品期限："
        '
        'RQ_DATE_T
        '
        Me.RQ_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_DATE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RQ_DATE_T.Location = New System.Drawing.Point(208, 254)
        Me.RQ_DATE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.RQ_DATE_T.Name = "RQ_DATE_T"
        Me.RQ_DATE_T.Size = New System.Drawing.Size(303, 33)
        Me.RQ_DATE_T.TabIndex = 4
        Me.RQ_DATE_T.Text = "別途ご相談"
        '
        'PLACE_L
        '
        Me.PLACE_L.AutoSize = True
        Me.PLACE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PLACE_L.Location = New System.Drawing.Point(50, 216)
        Me.PLACE_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.PLACE_L.Name = "PLACE_L"
        Me.PLACE_L.Size = New System.Drawing.Size(148, 30)
        Me.PLACE_L.TabIndex = 11
        Me.PLACE_L.Text = "納品場所："
        '
        'RQ_PLACE_T
        '
        Me.RQ_PLACE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_PLACE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RQ_PLACE_T.Location = New System.Drawing.Point(208, 210)
        Me.RQ_PLACE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.RQ_PLACE_T.Name = "RQ_PLACE_T"
        Me.RQ_PLACE_T.Size = New System.Drawing.Size(752, 33)
        Me.RQ_PLACE_T.TabIndex = 3
        Me.RQ_PLACE_T.Text = "右記弊社事業所"
        '
        'PAYMENT_L
        '
        Me.PAYMENT_L.FormattingEnabled = True
        Me.PAYMENT_L.Location = New System.Drawing.Point(208, 166)
        Me.PAYMENT_L.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.PAYMENT_L.Name = "PAYMENT_L"
        Me.PAYMENT_L.Size = New System.Drawing.Size(435, 32)
        Me.PAYMENT_L.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 170)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 30)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "支払方法："
        '
        'MEMO_T
        '
        Me.MEMO_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO_T.Location = New System.Drawing.Point(713, 928)
        Me.MEMO_T.Margin = New System.Windows.Forms.Padding(42, 40, 42, 40)
        Me.MEMO_T.MaxLength = 496
        Me.MEMO_T.Multiline = True
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Size = New System.Drawing.Size(1440, 202)
        Me.MEMO_T.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(715, 896)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(330, 26)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "備考  (７０文字 × ７行 以内)"
        '
        'ORDER_V
        '
        Me.ORDER_V.AllowUserToAddRows = False
        Me.ORDER_V.AllowUserToDeleteRows = False
        Me.ORDER_V.AllowUserToResizeColumns = False
        Me.ORDER_V.AllowUserToResizeRows = False
        Me.ORDER_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.ORDER_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ORDER_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ORDER_V.ColumnHeadersHeight = 21
        Me.ORDER_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ORDER_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.ORDER_V.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ORDER_V.Location = New System.Drawing.Point(88, 317)
        Me.ORDER_V.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ORDER_V.MultiSelect = False
        Me.ORDER_V.Name = "ORDER_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ORDER_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ORDER_V.RowHeadersWidth = 82
        Me.ORDER_V.RowTemplate.Height = 21
        Me.ORDER_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ORDER_V.Size = New System.Drawing.Size(2103, 566)
        Me.ORDER_V.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(692, 1240)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(155, 26)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "発注担当者："
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(861, 1232)
        Me.STAFF_CODE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(210, 33)
        Me.STAFF_CODE_T.TabIndex = 25
        Me.STAFF_CODE_T.TabStop = False
        Me.STAFF_CODE_T.Text = "1234567890123"
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(1090, 1232)
        Me.STAFF_NAME_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(374, 33)
        Me.STAFF_NAME_T.TabIndex = 27
        Me.STAFF_NAME_T.TabStop = False
        '
        'SUPPLIER_C
        '
        Me.SUPPLIER_C.FormattingEnabled = True
        Me.SUPPLIER_C.Location = New System.Drawing.Point(208, 122)
        Me.SUPPLIER_C.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.SUPPLIER_C.Name = "SUPPLIER_C"
        Me.SUPPLIER_C.Size = New System.Drawing.Size(752, 32)
        Me.SUPPLIER_C.TabIndex = 1
        '
        'TITLE_L
        '
        Me.TITLE_L.BackColor = System.Drawing.Color.Red
        Me.TITLE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TITLE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TITLE_L.ForeColor = System.Drawing.Color.White
        Me.TITLE_L.Location = New System.Drawing.Point(55, 22)
        Me.TITLE_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.TITLE_L.Name = "TITLE_L"
        Me.TITLE_L.Size = New System.Drawing.Size(2103, 35)
        Me.TITLE_L.TabIndex = 30
        Me.TITLE_L.Text = "注文伝票作成中"
        Me.TITLE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SUPPER_CODE_T
        '
        Me.SUPPER_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.SUPPER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPER_CODE_T.Location = New System.Drawing.Point(882, 122)
        Me.SUPPER_CODE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.SUPPER_CODE_T.Name = "SUPPER_CODE_T"
        Me.SUPPER_CODE_T.ReadOnly = True
        Me.SUPPER_CODE_T.Size = New System.Drawing.Size(36, 37)
        Me.SUPPER_CODE_T.TabIndex = 31
        Me.SUPPER_CODE_T.TabStop = False
        Me.SUPPER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SUPPER_CODE_T.Visible = False
        '
        'MEISAI_KINGAKU_G
        '
        Me.MEISAI_KINGAKU_G.Controls.Add(Me.AFTER_TAX_R)
        Me.MEISAI_KINGAKU_G.Controls.Add(Me.BEFORE_TAX_R)
        Me.MEISAI_KINGAKU_G.Location = New System.Drawing.Point(1796, 195)
        Me.MEISAI_KINGAKU_G.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MEISAI_KINGAKU_G.Name = "MEISAI_KINGAKU_G"
        Me.MEISAI_KINGAKU_G.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MEISAI_KINGAKU_G.Size = New System.Drawing.Size(358, 94)
        Me.MEISAI_KINGAKU_G.TabIndex = 11
        Me.MEISAI_KINGAKU_G.TabStop = False
        Me.MEISAI_KINGAKU_G.Text = "【明細金額】"
        '
        'AFTER_TAX_R
        '
        Me.AFTER_TAX_R.AutoSize = True
        Me.AFTER_TAX_R.Location = New System.Drawing.Point(26, 38)
        Me.AFTER_TAX_R.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.AFTER_TAX_R.Name = "AFTER_TAX_R"
        Me.AFTER_TAX_R.Size = New System.Drawing.Size(110, 28)
        Me.AFTER_TAX_R.TabIndex = 1
        Me.AFTER_TAX_R.TabStop = True
        Me.AFTER_TAX_R.Text = "税込み"
        Me.AFTER_TAX_R.UseVisualStyleBackColor = True
        '
        'BEFORE_TAX_R
        '
        Me.BEFORE_TAX_R.AutoSize = True
        Me.BEFORE_TAX_R.Checked = True
        Me.BEFORE_TAX_R.Location = New System.Drawing.Point(219, 38)
        Me.BEFORE_TAX_R.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BEFORE_TAX_R.Name = "BEFORE_TAX_R"
        Me.BEFORE_TAX_R.Size = New System.Drawing.Size(107, 28)
        Me.BEFORE_TAX_R.TabIndex = 2
        Me.BEFORE_TAX_R.TabStop = True
        Me.BEFORE_TAX_R.Text = "税抜き"
        Me.BEFORE_TAX_R.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.BurlyWood
        Me.GroupBox2.Controls.Add(Me.P_DISCOUNT_T)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DISCOUNT_T)
        Me.GroupBox2.Controls.Add(Me.RTAX_RATE_T)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.FEE_T)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.POSTAGE_T)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.BEFORE_TAX_PRODUCT_T)
        Me.GroupBox2.Controls.Add(Me.TOTAL_L)
        Me.GroupBox2.Controls.Add(Me.BEFORE_TAX_ORDER_T)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.AFTER_TAX_ORDER_T)
        Me.GroupBox2.Controls.Add(Me.TAX_T)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox2.Location = New System.Drawing.Point(55, 896)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(624, 384)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【注文金額】"
        '
        'P_DISCOUNT_T
        '
        Me.P_DISCOUNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.P_DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_DISCOUNT_T.Location = New System.Drawing.Point(263, 306)
        Me.P_DISCOUNT_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.P_DISCOUNT_T.Name = "P_DISCOUNT_T"
        Me.P_DISCOUNT_T.Size = New System.Drawing.Size(300, 33)
        Me.P_DISCOUNT_T.TabIndex = 4
        Me.P_DISCOUNT_T.Text = "0"
        Me.P_DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(68, 309)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 26)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "ポイント値引き："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DISCOUNT_T
        '
        Me.DISCOUNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DISCOUNT_T.Location = New System.Drawing.Point(263, 266)
        Me.DISCOUNT_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.DISCOUNT_T.Name = "DISCOUNT_T"
        Me.DISCOUNT_T.Size = New System.Drawing.Size(300, 33)
        Me.DISCOUNT_T.TabIndex = 3
        Me.DISCOUNT_T.Text = "0"
        Me.DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RTAX_RATE_T
        '
        Me.RTAX_RATE_T.AcceptsReturn = True
        Me.RTAX_RATE_T.BackColor = System.Drawing.Color.Wheat
        Me.RTAX_RATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.RTAX_RATE_T.Location = New System.Drawing.Point(263, 222)
        Me.RTAX_RATE_T.Name = "RTAX_RATE_T"
        Me.RTAX_RATE_T.Size = New System.Drawing.Size(300, 33)
        Me.RTAX_RATE_T.TabIndex = 50
        Me.RTAX_RATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 24)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "軽減税額："
        '
        'FEE_T
        '
        Me.FEE_T.BackColor = System.Drawing.Color.White
        Me.FEE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FEE_T.Location = New System.Drawing.Point(263, 98)
        Me.FEE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.FEE_T.Name = "FEE_T"
        Me.FEE_T.Size = New System.Drawing.Size(300, 33)
        Me.FEE_T.TabIndex = 2
        Me.FEE_T.Text = "0"
        Me.FEE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(140, 106)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 26)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "手数料："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'POSTAGE_T
        '
        Me.POSTAGE_T.BackColor = System.Drawing.Color.White
        Me.POSTAGE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAGE_T.Location = New System.Drawing.Point(263, 54)
        Me.POSTAGE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.POSTAGE_T.Name = "POSTAGE_T"
        Me.POSTAGE_T.Size = New System.Drawing.Size(300, 33)
        Me.POSTAGE_T.TabIndex = 1
        Me.POSTAGE_T.Text = "0"
        Me.POSTAGE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(166, 62)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 26)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "送料："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 269)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 26)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "値引き："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BEFORE_TAX_PRODUCT_T
        '
        Me.BEFORE_TAX_PRODUCT_T.BackColor = System.Drawing.Color.Wheat
        Me.BEFORE_TAX_PRODUCT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BEFORE_TAX_PRODUCT_T.Location = New System.Drawing.Point(263, 18)
        Me.BEFORE_TAX_PRODUCT_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BEFORE_TAX_PRODUCT_T.Name = "BEFORE_TAX_PRODUCT_T"
        Me.BEFORE_TAX_PRODUCT_T.ReadOnly = True
        Me.BEFORE_TAX_PRODUCT_T.Size = New System.Drawing.Size(300, 33)
        Me.BEFORE_TAX_PRODUCT_T.TabIndex = 1
        Me.BEFORE_TAX_PRODUCT_T.TabStop = False
        Me.BEFORE_TAX_PRODUCT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TOTAL_L
        '
        Me.TOTAL_L.AutoSize = True
        Me.TOTAL_L.BackColor = System.Drawing.Color.BurlyWood
        Me.TOTAL_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_L.Location = New System.Drawing.Point(114, 22)
        Me.TOTAL_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.TOTAL_L.Name = "TOTAL_L"
        Me.TOTAL_L.Size = New System.Drawing.Size(129, 26)
        Me.TOTAL_L.TabIndex = 38
        Me.TOTAL_L.Text = "商品代金："
        Me.TOTAL_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BEFORE_TAX_ORDER_T
        '
        Me.BEFORE_TAX_ORDER_T.BackColor = System.Drawing.Color.Wheat
        Me.BEFORE_TAX_ORDER_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BEFORE_TAX_ORDER_T.Location = New System.Drawing.Point(263, 141)
        Me.BEFORE_TAX_ORDER_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BEFORE_TAX_ORDER_T.Name = "BEFORE_TAX_ORDER_T"
        Me.BEFORE_TAX_ORDER_T.ReadOnly = True
        Me.BEFORE_TAX_ORDER_T.Size = New System.Drawing.Size(300, 33)
        Me.BEFORE_TAX_ORDER_T.TabIndex = 35
        Me.BEFORE_TAX_ORDER_T.TabStop = False
        Me.BEFORE_TAX_ORDER_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 147)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 26)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "税抜発注金額："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AFTER_TAX_ORDER_T
        '
        Me.AFTER_TAX_ORDER_T.BackColor = System.Drawing.Color.Wheat
        Me.AFTER_TAX_ORDER_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AFTER_TAX_ORDER_T.Location = New System.Drawing.Point(263, 346)
        Me.AFTER_TAX_ORDER_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.AFTER_TAX_ORDER_T.Name = "AFTER_TAX_ORDER_T"
        Me.AFTER_TAX_ORDER_T.ReadOnly = True
        Me.AFTER_TAX_ORDER_T.Size = New System.Drawing.Size(300, 33)
        Me.AFTER_TAX_ORDER_T.TabIndex = 23
        Me.AFTER_TAX_ORDER_T.TabStop = False
        Me.AFTER_TAX_ORDER_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAX_T
        '
        Me.TAX_T.BackColor = System.Drawing.Color.Wheat
        Me.TAX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_T.Location = New System.Drawing.Point(263, 182)
        Me.TAX_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TAX_T.Name = "TAX_T"
        Me.TAX_T.ReadOnly = True
        Me.TAX_T.Size = New System.Drawing.Size(300, 33)
        Me.TAX_T.TabIndex = 26
        Me.TAX_T.TabStop = False
        Me.TAX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 352)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 26)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "税込発注金額："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(114, 189)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 26)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "消費税額："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(6, 30)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(612, 348)
        Me.ShapeContainer1.TabIndex = 48
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Brown
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 7
        Me.LineShape2.X2 = 345
        Me.LineShape2.Y1 = 145
        Me.LineShape2.Y2 = 145
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Brown
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 6
        Me.LineShape1.X2 = 339
        Me.LineShape1.Y1 = 94
        Me.LineShape1.Y2 = 94
        '
        'EDIT_L
        '
        Me.EDIT_L.BackColor = System.Drawing.Color.Red
        Me.EDIT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EDIT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EDIT_L.ForeColor = System.Drawing.Color.White
        Me.EDIT_L.Location = New System.Drawing.Point(55, 1293)
        Me.EDIT_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.EDIT_L.Name = "EDIT_L"
        Me.EDIT_L.Size = New System.Drawing.Size(2103, 35)
        Me.EDIT_L.TabIndex = 34
        Me.EDIT_L.Text = "注文伝票作成中"
        Me.EDIT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TRN_RULE_T
        '
        Me.TRN_RULE_T.BackColor = System.Drawing.Color.Wheat
        Me.TRN_RULE_T.Location = New System.Drawing.Point(1014, 104)
        Me.TRN_RULE_T.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TRN_RULE_T.Name = "TRN_RULE_T"
        Me.TRN_RULE_T.ReadOnly = True
        Me.TRN_RULE_T.Size = New System.Drawing.Size(745, 186)
        Me.TRN_RULE_T.TabIndex = 35
        Me.TRN_RULE_T.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(1014, 78)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 24)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "【取引条件】"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(1796, 78)
        Me.RETURN_B.Margin = New System.Windows.Forms.Padding(15, 13, 15, 13)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(362, 115)
        Me.RETURN_B.TabIndex = 10
        Me.RETURN_B.TextButton = "検索画面に戻る"
        '
        'PRINT_START_B
        '
        Me.PRINT_START_B.ColorBottom = System.Drawing.Color.Tan
        Me.PRINT_START_B.Location = New System.Drawing.Point(1485, 1165)
        Me.PRINT_START_B.Margin = New System.Windows.Forms.Padding(15, 13, 15, 13)
        Me.PRINT_START_B.Name = "PRINT_START_B"
        Me.PRINT_START_B.Size = New System.Drawing.Size(327, 115)
        Me.PRINT_START_B.TabIndex = 8
        Me.PRINT_START_B.TextButton = "登録／伝票印刷"
        '
        'EXIT_B
        '
        Me.EXIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.EXIT_B.Location = New System.Drawing.Point(1831, 1165)
        Me.EXIT_B.Margin = New System.Windows.Forms.Padding(15, 13, 15, 13)
        Me.EXIT_B.Name = "EXIT_B"
        Me.EXIT_B.Size = New System.Drawing.Size(327, 115)
        Me.EXIT_B.TabIndex = 9
        Me.EXIT_B.TextButton = "終 了"
        '
        'fOrderReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(2205, 1414)
        Me.Controls.Add(Me.EXIT_B)
        Me.Controls.Add(Me.PRINT_START_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.TRN_RULE_T)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.EDIT_L)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.MEMO_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SUPPER_CODE_T)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RQ_DATE_T)
        Me.Controls.Add(Me.SUPPLIER_C)
        Me.Controls.Add(Me.PAYMENT_L)
        Me.Controls.Add(Me.ORDER_CODE_T)
        Me.Controls.Add(Me.MEISAI_KINGAKU_G)
        Me.Controls.Add(Me.TITLE_L)
        Me.Controls.Add(Me.ORDER_V)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RQ_PLACE_T)
        Me.Controls.Add(Me.ORDER_NUMBER_L)
        Me.Controls.Add(Me.SUPPLIER_L)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DATE_L)
        Me.Controls.Add(Me.PLACE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "fOrderReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        CType(Me.ORDER_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MEISAI_KINGAKU_G.ResumeLayout(False)
        Me.MEISAI_KINGAKU_G.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SUPPLIER_L As System.Windows.Forms.Label
    Friend WithEvents ORDER_NUMBER_L As System.Windows.Forms.Label
    Friend WithEvents ORDER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents DATE_L As System.Windows.Forms.Label
    Friend WithEvents RQ_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents PLACE_L As System.Windows.Forms.Label
    Friend WithEvents RQ_PLACE_T As System.Windows.Forms.TextBox
    Friend WithEvents PAYMENT_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MEMO_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ORDER_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SUPPLIER_C As System.Windows.Forms.ComboBox
    Friend WithEvents TITLE_L As System.Windows.Forms.Label
    Friend WithEvents SUPPER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MEISAI_KINGAKU_G As System.Windows.Forms.GroupBox
    Friend WithEvents AFTER_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents BEFORE_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AFTER_TAX_ORDER_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EDIT_L As System.Windows.Forms.Label
    Friend WithEvents BEFORE_TAX_ORDER_T As System.Windows.Forms.TextBox
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
    Friend WithEvents TRN_RULE_T As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRINT_START_B As Softgroup.NetButton.NetButton
    Friend WithEvents EXIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RTAX_RATE_T As TextBox
    Friend WithEvents Label11 As Label
End Class
