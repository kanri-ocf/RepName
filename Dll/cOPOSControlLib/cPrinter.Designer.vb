<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cPrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cPrinter))
        Me.AxOPOSPTR_TEC = New AxOPOSPRINTERLib.AxOPOSPrinter()
        Me.AxOPOSPTR_EPSON = New AxOposPOSPrinter_CCO.AxOPOSPOSPrinter()
        Me.AxOPOSPTR_STAR = New AxOposPOSPrinter_CCO.AxOPOSPOSPrinter()
        CType(Me.AxOPOSPTR_TEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSPTR_EPSON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSPTR_STAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxOPOSPTR_TEC
        '
        Me.AxOPOSPTR_TEC.Enabled = True
        Me.AxOPOSPTR_TEC.Location = New System.Drawing.Point(90, 25)
        Me.AxOPOSPTR_TEC.Name = "AxOPOSPTR_TEC"
        Me.AxOPOSPTR_TEC.OcxState = CType(resources.GetObject("AxOPOSPTR_TEC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSPTR_TEC.Size = New System.Drawing.Size(28, 28)
        Me.AxOPOSPTR_TEC.TabIndex = 1
        '
        'AxOPOSPTR_EPSON
        '
        Me.AxOPOSPTR_EPSON.Enabled = True
        Me.AxOPOSPTR_EPSON.Location = New System.Drawing.Point(18, 24)
        Me.AxOPOSPTR_EPSON.Name = "AxOPOSPTR_EPSON"
        Me.AxOPOSPTR_EPSON.OcxState = CType(resources.GetObject("AxOPOSPTR_EPSON.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSPTR_EPSON.Size = New System.Drawing.Size(32, 28)
        Me.AxOPOSPTR_EPSON.TabIndex = 2
        '
        'AxOPOSPTR_STAR
        '
        Me.AxOPOSPTR_STAR.Enabled = True
        Me.AxOPOSPTR_STAR.Location = New System.Drawing.Point(47, 61)
        Me.AxOPOSPTR_STAR.Name = "AxOPOSPTR_STAR"
        Me.AxOPOSPTR_STAR.OcxState = CType(resources.GetObject("AxOPOSPTR_STAR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSPTR_STAR.Size = New System.Drawing.Size(37, 33)
        Me.AxOPOSPTR_STAR.TabIndex = 3
        '
        'cPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(152, 106)
        Me.Controls.Add(Me.AxOPOSPTR_STAR)
        Me.Controls.Add(Me.AxOPOSPTR_EPSON)
        Me.Controls.Add(Me.AxOPOSPTR_TEC)
        Me.Name = "cPrinter"
        Me.Text = "cPrinter"
        CType(Me.AxOPOSPTR_TEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSPTR_EPSON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSPTR_STAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxOPOSPTR_TEC As AxOPOSPRINTERLib.AxOPOSPrinter
    Friend WithEvents AxOPOSPTR_EPSON As AxOposPOSPrinter_CCO.AxOPOSPOSPrinter
    Friend WithEvents AxOPOSPTR_STAR As AxOposPOSPrinter_CCO.AxOPOSPOSPrinter
End Class
