Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Public Class fMonthCloseReport
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iFromDate As String, _
            ByVal iToDate As String, _
            ByVal iChannelCode As Integer, _
            ByVal iSupplierCode As Integer, _
            ByVal iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oTool = New cTool

        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)

    End Sub


    Private Sub fMonthCloseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        '仕入先リストボックスセット
        SUPPLIER_SET()

    End Sub
    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません", _
                                                "仕入先マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        SUPPLIER_NAME_C.Items.Add("指定なし")
        For i = 0 To RecordCnt - 1
            SUPPLIER_NAME_C.Items.Add(oSupplier(i).sSupplierName)
        Next
        SUPPLIER_CODE_T.Text = -1
    End Sub
    Private Sub PRINT_PROC()
        Dim Message_form As cMessageLib.fMessage


        'Dim rTagPrint_A As New rTag_A(oConn, oCommand, oDataReader, CInt(CHANNEL_CODE_T.Text), ST_Point, oConf, oTran)

        'rTagPrint_A.Run()
        'rTagPrint_A.Document.Print(True, False)

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

    Private Sub SUOOLIER_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        SUPPLIER_CODE_T.Text = oSupplierDBIO.getSupplier(oSupplier, Nothing, SUPPLIER_NAME_C.Text, oTran)
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
