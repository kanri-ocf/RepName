Public Class fBomMst
    Inherits System.Windows.Forms.Form

    Private Const DISP_ROW_MAX = 500

    Private oTool As cTool

    '------------------------------------
    ' DBアクセス関連
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oBom() As cStructureLib.sBom
    Private oViewBom() As cStructureLib.sViewBom
    Private oMstBomDBIO As cMstBomDBIO

    Private oProduct() As cStructureLib.sProduct
    Private oMstProductDBIO As cMstProductDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private STAFF_CODE As String
    Private STAFF_NAME As String
    Private PRODUCT_CODE As String

    Private IVENT_FLG As Boolean

    Private counter As Integer = 0

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

        'oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)
        oMstBomDBIO = New cMstBomDBIO(oConn, oCommand, oDataReader)
        oMstProductDBIO = New cMstProductDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        PRODUCT_CODE = Nothing
        STAFF_CODE = Nothing
        STAFF_NAME = Nothing

    End Sub
    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByVal ProductCode As String, _
            ByVal StaffCode As String, _
            ByVal StaffName As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader
        oTran = iTran

        oMstBomDBIO = New cMstBomDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

        oTool = New cTool
        PRODUCT_CODE = ProductCode
        STAFF_CODE = StaffCode
        STAFF_NAME = StaffName

    End Sub

    Private Sub fMstBOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroupライセンス認証 ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '環境マスタ読込み
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            'メッセージウィンドウ表示
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "環境マスタの読込みに失敗しました", _
                                            "開発元にお問い合わせ下さい", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        If STAFF_CODE = Nothing Then
            'スタッフ入力ウィンドウ表示
            Dim staff_form As cStaffEntryLib.fStaffEntry

            staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
            staff_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            STAFF_CODE = staff_form.STAFF_CODE_T.Text
            STAFF_NAME = staff_form.STAFF_NAME_T.Text
            staff_form = Nothing
        End If

        IVENT_FLG = True

        '表示初期化処理
        INIT_PROC()


        'イベントハンドラを追加する
        AddHandler TREEVIEW.ItemDrag, AddressOf TREEVIEW_ItemDrag
        AddHandler TREEVIEW.DragOver, AddressOf TREEVIEW_DragOver
        AddHandler TREEVIEW.DragDrop, AddressOf TREEVIEW_DragDrop

    End Sub
    ' TreeViewコントロールのデータを更新します。
    Private Sub RefreshTreeView()
        TREEVIEW.Nodes.Clear()

        Dim treeNodeFruits As New System.Windows.Forms.TreeNode("果物")
        Dim treeNodeVegetables As New System.Windows.Forms.TreeNode("野菜")
        Dim treeNodeSubFolder() As System.Windows.Forms.TreeNode = {treeNodeFruits, treeNodeVegetables}

        ' 下位階層に対してまとめて項目（ノード）を追加
        Dim treeNodeFood As New System.Windows.Forms.TreeNode("食べ物", treeNodeSubFolder)

        Dim treeNodeDrink As New System.Windows.Forms.TreeNode("飲み物")
        Dim treeNodeRoot() As System.Windows.Forms.TreeNode = {treeNodeFood, treeNodeDrink}

        ' 最上位階層に対してまとめて項目（ノード）を追加
        TREEVIEW.Nodes.AddRange(treeNodeRoot)

        TREEVIEW.TopNode.Expand()
    End Sub

    Private Sub INIT_PROC()

        MODE_T.Text = "（新規）"
        MODE_T.BackColor = Drawing.Color.Red

        STRUCTURE_CODE_T.Text = ""
        PRODUCT_CODE_T.Text = ""
        PRODUCT_NAME_T.Text = ""
        OPTION_NAME_T.Text = ""

        TREEVIEW.Nodes.Clear()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim form_message As cMessageLib.fMessage

        If PRODUCT_CODE_T.Text = "" Then
            form_message = New cMessageLib.fMessage(1, "", "構成TOPの擬似品目を指定して下さい。", "", "")
            form_message = Nothing
            INPUT_CHECK = False
            Exit Function
        Else
            INPUT_CHECK = True
        End If

    End Function
    ''******************************************************************
    ''システム・ショートカット・キーによるダイアログの終了を阻止する
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows標準の処理は行わない
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
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
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function
 
    '***********************************************
    '更新対象の商品マスタ情報を画面にセット
    '***********************************************
    Private Sub UPDATE_STRUCTURE_SET()
        Dim RecordCount As Long
        Dim str As String
        Dim ostr As String
        Dim i As Integer
        Dim pParent() As Integer
        Dim pInNo() As Integer

        TREEVIEW.Nodes.Clear()

        '構成情報セット
        ReDim oViewBom(0)
        RecordCount = oMstBomDBIO.getFullBom(oViewBom, Nothing, PRODUCT_CODE_T.Text, 0, Nothing, oTran)
        If RecordCount > 0 Then
            MODE_T.Text = "（更新）"
            MODE_T.BackColor = Drawing.Color.Blue
            STRUCTURE_CODE_T.Text = oViewBom(0).sStructureCode
        Else
            MODE_T.Text = "（新規）"
            MODE_T.BackColor = Drawing.Color.Red
        End If

        str = PRODUCT_CODE_T.Text & "::" & PRODUCT_NAME_T.Text
        If OPTION_NAME_T.Text <> "" Then
            str = str & OPTION_NAME_T.Text
        End If
        TREEVIEW.Nodes.Add(str)

        If RecordCount > 0 Then
            RecordCount = oMstBomDBIO.getFullBom(oViewBom, oViewBom(0).sStructureCode, Nothing, Nothing, Nothing, oTran)

            i = 0
            ReDim pParent(0)
            ReDim pInNo(4)
            pParent(0) = 0
            pInNo(0) = 0
            pInNo(1) = 0
            pInNo(2) = 0
            pInNo(3) = 0
            For i = 1 To oViewBom.Length - 1

                str = ""
                ostr = ""

                '階層別親ノードの保持
                ReDim Preserve pParent(oViewBom(i).sHiearchyNo)
                pParent(oViewBom(i).sHiearchyNo) = oViewBom(i).sNodeNo - 1

                str = oViewBom(i).sProductCode & "::" & oViewBom(i).sProductName
                If oViewBom(i).sOption1 <> "" Then
                    If ostr = "" Then
                        ostr = " ("
                    Else
                        ostr = ostr & ","
                    End If
                    ostr = ostr & oViewBom(i).sOption1
                End If
                If oViewBom(i).sOption2 <> "" Then
                    If ostr = "" Then
                        ostr = " ("
                    Else
                        ostr = ostr & ","
                    End If
                    ostr = ostr & oViewBom(i).sOption2
                End If
                If oViewBom(i).sOption3 <> "" Then
                    If ostr = "" Then
                        ostr = " ("
                    Else
                        ostr = ostr & ","
                    End If
                    ostr = ostr & oViewBom(i).sOption3
                End If
                If oViewBom(i).sOption4 <> "" Then
                    If ostr = "" Then
                        ostr = " ("
                    Else
                        ostr = ostr & ","
                    End If
                    ostr = ostr & oViewBom(i).sOption4
                End If
                If oViewBom(i).sOption5 <> "" Then
                    If ostr = "" Then
                        ostr = " ("
                    Else
                        ostr = ostr & ","
                    End If
                    ostr = ostr & oViewBom(i).sOption5
                End If
                If ostr <> "" Then
                    ostr = ostr & ")"
                End If
                str = str & ostr

                Select Case oViewBom(i).sHiearchyNo
                    Case 2
                        TREEVIEW.Nodes(pInNo(0)).Nodes.Add(str)
                        pInNo(1) = pInNo(1) + 1
                    Case 3
                        TREEVIEW.Nodes(pInNo(0)).Nodes(pInNo(2)).Nodes.Add(str)
                        pInNo(2) = pInNo(2) + 1
                    Case 4
                        TREEVIEW.Nodes(pInNo(0)).Nodes(pInNo(1)).Nodes(pParent(pInNo(2))).Nodes.Add(str)
                        pInNo(3) = pInNo(3) + 1
                    Case 5
                        TREEVIEW.Nodes(pInNo(0)).Nodes(pInNo(1)).Nodes(pParent(pInNo(2))).Nodes(pParent(pInNo(3))).Nodes.Add(str)
                End Select
            Next

        End If

        TREEVIEW.TopNode.Expand()

    End Sub
    Private Function CREATE_STRUCTURE_CODE() As Long
        Dim StCode As Long

        StCode = oMstBomDBIO.readMaxBomCode(oTran) + 1
        CREATE_STRUCTURE_CODE = StCode
    End Function
    Private Function GetAllNodes(ByVal pNodes As System.Windows.Forms.TreeNodeCollection) As ArrayList
        Dim Ar As New ArrayList
        Dim pNode As System.Windows.Forms.TreeNode

        For Each pNode In pNodes
            Ar.Add(pNode)
            If pNode.GetNodeCount(False) > 0 Then
                Ar.AddRange(GetAllNodes(pNode.Nodes))
            End If
        Next

        Return Ar

    End Function
    Private Function GetHiearchyNo(ByVal pFullPath As String) As Integer
        Dim foundIndex As Integer = pFullPath.IndexOf("\")
        Dim count As Integer

        count = 0
        While 0 <= foundIndex
            count = count + 1

            '次の検索開始位置
            Dim nextIndex As Integer = foundIndex + "\".Length

            If nextIndex < pFullPath.Length Then
                '次の位置を探す
                foundIndex = pFullPath.IndexOf("\", nextIndex)
            Else
                '最後まで検索したときは終わる
                Exit While
            End If
        End While

        GetHiearchyNo = count + 1
    End Function

    Private Sub WRITE_DATA_SET(ByVal pNode As System.Windows.Forms.TreeNode, _
                               ByVal pNodeNo As Integer, _
                               ByVal pHiearChyNo As Integer, _
                               ByVal pParentNo As Integer)
        Dim stArray As String()

        '構成マスタ情報セット
        ReDim oBom(0)
        oBom(0).sStructureCode = CLng(STRUCTURE_CODE_T.Text)
        oBom(0).sNodeNo = pNodeNo
        oBom(0).sHiearchyNo = pHiearChyNo
        oBom(0).sParentNodeNo = pParentNo
        stArray = pNode.Text.ToString.Split(":")
        oBom(0).sProductCode = stArray(0)


    End Sub
    Private Function WRITE_PROC() As Boolean
        Dim RecordCount As Long


        '---------------- 新規登録 -----------------
        If MODE_T.Text = "（新規）" Then
            '構成マスタ登録
            RecordCount = oMstBomDBIO.insertBomMst(oBom, oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If

        Else
            '---------------- 更新 -----------------
            '構成マスタ更新
            RecordCount = oMstBomDBIO.updateBomMst(oBom, oTran)
            If RecordCount = False Then
                oTran.Rollback()
                WRITE_PROC = False
                Exit Function
            End If
        End If

        '---トランザクション終了
        oTran.Commit()

        WRITE_PROC = True

    End Function

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        Dim product_search_form As cSelectLib.fProductSearch
        Dim Message_form As cMessageLib.fMessage

        If IsNothing(oTran) = False Then
            oTran = Nothing
        End If
        product_search_form = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, 3, oTran)
        product_search_form.ShowDialog()
        If product_search_form.DialogResult = Windows.Forms.DialogResult.OK Then
            ReDim oProduct(0)
            oMstProductDBIO.getProduct(oProduct, Nothing, product_search_form.S_PRODUCT_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
            If oProduct(0).sProductClass <> 3 Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "擬似品目以外の品目が選択されました。", "Top品目には擬似品目を選択して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                Exit Sub
            End If
            PRODUCT_CODE_T.Text = product_search_form.S_PRODUCT_CODE_T.Text
            PRODUCT_NAME_T.Text = product_search_form.S_PRODUCT_NAME_T.Text
            OPTION_NAME_T.Text = product_search_form.S_OPTION_NAME_T.Text
            UPDATE_STRUCTURE_SET()
            PRODUCT_CODE_T.ReadOnly = True
        End If
        product_search_form = Nothing
        TREEVIEW.Focus()
    End Sub

    Private Sub DELETE_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim ret As Boolean
        Dim Message_form As cMessageLib.fMessage


        If STRUCTURE_CODE_T.Text <> "" Then
            oTran = oConn.BeginTransaction()
            '構成マスタ削除
            ret = oMstBomDBIO.deleteBom(STRUCTURE_CODE_T.Text, oTran)
            If ret = False Then
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "構成マスタの削除処理が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing

                oTran.Rollback()
                Exit Sub
            End If

            oTran.Commit()

            'メッセージウィンドウ表示
            Message_form = New cMessageLib.fMessage(1, "削除が完了しました。", "新規モードに移行します。", Nothing, Nothing)
            Message_form.ShowDialog()
            Message_form.Dispose()
            Message_form = Nothing
        End If
        INIT_PROC()


    End Sub

    Private Sub COMMIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim ret As Boolean
        Dim pNode As System.Windows.Forms.TreeNode
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCount As Long
        Dim pNodeNo As Integer
        Dim pHiearchyNo As Integer
        Dim pParentNodeNo As Integer

        '必須入力確認
        ret = INPUT_CHECK()
        If ret = False Then
            Exit Sub
        End If

        '---トランザクション開始
        oTran = Nothing
        oTran = oConn.BeginTransaction

        If STRUCTURE_CODE_T.Text = "" Then
            STRUCTURE_CODE_T.Text = CREATE_STRUCTURE_CODE()
        Else
            oMstBomDBIO.deleteBom(CLng(STRUCTURE_CODE_T.Text), oTran)
        End If

        'ReDim pParentNodeNo(0)
        pNodeNo = 0
        pHiearchyNo = 0
        pParentNodeNo = 0

        For Each pNode In GetAllNodes(TREEVIEW.Nodes)

            'ノード番号インクリメント
            pNodeNo = pNodeNo + 1
            If (pHiearchyNo = 1) Or (pHiearchyNo <> GetHiearchyNo(pNode.FullPath) - 1) Then
                'ReDim Preserve pParentNodeNo(pHiearchyNo - 1)
                pParentNodeNo = GetHiearchyNo(pNode.FullPath) - 1
            End If
            pHiearchyNo = GetHiearchyNo(pNode.FullPath)

            '登録データのバッファセット
            WRITE_DATA_SET(pNode, pNodeNo, pHiearchyNo, pParentNodeNo)

            '構成マスタ登録
            RecordCount = oMstBomDBIO.insertBomMst(oBom, oTran)
            If RecordCount = False Then
                oTran.Rollback()
                'メッセージウィンドウ表示
                Message_form = New cMessageLib.fMessage(1, "登録が失敗しました。", "システム管理者に連絡して下さい。", Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form.Dispose()
                Message_form = Nothing
                Exit Sub
            End If
        Next


        '---トランザクション終了
        oTran.Commit()

        'メッセージウィンドウ表示
        Message_form = New cMessageLib.fMessage(1, "登録が完了しました。", "新規モードに移行します。", Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form.Dispose()
        Message_form = Nothing

        INIT_PROC()

    End Sub

    Private Sub QUIT_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUIT_B.Click
        oConn = Nothing
        oMstBomDBIO = Nothing
        oMstProductDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.Dispose()

    End Sub

    Private Sub TREEVIEW_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

        'ドラッグされているデータがTreeNodeか調べる
        If e.Data.GetDataPresent(GetType(System.Windows.Forms.TreeNode)) Then
            If (e.KeyState And 8) = 8 And _
                (e.AllowedEffect And System.Windows.Forms.DragDropEffects.Copy) = _
                    System.Windows.Forms.DragDropEffects.Copy Then
                'Ctrlキーが押されていればCopy
                '"8"はCtrlキーを表す
                e.Effect = System.Windows.Forms.DragDropEffects.Copy
            ElseIf (e.AllowedEffect And System.Windows.Forms.DragDropEffects.Move) = _
                System.Windows.Forms.DragDropEffects.Move Then
                '何も押されていなければMove
                e.Effect = System.Windows.Forms.DragDropEffects.Move
            Else
                e.Effect = System.Windows.Forms.DragDropEffects.None
            End If
        Else
            'TreeNodeでなければ受け入れない
            e.Effect = System.Windows.Forms.DragDropEffects.None
        End If

        'マウス下のNodeを選択する
        If e.Effect <> System.Windows.Forms.DragDropEffects.None Then
            Dim tv As System.Windows.Forms.TreeView = CType(sender, System.Windows.Forms.TreeView)
            'マウスのあるNodeを取得する
            Dim target As System.Windows.Forms.TreeNode = _
                tv.GetNodeAt(tv.PointToClient(New System.Drawing.Point(e.X, e.Y)))
            'ドラッグされているNodeを取得する
            Dim [source] As System.Windows.Forms.TreeNode = _
                CType(e.Data.GetData(GetType(System.Windows.Forms.TreeNode)), System.Windows.Forms.TreeNode)
            'マウス下のNodeがドロップ先として適切か調べる
            If Not target Is Nothing AndAlso _
                Not target Is [source] AndAlso _
                Not IsChildNode([source], target) Then
                'Nodeを選択する
                If target.IsSelected = False Then
                    tv.SelectedNode = target
                End If
            Else
                e.Effect = System.Windows.Forms.DragDropEffects.None
            End If
        End If

    End Sub
    'ドロップされたとき
    Private Sub TREEVIEW_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'ドロップされたデータがTreeNodeか調べる
        If e.Data.GetDataPresent(GetType(System.Windows.Forms.TreeNode)) Then
            Dim tv As System.Windows.Forms.TreeView = CType(sender, System.Windows.Forms.TreeView)
            'ドロップされたデータ(TreeNode)を取得
            Dim [source] As System.Windows.Forms.TreeNode = _
                CType(e.Data.GetData(GetType(System.Windows.Forms.TreeNode)), System.Windows.Forms.TreeNode)
            'ドロップ先のTreeNodeを取得する
            Dim target As System.Windows.Forms.TreeNode = _
                tv.GetNodeAt(tv.PointToClient(New System.Drawing.Point(e.X, e.Y)))
            'マウス下のNodeがドロップ先として適切か調べる
            If Not target Is Nothing AndAlso _
                Not target Is [source] AndAlso _
                Not IsChildNode([source], target) Then
                'ドロップされたNodeのコピーを作成
                Dim cln As System.Windows.Forms.TreeNode = CType([source].Clone(), System.Windows.Forms.TreeNode)
                'Nodeを追加
                target.Nodes.Add(cln)
                'ドロップ先のNodeを展開
                target.Expand()
                '追加されたNodeを選択
                tv.SelectedNode = cln
            Else
                e.Effect = System.Windows.Forms.DragDropEffects.None
            End If
        Else
            e.Effect = System.Windows.Forms.DragDropEffects.None
        End If
    End Sub


    ''' <summary>
    ''' あるTreeNodeが別のTreeNodeの子ノードか調べる
    ''' </summary>
    ''' <param name="parentNode">親ノードか調べるTreeNode</param>
    ''' <param name="childNode">子ノードか調べるTreeNode</param>
    ''' <returns>子ノードの時はTrue</returns>
    Private Shared Function IsChildNode( _
            ByVal parentNode As System.Windows.Forms.TreeNode, _
            ByVal childNode As System.Windows.Forms.TreeNode) As Boolean
        If childNode.Parent Is parentNode Then
            Return True
        ElseIf Not childNode.Parent Is Nothing Then
            Return IsChildNode(parentNode, childNode.Parent)
        Else
            Return False
        End If
    End Function


    'ノードがドラッグされた時
    Private Sub TREEVIEW_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs)
        Dim tv As System.Windows.Forms.TreeView = CType(sender, System.Windows.Forms.TreeView)
        tv.SelectedNode = CType(e.Item, System.Windows.Forms.TreeNode)
        tv.Focus()

        'ノードのドラッグを開始する
        Dim dde As System.Windows.Forms.DragDropEffects = _
            tv.DoDragDrop(e.Item, System.Windows.Forms.DragDropEffects.All)

        '移動した時は、ドラッグしたノードを削除する
        If (dde And System.Windows.Forms.DragDropEffects.Move) = System.Windows.Forms.DragDropEffects.Move Then
            tv.Nodes.Remove(CType(e.Item, System.Windows.Forms.TreeNode))
        End If

    End Sub

    Private Sub TREEVIEW_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TREEVIEW.MouseDoubleClick
        Dim product_search_form As cSelectLib.fProductSearch

        If IsNothing(oTran) = False Then
            oTran = Nothing
        End If
        product_search_form = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, Nothing, oTran)
        product_search_form.ShowDialog()
        If product_search_form.DialogResult = Windows.Forms.DialogResult.OK Then
            TREEVIEW.SelectedNode.Name = "AAA"
        End If
        product_search_form = Nothing

    End Sub


    Private Sub TreeMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TreeMenu.ItemClicked
        Dim Node As System.Windows.Forms.TreeNode
        Dim product_search_form As cSelectLib.fProductSearch
        Dim str As String
        'Dim path() As String
        Dim Message_form As cMessageLib.fMessage

        ' クリックされた項目の Name を判定します。 
        Select Case e.ClickedItem.Name
            Case "Add"
                '階層が２階層以上の場合エラー
                'path = GetHiearchyNoTREEVIEW.SelectedNode.FullPath.ToString.Split("\")
                If GetHiearchyNo(TREEVIEW.SelectedNode.FullPath) > 1 Then
                    'メッセージウィンドウ表示
                    Message_form = New cMessageLib.fMessage(1, "このノードの下には追加出来ません。", "親ノードを選択して下さい。", Nothing, Nothing)
                    Message_form.ShowDialog()
                    Message_form.Dispose()
                    Message_form = Nothing
                    TREEVIEW.SelectedNode = TREEVIEW.SelectedNode.Parent
                    TREEVIEW.Focus()
                    Exit Sub
                End If
                If IsNothing(oTran) = False Then
                    oTran = Nothing
                End If
                product_search_form = New cSelectLib.fProductSearch(oConn, oCommand, oDataReader, Nothing, oTran)
                product_search_form.ShowDialog()
                If product_search_form.DialogResult = Windows.Forms.DialogResult.OK Then
                    ReDim oProduct(0)
                    oMstProductDBIO.getProduct(oProduct, Nothing, product_search_form.S_PRODUCT_CODE_T.Text, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)
                    If oProduct(0).sProductClass = 3 Then
                        'メッセージウィンドウ表示
                        Message_form = New cMessageLib.fMessage(1, "擬似品目が選択されました。", "構成品目には擬似品目以外を選択して下さい。", Nothing, Nothing)
                        Message_form.ShowDialog()
                        Message_form.Dispose()
                        Message_form = Nothing
                        TREEVIEW.SelectedNode = TREEVIEW.SelectedNode.Parent
                        TREEVIEW.Focus()
                        Exit Sub
                    End If
                    'ノード追加
                    str = product_search_form.S_PRODUCT_CODE_T.Text & "::" & product_search_form.S_PRODUCT_NAME_T.Text
                    If product_search_form.S_OPTION_NAME_T.Text <> "" Then
                        str = str & product_search_form.S_OPTION_NAME_T.Text
                    End If
                    Dim treeNodeNew As New System.Windows.Forms.TreeNode(str)
                    TREEVIEW.SelectedNode.Nodes.Add(treeNodeNew)

                    '追加ノードの選択
                    For Each Node In TREEVIEW.SelectedNode.Nodes
                        If Node.Text = str Then
                            TREEVIEW.SelectedNode = Node
                            Exit For
                        End If
                    Next
                End If
                product_search_form = Nothing
                TREEVIEW.SelectedNode = TREEVIEW.SelectedNode.Parent
                TREEVIEW.Focus()
            Case "Delete"
                '追加ノードの選択
                TREEVIEW.SelectedNode.Remove()
                If IsNothing(TREEVIEW.SelectedNode) = False Then
                    If IsNothing(TREEVIEW.SelectedNode.Parent) = False Then
                        TREEVIEW.SelectedNode = TREEVIEW.SelectedNode.Parent
                    End If
                End If
                TREEVIEW.Focus()

        End Select
    End Sub

    Private Sub PRODUCT_CODE_T_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRODUCT_CODE_T.TextChanged
        Dim RecordCount As Integer

        RecordCount = oMstBomDBIO.getFullBom(oViewBom, Nothing, PRODUCT_CODE_T.Text, 0, Nothing, oTran)

    End Sub
End Class
