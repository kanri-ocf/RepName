Public Class fShipmentSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oShipmentFull() As cStructureLib.sViewShipmentDataFull
    Private oDataShipmentDBIO As cDataShipmentDBIO
    Private oViewShipmentDataFullDBIO As cViewShipmentDataFullDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oShipmentStatus As cStructureLib.sShipStatus
    Private oDataShipmentStatusDBIO As cDataShipmentStatusDBIO

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oMstDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oTool As cTool

    Private CORP_CODE As Integer

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCorpCode As Integer, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        CORP_CODE = iCorpCode

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oDataShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oDataShipmentStatusDBIO = New cDataShipmentStatusDBIO(oConn, oCommand, oDataReader)
        oViewShipmentDataFullDBIO = New cViewShipmentDataFullDBIO(oConn, oCommand, oDataReader)
        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

    End Sub

    Private Sub fShipmentSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing

        'チャネルリストボックスセット
        CHANNEL_SET()

        '配送業者リストボックスセット
        DELIVERY_SET()

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '初期検索実行
        SEARCH_PROC()

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To Shipment_V.Rows.Count - 1
            Shipment_V.Rows.Clear()
        Next i

        CHANNEL_NAME_L.Text = ""
        CORP_NAME_C.Text = ""
        SEL_C.Checked = False
        SEL_COUNT_T.Text = 0
        COUNT_T.Text = 0

    End Sub

    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
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
    '     System.Windows.Forms.DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        SHIPMENT_V.RowHeadersVisible = False
        SHIPMENT_V.ColumnHeadersHeight = 30
        SHIPMENT_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column0 As New System.Windows.Forms.DataGridViewCheckBoxColumn
        column0.HeaderText = "選択"
        SHIPMENT_V.Columns.Add(column0)
        column0.Width = 40
        column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column0.Name = "選択"

        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "受注番号"
        SHIPMENT_V.Columns.Add(column1)
        column1.Width = 100
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column1.Name = "受注番号"

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "出荷日"
        SHIPMENT_V.Columns.Add(column2)
        column2.Width = 100
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column2.Name = "出荷日"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "チャネル名称"
        SHIPMENT_V.Columns.Add(column3)
        column3.Width = 150
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column3.Name = "チャネル名称"

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "出荷先名称"
        SHIPMENT_V.Columns.Add(column4)
        column4.Width = 250
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        column4.Name = "出荷先名称"

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "合計金額（税込）"
        SHIPMENT_V.Columns.Add(column5)
        column5.Width = 120
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column5.Name = "合計金額（税込）"

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "出荷コード"
        SHIPMENT_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        'column6.Visible = False
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column6.Name = "出荷コード"

        '背景色を白に設定
        Shipment_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        Shipment_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim cnt As Long
        Dim pPreNUmber As String

        For i = 0 To Shipment_V.Rows.Count
            Shipment_V.Rows.Clear()
        Next i

        '表示設定
        cnt = 0
        pPreNUmber = ""
        For i = 0 To oShipmentFull.Length - 1
            oChannelDBIO.getChannelMst(oChannel, oShipmentFull(i).sChannelCode, Nothing, Nothing, Nothing, oTran)
            If (pPreNUmber = "") Or (pPreNUmber <> oShipmentFull(i).sShipCode) Then
                SHIPMENT_V.Rows.Add(
                            oShipmentFull(i).sShipCheck,
                            oShipmentFull(i).sRequestCode,
                            oShipmentFull(i).sShipDate,
                            oChannel(0).sChannelName,
                            oShipmentFull(i).sFirstName & " " & oShipmentFull(i).sLastName,
                            oShipmentFull(i).sTotalPrice,
                            oShipmentFull(i).sShipCode
                    )
                cnt = cnt + 1
            End If
            pPreNUmber = oShipmentFull(i).sShipCode

        Next i
        COUNT_T.Text = cnt
        SEL_COUNT_T.Text = oDataShipmentStatusDBIO.ShipStatusCount(oTran)

    End Sub

    '***************************
    'チャネルリストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oChannel = Nothing
        RecordCnt = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
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
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CHANNEL_NAME_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing
    End Sub


    Private Sub CHANNEL_NAME_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANNEL_NAME_L.SelectedIndexChanged
        If CHANNEL_NAME_L.SelectedIndex <> -1 Then
            oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_L.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If
    End Sub


    Private Sub DELIVERY_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '配送業者コンボ内容設定
        ReDim oDeliveryClass(0)
        RecordCnt = oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, "配送業者", Nothing, Nothing, oTran)

        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタが登録されていません", _
                                                "配送種別マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "配送種別マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CORP_NAME_C.Items.Add(oDeliveryClass(i).sClassName)
            If oDeliveryClass(i).sDeliveryClassCode = CORP_CODE Then
                CORP_NAME_C.SelectedIndex = i
            End If
        Next
    End Sub

    Private Sub CORP_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CORP_NAME_C.SelectedIndexChanged
        If CORP_NAME_C.SelectedIndex <> -1 Then
            ReDim oDeliveryClass(0)
            oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, Nothing, Nothing, Nothing, CORP_NAME_C.Text, oTran)
            CORP_CODE_T.Text = oDeliveryClass(0).sDeliveryClassCode
        End If

    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        SEARCH_PROC()


    End Sub
    Private Sub SEARCH_PROC()
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Long
        Dim pRequestCode As String
        Dim pChannelCode As Integer
        Dim pProductCode As String
        Dim pProductName As String
        Dim pOptionName As String
        Dim pCorpCode As Integer
        Dim pFromRequestDate As String
        Dim pToRequestDate As String
        Dim pFromShipDate As String
        Dim pToShipDate As String
        Dim pPostCode As String
        Dim pAddr As String
        Dim pName As String
        Dim pCheck As Boolean

        SHIPMENT_V.SuspendLayout()

        '明細行クリア
        For i = 0 To SHIPMENT_V.Rows.Count - 1
            SHIPMENT_V.Rows.Clear()
        Next i

        'データ検索中メッセージ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        pRequestCode = ""
        pChannelCode = Nothing
        pProductCode = ""
        pProductName = ""
        pOptionName = ""
        pCorpCode = Nothing
        pFromRequestDate = ""
        pToRequestDate = ""
        pFromShipDate = ""
        pToShipDate = ""
        pPostCode = ""
        pAddr = ""
        pName = ""
        pCheck = Nothing

        '受注コード
        If REQUEST_CODE_T.Text = "" Then
            pRequestCode = Nothing
        Else
            pRequestCode = REQUEST_CODE_T.Text
        End If

        'チャネルコード
        If CHANNEL_CODE_T.Text = "" Then
            pChannelCode = Nothing
        Else
            pChannelCode = CInt(CHANNEL_CODE_T.Text)
        End If

        '商品コード
        If PRODUCT_CODE_T.Text = "" Then
            pProductCode = Nothing
        Else
            pProductCode = PRODUCT_CODE_T.Text
        End If

        '商品名称
        If PRODUCT_NAME_T.Text = "" Then
            pProductName = Nothing
        Else
            pProductName = PRODUCT_NAME_T.Text
        End If

        'オプション名称
        If OPTION_NAME_T.Text = "" Then
            pOptionName = Nothing
        Else
            pOptionName = OPTION_NAME_T.Text
        End If

        '配送業者
        If CORP_NAME_C.Text = "" Then
            pCorpCode = Nothing
        Else
            pCorpCode = CORP_CODE_T.Text
        End If

        '受注日(From)
        If oTool.MaskClear(FROM_REQUEST_DATE_T.Text) = "" Then
            pFromRequestDate = Nothing
        Else
            pFromRequestDate = oTool.MaskClear(FROM_REQUEST_DATE_T.Text)
        End If

        '受注日(To)
        If oTool.MaskClear(TO_REQUEST_DATE_T.Text) = "" Then
            pToRequestDate = Nothing
        Else
            pToRequestDate = oTool.MaskClear(TO_REQUEST_DATE_T.Text)
        End If

        '出荷日(From)
        If oTool.MaskClear(FROM_SHIP_DATE_T.Text) = "" Then
            pFromShipDate = Nothing
        Else
            pFromShipDate = oTool.MaskClear(FROM_SHIP_DATE_T.Text)
        End If

        '出荷日(To)
        If oTool.MaskClear(TO_SHIP_DATE_T.Text) = "" Then
            pToShipDate = Nothing
        Else
            pToShipDate = oTool.MaskClear(TO_SHIP_DATE_T.Text)
        End If

        '郵便番号
        If POST_CODE_T.Text = "" Then
            pPostCode = Nothing
        Else
            pPostCode = POST_CODE_T.Text
        End If

        '住所
        If ADDR_T.Text = "" Then
            pAddr = Nothing
        Else
            pAddr = ADDR_T.Text
        End If

        '名称
        If NAME_T.Text = "" Then
            pName = Nothing
        Else
            pName = NAME_T.Text
        End If

        '選択状況
        If SEL_C.Checked = False Then
            pCheck = Nothing
        Else
            pCheck = True
        End If

        '商品在庫データの読み込みバッファ初期化
        oShipmentFull = Nothing

        '商品在庫データの読み込み
        RecordCnt = oViewShipmentDataFullDBIO.getShipmentFull( _
                        oShipmentFull, _
                        pRequestCode, _
                        pChannelCode, _
                        pProductCode, _
                        pOptionName, _
                        pCorpCode, _
                        pFromRequestDate, _
                        pToRequestDate, _
                        pFromShipDate, _
                        pToShipDate, _
                        pPostCode, _
                        pAddr, _
                        pName, _
                        pCheck, _
                        oTran _
        )

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        '検索結果の画面セット
        If RecordCnt > 0 Then
            SEARCH_RESULT_SET()
        Else

            Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。", _
                                                  "条件を変更後再度検索して下さい。", _
                                                  Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()

            'メッセージウィンドウのクリア
            Message_form.Dispose()
            Message_form = Nothing
        End If

        SHIPMENT_V.ResumeLayout()

    End Sub

    Private Sub SHIPMENT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SHIPMENT_V.CellClick

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'チェックボックスの列かどうか調べる
        If e.ColumnIndex = 0 Then
            If SHIPMENT_V("選択", e.RowIndex).Value = False Then
                SHIPMENT_V("選択", e.RowIndex).Value = True
            Else
                SHIPMENT_V("選択", e.RowIndex).Value = False
            End If
        End If
    End Sub

    '***********************************************
    'チェックボックスがチェックされた直後に
    'CellValueChangedイベントが発生するようにする
    'CurrentCellDirtyStateChangedイベントハンドラ
    '***********************************************
    Private Sub SHIPMENT_V_CurrentCellDirtyStateChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles SHIPMENT_V.CurrentCellDirtyStateChanged

        If SHIPMENT_V.CurrentCellAddress.X = 0 AndAlso _
            SHIPMENT_V.IsCurrentCellDirty Then
            'コミットする
            SHIPMENT_V.CommitEdit(System.Windows.Forms.DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


    '***********************************************
    '注文のチェックボックスの状態が変更した際の処理
    'チェックボックスのカラムは０に固定
    '***********************************************
    Private Sub SHIPMENT_V_CellValueChanged(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles SHIPMENT_V.CellValueChanged

        '処理内容
        SEL_COUNT_T.Text = SHIPMENT_STATUS_UPDATE(e.RowIndex, SHIPMENT_V("出荷コード", e.RowIndex).Value, SHIPMENT_V(e.ColumnIndex, e.RowIndex).Value)
    End Sub
    '*****************************************************
    'チェックボックスのチェックが変更された場合の処理
    '注文状態データの更新
    '*****************************************************
    Private Function SHIPMENT_STATUS_UPDATE(ByVal Index As Integer, ByVal ShipCode As String, ByVal CheckStatus As Boolean) As Long

        Dim RecordCnt As Integer

        '挿入 Or 更新データのセット
        oShipmentStatus.sShipCode = ShipCode
        oShipmentStatus.sShipCheck = CheckStatus

        If CheckStatus = True Then  'チェック済みの場合
            If oDataShipmentStatusDBIO.ShipStatusExist(oShipmentStatus.sShipCode, oTran) Then
                ''すでに注文状態レコードが存在した場合（通常はありえない）
                'RecordCnt = oDatashipmentStatusDBIO.updateshipmentStatus(oshipmentStatus, oTran)
            Else
                '発注状態レコードの作成
                RecordCnt = oDataShipmentStatusDBIO.insertShipStatus(oShipmentStatus, oTran)
            End If
        Else                        'チェック解除の場合
            '注文状態レコードの削除
            RecordCnt = oDataShipmentStatusDBIO.deleteShipStatus(ShipCode, oTran)
        End If

        SHIPMENT_STATUS_UPDATE = oDataShipmentStatusDBIO.ShipStatusCount(oTran)
    End Function

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        If SEL_COUNT_T.Text = 0 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "選択されていません",
                                            "出荷する注文を選択して下さい。",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()

            Exit Sub
        End If

        oShipmentFull = Nothing
        oDataShipmentDBIO = Nothing
        oChannel = Nothing
        oChannelDBIO = Nothing
        oConf = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.OK
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub

End Class
