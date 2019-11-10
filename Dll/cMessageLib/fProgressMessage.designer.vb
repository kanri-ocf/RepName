<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProgressMessage
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
        Me.MESSAGE1_L = New System.Windows.Forms.Label
        Me.MESSAGE2_L = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'MESSAGE1_L
        '
        Me.MESSAGE1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE1_L.Location = New System.Drawing.Point(39, 20)
        Me.MESSAGE1_L.Name = "MESSAGE1_L"
        Me.MESSAGE1_L.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE1_L.TabIndex = 0
        Me.MESSAGE1_L.Text = "メッセージ"
        Me.MESSAGE1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MESSAGE2_L
        '
        Me.MESSAGE2_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE2_L.Location = New System.Drawing.Point(39, 52)
        Me.MESSAGE2_L.Name = "MESSAGE2_L"
        Me.MESSAGE2_L.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE2_L.TabIndex = 1
        Me.MESSAGE2_L.Text = "メッセージ"
        Me.MESSAGE2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(40, 95)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(332, 23)
        Me.ProgressBar.TabIndex = 6
        '
        'fProgressMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(407, 143)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.MESSAGE2_L)
        Me.Controls.Add(Me.MESSAGE1_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fProgressMessage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents MESSAGE1_L As System.Windows.Forms.Label
    Public WithEvents MESSAGE2_L As System.Windows.Forms.Label
    Public WithEvents ProgressBar As System.Windows.Forms.ProgressBar
End Class
