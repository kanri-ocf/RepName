Public Class fAccountMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oAccount() As cStructureLib.sAccount
    Private oSubAccount() As cStructureLib.sSubAccount
    Private oAccountDBIO As cMstAccountDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffDBIO As cMstStaffDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oTaxClass() As cStructureLib.sTaxClass
    Private oTaxClassDBIO As cMstTaxClassDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_ACCOUNT_CODE As Integer
    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oMaster() As String = {"仕入先マスタ", "チャネルマスタ"}

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyAccountCode As String, _
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
        If iKeyAccountCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_ACCOUNT_CODE = iKeyAccountCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oAccountDBIO = New cMstAccountDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oTaxClassDBIO = New cMstTaxClassDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oStaffDBIO.getStaff(oStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        oTool = New cTool

        IVENT_FLG = False

        '連携マスタセット
        MASTER_SET()

        'グリッド生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "（更新）"
            DELETE_B.Enabled = True
            ACCOUNT_CODE_T.ReadOnly = True
            ACCOUNT_CODE_T.BackColor = Color.White

            '勘定科目情報セット
            ACCOUNT_DISP()

        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "（新規）"
        End If

        IVENT_FLG = True

    End Sub

    Private Sub MASTER_SET()
        Dim i As Long

        '連携マスタコンボ内容設定
        LINK_MASTER_L.Items.Add("")
        For i = 0 To oMaster.Length - 1
            LINK_MASTER_L.Items.Add(oMaster(i))
        Next

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
        Column0.HeaderText = "補助勘定科目コード"
        DATA_V.Columns.Add(Column0)
        Column0.ReadOnly = True
        Column0.Width = 130
        Column0.Name = "補助勘定科目コード"
        Column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "補助勘定科目名称"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 430
        column1.Name = "補助勘定科目名称"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub ACCOUNT_DISP()
        ReDim oAccount(0)
        oAccountDBIO.getAccount(oAccount, S_ACCOUNT_CODE, Nothing, Nothing, Nothing, Nothing, oTran)

        ACCOUNT_CODE_T.Text = oAccount(0).sAccountCode
        ACCOUNT_CODE_T.ReadOnly = True

        ACCOUNT_CODE_T.Text = oAccount(0).sAccountCode
        ACCOUNT_NAME_T.Text = oAccount(0).sAccountName
        LINK_MASTER_L.Text = oAccount(0).sLinkMasterName

        TAX_CLASS_CODE_T.Text = oAccount(0).sTaxClassCode
        oTaxClassDBIO.getTaxClass(oTaxClass, oAccount(0).sTaxClassCode, Nothing, oTran)
        TAX_CLASS_NAME_T.Text = oTaxClass(0).sTaxClassName

        SUB_ACCOUNT_DISP()
    End Sub

    Private Sub SUB_ACCOUNT_DISP()
        Dim RecordCnt As Integer
        Dim i As Integer

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i
        SUB_ACCOUNT_CODE_T.Text = ""
        SUB_ACCOUNT_NAME_T.Text = ""

        Select Case LINK_MASTER_L.Text
            Case "仕入先マスタ"
                ReDim oSupplier(0)
                RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)

                For i = 0 To RecordCnt - 1
                    DATA_V.Rows.Add( _
                        oSupplier(i).sSupplierCode, _
                        oSupplier(i).sSupplierName _
                    )
                Next i
                DATA_V.ReadOnly = True
                SUB_ACCOUNT_ADD_B.Enabled = False
                SUB_ACCOUNT_DEL_B.Enabled = False
            Case "チャネルマスタ"
                ReDim oChannel(0)
                RecordCnt = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)

                For i = 0 To RecordCnt - 1
                    DATA_V.Rows.Add( _
                        oChannel(i).sChannelCode, _
                        oChannel(i).sChannelName _
                    )
                Next i
                DATA_V.ReadOnly = True
                SUB_ACCOUNT_ADD_B.Enabled = False
                SUB_ACCOUNT_DEL_B.Enabled = False
            Case Else
                ReDim oSubAccount(0)
                RecordCnt = oAccountDBIO.getSubAccount(oSubAccount, CInt(ACCOUNT_CODE_T.Text), Nothing, Nothing, oTran)

                For i = 0 To RecordCnt - 1
                    DATA_V.Rows.Add( _
                        oSubAccount(i).sSubAccountCode, _
                        oSubAccount(i).sSubAccountName _
                    )
                Next i
                DATA_V.ReadOnly = False
                SUB_ACCOUNT_ADD_B.Enabled = True
                SUB_ACCOUNT_DEL_B.Enabled = True
        End Select
    End Sub

    Private Sub INIT_PROC()

        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        ACCOUNT_CODE_T.Text = oAccountDBIO.getNewAccountCode(oTran)
        ACCOUNT_CODE_T.ReadOnly = False
        ACCOUNT_CODE_T.BackColor = Color.LightGreen
        DELETE_B.Enabled = False

        SUB_ACCOUNT_ADD_B.Enabled = True
        SUB_ACCOUNT_DEL_B.Enabled = False
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
        oAccountDBIO = Nothing
        oSupplierDBIO = Nothing
        oTaxClassDBIO = Nothing
        oChannelDBIO = Nothing
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
        ret = oAccountDBIO.deleteAccount(ACCOUNT_CODE_T.Text, oTran)


        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                    "削除が完了しました。", _
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If ACCOUNT_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "勘定科目コードが未入力です。", _
                                             "勘定科目コードを入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            ACCOUNT_CODE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If ACCOUNT_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "勘定科目名称が未入力です。", _
                                             "勘定科目名称を入力して下さい。", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            ACCOUNT_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function
    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '必須入力確認
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '勘定科目マスタの登録
        ReDim oAccount(0)
        oAccount(0).sAccountCode = CInt(ACCOUNT_CODE_T.Text)
        oAccount(0).sAccountName = ACCOUNT_NAME_T.Text
        oAccount(0).sLinkMasterName = LINK_MASTER_L.Text
        If TAX_CLASS_CODE_T.Text = "" Then
            oAccount(0).sTaxClassCode = 0
        Else
            oAccount(0).sTaxClassCode = CInt(TAX_CLASS_CODE_T.Text)
        End If

        If EDIT_MODE = False Then
            ret = oAccountDBIO.insertAccount(oAccount(0), oTran)
        Else
            ret = oAccountDBIO.updateAccount(oAccount(0), oTran)
        End If

        If LINK_MASTER_L.Text = "" Then
            '補助勘定科目マスタの登録

            oAccountDBIO.deleteSubAccount(CInt(ACCOUNT_CODE_T.Text), Nothing, oTran)

            For i = 0 To DATA_V.Rows.Count - 1
                ReDim oSubAccount(0)
                oSubAccount(0).sAccountCode = CInt(ACCOUNT_CODE_T.Text)
                oSubAccount(0).sSubAccountCode = CInt(DATA_V("補助勘定科目コード", i).Value)
                oSubAccount(0).sSubAccountName = DATA_V("補助勘定科目名称", i).Value

                oAccountDBIO.insertSubAccount(oSubAccount(0), oTran)

            Next i
        End If

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

    Private Sub SUB_ACCOUNT_ADD_B_Click(sender As Object, e As EventArgs) Handles SUB_ACCOUNT_ADD_B.Click
        Dim NewSubAccountCode As Integer
        Dim Message_form As cMessageLib.fMessage

        If SUB_ACCOUNT_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                            "補助勘定科目を入力して下さい。", _
                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            SUB_ACCOUNT_NAME_T.Focus()
            Exit Sub
        End If
        If SUB_ACCOUNT_CODE_T.Text = "" Then
            NewSubAccountCode = oTool.LookUpNewNo(DATA_V, 0)
            SUB_ACCOUNT_CODE_T.Text = NewSubAccountCode
        End If

        DATA_V.Rows.Add( _
            SUB_ACCOUNT_CODE_T.Text, _
            SUB_ACCOUNT_NAME_T.Text _
        )

        SUB_ACCOUNT_CODE_T.Text = ""
        SUB_ACCOUNT_NAME_T.Text = ""

        SUB_ACCOUNT_NAME_T.Focus()
    End Sub

    Private Sub DATA_V_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If

        SUB_ACCOUNT_CODE_T.Text = DATA_V("補助勘定科目コード", SelRow).Value
        SUB_ACCOUNT_NAME_T.Text = DATA_V("補助勘定科目名称", SelRow).Value

        SUB_ACCOUNT_DEL_B.Enabled = True

    End Sub

    Private Sub SUB_ACCOUNT_DEL_B_Click(sender As Object, e As EventArgs) Handles SUB_ACCOUNT_DEL_B.Click
        Dim r As DataGridViewRow
        For Each r In DATA_V.SelectedRows
            If Not r.IsNewRow Then
                DATA_V.Rows.Remove(r)
            End If
        Next r

        SUB_ACCOUNT_CODE_T.Text = ""
        SUB_ACCOUNT_NAME_T.Text = ""

    End Sub

    Private Sub LINK_MASTER_L_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LINK_MASTER_L.SelectedIndexChanged
        SUB_ACCOUNT_DISP()
    End Sub

    Private Sub TAX_CLASS_B_Click(sender As Object, e As EventArgs) Handles TAX_CLASS_B.Click
        Dim fTaxClassSearch_form As cSelectLib.fTaxClassSearch

        fTaxClassSearch_form = New cSelectLib.fTaxClassSearch(oConn, oCommand, oDataReader, TAX_CLASS_NAME_T, 1, oTran)
        fTaxClassSearch_form.ShowDialog()
        TAX_CLASS_CODE_T.Text = fTaxClassSearch_form.S_TaxClassCode
        TAX_CLASS_NAME_T.Text = fTaxClassSearch_form.S_TaxClassName

        fTaxClassSearch_form = Nothing

    End Sub

    Private Sub SUB_ACCOUNT_NAME_T_Leave(sender As Object, e As EventArgs) Handles SUB_ACCOUNT_NAME_T.Leave
        If SUB_ACCOUNT_NAME_T.Text <> "" Then
            SUB_ACCOUNT_ADD_B.Enabled = True
        Else
            SUB_ACCOUNT_ADD_B.Enabled = False
        End If
    End Sub
End Class
