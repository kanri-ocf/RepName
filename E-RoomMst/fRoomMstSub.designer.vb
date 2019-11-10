<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRoomMstSub
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
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ROOM_CODE_T = New System.Windows.Forms.TextBox()
        Me.ROOM_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxEX1 = New Dotnetrix.Controls.GroupBoxEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.CHANNEL_NAME_L = New System.Windows.Forms.ComboBox()
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BUMON_CODE_T = New System.Windows.Forms.TextBox()
        Me.BUMON_NAME_L = New System.Windows.Forms.ComboBox()
        Me.BUMON_ADD_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.BUMON_DEL_B = New Softgroup.NetButton.NetButton(Me.components)
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
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(72, 349)
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
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(72, 323)
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
        Me.Label15.Location = New System.Drawing.Point(17, 323)
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
        Me.DELETE_B.Location = New System.Drawing.Point(288, 323)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(109, 59)
        Me.DELETE_B.TabIndex = 3
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.ColorLight = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorTop = System.Drawing.Color.Linen
        Me.COMMIT_B.LightEffect = False
        Me.COMMIT_B.Location = New System.Drawing.Point(403, 323)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(109, 59)
        Me.COMMIT_B.TabIndex = 4
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.ColorLight = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorTop = System.Drawing.Color.Linen
        Me.RETURN_B.LightEffect = False
        Me.RETURN_B.Location = New System.Drawing.Point(518, 323)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 59)
        Me.RETURN_B.TabIndex = 5
        Me.RETURN_B.TextButton = "戻　る"
        '
        'ROOM_CODE_T
        '
        Me.ROOM_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ROOM_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROOM_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ROOM_CODE_T.Location = New System.Drawing.Point(369, 18)
        Me.ROOM_CODE_T.MaxLength = 8
        Me.ROOM_CODE_T.Name = "ROOM_CODE_T"
        Me.ROOM_CODE_T.Size = New System.Drawing.Size(62, 22)
        Me.ROOM_CODE_T.TabIndex = 1
        Me.ROOM_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ROOM_CODE_T.Visible = False
        '
        'ROOM_NAME_T
        '
        Me.ROOM_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ROOM_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROOM_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ROOM_NAME_T.Location = New System.Drawing.Point(128, 54)
        Me.ROOM_NAME_T.MaxLength = 8
        Me.ROOM_NAME_T.Name = "ROOM_NAME_T"
        Me.ROOM_NAME_T.Size = New System.Drawing.Size(273, 22)
        Me.ROOM_NAME_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(25, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "ルーム名称："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEX1
        '
        Me.GroupBoxEX1.Controls.Add(Me.Label1)
        Me.GroupBoxEX1.Controls.Add(Me.CHANNEL_CODE_T)
        Me.GroupBoxEX1.Controls.Add(Me.CHANNEL_NAME_L)
        Me.GroupBoxEX1.Controls.Add(Me.Label5)
        Me.GroupBoxEX1.Controls.Add(Me.ROOM_NAME_T)
        Me.GroupBoxEX1.Controls.Add(Me.ROOM_CODE_T)
        Me.GroupBoxEX1.Location = New System.Drawing.Point(19, 32)
        Me.GroupBoxEX1.Name = "GroupBoxEX1"
        Me.GroupBoxEX1.Size = New System.Drawing.Size(608, 92)
        Me.GroupBoxEX1.TabIndex = 74
        Me.GroupBoxEX1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 19)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "チャネル名称："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(323, 19)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.ReadOnly = True
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(22, 20)
        Me.CHANNEL_CODE_T.TabIndex = 136
        Me.CHANNEL_CODE_T.Visible = False
        '
        'CHANNEL_NAME_L
        '
        Me.CHANNEL_NAME_L.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHANNEL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_L.FormattingEnabled = True
        Me.CHANNEL_NAME_L.Location = New System.Drawing.Point(128, 18)
        Me.CHANNEL_NAME_L.Name = "CHANNEL_NAME_L"
        Me.CHANNEL_NAME_L.Size = New System.Drawing.Size(235, 21)
        Me.CHANNEL_NAME_L.TabIndex = 1
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DATA_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.DATA_V.Location = New System.Drawing.Point(19, 169)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DATA_V.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(608, 148)
        Me.DATA_V.TabIndex = 75
        Me.DATA_V.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "部門名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BUMON_CODE_T
        '
        Me.BUMON_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BUMON_CODE_T.Location = New System.Drawing.Point(301, 136)
        Me.BUMON_CODE_T.Name = "BUMON_CODE_T"
        Me.BUMON_CODE_T.ReadOnly = True
        Me.BUMON_CODE_T.Size = New System.Drawing.Size(22, 20)
        Me.BUMON_CODE_T.TabIndex = 139
        Me.BUMON_CODE_T.Visible = False
        '
        'BUMON_NAME_L
        '
        Me.BUMON_NAME_L.BackColor = System.Drawing.Color.LemonChiffon
        Me.BUMON_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_NAME_L.FormattingEnabled = True
        Me.BUMON_NAME_L.Location = New System.Drawing.Point(107, 135)
        Me.BUMON_NAME_L.Name = "BUMON_NAME_L"
        Me.BUMON_NAME_L.Size = New System.Drawing.Size(235, 21)
        Me.BUMON_NAME_L.TabIndex = 138
        '
        'BUMON_ADD_B
        '
        Me.BUMON_ADD_B.ColorBottom = System.Drawing.Color.Tan
        Me.BUMON_ADD_B.ColorLight = System.Drawing.Color.Wheat
        Me.BUMON_ADD_B.ColorTop = System.Drawing.Color.Linen
        Me.BUMON_ADD_B.LightEffect = False
        Me.BUMON_ADD_B.Location = New System.Drawing.Point(352, 129)
        Me.BUMON_ADD_B.Name = "BUMON_ADD_B"
        Me.BUMON_ADD_B.Size = New System.Drawing.Size(124, 34)
        Me.BUMON_ADD_B.TabIndex = 141
        Me.BUMON_ADD_B.TextButton = "追　加"
        '
        'BUMON_DEL_B
        '
        Me.BUMON_DEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.BUMON_DEL_B.ColorLight = System.Drawing.Color.Wheat
        Me.BUMON_DEL_B.ColorTop = System.Drawing.Color.Linen
        Me.BUMON_DEL_B.LightEffect = False
        Me.BUMON_DEL_B.Location = New System.Drawing.Point(482, 130)
        Me.BUMON_DEL_B.Name = "BUMON_DEL_B"
        Me.BUMON_DEL_B.Size = New System.Drawing.Size(124, 34)
        Me.BUMON_DEL_B.TabIndex = 142
        Me.BUMON_DEL_B.TextButton = "削　除"
        '
        'fRoomMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(645, 394)
        Me.Controls.Add(Me.BUMON_DEL_B)
        Me.Controls.Add(Me.BUMON_ADD_B)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BUMON_CODE_T)
        Me.Controls.Add(Me.BUMON_NAME_L)
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
        Me.Name = "fRoomMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ルームマスタ管理"
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
    Friend WithEvents ROOM_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents ROOM_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEX1 As Dotnetrix.Controls.GroupBoxEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BUMON_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents BUMON_ADD_B As Softgroup.NetButton.NetButton
    Friend WithEvents BUMON_DEL_B As Softgroup.NetButton.NetButton

End Class
