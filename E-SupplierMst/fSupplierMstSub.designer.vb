<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSupplierMstSub
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
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ADDRESS3_T = New System.Windows.Forms.TextBox()
        Me.ADDRESS2_T = New System.Windows.Forms.TextBox()
        Me.ADDRESS1_C = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ADDDR_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SUPPLIER_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.MEMO_T = New System.Windows.Forms.RichTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.RULE_T = New System.Windows.Forms.RichTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PAYMENT_CODE_3_T = New System.Windows.Forms.TextBox()
        Me.PAYMENT_NAME_3_L = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PAYMENT_CODE_2_T = New System.Windows.Forms.TextBox()
        Me.PAYMENT_NAME_2_L = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PAYMENT_CODE_1_T = New System.Windows.Forms.TextBox()
        Me.PAYMENT_NAME_1_L = New System.Windows.Forms.ComboBox()
        Me.MIN_LOT_T = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RATE_T = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CLOSE_DAY_T = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TANTOU_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.URL_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FAX_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.POST_CODE_T = New System.Windows.Forms.TextBox()
        Me.SUPPLIER_CODE_T = New System.Windows.Forms.TextBox()
        Me.TEL_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(12, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(881, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "新規"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.ADDRESS3_T)
        Me.GroupBox1.Controls.Add(Me.ADDRESS2_T)
        Me.GroupBox1.Controls.Add(Me.ADDRESS1_C)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.ADDDR_SEARCH_B)
        Me.GroupBox1.Controls.Add(Me.SUPPLIER_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.MEMO_T)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.RULE_T)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_CODE_3_T)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_NAME_3_L)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_CODE_2_T)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_NAME_2_L)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_CODE_1_T)
        Me.GroupBox1.Controls.Add(Me.PAYMENT_NAME_1_L)
        Me.GroupBox1.Controls.Add(Me.MIN_LOT_T)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.RATE_T)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CLOSE_DAY_T)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TANTOU_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.URL_T)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.FAX_T)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.POST_CODE_T)
        Me.GroupBox1.Controls.Add(Me.SUPPLIER_CODE_T)
        Me.GroupBox1.Controls.Add(Me.TEL_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(881, 399)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(20, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(90, 20)
        Me.Label23.TabIndex = 181
        Me.Label23.Text = "以下"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ADDRESS3_T
        '
        Me.ADDRESS3_T.BackColor = System.Drawing.Color.White
        Me.ADDRESS3_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS3_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDRESS3_T.Location = New System.Drawing.Point(116, 147)
        Me.ADDRESS3_T.Name = "ADDRESS3_T"
        Me.ADDRESS3_T.Size = New System.Drawing.Size(317, 20)
        Me.ADDRESS3_T.TabIndex = 180
        '
        'ADDRESS2_T
        '
        Me.ADDRESS2_T.BackColor = System.Drawing.Color.White
        Me.ADDRESS2_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS2_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ADDRESS2_T.Location = New System.Drawing.Point(116, 121)
        Me.ADDRESS2_T.Name = "ADDRESS2_T"
        Me.ADDRESS2_T.Size = New System.Drawing.Size(317, 20)
        Me.ADDRESS2_T.TabIndex = 179
        '
        'ADDRESS1_C
        '
        Me.ADDRESS1_C.BackColor = System.Drawing.Color.White
        Me.ADDRESS1_C.FormattingEnabled = True
        Me.ADDRESS1_C.Location = New System.Drawing.Point(116, 95)
        Me.ADDRESS1_C.Name = "ADDRESS1_C"
        Me.ADDRESS1_C.Size = New System.Drawing.Size(121, 20)
        Me.ADDRESS1_C.TabIndex = 178
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Tan
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(616, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(119, 12)
        Me.Label22.TabIndex = 177
        Me.Label22.Text = "(半角数字-60%なら 60)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Tan
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(724, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(147, 12)
        Me.Label21.TabIndex = 176
        Me.Label21.Text = "(半角数字-20日締めなら 20)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Tan
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(269, 202)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(145, 12)
        Me.Label20.TabIndex = 175
        Me.Label20.Text = "(半角数字-000-0000-0000)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Tan
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(269, 176)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(145, 12)
        Me.Label19.TabIndex = 174
        Me.Label19.Text = "(半角数字-000-0000-0000)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Tan
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(305, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(164, 12)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "(ハイフンなし半角数字-1234567)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ADDDR_SEARCH_B
        '
        Me.ADDDR_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ADDDR_SEARCH_B.Location = New System.Drawing.Point(199, 64)
        Me.ADDDR_SEARCH_B.Name = "ADDDR_SEARCH_B"
        Me.ADDDR_SEARCH_B.Size = New System.Drawing.Size(100, 30)
        Me.ADDDR_SEARCH_B.TabIndex = 4
        Me.ADDDR_SEARCH_B.TextButton = "住所検索"
        '
        'SUPPLIER_NAME_T
        '
        Me.SUPPLIER_NAME_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SUPPLIER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SUPPLIER_NAME_T.Location = New System.Drawing.Point(118, 41)
        Me.SUPPLIER_NAME_T.MaxLength = 50
        Me.SUPPLIER_NAME_T.Name = "SUPPLIER_NAME_T"
        Me.SUPPLIER_NAME_T.Size = New System.Drawing.Size(379, 20)
        Me.SUPPLIER_NAME_T.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(20, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 20)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "仕入先名称"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(19, 278)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 20)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "備考"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MEMO_T
        '
        Me.MEMO_T.Location = New System.Drawing.Point(18, 301)
        Me.MEMO_T.Name = "MEMO_T"
        Me.MEMO_T.Size = New System.Drawing.Size(480, 83)
        Me.MEMO_T.TabIndex = 11
        Me.MEMO_T.Text = ""
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(520, 178)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 20)
        Me.Label15.TabIndex = 169
        Me.Label15.Text = "取引条件"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RULE_T
        '
        Me.RULE_T.Location = New System.Drawing.Point(525, 201)
        Me.RULE_T.Name = "RULE_T"
        Me.RULE_T.Size = New System.Drawing.Size(333, 183)
        Me.RULE_T.TabIndex = 18
        Me.RULE_T.Text = ""
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(520, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 20)
        Me.Label14.TabIndex = 167
        Me.Label14.Text = "支払方法３"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PAYMENT_CODE_3_T
        '
        Me.PAYMENT_CODE_3_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_CODE_3_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PAYMENT_CODE_3_T.Location = New System.Drawing.Point(770, 145)
        Me.PAYMENT_CODE_3_T.Name = "PAYMENT_CODE_3_T"
        Me.PAYMENT_CODE_3_T.ReadOnly = True
        Me.PAYMENT_CODE_3_T.Size = New System.Drawing.Size(33, 22)
        Me.PAYMENT_CODE_3_T.TabIndex = 166
        Me.PAYMENT_CODE_3_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.PAYMENT_CODE_3_T.Visible = False
        '
        'PAYMENT_NAME_3_L
        '
        Me.PAYMENT_NAME_3_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_NAME_3_L.FormattingEnabled = True
        Me.PAYMENT_NAME_3_L.Location = New System.Drawing.Point(617, 145)
        Me.PAYMENT_NAME_3_L.Name = "PAYMENT_NAME_3_L"
        Me.PAYMENT_NAME_3_L.Size = New System.Drawing.Size(205, 23)
        Me.PAYMENT_NAME_3_L.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(520, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 20)
        Me.Label13.TabIndex = 164
        Me.Label13.Text = "支払方法２"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PAYMENT_CODE_2_T
        '
        Me.PAYMENT_CODE_2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_CODE_2_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PAYMENT_CODE_2_T.Location = New System.Drawing.Point(770, 117)
        Me.PAYMENT_CODE_2_T.Name = "PAYMENT_CODE_2_T"
        Me.PAYMENT_CODE_2_T.ReadOnly = True
        Me.PAYMENT_CODE_2_T.Size = New System.Drawing.Size(33, 22)
        Me.PAYMENT_CODE_2_T.TabIndex = 163
        Me.PAYMENT_CODE_2_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.PAYMENT_CODE_2_T.Visible = False
        '
        'PAYMENT_NAME_2_L
        '
        Me.PAYMENT_NAME_2_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_NAME_2_L.FormattingEnabled = True
        Me.PAYMENT_NAME_2_L.Location = New System.Drawing.Point(617, 117)
        Me.PAYMENT_NAME_2_L.Name = "PAYMENT_NAME_2_L"
        Me.PAYMENT_NAME_2_L.Size = New System.Drawing.Size(205, 23)
        Me.PAYMENT_NAME_2_L.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(520, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 20)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "支払方法１"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PAYMENT_CODE_1_T
        '
        Me.PAYMENT_CODE_1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_CODE_1_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PAYMENT_CODE_1_T.Location = New System.Drawing.Point(770, 89)
        Me.PAYMENT_CODE_1_T.Name = "PAYMENT_CODE_1_T"
        Me.PAYMENT_CODE_1_T.ReadOnly = True
        Me.PAYMENT_CODE_1_T.Size = New System.Drawing.Size(33, 22)
        Me.PAYMENT_CODE_1_T.TabIndex = 160
        Me.PAYMENT_CODE_1_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.PAYMENT_CODE_1_T.Visible = False
        '
        'PAYMENT_NAME_1_L
        '
        Me.PAYMENT_NAME_1_L.BackColor = System.Drawing.Color.LemonChiffon
        Me.PAYMENT_NAME_1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PAYMENT_NAME_1_L.FormattingEnabled = True
        Me.PAYMENT_NAME_1_L.Location = New System.Drawing.Point(617, 89)
        Me.PAYMENT_NAME_1_L.Name = "PAYMENT_NAME_1_L"
        Me.PAYMENT_NAME_1_L.Size = New System.Drawing.Size(205, 23)
        Me.PAYMENT_NAME_1_L.TabIndex = 15
        '
        'MIN_LOT_T
        '
        Me.MIN_LOT_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.MIN_LOT_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MIN_LOT_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MIN_LOT_T.Location = New System.Drawing.Point(811, 48)
        Me.MIN_LOT_T.Name = "MIN_LOT_T"
        Me.MIN_LOT_T.Size = New System.Drawing.Size(52, 20)
        Me.MIN_LOT_T.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(713, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 20)
        Me.Label11.TabIndex = 158
        Me.Label11.Text = "標準ロット数"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RATE_T
        '
        Me.RATE_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.RATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RATE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.RATE_T.Location = New System.Drawing.Point(618, 48)
        Me.RATE_T.Name = "RATE_T"
        Me.RATE_T.Size = New System.Drawing.Size(52, 20)
        Me.RATE_T.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(520, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 20)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "標準仕切率"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLOSE_DAY_T
        '
        Me.CLOSE_DAY_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.CLOSE_DAY_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLOSE_DAY_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CLOSE_DAY_T.Location = New System.Drawing.Point(618, 21)
        Me.CLOSE_DAY_T.Name = "CLOSE_DAY_T"
        Me.CLOSE_DAY_T.Size = New System.Drawing.Size(100, 20)
        Me.CLOSE_DAY_T.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(520, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 20)
        Me.Label9.TabIndex = 154
        Me.Label9.Text = "締め日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TANTOU_NAME_T
        '
        Me.TANTOU_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TANTOU_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TANTOU_NAME_T.Location = New System.Drawing.Point(117, 250)
        Me.TANTOU_NAME_T.Name = "TANTOU_NAME_T"
        Me.TANTOU_NAME_T.Size = New System.Drawing.Size(146, 20)
        Me.TANTOU_NAME_T.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(19, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 152
        Me.Label8.Text = "担当者名称"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'URL_T
        '
        Me.URL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.URL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.URL_T.Location = New System.Drawing.Point(117, 224)
        Me.URL_T.Name = "URL_T"
        Me.URL_T.Size = New System.Drawing.Size(381, 20)
        Me.URL_T.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(19, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "URL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FAX_T
        '
        Me.FAX_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FAX_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.FAX_T.Location = New System.Drawing.Point(117, 198)
        Me.FAX_T.Name = "FAX_T"
        Me.FAX_T.Size = New System.Drawing.Size(146, 20)
        Me.FAX_T.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(19, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 20)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "FAX"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'POST_CODE_T
        '
        Me.POST_CODE_T.BackColor = System.Drawing.Color.White
        Me.POST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.POST_CODE_T.Location = New System.Drawing.Point(118, 69)
        Me.POST_CODE_T.Name = "POST_CODE_T"
        Me.POST_CODE_T.Size = New System.Drawing.Size(75, 20)
        Me.POST_CODE_T.TabIndex = 3
        Me.POST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.SUPPLIER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(118, 14)
        Me.SUPPLIER_CODE_T.MaxLength = 13
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.SUPPLIER_CODE_T.TabIndex = 1
        Me.SUPPLIER_CODE_T.TabStop = False
        '
        'TEL_T
        '
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TEL_T.Location = New System.Drawing.Point(117, 172)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.Size = New System.Drawing.Size(146, 20)
        Me.TEL_T.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(19, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "TEL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "市区町村"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "郵便番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "都道府県"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(20, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 20)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "仕入先コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DELETE_B.Location = New System.Drawing.Point(587, 437)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(98, 41)
        Me.DELETE_B.TabIndex = 2
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(691, 437)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 41)
        Me.COMMIT_B.TabIndex = 3
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(795, 437)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 41)
        Me.RETURN_B.TabIndex = 4
        Me.RETURN_B.TextButton = "戻　る"
        '
        'fSupplierMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(905, 490)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fSupplierMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部門マスタ管理"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents MEMO_T As System.Windows.Forms.RichTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RULE_T As System.Windows.Forms.RichTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PAYMENT_CODE_3_T As System.Windows.Forms.TextBox
    Friend WithEvents PAYMENT_NAME_3_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PAYMENT_CODE_2_T As System.Windows.Forms.TextBox
    Friend WithEvents PAYMENT_NAME_2_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PAYMENT_CODE_1_T As System.Windows.Forms.TextBox
    Friend WithEvents PAYMENT_NAME_1_L As System.Windows.Forms.ComboBox
    Friend WithEvents MIN_LOT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents RATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CLOSE_DAY_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TANTOU_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents URL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FAX_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents POST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents SUPPLIER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SUPPLIER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ADDDR_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ADDRESS3_T As System.Windows.Forms.TextBox
    Friend WithEvents ADDRESS2_T As System.Windows.Forms.TextBox
    Friend WithEvents ADDRESS1_C As System.Windows.Forms.ComboBox

End Class
