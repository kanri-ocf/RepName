Public Class fAutoImport
    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oTran As System.Data.OleDb.OleDbTransaction

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oTool As cTool

    'タスクトレイにアニメで表示するアイコン
    Private tasktrayIcons() As Icon

    'アニメで現在表示しているアイコンのインデックス
    Private currentTasktrayIconIndex As Integer

    Private IMPORT_PROCESS As Integer       '0：初期値 1：ダウンロード中 2：ダウンロード終了 3：インポート中
    Private Tran As System.Data.OleDb.OleDbTransaction

    Sub New()
        Dim StrPath As String
        Dim DB_Path As String
        Dim RecordCnt As Integer

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, Tran)

    End Sub

    Private Sub fAutoImport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        NotifyIcon1.Dispose()
    End Sub

    Private Sub AutoImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'タスクトレイアイコンをフォームのアイコンにする
        Me.NotifyIcon1.Icon = Me.Icon
        Me.NotifyIcon1.Visible = True

        'タイマーを無効にしておく（初めはアニメしない）
        Me.Timer_Download.Enabled = False
        'アニメ時は、1秒毎にアイコンを変更する
        Me.Timer_Download.Interval = 1000

        'タスクトレイにアニメで表示するアイコンを指定する
        Me.currentTasktrayIconIndex = 0
        Me.tasktrayIcons = New Icon() { _
            New Icon(Application.StartupPath & "\Picture\AutoImport01.ico"), _
            New Icon(Application.StartupPath & "\Picture\AutoImport02.ico"), _
            New Icon(Application.StartupPath & "\Picture\AutoImport03.ico")}
        AddHandler Timer_Icon.Tick, AddressOf Timer_Icon_Tick

        Me.Hide()

        'CSVファイルのダウンロード
        Timer_Download.Stop()
        Timer_Icon.Start()

        'CSVファイルの削除()
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Yahoo_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Yahoo_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Yahoo_Product.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Yahoo_Product.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Rakuten_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Rakuten_Order.csv")
        End If
        ' *** START K.MINAGAWA 2013/05/20 ***
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Shop_Serv_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Shop_Serv_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Amazon_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Amazon_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Amazon_Product.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Amazon_Product.csv")
        End If
        ' *** END   K.MINAGAWA 2013/05/20 ***

        ''トランザクションの開始
        'oTran = oConn.BeginTransaction

        'YahooCSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 1, oTran) Then
            ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
            'Dim yahooCSV As New cBufferYahooCSV( _
            '                                 oConf(0).sYahooBisID, _
            '                                 oConf(0).sYahooBisPASS, _
            '                                 oConf(0).sYahooUserID, _
            '                                 oConf(0).sYahooUserPASS, _
            '                                 oConf(0).sTempFilePath _
            '                              )
            Dim yahooCSV As New cBufferYahooCSV( _
                                oConn, _
                                oCommand, _
                                oDataReader, _
                                oTran, _
                                oConf(0).sYahooUserID, _
                                oConf(0).sYahooUserPASS, _
                                oConf(0).sTempFilePath, _
                                oConf(0).sYahooApiKey, _
                                oConf(0).sYahooStoreAccount, _
                                oConf(0).sYahooRedirectUri _
                              )
            ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
            yahooCSV.download()
            yahooCSV = Nothing
        End If

        'If oMstChannelDBIO.ExistCMSType(oChannel, 2, oTran) Then
        '    Dim AuthKey As String = "owp-shop"
        '    Dim ShopUrl As String = "e0ee8d9d489e64e5a90ec75c0e8382ad"
        '    Dim o4 As New cBufferNewRakutenCSV(AuthKey, ShopUrl)
        '    Dim i4 As Integer = o4.download
        '    o4 = Nothing
        'End If

        '楽天CSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 2, oTran) Then
            ' ** 2016.08.09 K.Minagawa →　受注API対応 ***
            'Dim rakutenCSV As New cBufferRakutenCSV
            '                                    oConf(0).sRakutenRMSUserID, _
            ''                                  oConf(0).sRakutenUserID, _
            '                                oConf(0).sRakutenUserPASS, _
            '                               oConf(0).sRakutenCSVDownloadID, _
            '                                oConf(0).sRakutenCSVDownloadPASS, _
            '                                oConf(0).sTempFilePath _
            ''                             )
            Dim rakutenCSV As New cBufferRakutenCSV( _
                                                oConn, _
                                                oCommand, _
                                                oDataReader, _
                                                oTran, _
                                                oConf(0).sRakutenUserID, _
                                                oChannel(0).sChannelCode, _
                                                oConf(0).sTempFilePath)

            rakutenCSV.download()
            ' ** 2016.08.09 K.Minagawa →　受注API対応 ***

            rakutenCSV = Nothing
        End If

        'ショップサーブCSVデータダウンロード
        'If oMstChannelDBIO.ExistCMSType(oChannel, 3, oTran) Then
        '    Dim businessID3 As String = oConf(0).sShopServID
        '    Dim businessPass3 As String = oConf(0).sShopServPass
        '    Dim CSVsavePath3 As String = oConf(0).sTempFilePath
        '    Dim o3 As New cBufferShopServCSV(WebBrowser, businessID3, businessPass3, CSVsavePath3)
        '    Dim i3 As Integer = o3.download
        '    o3 = Nothing
        'End If

        ' *** START K.MINAGAWA 2013/05/20 ***
        ' AmazonCSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 4, oTran) Then
            Dim AccessKeyId As String = oConf(0).sAmazonWebServiceAccesskeyID
            Dim MarketplaceId As String = oConf(0).sAmazonMarketPlaceID
            Dim Signature As String = oConf(0).sAmazonSecretKey
            Dim sellerId As String = oConf(0).sAmazonSellerID
            Dim CSVsavePath4 As String = oConf(0).sTempFilePath
            Dim SecretKey As String = oConf(0).sAmazonSecretKey
            Dim o4 As New cBufferAmazonCSV(oConn, oCommand, oDataReader, AccessKeyId, MarketplaceId, Signature, sellerId, SecretKey, CSVsavePath4, oChannel(0).sChannelCode, oTran)
            Dim i4 As Integer = o4.DownLoad
            o4 = Nothing
        End If
        ' *** END   K.MINAGAWA 2013/05/20 ***

        'CSVファイルの取込
        Dim oNetImportCSV As New cBufferNetImportCSV(oConn, oCommand, oDataReader, oTran, 0)

        '処理プロセス＝インポート中をセット
        oNetImportCSV.IMPORT()
        oNetImportCSV = Nothing

        '処理プロセス＝ダウンロード中をセット
        Timer_Icon.Stop()
        Timer_Download.Interval = 3600000
        Timer_Download.Start()

        'Timer_Download.Interval = 10000
        'Timer_Download.Start()
        Timer_Icon.Interval = 1000
        Timer_Icon.Stop()
    End Sub

    Private Sub Timer_Download_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer_Download.Tick
        'CSVファイルのダウンロード
        Timer_Download.Stop()
        Timer_Icon.Start()

        'CSVファイルの削除()
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Yahoo_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Yahoo_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Yahoo_Product.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Yahoo_Product.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Rakuten_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Rakuten_Order.csv")
        End If
        ' *** START K.MINAGAWA 2013/05/20 ***
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Shop_Serv_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Shop_Serv_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Amazon_Order.csv") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Amazon_Order.csv")
        End If
        If System.IO.File.Exists(oConf(0).sTempFilePath & "\Amazon_Order.xml") Then
            System.IO.File.Delete(oConf(0).sTempFilePath & "\Amazon_Order.xml")
        End If
        ' *** END   K.MINAGAWA 2013/05/20 ***

        'Cookieクリア
        Dim p As New Process()
        p.StartInfo.FileName = "rundll32"
        p.StartInfo.Arguments = "inetcpl.cpl,ClearMyTracksByProcess 2"
        p.Start()
        p.WaitForExit()
        p.Close()

        'YahooCSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 1, oTran) Then
            ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
            'Dim yahooCSV As New cBufferYahooCSV( _
            '                                 oConf(0).sYahooBisID, _
            '                                 oConf(0).sYahooBisPASS, _
            '                                 oConf(0).sYahooUserID, _
            '                                 oConf(0).sYahooUserPASS, _
            '                                 oConf(0).sTempFilePath _
            '                              )
            Dim yahooCSV As New cBufferYahooCSV( _
                                oConn, _
                                oCommand, _
                                oDataReader, _
                                oTran, _
                                oConf(0).sYahooUserID, _
                                oConf(0).sYahooUserPASS, _
                                oConf(0).sTempFilePath, _
                                oConf(0).sYahooApiKey, _
                                oConf(0).sYahooStoreAccount, _
                                oConf(0).sYahooRedirectUri _
                              )
            ' ** 2016.08.26 K.Oikawa →　受注API対応 ***
            yahooCSV.download()
            yahooCSV = Nothing
        End If

        '楽天CSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 2, oTran) Then
            ' ** 2016.08.09 K.Minagawa →　受注API対応 ***
            '    Dim rakutenCSV As New cBufferRakutenCSV( _
            '                                    oConf(0).sRakutenRMSUserID, _
            '                                   oConf(0).sRakutenRMSUserPASS, _
            '                                  oConf(0).sRakutenUserID, _
            '                                 oConf(0).sRakutenUserPASS, _
            '                                oConf(0).sRakutenCSVDownloadID, _
            '                               oConf(0).sRakutenCSVDownloadPASS, _
            '                              oConf(0).sTempFilePath _
            '                          )
            Dim rakutenCSV As New cBufferRakutenCSV( _
                                               oConn, _
                                               oCommand, _
                                               oDataReader, _
                                               oTran, _
                                               oConf(0).sRakutenUserID, _
                                               oChannel(0).sChannelCode, _
                                               oConf(0).sTempFilePath)

            ' ** 2016.08.09 K.Minagawa →　受注API対応 ***
            rakutenCSV.downLoad()
            rakutenCSV = Nothing
        End If

        'ショップサーブCSVデータダウンロード
        'If oMstChannelDBIO.ExistCMSType(oChannel, 3, oTran) Then
        '    Dim businessID3 As String = oConf(0).sShopServID
        '    Dim businessPass3 As String = oConf(0).sShopServPass
        '    Dim CSVsavePath3 As String = oConf(0).sTempFilePath
        '    Dim o3 As New cBufferShopServCSV(WebBrowser, businessID3, businessPass3, CSVsavePath3)
        '    Dim i3 As Integer = o3.download
        '    o3 = Nothing
        'End If

        ' *** START K.MINAGAWA 2013/05/20 ***
        ' AmazonCSVデータダウンロード
        If oMstChannelDBIO.ExistCMSType(oChannel, 4, oTran) Then
            Dim AccessKeyId As String = oConf(0).sAmazonWebServiceAccesskeyID
            Dim MarketplaceId As String = oConf(0).sAmazonMarketPlaceID
            Dim Signature As String = oConf(0).sAmazonSecretKey
            Dim sellerId As String = oConf(0).sAmazonSellerID
            Dim SecretKey As String = oConf(0).sAmazonSecretKey
            Dim CSVsavePath4 As String = oConf(0).sTempFilePath
            Dim o4 As New cBufferAmazonCSV(oConn, oCommand, oDataReader, AccessKeyId, MarketplaceId, Signature, sellerId, SecretKey, CSVsavePath4, oChannel(0).sChannelCode, oTran)
            Dim i4 As Integer = o4.DownLoad
            o4 = Nothing
        End If
        ' *** END   K.MINAGAWA 2013/05/20 ***

        'CSVファイルの取込
        Dim oNetImportCSV As New cBufferNetImportCSV(oConn, oCommand, oDataReader, oTran, 0)

        '処理プロセス＝インポート中をセット
        oNetImportCSV.IMPORT()
        oNetImportCSV = Nothing

        '処理プロセス＝ダウンロード中をセット
        Timer_Icon.Stop()
        Timer_Download.Interval = 3600000
        Timer_Download.Start()

    End Sub

    Private Sub Timer_Icon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChangeAnimatedTasktrayIcon()
    End Sub

    'アニメ表示時にタスクトレイアイコンを変更する
    Private Sub ChangeAnimatedTasktrayIcon()

        '次に表示するアイコンを決める
        Select Case Me.currentTasktrayIconIndex
            Case 0
                Me.currentTasktrayIconIndex = 1
            Case 1
                Me.currentTasktrayIconIndex = 2
            Case 2
                Me.currentTasktrayIconIndex = 1
        End Select

        'タスクトレイアイコンを変更する
        Me.NotifyIcon1.Icon = Me.tasktrayIcons(Me.currentTasktrayIconIndex)

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        NotifyIcon1.Visible = False ' アイコンをトレイから取り除く
        Application.Exit() ' アプリケーションの終了
    End Sub
End Class
