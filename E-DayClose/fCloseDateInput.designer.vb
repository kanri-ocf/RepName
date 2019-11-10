<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCloseDateInput
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.CLOSE_DATE_T = New System.Windows.Forms.MaskedTextBox
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "呼び出しを行う締め日を入力して下さい"
        '
        'CLOSE_DATE_T
        '
        Me.CLOSE_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLOSE_DATE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CLOSE_DATE_T.Location = New System.Drawing.Point(55, 59)
        Me.CLOSE_DATE_T.Mask = "0000 / 00 / 00"
        Me.CLOSE_DATE_T.Name = "CLOSE_DATE_T"
        Me.CLOSE_DATE_T.Size = New System.Drawing.Size(235, 31)
        Me.CLOSE_DATE_T.TabIndex = 1
        Me.CLOSE_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(181, 103)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(109, 48)
        Me.OK_B.TabIndex = 2
        Me.OK_B.TextButton = "OK"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(55, 103)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 48)
        Me.RETURN_B.TabIndex = 3
        Me.RETURN_B.TextButton = "戻る"
        '
        'fCloseDateInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(334, 163)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.CLOSE_DATE_T)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fCloseDateInput"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CLOSE_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
End Class
