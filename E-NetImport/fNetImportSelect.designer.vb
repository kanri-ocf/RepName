<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNetImportSelect
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.PATH_1_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PATH_2_T = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.FILE1_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.FILE2_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "注文データ："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PATH_1_T
        '
        Me.PATH_1_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PATH_1_T.Location = New System.Drawing.Point(140, 56)
        Me.PATH_1_T.Name = "PATH_1_T"
        Me.PATH_1_T.Size = New System.Drawing.Size(320, 22)
        Me.PATH_1_T.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "注文明細データ："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PATH_2_T
        '
        Me.PATH_2_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PATH_2_T.Location = New System.Drawing.Point(140, 88)
        Me.PATH_2_T.Name = "PATH_2_T"
        Me.PATH_2_T.Size = New System.Drawing.Size(320, 22)
        Me.PATH_2_T.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "チャネル名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.Location = New System.Drawing.Point(140, 24)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(249, 23)
        Me.CHANNEL_L.TabIndex = 1
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Wheat
        Me.OK_B.Location = New System.Drawing.Point(158, 132)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(122, 40)
        Me.OK_B.TabIndex = 6
        Me.OK_B.TextButton = "OK"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Wheat
        Me.CANCEL_B.Location = New System.Drawing.Point(315, 132)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(122, 40)
        Me.CANCEL_B.TabIndex = 7
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'FILE1_B
        '
        Me.FILE1_B.ColorBottom = System.Drawing.Color.Wheat
        Me.FILE1_B.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FILE1_B.Location = New System.Drawing.Point(466, 52)
        Me.FILE1_B.Margin = New System.Windows.Forms.Padding(1)
        Me.FILE1_B.Name = "FILE1_B"
        Me.FILE1_B.Size = New System.Drawing.Size(65, 28)
        Me.FILE1_B.TabIndex = 3
        Me.FILE1_B.TextButton = "参照"
        '
        'FILE2_B
        '
        Me.FILE2_B.ColorBottom = System.Drawing.Color.Wheat
        Me.FILE2_B.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FILE2_B.Location = New System.Drawing.Point(466, 85)
        Me.FILE2_B.Margin = New System.Windows.Forms.Padding(1)
        Me.FILE2_B.Name = "FILE2_B"
        Me.FILE2_B.Size = New System.Drawing.Size(65, 28)
        Me.FILE2_B.TabIndex = 5
        Me.FILE2_B.TextButton = "参照"
        '
        'fNetImportSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(561, 196)
        Me.Controls.Add(Me.FILE2_B)
        Me.Controls.Add(Me.FILE1_B)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.PATH_2_T)
        Me.Controls.Add(Me.PATH_1_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fNetImportSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PATH_1_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PATH_2_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
    Friend WithEvents FILE1_B As Softgroup.NetButton.NetButton
    Friend WithEvents FILE2_B As Softgroup.NetButton.NetButton
End Class
