Public Class fRequestSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oRequest() As cStructureLib.sRequestData
    Private oRequestData() As cStructureLib.sRequestData
    Private oRequestDataDBIO As cDataRequestDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oShipment() As cStructureLib.sShipmentData
    Private oShipmentDBIO As cDataShipmentDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Public S_REQUESTNUMBER As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iRequest_Code As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oRequestDataDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        REQUEST_CODE_T.Text = iRequest_Code

        '2020,4,20 A.Komita 検索実行時に結果が表示される量の件数でも件数オーバーになるのを防ぐ為初期化処理を追加 From
        '表示初期化処理
        INIT_PROC()
        '2020,4,20 A.Komita 追加 To

    End Sub

    Private Sub fRequestSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        'For i = 0 To Request_V.Rows.Count - 1
        '    Request_V.Rows.Clear()
        'Next i

        For i = 0 To REQUEST_V.Rows.Count
            REQUEST_V.Rows.Clear()
        Next i

        CHANNEL_L.Text = ""
    End Sub

    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_CLOSE As Integer = &HF060
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
            Return  ' Windows標準の処理は行わない
        End If
        MyBase.WndProc(m)
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
    '     System.Windows.Forms.DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        REQUEST_V.RowHeadersVisible = False
        REQUEST_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        REQUEST_V.ColumnHeadersHeight = 25
        REQUEST_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "受注伝票番号"
        REQUEST_V.Columns.Add(column1)
        column1.Width = 120
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column1.Name = "受注伝票番号"

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "受注日"
        REQUEST_V.Columns.Add(column2)
        column2.Width = 150
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column2.Name = "受注日"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "チャネル名称"
        REQUEST_V.Columns.Add(column3)
        column3.Width = 200
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column3.Name = "チャネル名称"


        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "受注金額（税込）"
        REQUEST_V.Columns.Add(column4)
        column4.Width = 150
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column4.Name = "受注金額"

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "希望納品日"
        REQUEST_V.Columns.Add(column5)
        column5.Width = 150
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column5.Name = "希望納品日"

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "状態"
        REQUEST_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column6.Name = "状態"

        '背景色を白に設定
        Request_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        Request_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim RecordCnt As Long
        Dim cnt As Long
        Dim str As String

        For i = 0 To Request_V.Rows.Count
            Request_V.Rows.Clear()
        Next i

        '表示設定
        cnt = 0
        For i = 0 To oRequestData.Length - 1
            ReDim oChannel(0)
            oChannelDBIO.getChannelMst(oChannel, oRequestData(i).sChannelCode, Nothing, Nothing, Nothing, oTran)

            '状態判定
            ReDim oShipment(0)
            RecordCnt = oShipmentDBIO.getShipment(oShipment, oRequestData(i).sRequestCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

            '状態判定
            str = ""
            If RecordCnt = 0 Then
                str = "未納"
            Else
                Select Case oShipment(0).sFinishFlg
                    Case 0
                        str = "部分出荷"
                    Case 1
                        str = "完納"
                    Case 2
                        str = "再出荷"
                End Select
            End If
            REQUEST_V.Rows.Add(
             oRequestData(i).sRequestCode, _ '受注コード
             oRequestData(i).sRequestDate, _ '
             oChannel(0).sChannelName, _ 'チャネル名称
             oRequestData(i).sTotalPrice, _ '受注税込金額
             oRequestData(i).sShipRequestDate, _ '配達希望日
             str
        )
            cnt = cnt + 1
        Next i
        COUNT_L.Text = cnt
    End Sub

    '***************************
    'チャネルリストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
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
            CHANNEL_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing
    End Sub


    Private Sub CHANNEL_L_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANNEL_L.SelectedIndexChanged
        If CHANNEL_L.SelectedIndex <> -1 Then
            ReDim oChannel(0)
            oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_L.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If
    End Sub

    '************************
    '検索ボタン押下時の処理
    '************************
    'Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'End Sub
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oConn = Nothing
        'oStaffDBIO = Nothing
        oChannelDBIO = Nothing
        oRequestDataDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub PRODUCT_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles REQUEST_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = REQUEST_V.CurrentRow.Index

        If REQUEST_V(1, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        S_REQUESTNUMBER = REQUEST_V(0, SelRow).Value.ToString()

        'oStaffDBIO = Nothing
        oChannelDBIO = Nothing
        oRequestDataDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        '商品選択ウィンドウを閉じる
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Long
        Dim pChannelCode As Integer
        Dim pFromDate As String
        Dim pToDate As String
        Dim pProductCode As String
        Dim pProductName As String
        Dim pOptionName As String
        Dim pUnShipFlg As Boolean
        Dim pShipFlg As Boolean

        REQUEST_V.SuspendLayout()

        '2020,4,20 A.Komita 削除 start-----------
        '明細行クリア
        'For i = 0 To REQUEST_V.Rows.Count - 1
        '    REQUEST_V.Rows.Clear()
        'Next i
        '2020,4,20 A.Komita 削除 end-------------


        '2020,4,20 A.Komita 追加 From

        '明細行クリア
        For i = 0 To REQUEST_V.Rows.Count
            REQUEST_V.Rows.Clear()
        Next i
        '2020,4,20 A.Komita 追加 To

        'データ検索中メッセージ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oRequest = Nothing

        '商品在庫データの読み込み
        '受注日(From)
        If oTool.MaskClear(FROM_REQUEST_DATE_T.Text) = "" Then
            pFromDate = Nothing
        Else
            pFromDate = oTool.MaskClear(FROM_REQUEST_DATE_T.Text)
        End If
        '受注日(To)
        If oTool.MaskClear(TO_REQUEST_DATE_T.Text) = "" Then
            pToDate = Nothing
        Else
            pToDate = oTool.MaskClear(TO_REQUEST_DATE_T.Text)
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

        '出荷状況フラグ(未納フラグ）
        If NON_SHIP_C.Checked = True Then
            pUnShipFlg = True
        Else
            pUnShipFlg = Nothing
        End If

        '出荷状況フラグ（完納フラグ）
        If FINISH_SHIP_C.Checked = True Then
            pShipFlg = True
        Else
            pShipFlg = Nothing
        End If

        RecordCnt = oRequestDataDBIO.getRequest(
                        oRequestData,
                        pChannelCode,
                        REQUEST_CODE_T.Text,
                        pFromDate,
                        pToDate,
                        Nothing,
                        Nothing,
                        Nothing,
                        Nothing,
                        pShipFlg,
                        pUnShipFlg,
                        Nothing,
                        pProductCode,
                        pProductName,
                        pOptionName,
                        oTran
        )

        '検索結果の画面セット
        If RecordCnt > 0 Then
            '-----------------------------------------------------------------------------------------
            '2019/12/01 suzuki
            'データ件数が500件の条件を追加
            '1000件以上になるとエラーが発生し、原因が分からない為この形をとりました。
            '-----------------------------------------------------------------------------------------
            '検索MAX値の確認
            If RecordCnt > DISP_ROW_MAX Then
                Message_form.Dispose()
                Message_form = Nothing
                Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています",
                                            "条件を変更して再検索して下さい",
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------
            '2019/12/01 suzuki

            '-----------------------------------------------------------------------------------------
            '検索結果の画面セット
            SEARCH_RESULT_SET()
        Else
            'メッセージウィンドウのクリア
            Message_form.Dispose()
            Message_form = Nothing

            Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。",
                                                  "条件を変更後再度検索して下さい。",
                                                  Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        REQUEST_V.ResumeLayout()
    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oChannelDBIO = Nothing
        oRequestDataDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub
End Class
