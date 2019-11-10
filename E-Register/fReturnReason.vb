Public Class fReturnReason

    Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

    End Sub



    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
    '*
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    'Const WM_SYSCOMMAND As Integer = &H112
    'Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub

    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property

    Private Sub OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click

        Me.Close()

    End Sub

    'TOOD:対応方法が不要な箇所はグレーアウト
    'Private Sub REASON_1_R_CheckedChanged(sender As Object, e As EventArgs) Handles REASON_4_R.CheckedChanged
    '    RESULT_1_R.Enabled = True
    '    RESULT_2_R.Enabled = True
    'End Sub
    'Private Sub REASON_2_R_CheckedChanged(sender As Object, e As EventArgs) Handles REASON_4_R.CheckedChanged
    '    RESULT_1_R.Enabled = True
    '    RESULT_2_R.Enabled = True
    'End Sub
    'Private Sub REASON_3_R_CheckedChanged(sender As Object, e As EventArgs) Handles REASON_4_R.CheckedChanged
    '    RESULT_1_R.Enabled = True
    '    RESULT_2_R.Enabled = True
    'End Sub
    'Private Sub REASON_4_R_CheckedChanged(sender As Object, e As EventArgs) Handles REASON_4_R.CheckedChanged
    '    RESULT_1_R.Enabled = False
    '    RESULT_2_R.Enabled = False
    'End Sub
End Class
