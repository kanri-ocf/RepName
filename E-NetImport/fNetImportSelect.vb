Public Class fNetImportSelect
    Private oConf() As cStructureLib.sConfig
    Private oChannel() As cStructureLib.sChannel
    Private oTool As cTool

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

    Public Sub New(ByRef pChannel() As cStructureLib.sChannel, ByRef pConfig() As cStructureLib.sConfig)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        oConf = pConfig
        oChannel = pChannel

        oTool = New cTool

    End Sub
    Private Sub fNetImportSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'リストボックスへの値セット
        For i = 0 To oChannel.Length - 1
            CHANNEL_L.Items.Add(oChannel(i).sChannelName)
        Next

    End Sub

    Private Sub CHANNEL_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANNEL_L.SelectedIndexChanged
        'チャネル別サブファイル指定の有無コントロール
        PATH_2_T.Enabled = oChannel(CHANNEL_L.SelectedIndex).sRequestSubFileFlg

    End Sub

    Private Sub OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub FILE1_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILE1_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("注文情報を選択して下さい", oConf(0).sTempFilePath, "*.csv")
        If sPath <> "" Then
            PATH_1_T.Text = sPath
        End If

    End Sub

    Private Sub FILE2_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILE2_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("注文情報の明細データを選択して下さい", PATH_1_T.Text.ToString, "*.csv")
        If sPath <> "" Then
            PATH_2_T.Text = sPath
        End If

    End Sub
End Class
