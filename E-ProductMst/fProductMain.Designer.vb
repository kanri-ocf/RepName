<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fProductMain
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
        Me.PRODUCT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NETSTATUS_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RUTERN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PRODUCT_B
        '
        Me.PRODUCT_B.ColorBottom = System.Drawing.Color.Tan
        Me.PRODUCT_B.Location = New System.Drawing.Point(49, 88)
        Me.PRODUCT_B.Name = "PRODUCT_B"
        Me.PRODUCT_B.Size = New System.Drawing.Size(211, 53)
        Me.PRODUCT_B.TabIndex = 1
        Me.PRODUCT_B.TextButton = "商品情報登録／編集"
        '
        'NETSTATUS_B
        '
        Me.NETSTATUS_B.ColorBottom = System.Drawing.Color.Tan
        Me.NETSTATUS_B.Location = New System.Drawing.Point(48, 145)
        Me.NETSTATUS_B.Name = "NETSTATUS_B"
        Me.NETSTATUS_B.Size = New System.Drawing.Size(211, 53)
        Me.NETSTATUS_B.TabIndex = 2
        Me.NETSTATUS_B.TextButton = "商品ステータス更新"
        '
        'RUTERN_B
        '
        Me.RUTERN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RUTERN_B.Location = New System.Drawing.Point(49, 243)
        Me.RUTERN_B.Name = "RUTERN_B"
        Me.RUTERN_B.Size = New System.Drawing.Size(211, 53)
        Me.RUTERN_B.TabIndex = 3
        Me.RUTERN_B.TextButton = "終　　　了"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "処理内容選択して下さい。"
        '
        'fProductMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(306, 343)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RUTERN_B)
        Me.Controls.Add(Me.NETSTATUS_B)
        Me.Controls.Add(Me.PRODUCT_B)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fProductMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品マスタサブメニュー"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PRODUCT_B As Softgroup.NetButton.NetButton
    Friend WithEvents NETSTATUS_B As Softgroup.NetButton.NetButton
    Friend WithEvents RUTERN_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
