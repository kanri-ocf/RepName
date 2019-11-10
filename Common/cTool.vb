Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class cTool
    Private ON_COLOR As System.Drawing.Color = System.Drawing.Color.SkyBlue
    Private OFF_COLOR As System.Drawing.Color = System.Drawing.Color.Tan

    Private Delegate Function D_EnumChildWindowsProc _
        (ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Private Const WM_ACTIVATE = &H6
    Private Const BM_CLICK = &HF5
    Private Const WM_GETTEXT = &HD
    Private Const WM_QUIT = &H10

    Private Const NAVDIR_NEXT = &H5
    Private Const NAVDIR_FIRSTCHILD = &H7
    Private Const CHILDID_SELF = &H0
    Private Const OBJID_CLIENT = &HFFFFFFFC

    '***************************************************************************
    '    JANコード用チェックデジット生成
    '　[引数]
    '     argCode   : 生成元コード(チェックデジット（末尾1Byte）付加前のコード)
    '  [戻り値]
    '     正常      : チェックデジット付加後のJANコード
    '     異常      : 空のデータ
    '***************************************************************************

    Public Function JANCD(ByVal argCode As String) As String
        Dim strCode As String
        Dim intDigit As Integer
        Dim intPos As Integer
        Dim intCD As Integer

        Select Case Len(argCode)
            Case 7, 8
                strCode = Mid(argCode, 1, 7)
                For intPos = 1 To 7 Step 2
                    intDigit = intDigit + CInt(Mid(strCode, intPos, 1))
                Next
                intDigit = intDigit * 3
                For intPos = 2 To 6 Step 2
                    intDigit = intDigit + CInt(Mid(strCode, intPos, 1))
                Next

            Case 12, 13
                strCode = Mid(argCode, 1, 12)
                For intPos = 2 To 12 Step 2
                    intDigit = intDigit + CInt(Mid(strCode, intPos, 1))
                Next
                intDigit = intDigit * 3
                For intPos = 1 To 11 Step 2
                    intDigit = intDigit + CInt(Mid(strCode, intPos, 1))
                Next
            Case Else
                JANCD = ""
                Exit Function
        End Select
        intCD = intDigit Mod 10
        If intCD <> 0 Then
            intCD = 10 - intCD
        End If
        JANCD = strCode & Format(intCD)
    End Function
    '指定GRIDの指定列の値の最大値を返します。
    'Col：0～
    Public Function LookUpNewNo(ByRef DATA_V As System.Windows.Forms.DataGridView, ByVal Col As Integer) As Integer
        Dim up As Integer
        Dim i As Integer

        up = 0
        For i = 0 To DATA_V.RowCount - 1
            If up < CInt(DATA_V(Col, i).Value) Then
                up = CInt(DATA_V(Col, i).Value)
            End If
        Next i
        LookUpNewNo = up + 1
    End Function
    'Public Sub BUTTOM_COLOR_SET(ByVal Btn As Control, ByVal Mode As String)
    '    If Mode = "On" Then
    '        Btn.BackColor = ON_COLOR
    '    Else
    '        Btn.BackColor = OFF_COLOR
    '    End If
    'End Sub
    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iStart">
    '''     取り出しを開始する位置。</param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     指定されたバイト位置から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function MidB _
    (ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        If btBytes.Length < iByteSize Then
            iByteSize = btBytes.Length
        End If
        Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
    End Function

    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に四捨五入します。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に四捨五入された数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToHalfAdjust(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function

    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り上げします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り上げられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToRoundUp(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        Else
            Return System.Math.Floor(dValue * dCoef) / dCoef
        End If
    End Function
    ''' ------------------------------------------------------------------------
    ''' <summary>
    '''     指定した精度の数値に切り捨てします。</summary>
    ''' <param name="dValue">
    '''     丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">
    '''     戻り値の有効桁数の精度。</param>
    ''' <returns>
    '''     iDigits に等しい精度の数値に切り捨てられた数値。</returns>
    ''' ------------------------------------------------------------------------
    Public Function ToRoundDown(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor(dValue * dCoef) / dCoef
        Else
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        End If
    End Function
    Public Function RegistryRead(ByVal KetString As String) As String
        'キーを読み取り専用で開く()
        Dim regkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Ocf\Eazy_POS\", False)

        'キーが存在しないときはNothingが返される
        If (regkey Is Nothing) Then
            RegistryRead = Nothing
            Exit Function
        End If
        '文字列を読み込む
        '読み込む値が存在しないときはNothingが返される
        Dim stringValue As String = CType(regkey.GetValue(KetString), String)

        If stringValue = Nothing Then
            RegistryRead = Nothing
        Else
            RegistryRead = stringValue
        End If

    End Function

    Public Function FileSearch(ByVal pTitle As String, ByVal pInitPath As String) As String
        ' OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
        Dim OpenFileDialog1 As New System.Windows.Forms.OpenFileDialog()

        FileSearch = ""

        ' ダイアログのタイトルを設定する
        OpenFileDialog1.Title = pTitle

        ' 初期表示するディレクトリを設定する
        OpenFileDialog1.InitialDirectory = pInitPath

        ' 初期表示するファイル名を設定する
        OpenFileDialog1.FileName = "初期表示するファイル名をココに書く"

        ' ファイルのフィルタを設定する
        OpenFileDialog1.Filter = "テキスト ファイル|*.txt;*.log|すべてのファイル|*.*"

        ' ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
        OpenFileDialog1.FilterIndex = 1

        ' ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
        OpenFileDialog1.RestoreDirectory = True

        ' 複数のファイルを選択可能にする (初期値 False)
        OpenFileDialog1.Multiselect = False

        ' [ヘルプ] ボタンを表示する (初期値 False)
        OpenFileDialog1.ShowHelp = True

        ' [読み取り専用] チェックボックスを表示する (初期値 False)
        OpenFileDialog1.ShowReadOnly = False

        ' [読み取り専用] チェックボックスをオンにする (初期値 False)
        OpenFileDialog1.ReadOnlyChecked = False

        ' 存在しないファイルを指定した場合は警告を表示する (初期値 True)
        OpenFileDialog1.CheckFileExists = False

        ' 存在しないパスを指定した場合は警告を表示する (初期値 True)
        'OpenFileDialog1.CheckPathExists = True

        ' 拡張子を指定しない場合は自動的に拡張子を付加する (初期値 True)
        'OpenFileDialog1.AddExtension = True

        ' 有効な Win32 ファイル名だけを受け入れるようにする (初期値 True)
        'OpenFileDialog1.ValidateNames = True

        ' ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            FileSearch = OpenFileDialog1.FileName

            ' Multiselect が True の場合はこのように列挙する
            'For Each nFileName As String In OpenFileDialog1.FileNames
            '    MessageBox.Show(nFileName)
            'Next nFileName
        End If

        ' 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
        OpenFileDialog1.Dispose()
    End Function
    Public Function FileSearch(ByVal pTitle As String, ByVal pInitPath As String, ByVal pInitFileName As String) As String
        ' OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
        Dim OpenFileDialog1 As New System.Windows.Forms.OpenFileDialog()

        FileSearch = ""

        ' ダイアログのタイトルを設定する
        OpenFileDialog1.Title = pTitle

        ' 初期表示するディレクトリを設定する
        OpenFileDialog1.InitialDirectory = pInitPath

        ' 初期表示するファイル名を設定する
        OpenFileDialog1.FileName = pInitFileName

        ' ファイルのフィルタを設定する
        OpenFileDialog1.Filter = "テキスト ファイル|*.txt;*.log|すべてのファイル|*.*"

        ' ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
        OpenFileDialog1.FilterIndex = 2

        ' ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
        OpenFileDialog1.RestoreDirectory = True

        ' 複数のファイルを選択可能にする (初期値 False)
        OpenFileDialog1.Multiselect = False

        ' [ヘルプ] ボタンを表示する (初期値 False)
        OpenFileDialog1.ShowHelp = True

        ' [読み取り専用] チェックボックスを表示する (初期値 False)
        OpenFileDialog1.ShowReadOnly = True

        ' [読み取り専用] チェックボックスをオンにする (初期値 False)
        OpenFileDialog1.ReadOnlyChecked = True

        ' ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            FileSearch = OpenFileDialog1.FileName
        End If

        ' 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
        OpenFileDialog1.Dispose()
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function BitBlt(ByVal hdcDest As IntPtr, _
        ByVal nXDest As Integer, ByVal nYDest As Integer, _
        ByVal nWidth As Integer, ByVal nHeight As Integer, _
        ByVal hdcSrc As IntPtr, _
        ByVal nXSrc As Integer, ByVal nYSrc As Integer, _
        ByVal dwRop As Integer) As Boolean
    End Function
    'フォームのイメージを取得する
    Public Function CaptureControl(ByVal ctrl As System.Windows.Forms.Control, ByVal sPath As String) As String
        Dim g As System.Drawing.Graphics
        Dim img As System.Drawing.Bitmap
        Dim memg As System.Drawing.Graphics
        Dim dc1 As IntPtr
        Dim dc2 As IntPtr
        Dim path As String

        g = ctrl.CreateGraphics()
        img = New System.Drawing.Bitmap(ctrl.ClientRectangle.Width, ctrl.ClientRectangle.Height, g)
        memg = System.Drawing.Graphics.FromImage(img)
        dc1 = g.GetHdc()
        dc2 = memg.GetHdc()

        path = sPath & String.Format("\BarCodeBmp_{0:0,13:C}.png", ctrl.Text)

        BitBlt(dc2, 0, 0, img.Width - 10, img.Height, dc1, 0, 0, &HCC0020)
        g.ReleaseHdc(dc1)
        g.Dispose()
        g = Nothing
        memg.ReleaseHdc(dc2)
        memg.Dispose()
        memg = Nothing

        'キャプチャー結果の保存
        img.Save(path)
        img.Dispose()
        img = Nothing

        CaptureControl = path

    End Function
    Function CalYear(ByVal Birthday As Date, ByVal CalData As Date) As Long
        Dim iYear As Long
        Dim CalcYearBirthDay As Date

        '計算年の誕生日を割り出し 
        CalcYearBirthDay = CDate(CalData.Year & "/" & Birthday.Month & "/" & Birthday.Day)

        '計算年の誕生日前 
        If CalData < CalcYearBirthDay Then
            iYear = CalData.Year - Birthday.Year - 1
            '誕生日後 
        Else
            iYear = CalData.Year - Birthday.Year
        End If

        CalYear = iYear
    End Function
    Function ComboSerch(ByRef Combo As System.Windows.Forms.ComboBox, ByVal KeyString As String) As Integer
        Dim i As Integer

        ComboSerch = -1

        For i = 0 To Combo.Items.Count - 1
            If Combo.Items(i).ToString.IndexOf(KeyString) >= 0 Then
                ComboSerch = i
            End If
        Next
    End Function

    <DllImport("USER32.DLL", CharSet:=CharSet.Auto)> _
    Private Shared Function ShowWindow( _
     ByVal hWnd As System.IntPtr, _
     ByVal nCmdShow As Integer) As Integer
    End Function

    <DllImport("USER32.DLL", CharSet:=CharSet.Auto)> _
    Private Shared Function SetForegroundWindow( _
        ByVal hWnd As System.IntPtr) As Boolean
    End Function

    Private Const SW_NORMAL As Integer = 1

    ''' ------------------------------------------------------------------------------------
    ''' <summary>
    '''     同名のプロセスが起動中の場合、メイン ウィンドウをアクティブにします。</summary>
    ''' <returns>
    '''     既に起動中であれば True。それ以外は False。</returns>
    ''' ------------------------------------------------------------------------------------
    Public Shared Function ShowPrevProcess() As Boolean
        Dim hThisProcess As Process = Process.GetCurrentProcess()
        Dim hProcesses As Process() = Process.GetProcessesByName(hThisProcess.ProcessName)
        Dim iThisProcessId As Integer = hThisProcess.Id

        For Each hProcess As Process In hProcesses
            If hProcess.Id <> iThisProcessId Then
                Call ShowWindow(hProcess.MainWindowHandle, SW_NORMAL)
                Call SetForegroundWindow(hProcess.MainWindowHandle)
                Return True
            End If
        Next hProcess

        Return False
    End Function

    Public Function KillProcess(ByVal KeyProcessName As String) As Boolean
        Dim ps As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(KeyProcessName)

        '配列から1つずつ取り出す
        For Each p As System.Diagnostics.Process In ps
            'プロセスを強制的に終了させる
            p.Kill()
        Next

    End Function
    '*******************************************************************************
    '* Access(mdb)ﾌｧｲﾙの最適化処理
    '*******************************************************************************
    '* 使用方法 * 
    '*  参照設定でJRO(※１)を追加してください。
    '*   ※１：COMのタブを押し、Microsoft Jet and Replication Objects X.x Libraryを選択
    '*         現時点では、X.xは2.6が最新だと思います。C:\Working Area\開発\店舗管理システム\Common\cDataTrnSubDBIO.vb
    '*  Const定義は任意で指定してください。
    '*******************************************************************************
    Public Sub CompactDatabase(ByVal KeyFromPath As String, ByVal KeyToPath As String)

        Dim jro As New JRO.JetEngine
        Dim OrgPath As String
        Dim TargetPath As String
        Dim youbi As String
        Dim dt As DateTime
        Dim pFileInfo As System.IO.FileInfo

        dt = DateTime.Today
        youbi = ""
        Select Case dt.DayOfWeek
            Case 0
                youbi = "Sun"
            Case 1
                youbi = "Mon"
            Case 2
                youbi = "Tue"
            Case 3
                youbi = "Wed"
            Case 4
                youbi = "Thu"
            Case 5
                youbi = "Fri"
            Case 6
                youbi = "Sat"
        End Select

        'Jet4.0の最適化のためのパラメータ生成
        OrgPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & KeyFromPath & "\OwP-DB.mdb;"
        TargetPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & KeyToPath & "\" & youbi & "\OwP-DB.mdb;Jet OLEDB:Engine Type=5;"

        'ターゲットDBの削除
        If System.IO.File.Exists(KeyToPath & "\" & youbi & "\Owp-DB.mdb") = True Then
            System.IO.File.Delete(KeyToPath & "\" & youbi & "\Owp-DB.mdb")
        End If

        'Jet4.0の最適化
        jro.CompactDatabase(OrgPath, TargetPath)
        jro = Nothing

        pFileInfo = New System.IO.FileInfo(KeyToPath & "\" & youbi & "\Owp-DB.mdb")
        If pFileInfo.LastWriteTime.ToString("yyyy/MM/dd") = DateTime.Now.ToString("yyyy/MM/dd") Then
            System.IO.File.Copy(KeyToPath & "\" & youbi & "\Owp-DB.mdb", KeyFromPath & "\OwP-DB.mdb", True)
        End If

        pFileInfo = Nothing
    End Sub

    Public Function CripNoteRead(ByVal FileName As String) As String
        Dim sr As System.IO.StreamReader
        Dim str() As String

        If System.IO.File.Exists(FileName) Then
            sr = New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
        Else
            CripNoteRead = ""
            Exit Function
        End If
        '内容を一行読み込む
        str = sr.ReadLine().ToString.Split(":")
        CripNoteRead = str(9)
        sr.Close()
        sr = Nothing

    End Function
    Public Function MemoToDBString(ByVal MemoData As String) As String
        Dim i As Integer
        Dim str As String

        str = ""
        For i = 0 To MemoData.Length - 1
            If Asc(MemoData.Substring(i, 1)) = 13 Then
                str = str + "+vbCrLf+"
                i = i + 1
            Else
                str = str + MemoData.Substring(i, 1)
            End If
        Next

        MemoToDBString = str
    End Function


    '----------------------------------------------------
    '税抜き金額→税込み金額
    '----------------------------------------------------

    Public Function BeforeToAfterTax(ByVal BrforeTaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long
        Dim pTax As Double

        '消費税算出
        pTax = BrforeTaxValue * Tax / 100

        '消費税額の端数処理
        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                pTax = ToHalfAdjust(pTax, 0)
            Case 1  '切り捨て
                pTax = ToRoundDown(pTax, 0)
            Case 2  '切り上げ
                pTax = ToRoundUp(pTax, 0)
        End Select

        '税抜き金額＋消費税
        BeforeToAfterTax = BrforeTaxValue + pTax
    End Function

    '----------------------------------------------------
    '税込み金額→税抜き金額
    '----------------------------------------------------

    Public Function AfterToBeforeTax(ByVal AfterTaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long
        Dim pTax As Double

        '消費税算出
        pTax = AfterTaxValue * Tax / (100 + Tax)

        '消費税額の端数処理
        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                pTax = ToHalfAdjust(pTax, 0)
            Case 1  '切り捨て
                pTax = ToRoundDown(pTax, 0)
            Case 2  '切り上げ
                pTax = ToRoundUp(pTax, 0)
        End Select

        '税込み金額－消費税
        AfterToBeforeTax = AfterTaxValue - pTax
    End Function

    '----------------------------------------------------
    '税抜き金額→消費税
    '----------------------------------------------------
     Public Function BeforeToTax(ByVal BeforeTaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long
        Dim roundDownValue As Double

        roundDownValue = BeforeTaxValue * Tax / 100
 
        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                roundDownValue = ToHalfAdjust(roundDownValue, 0)
            Case 1  '切り捨て
                roundDownValue = ToRoundDown(roundDownValue, 0)
            Case 2  '切り上げ
                roundDownValue = ToRoundUp(roundDownValue, 0)
        End Select
        BeforeToTax = roundDownValue
    End Function

    '----------------------------------------------------
    '税込み金額→消費税
    '----------------------------------------------------
    Public Function AfterToTax(ByVal AfterTaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long
        Dim roundDownValue As Double

        roundDownValue = AfterTaxValue * Tax / (100 + Tax)
        ' 丸め誤差を訂正する
        roundDownValue = ToHalfAdjust(roundDownValue, 1)

        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                roundDownValue = ToHalfAdjust(roundDownValue, 0)
            Case 1  '切り捨て
                roundDownValue = ToRoundDown(roundDownValue, 0)
            Case 2  '切り上げ
                roundDownValue = ToRoundUp(roundDownValue, 0)
        End Select
        AfterToTax = roundDownValue
    End Function
    '----------------------------------------------------
    '消費税→税抜き金額
    '----------------------------------------------------
    Public Function TaxToBeforeTax(ByVal TaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long
        Dim roundDownValue As Double

        roundDownValue = TaxValue / (Tax / 100)
        ' 丸め誤差を訂正する
        roundDownValue = ToHalfAdjust(roundDownValue, 1)

        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                roundDownValue = ToHalfAdjust(roundDownValue, 0)
            Case 1  '切り捨て
                roundDownValue = ToRoundDown(roundDownValue, 0)
            Case 2  '切り上げ
                roundDownValue = ToRoundUp(roundDownValue, 0)
        End Select
        TaxToBeforeTax = roundDownValue
    End Function

    '----------------------------------------------------
    '消費税→税込み金額
    '----------------------------------------------------
    Public Function TaxToAfterTax(ByVal TaxValue As Single, ByVal Tax As Integer, ByVal FracProc As Integer) As Long

        Dim roundDownValue As Double

        roundDownValue = TaxValue * (100 + Tax) / Tax

        Select Case FracProc  '端数処理
            Case 0  '四捨五入
                roundDownValue = ToHalfAdjust(roundDownValue, 0)
            Case 1  '切り捨て
                roundDownValue = ToRoundDown(roundDownValue, 0)
            Case 2  '切り上げ
                roundDownValue = ToRoundUp(roundDownValue, 0)
        End Select
        TaxToAfterTax = roundDownValue
    End Function

    Private player As Media.SoundPlayer = Nothing
    Public Sub PlaySound()

        '再生されているときは止める
        If Not (player Is Nothing) Then
            StopSound()
        End If

        '読み込む
        '2016.06.09 K.Oikawa s
        'ベタ書きになっていたので修正
        'player = New System.Media.SoundPlayer("C:\WorkingArea\OCF\開発\店舗管理システム\Tool\WAV\click.wav")
        player = New System.Media.SoundPlayer(System.Windows.Forms.Application.StartupPath & "\WAV\click.wav")
        '2016.06.09 K.Oikawa e

        '非同期再生する
        player.Play()

    End Sub
    '再生されている音を止める
    Private Sub StopSound()
        If Not (player Is Nothing) Then
            player.Stop()
            player.Dispose()
            player = Nothing
        End If
    End Sub

    Public Function MaskClear(ByVal MaskString As String) As String
        Dim st As String

        st = MaskString.Replace(" ", "")
        If st = "//" Then
            MaskClear = Nothing
        Else
            MaskClear = st
        End If
    End Function
    Public Function GetRunExe() As String
        Dim FullPath As String

        '実行EXE名称取得
        FullPath = System.Windows.Forms.Application.ExecutablePath
        GetRunExe = FullPath.Substring(FullPath.LastIndexOf("\") + 1, (FullPath.Length - FullPath.LastIndexOf("\")) - 1)

    End Function
    ''' <summary>
    ''' 指定年月の末日を取得する
    ''' </summary>
    ''' <param name="yearmonth">yyyy/MM</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEndDate(ByVal yearmonth As String) As DateTime

        Dim d As DateTime

        If DateTime.TryParse(yearmonth & "/01", d) Then
            '翌月の1日前を返す
            Return d.AddMonths(1).AddDays(-1)
        Else
            Throw New ArgumentException("yearmonthが不正です。yyyy/MMを指定してください。")
        End If

    End Function

    Public Sub Wait(ByVal WaitTime As Long)

        Dim i As Long

        For i = 0 To WaitTime * 1000
            '......Wait
        Next
    End Sub

    Public Function DmyReplace(ByVal str As String) As String
        Dim i As Integer
        Dim AfterStr As String

        AfterStr = "%"
        For i = 0 To str.Length - 1
            AfterStr = AfterStr & str.Substring(i, 1) & "%"
        Next

        DmyReplace = AfterStr
    End Function



    '----------------------------------------------------
    '2015/07/01
    '及川和彦
    'FROM
    '----------------------------------------------------
    Public Function GetKeyProduct(ByVal keyProduct As String, ByRef parProduct() As cStructureLib.sProduct) As String
        Dim i As Integer
        Dim returnProductCode As String

        returnProductCode = Nothing

        For i = 0 To parProduct.Length - 1
            If (i + 1) <> CInt(parProduct(i).sProductCode.Substring(6, 2)) Then
                returnProductCode = keyProduct & "-" & String.Format("{0:00}", i + 1)
                Exit For
            End If
        Next
        '空き番がなかった場合は最大値+1の値
        If returnProductCode = Nothing Then
            returnProductCode = keyProduct & "-" & String.Format("{0:00}", i + 1)
        End If
        Return returnProductCode


    End Function

    '----------------------------------------------------
    'HERE
    '----------------------------------------------------

    ''' <summary>
    ''' 文字列を暗号化する
    ''' </summary>
    ''' <param name="sourceString">暗号化する文字列</param>
    ''' <param name="password">暗号化に使用するパスワード</param>
    ''' <returns>暗号化された文字列</returns>
    Public Shared Function EncryptString(ByVal sourceString As String, _
                                         ByVal password As String) As String
        'RijndaelManagedオブジェクトを作成
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte(), iv As Byte()

        key = Nothing
        iv = Nothing

        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '文字列をバイト型配列に変換する
        Dim strBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(sourceString)

        '対称暗号化オブジェクトの作成
        Dim encryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateEncryptor()
        'バイト型配列を暗号化する
        Dim encBytes As Byte() = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length)
        '閉じる
        encryptor.Dispose()

        'バイト型配列を文字列に変換して返す
        Return System.Convert.ToBase64String(encBytes)
    End Function


    ''' <summary>
    ''' パスワードから共有キーと初期化ベクタを生成する
    ''' </summary>
    ''' <param name="password">基になるパスワード</param>
    ''' <param name="keySize">共有キーのサイズ（ビット）</param>
    ''' <param name="key">作成された共有キー</param>
    ''' <param name="blockSize">初期化ベクタのサイズ（ビット）</param>
    ''' <param name="iv">作成された初期化ベクタ</param>
    Private Shared Sub GenerateKeyFromPassword(ByVal password As String, _
                                               ByVal keySize As Integer, _
                                               ByRef key As Byte(), _
                                               ByVal blockSize As Integer, _
                                               ByRef iv As Byte())
        'パスワードから共有キーと初期化ベクタを作成する
        'saltを決める
        Dim salt As Byte() = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上")
        'Rfc2898DeriveBytesオブジェクトを作成する
        Dim deriveBytes As New System.Security.Cryptography.Rfc2898DeriveBytes( _
            password, salt)
        '.NET Framework 1.1以下の時は、PasswordDeriveBytesを使用する
        'Dim deriveBytes As New System.Security.Cryptography.PasswordDeriveBytes( _
        '    password, salt)

        '反復処理回数を指定する デフォルトで1000回
        deriveBytes.IterationCount = 1000

        '共有キーと初期化ベクタを生成する
        key = deriveBytes.GetBytes(keySize \ 8)
        iv = deriveBytes.GetBytes(blockSize \ 8)
    End Sub

    'Public Sub netButtonLicense()
    '    '----------------------- SoftGroupライセンス認証 ----------------------
    '    Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
    '    Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
    '    Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
    '    '----------------------------------------------------------------------
    'End Sub

End Class

