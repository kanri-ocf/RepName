Public Class fCreateTrnCode

    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oChannel() As cStructureLib.sChannel
    Private oChannelDBIO As cMstChannelDBIO
    Private oTool As New cTool

    Private oTran As System.Data.OleDb.OleDbTransaction
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

    End Sub
    Private Sub fCreateTrnCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        CHANNEL_SET()

    End Sub
    Private Sub CHANNEL_SET()
        Dim RecordCount As Long
        Dim i As Long

        RecordCount = oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, Nothing, True, oTran)
        '再描画中止
        CHANNEL_C.BeginUpdate()

        'コンボボックスへのチャネル名セット
        CHANNEL_C.Items.Add("")
        For i = 0 To RecordCount - 1
            CHANNEL_C.Items.Add(oChannel(i).sChannelName)
        Next
        CHANNEL_C.SelectedIndex = 0

        '再描画再開
        CHANNEL_C.EndUpdate()

    End Sub
    Private Sub CHANNEL_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHANNEL_C.SelectedIndexChanged
        oChannelDBIO.getChannelMst(oChannel, Nothing, Nothing, CHANNEL_C.Text, Nothing, oTran)
        CHANNEL_CODE_T.Text = oChannel(0).sChannelCode
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String

        JAN_CODE_T.Text = ""
        If ANY_CODE_T.Text <> Nothing Then
            str = oTool.JANCD("98" _
                          & String.Format("{0:0}", CInt(CHANNEL_CODE_T.Text)) _
                          & String.Format("{0:000000000}", CLng(ANY_CODE_T.Text)))
            JAN_CODE_T.Text = str
        End If
    End Sub
End Class