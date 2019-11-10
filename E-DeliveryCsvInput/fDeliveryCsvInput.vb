Public Class fDeliveryCSVInput
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

        shipment_form = New cSelectLib.fShipmentSearch(oConn, oCommand, oDataReader, Nothing, STAFF_CODE, STAFF_NAME, oTran)
        shipment_form.ShowDialog()
        Application.DoEvents()
        shipment_form = Nothing

    End Sub

    Private Sub START_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles START_B.Click
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

        '入力チェック
        If INPUT_CHECK() = False Then
            oCsvLayout = Nothing
            oMstCsvLayoutDBIO = Nothing
            oShipmentFull = Nothing
            oViewShipmentFullDBIO = Nothing
            oDataShipmentSubDBIO = Nothing
            Exit Sub
        End If

        ReDim oCsvLayout(0)
        ColumnCnt = oMstCsvLayoutDBIO.getCsvLayout(oCsvLayout, "e秘伝Ⅱ", oTran)

        ReDim oShipmentFull(0)
        RecordCnt = oViewShipmentFullDBIO.getShipmentFull(oShipmentFull, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        '保存先のCSVファイルのパス
        csvPath = CSV_PATH_T.Text

        'CSVファイルに書き込むときに使うEncoding
        enc = System.Text.Encoding.GetEncoding("Shift_JIS")

        '開く
        sr = New System.IO.StreamWriter(csvPath, False, enc)

        'レコードを書き込む
        For i = 0 To RecordCnt - 1
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
            field = field & """"","
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
            field = field & """" & oShipmentFull(i).sTotalPrice & ""","
            '消費税
            field = field & """" & oShipmentFull(i).sTaxTotal & ""","
            '決済種別
            field = field & """0"","
            '保険金額
            field = field & "0,"
            '保険金額
            field = field & "0,"
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

        Dim message_form As New cMessageLib.fMessage(1, _
                                  "CSV出力は完了しました。", _
                                  csvPath & "を確認して下さい。", _
                                  Nothing, Nothing)
        message_form.ShowDialog()
        message_form = Nothing

        oCsvLayout = Nothing
        oMstCsvLayoutDBIO = Nothing

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim message_form As cMessageLib.fMessage

        If TYPE_C.SelectedIndex <= 0 Then
            message_form = New cMessageLib.fMessage(1, "。", _
                                      "出力データタイプを指定して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            TYPE_C.Focus()
            INPUT_CHECK = False
            Exit Function
        End If
        If CSV_PATH_T.Text = Nothing Then
            message_form = New cMessageLib.fMessage(1, "。", _
                                      "CSV出力先を指定して下さい。", _
                                      Nothing, Nothing)
            message_form.ShowDialog()
            message_form = Nothing
            CSV_PATH_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function

End Class
