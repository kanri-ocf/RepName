Public Class fPointADD

    Private oDataPointDBIO As cDataPointDBIO
    Private oPointData() As cStructureLib.sPoint

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private POINT_MEMBER_CODE As String

    Private STAFF_CODE As String
    Private STAFF_NAME As String

    Private oTran As System.Data.OleDb.OleDbTransaction

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
    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iPointMemberCode As String, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        POINT_MEMBER_CODE = iPointMemberCode

        STAFF_CODE = iStaffCode
        STAFF_NAME = iStaffName

    End Sub
    Private Sub fPointADD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pPointCnt As Long

        oDataPointDBIO = New cDataPointDBIO(oConn, oCommand, oDataReader)
        pPointCnt = oDataPointDBIO.getPoint(POINT_MEMBER_CODE, oTran)

        CURRENT_POINT_CNT_T.Text = pPointCnt
        ADD_POINT_CNT_T.Text = 0
        AFTER_POINT_CNT_T.Text = pPointCnt
    End Sub

    Private Sub ADD_POINT_CNT_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADD_POINT_CNT_T.LostFocus
        AFTER_POINT_CNT_T.Text = CLng(CURRENT_POINT_CNT_T.Text) + CLng(ADD_POINT_CNT_T.Text)
    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim pPointData As cStructureLib.sPoint

        'ポイントデータ作成
        pPointData = Nothing

        pPointData.sDate = String.Format("{0:yyyy/MM/dd}", Now)
        pPointData.sPointMemberCode = POINT_MEMBER_CODE
        If CLng(ADD_POINT_CNT_T.Text) < 0 Then
            pPointData.sAddPoint = 0
            pPointData.sUsePoint = CLng(ADD_POINT_CNT_T.Text) * -1
        Else
            pPointData.sAddPoint = CLng(ADD_POINT_CNT_T.Text)
            pPointData.sUsePoint = 0
        End If
        pPointData.sPoint = CLng(AFTER_POINT_CNT_T.Text)
        pPointData.sEnableFlg = True
        pPointData.sStaffCode = STAFF_CODE

        oDataPointDBIO.insertPoint(pPointData, oTran)
        oDataPointDBIO = Nothing
        pPointData = Nothing

        Dim Message_form = New cMessageLib.fMessage(1, _
              Nothing, _
              "登録が完了しました。", _
              Nothing, Nothing _
              )
        Message_form.ShowDialog()
        Message_form = Nothing

        Me.Close()
    End Sub
End Class