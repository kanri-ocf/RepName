<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRoomMst
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
        Me.DATA_V = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.S_ROOM_CODE_T = New System.Windows.Forms.TextBox()
        Me.S_ROOM_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NEW_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.S_CHANNEL_NAME_L = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.S_CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DATA_V.Location = New System.Drawing.Point(18, 99)
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
        Me.DATA_V.Size = New System.Drawing.Size(603, 187)
        Me.DATA_V.TabIndex = 4
        Me.DATA_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(25, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "ルームコード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'S_ROOM_CODE_T
        '
        Me.S_ROOM_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_ROOM_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.S_ROOM_CODE_T.Location = New System.Drawing.Point(128, 18)
        Me.S_ROOM_CODE_T.Name = "S_ROOM_CODE_T"
        Me.S_ROOM_CODE_T.Size = New System.Drawing.Size(163, 20)
        Me.S_ROOM_CODE_T.TabIndex = 0
        '
        'S_ROOM_NAME_T
        '
        Me.S_ROOM_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_ROOM_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.S_ROOM_NAME_T.Location = New System.Drawing.Point(128, 41)
        Me.S_ROOM_NAME_T.Name = "S_ROOM_NAME_T"
        Me.S_ROOM_NAME_T.Size = New System.Drawing.Size(351, 20)
        Me.S_ROOM_NAME_T.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "ルーム名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(80, 320)
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
        Me.Label1.Location = New System.Drawing.Point(25, 320)
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
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(185, 320)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(194, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(501, 28)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(120, 56)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "検　索"
        '
        'NEW_B
        '
        Me.NEW_B.ColorBottom = System.Drawing.Color.Tan
        Me.NEW_B.Location = New System.Drawing.Point(397, 306)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(109, 48)
        Me.NEW_B.TabIndex = 5
        Me.NEW_B.TextButton = "新規登録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(512, 306)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.TextButton = "終　了"
        '
        'S_CHANNEL_NAME_L
        '
        Me.S_CHANNEL_NAME_L.BackColor = System.Drawing.Color.White
        Me.S_CHANNEL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_CHANNEL_NAME_L.FormattingEnabled = True
        Me.S_CHANNEL_NAME_L.Location = New System.Drawing.Point(128, 64)
        Me.S_CHANNEL_NAME_L.Name = "S_CHANNEL_NAME_L"
        Me.S_CHANNEL_NAME_L.Size = New System.Drawing.Size(235, 21)
        Me.S_CHANNEL_NAME_L.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(25, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 19)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "チャネル名称"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'S_CHANNEL_CODE_T
        '
        Me.S_CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.S_CHANNEL_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.S_CHANNEL_CODE_T.Location = New System.Drawing.Point(369, 65)
        Me.S_CHANNEL_CODE_T.Name = "S_CHANNEL_CODE_T"
        Me.S_CHANNEL_CODE_T.ReadOnly = True
        Me.S_CHANNEL_CODE_T.Size = New System.Drawing.Size(22, 20)
        Me.S_CHANNEL_CODE_T.TabIndex = 133
        Me.S_CHANNEL_CODE_T.Visible = False
        '
        'fRoomMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(639, 366)
        Me.Controls.Add(Me.S_CHANNEL_CODE_T)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.S_CHANNEL_NAME_L)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.S_ROOM_NAME_T)
        Me.Controls.Add(Me.S_ROOM_CODE_T)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DATA_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fRoomMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ルームマスタ検索画面"
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents S_ROOM_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents S_ROOM_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents NEW_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents S_CHANNEL_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents S_CHANNEL_CODE_T As System.Windows.Forms.TextBox

End Class
