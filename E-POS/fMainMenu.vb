
Public Class fMainMenu
    Private oConn As System.Data.OleDb.OleDbConnection
    Private oCommand As System.Data.OleDb.OleDbCommand
    Private oDataReader As System.Data.OleDb.OleDbDataReader

    Private oTool As cTool

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private strPath As String
    Private oTran As System.Data.OleDb.OleDbTransaction
    Sub New()
        Dim StrPath As String
        Dim DB_Path As String
        Dim ret As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        oTool = New cTool

        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        If System.IO.File.Exists(DB_Path & "\OwP-DB.mdb") Then
            StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
            oConn = New System.Data.OleDb.OleDbConnection(StrPath)

            'ＤＢ接続を開く
            oConn.Open()

            oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
            ret = oMstConfigDBIO.getConfMst(oConf, oTran)
            oMstConfigDBIO = Nothing
        End If
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

    Private Sub fMainMenu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F2 Then
            If e.Shift Then
                SYSTEM_TOP_L.Visible = True
                SYSTEM_BOTTOM_L.Visible = True

                SYSTEM_G.Enabled = True
                'CONFIG_MST_B.Enabled = True
                'CATEGORY_MST_B.Enabled = True
                'STOCK_MST_B.Enabled = True
            Else
                If e.Alt Then
                    SYSTEM_TOP_L.Visible = False
                    SYSTEM_BOTTOM_L.Visible = False

                    SYSTEM_G.Enabled = False
                    'CONFIG_MST_B.Enabled = False
                    'CATEGORY_MST_B.Enabled = False
                    'STOCK_MST_B.Enabled = False
                End If
            End If
        End If


    End Sub


    ''' <summary>
    ''' フォームに配置されているコントロールを名前で探す
    ''' （フォームクラスのフィールドをフィールド名で探す）
    ''' </summary>
    ''' <param name="frm">コントロールを探すフォーム</param>
    ''' <param name="name">コントロール（フィールド）の名前</param>
    ''' <returns>見つかった時は、コントロールのオブジェクト。
    ''' 見つからなかった時は、null(VB.NETではNothing)。</returns>
    Public Shared Function FindControlByFieldName( _
        ByVal frm As Form, ByVal name As String) As Object
        'まずプロパティ名を探し、見つからなければフィールド名を探す
        Dim t As System.Type = frm.GetType()

        Dim pi As System.Reflection.PropertyInfo = _
            t.GetProperty(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If Not pi Is Nothing Then
            Return pi.GetValue(frm, Nothing)
        End If

        Dim fi As System.Reflection.FieldInfo = _
            t.GetField(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If fi Is Nothing Then
            Return Nothing
        End If

        Return fi.GetValue(frm)
    End Function
    Private Sub fMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCount As Integer
        Dim oApplication() As cStructureLib.sApplication
        Dim oMstApplicationDBIO As New cMstApplicationDBIO(oConn, oCommand, oDataReader)
        Dim i As Integer
        Dim cs() As Control

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        'フォームでキーボードイベントを認識()
        Me.KeyPreview = True

        SYSTEM_TOP_L.Visible = False
        SYSTEM_BOTTOM_L.Visible = False

        CONFIG_MST_B.Enabled = False
        CATEGORY_MST_B.Enabled = False
        STOCK_MST_B.Enabled = False

        'プログラム起動フォルダパスの取得
        strPath = Application.StartupPath

        ReDim oApplication(0)
        RecordCount = oMstApplicationDBIO.getApplication(oApplication, Nothing, Nothing, Nothing, Nothing, oTran)
        For i = 0 To RecordCount - 1
            cs = Me.Controls.Find(oApplication(i).sControlName, True)
            If cs.Length > 0 Then
                If System.IO.File.Exists(strPath & "\" & oApplication(i).sExeName) = True Then
                    CType(cs(0), Softgroup.NetButton.NetButton).Enabled = True
                Else
                    CType(cs(0), Softgroup.NetButton.NetButton).Enabled = False
                End If
            End If
        Next
        oMstApplicationDBIO = Nothing
        oApplication = Nothing
    End Sub

    '****************************
    '*          販売管理        *
    '****************************
    Private Sub REG_OPEN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REG_OPEN_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-RegOpen.exe"
        process1.Start()

    End Sub

    Private Sub REGISTER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTER_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-Register.exe"
        process1.Start()

    End Sub

    Private Sub DAYCLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAYCLOSE_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-DayClose.exe"
        process1.Start()

    End Sub

    Private Sub REQ_ORDER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REQ_ORDER_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-CustomerOrder.exe"
        process1.Start()

    End Sub

    Private Sub IN_CASH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IN_CASH_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-InCash.exe"
        process1.Start()

    End Sub

    Private Sub OUT_CASH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUT_CASH_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-OutCash.exe"
        process1.Start()

    End Sub

    '**************************************
    '*          ネットショップ管理        *
    '**************************************
    Private Sub NET_IMPORT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NET_IMPORT_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-NetImport.exe"
        process1.Start()

    End Sub

    '****************************
    '*          仕入管理        *
    '****************************
    Private Sub ORDER_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDER_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-Order.exe"
        process1.Start()

    End Sub

    Private Sub ARRIVAL_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARRIVAL_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-Arrival.exe"
        process1.Start()

    End Sub

    Private Sub INVCHECK_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INVCHECK_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-InvCheck.exe"
        process1.Start()

    End Sub

    '*******************************
    '*          マスタ管理         *
    '*******************************
    Private Sub PRODUCT_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCT_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-ProductMst.exe"
        process1.Start()

    End Sub

    Private Sub BUMON_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUMON_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-BumonMst.exe"
        process1.Start()

    End Sub

    Private Sub DELIVERY_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELIVERY_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-DeliveryMst.exe"
        process1.Start()

    End Sub

    Private Sub SUPPLIER_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIER_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-SupplierMst.exe"
        process1.Start()

    End Sub

    Private Sub MEMBER_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMBER_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-MemberMst.exe"
        process1.Start()

    End Sub

    Private Sub ROLE_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROLE_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-RoleMst.exe"
        process1.Start()

    End Sub

    Private Sub PAYMENT_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENT_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-PaymentMst.exe"
        process1.Start()

    End Sub

    Private Sub CHANNEL_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANNEL_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-ChannelMst.exe"
        process1.Start()

    End Sub

    Private Sub STAFF_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAFF_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-StaffMst.exe"
        process1.Start()

    End Sub

    Private Sub ACCOUNT_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCOUNT_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-AccountMst.exe"
        process1.Start()

    End Sub

    '*******************************
    '*          出荷管理           *
    '*******************************
    Private Sub SHIPMENT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHIPMENT_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-Shipment.exe"
        process1.Start()

    End Sub

    Private Sub DELIVERY_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELIVERY_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-DeliveryCSVOutput.exe"
        process1.Start()

    End Sub

    '*******************************
    '*          その他業務         *
    '*******************************

    Private Sub TAG_PRINT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAG_PRINT_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-TagPrint.exe"
        process1.Start()

    End Sub

    Private Sub RESERV_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESERV_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-Reserv.exe"
        process1.Start()

    End Sub

    '*********************************
    '*          システム管理         *
    '*********************************
    Private Sub CONFIG_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONFIG_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-ConfigMst.exe"
        process1.Start()

    End Sub

    Private Sub CATEGORY_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORY_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-CategoryMst.exe"
        process1.Start()

    End Sub

    Private Sub SALE_DATA_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALE_DATA_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-SaleDataCsvOutput.exe"
        process1.Start()

    End Sub

    Private Sub STOCK_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-StockMst.exe"
        process1.Start()
    End Sub

    '*****************************
    '*          終　　了         *
    '*****************************
    Private Sub EXIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXIT_B.Click
        Dim DbPath As String
        Dim BackUpPath As String

        Dim Message_form As cMessageLib.fProgressMessage

        Message_form = New cMessageLib.fProgressMessage(0, "終了処理中・・・", "しばらくお待ち下さい。")
        Message_form.Show()

        Application.DoEvents()

        oConn.Close()
        oConn = Nothing

        Message_form.ProgressBar.Value = 10

        '常駐プロセスの強制終了
        oTool.KillProcess("E-AutoImport")
        oTool.KillProcess("E-CripNoteRead")

        'バックアップパスの生成
        DbPath = oTool.RegistryRead("File1")
        BackUpPath = oConf(0).sBKFilePath

        On Error Resume Next

        Message_form.ProgressBar.Value = 50

        '最適化およびＤＢのバックアップ
        oTool.CompactDatabase(DbPath, BackUpPath)

        Message_form.ProgressBar.Value = 70

        On Error GoTo 0

        Message_form.ProgressBar.Value = 100

        Message_form.Dispose()
        Message_form = Nothing

        Application.Exit()
    End Sub

    Private Sub ROOM_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROOM_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-RoomMst.exe"
        process1.Start()

    End Sub

    Private Sub POINT_CARD_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POINT_CARD_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-PointCard.exe"
        process1.Start()

    End Sub

    Private Sub BOM_MST_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOM_MST_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-BomMst.exe"
        process1.Start()

    End Sub

    Private Sub MONTH_CLOSE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MONTH_CLOSE_B.Click
        Dim process1 As New Process

        process1.StartInfo.FileName = strPath & "\E-MonthClose.exe"
        process1.Start()

    End Sub
End Class
