Public Class fAdjustCount
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oAdjust() As cStructureLib.sAdjust
    Private oAdjustDBIO As cDataAdjustDBIO

    Private oAccount() As cStructureLib.sAccount
    Private oAccountDBIO As cMstAccountDBIO

    Private oSubAccount() As cStructureLib.sSubAccount
    Private oSubAccountDBIO As cMstAccountSubDBIO

    Private oSupplier() As cStructureLib.sSupplier
    Private oSupplierDBIO As cMstSupplierDBIO

    Private oDrawer As cOPOSControlLib.cDrawer

    Private oCloseDate As String

    Private Proc_Mode As Integer
    Private OrgProc_Mode As Integer
    Private Init_Cnt As Integer
    Private LOAD_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：Mode : 1 入金
    '　　　　　　　 2 出金
    '　　　　　　　 3 精算
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal iCloseDate As String, _
            ByVal iStaffCode As String, _
            ByVal iStaffName As String, _
            ByVal Mode As Integer, _
            ByRef ioTran As System.Data.OleDb.OleDbTransaction)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oCloseDate = iCloseDate

        oTran = ioTran

        STAFF_CODE_T.Text = iStaffCode
        STAFF_NAME_T.Text = iStaffName

        LOAD_FLG = False

        Proc_Mode = Mode
        OrgProc_Mode = Mode

        Select Case Proc_Mode
            Case 0  'レジ入金
                REGI_INPUT_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = True
                INPUT_R.Enabled = True
                OUTPUT_R.Enabled = True
                ADJUST_R.Enabled = False

                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False

                COLLECTION_L.Visible = False
            Case 1  '入金
                INPUT_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = False
                INPUT_R.Enabled = True
                OUTPUT_R.Enabled = True
                ADJUST_R.Enabled = False

                'ACCOUNT_C.Enabled = False
                'SUB_ACCOUNT_C.Enabled = False
                COLLECTION_L.Visible = False

                '----------------------------------------------------
                '2015/06/25
                '及川和彦
                '入金時の勘定科目を選択するため、修正
                'FROM
                '----------------------------------------------------
                ACCOUNT_C.Enabled = True
                SUB_ACCOUNT_C.Enabled = True
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------


            Case 2  '出金
                OUTPUT_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = False
                INPUT_R.Enabled = True
                OUTPUT_R.Enabled = True
                ADJUST_R.Enabled = False

                ACCOUNT_C.Enabled = True
                SUB_ACCOUNT_C.Enabled = True
                COLLECTION_L.Visible = False
            Case 3  '精算
                ADJUST_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = False
                INPUT_R.Enabled = True
                OUTPUT_R.Enabled = True
                ADJUST_R.Enabled = True

                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False
                COLLECTION_L.Visible = False
            Case 4  '再精算
                ADJUST_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = False
                INPUT_R.Enabled = True
                OUTPUT_R.Enabled = True
                ADJUST_R.Enabled = True

                ACCOUNT_C.Enabled = False
                COLLECTION_L.Visible = False
            Case 5  '現金回収
                OUTPUT_R.ColorBottom = Drawing.Color.Red

                REGI_INPUT_R.Enabled = False
                INPUT_R.Enabled = False
                OUTPUT_R.Enabled = False
                ADJUST_R.Enabled = False

                ACCOUNT_C.Enabled = True
                SUB_ACCOUNT_C.Enabled = True
                COLLECTION_L.Visible = True
        End Select

        oAdjustDBIO = New cDataAdjustDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)
        oDrawer = New cOPOSControlLib.cDrawer(oConn, oCommand, oDataReader, oTran)

        Init_Cnt = 0
        LOAD_FLG = True


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
    Private Sub fAdjust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SeisanAdjustCode As Long
        Dim InCashAdjustCode As Long
        Dim ret As Boolean

        '----------------------- SoftGroup繝ｩ繧､繧ｻ繝ｳ繧ｹ隱崎ｨｼ ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '精算処理の必要性確認
        If Proc_Mode = 3 Then
            InCashAdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", Nothing, Nothing, oTran)
            SeisanAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)

            '「レジ入金」＜「精算」・・・最終精算後、次の入金が存在しない場合
            If InCashAdjustCode < SeisanAdjustCode Then
                '2016.07.21 K.Oikawa s
                'oAdjustDBIO.getAdjust(oAdjust, SeisanAdjustCode, SeisanAdjustCode, Nothing, Nothing, Nothing, oTran)

                '起動時は「-1」
                SeisanAdjustCode = SeisanAdjustCode - 1
                oAdjustDBIO.getAdjust(oAdjust, SeisanAdjustCode, Nothing, Nothing, Nothing, Nothing, oTran)
                '2016.07.21 K.Oikawa e

                TPRICE_T.Text = oAdjust(0).sTotalPrice
                CLOSE_PROC()
                Me.DialogResult = Windows.Forms.DialogResult.Abort
                Exit Sub
            End If
        End If

        '処理モード別初期値設定
        ret = False
        If INIT_PROC() = False Then
            Me.Close()
        End If

        '集計処理
        CAL_PROC()

        '勘定科目セット
        ACCOUNT_SET()

        'ドロワーオープン
        oDrawer.DrawerInit()

    End Sub

    '---------------------------------------------------------------------------
    '-------------------------< ドロワーイベント >------------------------------
    '---------------------------------------------------------------------------
    Private Sub D_Y1_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y1_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y5_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y5_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y10_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y10_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y50_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y50_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y100_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y100_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y500_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y500_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y1000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y1000_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y5000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y5000_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub D_Y10000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles D_Y10000_T.LostFocus
        CAL_PROC()
    End Sub


    '---------------------------------------------------------------------------
    '-------------------------< 金庫イベント >----------------------------------
    '---------------------------------------------------------------------------
    Private Sub K_Y1_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y1_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y5_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y5_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y10_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y10_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y50_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y50_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y100_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y100_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y500_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y500_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y1000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y1000_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y5000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y5000_T.LostFocus
        CAL_PROC()
    End Sub
    Private Sub K_Y10000_T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles K_Y10000_T.LostFocus
        CAL_PROC()
    End Sub
    '-----------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------
    Private Function INIT_PROC() As Boolean
        Dim InCashAdjustCode As Long
        Dim SeisanAdjustCode As Long
        Dim LastAdjustCode As Long
        Dim RecordCount As Long
        Dim i As Integer
        Dim ADD_MODE As Boolean

        LINK_MST_T.Text = ""
        ACCOUNT_CODE_T.Text = ""
        SUB_ACCOUNT_CODE_T.Text = ""

        oAccountDBIO = New cMstAccountDBIO(oConn, oCommand, oDataReader)
        oSubAccountDBIO = New cMstAccountSubDBIO(oConn, oCommand, oDataReader)
        oSupplierDBIO = New cMstSupplierDBIO(oConn, oCommand, oDataReader)

        '初期値設定
        D_Y1_T.Text = 0
        D_Y5_T.Text = 0
        D_Y10_T.Text = 0
        D_Y50_T.Text = 0
        D_Y100_T.Text = 0
        D_Y500_T.Text = 0
        D_Y1000_T.Text = 0
        D_Y5000_T.Text = 0
        D_Y10000_T.Text = 0

        K_Y1_T.Text = 0
        K_Y5_T.Text = 0
        K_Y10_T.Text = 0
        K_Y50_T.Text = 0
        K_Y100_T.Text = 0
        K_Y500_T.Text = 0
        K_Y1000_T.Text = 0
        K_Y5000_T.Text = 0
        K_Y10000_T.Text = 0

        ACCOUNT_CODE_T.Text = -1
        SUB_ACCOUNT_CODE_T.Text = -1

        InCashAdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", Nothing, Nothing, oTran)
        SeisanAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)

        Select Case Proc_Mode
            Case 0  'レジ入金モード
                ADD_MODE = False

                REGI_INPUT_R.BackColor = System.Drawing.Color.Salmon
                INPUT_R.BackColor = System.Drawing.Color.Tan
                OUTPUT_R.BackColor = System.Drawing.Color.Tan
                ADJUST_R.BackColor = System.Drawing.Color.Tan
                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False

                '「レジ入金」＜「精算」の場合・・・最終の精算以降入金がされていない場合
                'If SeisanAdjustCode > 0 And InCashAdjustCode > SeisanAdjustCode Then
                If InCashAdjustCode > SeisanAdjustCode Then
                    Dim Message_form As cMessageLib.fMessage
                    Message_form = New cMessageLib.fMessage(2, "精算処理が完了していません。", _
                                                    "追加の「レジ入金」を行いますか？", _
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    If Message_form.DialogResult = Windows.Forms.DialogResult.Yes Then
                        '追加「レジ入金」を行う場合
                        ADD_MODE = True
                    Else
                        '追加「レジ入金」を行わない場合
                        Message_form = Nothing
                        Message_form = New cMessageLib.fMessage(1, Nothing, _
                                                        "精算処理を行って下さい。", _
                                                        Nothing, Nothing)
                        Message_form.ShowDialog()
                        Message_form = Nothing
                        INIT_PROC = False
                        Exit Function
                    End If
                    Message_form = Nothing
                End If

                '最終の「精算」情報の取得
                LastAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran)
                RecordCount = oAdjustDBIO.getAdjust(oAdjust, SeisanAdjustCode, LastAdjustCode, Nothing, Nothing, Nothing, oTran)

                D_Y1_T.Text = 0
                D_Y5_T.Text = 0
                D_Y10_T.Text = 0
                D_Y50_T.Text = 0
                D_Y100_T.Text = 0
                D_Y500_T.Text = 0
                D_Y1000_T.Text = 0
                D_Y5000_T.Text = 0
                D_Y10000_T.Text = 0

                If RecordCount = 0 Then
                    K_Y1_T.Text = 0
                    K_Y5_T.Text = 0
                    K_Y10_T.Text = 0
                    K_Y50_T.Text = 0
                    K_Y100_T.Text = 0
                    K_Y500_T.Text = 0
                    K_Y1000_T.Text = 0
                    K_Y5000_T.Text = 0
                    K_Y10000_T.Text = 0
                Else
                    For i = 0 To RecordCount - 1
                        If oAdjust(i).sAdjustClass <> "レジ入金" Then
                            K_Y1_T.Text = CStr(CInt(K_Y1_T.Text) + oAdjust(i).sD1Yen + oAdjust(i).sK1Yen)
                            K_Y5_T.Text = CStr(CInt(K_Y5_T.Text) + oAdjust(i).sD5Yen + oAdjust(i).sK5Yen)
                            K_Y10_T.Text = CStr(CInt(K_Y10_T.Text) + oAdjust(i).sD10Yen + oAdjust(i).sK10Yen)
                            K_Y50_T.Text = CStr(CInt(K_Y50_T.Text) + oAdjust(i).sD50Yen + oAdjust(i).sK50Yen)
                            K_Y100_T.Text = CStr(CInt(K_Y100_T.Text) + oAdjust(i).sD100Yen + oAdjust(i).sK100Yen)
                            K_Y500_T.Text = CStr(CInt(K_Y500_T.Text) + oAdjust(i).sD500Yen + oAdjust(i).sK500Yen)
                            K_Y1000_T.Text = CStr(CInt(K_Y1000_T.Text) + oAdjust(i).sD1000Yen + oAdjust(i).sK1000Yen)
                            K_Y5000_T.Text = CStr(CInt(K_Y5000_T.Text) + oAdjust(i).sD5000Yen + oAdjust(i).sK5000Yen)
                            K_Y10000_T.Text = CStr(CInt(K_Y10000_T.Text) + oAdjust(i).sD10000Yen + oAdjust(i).sK10000Yen)

                            '----------------------------------------------------------------------------
                            'suzuki 2020/07/10 再レジ入金の計算が倍になる為の処理　from
                            '----------------------------------------------------------------------------
                        ElseIf ADD_MODE = False Then
                            '----------------------------------------------------------------------------
                            'suzuki 2020/07/10 再レジ入金の計算が倍になる為の処理　end
                            '----------------------------------------------------------------------------
                            K_Y1_T.Text = oAdjust(i).sK1Yen
                            K_Y5_T.Text = oAdjust(i).sK5Yen
                            K_Y10_T.Text = oAdjust(i).sK10Yen
                            K_Y50_T.Text = oAdjust(i).sK50Yen
                            K_Y100_T.Text = oAdjust(i).sK100Yen
                            K_Y500_T.Text = oAdjust(i).sK500Yen
                            K_Y1000_T.Text = oAdjust(i).sK1000Yen
                            K_Y5000_T.Text = oAdjust(i).sK5000Yen
                            K_Y10000_T.Text = oAdjust(i).sK10000Yen
                            A_TPRICE_T.Text = CStr(CLng(A_TPRICE_T.Text) + CLng(oAdjust(i).sDTotalPrice))
                        End If
                    Next i
                End If
            Case 1  '入金モード
                REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                INPUT_R.BackColor = System.Drawing.Color.Salmon
                OUTPUT_R.BackColor = System.Drawing.Color.Tan
                ADJUST_R.BackColor = System.Drawing.Color.Tan
                'ACCOUNT_C.Enabled = False
                'SUB_ACCOUNT_C.Enabled = False
                '----------------------------------------------------
                '2015/06/25
                '及川和彦
                '入金時の勘定科目を選択するため、修正
                'FROM
                '----------------------------------------------------
                ACCOUNT_C.Enabled = True
                SUB_ACCOUNT_C.Enabled = True
                '----------------------------------------------------
                'HERE
                '----------------------------------------------------


                D_Y1_T.Text = 0
                D_Y5_T.Text = 0
                D_Y10_T.Text = 0
                D_Y50_T.Text = 0
                D_Y100_T.Text = 0
                D_Y500_T.Text = 0
                D_Y1000_T.Text = 0
                D_Y5000_T.Text = 0
                D_Y10000_T.Text = 0

                If RecordCount = 0 Then
                    K_Y1_T.Text = 0
                    K_Y5_T.Text = 0
                    K_Y10_T.Text = 0
                    K_Y50_T.Text = 0
                    K_Y100_T.Text = 0
                    K_Y500_T.Text = 0
                    K_Y1000_T.Text = 0
                    K_Y5000_T.Text = 0
                    K_Y10000_T.Text = 0
                Else
                    K_Y1_T.Text = 0
                    K_Y5_T.Text = 0
                    K_Y10_T.Text = 0
                    K_Y50_T.Text = 0
                    K_Y100_T.Text = 0
                    K_Y500_T.Text = 0
                    K_Y1000_T.Text = 0
                    K_Y5000_T.Text = 0
                    K_Y10000_T.Text = 0
                End If
            Case 2  '出金モード
                REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                INPUT_R.BackColor = System.Drawing.Color.Tan
                OUTPUT_R.BackColor = System.Drawing.Color.Salmon
                ADJUST_R.BackColor = System.Drawing.Color.Tan
                ACCOUNT_C.Enabled = True
                SUB_ACCOUNT_C.Enabled = True

                D_Y1_T.Text = 0
                D_Y5_T.Text = 0
                D_Y10_T.Text = 0
                D_Y50_T.Text = 0
                D_Y100_T.Text = 0
                D_Y500_T.Text = 0
                D_Y1000_T.Text = 0
                D_Y5000_T.Text = 0
                D_Y10000_T.Text = 0

                K_Y1_T.Text = 0
                K_Y5_T.Text = 0
                K_Y10_T.Text = 0
                K_Y50_T.Text = 0
                K_Y100_T.Text = 0
                K_Y500_T.Text = 0
                K_Y1000_T.Text = 0
                K_Y5000_T.Text = 0
                K_Y10000_T.Text = 0
            Case 3  '精算モード
                REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                INPUT_R.BackColor = System.Drawing.Color.Tan
                OUTPUT_R.BackColor = System.Drawing.Color.Tan
                ADJUST_R.BackColor = System.Drawing.Color.Salmon
                ADJUST_R.Enabled = True
                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False

                InCashAdjustCode = oAdjustDBIO.readMaxAdjustCode("レジ入金", Nothing, Nothing, oTran)
                RecordCount = oAdjustDBIO.getAdjust(oAdjust, InCashAdjustCode, InCashAdjustCode, Nothing, Nothing, Nothing, oTran)
                For i = 0 To RecordCount - 1
                    D_Y1_T.Text = CLng(D_Y1_T.Text) + oAdjust(i).sD1Yen
                    D_Y5_T.Text = CLng(D_Y5_T.Text) + oAdjust(i).sD5Yen
                    D_Y10_T.Text = CLng(D_Y10_T.Text) + oAdjust(i).sD10Yen
                    D_Y50_T.Text = CLng(D_Y50_T.Text) + oAdjust(i).sD50Yen
                    D_Y100_T.Text = CLng(D_Y100_T.Text) + oAdjust(i).sD100Yen
                    D_Y500_T.Text = CLng(D_Y500_T.Text) + oAdjust(i).sD500Yen
                    D_Y1000_T.Text = CLng(D_Y1000_T.Text) + oAdjust(i).sD1000Yen
                    D_Y5000_T.Text = CLng(D_Y5000_T.Text) + oAdjust(i).sD5000Yen
                    D_Y10000_T.Text = CLng(D_Y10000_T.Text) + oAdjust(i).sD10000Yen

                    K_Y1_T.Text = CLng(K_Y1_T.Text) + oAdjust(i).sK1Yen
                    K_Y5_T.Text = CLng(K_Y5_T.Text) + oAdjust(i).sK5Yen
                    K_Y10_T.Text = CLng(K_Y10_T.Text) + oAdjust(i).sK10Yen
                    K_Y50_T.Text = CLng(K_Y50_T.Text) + oAdjust(i).sK50Yen
                    K_Y100_T.Text = CLng(K_Y100_T.Text) + oAdjust(i).sK100Yen
                    K_Y500_T.Text = CLng(K_Y500_T.Text) + oAdjust(i).sK500Yen
                    K_Y1000_T.Text = CLng(K_Y1000_T.Text) + oAdjust(i).sK1000Yen
                    K_Y5000_T.Text = CLng(K_Y5000_T.Text) + oAdjust(i).sK5000Yen
                    K_Y10000_T.Text = CLng(K_Y10000_T.Text) + oAdjust(i).sK10000Yen
                Next i

            Case 4  '精算モード（再入力の場合）
                REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                INPUT_R.BackColor = System.Drawing.Color.Tan
                OUTPUT_R.BackColor = System.Drawing.Color.Tan
                ADJUST_R.BackColor = System.Drawing.Color.Salmon
                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False

                SeisanAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
                RecordCount = oAdjustDBIO.getAdjust(oAdjust, SeisanAdjustCode, SeisanAdjustCode, Nothing, Nothing, Nothing, oTran)
                D_Y1_T.Text = CLng(D_Y1_T.Text) + oAdjust(i).sD1Yen
                D_Y5_T.Text = CLng(D_Y5_T.Text) + oAdjust(i).sD5Yen
                D_Y10_T.Text = CLng(D_Y10_T.Text) + oAdjust(i).sD10Yen
                D_Y50_T.Text = CLng(D_Y50_T.Text) + oAdjust(i).sD50Yen
                D_Y100_T.Text = CLng(D_Y100_T.Text) + oAdjust(i).sD100Yen
                D_Y500_T.Text = CLng(D_Y500_T.Text) + oAdjust(i).sD500Yen
                D_Y1000_T.Text = CLng(D_Y1000_T.Text) + oAdjust(i).sD1000Yen
                D_Y5000_T.Text = CLng(D_Y5000_T.Text) + oAdjust(i).sD5000Yen
                D_Y10000_T.Text = CLng(D_Y10000_T.Text) + oAdjust(i).sD10000Yen

                K_Y1_T.Text = CLng(K_Y1_T.Text) + oAdjust(i).sK1Yen
                K_Y5_T.Text = CLng(K_Y5_T.Text) + oAdjust(i).sK5Yen
                K_Y10_T.Text = CLng(K_Y10_T.Text) + oAdjust(i).sK10Yen
                K_Y50_T.Text = CLng(K_Y50_T.Text) + oAdjust(i).sK50Yen
                K_Y100_T.Text = CLng(K_Y100_T.Text) + oAdjust(i).sK100Yen
                K_Y500_T.Text = CLng(K_Y500_T.Text) + oAdjust(i).sK500Yen
                K_Y1000_T.Text = CLng(K_Y1000_T.Text) + oAdjust(i).sK1000Yen
                K_Y5000_T.Text = CLng(K_Y5000_T.Text) + oAdjust(i).sK5000Yen
                K_Y10000_T.Text = CLng(K_Y10000_T.Text) + oAdjust(i).sK10000Yen

            Case 5  '出金モード(現金回収)
                D_Y1_T.Text = 0
                D_Y5_T.Text = 0
                D_Y10_T.Text = 0
                D_Y50_T.Text = 0
                D_Y100_T.Text = 0
                D_Y500_T.Text = 0
                D_Y1000_T.Text = 0
                D_Y5000_T.Text = 0
                D_Y10000_T.Text = 0

                K_Y1_T.Text = 0
                K_Y5_T.Text = 0
                K_Y10_T.Text = 0
                K_Y50_T.Text = 0
                K_Y100_T.Text = 0
                K_Y500_T.Text = 0
                K_Y1000_T.Text = 0
                K_Y5000_T.Text = 0
                K_Y10000_T.Text = 0

                ACCOUNT_C.SelectedText = "現金振替"
                SUB_ACCOUNT_C.SelectedText = "現金回収"
                ACCOUNT_CODE_T.Text = 0
                SUB_ACCOUNT_CODE_T.Text = 0

        End Select

        Init_Cnt = Init_Cnt + 1

        INIT_PROC = True

    End Function
    Private Sub CAL_PROC()
        Dim D_TPrice As Long
        Dim A_TPrice As Long
        Dim K_TPrice As Long
        Dim TPrice As Long

        D_TPrice = 0
        D_TPrice = D_TPrice + CInt(D_Y1_T.Text) * 1
        D_TPrice = D_TPrice + CInt(D_Y5_T.Text) * 5
        D_TPrice = D_TPrice + CInt(D_Y10_T.Text) * 10
        D_TPrice = D_TPrice + CInt(D_Y50_T.Text) * 50
        D_TPrice = D_TPrice + CInt(D_Y100_T.Text) * 100
        D_TPrice = D_TPrice + CInt(D_Y500_T.Text) * 500
        D_TPrice = D_TPrice + CInt(D_Y1000_T.Text) * 1000
        D_TPrice = D_TPrice + CInt(D_Y5000_T.Text) * 5000
        D_TPrice = D_TPrice + CInt(D_Y10000_T.Text) * 10000

        A_TPrice = CLng(A_TPRICE_T.Text)
        A_TPRICE_T.Text = String.Format("{0:C}", A_TPrice)

        D_TPRICE_T.Text = String.Format("{0:C}", D_TPrice)

        K_TPrice = 0
        K_TPrice = K_TPrice + CInt(K_Y1_T.Text) * 1
        K_TPrice = K_TPrice + CInt(K_Y5_T.Text) * 5
        K_TPrice = K_TPrice + CInt(K_Y10_T.Text) * 10
        K_TPrice = K_TPrice + CInt(K_Y50_T.Text) * 50
        K_TPrice = K_TPrice + CInt(K_Y100_T.Text) * 100
        K_TPrice = K_TPrice + CInt(K_Y500_T.Text) * 500
        K_TPrice = K_TPrice + CInt(K_Y1000_T.Text) * 1000
        K_TPrice = K_TPrice + CInt(K_Y5000_T.Text) * 5000
        K_TPrice = K_TPrice + CInt(K_Y10000_T.Text) * 10000
        K_TPRICE_T.Text = String.Format("{0:C}", K_TPrice)

        TPrice = D_TPrice + A_TPrice + K_TPrice
        TPRICE_T.Text = String.Format("{0:C}", TPrice)
    End Sub


    '***************************
    '仕入先リストボックスセット
    '***************************
    Private Sub SUPPLIER_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '仕入先コンボ内容設定
        oSupplier = Nothing
        RecordCnt = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタが登録されていません", _
                                                "仕入先マスタを登録してください", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "仕入先マスタの読込みに失敗しました", _
                                                "開発元にお問い合わせ下さい", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        'リストボックスへの値セット
        For i = 0 To RecordCnt - 1
            SUB_ACCOUNT_C.Items.Add(oSupplier(i).sSupplierName)
        Next
        oDataReader = Nothing
        oSupplierDBIO = Nothing
    End Sub

    Private Sub ACCOUNT_SET()
        Dim i As Integer
        Dim RecordCount As Integer

        ReDim oAccount(0)
        RecordCount = oAccountDBIO.getAccount(oAccount, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        'リストボックスへの値セット
        For i = 0 To RecordCount - 1
            'Dim a As String
            'a = oSupplier(i).sSupplierName
            ACCOUNT_C.Items.Add(oAccount(i).sAccountName)
        Next
    End Sub


    Private Sub ACCOUNT_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACCOUNT_C.SelectedIndexChanged
        'Dim RecordCount As Integer
        'Dim i As Integer

        ''リストボックスの初期化
        'For i = 0 To SUB_ACCOUNT_C.Items.Count - 1
        '    SUB_ACCOUNT_C.Items.RemoveAt(0)
        'Next i
        'SUB_ACCOUNT_C.Refresh()

        'If ACCOUNT_C.Text <> "" Then
        '    RecordCount = oAccountDBIO.getNewAccountCode(oTran)
        '    'TODO:Select Index
        '    'ACCOUNT_CODE_T.Text = oAccount(0).sAccountCode
        '    ACCOUNT_CODE_T.Text = oAccount(DirectCast(sender, System.Windows.Forms.ComboBox).SelectedIndex).sAccountCode
        '    If oAccount(0).sLinkMasterName = "" Or oAccount(0).sLinkMasterName = Nothing Then
        '        LINK_MST_T.Text = ""
        '        ACCOUNT_SUB_SET(ACCOUNT_CODE_T.Text)
        '    Else
        '        LINK_MST_T.Text = oAccount(0).sLinkMasterName
        '        ACCOUNT_SUB_LINK_SET(oAccount(0).sLinkMasterName)

        '    End If
        'Else
        '    ACCOUNT_CODE_T.Text = -1
        'End If


        Dim RecordCount As Integer
        Dim i As Integer
        For i = 0 To SUB_ACCOUNT_C.Items.Count - 1
            SUB_ACCOUNT_C.Items.RemoveAt(0)
        Next i
        SUB_ACCOUNT_C.Refresh()
        If ACCOUNT_C.Text <> "" Then
            RecordCount = oAccountDBIO.getAccountCode(oAccount, ACCOUNT_C.Text, oTran)
            ACCOUNT_CODE_T.Text = oAccount(0).sAccountCode
            If oAccount(0).sLinkMasterName = "" Or oAccount(0).sLinkMasterName = Nothing Then
                LINK_MST_T.Text = ""
                ACCOUNT_SUB_SET(ACCOUNT_CODE_T.Text)
            Else
                LINK_MST_T.Text = oAccount(0).sLinkMasterName
                ACCOUNT_SUB_LINK_SET(oAccount(0).sLinkMasterName)
            End If
        Else
            ACCOUNT_CODE_T.Text = -1
        End If

    End Sub
    Private Sub SUBACCOUNT_C_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SUB_ACCOUNT_C.SelectedIndexChanged
        Dim RecordCount As Integer

        If SUB_ACCOUNT_C.Text <> "" Then
            If LINK_MST_T.Text <> "" Then
                RecordCount = oSupplierDBIO.getSupplierCode(oSupplier, SUB_ACCOUNT_C.Text, oTran)
                SUB_ACCOUNT_CODE_T.Text = oSupplier(0).sSupplierCode
            Else
                RecordCount = oSubAccountDBIO.getSubAccountCode(oSubAccount, ACCOUNT_C.Text, SUB_ACCOUNT_C.Text, oTran)
                SUB_ACCOUNT_CODE_T.Text = oSubAccount(0).sSubAccountCode
            End If
        Else
            SUB_ACCOUNT_CODE_T.Text = -1
        End If

    End Sub

    Private Sub ACCOUNT_SUB_SET(ByVal KeyAccountCode As Integer)
        Dim i As Integer
        Dim RecordCount As Integer

        ReDim oSubAccount(0)
        RecordCount = oSubAccountDBIO.getSubAccount(oSubAccount, KeyAccountCode, -1, oTran)

        'リストボックスへの値セット
        For i = 0 To RecordCount - 1
            SUB_ACCOUNT_C.Items.Add(oSubAccount(i).sSubAccountName)
            'SUB_ACCOUNT_C.Items.Add(oSubAccount(i).sSubAccountName)
        Next
        If RecordCount > 0 Then
            SUB_ACCOUNT_C.Enabled = True
        End If
    End Sub

    Private Sub ACCOUNT_SUB_LINK_SET(ByVal MstName As String)
        Dim i As Integer
        Dim RecordCount As Integer

        Select Case MstName
            Case "仕入先マスタ"

                Dim oSupplier() As cStructureLib.sSupplier

                ReDim oSupplier(0)
                RecordCount = oSupplierDBIO.getSupplier(oSupplier, Nothing, Nothing, oTran)

                'リストボックスへの値セット
                For i = 0 To RecordCount - 1
                    SUB_ACCOUNT_C.Items.Add(oSupplier(i).sSupplierName)
                Next
                If RecordCount > 0 Then
                    SUB_ACCOUNT_C.Enabled = True
                End If

        End Select
    End Sub
    Private Sub CLOSE_PROC()
        oAccountDBIO = Nothing
        oSubAccountDBIO = Nothing
        oSupplierDBIO = Nothing
        oAdjustDBIO = Nothing
    End Sub

    Private Sub ADJUST_G_CHANGE(ByRef sender As System.Object)
        Dim ret As Boolean
        If LOAD_FLG = True Then
            If sender.textButton = "レジ入金" Then             'レジ入金
                Proc_Mode = 1
                ACCOUNT_C.Enabled = False
                SUB_ACCOUNT_C.Enabled = False

                'ボタンバックカラー調整
                REGI_INPUT_R.BackColor = System.Drawing.Color.Salmon
                INPUT_R.BackColor = System.Drawing.Color.Tan
                OUTPUT_R.BackColor = System.Drawing.Color.Tan
                ADJUST_R.BackColor = System.Drawing.Color.Tan
                Proc_Mode = 0
            Else
                If INPUT_R.ColorBottom = Drawing.Color.Red Then              '入金
                    '勘定科目コンボボックスコントロール
                    ACCOUNT_C.Enabled = False
                    SUB_ACCOUNT_C.Enabled = False

                    'ボタンバックカラー調整
                    REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                    INPUT_R.BackColor = System.Drawing.Color.Salmon
                    OUTPUT_R.BackColor = System.Drawing.Color.Tan
                    ADJUST_R.BackColor = System.Drawing.Color.Tan
                    Proc_Mode = 1
                Else
                    If OUTPUT_R.ColorBottom = Drawing.Color.Red Then         '出金
                        ACCOUNT_C.Enabled = True
                        SUB_ACCOUNT_C.Enabled = False

                        'ボタンバックカラー調整
                        REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                        INPUT_R.BackColor = System.Drawing.Color.Tan
                        OUTPUT_R.BackColor = System.Drawing.Color.Salmon
                        ADJUST_R.BackColor = System.Drawing.Color.Tan
                        Proc_Mode = 2
                    Else
                        If ADJUST_R.ColorBottom = Drawing.Color.Red Then     '精算
                            ACCOUNT_C.Enabled = False
                            SUB_ACCOUNT_C.Enabled = False

                            'ボタンバックカラー調整
                            REGI_INPUT_R.BackColor = System.Drawing.Color.Tan
                            INPUT_R.BackColor = System.Drawing.Color.Tan
                            OUTPUT_R.BackColor = System.Drawing.Color.Tan
                            ADJUST_R.BackColor = System.Drawing.Color.Salmon
                            Proc_Mode = 3
                        End If
                    End If
                End If
            End If
            ret = False
            If LOAD_FLG = True Then
                While ret = False
                    ret = INIT_PROC()
                End While
                CAL_PROC()
            End If
        End If
    End Sub

    Private Sub REGI_INPUT_R_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ADJUST_G_CHANGE(sender)
    End Sub
    Private Sub INPUT_R_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ADJUST_G_CHANGE(sender)
    End Sub
    Private Sub OUTPUT_R_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ADJUST_G_CHANGE(sender)
    End Sub
    Private Sub RETURN_R_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ADJUST_G_CHANGE(sender)
    End Sub
    Private Sub ADJUST_R_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ADJUST_G_CHANGE(sender)
    End Sub

    '**************************************************
    'ドローワーオープン
    '[引数]
    '   なし
    '[戻り値]
    '   なし
    '**************************************************

    Sub DROWER_OPEN()
        oDrawer.OpenDrawer()
    End Sub
    Private Sub D_Y10000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y10000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y10000_T.Text) > 0 Then
                D_Y10000_T.Text = CInt(D_Y10000_T.Text) + 1
                K_Y10000_T.Text = CInt(K_Y10000_T.Text) - 1
            End If
        Else
            D_Y10000_T.Text = CInt(D_Y10000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y5000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y5000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y5000_T.Text) > 0 Then
                D_Y5000_T.Text = CInt(D_Y5000_T.Text) + 1
                K_Y5000_T.Text = CInt(K_Y5000_T.Text) - 1
            End If
        Else
            D_Y5000_T.Text = CInt(D_Y5000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y1000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y1000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y1000_T.Text) > 0 Then
                D_Y1000_T.Text = CInt(D_Y1000_T.Text) + 1
                K_Y1000_T.Text = CInt(K_Y1000_T.Text) - 1
            End If
        Else
            D_Y1000_T.Text = CInt(D_Y1000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y500_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y500_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y500_T.Text) > 0 Then
                D_Y500_T.Text = CInt(D_Y500_T.Text) + 1
                K_Y500_T.Text = CInt(K_Y500_T.Text) - 1
            End If
        Else
            D_Y500_T.Text = CInt(D_Y500_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y100_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y100_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y100_T.Text) > 0 Then
                D_Y100_T.Text = CInt(D_Y100_T.Text) + 1
                K_Y100_T.Text = CInt(K_Y100_T.Text) - 1
            End If
        Else
            D_Y100_T.Text = CInt(D_Y100_T.Text) + 1
        End If
        CAL_PROC()

    End Sub
    Private Sub D_Y50_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y50_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y50_T.Text) > 0 Then
                D_Y50_T.Text = CInt(D_Y50_T.Text) + 1
                K_Y50_T.Text = CInt(K_Y50_T.Text) - 1
            End If
        Else
            D_Y50_T.Text = CInt(D_Y50_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y10_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y10_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y10_T.Text) > 0 Then
                D_Y10_T.Text = CInt(D_Y10_T.Text) + 1
                K_Y10_T.Text = CInt(K_Y10_T.Text) - 1
            End If
        Else
            D_Y10_T.Text = CInt(D_Y10_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y5_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y5_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y5_T.Text) > 0 Then
                D_Y5_T.Text = CInt(D_Y5_T.Text) + 1
                K_Y5_T.Text = CInt(K_Y5_T.Text) - 1
            End If
        Else
            D_Y5_T.Text = CInt(D_Y5_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y1_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y1_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y1_T.Text) > 0 Then
                D_Y1_T.Text = CInt(D_Y1_T.Text) + 1
                K_Y1_T.Text = CInt(K_Y1_T.Text) - 1
            End If
        Else
            D_Y1_T.Text = CInt(D_Y1_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y10000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y10000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y10000_T.Text) > 0 Then
                D_Y10000_T.Text = CInt(D_Y10000_T.Text) - 1
                K_Y10000_T.Text = CInt(K_Y10000_T.Text) + 1
            End If
        Else
            If CInt(D_Y10000_T.Text) > 0 Then
                D_Y10000_T.Text = CInt(D_Y10000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y5000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y5000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y5000_T.Text) > 0 Then
                D_Y5000_T.Text = CInt(D_Y5000_T.Text) - 1
                K_Y5000_T.Text = CInt(K_Y5000_T.Text) + 1
            End If
        Else
            If CInt(D_Y5000_T.Text) > 0 Then
                D_Y5000_T.Text = CInt(D_Y5000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y1000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y1000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y1000_T.Text) > 0 Then
                D_Y1000_T.Text = CInt(D_Y1000_T.Text) - 1
                K_Y1000_T.Text = CInt(K_Y1000_T.Text) + 1
            End If
        Else
            If CInt(D_Y1000_T.Text) > 0 Then
                D_Y1000_T.Text = CInt(D_Y1000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y500_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y500_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y500_T.Text) > 0 Then
                D_Y500_T.Text = CInt(D_Y500_T.Text) - 1
                K_Y500_T.Text = CInt(K_Y500_T.Text) + 1
            End If
        Else
            If CInt(D_Y500_T.Text) > 0 Then
                D_Y500_T.Text = CInt(D_Y500_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y100_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y100_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y100_T.Text) > 0 Then
                D_Y100_T.Text = CInt(D_Y100_T.Text) - 1
                K_Y100_T.Text = CInt(K_Y100_T.Text) + 1
            End If
        Else
            If CInt(D_Y100_T.Text) > 0 Then
                D_Y100_T.Text = CInt(D_Y100_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y50_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y50_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y50_T.Text) > 0 Then
                D_Y50_T.Text = CInt(D_Y50_T.Text) - 1
                K_Y50_T.Text = CInt(K_Y50_T.Text) + 1
            End If
        Else
            If CInt(D_Y50_T.Text) > 0 Then
                D_Y50_T.Text = CInt(D_Y50_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y10_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y10_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y10_T.Text) > 0 Then
                D_Y10_T.Text = CInt(D_Y10_T.Text) - 1
                K_Y10_T.Text = CInt(K_Y10_T.Text) + 1
            End If
        Else
            If CInt(D_Y10_T.Text) > 0 Then
                D_Y10_T.Text = CInt(D_Y10_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y5_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y5_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y5_T.Text) > 0 Then
                D_Y5_T.Text = CInt(D_Y5_T.Text) - 1
                K_Y5_T.Text = CInt(K_Y5_T.Text) + 1
            End If
        Else
            If CInt(D_Y5_T.Text) > 0 Then
                D_Y5_T.Text = CInt(D_Y5_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub D_Y1_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D_Y1_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y1_T.Text) > 0 Then
                D_Y1_T.Text = CInt(D_Y1_T.Text) - 1
                K_Y1_T.Text = CInt(K_Y1_T.Text) + 1
            End If
        Else
            If CInt(D_Y1_T.Text) > 0 Then
                D_Y1_T.Text = CInt(D_Y1_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub REGI_INPUT_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGI_INPUT_R.Click
        ADJUST_G_CHANGE(sender)

    End Sub

    Private Sub INPUT_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INPUT_R.Click
        ADJUST_G_CHANGE(sender)

    End Sub

    Private Sub OUTPUT_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUTPUT_R.Click
        ADJUST_G_CHANGE(sender)

    End Sub

    Private Sub ADJUST_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADJUST_R.Click
        ADJUST_G_CHANGE(sender)

    End Sub

    Private Sub K_Y10000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y10000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y10000_T.Text) > 0 Then
                K_Y10000_T.Text = CInt(K_Y10000_T.Text) + 1
                D_Y10000_T.Text = CInt(D_Y10000_T.Text) - 1
            End If
        Else
            K_Y10000_T.Text = CInt(K_Y10000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y10000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y10000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y10000_T.Text) > 0 Then
                K_Y10000_T.Text = CInt(K_Y10000_T.Text) - 1
                D_Y10000_T.Text = CInt(D_Y10000_T.Text) + 1
            End If
        Else
            If CInt(K_Y10000_T.Text) > 0 Then
                K_Y10000_T.Text = CInt(K_Y10000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y5000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y5000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y5000_T.Text) > 0 Then
                K_Y5000_T.Text = CInt(K_Y5000_T.Text) + 1
                D_Y5000_T.Text = CInt(D_Y5000_T.Text) - 1
            End If
        Else
            K_Y5000_T.Text = CInt(K_Y5000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y5000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y5000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y5000_T.Text) > 0 Then
                K_Y5000_T.Text = CInt(K_Y5000_T.Text) - 1
                D_Y5000_T.Text = CInt(D_Y5000_T.Text) + 1
            End If
        Else
            If CInt(K_Y5000_T.Text) > 0 Then
                K_Y5000_T.Text = CInt(K_Y5000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y1000_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y1000_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y1000_T.Text) > 0 Then
                K_Y1000_T.Text = CInt(K_Y1000_T.Text) + 1
                D_Y1000_T.Text = CInt(D_Y1000_T.Text) - 1
            End If
        Else
            K_Y1000_T.Text = CInt(K_Y1000_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y1000_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y1000_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y1000_T.Text) > 0 Then
                K_Y1000_T.Text = CInt(K_Y1000_T.Text) - 1
                D_Y1000_T.Text = CInt(D_Y1000_T.Text) + 1
            End If
        Else
            If CInt(K_Y1000_T.Text) > 0 Then
                K_Y1000_T.Text = CInt(K_Y1000_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y500_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y500_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y500_T.Text) > 0 Then
                K_Y500_T.Text = CInt(K_Y500_T.Text) + 1
                D_Y500_T.Text = CInt(D_Y500_T.Text) - 1
            End If
        Else
            K_Y500_T.Text = CInt(K_Y500_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y500_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y500_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y500_T.Text) > 0 Then
                K_Y500_T.Text = CInt(K_Y500_T.Text) - 1
                D_Y500_T.Text = CInt(D_Y500_T.Text) + 1
            End If
        Else
            If CInt(K_Y500_T.Text) > 0 Then
                K_Y500_T.Text = CInt(K_Y500_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y100_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y100_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y100_T.Text) > 0 Then
                K_Y100_T.Text = CInt(K_Y100_T.Text) + 1
                D_Y100_T.Text = CInt(D_Y100_T.Text) - 1
            End If
        Else
            K_Y100_T.Text = CInt(K_Y100_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y100_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y100_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y100_T.Text) > 0 Then
                K_Y100_T.Text = CInt(K_Y100_T.Text) - 1
                D_Y100_T.Text = CInt(D_Y100_T.Text) + 1
            End If
        Else
            If CInt(K_Y100_T.Text) > 0 Then
                K_Y100_T.Text = CInt(K_Y100_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y50_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y50_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y50_T.Text) > 0 Then
                K_Y50_T.Text = CInt(K_Y50_T.Text) + 1
                D_Y50_T.Text = CInt(D_Y50_T.Text) - 1
            End If
        Else
            K_Y50_T.Text = CInt(K_Y50_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y50_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y50_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y50_T.Text) > 0 Then
                K_Y50_T.Text = CInt(K_Y50_T.Text) - 1
                D_Y50_T.Text = CInt(D_Y50_T.Text) + 1
            End If
        Else
            If CInt(K_Y50_T.Text) > 0 Then
                K_Y50_T.Text = CInt(K_Y50_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y10_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y10_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y10_T.Text) > 0 Then
                K_Y10_T.Text = CInt(K_Y10_T.Text) + 1
                D_Y10_T.Text = CInt(D_Y10_T.Text) - 1
            End If
        Else
            K_Y10_T.Text = CInt(K_Y10_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y10_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y10_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y10_T.Text) > 0 Then
                K_Y10_T.Text = CInt(K_Y10_T.Text) - 1
                D_Y10_T.Text = CInt(D_Y10_T.Text) + 1
            End If
        Else
            If CInt(K_Y10_T.Text) > 0 Then
                K_Y10_T.Text = CInt(K_Y10_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y5_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y5_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y5_T.Text) > 0 Then
                K_Y5_T.Text = CInt(K_Y5_T.Text) + 1
                D_Y5_T.Text = CInt(D_Y5_T.Text) - 1
            End If
        Else
            K_Y5_T.Text = CInt(K_Y5_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y5_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y5_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y5_T.Text) > 0 Then
                K_Y5_T.Text = CInt(K_Y5_T.Text) - 1
                D_Y5_T.Text = CInt(D_Y5_T.Text) + 1
            End If
        Else
            If CInt(K_Y5_T.Text) > 0 Then
                K_Y5_T.Text = CInt(K_Y5_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y1_P_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y1_P_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(D_Y1_T.Text) > 0 Then
                K_Y1_T.Text = CInt(K_Y1_T.Text) + 1
                D_Y1_T.Text = CInt(D_Y1_T.Text) - 1
            End If
        Else
            K_Y1_T.Text = CInt(K_Y1_T.Text) + 1
        End If
        CAL_PROC()

    End Sub

    Private Sub K_Y1_M_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K_Y1_M_B.Click
        Beep()
        If Proc_Mode = 0 Then
            If CInt(K_Y1_T.Text) > 0 Then
                K_Y1_T.Text = CInt(K_Y1_T.Text) - 1
                D_Y1_T.Text = CInt(D_Y1_T.Text) + 1
            End If
        Else
            If CInt(K_Y1_T.Text) > 0 Then
                K_Y1_T.Text = CInt(K_Y1_T.Text) - 1
            End If
        End If
        CAL_PROC()

    End Sub

    Private Sub DRWER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DRWER_B.Click
        'ドローワーオープン
        DROWER_OPEN()

    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim FromAdjustCode As String
        Dim ToAdjustCode As String
        Dim i As Integer
        Dim cnt As Integer
        Dim oTranOn As Boolean

        'トランザクションの開始
        oTranOn = False
        If IsDBNull(oTran) <> False Then
            oTran = oConn.BeginTransaction
            oTranOn = True
        End If
        If Proc_Mode = 4 Then   '再精算処理の場合
            '削除対象の精算コード取得
            FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
            ToAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran)
            '精算データ削除
            cnt = 0
            For i = FromAdjustCode To ToAdjustCode
                If oAdjustDBIO.deleteAdjust(i, oTran) = True Then
                    cnt = cnt + 1
                End If
            Next i
            If cnt = ToAdjustCode - FromAdjustCode + 1 Then
                If oTranOn = True Then
                    oTran.Commit()
                    oTran = Nothing
                End If
            Else
                If oTranOn = True Then
                    oTran.Rollback()
                    oTran = Nothing
                End If
            End If
        End If

        oAccountDBIO = Nothing
        oSubAccountDBIO = Nothing
        oSupplierDBIO = Nothing
        oAdjustDBIO = Nothing
        Me.Close()

    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim OPE As Integer
        Dim FromAdjustCode As Long
        Dim ToAdjustCode As Long
        Dim oTranOn As Boolean

        oAdjust = Nothing
        ReDim Preserve oAdjust(1)

        oTranOn = False
        If IsDBNull(oTran) <> False Then
            'トランザクションの開始
            oTran = Nothing
            oTran = oConn.BeginTransaction
            oTranOn = True
        End If

        If Proc_Mode = 4 Then   '再精算処理の場合
            '削除対象の精算コード取得
            FromAdjustCode = oAdjustDBIO.readMaxAdjustCode("精算", Nothing, Nothing, oTran)
            ToAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran)
            '精算データ削除
            For i = FromAdjustCode To ToAdjustCode
                oAdjustDBIO.deleteAdjust(i, oTran)
            Next i
        End If

        oAdjust(0).sAdjustCode = oAdjustDBIO.readMaxAdjustCode(Nothing, Nothing, Nothing, oTran) + 1    '精算コード
        '精算区分
        If REGI_INPUT_R.ColorBottom = Drawing.Color.Red Then
            oAdjust(0).sAdjustClass = "レジ入金"
            OPE = 1
        Else
            If INPUT_R.ColorBottom = Drawing.Color.Red Then
                'oAdjust(0).sAdjustClass = "入金"
                'OPE = 1

                '----------------------------------------------------
                '2020/07/10
                'suzuki
                '勘定科目、補助勘定科目が―を選択した場合、メッセージ追加
                'FROM
                '----------------------------------------------------

                '----------------------------------------------------
                '2015/06/25
                '及川和彦
                '入金時の勘定科目が空の場合、メッセージを出すため追加
                'FROM
                '----------------------------------------------------
                'If ACCOUNT_C.Text = ""Then
                If ACCOUNT_C.Text = "" Or ACCOUNT_C.Text = "－" Then
                    'メッセージウィンドウ表示
                    Dim Message_form As cMessageLib.fMessage
                    Message_form = New cMessageLib.fMessage(1, Nothing,
                                                    "入金対象の勘定科目を指定して下さい。",
                                                    Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form = Nothing
                    ACCOUNT_C.Focus()
                    If oTranOn = True Then
                        oTran = Nothing
                    End If
                    Exit Sub
                End If
                'If SUB_ACCOUNT_C.Text = "" Then
                If SUB_ACCOUNT_C.Text = "" Or ACCOUNT_C.Text = "－" Then
                        'メッセージウィンドウ表示
                        Dim Message_form As cMessageLib.fMessage
                        Message_form = New cMessageLib.fMessage(1, Nothing,
                                                    "入金対象の補助勘定科目を指定して下さい。",
                                                    Nothing, Nothing)
                        Message_form.ShowDialog()
                        Message_form = Nothing
                        SUB_ACCOUNT_C.Focus()
                        If oTranOn = True Then
                            oTran = Nothing
                            Exit Sub
                        End If
                    End If
                    oAdjust(0).sAdjustClass = "入金"
                    OPE = 1
                    '----------------------------------------------------
                    'HERE
                    '----------------------------------------------------


                Else
                    If OUTPUT_R.ColorBottom = Drawing.Color.Red Or COLLECTION_L.Visible = True Then
                    If ACCOUNT_C.Text = "" Or ACCOUNT_C.Text = "－" Then
                        'メッセージウィンドウ表示
                        Dim Message_form As cMessageLib.fMessage
                        Message_form = New cMessageLib.fMessage(1, Nothing,
                                                        "出金対象の勘定科目を指定して下さい。",
                                                        Nothing, Nothing)
                        Message_form.ShowDialog()
                        Message_form = Nothing
                        ACCOUNT_C.Focus()
                        If oTranOn = True Then
                            oTran = Nothing
                        End If
                        Exit Sub
                    End If
                    If SUB_ACCOUNT_C.Text = "" Or ACCOUNT_C.Text = "－" Then
                        'メッセージウィンドウ表示
                        Dim Message_form As cMessageLib.fMessage
                        Message_form = New cMessageLib.fMessage(1, Nothing,
                                                        "出金対象の補助勘定科目を指定して下さい。",
                                                        Nothing, Nothing)
                        Message_form.ShowDialog()
                        Message_form = Nothing
                        SUB_ACCOUNT_C.Focus()
                        If oTranOn = True Then
                            oTran = Nothing
                            Exit Sub
                        End If
                    End If
                    oAdjust(0).sAdjustClass = "出金"
                    OPE = -1
                Else
                    oAdjust(0).sAdjustClass = "精算"
                    OPE = 1
                End If
                '----------------------------------------------------
                '2020/07/10
                'suzuki
                '勘定科目、補助勘定科目が―を選択した場合、メッセージ追加
                'end
                '----------------------------------------------------
            End If
        End If

        '精算日
        oAdjust(0).sAdjustDate = oCloseDate

        '金額
        oAdjust(0).sTotalPrice = CLng(TPRICE_T.Text) * OPE

        '勘定科目コード
        oAdjust(0).sAccountCode = CInt(ACCOUNT_CODE_T.Text)

        '補助勘定科目コード
        oAdjust(0).sSubAccountCode = CInt(SUB_ACCOUNT_CODE_T.Text)

        'レジ（ドロワー）入金
        oAdjust(0).sDTotalPrice = CLng(D_TPRICE_T.Text) * OPE
        oAdjust(0).sD10000Yen = CInt(D_Y10000_T.Text) * OPE
        oAdjust(0).sD5000Yen = CInt(D_Y5000_T.Text) * OPE
        oAdjust(0).sD1000Yen = CInt(D_Y1000_T.Text) * OPE
        oAdjust(0).sD500Yen = CInt(D_Y500_T.Text) * OPE
        oAdjust(0).sD100Yen = CInt(D_Y100_T.Text) * OPE
        oAdjust(0).sD50Yen = CInt(D_Y50_T.Text) * OPE
        oAdjust(0).sD10Yen = CInt(D_Y10_T.Text) * OPE
        oAdjust(0).sD5Yen = CInt(D_Y5_T.Text) * OPE
        oAdjust(0).sD1Yen = CInt(D_Y1_T.Text) * OPE
        '金庫入金
        oAdjust(0).sKTotalPrice = CLng(K_TPRICE_T.Text) * OPE
        oAdjust(0).sK10000Yen = CInt(K_Y10000_T.Text) * OPE
        oAdjust(0).sK5000Yen = CInt(K_Y5000_T.Text) * OPE
        oAdjust(0).sK1000Yen = CInt(K_Y1000_T.Text) * OPE
        oAdjust(0).sK500Yen = CInt(K_Y500_T.Text) * OPE
        oAdjust(0).sK100Yen = CInt(K_Y100_T.Text) * OPE
        oAdjust(0).sK50Yen = CInt(K_Y50_T.Text) * OPE
        oAdjust(0).sK10Yen = CInt(K_Y10_T.Text) * OPE
        oAdjust(0).sK5Yen = CInt(K_Y5_T.Text) * OPE
        oAdjust(0).sK1Yen = CInt(K_Y1_T.Text) * OPE

        oAdjust(0).sAdjustStaffCode = STAFF_CODE_T.Text

        If oAdjustDBIO.insertAdjust(oAdjust(0), oTran) = True Then
            If oTranOn = True Then
                oTran.Commit()
                oTran = Nothing
            End If
        Else
            If oTranOn = True Then
                oTran.Commit()
                oTran = Nothing
            End If

        End If

        If Proc_Mode = OrgProc_Mode Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Proc_Mode = OrgProc_Mode
            Select Case Proc_Mode
                Case 0
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Red
                    INPUT_R.ColorBottom = Drawing.Color.Tan
                    OUTPUT_R.ColorBottom = Drawing.Color.Tan
                    ADJUST_R.ColorBottom = Drawing.Color.Tan
                Case 1
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Tan
                    INPUT_R.ColorBottom = Drawing.Color.Red
                    OUTPUT_R.ColorBottom = Drawing.Color.Tan
                    ADJUST_R.ColorBottom = Drawing.Color.Tan
                Case 2
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Tan
                    INPUT_R.ColorBottom = Drawing.Color.Tan
                    OUTPUT_R.ColorBottom = Drawing.Color.Red
                    ADJUST_R.ColorBottom = Drawing.Color.Tan
                Case 3
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Tan
                    INPUT_R.ColorBottom = Drawing.Color.Tan
                    OUTPUT_R.ColorBottom = Drawing.Color.Tan
                    ADJUST_R.ColorBottom = Drawing.Color.Red
                Case 4
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Tan
                    INPUT_R.ColorBottom = Drawing.Color.Tan
                    OUTPUT_R.ColorBottom = Drawing.Color.Red
                    ADJUST_R.ColorBottom = Drawing.Color.Tan
                Case 5
                    REGI_INPUT_R.ColorBottom = Drawing.Color.Tan
                    INPUT_R.ColorBottom = Drawing.Color.Tan
                    OUTPUT_R.ColorBottom = Drawing.Color.Tan
                    ADJUST_R.ColorBottom = Drawing.Color.Red
            End Select
            INIT_PROC()
        End If

    End Sub
End Class