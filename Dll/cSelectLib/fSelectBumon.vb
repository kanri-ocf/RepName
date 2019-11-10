
Public Class fSelectBumon
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader
    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oBumon() As cStructureLib.sBumon
    Private oMstBumonDBIO As cMstBumonDBIO

    Private oConf() As cStructureLib.sConfig
    Private oTool As cTool

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oConf = iConf

        oMstBumonDBIO = New cMstBumonDBIO(iConn, iCommand, iDataReader)
        oTool = New cTool

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

    Private Sub fSelectJAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        GRIDVIEW_CREATE()
        ret = BUMON_DISPLAY()
        If ret = False Then
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Me.Close()
        End If
    End Sub
    '******************************
    '     System.Windows.Forms.DataGridViewの設定
    '        ヘッダー生成
    '******************************
    Sub GRIDVIEW_CREATE()
        'レコードセレクタを非表示に設定
        BUMON_LIST_V.RowHeadersVisible = False

        BUMON_LIST_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        BUMON_LIST_V.ColumnHeadersHeight = 25
        BUMON_LIST_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "部門コード"
        BUMON_LIST_V.Columns.Add(column1)
        column1.Width = 120

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "部門名称"
        BUMON_LIST_V.Columns.Add(column2)
        column2.Width = 330


        '背景色を白に設定
        BUMON_LIST_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        BUMON_LIST_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub
    Function BUMON_DISPLAY() As Boolean
        Dim cnt As Long
        Dim i As Long

        ReDim oBumon(0)
        cnt = oMstBumonDBIO.getBumonMst(oBumon, "999", Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        For i = 1 To cnt
            'オプション結合
            BUMON_LIST_V.Rows.Add( _
                       oBumon(i - 1).sBumonCode, _
                       oBumon(i - 1).sBumonName _
            )
        Next i
        If cnt = 0 Then
            BUMON_DISPLAY = False
        Else
            BUMON_DISPLAY = True
        End If

    End Function


    Private Sub BUMON_LIST_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BUMON_LIST_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = BUMON_LIST_V.CurrentRow.Index

        BUMON_CODE_T.Text = BUMON_LIST_V(0, SelRow).Value.ToString()

        '商品選択ウィンドウを閉じる
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

End Class

