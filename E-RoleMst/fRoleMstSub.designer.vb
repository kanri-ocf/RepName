<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRoleMstSub
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
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ROLE_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ROLE_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxEX1 = New Dotnetrix.Controls.GroupBoxEX()
        Me.GroupBoxEX1.SuspendLayout()
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
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(78, 267)
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
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(78, 241)
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
        Me.Label15.Location = New System.Drawing.Point(23, 241)
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
        Me.DELETE_B.Location = New System.Drawing.Point(285, 241)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(124, 59)
        Me.DELETE_B.TabIndex = 76
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.ColorLight = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorTop = System.Drawing.Color.Linen
        Me.COMMIT_B.LightEffect = False
        Me.COMMIT_B.Location = New System.Drawing.Point(415, 241)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(124, 59)
        Me.COMMIT_B.TabIndex = 77
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.ColorLight = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorTop = System.Drawing.Color.Linen
        Me.RETURN_B.LightEffect = False
        Me.RETURN_B.Location = New System.Drawing.Point(545, 241)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(124, 59)
        Me.RETURN_B.TabIndex = 78
        Me.RETURN_B.TextButton = "戻　る"
        '
        'ROLE_CODE_T
        '
        Me.ROLE_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ROLE_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROLE_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ROLE_CODE_T.Location = New System.Drawing.Point(259, 64)
        Me.ROLE_CODE_T.MaxLength = 8
        Me.ROLE_CODE_T.Name = "ROLE_CODE_T"
        Me.ROLE_CODE_T.Size = New System.Drawing.Size(146, 22)
        Me.ROLE_CODE_T.TabIndex = 1
        Me.ROLE_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(156, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 19)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "役割コード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ROLE_NAME_T
        '
        Me.ROLE_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ROLE_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ROLE_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ROLE_NAME_T.Location = New System.Drawing.Point(259, 104)
        Me.ROLE_NAME_T.MaxLength = 8
        Me.ROLE_NAME_T.Name = "ROLE_NAME_T"
        Me.ROLE_NAME_T.Size = New System.Drawing.Size(273, 22)
        Me.ROLE_NAME_T.TabIndex = 113
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(156, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "役割名称："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEX1
        '
        Me.GroupBoxEX1.Controls.Add(Me.Label5)
        Me.GroupBoxEX1.Controls.Add(Me.ROLE_NAME_T)
        Me.GroupBoxEX1.Controls.Add(Me.Label7)
        Me.GroupBoxEX1.Controls.Add(Me.ROLE_CODE_T)
        Me.GroupBoxEX1.Location = New System.Drawing.Point(19, 32)
        Me.GroupBoxEX1.Name = "GroupBoxEX1"
        Me.GroupBoxEX1.Size = New System.Drawing.Size(650, 203)
        Me.GroupBoxEX1.TabIndex = 74
        Me.GroupBoxEX1.TabStop = False
        '
        'fRoleMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(684, 317)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBoxEX1)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MODE_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fRoleMstSub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "役割マスタ管理"
        Me.GroupBoxEX1.ResumeLayout(False)
        Me.GroupBoxEX1.PerformLayout()
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
    Friend WithEvents ROLE_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ROLE_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEX1 As Dotnetrix.Controls.GroupBoxEX

End Class
