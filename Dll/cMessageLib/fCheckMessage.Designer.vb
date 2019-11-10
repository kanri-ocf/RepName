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
        Me.MESSAGE1 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.OK_BUTTON = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MESSAGE1
        '
        Me.MESSAGE1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE1.Location = New System.Drawing.Point(35, 9)
        Me.MESSAGE1.Name = "MESSAGE1"
        Me.MESSAGE1.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE1.TabIndex = 21
        Me.MESSAGE1.Text = "メッセージ1"
        Me.MESSAGE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CheckBox1.Location = New System.Drawing.Point(38, 64)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(332, 46)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'OK_BUTTON
        '
        Me.OK_BUTTON.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OK_BUTTON.Location = New System.Drawing.Point(141, 125)
        Me.OK_BUTTON.Name = "OK_BUTTON"
        Me.OK_BUTTON.Size = New System.Drawing.Size(127, 36)
        Me.OK_BUTTON.TabIndex = 23
        Me.OK_BUTTON.Text = "OK"
        Me.OK_BUTTON.UseVisualStyleBackColor = True
        '
        'fCheckMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(399, 173)
        Me.ControlBox = False
        Me.Controls.Add(Me.OK_BUTTON)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.MESSAGE1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fCheckMessage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MESSAGE1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents OK_BUTTON As System.Windows.Forms.Button
End Class
