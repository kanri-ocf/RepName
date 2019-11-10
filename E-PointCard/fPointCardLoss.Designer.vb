<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPointCardLoss
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPointCardLoss))
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.FROM_POINT_MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TO_POINT_MEMBER_CODE_T = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.POINT_CNT_T = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ENTRY_DATE_T = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TEL_T = New System.Windows.Forms.TextBox
        Me.POINT_MEMBER_NAME_T = New System.Windows.Forms.TextBox
        Me.FROM_ENABLE_T = New System.Windows.Forms.TextBox
        Me.TO_ENABLE_T = New System.Windows.Forms.TextBox
        Me.COPY_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PRINT_C = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(375, 338)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(134, 46)
        Me.COMMIT_B.TabIndex = 7
        Me.COMMIT_B.TextButton = "再発行"
        '
        'FROM_POINT_MEMBER_CODE_T
        '
        Me.FROM_POINT_MEMBER_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FROM_POINT_MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_POINT_MEMBER_CODE_T.Location = New System.Drawing.Point(209, 93)
        Me.FROM_POINT_MEMBER_CODE_T.Name = "FROM_POINT_MEMBER_CODE_T"
        Me.FROM_POINT_MEMBER_CODE_T.Size = New System.Drawing.Size(214, 31)
        Me.FROM_POINT_MEMBER_CODE_T.TabIndex = 1
        Me.FROM_POINT_MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "紛失カード番号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "再発行カード番号："
        '
        'TO_POINT_MEMBER_CODE_T
        '
        Me.TO_POINT_MEMBER_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TO_POINT_MEMBER_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_POINT_MEMBER_CODE_T.Location = New System.Drawing.Point(209, 263)
        Me.TO_POINT_MEMBER_CODE_T.Name = "TO_POINT_MEMBER_CODE_T"
        Me.TO_POINT_MEMBER_CODE_T.Size = New System.Drawing.Size(214, 31)
        Me.TO_POINT_MEMBER_CODE_T.TabIndex = 3
        Me.TO_POINT_MEMBER_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(271, 207)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(143, 338)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(134, 46)
        Me.RETURN_B.TabIndex = 6
        Me.RETURN_B.TextButton = "戻　る"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(144, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(348, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "紛失カードの会員情報およびポイント数を移行します。"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(115, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(394, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "移行後、紛失カードは利用不可となりますのでご注意下さい。"
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(429, 87)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(121, 42)
        Me.SEARCH_B.TabIndex = 2
        Me.SEARCH_B.TextButton = "ポイント会員検索"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.POINT_CNT_T)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ENTRY_DATE_T)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TEL_T)
        Me.GroupBox1.Controls.Add(Me.POINT_MEMBER_NAME_T)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 60)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【会員情報】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(217, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "保有ポイント数："
        '
        'POINT_CNT_T
        '
        Me.POINT_CNT_T.BackColor = System.Drawing.Color.Wheat
        Me.POINT_CNT_T.Location = New System.Drawing.Point(309, 36)
        Me.POINT_CNT_T.Name = "POINT_CNT_T"
        Me.POINT_CNT_T.ReadOnly = True
        Me.POINT_CNT_T.Size = New System.Drawing.Size(98, 19)
        Me.POINT_CNT_T.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(230, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "契約開始日："
        '
        'ENTRY_DATE_T
        '
        Me.ENTRY_DATE_T.BackColor = System.Drawing.Color.Wheat
        Me.ENTRY_DATE_T.Location = New System.Drawing.Point(309, 13)
        Me.ENTRY_DATE_T.Name = "ENTRY_DATE_T"
        Me.ENTRY_DATE_T.ReadOnly = True
        Me.ENTRY_DATE_T.Size = New System.Drawing.Size(127, 19)
        Me.ENTRY_DATE_T.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "TEL："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "会員名称："
        '
        'TEL_T
        '
        Me.TEL_T.BackColor = System.Drawing.Color.Wheat
        Me.TEL_T.Location = New System.Drawing.Point(82, 36)
        Me.TEL_T.Name = "TEL_T"
        Me.TEL_T.ReadOnly = True
        Me.TEL_T.Size = New System.Drawing.Size(127, 19)
        Me.TEL_T.TabIndex = 14
        '
        'POINT_MEMBER_NAME_T
        '
        Me.POINT_MEMBER_NAME_T.BackColor = System.Drawing.Color.Wheat
        Me.POINT_MEMBER_NAME_T.Location = New System.Drawing.Point(82, 13)
        Me.POINT_MEMBER_NAME_T.Name = "POINT_MEMBER_NAME_T"
        Me.POINT_MEMBER_NAME_T.ReadOnly = True
        Me.POINT_MEMBER_NAME_T.Size = New System.Drawing.Size(127, 19)
        Me.POINT_MEMBER_NAME_T.TabIndex = 0
        '
        'FROM_ENABLE_T
        '
        Me.FROM_ENABLE_T.BackColor = System.Drawing.Color.Tan
        Me.FROM_ENABLE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FROM_ENABLE_T.Location = New System.Drawing.Point(556, 98)
        Me.FROM_ENABLE_T.Name = "FROM_ENABLE_T"
        Me.FROM_ENABLE_T.Size = New System.Drawing.Size(35, 31)
        Me.FROM_ENABLE_T.TabIndex = 14
        Me.FROM_ENABLE_T.Visible = False
        '
        'TO_ENABLE_T
        '
        Me.TO_ENABLE_T.BackColor = System.Drawing.Color.Tan
        Me.TO_ENABLE_T.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TO_ENABLE_T.Location = New System.Drawing.Point(556, 260)
        Me.TO_ENABLE_T.Name = "TO_ENABLE_T"
        Me.TO_ENABLE_T.Size = New System.Drawing.Size(35, 31)
        Me.TO_ENABLE_T.TabIndex = 15
        Me.TO_ENABLE_T.Text = "zzz"
        Me.TO_ENABLE_T.Visible = False
        '
        'COPY_B
        '
        Me.COPY_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COPY_B.Location = New System.Drawing.Point(429, 263)
        Me.COPY_B.Name = "COPY_B"
        Me.COPY_B.Size = New System.Drawing.Size(105, 31)
        Me.COPY_B.TabIndex = 4
        Me.COPY_B.TextButton = "同一番号コピー"
        '
        'PRINT_C
        '
        Me.PRINT_C.AutoSize = True
        Me.PRINT_C.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRINT_C.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRINT_C.Location = New System.Drawing.Point(231, 300)
        Me.PRINT_C.Name = "PRINT_C"
        Me.PRINT_C.Size = New System.Drawing.Size(183, 19)
        Me.PRINT_C.TabIndex = 5
        Me.PRINT_C.Text = "カードの発行（印刷）を行う"
        Me.PRINT_C.UseVisualStyleBackColor = True
        '
        'fPointCardLoss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(610, 405)
        Me.Controls.Add(Me.PRINT_C)
        Me.Controls.Add(Me.COPY_B)
        Me.Controls.Add(Me.TO_ENABLE_T)
        Me.Controls.Add(Me.FROM_ENABLE_T)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TO_POINT_MEMBER_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FROM_POINT_MEMBER_CODE_T)
        Me.Controls.Add(Me.COMMIT_B)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPointCardLoss"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ポイント会員管理"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents FROM_POINT_MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TO_POINT_MEMBER_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents POINT_MEMBER_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents POINT_CNT_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ENTRY_DATE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TEL_T As System.Windows.Forms.TextBox
    Friend WithEvents FROM_ENABLE_T As System.Windows.Forms.TextBox
    Friend WithEvents TO_ENABLE_T As System.Windows.Forms.TextBox
    Friend WithEvents COPY_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRINT_C As System.Windows.Forms.CheckBox
End Class
