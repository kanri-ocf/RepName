<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCreateTrnCode
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
        Me.ANY_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.JAN_CODE_T = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CHANNEL_C = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ANY_CODE_T
        '
        Me.ANY_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ANY_CODE_T.Location = New System.Drawing.Point(128, 30)
        Me.ANY_CODE_T.Name = "ANY_CODE_T"
        Me.ANY_CODE_T.Size = New System.Drawing.Size(156, 23)
        Me.ANY_CODE_T.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "任意番号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "JanCode："
        '
        'JAN_CODE_T
        '
        Me.JAN_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JAN_CODE_T.Location = New System.Drawing.Point(128, 99)
        Me.JAN_CODE_T.Name = "JAN_CODE_T"
        Me.JAN_CODE_T.Size = New System.Drawing.Size(156, 23)
        Me.JAN_CODE_T.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(100, 145)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 35)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "発番"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(200, 145)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 35)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "終了"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CHANNEL_C
        '
        Me.CHANNEL_C.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_C.FormattingEnabled = True
        Me.CHANNEL_C.Location = New System.Drawing.Point(128, 62)
        Me.CHANNEL_C.Name = "CHANNEL_C"
        Me.CHANNEL_C.Size = New System.Drawing.Size(156, 24)
        Me.CHANNEL_C.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "チャネル："
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(290, 63)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(21, 23)
        Me.CHANNEL_CODE_T.TabIndex = 8
        Me.CHANNEL_CODE_T.Visible = False
        '
        'fCreateTrnCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 207)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CHANNEL_C)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.JAN_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ANY_CODE_T)
        Me.Name = "fCreateTrnCode"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ANY_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents JAN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CHANNEL_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
End Class
