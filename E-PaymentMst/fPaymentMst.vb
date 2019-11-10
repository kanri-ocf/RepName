Public Class fPaymentMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPayment() As cStructureLib.sPayment
    Private oMstPaymentDBIO As cMstPaymentDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New()
        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = Nothing
        STAFF_NAME = Nothing

    End Sub
    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

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
            Application.DoEvents()
            Application.Exit()
        End If

        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.fStaffEntry

        staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
        staff_form.ShowDialog()
        Application.DoEvents()
        If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
            '担当者セット
            STAFF_CODE_T.Text = staff_form.STAFF_CODE
            STAFF_NAME_T.Text = staff_form.STAFF_NAME
            staff_form = Nothing
        Else
            staff_form = Nothing
        End If

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '検索処理
        SEARCH_PROC()

    End Sub
     Private Sub INIT_PROC()

        S_REQUEST_C.Checked = False
        S_SHIP_C.Checked = False
        S_ORDER_C.Checked = False
        S_ARRIVE_C.Checked = False

        SEARCH_PROC()
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
            Dim cp As CreateParams = MyBase.CreateParams
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
        'レコードセレクタを非表示に設定
        DATA_V.RowHeadersVisible = False
        DATA_V.ColumnHeadersHeight = 30
        DATA_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "コード"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 60
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column1.Name = "支払方法コード"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "支払方法名称"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 210
        column2.Name = "支払方法名称"

        Dim column4 As New DataGridViewCheckBoxColumn
        column4.HeaderText = "掛取引"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 60
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column4.Name = "掛取引フラグ"

        Dim column5 As New DataGridViewCheckBoxColumn
        column5.HeaderText = "受注"
        DATA_V.Columns.Add(column5)
        column5.Width = 50
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column5.Name = "受注フラグ"

        Dim column6 As New DataGridViewCheckBoxColumn
        column6.HeaderText = "出荷"
        DATA_V.Columns.Add(column6)
        column6.Width = 50
        column6.ReadOnly = True
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column6.Name = "出荷フラグ"

        Dim column7 As New DataGridViewCheckBoxColumn
        column7.HeaderText = "発注"
        DATA_V.Columns.Add(column7)
        column7.Width = 50
        column7.ReadOnly = True
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column7.Name = "発注フラグ"

        Dim column8 As New DataGridViewCheckBoxColumn
        column8.HeaderText = "入庫"
        DATA_V.Columns.Add(column8)
        column8.Width = 50
        column8.ReadOnly = True
        column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column8.Name = "入庫フラグ"

        Dim column9 As New DataGridViewCheckBoxColumn
        column9.HeaderText = "返品"
        DATA_V.Columns.Add(column9)
        column9.Width = 50
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column9.Name = "返品フラグ"

        '背景色を白に設定
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer
        Dim str As String

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '表示設定
        str = ""
        For i = 0 To oPayment.Length - 1
            DATA_V.Rows.Add( _
                    oPayment(i).sPaymentCode, _
                    oPayment(i).sPaymentName, _
                    oPayment(i).sCreditFlg, _
                    oPayment(i).sRequestFlg, _
                    oPayment(i).sShipmentFlg, _
                    oPayment(i).sOrderFlg, _
                    oPayment(i).sArriveFlg, _
                    oPayment(i).sReturnFlg _
            )
        Next i
    End Sub


    '************************
    '検索ボタン押下時の処理
    '************************
    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click

        '検索処理
        SEARCH_PROC()

    End Sub
    Private Sub SEARCH_PROC()
        Dim pPaymentCode As Integer
        Dim pPaymentName As String
        Dim pCreditFlg As Boolean
        Dim pRequestFlg As Boolean
        Dim pShipmentFlg As Boolean
        Dim pOrderFlg As Boolean
        Dim pArriveFlg As Boolean
        Dim pReturnFlg As Boolean
        Dim pDaibikiFlg As Boolean
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '支払方法マスタ読み込みバッファ初期化
        oPayment = Nothing
        pPaymentCode = Nothing
        pPaymentName = Nothing
        pCreditFlg = Nothing
        pRequestFlg = Nothing
        pShipmentFlg = Nothing
        pOrderFlg = Nothing
        pArriveFlg = Nothing
        pReturnFlg = Nothing
        pDaibikiFlg = Nothing

        '支払方法コード
        If S_PAYMENT_CODE_T.Text <> "" Then
            pPaymentCode = S_PAYMENT_CODE_T.Text
        Else
            pPaymentCode = Nothing
        End If

        '支払方法名称
        If S_PAYMENT_NAME_T.Text <> "" Then
            pPaymentName = S_PAYMENT_NAME_T.Text
        Else
            pPaymentName = Nothing
        End If

        '掛け取引フラグ
        If S_CREDIT_C.Checked <> True Then
            pCreditFlg = Nothing
        Else
            pCreditFlg = True
        End If

        '受注フラグ
        If S_REQUEST_C.Checked <> True Then
            pRequestFlg = Nothing
        Else
            pRequestFlg = True
        End If

        '出荷フラグ
        If S_SHIP_C.Checked <> True Then
            pShipmentFlg = Nothing
        Else
            pShipmentFlg = True
        End If

        '発注フラグ
        If S_ORDER_C.Checked <> True Then
            pOrderFlg = Nothing
        Else
            pOrderFlg = True
        End If

        '入庫フラグ
        If S_ARRIVE_C.Checked <> True Then
            pArriveFlg = Nothing
        Else
            pArriveFlg = True
        End If

        '返品フラグ
        If S_RETURN_C.Checked <> True Then
            pReturnFlg = Nothing
        Else
            pReturnFlg = True
        End If

        '支払方法マスタの読み込み
        ReDim oPayment(0)
        'RecordCnt = oMstPaymentDBIO.getPayment( _
        '                oPayment, _
        '                pPaymentCode, _
        '                pPaymentName, _
        '                pCreditFlg, _
        '                pRequestFlg, _
        '                pShipmentFlg, _
        '                pOrderFlg, _
        '                pArriveFlg, _
        '                pReturnFlg, _
        '                oTran _
        ')
        RecordCnt = oMstPaymentDBIO.getPayment( _
                        oPayment, _
                        pPaymentCode, _
                        pPaymentName, _
                        pCreditFlg, _
                        pRequestFlg, _
                        pShipmentFlg, _
                        pOrderFlg, _
                        pArriveFlg, _
                        pReturnFlg, _
                        Nothing, _
                        oTran _
        )

        If RecordCnt > 0 Then
            '検索MAX値の確認
            If RecordCnt > DISP_COW_MAX Then
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
        End If

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oPayment = Nothing
        oMstPaymentDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '支払方法マスタ管理ウィンドウを閉じる
        Me.Close()
    End Sub

    Private Sub DATA_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        '選択行がタイトル行の場合はリターン
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        'タイトル行の下の行を1行目として返す
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If
        Dim fPaymentSub_form As New fPaymentMstSub(oConn, oCommand, oDataReader, CInt(DATA_V("支払方法コード", SelRow).Value), STAFF_CODE_T.Text, STAFF_NAME_T.Text, oTran)
        fPaymentSub_form.ShowDialog()
        fPaymentSub_form = Nothing

        '検索処理
        SEARCH_PROC()

        '支払方法コードにフォカスセット
        S_PAYMENT_CODE_T.Focus()
    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fPaymentSub_form As New fPaymentMstSub(oConn, oCommand, oDataReader, Nothing, STAFF_CODE_T.Text, STAFF_NAME_T.Text, oTran)
        fPaymentSub_form.ShowDialog()
        fPaymentSub_form = Nothing

        '検索処理
        SEARCH_PROC()

    End Sub
End Class
