Option Explicit On

Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Text

Public Class cBufferNewRakutenCSV

    Private Const START_URL As String = "https://glogin.rms.rakuten.co.jp/"
    Private Const ORDER_CSV_NAME As String = "Rakuten_Order.csv"
    Private Const PROGRAM_NAME As String = "rakuten"
    Private Const CHARSET As String = "EUC-JP"
    Private Const CHARSET2 As String = "UTF-8"

    Private Const GET_DAYS As Integer = -7

    Private AuthKey As String
    Private ShopUrl As String

    Public Sub New( _
            ByVal AuthKey As String, _
            ByVal ShopUrl As String _
            )
        Me.AuthKey = AuthKey
        Me.ShopUrl = ShopUrl
    End Sub

    Public Function download() As Integer
        'Dim rtnStatus As Integer = 0
        'Dim l As New cLog(Application.StartupPath & "\Net\Log", PROGRAM_NAME)
        'Dim msg As String = ""
        'Dim html As String = ""
        'Dim url As String = ""
        'Dim wxh As New cWrapXMLHTTP(Application.StartupPath & "\Net", PROGRAM_NAME)

        'Try

        '    Dim requestId As String
        '    Dim errCode As String

        '    ''プロキシクラスのインスタンスを作成

        '    Dim api As New jp.co.rakuten.rms.api.OrderApiService

        '    ''ポートを生成します
        '    ''Dim port As OrderApiService = api.getOrderApiServicePort

        '    '認証モデルを生成します
        '    Dim auth As New jp.co.rakuten.rms.api.userAuthModel
        '    '認証キーをセットします
        '    auth.authKey = AuthKey
        '    '店舗URL をセットします
        '    auth.shopUrl = ShopUrl
        '    'ユーザー名をセットします
        '    auth.userName = ""

        '    'レスポンスモデルを生成します
        '    Dim response As New jp.co.rakuten.rms.api.getRequestIdResponseModel
        '    'getRequestId を呼出します
        '    'response = port.getRequestId(auth)

        '    ''実行結果を判定します
        '    'If response.errorCode Is Nothing And response.errorCode.Equals("N00-000") Then
        '    '    'リクエストID の格納処理など
        '    '    requestId = response.requestId
        '    'Else
        '    '    'エラーコード、エラーメッセージの出力処理など
        '    '    errCode = response.errorCode
        '    'End If


        '    'clientを使った何らかのSOAPの要求/応答処理

        'Catch ex As Exception
        '    l.write(msg)
        '    l.write(ex)
        '    l.write("以下パスにHTMLダンプを出力：" & vbCrLf & wxh.getFullDumpFilePath())
        '    rtnStatus = -1

        'Finally
        '    ' HTMLダンプの削除
        '    If rtnStatus <> -1 Then System.IO.File.Delete(wxh.getFullDumpFilePath())

        '    ' LOGクローズ
        '    l.close() : l = Nothing
        '    wxh.Dispose() : wxh = Nothing

        'End Try

        '' 終了ステータスの返却
        'Return rtnStatus

    End Function
End Class
