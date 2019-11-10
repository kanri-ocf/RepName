<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fDeliveryCSVInput
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
        Me.TYPE_C = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.START_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.FIND_PATH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CSV_PATH_T = New System.Windows.Forms.TextBox
        Me.PROGRESS_B = New System.Windows.Forms.ProgressBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TYPE_C
        '
        Me.TYPE_C.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TYPE_C.FormattingEnabled = True
        Me.TYPE_C.Location = New System.Drawing.Point(137, 83)
        Me.TYPE_C.Name = "TYPE_C"
        Me.TYPE_C.Size = New System.Drawing.Size(247, 21)
        Me.TYPE_C.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "入力データタイプ："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "出力対象件数："
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 32)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(260, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "件"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(156, 205)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(144, 50)
        Me.RETURN_B.TabIndex = 2
        Me.RETURN_B.TextButton = "戻　る"
        '
        'START_B
        '
        Me.START_B.ColorBottom = System.Drawing.Color.Tan
        Me.START_B.Location = New System.Drawing.Point(366, 205)
        Me.START_B.Name = "START_B"
        Me.START_B.Size = New System.Drawing.Size(144, 50)
        Me.START_B.TabIndex = 3
        Me.START_B.TextButton = "出力開始"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "CSV出力先："
        '
        'FIND_PATH_B
        '
        Me.FIND_PATH_B.ColorBottom = System.Drawing.Color.Tan
        Me.FIND_PATH_B.Location = New System.Drawing.Point(516, 111)
        Me.FIND_PATH_B.Name = "FIND_PATH_B"
        Me.FIND_PATH_B.Size = New System.Drawing.Size(105, 36)
        Me.FIND_PATH_B.TabIndex = 74
        Me.FIND_PATH_B.TextButton = "参照"
        '
        'CSV_PATH_T
        '
        Me.CSV_PATH_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CSV_PATH_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CSV_PATH_T.Location = New System.Drawing.Point(137, 118)
        Me.CSV_PATH_T.Name = "CSV_PATH_T"
        Me.CSV_PATH_T.Size = New System.Drawing.Size(373, 22)
        Me.CSV_PATH_T.TabIndex = 73
        '
        'PROGRESS_B
        '
        Me.PROGRESS_B.Location = New System.Drawing.Point(27, 285)
        Me.PROGRESS_B.Name = "PROGRESS_B"
        Me.PROGRESS_B.Size = New System.Drawing.Size(594, 23)
        Me.PROGRESS_B.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(205, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(249, 15)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "出荷伝票入力用CSVデータを取込ます。"
        '
        'fDeliveryCSVInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(648, 338)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PROGRESS_B)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FIND_PATH_B)
        Me.Controls.Add(Me.CSV_PATH_T)
        Me.Controls.Add(Me.START_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TYPE_C)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fDeliveryCSVInput"
        Me.Text = "配送伝票CSVデータ出力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TYPE_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents START_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FIND_PATH_B As Softgroup.NetButton.NetButton
    Friend WithEvents CSV_PATH_T As System.Windows.Forms.TextBox
    Friend WithEvents PROGRESS_B As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
