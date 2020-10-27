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
    ''' メイン画面起動前処理
    ''' </summary>
    Public Shared Sub Main()

        'ThreadExceptionイベントハンドラを追加
        AddHandler Application.ThreadException, AddressOf Application_ThreadException
        'ThreadExceptionが発生しないようにする
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException)
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

        Dim hasHandle As Boolean = False
        Dim intCnt As Integer = 0

        Try

            log4net.NDC.Push(My.Application.Info.Version.ToString)

            _mutex = New Mutex(False, My.Application.Info.ProductName)

            '自exeパス取得
            gstrAppFilePath = Get_AppPath()

            'カレントユーザーApplicationDataパス取得
            gstrApplicationDataPath = Set_FilePath(Get_ApplicationPath(), "HARK")

            'ログファイルパス取得
            gstrlogFilePath = Set_FilePath(gstrApplicationDataPath, "log")

            '個別設定ファイルパス取得
            gstrSettingFilePath = Set_FilePath(gstrAppFilePath, "Setting")
            If Chk_DirExists(gstrSettingFilePath) = False Then
                gblRtn = Create_Dir(gstrSettingFilePath)
            End If

            '各ファイルパス設定
            gstrLogFileName = Set_FilePath(gstrlogFilePath, "HARK000Err.Log")
            gstrExecuteLogFileName = Set_FilePath(gstrlogFilePath, "HARK000Execute.Log")

            Try
                'ミューテックスの所有権を要求する
                hasHandle = _mutex.WaitOne(0, False)

            Catch ex As AbandonedMutexException
                hasHandle = True
            End Try

            If hasHandle = False Then
                log.Error(Set_ErrMSG(0, MSG_COM005))
                MsgBox(MSG_COM005, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Return
            End If

            'Oracle接続
            If OraConnect() = False Then
                log.Error(Set_ErrMSG(0, MSG_COM004))
                MsgBox(MSG_COM004 & vbCr & MSG_COM019, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Throw New Exception(MSG_COM004)
            End If

            '部門名取得
            If My.Settings.事業所コード = 0 Then
                gstr部門名 = "システム管理"
            Else
                If DLTP0900_PROC0002("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                    Throw New Exception
                End If
            End If

            '担当者名取得
            If My.Settings.入力担当コード = 0 Then
                gstr担当者名 = "システム管理"
            Else
                If DLTP0900_PROC0001("Sub_Main", My.Settings.入力担当コード, vbNullString, gintSQLCODE, gstrSQLERRM) = False Then
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                    Throw New Exception
                End If
            End If

            '事業所一覧取得
            If DLTP0901_PROC0001("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            '掲示版一覧取得
            If DLTP0000_PROC0011("Sub_Main", gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            'ログイン情報更新
            If DLTP0000_PROC0006(gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(MSG_COM910 & vbCr & MSG_COM901 & vbCr & gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Throw New Exception
            End If

            '変数設定
            'PrintScreen無効化(0・・無効、1・・有効)
            gintKeyControl01 = 0

            'アプリ起動
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
    ''' 指定フォームIDのキャプションを設定
    ''' </summary>
    ''' <param name="ProgramID">各クラス名</param>
    ''' <param name="FormID">各フォーム名</param>
    ''' <returns>フォームタイトル</returns>
    Public Shared Function Set_FormTitle(ByVal ProgramID As String,
                                         ByVal FormID As String) As String

        Try
            'パスにファイル名を追加
            Set_FormTitle = ProgramID & " " & FormID & " 【" & My.Application.Info.CompanyName & "】"

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' エラーメッセージ整形
    ''' </summary>
    ''' <param name="strErrCode">エラーコード</param>
    ''' <param name="strErrMessage">エラーメッセージ</param>
    ''' <returns>整形後エラーメッセージ</returns>
    Public Shared Function Set_ErrMSG(ByVal strErrCode As Integer, ByVal strErrMessage As String) As String

        Dim strBuff As String

        strBuff = CType(strErrCode, String) & " " & strErrMessage

        Set_ErrMSG = strBuff

    End Function
    ''' <summary>
    ''' 処理中画面表示
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
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)

        Dim ErrMsg As String

        Try
            ErrMsg = CStr(DirectCast(e.ExceptionObject, Exception).HResult) & "-" & DirectCast(e.ExceptionObject, Exception).Message

            log.Error(Set_ErrMSG(999, ErrMsg))
            MsgBox(MSG_COM902 & vbCr & DirectCast(e.ExceptionObject, Exception).HResult & vbCr & DirectCast(e.ExceptionObject, Exception).Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        Finally
            'アプリケーションを終了する
            Environment.Exit(1)
        End Try

    End Sub
    ''' <summary>
    ''' Application_ThreadException
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Shared Sub Application_ThreadException(sender As Object, e As ThreadExceptionEventArgs)

        Dim ErrMsg As String

        Try
            ErrMsg = CStr(e.Exception.HResult) & "-" & e.Exception.Message

            log.Error(Set_ErrMSG(999, ErrMsg))
            MsgBox(MSG_COM902 & vbCr & e.Exception.HResult & vbCr & e.Exception.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        Finally
            'アプリケーションを終了する
            Application.Exit()
        End Try

    End Sub

End Class
