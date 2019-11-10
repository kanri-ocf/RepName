Public Class fCripNoteRead
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------

    'タスクトレイにアニメで表示するアイコン
    Private tasktrayIcons() As Icon
    'アニメで現在表示しているアイコンのインデックス
    Private currentTasktrayIconIndex As Integer

    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

    End Sub

    Private Sub fAutoImport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        NotifyIcon1.Dispose()

    End Sub

    Private Sub CripNoteRead_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'タスクトレイアイコンをフォームのアイコンにする
        Me.NotifyIcon1.Icon = Me.Icon
        Me.NotifyIcon1.Visible = True

        'タイマーを無効にしておく（初めはアニメしない）
        Me.Timer_Copy.Enabled = False
        'アニメ時は、1秒毎にアイコンを変更する
        Me.Timer_Copy.Interval = 1000

        'タスクトレイにアニメで表示するアイコンを指定する
        Me.currentTasktrayIconIndex = 0
        Me.tasktrayIcons = New Icon() { _
            New Icon(Application.StartupPath & "\Picture\CripNoteRead01.ico"), _
            New Icon(Application.StartupPath & "\Picture\CripNoteRead02.ico"), _
            New Icon(Application.StartupPath & "\Picture\CripNoteRead03.ico")}
        AddHandler Timer_Icon.Tick, AddressOf Timer_Icon_Tick

        Me.Hide()

        Timer_Copy.Interval = 1000
        Timer_Copy.Start()
        Timer_Icon.Interval = 1000
        Timer_Icon.Stop()
    End Sub

    Private Sub Timer_Copy_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer_Copy.Tick
        Dim oConn As OleDb.OleDbConnection
        Dim oCommand As New OleDb.OleDbCommand
        Dim oDataReader As OleDb.OleDbDataReader
        Dim oConf() As cStructureLib.sConfig
        Dim oMstConfigDBIO As cMstConfigDBIO
        Dim oTool As cTool
        Dim RecordCnt As Integer
        Dim StrPath As String
        Dim DB_Path As String

        'タスクトレイアイコンを変更する
        Me.NotifyIcon1.Icon = Me.tasktrayIcons(1)

        Timer_Copy.Stop()
        Timer_Icon.Start()
        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

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

        If RecordCnt > 0 Then

            Dim result As String = ""

            'YahooビジネスID読込み
            If oConf(0).sYahooBisIDLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sYahooBisIDLinkPG)
                oConf(0).sYahooBisID = IIf(result = "", oConf(0).sYahooBisID, result)
            End If

            'YahooビジネスPASS読込み
            If oConf(0).sYahooBisPASSLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sYahooBisPASSLinkPG)
                oConf(0).sYahooBisPASS = IIf(result = "", oConf(0).sYahooBisPASS, result)
            End If

            'YahooユーザーID読込み
            If oConf(0).sYahooUserIDLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sYahooUserIDLinkPG)
                oConf(0).sYahooUserID = IIf(result = "", oConf(0).sYahooUserID, result)
            End If

            'YahooユーザーPASS読込み
            If oConf(0).sYahooUserPASSLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sYahooUserPASSLinkPG)
                oConf(0).sYahooUserPASS = IIf(result = "", oConf(0).sYahooUserPASS, result)
            End If

            '楽天RMSユーザーID読込み
            If oConf(0).sRakutenRMSUserIDLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenRMSUserIDLinkPG)
                oConf(0).sRakutenRMSUserID = IIf(result = "", oConf(0).sRakutenRMSUserID, result)
            End If

            '楽天RMSユーザーPASS読込み
            If oConf(0).sRakutenRMSUserPASSLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenRMSUserPASSLinkPG)
                oConf(0).sRakutenRMSUserPASS = IIf(result = "", oConf(0).sRakutenRMSUserPASS, result)
            End If

            '楽天ユーザーID読込み
            If oConf(0).sRakutenUserIDLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenUserIDLinkPG)
                oConf(0).sRakutenUserID = IIf(result = "", oConf(0).sRakutenUserID, result)
            End If

            '楽天ユーザーPASS読込み
            If oConf(0).sRakutenUserPASSLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenUserPASSLinkPG)
                oConf(0).sRakutenUserPASS = IIf(result = "", oConf(0).sRakutenUserPASS, result)
            End If

            '楽天ＣＳＶダウンロードユーザーID読込み
            If oConf(0).sRakutenCSVDownloadIDLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenCSVDownloadIDLinkPG)
                oConf(0).sRakutenCSVDownloadID = IIf(result = "", oConf(0).sRakutenCSVDownloadID, result)
            End If

            '楽天ＣＳＶダウンロードユーザーPASS読込み
            If oConf(0).sRakutenCSVDownloadPASSLinkPG <> "" Then
                result = oTool.CripNoteRead(oConf(0).sRakutenCSVDownloadPASSLinkPG)
                oConf(0).sRakutenCSVDownloadPASS = IIf(result = "", oConf(0).sRakutenCSVDownloadPASS, result)
            End If

            oMstConfigDBIO.updateConfMst(oConf, Nothing)

        End If
        oMstConfigDBIO = Nothing

        Trace.WriteLine(String.Format("{0:HH:mm:ss}", Now))

        Timer_Copy.Interval = 3600000

        Timer_Icon.Stop()
        Timer_Copy.Start()

        'タスクトレイアイコンを変更する
        Me.NotifyIcon1.Icon = Me.tasktrayIcons(0)

        oMstConfigDBIO = Nothing
        oConn = Nothing
        oCommand = Nothing
        oDataReader = Nothing
    End Sub

    Private Sub Timer_Icon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChangeAnimatedTasktrayIcon()
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



    Private Sub 終了ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        NotifyIcon1.Visible = False ' アイコンをトレイから取り除く
        Application.Exit() ' アプリケーションの終了
    End Sub
End Class
