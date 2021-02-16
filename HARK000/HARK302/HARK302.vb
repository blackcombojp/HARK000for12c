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
Imports HARK000.HARK_Xml
Imports AdvanceSoftware.ExcelCreator
Imports System.ComponentModel
Imports System.IO


Public Class HARK302
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
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                txtエラー出力先.Text = Get_DesktopPath()
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
            '初期フォーカスを設定
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

            '現在の設定をXMLファイルに保存する
            '保存処理はしない
            'SaveToXmlFile(Set_FilePath(gstrSettingFilePath, xxxstrProgram_ID & CStr(xxxintSubProgram_ID) & ".config"))

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

            '現在の設定をXMLファイルに保存する
            '保存処理はしない
            'SaveToXmlFile(Set_FilePath(gstrSettingFilePath, xxxstrProgram_ID & CStr(xxxintSubProgram_ID) & ".config"))

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

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
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

            txtエラー出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))

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

                Case "ID1"  'エラー出力先

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
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txtエラー出力先.Text = Get_DesktopPath()
                        Else
                            txtエラー出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))
                        End If
                    End If


                Case "ID2" 'cmbサブプログラム

                    With DirectCast(cmbサブプログラム.SelectedItem, サブプログラム一覧)
                        xxxintSubProgram_ID = .intサブプログラムコード
                    End With

                    If xxxintSubProgram_ID <> 0 Then
                        'メール送信用config読込
                        If Chk_FileExists(Set_FilePath(gstrSettingFilePath, xxxstrProgram_ID & CStr(xxxintSubProgram_ID) & ".config")) = False Then
                            MsgBox(MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            cmbサブプログラム.Focus()
                            Exit Sub
                        Else
                            'XMLファイルから設定を読み込む
                            LoadFromXmlFile(Set_FilePath(gstrSettingFilePath, xxxstrProgram_ID & CStr(xxxintSubProgram_ID) & ".config"))
                        End If
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
            cmbサブプログラム.Focus()
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
            cmbサブプログラム.Focus()
            Exit Sub

        End If

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

                Case "ID1" 'エラー出力先

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txtエラー出力先.Text = ""
                        txtエラー出力先.Text = FDDlg.SelectedPath

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
        'Dim m_lording As Thread = Nothing
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

                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
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

                    Set_ListItem(0, "")
                    Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                    Set_ListItem(1, MSG_301002)

                    '実績送信用データ作成
                    gintRtn = DLTP0302_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxintNo, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                    Select Case gintRtn

                        Case 0 '正常終了

                            If xxxintCnt(0) = 0 Or xxxintCnt(1) = 0 Then '対象件数0件

                                Set_ListItem(1, MSG_301001 & "《" & xxxintNo & "》")
                                Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                                Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                                Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                                Set_ListItem(1, MSG_301003)
                                Set_ListItem(1, MSG_301005)
                                Set_ListItem(2, "")

                                GoTo ErrorDataExport

                            End If

                            Set_ListItem(1, MSG_301001 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                            Set_ListItem(1, MSG_301003)


                        Case 8 '対象件数0件

                            Set_ListItem(1, MSG_301001 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                            Set_ListItem(1, MSG_301003)
                            Set_ListItem(1, MSG_301005)
                            Set_ListItem(2, "")

                            GoTo ErrorDataExport

                        Case 9 'エラー

                            Set_ListItem(1, MSG_301001 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                            Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                            Set_ListItem(1, MSG_301004)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute

                    End Select

                    Set_ListItem(0, "")
                    Set_ListItem(1, MSG_301006)

                    If 送信用データ検索処理(strSendFile) = False Then GoTo EndExecute

                    If メール送信処理(strSendFile) = False Then GoTo EndExecute

ErrorDataExport:

                    Set_ListItem(1, MSG_101115)

                    If エラーデータ検索処理() = False Then GoTo EndExecute

                    If 出力結果更新処理(9, 9) = False Then GoTo EndExecute

EndExecute:

                    'セッション情報削除
                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "福医協実績送信", xxxintSubProgram_ID)

                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                    cmbサブプログラム.Focus()

                    Exit Sub


                Case "ID6" 'なし
                Case "ID7" 'なし
                Case "ID8" 'エラーフォルダ表示

                    If IsNull(txtエラー出力先.Text) = False AndAlso Chk_DirExists(txtエラー出力先.Text) Then
                        Process.Start(txtエラー出力先.Text)
                    End If

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
                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
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

            'エラー出力先チェック
            If IsNull(txtエラー出力先.Text.Trim) = True Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtエラー出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txtエラー出力先.Text.Trim) = False Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtエラー出力先.Text = ""
                txtエラー出力先.Focus()
                Exit Function
            End If

            実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　エラーデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function エラーデータ出力処理() As Boolean

        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String
        Dim stArrayData As String()
        Dim FileName As String
        Dim i As Integer
        Dim dtNow As DateTime = Now

        Try

            エラーデータ出力処理 = False

            Select Case xxxintSubProgram_ID

                Case 1 '福医協医薬
                    FileName = Set_FilePath(txtエラー出力先.Text, "福医協医薬-エラーデータ_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                Case 2 '福医協消耗品
                    FileName = Set_FilePath(txtエラー出力先.Text, "福医協消耗品-エラーデータ_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                Case Else
                    Set_ListItem(1, MSG_101117)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 2, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            RowMax = gintResultCnt

            '出力ヘッダを分割
            stArrayData = strHeaderText.Split(","c)

            i = 0

            With ExcelCreator

                .ExcelFileType = ExcelFileType.xlsx

                'EXCEL作成
                .CreateBook(FileName, 1, xlsxVersion.ver2013)

                .DefaultFontName = "メイリオ"                                                   'デフォルトフォント
                .DefaultFontPoint = 10                                                          'デフォルトフォントポイント
                .SheetName = "エラーデータ"                                                     'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                       '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                       '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)         '背景色＝青

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Str = stData
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    For ColCnt = 0 To ColMax - 1

                        .Pos(ColCnt, RowCnt + 1).Str = Results(RowCnt).strBuff(ColCnt)

                    Next

                Next

                .CloseBook(True)

            End With

            エラーデータ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　出力結果更新処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 出力結果更新処理(ByVal int送信区分 As Integer,
                                      ByVal int更新結果 As Integer) As Boolean

        Try

            出力結果更新処理 = False

            '出力結果を元にテーブルを更新
            gintRtn = DLTP0302_PROC0021(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, int送信区分, int更新結果, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0

                    Set_ListItem(1, MSG_301009)
                    Set_ListItem(2, "")

                Case 9

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_301010)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            出力結果更新処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　エラーデータ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function エラーデータ検索処理() As Boolean

        Try

            エラーデータ検索処理 = False

            'エラーデータ検索
            gintRtn = DLTP0302_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 9, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    gblRtn = エラーデータ出力処理()

                    If gblRtn = True Then

                        Set_ListItem(1, MSG_101116)

                    Else

                        Set_ListItem(1, MSG_101117)
                        Set_ListItem(1, MSG_COM901)
                        Set_ListItem(2, "")
                        Exit Function

                    End If

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_101120)
                    Set_ListItem(2, "")
                    Exit Function

                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_101117)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            エラーデータ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　メッセージの受信イベント
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Smtp_MessageReceive(ByVal sender As Object, ByVal e As TKMP.Net.MessageArgs)

        Try

            Set_ListItem(1, e.Message)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　メッセージの送信イベント
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender -- オブジェクト識別クラス
    ' *　引数２　　　　　：　e      -- イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Smtp_MessageSend(ByVal sender As Object, ByVal e As TKMP.Net.MessageArgs)

        Try

            Set_ListItem(1, e.Message)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　メール送信処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FilePath・・添付ファイル
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function メール送信処理(ByVal FilePath As String) As Boolean

        Try

            メール送信処理 = False

            'メール送信
            gintRtn = Send_Mail(FilePath)

            Select Case gintRtn

                Case 0 '正常

                    Set_ListItem(1, MSG_301008)
                    Set_ListItem(2, "")
                    送信済ファイル移動処理(FilePath, 0) '成功用フォルダへファイル移動

                    If 出力結果更新処理(0, 1) = False Then Exit Function


                Case 8 '送信先アドレス不明

                    Set_ListItem(1, MSG_301007)
                    Set_ListItem(1, MSG_101130)
                    Set_ListItem(2, "")
                    送信済ファイル移動処理(FilePath, 1) '失敗用フォルダへファイル移動

                    If 出力結果更新処理(0, 9) = False Then Exit Function


                Case 9 'エラー

                    Set_ListItem(1, MSG_301007)
                    Set_ListItem(2, "")
                    送信済ファイル移動処理(FilePath, 1) '失敗用フォルダへファイル移動

                    If 出力結果更新処理(0, 9) = False Then Exit Function


            End Select

            メール送信処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　送信済ファイル移動
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　Flg -- 0・・成功 1・・失敗
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub 送信済ファイル移動処理(ByVal FileName As String, ByVal Flg As Integer)

        Dim str送信正常保存先 As String
        Dim str送信異常保存先 As String
        Dim strMoveFile As String
        Dim dtNow As DateTime = Now

        Try

            str送信正常保存先 = Instance.送信保存先 & "\" & gintSPDシステムコード & xxxintSubProgram_ID & "\success"
            If Chk_DirExists(str送信正常保存先) = False Then
                gblRtn = Create_Dir(str送信正常保存先)
            End If

            str送信異常保存先 = Instance.送信保存先 & "\" & gintSPDシステムコード & xxxintSubProgram_ID & "\fail"
            If Chk_DirExists(str送信異常保存先) = False Then
                gblRtn = Create_Dir(str送信異常保存先)
            End If

            If Flg = 0 Then '成功
                strMoveFile = str送信正常保存先 & "\" & dtNow.ToString("yyyyMMddHHmmss") & "_" & Get_FileName(FileName)
            Else '失敗
                strMoveFile = str送信異常保存先 & "\" & dtNow.ToString("yyyyMMddHHmmss") & "_" & Get_FileName(FileName)
            End If

            File.Move(FileName, strMoveFile)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　メール送信
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FilePath -- 添付ファイルパス
    ' *　戻値　　　　　　：　0 -- 正常終了 9 -- 異常終了
    ' *-----------------------------------------------------------------------------/
    Private Function Send_Mail(ByVal FilePath As String) As Integer

        Dim Mail As New TKMP.Writer.MailWriter
        Dim Server As Net.IPAddress
        Dim Smtp As TKMP.Net.SmtpClient = Nothing
        Dim strBody As String = Nothing
        Dim dtNow As DateTime = Now
        Dim blConnectFlg As Boolean
        Dim blToAddressFlg As Boolean
        Dim i As Integer
        Dim strSendToAddress(5) As String

        Try

            Send_Mail = 9
            blConnectFlg = False
            blToAddressFlg = False

            Try
                Server = Net.Dns.GetHostEntry(Instance.送信元サーバ).AddressList(0)
                Smtp = New TKMP.Net.SmtpClient(Server, Instance.送信元ポート)
            Catch ex As Exception
                log.Error(Set_ErrMSG(Err.Number, ex.ToString))
                Exit Function
            End Try

            strBody = ""
            Select Case xxxintSubProgram_ID

                Case 1 '医薬
                    strBody = "薬品納品データ　送信時刻：" & dtNow.ToString("yyyy年MM月dd日 HH時mm分")

                Case 2 '消耗品
                    strBody = "送信日時：" & dtNow.ToString("yyyy/MM/dd HH:mm:ss")

            End Select

            '複数送信対応
            strSendToAddress(0) = Instance.送信先アドレス1
            strSendToAddress(1) = Instance.送信先アドレス2
            strSendToAddress(2) = Instance.送信先アドレス3
            strSendToAddress(3) = Instance.送信先アドレス4
            strSendToAddress(4) = Instance.送信先アドレス5

            '宛先アドレス作成
            For i = 0 To 4
                If IsNull(strSendToAddress(i)) = False Then
                    'あて先アドレスをセット
                    Mail.ToAddressList.Add(strSendToAddress(i))
                    'ヘッダ情報を追加
                    Mail.Headers.Add("To", strSendToAddress(i))
                    blToAddressFlg = True
                End If
            Next

            '差出人のアドレスをセット
            Mail.FromAddress = Instance.送信元アドレス

            '複数送信対応で不要
            'あて先アドレスをセット
            'Mail.ToAddressList.Add(Instance.送信先アドレス1)

            '本文のクラスを作成
            Dim part As New TKMP.Writer.MultiPart(
            New TKMP.Writer.TextPart(strBody),
            New TKMP.Writer.FilePart(FilePath)
            )

            '送信メールクラスに本文を登録
            Mail.MainPart = part

            'ヘッダ情報を追加
            '複数送信対応で不要
            'Mail.Headers.Add("To", Instance.送信先アドレス1)
            Mail.Headers.Add("From", Instance.送信元アドレス)
            Mail.Headers.Add("Subject", Instance.送信タイトル)

            '通信ログのイベント
            AddHandler Smtp.MessageReceive, AddressOf Smtp_MessageReceive
            AddHandler Smtp.MessageSend, AddressOf Smtp_MessageSend

            '接続
            If Not Smtp.Connect() Then Exit Function

            blConnectFlg = True

            Smtp.SendMail(Mail)

            Smtp.Close()

            blConnectFlg = False

            Send_Mail = 0

        Catch ex As Exception

            If blConnectFlg = True Then
                Smtp.Close()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　送信用データ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　添付ファイル
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 送信用データ検索処理(ByRef str添付ファイル As String) As Boolean

        Dim dtNow As DateTime = Now
        Dim str添付ファイルパス As String

        Try

            送信用データ検索処理 = False

            'データ検索
            gintRtn = DLTP0302_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 0, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    str添付ファイルパス = Instance.送信保存先 & "\" & gintSPDシステムコード & xxxintSubProgram_ID & "\temp"

                    If Chk_DirExists(str添付ファイルパス) = False Then
                        gblRtn = Create_Dir(str添付ファイルパス)
                    End If

                    Select Case xxxintSubProgram_ID

                        Case 1 '医薬
                            str添付ファイル = Set_FilePath(str添付ファイルパス, Instance.送信添付ファイル名 & ".dat")

                        Case 2 '消耗品
                            str添付ファイル = Set_FilePath(str添付ファイルパス, Instance.送信添付ファイル名 & ".csv")

                    End Select

                    If Chk_FileExists(str添付ファイル) = True Then
                        Set_ListItem(1, MSG_301024)
                        Set_ListItem(1, MSG_301007)
                        Set_ListItem(1, MSG_COM901)
                        Set_ListItem(2, "")
                        Exit Function
                    End If

                    gblRtn = 送信用データ出力処理(str添付ファイル)

                    If gblRtn = False Then

                        Set_ListItem(1, MSG_301007)
                        Set_ListItem(1, MSG_COM901)
                        Set_ListItem(2, "")
                        Exit Function


                    End If

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_301005)
                    Set_ListItem(2, "")
                    Exit Function


                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_301007)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            送信用データ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　送信用データ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FileName・・作成ファイル
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Function 送信用データ出力処理(ByVal FileName As String) As Boolean

        Dim DataWriter As StreamWriter = Nothing
        Dim blOpenFlg As Boolean
        Dim i As Integer

        Try

            送信用データ出力処理 = False

            blOpenFlg = False

            'ファイルオープン
            DataWriter = New StreamWriter(FileName, True, System.Text.Encoding.GetEncoding("shift_jis"))

            blOpenFlg = True

            For i = 0 To gintResultCnt - 1

                DataWriter.WriteLine(Results(i).strBuff(0))

            Next

            DataWriter.Flush()

            'ファイルクローズ
            DataWriter.Close()

            blOpenFlg = False

            送信用データ出力処理 = True


        Catch ex As Exception

            If blOpenFlg Then
                DataWriter.Close()
            End If

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function

End Class