'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Imports System.IO
Imports System.Text

<Serializable()>
Public Class HARK_Xml

    '設定を保存するフィールド
    Private _送信保存先 As String
    Private _送信元アドレス As String
    Private _送信元サーバ As String
    Private _送信元ポート As Integer
    Private _送信添付ファイル名 As String
    Private _送信タイトル As String
    Private _送信先アドレス1 As String
    Private _送信先アドレス2 As String
    Private _送信先アドレス3 As String
    Private _送信先アドレス4 As String
    Private _送信先アドレス5 As String
    '設定のプロパティ
    Public Property 送信保存先() As String
        Get
            Return _送信保存先
        End Get
        Set(ByVal Value As String)
            _送信保存先 = Value
        End Set
    End Property
    Public Property 送信元アドレス() As String
        Get
            Return _送信元アドレス
        End Get
        Set(ByVal Value As String)
            _送信元アドレス = Value
        End Set
    End Property
    Public Property 送信元サーバ() As String
        Get
            Return _送信元サーバ
        End Get
        Set(ByVal Value As String)
            _送信元サーバ = Value
        End Set
    End Property
    Public Property 送信元ポート() As Integer
        Get
            Return _送信元ポート
        End Get
        Set(ByVal Value As Integer)
            _送信元ポート = Value
        End Set
    End Property
    Public Property 送信添付ファイル名() As String
        Get
            Return _送信添付ファイル名
        End Get
        Set(ByVal Value As String)
            _送信添付ファイル名 = Value
        End Set
    End Property
    Public Property 送信タイトル() As String
        Get
            Return _送信タイトル
        End Get
        Set(ByVal Value As String)
            _送信タイトル = Value
        End Set
    End Property
    Public Property 送信先アドレス1() As String
        Get
            Return _送信先アドレス1
        End Get
        Set(ByVal Value As String)
            _送信先アドレス1 = Value
        End Set
    End Property
    Public Property 送信先アドレス2() As String
        Get
            Return _送信先アドレス2
        End Get
        Set(ByVal Value As String)
            _送信先アドレス2 = Value
        End Set
    End Property
    Public Property 送信先アドレス3() As String
        Get
            Return _送信先アドレス3
        End Get
        Set(ByVal Value As String)
            _送信先アドレス3 = Value
        End Set
    End Property
    Public Property 送信先アドレス4() As String
        Get
            Return _送信先アドレス4
        End Get
        Set(ByVal Value As String)
            _送信先アドレス4 = Value
        End Set
    End Property
    Public Property 送信先アドレス5() As String
        Get
            Return _送信先アドレス5
        End Get
        Set(ByVal Value As String)
            _送信先アドレス5 = Value
        End Set
    End Property
    'コンストラクタ
    Public Sub New()
        _送信保存先 = "String"
        _送信元アドレス = "String"
        _送信元サーバ = "String"
        _送信元ポート = 0
        _送信添付ファイル名 = "String"
        _送信タイトル = "String"
        _送信先アドレス1 = "String"
        _送信先アドレス2 = ""
        _送信先アドレス3 = ""
        _送信先アドレス4 = ""
        _送信先アドレス5 = ""
    End Sub
    ''' <summary>
    ''' HARK_Xmlクラスインスタンス
    ''' </summary>
    <NonSerialized()>
    Private Shared _instance As HARK_Xml
    <Xml.Serialization.XmlIgnore()>
    Public Shared Property Instance() As HARK_Xml
        Get
            If _instance Is Nothing Then
                _instance = New HARK_Xml
            End If
            Return _instance
        End Get
        Set(ByVal Value As HARK_Xml)
            _instance = Value
        End Set
    End Property
    ''' <summary>
    ''' 設定をXMLファイルから読み込み復元する
    ''' </summary>
    ''' <param name="PI_SettingFile">読込ファイルパス</param>
    Public Shared Sub LoadFromXmlFile(ByVal PI_SettingFile As String)

        Dim sr As New StreamReader(PI_SettingFile, New UTF8Encoding(False))
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(HARK_Xml))
        '読み込んで逆シリアル化する
        Dim obj As Object = xs.Deserialize(sr)
        sr.Close()

        Instance = CType(obj, HARK_Xml)

    End Sub
    ''' <summary>
    ''' 現在の設定をXMLファイルに保存する
    ''' </summary>
    ''' <param name="PI_SettingFile">書込ファイルパス</param>
    Public Shared Sub SaveToXmlFile(ByVal PI_SettingFile As String)

        Dim sw As New StreamWriter(PI_SettingFile, False, New UTF8Encoding(False))
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(HARK_Xml))
        'シリアル化して書き込む
        xs.Serialize(sw, Instance)
        sw.Close()

    End Sub

End Class
