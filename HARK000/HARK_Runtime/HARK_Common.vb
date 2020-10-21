'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

'Imports System.IO.FileStream
Imports System.IO
Imports HARK000.HARK_Sub
Public Class HARK_Common

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    ''' <summary>
    ''' 自exeパス取得
    ''' </summary>
    ''' <returns>自exeパス</returns>
    Public Shared Function Get_AppPath() As String

        Dim strFullAppName As String
        Dim strFullAppPath As String

        Try
            '自exeパス取得(ファイル名含む)
            strFullAppName = Reflection.Assembly.GetExecutingAssembly().Location

            '自exe名を除く(右端[\]も削除)
            strFullAppPath = Path.GetDirectoryName(strFullAppName)

            Get_AppPath = strFullAppPath

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 自exe名（拡張子付き）取得
    ''' </summary>
    ''' <returns>自exe名（拡張子付き）</returns>
    Public Shared Function Get_AppFileName() As String

        Dim strFullAppName As String
        Dim strFullAppPath As String

        Try
            '自exeパス取得(ファイル名含む)
            strFullAppName = Reflection.Assembly.GetExecutingAssembly().Location

            '自exeパスを除く(右端[\]も削除)
            strFullAppPath = Path.GetFileName(strFullAppName)

            Get_AppFileName = strFullAppPath

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 指定ファイル存在チェック
    ''' </summary>
    ''' <param name="FileName">指定ファイル名(フルパス)</param>
    ''' <returns>Ture・・存在する,False・・存在しない</returns>
    Public Shared Function Chk_FileExists(ByVal FileName As String) As Boolean

        Try

            Chk_FileExists = False

            If File.Exists(FileName) = True Then

                Chk_FileExists = True

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 指定フォルダ存在チェック
    ''' </summary>
    ''' <param name="DirName">指定フォルダ名(フルパス)</param>
    ''' <returns>Ture・・存在する,False・・存在しない</returns>
    Public Shared Function Chk_DirExists(ByVal DirName As String) As Boolean

        Try

            Chk_DirExists = False

            If Right(DirName.Trim, 1) <> "\" Then
                DirName &= "\"
            End If

            If Directory.Exists(DirName) = True Then

                Chk_DirExists = True

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 指定Dirパスに指定ファイル名を追加
    ''' </summary>
    ''' <param name="DirPath">任意のDirパス</param>
    ''' <param name="Filename">任意のファイル名(拡張子付)</param>
    ''' <returns>フルパスファイル名</returns>
    ''' <remarks>DirPathは右端[\]は不要</remarks>
    Public Shared Function Set_FilePath(ByVal DirPath As String, ByVal Filename As String) As String

        Try
            'パスにファイル名を追加
            Set_FilePath = Path.Combine(DirPath, Filename)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 指定exeのバージョン比較
    ''' </summary>
    ''' <param name="Path">現行exeのフルパス</param>
    ''' <returns>True・・バージョンアップ必要、False・・不要</returns>
    Public Shared Function Chk_Version(ByVal Path As String) As Boolean

        Dim strAppVer As String         '現行バージョン
        Dim strAppVerUp As String       '次期バージョン

        Try

            Chk_Version = False

            'ファイル存在チェック
            If Chk_FileExists(Path) = False Then

                Exit Function

            End If

            '現行バージョン取得
            strAppVer = Application.ProductVersion

            '次期バージョン取得
            Dim vi As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path)

            strAppVerUp = vi.FileVersion

            'バージョン比較
            If strAppVer >= strAppVerUp Then
                Exit Function
            End If

            Chk_Version = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 文字列NULLチェック
    ''' </summary>
    ''' <param name="text">指定文字列</param>
    ''' <returns>True・・NULL、False・・NULLでない</returns>
    Public Shared Function IsNull(ByVal text As String) As Boolean

        Try

            If IsNothing(text) = True Then
                Return True
            End If

            If String.IsNullOrEmpty(text) Then
                Return True
            End If

            If text Is Nothing = True Then
                Return True
            End If

            If text = "" Then
                Return True
            End If

            Return False

        Catch
            Return True
        End Try

    End Function
    ''' <summary>
    ''' 文字列⇒数字変換可否チェック
    ''' </summary>
    ''' <param name="text">指定文字列</param>
    ''' <returns>True・・変換可、False・・変換不可</returns>
    Public Shared Function IsNumeric(ByVal text As String) As Boolean

        Try
            Double.Parse(text)
            Return True
        Catch
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 文字列⇒日付変換可否チェック
    ''' </summary>
    ''' <param name="text">指定文字列</param>
    ''' <returns>True・・変換可、False・・変換不可</returns>
    Public Shared Function IsDate(ByVal text As String) As Boolean

        Try
            text = text.Replace("_", "")
            Date.Parse(text)
            Return True
        Catch
            Return False
        End Try

    End Function
    ''' <summary>
    ''' デスクトップパス取得
    ''' </summary>
    ''' <returns>デスクトップパス</returns>
    Public Shared Function Get_DesktopPath() As String

        Dim Path As String

        Try

            Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)

            Get_DesktopPath = Path

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 文字列の入力チェック
    ''' </summary>
    ''' <param name="strData">チェックする文字列</param>
    ''' <param name="intSizeFlg">1 全角 2 半角 0 共用</param>
    ''' <param name="intStyleFlg">0 数字のみ 1 英数字のみ 2 その他</param>
    ''' <param name="intMaxLength">最大文字数</param>
    ''' <returns>True・・正常、False・・異常</returns>
    Public Shared Function Chk_Entry(ByVal strData As String, ByVal intSizeFlg As Integer, ByVal intStyleFlg As Integer, ByVal intMaxLength As Integer) As Boolean

        Dim Base() As Byte
        Dim UniBase() As Byte
        Dim Code As Text.Encoding
        Dim intByte As Integer

        Try
            Chk_Entry = False

            '引数正常チェック
            If intSizeFlg < 0 Or intSizeFlg > 2 Then
                Exit Function
            End If

            If intStyleFlg < 0 Or intStyleFlg > 2 Then
                Exit Function
            End If

            If intMaxLength = 0 Then
                Exit Function
            End If

            '変換文字コード指定
            Code = Text.Encoding.GetEncoding(932)

            '文字列のバイト数取得
            Base = Text.Encoding.Unicode.GetBytes(strData)

            'Unicodeバイトへ変換
            UniBase = Text.Encoding.Convert(Text.Encoding.Unicode, Code, Base)

            '取得文字列のバイト数代入
            intByte = CType(UniBase.Length, Integer)

            '文字列長比較
            If intByte > intMaxLength Then
                Exit Function
            End If

            If intSizeFlg = 1 Then        '全角チェック
                If Text.RegularExpressions.Regex.IsMatch(strData, "^[a-zA-Z0-9｡-ﾟ!-/]+") Then
                    Exit Function
                End If
            ElseIf intSizeFlg = 2 Then    '半角チェック
                If Text.RegularExpressions.Regex.IsMatch(strData, "^[a-zA-Z0-9｡-ﾟ!-/\uFF61-\uFF9F]+") = False Then
                    Exit Function
                End If
            End If

            If intStyleFlg = 0 Then    '数字のみ
                If Not Text.RegularExpressions.Regex.IsMatch(strData, "^[0-9]{1," & intMaxLength & "}$") Then
                    Exit Function
                End If
            ElseIf intStyleFlg = 1 Then     '英数字のみ
                If Not Text.RegularExpressions.Regex.IsMatch(strData, "^[a-zA-Z0-9\-/]{1," & intMaxLength & "}$") Then
                    Exit Function
                End If
            ElseIf intStyleFlg = 2 Then     'その他
                If Not Text.RegularExpressions.Regex.IsMatch(strData, "^[a-zA-Z0-9｡-ﾟ!-/\uFF61-\uFF9F]{1," & intMaxLength & "}$") Then
                    Exit Function
                End If
            End If

            Chk_Entry = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' 日付の入力チェック
    ''' </summary>
    ''' <param name="strDate">チェックする日付</param>
    ''' <param name="ChkFlg">1・・YYYY/MM/DD 2・・YYYY/MM</param>
    ''' <returns>True・・正常、False・・異常</returns>
    Public Shared Function Chk_Date(ByVal strDate As String, ByVal ChkFlg As Integer) As Boolean

        Dim strBuff() As String    '/用配列
        Dim iLastDay As Integer
        Dim iYear As Integer
        Dim iMonth As Integer
        Dim iDate As Integer

        Try

            Chk_Date = False
            gstrDate = ""

            If Chk_Entry(strDate, 2, 1, 10) = False Then
                Exit Function
            End If

            If Text.RegularExpressions.Regex.IsMatch(strDate, "^[0-9/]{1,10}$") = False Then
                Exit Function
            End If

            strBuff = Split(strDate, "/")

            If ChkFlg = 1 Then
                Select Case strBuff.Length

                    Case Is = 1

                        If strDate.Length <> 8 Then
                            Exit Function
                        End If

                        iYear = CType(strDate.Substring(0, 4), Integer)
                        iMonth = CType(strDate.Substring(4, 2), Integer)
                        iDate = CType(strDate.Substring(6, 2), Integer)

                        If Text.RegularExpressions.Regex.IsMatch(strDate, "^[12][0-9]{7}$") Then

                            If (Date.MinValue.Year > iYear) OrElse (iYear > Date.MaxValue.Year) Then
                                Exit Function
                            End If

                            If (Date.MinValue.Month > iMonth) OrElse (iMonth > Date.MaxValue.Month) Then
                                Exit Function
                            End If

                            iLastDay = Date.DaysInMonth(iYear, iMonth)

                            If (Date.MinValue.Day > iDate) OrElse (iDate > iLastDay) Then
                                Exit Function
                            End If

                            gstrDate = strDate.Substring(0, 4) & "/" &
                                       strDate.Substring(4, 2) & "/" &
                                       strDate.Substring(6, 2)

                            Chk_Date = True
                            Exit Function

                        Else
                            Exit Function
                        End If

                    Case Is = 3

                        iYear = CType(strBuff(0), Integer)
                        iMonth = CType(strBuff(1), Integer)
                        iDate = CType(strBuff(2), Integer)

                        If Text.RegularExpressions.Regex.IsMatch(strDate, "^[12][0-9]{1,3}[/][0-9]{1,2}[/][0-9]{1,2}$") Then

                            If strBuff(1).Length = 1 And CDbl(strBuff(1)) < 10 Then
                                strBuff(1) = "0" & strBuff(1)
                            End If

                            If strBuff(2).Length = 1 And CDbl(strBuff(2)) < 10 Then
                                strBuff(2) = "0" & strBuff(2)
                            End If

                            If (Date.MinValue.Year > iYear) OrElse (iYear > Date.MaxValue.Year) Then
                                Exit Function
                            End If

                            If (Date.MinValue.Month > iMonth) OrElse (iMonth > Date.MaxValue.Month) Then
                                Exit Function
                            End If

                            iLastDay = Date.DaysInMonth(iYear, iMonth)

                            If (Date.MinValue.Day > iDate) OrElse (iDate > iLastDay) Then
                                Exit Function
                            End If

                            '正常終了
                            gstrDate = strBuff(0) & "/" &
                                       strBuff(1) & "/" &
                                       strBuff(2)

                            Chk_Date = True
                            Exit Function

                        Else
                            Exit Function
                        End If

                End Select

            ElseIf ChkFlg = 2 Then
                Select Case strBuff.Length

                    Case Is = 1

                        If strDate.Length <> 6 Then
                            Exit Function
                        End If

                        iYear = CType(strDate.Substring(0, 4), Integer)
                        iMonth = CType(strDate.Substring(4, 2), Integer)
                        ' iDate = CType(strDate.Substring(6, 2), Integer)

                        If Text.RegularExpressions.Regex.IsMatch(strDate, "^[12][0-9]{5}$") Then

                            If (Date.MinValue.Year > iYear) OrElse (iYear > Date.MaxValue.Year) Then
                                Exit Function
                            End If

                            If (Date.MinValue.Month > iMonth) OrElse (iMonth > Date.MaxValue.Month) Then
                                Exit Function
                            End If

                            gstrDate = strDate.Substring(0, 4) & "/" &
                                       strDate.Substring(4, 2)

                            Chk_Date = True
                            Exit Function

                        Else
                            Exit Function
                        End If

                    Case Is = 2

                        iYear = CType(strBuff(0), Integer)
                        iMonth = CType(strBuff(1), Integer)
                        '         iDate = CType(strBuff(2), Integer)


                        If Text.RegularExpressions.Regex.IsMatch(strDate, "^[12][0-9]{1,3}[/][0-9]{1,2}$") Then

                            If strBuff(1).Length = 1 And CDbl(strBuff(1)) < 10 Then
                                strBuff(1) = "0" & strBuff(1)
                            End If

                            If (Date.MinValue.Year > iYear) OrElse (iYear > Date.MaxValue.Year) Then
                                Exit Function
                            End If

                            If (Date.MinValue.Month > iMonth) OrElse (iMonth > Date.MaxValue.Month) Then
                                Exit Function
                            End If


                            '正常終了
                            gstrDate = strBuff(0) & "/" &
                                       strBuff(1)

                            Chk_Date = True
                            Exit Function

                        Else
                            Exit Function
                        End If

                End Select

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' ディレクトリ名取得
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>ディレクトリ名</returns>
    Public Shared Function Get_DirectoryName(ByVal strPath As String) As String

        Get_DirectoryName = Path.GetDirectoryName(strPath)

    End Function
    ''' <summary>
    ''' 拡張子取得
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>拡張子</returns>
    ''' <remarks>3文字拡張子用</remarks>
    Public Shared Function Get_Extension(ByVal strPath As String) As String

        Get_Extension = Right(Path.GetExtension(strPath), 3)

    End Function
    ''' <summary>
    ''' 拡張子取得
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>拡張子</returns>
    ''' <remarks>4文字拡張子用</remarks>
    Public Shared Function Get_ExtensionEx(ByVal strPath As String) As String

        Get_ExtensionEx = Right(Path.GetExtension(strPath), 4)

    End Function
    ''' <summary>
    ''' ファイル名取得（拡張子付）
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>ファイル名（拡張子付）</returns>
    Public Shared Function Get_FileName(ByVal strPath As String) As String

        Get_FileName = Path.GetFileName(strPath)

    End Function
    ''' <summary>
    ''' ファイル名取得（拡張子無）
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>ファイル名（拡張子無）</returns>
    Public Shared Function Get_FileNameWithoutExtension(ByVal strPath As String) As String

        Get_FileNameWithoutExtension = Path.GetFileNameWithoutExtension(strPath)

    End Function
    ''' <summary>
    ''' ルートディレクトリ名取得
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>ルートディレクトリ名</returns>
    Public Shared Function Get_PathRoot(ByVal strPath As String) As String

        Get_PathRoot = Path.GetPathRoot(strPath)

    End Function
    ''' <summary>
    ''' NULL置換
    ''' </summary>
    ''' <param name="obj1">指定オブジェクト</param>
    ''' <param name="obj2">指定オブジェクト</param>
    ''' <returns>obj1がNULLならobj2、obj1がNOTNULLならobj1</returns>
    Public Shared Function Nvl(ByVal obj1 As Object, ByVal obj2 As Object) As Object

        Try

            If obj1 Is Nothing Then
                Nvl = obj2
                Return Nvl
            Else
                Nvl = obj1
                Return Nvl
            End If


            If IsNothing(obj1) Then
                Nvl = obj2
                Return Nvl
            Else
                Nvl = obj1
                Return Nvl
            End If

            Return vbNullString

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' NULL置換(String用)
    ''' </summary>
    ''' <param name="obj1">指定オブジェクト</param>
    ''' <param name="obj2">指定オブジェクト</param>
    ''' <returns>obj1がNULLならobj2 obj1がNOTNULLならobj1</returns>
    Public Shared Function NvlString(ByVal obj1 As String, ByVal obj2 As String) As String

        Try
            If IsNull(obj1) Then
                NvlString = obj2
                Return NvlString
            Else
                NvlString = obj1
                Return NvlString
            End If

            Return vbNullString

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' ディレクトリ作成
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>True・・正常終了 False・・異常終了</returns>
    Public Shared Function Create_Dir(ByVal strPath As String) As Boolean

        Dim hstream As DirectoryInfo

        Try
            hstream = Directory.CreateDirectory(strPath)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 指定ディレクトリ内全ファイルを削除
    ''' </summary>
    ''' <param name="DirName">任意のディレクトリ</param>
    ''' <returns>True・・正常終了 False・・異常終了</returns>
    Public Shared Function Delete_Files(ByVal DirName As String) As Boolean

        Dim Files As String() = Directory.GetFiles(DirName)
        Dim f As String

        Try
            For Each f In Files

                Dim FileName As String = Set_FilePath(DirName, Path.GetFileName(f))

                Kill(FileName)

            Next f
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' ファイル各種チェック
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>True・・正常 False・・異常</returns>
    Public Shared Function Chk_FilePath(ByVal strPath As String) As Boolean

        Dim tmpFileName As String
        Dim invalidChars As Char() = Path.GetInvalidPathChars


        Try
            'ディレクトリ存在チェック
            If Not Directory.Exists(Get_DirectoryName(strPath)) Then
                Return False
            End If

            'ディレクトリアクセスチェック
            If Not Create_DummyFile(Set_FilePath(Get_DirectoryName(strPath), DUMMY_FILENAME)) Then
                Return False
            End If

            'ダミーファイル削除
            Kill(Set_FilePath(Get_DirectoryName(strPath), DUMMY_FILENAME))

            'プラットフォーム固有文字チェック
            tmpFileName = Get_FileNameWithoutExtension(strPath)
            If tmpFileName.IndexOfAny(invalidChars) >= 0 Then
                Return False
            End If

            '拡張子存在チェック
            If Not Has_Extension(strPath) Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' ダミーファイル書込
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>True・・正常 False・・異常</returns>
    Public Shared Function Create_DummyFile(ByVal strPath As String) As Boolean

        Dim hstream As FileStream = Nothing

        Try
            Try
                hstream = File.Create(strPath)
                Return True
            Catch ex As Exception
                Return False
            Finally
                If Not hstream Is Nothing Then
                    hstream.Close()
                End If
            End Try
        Catch ex As Exception
            Return False
        Finally
            If Not hstream Is Nothing Then
                Dim hDisposable As IDisposable = hstream
                hDisposable.Dispose()
            End If
        End Try

    End Function
    ''' <summary>
    ''' 拡張子存在チェック
    ''' </summary>
    ''' <param name="strPath">絶対パス</param>
    ''' <returns>True・・存在する False・・存在しない</returns>
    Public Shared Function Has_Extension(ByVal strPath As String) As Boolean

        Has_Extension = Path.HasExtension(strPath)

    End Function
    ''' <summary>
    ''' 指定ファイルを削除
    ''' </summary>
    ''' <param name="Filename">任意のファイル名(拡張子付)</param>
    ''' <returns>0 -- 正常終了 55 -- ファイルオープン 53 -- ファイル存在エラー 99 -- その他エラー</returns>
    Public Shared Function Delete_File(ByVal Filename As String) As Integer

        Try
            'ファイル削除
            Kill(Filename)
            Return 0
        Catch ex As FileNotFoundException
            'ファイルが存在しない
            Return 53
        Catch ex As IOException
            'ファイルが他プロセスで使用中
            Return 55
        Catch ex As Exception
            'その他エラー
            Return 99
        End Try

    End Function
    ''' <summary>
    ''' コンピュータ名取得
    ''' </summary>
    ''' <returns>コンピュータ名</returns>
    Public Shared Function Get_MachineName() As String

        Try

            Get_MachineName = Environment.MachineName

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' コンピュータログインユーザー名取得
    ''' </summary>
    ''' <returns>コンピュータログインユーザー名</returns>
    Public Shared Function Get_LoginUserName() As String

        Try

            Get_LoginUserName = Environment.UserName

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' コンピュータIPアドレス取得
    ''' </summary>
    ''' <returns>IPアドレス</returns>
    Public Shared Function Get_IPAddress() As String

        Try
            'VISTA以降API仕様変更の為、OSバージョン毎の取得
            Select Case Get_OSVersion()

                Case OS_WINDOWSVISTA, OS_WINDOWS7, OS_WINDOWS8, OS_WINDOWS81, OS_WINDOWS10

                    Get_IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName).AddressList(1).ToString
                    Exit Select

                Case OS_MACINTOSH, OS_UNIX, OS_UNKNOWN, OS_WINDOWS32s, OS_WINDOWSCE, OS_XBOX

                    Get_IPAddress = ""
                    Exit Select

                Case Else

                    Get_IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName).AddressList(0).ToString
                    Exit Select

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' OSバージョン取得
    ''' </summary>
    ''' <returns>OSバージョン</returns>
    Public Shared Function Get_OSVersion() As Integer

        Dim os As OperatingSystem = Environment.OSVersion

        Try

            Select Case os.Platform

                Case PlatformID.Win32Windows

                    If os.Version.Major >= 4 Then

                        Select Case os.Version.Minor
                            Case 0
                                Get_OSVersion = OS_WINDOWS95
                                Exit Select
                            Case 10
                                Get_OSVersion = OS_WINDOWS98
                                Exit Select
                            Case 90
                                Get_OSVersion = OS_WINDOWSME
                                Exit Select
                        End Select

                    End If
                    Exit Select

                Case PlatformID.Win32NT

                    Select Case os.Version.Major
                        Case 3
                            Select Case os.Version.Minor
                                Case 0
                                    Get_OSVersion = OS_WINDOWSNT3
                                    Exit Select
                                Case 1
                                    Get_OSVersion = OS_WINDOWSNT31
                                    Exit Select
                                Case 5
                                    Get_OSVersion = OS_WINDOWSNT35
                                    Exit Select
                                Case 51
                                    Get_OSVersion = OS_WINDOWSNT351
                                    Exit Select
                            End Select
                            Exit Select
                        Case 4
                            If os.Version.Minor = 0 Then
                                Get_OSVersion = OS_WINDOWSNT4
                            End If
                            Exit Select
                        Case 5
                            Select Case os.Version.Minor
                                Case 0
                                    Get_OSVersion = OS_WINDOWS2000
                                    Exit Select
                                Case 1
                                    Get_OSVersion = OS_WINDOWSXP
                                    Exit Select
                                Case 2
                                    Get_OSVersion = OS_WINDOWSSERVER2003
                                    Exit Select
                            End Select
                            Exit Select
                        Case 6
                            Select Case os.Version.Minor
                                Case 0
                                    Get_OSVersion = OS_WINDOWSVISTA 'Windows Server 2008含む
                                    Exit Select
                                Case 1
                                    Get_OSVersion = OS_WINDOWS7  'Windows Server 2008 R2含む
                                    Exit Select
                                Case 2
                                    Get_OSVersion = OS_WINDOWS8  'Windows Server 2012含む
                                    Exit Select
                                Case 3
                                    Get_OSVersion = OS_WINDOWS81  'Windows Server 2012 R2含む
                                    Exit Select
                            End Select
                            Exit Select
                        Case 10
                            Select Case os.Version.Minor
                                Case 0
                                    Get_OSVersion = OS_WINDOWS10 'Windows Server 2016含む
                                    Exit Select
                            End Select
                            Exit Select
                    End Select
                    Exit Select

                Case PlatformID.Win32S
                    Get_OSVersion = OS_WINDOWS32s
                    Exit Select

                Case PlatformID.WinCE
                    Get_OSVersion = OS_WINDOWSCE
                    Exit Select

                Case PlatformID.Unix
                    '.NET Framework 2.0以降
                    Get_OSVersion = OS_UNIX
                    Exit Select

                Case PlatformID.Xbox
                    '.NET Framework 3.5以降
                    Get_OSVersion = OS_XBOX
                    Exit Select

                Case PlatformID.MacOSX
                    '.NET Framework 3.5以降
                    Get_OSVersion = OS_MACINTOSH
                    Exit Select

                Case Else
                    Get_OSVersion = OS_UNKNOWN
                    Exit Select

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' カレントユーザーApplicationDataパス取得
    ''' </summary>
    ''' <returns>デスクトップパス</returns>
    Public Shared Function Get_ApplicationPath() As String

        Dim Path As String

        Try

            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

            Get_ApplicationPath = Path

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    ''' <summary>
    ''' ランダムファイル名取得(拡張子なし)
    ''' </summary>
    ''' <returns>ファイル名</returns>
    Public Shared Function Get_RandomFileName() As String

        Dim Name As String

        Try

            Name = Get_FileNameWithoutExtension(Path.GetRandomFileName)

            Get_RandomFileName = Name

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
End Class
