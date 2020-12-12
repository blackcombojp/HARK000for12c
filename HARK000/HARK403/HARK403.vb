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


Public Class HARK403
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
            '初期フォーカスを設定
            cmb売上先.Focus()

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

            '得意先一覧取得
            If DLTP0304_PROC0020(xxxstrProgram_ID, gintSPDシステムコード, 0, gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '得意先一覧
            For i = 0 To gint得意先Cnt - 1

                cmb売上先.Items.Add(New 得意先一覧(得意先Array(i).str得意先名, 得意先Array(i).lng得意先コード))

            Next

            '空白行追加
            cmb売上先.Items.Add(New 得意先一覧("全て", 0))


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

            cmb売上先.SelectedIndex = gint得意先Cnt
            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
            txt請求日.Text = ""


            txtデータ出力先.Text = CStr(Nvl(gudt処理端末情報.str出力先１, Get_DesktopPath))

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

                Case "ID1"  'データ出力先

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

                Case "ID2"  '売上先

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
        Dim i As Integer

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

                    cmb売上先.Items.Clear()

                    '得意先一覧取得
                    If DLTP0304_PROC0020(xxxstrProgram_ID, gintSPDシステムコード, 0, gintSQLCODE, gstrSQLERRM) = False Then

                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                        Exit Sub

                    End If

                    '得意先一覧
                    For i = 0 To gint得意先Cnt - 1

                        cmb売上先.Items.Add(New 得意先一覧(得意先Array(i).str得意先名, 得意先Array(i).lng得意先コード))

                    Next

                    '空白行追加
                    cmb売上先.Items.Add(New 得意先一覧("全て", 0))


                Case "ID2" '売上先

                    With DirectCast(cmb売上先.SelectedItem, 得意先一覧)
                        xxxlng売上先コード = .lng得意先コード
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
            txtデータ出力先.Focus()
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
            txtデータ出力先.Focus()
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
        'Dim m_lording As Thread = Nothing
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

                        cmb売上先.SelectedIndex = gint得意先Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        txt請求日.Text = ""
                        lb_Msg.Items.Clear()
                        cmb売上先.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmb売上先.SelectedIndex = gint得意先Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        txt請求日.Text = ""
                        lb_Msg.Items.Clear()
                        cmb売上先.Focus()

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
                    Set_ListItem(1, "【" & cmb売上先.Text & "】")
                    Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                    Set_ListItem(1, MSG_403002)

                    'データ作成
                    gintRtn = DLTP0403_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxlng売上先コード, txt請求日.Text.Trim, xxxintNo, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

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

                    '鑑データ検索
                    gintRtn = DLTP0403_PROC0021(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxintNo, gintSQLCODE, gstrSQLERRM)

                    Select Case gintRtn

                        Case 2

                            Set_ListItem(1, MSG_304005)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                        Case 9

                            Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                            Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                            Set_ListItem(1, MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                    End Select

                    Select Case xxxintSubProgram_ID

                        Case 1
                            If 請求鑑Excelデータ出力処理() = True Then
                                Set_ListItem(1, MSG_301018)
                                Set_ListItem(2, "")
                            Else
                                Set_ListItem(1, MSG_301019)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")
                            End If

                        Case 2
                            If Output_RawData() = True Then
                                Set_ListItem(1, MSG_301018)
                                Set_ListItem(2, "")
                            Else
                                Set_ListItem(1, MSG_301019)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")
                            End If

                    End Select

                    Set_ListItem(0, "")
                    Set_ListItem(1, MSG_403003)

                    '明細データ作成
                    gintRtn = DLTP0403_PROC0101(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxintNo, xxxintCnt(0), xxxintCnt(1), xxxintCnt(2), gintSQLCODE, gstrSQLERRM)

                    Select Case gintRtn

                        Case 8

                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                            Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                            Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")
                            Set_ListItem(1, MSG_201006)
                            Set_ListItem(1, MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                        Case 9

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

                    Set_ListItem(1, MSG_101111 & "【" & xxxintCnt(0) & "】")
                    Set_ListItem(1, MSG_101112 & "【" & xxxintCnt(1) & "】")
                    Set_ListItem(1, MSG_101113 & "【" & xxxintCnt(2) & "】")

                    'データ検索
                    gintRtn = DLTP0403_PROC0201(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxintNo, gintSQLCODE, gstrSQLERRM)

                    Select Case gintRtn

                        Case 2

                            Set_ListItem(1, MSG_304005)
                            Set_ListItem(1, MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                        Case 9

                            Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                            Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                            Set_ListItem(1, MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                    End Select

                    Select Case xxxintSubProgram_ID

                        Case 1
                            If 請求明細Excelデータ出力処理() = True Then
                                Set_ListItem(1, MSG_301018)
                                Set_ListItem(2, "")
                            Else
                                Set_ListItem(1, MSG_301019)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")
                            End If

                        Case 2
                            If Output_RawDataDetail() = True Then
                                Set_ListItem(1, MSG_301018)
                                Set_ListItem(2, "")
                            Else
                                Set_ListItem(1, MSG_301019)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")
                            End If

                    End Select

EndExecute:
                    'セッション情報削除
                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "徳洲会請求情報送信", 1) '鑑
                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "徳洲会請求情報送信", 2) '明細

                    cmb売上先.SelectedIndex = gint得意先Cnt
                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                    txt請求日.Text = ""
                    cmb売上先.Focus()

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

            '売掛先
            If IsNull(cmb売上先.Text.Trim) = True Then
                MsgBox(MSG_304001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb売上先.Focus()
                Exit Function
            End If

            'サブプログラムチェック
            If IsNull(cmbサブプログラム.Text.Trim) = True Then
                MsgBox(MSG_COM012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmbサブプログラム.Focus()
                Exit Function
            End If

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

            '請求日チェック
            If IsNull(txt請求日.Text.Trim) = True Then
                MsgBox(MSG_403001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt請求日.Focus()
                Exit Function
            End If

            If Chk_Date(txt請求日.Text.Trim, 1) = False Then
                txt請求日.Text = ""
                MsgBox(MSG_301012, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                txt請求日.Focus()
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
    ' *　モジュール機能　：　請求鑑Excelデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　0 -- 成功 9 -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 請求鑑Excelデータ出力処理() As Boolean

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

            請求鑑Excelデータ出力処理 = False

            FileName = Set_FilePath(txtデータ出力先.Text, Results(0).strBuff(1) & "_BILL_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
            strSheetName = Results(0).strBuff(1) & "_BILL_" & dtNow.ToString("yyyyMMddHHmmss")

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 4, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 4, 99, "項目数")
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

            請求鑑Excelデータ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　請求明細Excelデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　0 -- 成功 9 -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function 請求明細Excelデータ出力処理() As Boolean

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

            請求明細Excelデータ出力処理 = False

            FileName = Set_FilePath(txtデータ出力先.Text, Results(0).strBuff(1) & "_BILLDT_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
            strSheetName = Results(0).strBuff(1) & "_BILLDT_" & dtNow.ToString("yyyyMMddHHmmss")

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 5, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 5, 99, "項目数")
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
                .SheetName = strSheetName                                                       'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                       '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                       '文字列修飾＝太字
                .Pos(0, 0, 27, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)                 '背景色＝青
                .Pos(28, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(255, 101, 101)       '背景色＝赤


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

            請求明細Excelデータ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　CSVデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FileName -- 出力パス
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function Output_RawData() As Boolean

        Dim strstreamWriter As StreamWriter
        Dim strDataText As String
        Dim strHeaderText As String
        Dim strBreak As String = Nothing
        Dim FileName As String
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim dtNow As DateTime = Now

        Try

            Output_RawData = False

            FileName = Set_FilePath(txtデータ出力先.Text, Results(0).strBuff(1) & "_BILL_" & dtNow.ToString("yyyyMMddHHmmss") & ".csv")

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 4, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '出力区切文字取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 4, 99, "出力区切文字")
            Select Case gstrDLTP0997S_FUNC005

                Case "TAB"
                    strBreak = vbTab

                Case "CSV"
                    strBreak = ","

                Case "NULL"
                    strBreak = ""

            End Select

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 4, 99, "項目数")
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

                    'strDataText = strDataText & Chr(34) & Results(RowCnt).strBuff(ColCnt) & Chr(34) & strBreak
                    strDataText = strDataText & Results(RowCnt).strBuff(ColCnt) & strBreak

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
    ' *　モジュール機能　：　請求明細CSVデータ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　FileName -- 出力パス
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function Output_RawDataDetail() As Boolean

        Dim strstreamWriter As StreamWriter
        Dim strDataText As String
        Dim strHeaderText As String
        Dim strBreak As String = Nothing
        Dim FileName As String
        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim dtNow As DateTime = Now

        Try

            Output_RawDataDetail = False

            FileName = Set_FilePath(txtデータ出力先.Text, Results(0).strBuff(1) & "_BILLDT_" & dtNow.ToString("yyyyMMddHHmmss") & ".csv")

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 5, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '出力区切文字取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 5, 99, "出力区切文字")
            Select Case gstrDLTP0997S_FUNC005

                Case "TAB"
                    strBreak = vbTab

                Case "CSV"
                    strBreak = ","

                Case "NULL"
                    strBreak = ""

            End Select

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 5, 99, "項目数")
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

                    'strDataText = strDataText & Chr(34) & Results(RowCnt).strBuff(ColCnt) & Chr(34) & strBreak
                    strDataText = strDataText & Results(RowCnt).strBuff(ColCnt) & strBreak

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

            Output_RawDataDetail = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function

End Class