﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fTagReportPage
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
        Me.MESSAGE_1_T = New System.Windows.Forms.Label()
        Me.CHANNEL_L = New System.Windows.Forms.ComboBox()
        Me.CHANNEL_CODE_T = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TYPE_C = New System.Windows.Forms.ComboBox()
        Me.OK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CANCEL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SuspendLayout()
        '
        'MESSAGE_1_T
        '
        Me.MESSAGE_1_T.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MESSAGE_1_T.Location = New System.Drawing.Point(63, 34)
        Me.MESSAGE_1_T.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.MESSAGE_1_T.Name = "MESSAGE_1_T"
        Me.MESSAGE_1_T.Size = New System.Drawing.Size(934, 134)
        Me.MESSAGE_1_T.TabIndex = 15
        Me.MESSAGE_1_T.Text = "タグ出力するチャネルおよびタイプを指定して下さい。"
        Me.MESSAGE_1_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CHANNEL_L
        '
        Me.CHANNEL_L.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CHANNEL_L.FormattingEnabled = True
        Me.CHANNEL_L.Location = New System.Drawing.Point(364, 210)
        Me.CHANNEL_L.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CHANNEL_L.Name = "CHANNEL_L"
        Me.CHANNEL_L.Size = New System.Drawing.Size(552, 46)
        Me.CHANNEL_L.TabIndex = 1
        '
        'CHANNEL_CODE_T
        '
        Me.CHANNEL_CODE_T.BackColor = System.Drawing.Color.LightGray
        Me.CHANNEL_CODE_T.Location = New System.Drawing.Point(609, 494)
        Me.CHANNEL_CODE_T.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CHANNEL_CODE_T.Name = "CHANNEL_CODE_T"
        Me.CHANNEL_CODE_T.Size = New System.Drawing.Size(102, 31)
        Me.CHANNEL_CODE_T.TabIndex = 17
        Me.CHANNEL_CODE_T.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(221, 218)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 33)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "チャネル："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(91, 288)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 33)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "タグシールのタイプ："
        '
        'TYPE_C
        '
        Me.TYPE_C.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TYPE_C.FormattingEnabled = True
        Me.TYPE_C.Location = New System.Drawing.Point(377, 274)
        Me.TYPE_C.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TYPE_C.Name = "TYPE_C"
        Me.TYPE_C.Size = New System.Drawing.Size(552, 46)
        Me.TYPE_C.TabIndex = 2
        Me.TYPE_C.Text = "バーコード無し(A-One 28879)"
        '
        'OK_B
        '
        Me.OK_B.ColorBottom = System.Drawing.Color.Tan
        Me.OK_B.Location = New System.Drawing.Point(609, 396)
        Me.OK_B.Margin = New System.Windows.Forms.Padding(15, 12, 15, 12)
        Me.OK_B.Name = "OK_B"
        Me.OK_B.Size = New System.Drawing.Size(267, 86)
        Me.OK_B.TabIndex = 3
        Me.OK_B.TextButton = "OK"
        '
        'CANCEL_B
        '
        Me.CANCEL_B.ColorBottom = System.Drawing.Color.Tan
        Me.CANCEL_B.Location = New System.Drawing.Point(228, 396)
        Me.CANCEL_B.Margin = New System.Windows.Forms.Padding(15, 12, 15, 12)
        Me.CANCEL_B.Name = "CANCEL_B"
        Me.CANCEL_B.Size = New System.Drawing.Size(267, 86)
        Me.CANCEL_B.TabIndex = 4
        Me.CANCEL_B.TextButton = "キャンセル"
        '
        'fTagReportPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1055, 562)
        Me.Controls.Add(Me.CANCEL_B)
        Me.Controls.Add(Me.OK_B)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TYPE_C)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CHANNEL_CODE_T)
        Me.Controls.Add(Me.CHANNEL_L)
        Me.Controls.Add(Me.MESSAGE_1_T)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "fTagReportPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fReportPage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OrderReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MESSAGE_1_T As System.Windows.Forms.Label
    Friend WithEvents CHANNEL_L As System.Windows.Forms.ComboBox
    Friend WithEvents CHANNEL_CODE_T As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TYPE_C As System.Windows.Forms.ComboBox
    Friend WithEvents OK_B As Softgroup.NetButton.NetButton
    Friend WithEvents CANCEL_B As Softgroup.NetButton.NetButton
End Class
