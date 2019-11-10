<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSelectJAN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PRODUCT_LIST_V = New System.Windows.Forms.DataGridView
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox
        CType(Me.PRODUCT_LIST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PRODUCT_LIST_V
        '
        Me.PRODUCT_LIST_V.AllowUserToAddRows = False
        Me.PRODUCT_LIST_V.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
        Me.PRODUCT_LIST_V.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.PRODUCT_LIST_V.BackgroundColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_LIST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.PRODUCT_LIST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.PRODUCT_LIST_V.Location = New System.Drawing.Point(12, 12)
        Me.PRODUCT_LIST_V.MultiSelect = False
        Me.PRODUCT_LIST_V.Name = "PRODUCT_LIST_V"
        Me.PRODUCT_LIST_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRODUCT_LIST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_LIST_V.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.PRODUCT_LIST_V.RowTemplate.Height = 40
        Me.PRODUCT_LIST_V.RowTemplate.ReadOnly = True
        Me.PRODUCT_LIST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PRODUCT_LIST_V.Size = New System.Drawing.Size(769, 374)
        Me.PRODUCT_LIST_V.TabIndex = 0
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(306, 154)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(202, 19)
        Me.PRODUCT_CODE_T.TabIndex = 1
        Me.PRODUCT_CODE_T.Text = "PRODUCT_CODE"
        Me.PRODUCT_CODE_T.Visible = False
        '
        'fSelectJAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(793, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.PRODUCT_LIST_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fSelectJAN"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品選択"
        CType(Me.PRODUCT_LIST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PRODUCT_LIST_V As System.Windows.Forms.DataGridView
    Public WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
End Class
