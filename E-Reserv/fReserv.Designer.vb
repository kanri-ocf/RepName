<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReserv
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CHART_V = New System.Windows.Forms.DataGridView
        Me.Label33 = New System.Windows.Forms.Label
        Me.PRE_MONTH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NEXT_MONTH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MONTH_T = New System.Windows.Forms.MaskedTextBox
        Me.CHANNEL_NAME_C = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox
        Me.BUMON_CODE_T = New System.Windows.Forms.TextBox
        Me.BUMON_NAME_C = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.CHART_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CHART_V
        '
        Me.CHART_V.AllowUserToAddRows = False
        Me.CHART_V.AllowUserToDeleteRows = False
        Me.CHART_V.AllowUserToResizeColumns = False
        Me.CHART_V.AllowUserToResizeRows = False
        Me.CHART_V.BackgroundColor = System.Drawing.Color.Tan
        Me.CHART_V.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CHART_V.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHART_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.CHART_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.CHART_V.ColumnHeadersVisible = False
        Me.CHART_V.EnableHeadersVisualStyles = False
        Me.CHART_V.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CHART_V.Location = New System.Drawing.Point(7, 109)
        Me.CHART_V.Name = "CHART_V"
        Me.CHART_V.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.CHART_V.RowHeadersVisible = False
        Me.CHART_V.RowTemplate.Height = 21
        Me.CHART_V.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CHART_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.CHART_V.Size = New System.Drawing.Size(1005, 600)
        Me.CHART_V.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(513, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(60, 15)
        Me.Label33.TabIndex = 32
        Me.Label33.Text = "表示月："
        '
        'PRE_MONTH_B
        '
        Me.PRE_MONTH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.PRE_MONTH_B.ColorDisabled = System.Drawing.Color.Tan
        Me.PRE_MONTH_B.Location = New System.Drawing.Point(427, 14)
        Me.PRE_MONTH_B.Name = "PRE_MONTH_B"
        Me.PRE_MONTH_B.Size = New System.Drawing.Size(80, 37)
        Me.PRE_MONTH_B.TabIndex = 37
        Me.PRE_MONTH_B.TextButton = "<< 前月"
        '
        'NEXT_MONTH_B
        '
        Me.NEXT_MONTH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.NEXT_MONTH_B.ColorDisabled = System.Drawing.Color.Tan
        Me.NEXT_MONTH_B.Location = New System.Drawing.Point(676, 14)
        Me.NEXT_MONTH_B.Name = "NEXT_MONTH_B"
        Me.NEXT_MONTH_B.Size = New System.Drawing.Size(80, 37)
        Me.NEXT_MONTH_B.TabIndex = 38
        Me.NEXT_MONTH_B.TextButton = "次月 >>"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.ColorDisabled = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(870, 714)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(131, 37)
        Me.COMMIT_B.TabIndex = 39
        Me.COMMIT_B.TextButton = "終　了"
        '
        'MONTH_T
        '
        Me.MONTH_T.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MONTH_T.Location = New System.Drawing.Point(571, 20)
        Me.MONTH_T.Mask = "0000/00"
        Me.MONTH_T.Name = "MONTH_T"
        Me.MONTH_T.Size = New System.Drawing.Size(90, 26)
        Me.MONTH_T.TabIndex = 40
        Me.MONTH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CHANNEL_NAME_C
        '
        Me.CHANNEL_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_C.FormattingEnabled = True
        Me.CHANNEL_NAME_C.Location = New System.Drawing.Point(129, 6)
        Me.CHANNEL_NAME_C.Name = "CHANNEL_NAME_C"
        Me.CHANNEL_NAME_C.Size = New System.Drawing.Size(144, 24)
        Me.CHANNEL_NAME_C.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "チャネル名称："
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(235, 9)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(19, 20)
        Me.CHANNEL_CODE_T.TabIndex = 79
        Me.CHANNEL_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CHANNEL_CODE_T.Visible = False
        '
        'BUMON_CODE_T
        '
        Me.BUMON_CODE_T.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.BUMON_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_CODE_T.Location = New System.Drawing.Point(298, 35)
        Me.BUMON_CODE_T.Name = "BUMON_CODE_T"
        Me.BUMON_CODE_T.Size = New System.Drawing.Size(19, 20)
        Me.BUMON_CODE_T.TabIndex = 82
        Me.BUMON_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BUMON_CODE_T.Visible = False
        '
        'BUMON_NAME_C
        '
        Me.BUMON_NAME_C.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_NAME_C.FormattingEnabled = True
        Me.BUMON_NAME_C.Location = New System.Drawing.Point(129, 32)
        Me.BUMON_NAME_C.Name = "BUMON_NAME_C"
        Me.BUMON_NAME_C.Size = New System.Drawing.Size(206, 24)
        Me.BUMON_NAME_C.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 15)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "サービス商品名称："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 718)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 12)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "新規予約は、予約の範囲を左クリックで選択して下さい。"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 739)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(324, 12)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "更新予約は、更新予約の範囲の一意のセルを右クリックして下さい。"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.ColorDisabled = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(866, 15)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(135, 37)
        Me.SEARCH_B.TabIndex = 85
        Me.SEARCH_B.TextButton = "予約検索"
        '
        'fReserv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BUMON_CODE_T)
        Me.Controls.Add(Me.BUMON_NAME_C)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.MONTH_T)
        Me.Controls.Add(Me.CHANNEL_NAME_C)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.NEXT_MONTH_B)
        Me.Controls.Add(Me.PRE_MONTH_B)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.CHART_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fReserv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "予約管理"
        CType(Me.CHART_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CHART_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents PRE_MONTH_B As Softgroup.NetButton.NetButton
    Friend WithEvents NEXT_MONTH_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents MONTH_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CHANNEL_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents BUMON_NAME_C As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
End Class
