Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Public Class fStaffCardReportPage
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private RECORD_NO As Integer

    Private oStaffCode As String
    Private oStaffName As String
    Private oStaffRole As String

    Private oTool As cTool

    Private CHANNEL_CODE As Integer
    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByVal iStaffRole As String, _
            ByVal iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oConf = iConf

        oTran = iTran

        oStaffCode = iStaffCode
        oStaffName = iStaffName
        oStaffRole = iStaffRole

        oTool = New cTool

    End Sub


    Private Sub fStaffCardReportPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'カードプリンターの接続確認
        If oConf(0).sCardPrinterClass > 0 Then
            Card_Printer_R.Enabled = True
        Else
            Card_Printer_R.Enabled = False
        End If

        IVENT_FLG = True

        oTran = oConn.BeginTransaction
    End Sub
    Private Sub PRINT_PROC()
        Dim Message_form As cMessageLib.fMessage
        Dim rCard_Report As rStaffCard
        Dim rCard_Fore_Report As rStaffCard_Fore
        Dim rCard_Back_Report As rStaffCard_Back

        Message_form = New cMessageLib.fMessage(0, Nothing, "スタッフカード印刷準備中...", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        If A4_Printer_R.Checked = True Then
            '*********************************
            '     A4プリンター印刷の場合
            '*********************************


            rCard_Report = New rStaffCard(oStaffCode, oStaffName, oStaffRole)

            rCard_Report.Run()

            rCard_Report.Document.Name = "スタッフカード"
            rCard_Report.Document.Print(True, False)

            rCard_Report = Nothing

        Else
            '*********************************
            '     カードプリンター印刷の場合
            '*********************************

            '------------------
            '表面のレポート設定
            '------------------
            rCard_Fore_Report = Nothing

            rCard_Fore_Report = New rStaffCard_Fore(oStaffCode, oStaffName, oStaffRole)

            With rCard_Fore_Report.PageSettings
                .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                ' 上下の余白を 0cm に設定します。
                .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                ' 左右の余白を 0cm に設定します。
                .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

            End With

            rCard_Fore_Report.Run()


            rCard_Fore_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(8.6)
            rCard_Fore_Report.Document.Name = "スタッフカード表面"

            rCard_Fore_Report.Document.Print(True, False)

            rCard_Fore_Report.Dispose()
            rCard_Fore_Report = Nothing


            Dim Message_form1 = New cMessageLib.fMessage(1, "裏面を印刷します。", "カードをセットして下さい。", Nothing, Nothing)
            Message_form1.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form1.Dispose()
            Message_form1 = Nothing

            '------------------
            '裏面のレポート設定
            '------------------
            rCard_Back_Report = Nothing

            rCard_Back_Report = New rStaffCard_Back(oConf(0))

            With rCard_Back_Report.PageSettings
                .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                ' 上下の余白を 0cm に設定します。
                .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                ' 左右の余白を 0cm に設定します。
                .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

            End With

            rCard_Back_Report.Run()


            rCard_Back_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(8.6)
            rCard_Back_Report.Document.Name = "スタッフカード裏面"

            rCard_Back_Report.Document.Print(True, False)

            rCard_Back_Report.Dispose()
            rCard_Back_Report = Nothing
        End If

        Message_form.Dispose()
        Message_form = Nothing
        System.Windows.Forms.Application.DoEvents()

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

    Private Sub OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click

        '印刷実行
        PRINT_PROC()

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Dispose()

    End Sub
End Class
