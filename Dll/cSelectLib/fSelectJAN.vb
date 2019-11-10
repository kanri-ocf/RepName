
Public Class fSelectJAN
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader
    Private oTran As System.Data.OleDb.OleDbTransaction

    'JANコード
    Private pJANCODE As String

    'チャネルコード
    Private CHANNEL_CODE As Integer

    Private oProductSalePrice() As cStructureLib.sViewProductSalePrice
    Private oMstProductDBIO As cMstProductDBIO

    Private oConf() As cStructureLib.sConfig
    Private oTool As cTool

    '検索モード用
    Private Const PRODUCT_MODE = 1
    Private Const JAN_MODE = 2

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iChannelCode As Integer, _
            ByVal iJanCode As String, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oConf = iConf

        oMstProductDBIO = New cMstProductDBIO(iConn, iCommand, iDataReader)
        oTool = New cTool

        pJANCODE = iJanCode
        CHANNEL_CODE = iChannelCode

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
        ret = PRODUCT_DISPLAY()
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
        PRODUCT_LIST_V.RowHeadersVisible = False

        PRODUCT_LIST_V.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        PRODUCT_LIST_V.ColumnHeadersHeight = 25
        PRODUCT_LIST_V.RowTemplate.Height = 25

        'グリッドのヘッダーを作成します。
        Dim column1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column1.HeaderText = "商品コード"
        PRODUCT_LIST_V.Columns.Add(column1)
        column1.Width = 85

        Dim column2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column2.HeaderText = "商品名称"
        PRODUCT_LIST_V.Columns.Add(column2)
        column2.Width = 220

        Dim column3 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column3.HeaderText = "オプション"
        PRODUCT_LIST_V.Columns.Add(column3)
        column3.Width = 250

        Dim column4 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column4.HeaderText = "定価"
        PRODUCT_LIST_V.Columns.Add(column4)
        column4.Width = 80
        column4.DefaultCellStyle.Format = "c"
        column4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight

        Dim column5 As New System.Windows.Forms.DataGridViewTextBoxColumn
        column5.HeaderText = "販売価格"
        PRODUCT_LIST_V.Columns.Add(column5)
        column5.Width = 80
        column5.DefaultCellStyle.Format = "c"
        column5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight

        '背景色を白に設定
        PRODUCT_LIST_V.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White

        '奇数行の背景色を薄黄色に設定
        PRODUCT_LIST_V.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon

    End Sub
    Function PRODUCT_DISPLAY() As Boolean
        Dim cnt As Long
        Dim i As Long
        Dim opt As String

        ReDim oProductSalePrice(0)
        If CHANNEL_CODE = 0 Then
            cnt = oMstProductDBIO.getProductSalePrice(oProductSalePrice, Nothing, Nothing, pJANCODE, oTran)
        Else
            cnt = oMstProductDBIO.getProductSalePrice(oProductSalePrice, CHANNEL_CODE, Nothing, pJANCODE, oTran)
        End If
        For i = 1 To cnt
            'オプション結合
            opt = ""
            If oProductSalePrice(i - 1).sOption1 <> "" Then
                opt = opt & oProductSalePrice(i - 1).sOption1 & "："
            End If
            If oProductSalePrice(i - 1).sOption2 <> "" Then
                opt = opt & oProductSalePrice(i - 1).sOption2 & "："
            End If
            If oProductSalePrice(i - 1).sOption3 <> "" Then
                opt = opt & oProductSalePrice(i - 1).sOption3 & "："
            End If
            If oProductSalePrice(i - 1).sOption4 <> "" Then
                opt = opt & oProductSalePrice(i - 1).sOption4 & "："
            End If
            If oProductSalePrice(i - 1).sOption5 <> "" Then
                opt = opt & oProductSalePrice(i - 1).sOption5 & "："
            End If
            PRODUCT_LIST_V.Rows.Add( _
                       oProductSalePrice(i - 1).sProductCode, _
                       oProductSalePrice(i - 1).sProductName, _
                       opt, _
                       oTool.BeforeToAfterTax(oProductSalePrice(i - 1).sListPrice, oConf(0).sTax, oConf(0).sFracProc), _
                       oTool.BeforeToAfterTax(oProductSalePrice(i - 1).sSalePrice, oConf(0).sTax, oConf(0).sFracProc) _
            )
        Next i
        If cnt = 0 Then
            PRODUCT_DISPLAY = False
        Else
            PRODUCT_DISPLAY = True
        End If

    End Function


    Private Sub PRODUCT_LIST_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PRODUCT_LIST_V.CellClick
        Dim SelRow As Integer

        'ヘッダーがクリックされた場合Exit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        'タイトル行の下の行を1行目として返す
        SelRow = PRODUCT_LIST_V.CurrentRow.Index

        ''On Error Resume Next
        'If PRODUCT_LIST_V(0, SelRow).Value.ToString() = Nothing Then
        '    Exit Sub
        'End If

        PRODUCT_CODE_T.Text = PRODUCT_LIST_V(0, SelRow).Value.ToString()

        '商品選択ウィンドウを閉じる
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

End Class

