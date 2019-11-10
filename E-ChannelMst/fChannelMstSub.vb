Public Class fChannelMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oTool As cTool

    Private CHANNEL_CODE As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iChannelCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        CHANNEL_CODE = iChannelCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        If CHANNEL_CODE <> "" Then
            oMstChannelDBIO.getChannelMst(oChannel, CHANNEL_CODE, Nothing, Nothing, Nothing, oTran)
        End If

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()
        If Channel_CODE = Nothing Then
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "新規"
            CHANNEL_CODE_T.Text = oMstChannelDBIO.getNewChannelCode(oTran)
            CHANNEL_REAL_CLASS_R.Checked = True
            CHANNEL_NAME_T.Text = ""
            URL_T.Text = ""
            RECEIPT_PRINT_C.Checked = False
            SALES_REGIST_C.Checked = False
            CSV_HEADER_C.Checked = False
            CSV_DETAIL_C.Checked = False
        Else
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "更新"
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
            Select Case oChannel(0).sChannelClass
                Case 1
                    CHANNEL_REAL_CLASS_R.Checked = True
                Case 2
                    CHANNEL_NET_CLASS_R.Checked = True
            End Select
            CHANNEL_NAME_T.Text = oChannel(0).sChannelName
            URL_T.Text = oChannel(0).sURL
            RECEIPT_PRINT_C.Checked = oChannel(0).sReceiptPrint
            SALES_REGIST_C.Checked = oChannel(0).sSaleRegist
            CSV_HEADER_C.Checked = oChannel(0).sRequestFileFlg
            CSV_DETAIL_C.Checked = oChannel(0).sRequestSubFileFlg
            Select Case oChannel(0).sCMSType
                Case 1  'Yahoo
                    CMS_YAHOO_R.Checked = True
                Case 2  '楽天
                    CMS_RAKUTEN_R.Checked = True
                Case 3  'ショップサーブ
                    CMS_SHOPSERV_R.Checked = True
                Case 4  'Amazon
                    CMS_AMAZON_R.Checked = True
            End Select
        End If
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function

    Private Sub CLOSE_PROC()
        oMstChannelDBIO = Nothing

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        ret = oMstChannelDBIO.deleteChannelMst(CHANNEL_CODE_T.Text, oTran)
        If ret = False Then
            Message_form = New cMessageLib.fMessage(1, "チャネルマスタの登録に失敗しました。", _
                                            "システム管理者に連絡して下さい", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                                            "削除が完了しました。", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Message_form.ShowDialog()
        Application.DoEvents()
        Message_form = Nothing


        CLOSE_PROC()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage
 
        INPUT_CHECK = True

        If CHANNEL_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "チャネルコードが未入力です。", _
                                             "チャネルコードを入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CHANNEL_CODE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If CHANNEL_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "チャネル名称が未入力です。", _
                                             "チャネル名称を入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CHANNEL_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If CHANNEL_NET_CLASS_R.Checked = True Then

            If CMS_YAHOO_R.Checked = False And CMS_RAKUTEN_R.Checked = False And CMS_SHOPSERV_R.Checked = False And CMS_AMAZON_R.Checked = False Then
                Message_form = New cMessageLib.fMessage(1, "CMSタイプが未選択です。", _
                                                 "CMSタイプを選択して下さい。", _
                                                 Nothing, Nothing)

                Message_form.ShowDialog()
                Application.DoEvents()
                Message_form = Nothing
                CMS_YAHOO_R.Focus()
                INPUT_CHECK = False
                Exit Function

            End If
        End If
    End Function
    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '必須入力確認
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        ReDim oChannel(0)
        oChannel(0).sChannelCode = CInt(CHANNEL_CODE_T.Text)
        If CHANNEL_REAL_CLASS_R.Checked = True Then
            oChannel(0).sChannelClass = 1
        Else
            oChannel(0).sChannelClass = 2
        End If
        oChannel(0).sChannelName = CHANNEL_NAME_T.Text
        oChannel(0).sURL = URL_T.Text
        oChannel(0).sReceiptPrint = RECEIPT_PRINT_C.Checked
        oChannel(0).sSaleRegist = SALES_REGIST_C.Checked
        oChannel(0).sRequestFileFlg = CSV_HEADER_C.Checked
        oChannel(0).sRequestSubFileFlg = CSV_DETAIL_C.Checked

        oChannel(0).sCMSType = 0
        oChannel(0).sORRequestCodeFieldName = ""
        If CMS_YAHOO_R.Checked = True Then
            oChannel(0).sCMSType = 1
            oChannel(0).sORRequestCodeFieldName = "Order ID"
        End If
        If CMS_RAKUTEN_R.Checked = True Then
            oChannel(0).sCMSType = 2
            oChannel(0).sORRequestCodeFieldName = "受注番号"
        End If
        If CMS_SHOPSERV_R.Checked = True Then
            oChannel(0).sCMSType = 3
            oChannel(0).sORRequestCodeFieldName = "受注番号"
        End If
        If CMS_AMAZON_R.Checked = True Then
            oChannel(0).sCMSType = 4
            oChannel(0).sORRequestCodeFieldName = "AmazonOrderId"
        End If


        If MODE_L.Text = "新規" Then
            ret = oMstChannelDBIO.insertChannelMst(oChannel(0), oTran)
        Else
            ret = oMstChannelDBIO.updateChannelMst(oChannel(0), CHANNEL_CODE, oTran)
        End If
        If ret = False Then
            Message_form = New cMessageLib.fMessage(1, "チャネルマスタの登録に失敗しました。", _
                                            "システム管理者に連絡して下さい", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                                            "登録が完了しました。", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Message_form.ShowDialog()
        Application.DoEvents()
        Message_form = Nothing
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstChannelDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        CLOSE_PROC()

    End Sub

    Private Sub CHANNEL_CODE_T_Leave(sender As Object, e As EventArgs) Handles CHANNEL_CODE_T.Leave
        Dim pChannel() As cStructureLib.sChannel
        Dim pRecordCnt As Integer
        Dim Message_form As cMessageLib.fMessage

        ReDim pChannel(0)
        pRecordCnt = oMstChannelDBIO.getChannelMst(pChannel, CHANNEL_CODE_T.Text, Nothing, Nothing, Nothing, oTran)
        If pRecordCnt > 0 Then
            Message_form = New cMessageLib.fMessage(1, "入力されたチャネル番号は既に登録済みです。", _
                                            "別のチャネル番号を入力して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CHANNEL_CODE_T.Text = ""
            CHANNEL_CODE_T.Focus()
        End If

    End Sub

End Class
