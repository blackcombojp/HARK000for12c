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
Imports GrapeCity.Win.MultiRow


Public Class HARK504
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
                txt検索得意先コード.Focus()
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
            txt検索得意先コード.Focus()
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
            OraTrnRollBack()
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
            OraTrnRollBack()
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

            '名称辞書一覧取得
            If DLTP0901_PROC0004(xxxstrProgram_ID, "業種コード", gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '名称辞書一覧
            For i = 0 To gint名称辞書Cnt - 1

                cmb検索分類１.Items.Add(New 名称辞書一覧(名称辞書Array(i).str名称, 名称辞書Array(i).strコード))

            Next

            '空白行追加
            cmb検索分類１.Items.Add(New 名称辞書一覧("", "0"))

            '許可証種別
            cmb検索許可証１.Items.Add("高度管理")
            cmb検索許可証１.Items.Add("医薬品")
            cmb検索許可証１.Items.Add("修理業")
            cmb検索許可証１.Items.Add("毒物劇物")
            cmb検索許可証１.Items.Add("動物用高度管理")
            cmb検索許可証１.Items.Add("医療機関番号")
            cmb検索許可証１.Items.Add("")

            '名称辞書一覧
            For i = 0 To gint名称辞書Cnt - 1

                cmb検索分類２.Items.Add(New 名称辞書一覧(名称辞書Array(i).str名称, 名称辞書Array(i).strコード))

            Next

            '空白行追加
            cmb検索分類２.Items.Add(New 名称辞書一覧("", "0"))

            '許可証種別
            cmb検索許可証２.Items.Add("高度管理")
            cmb検索許可証２.Items.Add("医薬品")
            cmb検索許可証２.Items.Add("修理業")
            cmb検索許可証２.Items.Add("毒物劇物")
            cmb検索許可証２.Items.Add("動物用高度管理")
            cmb検索許可証２.Items.Add("医療機関番号")
            cmb検索許可証２.Items.Add("")

            'サブプログラム一覧取得
            If DLTP0901_PROC0002(xxxstrProgram_ID, gintSPDシステムコード, gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            'サブプログラム一覧
            For i = 0 To gintサブプログラムCnt - 1

                cmb検索条件１.Items.Add(New サブプログラム一覧(サブプログラムArray(i).strサブプログラム名, サブプログラムArray(i).intサブプログラムコード))

            Next

            '空白行追加
            cmb検索条件１.Items.Add(New サブプログラム一覧("", 0))

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

            HARK504DS.ds一覧.Clear()

            Initialize検索条件()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　検索部明細初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　区分・・サブプログラムID
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize検索条件()

        Try

            txt検索得意先コード.Text = ""
            lbl検索得意先名.Text = ""
            cmb検索分類１.SelectedIndex = gint名称辞書Cnt
            cmb検索許可証１.SelectedIndex = 6
            cmb検索分類２.SelectedIndex = gint名称辞書Cnt
            cmb検索許可証２.SelectedIndex = 6
            cmb検索条件１.SelectedIndex = gintサブプログラムCnt
            txt検索Date.Text = ""

            xxxstr業種コード(0) = ""
            xxxstr業種コード(1) = ""
            xxxint許可証区分(0) = 7
            xxxint許可証区分(1) = 7
            xxxint条件 = gintサブプログラムCnt

            txt検索得意先コード.Enabled = True
            cmb検索分類１.Enabled = True
            cmb検索許可証１.Enabled = True
            cmb検索分類２.Enabled = False
            cmb検索許可証２.Enabled = False
            cmb検索条件１.Enabled = False
            txt検索Date.Enabled = False

            Rb_検索条件１.Checked = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　検索部明細活性制御
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　PreBool・・活性フラグ
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Set_Enabled検索条件(ByVal PreBool As Boolean)

        Try

            txt検索得意先コード.Enabled = PreBool
            cmb検索分類１.Enabled = PreBool
            cmb検索許可証１.Enabled = PreBool
            cmb検索分類２.Enabled = PreBool
            cmb検索許可証２.Enabled = PreBool
            cmb検索条件１.Enabled = PreBool
            If cmb検索条件１.SelectedIndex = 1 Then
                txt検索Date.Enabled = PreBool
            Else
                txt検索Date.Enabled = False
            End If

            Rb_検索条件１.Enabled = PreBool
            Rb_検索条件２.Enabled = PreBool
            btn検索.Enabled = PreBool

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

                Case "ID1"  '検索得意先コード

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

                Case "ID4"  '業種２

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
    ' *　モジュール機能　：　ボタン押下処理
    ' *
    ' *　注意、制限事項　：　タブ移動させたくないコントロールのみにハンドリングすること
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub Btn_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)

        Dim Tag As String

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Buttons.GcButton).Tag)

            Select Case Tag

                Case "ID1"  '検索

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


                Case "ID2" '業種コード

                    With DirectCast(cmb検索分類１.SelectedItem, 名称辞書一覧)
                        xxxstr業種コード(0) = .strコード
                    End With

                Case "ID3" '許可証区分

                    xxxint許可証区分(0) = cmb検索許可証１.SelectedIndex + 1

                Case "ID4" '業種コード

                    With DirectCast(cmb検索分類２.SelectedItem, 名称辞書一覧)
                        xxxstr業種コード(1) = .strコード
                    End With

                Case "ID5" '許可証区分

                    xxxint許可証区分(1) = cmb検索許可証２.SelectedIndex + 1

                Case "ID6" '条件

                    With DirectCast(cmb検索条件１.SelectedItem, サブプログラム一覧)
                        xxxint条件 = .intサブプログラムコード
                    End With

                    If xxxint条件 = 2 Then
                        txt検索Date.Enabled = True
                    Else
                        txt検索Date.Enabled = False
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
            'txt検索院内コード.Focus()
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
            'txt検索院内コード.Focus()
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
        'Dim m_lording As Thread = Nothing

        Try
            'Oracle接続状態確認
            If (OraConnectState(gintRtn, gintSQLCODE, gstrSQLERRM)) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM004 & vbCr & MSG_COM903, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            Tag = CStr(CType(sender, Button).Tag)

            Select Case Tag

                Case "ID1" '出力

                    If gcmr一覧.RowCount = 0 Then
                        MsgBox(MSG_504006, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                        txt検索得意先コード.Focus()
                        Exit Sub
                    End If

                    With SaveFileDlg

                        'はじめに「ファイル名」で表示される文字列を指定する
                        .FileName = ""

                        'はじめに表示されるフォルダを指定する
                        .InitialDirectory = Get_DesktopPath()

                        '[ファイルの種類]に表示される選択肢を指定する
                        .Filter = "EXCELファイル(*.xlsx)|*.xlsx|すべてのファイル(*.*)|*.*"

                        '[ファイルの種類]ではじめに選択されるものを指定する
                        .FilterIndex = 1

                        'タイトルを設定する
                        .Title = "保存先のファイル名を指定してください"

                        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                        .RestoreDirectory = True

                        '既に存在するファイル名を指定したとき警告する
                        .OverwritePrompt = True

                        '存在しないパスが指定されたとき警告を表示する
                        .CheckPathExists = True

                        If .ShowDialog() = DialogResult.OK Then
                            gintRtn = Excelデータ出力処理(.FileName)

                            If gintRtn = 0 Then
                                MsgBox(MSG_504012, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            Else
                                MsgBox(MSG_504013, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            End If

                        End If

                    End With

                Case "ID2" 'なし
                Case "ID3" 'クリア

                    gintRtn = MsgBox(MSG_COM001, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbYes Then

                        Set_Enabled検索条件(True)
                        Initialize検索条件()
                        OraTrnRollBack()
                        HARK504DS.ds一覧.Clear()

                        txt検索得意先コード.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then Exit Sub

                    Cursor = Cursors.WaitCursor

                    ''処理中画面
                    'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                    '    .IsBackground = True
                    '}

                    'm_lording.Start()

                    gintRtn = DLTP0504_PROC0011(xxxstrProgram_ID, gintSPDシステムコード, xxxintSubProgram_ID, xxxintResultCnt, xxxlngResults, gintSQLCODE, gstrSQLERRM)

                    ''処理中画面廃棄
                    'If Not m_lording Is Nothing AndAlso m_lording.IsAlive Then
                    '    m_lording.Abort()
                    '    m_lording = Nothing
                    'End If

                    If gintRtn = 0 Then
                        MsgBox(MSG_504010, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    Else
                        MsgBox(MSG_504011 & vbCr & gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    End If

                    Set_Enabled検索条件(True)
                    Initialize検索条件()
                    OraTrnCommit()
                    HARK504DS.ds一覧.Clear()

                    txt検索得意先コード.Focus()

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

        Dim intRowCnt As Integer
        Dim blnChkFLG As Boolean = False

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

            If gcmr一覧.RowCount < 1 Then
                MsgBox(MSG_504008, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt検索得意先コード.Focus()
                Exit Function
            End If

            xxxintResultCnt = 0
            xxxlngResults = Nothing

            For intRowCnt = 0 To gcmr一覧.RowCount - 1
                If CByte(gcmr一覧.Item(intRowCnt, "chk明細削除区分").Value) = 1 Then
                    blnChkFLG = True
                    ReDim Preserve xxxlngResults(xxxintResultCnt)
                    xxxlngResults(xxxintResultCnt) = CLng(gcmr一覧.Item(intRowCnt, "txt明細販売許可証管理情報_ID").Value)
                    xxxintResultCnt += 1
                End If
            Next

            If blnChkFLG = False Then
                MsgBox(MSG_504009, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                gcmr一覧.Item(0, "chk明細削除区分").Selected = True
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
    ' *　モジュール機能　：　検索実行前チェック処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 検索実行前チェック処理() As Boolean

        Try

            検索実行前チェック処理 = False

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

            If Rb_検索条件１.Checked = True Then

                If IsNull(txt検索得意先コード.Text.Trim) And IsNull(cmb検索分類１.Text.Trim) And IsNull(cmb検索許可証１.Text.Trim) Then
                    MsgBox(MSG_504001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    txt検索得意先コード.Focus()
                    Exit Function
                End If

            Else

                'If IsNull(cmb検索分類２.Text.Trim) Then
                '    MsgBox(MSG_504002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                '    cmb検索分類２.Focus()
                '    Exit Function
                'End If

                If IsNull(cmb検索許可証２.Text.Trim) Then
                    MsgBox(MSG_504003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    cmb検索許可証２.Focus()
                    Exit Function
                End If

                If IsNull(cmb検索条件１.Text.Trim) Then
                    MsgBox(MSG_504004, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    cmb検索条件１.Focus()
                    Exit Function
                End If

                If cmb検索条件１.SelectedIndex = 1 And Chk_Date(txt検索Date.Text.Trim, 1) = False Then
                    MsgBox(MSG_504005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    txt検索Date.Focus()
                    Exit Function
                End If

            End If

            検索実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　検索ボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Btn_Click(sender As Object, e As EventArgs)

        Dim Tag As String
        Dim lng検索得意先コード As Long
        'Dim m_lording As Thread = Nothing

        Try

            Tag = CStr(CType(sender, GrapeCity.Win.Buttons.GcButton).Tag)

            Select Case Tag

                Case "ID1"  '検索

                    If 検索実行前チェック処理() = False Then Exit Sub

                    HARK504DS.ds一覧.Clear()

                    If Rb_検索条件１.Checked = True Then

                        If IsNull(txt検索得意先コード.Text.Trim) Then
                            lng検索得意先コード = DUMMY_LNGCODE
                        Else
                            lng検索得意先コード = CLng(txt検索得意先コード.Text.Trim)
                        End If

                        Cursor = Cursors.WaitCursor

                        ''処理中画面
                        'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                        '    .IsBackground = True
                        '}

                        'm_lording.Start()

                        gintRtn = DLTP0504_PROC0001(xxxstrProgram_ID, xxxintSubProgram_ID, gintSPDシステムコード, lng検索得意先コード, xxxstr業種コード(0), xxxint許可証区分(0), gintSQLCODE, gstrSQLERRM)

                        Select Case gintRtn
                            Case 0
                                gblRtn = データ表示処理()
                            Case 2
                                MsgBox(MSG_504006, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                txt検索得意先コード.Focus()
                                Exit Sub
                            Case -54
                                MsgBox(MSG_504007, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                txt検索得意先コード.Focus()
                                Exit Sub
                            Case Else
                                MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                txt検索得意先コード.Focus()
                                Exit Sub

                        End Select

                    Else

                        Cursor = Cursors.WaitCursor

                        ''処理中画面
                        'm_lording = New Thread(New ThreadStart(AddressOf NowLording)) With {
                        '    .IsBackground = True
                        '}

                        'm_lording.Start()

                        gintRtn = DLTP0504_PROC0002(xxxstrProgram_ID, xxxintSubProgram_ID, gintSPDシステムコード, xxxstr業種コード(1), xxxint許可証区分(1), xxxint条件, txt検索Date.Text.Trim, gintSQLCODE, gstrSQLERRM)

                        Select Case gintRtn
                            Case 0
                                gblRtn = データ表示処理()
                            Case 2
                                MsgBox(MSG_504006, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                cmb検索分類２.Focus()
                                Exit Sub
                            Case -54
                                MsgBox(MSG_504007, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                cmb検索分類２.Focus()
                                Exit Sub
                            Case Else
                                MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                Initialize検索条件()
                                cmb検索分類２.Focus()
                                Exit Sub

                        End Select

                    End If

                    Set_Enabled検索条件(False)

                    Exit Select

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
    ' *　モジュール機能　：　データ表示処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function データ表示処理() As Boolean

        Dim intRowCnt As Integer

        Try

            データ表示処理 = False

            For intRowCnt = 0 To gintResultCnt - 1

                HARK504DS.ds一覧.Addds一覧Row(CLng(Results(intRowCnt).strBuff(0)),
                                              CInt(Results(intRowCnt).strBuff(1)),
                                              Results(intRowCnt).strBuff(2),
                                              CInt(Results(intRowCnt).strBuff(3)),
                                              Results(intRowCnt).strBuff(4),
                                              CInt(Results(intRowCnt).strBuff(5)),
                                              Results(intRowCnt).strBuff(6),
                                              Results(intRowCnt).strBuff(7),
                                              Results(intRowCnt).strBuff(8),
                                              Results(intRowCnt).strBuff(9),
                                              CInt(Results(intRowCnt).strBuff(10)),
                                              Results(intRowCnt).strBuff(11),
                                              CByte(Results(intRowCnt).strBuff(12)),
                                              CByte(Results(intRowCnt).strBuff(13)))


            Next

            For intRowCnt = 0 To gcmr一覧.RowCount - 1

                If CByte(gcmr一覧.Item(intRowCnt, "txt画像").Value) = 0 Then
                    gcmr一覧.Item(intRowCnt, "bt明細画像").Enabled = False
                Else
                    gcmr一覧.Item(intRowCnt, "bt明細画像").Enabled = True
                End If

                If CLng(gcmr一覧.Item(intRowCnt, "txt明細販売許可証管理情報_ID").Value) = 0 Then
                    gcmr一覧.Item(intRowCnt, "chk明細削除区分").Enabled = False
                Else
                    gcmr一覧.Item(intRowCnt, "chk明細削除区分").Enabled = True
                End If

            Next

            データ表示処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　ラジオボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Sub Rb_CheckedChanged(sender As Object, e As EventArgs)

        Try

            txt検索得意先コード.Text = ""
            lbl検索得意先名.Text = ""
            cmb検索分類１.SelectedIndex = gint名称辞書Cnt
            cmb検索許可証１.SelectedIndex = 6
            cmb検索分類２.SelectedIndex = gint名称辞書Cnt
            cmb検索許可証２.SelectedIndex = 6
            cmb検索条件１.SelectedIndex = gintサブプログラムCnt
            txt検索Date.Text = ""

            If Rb_検索条件１.Checked = True Then

                txt検索得意先コード.Enabled = True
                cmb検索分類１.Enabled = True
                cmb検索許可証１.Enabled = True
                cmb検索分類２.Enabled = False
                cmb検索許可証２.Enabled = False
                cmb検索条件１.Enabled = False
                txt検索Date.Enabled = False
                txt検索得意先コード.Focus()

            Else

                txt検索得意先コード.Enabled = False
                cmb検索分類１.Enabled = False
                cmb検索許可証１.Enabled = False
                cmb検索分類２.Enabled = True
                cmb検索許可証２.Enabled = True
                cmb検索条件１.Enabled = True
                txt検索Date.Enabled = False
                cmb検索分類２.Focus()

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try


    End Sub
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

                    If IsNull(txt検索得意先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0004(xxxstrProgram_ID, CLng(txt検索得意先コード.Text.Trim), gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                            txt検索得意先コード.Text = ""
                            lbl検索得意先名.Text = ""
                            txt検索得意先コード.Focus()
                        Else
                            lbl検索得意先名.Text = gstr得意先名
                        End If
                    Else
                        txt検索得意先コード.Text = ""
                        lbl検索得意先名.Text = ""
                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　画像ボタン押下処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Sub gcmr一覧_CellClick(sender As Object, e As CellEventArgs) Handles gcmr一覧.CellClick

        Try

            If e.RowIndex < 0 Then Exit Sub

            Select Case e.CellName

                Case "bt明細画像"

                    If CByte(gcmr一覧.Item(e.RowIndex, "txt画像").Value) = 0 Then Exit Sub

                    If 画像表示処理(CLng(gcmr一覧.Item(e.RowIndex, "txt明細販売許可証管理情報_ID").Value)) = False Then Exit Sub

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　画像表示処理
    ' *
    ' *　注意、制限事項　：　画像が他アプリで起動
    ' *　引数１　　　　　：　PreID・・DLT販売許可証管理情報_ID
    ' *　戻値　　　　　　：　True・・正常終了、False・・異常終了
    ' *
    ' *-----------------------------------------------------------------------------/
    Private Function 画像表示処理(ByVal PreID As Long) As Boolean

        Dim PO_Img As Image = Nothing
        Dim FileName As String
        Dim MyProcess As Process = Nothing

        Try

            画像表示処理 = False

            gintRtn = DLTP0504_PROC0021(xxxstrProgram_ID, xxxintSubProgram_ID, gintSPDシステムコード, PreID, PO_Img, gintSQLCODE, gstrSQLERRM)

            If gintRtn > 0 Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                Exit Function
            End If

            FileName = Set_FilePath(IO.Path.GetTempPath, Get_RandomFileName) & ".jpg"

            PO_Img.Save(FileName, Imaging.ImageFormat.Jpeg)

            MyProcess = Process.Start(FileName)

            PO_Img = Nothing
            MyProcess = Nothing

            画像表示処理 = True

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
    Private Function Excelデータ出力処理(ByVal FileName As String) As Integer

        Dim ColMax As Integer
        Dim RowCnt As Integer
        Dim RowMax As Integer
        Dim strHeaderText As String = Nothing
        Dim stArrayData As String()
        Dim i As Integer
        Dim dtNow As DateTime = Now

        Try

            Excelデータ出力処理 = 9

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
                .SheetName = "販売許可証情報"                                                       'シート名
                .Pos(0, 0, ColMax - 1, 0).Attr.FontColor2 = xlColor.White                       '文字列色＝白
                .Pos(0, 0, ColMax - 1, 0).Attr.FontStyle = FontStyle.Bold                       '文字列修飾＝太字
                .Pos(0, 0, ColMax - 1, 0).Attr.BackColor = Color.FromArgb(91, 155, 213)         '背景色＝青
                .Pos(0, 0, ColMax - 1, RowMax).Attr.VerticalAlignment = VerticalAlignment.Center       'テキスト縦位置=中心
                .Pos(0, 1, 0, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(事業所コード)
                .Pos(2, 1, 2, RowMax).Attr.HorizontalAlignment = HorizontalAlignment.Right             'テキスト横位置=右(得意先コード)

                'ヘッダ項目出力
                For Each stData As String In stArrayData
                    .Pos(i, 0).Str = stData
                    .Pos(i, 0).Attr.HorizontalAlignment = HorizontalAlignment.Center
                    i += 1
                Next stData

                '明細行出力
                For RowCnt = 0 To RowMax - 1

                    .Pos(0, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(1))
                    .Pos(1, RowCnt + 1).Str = Results(RowCnt).strBuff(2)
                    .Pos(2, RowCnt + 1).Long = CInt(Results(RowCnt).strBuff(3))
                    .Pos(3, RowCnt + 1).Str = Results(RowCnt).strBuff(4)
                    .Pos(4, RowCnt + 1).Str = Results(RowCnt).strBuff(6)
                    .Pos(5, RowCnt + 1).Str = Results(RowCnt).strBuff(7)
                    .Pos(6, RowCnt + 1).Str = Results(RowCnt).strBuff(8)
                    .Pos(7, RowCnt + 1).Str = Results(RowCnt).strBuff(9)
                    .Pos(8, RowCnt + 1).Str = Results(RowCnt).strBuff(11)

                Next

                .CloseBook(True)

            End With

            Excelデータ出力処理 = 0

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
End Class