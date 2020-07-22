<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRequestSearch
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.REQUEST_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.REQUEST_V = New System.Windows.Forms.DataGridView()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FINISH_SHIP_C = New System.Windows.Forms.CheckBox()
        Me.NON_SHIP_C = New System.Windows.Forms.CheckBox()
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.S_REQUESTNUMBER_T = New System.Windows.Forms.TextBox()
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.COUNT_L = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FROM_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.TO_REQUEST_DATE_T = New System.Windows.Forms.MaskedTextBox()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'REQUEST_CODE_T
        '
        Me.REQUEST_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.REQUEST_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.REQUEST_CODE_T.Location = New System.Drawing.Point(295, 58)
        Me.REQUEST_CODE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.REQUEST_CODE_T.Name = "REQUEST_CODE_T"
        Me.REQUEST_CODE_T.Size = New System.Drawing.Size(325, 33)
        Me.REQUEST_CODE_T.TabIndex = 1
        Me.REQUEST_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Tan
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(69, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "受注伝票番号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.DropDownHeight = 300
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.IntegralHeight = False
        Me.CHANNEL_L.Location = New System.Drawing.Point(1010, 110)
        Me.CHANNEL_L.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(476, 34)
        Me.CHANNEL_L.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Tan
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(815, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 30)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "チャネル名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'REQUEST_V
        '
        Me.REQUEST_V.AllowUserToAddRows = False
        Me.REQUEST_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.REQUEST_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.REQUEST_V.ColumnHeadersHeight = 30
        Me.REQUEST_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.REQUEST_V.DefaultCellStyle = DataGridViewCellStyle11
        Me.REQUEST_V.Location = New System.Drawing.Point(52, 270)
        Me.REQUEST_V.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.REQUEST_V.Name = "REQUEST_V"
        Me.REQUEST_V.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REQUEST_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.REQUEST_V.RowHeadersWidth = 82
        Me.REQUEST_V.RowTemplate.Height = 21
        Me.REQUEST_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.REQUEST_V.Size = New System.Drawing.Size(1965, 710)
        Me.REQUEST_V.TabIndex = 15
        Me.REQUEST_V.TabStop = False
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.SystemColors.Menu
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(1402, 110)
        Me.CHANNEL_CODE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(37, 31)
        Me.CHANNEL_CODE_T.TabIndex = 21
        Me.CHANNEL_CODE_T.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Tan
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(882, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 30)
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
        Me.Label4.Location = New System.Drawing.Point(1226, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 30)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "～"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FINISH_SHIP_C)
        Me.GroupBox1.Controls.Add(Me.NON_SHIP_C)
        Me.GroupBox1.Location = New System.Drawing.Point(1010, 168)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(405, 74)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'FINISH_SHIP_C
        '
        Me.FINISH_SHIP_C.AutoSize = True
        Me.FINISH_SHIP_C.Location = New System.Drawing.Point(223, 24)
        Me.FINISH_SHIP_C.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.FINISH_SHIP_C.Name = "FINISH_SHIP_C"
        Me.FINISH_SHIP_C.Size = New System.Drawing.Size(138, 28)
        Me.FINISH_SHIP_C.TabIndex = 12
        Me.FINISH_SHIP_C.Text = "出荷完了"
        Me.FINISH_SHIP_C.UseVisualStyleBackColor = True
        '
        'NON_SHIP_C
        '
        Me.NON_SHIP_C.AutoSize = True
        Me.NON_SHIP_C.Checked = True
        Me.NON_SHIP_C.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NON_SHIP_C.Location = New System.Drawing.Point(52, 24)
        Me.NON_SHIP_C.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.NON_SHIP_C.Name = "NON_SHIP_C"
        Me.NON_SHIP_C.Size = New System.Drawing.Size(114, 28)
        Me.NON_SHIP_C.TabIndex = 10
        Me.NON_SHIP_C.Text = "未完了"
        Me.NON_SHIP_C.UseVisualStyleBackColor = True
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(295, 104)
        Me.PRODUCT_CODE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(212, 33)
        Me.PRODUCT_CODE_T.TabIndex = 2
        Me.PRODUCT_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Tan
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(128, 110)
        Me.Label5.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 30)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "商品コード："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(295, 150)
        Me.PRODUCT_NAME_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(507, 33)
        Me.PRODUCT_NAME_T.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Tan
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(134, 156)
        Me.Label6.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 30)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "商品名称："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'S_REQUESTNUMBER_T
        '
        Me.S_REQUESTNUMBER_T.BackColor = System.Drawing.SystemColors.Menu
        Me.S_REQUESTNUMBER_T.Location = New System.Drawing.Point(626, 58)
        Me.S_REQUESTNUMBER_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.S_REQUESTNUMBER_T.Name = "S_REQUESTNUMBER_T"
        Me.S_REQUESTNUMBER_T.Size = New System.Drawing.Size(41, 31)
        Me.S_REQUESTNUMBER_T.TabIndex = 37
        Me.S_REQUESTNUMBER_T.Visible = False
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(295, 196)
        Me.OPTION_NAME_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(507, 33)
        Me.OPTION_NAME_T.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Tan
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(85, 202)
        Me.Label7.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 30)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "オプション名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'COUNT_L
        '
        Me.COUNT_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.COUNT_L.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.COUNT_L.Location = New System.Drawing.Point(1740, 36)
        Me.COUNT_L.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.COUNT_L.Name = "COUNT_L"
        Me.COUNT_L.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.COUNT_L.Size = New System.Drawing.Size(215, 68)
        Me.COUNT_L.TabIndex = 44
        Me.COUNT_L.Text = "0"
        Me.COUNT_L.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(1560, 58)
        Me.Label11.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(182, 46)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(1961, 58)
        Me.Label12.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 46)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "件"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Tan
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(849, 192)
        Me.Label10.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 30)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "出荷状況："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FROM_REQUEST_DATE_T
        '
        Me.FROM_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_REQUEST_DATE_T.Location = New System.Drawing.Point(1010, 66)
        Me.FROM_REQUEST_DATE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.FROM_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.FROM_REQUEST_DATE_T.Name = "FROM_REQUEST_DATE_T"
        Me.FROM_REQUEST_DATE_T.Size = New System.Drawing.Size(212, 33)
        Me.FROM_REQUEST_DATE_T.TabIndex = 5
        Me.FROM_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TO_REQUEST_DATE_T
        '
        Me.TO_REQUEST_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_REQUEST_DATE_T.Location = New System.Drawing.Point(1274, 66)
        Me.TO_REQUEST_DATE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TO_REQUEST_DATE_T.Mask = "0000 / 00 / 00"
        Me.TO_REQUEST_DATE_T.Name = "TO_REQUEST_DATE_T"
        Me.TO_REQUEST_DATE_T.Size = New System.Drawing.Size(212, 33)
        Me.TO_REQUEST_DATE_T.TabIndex = 6
        Me.TO_REQUEST_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(1510, 124)
        Me.SEARCH_B.Margin = New System.Windows.Forms.Padding(15, 12, 15, 12)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(247, 116)
        Me.SEARCH_B.TabIndex = 13
        Me.SEARCH_B.TextButton = "検　索"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(1770, 124)
        Me.RETURN_B.Margin = New System.Windows.Forms.Padding(15, 12, 15, 12)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(247, 116)
        Me.RETURN_B.TabIndex = 14
        Me.RETURN_B.TextButton = "戻　る"
        '
        'fRequestSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(2076, 1036)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.COUNT_L)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.TO_REQUEST_DATE_T)
        Me.Controls.Add(Me.FROM_REQUEST_DATE_T)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.REQUEST_CODE_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.S_REQUESTNUMBER_T)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.REQUEST_V)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "fRequestSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "発注書検索画面"
        CType(Me.REQUEST_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents REQUEST_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents REQUEST_V As System.Windows.Forms.DataGridView
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FINISH_SHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents NON_SHIP_C As System.Windows.Forms.CheckBox
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents COUNT_L As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FROM_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TO_REQUEST_DATE_T As System.Windows.Forms.MaskedTextBox
    Public WithEvents S_REQUESTNUMBER_T As System.Windows.Forms.TextBox
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton

End Class
