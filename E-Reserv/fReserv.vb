Public Class fReserv
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oRoom() As cStructureLib.sRoom
    Private oMstRoomDBIO As cMstRoomDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oMstBumonDBIO As cMstBumonDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oMstStaffDBIO As cMstStaffDBIO

    Private oReserv() As cStructureLib.sReserv
    Private oReservFull() As cStructureLib.sViewReservFull
    Private oDataReservDBIO As cDataReservDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private DB_CONNECT As Boolean

    Private CellWide As Integer
    Private CellCnt As Integer
    Private ChartWide As Integer

    Private StartTime As Integer
    Private EndTime As Integer

    Private IVENT_FLG As Boolean

    Private DayCnt As Integer
    Private RecCnt As Long
    Private RoomCnt As Integer
    Private StaffCnt As Integer

    Private RUN_MODE As Integer '0：日予約　　1：時間予約
    Private CHART_MODE As String
    Private OFFSET As Integer

    Dim BARCOLOR(10) As System.Drawing.Color

    Private oTran As System.Data.OleDb.OleDbTransaction

    ''******************************************************************
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

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        'RUN_MODE = 1

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        On Error Resume Next
        'ＤＢ接続を開く
        oConn.Open()

        DB_CONNECT = True

        If oConn.State = ConnectionState.Open Then
            oDataReservDBIO = New cDataReservDBIO(oConn, oCommand, oDataReader)
            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
            oMstRoomDBIO = New cMstRoomDBIO(oConn, oCommand, oDataReader)
            oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
            oMstBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        Else
            DB_CONNECT = False
        End If

        IVENT_FLG = True
    End Sub
    Sub New(ByVal iRunMode As Integer)

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        RUN_MODE = iRunMode

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        On Error Resume Next
        'ＤＢ接続を開く
        oConn.Open()

        DB_CONNECT = True

        If oConn.State = ConnectionState.Open Then
            oDataReservDBIO = New cDataReservDBIO(oConn, oCommand, oDataReader)
            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
            oMstRoomDBIO = New cMstRoomDBIO(oConn, oCommand, oDataReader)
            oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
            oMstBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        Else
            DB_CONNECT = False
        End If

        IVENT_FLG = True
    End Sub
    
    Private Sub fReserv_Load(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        If DB_CONNECT = False Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "データベースの接続に失敗しました。", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        Else
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
                Message_form = Nothing
                Application.DoEvents()
                Application.Exit()
            End If

            If STAFF_CODE = Nothing Then
                'スタッフ入力ウィンドウ表示
                Dim staff_form As cStaffEntryLib.fStaffEntry

                staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
                staff_form.ShowDialog()
                Application.DoEvents()
                If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
                    '担当者セット
                    STAFF_CODE = staff_form.STAFF_CODE
                    STAFF_NAME = staff_form.STAFF_NAME
                    staff_form = Nothing
                Else
                    staff_form = Nothing
                    Environment.Exit(1)
                End If
            End If

            'カラーコレクション生成
            COLOR_SET()

            'チャネル名称設定
            CHANNEL_SET()

            'サービス商品名称(部門名称)設定
            BUMON_SET()

            '初期表示月セット
            MONTH_T.Text = String.Format("{0:yyyy/MM}", Now)

            'チャート生成
            CHART_CREATE()

            'データ読込み
            DATA_SET()

        End If
    End Sub
    Private Sub COLOR_SET()

        BARCOLOR(0) = Color.Red
        BARCOLOR(1) = Color.Blue
        BARCOLOR(2) = Color.Orange
        BARCOLOR(3) = Color.DarkGreen
        BARCOLOR(4) = Color.DarkViolet
        BARCOLOR(5) = Color.LightBlue
        BARCOLOR(6) = Color.GreenYellow
        BARCOLOR(7) = Color.Pink
        BARCOLOR(8) = Color.Navy
        BARCOLOR(9) = Color.Olive

    End Sub
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'サービス担当者コンボ内容設定
        oChannel = Nothing
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 1, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタが登録されていません", _
                                                "チャネルマスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_NAME_C.SelectedIndex = 0
    End Sub
    Private Sub BUMON_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'サービス商品名称コンボ内容設定
        oBumon = Nothing
        'RecordCnt = oMstBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, True, Nothing, oTran)
        RecordCnt = oMstBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "部門マスタが登録されていません", _
                                                "部門マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "部門マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        IVENT_FLG = False
        For i = 0 To RecordCnt - 1
            BUMON_NAME_C.Items.Add(oBumon(i).sBumonName)
        Next
        BUMON_NAME_C.SelectedIndex = 0
        If oBumon(0).sReservPeace = "D" Then
            RUN_MODE = 0
        Else
            RUN_MODE = 1
        End If
        IVENT_FLG = True
    End Sub

    Private Sub DAY_CHART_CAL_PROC()
        Dim bTime As Integer
        Dim dt As Date

        CellWide = 30
        ChartWide = 800

        '月末日取得
        dt = Date.Parse(oTool.MaskClear(MONTH_T.Text) & "/01")
        dt = dt.AddMonths(1)
        dt = dt.AddDays(-1)
        DayCnt = dt.Day

        StartTime = 1
        EndTime = DayCnt + 1
        bTime = EndTime - StartTime

        CellWide = CInt(ChartWide / bTime)
        CellCnt = EndTime - StartTime
        CHART_V.Size = New System.Drawing.Size(288 + (CellWide * CellCnt), 600)


    End Sub
    Private Sub TIME_CHART_CAL_PROC()
        Dim bTime As Integer

        CellWide = 15
        ChartWide = 350

        If oConf(0).sCloseHour = 0 Then
            StartTime = 0
            EndTime = 24
        Else
            If oConf(0).sOpenHour - 2 > 0 Then
                StartTime = oConf(0).sOpenHour - 2
            Else
                StartTime = 0
            End If

            If oConf(0).sCloseHour + 2 < 24 Then
                EndTime = oConf(0).sCloseHour + 2
            Else
                EndTime = 24
            End If

        End If
        bTime = EndTime - StartTime

        CellWide = ChartWide / bTime
        CellCnt = (EndTime - StartTime) * 2
        CHART_V.Size = New System.Drawing.Size(288 + (CellWide * CellCnt), 600)

    End Sub
    Private Sub GRIDVIEW_CREATE()
        Dim CellBox() As DataGridViewTextBoxColumn
        Dim HeaderLabel() As System.Windows.Forms.Label
        Dim cs() As Control
        Dim i As Integer
        Dim j As Integer
        Dim cnt As Integer

        CHART_V.Rows.Clear()
        CHART_V.Columns.Clear()

        If RUN_MODE = 0 Then      '日単位予約の場合
            Dim cStartDay As New DataGridViewTextBoxColumn
            cStartDay.HeaderText = ""
            CHART_V.Columns.Add(cStartDay)
            cStartDay.Width = 30
            cStartDay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cStartDay.DefaultCellStyle.BackColor = Color.Wheat
            cStartDay.Name = "開始日"
            cStartDay.Visible = False

            Dim cEndDay As New DataGridViewTextBoxColumn
            cEndDay.HeaderText = ""
            CHART_V.Columns.Add(cEndDay)
            cEndDay.Width = 30
            cEndDay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cEndDay.DefaultCellStyle.BackColor = Color.Wheat
            cEndDay.Name = "終了日"
            cEndDay.Visible = False

            Dim cRoomCode As New DataGridViewTextBoxColumn
            cRoomCode.HeaderText = ""
            CHART_V.Columns.Add(cRoomCode)
            cRoomCode.Width = 10
            cRoomCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cRoomCode.DefaultCellStyle.BackColor = Color.Wheat
            cRoomCode.ReadOnly = True
            cRoomCode.Name = "ルームコード"
            cRoomCode.Visible = False

            Dim cRoomName As New DataGridViewTextBoxColumn
            cRoomName.HeaderText = ""
            CHART_V.Columns.Add(cRoomName)
            cRoomName.Width = 200
            cRoomName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            cRoomName.DefaultCellStyle.BackColor = Color.Wheat
            cRoomName.ReadOnly = True
            cRoomName.Name = "ルーム名称"

            'ヘッダーラベルクリア
            cnt = 0
            While 1
                cs = Me.Controls.Find(cnt, True)
                If cs.Length > 0 Then
                    Me.Controls.Remove(cs(0))
                Else
                    Exit While
                End If
                cnt += 1
            End While

            'ヘッダーラベル生成
            cnt = 0
            For i = StartTime To EndTime - 1
                ReDim Preserve HeaderLabel(i)
                HeaderLabel(i) = New System.Windows.Forms.Label
                HeaderLabel(i).Text = i
                HeaderLabel(i).Name = i - StartTime
                HeaderLabel(i).Location = New Point(209 + (CellWide * (i - 1)), 83)
                HeaderLabel(i).Size = New System.Drawing.Size(CellWide - 1, 23)
                HeaderLabel(i).BackColor = Color.SaddleBrown
                HeaderLabel(i).ForeColor = Color.White
                HeaderLabel(i).TextAlign = ContentAlignment.MiddleCenter
                Me.Controls.Add(HeaderLabel(i))

                ReDim Preserve CellBox(i)
                CellBox(i) = New DataGridViewTextBoxColumn
                CellBox(i).DataPropertyName = "c" & cnt
                CHART_V.Columns.Add(CellBox(i))
                CellBox(i).Width = CellWide
                CellBox(i).ReadOnly = True
                CellBox(i).Name = "c" & i
            Next i

            'ルーム名称
            ReDim Preserve HeaderLabel(i)
            HeaderLabel(i) = New System.Windows.Forms.Label
            HeaderLabel(i).Text = "ルーム名称"
            HeaderLabel(i).Name = i - StartTime
            HeaderLabel(i).Location = New Point(8, 60)
            HeaderLabel(i).Size = New System.Drawing.Size(199, 46)
            HeaderLabel(i).BackColor = Color.SaddleBrown
            HeaderLabel(i).ForeColor = Color.White
            HeaderLabel(i).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i))

            '予約チャート
            ReDim Preserve HeaderLabel(i + 1)
            HeaderLabel(i + 1) = New System.Windows.Forms.Label
            HeaderLabel(i + 1).Text = "予約チャート"
            HeaderLabel(i + 1).Name = i + 1 - StartTime
            HeaderLabel(i + 1).Location = New Point(209, 60)
            HeaderLabel(i + 1).Size = New System.Drawing.Size(CellWide * (i - 1), 22)
            HeaderLabel(i + 1).BackColor = Color.SaddleBrown
            HeaderLabel(i + 1).ForeColor = Color.White
            HeaderLabel(i + 1).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i + 1))
        Else        '時間単位予約の場合
            Dim cDay As New DataGridViewTextBoxColumn
            cDay.HeaderText = ""
            CHART_V.Columns.Add(cDay)
            cDay.Width = 30
            cDay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cDay.DefaultCellStyle.BackColor = Color.Wheat
            cDay.ReadOnly = True
            cDay.Name = "日付"

            Dim cStartHoure As New DataGridViewTextBoxColumn
            cStartHoure.HeaderText = "時"
            CHART_V.Columns.Add(cStartHoure)
            cStartHoure.Width = 30
            cStartHoure.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cStartHoure.DefaultCellStyle.BackColor = Color.Wheat
            cStartHoure.Name = "開始時"
            cStartHoure.Visible = False

            Dim cStartTime As New DataGridViewTextBoxColumn
            cStartTime.HeaderText = "分"
            CHART_V.Columns.Add(cStartTime)
            cStartTime.Width = 30
            cStartTime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cStartTime.DefaultCellStyle.BackColor = Color.Wheat
            cStartTime.Name = "開始分"
            cStartTime.Visible = False

            Dim cEndHoure As New DataGridViewTextBoxColumn
            cEndHoure.HeaderText = "時"
            CHART_V.Columns.Add(cEndHoure)
            cEndHoure.Width = 30
            cEndHoure.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cEndHoure.DefaultCellStyle.BackColor = Color.Wheat
            cEndHoure.Name = "終了時"
            cEndHoure.Visible = False

            Dim cEndTime As New DataGridViewTextBoxColumn
            cEndTime.HeaderText = "分"
            CHART_V.Columns.Add(cEndTime)
            cEndTime.Width = 30
            cEndTime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cEndTime.DefaultCellStyle.BackColor = Color.Wheat
            cEndTime.Name = "終了分"
            cEndTime.Visible = False

            Dim cRoomCode As New DataGridViewTextBoxColumn
            cRoomCode.HeaderText = ""
            CHART_V.Columns.Add(cRoomCode)
            cRoomCode.Width = 100
            cRoomCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cRoomCode.DefaultCellStyle.BackColor = Color.Wheat
            cRoomCode.ReadOnly = True
            cRoomCode.Name = "ルームコード"
            cRoomCode.Visible = False

            Dim cRoomName As New DataGridViewTextBoxColumn
            cRoomName.HeaderText = ""
            CHART_V.Columns.Add(cRoomName)
            cRoomName.Width = 100
            cRoomName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cRoomName.DefaultCellStyle.BackColor = Color.Wheat
            cRoomName.ReadOnly = True
            cRoomName.Name = "ルーム名称"

            Dim cStaffCode As New DataGridViewTextBoxColumn
            cStaffCode.HeaderText = ""
            CHART_V.Columns.Add(cStaffCode)
            cStaffCode.Width = 147
            cStaffCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cStaffCode.DefaultCellStyle.BackColor = Color.Wheat
            cStaffCode.ReadOnly = True
            cStaffCode.Name = "担当者コード"
            cStaffCode.Visible = False

            Dim cStaffName As New DataGridViewTextBoxColumn
            cStaffName.HeaderText = ""
            CHART_V.Columns.Add(cStaffName)
            cStaffName.Width = 147
            cStaffName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            cStaffName.DefaultCellStyle.BackColor = Color.Wheat
            cStaffName.ReadOnly = True
            cStaffName.Name = "担当者名称"

            'ヘッダーラベルクリア
            cnt = 0
            While 1
                cs = Me.Controls.Find(cnt, True)
                If cs.Length > 0 Then
                    Me.Controls.Remove(cs(0))
                Else
                    Exit While
                End If
                cnt += 1
            End While

            'ヘッダーラベル生成
            cnt = 0
            For i = StartTime To EndTime - 1
                ReDim Preserve HeaderLabel(i)
                HeaderLabel(i) = New System.Windows.Forms.Label
                HeaderLabel(i).Text = i
                HeaderLabel(i).Name = i - StartTime
                HeaderLabel(i).Location = New Point(286 + ((CellWide * 2) * (cnt / 2)), 83)
                HeaderLabel(i).Size = New System.Drawing.Size((CellWide * 2) - 1, 23)
                HeaderLabel(i).BackColor = Color.SaddleBrown
                HeaderLabel(i).ForeColor = Color.White
                HeaderLabel(i).TextAlign = ContentAlignment.MiddleCenter
                Me.Controls.Add(HeaderLabel(i))

                For j = 1 To 2
                    ReDim Preserve CellBox(cnt)
                    CellBox(cnt) = New DataGridViewTextBoxColumn
                    CellBox(cnt).DataPropertyName = "c" & cnt
                    CHART_V.Columns.Add(CellBox(cnt))
                    CellBox(cnt).Width = CellWide
                    CellBox(cnt).ReadOnly = True
                    CellBox(cnt).Name = "c" & cnt
                    cnt = cnt + 1
                Next j
            Next i
            '日付
            ReDim Preserve HeaderLabel(i)
            HeaderLabel(i) = New System.Windows.Forms.Label
            HeaderLabel(i).Text = "日付"
            HeaderLabel(i).Name = i - StartTime
            HeaderLabel(i).Location = New Point(8, 60)
            HeaderLabel(i).Size = New System.Drawing.Size(29, 46)
            HeaderLabel(i).BackColor = Color.SaddleBrown
            HeaderLabel(i).ForeColor = Color.White
            HeaderLabel(i).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i))

            'ルーム名称
            ReDim Preserve HeaderLabel(i + 1)
            HeaderLabel(i + 1) = New System.Windows.Forms.Label
            HeaderLabel(i + 1).Text = "ルーム名称"
            HeaderLabel(i + 1).Name = i + 1 - StartTime
            HeaderLabel(i + 1).Location = New Point(38, 60)
            HeaderLabel(i + 1).Size = New System.Drawing.Size(99, 46)
            HeaderLabel(i + 1).BackColor = Color.SaddleBrown
            HeaderLabel(i + 1).ForeColor = Color.White
            HeaderLabel(i + 1).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i + 1))

            '担当者名称
            ReDim Preserve HeaderLabel(i + 2)
            HeaderLabel(i + 2) = New System.Windows.Forms.Label
            HeaderLabel(i + 2).Text = "担当者名称"
            HeaderLabel(i + 2).Name = i + 2 - StartTime
            HeaderLabel(i + 2).Location = New Point(138, 60)
            HeaderLabel(i + 2).Size = New System.Drawing.Size(146, 46)
            HeaderLabel(i + 2).BackColor = Color.SaddleBrown
            HeaderLabel(i + 2).ForeColor = Color.White
            HeaderLabel(i + 2).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i + 2))

            '予約チャート
            ReDim Preserve HeaderLabel(i + 3)
            HeaderLabel(i + 3) = New System.Windows.Forms.Label
            HeaderLabel(i + 3).Text = "予約チャート"
            HeaderLabel(i + 3).Name = i + 3 - StartTime
            HeaderLabel(i + 3).Location = New Point(286, 60)
            HeaderLabel(i + 3).Size = New System.Drawing.Size(701, 22)
            HeaderLabel(i + 3).BackColor = Color.SaddleBrown
            HeaderLabel(i + 3).ForeColor = Color.White
            HeaderLabel(i + 3).TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(HeaderLabel(i + 3))
        End If
    End Sub

    Private Sub CHART_V_CellMouseDown(ByVal sCloseer As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles CHART_V.CellMouseDown
        ' 右ボタンのクリックか？
        If e.Button = MouseButtons.Right Then

            ' ヘッダ以外のセルか？
            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then

                ' 右クリックされたセル
                Dim cell As DataGridViewCell = CHART_V(e.ColumnIndex, e.RowIndex)
                '' セルの選択状態を反転
                'cell.Selected = Not cell.Selected
                CHART_V.CurrentCell = CHART_V(e.ColumnIndex, e.RowIndex)
            End If
        End If

    End Sub

    Private Sub CHART_V_CellStyleChanged(ByVal sCloseer As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CHART_V.CellStyleChanged

    End Sub

    Private Sub CHART_V_CellValueChanged(ByVal sCloseer As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CHART_V.CellValueChanged
        If IVENT_FLG = True Then
            If e.ColumnIndex < OFFSET And (CHART_V("終了時", e.RowIndex).Value <> "" And CHART_V("終了分", e.RowIndex).Value <> "") Then
                DATA_SET()
            End If
        End If
    End Sub
    Private Sub CHART_CREATE()

        IVENT_FLG = False

        '初期化
        CHART_V.Rows.Clear()

        If RUN_MODE = 0 Then        '日単位の予約の場合
            OFFSET = 4
            'チャート領域計算
            DAY_CHART_CAL_PROC()

            '明細表示エリアタイトル行生成
            CHART_V.SuspendLayout()
            GRIDVIEW_CREATE()
            CHART_V.ResumeLayout(False)

            DAY_CHART_CREATE()
        Else        '時間単位の予約の場合
            OFFSET = 9
            'チャート領域計算
            TIME_CHART_CAL_PROC()

            '明細表示エリアタイトル行生成
            CHART_V.SuspendLayout()
            GRIDVIEW_CREATE()
            CHART_V.ResumeLayout(False)

            TIME_CHART_CREATE()
        End If
        IVENT_FLG = True

    End Sub
    Private Sub DAY_CHART_CREATE()
        Dim i As Integer
        Dim dt As Date
        Dim sDay As String
        Dim sRoomCode As String
        Dim sRoomName As String
        Dim RowNo As Integer

        '月末日取得
        dt = Date.Parse(oTool.MaskClear(MONTH_T.Text) & "/01")
        dt = dt.AddMonths(1)
        dt = dt.AddDays(-1)
        DayCnt = dt.Day

        ReDim oRoom(0)
        RoomCnt = oMstRoomDBIO.getRoom(oRoom, Nothing, CInt(CHANNEL_CODE_T.Text), oTran)

        ReDim oReservFull(0)
        RecCnt = oDataReservDBIO.getReservFull(oReservFull, Nothing, oTool.MaskClear(MONTH_T.Text), Nothing, Nothing, Nothing, CInt(CHANNEL_CODE_T.Text), BUMON_CODE_T.Text, oTran)

        RowNo = 0
        For i = 0 To RoomCnt - 1

            '日付作成
            sDay = i + 1

            'ルーム情報作成
            If RoomCnt = 0 Then
                sRoomCode = ""
                sRoomName = ""
            Else
                sRoomCode = oRoom(i).sRoomCode
                sRoomName = oRoom(i).sRoomName
            End If

            CHART_V.Rows.Add("", "", sRoomCode, sRoomName)

            ''重複項目の色を背景色に・・・
            'If RowNo > 0 Then
            '    'ルーム情報作成
            '    If CInt(CHART_V("ルームコード", RowNo - 1).Value) = oRoom(i).sRoomCode Then
            '        CHART_V("ルームコード", RowNo).Style.ForeColor = Color.Wheat
            '    End If
            'End If
            RowNo = RowNo + 1
        Next i
    End Sub
    Private Sub TIME_CHART_CREATE()
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim dt As Date
        Dim sDay As String
        Dim sRoomCode As String
        Dim sRoomName As String
        Dim sStaffCode As String
        Dim sStaffName As String
        Dim RowNo As Integer

        '月末日取得
        dt = Date.Parse(oTool.MaskClear(MONTH_T.Text) & "/01")
        dt = dt.AddMonths(1)
        dt = dt.AddDays(-1)
        DayCnt = dt.Day

        ReDim oRoom(0)
        RoomCnt = oMstRoomDBIO.getRoom(oRoom, Nothing, CInt(CHANNEL_CODE_T.Text), oTran)

        ReDim oStaff(0)
        StaffCnt = oMstStaffDBIO.getStaff(oStaff, Nothing, Nothing, Nothing, BUMON_CODE_T.Text, oTran)

        ReDim oReservFull(0)
        RecCnt = oDataReservDBIO.getReservFull(oReservFull, Nothing, oTool.MaskClear(MONTH_T.Text), Nothing, Nothing, Nothing, CInt(CHANNEL_CODE_T.Text), BUMON_CODE_T.Text, oTran)

        RowNo = 0
        For i = 0 To DayCnt - 1
            For j = 0 To RoomCnt - 1
                For k = 0 To StaffCnt - 1

                    '日付作成
                    sDay = i + 1

                    'ルーム情報作成
                    If RoomCnt = 0 Then
                        sRoomCode = ""
                        sRoomName = ""
                    Else
                        sRoomCode = oRoom(j).sRoomCode
                        sRoomName = oRoom(j).sRoomName
                    End If

                    '担当者情報作成
                    If StaffCnt = 0 Then
                        sStaffCode = ""
                        sStaffName = ""
                    Else
                        sStaffCode = oStaff(k).sStaffCode
                        sStaffName = oStaff(k).sStaffName
                    End If

                    CHART_V.Rows.Add(sDay, "", "", "", "", sRoomCode, sRoomName, sStaffCode, sStaffName)

                    '重複項目の色を背景色に・・・
                    If RowNo > 0 Then
                        '日付作成
                        If CHART_V("日付", RowNo - 1).Value = (i + 1).ToString Then
                            CHART_V("日付", RowNo).Style.ForeColor = Color.Wheat
                        End If
                        'ルーム情報作成
                        If CInt(CHART_V("ルームコード", RowNo - 1).Value) = oRoom(j).sRoomCode Then
                            CHART_V("ルームコード", RowNo).Style.ForeColor = Color.Wheat
                        End If
                        '担当者情報作成
                        If CHART_V("担当者コード", RowNo - 1).Value = oStaff(k).sStaffCode Then
                            CHART_V("担当者コード", RowNo).Style.ForeColor = Color.Wheat
                        End If
                    End If
                    RowNo = RowNo + 1
                Next k
            Next j
        Next i
    End Sub
    Private Sub DATA_SET()
        If RUN_MODE = 0 Then
            DAY_DATA_SET()
        Else
            TIME_DATA_SET()
        End If
    End Sub
    Private Sub DAY_DATA_SET()
        Dim RecCnt As Long
        Dim i As Integer
        Dim j As Integer
        Dim l As Integer
        Dim str() As String
        Dim pDay As Integer
        Dim ColCnt As Integer
        Dim ToDay As Integer
        Dim pDate As Date

        IVENT_FLG = False

        ReDim oReservFull(0)
        RecCnt = oDataReservDBIO.getReservFull(oReservFull, Nothing, Nothing, oTool.MaskClear(MONTH_T.Text), Nothing, Nothing, CInt(CHANNEL_CODE_T.Text), BUMON_CODE_T.Text, oTran)

        ColCnt = 0
        For i = 0 To RoomCnt - 1
            For j = 0 To RecCnt - 1
                str = oReservFull(l).sFromReserveDate.Split("/")
                pDay = CInt(str(2))

                If CInt(CHART_V("ルームコード", i).Value) = oReservFull(j).sRoomCode Then
                    If Date.Parse(oReservFull(j).sFromReserveDate).Day > Date.Parse(oReservFull(j).sToReserveDate).Day Then
                        pDate = oTool.GetEndDate(Date.Parse(oReservFull(j).sToReserveDate).Year.ToString & "/" & Date.Parse(oReservFull(j).sToReserveDate).Month.ToString)
                        ToDay = pDate.Day + 1
                    Else
                        ToDay = Date.Parse(oReservFull(j).sToReserveDate).Day
                    End If
                    If MONTH_T.Text.ToString.Substring(5, 2) = String.Format("{0:00}", Date.Parse(oReservFull(j).sFromReserveDate).Month) Then
                        CHART_V("開始日", i).Value = String.Format("{0:00}", Date.Parse(oReservFull(j).sFromReserveDate).Day)
                        If Date.Parse(oReservFull(j).sFromReserveDate).Day > Date.Parse(oReservFull(j).sToReserveDate).Day Then
                            pDate = oTool.GetEndDate(Date.Parse(oReservFull(j).sToReserveDate).Year.ToString & "/" & Date.Parse(oReservFull(j).sToReserveDate).Month.ToString)
                            ToDay = pDate.Day + 1
                        Else
                            ToDay = Date.Parse(oReservFull(j).sToReserveDate).Day
                        End If
                    Else
                        CHART_V("開始日", i).Value = "01"
                        If 1 > Date.Parse(oReservFull(j).sToReserveDate).Day Then
                            pDate = oTool.GetEndDate(Date.Parse(oReservFull(j).sToReserveDate).Year.ToString & "/" & Date.Parse(oReservFull(j).sToReserveDate).Month.ToString)
                            ToDay = pDate.Day + 1
                        Else
                            ToDay = Date.Parse(oReservFull(j).sToReserveDate).Day
                        End If
                    End If
                    CHART_V("終了日", i).Value = String.Format("{0:00}", ToDay)

                    For k = 0 To CellCnt - 1
                        If (((CInt(CHART_V("開始日", i).Value) - StartTime)) <= k _
                            And _
                            ((CInt(CHART_V("終了日", i).Value) - StartTime + 1)) > k) Then

                            CHART_V(OFFSET + k, i).Style.BackColor = BARCOLOR(ColCnt Mod 10)
                            CHART_V(OFFSET + k, i).Value = " "
                        End If
                    Next k
                    ColCnt += 1
                End If
            Next j
        Next i

        IVENT_FLG = True

    End Sub
    Private Sub TIME_DATA_SET()
        Dim RecCnt As Long
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim l As Integer
        Dim m As Integer
        Dim str() As String
        Dim pDay As Integer
        Dim RowNo As Integer
        Dim ColCnt As Integer

        IVENT_FLG = False

        ReDim oReservFull(0)
        RecCnt = oDataReservDBIO.getReservFull(oReservFull, Nothing, oTool.MaskClear(MONTH_T.Text), Nothing, Nothing, Nothing, CInt(CHANNEL_CODE_T.Text), BUMON_CODE_T.Text, oTran)

        ColCnt = 0
        RowNo = 0
        For i = 0 To DayCnt - 1
            For j = 0 To RoomCnt - 1
                For k = 0 To StaffCnt - 1
                    For l = 0 To RecCnt - 1
                        str = oReservFull(l).sFromReserveDate.Split("/")
                        pDay = CInt(str(2))

                        If CHART_V("日付", RowNo).Value = pDay.ToString _
                           And CHART_V("ルームコード", RowNo).Value = oReservFull(l).sRoomCode.ToString _
                           And CHART_V("担当者コード", RowNo).Value = oReservFull(l).sServiceStaffCode Then
                            CHART_V("開始時", RowNo).Value = String.Format("{0:00}", oReservFull(l).sFromHour)
                            CHART_V("開始分", RowNo).Value = String.Format("{0:00}", oReservFull(l).sfromMinute)
                            CHART_V("終了時", RowNo).Value = String.Format("{0:00}", oReservFull(l).sToHour)
                            CHART_V("終了分", RowNo).Value = String.Format("{0:00}", oReservFull(l).sToMinute)

                            'チャートペイント
                            For m = 0 To CellCnt - 1
                                If (((CInt(CHART_V("開始時", RowNo).Value) - StartTime) * 2) + _
                                    CInt(CHART_V("開始分", RowNo).Value) / 30) <= m _
                                    And _
                                    (((CInt(CHART_V("終了時", RowNo).Value) - StartTime) * 2) + _
                                     CInt(CHART_V("終了分", RowNo).Value) / 30) > m Then

                                    CHART_V(OFFSET + m, RowNo).Style.BackColor = BARCOLOR(ColCnt Mod 10)
                                    CHART_V(OFFSET + m, RowNo).Value = " "
                                End If
                            Next m
                            ColCnt += 1
                        End If
                    Next l
                    RowNo = RowNo + 1
                Next k
            Next j
        Next i

        IVENT_FLG = True

    End Sub
    Private Sub COMMIT_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        oMstChannelDBIO = Nothing
        oMstConfigDBIO = Nothing
        oMstRoomDBIO = Nothing
        oMstStaffDBIO = Nothing
        oMstBumonDBIO = Nothing
        oDataReservDBIO = Nothing
        Me.Dispose()
    End Sub

    Private Sub CHART_V_MouseUp(ByVal sCloseer As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CHART_V.MouseUp

        'TODO:後で
        Dim a As Integer
        a = CHART_V.GetCellCount(DataGridViewElementStates.Selected)
        a = CHART_V.Rows.GetRowCount(DataGridViewElementStates.Selected)
        a = CHART_V.Columns.GetColumnCount(DataGridViewElementStates.Selected)

        a = CHART_V.Rows.Count
        a = CHART_V.Columns.Count

        '2019.12.11 R.Takashima FROM
        'DataGridViewのRows、Columnsプロパティは行または列が全て選択されているときに実行される
        'そのため部分選択を行うと行数、列数はGetRowCount、GetColumnCountで取得することはできない
        'よって下記の処理は全て０を戻り値として縦方向の操作が出来てしまう

        ''2016.09.13 K.Oikawa s
        ''課題表No.177 縦方向への操作を禁ずる
        'Dim i = CHART_V.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'If CHART_V.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0 Then
        '    Exit Sub
        'End If
        ''2016.09.13 K.Oikawa e

        Dim row = CHART_V.SelectedCells(0).RowIndex
        Dim column = CHART_V.SelectedCells(0).ColumnIndex
        Dim message = New cMessageLib.fMessage(1,
                                            "複数行の選択はできません。",
                                            "選択をしなおしてください。",
                                            Nothing,
                                            Nothing
                                            )

        If row > 0 And row < CHART_V.Rows.Count Then
            If CHART_V(column, row - 1).Selected = True Then
                message.ShowDialog()
                message.Dispose()
                CHART_V.ClearSelection()
                Exit Sub

            ElseIf CHART_V.Rows.Count - 1 < row Then

                If CHART_V(column, row + 1).Selected = True Then
                    message.ShowDialog()
                    message.Dispose()
                    CHART_V.ClearSelection()
                    Exit Sub
                End If
            End If
        End If

        '2019.12.11 R.Takashima TO

        If RUN_MODE = 0 Then
            If e.Button = Windows.Forms.MouseButtons.Left Then  '新規入力の場合
                DAY_NEW_SELECT()
            Else    '更新入力の場合
                DAY_EDIT_SELECT()
            End If
        Else
            If e.Button = Windows.Forms.MouseButtons.Left Then  '新規入力の場合
                TIME_NEW_SELECT()
            Else    '更新入力の場合
                TIME_EDIT_SELECT()
            End If
        End If
    End Sub
    Private Sub DAY_NEW_SELECT()
        Dim form_ReservSub As fReservSub
        Dim MinLoc As Integer
        Dim MaxLoc As Integer
        Dim ColRow As Integer
        Dim FromReqDate As String
        Dim ToReqDate As String

        If CHART_V.CurrentCell.ColumnIndex > OFFSET Then
            MinLoc = 0
            MaxLoc = 0
            IVENT_FLG = False

            '重複確認
            For Each c As DataGridViewCell In CHART_V.SelectedCells
                If CHART_V(c.ColumnIndex, c.RowIndex).Value = " " Then
                    Dim Message_form As cMessageLib.fMessage

                    Message_form = New cMessageLib.fMessage(2, "予約が重複しています。", _
                                                    "このまま登録しますか？", _
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                        Message_form = Nothing
                        Exit Sub
                    End If
                    Message_form = Nothing
                    Exit For
                End If
            Next c

            'チャート明記処理
            For Each c As DataGridViewCell In CHART_V.SelectedCells
                ColRow = c.RowIndex
                If MinLoc = 0 Or MinLoc > c.ColumnIndex Then
                    MinLoc = c.ColumnIndex
                    CHART_V("開始日", c.RowIndex).Value = String.Format("{0:00}", StartTime + CInt(c.ColumnIndex - OFFSET))
                End If
                If MaxLoc = 0 Or MaxLoc < c.ColumnIndex Then
                    MaxLoc = c.ColumnIndex
                    CHART_V("終了日", c.RowIndex).Value = String.Format("{0:00}", StartTime + CInt(c.ColumnIndex - OFFSET))
                End If
            Next c
            IVENT_FLG = True

            '予約データ明細登録
            FromReqDate = oTool.MaskClear(MONTH_T.Text) & "/" & (MinLoc - OFFSET + 1).ToString.PadLeft(2, "0")
            ToReqDate = oTool.MaskClear(MONTH_T.Text) & "/" & (MaxLoc - OFFSET + 1).ToString.PadLeft(2, "0")
            form_ReservSub = New fReservSub( _
                                        oConn, _
                                        oCommand, _
                                        oDataReader, _
                                        Nothing, _
                                        CInt(CHANNEL_CODE_T.Text), _
                                        FromReqDate, _
                                        ToReqDate, _
                                        BUMON_CODE_T.Text, _
                                        CInt(CHART_V("ルームコード", ColRow).Value), _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        STAFF_CODE, _
                                        oTran _
                                )

            form_ReservSub.ShowDialog()
            form_ReservSub.Dispose()

            Select Case form_ReservSub.DialogResult
                Case Windows.Forms.DialogResult.OK          '「登録」で終了
                    CHART_CREATE()
                    DATA_SET()

                Case Windows.Forms.DialogResult.Cancel      '「戻る」で終了
                    MinLoc = 0
                    MaxLoc = 0
                    IVENT_FLG = False
                    For Each c As DataGridViewCell In CHART_V.SelectedCells
                        ColRow = c.RowIndex
                        If MinLoc = 0 Or MinLoc > c.ColumnIndex Then
                            MinLoc = c.ColumnIndex
                            CHART_V("開始日", c.RowIndex).Value = ""
                        End If
                        If MaxLoc = 0 Or MaxLoc < c.ColumnIndex Then
                            MaxLoc = c.ColumnIndex
                            CHART_V("終了日", c.RowIndex).Value = ""
                        End If
                    Next c
                    IVENT_FLG = True

                Case Windows.Forms.DialogResult.Abort       '「削除」で終了
            End Select

        End If

        form_ReservSub = Nothing

    End Sub
    Private Sub DAY_EDIT_SELECT()
        Dim form_ReservSub As fReservSub
        Dim ColRow As Integer
        Dim ReqDate As String
        Dim pHour As Integer
        Dim pMinute As Integer

        '2019.12.11 R.Takashima FROM
        '日付、ルーム名称、担当者名称が選択されたとき処理を行わないよう変更
        'If CHART_V.CurrentCell.Value <> "" Then
        If CHART_V.CurrentCell.Value <> "" And CHART_V.CurrentCell.ColumnIndex > 8 Then
            '2019.12.11 R.Takashima TO
            pHour = StartTime + oTool.ToRoundDown((CInt(CHART_V.CurrentCell.ColumnIndex) - OFFSET) / 2, 0)
            pMinute = ((CInt(CHART_V.CurrentCell.ColumnIndex) - OFFSET) Mod 2) * 30
            ReqDate = oTool.MaskClear(MONTH_T.Text) & "/" & (CInt(CHART_V.CurrentCell.ColumnIndex) - OFFSET + 1).ToString.PadLeft(2, "0")

            oDataReservDBIO.getReserv( _
                                        oReserv, _
                                        Nothing, _
                                        ReqDate, _
                                        ReqDate, _
                                        BUMON_CODE_T.Text, _
                                        CInt(CHART_V("ルームコード", CHART_V.CurrentCell.RowIndex).Value), _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        CInt(CHANNEL_CODE_T.Text), oTran _
                                    )

            form_ReservSub = New fReservSub( _
                                        oConn, _
                                        oCommand, _
                                        oDataReader, _
                                        oReserv(0).sReserveCode, _
                                        CInt(CHANNEL_CODE_T.Text), _
                                        ReqDate, _
                                        ReqDate, _
                                        BUMON_CODE_T.Text, _
                                        CInt(CHART_V("ルームコード", ColRow).Value), _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        STAFF_CODE, _
                                        oTran _
                                )
            form_ReservSub.ShowDialog()
            form_ReservSub.Dispose()

            CHART_CREATE()
            DATA_SET()
        End If

    End Sub
    Private Sub TIME_NEW_SELECT()
        Dim form_ReservSub As fReservSub
        Dim MinLoc As Integer
        Dim MaxLoc As Integer
        Dim ColRow As Integer
        Dim ReqDate As String

        IVENT_FLG = False

        If CHART_V.CurrentCell.ColumnIndex > OFFSET Then
            MinLoc = 0
            MaxLoc = 0

            '重複確認処理
            For Each c As DataGridViewCell In CHART_V.SelectedCells
                If CHART_V(c.ColumnIndex, c.RowIndex).Value = " " Then
                    Dim Message_form As cMessageLib.fMessage

                    Message_form = New cMessageLib.fMessage(2, "予約が重複しています。", _
                                                    "このまま登録しますか？", _
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                        Message_form = Nothing
                        Exit Sub
                    End If
                    Message_form = Nothing
                    Exit For
                End If
            Next c

            'チャート明記処理
            For Each c As DataGridViewCell In CHART_V.SelectedCells
                ColRow = c.RowIndex
                If MinLoc = 0 Or MinLoc > c.ColumnIndex Then
                    MinLoc = c.ColumnIndex
                    CHART_V("開始分", c.RowIndex).Value = String.Format("{0:00}", CInt((c.ColumnIndex - OFFSET) Mod 2) * 30)
                    CHART_V("開始時", c.RowIndex).Value = String.Format("{0:00}", StartTime + oTool.ToRoundDown(((c.ColumnIndex - OFFSET) / 2), 0))
                End If
                If MaxLoc = 0 Or MaxLoc < c.ColumnIndex Then
                    MaxLoc = c.ColumnIndex
                    CHART_V("終了時", c.RowIndex).Value = String.Format("{0:00}", StartTime + CInt((c.ColumnIndex - OFFSET) / 2))
                    CHART_V("終了分", c.RowIndex).Value = String.Format("{0:00}", System.Math.Abs(CInt(((c.ColumnIndex - OFFSET) Mod 2) - 1)) * 30)
                End If
            Next c

            '予約データ明細登録
            ReqDate = oTool.MaskClear(MONTH_T.Text) & "/" & CHART_V(0, ColRow).Value.ToString.PadLeft(2, "0")
            form_ReservSub = New fReservSub( _
                                        oConn, _
                                        oCommand, _
                                        oDataReader, _
                                        Nothing, _
                                        CInt(CHANNEL_CODE_T.Text), _
                                        ReqDate, _
                                        ReqDate, _
                                        BUMON_CODE_T.Text, _
                                        CInt(CHART_V("ルームコード", ColRow).Value), _
                                        CHART_V("担当者コード", ColRow).Value, _
                                        CHART_V("開始時", ColRow).Value, _
                                        CHART_V("開始分", ColRow).Value, _
                                        CHART_V("終了時", ColRow).Value, _
                                        CHART_V("終了分", ColRow).Value, _
                                        STAFF_CODE, _
                                        oTran _
                                )

            form_ReservSub.ShowDialog()
            form_ReservSub.Dispose()

            Select Case form_ReservSub.DialogResult
                Case Windows.Forms.DialogResult.OK          '「登録」で終了
                    CHART_CREATE()
                    DATA_SET()

                Case Windows.Forms.DialogResult.Cancel      '「戻る」で終了
                    MinLoc = 0
                    MaxLoc = 0
                    For Each c As DataGridViewCell In CHART_V.SelectedCells
                        ColRow = c.RowIndex
                        If MinLoc = 0 Or MinLoc > c.ColumnIndex Then
                            MinLoc = c.ColumnIndex
                            CHART_V("開始時", c.RowIndex).Value = ""
                            CHART_V("開始分", c.RowIndex).Value = ""
                        End If
                        If MaxLoc = 0 Or MaxLoc < c.ColumnIndex Then
                            MaxLoc = c.ColumnIndex
                            CHART_V("終了時", c.RowIndex).Value = ""
                            CHART_V("終了分", c.RowIndex).Value = ""
                        End If
                    Next c

                Case Windows.Forms.DialogResult.Abort       '「削除」で終了
            End Select

        End If

        IVENT_FLG = True
        form_ReservSub = Nothing

    End Sub
    Private Sub TIME_EDIT_SELECT()
        Dim form_ReservSub As fReservSub
        Dim ColRow As Integer
        Dim ReqDate As String
        Dim pHour As Integer
        Dim pMinute As Integer

        '2019.12.11 R.Takashima FROM
        '日付、ルーム名称、担当者名称が選択されたとき処理を行わないよう変更
        'If CHART_V.CurrentCell.Value <> "" Then
        If CHART_V.CurrentCell.Value <> "" And CHART_V.CurrentCell.ColumnIndex > 8 Then
            '2019.12.11 R.Takashima TO

            pHour = StartTime + oTool.ToRoundDown((CInt(CHART_V.CurrentCell.ColumnIndex) - OFFSET) / 2, 0)
            pMinute = ((CInt(CHART_V.CurrentCell.ColumnIndex) - OFFSET) Mod 2) * 30
            ReqDate = oTool.MaskClear(MONTH_T.Text) & "/" & CHART_V("日付", CHART_V.CurrentCell.RowIndex).Value.ToString.PadLeft(2, "0")

            oDataReservDBIO.getReserv(
                                        oReserv,
                                        Nothing,
                                        ReqDate,
                                        ReqDate,
                                        BUMON_CODE_T.Text,
                                        CInt(CHART_V("ルームコード", CHART_V.CurrentCell.RowIndex).Value),
                                        CHART_V("担当者コード", CHART_V.CurrentCell.RowIndex).Value,
                                        pHour,
                                        pMinute,
                                        CInt(CHANNEL_CODE_T.Text), oTran
                                    )

            form_ReservSub = New fReservSub(
                                        oConn,
                                        oCommand,
                                        oDataReader,
                                        oReserv(0).sReserveCode,
                                        CInt(CHANNEL_CODE_T.Text),
                                        ReqDate,
                                        ReqDate,
                                        BUMON_CODE_T.Text,
                                        CInt(CHART_V("ルームコード", ColRow).Value),
                                        CHART_V("担当者コード", ColRow).Value,
                                        Nothing,
                                        Nothing,
                                        Nothing,
                                        Nothing,
                                        STAFF_CODE,
                                        oTran
                                )
            form_ReservSub.ShowDialog()
            form_ReservSub.Dispose()

            CHART_CREATE()
            DATA_SET()
        End If

    End Sub
    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(ByVal sCloseer As Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_C.SelectedIndexChanged
        If CHANNEL_NAME_C.SelectedIndex <> -1 Then
            oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_C.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If

    End Sub

    Private Sub BUMON_NAME_C_SelectedIndexChanged(ByVal sCloseer As Object, ByVal e As System.EventArgs) Handles BUMON_NAME_C.SelectedIndexChanged
        Dim ReDisp As Boolean

        ReDisp = False
        If BUMON_NAME_C.SelectedIndex <> -1 Then
            'oMstBumonDBIO.getBumonMst(oBumon, Nothing, BUMON_NAME_C.Text, Nothing, Nothing, Nothing, oTran)
            oMstBumonDBIO.getBumonMst(oBumon, Nothing, BUMON_NAME_C.Text, Nothing, Nothing, Nothing, Nothing, oTran)
            BUMON_CODE_T.Text = oBumon(0).sBumonCode
            CHART_MODE = oBumon(0).sReservPeace
            If IVENT_FLG = True Then
                If RUN_MODE = 1 And oBumon(0).sReservPeace = "D" Or RUN_MODE = 0 And oBumon(0).sReservPeace = "H" Then
                    ReDisp = True
                    RUN_MODE = System.Math.Abs(RUN_MODE - 1)
                End If
                If ReDisp = True Then
                    CHART_CREATE()
                    DATA_SET()
                End If
            End If
        End If
    End Sub

    Private Sub PRE_MONTH_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles PRE_MONTH_B.Click
        Dim dt As DateTime

        dt = DateTime.Parse(MONTH_T.Text & "/01")
        MONTH_T.Text = String.Format("{0:yyyy/MM/dd}", dt.AddMonths(-1))

        CHART_CREATE()
        DATA_SET()
    End Sub

    Private Sub NEXT_MONTH_B_Click(ByVal sCloseer As System.Object, ByVal e As System.EventArgs) Handles NEXT_MONTH_B.Click
        Dim dt As DateTime

        dt = DateTime.Parse(MONTH_T.Text & "/01")
        MONTH_T.Text = String.Format("{0:yyyy/MM/dd}", dt.AddMonths(+1))

        CHART_CREATE()
        DATA_SET()
    End Sub

End Class