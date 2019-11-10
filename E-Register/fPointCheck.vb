Public Class fPointCheck

    Private ConArry() As CheckBox
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private oPointData() As cStructureLib.sPoint
    Private oDataPointDBIO As cDataPointDBIO

    Private POINT_MEMBER_CODE As String
    Private TOTAL_PRICE As Long
    Private USE_POINT As Long

    Private oConf As cStructureLib.sConfig

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private IVENT_FLG As Boolean

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf As cStructureLib.sConfig, _
            ByRef iPointMemberCode As String, _
            ByRef iTotalPrice As Long, _
            ByRef iUsePoint As Long, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oConf = iConf

        POINT_MEMBER_CODE = iPointMemberCode
        TOTAL_PRICE = iTotalPrice
        USE_POINT = iUsePoint

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
    Private Sub fMemberSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCount As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oTool = New cTool

        If POINT_MEMBER_CODE <> "" Then
            oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
            RecordCount = oMstPointMemberDBIO.getPointMember(oPointMember, _
                                           POINT_MEMBER_CODE, _
                                           POINT_MEMBER_CODE, _
                                           Nothing, _
                                           Nothing, _
                                           Nothing, _
                                           oTran)
            POINT_MEMBER_CODE_T.Text = oPointMember(0).sPointMemberCode
            POINT_MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName
            POST_CODE_T.Text = oPointMember(0).sPostCode
            ADDRESS_T.Text = oPointMember(0).sAddress1 & oPointMember(0).sAddress2 & oPointMember(0).sAddress3
            TEL_T.Text = oPointMember(0).sTEL
            FAX_T.Text = oPointMember(0).sFAX
            E_MAIL_T.Text = oPointMember(0).sMailAddress
            ENTRY_DATE_T.Text = oPointMember(0).sEntryDate
            REG_S_DATE.Text = oPointMember(0).sStartRegistDate
            REG_E_DATE.Text = oPointMember(0).sEndRegistDate
            SEX_T.Text = oPointMember(0).sSex
            GEN_T.Text = oPointMember(0).sAge
            oMstPointMemberDBIO = Nothing

            oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)
            POINT_T.Text = oDataPointDBIO.getPoint(POINT_MEMBER_CODE, oTran)
        Else
            POINT_T.Text = 0
        End If
        USE_POINT_T.Text = 0
        ADD_P_T.Text = oTool.ToRoundDown((TOTAL_PRICE - CLng(USE_POINT_T.Text)) * (oConf.sPointRATE / oConf.sPointEN), 0)
        RE_POINT_T.Text = POINT_T.Text + ADD_P_T.Text

        CAL_PROC()

        IVENT_FLG = True
    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        If USE_POINT_T.Text <> "" And USE_POINT_T.Text <> "0" Then
            If CLng(USE_POINT_T.Text) > CLng(POINT_T.Text) Then
                Dim Message_form As cMessageLib.fMessage

                Message_form = New cMessageLib.fMessage(1, "今回ご利用ポイント数が超過です。", _
                                                "今回ご利用可能ポイント数は", _
                                                "保有ポイント数以下に設定して下さい。", Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                USE_POINT_T.Focus()
                Exit Sub
            Else
                CAL_PROC()
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ALL_PRICE_POINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALL_PRICE_POINT_B.Click
        If TOTAL_PRICE > CLng(POINT_T.Text) Then
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "全額ポイント利用には", _
                                            "ポイント数が不足しております。", _
                                            "保有ポイントをすべて利用でセットします。", Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing
            USE_POINT_T.Text = POINT_T.Text
        Else
            USE_POINT_T.Text = TOTAL_PRICE
        End If
        CAL_PROC()

        COMMIT_B.Focus()
    End Sub
    Private Sub CAL_PROC()

        '2016.06.28 K.Oikawa s
        '修正などで使用ポイントが一時的にでも空になればエラー発生
        'ADD_P_T.Text = oTool.ToRoundDown((TOTAL_PRICE - CLng(USE_POINT_T.Text)) * (oConf.sPointRATE / oConf.sPointEN), 0)
        'RE_POINT_T.Text = CLng(POINT_T.Text) - CLng(USE_POINT_T.Text) + CLng(ADD_P_T.Text)
        If IsNumeric(USE_POINT_T.Text) Then
            ADD_P_T.Text = oTool.ToRoundDown((TOTAL_PRICE - CLng(USE_POINT_T.Text)) * (oConf.sPointRATE / oConf.sPointEN), 0)
            RE_POINT_T.Text = CLng(POINT_T.Text) - CLng(USE_POINT_T.Text) + CLng(ADD_P_T.Text)
        Else
            ADD_P_T.Text = oTool.ToRoundDown(TOTAL_PRICE * (oConf.sPointRATE / oConf.sPointEN), 0)
            RE_POINT_T.Text = CLng(POINT_T.Text) + CLng(ADD_P_T.Text)
        End If
        '2016.06.28 K.Oikawa e
    End Sub

    Private Sub USE_POINT_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles USE_POINT_T.LostFocus
        If USE_POINT_T.Text = "" Then
            USE_POINT_T.Text = 0
        End If
    End Sub

    Private Sub ALL_POINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALL_POINT_B.Click

        USE_POINT_T.Text = POINT_T.Text
        CAL_PROC()

        COMMIT_B.Focus()

    End Sub

    Private Sub USE_POINT_T_TextChanged(sender As Object, e As EventArgs) Handles USE_POINT_T.TextChanged
        CAL_PROC()
        USE_POINT_T.Focus()
    End Sub
End Class
