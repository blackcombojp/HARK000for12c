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


Public Class HARK503
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
                txt得意先コード.Focus()
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
            txt得意先コード.Focus()

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
    ' *  モジュール機能　： キーダウン処理
    ' *
    ' *  注意、制限事項  ：なし
    ' *  引数　　　　　　：sender・・オブジェクト識別クラス
    ' *      　　　　　　：e・・イベントデータクラス
    ' *　戻値　　　　　　：なし
    ' *-----------------------------------------------------------------------------/ 
    Private Sub Cmb_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, ComboBox).Tag)

            Select Case Tag

                Case "ID3" '許可証区分

                    If xxxint引用 = 1 AndAlso e.KeyCode = Keys.Enter Then Exit Sub

            End Select

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

            cmb引用.Items.Add("しない")
            cmb引用.Items.Add("する")

            cmb許可証区分.Items.Add("高度管理")
            cmb許可証区分.Items.Add("医薬品")
            cmb許可証区分.Items.Add("修理業")
            cmb許可証区分.Items.Add("毒物劇物")
            cmb許可証区分.Items.Add("動物用高度管理")
            cmb許可証区分.Items.Add("医療機関番号")
            cmb許可証区分.Items.Add("")

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

            cmb引用.SelectedIndex = 0
            Initialize明細(0)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　各種コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　int区分 -- 0・・引用しない、1・・引用する
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize明細(ByVal int区分 As Integer)

        Try

            Select Case int区分

                Case 0
                    txt得意先コード.Text = ""
                    lbl得意先名.Text = ""
                    txt引用元得意先コード.Text = ""
                    lbl引用元得意先名.Text = ""
                    lbl引用元得意先.Visible = False
                    txt引用元得意先コード.Visible = False
                    lbl引用元得意先名.Visible = False
                    cmb許可証区分.SelectedIndex = 6
                    txt許可証番号.Text = ""
                    txt許可開始日.Text = ""
                    txt許可終了日.Text = ""
                    txt取込ファイル.Text = ""
                    txt許可証番号.Enabled = True
                    txt許可開始日.Enabled = True
                    txt許可終了日.Enabled = True
                    txt取込ファイル.Enabled = True
                    btnファイル参照.Enabled = True

                    xxxint引用 = 0
                    xxxint許可証区分 = 7


                Case 1
                    ' txt得意先コード.Text = ""
                    ' lbl得意先名.Text = ""
                    txt引用元得意先コード.Text = ""
                    lbl引用元得意先名.Text = ""
                    lbl引用元得意先.Visible = True
                    txt引用元得意先コード.Visible = True
                    lbl引用元得意先名.Visible = True
                    cmb許可証区分.SelectedIndex = 6
                    txt許可証番号.Text = ""
                    txt許可開始日.Text = ""
                    txt許可終了日.Text = ""
                    txt取込ファイル.Text = ""
                    txt許可証番号.Enabled = False
                    txt許可開始日.Enabled = False
                    txt許可終了日.Enabled = False
                    txt取込ファイル.Enabled = False
                    btnファイル参照.Enabled = False

                    xxxint引用 = 1
                    xxxint許可証区分 = 7


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

                Case "ID1" '得意先コード

                    If e.Shift = True Then

                        Select Case e.KeyCode

                            'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

                Case "ID4"  '取込ファイル

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
    ' *　モジュール機能　：　テキストボックスフォーカス検証後
    ' *
    ' *　注意、制限事項　：　なし
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

                        If DLTP0900_PROC0004(xxxstrProgram_ID, CLng(txt得意先コード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
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

                Case "ID2" '引用元得意先コード

                    If IsNull(txt引用元得意先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0004(xxxstrProgram_ID, CLng(txt引用元得意先コード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txt引用元得意先コード.Text = ""
                            lbl引用元得意先名.Text = ""
                            txt引用元得意先コード.Focus()
                        Else
                            lbl引用元得意先名.Text = gstr得意先名
                        End If
                    Else
                        txt引用元得意先コード.Text = ""
                        lbl引用元得意先名.Text = ""
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

                Case "ID3" '許可証区分

                    If xxxint引用 = 1 AndAlso e.Shift = False Then

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


                Case "ID2" '区分

                    xxxint引用 = cmb引用.SelectedIndex
                    Initialize明細(cmb引用.SelectedIndex)


                Case "ID3" '許可証区分

                    xxxint許可証区分 = cmb許可証区分.SelectedIndex + 1

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
            OFDlg.Filter = "tif Files (*.tif)|*.tif"
            OFDlg.FilterIndex = 1
            OFDlg.RestoreDirectory = True

            If OFDlg.ShowDialog() = DialogResult.OK Then

                txt取込ファイル.Text = OFDlg.FileName
                txt得意先コード.Focus()

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

                        cmb引用.SelectedIndex = 0
                        Initialize明細(0)
                        lb_Msg.Items.Clear()
                        txt得意先コード.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub


                    Select Case xxxint引用

                        Case 0 '引用しない

                            '許可証確認
                            gintRtn = DLTP0503_FUNC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, CLng(txt得意先コード.Text.Trim), xxxint許可証区分, 1)

                            Select Case gintRtn

                                Case 0

                                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                                    If gintRtn = vbNo Then

                                        cmb引用.SelectedIndex = 0
                                        Initialize明細(0)
                                        txt得意先コード.Focus()
                                        Exit Sub

                                    End If

                                Case 1

                                    gintRtn = MsgBox(MSG_503011 & vbCr & MSG_503012, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                                    If gintRtn = vbNo Then

                                        cmb引用.SelectedIndex = 0
                                        Initialize明細(0)
                                        txt得意先コード.Focus()
                                        Exit Sub

                                    End If

                                Case Else

                                    Throw New Exception(MSG_503015)

                            End Select

                            Cursor = Cursors.WaitCursor

                            lb_Msg.Items.Add("")

                            ''処理中画面
                            'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                            '    .IsBackground = True
                            '}

                            'm_lording.Start()

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_101133 & lbl得意先名.Text.Trim)
                            Set_ListItem(1, MSG_503017 & cmb許可証区分.Text.Trim)
                            Set_ListItem(1, MSG_503007)

                            Select Case xxxint許可証区分

                                '通常
                                Case 1, 2, 3, 4, 5

                                    '許可証登録
                                    gintRtn = DLTP0503_PROC0001(xxxstrProgram_ID,
                                                                gintSPDシステムコード,
                                                                xxxintSubProgram_ID,
                                                                xxxint引用,
                                                                CLng(txt得意先コード.Text.Trim),
                                                                DUMMY_LNGCODE,
                                                                txt許可証番号.Text.Trim,
                                                                txt許可開始日.Text.Trim,
                                                                txt許可終了日.Text.Trim,
                                                                xxxint許可証区分,
                                                                txt取込ファイル.Text.Trim,
                                                                gintSQLCODE,
                                                                gstrSQLERRM)

                                '医療機関番号
                                Case 6

                                    '許可証登録
                                    gintRtn = DLTP0503_PROC0001(xxxstrProgram_ID,
                                                                gintSPDシステムコード,
                                                                xxxintSubProgram_ID,
                                                                xxxint引用,
                                                                CLng(txt得意先コード.Text.Trim),
                                                                DUMMY_LNGCODE,
                                                                txt許可証番号.Text.Trim,
                                                                vbNullString,
                                                                vbNullString,
                                                                xxxint許可証区分,
                                                                DUMMY_STRCODE,
                                                                gintSQLCODE,
                                                                gstrSQLERRM)

                            End Select

                            Select Case gintRtn

                                Case 0

                                    Set_ListItem(1, MSG_503013)
                                    Set_ListItem(2, "")

                                Case Else

                                    取込エラーファイル複製処理()

                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_503014)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")

                            End Select

                        Case 1 '引用する

                            '許可証確認
                            gintRtn = DLTP0503_FUNC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, CLng(txt引用元得意先コード.Text.Trim), xxxint許可証区分, 1)

                            Select Case gintRtn

                                Case 0

                                    gintRtn = MsgBox(MSG_503009, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)

                                    cmb引用.SelectedIndex = 1
                                    Initialize明細(1)
                                    cmb許可証区分.Focus()
                                    Exit Sub

                                Case 1

                                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                                    If gintRtn = vbNo Then

                                        cmb引用.SelectedIndex = 0
                                        Initialize明細(0)
                                        txt得意先コード.Focus()
                                        Exit Sub

                                    End If

                                Case Else

                                    Throw New Exception(MSG_503016)

                            End Select

                            Cursor = Cursors.WaitCursor

                            lb_Msg.Items.Add("")

                            ''処理中画面
                            'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                            '    .IsBackground = True
                            '}

                            'm_lording.Start()

                            Set_ListItem(0, "")
                            Set_ListItem(1, MSG_101133 & lbl得意先名.Text.Trim)
                            Set_ListItem(1, MSG_503017 & cmb許可証区分.Text.Trim)
                            Set_ListItem(1, MSG_503007)

                            '許可証登録
                            gintRtn = DLTP0503_PROC0001(xxxstrProgram_ID,
                                                        gintSPDシステムコード,
                                                        xxxintSubProgram_ID,
                                                        xxxint引用,
                                                        CLng(txt得意先コード.Text.Trim),
                                                        CLng(txt引用元得意先コード.Text.Trim),
                                                        DUMMY_STRCODE,
                                                        vbNullString,
                                                        vbNullString,
                                                        xxxint許可証区分,
                                                        DUMMY_STRCODE,
                                                        gintSQLCODE,
                                                        gstrSQLERRM)


                            Select Case gintRtn

                                Case 0

                                    Set_ListItem(1, MSG_503013)
                                    Set_ListItem(2, "")

                                Case 4

                                    Set_ListItem(1, MSG_503009)
                                    Set_ListItem(2, "")

                                Case Else

                                    Set_ListItem(1, MSG_COM899 & gintSQLCODE)
                                    Set_ListItem(1, MSG_COM900 & gstrSQLERRM)
                                    Set_ListItem(1, MSG_503014)
                                    Set_ListItem(1, MSG_COM901)
                                    Set_ListItem(2, "")

                            End Select

                    End Select

                    cmb引用.SelectedIndex = 0
                    Initialize明細(0)
                    txt得意先コード.Focus()

                    Exit Sub

                    Exit Select

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

            '事業所
            If IsNull(cmb事業所.Text.Trim) = True Then
                MsgBox(MSG_COM007, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb事業所.Focus()
                Exit Function
            End If

            '入力担当
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

            '得意先
            If IsNull(txt得意先コード.Text.Trim) = True Then
                MsgBox(MSG_402002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt得意先コード.Focus()
                Exit Function
            End If

            If DLTP0900_PROC0004(xxxstrProgram_ID, CLng(txt得意先コード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                txt得意先コード.Focus()
                txt得意先コード.Text = ""
                lbl得意先名.Text = ""
            Else
                lbl得意先名.Text = gstr得意先名
            End If

            Select Case xxxint引用

                Case 0 '引用しない

                    '許可証区分
                    If IsNull(cmb許可証区分.Text.Trim) = True Then
                        MsgBox(MSG_503001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        cmb許可証区分.Focus()
                        Exit Function
                    End If

                    '許可証番号
                    If IsNull(txt許可証番号.Text.Trim) = True Then
                        MsgBox(MSG_503002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt許可証番号.Focus()
                        Exit Function
                    End If

                    '医療機関番号はチェック不要
                    If xxxint許可証区分 < 6 Then

                        '許可開始日
                        If IsNull(txt許可開始日.Text.Trim) = True Then
                            MsgBox(MSG_503003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            txt許可開始日.Focus()
                            Exit Function
                        End If

                        If Chk_Date(txt許可開始日.Text.Trim, 1) = False Then
                            txt許可開始日.Text = ""
                            MsgBox(MSG_301012, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                            txt許可開始日.Focus()
                            Exit Function
                        End If

                        '許可終了日
                        If IsNull(txt許可終了日.Text.Trim) = True Then
                            MsgBox(MSG_503004, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            txt許可終了日.Focus()
                            Exit Function
                        End If

                        If Chk_Date(txt許可終了日.Text.Trim, 1) = False Then
                            txt許可終了日.Text = ""
                            MsgBox(MSG_301012, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, My.Application.Info.Title)
                            txt許可終了日.Focus()
                            Exit Function
                        End If

                        '取込ファイルチェック
                        If IsNull(txt取込ファイル.Text.Trim) = True Then
                            MsgBox(MSG_503005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
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
                        If Get_Extension(txt取込ファイル.Text).CompareTo(TIFExtension) <> 0 Then
                            MsgBox(MSG_101103, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            txt取込ファイル.Text = ""
                            txt取込ファイル.Focus()
                            Exit Function
                        End If

                    End If

                Case 1 '引用する

                    '引用元得意先
                    If IsNull(txt引用元得意先コード.Text.Trim) = True Then
                        MsgBox(MSG_503006, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt引用元得意先コード.Focus()
                        Exit Function
                    End If

                    If DLTP0900_PROC0004(xxxstrProgram_ID, CLng(txt引用元得意先コード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
                        MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                        txt引用元得意先コード.Focus()
                        txt引用元得意先コード.Text = ""
                        lbl引用元得意先名.Text = ""
                        Exit Function
                    Else
                        lbl引用元得意先名.Text = gstr得意先名
                    End If

                    If txt得意先コード.Text.Trim = txt引用元得意先コード.Text.Trim Then
                        MsgBox(MSG_503008 & vbCr & MSG_503010, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt引用元得意先コード.Focus()
                        txt引用元得意先コード.Text = ""
                        lbl引用元得意先名.Text = ""
                        Exit Function
                    End If

                    '許可証区分
                    If IsNull(cmb許可証区分.Text.Trim) = True Then
                        MsgBox(MSG_503001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        cmb許可証区分.Focus()
                        Exit Function
                    End If

                    '引用元許可証確認
                    gintRtn = DLTP0503_FUNC0001(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, CLng(txt引用元得意先コード.Text.Trim), xxxint許可証区分, 1)

                    If gintRtn = 0 Or gintRtn = 9 Then
                        MsgBox(MSG_503009 & vbCr & MSG_503010, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        cmb許可証区分.SelectedIndex = 5
                        cmb許可証区分.Focus()
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