<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cScanner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cScanner))
        'TODO:スキャナーを一旦コメントアウト
        'Me.AxOPOSSCAN_STAR = New AxOposScanner_CCO.AxOPOSScanner()
        'CType(Me.AxOPOSSCAN_STAR, System.ComponentModel.ISupportInitialize).BeginInit()
        'Me.SuspendLayout()
        ''
        ''AxOPOSSCAN_STAR
        ''
        'Me.AxOPOSSCAN_STAR.Enabled = True
        'Me.AxOPOSSCAN_STAR.Location = New System.Drawing.Point(60, 40)
        'Me.AxOPOSSCAN_STAR.Name = "AxOPOSSCAN_STAR"
        'Me.AxOPOSSCAN_STAR.OcxState = CType(resources.GetObject("AxOPOSSCAN_STAR.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.AxOPOSSCAN_STAR.Size = New System.Drawing.Size(36, 30)
        'Me.AxOPOSSCAN_STAR.TabIndex = 0
        '
        'TODO:スキャナーを一旦コメントアウト
        ''cScanner
        ''
        'Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        'Me.ClientSize = New System.Drawing.Size(235, 150)
        'Me.Controls.Add(Me.AxOPOSSCAN_STAR)
        'Me.Name = "cScanner"
        'Me.Text = "cScanner"
        'CType(Me.AxOPOSSCAN_STAR, System.ComponentModel.ISupportInitialize).EndInit()
        'Me.ResumeLayout(False)

    End Sub

    'TODO:スキャナーを一旦コメントアウト
    'Friend WithEvents AxOPOSSCAN_STAR As AxOposScanner_CCO.AxOPOSScanner
End Class
