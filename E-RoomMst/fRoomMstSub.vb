Public Class fRoomMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oRoom() As cStructureLib.sRoom
    Private oRoomBumon() As cStructureLib.sRoomBumon
    Private oRoomDBIO As cMstRoomDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_ROOM_CODE As Integer
    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyRoomCode As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oConf = iConf

        oTran = iTran

        '新規／更新のモード設定
        If iKeyRoomCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_ROOM_CODE = iKeyRoomCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oRoomDBIO = New cMstRoomDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oStaffDBIO.getStaff(oStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        oTool = New cTool

        IVENT_FLG = False

        'チャネルセット
        CHANNEL_SET()

        '部門セット
        BUMON_SET()

        'グリッド生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "（更新）"
            DELETE_B.Enabled = True
            ROOM_CODE_T.ReadOnly = True
            ROOM_CODE_T.BackColor = Color.White

            'ルーム情報セット
            ROOM_DISP()

        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "（新規）"
        End If

        IVENT_FLG = True

    End Sub

    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        ReDim oChannel(0)
        RecordCnt = oChannelDBIO.getChannelMst(oChannel, Nothing, 1, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタが登録されていません", _
                                                "部門マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "チャネルマスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CHANNEL_NAME_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing

    End Sub

    Private Sub BUMON_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '部門コンボ内容設定
        ReDim oBumon(0)
        RecordCnt = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
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
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            BUMON_NAME_L.Items.Add(oBumon(i).sBumonName)
        Next
        oDataReader = Nothing

    End Sub

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        DATA_V.RowHeadersVisible = False
        DATA_V.ColumnHeadersHeight = 30
        DATA_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim Column0 As New DataGridViewTextBoxColumn
        Column0.HeaderText = "部門コード"
        DATA_V.Columns.Add(Column0)
        Column0.ReadOnly = True
        Column0.Width = 90
        Column0.Name = "部門コード"
        Column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "部門名称"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 400
        column1.Name = "部門名称"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column2.HeaderText = "予約可能"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 100
        column2.Name = "予約可能"

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub ROOM_DISP()
        Dim pRoom() As cStructureLib.sRoom
        Dim pChannel() As cStructureLib.sChannel

        ReDim oRoom(0)
        oRoomDBIO.getRoom(oRoom, S_ROOM_CODE, Nothing, oTran)

        ROOM_CODE_T.Text = oRoom(0).sRoomCode
        ROOM_CODE_T.ReadOnly = True

        ReDim pRoom(0)
        oRoomDBIO.getRoom(pRoom, oRoom(0).sRoomCode, Nothing, oTran)
        ROOM_CODE_T.Text = pRoom(0).sRoomCode
        ROOM_NAME_T.Text = pRoom(0).sRoomName

        ReDim pChannel(0)
        oChannelDBIO.getChannelMst(pChannel, pRoom(0).sChannelCode, 1, Nothing, Nothing, oTran)
        CHANNEL_NAME_L.Text = pChannel(0).sChannelName
        CHANNEL_CODE_T.Text = oRoom(0).sChannelCode

        BUMON_DISP()
    End Sub

    Private Sub BUMON_DISP()
        Dim RecordCnt As Integer
        Dim i As Integer
        Dim pBumon() As cStructureLib.sBumon

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        ReDim oRoomBumon(0)
        RecordCnt = oRoomDBIO.getRoomBumon(oRoomBumon, ROOM_CODE_T.Text, Nothing, oTran)

        For i = 0 To RecordCnt - 1
            '部門コンボ内容設定
            ReDim pBumon(0)
            oBumonDBIO.getBumonMst(pBumon, oRoomBumon(i).sBumonCode, Nothing, Nothing, True, Nothing, Nothing, oTran)

            DATA_V.Rows.Add( _
                pBumon(0).sBumonCode, _
                pBumon(0).sBumonName, _
                pBumon(0).sReservFlg _
            )
        Next i
    End Sub

    Private Sub INIT_PROC()

        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        ROOM_CODE_T.Text = oRoomDBIO.getNewRoomCode(oTran)
        ROOM_CODE_T.ReadOnly = False
        ROOM_CODE_T.BackColor = Color.LightGreen
        DELETE_B.Enabled = False
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Private Sub CLOSE_PROC()
        oConn = Nothing
        oRoomDBIO = Nothing
        oBumonDBIO = Nothing
        oStaffDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '役割マスタの削除
        ret = oRoomDBIO.deleteRoom(ROOM_CODE_T.Text, oTran)


        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                    "登録が完了しました。", _
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If CHANNEL_NAME_L.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "チャネル名称が未選択です。", _
                                             "チャネル名称を選択して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CHANNEL_NAME_L.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If ROOM_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "ルーム名称が未入力です。",
                                             "ルーム名称を入力して下さい。",
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            ROOM_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function
    Private Sub COMMIT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '必須入力確認
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        oTran = Nothing
        oTran = oConn.BeginTransaction

        'ルームマスタの登録
        ReDim oRoom(0)
        oRoom(0).sRoomCode = CInt(ROOM_CODE_T.Text)
        oRoom(0).sRoomName = ROOM_NAME_T.Text
        oRoom(0).sChannelCode = CInt(CHANNEL_CODE_T.Text)

        If EDIT_MODE = False Then
            ret = oRoomDBIO.insertRoom(oRoom(0), oTran)
        Else
            ret = oRoomDBIO.updateRoom(oRoom, oTran)
        End If

        'ルーム利用分野マスタの登録

        oRoomDBIO.deleteRoomBumon(CInt(ROOM_CODE_T.Text), Nothing, oTran)

        For i = 0 To DATA_V.Rows.Count - 1
            ReDim oRoomBumon(0)
            oRoomBumon(0).sRoomCode = CInt(ROOM_CODE_T.Text)
            oRoomBumon(0).sBumonCode = CInt(DATA_V("部門コード", i).Value)
            oRoomDBIO.insertRoomBumon(oRoomBumon(0), oTran)
        Next i

        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                        "登録が完了しました。", _
                        Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()
        Message_form = Nothing
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "変更は破棄されます。", _
                                                    "よろしいですか？", _
                                                    Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If

        Message_form = Nothing
        Application.DoEvents()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        CLOSE_PROC()

    End Sub

    Private Sub CHANNEL_NAME_L_SelectedValueChanged(sender As Object, e As EventArgs) Handles CHANNEL_NAME_L.SelectedValueChanged
        If CHANNEL_NAME_L.SelectedIndex <> -1 Then
            CHANNEL_CODE_T.Text = oChannel(CHANNEL_NAME_L.SelectedIndex).sChannelCode
        End If

    End Sub

    Private Sub BUMON_NAME_L_SelectedValueChanged(sender As Object, e As EventArgs) Handles BUMON_NAME_L.SelectedValueChanged
        If BUMON_NAME_L.SelectedIndex <> -1 Then
            BUMON_CODE_T.Text = oBumon(BUMON_NAME_L.SelectedIndex).sBumonCode
        End If

    End Sub

    Private Sub BUMON_ADD_B_Click(sender As Object, e As EventArgs) Handles BUMON_ADD_B.Click
        Dim pBumon() As cStructureLib.sBumon

        '部門コンボ内容設定
        ReDim pBumon(0)
        oBumonDBIO.getBumonMst(pBumon, CInt(BUMON_CODE_T.Text), Nothing, Nothing, True, Nothing, Nothing, oTran)

        DATA_V.Rows.Add( _
            pBumon(0).sBumonCode, _
            pBumon(0).sBumonName, _
            pBumon(0).sReservFlg _
        )

    End Sub

    Private Sub DATA_V_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If

        BUMON_CODE_T.Text = DATA_V("部門コード", SelRow).Value
        BUMON_NAME_L.Text = DATA_V("部門名称", SelRow).Value

    End Sub

    Private Sub BUMON_DEL_B_Click(sender As Object, e As EventArgs) Handles BUMON_DEL_B.Click
        Dim r As DataGridViewRow
        For Each r In DATA_V.SelectedRows
            If Not r.IsNewRow Then
                DATA_V.Rows.Remove(r)
            End If
        Next r

    End Sub
End Class
