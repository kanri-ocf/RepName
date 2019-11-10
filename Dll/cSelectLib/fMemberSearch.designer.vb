<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMemberSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TEL_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MEMBER_NAME_T = New System.Windows.Forms.TextBox()
        Me.MEMBER_V = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MEMBER_CODE_T = New System.Windows.Forms.TextBox()
        Me.Enable_C = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.MEMBER_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEL_T
        '
        Me.TEL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TEL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TEL_T.Location = New System.Drawing.Point(453, 58)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.Size = New System.Drawing.Size(171, 20)
        Me.TEL_T.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(379, 61)
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
        Me.Label3.Location = New System.Drawing.Point(24, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "会員名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MEMBER_NAME_T
        '
        Me.MEMBER_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MEMBER_NAME_T.Location = New System.Drawing.Point(101, 58)
        Me.MEMBER_NAME_T.Name = "MEMBER_NAME_T"
        Me.MEMBER_NAME_T.Size = New System.Drawing.Size(269, 20)
        Me.MEMBER_NAME_T.TabIndex = 2
        '
        'MEMBER_V
        '
        Me.MEMBER_V.AllowUserToAddRows = False
        Me.MEMBER_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.MEMBER_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MEMBER_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MEMBER_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MEMBER_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.MEMBER_V.Location = New System.Drawing.Point(25, 114)
        Me.MEMBER_V.Name = "MEMBER_V"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MEMBER_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MEMBER_V.RowTemplate.Height = 21
        Me.MEMBER_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MEMBER_V.Size = New System.Drawing.Size(934, 506)
        Me.MEMBER_V.TabIndex = 6
        Me.MEMBER_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "会員コード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MEMBER_CODE_T
        '
        Me.MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MEMBER_CODE_T.Location = New System.Drawing.Point(101, 34)
        Me.MEMBER_CODE_T.Name = "MEMBER_CODE_T"
        Me.MEMBER_CODE_T.Size = New System.Drawing.Size(171, 20)
        Me.MEMBER_CODE_T.TabIndex = 0
        '
        'Enable_C
        '
        Me.Enable_C.AutoSize = True
        Me.Enable_C.Location = New System.Drawing.Point(453, 84)
        Me.Enable_C.Name = "Enable_C"
        Me.Enable_C.Size = New System.Drawing.Size(93, 16)
        Me.Enable_C.TabIndex = 23
        Me.Enable_C.Text = "有効会員のみ"
        Me.Enable_C.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "保護者名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox1.Location = New System.Drawing.Point(101, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(269, 20)
        Me.TextBox1.TabIndex = 24
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(453, 34)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(171, 21)
        Me.ComboBox1.TabIndex = 130
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(388, 37)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(66, 13)
        Me.Label33.TabIndex = 131
        Me.Label33.Text = "会員種別："
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
        Me.CLOSE_B.TabIndex = 9
        Me.CLOSE_B.TextButton = "終　了"
        '
        'fMemberSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(987, 643)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Enable_C)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MEMBER_CODE_T)
        Me.Controls.Add(Me.MEMBER_V)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MEMBER_NAME_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TEL_T)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fMemberSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "会員検索画面"
        CType(Me.MEMBER_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MEMBER_V As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Enable_C As System.Windows.Forms.CheckBox
    Public WithEvents MEMBER_NAME_T As System.Windows.Forms.TextBox
    Public WithEvents MEMBER_CODE_T As System.Windows.Forms.TextBox
    Public WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton

End Class
