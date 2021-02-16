'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Module HARK_Public

    '*********************************************************************
    '�e�t�@�C���p�X
    '*********************************************************************
    Public gstrAppFilePath As String            '��exe�p�X
    Public gstrApplicationDataPath As String    '�J�����g���[�U�[ApplicationData�p�X
    Public gstrlogFilePath As String            '�e�탍�O�t�@�C���p�X
    Public gstrLogFileName As String            '���O�t�@�C���p�X
    Public gstrSettingFilePath As String        '�ʐݒ�t�@�C���p�X
    Public gstrExecuteLogFileName As String     '�������s���O�t�@�C���p�X

    '*********************************************************************
    '�e�ߒl
    '*********************************************************************
    Public gintMsg As Integer                   'Msgbox�ߒl
    Public gblRtn As Boolean                    'Bool�^�ߒl
    Public gintRtn As Integer                   'int�^�ߒl
    Public gstrDate As String                   '���t�^�ߒl
    Public gstrRtn As String                    '������^�ߒl
    Public gintSQLCODE As Integer               'Oracle�G���[�R�[�h
    Public gstrSQLERRM As String                'Oracle�G���[���b�Z�[�W
    Public gstr�Z�b�V�����[���� As String       '�Z�b�V�������(�[��)
    Public gint�Z�b�V����ID As Integer          '�Z�b�V�������(ID)

    '*********************************************************************
    '�\�����[�V�����ϐ�
    '*********************************************************************
    Public gintSPD�V�X�e���R�[�h As Integer     'SPD�V�X�e���R�[�h
    Public gstrFormID As String                 '�eFormID
    Public gstrFormTitle As String              '�eForm�^�C�g��
    Public gstr�S���Җ� As String               '�S���Җ�
    Public gstr���喼 As String                 '���喼
    Public gstr���Ӑ於 As String               '���Ӑ於

    '*********************************************************************
    '���R�[�h�J�E���g�ϐ�
    '*********************************************************************
    Public gint�捞�f�[�^Cnt As Integer         '�捞�f�[�^��
    Public gint�f����Cnt As Integer             '�擾�f����
    Public gintResultCnt As Integer             '�������ʌ���
    Public gint���v��Cnt As Integer             '�擾���v�搔
    Public gint���Ӑ�Cnt As Integer             '�擾���Ӑ搔
    Public gint���Ə�Cnt As Integer             '�擾���v�搔
    Public gint�T�u�v���O����Cnt As Integer     '�擾�T�u�v���O������
    Public gintPHsmos��Ë@��Cnt As Integer     '�擾PHsmos��Ë@�֐�
    Public gin�{��Cnt As Integer                '�擾�V�_��SPD�{�ݐ�
    Public gintErrorExportDataCnt As Integer    '�G���[�f�[�^�o�͌���
    Public gintErrorSendDataCnt As Integer      '�G���[�f�[�^���M����
    Public gintExcelDataCnt As Integer          '�Ǎ�EXCEL�f�[�^����
    Public gint���̎���Cnt As Integer           '���̎�������
    Public gint���ڎ���Cnt As Integer           '���ڎ�������

    '*********************************************************************
    '�v���O�������ϐ�
    '*********************************************************************
    Public gintDLTP0997S_FUNC004 As Integer     '�v���O�����ʏ��NUMBER�^�ߒl
    Public gstrDLTP0997S_FUNC005 As String      '�v���O�����ʏ��VARCHAR�^�ߒl
    Public gintKeyControl01 As Integer          '�L�[����t���O

End Module
