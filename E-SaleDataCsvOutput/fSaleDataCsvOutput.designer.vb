<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSaleDataCsvOutput
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FROM_DATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.TO_DATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.START_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.FIND_PATH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CSV_PATH_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PROGRESS_B = New System.Windows.Forms.ProgressBar()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.CHANNEL_NAME_C = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "売上データを弥生インポートデータCSV形式で出力します。"
        '
        'FROM_DATE_T
        '
        Me.FROM_DATE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FROM_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_DATE_T.Location = New System.Drawing.Point(99, 148)
        Me.FROM_DATE_T.Mask = "0000/00/00"
        Me.FROM_DATE_T.Name = "FROM_DATE_T"
        Me.FROM_DATE_T.Size = New System.Drawing.Size(112, 23)
        Me.FROM_DATE_T.TabIndex = 1
        Me.FROM_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FROM_DATE_T.ValidatingType = GetType(Date)
        '
        'TO_DATE_T
        '
        Me.TO_DATE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TO_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_DATE_T.Location = New System.Drawing.Point(247, 148)
        Me.TO_DATE_T.Mask = "0000/00/00"
        Me.TO_DATE_T.Name = "TO_DATE_T"
        Me.TO_DATE_T.Size = New System.Drawing.Size(112, 23)
        Me.TO_DATE_T.TabIndex = 2
        Me.TO_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TO_DATE_T.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(219, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "～"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(180, 244)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(109, 45)
        Me.RETURN_B.TabIndex = 5
        Me.RETURN_B.TextButton = "戻　る"
        '
        'START_B
        '
        Me.START_B.ColorBottom = System.Drawing.Color.Wheat
        Me.START_B.Location = New System.Drawing.Point(325, 244)
        Me.START_B.Name = "START_B"
        Me.START_B.Size = New System.Drawing.Size(109, 45)
        Me.START_B.TabIndex = 6
        Me.START_B.TextButton = "出力開始"
        '
        'FIND_PATH_B
        '
        Me.FIND_PATH_B.ColorBottom = System.Drawing.Color.Tan
        Me.FIND_PATH_B.Location = New System.Drawing.Point(479, 193)
        Me.FIND_PATH_B.Name = "FIND_PATH_B"
        Me.FIND_PATH_B.Size = New System.Drawing.Size(100, 30)
        Me.FIND_PATH_B.TabIndex = 4
        Me.FIND_PATH_B.TextButton = "参照"
        '
        'CSV_PATH_T
        '
        Me.CSV_PATH_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CSV_PATH_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CSV_PATH_T.Location = New System.Drawing.Point(100, 197)
        Me.CSV_PATH_T.Name = "CSV_PATH_T"
        Me.CSV_PATH_T.Size = New System.Drawing.Size(373, 22)
        Me.CSV_PATH_T.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 12)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "CSV出力先："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "出力対象締日："
        '
        'PROGRESS_B
        '
        Me.PROGRESS_B.Location = New System.Drawing.Point(26, 302)
        Me.PROGRESS_B.Name = "PROGRESS_B"
        Me.PROGRESS_B.Size = New System.Drawing.Size(553, 23)
        Me.PROGRESS_B.TabIndex = 74
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(243, 108)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(19, 20)
        Me.CHANNEL_CODE_T.TabIndex = 82
        Me.CHANNEL_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CHANNEL_CODE_T.Visible = False
        '
        'CHANNEL_NAME_C
        '
        Me.CHANNEL_NAME_C.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CHANNEL_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_C.FormattingEnabled = True
        Me.CHANNEL_NAME_C.Location = New System.Drawing.Point(100, 107)
        Me.CHANNEL_NAME_C.Name = "CHANNEL_NAME_C"
        Me.CHANNEL_NAME_C.Size = New System.Drawing.Size(144, 24)
        Me.CHANNEL_NAME_C.TabIndex = 80
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "チャネル名称："
        '
        'fSaleDataCsvOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(603, 347)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_NAME_C)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PROGRESS_B)
        Me.Controls.Add(Me.TO_DATE_T)
        Me.Controls.Add(Me.FROM_DATE_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FIND_PATH_B)
        Me.Controls.Add(Me.CSV_PATH_T)
        Me.Controls.Add(Me.START_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fSaleDataCsvOutput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "弥生データ出力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FROM_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents START_B As Softgroup.NetButton.NetButton
    Friend WithEvents FIND_PATH_B As Softgroup.NetButton.NetButton
    Friend WithEvents CSV_PATH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PROGRESS_B As System.Windows.Forms.ProgressBar
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
