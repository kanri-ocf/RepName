Public Class fServiceMstSub
    Private Const DISP_ROW_MAX = 500
    '------------------------------------
    ' DB�A�N�Z�X�֘A
    '------------------------------------
    Private oConn As OleDb.OleDbConnection
    Private oCommand As OleDb.OleDbCommand
    Private oDataReader As OleDb.OleDbDataReader

    Private oService() As cStructureLib.sService
    Private oServiceRate() As cStructureLib.sServiceRate
    Private oServiceDBIO As cMstServiceDBIO

    Private oBumon() As cStructureLib.sBumon
    Private oBumonDBIO As cMstBumonDBIO

    Private oStaff() As cStructureLib.sStaff
    Private oStaffDBIO As cMstStaffDBIO

    Private oConf() As cStructureLib.sConfig

    Private oTool As cTool

    Private S_SERVICE_CODE As Integer
    Private STAFF_CODE As String

    Private EDIT_MODE As Boolean    '�V�K = False   �X�V = True

    Private IVENT_FLG As Boolean

    Private oTran As System.Data.OleDb.OleDbTransaction

    Sub New(ByRef iConn As OleDb.OleDbConnection, _
            ByRef iCommand As OleDb.OleDbCommand, _
            ByRef iDataReader As OleDb.OleDbDataReader, _
            ByRef iConf() As cStructureLib.sConfig, _
            ByVal iKeyServiceCode As String, _
            ByVal iStaffCode As String, _
            ByRef iTran As System.Data.OleDb.OleDbTransaction)

        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        oConn = iConn
        oCommand = iCommand
        oDataReader = iDataReader

        oConf = iConf

        oTran = iTran

        '�V�K�^�X�V�̃��[�h�ݒ�
        If iKeyServiceCode = Nothing Then
            EDIT_MODE = False
        Else
            EDIT_MODE = True
        End If

        S_SERVICE_CODE = iKeyServiceCode
        STAFF_CODE = iStaffCode
    End Sub

    Private Sub fProductSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '----------------------- SoftGroup���C�Z���X�F�� ----------------------
        Softgroup.NetButton.License.LicenseName = "Yooko Satoh"
        Softgroup.NetButton.License.LicenseUser = "yoko.satoh@ocf.co.jp"
        Softgroup.NetButton.License.LicenseKey = "DDADJEBQ3HL2AOBINJBDGZBFC"
        '----------------------------------------------------------------------

        oServiceDBIO = New cMstServiceDBIO(oConn, oCommand, oDataReader)
        oBumonDBIO = New cMstBumonDBIO(oConn, oCommand, oDataReader)
        oStaffDBIO = New cMstStaffDBIO(oConn, oCommand, oDataReader)

        oStaffDBIO.getStaff(oStaff, STAFF_CODE, Nothing, Nothing, Nothing, oTran)

        STAFF_CODE_T.Text = oStaff(0).sStaffCode
        STAFF_NAME_T.Text = oStaff(0).sStaffName

        oTool = New cTool

        IVENT_FLG = False

        '�O���b�h����
        GRIDVIEW_CREATE()

        '�\������������
        INIT_PROC()

        '�X�V�����̏ꍇ�A�ҏW�f�[�^�̓Ǎ��ݏ���
        If EDIT_MODE = True Then
            MODE_L.BackColor = System.Drawing.Color.Blue
            MODE_L.Text = "�i�X�V�j"
            DELETE_B.Enabled = True

            '�T�[�r�X���Z�b�g
            SERVICE_DISP()

        Else
            MODE_L.BackColor = System.Drawing.Color.Red
            MODE_L.Text = "�i�V�K�j"
        End If

        IVENT_FLG = True

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
        Dim Column0 As New DataGridViewTextBoxColumn
        Column0.HeaderText = "����R�[�h"
        DATA_V.Columns.Add(Column0)
        Column0.ReadOnly = True
        Column0.Width = 90
        Column0.Name = "����R�[�h"
        Column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim column1 As New DataGridViewTextBoxColumn
        column1.HeaderText = "���喼��"
        DATA_V.Columns.Add(column1)
        column1.ReadOnly = True
        column1.Width = 250
        column1.Name = "���喼��"
        column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Dim column2 As New DataGridViewTextBoxColumn
        column2.HeaderText = "������"
        DATA_V.Columns.Add(column2)
        column2.ReadOnly = False
        column2.Width = 100
        column2.Name = "������"
        column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '�w�i�F�𔒂ɐݒ�
        DATA_V.RowsDefaultCellStyle.BackColor = Color.White

        '��s�̔w�i�F�𔖉��F�ɐݒ�
        DATA_V.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon

    End Sub

    Private Sub SERVICE_DISP()

        ReDim oService(0)
        oServiceDBIO.getService(oService, S_SERVICE_CODE, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, oTran)

        SERVICE_CODE_T.Text = oService(0).sServiceCode
        SERVICE_CODE_T.ReadOnly = True

        SERVICE_NAME_T.Text = oService(0).sServiceName
        SERVICE_NAME_T.ReadOnly = True

        If oService(0).sServiceClass = 0 Then
            CLASS_OUT_R.Checked = True
        Else
            CLASS_IN_R.Checked = True
        End If

        TARGET_C_C.Checked = oService(0).sTarget_C
        TARGET_E_C.Checked = oService(0).sTarget_E
        TARGET_A_C.Checked = oService(0).sTarget_A
        TARGET_P_C.Checked = oService(0).sTarget_P
        TARGET_O_C.Checked = oService(0).sTarget_O

        RATE_DISP()
    End Sub

    Private Sub RATE_DISP()
        Dim RecordCnt As Integer
        Dim i As Integer
        Dim pServiceRate() As cStructureLib.sServiceRate

        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '����R���{���e�ݒ�
        ReDim oBumon(0)
        RecordCnt = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)

        For i = 0 To RecordCnt - 1
            ReDim pServiceRate(0)
            oServiceDBIO.getServiceRate(pServiceRate, S_SERVICE_CODE, oBumon(i).sBumonCode, oTran)

            DATA_V.Rows.Add( _
                oBumon(i).sBumonCode, _
                oBumon(i).sBumonName, _
                pServiceRate(0).sRate _
            )
        Next i

        pServiceRate = Nothing
    End Sub

    Private Sub INIT_PROC()
        Dim RecordCnt As Integer
        Dim i As Integer
        Dim pServiceRate() As cStructureLib.sServiceRate


        MODE_L.BackColor = System.Drawing.Color.Red
        MODE_L.Text = "�V�K"
        DELETE_B.Enabled = False

        SERVICE_CODE_T.Text = oServiceDBIO.getNewServiceCode(oTran)
        SERVICE_CODE_T.ReadOnly = False
        SERVICE_CODE_T.BackColor = Color.LightGreen
        DELETE_B.Enabled = False

        '�������O���b�h������
        For i = 0 To DATA_V.Rows.Count
            DATA_V.Rows.Clear()
        Next i

        '����R���{���e�ݒ�
        ReDim oBumon(0)
        RecordCnt = oBumonDBIO.getBumonMst(oBumon, Nothing, Nothing, Nothing, True, Nothing, Nothing, oTran)

        For i = 0 To RecordCnt - 1
            DATA_V.Rows.Add( _
                oBumon(i).sBumonCode, _
                oBumon(i).sBumonName, _
                0 _
            )
        Next i

        pServiceRate = Nothing
    End Sub
    '******************************************************************
    '�^�C�g���o�[�̂Ȃ��E�B���h�E��3D�̋��E������������
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

    '******************************
    '     DataGridView�̐ݒ�
    '   �w�b�_�[����ї񕝐ݒ�
    '******************************

    Private Sub CLOSE_PROC()
        oConn = Nothing
        oServiceDBIO = Nothing
        oBumonDBIO = Nothing
        oStaffDBIO = Nothing
        oTool = Nothing
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub DELETE_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '�����}�X�^�̍폜
        ret = oServiceDBIO.deleteService(SERVICE_CODE_T.Text, oTran)


        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                    "�폜���������܂����B", _
                    Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()

        CLOSE_PROC()

    End Sub
    Private Function INPUT_CHECK() As Boolean
        Dim Message_form As cMessageLib.fMessage

        INPUT_CHECK = True

        If SERVICE_NAME_T.Text = "" Then
            Message_form = New cMessageLib.fMessage(1, "�������̂������͂ł��B", _
                                             "�������̂���͂��ĉ������B", _
                                             Nothing, Nothing)

            Message_form.ShowDialog()
            Application.DoEvents()
            Message_form = Nothing
            SERVICE_NAME_T.Focus()
            INPUT_CHECK = False
            Exit Function
        End If

    End Function
    Private Sub COMMIT_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMMIT_B.Click
        Dim Message_form As cMessageLib.fMessage
        Dim ret As Boolean

        '�K�{���͊m�F
        If INPUT_CHECK() = False Then
            Exit Sub
        End If

        oTran = Nothing
        oTran = oConn.BeginTransaction

        '�T�[�r�X�}�X�^�̓o�^
        ReDim oService(0)
        oService(0).sServiceCode = CInt(SERVICE_CODE_T.Text)
        oService(0).sServiceName = SERVICE_NAME_T.Text
        If CLASS_OUT_R.Checked = True Then
            oService(0).sServiceClass = 0
        Else
            oService(0).sServiceClass = 1
        End If
        oService(0).sTarget_C = TARGET_C_C.Checked
        oService(0).sTarget_E = TARGET_E_C.Checked
        oService(0).sTarget_A = TARGET_A_C.Checked
        oService(0).sTarget_P = TARGET_P_C.Checked
        oService(0).sTarget_O = TARGET_O_C.Checked

        If EDIT_MODE = False Then
            ret = oServiceDBIO.insertService(oService(0), oTran)
        Else
            ret = oServiceDBIO.updateService(oService(0), oTran)
        End If

        '�T�[�r�X�ڍ׃}�X�^�̓o�^

        oServiceDBIO.deleteServiceRate(CInt(SERVICE_CODE_T.Text), Nothing, oTran)

        For i = 0 To DATA_V.Rows.Count - 1
            ReDim oServiceRate(0)
            oServiceRate(0).sServiceCode = CInt(SERVICE_CODE_T.Text)
            oServiceRate(0).sBumonCode = CInt(DATA_V("����R�[�h", i).Value)
            oServiceRate(0).sRate = CInt(DATA_V("������", i).Value)
            oServiceDBIO.insertServiceRate(oServiceRate(0), oTran)
        Next i

        oTran.Commit()

        Message_form = New cMessageLib.fMessage(1, Nothing, _
                        "�o�^���������܂����B", _
                        Nothing, Nothing)
        Message_form.ShowDialog()
        Message_form = Nothing

        Application.DoEvents()
        Message_form = Nothing
        CLOSE_PROC()

    End Sub

    Private Sub RETURN_B_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURN_B.Click
        Dim Message_form As cMessageLib.fMessage

        Message_form = New cMessageLib.fMessage(2, "�ύX�͔j������܂��B", _
                                                    "��낵���ł����H", _
                                                    Nothing, Nothing)
        Message_form.ShowDialog()
        If Message_form.DialogResult = Windows.Forms.DialogResult.No Then
            Message_form = Nothing
            Exit Sub
        End If

        Message_form = Nothing
        Application.DoEvents()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        CLOSE_PROC()

    End Sub
End Class
