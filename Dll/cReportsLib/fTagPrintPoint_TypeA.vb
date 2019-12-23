Public Class fTagPrintPoint_TypeA
    Private oTool As cTool


    Private Sub fTagPrintPoint_TypeA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

    End Sub
    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_CLOSE As Integer = &HF060
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
            Return  ' Windows標準の処理は行わない
        End If
        MyBase.WndProc(m)
    End Sub
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

    Private Sub OK_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click
        oTool = Nothing
        If POINT_T.Text = "" Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "タグ印刷時のスタート位置を",
                                            "指定して下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            POINT_T.Focus()
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_B.Click
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub LOC_1_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_1_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_2_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_2_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_3_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_3_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_4_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_4_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_5_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_5_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_6_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_6_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_7_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_7_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_8_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_8_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_9_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_9_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_10_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_10_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_11_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_11_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_12_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_12_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_13_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_13_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_14_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_14_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_15_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_15_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_16_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_16_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_17_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_17_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_18_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_18_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_19_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_19_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_20_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_20_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_21_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_21_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_22_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_22_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_23_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_23_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_24_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_24_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_25_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_25_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_26_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_26_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_27_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_27_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_28_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_28_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_29_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_29_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_30_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_30_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_31_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_31_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_32_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_32_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_33_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_33_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_34_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_34_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_35_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_35_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_36_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_36_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_37_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_37_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_38_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_38_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_39_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_39_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_40_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_40_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_41_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_41_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_42_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_42_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_43_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_43_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub

    Private Sub LOC_44_B_Click_1(ByVal sender As Softgroup.NetButton.NetButton, ByVal e As System.EventArgs) Handles LOC_44_B.Click
        POINT_T.Text = sender.TextButton
        OK_B.Focus()

    End Sub
End Class
