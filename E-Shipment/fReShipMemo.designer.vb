<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReShipMemo
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
        Me.RESHIP_MEMO_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.YES_B = New Softgroup.NetButton.NetButton
        Me.NO_B = New Softgroup.NetButton.NetButton
        Me.SuspendLayout()
        '
        'RESHIP_MEMO_T
        '
        Me.RESHIP_MEMO_T.Location = New System.Drawing.Point(13, 36)
        Me.RESHIP_MEMO_T.Multiline = True
        Me.RESHIP_MEMO_T.Name = "RESHIP_MEMO_T"
        Me.RESHIP_MEMO_T.Size = New System.Drawing.Size(382, 83)
        Me.RESHIP_MEMO_T.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "再出荷の事由を入力して下さい"
        '
        'YES_B
        '
        Me.YES_B.ColorBottom = System.Drawing.Color.Tan
        Me.YES_B.ColorDisabled = System.Drawing.Color.DimGray
        Me.YES_B.ColorLight = System.Drawing.SystemColors.HighlightText
        Me.YES_B.ColorText = System.Drawing.SystemColors.ControlText
        Me.YES_B.ColorTop = System.Drawing.SystemColors.ControlLightLight
        Me.YES_B.Location = New System.Drawing.Point(225, 129)
        Me.YES_B.Name = "YES_B"
        Me.YES_B.Size = New System.Drawing.Size(84, 40)
        Me.YES_B.TabIndex = 2
        Me.YES_B.TextButton = "登録"
        '
        'NO_B
        '
        Me.NO_B.ColorBottom = System.Drawing.Color.Tan
        Me.NO_B.ColorDisabled = System.Drawing.Color.DimGray
        Me.NO_B.ColorLight = System.Drawing.SystemColors.HighlightText
        Me.NO_B.ColorText = System.Drawing.SystemColors.ControlText
        Me.NO_B.ColorTop = System.Drawing.SystemColors.ControlLightLight
        Me.NO_B.Location = New System.Drawing.Point(117, 129)
        Me.NO_B.Name = "NO_B"
        Me.NO_B.Size = New System.Drawing.Size(84, 40)
        Me.NO_B.TabIndex = 3
        Me.NO_B.TextButton = "戻る"
        '
        'fReShipMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(407, 181)
        Me.Controls.Add(Me.NO_B)
        Me.Controls.Add(Me.YES_B)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RESHIP_MEMO_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fReShipMemo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RESHIP_MEMO_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents YES_B As Softgroup.NetButton.NetButton
    Friend WithEvents NO_B As Softgroup.NetButton.NetButton
End Class
