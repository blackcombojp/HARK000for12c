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
Imports System.Threading
Imports NPOI.OpenXmlFormats.Spreadsheet

Public Class HARK201
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
                txt連携データ出力先.Text = Get_DesktopPath()
                txt分納データ出力先.Text = Get_DesktopPath()
                txt未検品データ出力先.Text = Get_DesktopPath()
                txt有効期限切迫データ出力先.Text = Get_DesktopPath()
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
            cmb需要先.Focus()

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

            '需要先一覧取得
            If DLTP0997S_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, 0, gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '需要先一覧
            For i = 0 To gint需要先Cnt - 1

                cmb需要先.Items.Add(New 需要先一覧(需要先Array(i).str需要先名, 需要先Array(i).lng需要先コード))

            Next

            '空白行追加
            cmb需要先.Items.Add(New 需要先一覧("", 0))


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

            cmb需要先.SelectedIndex = gint需要先Cnt
            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt

            txt連携データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))
            txt分納データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先２, Get_DesktopPath))
            txt未検品データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先３, Get_DesktopPath))
            txt有効期限切迫データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先４, Get_DesktopPath))


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

                Case "ID4"  '有効期限切迫データ出力先

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

                Case "ID2"  '需要先

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
                            txt連携データ出力先.Text = Get_DesktopPath()
                            txt分納データ出力先.Text = Get_DesktopPath()
                            txt未検品データ出力先.Text = Get_DesktopPath()
                            txt有効期限切迫データ出力先.Text = Get_DesktopPath()
                        Else
                            txt連携データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))
                            txt分納データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先２, Get_DesktopPath))
                            txt未検品データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先３, Get_DesktopPath))
                            txt有効期限切迫データ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先４, Get_DesktopPath))

                        End If
                    End If

                Case "ID2" '需要先

                    With DirectCast(cmb需要先.SelectedItem, 需要先一覧)
                        xxxlng需要先コード = .lng需要先コード
                    End With

                Case "ID3" 'サブプログラム

                    With DirectCast(cmbサブプログラム.SelectedItem, サブプログラム一覧)
                        xxxintSubProgram_ID = .intサブプログラムコード
                    End With

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
            txt連携データ出力先.Focus()
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
            txt連携データ出力先.Focus()
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
    Private Sub Btnフォルダ参照_Click(sender As Object, e As EventArgs)

        Dim FDDlg As New FolderBrowserDialog
        Dim Tag As String

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Buttons.GcButton).Tag)

            Select Case Tag

                Case "ID1" '連携データ

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txt連携データ出力先.Text = ""
                        txt連携データ出力先.Text = FDDlg.SelectedPath

                    End If

                Case "ID2" '分納データ

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txt分納データ出力先.Text = ""
                        txt分納データ出力先.Text = FDDlg.SelectedPath

                    End If


                Case "ID3" '未検品データ

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txt未検品データ出力先.Text = ""
                        txt未検品データ出力先.Text = FDDlg.SelectedPath

                    End If

                Case "ID4" '有効期限切迫データ

                    If FDDlg.ShowDialog() = DialogResult.OK Then

                        txt有効期限切迫データ出力先.Text = ""
                        txt有効期限切迫データ出力先.Text = FDDlg.SelectedPath

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
        Dim m_lording As Thread = Nothing
        Dim strSendFile As String = Nothing

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

                        cmb需要先.SelectedIndex = gint需要先Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        lb_Msg.Items.Clear()
                        cmb需要先.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmb需要先.SelectedIndex = gint需要先Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        lb_Msg.Items.Clear()
                        cmb需要先.Focus()

                        Exit Sub

                    End If

                    Cursor = Cursors.WaitCursor

                    lb_Msg.Items.Add("")

                    '処理中画面
                    m_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                        .IsBackground = True
                    }

                    m_lording.Start()

                    Select Case xxxintSubProgram_ID


                        Case 1 'ピッキング連携データ出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, "【" & cmb需要先.Text & "】")
                            Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                            Set_ListItem(1, MSG_201007 & MSG_201001)

                            'ピッキング連携データ作成
                            gintRtn = DLTP0201_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, xxxintNo, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn

                                Case 8

                                    Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                                    Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                                    Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                                    Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                                    Set_ListItem(1, MSG_201006)
                                    Set_ListItem(2, "")

                                    GoTo EndExecute


                                Case 9

                                    Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                                    Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                                    Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                                    Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_201003)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")

                                    GoTo EndExecute


                            End Select

                            Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")

                            gblRtn = ピッキングデータEXCEL出力処理()

                            If ピッキング連携データ検索処理() = False Then GoTo EndExecute

                            If ピッキング連携データ出力結果更新処理() = False Then GoTo EndExecute

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_201010 & MSG_201001)

                            If 分納データ検索処理() = False Then GoTo EndExecute

                            If 分納データ出力結果更新処理() = False Then GoTo EndExecute

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_201012 & MSG_201001)

                            If 有効期限切迫データ検索処理() = False Then GoTo EndExecute

                            If 有効期限切迫データ出力結果更新処理() = False Then GoTo EndExecute


                        Case 2, 3 '出荷検品未完了データ出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, "【" & cmb需要先.Text & "】")
                            Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                            Set_ListItem(1, MSG_201008 & MSG_201001)

                            '出荷検品未完了データ検索
                            gintRtn = DLTP0201_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn

                                Case 2 '対象件数0件

                                    Set_ListItem(1, MSG_201006)
                                    Set_ListItem(2, "")

                                    'セッション情報削除
                                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "出荷検品未完了", xxxintSubProgram_ID)

                                    GoTo EndExecute


                                Case 9 'エラー

                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_201003)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")

                                    'セッション情報削除
                                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "出荷検品未完了", xxxintSubProgram_ID)

                                    GoTo EndExecute


                            End Select

                            If gintRtn = Excelデータ出力処理(1) Then

                                Select Case gintRtn

                                    Case 0 '正常終了
                                        Set_ListItem(1, MSG_201002)
                                        Set_ListItem(2, "")

                                    Case 9 '異常終了
                                        Set_ListItem(1, MSG_201003)
                                        Set_ListItem(2, "")

                                End Select

                            End If

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "出荷検品未完了", xxxintSubProgram_ID)

                    End Select

