Public Class fDeliveryCSVOutput
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    'Private oStaff() As sStaff
    'Private oStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oSoft() As cStructureLib.sSoft
    Private oMstSoftDBIO As cMstSoftDBIO

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

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstSoftDBIO = New cMstSoftDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

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
    Private Sub fInCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim staff_form As cStaffEntryLib.fStaffEntry
        Dim shipment_form As cSelectLib.fShipmentSearch
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
            Message_form = Nothing
            Application.DoEvents()
            Application.Exit()
        End If

        If STAFF_CODE = Nothing Then
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

        TYPE_SET()

        shipment_form = New cSelectLib.fShipmentSearch(oConn, oCommand, oDataReader, Nothing, STAFF_CODE, STAFF_NAME, oTran)
        shipment_form.ShowDialog()
        COUNT_L.Text = shipment_form.SEL_COUNT_T.Text
        CSV_PATH_T.Text = oConf(0).sTempFilePath & "\sender.csv"
        Application.DoEvents()
        shipment_form = Nothing


    End Sub

    Private Sub TYPE_SET()

        Dim RecordCnt As Integer
        Dim i As Long

        '連携ソフト
        ReDim oSoft(0)
        RecordCnt = oMstSoftDBIO.getSoftMst(oSoft, Nothing, Nothing, Nothing, 2, Nothing, oTran)

        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "連携ソフトマスタが登録されていません", _
                                                "連携ソフトマスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "連携ソフトマスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            TYPE_C.Items.Add(oSoft(i).sSoftName & " -- " & oSoft(i).sVersion)
        Next
        TYPE_C.SelectedIndex = 0

    End Sub
    Private Sub START_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles START_B.Click
        Dim ret As Boolean

        '入力チェック
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        Select Case CInt(TYPE_T.Text)
            Case 2  '佐川急便 e秘伝Ⅱ
                ret = SAGAWA_eHIDEN2()
        End Select

        Dim message_form As New cMessageLib.fMessage(1, _
                                  "CSV出力は完了しました。", _
                                   "出力先は下記のパスを確認して下さい。", _
                                  Nothing, CSV_PATH_T.Text)
        message_form.ShowDialog()
        message_form = Nothing

        'プログレスバークリア
        PROGRESS_B.Value = 0
        Application.DoEvents()

    End Sub
    Private Function SAGAWA_eHIDEN2()
        Dim i As Integer
        Dim oCsvLayout() As cStructureLib.sCsvLayout
        Dim oMstCsvLayoutDBIO As New cMstCsvLayoutDBIO(oConn, oCommand, oDataReader)
        Dim oShipmentFull() As cStructureLib.sViewShipmentDataFull
        Dim oViewShipmentFullDBIO As New cViewShipmentDataFullDBIO(oConn, oCommand, oDataReader)
        Dim oDataShipmentSubDBIO As New cDataShipmentSubDBIO(oConn, oCommand, oDataReader)
        Dim RecordCnt As Integer
        Dim ColumnCnt As Integer
        Dim csvPath As String
        Dim enc As System.Text.Encoding
        Dim sr As System.IO.StreamWriter
        Dim field As String

        ReDim oCsvLayout(0)
        ColumnCnt = oMstCsvLayoutDBIO.getCsvLayout(oCsvLayout, CInt(TYPE_T.Text), oTran)

        ReDim oShipmentFull(0)
        RecordCnt = oViewShipmentFullDBIO.getShipmentFull(oShipmentFull, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, True, oTran)
        '保存先のCSVファイルのパス
        csvPath = CSV_PATH_T.Text

        'CSVファイルに書き込むときに使うEncoding
        enc = System.Text.Encoding.GetEncoding("Shift_JIS")

        '開く
        sr = New System.IO.StreamWriter(csvPath, False, enc)

        'レコードを書き込む
        For i = 0 To RecordCnt - 1

            'プログレスバー表示
            PROGRESS_B.Value = CInt((i + 1) / RecordCnt) * 100
            Application.DoEvents()

            '住所録コード
            field = """"","
            'お届け先電話番号
            field = field & """" & StrConv(oShipmentFull(i).sTel.Trim, VbStrConv.Narrow) & ""","
            'お届け先郵便番号
            field = field & """" & StrConv(oShipmentFull(i).sPostalCode.Trim, VbStrConv.Narrow) & ""","
            'お届け先住所1
            field = field & """" & StrConv(oShipmentFull(i).sAddress1.TrimEnd, VbStrConv.Wide) & ""","
            'お届け先住所2
            field = field & """" & StrConv(oShipmentFull(i).sAddress2.TrimEnd, VbStrConv.Wide) & ""","
            'お届け先住所3
            field = field & """" & StrConv(oShipmentFull(i).sAddress3.TrimEnd, VbStrConv.Wide) & ""","
            'お届け先名称1
            field = field & """" & StrConv(oShipmentFull(i).sFirstName.Trim & "　" & oShipmentFull(i).sLastName.Trim, VbStrConv.Wide) & ""","
            'お届け先名称2
            field = field & """"","
            'お客様管理ナンバー
            field = field & """"","
            'お客様コード
            field = field & """"","
            '荷送人の部署・担当者
            field = field & """"","
            '荷送人電話番号
            field = field & """"","
            '依頼主電話番号
            field = field & """"","
            '依頼主郵便番号
            field = field & """"","
            '依頼主住所1
            field = field & """"","
            '依頼主住所2
            field = field & """"","
            '依頼主名称1
            field = field & """"","
            '依頼主名称2
            field = field & """"","
            '荷姿コード
            field = field & """001"","
            '-------------品名---------------
            '品名1
            field = field & """"","
            '品名2
            field = field & """"","
            '品名3
            field = field & """"","
            '品名4
            field = field & """"","
            '品名5
            field = field & """" & oShipmentFull(i).sShipCode & ""","
            '出荷個数
            field = field & """1"","
            '便種（スピード）
            field = field & """" & oShipmentFull(i).sDeliveryClassSpeed.Trim & ""","
            '便種（商品）
            field = field & """" & oShipmentFull(i).sDeliveryClassProduct.Trim & ""","
            '配達日
            field = field & """" & oShipmentFull(i).sShipRequestDate.Replace("/", "").Trim & ""","
            '配達指定時間帯
            field = field & """" & oShipmentFull(i).sShipRequestTimeClass & ""","
            '配達指定時間
            field = field & """" & oShipmentFull(i).sShipRequestTime.Replace(":", "").Trim & ""","
            '代引金額
            field = field & """" & oShipmentFull(i).sDaibikiPrice & ""","
            '消費税
            field = field & """" & oTool.AfterToTax(oShipmentFull(i).sDaibikiPrice, oConf(0).sTax, oConf(0).sFracProc) & ""","
            '保険金額
            field = field & "0,"
            '指定シール1
            Select Case oShipmentFull(i).sDeliveryClassProduct
                Case "002"
                    field = field & """001"","
                Case "003"
                    field = field & """002"","
                Case Else
                    field = field & """"","
            End Select
            '指定シール2
            field = field & """"","
            '指定シール3
            field = field & """"","
            '営業店止め
            field = field & """0"","
            'SRC区分
            field = field & """0"","
            '営業店コード
            field = field & """" & oShipmentFull(i).sShipOfficeCode & ""","
            '元着区分
            field = field & """" & oShipmentFull(i).sMotoCyakuClass & ""","

            'フィールドを書き込む
            sr.Write(field)

            '改行する
            sr.Write(ControlChars.Cr + ControlChars.Lf)

        Next i

        '閉じる
        sr.Close()

        oCsvLayout = Nothing
        oMstCsvLayoutDBIO = Nothing
        oShipmentFull = Nothing
        oViewShipmentFullDBIO = Nothing
        oDataShipmentSubDBIO = Nothing

        SAGAWA_eHIDEN2 = True
    End Function
    Private Function INPUT_CHECK() As Boolean
        Dim message_form As cMessageLib.fMessage
        Dim str As String

        If TYPE_C.Text = "" Then
            message_form = New cMessageLib.fMessage(1, "。", _
                                      "出力データタイプを指定して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            TYPE_C.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If CSV_PATH_T.Text = "" Then
            message_form = New cMessageLib.fMessage(1, "", _
                                      "CSV出力先を指定して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            CSV_PATH_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        str = CSV_PATH_T.Text.ToString.Substring(0, CSV_PATH_T.Text.ToString.LastIndexOf("\")) & "\"
        If System.IO.Directory.Exists(str) = False Then
            message_form = New cMessageLib.fMessage(1, "CSV出力先パスが存在しません。", _
                                      "CSV出力先のフォルダを確認して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            CSV_PATH_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        INPUT_CHECK = True
    End Function

    Private Sub FIND_PATH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_PATH_B.Click
        Dim sPath As String
        Dim message_form As cMessageLib.fMessage
        Dim str As String

        sPath = oTool.FileSearch("ファイル選択", Nothing)
        If sPath <> "" Then
            Str = sPath.Substring(0, sPath.LastIndexOf("\")) & "\"
            If System.IO.Directory.Exists(Str) = False Then
                message_form = New cMessageLib.fMessage(1, "CSV出力先パスが存在しません。", _
                                          "CSV出力先のフォルダを確認して下さい。", _
                                          Nothing, Nothing)
                message_form.ShowDialog()
                message_form = Nothing
                CSV_PATH_T.Focus()
                Exit Sub
            End If
            CSV_PATH_T.Text = sPath
        End If
        START_B.Focus()
    End Sub

    Private Sub TYPE_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TYPE_C.SelectedIndexChanged
        Dim str() As String

        str = TYPE_C.Text.ToString.Split(" -- ")
        If str(2) = "" Then
            str(2) = Nothing
        End If
        ReDim oSoft(0)
        oMstSoftDBIO.getSoftMst(oSoft, Nothing, str(0), str(2), Nothing, Nothing, oTran)
        TYPE_C.Text = oSoft(0).sSoftName
        TYPE_T.Text = oSoft(0).sSoftCode
        CORP_CODE_T.Text = oSoft(0).sCorpCode
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim shipment_form As cSelectLib.fShipmentSearch
        Dim pCorpCode As Integer

        If CORP_CODE_T.Text = "" Then
            pCorpCode = Nothing
        Else
            pCorpCode = CInt(CORP_CODE_T.Text)
        End If
        shipment_form = New cSelectLib.fShipmentSearch(oConn, oCommand, oDataReader, pCorpCode, STAFF_CODE, STAFF_NAME, oTran)
        shipment_form.ShowDialog()
        COUNT_L.Text = shipment_form.SEL_COUNT_T.Text
        Application.DoEvents()
        shipment_form = Nothing

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Me.Dispose()
    End Sub
End Class
