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
Imports AdvanceSoftware.ExcelCreator
Imports System.ComponentModel
Imports System.IO

Public Class HARK401
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
            txtDate.Text = ""

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
    ' *　引数１　　　　　：　int区分・・サブプログラムID
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize条件(ByVal int区分 As Integer)

        Try

            Select Case int区分

                Case 1 '請求情報チェック処理(WEB在庫移動ログ)

                    lbl取込ファイル.Text = "【WEB在庫移動ログ】"

                Case 2 '請求情報チェック処理(請求明細)

                    lbl取込ファイル.Text = "【請求明細】"

                Case 3 '値引作成処理(請求明細)

                    lbl取込ファイル.Text = "【請求明細】"

                Case Else

                    lbl取込ファイル.Text = "【取込ファイル】"

            End Select

            txtDate.Text = ""
            txt取込ファイル.Text = ""
            txtDate.Enabled = True
            txt取込ファイル.Enabled = True
            btnファイル参照.Enabled = True

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
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM908 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
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

            OFDlg.InitialDirectory = Get_DesktopPath()
            OFDlg.Filter = "csv Files (*.csv)|*.csv|All Files (*.*)|*.*"
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
    ' *　引数１　　　　　：　Line・・メッセージ区分
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
        Dim ii As Integer
        Dim strSendFile As String = Nothing
        'Dim m_lording As Thread = Nothing

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

                    'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                    '    .IsBackground = True
                    '}

                    'm_lording.Start()

                    If テキスト取込処理(txt取込ファイル.Text.Trim) = False Then GoTo EndExecute

                    Select Case xxxintSubProgram_ID

                        Case 1 '請求情報チェック処理(WEB在庫移動ログ)
                            'テキスト取込
                            gintRtn = DLTP0401_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, txtDate.Text.Trim, "在庫移動ログ", xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                        Case 2 '請求情報チェック処理(請求明細)
                            'テキスト取込
                            gintRtn = DLTP0401_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, txtDate.Text.Trim, "請求明細", xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                        Case 3 '値引作成処理(請求明細)
                            'テキスト取込
                            gintRtn = DLTP0401_PROC0002(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxstr病院コード, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                    End Select

                    Select Case gintRtn

                        Case 0 '正常終了

                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                            Set_ListItem(1, MSG_301015)
                            Set_ListItem(2, "")

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "請求情報", 1)

                        Case 8 'エラーデータあり

                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                            Set_ListItem(1, MSG_301015)
                            Set_ListItem(2, "")

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "請求情報", 1)

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_101115)

                            gblRtn = エラーデータ検索処理()

                            GoTo EndExecute

                        Case 9 'ORACLEエラー

                            取込エラーファイル複製処理()

                            Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                            Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                            Set_ListItem(1, MSG_301016)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "請求情報", 1)

                            GoTo EndExecute

                    End Select

                    Select Case xxxintSubProgram_ID

                        Case 1, 2 '請求情報チェック処理

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_401001)

                            If 出力ファイル名作成() = False Then

                                Set_ListItem(1, MSG_COM898)
                                Set_ListItem(1, MSG_401005)
                                Set_ListItem(2, "")

                                GoTo EndExecute

                            End If

                            For ii = 24 To 28

                                Set_ListItem(1, xxxstr出力種別(ii - 24) & MSG_401002)

                                'チェック結果データ検索
                                gintRtn = DLTP0401_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, 0, ii, gintSQLCODE, gstrSQLERRM)

                                Select Case gintRtn

                                    Case 0 '正常終了

                                        gblRtn = データ出力処理EX(xxxstr出力ファイル(ii - 24), ii, xxxstr出力シート名(ii - 24))

                                        If gblRtn = True Then

                                            Set_ListItem(1, MSG_301020 & "【" & gintResultCnt & "】")
                                            Set_ListItem(1, MSG_401004)


                                        Else

                                            Set_ListItem(1, MSG_401003)


                                        End If

                                    Case 2 '対象件数0件

                                        Set_ListItem(1, MSG_301005)


                                    Case 9 'エラー

                                        Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                        Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                        Set_ListItem(1, MSG_401003)
                                        Set_ListItem(1, MSG_COM901)


                                End Select

                            Next

                            Set_ListItem(1, MSG_401006)
                            Set_ListItem(2, "")

                        Case 3 '値引作成処理

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_401012)
                            Set_ListItem(1, MSG_401007)

                            If 値引用出力ファイル名作成() = False Then

                                Set_ListItem(1, MSG_COM898)
                                Set_ListItem(1, MSG_401008)
                                Set_ListItem(2, "")

                                GoTo EndExecute

                            End If

                            If 値引金額確認表作成処理() = False Then

                                Set_ListItem(1, MSG_401010)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")

                                GoTo EndExecute

                            End If

                            Set_ListItem(1, MSG_401011)
                            Set_ListItem(1, MSG_401013)

                            If 値引金額一覧作成処理() = False Then

                                Set_ListItem(1, MSG_401014)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")

                                GoTo EndExecute

                            End If

                            Set_ListItem(1, MSG_401015)
                            Set_ListItem(1, MSG_401009)
                            Set_ListItem(2, "")

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

            '対象日
            If IsNull(txtDate.Text.Trim) = True Then
                MsgBox(MSG_301011, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtDate.Focus()
                Exit Function
            End If

            If Chk_Date(txtDate.Text.Trim, 1) = False Then
                txtDate.Text = ""
                MsgBox(MSG_301012, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                txtDate.Focus()
                Exit Function
            End If

            '取込ファイルチェック
            If IsNull(txt取込ファイル.Text.Trim) = True Then
                MsgBox(MSG_101001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt取込ファイル.Focus()
                Exit Function
            End If

            If Chk_FileExists(txt取込ファイル.Text.Trim) = False Then
                MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt取込ファイル.Text = ""
                txt取込ファイル.Focus()
                Exit Function
            End If

            '拡張子比較
            If Get_Extension(txt取込ファイル.Text).CompareTo(CSVExtension) <> 0 Then
                MsgBox(MSG_101103, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt取込ファイル.Text = ""
                txt取込ファイル.Focus()
                Exit Function
            End If

            Select Case xxxintSubProgram_ID

                Case 1 '請求情報チェック処理(WEB在庫移動ログ)

                    If Not Get_FileNameWithoutExtension(txt取込ファイル.Text).Contains(HARKP4011ImpFileName) Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If


                Case 2, 3 '請求情報チェック処理(請求明細)/値引金額作成処理(請求明細)

                    If Not Get_FileNameWithoutExtension(txt取込ファイル.Text).Contains(HARKP4012ImpFileName) Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If


                Case Else

                    Exit Function

            End Select

            'データ出力先チェック
            If IsNull(txtデータ出力先.Text.Trim) = True Then
                MsgBox(MSG_301021, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtデータ出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txtデータ出力先.Text.Trim) = False Then
                MsgBox(MSG_301021, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txtデータ出力先.Text = ""
                txtデータ出力先.Focus()
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
    ' *　モジュール機能　：　テキスト取込処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　str取込ファイル -- 取込ファイルパス
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function テキスト取込処理(ByVal str取込ファイル As String) As Boolean

        'Dim SR As New StreamReader(str取込ファイル, System.Text.Encoding.GetEncoding(932))
        Dim SR As StreamReader = Nothing
        Dim i As Integer
        Dim blnFirstLine As Boolean
        Dim blnHeaderLine As Boolean
        Dim line As String

        Try

            テキスト取込処理 = False

            blnHeaderLine = True
            Set_ListItem(0, "")
            Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
            Set_ListItem(1, MSG_301014)

            blnFirstLine = True
            line = ""

            i = 0

            SR = New StreamReader(str取込ファイル, System.Text.Encoding.GetEncoding(932))

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
            '確実にファイルを閉じる
            If Not SR Is Nothing Then
                SR.Close()
                SR.Dispose()
            End If

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：  エラーデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　strファイル・・出力ファイル
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function エラーデータ出力処理(ByVal strファイル As String) As Boolean

        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String = Nothing
        Dim strSheetName As String = Nothing
        Dim stArrayData As String()
        Dim i As Integer


        Try

            エラーデータ出力処理 = False

            Select Case xxxintSubProgram_ID

                Case 1, 2 '請求情報チェック処理

                    '出力ヘッダ取得
                    gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 1, 3, 99, "出力ヘッダ")
                    strHeaderText = gstrDLTP0997S_FUNC005

                    '項目数取得
                    gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 1, 3, 99, "項目数")
                    ColMax = gintDLTP0997S_FUNC004

                    strSheetName = "請求チェック処理-取込情報エラー"

                Case 3 '値引作成処理

                    '出力ヘッダ取得
                    gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "出力ヘッダ")
                    strHeaderText = gstrDLTP0997S_FUNC005

                    '項目数取得
                    gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "項目数")
                    ColMax = gintDLTP0997S_FUNC004

                    strSheetName = "値引作成処理-取込情報エラー"

            End Select

            RowMax = gintResultCnt

            '出力ヘッダを分割
            stArrayData = strHeaderText.Split(","c)

            i = 0

            With ExcelCreator

                .ExcelFileType = ExcelFileType.xlsx

                'EXCEL作成
                .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                .DefaultFontName = "メイリオ"                                                   'デフォルトフォント
                .DefaultFontPoint = 10                                                          'デフォルトフォントポイント
                .SheetName = strSheetName                                                       'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                       '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                       '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)         '背景色＝青

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center       'テキスト横位置=中心
                    .Pos(i, 0).Str = stData
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    For ColCnt = 0 To ColMax - 1

                        .Pos(ColCnt, RowCnt + 1).Str = Results(RowCnt).strBuff(ColCnt)

                    Next

                Next

                .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                .CloseBook(True)

            End With

            エラーデータ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　データ出力処理EX
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　strファイル -- 出力パス
    ' *　引数２　　　　　：　intデータ区分 -- 出力データ種別
    ' *　引数３　　　　　：　strシート名 -- EXCELシート名
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ出力処理EX(ByVal strファイル As String,
                                      ByVal intデータ区分 As Integer,
                                      ByVal strシート名 As String) As Boolean

        '  Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String
        Dim stArrayData As String()
        Dim i As Integer

        Try

            データ出力処理EX = False

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 1, intデータ区分, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 1, intデータ区分, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004

            RowMax = gintResultCnt

            '出力ヘッダを分割
            stArrayData = strHeaderText.Split(","c)

            i = 0

            Select Case intデータ区分

                Case 24 '施設別

                    With ExcelCreator

                        .ExcelFileType = ExcelFileType.xlsx

                        'EXCEL作成
                        .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                        .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                        .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                        .SheetName = strシート名                                                               'シート名
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                        .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                        .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(需要先コード)
                        .Pos(2, 1, 2, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(ＩＴＩ金額)
                        .Pos(3, 1, 3, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(病院金額)
                        .Pos(4, 1, 4, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(差額)
                        .Pos(2, 1, 4, RowMax).Attr.Format = "#,##0;[赤]-#,##0"                                 '数値表示(マイナス時赤)

                        'ヘッダ項目出力
                        For Each stData As String In stArrayData
                            .Pos(i, 0).Str = stData
                            .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                            i += 1
                        Next stData

                        '明細行出力
                        For RowCnt = 0 To RowMax - 1

                            'For ColCnt = 0 To ColMax - 1

                            .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(0))
                            .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                            .Pos(2, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(2))
                            .Pos(3, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(3))
                            .Pos(4, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(4))

                            'Next

                        Next

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                        .CloseBook(True)

                    End With


                Case 25 '商品別

                    With ExcelCreator

                        .ExcelFileType = ExcelFileType.xlsx

                        'EXCEL作成
                        .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                        .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                        .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                        .SheetName = strシート名                                                               'シート名
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                        .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                        .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(得意先コード)
                        .Pos(4, 1, 4, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(メーカコード)
                        .Pos(8, 1, 8, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(ＩＴＩ数量)
                        .Pos(9, 1, 9, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(ＩＴＩ金額)
                        .Pos(10, 1, 10, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院数量)
                        .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院金額)
                        .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(差額)

                        .Pos(8, 1, 12, RowMax).Attr.Format = "#,##0;[赤]-#,##0"                                '数値表示(マイナス時赤)

                        'ヘッダ項目出力
                        For Each stData As String In stArrayData
                            .Pos(i, 0).Str = stData
                            .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                            i += 1
                        Next stData

                        '明細行出力
                        For RowCnt = 0 To RowMax - 1

                            'For ColCnt = 0 To ColMax - 1

                            .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(0))
                            .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                            .Pos(2, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                            .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                            .Pos(4, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(4))
                            .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                            .Pos(6, RowCnt + 1).Str = Results(RowCnt).strBuff(6)
                            .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                            .Pos(8, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(8))
                            .Pos(9, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(9))
                            .Pos(10, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(10))
                            .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                            .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))

                            'Next

                        Next

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                        .CloseBook(True)

                    End With


                Case 26 '部署商品別

                    With ExcelCreator

                        .ExcelFileType = ExcelFileType.xlsx

                        'EXCEL作成
                        .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                        .DefaultFontName = "メイリオ"                                                                                       'デフォルトフォント
                        .DefaultFontPoint = 9                                                                                               'デフォルトフォントポイント
                        .SheetName = strシート名                                                               'シート名
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                        .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                        .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(得意先コード)
                        .Pos(2, 1, 2, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(部署コード)
                        .Pos(6, 1, 6, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(メーカコード)
                        .Pos(10, 1, 10, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(ＩＴＩ数量)
                        .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(ＩＴＩ金額)
                        .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院数量)
                        .Pos(13, 1, 13, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院金額)
                        .Pos(14, 1, 14, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(差額)

                        .Pos(10, 1, 14, RowMax).Attr.Format = "#,##0;[赤]-#,##0"                                                            '数値表示(マイナス時赤)

                        'ヘッダ項目出力
                        For Each stData As String In stArrayData
                            .Pos(i, 0).Str = stData
                            .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                            i += 1
                        Next stData

                        '明細行出力
                        For RowCnt = 0 To RowMax - 1

                            'For ColCnt = 0 To ColMax - 1

                            .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(0))
                            .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                            .Pos(2, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(2))
                            .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                            .Pos(4, RowCnt + 1).Str = Results(RowCnt).strBuff(4)
                            .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                            .Pos(6, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(6))
                            .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                            .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                            .Pos(9, RowCnt + 1).Str = Results(RowCnt).strBuff(9)
                            .Pos(10, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(10))
                            .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                            .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))
                            .Pos(13, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(13))
                            .Pos(14, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(14))

                            'Next

                        Next

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                        .CloseBook(True)

                    End With

                Case 27 '商品日付別

                    With ExcelCreator

                        .ExcelFileType = ExcelFileType.xlsx

                        'EXCEL作成
                        .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                        .DefaultFontName = "メイリオ"                                                                                       'デフォルトフォント
                        .DefaultFontPoint = 9                                                                                               'デフォルトフォントポイント
                        .SheetName = strシート名                                                               'シート名
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                        .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                        .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(得意先コード)
                        .Pos(4, 1, 4, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(メーカコード)
                        .Pos(8, 1, 8, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(日付)
                        .Pos(9, 1, 9, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(ＩＴＩ数量)
                        .Pos(10, 1, 10, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(ＩＴＩ金額)
                        .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院数量)
                        .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院金額)
                        .Pos(13, 1, 13, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(差額)

                        .Pos(8, 1, 8, RowMax).Attr.Format = "yyyy/m/d"                                                                      '日付表示
                        .Pos(9, 1, 13, RowMax).Attr.Format = "#,##0;[赤]-#,##0"                                                             '数値表示(マイナス時赤)

                        'ヘッダ項目出力
                        For Each stData As String In stArrayData
                            .Pos(i, 0).Str = stData
                            .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                            i += 1
                        Next stData

                        '明細行出力
                        For RowCnt = 0 To RowMax - 1

                            'For ColCnt = 0 To ColMax - 1

                            .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(0))
                            .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                            .Pos(2, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                            .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                            .Pos(4, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(4))
                            .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                            .Pos(6, RowCnt + 1).Str = Results(RowCnt).strBuff(6)
                            .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                            .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                            .Pos(9, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(9))
                            .Pos(10, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(10))
                            .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                            .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))
                            .Pos(13, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(13))

                            'Next

                        Next

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                        .CloseBook(True)

                    End With


                Case 28 '商品部署日付別

                    With ExcelCreator

                        .ExcelFileType = ExcelFileType.xlsx

                        'EXCEL作成
                        .CreateBook(strファイル, 1, xlsxVersion.ver2013)

                        .DefaultFontName = "メイリオ"                                                                                       'デフォルトフォント
                        .DefaultFontPoint = 9                                                                                               'デフォルトフォントポイント
                        .SheetName = strシート名                                                               'シート名
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                        .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                        .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                        .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(得意先コード)
                        .Pos(2, 1, 2, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(部署コード)
                        .Pos(6, 1, 6, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(メーカコード)
                        .Pos(10, 1, 10, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(日付)
                        .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(ＩＴＩ数量)
                        .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(ＩＴＩ金額)
                        .Pos(13, 1, 13, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院数量)
                        .Pos(14, 1, 14, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(病院金額)
                        .Pos(15, 1, 15, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(差額)

                        .Pos(10, 1, 10, RowMax).Attr.Format = "yyyy/m/d"                                                                    '日付表示
                        .Pos(11, 1, 15, RowMax).Attr.Format = "#,##0;[赤]-#,##0"                                                            '数値表示(マイナス時赤)

                        'ヘッダ項目出力
                        For Each stData As String In stArrayData
                            .Pos(i, 0).Str = stData
                            .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                            i += 1
                        Next stData

                        '明細行出力
                        For RowCnt = 0 To RowMax - 1

                            'For ColCnt = 0 To ColMax - 1

                            .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(0))
                            .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                            .Pos(2, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(2))
                            .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                            .Pos(4, RowCnt + 1).Str = Results(RowCnt).strBuff(4)
                            .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                            .Pos(6, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(6))
                            .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                            .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                            .Pos(9, RowCnt + 1).Str = Results(RowCnt).strBuff(9)
                            .Pos(10, RowCnt + 1).Str = Results(RowCnt).strBuff(10)
                            .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                            .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))
                            .Pos(13, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(13))
                            .Pos(14, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(14))
                            .Pos(15, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(15))

                            'Next

                        Next

                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                        .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                        .CloseBook(True)

                    End With

            End Select

            データ出力処理EX = True

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

        Dim strファイル名 As String = Nothing
        Dim dtNow As DateTime = Now

        Try

            エラーデータ検索処理 = False

            Select Case xxxintSubProgram_ID

                Case 1, 2　'請求情報チェック処理

                    'エラーデータ検索
                    gintRtn = DLTP0401_PROC0021(xxxstrProgram_ID, gintSPDシステムコード, 0, gintSQLCODE, gstrSQLERRM)

                    strファイル名 = Set_FilePath(txtデータ出力先.Text, "請求チェック処理-取込情報エラー_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")

                Case 3 '値引作成処理

                    'エラーデータ検索
                    gintRtn = DLTP0401_PROC0031(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, gintSQLCODE, gstrSQLERRM)

                    strファイル名 = Set_FilePath(txtデータ出力先.Text, "値引作成処理-取込情報エラー_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")

            End Select

            Select Case gintRtn

                Case 0 '正常終了

                    If Chk_FileExists(strファイル名) = True Then

                        gintRtn = Delete_File(strファイル名)

                        Select Case gintRtn

                            Case 0
                                Exit Select
                            Case 55
                                Set_ListItem(1, MSG_COM896)
                                Set_ListItem(1, MSG_101117)
                                Set_ListItem(2, "")

                                Exit Function
                            Case 53
                                Set_ListItem(1, MSG_COM897)
                                Set_ListItem(1, MSG_101117)
                                Set_ListItem(2, "")

                                Exit Function
                            Case 99
                                Set_ListItem(1, MSG_COM898)
                                Set_ListItem(1, MSG_101117)
                                Set_ListItem(2, "")

                                Exit Function
                        End Select

                    End If

                    gblRtn = エラーデータ出力処理(strファイル名)

                    If gblRtn = True Then

                        Set_ListItem(1, MSG_301020 & "【" & gintResultCnt & "】")
                        Set_ListItem(1, MSG_101116)
                        '★★暫定対応
                        If xxxintSubProgram_ID = 1 Or xxxintSubProgram_ID = 2 Then '請求情報チェック処理
                            Set_ListItem(1, MSG_COM901)
                        End If
                        Set_ListItem(2, "")


                    Else

                        Set_ListItem(1, MSG_101117)
                        Set_ListItem(1, MSG_COM901)
                        Set_ListItem(2, "")
                        Exit Function


                    End If

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_301005)
                    Set_ListItem(1, MSG_101117)
                    Set_ListItem(1, MSG_COM901)
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
    ' *　モジュール機能　：　ファイル名作成
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 出力ファイル名作成() As Boolean

        Dim str個別名 As String
        Dim ii As Integer
        Dim dtNow As DateTime = Now

        Try

            出力ファイル名作成 = False

            For ii = 24 To 28

                '出力ヘッダ取得
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 1, ii, 99, "個別名")
                str個別名 = gstrDLTP0997S_FUNC005

                xxxstr出力シート名(ii - 24) = str個別名
                xxxstr出力ファイル(ii - 24) = Set_FilePath(txtデータ出力先.Text, Mid(txtDate.Text.Replace("/", ""), 1, 6) & "_チェック処理" & str個別名 & "_" & dtNow.ToString("yyyyMMdd") & ".xlsx")
                xxxstr出力種別(ii - 24) = str個別名

                If Chk_FileExists(xxxstr出力ファイル(ii - 24)) = True Then

                    If Delete_File(xxxstr出力ファイル(ii - 24)) <> 0 Then Exit Function

                End If

            Next

            出力ファイル名作成 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　値引用出力ファイル名作成
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 値引用出力ファイル名作成() As Boolean

        Dim str個別名 As String
        Dim ii As Integer
        Dim dtNow As DateTime = Now

        Try

            値引用出力ファイル名作成 = False

            '値引値引金額確認表
            xxxstr値引用出力ファイル(0) = Set_FilePath(txtデータ出力先.Text, Mid(txtDate.Text.Replace("/", ""), 1, 6) & "_値引金額確認表_" & dtNow.ToString("yyyyMMdd") & ".xlsx")

            If Chk_FileExists(xxxstr値引用出力ファイル(0)) = True Then
                If Delete_File(xxxstr値引用出力ファイル(0)) <> 0 Then Exit Function
            End If

            '値引金額一覧
            xxxstr値引用出力ファイル(1) = Set_FilePath(txtデータ出力先.Text, Mid(txtDate.Text.Replace("/", ""), 1, 6) & "_値引金額一覧_" & dtNow.ToString("yyyyMMdd") & ".xlsx")

            If Chk_FileExists(xxxstr値引用出力ファイル(1)) = True Then
                If Delete_File(xxxstr値引用出力ファイル(1)) <> 0 Then Exit Function
            End If

            For ii = 21 To 25

                '出力ヘッダ取得
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, ii, 99, "個別名")
                str個別名 = gstrDLTP0997S_FUNC005
                xxxstr値引用出力シート名(ii - 21) = str個別名

            Next

            値引用出力ファイル名作成 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　値引金額確認表作成処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 値引金額確認表作成処理() As Boolean

        '  Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String
        Dim stArrayData As String()
        Dim i As Integer

        Try

            値引金額確認表作成処理 = False

            With ExcelCreator

                .ExcelFileType = ExcelFileType.xlsx

                'EXCEL作成
                .CreateBook(xxxstr値引用出力ファイル(0), 3, xlsxVersion.ver2013)


                ''01【除外商品対応前】
                '出力ヘッダ取得
                strHeaderText = ""
                i = 0
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 3, 21, 99, "出力ヘッダ")
                strHeaderText = gstrDLTP0997S_FUNC005

                '項目数取得
                gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 3, 21, 99, "項目数")
                ColMax = gintDLTP0997S_FUNC004

                '出力ヘッダを分割
                stArrayData = strHeaderText.Split(","c)

                'チェック結果データ検索
                gintRtn = DLTP0401_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 21, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        Exit Select
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                    Case 9
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                End Select

                RowMax = gintResultCnt

                .SheetNo = 0
                .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                .SheetName = xxxstr値引用出力シート名(0)                                               'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(単価)
                .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(数量)
                .Pos(13, 1, 13, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(金額)
                .Pos(14, 1, 14, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(消費税)
                .Pos(11, 1, 11, RowMax).Attr.Format = "#,##0.00_ "                                     '数値表示(小数点以下2位表示)
                .Pos(13, 1, 14, RowMax + 1).Attr.Format = "#,##0_ "                                    '数値表示

                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineLeft(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineTop(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineRight(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineBottom(BorderStyle.Thin, xlColor.Black)

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Str = stData
                    .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 1).Str = Results(RowCnt).strBuff(0)
                    .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                    .Pos(2, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                    .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                    .Pos(4, RowCnt + 1).Str = Results(RowCnt).strBuff(4)
                    .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                    .Pos(6, RowCnt + 1).Str = Results(RowCnt).strBuff(6)
                    .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                    .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                    .Pos(9, RowCnt + 1).Str = Results(RowCnt).strBuff(9)
                    .Pos(10, RowCnt + 1).Str = Results(RowCnt).strBuff(10)
                    .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                    .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))
                    .Pos(13, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(13))
                    .Pos(14, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(14))
                    .Pos(15, RowCnt + 1).Str = Results(RowCnt).strBuff(15)
                    .Pos(16, RowCnt + 1).Str = Results(RowCnt).strBuff(16)
                    .Pos(17, RowCnt + 1).Str = Results(RowCnt).strBuff(17)
                    .Pos(18, RowCnt + 1).Str = Results(RowCnt).strBuff(18)
                    .Pos(19, RowCnt + 1).Str = Results(RowCnt).strBuff(19)
                    .Pos(20, RowCnt + 1).Str = Results(RowCnt).strBuff(20)
                    .Pos(21, RowCnt + 1).Str = Results(RowCnt).strBuff(21)

                Next

                '最終行に合計追加
                .Pos(13, RowMax + 1).Func("=SUM(N2:N" & RowMax + 1 & ")", Nothing)
                .Pos(14, RowMax + 1).Func("=SUM(O2:O" & RowMax + 1 & ")", Nothing)


                ''02【除外商品対応後】
                '出力ヘッダ取得
                strHeaderText = ""
                i = 0
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 3, 22, 99, "出力ヘッダ")
                strHeaderText = gstrDLTP0997S_FUNC005

                '項目数取得
                gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 3, 22, 99, "項目数")
                ColMax = gintDLTP0997S_FUNC004

                '出力ヘッダを分割
                stArrayData = strHeaderText.Split(","c)

                'チェック結果データ検索
                gintRtn = DLTP0401_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 22, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        Exit Select
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                    Case 9
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                End Select

                RowMax = gintResultCnt

                .SheetNo = 1
                .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                .SheetName = xxxstr値引用出力シート名(1)                                               'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                .Pos(11, 1, 11, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(単価)
                .Pos(12, 1, 12, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(数量)
                .Pos(13, 1, 13, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(金額)
                .Pos(14, 1, 14, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right           'テキスト横位置=右(消費税)
                .Pos(11, 1, 11, RowMax).Attr.Format = "#,##0.00_ "                                     '数値表示(小数点以下2位表示)
                .Pos(13, 1, 14, RowMax + 1).Attr.Format = "#,##0_ "                                    '数値表示

                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineLeft(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineTop(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineRight(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineBottom(BorderStyle.Thin, xlColor.Black)

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Str = stData
                    .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 1).Str = Results(RowCnt).strBuff(0)
                    .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                    .Pos(2, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                    .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(3)
                    .Pos(4, RowCnt + 1).Str = Results(RowCnt).strBuff(4)
                    .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(5)
                    .Pos(6, RowCnt + 1).Str = Results(RowCnt).strBuff(6)
                    .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                    .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                    .Pos(9, RowCnt + 1).Str = Results(RowCnt).strBuff(9)
                    .Pos(10, RowCnt + 1).Str = Results(RowCnt).strBuff(10)
                    .Pos(11, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(11))
                    .Pos(12, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(12))
                    .Pos(13, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(13))
                    .Pos(14, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(14))
                    .Pos(15, RowCnt + 1).Str = Results(RowCnt).strBuff(15)
                    .Pos(16, RowCnt + 1).Str = Results(RowCnt).strBuff(16)
                    .Pos(17, RowCnt + 1).Str = Results(RowCnt).strBuff(17)
                    .Pos(18, RowCnt + 1).Str = Results(RowCnt).strBuff(18)
                    .Pos(19, RowCnt + 1).Str = Results(RowCnt).strBuff(19)
                    .Pos(20, RowCnt + 1).Str = Results(RowCnt).strBuff(20)
                    .Pos(21, RowCnt + 1).Str = Results(RowCnt).strBuff(21)

                Next

                '最終行に合計追加
                .Pos(13, RowMax + 1).Func("=SUM(N2:N" & RowMax + 1 & ")", Nothing)
                .Pos(14, RowMax + 1).Func("=SUM(O2:O" & RowMax + 1 & ")", Nothing)


                ''03【集計】
                '出力ヘッダ取得
                strHeaderText = ""
                i = 0
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 3, 23, 99, "出力ヘッダ")
                strHeaderText = gstrDLTP0997S_FUNC005

                '項目数取得
                gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 3, 23, 99, "項目数")
                ColMax = gintDLTP0997S_FUNC004

                '出力ヘッダを分割
                stArrayData = strHeaderText.Split(","c)

                'チェック結果データ検索
                gintRtn = DLTP0401_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 23, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        Exit Select
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                    Case 9
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                End Select

                RowMax = gintResultCnt

                .SheetNo = 2
                .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                .SheetName = xxxstr値引用出力シート名(2)                                               'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                .Pos(3, 1, 3, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(金額)
                .Pos(4, 1, 4, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(値引金額)
                .Pos(3, 1, 4, RowMax + 1).Attr.Format = "#,##0_ "                                      '数値表示

                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineLeft(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineTop(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineRight(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 0, ColMax - 1, RowMax).Attr.LineBottom(BorderStyle.Thin, xlColor.Black)

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Str = stData
                    .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 1).Str = Results(RowCnt).strBuff(0)
                    .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(1)
                    .Pos(2, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                    .Pos(3, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(3))
                    .Pos(4, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(4))

                Next

                '最終行に合計追加
                .Pos(3, RowMax + 1).Func("=SUM(D2:D" & RowMax + 1 & ")", Nothing)
                .Pos(4, RowMax + 1).Func("=D" & RowMax + 2 & "*0.04", Nothing)

                .CloseBook(True)

            End With

            値引金額確認表作成処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　値引金額一覧作成処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 値引金額一覧作成処理() As Boolean

        'Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String
        Dim str本文(3) As String
        Dim stArrayData As String()
        Dim i As Integer

        Try

            値引金額一覧作成処理 = False

            str本文(0) = Mid(txtDate.Text.Replace("/", ""), 1, 4) & "年" & Mid(txtDate.Text.Replace("/", ""), 5, 2) & "月度値引金額"
            str本文(1) = "消費税額"
            str本文(2) = "施設別予算区分別値引金額"

            With ExcelCreator

                .ExcelFileType = ExcelFileType.xlsx

                'EXCEL作成
                .CreateBook(xxxstr値引用出力ファイル(1), 2, xlsxVersion.ver2013)

                ''値引詳細（提出用）

                ''共通
                .SheetNo = 0
                .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                .SheetName = xxxstr値引用出力シート名(3)                                               'シート名

                ''データ取得
                '出力ヘッダ取得
                strHeaderText = ""
                i = 0
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 3, 24, 99, "出力ヘッダ")
                strHeaderText = gstrDLTP0997S_FUNC005

                '項目数取得
                gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 3, 24, 99, "項目数")
                ColMax = gintDLTP0997S_FUNC004

                '出力ヘッダを分割
                stArrayData = strHeaderText.Split(","c)

                'チェック結果データ検索
                gintRtn = DLTP0401_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 24, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        Exit Select
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                    Case 9
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                End Select

                RowMax = gintResultCnt

                ''ヘッダ部
                .Pos(0, 0, 1, 1).Attr.FontPoint = 11                                    '文字サイズ
                .Pos(0, 0, 1, 1).Attr.FontStyle = FontStyle.Bold                        '文字列修飾＝太字
                .Pos(0, 0, 4, 3).Attr.VerticalAlignment = VerticalAlignment.Center      'テキスト縦位置=中心
                .Pos(0, 0, 1, 1).Attr.HorizontalAlignment = HorizontalAlignment.Right   'テキスト横位置=右
                .Pos(1, 0, 1, 1).Attr.Format = """\""#,##0;""\""-#,##0"                 '金額表示

                .Pos(0, 0).Str = str本文(0)
                .Pos(0, 1).Str = str本文(1)
                .Pos(0, 3).Str = str本文(2)
                .Pos(1, 0).Func("=E" & RowMax + 6, Nothing)
                .Pos(1, 1).Func("=ROUNDDOWN(B1*0.1,0)", Nothing)

                ''明細部
                .Pos(0, 4, ColMax - 1, 4).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                .Pos(0, 4, ColMax - 1, 4).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                .Pos(0, 4, ColMax - 1, 4).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.VerticalAlignment = VerticalAlignment.Center   'テキスト縦位置=中心
                .Pos(3, 5, 3, RowMax + 4).Attr.HorizontalAlignment = HorizontalAlignment.Right         'テキスト横位置=右(金額)
                .Pos(4, 5, 4, RowMax + 4).Attr.HorizontalAlignment = HorizontalAlignment.Right         'テキスト横位置=右(値引額)
                .Pos(3, 5, 4, RowMax + 5).Attr.Format = "#,##0_ "                                      '数値表示

                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineLeft(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineTop(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineRight(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineBottom(BorderStyle.Thin, xlColor.Black)

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 4).Str = stData
                    .Pos(i, 4).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 5).Str = Results(RowCnt).strBuff(0)
                    .Pos(1, RowCnt + 5).Str = Results(RowCnt).strBuff(1)
                    .Pos(2, RowCnt + 5).Str = Results(RowCnt).strBuff(2)
                    .Pos(3, RowCnt + 5).Long = CInt(Results(RowCnt).strBuff(3))
                    .Pos(4, RowCnt + 5).Long = CInt(Results(RowCnt).strBuff(4))

                Next

                '最終行に合計追加
                .Pos(3, RowMax + 5).Func("=SUM(D6:D" & RowMax + 5 & ")", Nothing)
                .Pos(4, RowMax + 5).Func("=D" & RowMax + 6 & "*0.04", Nothing)


                ''値引詳細（原さん用）

                ''共通
                .SheetNo = 1
                .DefaultFontName = "メイリオ"                                                          'デフォルトフォント
                .DefaultFontPoint = 9                                                                  'デフォルトフォントポイント
                .SheetName = xxxstr値引用出力シート名(4)                                               'シート名

                ''データ取得
                '出力ヘッダ取得
                strHeaderText = ""
                i = 0
                gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 3, 25, 99, "出力ヘッダ")
                strHeaderText = gstrDLTP0997S_FUNC005

                '項目数取得
                gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 3, 25, 99, "項目数")
                ColMax = gintDLTP0997S_FUNC004

                '出力ヘッダを分割
                stArrayData = strHeaderText.Split(","c)

                'チェック結果データ検索
                gintRtn = DLTP0401_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 25, gintSQLCODE, gstrSQLERRM)

                Select Case gintRtn
                    Case 0
                        Exit Select
                    Case 2
                        MsgBox(MSG_301005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                    Case 9
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        Exit Function
                End Select

                RowMax = gintResultCnt

                ''ヘッダ部
                .Pos(0, 0, 1, 1).Attr.FontPoint = 11                                    '文字サイズ
                .Pos(0, 0, 1, 1).Attr.FontStyle = FontStyle.Bold                        '文字列修飾＝太字
                .Pos(0, 0, 4, 3).Attr.VerticalAlignment = VerticalAlignment.Center      'テキスト縦位置=中心
                .Pos(0, 0, 1, 1).Attr.HorizontalAlignment = HorizontalAlignment.Right   'テキスト横位置=右
                .Pos(1, 0, 1, 1).Attr.Format = """\""#,##0;""\""-#,##0"                 '金額表示

                .Pos(0, 0).Str = str本文(0)
                .Pos(0, 1).Str = str本文(1)
                .Pos(0, 3).Str = str本文(2)
                .Pos(1, 0).Func("=E" & RowMax + 6, Nothing)
                .Pos(1, 1).Func("=ROUNDDOWN(B1*0.1,0)", Nothing)

                ''明細部
                .Pos(0, 4, ColMax - 1, 4).Attr.FontColor2 = xlColor.White                              '文字列色＝白
                .Pos(0, 4, ColMax - 1, 4).Attr.FontStyle = FontStyle.Bold                              '文字列修飾＝太字
                .Pos(0, 4, ColMax - 1, 4).Attr.BackColor = Color.FromArgb(91, 155, 213)                '背景色＝青
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.VerticalAlignment = VerticalAlignment.Center   'テキスト縦位置=中心
                .Pos(3, 5, 3, RowMax + 4).Attr.HorizontalAlignment = HorizontalAlignment.Right         'テキスト横位置=右(金額)
                .Pos(4, 5, 4, RowMax + 4).Attr.HorizontalAlignment = HorizontalAlignment.Right         'テキスト横位置=右(値引額)
                .Pos(5, 5, 5, RowMax + 4).Attr.HorizontalAlignment = HorizontalAlignment.Right         'テキスト横位置=右(消費税)
                .Pos(3, 5, 5, RowMax + 5).Attr.Format = "#,##0_ "                                      '数値表示

                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineLeft(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineTop(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineRight(BorderStyle.Thin, xlColor.Black)
                .Pos(0, 4, ColMax - 1, RowMax + 4).Attr.LineBottom(BorderStyle.Thin, xlColor.Black)


                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 4).Str = stData
                    .Pos(i, 4).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 5).Str = Results(RowCnt).strBuff(0)
                    .Pos(1, RowCnt + 5).Str = Results(RowCnt).strBuff(1)
                    .Pos(2, RowCnt + 5).Str = Results(RowCnt).strBuff(2)
                    .Pos(3, RowCnt + 5).Long = CInt(Results(RowCnt).strBuff(3))
                    .Pos(4, RowCnt + 5).Long = CInt(Results(RowCnt).strBuff(4))
                    .Pos(5, RowCnt + 5).Long = CInt(Results(RowCnt).strBuff(5))

                Next

                '最終行に合計追加
                .Pos(3, RowMax + 5).Func("=SUM(D6:D" & RowMax + 5 & ")", Nothing)
                .Pos(4, RowMax + 5).Func("=D" & RowMax + 6 & "*0.04", Nothing)
                .Pos(5, RowMax + 5).Func("=E" & RowMax + 6 & "*0.1", Nothing)

                .CloseBook(True)

            End With

            値引金額一覧作成処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

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