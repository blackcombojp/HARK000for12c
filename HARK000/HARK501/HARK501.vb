﻿'/*-----------------------------------------------------------------------------
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
Imports AdvanceSoftware.ExcelCreator
Imports System.ComponentModel
Imports NPOI.SS.UserModel
Imports System.IO


Public Class HARK501
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
            txt入力担当コード.Text = CStr(IIf(My.Settings.入力担当コード = 0, "", My.Settings.入力担当コード))
            SttBar_2.Text = gstr担当者名
            SttBar_3.Text = "Ver : " & Application.ProductVersion

            If DLTP0000_PROC0005(xxxstrProgram_ID, gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtデータ出力先.Text = Get_DesktopPath()
            End If

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
    ' *　モジュール機能　：　初回起動時処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
            '初期フォーカスを項目に設定
            cmbサブプログラム.Focus()

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

            My.Settings.事業所コード = xxxint事業所コード
            gstr担当者名 = xxxstr担当者名
            gudt処理端末情報.IsClear()

            'メモリ開放
            GC.Collect()
            '前画面表示
            xxxmForm.Show()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally
            '自画面破棄
            If Not Me Is Nothing Then
                Dispose()
            End If
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

            My.Settings.事業所コード = xxxint事業所コード
            gstr担当者名 = xxxstr担当者名
            gudt処理端末情報.IsClear()

            'メモリ開放
            GC.Collect()
            '前画面表示
            xxxmForm.Show()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally
            '自画面破棄
            If Not Me Is Nothing Then
                Dispose()
            End If
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

        Dim i As Integer

        Try

            '事業所一覧
            For i = 0 To gint事業所Cnt - 1

                cmb事業所.Items.Add(New 事業所一覧(事業所Array(i).str事業所名, 事業所Array(i).int事業所コード))

            Next

            '空白行追加
            cmb事業所.Items.Add(New 事業所一覧("", 0))

            'サブプログラム一覧取得
            If DLTP0901_PROC0002(xxxstrProgram_ID, gintSPDシステムコード, gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            'サブプログラム一覧
            For i = 0 To gintサブプログラムCnt - 1

                cmbサブプログラム.Items.Add(New サブプログラム一覧(サブプログラムArray(i).strサブプログラム名, サブプログラムArray(i).intサブプログラムコード))

            Next

            '空白行追加
            cmbサブプログラム.Items.Add(New サブプログラム一覧("", 0))


        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

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

            '事業所コンボ制御
            If My.Settings.事業所コード = 0 Then
                xxxint事業所コード = 0
                cmb事業所.Enabled = True
                cmb事業所.SelectedIndex = gint事業所Cnt
            Else
                xxxint事業所コード = My.Settings.事業所コード
                cmb事業所.Enabled = False
                cmb事業所.Text = gstr部門名
            End If

            '担当者コンボ制御
            If My.Settings.入力担当コード = 0 Then
                txt入力担当コード.Enabled = True
            Else
                txt入力担当コード.Enabled = False
            End If

            xxxstr担当者名 = gstr担当者名

            'メッセージリストボックス初期化
            lb_Msg.Items.Clear()

            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt

            txt取込ファイル.Text = ""
            txtデータ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　各種コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　区分・・サブプログラムID
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize条件(ByVal int区分 As Integer)

        Try

            Select Case int区分

                Case 1 'SPD採用情報マスタ更新処理

                    lbl取込ファイル.Text = "【採用商品リストファイル】"
                    txt取込ファイル.Text = ""
                    txt取込ファイル.Enabled = True
                    btnファイル参照.Enabled = True
                    txtデータ出力先.Enabled = True
                    btnフォルダ参照.Enabled = True


                Case Else

                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txt取込ファイル.Enabled = True
                    btnファイル参照.Enabled = True
                    txtデータ出力先.Enabled = True
                    btnフォルダ参照.Enabled = True

            End Select

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

                'Case "ID1"  '取込ファイル

                '    If e.Shift = True Then

                '        Select Case e.KeyCode

                '            'Tabキーが押されてもフォーカスが移動しないようにする
                '            Case Keys.Tab
                '                e.IsInputKey = True

                '        End Select

                '    End If

                Case "ID2"  'データ出力先

                    If e.Shift = False Then

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

                Case "ID1"  '事業所

                    Select Case e.KeyCode

                            'Tabキーが押されてもフォーカスが移動しないようにする
                        Case Keys.Tab
                            e.IsInputKey = True

                    End Select

                Case "ID2"  'サブプログラム

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

                Case "ID1" '事業所コンボボックス

                    With DirectCast(cmb事業所.SelectedItem, 事業所一覧)
                        My.Settings.事業所コード = .int事業所コード
                    End With

                    If DLTP0000_PROC0003(xxxstrProgram_ID, gintSQLCODE, gstrSQLERRM) = 0 Then
                        MsgBox(MSG_COM010 & vbCr & MSG_COM011, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        cmb事業所.SelectedIndex = gint事業所Cnt
                        My.Settings.事業所コード = 0
                        Exit Sub
                    End If

                    If My.Settings.事業所コード <> 0 Then
                        If DLTP0000_PROC0005(xxxstrProgram_ID, gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            txtデータ出力先.Text = Get_DesktopPath()
                        Else
                            txtデータ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))
                        End If
                    End If

                Case "ID2" 'サブプログラム

                    With DirectCast(cmbサブプログラム.SelectedItem, サブプログラム一覧)
                        xxxintSubProgram_ID = .intサブプログラムコード
                    End With

                    Initialize条件(xxxintSubProgram_ID)

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
            txt取込ファイル.Focus()
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
            txt取込ファイル.Focus()
            Exit Sub

        End If

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ファイル選択ダイアログ表示
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Btnファイル参照_Click(sender As Object, e As EventArgs) Handles btnファイル参照.Click

        Dim OFDlg As New OpenFileDialog
        Dim strFilter As String = Nothing

        Try

            Select Case xxxintSubProgram_ID

                Case 1 'SPD採用情報マスタ更新処理
                    strFilter = "xlsx Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"

                Case Else
                    Exit Sub

            End Select

            OFDlg.InitialDirectory = Get_DesktopPath()
            OFDlg.Filter = strFilter
            OFDlg.FilterIndex = 1
            OFDlg.RestoreDirectory = True

            If OFDlg.ShowDialog() = DialogResult.OK Then

                txt取込ファイル.Text = OFDlg.FileName
                txtデータ出力先.Focus()

            Else

                txt取込ファイル.Text = ""
                txt取込ファイル.Focus()

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　フォルダ選択ダイアログ表示
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Btnフォルダ参照_Click(sender As Object, e As EventArgs) Handles btnフォルダ参照.Click

        Dim FDDlg As New FolderBrowserDialog
        Dim Tag As String

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Buttons.GcButton).Tag)

            Select Case Tag

                Case "ID1" 'データ出力先

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txtデータ出力先.Text = ""
                        txtデータ出力先.Text = FDDlg.SelectedPath

                    End If

                Case Else

                    Exit Sub

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

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
    ' *　モジュール機能　：　ListBoxにメッセージを表示
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　line・・メッセージ区分
    ' *　引数２　　　　　：　msg・・メッセージ本文
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Set_ListItem(ByVal Line As Integer, ByVal msg As String)

        Dim DateTime As String

        'スタートライン
        If Line = 0 Then

            lb_Msg.Items.Add("------------------------------------------------------------------------")
            log.Info("------------------------------------------------------------------------")

            lb_Msg.SelectedIndex = lb_Msg.Items.Count - 2

            '文字列
        ElseIf Line = 1 Then

            DateTime = CType(Microsoft.VisualBasic.Format(Now(), "yyyy/MM/dd HH:mm:ss"), String)

            lb_Msg.Items.Add(DateTime & "  " & msg)
            log.Info(msg)
            lb_Msg.SelectedIndex = lb_Msg.Items.Count - 1

            'エンドライン
        ElseIf Line = 2 Then

            lb_Msg.Items.Add("------------------------------------------------------------------------")
            log.Info("------------------------------------------------------------------------")

            lb_Msg.SelectedIndex = lb_Msg.Items.Count - 1

        End If

        Refresh()

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　EXCELCreaterコンポーネントエラー処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub ExcelCreator_Error(sender As Object, e As CreatorErrorEventArgs) Handles ExcelCreator.Error

        Try

            log.Error(Set_ErrMSG(e.ErrorNo, ExcelCreator.ErrorMessage))
            Throw New Exception(e.ErrorNo.ToString & ":" & ExcelCreator.ErrorMessage)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

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
        'Dim m_lording As Thread = Nothing

        Try
            'Oracle接続状態確認
            If (OraConnectState(gintRtn, gintSQLCODE, gstrSQLERRM)) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM004 & vbCr & MSG_COM903, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            Tag = CStr(CType(sender, Button).Tag)

            Select Case Tag

                Case "ID1" 'なし
                Case "ID2" 'なし
                Case "ID3" 'クリア

                    gintRtn = MsgBox(MSG_COM001, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbYes Then

                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        Initialize条件(0)
                        lb_Msg.Items.Clear()
                        cmbサブプログラム.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        Initialize条件(0)
                        cmbサブプログラム.Focus()

                        Exit Sub

                    End If

                    Cursor = Cursors.WaitCursor

                    lb_Msg.Items.Add("")

                    ''処理中画面
                    'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                    '    .IsBackground = True
                    '}

                    'm_lording.Start()

                    Select Case xxxintSubProgram_ID

                        Case 1 'SPD採用情報マスタ更新処理

                            If Read_ExcelData(txt取込ファイル.Text.Trim) = False Then GoTo EndExecute

                            'テキスト取込
                            gintRtn = DLTP0501_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn

                                Case 0 '正常終了

                                    Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                                    Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                                    Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                                    Set_ListItem(1, MSG_501003)
                                    Set_ListItem(2, "")


                                Case 9 'エラー

                                    取込エラーファイル複製処理()

                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_501004)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")


                            End Select

                        Case Else

                            Exit Sub

                    End Select

