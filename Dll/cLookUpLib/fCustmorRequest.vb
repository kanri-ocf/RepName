Public Class fCustmorRequest
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oMstChannelDBIO As cMstChannelDBIO
    Private oChannel() As cStructureLib.sChannel

    Private oRequestDataDBIO As cDataRequestDBIO
    Private oRequestData() As cStructureLib.sRequestData

    Private oRequestSubDataDBIO As cDataRequestSubDBIO
    Private oRequestSubData() As cStructureLib.sRequestSubData

    Private oShipmentDataDBIO As cDataShipmentDBIO
    Private oShipmentData() As cStructureLib.sShipmentData

    Private oShipmentSubDataDBIO As cDataShipmentSubDBIO
    Private oShipmentSubData() As cStructureLib.sShipmentSubData

    Private oMstPaymentDBIO As cMstPaymentDBIO
    Private oPayment() As cStructureLib.sPayment

    Private oMstChannelPaymentDBIO As cMstChannelPaymentDBIO
    Private oChannelPayment() As cStructureLib.sChannelPayment

    Private oMstStaffDBIO As cMstStaffDBIO
    Private oStaff() As cStructureLib.sStaff

    Private oConf() As cStructureLib.sConfig

    Private oDeliveryClass() As cStructureLib.sDeliveryClass
    Private oMstDeliveryClassDBIO As cMstDeliveryClassDBIO

    Private oTool As cTool

    Private REQUEST_CODE As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oRequestCode As String
    Private oPhoneNumber As String

    Private from_RequestSearch As cSelectLib.fRequestSearch

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        'oCustmorRequestDBIO = New cViewRequestDataFullDBIO(oConn, oCommand, oDataReader)

        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        oRequestDataDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oRequestSubDataDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        oShipmentDataDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oShipmentSubDataDBIO = New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)

        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)
        oMstChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)

        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oPhoneNumber = ""

    End Sub
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iPhoneNumber As String, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        Dim StrPath As String
        Dim DB_Path As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        oRequestDataDBIO = New cDataRequestDBIO(oConn, oCommand, oDataReader)
        oRequestSubDataDBIO = New cDataRequestSubDBIO(oConn, oCommand, oDataReader)

        oShipmentDataDBIO = New cDataShipmentDBIO(oConn, oCommand, oDataReader)
        oShipmentSubDataDBIO = New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)

        oMstDeliveryClassDBIO = New cMstDeliveryClassDBIO(oConn, oCommand, oDataReader)

        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)
        oMstChannelPaymentDBIO = New cMstChannelPaymentDBIO(oConn, oCommand, oDataReader)

        oMstStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oPhoneNumber = iPhoneNumber
        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName
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

    Private Sub fCustmorRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer
        Dim oMstConfigDBIO As New cMstConfigDBIO(oConn, oCommand, oDataReader)

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        oMstConfigDBIO = Nothing
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        End If

        'スタッフ入力ウィンドウ表示
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

        '担当者画面セット
        STAFF_CODE_T.Text = STAFF_CODE
        STAFF_NAME_T.Text = STAFF_NAME

        '注文情報データグリッド生成
        GRIDVIEW_CREATE_REQ()

        '出荷情報データグリッド生成
        GRIDVIEW_CREATE_SHIP()

        '画面初期化
        INIT_PROC()

        'CTI接続の場合
        If oPhoneNumber <> "" Then
            RecordCnt = oRequestDataDBIO.getRequest2(oRequestData, Nothing, oPhoneNumber, Nothing, Nothing, oTran)
            If RecordCnt = 0 Then
                Me.Dispose()
            End If
            oRequestCode = oRequestData(0).sRequestCode
        Else
            '受注情報選択画面表示
            from_RequestSearch = New cSelectLib.fRequestSearch(oConn, oCommand, oDataReader, oRequestCode, oTran)
            While oRequestCode = ""
                from_RequestSearch.ShowDialog()
                oRequestCode = from_RequestSearch.S_REQUESTNUMBER
            End While
            from_RequestSearch = Nothing
        End If

        RESULT_SET()

        TABPAGE.SelectedIndex = 0
    End Sub
    '-----------------------------------------< 内部関数 >-------------------------------------------

    '******************************
    '     DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************
    Sub GRIDVIEW_CREATE_REQ()
        'レコードセレクタを非表示に設定
        REQ_MEISAI_V.RowHeadersVisible = False

        REQ_MEISAI_V.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        'JANコード
        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "JANコード"
        REQ_MEISAI_V.Columns.Add(column0)
        column0.Width = 100
        column0.ReadOnly = False
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column0.Name = "JANコード"

        '商品コード
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        REQ_MEISAI_V.Columns.Add(column1)
        column1.Width = 80
        column1.ReadOnly = True
        column1.Name = "商品コード"

        '商品名称
        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        REQ_MEISAI_V.Columns.Add(column2)
        column2.Width = 280
        column2.ReadOnly = True
        column2.Name = "商品名称"

        'オプション
        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        REQ_MEISAI_V.Columns.Add(column3)
        column3.Width = 280
        column3.ReadOnly = True
        column3.Name = "オプション"

        '注文単価
        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "注文単価"
        REQ_MEISAI_V.Columns.Add(column4)
        column4.Width = 70
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "注文単価"

        '注文数
        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "注文数"
        REQ_MEISAI_V.Columns.Add(column5)
        column5.Width = 50
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "注文数"

        '注文金額
        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "注文金額"
        REQ_MEISAI_V.Columns.Add(column6)
        column6.Width = 80
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.Name = "注文金額"

        '背景色を白に設定
        REQ_MEISAI_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        REQ_MEISAI_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Sub GRIDVIEW_CREATE_SHIP()
        'レコードセレクタを非表示に設定
        S_MEISAI_V.RowHeadersVisible = False

        S_MEISAI_V.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        'JANコード
        Dim column0 As New DataGridViewTextBoxColumn
        column0.HeaderText = "JANコード"
        S_MEISAI_V.Columns.Add(column0)
        column0.Width = 100
        column0.ReadOnly = False
        column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        column0.Name = "JANコード"

        '商品コード
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        S_MEISAI_V.Columns.Add(column1)
        column1.Width = 80
        column1.ReadOnly = True
        column1.Name = "商品コード"

        '商品名称
        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        S_MEISAI_V.Columns.Add(column2)
        column2.Width = 250
        column2.ReadOnly = True
        column2.Name = "商品名称"

        'オプション
        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        S_MEISAI_V.Columns.Add(column3)
        column3.Width = 250
        column3.ReadOnly = True
        column3.Name = "オプション"

        '注文単価
        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "注文単価"
        S_MEISAI_V.Columns.Add(column4)
        column4.Width = 70
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column4.Name = "注文単価"

        '注文数
        Dim column5 As New DataGridViewTextBoxColumn
        column5.HeaderText = "注文数"
        S_MEISAI_V.Columns.Add(column5)
        column5.Width = 50
        column5.ReadOnly = True
        column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column5.Name = "注文数"

        '注文金額
        Dim column6 As New DataGridViewTextBoxColumn
        column6.HeaderText = "注文金額"
        S_MEISAI_V.Columns.Add(column6)
        column6.Width = 80
        column6.DefaultCellStyle.Format = "c"
        column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column6.Name = "注文金額"

        '出荷数
        Dim column7 As New DataGridViewTextBoxColumn
        column7.HeaderText = "出荷数"
        S_MEISAI_V.Columns.Add(column7)
        column7.Width = 50
        column7.ReadOnly = True
        column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        column7.Name = "出荷数"

        '背景色を白に設定
        S_MEISAI_V.RowsDefaultCellStyle.BackColor = Color.White

        '奇数行の背景色を薄黄色に設定
        S_MEISAI_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '注文情報を画面にセット
    '***********************************************
    Private Function RESULT_SET() As Long

        REQUEST_SET()
        MEISAI_V_SET()
        SHIPMENT_SET()
        S_MEISAI_V_SET()

    End Function
    '***********************************************
    '注文情報を画面にセット
    '***********************************************
    Private Function REQUEST_SET() As Long
        Dim RecordCnt As Integer

        '受注明細情報の読み込み
        ReDim oRequestData(0)
        RecordCnt = oRequestDataDBIO.getRequest2(oRequestData, oRequestCode, Nothing, Nothing, Nothing, oTran)
        ReDim oShipmentData(0)
        RecordCnt = oShipmentDataDBIO.getShipment(oShipmentData, oRequestCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        oMstChannelDBIO.getChannelMst(oChannel, oRequestData(0).sChannelCode, Nothing, Nothing, Nothing, oTran)

        CHANNEL_NAME_T.Text = oChannel(0).sChannelName
        REQUEST_CODE_T.Text = oRequestData(0).sRequestCode
        OR_REQUEST_CODE_T.Text = oRequestData(0).sORRequestCode
        REQ_DATE_T.Text = oRequestData(0).sRequestDate
        REQ_STAFF_CODE_T.Text = oRequestData(0).sStaffCode
        oMstStaffDBIO.getStaff(oStaff, oRequestData(0).sStaffCode, Nothing, Nothing, Nothing, oTran)
        REQ_STAFF_NAME_T.Text = oStaff(0).sStaffName

        '受注情報の画面セット
        BILL_CORP_NAME_T.Text = oRequestData(0).sBillCorpName
        BILL_BRANCH_T.Text = oRequestData(0).sBillDivName
        BILL_NAME_T.Text = oRequestData(0).sBill1stName & "　" & oRequestData(0).sBill2ndName
        BILL_POSTCODE_1_T.Text = oRequestData(0).sBillPostCode1
        BILL_POSTCODE_2_T.Text = oRequestData(0).sBillPostCode2
        BILL_COUNTRY_T.Text = oRequestData(0).sBillCountry
        BILL_DIVNAME_T.Text = oRequestData(0).sBillKanaState
        BILL_CITY_T.Text = oRequestData(0).sBillCity
        BILL_ADDR_1_T.Text = oRequestData(0).sBillAdder1
        BILL_ADDR_2_T.Text = oRequestData(0).sBillAdder2
        BILL_TEL_T.Text = oRequestData(0).sBillTel
        BILL_MAIL_T.Text = oRequestData(0).sMailAdderss
        BILL_MEMO_T.Text = oRequestData(0).sComment

        SHIP_CORP_NAME_T.Text = oRequestData(0).sShipCorpName
        SHIP_BRANCH_T.Text = oRequestData(0).sShipDivName
        SHIP_NAME_T.Text = oRequestData(0).sShip1stName & "　" & oRequestData(0).sShip2ndName
        SHIP_POSTCODE_1_T.Text = oRequestData(0).sShipPostCode1
        SHIP_POSTCODE_2_T.Text = oRequestData(0).sShipPostCode2
        SHIP_COUNTRY_T.Text = oRequestData(0).sShipCountry
        SHIP_DIVNAME_T.Text = oRequestData(0).sShipState
        SHIP_CITY_T.Text = oRequestData(0).sShipCity
        SHIP_ADDR_1_T.Text = oRequestData(0).sShipAdder1
        SHIP_ADDR_2_T.Text = oRequestData(0).sShipAdder2
        SHIP_TEL_T.Text = oRequestData(0).sShipTel
        SHIP_MEMO_T.Text = oRequestData(0).sComment

        oMstChannelPaymentDBIO.getChannelPaymentMst(oChannelPayment, oRequestData(0).sChannelPaymentCode, Nothing, Nothing, Nothing, oTran)
        PAYMENT_NAME_T.Text = oChannelPayment(0).sChannelPaymentName
        DEV_REQ_DATE_T.Text = oRequestData(0).sShipRequestDate
        DEV_REQ_TIME_T.Text = oRequestData(0).sShipRequestTime
        DEV_TYPE_T.Text = oRequestData(0).sShipCorp

        If oRequestData(0).sGiftRequest = "" Or oRequestData(0).sGiftRequest = "0" Then
            GIFT_C.Checked = False
        Else
            GIFT_C.Checked = True
        End If

        If oRequestData(0).sNoshiType = "" Then
            NOSHI_C.Checked = False
        Else
            NOSHI_C.Checked = True
            NOSHI_MSG_T.Text = oRequestData(0).sNoshiName
        End If
    End Function
    '***********************************************
    '注文情報明細を画面にセット
    '***********************************************
    Private Function MEISAI_V_SET() As Long
        Dim i As Integer
        Dim j As Integer
        Dim RecordCnt As Integer
        Dim oName() As String
        Dim oValue() As String
        Dim str As String

        '受注明細情報（FULL)データの読み込み
        RecordCnt = oRequestSubDataDBIO.getSubRequest(oRequestSubData, oRequestCode, Nothing, oTran)

        '表示設定
        Me.SuspendLayout()

        For i = 0 To RecordCnt - 1

            'オプション値の整形
            oName = oRequestSubData(i).sOptionName.Split(":")
            oValue = oRequestSubData(i).sOptionValue.Split(":")
            str = ""
            For j = 0 To oName.Length - 1
                If oName(j) <> "" Then
                    str = str & oName(j) & "=" & oValue(j) & " "
                End If
            Next


            REQ_MEISAI_V.Rows.Add( _
                        oRequestSubData(i).sJANCode, _
                        oRequestSubData(i).sProductCode, _
                        oRequestSubData(i).sProductName, _
                        str, _
                        oTool.BeforeToAfterTax(oRequestSubData(i).sUnitPrice, oConf(0).sTax, oConf(0).sFracProc), _
                        oRequestSubData(i).sCount, _
                        oRequestSubData(i).sPrice _
                )
        Next i
        Me.ResumeLayout()

        MEISAI_V_SET = i
    End Function
    '***********************************************
    '出荷情報を画面にセット
    '***********************************************
    Private Function SHIPMENT_SET() As Long

        '出荷情報の画面セット
        SHIPMENT_CODE_T.Text = oShipmentData(0).sShipCode

        SHIP_DATE_T.Text = oShipmentData(0).sShipDate

        SHIP_STAFF_CODE_T.Text = oShipmentData(0).sShipStaffCode
        oMstStaffDBIO.getStaff(oStaff, oShipmentData(0).sShipStaffCode, Nothing, Nothing, Nothing, oTran)
        SHIP_STAFF_NAME_T.Text = oStaff(0).sStaffName

        S_NAME_T.Text = oShipmentData(0).sFirstName & "　" & oShipmentData(0).sLastName
        S_POSTCODE_1_T.Text = oShipmentData(0).sPostalCode.Substring(0, 3)
        S_POSTCODE_2_T.Text = oShipmentData(0).sPostalCode.Substring(oShipmentData(0).sPostalCode.Length - 4, 4)
        S_ADDR_1_T.Text = oShipmentData(0).sAddress1
        S_ADDR_2_T.Text = oShipmentData(0).sAddress2
        S_ADDR_2_T.Text = oShipmentData(0).sAddress3
        S_TEL_T.Text = oShipmentData(0).sTel
        S_MEMO_T.Text = oShipmentData(0).sShipMemo
        Select Case oShipmentData(0).sFinishFlg
            Case 0
                FINISH_C.Checked = False
            Case 1
                FINISH_C.Checked = True
        End Select

        oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, oShipmentData(0).sShipCorpCode, Nothing, Nothing, Nothing, oTran)
        S_SHIPCORP_T.Text = oDeliveryClass(0).sClassName
        S_SHIPCORP_CODE_T.Text = oShipmentData(0).sShipCorpCode
        S_OFFICE_CODE_T.Text = oDeliveryClass(0).sClassCode

        oMstDeliveryClassDBIO.getDeliveryClassMst(oDeliveryClass, oShipmentData(0).sShipRequestTimeClass, Nothing, Nothing, Nothing, oTran)
        S_SHIPCLASS_T.Text = oRequestData(0).sShipCorp
        S_DATE_T.Text = oRequestData(0).sRequestDate
        S_TIMEZONE_T.Text = oDeliveryClass(0).sClassName
        S_POSTAGE_T.Text = oTool.BeforeToAfterTax(oShipmentData(0).sShippingCharge, oConf(0).sTax, oConf(0).sFracProc)
        S_FEE_T.Text = oTool.BeforeToAfterTax(oShipmentData(0).sPaymentCharge, oConf(0).sTax, oConf(0).sFracProc)
        S_DLIVERYNUMBER_T.Text = oShipmentData(0).sDeliveryNumber
        S_DAIBIKI_T.Text = oShipmentData(0).sDaibikiPrice

    End Function
    '***********************************************
    '出荷情報明細を画面にセット
    '***********************************************
    Private Function S_MEISAI_V_SET() As Long
        Dim i As Integer
        Dim j As Integer
        Dim RecordCnt As Integer
        Dim oName() As String
        Dim oValue() As String
        Dim str As String

        '出荷明細情報データの読み込み
        RecordCnt = oShipmentSubDataDBIO.getSubShipment(oShipmentSubData, oRequestCode, Nothing, Nothing, oTran)

        '表示設定

        Me.SuspendLayout()

        For i = 0 To RecordCnt - 1

            'オプション値の整形
            oName = oShipmentSubData(i).sOptionName.Split(" ")
            oValue = oShipmentSubData(i).sOptionValue.Split(" ")
            str = ""
            For j = 0 To oName.Length - 1
                If oName(j) <> "" Then
                    str = str & oName(j) & "=" & oValue(j) & " "
                End If
            Next j

            S_MEISAI_V.Rows.Add( _
                        oShipmentSubData(i).sJANCode, _
                        oShipmentSubData(i).sProductCode, _
                        oShipmentSubData(i).sProductName, _
                        str, _
                        oShipmentSubData(i).sUnitPrice, _
                        oRequestSubData(i).sCount, _
                        oShipmentSubData(i).sPrice, _
                        oShipmentSubData(i).sCount _
                )
        Next i
        Me.ResumeLayout()

        S_MEISAI_V_SET = i

    End Function
    Private Sub INIT_PROC()
        Dim i As Integer
        oRequestCode = ""

        REQUEST_CODE_T.Text = ""
        OR_REQUEST_CODE_T.Text = ""
        REQ_DATE_T.Text = ""
        SHIP_DATE_T.Text = ""
        REQ_STAFF_CODE_T.Text = ""
        SHIP_STAFF_CODE_T.Text = ""
        CHANNEL_NAME_T.Text = ""

        '受注情報クリア
        BILL_CORP_NAME_T.Text = ""
        BILL_BRANCH_T.Text = ""
        BILL_NAME_T.Text = ""
        BILL_POSTCODE_1_T.Text = ""
        BILL_POSTCODE_2_T.Text = ""
        BILL_COUNTRY_T.Text = ""
        BILL_DIVNAME_T.Text = ""
        BILL_CITY_T.Text = ""
        BILL_ADDR_1_T.Text = ""
        BILL_ADDR_2_T.Text = ""
        BILL_TEL_T.Text = ""
        BILL_MAIL_T.Text = ""
        BILL_MEMO_T.Text = ""

        SHIP_CORP_NAME_T.Text = ""
        SHIP_BRANCH_T.Text = ""
        SHIP_NAME_T.Text = ""
        SHIP_POSTCODE_1_T.Text = ""
        SHIP_POSTCODE_2_T.Text = ""
        SHIP_COUNTRY_T.Text = ""
        SHIP_DIVNAME_T.Text = ""
        SHIP_CITY_T.Text = ""
        SHIP_ADDR_1_T.Text = ""
        SHIP_ADDR_2_T.Text = ""
        SHIP_TEL_T.Text = ""
        SHIP_MEMO_T.Text = ""

        PAYMENT_NAME_T.Text = ""
        CARD_PAY_TYPE_T.Text = ""

        DEV_TYPE_T.Text = ""
        DEV_REQ_DATE_T.Text = ""
        DEV_REQ_TIME_T.Text = ""

        GIFT_C.Checked = False
        NOSHI_C.Checked = False
        NOSHI_MSG_T.Text = ""

        '明細行クリア
        For i = 0 To REQ_MEISAI_V.Rows.Count - 1
            REQ_MEISAI_V.Rows.Clear()
        Next i

        '出荷情報クリア
        SHIPMENT_CODE_T.Text = ""
        S_NAME_T.Text = ""
        S_POSTCODE_1_T.Text = ""
        S_POSTCODE_2_T.Text = ""
        S_ADDR_1_T.Text = ""
        S_ADDR_2_T.Text = ""
        S_ADDR_2_T.Text = ""
        S_TEL_T.Text = ""
        S_MEMO_T.Text = ""

        S_SHIPCORP_T.Text = ""
        S_SHIPCORP_CODE_T.Text = ""
        S_OFFICE_CODE_T.Text = ""
        S_SHIPCLASS_T.Text = ""
        S_TIMEZONE_T.Text = ""
        S_POSTAGE_T.Text = ""
        S_FEE_T.Text = ""
        S_DLIVERYNUMBER_T.Text = ""
        S_DAIBIKI_T.Text = ""

        FINISH_C.Checked = False

        '明細行クリア
        For i = 0 To S_MEISAI_V.Rows.Count - 1
            S_MEISAI_V.Rows.Clear()
        Next i
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click

        CLOSE_PROC()
        Me.Dispose()

    End Sub
    Private Sub CLOSE_PROC()
        oConf = Nothing
        oConn = Nothing
        oCommand = Nothing
        oDataReader = Nothing

        oMstChannelDBIO = Nothing
        oRequestDataDBIO = Nothing
        oRequestSubDataDBIO = Nothing
        oShipmentDataDBIO = Nothing
        oShipmentSubDataDBIO = Nothing
        oMstDeliveryClassDBIO = Nothing
        oMstPaymentDBIO = Nothing
        oMstChannelPaymentDBIO = Nothing
        oMstStaffDBIO = Nothing

        oTool = Nothing
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        from_RequestSearch = New cSelectLib.fRequestSearch(oConn, oCommand, oDataReader, oRequestCode, oTran)
        from_RequestSearch.ShowDialog()
        oRequestCode = from_RequestSearch.S_REQUESTNUMBER
        from_RequestSearch = Nothing

        INIT_PROC()
        RESULT_SET()

    End Sub
End Class
