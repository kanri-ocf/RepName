<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointADD
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CURRENT_POINT_CNT_T = New System.Windows.Forms.TextBox
        Me.ADD_POINT_CNT_T = New System.Windows.Forms.TextBox
        Me.AFTER_POINT_CNT_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "【現在のポイント数】"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "【付与ポイント数】"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(392, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "【処理後ポイント数】"
        '
        'CURRENT_POINT_CNT_T
        '
        Me.CURRENT_POINT_CNT_T.BackColor = System.Drawing.Color.PaleGreen
        Me.CURRENT_POINT_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CURRENT_POINT_CNT_T.Location = New System.Drawing.Point(49, 112)
        Me.CURRENT_POINT_CNT_T.Name = "CURRENT_POINT_CNT_T"
        Me.CURRENT_POINT_CNT_T.ReadOnly = True
        Me.CURRENT_POINT_CNT_T.Size = New System.Drawing.Size(155, 26)
        Me.CURRENT_POINT_CNT_T.TabIndex = 3
        Me.CURRENT_POINT_CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ADD_POINT_CNT_T
        '
        Me.ADD_POINT_CNT_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ADD_POINT_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADD_POINT_CNT_T.Location = New System.Drawing.Point(250, 112)
        Me.ADD_POINT_CNT_T.Name = "ADD_POINT_CNT_T"
        Me.ADD_POINT_CNT_T.Size = New System.Drawing.Size(100, 26)
        Me.ADD_POINT_CNT_T.TabIndex = 4
        Me.ADD_POINT_CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AFTER_POINT_CNT_T
        '
        Me.AFTER_POINT_CNT_T.BackColor = System.Drawing.Color.PaleGreen
        Me.AFTER_POINT_CNT_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AFTER_POINT_CNT_T.Location = New System.Drawing.Point(395, 112)
        Me.AFTER_POINT_CNT_T.Name = "AFTER_POINT_CNT_T"
        Me.AFTER_POINT_CNT_T.ReadOnly = True
        Me.AFTER_POINT_CNT_T.Size = New System.Drawing.Size(151, 26)
        Me.AFTER_POINT_CNT_T.TabIndex = 5
        Me.AFTER_POINT_CNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(210, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "＋"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(356, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 24)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "＝"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMMIT_B.Location = New System.Drawing.Point(156, 187)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(297, 60)
        Me.COMMIT_B.TabIndex = 8
        Me.COMMIT_B.TextButton = "処　理　実　行"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(139, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(314, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "ポイント付与事由を入力の上、処理を行って下さい。"
        '
        'fPointADD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(595, 273)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AFTER_POINT_CNT_T)
        Me.Controls.Add(Me.ADD_POINT_CNT_T)
        Me.Controls.Add(Me.CURRENT_POINT_CNT_T)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPointADD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fPointAdd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CURRENT_POINT_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents ADD_POINT_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents AFTER_POINT_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
