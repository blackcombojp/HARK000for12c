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
    ''' OracleÚ±
    ''' </summary>
    ''' <returns>TrueEE¬÷AfalseEE¸s</returns>
    Public Shared Function OraConnect() As Boolean

        Dim StrParam As String

        Try

            OraConnect = False

            'StrParam = "User id=" & My.Settings.DB[U & ";" & "Password=" & My.Settings.DBpX[h & ";" & "Data Source=" & My.Settings.DBÚ±¶ñ
            StrParam = "User id=" & My.Settings.DB[U & ";" & "Password=" & My.Settings.DBpX[h & ";" & "Data Source=" & My.Settings.DBÚ±¶ñ & ";" & "Connection Timeout=5;Pooling=false;"

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
    ''' OracleØf
    ''' </summary>
    ''' <returns>TrueEE¬÷AfalseEE¸s</returns>
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
    ''' gUNVR~bg
    ''' </summary>
    ''' <returns>TrueEE³íAfalseEEÙí</returns>
    Public Shared Function OraTrnCommit() As Boolean

        Try

            OraTrnCommit = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0091"
            Oracmd.CommandType = CommandType.StoredProcedure

            'XgAhvV[WCall
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
    ''' gUNV[obN
    ''' </summary>
    ''' <returns>TrueEE³íAfalseEEÙí</returns>
    Public Shared Function OraTrnRollBack() As Boolean

        Try

            OraTrnRollBack = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0090"
            Oracmd.CommandType = CommandType.StoredProcedure

            'XgAhvV[WCall
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
    ''' OracleÚ±óÔmF
    ''' </summary>
    ''' <param name="PO_intOraSessionID">ZbVIDißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>TrueEEÚ±AfalseEEØf</returns>
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

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_03.Value.ToString)
            PO_strSQLERRM = PO_04.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' SÒ¼æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PI_lngüÍSR[h">üÍSR[h</param>
    ''' <param name="PI_objÆR[h">ÆR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0900_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lngüÍSR[h As Long,
                                             ByVal PI_objÆR[h As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0001 = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_lngüÍSR[h
            PI_02.Value = PI_objÆR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 30, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstrSÒ¼ = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                gstrSÒ¼ = PO_01.Value.ToString

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
    ''' å¼æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0900_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0002 = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstrå¼ = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                gstrå¼ = PO_01.Value.ToString

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
    ''' ¾Óæ¼æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PI_objÆR[h">ÆR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0900_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByVal PI_objÆR[h As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0003 = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_objÆR[h
            PI_02.Value = PI_lng¾ÓæR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr¾Óæ¼ = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                gstr¾Óæ¼ = PO_01.Value.ToString

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
    ''' ¾Óæ¼æ¾(Æ`FbN³µ)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0900_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0004 = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_lng¾ÓæR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr¾Óæ¼ = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                gstr¾Óæ¼ = PO_01.Value.ToString

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
    ''' Æêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0901_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0001 = False

            gintÆCnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ÆArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve ÆArray(i)

                    'O[oÏÉZbg
                    ÆArray(i).intÆR[h = OraDr.GetInt32(0)
                    ÆArray(i).strÆ¼ = OraDr.GetString(1)
                    i += 1

                End While

                gintÆCnt = i

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
    ''' SPDVXeR[hæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
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

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_strProgram_ID

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 100, DBNull.Value, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_04.Value.ToString)
            PO_strSQLERRM = PO_05.Value.ToString

            gintSPDVXeR[h = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                gintSPDVXeR[h = CInt(PO_01.Value.ToString)
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
    ''' vOÂÛmF
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0EEsÂA1EEÂ</returns>
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

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()
            PI_04.Value = My.Application.Info.Version

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' [îñæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
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

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gudt[îñ.IsClear()

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                OraDr.Read()

                If OraDr.IsDBNull(0) = False Then gudt[îñ.stroÍæP = OraDr.GetString(0)
                If OraDr.IsDBNull(1) = False Then gudt[îñ.stroÍæQ = OraDr.GetString(1)
                If OraDr.IsDBNull(2) = False Then gudt[îñ.stroÍæR = OraDr.GetString(2)
                If OraDr.IsDBNull(3) = False Then gudt[îñ.stroÍæS = OraDr.GetString(3)
                If OraDr.IsDBNull(4) = False Then gudt[îñ.stroÍæT = OraDr.GetString(4)

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
    ''' f¦Åêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0000_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0000_PROC0011 = False

            gintf¦ÅCnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0011"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            f¦ÂArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve f¦ÂArray(i)

                    'O[oÏÉZbg
                    f¦ÂArray(i).strf¦îñ = OraDr.GetString(0)
                    i += 1

                End While

                gintf¦ÅCnt = i

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
    ''' DLTvOÂÊîñVARCHAR^îñæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intÇæª">Çæª</param>
    ''' <param name="PI_intæª">æª</param>
    ''' <param name="PI_strImputName">Ú¼</param>
    ''' <returns>0 -- f[^ è 2 -- f[^Èµ</returns>
    Public Shared Function DLTP0997S_FUNC005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intÇæª As Integer,
                                             ByVal PI_intæª As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'AEgvbgp[^Ýè(FUNCTIONÍêÔÅÉp[^Ýè)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.ReturnValue)

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_intÇæª
            PI_05.Value = PI_intæª
            PI_06.Value = PI_strImputName.Trim

            'XgAhvV[Wcall
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
    ''' DLTvOÂÊîñNUMBER^îñæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intÇæª">Çæª</param>
    ''' <param name="PI_intæª">æª</param>
    ''' <param name="PI_strImputName">Ú¼</param>
    ''' <returns>0 -- f[^ è 2 -- f[^Èµ</returns>
    Public Shared Function DLTP0997S_FUNC004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intÇæª As Integer,
                                             ByVal PI_intæª As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'AEgvbgp[^Ýè(FUNCTIONÍêÔÅÉp[^Ýè)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_intÇæª
            PI_05.Value = PI_intæª
            PI_06.Value = PI_strImputName.Trim

            'XgAhvV[Wcall
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
    ''' vOÂÊîñ(¾Óæ)êæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intÇæª">Çæª</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0997S_PROC0001(ByVal PI_strProgram_ID As String,
                                              ByVal PI_intSPDSystemcode As Integer,
                                              ByVal PI_intSubProgram_ID As Integer,
                                              ByVal PI_intÇæª As Integer,
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

            gintùvæCnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure


            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_intÇæª

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ùvæArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve ùvæArray(i)

                    'O[oÏÉZbg
                    If OraDr.IsDBNull(0) = False Then ùvæArray(i).lngùvæR[h = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then ùvæArray(i).strùvæ¼ = OraDr.GetString(1)

                    i += 1

                End While

                gintùvæCnt = i

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
    ''' TuvOêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
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

            gintTuvOCnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure


            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            TuvOArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve TuvOArray(i)

                    'O[oÏÉZbg
                    TuvOArray(i).intTuvOR[h = OraDr.GetInt32(0)
                    TuvOArray(i).strTuvO¼ = OraDr.GetString(1)

                    i += 1

                End While

                gintTuvOCnt = i

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
    ''' óeLXgæ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintæf[^Cnt - 1)

            For i = 0 To gintæf[^Cnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintæf[^Cnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' AptagepÄpóf[^ì¬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lngì¬SÒR[h">ì¬SÒR[h</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_¾Óæîñ">¾Óæîñißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0101_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lngì¬SÒR[h As Long,
                                             ByVal PI_intæÔ As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_¾Óæîñ As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 80, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lngì¬SÒR[h
            PI_03.Value = PI_intæÔ
            PI_04.Value = PI_intSubProgram_ID

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_¾Óæîñ = PO_01.Value.ToString
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' G[f[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0101_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_intæÔ


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' G[f[^oÍÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorExportDataCnt = 0 Then
                DLTP0101_PROC0012 = 0
                Exit Function
            End If

            ReDim ID(gintErrorExportDataCnt - 1)

            For i = 0 To gintErrorExportDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorExportDataCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = gintErrorExportDataCnt
            PI_03.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' MpG[f[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0101_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_intæÔ

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' MpG[f[^oÍÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorSendDataCnt = 0 Then
                DLTP0101_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintErrorSendDataCnt - 1)

            For i = 0 To gintErrorSendDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorSendDataCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = gintErrorSendDataCnt
            PI_03.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' o×i¢®¹f[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ZbVîñí
    ''' </summary>
    ''' <param name="strProgram_ID">vO_ID</param>
    ''' <param name="strVæª">DLTZbVîñ.Væª</param>
    ''' <param name="intNæª">DLTZbVîñ.Næª</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
    Public Shared Function DLTP0998S_PROC0013(ByVal strProgram_ID As String,
                                              ByVal strVæª As String,
                                              ByVal intNæª As Integer) As Integer


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

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0013"
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
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

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_99 = Oracmd.Parameters.Add("PO_99", OracleDbType.Int32, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = "DELETE"
            PI_02.Value = strProgram_ID
            PI_03.Value = strVæª
            PI_04.Value = intNæª
            PI_05.Value = vbNullString
            PI_06.Value = vbNullString
            PI_07.Value = vbNullString
            PI_08.Value = vbNullString
            PI_09.Value = vbNullString
            PI_10.Value = vbNullString
            PI_11.Value = vbNullString

            'XgAhvV[Wcall
            Oracmd.ExecuteNonQuery()

            '^[R[hÅÌUèª¯
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
    ''' sbLOAgf[^ì¬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' sbLOAgf[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ª[f[^õf[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' sbLOAgf[^õ(EXCELp)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' LøúÀØf[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngùvæR[h">ùvæR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0201_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngùvæR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lngùvæR[h


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' sbLOAgf[^oÍÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = Results(i).strBuff(0)
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ª[f[^oÍÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(18))
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' LøúÀØf[^oÍÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 8, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0023 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(20))
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    '''f[^ì¬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    '''  ÀÑMpf[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intMæª"> 0EEMp,9EEG[oÍp</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0302_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intMæª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_intMæª

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' MÊð³Ée[uðXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intMæª">0EEMp,9EEG[oÍp</param>
    ''' <param name="PI_intResult">1EE¬÷ 9E¥¸s</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
    Public Shared Function DLTP0302_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intMæª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0302_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(1))
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'CvbglÝè
            PI_01.Value = ID
            PI_02.Value = PI_intMæª
            PI_03.Value = gintResultCnt
            PI_04.Value = PI_intResult

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' AptagepÄpóf[^ì¬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lngì¬SÒR[h">ì¬SÒR[h</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0103_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lngì¬SÒR[h As Long,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lngì¬SÒR[h
            PI_03.Value = PI_intæÔ
            PI_04.Value = PI_intSubProgram_ID

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' Ê\¦pÎÛ¾Óæêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0103_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005


            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_intæÔ


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Ê\¦p¾ÓæêArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve Ê\¦p¾ÓæêArray(RowCnt)

                    If OraDr.IsDBNull(0) = False Then
                        Ê\¦p¾ÓæêArray(RowCnt).strRecData = ""
                        Ê\¦p¾ÓæêArray(RowCnt).strRecData = CType(OraDr.GetValue(0), String)
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
    ''' OliverEANeLXgæ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintæf[^Cnt - 1)

            For i = 0 To gintæf[^Cnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintæf[^Cnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0
            PI_04.Value = gintæf[^Cnt

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' OliverG[f[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_Îú">ÎÛú</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0301_PROC0010(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_Îú As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_Îú.Trim

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' OliverEANf[^õ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ·úÝoÔîñoÍ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_ùvæR[h">ùvæR[h</param>
    ''' <param name="PI_oÍæª">0EEÝoÌÝA1EES</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0301_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_ùvæR[h As Long,
                                             ByVal PI_oÍæª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            If PI_ùvæR[h = 0 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_ùvæR[h
            End If
            PI_04.Value = PI_oÍæª

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' LøúÀØio×¾×oÍ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_ÎÛú">ÎÛú</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0301_PROC0016(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_ÎÛú As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_ÎÛú.Trim

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' Ìp¤iîñæ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintExcelDataCnt - 1)

            For i = 0 To gintExcelDataCnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintExcelDataCnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ¿f[^æ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="strÎÛú">ÎÛú</param>
    ''' <param name="str\[X">\[X</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0401_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal strÎÛú As String,
                                             ByVal str\[X As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintæf[^Cnt - 1)

            For i = 0 To gintæf[^Cnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintæf[^Cnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = str\[X.Trim
            PI_05.Value = strÎÛú.Trim

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ¿îñG[îñõ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ¿îñ`FbNÊoÍ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_f[^æª">f[^íÊ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0401_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_f[^æª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_f[^æª, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_f[^æª, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_f[^æª


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ¿îñG[îñõ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_str[¼">[¼</param>
    ''' <param name="PI_intSESSION_ID">ZbVID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0402_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str[¼ As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_str[¼
            PI_02.Value = PI_intSESSION_ID


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ¿f[^æ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="strÎÛú">ÎÛú</param>
    ''' <param name="PI_objÆR[h">ÆR[h</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PI_intõÎÛ">õÎÛ</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_str[¼">[¼ißlj</param>
    ''' <param name="PO_intOraSessionID">ZbVIDißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0402_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal strÎÛú As String,
                                             ByVal PI_objÆR[h As Object,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByVal PI_intõÎÛ As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_str[¼ As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintæf[^Cnt - 1)

            For i = 0 To gintæf[^Cnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Int32, ParameterDirection.Output)
            PO_07 = Oracmd.Parameters.Add("PO_07", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintæf[^Cnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = strÎÛú.Trim
            PI_05.Value = PI_objÆR[h
            PI_06.Value = PI_lng¾ÓæR[h
            PI_07.Value = PI_intõÎÛ

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_str[¼ = PO_04.Value.ToString
            PO_intOraSessionID = CType(PO_05.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_06.Value.ToString, Integer)
            PO_strSQLERRM = PO_07.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ¿îñ`FbNÊoÍ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_str[¼">[¼</param>
    ''' <param name="PI_intOraSessionID">ZbVID</param>
    ''' <param name="PI_f[^æª">f[^æª</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0402_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str[¼ As String,
                                             ByVal PI_intOraSessionID As Integer,
                                             ByVal PI_f[^æª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_f[^æª, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_f[^æª, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_str[¼
            PI_02.Value = PI_intOraSessionID
            PI_03.Value = PI_f[^æª


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' ÌÂØ¶ÝmF
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PI_intÂØæª">ÂØæª</param>
    ''' <param name="PI_intútl¶">útl¶     -- 0EEÌÂI¹úðl¶·éA1EEµÈ¢</param>
    ''' <returns>0 -- f[^Èµ 1 -- f[^ è 9 -- G[</returns>
    Public Shared Function DLTP0503_FUNC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByVal PI_intÂØæª As Integer,
                                             ByVal PI_intútl¶ As Integer) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim strPROC As String

        Try

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'AEgvbgp[^Ýè(FUNCTIONÍêÔÅÉp[^Ýè)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_lng¾ÓæR[h
            PI_02.Value = PI_intÂØæª
            PI_03.Value = PI_intútl¶

            'XgAhvV[Wcall
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
    ''' ÌÂØo^
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode"> SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_øpæª">0EEøpµÈ¢A1EEøp·é</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PI_lngøp³¾ÓæR[h">øp³¾ÓæR[h</param>
    ''' <param name="PI_strÌÂØÔ">ÌÂØÔ</param>
    ''' <param name="PI_strÌÂJnút">ÌÂJnút</param>
    ''' <param name="PI_strÌÂI¹út">ÌÂI¹út</param>
    ''' <param name="PI_intÂØæª">ÂØæª</param>
    ''' <param name="PI_intæt@C">ÂØt@C</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 1 -- øp·éÌÉAøp³Èµ 9 -- ÙíI¹</returns>
    Public Shared Function DLTP0503_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_øpæª As Integer,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByVal PI_lngøp³¾ÓæR[h As Long,
                                             ByVal PI_strÌÂØÔ As String,
                                             ByVal PI_strÌÂJnút As String,
                                             ByVal PI_strÌÂI¹út As String,
                                             ByVal PI_intÂØæª As Integer,
                                             ByVal PI_intæt@C As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Blob, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_øpæª
            PI_02.Value = PI_lng¾ÓæR[h
            PI_03.Value = PI_lngøp³¾ÓæR[h
            PI_04.Value = PI_strÌÂØÔ
            PI_05.Value = PI_strÌÂJnút
            PI_06.Value = PI_strÌÂI¹út
            PI_07.Value = PI_intÂØæª
            If PI_øpæª = 0 Then
                If Chk_FileExists(PI_intæt@C) = True Then
                    Dim fs As New IO.FileStream(PI_intæt@C, IO.FileMode.Open, IO.FileAccess.Read)
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

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
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
    ''' PHsmosãÃ@Öêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
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

            gintPHsmosãÃ@ÖCnt = 0

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.ÆR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            PHsmosãÃ@ÖArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve PHsmosãÃ@ÖArray(i)

                    'O[oÏÉZbg
                    PHsmosãÃ@ÖArray(i).strãÃ@ÖR[h = OraDr.GetString(0)
                    PHsmosãÃ@ÖArray(i).strãÃ@Ö¼ = OraDr.GetString(1)
                    i += 1

                End While

                gintPHsmosãÃ@ÖCnt = i

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
    ''' PHsmosÌp¤iîñoÍ
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_strãÃ@ÖR[h">ãÃ@ÖR[h</param>
    ''' <param name="PI_ÎÛút">¾¤/ù¤XVút</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0505_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_strãÃ@ÖR[h As String,
                                             ByVal PI_ÎÛút As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_strãÃ@ÖR[h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_ÎÛút

            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' Ú«êæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PI_Ú¼">Ú«}X^.Ú¼</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0901_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_Ú¼ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0005 = False

            gint¼Ì«Cnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_Ú¼

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Ú«Array = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve Ú«Array(i)

                    'O[oÏÉZbg
                    Ú«Array(i).intR[h = OraDr.GetInt32(0)
                    Ú«Array(i).str¼Ì = OraDr.GetString(1)
                    i += 1

                End While

                gintÚ«Cnt = i

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
    ''' ¼Ì«êæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_IDi¢gpj</param>
    ''' <param name="PI_Ú¼">¼Ì«}X^.Ú¼</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
    Public Shared Function DLTP0901_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_Ú¼ As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0004 = False

            gint¼Ì«Cnt = 0

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_Ú¼

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ¼Ì«Array = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve ¼Ì«Array(i)

                    'O[oÏÉZbg
                    ¼Ì«Array(i).strR[h = OraDr.GetString(0)
                    ¼Ì«Array(i).str¼Ì = OraDr.GetString(1)
                    i += 1

                End While

                gint¼Ì«Cnt = i

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
    ''' ·úÝoÔîñæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lng·úÝoÔ">·úÝoÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
    Public Shared Function DLTP0301_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng·úÝoÔ As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng·úÝoÔ

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            gudt·úÝoÔîñ.IsClear()

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '^[R[hÅÌUèª¯
            Select Case PO_intSQLCODE

                Case 0

                    OraDr.Read()

                    If OraDr.IsDBNull(0) = False Then gudt·úÝoÔîñ.lng·úÝoÔ = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then gudt·úÝoÔîñ.stro×ú = CStr(OraDr.GetValue(1))
                    If OraDr.IsDBNull(2) = False Then gudt·úÝoÔîñ.stró`Ô = OraDr.GetString(2)
                    If OraDr.IsDBNull(3) = False Then gudt·úÝoÔîñ.strùvæ¼ = OraDr.GetString(3)
                    If OraDr.IsDBNull(4) = False Then gudt·úÝoÔîñ.strùvæ¼ = OraDr.GetString(4)
                    If OraDr.IsDBNull(5) = False Then gudt·úÝoÔîñ.str¤iR[h = OraDr.GetString(5)
                    If OraDr.IsDBNull(6) = False Then gudt·úÝoÔîñ.str[J¼ = OraDr.GetString(6)
                    If OraDr.IsDBNull(7) = False Then gudt·úÝoÔîñ.str[JiÔ = OraDr.GetString(7)
                    If OraDr.IsDBNull(8) = False Then gudt·úÝoÔîñ.str¤i¼ = OraDr.GetString(8)
                    If OraDr.IsDBNull(9) = False Then gudt·úÝoÔîñ.strKi = OraDr.GetString(9)
                    If OraDr.IsDBNull(10) = False Then gudt·úÝoÔîñ.strLøúÀ = CStr(OraDr.GetValue(10))
                    If OraDr.IsDBNull(11) = False Then gudt·úÝoÔîñ.strbg = OraDr.GetString(11)
                    If OraDr.IsDBNull(12) = False Then gudt·úÝoÔîñ.strVA = OraDr.GetString(12)
                    If OraDr.IsDBNull(13) = False Then gudt·úÝoÔîñ.lngo×Ê = CLng(OraDr.GetDouble(13))
                    If OraDr.IsDBNull(14) = False Then gudt·úÝoÔîñ.stro×PÊ¼ = OraDr.GetString(14)
                    If OraDr.IsDBNull(15) = False Then gudt·úÝoÔîñ.strÁïú = CStr(OraDr.GetValue(15))
                    If OraDr.IsDBNull(16) = False Then gudt·úÝoÔîñ.strÁïùvæ¼ = OraDr.GetString(16)
                    If OraDr.IsDBNull(17) = False Then gudt·úÝoÔîñ.strÁïùvæ¼ = OraDr.GetString(17)
                    If OraDr.IsDBNull(18) = False Then gudt·úÝoÔîñ.strÔpú = CStr(OraDr.GetValue(18))

                Case 2

                    DLTP0301_PROC0014 = 2
                    OraTran.Rollback()
                    Exit Function

                Case -54 'NOWAIT rW[

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
    ''' ·úÝoÔîñXV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lng·úÝoÔ">·úÝoÔ</param>
    ''' <param name="PI_strÁú">Áú</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
    Public Shared Function DLTP0301_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng·úÝoÔ As Long,
                                             ByVal PI_strÁú As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng·úÝoÔ
            PI_04.Value = PI_strÁú

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
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
    ''' ¾ÓæÊÌÂØeiX(¾Óæõ)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lng¾ÓæR[h">¾ÓæR[h</param>
    ''' <param name="PI_strÆíR[h">ÆíR[h</param>
    ''' <param name="PI_intÂØæª">ÂØæª</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
    Public Shared Function DLTP0504_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng¾ÓæR[h As Long,
                                             ByVal PI_strÆíR[h As String,
                                             ByVal PI_intÂØæª As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            If PI_lng¾ÓæR[h = DUMMY_LNGCODE Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_lng¾ÓæR[h
            End If
            If IsNull(PI_strÆíR[h) Then
                PI_02.Value = vbNullString
            Else
                PI_02.Value = PI_strÆíR[h
            End If
            If PI_intÂØæª = 7 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_intÂØæª
            End If

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '^[R[hÅÌUèª¯
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

                Case -54 'NOWAIT rW[

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
    ''' ¾ÓæÊÌÂØeiX(ðõ)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_strÆíR[h">ÆíR[h</param>
    ''' <param name="PI_intÂØæª">ÂØæª</param>
    ''' <param name="PI_ð">ð</param>
    ''' <param name="PI_I¹út">I¹út</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
    Public Shared Function DLTP0504_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_strÆíR[h As String,
                                             ByVal PI_intÂØæª As Integer,
                                             ByVal PI_ð As Integer,
                                             ByVal PI_I¹út As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)


            'CvbglÝè
            If IsNull(PI_strÆíR[h) Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_strÆíR[h
            End If
            PI_02.Value = PI_intÂØæª
            PI_03.Value = PI_ð
            If PI_ð = 2 Then
                PI_04.Value = PI_I¹út
            Else
                PI_04.Value = vbNullString
            End If

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '^[R[hÅÌUèª¯
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

                Case -54 'NOWAIT rW[

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
    ''' ¾ÓæÊÌÂØeiX(í)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_">í</param>
    ''' <param name="PI_Results">DLTÌÂØÇîñ_ID_Array</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹ 9 -- G[</returns>
    Public Shared Function DLTP0504_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = PI_

            'CvbglÝè
            PI_01.Value = PI_Results
            PI_02.Value = PI_

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ¾ÓæÊÌÂØeiX(ææ¾)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lngID">DLTÌÂØÇîñ_ID</param>
    ''' <param name="PO_Img">æißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure


            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_lngID

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ó`ÔeiX¤iîñæ¾æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_str¤iR[h">¤iR[h</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹ </returns>
    Public Shared Function DLTP0301_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str¤iR[h As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.ÆR[h
            PI_04.Value = PI_str¤iR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '^[R[hÅÌUèª¯
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
    ''' ó`ÔeiX¤iîñæ¾æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_str¤iR[h">¤iR[h</param>
    ''' <param name="PI_strSPD¤iR[h">SPD¤iR[h</param>
    ''' <param name="PI_intó`Ô">ó`Ô</param>
    ''' <param name="PI_into×Ag">o×Ag</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íI¹A2 -- f[^ÈµA9 -- ÙíI¹</returns>
    Public Shared Function DLTP0301_PROC0022(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str¤iR[h As String,
                                             ByVal PI_strSPD¤iR[h As String,
                                             ByVal PI_intó`Ô As Integer,
                                             ByVal PI_into×Ag As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.ÆR[h
            PI_04.Value = PI_str¤iR[h
            PI_05.Value = PI_strSPD¤iR[h
            PI_06.Value = PI_intó`Ô
            PI_07.Value = PI_into×Ag

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
            If Math.Abs(PO_intSQLCODE) > 0 Then
                OraTran.Rollback()
                log.Error(Set_ErrMSG(PO_intSQLCODE, PO_strSQLERRM))
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
    ''' óeLXgæ`FbN
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lngüÍSR[h">üÍSR[h</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0106_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lngüÍSR[h As Long,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintæf[^Cnt - 1)

            For i = 0 To gintæf[^Cnt - 1
                Data(i) = æf[^Array(i).strRecData
            Next

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int64, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintæf[^Cnt

            'CvbglÝè
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_lngüÍSR[h
            PI_05.Value = My.Settings.ÆR[h

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' AptagepÄpóf[^ì¬
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_lngì¬SÒR[h">ì¬SÒR[h</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0106_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lngì¬SÒR[h As Long,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lngì¬SÒR[h
            PI_03.Value = PI_intæÔ
            PI_04.Value = PI_intSubProgram_ID

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ¾Óæêæ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íæ¾ False -- G[</returns>
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

            gint¾ÓæCnt = 0

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.ÆR[h

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            ¾ÓæArray = Nothing

            '^[R[hÅÌUèª¯
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'Äæ¾
                    ReDim Preserve ¾ÓæArray(i)

                    'O[oÏÉZbg
                    ¾ÓæArray(i).lng¾ÓæR[h = OraDr.GetInt64(0)
                    ¾ÓæArray(i).str¾Óæ¼ = OraDr.GetString(1)
                    i += 1

                End While

                gint¾ÓæCnt = i

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
    ''' `p[iîñì¬(¿Fï[iÀÑM)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lng|æR[h">|æR[h</param>
    ''' <param name="PI_txtÎÛJnú">ÎÛJnú</param>
    ''' <param name="PI_txtÎÛI¹ú">ÎÛI¹ú</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0304_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng|æR[h As Long,
                                             ByVal PI_txtÎÛJnú As String,
                                             ByVal PI_txtÎÛI¹ú As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txtÎÛJnú.Trim
            PI_05.Value = PI_txtÎÛI¹ú.Trim
            If PI_lng|æR[h = 0 Then
                PI_06.Value = vbNullString
            Else
                PI_06.Value = PI_lng|æR[h
            End If

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' `p[iîñf[^õ(¿Fï[iÀÑM)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0304_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.ÆR[h
            PI_04.Value = PI_intæÔ


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' `p¿Óîñì¬(¿Fï¿îñ`)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_lng|æR[h">|æR[h</param>
    ''' <param name="PI_txt¿÷ú">¿÷ú</param>
    ''' <param name="PO_intNo">æÔißlj</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0403_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng|æR[h As Long,
                                             ByVal PI_txt¿÷ú As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int64, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt¿÷ú.Trim
            If PI_lng|æR[h = 0 Then
                PI_05.Value = vbNullString
            Else
                PI_05.Value = PI_lng|æR[h
            End If

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' `p¿¾×îñì¬(¿Fï¿îñ`)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_æÔ">æÔ</param>
    ''' <param name="PO_intCnt0">ÎÛißlj</param>
    ''' <param name="PO_intCnt1">³íißlj</param>
    ''' <param name="PO_intCnt2">G[ißlj</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 9 -- G[</returns>
    Public Shared Function DLTP0403_PROC0101(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_æÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'CvbglÝè
            PI_01.Value = My.Settings.ÆR[h
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_æÔ

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' `p¿Óîñf[^õ(¿Fï¿îñ`)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0403_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.ÆR[h
            PI_04.Value = PI_intæÔ


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' `p¿¾×îñf[^õ(¿Fï¿îñ`)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDVXeR[h</param>
    ''' <param name="PI_intSubProgram_ID">TuvO_ID</param>
    ''' <param name="PI_intæÔ">æÔ</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0403_PROC0201(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intæÔ As Integer,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.ÆR[h
            PI_04.Value = PI_intæÔ


            'AEgvbgp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[Wcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            '^[R[hÅÌUèª¯
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
    ''' OCîñXV
    ''' </summary>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj</param>
    ''' <returns>True -- ³íI¹ 9 -- G[</returns>
    Public Shared Function DLTP0000_PROC0006(ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0000_PROC0006 = False

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0006"
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = Get_MachineName()
            PI_02.Value = My.Application.Info.Version

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
    ''' ª[f[^æ¾
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPDVXeR[h</param>
    ''' <param name="PI_intSPDSystemcode">TuvO_ID</param>
    ''' <param name="PI_strAgL[">Ag[</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj></param>
    ''' <returns>0 -- ³íæ¾ 2 -- R[h³ 9 -- G[</returns>
    Public Shared Function DLTP0301_PROC0023(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_strAgL[ As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'Úæ¾
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "Ú")
            ColMax = gintDLTP0997S_FUNC004

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_strAgL[

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            '^[R[hÅÌUèª¯
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
    ''' ª[f[^XV
    ''' </summary>
    ''' <param name="PI_strProgram_ID">vO_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPDVXeR[h</param>
    ''' <param name="PI_intSPDSystemcode">TuvO_ID</param>
    ''' <param name="PI_strAgL[">Ag[</param>
    ''' <param name="PO_intSQLCODE">OracleG[R[hißlj</param>
    ''' <param name="PO_strSQLERRM">OracleG[bZ[Wißlj></param>
    ''' <returns>TrueEE³íI¹AFalseEEÙíI¹</returns>
    Public Shared Function DLTP0301_PROC0024(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_strAgL[ As String,
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

            'vO_IDæ¾
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "Ö")
            strPROC = gstrDLTP0997S_FUNC005

            'XgAhvV[WÝè
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'Cvbgp[^Ýè
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'CvbglÝè
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_strAgL[

            'Outputp[^Ýè
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'XgAhvV[WCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            '^[R[hÅÌUèª¯
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
End Class
