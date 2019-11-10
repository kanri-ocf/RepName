<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSelectBumon
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BUMON_LIST_V = New System.Windows.Forms.DataGridView()
        Me.BUMON_CODE_T = New System.Windows.Forms.TextBox()
        CType(Me.BUMON_LIST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BUMON_LIST_V
        '
        Me.BUMON_LIST_V.AllowUserToAddRows = False
        Me.BUMON_LIST_V.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
        Me.BUMON_LIST_V.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.BUMON_LIST_V.BackgroundColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BUMON_LIST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.BUMON_LIST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.BUMON_LIST_V.Location = New System.Drawing.Point(12, 12)
        Me.BUMON_LIST_V.MultiSelect = False
        Me.BUMON_LIST_V.Name = "BUMON_LIST_V"
        Me.BUMON_LIST_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BUMON_LIST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BUMON_LIST_V.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.BUMON_LIST_V.RowTemplate.Height = 40
        Me.BUMON_LIST_V.RowTemplate.ReadOnly = True
        Me.BUMON_LIST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BUMON_LIST_V.Size = New System.Drawing.Size(467, 374)
        Me.BUMON_LIST_V.TabIndex = 0
        '
        'BUMON_CODE_T
        '
        Me.BUMON_CODE_T.Location = New System.Drawing.Point(72, 177)
        Me.BUMON_CODE_T.Name = "BUMON_CODE_T"
        Me.BUMON_CODE_T.Size = New System.Drawing.Size(202, 19)
        Me.BUMON_CODE_T.TabIndex = 1
        Me.BUMON_CODE_T.Text = "BUMON_CODE"
        Me.BUMON_CODE_T.Visible = False
        '
        'fSelectBumon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(490, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.BUMON_CODE_T)
        Me.Controls.Add(Me.BUMON_LIST_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fSelectBumon"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品選択"
        CType(Me.BUMON_LIST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BUMON_LIST_V As System.Windows.Forms.DataGridView
    Public WithEvents BUMON_CODE_T As System.Windows.Forms.TextBox
End Class
