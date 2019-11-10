<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMonthCloseReport
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
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SALER_REPORT_C = New System.Windows.Forms.CheckBox
        Me.CHANNEL_REPORT_C = New System.Windows.Forms.CheckBox
        Me.SUPPLIER_REPORT_C = New System.Windows.Forms.CheckBox
        Me.SUPPLIER_NAME_C = New System.Windows.Forms.ComboBox
        Me.SUPPLIER_CODE_T = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MESSAGE_1_T
        '
        Me.MESSAGE_1_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE_1_T.Location = New System.Drawing.Point(29, 17)
        Me.MESSAGE_1_T.Name = "MESSAGE_1_T"
        Me.MESSAGE_1_T.Size = New System.Drawing.Size(431, 30)
        Me.MESSAGE_1_T.TabIndex = 15
        Me.MESSAGE_1_T.Text = "月次締め処理のレポートを出力します。"
        Me.MESSAGE_1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(281, 241)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(123, 43)
        Me.OK_B.TabIndex = 3
        Me.OK_B.TextButton = "OK"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.CANCEL_B.Location = New System.Drawing.Point(105, 241)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(123, 43)
        Me.CANCEL_B.TabIndex = 4
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(431, 30)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "出力対象のレポートを指定して下さい。"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SUPPLIER_CODE_T)
        Me.GroupBox1.Controls.Add(Me.SUPPLIER_NAME_C)
        Me.GroupBox1.Controls.Add(Me.SUPPLIER_REPORT_C)
        Me.GroupBox1.Controls.Add(Me.CHANNEL_REPORT_C)
        Me.GroupBox1.Controls.Add(Me.SALER_REPORT_C)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 155)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'SALER_REPORT_C
        '
        Me.SALER_REPORT_C.AutoSize = True
        Me.SALER_REPORT_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SALER_REPORT_C.Location = New System.Drawing.Point(36, 28)
        Me.SALER_REPORT_C.Name = "SALER_REPORT_C"
        Me.SALER_REPORT_C.Size = New System.Drawing.Size(119, 17)
        Me.SALER_REPORT_C.TabIndex = 0
        Me.SALER_REPORT_C.Text = "売上集計レポート"
        Me.SALER_REPORT_C.UseVisualStyleBackColor = True
        '
        'CHANNEL_REPORT_C
        '
        Me.CHANNEL_REPORT_C.AutoSize = True
        Me.CHANNEL_REPORT_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_REPORT_C.Location = New System.Drawing.Point(36, 50)
        Me.CHANNEL_REPORT_C.Name = "CHANNEL_REPORT_C"
        Me.CHANNEL_REPORT_C.Size = New System.Drawing.Size(173, 17)
        Me.CHANNEL_REPORT_C.TabIndex = 1
        Me.CHANNEL_REPORT_C.Text = "チャネル別売上集計レポート"
        Me.CHANNEL_REPORT_C.UseVisualStyleBackColor = True
        '
        'SUPPLIER_REPORT_C
        '
        Me.SUPPLIER_REPORT_C.AutoSize = True
        Me.SUPPLIER_REPORT_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_REPORT_C.Location = New System.Drawing.Point(36, 72)
        Me.SUPPLIER_REPORT_C.Name = "SUPPLIER_REPORT_C"
        Me.SUPPLIER_REPORT_C.Size = New System.Drawing.Size(119, 17)
        Me.SUPPLIER_REPORT_C.TabIndex = 2
        Me.SUPPLIER_REPORT_C.Text = "仕入状況レポート"
        Me.SUPPLIER_REPORT_C.UseVisualStyleBackColor = True
        '
        'SUPPLIER_NAME_C
        '
        Me.SUPPLIER_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SUPPLIER_NAME_C.FormattingEnabled = True
        Me.SUPPLIER_NAME_C.Location = New System.Drawing.Point(77, 95)
        Me.SUPPLIER_NAME_C.Name = "SUPPLIER_NAME_C"
        Me.SUPPLIER_NAME_C.Size = New System.Drawing.Size(328, 23)
        Me.SUPPLIER_NAME_C.TabIndex = 3
        '
        'SUPPLIER_CODE_T
        '
        Me.SUPPLIER_CODE_T.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.SUPPLIER_CODE_T.Location = New System.Drawing.Point(362, 98)
        Me.SUPPLIER_CODE_T.Name = "SUPPLIER_CODE_T"
        Me.SUPPLIER_CODE_T.Size = New System.Drawing.Size(25, 19)
        Me.SUPPLIER_CODE_T.TabIndex = 4
        Me.SUPPLIER_CODE_T.Visible = False
        '
        'fMonthCloseReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(487, 311)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.MESSAGE_1_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fMonthCloseReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fReportPage"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OrderReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MESSAGE_1_T As System.Windows.Forms.Label
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SUPPLIER_REPORT_C As System.Windows.Forms.CheckBox
    Friend WithEvents CHANNEL_REPORT_C As System.Windows.Forms.CheckBox
    Friend WithEvents SALER_REPORT_C As System.Windows.Forms.CheckBox
    Friend WithEvents SUPPLIER_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents SUPPLIER_CODE_T As System.Windows.Forms.TextBox
End Class
