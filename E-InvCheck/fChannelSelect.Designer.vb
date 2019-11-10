<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fChannelSelect
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
        Me.CHANNEL_NAME_L = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RETURN_B = New System.Windows.Forms.Button
        Me.COMMIT_B = New System.Windows.Forms.Button
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'CHANNEL_NAME_L
        '
        Me.CHANNEL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_L.FormattingEnabled = True
        Me.CHANNEL_NAME_L.Location = New System.Drawing.Point(108, 71)
        Me.CHANNEL_NAME_L.Name = "CHANNEL_NAME_L"
        Me.CHANNEL_NAME_L.Size = New System.Drawing.Size(209, 24)
        Me.CHANNEL_NAME_L.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "棚卸を行うチャネルを選択して下さい。"
        '
        'RETURN_B
        '
        Me.RETURN_B.Location = New System.Drawing.Point(89, 113)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(107, 38)
        Me.RETURN_B.TabIndex = 2
        Me.RETURN_B.Text = "戻る"
        Me.RETURN_B.UseVisualStyleBackColor = True
        '
        'COMMIT_B
        '
        Me.COMMIT_B.Location = New System.Drawing.Point(241, 113)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(107, 38)
        Me.COMMIT_B.TabIndex = 3
        Me.COMMIT_B.Text = "決定"
        Me.COMMIT_B.UseVisualStyleBackColor = True
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.Color.Silver
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(324, 71)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(24, 19)
        Me.CHANNEL_CODE_T.TabIndex = 4
        Me.CHANNEL_CODE_T.Visible = False
        '
        'fChannelSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(418, 172)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CHANNEL_NAME_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fChannelSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fChannelSelect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CHANNEL_NAME_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RETURN_B As System.Windows.Forms.Button
    Friend WithEvents COMMIT_B As System.Windows.Forms.Button
    Public WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
End Class
