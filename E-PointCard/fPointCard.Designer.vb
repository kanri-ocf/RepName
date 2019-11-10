<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointCard
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
        Me.POINT_CARD_PRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POINT_MEMBER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POINT_CRD_LOSS_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'POINT_CARD_PRINT_B
        '
        Me.POINT_CARD_PRINT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.POINT_CARD_PRINT_B.Location = New System.Drawing.Point(61, 101)
        Me.POINT_CARD_PRINT_B.Name = "POINT_CARD_PRINT_B"
        Me.POINT_CARD_PRINT_B.Size = New System.Drawing.Size(263, 53)
        Me.POINT_CARD_PRINT_B.TabIndex = 2
        Me.POINT_CARD_PRINT_B.TextButton = "ポイントカード発行"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(143, 245)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 46)
        Me.RETURN_B.TabIndex = 3
        Me.RETURN_B.TextButton = "終  了"
        '
        'POINT_MEMBER_B
        '
        Me.POINT_MEMBER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.POINT_MEMBER_B.Location = New System.Drawing.Point(61, 30)
        Me.POINT_MEMBER_B.Name = "POINT_MEMBER_B"
        Me.POINT_MEMBER_B.Size = New System.Drawing.Size(263, 53)
        Me.POINT_MEMBER_B.TabIndex = 1
        Me.POINT_MEMBER_B.TextButton = "ポイント会員登録/編集"
        '
        'POINT_CRD_LOSS_B
        '
        Me.POINT_CRD_LOSS_B.ColorBottom = System.Drawing.Color.Wheat
        Me.POINT_CRD_LOSS_B.Location = New System.Drawing.Point(61, 175)
        Me.POINT_CRD_LOSS_B.Name = "POINT_CRD_LOSS_B"
        Me.POINT_CRD_LOSS_B.Size = New System.Drawing.Size(263, 53)
        Me.POINT_CRD_LOSS_B.TabIndex = 4
        Me.POINT_CRD_LOSS_B.TextButton = "ポイントカード紛失・再発行"
        '
        'fPointCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(381, 311)
        Me.Controls.Add(Me.POINT_CRD_LOSS_B)
        Me.Controls.Add(Me.POINT_CARD_PRINT_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.POINT_MEMBER_B)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPointCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ポイント会員管理"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents POINT_CARD_PRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents POINT_MEMBER_B As Softgroup.NetButton.NetButton
    Friend WithEvents POINT_CRD_LOSS_B As Softgroup.NetButton.NetButton
End Class
