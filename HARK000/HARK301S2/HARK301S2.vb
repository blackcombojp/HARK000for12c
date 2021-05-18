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

Public Class HARK301S2
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　フォーム読み込み処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim str備考 As String

        Try
            Cursor = Cursors.WaitCursor

            gcmr一覧.ViewMode = GrapeCity.Win.MultiRow.ViewMode.Row           '行選択
            gcmr一覧.MultiSelect = False

            'フォームキャプション設定
            Text = Set_FormTitle(xxxstrProgram_ID, xxxstrForTitle)

            '各種情報表示
            SttBar_2.Text = gstr担当者名
            SttBar_3.Text = "Ver : " & Application.ProductVersion

            '備考取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 0, 1, "備考")
            str備考 = gstrDLTP0997S_FUNC005

            If str備考 <> "null" Then lbl備考.Text = str備考 Else lbl備考.Visible = False

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
            txtメーカコード.Focus()

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
    ' *　モジュール機能　：　各種コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize()

        Try
            txtメーカコード.Text = ""
            lblメーカ名.Text = ""
            txtメーカ品番.Text = ""
            txt商品コード.Text = ""

            txtメーカコード.Enabled = True
            txtメーカ品番.Enabled = True
            txt商品コード.Enabled = True

            HARK301S2DS.ds一覧.Clear()

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

                Case "ID1"  'メーカコード

                    If e.Shift = True Then

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
            txtメーカコード.Focus()
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
            txtメーカコード.Focus()
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
                        txtメーカコード.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" 'なし
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
    ' *　モジュール機能　：　データ表示処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ表示処理() As Boolean

        Dim intRowCnt As Integer

        Try

            データ表示処理 = False

            HARK301S2DS.ds一覧.Clear()

            For intRowCnt = 0 To gintResultCnt - 1

                HARK301S2DS.ds一覧.Addds一覧Row(CInt(Results(intRowCnt).strBuff(0)),
                                                  Results(intRowCnt).strBuff(1),
                                                  CInt(Results(intRowCnt).strBuff(2)),
                                                  CLng(Results(intRowCnt).strBuff(3)),
                                                  Results(intRowCnt).strBuff(4),
                                                  CInt(Results(intRowCnt).strBuff(5)),
                                                  Results(intRowCnt).strBuff(6),
                                                  Results(intRowCnt).strBuff(7),
                                                  CLng(Results(intRowCnt).strBuff(8)),
                                                  Results(intRowCnt).strBuff(9),
                                                  Results(intRowCnt).strBuff(10),
                                                  Results(intRowCnt).strBuff(11),
                                                  Results(intRowCnt).strBuff(12),
                                                  CInt(Results(intRowCnt).strBuff(13)),
                                                  Results(intRowCnt).strBuff(14),
                                                  CInt(Results(intRowCnt).strBuff(15)),
                                                  Results(intRowCnt).strBuff(16),
                                                  CInt(Results(intRowCnt).strBuff(17)),
                                                  CLng(Results(intRowCnt).strBuff(18)),
                                                  CLng(Results(intRowCnt).strBuff(19)),
                                                  Results(intRowCnt).strBuff(20),
                                                  CLng(Results(intRowCnt).strBuff(21)),
                                                  CLng(Results(intRowCnt).strBuff(22)),
                                                  CLng(Results(intRowCnt).strBuff(23)),
                                                  CLng(Results(intRowCnt).strBuff(24)))

            Next

            データ表示処理 = True

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

                Case "ID1" 'メーカコード

                    If IsNull(txtメーカコード.Text.Trim) = False Then

                        If DLTP0900_PROC0005(xxxstrProgram_ID, CLng(txtメーカコード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txtメーカコード.Text = ""
                            lblメーカ名.Text = ""
                            txtメーカコード.Focus()
                        Else
                            lblメーカ名.Text = gstrメーカ名
                        End If
                    Else
                        txtメーカコード.Text = ""
                        lblメーカ名.Text = ""
                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　明細部フォーカス取得
    ' *
    ' *　注意、制限事項　：　明細データ検索
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub gcmr一覧_Enter(sender As Object, e As EventArgs) Handles gcmr一覧.Enter

        Dim xxxintメーカコード As Integer
        Dim xxxstrメーカ品番 As String
        Dim xxxstr商品コード As String

        Try

            If HARK301S2DS.ds一覧.Count > 0 Then Exit Sub

            If IsNull(txtメーカコード.Text.Trim) And IsNull(txtメーカ品番.Text.Trim) And IsNull(txt商品コード.Text.Trim) Then
                MsgBox(MSG_301052, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtメーカコード.Focus()
                Exit Sub
            Else

                If IsNull(txtメーカコード.Text.Trim) Then xxxintメーカコード = DUMMY_INTCODE Else xxxintメーカコード = CInt(txtメーカコード.Text.Trim)
                If IsNull(txtメーカ品番.Text.Trim) Then xxxstrメーカ品番 = DUMMY_STRCODE Else xxxstrメーカ品番 = txtメーカ品番.Text.Trim
                If IsNull(txt商品コード.Text.Trim) Then xxxstr商品コード = DUMMY_STRCODE Else xxxstr商品コード = txt商品コード.Text.Trim

                Cursor = Cursors.WaitCursor

                gintRtn = DLTP0301_PROC0017(xxxstrProgram_ID, xxxintSPDSystemCode, xxxintSubProgram_ID, xxxintメーカコード, xxxstrメーカ品番, txt商品コード.Text.Trim, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        gblRtn = データ表示処理()
                        txtメーカコード.Enabled = False
                        txtメーカ品番.Enabled = False
                        txt商品コード.Enabled = False
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        Initialize()
                        txtメーカコード.Focus()
                        Exit Sub
                    Case Else
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Initialize()
                        txtメーカコード.Focus()
                        Exit Sub

                End Select

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub

End Class