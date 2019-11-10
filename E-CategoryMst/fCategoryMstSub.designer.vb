<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCategoryMstSub
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CATEGORY1_ID_T = New System.Windows.Forms.TextBox()
        Me.ID1_L = New System.Windows.Forms.Label()
        Me.CATEGORY1_NAME_T = New System.Windows.Forms.TextBox()
        Me.NAME1_L = New System.Windows.Forms.Label()
        Me.GroupBoxEX1 = New Dotnetrix.Controls.GroupBoxEX()
        Me.GroupBoxEX2 = New Dotnetrix.Controls.GroupBoxEX()
        Me.NAME2_l = New System.Windows.Forms.Label()
        Me.CATEGORY2_NAME_T = New System.Windows.Forms.TextBox()
        Me.ID2_l = New System.Windows.Forms.Label()
        Me.CATEGORY2_ID_T = New System.Windows.Forms.TextBox()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.NEW_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBoxEX1.SuspendLayout()
        Me.GroupBoxEX2.SuspendLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(19, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(653, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "（新規）"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(185, 494)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 73
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(79, 494)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 71
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Tan
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(24, 494)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "担当者"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Tan
        Me.DELETE_B.ColorLight = System.Drawing.Color.Wheat
        Me.DELETE_B.ColorTop = System.Drawing.Color.Linen
        Me.DELETE_B.LightEffect = False
        Me.DELETE_B.Location = New System.Drawing.Point(286, 420)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(124, 59)
        Me.DELETE_B.TabIndex = 3
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.ColorLight = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorTop = System.Drawing.Color.Linen
        Me.COMMIT_B.LightEffect = False
        Me.COMMIT_B.Location = New System.Drawing.Point(416, 420)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(124, 59)
        Me.COMMIT_B.TabIndex = 4
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.ColorLight = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorTop = System.Drawing.Color.Linen
        Me.RETURN_B.LightEffect = False
        Me.RETURN_B.Location = New System.Drawing.Point(546, 420)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(124, 59)
        Me.RETURN_B.TabIndex = 5
        Me.RETURN_B.TextButton = "終　了"
        '
        'CATEGORY1_ID_T
        '
        Me.CATEGORY1_ID_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CATEGORY1_ID_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CATEGORY1_ID_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CATEGORY1_ID_T.Location = New System.Drawing.Point(94, 9)
        Me.CATEGORY1_ID_T.MaxLength = 1
        Me.CATEGORY1_ID_T.Name = "CATEGORY1_ID_T"
        Me.CATEGORY1_ID_T.Size = New System.Drawing.Size(31, 22)
        Me.CATEGORY1_ID_T.TabIndex = 1
        Me.CATEGORY1_ID_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ID1_L
        '
        Me.ID1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ID1_L.ForeColor = System.Drawing.Color.Black
        Me.ID1_L.Location = New System.Drawing.Point(6, 10)
        Me.ID1_L.Name = "ID1_L"
        Me.ID1_L.Size = New System.Drawing.Size(82, 19)
        Me.ID1_L.TabIndex = 74
        Me.ID1_L.Text = "カテゴリ1ID："
        Me.ID1_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CATEGORY1_NAME_T
        '
        Me.CATEGORY1_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CATEGORY1_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CATEGORY1_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CATEGORY1_NAME_T.Location = New System.Drawing.Point(244, 10)
        Me.CATEGORY1_NAME_T.MaxLength = 50
        Me.CATEGORY1_NAME_T.Name = "CATEGORY1_NAME_T"
        Me.CATEGORY1_NAME_T.Size = New System.Drawing.Size(390, 22)
        Me.CATEGORY1_NAME_T.TabIndex = 2
        '
        'NAME1_L
        '
        Me.NAME1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME1_L.ForeColor = System.Drawing.Color.Black
        Me.NAME1_L.Location = New System.Drawing.Point(141, 12)
        Me.NAME1_L.Name = "NAME1_L"
        Me.NAME1_L.Size = New System.Drawing.Size(97, 19)
        Me.NAME1_L.TabIndex = 114
        Me.NAME1_L.Text = "カテゴリ1名称："
        Me.NAME1_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEX1
        '
        Me.GroupBoxEX1.Controls.Add(Me.NAME1_L)
        Me.GroupBoxEX1.Controls.Add(Me.CATEGORY1_NAME_T)
        Me.GroupBoxEX1.Controls.Add(Me.ID1_L)
        Me.GroupBoxEX1.Controls.Add(Me.CATEGORY1_ID_T)
        Me.GroupBoxEX1.Location = New System.Drawing.Point(19, 32)
        Me.GroupBoxEX1.Name = "GroupBoxEX1"
        Me.GroupBoxEX1.Size = New System.Drawing.Size(650, 39)
        Me.GroupBoxEX1.TabIndex = 1
        Me.GroupBoxEX1.TabStop = False
        '
        'GroupBoxEX2
        '
        Me.GroupBoxEX2.Controls.Add(Me.NAME2_l)
        Me.GroupBoxEX2.Controls.Add(Me.CATEGORY2_NAME_T)
        Me.GroupBoxEX2.Controls.Add(Me.ID2_l)
        Me.GroupBoxEX2.Controls.Add(Me.CATEGORY2_ID_T)
        Me.GroupBoxEX2.Location = New System.Drawing.Point(19, 77)
        Me.GroupBoxEX2.Name = "GroupBoxEX2"
        Me.GroupBoxEX2.Size = New System.Drawing.Size(650, 47)
        Me.GroupBoxEX2.TabIndex = 2
        Me.GroupBoxEX2.TabStop = False
        '
        'NAME2_l
        '
        Me.NAME2_l.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME2_l.ForeColor = System.Drawing.Color.Black
        Me.NAME2_l.Location = New System.Drawing.Point(141, 16)
        Me.NAME2_l.Name = "NAME2_l"
        Me.NAME2_l.Size = New System.Drawing.Size(97, 19)
        Me.NAME2_l.TabIndex = 114
        Me.NAME2_l.Text = "カテゴリ2名称："
        Me.NAME2_l.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CATEGORY2_NAME_T
        '
        Me.CATEGORY2_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CATEGORY2_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CATEGORY2_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CATEGORY2_NAME_T.Location = New System.Drawing.Point(244, 15)
        Me.CATEGORY2_NAME_T.MaxLength = 50
        Me.CATEGORY2_NAME_T.Name = "CATEGORY2_NAME_T"
        Me.CATEGORY2_NAME_T.Size = New System.Drawing.Size(390, 22)
        Me.CATEGORY2_NAME_T.TabIndex = 2
        '
        'ID2_l
        '
        Me.ID2_l.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ID2_l.ForeColor = System.Drawing.Color.Black
        Me.ID2_l.Location = New System.Drawing.Point(6, 15)
        Me.ID2_l.Name = "ID2_l"
        Me.ID2_l.Size = New System.Drawing.Size(82, 19)
        Me.ID2_l.TabIndex = 74
        Me.ID2_l.Text = "カテゴリ2ID："
        Me.ID2_l.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CATEGORY2_ID_T
        '
        Me.CATEGORY2_ID_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CATEGORY2_ID_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CATEGORY2_ID_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CATEGORY2_ID_T.Location = New System.Drawing.Point(94, 15)
        Me.CATEGORY2_ID_T.MaxLength = 1
        Me.CATEGORY2_ID_T.Name = "CATEGORY2_ID_T"
        Me.CATEGORY2_ID_T.Size = New System.Drawing.Size(31, 22)
        Me.CATEGORY2_ID_T.TabIndex = 1
        Me.CATEGORY2_ID_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DATA_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle10
        Me.DATA_V.Location = New System.Drawing.Point(19, 130)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DATA_V.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(650, 284)
        Me.DATA_V.TabIndex = 74
        Me.DATA_V.TabStop = False
        '
        'NEW_B
        '
        Me.NEW_B.ColorBottom = System.Drawing.Color.Tan
        Me.NEW_B.ColorLight = System.Drawing.Color.Wheat
        Me.NEW_B.ColorTop = System.Drawing.Color.Linen
        Me.NEW_B.LightEffect = False
        Me.NEW_B.Location = New System.Drawing.Point(19, 420)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(175, 59)
        Me.NEW_B.TabIndex = 75
        Me.NEW_B.TextButton = "カテゴリ2－新規登録"
        '
        'fCategoryMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(695, 526)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.DATA_V)
        Me.Controls.Add(Me.GroupBoxEX2)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBoxEX1)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCategoryMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "カテゴリマスタ管理"
        Me.GroupBoxEX1.ResumeLayout(False)
        Me.GroupBoxEX1.PerformLayout()
        Me.GroupBoxEX2.ResumeLayout(False)
        Me.GroupBoxEX2.PerformLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents CATEGORY1_ID_T As System.Windows.Forms.TextBox
    Friend WithEvents ID1_L As System.Windows.Forms.Label
    Friend WithEvents CATEGORY1_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents NAME1_L As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEX1 As Dotnetrix.Controls.GroupBoxEX
    Friend WithEvents GroupBoxEX2 As Dotnetrix.Controls.GroupBoxEX
    Friend WithEvents NAME2_l As System.Windows.Forms.Label
    Friend WithEvents CATEGORY2_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents ID2_l As System.Windows.Forms.Label
    Friend WithEvents CATEGORY2_ID_T As System.Windows.Forms.TextBox
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents NEW_B As Softgroup.NetButton.NetButton

End Class
