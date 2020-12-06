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
Imports System.Threading
Imports GrapeCity.ActiveReports


Public Class HARK502
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
            cmb医薬品区分.Focus()

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


            '項目一覧取得
            If DLTP0901_PROC0005(xxxstrProgram_ID, "医薬区分", gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '項目一覧
            For i = 0 To gint項目辞書Cnt - 1

                cmb医薬品区分.Items.Add(New 項目辞書一覧(項目辞書Array(i).str名称, 項目辞書Array(i).intコード))

            Next

            '空白行追加
            cmb医薬品区分.Items.Add(New 項目辞書一覧("", 99))



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

            cmb医薬品区分.SelectedIndex = gint項目辞書Cnt
            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
            txt対象開始月.Text = ""
            txt対象終了月.Text = ""

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

                Case 1, 3 'ファイル出力

                    txtデータ出力先.Enabled = True
                    btnフォルダ参照.Enabled = True

                Case 2, 4 '印刷

                    txtデータ出力先.Enabled = False
                    btnフォルダ参照.Enabled = False

                Case Else

                    cmb医薬品区分.SelectedIndex = gint項目辞書Cnt
                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
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

                Case "ID2"  '医薬品区分

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
        '  Dim i As Integer

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

                Case "ID2" '医薬品区分

                    With DirectCast(cmb医薬品区分.SelectedItem, 項目辞書一覧)
                        xxxint医薬品区分 = .intコード
                    End With

                Case "ID3" 'サブプログラム

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
            cmb医薬品区分.Focus()
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
            cmb医薬品区分.Focus()
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
        Dim m_lording As Thread = Nothing

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

                        cmb医薬品区分.SelectedIndex = gint項目辞書Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        txt対象開始月.Text = ""
                        txt対象終了月.Text = ""
                        Initialize条件(0)
                        lb_Msg.Items.Clear()
                        cmb医薬品区分.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    ''★★
                    ''開発中
                    'If xxxintSubProgram_ID = 2 Or xxxintSubProgram_ID = 4 Then
                    '    MsgBox(MSG_COM906, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    '    Exit Sub
                    'End If

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmb医薬品区分.SelectedIndex = gint項目辞書Cnt
                        cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                        txt対象開始月.Text = ""
                        txt対象終了月.Text = ""
                        Initialize条件(0)
                        cmb医薬品区分.Focus()

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
                        Case 1, 2
                            xxxint処理対象区分 = 1
                        Case 3, 4
                            xxxint処理対象区分 = 2
                    End Select

                    Set_ListItem(0, "")
                    Set_ListItem(1, "【" & cmb医薬品区分.Text & "】")
                    Set_ListItem(1, cmbサブプログラム.Text)
                    Set_ListItem(1, MSG_301017)

                    Select Case xxxintSubProgram_ID
                        Case 1, 3
                            'データ作成
                            gintRtn = DLTP0502_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxint医薬品区分, txt対象開始月.Text.Trim, txt対象終了月.Text.Trim, xxxint処理対象区分, xxxintNo, xxxintCnt, gintSQLCODE, gstrSQLERRM)
                        Case 2, 4
                            'データ作成
                            gintRtn = DLTP0502_PROC0002(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxint医薬品区分, txt対象開始月.Text.Trim, txt対象終了月.Text.Trim, xxxint処理対象区分, xxxintNo, xxxintCnt, gintSQLCODE, gstrSQLERRM)
                    End Select

                    Select Case gintRtn

                        Case 8

                            Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt & "】")
                            Set_ListItem(1, MSG_201006)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                        Case 9

                            Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                            Set_ListItem(1, MSG_101111 & "【" & xxxintCnt & "】")
                            Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                            Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                            Set_ListItem(1, MSG_201003)
                            Set_ListItem(1, MSG_COM901)
                            Set_ListItem(2, "")

                            GoTo EndExecute


                    End Select

                    Set_ListItem(1, MSG_201009 & "《" & xxxintNo & "》")
                    Set_ListItem(1, MSG_101111 & "【" & xxxintCnt & "】")

                    Select Case xxxintSubProgram_ID
                        Case 1, 3
                            'データ検索
                            gintRtn = DLTP0502_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxintNo, gintSQLCODE, gstrSQLERRM)
                        Case 2, 4
                            ''データ検索
                            gintRtn = DLTP0502_PROC0012(xxxstrProgram_ID, gintSPDシステムコード, 0, xxxintNo, gintSQLCODE, gstrSQLERRM)
                    End Select

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

                        Case 1, 3
                            If データ出力処理() = True Then
                                Set_ListItem(1, MSG_301018)
                                Set_ListItem(2, "")
                            Else
                                Set_ListItem(1, MSG_301019)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")
                            End If

                        Case 2, 4

                            Try
                                gblRtn = 印刷用データ作成処理()

                                '印刷
                                If Viewer Is Nothing Then Viewer = New HARK991()
                                If Reports Is Nothing Then Reports = New HARK502Reports()

                                Reports.DataSource = HARK502DS.ds一覧

                                'ActiveReports実行
                                Reports.Run()
                                Viewer.ViewerCtl.LoadDocument(Reports)

                                Set_ListItem(1, MSG_502007)
                                Set_ListItem(2, "")

                                '処理中画面廃棄
                                If Not m_lording Is Nothing AndAlso m_lording.IsAlive Then
                                    m_lording.Abort()
                                    m_lording = Nothing
                                End If

                                Viewer.ShowDialog()

                            Catch ex As Exception

                                log.Error(Set_ErrMSG(Err.Number, ex.ToString))

                                Set_ListItem(1, MSG_502006)
                                Set_ListItem(1, MSG_COM901)
                                Set_ListItem(2, "")

                            Finally

                                If Not Reports Is Nothing Then Reports = Nothing
                                If Not Viewer Is Nothing Then Viewer = Nothing

                            End Try

                    End Select

