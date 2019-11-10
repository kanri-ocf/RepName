<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fChannelMst
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.CHANNEL_NAME_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BUMON_CLASS_G = New System.Windows.Forms.GroupBox
        Me.CHANNEL_NET_CLASS_R = New System.Windows.Forms.RadioButton
        Me.CHANNEL_REAL_CLASS_R = New System.Windows.Forms.RadioButton
        Me.DATA_V = New System.Windows.Forms.DataGridView
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NEW_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.BUMON_CLASS_G.SuspendLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(31, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "チャネルコード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(151, 20)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.CHANNEL_CODE_T.TabIndex = 0
        '
        'CHANNEL_NAME_T
        '
        Me.CHANNEL_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CHANNEL_NAME_T.Location = New System.Drawing.Point(151, 104)
        Me.CHANNEL_NAME_T.Name = "CHANNEL_NAME_T"
        Me.CHANNEL_NAME_T.Size = New System.Drawing.Size(368, 20)
        Me.CHANNEL_NAME_T.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(31, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 18)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "チャネル名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(78, 339)
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
        Me.Label1.Location = New System.Drawing.Point(23, 339)
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
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(78, 365)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(208, 20)
        Me.STAFF_NAME_T.TabIndex = 30
        Me.STAFF_NAME_T.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 18)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "チャネル種別"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BUMON_CLASS_G
        '
        Me.BUMON_CLASS_G.Controls.Add(Me.CHANNEL_NET_CLASS_R)
        Me.BUMON_CLASS_G.Controls.Add(Me.CHANNEL_REAL_CLASS_R)
        Me.BUMON_CLASS_G.Location = New System.Drawing.Point(151, 39)
        Me.BUMON_CLASS_G.Name = "BUMON_CLASS_G"
        Me.BUMON_CLASS_G.Size = New System.Drawing.Size(169, 59)
        Me.BUMON_CLASS_G.TabIndex = 1
        Me.BUMON_CLASS_G.TabStop = False
        '
        'CHANNEL_NET_CLASS_R
        '
        Me.CHANNEL_NET_CLASS_R.AutoSize = True
        Me.CHANNEL_NET_CLASS_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NET_CLASS_R.Location = New System.Drawing.Point(17, 34)
        Me.CHANNEL_NET_CLASS_R.Name = "CHANNEL_NET_CLASS_R"
        Me.CHANNEL_NET_CLASS_R.Size = New System.Drawing.Size(133, 19)
        Me.CHANNEL_NET_CLASS_R.TabIndex = 1
        Me.CHANNEL_NET_CLASS_R.Text = "ネット販売チャネル"
        Me.CHANNEL_NET_CLASS_R.UseVisualStyleBackColor = True
        '
        'CHANNEL_REAL_CLASS_R
        '
        Me.CHANNEL_REAL_CLASS_R.AutoSize = True
        Me.CHANNEL_REAL_CLASS_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_REAL_CLASS_R.Location = New System.Drawing.Point(16, 10)
        Me.CHANNEL_REAL_CLASS_R.Name = "CHANNEL_REAL_CLASS_R"
        Me.CHANNEL_REAL_CLASS_R.Size = New System.Drawing.Size(133, 19)
        Me.CHANNEL_REAL_CLASS_R.TabIndex = 0
        Me.CHANNEL_REAL_CLASS_R.Text = "リアル店舗チャネル"
        Me.CHANNEL_REAL_CLASS_R.UseVisualStyleBackColor = True
        '
        'DATA_V
        '
        Me.DATA_V.AllowUserToAddRows = False
        Me.DATA_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.DATA_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DATA_V.ColumnHeadersHeight = 30
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DATA_V.DefaultCellStyle = DataGridViewCellStyle8
        Me.DATA_V.Location = New System.Drawing.Point(28, 136)
        Me.DATA_V.Name = "DATA_V"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DATA_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DATA_V.RowTemplate.Height = 21
        Me.DATA_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATA_V.Size = New System.Drawing.Size(491, 187)
        Me.DATA_V.TabIndex = 4
        Me.DATA_V.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEARCH_B.Location = New System.Drawing.Point(351, 20)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(168, 58)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "検　索"
        '
        'NEW_B
        '
        Me.NEW_B.ColorBottom = System.Drawing.Color.Wheat
        Me.NEW_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NEW_B.Location = New System.Drawing.Point(295, 337)
        Me.NEW_B.Name = "NEW_B"
        Me.NEW_B.Size = New System.Drawing.Size(109, 48)
        Me.NEW_B.TabIndex = 5
        Me.NEW_B.TextButton = "新規登録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RETURN_B.Location = New System.Drawing.Point(410, 337)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.TextButton = "戻　る"
        '
        'fChannelMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(553, 407)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.NEW_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.CHANNEL_NAME_T)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.BUMON_CLASS_G)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DATA_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fChannelMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "チャネルマスタ管理"
        Me.BUMON_CLASS_G.ResumeLayout(False)
        Me.BUMON_CLASS_G.PerformLayout()
        CType(Me.DATA_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BUMON_CLASS_G As System.Windows.Forms.GroupBox
    Friend WithEvents CHANNEL_NET_CLASS_R As System.Windows.Forms.RadioButton
    Friend WithEvents CHANNEL_REAL_CLASS_R As System.Windows.Forms.RadioButton
    Friend WithEvents DATA_V As System.Windows.Forms.DataGridView
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents NEW_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton

End Class
