<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointCardReportPage
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
        Me.MESSAGE_1_T = New System.Windows.Forms.Label
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.A4_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CARD_COUNT_L = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.A4PRINTER_SET_G = New System.Windows.Forms.GroupBox
        Me.CARD_PRINTER_SET = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.CARD_COUNT_T = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.DEVICE_SET_G = New System.Windows.Forms.GroupBox
        Me.Card_Printer_R = New System.Windows.Forms.RadioButton
        Me.A4_Printer_R = New System.Windows.Forms.RadioButton
        Me.A4PRINTER_SET_G.SuspendLayout()
        Me.CARD_PRINTER_SET.SuspendLayout()
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
        Me.MESSAGE_1_T.Text = "ポイントカード出力を行うチャネル・枚数を指定して下さい。"
        Me.MESSAGE_1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.Location = New System.Drawing.Point(160, 83)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(257, 24)
        Me.CHANNEL_L.TabIndex = 1
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.Color.LightGray
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(481, 318)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(49, 19)
        Me.CHANNEL_CODE_T.TabIndex = 17
        Me.CHANNEL_CODE_T.TabStop = False
        Me.CHANNEL_CODE_T.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "チャネル："
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(312, 318)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(123, 43)
        Me.OK_B.TabIndex = 4
        Me.OK_B.TextButton = "印刷実行"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.CANCEL_B.Location = New System.Drawing.Point(136, 318)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(123, 43)
        Me.CANCEL_B.TabIndex = 3
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "発行枚数："
        '
        'A4_COUNT_T
        '
        Me.A4_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.A4_COUNT_T.Location = New System.Drawing.Point(96, 11)
        Me.A4_COUNT_T.Name = "A4_COUNT_T"
        Me.A4_COUNT_T.Size = New System.Drawing.Size(58, 23)
        Me.A4_COUNT_T.TabIndex = 2
        Me.A4_COUNT_T.Text = "1"
        Me.A4_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(10, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(392, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "※ 発行枚数は、シート（カード10枚）単位で指定して下さい。"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(160, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "シート"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "("
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(245, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = ")枚出力"
        '
        'CARD_COUNT_L
        '
        Me.CARD_COUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CARD_COUNT_L.Location = New System.Drawing.Point(215, 21)
        Me.CARD_COUNT_L.Name = "CARD_COUNT_L"
        Me.CARD_COUNT_L.Size = New System.Drawing.Size(26, 13)
        Me.CARD_COUNT_L.TabIndex = 26
        Me.CARD_COUNT_L.Text = "10"
        Me.CARD_COUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(10, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(270, 16)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "用紙はA-One(51165・51166）限定です。"
        '
        'A4PRINTER_SET_G
        '
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label2)
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label7)
        Me.A4PRINTER_SET_G.Controls.Add(Me.A4_COUNT_T)
        Me.A4PRINTER_SET_G.Controls.Add(Me.CARD_COUNT_L)
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label3)
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label6)
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label4)
        Me.A4PRINTER_SET_G.Controls.Add(Me.Label5)
        Me.A4PRINTER_SET_G.Location = New System.Drawing.Point(73, 166)
        Me.A4PRINTER_SET_G.Name = "A4PRINTER_SET_G"
        Me.A4PRINTER_SET_G.Size = New System.Drawing.Size(414, 98)
        Me.A4PRINTER_SET_G.TabIndex = 28
        Me.A4PRINTER_SET_G.TabStop = False
        '
        'CARD_PRINTER_SET
        '
        Me.CARD_PRINTER_SET.Controls.Add(Me.Label8)
        Me.CARD_PRINTER_SET.Controls.Add(Me.Label9)
        Me.CARD_PRINTER_SET.Controls.Add(Me.CARD_COUNT_T)
        Me.CARD_PRINTER_SET.Controls.Add(Me.Label13)
        Me.CARD_PRINTER_SET.Location = New System.Drawing.Point(73, 267)
        Me.CARD_PRINTER_SET.Name = "CARD_PRINTER_SET"
        Me.CARD_PRINTER_SET.Size = New System.Drawing.Size(414, 43)
        Me.CARD_PRINTER_SET.TabIndex = 29
        Me.CARD_PRINTER_SET.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "発行枚数："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(90, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 16)
        Me.Label9.TabIndex = 27
        '
        'CARD_COUNT_T
        '
        Me.CARD_COUNT_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CARD_COUNT_T.Location = New System.Drawing.Point(96, 11)
        Me.CARD_COUNT_T.Name = "CARD_COUNT_T"
        Me.CARD_COUNT_T.Size = New System.Drawing.Size(58, 23)
        Me.CARD_COUNT_T.TabIndex = 2
        Me.CARD_COUNT_T.Text = "1"
        Me.CARD_COUNT_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(160, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "枚"
        '
        'DEVICE_SET_G
        '
        Me.DEVICE_SET_G.Controls.Add(Me.Card_Printer_R)
        Me.DEVICE_SET_G.Controls.Add(Me.A4_Printer_R)
        Me.DEVICE_SET_G.Location = New System.Drawing.Point(73, 129)
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
        'fPointCardReportPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(557, 381)
        Me.Controls.Add(Me.DEVICE_SET_G)
        Me.Controls.Add(Me.CARD_PRINTER_SET)
        Me.Controls.Add(Me.A4PRINTER_SET_G)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.MESSAGE_1_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPointCardReportPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ポイントカード印刷指定"
        Me.A4PRINTER_SET_G.ResumeLayout(False)
        Me.A4PRINTER_SET_G.PerformLayout()
        Me.CARD_PRINTER_SET.ResumeLayout(False)
        Me.CARD_PRINTER_SET.PerformLayout()
        Me.DEVICE_SET_G.ResumeLayout(False)
        Me.DEVICE_SET_G.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OrderReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MESSAGE_1_T As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents A4_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CARD_COUNT_L As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents A4PRINTER_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents CARD_PRINTER_SET As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CARD_COUNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DEVICE_SET_G As System.Windows.Forms.GroupBox
    Friend WithEvents A4_Printer_R As System.Windows.Forms.RadioButton
    Friend WithEvents Card_Printer_R As System.Windows.Forms.RadioButton
End Class
