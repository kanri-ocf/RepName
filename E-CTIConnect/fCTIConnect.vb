Public Class fCTIConnect
    Declare Function Aloha_SetupPort Lib "AlohaDLL.dll" Alias "_Aloha_SetupPort@12" (ByVal portname As String, ByVal callback As Long, ByVal userdata As Long) As Long
    Declare Function Aloha_GetEvent Lib "AlohaDLL.dll" Alias "_Aloha_GetEvent@16" (ByRef devno As Long, ByRef event_id As Long, ByVal message As String, ByRef msg_len As Long) As Long
    Declare Function Aloha_ReadMemory Lib "AlohaDLL.dll" Alias "_Aloha_ReadMemory@12" (ByVal devno As Long, ByVal addr As Long, ByVal msg As String) As Long

    'Declare Function Aloha_SetupPort Lib "AlohaDLL.dll" Alias "_Aloha_SetupPort" (ByVal portname As String, ByVal callback As Long, ByVal userdata As Long) As Long
    'Declare Function Aloha_GetEvent Lib "AlohaDLL.dll" Alias "_Aloha_GetEvent" (ByRef devno As Long, ByRef event_id As Long, ByVal message As String, ByRef msg_len As Long) As Long
    'Declare Function Aloha_ReadMemory Lib "AlohaDLL.dll" Alias "_Aloha_ReadMemory" (ByVal devno As Long, ByVal addr As Long, ByVal msg As String) As Long

    'Declare Function Aloha_TearDown Lib "AlohaDLL.dll" Alias "_Aloha_TearDown@4" (ByVal devno As Long) As Long
    'Declare Function Aloha_GetConnStatus Lib "AlohaDLL.dll" Alias "_Aloha_GetConnStatus@12" (ByVal devno As Long, ByVal portname As String, ByVal namelen As Long) As Long
    'Declare Function Aloha_ReadMemoryEx Lib "AlohaDLL.dll" Alias "_Aloha_ReadMemoryEx@12" (ByVal devno As Long, ByVal addr As Long, ByVal msg As String) As Long
    'Declare Function Aloha_SetCalendar Lib "AlohaDLL.dll" Alias "_Aloha_SetCalendar@24" (ByVal devno As Long, ByVal year As Long, ByVal month As Long, ByVal day As Long, ByVal minute As Long) As Long
    'Declare Function Aloha_SyncCalendar Lib "AlohaDLL.dll" Alias "_Aloha_SyncCalendar@4" (ByVal devno As Long) As Long
    'Declare Function Aloha_SetDeviceID Lib "AlohaDLL.dll" Alias "_Aloha_SetDeviceID@8" (ByVal devno As Long, ByVal devid As String) As Long
    'Declare Function Aloha_GetDeviceID Lib "AlohaDLL.dll" Alias "_Aloha_GetDeviceID@8" (ByVal devno As Long, ByVal ldevid As String) As Long

    Private DevNo As Long
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private REQUEST_CODE As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

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
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property

    Private Sub fCTIConnect_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        NotifyIcon1.Dispose()
    End Sub

    Private Sub fCTIConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer
        Dim oMstConfigDBIO As New cMstConfigDBIO(oConn, oCommand, oDataReader)


        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'タスクトレイアイコンをフォームのアイコンにする
        Me.NotifyIcon1.Icon = Me.Icon
        Me.NotifyIcon1.Visible = True

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        End If

        ''スタッフ入力ウィンドウ表示
        'If STAFF_CODE = Nothing Then
        '    'スタッフ入力ウィンドウ表示
        '    Dim staff_form As cStaffEntryLib.fStaffEntry

        '    staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
        '    staff_form.ShowDialog()
        '    Application.DoEvents()
        '    If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
        '        '担当者セット
        '        STAFF_CODE = staff_form.STAFF_CODE
        '        STAFF_NAME = staff_form.STAFF_NAME
        '        staff_form = Nothing
        '    Else
        '        staff_form = Nothing
        '        Environment.Exit(1)
        '    End If
        'End If

        DevNo = Aloha_SetupPort(oConf(0).sCTIPort, 0, 0)
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub
    '-----------------------------------------< 内部関数 >-------------------------------------------
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim msg As String
        Dim msg_len As Integer
        Dim event_id As Long
        Dim devnum As Long
        Dim fCustmorRequest_form As cLookUpLib.fCustmorRequest

        msg_len = 128
        msg = ""
        msg = GetSJisFixedString(msg, msg_len)
        If Aloha_GetEvent(devnum, event_id, msg, msg_len) = 0 Then
            Aloha_ReadMemory(DevNo, 1, msg)
            Timer1.Stop()
            fCustmorRequest_form = New cLookUpLib.fCustmorRequest(oConn, oCommand, oDataReader, msg.Substring(9, 10), STAFF_CODE, STAFF_NAME, oTran)
            fCustmorRequest_form.ShowDialog()
            fCustmorRequest_form = Nothing
            Timer1.Start()
        End If

    End Sub
    Private Function GetSJisFixedString(ByVal Str As String, ByVal ByteSize As Integer)

        Dim wkstr As String = Str.PadRight(ByteSize)
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(wkstr)

        wkstr = hEncoding.GetString(btBytes, 0, ByteSize)
        If hEncoding.GetByteCount(wkstr) > ByteSize Then
            wkstr = hEncoding.GetString(btBytes, 0, ByteSize - 1) & Space(1)
        End If

        Return wkstr

    End Function

    Private Sub CALL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fCustmorRequest_form As cLookUpLib.fCustmorRequest

        Me.Hide()
        fCustmorRequest_form = New cLookUpLib.fCustmorRequest(oConn, oCommand, oDataReader, "09061696683", STAFF_CODE, STAFF_NAME, oTran)
        fCustmorRequest_form.ShowDialog()
        fCustmorRequest_form = Nothing
        Me.Show()
    End Sub
End Class
