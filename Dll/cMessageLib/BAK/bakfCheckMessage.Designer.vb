<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCheckMessage
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
        Me.MESSAGE1 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.OK_BUTTON = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'MESSAGE1
        '
        Me.MESSAGE1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE1.Location = New System.Drawing.Point(39, 17)
        Me.MESSAGE1.Name = "MESSAGE1"
        Me.MESSAGE1.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE1.TabIndex = 0
        Me.MESSAGE1.Text = "メッセージ1"
        Me.MESSAGE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(42, 62)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(335, 29)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "チェックボックス１"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'OK_BUTTON
        '
        Me.OK_BUTTON.ColorBottom = System.Drawing.Color.Tan
        Me.OK_BUTTON.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OK_BUTTON.LightEffect = False
        Me.OK_BUTTON.Location = New System.Drawing.Point(149, 107)
        Me.OK_BUTTON.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OK_BUTTON.Name = "OK_BUTTON"
        Me.OK_BUTTON.Size = New System.Drawing.Size(117, 34)
        Me.OK_BUTTON.TabIndex = 4
        Me.OK_BUTTON.TabStop = False
        Me.OK_BUTTON.TextButton = "OK"
        '
        'fCheckMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 11.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(407, 166)
        Me.Controls.Add(Me.OK_BUTTON)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.MESSAGE1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCheckMessage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fCheckMessage"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MESSAGE1 As System.Windows.Forms.Label
    Friend WithEvents OK_BUTTON As Softgroup.NetButton.NetButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
