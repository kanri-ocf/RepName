<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCreateTool
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.STAFF_B = New System.Windows.Forms.Button()
        Me.IMAGE_GET_B = New System.Windows.Forms.Button()
        Me.LIB_IMG_B = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.BIRDIE_B = New System.Windows.Forms.Button()
        Me.PAGE_L = New System.Windows.Forms.Label()
        Me.KCOLLECTION_B = New System.Windows.Forms.Button()
        Me.PETIO_B = New System.Windows.Forms.Button()
        Me.PETIO_FILE_B = New System.Windows.Forms.Button()
        Me.FileToClass_B = New System.Windows.Forms.Button()
        Me.SourceClassChange_B = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TRN_B = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(47, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(202, 65)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "独自JANコード発番処理開始"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(45, 85)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(202, 65)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "会員コード発番処理"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'STAFF_B
        '
        Me.STAFF_B.Location = New System.Drawing.Point(45, 158)
        Me.STAFF_B.Name = "STAFF_B"
        Me.STAFF_B.Size = New System.Drawing.Size(202, 65)
        Me.STAFF_B.TabIndex = 2
        Me.STAFF_B.Text = "スタッフコード発番処理"
        Me.STAFF_B.UseVisualStyleBackColor = True
        '
        'IMAGE_GET_B
        '
        Me.IMAGE_GET_B.Location = New System.Drawing.Point(255, 12)
        Me.IMAGE_GET_B.Name = "IMAGE_GET_B"
        Me.IMAGE_GET_B.Size = New System.Drawing.Size(166, 65)
        Me.IMAGE_GET_B.TabIndex = 3
        Me.IMAGE_GET_B.Text = "Yahoo画像の取得"
        Me.IMAGE_GET_B.UseVisualStyleBackColor = True
        '
        'LIB_IMG_B
        '
        Me.LIB_IMG_B.Location = New System.Drawing.Point(255, 85)
        Me.LIB_IMG_B.Name = "LIB_IMG_B"
        Me.LIB_IMG_B.Size = New System.Drawing.Size(166, 65)
        Me.LIB_IMG_B.TabIndex = 5
        Me.LIB_IMG_B.Text = "YahooLib画像の取得"
        Me.LIB_IMG_B.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(50, 321)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(681, 23)
        Me.ProgressBar.TabIndex = 6
        '
        'BIRDIE_B
        '
        Me.BIRDIE_B.Location = New System.Drawing.Point(255, 158)
        Me.BIRDIE_B.Name = "BIRDIE_B"
        Me.BIRDIE_B.Size = New System.Drawing.Size(166, 65)
        Me.BIRDIE_B.TabIndex = 7
        Me.BIRDIE_B.Text = "BIRDIE画像の取得"
        Me.BIRDIE_B.UseVisualStyleBackColor = True
        '
        'PAGE_L
        '
        Me.PAGE_L.AutoSize = True
        Me.PAGE_L.Location = New System.Drawing.Point(276, 306)
        Me.PAGE_L.Name = "PAGE_L"
        Me.PAGE_L.Size = New System.Drawing.Size(71, 12)
        Me.PAGE_L.TabIndex = 8
        Me.PAGE_L.Text = "進捗状況・・・"
        Me.PAGE_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KCOLLECTION_B
        '
        Me.KCOLLECTION_B.Location = New System.Drawing.Point(427, 12)
        Me.KCOLLECTION_B.Name = "KCOLLECTION_B"
        Me.KCOLLECTION_B.Size = New System.Drawing.Size(159, 65)
        Me.KCOLLECTION_B.TabIndex = 9
        Me.KCOLLECTION_B.Text = "KCOLLECTION画像の取得"
        Me.KCOLLECTION_B.UseVisualStyleBackColor = True
        '
        'PETIO_B
        '
        Me.PETIO_B.Location = New System.Drawing.Point(427, 85)
        Me.PETIO_B.Name = "PETIO_B"
        Me.PETIO_B.Size = New System.Drawing.Size(159, 65)
        Me.PETIO_B.TabIndex = 10
        Me.PETIO_B.Text = "PETIO画像の取得"
        Me.PETIO_B.UseVisualStyleBackColor = True
        '
        'PETIO_FILE_B
        '
        Me.PETIO_FILE_B.Location = New System.Drawing.Point(427, 158)
        Me.PETIO_FILE_B.Name = "PETIO_FILE_B"
        Me.PETIO_FILE_B.Size = New System.Drawing.Size(159, 65)
        Me.PETIO_FILE_B.TabIndex = 11
        Me.PETIO_FILE_B.Text = "PETIO画像ファイル名変更"
        Me.PETIO_FILE_B.UseVisualStyleBackColor = True
        '
        'FileToClass_B
        '
        Me.FileToClass_B.Location = New System.Drawing.Point(592, 156)
        Me.FileToClass_B.Name = "FileToClass_B"
        Me.FileToClass_B.Size = New System.Drawing.Size(159, 65)
        Me.FileToClass_B.TabIndex = 12
        Me.FileToClass_B.Text = "ファイル名⇒クラス名"
        Me.FileToClass_B.UseVisualStyleBackColor = True
        '
        'SourceClassChange_B
        '
        Me.SourceClassChange_B.Location = New System.Drawing.Point(253, 229)
        Me.SourceClassChange_B.Name = "SourceClassChange_B"
        Me.SourceClassChange_B.Size = New System.Drawing.Size(168, 65)
        Me.SourceClassChange_B.TabIndex = 13
        Me.SourceClassChange_B.Text = "ソース内クラス名変換"
        Me.SourceClassChange_B.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(427, 229)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(159, 65)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "価格⇒単価へ"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(592, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(159, 65)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "カーソル数確認"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(592, 85)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(159, 65)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "楽天消費税調整"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TRN_B
        '
        Me.TRN_B.Location = New System.Drawing.Point(45, 229)
        Me.TRN_B.Name = "TRN_B"
        Me.TRN_B.Size = New System.Drawing.Size(202, 65)
        Me.TRN_B.TabIndex = 17
        Me.TRN_B.Text = "取引コード発番処理"
        Me.TRN_B.UseVisualStyleBackColor = True
        '
        'fCreateTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 384)
        Me.Controls.Add(Me.TRN_B)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.SourceClassChange_B)
        Me.Controls.Add(Me.FileToClass_B)
        Me.Controls.Add(Me.PETIO_FILE_B)
        Me.Controls.Add(Me.PETIO_B)
        Me.Controls.Add(Me.KCOLLECTION_B)
        Me.Controls.Add(Me.PAGE_L)
        Me.Controls.Add(Me.BIRDIE_B)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.LIB_IMG_B)
        Me.Controls.Add(Me.IMAGE_GET_B)
        Me.Controls.Add(Me.STAFF_B)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "fCreateTool"
        Me.Text = "Eazy_POS　業務ツール"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents STAFF_B As System.Windows.Forms.Button
    Friend WithEvents IMAGE_GET_B As System.Windows.Forms.Button
    Friend WithEvents LIB_IMG_B As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BIRDIE_B As System.Windows.Forms.Button
    Friend WithEvents PAGE_L As System.Windows.Forms.Label
    Friend WithEvents KCOLLECTION_B As System.Windows.Forms.Button
    Friend WithEvents PETIO_B As System.Windows.Forms.Button
    Friend WithEvents PETIO_FILE_B As System.Windows.Forms.Button
    Friend WithEvents FileToClass_B As System.Windows.Forms.Button
    Friend WithEvents SourceClassChange_B As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TRN_B As System.Windows.Forms.Button

End Class
