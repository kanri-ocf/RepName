<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShipmentSearch
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
        Me.CHANNEL_NAME_L = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SHIPMENT_V = New System.Windows.Forms.DataGridView
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.S_REQUESTNUMBER_T = New System.Windows.Forms.TextBox
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.FROM_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.TO_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.TO_SHIP_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.FROM_SHIP_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ADDR_T = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.NAME_T = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.SEL_C = New System.Windows.Forms.CheckBox
        Me.COUNT_T = New System.Windows.Forms.TextBox
        Me.SEL_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.CORP_CODE_T = New System.Windows.Forms.TextBox
        Me.CORP_NAME_C = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        CType(Me.SHIPMENT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(129, 30)
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
        Me.Label1.Location = New System.Drawing.Point(53, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "受注コード："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHANNEL_NAME_L
        '
        Me.CHANNEL_NAME_L.DropDownHeight = 300
        Me.CHANNEL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_L.FormattingEnabled = True
        Me.CHANNEL_NAME_L.IntegralHeight = False
        Me.CHANNEL_NAME_L.Location = New System.Drawing.Point(129, 51)
        Me.CHANNEL_NAME_L.Name = "CHANNEL_NAME_L"
        Me.CHANNEL_NAME_L.Size = New System.Drawing.Size(191, 21)
        Me.CHANNEL_NAME_L.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "チャネル名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SHIPMENT_V
        '
        Me.SHIPMENT_V.AllowUserToAddRows = False
        Me.SHIPMENT_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.SHIPMENT_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SHIPMENT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SHIPMENT_V.ColumnHeadersHeight = 30
        Me.SHIPMENT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SHIPMENT_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.SHIPMENT_V.Location = New System.Drawing.Point(24, 166)
        Me.SHIPMENT_V.Name = "SHIPMENT_V"
        Me.SHIPMENT_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SHIPMENT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SHIPMENT_V.RowTemplate.Height = 21
        Me.SHIPMENT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SHIPMENT_V.Size = New System.Drawing.Size(907, 324)
        Me.SHIPMENT_V.TabIndex = 15
        Me.SHIPMENT_V.TabStop = False
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(282, 51)
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
        Me.Label3.Location = New System.Drawing.Point(427, 34)
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
        Me.Label4.Location = New System.Drawing.Point(587, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "～"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(129, 73)
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
        Me.Label5.Location = New System.Drawing.Point(52, 76)
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
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(129, 95)
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
        Me.Label6.Location = New System.Drawing.Point(55, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "商品名称："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'S_REQUESTNUMBER_T
        '
        Me.S_REQUESTNUMBER_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_REQUESTNUMBER_T.Location = New System.Drawing.Point(282, 30)
        Me.S_REQUESTNUMBER_T.Name = "S_REQUESTNUMBER_T"
        Me.S_REQUESTNUMBER_T.Size = New System.Drawing.Size(21, 19)
        Me.S_REQUESTNUMBER_T.TabIndex = 37
        Me.S_REQUESTNUMBER_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(129, 117)
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
        Me.Label7.Location = New System.Drawing.Point(32, 120)
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
        Me.Label8.Location = New System.Drawing.Point(587, 55)
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
        Me.Label9.Location = New System.Drawing.Point(428, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "出荷日："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(720, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 23)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(905, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 23)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "件"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FROM_REQUEST_DATE_T
        '
        Me.FROM_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_REQUEST_DATE_T.Location = New System.Drawing.Point(487, 31)
        Me.FROM_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_REQUEST_DATE_T.Name = "FROM_REQUEST_DATE_T"
        Me.FROM_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_REQUEST_DATE_T.TabIndex = 5
        Me.FROM_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_REQUEST_DATE_T
        '
        Me.TO_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_REQUEST_DATE_T.Location = New System.Drawing.Point(607, 31)
        Me.TO_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_REQUEST_DATE_T.Name = "TO_REQUEST_DATE_T"
        Me.TO_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_REQUEST_DATE_T.TabIndex = 6
        Me.TO_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_SHIP_DATE_T
        '
        Me.TO_SHIP_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_SHIP_DATE_T.Location = New System.Drawing.Point(607, 53)
        Me.TO_SHIP_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_SHIP_DATE_T.Name = "TO_SHIP_DATE_T"
        Me.TO_SHIP_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_SHIP_DATE_T.TabIndex = 8
        Me.TO_SHIP_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FROM_SHIP_DATE_T
        '
        Me.FROM_SHIP_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_SHIP_DATE_T.Location = New System.Drawing.Point(487, 53)
        Me.FROM_SHIP_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_SHIP_DATE_T.Name = "FROM_SHIP_DATE_T"
        Me.FROM_SHIP_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_SHIP_DATE_T.TabIndex = 7
        Me.FROM_SHIP_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(701, 87)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(112, 73)
        Me.SEARCH_B.TabIndex = 13
        Me.SEARCH_B.TextButton = "検　索"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(819, 87)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(112, 73)
        Me.RETURN_B.TabIndex = 14
        Me.RETURN_B.TextButton = "決　定"
        '
        'POST_CODE_T
        '
        Me.POST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.POST_CODE_T.Location = New System.Drawing.Point(487, 76)
        Me.POST_CODE_T.Name = "POST_CODE_T"
        Me.POST_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.POST_CODE_T.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Tan
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(368, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 15)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "出荷先郵便番号："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ADDR_T
        '
        Me.ADDR_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ADDR_T.Location = New System.Drawing.Point(487, 98)
        Me.ADDR_T.Name = "ADDR_T"
        Me.ADDR_T.Size = New System.Drawing.Size(208, 20)
        Me.ADDR_T.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Tan
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(398, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 15)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "出荷先住所："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NAME_T
        '
        Me.NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NAME_T.Location = New System.Drawing.Point(487, 119)
        Me.NAME_T.Name = "NAME_T"
        Me.NAME_T.Size = New System.Drawing.Size(208, 20)
        Me.NAME_T.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Tan
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(398, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 15)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "出荷先氏名："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SEL_C
        '
        Me.SEL_C.AutoSize = True
        Me.SEL_C.Checked = True
        Me.SEL_C.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SEL_C.Location = New System.Drawing.Point(487, 142)
        Me.SEL_C.Name = "SEL_C"
        Me.SEL_C.Size = New System.Drawing.Size(71, 16)
        Me.SEL_C.TabIndex = 53
        Me.SEL_C.Text = "選択済み"
        Me.SEL_C.UseVisualStyleBackColor = True
        '
        'COUNT_T
        '
        Me.COUNT_T.BackColor = System.Drawing.Color.Wheat
        Me.COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COUNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.COUNT_T.Location = New System.Drawing.Point(802, 55)
        Me.COUNT_T.Name = "COUNT_T"
        Me.COUNT_T.ReadOnly = True
        Me.COUNT_T.Size = New System.Drawing.Size(100, 26)
        Me.COUNT_T.TabIndex = 54
        Me.COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SEL_COUNT_T
        '
        Me.SEL_COUNT_T.BackColor = System.Drawing.Color.Wheat
        Me.SEL_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEL_COUNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SEL_COUNT_T.Location = New System.Drawing.Point(802, 29)
        Me.SEL_COUNT_T.Name = "SEL_COUNT_T"
        Me.SEL_COUNT_T.ReadOnly = True
        Me.SEL_COUNT_T.Size = New System.Drawing.Size(100, 26)
        Me.SEL_COUNT_T.TabIndex = 57
        Me.SEL_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(905, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 23)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "件"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(720, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 23)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "選択件数："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CORP_CODE_T
        '
        Me.CORP_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.CORP_CODE_T.Location = New System.Drawing.Point(282, 139)
        Me.CORP_CODE_T.Name = "CORP_CODE_T"
        Me.CORP_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.CORP_CODE_T.TabIndex = 60
        Me.CORP_CODE_T.Visible = False
        '
        'CORP_NAME_C
        '
        Me.CORP_NAME_C.DropDownHeight = 300
        Me.CORP_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CORP_NAME_C.FormattingEnabled = True
        Me.CORP_NAME_C.IntegralHeight = False
        Me.CORP_NAME_C.Location = New System.Drawing.Point(129, 139)
        Me.CORP_NAME_C.Name = "CORP_NAME_C"
        Me.CORP_NAME_C.Size = New System.Drawing.Size(191, 21)
        Me.CORP_NAME_C.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Tan
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(55, 143)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 15)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "配送業者："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fShipmentSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(958, 518)
        Me.Controls.Add(Me.CORP_CODE_T)
        Me.Controls.Add(Me.CORP_NAME_C)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.SEL_COUNT_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.COUNT_T)
        Me.Controls.Add(Me.SEL_C)
        Me.Controls.Add(Me.NAME_T)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ADDR_T)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.POST_CODE_T)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_NAME_L)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.REQUEST_CODE_T)
        Me.Controls.Add(Me.S_REQUESTNUMBER_T)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.TO_SHIP_DATE_T)
        Me.Controls.Add(Me.FROM_SHIP_DATE_T)
        Me.Controls.Add(Me.TO_REQUEST_DATE_T)
        Me.Controls.Add(Me.FROM_REQUEST_DATE_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SHIPMENT_V)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fShipmentSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出荷情報検索画面"
        CType(Me.SHIPMENT_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SHIPMENT_V As System.Windows.Forms.DataGridView
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FROM_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_SHIP_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents FROM_SHIP_DATE_T As System.Windows.Forms.MaskedTextBox
    Public WithEvents S_REQUESTNUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents POST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ADDR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SEL_C As System.Windows.Forms.CheckBox
    Public WithEvents SEL_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents CORP_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CORP_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
