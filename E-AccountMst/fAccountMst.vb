Public Class fAccountMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DB�A�N�Z�X�֘A
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oAccountFull() As cStructureLib.sViewAccountFull
    Private oMstAccountDBIO As cMstAccountDBIO

    Private oChannel() As cStructureLib.sChannel
    Private oMstChannelDBIO As cMstChannelDBIO

    Private oConf() As cStructureLib.sConfig
    Private oMstConfigDBIO As cMstConfigDBIO

    Private oTool As cTool

    Private oTran As System.Data.OleDb.OleDbTransaction

    '----------------------------------------------------------------------
    '�@�@�\�F�R���X�g���N�^
    '�@�����FJAN_CODE : �����L�[JAN�R�[�h
    '----------------------------------------------------------------------
    Sub New()
        Dim StrPath As String
        Dim DB_Path As String

        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        oTool = New cTool
        DB_Path = oTool.RegistryRead("File1")

        'ADO.NET�ɂ��'DB�ڑ�������̐ݒ�
        '���F�v���W�F�N�g�t�@�C���z���_�̉��ɂ���bin�z���_��MDB��u��

        StrPath = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_Path & "\OwP-DB.mdb;"
        oConn = New OleDb.OleDbConnection(StrPath)

        '�c�a�ڑ����J��
        oConn.Open()

        oMstAccountDBIO = New cMstAccountDBIO(oConn, oCommand, oDataReader)
        oMstChannelDBIO = New cMstChannelDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

    End Sub
    Private Sub fAccountMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecordCnt As Integer

        '----------------------- SoftGroup���C�Z���X�F�� ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        '���}�X�^�Ǎ���
        ReDim oConf(1)
        RecordCnt = oMstConfigDBIO.getConfMst(oConf, oTran)
        If RecordCnt < 1 Then
            '���b�Z�[�W�E�B���h�E�\��
            Dim Message_form As cMessageLib.fMessage

            Message_form = New cMessageLib.fMessage(1, "���}�X�^�̓Ǎ��݂Ɏ��s���܂���", _
                                            "�J�����ɂ��₢���킹������", _
                                            Nothing, Nothing)
            Message_form.ShowDialog()
            Application.DoEvents()
            Application.Exit()
        End If

        '�X�^�b�t���̓E�B���h�E�\��
        Dim staff_form As cStaffEntryLib.fStaffEntry

        staff_form = New cStaffEntryLib.fStaffEntry(oConn, oCommand, oDataReader, oTran)
        staff_form.ShowDialog()
        Application.DoEvents()
        If staff_form.DialogResult = Windows.Forms.DialogResult.OK Then
            '�S���҃Z�b�g
            STAFF_CODE_T.Text = staff_form.STAFF_CODE
            STAFF_NAME_T.Text = staff_form.STAFF_NAME
            staff_form = Nothing
        Else
            staff_form = Nothing
        End If


        '���ו\���G���A�^�C�g���s����
        GRIDVIEW_CREATE()

        '�`���l�����X�g�{�b�N�X�Z�b�g
        CHANNEL_SET()

        '�\������������
        INIT_PROC()

        '��������
        SEARCH_PROC()

    End Sub
    Private Sub INIT_PROC()

        SEARCH_PROC()
    End Sub

    ''******************************************************************
    ''�V�X�e���E�V���[�g�J�b�g�E�L�[�ɂ��_�C�A���O�̏I����j�~����
    ''******************************************************************
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Const WM_SYSCOMMAND As Integer = &H112
    '    Const SC_CLOSE As Integer = &HF060
    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_CLOSE) Then
    '        Return  ' Windows�W���̏����͍s��Ȃ�
    '    End If
    '    MyBase.WndProc(m)
    'End Sub
    '******************************************************************
    '�^�C�g���o�[�̂Ȃ��E�B���h�E��3D�̋��E������������
    '******************************************************************
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const WS_EX_DLGMODALFRAME As Integer = &H1
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_DLGMODALFRAME
            Return cp
        End Get
    End Property
    <System.Runtime.InteropServices.DllImport("USER32.DLL", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function HideCaret( _
           ByVal hwnd As IntPtr) As Integer
    End Function
    Private Sub CHANNEL_SET()
        Dim RecordCnt As Integer
        Dim i As Long

        '����ȖڃR���{���e�ݒ�
        ReDim oChannel(0)
        RecordCnt = oMstChannelDBIO.getChannelMst(oChannel, Nothing, 1, Nothing, Nothing, oTran)
        If RecordCnt < 1 Then
            '���b�Z�[�W�E�B���h�E�\��
            Dim Message_form As cMessageLib.fMessage
            If RecordCnt = 0 Then
                Message_form = New cMessageLib.fMessage(1, "����Ȗڃ}�X�^���o�^����Ă��܂���", _
                                                "����Ȗڃ}�X�^��o�^���Ă�������", _
                                                Nothing, Nothing)

            Else
                Message_form = New cMessageLib.fMessage(1, "����Ȗڃ}�X�^�̓Ǎ��݂Ɏ��s���܂���", _
                                                "�J�����ɂ��₢���킹������", _
                                                Nothing, Nothing)
            End If
            Message_form.ShowDialog()
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Application.Exit()
        End If

        '���X�g�{�b�N�X�ւ̒l�Z�b�g
        For i = 0 To RecordCnt - 1
            S_TAX_CLASS_L.Items.Add(oChannel(i).sChannelName)
        Next
        oDataReader = Nothing

    End Sub

    '******************************
    '     DataGridView�̐ݒ�
    '   �w�b�_�[����ї񕝐ݒ�
    '******************************

    Sub GRIDVIEW_CREATE()
        '���R�[�h�Z���N�^���\���ɐݒ�
        DATA_V.RowHeadersVisible = False
        DATA_V.ColumnHeadersHeight = 30
        DATA_V.RowTemplate.Height = 30

        '�O���b�h�̃w�b�_�[���쐬���܂��B
        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "����ȖڃR�[�h"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 110
        column1.Name = "����ȖڃR�[�h"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "����Ȗږ���"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 200
        column2.Name = "����Ȗږ���"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "�A�g�}�X�^"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 150
        column3.Name = "�A�g�}�X�^"

        Dim column4 As New DataGridViewTextBoxColumn
        column4.HeaderText = "�ŋ敪"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 120
        column4.Name = "�ŋ敪"

        '�w�i�F�𔒂ɐݒ�
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '��s�̔w�i�F�𔖉��F�ɐݒ�
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    '***********************************************
    '�������ʂ���ʂɃZ�b�g
    '***********************************************
    Sub SEARCH_RESULT_SET()
        Dim i As Integer

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '�\���ݒ�
        For i = 0 To oAccountFull.Length - 1
            DATA_V.Rows.Add( _
                        oAccountFull(i).sAccountCode, _
                        oAccountFull(i).sAccountName, _
                        oAccountFull(i).sLinkMasterName, _
                        oAccountFull(i).sTaxClassName _
                )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pAccountCode As String
        Dim pAccountName As String
        Dim pLinkMasterName As String
        Dim pTaxClassName As String
        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        '���b�Z�[�W�E�B���h�E�\��
        Message_form = New cMessageLib.fMessage(0, "�f�[�^�Ǎ��ݒ�", "���΂炭���҂���������", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '����Ȗڃ}�X�^�ǂݍ��݃o�b�t�@������
        oAccountFull = Nothing
        pAccountCode = Nothing
        pAccountName = Nothing
        pLinkMasterName = Nothing
        pTaxClassName = Nothing

        '����ȖڃR�[�h
        If S_ACCOUNT_CODE_T.Text <> "" Then
            pAccountCode = S_ACCOUNT_CODE_T.Text
        End If

        '����Ȗږ���
        If S_ACCOUNT_NAME_T.Text <> "" Then
            pAccountName = S_ACCOUNT_NAME_T.Text
        End If

        '�A�g�}�X�^����
        If S_LINK_MASTER_L.Text <> "" Then
            pLinkMasterName = S_LINK_MASTER_L.Text
        End If

        '�ŋ敪����
        If S_TAX_CLASS_L.Text <> "" Then
            pTaxClassName = S_TAX_CLASS_L.Text
        End If

        '����Ȗڃ}�X�^�̓ǂݍ���
        RecordCnt = oMstAccountDBIO.getAccountFull( _
                        oAccountFull, _
                        pAccountCode, _
                        pAccountName, _
                        pLinkMasterName, _
                        Nothing, _
                        pTaxClassName, _
                        oTran _
        )

        If RecordCnt > 0 Then
            '����MAX�l�̊m�F
            If RecordCnt > DISP_COW_MAX Then
                Message_form.Dispose()
                Message_form = Nothing
                Message_form = New cMessageLib.fMessage(1, "�f�[�^������500���𒴂��Ă��܂�", _
                                            "������ύX���čČ��􂵂ĉ�����", _
                                            Nothing, Nothing)
                Message_form.ShowDialog()
                Message_form = Nothing
                Exit Sub
            End If

            '�������ʂ̉�ʃZ�b�g
            SEARCH_RESULT_SET()
        End If

        '���b�Z�[�W�E�B���h�E�̃N���A
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub DATA_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        '�w�b�_�[���N���b�N���ꂽ�ꍇExit
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        '�^�C�g���s�̉��̍s��1�s�ڂƂ��ĕԂ�
        SelRow = DATA_V.CurrentRow.Index

        Dim fAccountSub_form As New fAccountMstSub(oConn, oCommand, oDataReader, oConf, DATA_V("����ȖڃR�[�h", SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fAccountSub_form.ShowDialog()
        fAccountSub_form = Nothing

        '��������
        SEARCH_PROC()

        '�����R�[�h�Ƀt�H�J�X�Z�b�g
        S_ACCOUNT_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '��������
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fAccountSub_form As New fAccountMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
        fAccountSub_form.ShowDialog()
        fAccountSub_form = Nothing

        '��������
        SEARCH_PROC()
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstAccountDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '����Ȗڃ}�X�^�Ǘ��E�B���h�E�����
        Me.Close()

    End Sub
End Class
