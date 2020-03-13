Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Public Class fTagReportPage
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTagPrintStatus() As cStructureLib.sTagPrintStatus
    Private oDataTagPrintStatusDBIO As cDataTagPrintStatusDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private RECORD_NO As Integer

    Private oTool As cTool

    Private CHANNEL_CODE As Integer
    Private PRINT_MODE As Integer       '0：指定なし　　1:バーコード付き　　2:バーコードなし

    Private Const SRCCOPY As Integer = &HCC0020
    'Private PrintMessage_form As fPrintMessage
    Private ST_Point As Integer

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iChannelCode As Integer, _
            ByVal iMode As Integer, _
            ByVal iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        CHANNEL_CODE = iChannelCode
        PRINT_MODE = iMode

        oTool = New cTool

        oDataTagPrintStatusDBIO = New cDataTagPrintStatusDBIO(oConn, oCommand, oDataReader)

    End Sub


    Private Sub fTagReportPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(1)

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            System.Windows.Forms.Application.Exit()
        End If
        oMstConfigDBIO = Nothing

        'チャネルリストＢＯＸセット
        CHANNEL_SET()

        'タグタイプセット
        TAGTYPE_SET()

    End Sub
    Private Sub CHANNEL_SET()
        Dim oChannelDBIO As New cMstChannelDBIO(oConn, oCommand, oDataReader)
        Dim RecordCount As Long
        Dim pChannelName As String

        '呼出元のチャネル名称を取得
        pChannelName = ""
        If CHANNEL_CODE <> Nothing Then
            RecordCount = oChannelDBIO.getChannelMst(oChannel, CHANNEL_CODE, Nothing, Nothing, 0, oTran)
            pChannelName = oChannel(0).sChannelName
        End If

        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, 0, oTran)
        For i = 0 To oChannel.Length - 1
            CHANNEL_L.Items.Add(oChannel(i).sChannelName)
        Next

        If CHANNEL_CODE <> Nothing Then
            CHANNEL_L.Text = pChannelName
        End If

    End Sub
    Private Sub TAGTYPE_SET()
        TYPE_C.BeginUpdate()

        TYPE_C.Items.Clear()

        Select Case PRINT_MODE
            Case 0
                TYPE_C.Items.Add("バーコード付き(A-One 31516)")
                TYPE_C.Items.Add("バーコード無し(A-One 28879)")
            Case 1
                TYPE_C.Items.Add("バーコード付き(A-One 31516)")
            Case 2
                TYPE_C.Items.Add("バーコード無し(A-One 28879)")
        End Select
        TYPE_C.EndUpdate()
        If TYPE_C.Items.Count = 1 Then
            TYPE_C.SelectedIndex = 0
        End If
    End Sub
    Private Sub PRINT_PROC()
        Dim Message_form As cMessageLib.fMessage

        '印刷開始位置指定ウィンドウ表示
        If TYPE_C.Text = "バーコード付き(A-One 31516)" Then
            Dim fTagPrintPoint As New fTagPrintPoint_TypeA
            fTagPrintPoint.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            If fTagPrintPoint.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            ST_Point = CInt(fTagPrintPoint.POINT_T.Text.ToString)
            fTagPrintPoint = Nothing

            Message_form = New cMessageLib.fMessage(0, Nothing, "印刷中...", Nothing, Nothing)
            Message_form.Show()
            System.Windows.Forms.Application.DoEvents()

            Dim rTagPrint_A As New rTag_A(oConn, oCommand, oDataReader, CInt(CHANNEL_CODE_T.Text), ST_Point, oConf, oTran)

            rTagPrint_A.Run()
            rTagPrint_A.Document.Print(True, False)
        Else
            Dim fTagPrintPoint As New fTagPrintPoint_TypeB
            fTagPrintPoint.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            If fTagPrintPoint.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            ST_Point = CInt(fTagPrintPoint.POINT_T.Text.ToString)
            fTagPrintPoint = Nothing

            Message_form = New cMessageLib.fMessage(0, Nothing, "印刷中...", Nothing, Nothing)
            Message_form.Show()
            System.Windows.Forms.Application.DoEvents()

            Dim rTagPrint_B As New rTag_B(oConn, oCommand, oDataReader, CInt(CHANNEL_CODE_T.Text), ST_Point, oConf, oTran)

            rTagPrint_B.Run()
            rTagPrint_B.Document.Print(True, False)

        End If

        Message_form = Nothing

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

    Private Sub CHANNEL_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_L.SelectedIndexChanged
        CHANNEL_CODE_T.Text = oChannel(CHANNEL_L.SelectedIndex).sChannelCode
    End Sub

    Private Sub OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '印刷実行
        PRINT_PROC()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Dispose()
    End Sub

    Private Sub CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub OK_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click
        '印刷実行
        PRINT_PROC()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Dispose()

    End Sub

    Private Sub CANCEL_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()

    End Sub

End Class
