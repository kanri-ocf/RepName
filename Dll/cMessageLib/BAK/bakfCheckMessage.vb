Public Class fCheckMessage
    Private pLabelMessage As String
    Private pCheckMessage As String
    Private pCheckStatus As Boolean

    Sub New(ByVal LabelMessage As String, _
            ByVal CheckMessage As String, _
            ByVal CheckStatus As Boolean)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        pLabelMessage = LabelMessage
        pCheckMessage = CheckMessage
        pCheckStatus = CheckStatus
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
    Private Sub fMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

    End Sub
    Private Sub OK_BUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_BUTTON.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            pCheckStatus = True
        Else
            pCheckStatus = False
        End If
    End Sub

    Private Sub fCheckMessage_Show(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' ラベルのメッセージ設定
        If pLabelMessage = "" Or pLabelMessage Is Nothing Then
            MESSAGE1.Visible = False
        Else
            MESSAGE1.Visible = True
            MESSAGE1.Text = pLabelMessage
        End If

        'チェックボックスのメッセージ設定
        If pCheckMessage = "" Or pCheckMessage Is Nothing Then
            CheckBox1.Visible = False
        Else
            CheckBox1.Visible = True
            CheckBox1.Text = pCheckMessage
        End If

        System.Windows.Forms.Application.DoEvents()
    End Sub
End Class