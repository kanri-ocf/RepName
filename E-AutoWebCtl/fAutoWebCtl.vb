Imports System.Threading

Public Class fAutoWebCtl
    'タスクトレイにアニメで表示するアイコン
    Private tasktrayIcons() As Icon
    'アニメで現在表示しているアイコンのインデックス
    Private currentTasktrayIconIndex As Integer
    Private oConf() As cStructureLib.sConfig

    Private UpdateCnt As Integer

    Private Sub readConf()
        Dim oConn As OleDb.OleDbConnection
        Dim oCommand As New OleDb.OleDbCommand
        Dim oDataReader As OleDb.OleDbDataReader
        Dim oMstConfigDBIO As cMstConfigDBIO
        Dim Tran As System.Data.OleDb.OleDbTransaction
        Dim oTool As cTool
        Dim RecordCnt As Integer
        Dim StrPath As String
        Dim DB_Path As String

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        Tran = Nothing

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く
        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()
        oDataReader = Nothing
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, Tran)
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        終了ToolStripMenuItem.Enabled = False
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub fAutoWebCtl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False

        'タスクトレイアイコンをフォームのアイコンにする
        'タスクトレイにアニメで表示するアイコンを指定する
        Me.currentTasktrayIconIndex = 0
        Me.tasktrayIcons = New Icon() { _
            New Icon(Application.StartupPath & "\Picture\AutoWebCtl01.ico"), _
            New Icon(Application.StartupPath & "\Picture\AutoWebCtl02.ico"), _
            New Icon(Application.StartupPath & "\Picture\AutoWebCtl01.ico")}

        readConf()

        UpdateCnt = 0

        Me.NotifyIcon1.Icon = tasktrayIcons(0)
        Me.NotifyIcon1.Visible = True

        Timer_Icon.Interval = 500
        Timer_Icon.Start()

        'BackgroundWorker1.WorkerSupportsCancellation = True
        'BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Dim bgWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        'cWebTool.bgWorker = bgWorker

        'readConf()
        'Dim mode As Integer = Today.ToOADate() Mod 2
        'Select Case mode
        '    Case 0  'Yahoo
        '        Dim businessID As String = oConf(0).sYahooBisID
        '        Dim businessPass As String = oConf(0).sYahooBisPASS
        '        Dim userID As String = oConf(0).sYahooUserID
        '        Dim userPass As String = oConf(0).sYahooUserPASS
        '        Dim webCtl As New cYahooProductMstWebCtl(businessID, businessPass, userID, userPass)
        '        webCtl.download()
        '    Case 1  '楽天
        '        Dim businessID As String = oConf(0).sRakutenRMSUserID
        '        Dim businessPass As String = oConf(0).sRakutenRMSUserPASS
        '        Dim userID As String = oConf(0).sRakutenUserID
        '        Dim userPass As String = oConf(0).sRakutenUserPASS
        '        Dim webCtl As New cRakutenProductWebCtl(businessID, businessPass, userID, userPass)
        '        webCtl.download()
        'End Select
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        NotifyIcon1.Visible = False ' アイコンをトレイから取り除く
        Application.Exit() ' アプリケーションの終了
    End Sub

    Private Sub Timer_Icon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Icon.Tick
        Me.ChangeAnimatedTasktrayIcon()

        Dim mode As Integer = Today.ToOADate() Mod 2
        Select Case mode
            Case 0  'Yahoo
                YahooUpdate()
            Case 1  '楽天
                RakutenUpdate()
        End Select

        UpdateCnt = UpdateCnt + 1
        Timer_Icon.Interval = 14400000     '4時間に一回実行
    End Sub
    Private Sub YahooUpdate()
        Dim businessID As String = oConf(0).sRakutenRMSUserID
        Dim businessPass As String = oConf(0).sRakutenRMSUserPASS
        Dim userID As String = oConf(0).sRakutenUserID
        Dim userPass As String = oConf(0).sRakutenUserPASS
        Dim webCtl As New cYahooProductWebCtl(businessID, businessPass, userID, userPass)
        webCtl.download()
    End Sub
    Private Sub RakutenUpdate()
        Dim businessID As String = oConf(0).sRakutenRMSUserID
        Dim businessPass As String = oConf(0).sRakutenRMSUserPASS
        Dim userID As String = oConf(0).sRakutenUserID
        Dim userPass As String = oConf(0).sRakutenUserPASS
        Dim webCtl As New cRakutenProductWebCtl(businessID, businessPass, userID, userPass)
        webCtl.download()
    End Sub


    'アニメ表示時にタスクトレイアイコンを変更する
    Private Sub ChangeAnimatedTasktrayIcon()

        '次に表示するアイコンを決める
        Select Case Me.currentTasktrayIconIndex
            Case 0
                Me.currentTasktrayIconIndex = 1
            Case 1
                Me.currentTasktrayIconIndex = 2
            Case 2
                Me.currentTasktrayIconIndex = 1
        End Select

        'タスクトレイアイコンを変更する
        Me.NotifyIcon1.Icon = Me.tasktrayIcons(Me.currentTasktrayIconIndex)

    End Sub
End Class
