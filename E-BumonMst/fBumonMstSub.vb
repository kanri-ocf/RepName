
Public Class fBumonMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oTaxClassDBIO As cMstTaxClassDBIO
    Private oTaxClass() As cStructureLib.sTaxClass

    Private oTool As cTool

    Private BUMON_CODE As String
    Private STAFF_CODE As String

    Private oTran As System.Data.OleDb.OleDbTransaction


    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iBumonCode As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oTool = New cTool

        BUMON_CODE = iBumonCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oTaxClassDBIO = New cMstTaxClassDBIO(oConn, oCommand, oDataReader)

        '表示初期化処理
        INIT_PROC()

    End Sub
    Private Sub INIT_PROC()
        If BUMON_CODE = Nothing Then
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "新規"
            BUMON_CODE_T.Text = oBumonDBIO.getNewBumonCode(oTran)
            BUMON_NAME_T.Text = ""
            BUMON_SHORT_NAME_T.Text = ""
            PRODUCT_R.Checked = True
            RESERV_YES_R.Checked = True
            DAY_R.Checked = True
            TAX_CLASS_NAME_T.Text = ""
            DELETE_B.Enabled = False
        Else
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "更新"
            oBumonDBIO.getBumonMst(oBumon, BUMON_CODE, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            BUMON_CODE_T.Text = oBumon(0).sBumonCode
            BUMON_NAME_T.Text = oBumon(0).sBumonName
            BUMON_SHORT_NAME_T.Text = oBumon(0).sBumonShortName
            If oBumon(0).sBumonClass = 1 Then
                PRODUCT_R.Checked = True
            Else
                SERVICE_R.Checked = True
            End If
            If oBumon(0).sReservFlg = True Then
                RESERV_YES_R.Checked = True
            Else
                RESERV_NO_R.Checked = True
            End If

            If oBumon(0).sReservFlg = True Then
                Select Case oBumon(0).sReservPeace
                    Case "D"
                        DAY_R.Checked = True
                    Case "H"
                        TIME_R.Checked = True
                End Select
            Else
                DAY_R.Enabled = False
                TIME_R.Enabled = False
            End If
            TAX_CLASS_CODE_T.Text = oBumon(0).sTaxClassCode
            oTaxClassDBIO.getTaxClass(oTaxClass, oBumon(0).sTaxClassCode, Nothing, oTran)
            TAX_CLASS_NAME_T.Text = oTaxClass(0).sTaxClassName
        End If
    End Sub

    Private Function INPUT_CHECK() As Boolean
        Dim RecordCnt As Long
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If BUMON_CODE_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "部門コードが未入力です。", _
                                "部門コードを入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form = Nothing
            BUMON_CODE_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If BUMON_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "部門名称が未入力です。", _
                                "部門名称を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form = Nothing
            BUMON_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        If BUMON_SHORT_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "部門略称が未入力です。", _
                                "部門略称を入力して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form = Nothing
            BUMON_SHORT_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

        RecordCnt = oTaxClassDBIO.getTaxClass(oTaxClass, Nothing, TAX_CLASS_NAME_T.Text, oTran)
        If RecordCnt = 0 Then
            Message_form = New cMessageLib.fMessage(1, "税区分マスタに登録されていない税区分が入力されました。", _
                                "税区分名称を確認して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form = Nothing
            TAX_CLASS_CODE_T.Text = ""
            TAX_CLASS_NAME_T.Text = ""
            TAX_CLASS_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function

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
        oBumonDBIO = Nothing

        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub LINK_JAN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LINK_JAN_B.Click
        Dim KeyJANCode As String
        Dim oProductDBIO As cMstProductDBIO
        Dim RecordCnt As Integer
        Dim Message_form As cMessageLib.fMessage

        oProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        KeyJANCode = oProductDBIO.readMaxJANCode(oTran)
        If KeyJANCode = Nothing Then
            KeyJANCode = "999" & String.Format("{0:000000000}", 1)
        Else
            KeyJANCode = "999" & String.Format("{0:000000000}", CLng(KeyJANCode.Substring(3, 9)) + 1)
        End If
        BUMON_CODE_T.Text = oTool.JANCD(KeyJANCode)

        '部門コードの重複確認
        RecordCnt = oBumonDBIO.getBumonMst(oBumon, BUMON_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
        If RecordCnt > 0 Then
            Message_form = New cMessageLib.fMessage(1, "部門マスタ上に重複した部門コードは登録できません。", _
                                "再度、部門コードを指定して下さい。", _
                                Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            Message_form = Nothing
            BUMON_CODE_T.Text = ""
            BUMON_CODE_T.Focus()
        End If

        oProductDBIO = Nothing
    End Sub

    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        ret = oBumonDBIO.deleteBumonMst(BUMON_CODE_T.Text, oTran)
        If ret = False Then
            Message_form = New cMessageLib.fMessage(1, "部門マスタの登録に失敗しました。", _
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
        System.Windows.Forms.Application.DoEvents()
        Message_form = Nothing

        CLOSE_PROC()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        ReDim oBumon(0)

        '部門コード
        oBumon(0).sBumonCode = BUMON_CODE_T.Text
        '部門名称
        oBumon(0).sBumonName = BUMON_NAME_T.Text
        '部門略称
        oBumon(0).sBumonShortName = BUMON_SHORT_NAME_T.Text
        '部門種別
        If PRODUCT_R.Checked = True Then
            oBumon(0).sBumonClass = 1
        Else
            oBumon(0).sBumonClass = 2
        End If
        '予約可否
        If RESERV_NO_R.Checked = True Then
            oBumon(0).sReservFlg = False
        Else
            oBumon(0).sReservFlg = True
        End If
        '予約単位
        If RESERV_YES_R.Checked = True Then
            If DAY_R.Checked = True Then
                oBumon(0).sReservPeace = "D"
            Else
                oBumon(0).sReservPeace = "H"
            End If
        Else
            oBumon(0).sReservPeace = ""
        End If
        '税区分
        If TAX_CLASS_CODE_T.Text = "" Then
            oBumon(0).sTaxClassCode = 0
        Else
            oBumon(0).sTaxClassCode = TAX_CLASS_CODE_T.Text
        End If

        If MODE_L.Text = "新規" Then
            ret = oBumonDBIO.insertBumonMst(oBumon(0), oTran)
        Else
            ret = oBumonDBIO.updateBumonMst(oBumon(0), oTran)
        End If
        If ret = False Then
            Message_form = New cMessageLib.fMessage(1, "部門マスタの登録に失敗しました。", _
                                            "システム管理者に連絡して下さい", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        Else
            Message_form = New cMessageLib.fMessage(1, Nothing, _
                                            "登録が完了しました。", _
                                            Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Message_form.ShowDialog()
        System.Windows.Forms.Application.DoEvents()
        Message_form = Nothing
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oBumonDBIO = Nothing
        oTaxClassDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        CLOSE_PROC()

    End Sub

    Private Sub RESERV_YES_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RESERV_YES_R.CheckedChanged
        If RESERV_YES_R.Checked = True Then
            DAY_R.Enabled = True
            TIME_R.Enabled = True
        Else
            DAY_R.Enabled = False
            TIME_R.Enabled = False
        End If
    End Sub

    Private Sub TAX_CLASS_B_Click(sender As Object, e As EventArgs) Handles TAX_CLASS_B.Click
        Dim fTaxClassSearch_form As cSelectLib.fTaxClassSearch

        fTaxClassSearch_form = New cSelectLib.fTaxClassSearch(oConn, oCommand, oDataReader, TAX_CLASS_NAME_T, 1, oTran)
        fTaxClassSearch_form.ShowDialog()
        TAX_CLASS_CODE_T.Text = fTaxClassSearch_form.S_TaxClassCode
        TAX_CLASS_NAME_T.Text = fTaxClassSearch_form.S_TaxClassName

        fTaxClassSearch_form = Nothing

    End Sub

    Private Sub BUMON_CODE_T_Leave(sender As Object, e As EventArgs) Handles BUMON_CODE_T.Leave
        Dim Message_form As cMessageLib.fMessage

        If BUMON_CODE_T.Text <> "" Then
            If oBumonDBIO.BumonExist(BUMON_CODE_T.Text, oTran) > 0 Then
                Message_form = New cMessageLib.fMessage(1, "部門コードは、既に登録済みです。", _
                                                "再度部門コードを入力して下さい。", _
                                                Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing

                BUMON_CODE_T.Text = ""
                BUMON_CODE_T.Focus()

            End If
        End If
    End Sub

    Private Sub TAX_CLASS_NAME_T_TextChanged(sender As Object, e As EventArgs) Handles TAX_CLASS_NAME_T.TextChanged

    End Sub

    Private Sub TAX_CLASS_CODE_T_TextChanged(sender As Object, e As EventArgs) Handles TAX_CLASS_CODE_T.TextChanged

    End Sub
End Class
