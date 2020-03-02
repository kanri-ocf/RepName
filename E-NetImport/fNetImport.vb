
Imports System.Text.RegularExpressions

Public Class fNetImport
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private sColumn() As cStructureLib.sDownloadColumn
    Private cMstDownloadColumnDBIO As cMstDownloadColumnDBIO

    Private oRequestData() As cStructureLib.sRequestData
    Private oDataRequestDBIO As cDataRequestDBIO

    Private oRequestSubData() As cStructureLib.sRequestSubData
    Private oDataRequestSubDBIO As cDataRequestSubDBIO

    Private oDataRequestTMPDBIO As cDataRequestTMPDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    Private oCnvProductCd() As cStructureLib.sViewCnvProductCd
    Private oPenddingData() As cStructureLib.sViewPenddingCnvProduct
    Private oMstCnvProductCdDBIO As cMstCnvProductCdDBIO

    Private oChannelPayment() As cStructureLib.sChannelPayment
    Private oMstChannelPaymentDBIO As cMstChannelPaymentDBIO

    Private oTool As cTool

    Private RequestCheck As CheckBox()
    Private sData() As String
    Private hReadData() As cStructureLib.sViewCSVReadBuff

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private RequestNo As String

    Private PageNo As Integer
    Private SelectCnt As Integer
    Private RowNo As Integer

    Private oTran As System.Data.OleDb.OleDbTransaction

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

        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oDataRequestSubDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        oMstChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)

        oDataRequestTMPDBIO = New cDataRequestTMPDBIO(oConn, oCommand, oDataReader)

        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstCnvProductCdDBIO = New cMstCnvProductCdDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

    End Sub
    Private Sub fNetImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
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
        oMstConfigDBIO = Nothing

        If STAFF_CODE = Nothing Then
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            Application.DoEvents()
            If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
                '担当者セット
                STAFF_CODE = staff_form.STAFF_CODE
                STAFF_NAME = staff_form.STAFF_NAME
                staff_form = Nothing
            Else
                staff_form = Nothing
                Environment.Exit(1)
            End If
        End If

        'チャネルリストボックスセット
        CHANNEL_SET()

        '明細表示エリアタイトル行生成
        GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

    End Sub
    '***************************
    'チャネル名称リストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oChannel = Nothing
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 2, Nothing, True, oTran)
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
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            CHANNEL_L.Items.Add(oChannel(i).sChannelName)
        Next
    End Sub

    Private Sub INIT_PROC()
        Dim i As Integer

        '明細行クリア
        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V.Rows.Clear()
        Next i

        '抽出件数の初期化
        PICKUP_CNT_L.Text = 0

        '保留件数の初期化
        HOLD_COUNT_L.Text = 0

        '保留(受注)件数の取得
        oPenddingData = Nothing
        HOLD_COUNT_L.Text = oMstCnvProductCdDBIO.getPenddingCnvProduct(oPenddingData, oTran).ToString
        If CLng(HOLD_COUNT_L.Text) > 0 Then
            '商品コード変換マスタ画面表示
            Dim cnv_product_code_form = New fCnvProductCdMst(oConn, oCommand, oDataReader, oRequestData, 2)
            cnv_product_code_form.ShowDialog()
            cnv_product_code_form = Nothing

            '保留受注件数のセット
            oPenddingData = Nothing
            HOLD_COUNT_L.Text = oMstCnvProductCdDBIO.getPenddingCnvProduct(oPenddingData, oTran).ToString
        End If

        Try
            '---トランザクション開始
            oTran = oConn.BeginTransaction

            '注文情報データTMP → 注文情報データへ移動
            oDataRequestDBIO.insertTmpToRequest(oTran)

            '注文情報TMP削除
            oDataRequestDBIO.deleteTmpToRequest(oTran)

            '注文情報明細データTMP → 注文明細情報データへ移動
            oDataRequestSubDBIO.insertTmpToRequest(oTran)

            ''注文情報明細データに対し、値引き、送料、ポイント値引き、手数料 のレコードを作成する
            'oDataRequestSubDBIO.insertChargeRecords(oTran, oConf)

            '注文明細情報TMP削除
            oDataRequestSubDBIO.deleteTmpToRequest(oTran)
        Catch ex As Exception
            If oTran IsNot Nothing Then
                '---トランザクション取消し
                oTran.Rollback()
                oTran.Dispose() : oTran = Nothing
            End If
        Finally
            If oTran IsNot Nothing Then
                '---トランザクション終了
                oTran.Commit()
                oTran.Dispose() : oTran = Nothing
            End If
        End Try

        SEARCH_RESULT_DISP()

    End Sub

    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
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
        REQUEST_V.RowHeadersVisible = False
        REQUEST_V.ColumnHeadersHeight = 30
        REQUEST_V.RowTemplate.Height = 30

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewCheckBoxColumn
        column1.HeaderText = "選択"
        REQUEST_V.Columns.Add(column1)
        column1.Width = 40
        column1.Name = "選択"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "受注コード"
        REQUEST_V.Columns.Add(column2)
        column2.Width = 85
        column2.ReadOnly = True
        column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column2.Name = "受注コード"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "受注日"
        REQUEST_V.Columns.Add(column3)
        column3.Width = 90
        column3.ReadOnly = True
        column3.Name = "受注日"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "顧客名称"
        REQUEST_V.Columns.Add(column4)
        column4.Width = 100
        column4.ReadOnly = True
        column4.Name = "顧客名称"

        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "都道府県"
        REQUEST_V.Columns.Add(column5)
        column5.Width = 80
        column5.ReadOnly = True
        column5.Name = "都道府県"

        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "市区町村"
        REQUEST_V.Columns.Add(column6)
        column6.Width = 80
        column6.ReadOnly = True
        column6.Name = "市区町村"

        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "住所１"
        REQUEST_V.Columns.Add(column7)
        column7.Width = 120
        column7.ReadOnly = True
        column7.Name = "住所１"

        Dim column8 As New DataGridViewTextBoxColumn
        column8.HeaderText = "住所２"
        REQUEST_V.Columns.Add(column8)
        column8.Width = 120
        column8.ReadOnly = True
        column8.Name = "住所２"

        Dim column9 As New DataGridViewTextBoxColumn
        column9.HeaderText = "電話番号"
        REQUEST_V.Columns.Add(column9)
        column9.Width = 80
        column9.ReadOnly = True
        column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column9.DefaultCellStyle.BackColor = Color.Wheat
        column9.Name = "電話番号"

        Dim column10 As New DataGridViewTextBoxColumn
        column10.HeaderText = "購入金額"
        REQUEST_V.Columns.Add(column10)
        column10.Width = 80
        column10.ReadOnly = True
        column10.DefaultCellStyle.Format = "c"
        column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column10.Name = "購入金額"

        Dim column11 As New DataGridViewTextBoxColumn
        column11.HeaderText = "支払方法"
        REQUEST_V.Columns.Add(column11)
        column11.Width = 85
        column11.ReadOnly = True
        column11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        column11.Name = "支払方法"

        '背景色を白に設定
        REQUEST_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        REQUEST_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub
    Public Sub SEARCH_RESULT_DISP()
        Dim RecordCnt As Long
        Dim i As Long
        Dim CCd As Integer

        '明細行クリア
        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '検索キー:チャネルコードの整形
        If CHANNEL_L.SelectedIndex >= 0 Then
            CCd = oChannel(CHANNEL_L.SelectedIndex).sChannelCode
        Else
            CCd = Nothing
        End If

        '保留受注件数のセット
        oPenddingData = Nothing
        HOLD_COUNT_L.Text = oMstCnvProductCdDBIO.getPenddingCnvProduct(oPenddingData, oTran).ToString

        '注文情報データの読み込み
        oRequestData = Nothing
        RecordCnt = oDataRequestDBIO.getRequest( _
                        oRequestData, _
                        CCd, _
                        REQUEST_CODE_T.Text, _
                        oTool.MaskClear(REQUEST_DATE_T.Text), _
                        oTool.MaskClear(REQUEST_DATE_T.Text), _
                        CUSTMOR_NAME_T.Text, _
                        Nothing, _
                        PRINTED_C.Checked, _
                        UNPRINTED_C.Checked, _
                        SHIPED_C.Checked, _
                        UNSHIP_C.Checked, _
                        Nothing, _
                        PRODUCT_CODE_T.Text, _
                        Nothing, _
                        Nothing, _
                        oTran)

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

        '検索結果の画面セット
        PICKUP_CNT_L.Text = RecordCnt

        '検索結果の画面セット
        SEARCH_RESULT_SET(RecordCnt)

        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing


    End Sub
    '***********************************************
    '検索結果を画面にセット
    '***********************************************
    Sub SEARCH_RESULT_SET(ByVal RecordCnt As Long)
        Dim i As Integer

        ReDim RequestCheck(RecordCnt)
        ReDim oChannelPayment(0)

        '表示設定
        For i = 0 To RecordCnt - 1
            oMstChannelPaymentDBIO.getChannelPaymentMst(oChannelPayment, oRequestData(i).sChannelPaymentCode, Nothing, Nothing, Nothing, oTran)
            REQUEST_V.Rows.Add(
                    False,
                    oRequestData(i).sRequestCode,
                    oRequestData(i).sRequestDate,
                    oRequestData(i).sShip1stName & " " & oRequestData(i).sShip2ndName,
                    oRequestData(i).sShipState,
                    oRequestData(i).sShipCity,
                    oRequestData(i).sShipAdder1,
                    oRequestData(i).sShipAdder2,
                    oRequestData(i).sShipTel,
                    oRequestData(i).sTotalPrice,
                    oChannelPayment(0).sChannelPaymentName
            )
        Next i
    End Sub

    '**********************
    '受注番号発番処理
    '**********************
    Private Function REQUEST_NUMBER_CREATE(ByVal ChannelCode As Integer) As String
        Dim ORDER_NUMBER As String
        Dim MaxRequestCode As Long
        Dim MaxCode1 As Long
        Dim MaxCode2 As Long
        Dim JanCode As String

        '受注情報データと受注情報データTMPから、最大の受注番号を取得
        MaxCode1 = oDataRequestDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        MaxCode2 = oDataRequestTMPDBIO.getMaxRequestCode(CInt(String.Format("{0:0}", ChannelCode)), String.Format("{0:yyMMdd}", Now), oTran)
        If MaxCode1 > MaxCode2 Then
            MaxRequestCode = MaxCode1
        Else
            MaxRequestCode = MaxCode2
        End If

        ORDER_NUMBER = "992" & String.Format("{0:0}", ChannelCode) & String.Format("{0:yyMMdd}", Now) & String.Format("{0:00}", MaxRequestCode)

        'チェックデジットの生成
        JanCode = oTool.JANCD(ORDER_NUMBER)

        REQUEST_NUMBER_CREATE = JanCode
    End Function
    '**********************
    '受注番号読込処理
    '**********************
    Private Function REQUEST_NUMBER_READ(ByVal ORRequestCode As String) As String
        Dim RecordCount As Long

        ReDim oRequestData(0)
        '受注コードが同じである、受注情報データの存在確認
        RecordCount = oDataRequestDBIO.getRequest(oRequestData,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  ORRequestCode,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  Nothing,
                                                  oTran)

        '受注コードが同じである、受注情報データTMPの存在確認
        If oRequestData(0).sRequestCode Is Nothing Then
            RecordCount = oDataRequestTMPDBIO.getRequest(oRequestData, Nothing, Nothing, Nothing, Nothing, ORRequestCode, oTran)
        End If

        REQUEST_NUMBER_READ = oRequestData(0).sRequestCode

    End Function
    Private Sub REQUEST_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles REQUEST_V.CellClick
        'チェックボックスの列かどうか調べる
        If e.RowIndex >= 0 Then
            If e.ColumnIndex <> 0 Then
                If REQUEST_V("選択", e.RowIndex).Value = False Then
                    REQUEST_V("選択", e.RowIndex).Value = True
                Else
                    REQUEST_V("選択", e.RowIndex).Value = False
                End If
            End If
        End If
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        SEARCH_RESULT_DISP()

    End Sub

    Private Sub OFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFF_B.Click
        Dim i As Integer

        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V("選択", i).Value = False
        Next i

    End Sub

    Private Sub ON_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ON_B.Click
        Dim i As Integer

        For i = 0 To REQUEST_V.Rows.Count - 1
            REQUEST_V("選択", i).Value = True
        Next i

    End Sub

    Private Sub REQUEST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQUEST_B.Click
        Dim i As Integer
        Dim Message_form As cMessageLib.fMessage
        Dim oReportPage As New cReportsLib.cReportsLib
        Dim ret As Integer

        SelectCnt = 0
        For i = 0 To REQUEST_V.Rows.Count - 1
            If REQUEST_V("選択", i).Value = True Then
                SelectCnt = SelectCnt + 1
            End If
        Next i

        If SelectCnt = 0 Then
            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "受注データが選択されていません", _
                                            "印刷する受注情報を選択して下さい。", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Exit Sub
        End If

        '印刷実行
        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(0, "受注伝票を印刷中です。", _
                                        "しばらくお待ちください。", _
                                        Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        'レポート印刷
        ret = oReportPage.RequestPrint(oConn, oCommand, oDataReader, REQUEST_V, SelectCnt, oTran)

        oReportPage = Nothing

        '受注伝票出力フラグ＝Trueセット
        If ret = True Then
            For i = 0 To REQUEST_V.Rows.Count - 1
                If REQUEST_V("選択", i).Value = True Then
                    oDataRequestDBIO.updatePrintFlg(REQUEST_V("受注コード", i).Value, True, oTran)
                End If
            Next i

        End If
        Message_form.Dispose()
        Message_form = Nothing

        SEARCH_RESULT_DISP()

    End Sub

    Private Sub IMPORT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPORT_B.Click
        Dim hReadData() As cStructureLib.sViewCSVReadBuff
        Dim cMstDownloadColumnDBIO As New cMstDownloadColumnDBIO(oConn, oCommand, oDataReader)
        Dim ImportChannel As Integer
        Dim Path1 As String
        Dim Path2 As String
        Dim oBuffNetImportCSV As New cBufferNetImportCSV(oConn, oCommand, oDataReader, oTran, 1)
        Dim pCMSType As Integer

        ReDim hReadData(0)

        '取込みデータ選択画面表示
        'メッセージウィンドウ表示
        Dim fNetImportSelect_form As fNetImportSelect

        fNetImportSelect_form = New fNetImportSelect(oChannel, oConf)
        fNetImportSelect_form.ShowDialog()

        '取込みデータ選択画面がキャンセル終了された場合
        If fNetImportSelect_form.DialogResult = Windows.Forms.DialogResult.Cancel Then
            fNetImportSelect_form = Nothing
            CHANNEL_L.Focus()
            Exit Sub
        End If

        ImportChannel = oChannel(fNetImportSelect_form.CHANNEL_L.SelectedIndex).sChannelCode
        Path1 = fNetImportSelect_form.PATH_1_T.Text
        Path2 = fNetImportSelect_form.PATH_2_T.Text
        pCMSType = oChannel(fNetImportSelect_form.CHANNEL_L.SelectedIndex).sCMSType

        fNetImportSelect_form = Nothing
        Dim tempFilePath As String = Application.StartupPath & "\Net\Temp"
        'インポート対象CSVの移動
        Select Case pCMSType
            Case 1     'Yahooデータの場合
                System.IO.File.Copy(Path1, tempFilePath & "\Yahoo_Order.csv", True)
                System.IO.File.Copy(Path2, tempFilePath & "\Yahoo_Product.csv", True)
            Case 2     '楽天データの場合
                System.IO.File.Copy(Path1, tempFilePath & "\Rakuten_Order.csv", True)
            Case 3     'ショップサーブデータの場合
                System.IO.File.Copy(Path1, tempFilePath & "\ShopServ_Order.csv", True)
            Case 4     'Amazonデータの場合
                System.IO.File.Copy(Path1, tempFilePath & "\Amazon_Order.csv", True)
        End Select

        'データ取込み
        oBuffNetImportCSV.IMPORT(tempFilePath)

        INIT_PROC()

    End Sub

    Private Sub CODE_MAP_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CODE_MAP_B.Click
        Dim cnv_product_code_form As fCnvProductCdMst
        Dim holdCnt = CInt(HOLD_COUNT_L.Text)
        If holdCnt > 0 Then holdCnt = 2
        cnv_product_code_form = New fCnvProductCdMst(oConn, oCommand, oDataReader, Nothing, holdCnt)
        cnv_product_code_form.ShowDialog()
        cnv_product_code_form.Dispose()
        '保留受注件数のセット
        oRequestData = Nothing
        HOLD_COUNT_L.Text = _
                    oDataRequestTMPDBIO.getRequest( _
                        oRequestData, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        oTran).ToString

    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        oDataRequestDBIO = Nothing
        oDataRequestSubDBIO = Nothing

        oDataRequestTMPDBIO = Nothing

        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub
End Class
