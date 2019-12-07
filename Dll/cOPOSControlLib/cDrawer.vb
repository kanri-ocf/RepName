'Imports Microsoft.PointOfService
Public Class cDrawer
    'キャッシュドロワーオブジェクト
    'Private m_Drawer As CashDrawer = Nothing
    Private pMessageBox As cMessageLib.fMessage
    Private MAKER_NAME As String
    Private DEVICE_NAME As String
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
        RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sDrawerProductClass, iTran)
        MAKER_NAME = oOPOS(0).sMakerName
        DEVICE_NAME = oOPOS(0).sDeviceName
    End Sub
    '------------------------------------------------------
    '　　　ドロワコントロール
    '------------------------------------------------------
    Public Function DrawerInit() As Boolean

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDRW_TEC.Open(DEVICE_NAME)
                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'DrawerInit = ret
                    AxOPOSDRW_TEC.DeviceEnabled = True

                    DrawerInit = AxOPOSDRW_TEC.DeviceEnabled
                    '2016.07.05 K.Oikawa e

                Case "EPSON"
                    ret = AxOPOSDRW_EPSON.Open(DEVICE_NAME)
                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'DrawerInit = ret
                    AxOPOSDRW_EPSON.DeviceEnabled = True

                    DrawerInit = AxOPOSDRW_EPSON.DeviceEnabled
                    '2016.07.05 K.Oikawa e

                Case "STAR"
                    ret = AxOPOSDRW_STAR.Open(DEVICE_NAME)

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'DrawerInit = ret
                    AxOPOSDRW_STAR.DeviceEnabled = True

                    DrawerInit = AxOPOSDRW_STAR.DeviceEnabled
                    '2016.07.05 K.Oikawa e

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DrawerInit)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Sub OpenDrawer()

        Try
            '2019.12.7 R.Takashima FROM
            'ドロワーオープン時にメッセージを表示させる
            If AxOPOSDRW_TEC.DeviceEnabled = True Or AxOPOSDRW_EPSON.DeviceEnabled = True Or AxOPOSDRW_STAR.DeviceEnabled = True Then
                pMessageBox = New cMessageLib.fMessage(0,
                                          Nothing,
                                          "ドロワーを閉じて下さい。",
                                          Nothing, Nothing)
                pMessageBox.Show()
                System.Windows.Forms.Application.DoEvents()
                '2019.12.7 R.Takashima TO

                Select Case MAKER_NAME
                    Case "TEC"
                        AxOPOSDRW_TEC.OpenDrawer()
                        While AxOPOSDRW_TEC.DrawerOpened
                            'ドロワーが閉まるまでWait....
                        End While

                    Case "EPSON"
                        AxOPOSDRW_EPSON.OpenDrawer()
                        While AxOPOSDRW_EPSON.DrawerOpened
                            'ドロワーが閉まるまでWait....
                        End While

                    Case "STAR"
                        AxOPOSDRW_STAR.OpenDrawer()
                        Dim a As Boolean

                        'これがFalseだとドロワの状態を通知できない
                        a = AxOPOSDRW_STAR.CapStatus

                        '2019.10.25 R.Takashima
                        If AxOPOSDRW_STAR.Enabled = True Then

                            While AxOPOSDRW_STAR.DrawerOpened = False
                                'ドロワーの応答速度やプログラムを実行している環境によっては
                                '閉じるまでWaitする処理が働かないため（ドロワーが開く前に下の処理を終わらせてしまっている）
                                'ここでドロワーが開くまでWait
                            End While

                            While AxOPOSDRW_STAR.DrawerOpened
                                'TODO:課題表No136 ここが機能していない
                                'ドロワーが閉まるまでWait....

                            End While

                        End If

                        pMessageBox.Dispose()
                        pMessageBox = Nothing
                        a = AxOPOSDRW_STAR.CapStatus

                End Select
            Else
                '2019.12.7 R.Takashima FROM
                'ドロワーが接続されていないときにメッセージ表示
                pMessageBox = New cMessageLib.fMessage(1,
                                                       Nothing,
                                                       "ドロワに接続されていません。",
                                                       Nothing,
                                                       Nothing
                                                       )
                pMessageBox.ShowDialog()
                pMessageBox.Dispose()
                pMessageBox = Nothing
                '2019.12.7 R.Takashima TO
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DrawerOpen)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Return

        End Try
    End Sub
    Public Sub DrawerClose()
        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSDRW_TEC.Close
                    If ret Then
                        Dim message_form As New cMessageLib.fMessage(1, _
                                                      "ドロワーのクローズに失敗しました", _
                                                      "開発元に連絡して下さい", _
                                                      Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing
                    End If
                    AxOPOSDRW_TEC.DeviceEnabled = False

                Case "EPSON"
                    ret = AxOPOSDRW_EPSON.Close()

                    If ret Then
                        Dim message_form As New cMessageLib.fMessage(1, _
                                                      "ドロワーのクローズに失敗しました", _
                                                      "開発元に連絡して下さい", _
                                                      Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing
                    End If
                    AxOPOSDRW_EPSON.DeviceEnabled = False

                Case "STAR"
                    ret = AxOPOSDRW_STAR.Close()

                    If ret Then
                        Dim message_form As New cMessageLib.fMessage(1, _
                                                      "ドロワーのクローズに失敗しました", _
                                                      "開発元に連絡して下さい", _
                                                      Nothing, Nothing)
                        message_form.ShowDialog()
                        message_form = Nothing
                    End If
                    AxOPOSDRW_EPSON.DeviceEnabled = False
            End Select
        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.DrawerClose)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Sub SetDeviceEnabled(ByVal Value As Integer)

        'Try
        Select Case MAKER_NAME
            Case "TEC"
                AxOPOSDRW_TEC.DeviceEnabled = Value
            Case "EPSON"
                AxOPOSDRW_EPSON.DeviceEnabled = Value
            Case "STAR"
                AxOPOSDRW_STAR.DeviceEnabled = Value

        End Select

    End Sub
End Class