Public Class fPointCardLoss
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oPointData() As cStructureLib.sPoint
    Private oDataPointDBIO As cDataPointDBIO

    Private oPointMember() As cStructureLib.sPointMember
    Private oMstPointMemberDBIO As cMstPointMemberDBIO

    Private oTool As cTool

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private FROM_POINT_MEMBER_CODE As String
    Private TO_POINT_MEMBER_CODE As String

    Private oTran As System.Data.OleDb.OleDbTransaction
    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
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

        oMstPointMemberDBIO = New cMstPointMemberDBIO(oConn, oCommand, oDataReader)
        oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

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

    Private Sub fPointCardLoss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        COMMIT_B.Enabled = False
        FROM_ENABLE_T.Text = 0
        TO_ENABLE_T.Text = 0

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oDataPointDBIO = Nothing
        oMstPointMemberDBIO = Nothing
        oPointData = Nothing
        oPointMember = Nothing

        Me.Close()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim fPointMember_form As New cSelectLib.fPointMemberSearch(oConn, oCommand, oDataReader, oTran)

        fPointMember_form.ShowDialog()

        If fPointMember_form.DialogResult = Windows.Forms.DialogResult.OK Then

            FROM_POINT_MEMBER_CODE = fPointMember_form.POINT_MEMBER_CODE_T.Text
            FROM_POINT_MEMBER_CODE_T.Text = fPointMember_form.POINT_MEMBER_CODE_T.Text

            POINT_MEMBER_SET()

        End If

        fPointMember_form.Dispose()
        fPointMember_form = Nothing

        FROM_POINT_MEMBER_CODE_T.Focus()
    End Sub
    Private Sub POINT_MEMBER_SET()
        Dim RecCnt As Long
        Dim Message_form As cMessageLib.fMessage

        FROM_ENABLE_T.Text = 0
        RecCnt = oMstPointMemberDBIO.getPointMember(oPointMember, FROM_POINT_MEMBER_CODE, FROM_POINT_MEMBER_CODE, Nothing, Nothing, True, oTran)
        If RecCnt < 1 Then
            Message_form = New cMessageLib.fMessage(1, _
                                          "該当のポイント会員コードは有効でありません。", _
                                          "ポイント会員コードを確認して下さい。", _
                                          Nothing, Nothing _
                                          )
            Message_form.ShowDialog()
            Message_form = Nothing
            Exit Sub
        End If

        POINT_MEMBER_NAME_T.Text = oPointMember(0).sPointMemberName
        TEL_T.Text = oPointMember(0).sTEL
        ENTRY_DATE_T.Text = oPointMember(0).sEntryDate
        POINT_CNT_T.Text = oDataPointDBIO.getPoint(FROM_POINT_MEMBER_CODE, oTran)

        COMMIT_B.Enabled = True
        FROM_ENABLE_T.Text = 1
    End Sub

    Private Sub FROM_POINT_MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FROM_POINT_MEMBER_CODE_T.LostFocus
        If FROM_POINT_MEMBER_CODE_T.Text <> "" Then
            FROM_POINT_MEMBER_CODE = FROM_POINT_MEMBER_CODE_T.Text
            POINT_MEMBER_SET()
        End If
    End Sub

    Private Sub TO_POINT_MEMBER_CODE_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TO_POINT_MEMBER_CODE_T.LostFocus
        Dim RecCnt As Long
        Dim Message_form As cMessageLib.fMessage

        If TO_POINT_MEMBER_CODE_T.Text <> "" Then
            TO_ENABLE_T.Text = 0
            RecCnt = oMstPointMemberDBIO.getPointMember(oPointMember, TO_POINT_MEMBER_CODE_T.Text, TO_POINT_MEMBER_CODE_T.Text, Nothing, Nothing, False, oTran)
            If RecCnt < 1 Then
                Message_form = New cMessageLib.fMessage(1, _
                                          "再発行するポイントカードの会員コードが無効です", _
                                          "再発行カード番号を確認して下さい。", _
                                          Nothing, Nothing _
                                              )
                Message_form.ShowDialog()
                Message_form = Nothing
                TO_ENABLE_T.Text = ""
                TO_ENABLE_T.Focus()
                Exit Sub
            End If

            TO_POINT_MEMBER_CODE = TO_POINT_MEMBER_CODE_T.Text
            TO_ENABLE_T.Text = 1
        End If
    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage

        If FROM_ENABLE_T.Text <> 1 Then
            Message_form = New cMessageLib.fMessage(1, _
                                          "紛失したポイントカードの会員コードが無効です", _
                                          "紛失カード番号を確認して下さい。", _
                                          Nothing, Nothing _
                                          )
            Message_form.ShowDialog()
            Message_form = Nothing
            FROM_ENABLE_T.Text = ""
            FROM_ENABLE_T.Focus()
            Exit Sub
        End If

        If TO_ENABLE_T.Text <> 1 Then
            Message_form = New cMessageLib.fMessage(1, _
                                          "再発行するポイントカードの会員コードが無効です", _
                                          "再発行カード番号を確認して下さい。", _
                                          Nothing, Nothing _
                                          )
            Message_form.ShowDialog()
            Message_form = Nothing
            TO_ENABLE_T.Text = ""
            TO_ENABLE_T.Focus()
            Exit Sub
        End If

        If FROM_POINT_MEMBER_CODE_T.Text <> TO_POINT_MEMBER_CODE_T.Text Then
            If PRINT_C.Checked = True Then
                Message_form = New cMessageLib.fMessage(1, _
                                              "再発行時に同時発行（印刷）可能なのは", _
                                              "カードプリンターが接続されている場合のみです。", _
                                              "再度設定をご確認下さい", Nothing _
                                              )
                Message_form.ShowDialog()
                Message_form = Nothing
                PRINT_C.Checked = False
                PRINT_C.Focus()
                Exit Sub
            End If
        End If

        If FROM_POINT_MEMBER_CODE_T.Text <> TO_POINT_MEMBER_CODE_T.Text Then
            '紛失データの無効化⇒新規ポイント会員コードへのデータ移行
            MOVE_MEMBER_DATA()

            Message_form = New cMessageLib.fMessage(1, _
                                          "", _
                                          "再発行処理が完了しました。", _
                                          Nothing, Nothing _
                                          )
            Message_form.ShowDialog()
            Message_form = Nothing
        End If

        oDataPointDBIO = Nothing
        oMstPointMemberDBIO = Nothing
        oPointData = Nothing
        oPointMember = Nothing

        '-----------------------------------------------------------------------------
        'ポイントカードの再発行
        '再発行時に印刷可能な場合は、カードプリンターが接続されている場合に限ります。
        '-----------------------------------------------------------------------------
        If PRINT_C.Checked = True Then
            Dim oPointCardPrint_form = New cReportsLib.fPointCardReportPage(oConn, oCommand, oDataReader, 1, TO_POINT_MEMBER_CODE_T.Text, oTran)

            Me.Visible = False
            oPointCardPrint_form.ShowDialog()
            oPointCardPrint_form = Nothing
            Me.Visible = True
        End If

        Me.Close()
    End Sub

    Private Sub MOVE_MEMBER_DATA()
        Dim RecCnt As Integer
        Dim i As Integer

        'ポイントデータのコピー
        RecCnt = oDataPointDBIO.getPointData(oPointData, Nothing, FROM_POINT_MEMBER_CODE, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To RecCnt - 1
            oPointData(i).sPointMemberCode = TO_POINT_MEMBER_CODE
            oDataPointDBIO.insertPoint(oPointData(i), oTran)
        Next

        'ポイント会員情報のコピー
        oMstPointMemberDBIO.getPointMember(oPointMember, FROM_POINT_MEMBER_CODE, FROM_POINT_MEMBER_CODE, Nothing, Nothing, Nothing, oTran)
        oPointMember(0).sPointMemberCode = TO_POINT_MEMBER_CODE
        oMstPointMemberDBIO.updatePointMember(oPointMember(0), TO_POINT_MEMBER_CODE, oTran)

        '紛失ポイント会員情報の契約満了日設定
        oMstPointMemberDBIO.updatePointMemberEndDate(FROM_POINT_MEMBER_CODE, String.Format("{0:yyyy/MM/dd}", Now), "カード紛失", oTran)

        '紛失ポイントデータの無効化
        oDataPointDBIO.updatePointEnable(Nothing, FROM_POINT_MEMBER_CODE, False, oTran)

    End Sub

    Private Sub COPY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COPY_B.Click
        TO_POINT_MEMBER_CODE_T.Text = FROM_POINT_MEMBER_CODE_T.Text
        TO_POINT_MEMBER_CODE_T.Focus()
    End Sub
End Class