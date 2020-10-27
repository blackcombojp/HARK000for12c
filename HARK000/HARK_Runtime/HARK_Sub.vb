'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On


Imports HARK000.HARK_Common
Imports HARK000.HARK_DBCommon
Imports System.Threading
Public Class HARK_Sub

    Private Shared _mutex As Mutex
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    ''' <summary>
    ''' ���C����ʋN���O����
    ''' </summary>
    Public Shared Sub Main()

        'ThreadException�C�x���g�n���h����ǉ�
        AddHandler Application.ThreadException, AddressOf Application_ThreadException
        'ThreadException���������Ȃ��悤�ɂ���
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException)
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

        Dim hasHandle As Boolean = False
        Dim intCnt As Integer = 0

        Try

            log4net.NDC.Push(My.Application.Info.Version.ToString)

            _mutex = New Mutex(False, My.Application.Info.ProductName)

            '��exe�p�X�擾
            gstrAppFilePath = Get_AppPath()

            '�J�����g���[�U�[ApplicationData�p�X�擾
            gstrApplicationDataPath = Set_FilePath(Get_ApplicationPath(), "HARK")

            '���O�t�@�C���p�X�擾
            gstrlogFilePath = Set_FilePath(gstrApplicationDataPath, "log")

            '�ʐݒ�t�@�C���p�X�擾
            gstrSettingFilePath = Set_FilePath(gstrAppFilePath, "Setting")
            If Chk_DirExists(gstrSettingFilePath) = False Then
                gblRtn = Create_Dir(gstrSettingFilePath)
            End If

            '�e�t�@�C���p�X�ݒ�
            gstrLogFileName = Set_FilePath(gstrlogFilePath, "HARK000Err.Log")
            gstrExecuteLogFileName = Set_FilePath(gstrlogFilePath, "HARK000Execute.Log")

            Try
                '�~���[�e�b�N�X�̏��L����v������
                hasHandle = _mutex.WaitOne(0, False)

            Catch ex As AbandonedMutexException
                hasHandle = True
            End Try

            If hasHandle = False Then
                log.Error(Set_ErrMSG(0, MSG_COM005))
                MsgBox(MSG_COM005, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Return
            End If

            'Oracle�ڑ�
            If OraConnect() = False Then
                log.Error(Set_ErrMSG(0, MSG_COM004))
                MsgBox(MSG_COM004 & vbCr & MSG_COM019, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Throw New Exception(MSG_COM004)
            End If

            '���喼�擾
            If My.Settings.���Ə��R�[�h = 0 Then
                gstr���喼 = "�V�X�e���Ǘ�"
            Else
                If DLTP0900_PROC0002("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                    Throw New Exception
                End If
            End If

            '�S���Җ��擾
            If My.Settings.���͒S���R�[�h = 0 Then
                gstr�S���Җ� = "�V�X�e���Ǘ�"
            Else
                If DLTP0900_PROC0001("Sub_Main", My.Settings.���͒S���R�[�h, vbNullString, gintSQLCODE, gstrSQLERRM) = False Then
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                    Throw New Exception
                End If
            End If

            '���Ə��ꗗ�擾
            If DLTP0901_PROC0001("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            '�f���ňꗗ�擾
            If DLTP0000_PROC0011("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            '���O�C�����X�V
            If DLTP0000_PROC0006(gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(MSG_COM910 & vbCr & MSG_COM901 & vbCr & gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            '�ϐ��ݒ�
            'PrintScreen������(0�E�E�����A1�E�E�L��)
            gintKeyControl01 = 0

            '�A�v���N��
            Application.Run(New HARK001)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

            Application.Exit()

        Finally

            If hasHandle Then
                _mutex.ReleaseMutex()
            End If

            _mutex.Close()

        End Try

    End Sub
    ''' <summary>
    ''' �w��t�H�[��ID�̃L���v�V������ݒ�
    ''' </summary>
    ''' <param name="ProgramID">�e�N���X��</param>
    ''' <param name="FormID">�e�t�H�[����</param>
    ''' <returns>�t�H�[���^�C�g��</returns>
    Public Shared Function Set_FormTitle(ByVal ProgramID As String,
                                         ByVal FormID As String) As String

        Try
            '�p�X�Ƀt�@�C������ǉ�
            Set_FormTitle = ProgramID & " " & FormID & " �y" & My.Application.Info.CompanyName & "�z"

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' �G���[���b�Z�[�W���`
    ''' </summary>
    ''' <param name="strErrCode">�G���[�R�[�h</param>
    ''' <param name="strErrMessage">�G���[���b�Z�[�W</param>
    ''' <returns>���`��G���[���b�Z�[�W</returns>
    Public Shared Function Set_ErrMSG(ByVal strErrCode As Integer, ByVal strErrMessage As String) As String

        Dim strBuff As String

        strBuff = CType(strErrCode, String) & " " & strErrMessage

        Set_ErrMSG = strBuff

    End Function
    ''' <summary>
    ''' ��������ʕ\��
    ''' </summary>
    Public Shared Sub NowLording()

        Dim Fmlording As New HARK990

        Try

            Fmlording.ShowDialog()

        Catch ex As ThreadAbortException

            Fmlording.Close()

        Finally

            Fmlording.Dispose()

        End Try

    End Sub
    ''' <summary>
    ''' CurrentDomain_UnhandledException
    ''' </summary>
    ''' <param name="sender">�I�u�W�F�N�g���ʃN���X</param>
    ''' <param name="e">�C�x���g�f�[�^�N���X</param>
    Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)

        Dim ErrMsg As String

        Try
            ErrMsg = CStr(DirectCast(e.ExceptionObject, Exception).HResult) & "-" & DirectCast(e.ExceptionObject, Exception).Message

            log.Error(Set_ErrMSG(999, ErrMsg))
            MsgBox(MSG_COM902 & vbCr & DirectCast(e.ExceptionObject, Exception).HResult & vbCr & DirectCast(e.ExceptionObject, Exception).Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        Finally
            '�A�v���P�[�V�������I������
            Environment.Exit(1)
        End Try

    End Sub
    ''' <summary>
    ''' Application_ThreadException
    ''' </summary>
    ''' <param name="sender">�I�u�W�F�N�g���ʃN���X</param>
    ''' <param name="e">�C�x���g�f�[�^�N���X</param>
    Private Shared Sub Application_ThreadException(sender As Object, e As ThreadExceptionEventArgs)

        Dim ErrMsg As String

        Try
            ErrMsg = CStr(e.Exception.HResult) & "-" & e.Exception.Message

            log.Error(Set_ErrMSG(999, ErrMsg))
            MsgBox(MSG_COM902 & vbCr & e.Exception.HResult & vbCr & e.Exception.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        Finally
            '�A�v���P�[�V�������I������
            Application.Exit()
        End Try

    End Sub

End Class
