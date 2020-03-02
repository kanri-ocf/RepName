Public Class fPaymentMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oChannelPaymentFull() As cStructureLib.sViewChannelPaymentFull
    Private oMstChannelPaymentDBIO As cMstChannelPaymentDBIO

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oPayment() As cStructureLib.sPayment
    Private oPaymentDBIO As cMstPaymentDBIO

    Private oTool As cTool

    Private S_PAYMENT_CODE As String
    Private S_CHANNELPAYMENT_NAME As String

    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '新規 = False   更新 = True

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iKeyPaymentCode As Integer, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTran = iTran

        oMstChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)
        oDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)

        '新規／更新のモード設定
        If iKeyPaymentCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_PAYMENT_CODE = iKeyPaymentCode
        STAFF_CODE_T.Text = iStaffCode
        STAFF_NAME_T.Text = iStaffName
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oTool = New cTool

        'アクセス権限表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '更新処理の場合、編集データの読込み処理
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "更新"
            DELETE_B.Enabled = True

            SEARCH_PROC()
        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "新規"
            DELETE_B.Enabled = False

            S_PAYMENT_CODE = oPaymentDBIO.getNewPaymentCode(oTran)
            PAYMENT_CODE_T.Text = S_PAYMENT_CODE
        End If
    End Sub
    Private Sub SEARCH_PROC()
        ReDim oChannelPaymentFull(0)
        oMstChannelPaymentDBIO.getChannelPaymentFull(oChannelPaymentFull, Nothing, Nothing, S_PAYMENT_CODE, Nothing, Nothing, oTran)

        '支払方法情報セット
        PAYMENY_DISP()

        'チャネル別支払方法情報セット
        CHANNEL_PAYMENT_DISP()

    End Sub
    Private Sub PAYMENY_DISP()

        PAYMENT_CODE_T.Text = oChannelPaymentFull(0).sPaymentCode
        PAYMENT_NAME_T.Text = oChannelPaymentFull(0).sPaymentName

        CREDIT_C.Checked = oChannelPaymentFull(0).sCreditFlg

        REQUEST_C.Checked = oChannelPaymentFull(0).sRequestFlg
        SHIPMENT_C.Checked = oChannelPaymentFull(0).sShipmentFlg
        ORDER_C.Checked = oChannelPaymentFull(0).sOrderFlg
        ARRIVE_C.Checked = oChannelPaymentFull(0).sArrivalFlg
        RETURN_C.Checked = oChannelPaymentFull(0).sReturnFlg

    End Sub
    Private Sub CHANNEL_PAYMENT_DISP()
        Dim i As Integer
        Dim PreChannelPaymentCode As Integer

        For i = 0 To CHANNEL_PAYMENT_V.Rows.Count
            CHANNEL_PAYMENT_V.Rows.Clear()
        Next i

        PreChannelPaymentCode = 0
        For i = 0 To oChannelPaymentFull.Length - 1
            If PreChannelPaymentCode <> oChannelPaymentFull(i).sChannelPaymentCode Then
                CHANNEL_PAYMENT_V.Rows.Add( _
                    oChannelPaymentFull(i).sChannelPaymentCode, _
                    oChannelPaymentFull(i).sChannelCode, _
                    oChannelPaymentFull(i).sChannelName, _
                    oChannelPaymentFull(i).sChannelPaymentName, _
                    oChannelPaymentFull(i).sPaymentCode _
                )
            End If
            PreChannelPaymentCode = oChannelPaymentFull(i).sChannelPaymentCode
        Next i

    End Sub
    Private Sub INIT_PROC()
        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "新規"
        DELETE_B.Enabled = False

        PAYMENT_CODE_T.Text = ""
        PAYMENT_NAME_T.Text = ""
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
        Dim RecordCount As Integer

        '-------------- SALES_V (販売管理）----------------------
        'レコードセレクタを非表示に設定
        CHANNEL_PAYMENT_V.RowHeadersVisible = False
        CHANNEL_PAYMENT_V.ColumnHeadersHeight = 20
        CHANNEL_PAYMENT_V.RowTemplate.Height = 20

        'グリッドのヘッダーを作成します。
        Dim ChannelPaymentCode As New System.Windows.Forms.DataGridViewComboBoxColumn()
        ChannelPaymentCode.HeaderText = "チャネル別支払コード"
        CHANNEL_PAYMENT_V.Columns.Add(ChannelPaymentCode)
        ChannelPaymentCode.Width = 200
        ChannelPaymentCode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ChannelPaymentCode.Visible = False
        ChannelPaymentCode.Name = "チャネル別支払コード"

        Dim ChannelCode As New System.Windows.Forms.DataGridViewComboBoxColumn()
        ChannelCode.HeaderText = "チャネルコード"
        CHANNEL_PAYMENT_V.Columns.Add(ChannelCode)
        ChannelCode.Width = 200
        ChannelCode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ChannelCode.Visible = False
        ChannelCode.Name = "チャネルコード"

        Dim ChannelName As New System.Windows.Forms.DataGridViewComboBoxColumn()
        ChannelName.HeaderText = "チャネル名称"
        CHANNEL_PAYMENT_V.Columns.Add(ChannelName)
        ChannelName.Width = 200
        ChannelName.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ChannelName.Name = "チャネル名称"

        'ComboBoxのリストに表示する項目を指定する
        ReDim oChannel(0)
        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
        ChannelName.Items.Add("")
        For i = 0 To oChannel.Length - 1
            ChannelName.Items.Add(oChannel(i).sChannelName)
        Next i

        Dim ChannelPaymentName As New System.Windows.Forms.DataGridViewTextBoxColumn
        ChannelPaymentName.HeaderText = "チャネル別支払方法名称"
        CHANNEL_PAYMENT_V.Columns.Add(ChannelPaymentName)
        ChannelPaymentName.Width = 250
        ChannelPaymentName.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        ChannelPaymentName.Name = "チャネル別支払方法名称"

        Dim PaymentCode As New System.Windows.Forms.DataGridViewTextBoxColumn
        PaymentCode.HeaderText = "支払方法コード"
        CHANNEL_PAYMENT_V.Columns.Add(PaymentCode)
        PaymentCode.Width = 250
        PaymentCode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        PaymentCode.Visible = False
        PaymentCode.Name = "支払方法コード"

        '背景色を白に設定
        CHANNEL_PAYMENT_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        CHANNEL_PAYMENT_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

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
        Dim ret As Boolean
        Dim oChannelPayment() As cStructureLib.sChannelPayment
        Dim i As Integer

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '支払方法マスタの登録
        ReDim oPayment(0)
        If PAYMENT_CODE_T.Text <> "" Then
            oPayment(0).sPaymentCode = CInt(PAYMENT_CODE_T.Text)
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing,
                        "支払い方法コードが空欄です。",
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If
        If PAYMENT_NAME_T.Text <> "" Then
            oPayment(0).sPaymentName = PAYMENT_NAME_T.Text
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing,
                        "支払い方法名称が空欄です。",
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If

        oPayment(0).sCreditFlg = CREDIT_C.Checked
        oPayment(0).sRequestFlg = REQUEST_C.Checked
        oPayment(0).sShipmentFlg = SHIPMENT_C.Checked
        oPayment(0).sOrderFlg = ORDER_C.Checked
        oPayment(0).sArriveFlg = ARRIVE_C.Checked
        oPayment(0).sReturnFlg = RETURN_C.Checked


        If MODE_L.Text = "新規" Then
            ret = oPaymentDBIO.insertPaymentMst(oPayment(0), oTran)
        Else
            ret = oPaymentDBIO.updatePaymentMst(oPayment(0), oPayment(0).sPaymentCode, oTran)
        End If

        'チャネル別支払方法マスタの削除
        ret = oMstChannelPaymentDBIO.deleteChannelPaymentMst(Nothing, Nothing, CInt(PAYMENT_CODE_T.Text), oTran)

        'チャネル別支払方法マスタの登録
        ReDim oChannelPayment(0)
        For i = 0 To CHANNEL_PAYMENT_V.Rows.Count - 2
            If CHANNEL_PAYMENT_V("チャネル別支払方法名称", i).Value <> "" Then


                If CHANNEL_PAYMENT_V("チャネル別支払コード", i).Value = 0 Then
                    oChannelPayment(0).sChannelPaymentCode = oMstChannelPaymentDBIO.getNewChannelPaymentCode(oTran)
                Else
                    oChannelPayment(0).sChannelPaymentCode = CInt(CHANNEL_PAYMENT_V("チャネル別支払コード", i).Value)
                End If
                oChannelPayment(0).sChannelCode = CInt(CHANNEL_PAYMENT_V("チャネルコード", i).Value)
                oChannelPayment(0).sPaymentCode = CInt(CHANNEL_PAYMENT_V("支払方法コード", i).Value)
                oChannelPayment(0).sChannelPaymentName = CHANNEL_PAYMENT_V("チャネル別支払方法名称", i).Value

                ret = oMstChannelPaymentDBIO.insertChannelPaymentMst(oChannelPayment(0), oTran)
            Else
                Message_form = New cMessageLib.fMessage(1, Nothing,
                        "チャネル別支払方法名称が空欄です。",
                        Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            End If

        Next

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
        Dim ret As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '支払方法マスタの削除
        ret = oPaymentDBIO.deletePaymentMst(CInt(PAYMENT_CODE_T.Text), oTran)

        'チャネル別支払方法マスタの削除
        ret = oMstChannelPaymentDBIO.deleteChannelPaymentMst(Nothing, Nothing, CInt(PAYMENT_CODE_T.Text), oTran)

        If ret = True Then
            oTran.Commit()
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                        "削除が完了しました。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()

            CLOSE_PROC()
        Else
            oTran.Rollback()
            Message_form = New cMessageLib.fMessage(1, "支払方法マスタの削除に失敗しました。", _
                        "システム管理者に連絡して下さい。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()
        End If

    End Sub
    Private Sub CLOSE_PROC()
        oConn = Nothing
        oChannelPaymentFull = Nothing
        oMstChannelPaymentDBIO = Nothing
        oDeliveryClass = Nothing
        oDeliveryClassDBIO = Nothing
        oChannel = Nothing
        oChannelDBIO = Nothing
        oPayment = Nothing
        oPaymentDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CHANNEL_PAYMENT_V_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CHANNEL_PAYMENT_V.CellValueChanged
        If e.ColumnIndex = 2 Then
            oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_PAYMENT_V("チャネル名称", e.RowIndex).Value, Nothing, oTran)
            CHANNEL_PAYMENT_V("チャネルコード", e.RowIndex).Value = oChannel(0).sChannelCode
        End If
        CHANNEL_PAYMENT_V("支払方法コード", e.RowIndex).Value = CInt(PAYMENT_CODE_T.Text)
    End Sub

    Private Sub CHANNEL_PAYMENT_V_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_PAYMENT_V.DoubleClick
        Dim RowNo As Integer

        RowNo = CHANNEL_PAYMENT_V.CurrentRow.Index
        If RowNo <CHANNEL_PAYMENT_V.Rows.Count - 1 Then
            Dim message_form As New cMessageLib.fMessage(2, _
                                          "チャネル別支払名称を削除します", _
                                          "よろしいですか？", _
                                          Nothing, Nothing)
            message_form.ShowDialog()
            If message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                '取引明細データ削除
                RowNo = CHANNEL_PAYMENT_V.CurrentRow.Index
                CHANNEL_PAYMENT_V.Rows.RemoveAt(RowNo)
            End If
            message_form = Nothing
        End If
    End Sub

    Private Sub SUB_DELETE_B_Click(sender As Object, e As EventArgs) Handles SUB_DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean
        Dim SelRow As Integer
        Dim i As Integer

        '選択行がタイトル行の場合はリターン
        i = 0
        For Each r As DataGridViewRow In CHANNEL_PAYMENT_V.SelectedRows
            SelRow = r.Index
        Next r

        If SelRow = -1 Then
            Exit Sub
        End If

        oTran = Nothing
        oTran = oConn.BeginTransaction

        'チャネル別支払方法マスタの削除
        ret = oMstChannelPaymentDBIO.deleteChannelPaymentMst(CHANNEL_PAYMENT_V("チャネル別支払コード", Selrow).value, Nothing, Nothing, oTran)

        If ret = True Then
            oTran.Commit()
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                        "削除が完了しました。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()

            SEARCH_PROC()
        Else
            oTran.Rollback()
            Message_form = New cMessageLib.fMessage(1, "チャネル別支払方法マスタの削除に失敗しました。", _
                        "システム管理者に連絡して下さい。", _
                        Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing

            Application.DoEvents()
        End If

    End Sub
End Class
