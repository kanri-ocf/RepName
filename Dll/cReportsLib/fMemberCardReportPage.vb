Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Public Class fMemberCardReportPage
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
    Private MEMBER_CODE As String

    Private oTool As cTool

    Private CHANNEL_CODE As Integer
    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iMemberCode As String, _
            ByVal iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        MEMBER_CODE = iMemberCode

        oTool = New cTool

    End Sub


    Private Sub fMemberCardReportPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '2016.07.06 K.Oikawa s
        '課題表No107 カードプリンタの接続チェック
        If oConf Is Nothing Then
            '2016.07.05 K.Oikawa e        
            Dim message_form As New cMessageLib.fMessage(1,
                                              "カードプリンターの接続を確認してください", Nothing, Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            'Me.DialogResult = Windows.Forms.DialogResult.No
            'Me.Dispose()
            'Exit Sub
        End If
        '2016.07.06 K.Oikawa e

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
        Dim i As Integer
        Dim rCard_Fore_Report As rMemberCard_Fore
        Dim rCard_Back_Report As rMemberCard_Back

        Message_form = New cMessageLib.fMessage(0, Nothing, "会員カード印刷準備中...", Nothing, Nothing)
        Message_form.Show()
        'System.Windows.Forms.Application.DoEvents()

        If A4_Printer_R.Checked = True Then
            '*********************************
            '     A4プリンター印刷の場合
            '*********************************

            '------------------
            '表面のレポート設定
            '------------------
            rCard_Fore_Report = New rMemberCard_Fore(oConn, oCommand, oDataReader, MEMBER_CODE, oTran)

            rCard_Fore_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(17.2)

            With (rCard_Fore_Report.PageSettings)
                ' 用紙サイズを A4(縦) に設定します。
                .PaperKind = System.Drawing.Printing.PaperKind.A4
                .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait

                ' 上下の余白を 1.0cm に設定します。
                .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.4)
                .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.0)

                ' 左右の余白を 1.5cm に設定します。
                .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.9)
                .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.9)
            End With

            rCard_Fore_Report.Run()

            '    '------------------
            '    '裏面のレポート設定
            '    '------------------
            rCard_Back_Report = New rMemberCard_Back(oConn, oCommand, oDataReader, oTran)

            rCard_Back_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(17.2)

            With rCard_Back_Report.PageSettings
                ' 用紙サイズを A4(縦) に設定します。
                .PaperKind = System.Drawing.Printing.PaperKind.A4
                .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait

                ' 上下の余白を 1.0cm に設定します。
                .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.4)
                .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.0)

                ' 左右の余白を 1.5cm に設定します。
                .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.9)
                .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(1.9)
            End With

            rCard_Back_Report.Run()

            For i = 0 To rCard_Fore_Report.Document.Pages.Count - 1
                ' 各レポートが交互に出力されるように、ページを挿入します。
                rCard_Fore_Report.Document.Pages.Insert(i * 2 + 1, rCard_Back_Report.Document.Pages(i).Clone)
            Next

            rCard_Fore_Report.Document.Name = "会員カード"
            rCard_Fore_Report.Document.Print(True, False)

            rCard_Fore_Report.Dispose()
            rCard_Fore_Report = Nothing

            'rCard_Back_Report.Dispose()
            'rCard_Back_Report = Nothing

        Else
            '*********************************
            '     カードプリンター印刷の場合
            '*********************************

            '------------------
            '表面のレポート設定
            '------------------
            rCard_Fore_Report = Nothing

            rCard_Fore_Report = New rMemberCard_Fore(oConn, oCommand, oDataReader, MEMBER_CODE, oTran)

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
            rCard_Fore_Report.Document.Name = "会員カード表面"

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

            rCard_Back_Report = New rMemberCard_Back(oConn, oCommand, oDataReader, oTran)

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
            rCard_Back_Report.Document.Name = "会員カード裏面"

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

    '2016.07.06 K.Oikawa s
    '課題表No145 キャンセルボタンの中身が実装されていなかったので追加
    Private Sub CANCEL_B_Click(sender As Object, e As EventArgs) Handles CANCEL_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Dispose()
    End Sub
    '2016.07.06 K.Oikawa e

End Class
