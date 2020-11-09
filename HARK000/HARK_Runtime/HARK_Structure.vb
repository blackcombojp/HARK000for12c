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
Module HARK_Structure

    '���̎����ꗗ
    Public Structure ���̎����ꗗ

        Public str�R�[�h As String     '�R�[�h
        Public str���� As String       '����

        Public Overrides Function ToString() As String
            Return str����
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As String)
            str���� = NvlString(Name, CStr(IIf(CD = "0", "", CD)))
            str�R�[�h = CD
        End Sub

    End Structure


    '���ڎ����ꗗ
    Public Structure ���ڎ����ꗗ

        Public int�R�[�h As Integer    '�R�[�h
        Public str���� As String       '����

        Public Overrides Function ToString() As String
            Return str����
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            str���� = Name
            int�R�[�h = CD
        End Sub

    End Structure


    '�T�u�v���O�����ꗗ
    Public Structure �T�u�v���O�����ꗗ

        Public int�T�u�v���O�����R�[�h As Integer   '�T�u�v���O�����R�[�h
        Public str�T�u�v���O������ As String        '�T�u�v���O������

        Public Overrides Function ToString() As String
            Return str�T�u�v���O������
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            str�T�u�v���O������ = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            int�T�u�v���O�����R�[�h = CD
        End Sub

    End Structure


    '���Ӑ�ꗗ
    Public Structure ���Ӑ�ꗗ

        Public lng���Ӑ�R�[�h As Long      '���Ӑ�R�[�h
        Public str���Ӑ於 As String        '���Ӑ於

        Public Overrides Function ToString() As String
            Return str���Ӑ於
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Long)
            str���Ӑ於 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            lng���Ӑ�R�[�h = CD
        End Sub

    End Structure


    '���v��ꗗ
    Public Structure ���v��ꗗ

        Public lng���v��R�[�h As Long      '���v��R�[�h
        Public str���v�於 As String        '���v�於

        Public Overrides Function ToString() As String
            Return str���v�於
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Long)
            str���v�於 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            lng���v��R�[�h = CD
        End Sub

    End Structure


    '���Ə��ꗗ
    Public Structure ���Ə��ꗗ

        Public int���Ə��R�[�h As Integer   '���Ə��R�[�h
        Public str���Ə��� As String        '���Ə���

        Public Overrides Function ToString() As String
            Return str���Ə���
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            str���Ə��� = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            int���Ə��R�[�h = CD
        End Sub

    End Structure


    '�f���ꗗ
    Public Structure �f���ꗗ

        Public str�f����� As String        '�f�����

        Public Overrides Function ToString() As String
            Return str�f�����
        End Function

        Public Sub New(ByVal Name As String)
            str�f����� = Name
        End Sub

    End Structure


    '�捞�f�[�^
    Public Structure �捞�f�[�^�ꗗ

        Public intRec_ID As Integer    '�捞�f�[�^_ID
        Public strRecData As String    '�捞�f�[�^

        Public Overrides Function ToString() As String
            Return strRecData
        End Function

        Public Sub New(ByVal Data As String, ByVal ID As Integer)
            strRecData = Data
            intRec_ID = ID
        End Sub

    End Structure


    'PHsmos��Ë@�ֈꗗ
    Public Structure PHsmos��Ë@�ֈꗗ

        Public str��Ë@�փR�[�h As String    '��Ë@�փR�[�h
        Public str��Ë@�֖� As String        '��Ë@�֖�

        Public Overrides Function ToString() As String
            Return str��Ë@�֖�
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As String)
            str��Ë@�֖� = NvlString(Name, CStr(IIf(CD = "", "", CD)))
            str��Ë@�փR�[�h = CD
        End Sub

    End Structure


    '�����[�����
    Public Structure Struc_�����[�����
        Dim str�o�͐�P As String
        Dim str�o�͐�Q As String
        Dim str�o�͐�R As String
        Dim str�o�͐�S As String
        Dim str�o�͐�T As String
        Public Sub IsClear()

            str�o�͐�P = vbNullString
            str�o�͐�Q = vbNullString
            str�o�͐�R = vbNullString
            str�o�͐�S = vbNullString
            str�o�͐�T = vbNullString

        End Sub
    End Structure


    '�����ݏo�ԍ����
    Public Structure Struc_�����ݏo�ԍ����
        Dim lng�����ݏo�ԍ� As Long
        Dim str�o�ד� As String
        Dim str�󒍌`�� As String
        Dim str���v�於 As String
        Dim str���v�敔���� As String
        Dim str���i�R�[�h As String
        Dim str���[�J�� As String
        Dim str���[�J�i�� As String
        Dim str���i�� As String
        Dim str�K�i As String
        Dim str�L������ As String
        Dim str���b�g As String
        Dim str�V���A�� As String
        Dim lng�o�א��� As Long
        Dim str�o�גP�ʖ� As String
        Dim str����� As String
        Dim str������v�於 As String
        Dim str������v�敔���� As String
        Dim str�ԋp�� As String
        Public Sub IsClear()

            lng�����ݏo�ԍ� = DUMMY_LNGCODE
            str�o�ד� = vbNullString
            str�󒍌`�� = vbNullString
            str���v�於 = vbNullString
            str���v�敔���� = vbNullString
            str���i�R�[�h = vbNullString
            str���[�J�� = vbNullString
            str���[�J�i�� = vbNullString
            str���i�� = vbNullString
            str�K�i = vbNullString
            str�L������ = vbNullString
            str���b�g = vbNullString
            str�V���A�� = vbNullString
            lng�o�א��� = DUMMY_LNGCODE
            str�o�גP�ʖ� = vbNullString
            str����� = vbNullString
            str������v�於 = vbNullString
            str������v�敔���� = vbNullString
            str�ԋp�� = vbNullString

        End Sub
    End Structure


    '���ʕ\���p���Ӑ�ꗗ
    Public Structure Struc_���ʕ\���p���Ӑ�ꗗ
        Public strRecData As String    '���Ӑ�ꗗ
    End Structure


    '�������ʈꗗ
    Public Structure Result
        Public strBuff() As String
    End Structure


    Public �T�u�v���O����Array() As �T�u�v���O�����ꗗ
    Public ���v��Array() As ���v��ꗗ
    Public ���Ӑ�Array() As ���Ӑ�ꗗ
    Public �捞�f�[�^Array() As �捞�f�[�^�ꗗ
    Public ���Ə�Array() As ���Ə��ꗗ
    Public �f����Array() As �f���ꗗ
    Public PHsmos��Ë@��Array() As PHsmos��Ë@�ֈꗗ
    Public ���̎���Array() As ���̎����ꗗ
    Public ���ڎ���Array() As ���ڎ����ꗗ

    Public Results() As Result
    Public ���ʕ\���p���Ӑ�ꗗArray() As Struc_���ʕ\���p���Ӑ�ꗗ

    Public gudt�����[����� As Struc_�����[�����
    Public gudt�����ݏo�ԍ���� As Struc_�����ݏo�ԍ����

End Module
