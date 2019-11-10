<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fDeliveryMst
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DATA_V = New System.Windows.Forms.DataGridView
        Me.CODE_L = New System.Windows.Forms.Label
        Me.CODE_T = New System.Windows.Forms.TextBox
        Me.NAME_T = New System.Windows.Forms.TextBox
        Me.NAME_L = New System.Windows.Forms.Label
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NEW_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ITEM_CLASS_L = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DATA_V.ColumnHeadersHeight = 25
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle6
        Me.DATA_V.Location = New System.Drawing.Point(28, 101)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DATA_V.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(491, 217)
        Me.DATA_V.TabIndex = 4
        Me.DATA_V.TabStop = False
        '
        'CODE_L
        '
        Me.CODE_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CODE_L.ForeColor = System.Drawing.Color.White
        Me.CODE_L.Location = New System.Drawing.Point(26, 28)
        Me.CODE_L.Name = "CODE_L"
        Me.CODE_L.Size = New System.Drawing.Size(82, 19)
        Me.CODE_L.TabIndex = 20
        Me.CODE_L.Text = "コード"
        Me.CODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CODE_T
        '
        Me.CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CODE_T.Location = New System.Drawing.Point(114, 28)
        Me.CODE_T.Name = "CODE_T"
        Me.CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.CODE_T.TabIndex = 0
        '
        'NAME_T
        '
        Me.NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.NAME_T.Location = New System.Drawing.Point(114, 75)
        Me.NAME_T.Name = "NAME_T"
        Me.NAME_T.Size = New System.Drawing.Size(270, 20)
        Me.NAME_T.TabIndex = 2
        '
        'NAME_L
        '
        Me.NAME_L.BackColor = System.Drawing.Color.SaddleBrown
        Me.NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_L.ForeColor = System.Drawing.Color.White
        Me.NAME_L.Location = New System.Drawing.Point(26, 76)
        Me.NAME_L.Name = "NAME_L"
        Me.NAME_L.Size = New System.Drawing.Size(82, 19)
        Me.NAME_L.TabIndex = 26
        Me.NAME_L.Text = "名称"
        Me.NAME_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(86, 335)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 28
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(31, 335)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "担当者"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(86, 361)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(399, 34)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(120, 56)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "検　索"
        '
        'NEW_B
        '
        Me.NEW_B.ColorBottom = System.Drawing.Color.Wheat
        Me.NEW_B.Location = New System.Drawing.Point(295, 335)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(109, 48)
        Me.NEW_B.TabIndex = 5
        Me.NEW_B.TextButton = "新規登録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(410, 335)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 31
        Me.RETURN_B.TextButton = "終　了"
        '
        'ITEM_CLASS_L
        '
        Me.ITEM_CLASS_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITEM_CLASS_L.FormattingEnabled = True
        Me.ITEM_CLASS_L.Location = New System.Drawing.Point(114, 50)
        Me.ITEM_CLASS_L.Name = "ITEM_CLASS_L"
        Me.ITEM_CLASS_L.Size = New System.Drawing.Size(205, 23)
        Me.ITEM_CLASS_L.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(26, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 19)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "項目種別"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fDeliveryMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(551, 401)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ITEM_CLASS_L)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.NAME_T)
        Me.Controls.Add(Me.CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NAME_L)
        Me.Controls.Add(Me.CODE_L)
        Me.Controls.Add(Me.DATA_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fDeliveryMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "スタッフマスタ検索画面"
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents CODE_L As System.Windows.Forms.Label
    Friend WithEvents CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents NAME_L As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents NEW_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents ITEM_CLASS_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
