<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCustomerOrder
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fCustomerOrder))
        Me.MSG_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.TRN_CODE_T = New System.Windows.Forms.TextBox()
        Me.CNT_T = New System.Windows.Forms.TextBox()
        Me.TRNSUB_CODE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MEISAI_V = New System.Windows.Forms.DataGridView()
        Me.PRICE_T = New System.Windows.Forms.TextBox()
        Me.ADVANCE_RECEIVED_L = New System.Windows.Forms.Label()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.FEE_L = New System.Windows.Forms.Label()
        Me.DELIVERY_CHARGE_L = New System.Windows.Forms.Label()
        Me.DISCOUNT_T = New System.Windows.Forms.TextBox()
        Me.OTHER_DISCOUNT_T = New System.Windows.Forms.TextBox()
        Me.PRICE_L = New System.Windows.Forms.Label()
        Me.DISCOUNT_L = New System.Windows.Forms.Label()
        Me.OTHER_DISCOUNT_L = New System.Windows.Forms.Label()
        Me.TAX_L = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.REMAINING_MONEY_T = New System.Windows.Forms.TextBox()
        Me.REMAINING_MONEY_L = New System.Windows.Forms.Label()
        Me.BILLING_AMOUNT_T = New System.Windows.Forms.TextBox()
        Me.BILLING_AMOUNT_L = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TFEE_T = New System.Windows.Forms.TextBox()
        Me.POSTAGE_T = New System.Windows.Forms.TextBox()
        Me.ADVANCE_RECEIVED_T = New System.Windows.Forms.TextBox()
        Me.TAX_T = New System.Windows.Forms.TextBox()
        Me.JAN_CODE_T = New System.Windows.Forms.TextBox()
        Me.PRODUCT_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.EXIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POINT_MEMBER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TRAN_HISTORY_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MENBERS_CODE_T = New System.Windows.Forms.TextBox()
        Me.POSTAL_CODE_T = New System.Windows.Forms.TextBox()
        Me.MENBERS_CODE_L = New System.Windows.Forms.Label()
        Me.POSTAL_CODE_L = New System.Windows.Forms.Label()
        Me.ADDRESS_L = New System.Windows.Forms.Label()
        Me.COMPANY_NAME_L = New System.Windows.Forms.Label()
        Me.FULL_NAME_L = New System.Windows.Forms.Label()
        Me.PHONE_NUMBER_L = New System.Windows.Forms.Label()
        Me.ADDRESS_T = New System.Windows.Forms.TextBox()
        Me.COMPANY_NAME_T = New System.Windows.Forms.TextBox()
        Me.FULL_NAME_T = New System.Windows.Forms.TextBox()
        Me.PHONE_NUMBER_T = New System.Windows.Forms.TextBox()
        Me.ORDERER_G = New System.Windows.Forms.GroupBox()
        Me.CUSTOMER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.JAN_CODE_L = New System.Windows.Forms.Label()
        Me.CNT_L = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SEND_POST_T = New System.Windows.Forms.TextBox()
        Me.SEND_ADDRESS_T = New System.Windows.Forms.TextBox()
        Me.SEND_COMPANY_T = New System.Windows.Forms.TextBox()
        Me.SEND_NAME_T = New System.Windows.Forms.TextBox()
        Me.SEND_TEL_T = New System.Windows.Forms.TextBox()
        Me.COPY_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.RQDATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.RQTIME_T = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PAYMENT_C = New System.Windows.Forms.ComboBox()
        Me.ORDER_NUMBER_L = New System.Windows.Forms.Label()
        Me.ORDER_NUMBER_T = New System.Windows.Forms.TextBox()
        Me.READ_MENBER_CODE_L = New System.Windows.Forms.Label()
        Me.READ_MENBER_CODE_T = New System.Windows.Forms.TextBox()
        Me.MENBER_NAME_L = New System.Windows.Forms.Label()
        Me.MENBER_NAME_T = New System.Windows.Forms.TextBox()
        Me.MEMBER_INFORMATION＿G = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.NEW_REGISTRATION_L = New System.Windows.Forms.Label()
        Me.UPDATE_L = New System.Windows.Forms.Label()
        CType(Me.MEISAI_V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.ORDERER_G.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MEMBER_INFORMATION＿G.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MSG_T
        '
        Me.MSG_T.BackColor = System.Drawing.Color.Tan
        Me.MSG_T.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MSG_T.ForeColor = System.Drawing.Color.Black
        Me.MSG_T.Location = New System.Drawing.Point(12, 716)
        Me.MSG_T.Multiline = True
        Me.MSG_T.Name = "MSG_T"
        Me.MSG_T.ReadOnly = True
        Me.MSG_T.Size = New System.Drawing.Size(516, 20)
        Me.MSG_T.TabIndex = 228
        Me.MSG_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.AcceptsReturn = True
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Tan
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ForeColor = System.Drawing.Color.Black
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(57, 740)
        Me.STAFF_CODE_T.MaxLength = 999999999
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(110, 20)
        Me.STAFF_CODE_T.TabIndex = 243
        Me.STAFF_CODE_T.TabStop = False
        Me.STAFF_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TRN_CODE_T
        '
        Me.TRN_CODE_T.AcceptsReturn = True
        Me.TRN_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TRN_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TRN_CODE_T.ForeColor = System.Drawing.Color.Black
        Me.TRN_CODE_T.Location = New System.Drawing.Point(365, 741)
        Me.TRN_CODE_T.MaxLength = 999999999
        Me.TRN_CODE_T.Name = "TRN_CODE_T"
        Me.TRN_CODE_T.ReadOnly = True
        Me.TRN_CODE_T.Size = New System.Drawing.Size(55, 20)
        Me.TRN_CODE_T.TabIndex = 240
        Me.TRN_CODE_T.TabStop = False
        Me.TRN_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TRN_CODE_T.Visible = False
        '
        'CNT_T
        '
        Me.CNT_T.BackColor = System.Drawing.Color.LightYellow
        Me.CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CNT_T.ForeColor = System.Drawing.Color.Black
        Me.CNT_T.Location = New System.Drawing.Point(354, 89)
        Me.CNT_T.MaxLength = 999999999
        Me.CNT_T.Name = "CNT_T"
        Me.CNT_T.Size = New System.Drawing.Size(79, 44)
        Me.CNT_T.TabIndex = 235
        Me.CNT_T.TabStop = False
        Me.CNT_T.Text = "1"
        Me.CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TRNSUB_CODE
        '
        Me.TRNSUB_CODE.AcceptsReturn = True
        Me.TRNSUB_CODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TRNSUB_CODE.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TRNSUB_CODE.ForeColor = System.Drawing.Color.Black
        Me.TRNSUB_CODE.Location = New System.Drawing.Point(426, 741)
        Me.TRNSUB_CODE.MaxLength = 999999999
        Me.TRNSUB_CODE.Name = "TRNSUB_CODE"
        Me.TRNSUB_CODE.ReadOnly = True
        Me.TRNSUB_CODE.Size = New System.Drawing.Size(46, 20)
        Me.TRNSUB_CODE.TabIndex = 229
        Me.TRNSUB_CODE.TabStop = False
        Me.TRNSUB_CODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TRNSUB_CODE.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 743)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "担当者"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 30)
        Me.Label8.TabIndex = 236
        Me.Label8.Text = "×"
        '
        'MEISAI_V
        '
        Me.MEISAI_V.AllowUserToAddRows = False
        Me.MEISAI_V.AllowUserToResizeColumns = False
        Me.MEISAI_V.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.MEISAI_V.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MEISAI_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.MEISAI_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MEISAI_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MEISAI_V.ColumnHeadersHeight = 28
        Me.MEISAI_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MEISAI_V.DefaultCellStyle = DataGridViewCellStyle3
        Me.MEISAI_V.Location = New System.Drawing.Point(22, 338)
        Me.MEISAI_V.MultiSelect = False
        Me.MEISAI_V.Name = "MEISAI_V"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MEISAI_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEISAI_V.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.MEISAI_V.RowTemplate.Height = 30
        Me.MEISAI_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MEISAI_V.Size = New System.Drawing.Size(989, 227)
        Me.MEISAI_V.TabIndex = 249
        '
        'PRICE_T
        '
        Me.PRICE_T.AcceptsReturn = True
        Me.PRICE_T.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.PRICE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRICE_T.ForeColor = System.Drawing.Color.Black
        Me.PRICE_T.Location = New System.Drawing.Point(84, 37)
        Me.PRICE_T.MaxLength = 999999999
        Me.PRICE_T.Name = "PRICE_T"
        Me.PRICE_T.ReadOnly = True
        Me.PRICE_T.Size = New System.Drawing.Size(102, 23)
        Me.PRICE_T.TabIndex = 251
        Me.PRICE_T.TabStop = False
        Me.PRICE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ADVANCE_RECEIVED_L
        '
        Me.ADVANCE_RECEIVED_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.ADVANCE_RECEIVED_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADVANCE_RECEIVED_L.ForeColor = System.Drawing.Color.White
        Me.ADVANCE_RECEIVED_L.Location = New System.Drawing.Point(800, 10)
        Me.ADVANCE_RECEIVED_L.Name = "ADVANCE_RECEIVED_L"
        Me.ADVANCE_RECEIVED_L.Size = New System.Drawing.Size(105, 24)
        Me.ADVANCE_RECEIVED_L.TabIndex = 256
        Me.ADVANCE_RECEIVED_L.Text = "前受金"
        Me.ADVANCE_RECEIVED_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbImage
        '
        Me.pbImage.Image = CType(resources.GetObject("pbImage.Image"), System.Drawing.Image)
        Me.pbImage.Location = New System.Drawing.Point(340, 738)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(19, 22)
        Me.pbImage.TabIndex = 248
        Me.pbImage.TabStop = False
        Me.pbImage.Visible = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.AcceptsReturn = True
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Tan
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ForeColor = System.Drawing.Color.Black
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(173, 740)
        Me.STAFF_NAME_T.MaxLength = 999999999
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(161, 20)
        Me.STAFF_NAME_T.TabIndex = 260
        Me.STAFF_NAME_T.TabStop = False
        '
        'FEE_L
        '
        Me.FEE_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.FEE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FEE_L.ForeColor = System.Drawing.Color.White
        Me.FEE_L.Location = New System.Drawing.Point(383, 10)
        Me.FEE_L.Name = "FEE_L"
        Me.FEE_L.Size = New System.Drawing.Size(78, 24)
        Me.FEE_L.TabIndex = 270
        Me.FEE_L.Text = "手数料"
        Me.FEE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DELIVERY_CHARGE_L
        '
        Me.DELIVERY_CHARGE_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.DELIVERY_CHARGE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DELIVERY_CHARGE_L.ForeColor = System.Drawing.Color.White
        Me.DELIVERY_CHARGE_L.Location = New System.Drawing.Point(301, 10)
        Me.DELIVERY_CHARGE_L.Name = "DELIVERY_CHARGE_L"
        Me.DELIVERY_CHARGE_L.Size = New System.Drawing.Size(76, 24)
        Me.DELIVERY_CHARGE_L.TabIndex = 268
        Me.DELIVERY_CHARGE_L.Text = "送料"
        Me.DELIVERY_CHARGE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DISCOUNT_T
        '
        Me.DISCOUNT_T.AcceptsReturn = True
        Me.DISCOUNT_T.BackColor = System.Drawing.Color.LightPink
        Me.DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DISCOUNT_T.ForeColor = System.Drawing.Color.Black
        Me.DISCOUNT_T.Location = New System.Drawing.Point(192, 37)
        Me.DISCOUNT_T.MaxLength = 999999999
        Me.DISCOUNT_T.Name = "DISCOUNT_T"
        Me.DISCOUNT_T.ReadOnly = True
        Me.DISCOUNT_T.Size = New System.Drawing.Size(103, 23)
        Me.DISCOUNT_T.TabIndex = 275
        Me.DISCOUNT_T.TabStop = False
        Me.DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'OTHER_DISCOUNT_T
        '
        Me.OTHER_DISCOUNT_T.AcceptsReturn = True
        Me.OTHER_DISCOUNT_T.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.OTHER_DISCOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OTHER_DISCOUNT_T.ForeColor = System.Drawing.Color.Black
        Me.OTHER_DISCOUNT_T.Location = New System.Drawing.Point(467, 37)
        Me.OTHER_DISCOUNT_T.MaxLength = 999999999
        Me.OTHER_DISCOUNT_T.Name = "OTHER_DISCOUNT_T"
        Me.OTHER_DISCOUNT_T.ReadOnly = True
        Me.OTHER_DISCOUNT_T.Size = New System.Drawing.Size(89, 23)
        Me.OTHER_DISCOUNT_T.TabIndex = 278
        Me.OTHER_DISCOUNT_T.TabStop = False
        Me.OTHER_DISCOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PRICE_L
        '
        Me.PRICE_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.PRICE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRICE_L.ForeColor = System.Drawing.Color.White
        Me.PRICE_L.Location = New System.Drawing.Point(84, 10)
        Me.PRICE_L.Name = "PRICE_L"
        Me.PRICE_L.Size = New System.Drawing.Size(102, 24)
        Me.PRICE_L.TabIndex = 281
        Me.PRICE_L.Text = "請求商品代金"
        Me.PRICE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DISCOUNT_L
        '
        Me.DISCOUNT_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.DISCOUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DISCOUNT_L.ForeColor = System.Drawing.Color.White
        Me.DISCOUNT_L.Location = New System.Drawing.Point(192, 10)
        Me.DISCOUNT_L.Name = "DISCOUNT_L"
        Me.DISCOUNT_L.Size = New System.Drawing.Size(103, 24)
        Me.DISCOUNT_L.TabIndex = 282
        Me.DISCOUNT_L.Text = "会員値引"
        Me.DISCOUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OTHER_DISCOUNT_L
        '
        Me.OTHER_DISCOUNT_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.OTHER_DISCOUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OTHER_DISCOUNT_L.ForeColor = System.Drawing.Color.White
        Me.OTHER_DISCOUNT_L.Location = New System.Drawing.Point(467, 10)
        Me.OTHER_DISCOUNT_L.Name = "OTHER_DISCOUNT_L"
        Me.OTHER_DISCOUNT_L.Size = New System.Drawing.Size(89, 24)
        Me.OTHER_DISCOUNT_L.TabIndex = 283
        Me.OTHER_DISCOUNT_L.Text = "その他値引"
        Me.OTHER_DISCOUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TAX_L
        '
        Me.TAX_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.TAX_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_L.ForeColor = System.Drawing.Color.White
        Me.TAX_L.Location = New System.Drawing.Point(711, 10)
        Me.TAX_L.Name = "TAX_L"
        Me.TAX_L.Size = New System.Drawing.Size(83, 24)
        Me.TAX_L.TabIndex = 284
        Me.TAX_L.Text = "消費税"
        Me.TAX_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Tan
        Me.GroupBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox8.Controls.Add(Me.REMAINING_MONEY_T)
        Me.GroupBox8.Controls.Add(Me.REMAINING_MONEY_L)
        Me.GroupBox8.Controls.Add(Me.BILLING_AMOUNT_T)
        Me.GroupBox8.Controls.Add(Me.BILLING_AMOUNT_L)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.TFEE_T)
        Me.GroupBox8.Controls.Add(Me.POSTAGE_T)
        Me.GroupBox8.Controls.Add(Me.ADVANCE_RECEIVED_T)
        Me.GroupBox8.Controls.Add(Me.TAX_T)
        Me.GroupBox8.Controls.Add(Me.TAX_L)
        Me.GroupBox8.Controls.Add(Me.OTHER_DISCOUNT_L)
        Me.GroupBox8.Controls.Add(Me.OTHER_DISCOUNT_T)
        Me.GroupBox8.Controls.Add(Me.DISCOUNT_L)
        Me.GroupBox8.Controls.Add(Me.PRICE_L)
        Me.GroupBox8.Controls.Add(Me.DISCOUNT_T)
        Me.GroupBox8.Controls.Add(Me.FEE_L)
        Me.GroupBox8.Controls.Add(Me.DELIVERY_CHARGE_L)
        Me.GroupBox8.Controls.Add(Me.PRICE_T)
        Me.GroupBox8.Controls.Add(Me.ADVANCE_RECEIVED_L)
        Me.GroupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox8.Location = New System.Drawing.Point(10, 583)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(1004, 64)
        Me.GroupBox8.TabIndex = 301
        Me.GroupBox8.TabStop = False
        '
        'REMAINING_MONEY_T
        '
        Me.REMAINING_MONEY_T.AcceptsReturn = True
        Me.REMAINING_MONEY_T.BackColor = System.Drawing.Color.PaleTurquoise
        Me.REMAINING_MONEY_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REMAINING_MONEY_T.ForeColor = System.Drawing.Color.Black
        Me.REMAINING_MONEY_T.Location = New System.Drawing.Point(911, 37)
        Me.REMAINING_MONEY_T.MaxLength = 999999999
        Me.REMAINING_MONEY_T.Name = "REMAINING_MONEY_T"
        Me.REMAINING_MONEY_T.ReadOnly = True
        Me.REMAINING_MONEY_T.Size = New System.Drawing.Size(79, 23)
        Me.REMAINING_MONEY_T.TabIndex = 297
        Me.REMAINING_MONEY_T.TabStop = False
        Me.REMAINING_MONEY_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'REMAINING_MONEY_L
        '
        Me.REMAINING_MONEY_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.REMAINING_MONEY_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REMAINING_MONEY_L.ForeColor = System.Drawing.Color.White
        Me.REMAINING_MONEY_L.Location = New System.Drawing.Point(911, 9)
        Me.REMAINING_MONEY_L.Name = "REMAINING_MONEY_L"
        Me.REMAINING_MONEY_L.Size = New System.Drawing.Size(79, 24)
        Me.REMAINING_MONEY_L.TabIndex = 296
        Me.REMAINING_MONEY_L.Text = "残金"
        Me.REMAINING_MONEY_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BILLING_AMOUNT_T
        '
        Me.BILLING_AMOUNT_T.AcceptsReturn = True
        Me.BILLING_AMOUNT_T.BackColor = System.Drawing.Color.PaleTurquoise
        Me.BILLING_AMOUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILLING_AMOUNT_T.ForeColor = System.Drawing.Color.Black
        Me.BILLING_AMOUNT_T.Location = New System.Drawing.Point(594, 37)
        Me.BILLING_AMOUNT_T.MaxLength = 999999999
        Me.BILLING_AMOUNT_T.Name = "BILLING_AMOUNT_T"
        Me.BILLING_AMOUNT_T.ReadOnly = True
        Me.BILLING_AMOUNT_T.Size = New System.Drawing.Size(111, 23)
        Me.BILLING_AMOUNT_T.TabIndex = 293
        Me.BILLING_AMOUNT_T.TabStop = False
        Me.BILLING_AMOUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BILLING_AMOUNT_L
        '
        Me.BILLING_AMOUNT_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.BILLING_AMOUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BILLING_AMOUNT_L.ForeColor = System.Drawing.Color.White
        Me.BILLING_AMOUNT_L.Location = New System.Drawing.Point(594, 10)
        Me.BILLING_AMOUNT_L.Name = "BILLING_AMOUNT_L"
        Me.BILLING_AMOUNT_L.Size = New System.Drawing.Size(111, 24)
        Me.BILLING_AMOUNT_L.TabIndex = 292
        Me.BILLING_AMOUNT_L.Text = "請求金額(税抜)"
        Me.BILLING_AMOUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(5, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 50)
        Me.Label12.TabIndex = 291
        Me.Label12.Text = "請求情報"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TFEE_T
        '
        Me.TFEE_T.AcceptsReturn = True
        Me.TFEE_T.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.TFEE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TFEE_T.ForeColor = System.Drawing.Color.Black
        Me.TFEE_T.Location = New System.Drawing.Point(383, 37)
        Me.TFEE_T.MaxLength = 999999999
        Me.TFEE_T.Name = "TFEE_T"
        Me.TFEE_T.ReadOnly = True
        Me.TFEE_T.Size = New System.Drawing.Size(78, 23)
        Me.TFEE_T.TabIndex = 290
        Me.TFEE_T.TabStop = False
        Me.TFEE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'POSTAGE_T
        '
        Me.POSTAGE_T.AcceptsReturn = True
        Me.POSTAGE_T.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.POSTAGE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAGE_T.ForeColor = System.Drawing.Color.Black
        Me.POSTAGE_T.Location = New System.Drawing.Point(301, 37)
        Me.POSTAGE_T.MaxLength = 999999999
        Me.POSTAGE_T.Name = "POSTAGE_T"
        Me.POSTAGE_T.ReadOnly = True
        Me.POSTAGE_T.Size = New System.Drawing.Size(76, 23)
        Me.POSTAGE_T.TabIndex = 289
        Me.POSTAGE_T.TabStop = False
        Me.POSTAGE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ADVANCE_RECEIVED_T
        '
        Me.ADVANCE_RECEIVED_T.AcceptsReturn = True
        Me.ADVANCE_RECEIVED_T.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ADVANCE_RECEIVED_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADVANCE_RECEIVED_T.ForeColor = System.Drawing.Color.Black
        Me.ADVANCE_RECEIVED_T.Location = New System.Drawing.Point(800, 37)
        Me.ADVANCE_RECEIVED_T.MaxLength = 999999999
        Me.ADVANCE_RECEIVED_T.Name = "ADVANCE_RECEIVED_T"
        Me.ADVANCE_RECEIVED_T.ReadOnly = True
        Me.ADVANCE_RECEIVED_T.Size = New System.Drawing.Size(105, 23)
        Me.ADVANCE_RECEIVED_T.TabIndex = 288
        Me.ADVANCE_RECEIVED_T.TabStop = False
        Me.ADVANCE_RECEIVED_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAX_T
        '
        Me.TAX_T.AcceptsReturn = True
        Me.TAX_T.BackColor = System.Drawing.Color.PaleTurquoise
        Me.TAX_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_T.ForeColor = System.Drawing.Color.Black
        Me.TAX_T.Location = New System.Drawing.Point(711, 37)
        Me.TAX_T.MaxLength = 999999999
        Me.TAX_T.Name = "TAX_T"
        Me.TAX_T.ReadOnly = True
        Me.TAX_T.Size = New System.Drawing.Size(83, 23)
        Me.TAX_T.TabIndex = 287
        Me.TAX_T.TabStop = False
        Me.TAX_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'JAN_CODE_T
        '
        Me.JAN_CODE_T.AcceptsReturn = True
        Me.JAN_CODE_T.BackColor = System.Drawing.Color.LightYellow
        Me.JAN_CODE_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JAN_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JAN_CODE_T.ForeColor = System.Drawing.Color.Black
        Me.JAN_CODE_T.Location = New System.Drawing.Point(19, 89)
        Me.JAN_CODE_T.MaxLength = 13
        Me.JAN_CODE_T.Name = "JAN_CODE_T"
        Me.JAN_CODE_T.Size = New System.Drawing.Size(301, 44)
        Me.JAN_CODE_T.TabIndex = 1
        Me.JAN_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PRODUCT_SEARCH_B
        '
        Me.PRODUCT_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.PRODUCT_SEARCH_B.CornerRadius = 10
        Me.PRODUCT_SEARCH_B.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_SEARCH_B.Location = New System.Drawing.Point(766, 268)
        Me.PRODUCT_SEARCH_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PRODUCT_SEARCH_B.Name = "PRODUCT_SEARCH_B"
        Me.PRODUCT_SEARCH_B.Size = New System.Drawing.Size(245, 57)
        Me.PRODUCT_SEARCH_B.TabIndex = 342
        Me.PRODUCT_SEARCH_B.TabStop = False
        Me.PRODUCT_SEARCH_B.TextButton = "商 品 検 索"
        '
        'MEMBER_B
        '
        Me.MEMBER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_B.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_B.Location = New System.Drawing.Point(791, 717)
        Me.MEMBER_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MEMBER_B.Name = "MEMBER_B"
        Me.MEMBER_B.Size = New System.Drawing.Size(110, 44)
        Me.MEMBER_B.TabIndex = 343
        Me.MEMBER_B.TabStop = False
        Me.MEMBER_B.TextButton = "会員登録"
        '
        'EXIT_B
        '
        Me.EXIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.EXIT_B.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EXIT_B.Location = New System.Drawing.Point(907, 717)
        Me.EXIT_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EXIT_B.Name = "EXIT_B"
        Me.EXIT_B.Size = New System.Drawing.Size(110, 44)
        Me.EXIT_B.TabIndex = 344
        Me.EXIT_B.TabStop = False
        Me.EXIT_B.TextButton = "終　了"
        '
        'POINT_MEMBER_B
        '
        Me.POINT_MEMBER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.POINT_MEMBER_B.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_MEMBER_B.Location = New System.Drawing.Point(662, 717)
        Me.POINT_MEMBER_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.POINT_MEMBER_B.Name = "POINT_MEMBER_B"
        Me.POINT_MEMBER_B.Size = New System.Drawing.Size(122, 44)
        Me.POINT_MEMBER_B.TabIndex = 345
        Me.POINT_MEMBER_B.TabStop = False
        Me.POINT_MEMBER_B.TextButton = "ポイント会員登録"
        '
        'TRAN_HISTORY_B
        '
        Me.TRAN_HISTORY_B.ColorBottom = System.Drawing.Color.Wheat
        Me.TRAN_HISTORY_B.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TRAN_HISTORY_B.Location = New System.Drawing.Point(534, 717)
        Me.TRAN_HISTORY_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TRAN_HISTORY_B.Name = "TRAN_HISTORY_B"
        Me.TRAN_HISTORY_B.Size = New System.Drawing.Size(122, 44)
        Me.TRAN_HISTORY_B.TabIndex = 346
        Me.TRAN_HISTORY_B.TabStop = False
        Me.TRAN_HISTORY_B.TextButton = "取引履歴"
        '
        'MENBERS_CODE_T
        '
        Me.MENBERS_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MENBERS_CODE_T.Location = New System.Drawing.Point(80, 13)
        Me.MENBERS_CODE_T.MaxLength = 13
        Me.MENBERS_CODE_T.Name = "MENBERS_CODE_T"
        Me.MENBERS_CODE_T.ReadOnly = True
        Me.MENBERS_CODE_T.Size = New System.Drawing.Size(155, 20)
        Me.MENBERS_CODE_T.TabIndex = 347
        '
        'POSTAL_CODE_T
        '
        Me.POSTAL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAL_CODE_T.Location = New System.Drawing.Point(80, 44)
        Me.POSTAL_CODE_T.MaxLength = 8
        Me.POSTAL_CODE_T.Name = "POSTAL_CODE_T"
        Me.POSTAL_CODE_T.Size = New System.Drawing.Size(155, 20)
        Me.POSTAL_CODE_T.TabIndex = 2
        '
        'MENBERS_CODE_L
        '
        Me.MENBERS_CODE_L.AutoSize = True
        Me.MENBERS_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MENBERS_CODE_L.Location = New System.Drawing.Point(6, 15)
        Me.MENBERS_CODE_L.Name = "MENBERS_CODE_L"
        Me.MENBERS_CODE_L.Size = New System.Drawing.Size(69, 13)
        Me.MENBERS_CODE_L.TabIndex = 349
        Me.MENBERS_CODE_L.Text = "会員コード："
        '
        'POSTAL_CODE_L
        '
        Me.POSTAL_CODE_L.AutoSize = True
        Me.POSTAL_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAL_CODE_L.Location = New System.Drawing.Point(9, 47)
        Me.POSTAL_CODE_L.Name = "POSTAL_CODE_L"
        Me.POSTAL_CODE_L.Size = New System.Drawing.Size(66, 13)
        Me.POSTAL_CODE_L.TabIndex = 350
        Me.POSTAL_CODE_L.Text = "郵便番号："
        '
        'ADDRESS_L
        '
        Me.ADDRESS_L.AutoSize = True
        Me.ADDRESS_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS_L.Location = New System.Drawing.Point(35, 79)
        Me.ADDRESS_L.Name = "ADDRESS_L"
        Me.ADDRESS_L.Size = New System.Drawing.Size(40, 13)
        Me.ADDRESS_L.TabIndex = 351
        Me.ADDRESS_L.Text = "住所："
        '
        'COMPANY_NAME_L
        '
        Me.COMPANY_NAME_L.AutoSize = True
        Me.COMPANY_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMPANY_NAME_L.Location = New System.Drawing.Point(22, 111)
        Me.COMPANY_NAME_L.Name = "COMPANY_NAME_L"
        Me.COMPANY_NAME_L.Size = New System.Drawing.Size(53, 13)
        Me.COMPANY_NAME_L.TabIndex = 352
        Me.COMPANY_NAME_L.Text = "会社名："
        '
        'FULL_NAME_L
        '
        Me.FULL_NAME_L.AutoSize = True
        Me.FULL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FULL_NAME_L.Location = New System.Drawing.Point(35, 143)
        Me.FULL_NAME_L.Name = "FULL_NAME_L"
        Me.FULL_NAME_L.Size = New System.Drawing.Size(40, 13)
        Me.FULL_NAME_L.TabIndex = 353
        Me.FULL_NAME_L.Text = "氏名："
        '
        'PHONE_NUMBER_L
        '
        Me.PHONE_NUMBER_L.AutoSize = True
        Me.PHONE_NUMBER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHONE_NUMBER_L.Location = New System.Drawing.Point(6, 175)
        Me.PHONE_NUMBER_L.Name = "PHONE_NUMBER_L"
        Me.PHONE_NUMBER_L.Size = New System.Drawing.Size(66, 13)
        Me.PHONE_NUMBER_L.TabIndex = 354
        Me.PHONE_NUMBER_L.Text = "電話番号："
        '
        'ADDRESS_T
        '
        Me.ADDRESS_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS_T.Location = New System.Drawing.Point(80, 77)
        Me.ADDRESS_T.MaxLength = 150
        Me.ADDRESS_T.Name = "ADDRESS_T"
        Me.ADDRESS_T.Size = New System.Drawing.Size(318, 20)
        Me.ADDRESS_T.TabIndex = 355
        '
        'COMPANY_NAME_T
        '
        Me.COMPANY_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMPANY_NAME_T.Location = New System.Drawing.Point(80, 106)
        Me.COMPANY_NAME_T.MaxLength = 50
        Me.COMPANY_NAME_T.Name = "COMPANY_NAME_T"
        Me.COMPANY_NAME_T.Size = New System.Drawing.Size(318, 20)
        Me.COMPANY_NAME_T.TabIndex = 356
        '
        'FULL_NAME_T
        '
        Me.FULL_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FULL_NAME_T.Location = New System.Drawing.Point(80, 137)
        Me.FULL_NAME_T.MaxLength = 20
        Me.FULL_NAME_T.Name = "FULL_NAME_T"
        Me.FULL_NAME_T.Size = New System.Drawing.Size(318, 20)
        Me.FULL_NAME_T.TabIndex = 357
        '
        'PHONE_NUMBER_T
        '
        Me.PHONE_NUMBER_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHONE_NUMBER_T.Location = New System.Drawing.Point(80, 168)
        Me.PHONE_NUMBER_T.MaxLength = 12
        Me.PHONE_NUMBER_T.Name = "PHONE_NUMBER_T"
        Me.PHONE_NUMBER_T.Size = New System.Drawing.Size(196, 20)
        Me.PHONE_NUMBER_T.TabIndex = 358
        '
        'ORDERER_G
        '
        Me.ORDERER_G.Controls.Add(Me.CUSTOMER_SEARCH_B)
        Me.ORDERER_G.Controls.Add(Me.PHONE_NUMBER_T)
        Me.ORDERER_G.Controls.Add(Me.FULL_NAME_T)
        Me.ORDERER_G.Controls.Add(Me.COMPANY_NAME_T)
        Me.ORDERER_G.Controls.Add(Me.ADDRESS_T)
        Me.ORDERER_G.Controls.Add(Me.PHONE_NUMBER_L)
        Me.ORDERER_G.Controls.Add(Me.FULL_NAME_L)
        Me.ORDERER_G.Controls.Add(Me.COMPANY_NAME_L)
        Me.ORDERER_G.Controls.Add(Me.ADDRESS_L)
        Me.ORDERER_G.Controls.Add(Me.POSTAL_CODE_L)
        Me.ORDERER_G.Controls.Add(Me.MENBERS_CODE_L)
        Me.ORDERER_G.Controls.Add(Me.POSTAL_CODE_T)
        Me.ORDERER_G.Controls.Add(Me.MENBERS_CODE_T)
        Me.ORDERER_G.Location = New System.Drawing.Point(22, 137)
        Me.ORDERER_G.Name = "ORDERER_G"
        Me.ORDERER_G.Size = New System.Drawing.Size(404, 194)
        Me.ORDERER_G.TabIndex = 359
        Me.ORDERER_G.TabStop = False
        Me.ORDERER_G.Text = "【注文者情報】"
        '
        'CUSTOMER_SEARCH_B
        '
        Me.CUSTOMER_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CUSTOMER_SEARCH_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CUSTOMER_SEARCH_B.Location = New System.Drawing.Point(241, 13)
        Me.CUSTOMER_SEARCH_B.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.CUSTOMER_SEARCH_B.Name = "CUSTOMER_SEARCH_B"
        Me.CUSTOMER_SEARCH_B.Size = New System.Drawing.Size(157, 56)
        Me.CUSTOMER_SEARCH_B.TabIndex = 359
        Me.CUSTOMER_SEARCH_B.TextButton = "顧客検索"
        '
        'JAN_CODE_L
        '
        Me.JAN_CODE_L.AutoSize = True
        Me.JAN_CODE_L.Location = New System.Drawing.Point(18, 72)
        Me.JAN_CODE_L.Name = "JAN_CODE_L"
        Me.JAN_CODE_L.Size = New System.Drawing.Size(67, 12)
        Me.JAN_CODE_L.TabIndex = 360
        Me.JAN_CODE_L.Text = "【JANコード】"
        '
        'CNT_L
        '
        Me.CNT_L.AutoSize = True
        Me.CNT_L.Location = New System.Drawing.Point(354, 72)
        Me.CNT_L.Name = "CNT_L"
        Me.CNT_L.Size = New System.Drawing.Size(41, 12)
        Me.CNT_L.TabIndex = 361
        Me.CNT_L.Text = "【数量】"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 362
        Me.Label17.Text = "郵便番号："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(30, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 363
        Me.Label18.Text = "住所："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(18, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 364
        Me.Label19.Text = "会社名："
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(30, 118)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 365
        Me.Label20.Text = "氏名："
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 13)
        Me.Label21.TabIndex = 366
        Me.Label21.Text = "電話番号："
        '
        'SEND_POST_T
        '
        Me.SEND_POST_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEND_POST_T.Location = New System.Drawing.Point(72, 37)
        Me.SEND_POST_T.Name = "SEND_POST_T"
        Me.SEND_POST_T.Size = New System.Drawing.Size(126, 20)
        Me.SEND_POST_T.TabIndex = 367
        '
        'SEND_ADDRESS_T
        '
        Me.SEND_ADDRESS_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEND_ADDRESS_T.Location = New System.Drawing.Point(72, 62)
        Me.SEND_ADDRESS_T.Name = "SEND_ADDRESS_T"
        Me.SEND_ADDRESS_T.Size = New System.Drawing.Size(243, 20)
        Me.SEND_ADDRESS_T.TabIndex = 368
        '
        'SEND_COMPANY_T
        '
        Me.SEND_COMPANY_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEND_COMPANY_T.Location = New System.Drawing.Point(72, 86)
        Me.SEND_COMPANY_T.Name = "SEND_COMPANY_T"
        Me.SEND_COMPANY_T.Size = New System.Drawing.Size(243, 20)
        Me.SEND_COMPANY_T.TabIndex = 369
        '
        'SEND_NAME_T
        '
        Me.SEND_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEND_NAME_T.Location = New System.Drawing.Point(72, 112)
        Me.SEND_NAME_T.Name = "SEND_NAME_T"
        Me.SEND_NAME_T.Size = New System.Drawing.Size(193, 20)
        Me.SEND_NAME_T.TabIndex = 370
        '
        'SEND_TEL_T
        '
        Me.SEND_TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEND_TEL_T.Location = New System.Drawing.Point(72, 138)
        Me.SEND_TEL_T.Name = "SEND_TEL_T"
        Me.SEND_TEL_T.Size = New System.Drawing.Size(126, 20)
        Me.SEND_TEL_T.TabIndex = 371
        '
        'COPY_B
        '
        Me.COPY_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COPY_B.Location = New System.Drawing.Point(204, 31)
        Me.COPY_B.Name = "COPY_B"
        Me.COPY_B.Size = New System.Drawing.Size(111, 29)
        Me.COPY_B.TabIndex = 372
        Me.COPY_B.TextButton = "コピー"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(30, 170)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 373
        Me.Label22.Text = "支払方法："
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(18, 196)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(79, 13)
        Me.Label23.TabIndex = 374
        Me.Label23.Text = "配送希望日："
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 222)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 13)
        Me.Label24.TabIndex = 375
        Me.Label24.Text = "配達希望時間："
        '
        'RQDATE_T
        '
        Me.RQDATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQDATE_T.Location = New System.Drawing.Point(95, 189)
        Me.RQDATE_T.Mask = "0000/00/00"
        Me.RQDATE_T.Name = "RQDATE_T"
        Me.RQDATE_T.Size = New System.Drawing.Size(122, 20)
        Me.RQDATE_T.TabIndex = 377
        Me.RQDATE_T.ValidatingType = GetType(Date)
        '
        'RQTIME_T
        '
        Me.RQTIME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RQTIME_T.Location = New System.Drawing.Point(95, 218)
        Me.RQTIME_T.Mask = "90:00"
        Me.RQTIME_T.Name = "RQTIME_T"
        Me.RQTIME_T.Size = New System.Drawing.Size(122, 20)
        Me.RQTIME_T.TabIndex = 378
        Me.RQTIME_T.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PAYMENT_C)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.RQTIME_T)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.RQDATE_T)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.SEND_POST_T)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.SEND_ADDRESS_T)
        Me.GroupBox1.Controls.Add(Me.COPY_B)
        Me.GroupBox1.Controls.Add(Me.SEND_COMPANY_T)
        Me.GroupBox1.Controls.Add(Me.SEND_TEL_T)
        Me.GroupBox1.Controls.Add(Me.SEND_NAME_T)
        Me.GroupBox1.Location = New System.Drawing.Point(439, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 260)
        Me.GroupBox1.TabIndex = 379
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【送付先情報】"
        '
        'PAYMENT_C
        '
        Me.PAYMENT_C.FormattingEnabled = True
        Me.PAYMENT_C.Location = New System.Drawing.Point(95, 164)
        Me.PAYMENT_C.Name = "PAYMENT_C"
        Me.PAYMENT_C.Size = New System.Drawing.Size(133, 20)
        Me.PAYMENT_C.TabIndex = 380
        '
        'ORDER_NUMBER_L
        '
        Me.ORDER_NUMBER_L.AutoSize = True
        Me.ORDER_NUMBER_L.Location = New System.Drawing.Point(764, 88)
        Me.ORDER_NUMBER_L.Name = "ORDER_NUMBER_L"
        Me.ORDER_NUMBER_L.Size = New System.Drawing.Size(59, 12)
        Me.ORDER_NUMBER_L.TabIndex = 380
        Me.ORDER_NUMBER_L.Text = "受注番号："
        '
        'ORDER_NUMBER_T
        '
        Me.ORDER_NUMBER_T.Location = New System.Drawing.Point(839, 85)
        Me.ORDER_NUMBER_T.Multiline = True
        Me.ORDER_NUMBER_T.Name = "ORDER_NUMBER_T"
        Me.ORDER_NUMBER_T.ReadOnly = True
        Me.ORDER_NUMBER_T.Size = New System.Drawing.Size(153, 21)
        Me.ORDER_NUMBER_T.TabIndex = 381
        '
        'READ_MENBER_CODE_L
        '
        Me.READ_MENBER_CODE_L.AutoSize = True
        Me.READ_MENBER_CODE_L.Location = New System.Drawing.Point(8, 26)
        Me.READ_MENBER_CODE_L.Name = "READ_MENBER_CODE_L"
        Me.READ_MENBER_CODE_L.Size = New System.Drawing.Size(62, 12)
        Me.READ_MENBER_CODE_L.TabIndex = 382
        Me.READ_MENBER_CODE_L.Text = "会員コード："
        '
        'READ_MENBER_CODE_T
        '
        Me.READ_MENBER_CODE_T.Location = New System.Drawing.Point(70, 22)
        Me.READ_MENBER_CODE_T.Multiline = True
        Me.READ_MENBER_CODE_T.Name = "READ_MENBER_CODE_T"
        Me.READ_MENBER_CODE_T.ReadOnly = True
        Me.READ_MENBER_CODE_T.Size = New System.Drawing.Size(156, 19)
        Me.READ_MENBER_CODE_T.TabIndex = 383
        '
        'MENBER_NAME_L
        '
        Me.MENBER_NAME_L.AutoSize = True
        Me.MENBER_NAME_L.Location = New System.Drawing.Point(8, 54)
        Me.MENBER_NAME_L.Name = "MENBER_NAME_L"
        Me.MENBER_NAME_L.Size = New System.Drawing.Size(59, 12)
        Me.MENBER_NAME_L.TabIndex = 384
        Me.MENBER_NAME_L.Text = "会員名称："
        '
        'MENBER_NAME_T
        '
        Me.MENBER_NAME_T.Location = New System.Drawing.Point(70, 50)
        Me.MENBER_NAME_T.Name = "MENBER_NAME_T"
        Me.MENBER_NAME_T.ReadOnly = True
        Me.MENBER_NAME_T.Size = New System.Drawing.Size(156, 19)
        Me.MENBER_NAME_T.TabIndex = 385
        '
        'MEMBER_INFORMATION＿G
        '
        Me.MEMBER_INFORMATION＿G.Controls.Add(Me.READ_MENBER_CODE_L)
        Me.MEMBER_INFORMATION＿G.Controls.Add(Me.MENBER_NAME_L)
        Me.MEMBER_INFORMATION＿G.Controls.Add(Me.MENBER_NAME_T)
        Me.MEMBER_INFORMATION＿G.Controls.Add(Me.READ_MENBER_CODE_T)
        Me.MEMBER_INFORMATION＿G.Location = New System.Drawing.Point(766, 112)
        Me.MEMBER_INFORMATION＿G.Name = "MEMBER_INFORMATION＿G"
        Me.MEMBER_INFORMATION＿G.Size = New System.Drawing.Size(245, 89)
        Me.MEMBER_INFORMATION＿G.TabIndex = 386
        Me.MEMBER_INFORMATION＿G.TabStop = False
        Me.MEMBER_INFORMATION＿G.Text = "会員情報"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(766, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(245, 46)
        Me.GroupBox2.TabIndex = 387
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【受取場所】"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(128, 18)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "宅配"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(13, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "店頭受取"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'NEW_REGISTRATION_L
        '
        Me.NEW_REGISTRATION_L.BackColor = System.Drawing.Color.Red
        Me.NEW_REGISTRATION_L.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NEW_REGISTRATION_L.ForeColor = System.Drawing.Color.White
        Me.NEW_REGISTRATION_L.Location = New System.Drawing.Point(14, 9)
        Me.NEW_REGISTRATION_L.Name = "NEW_REGISTRATION_L"
        Me.NEW_REGISTRATION_L.Size = New System.Drawing.Size(991, 49)
        Me.NEW_REGISTRATION_L.TabIndex = 388
        Me.NEW_REGISTRATION_L.Text = "受注情報-新規登録"
        Me.NEW_REGISTRATION_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.NEW_REGISTRATION_L.Visible = False
        '
        'UPDATE_L
        '
        Me.UPDATE_L.BackColor = System.Drawing.Color.Blue
        Me.UPDATE_L.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UPDATE_L.ForeColor = System.Drawing.Color.White
        Me.UPDATE_L.Location = New System.Drawing.Point(14, 9)
        Me.UPDATE_L.Name = "UPDATE_L"
        Me.UPDATE_L.Size = New System.Drawing.Size(991, 49)
        Me.UPDATE_L.TabIndex = 389
        Me.UPDATE_L.Text = "受注情報-更新"
        Me.UPDATE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UPDATE_L.Visible = False
        '
        'fCustomerOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1028, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.UPDATE_L)
        Me.Controls.Add(Me.NEW_REGISTRATION_L)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.MEMBER_INFORMATION＿G)
        Me.Controls.Add(Me.ORDER_NUMBER_T)
        Me.Controls.Add(Me.ORDER_NUMBER_L)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CNT_L)
        Me.Controls.Add(Me.JAN_CODE_L)
        Me.Controls.Add(Me.ORDERER_G)
        Me.Controls.Add(Me.TRAN_HISTORY_B)
        Me.Controls.Add(Me.POINT_MEMBER_B)
        Me.Controls.Add(Me.EXIT_B)
        Me.Controls.Add(Me.MEMBER_B)
        Me.Controls.Add(Me.PRODUCT_SEARCH_B)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.JAN_CODE_T)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.MSG_T)
        Me.Controls.Add(Me.MEISAI_V)
        Me.Controls.Add(Me.TRN_CODE_T)
        Me.Controls.Add(Me.CNT_T)
        Me.Controls.Add(Me.TRNSUB_CODE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pbImage)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCustomerOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MEISAI_V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ORDERER_G.ResumeLayout(False)
        Me.ORDERER_G.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MEMBER_INFORMATION＿G.ResumeLayout(False)
        Me.MEMBER_INFORMATION＿G.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MSG_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents TRN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents TRNSUB_CODE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents MEISAI_V As System.Windows.Forms.DataGridView
    Friend WithEvents PRICE_T As System.Windows.Forms.TextBox
    Friend WithEvents ADVANCE_RECEIVED_L As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents FEE_L As System.Windows.Forms.Label
    Friend WithEvents DELIVERY_CHARGE_L As System.Windows.Forms.Label
    Friend WithEvents DISCOUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents OTHER_DISCOUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents PRICE_L As System.Windows.Forms.Label
    Friend WithEvents DISCOUNT_L As System.Windows.Forms.Label
    Friend WithEvents OTHER_DISCOUNT_L As System.Windows.Forms.Label
    Friend WithEvents TAX_L As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TFEE_T As System.Windows.Forms.TextBox
    Friend WithEvents POSTAGE_T As System.Windows.Forms.TextBox
    Friend WithEvents ADVANCE_RECEIVED_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_T As System.Windows.Forms.TextBox
    Friend WithEvents JAN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BILLING_AMOUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents BILLING_AMOUNT_L As System.Windows.Forms.Label
    Friend WithEvents REMAINING_MONEY_T As System.Windows.Forms.TextBox
    Friend WithEvents REMAINING_MONEY_L As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_B As Softgroup.NetButton.NetButton
    Friend WithEvents EXIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents POINT_MEMBER_B As Softgroup.NetButton.NetButton
    Friend WithEvents TRAN_HISTORY_B As Softgroup.NetButton.NetButton
    Friend WithEvents MENBERS_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents POSTAL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MENBERS_CODE_L As System.Windows.Forms.Label
    Friend WithEvents POSTAL_CODE_L As System.Windows.Forms.Label
    Friend WithEvents ADDRESS_L As System.Windows.Forms.Label
    Friend WithEvents COMPANY_NAME_L As System.Windows.Forms.Label
    Friend WithEvents FULL_NAME_L As System.Windows.Forms.Label
    Friend WithEvents PHONE_NUMBER_L As System.Windows.Forms.Label
    Friend WithEvents ADDRESS_T As System.Windows.Forms.TextBox
    Friend WithEvents COMPANY_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents FULL_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents PHONE_NUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents ORDERER_G As System.Windows.Forms.GroupBox
    Friend WithEvents CUSTOMER_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents JAN_CODE_L As System.Windows.Forms.Label
    Friend WithEvents CNT_L As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SEND_POST_T As System.Windows.Forms.TextBox
    Friend WithEvents SEND_ADDRESS_T As System.Windows.Forms.TextBox
    Friend WithEvents SEND_COMPANY_T As System.Windows.Forms.TextBox
    Friend WithEvents SEND_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SEND_TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents COPY_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents RQDATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RQTIME_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PAYMENT_C As System.Windows.Forms.ComboBox
    Friend WithEvents ORDER_NUMBER_L As System.Windows.Forms.Label
    Friend WithEvents ORDER_NUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents READ_MENBER_CODE_L As System.Windows.Forms.Label
    Friend WithEvents READ_MENBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MENBER_NAME_L As System.Windows.Forms.Label
    Friend WithEvents MENBER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents MEMBER_INFORMATION＿G As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents NEW_REGISTRATION_L As System.Windows.Forms.Label
    Friend WithEvents UPDATE_L As System.Windows.Forms.Label
    '    Friend WithEvents OPOSDRW1 As AxOPOSDRWLib.AxOPOSDRW
End Class
