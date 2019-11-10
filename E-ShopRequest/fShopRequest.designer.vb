<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShopRequest
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
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SUPPLIER_L = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.PRODUCT_V = New System.Windows.Forms.DataGridView
        Me.REQUEST_C = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TOTAL_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.JANCODE_T = New System.Windows.Forms.TextBox
        Me.SUPPLIER_CODE_T = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.REQUEST_REPORT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQUEST_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQUEST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ON_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OFF_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQUEST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(111, 72)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(110, 20)
        Me.PRODUCT_CODE_T.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "商品番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SUPPLIER_L
        '
        Me.SUPPLIER_L.DropDownHeight = 300
        Me.SUPPLIER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_L.FormattingEnabled = True
        Me.SUPPLIER_L.IntegralHeight = False
        Me.SUPPLIER_L.Location = New System.Drawing.Point(111, 95)
        Me.SUPPLIER_L.Name = "SUPPLIER_L"
        Me.SUPPLIER_L.Size = New System.Drawing.Size(264, 21)
        Me.SUPPLIER_L.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "仕入先："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(111, 26)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(357, 20)
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
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.PRODUCT_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCT_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.PRODUCT_V.Location = New System.Drawing.Point(24, 131)
        Me.PRODUCT_V.Name = "PRODUCT_V"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.PRODUCT_V.RowTemplate.Height = 21
        Me.PRODUCT_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PRODUCT_V.Size = New System.Drawing.Size(986, 556)
        Me.PRODUCT_V.TabIndex = 8
        Me.PRODUCT_V.TabStop = False
        '
        'REQUEST_C
        '
        Me.REQUEST_C.AutoSize = True
        Me.REQUEST_C.Location = New System.Drawing.Point(548, 30)
        Me.REQUEST_C.Name = "REQUEST_C"
        Me.REQUEST_C.Size = New System.Drawing.Size(15, 14)
        Me.REQUEST_C.TabIndex = 6
        Me.REQUEST_C.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(474, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "注文チェック："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(409, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "選択商品数："
        '
        'TOTAL_COUNT_T
        '
        Me.TOTAL_COUNT_T.BackColor = System.Drawing.Color.Wheat
        Me.TOTAL_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_COUNT_T.Location = New System.Drawing.Point(487, 82)
        Me.TOTAL_COUNT_T.Multiline = True
        Me.TOTAL_COUNT_T.Name = "TOTAL_COUNT_T"
        Me.TOTAL_COUNT_T.ReadOnly = True
        Me.TOTAL_COUNT_T.Size = New System.Drawing.Size(68, 28)
        Me.TOTAL_COUNT_T.TabIndex = 17
        Me.TOTAL_COUNT_T.TabStop = False
        Me.TOTAL_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(231, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "JANコード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(294, 72)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(105, 20)
        Me.JANCODE_T.TabIndex = 4
        Me.JANCODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(377, 96)
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(21, 19)
        Me.SUPPLIER_CODE_T.TabIndex = 21
        Me.SUPPLIER_CODE_T.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.REQUEST_REPORT_B)
        Me.GroupBox1.Controls.Add(Me.REQUEST_SEARCH_B)
        Me.GroupBox1.Controls.Add(Me.REQUEST_CODE_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(338, 693)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 59)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'REQUEST_REPORT_B
        '
        Me.REQUEST_REPORT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REQUEST_REPORT_B.CornerRadius = 15
        Me.REQUEST_REPORT_B.Location = New System.Drawing.Point(372, 11)
        Me.REQUEST_REPORT_B.Name = "REQUEST_REPORT_B"
        Me.REQUEST_REPORT_B.Size = New System.Drawing.Size(110, 43)
        Me.REQUEST_REPORT_B.TabIndex = 3
        Me.REQUEST_REPORT_B.TextButton = "注文書再印刷"
        '
        'REQUEST_SEARCH_B
        '
        Me.REQUEST_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REQUEST_SEARCH_B.CornerRadius = 15
        Me.REQUEST_SEARCH_B.Location = New System.Drawing.Point(256, 11)
        Me.REQUEST_SEARCH_B.Name = "REQUEST_SEARCH_B"
        Me.REQUEST_SEARCH_B.Size = New System.Drawing.Size(110, 43)
        Me.REQUEST_SEARCH_B.TabIndex = 2
        Me.REQUEST_SEARCH_B.TextButton = "注文書呼出"
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(86, 19)
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.Size = New System.Drawing.Size(161, 26)
        Me.REQUEST_CODE_T.TabIndex = 1
        Me.REQUEST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "注文番号："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(122, 707)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(117, 20)
        Me.STAFF_CODE_T.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 710)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "担当者コード："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(122, 727)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(190, 20)
        Me.STAFF_NAME_T.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 730)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "担当者名称："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(111, 49)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(452, 20)
        Me.OPTION_NAME_T.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "オプション名称："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1036, 768)
        Me.ShapeContainer1.TabIndex = 14
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Sienna
        Me.RectangleShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(404, 75)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(159, 42)
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.CornerRadius = 10
        Me.SEARCH_B.Location = New System.Drawing.Point(661, 26)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(130, 92)
        Me.SEARCH_B.TabIndex = 7
        Me.SEARCH_B.TextButton = "検　索"
        '
        'ON_B
        '
        Me.ON_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ON_B.CornerRadius = 10
        Me.ON_B.Location = New System.Drawing.Point(797, 29)
        Me.ON_B.Name = "ON_B"
        Me.ON_B.Size = New System.Drawing.Size(78, 41)
        Me.ON_B.TabIndex = 13
        Me.ON_B.TextButton = "すべてOn"
        '
        'OFF_B
        '
        Me.OFF_B.ColorBottom = System.Drawing.Color.Wheat
        Me.OFF_B.CornerRadius = 10
        Me.OFF_B.Location = New System.Drawing.Point(799, 77)
        Me.OFF_B.Name = "OFF_B"
        Me.OFF_B.Size = New System.Drawing.Size(78, 41)
        Me.OFF_B.TabIndex = 14
        Me.OFF_B.TextButton = "すべてOff"
        '
        'REQUEST_B
        '
        Me.REQUEST_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REQUEST_B.CornerRadius = 10
        Me.REQUEST_B.Location = New System.Drawing.Point(881, 28)
        Me.REQUEST_B.Name = "REQUEST_B"
        Me.REQUEST_B.Size = New System.Drawing.Size(129, 90)
        Me.REQUEST_B.TabIndex = 9
        Me.REQUEST_B.TextButton = "注文書作成"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CLOSE_B.CornerRadius = 15
        Me.CLOSE_B.Location = New System.Drawing.Point(866, 697)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(144, 55)
        Me.CLOSE_B.TabIndex = 15
        Me.CLOSE_B.TextButton = "終　了"
        '
        'fShopRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1036, 768)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.REQUEST_B)
        Me.Controls.Add(Me.OFF_B)
        Me.Controls.Add(Me.ON_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.TOTAL_COUNT_T)
        Me.Controls.Add(Me.JANCODE_T)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.REQUEST_C)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.SUPPLIER_L)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SUPPLIER_CODE_T)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PRODUCT_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fShopRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "取寄せ注文画面"
        CType(Me.PRODUCT_V, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents REQUEST_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TOTAL_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents SUPPLIER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents ON_B As Softgroup.NetButton.NetButton
    Friend WithEvents OFF_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQUEST_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQUEST_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQUEST_REPORT_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton

End Class
