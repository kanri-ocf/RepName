Public Class fCheckMessage
    Private pLabelMessage As String
    Private pCheckMessage As String
    Private pCheckStatus As Boolean
    Private pDisableFlg As Boolean


    Sub New(ByVal iLabelMessage As String, _
            ByVal iCheckMessage As String, _
            ByRef iCheckStatus As Boolean, _
            ByVal iDisableFlg As Boolean)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        pLabelMessage = iLabelMessage
        pCheckMessage = iCheckMessage
        pCheckStatus = False
        pDisableFlg = iDisableFlg
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

        ' チェックボックスの操作可否の設定
        If pDisableFlg = False Then
            CheckBox1.Enabled = False
        End If

        System.Windows.Forms.Application.DoEvents()
    End Sub
    Private Sub OK_BUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_BUTTON.Click
        If CheckBox1.Checked = True Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If

        Me.Close()
    End Sub
End Class