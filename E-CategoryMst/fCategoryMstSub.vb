Public Class fCategoryMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oCategory1() As cStructureLib.sCategory1
    Private oCategory2() As cStructureLib.sCategory2
    Private oCategoryDBIO As cMstCategoryDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_CATEGORY1_ID As String
    Private S_CATEGORY2_ID As String

    Private STAFF_CODE As String

    Private EDIT_MODE As Integer    'カテゴリ１（新規） = 1   カテゴリ２（新規） = 2　　両方（更新） = 3

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyMode As Integer, _
            ByVal iKeyCategory1ID As String, _
            ByVal iKeyCategory2ID As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oConf = iConf

        oTran = iTran

        'モードセット
        EDIT_MODE = iKeyMode

        S_CATEGORY1_ID = iKeyCategory1ID
        S_CATEGORY2_ID = iKeyCategory2ID

        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oCategoryDBIO = New cMstCategoryDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oStaffDBIO.getStaff(oStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        CATEGORY1_ID_T.Text = S_CATEGORY1_ID
        CATEGORY2_ID_T.Text = S_CATEGORY2_ID

        oTool = New cTool

        IVENT_FLG = False

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = 3 Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "（更新）"

            'カテゴリ情報セット
            CATEGORY_DISP()

        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "（新規）"
        End If

        IVENT_FLG = True

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

        'グリッドのヘッダーを作成します。DataGridViewCheckBoxColumn
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "カテゴリ2ID"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 90
        column1.Name = "カテゴリ2ID"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "カテゴリ2名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 350
        column2.Name = "カテゴリ2名称"

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub CATEGORY_DISP()
 
        Select Case EDIT_MODE
            Case 1
            Case 2
            Case 3
                ReDim oCategory1(0)
                oCategoryDBIO.getCategory1(oCategory1, S_CATEGORY1_ID, Nothing, oTran)

                CATEGORY1_ID_T.Text = oCategory1(0).sCategory1ID
                CATEGORY1_NAME_T.Text = oCategory1(0).sCategory1Name

                ReDim oCategory2(0)
                oCategoryDBIO.getCategory2(oCategory2, S_CATEGORY1_ID, S_CATEGORY2_ID, Nothing, oTran)
                If oCategory2(0).sCategory2ID = "" Then
                    CATEGORY2_ID_T.Enabled = True
                    CATEGORY2_ID_T.ReadOnly = False
                    CATEGORY2_ID_T.BackColor = Color.LemonChiffon
                End If
                CATEGORY2_ID_T.Text = oCategory2(0).sCategory2ID
                If oCategory2(0).sCategory2ID = "" Then
                    CATEGORY2_NAME_T.Enabled = True
                    CATEGORY2_NAME_T.ReadOnly = False
                    CATEGORY2_NAME_T.BackColor = Color.LemonChiffon
                    EDIT_MODE = 4
                End If
                CATEGORY2_NAME_T.Text = oCategory2(0).sCategory2Name
        End Select

        CATEGORY_SUB_DISP()
    End Sub

    Private Sub CATEGORY_SUB_DISP()
        Dim pCategory2() As cStructureLib.sCategory2
        Dim RecordCount As Integer
        Dim i As Integer

        ReDim pCategory2(0)
        RecordCount = oCategoryDBIO.getCategory2(pCategory2, CATEGORY1_ID_T.Text, Nothing, Nothing, oTran)

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To pCategory2.Length - 2
            DATA_V.Rows.Add( _
                        pCategory2(i).sCategory2ID, _
                        pCategory2(i).sCategory2Name _
                )
        Next i

    End Sub
    Private Sub INIT_PROC()
 
        Select Case EDIT_MODE
            Case 1
                CATEGORY1_ID_T.Enabled = True
                CATEGORY1_ID_T.ReadOnly = False
                CATEGORY1_ID_T.BackColor = Color.LemonChiffon
                CATEGORY1_NAME_T.Enabled = True
                CATEGORY1_NAME_T.ReadOnly = False
                CATEGORY1_NAME_T.BackColor = Color.LemonChiffon
                CATEGORY2_ID_T.Enabled = True
                CATEGORY2_ID_T.ReadOnly = False
                CATEGORY2_ID_T.BackColor = Color.White
                CATEGORY2_NAME_T.Enabled = True
                CATEGORY2_NAME_T.ReadOnly = False
                CATEGORY2_NAME_T.BackColor = Color.White

                CATEGORY1_ID_T.Text = ""
                CATEGORY1_NAME_T.Text = ""
                CATEGORY2_ID_T.Text = ""
                CATEGORY2_NAME_T.Text = ""
                CATEGORY1_ID_T.Focus()

                MODE_L.BackColor = System.Drawing.Color.Red
                MODE_L.Text = "新規"
                 DELETE_B.Enabled = False
            Case 2
                CATEGORY1_ID_T.Enabled = False
                CATEGORY1_ID_T.ReadOnly = True
                CATEGORY1_ID_T.BackColor = Color.Gray
                CATEGORY1_NAME_T.Enabled = True
                CATEGORY1_NAME_T.ReadOnly = False
                CATEGORY1_NAME_T.BackColor = Color.LemonChiffon
                CATEGORY2_ID_T.Enabled = True
                CATEGORY2_ID_T.ReadOnly = False
                CATEGORY2_ID_T.BackColor = Color.LemonChiffon
                CATEGORY2_NAME_T.Enabled = True
                CATEGORY2_NAME_T.ReadOnly = False
                CATEGORY2_NAME_T.BackColor = Color.LemonChiffon

                CATEGORY2_ID_T.Text = ""
                CATEGORY2_NAME_T.Text = ""
                CATEGORY2_ID_T.Focus()

                MODE_L.BackColor = System.Drawing.Color.Red
                MODE_L.Text = "新規"
                DELETE_B.Enabled = False
            Case 3
                CATEGORY1_ID_T.Enabled = False
                CATEGORY1_ID_T.ReadOnly = True
                CATEGORY1_ID_T.BackColor = Color.Gray
                CATEGORY1_NAME_T.Enabled = True
                CATEGORY1_NAME_T.ReadOnly = False
                CATEGORY1_NAME_T.BackColor = Color.LemonChiffon
                CATEGORY2_ID_T.Enabled = False
                CATEGORY2_ID_T.ReadOnly = True
                CATEGORY2_ID_T.BackColor = Color.Gray
                CATEGORY2_NAME_T.Enabled = True
                CATEGORY2_NAME_T.ReadOnly = False
                CATEGORY2_NAME_T.BackColor = Color.LemonChiffon
                CATEGORY1_NAME_T.Focus()

                CATEGORY1_NAME_T.Focus()

                MODE_L.BackColor = System.Drawing.Color.Blue
                MODE_L.Text = "更新"
                DELETE_B.Enabled = True
            Case 4
                CATEGORY1_ID_T.Enabled = False
                CATEGORY1_ID_T.ReadOnly = True
                CATEGORY1_ID_T.BackColor = Color.Gray
                CATEGORY1_NAME_T.Enabled = True
                CATEGORY1_NAME_T.ReadOnly = False
                CATEGORY1_NAME_T.BackColor = Color.LemonChiffon
                CATEGORY2_ID_T.Enabled = True
                CATEGORY2_ID_T.ReadOnly = False
                CATEGORY2_ID_T.BackColor = Color.LemonChiffon
                CATEGORY2_NAME_T.Enabled = True
                CATEGORY2_NAME_T.ReadOnly = False
                CATEGORY2_NAME_T.BackColor = Color.LemonChiffon

                CATEGORY2_ID_T.Text = ""
                CATEGORY2_NAME_T.Text = ""
                CATEGORY2_ID_T.Focus()

                MODE_L.BackColor = System.Drawing.Color.Blue
                MODE_L.Text = "更新"
                DELETE_B.Enabled = True
        End Select

        CATEGORY_SUB_DISP()

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

    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If CATEGORY1_ID_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "カテゴリ１ＩＤが未入力です。", _
                                             "カテゴリ１ＩＤを入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CATEGORY1_ID_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If CATEGORY1_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "カテゴリ１名称が未入力です。", _
                                             "カテゴリ１名称を入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CATEGORY1_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If EDIT_MODE = 2 Or EDIT_MODE = 3 Then

            If CATEGORY2_ID_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２ＩＤが未入力です。", _
                                                 "カテゴリ２ＩＤを入力して下さい。", _
                                                 Nothing, Nothing)

                Message_form.ShowDialog()
                Application.DoEvents()
                Message_form = Nothing
                CATEGORY2_ID_T.Focus()
                INPUT_CHECK = False
                Exit Function
            End If
            If CATEGORY2_NAME_T.Text = "" Then
                Message_form = New cMessageLib.fMessage(1, "カテゴリ２名称が未入力です。", _
                                                 "カテゴリ２名称を入力して下さい。", _
                                                 Nothing, Nothing)

                Message_form.ShowDialog()
                Application.DoEvents()
                Message_form = Nothing
                CATEGORY2_NAME_T.Focus()
                INPUT_CHECK = False
                Exit Function
            End If

        End If

    End Function

    Private Sub DATA_SET()
        ReDim oCategory1(0)
        oCategory1(0).sCategory1ID = CATEGORY1_ID_T.Text
        oCategory1(0).sCategory1Name = CATEGORY1_NAME_T.Text

        ReDim oCategory2(0)
        oCategory2(0).sCategory1ID = CATEGORY1_ID_T.Text
        oCategory2(0).sCategory2ID = CATEGORY2_ID_T.Text
        oCategory2(0).sCategory2Name = CATEGORY2_NAME_T.Text
    End Sub

    Private Sub DATA_V_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        '選択行がタイトル行の場合はリターン
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        S_CATEGORY2_ID = DATA_V("カテゴリ2ID", SelRow).Value.ToString

        CATEGORY2_ID_T.Text = DATA_V("カテゴリ2ID", SelRow).Value.ToString
        CATEGORY2_NAME_T.Text = DATA_V("カテゴリ2名称", SelRow).Value.ToString

        EDIT_MODE = 3

        INIT_PROC()

    End Sub

    Private Sub NEW_B_Click(sender As Object, e As EventArgs) Handles NEW_B.Click
        S_CATEGORY2_ID = ""

        CATEGORY2_ID_T.Text = ""
        CATEGORY2_NAME_T.Text = ""

        EDIT_MODE = 2

        INIT_PROC()
    End Sub

    Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret1 As Boolean
        Dim ret2 As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        'カテゴリマスタの削除
        Select Case EDIT_MODE
            Case 1
            Case 2
            Case 3
                Message_form = New cMessageLib.fMessage(2, "親カテゴリ以下を全て削除しますか？", _
                    "「No」の場合は、サブカテゴリのみ削除されます。", _
                    "よろしいですか？", Nothing)
                Message_form.ShowDialog()
                Select Case Message_form.DialogResult
                    Case Windows.Forms.DialogResult.Yes
                        ret1 = oCategoryDBIO.deleteCategory1(CATEGORY1_ID_T.Text, oTran)
                        ret2 = oCategoryDBIO.deleteCategory2(CATEGORY1_ID_T.Text, Nothing, oTran)
                    Case Windows.Forms.DialogResult.No
                        ret1 = True
                        ret2 = oCategoryDBIO.deleteCategory2(CATEGORY1_ID_T.Text, CATEGORY2_ID_T.Text, oTran)
                    Case Windows.Forms.DialogResult.Cancel
                        Message_form = Nothing
                        Exit Sub
                End Select
                Message_form = Nothing
            Case 4
                ret1 = True
                ret2 = oCategoryDBIO.deleteCategory2(CATEGORY1_ID_T.Text, CATEGORY2_ID_T.Text, oTran)
        End Select

        If ret1 = True And ret2 = True Then
            oTran.Commit()

            Message_form = New cMessageLib.fMessage(1, Nothing, _
                "削除が完了しました。", _
                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()
        Else
            oTran.Rollback()
            Message_form = New cMessageLib.fMessage(1, "削除が失敗しました。", _
                        "システム管理者に連絡して下さい。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()

            Exit Sub
        End If

        CLOSE_PROC()

    End Sub
    Private Sub COMMIT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret1 As Boolean
        Dim ret2 As Boolean
        Dim msg As String

        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        msg = ""
        oTran = Nothing
        oTran = oConn.BeginTransaction

        DATA_SET()

        'カテゴリマスタマスタの登録
        Select Case EDIT_MODE
            Case 1
                ret1 = oCategoryDBIO.insertCategory1(oCategory1(0), oTran)
                If CATEGORY2_ID_T.Text <> "" Then
                    ret2 = oCategoryDBIO.insertCategory2(oCategory2(0), oTran)
                Else
                    ret2 = True
                End If
                msg = "登録"
            Case 2
                ret1 = True
                '           If CATEGORY2_ID_T.Text <> "" Then
                ret2 = oCategoryDBIO.insertCategory2(oCategory2(0), oTran)
                'End If
                msg = "登録"
            Case 3
                ret1 = oCategoryDBIO.updateCategory1(oCategory1(0), CATEGORY1_ID_T.Text, oTran)
                ret2 = oCategoryDBIO.updateCategory2(oCategory2(0), CATEGORY1_ID_T.Text, CATEGORY2_ID_T.Text, oTran)
                msg = "更新"
            Case 4
                ret1 = oCategoryDBIO.updateCategory1(oCategory1(0), CATEGORY1_ID_T.Text, oTran)
                If CATEGORY2_ID_T.Text <> "" Then
                    ret2 = oCategoryDBIO.insertCategory2(oCategory2(0), oTran)
                Else
                    ret2 = True
                End If
                msg = "更新"
        End Select
        If ret1 = True And ret2 = True Then
            oTran.Commit()

            Message_form = New cMessageLib.fMessage(1, Nothing, _
            msg & "が完了しました。", _
            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()
        Else
            oTran.Rollback()
            Message_form = New cMessageLib.fMessage(1, msg & "が失敗しました。", _
                        "システム管理者に連絡して下さい。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()

            Exit Sub
        End If

        If EDIT_MODE = 1 Or EDIT_MODE = 4 Then
            CLOSE_PROC()
        Else
            INIT_PROC()
        End If

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "処理が終了されます。", _
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

    Private Sub CLOSE_PROC()
        oConn = Nothing
        oCategoryDBIO = Nothing
        oStaffDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CATEGORY1_ID_T_Leave(sender As Object, e As EventArgs) Handles CATEGORY1_ID_T.Leave
        Dim RecordCount As Long
        Dim Message_form As cMessageLib.fMessage

        If CATEGORY1_ID_T.Text <> "" Then
            If EDIT_MODE < 3 Then
                RecordCount = oCategoryDBIO.getCategory1Count(CATEGORY1_ID_T.Text, Nothing, oTran)
                If RecordCount > 0 Then
                    Message_form = New cMessageLib.fMessage(1, "入力された「カテゴリ1ID」は", _
                                                                "既に登録済みです。", _
                                                                "別のIDを入力して下さい。", Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing
                    CATEGORY1_ID_T.Text = ""
                    CATEGORY1_ID_T.Focus()

                End If
            End If
        End If
    End Sub

    Private Sub CATEGORY2_ID_T_Leave(sender As Object, e As EventArgs) Handles CATEGORY2_ID_T.Leave
        Dim RecordCount As Long
        Dim Message_form As cMessageLib.fMessage

        If CATEGORY2_ID_T.Text <> "" Then
            If EDIT_MODE < 3 Then
                RecordCount = oCategoryDBIO.getCategory2Count(CATEGORY1_ID_T.Text, CATEGORY2_ID_T.Text, Nothing, oTran)
                If RecordCount > 0 Then
                    Message_form = New cMessageLib.fMessage(1, "入力された「カテゴリ2ID」は", _
                                                                "既に登録済みです。", _
                                                                "別のIDを入力して下さい。", Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing
                    CATEGORY2_ID_T.Text = ""
                    CATEGORY2_ID_T.Focus()

                End If
            End If
        End If
    End Sub
End Class
