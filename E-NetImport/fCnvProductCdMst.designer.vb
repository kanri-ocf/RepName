<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCnvProductCdMst
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
        Me.P_JANCODE_T = New System.Windows.Forms.TextBox
        Me.P_PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.P_PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.P_PRODUCT_MST_V = New System.Windows.Forms.DataGridView
        Me.P_MAKER_NAME_T = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.P_SEARCH_PROD_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.P_SUPPLIER_L = New System.Windows.Forms.ComboBox
        Me.UPDATE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.CHL_PRODUCT_NAME_T = New System.Windows.Forms.TextBox
        Me.CHL_PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.PRODUCT_CD_ISNULL_C = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CNV_PRODUCT_CD_MST_V = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.P_PRODUCT_MST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CNV_PRODUCT_CD_MST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'P_JANCODE_T
        '
        Me.P_JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.P_JANCODE_T.Location = New System.Drawing.Point(327, 22)
        Me.P_JANCODE_T.Name = "P_JANCODE_T"
        Me.P_JANCODE_T.Size = New System.Drawing.Size(100, 20)
        Me.P_JANCODE_T.TabIndex = 3
        '
        'P_PRODUCT_CODE_T
        '
        Me.P_PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.P_PRODUCT_CODE_T.Location = New System.Drawing.Point(140, 21)
        Me.P_PRODUCT_CODE_T.Name = "P_PRODUCT_CODE_T"
        Me.P_PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.P_PRODUCT_CODE_T.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(253, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "JANコード："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(473, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "仕入先："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(63, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "商品コード："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'P_PRODUCT_NAME_T
        '
        Me.P_PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.P_PRODUCT_NAME_T.Location = New System.Drawing.Point(140, 51)
        Me.P_PRODUCT_NAME_T.Name = "P_PRODUCT_NAME_T"
        Me.P_PRODUCT_NAME_T.Size = New System.Drawing.Size(287, 20)
        Me.P_PRODUCT_NAME_T.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(66, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "商品名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'P_PRODUCT_MST_V
        '
        Me.P_PRODUCT_MST_V.AllowUserToAddRows = False
        Me.P_PRODUCT_MST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.P_PRODUCT_MST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.P_PRODUCT_MST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P_PRODUCT_MST_V.Location = New System.Drawing.Point(19, 85)
        Me.P_PRODUCT_MST_V.Name = "P_PRODUCT_MST_V"
        Me.P_PRODUCT_MST_V.RowTemplate.Height = 21
        Me.P_PRODUCT_MST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.P_PRODUCT_MST_V.Size = New System.Drawing.Size(940, 200)
        Me.P_PRODUCT_MST_V.TabIndex = 149
        Me.P_PRODUCT_MST_V.TabStop = False
        '
        'P_MAKER_NAME_T
        '
        Me.P_MAKER_NAME_T.BackColor = System.Drawing.SystemColors.Window
        Me.P_MAKER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_MAKER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.P_MAKER_NAME_T.Location = New System.Drawing.Point(539, 49)
        Me.P_MAKER_NAME_T.Name = "P_MAKER_NAME_T"
        Me.P_MAKER_NAME_T.Size = New System.Drawing.Size(223, 20)
        Me.P_MAKER_NAME_T.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.Label11.Location = New System.Drawing.Point(454, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 15)
        Me.Label11.TabIndex = 157
        Me.Label11.Text = "メーカー名："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.P_SEARCH_PROD_B)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.P_PRODUCT_MST_V)
        Me.GroupBox1.Controls.Add(Me.P_SUPPLIER_L)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.P_MAKER_NAME_T)
        Me.GroupBox1.Controls.Add(Me.P_PRODUCT_NAME_T)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.P_JANCODE_T)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.P_PRODUCT_CODE_T)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 328)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(976, 305)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'P_SEARCH_PROD_B
        '
        Me.P_SEARCH_PROD_B.ColorBottom = System.Drawing.Color.Wheat
        Me.P_SEARCH_PROD_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_SEARCH_PROD_B.Location = New System.Drawing.Point(834, 22)
        Me.P_SEARCH_PROD_B.Name = "P_SEARCH_PROD_B"
        Me.P_SEARCH_PROD_B.Size = New System.Drawing.Size(125, 51)
        Me.P_SEARCH_PROD_B.TabIndex = 161
        Me.P_SEARCH_PROD_B.TextButton = "検　索"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, -1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 15)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "【商品マスタ】"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_SUPPLIER_L
        '
        Me.P_SUPPLIER_L.DropDownHeight = 300
        Me.P_SUPPLIER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_SUPPLIER_L.FormattingEnabled = True
        Me.P_SUPPLIER_L.IntegralHeight = False
        Me.P_SUPPLIER_L.Location = New System.Drawing.Point(539, 21)
        Me.P_SUPPLIER_L.Name = "P_SUPPLIER_L"
        Me.P_SUPPLIER_L.Size = New System.Drawing.Size(276, 21)
        Me.P_SUPPLIER_L.TabIndex = 4
        '
        'UPDATE_B
        '
        Me.UPDATE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.UPDATE_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UPDATE_B.Location = New System.Drawing.Point(697, 655)
        Me.UPDATE_B.Name = "UPDATE_B"
        Me.UPDATE_B.Size = New System.Drawing.Size(142, 51)
        Me.UPDATE_B.TabIndex = 7
        Me.UPDATE_B.TextButton = "登　録"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CLOSE_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLOSE_B.Location = New System.Drawing.Point(854, 655)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(142, 51)
        Me.CLOSE_B.TabIndex = 10
        Me.CLOSE_B.TextButton = "終　了"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PRODUCT_CODE_T)
        Me.GroupBox2.Controls.Add(Me.CHL_PRODUCT_NAME_T)
        Me.GroupBox2.Controls.Add(Me.CHL_PRODUCT_CODE_T)
        Me.GroupBox2.Controls.Add(Me.CHANNEL_L)
        Me.GroupBox2.Controls.Add(Me.SEARCH_B)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.PRODUCT_CD_ISNULL_C)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.CNV_PRODUCT_CD_MST_V)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(976, 305)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【ネット掲載状況】"
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(469, 48)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 147
        '
        'CHL_PRODUCT_NAME_T
        '
        Me.CHL_PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHL_PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CHL_PRODUCT_NAME_T.Location = New System.Drawing.Point(373, 21)
        Me.CHL_PRODUCT_NAME_T.Name = "CHL_PRODUCT_NAME_T"
        Me.CHL_PRODUCT_NAME_T.Size = New System.Drawing.Size(314, 20)
        Me.CHL_PRODUCT_NAME_T.TabIndex = 149
        '
        'CHL_PRODUCT_CODE_T
        '
        Me.CHL_PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHL_PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CHL_PRODUCT_CODE_T.Location = New System.Drawing.Point(140, 21)
        Me.CHL_PRODUCT_CODE_T.Name = "CHL_PRODUCT_CODE_T"
        Me.CHL_PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.CHL_PRODUCT_CODE_T.TabIndex = 146
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CHANNEL_L.Location = New System.Drawing.Point(140, 47)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(227, 23)
        Me.CHANNEL_L.TabIndex = 145
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(834, 20)
        Me.SEARCH_B.Margin = New System.Windows.Forms.Padding(4)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(125, 51)
        Me.SEARCH_B.TabIndex = 150
        Me.SEARCH_B.TextButton = "検　索"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(391, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "商品コード："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_CD_ISNULL_C
        '
        Me.PRODUCT_CD_ISNULL_C.AutoSize = True
        Me.PRODUCT_CD_ISNULL_C.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRODUCT_CD_ISNULL_C.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.PRODUCT_CD_ISNULL_C.Location = New System.Drawing.Point(608, 49)
        Me.PRODUCT_CD_ISNULL_C.Name = "PRODUCT_CD_ISNULL_C"
        Me.PRODUCT_CD_ISNULL_C.Size = New System.Drawing.Size(79, 19)
        Me.PRODUCT_CD_ISNULL_C.TabIndex = 148
        Me.PRODUCT_CD_ISNULL_C.Text = "未設定："
        Me.PRODUCT_CD_ISNULL_C.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRODUCT_CD_ISNULL_C.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 15)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "チャネル商品名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 15)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "チャネル商品コード："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "チャネル名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CNV_PRODUCT_CD_MST_V
        '
        Me.CNV_PRODUCT_CD_MST_V.AllowUserToAddRows = False
        Me.CNV_PRODUCT_CD_MST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.CNV_PRODUCT_CD_MST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CNV_PRODUCT_CD_MST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CNV_PRODUCT_CD_MST_V.Location = New System.Drawing.Point(19, 81)
        Me.CNV_PRODUCT_CD_MST_V.Name = "CNV_PRODUCT_CD_MST_V"
        Me.CNV_PRODUCT_CD_MST_V.RowTemplate.Height = 21
        Me.CNV_PRODUCT_CD_MST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CNV_PRODUCT_CD_MST_V.Size = New System.Drawing.Size(940, 210)
        Me.CNV_PRODUCT_CD_MST_V.TabIndex = 151
        Me.CNV_PRODUCT_CD_MST_V.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(37, 642)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(488, 75)
        Me.Label10.TabIndex = 146
        Me.Label10.Text = "上段の「ネット掲載」の商品と下段「商品マスタ」の商品のマッピングを行って下さい。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "「上段」を選択後、それに紐づく商品マスタのデータを「下段」より選択して下さい。" & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "「下段」の選択が当該行をダブルクリックして下さい。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "すべてのマッピングが終了したら、「登録」ボタンをクリックして下さい。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'fCnvProductCdMst
        '
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 728)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.UPDATE_B)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCnvProductCdMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品コード変換画面"
        CType(Me.P_PRODUCT_MST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CNV_PRODUCT_CD_MST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents P_JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents P_PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents P_PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents P_PRODUCT_MST_V As System.Windows.Forms.DataGridView
    Friend WithEvents P_MAKER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents P_SUPPLIER_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UPDATE_B As Softgroup.NetButton.NetButton
    Friend WithEvents P_SEARCH_PROD_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHL_PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents CHL_PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CD_ISNULL_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CNV_PRODUCT_CD_MST_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
