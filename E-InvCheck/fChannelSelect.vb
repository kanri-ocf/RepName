Public Class fChannelSelect

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oTran As System.Data.OleDb.OleDbTransaction
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
           ByRef iCommand As OleDb.OleDbCommand, _
           ByRef iDataReader As OleDb.OleDbDataReader, _
           ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function

    Private Sub fChannelSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        CHANNEL_CODE_T.Text = 0
        CHANNEL_NAME_SET()

    End Sub
    Private Sub CHANNEL_NAME_SET()
        Dim i As Integer

        ReDim oChannel(0)
        oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To oChannel.Length - 1
            CHANNEL_NAME_L.Items.Add(oChannel(i).sChannelName)
        Next
    End Sub

    Private Sub CHANNEL_NAME_L_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_L.TextChanged
        If CHANNEL_NAME_L.Text <> "" Then
            ReDim oChannel(0)
            oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_L.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        Else
            CHANNEL_CODE_T.Text = 0
        End If

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        oChannel = Nothing
        oChannelDBIO = Nothing
        Me.Close()
    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        oChannel = Nothing
        oChannelDBIO = Nothing
        Me.Close()

    End Sub
End Class