EndExecute:
                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                    cmb需要先.Focus()

                    Exit Sub


                Case "ID6" 'なし
                Case "ID7" 'なし
                Case "ID8" 'なし

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            '処理中画面廃棄
            If Not m_lording Is Nothing AndAlso m_lording.IsAlive Then
                m_lording.Abort()
                m_lording = Nothing
            End If

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

            '需要先
            If IsNull(cmb需要先.Text.Trim) = True Then
                MsgBox(MSG_COM013, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb需要先.Focus()
                Exit Function
            End If

            'サブプログラムチェック
            If IsNull(cmbサブプログラム.Text.Trim) = True Then
                MsgBox(MSG_COM012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmbサブプログラム.Focus()
                Exit Function
            End If

            '連携データ出力先チェック
            If IsNull(txt連携データ出力先.Text.Trim) = True Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt連携データ出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txt連携データ出力先.Text.Trim) = False Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt連携データ出力先.Text = ""
                txt連携データ出力先.Focus()
                Exit Function
            End If

            '分納データ出力先チェック
            If IsNull(txt分納データ出力先.Text.Trim) = True Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt分納データ出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txt分納データ出力先.Text.Trim) = False Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt分納データ出力先.Text = ""
                txt分納データ出力先.Focus()
                Exit Function
            End If

            '未検品データ出力先チェック
            If IsNull(txt未検品データ出力先.Text.Trim) = True Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt未検品データ出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txt未検品データ出力先.Text.Trim) = False Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt未検品データ出力先.Text = ""
                txt未検品データ出力先.Focus()
                Exit Function
            End If

            '有効期限切迫データ出力先チェック
            If IsNull(txt有効期限切迫データ出力先.Text.Trim) = True Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt有効期限切迫データ出力先.Focus()
                Exit Function
            End If

            If Chk_DirExists(txt有効期限切迫データ出力先.Text.Trim) = False Then
                MsgBox(MSG_101104, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt有効期限切迫データ出力先.Text = ""
                txt有効期限切迫データ出力先.Focus()
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
    ' *　モジュール機能　：　Excelデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　0 -- 成功 9 -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function Excelデータ出力処理(ByVal int出力種別 As Integer) As Integer

        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String = Nothing
        Dim stArrayData As String()
        Dim FileName As String = Nothing
        Dim strSheetName As String = Nothing
        Dim i As Integer
        Dim dtNow As DateTime = Now

        Try

            Excelデータ出力処理 = 9

            Select Case xxxintSubProgram_ID

                Case 1 'ピッキング連携データ出力

                    Select Case int出力種別

                        Case 1 'ピッキング連携データ

                            FileName = Set_FilePath(txt連携データ出力先.Text, "ピッキング連携データ_" & Results(0).strBuff(2) & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                            strSheetName = "ピッキング連携データ"

                            '出力ヘッダ取得
                            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 6, 99, "出力ヘッダ")
                            strHeaderText = gstrDLTP0997S_FUNC005

                            '項目数取得
                            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 6, 99, "項目数")
                            ColMax = gintDLTP0997S_FUNC004


                        Case 2 '分納データ

                            FileName = Set_FilePath(txt分納データ出力先.Text, "ピッキング連携分納データ_" & Results(0).strBuff(3) & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                            strSheetName = "ピッキング連携分納データ"

                            '出力ヘッダ取得
                            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "出力ヘッダ")
                            strHeaderText = gstrDLTP0997S_FUNC005

                            '項目数取得
                            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "項目数")
                            ColMax = gintDLTP0997S_FUNC004


                        Case 3 '有効期限切迫データ

                            FileName = Set_FilePath(txt有効期限切迫データ出力先.Text, "有効期限切迫データ_" & Results(0).strBuff(4) & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                            strSheetName = "有効期限切迫データ"

                            '出力ヘッダ取得
                            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 7, 99, "出力ヘッダ")
                            strHeaderText = gstrDLTP0997S_FUNC005

                            '項目数取得
                            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 7, 99, "項目数")
                            ColMax = gintDLTP0997S_FUNC004

                    End Select


                Case 2, 3 '出荷検品未完了データ出力

                    Select Case int出力種別

                        Case 1 '出荷検品未完了データ

                            FileName = Set_FilePath(txt未検品データ出力先.Text, "出荷検品未完了データ_" & Results(0).strBuff(2) & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                            strSheetName = "出荷検品未完了データ"

                            '出力ヘッダ取得
                            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 1, 99, "出力ヘッダ")
                            strHeaderText = gstrDLTP0997S_FUNC005

                            '項目数取得
                            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 1, 99, "項目数")
                            ColMax = gintDLTP0997S_FUNC004


                    End Select


                Case Else
                    Set_ListItem(1, MSG_201003)
                    Set_ListItem(2, "")

                    Exit Function

            End Select

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
                .SheetName = strSheetName                                                       'シート名
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

            Excelデータ出力処理 = 0

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ピッキング連携データ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function ピッキング連携データ検索処理() As Boolean

        Dim strFilePath As String
        Dim dtNow As DateTime = Now

        Try

            ピッキング連携データ検索処理 = False

            'データ検索
            gintRtn = DLTP0201_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    strFilePath = Set_FilePath(txt連携データ出力先.Text, "ピッキング連携_" & cmb需要先.Text & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".dat")

                    gblRtn = Output_RawData(strFilePath)

                    If gblRtn = True Then

                        Set_ListItem(1, MSG_201007 & MSG_201002)


                    Else

                        Set_ListItem(1, MSG_201007 & MSG_201003)
                        Set_ListItem(1, MSG_COM901)
                        Set_ListItem(2, "")
                        Exit Function


                    End If

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_201006)
                    Set_ListItem(2, "")


                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201007 & MSG_201003)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            ピッキング連携データ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ピッキング連携データ出力結果更新処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function ピッキング連携データ出力結果更新処理() As Boolean

        Try

            ピッキング連携データ出力結果更新処理 = False

            If gintResultCnt = 0 Then
                Return True
            End If

            '出力結果を元にテーブルを更新
            gintRtn = DLTP0201_PROC0021(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 8, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0

                    Set_ListItem(1, MSG_201007 & MSG_201004)
                    Set_ListItem(2, "")


                Case 9

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201007 & MSG_201005)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            ピッキング連携データ出力結果更新処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　分納データ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 分納データ検索処理() As Boolean

        Try

            分納データ検索処理 = False

            'エラーデータ検索
            gintRtn = DLTP0201_PROC0013(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    gintRtn = Excelデータ出力処理(2)

                    Select Case gintRtn

                        Case 0 '正常終了
                            Set_ListItem(1, MSG_201013 & gintResultCnt)
                            Set_ListItem(1, MSG_201010 & MSG_201002)

                        Case 9 '異常終了
                            Set_ListItem(1, MSG_201010 & MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")
                            Exit Function


                    End Select

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_201006)
                    Set_ListItem(2, "")


                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201010 & MSG_201003)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            分納データ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　分納データ出力結果更新処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 分納データ出力結果更新処理() As Boolean

        Try

            分納データ出力結果更新処理 = False

            If gintResultCnt = 0 Then
                Return True
            End If

            '出力結果を元にテーブルを更新
            gintRtn = DLTP0201_PROC0022(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 1, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0

                    Set_ListItem(1, MSG_201010 & MSG_201004)
                    Set_ListItem(2, "")


                Case 9

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201010 & MSG_201005)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            分納データ出力結果更新処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ピッキング連携データ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FileName -- 出力パス
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function Output_RawData(ByVal FileName As String) As Boolean

        Dim strstreamWriter As StreamWriter
        Dim strDataText As String
        Dim strHeaderText As String
        Dim strBreak As String = Nothing
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer

        Try

            Output_RawData = False

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 2, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '出力区切文字取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 2, 99, "出力区切文字")
            Select Case gstrDLTP0997S_FUNC005

                Case "TAB"
                    strBreak = vbTab

                Case "CSV"
                    strBreak = ","

                Case "NULL"
                    strBreak = ""

            End Select

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 2, 99, "項目数")
            ColMax = gintDLTP0997S_FUNC004


            '書き込み準備
            strstreamWriter = New StreamWriter(FileName, True, System.Text.Encoding.GetEncoding(932))

            If strHeaderText <> "NULL" Then
                'へッダ書き込み
                strstreamWriter.WriteLine(strHeaderText)
            End If

            For RowCnt = 0 To gintResultCnt - 1

                strDataText = ""

                For ColCnt = 0 To ColMax - 1

                    strDataText = strDataText & Chr(34) & Results(RowCnt).strBuff(ColCnt) & Chr(34) & strBreak

                Next

                Select Case gstrDLTP0997S_FUNC005

                    Case "CSV"
                        strDataText = strDataText.Substring(0, strDataText.Length - 1)

                    Case "TAB"
                        strDataText = strDataText.Trim

                End Select

                'データ書き込み
                strstreamWriter.WriteLine(strDataText)

            Next

            '後処理
            strstreamWriter.Flush()
            strstreamWriter.Close()

            Output_RawData = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ピッキングデータEXCEL出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function ピッキングデータEXCEL出力処理() As Boolean

        Try

            ピッキングデータEXCEL出力処理 = False

            'エラーデータ検索
            gintRtn = DLTP0201_PROC0014(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    gintRtn = Excelデータ出力処理(1)

                    Select Case gintRtn

                        Case 0 '正常終了
                            Set_ListItem(1, MSG_201013 & gintResultCnt)
                            Set_ListItem(1, MSG_201011 & MSG_201002)

                        Case 9 '異常終了
                            Set_ListItem(1, MSG_201011 & MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")
                            Exit Function


                    End Select

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_201006)
                    Set_ListItem(2, "")


                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201003)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            ピッキングデータEXCEL出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　有効期限切迫データ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 有効期限切迫データ検索処理() As Boolean

        Try

            有効期限切迫データ検索処理 = False

            'エラーデータ検索
            gintRtn = DLTP0201_PROC0015(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0 '正常終了

                    gintRtn = Excelデータ出力処理(3)

                    Select Case gintRtn

                        Case 0 '正常終了
                            Set_ListItem(1, MSG_201013 & gintResultCnt)
                            Set_ListItem(1, MSG_201012 & MSG_201002)

                        Case 9 '異常終了
                            Set_ListItem(1, MSG_201012 & MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")
                            Exit Function


                    End Select

                Case 2 '対象件数0件

                    Set_ListItem(1, MSG_201006)
                    Set_ListItem(2, "")


                Case 9 'エラー

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201003)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            有効期限切迫データ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　有効期限切迫データ出力結果更新処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 有効期限切迫データ出力結果更新処理() As Boolean

        Try

            有効期限切迫データ出力結果更新処理 = False

            If gintResultCnt = 0 Then
                Return True
            End If

            '出力結果を元にテーブルを更新
            gintRtn = DLTP0201_PROC0023(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 1, gintSQLCODE, gstrSQLERRM)

            Select Case gintRtn

                Case 0

                    Set_ListItem(1, MSG_201012 & MSG_201004)
                    Set_ListItem(2, "")


                Case 9

                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                    Set_ListItem(1, MSG_201012 & MSG_201005)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            有効期限切迫データ出力結果更新処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function

End Class