EndExecute:
                    'セッション情報削除
                    gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "医薬品入出庫履歴", xxxint処理対象区分)

                    cmb医薬品区分.SelectedIndex = gint項目辞書Cnt
                    cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                    txt対象開始月.Text = ""
                    txt対象終了月.Text = ""
                    Initialize条件(0)
                    cmb医薬品区分.Focus()

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

            '医薬品区分チェック
            If IsNull(cmb医薬品区分.Text.Trim) = True Then
                MsgBox(MSG_502001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb医薬品区分.Focus()
                Exit Function
            End If

            'サブプログラムチェック
            If IsNull(cmbサブプログラム.Text.Trim) = True Then
                MsgBox(MSG_COM012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmbサブプログラム.Focus()
                Exit Function
            End If

            '対象開始月
            If IsNull(txt対象開始月.Text.Trim) = True Then
                MsgBox(MSG_502002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt対象開始月.Focus()
                Exit Function
            End If

            If Chk_Date(txt対象開始月.Text.Trim, 2) = False Then
                txt対象開始月.Text = ""
                MsgBox(MSG_502003, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                txt対象開始月.Focus()
                Exit Function
            End If

            '対象終了月
            If IsNull(txt対象終了月.Text.Trim) = True Then
                MsgBox(MSG_502004, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt対象終了月.Focus()
                Exit Function
            End If

            If Chk_Date(txt対象終了月.Text.Trim, 2) = False Then
                txt対象終了月.Text = ""
                MsgBox(MSG_502005, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                txt対象終了月.Focus()
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

            実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：  データ出力処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ出力処理() As Boolean

        Dim ColCnt As Integer
        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String
        Dim stArrayData As String()
        Dim FileName As String
        Dim strSheetName As String
        Dim i As Integer
        Dim dtNow As DateTime = Now

        Try

            データ出力処理 = False

            FileName = Set_FilePath(txtデータ出力先.Text, "医薬品入出庫履歴_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
            strSheetName = "医薬品入出庫履歴"

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, 0, 3, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, 0, 3, 99, "項目数")
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

            データ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　印刷用データ作成処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 印刷用データ作成処理() As Boolean

        Dim intRowCnt As Integer

        Try

            印刷用データ作成処理 = False

            HARK502DS.ds一覧.Clear()

            For intRowCnt = 0 To gintResultCnt - 1

                HARK502DS.ds一覧.Addds一覧Row(CInt(Results(intRowCnt).strBuff(0)),
                                              Results(intRowCnt).strBuff(1),
                                              Results(intRowCnt).strBuff(2),
                                              Results(intRowCnt).strBuff(3),
                                              CLng(Results(intRowCnt).strBuff(4)),
                                              Results(intRowCnt).strBuff(5),
                                              Results(intRowCnt).strBuff(6),
                                              Results(intRowCnt).strBuff(7),
                                              Results(intRowCnt).strBuff(8),
                                              Results(intRowCnt).strBuff(9),
                                              CDbl(Results(intRowCnt).strBuff(10)),
                                              Results(intRowCnt).strBuff(11),
                                              Results(intRowCnt).strBuff(12),
                                              CLng(Results(intRowCnt).strBuff(13)),
                                              CInt(Results(intRowCnt).strBuff(14)),
                                              CLng(Results(intRowCnt).strBuff(15)),
                                              Results(intRowCnt).strBuff(16),
                                              CDbl(Results(intRowCnt).strBuff(17)),
                                              CDbl(Results(intRowCnt).strBuff(18)),
                                              CDbl(Results(intRowCnt).strBuff(19)),
                                              Results(intRowCnt).strBuff(20),
                                              CDbl(Results(intRowCnt).strBuff(21)),
                                              Results(intRowCnt).strBuff(22),
                                              Results(intRowCnt).strBuff(23),
                                              Results(intRowCnt).strBuff(24),
                                              CLng(Results(intRowCnt).strBuff(25)),
                                              CLng(Results(intRowCnt).strBuff(26)))

            Next

            印刷用データ作成処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
End Class