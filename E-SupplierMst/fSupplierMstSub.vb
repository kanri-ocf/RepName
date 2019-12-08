Public Class fSupplierMstSub
    Private Const DISP_ROW_MAX = 500
    Dim flag As Boolean
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oSupplier() As cStructureLib.sSupplier
    Private oMstSupplierDBIO As cMstSupplierDBIO

    Private oPayment() As cStructureLib.sPayment
    Private oMstPaymentDBIO As cMstPaymentDBIO

    Private oPostCode() As cStructureLib.sPostCode
    Private oCity() As cStructureLib.sCity
    Private oMstPostCodeDBIO As cMstPostCodeDBIO

    Private oTool As cTool

    Private SUPPLIER_CODE As Integer
    Private STAFF_CODE As String

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iSupplierCode As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        If IsNothing(iSupplierCode) = True Then
            SUPPLIER_CODE = -1
        Else
            SUPPLIER_CODE = iSupplierCode
        End If
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oMstSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oMstPaymentDBIO = New cMstPaymentDBIO(oConn, oCommand, oDataReader)

        '支払方法リストボックスセット
        PAYMENT1_SET()
        PAYMENT2_SET()
        PAYMENT3_SET()

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub PAYMENT1_SET()
        Dim i As Integer

        ReDim oPayment(0)
        'oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
        oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
        For i = 0 To oPayment.Length - 1
            PAYMENT_NAME_1_L.Items.Add(oPayment(i).sPaymentName)
        Next
    End Sub
    Private Sub PAYMENT2_SET()
        Dim i As Integer

        ReDim oPayment(0)
        'oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
        oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
        For i = 0 To oPayment.Length - 2
            PAYMENT_NAME_2_L.Items.Add(oPayment(i).sPaymentName)
        Next
    End Sub
    Private Sub PAYMENT3_SET()
        Dim i As Integer

        ReDim oPayment(0)
        'oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
        oMstPaymentDBIO.getPayment(oPayment, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
        For i = 0 To oPayment.Length - 3
            PAYMENT_NAME_3_L.Items.Add(oPayment(i).sPaymentName)
        Next
    End Sub
    Private Sub INIT_PROC()
        Dim RecordCount As Long

        If SUPPLIER_CODE = -1 Then
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "新規"
            SUPPLIER_CODE_T.Text = oMstSupplierDBIO.getNewSupplierCode(oTran)
            SUPPLIER_NAME_T.Text = ""
            POST_CODE_T.Text = ""
            ADDRESS1_C.Text = ""
            ADDRESS2_T.Text = ""
            ADDRESS3_T.Text = ""
            TEL_T.Text = ""
            FAX_T.Text = ""
            URL_T.Text = ""
            TANTOU_NAME_T.Text = ""
            CLOSE_DAY_T.Text = ""
            RATE_T.Text = ""
            MIN_LOT_T.Text = ""
            PAYMENT_NAME_1_L.Text = ""
            PAYMENT_NAME_2_L.Text = ""
            PAYMENT_NAME_3_L.Text = ""
            PAYMENT_CODE_1_T.Text = 0
            PAYMENT_CODE_2_T.Text = 0
            PAYMENT_CODE_3_T.Text = 0
            RULE_T.Text = ""
            MEMO_T.Text = ""
            DELETE_B.Enabled = False
        Else
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "更新"
            oMstSupplierDBIO.getSupplier(oSupplier, SUPPLIER_CODE, Nothing, oTran)
            SUPPLIER_CODE_T.Text = oSupplier(0).sSupplierCode
            SUPPLIER_NAME_T.Text = oSupplier(0).sSupplierName
            POST_CODE_T.Text = oSupplier(0).sPostCode
            ADDRESS1_C.Text = oSupplier(0).sAddress1
            ADDRESS2_T.Text = oSupplier(0).sAddress2
            ADDRESS3_T.Text = oSupplier(0).sAddress3
            TEL_T.Text = oSupplier(0).sTEL
            FAX_T.Text = oSupplier(0).sFAX
            URL_T.Text = oSupplier(0).sURL
            TANTOU_NAME_T.Text = oSupplier(0).sPersonName
            CLOSE_DAY_T.Text = oSupplier(0).sCloseDate
            RATE_T.Text = oSupplier(0).sStanderedRate
            MIN_LOT_T.Text = oSupplier(0).sStanderedLot

            If oSupplier(0).sPaymentCode1 <> 0 Then
                'RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode1, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
                RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode1, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
                PAYMENT_CODE_1_T.Text = oPayment(0).sPaymentCode
                PAYMENT_NAME_1_L.Text = oPayment(0).sPaymentName
            Else
                PAYMENT_CODE_1_T.Text = ""
                PAYMENT_NAME_1_L.Text = ""
            End If

            If oSupplier(0).sPaymentCode2 <> 0 Then
                'RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode2, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
                RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode2, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
                PAYMENT_CODE_2_T.Text = oPayment(0).sPaymentCode
                PAYMENT_NAME_2_L.Text = oPayment(0).sPaymentName
            Else
                PAYMENT_CODE_2_T.Text = ""
                PAYMENT_NAME_2_L.Text = ""
            End If

            If oSupplier(0).sPaymentCode3 <> 0 Then
                'RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode3, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
                RecordCount = oMstPaymentDBIO.getPayment(oPayment, oSupplier(0).sPaymentCode3, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
                PAYMENT_CODE_3_T.Text = oPayment(0).sPaymentCode
                PAYMENT_NAME_3_L.Text = oPayment(0).sPaymentName
            Else
                PAYMENT_CODE_3_T.Text = ""
                PAYMENT_NAME_3_L.Text = ""
            End If

            RULE_T.Text = oSupplier(0).sTrnRule
            MEMO_T.Text = oSupplier(0).sMemo
            DELETE_B.Enabled = True
        End If
    End Sub

    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function

    Private Sub CLOSE_PROC()
        oMstSupplierDBIO = Nothing

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PAYMENT_NAME_1_L_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PAYMENT_NAME_1_L.TextChanged
        If PAYMENT_NAME_1_L.Text <> "" Then
            ReDim oPayment(0)
            'oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_1_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
            oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_1_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
            PAYMENT_CODE_1_T.Text = oPayment(0).sPaymentCode
        Else
            PAYMENT_CODE_1_T.Text = 0
        End If

    End Sub

    Private Sub PAYMENT_NAME_2_L_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PAYMENT_NAME_2_L.TextChanged
        If PAYMENT_NAME_2_L.Text <> "" Then
            ReDim oPayment(0)
            'oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_2_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
            oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_2_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
            PAYMENT_CODE_2_T.Text = oPayment(0).sPaymentCode
        Else
            PAYMENT_CODE_2_T.Text = 0
        End If

    End Sub

    Private Sub PAYMENT_NAME_3_L_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PAYMENT_NAME_3_L.TextChanged
        If PAYMENT_NAME_3_L.Text <> "" Then
            ReDim oPayment(0)
            'oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_3_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)
            oMstPaymentDBIO.getPayment(oPayment, Nothing, PAYMENT_NAME_3_L.Text, Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, oTran)
            PAYMENT_CODE_3_T.Text = oPayment(0).sPaymentCode
        Else
            PAYMENT_CODE_3_T.Text = 0
        End If

    End Sub

    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        ret = oMstSupplierDBIO.deleteSupplierMst(SUPPLIER_CODE_T.Text, oTran)
        If ret = False Then
            Message_form = New cMessageLib.fMessage(1, "仕入先マスタの登録に失敗しました。", _
                                            "システム管理者に連絡して下さい", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                                            "削除が完了しました。", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Message_form.ShowDialog()
        Application.DoEvents()
        Message_form = Nothing


        CLOSE_PROC()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '---------------------------------------------------------------------------------
        '2019/12/08 suzuki 
        '必須項目のチェックを追加
        '---------------------------------------------------------------------------------
        flag = False
        Requireditem()

        If flag <> False Then
            ReDim oSupplier(0)
            oSupplier(0).sSupplierCode = SUPPLIER_CODE_T.Text
            oSupplier(0).sSupplierName = SUPPLIER_NAME_T.Text
            oSupplier(0).sPostCode = POST_CODE_T.Text
            oSupplier(0).sAddress1 = ADDRESS1_C.Text
            oSupplier(0).sAddress2 = ADDRESS2_T.Text
            oSupplier(0).sAddress3 = ADDRESS3_T.Text
            oSupplier(0).sTEL = TEL_T.Text
            oSupplier(0).sFAX = FAX_T.Text
            oSupplier(0).sURL = URL_T.Text
            oSupplier(0).sPersonName = TANTOU_NAME_T.Text
            oSupplier(0).sCloseDate = CLOSE_DAY_T.Text
            oSupplier(0).sStanderedRate = RATE_T.Text
            oSupplier(0).sStanderedLot = MIN_LOT_T.Text
            oSupplier(0).sPaymentCode1 = PAYMENT_CODE_1_T.Text
            If PAYMENT_CODE_2_T.Text <> "" Then
                oSupplier(0).sPaymentCode2 = PAYMENT_CODE_2_T.Text
            End If
            If PAYMENT_CODE_3_T.Text <> "" Then
                oSupplier(0).sPaymentCode3 = PAYMENT_CODE_3_T.Text
            End If
            oSupplier(0).sTrnRule = RULE_T.Text
            oSupplier(0).sMemo = MEMO_T.Text
            If MODE_L.Text = "新規" Then
                ret = oMstSupplierDBIO.insertSupplierMst(oSupplier(0), oTran)
            Else
                ret = oMstSupplierDBIO.updateSupplierMst(oSupplier(0), CInt(SUPPLIER_CODE_T.Text), oTran)
            End If
            If ret = False Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの登録に失敗しました。",
                                            "システム管理者に連絡して下さい",
                                            Nothing, Nothing)
                Me.DialogResult = Windows.Forms.DialogResult.Abort
            Else
                Message_form = New cMessageLib.fMessage(1, Nothing,
                                            "登録が完了しました。",
                                            Nothing, Nothing)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            CLOSE_PROC()
        End If

        '---------------------------------------------------------------------------------
        '2019/12/08 suzuki 
        '必須項目のチェックを追加　END
        '---------------------------------------------------------------------------------
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstSupplierDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        CLOSE_PROC()

    End Sub

    Private Sub ADDDR_SEARCH_B_Click(sender As Object, e As EventArgs) Handles ADDDR_SEARCH_B.Click
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

        ADDRESS3_T.Focus()
    End Sub
    '---------------------------------------------------------------------------------
    '2019/12/08 suzuki 
    '必須項目の確認フラグを追加
    '---------------------------------------------------------------------------------
    Private Sub Requireditem()
        Dim Message_form As cMessageLib.fMessage

        If SUPPLIER_CODE_T.Text <> "" Then
            If SUPPLIER_NAME_T.Text <> "" Then
                If CLOSE_DAY_T.Text <> "" Then
                    If RATE_T.Text <> "" Then
                        If MIN_LOT_T.Text <> "" Then
                            If PAYMENT_NAME_1_L.Text <> "" Then
                                flag = True
                            Else
                                Message_form = New cMessageLib.fMessage(1, Nothing,
                                "支払い方法が選択されていません。",
                                Nothing, Nothing)
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Message_form.ShowDialog()
                                Message_form = Nothing
                            End If
                        Else
                            Message_form = New cMessageLib.fMessage(1, Nothing,
                            "標準ロット数が入力されていません。",
                            Nothing, Nothing)
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Message_form.ShowDialog()
                            Message_form = Nothing
                        End If
                    Else
                        Message_form = New cMessageLib.fMessage(1, Nothing,
                        "締め日が入力されていません。",
                         Nothing, Nothing)
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Message_form.ShowDialog()
                        Message_form = Nothing
                    End If
                Else
                    Message_form = New cMessageLib.fMessage(1, Nothing,
                    "標準仕切率が入力されていません。",
                    Nothing, Nothing)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Message_form.ShowDialog()
                    Message_form = Nothing

                End If

            Else
                    Message_form = New cMessageLib.fMessage(1, Nothing,
                            "仕入先名称が入力されていません。",
                            Nothing, Nothing)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Message_form.ShowDialog()
                Message_form = Nothing
            End If

        Else
            Message_form = New cMessageLib.fMessage(1, Nothing,
            "仕入先コードが入力されていません。",
             Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Message_form.ShowDialog()
            Message_form = Nothing
        End If

    End Sub
    '---------------------------------------------------------------------------------
    '2019/12/08 suzuki 
    '必須項目の確認フラグを追加　END
    '---------------------------------------------------------------------------------
End Class
