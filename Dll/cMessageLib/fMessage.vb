Public Class fMessage
    Private pMode As Integer
    Private pMessage1 As String
    Private pMessage2 As String
    Private pMessage3 As String
    Private pMessage4 As String

    Private oTool As cTool

    '********************************
    '共通メッセージウィンドウ
    '  Mode   0     :ボタン無し
    '         1     :OKボタンのみ
    '         2     :Yes/Noボタンあり
    '　Message1　　 :上段のメッセージ
    '　Message2　　 :中段のメッセージ
    '　Message3　　 :下段のメッセージ
    '********************************
    Sub New(ByVal Mode As Integer, _
            ByVal Message1 As String, _
            ByVal Message2 As String, _
            ByVal Message3 As String, _
            ByVal Message4 As String)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        pMode = Mode
        pMessage1 = Message1
        pMessage2 = Message2
        pMessage3 = Message3
        pMessage4 = Message4
    End Sub
    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
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


    Private Sub fMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

    End Sub

    Private Sub NO_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_B.Click
        oTool.PlaySound()

        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()

    End Sub

    Private Sub YES_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_B.Click
        oTool.PlaySound()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()

    End Sub

    Private Sub OK_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click
        oTool.PlaySound()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()

    End Sub

    Private Sub HI_B_Click(sender As Object, e As EventArgs) Handles HI_B.Click
        oTool.PlaySound()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Dispose()
    End Sub

    Private Sub IIE_B_Click(sender As Object, e As EventArgs) Handles IIE_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Dispose()
    End Sub

    Private Sub CANCEL_B_Click(sender As Object, e As EventArgs) Handles CANCEL_B.Click
        oTool.PlaySound()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub fMessage_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Select Case pMode
            Case 0  'ボタン無し
                OK_B.Visible = False
                YES_B.Visible = False
                NO_B.Visible = False
                HI_B.Visible = False
                IIE_B.Visible = False
                CANCEL_B.Visible = False
                Me.Height = 123
            Case 1  'OKボタンのみ
                OK_B.Visible = True
                YES_B.Visible = False
                NO_B.Visible = False
                HI_B.Visible = False
                IIE_B.Visible = False
                CANCEL_B.Visible = False
                OK_B.Focus()
                Me.Height = 190
            Case 2  'Yes/Noボタンあり
                OK_B.Visible = False
                YES_B.Visible = True
                NO_B.Visible = True
                HI_B.Visible = False
                IIE_B.Visible = False
                CANCEL_B.Visible = False
                YES_B.Focus()
                Me.Height = 190
            Case 4  'はい/いいえ/キャンセルボタンあり
                OK_B.Visible = False
                YES_B.Visible = False
                NO_B.Visible = False
                HI_B.Visible = True
                IIE_B.Visible = True
                CANCEL_B.Visible = True
                OK_B.Focus()
                Me.Height = 190
        End Select

        'メッセージ1の設定
        If pMessage1 = "" Or pMessage1 = Nothing Then
            MESSAGE1_L.Visible = False
        Else
            MESSAGE1_L.Visible = True
            MESSAGE1_L.Text = pMessage1
        End If

        'メッセージ2の設定
        If pMessage2 = "" Or pMessage2 = Nothing Then
            MESSAGE2_L.Visible = False
        Else
            MESSAGE2_L.Visible = True
            MESSAGE2_L.Text = pMessage2
        End If

        'メッセージ3の設定
        If pMessage3 = "" Or pMessage3 = Nothing Then
            MESSAGE3_L.Visible = False
        Else
            MESSAGE3_L.Visible = True
            MESSAGE3_L.Text = pMessage3
        End If

        'メッセージ4の設定
        If pMessage4 = "" Or pMessage4 = Nothing Then
            MESSAGE4_L.Visible = False
        Else
            MESSAGE4_L.Visible = True
            MESSAGE4_L.Text = pMessage4
        End If

        System.Windows.Forms.Application.DoEvents()
    End Sub

 
End Class
