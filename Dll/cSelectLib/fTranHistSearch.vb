'2016.06.07 K.OIkawa s
'過去伝票の一覧を表示する

Public Class fTranHistSearch
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oHstTrn() As cStructureLib.sViewHstTrn
    Private oDataTrnMsDBIO As cDataTrnMsDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oShipment() As cStructureLib.sShipmentData
    Private oShipmentDBIO As cDataShipmentDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private MEMBER_CODE As String
    Public CHANNEL_CODE As Integer
    Public CHANNEL_NAME As String
    Public TRN_CODE As Long
    Public JAN_CODE As Long

    Public S_REQUESTNUMBER As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iMemberCode As String, _
            ByVal iChannel_Code As Integer, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'DB関連
        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran
        oDataTrnMsDBIO = New cDataTrnMsDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oShipmentDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)

        '会員コード
        MEMBER_CODE = iMemberCode
        'チャネルコード
        CHANNEL_CODE = iChannel_Code

        oTool = New cTool
    End Sub

    Private Sub fTranHistSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'チャネルリストの初期値セット
        For j As Integer = 0 To oChannel.Count - 1
            If oChannel(j).sChannelCode = CHANNEL_CODE Then
                CHANNEL_L.Text = oChannel(j).sChannelName
                CHANNEL_NAME = CHANNEL_L.Text
                Exit For
            End If
        Next
        '会員情報の初期値設定
        MEMBER_CODE_T.Text = MEMBER_CODE

    End Sub
    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V.Rows.Clear()
        Next i

        'チャネル初期化
        CHANNEL_L.Text = ""

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
        REQUEST_V.RowHeadersVisible = False
        REQUEST_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        REQUEST_V.ColumnHeadersHeight = 25
        REQUEST_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "受注日時"
        REQUEST_V.Columns.Add(column1)
        column1.Width = 120
        column1.ReadOnly = True
        column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column1.Name = "受注日時"

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "商品名"
        REQUEST_V.Columns.Add(column2)
        column2.Width = 230
        column2.ReadOnly = True
        column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column2.Name = "商品名"

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "商品単価"
        REQUEST_V.Columns.Add(column3)
        column3.Width = 100
        column3.ReadOnly = True
        column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column3.DefaultCellStyle.Format = "c"
        column3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column3.Name = "商品単価"

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "数量"
        REQUEST_V.Columns.Add(column4)
        column4.Width = 50
        column4.ReadOnly = True
        column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        column4.Name = "数量"

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "会員名称"
        REQUEST_V.Columns.Add(column5)
        column5.Width = 100
        column5.ReadOnly = True
        column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column5.Name = "会員名称"

        Dim column6 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column6.HeaderText = "チャネル名称"
        REQUEST_V.Columns.Add(column6)
        column6.Width = 100
        column6.ReadOnly = True
        column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column6.Name = "チャネル名称"

        Dim column7 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column7.HeaderText = "担当者"
        REQUEST_V.Columns.Add(column7)
        column7.Width = 100
        column7.ReadOnly = True
        column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column7.Name = "担当者"

        Dim column8 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column8.HeaderText = "取引コード"
        REQUEST_V.Columns.Add(column8)
        column8.Width = 0
        column8.ReadOnly = True
        column8.Visible = False
        column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column8.Name = "取引コード"

        Dim column9 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column9.HeaderText = "チャネルコード"
        REQUEST_V.Columns.Add(column9)
        column9.Width = 0
        column9.Visible = False
        column9.ReadOnly = True
        column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column9.Name = "チャネルコード"

        Dim column10 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column10.HeaderText = "支払方法名称"
        REQUEST_V.Columns.Add(column10)
        column10.Width = 100
        column10.ReadOnly = True
        column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column10.Name = "支払方法名称"

        Dim column11 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column11.HeaderText = "JANコード"
        REQUEST_V.Columns.Add(column11)
        column11.Width = 0
        column11.ReadOnly = False
        column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        column11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        column11.Name = "JANコード"

        '背景色を白に設定
        REQUEST_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        REQUEST_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

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
    '会員情報
    '************************
    Private Sub MEMBER_CODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MEMBER_CODE_T.GotFocus
        MEMBER_CODE_T.SelectAll()
    End Sub

    Private Sub MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_SEARCH_B.Click
        Dim fMember_form As cSelectLib.fMemberSearch
        Dim RecordCount As Integer

        'キー入力音出力
        oTool.PlaySound()

        fMember_form = New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
        fMember_form.ShowDialog()
        If fMember_form.DialogResult = Windows.Forms.DialogResult.OK Then
            RecordCount = oMstMemberDBIO.getMember(oMember, _
                                                   fMember_form.MEMBER_CODE_T.Text, _
                                                   "", _
                                                   "", _
                                                   Nothing, _
                                                   oTran)
            MEMBER_SET()
        Else
            MEMBER_INIT()
        End If
        fMember_form = Nothing
        MEMBER_CODE_T.Focus()
    End Sub
    Private Sub MEMBER_INIT()
        MEMBER_CODE_T.Text = ""
    End Sub
    Private Sub MEMBER_SET()
        MEMBER_CODE_T.Text = oMember(0).sMemberCode
    End Sub
    Private Function MEMBER_CHECK() As Boolean
        Dim RecordCount As Integer
        Dim message_form As cMessageLib.fMessage

        MEMBER_CHECK = False
        If MEMBER_CODE_T.Text.Length < 13 Then
            Exit Function
        End If

        RecordCount = oMstMemberDBIO.getMember(oMember, _
                                               MEMBER_CODE_T.Text, _
                                               "", _
                                               "", _
                                               Nothing, _
                                               oTran)
        If RecordCount = 0 Then
            message_form = New cMessageLib.fMessage(1, _
                      "会員コードが未登録です。", _
                      "再度確認して下さい。", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            MEMBER_INIT()
            Exit Function
        End If

        If oMember(0).sResignDate <> "" Then
            message_form = New cMessageLib.fMessage(1, _
                      "退会済みの会員コードが入力されました。", _
                      "再度確認して下さい。", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Exit Function
        End If

        If CDate(oMember(0).sEndRegistDate) < Now() Then
            message_form = New cMessageLib.fMessage(1, _
                      "契約期間切れの会員コードが入力されました。", _
                      "再度確認して下さい。", _
                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            Exit Function
        End If

        MEMBER_SET()

        MEMBER_CHECK = True

    End Function

    Private Sub JANCODE_T_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JANCODE_T.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If e.Control = False Then
                SEARCH_B.Focus()
            End If
        End If

    End Sub




    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long
        Dim i As Long
        Dim pChannelCode As Integer
        Dim pFromDate As String
        Dim pToDate As String
        Dim pProductCode As String
        Dim pProductName As String
        'Dim pOptionName As String
        Dim pJanCode As String
        Dim pMemberCode As String

        REQUEST_V.SuspendLayout()

        '明細行クリア
        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V.Rows.Clear()
        Next i

        'データ検索中メッセージ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        System.Windows.Forms.Application.DoEvents()

        '商品在庫データの読み込み
        'チャネルコード
        If CHANNEL_CODE_T.Text = "" Then
            pChannelCode = Nothing
        Else
            pChannelCode = CInt(CHANNEL_CODE_T.Text)
        End If
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
        '商品コード
        If PRODUCT_CODE_T.Text = "" Then
            pProductCode = Nothing
        Else
            pProductCode = PRODUCT_CODE_T.Text
        End If
        '商品JANコード
        If JANCODE_T.Text = "" Then
            pJanCode = Nothing
        Else
            pJanCode = JANCODE_T.Text
        End If
        '商品名称
        If PRODUCT_NAME_T.Text = "" Then
            pProductName = Nothing
        Else
            pProductName = PRODUCT_NAME_T.Text
        End If
        '会員コード
        If MEMBER_CODE_T.Text = "" Then
            pMemberCode = Nothing
        Else
            pMemberCode = MEMBER_CODE_T.Text
        End If

        RecordCnt = oDataTrnMsDBIO.getHstTrn( _
                        oHstTrn, _
                        pChannelCode, _
                        pFromDate, _
                        pToDate, _
                        pProductCode, _
                        pJanCode,
                        pProductName, _
                        pMemberCode,
                        oTran _
        )

        '検索結果の画面セット
        If RecordCnt > 0 Then
            '検索MAX値の確認
            If RecordCnt > DISP_ROW_MAX Then
                Message_form.Dispose()
                Message_form = Nothing
                Message_form = New cMessageLib.fMessage(1, "データ件数が500件を超えています", _
                                            "条件を変更して再建策して下さい", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            End If

            '検索結果の画面セット
            SEARCH_RESULT_SET()
        Else
            'メッセージウィンドウのクリア
            Message_form.Dispose()
            Message_form = Nothing

            Message_form = New cMessageLib.fMessage(1, "該当データが存在しません。", _
                                                  "条件を変更後再度検索して下さい。", _
                                                  Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

        REQUEST_V.ResumeLayout()
    End Sub





    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim cnt As Long
        'Dim str As String

        For i = 0 To REQUEST_V.Rows.Count
            REQUEST_V.Rows.Clear()
        Next i

        If oHstTrn Is Nothing Then
            Exit Sub
        End If

        '表示設定
        cnt = 0

        For i = 0 To oHstTrn.Length - 1
            ReDim oChannel(0)
            oChannelDBIO.getChannelMst(oChannel, oHstTrn(i).sChannelCode, Nothing, Nothing, Nothing, oTran)

            REQUEST_V.Rows.Add( _
             oHstTrn(i).sRequestDate & " " & oHstTrn(i).sRequesTime, _
             oHstTrn(i).sProductName, _
             oHstTrn(i).sUnitPrice, _
             oHstTrn(i).sCount, _
             oHstTrn(i).sMemberName, _
             oHstTrn(i).sChannelName, _
             oHstTrn(i).sStaffName, _
             oHstTrn(i).sTrnCode, _
             oHstTrn(i).sChannelCode, _
             oHstTrn(i).sPaymentMethod, _
             oHstTrn(i).sJanCode _
        )
            cnt = cnt + 1
        Next i
        COUNT_L.Text = cnt
    End Sub




    '***********************************************
    '検索結果選択
    '***********************************************
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

        TRN_CODE = CInt(REQUEST_V(7, SelRow).Value)     '取引コード
        CHANNEL_CODE = CLng(REQUEST_V(8, SelRow).Value) 'チャネルコード
        JAN_CODE = CLng(REQUEST_V(10, SelRow).Value)     '商品JANコード

        'oStaffDBIO = Nothing
        oChannelDBIO = Nothing
        oDataTrnMsDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        '商品選択ウィンドウを閉じる
    End Sub




    '***********************************************
    '戻るボタン押下時
    '***********************************************
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oChannelDBIO = Nothing
        oDataTrnMsDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '商品選択ウィンドウを閉じる
        Me.Close()

    End Sub
End Class

'2016.06.07 K.OIkawa e