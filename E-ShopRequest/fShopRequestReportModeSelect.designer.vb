<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShopRequestReportModeSelect
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BEFORE_TAX_R = New System.Windows.Forms.RadioButton
        Me.AFTER_TAX_R = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.COMMIT_B = New Softgroup.NetButton.NetButton
        Me.RETURN_B = New Softgroup.NetButton.NetButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BEFORE_TAX_R)
        Me.GroupBox1.Controls.Add(Me.AFTER_TAX_R)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(62, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 41)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'BEFORE_TAX_R
        '
        Me.BEFORE_TAX_R.AutoSize = True
        Me.BEFORE_TAX_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BEFORE_TAX_R.Location = New System.Drawing.Point(177, 16)
        Me.BEFORE_TAX_R.Name = "BEFORE_TAX_R"
        Me.BEFORE_TAX_R.Size = New System.Drawing.Size(66, 19)
        Me.BEFORE_TAX_R.TabIndex = 1
        Me.BEFORE_TAX_R.TabStop = True
        Me.BEFORE_TAX_R.Text = "税抜き"
        Me.BEFORE_TAX_R.UseVisualStyleBackColor = True
        '
        'AFTER_TAX_R
        '
        Me.AFTER_TAX_R.AutoSize = True
        Me.AFTER_TAX_R.Checked = True
        Me.AFTER_TAX_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AFTER_TAX_R.Location = New System.Drawing.Point(41, 16)
        Me.AFTER_TAX_R.Name = "AFTER_TAX_R"
        Me.AFTER_TAX_R.Size = New System.Drawing.Size(68, 19)
        Me.AFTER_TAX_R.TabIndex = 0
        Me.AFTER_TAX_R.TabStop = True
        Me.AFTER_TAX_R.Text = "税込み"
        Me.AFTER_TAX_R.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "伝票に印刷する、金額の明記方法を指定して下さい。"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorDisabled = System.Drawing.Color.DimGray
        Me.COMMIT_B.ColorLight = System.Drawing.SystemColors.HighlightText
        Me.COMMIT_B.ColorText = System.Drawing.SystemColors.ControlText
        Me.COMMIT_B.ColorTop = System.Drawing.SystemColors.ControlLightLight
        Me.COMMIT_B.Location = New System.Drawing.Point(239, 125)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(84, 40)
        Me.COMMIT_B.TabIndex = 4
        Me.COMMIT_B.TextButton = "選択"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.ColorDisabled = System.Drawing.Color.DimGray
        Me.RETURN_B.ColorLight = System.Drawing.SystemColors.HighlightText
        Me.RETURN_B.ColorText = System.Drawing.SystemColors.ControlText
        Me.RETURN_B.ColorTop = System.Drawing.SystemColors.ControlLightLight
        Me.RETURN_B.Location = New System.Drawing.Point(103, 125)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(84, 40)
        Me.RETURN_B.TabIndex = 3
        Me.RETURN_B.TextButton = "戻る"
        '
        'fOrderReportModeSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(407, 181)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fOrderReportModeSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BEFORE_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents AFTER_TAX_R As System.Windows.Forms.RadioButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
End Class
