Imports System.IO
Public Class fStockMst

    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oMstProductDBIO As cMstProductDBIO

    Private oMstStockDBIO As cMstStockDBIO
    Private oStock() As cStructureLib.sStock      '登録用

    Private oInvCheck() As cStructureLib.sInvCheck
    Private oDataInvCheckDBIO As cDataInvCheckDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private STOCK_UPDATE_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim DB_Path As String
        Dim StrPath As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstStockDBIO = New cMstStockDBIO(oConn, oCommand, oDataReader)
        oDataInvCheckDBIO = New cDataInvCheckDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

    End Sub
    Private Sub fMstProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

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
        STAFF_CODE = staff_form.STAFF_CODE_T.Text
        STAFF_NAME = staff_form.STAFF_NAME_T.Text
        staff_form = Nothing

        'オプションラベルセット
        OPTION_SET()

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()

        JANCODE_T.Text = ""

        '商品情報初期化
        PRODUCT_CODE_T.Text = ""
        JAN_CODE_T.Text = ""
        PLU_CODE_T.Text = ""
        CNT_T.Text = 1
        PRODUCT_NAME_T.Text = ""
        PRODUCT_S_NAME_T.Text = ""
        MAKER_NAME_T.Text = ""
        SYUBETU_1_R.Checked = True
        OPTION1_T.Text = ""
        OPTION2_T.Text = ""
        OPTION3_T.Text = ""
        OPTION4_T.Text = ""
        OPTION5_T.Text = ""
        STOPSALE_C.Checked = False
        PRICE_T.Text = ""
        MIN_STOCK_T.Text = ""

        STOCK_CNT_T.Text = ""

        STOCK_UPDATE_FLG = False
        JANCODE_T.Focus()
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

    '***********************************************
    '更新対象の商品マスタ情報を画面にセット
    '***********************************************
    Private Sub UPDATE_PRODUCT_SET()
        Dim RecordCount As Long

        '商品情報セット
        RecordCount = oMstProductDBIO.getProduct( _
                                        oProduct, _
                                        Nothing, _
                                        PRODUCT_CODE_T.Text, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        oTran _
                                    )
        PRODUCT_CODE_T.Text = oProduct(0).sProductCode
        JANCODE_T.Text = oProduct(0).sJANCode
        JAN_CODE_T.Text = oProduct(0).sJANCode
        PLU_CODE_T.Text = oProduct(0).sPLUCode
        PRODUCT_NAME_T.Text = oProduct(0).sProductName
        PRODUCT_S_NAME_T.Text = oProduct(0).sProductShortName
        If oProduct(0).sProductClass = 1 Then
            SYUBETU_1_R.Checked = True
        Else
            SYUBETU_2_R.Checked = True
        End If
        MAKER_NAME_T.Text = oProduct(0).sMakerName
        OPTION1_T.Text = oProduct(0).sOption1
        OPTION2_T.Text = oProduct(0).sOption2
        OPTION3_T.Text = oProduct(0).sOption3
        OPTION4_T.Text = oProduct(0).sOption4
        OPTION5_T.Text = oProduct(0).sOption5
        MEMO_T.Text = oProduct(0).sMemo
        If oProduct(0).sStopSaleFlg = True Then
            STOPSALE_C.Checked = True
        Else
            STOPSALE_C.Checked = False
        End If
        If oProduct(0).sStopSupplieFlg = True Then
            SUPPLIESTOP_C.Checked = True
        Else
            SUPPLIESTOP_C.Checked = False
        End If
        PRICE_T.Text = oProduct(0).sListPrice
        MIN_STOCK_T.Text = oProduct(0).sMinStock

        '在庫情報セット
        oMstStockDBIO.getStock(oStock, oProduct(0).sProductCode, oTran)
        STOCK_CNT_T.Text = oStock(0).sStockCount
    End Sub

    '必須項目入力確認
    Private Function INPUT_CHECK() As Integer
        INPUT_CHECK = 0

        '商品番号
        If PRODUCT_CODE_T.Text = "" Then
            PRODUCT_CODE_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

        'JANコード
        If JAN_CODE_T.Text = "" Then
            JAN_CODE_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

        '商品名称
        If PRODUCT_NAME_T.Text = "" Then
            PRODUCT_NAME_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

        '商品略称
        If PRODUCT_S_NAME_T.Text = "" Then
            PRODUCT_S_NAME_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

        'メーカー名称
        If MAKER_NAME_T.Text = "" Then
            MAKER_NAME_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

        '適正在庫数
        If MIN_STOCK_T.Text = "" Then
            MIN_STOCK_T.Focus()
            INPUT_CHECK = 1
            Exit Function
        End If

    End Function
    '****************
    '在庫マスタ更新
    '****************
    Private Function UPDATE_STOCK() As Long
        Dim ret As Boolean
        Dim RecordCount As Integer
        Dim UpdateCount As Long

        UpdateCount = 0

        '商品コード
        RecordCount = oStock(0).sProductCode = PRODUCT_CODE_T.Text
        '在庫更新
        If STOCK_UPDATE_FLG = True Then
            oStock(0).sStockCount = CInt(STOCK_CNT_T.Text)
        Else
            oStock(0).sStockCount = oStock(0).sStockCount + CInt(CNT_T.Text)
        End If


        ret = oMstStockDBIO.updateStock(oStock, oTran)

        UpdateCount = UpdateCount + 1

        UPDATE_STOCK = UpdateCount
    End Function
    Private Sub WRITE_DATA_SET()

        '商品マスタ情報セット
        'ReDim oProduct(0)
        oProduct(0).sProductCode = PRODUCT_CODE_T.Text
        oProduct(0).sPLUCode = PLU_CODE_T.Text
        oProduct(0).sJANCode = JAN_CODE_T.Text
        If SYUBETU_1_R.Checked = True Then
            oProduct(0).sProductClass = 1
        Else
            oProduct(0).sProductClass = 2
        End If
        oProduct(0).sProductName = PRODUCT_NAME_T.Text
        oProduct(0).sProductShortName = PRODUCT_S_NAME_T.Text
        oProduct(0).sMakerName = MAKER_NAME_T.Text
        oProduct(0).sOption1 = OPTION1_T.Text
        oProduct(0).sOption2 = OPTION2_T.Text
        oProduct(0).sOption3 = OPTION3_T.Text
        oProduct(0).sOption4 = OPTION4_T.Text
        oProduct(0).sOption5 = OPTION5_T.Text
        oProduct(0).sMemo = MEMO_T.Text
        oProduct(0).sStopSaleFlg = STOPSALE_C.Checked
        If PRICE_T.Text = "" Then
            oProduct(0).sListPrice = 0
        Else
            oProduct(0).sListPrice = CLng(PRICE_T.Text)
        End If
        oProduct(0).sMinStock = CLng(MIN_STOCK_T.Text)
        oProduct(0).sPLUCode = PLU_CODE_T.Text

    End Sub
    Private Function WRITE_PROC() As Boolean
        Dim ret As Long
        Dim Tran As System.Data.OleDb.OleDbTransaction

        '---トランザクション開始
        Tran = Nothing
        Tran = oConn.BeginTransaction

        '---------------- 更新 -----------------
        '商品マスタ更新
        ret = oMstProductDBIO.updateProductMst(oProduct, Tran)
        If ret = False Then
            Tran.Rollback()
            WRITE_PROC = False
            Exit Function
        End If

        '---トランザクション終了
        Tran.Commit()

        WRITE_PROC = True

    End Function
    Private Sub OPTION_SET()
        If oConf(0).sOptionName1 <> "" Then
            OPTION1_L.Text = oConf(0).sOptionName1 & "："
        End If
        If oConf(0).sOptionName2 <> "" Then
            OPTION2_L.Text = oConf(0).sOptionName2 & "："
        End If
        If oConf(0).sOptionName3 <> "" Then
            OPTION3_L.Text = oConf(0).sOptionName3 & "："
        End If
        If oConf(0).sOptionName4 <> "" Then
            OPTION4_L.Text = oConf(0).sOptionName4 & "："
        End If
        If oConf(0).sOptionName5 <> "" Then
            OPTION5_L.Text = oConf(0).sOptionName5 & "："
        End If
    End Sub

    Private Sub JANCODE_T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JANCODE_T.GotFocus
        Me.JANCODE_T.SelectAll()
    End Sub

    Private Sub JANCODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JANCODE_T.LostFocus
        Dim recCount As Long
        Dim ProductCode As String
        Dim SelectJAN_form As cSelectLib.fSelectJAN

        If (JANCODE_T.Text <> "") Then
            recCount = oMstProductDBIO.getProduct( _
                                        oProduct, _
                                        JANCODE_T.Text, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        oTran _
                                    )

            '登録情報の取得
            Select Case recCount
                Case 0 '該当JANコードが存在しなかった場合
                    Dim message_form As New cMessageLib.fMessage(1, _
                                                      "該当のJANコードが登録されていません", _
                                                      "商品登録を行って下さい", _
                                                      Nothing, Nothing)
                    JANCODE_T.Text = ""
                    message_form.ShowDialog()
                    message_form = Nothing
                    Beep()
                    JANCODE_T.Focus()
                    Exit Sub
                Case 1 '該当JANコードが1レコード存在した場合
                Case Else '該当JANコードが複数存在した場合
                    '重複JANコード商品の選択画面表示
                    JANCODE_T.Enabled = False

                    SelectJAN_form = New cSelectLib.fSelectJAN(oConn, _
                                                         oCommand, _
                                                         oDataReader, _
                                                         Nothing, _
                                                         JANCODE_T.Text, _
                                                         oConf, _
                                                         oTran)
                    SelectJAN_form.ShowDialog()

                    '選択画面で選択された商品コードを取得
                    ProductCode = SelectJAN_form.PRODUCT_CODE_T.Text

                    '選択画面クラスの破棄
                    SelectJAN_form.Dispose()
                    SelectJAN_form = Nothing

                    '商品情報読込み
                    recCount = oMstProductDBIO.getProduct( _
                                                    oProduct, _
                                                    Nothing, _
                                                    ProductCode, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                   oTran _
                                                )
                    JANCODE_T.Enabled = True

            End Select
            PRODUCT_CODE_T.Text = oProduct(0).sProductCode
            PLU_CODE_T.Text = oProduct(0).sPLUCode
            JAN_CODE_T.Text = oProduct(0).sJANCode
            PRODUCT_NAME_T.Text = oProduct(0).sProductName
            PRODUCT_S_NAME_T.Text = oProduct(0).sProductShortName
            If oProduct(0).sProductClass = 1 Then
                SYUBETU_1_R.Checked = True
            Else
                SYUBETU_2_R.Checked = True
            End If
            MAKER_NAME_T.Text = oProduct(0).sMakerName
            OPTION1_T.Text = oProduct(0).sOption1
            OPTION2_T.Text = oProduct(0).sOption2
            OPTION3_T.Text = oProduct(0).sOption3
            OPTION4_T.Text = oProduct(0).sOption4
            OPTION5_T.Text = oProduct(0).sOption5
            MEMO_T.Text = oProduct(0).sMemo
            If oProduct(0).sStopSaleFlg = True Then
                STOPSALE_C.Checked = True
            Else
                STOPSALE_C.Checked = False
            End If
            PRICE_T.Text = oProduct(0).sListPrice
            MIN_STOCK_T.Text = oProduct(0).sMinStock

            '在庫情報セット
            oMstStockDBIO.getStock(oStock, oProduct(0).sProductCode, oTran)
            STOCK_CNT_T.Text = oStock(0).sStockCount
        End If

    End Sub

    Private Sub STOCK_CNT_T_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_CNT_T.TextChanged
        STOCK_UPDATE_FLG = True
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '商品検索ウィンドウ表示
        Dim product_search_form As cSelectLib.fProductSearch

        product_search_form = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, 1, oTran)
        product_search_form.ShowDialog()
        If product_search_form.DialogResult = Windows.Forms.DialogResult.OK Then
            PRODUCT_CODE_T.Text = product_search_form.S_PRODUCT_CODE_T.Text
            UPDATE_PRODUCT_SET()
            PRODUCT_CODE_T.ReadOnly = True
        End If
        Application.DoEvents()
        product_search_form = Nothing

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim ret As Boolean

        '必須入力確認
        ret = INPUT_CHECK()
        If ret <> 0 Then
            Dim Message_form As cMessageLib.fMessage
            Message_form = New cMessageLib.fMessage(1, "必須項目が入力されていません。", _
                                                "必須項目を入力後、再度「登録」して下さい", _
                                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If

        '登録データのバッファセット
        WRITE_DATA_SET()

        '在庫更新
        UPDATE_STOCK()

        'DB登録処理
        ret = WRITE_PROC()
        If ret = True Then
            INIT_PROC()
        End If

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        oConn = Nothing
        'oStaffDBIO = Nothing
        oSupplierDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub
End Class
