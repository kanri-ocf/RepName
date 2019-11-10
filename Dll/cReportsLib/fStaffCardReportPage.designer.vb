<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fStaffCardReportPage
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
        Me.MESSAGE_1_T = New System.Windows.Forms.Label()
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DEVICE_SET_G = New System.Windows.Forms.GroupBox()
        Me.Card_Printer_R = New System.Windows.Forms.RadioButton()
        Me.A4_Printer_R = New System.Windows.Forms.RadioButton()
        Me.DEVICE_SET_G.SuspendLayout()
        Me.SuspendLayout()
        '
        'MESSAGE_1_T
        '
        Me.MESSAGE_1_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE_1_T.Location = New System.Drawing.Point(45, 13)
        Me.MESSAGE_1_T.Name = "MESSAGE_1_T"
        Me.MESSAGE_1_T.Size = New System.Drawing.Size(463, 67)
        Me.MESSAGE_1_T.TabIndex = 15
        Me.MESSAGE_1_T.Text = "スタッフカード出力を行います。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "出力先のプリンターデバイスを指定して下さい。"
        Me.MESSAGE_1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(316, 152)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(123, 43)
        Me.OK_B.TabIndex = 4
        Me.OK_B.TextButton = "印刷実行"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.CANCEL_B.Location = New System.Drawing.Point(140, 152)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(123, 43)
        Me.CANCEL_B.TabIndex = 3
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'DEVICE_SET_G
        '
        Me.DEVICE_SET_G.Controls.Add(Me.Card_Printer_R)
        Me.DEVICE_SET_G.Controls.Add(Me.A4_Printer_R)
        Me.DEVICE_SET_G.Location = New System.Drawing.Point(73, 101)
        Me.DEVICE_SET_G.Name = "DEVICE_SET_G"
        Me.DEVICE_SET_G.Size = New System.Drawing.Size(414, 31)
        Me.DEVICE_SET_G.TabIndex = 30
        Me.DEVICE_SET_G.TabStop = False
        Me.DEVICE_SET_G.Text = "【出力デバイス】"
        '
        'Card_Printer_R
        '
        Me.Card_Printer_R.AutoSize = True
        Me.Card_Printer_R.Location = New System.Drawing.Point(207, 9)
        Me.Card_Printer_R.Name = "Card_Printer_R"
        Me.Card_Printer_R.Size = New System.Drawing.Size(94, 16)
        Me.Card_Printer_R.TabIndex = 1
        Me.Card_Printer_R.Text = "カードプリンター"
        Me.Card_Printer_R.UseVisualStyleBackColor = True
        '
        'A4_Printer_R
        '
        Me.A4_Printer_R.AutoSize = True
        Me.A4_Printer_R.Checked = True
        Me.A4_Printer_R.Location = New System.Drawing.Point(93, 9)
        Me.A4_Printer_R.Name = "A4_Printer_R"
        Me.A4_Printer_R.Size = New System.Drawing.Size(80, 16)
        Me.A4_Printer_R.TabIndex = 0
        Me.A4_Printer_R.TabStop = True
        Me.A4_Printer_R.Text = "A4プリンター"
        Me.A4_Printer_R.UseVisualStyleBackColor = True
        '
        'fStaffCardReportPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(557, 232)
        Me.Controls.Add(Me.DEVICE_SET_G)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.MESSAGE_1_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fStaffCardReportPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "スタッフカード印刷指定"
        Me.DEVICE_SET_G.ResumeLayout(False)
        Me.DEVICE_SET_G.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OrderReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MESSAGE_1_T As System.Windows.Forms.Label
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
    Friend WithEvents DEVICE_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents A4_Printer_R As System.Windows.Forms.RadioButton
    Friend WithEvents Card_Printer_R As System.Windows.Forms.RadioButton
End Class
