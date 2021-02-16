'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Imports Oracle.DataAccess.Client
Imports HARK000.HARK_Common
Imports HARK000.HARK_Sub

Public Class HARK_DBCommon

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Shared Oracomm As New OracleConnection
    Public Shared Oracmd As New OracleCommand
    Public Shared OraDr As OracleDataReader
    Public Shared OraTran As OracleTransaction
    ''' <summary>
    ''' Oracle�ڑ�����
    ''' </summary>
    ''' <returns>True�E�E�����Afalse�E�E���s</returns>
    Public Shared Function OraConnect() As Boolean

        Dim StrParam As String

        Try

            OraConnect = False

            'StrParam = "User id=" & My.Settings.DB���[�U & ";" & "Password=" & My.Settings.DB�p�X���[�h & ";" & "Data Source=" & My.Settings.DB�ڑ�������
            StrParam = "User id=" & My.Settings.DB���[�U & ";" & "Password=" & My.Settings.DB�p�X���[�h & ";" & "Data Source=" & My.Settings.DB�ڑ������� & ";" & "Connection Timeout=5;Pooling=false;"

            Oracomm.ConnectionString = StrParam

            Oracomm.Open()

            OraConnect = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' Oracle�ؒf����
    ''' </summary>
    ''' <returns>True�E�E�����Afalse�E�E���s</returns>
    Public Shared Function OraDisConnect() As Boolean

        Try

            Oracomm.Close()

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()
            Oracomm.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �g�����U�N�V�����R�~�b�g
    ''' </summary>
    ''' <returns>True�E�E����Afalse�E�E�ُ�</returns>
    Public Shared Function OraTrnCommit() As Boolean

        Try

            OraTrnCommit = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0091"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            OraTrnCommit = True

            Exit Function

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �g�����U�N�V�������[���o�b�N
    ''' </summary>
    ''' <returns>True�E�E����Afalse�E�E�ُ�</returns>
    Public Shared Function OraTrnRollBack() As Boolean

        Try

            OraTrnRollBack = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0090"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            OraTrnRollBack = True

            Exit Function

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' Oracle�ڑ���Ԋm�F
    ''' </summary>
    ''' <param name="PO_intOraSessionID">�Z�b�V����ID�i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True�E�E�ڑ����Afalse�E�E�ؒf</returns>
    Public Shared Function OraConnectState(ByRef PO_intOraSessionID As Integer,
                                           ByRef PO_intSQLCODE As Integer,
                                           ByRef PO_strSQLERRM As String) As Boolean

        Try

            Dim PO_01 As OracleParameter
            Dim PO_02 As OracleParameter
            Dim PO_03 As OracleParameter
            Dim PO_04 As OracleParameter

            OraConnectState = False
            PO_intOraSessionID = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_03.Value.ToString)
            PO_strSQLERRM = PO_04.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                PO_intOraSessionID = CInt(PO_02.Value.ToString)
                OraConnectState = True

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            End If

            Exit Function

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �S���Җ��擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PI_lng���͒S���R�[�h">���͒S���R�[�h</param>
    ''' <param name="PI_obj���Ə��R�[�h">���Ə��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0900_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng���͒S���R�[�h As Long,
                                             ByVal PI_obj���Ə��R�[�h As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0001 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_lng���͒S���R�[�h
            PI_02.Value = PI_obj���Ə��R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 30, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr�S���Җ� = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                gstr�S���Җ� = PO_01.Value.ToString

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0900_PROC0001 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���喼�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0900_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0002 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr���喼 = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                gstr���喼 = PO_01.Value.ToString

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0900_PROC0002 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ於�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PI_obj���Ə��R�[�h">���Ə��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0900_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByVal PI_obj���Ə��R�[�h As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0003 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_obj���Ə��R�[�h
            PI_02.Value = PI_lng���Ӑ�R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr���Ӑ於 = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                gstr���Ӑ於 = PO_01.Value.ToString

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0900_PROC0003 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ於�擾(�������Ə��`�F�b�N����)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0900_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0004 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_lng���Ӑ�R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr���Ӑ於 = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                gstr���Ӑ於 = PO_01.Value.ToString

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0900_PROC0004 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ə��ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0901_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0001 = False

            gint���Ə�Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ���Ə�Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve ���Ə�Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    ���Ə�Array(i).int���Ə��R�[�h = OraDr.GetInt32(0)
                    ���Ə�Array(i).str���Ə��� = OraDr.GetString(1)
                    i += 1

                End While

                gint���Ə�Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0901_PROC0001 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' SPD�V�X�e���R�[�h�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0000_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter


        Try
            DLTP0000_PROC0002 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_strProgram_ID

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 100, DBNull.Value, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_04.Value.ToString)
            PO_strSQLERRM = PO_05.Value.ToString

            gintSPD�V�X�e���R�[�h = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                gintSPD�V�X�e���R�[�h = CInt(PO_01.Value.ToString)
                gstrFormID = PO_02.Value.ToString
                gstrFormTitle = PO_03.Value.ToString

                DLTP0000_PROC0002 = True

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �v���O���������ۊm�F
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0�E�E�s�A1�E�E��</returns>
    Public Shared Function DLTP0000_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0000_PROC0003 = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()
            PI_04.Value = My.Application.Info.Version

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                DLTP0000_PROC0003 = CInt(PO_01.Value.ToString)

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����[�����擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0000_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0000_PROC0005 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gudt�����[�����.IsClear()

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraDr.Read()

                If OraDr.IsDBNull(0) = False Then gudt�����[�����.str�o�͐�P = OraDr.GetString(0)
                If OraDr.IsDBNull(1) = False Then gudt�����[�����.str�o�͐�Q = OraDr.GetString(1)
                If OraDr.IsDBNull(2) = False Then gudt�����[�����.str�o�͐�R = OraDr.GetString(2)
                If OraDr.IsDBNull(3) = False Then gudt�����[�����.str�o�͐�S = OraDr.GetString(3)
                If OraDr.IsDBNull(4) = False Then gudt�����[�����.str�o�͐�T = OraDr.GetString(4)

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0000_PROC0005 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �f���ňꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0000_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0000_PROC0011 = False

            gint�f����Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0011"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            �f����Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve �f����Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    �f����Array(i).str�f����� = OraDr.GetString(0)
                    i += 1

                End While

                gint�f����Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0000_PROC0011 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' DLT�v���O�����ʏ��VARCHAR�^���擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�Ǘ��敪">�Ǘ��敪</param>
    ''' <param name="PI_int�����敪">�����敪</param>
    ''' <param name="PI_strImputName">���ږ�</param>
    ''' <returns>0 -- �f�[�^���� 2 -- �f�[�^�Ȃ�</returns>
    Public Shared Function DLTP0997S_FUNC005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�Ǘ��敪 As Integer,
                                             ByVal PI_int�����敪 As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC005"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�A�E�g�v�b�g�p�����[�^�ݒ�(FUNCTION�͈�ԍŏ��Ƀp�����[�^�ݒ�)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.ReturnValue)

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int�Ǘ��敪
            PI_05.Value = PI_int�����敪
            PI_06.Value = PI_strImputName.Trim

            '�X�g�A�h�v���V�[�W��call
            Oracmd.ExecuteNonQuery()

            gstrDLTP0997S_FUNC005 = vbNullString
            gstrDLTP0997S_FUNC005 = PO_01.Value.ToString.Trim

            If IsNull(gstrDLTP0997S_FUNC005) = True Then
                DLTP0997S_FUNC005 = 2
            Else
                DLTP0997S_FUNC005 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' DLT�v���O�����ʏ��NUMBER�^���擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�Ǘ��敪">�Ǘ��敪</param>
    ''' <param name="PI_int�����敪">�����敪</param>
    ''' <param name="PI_strImputName">���ږ�</param>
    ''' <returns>0 -- �f�[�^���� 2 -- �f�[�^�Ȃ�</returns>
    Public Shared Function DLTP0997S_FUNC004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�Ǘ��敪 As Integer,
                                             ByVal PI_int�����敪 As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC004"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�A�E�g�v�b�g�p�����[�^�ݒ�(FUNCTION�͈�ԍŏ��Ƀp�����[�^�ݒ�)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int�Ǘ��敪
            PI_05.Value = PI_int�����敪
            PI_06.Value = PI_strImputName.Trim

            '�X�g�A�h�v���V�[�W��call
            Oracmd.ExecuteNonQuery()

            gintDLTP0997S_FUNC004 = 0
            gintDLTP0997S_FUNC004 = CInt(PO_01.Value.ToString.Trim)

            If gintDLTP0997S_FUNC004 = 0 Then
                DLTP0997S_FUNC004 = 2
            Else
                DLTP0997S_FUNC004 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �v���O�����ʏ��(���Ӑ�)�ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�Ǘ��敪">�Ǘ��敪</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0997S_PROC0001(ByVal PI_strProgram_ID As String,
                                              ByVal PI_intSPDSystemcode As Integer,
                                              ByVal PI_intSubProgram_ID As Integer,
                                              ByVal PI_int�Ǘ��敪 As Integer,
                                              ByRef PO_intSQLCODE As Integer,
                                              ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0997S_PROC0001 = False

            gint���v��Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure


            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int�Ǘ��敪

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ���v��Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve ���v��Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    If OraDr.IsDBNull(0) = False Then ���v��Array(i).lng���v��R�[�h = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then ���v��Array(i).str���v�於 = OraDr.GetString(1)

                    i += 1

                End While

                gint���v��Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0997S_PROC0001 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �T�u�v���O�����ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0901_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0002 = False

            gint�T�u�v���O����Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure


            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            �T�u�v���O����Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve �T�u�v���O����Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    �T�u�v���O����Array(i).int�T�u�v���O�����R�[�h = OraDr.GetInt32(0)
                    �T�u�v���O����Array(i).str�T�u�v���O������ = OraDr.GetString(1)

                    i += 1

                End While

                gint�T�u�v���O����Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0901_PROC0002 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍃e�L�X�g�捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0101_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0101_PROC0001 = 8
                Else
                    DLTP0101_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' Aptage�p�ėp�󒍃f�[�^�쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng�쐬�S���҃R�[�h">�쐬�S���҃R�[�h</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_���Ӑ���">���Ӑ���i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng�쐬�S���҃R�[�h As Long,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_���Ӑ��� As String,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try
            DLTP0101_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 80, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng�쐬�S���҃R�[�h
            PI_03.Value = PI_int�捞�ԍ�
            PI_04.Value = PI_intSubProgram_ID

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_���Ӑ��� = PO_01.Value.ToString
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0101_PROC0002 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �G���[�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0101_PROC0011 = 9
            gintErrorExportDataCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintErrorExportDataCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintErrorExportDataCnt = 0 Then
                DLTP0101_PROC0011 = 2
            Else
                DLTP0101_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �G���[�f�[�^�o�͌��ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As Integer
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0101_PROC0012 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorExportDataCnt = 0 Then
                DLTP0101_PROC0012 = 0
                Exit Function
            End If

            ReDim ID(gintErrorExportDataCnt - 1)

            For i = 0 To gintErrorExportDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorExportDataCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = gintErrorExportDataCnt
            PI_03.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0101_PROC0012 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���M�p�G���[�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0101_PROC0021 = 9
            gintErrorSendDataCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int�捞�ԍ�

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintErrorSendDataCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintErrorSendDataCnt = 0 Then
                DLTP0101_PROC0021 = 2
            Else
                DLTP0101_PROC0021 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���M�p�G���[�f�[�^�o�͌��ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0101_PROC0022(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As Integer
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0101_PROC0022 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorSendDataCnt = 0 Then
                DLTP0101_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintErrorSendDataCnt - 1)

            For i = 0 To gintErrorSendDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorSendDataCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = gintErrorSendDataCnt
            PI_03.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0101_PROC0022 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �o�׌��i�������f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0201_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                OraTran.Rollback()

                Exit Function

            End If

            OraTran.Commit()

            If gintResultCnt = 0 Then
                DLTP0201_PROC0011 = 2
            Else
                DLTP0201_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �Z�b�V�������폜
    ''' </summary>
    ''' <param name="strProgram_ID">�v���O����_ID</param>
    ''' <param name="strV�敪">DLT�Z�b�V�������.V�敪</param>
    ''' <param name="intN�敪">DLT�Z�b�V�������.N�敪</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0998S_PROC0013(ByVal strProgram_ID As String,
                                              ByVal strV�敪 As String,
                                              ByVal intN�敪 As Integer) As Integer


        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PI_08 As OracleParameter
        Dim PI_09 As OracleParameter
        Dim PI_10 As OracleParameter
        Dim PI_11 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_99 As OracleParameter

        Try

            DLTP0998S_PROC0013 = 9

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0013"
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Int32, ParameterDirection.Input)
            PI_09 = Oracmd.Parameters.Add("PI_09", OracleDbType.Int32, ParameterDirection.Input)
            PI_10 = Oracmd.Parameters.Add("PI_10", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_11 = Oracmd.Parameters.Add("PI_11", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_99 = Oracmd.Parameters.Add("PO_99", OracleDbType.Int32, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = "DELETE"
            PI_02.Value = strProgram_ID
            PI_03.Value = strV�敪
            PI_04.Value = intN�敪
            PI_05.Value = vbNullString
            PI_06.Value = vbNullString
            PI_07.Value = vbNullString
            PI_08.Value = vbNullString
            PI_09.Value = vbNullString
            PI_10.Value = vbNullString
            PI_11.Value = vbNullString

            '�X�g�A�h�v���V�[�W��call
            Oracmd.ExecuteNonQuery()

            '���^�[���R�[�h�ł̏����U�蕪��
            If CInt(PO_99.Value.ToString) = 0 Then

                DLTP0998S_PROC0013 = 0

                Exit Function

            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �s�b�L���O�A�g�f�[�^�쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0201_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0201_PROC0001 = 8
                Else
                    DLTP0201_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �s�b�L���O�A�g�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0201_PROC0012 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0201_PROC0012 = 2
            Else
                DLTP0201_PROC0012 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���[�f�[�^�����f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0201_PROC0013 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0201_PROC0013 = 2
            Else
                DLTP0201_PROC0013 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �s�b�L���O�A�g�f�[�^����(EXCEL�p)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0201_PROC0014 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0201_PROC0014 = 2
            Else
                DLTP0201_PROC0014 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �L�������ؔ��f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0201_PROC0015 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng���v��R�[�h


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0201_PROC0015 = 2
            Else
                DLTP0201_PROC0015 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �s�b�L���O�A�g�f�[�^�o�͌��ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0201_PROC0021 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = Results(i).strBuff(0)
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0201_PROC0021 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���[�f�[�^�o�͌��ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0022(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As Integer
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0201_PROC0022 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(18))
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0201_PROC0022 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �L�������ؔ��f�[�^�o�͌��ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0201_PROC0023(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As Integer
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0201_PROC0023 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 8, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0023 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(20))
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0201_PROC0023 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    '''�f�[�^�쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0302_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0302_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0302_PROC0001 = 8
                Else
                    DLTP0302_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    '''  ���ё��M�p�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int���M�敪"> 0�E�E���M�p,9�E�E�G���[�o�͗p</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0302_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int���M�敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0302_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int���M�敪

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0302_PROC0011 = 2
            Else
                DLTP0302_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���M���ʂ����Ƀe�[�u�����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int���M�敪">0�E�E���M�p,9�E�E�G���[�o�͗p</param>
    ''' <param name="PI_intResult">1�E�E���� 9�E����s</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0302_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int���M�敪 As Integer,
                                             ByVal PI_intResult As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim ID() As Integer
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0302_PROC0021 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0302_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(1))
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = ID
            PI_02.Value = PI_int���M�敪
            PI_03.Value = gintResultCnt
            PI_04.Value = PI_intResult

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0302_PROC0021 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' Aptage�p�ėp�󒍃f�[�^�쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng�쐬�S���҃R�[�h">�쐬�S���҃R�[�h</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0103_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng�쐬�S���҃R�[�h As Long,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try
            DLTP0103_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng�쐬�S���҃R�[�h
            PI_03.Value = PI_int�捞�ԍ�
            PI_04.Value = PI_intSubProgram_ID

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0103_PROC0002 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���ʕ\���p�Ώۓ��Ӑ�ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0103_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim strPROC As String

        Try
            DLTP0103_PROC0015 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005


            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            ���ʕ\���p���Ӑ�ꗗArray = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve ���ʕ\���p���Ӑ�ꗗArray(RowCnt)

                    If OraDr.IsDBNull(0) = False Then
                        ���ʕ\���p���Ӑ�ꗗArray(RowCnt).strRecData = ""
                        ���ʕ\���p���Ӑ�ꗗArray(RowCnt).strRecData = CType(OraDr.GetValue(0), String)
                    End If

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0103_PROC0015 = 2
            Else
                DLTP0103_PROC0015 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' OliverEAN�e�L�X�g�捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0301_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0
            PI_04.Value = gint�捞�f�[�^Cnt

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0301_PROC0001 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' Oliver�G���[�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�Ώ���">�Ώۓ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0010(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�Ώ��� As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0010 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_�Ώ���.Trim

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                OraTran.Rollback()

                Exit Function

            End If

            OraTran.Commit()

            If gintResultCnt = 0 Then
                DLTP0301_PROC0010 = 2
            Else
                DLTP0301_PROC0010 = 0
            End If

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' OliverEAN�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0301_PROC0011 = 2
            Else
                DLTP0301_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����ݏo�ԍ����o��
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PI_�o�͋敪">0�E�E�ݏo���̂݁A1�E�E�S��</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_���v��R�[�h As Long,
                                             ByVal PI_�o�͋敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0013 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            If PI_���v��R�[�h = 0 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_���v��R�[�h
            End If
            PI_04.Value = PI_�o�͋敪

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                OraTran.Rollback()

                Exit Function

            End If

            OraTran.Commit()

            If gintResultCnt = 0 Then
                DLTP0301_PROC0013 = 2
            Else
                DLTP0301_PROC0013 = 0
            End If

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����}�X�^�o�́i���j�՗p�j/�I���Ώۃf�[�^�o�́i���j�՗p�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_���v��R�[�h">���v��R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0025(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_���v��R�[�h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0025 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_���v��R�[�h

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0301_PROC0025 = 2
            Else
                DLTP0301_PROC0025 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �L�������ؔ��i�o�ז��׏o��
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�Ώۓ�">�Ώۓ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0016(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�Ώۓ� As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0016 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_�Ώۓ�.Trim

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0301_PROC0016 = 2
            Else
                DLTP0301_PROC0016 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �̗p���i���捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0501_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try

            DLTP0501_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintExcelDataCnt - 1)

            For i = 0 To gintExcelDataCnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintExcelDataCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0501_PROC0001 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����f�[�^�捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="str�Ώۓ�">�Ώۓ�</param>
    ''' <param name="str�\�[�X">�\�[�X</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal str�Ώۓ� As String,
                                             ByVal str�\�[�X As String,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try

            DLTP0401_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = str�\�[�X.Trim
            PI_05.Value = str�Ώۓ�.Trim

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    DLTP0401_PROC0001 = 0

                    OraTran.Commit()

                Case 8

                    DLTP0401_PROC0001 = 8

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Commit()

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Rollback()

            End Select

            Exit Function

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������G���[��񌟍�
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0401_PROC0021 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0401_PROC0021 = 2
            Else
                DLTP0401_PROC0021 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������`�F�b�N���ʏo��
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�f�[�^�敪">�f�[�^���</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�f�[�^�敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0401_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_�f�[�^�敪, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_�f�[�^�敪, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_�f�[�^�敪


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0401_PROC0011 = 2
            Else
                DLTP0401_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������G���[��񌟍�
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_str�[����">�[����</param>
    ''' <param name="PI_intSESSION_ID">�Z�b�V����ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0402_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str�[���� As String,
                                             ByVal PI_intSESSION_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0402_PROC0021 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_str�[����
            PI_02.Value = PI_intSESSION_ID


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0402_PROC0021 = 2
            Else
                DLTP0402_PROC0021 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����f�[�^�捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="str�Ώۓ�">�Ώۓ�</param>
    ''' <param name="PI_obj���Ə��R�[�h">���Ə��R�[�h</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PI_int�����Ώ�">�����Ώ�</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_str�[����">�[�����i�ߒl�j</param>
    ''' <param name="PO_intOraSessionID">�Z�b�V����ID�i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0402_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal str�Ώۓ� As String,
                                             ByVal PI_obj���Ə��R�[�h As Object,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByVal PI_int�����Ώ� As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_str�[���� As String,
                                             ByRef PO_intOraSessionID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer


        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter
        Dim PO_07 As OracleParameter


        Try

            DLTP0402_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Int32, ParameterDirection.Output)
            PO_07 = Oracmd.Parameters.Add("PO_07", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = str�Ώۓ�.Trim
            PI_05.Value = PI_obj���Ə��R�[�h
            PI_06.Value = PI_lng���Ӑ�R�[�h
            PI_07.Value = PI_int�����Ώ�

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_str�[���� = PO_04.Value.ToString
            PO_intOraSessionID = CType(PO_05.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_06.Value.ToString, Integer)
            PO_strSQLERRM = PO_07.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    DLTP0402_PROC0001 = 0

                    OraTran.Commit()

                Case 8

                    DLTP0402_PROC0001 = 8

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Commit()

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Rollback()

            End Select

            Exit Function

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������`�F�b�N���ʏo��
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_str�[����">�[����</param>
    ''' <param name="PI_intOraSessionID">�Z�b�V����ID</param>
    ''' <param name="PI_�f�[�^�敪">�f�[�^�敪</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0402_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str�[���� As String,
                                             ByVal PI_intOraSessionID As Integer,
                                             ByVal PI_�f�[�^�敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0402_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_�f�[�^�敪, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_�f�[�^�敪, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_str�[����
            PI_02.Value = PI_intOraSessionID
            PI_03.Value = PI_�f�[�^�敪


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0402_PROC0011 = 2
            Else
                DLTP0402_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �̔����ؑ��݊m�F
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PI_int���؋敪">���؋敪</param>
    ''' <param name="PI_int���t�l��">���t�l��     -- 0�E�E�̔����I�������l������A1�E�E���Ȃ�</param>
    ''' <returns>0 -- �f�[�^�Ȃ� 1 -- �f�[�^���� 9 -- �G���[</returns>
    Public Shared Function DLTP0503_FUNC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByVal PI_int���؋敪 As Integer,
                                             ByVal PI_int���t�l�� As Integer) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim strPROC As String

        Try

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�A�E�g�v�b�g�p�����[�^�ݒ�(FUNCTION�͈�ԍŏ��Ƀp�����[�^�ݒ�)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_lng���Ӑ�R�[�h
            PI_02.Value = PI_int���؋敪
            PI_03.Value = PI_int���t�l��

            '�X�g�A�h�v���V�[�W��call
            Oracmd.ExecuteNonQuery()

            DLTP0503_FUNC0001 = CInt(PO_01.Value.ToString.Trim)

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �̔����ؓo�^
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode"> SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_���p�敪">0�E�E���p���Ȃ��A1�E�E���p����</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PI_lng���p�����Ӑ�R�[�h">���p�����Ӑ�R�[�h</param>
    ''' <param name="PI_str�̔����ؔԍ�">�̔����ؔԍ�</param>
    ''' <param name="PI_str�̔����J�n���t">�̔����J�n���t</param>
    ''' <param name="PI_str�̔����I�����t">�̔����I�����t</param>
    ''' <param name="PI_int���؋敪">���؋敪</param>
    ''' <param name="PI_int�摜�t�@�C��">���؃t�@�C��</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 1 -- ���p����̂ɁA���p���Ȃ� 9 -- �ُ�I��</returns>
    Public Shared Function DLTP0503_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_���p�敪 As Integer,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByVal PI_lng���p�����Ӑ�R�[�h As Long,
                                             ByVal PI_str�̔����ؔԍ� As String,
                                             ByVal PI_str�̔����J�n���t As String,
                                             ByVal PI_str�̔����I�����t As String,
                                             ByVal PI_int���؋敪 As Integer,
                                             ByVal PI_int�摜�t�@�C�� As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PI_08 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Blob, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_���p�敪
            PI_02.Value = PI_lng���Ӑ�R�[�h
            PI_03.Value = PI_lng���p�����Ӑ�R�[�h
            PI_04.Value = PI_str�̔����ؔԍ�
            PI_05.Value = PI_str�̔����J�n���t
            PI_06.Value = PI_str�̔����I�����t
            PI_07.Value = PI_int���؋敪
            If PI_���p�敪 = 0 Then
                If Chk_FileExists(PI_int�摜�t�@�C��) = True Then
                    Dim fs As New IO.FileStream(PI_int�摜�t�@�C��, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim ImageData(CType(fs.Length, Integer)) As Byte
                    fs.Read(ImageData, 0, CType(fs.Length, Integer))
                    PI_08.Value = ImageData
                    fs.Close()
                Else
                    PI_08.Value = vbNullString
                End If
            Else
                PI_08.Value = vbNullString
            End If

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            DLTP0503_PROC0001 = PO_intSQLCODE

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' PHsmos��Ë@�ֈꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0505_PROC0020(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim strPROC As String

        Dim i As Integer

        Try
            DLTP0505_PROC0020 = False

            gintPHsmos��Ë@��Cnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            PHsmos��Ë@��Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve PHsmos��Ë@��Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    PHsmos��Ë@��Array(i).str��Ë@�փR�[�h = OraDr.GetString(0)
                    PHsmos��Ë@��Array(i).str��Ë@�֖� = OraDr.GetString(1)
                    i += 1

                End While

                gintPHsmos��Ë@��Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0505_PROC0020 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' PHsmos�̗p���i���o��
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_str��Ë@�փR�[�h">��Ë@�փR�[�h</param>
    ''' <param name="PI_�Ώۓ��t">����/�����X�V���t</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0505_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str��Ë@�փR�[�h As String,
                                             ByVal PI_�Ώۓ��t As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0505_PROC0001 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_str��Ë@�փR�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_�Ώۓ��t

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0505_PROC0001 = 2
            Else
                DLTP0505_PROC0001 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���ڎ����ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PI_���ږ�">���ڎ����}�X�^.���ږ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0901_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_���ږ� As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0005 = False

            gint���̎���Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_���ږ�

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ���ڎ���Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve ���ڎ���Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    ���ڎ���Array(i).int�R�[�h = OraDr.GetInt32(0)
                    ���ڎ���Array(i).str���� = OraDr.GetString(1)
                    i += 1

                End While

                gint���ڎ���Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0901_PROC0005 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���̎����ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID�i���g�p�j</param>
    ''' <param name="PI_���ږ�">���̎����}�X�^.���ږ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0901_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_���ږ� As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0004 = False

            gint���̎���Cnt = 0

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_���ږ�

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ���̎���Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve ���̎���Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    ���̎���Array(i).str�R�[�h = OraDr.GetString(0)
                    ���̎���Array(i).str���� = OraDr.GetString(1)
                    i += 1

                End While

                gint���̎���Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0901_PROC0004 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����ݏo�ԍ����擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng�����ݏo�ԍ�">�����ݏo�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0301_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng�����ݏo�ԍ� As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0301_PROC0014 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng�����ݏo�ԍ�

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            gudt�����ݏo�ԍ����.IsClear()

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    OraDr.Read()

                    If OraDr.IsDBNull(0) = False Then gudt�����ݏo�ԍ����.lng�����ݏo�ԍ� = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then gudt�����ݏo�ԍ����.str�o�ד� = CStr(OraDr.GetValue(1))
                    If OraDr.IsDBNull(2) = False Then gudt�����ݏo�ԍ����.str�󒍌`�� = OraDr.GetString(2)
                    If OraDr.IsDBNull(3) = False Then gudt�����ݏo�ԍ����.str���v�於 = OraDr.GetString(3)
                    If OraDr.IsDBNull(4) = False Then gudt�����ݏo�ԍ����.str���v�敔���� = OraDr.GetString(4)
                    If OraDr.IsDBNull(5) = False Then gudt�����ݏo�ԍ����.str���i�R�[�h = OraDr.GetString(5)
                    If OraDr.IsDBNull(6) = False Then gudt�����ݏo�ԍ����.str���[�J�� = OraDr.GetString(6)
                    If OraDr.IsDBNull(7) = False Then gudt�����ݏo�ԍ����.str���[�J�i�� = OraDr.GetString(7)
                    If OraDr.IsDBNull(8) = False Then gudt�����ݏo�ԍ����.str���i�� = OraDr.GetString(8)
                    If OraDr.IsDBNull(9) = False Then gudt�����ݏo�ԍ����.str�K�i = OraDr.GetString(9)
                    If OraDr.IsDBNull(10) = False Then gudt�����ݏo�ԍ����.str�L������ = CStr(OraDr.GetValue(10))
                    If OraDr.IsDBNull(11) = False Then gudt�����ݏo�ԍ����.str���b�g = OraDr.GetString(11)
                    If OraDr.IsDBNull(12) = False Then gudt�����ݏo�ԍ����.str�V���A�� = OraDr.GetString(12)
                    If OraDr.IsDBNull(13) = False Then gudt�����ݏo�ԍ����.lng�o�א��� = CLng(OraDr.GetDouble(13))
                    If OraDr.IsDBNull(14) = False Then gudt�����ݏo�ԍ����.str�o�גP�ʖ� = OraDr.GetString(14)
                    If OraDr.IsDBNull(15) = False Then gudt�����ݏo�ԍ����.str����� = CStr(OraDr.GetValue(15))
                    If OraDr.IsDBNull(16) = False Then gudt�����ݏo�ԍ����.str������v�於 = OraDr.GetString(16)
                    If OraDr.IsDBNull(17) = False Then gudt�����ݏo�ԍ����.str������v�敔���� = OraDr.GetString(17)
                    If OraDr.IsDBNull(18) = False Then gudt�����ݏo�ԍ����.str�ԋp�� = CStr(OraDr.GetValue(18))

                Case 2

                    DLTP0301_PROC0014 = 2
                    OraTran.Rollback()
                    Exit Function

                Case -54 'NOWAIT �r�W�[

                    DLTP0301_PROC0014 = -54
                    OraTran.Rollback()
                    Exit Function

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    OraTran.Rollback()
                    Exit Function
            End Select

            DLTP0301_PROC0014 = 0

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �����ݏo�ԍ����X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng�����ݏo�ԍ�">�����ݏo�ԍ�</param>
    ''' <param name="PI_str������">������</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0301_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng�����ݏo�ԍ� As Long,
                                             ByVal PI_str������ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0301_PROC0015 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng�����ݏo�ԍ�
            PI_04.Value = PI_str������

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            If Math.Abs(PO_intSQLCODE) > 0 Then
                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                OraTran.Rollback()
                Exit Function
            End If

            OraTran.Commit()

            DLTP0301_PROC0015 = 0

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ�ʔ̔����؃����e�i���X(���Ӑ挟��)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng���Ӑ�R�[�h">���Ӑ�R�[�h</param>
    ''' <param name="PI_str�Ǝ�R�[�h">�Ǝ�R�[�h</param>
    ''' <param name="PI_int���؋敪">���؋敪</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0504_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng���Ӑ�R�[�h As Long,
                                             ByVal PI_str�Ǝ�R�[�h As String,
                                             ByVal PI_int���؋敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0504_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            If PI_lng���Ӑ�R�[�h = DUMMY_LNGCODE Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_lng���Ӑ�R�[�h
            End If
            If IsNull(PI_str�Ǝ�R�[�h) Then
                PI_02.Value = vbNullString
            Else
                PI_02.Value = PI_str�Ǝ�R�[�h
            End If
            If PI_int���؋敪 = 7 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_int���؋敪
            End If

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case -54 'NOWAIT �r�W�[

                    DLTP0504_PROC0001 = -54
                    OraTran.Rollback()
                    Exit Function

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    OraTran.Rollback()
                    Exit Function
            End Select

            If gintResultCnt = 0 Then
                DLTP0504_PROC0001 = 2
                OraTran.Rollback()
            Else
                DLTP0504_PROC0001 = 0
            End If

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ�ʔ̔����؃����e�i���X(��������)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str�Ǝ�R�[�h">�Ǝ�R�[�h</param>
    ''' <param name="PI_int���؋敪">���؋敪</param>
    ''' <param name="PI_����">����</param>
    ''' <param name="PI_�I�����t">�I�����t</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0504_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�Ǝ�R�[�h As String,
                                             ByVal PI_int���؋敪 As Integer,
                                             ByVal PI_���� As Integer,
                                             ByVal PI_�I�����t As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0504_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)


            '�C���v�b�g�l�ݒ�
            If IsNull(PI_str�Ǝ�R�[�h) Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_str�Ǝ�R�[�h
            End If
            PI_02.Value = PI_int���؋敪
            PI_03.Value = PI_����
            If PI_���� = 2 Then
                PI_04.Value = PI_�I�����t
            Else
                PI_04.Value = vbNullString
            End If

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case -54 'NOWAIT �r�W�[

                    DLTP0504_PROC0002 = -54
                    OraTran.Rollback()
                    Exit Function

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    OraTran.Rollback()
                    Exit Function
            End Select

            If gintResultCnt = 0 Then
                DLTP0504_PROC0002 = 2
                OraTran.Rollback()
            Else
                DLTP0504_PROC0002 = 0
            End If

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ�ʔ̔����؃����e�i���X(�폜)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_����">�폜����</param>
    ''' <param name="PI_Results">DLT�̔����؊Ǘ����_ID_Array</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0504_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_���� As Integer,
                                             ByVal PI_Results() As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0504_PROC0011 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = PI_����

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_Results
            PI_02.Value = PI_����

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0504_PROC0011 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ�ʔ̔����؃����e�i���X(�摜�擾)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lngID">DLT�̔����؊Ǘ����_ID</param>
    ''' <param name="PO_Img">�摜�i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0504_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lngID As Long,
                                             ByRef PO_Img As Image,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim strPROC As String
        Dim blob As Oracle.DataAccess.Types.OracleBlob
        Dim Img As Image

        Try
            DLTP0504_PROC0021 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure


            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_lngID

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    Img = Nothing

                    If OraDr.Read Then

                        blob = OraDr.GetOracleBlob(1)

                        Dim ms As New IO.MemoryStream(blob.Value)

                        Img = New Bitmap(ms)

                    End If

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    Exit Function

            End Select

            PO_Img = Img

            Img = Nothing

            DLTP0504_PROC0021 = 0

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍌`�ԃ����e�i���X���i���擾�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str���i�R�[�h">���i�R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0301_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str���i�R�[�h As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0021 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_str���i�R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case 7, 8
                    DLTP0301_PROC0021 = PO_intSQLCODE
                    Exit Function
                Case Else
                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    Exit Function
            End Select

            DLTP0301_PROC0021 = 0

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍌`�ԃ����e�i���X���i���擾�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str���i�R�[�h">���i�R�[�h</param>
    ''' <param name="PI_strSPD���i�R�[�h">SPD���i�R�[�h</param>
    ''' <param name="PI_int�󒍌`��">�󒍌`��</param>
    ''' <param name="PI_int�o�טA�g">�o�טA�g</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I��</returns>
    Public Shared Function DLTP0301_PROC0022(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str���i�R�[�h As String,
                                             ByVal PI_strSPD���i�R�[�h As String,
                                             ByVal PI_int�󒍌`�� As Integer,
                                             ByVal PI_int�o�טA�g As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0301_PROC0022 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_str���i�R�[�h
            PI_05.Value = PI_strSPD���i�R�[�h
            PI_06.Value = PI_int�󒍌`��
            PI_07.Value = PI_int�o�טA�g

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If Math.Abs(PO_intSQLCODE) > 0 Then
                OraTran.Rollback()
                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                DLTP0301_PROC0022 = PO_intSQLCODE
                Exit Function
            End If

            OraTran.Commit()

            DLTP0301_PROC0022 = 0

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍃e�L�X�g�捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���͒S���R�[�h">���͒S���R�[�h</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0106_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���͒S���R�[�h As Long,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0106_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int64, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_lng���͒S���R�[�h
            PI_05.Value = My.Settings.���Ə��R�[�h

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0106_PROC0001 = 8
                Else
                    DLTP0106_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' Aptage�p�ėp�󒍃f�[�^�쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_lng�쐬�S���҃R�[�h">�쐬�S���҃R�[�h</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0106_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng�쐬�S���҃R�[�h As Long,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try
            DLTP0106_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng�쐬�S���҃R�[�h
            PI_03.Value = PI_int�捞�ԍ�
            PI_04.Value = PI_intSubProgram_ID

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0106_PROC0002 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���Ӑ�ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0304_PROC0020(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim strPROC As String

        Dim i As Integer

        Try
            DLTP0304_PROC0020 = False

            gint���Ӑ�Cnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ���Ӑ�Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve ���Ӑ�Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    ���Ӑ�Array(i).lng���Ӑ�R�[�h = OraDr.GetInt64(0)
                    ���Ӑ�Array(i).str���Ӑ於 = OraDr.GetString(1)
                    i += 1

                End While

                gint���Ӑ�Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0304_PROC0020 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�[�i���쐬(���F��[�i���ё��M)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���|��R�[�h">���|��R�[�h</param>
    ''' <param name="PI_txt�ΏۊJ�n��">�ΏۊJ�n��</param>
    ''' <param name="PI_txt�ΏۏI����">�ΏۏI����</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0304_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���|��R�[�h As Long,
                                             ByVal PI_txt�ΏۊJ�n�� As String,
                                             ByVal PI_txt�ΏۏI���� As String,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0304_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt�ΏۊJ�n��.Trim
            PI_05.Value = PI_txt�ΏۏI����.Trim
            If PI_lng���|��R�[�h = 0 Then
                PI_06.Value = vbNullString
            Else
                PI_06.Value = PI_lng���|��R�[�h
            End If

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0304_PROC0001 = 8
                Else
                    DLTP0304_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�[�i���f�[�^����(���F��[�i���ё��M)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0304_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0304_PROC0021 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0304_PROC0021 = 2
            Else
                DLTP0304_PROC0021 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�����ӏ��쐬(���F������`��)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���|��R�[�h">���|��R�[�h</param>
    ''' <param name="PI_txt��������">��������</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0403_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng���|��R�[�h As Long,
                                             ByVal PI_txt�������� As String,
                                             ByRef PO_intNo As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter
        Dim PO_06 As OracleParameter

        Try

            DLTP0403_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int64, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt��������.Trim
            If PI_lng���|��R�[�h = 0 Then
                PI_05.Value = vbNullString
            Else
                PI_05.Value = PI_lng���|��R�[�h
            End If

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0403_PROC0001 = 8
                Else
                    DLTP0403_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�������׏��쐬(���F������`��)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0403_PROC0101(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�捞�ԍ� As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try

            DLTP0403_PROC0101 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_�捞�ԍ�

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt0 = 0 Then
                    DLTP0403_PROC0101 = 8
                Else
                    DLTP0403_PROC0101 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�����ӏ��f�[�^����(���F������`��)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0403_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0403_PROC0021 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0403_PROC0021 = 2
            Else
                DLTP0403_PROC0021 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �`���p�������׏��f�[�^����(���F������`��)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0403_PROC0201(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0403_PROC0201 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0403_PROC0201 = 2
            Else
                DLTP0403_PROC0201 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���O�C�����X�V
    ''' </summary>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����I�� 9 -- �G���[</returns>
    Public Shared Function DLTP0000_PROC0006(ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0000_PROC0006 = False

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0006"
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Get_MachineName()
            PI_02.Value = My.Application.Info.Version

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0000_PROC0006 = True

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���[�f�[�^�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSPDSystemcode">�T�u�v���O����_ID</param>
    ''' <param name="PI_str�A�g�L�[">�A�g�[</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j></param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0023(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�A�g�L�[ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0301_PROC0023 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str�A�g�L�[

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case 7, 8
                    DLTP0301_PROC0023 = PO_intSQLCODE
                    Exit Function
                Case Else
                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    Exit Function
            End Select

            DLTP0301_PROC0023 = 0

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���[�f�[�^�X�V
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSPDSystemcode">�T�u�v���O����_ID</param>
    ''' <param name="PI_str�A�g�L�[">�A�g�[</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j></param>
    ''' <returns>True�E�E����I���AFalse�E�E�ُ�I��</returns>
    Public Shared Function DLTP0301_PROC0024(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�A�g�L�[ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0301_PROC0024 = False

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_str�A�g�L�[

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0301_PROC0024 = True

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���o�ɏ��쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���敪">���敪</param>
    ''' <param name="PI_txt�ΏۊJ�n��">�ΏۊJ�n��</param>
    ''' <param name="PI_txt�ΏۏI����">�ΏۏI����</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0502_PROC0001(ByVal PI_strProgram_ID As String,
                                            ByVal PI_intSPDSystemcode As Integer,
                                            ByVal PI_intSubProgram_ID As Integer,
                                            ByVal PI_lng���敪 As Integer,
                                            ByVal PI_txt�ΏۊJ�n�� As String,
                                            ByVal PI_txt�ΏۏI���� As String,
                                            ByVal PI_int�����Ώۋ敪 As Integer,
                                            ByRef PO_intNo As Integer,
                                            ByRef PO_intCnt As Integer,
                                            ByRef PO_intSQLCODE As Integer,
                                            ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter

        Try

            DLTP0502_PROC0001 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt�ΏۊJ�n��.Trim & "/01"
            PI_05.Value = PI_txt�ΏۏI����.Trim & "/01"
            PI_06.Value = PI_lng���敪
            PI_07.Value = PI_int�����Ώۋ敪

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt = CType(PO_02.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_03.Value.ToString, Integer)
            PO_strSQLERRM = PO_04.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt = 0 Then
                    DLTP0502_PROC0001 = 8
                Else
                    DLTP0502_PROC0001 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���o�ɏ��쐬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_lng���敪">���敪</param>
    ''' <param name="PI_txt�ΏۊJ�n��">�ΏۊJ�n��</param>
    ''' <param name="PI_txt�ΏۏI����">�ΏۏI����</param>
    ''' <param name="PO_intNo">�捞�ԍ��i�ߒl�j</param>
    ''' <param name="PO_intCnt">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0502_PROC0002(ByVal PI_strProgram_ID As String,
                                            ByVal PI_intSPDSystemcode As Integer,
                                            ByVal PI_intSubProgram_ID As Integer,
                                            ByVal PI_lng���敪 As Integer,
                                            ByVal PI_txt�ΏۊJ�n�� As String,
                                            ByVal PI_txt�ΏۏI���� As String,
                                            ByVal PI_int�����Ώۋ敪 As Integer,
                                            ByRef PO_intNo As Integer,
                                            ByRef PO_intCnt As Integer,
                                            ByRef PO_intSQLCODE As Integer,
                                            ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter

        Try

            DLTP0502_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = My.Settings.���Ə��R�[�h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt�ΏۊJ�n��.Trim & "/01"
            PI_05.Value = PI_txt�ΏۏI����.Trim & "/01"
            PI_06.Value = PI_lng���敪
            PI_07.Value = PI_int�����Ώۋ敪

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt = CType(PO_02.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_03.Value.ToString, Integer)
            PO_strSQLERRM = PO_04.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                If PO_intCnt = 0 Then
                    DLTP0502_PROC0002 = 8
                Else
                    DLTP0502_PROC0002 = 0
                End If

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���o�ɏ����f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0502_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0502_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0502_PROC0011 = 2
            Else
                DLTP0502_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ���o�ɏ����f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�捞�ԍ�">�捞�ԍ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0502_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�捞�ԍ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0502_PROC0012 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 4, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_int�捞�ԍ�


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0502_PROC0012 = 2
            Else
                DLTP0502_PROC0012 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �I�����ʓo�^�O�Ǎ��f�[�^�o�́i���j�՗p�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0301_PROC0027(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer

        Try

            DLTP0301_PROC0027 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            ReDim Data(gintExcelDataCnt - 1)

            For i = 0 To gintExcelDataCnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintExcelDataCnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = gintExcelDataCnt

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0301_PROC0027 = 2
            Else
                DLTP0301_PROC0027 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �V�_��SPD�{�݈ꗗ�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_str�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>True -- ����擾 False -- �G���[</returns>
    Public Shared Function DLTP0501_PROC0101(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str�a�@�R�[�h As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim strPROC As String

        Dim i As Integer

        Try
            DLTP0501_PROC0101 = False

            gin�{��Cnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_str�a�@�R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            �{��Array = Nothing

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    '�������Ď擾
                    ReDim Preserve �{��Array(i)

                    '�O���[�o���ϐ��ɃZ�b�g
                    �{��Array(i).str�{�݃R�[�h = OraDr.GetString(0)
                    �{��Array(i).str�{�ݖ� = OraDr.GetString(1)
                    i += 1

                End While

                gin�{��Cnt = i

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            DLTP0501_PROC0101 = True

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �V�_��SPD�������擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PI_str�����R�[�h">�����R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A8 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0501_PROC0102(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�a�@�R�[�h As String,
                                             ByVal PI_str�����R�[�h As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0501_PROC0102 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_str�a�@�R�[�h
            PI_05.Value = PI_str�����R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case Else
                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    Exit Function
            End Select

            If gintResultCnt = 0 Then
                DLTP0501_PROC0102 = 8
            Else
                DLTP0501_PROC0102 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �V�_��SPD������񃁃��e�i���X
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PI_int����ID">����ID</param>
    ''' <param name="PI_str�{�݃R�[�h">�{�݃R�[�h</param>
    ''' <param name="PI_str�����R�[�h">�����R�[�h</param>
    ''' <param name="PI_str������">������</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A9 -- �ُ�I��</returns>
    Public Shared Function DLTP0501_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�a�@�R�[�h As String,
                                             ByVal PI_int����ID As Integer,
                                             ByVal PI_str�{�݃R�[�h As String,
                                             ByVal PI_str�����R�[�h As String,
                                             ByVal PI_str������ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PI_08 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0501_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int64, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Varchar2, ParameterDirection.Input)


            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.���Ə��R�[�h
            PI_04.Value = PI_str�a�@�R�[�h
            PI_05.Value = PI_int����ID
            PI_06.Value = PI_str�{�݃R�[�h
            PI_07.Value = PI_str�����R�[�h
            PI_08.Value = PI_str������

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If Math.Abs(PO_intSQLCODE) > 0 Then
                OraTran.Rollback()
                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                DLTP0501_PROC0002 = PO_intSQLCODE
                Exit Function
            End If

            OraTran.Commit()

            DLTP0501_PROC0002 = 0

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍌`�ԃ����e�i���X���i���擾�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PI_str�@���R�[�h">str�@���R�[�h</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I�� </returns>
    Public Shared Function DLTP0501_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�a�@�R�[�h As String,
                                             ByVal PI_str�@���R�[�h As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0501_PROC0013 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str�a�@�R�[�h
            PI_04.Value = PI_str�@���R�[�h

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    RowCnt = 0

                    While OraDr.Read

                        ReDim Preserve Results(RowCnt)

                        For ColCnt = 0 To ColMax - 1

                            ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                            If OraDr.IsDBNull(ColCnt) = False Then
                                Results(RowCnt).strBuff(ColCnt) = ""
                                Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                            End If

                        Next

                        RowCnt += 1

                    End While

                    gintResultCnt = RowCnt

                Case Else
                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                    Exit Function
            End Select

            If gintResultCnt = 0 Then
                DLTP0501_PROC0013 = 2
            Else
                DLTP0501_PROC0013 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �󒍌`�ԃ����e�i���X���i���擾�擾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_str�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PI_str���iID">���iID</param>
    ''' <param name="PI_int�}���R�Ώ�">�}���R�Ώ�</param>
    ''' <param name="PI_int�}���r�V�Ώ�">�}���r�V�Ώ�</param>
    ''' <param name="PI_int�y���ŗ��Ώ�">�y���ŗ��Ώ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����I���A2 -- �f�[�^�Ȃ��A9 -- �ُ�I��</returns>
    Public Shared Function DLTP0501_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str�a�@�R�[�h As String,
                                             ByVal PI_str���iID As String,
                                             ByVal PI_int�}���R�Ώ� As Integer,
                                             ByVal PI_int�}���r�V�Ώ� As Integer,
                                             ByVal PI_int�y���ŗ��Ώ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PI_07 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim strPROC As String

        Try
            DLTP0501_PROC0005 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str�a�@�R�[�h
            PI_04.Value = PI_str���iID
            PI_05.Value = PI_int�}���R�Ώ�
            PI_06.Value = PI_int�}���r�V�Ώ�
            PI_07.Value = PI_int�y���ŗ��Ώ�

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If Math.Abs(PO_intSQLCODE) > 0 Then
                OraTran.Rollback()
                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
                DLTP0501_PROC0005 = PO_intSQLCODE
                Exit Function
            End If

            OraTran.Commit()

            DLTP0501_PROC0005 = 0

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �̗p���i���捞���`�F�b�N
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_int�Ǘ��敪">�Ǘ��敪</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0501_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int�Ǘ��敪 As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try

            DLTP0501_PROC0003 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_int�Ǘ��敪, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            If PO_intSQLCODE = 0 Then

                OraTran.Commit()

                DLTP0501_PROC0003 = 0

                Exit Function

            End If

            log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

            OraTran.Rollback()

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' SPD�̗p���i�}�X�^�ꊇ�X�V�����@�G���[�f�[�^����
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0501_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0501_PROC0011 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0501_PROC0011 = 2
            Else
                DLTP0501_PROC0011 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' SPD�̗p���i�}�X�^�ꊇ�X�V�����@����i�ڃf�[�^�����i�d����F�}���R�A�}���r�V�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_txt�Ώۓ�">�Ώۓ�</param>
    ''' <param name="PI_int�o�͑Ώ�">�o�͑Ώ�</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0501_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_txt�Ώۓ� As String,
                                             ByVal PI_int�o�͑Ώ� As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0501_PROC0012 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_txt�Ώۓ�.Trim
            PI_04.Value = PI_int�o�͑Ώ�

            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0501_PROC0012 = 2
            Else
                DLTP0501_PROC0012 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������捞���`�F�b�N�i�l���p�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�a�@�R�[�h">�a�@�R�[�h</param>
    ''' <param name="PO_intCnt0">�Ώی����i�ߒl�j</param>
    ''' <param name="PO_intCnt1">���팏���i�ߒl�j</param>
    ''' <param name="PO_intCnt2">�G���[�����i�ߒl�j</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�a�@�R�[�h As String,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim strPROC As String
        Dim i As Integer
        Dim Data() As String
        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim PO_04 As OracleParameter
        Dim PO_05 As OracleParameter

        Try

            DLTP0401_PROC0002 = 9

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint�捞�f�[�^Cnt - 1)

            For i = 0 To gint�捞�f�[�^Cnt - 1
                Data(i) = �捞�f�[�^Array(i).strRecData
            Next

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)

            'Output�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint�捞�f�[�^Cnt

            '�C���v�b�g�l�ݒ�
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0
            PI_04.Value = My.Settings.���Ə��R�[�h
            PI_05.Value = PI_�a�@�R�[�h

            '�X�g�A�h�v���V�[�W��Call
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '���^�[���R�[�h�ł̏����U�蕪��
            Select Case PO_intSQLCODE

                Case 0

                    DLTP0401_PROC0002 = 0

                    OraTran.Commit()

                Case 8

                    DLTP0401_PROC0002 = 8

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Commit()

                Case Else

                    log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                    OraTran.Rollback()

            End Select

            Exit Function

        Catch Oraex As OracleException

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            If Not IsNothing(OraTran) Then
                OraTran.Rollback()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not IsNothing(OraTran) Then
                OraTran.Dispose()
            End If

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' �������G���[��񌟍��i�l���p�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0031(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0401_PROC0031 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0401_PROC0031 = 2
            Else
                DLTP0401_PROC0031 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' ������񌋉ʏo�́i�l���p�j
    ''' </summary>
    ''' <param name="PI_strProgram_ID">�v���O����_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPD�V�X�e���R�[�h</param>
    ''' <param name="PI_intSubProgram_ID">�T�u�v���O����_ID</param>
    ''' <param name="PI_�f�[�^�敪">�f�[�^���</param>
    ''' <param name="PO_intSQLCODE">Oracle�G���[�R�[�h�i�ߒl�j</param>
    ''' <param name="PO_strSQLERRM">Oracle�G���[���b�Z�[�W�i�ߒl�j</param>
    ''' <returns>0 -- ����擾 2 -- ���R�[�h�� 9 -- �G���[</returns>
    Public Shared Function DLTP0401_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_�f�[�^�敪 As Integer,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter
        Dim RowCnt As Integer
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim strPROC As String

        Try
            DLTP0401_PROC0012 = 9
            gintResultCnt = 0

            '�v���O����_ID�擾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_�f�[�^�敪, 1, "�����֐�")
            strPROC = gstrDLTP0997S_FUNC005

            '���ڐ��擾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_�f�[�^�敪, 99, "���ڐ�")
            ColMax = gintDLTP0997S_FUNC004

            '�X�g�A�h�v���V�[�W���ݒ�
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            '�C���v�b�g�p�����[�^�ݒ�
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            '�C���v�b�g�l�ݒ�
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_�f�[�^�敪


            '�A�E�g�v�b�g�p�����[�^�ݒ�
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            '�X�g�A�h�v���V�[�W��call
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '���^�[���R�[�h�ł̐U�蕪��
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Results(RowCnt)

                    For ColCnt = 0 To ColMax - 1

                        ReDim Preserve Results(RowCnt).strBuff(ColCnt)

                        If OraDr.IsDBNull(ColCnt) = False Then
                            Results(RowCnt).strBuff(ColCnt) = ""
                            Results(RowCnt).strBuff(ColCnt) = CType(OraDr.GetValue(ColCnt), String)
                        End If

                    Next

                    RowCnt += 1

                End While

                gintResultCnt = RowCnt

            Else

                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))

                Exit Function

            End If

            If gintResultCnt = 0 Then
                DLTP0401_PROC0012 = 2
            Else
                DLTP0401_PROC0012 = 0
            End If

        Catch Oraex As OracleException

            log.Error(Set_ErrMSG(Oraex.Number, Oraex.ToString))
            Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            Oracmd.Dispose()

        End Try

    End Function
End Class
