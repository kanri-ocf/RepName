<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fOrderCancel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OTHER_R = New System.Windows.Forms.RadioButton
        Me.NOUKI_R = New System.Windows.Forms.RadioButton
        Me.MISSTAKE_R = New System.Windows.Forms.RadioButton
        Me.HAIBAN_R = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.REASON_T = New System.Windows.Forms.TextBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape7 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.RectangleShape9 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape8 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape7 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape6 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.ORDER_CODE_L = New System.Windows.Forms.Label
        Me.ORDER_SUB_CODE_L = New System.Windows.Forms.Label
        Me.COSTPRICE_L = New System.Windows.Forms.Label
        Me.CNT_L = New System.Windows.Forms.Label
        Me.TOTAL_PRICE_L = New System.Windows.Forms.Label
        Me.PRODUCT_CODE_L = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_L = New System.Windows.Forms.Label
        Me.OPTION1_L = New System.Windows.Forms.Label
        Me.OPTION2_L = New System.Windows.Forms.Label
        Me.OPTION3_L = New System.Windows.Forms.Label
        Me.OPTION4_L = New System.Windows.Forms.Label
        Me.OPTION5_L = New System.Windows.Forms.Label
        Me.PRICE_L = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.PRODUCT_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ARRIVE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_NG_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(31, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "注文コード"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(295, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "注文明細コード"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(31, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "商品コード"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(31, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "商品名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(31, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "オプション1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(31, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "オプション2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(31, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "オプション3"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(31, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "オプション4"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(31, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 23)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "オプション5"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(31, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 23)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "仕入価格"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(464, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 23)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "発注金額"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(259, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 23)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "発注数量"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.OTHER_R)
        Me.GroupBox1.Controls.Add(Me.NOUKI_R)
        Me.GroupBox1.Controls.Add(Me.MISSTAKE_R)
        Me.GroupBox1.Controls.Add(Me.HAIBAN_R)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.REASON_T)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(24, 285)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'OTHER_R
        '
        Me.OTHER_R.AutoSize = True
        Me.OTHER_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OTHER_R.Location = New System.Drawing.Point(400, 16)
        Me.OTHER_R.Name = "OTHER_R"
        Me.OTHER_R.Size = New System.Drawing.Size(63, 19)
        Me.OTHER_R.TabIndex = 4
        Me.OTHER_R.Text = "その他"
        Me.OTHER_R.UseVisualStyleBackColor = True
        '
        'NOUKI_R
        '
        Me.NOUKI_R.AutoSize = True
        Me.NOUKI_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOUKI_R.Location = New System.Drawing.Point(298, 16)
        Me.NOUKI_R.Name = "NOUKI_R"
        Me.NOUKI_R.Size = New System.Drawing.Size(85, 19)
        Me.NOUKI_R.TabIndex = 3
        Me.NOUKI_R.Text = "納期遅延"
        Me.NOUKI_R.UseVisualStyleBackColor = True
        '
        'MISSTAKE_R
        '
        Me.MISSTAKE_R.AutoSize = True
        Me.MISSTAKE_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MISSTAKE_R.Location = New System.Drawing.Point(206, 16)
        Me.MISSTAKE_R.Name = "MISSTAKE_R"
        Me.MISSTAKE_R.Size = New System.Drawing.Size(70, 19)
        Me.MISSTAKE_R.TabIndex = 2
        Me.MISSTAKE_R.Text = "誤発注"
        Me.MISSTAKE_R.UseVisualStyleBackColor = True
        '
        'HAIBAN_R
        '
        Me.HAIBAN_R.AutoSize = True
        Me.HAIBAN_R.Checked = True
        Me.HAIBAN_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HAIBAN_R.Location = New System.Drawing.Point(134, 16)
        Me.HAIBAN_R.Name = "HAIBAN_R"
        Me.HAIBAN_R.Size = New System.Drawing.Size(55, 19)
        Me.HAIBAN_R.TabIndex = 1
        Me.HAIBAN_R.TabStop = True
        Me.HAIBAN_R.Text = "廃番"
        Me.HAIBAN_R.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(6, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 47)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "発注中止事由"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'REASON_T
        '
        Me.REASON_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REASON_T.Location = New System.Drawing.Point(129, 37)
        Me.REASON_T.Multiline = True
        Me.REASON_T.Name = "REASON_T"
        Me.REASON_T.Size = New System.Drawing.Size(531, 23)
        Me.REASON_T.TabIndex = 5
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape7, Me.LineShape6, Me.LineShape5, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1, Me.RectangleShape9, Me.RectangleShape8, Me.RectangleShape7, Me.RectangleShape6, Me.RectangleShape5, Me.RectangleShape4, Me.RectangleShape3, Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(719, 434)
        Me.ShapeContainer1.TabIndex = 22
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape7
        '
        Me.LineShape7.Name = "LineShape7"
        Me.LineShape7.X1 = 583
        Me.LineShape7.X2 = 583
        Me.LineShape7.Y1 = 27
        Me.LineShape7.Y2 = 81
        '
        'LineShape6
        '
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 460
        Me.LineShape6.X2 = 460
        Me.LineShape6.Y1 = 27
        Me.LineShape6.Y2 = 81
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 381
        Me.LineShape5.X2 = 381
        Me.LineShape5.Y1 = 53
        Me.LineShape5.Y2 = 82
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 255
        Me.LineShape4.X2 = 255
        Me.LineShape4.Y1 = 53
        Me.LineShape4.Y2 = 80
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 417
        Me.LineShape3.X2 = 417
        Me.LineShape3.Y1 = 26
        Me.LineShape3.Y2 = 52
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 292
        Me.LineShape2.X2 = 292
        Me.LineShape2.Y1 = 26
        Me.LineShape2.Y2 = 52
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 151
        Me.LineShape1.X2 = 151
        Me.LineShape1.Y1 = 27
        Me.LineShape1.Y2 = 284
        '
        'RectangleShape9
        '
        Me.RectangleShape9.Location = New System.Drawing.Point(26, 255)
        Me.RectangleShape9.Name = "RectangleShape9"
        Me.RectangleShape9.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape8
        '
        Me.RectangleShape8.Location = New System.Drawing.Point(26, 226)
        Me.RectangleShape8.Name = "RectangleShape8"
        Me.RectangleShape8.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape7
        '
        Me.RectangleShape7.Location = New System.Drawing.Point(26, 197)
        Me.RectangleShape7.Name = "RectangleShape7"
        Me.RectangleShape7.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape6
        '
        Me.RectangleShape6.Location = New System.Drawing.Point(26, 168)
        Me.RectangleShape6.Name = "RectangleShape6"
        Me.RectangleShape6.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape5
        '
        Me.RectangleShape5.Location = New System.Drawing.Point(26, 110)
        Me.RectangleShape5.Name = "RectangleShape5"
        Me.RectangleShape5.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape4
        '
        Me.RectangleShape4.Location = New System.Drawing.Point(26, 139)
        Me.RectangleShape4.Name = "RectangleShape4"
        Me.RectangleShape4.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.Location = New System.Drawing.Point(26, 81)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.Location = New System.Drawing.Point(26, 52)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(663, 29)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(26, 25)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(663, 27)
        '
        'ORDER_CODE_L
        '
        Me.ORDER_CODE_L.BackColor = System.Drawing.Color.Wheat
        Me.ORDER_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_CODE_L.ForeColor = System.Drawing.Color.Black
        Me.ORDER_CODE_L.Location = New System.Drawing.Point(156, 28)
        Me.ORDER_CODE_L.Name = "ORDER_CODE_L"
        Me.ORDER_CODE_L.Size = New System.Drawing.Size(134, 23)
        Me.ORDER_CODE_L.TabIndex = 23
        Me.ORDER_CODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ORDER_SUB_CODE_L
        '
        Me.ORDER_SUB_CODE_L.BackColor = System.Drawing.Color.Wheat
        Me.ORDER_SUB_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ORDER_SUB_CODE_L.ForeColor = System.Drawing.Color.Black
        Me.ORDER_SUB_CODE_L.Location = New System.Drawing.Point(421, 28)
        Me.ORDER_SUB_CODE_L.Name = "ORDER_SUB_CODE_L"
        Me.ORDER_SUB_CODE_L.Size = New System.Drawing.Size(37, 22)
        Me.ORDER_SUB_CODE_L.TabIndex = 24
        Me.ORDER_SUB_CODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'COSTPRICE_L
        '
        Me.COSTPRICE_L.BackColor = System.Drawing.Color.Wheat
        Me.COSTPRICE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COSTPRICE_L.ForeColor = System.Drawing.Color.Black
        Me.COSTPRICE_L.Location = New System.Drawing.Point(156, 56)
        Me.COSTPRICE_L.Name = "COSTPRICE_L"
        Me.COSTPRICE_L.Size = New System.Drawing.Size(95, 23)
        Me.COSTPRICE_L.TabIndex = 25
        Me.COSTPRICE_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CNT_L
        '
        Me.CNT_L.BackColor = System.Drawing.Color.Wheat
        Me.CNT_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CNT_L.ForeColor = System.Drawing.Color.Black
        Me.CNT_L.Location = New System.Drawing.Point(383, 56)
        Me.CNT_L.Name = "CNT_L"
        Me.CNT_L.Size = New System.Drawing.Size(75, 23)
        Me.CNT_L.TabIndex = 26
        Me.CNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TOTAL_PRICE_L
        '
        Me.TOTAL_PRICE_L.BackColor = System.Drawing.Color.Wheat
        Me.TOTAL_PRICE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_PRICE_L.ForeColor = System.Drawing.Color.Black
        Me.TOTAL_PRICE_L.Location = New System.Drawing.Point(587, 56)
        Me.TOTAL_PRICE_L.Name = "TOTAL_PRICE_L"
        Me.TOTAL_PRICE_L.Size = New System.Drawing.Size(96, 23)
        Me.TOTAL_PRICE_L.TabIndex = 27
        Me.TOTAL_PRICE_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRODUCT_CODE_L
        '
        Me.PRODUCT_CODE_L.BackColor = System.Drawing.Color.Wheat
        Me.PRODUCT_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_L.ForeColor = System.Drawing.Color.Black
        Me.PRODUCT_CODE_L.Location = New System.Drawing.Point(156, 85)
        Me.PRODUCT_CODE_L.Name = "PRODUCT_CODE_L"
        Me.PRODUCT_CODE_L.Size = New System.Drawing.Size(527, 23)
        Me.PRODUCT_CODE_L.TabIndex = 28
        Me.PRODUCT_CODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_L
        '
        Me.PRODUCT_NAME_L.BackColor = System.Drawing.Color.Wheat
        Me.PRODUCT_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_L.ForeColor = System.Drawing.Color.Black
        Me.PRODUCT_NAME_L.Location = New System.Drawing.Point(156, 114)
        Me.PRODUCT_NAME_L.Name = "PRODUCT_NAME_L"
        Me.PRODUCT_NAME_L.Size = New System.Drawing.Size(527, 23)
        Me.PRODUCT_NAME_L.TabIndex = 29
        Me.PRODUCT_NAME_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION1_L
        '
        Me.OPTION1_L.BackColor = System.Drawing.Color.Wheat
        Me.OPTION1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION1_L.ForeColor = System.Drawing.Color.Black
        Me.OPTION1_L.Location = New System.Drawing.Point(156, 143)
        Me.OPTION1_L.Name = "OPTION1_L"
        Me.OPTION1_L.Size = New System.Drawing.Size(527, 23)
        Me.OPTION1_L.TabIndex = 30
        Me.OPTION1_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION2_L
        '
        Me.OPTION2_L.BackColor = System.Drawing.Color.Wheat
        Me.OPTION2_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION2_L.ForeColor = System.Drawing.Color.Black
        Me.OPTION2_L.Location = New System.Drawing.Point(156, 172)
        Me.OPTION2_L.Name = "OPTION2_L"
        Me.OPTION2_L.Size = New System.Drawing.Size(527, 23)
        Me.OPTION2_L.TabIndex = 31
        Me.OPTION2_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION3_L
        '
        Me.OPTION3_L.BackColor = System.Drawing.Color.Wheat
        Me.OPTION3_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION3_L.ForeColor = System.Drawing.Color.Black
        Me.OPTION3_L.Location = New System.Drawing.Point(156, 201)
        Me.OPTION3_L.Name = "OPTION3_L"
        Me.OPTION3_L.Size = New System.Drawing.Size(527, 23)
        Me.OPTION3_L.TabIndex = 32
        Me.OPTION3_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION4_L
        '
        Me.OPTION4_L.BackColor = System.Drawing.Color.Wheat
        Me.OPTION4_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION4_L.ForeColor = System.Drawing.Color.Black
        Me.OPTION4_L.Location = New System.Drawing.Point(156, 230)
        Me.OPTION4_L.Name = "OPTION4_L"
        Me.OPTION4_L.Size = New System.Drawing.Size(527, 23)
        Me.OPTION4_L.TabIndex = 33
        Me.OPTION4_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION5_L
        '
        Me.OPTION5_L.BackColor = System.Drawing.Color.Wheat
        Me.OPTION5_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION5_L.ForeColor = System.Drawing.Color.Black
        Me.OPTION5_L.Location = New System.Drawing.Point(155, 259)
        Me.OPTION5_L.Name = "OPTION5_L"
        Me.OPTION5_L.Size = New System.Drawing.Size(527, 23)
        Me.OPTION5_L.TabIndex = 34
        Me.OPTION5_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRICE_L
        '
        Me.PRICE_L.BackColor = System.Drawing.Color.Wheat
        Me.PRICE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRICE_L.ForeColor = System.Drawing.Color.Black
        Me.PRICE_L.Location = New System.Drawing.Point(587, 27)
        Me.PRICE_L.Name = "PRICE_L"
        Me.PRICE_L.Size = New System.Drawing.Size(96, 23)
        Me.PRICE_L.TabIndex = 36
        Me.PRICE_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(464, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 23)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "定価"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PRODUCT_MST_B
        '
        Me.PRODUCT_MST_B.ColorBottom = System.Drawing.Color.Wheat
        Me.PRODUCT_MST_B.Location = New System.Drawing.Point(24, 366)
        Me.PRODUCT_MST_B.Name = "PRODUCT_MST_B"
        Me.PRODUCT_MST_B.Size = New System.Drawing.Size(169, 49)
        Me.PRODUCT_MST_B.TabIndex = 2
        Me.PRODUCT_MST_B.TextButton = "商品マスタ更新"
        '
        'ARRIVE_B
        '
        Me.ARRIVE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ARRIVE_B.Location = New System.Drawing.Point(255, 366)
        Me.ARRIVE_B.Name = "ARRIVE_B"
        Me.ARRIVE_B.Size = New System.Drawing.Size(104, 49)
        Me.ARRIVE_B.TabIndex = 3
        Me.ARRIVE_B.TextButton = "入庫"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(367, 366)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(104, 49)
        Me.RETURN_B.TabIndex = 4
        Me.RETURN_B.TextButton = "戻る"
        '
        'CANCEL_NG_B
        '
        Me.CANCEL_NG_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CANCEL_NG_B.Location = New System.Drawing.Point(477, 366)
        Me.CANCEL_NG_B.Name = "CANCEL_NG_B"
        Me.CANCEL_NG_B.Size = New System.Drawing.Size(104, 49)
        Me.CANCEL_NG_B.TabIndex = 6
        Me.CANCEL_NG_B.TextButton = "中止解除"
        '
        'CANCEL_OK_B
        '
        Me.CANCEL_OK_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CANCEL_OK_B.Location = New System.Drawing.Point(586, 366)
        Me.CANCEL_OK_B.Name = "CANCEL_OK_B"
        Me.CANCEL_OK_B.Size = New System.Drawing.Size(104, 49)
        Me.CANCEL_OK_B.TabIndex = 37
        Me.CANCEL_OK_B.TextButton = "中止登録"
        '
        'fOrderCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(719, 434)
        Me.Controls.Add(Me.CANCEL_OK_B)
        Me.Controls.Add(Me.CANCEL_NG_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.ARRIVE_B)
        Me.Controls.Add(Me.PRODUCT_MST_B)
        Me.Controls.Add(Me.PRICE_L)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.OPTION5_L)
        Me.Controls.Add(Me.OPTION4_L)
        Me.Controls.Add(Me.OPTION3_L)
        Me.Controls.Add(Me.OPTION2_L)
        Me.Controls.Add(Me.OPTION1_L)
        Me.Controls.Add(Me.PRODUCT_NAME_L)
        Me.Controls.Add(Me.PRODUCT_CODE_L)
        Me.Controls.Add(Me.TOTAL_PRICE_L)
        Me.Controls.Add(Me.CNT_L)
        Me.Controls.Add(Me.COSTPRICE_L)
        Me.Controls.Add(Me.ORDER_SUB_CODE_L)
        Me.Controls.Add(Me.ORDER_CODE_L)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fOrderCancel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MISSTAKE_R As System.Windows.Forms.RadioButton
    Friend WithEvents HAIBAN_R As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents REASON_T As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape9 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape8 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape7 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape6 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape5 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents LineShape7 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ORDER_CODE_L As System.Windows.Forms.Label
    Friend WithEvents ORDER_SUB_CODE_L As System.Windows.Forms.Label
    Friend WithEvents COSTPRICE_L As System.Windows.Forms.Label
    Friend WithEvents CNT_L As System.Windows.Forms.Label
    Friend WithEvents TOTAL_PRICE_L As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CODE_L As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_L As System.Windows.Forms.Label
    Friend WithEvents OPTION1_L As System.Windows.Forms.Label
    Friend WithEvents OPTION2_L As System.Windows.Forms.Label
    Friend WithEvents OPTION3_L As System.Windows.Forms.Label
    Friend WithEvents OPTION4_L As System.Windows.Forms.Label
    Friend WithEvents OPTION5_L As System.Windows.Forms.Label
    Friend WithEvents PRICE_L As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NOUKI_R As System.Windows.Forms.RadioButton
    Friend WithEvents OTHER_R As System.Windows.Forms.RadioButton
    Friend WithEvents PRODUCT_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents ARRIVE_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_NG_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_OK_B As Softgroup.NetButton.NetButton
End Class
