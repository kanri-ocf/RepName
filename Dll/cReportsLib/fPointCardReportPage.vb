Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Public Class fPointCardReportPage
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

    Private oPointMemberDBIO As cMstPointMemberDBIO
    Private oPointMember() As cStructureLib.sPointMember

    Private RECORD_NO As Integer
    Private PRINT_MODE As Integer   '0:新規　1:再発行
    Private POINT_MEMBER_CODE As String

    Private oTool As cTool

    Private CHANNEL_CODE As Integer
    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction


    '2016.07.06 K.Oikawa s
    '課題表No129 印刷キャンセル時の処理追加
    '印刷失敗時のフラグ
    Public P_FLG As Boolean
    '2016.07.06 K.Oikawa e


    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iPrintMode As Integer, _
            ByVal iPointMemberCode As String, _
            ByVal iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        PRINT_MODE = iPrintMode
        POINT_MEMBER_CODE = iPointMemberCode
        If iPointMemberCode <> "" Then
            CHANNEL_CODE = CInt(iPointMemberCode.Substring(4, 1))
        End If

        oTool = New cTool

    End Sub


    Private Sub fPointCardReportPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)

        '環境マスタ読込み
        ReDim oConf(1)
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

        'カードプリンターの接続確認
        If oConf(0).sCardPrinterClass > 0 Then
            Card_Printer_R.Enabled = True
        Else
            Card_Printer_R.Enabled = False
        End If

        'チャネルリストＢＯＸセット
        CHANNEL_SET()

        '再発行の場合
        If PRINT_MODE = 1 Then
            A4_Printer_R.Enabled = False
            Card_Printer_R.Checked = True
            CARD_COUNT_T.Enabled = False
        End If
        IVENT_FLG = True

        '2016.07.06 K.Oikawa s
        '課題表No129 印刷キャンセル時の処理追加
        '印刷失敗時のフラグ
        P_FLG = True
        '2016.07.06 K.Oikawa e

        oTran = oConn.BeginTransaction
    End Sub
    Private Sub CHANNEL_SET()
        Dim oChannelDBIO As New cMstChannelDBIO(oConn, oCommand, oDataReader)
        Dim RecordCount As Long

        '呼出元のチャネル名称を取得
        If CHANNEL_CODE <> Nothing Then
            RecordCount = oChannelDBIO.getChannelMst(oChannel, CHANNEL_CODE, Nothing, Nothing, 0, oTran)
            CHANNEL_L.Text = oChannel(0).sChannelName
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
            CHANNEL_L.Enabled = False
        Else
            RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, 0, oTran)
            For i = 0 To oChannel.Length - 1
                CHANNEL_L.Items.Add(oChannel(i).sChannelName)
            Next
        End If

    End Sub
    Private Sub PRINT_PROC(ByVal pPrintCount As Integer)
        Dim Message_form As cMessageLib.fMessage
        Dim i As Integer
        Dim rPointCard_Fore_Report As rPointCard_Fore
        Dim rPointCard_Back_Report As rPointCard_Back
        Dim rPointCard_Fore_Report_1 As rPointCard_Fore
        Dim rPointCard_Back_Report_1 As rPointCard_Back
        Dim pPointMembar() As cStructureLib.sPointMember

        Message_form = New cMessageLib.fMessage(0, Nothing, "印刷準備中...", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        ReDim pPointMembar(0)

        If A4_Printer_R.Checked = True Then
            '*********************************
            '     A4プリンター印刷の場合
            '*********************************

            '------------------
            '表面のレポート設定
            '------------------
            rPointCard_Fore_Report = New rPointCard_Fore(oConn, oCommand, oDataReader, oPointMember, pPrintCount, False, oConf, oTran)

            rPointCard_Fore_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(17.2)

            With (rPointCard_Fore_Report.PageSettings)
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

            rPointCard_Fore_Report.Run()

            '------------------
            '裏面のレポート設定
            '------------------
            rPointCard_Back_Report = New rPointCard_Back(oConn, oCommand, oDataReader, oPointMember, pPrintCount, False, oConf, oTran)

            rPointCard_Back_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(17.2)

            With rPointCard_Back_Report.PageSettings
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

            rPointCard_Back_Report.Run()

            For i = 0 To rPointCard_Fore_Report.Document.Pages.Count - 1
                ' 各レポートが交互に出力されるように、ページを挿入します。
                rPointCard_Fore_Report.Document.Pages.Insert(i * 2 + 1, rPointCard_Back_Report.Document.Pages(i).Clone)
            Next

            rPointCard_Fore_Report.Document.Name = "ポイントカード"

            '2016.07.06 K.Oikawa s
            '課題表No129 印刷キャンセル時の処理追加
            'rPointCard_Fore_Report.Document.Print(True, False)
            Dim rtn As Boolean
            rtn = rPointCard_Fore_Report.Document.Print(True, False)
            If rtn = False Then
                P_FLG = False
                Message_form.Dispose()
                Message_form = Nothing
                System.Windows.Forms.Application.DoEvents()
                Exit Sub
            End If
            '2016.07.06 K.Oikawa e



            rPointCard_Fore_Report.Dispose()
            rPointCard_Fore_Report = Nothing

            rPointCard_Back_Report.Dispose()
            rPointCard_Back_Report = Nothing

        Else
            '*********************************
            '     カードプリンター印刷の場合
            '*********************************

            '------------------
            '表面のレポート設定
            '------------------
            rPointCard_Fore_Report = Nothing

            For i = 0 To pPrintCount - 1
                pPointMembar(0) = oPointMember(i)

                If i = 0 Then
                    rPointCard_Fore_Report = New rPointCard_Fore(oConn, oCommand, oDataReader, pPointMembar, 1, True, oConf, oTran)

                    With rPointCard_Fore_Report.PageSettings
                        .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                        ' 上下の余白を 0cm に設定します。
                        .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                        ' 左右の余白を 0cm に設定します。
                        .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                    End With

                    rPointCard_Fore_Report.Run()
                Else

                    rPointCard_Fore_Report_1 = Nothing
                    rPointCard_Fore_Report_1 = New rPointCard_Fore(oConn, oCommand, oDataReader, pPointMembar, 1, True, oConf, oTran)

                    With rPointCard_Fore_Report_1.PageSettings
                        .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                        ' 上下の余白を 0cm に設定します。
                        .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                        ' 左右の余白を 0cm に設定します。
                        .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                    End With

                    rPointCard_Fore_Report_1.Run()

                    rPointCard_Fore_Report.Document.Pages.Insert(rPointCard_Fore_Report.Document.Pages.Count, rPointCard_Fore_Report_1.Document.Pages(0).Clone)

                End If
            Next

            rPointCard_Fore_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(8.6)
            rPointCard_Fore_Report.Document.Name = "ポイントカード表面"

            rPointCard_Fore_Report.Document.Print(True, False)

            rPointCard_Fore_Report.Dispose()
            rPointCard_Fore_Report = Nothing


            Dim Message_form1 = New cMessageLib.fMessage(1, "裏面を印刷します。", "カードをセットして下さい。", Nothing, Nothing)
            Message_form1.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form1.Dispose()
            Message_form1 = Nothing

            '------------------
            '裏面のレポート設定
            '------------------
            rPointCard_Back_Report = Nothing

            For i = 0 To pPrintCount - 1

                pPointMembar(0) = oPointMember(i)

                If i = 0 Then
                    rPointCard_Back_Report = New rPointCard_Back(oConn, oCommand, oDataReader, pPointMembar, 1, True, oConf, oTran)

                    With rPointCard_Back_Report.PageSettings
                        .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                        ' 上下の余白を 0cm に設定します。
                        .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                        ' 左右の余白を 0cm に設定します。
                        .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                    End With

                    rPointCard_Back_Report.Run()

                Else
                    rPointCard_Back_Report_1 = Nothing
                    rPointCard_Back_Report_1 = New rPointCard_Back(oConn, oCommand, oDataReader, pPointMembar, 1, True, oConf, oTran)

                    With rPointCard_Back_Report_1.PageSettings
                        .Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape

                        ' 上下の余白を 0cm に設定します。
                        .Margins.Top = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Bottom = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                        ' 左右の余白を 0cm に設定します。
                        .Margins.Left = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)
                        .Margins.Right = DataDynamics.ActiveReports.ActiveReport.CmToInch(0)

                    End With

                    rPointCard_Back_Report_1.Run()

                    rPointCard_Back_Report.Document.Pages.Insert(rPointCard_Back_Report.Document.Pages.Count, rPointCard_Back_Report_1.Document.Pages(0).Clone)

                End If
            Next

            rPointCard_Back_Report.PrintWidth = DataDynamics.ActiveReports.ActiveReport.CmToInch(8.6)
            rPointCard_Back_Report.Document.Name = "ポイントカード裏面"

            rPointCard_Back_Report.Document.Print(True, False)

            rPointCard_Back_Report.Dispose()
            rPointCard_Back_Report = Nothing
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

    Private Sub CHANNEL_L_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_L.SelectedIndexChanged
        CHANNEL_CODE_T.Text = oChannel(CHANNEL_L.SelectedIndex).sChannelCode
    End Sub

    Private Sub OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim PrintCount As Integer

        '必須チェック
        If CHANNEL_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "チャネルを指定して下さい。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing
            CHANNEL_L.Focus()
            Exit Sub
        End If
        If A4_Printer_R.Checked = True Then
            If A4_COUNT_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, Nothing, "発行枚数を指定して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                A4_COUNT_T.Focus()
                Exit Sub
            End If
            If CInt(A4_COUNT_T.Text) < 1 Then
                Message_form = New cMessageLib.fMessage(1, Nothing, "発行枚数は1枚以上を指定して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                A4_COUNT_T.Focus()
                Exit Sub
            End If
        Else
            If CARD_COUNT_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, Nothing, "発行枚数を指定して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                CARD_COUNT_T.Focus()
                Exit Sub
            End If
            If CInt(CARD_COUNT_T.Text) < 1 Then
                Message_form = New cMessageLib.fMessage(1, Nothing, "発行枚数は1枚以上を指定して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                CARD_COUNT_T.Focus()
                Exit Sub
            End If
        End If

        Select Case PRINT_MODE
            Case 0  '新規
                '仮ポイント会員作成
                PrintCount = POINT_MEMBER_CREATE()
            Case 1  '再発行
                oPointMemberDBIO.getPointMember(oPointMember, POINT_MEMBER_CODE, POINT_MEMBER_CODE, Nothing, Nothing, Nothing, oTran)
                PrintCount = 1
        End Select

        '2016.07.06 K.Oikawa s
        '課題表No129 印刷キャンセル時の処理追加
        '印刷失敗時のフラグ
        P_FLG = True
        '2016.07.06 K.Oikawa e

        '印刷実行
        PRINT_PROC(PrintCount)

        '2016.07.06 K.Oikawa s
        'oTran.Commit()
        'Me.DialogResult = Windows.Forms.DialogResult.Yes

        '課題表No129 印刷キャンセル時の処理追加
        '印刷失敗時のフラグ
        If P_FLG = True Then
            oTran.Commit()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            oTran.Rollback()
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
        '2016.07.06 K.Oikawa e


        Me.Dispose()

    End Sub
    Private Function POINT_MEMBER_CREATE() As Integer
        Dim pPointMemberCode As String
        Dim i As Long
        Dim PrintCount As Integer

        pPointMemberCode = oPointMemberDBIO.readMaxPointMemberCode(CInt(CHANNEL_CODE_T.Text), CInt(Now().Year.ToString.Substring(2, 2)), oTran)
        If pPointMemberCode = Nothing Then
            pPointMemberCode = "0000000000000"
        End If

        If A4_Printer_R.Checked = True Then
            PrintCount = CLng(A4_COUNT_T.Text) * 10
        Else
            PrintCount = CLng(CARD_COUNT_T.Text)
        End If
        POINT_MEMBER_CREATE = 0

        For i = CLng(pPointMemberCode.Substring(6, 6)) To CLng(pPointMemberCode.Substring(6, 6)) + PrintCount - 1
            ReDim Preserve oPointMember(i - CLng(pPointMemberCode.Substring(6, 6)))
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sPointMemberCode = oTool.JANCD(String.Format("997{0:0}{1:00}{2:000000}", CInt(CHANNEL_CODE_T.Text), CInt(Now().Year.ToString.Substring(2, 2)), i + 1))
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sPointMemberName = "未登録"

            '2016.06.29 K.Oikawa s
            '課代表No121 郵便番号はハイフンを入力しないこととしているが、
            '仮登録を行った際に入ってしまっているので修正
            'oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sPostCode = "000-0000"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sPostCode = "0000000"
            '2016.06.29 K.Oikawa e

            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sAddress1 = ""
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sAddress2 = ""
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sAddress3 = ""
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sTEL = "------------"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sFAX = "------------"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sMailAddress = "XXX@XXXXX.XX.XX"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sSex = ""
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sBirthDay = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sAge = 0
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sEntryDate = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sResignDate = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sStartRegistDate = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sEndRegistDate = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sEntryDate = "0000/00/00"
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sUpdateCount = 0
            oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))).sMemo = ""

            If oPointMemberDBIO.insertPointMember(oPointMember(i - CLng(pPointMemberCode.Substring(6, 6))), oTran) = True Then
                POINT_MEMBER_CREATE = POINT_MEMBER_CREATE + 1
            End If
        Next

    End Function
    Private Sub CANCEL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_B.Click
        oTran.Rollback()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub COUNT_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles A4_COUNT_T.LostFocus
        Dim Message_form As cMessageLib.fMessage

        If IVENT_FLG = True Then
            IVENT_FLG = False
            If A4_COUNT_T.Text <> "" Then
                If CInt(A4_COUNT_T.Text) < 1 Then
                    Message_form = New cMessageLib.fMessage(1, Nothing, "発行枚数は1枚以上を指定して下さい。", Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing
                    A4_COUNT_T.Focus()
                Else
                    CARD_COUNT_L.Text = CInt(A4_COUNT_T.Text) * 10
                End If
                IVENT_FLG = True
            End If
        End If
    End Sub


    Private Sub A4_Printer_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles A4_Printer_R.CheckedChanged
        '接続デバイス別設定切替
        If A4_Printer_R.Checked = True Then
            A4PRINTER_SET_G.Enabled = True
            CARD_PRINTER_SET.Enabled = False
            CARD_COUNT_T.Enabled = False
        Else
            A4PRINTER_SET_G.Enabled = False
            CARD_PRINTER_SET.Enabled = True
            CARD_COUNT_T.Enabled = True
        End If

    End Sub
End Class
