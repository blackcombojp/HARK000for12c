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
    ''' Oracle接続処理
    ''' </summary>
    ''' <returns>True・・成功、false・・失敗</returns>
    Public Shared Function OraConnect() As Boolean

        Dim StrParam As String

        Try

            OraConnect = False

            'StrParam = "User id=" & My.Settings.DBユーザ & ";" & "Password=" & My.Settings.DBパスワード & ";" & "Data Source=" & My.Settings.DB接続文字列
            StrParam = "User id=" & My.Settings.DBユーザ & ";" & "Password=" & My.Settings.DBパスワード & ";" & "Data Source=" & My.Settings.DB接続文字列 & ";" & "Connection Timeout=5;Pooling=false;"

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
    ''' Oracle切断処理
    ''' </summary>
    ''' <returns>True・・成功、false・・失敗</returns>
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
    ''' トランザクションコミット
    ''' </summary>
    ''' <returns>True・・正常、false・・異常</returns>
    Public Shared Function OraTrnCommit() As Boolean

        Try

            OraTrnCommit = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0091"
            Oracmd.CommandType = CommandType.StoredProcedure

            'ストアドプロシージャCall
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
    ''' トランザクションロールバック
    ''' </summary>
    ''' <returns>True・・正常、false・・異常</returns>
    Public Shared Function OraTrnRollBack() As Boolean

        Try

            OraTrnRollBack = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0090"
            Oracmd.CommandType = CommandType.StoredProcedure

            'ストアドプロシージャCall
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
    ''' Oracle接続状態確認
    ''' </summary>
    ''' <param name="PO_intOraSessionID">セッションID（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True・・接続中、false・・切断</returns>
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

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_03.Value.ToString)
            PO_strSQLERRM = PO_04.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 担当者名取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PI_lng入力担当コード">入力担当コード</param>
    ''' <param name="PI_obj事業所コード">事業所コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0900_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng入力担当コード As Long,
                                             ByVal PI_obj事業所コード As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0001 = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_lng入力担当コード
            PI_02.Value = PI_obj事業所コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 30, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr担当者名 = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                gstr担当者名 = PO_01.Value.ToString

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
    ''' 部門名取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0900_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0002 = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr部門名 = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                gstr部門名 = PO_01.Value.ToString

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
    ''' 得意先名取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PI_obj事業所コード">事業所コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0900_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng得意先コード As Long,
                                             ByVal PI_obj事業所コード As Object,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0003 = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_obj事業所コード
            PI_02.Value = PI_lng得意先コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr得意先名 = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                gstr得意先名 = PO_01.Value.ToString

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
    ''' 得意先名取得(所轄事業所チェック無し)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0900_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_lng得意先コード As Long,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Try
            DLTP0900_PROC0004 = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0900.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_lng得意先コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 60, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gstr得意先名 = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                gstr得意先名 = PO_01.Value.ToString

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
    ''' 事業所一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0901_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0001 = False

            gint事業所Cnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            事業所Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 事業所Array(i)

                    'グローバル変数にセット
                    事業所Array(i).int事業所コード = OraDr.GetInt32(0)
                    事業所Array(i).str事業所名 = OraDr.GetString(1)
                    i += 1

                End While

                gint事業所Cnt = i

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
    ''' SPDシステムコード取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
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

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_strProgram_ID

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 100, DBNull.Value, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_04.Value.ToString)
            PO_strSQLERRM = PO_05.Value.ToString

            gintSPDシステムコード = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                gintSPDシステムコード = CInt(PO_01.Value.ToString)
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
    ''' プログラム処理可否確認
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0・・不可、1・・可</returns>
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

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0003"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()
            PI_04.Value = My.Application.Info.Version

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 処理端末情報取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
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

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_strProgram_ID
            PI_03.Value = Get_MachineName()

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            gudt処理端末情報.IsClear()

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                OraDr.Read()

                If OraDr.IsDBNull(0) = False Then gudt処理端末情報.str出力先１ = OraDr.GetString(0)
                If OraDr.IsDBNull(1) = False Then gudt処理端末情報.str出力先２ = OraDr.GetString(1)
                If OraDr.IsDBNull(2) = False Then gudt処理端末情報.str出力先３ = OraDr.GetString(2)
                If OraDr.IsDBNull(3) = False Then gudt処理端末情報.str出力先４ = OraDr.GetString(3)
                If OraDr.IsDBNull(4) = False Then gudt処理端末情報.str出力先５ = OraDr.GetString(4)

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
    ''' 掲示版一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0000_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0000_PROC0011 = False

            gint掲示版Cnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0011"
            Oracmd.CommandType = CommandType.StoredProcedure

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            掲示板Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 掲示板Array(i)

                    'グローバル変数にセット
                    掲示板Array(i).str掲示情報 = OraDr.GetString(0)
                    i += 1

                End While

                gint掲示版Cnt = i

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
    ''' DLTプログラム個別情報VARCHAR型情報取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int管理区分">管理区分</param>
    ''' <param name="PI_int処理区分">処理区分</param>
    ''' <param name="PI_strImputName">項目名</param>
    ''' <returns>0 -- データあり 2 -- データなし</returns>
    Public Shared Function DLTP0997S_FUNC005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int管理区分 As Integer,
                                             ByVal PI_int処理区分 As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'アウトプットパラメータ設定(FUNCTIONは一番最初にパラメータ設定)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.ReturnValue)

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int管理区分
            PI_05.Value = PI_int処理区分
            PI_06.Value = PI_strImputName.Trim

            'ストアドプロシージャcall
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
    ''' DLTプログラム個別情報NUMBER型情報取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int管理区分">管理区分</param>
    ''' <param name="PI_int処理区分">処理区分</param>
    ''' <param name="PI_strImputName">項目名</param>
    ''' <returns>0 -- データあり 2 -- データなし</returns>
    Public Shared Function DLTP0997S_FUNC004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int管理区分 As Integer,
                                             ByVal PI_int処理区分 As Integer,
                                             ByVal PI_strImputName As String) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PI_04 As OracleParameter
        Dim PI_05 As OracleParameter
        Dim PI_06 As OracleParameter
        Dim PO_01 As OracleParameter

        Try
            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.FUNC004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'アウトプットパラメータ設定(FUNCTIONは一番最初にパラメータ設定)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int管理区分
            PI_05.Value = PI_int処理区分
            PI_06.Value = PI_strImputName.Trim

            'ストアドプロシージャcall
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
    ''' プログラム個別情報(得意先)一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int管理区分">管理区分</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0997S_PROC0001(ByVal PI_strProgram_ID As String,
                                              ByVal PI_intSPDSystemcode As Integer,
                                              ByVal PI_intSubProgram_ID As Integer,
                                              ByVal PI_int管理区分 As Integer,
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

            gint需要先Cnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0997S.PROC0001"
            Oracmd.CommandType = CommandType.StoredProcedure


            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_int管理区分

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            需要先Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 需要先Array(i)

                    'グローバル変数にセット
                    If OraDr.IsDBNull(0) = False Then 需要先Array(i).lng需要先コード = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then 需要先Array(i).str需要先名 = OraDr.GetString(1)

                    i += 1

                End While

                gint需要先Cnt = i

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
    ''' サブプログラム一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
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

            gintサブプログラムCnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0002"
            Oracmd.CommandType = CommandType.StoredProcedure


            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_strProgram_ID.Trim
            PI_02.Value = PI_intSPDSystemcode

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            サブプログラムArray = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve サブプログラムArray(i)

                    'グローバル変数にセット
                    サブプログラムArray(i).intサブプログラムコード = OraDr.GetInt32(0)
                    サブプログラムArray(i).strサブプログラム名 = OraDr.GetString(1)

                    i += 1

                End While

                gintサブプログラムCnt = i

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
    ''' 受注テキスト取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' Aptage用汎用受注データ作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng作成担当者コード">作成担当者コード</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_得意先情報">得意先情報（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0101_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng作成担当者コード As Long,
                                             ByVal PI_int取込番号 As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByRef PO_得意先情報 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 80, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng作成担当者コード
            PI_03.Value = PI_int取込番号
            PI_04.Value = PI_intSubProgram_ID

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_得意先情報 = PO_01.Value.ToString
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' エラーデータ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0101_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' エラーデータ出力結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorExportDataCnt = 0 Then
                DLTP0101_PROC0012 = 0
                Exit Function
            End If

            ReDim ID(gintErrorExportDataCnt - 1)

            For i = 0 To gintErrorExportDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorExportDataCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = gintErrorExportDataCnt
            PI_03.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 送信用エラーデータ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0101_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int取込番号

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 送信用エラーデータ出力結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintErrorSendDataCnt = 0 Then
                DLTP0101_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintErrorSendDataCnt - 1)

            For i = 0 To gintErrorSendDataCnt - 1
                ID(i) = CInt(Results(i).strBuff(0))
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintErrorSendDataCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = gintErrorSendDataCnt
            PI_03.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 出荷検品未完了データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' セッション情報削除
    ''' </summary>
    ''' <param name="strProgram_ID">プログラム_ID</param>
    ''' <param name="strV区分">DLTセッション情報.V区分</param>
    ''' <param name="intN区分">DLTセッション情報.N区分</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
    Public Shared Function DLTP0998S_PROC0013(ByVal strProgram_ID As String,
                                              ByVal strV区分 As String,
                                              ByVal intN区分 As Integer) As Integer


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

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0998S.PROC0013"
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
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

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_99 = Oracmd.Parameters.Add("PO_99", OracleDbType.Int32, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = "DELETE"
            PI_02.Value = strProgram_ID
            PI_03.Value = strV区分
            PI_04.Value = intN区分
            PI_05.Value = vbNullString
            PI_06.Value = vbNullString
            PI_07.Value = vbNullString
            PI_08.Value = vbNullString
            PI_09.Value = vbNullString
            PI_10.Value = vbNullString
            PI_11.Value = vbNullString

            'ストアドプロシージャcall
            Oracmd.ExecuteNonQuery()

            'リターンコードでの処理振り分け
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
    ''' ピッキング連携データ作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' ピッキング連携データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 分納データ検索データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' ピッキング連携データ検索(EXCEL用)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 6, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 有効期限切迫データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0201_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 7, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng需要先コード


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' ピッキング連携データ出力結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = Results(i).strBuff(0)
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 分納データ出力結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0022 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(18))
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 有効期限切迫データ出力結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 8, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0201_PROC0023 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(20))
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = gintResultCnt
            PI_03.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    '''データ作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    '''  実績送信用データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int送信区分"> 0・・送信用,9・・エラー出力用</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0302_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int送信区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int送信区分

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 送信結果を元にテーブルを更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int送信区分">0・・送信用,9・・エラー出力用</param>
    ''' <param name="PI_intResult">1・・成功 9・･失敗</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
    Public Shared Function DLTP0302_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int送信区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            If gintResultCnt = 0 Then
                DLTP0302_PROC0021 = 0
                Exit Function
            End If

            ReDim ID(gintResultCnt - 1)

            For i = 0 To gintResultCnt - 1
                ID(i) = CInt(Results(i).strBuff(1))
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintResultCnt

            'インプット値設定
            PI_01.Value = ID
            PI_02.Value = PI_int送信区分
            PI_03.Value = gintResultCnt
            PI_04.Value = PI_intResult

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' Aptage用汎用受注データ作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng作成担当者コード">作成担当者コード</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0103_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng作成担当者コード As Long,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng作成担当者コード
            PI_03.Value = PI_int取込番号
            PI_04.Value = PI_intSubProgram_ID

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 結果表示用対象得意先一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0103_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005


            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            結果表示用得意先一覧Array = Nothing

            'リターンコードでの振り分け
            If PO_intSQLCODE = 0 Then

                RowCnt = 0

                While OraDr.Read

                    ReDim Preserve 結果表示用得意先一覧Array(RowCnt)

                    If OraDr.IsDBNull(0) = False Then
                        結果表示用得意先一覧Array(RowCnt).strRecData = ""
                        結果表示用得意先一覧Array(RowCnt).strRecData = CType(OraDr.GetValue(0), String)
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
    ''' OliverEANテキスト取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0
            PI_04.Value = gint取込データCnt

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' Oliverエラーデータ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_対処日">対象日</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0301_PROC0010(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_対処日 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_対処日.Trim

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' OliverEANデータ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 長期貸出番号情報出力
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_需要先コード">需要先コード</param>
    ''' <param name="PI_出力区分">0・・貸出中のみ、1・・全件</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0301_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_需要先コード As Long,
                                             ByVal PI_出力区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            If PI_需要先コード = 0 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_需要先コード
            End If
            PI_04.Value = PI_出力区分

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 部署マスタ出力（羅針盤用）/棚卸対象データ出力（羅針盤用）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_需要先コード">需要先コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0301_PROC0025(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_需要先コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_需要先コード

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 有効期限切迫品出荷明細出力
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_対象日">対象日</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0301_PROC0016(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_対象日 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_対象日.Trim

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 採用商品情報取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gintExcelDataCnt - 1)

            For i = 0 To gintExcelDataCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintExcelDataCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 請求データ取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="str対象日">対象日</param>
    ''' <param name="strソース">ソース</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0401_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal str対象日 As String,
                                             ByVal strソース As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = strソース.Trim
            PI_05.Value = str対象日.Trim

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 請求情報エラー情報検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 請求情報チェック結果出力
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_データ区分">データ種別</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0401_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_データ区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_データ区分, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 1, PI_データ区分, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_データ区分


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 請求情報エラー情報検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_str端末名">端末名</param>
    ''' <param name="PI_intSESSION_ID">セッションID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0402_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str端末名 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_str端末名
            PI_02.Value = PI_intSESSION_ID


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 請求データ取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="str対象日">対象日</param>
    ''' <param name="PI_obj事業所コード">事業所コード</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PI_int検索対象">検索対象</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_str端末名">端末名（戻値）</param>
    ''' <param name="PO_intOraSessionID">セッションID（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0402_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal str対象日 As String,
                                             ByVal PI_obj事業所コード As Object,
                                             ByVal PI_lng得意先コード As Long,
                                             ByVal PI_int検索対象 As Integer,
                                             ByRef PO_intCnt0 As Integer,
                                             ByRef PO_intCnt1 As Integer,
                                             ByRef PO_intCnt2 As Integer,
                                             ByRef PO_str端末名 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Int32, ParameterDirection.Output)
            PO_07 = Oracmd.Parameters.Add("PO_07", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = str対象日.Trim
            PI_05.Value = PI_obj事業所コード
            PI_06.Value = PI_lng得意先コード
            PI_07.Value = PI_int検索対象

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_str端末名 = PO_04.Value.ToString
            PO_intOraSessionID = CType(PO_05.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_06.Value.ToString, Integer)
            PO_strSQLERRM = PO_07.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 請求情報チェック結果出力
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_str端末名">端末名</param>
    ''' <param name="PI_intOraSessionID">セッションID</param>
    ''' <param name="PI_データ区分">データ区分</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0402_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str端末名 As String,
                                             ByVal PI_intOraSessionID As Integer,
                                             ByVal PI_データ区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_データ区分, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_データ区分, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_str端末名
            PI_02.Value = PI_intOraSessionID
            PI_03.Value = PI_データ区分


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 販売許可証存在確認
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PI_int許可証区分">許可証区分</param>
    ''' <param name="PI_int日付考慮">日付考慮     -- 0・・販売許可終了日を考慮する、1・・しない</param>
    ''' <returns>0 -- データなし 1 -- データあり 9 -- エラー</returns>
    Public Shared Function DLTP0503_FUNC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng得意先コード As Long,
                                             ByVal PI_int許可証区分 As Integer,
                                             ByVal PI_int日付考慮 As Integer) As Integer

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PI_03 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim strPROC As String

        Try

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'アウトプットパラメータ設定(FUNCTIONは一番最初にパラメータ設定)
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.ReturnValue)

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_lng得意先コード
            PI_02.Value = PI_int許可証区分
            PI_03.Value = PI_int日付考慮

            'ストアドプロシージャcall
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
    ''' 販売許可証登録
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode"> SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_引用区分">0・・引用しない、1・・引用する</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PI_lng引用元得意先コード">引用元得意先コード</param>
    ''' <param name="PI_str販売許可証番号">販売許可証番号</param>
    ''' <param name="PI_str販売許可開始日付">販売許可開始日付</param>
    ''' <param name="PI_str販売許可終了日付">販売許可終了日付</param>
    ''' <param name="PI_int許可証区分">許可証区分</param>
    ''' <param name="PI_int画像ファイル">許可証ファイル</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 1 -- 引用するのに、引用元なし 9 -- 異常終了</returns>
    Public Shared Function DLTP0503_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_引用区分 As Integer,
                                             ByVal PI_lng得意先コード As Long,
                                             ByVal PI_lng引用元得意先コード As Long,
                                             ByVal PI_str販売許可証番号 As String,
                                             ByVal PI_str販売許可開始日付 As String,
                                             ByVal PI_str販売許可終了日付 As String,
                                             ByVal PI_int許可証区分 As Integer,
                                             ByVal PI_int画像ファイル As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Blob, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_引用区分
            PI_02.Value = PI_lng得意先コード
            PI_03.Value = PI_lng引用元得意先コード
            PI_04.Value = PI_str販売許可証番号
            PI_05.Value = PI_str販売許可開始日付
            PI_06.Value = PI_str販売許可終了日付
            PI_07.Value = PI_int許可証区分
            If PI_引用区分 = 0 Then
                If Chk_FileExists(PI_int画像ファイル) = True Then
                    Dim fs As New IO.FileStream(PI_int画像ファイル, IO.FileMode.Open, IO.FileAccess.Read)
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

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
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
    ''' PHsmos医療機関一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
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

            gintPHsmos医療機関Cnt = 0

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            PHsmos医療機関Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve PHsmos医療機関Array(i)

                    'グローバル変数にセット
                    PHsmos医療機関Array(i).str医療機関コード = OraDr.GetString(0)
                    PHsmos医療機関Array(i).str医療機関名 = OraDr.GetString(1)
                    i += 1

                End While

                gintPHsmos医療機関Cnt = i

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
    ''' PHsmos採用商品情報出力
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_str医療機関コード">医療機関コード</param>
    ''' <param name="PI_対象日付">得商/需商更新日付</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0505_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str医療機関コード As String,
                                             ByVal PI_対象日付 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_str医療機関コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_対象日付

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 項目辞書一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PI_項目名">項目辞書マスタ.項目名</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0901_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_項目名 As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0005 = False

            gint名称辞書Cnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0005"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_項目名

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            項目辞書Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 項目辞書Array(i)

                    'グローバル変数にセット
                    項目辞書Array(i).intコード = OraDr.GetInt32(0)
                    項目辞書Array(i).str名称 = OraDr.GetString(1)
                    i += 1

                End While

                gint項目辞書Cnt = i

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
    ''' 名称辞書一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID（未使用）</param>
    ''' <param name="PI_項目名">名称辞書マスタ.項目名</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0901_PROC0004(ByVal PI_strProgram_ID As String,
                                             ByVal PI_項目名 As String,
                                             ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter
        Dim PO_03 As OracleParameter

        Dim i As Integer

        Try
            DLTP0901_PROC0004 = False

            gint名称辞書Cnt = 0

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0901.PROC0004"
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_項目名

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            名称辞書Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 名称辞書Array(i)

                    'グローバル変数にセット
                    名称辞書Array(i).strコード = OraDr.GetString(0)
                    名称辞書Array(i).str名称 = OraDr.GetString(1)
                    i += 1

                End While

                gint名称辞書Cnt = i

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
    ''' 長期貸出番号情報取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng長期貸出番号">長期貸出番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0301_PROC0014(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng長期貸出番号 As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng長期貸出番号

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            gudt長期貸出番号情報.IsClear()

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            'リターンコードでの処理振り分け
            Select Case PO_intSQLCODE

                Case 0

                    OraDr.Read()

                    If OraDr.IsDBNull(0) = False Then gudt長期貸出番号情報.lng長期貸出番号 = OraDr.GetInt64(0)
                    If OraDr.IsDBNull(1) = False Then gudt長期貸出番号情報.str出荷日 = CStr(OraDr.GetValue(1))
                    If OraDr.IsDBNull(2) = False Then gudt長期貸出番号情報.str受注形態 = OraDr.GetString(2)
                    If OraDr.IsDBNull(3) = False Then gudt長期貸出番号情報.str需要先名 = OraDr.GetString(3)
                    If OraDr.IsDBNull(4) = False Then gudt長期貸出番号情報.str需要先部署名 = OraDr.GetString(4)
                    If OraDr.IsDBNull(5) = False Then gudt長期貸出番号情報.str商品コード = OraDr.GetString(5)
                    If OraDr.IsDBNull(6) = False Then gudt長期貸出番号情報.strメーカ名 = OraDr.GetString(6)
                    If OraDr.IsDBNull(7) = False Then gudt長期貸出番号情報.strメーカ品番 = OraDr.GetString(7)
                    If OraDr.IsDBNull(8) = False Then gudt長期貸出番号情報.str商品名 = OraDr.GetString(8)
                    If OraDr.IsDBNull(9) = False Then gudt長期貸出番号情報.str規格 = OraDr.GetString(9)
                    If OraDr.IsDBNull(10) = False Then gudt長期貸出番号情報.str有効期限 = CStr(OraDr.GetValue(10))
                    If OraDr.IsDBNull(11) = False Then gudt長期貸出番号情報.strロット = OraDr.GetString(11)
                    If OraDr.IsDBNull(12) = False Then gudt長期貸出番号情報.strシリアル = OraDr.GetString(12)
                    If OraDr.IsDBNull(13) = False Then gudt長期貸出番号情報.lng出荷数量 = CLng(OraDr.GetDouble(13))
                    If OraDr.IsDBNull(14) = False Then gudt長期貸出番号情報.str出荷単位名 = OraDr.GetString(14)
                    If OraDr.IsDBNull(15) = False Then gudt長期貸出番号情報.str消費日 = CStr(OraDr.GetValue(15))
                    If OraDr.IsDBNull(16) = False Then gudt長期貸出番号情報.str消費需要先名 = OraDr.GetString(16)
                    If OraDr.IsDBNull(17) = False Then gudt長期貸出番号情報.str消費需要先部署名 = OraDr.GetString(17)
                    If OraDr.IsDBNull(18) = False Then gudt長期貸出番号情報.str返却日 = CStr(OraDr.GetValue(18))

                Case 2

                    DLTP0301_PROC0014 = 2
                    OraTran.Rollback()
                    Exit Function

                Case -54 'NOWAIT ビジー

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
    ''' 長期貸出番号情報更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng長期貸出番号">長期貸出番号</param>
    ''' <param name="PI_str抹消日">抹消日</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0301_PROC0015(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng長期貸出番号 As Long,
                                             ByVal PI_str抹消日 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int64, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_lng長期貸出番号
            PI_04.Value = PI_str抹消日

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
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
    ''' 得意先別販売許可証メンテナンス(得意先検索)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng得意先コード">得意先コード</param>
    ''' <param name="PI_str業種コード">業種コード</param>
    ''' <param name="PI_int許可証区分">許可証区分</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0504_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng得意先コード As Long,
                                             ByVal PI_str業種コード As String,
                                             ByVal PI_int許可証区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            If PI_lng得意先コード = DUMMY_LNGCODE Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_lng得意先コード
            End If
            If IsNull(PI_str業種コード) Then
                PI_02.Value = vbNullString
            Else
                PI_02.Value = PI_str業種コード
            End If
            If PI_int許可証区分 = 7 Then
                PI_03.Value = vbNullString
            Else
                PI_03.Value = PI_int許可証区分
            End If

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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

                Case -54 'NOWAIT ビジー

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
    ''' 得意先別販売許可証メンテナンス(条件検索)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str業種コード">業種コード</param>
    ''' <param name="PI_int許可証区分">許可証区分</param>
    ''' <param name="PI_条件">条件</param>
    ''' <param name="PI_終了日付">終了日付</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0504_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str業種コード As String,
                                             ByVal PI_int許可証区分 As Integer,
                                             ByVal PI_条件 As Integer,
                                             ByVal PI_終了日付 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)


            'インプット値設定
            If IsNull(PI_str業種コード) Then
                PI_01.Value = vbNullString
            Else
                PI_01.Value = PI_str業種コード
            End If
            PI_02.Value = PI_int許可証区分
            PI_03.Value = PI_条件
            If PI_条件 = 2 Then
                PI_04.Value = PI_終了日付
            Else
                PI_04.Value = vbNullString
            End If

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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

                Case -54 'NOWAIT ビジー

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
    ''' 得意先別販売許可証メンテナンス(削除)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_件数">削除件数</param>
    ''' <param name="PI_Results">DLT販売許可証管理情報_ID_Array</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了 9 -- エラー</returns>
    Public Shared Function DLTP0504_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_件数 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = PI_件数

            'インプット値設定
            PI_01.Value = PI_Results
            PI_02.Value = PI_件数

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 得意先別販売許可証メンテナンス(画像取得)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lngID">DLT販売許可証管理情報_ID</param>
    ''' <param name="PO_Img">画像（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure


            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int64, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_lngID

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 受注形態メンテナンス商品情報取得取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str商品コード">商品コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0301_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str商品コード As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_str商品コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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
    ''' 受注形態メンテナンス商品情報取得取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str商品コード">商品コード</param>
    ''' <param name="PI_strSPD商品コード">SPD商品コード</param>
    ''' <param name="PI_int受注形態">受注形態</param>
    ''' <param name="PI_int出荷連携">出荷連携</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了</returns>
    Public Shared Function DLTP0301_PROC0022(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str商品コード As String,
                                             ByVal PI_strSPD商品コード As String,
                                             ByVal PI_int受注形態 As Integer,
                                             ByVal PI_int出荷連携 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_str商品コード
            PI_05.Value = PI_strSPD商品コード
            PI_06.Value = PI_int受注形態
            PI_07.Value = PI_int出荷連携

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 受注テキスト取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng入力担当コード">入力担当コード</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0106_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng入力担当コード As Long,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int64, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_lng入力担当コード
            PI_05.Value = My.Settings.事業所コード

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' Aptage用汎用受注データ作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_lng作成担当者コード">作成担当者コード</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0106_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_lng作成担当者コード As Long,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int64, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_lng作成担当者コード
            PI_03.Value = PI_int取込番号
            PI_04.Value = PI_intSubProgram_ID

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 得意先一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
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

            gint得意先Cnt = 0

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            得意先Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 得意先Array(i)

                    'グローバル変数にセット
                    得意先Array(i).lng得意先コード = OraDr.GetInt64(0)
                    得意先Array(i).str得意先名 = OraDr.GetString(1)
                    i += 1

                End While

                gint得意先Cnt = i

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
    ''' 伝送用納品情報作成(徳洲会納品実績送信)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng売掛先コード">売掛先コード</param>
    ''' <param name="PI_txt対象開始日">対象開始日</param>
    ''' <param name="PI_txt対象終了日">対象終了日</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0304_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng売掛先コード As Long,
                                             ByVal PI_txt対象開始日 As String,
                                             ByVal PI_txt対象終了日 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int64, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt対象開始日.Trim
            PI_05.Value = PI_txt対象終了日.Trim
            If PI_lng売掛先コード = 0 Then
                PI_06.Value = vbNullString
            Else
                PI_06.Value = PI_lng売掛先コード
            End If

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 伝送用納品情報データ検索(徳洲会納品実績送信)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0304_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 伝送用請求鑑情報作成(徳洲会請求情報伝送)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng売掛先コード">売掛先コード</param>
    ''' <param name="PI_txt請求締日">請求締日</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0403_PROC0001(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_lng売掛先コード As Long,
                                             ByVal PI_txt請求締日 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int64, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Int32, ParameterDirection.Output)
            PO_06 = Oracmd.Parameters.Add("PO_06", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt請求締日.Trim
            If PI_lng売掛先コード = 0 Then
                PI_05.Value = vbNullString
            Else
                PI_05.Value = PI_lng売掛先コード
            End If

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt0 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_03.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_04.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_05.Value.ToString, Integer)
            PO_strSQLERRM = PO_06.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 伝送用請求明細情報作成(徳洲会請求情報伝送)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_取込番号">取込番号</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0403_PROC0101(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_取込番号

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 伝送用請求鑑情報データ検索(徳洲会請求情報伝送)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0403_PROC0021(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 伝送用請求明細情報データ検索(徳洲会請求情報伝送)
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0403_PROC0201(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 5, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' ログイン情報更新
    ''' </summary>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常終了 9 -- エラー</returns>
    Public Shared Function DLTP0000_PROC0006(ByRef PO_intSQLCODE As Integer,
                                             ByRef PO_strSQLERRM As String) As Boolean

        Dim PI_01 As OracleParameter
        Dim PI_02 As OracleParameter
        Dim PO_01 As OracleParameter
        Dim PO_02 As OracleParameter

        Try

            DLTP0000_PROC0006 = False

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = "DLTP0000.PROC0006"
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = Get_MachineName()
            PI_02.Value = My.Application.Info.Version

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CType(PO_01.Value.ToString, Integer)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 分納データ取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPDシステムコード</param>
    ''' <param name="PI_intSPDSystemcode">サブプログラム_ID</param>
    ''' <param name="PI_str連携キー">連携ー</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）></param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0301_PROC0023(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str連携キー As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str連携キー

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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
    ''' 分納データ更新
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">SPDシステムコード</param>
    ''' <param name="PI_intSPDSystemcode">サブプログラム_ID</param>
    ''' <param name="PI_str連携キー">連携ー</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）></param>
    ''' <returns>True・・正常終了、False・・異常終了</returns>
    Public Shared Function DLTP0301_PROC0024(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str連携キー As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_str連携キー

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 入出庫情報作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng医薬区分">医薬区分</param>
    ''' <param name="PI_txt対象開始日">対象開始日</param>
    ''' <param name="PI_txt対象終了日">対象終了日</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt">対象件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0502_PROC0001(ByVal PI_strProgram_ID As String,
                                            ByVal PI_intSPDSystemcode As Integer,
                                            ByVal PI_intSubProgram_ID As Integer,
                                            ByVal PI_lng医薬区分 As Integer,
                                            ByVal PI_txt対象開始日 As String,
                                            ByVal PI_txt対象終了日 As String,
                                            ByVal PI_int処理対象区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt対象開始日.Trim & "/01"
            PI_05.Value = PI_txt対象終了日.Trim & "/01"
            PI_06.Value = PI_lng医薬区分
            PI_07.Value = PI_int処理対象区分

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt = CType(PO_02.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_03.Value.ToString, Integer)
            PO_strSQLERRM = PO_04.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 入出庫情報作成
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_lng医薬区分">医薬区分</param>
    ''' <param name="PI_txt対象開始日">対象開始日</param>
    ''' <param name="PI_txt対象終了日">対象終了日</param>
    ''' <param name="PO_intNo">取込番号（戻値）</param>
    ''' <param name="PO_intCnt">対象件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0502_PROC0002(ByVal PI_strProgram_ID As String,
                                            ByVal PI_intSPDSystemcode As Integer,
                                            ByVal PI_intSubProgram_ID As Integer,
                                            ByVal PI_lng医薬区分 As Integer,
                                            ByVal PI_txt対象開始日 As String,
                                            ByVal PI_txt対象終了日 As String,
                                            ByVal PI_int処理対象区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, 20, DBNull.Value, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)


            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'インプット値設定
            PI_01.Value = My.Settings.事業所コード
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = PI_txt対象開始日.Trim & "/01"
            PI_05.Value = PI_txt対象終了日.Trim & "/01"
            PI_06.Value = PI_lng医薬区分
            PI_07.Value = PI_int処理対象区分

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intNo = CType(PO_01.Value.ToString, Integer)
            PO_intCnt = CType(PO_02.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_03.Value.ToString, Integer)
            PO_strSQLERRM = PO_04.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 入出庫情報情報データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0502_PROC0011(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 入出庫情報情報データ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int取込番号">取込番号</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0502_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int取込番号 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, 0, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, 0, 4, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_int取込番号


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 棚卸結果登録外読込データ出力（羅針盤用）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            ReDim Data(gintExcelDataCnt - 1)

            For i = 0 To gintExcelDataCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gintExcelDataCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = PI_intSubProgram_ID
            PI_04.Value = gintExcelDataCnt

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            'リターンコードでの振り分け
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
    ''' 天神会SPD施設一覧取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_str病院コード">病院コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>True -- 正常取得 False -- エラー</returns>
    Public Shared Function DLTP0501_PROC0101(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_str病院コード As String,
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

            gin施設Cnt = 0

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_str病院コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            施設Array = Nothing

            'リターンコードでの処理振り分け
            If PO_intSQLCODE = 0 Then

                i = 0

                While OraDr.Read

                    'メモリ再取得
                    ReDim Preserve 施設Array(i)

                    'グローバル変数にセット
                    施設Array(i).str施設コード = OraDr.GetString(0)
                    施設Array(i).str施設名 = OraDr.GetString(1)
                    i += 1

                End While

                gin施設Cnt = i

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
    ''' 天神会SPD部署情報取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str病院コード">病院コード</param>
    ''' <param name="PI_str部署コード">部署コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、8 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0501_PROC0102(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str病院コード As String,
                                             ByVal PI_str部署コード As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_str病院コード
            PI_05.Value = PI_str部署コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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
    ''' 天神会SPD部署情報メンテナンス
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str病院コード">病院コード</param>
    ''' <param name="PI_int明細ID">明細ID</param>
    ''' <param name="PI_str施設コード">施設コード</param>
    ''' <param name="PI_str部署コード">部署コード</param>
    ''' <param name="PI_str部署名">部署名</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、9 -- 異常終了</returns>
    Public Shared Function DLTP0501_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str病院コード As String,
                                             ByVal PI_int明細ID As Integer,
                                             ByVal PI_str施設コード As String,
                                             ByVal PI_str部署コード As String,
                                             ByVal PI_str部署名 As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int64, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_08 = Oracmd.Parameters.Add("PI_08", OracleDbType.Varchar2, ParameterDirection.Input)


            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = My.Settings.事業所コード
            PI_04.Value = PI_str病院コード
            PI_05.Value = PI_int明細ID
            PI_06.Value = PI_str施設コード
            PI_07.Value = PI_str部署コード
            PI_08.Value = PI_str部署名

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 受注形態メンテナンス商品情報取得取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str病院コード">病院コード</param>
    ''' <param name="PI_str院内コード">str院内コード</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了 </returns>
    Public Shared Function DLTP0501_PROC0013(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str病院コード As String,
                                             ByVal PI_str院内コード As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str病院コード
            PI_04.Value = PI_str院内コード

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            OraDr = Oracmd.ExecuteReader()

            PO_intSQLCODE = CInt(PO_02.Value.ToString)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing
            gintResultCnt = 0

            'リターンコードでの処理振り分け
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
    ''' 受注形態メンテナンス商品情報取得取得
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_str病院コード">病院コード</param>
    ''' <param name="PI_str商品ID">商品ID</param>
    ''' <param name="PI_intマルコ対象">マルコ対象</param>
    ''' <param name="PI_intマルビシ対象">マルビシ対象</param>
    ''' <param name="PI_int軽減税率対象">軽減税率対象</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常終了、2 -- データなし、9 -- 異常終了</returns>
    Public Shared Function DLTP0501_PROC0005(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_str病院コード As String,
                                             ByVal PI_str商品ID As String,
                                             ByVal PI_intマルコ対象 As Integer,
                                             ByVal PI_intマルビシ対象 As Integer,
                                             ByVal PI_int軽減税率対象 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Int32, ParameterDirection.Input)
            PI_06 = Oracmd.Parameters.Add("PI_06", OracleDbType.Int32, ParameterDirection.Input)
            PI_07 = Oracmd.Parameters.Add("PI_07", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_str病院コード
            PI_04.Value = PI_str商品ID
            PI_05.Value = PI_intマルコ対象
            PI_06.Value = PI_intマルビシ対象
            PI_07.Value = PI_int軽減税率対象

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intSQLCODE = CInt(PO_01.Value.ToString)
            PO_strSQLERRM = PO_02.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 採用商品情報取込＆チェック
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_int管理区分">管理区分</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0501_PROC0003(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_int管理区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_int管理区分, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' SPD採用商品マスタ一括更新処理　エラーデータ検索
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' SPD採用商品マスタ一括更新処理　特殊品目データ検索（仕入先：マルコ、マルビシ）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_txt対象日">対象日</param>
    ''' <param name="PI_int出力対象">出力対象</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0501_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_txt対象日 As String,
                                             ByVal PI_int出力対象 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 4, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Varchar2, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)


            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = PI_intSubProgram_ID
            PI_03.Value = PI_txt対象日.Trim
            PI_04.Value = PI_int出力対象

            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 請求情報取込＆チェック（値引用）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_病院コード">病院コード</param>
    ''' <param name="PO_intCnt0">対象件数（戻値）</param>
    ''' <param name="PO_intCnt1">正常件数（戻値）</param>
    ''' <param name="PO_intCnt2">エラー件数（戻値）</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 9 -- エラー</returns>
    Public Shared Function DLTP0401_PROC0002(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_病院コード As String,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 1, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            ReDim Data(gint取込データCnt - 1)

            For i = 0 To gint取込データCnt - 1
                Data(i) = 取込データArray(i).strRecData
            Next

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            OraTran = Oracomm.BeginTransaction

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Varchar2)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)
            PI_04 = Oracmd.Parameters.Add("PI_04", OracleDbType.Int32, ParameterDirection.Input)
            PI_05 = Oracmd.Parameters.Add("PI_05", OracleDbType.Varchar2, ParameterDirection.Input)

            'Outputパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.Int32, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Int32, ParameterDirection.Output)
            PO_04 = Oracmd.Parameters.Add("PO_04", OracleDbType.Int32, ParameterDirection.Output)
            PO_05 = Oracmd.Parameters.Add("PO_05", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)


            PI_01.CollectionType = OracleCollectionType.PLSQLAssociativeArray
            PI_01.Size = gint取込データCnt

            'インプット値設定
            PI_01.Value = Data
            PI_02.Value = PI_intSPDSystemcode
            PI_03.Value = 0
            PI_04.Value = My.Settings.事業所コード
            PI_05.Value = PI_病院コード

            'ストアドプロシージャCall
            Oracmd.ExecuteNonQuery()

            PO_intCnt0 = CType(PO_01.Value.ToString, Integer)
            PO_intCnt1 = CType(PO_02.Value.ToString, Integer)
            PO_intCnt2 = CType(PO_03.Value.ToString, Integer)
            PO_intSQLCODE = CType(PO_04.Value.ToString, Integer)
            PO_strSQLERRM = PO_05.Value.ToString

            'リターンコードでの処理振り分け
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
    ''' 請求情報エラー情報検索（値引用）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, 3, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
    ''' 請求情報結果出力（値引用）
    ''' </summary>
    ''' <param name="PI_strProgram_ID">プログラム_ID</param>
    ''' <param name="PI_intSPDSystemcode">SPDシステムコード</param>
    ''' <param name="PI_intSubProgram_ID">サブプログラム_ID</param>
    ''' <param name="PI_データ区分">データ種別</param>
    ''' <param name="PO_intSQLCODE">Oracleエラーコード（戻値）</param>
    ''' <param name="PO_strSQLERRM">Oracleエラーメッセージ（戻値）</param>
    ''' <returns>0 -- 正常取得 2 -- レコード無 9 -- エラー</returns>
    Public Shared Function DLTP0401_PROC0012(ByVal PI_strProgram_ID As String,
                                             ByVal PI_intSPDSystemcode As Integer,
                                             ByVal PI_intSubProgram_ID As Integer,
                                             ByVal PI_データ区分 As Integer,
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

            'プログラム_ID取得
            gintRtn = DLTP0997S_FUNC005(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_データ区分, 1, "処理関数")
            strPROC = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(PI_strProgram_ID, PI_intSPDSystemcode, PI_intSubProgram_ID, PI_データ区分, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            'ストアドプロシージャ設定
            Oracmd = Oracomm.CreateCommand()
            Oracmd.CommandText = strPROC
            Oracmd.CommandType = CommandType.StoredProcedure

            'インプットパラメータ設定
            PI_01 = Oracmd.Parameters.Add("PI_01", OracleDbType.Int32, ParameterDirection.Input)
            PI_02 = Oracmd.Parameters.Add("PI_02", OracleDbType.Int32, ParameterDirection.Input)
            PI_03 = Oracmd.Parameters.Add("PI_03", OracleDbType.Int32, ParameterDirection.Input)

            'インプット値設定
            PI_01.Value = PI_intSPDSystemcode
            PI_02.Value = 0
            PI_03.Value = PI_データ区分


            'アウトプットパラメータ設定
            PO_01 = Oracmd.Parameters.Add("PO_01", OracleDbType.RefCursor, ParameterDirection.Output)
            PO_02 = Oracmd.Parameters.Add("PO_02", OracleDbType.Int32, ParameterDirection.Output)
            PO_03 = Oracmd.Parameters.Add("PO_03", OracleDbType.Varchar2, 1024, DBNull.Value, ParameterDirection.Output)

            'ストアドプロシージャcall
            OraDr = Oracmd.ExecuteReader

            PO_intSQLCODE = CType(PO_02.Value.ToString, Integer)
            PO_strSQLERRM = PO_03.Value.ToString

            Results = Nothing

            'リターンコードでの振り分け
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
