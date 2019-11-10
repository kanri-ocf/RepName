<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMessage
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
        Me.MESSAGE1_L = New System.Windows.Forms.Label()
        Me.MESSAGE2_L = New System.Windows.Forms.Label()
        Me.MESSAGE3_L = New System.Windows.Forms.Label()
        Me.MESSAGE4_L = New System.Windows.Forms.RichTextBox()
        Me.NO_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.YES_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.IIE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.HI_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'MESSAGE1_L
        '
        Me.MESSAGE1_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE1_L.Location = New System.Drawing.Point(39, 17)
        Me.MESSAGE1_L.Name = "MESSAGE1_L"
        Me.MESSAGE1_L.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE1_L.TabIndex = 20
        Me.MESSAGE1_L.Text = "メッセージ1"
        Me.MESSAGE1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MESSAGE2_L
        '
        Me.MESSAGE2_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE2_L.Location = New System.Drawing.Point(39, 52)
        Me.MESSAGE2_L.Name = "MESSAGE2_L"
        Me.MESSAGE2_L.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE2_L.TabIndex = 21
        Me.MESSAGE2_L.Text = "メッセージ2"
        Me.MESSAGE2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MESSAGE3_L
        '
        Me.MESSAGE3_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE3_L.Location = New System.Drawing.Point(40, 84)
        Me.MESSAGE3_L.Name = "MESSAGE3_L"
        Me.MESSAGE3_L.Size = New System.Drawing.Size(335, 29)
        Me.MESSAGE3_L.TabIndex = 22
        Me.MESSAGE3_L.Text = "メッセージ3"
        Me.MESSAGE3_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MESSAGE4_L
        '
        Me.MESSAGE4_L.BackColor = System.Drawing.Color.Tan
        Me.MESSAGE4_L.Location = New System.Drawing.Point(15, 52)
        Me.MESSAGE4_L.Name = "MESSAGE4_L"
        Me.MESSAGE4_L.ReadOnly = True
        Me.MESSAGE4_L.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.MESSAGE4_L.Size = New System.Drawing.Size(380, 67)
        Me.MESSAGE4_L.TabIndex = 7
        Me.MESSAGE4_L.TabStop = False
        Me.MESSAGE4_L.Text = ""
        '
        'NO_B
        '
        Me.NO_B.ColorBottom = System.Drawing.Color.Tan
        Me.NO_B.LightEffect = False
        Me.NO_B.Location = New System.Drawing.Point(217, 125)
        Me.NO_B.Name = "NO_B"
        Me.NO_B.Size = New System.Drawing.Size(84, 40)
        Me.NO_B.TabIndex = 3
        Me.NO_B.TabStop = False
        Me.NO_B.TextButton = "NO"
        '
        'YES_B
        '
        Me.YES_B.ColorBottom = System.Drawing.Color.Tan
        Me.YES_B.Location = New System.Drawing.Point(113, 125)
        Me.YES_B.Name = "YES_B"
        Me.YES_B.Size = New System.Drawing.Size(84, 40)
        Me.YES_B.TabIndex = 2
        Me.YES_B.TabStop = False
        Me.YES_B.TextButton = "YES"
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.LightEffect = False
        Me.OK_B.Location = New System.Drawing.Point(148, 125)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(117, 40)
        Me.OK_B.TabIndex = 1
        Me.OK_B.TabStop = False
        Me.OK_B.TextButton = "OK"
        '
        'IIE_B
        '
        Me.IIE_B.ColorBottom = System.Drawing.Color.Tan
        Me.IIE_B.LightEffect = False
        Me.IIE_B.Location = New System.Drawing.Point(158, 125)
        Me.IIE_B.Name = "IIE_B"
        Me.IIE_B.Size = New System.Drawing.Size(84, 40)
        Me.IIE_B.TabIndex = 24
        Me.IIE_B.TabStop = False
        Me.IIE_B.TextButton = "いいえ"
        '
        'HI_B
        '
        Me.HI_B.ColorBottom = System.Drawing.Color.Tan
        Me.HI_B.Location = New System.Drawing.Point(54, 125)
        Me.HI_B.Name = "HI_B"
        Me.HI_B.Size = New System.Drawing.Size(84, 40)
        Me.HI_B.TabIndex = 23
        Me.HI_B.TabStop = False
        Me.HI_B.TextButton = "はい"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.CANCEL_B.LightEffect = False
        Me.CANCEL_B.Location = New System.Drawing.Point(271, 125)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(84, 40)
        Me.CANCEL_B.TabIndex = 26
        Me.CANCEL_B.TabStop = False
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'fMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(407, 181)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.IIE_B)
        Me.Controls.Add(Me.HI_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.NO_B)
        Me.Controls.Add(Me.YES_B)
        Me.Controls.Add(Me.MESSAGE4_L)
        Me.Controls.Add(Me.MESSAGE3_L)
        Me.Controls.Add(Me.MESSAGE2_L)
        Me.Controls.Add(Me.MESSAGE1_L)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fMessage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メッセージ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MESSAGE1_L As System.Windows.Forms.Label
    Friend WithEvents MESSAGE2_L As System.Windows.Forms.Label
    Friend WithEvents MESSAGE3_L As System.Windows.Forms.Label
    Friend WithEvents MESSAGE4_L As System.Windows.Forms.RichTextBox
    Friend WithEvents NO_B As Softgroup.NetButton.NetButton
    Friend WithEvents YES_B As Softgroup.NetButton.NetButton
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents IIE_B As Softgroup.NetButton.NetButton
    Friend WithEvents HI_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
End Class
