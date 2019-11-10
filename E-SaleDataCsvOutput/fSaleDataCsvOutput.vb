Imports System.Reflection
Imports System.Windows.Forms

Public Class fSaleDataCsvOutput
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

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

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
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

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
    Private Sub fYayoiCSVOutput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim staff_form As cStaffEntryLib.fStaffEntry

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

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

        CHANNEL_SET()
    End Sub

    Private Sub START_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles START_B.Click
        Dim csvPath As String

        '入力チェック
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        '保存先のCSVファイルのパス
        csvPath = CSV_PATH_T.Text

        '日次データ出力処理
        TRANDATA_OUTPUT(csvPath)

        '精算データ出力処理
        ADJUSTDATA_OUTPUT(csvPath)

        Dim message_form As New cMessageLib.fMessage(1, _
                               "CSV出力は完了しました。", _
                               csvPath & "を確認して下さい。", _
                               Nothing, Nothing)
        message_form.ShowDialog()
        message_form = Nothing

        INIT_PROC()
    End Sub
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        'サービス担当者コンボ内容設定
        oChannel = Nothing
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, Nothing, oTran)
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
            CHANNEL_NAME_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_NAME_C.SelectedIndex = 0
    End Sub
    Private Sub TRANDATA_OUTPUT(ByVal csvPath As String)
        Dim i As Integer
        Dim oCsvLayout() As cStructureLib.sCsvLayout
        Dim oMstCsvLayoutDBIO As New cMstCsvLayoutDBIO(oConn, oCommand, oDataReader)
        Dim oSoft() As cStructureLib.sSoft
        Dim oMstSoftDBIO As New cMstSoftDBIO(oConn, oCommand, oDataReader)
        Dim oFinTrnFull() As cStructureLib.sViewFinTrnFull
        Dim oViewTrnFullDBIO As New cViewTrnFullDBIO(oConn, oCommand, oDataReader)
        Dim oBumon() As cStructureLib.sViewBumonFull
        Dim oMstBumonDBIO As New cMstBumonDBIO(oConn, oCommand, oDataReader)
        Dim RecordCnt As Integer
        Dim ColumnCnt As Integer
        Dim enc As System.Text.Encoding
        Dim sr As System.IO.StreamWriter
        Dim field As String
        Dim str As String

        ReDim oSoft(0)
        RecordCnt = oMstSoftDBIO.getSoftMst(oSoft, Nothing, "弥生会計", "08 スタンダード", Nothing, Nothing, oTran)

        ReDim oCsvLayout(0)
        ColumnCnt = oMstCsvLayoutDBIO.getCsvLayout(oCsvLayout, oSoft(0).sSoftCode, oTran)

        ReDim oFinTrnFull(0)
        RecordCnt = oViewTrnFullDBIO.getFinTrnFull(oFinTrnFull, oTool.MaskClear(FROM_DATE_T.Text), oTool.MaskClear(TO_DATE_T.Text), oTran)

        'CSVファイルに書き込むときに使うEncoding
        enc = System.Text.Encoding.GetEncoding("Shift_JIS")

        '開く
        sr = New System.IO.StreamWriter(csvPath, False, enc)

        'レコードを書き込む
        For i = 0 To RecordCnt - 1
            If oFinTrnFull(i).sTrnClass = "売上" Or oFinTrnFull(i).sTrnClass = "戻入" Then
                If oFinTrnFull(i).sChannel = CInt(CHANNEL_CODE_T.Text) Then
                    '識別フラグ
                    field = """2000"","
                    '伝票No.
                    field = field & """1"","
                    '決算
                    field = field & """"","
                    '取引日付
                    field = field & """" & oFinTrnFull(i).sDayCloseDate & ""","
                    If oFinTrnFull(i).sTrnClass = "売上" Then   '売上の場合
                        '借方勘定科目
                        field = field & """小口現金"","
                        '借方補助科目
                        field = field & """"","
                        '借方部門
                        field = field & """"","
                        '借方税区分
                        field = field & """対象外"","
                        '借方金額
                        field = field & oFinTrnFull(i).sPrice & ","
                        '借方税金額
                        field = field & ","
                        '貸方勘定科目
                        ReDim oBumon(0)
                        oMstBumonDBIO.getBumonFull(oBumon, oFinTrnFull(i).sBumonCode, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                        str = ""
                        Select Case oBumon(0).sBumonClass
                            Case 1  '物販   
                                field = field & """店舗物販売上"","
                                str = "店舗物販売上"
                            Case 2  'サービス
                                field = field & """店舗サービス売上"","
                                str = "店舗サービス売上"
                        End Select
                        '貸方補助科目
                        Select Case oFinTrnFull(i).sPaymentCode
                            Case 1  '現金払い
                                field = field & """現金売上"","
                                str = str & "(現金)"
                            Case 2  'クレジット払い
                                field = field & """カード売上"","
                                str = str & "(カード)"
                        End Select
                        '貸方部門
                        field = field & """"","
                        '貸方税区分
                        field = field & """" & oBumon(0).sTaxClassName & ""","
                        '貸方金額
                        field = field & oFinTrnFull(i).sPrice & ","
                        '貸方税金額
                        field = field & ","
                    Else        '戻入の場合
                        '借方勘定科目
                        ReDim oBumon(0)
                        oMstBumonDBIO.getBumonFull(oBumon, oFinTrnFull(i).sBumonCode, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                        str = ""
                        Select Case oBumon(0).sBumonClass
                            Case 1  '物販   
                                field = field & """店舗物販売上"","
                                str = "店舗物販売上"
                            Case 2  'サービス
                                field = field & """店舗サービス売上"","
                                str = "店舗サービス売上"
                        End Select
                        '借方補助科目
                        Select Case oFinTrnFull(i).sPaymentCode
                            Case 1  '現金払い
                                field = field & """現金売上"","
                                str = str & "(現金)"
                            Case 2  'クレジット払い
                                field = field & """カード売上"","
                                str = str & "(カード)"
                        End Select
                        '借方部門
                        field = field & """"","
                        '借方税区分
                        field = field & """" & oBumon(0).sTaxClassName & ""","
                        '借方金額
                        field = field & oFinTrnFull(i).sPrice * -1 & ","
                        '借方税金額
                        field = field & ","
                        '貸方勘定科目
                        field = field & """小口現金"","
                        '貸方補助科目
                        field = field & """"","
                        '貸方部門
                        field = field & """"","
                        '貸方税区分
                        field = field & """" & oBumon(0).sTaxClassName & ""","
                        '貸方金額
                        field = field & oFinTrnFull(i).sPrice * -1 & ","
                        '貸方税金額
                        field = field & ","
                    End If
                    '摘要
                    field = field & """" & str & "(" & oFinTrnFull(i).sBumonName & ")"","
                    '番号
                    field = field & """"","
                    '期日
                    field = field & """"","
                    'タイプ
                    field = field & "0,"
                    '生成元
                    field = field & """"","
                    '仕訳メモ
                    field = field & """"","
                    '付箋1
                    field = field & "0,"
                    '付箋2
                    field = field & "0,"
                    '調整
                    field = field & """no"","

                    'フィールドを書き込む
                    sr.Write(field)

                    '改行する
                    sr.Write(ControlChars.Cr + ControlChars.Lf)
                End If
            End If
            PROGRESS_B.Value = CInt(i / RecordCnt * 100)
        Next i

        '閉じる
        sr.Close()

        oSoft = Nothing
        oMstSoftDBIO = Nothing
        oCsvLayout = Nothing
        oMstCsvLayoutDBIO = Nothing
        oFinTrnFull = Nothing
        oViewTrnFullDBIO = Nothing
        oBumon = Nothing
        oMstBumonDBIO = Nothing
    End Sub

    Private Sub ADJUSTDATA_OUTPUT(ByVal csvPath As String)
        Dim i As Integer
        Dim oCsvLayout() As cStructureLib.sCsvLayout
        Dim oMstCsvLayoutDBIO As New cMstCsvLayoutDBIO(oConn, oCommand, oDataReader)
        Dim oAdjust() As cStructureLib.sAdjust
        Dim oDataAdjustDBIO As New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        Dim RecordCnt As Integer
        Dim ColumnCnt As Integer
        Dim enc As System.Text.Encoding
        Dim sr As System.IO.StreamWriter
        Dim field As String

        ReDim oCsvLayout(0)
        ColumnCnt = oMstCsvLayoutDBIO.getCsvLayout(oCsvLayout, 0, oTran)

        ReDim oAdjust(0)
        RecordCnt = oDataAdjustDBIO.getBetweenAdjust(oAdjust, oTool.MaskClear(FROM_DATE_T.Text), oTool.MaskClear(TO_DATE_T.Text), oTran)

        'CSVファイルに書き込むときに使うEncoding
        enc = System.Text.Encoding.GetEncoding("Shift_JIS")

        '開く
        sr = New System.IO.StreamWriter(csvPath, True, enc)

        field = ""

        'レコードを書き込む
        For i = 0 To RecordCnt - 1
            Select Case oAdjust(i).sAdjustClass
                Case "出金"
                    '識別フラグ
                    field = """2000"","
                    '伝票No.
                    field = field & """1"","
                    '決算
                    field = field & """"","
                    '取引日付
                    field = field & """" & oAdjust(i).sAdjustDate & ""","
                    '借方勘定科目
                    field = field & """" & oAdjust(i).sAccountName & ""","
                    '借方補助科目
                    field = field & """" & oAdjust(i).sSubAccountName & ""","
                    '借方部門
                    field = field & """"","
                    '借方税区分
                    field = field & """" & oAdjust(i).sTaxClassName & ""","
                    '借方金額
                    field = field & oAdjust(i).sTotalPrice * -1 & ","
                    '借方税金額
                    field = field & ","
                    '貸方勘定科目
                    field = field & """小口現金"","
                    '貸方補助科目
                    field = field & ","
                    '貸方部門
                    field = field & ","
                    '貸方税区分
                    field = field & """対象外"","
                    '貸方金額
                    field = field & oAdjust(i).sTotalPrice * -1 & ","
                    '貸方税金額
                    field = field & ","
                    '摘要
                    field = field & """" & oAdjust(i).sAccountName & "-" & oAdjust(i).sSubAccountName & ""","
                Case "入金"
                    '識別フラグ
                    field = """2000"","
                    '伝票No.
                    field = field & """1"","
                    '決算
                    field = field & """"","
                    '取引日付
                    field = field & """" & oAdjust(i).sAdjustDate & ""","
                    '借方勘定科目
                    field = field & """小口現金"","
                    '借方補助科目
                    field = field & """"","
                    '借方部門
                    field = field & """"","
                    '借方税区分
                    field = field & """対象外"","
                    '借方金額
                    field = field & oAdjust(i).sTotalPrice & ","
                    '借方税金額
                    field = field & ","
                    '貸方勘定科目
                    field = field & """現金"","
                    '貸方補助科目
                    field = field & """"","
                    '貸方部門
                    field = field & """"","
                    '貸方税区分
                    field = field & """対象外"","
                    '貸方金額
                    field = field & oAdjust(i).sTotalPrice & ","
                    '貸方税金額
                    field = field & ","
                    '摘要
                    field = field & """現金振替"","
            End Select
            '番号
            field = field & """"","
            '期日
            field = field & """"","
            'タイプ
            field = field & "0,"
            '生成元
            field = field & """"","
            '仕訳メモ
            field = field & """"","
            '付箋1
            field = field & "0,"
            '付箋2
            field = field & "0,"
            '調整
            field = field & """no"","

            'フィールドを書き込む
            sr.Write(field)

            '改行する
            sr.Write(ControlChars.Cr + ControlChars.Lf)

            PROGRESS_B.Value = CInt(i / RecordCnt * 100)
        Next i

        '閉じる
        sr.Close()

        oCsvLayout = Nothing
        oMstCsvLayoutDBIO = Nothing
        oAdjust = Nothing
        oDataAdjustDBIO = Nothing
    End Sub
    Private Sub FIND_PATH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIND_PATH_B.Click
        Dim sPath As String

        sPath = oTool.FileSearch("ファイル選択", "Yayoi_" & String.Format("{0:yyyyMMdd}", Now) & ".csv")
        If sPath <> "" Then
            CSV_PATH_T.Text = sPath.ToString
        End If

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConf = Nothing
        oConn = Nothing
        oCommand = Nothing
        oDataReader = Nothing
        Me.Dispose()

    End Sub
    Private Sub INIT_PROC()
        FROM_DATE_T.Text = ""
        TO_DATE_T.Text = ""
        CSV_PATH_T.Text = ""
        PROGRESS_B.Value = 0

        FROM_DATE_T.Focus()
    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim message_form As cMessageLib.fMessage

        If oTool.MaskClear(FROM_DATE_T.Text) = Nothing Then
            message_form = New cMessageLib.fMessage(1, "。", _
                                      "出力対象締日Fromを入力して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            FROM_DATE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If oTool.MaskClear(TO_DATE_T.Text) = Nothing Then
            message_form = New cMessageLib.fMessage(1, "。", _
                                      "出力対象締日Toを入力して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            TO_DATE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If CSV_PATH_T.Text = "" Then
            message_form = New cMessageLib.fMessage(1, Nothing, _
                                      "CSVの出力先を指定して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            CSV_PATH_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If CDate(oTool.MaskClear(FROM_DATE_T.Text)) > CDate(oTool.MaskClear(TO_DATE_T.Text)) Then
            message_form = New cMessageLib.fMessage(1, "出力対象締日が不正です。", _
                                      "From～Toを確認して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            FROM_DATE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        INPUT_CHECK = True

    End Function

    Private Sub CHANNEL_NAME_C_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHANNEL_NAME_C.SelectedIndexChanged
        If CHANNEL_NAME_C.SelectedIndex <> -1 Then
            oMstChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_NAME_C.Text, Nothing, oTran)
            CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        End If

    End Sub
End Class
