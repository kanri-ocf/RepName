<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShipment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RQ_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.REQ_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RQ_DATE_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RQ_ADDR_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SHIPMENT_V = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.RQ_PAYMENT_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RQ_CHANNEL_T = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.RQ_TIME_T = New System.Windows.Forms.TextBox()
        Me.RQ_DAIBIKI_C = New System.Windows.Forms.CheckBox()
        Me.RQ_PAYMENT_CODE_T = New System.Windows.Forms.TextBox()
        Me.SHIP_RQ_DATE_T = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.RQ_MAIL_T = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.RQ_PONE_T = New System.Windows.Forms.TextBox()
        Me.SHIP_RQ_TIME_T = New System.Windows.Forms.TextBox()
        Me.JANCODE_T = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.COUNT_T = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DELIVERY_DATA_OUTPUT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SHIP_FIX_C = New System.Windows.Forms.CheckBox()
        Me.MEISAI_KINGAKU_G = New System.Windows.Forms.GroupBox()
        Me.IN_TAX_R = New System.Windows.Forms.RadioButton()
        Me.OUT_TAX_R = New System.Windows.Forms.RadioButton()
        Me.REQUEST_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.RQ_RTAX_RATE_P_T = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.RQ_DISCOUNT_P_T = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RQ_BILL_P_T = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.RQ_PRODUCT_P_T = New System.Windows.Forms.TextBox()
        Me.RQ_FEE_P_T = New System.Windows.Forms.TextBox()
        Me.RQ_POSTAGE_P_T = New System.Windows.Forms.TextBox()
        Me.RQ_P_DISCOUNT_P_T = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RQ_TAX_P_T = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.SHIP_CNT_L = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TIME_CODE_T = New System.Windows.Forms.TextBox()
        Me.TIME_NAME_C = New System.Windows.Forms.ComboBox()
        Me.ARRIVE_DATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.SHIP_PAY_T = New System.Windows.Forms.TextBox()
        Me.SHIP_COUNT_T = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.PRODUCT_NAME_C = New System.Windows.Forms.ComboBox()
        Me.SPEED_CODE_T = New System.Windows.Forms.TextBox()
        Me.SPEED_NAME_C = New System.Windows.Forms.ComboBox()
        Me.MOTOCYAKU_CODE_T = New System.Windows.Forms.TextBox()
        Me.CORP_CODE_T = New System.Windows.Forms.TextBox()
        Me.CORP_NAME_C = New System.Windows.Forms.ComboBox()
        Me.MOTOCYAKU_CLASS_C = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.BT_RTAX_RATE_P_T = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.BT_TAX_P_T = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.BT_DISCOUNT_P_T = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.BT_BILL_P_T = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.BT_PRODUCT_P_T = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.BT_P_DISCOUNT_P_T = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BT_FEE_P_T = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.BT_POSTAGE_P_T = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SHIP_ADDR4_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SHIP_NAME2_T = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SHIP_POSTCODE_T = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.SHIP_PONE_T = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SHIP_ADDR3_T = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SHIP_ADDR2_T = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SHIP_ADDR1_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SHIP_NAME1_T = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SHIP_MEMO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.RESHIP_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DELIVERY_PRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RESHIP_L = New System.Windows.Forms.Label()
        CType(Me.SHIPMENT_V,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.MEISAI_KINGAKU_G.SuspendLayout
        Me.GroupBox6.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.GroupBox5.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "注文者名"
        '
        'RQ_NAME_T
        '
        Me.RQ_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_NAME_T.Location = New System.Drawing.Point(124, 18)
        Me.RQ_NAME_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_NAME_T.Name = "RQ_NAME_T"
        Me.RQ_NAME_T.ReadOnly = True
        Me.RQ_NAME_T.Size = New System.Drawing.Size(436, 24)
        Me.RQ_NAME_T.TabIndex = 2
        Me.RQ_NAME_T.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "受注番号"
        '
        'REQ_CODE_T
        '
        Me.REQ_CODE_T.BackColor = System.Drawing.Color.LightCyan
        Me.REQ_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQ_CODE_T.Location = New System.Drawing.Point(88, 26)
        Me.REQ_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.REQ_CODE_T.Name = "REQ_CODE_T"
        Me.REQ_CODE_T.Size = New System.Drawing.Size(288, 34)
        Me.REQ_CODE_T.TabIndex = 1
        Me.REQ_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 100)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "受注日"
        '
        'RQ_DATE_T
        '
        Me.RQ_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_DATE_T.Location = New System.Drawing.Point(124, 96)
        Me.RQ_DATE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_DATE_T.Name = "RQ_DATE_T"
        Me.RQ_DATE_T.ReadOnly = True
        Me.RQ_DATE_T.Size = New System.Drawing.Size(136, 24)
        Me.RQ_DATE_T.TabIndex = 8
        Me.RQ_DATE_T.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 48)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "納品先住所"
        '
        'RQ_ADDR_T
        '
        Me.RQ_ADDR_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_ADDR_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_ADDR_T.Location = New System.Drawing.Point(124, 44)
        Me.RQ_ADDR_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_ADDR_T.Name = "RQ_ADDR_T"
        Me.RQ_ADDR_T.ReadOnly = True
        Me.RQ_ADDR_T.Size = New System.Drawing.Size(524, 24)
        Me.RQ_ADDR_T.TabIndex = 10
        Me.RQ_ADDR_T.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 208)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "支払方法"
        '
        'SHIPMENT_V
        '
        Me.SHIPMENT_V.AllowUserToAddRows = False
        Me.SHIPMENT_V.AllowUserToDeleteRows = False
        Me.SHIPMENT_V.AllowUserToResizeColumns = False
        Me.SHIPMENT_V.AllowUserToResizeRows = False
        Me.SHIPMENT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.SHIPMENT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SHIPMENT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SHIPMENT_V.ColumnHeadersHeight = 21
        Me.SHIPMENT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SHIPMENT_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.SHIPMENT_V.Location = New System.Drawing.Point(18, 358)
        Me.SHIPMENT_V.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIPMENT_V.MultiSelect = False
        Me.SHIPMENT_V.Name = "SHIPMENT_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SHIPMENT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SHIPMENT_V.RowHeadersWidth = 82
        Me.SHIPMENT_V.RowTemplate.Height = 21
        Me.SHIPMENT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SHIPMENT_V.Size = New System.Drawing.Size(1327, 216)
        Me.SHIPMENT_V.TabIndex = 11
        Me.SHIPMENT_V.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(39, 921)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 17)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "出庫担当者"
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(143, 918)
        Me.STAFF_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(165, 24)
        Me.STAFF_CODE_T.TabIndex = 25
        Me.STAFF_CODE_T.TabStop = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(319, 918)
        Me.STAFF_NAME_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(227, 24)
        Me.STAFF_NAME_T.TabIndex = 27
        Me.STAFF_NAME_T.TabStop = False
        '
        'RQ_PAYMENT_T
        '
        Me.RQ_PAYMENT_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_PAYMENT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_PAYMENT_T.Location = New System.Drawing.Point(124, 202)
        Me.RQ_PAYMENT_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_PAYMENT_T.Name = "RQ_PAYMENT_T"
        Me.RQ_PAYMENT_T.ReadOnly = True
        Me.RQ_PAYMENT_T.Size = New System.Drawing.Size(261, 24)
        Me.RQ_PAYMENT_T.TabIndex = 28
        Me.RQ_PAYMENT_T.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 181)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "受注チャネル"
        '
        'RQ_CHANNEL_T
        '
        Me.RQ_CHANNEL_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_CHANNEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_CHANNEL_T.Location = New System.Drawing.Point(124, 176)
        Me.RQ_CHANNEL_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_CHANNEL_T.Name = "RQ_CHANNEL_T"
        Me.RQ_CHANNEL_T.ReadOnly = True
        Me.RQ_CHANNEL_T.Size = New System.Drawing.Size(261, 24)
        Me.RQ_CHANNEL_T.TabIndex = 29
        Me.RQ_CHANNEL_T.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.RQ_TIME_T)
        Me.GroupBox1.Controls.Add(Me.RQ_DAIBIKI_C)
        Me.GroupBox1.Controls.Add(Me.RQ_PAYMENT_CODE_T)
        Me.GroupBox1.Controls.Add(Me.SHIP_RQ_DATE_T)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.RQ_MAIL_T)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.RQ_PONE_T)
        Me.GroupBox1.Controls.Add(Me.SHIP_RQ_TIME_T)
        Me.GroupBox1.Controls.Add(Me.RQ_CHANNEL_T)
        Me.GroupBox1.Controls.Add(Me.RQ_PAYMENT_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.RQ_ADDR_T)
        Me.GroupBox1.Controls.Add(Me.RQ_DATE_T)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RQ_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(18, 576)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(670, 240)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【受注情報】"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(266, 155)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(17, 17)
        Me.Label29.TabIndex = 87
        Me.Label29.Text = "-"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(266, 101)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(17, 17)
        Me.Label27.TabIndex = 86
        Me.Label27.Text = "-"
        '
        'RQ_TIME_T
        '
        Me.RQ_TIME_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_TIME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_TIME_T.Location = New System.Drawing.Point(287, 96)
        Me.RQ_TIME_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_TIME_T.Name = "RQ_TIME_T"
        Me.RQ_TIME_T.ReadOnly = True
        Me.RQ_TIME_T.Size = New System.Drawing.Size(122, 24)
        Me.RQ_TIME_T.TabIndex = 85
        Me.RQ_TIME_T.TabStop = False
        '
        'RQ_DAIBIKI_C
        '
        Me.RQ_DAIBIKI_C.AutoSize = True
        Me.RQ_DAIBIKI_C.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RQ_DAIBIKI_C.Location = New System.Drawing.Point(438, 208)
        Me.RQ_DAIBIKI_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_DAIBIKI_C.Name = "RQ_DAIBIKI_C"
        Me.RQ_DAIBIKI_C.Size = New System.Drawing.Size(18, 17)
        Me.RQ_DAIBIKI_C.TabIndex = 84
        Me.RQ_DAIBIKI_C.UseVisualStyleBackColor = True
        Me.RQ_DAIBIKI_C.Visible = False
        '
        'RQ_PAYMENT_CODE_T
        '
        Me.RQ_PAYMENT_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_PAYMENT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_PAYMENT_CODE_T.Location = New System.Drawing.Point(391, 202)
        Me.RQ_PAYMENT_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_PAYMENT_CODE_T.Name = "RQ_PAYMENT_CODE_T"
        Me.RQ_PAYMENT_CODE_T.ReadOnly = True
        Me.RQ_PAYMENT_CODE_T.Size = New System.Drawing.Size(37, 24)
        Me.RQ_PAYMENT_CODE_T.TabIndex = 78
        Me.RQ_PAYMENT_CODE_T.TabStop = False
        Me.RQ_PAYMENT_CODE_T.Visible = False
        '
        'SHIP_RQ_DATE_T
        '
        Me.SHIP_RQ_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.SHIP_RQ_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_RQ_DATE_T.Location = New System.Drawing.Point(124, 150)
        Me.SHIP_RQ_DATE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_RQ_DATE_T.Name = "SHIP_RQ_DATE_T"
        Me.SHIP_RQ_DATE_T.ReadOnly = True
        Me.SHIP_RQ_DATE_T.Size = New System.Drawing.Size(136, 24)
        Me.SHIP_RQ_DATE_T.TabIndex = 76
        Me.SHIP_RQ_DATE_T.TabStop = False
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.Location = New System.Drawing.Point(9, 154)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(110, 17)
        Me.Label51.TabIndex = 77
        Me.Label51.Text = "配達希望日時"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(22, 74)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 17)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "メールアドレス"
        '
        'RQ_MAIL_T
        '
        Me.RQ_MAIL_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_MAIL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_MAIL_T.Location = New System.Drawing.Point(124, 70)
        Me.RQ_MAIL_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_MAIL_T.Name = "RQ_MAIL_T"
        Me.RQ_MAIL_T.ReadOnly = True
        Me.RQ_MAIL_T.Size = New System.Drawing.Size(358, 24)
        Me.RQ_MAIL_T.TabIndex = 36
        Me.RQ_MAIL_T.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(44, 128)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 17)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "電話番号"
        '
        'RQ_PONE_T
        '
        Me.RQ_PONE_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_PONE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_PONE_T.Location = New System.Drawing.Point(124, 122)
        Me.RQ_PONE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_PONE_T.Name = "RQ_PONE_T"
        Me.RQ_PONE_T.ReadOnly = True
        Me.RQ_PONE_T.Size = New System.Drawing.Size(228, 24)
        Me.RQ_PONE_T.TabIndex = 34
        Me.RQ_PONE_T.TabStop = False
        '
        'SHIP_RQ_TIME_T
        '
        Me.SHIP_RQ_TIME_T.BackColor = System.Drawing.Color.Wheat
        Me.SHIP_RQ_TIME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_RQ_TIME_T.Location = New System.Drawing.Point(287, 150)
        Me.SHIP_RQ_TIME_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_RQ_TIME_T.Name = "SHIP_RQ_TIME_T"
        Me.SHIP_RQ_TIME_T.ReadOnly = True
        Me.SHIP_RQ_TIME_T.Size = New System.Drawing.Size(122, 24)
        Me.SHIP_RQ_TIME_T.TabIndex = 32
        Me.SHIP_RQ_TIME_T.TabStop = False
        '
        'JANCODE_T
        '
        Me.JANCODE_T.BackColor = System.Drawing.Color.LightCyan
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.Location = New System.Drawing.Point(14, 95)
        Me.JANCODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.JANCODE_T.Multiline = True
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(486, 45)
        Me.JANCODE_T.TabIndex = 2
        Me.JANCODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 78)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 17)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "JANコード"
        '
        'COUNT_T
        '
        Me.COUNT_T.BackColor = System.Drawing.Color.LightCyan
        Me.COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COUNT_T.Location = New System.Drawing.Point(524, 95)
        Me.COUNT_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.COUNT_T.Multiline = True
        Me.COUNT_T.Name = "COUNT_T"
        Me.COUNT_T.Size = New System.Drawing.Size(211, 45)
        Me.COUNT_T.TabIndex = 3
        Me.COUNT_T.Text = "1"
        Me.COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(526, 76)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 17)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "出庫数量"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DELIVERY_DATA_OUTPUT_B)
        Me.GroupBox2.Controls.Add(Me.SHIP_FIX_C)
        Me.GroupBox2.Controls.Add(Me.MEISAI_KINGAKU_G)
        Me.GroupBox2.Controls.Add(Me.REQUEST_SEARCH_B)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.SHIP_CNT_L)
        Me.GroupBox2.Controls.Add(Me.Label52)
        Me.GroupBox2.Controls.Add(Me.COUNT_T)
        Me.GroupBox2.Controls.Add(Me.REQ_CODE_T)
        Me.GroupBox2.Controls.Add(Me.JANCODE_T)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(20, 31)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1327, 316)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【出庫情報】"
        '
        'DELIVERY_DATA_OUTPUT_B
        '
        Me.DELIVERY_DATA_OUTPUT_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELIVERY_DATA_OUTPUT_B.Location = New System.Drawing.Point(1132, 19)
        Me.DELIVERY_DATA_OUTPUT_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.DELIVERY_DATA_OUTPUT_B.Name = "DELIVERY_DATA_OUTPUT_B"
        Me.DELIVERY_DATA_OUTPUT_B.Size = New System.Drawing.Size(186, 46)
        Me.DELIVERY_DATA_OUTPUT_B.TabIndex = 85
        Me.DELIVERY_DATA_OUTPUT_B.TextButton = "配送伝票データ出力"
        '
        'SHIP_FIX_C
        '
        Me.SHIP_FIX_C.AutoSize = True
        Me.SHIP_FIX_C.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SHIP_FIX_C.Location = New System.Drawing.Point(758, 38)
        Me.SHIP_FIX_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_FIX_C.Name = "SHIP_FIX_C"
        Me.SHIP_FIX_C.Size = New System.Drawing.Size(97, 19)
        Me.SHIP_FIX_C.TabIndex = 83
        Me.SHIP_FIX_C.Text = "出荷完了："
        Me.SHIP_FIX_C.UseVisualStyleBackColor = True
        '
        'MEISAI_KINGAKU_G
        '
        Me.MEISAI_KINGAKU_G.Controls.Add(Me.IN_TAX_R)
        Me.MEISAI_KINGAKU_G.Controls.Add(Me.OUT_TAX_R)
        Me.MEISAI_KINGAKU_G.Location = New System.Drawing.Point(892, 14)
        Me.MEISAI_KINGAKU_G.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MEISAI_KINGAKU_G.Name = "MEISAI_KINGAKU_G"
        Me.MEISAI_KINGAKU_G.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MEISAI_KINGAKU_G.Size = New System.Drawing.Size(223, 51)
        Me.MEISAI_KINGAKU_G.TabIndex = 84
        Me.MEISAI_KINGAKU_G.TabStop = False
        Me.MEISAI_KINGAKU_G.Text = "【税モード】"
        '
        'IN_TAX_R
        '
        Me.IN_TAX_R.AutoSize = True
        Me.IN_TAX_R.Checked = True
        Me.IN_TAX_R.Location = New System.Drawing.Point(23, 21)
        Me.IN_TAX_R.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IN_TAX_R.Name = "IN_TAX_R"
        Me.IN_TAX_R.Size = New System.Drawing.Size(71, 19)
        Me.IN_TAX_R.TabIndex = 1
        Me.IN_TAX_R.TabStop = True
        Me.IN_TAX_R.Text = "税込み"
        Me.IN_TAX_R.UseVisualStyleBackColor = True
        '
        'OUT_TAX_R
        '
        Me.OUT_TAX_R.AutoSize = True
        Me.OUT_TAX_R.Location = New System.Drawing.Point(122, 21)
        Me.OUT_TAX_R.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OUT_TAX_R.Name = "OUT_TAX_R"
        Me.OUT_TAX_R.Size = New System.Drawing.Size(69, 19)
        Me.OUT_TAX_R.TabIndex = 0
        Me.OUT_TAX_R.Text = "税抜き"
        Me.OUT_TAX_R.UseVisualStyleBackColor = True
        '
        'REQUEST_SEARCH_B
        '
        Me.REQUEST_SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.REQUEST_SEARCH_B.Location = New System.Drawing.Point(385, 15)
        Me.REQUEST_SEARCH_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.REQUEST_SEARCH_B.Name = "REQUEST_SEARCH_B"
        Me.REQUEST_SEARCH_B.Size = New System.Drawing.Size(130, 59)
        Me.REQUEST_SEARCH_B.TabIndex = 2
        Me.REQUEST_SEARCH_B.TextButton = "注文検索"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RQ_RTAX_RATE_P_T)
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.RQ_DISCOUNT_P_T)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.RQ_BILL_P_T)
        Me.GroupBox6.Controls.Add(Me.Label47)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.RQ_PRODUCT_P_T)
        Me.GroupBox6.Controls.Add(Me.RQ_FEE_P_T)
        Me.GroupBox6.Controls.Add(Me.RQ_POSTAGE_P_T)
        Me.GroupBox6.Controls.Add(Me.RQ_P_DISCOUNT_P_T)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.RQ_TAX_P_T)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.ShapeContainer3)
        Me.GroupBox6.Location = New System.Drawing.Point(743, 74)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(279, 234)
        Me.GroupBox6.TabIndex = 81
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "【受注金額情報】"
        '
        'RQ_RTAX_RATE_P_T
        '
        Me.RQ_RTAX_RATE_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_RTAX_RATE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_RTAX_RATE_P_T.Location = New System.Drawing.Point(119, 122)
        Me.RQ_RTAX_RATE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_RTAX_RATE_P_T.Name = "RQ_RTAX_RATE_P_T"
        Me.RQ_RTAX_RATE_P_T.ReadOnly = True
        Me.RQ_RTAX_RATE_P_T.Size = New System.Drawing.Size(140, 24)
        Me.RQ_RTAX_RATE_P_T.TabIndex = 98
        Me.RQ_RTAX_RATE_P_T.TabStop = False
        Me.RQ_RTAX_RATE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(55, 128)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(59, 17)
        Me.Label30.TabIndex = 99
        Me.Label30.Text = "軽減税"
        '
        'RQ_DISCOUNT_P_T
        '
        Me.RQ_DISCOUNT_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_DISCOUNT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_DISCOUNT_P_T.Location = New System.Drawing.Point(118, 149)
        Me.RQ_DISCOUNT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_DISCOUNT_P_T.Name = "RQ_DISCOUNT_P_T"
        Me.RQ_DISCOUNT_P_T.ReadOnly = True
        Me.RQ_DISCOUNT_P_T.Size = New System.Drawing.Size(141, 24)
        Me.RQ_DISCOUNT_P_T.TabIndex = 93
        Me.RQ_DISCOUNT_P_T.TabStop = False
        Me.RQ_DISCOUNT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 208)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 17)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "合計請求金額"
        '
        'RQ_BILL_P_T
        '
        Me.RQ_BILL_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_BILL_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_BILL_P_T.Location = New System.Drawing.Point(118, 202)
        Me.RQ_BILL_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_BILL_P_T.Name = "RQ_BILL_P_T"
        Me.RQ_BILL_P_T.ReadOnly = True
        Me.RQ_BILL_P_T.Size = New System.Drawing.Size(142, 24)
        Me.RQ_BILL_P_T.TabIndex = 96
        Me.RQ_BILL_P_T.TabStop = False
        Me.RQ_BILL_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.Location = New System.Drawing.Point(58, 155)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(55, 17)
        Me.Label47.TabIndex = 94
        Me.Label47.Text = "値引き"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.Location = New System.Drawing.Point(57, 74)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(59, 17)
        Me.Label39.TabIndex = 90
        Me.Label39.Text = "手数料"
        '
        'RQ_PRODUCT_P_T
        '
        Me.RQ_PRODUCT_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_PRODUCT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_PRODUCT_P_T.Location = New System.Drawing.Point(120, 15)
        Me.RQ_PRODUCT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_PRODUCT_P_T.Name = "RQ_PRODUCT_P_T"
        Me.RQ_PRODUCT_P_T.ReadOnly = True
        Me.RQ_PRODUCT_P_T.Size = New System.Drawing.Size(140, 24)
        Me.RQ_PRODUCT_P_T.TabIndex = 83
        Me.RQ_PRODUCT_P_T.TabStop = False
        Me.RQ_PRODUCT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RQ_FEE_P_T
        '
        Me.RQ_FEE_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_FEE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_FEE_P_T.Location = New System.Drawing.Point(119, 68)
        Me.RQ_FEE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_FEE_P_T.Name = "RQ_FEE_P_T"
        Me.RQ_FEE_P_T.ReadOnly = True
        Me.RQ_FEE_P_T.Size = New System.Drawing.Size(141, 24)
        Me.RQ_FEE_P_T.TabIndex = 88
        Me.RQ_FEE_P_T.TabStop = False
        Me.RQ_FEE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RQ_POSTAGE_P_T
        '
        Me.RQ_POSTAGE_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_POSTAGE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_POSTAGE_P_T.Location = New System.Drawing.Point(119, 41)
        Me.RQ_POSTAGE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_POSTAGE_P_T.Name = "RQ_POSTAGE_P_T"
        Me.RQ_POSTAGE_P_T.ReadOnly = True
        Me.RQ_POSTAGE_P_T.Size = New System.Drawing.Size(141, 24)
        Me.RQ_POSTAGE_P_T.TabIndex = 87
        Me.RQ_POSTAGE_P_T.TabStop = False
        Me.RQ_POSTAGE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RQ_P_DISCOUNT_P_T
        '
        Me.RQ_P_DISCOUNT_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_P_DISCOUNT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_P_DISCOUNT_P_T.Location = New System.Drawing.Point(118, 175)
        Me.RQ_P_DISCOUNT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_P_DISCOUNT_P_T.Name = "RQ_P_DISCOUNT_P_T"
        Me.RQ_P_DISCOUNT_P_T.ReadOnly = True
        Me.RQ_P_DISCOUNT_P_T.Size = New System.Drawing.Size(141, 24)
        Me.RQ_P_DISCOUNT_P_T.TabIndex = 91
        Me.RQ_P_DISCOUNT_P_T.TabStop = False
        Me.RQ_P_DISCOUNT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.Location = New System.Drawing.Point(7, 182)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(106, 17)
        Me.Label44.TabIndex = 92
        Me.Label44.Text = "ポイント値引き"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.Location = New System.Drawing.Point(74, 48)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(42, 17)
        Me.Label38.TabIndex = 89
        Me.Label38.Text = "送料"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "受注商品代金"
        '
        'RQ_TAX_P_T
        '
        Me.RQ_TAX_P_T.BackColor = System.Drawing.Color.Wheat
        Me.RQ_TAX_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQ_TAX_P_T.Location = New System.Drawing.Point(119, 95)
        Me.RQ_TAX_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RQ_TAX_P_T.Name = "RQ_TAX_P_T"
        Me.RQ_TAX_P_T.ReadOnly = True
        Me.RQ_TAX_P_T.Size = New System.Drawing.Size(140, 24)
        Me.RQ_TAX_P_T.TabIndex = 85
        Me.RQ_TAX_P_T.TabStop = False
        Me.RQ_TAX_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(55, 101)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 17)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "消費税"
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(4, 19)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3})
        Me.ShapeContainer3.Size = New System.Drawing.Size(271, 211)
        Me.ShapeContainer3.TabIndex = 100
        Me.ShapeContainer3.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.SaddleBrown
        Me.LineShape4.Name = "LineShape1"
        Me.LineShape4.X1 = 4
        Me.LineShape4.X2 = 191
        Me.LineShape4.Y1 = 182
        Me.LineShape4.Y2 = 182
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.SaddleBrown
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 2
        Me.LineShape3.X2 = 189
        Me.LineShape3.Y1 = 155
        Me.LineShape3.Y2 = 155
        '
        'SHIP_CNT_L
        '
        Me.SHIP_CNT_L.BackColor = System.Drawing.Color.Wheat
        Me.SHIP_CNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SHIP_CNT_L.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_CNT_L.Location = New System.Drawing.Point(616, 28)
        Me.SHIP_CNT_L.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SHIP_CNT_L.Name = "SHIP_CNT_L"
        Me.SHIP_CNT_L.Size = New System.Drawing.Size(120, 35)
        Me.SHIP_CNT_L.TabIndex = 66
        Me.SHIP_CNT_L.Text = "初回"
        Me.SHIP_CNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.Location = New System.Drawing.Point(530, 38)
        Me.Label52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(76, 17)
        Me.Label52.TabIndex = 65
        Me.Label52.Text = "出荷状況"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TIME_CODE_T)
        Me.GroupBox3.Controls.Add(Me.TIME_NAME_C)
        Me.GroupBox3.Controls.Add(Me.ARRIVE_DATE_T)
        Me.GroupBox3.Controls.Add(Me.SHIP_PAY_T)
        Me.GroupBox3.Controls.Add(Me.SHIP_COUNT_T)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.PRODUCT_CODE_T)
        Me.GroupBox3.Controls.Add(Me.PRODUCT_NAME_C)
        Me.GroupBox3.Controls.Add(Me.SPEED_CODE_T)
        Me.GroupBox3.Controls.Add(Me.SPEED_NAME_C)
        Me.GroupBox3.Controls.Add(Me.MOTOCYAKU_CODE_T)
        Me.GroupBox3.Controls.Add(Me.CORP_CODE_T)
        Me.GroupBox3.Controls.Add(Me.CORP_NAME_C)
        Me.GroupBox3.Controls.Add(Me.MOTOCYAKU_CLASS_C)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(15, 158)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(724, 150)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "【配送情報】"
        '
        'TIME_CODE_T
        '
        Me.TIME_CODE_T.Location = New System.Drawing.Point(655, 85)
        Me.TIME_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TIME_CODE_T.Name = "TIME_CODE_T"
        Me.TIME_CODE_T.ReadOnly = True
        Me.TIME_CODE_T.Size = New System.Drawing.Size(26, 22)
        Me.TIME_CODE_T.TabIndex = 68
        Me.TIME_CODE_T.Visible = False
        '
        'TIME_NAME_C
        '
        Me.TIME_NAME_C.BackColor = System.Drawing.Color.White
        Me.TIME_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TIME_NAME_C.FormattingEnabled = True
        Me.TIME_NAME_C.Location = New System.Drawing.Point(460, 84)
        Me.TIME_NAME_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TIME_NAME_C.Name = "TIME_NAME_C"
        Me.TIME_NAME_C.Size = New System.Drawing.Size(246, 24)
        Me.TIME_NAME_C.TabIndex = 65
        '
        'ARRIVE_DATE_T
        '
        Me.ARRIVE_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ARRIVE_DATE_T.Location = New System.Drawing.Point(460, 54)
        Me.ARRIVE_DATE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ARRIVE_DATE_T.Mask = "0000/00/00"
        Me.ARRIVE_DATE_T.Name = "ARRIVE_DATE_T"
        Me.ARRIVE_DATE_T.Size = New System.Drawing.Size(148, 26)
        Me.ARRIVE_DATE_T.TabIndex = 64
        Me.ARRIVE_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ARRIVE_DATE_T.ValidatingType = GetType(Date)
        '
        'SHIP_PAY_T
        '
        Me.SHIP_PAY_T.BackColor = System.Drawing.Color.White
        Me.SHIP_PAY_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_PAY_T.Location = New System.Drawing.Point(460, 112)
        Me.SHIP_PAY_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_PAY_T.Name = "SHIP_PAY_T"
        Me.SHIP_PAY_T.Size = New System.Drawing.Size(148, 24)
        Me.SHIP_PAY_T.TabIndex = 13
        Me.SHIP_PAY_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SHIP_COUNT_T
        '
        Me.SHIP_COUNT_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SHIP_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_COUNT_T.Location = New System.Drawing.Point(460, 26)
        Me.SHIP_COUNT_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_COUNT_T.Name = "SHIP_COUNT_T"
        Me.SHIP_COUNT_T.Size = New System.Drawing.Size(52, 24)
        Me.SHIP_COUNT_T.TabIndex = 8
        Me.SHIP_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(612, 120)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 15)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "（税込み）"
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(260, 114)
        Me.PRODUCT_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.ReadOnly = True
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(26, 22)
        Me.PRODUCT_CODE_T.TabIndex = 74
        Me.PRODUCT_CODE_T.Visible = False
        '
        'PRODUCT_NAME_C
        '
        Me.PRODUCT_NAME_C.BackColor = System.Drawing.Color.LemonChiffon
        Me.PRODUCT_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_C.FormattingEnabled = True
        Me.PRODUCT_NAME_C.Location = New System.Drawing.Point(118, 112)
        Me.PRODUCT_NAME_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PRODUCT_NAME_C.Name = "PRODUCT_NAME_C"
        Me.PRODUCT_NAME_C.Size = New System.Drawing.Size(194, 24)
        Me.PRODUCT_NAME_C.TabIndex = 73
        '
        'SPEED_CODE_T
        '
        Me.SPEED_CODE_T.Location = New System.Drawing.Point(260, 85)
        Me.SPEED_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SPEED_CODE_T.Name = "SPEED_CODE_T"
        Me.SPEED_CODE_T.ReadOnly = True
        Me.SPEED_CODE_T.Size = New System.Drawing.Size(26, 22)
        Me.SPEED_CODE_T.TabIndex = 71
        Me.SPEED_CODE_T.Visible = False
        '
        'SPEED_NAME_C
        '
        Me.SPEED_NAME_C.BackColor = System.Drawing.Color.LemonChiffon
        Me.SPEED_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SPEED_NAME_C.FormattingEnabled = True
        Me.SPEED_NAME_C.Location = New System.Drawing.Point(118, 84)
        Me.SPEED_NAME_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SPEED_NAME_C.Name = "SPEED_NAME_C"
        Me.SPEED_NAME_C.Size = New System.Drawing.Size(194, 24)
        Me.SPEED_NAME_C.TabIndex = 70
        '
        'MOTOCYAKU_CODE_T
        '
        Me.MOTOCYAKU_CODE_T.Location = New System.Drawing.Point(148, 55)
        Me.MOTOCYAKU_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MOTOCYAKU_CODE_T.Name = "MOTOCYAKU_CODE_T"
        Me.MOTOCYAKU_CODE_T.ReadOnly = True
        Me.MOTOCYAKU_CODE_T.Size = New System.Drawing.Size(26, 22)
        Me.MOTOCYAKU_CODE_T.TabIndex = 67
        Me.MOTOCYAKU_CODE_T.Visible = False
        '
        'CORP_CODE_T
        '
        Me.CORP_CODE_T.Location = New System.Drawing.Point(228, 26)
        Me.CORP_CODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CORP_CODE_T.Name = "CORP_CODE_T"
        Me.CORP_CODE_T.ReadOnly = True
        Me.CORP_CODE_T.Size = New System.Drawing.Size(26, 22)
        Me.CORP_CODE_T.TabIndex = 66
        Me.CORP_CODE_T.Visible = False
        '
        'CORP_NAME_C
        '
        Me.CORP_NAME_C.BackColor = System.Drawing.Color.LemonChiffon
        Me.CORP_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CORP_NAME_C.FormattingEnabled = True
        Me.CORP_NAME_C.Location = New System.Drawing.Point(118, 25)
        Me.CORP_NAME_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CORP_NAME_C.Name = "CORP_NAME_C"
        Me.CORP_NAME_C.Size = New System.Drawing.Size(162, 24)
        Me.CORP_NAME_C.TabIndex = 6
        '
        'MOTOCYAKU_CLASS_C
        '
        Me.MOTOCYAKU_CLASS_C.BackColor = System.Drawing.Color.LemonChiffon
        Me.MOTOCYAKU_CLASS_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTOCYAKU_CLASS_C.FormattingEnabled = True
        Me.MOTOCYAKU_CLASS_C.Location = New System.Drawing.Point(118, 54)
        Me.MOTOCYAKU_CLASS_C.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MOTOCYAKU_CLASS_C.Name = "MOTOCYAKU_CLASS_C"
        Me.MOTOCYAKU_CLASS_C.Size = New System.Drawing.Size(82, 24)
        Me.MOTOCYAKU_CLASS_C.TabIndex = 9
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(25, 118)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(86, 17)
        Me.Label26.TabIndex = 72
        Me.Label26.Text = "便種(商品)"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 88)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 17)
        Me.Label22.TabIndex = 69
        Me.Label22.Text = "便種(スピード)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.Location = New System.Drawing.Point(34, 30)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(76, 17)
        Me.Label35.TabIndex = 63
        Me.Label35.Text = "配送業者"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(34, 59)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 17)
        Me.Label21.TabIndex = 58
        Me.Label21.Text = "元着区分"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(377, 31)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 17)
        Me.Label28.TabIndex = 54
        Me.Label28.Text = "出荷個数"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(360, 58)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 17)
        Me.Label32.TabIndex = 48
        Me.Label32.Text = "配達希望日"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(378, 118)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 17)
        Me.Label33.TabIndex = 46
        Me.Label33.Text = "代引金額"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.Location = New System.Drawing.Point(344, 88)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(110, 17)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "配達希望時間"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.BT_RTAX_RATE_P_T)
        Me.GroupBox5.Controls.Add(Me.Label54)
        Me.GroupBox5.Controls.Add(Me.BT_TAX_P_T)
        Me.GroupBox5.Controls.Add(Me.Label48)
        Me.GroupBox5.Controls.Add(Me.BT_DISCOUNT_P_T)
        Me.GroupBox5.Controls.Add(Me.Label46)
        Me.GroupBox5.Controls.Add(Me.BT_BILL_P_T)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.BT_PRODUCT_P_T)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Controls.Add(Me.BT_P_DISCOUNT_P_T)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.BT_FEE_P_T)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.BT_POSTAGE_P_T)
        Me.GroupBox5.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox5.Location = New System.Drawing.Point(1025, 72)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(294, 235)
        Me.GroupBox5.TabIndex = 60
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "【出荷金額情報】"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.Location = New System.Drawing.Point(66, 125)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(59, 17)
        Me.Label36.TabIndex = 76
        Me.Label36.Text = "軽減税"
        '
        'BT_RTAX_RATE_P_T
        '
        Me.BT_RTAX_RATE_P_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BT_RTAX_RATE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_RTAX_RATE_P_T.Location = New System.Drawing.Point(129, 120)
        Me.BT_RTAX_RATE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_RTAX_RATE_P_T.Name = "BT_RTAX_RATE_P_T"
        Me.BT_RTAX_RATE_P_T.ReadOnly = True
        Me.BT_RTAX_RATE_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_RTAX_RATE_P_T.TabIndex = 75
        Me.BT_RTAX_RATE_P_T.TabStop = False
        Me.BT_RTAX_RATE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.Location = New System.Drawing.Point(66, 99)
        Me.Label54.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(59, 17)
        Me.Label54.TabIndex = 74
        Me.Label54.Text = "消費税"
        '
        'BT_TAX_P_T
        '
        Me.BT_TAX_P_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BT_TAX_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_TAX_P_T.Location = New System.Drawing.Point(129, 94)
        Me.BT_TAX_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_TAX_P_T.Name = "BT_TAX_P_T"
        Me.BT_TAX_P_T.ReadOnly = True
        Me.BT_TAX_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_TAX_P_T.TabIndex = 73
        Me.BT_TAX_P_T.TabStop = False
        Me.BT_TAX_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.Location = New System.Drawing.Point(72, 152)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(55, 17)
        Me.Label48.TabIndex = 71
        Me.Label48.Text = "値引き"
        '
        'BT_DISCOUNT_P_T
        '
        Me.BT_DISCOUNT_P_T.BackColor = System.Drawing.Color.White
        Me.BT_DISCOUNT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_DISCOUNT_P_T.Location = New System.Drawing.Point(130, 148)
        Me.BT_DISCOUNT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_DISCOUNT_P_T.Name = "BT_DISCOUNT_P_T"
        Me.BT_DISCOUNT_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_DISCOUNT_P_T.TabIndex = 26
        Me.BT_DISCOUNT_P_T.TabStop = False
        Me.BT_DISCOUNT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.Location = New System.Drawing.Point(15, 205)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(110, 17)
        Me.Label46.TabIndex = 69
        Me.Label46.Text = "合計請求金額"
        '
        'BT_BILL_P_T
        '
        Me.BT_BILL_P_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BT_BILL_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_BILL_P_T.Location = New System.Drawing.Point(129, 200)
        Me.BT_BILL_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_BILL_P_T.Name = "BT_BILL_P_T"
        Me.BT_BILL_P_T.ReadOnly = True
        Me.BT_BILL_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_BILL_P_T.TabIndex = 68
        Me.BT_BILL_P_T.TabStop = False
        Me.BT_BILL_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.Location = New System.Drawing.Point(15, 21)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(110, 17)
        Me.Label43.TabIndex = 67
        Me.Label43.Text = "出荷商品代金"
        '
        'BT_PRODUCT_P_T
        '
        Me.BT_PRODUCT_P_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BT_PRODUCT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_PRODUCT_P_T.Location = New System.Drawing.Point(129, 16)
        Me.BT_PRODUCT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_PRODUCT_P_T.Name = "BT_PRODUCT_P_T"
        Me.BT_PRODUCT_P_T.ReadOnly = True
        Me.BT_PRODUCT_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_PRODUCT_P_T.TabIndex = 66
        Me.BT_PRODUCT_P_T.TabStop = False
        Me.BT_PRODUCT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.Location = New System.Drawing.Point(22, 178)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(106, 17)
        Me.Label42.TabIndex = 65
        Me.Label42.Text = "ポイント値引き"
        '
        'BT_P_DISCOUNT_P_T
        '
        Me.BT_P_DISCOUNT_P_T.BackColor = System.Drawing.Color.White
        Me.BT_P_DISCOUNT_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_P_DISCOUNT_P_T.Location = New System.Drawing.Point(130, 172)
        Me.BT_P_DISCOUNT_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_P_DISCOUNT_P_T.Name = "BT_P_DISCOUNT_P_T"
        Me.BT_P_DISCOUNT_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_P_DISCOUNT_P_T.TabIndex = 27
        Me.BT_P_DISCOUNT_P_T.TabStop = False
        Me.BT_P_DISCOUNT_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.Location = New System.Drawing.Point(66, 74)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(59, 17)
        Me.Label41.TabIndex = 63
        Me.Label41.Text = "手数料"
        '
        'BT_FEE_P_T
        '
        Me.BT_FEE_P_T.BackColor = System.Drawing.Color.White
        Me.BT_FEE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_FEE_P_T.Location = New System.Drawing.Point(129, 69)
        Me.BT_FEE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_FEE_P_T.Name = "BT_FEE_P_T"
        Me.BT_FEE_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_FEE_P_T.TabIndex = 25
        Me.BT_FEE_P_T.TabStop = False
        Me.BT_FEE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.Location = New System.Drawing.Point(84, 48)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(42, 17)
        Me.Label40.TabIndex = 61
        Me.Label40.Text = "送料"
        '
        'BT_POSTAGE_P_T
        '
        Me.BT_POSTAGE_P_T.BackColor = System.Drawing.Color.White
        Me.BT_POSTAGE_P_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_POSTAGE_P_T.Location = New System.Drawing.Point(129, 42)
        Me.BT_POSTAGE_P_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BT_POSTAGE_P_T.Name = "BT_POSTAGE_P_T"
        Me.BT_POSTAGE_P_T.Size = New System.Drawing.Size(142, 24)
        Me.BT_POSTAGE_P_T.TabIndex = 24
        Me.BT_POSTAGE_P_T.TabStop = False
        Me.BT_POSTAGE_P_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(4, 19)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(286, 212)
        Me.ShapeContainer1.TabIndex = 72
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.SaddleBrown
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 7
        Me.LineShape2.X2 = 206
        Me.LineShape2.Y1 = 178
        Me.LineShape2.Y2 = 178
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.SaddleBrown
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 8
        Me.LineShape1.X2 = 207
        Me.LineShape1.Y1 = 154
        Me.LineShape1.Y2 = 154
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR4_T)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.SHIP_NAME2_T)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.SHIP_POSTCODE_T)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.SHIP_PONE_T)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR3_T)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR2_T)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.SHIP_ADDR1_T)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.SHIP_NAME1_T)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(702, 576)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(632, 240)
        Me.GroupBox4.TabIndex = 61
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "【送付者情報】"
        '
        'SHIP_ADDR4_T
        '
        Me.SHIP_ADDR4_T.BackColor = System.Drawing.Color.White
        Me.SHIP_ADDR4_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR4_T.Location = New System.Drawing.Point(159, 176)
        Me.SHIP_ADDR4_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_ADDR4_T.Name = "SHIP_ADDR4_T"
        Me.SHIP_ADDR4_T.Size = New System.Drawing.Size(456, 26)
        Me.SHIP_ADDR4_T.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(86, 186)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 17)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "住所-2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_NAME2_T
        '
        Me.SHIP_NAME2_T.BackColor = System.Drawing.Color.White
        Me.SHIP_NAME2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_NAME2_T.Location = New System.Drawing.Point(159, 39)
        Me.SHIP_NAME2_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_NAME2_T.Name = "SHIP_NAME2_T"
        Me.SHIP_NAME2_T.Size = New System.Drawing.Size(307, 26)
        Me.SHIP_NAME2_T.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(94, 49)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 17)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "名称２"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_POSTCODE_T
        '
        Me.SHIP_POSTCODE_T.BackColor = System.Drawing.Color.White
        Me.SHIP_POSTCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_POSTCODE_T.Location = New System.Drawing.Point(159, 66)
        Me.SHIP_POSTCODE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_POSTCODE_T.Name = "SHIP_POSTCODE_T"
        Me.SHIP_POSTCODE_T.Size = New System.Drawing.Size(141, 26)
        Me.SHIP_POSTCODE_T.TabIndex = 18
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(72, 76)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 17)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "郵便番号"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_PONE_T
        '
        Me.SHIP_PONE_T.BackColor = System.Drawing.Color.White
        Me.SHIP_PONE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_PONE_T.Location = New System.Drawing.Point(159, 204)
        Me.SHIP_PONE_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_PONE_T.Name = "SHIP_PONE_T"
        Me.SHIP_PONE_T.Size = New System.Drawing.Size(245, 26)
        Me.SHIP_PONE_T.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(71, 214)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 17)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "電話番号"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_ADDR3_T
        '
        Me.SHIP_ADDR3_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SHIP_ADDR3_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR3_T.Location = New System.Drawing.Point(159, 149)
        Me.SHIP_ADDR3_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_ADDR3_T.Name = "SHIP_ADDR3_T"
        Me.SHIP_ADDR3_T.Size = New System.Drawing.Size(456, 26)
        Me.SHIP_ADDR3_T.TabIndex = 21
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(86, 159)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 17)
        Me.Label18.TabIndex = 67
        Me.Label18.Text = "住所-1"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_ADDR2_T
        '
        Me.SHIP_ADDR2_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SHIP_ADDR2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR2_T.Location = New System.Drawing.Point(159, 121)
        Me.SHIP_ADDR2_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_ADDR2_T.Name = "SHIP_ADDR2_T"
        Me.SHIP_ADDR2_T.Size = New System.Drawing.Size(180, 26)
        Me.SHIP_ADDR2_T.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(23, 131)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 17)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "住所（市区町村）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_ADDR1_T
        '
        Me.SHIP_ADDR1_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SHIP_ADDR1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_ADDR1_T.Location = New System.Drawing.Point(159, 94)
        Me.SHIP_ADDR1_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_ADDR1_T.Name = "SHIP_ADDR1_T"
        Me.SHIP_ADDR1_T.Size = New System.Drawing.Size(180, 26)
        Me.SHIP_ADDR1_T.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(23, 104)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 17)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "住所（都道府県）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_NAME1_T
        '
        Me.SHIP_NAME1_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SHIP_NAME1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SHIP_NAME1_T.Location = New System.Drawing.Point(159, 11)
        Me.SHIP_NAME1_T.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_NAME1_T.Name = "SHIP_NAME1_T"
        Me.SHIP_NAME1_T.Size = New System.Drawing.Size(307, 26)
        Me.SHIP_NAME1_T.TabIndex = 16
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(95, 21)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 17)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "名称１"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SHIP_MEMO
        '
        Me.SHIP_MEMO.Location = New System.Drawing.Point(150, 826)
        Me.SHIP_MEMO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SHIP_MEMO.Multiline = True
        Me.SHIP_MEMO.Name = "SHIP_MEMO"
        Me.SHIP_MEMO.Size = New System.Drawing.Size(1178, 52)
        Me.SHIP_MEMO.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(78, 829)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 17)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "出荷メモ"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Red
        Me.Label50.Location = New System.Drawing.Point(18, 849)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(124, 17)
        Me.Label50.TabIndex = 77
        Me.Label50.Text = "（納品書に印刷）"
        '
        'RESHIP_B
        '
        Me.RESHIP_B.ColorBottom = System.Drawing.Color.Tan
        Me.RESHIP_B.Location = New System.Drawing.Point(710, 888)
        Me.RESHIP_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.RESHIP_B.Name = "RESHIP_B"
        Me.RESHIP_B.Size = New System.Drawing.Size(146, 60)
        Me.RESHIP_B.TabIndex = 83
        Me.RESHIP_B.TextButton = "再出荷"
        '
        'DELIVERY_PRINT_B
        '
        Me.DELIVERY_PRINT_B.AllowDrop = True
        Me.DELIVERY_PRINT_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELIVERY_PRINT_B.Location = New System.Drawing.Point(874, 888)
        Me.DELIVERY_PRINT_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.DELIVERY_PRINT_B.Name = "DELIVERY_PRINT_B"
        Me.DELIVERY_PRINT_B.Size = New System.Drawing.Size(146, 60)
        Me.DELIVERY_PRINT_B.TabIndex = 29
        Me.DELIVERY_PRINT_B.TextButton = "納品書印刷"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(1030, 888)
        Me.COMMIT_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(146, 60)
        Me.COMMIT_B.TabIndex = 30
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(1182, 888)
        Me.RETURN_B.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(146, 60)
        Me.RETURN_B.TabIndex = 10
        Me.RETURN_B.TextButton = "終　了"
        '
        'RESHIP_L
        '
        Me.RESHIP_L.BackColor = System.Drawing.Color.Red
        Me.RESHIP_L.ForeColor = System.Drawing.Color.White
        Me.RESHIP_L.Location = New System.Drawing.Point(20, 10)
        Me.RESHIP_L.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RESHIP_L.Name = "RESHIP_L"
        Me.RESHIP_L.Size = New System.Drawing.Size(1327, 15)
        Me.RESHIP_L.TabIndex = 84
        Me.RESHIP_L.Text = "再出荷処理中"
        Me.RESHIP_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fShipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(1384, 884)
        Me.Controls.Add(Me.RESHIP_L)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELIVERY_PRINT_B)
        Me.Controls.Add(Me.RESHIP_B)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.SHIP_MEMO)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SHIPMENT_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "fShipment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "出庫処理"
        CType(Me.SHIPMENT_V,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.MEISAI_KINGAKU_G.ResumeLayout(false)
        Me.MEISAI_KINGAKU_G.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RQ_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents REQ_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RQ_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RQ_ADDR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SHIPMENT_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents RQ_PAYMENT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RQ_CHANNEL_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SHIP_RQ_TIME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents RQ_MAIL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents RQ_PONE_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SHIP_PONE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR3_T As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SHIP_ADDR1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SHIP_NAME1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SHIP_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents SHIP_PAY_T As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents SHIP_NAME2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents SHIP_POSTCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents MOTOCYAKU_CLASS_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CORP_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents BT_PRODUCT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents BT_P_DISCOUNT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents BT_FEE_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents BT_POSTAGE_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents BT_BILL_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents BT_DISCOUNT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents SHIP_MEMO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents SHIP_RQ_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents SHIP_CNT_L As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents BT_TAX_P_T As System.Windows.Forms.TextBox
    Friend WithEvents SHIP_ADDR4_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ARRIVE_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TIME_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RQ_BILL_P_T As System.Windows.Forms.TextBox
    Friend WithEvents RQ_DISCOUNT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents RQ_PRODUCT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents RQ_P_DISCOUNT_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents RQ_FEE_P_T As System.Windows.Forms.TextBox
    Friend WithEvents RQ_POSTAGE_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RQ_TAX_P_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents CORP_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents TIME_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MOTOCYAKU_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents SPEED_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents SPEED_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RESHIP_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELIVERY_PRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELIVERY_DATA_OUTPUT_B As Softgroup.NetButton.NetButton
    Friend WithEvents SHIP_FIX_C As System.Windows.Forms.CheckBox
    Friend WithEvents MEISAI_KINGAKU_G As System.Windows.Forms.GroupBox
    Friend WithEvents IN_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents OUT_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents RESHIP_L As System.Windows.Forms.Label
    Friend WithEvents RQ_PAYMENT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents RQ_DAIBIKI_C As System.Windows.Forms.CheckBox
    Friend WithEvents RQ_TIME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents RQ_RTAX_RATE_P_T As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents ShapeContainer3 As PowerPacks.ShapeContainer
    Friend WithEvents Label36 As Label
    Friend WithEvents BT_RTAX_RATE_P_T As TextBox
End Class
