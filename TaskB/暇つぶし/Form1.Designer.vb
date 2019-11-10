<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.B_1 = New System.Windows.Forms.TextBox()
        Me.B_2 = New System.Windows.Forms.TextBox()
        Me.B_3 = New System.Windows.Forms.TextBox()
        Me.B_4 = New System.Windows.Forms.TextBox()
        Me.A_1 = New System.Windows.Forms.TextBox()
        Me.A_2 = New System.Windows.Forms.TextBox()
        Me.A_3 = New System.Windows.Forms.TextBox()
        Me.A_4 = New System.Windows.Forms.TextBox()
        Me.A_5 = New System.Windows.Forms.TextBox()
        Me.B_5 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(88, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 55)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "バブルソート"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "出力前"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ソート後"
        '
        'B_1
        '
        Me.B_1.Location = New System.Drawing.Point(46, 92)
        Me.B_1.MaxLength = 3
        Me.B_1.Name = "B_1"
        Me.B_1.Size = New System.Drawing.Size(100, 19)
        Me.B_1.TabIndex = 1
        '
        'B_2
        '
        Me.B_2.Location = New System.Drawing.Point(165, 92)
        Me.B_2.MaxLength = 3
        Me.B_2.Name = "B_2"
        Me.B_2.Size = New System.Drawing.Size(100, 19)
        Me.B_2.TabIndex = 2
        '
        'B_3
        '
        Me.B_3.Location = New System.Drawing.Point(289, 92)
        Me.B_3.MaxLength = 3
        Me.B_3.Name = "B_3"
        Me.B_3.Size = New System.Drawing.Size(100, 19)
        Me.B_3.TabIndex = 3
        '
        'B_4
        '
        Me.B_4.Location = New System.Drawing.Point(408, 92)
        Me.B_4.MaxLength = 3
        Me.B_4.Name = "B_4"
        Me.B_4.Size = New System.Drawing.Size(100, 19)
        Me.B_4.TabIndex = 4
        '
        'A_1
        '
        Me.A_1.Location = New System.Drawing.Point(46, 263)
        Me.A_1.Name = "A_1"
        Me.A_1.ReadOnly = True
        Me.A_1.Size = New System.Drawing.Size(100, 19)
        Me.A_1.TabIndex = 7
        Me.A_1.TabStop = False
        '
        'A_2
        '
        Me.A_2.Location = New System.Drawing.Point(165, 263)
        Me.A_2.Name = "A_2"
        Me.A_2.ReadOnly = True
        Me.A_2.Size = New System.Drawing.Size(100, 19)
        Me.A_2.TabIndex = 11
        Me.A_2.TabStop = False
        '
        'A_3
        '
        Me.A_3.Location = New System.Drawing.Point(289, 262)
        Me.A_3.Name = "A_3"
        Me.A_3.ReadOnly = True
        Me.A_3.Size = New System.Drawing.Size(100, 19)
        Me.A_3.TabIndex = 12
        Me.A_3.TabStop = False
        '
        'A_4
        '
        Me.A_4.Location = New System.Drawing.Point(408, 262)
        Me.A_4.Name = "A_4"
        Me.A_4.ReadOnly = True
        Me.A_4.Size = New System.Drawing.Size(100, 19)
        Me.A_4.TabIndex = 13
        Me.A_4.TabStop = False
        '
        'A_5
        '
        Me.A_5.Location = New System.Drawing.Point(546, 262)
        Me.A_5.Name = "A_5"
        Me.A_5.ReadOnly = True
        Me.A_5.Size = New System.Drawing.Size(100, 19)
        Me.A_5.TabIndex = 14
        Me.A_5.TabStop = False
        '
        'B_5
        '
        Me.B_5.Location = New System.Drawing.Point(546, 91)
        Me.B_5.MaxLength = 3
        Me.B_5.Name = "B_5"
        Me.B_5.Size = New System.Drawing.Size(100, 19)
        Me.B_5.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.Location = New System.Drawing.Point(408, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 55)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "クイックソート"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 489)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.B_5)
        Me.Controls.Add(Me.A_5)
        Me.Controls.Add(Me.A_4)
        Me.Controls.Add(Me.A_3)
        Me.Controls.Add(Me.A_2)
        Me.Controls.Add(Me.A_1)
        Me.Controls.Add(Me.B_4)
        Me.Controls.Add(Me.B_3)
        Me.Controls.Add(Me.B_2)
        Me.Controls.Add(Me.B_1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_1 As System.Windows.Forms.TextBox
    Friend WithEvents B_2 As System.Windows.Forms.TextBox
    Friend WithEvents B_3 As System.Windows.Forms.TextBox
    Friend WithEvents B_4 As System.Windows.Forms.TextBox
    Friend WithEvents A_1 As System.Windows.Forms.TextBox
    Friend WithEvents A_2 As System.Windows.Forms.TextBox
    Friend WithEvents A_3 As System.Windows.Forms.TextBox
    Friend WithEvents A_4 As System.Windows.Forms.TextBox
    Friend WithEvents A_5 As System.Windows.Forms.TextBox
    Friend WithEvents B_5 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
