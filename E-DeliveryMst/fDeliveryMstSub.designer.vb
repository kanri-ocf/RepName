<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fDeliveryMstSub
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
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CLASS_VALUE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NAME_T = New System.Windows.Forms.TextBox()
        Me.ITEM_NAME_L = New System.Windows.Forms.ComboBox()
        Me.CLASS_L = New System.Windows.Forms.Label()
        Me.CODE_T = New System.Windows.Forms.TextBox()
        Me.CODE_L = New System.Windows.Forms.Label()
        Me.NAME_L = New System.Windows.Forms.Label()
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2.SuspendLayout()
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
        Me.MODE_L.Size = New System.Drawing.Size(532, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "新規"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(70, 210)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(167, 20)
        Me.STAFF_NAME_T.TabIndex = 73
        Me.STAFF_NAME_T.TabStop = False
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(70, 189)
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
        Me.Label15.Location = New System.Drawing.Point(15, 189)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "担当者"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CLASS_VALUE_T)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.NAME_T)
        Me.GroupBox2.Controls.Add(Me.ITEM_NAME_L)
        Me.GroupBox2.Controls.Add(Me.CLASS_L)
        Me.GroupBox2.Controls.Add(Me.CODE_T)
        Me.GroupBox2.Controls.Add(Me.CODE_L)
        Me.GroupBox2.Controls.Add(Me.NAME_L)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 151)
        Me.GroupBox2.TabIndex = 133
        Me.GroupBox2.TabStop = False
        '
        'CLASS_VALUE_T
        '
        Me.CLASS_VALUE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLASS_VALUE_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CLASS_VALUE_T.Location = New System.Drawing.Point(158, 109)
        Me.CLASS_VALUE_T.Name = "CLASS_VALUE_T"
        Me.CLASS_VALUE_T.Size = New System.Drawing.Size(311, 22)
        Me.CLASS_VALUE_T.TabIndex = 141
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(45, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 19)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "種別値："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NAME_T
        '
        Me.NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.NAME_T.Location = New System.Drawing.Point(158, 84)
        Me.NAME_T.Name = "NAME_T"
        Me.NAME_T.Size = New System.Drawing.Size(311, 22)
        Me.NAME_T.TabIndex = 133
        '
        'ITEM_NAME_L
        '
        Me.ITEM_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITEM_NAME_L.FormattingEnabled = True
        Me.ITEM_NAME_L.Location = New System.Drawing.Point(159, 58)
        Me.ITEM_NAME_L.Name = "ITEM_NAME_L"
        Me.ITEM_NAME_L.Size = New System.Drawing.Size(205, 23)
        Me.ITEM_NAME_L.TabIndex = 139
        '
        'CLASS_L
        '
        Me.CLASS_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLASS_L.ForeColor = System.Drawing.Color.Black
        Me.CLASS_L.Location = New System.Drawing.Point(46, 60)
        Me.CLASS_L.Name = "CLASS_L"
        Me.CLASS_L.Size = New System.Drawing.Size(109, 19)
        Me.CLASS_L.TabIndex = 138
        Me.CLASS_L.Text = "項目種別："
        Me.CLASS_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CODE_T
        '
        Me.CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CODE_T.Location = New System.Drawing.Point(160, 33)
        Me.CODE_T.Name = "CODE_T"
        Me.CODE_T.ReadOnly = True
        Me.CODE_T.Size = New System.Drawing.Size(45, 22)
        Me.CODE_T.TabIndex = 136
        Me.CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CODE_L
        '
        Me.CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CODE_L.ForeColor = System.Drawing.Color.Black
        Me.CODE_L.Location = New System.Drawing.Point(47, 34)
        Me.CODE_L.Name = "CODE_L"
        Me.CODE_L.Size = New System.Drawing.Size(109, 19)
        Me.CODE_L.TabIndex = 137
        Me.CODE_L.Text = "配送種別コード："
        Me.CODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NAME_L
        '
        Me.NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NAME_L.ForeColor = System.Drawing.Color.Black
        Me.NAME_L.Location = New System.Drawing.Point(45, 85)
        Me.NAME_L.Name = "NAME_L"
        Me.NAME_L.Size = New System.Drawing.Size(109, 19)
        Me.NAME_L.TabIndex = 134
        Me.NAME_L.Text = "種別名称："
        Me.NAME_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(453, 189)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 41)
        Me.RETURN_B.TabIndex = 136
        Me.RETURN_B.TextButton = "戻　る"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(349, 189)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 41)
        Me.COMMIT_B.TabIndex = 135
        Me.COMMIT_B.TextButton = "登　録"
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DELETE_B.Location = New System.Drawing.Point(245, 189)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(98, 41)
        Me.DELETE_B.TabIndex = 134
        Me.DELETE_B.TextButton = "削　除"
        '
        'fDeliveryMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(568, 250)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fDeliveryMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "スタッフマスタ管理"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents ITEM_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents CLASS_L As System.Windows.Forms.Label
    Friend WithEvents CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CODE_L As System.Windows.Forms.Label
    Friend WithEvents NAME_L As System.Windows.Forms.Label
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLASS_VALUE_T As System.Windows.Forms.TextBox
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
