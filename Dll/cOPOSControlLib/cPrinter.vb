Imports System.Drawing.Printing
Imports System.Text
Imports System.Collections.Generic
Imports System.Globalization
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports StarMicronics.StarIO 'Added as a reference from the "Dependencies" directory 

Public Class cPrinter
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
        RecordCount = oMstOPOSDBIO.getOPOSMst(oOPOS, Nothing, Nothing, oConf(0).sRecertPrinterProductClass, iTran)
        MAKER_NAME = oOPOS(0).sMakerName
        DEVICE_NAME = oOPOS(0).sDeviceName
    End Sub
    '------------------------------------------------------
    '　　　レシートプリンターコントロール
    '------------------------------------------------------
    Public Function PrinterInit() As Boolean

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.Open(DEVICE_NAME)
                    ret = AxOPOSPTR_TEC.ClaimDevice(1000)
                    If ret Then
                        AxOPOSPTR_TEC.DeviceEnabled = False
                    Else
                        AxOPOSPTR_TEC.DeviceEnabled = True
                    End If

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'PrinterInit = ret
                    PrinterInit = AxOPOSPTR_TEC.DeviceEnabled
                    '2016.07.05 K.Oikawa e

                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.Open(DEVICE_NAME)

                    ret = AxOPOSPTR_EPSON.ClaimDevice(1000)
                    If ret Then
                        AxOPOSPTR_EPSON.DeviceEnabled = False
                    Else
                        AxOPOSPTR_EPSON.DeviceEnabled = True
                    End If

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'PrinterInit = ret
                    PrinterInit = AxOPOSPTR_EPSON.DeviceEnabled
                    '2016.07.05 K.Oikawa e

                Case "STAR"
                    ret = AxOPOSPTR_STAR.Open(DEVICE_NAME)

                    ret = AxOPOSPTR_STAR.ClaimDevice(1000)
                    If ret Then
                        AxOPOSPTR_STAR.DeviceEnabled = False
                    Else
                        AxOPOSPTR_STAR.DeviceEnabled = True
                    End If

                    '2016.07.05 K.Oikawa s
                    '課題表No88 周辺機器の接続確認修正
                    'PrinterInit = ret
                    PrinterInit = AxOPOSPTR_STAR.DeviceEnabled
                    '2016.07.05 K.Oikawa e

            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.PrinterInit)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
            PrinterInit = False
            Return PrinterInit
        End Try

    End Function
    Public Sub SetAsyncMode(ByVal Value As Integer)

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    AxOPOSPTR_TEC.AsyncMode = Value
                Case "EPSON"
                    AxOPOSPTR_EPSON.AsyncMode = Value
                Case "STAR"
                    AxOPOSPTR_STAR.AsyncMode = Value
            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.SetAsyncMode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Sub
    Public Function TransactionPrint(ByVal station As Integer, _
                        ByVal control As Integer _
                        ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.TransactionPrint(station, control)
                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.TransactionPrint(station, control)
                Case "STAR"
                    ret = AxOPOSPTR_STAR.TransactionPrint(station, control)
            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.TransactionPrint)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Function SetBitmap(ByVal bitmapNumber As Integer, _
                        ByVal station As Integer, _
                        ByVal fileName As String, _
                        ByVal width As Integer, _
                        ByVal alignment As Integer _
                        ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.SetBitmap(bitmapNumber, station, fileName, width, alignment)
                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.SetBitmap(bitmapNumber, station, fileName, width, alignment)
                Case "STAR"
                    ret = AxOPOSPTR_STAR.SetBitmap(bitmapNumber, station, fileName, width, alignment)
            End Select

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.SetBitmap)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
        End Try

    End Function
    Public Function PrintNormal(ByVal station As Integer, _
                        ByVal data As String _
                        ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.PrintNormal(station, data)
                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.PrintNormal(station, data)
                Case "STAR"
                    ret = AxOPOSPTR_STAR.PrintNormal(station, data)
            End Select
            PrintNormal = ret

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.PrintNormal)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            PrintNormal = -1
        End Try

    End Function
    Public Function PrintBarCode(ByVal station As Integer, _
                        ByVal data As String, _
                        ByVal symbology As Integer, _
                        ByVal height As Integer, _
                        ByVal width As Integer, _
                        ByVal alignment As Integer, _
                        ByVal textposition As Short _
                        ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.PrintBarCode(station, data, symbology, height, width, alignment, textposition)
                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.PrintBarCode(station, data, symbology, height, width, alignment, textposition)
                Case "STAR"
                    ret = AxOPOSPTR_STAR.PrintBarCode(station, data, symbology, height, width, alignment, textposition)
            End Select
            PrintBarCode = ret

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.PrintBarCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            PrintBarCode = -1
        End Try

    End Function
    Public Function RotatePrint(ByVal station As Integer, _
                        ByVal rotation As Integer _
                        ) As Integer

        Dim ret As Boolean

        Try
            Select Case MAKER_NAME
                Case "TEC"
                    ret = AxOPOSPTR_TEC.RotatePrint(station, rotation)
                Case "EPSON"
                    ret = AxOPOSPTR_EPSON.RotatePrint(station, rotation)
                Case "STAR"
                    ret = AxOPOSPTR_STAR.RotatePrint(station, rotation)
            End Select
            RotatePrint = ret

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cPosControl.RotatePrint)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            RotatePrint = -1
        End Try

    End Function
End Class