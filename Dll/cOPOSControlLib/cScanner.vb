'Imports Microsoft.PointOfService
Public Class cScanner
    'キャッシュスキャナーオブジェクト
    'Private m_Scanner As CashScanner = Nothing
    Private pMessageBox As cMessageLib.fMessage
    Private MAKER_NAME As String
    Private DEVICE_NAME As String
    Private SCAN_SET_ZOOM As System.Windows.Forms.TextBox

    Private Const OPOS_PN_DISABLED = 0
    Private Const OPOS_PN_ENABLED = 1

    '----------------------------------------------------------------------
    '　機能：コンストラクタ
    '　引数：JAN_CODE : 検索キーJANコード
    '----------------------------------------------------------------------
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
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

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
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
        RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sBarcodeScannerClass, iTran)
        MAKER_NAME = oOPOS(0).sMakerName
        DEVICE_NAME = oOPOS(0).sDeviceName
    End Sub
    '------------------------------------------------------
    '　　　スキャナコントロール
    '------------------------------------------------------
    Public Function ScannerInit(ByRef iTextBox As System.Windows.Forms.TextBox) As Boolean

        'Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"

                Case "EPSON"

                Case "STAR"
                    'TODO:スキャナーを一旦コメントアウト
                    'ret = AxOPOSSCAN_STAR.Open(DEVICE_NAME)
                    'ret = AxOPOSSCAN_STAR.ClaimDevice(0)
                    'If ret Then
                    '    AxOPOSSCAN_STAR.DeviceEnabled = False
                    'Else
                    '    AxOPOSSCAN_STAR.DeviceEnabled = True
                    'End If

                    'AxOPOSSCAN_STAR.PowerNotify = OPOS_PN_ENABLED

                    'AxOPOSSCAN_STAR.DeviceEnabled = True

                    'AxOPOSSCAN_STAR.DataEventEnabled = True

                    'AxOPOSSCAN_STAR.DecodeData = True

                    'SCAN_SET_ZOOM = iTextBox

                    'ScannerInit = AxOPOSSCAN_STAR.ResultCode

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ScannerInit)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Sub OpenScanner()

        Try
            Select Case MAKER_NAME
                Case "TEC"

                Case "EPSON"

                Case "STAR"
                    'TODO:スキャナーを一旦コメントアウト
                    'AxOPOSSCAN_STAR.Open(DEVICE_NAME)
            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ScannerOpen)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Return

        End Try
    End Sub
    Public Sub ScannerClose()
        'Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"

                Case "EPSON"

                Case "STAR"
                    'TODO:スキャナーを一旦コメントアウト
                    'ret = AxOPOSSCAN_STAR.Close()

                    'If ret Then
                    '    Dim message_form As New cMessageLib.fMessage(1, _
                    '                                  "スキャナーのクローズに失敗しました", _
                    '                                  "開発元に連絡して下さい", _
                    '                                  Nothing, Nothing)
                    '    message_form.ShowDialog()
                    '    message_form = Nothing
                    'End If
                    'AxOPOSSCAN_STAR.DeviceEnabled = False
            End Select
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.ScannerClose)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub SetDeviceEnabled(ByVal Value As Integer)

        'Try
        Select Case MAKER_NAME
            Case "TEC"

            Case "EPSON"

            Case "STAR"
                'TODO:スキャナーを一旦コメントアウト
                'AxOPOSSCAN_STAR.DeviceEnabled = Value

        End Select

    End Sub

    'TODO:スキャナーを一旦コメントアウト
    'Private Sub AxOPOSSCAN_STAR_DataEvent(sender As Object, e As AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent) Handles AxOPOSSCAN_STAR.DataEvent
    '    SCAN_SET_ZOOM.Text = AxOPOSSCAN_STAR.ScanData

    '    AxOPOSSCAN_STAR.DataEventEnabled = True

    'End Sub
End Class