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
Imports NPOI.SS.UserModel
Imports System.IO


Public Class HARK301
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


            '需要先一覧取得
            If DLTP0997S_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, 0, 0, gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '需要先一覧
            For i = 0 To gint需要先Cnt - 1

                cmb需要先.Items.Add(New 需要先一覧(需要先Array(i).str需要先名, 需要先Array(i).lng需要先コード))

            Next

            '空白行追加
            cmb需要先.Items.Add(New 需要先一覧("", 0))

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

            Chk長期貸出番号出力区分.Checked = False
            Chk長期貸出番号出力区分.Visible = False

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

                Case 1 'Oliver取込処理エラー結果出力

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = False
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = True
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = False
                    txt取込ファイル.Enabled = False
                    btnファイル参照.Enabled = False

                Case 2 'OliverEAN読取結果チェック処理

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = False
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【OliverEANデータファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = False
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = False
                    txt取込ファイル.Enabled = True
                    btnファイル参照.Enabled = True

                Case 3 '長期貸出番号情報出力

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = True
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = False
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = True
                    txt取込ファイル.Enabled = False
                    btnファイル参照.Enabled = False

                Case 6 '有効期限切迫品出荷明細出力

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = False
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = True
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = False
                    txt取込ファイル.Enabled = False
                    btnファイル参照.Enabled = False

                Case 8 '発注入荷状況出力

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = False
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = False
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = False
                    txt取込ファイル.Enabled = False
                    btnファイル参照.Enabled = False

                Case Else

                    cmb需要先.SelectedIndex = gint需要先Cnt
                    cmb需要先.Enabled = True
                    txtDate.Text = ""
                    lbl取込ファイル.Text = "【取込ファイル】"
                    txt取込ファイル.Text = ""
                    txtDate.Enabled = True
                    Chk長期貸出番号出力区分.Checked = False
                    Chk長期貸出番号出力区分.Visible = False
                    txt取込ファイル.Enabled = True
                    btnファイル参照.Enabled = True

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
        Dim SubForm As Form

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

                    Select Case xxxintSubProgram_ID

                        Case 4 '長期貸出番号抹消処理

                            If フォームヘッダチェック処理() = False Then
                                cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                                Exit Sub
                            End If

                            SubForm = New HARK301S1(cmbサブプログラム.Text, xxxstrProgram_ID, xxxintSubProgram_ID, gintSPDシステムコード)

                            SubForm.ShowDialog(Me)
                            SubForm.Dispose()

                            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                            Initialize条件(0)
                            lb_Msg.Items.Clear()
                            cmbサブプログラム.Focus()

                        Case 7 '倉庫在庫照会

                            If フォームヘッダチェック処理() = False Then
                                cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                                Exit Sub
                            End If

                            SubForm = New HARK301S2(cmbサブプログラム.Text, xxxstrProgram_ID, xxxintSubProgram_ID, gintSPDシステムコード)

                            SubForm.ShowDialog(Me)
                            SubForm.Dispose()

                            cmbサブプログラム.SelectedIndex = gintサブプログラムCnt
                            Initialize条件(0)
                            lb_Msg.Items.Clear()
                            cmbサブプログラム.Focus()

                    End Select

                Case "ID3" '需要先

                    With DirectCast(cmb需要先.SelectedItem, 需要先一覧)
                        xxxlng需要先コード = .lng需要先コード
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

                Case 1 'Oliver取込処理エラー結果出力
                    Exit Sub

                Case 2 'OliverEAN読取結果チェック処理
                    strFilter = "txt Files (*.txt)|*.txt|All Files (*.*)|*.*"

                Case 3 '長期貸出番号情報出力
                    Exit Sub

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

                    ''処理中画面
                    'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                    '    .IsBackground = True
                    '}

                    'm_lording.Start()

                    Select Case xxxintSubProgram_ID

                        Case 1 'Oliver取込処理エラー結果出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_301017)

                            gblRtn = データ検索処理()

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "Oliver取込処理エラー", xxxintSubProgram_ID)


                        Case 2 'OliverEAN読取結果チェック処理

                            If テキスト取込処理(txt取込ファイル.Text.Trim) = False Then GoTo EndExecute

                            'テキスト取込
                            gintRtn = DLTP0301_PROC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn

                                Case 0 '正常終了

                                    Set_ListItem(1, MSG_301015)
                                    Set_ListItem(2, "")

                                    Exit Select

                                Case 9 'エラー

                                    取込エラーファイル複製処理()

                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_301016)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")

                                    GoTo EndExecute

                            End Select

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_301017)

                            gblRtn = データ検索処理()


                        Case 3 '長期貸出番号情報出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_301017)

                            gblRtn = データ検索処理()

                        Case 6 '有効期限切迫品出荷明細出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_301017)

                            gblRtn = データ検索処理()

                        Case 8 '発注入荷状況出力

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_301017)

                            gblRtn = データ検索処理()

                            'セッション情報削除
                            gintRtn = DLTP0998S_PROC0013(xxxstrProgram_ID, "発注入荷状況出力", xxxintSubProgram_ID)

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

            If フォームヘッダチェック処理() = False Then Exit Function

            'サブプログラムチェック
            If IsNull(cmbサブプログラム.Text.Trim) = True Then
                MsgBox(MSG_COM012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmbサブプログラム.Focus()
                Exit Function
            End If

            Select Case xxxintSubProgram_ID

                Case 1 'Oliver取込処理エラー結果出力

                    '対象日チェック
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


                Case 2 'OliverEAN読取結果チェック処理

                    '取込ファイルチェック
                    If IsNull(txt取込ファイル.Text.Trim) = True Then
                        MsgBox(MSG_301013, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    If Chk_FileExists(txt取込ファイル.Text.Trim) = False Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    If Not Get_FileNameWithoutExtension(txt取込ファイル.Text).Contains(HARKP3011ImpFileName) Then
                        MsgBox(MSG_101002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If

                    '拡張子比較
                    If Get_Extension(txt取込ファイル.Text).CompareTo(TXTExtension) <> 0 Then
                        MsgBox(MSG_101103, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt取込ファイル.Text = ""
                        txt取込ファイル.Focus()
                        Exit Function
                    End If


                Case 3 '長期貸出番号情報出力

                    '需要先全て
                    If xxxlng需要先コード = 0 Then

                        gintRtn = MsgBox(MSG_301026 & vbCr & MSG_301023, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)
                        If gintRtn = vbNo Then Exit Function

                    End If

                    '消費済みも出力
                    If Math.Abs(CInt(Chk長期貸出番号出力区分.Checked)) = 1 Then

                        gintRtn = MsgBox(MSG_301022 & vbCr & MSG_301023, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)
                        If gintRtn = vbNo Then Exit Function

                    End If

                Case 6 '有効期限切迫品出荷明細出力

                    '対象日チェック
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

                Case 8 '発注入荷状況出力

                    Exit Select

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

                Case 1 'Oliver取込処理エラー結果出力
                    Exit Function

                Case 2 'OliverEAN読取結果チェック処理

                    blnHeaderLine = False
                    Set_ListItem(0, "")
                    Set_ListItem(1, "【" & cmbサブプログラム.Text & "】")
                    Set_ListItem(1, MSG_301014)


                Case 3 '長期貸出番号情報出力
                    Exit Function

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

            Select Case xxxintSubProgram_ID

                Case 1 'Oliver取込処理エラー結果出力
                    FileName = Set_FilePath(txtデータ出力先.Text, "Oliver取込処理エラー結果_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                    strSheetName = "Oliver取込処理エラー結果"

                Case 2 'OliverEAN読取結果チェック処理
                    FileName = Set_FilePath(txtデータ出力先.Text, "OliverEAN読取結果データ_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                    strSheetName = "OliverEAN読取結果データ"

                Case 3 '長期貸出番号情報出力
                    FileName = Set_FilePath(txtデータ出力先.Text, "長期貸出番号一覧_" & cmb需要先.Text.Trim & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                    strSheetName = "長期貸出番号一覧"

                Case 6 '有効期限切迫品出荷明細出力
                    FileName = Set_FilePath(txtデータ出力先.Text, "有効期限切迫品出荷明細_" & cmb需要先.Text.Trim & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                    strSheetName = "有効期限切迫品出荷明細"

                Case 8 '発注入荷状況出力
                    FileName = Set_FilePath(txtデータ出力先.Text, "発注入荷状況明細_" & cmb需要先.Text.Trim & "_" & dtNow.ToString("yyyyMMddHHmmss") & ".xlsx")
                    strSheetName = "発注入荷状況明細"

                Case Else
                    Set_ListItem(1, MSG_301019)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            '出力ヘッダ取得
            gintRtn = DLTP0997S_FUNC005(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "出力ヘッダ")
            strHeaderText = gstrDLTP0997S_FUNC005

            '項目数取得
            gintRtn = DLTP0997S_FUNC004(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, 3, 99, "項目数")
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
                    .Pos(i, 0).Attr.HorizontalAlignment = AdvanceSoftware.ExcelCreator.HorizontalAlignment.Center       'テキスト横位置=中心
                    .Pos(i, 0).Str = stData
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    For ColCnt = 0 To ColMax - 1

                        .Pos(ColCnt, RowCnt + 1).Str = Results(RowCnt).strBuff(ColCnt)

                    Next

                Next

                .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, AdvanceSoftware.ExcelCreator.BorderStyle.Thin, Color.FromArgb(91, 155, 213))
                .Pos(0, 0, ColMax - 1, RowMax).Attr.Box(BoxType.Ltc, AdvanceSoftware.ExcelCreator.BorderStyle.Thin, Color.FromArgb(91, 155, 213))

                .CloseBook(True)

            End With

            データ出力処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　データ検索処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ検索処理() As Boolean

        Try

            データ検索処理 = False

            Select Case xxxintSubProgram_ID

                Case 1 'Oliver取込処理エラー結果出力
                    gintRtn = DLTP0301_PROC0010(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, txtDate.Text.Trim, gintSQLCODE, gstrSQLERRM)

                Case 2 'OliverEAN読取結果チェック処理
                    gintRtn = DLTP0301_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, gintSQLCODE, gstrSQLERRM)

                Case 3 '長期貸出番号情報出力
                    gintRtn = DLTP0301_PROC0013(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxlng需要先コード, Math.Abs(CInt(Chk長期貸出番号出力区分.Checked)), gintSQLCODE, gstrSQLERRM)

                Case 6 '有効期限切迫品出荷明細出力
                    gintRtn = DLTP0301_PROC0016(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, txtDate.Text.Trim, gintSQLCODE, gstrSQLERRM)

                Case 8 '発注入荷状況出力
                    gintRtn = DLTP0301_PROC0018(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, gintSQLCODE, gstrSQLERRM)

                Case Else
                    Set_ListItem(1, MSG_301019)
                    Set_ListItem(2, "")
                    Exit Function

            End Select

            Select Case gintRtn

                Case 0 '正常終了

                    gblRtn = データ出力処理()

                    If gblRtn = True Then

                        Set_ListItem(1, MSG_301020 & "【" & gintResultCnt & "】")
                        Set_ListItem(1, MSG_301018)
                        Set_ListItem(2, "")

                    Else

                        Set_ListItem(1, MSG_301019)
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
                    Set_ListItem(1, MSG_301019)
                    Set_ListItem(1, MSG_COM901)
                    Set_ListItem(2, "")
                    Exit Function


            End Select

            データ検索処理 = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　フォームヘッダチェック処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function フォームヘッダチェック処理() As Boolean

        Try
            フォームヘッダチェック処理 = False

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

            フォームヘッダチェック処理 = True

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