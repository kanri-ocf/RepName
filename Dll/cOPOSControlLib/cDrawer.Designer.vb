<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDrawer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDrawer))
        Me.AxOPOSDRW_TEC = New AxOPOSDRWLib.AxOPOSDRW()
        Me.AxOPOSDRW_EPSON = New AxOposCashDrawer_CCO.AxOPOSCashDrawer()
        Me.AxOPOSDRW_STAR = New AxOposCashDrawer_CCO.AxOPOSCashDrawer()
        CType(Me.AxOPOSDRW_TEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSDRW_EPSON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSDRW_STAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxOPOSDRW_TEC
        '
        Me.AxOPOSDRW_TEC.Enabled = True
        Me.AxOPOSDRW_TEC.Location = New System.Drawing.Point(109, 22)
        Me.AxOPOSDRW_TEC.Name = "AxOPOSDRW_TEC"
        Me.AxOPOSDRW_TEC.OcxState = CType(resources.GetObject("AxOPOSDRW_TEC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDRW_TEC.Size = New System.Drawing.Size(28, 28)
        Me.AxOPOSDRW_TEC.TabIndex = 1
        '
        'AxOPOSDRW_EPSON
        '
        Me.AxOPOSDRW_EPSON.Enabled = True
        Me.AxOPOSDRW_EPSON.Location = New System.Drawing.Point(25, 21)
        Me.AxOPOSDRW_EPSON.Name = "AxOPOSDRW_EPSON"
        Me.AxOPOSDRW_EPSON.OcxState = CType(resources.GetObject("AxOPOSDRW_EPSON.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDRW_EPSON.Size = New System.Drawing.Size(46, 45)
        Me.AxOPOSDRW_EPSON.TabIndex = 2
        '
        'AxOPOSDRW_STAR
        '
        Me.AxOPOSDRW_STAR.Enabled = True
        Me.AxOPOSDRW_STAR.Location = New System.Drawing.Point(25, 72)
        Me.AxOPOSDRW_STAR.Name = "AxOPOSDRW_STAR"
        Me.AxOPOSDRW_STAR.OcxState = CType(resources.GetObject("AxOPOSDRW_STAR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDRW_STAR.Size = New System.Drawing.Size(46, 37)
        Me.AxOPOSDRW_STAR.TabIndex = 3
        '
        'cDrawer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 150)
        Me.Controls.Add(Me.AxOPOSDRW_STAR)
        Me.Controls.Add(Me.AxOPOSDRW_EPSON)
        Me.Controls.Add(Me.AxOPOSDRW_TEC)
        Me.Name = "cDrawer"
        Me.Text = "cDrawer"
        CType(Me.AxOPOSDRW_TEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSDRW_EPSON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSDRW_STAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxOPOSDRW_TEC As AxOPOSDRWLib.AxOPOSDRW
    Friend WithEvents AxOPOSDRW_EPSON As AxOposCashDrawer_CCO.AxOPOSCashDrawer
    Friend WithEvents AxOPOSDRW_STAR As AxOposCashDrawer_CCO.AxOPOSCashDrawer
End Class
