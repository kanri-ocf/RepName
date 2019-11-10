<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fInvCheck
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
        Me.SYUBETU_2_R = New System.Windows.Forms.RadioButton
        Me.SYUBETU_1_R = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.MIN_STOCK_T = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PRICE_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.OPTION3_T = New System.Windows.Forms.TextBox
        Me.OPTION2_T = New System.Windows.Forms.TextBox
        Me.PRODUCT_S_NAME_T = New System.Windows.Forms.TextBox
        Me.JANCODE_T = New System.Windows.Forms.TextBox
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.OPTION3_L = New System.Windows.Forms.Label
        Me.OPTION2_L = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PLU_CODE_T = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.STOPSALE_C = New System.Windows.Forms.CheckBox
        Me.MEMO_T = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.OPTION5_T = New System.Windows.Forms.TextBox
        Me.OPTION4_T = New System.Windows.Forms.TextBox
        Me.OPTION5_L = New System.Windows.Forms.Label
        Me.OPTION4_L = New System.Windows.Forms.Label
        Me.OPTION1_T = New System.Windows.Forms.TextBox
        Me.OPTION1_L = New System.Windows.Forms.Label
        Me.MAKER_NAME_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CNT_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.JAN_CODE_T = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.SUPPLIESTOP_C = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.STOCK_CNT_T = New System.Windows.Forms.TextBox
        Me.SEQ_CODE_T = New System.Windows.Forms.TextBox
        Me.YEAR_T = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.MONTH_T = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.DAY_T = New System.Windows.Forms.TextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SYUBETU_2_R
        '
        Me.SYUBETU_2_R.AutoSize = True
        Me.SYUBETU_2_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_2_R.Location = New System.Drawing.Point(72, 11)
        Me.SYUBETU_2_R.Name = "SYUBETU_2_R"
        Me.SYUBETU_2_R.Size = New System.Drawing.Size(79, 17)
        Me.SYUBETU_2_R.TabIndex = 2
        Me.SYUBETU_2_R.TabStop = True
        Me.SYUBETU_2_R.Text = "サービス品"
        Me.SYUBETU_2_R.UseVisualStyleBackColor = True
        '
        'SYUBETU_1_R
        '
        Me.SYUBETU_1_R.AutoSize = True
        Me.SYUBETU_1_R.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYUBETU_1_R.Location = New System.Drawing.Point(7, 11)
        Me.SYUBETU_1_R.Name = "SYUBETU_1_R"
        Me.SYUBETU_1_R.Size = New System.Drawing.Size(64, 17)
        Me.SYUBETU_1_R.TabIndex = 1
        Me.SYUBETU_1_R.TabStop = True
        Me.SYUBETU_1_R.Text = "在庫品"
        Me.SYUBETU_1_R.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SYUBETU_2_R)
        Me.GroupBox1.Controls.Add(Me.SYUBETU_1_R)
        Me.GroupBox1.Location = New System.Drawing.Point(550, 258)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 32)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(487, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "商品種別："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MIN_STOCK_T
        '
        Me.MIN_STOCK_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MIN_STOCK_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MIN_STOCK_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MIN_STOCK_T.Location = New System.Drawing.Point(550, 238)
        Me.MIN_STOCK_T.Name = "MIN_STOCK_T"
        Me.MIN_STOCK_T.Size = New System.Drawing.Size(115, 20)
        Me.MIN_STOCK_T.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(474, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "適正在庫数："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRICE_T
        '
        Me.PRICE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRICE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRICE_T.Location = New System.Drawing.Point(550, 212)
        Me.PRICE_T.Name = "PRICE_T"
        Me.PRICE_T.Size = New System.Drawing.Size(115, 20)
        Me.PRICE_T.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(513, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "定価："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION3_T
        '
        Me.OPTION3_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION3_T.Location = New System.Drawing.Point(103, 238)
        Me.OPTION3_T.Name = "OPTION3_T"
        Me.OPTION3_T.Size = New System.Drawing.Size(181, 20)
        Me.OPTION3_T.TabIndex = 9
        '
        'OPTION2_T
        '
        Me.OPTION2_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION2_T.Location = New System.Drawing.Point(103, 218)
        Me.OPTION2_T.Name = "OPTION2_T"
        Me.OPTION2_T.Size = New System.Drawing.Size(181, 20)
        Me.OPTION2_T.TabIndex = 8
        '
        'PRODUCT_S_NAME_T
        '
        Me.PRODUCT_S_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PRODUCT_S_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_S_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_S_NAME_T.Location = New System.Drawing.Point(103, 177)
        Me.PRODUCT_S_NAME_T.Name = "PRODUCT_S_NAME_T"
        Me.PRODUCT_S_NAME_T.Size = New System.Drawing.Size(309, 20)
        Me.PRODUCT_S_NAME_T.TabIndex = 6
        '
        'JANCODE_T
        '
        Me.JANCODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(30, 32)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(321, 34)
        Me.JANCODE_T.TabIndex = 1
        Me.JANCODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(103, 155)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(331, 20)
        Me.PRODUCT_NAME_T.TabIndex = 5
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(103, 113)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 3
        Me.PRODUCT_CODE_T.TabStop = False
        '
        'OPTION3_L
        '
        Me.OPTION3_L.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPTION3_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION3_L.Location = New System.Drawing.Point(19, 241)
        Me.OPTION3_L.Name = "OPTION3_L"
        Me.OPTION3_L.Size = New System.Drawing.Size(84, 12)
        Me.OPTION3_L.TabIndex = 83
        Me.OPTION3_L.Text = "Option3："
        Me.OPTION3_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION2_L
        '
        Me.OPTION2_L.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPTION2_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION2_L.Location = New System.Drawing.Point(17, 221)
        Me.OPTION2_L.Name = "OPTION2_L"
        Me.OPTION2_L.Size = New System.Drawing.Size(86, 12)
        Me.OPTION2_L.TabIndex = 81
        Me.OPTION2_L.Text = "Option2："
        Me.OPTION2_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "商品略称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "【JANコード】"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(-204, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "商品番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PLU_CODE_T
        '
        Me.PLU_CODE_T.BackColor = System.Drawing.Color.White
        Me.PLU_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PLU_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PLU_CODE_T.Location = New System.Drawing.Point(103, 323)
        Me.PLU_CODE_T.Name = "PLU_CODE_T"
        Me.PLU_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.PLU_CODE_T.TabIndex = 13
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.Location = New System.Drawing.Point(37, 326)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(66, 13)
        Me.Label42.TabIndex = 137
        Me.Label42.Text = "PLUコード："
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STOPSALE_C
        '
        Me.STOPSALE_C.AutoSize = True
        Me.STOPSALE_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STOPSALE_C.Location = New System.Drawing.Point(550, 298)
        Me.STOPSALE_C.Name = "STOPSALE_C"
        Me.STOPSALE_C.Size = New System.Drawing.Size(106, 17)
        Me.STOPSALE_C.TabIndex = 19
        Me.STOPSALE_C.Text = "販売停止フラグ"
        Me.STOPSALE_C.UseVisualStyleBackColor = True
        '
        'MEMO_T
        '
        Me.MEMO_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMO_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMO_T.Location = New System.Drawing.Point(103, 300)
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Size = New System.Drawing.Size(331, 20)
        Me.MEMO_T.TabIndex = 12
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.Location = New System.Drawing.Point(64, 304)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(40, 13)
        Me.Label43.TabIndex = 143
        Me.Label43.Text = "適用："
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION5_T
        '
        Me.OPTION5_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION5_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION5_T.Location = New System.Drawing.Point(103, 277)
        Me.OPTION5_T.Name = "OPTION5_T"
        Me.OPTION5_T.Size = New System.Drawing.Size(181, 20)
        Me.OPTION5_T.TabIndex = 11
        '
        'OPTION4_T
        '
        Me.OPTION4_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION4_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION4_T.Location = New System.Drawing.Point(103, 257)
        Me.OPTION4_T.Name = "OPTION4_T"
        Me.OPTION4_T.Size = New System.Drawing.Size(181, 20)
        Me.OPTION4_T.TabIndex = 10
        '
        'OPTION5_L
        '
        Me.OPTION5_L.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPTION5_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION5_L.Location = New System.Drawing.Point(19, 280)
        Me.OPTION5_L.Name = "OPTION5_L"
        Me.OPTION5_L.Size = New System.Drawing.Size(84, 12)
        Me.OPTION5_L.TabIndex = 147
        Me.OPTION5_L.Text = "Option5："
        Me.OPTION5_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION4_L
        '
        Me.OPTION4_L.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPTION4_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION4_L.Location = New System.Drawing.Point(17, 261)
        Me.OPTION4_L.Name = "OPTION4_L"
        Me.OPTION4_L.Size = New System.Drawing.Size(86, 12)
        Me.OPTION4_L.TabIndex = 146
        Me.OPTION4_L.Text = "Option4："
        Me.OPTION4_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION1_T
        '
        Me.OPTION1_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION1_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION1_T.Location = New System.Drawing.Point(103, 198)
        Me.OPTION1_T.Name = "OPTION1_T"
        Me.OPTION1_T.Size = New System.Drawing.Size(181, 20)
        Me.OPTION1_T.TabIndex = 7
        '
        'OPTION1_L
        '
        Me.OPTION1_L.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPTION1_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION1_L.Location = New System.Drawing.Point(17, 201)
        Me.OPTION1_L.Name = "OPTION1_L"
        Me.OPTION1_L.Size = New System.Drawing.Size(86, 12)
        Me.OPTION1_L.TabIndex = 149
        Me.OPTION1_L.Text = "Option1："
        Me.OPTION1_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MAKER_NAME_T
        '
        Me.MAKER_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MAKER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MAKER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MAKER_NAME_T.Location = New System.Drawing.Point(550, 187)
        Me.MAKER_NAME_T.Name = "MAKER_NAME_T"
        Me.MAKER_NAME_T.Size = New System.Drawing.Size(149, 20)
        Me.MAKER_NAME_T.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(472, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "メーカー名："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CNT_T
        '
        Me.CNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CNT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CNT_T.Location = New System.Drawing.Point(359, 31)
        Me.CNT_T.Name = "CNT_T"
        Me.CNT_T.Size = New System.Drawing.Size(90, 34)
        Me.CNT_T.TabIndex = 2
        Me.CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "【加算数量】"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.JANCODE_T)
        Me.GroupBox2.Controls.Add(Me.CNT_T)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(476, 85)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(38, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 166
        Me.Label17.Text = "商品番号："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'JAN_CODE_T
        '
        Me.JAN_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.JAN_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JAN_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JAN_CODE_T.Location = New System.Drawing.Point(103, 134)
        Me.JAN_CODE_T.Name = "JAN_CODE_T"
        Me.JAN_CODE_T.Size = New System.Drawing.Size(176, 20)
        Me.JAN_CODE_T.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(25, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 168
        Me.Label18.Text = "JANコード："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SUPPLIESTOP_C
        '
        Me.SUPPLIESTOP_C.AutoSize = True
        Me.SUPPLIESTOP_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIESTOP_C.Location = New System.Drawing.Point(550, 318)
        Me.SUPPLIESTOP_C.Name = "SUPPLIESTOP_C"
        Me.SUPPLIESTOP_C.Size = New System.Drawing.Size(106, 17)
        Me.SUPPLIESTOP_C.TabIndex = 20
        Me.SUPPLIESTOP_C.Text = "仕入停止フラグ"
        Me.SUPPLIESTOP_C.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(467, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 16)
        Me.Label12.TabIndex = 172
        Me.Label12.Text = "帳簿在庫数："
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STOCK_CNT_T
        '
        Me.STOCK_CNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.STOCK_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STOCK_CNT_T.Location = New System.Drawing.Point(550, 153)
        Me.STOCK_CNT_T.Name = "STOCK_CNT_T"
        Me.STOCK_CNT_T.ReadOnly = True
        Me.STOCK_CNT_T.Size = New System.Drawing.Size(87, 23)
        Me.STOCK_CNT_T.TabIndex = 173
        Me.STOCK_CNT_T.TabStop = False
        '
        'SEQ_CODE_T
        '
        Me.SEQ_CODE_T.BackColor = System.Drawing.Color.LightGray
        Me.SEQ_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEQ_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SEQ_CODE_T.Location = New System.Drawing.Point(208, 112)
        Me.SEQ_CODE_T.Name = "SEQ_CODE_T"
        Me.SEQ_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.SEQ_CODE_T.TabIndex = 174
        Me.SEQ_CODE_T.Visible = False
        '
        'YEAR_T
        '
        Me.YEAR_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.YEAR_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.YEAR_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.YEAR_T.Location = New System.Drawing.Point(525, 37)
        Me.YEAR_T.Name = "YEAR_T"
        Me.YEAR_T.Size = New System.Drawing.Size(64, 22)
        Me.YEAR_T.TabIndex = 1
        Me.YEAR_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(526, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 178
        Me.Label14.Text = "【棚卸日】"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(590, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 20)
        Me.Label15.TabIndex = 179
        Me.Label15.Text = "年"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(646, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 20)
        Me.Label16.TabIndex = 181
        Me.Label16.Text = "月"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MONTH_T
        '
        Me.MONTH_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MONTH_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MONTH_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MONTH_T.Location = New System.Drawing.Point(610, 37)
        Me.MONTH_T.Name = "MONTH_T"
        Me.MONTH_T.Size = New System.Drawing.Size(32, 22)
        Me.MONTH_T.TabIndex = 2
        Me.MONTH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(707, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 20)
        Me.Label19.TabIndex = 183
        Me.Label19.Text = "日"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DAY_T
        '
        Me.DAY_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DAY_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DAY_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DAY_T.Location = New System.Drawing.Point(671, 38)
        Me.DAY_T.Name = "DAY_T"
        Me.DAY_T.Size = New System.Drawing.Size(32, 22)
        Me.DAY_T.TabIndex = 3
        Me.DAY_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(523, 63)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(210, 39)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "検　索"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(486, 360)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(119, 53)
        Me.COMMIT_B.TabIndex = 20
        Me.COMMIT_B.TextButton = "登　録"
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.QUIT_B.Location = New System.Drawing.Point(614, 360)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(119, 53)
        Me.QUIT_B.TabIndex = 21
        Me.QUIT_B.TextButton = "終　了"
        '
        'fInvCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(772, 439)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DAY_T)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.MONTH_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.YEAR_T)
        Me.Controls.Add(Me.SEQ_CODE_T)
        Me.Controls.Add(Me.STOCK_CNT_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SUPPLIESTOP_C)
        Me.Controls.Add(Me.JAN_CODE_T)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.MAKER_NAME_T)
        Me.Controls.Add(Me.OPTION1_T)
        Me.Controls.Add(Me.OPTION1_L)
        Me.Controls.Add(Me.OPTION5_T)
        Me.Controls.Add(Me.OPTION4_T)
        Me.Controls.Add(Me.OPTION5_L)
        Me.Controls.Add(Me.OPTION4_L)
        Me.Controls.Add(Me.MEMO_T)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.MIN_STOCK_T)
        Me.Controls.Add(Me.PLU_CODE_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.PRICE_T)
        Me.Controls.Add(Me.OPTION3_T)
        Me.Controls.Add(Me.OPTION2_T)
        Me.Controls.Add(Me.PRODUCT_S_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.STOPSALE_C)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.OPTION3_L)
        Me.Controls.Add(Me.OPTION2_L)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fInvCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "棚卸画面"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SYUBETU_2_R As System.Windows.Forms.RadioButton
    Friend WithEvents SYUBETU_1_R As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents MIN_STOCK_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PRICE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OPTION3_T As System.Windows.Forms.TextBox
    Friend WithEvents OPTION2_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_S_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents OPTION3_L As System.Windows.Forms.Label
    Friend WithEvents OPTION2_L As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PLU_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents STOPSALE_C As System.Windows.Forms.CheckBox
    Friend WithEvents MEMO_T As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents OPTION5_T As System.Windows.Forms.TextBox
    Friend WithEvents OPTION4_T As System.Windows.Forms.TextBox
    Friend WithEvents OPTION5_L As System.Windows.Forms.Label
    Friend WithEvents OPTION4_L As System.Windows.Forms.Label
    Friend WithEvents OPTION1_T As System.Windows.Forms.TextBox
    Friend WithEvents OPTION1_L As System.Windows.Forms.Label
    Friend WithEvents MAKER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents JAN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SUPPLIESTOP_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents STOCK_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents SEQ_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents YEAR_T As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents MONTH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DAY_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton

End Class
