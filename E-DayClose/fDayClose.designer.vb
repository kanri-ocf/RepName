<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fDayClose
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fDayClose))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CLOSE_DATE_T = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.STAFF_CODE_T = New System.Windows.Forms.TextBox()
        Me.STAFF_NAME_T = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RET_CASH_T = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SUM_V = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RETURN_CASH_T = New System.Windows.Forms.TextBox()
        Me.DIFF_CASH_T = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.STIFFNESS_CASH_T = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OUTPUT_CASH_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.INPUT_CASH_T = New System.Windows.Forms.TextBox()
        Me.CAL_CASH_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TOTAL_SALE_PRICE_T = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TRN_V = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OUTPUT2_R = New System.Windows.Forms.RadioButton()
        Me.OUTPUT1_R = New System.Windows.Forms.RadioButton()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.OPOSPrinter1 = New AxOPOSPRINTERLib.AxOPOSPrinter()
        Me.PRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RET_CASH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.SUM_V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRN_V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.OPOSPrinter1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(89, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 30)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "締め日"
        '
        'CLOSE_DATE_T
        '
        Me.CLOSE_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.CLOSE_DATE_T.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CLOSE_DATE_T.Location = New System.Drawing.Point(197, 38)
        Me.CLOSE_DATE_T.Margin = New System.Windows.Forms.Padding(6)
        Me.CLOSE_DATE_T.Name = "CLOSE_DATE_T"
        Me.CLOSE_DATE_T.Size = New System.Drawing.Size(389, 49)
        Me.CLOSE_DATE_T.TabIndex = 0
        Me.CLOSE_DATE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(67, 1315)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(189, 26)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "締め処理担当者"
        '
        'STAFF_CODE_T
        '
        Me.STAFF_CODE_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_CODE_T.Location = New System.Drawing.Point(284, 1309)
        Me.STAFF_CODE_T.Margin = New System.Windows.Forms.Padding(6)
        Me.STAFF_CODE_T.Name = "STAFF_CODE_T"
        Me.STAFF_CODE_T.ReadOnly = True
        Me.STAFF_CODE_T.Size = New System.Drawing.Size(266, 33)
        Me.STAFF_CODE_T.TabIndex = 25
        Me.STAFF_CODE_T.TabStop = False
        '
        'STAFF_NAME_T
        '
        Me.STAFF_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.STAFF_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STAFF_NAME_T.Location = New System.Drawing.Point(578, 1309)
        Me.STAFF_NAME_T.Margin = New System.Windows.Forms.Padding(6)
        Me.STAFF_NAME_T.Name = "STAFF_NAME_T"
        Me.STAFF_NAME_T.ReadOnly = True
        Me.STAFF_NAME_T.Size = New System.Drawing.Size(366, 33)
        Me.STAFF_NAME_T.TabIndex = 27
        Me.STAFF_NAME_T.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RET_CASH_T)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.SUM_V)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.RETURN_CASH_T)
        Me.GroupBox2.Controls.Add(Me.DIFF_CASH_T)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.STIFFNESS_CASH_T)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.OUTPUT_CASH_T)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.INPUT_CASH_T)
        Me.GroupBox2.Controls.Add(Me.CAL_CASH_T)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TOTAL_SALE_PRICE_T)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.CLOSE_DATE_T)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(65, 77)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox2.Size = New System.Drawing.Size(1750, 522)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【締め情報】"
        '
        'RET_CASH_T
        '
        Me.RET_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.RET_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RET_CASH_T.Location = New System.Drawing.Point(197, 454)
        Me.RET_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.RET_CASH_T.Name = "RET_CASH_T"
        Me.RET_CASH_T.ReadOnly = True
        Me.RET_CASH_T.Size = New System.Drawing.Size(389, 49)
        Me.RET_CASH_T.TabIndex = 2
        Me.RET_CASH_T.TabStop = False
        Me.RET_CASH_T.Text = "0"
        Me.RET_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(52, 466)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 30)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "回収金額"
        '
        'SUM_V
        '
        Me.SUM_V.AllowUserToAddRows = False
        Me.SUM_V.AllowUserToDeleteRows = False
        Me.SUM_V.AllowUserToResizeColumns = False
        Me.SUM_V.AllowUserToResizeRows = False
        Me.SUM_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.SUM_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SUM_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SUM_V.ColumnHeadersHeight = 21
        Me.SUM_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SUM_V.DefaultCellStyle = DataGridViewCellStyle2
        Me.SUM_V.Location = New System.Drawing.Point(604, 35)
        Me.SUM_V.Margin = New System.Windows.Forms.Padding(6)
        Me.SUM_V.MultiSelect = False
        Me.SUM_V.Name = "SUM_V"
        Me.SUM_V.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SUM_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SUM_V.RowHeadersWidth = 82
        Me.SUM_V.RowTemplate.Height = 21
        Me.SUM_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SUM_V.Size = New System.Drawing.Size(1133, 472)
        Me.SUM_V.TabIndex = 51
        Me.SUM_V.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(83, 210)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 30)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "戻入額"
        '
        'RETURN_CASH_T
        '
        Me.RETURN_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.RETURN_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RETURN_CASH_T.Location = New System.Drawing.Point(197, 202)
        Me.RETURN_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.RETURN_CASH_T.Name = "RETURN_CASH_T"
        Me.RETURN_CASH_T.ReadOnly = True
        Me.RETURN_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.RETURN_CASH_T.TabIndex = 55
        Me.RETURN_CASH_T.TabStop = False
        Me.RETURN_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DIFF_CASH_T
        '
        Me.DIFF_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.DIFF_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DIFF_CASH_T.Location = New System.Drawing.Point(197, 394)
        Me.DIFF_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.DIFF_CASH_T.Name = "DIFF_CASH_T"
        Me.DIFF_CASH_T.ReadOnly = True
        Me.DIFF_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.DIFF_CASH_T.TabIndex = 59
        Me.DIFF_CASH_T.TabStop = False
        Me.DIFF_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(52, 402)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 30)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "現金差額"
        '
        'STIFFNESS_CASH_T
        '
        Me.STIFFNESS_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.STIFFNESS_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STIFFNESS_CASH_T.Location = New System.Drawing.Point(197, 346)
        Me.STIFFNESS_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.STIFFNESS_CASH_T.Name = "STIFFNESS_CASH_T"
        Me.STIFFNESS_CASH_T.ReadOnly = True
        Me.STIFFNESS_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.STIFFNESS_CASH_T.TabIndex = 57
        Me.STIFFNESS_CASH_T.TabStop = False
        Me.STIFFNESS_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 354)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 30)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "計測残高"
        '
        'OUTPUT_CASH_T
        '
        Me.OUTPUT_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.OUTPUT_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OUTPUT_CASH_T.Location = New System.Drawing.Point(197, 154)
        Me.OUTPUT_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.OUTPUT_CASH_T.Name = "OUTPUT_CASH_T"
        Me.OUTPUT_CASH_T.ReadOnly = True
        Me.OUTPUT_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.OUTPUT_CASH_T.TabIndex = 55
        Me.OUTPUT_CASH_T.TabStop = False
        Me.OUTPUT_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(84, 162)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 30)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "出金額"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 114)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 30)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "入金額"
        '
        'INPUT_CASH_T
        '
        Me.INPUT_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.INPUT_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.INPUT_CASH_T.Location = New System.Drawing.Point(197, 106)
        Me.INPUT_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.INPUT_CASH_T.Name = "INPUT_CASH_T"
        Me.INPUT_CASH_T.ReadOnly = True
        Me.INPUT_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.INPUT_CASH_T.TabIndex = 53
        Me.INPUT_CASH_T.TabStop = False
        Me.INPUT_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CAL_CASH_T
        '
        Me.CAL_CASH_T.BackColor = System.Drawing.Color.Wheat
        Me.CAL_CASH_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CAL_CASH_T.Location = New System.Drawing.Point(197, 298)
        Me.CAL_CASH_T.Margin = New System.Windows.Forms.Padding(6)
        Me.CAL_CASH_T.Name = "CAL_CASH_T"
        Me.CAL_CASH_T.ReadOnly = True
        Me.CAL_CASH_T.Size = New System.Drawing.Size(389, 39)
        Me.CAL_CASH_T.TabIndex = 51
        Me.CAL_CASH_T.TabStop = False
        Me.CAL_CASH_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 306)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 30)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "現金残高"
        '
        'TOTAL_SALE_PRICE_T
        '
        Me.TOTAL_SALE_PRICE_T.BackColor = System.Drawing.Color.Wheat
        Me.TOTAL_SALE_PRICE_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TOTAL_SALE_PRICE_T.Location = New System.Drawing.Point(197, 250)
        Me.TOTAL_SALE_PRICE_T.Margin = New System.Windows.Forms.Padding(6)
        Me.TOTAL_SALE_PRICE_T.Name = "TOTAL_SALE_PRICE_T"
        Me.TOTAL_SALE_PRICE_T.ReadOnly = True
        Me.TOTAL_SALE_PRICE_T.Size = New System.Drawing.Size(389, 39)
        Me.TOTAL_SALE_PRICE_T.TabIndex = 4
        Me.TOTAL_SALE_PRICE_T.TabStop = False
        Me.TOTAL_SALE_PRICE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 258)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(163, 30)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "現金売上額"
        '
        'TRN_V
        '
        Me.TRN_V.AllowUserToAddRows = False
        Me.TRN_V.AllowUserToDeleteRows = False
        Me.TRN_V.AllowUserToResizeColumns = False
        Me.TRN_V.AllowUserToResizeRows = False
        Me.TRN_V.BackgroundColor = System.Drawing.Color.Wheat
        Me.TRN_V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TRN_V.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.TRN_V.ColumnHeadersHeight = 21
        Me.TRN_V.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TRN_V.DefaultCellStyle = DataGridViewCellStyle5
        Me.TRN_V.Location = New System.Drawing.Point(58, 618)
        Me.TRN_V.Margin = New System.Windows.Forms.Padding(6)
        Me.TRN_V.MultiSelect = False
        Me.TRN_V.Name = "TRN_V"
        Me.TRN_V.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TRN_V.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.TRN_V.RowHeadersWidth = 82
        Me.TRN_V.RowTemplate.Height = 21
        Me.TRN_V.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TRN_V.Size = New System.Drawing.Size(2100, 678)
        Me.TRN_V.TabIndex = 11
        Me.TRN_V.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OUTPUT2_R)
        Me.GroupBox1.Controls.Add(Me.OUTPUT1_R)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(1828, 77)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(325, 128)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【集計表出力方法】"
        '
        'OUTPUT2_R
        '
        Me.OUTPUT2_R.AutoSize = True
        Me.OUTPUT2_R.Checked = True
        Me.OUTPUT2_R.Location = New System.Drawing.Point(50, 83)
        Me.OUTPUT2_R.Margin = New System.Windows.Forms.Padding(6)
        Me.OUTPUT2_R.Name = "OUTPUT2_R"
        Me.OUTPUT2_R.Size = New System.Drawing.Size(116, 28)
        Me.OUTPUT2_R.TabIndex = 51
        Me.OUTPUT2_R.TabStop = True
        Me.OUTPUT2_R.Text = "A4伝票"
        Me.OUTPUT2_R.UseVisualStyleBackColor = True
        '
        'OUTPUT1_R
        '
        Me.OUTPUT1_R.AutoSize = True
        Me.OUTPUT1_R.Location = New System.Drawing.Point(50, 38)
        Me.OUTPUT1_R.Margin = New System.Windows.Forms.Padding(6)
        Me.OUTPUT1_R.Name = "OUTPUT1_R"
        Me.OUTPUT1_R.Size = New System.Drawing.Size(184, 28)
        Me.OUTPUT1_R.TabIndex = 0
        Me.OUTPUT1_R.Text = "ジャーナル伝票"
        Me.OUTPUT1_R.UseVisualStyleBackColor = True
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(65, 26)
        Me.MODE_L.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(2088, 45)
        Me.MODE_L.TabIndex = 54
        Me.MODE_L.Text = "日次締め処理モード"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OPOSPrinter1
        '
        Me.OPOSPrinter1.Enabled = True
        Me.OPOSPrinter1.Location = New System.Drawing.Point(13, 719)
        Me.OPOSPrinter1.Margin = New System.Windows.Forms.Padding(6)
        Me.OPOSPrinter1.Name = "OPOSPrinter1"
        Me.OPOSPrinter1.OcxState = CType(resources.GetObject("OPOSPrinter1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.OPOSPrinter1.Size = New System.Drawing.Size(28, 28)
        Me.OPOSPrinter1.TabIndex = 51
        '
        'PRINT_B
        '
        Me.PRINT_B.ColorBottom = System.Drawing.Color.Tan
        Me.PRINT_B.Location = New System.Drawing.Point(1833, 208)
        Me.PRINT_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.PRINT_B.Name = "PRINT_B"
        Me.PRINT_B.Size = New System.Drawing.Size(320, 94)
        Me.PRINT_B.TabIndex = 1
        Me.PRINT_B.TextButton = "印刷実行"
        '
        'RET_CASH_B
        '
        Me.RET_CASH_B.ColorBottom = System.Drawing.Color.Tan
        Me.RET_CASH_B.Location = New System.Drawing.Point(1833, 307)
        Me.RET_CASH_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.RET_CASH_B.Name = "RET_CASH_B"
        Me.RET_CASH_B.Size = New System.Drawing.Size(320, 94)
        Me.RET_CASH_B.TabIndex = 2
        Me.RET_CASH_B.TextButton = "現金回収"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Tan
        Me.SEARCH_B.Location = New System.Drawing.Point(1833, 408)
        Me.SEARCH_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(320, 94)
        Me.SEARCH_B.TabIndex = 3
        Me.SEARCH_B.TextButton = "過去データ呼出"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Tan
        Me.RETURN_B.Location = New System.Drawing.Point(1833, 509)
        Me.RETURN_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(320, 94)
        Me.RETURN_B.TabIndex = 4
        Me.RETURN_B.TextButton = "再計測"
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.QUIT_B.Location = New System.Drawing.Point(1495, 1315)
        Me.QUIT_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(320, 94)
        Me.QUIT_B.TabIndex = 5
        Me.QUIT_B.TextButton = "中　止"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Tan
        Me.COMMIT_B.Location = New System.Drawing.Point(1838, 1315)
        Me.COMMIT_B.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(320, 94)
        Me.COMMIT_B.TabIndex = 6
        Me.COMMIT_B.TextButton = "終 了"
        '
        'fDayClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(2218, 1438)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.RET_CASH_B)
        Me.Controls.Add(Me.PRINT_B)
        Me.Controls.Add(Me.MODE_L)
        Me.Controls.Add(Me.OPOSPrinter1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TRN_V)
        Me.Controls.Add(Me.STAFF_CODE_T)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.STAFF_NAME_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "fDayClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "日次締め処理"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SUM_V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRN_V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.OPOSPrinter1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CLOSE_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents STAFF_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents STAFF_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TOTAL_SALE_PRICE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TRN_V As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OUTPUT1_R As System.Windows.Forms.RadioButton
    Friend WithEvents OUTPUT2_R As System.Windows.Forms.RadioButton
    Friend WithEvents CAL_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OUTPUT_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents INPUT_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents DIFF_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents STIFFNESS_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SUM_V As System.Windows.Forms.DataGridView
    Friend WithEvents OPOSPrinter1 As AxOPOSPRINTERLib.AxOPOSPrinter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RETURN_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents RET_CASH_T As System.Windows.Forms.TextBox
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents PRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RET_CASH_B As Softgroup.NetButton.NetButton
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
End Class
