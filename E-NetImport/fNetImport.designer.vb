<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNetImport
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.REQUEST_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CUSTMOR_NAME_T = New System.Windows.Forms.TextBox
        Me.REQUEST_V = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.HOLD_COUNT_L = New System.Windows.Forms.Label
        Me.PRINTED_C = New System.Windows.Forms.CheckBox
        Me.UNPRINTED_C = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.UNSHIP_C = New System.Windows.Forms.CheckBox
        Me.SHIPED_C = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        Me.PICKUP_CNT_L = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OFF_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ON_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQUEST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.IMPORT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CODE_MAP_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(111, 23)
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.Size = New System.Drawing.Size(217, 20)
        Me.REQUEST_CODE_T.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "受注コード："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "顧客名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CUSTMOR_NAME_T
        '
        Me.CUSTMOR_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CUSTMOR_NAME_T.Location = New System.Drawing.Point(111, 45)
        Me.CUSTMOR_NAME_T.Name = "CUSTMOR_NAME_T"
        Me.CUSTMOR_NAME_T.Size = New System.Drawing.Size(371, 20)
        Me.CUSTMOR_NAME_T.TabIndex = 2
        '
        'REQUEST_V
        '
        Me.REQUEST_V.AllowUserToAddRows = False
        Me.REQUEST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.REQUEST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.GreenYellow
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.REQUEST_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.REQUEST_V.DefaultCellStyle = DataGridViewCellStyle8
        Me.REQUEST_V.Location = New System.Drawing.Point(24, 120)
        Me.REQUEST_V.Name = "REQUEST_V"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.REQUEST_V.RowTemplate.Height = 21
        Me.REQUEST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.REQUEST_V.Size = New System.Drawing.Size(975, 537)
        Me.REQUEST_V.TabIndex = 9
        Me.REQUEST_V.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(324, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "受注日："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'REQUEST_DATE_T
        '
        Me.REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_DATE_T.Location = New System.Drawing.Point(382, 67)
        Me.REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.REQUEST_DATE_T.Name = "REQUEST_DATE_T"
        Me.REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.REQUEST_DATE_T.TabIndex = 24
        Me.REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.Location = New System.Drawing.Point(111, 67)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(207, 20)
        Me.CHANNEL_L.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "チャネル名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 15.0!)
        Me.Label6.Location = New System.Drawing.Point(594, 674)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 37)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "件"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 15.0!)
        Me.Label5.Location = New System.Drawing.Point(342, 674)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 37)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "商品コード不明件数："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HOLD_COUNT_L
        '
        Me.HOLD_COUNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.HOLD_COUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 21.0!)
        Me.HOLD_COUNT_L.Location = New System.Drawing.Point(534, 673)
        Me.HOLD_COUNT_L.Name = "HOLD_COUNT_L"
        Me.HOLD_COUNT_L.Size = New System.Drawing.Size(58, 37)
        Me.HOLD_COUNT_L.TabIndex = 33
        Me.HOLD_COUNT_L.Text = "0"
        Me.HOLD_COUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRINTED_C
        '
        Me.PRINTED_C.AutoSize = True
        Me.PRINTED_C.Location = New System.Drawing.Point(22, 20)
        Me.PRINTED_C.Name = "PRINTED_C"
        Me.PRINTED_C.Size = New System.Drawing.Size(71, 16)
        Me.PRINTED_C.TabIndex = 34
        Me.PRINTED_C.Text = "発行済み"
        Me.PRINTED_C.UseVisualStyleBackColor = True
        '
        'UNPRINTED_C
        '
        Me.UNPRINTED_C.AutoSize = True
        Me.UNPRINTED_C.Checked = True
        Me.UNPRINTED_C.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UNPRINTED_C.Location = New System.Drawing.Point(100, 20)
        Me.UNPRINTED_C.Name = "UNPRINTED_C"
        Me.UNPRINTED_C.Size = New System.Drawing.Size(60, 16)
        Me.UNPRINTED_C.TabIndex = 35
        Me.UNPRINTED_C.Text = "未発行"
        Me.UNPRINTED_C.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UNPRINTED_C)
        Me.GroupBox1.Controls.Add(Me.PRINTED_C)
        Me.GroupBox1.Location = New System.Drawing.Point(503, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 45)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "受注伝票発行状況"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UNSHIP_C)
        Me.GroupBox2.Controls.Add(Me.SHIPED_C)
        Me.GroupBox2.Location = New System.Drawing.Point(503, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(181, 45)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出荷状況"
        '
        'UNSHIP_C
        '
        Me.UNSHIP_C.AutoSize = True
        Me.UNSHIP_C.Location = New System.Drawing.Point(100, 20)
        Me.UNSHIP_C.Name = "UNSHIP_C"
        Me.UNSHIP_C.Size = New System.Drawing.Size(60, 16)
        Me.UNSHIP_C.TabIndex = 35
        Me.UNSHIP_C.Text = "未出荷"
        Me.UNSHIP_C.UseVisualStyleBackColor = True
        '
        'SHIPED_C
        '
        Me.SHIPED_C.AutoSize = True
        Me.SHIPED_C.Location = New System.Drawing.Point(22, 20)
        Me.SHIPED_C.Name = "SHIPED_C"
        Me.SHIPED_C.Size = New System.Drawing.Size(71, 16)
        Me.SHIPED_C.TabIndex = 34
        Me.SHIPED_C.Text = "出荷済み"
        Me.SHIPED_C.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(35, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "商品コード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(111, 89)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(91, 20)
        Me.PRODUCT_CODE_T.TabIndex = 39
        '
        'PICKUP_CNT_L
        '
        Me.PICKUP_CNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PICKUP_CNT_L.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PICKUP_CNT_L.Location = New System.Drawing.Point(915, 15)
        Me.PICKUP_CNT_L.Name = "PICKUP_CNT_L"
        Me.PICKUP_CNT_L.Size = New System.Drawing.Size(54, 30)
        Me.PICKUP_CNT_L.TabIndex = 43
        Me.PICKUP_CNT_L.Text = "0"
        Me.PICKUP_CNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(833, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 37)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "抽出件数："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(971, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 37)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "件"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(705, 53)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(100, 60)
        Me.SEARCH_B.TabIndex = 5
        Me.SEARCH_B.TextButton = "検　索"
        '
        'OFF_B
        '
        Me.OFF_B.ColorBottom = System.Drawing.Color.Wheat
        Me.OFF_B.CornerRadius = 6
        Me.OFF_B.Location = New System.Drawing.Point(811, 53)
        Me.OFF_B.Name = "OFF_B"
        Me.OFF_B.Size = New System.Drawing.Size(84, 29)
        Me.OFF_B.TabIndex = 8
        Me.OFF_B.TextButton = "すべてOff"
        '
        'ON_B
        '
        Me.ON_B.ColorBottom = System.Drawing.Color.Wheat
        Me.ON_B.CornerRadius = 6
        Me.ON_B.Location = New System.Drawing.Point(811, 84)
        Me.ON_B.Name = "ON_B"
        Me.ON_B.Size = New System.Drawing.Size(84, 29)
        Me.ON_B.TabIndex = 7
        Me.ON_B.TextButton = "すべてOn"
        '
        'REQUEST_B
        '
        Me.REQUEST_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REQUEST_B.Location = New System.Drawing.Point(899, 53)
        Me.REQUEST_B.Name = "REQUEST_B"
        Me.REQUEST_B.Size = New System.Drawing.Size(100, 60)
        Me.REQUEST_B.TabIndex = 8
        Me.REQUEST_B.TextButton = "受注伝票印刷"
        '
        'IMPORT_B
        '
        Me.IMPORT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.IMPORT_B.Location = New System.Drawing.Point(24, 670)
        Me.IMPORT_B.Name = "IMPORT_B"
        Me.IMPORT_B.Size = New System.Drawing.Size(153, 40)
        Me.IMPORT_B.TabIndex = 10
        Me.IMPORT_B.TextButton = "インポート"
        '
        'CODE_MAP_B
        '
        Me.CODE_MAP_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CODE_MAP_B.Location = New System.Drawing.Point(678, 670)
        Me.CODE_MAP_B.Name = "CODE_MAP_B"
        Me.CODE_MAP_B.Size = New System.Drawing.Size(153, 40)
        Me.CODE_MAP_B.TabIndex = 11
        Me.CODE_MAP_B.TextButton = "商品コード変換"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CLOSE_B.Location = New System.Drawing.Point(846, 671)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(153, 40)
        Me.CLOSE_B.TabIndex = 12
        Me.CLOSE_B.TextButton = "終　了"
        '
        'fNetImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 726)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.CODE_MAP_B)
        Me.Controls.Add(Me.IMPORT_B)
        Me.Controls.Add(Me.REQUEST_B)
        Me.Controls.Add(Me.ON_B)
        Me.Controls.Add(Me.OFF_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.PICKUP_CNT_L)
        Me.Controls.Add(Me.HOLD_COUNT_L)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CUSTMOR_NAME_T)
        Me.Controls.Add(Me.REQUEST_DATE_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.REQUEST_CODE_T)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.REQUEST_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fNetImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "受注登録画面"
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CUSTMOR_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents REQUEST_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents HOLD_COUNT_L As System.Windows.Forms.Label
    Friend WithEvents PRINTED_C As System.Windows.Forms.CheckBox
    Friend WithEvents UNPRINTED_C As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents UNSHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents SHIPED_C As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents PICKUP_CNT_L As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents OFF_B As Softgroup.NetButton.NetButton
    Friend WithEvents ON_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQUEST_B As Softgroup.NetButton.NetButton
    Friend WithEvents IMPORT_B As Softgroup.NetButton.NetButton
    Friend WithEvents CODE_MAP_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
