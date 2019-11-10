<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointMemberSearch
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TEL_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.POINT_MEMBER_NAME_T = New System.Windows.Forms.TextBox
        Me.POINT_MEMBER_V = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.POINT_MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PRE_R = New System.Windows.Forms.RadioButton
        Me.DISENABLE_R = New System.Windows.Forms.RadioButton
        Me.ENABLE_R = New System.Windows.Forms.RadioButton
        CType(Me.POINT_MEMBER_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TEL_T
        '
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TEL_T.Location = New System.Drawing.Point(160, 72)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.Size = New System.Drawing.Size(171, 20)
        Me.TEL_T.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "電話番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ポイント会員名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'POINT_MEMBER_NAME_T
        '
        Me.POINT_MEMBER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_MEMBER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.POINT_MEMBER_NAME_T.Location = New System.Drawing.Point(160, 50)
        Me.POINT_MEMBER_NAME_T.Name = "POINT_MEMBER_NAME_T"
        Me.POINT_MEMBER_NAME_T.Size = New System.Drawing.Size(269, 20)
        Me.POINT_MEMBER_NAME_T.TabIndex = 2
        '
        'POINT_MEMBER_V
        '
        Me.POINT_MEMBER_V.AllowUserToAddRows = False
        Me.POINT_MEMBER_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.POINT_MEMBER_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.POINT_MEMBER_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.POINT_MEMBER_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.POINT_MEMBER_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.POINT_MEMBER_V.Location = New System.Drawing.Point(25, 114)
        Me.POINT_MEMBER_V.Name = "POINT_MEMBER_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.POINT_MEMBER_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.POINT_MEMBER_V.RowTemplate.Height = 21
        Me.POINT_MEMBER_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.POINT_MEMBER_V.Size = New System.Drawing.Size(934, 506)
        Me.POINT_MEMBER_V.TabIndex = 6
        Me.POINT_MEMBER_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "ポイント会員コード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'POINT_MEMBER_CODE_T
        '
        Me.POINT_MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POINT_MEMBER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.POINT_MEMBER_CODE_T.Location = New System.Drawing.Point(160, 28)
        Me.POINT_MEMBER_CODE_T.Name = "POINT_MEMBER_CODE_T"
        Me.POINT_MEMBER_CODE_T.Size = New System.Drawing.Size(171, 20)
        Me.POINT_MEMBER_CODE_T.TabIndex = 1
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(679, 34)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(137, 57)
        Me.SEARCH_B.TabIndex = 5
        Me.SEARCH_B.TextButton = "検　索"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Tan
        Me.CLOSE_B.Location = New System.Drawing.Point(822, 34)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(137, 57)
        Me.CLOSE_B.TabIndex = 6
        Me.CLOSE_B.TextButton = "終　了"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PRE_R)
        Me.GroupBox1.Controls.Add(Me.DISENABLE_R)
        Me.GroupBox1.Controls.Add(Me.ENABLE_R)
        Me.GroupBox1.Location = New System.Drawing.Point(456, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 87)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【会員種別】"
        '
        'PRE_R
        '
        Me.PRE_R.AutoSize = True
        Me.PRE_R.Location = New System.Drawing.Point(35, 62)
        Me.PRE_R.Name = "PRE_R"
        Me.PRE_R.Size = New System.Drawing.Size(83, 16)
        Me.PRE_R.TabIndex = 2
        Me.PRE_R.Text = "仮登録会員"
        Me.PRE_R.UseVisualStyleBackColor = True
        '
        'DISENABLE_R
        '
        Me.DISENABLE_R.AutoSize = True
        Me.DISENABLE_R.Location = New System.Drawing.Point(35, 40)
        Me.DISENABLE_R.Name = "DISENABLE_R"
        Me.DISENABLE_R.Size = New System.Drawing.Size(71, 16)
        Me.DISENABLE_R.TabIndex = 1
        Me.DISENABLE_R.Text = "無効会員"
        Me.DISENABLE_R.UseVisualStyleBackColor = True
        '
        'ENABLE_R
        '
        Me.ENABLE_R.AutoSize = True
        Me.ENABLE_R.Checked = True
        Me.ENABLE_R.Location = New System.Drawing.Point(35, 18)
        Me.ENABLE_R.Name = "ENABLE_R"
        Me.ENABLE_R.Size = New System.Drawing.Size(71, 16)
        Me.ENABLE_R.TabIndex = 0
        Me.ENABLE_R.TabStop = True
        Me.ENABLE_R.Text = "有効会員"
        Me.ENABLE_R.UseVisualStyleBackColor = True
        '
        'fPointMemberSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(987, 643)
        Me.Controls.Add(Me.POINT_MEMBER_CODE_T)
        Me.Controls.Add(Me.POINT_MEMBER_NAME_T)
        Me.Controls.Add(Me.TEL_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.POINT_MEMBER_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fPointMemberSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ポイント会員検索画面"
        CType(Me.POINT_MEMBER_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents POINT_MEMBER_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents POINT_MEMBER_NAME_T As System.Windows.Forms.TextBox
    Public WithEvents POINT_MEMBER_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PRE_R As System.Windows.Forms.RadioButton
    Friend WithEvents DISENABLE_R As System.Windows.Forms.RadioButton
    Friend WithEvents ENABLE_R As System.Windows.Forms.RadioButton

End Class
