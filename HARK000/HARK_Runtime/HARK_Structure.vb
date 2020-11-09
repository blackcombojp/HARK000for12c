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

    '名称辞書一覧
    Public Structure 名称辞書一覧

        Public strコード As String     'コード
        Public str名称 As String       '名称

        Public Overrides Function ToString() As String
            Return str名称
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As String)
            str名称 = NvlString(Name, CStr(IIf(CD = "0", "", CD)))
            strコード = CD
        End Sub

    End Structure


    '項目辞書一覧
    Public Structure 項目辞書一覧

        Public intコード As Integer    'コード
        Public str名称 As String       '名称

        Public Overrides Function ToString() As String
            Return str名称
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            str名称 = Name
            intコード = CD
        End Sub

    End Structure


    'サブプログラム一覧
    Public Structure サブプログラム一覧

        Public intサブプログラムコード As Integer   'サブプログラムコード
        Public strサブプログラム名 As String        'サブプログラム名

        Public Overrides Function ToString() As String
            Return strサブプログラム名
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            strサブプログラム名 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            intサブプログラムコード = CD
        End Sub

    End Structure


    '得意先一覧
    Public Structure 得意先一覧

        Public lng得意先コード As Long      '得意先コード
        Public str得意先名 As String        '得意先名

        Public Overrides Function ToString() As String
            Return str得意先名
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Long)
            str得意先名 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            lng得意先コード = CD
        End Sub

    End Structure


    '需要先一覧
    Public Structure 需要先一覧

        Public lng需要先コード As Long      '需要先コード
        Public str需要先名 As String        '需要先名

        Public Overrides Function ToString() As String
            Return str需要先名
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Long)
            str需要先名 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            lng需要先コード = CD
        End Sub

    End Structure


    '事業所一覧
    Public Structure 事業所一覧

        Public int事業所コード As Integer   '事業所コード
        Public str事業所名 As String        '事業所名

        Public Overrides Function ToString() As String
            Return str事業所名
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As Integer)
            str事業所名 = NvlString(Name, CStr(IIf(CD = 0, "", CStr(CD))))
            int事業所コード = CD
        End Sub

    End Structure


    '掲示板一覧
    Public Structure 掲示板一覧

        Public str掲示情報 As String        '掲示情報

        Public Overrides Function ToString() As String
            Return str掲示情報
        End Function

        Public Sub New(ByVal Name As String)
            str掲示情報 = Name
        End Sub

    End Structure


    '取込データ
    Public Structure 取込データ一覧

        Public intRec_ID As Integer    '取込データ_ID
        Public strRecData As String    '取込データ

        Public Overrides Function ToString() As String
            Return strRecData
        End Function

        Public Sub New(ByVal Data As String, ByVal ID As Integer)
            strRecData = Data
            intRec_ID = ID
        End Sub

    End Structure


    'PHsmos医療機関一覧
    Public Structure PHsmos医療機関一覧

        Public str医療機関コード As String    '医療機関コード
        Public str医療機関名 As String        '医療機関名

        Public Overrides Function ToString() As String
            Return str医療機関名
        End Function

        Public Sub New(ByVal Name As String, ByVal CD As String)
            str医療機関名 = NvlString(Name, CStr(IIf(CD = "", "", CD)))
            str医療機関コード = CD
        End Sub

    End Structure


    '処理端末情報
    Public Structure Struc_処理端末情報
        Dim str出力先１ As String
        Dim str出力先２ As String
        Dim str出力先３ As String
        Dim str出力先４ As String
        Dim str出力先５ As String
        Public Sub IsClear()

            str出力先１ = vbNullString
            str出力先２ = vbNullString
            str出力先３ = vbNullString
            str出力先４ = vbNullString
            str出力先５ = vbNullString

        End Sub
    End Structure


    '長期貸出番号情報
    Public Structure Struc_長期貸出番号情報
        Dim lng長期貸出番号 As Long
        Dim str出荷日 As String
        Dim str受注形態 As String
        Dim str需要先名 As String
        Dim str需要先部署名 As String
        Dim str商品コード As String
        Dim strメーカ名 As String
        Dim strメーカ品番 As String
        Dim str商品名 As String
        Dim str規格 As String
        Dim str有効期限 As String
        Dim strロット As String
        Dim strシリアル As String
        Dim lng出荷数量 As Long
        Dim str出荷単位名 As String
        Dim str消費日 As String
        Dim str消費需要先名 As String
        Dim str消費需要先部署名 As String
        Dim str返却日 As String
        Public Sub IsClear()

            lng長期貸出番号 = DUMMY_LNGCODE
            str出荷日 = vbNullString
            str受注形態 = vbNullString
            str需要先名 = vbNullString
            str需要先部署名 = vbNullString
            str商品コード = vbNullString
            strメーカ名 = vbNullString
            strメーカ品番 = vbNullString
            str商品名 = vbNullString
            str規格 = vbNullString
            str有効期限 = vbNullString
            strロット = vbNullString
            strシリアル = vbNullString
            lng出荷数量 = DUMMY_LNGCODE
            str出荷単位名 = vbNullString
            str消費日 = vbNullString
            str消費需要先名 = vbNullString
            str消費需要先部署名 = vbNullString
            str返却日 = vbNullString

        End Sub
    End Structure


    '結果表示用得意先一覧
    Public Structure Struc_結果表示用得意先一覧
        Public strRecData As String    '得意先一覧
    End Structure


    '検索結果一覧
    Public Structure Result
        Public strBuff() As String
    End Structure


    Public サブプログラムArray() As サブプログラム一覧
    Public 需要先Array() As 需要先一覧
    Public 得意先Array() As 得意先一覧
    Public 取込データArray() As 取込データ一覧
    Public 事業所Array() As 事業所一覧
    Public 掲示板Array() As 掲示板一覧
    Public PHsmos医療機関Array() As PHsmos医療機関一覧
    Public 名称辞書Array() As 名称辞書一覧
    Public 項目辞書Array() As 項目辞書一覧

    Public Results() As Result
    Public 結果表示用得意先一覧Array() As Struc_結果表示用得意先一覧

    Public gudt処理端末情報 As Struc_処理端末情報
    Public gudt長期貸出番号情報 As Struc_長期貸出番号情報

End Module
