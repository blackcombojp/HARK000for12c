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

Public Class HARK992
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
            SttBar_2.Text = gstr担当者名
            SttBar_3.Text = "Ver : " & Application.ProductVersion

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
    ' *　モジュール機能　：　画面アクティブ時処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Fm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
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

            'メモリ開放
            GC.Collect()
            OraTrnRollBack()
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
            OraTrnRollBack()

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

            '直送区分
            '名称辞書一覧取得
            If DLTP0901_PROC0005(xxxstrProgram_ID, "直送区分", gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '名称辞書一覧
            For i = 0 To gint項目辞書Cnt - 1

                cmb直送区分.Items.Add(New 項目辞書一覧(項目辞書Array(i).str名称, 項目辞書Array(i).intコード))

            Next

            '空白行追加
            cmb直送区分.Items.Add(New 項目辞書一覧("", 0))
            xxxint直送区分項目数 = gint項目辞書Cnt

            '商品出荷指示区分
            '名称辞書一覧取得
            If DLTP0901_PROC0005(xxxstrProgram_ID, "商品出荷指示区分", gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '名称辞書一覧
            For i = 0 To gint項目辞書Cnt - 1

                cmb商品出荷指示区分.Items.Add(New 項目辞書一覧(項目辞書Array(i).str名称, 項目辞書Array(i).intコード))

            Next

            '空白行追加
            cmb商品出荷指示区分.Items.Add(New 項目辞書一覧("", 0))
            xxxint商品出荷指示区分項目数 = gint項目辞書Cnt

            '商品手配方法区分
            '名称辞書一覧取得
            If DLTP0901_PROC0005(xxxstrProgram_ID, "商品手配方法区分", gintSQLCODE, gstrSQLERRM) = False Then

                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM902 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                log.Error(Set_ErrMSG(gintSQLCODE, gstrSQLERRM))
                Exit Sub

            End If

            '名称辞書一覧
            For i = 0 To gint項目辞書Cnt - 1

                cmb商品手配方法区分.Items.Add(New 項目辞書一覧(項目辞書Array(i).str名称, 項目辞書Array(i).intコード))

            Next

            '空白行追加
            cmb商品手配方法区分.Items.Add(New 項目辞書一覧("", 0))
            xxxint商品手配方法区分項目数 = gint項目辞書Cnt

            '発注納期設定区分
            cmb発注納期設定区分.Items.Add("設定しない")
            cmb発注納期設定区分.Items.Add("設定する")
            cmb発注納期設定区分.Items.Add("")
            xxxint発注納期設定区分項目数 = 2

            '希望発注納期
            For i = 0 To 4
                Grp希望発注納期(i).Items.Add("月曜日")
                Grp希望発注納期(i).Items.Add("火曜日")
                Grp希望発注納期(i).Items.Add("水曜日")
                Grp希望発注納期(i).Items.Add("木曜日")
                Grp希望発注納期(i).Items.Add("金曜日")
                Grp希望発注納期(i).Items.Add("")
            Next
            xxxint希望発注納期項目数 = 5

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

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

                Case "ID1" '直送区分

                    xxxint直送区分 = cmb直送区分.SelectedIndex

                    Select Case xxxint直送区分

                        Case 0, 2 '取寄、初期化

                            txt直送先コード.Text = ""
                            lbl直送先名.Text = ""
                            lbl明細直送先コード.Visible = False
                            txt直送先コード.Visible = False
                            lbl直送先名.Visible = False

                        Case 1 '直送

                            txt直送先コード.Text = ""
                            lbl直送先名.Text = ""
                            lbl明細直送先コード.Visible = True
                            txt直送先コード.Visible = True
                            lbl直送先名.Visible = True

                    End Select

                Case "ID2" '商品出荷指示区分

                    xxxint商品出荷指示区分 = cmb商品出荷指示区分.SelectedIndex + 1

                Case "ID3" 'cmb商品手配方法区分

                    xxxint商品手配方法区分 = cmb商品手配方法区分.SelectedIndex + 1

                Case "ID4" 'cmb発注納期設定区分

                    xxxint発注納期設定区分 = cmb発注納期設定区分.SelectedIndex

                    Select Case xxxint発注納期設定区分

                        Case 0 '設定しない

                            For i = 0 To 4
                                Grp希望発注納期(i).Text = ""
                                Grp希望発注納期(i).Enabled = False
                            Next

                        Case 1, 2 '設定する,初期化

                            For i = 0 To 4
                                Grp希望発注納期(i).Text = ""
                                Grp希望発注納期(i).Enabled = True
                            Next

                    End Select

            End Select

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

            txt得意先コード.Text = ""
            txt需要先コード.Text = ""
            lbl得意先名.Text = ""
            lbl需要先名.Text = ""
            txt得意先コード.Enabled = True
            txt需要先コード.Enabled = True

            Initialize明細()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　明細コンポーネント初期化
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub Initialize明細()

        Dim i As Integer

        Try

            cmb直送区分.SelectedIndex = xxxint直送区分項目数
            txt直送先コード.Text = ""
            lbl直送先名.Text = ""
            lbl明細直送先コード.Visible = False
            txt直送先コード.Visible = False
            lbl直送先名.Visible = False
            cmb商品出荷指示区分.SelectedIndex = xxxint商品出荷指示区分項目数
            cmb商品手配方法区分.SelectedIndex = xxxint商品手配方法区分項目数
            cmb発注納期設定区分.SelectedIndex = xxxint発注納期設定区分項目数

            For i = 0 To 4
                Grp希望発注納期(i).SelectedIndex = xxxint希望発注納期項目数
            Next

            lblID.Text = ""

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

                Case "ID1"  '得意先コード

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

                Case "ID1"  '直送区分

                    If e.Shift = True And txt得意先コード.Enabled = False Then

                        Select Case e.KeyCode

                                'Tabキーが押されてもフォーカスが移動しないようにする
                            Case Keys.Tab
                                e.IsInputKey = True

                        End Select

                    End If

                Case "ID9" '希望発注納期_金

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
            txt得意先コード.Focus()
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
            txt得意先コード.Focus()
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
                        OraTrnRollBack()
                        txt得意先コード.Focus()

                    End If

                    Exit Sub

                Case "ID4" 'ログ

                  '別ロジックで実装

                Case "ID5" '実行

                    If 実行前チェック処理() = False Then Exit Sub

                    gintRtn = MsgBox(MSG_101105, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)

                    If gintRtn = vbNo Then

                        cmb直送区分.Focus()
                        Exit Sub

                    End If

                    gintRtn = DLTP0100S_PROC0024(xxxstrProgram_ID,
                                                xxxintSubProgram_ID,
                                                xxxintSPDSystemCode,
                                                xxxint新規区分,
                                                CLng(txt得意先コード.Text.Trim),
                                                CLng(txt需要先コード.Text.Trim),
                                                xxxint直送区分,
                                                xxxint商品出荷指示区分,
                                                xxxint商品手配方法区分,
                                                xxxint発注納期設定区分,
                                                CLng(NvlString(txt直送先コード.Text.Trim, DUMMY_STRCODE)),
                                                cmb希望発注納期_月.Text.Trim,
                                                cmb希望発注納期_火.Text.Trim,
                                                cmb希望発注納期_水.Text.Trim,
                                                cmb希望発注納期_木.Text.Trim,
                                                cmb希望発注納期_金.Text.Trim,
                                                gintSQLCODE,
                                                gstrSQLERRM)

                    If gintRtn = 0 Then
                        MsgBox(MSG_992011, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    Else
                        MsgBox(MSG_992012 & vbCr & gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                    End If

                    Initialize()
                    txt得意先コード.Focus()

                    Exit Sub

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
    ' *　モジュール機能　：　処理実行前チェック処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　引数２　　　　　：　なし
    ' *　戻値　　　　　　：　True・・正常、False・・異常
    ' *-----------------------------------------------------------------------------/
    Private Function 実行前チェック処理() As Boolean

        Dim i As Integer
        Dim bl空白 As Boolean = Nothing

        Try

            実行前チェック処理 = False

            '得意先コード
            If IsNull(txt得意先コード.Text.Trim) = True Then
                MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt得意先コード.Focus()
                Exit Function
            End If

            '需要先コード
            If IsNull(txt需要先コード.Text.Trim) = True Then
                MsgBox(MSG_992002, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt需要先コード.Focus()
                Exit Function
            End If

            '直送区分
            If IsNull(cmb直送区分.Text.Trim) = True Then
                MsgBox(MSG_992006, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb直送区分.Focus()
                Exit Function
            End If

            '直送先コード
            If xxxint直送区分 = 1 AndAlso IsNull(txt直送先コード.Text.Trim) = True Then
                MsgBox(MSG_992003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                txt需要先コード.Focus()
                Exit Function
            End If

            '商品出荷指示区分
            If IsNull(cmb商品出荷指示区分.Text.Trim) = True Then
                MsgBox(MSG_992007, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb商品出荷指示区分.Focus()
                Exit Function
            End If

            '商品手配方法区分
            If IsNull(cmb商品手配方法区分.Text.Trim) = True Then
                MsgBox(MSG_992008, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb商品手配方法区分.Focus()
                Exit Function
            End If

            '発注納期設定区分
            If IsNull(cmb発注納期設定区分.Text.Trim) = True Then
                MsgBox(MSG_992009, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                cmb発注納期設定区分.Focus()
                Exit Function
            End If

            If xxxint発注納期設定区分 = 1 Then

                bl空白 = True

                For i = 0 To 4
                    If IsNull(Grp希望発注納期(i).Text.Trim) = False Then
                        bl空白 = False
                        Exit For
                    End If
                Next

                If bl空白 = True Then
                    MsgBox(MSG_992010, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                    cmb発注納期設定区分.Focus()
                    Exit Function
                End If

            End If

            実行前チェック処理 = True

            Exit Function

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Function
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　データ表示処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　なし
    ' *　戻値　　　　　　：　True -- 成功 false -- 失敗
    ' *-----------------------------------------------------------------------------/
    Private Function データ表示処理() As Boolean

        Try

            データ表示処理 = False

            Initialize明細()

            lblID.Text = Results(0).strBuff(0)
            cmb直送区分.SelectedIndex = CInt(Results(0).strBuff(1))
            xxxint直送区分 = CInt(Results(0).strBuff(1))
            txt直送先コード.Text = Results(0).strBuff(3)
            lbl直送先名.Text = Results(0).strBuff(4)
            cmb商品出荷指示区分.SelectedIndex = CInt(Results(0).strBuff(5)) - 1
            xxxint商品出荷指示区分 = CInt(Results(0).strBuff(5))
            cmb商品手配方法区分.SelectedIndex = CInt(Results(0).strBuff(7)) - 1
            xxxint商品手配方法区分 = CInt(Results(0).strBuff(7))
            cmb発注納期設定区分.SelectedIndex = CInt(Results(0).strBuff(9))
            xxxint発注納期設定区分 = CInt(Results(0).strBuff(9))
            cmb希望発注納期_月.Text = Results(0).strBuff(11)
            cmb希望発注納期_火.Text = Results(0).strBuff(12)
            cmb希望発注納期_水.Text = Results(0).strBuff(13)
            cmb希望発注納期_木.Text = Results(0).strBuff(14)
            cmb希望発注納期_金.Text = Results(0).strBuff(15)

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

                Case "ID1" '得意先コード

                    If IsNull(txt得意先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0003(xxxstrProgram_ID, CLng(txt得意先コード.Text.Trim), My.Settings.事業所コード, 1, gintSQLCODE, gstrSQLERRM) = False Then
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

                Case "ID2" '需要先コード

                    If IsNull(txt需要先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0003(xxxstrProgram_ID, CLng(txt需要先コード.Text.Trim), My.Settings.事業所コード, 2, gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txt需要先コード.Text = ""
                            lbl需要先名.Text = ""
                            txt需要先コード.Focus()
                        Else
                            lbl需要先名.Text = gstr得意先名

                            If IsNull(txt得意先コード.Text.Trim) = True Then
                                MsgBox(MSG_992001, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                txt得意先コード.Focus()
                                Exit Sub
                            End If

                            gintRtn = DLTP0100S_PROC0023(xxxstrProgram_ID, xxxintSPDSystemCode, xxxintSubProgram_ID, CLng(txt得意先コード.Text.Trim), CLng(txt需要先コード.Text.Trim), gintSQLCODE, gstrSQLERRM)

                            Select Case gintRtn
                                Case 0
                                    gblRtn = データ表示処理()
                                    txt得意先コード.Enabled = False
                                    txt需要先コード.Enabled = False
                                    xxxint新規区分 = 0
                                    cmb直送区分.Focus()
                                    Exit Sub
                                Case 2
                                    MsgBox(MSG_992005, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                                    txt得意先コード.Enabled = False
                                    txt需要先コード.Enabled = False
                                    xxxint新規区分 = 1
                                    cmb直送区分.Focus()
                                    Exit Sub
                                Case -54
                                    MsgBox(MSG_992004, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                    Initialize()
                                    txt得意先コード.Focus()
                                    Exit Sub
                                Case Else
                                    MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                                    Initialize()
                                    txt得意先コード.Focus()
                                    Exit Sub

                            End Select

                        End If
                    Else
                        txt需要先コード.Text = ""
                        lbl需要先名.Text = ""
                    End If

                Case "ID3" '直送先コード

                    If IsNull(txt直送先コード.Text.Trim) = False Then

                        If DLTP0900_PROC0003(xxxstrProgram_ID, CLng(txt直送先コード.Text.Trim), My.Settings.事業所コード, 2, gintSQLCODE, gstrSQLERRM) = False Then
                            MsgBox(gintSQLCODE & "-" & gstrSQLERRM, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                            txt直送先コード.Text = ""
                            lbl直送先名.Text = ""
                            txt直送先コード.Focus()
                        Else
                            lbl直送先名.Text = gstr得意先名
                        End If
                    Else
                        txt直送先コード.Text = ""
                        lbl直送先名.Text = ""
                    End If

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub


End Class