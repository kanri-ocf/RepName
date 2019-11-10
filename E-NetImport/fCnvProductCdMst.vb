'*************************************
'DataGridViewに対する列挙型の定義
'*************************************
'商品コード変換マスタ明細(DataGridView)
Public Enum CPCMVColumnType As Integer
    ProductCode
    ChannelName
    ChannelProductCode
    ChannelProductName
    ChannelOptionNameAndValue
End Enum

'商品マスタ明細(DataGridView)
Public Enum PPMVColumnType As Integer
    JANCode
    ProductCode
    ProductName
    OptionValue
    Price
    MakerName
    SupplierName
End Enum

Public Class fCnvProductCdMst
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader
    Private oTool As cTool

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oMstProductDBIO As cMstProductDBIO

    Private oCnvProductCd() As cStructureLib.sViewCnvProductCd
    Private oPenddingCnvProduct() As cStructureLib.sViewPenddingCnvProduct
    Private oMstCnvProductCdDBIO As cMstCnvProductCdDBIO

    Private oRequestData() As cStructureLib.sRequestData
    Private oDataRequestDBIO As cDataRequestDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private NowRowIndex As Integer

    Private OpenMode As Integer

    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iRequestData() As cStructureLib.sRequestData, _
            ByVal mode As Integer)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oRequestData = iRequestData

        oTool = New cTool
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstCnvProductCdDBIO = New cMstCnvProductCdDBIO(oConn, oCommand, oDataReader)
        oDataRequestDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)

        Me.OpenMode = mode

    End Sub

    Private Sub fConvProductCdMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, Tran)
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

        'チャネルリストボックスセット
        CHANNEL_SET()

        '仕入先リストボックスセット
        SUPPLIER_SET()

        '明細表示エリアタイトル行生成
        CNV_PRODUCT_CD_MST_GRIDVIEW_CREATE()
        P_PRODUCT_MST_GRIDVIEW_CREATE()

        '表示初期化処理
        INIT_PROC()

        '保留件数がゼロ件でない場合は、チェックして検索@@
        If OpenMode = 2 Then
            PRODUCT_CD_ISNULL_C.Checked = True
            SEARCH_B_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub INIT_PROC()
        Dim i As Long

        '明細行クリア
        For i = 0 To CNV_PRODUCT_CD_MST_V.Rows.Count - 1
            CNV_PRODUCT_CD_MST_V.Rows.Clear()
        Next i

        '明細行クリア
        For i = 0 To P_PRODUCT_MST_V.Rows.Count - 1
            P_PRODUCT_MST_V.Rows.Clear()
        Next i
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

    '***************************
    'チャネル名称リストボックスセット
    '***************************
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'チャネルコンボ内容設定
        oChannel = Nothing
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 2, Nothing, True, Tran)
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

    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, Tran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません", _
                                                "仕入先マスタを登録してください", _
                                                Nothing, Nothing)
            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            P_SUPPLIER_L.Items.Add(oSupplier(i).sSupplierName)
        Next
    End Sub

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    '商品コード変換マスタ明細(DataGridView)
    Sub CNV_PRODUCT_CD_MST_GRIDVIEW_CREATE()

        'レコードセレクタを非表示に設定
        CNV_PRODUCT_CD_MST_V.RowHeadersVisible = False
        CNV_PRODUCT_CD_MST_V.MultiSelect = False
        CNV_PRODUCT_CD_MST_V.ReadOnly = True
        CNV_PRODUCT_CD_MST_V.RowsDefaultCellStyle.BackColor = Color.White
        CNV_PRODUCT_CD_MST_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewTextBoxColumn
        column1.Name = "商品コード"
        column1.Width = 100
        CNV_PRODUCT_CD_MST_V.Columns.Add(column1)

        Dim column2 As New DataGridViewTextBoxColumn
        column2.Name = "チャネル名称"
        column2.Width = 100
        CNV_PRODUCT_CD_MST_V.Columns.Add(column2)

        Dim column3 As New DataGridViewTextBoxColumn
        column3.Name = "チャネル商品コード"
        column3.Width = 150
        CNV_PRODUCT_CD_MST_V.Columns.Add(column3)

        Dim column4 As New DataGridViewTextBoxColumn
        column4.Name = "チャネル商品名称"
        column4.Width = 320
        CNV_PRODUCT_CD_MST_V.Columns.Add(column4)

        Dim column5 As New DataGridViewTextBoxColumn
        column5.Name = "チャネルオプション"
        column5.Width = 300
        CNV_PRODUCT_CD_MST_V.Columns.Add(column5)

    End Sub

    '商品マスタ明細(DataGridView)
    Sub P_PRODUCT_MST_GRIDVIEW_CREATE()

        'レコードセレクタを非表示に設定
        P_PRODUCT_MST_V.RowHeadersVisible = False
        P_PRODUCT_MST_V.MultiSelect = False
        P_PRODUCT_MST_V.ReadOnly = True
        P_PRODUCT_MST_V.RowsDefaultCellStyle.BackColor = Color.White
        P_PRODUCT_MST_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

        'グリッドのヘッダーを作成します。
        Dim column1 As New DataGridViewTextBoxColumn
        column1.Name = "JANコード"
        column1.Width = 80
        P_PRODUCT_MST_V.Columns.Add(column1)

        Dim column2 As New DataGridViewTextBoxColumn
        column2.Name = "商品コード"
        column2.Width = 100
        P_PRODUCT_MST_V.Columns.Add(column2)

        Dim column3 As New DataGridViewTextBoxColumn
        column3.Name = "商品名称"
        column3.Width = 220
        P_PRODUCT_MST_V.Columns.Add(column3)

        Dim column4 As New DataGridViewTextBoxColumn
        column4.Name = "オプション値"
        column4.Width = 200
        P_PRODUCT_MST_V.Columns.Add(column4)

        Dim column5 As New DataGridViewTextBoxColumn
        column5.Name = "定価"
        P_PRODUCT_MST_V.Columns.Add(column5)
        column5.Width = 100
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim column6 As New DataGridViewTextBoxColumn
        column6.Name = "メーカー"
        column6.Width = 120
        P_PRODUCT_MST_V.Columns.Add(column6)

        Dim column7 As New DataGridViewTextBoxColumn
        column7.Name = "仕入先"
        P_PRODUCT_MST_V.Columns.Add(column7)
        column7.Width = 115

    End Sub

    '***********************************************
    '検索結果を画面(商品コード変換マスタ明細)にセット
    '***********************************************
    Sub CNV_PRODUCT_CD_MST_V_SEARCH_RESULT_SET()
        Dim i As Long

        For i = 0 To CNV_PRODUCT_CD_MST_V.Rows.Count
            CNV_PRODUCT_CD_MST_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oPenddingCnvProduct.Length - 1
            If oPenddingCnvProduct(i).sChannelProductCode.Substring(0, 5) <> "ZZZZZ" Then
                CNV_PRODUCT_CD_MST_V.Rows.Add( _
                        oPenddingCnvProduct(i).sProductCode, _
                        oPenddingCnvProduct(i).sChannelName, _
                        oPenddingCnvProduct(i).sChannelProductCode, _
                        oPenddingCnvProduct(i).sChannelProductName, _
                        oPenddingCnvProduct(i).sChannelOptionNameAndValue _
                )
            End If
        Next i
    End Sub

    '***********************************************
    '検索結果を画面(商品マスタ明細)にセット
    '***********************************************
    Sub P_PRODUCT_MST_V_SEARCH_RESULT_SET(ByVal isChecked As Boolean)
        Dim i As Long

        For i = 0 To P_PRODUCT_MST_V.Rows.Count
            P_PRODUCT_MST_V.Rows.Clear()
        Next i

        '表示設定
        For i = 0 To oProduct.Length - 1
            P_PRODUCT_MST_V.Rows.Add( _
                    oProduct(i).sJANCode, _
                    oProduct(i).sProductCode, _
                    oProduct(i).sProductName, _
                    oProduct(i).sOption1 & ":" & _
                    oProduct(i).sOption2 & ":" & _
                    oProduct(i).sOption3 & ":" & _
                    oProduct(i).sOption4 & ":" & _
                    oProduct(i).sOption5, _
                    oProduct(i).sListPrice, _
                    oProduct(i).sMakerName, _
                    "" _
            )
        Next i

        '@TODO (仕入先名の取得)
        'oProduct(i).sSupplierName1 _

    End Sub

    '***********************************************
    'イベント処理:商品コード変換マスタ明細セル選択
    '***********************************************
    Private Sub CNV_PRODUCT_CD_MST_V_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CNV_PRODUCT_CD_MST_V.CellClick
        Dim RecordCnt As Long
        Dim KeyProductCode As String
        Dim KeyIsNotChannelProductCode As Boolean
        '
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        NowRowIndex = e.RowIndex

        '検索キーの判定
        If (CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ProductCode, NowRowIndex).Value <> "") Then
            KeyIsNotChannelProductCode = True
            KeyProductCode = CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ProductCode, NowRowIndex).Value
        Else
            KeyIsNotChannelProductCode = False
            KeyProductCode = CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ChannelProductCode, NowRowIndex).Value
        End If

        '商品マスタの読み込みバッファ初期化
        oProduct = Nothing

        '商品マスタの読み込み
        RecordCnt = oMstProductDBIO.getProduct( _
                        oProduct, _
                        Nothing, _
                        KeyProductCode, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Tran)

        '商品マスタ検索条件クリア
        P_JANCODE_T.Text = ""
        P_PRODUCT_CODE_T.Text = ""
        P_PRODUCT_NAME_T.Text = ""
        P_SUPPLIER_L.Text = ""
        P_MAKER_NAME_T.Text = ""

        '商品マスタ明細行クリア
        For i = 0 To P_PRODUCT_MST_V.Rows.Count - 1
            P_PRODUCT_MST_V.Rows.Clear()
        Next i

        If RecordCnt > 0 Then
            '商品マスタ明細行セット
            If KeyIsNotChannelProductCode Then
                P_PRODUCT_CODE_T.Text = oProduct(0).sProductCode
                P_PRODUCT_MST_V_SEARCH_RESULT_SET(True)
            Else
                P_PRODUCT_NAME_T.Text = oProduct(0).sProductName
                P_SEARCH_PROD_B_Click(Nothing, Nothing)
            End If
        Else
            P_PRODUCT_NAME_T.Text = CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ChannelProductName, NowRowIndex).Value
        End If
    End Sub

    '***********************************************
    'イベント処理:商品マスタ明細セル選択(ダブルクリック)
    '***********************************************
    Private Sub P_PRODUCT_MST_V_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles P_PRODUCT_MST_V.CellDoubleClick
        '
        If e.RowIndex < 0 Then Return

        If oPenddingCnvProduct(NowRowIndex).sProductCode <> oProduct(e.RowIndex).sProductCode Then
            CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ProductCode, NowRowIndex).Value = oProduct(e.RowIndex).sProductCode
            CNV_PRODUCT_CD_MST_V.Rows(NowRowIndex).DefaultCellStyle.ForeColor = Color.Red
        Else
            CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ProductCode, NowRowIndex).Value = oProduct(e.RowIndex).sProductCode
            CNV_PRODUCT_CD_MST_V.Rows(NowRowIndex).DefaultCellStyle.ForeColor = Color.Black
        End If
    End Sub

    '***********************************************
    'イベント処理:終了ボタン押下
    '***********************************************
    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RecordCnt As Long = 0D
        Dim i As Integer

        '未登録変更データの確認
        For i = 0 To CNV_PRODUCT_CD_MST_V.Rows.Count - 1
            If CNV_PRODUCT_CD_MST_V(0, i).Value = "" Then
                RecordCnt += 1
            End If
        Next
        If RecordCnt > 0 Then
            Dim Message_form As cMessageLib.fMessage
            Message_form = New cMessageLib.fMessage(2, "未登録の変更データがあります。", _
                                    "終了してもよろしいですか？", _
                                    Nothing, Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                Message_form.Dispose()
                Message_form = Nothing
                Exit Sub
            End If
            Message_form.Dispose()
            Message_form = Nothing
        End If

        'MsgBox(CNV_PRODUCT_CD_MST_V.SelectedRows(0).Cells(CPCMVColumnType.ProductCode).Value)

        oConn = Nothing
        oTool = Nothing

        oMstConfigDBIO = Nothing
        oMstChannelDBIO = Nothing
        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstCnvProductCdDBIO = Nothing
        oDataRequestDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RecordCnt As Long

        '明細行クリア
        CNV_PRODUCT_CD_MST_V.Rows.Clear()
        P_PRODUCT_MST_V.Rows.Clear()

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", _
                                              "しばらくお待ちください", _
                                              Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oPenddingCnvProduct = Nothing

        '商品情報変換マスタの読み込み
        RecordCnt = oMstCnvProductCdDBIO.getPenddingCnvProduct(oPenddingCnvProduct, Tran)
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
            CNV_PRODUCT_CD_MST_V_SEARCH_RESULT_SET()
            If CNV_PRODUCT_CD_MST_V.Rows.Count = 0 Then
                oConn = Nothing
                oTool = Nothing

                oMstConfigDBIO = Nothing
                oMstChannelDBIO = Nothing
                oSupplierDBIO = Nothing
                oMstProductDBIO = Nothing
                oMstCnvProductCdDBIO = Nothing
                oDataRequestDBIO = Nothing

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

            '検索結果に対応する商品マスタ明細をセット
            CNV_PRODUCT_CD_MST_V_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub UPDATE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATE_B.Click
        Dim RecordCnt As Long
        Dim i As Integer
        Dim Tran As System.Data.OleDb.OleDbTransaction
        Dim oPenddingData() As cStructureLib.sViewPenddingCnvProduct

        '---トランザクション開始
        'Tran = oConn.BeginTransaction
        Tran = Nothing

        Dim UpdateCnt As Long = 0
        For i = 0 To CNV_PRODUCT_CD_MST_V.Rows.Count - 1
            If CNV_PRODUCT_CD_MST_V(0, i).Value <> "" Then
                oPenddingCnvProduct(i).sProductCode = CNV_PRODUCT_CD_MST_V(CPCMVColumnType.ProductCode, i).Value
                RecordCnt = oMstCnvProductCdDBIO.deleteCnvProductCdMst(oPenddingCnvProduct(i), Tran)
                RecordCnt = oMstCnvProductCdDBIO.insertCnvProductCdMst(oPenddingCnvProduct(i), Tran)
                CNV_PRODUCT_CD_MST_V.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                UpdateCnt += 1
            End If
        Next
        ''注文商品がすべて商品コード変換マスタに登録済のものを対象とし、
        ''一時表から注文情報および注文情報明細をまとめて登録する
        'oDataRequestDBIO.insertTmpToRequest(Tran)

        Dim Message_form As cMessageLib.fMessage
        Message_form = New cMessageLib.fMessage(1, Nothing, _
                                              UpdateCnt.ToString & " 件のデータを登録しました。", _
                                              Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form.Dispose()
        Message_form = Nothing

        ReDim oPenddingData(0)
        RecordCnt = oMstCnvProductCdDBIO.getPenddingCnvProduct(oPenddingData, Tran).ToString
        If RecordCnt = 0 Then
            oConn = Nothing
            oTool = Nothing

            oMstConfigDBIO = Nothing
            oMstChannelDBIO = Nothing
            oSupplierDBIO = Nothing
            oMstProductDBIO = Nothing
            oMstCnvProductCdDBIO = Nothing
            oDataRequestDBIO = Nothing

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub P_SEARCH_PROD_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_SEARCH_PROD_B.Click
        Dim RecordCnt As Long
        Dim i As Long

        '明細行クリア
        For i = 0 To P_PRODUCT_MST_V.Rows.Count - 1
            P_PRODUCT_MST_V.Rows.Clear()
        Next i

        'メッセージウィンドウ表示
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(0, "データ読込み中", "しばらくお待ちください", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '商品在庫データの読み込みバッファ初期化
        oProduct = Nothing

        '商品在庫データの読み込み
        RecordCnt = oMstProductDBIO.getProduct( _
                        oProduct, _
                        P_JANCODE_T.Text, _
                        P_PRODUCT_CODE_T.Text, _
                        P_PRODUCT_NAME_T.Text, _
                        Nothing, _
                        P_SUPPLIER_L.Text, _
                        P_MAKER_NAME_T.Text, _
                        Nothing, _
                        Nothing, _
                        Nothing, _
                        Tran)

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
            P_PRODUCT_MST_V_SEARCH_RESULT_SET(False)

        End If
        'メッセージウィンドウのクリア
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLOSE_B.Click
        Dim RecordCnt As Long = 0D
        Dim i As Integer

        '未登録変更データの確認
        For i = 0 To CNV_PRODUCT_CD_MST_V.Rows.Count - 1
            If CNV_PRODUCT_CD_MST_V(0, i).Value = "" Then
                RecordCnt += 1
            End If
        Next
        If RecordCnt > 0 Then
            Dim Message_form As cMessageLib.fMessage
            Message_form = New cMessageLib.fMessage(2, "未登録の変更データがあります。", _
                                    "終了してもよろしいですか？", _
                                    Nothing, Nothing)
            Message_form.ShowDialog()
            If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
                Message_form.Dispose()
                Message_form = Nothing
                Exit Sub
            End If
            Message_form.Dispose()
            Message_form = Nothing
        End If

        'MsgBox(CNV_PRODUCT_CD_MST_V.SelectedRows(0).Cells(CPCMVColumnType.ProductCode).Value)

        oConn = Nothing
        oTool = Nothing

        oMstConfigDBIO = Nothing
        oMstChannelDBIO = Nothing
        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstCnvProductCdDBIO = Nothing
        oDataRequestDBIO = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class
