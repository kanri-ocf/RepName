Public Class fDeliveryMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oMstDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private KEY_CODE As String
    Private STAFF_CODE As String
    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iKeyCode As String, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        '新規／更新のモード設定
        If iKeyCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        KEY_CODE = iKeyCode

        STAFF_CODE_T.Text = iStaffCode
        STAFF_NAME_T.Text = iStaffName
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

        '項目名称リストボックスセット
        ITEM_CLASS_SET()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "更新"
            DELETE_B.Enabled = True

            'マスタの読み込み
            ReDim oDeliveryClass(0)
            RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, KEY_CODE, Nothing, Nothing, Nothing, oTran)

            '情報セット
            DATA_DISP()
        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "新規"
            DELETE_B.Enabled = False

            'キーコード発番
            KEY_CODE = oMstDeliveryClassDBIO.getNewDeliveryClassCode(oTran)
            CODE_T.Text = KEY_CODE
        End If
    End Sub
    Private Sub ITEM_CLASS_SET()
        Dim i As Integer
        Dim pData() As String

        ReDim pData(0)
        oMstDeliveryClassDBIO.getItemName(pData, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To pData.Length - 1
            ITEM_NAME_L.Items.Add(pData(i))
        Next
    End Sub
    Private Sub DATA_DISP()

        CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        ITEM_NAME_L.Text = oDeliveryClass(0).sItemName
        NAME_T.Text = oDeliveryClass(0).sClassName
        CLASS_VALUE_T.Text = oDeliveryClass(0).sClassCode

    End Sub
    Private Sub INIT_PROC()
        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        CODE_T.Text = ""
        NAME_T.Text = ""
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

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
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

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCount As Long
        If ITEM_NAME_L.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing,
                        "項目種別が選択されていません。",
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If
        If NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing,
            "種別名称が記入されていません。",
            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If
        'If CLASS_VALUE_T.Text = "" Then
        '    Message_form = New cMessageLib.fMessage(1, Nothing,
        '    "種別値が記入されていません。",
        '    Nothing, Nothing)
        '    Message_form.ShowDialog()
        '    Message_form = Nothing
        '    Exit Sub
        'End If
        oTran = Nothing
        oTran = oConn.BeginTransaction

        'マスタの登録
        ReDim oDeliveryClass(0)
        oDeliveryClass(0).sDeliveryClassCode = CInt(CODE_T.Text)
        oDeliveryClass(0).sItemName = ITEM_NAME_L.Text
        oDeliveryClass(0).sClassName = NAME_T.Text
        oDeliveryClass(0).sClassCode = CLASS_VALUE_T.Text
        If EDIT_MODE = True Then
            RecordCount = oMstDeliveryClassDBIO.updateDeliveryClassMst(oDeliveryClass(0), KEY_CODE, oTran)
        Else
            RecordCount = oMstDeliveryClassDBIO.insertDeliveryClassMst(oDeliveryClass(0), oTran)
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
    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage

        'マスタの登録
        oMstDeliveryClassDBIO.deleteDeliveryClassMst(KEY_CODE, Nothing, oTran)

        Message_form = New cMessageLib.fMessage(1, Nothing,
                    "削除が完了しました。",
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()
    End Sub
    Private Sub CLOSE_PROC()
        oConn = Nothing
        oDeliveryClass = Nothing
        oMstDeliveryClassDBIO = Nothing
        oConf = Nothing
        oMstConfigDBIO = Nothing

        oTool = Nothing

        Me.Dispose()
        Me.Close()
    End Sub

    'Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
    '    Dim Message_form As cMessageLib.fMessage

    '    'oTran = Nothing
    '    'oTran = oConn.BeginTransaction


    '    'マスタの登録
    '    oMstDeliveryClassDBIO.deleteDeliveryClassMst(KEY_CODE, Nothing, oTran)

    '    oTran.Commit()

    '    Message_form = New cMessageLib.fMessage(1, Nothing,
    '                "削除が完了しました。",
    '                Nothing, Nothing)
    '    Message_form.ShowDialog()
    '    Message_form = Nothing

    '    Application.DoEvents()

    '    CLOSE_PROC()

    'End Sub

End Class
