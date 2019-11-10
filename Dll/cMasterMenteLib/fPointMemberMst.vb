Public Class fPointMemberMst

    Private ConArry() As System.Windows.Forms.CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPostCode() As cStructureLib.sPostCode
    Private oCity() As cStructureLib.sCity
    Private oMstPostCodeDBIO As cMstPostCodeDBIO

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private oPointData() As cStructureLib.sPoint
    Private oDataPointDBIO As cDataPointDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oMstBumonDBIO As cMstBumonDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private PointMember_CODE As String
    Private UPDATE_FLG As String                '契約期間更新フラグ

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------

    '2016.06.29 K.Oikawa s
    '課題表No109 Transactionを呼び元に応じて変更する

    Private MODE As Integer



    Sub New()
        Dim DB_Path As String
        Dim StrPath As String

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く
        DB_Path = oTool.RegistryRead("File1")
        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        STAFF_CODE = Nothing
        STAFF_NAME = Nothing

        STAFF_CODE_T.Text = Nothing
        STAFF_NAME_T.Text = Nothing

        MODE = 0

    End Sub
    '2016.06.29 K.Oikawa e



    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

        STAFF_CODE_T.Text = iStaffCode
        STAFF_NAME_T.Text = iStaffName

        '2016.06.29 K.Oikawa s
        MODE = 1
        '2016.06.29 K.Oikawa e

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
    Private Sub fPointMemberMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCount As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.fStaffEntry

        PointMember_CODE = ""

        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool

        '環境マスタ読込み
        ReDim oConf(0)

        RecordCount = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCount < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Environment.Exit(1)
            Exit Sub
        End If
        oMstConfigDBIO = Nothing

        'ログイン
        If STAFF_CODE_T.Text = "" Then
            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()

            '担当者画面セット
            STAFF_CODE_T.Text = staff_form.STAFF_CODE_T.Text
            STAFF_NAME_T.Text = staff_form.STAFF_NAME_T.Text
            staff_form = Nothing

            '担当者セット
            STAFF_CODE = STAFF_CODE_T.Text
            STAFF_NAME = STAFF_NAME_T.Text
        End If

        PointMember_CODE = MEMBER_CODE_T.Text

        IVENT_FLG = True

        '表示初期化
        DISP_INIT()

        '都道府県コンボボックスセット
        ADDRESS1_SET()

        SEARCH_PROC()
    End Sub
    Private Sub SEARCH_PROC()
        '会員検索画面表示
        Dim fPointMember_form As New cSelectLib.fPointMemberSearch(oConn, oCommand, oDataReader, oTran)
        fPointMember_form.ShowDialog()

        If fPointMember_form.DialogResult = Windows.Forms.DialogResult.Abort Then
            fPointMember_form = Nothing
            CLOSE_PROC()
            Exit Sub
        End If
        IVENT_FLG = False
        POINTMEMBER_SET(fPointMember_form.POINT_MEMBER_CODE_T.Text)
        IVENT_FLG = True

        fPointMember_form = Nothing

    End Sub
    Private Sub DISP_INIT()
        Dim dt As Date

        '2016.06.28 K.Oikawa s
        '課題表No109 呼び元の画面に応じて処理を変える
        'RETURN_B.Text = "終　了"
        If MODE = 0 Then
            RETURN_B.Text = "終　了"
        Else
            RETURN_B.Text = "戻　る"
        End If
        '2016.06.28 K.Oikawa e

        UPDATE_FLG = 0

        MEMBER_CODE_T.Text = ""
        CHANNEL_NAME_T.Text = ""
        CHANNEL_CODE_T.Text = ""
        MEMBER_NAME_T.Text = ""
        AGE_T.Text = 0
        POST_CODE_T.Text = ""
        ADDRESS1_C.Text = ""
        ADDRESS2_T.Text = ""
        ADDRESS3_T.Text = ""
        SEX_M_R.Checked = True
        TEL_T.Text = ""
        FAX_T.Text = ""
        E_MAIL_T.Text = ""

        UPDATE_COUNT_T.Text = 0

        '保有ポイント
        POINT_COUNT_T.Text = 0

        '入会日
        ENTRY_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        ENTRY_DATE_D.CustomFormat = " "
        ENTRY_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
        ENTRY_DATE_D.Value = Now

        '退会日
        RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        RESIGN_DATE_D.CustomFormat = " "

        '契約開始日
        ST_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        ST_REG_DATE_D.CustomFormat = " "
        ST_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
        ST_REG_DATE_D.Value = Now

        '契約満了日
        END_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        END_REG_DATE_D.CustomFormat = " "
        dt = ST_REG_DATE_D.Value
        END_REG_DATE_D.Value = dt.AddMonths(oConf(0).sPointEnableMonth)
        END_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", END_REG_DATE_D.Value)

        '生年月日
        BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        BIRTHDAY_D.CustomFormat = " "

    End Sub
    Private Sub ADDRESS1_SET()
        Dim RecordCount As Long
        Dim i As Long

        oMstPostCodeDBIO = New cMstPostCodeDBIO(oConn, oCommand, oDataReader)
        RecordCount = oMstPostCodeDBIO.getCity(oCity, oTran)

        '再描画中止
        ADDRESS1_C.BeginUpdate()

        'コンボボックスへの県名セット
        For i = 0 To RecordCount - 1
            ADDRESS1_C.Items.Add(oCity(i).sCityName)
        Next

        '再描画再開
        ADDRESS1_C.EndUpdate()

        oMstPostCodeDBIO = Nothing
    End Sub

    Private Sub POINTMEMBER_SET(ByVal PointMemberCode As String)
        Dim RecordCount As Integer
        Dim i As Integer

        RecordCount = oMstPointMemberDBIO.getPointMember(oPointMember, _
                                       PointMemberCode, _
                                       PointMemberCode, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       oTran)
        MEMBER_CODE_T.Text = oPointMember(0).sPointMemberCode
        RecordCount = oChannelDBIO.getChannelMst(oChannel, CInt(oPointMember(0).sPointMemberCode.Substring(3, 1)), Nothing, Nothing, Nothing, oTran)
        CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
        CHANNEL_NAME_T.Text = oChannel(0).sChannelName
        MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName
        BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        POST_CODE_T.Text = oPointMember(0).sPostCode
        ADDRESS1_C.Text = oPointMember(0).sAddress1
        ADDRESS2_T.Text = oPointMember(0).sAddress2
        ADDRESS3_T.Text = oPointMember(0).sAddress3
        TEL_T.Text = oPointMember(0).sTEL
        FAX_T.Text = oPointMember(0).sFAX
        E_MAIL_T.Text = oPointMember(0).sMailAddress
        If oPointMember(0).sSex = "M" Then
            SEX_M_R.Checked = True
            SEX_F_R.Checked = False
        Else
            SEX_M_R.Checked = False
            SEX_F_R.Checked = True
        End If
        If oPointMember(i).sBirthDay <> "" Then
            BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
            If oPointMember(0).sBirthDay <> "0000/00/00" Then
                '課題表No106 生年月日の選択時の動作修正
                '空っぽで登録されている場合はそのまま空っぽ
                BIRTHDAY_D.Value = oPointMember(0).sBirthDay
                BIRTHDAY_D.Text = oPointMember(0).sBirthDay
            Else
                BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
                BIRTHDAY_D.CustomFormat = " "
                '2016.06.30 K.Oikawa s
                '課題表No106 生年月日の選択時の動作修正
                BIRTHDAY_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
                BIRTHDAY_D.Value = Now
                '2016.06.30 K.Oikawa e
            End If
        Else
            BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            BIRTHDAY_D.CustomFormat = " "
        End If

        AGE_T.Text = oPointMember(0).sAge

        '保有ポイント
        POINT_COUNT_T.Text = oDataPointDBIO.getPoint(PointMemberCode, oTran)

        ENTRY_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
        If oPointMember(0).sEntryDate = "0000/00/00" Then
            ENTRY_DATE_D.Value = Now()
        Else
            ENTRY_DATE_D.Value = oPointMember(0).sEntryDate
        End If
        If oPointMember(0).sResignDate <> "" Then
            RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
            If oPointMember(0).sResignDate <> "0000/00/00" Then
                RESIGN_DATE_D.Value = oPointMember(0).sResignDate
                RESIGN_DATE_D.Text = oPointMember(0).sResignDate
            Else
                RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
                RESIGN_DATE_D.CustomFormat = " "
            End If
        Else
            RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            RESIGN_DATE_D.CustomFormat = " "
        End If
        ST_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
        If oPointMember(0).sStartRegistDate = "0000/00/00" Then
            ST_REG_DATE_D.Value = Now()
            ST_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now())
        Else
            ST_REG_DATE_D.Value = oPointMember(0).sStartRegistDate
            ST_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", oPointMember(0).sStartRegistDate)
        End If
        END_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
        If oPointMember(0).sEndRegistDate = "0000/00/00" Then
            END_REG_DATE_D.Value = Now().AddYears(1)
            END_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now().AddYears(1))
        Else
            END_REG_DATE_D.Value = oPointMember(0).sEndRegistDate
            END_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", oPointMember(0).sEndRegistDate)
        End If
        UPDATE_COUNT_T.Text = oPointMember(0).sUpdateCount

        '部門別割引率設定

        MODE_L.Text = "（更新）"
        MODE_L.BackColor = Drawing.Color.Blue

        QUIT_B.Enabled = True

    End Sub

    '************************************
    ' 生年月日から年齢計算
    '(引数）
    '   BirthDay:   生年月日
    '（戻り値）
    '   年齢
    '************************************
    Private Function CAL_AGE(ByVal BirthDay As Date) As Integer
        Dim age As Integer

        '年齢を計算する
        age = Now.Year - BirthDay.Year

        If BirthDay.Month > Now.Month Then
            age = age - 1
        ElseIf BirthDay.Month = Now.Month Then
            If BirthDay.Day > Now.Day Then
                age = age - 1
            End If
        End If


        If age < 0 Then '現在以上入力エラー処理
            CAL_AGE = 0
        End If

        CAL_AGE = age
    End Function
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        If MEMBER_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, Nothing, "会員番号が入力されていません", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            MEMBER_CODE_T.Focus()
            Exit Function
        End If

        If MEMBER_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "会員名称が入力されていません。", _
                                "会員名称を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            MEMBER_NAME_T.Focus()
            Exit Function
        End If

        If POST_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "郵便番号が入力されていません。", _
                                "郵便番号を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            POST_CODE_T.Focus()
            Exit Function
        End If

        If ADDRESS1_C.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "都道府県が入力されていません。", _
                                "都道府県を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS1_C.Focus()
            Exit Function
        End If

        If ADDRESS2_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "市区町村が入力されていません。", _
                                "市区町村を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS2_T.Focus()
            Exit Function
        End If

        If ADDRESS3_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "市区町村以下の住所が入力されていません。", _
                                "市区町村以下の住所を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS3_T.Focus()
            Exit Function
        End If

        If TEL_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "電話番号が入力されていません。", _
                                "電話番号を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            TEL_T.Focus()
            Exit Function
        End If

        INPUT_CHECK = True
    End Function
    'Date Time Picker CloseUp
    Private Sub ENTRY_DATE_D_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles ENTRY_DATE_D.CloseUp
        ENTRY_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    Private Sub RESIGN_DATE_D_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles RESIGN_DATE_D.CloseUp
        RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    Private Sub ST_REG_DATE_D_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles ST_REG_DATE_D.CloseUp
        ST_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    Private Sub END_REG_DATE_D_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles END_REG_DATE_D.CloseUp
        END_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    Private Sub BIRTHDAY_D_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles BIRTHDAY_D.CloseUp
        BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    'Date Time Picker ValuseChanged
    Private Sub ENTRY_DATE_D_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRY_DATE_D.ValueChanged
        ENTRY_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
        ST_REG_DATE_D.Value = ENTRY_DATE_D.Value
    End Sub
    Private Sub RESIGN_DATE_D_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESIGN_DATE_D.ValueChanged
        RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ST_REG_DATE_D_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ST_REG_DATE_D.ValueChanged
        Dim dt As Date

        ST_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short

        dt = ST_REG_DATE_D.Value
        If oConf(0).sPointEnableMonth = 0 Then
            END_REG_DATE_D.Value = "9998/12/31"
        Else
            END_REG_DATE_D.Value = dt.AddYears(1)
        End If
    End Sub
    Private Sub END_REG_DATE_D_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles END_REG_DATE_D.ValueChanged
        END_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
    End Sub
    Private Sub BIRTHDAY_T_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIRTHDAY_D.ValueChanged
        BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Short
        AGE_T.Text = CAL_AGE(BIRTHDAY_D.Value)
    End Sub

    Private Sub MEMBER_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_SEARCH_B.Click
        'If IsNothing(oTran) = False Then
        '    oTran.Rollback()
        'End If
        Dim fPointMember_form As New cSelectLib.fPointMemberSearch(oConn, oCommand, oDataReader, oTran)
        fPointMember_form.ShowDialog()

        IVENT_FLG = False
        POINTMEMBER_SET(fPointMember_form.POINT_MEMBER_CODE_T.Text)
        IVENT_FLG = True

        fPointMember_form.Dispose()
        fPointMember_form = Nothing

    End Sub

    Private Sub BIRTHDAY_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIRTHDAY_CLR_B.Click
        BIRTHDAY_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        BIRTHDAY_D.CustomFormat = " "

    End Sub

    Private Sub ADDDR_SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDDR_SEARCH_B.Click
        Dim strLen As Integer
        Dim RecordCount As Long
        Dim sPostCode As String

        '郵便番号の入力値チェック
        sPostCode = POST_CODE_T.Text
        strLen = sPostCode.Length

        '入力状況チェック
        If POST_CODE_T.Text.Length < 7 Then
            Dim message_form As New cMessageLib.fMessage(1, _
                                              Nothing, _
                                              "郵便番号を確認して下さい", _
                                              Nothing, _
                                              Nothing _
                                              )
            message_form.ShowDialog()
            message_form = Nothing
            POST_CODE_T.Focus()
            Exit Sub
        End If

        'フォーマットチェック
        For i = 0 To strLen - 1
            If Asc(Mid(sPostCode, i + 1, 1)) < 48 Or Asc(Mid(sPostCode, i + 1, 1)) > 57 Then
                Dim message_form As New cMessageLib.fMessage(1, _
                                                  Nothing, _
                                                  "郵便番号は、－なしの半角数字で入力下さい", _
                                                  Nothing, _
                                                  Nothing _
                                                  )
                message_form.ShowDialog()
                message_form = Nothing
                POST_CODE_T.Focus()
                Exit Sub
            End If
        Next i

        '住所読込み
        oMstPostCodeDBIO = New cMstPostCodeDBIO(oConn, oCommand, oDataReader)
        sPostCode = POST_CODE_T.Text
        RecordCount = oMstPostCodeDBIO.getPostCode(oPostCode, sPostCode, 1, oTran)
        If RecordCount = 1 Then
            ADDRESS1_C.Text = oPostCode(0).sAddr1.ToString
            ADDRESS2_T.Text = oPostCode(0).sAddr2.ToString
            ADDRESS3_T.Text = oPostCode(0).sAddr3.ToString
            '2016.09.14 K.Oikawa s
        Else '住所が取得できなかった時
            Dim message_form As New cMessageLib.fMessage(1, _
                                  Nothing, _
                                  "郵便番号を確認して下さい", _
                                  Nothing, _
                                  Nothing _
                                  )
            message_form.ShowDialog()
            message_form = Nothing
            POST_CODE_T.Focus()
            Exit Sub
            '2016.09.14 K.Oikawa e
        End If
        ADDRESS1_C.Text = oPostCode(0).sAddr1.ToString
        ADDRESS2_T.Text = oPostCode(0).sAddr2.ToString
        ADDRESS3_T.Text = oPostCode(0).sAddr3.ToString
        oMstPostCodeDBIO = Nothing

    End Sub

    Private Sub RESIGNDATE_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESIGNDATE_CLR_B.Click
        RESIGN_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        RESIGN_DATE_D.CustomFormat = " "

    End Sub

    Private Sub REG_UPDATE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REG_UPDATE_B.Click
        Dim dt As Date

        dt = ST_REG_DATE_D.Value.AddYears(1)

        ST_REG_DATE_D.Value = dt
        END_REG_DATE_D.Value = dt.AddYears(+1)

        UPDATE_COUNT_T.Text = CInt(UPDATE_COUNT_T.Text) + 1
        UPDATE_FLG = 1

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        Dim ret As Boolean
        Dim message_form As cMessageLib.fMessage

        message_form = New cMessageLib.fMessage(2, _
                 "会員情報を削除します。", _
                 "削除した情報は元に戻せません。", _
                 "削除してよろしいですか？", _
                 Nothing)
        message_form.ShowDialog()
        If message_form.DialogResult = Windows.Forms.DialogResult.No Then
            message_form.Dispose()
            Exit Sub
        End If

        ret = oMstPointMemberDBIO.deletePointMember(MEMBER_CODE_T.Text, oTran)
        If ret = True Then
            If IsNothing(oTran) = False Then
                oTran.Commit()
            End If
            message_form = New cMessageLib.fMessage(1, _
                              Nothing, _
                              "会員情報を削除しました。", _
                              Nothing, Nothing)
        Else
            'oTran.Rollback()
            message_form = New cMessageLib.fMessage(1, _
                             "会員情報の削除に失敗しました。", _
                             "システム管理者に連絡して下さい。", _
                             Nothing, Nothing)
        End If
        message_form.ShowDialog()
        message_form.Dispose()

        '会員検索画面表示
        SEARCH_PROC()


    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage

        '必須項目入力確認
        If INPUT_CHECK() = True Then

            'DB更新
            ReDim oPointMember(0)

            oPointMember(0).sPointMemberCode = MEMBER_CODE_T.Text
            oPointMember(0).sPointMemberName = MEMBER_NAME_T.Text
            oPointMember(0).sPostCode = POST_CODE_T.Text
            oPointMember(0).sAddress1 = ADDRESS1_C.Text
            oPointMember(0).sAddress2 = ADDRESS2_T.Text
            oPointMember(0).sAddress3 = ADDRESS3_T.Text
            oPointMember(0).sTEL = TEL_T.Text
            oPointMember(0).sFAX = FAX_T.Text
            oPointMember(0).sMailAddress = E_MAIL_T.Text

            If SEX_M_R.Checked = True Then
                oPointMember(0).sSex = "M"
            Else
                oPointMember(0).sSex = "F"
            End If
            If BIRTHDAY_D.Text = " " Then
                oPointMember(0).sBirthDay = ""
            Else
                oPointMember(0).sBirthDay = String.Format("{0:yyyy/MM/dd}", CDate(BIRTHDAY_D.Value))
            End If
            oPointMember(0).sAge = CInt(AGE_T.Text)
            oPointMember(0).sEntryDate = String.Format("{0:yyyy/MM/dd}", CDate(ENTRY_DATE_D.Value))
            If RESIGN_DATE_D.Text = " " Then
                oPointMember(0).sResignDate = ""
            Else
                oPointMember(0).sResignDate = String.Format("{0:yyyy/MM/dd}", CDate(RESIGN_DATE_D.Value))
            End If
            oPointMember(0).sStartRegistDate = String.Format("{0:yyyy/MM/dd}", CDate(ST_REG_DATE_D.Value))
            If END_REG_DATE_D.Text = " " Then
                oPointMember(0).sEndRegistDate = "9998/12/31"
            Else
                oPointMember(0).sEndRegistDate = String.Format("{0:yyyy/MM/dd}", CDate(END_REG_DATE_D.Value))
            End If
            oPointMember(0).sUpdateCount = CInt(UPDATE_COUNT_T.Text)
            oPointMember(0).sMemo = MEMO_T.Text
            ret = oMstPointMemberDBIO.updatePointMember(oPointMember(0), MEMBER_CODE_T.Text, oTran)
            If ret = True Then
                '2016.06.30 K.Oikawa s
                '課題表No109 ここではTransactionが終わっている場合がある
                'If IsNothing(oTran) = False Then
                If IsNothing(oTran) = False And MODE = 0 Then
                    '2016.06.30 K.Oikawa e

                    oTran.Commit()
                    oTran = Nothing
                End If
                Message_form = New cMessageLib.fMessage(1, _
                          Nothing, _
                          "登録が完了しました。", _
                          Nothing, Nothing _
                          )
                Message_form.ShowDialog()
                Message_form = Nothing

            Else
                Message_form = New cMessageLib.fMessage(1, _
                                                          "登録処理が失敗しました。", _
                                                          "システム管理者に連絡して下さい。", _
                                                          Nothing, Nothing _
                                                          )
                Message_form.ShowDialog()
                Message_form = Nothing

            End If

            '2016.06.29 K.Oikawa s
            '課題表No109
            If MODE = 0 Then
                IVENT_FLG = False
                '表示初期化
                DISP_INIT()
                IVENT_FLG = True
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
            '2016.06.29 K.Oikawa e

            '会員検索画面表示
            SEARCH_PROC()

            IVENT_FLG = True
        End If

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        'TODO:課代表.No109 Transactionが有効でないのにrollbackしている
        '2016.06.22 K.Oikawa s
        'SUB_MODEをチェック?

        '2016.06.22 K.Oikawa e
        If IsNothing(oTran) = False Then
            oTran.Rollback()
        End If

        CLOSE_PROC()

    End Sub
    Private Sub CLOSE_PROC()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub END_REG_CLR_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles END_REG_CLR_B.Click
        END_REG_DATE_D.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        END_REG_DATE_D.CustomFormat = " "

    End Sub

    Private Sub POINT_ADD_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_ADD_B.Click
        Dim form_PointCal = New fPointADD(oConn, oCommand, oDataReader, MEMBER_CODE_T.Text, STAFF_CODE, STAFF_NAME, oTran)
        form_PointCal.ShowDialog()

        POINT_COUNT_T.Text = form_PointCal.AFTER_POINT_CNT_T.Text

        form_PointCal.Dispose()
        form_PointCal = Nothing
    End Sub
End Class
