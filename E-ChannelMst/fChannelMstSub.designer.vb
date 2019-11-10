<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fChannelMstSub
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.CHANNEL_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MODE_L = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CHANNEL_NET_CLASS_R = New System.Windows.Forms.RadioButton()
        Me.CHANNEL_REAL_CLASS_R = New System.Windows.Forms.RadioButton()
        Me.URL_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RECEIPT_PRINT_C = New System.Windows.Forms.CheckBox()
        Me.SALES_REGIST_C = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CSV_HEADER_C = New System.Windows.Forms.CheckBox()
        Me.CSV_DETAIL_C = New System.Windows.Forms.CheckBox()
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RETURN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CMS_AMAZON_R = New System.Windows.Forms.RadioButton()
        Me.CMS_SHOPSERV_R = New System.Windows.Forms.RadioButton()
        Me.CMS_RAKUTEN_R = New System.Windows.Forms.RadioButton()
        Me.CMS_YAHOO_R = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(31, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 21)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "チャネルコード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHANNEL_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(129, 45)
        Me.CHANNEL_CODE_T.MaxLength = 13
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(146, 20)
        Me.CHANNEL_CODE_T.TabIndex = 0
        Me.CHANNEL_CODE_T.TabStop = False
        Me.CHANNEL_CODE_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CHANNEL_NAME_T
        '
        Me.CHANNEL_NAME_T.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHANNEL_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NAME_T.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CHANNEL_NAME_T.Location = New System.Drawing.Point(129, 141)
        Me.CHANNEL_NAME_T.MaxLength = 30
        Me.CHANNEL_NAME_T.Name = "CHANNEL_NAME_T"
        Me.CHANNEL_NAME_T.Size = New System.Drawing.Size(379, 20)
        Me.CHANNEL_NAME_T.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(31, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 21)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "チャネル名称"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 21)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "チャネル種別"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MODE_L
        '
        Me.MODE_L.BackColor = System.Drawing.Color.Red
        Me.MODE_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_L.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_L.ForeColor = System.Drawing.Color.White
        Me.MODE_L.Location = New System.Drawing.Point(12, 9)
        Me.MODE_L.Name = "MODE_L"
        Me.MODE_L.Size = New System.Drawing.Size(624, 20)
        Me.MODE_L.TabIndex = 39
        Me.MODE_L.Text = "新規"
        Me.MODE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CHANNEL_NET_CLASS_R)
        Me.GroupBox1.Controls.Add(Me.CHANNEL_REAL_CLASS_R)
        Me.GroupBox1.Location = New System.Drawing.Point(130, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(169, 59)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CHANNEL_NET_CLASS_R
        '
        Me.CHANNEL_NET_CLASS_R.AutoSize = True
        Me.CHANNEL_NET_CLASS_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_NET_CLASS_R.Location = New System.Drawing.Point(17, 34)
        Me.CHANNEL_NET_CLASS_R.Name = "CHANNEL_NET_CLASS_R"
        Me.CHANNEL_NET_CLASS_R.Size = New System.Drawing.Size(133, 19)
        Me.CHANNEL_NET_CLASS_R.TabIndex = 1
        Me.CHANNEL_NET_CLASS_R.Text = "ネット販売チャネル"
        Me.CHANNEL_NET_CLASS_R.UseVisualStyleBackColor = True
        '
        'CHANNEL_REAL_CLASS_R
        '
        Me.CHANNEL_REAL_CLASS_R.AutoSize = True
        Me.CHANNEL_REAL_CLASS_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_REAL_CLASS_R.Location = New System.Drawing.Point(16, 10)
        Me.CHANNEL_REAL_CLASS_R.Name = "CHANNEL_REAL_CLASS_R"
        Me.CHANNEL_REAL_CLASS_R.Size = New System.Drawing.Size(133, 19)
        Me.CHANNEL_REAL_CLASS_R.TabIndex = 0
        Me.CHANNEL_REAL_CLASS_R.Text = "リアル店舗チャネル"
        Me.CHANNEL_REAL_CLASS_R.UseVisualStyleBackColor = True
        '
        'URL_T
        '
        Me.URL_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.URL_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.URL_T.Location = New System.Drawing.Point(129, 167)
        Me.URL_T.MaxLength = 30
        Me.URL_T.Name = "URL_T"
        Me.URL_T.Size = New System.Drawing.Size(489, 20)
        Me.URL_T.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(31, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 21)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "URL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RECEIPT_PRINT_C
        '
        Me.RECEIPT_PRINT_C.AutoSize = True
        Me.RECEIPT_PRINT_C.Location = New System.Drawing.Point(133, 202)
        Me.RECEIPT_PRINT_C.Name = "RECEIPT_PRINT_C"
        Me.RECEIPT_PRINT_C.Size = New System.Drawing.Size(85, 16)
        Me.RECEIPT_PRINT_C.TabIndex = 5
        Me.RECEIPT_PRINT_C.Text = "レシート印刷"
        Me.RECEIPT_PRINT_C.UseVisualStyleBackColor = True
        '
        'SALES_REGIST_C
        '
        Me.SALES_REGIST_C.AutoSize = True
        Me.SALES_REGIST_C.Location = New System.Drawing.Point(238, 202)
        Me.SALES_REGIST_C.Name = "SALES_REGIST_C"
        Me.SALES_REGIST_C.Size = New System.Drawing.Size(72, 16)
        Me.SALES_REGIST_C.TabIndex = 6
        Me.SALES_REGIST_C.Text = "売上計上"
        Me.SALES_REGIST_C.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CSV_HEADER_C)
        Me.GroupBox2.Controls.Add(Me.CSV_DETAIL_C)
        Me.GroupBox2.Location = New System.Drawing.Point(328, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 48)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【受注データCSVファイル】"
        '
        'CSV_HEADER_C
        '
        Me.CSV_HEADER_C.AutoSize = True
        Me.CSV_HEADER_C.Location = New System.Drawing.Point(40, 19)
        Me.CSV_HEADER_C.Name = "CSV_HEADER_C"
        Me.CSV_HEADER_C.Size = New System.Drawing.Size(94, 16)
        Me.CSV_HEADER_C.TabIndex = 0
        Me.CSV_HEADER_C.Text = "ヘッダーファイル"
        Me.CSV_HEADER_C.UseVisualStyleBackColor = True
        '
        'CSV_DETAIL_C
        '
        Me.CSV_DETAIL_C.AutoSize = True
        Me.CSV_DETAIL_C.Location = New System.Drawing.Point(147, 19)
        Me.CSV_DETAIL_C.Name = "CSV_DETAIL_C"
        Me.CSV_DETAIL_C.Size = New System.Drawing.Size(82, 16)
        Me.CSV_DETAIL_C.TabIndex = 1
        Me.CSV_DETAIL_C.Text = "明細ファイル"
        Me.CSV_DETAIL_C.UseVisualStyleBackColor = True
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DELETE_B.Location = New System.Drawing.Point(330, 300)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(98, 41)
        Me.DELETE_B.TabIndex = 8
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(434, 300)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(98, 41)
        Me.COMMIT_B.TabIndex = 9
        Me.COMMIT_B.TextButton = "登　録"
        '
        'RETURN_B
        '
        Me.RETURN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.RETURN_B.Location = New System.Drawing.Point(538, 300)
        Me.RETURN_B.Name = "RETURN_B"
        Me.RETURN_B.Size = New System.Drawing.Size(98, 41)
        Me.RETURN_B.TabIndex = 10
        Me.RETURN_B.TextButton = "戻　る"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CMS_AMAZON_R)
        Me.GroupBox3.Controls.Add(Me.CMS_SHOPSERV_R)
        Me.GroupBox3.Controls.Add(Me.CMS_RAKUTEN_R)
        Me.GroupBox3.Controls.Add(Me.CMS_YAHOO_R)
        Me.GroupBox3.Location = New System.Drawing.Point(130, 224)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 117)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'CMS_AMAZON_R
        '
        Me.CMS_AMAZON_R.AutoSize = True
        Me.CMS_AMAZON_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CMS_AMAZON_R.Location = New System.Drawing.Point(23, 89)
        Me.CMS_AMAZON_R.Name = "CMS_AMAZON_R"
        Me.CMS_AMAZON_R.Size = New System.Drawing.Size(75, 19)
        Me.CMS_AMAZON_R.TabIndex = 3
        Me.CMS_AMAZON_R.Text = "Amazon"
        Me.CMS_AMAZON_R.UseVisualStyleBackColor = True
        '
        'CMS_SHOPSERV_R
        '
        Me.CMS_SHOPSERV_R.AutoSize = True
        Me.CMS_SHOPSERV_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CMS_SHOPSERV_R.Location = New System.Drawing.Point(22, 64)
        Me.CMS_SHOPSERV_R.Name = "CMS_SHOPSERV_R"
        Me.CMS_SHOPSERV_R.Size = New System.Drawing.Size(100, 19)
        Me.CMS_SHOPSERV_R.TabIndex = 2
        Me.CMS_SHOPSERV_R.Text = "ショップサーブ"
        Me.CMS_SHOPSERV_R.UseVisualStyleBackColor = True
        '
        'CMS_RAKUTEN_R
        '
        Me.CMS_RAKUTEN_R.AutoSize = True
        Me.CMS_RAKUTEN_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CMS_RAKUTEN_R.Location = New System.Drawing.Point(22, 40)
        Me.CMS_RAKUTEN_R.Name = "CMS_RAKUTEN_R"
        Me.CMS_RAKUTEN_R.Size = New System.Drawing.Size(85, 19)
        Me.CMS_RAKUTEN_R.TabIndex = 1
        Me.CMS_RAKUTEN_R.Text = "楽天市場"
        Me.CMS_RAKUTEN_R.UseVisualStyleBackColor = True
        '
        'CMS_YAHOO_R
        '
        Me.CMS_YAHOO_R.AutoSize = True
        Me.CMS_YAHOO_R.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CMS_YAHOO_R.Location = New System.Drawing.Point(22, 15)
        Me.CMS_YAHOO_R.Name = "CMS_YAHOO_R"
        Me.CMS_YAHOO_R.Size = New System.Drawing.Size(128, 19)
        Me.CMS_YAHOO_R.TabIndex = 0
        Me.CMS_YAHOO_R.Text = "Yahooショッピング"
        Me.CMS_YAHOO_R.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(31, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 21)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "CMSタイプ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fChannelMstSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(659, 353)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RETURN_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.DELETE_B)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SALES_REGIST_C)
        Me.Controls.Add(Me.RECEIPT_PRINT_C)
        Me.Controls.Add(Me.URL_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.MODE_L)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CHANNEL_NAME_T)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fChannelMstSub"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "チャネルマスタ管理"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents CHANNEL_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MODE_L As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CHANNEL_NET_CLASS_R As System.Windows.Forms.RadioButton
    Friend WithEvents CHANNEL_REAL_CLASS_R As System.Windows.Forms.RadioButton
    Friend WithEvents URL_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RECEIPT_PRINT_C As System.Windows.Forms.CheckBox
    Friend WithEvents SALES_REGIST_C As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CSV_HEADER_C As System.Windows.Forms.CheckBox
    Friend WithEvents CSV_DETAIL_C As System.Windows.Forms.CheckBox
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents RETURN_B As Softgroup.NetButton.NetButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CMS_AMAZON_R As System.Windows.Forms.RadioButton
    Friend WithEvents CMS_SHOPSERV_R As System.Windows.Forms.RadioButton
    Friend WithEvents CMS_RAKUTEN_R As System.Windows.Forms.RadioButton
    Friend WithEvents CMS_YAHOO_R As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
