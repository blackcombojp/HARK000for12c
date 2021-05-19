'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Imports HARK000.HARK_DBCommon
Imports HARK000.HARK_Common
Imports HARK000.HARK_Sub
Imports System.ComponentModel

Public Class HARK100S2
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　フォーム読み込み処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Cursor = Cursors.WaitCursor

            'フォームキャプション設定
            Text = Set_FormTitle(xxxstrProgram_ID, xxxstrForTitle)

            '各種情報表示
            SttBar_2.Text = gstr担当者名
            SttBar_3.Text = "Ver : " & Application.ProductVersion

            'コンボに値設定
            Set_CmbValue()

            '初期化
            Initialize()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　画面アクティブ時処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try

            xxx初期コントロール.Focus()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw
        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *  モジュール機能　： 「終了」ボタンクリック時処理
    ' *
    ' *  注意、制限事項  ：なし
    ' *  引数　　　　　　：sender・・オブジェクト識別クラス
    ' *      　　　　　　：e・・イベントデータクラス
    ' *　戻値　　　　　　：なし
    ' *-----------------------------------------------------------------------------/ 
    Private Sub Bt_Close_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Close.Click

        Try

            'メモリ開放
            GC.Collect()
            OraTrnRollBack()
            Me.Close()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　「×」ボタンクリック
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Try

            'メモリ開放
            GC.Collect()
            OraTrnRollBack()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)


        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *  モジュール機能　： キーダウン処理
    ' *
    ' *  注意、制限事項  ：なし
    ' *  引数　　　　　　：sender・・オブジェクト識別クラス
    ' *      　　　　　　：e・・イベントデータクラス
    ' *　戻値　　　　　　：なし
    ' *-----------------------------------------------------------------------------/ 
    Private Sub Txt_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        Try

            '[Enter]キー判別
            If e.KeyCode = Keys.Enter Then

                'TabIndexの次のコントロールへフォーカス移動
                SelectNextControl(ActiveControl, True, True, True, True)
                e.Handled = True

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　コンボボックスに値をセット
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub Set_CmbValue()

        Try

            '取込除外区分
            cmb取込除外区分.Items.Add("対象外")
            cmb取込除外区分.Items.Add("対象")

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　コンボボックス選択時処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Cmb_SelectedValueChanged(sender As Object, e As EventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, ComboBox).Tag)

            Select Case Tag

                Case "ID1" '取込除外区分

                    xxxint取込除外区分 = cmb取込除外区分.SelectedIndex

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　各種コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize()

        Try

            Select Case xxxstrProgram_ID

                Case "HARKP102" 'KMC EDI受注

                    txt得意先コード.Text = ""
                    txt需要先コード.Text = ""
                    lbl得意先名.Text = ""
                    lbl需要先名.Text = ""
                    txt商品コード.Text = ""
                    txt相手先商品コード.Text = ""

                    txt得意先コード.Enabled = False
                    txt需要先コード.Enabled = False
                    txt商品コード.Enabled = False
                    txt相手先商品コード.Enabled = True

                    xxx初期コントロール = txt相手先商品コード

                Case "HARKP105" 'PHsmos連携

                    txt得意先コード.Text = ""
                    txt需要先コード.Text = ""
                    lbl得意先名.Text = ""
                    lbl需要先名.Text = ""
                    txt商品コード.Text = ""
                    txt相手先商品コード.Text = ""

                    txt得意先コード.Enabled = True
                    txt需要先コード.Enabled = True
                    txt商品コード.Enabled = True
                    txt相手先商品コード.Enabled = False

                    xxx初期コントロール = txt得意先コード

                Case "HARKP106", "HARKP107" '徳洲会連携 汎用連携

                    txt得意先コード.Text = ""
                    txt需要先コード.Text = ""
                    lbl得意先名.Text = ""
                    lbl需要先名.Text = ""
                    txt商品コード.Text = ""
                    txt相手先商品コード.Text = ""

                    txt得意先コード.Enabled = True
                    txt需要先コード.Enabled = True
                    txt商品コード.Enabled = False
                    txt相手先商品コード.Enabled = True

                    xxx初期コントロール = txt得意先コード

                Case Else

                    txt得意先コード.Text = ""
                    txt需要先コード.Text = ""
                    lbl得意先名.Text = ""
                    lbl需要先名.Text = ""
                    txt商品コード.Text = ""
                    txt相手先商品コード.Text = ""

                    txt得意先コード.Enabled = True
                    txt需要先コード.Enabled = True
                    txt商品コード.Enabled = True
                    txt相手先商品コード.Enabled = True

                    xxx初期コントロール = txt得意先コード

            End Select

            Initialize明細()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　明細コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize明細()

        Try

            cmb取込除外区分.SelectedIndex = 0
            lblID.Text = ""

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　FUNCTIONキー押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            Select Case e.KeyCode

                Case Keys.F1
                    '帳票
                    BT_ID1.PerformClick()
                Case Keys.F2
                    'なし
                    BT_ID2.PerformClick()
                Case Keys.F3
                    'クリア
                    BT_ID3.PerformClick()
                Case Keys.F4
                    'ログ
                    'BT_ID4.PerformClick()
                Case Keys.F5
                    '実行
                    BT_ID5.PerformClick()
                Case Keys.F6
                    'なし
                    BT_ID6.PerformClick()
                Case Keys.F7
                    'なし
                    BT_ID7.PerformClick()
                Case Keys.F8
                    'なし
                    BT_ID8.PerformClick()
                Case Keys.F12
                    '終了
                    Bt_Close_Click(Nothing, Nothing)

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　テキストボックスキー押下処理
    ' *
    ' *　注意、制限事項　：　タブ移動させたくないコントロールのみにハンドリングすること
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub Txt_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Editors.GcTextBox).Tag)

            Select Case Tag

                Case "ID1"  '得意先コード

                    If e.Shift = True AndAlso xxx初期コントロール.Name = "txt得意先コード" Then

                        Select Case e.KeyCode

                            'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

                Case "ID3" '商品コード

                    If e.Shift = True AndAlso xxx初期コントロール.Name = "txt商品コード" Then

                        Select Case e.KeyCode

                            'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

                Case "ID4" '相手先商品コード

                    If e.Shift = True AndAlso xxx初期コントロール.Name = "txt相手先商品コード" Then

                        Select Case e.KeyCode

                            'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　コンボボックスキー押下処理
    ' *
    ' *　注意、制限事項　：　タブ移動させたくないコントロールのみにハンドリングすること
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub Cmb_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, ComboBox).Tag)

            Select Case Tag

                Case "ID1"  '取込除外区分

                    If e.Shift = True And xxx初期コントロール.Enabled = False Then

                        Select Case e.KeyCode

                                'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    ElseIf e.Shift = False Then

                        Select Case e.KeyCode

                                'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　操作ログボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Menu_Log_Click(sender As Object, e As EventArgs) Handles Menu_Log.Click

        If Chk_FileExists(gstrExecuteLogFileName) = True Then

            'ログファイルを開く
            Process.Start(gstrExecuteLogFileName)

        Else

            MsgBox(MSG_COM002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
            txt得意先コード.Focus()
            Exit Sub

        End If

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　エラーログボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Menu_ErrorLog_Click(sender As Object, e As EventArgs) Handles Menu_ErrorLog.Click

        If Chk_FileExists(gstrLogFileName) = True Then

            'ログファイルを開く
            Process.Start(gstrLogFileName)

        Else

            MsgBox(MSG_COM002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
            txt得意先コード.Focus()
            Exit Sub

        End If

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　PRINTSCREENキー押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp

        'PrintScreenキーは無効
        If gintKeyControl01 = 1 AndAlso e.KeyCode = Keys.PrintScreen Then Clipboard.SetDataObject(MSG_COM006, True)

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　各種機能ボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Bt_ID_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim Tag As String
        Dim strSendFile As String = Nothing

        Try
            'Oracle接続状態確認
            If (OraConnectState(gintRtn, gintSQLCODE, gstrSQLERRM)) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM004 & vbCr & MSG_COM903, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            Tag = CStr(CType(sender, Button).Tag)

            Select Case Tag

                Case "ID1" 'なし
                Case "ID2" 'なし
                Case "ID3" 'クリア

                    gintRtn = MsgBox(MSG_COM001, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbYes Then

                        Initialize()
                        OraTrnRollBack()
                        txt得意先コード.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmb取込除外区分.Focus()
                        Exit Sub

                    End If

                    gblRtn = パラメータ設定処理()


                    gintRtn = DLTP0100S_PROC0026(xxxstrProgram_ID,
                                                xxxintSubProgram_ID,
                                                xxxintSPDSystemCode,
                                                xxxint新規区分,
                                                xxxstr商品コード,
                                                xxxstr相手先商品コード,
                                                xxxlng得意先コード,
                                                xxxlng需要先コード,
                                                CLng(lblID.Text.Trim),
                                                gintSQLCODE,
                                                gstrSQLERRM)

                    If gintRtn = 0 Then
                        MsgBox(MSG_992011, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    Else
                        MsgBox(MSG_992012 & vbCr & gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                    End If

                    Initialize()
                    txt得意先コード.Focus()

                    Exit Sub

                Case "ID6" 'なし
                Case "ID7" 'なし
                Case "ID8" 'なし

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　処理実行前チェック処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 実行前チェック処理() As Boolean

        Try

            実行前チェック処理 = False

            Select Case xxxstrProgram_ID

                Case "HARKP102" 'KMC EDI受注

                    '相手先商品コード
                    If IsNull(txt相手先商品コード.Text.Trim) = True Then
                        MsgBox(MSG_100001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt相手先商品コード.Focus()
                        Exit Function
                    End If

                Case "HARKP105" 'PHsmos連携

                    '得意先コード
                    If IsNull(txt得意先コード.Text.Trim) = True Then
                        MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt得意先コード.Focus()
                        Exit Function
                    End If

                    '需要先コード
                    If IsNull(txt需要先コード.Text.Trim) = True Then
                        MsgBox(MSG_992002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt需要先コード.Focus()
                        Exit Function
                    End If

                    '商品コード
                    If IsNull(txt商品コード.Text.Trim) = True Then
                        MsgBox(MSG_100002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt商品コード.Focus()
                        Exit Function
                    End If

                Case "HARKP106", "HARKP107" '徳洲会連携 汎用連携

                    '得意先コード
                    If IsNull(txt得意先コード.Text.Trim) = True Then
                        MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt得意先コード.Focus()
                        Exit Function
                    End If

                    '需要先コード
                    If IsNull(txt需要先コード.Text.Trim) = True Then
                        MsgBox(MSG_992002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt需要先コード.Focus()
                        Exit Function
                    End If

                    '相手先商品コード
                    If IsNull(txt相手先商品コード.Text.Trim) = True Then
                        MsgBox(MSG_100001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt相手先商品コード.Focus()
                        Exit Function
                    End If

            End Select

            実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　データ表示処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ表示処理() As Boolean

        Try

            データ表示処理 = False

            Initialize明細()

            lblID.Text = Results(0).strBuff(0)
            cmb取込除外区分.SelectedIndex = CInt(Results(0).strBuff(1))

            データ表示処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　パラメータ設定処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function パラメータ設定処理() As Boolean

        Try

            パラメータ設定処理 = False

            xxxlng得意先コード = DUMMY_LNGCODE
            xxxlng需要先コード = DUMMY_LNGCODE
            xxxstr商品コード = DUMMY_STRNULL
            xxxstr相手先商品コード = DUMMY_STRNULL

            If IsNull(txt得意先コード.Text.Trim) = False Then xxxlng得意先コード = CLng(txt得意先コード.Text.Trim)
            If IsNull(txt需要先コード.Text.Trim) = False Then xxxlng需要先コード = CLng(txt需要先コード.Text.Trim)
            If IsNull(txt商品コード.Text.Trim) = False Then xxxstr商品コード = txt商品コード.Text.Trim
            If IsNull(txt相手先商品コード.Text.Trim) = False Then xxxstr相手先商品コード = txt相手先商品コード.Text.Trim

            パラメータ設定処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　テキストボックスフォーカス検証後
    ' *
    ' *　注意、制限事項　：　タブ移動させたくないコントロールのみにハンドリングすること
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub Txt_Validated(ByVal sender As Object, ByVal e As EventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Editors.GcTextBox).Tag)


            Select Case Tag

                Case "ID1" '得意先コード

                    If IsNull(txt得意先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0003(xxxstrProgram_ID, CLng(txt得意先コード.Text.Trim), My.Settings.事業所コード, 1, gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txt得意先コード.Text = ""
                            lbl得意先名.Text = ""
                            txt得意先コード.Focus()
                        Else
                            lbl得意先名.Text = gstr得意先名
                        End If
                    Else
                        txt得意先コード.Text = ""
                        lbl得意先名.Text = ""
                    End If

                Case "ID2" '需要先コード

                    If IsNull(txt需要先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0003(xxxstrProgram_ID, CLng(txt需要先コード.Text.Trim), My.Settings.事業所コード, 2, gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txt需要先コード.Text = ""
                            lbl需要先名.Text = ""
                            txt需要先コード.Focus()
                        Else
                            lbl需要先名.Text = gstr得意先名
                        End If
                    Else
                        txt需要先コード.Text = ""
                        lbl需要先名.Text = ""
                    End If

                Case "ID3" '商品コード

                    If IsNull(txt商品コード.Text.Trim) = False Then

                        If txt相手先商品コード.Enabled = False Then

                            If txt得意先コード.Enabled = False Then
                                xxxlng得意先コード = DUMMY_LNGCODE
                                xxxlng需要先コード = DUMMY_LNGCODE
                            Else
                                If IsNull(txt得意先コード.Text.Trim) Then
                                    MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                    txt得意先コード.Focus()
                                    Exit Sub
                                End If
                                If IsNull(txt需要先コード.Text.Trim) Then
                                    MsgBox(MSG_992002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                    txt需要先コード.Focus()
                                    Exit Sub
                                End If
                                xxxlng得意先コード = CLng(txt得意先コード.Text.Trim)
                                xxxlng需要先コード = CLng(txt需要先コード.Text.Trim)
                            End If

                            gintRtn = DLTP0100S_PROC0025(xxxstrProgram_ID, xxxintSPDSystemCode, xxxintSubProgram_ID, txt商品コード.Text.Trim, vbNullString, xxxlng得意先コード, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn
                                Case 0
                                    gblRtn = データ表示処理()
                                    txt得意先コード.Enabled = False
                                    txt需要先コード.Enabled = False
                                    txt商品コード.Enabled = False
                                    txt相手先商品コード.Enabled = False
                                    xxxint新規区分 = 0
                                    cmb取込除外区分.Focus()
                                    Exit Sub
                                Case 2
                                    txt得意先コード.Enabled = False
                                    txt需要先コード.Enabled = False
                                    txt商品コード.Enabled = False
                                    txt相手先商品コード.Enabled = False
                                    xxxint新規区分 = 1
                                    lblID.Text = "0"
                                    cmb取込除外区分.Focus()
                                    Exit Sub
                                Case -54
                                    MsgBox(MSG_100003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                    Initialize()
                                    xxx初期コントロール.Focus()
                                    Exit Sub
                                Case Else
                                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                    Initialize()
                                    xxx初期コントロール.Focus()
                                    Exit Sub

                            End Select

                        End If

                    End If

                Case "ID4" '相手先商品コード

                    If IsNull(txt相手先商品コード.Text.Trim) = False Then

                        If txt得意先コード.Enabled = False Then
                            xxxlng得意先コード = DUMMY_LNGCODE
                            xxxlng需要先コード = DUMMY_LNGCODE
                        Else
                            If IsNull(txt得意先コード.Text.Trim) Then
                                MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                txt得意先コード.Focus()
                                Exit Sub
                            End If
                            If IsNull(txt需要先コード.Text.Trim) Then
                                MsgBox(MSG_992002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                txt需要先コード.Focus()
                                Exit Sub
                            End If
                            xxxlng得意先コード = CLng(txt得意先コード.Text.Trim)
                            xxxlng需要先コード = CLng(txt需要先コード.Text.Trim)
                        End If

                        gintRtn = DLTP0100S_PROC0025(xxxstrProgram_ID, xxxintSPDSystemCode, xxxintSubProgram_ID, vbNullString, txt相手先商品コード.Text.Trim, xxxlng得意先コード, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

                        Select Case gintRtn
                            Case 0
                                gblRtn = データ表示処理()
                                txt得意先コード.Enabled = False
                                txt需要先コード.Enabled = False
                                txt商品コード.Enabled = False
                                txt相手先商品コード.Enabled = False
                                xxxint新規区分 = 0
                                cmb取込除外区分.Focus()
                                Exit Sub
                            Case 2
                                txt得意先コード.Enabled = False
                                txt需要先コード.Enabled = False
                                txt商品コード.Enabled = False
                                txt相手先商品コード.Enabled = False
                                xxxint新規区分 = 1
                                lblID.Text = "0"
                                cmb取込除外区分.Focus()
                                Exit Sub
                            Case -54
                                MsgBox(MSG_100003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                Initialize()
                                xxx初期コントロール.Focus()
                                Exit Sub
                            Case Else
                                MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                Initialize()
                                xxx初期コントロール.Focus()
                                Exit Sub

                        End Select

                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub


End Class