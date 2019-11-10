Public Class fProgressMessage
    Private pMode As Integer
    Private pMessage1 As String
    Private pMessage2 As String
    '********************************
    '共通メッセージウィンドウ
    '  Mode         0: ボタンなし
    '               1: OKボタンあり
    '　Message1　　 上段のメッセージ
    '　Message2　　 下段のメッセージ
    '********************************
    Sub New(ByVal Mode As Integer, _
            ByVal Message1 As String, _
            ByVal Message2 As String)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        pMode = Mode
        pMessage1 = Message1
        pMessage2 = Message2
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


    Private Sub fProgressMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        MESSAGE1_L.Text = pMessage1
        MESSAGE2_L.Text = pMessage2

    End Sub

End Class