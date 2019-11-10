<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDisplay))
        Me.AxOPOSDISP_TEC = New AxOPOSDISPLib.AxOPOSDISP
        Me.AxOPOSDISP_EPSON = New AxOposLineDisplay_CCO.AxOPOSLineDisplay
        CType(Me.AxOPOSDISP_TEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSDISP_EPSON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxOPOSDISP_TEC
        '
        Me.AxOPOSDISP_TEC.Enabled = True
        Me.AxOPOSDISP_TEC.Location = New System.Drawing.Point(102, 26)
        Me.AxOPOSDISP_TEC.Name = "AxOPOSDISP_TEC"
        Me.AxOPOSDISP_TEC.OcxState = CType(resources.GetObject("AxOPOSDISP_TEC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDISP_TEC.Size = New System.Drawing.Size(28, 28)
        Me.AxOPOSDISP_TEC.TabIndex = 1
        '
        'AxOPOSDISP_EPSON
        '
        Me.AxOPOSDISP_EPSON.Enabled = True
        Me.AxOPOSDISP_EPSON.Location = New System.Drawing.Point(31, 26)
        Me.AxOPOSDISP_EPSON.Name = "AxOPOSDISP_EPSON"
        Me.AxOPOSDISP_EPSON.OcxState = CType(resources.GetObject("AxOPOSDISP_EPSON.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDISP_EPSON.Size = New System.Drawing.Size(35, 27)
        Me.AxOPOSDISP_EPSON.TabIndex = 2
        '
        'cDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(178, 110)
        Me.Controls.Add(Me.AxOPOSDISP_EPSON)
        Me.Controls.Add(Me.AxOPOSDISP_TEC)
        Me.Name = "cDisplay"
        Me.Text = "cDisplay"
        CType(Me.AxOPOSDISP_TEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSDISP_EPSON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxOPOSDISP_TEC As AxOPOSDISPLib.AxOPOSDISP
    Friend WithEvents AxOPOSDISP_EPSON As AxOposLineDisplay_CCO.AxOPOSLineDisplay
End Class
