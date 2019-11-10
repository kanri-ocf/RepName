Public Class fServiceMst
    Private Const DISP_COW_MAX = 500
    '------------------------------------
    ' DB�A�N�Z�X�֘A
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oService() As cStructureLib.sService
    Private oMstServiceDBIO As cMstServiceDBIO

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

        oMstServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
        oMstConfigDBIO = New cMstConfigDBIO(oConn, oCommand, oDataReader)

    End Sub
    Private Sub fServiceMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        column1.HeaderText = "�R�[�h"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 70
        column1.Name = "�T�[�r�X�R�[�h"

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "�T�[�r�X����"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = True
        column2.Width = 180
        column2.Name = "�T�[�r�X����"

        Dim column3 As New DataGridViewTextBoxColumn
        column3.HeaderText = "�敪"
        DATA_V.Columns.Add(column3)
        column3.ReadOnly = True
        column3.Width = 80
        column3.Name = "�T�[�r�X�敪"

        Dim column4 As New DataGridViewCheckBoxColumn
        column4.HeaderText = "�ڋq"
        DATA_V.Columns.Add(column4)
        column4.ReadOnly = True
        column4.Width = 80
        column4.Name = "�ڋq"

        Dim column5 As New DataGridViewCheckBoxColumn
        column5.HeaderText = "�Ј�"
        DATA_V.Columns.Add(column5)
        column5.ReadOnly = True
        column5.Width = 80
        column5.Name = "�Ј�"

        Dim column6 As New DataGridViewCheckBoxColumn
        column6.HeaderText = "�A���o�C�g"
        DATA_V.Columns.Add(column6)
        column6.ReadOnly = True
        column6.Width = 80
        column6.Name = "�A���o�C�g"

        Dim column7 As New DataGridViewCheckBoxColumn
        column7.HeaderText = "�p�[�g"
        DATA_V.Columns.Add(column7)
        column7.ReadOnly = True
        column7.Width = 80
        column7.Name = "�p�[�g"

        Dim column8 As New DataGridViewCheckBoxColumn
        column8.HeaderText = "���̑�"
        DATA_V.Columns.Add(column8)
        column8.ReadOnly = True
        column8.Width = 80
        column8.Name = "���̑�"

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
        Dim str As String
        Dim RecordCnt As Long

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '�\���ݒ�
        If IsNothing(oService) = True Then
            RecordCnt = 0
        Else
            RecordCnt = oService.Length
        End If

        For i = 0 To RecordCnt - 1
            str = ""
            If oService(i).sServiceClass = 0 Then
                str = "�ڋq����"
            Else
                str = "�Г�����"
            End If

            DATA_V.Rows.Add( _
                        oService(i).sServiceCode, _
                        oService(i).sServiceName, _
                        str, _
                        oService(i).sTarget_C, _
                        oService(i).sTarget_E, _
                        oService(i).sTarget_A, _
                        oService(i).sTarget_P, _
                        oService(i).sTarget_O _
                )
        Next i
    End Sub

    Private Sub SEARCH_PROC()
        Dim pServiceCode As String
        Dim pServiceName As String
        Dim pServiceClass As Integer
        Dim pTarget_C As Boolean
        Dim pTarget_E As Boolean
        Dim pTarget_A As Boolean
        Dim pTarget_P As Boolean
        Dim pTarget_O As Boolean

        Dim Message_form As cMessageLib.fMessage
        Dim RecordCnt As Long

        '���b�Z�[�W�E�B���h�E�\��
        Message_form = New cMessageLib.fMessage(0, "�f�[�^�Ǎ��ݒ�", "���΂炭���҂���������", Nothing, Nothing)
        Message_form.Show()
        Application.DoEvents()

        '�T�[�r�X�}�X�^�ǂݍ��݃o�b�t�@������
        oService = Nothing
        pServiceCode = Nothing
        pServiceName = Nothing

        '�T�[�r�X�R�[�h
        If S_SERVICE_CODE_T.Text <> "" Then
            pServiceCode = S_SERVICE_CODE_T.Text
        End If

        '�T�[�r�X����
        If S_SERVICE_NAME_T.Text <> "" Then
            pServiceName = S_SERVICE_NAME_T.Text
        End If

        '�T�[�r�X�敪�i�ڋq�j
        If CLASS_OUT_C.Checked = True Then
            If CLASS_IN_C.Checked = True Then
                pServiceClass = Nothing
            Else
                pServiceClass = 0
            End If
        Else
            If CLASS_IN_C.Checked = True Then
                pServiceClass = 1
            Else
                pServiceClass = Nothing
            End If
        End If

        '�T�[�r�X�Ώہ[�ڋq
        If TARGET_C_C.Checked = True Then
            pTarget_C = True
        Else
            pTarget_C = Nothing
        End If

        '�T�[�r�X�Ώہ[�Ј�
        If TARGET_E_C.Checked = True Then
            pTarget_E = True
        Else
            pTarget_E = Nothing
        End If

        '�T�[�r�X�Ώہ[�A���o�C�g
        If TARGET_A_C.Checked = True Then
            pTarget_A = True
        Else
            pTarget_A = Nothing
        End If

        '�T�[�r�X�Ώہ[�p�[�g
        If TARGET_P_C.Checked = True Then
            pTarget_P = True
        Else
            pTarget_P = Nothing
        End If

        '�T�[�r�X�Ώہ[���̑�
        If TARGET_O_C.Checked = True Then
            pTarget_O = True
        Else
            pTarget_O = Nothing
        End If

        '�T�[�r�X�}�X�^�̓ǂݍ���
        RecordCnt = oMstServiceDBIO.getService( _
                        oService, _
                        pServiceCode, _
                        pServiceName, _
                        pServiceClass, _
                        pTarget_C, _
                        pTarget_E, _
                        pTarget_A, _
                        pTarget_P, _
                        pTarget_O, _
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
        End If

        '�������ʂ̉�ʃZ�b�g
        SEARCH_RESULT_SET()

        '���b�Z�[�W�E�B���h�E�̃N���A
        Message_form.Dispose()
        Message_form = Nothing

    End Sub

    Private Sub DATA_V_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DATA_V.CellClick
        Dim SelRow As Integer

        '�^�C�g���s�̉��̍s��1�s�ڂƂ��ĕԂ�
        SelRow = DATA_V.CurrentRow.Index

        If DATA_V(0, SelRow).Value.ToString() = Nothing Then
            Exit Sub
        End If

        Dim fServiceSub_form As New fServiceMstSub(oConn, oCommand, oDataReader, oConf, DATA_V("�T�[�r�X�R�[�h", SelRow).Value.ToString(), STAFF_CODE_T.Text, oTran)
        fServiceSub_form.ShowDialog()
        fServiceSub_form = Nothing

        '��������
        SEARCH_PROC()

        '�T�[�r�X�R�[�h�Ƀt�H�J�X�Z�b�g
        S_SERVICE_CODE_T.Focus()
    End Sub

    Private Sub SEARCH_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCH_B.Click
        '��������
        SEARCH_PROC()

    End Sub

    Private Sub NEW_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEW_B.Click

        Dim fServiceSub_form As New fServiceMstSub(oConn, oCommand, oDataReader, oConf, Nothing, STAFF_CODE_T.Text, oTran)
        fServiceSub_form.ShowDialog()
        fServiceSub_form = Nothing

        '��������
        SEARCH_PROC()
    End Sub

    Private Sub RETURN_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        oConn = Nothing
        oMstServiceDBIO = Nothing
        oMstConfigDBIO = Nothing
        oTool = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '�T�[�r�X�}�X�^�Ǘ��E�B���h�E�����
        Me.Close()

    End Sub
End Class
