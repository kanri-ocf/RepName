<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDisplay
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDisplay))
        Me.AxOPOSDISP_TEC = New AxOPOSDISPLib.AxOPOSDISP()
        Me.AxOPOSDISP_EPSON = New AxOPOSDISPLib.AxOPOSDISP()
        CType(Me.AxOPOSDISP_TEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxOPOSDISP_EPSON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxOPOSDISP_TEC
        '
        Me.AxOPOSDISP_TEC.Enabled = True
        Me.AxOPOSDISP_TEC.Location = New System.Drawing.Point(66, 25)
        Me.AxOPOSDISP_TEC.Name = "AxOPOSDISP_TEC"
        Me.AxOPOSDISP_TEC.OcxState = CType(resources.GetObject("AxOPOSDISP_TEC.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDISP_TEC.Size = New System.Drawing.Size(28, 28)
        Me.AxOPOSDISP_TEC.TabIndex = 0
        '
        'AxOPOSDISP_EPSON
        '
        Me.AxOPOSDISP_EPSON.Enabled = True
        Me.AxOPOSDISP_EPSON.Location = New System.Drawing.Point(159, 89)
        Me.AxOPOSDISP_EPSON.Name = "AxOPOSDISP_EPSON"
        Me.AxOPOSDISP_EPSON.OcxState = CType(resources.GetObject("AxOPOSDISP_EPSON.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxOPOSDISP_EPSON.Size = New System.Drawing.Size(28, 28)
        Me.AxOPOSDISP_EPSON.TabIndex = 1
        '
        'cDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 228)
        Me.Controls.Add(Me.AxOPOSDISP_EPSON)
        Me.Controls.Add(Me.AxOPOSDISP_TEC)
        Me.Name = "cDisplay"
        Me.Text = "Form1"
        CType(Me.AxOPOSDISP_TEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxOPOSDISP_EPSON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AxOPOSDISP_TEC As AxOPOSDISPLib.AxOPOSDISP
    Friend WithEvents AxOPOSDISP_EPSON As AxOPOSDISPLib.AxOPOSDISP
End Class
