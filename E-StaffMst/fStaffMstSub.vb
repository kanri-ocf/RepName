Public Class fStaffMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oStaff() As cStructureLib.sStaff
    Private oStaffFull() As cStructureLib.sViewStaffFull
    Private oMstStaffDBIO As cMstStaffDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oRole() As cStructureLib.sRole
    Private oRoleDBIO As cMstRoleDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_STAFF_CODE As String
    Private S_STAFF_NAME As String
    Private S_ROLE_NAME As String

    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyStaffCode As String, _
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
        If iKeyStaffCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_STAFF_CODE = iKeyStaffCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oRoleDBIO = New cMstRoleDBIO(oConn, oCommand, oDataReader)

        oMstStaffDBIO.getStaff(oStaff, STAFF_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        oTool = New cTool

        'アクセス権限表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '権限マップ初期化
        AUTHORITY_INIT()

        IVENT_FLG = False

        'チャネルコンボボックスセット
        CHANNEL_SET()

        '役割リストボックスセット
        ROLE_SET()

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "（更新）"
            DELETE_B.Enabled = True
            SYAIN_CODE_T.ReadOnly = True
            SYAIN_CODE_T.BackColor = Color.White

            'スタッフ情報セット
            STAFF_DISP()

            '権限情報セット
            AUTHORITY_DISP()
        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "（新規）"
        End If

        IVENT_FLG = True

    End Sub
    Private Sub CHANNEL_SET()
        Dim RecordCount As Long
        Dim i As Long

        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, True, oTran)
        '再描画中止
        CHANNEL_NAME_C.BeginUpdate()

        'コンボボックスへのチャネル名セット
        CHANNEL_NAME_C.Items.Add("")
        For i = 0 To RecordCount - 1
            CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_NAME_C.SelectedIndex = 0

        '再描画再開
        CHANNEL_NAME_C.EndUpdate()

    End Sub
    Private Sub ROLE_SET()
        Dim i As Integer

        ReDim oRole(0)
        oRoleDBIO.getRole(oRole, Nothing, Nothing, oTran)

        For i = 0 To oRole.Length - 1
            ROLE_NAME_C.Items.Add(oRole(i).sRoleName)
        Next
    End Sub
    Private Sub STAFF_DISP()
        Dim pRole() As cStructureLib.sRole
        Dim sPath As String
        Dim tPath As String

        ReDim oStaffFull(0)
        oMstStaffDBIO.getStaffFull(oStaffFull, S_STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        'private変数にセット
        S_STAFF_CODE = oStaffFull(0).sStaffCode
        S_STAFF_NAME = oStaffFull(0).sStaffName
        S_ROLE_NAME = oStaffFull(0).sRoleName

        SYAIN_CODE_T.Text = oStaffFull(0).sStaffCode.Substring(4, 8)
        SYAIN_CODE_T.ReadOnly = True
        S_STAFF_CODE_T.Text = oStaffFull(0).sStaffCode

        'チャネルセット
        oChannelDBIO.getChannelMst(oChannel, CInt(oStaffFull(0).sStaffCode.Substring(4, 1)), Nothing, Nothing, Nothing, oTran)
        CHANNEL_NAME_C.Text = oChannel(0).sChannelName

        ReDim pRole(0)
        oRoleDBIO.getRole(pRole, oStaffFull(0).sRoleCode, Nothing, oTran)
        ROLE_NAME_C.Text = pRole(0).sRoleName
        ROLE_CODE_T.Text = pRole(0).sRoleCode
        S_STAFF_NAME_T.Text = oStaffFull(0).sStaffName
        Select Case oStaffFull(0).sStaffClass
            Case "E"
                S_E_CLASS_R.Checked = True
            Case "A"
                S_A_CLASS_R.Checked = True
            Case "P"
                S_P_CLASS_R.Checked = True
            Case "O"
                S_O_CLASS_R.Checked = True
        End Select
        RATE_T.Text = oStaffFull(0).sRate

        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\" & oStaffFull(0).sStaffCode & ".jpg"
        tPath = System.Windows.Forms.Application.StartupPath & "\StaffPhoto\" & oStaffFull(0).sStaffCode & ".jpg"

        'Tempのメンバー写真を削除
        System.IO.File.Delete(sPath)

        If System.IO.File.Exists(tPath) Then
            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            STAFF_PIC.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        Else
            STAFF_PIC.Image = Nothing
        End If

    End Sub
    Private Sub AUTHORITY_INIT()
        STAFF_AUTHORITY_INIT("販売管理", SALES_V)
        STAFF_AUTHORITY_INIT("ネットショップ管理", NET_V)
        STAFF_AUTHORITY_INIT("在庫管理", STOCK_V)
        STAFF_AUTHORITY_INIT("マスタ管理", MASTER_V)
        STAFF_AUTHORITY_INIT("システム管理", SYSTEM_V)
    End Sub
    Private Sub AUTHORITY_DISP()
        '権限情報セット
        STAFF_AUTHORITY_DISP("販売管理", SALES_V)
        STAFF_AUTHORITY_DISP("ネットショップ管理", NET_V)
        STAFF_AUTHORITY_DISP("在庫管理", STOCK_V)
        STAFF_AUTHORITY_DISP("マスタ管理", MASTER_V)
        STAFF_AUTHORITY_DISP("システム管理", SYSTEM_V)
    End Sub
    Private Sub INIT_PROC()
        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        SYAIN_CODE_T.Text = ""
        SYAIN_CODE_T.ReadOnly = False
        SYAIN_CODE_T.BackColor = Color.LightGreen
        S_STAFF_CODE_T.Text = ""
        S_STAFF_NAME_T.Text = ""
        S_E_CLASS_R.Checked = True
        RATE_T.Text = 0
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

    Sub GRIDVIEW_CREATE()
        '-------------- SALES_V (販売管理）----------------------
        'レコードセレクタを非表示に設定
        SALES_V.RowHeadersVisible = False
        SALES_V.ColumnHeadersHeight = 20
        SALES_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim sales1 As New DataGridViewTextBoxColumn
        sales1.HeaderText = "機能名称"
        SALES_V.Columns.Add(sales1)
        sales1.Width = 155
        sales1.ReadOnly = True
        sales1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        sales1.Name = "機能名称"

        Dim sales2 As New DataGridViewCheckBoxColumn
        sales2.HeaderText = "権限"
        SALES_V.Columns.Add(sales2)
        sales2.Width = 40
        sales2.Name = "権限"

        Dim sales3 As New DataGridViewCheckBoxColumn
        sales3.HeaderText = "アプリケーションID"
        SALES_V.Columns.Add(sales3)
        sales3.Width = 40
        sales3.Visible = False
        sales3.Name = "アプリケーションID"

        '背景色を白に設定
        SALES_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        SALES_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------- STOCK_V (在庫管理）----------------------
        'レコードセレクタを非表示に設定
        STOCK_V.RowHeadersVisible = False
        STOCK_V.ColumnHeadersHeight = 20
        STOCK_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim stock1 As New DataGridViewTextBoxColumn
        stock1.HeaderText = "機能名称"
        STOCK_V.Columns.Add(stock1)
        stock1.Width = 155
        stock1.ReadOnly = True
        stock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        stock1.Name = "機能名称"

        Dim stock2 As New DataGridViewCheckBoxColumn
        stock2.HeaderText = "権限"
        STOCK_V.Columns.Add(stock2)
        stock2.Width = 40
        stock2.Name = "権限"

        Dim stock3 As New DataGridViewCheckBoxColumn
        stock3.HeaderText = "アプリケーションID"
        STOCK_V.Columns.Add(stock3)
        stock3.Width = 40
        stock3.Visible = False
        stock3.Name = "アプリケーションID"

        '背景色を白に設定
        STOCK_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        STOCK_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------- NET_V (ネットショップ管理）----------------------
        'レコードセレクタを非表示に設定
        NET_V.RowHeadersVisible = False
        NET_V.ColumnHeadersHeight = 20
        NET_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim net1 As New DataGridViewTextBoxColumn
        net1.HeaderText = "機能名称"
        NET_V.Columns.Add(net1)
        net1.Width = 155
        net1.ReadOnly = True
        net1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        net1.Name = "機能名称"

        Dim net2 As New DataGridViewCheckBoxColumn
        net2.HeaderText = "権限"
        NET_V.Columns.Add(net2)
        net2.Width = 40
        net2.Name = "権限"

        Dim net3 As New DataGridViewCheckBoxColumn
        net3.HeaderText = "アプリケーションID"
        NET_V.Columns.Add(net3)
        net3.Width = 40
        net3.Visible = False
        net3.Name = "アプリケーションID"

        '背景色を白に設定
        NET_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        NET_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------- MASTER_V (マスター管理）----------------------
        'レコードセレクタを非表示に設定
        MASTER_V.RowHeadersVisible = False
        MASTER_V.ColumnHeadersHeight = 20
        MASTER_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim master1 As New DataGridViewTextBoxColumn
        master1.HeaderText = "機能名称"
        MASTER_V.Columns.Add(master1)
        master1.Width = 155
        master1.ReadOnly = True
        master1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        master1.Name = "機能名称"

        Dim master2 As New DataGridViewCheckBoxColumn
        master2.HeaderText = "権限"
        MASTER_V.Columns.Add(master2)
        master2.Width = 40
        master2.Name = "権限"

        Dim master3 As New DataGridViewCheckBoxColumn
        master3.HeaderText = "アプリケーションID"
        MASTER_V.Columns.Add(master3)
        master3.Width = 40
        master3.Visible = False
        master3.Name = "アプリケーションID"

        '背景色を白に設定
        MASTER_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        MASTER_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        '-------------- SYSTEM_V (システム管理）----------------------
        'レコードセレクタを非表示に設定
        SYSTEM_V.RowHeadersVisible = False
        SYSTEM_V.ColumnHeadersHeight = 20
        SYSTEM_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim system1 As New DataGridViewTextBoxColumn
        system1.HeaderText = "機能名称"
        SYSTEM_V.Columns.Add(system1)
        system1.Width = 155
        system1.ReadOnly = True
        system1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        system1.Name = "機能名称"

        Dim system2 As New DataGridViewCheckBoxColumn
        system2.HeaderText = "権限"
        SYSTEM_V.Columns.Add(system2)
        system2.Width = 40
        system2.Name = "権限"

        Dim system3 As New DataGridViewCheckBoxColumn
        system3.HeaderText = "アプリケーションID"
        SYSTEM_V.Columns.Add(system3)
        system3.Width = 40
        system3.Visible = False
        system3.Name = "アプリケーションID"

        '背景色を白に設定
        SYSTEM_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        SYSTEM_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Function STAFF_AUTHORITY_INSERT(ByRef GRID_V As System.Windows.Forms.DataGridView)
        Dim ret As Boolean
        Dim i As Integer
        Dim oStaffAuthority As New cStructureLib.sStaffAuthority

        For i = 0 To GRID_V.Rows.Count - 1
            If GRID_V("権限", i).Value = True Then
                oStaffAuthority.sStaffCode = S_STAFF_CODE_T.Text
                oStaffAuthority.sApplicationID = GRID_V("アプリケーションID", i).Value

                ret = oMstStaffDBIO.insertStaffAuthorityMst(oStaffAuthority, oTran)
            End If
        Next i
        oStaffAuthority = Nothing
        STAFF_AUTHORITY_INSERT = True
    End Function
    Private Function STAFF_AUTHORITY_INIT(ByVal GroupName As String, ByRef GRID_V As System.Windows.Forms.DataGridView)
        Dim ret As Boolean
        Dim i As Integer
        Dim oApplicationDBIO As New cMstApplicationDBIO(oConn, oCommand, oDataReader)
        Dim oApplication() As cStructureLib.sApplication


        ReDim oApplication(0)
        ret = oApplicationDBIO.getApplication(oApplication, Nothing, Nothing, GroupName, Nothing, oTran)

        For i = 0 To oApplication.Length - 1
            GRID_V.Rows.Add( _
                oApplication(i).sMenuName, _
                False, _
                oApplication(i).sApplicationID _
            )
        Next i

        oApplicationDBIO = Nothing
        oApplication = Nothing
        STAFF_AUTHORITY_INIT = True
    End Function
    Private Function STAFF_AUTHORITY_DISP(ByVal GroupName As String, ByRef GRID_V As System.Windows.Forms.DataGridView)
        Dim ret As Integer
        Dim i As Integer
        Dim oStaffAuthority() As cStructureLib.sStaffAuthority

        ReDim oStaffAuthority(0)

        For i = 0 To GRID_V.Rows.Count - 1
            ret = oMstStaffDBIO.getStaffAuthority(oStaffAuthority, S_STAFF_CODE, GRID_V("アプリケーションID", i).Value, oTran)
            If ret = 0 Then
                GRID_V("権限", i).Value = False
            Else
                GRID_V("権限", i).Value = True
            End If
        Next i

        oStaffAuthority = Nothing
        STAFF_AUTHORITY_DISP = True
    End Function
     Private Sub CLOSE_PROC()
        oConn = Nothing
        oMstStaffDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub

    'Private Sub SYAIN_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If MODE_L.Text = "新規" Then
    '        If SYAIN_CODE_T.Text <> Nothing Then
    '            S_STAFF_CODE_T.Text = oTool.JANCD("9901" & String.Format("{0:00000000}", CLng(SYAIN_CODE_T.Text)))
    '        End If
    '    End If
    'End Sub

    Private Sub ALL_CHECK_CONTROL(ByVal Action As Boolean, ByRef GRID_V As System.Windows.Forms.DataGridView)
        Dim i As Integer

        For i = 0 To GRID_V.Rows.Count - 1
            GRID_V("権限", i).Value = Action
        Next
    End Sub

    Private Sub SYSTEM_ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SYSTEM_ON_B.Click
        ALL_CHECK_CONTROL(True, SYSTEM_V)
    End Sub
    Private Sub SYSTEM_OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SYSTEM_OFF_B.Click
        ALL_CHECK_CONTROL(False, SYSTEM_V)
    End Sub

    Private Sub SALES_ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALES_ON_B.Click
        ALL_CHECK_CONTROL(True, SALES_V)
    End Sub

    Private Sub SALES_OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALES_OFF_B.Click
        ALL_CHECK_CONTROL(False, SALES_V)
    End Sub

    Private Sub MASTER_ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MASTER_ON_B.Click
        ALL_CHECK_CONTROL(True, MASTER_V)
    End Sub

    Private Sub MASTER_OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MASTER_OFF_B.Click
        ALL_CHECK_CONTROL(False, MASTER_V)
    End Sub

    Private Sub STOCK_ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_ON_B.Click
        ALL_CHECK_CONTROL(True, STOCK_V)
    End Sub

    Private Sub STOCK_OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_OFF_B.Click
        ALL_CHECK_CONTROL(False, STOCK_V)
    End Sub

    Private Sub NET_ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NET_ON_B.Click
        ALL_CHECK_CONTROL(True, NET_V)
    End Sub

    Private Sub NET_OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NET_OFF_B.Click
        ALL_CHECK_CONTROL(False, NET_V)
    End Sub

    Private Sub ROLE_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ROLE_NAME_C.SelectedIndexChanged
        If ROLE_NAME_C.SelectedIndex <> -1 Then
            ROLE_CODE_T.Text = oRole(ROLE_NAME_C.SelectedIndex).sRoleCode
        End If

    End Sub

    Private Sub PRINT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINT_B.Click
        Dim pStaffCard_form = New cReportsLib.fStaffCardReportPage(oConn, oCommand, oDataReader, oConf, S_STAFF_CODE, S_STAFF_NAME, S_ROLE_NAME, oTran)

        Me.Visible = False
        pStaffCard_form.ShowDialog()
        pStaffCard_form = Nothing
        Me.Visible = True

    End Sub

    Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        'スタッフマスタの削除
        ret = oMstStaffDBIO.deleteStaffMst(S_STAFF_CODE_T.Text, oTran)

        'スタッフ権限マスタの削除
        ret = oMstStaffDBIO.deleteStaffAuthorityMst(S_STAFF_CODE_T.Text, oTran)

        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                    "登録が完了しました。", _
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()

    End Sub

    Private Sub COMMIT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean
        Dim sPath As String
        Dim tPath As String

        If EDIT_MODE = True And S_STAFF_CODE_T.Text <> S_STAFF_CODE Then
            Message_form = New cMessageLib.fMessage(2, _
                                      "スタッフコードが変更されています。", _
                                      "スタッフカードの再発行が必要となります。", _
                                      "変更してよろしいですか？", _
                                      Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                Exit Sub      '登録処理の中止
            Else
                EDIT_MODE = False   '新規登録モードに変更
            End If
            Message_form = Nothing
        End If

        oStaff(0).sStaffCode = S_STAFF_CODE_T.Text
        oStaff(0).sStaffName = S_STAFF_NAME_T.Text

        oStaff(0).sRoleCode = CInt(ROLE_CODE_T.Text)
        If S_E_CLASS_R.Checked = True Then
            oStaff(0).sStaffClass = "E"
        End If
        If S_A_CLASS_R.Checked = True Then
            oStaff(0).sStaffClass = "A"
        End If
        If S_P_CLASS_R.Checked = True Then
            oStaff(0).sStaffClass = "P"
        End If
        If S_O_CLASS_R.Checked = True Then
            oStaff(0).sStaffClass = "O"
        End If
        oStaff(0).sRate = CSng(RATE_T.Text)

        oTran = Nothing
        oTran = oConn.BeginTransaction

        'スタッフマスタの登録
        If EDIT_MODE = False Then
            ret = oMstStaffDBIO.insertStaffMst(oStaff(0), oTran)
        Else
            ret = oMstStaffDBIO.updateStaffMst(oStaff(0), S_STAFF_CODE_T.Text, oTran)
        End If

        sPath = System.Windows.Forms.Application.StartupPath & "\Temp\" & S_STAFF_CODE_T.Text & ".jpg"
        tPath = System.Windows.Forms.Application.StartupPath & "\StaffPhoto\" & S_STAFF_CODE_T.Text & ".jpg"

        If System.IO.File.Exists(sPath) Then
            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)
            System.IO.File.Delete(sPath)
        End If

        'スタッフ権限マスタの削除
        ret = oMstStaffDBIO.deleteStaffAuthorityMst(S_STAFF_CODE_T.Text, oTran)

        '----------------------------
        ' スタッフ権限マスタの挿入
        '----------------------------
        '販売管理
        ret = STAFF_AUTHORITY_INSERT(SALES_V)
        'ネットショップ管理
        ret = STAFF_AUTHORITY_INSERT(NET_V)
        '在庫管理
        ret = STAFF_AUTHORITY_INSERT(STOCK_V)
        'マスタ管理
        ret = STAFF_AUTHORITY_INSERT(MASTER_V)
        'システム管理
        ret = STAFF_AUTHORITY_INSERT(SYSTEM_V)

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

    Private Sub PHOTO_UP_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PHOTO_UP_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = System.Windows.Forms.Application.StartupPath & "\Temp\" & S_STAFF_CODE_T.Text & ".jpg"

            'ファイルのコピー
            System.IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New System.IO.FileStream(tPath, System.IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            STAFF_PIC.Image = System.Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub

    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_C.SelectedIndexChanged

        oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_C.Text, Nothing, oTran)
        CHANNEL_CODE_T.Text = oChannel(0).sChannelCode

    End Sub

    Private Sub SYAIN_CODE_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SYAIN_CODE_T.KeyPress
        If e.KeyChar < "0"c OrElse "9"c < e.KeyChar Then
            '押されたキーが 0～9でない場合は、イベントをキャンセルする
            e.Handled = True
        End If
    End Sub

    Private Sub SYAIN_CODE_T_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SYAIN_CODE_T.TextChanged

        If IVENT_FLG = True And SYAIN_CODE_T.Text <> "" And CHANNEL_CODE_T.Text <> "" Then
            S_STAFF_CODE_T.Text = oTool.JANCD(String.Format("990{0:0}{1:00000000}", CInt(CHANNEL_CODE_T.Text), CLng(SYAIN_CODE_T.Text)))
        End If

    End Sub

    Private Sub CHANNEL_CODE_T_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_CODE_T.TextChanged
        If IVENT_FLG = True And SYAIN_CODE_T.Text <> "" And CHANNEL_CODE_T.Text <> "" Then
            S_STAFF_CODE_T.Text = oTool.JANCD(String.Format("990{0:0}{1:00000000}", CInt(CHANNEL_CODE_T.Text), CLng(SYAIN_CODE_T.Text)))
        End If

    End Sub
End Class
