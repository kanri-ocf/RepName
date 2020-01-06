Public Class fMemberMst

    Private ConArry() As Windows.Forms.CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPostCode() As cStructureLib.sPostCode
    Private oCity() As cStructureLib.sCity
    Private oMstPostCodeDBIO As cMstPostCodeDBIO

    Private oMember() As cStructureLib.sMember
    Private oMstMemberDBIO As cMstMemberDBIO

    Private oService() As cStructureLib.sService
    Private oViewServiceFull() As cStructureLib.sViewServiceFull
    Private oMstServiceDBIO As cMstServiceDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oMstBumonDBIO As cMstBumonDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private MODE As Integer
    Private MEMBER_CODE As String
    Private UPDATE_FLG As String                '契約期間更新フラグ

    Private IVENT_FLG As Boolean



    Private oTran As OleDb.OleDbTransaction

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

        MODE = 0

    End Sub
    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByVal iMemberCode As String,
            ByRef iTran As OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        If iMemberCode <> Nothing Then
            MEMBER_CODE = iMemberCode
        Else
            MEMBER_CODE = ""
        End If

        MODE = 1

    End Sub

    '******************************************************************
    'タイトルバーのないウィンドウに3Dの境界線を持たせる
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property
    Private Sub fMemberMst_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim RecordCount As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.fStaffEntry

        oMstMemberDBIO = New cMstMemberDBIO(oConn, oCommand, oDataReader)
        oMstServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
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

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Environment.Exit(1)
            Exit Sub
        End If
        oMstConfigDBIO = Nothing

        'ログイン
        If STAFF_CODE_T.Text = "" Then
            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            Windows.Forms.Application.DoEvents()

            '担当者画面セット
            STAFF_CODE_T.Text = staff_form.STAFF_CODE_T.Text
            STAFF_NAME_T.Text = staff_form.STAFF_NAME_T.Text
            staff_form = Nothing
        End If

        '担当者セット
        STAFF_CODE = STAFF_CODE_T.Text
        STAFF_NAME = STAFF_NAME_T.Text

        MEMBER_CODE = MEMBER_CODE_T.Text

        'レート情報グリッド生成
        GRIDVIEW_CREATE()

        IVENT_FLG = True

        '都道府県コンボボックスセット
        ADDRESS1_SET()

        '販売チャネルコンボボックスセット
        CHANNEL_SET()

        'サービスコンボボックスセット
        SERVICE_SET()

        '表示初期化
        DISP_INIT()

        If MEMBER_CODE <> "" Then
            MEMBER_SET(MEMBER_CODE)
        End If
    End Sub
    '******************************
    '     Windows.Forms.DataGridViewの設定
    '   ヘッダーおよび列幅設定
    '******************************

    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        RATE_V.RowHeadersVisible = False
        RATE_V.AllowUserToAddRows = False

        'グリッドのヘッダーを作成します。
        Dim column1 As New Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "部門名称"
        column1.ReadOnly = True
        RATE_V.Columns.Add(column1)
        column1.Width = 240

        Dim column2 As New Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "割引率"
        column2.ReadOnly = True
        RATE_V.Columns.Add(column2)
        column2.Width = 123
        column2.DefaultCellStyle.Format = "#.0"
        column2.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

        '背景色を白に設定
        RATE_V.RowsDefaultCellStyle.BackColor = Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        RATE_V.AlternatingRowsDefaultCellStyle.BackColor = Drawing.Color.LemonChiffon

    End Sub


    Private Sub DISP_INIT()
        Dim RecordCount As Long
        Dim dt As Date

        If MODE = 0 Then
            RETURN_B.Text = "終　了"
        Else
            RETURN_B.Text = "戻　る"
        End If

        UPDATE_FLG = 0

        MEMBER_CODE_T.Text = ""
        SERVICE_NAME_C.Text = ""
        CHANNEL_C.Text = ""
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

        ATTR1_DOG_R.Checked = True
        ATTR2_T.Text = ""
        ATTR5_T.Text = ""

        SUBMEMBER_NAME_1_T.Text = ""
        SUBAGE_1.Text = 0
        SUBSEX_M_1_R.Checked = True

        'Date Time Pickerの初期値空白設定
        '入会日
        ENTRY_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ENTRY_DATE_D.CustomFormat = " "
        ENTRY_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
        ENTRY_DATE_D.Value = Now

        '退会日
        RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        RESIGN_DATE_D.CustomFormat = " "

        '契約開始日
        ST_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ST_REG_DATE_D.CustomFormat = " "
        ST_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
        ST_REG_DATE_D.Value = Now

        '契約満了日
        '2019,10,15 A.Komita 初期値を無期限としての数値にする為変数を追加 From
        Dim dtBirth As DateTime = DateTime.Parse(DateTime.Now)
        '2019,10,15 A.Komita 追加 To

        '2019,10,15 A.Komita 修正 Start-------------------------------------
        END_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        END_REG_DATE_D.CustomFormat = " "
        END_REG_DATE_D.Text = String.Format(dtBirth, "{0:yyyy/MM/dd}")
        END_REG_DATE_D.Value = dtBirth.AddYears(999)
        '2019,10,15 A.Komita 修正 End---------------------------------------

        '生年月日
        BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        BIRTHDAY_D.CustomFormat = " "
        '2016.06.22 K.Oikawa s
        '課題表　クリックしても反映されない場合がある
        BIRTHDAY_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
        '2016.06.22 K.Oikawa e

        '狂犬病予防接種日
        ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ATTR3_D.CustomFormat = " "

        'ワクチン接種日
        ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ATTR4_D.CustomFormat = " "

        '補助会員１－生年月日
        SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        SUBBIRTHDAY_1_D.CustomFormat = " "

        '会員写真
        MEMBER_PIC.Image = Nothing

        'レート情報セット
        RecordCount = oMstBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCount > 0 Then
            For i = 0 To RATE_V.Rows.Count
                RATE_V.Rows.Clear()
            Next i

            '表示設定
            For i = 0 To oBumon.Length - 1
                RATE_V.Rows.Add(
                        oBumon(i).sBumonName,
                        0.0
                )
            Next i
        End If

        MODE_L.Text = "（新規）"
        MODE_L.BackColor = Drawing.Color.Red

        QUIT_B.Enabled = False


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
    Private Sub CHANNEL_SET()
        Dim RecordCount As Long
        Dim i As Long

        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, True, oTran)
        '再描画中止
        CHANNEL_C.BeginUpdate()

        'コンボボックスへのチャネル名セット
        'CHANNEL_C.Items.Add("")
        CHANNEL_C.Items.Clear()
        For i = 0 To RecordCount - 1
            CHANNEL_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_C.SelectedIndex = 0

        '再描画再開
        CHANNEL_C.EndUpdate()

    End Sub

    Private Sub SERVICE_SET()
        Dim RecordCount As Long
        Dim i As Long

        ReDim oService(0)
        RecordCount = oMstServiceDBIO.getService(oService, Nothing, Nothing, 1, True, Nothing, Nothing, Nothing, Nothing, oTran)

        '再描画中止
        SERVICE_NAME_C.BeginUpdate()

        'コンボボックスへのチャネル名セット
        'SERVICE_NAME_C.Items.Add("")
        SERVICE_NAME_C.Items.Clear()
        For i = 0 To RecordCount - 1
            SERVICE_NAME_C.Items.Add(oService(i).sServiceName)
        Next
        oService = Nothing

        SERVICE_NAME_C.SelectedIndex = 0

        '再描画再開
        SERVICE_NAME_C.EndUpdate()

    End Sub

    Private Sub MEMBER_SET(ByVal MemberCode As String)
        Dim RecordCount As Integer
        Dim i As Integer
        Dim sPath As String
        Dim tPath As String

        MODE_L.Text = "（更新）"
        MODE_L.BackColor = Drawing.Color.Blue

        IVENT_FLG = False

        RecordCount = oMstMemberDBIO.getMember(oMember,
                                          MemberCode,
                                          "",
                                          "",
                                          Nothing,
                                          oTran)
        MEMBER_CODE_T.Text = oMember(0).sMemberCode
        RecordCount = oChannelDBIO.getChannelMst(oChannel, CInt(oMember(0).sMemberCode.Substring(3, 1)), Nothing, Nothing, Nothing, oTran)

        oMstServiceDBIO.getService(oService, oMember(0).sServiceCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        SERVICE_CODE_T.Text = oService(0).sServiceCode
        'SERVICE_NAME_C.Text = oService(0).sServiceName

        CHANNEL_C.Text = oChannel(0).sChannelName
        MEMBER_NAME_T.Text = oMember(0).sMemberName
        POST_CODE_T.Text = oMember(0).sPostCode
        ADDRESS1_C.Text = oMember(0).sAddress1
        ADDRESS2_T.Text = oMember(0).sAddress2
        ADDRESS3_T.Text = oMember(0).sAddress3
        TEL_T.Text = oMember(0).sTEL
        FAX_T.Text = oMember(0).sFAX
        E_MAIL_T.Text = oMember(0).sMailAddress
        If oMember(0).sSex = "M" Then
            SEX_M_R.Checked = True
            SEX_F_R.Checked = False
        Else
            SEX_M_R.Checked = False
            SEX_F_R.Checked = True
        End If
        If oMember(i).sBirthday <> "" Then
            BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Short
            BIRTHDAY_D.Value = oMember(0).sBirthday
            BIRTHDAY_D.Text = oMember(0).sBirthday
        Else
            BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Custom
            BIRTHDAY_D.CustomFormat = " "
        End If

        AGE_T.Text = oMember(0).sAge
        ENTRY_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
        ENTRY_DATE_D.Value = oMember(0).sEntryDate
        If oMember(0).sResignDate <> "" Then
            RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
            RESIGN_DATE_D.Value = oMember(0).sResignDate
            RESIGN_DATE_D.Text = oMember(0).sResignDate
        Else
            RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
            RESIGN_DATE_D.CustomFormat = " "
        End If
        ST_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
        ST_REG_DATE_D.Value = oMember(0).sStartRegistDate
        ST_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", oMember(0).sStartRegistDate)
        END_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
        END_REG_DATE_D.Value = oMember(0).sEndRegistDate
        END_REG_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", oMember(0).sEndRegistDate)

        UPDATE_COUNT_T.Text = oMember(0).sUpdateCount

        SUBMEMBER_NAME_1_T.Text = oMember(0).sSubMemberName
        If oMember(0).sSubMemberBirthDay <> "" Then
            SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Short
            SUBBIRTHDAY_1_D.Value = oMember(0).sSubMemberBirthDay
            SUBBIRTHDAY_1_D.Text = oMember(0).sSubMemberBirthDay
        Else
            SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Custom
            SUBBIRTHDAY_1_D.CustomFormat = " "
        End If
        SUBAGE_1.Text = oMember(0).sSubMemberAge
        If oMember(0).sSubMemberSex = "M" Then
            SUBSEX_M_1_R.Checked = True
            SUBSEX_M_1_R.Checked = False
        Else
            SUBSEX_F_1_R.Checked = False
            SUBSEX_F_1_R.Checked = True
        End If

        Select Case oMember(0).sAttr1
            Case "犬"
                ATTR1_DOG_R.Checked = True
            Case "猫"
                ATTR1_CAT_R.Checked = True
            Case "その他"
                ATTR1_OTHER_R.Checked = True
        End Select
        ATTR2_T.Text = oMember(0).sAttr2
        If oMember(0).sAttr3 <> "" Then
            ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Short
            ATTR3_D.Value = oMember(0).sAttr3
            ATTR3_D.Text = oMember(0).sAttr3
        Else
            ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Custom
            ATTR3_D.CustomFormat = " "
        End If
        If oMember(0).sAttr4 <> "" Then
            ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Short
            ATTR4_D.Value = oMember(0).sAttr4
            ATTR4_D.Text = oMember(0).sAttr4
        Else
            ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Custom
            ATTR4_D.CustomFormat = " "
        End If
        ATTR5_T.Text = oMember(0).sAttr5

        sPath = Windows.Forms.Application.StartupPath & "\Temp\" & oMember(0).sMemberCode & ".jpg"
        tPath = Windows.Forms.Application.StartupPath & "\MemberPhoto\" & oMember(0).sMemberCode & ".jpg"

        'Tempのメンバー写真を削除
        IO.File.Delete(sPath)

        If IO.File.Exists(tPath) Then
            ' FileStream を開く
            Dim hStream As New IO.FileStream(tPath, IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            MEMBER_PIC.Image = Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        Else
            MEMBER_PIC.Image = Nothing
        End If

        RATE_SET()

        IVENT_FLG = True

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
            Message_form = New cMessageLib.fMessage(1, Nothing, "会員番号が入力されていません",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            MEMBER_CODE_T.Focus()
            Exit Function
        End If

        If CHANNEL_C.Text = "" Or CHANNEL_C.Text = Nothing Then
            Message_form = New cMessageLib.fMessage(1, "チャネルが選択されていません。",
                                "チャネルを指定して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            CHANNEL_C.Focus()
            Exit Function
        End If

        If SERVICE_NAME_C.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "会員種別が選択されていません。",
                                "会員種別を指定して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            SERVICE_NAME_C.Focus()
            Exit Function
        End If

        If MEMBER_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "会員名称が入力されていません。",
                                "会員名称を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            MEMBER_NAME_T.Focus()
            Exit Function
        End If

        If AGE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "年齢が入力されていません。",
                                "年齢を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            AGE_T.Focus()
            Exit Function
        End If

        If POST_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "郵便番号が入力されていません。",
                                "郵便番号を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            POST_CODE_T.Focus()
            Exit Function
        End If

        If ADDRESS1_C.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "都道府県が入力されていません。",
                                "都道府県を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS1_C.Focus()
            Exit Function
        End If

        If ADDRESS2_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "市区町村が入力されていません。",
                                "市区町村を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS2_T.Focus()
            Exit Function
        End If

        If ADDRESS3_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "市区町村以下の住所が入力されていません。",
                                "市区町村以下の住所を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            ADDRESS3_T.Focus()
            Exit Function
        End If

        If TEL_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "電話番号が入力されていません。",
                                "電話番号を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            TEL_T.Focus()
            Exit Function
        End If

        If ENTRY_DATE_D.Text = " " Then
            Message_form = New cMessageLib.fMessage(1, "入会日が入力されていません。",
                                "入会日を入力して下さい。",
                                Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form = Nothing
            INPUT_CHECK = False
            TEL_T.Focus()
            Exit Function
        End If


        INPUT_CHECK = True
    End Function

    Private Function MEMBER_CODE_CREATE() As String
        Dim KeyStr As String
        Dim MemberCode As String

        oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_C.Text, Nothing, oTran)

        KeyStr = oMstMemberDBIO.readMaxMemberCode(oChannel(0).sChannelCode, oTran)
        If KeyStr = Nothing Then
            KeyStr = "993" & oChannel(0).sChannelCode & String.Format("{0:00000000}", 1)
        Else
            KeyStr = "993" & oChannel(0).sChannelCode & String.Format("{0:00000000}", CInt(KeyStr.Substring(4, 8)) + 1)
        End If
        MemberCode = oTool.JANCD(KeyStr)

        MEMBER_CODE_CREATE = MemberCode
    End Function

    Private Sub ENTRY_DATE_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles ENTRY_DATE_D.CloseUp
        ENTRY_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub RESIGN_DATE_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles RESIGN_DATE_D.CloseUp
        RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ST_REG_DATE_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles ST_REG_DATE_D.CloseUp
        ST_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub END_REG_DATE_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles END_REG_DATE_D.CloseUp
        END_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub BIRTHDAY_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles BIRTHDAY_D.CloseUp
        BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub SUBBIRTHDAY_1_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles SUBBIRTHDAY_1_D.CloseUp
        SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ATTR3_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs)
        ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ATTR4_D_CloseUp(ByVal sender As Object, ByVal e As EventArgs)
        ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ENTRY_DATE_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ENTRY_DATE_D.ValueChanged
        ENTRY_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
        ST_REG_DATE_D.Value = ENTRY_DATE_D.Value
    End Sub

    Private Sub RESIGN_DATE_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RESIGN_DATE_D.ValueChanged
        RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    '2019,10,15 A.Komita 修正 Start-----------------------------------------------------------------------------------------
    Private Sub ST_REG_DATE_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ST_REG_DATE_D.ValueChanged
        ST_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub
    '2019,10,15 A.Komita 修正 End-------------------------------------------------------------------------------------------

    Private Sub END_REG_DATE_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles END_REG_DATE_D.ValueChanged
        END_REG_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub BIRTHDAY_T_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BIRTHDAY_D.ValueChanged
        BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Short
        AGE_T.Text = CAL_AGE(BIRTHDAY_D.Value)
    End Sub

    Private Sub SUBBIRTHDAY_1_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SUBBIRTHDAY_1_D.ValueChanged
        SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Short
        SUBAGE_1.Text = CAL_AGE(SUBBIRTHDAY_1_D.Value)
    End Sub

    Private Sub ATTR3_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ATTR3_D.ValueChanged
        ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub ATTR4_D_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ATTR4_D.ValueChanged
        ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Short
    End Sub

    Private Sub CHANNEL_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CHANNEL_C.SelectedIndexChanged
        Dim RecordCount As Integer

        If IVENT_FLG = False Then
            Exit Sub
        End If

        If MODE_L.Text = "（更新）" Then
            Dim message_form As New cMessageLib.fMessage(2,
                                      "チャネルを変更すると",
                                      "会員コードおよび会員カードの再発行となます",
                                      "変更してよろしいですか？",
                                      Nothing)
            message_form.ShowDialog()
            If message_form.DialogResult = Windows.Forms.DialogResult.No Then
                RecordCount = oChannelDBIO.getChannelMst(oChannel, MEMBER_CODE_T.Text.Substring(3, 1), Nothing, Nothing, Nothing, oTran)
                CHANNEL_C.Text = oChannel(0).sChannelName
            Else
                MODE_L.Text = "（新規）"
                MEMBER_CODE_T.Text = MEMBER_CODE_CREATE()
                ENTRY_DATE_D.Text = String.Format("{0:yyyy/MM/dd}", Now)
                ST_REG_DATE_D.Value = Now
            End If
            message_form = Nothing
        Else
            MEMBER_CODE_T.Text = MEMBER_CODE_CREATE()
        End If
    End Sub

    Private Sub RATE_V_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If IVENT_FLG = False Then
            Exit Sub
        End If
        RATE_V.CurrentCell = RATE_V(1, RATE_V.CurrentCell.RowIndex)
    End Sub

    Private Sub SERVICE_NAME_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SERVICE_NAME_C.SelectedIndexChanged

        If IVENT_FLG = False Then
            Exit Sub
        End If

        If SERVICE_NAME_C.Text <> "" Then
            ReDim oService(0)

            'トリミング会員を選択したら例外発生
            oMstServiceDBIO.getService(oService, Nothing, SERVICE_NAME_C.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            SERVICE_CODE_T.Text = oService(0).sServiceCode
        End If

        RATE_SET()
    End Sub

    Private Sub RATE_SET()
        Dim RecordCnt As Integer
        Dim i As Integer

        RATE_V.Rows.Clear()

        If SERVICE_NAME_C.Text <> "" Then
            ReDim oViewServiceFull(0)
            RecordCnt = oMstServiceDBIO.getServiceFull(oViewServiceFull, CInt(SERVICE_CODE_T.Text), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

            For i = 0 To RecordCnt - 1
                RATE_V.Rows.Add(
                    oViewServiceFull(i).sBumonName,
                    oViewServiceFull(i).sRate
                )
            Next
        End If

    End Sub

    Private Sub MEMBER_SEARCH_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MEMBER_SEARCH_B.Click
        Dim fMember_form As New cSelectLib.fMemberSearch(oConn, oCommand, oDataReader, oTran)
        fMember_form.ShowDialog()

        IVENT_FLG = False
        If fMember_form.DialogResult = Windows.Forms.DialogResult.OK Then
            MEMBER_SET(fMember_form.MEMBER_CODE_T.Text)
        End If
        IVENT_FLG = True

        fMember_form = Nothing

    End Sub

    Private Sub BIRTHDAY_CLR_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BIRTHDAY_CLR_B.Click
        BIRTHDAY_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        BIRTHDAY_D.CustomFormat = " "

    End Sub

    Private Sub ADDDR_SEARCH_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ADDDR_SEARCH_B.Click
        Dim strLen As Integer
        Dim RecordCount As Long
        Dim sPostCode As String

        '郵便番号の入力値チェック
        sPostCode = POST_CODE_T.Text
        strLen = sPostCode.Length

        '入力状況チェック
        If POST_CODE_T.Text.Length < 7 Then
            Dim message_form As New cMessageLib.fMessage(1,
                                              Nothing,
                                              "郵便番号を確認して下さい",
                                              Nothing,
                                              Nothing
                                              )
            message_form.ShowDialog()
            message_form = Nothing
            POST_CODE_T.Focus()
            Exit Sub
        End If

        'フォーマットチェック
        For i = 0 To strLen - 1
            If Asc(Mid(sPostCode, i + 1, 1)) < 48 Or Asc(Mid(sPostCode, i + 1, 1)) > 57 Then
                Dim message_form As New cMessageLib.fMessage(1,
                                                  Nothing,
                                                  "郵便番号は、－なしの半角数字で入力下さい",
                                                  Nothing,
                                                  Nothing
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
        Else
            ADDRESS1_C.Text = ""
            ADDRESS2_T.Text = ""
            ADDRESS3_T.Text = ""
        End If
        oMstPostCodeDBIO = Nothing

    End Sub

    Private Sub RESIGNDATE_CLR_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RESIGNDATE_CLR_B.Click
        RESIGN_DATE_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        RESIGN_DATE_D.CustomFormat = " "

    End Sub

    Private Sub REG_UPDATE_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles REG_UPDATE_B.Click
        Dim dt As Date

        dt = ST_REG_DATE_D.Value.AddYears(1)

        ST_REG_DATE_D.Value = dt
        END_REG_DATE_D.Value = dt.AddYears(+1)

        UPDATE_COUNT_T.Text = CInt(UPDATE_COUNT_T.Text) + 1
        UPDATE_FLG = 1

    End Sub


    Private Sub PHOTO_UP_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PHOTO_UP_B.Click
        Dim sPath As String
        Dim Derimita As Integer
        Dim tPath As String

        sPath = oTool.FileSearch(Nothing, Nothing)
        If sPath <> "" Then
            Derimita = sPath.LastIndexOf("."c)
            tPath = sPath.Substring(Derimita, sPath.Length - Derimita)
            tPath = Windows.Forms.Application.StartupPath & "\Temp\" & MEMBER_CODE_T.Text & ".jpg"

            'ファイルのコピー
            IO.File.Copy(sPath, tPath, True)

            ' FileStream を開く
            Dim hStream As New IO.FileStream(tPath, IO.FileMode.Open)

            ' FileStream から画像を読み込んで表示
            MEMBER_PIC.Image = Drawing.Image.FromStream(hStream)

            ' FileStream を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            hStream.Close()
        End If

    End Sub


    Private Sub ATTR3_CLR_B_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ATTR3_CLR_B.Click
        ATTR3_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ATTR3_D.CustomFormat = " "

    End Sub

    Private Sub ATTR4_CLR_B_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ATTR4_CLR_B.Click
        ATTR4_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        ATTR4_D.CustomFormat = " "

    End Sub

    Private Sub SUBBIRTH_CLR_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SUBBIRTH_CLR_B.Click
        SUBBIRTHDAY_1_D.Format = Windows.Forms.DateTimePickerFormat.Custom
        SUBBIRTHDAY_1_D.CustomFormat = " "

    End Sub

    Private Sub PRINT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PRINT_B.Click
        Dim ret As Boolean

        '2016.06.22 K.Oikawa s
        '必須項目の入力チェックを行う
        If INPUT_CHECK() = True Then
            '2016.06.22 K.Oikawa e
            ret = WRITE_PROC()

            If ret = True Then
                'MEMBER_CARD_PRINT()
            End If
            '2016.06.22 K.Oikawa s
        End If
        '2016.06.22 K.Oikawa e

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles QUIT_B.Click
        Dim ret As Boolean
        Dim message_form As cMessageLib.fMessage
        Dim tPath As String

        message_form = New cMessageLib.fMessage(2,
                 "会員情報を削除します。",
                 "削除した情報は元に戻せません。",
                 "削除してよろしいですか？",
                 Nothing)
        message_form.ShowDialog()
        If message_form.DialogResult = Windows.Forms.DialogResult.No Then
            message_form.Dispose()
            Exit Sub
        End If

        ret = oMstMemberDBIO.deleteMember(MEMBER_CODE_T.Text, oTran)
        tPath = Windows.Forms.Application.StartupPath & "\MemberPhoto\" & MEMBER_CODE_T.Text & ".jpg"

        If IO.File.Exists(tPath) Then
            'ファイルの削除
            IO.File.Delete(tPath)
        End If

        If ret = True Then
            message_form = New cMessageLib.fMessage(1,
                              Nothing,
                              "会員情報を削除しました。",
                              Nothing, Nothing)
        Else
            message_form = New cMessageLib.fMessage(1,
                             "会員情報の削除に失敗しました。",
                             "システム管理者に連絡して下さい。",
                             Nothing, Nothing)
        End If
        message_form.ShowDialog()
        message_form.Dispose()

    End Sub
    Private Function WRITE_PROC() As Boolean
        Dim ret As Boolean
        Dim pMember() As cStructureLib.sMember
        Dim cnt As Long

        If MODE_L.Text = "（新規）" And MEMBER_CODE_T.Text = "" Then
            MEMBER_CODE_T.Text = MEMBER_CODE_CREATE()
        End If


        'DB更新
        ReDim oMember(0)

        oMember(0).sMemberCode = MEMBER_CODE_T.Text
        oMember(0).sServiceCode = CInt(SERVICE_CODE_T.Text)
        oMember(0).sMemberName = MEMBER_NAME_T.Text
        oMember(0).sPostCode = POST_CODE_T.Text
        oMember(0).sAddress1 = ADDRESS1_C.Text
        oMember(0).sAddress2 = ADDRESS2_T.Text
        oMember(0).sAddress3 = ADDRESS3_T.Text
        oMember(0).sTEL = TEL_T.Text
        oMember(0).sFAX = FAX_T.Text
        oMember(0).sMailAddress = E_MAIL_T.Text

        If SEX_M_R.Checked = True Then
            oMember(0).sSex = "M"
        Else
            oMember(0).sSex = "F"
        End If
        If BIRTHDAY_D.Text = " " Then
            oMember(0).sBirthday = ""
        Else
            oMember(0).sBirthday = String.Format("{0:yyyy/MM/dd}", CDate(BIRTHDAY_D.Value))
        End If
        oMember(0).sAge = CInt(AGE_T.Text)
        oMember(0).sEntryDate = String.Format("{0:yyyy/MM/dd}", CDate(ENTRY_DATE_D.Value))
        If RESIGN_DATE_D.Text = " " Then
            oMember(0).sResignDate = ""
        Else
            oMember(0).sResignDate = String.Format("{0:yyyy/MM/dd}", CDate(RESIGN_DATE_D.Value))
        End If
        If ATTR1_DOG_R.Checked = True Then
            oMember(0).sAttr1 = "犬"
        Else
            If ATTR1_CAT_R.Checked = True Then
                oMember(0).sAttr1 = "猫"
            Else
                oMember(0).sAttr1 = "その他"
            End If
        End If
        oMember(0).sAttr2 = ATTR2_T.Text
        If ATTR3_D.Text = " " Then
            oMember(0).sAttr3 = ""
        Else
            oMember(0).sAttr3 = ATTR3_D.Value
        End If
        If ATTR4_D.Text = " " Then
            oMember(0).sAttr4 = ""
        Else
            oMember(0).sAttr4 = ATTR4_D.Value
        End If
        oMember(0).sAttr5 = ATTR5_T.Text
        oMember(0).sStartRegistDate = String.Format("{0:yyyy/MM/dd}", ST_REG_DATE_D.Value)
        oMember(0).sEndRegistDate = String.Format("{0:yyyy/MM/dd}", END_REG_DATE_D.Value)
        oMember(0).sUpdateCount = CInt(UPDATE_COUNT_T.Text)
        oMember(0).sSubMemberName = SUBMEMBER_NAME_1_T.Text
        If SUBSEX_M_1_R.Checked = True Then
            oMember(0).sSubMemberSex = "M"
        Else
            oMember(0).sSubMemberSex = "F"
        End If
        If SUBBIRTHDAY_1_D.Text = " " Then
            oMember(0).sSubMemberBirthDay = ""
        Else
            oMember(0).sSubMemberBirthDay = String.Format("{0:yyyy/MM/dd}", CDate(SUBBIRTHDAY_1_D.Value))
        End If
        oMember(0).sSubMemberAge = CInt(SUBAGE_1.Text)

        ReDim pMember(0)
        cnt = oMstMemberDBIO.getMember(pMember, MEMBER_CODE_T.Text, Nothing, Nothing, Nothing, oTran)

        If cnt > 0 Then
            ret = oMstMemberDBIO.updateMember(oMember(0), MEMBER_CODE_T.Text, oTran)
        Else
            ret = oMstMemberDBIO.insertMember(oMember(0), oTran)
        End If

        WRITE_PROC = ret

    End Function
    Private Sub COMMIT_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles COMMIT_B.Click
        Dim ret As Boolean
        Dim sPath As String
        Dim tPath As String
        Dim Message_form As cMessageLib.fMessage

        '必須項目入力確認
        If INPUT_CHECK() = True Then


            ret = WRITE_PROC()

            If ret = True Then
                sPath = Windows.Forms.Application.StartupPath & "\Temp\" & MEMBER_CODE_T.Text & ".jpg"
                tPath = Windows.Forms.Application.StartupPath & "\MemberPhoto\" & MEMBER_CODE_T.Text & ".jpg"

                If IO.File.Exists(sPath) Then
                    'ファイルのコピー
                    IO.File.Copy(sPath, tPath, True)
                    IO.File.Delete(sPath)
                End If


                Message_form = New cMessageLib.fMessage(1,
                      Nothing,
                      "登録が完了しました。",
                      Nothing, Nothing
                      )
                Message_form.ShowDialog()
                Message_form = Nothing

                '会員証印刷確認
                If UPDATE_FLG = 1 And MODE_L.Text = "（更新）" Then
                    'MEMBER_CARD_PRINT()
                End If
            Else
                Message_form = New cMessageLib.fMessage(1,
                                                          "登録処理が失敗しました。",
                                                          "システム管理者に連絡して下さい。",
                                                          Nothing, Nothing
                                                          )
                Message_form.ShowDialog()
                Message_form = Nothing

            End If

            If MODE = 0 Then
                IVENT_FLG = False
                '表示初期化
                DISP_INIT()
                IVENT_FLG = True
            Else
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
        End If
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RETURN_B.Click
        CLOSE_PROC()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()

    End Sub

    Private Sub CLOSE_PROC()
        oPostCode = Nothing
        oCity = Nothing
        oMstPostCodeDBIO = Nothing

        oMember = Nothing
        oMstMemberDBIO = Nothing

        oService = Nothing
        oViewServiceFull = Nothing
        oMstServiceDBIO = Nothing

        oChannel = Nothing
        oChannelDBIO = Nothing

        oConf = Nothing
        oMstConfigDBIO = Nothing

        oBumon = Nothing
        oMstBumonDBIO = Nothing

        oTool = Nothing

    End Sub
End Class
