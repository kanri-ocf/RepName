Public Class fReShipMemo
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
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property


    Private Sub fReShipMemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------


    End Sub

    Private Sub YES_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RESHIP_MEMO_T.Text = "" Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "再出荷事由が未入力です。", _
                                            "事由を入力後、再度「登録」を押下して下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            RESHIP_MEMO_T.Focus()
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub NO_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub YES_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_B.Click
        If RESHIP_MEMO_T.Text = "" Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "再出荷事由が未入力です。", _
                                            "事由を入力後、再度「登録」を押下して下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            RESHIP_MEMO_T.Focus()
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()

    End Sub

    Private Sub NO_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()

    End Sub
End Class
