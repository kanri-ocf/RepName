<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAccountMstSub
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
        Me.ACCOUNT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxEX1 = New Dotnetrix.Controls.GroupBoxEX()
        Me.TAX_CLASS_CODE_T = New System.Windows.Forms.TextBox()
        Me.TAX_CLASS_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TAX_CLASS_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LINK_MASTER_L = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ACCOUNT_CODE_T = New System.Windows.Forms.TextBox()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SUB_ACCOUNT_ADD_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SUB_ACCOUNT_DEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SUB_ACCOUNT_NAME_T = New System.Windows.Forms.TextBox()
        Me.SUB_ACCOUNT_CODE_T = New System.Windows.Forms.TextBox()
        Me.GroupBoxEX1.SuspendLayout()
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
        Me.MODE_L.Size = New System.Drawing.Size(608, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "（新規）"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(72, 400)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 73
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(72, 374)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.STAFF_CODE_T.TabIndex = 71
        Me.STAFF_CODE_T.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Tan
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(17, 374)
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
        Me.DELETE_B.Location = New System.Drawing.Point(288, 374)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(109, 59)
        Me.DELETE_B.TabIndex = 9
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.ColorLight = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorTop = System.Drawing.Color.Linen
        Me.COMMIT_B.LightEffect = False
        Me.COMMIT_B.Location = New System.Drawing.Point(403, 374)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(109, 59)
        Me.COMMIT_B.TabIndex = 10
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.ColorLight = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorTop = System.Drawing.Color.Linen
        Me.RETURN_B.LightEffect = False
        Me.RETURN_B.Location = New System.Drawing.Point(518, 374)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 59)
        Me.RETURN_B.TabIndex = 11
        Me.RETURN_B.TextButton = "戻　る"
        '
        'ACCOUNT_NAME_T
        '
        Me.ACCOUNT_NAME_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.ACCOUNT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ACCOUNT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ACCOUNT_NAME_T.Location = New System.Drawing.Point(208, 45)
        Me.ACCOUNT_NAME_T.MaxLength = 8
        Me.ACCOUNT_NAME_T.Name = "ACCOUNT_NAME_T"
        Me.ACCOUNT_NAME_T.Size = New System.Drawing.Size(273, 22)
        Me.ACCOUNT_NAME_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(89, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 19)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "勘定科目名称："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEX1
        '
        Me.GroupBoxEX1.Controls.Add(Me.TAX_CLASS_CODE_T)
        Me.GroupBoxEX1.Controls.Add(Me.TAX_CLASS_B)
        Me.GroupBoxEX1.Controls.Add(Me.TAX_CLASS_NAME_T)
        Me.GroupBoxEX1.Controls.Add(Me.Label3)
        Me.GroupBoxEX1.Controls.Add(Me.Label4)
        Me.GroupBoxEX1.Controls.Add(Me.LINK_MASTER_L)
        Me.GroupBoxEX1.Controls.Add(Me.Label1)
        Me.GroupBoxEX1.Controls.Add(Me.ACCOUNT_CODE_T)
        Me.GroupBoxEX1.Controls.Add(Me.Label5)
        Me.GroupBoxEX1.Controls.Add(Me.ACCOUNT_NAME_T)
        Me.GroupBoxEX1.Location = New System.Drawing.Point(19, 32)
        Me.GroupBoxEX1.Name = "GroupBoxEX1"
        Me.GroupBoxEX1.Size = New System.Drawing.Size(608, 138)
        Me.GroupBoxEX1.TabIndex = 1
        Me.GroupBoxEX1.TabStop = False
        '
        'TAX_CLASS_CODE_T
        '
        Me.TAX_CLASS_CODE_T.BackColor = System.Drawing.Color.Gray
        Me.TAX_CLASS_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_CLASS_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TAX_CLASS_CODE_T.Location = New System.Drawing.Point(374, 100)
        Me.TAX_CLASS_CODE_T.MaxLength = 13
        Me.TAX_CLASS_CODE_T.Name = "TAX_CLASS_CODE_T"
        Me.TAX_CLASS_CODE_T.ReadOnly = True
        Me.TAX_CLASS_CODE_T.Size = New System.Drawing.Size(24, 20)
        Me.TAX_CLASS_CODE_T.TabIndex = 150
        Me.TAX_CLASS_CODE_T.TabStop = False
        Me.TAX_CLASS_CODE_T.Visible = False
        '
        'TAX_CLASS_B
        '
        Me.TAX_CLASS_B.ColorBottom = System.Drawing.Color.Tan
        Me.TAX_CLASS_B.Location = New System.Drawing.Point(404, 97)
        Me.TAX_CLASS_B.Name = "TAX_CLASS_B"
        Me.TAX_CLASS_B.Size = New System.Drawing.Size(76, 30)
        Me.TAX_CLASS_B.TabIndex = 149
        Me.TAX_CLASS_B.TextButton = "税区分"
        '
        'TAX_CLASS_NAME_T
        '
        Me.TAX_CLASS_NAME_T.BackColor = System.Drawing.Color.White
        Me.TAX_CLASS_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAX_CLASS_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TAX_CLASS_NAME_T.Location = New System.Drawing.Point(208, 100)
        Me.TAX_CLASS_NAME_T.MaxLength = 13
        Me.TAX_CLASS_NAME_T.Name = "TAX_CLASS_NAME_T"
        Me.TAX_CLASS_NAME_T.Size = New System.Drawing.Size(190, 20)
        Me.TAX_CLASS_NAME_T.TabIndex = 148
        Me.TAX_CLASS_NAME_T.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(86, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 19)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "連携マスタ名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(89, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 19)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "税区分名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LINK_MASTER_L
        '
        Me.LINK_MASTER_L.BackColor = System.Drawing.Color.White
        Me.LINK_MASTER_L.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LINK_MASTER_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LINK_MASTER_L.FormattingEnabled = True
        Me.LINK_MASTER_L.Location = New System.Drawing.Point(208, 73)
        Me.LINK_MASTER_L.Name = "LINK_MASTER_L"
        Me.LINK_MASTER_L.Size = New System.Drawing.Size(276, 21)
        Me.LINK_MASTER_L.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(86, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "勘定科目コード："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ACCOUNT_CODE_T
        '
        Me.ACCOUNT_CODE_T.BackColor = System.Drawing.Color.LightGreen
        Me.ACCOUNT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ACCOUNT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ACCOUNT_CODE_T.Location = New System.Drawing.Point(208, 17)
        Me.ACCOUNT_CODE_T.MaxLength = 8
        Me.ACCOUNT_CODE_T.Name = "ACCOUNT_CODE_T"
        Me.ACCOUNT_CODE_T.ReadOnly = True
        Me.ACCOUNT_CODE_T.Size = New System.Drawing.Size(126, 22)
        Me.ACCOUNT_CODE_T.TabIndex = 1
        Me.ACCOUNT_CODE_T.TabStop = False
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
        Me.DATA_V.Location = New System.Drawing.Point(19, 216)
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
        Me.DATA_V.Size = New System.Drawing.Size(608, 152)
        Me.DATA_V.TabIndex = 8
        Me.DATA_V.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 19)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "補助勘定科目名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SUB_ACCOUNT_ADD_B
        '
        Me.SUB_ACCOUNT_ADD_B.ColorBottom = System.Drawing.Color.Tan
        Me.SUB_ACCOUNT_ADD_B.ColorLight = System.Drawing.Color.Wheat
        Me.SUB_ACCOUNT_ADD_B.ColorTop = System.Drawing.Color.Linen
        Me.SUB_ACCOUNT_ADD_B.LightEffect = False
        Me.SUB_ACCOUNT_ADD_B.Location = New System.Drawing.Point(418, 176)
        Me.SUB_ACCOUNT_ADD_B.Name = "SUB_ACCOUNT_ADD_B"
        Me.SUB_ACCOUNT_ADD_B.Size = New System.Drawing.Size(94, 34)
        Me.SUB_ACCOUNT_ADD_B.TabIndex = 6
        Me.SUB_ACCOUNT_ADD_B.TextButton = "追　加"
        '
        'SUB_ACCOUNT_DEL_B
        '
        Me.SUB_ACCOUNT_DEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.SUB_ACCOUNT_DEL_B.ColorLight = System.Drawing.Color.Wheat
        Me.SUB_ACCOUNT_DEL_B.ColorTop = System.Drawing.Color.Linen
        Me.SUB_ACCOUNT_DEL_B.LightEffect = False
        Me.SUB_ACCOUNT_DEL_B.Location = New System.Drawing.Point(518, 177)
        Me.SUB_ACCOUNT_DEL_B.Name = "SUB_ACCOUNT_DEL_B"
        Me.SUB_ACCOUNT_DEL_B.Size = New System.Drawing.Size(94, 34)
        Me.SUB_ACCOUNT_DEL_B.TabIndex = 7
        Me.SUB_ACCOUNT_DEL_B.TextButton = "削　除"
        '
        'SUB_ACCOUNT_NAME_T
        '
        Me.SUB_ACCOUNT_NAME_T.BackColor = System.Drawing.Color.White
        Me.SUB_ACCOUNT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUB_ACCOUNT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SUB_ACCOUNT_NAME_T.Location = New System.Drawing.Point(180, 183)
        Me.SUB_ACCOUNT_NAME_T.MaxLength = 8
        Me.SUB_ACCOUNT_NAME_T.Name = "SUB_ACCOUNT_NAME_T"
        Me.SUB_ACCOUNT_NAME_T.Size = New System.Drawing.Size(223, 22)
        Me.SUB_ACCOUNT_NAME_T.TabIndex = 5
        '
        'SUB_ACCOUNT_CODE_T
        '
        Me.SUB_ACCOUNT_CODE_T.BackColor = System.Drawing.Color.Gray
        Me.SUB_ACCOUNT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUB_ACCOUNT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SUB_ACCOUNT_CODE_T.Location = New System.Drawing.Point(372, 183)
        Me.SUB_ACCOUNT_CODE_T.MaxLength = 8
        Me.SUB_ACCOUNT_CODE_T.Name = "SUB_ACCOUNT_CODE_T"
        Me.SUB_ACCOUNT_CODE_T.ReadOnly = True
        Me.SUB_ACCOUNT_CODE_T.Size = New System.Drawing.Size(31, 22)
        Me.SUB_ACCOUNT_CODE_T.TabIndex = 144
        Me.SUB_ACCOUNT_CODE_T.Visible = False
        '
        'fAccountMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(645, 445)
        Me.Controls.Add(Me.SUB_ACCOUNT_CODE_T)
        Me.Controls.Add(Me.SUB_ACCOUNT_NAME_T)
        Me.Controls.Add(Me.SUB_ACCOUNT_DEL_B)
        Me.Controls.Add(Me.SUB_ACCOUNT_ADD_B)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DATA_V)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBoxEX1)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fAccountMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "勘定科目マスタ管理"
        Me.GroupBoxEX1.ResumeLayout(False)
        Me.GroupBoxEX1.PerformLayout()
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
    Friend WithEvents ACCOUNT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEX1 As Dotnetrix.Controls.GroupBoxEX
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SUB_ACCOUNT_ADD_B As Softgroup.NetButton.NetButton
    Friend WithEvents SUB_ACCOUNT_DEL_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ACCOUNT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents SUB_ACCOUNT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LINK_MASTER_L As System.Windows.Forms.ComboBox
    Friend WithEvents SUB_ACCOUNT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_CLASS_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents TAX_CLASS_B As Softgroup.NetButton.NetButton
    Friend WithEvents TAX_CLASS_NAME_T As System.Windows.Forms.TextBox

End Class
