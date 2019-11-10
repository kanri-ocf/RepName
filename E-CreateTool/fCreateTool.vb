Imports System.Net
Public Class fCreateTool
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oConf() As cStructureLib.sConfig
    Private oConfMstDBIO As cMstConfigDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oProductMstDBIO As cMstProductDBIO

    Private oMember() As cStructureLib.sMember
    Private oMemberMstDBIO As cMstMemberDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffMstDBIO As cMstStaffDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New()

        Dim StrPath As String
        Dim DB_Path As String

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



    End Sub
    Private Sub fCreateJANCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim RecordCnt As Integer

        'oProductMstDBIO = New cProductMstDBIO(oConn, oCommand, oDataReader)
        'oConfMstDBIO = New cConfMstDBIO(oConn, oCommand, oDataReader)
        'oMemberMstDBIO = New cMemberMstDBIO(oConn, oCommand, oDataReader)

        'oTool = New cTool

        ''環境マスタ読込み
        'ReDim oConf(1)
        'RecordCnt = oConfMstDBIO.getConfMst(oConf, Tran)
        'If RecordCnt < 1 Then
        '    'メッセージウィンドウ表示
        '    Dim Message_form As fMessage

        '    Message_form = New fMessage(1, "環境マスタの読込みに失敗しました", _
        '                                    "開発元にお問い合わせ下さい", _
        '                                    "")
        '    Message_form.ShowDialog()
        '    Application.DoEvents()
        '    Application.Exit()
        'End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CREATE_JANCODE()

    End Sub
    Private Sub CREATE_JANCODE()
        Dim KeyJANCode As String
        Dim RecordCount As Integer
        Dim i As Long
        Dim ret As Long

        RecordCount = oProductMstDBIO.getProduct_JANNull(oProduct, oTran)

        For i = 0 To RecordCount - 1
            KeyJANCode = Nothing
            KeyJANCode = oProductMstDBIO.readMaxJANCode(oTran)
            If KeyJANCode = Nothing Then
                KeyJANCode = "999" & String.Format("{0:000000000}", 1)
            Else
                KeyJANCode = "999" & String.Format("{0:000000000}", CInt(KeyJANCode.Substring(3, 9)) + 1)
            End If
            oProduct(i).sJANCode = oTool.JANCD(KeyJANCode)
            ret = oProductMstDBIO.updateJANCode(oProduct(i), oTran)
        Next i
        MsgBox(RecordCount & "件更新しました")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fCreateForm As New fCreateJanCode
        fCreateForm.ShowDialog()
        fCreateForm = Nothing
    End Sub

    'Private Sub STAFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAFF_B.Click
    '    Dim StaffCode As String
    '    Dim RecordCount As Integer
    '    Dim i As Long
    '    Dim ret As Boolean
    '    Dim OrgStaffCode As String

    '    StaffCode = oStaffMstDBIO.readMaxStaffCode(1, Tran)
    '    RecordCount = oStaffMstDBIO.getStaffCodeNull(oStaff, Tran)
    '    StaffCode = Nothing
    '    For i = 0 To RecordCount - 1
    '        If StaffCode = Nothing Then
    '            StaffCode = "990" & String.Format("{0:000000000}", 1)
    '        Else
    '            StaffCode = "990" & String.Format("{0:000000000}", CInt(StaffCode.Substring(4, 8)) + 1)
    '        End If
    '        OrgStaffCode = oStaff(i).sStaffCode
    '        oStaff(i).sStaffCode = oTool.JANCD(StaffCode)
    '        ret = oStaffMstDBIO.updateStaff(oStaff(i), OrgStaffCode, Tran)
    '    Next i
    '    MsgBox(RecordCount & "件更新しました")
    'End Sub

    Private Sub IMAGE_GET_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMAGE_GET_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Integer
        Dim objWC As New WebClient
        Dim cFileInfo As System.IO.FileInfo
        Dim lFileSize As Long

        ProgressBar.Value = 0
        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, False, 1, oTran)

        For i = 0 To recordCnt - 1
            spath = "d:\temp\ProductImg\" & oProduct(i).sProductCode.ToString.ToLower & ".jpg"
            If System.IO.File.Exists(spath) = False Then
                tpath = "http://a248.e.akamai.net/f/248/37952/1h/image.shopping.yahoo.co.jp/i/j/owp-shop_" & oProduct(i).sProductCode.ToString.ToLower

                '指定URLからファイルをダウンロードして保存
                objWC.DownloadFile(tpath, spath)

                For j = 1 To 5
                    tpath = "http://a248.e.akamai.net/f/248/37952/1h/image.shopping.yahoo.co.jp/i/j/owp-shop_" & oProduct(i).sProductCode.ToString.ToLower & "_" & j
                    spath = "d:\temp\ProductImg\" & oProduct(i).sProductCode.ToString.ToLower & "_" & j & ".jpg"

                    If System.IO.File.Exists(spath) = False Then
                        '指定URLからファイルをダウンロードして保存
                        objWC.DownloadFile(tpath, spath)
                    End If

                    cFileInfo = New System.IO.FileInfo(spath)

                    ' ファイルサイズを取得する
                    lFileSize = cFileInfo.Length

                    If lFileSize < 2500 Then
                        System.IO.File.Delete(spath)
                    End If
                Next j
                ProgressBar.Value = (i / recordCnt) * 100
                Application.DoEvents()
            End If
        Next i
        MsgBox("完了")
    End Sub

    Private Sub LIB_IMG_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIB_IMG_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Integer
        Dim objWC As New WebClient

        ProgressBar.Value = 0
        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, False, 1, oTran)

        On Error Resume Next
        For i = 0 To recordCnt - 1
            For j = 0 To 8
                tpath = "http://lib4.store.yahoo.co.jp/lib/owp-shop/" & oProduct(i).sProductCode.ToString.ToUpper & "-" & String.Format("{0:00}", j) & ".jpg"
                spath = "d:\temp\ProductImg\Lib\" & oProduct(i).sProductCode.ToString.ToLower & "-" & String.Format("{0:00}", j) & ".jpg"

                '指定URLからファイルをダウンロードして保存
                objWC.DownloadFile(tpath, spath)
            Next j
            ProgressBar.Value = (i / recordCnt) * 100
            Application.DoEvents()
        Next i
        MsgBox("完了")
    End Sub

    Private Sub BIRDIE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIRDIE_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim l As Long
        Dim objWC As New WebClient

        ProgressBar.Value = 0
        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, False, 1, oTran)

        On Error Resume Next
        For j = 12 To 20
            For k = 1 To 10
                For l = 0 To 100
                    For i = 0 To 5
                        tpath = "http://image.webftp.jp/shopimages/gcom055/" & String.Format("s{0:0}", i) & "_" & String.Format("{0:000}", j) & String.Format("{0:000}", k) & String.Format("{0:000000}", l) & ".jpg"
                        spath = "d:\temp\ProductImg\Birdie\" & String.Format("s{0:0}", i) & "_" & String.Format("{0:000}", j) & String.Format("{0:000}", k) & String.Format("{0:000000}", l) & ".jpg"

                        '指定URLからファイルをダウンロードして保存
                        objWC.DownloadFile(tpath, spath)

                        PAGE_L.Text = String.Format("s{0:0}", i) & "_" & String.Format("{0:000}", j) & String.Format("{0:000}", k) & String.Format("{0:000000}", l)
                        Application.DoEvents()
                    Next i
                    ProgressBar.Value = ((i + 1) * l * k * j / 5 * 1000 * 10 * 12) * 100
                    Application.DoEvents()
                Next l
            Next k
        Next j
        MsgBox("完了")
    End Sub

    Private Sub KCOLLECTION_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KCOLLECTION_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim l As Long
        Dim m As Long
        Dim objWC As New WebClient
        Dim cFileInfo As System.IO.FileInfo
        Dim lFileSize As Long

        ProgressBar.Value = 0
        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, False, 1, oTran)

        On Error Resume Next
        For j = 8 To 9
            For k = 53 To 69
                For l = 1 To 9
                    For i = 0 To 999
                        For m = 1 To 5
                            tpath = "http://img11.shop-pro.jp/PA01053/606/product/" & String.Format("{0:0}", j) & String.Format("{0:00}", k) & String.Format("{0:0}", l) & String.Format("{0:000}", i) & "_o" & m & ".jpg"
                            spath = "d:\temp\ProductImg\Kcollection\" & String.Format("{0:0}", j) & String.Format("{0:00}", k) & String.Format("{0:0}", l) & String.Format("{0:000}", i) & "_o" & m & ".jpg"

                            cFileInfo = New System.IO.FileInfo(spath)

                            If System.IO.File.Exists(spath) = False Then
                                '指定URLからファイルをダウンロードして保存
                                objWC.DownloadFile(tpath, spath)

                                lFileSize = cFileInfo.Length

                                If lFileSize < 13000 Then
                                    System.IO.File.Delete(spath)
                                End If
                            End If

                            PAGE_L.Text = String.Format("{0:0}", j) & String.Format("{0:00}", k) & String.Format("{0:0}", l) & String.Format("{0:000}", i) & "_o" & m

                            lFileSize = Nothing
                            Application.DoEvents()
                        Next m
                    Next i
                Next l
            Next k
            ProgressBar.Value = (j * k / 20 * 8999) * 100
            Application.DoEvents()
        Next j
        MsgBox("完了")
    End Sub

    Private Sub PETIO_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PETIO_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim l As Long
        Dim m As Long
        Dim objWC As New WebClient
        Dim cFileInfo As System.IO.FileInfo
        Dim lFileSize As Long

        ProgressBar.Value = 0
        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, False, 1, oTran)


        On Error Resume Next
        For k = 10 To 10
            For i = 0 To 9999
                For j = 1 To 3
                    tpath = "http://www.petio.net/db/showimg.php?img=img_s/" & String.Format("{0:00}", k) & String.Format("{0:0000}", i) & "_" & String.Format("{0:00}", j) & ".jpg"
                    spath = "d:\temp\ProductImg\Petio\" & tpath.Substring(tpath.LastIndexOf("/") + 1, tpath.Length - tpath.LastIndexOf("/") - 1)

                    cFileInfo = New System.IO.FileInfo(spath)

                    If System.IO.File.Exists(spath) = False Then
                        '指定URLからファイルをダウンロードして保存
                        objWC.DownloadFile(tpath, spath)

                        lFileSize = cFileInfo.Length

                        If lFileSize < 13000 Then
                            System.IO.File.Delete(spath)
                        End If
                    End If

                    PAGE_L.Text = String.Format("{0:00}", k) & String.Format("{0:0000}", i) & "_" & String.Format("{0:00}", j)

                    lFileSize = Nothing
                    Application.DoEvents()
                Next j
            Next i
        Next k
        ProgressBar.Value = (j * k / 20 * 8999) * 100
        Application.DoEvents()
        MsgBox("完了")
    End Sub

    Private Sub PETIO_FILE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PETIO_FILE_B.Click
        Dim spath As String
        Dim tpath As String
        Dim recordCnt As Long
        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim l As Long

        recordCnt = oProductMstDBIO.getProduct(oProduct, Nothing, Nothing, Nothing, Nothing, "PETIO", False, False, False, 1, oTran)

        On Error Resume Next
        For i = 0 To recordCnt - 1
            If oProduct(i).sJANCode.Length >= 3 Then
                For j = 0 To 3
                    If j = 0 Then
                        spath = "d:\temp\ProductImg\Petio\" & oProduct(i).sJANCode.Substring(7, 6) & "_01.jpg"
                    Else
                        spath = "d:\temp\ProductImg\Petio\" & oProduct(i).sJANCode.Substring(7, 6) & "_" & String.Format("{0:00}", j + 1) & ".jpg"
                    End If
                    If System.IO.File.Exists(spath) = True Then
                        If j = 0 Then
                            tpath = "d:\temp\ProductImg\Petio\" & oProduct(i).sProductCode & ".jpg"
                        Else
                            tpath = "d:\temp\ProductImg\Petio\" & oProduct(i).sProductCode & "_" & String.Format("{0:00}", j + 1) & ".jpg"
                        End If
                        System.IO.File.Copy(spath, tpath, True)
                        If System.IO.File.Exists(tpath) = True Then
                            System.IO.File.Delete(spath)
                        End If
                    End If
                Next j
            End If
        Next i
        MsgBox("完了")

    End Sub

    Private Sub FileToClass_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToClass_B.Click
        Dim root As String
        Dim i As Integer
        Dim sr As System.IO.StreamReader
        Dim sw As System.IO.StreamWriter
        Dim buf As String
        Dim nbuf As String
        Dim pos As Integer
        Dim file As String
        Dim outpos As String

        root = "C:\Documents and Settings\popo\デスクトップ\src\Eazy-POS\Common\obj\obj"

        Dim pass As String() = System.IO.Directory.GetFiles(root, "*", System.IO.SearchOption.AllDirectories)
        For i = 0 To pass.Length - 1
            sr = New System.IO.StreamReader(pass(i), System.Text.Encoding.GetEncoding("utf-8"))
            outpos = pass(i).Substring(0, pass(i).LastIndexOf("\"))
            file = pass(i).Substring(pass(i).LastIndexOf("\") + 1, pass(i).Length - pass(i).LastIndexOf("\") - 4)

            sw = New System.IO.StreamWriter(outpos & "\obj\" & file & ".vb", False, System.Text.Encoding.GetEncoding("utf-8"))


            '内容を一行ずつ読み込む
            While sr.Peek() > -1
                buf = sr.ReadLine()
                pos = buf.IndexOf("Public Class")
                If pos >= 0 Then
                    nbuf = buf.Substring(0, buf.LastIndexOf(" "))
                    buf = nbuf & " " & file
                End If
                sw.WriteLine(buf)
            End While
            sr.Close()
            sw.Close()
        Next i
        MsgBox("正常終了")

    End Sub

    Private Sub SourceClassChange_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceClassChange_B.Click
        Dim root As String
        Dim i As Integer
        Dim j As Integer
        Dim sr As System.IO.StreamReader
        Dim sw As System.IO.StreamWriter
        Dim buf As String
        Dim file As String
        Dim outpos As String

        'CSVファイル読込み
        Dim csvRecords As New System.Collections.ArrayList()

        'CSVファイル名
        Dim csvFileName As String = "D:\Working Area\OCF\開発\店舗管理システム\Project\Eazy-POS(DLL)\Dll\conv.txt"

        'Shift JISで読み込む
        Dim tfp As New FileIO.TextFieldParser(csvFileName, System.Text.Encoding.GetEncoding("utf-8"))
        'フィールドが文字で区切られているとする
        'デフォルトでDelimitedなので、必要なし
        tfp.TextFieldType = FileIO.FieldType.Delimited
        '区切り文字を,とする
        tfp.Delimiters = New String() {","}
        'フィールドを"で囲み、改行文字、区切り文字を含めることができるか
        'デフォルトでtrueなので、必要なし
        tfp.HasFieldsEnclosedInQuotes = True
        'フィールドの前後からスペースを削除する
        'デフォルトでtrueなので、必要なし
        tfp.TrimWhiteSpace = True

        While Not tfp.EndOfData
            'フィールドを読み込む
            Dim fields As String() = tfp.ReadFields()
            '保存
            csvRecords.Add(fields)
        End While

        '後始末
        tfp.Close()

        'ソース変換
        root = "C:\Documents and Settings\popo\デスクトップ\src\Eazy-POS\Common\obj"

        Dim pass As String() = System.IO.Directory.GetFiles(root, "*.vb", System.IO.SearchOption.TopDirectoryOnly)

        For i = 0 To pass.Length - 1
            If pass(i).IndexOf("designer") < 0 Then
                sr = New System.IO.StreamReader(pass(i), System.Text.Encoding.GetEncoding("utf-8"))
                outpos = pass(i).Substring(0, pass(i).LastIndexOf("\"))
                file = pass(i).Substring(pass(i).LastIndexOf("\") + 1, pass(i).Length - pass(i).LastIndexOf("\") - 4)

                sw = New System.IO.StreamWriter(outpos & "\obj\" & file & ".vb", False, System.Text.Encoding.GetEncoding("utf-8"))


                '内容を一行ずつ読み込む
                While sr.Peek() > -1
                    buf = sr.ReadLine()
                    For j = 0 To csvRecords.Count - 1
                        buf = buf.Replace(csvRecords(j)(1), csvRecords(j)(0))
                    Next j
                    sw.WriteLine(buf)
                End While
                sr.Close()
                sw.Close()
            End If
        Next i
        MsgBox("正常終了")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim root As String
        Dim i As Integer
        Dim sr As System.IO.StreamReader
        Dim sw As System.IO.StreamWriter
        Dim buf As String
        Dim file As String
        Dim outpos As String

        'ソース変換
        root = "D:\Working Area\OCF\開発\店舗管理システム\Project\Eazy-POS(統合環境)\Common"

        Dim pass As String() = System.IO.Directory.GetFiles(root, "*.vb", System.IO.SearchOption.TopDirectoryOnly)

        For i = 0 To pass.Length - 1
            If pass(i).IndexOf("designer") < 0 Then
                sr = New System.IO.StreamReader(pass(i), System.Text.Encoding.GetEncoding("utf-8"))
                outpos = pass(i).Substring(0, pass(i).LastIndexOf("\"))
                file = pass(i).Substring(pass(i).LastIndexOf("\") + 1, pass(i).Length - pass(i).LastIndexOf("\") - 4)

                sw = New System.IO.StreamWriter(outpos & "\obj\" & file & ".vb", False, System.Text.Encoding.GetEncoding("utf-8"))


                '内容を一行ずつ読み込む
                While sr.Peek() > -1
                    buf = sr.ReadLine()
                    buf = buf.Replace("System.Windows.Forms.Application.Exit()", "Environment.Exit(1)")
                    sw.WriteLine(buf)
                End While
                sr.Close()
                sw.Close()
            End If
        Next i
        MsgBox("正常終了")

    End Sub

    Private Sub STAFF_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAFF_B.Click
        Dim fCreateForm As New fCreateStaffCode
        fCreateForm.ShowDialog()
        fCreateForm = Nothing

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim oConfigDBIO As New cMstConfigDBIO(oConn, oCommand, oDataReader)
        Dim i As Integer
        Dim max As Long
        Dim oConfig() As cStructureLib.sConfig

        max = 100000
        For i = 0 To max
            ProgressBar.Maximum = max
            ProgressBar.Value = i

            ReDim oConfig(0)
            oConfigDBIO.getConfMst(oConfig, oTran)

        Next
        MsgBox("完了")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim StrPath As String
        Dim DB_Path As String

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NETによる'DB接続文字列の設定
        '注：プロジェクトファイルホルダの下にあるbinホルダにMDBを置く

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        'ＤＢ接続を開く
        oConn.Open()

        oConfMstDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        Dim CreaterakutenTAX As New cCreateRakutenTAX( _
                                      oConf(0).sRakutenRMSUserID, _
                                      oConf(0).sRakutenRMSUserPASS, _
                                      oConf(0).sRakutenUserID, _
                                      oConf(0).sRakutenUserPASS, _
                                      oConf(0).sRakutenCSVDownloadID, _
                                      oConf(0).sRakutenCSVDownloadPASS, _
                                      oConf(0).sTempFilePath _
                                   )
    End Sub

    Private Sub TRN_B_Click(sender As Object, e As EventArgs) Handles TRN_B.Click
        Dim fCreateForm As New fCreateTrnCode
        fCreateForm.ShowDialog()
        fCreateForm = Nothing

    End Sub
End Class
