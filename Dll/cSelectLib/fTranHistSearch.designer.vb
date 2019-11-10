<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fTranHistSearch
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
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.REQUEST_V = New System.Windows.Forms.DataGridView()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.COUNT_L = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.S_JAN_CODE_T = New System.Windows.Forms.TextBox()
        Me.JANCODE_T = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FROM_REQUEST_DATE_T = New System.Windows.Forms.DateTimePicker()
        Me.TO_REQUEST_DATE_T = New System.Windows.Forms.DateTimePicker()
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.DropDownHeight = 300
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.IntegralHeight = False
        Me.CHANNEL_L.Location = New System.Drawing.Point(138, 76)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(224, 21)
        Me.CHANNEL_L.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(48, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "チャネル名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'REQUEST_V
        '
        Me.REQUEST_V.AllowUserToAddRows = False
        Me.REQUEST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.REQUEST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.REQUEST_V.ColumnHeadersHeight = 30
        Me.REQUEST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.REQUEST_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.REQUEST_V.Location = New System.Drawing.Point(24, 107)
        Me.REQUEST_V.Name = "REQUEST_V"
        Me.REQUEST_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.REQUEST_V.RowTemplate.Height = 21
        Me.REQUEST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.REQUEST_V.Size = New System.Drawing.Size(907, 483)
        Me.REQUEST_V.TabIndex = 15
        Me.REQUEST_V.TabStop = False
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(319, 76)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.CHANNEL_CODE_T.TabIndex = 21
        Me.CHANNEL_CODE_T.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Tan
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(382, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "受注日："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(544, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "～"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(138, 31)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(100, 20)
        Me.PRODUCT_CODE_T.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Tan
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(61, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "商品コード："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(138, 54)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(224, 20)
        Me.PRODUCT_NAME_T.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Tan
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(64, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "商品名称："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'COUNT_L
        '
        Me.COUNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.COUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COUNT_L.Location = New System.Drawing.Point(800, 4)
        Me.COUNT_L.Name = "COUNT_L"
        Me.COUNT_L.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.COUNT_L.Size = New System.Drawing.Size(99, 34)
        Me.COUNT_L.TabIndex = 44
        Me.COUNT_L.Text = "0"
        Me.COUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(717, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 23)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(902, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 23)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "件"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(697, 43)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(114, 58)
        Me.SEARCH_B.TabIndex = 13
        Me.SEARCH_B.TextButton = "検　索"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(817, 43)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(114, 58)
        Me.RETURN_B.TabIndex = 14
        Me.RETURN_B.TextButton = "戻　る"
        '
        'MEMBER_SEARCH_B
        '
        Me.MEMBER_SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MEMBER_SEARCH_B.Location = New System.Drawing.Point(577, 24)
        Me.MEMBER_SEARCH_B.Name = "MEMBER_SEARCH_B"
        Me.MEMBER_SEARCH_B.Size = New System.Drawing.Size(100, 30)
        Me.MEMBER_SEARCH_B.TabIndex = 49
        Me.MEMBER_SEARCH_B.TextButton = "会員検索"
        '
        'MEMBER_CODE_T
        '
        Me.MEMBER_CODE_T.BackColor = System.Drawing.SystemColors.Window
        Me.MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEMBER_CODE_T.Location = New System.Drawing.Point(441, 29)
        Me.MEMBER_CODE_T.MaxLength = 13
        Me.MEMBER_CODE_T.Name = "MEMBER_CODE_T"
        Me.MEMBER_CODE_T.Size = New System.Drawing.Size(130, 20)
        Me.MEMBER_CODE_T.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(363, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "会員コード："
        '
        'S_JAN_CODE_T
        '
        Me.S_JAN_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_JAN_CODE_T.Location = New System.Drawing.Point(552, 53)
        Me.S_JAN_CODE_T.Name = "S_JAN_CODE_T"
        Me.S_JAN_CODE_T.Size = New System.Drawing.Size(19, 19)
        Me.S_JAN_CODE_T.TabIndex = 53
        Me.S_JAN_CODE_T.Visible = False
        '
        'JANCODE_T
        '
        Me.JANCODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JANCODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.JANCODE_T.Location = New System.Drawing.Point(441, 52)
        Me.JANCODE_T.Name = "JANCODE_T"
        Me.JANCODE_T.Size = New System.Drawing.Size(130, 20)
        Me.JANCODE_T.TabIndex = 51
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Tan
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(366, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 19)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "JANコード："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FROM_REQUEST_DATE_T
        '
        Me.FROM_REQUEST_DATE_T.CustomFormat = "yyyy/MM/dd "
        Me.FROM_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.FROM_REQUEST_DATE_T.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FROM_REQUEST_DATE_T.Location = New System.Drawing.Point(441, 75)
        Me.FROM_REQUEST_DATE_T.Name = "FROM_REQUEST_DATE_T"
        Me.FROM_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.FROM_REQUEST_DATE_T.TabIndex = 58
        '
        'TO_REQUEST_DATE_T
        '
        Me.TO_REQUEST_DATE_T.CustomFormat = "yyyy/MM/dd "
        Me.TO_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.TO_REQUEST_DATE_T.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TO_REQUEST_DATE_T.Location = New System.Drawing.Point(565, 75)
        Me.TO_REQUEST_DATE_T.Name = "TO_REQUEST_DATE_T"
        Me.TO_REQUEST_DATE_T.Size = New System.Drawing.Size(100, 20)
        Me.TO_REQUEST_DATE_T.TabIndex = 59
        '
        'fTranHistSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(958, 617)
        Me.Controls.Add(Me.TO_REQUEST_DATE_T)
        Me.Controls.Add(Me.FROM_REQUEST_DATE_T)
        Me.Controls.Add(Me.S_JAN_CODE_T)
        Me.Controls.Add(Me.JANCODE_T)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MEMBER_SEARCH_B)
        Me.Controls.Add(Me.MEMBER_CODE_T)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.COUNT_L)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.REQUEST_V)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fTranHistSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "発注書検索画面"
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_V As System.Windows.Forms.DataGridView
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents COUNT_L As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents S_JAN_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents JANCODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FROM_REQUEST_DATE_T As System.Windows.Forms.DateTimePicker
    Friend WithEvents TO_REQUEST_DATE_T As System.Windows.Forms.DateTimePicker

End Class
