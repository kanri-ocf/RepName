Public Class cDisplay
    Private pMessageBox As cMessageLib.fMessage
    Private MAKER_NAME As String
    Private DEVICE_NAME As String

    'ラインディスプレイオブジェクト
    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection,
            ByRef iCommand As OleDb.OleDbCommand,
            ByRef iDataReader As OleDb.OleDbDataReader,
            ByRef iTran As System.Data.OleDb.OleDbTransaction)
        Dim oConf() As cStructureLib.sConfig
        Dim oMstConfigDBIO As cMstConfigDBIO
        Dim oOPOS() As cStructureLib.sOPOS
        Dim oMstOPOSDBIO As cMstOPOSDBIO
        Dim RecordCount As Long

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        '環境マスタ読込み
        oMstConfigDBIO = New cMstConfigDBIO(iConn, iCommand, iDataReader)
        ReDim oConf(0)
        RecordCount = oMstConfigDBIO.getConfMst(oConf, iTran)
        If RecordCount < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました",
                                            "開発元にお問い合わせ下さい",
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            oMstConfigDBIO = Nothing
            Exit Sub
        End If
        oMstConfigDBIO = Nothing
        'OPOSマスタ読込み
        oMstOPOSDBIO = New cMstOPOSDBIO(iConn, iCommand, iDataReader)
        ReDim oOPOS(0)
        RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sCustomerDisplayProducttClass, iTran)
        MAKER_NAME = oOPOS(0).sMakerName
        DEVICE_NAME = oOPOS(0).sDeviceName
    End Sub
    '------------------------------------------------------
    '　　　カスタマディスプレーコントロール
    '------------------------------------------------------
    Public Function DisplayInit() As Boolean

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.Open(DEVICE_NAME)
                    ret = AxOPOSDISP_TEC.ClaimDevice(1000)
                    If ret Then
                        AxOPOSDISP_TEC.DeviceEnabled = False
                    Else
                        AxOPOSDISP_TEC.DeviceEnabled = True
                    End If

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'DisplayInit = ret
                    DisplayInit = AxOPOSDISP_TEC.DeviceEnabled
                    '2016.07.05 K.Oikawa e

                Case "EPSON"
                    AxOPOSDISP_EPSON.Open(DEVICE_NAME)
                    ret = AxOPOSDISP_EPSON.ClaimDevice(1000)
                    If ret Then
                        AxOPOSDISP_EPSON.DeviceEnabled = False
                    Else
                        AxOPOSDISP_EPSON.DeviceEnabled = True
                    End If

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'DisplayInit = ret
                    DisplayInit = AxOPOSDISP_EPSON.DeviceEnabled
                    '2016.07.05 K.Oikawa e

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DisplyaInit)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            DisplayInit = False
        End Try

    End Function
    Public Sub ClearText()

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.ClearText

                Case "EPSON"
                    ret = AxOPOSDISP_EPSON.ClearText()

            End Select
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ClearText)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub DestroyWindow()

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.DestroyWindow

                Case "EPSON"
                    ret = AxOPOSDISP_EPSON.DestroyWindow()

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DestroyWindow)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub DisplayText(ByVal msg As String, ByVal DISP_MODE As Integer)

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.DisplayText(msg, DISP_MODE)

                Case "EPSON"
                    ret = AxOPOSDISP_EPSON.DisplayText(msg, DISP_MODE)

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DisplayText)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub ScrollText(ByVal SCROLL_MODE As Integer, ByVal SCROLL_SIZE As Integer)

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.ScrollText(SCROLL_MODE, SCROLL_SIZE)

                Case "EPSON"
                    ret = AxOPOSDISP_EPSON.ScrollText(SCROLL_MODE, SCROLL_SIZE)

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ScrollText)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Function CreateWindow(ByVal row As Integer,
                            ByVal column As Integer,
                            ByVal height As Integer,
                            ByVal width As Integer,
                            ByVal windowHeight As Integer,
                            ByVal windowWidth As Integer
                            ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDISP_TEC.CreateWindow(row, column, height, width, windowHeight, windowWidth)
                Case "EPSON"
                    ret = AxOPOSDISP_EPSON.CreateWindow(row, column, height, width, windowHeight, windowWidth)

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.CreateWindow)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Function Columns() As Integer

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    Columns = AxOPOSDISP_TEC.Columns()
                Case "EPSON"
                    Columns = AxOPOSDISP_EPSON.Columns()

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.Columns)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Function ResultCode() As Integer

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ResultCode = AxOPOSDISP_TEC.ResultCode()
                Case "EPSON"
                    ResultCode = True

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ResultCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Sub SetMarqueeType(ByVal Value As Integer)

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    AxOPOSDISP_TEC.MarqueeType = Value
                Case "EPSON"
                    AxOPOSDISP_EPSON.MarqueeType = Value

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.SetMarqueeType)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub SetMarqueeUnitWait(ByVal Value As Integer)

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    AxOPOSDISP_TEC.MarqueeUnitWait = Value
                Case "EPSON"
                    AxOPOSDISP_EPSON.MarqueeUnitWait = Value

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.SetMarqueeUnitWait)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
End Class