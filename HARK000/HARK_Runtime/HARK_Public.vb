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
    '各ファイルパス
    '*********************************************************************
    Public gstrAppFilePath As String            '自exeパス
    Public gstrApplicationDataPath As String    'カレントユーザーApplicationDataパス
    Public gstrlogFilePath As String            '各種ログファイルパス
    Public gstrLogFileName As String            'ログファイルパス
    Public gstrSettingFilePath As String        '個別設定ファイルパス
    Public gstrExecuteLogFileName As String     '処理実行ログファイルパス

    '*********************************************************************
    '各戻値
    '*********************************************************************
    Public gintMsg As Integer                   'Msgbox戻値
    Public gblRtn As Boolean                    'Bool型戻値
    Public gintRtn As Integer                   'int型戻値
    Public gstrDate As String                   '日付型戻値
    Public gstrRtn As String                    '文字列型戻値
    Public gintSQLCODE As Integer               'Oracleエラーコード
    Public gstrSQLERRM As String                'Oracleエラーメッセージ
    Public gstrセッション端末名 As String       'セッション情報(端末)
    Public gintセッションID As Integer          'セッション情報(ID)

    '*********************************************************************
    'ソリューション変数
    '*********************************************************************
    Public gintSPDシステムコード As Integer     'SPDシステムコード
    Public gstrFormID As String                 '各FormID
    Public gstrFormTitle As String              '各Formタイトル
    Public gstr担当者名 As String               '担当者名
    Public gstr部門名 As String                 '部門名
    Public gstr得意先名 As String               '得意先名

    '*********************************************************************
    'レコードカウント変数
    '*********************************************************************
    Public gint取込データCnt As Integer         '取込データ数
    Public gint掲示版Cnt As Integer             '取得掲示板数
    Public gintResultCnt As Integer             '検索結果件数
    Public gint需要先Cnt As Integer             '取得需要先数
    Public gint得意先Cnt As Integer             '取得得意先数
    Public gint事業所Cnt As Integer             '取得需要先数
    Public gintサブプログラムCnt As Integer     '取得サブプログラム数
    Public gintPHsmos医療機関Cnt As Integer     '取得PHsmos医療機関数
    Public gin施設Cnt As Integer                '取得天神会SPD施設数
    Public gintErrorExportDataCnt As Integer    'エラーデータ出力件数
    Public gintErrorSendDataCnt As Integer      'エラーデータ送信件数
    Public gintExcelDataCnt As Integer          '読込EXCELデータ件数
    Public gint名称辞書Cnt As Integer           '名称辞書件数
    Public gint項目辞書Cnt As Integer           '項目辞書件数

    '*********************************************************************
    'プログラム情報変数
    '*********************************************************************
    Public gintDLTP0997S_FUNC004 As Integer     'プログラム個別情報NUMBER型戻値
    Public gstrDLTP0997S_FUNC005 As String      'プログラム個別情報VARCHAR型戻値
    Public gintKeyControl01 As Integer          'キー制御フラグ

End Module
