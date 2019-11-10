<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fStaffEntry
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
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'MESSAGE1_L
        '
        Me.MESSAGE1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE1_L.Location = New System.Drawing.Point(37, 19)
        Me.MESSAGE1_L.Name = "MESSAGE1_L"
        Me.MESSAGE1_L.Size = New System.Drawing.Size(214, 29)
        Me.MESSAGE1_L.TabIndex = 0
        Me.MESSAGE1_L.Text = "スタッフコードを入力して下さい"
        Me.MESSAGE1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(78, 57)
        Me.STAFF_CODE_T.MaxLength = 13
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(139, 22)
        Me.STAFF_CODE_T.TabIndex = 1
        Me.STAFF_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Tan
        Me.STAFF_NAME_T.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.ForeColor = System.Drawing.Color.Tan
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(78, 87)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(139, 15)
        Me.STAFF_NAME_T.TabIndex = 2
        '
        'fStaffEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(284, 114)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.MESSAGE1_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fStaffEntry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MESSAGE1_L As System.Windows.Forms.Label
    Public WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
End Class
