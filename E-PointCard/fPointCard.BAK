Public Class fRegfOpen
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

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
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

    Private Sub fRegfOpen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'スタッフ入力ウィンドウ表示
        Dim staff_form As cStaffEntryLib.fStaffEntry
        Dim adjust_form As cAdjustLib.fAdjustCount

        'スタッフ入力ウィンドウ表示
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

        adjust_form = New cAdjustLib.fAdjustCount(oConn, oCommand, oDataReader, Nothing, STAFF_CODE, STAFF_NAME, 0, oTran)
        adjust_form.ShowDialog()
        Application.DoEvents()
        Application.Exit()
    End Sub
End Class
