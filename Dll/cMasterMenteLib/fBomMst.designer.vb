<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fBomMst
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
        Me.MODE_T = New System.Windows.Forms.Label()
        Me.SEARCH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DELETE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.COMMIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.QUIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TREEVIEW = New System.Windows.Forms.TreeView()
        Me.TreeMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCT_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PRODUCT_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.STRUCTURE_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OPTION_NAME_T = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TreeMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MODE_T
        '
        Me.MODE_T.BackColor = System.Drawing.Color.Red
        Me.MODE_T.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MODE_T.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MODE_T.ForeColor = System.Drawing.Color.White
        Me.MODE_T.Location = New System.Drawing.Point(15, 9)
        Me.MODE_T.Name = "MODE_T"
        Me.MODE_T.Size = New System.Drawing.Size(824, 17)
        Me.MODE_T.TabIndex = 128
        Me.MODE_T.Text = "（新規）"
        Me.MODE_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SEARCH_B
        '
        Me.SEARCH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.SEARCH_B.Location = New System.Drawing.Point(677, 56)
        Me.SEARCH_B.Name = "SEARCH_B"
        Me.SEARCH_B.Size = New System.Drawing.Size(149, 66)
        Me.SEARCH_B.TabIndex = 0
        Me.SEARCH_B.TextButton = "検　索"
        '
        'DELETE_B
        '
        Me.DELETE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DELETE_B.Location = New System.Drawing.Point(545, 581)
        Me.DELETE_B.Name = "DELETE_B"
        Me.DELETE_B.Size = New System.Drawing.Size(94, 42)
        Me.DELETE_B.TabIndex = 24
        Me.DELETE_B.TextButton = "削　除"
        '
        'COMMIT_B
        '
        Me.COMMIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.COMMIT_B.Location = New System.Drawing.Point(645, 581)
        Me.COMMIT_B.Name = "COMMIT_B"
        Me.COMMIT_B.Size = New System.Drawing.Size(94, 42)
        Me.COMMIT_B.TabIndex = 26
        Me.COMMIT_B.TextButton = "登　録"
        '
        'QUIT_B
        '
        Me.QUIT_B.ColorBottom = System.Drawing.Color.Wheat
        Me.QUIT_B.Location = New System.Drawing.Point(745, 581)
        Me.QUIT_B.Name = "QUIT_B"
        Me.QUIT_B.Size = New System.Drawing.Size(94, 42)
        Me.QUIT_B.TabIndex = 27
        Me.QUIT_B.TextButton = "終　了"
        '
        'TREEVIEW
        '
        Me.TREEVIEW.ContextMenuStrip = Me.TreeMenu
        Me.TREEVIEW.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TREEVIEW.Indent = 45
        Me.TREEVIEW.ItemHeight = 24
        Me.TREEVIEW.Location = New System.Drawing.Point(15, 138)
        Me.TREEVIEW.Name = "TREEVIEW"
        Me.TREEVIEW.Size = New System.Drawing.Size(824, 429)
        Me.TREEVIEW.TabIndex = 168
        '
        'TreeMenu
        '
        Me.TreeMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Add, Me.Delete})
        Me.TreeMenu.Name = "TreeMenu"
        Me.TreeMenu.Size = New System.Drawing.Size(153, 70)
        Me.TreeMenu.Text = "追加"
        '
        'Add
        '
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(94, 22)
        Me.Add.Text = "追加"
        '
        'Delete
        '
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(94, 22)
        Me.Delete.Text = "削除"
        '
        'PRODUCT_CODE_T
        '
        Me.PRODUCT_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PRODUCT_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_CODE_T.Location = New System.Drawing.Point(119, 56)
        Me.PRODUCT_CODE_T.Name = "PRODUCT_CODE_T"
        Me.PRODUCT_CODE_T.Size = New System.Drawing.Size(129, 20)
        Me.PRODUCT_CODE_T.TabIndex = 169
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "商品コード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRODUCT_NAME_T
        '
        Me.PRODUCT_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PRODUCT_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PRODUCT_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PRODUCT_NAME_T.Location = New System.Drawing.Point(119, 79)
        Me.PRODUCT_NAME_T.Name = "PRODUCT_NAME_T"
        Me.PRODUCT_NAME_T.Size = New System.Drawing.Size(515, 20)
        Me.PRODUCT_NAME_T.TabIndex = 171
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "商品名称："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STRUCTURE_CODE_T
        '
        Me.STRUCTURE_CODE_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.STRUCTURE_CODE_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.STRUCTURE_CODE_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.STRUCTURE_CODE_T.Location = New System.Drawing.Point(254, 56)
        Me.STRUCTURE_CODE_T.Name = "STRUCTURE_CODE_T"
        Me.STRUCTURE_CODE_T.Size = New System.Drawing.Size(60, 20)
        Me.STRUCTURE_CODE_T.TabIndex = 173
        Me.STRUCTURE_CODE_T.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(26, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(481, 15)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "－－－－－ヘッダー品目となる商品（疑似品目）を指定して下さい。－－－－－"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OPTION_NAME_T
        '
        Me.OPTION_NAME_T.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OPTION_NAME_T.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OPTION_NAME_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.OPTION_NAME_T.Location = New System.Drawing.Point(118, 102)
        Me.OPTION_NAME_T.Name = "OPTION_NAME_T"
        Me.OPTION_NAME_T.Size = New System.Drawing.Size(516, 20)
        Me.OPTION_NAME_T.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "オプション名称："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fBomMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(857, 644)
        Me.Controls.Add(Me.OPTION_NAME_T)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PRODUCT_NAME_T)
        Me.Controls.Add(Me.STRUCTURE_CODE_T)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PRODUCT_CODE_T)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TREEVIEW)
        Me.Controls.Add(Me.QUIT_B)
        Me.Controls.Add(Me.SEARCH_B)
        Me.Controls.Add(Me.COMMIT_B)
        Me.Controls.Add(Me.MODE_T)
        Me.Controls.Add(Me.DELETE_B)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fBomMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "構成マスタ編集画面"
        Me.TreeMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MODE_T As System.Windows.Forms.Label
    Friend WithEvents SEARCH_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELETE_B As Softgroup.NetButton.NetButton
    Friend WithEvents COMMIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents QUIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents TREEVIEW As System.Windows.Forms.TreeView
    Friend WithEvents PRODUCT_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PRODUCT_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STRUCTURE_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OPTION_NAME_T As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
