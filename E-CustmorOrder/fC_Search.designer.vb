<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fC_Search
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
        Me.MEMBER_V = New System.Windows.Forms.DataGridView()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PHONE_NUMBER_T = New System.Windows.Forms.TextBox()
        Me.FULL_NAME_T = New System.Windows.Forms.TextBox()
        Me.COMPANY_NAME_T = New System.Windows.Forms.TextBox()
        Me.ADDRESS_T = New System.Windows.Forms.TextBox()
        Me.PHONE_NUMBER_L = New System.Windows.Forms.Label()
        Me.FULL_NAME_L = New System.Windows.Forms.Label()
        Me.COMPANY_NAME_L = New System.Windows.Forms.Label()
        Me.ADDRESS_L = New System.Windows.Forms.Label()
        Me.POSTAL_CODE_L = New System.Windows.Forms.Label()
        Me.MENBERS_CODE_L = New System.Windows.Forms.Label()
        Me.POSTAL_CODE_T = New System.Windows.Forms.TextBox()
        Me.MENBERS_CODE_T = New System.Windows.Forms.TextBox()
        CType(Me.MEMBER_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.MEMBER_V.Location = New System.Drawing.Point(33, 170)
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
        Me.MEMBER_V.Size = New System.Drawing.Size(910, 443)
        Me.MEMBER_V.TabIndex = 6
        Me.MEMBER_V.TabStop = False
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(653, 34)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(137, 57)
        Me.SEARCH_B.TabIndex = 5
        Me.SEARCH_B.TextButton = "検　索"
        '
        'CLOSE_B
        '
        Me.CLOSE_B.ColorBottom = System.Drawing.Color.Tan
        Me.CLOSE_B.Location = New System.Drawing.Point(806, 34)
        Me.CLOSE_B.Name = "CLOSE_B"
        Me.CLOSE_B.Size = New System.Drawing.Size(137, 57)
        Me.CLOSE_B.TabIndex = 9
        Me.CLOSE_B.TextButton = "終　了"
        '
        'PHONE_NUMBER_T
        '
        Me.PHONE_NUMBER_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHONE_NUMBER_T.Location = New System.Drawing.Point(138, 141)
        Me.PHONE_NUMBER_T.MaxLength = 12
        Me.PHONE_NUMBER_T.Multiline = True
        Me.PHONE_NUMBER_T.Name = "PHONE_NUMBER_T"
        Me.PHONE_NUMBER_T.Size = New System.Drawing.Size(197, 23)
        Me.PHONE_NUMBER_T.TabIndex = 371
        '
        'FULL_NAME_T
        '
        Me.FULL_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FULL_NAME_T.Location = New System.Drawing.Point(138, 110)
        Me.FULL_NAME_T.MaxLength = 20
        Me.FULL_NAME_T.Multiline = True
        Me.FULL_NAME_T.Name = "FULL_NAME_T"
        Me.FULL_NAME_T.Size = New System.Drawing.Size(283, 23)
        Me.FULL_NAME_T.TabIndex = 370
        '
        'COMPANY_NAME_T
        '
        Me.COMPANY_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMPANY_NAME_T.Location = New System.Drawing.Point(138, 79)
        Me.COMPANY_NAME_T.MaxLength = 50
        Me.COMPANY_NAME_T.Multiline = True
        Me.COMPANY_NAME_T.Name = "COMPANY_NAME_T"
        Me.COMPANY_NAME_T.Size = New System.Drawing.Size(283, 23)
        Me.COMPANY_NAME_T.TabIndex = 369
        '
        'ADDRESS_T
        '
        Me.ADDRESS_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS_T.Location = New System.Drawing.Point(138, 48)
        Me.ADDRESS_T.MaxLength = 150
        Me.ADDRESS_T.Multiline = True
        Me.ADDRESS_T.Name = "ADDRESS_T"
        Me.ADDRESS_T.Size = New System.Drawing.Size(283, 23)
        Me.ADDRESS_T.TabIndex = 368
        '
        'PHONE_NUMBER_L
        '
        Me.PHONE_NUMBER_L.AutoSize = True
        Me.PHONE_NUMBER_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHONE_NUMBER_L.Location = New System.Drawing.Point(33, 147)
        Me.PHONE_NUMBER_L.Name = "PHONE_NUMBER_L"
        Me.PHONE_NUMBER_L.Size = New System.Drawing.Size(99, 20)
        Me.PHONE_NUMBER_L.TabIndex = 367
        Me.PHONE_NUMBER_L.Text = "電話番号："
        '
        'FULL_NAME_L
        '
        Me.FULL_NAME_L.AutoSize = True
        Me.FULL_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FULL_NAME_L.Location = New System.Drawing.Point(73, 116)
        Me.FULL_NAME_L.Name = "FULL_NAME_L"
        Me.FULL_NAME_L.Size = New System.Drawing.Size(59, 20)
        Me.FULL_NAME_L.TabIndex = 366
        Me.FULL_NAME_L.Text = "氏名："
        '
        'COMPANY_NAME_L
        '
        Me.COMPANY_NAME_L.AutoSize = True
        Me.COMPANY_NAME_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COMPANY_NAME_L.Location = New System.Drawing.Point(53, 84)
        Me.COMPANY_NAME_L.Name = "COMPANY_NAME_L"
        Me.COMPANY_NAME_L.Size = New System.Drawing.Size(79, 20)
        Me.COMPANY_NAME_L.TabIndex = 365
        Me.COMPANY_NAME_L.Text = "会社名："
        '
        'ADDRESS_L
        '
        Me.ADDRESS_L.AutoSize = True
        Me.ADDRESS_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDRESS_L.Location = New System.Drawing.Point(73, 51)
        Me.ADDRESS_L.Name = "ADDRESS_L"
        Me.ADDRESS_L.Size = New System.Drawing.Size(59, 20)
        Me.ADDRESS_L.TabIndex = 364
        Me.ADDRESS_L.Text = "住所："
        '
        'POSTAL_CODE_L
        '
        Me.POSTAL_CODE_L.AutoSize = True
        Me.POSTAL_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAL_CODE_L.Location = New System.Drawing.Point(275, 20)
        Me.POSTAL_CODE_L.Name = "POSTAL_CODE_L"
        Me.POSTAL_CODE_L.Size = New System.Drawing.Size(99, 20)
        Me.POSTAL_CODE_L.TabIndex = 363
        Me.POSTAL_CODE_L.Text = "郵便番号："
        '
        'MENBERS_CODE_L
        '
        Me.MENBERS_CODE_L.AutoSize = True
        Me.MENBERS_CODE_L.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MENBERS_CODE_L.Location = New System.Drawing.Point(29, 20)
        Me.MENBERS_CODE_L.Name = "MENBERS_CODE_L"
        Me.MENBERS_CODE_L.Size = New System.Drawing.Size(103, 20)
        Me.MENBERS_CODE_L.TabIndex = 362
        Me.MENBERS_CODE_L.Text = "会員コード："
        '
        'POSTAL_CODE_T
        '
        Me.POSTAL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.POSTAL_CODE_T.Location = New System.Drawing.Point(380, 17)
        Me.POSTAL_CODE_T.MaxLength = 8
        Me.POSTAL_CODE_T.Multiline = True
        Me.POSTAL_CODE_T.Name = "POSTAL_CODE_T"
        Me.POSTAL_CODE_T.Size = New System.Drawing.Size(132, 23)
        Me.POSTAL_CODE_T.TabIndex = 361
        '
        'MENBERS_CODE_T
        '
        Me.MENBERS_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MENBERS_CODE_T.Location = New System.Drawing.Point(138, 17)
        Me.MENBERS_CODE_T.MaxLength = 13
        Me.MENBERS_CODE_T.Multiline = True
        Me.MENBERS_CODE_T.Name = "MENBERS_CODE_T"
        Me.MENBERS_CODE_T.Size = New System.Drawing.Size(120, 23)
        Me.MENBERS_CODE_T.TabIndex = 360
        '
        'fC_Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(987, 643)
        Me.Controls.Add(Me.PHONE_NUMBER_T)
        Me.Controls.Add(Me.FULL_NAME_T)
        Me.Controls.Add(Me.COMPANY_NAME_T)
        Me.Controls.Add(Me.ADDRESS_T)
        Me.Controls.Add(Me.PHONE_NUMBER_L)
        Me.Controls.Add(Me.FULL_NAME_L)
        Me.Controls.Add(Me.COMPANY_NAME_L)
        Me.Controls.Add(Me.ADDRESS_L)
        Me.Controls.Add(Me.POSTAL_CODE_L)
        Me.Controls.Add(Me.MENBERS_CODE_L)
        Me.Controls.Add(Me.POSTAL_CODE_T)
        Me.Controls.Add(Me.MENBERS_CODE_T)
        Me.Controls.Add(Me.CLOSE_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.MEMBER_V)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fC_Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "会員検索画面"
        CType(Me.MEMBER_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MEMBER_V As System.Windows.Forms.DataGridView
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents CLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents PHONE_NUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents FULL_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents COMPANY_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents ADDRESS_T As System.Windows.Forms.TextBox
    Friend WithEvents PHONE_NUMBER_L As System.Windows.Forms.Label
    Friend WithEvents FULL_NAME_L As System.Windows.Forms.Label
    Friend WithEvents COMPANY_NAME_L As System.Windows.Forms.Label
    Friend WithEvents ADDRESS_L As System.Windows.Forms.Label
    Friend WithEvents POSTAL_CODE_L As System.Windows.Forms.Label
    Friend WithEvents MENBERS_CODE_L As System.Windows.Forms.Label
    Friend WithEvents POSTAL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents MENBERS_CODE_T As System.Windows.Forms.TextBox

End Class