EndExecute:
                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                    Initialize条件(0)
                    cmbサブプログラム.Focus()

                    Exit Sub


                Case "ID6" 'なし
                Case "ID7" 'なし
                Case "ID8" 'なし

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            ''処理中画面廃棄
            'If Not m_lording Is Nothing AndAlso m_lording.IsAlive Then
            '    m_lording.Abort()
            '    m_lording = Nothing
            'End If

            'メモリ開放
            GC.Collect()
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

            If IsNull(cmb事業所.Text.Trim) = True Then
                MsgBox(MSG_COM007, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb事業所.Focus()
                Exit Function
            End If

            If IsNull(txt入力担当コード.Text.Trim) = True Then
                MsgBox(MSG_COM008, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt入力担当コード.Focus()
                Exit Function
            End If

            If CLng(txt入力担当コード.Text.Trim) = 0 Then
                MsgBox(MSG_COM008, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt入力担当コード.Focus()
                Exit Function
            End If

            If DLTP0900_PROC0001(xxxstrProgram_ID, CLng(txt入力担当コード.Text.Trim), My.Settings.事業所コード, gintSQLCODE, gstrSQLERRM) = False Then
                If gintSQLCODE = 1 Then
                    MsgBox(MSG_COM009, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                Else
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                End If
                txt入力担当コード.Text = ""
                txt入力担当コード.Focus()
                Exit Function
            Else
                SttBar_2.Text = gstr担当者名
            End If

            'サブプログラムチェック
            If IsNull(cmbサブプログラム.Text.Trim) = True Then
                MsgBox(MSG_COM012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmbサブプログラム.Focus()
                Exit Function
            End If

            Select Case xxxintSubProgram_ID

                Case 1 'SPD採用情報マスタ更新処理

                    '取込ファイルチェック
                    If IsNull(txt取込ファイル.Text.Trim) = True Then
                        MsgBox(MSG_501001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    If Chk_FileExists(txt取込ファイル.Text.Trim) = False Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    If Not Get_FileNameWithoutExtension(txt取込ファイル.Text).Contains(HARKP501ImpFileName) Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    '拡張子比較
                    If Get_ExtensionEx(txt取込ファイル.Text).CompareTo(XLSXExtension) <> 0 Then
                        MsgBox(MSG_101103, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If


                Case Else

                    Exit Function

            End Select

            'とりあえず不要
            ''データ出力先チェック
            'If IsNull(txtデータ出力先.Text.Trim) = True Then
            '    MsgBox(MSG_301021, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
            '    txtデータ出力先.Focus()
            '    Exit Function
            'End If

            'If Chk_DirExists(txtデータ出力先.Text.Trim) = False Then
            '    MsgBox(MSG_301021, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
            '    txtデータ出力先.Text = ""
            '    txtデータ出力先.Focus()
            '    Exit Function
            'End If

            実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　テキスト取込処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　strFile 　　　-- ファイルパス
    ' *　引数２　　　　　：　blnHeaderLine -- 1行目はヘッダ行とみなす
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function テキスト取込処理(ByVal strFile As String) As Boolean

        'Dim SR As New StreamReader(strFile, System.Text.Encoding.GetEncoding(932))
        Dim SR As StreamReader = Nothing
        Dim i As Integer
        Dim blnFirstLine As Boolean
        Dim blnHeaderLine As Boolean
        Dim line As String

        Try

            テキスト取込処理 = False

            Select Case xxxintSubProgram_ID

                Case 1 'SPD採用情報マスタ更新処理
                    Exit Function

                Case 2 '
                    blnHeaderLine = False
                    Set_ListItem(0, "")
                    Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                    Set_ListItem(1, MSG_301014)


                Case Else
                    Set_ListItem(0, "")
                    Set_ListItem(1, "【不明】")
                    Set_ListItem(1, MSG_301014)
                    Set_ListItem(1, MSG_301016)
                    Set_ListItem(1, MSG_101109)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            blnFirstLine = True
            line = ""

            i = 0

            SR = New StreamReader(strFile, System.Text.Encoding.GetEncoding(932))

            While SR.Peek() > -1

                line = ""
                line = SR.ReadLine

                If blnHeaderLine = True Then
                    '1行目はヘッダの為、スキップ
                    If blnFirstLine = True Then
                        blnFirstLine = False
                        Continue While
                    End If
                End If

                ReDim Preserve 取込データArray(i)

                取込データArray(i).strRecData = line

                i += 1

            End While

            gint取込データCnt = i

            If gint取込データCnt = 0 Then
                Set_ListItem(1, MSG_301016)
                Set_ListItem(1, MSG_101109)
                Set_ListItem(2, "")
                Exit Function
            End If

            テキスト取込処理 = True

        Catch ex As FileNotFoundException

            Set_ListItem(1, MSG_301016)
            Set_ListItem(1, MSG_COM016)
            Set_ListItem(2, "")

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_301016 & vbCr & MSG_COM016, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As IOException

            Set_ListItem(1, MSG_301016)
            Set_ListItem(1, MSG_COM015)
            Set_ListItem(2, "")

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_301016 & vbCr & MSG_COM015, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As UnauthorizedAccessException

            Set_ListItem(1, MSG_301016)
            Set_ListItem(1, MSG_COM018)
            Set_ListItem(2, "")

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_301016 & vbCr & MSG_COM018, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As Exception

            Set_ListItem(1, MSG_301016)
            Set_ListItem(1, MSG_COM017)
            Set_ListItem(1, CStr(Err.Number))
            Set_ListItem(1, ex.ToString)
            Set_ListItem(2, "")

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If Not SR Is Nothing Then
                SR.Close()
                SR.Dispose()
            End If

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　各種Excelデータ読込
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　strExcelFilePath -- クオン採用商品リストExcel
    ' *　戻値　　　　　　：　True -- 正常終了 False -- 異常終了
    ' *-----------------------------------------------------------------------------/
    Private Function Read_ExcelData(ByVal strExcelFilePath As String) As Boolean

        Dim inputStream As FileStream = Nothing
        Dim lWBook As IWorkbook
        Dim lSheet As ISheet
        Dim lRow As IRow
        Dim lCell(9) As ICell
        Dim iRowCnt As Integer
        Dim i As Integer
        Dim iColCnt As Integer
        Dim strLineData As String

        Try

            Read_ExcelData = False

            Select Case xxxintSubProgram_ID

                Case 1 'Oliver取込処理エラー結果出力

                    Set_ListItem(0, "")
                    Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                    Set_ListItem(1, MSG_501002)


                Case Else
                    Set_ListItem(0, "")
                    Set_ListItem(1, "【不明】")
                    Set_ListItem(1, MSG_301014)
                    Set_ListItem(1, MSG_301016)
                    Set_ListItem(1, MSG_101109)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            'ファイルストリームで開く
            inputStream = New FileStream(strExcelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            lWBook = WorkbookFactory.Create(inputStream)

            lSheet = lWBook.GetSheetAt(0)

            i = 0
            gintExcelDataCnt = 0
            取込データArray = Nothing

            Select Case xxxintSubProgram_ID

                Case 1 'SPD採用情報マスタ更新処理

                    For iRowCnt = 0 To lSheet.LastRowNum

                        '1行目はヘッダの為、スキップ
                        If iRowCnt = 0 Then
                            Continue For
                        End If

                        strLineData = vbNullString

                        lRow = lSheet.GetRow(iRowCnt)      '行取得

                        lCell(0) = lRow.GetCell(3)      '院内コード
                        lCell(1) = lRow.GetCell(1)      '業者用コード
                        lCell(2) = lRow.GetCell(16)     '管理区分
                        lCell(3) = lRow.GetCell(8)      'ＪＡＮコード
                        lCell(4) = lRow.GetCell(18)     '採用開始日
                        lCell(5) = lRow.GetCell(19)     '採用中止日
                        lCell(6) = lRow.GetCell(5)      '商品名
                        lCell(7) = lRow.GetCell(6)      '規格
                        lCell(8) = lRow.GetCell(7)      '商品コード

                        For iColCnt = 0 To 8
                            'セルにデータがあれば格納
                            If lCell(iColCnt) IsNot Nothing Then
                                Select Case iColCnt
                                    Case 3
                                        If lCell(iColCnt).CellType = CellType.Numeric Then
                                            strLineData &= ","
                                        Else
                                            strLineData = strLineData & lCell(iColCnt).StringCellValue & ","
                                        End If
                                    Case 4, 5
                                        strLineData = strLineData & Replace(lCell(iColCnt).StringCellValue, "/", "") & ","
                                    Case 6, 7, 8
                                        strLineData = strLineData & """" & lCell(iColCnt).StringCellValue & """" & ","
                                    Case Else
                                        strLineData = strLineData & lCell(iColCnt).StringCellValue & ","
                                End Select
                            Else
                                strLineData &= ","
                            End If
                        Next

                        strLineData = strLineData.Substring(0, strLineData.Length - 1)

                        ReDim Preserve 取込データArray(i)

                        取込データArray(i).strRecData = strLineData

                        i += 1

                    Next

                Case Else

                    Exit Function

            End Select

            gintExcelDataCnt = i

            lWBook.Close()

            ' inputStream = Nothing

            Read_ExcelData = True

        Catch ex As FileNotFoundException

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM016, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As IOException

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM015, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As UnauthorizedAccessException

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM018, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
            'Throw

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        Finally

            If inputStream IsNot Nothing Then
                inputStream.Close()
                inputStream.Dispose()
            End If

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　取込エラーファイル複製
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub 取込エラーファイル複製処理()

        Dim strCopyFile As String

        Dim strBackupDir As String
        Dim strBackupFileName As String

        Try

            strBackupDir = Set_FilePath(gstrAppFilePath, "error\" & Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name)
            If Chk_DirExists(strBackupDir) = False Then gblRtn = Create_Dir(strBackupDir)

            strBackupFileName = Get_FileName(txt取込ファイル.Text)
            strCopyFile = strBackupDir & "\" & strBackupFileName
            If Chk_FileExists(strCopyFile) = True Then gintRtn = Delete_File(strCopyFile)

            File.Copy(txt取込ファイル.Text, strCopyFile)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
End Class