Public Class fOrderCancel
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private OrderCode As String
    Private OrderSubCode As Integer

    Private oOrderSubData() As cStructureLib.sOrderSubData
    Private oDataOrderSubDBIO As cDataOrderSubDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String


    '商品情報の一時保存反映
    Private oOrderData() As cStructureLib.sOrderData
    Private oDataOrderDBIO As cDataOrderDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductDBIO As cMstProductDBIO

    Private oCostPrice() As cStructureLib.sCostPrice
    Private oCostPriceDBIO As cMstCostPriceDBIO


    Private oTool As cTool
    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO
    'ここまで


    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iOrderCode As String, _
            ByVal iOrderSubCode As String, _
            ByVal StaffCode As String, _
            ByVal StaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        OrderCode = iOrderCode
        OrderSubCode = iOrderSubCode

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oDataOrderSubDBIO = New cDataOrderSubDBIO(oConn, oCommand, oDataReader)

        STAFF_CODE = StaffCode
        STAFF_NAME = StaffName

        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oCostPriceDBIO = New cMstCostPriceDBIO(oConn, oCommand, oDataReader)
        oDataOrderDBIO = New cDataOrderDBIO(oConn, oCommand, oDataReader)
        oTool = New cTool
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)


    End Sub
    '******************************************************************
    'システム・ショートカット・キーによるダイアログの終了を阻止する
    '******************************************************************
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_CLOSE As Integer = &HF060
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
            Return  ' Windows標準の処理は行わない
        End If
        MyBase.WndProc(m)
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


    Private Sub fOrderCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Long

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        ReDim oOrderSubData(0)
        RecordCnt = oDataOrderSubDBIO.getOrderSubData(oOrderSubData, OrderCode, OrderSubCode, oTran)
        RecordCnt = oDataOrderDBIO.getOrderData(oOrderData, OrderCode, Nothing, Nothing, Nothing, oTran)


        '商品情報の一時保存の結果を反映する
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)

        '商品情報の取得
        RecordCnt = oProductDBIO.getProduct(oProduct, Nothing, oOrderSubData(0).sProductCode, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        RecordCnt = oCostPriceDBIO.getPriceMst(oCostPrice, oOrderSubData(0).sProductCode, oOrderData(0).sSupplierCode, oTran)

        oOrderSubData(0).sProductName = oProduct(0).sProductName
        oOrderSubData(0).sOption1 = oProduct(0).sOption1
        oOrderSubData(0).sOption2 = oProduct(0).sOption2
        oOrderSubData(0).sOption3 = oProduct(0).sOption3
        oOrderSubData(0).sOption4 = oProduct(0).sOption4
        oOrderSubData(0).sOption5 = oProduct(0).sOption5
        oOrderSubData(0).sCostPrice = oTool.BeforeToAfterTax(oCostPrice(0).sCostPrice, oConf(0).sTax, oConf(0).sFracProc)

        '2019,11,22 A.Komita 追加 From
        If oOrderSubData(0).sCancelReason <> String.Empty Then
            REASON_T.Text = oOrderSubData(0).sCancelReason
        End If
        '2019,11,22 A.Komita 追加 To

        DISP_SET(oOrderSubData(0))

    End Sub

    Private Sub DISP_SET(ByRef SubOrder As cStructureLib.sOrderSubData)
        ORDER_CODE_L.Text = SubOrder.sOrderCode
        ORDER_SUB_CODE_L.Text = SubOrder.sOrderSubCode

        COSTPRICE_L.Text = SubOrder.sCostPrice
        CNT_L.Text = SubOrder.sCount
        TOTAL_PRICE_L.Text = SubOrder.sPrice

        PRODUCT_CODE_L.Text = SubOrder.sProductCode
        PRODUCT_NAME_L.Text = SubOrder.sProductName

        OPTION1_L.Text = SubOrder.sOption1
        OPTION2_L.Text = SubOrder.sOption2
        OPTION3_L.Text = SubOrder.sOption3
        OPTION4_L.Text = SubOrder.sOption4
        OPTION5_L.Text = SubOrder.sOption5

    End Sub

    Private Sub PRODUCT_MST_B_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRODUCT_MST_B.Click
        Dim fProductMst_form As New fProductMst(oConn, oCommand, oDataReader, oOrderSubData(0).sProductCode, STAFF_CODE, STAFF_NAME, oTran)

        fProductMst_form.ShowDialog()
        fProductMst_form.Dispose()

        '----------------------------------------------------
        '2015/06/21
        '及川和彦
        'FROM
        '----------------------------------------------------
        Me.DialogResult = fProductMst_form.DialogResult

        '----------------------------------------------------
        'HERE
        '----------------------------------------------------
        fProductMst_form = Nothing
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ARRIVE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARRIVE_B.Click
        Me.DialogResult = Windows.Forms.DialogResult.Ignore

        Me.Close()

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oOrderSubData = Nothing
        oDataOrderSubDBIO = Nothing
        'Me.DialogResult = Windows.Forms.DialogResult.Abort


        '----------------------------------------------------
        '2015/06/27
        '及川和彦
        '戻るにNoを割り当てる
        'FROM
        '----------------------------------------------------
        Me.DialogResult = Windows.Forms.DialogResult.No
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------



        Me.Close()

    End Sub

    Private Sub CANCEL_NG_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_NG_B.Click
        Dim RecordCnt As Long

        oOrderSubData(0).sOrderCancelFlg = False
        oOrderSubData(0).sCancelReason = ""

        RecordCnt = oDataOrderSubDBIO.updateOrderSub(oOrderSubData, oOrderSubData(0).sOrderCode, oOrderSubData(0).sOrderSubCode, oTran)

        oOrderSubData = Nothing
        oDataOrderSubDBIO = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub CANCEL_OK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_OK_B.Click
        Dim RecordCnt As Long
        Dim str As String

        oOrderSubData(0).sOrderCancelFlg = True
        str = ""
        If HAIBAN_R.Checked = True Then
            str = "廃番の為"
        Else
            If MISSTAKE_R.Checked = True Then
                If str.Length > 0 Then
                    str = str & "・"
                End If
                str = str & "誤発注の為"
            Else
                If NOUKI_R.Checked = True Then
                    If str.Length > 0 Then
                        str = str & "・"
                    End If
                    str = str & "納期遅延の為"
                Else
                    If OTHER_R.Checked = True Then
                        If REASON_T.Text = "" Then
                            str = str & "その他"
                            If str.Length > 0 Then
                                str = str & "・"
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If REASON_T.Text <> "" Then
            If str.Length > 0 Then
                str = str & "・"
            End If
            str = str & "・"
            str = str & REASON_T.Text
        End If
        oOrderSubData(0).sCancelReason = str

        RecordCnt = oDataOrderSubDBIO.updateOrderSub(oOrderSubData, oOrderSubData(0).sOrderCode, oOrderSubData(0).sOrderSubCode, oTran)

        oOrderSubData = Nothing
        oDataOrderSubDBIO = Nothing

        '----------------------------------------------------
        '2015/06/21
        '及川和彦
        'FROM
        '----------------------------------------------------
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        '----------------------------------------------------
        'HERE
        '----------------------------------------------------

        Me.Close()

    End Sub
End Class
