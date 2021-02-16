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
Imports HARK000.HARK_Sub
Imports HARK000.HARK_Common
Imports NAppUpdate.Framework

Public Class HARK001

    ''' <summary>
    ''' サイドボタン押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub BtnSide_Click(sender As Object, e As EventArgs)

        Dim xxxSideBtn As GrapeCity.Win.Buttons.GcButton = DirectCast(sender, GrapeCity.Win.Buttons.GcButton)
        Dim i As Integer

        Try
            For i = 0 To 5
                Pnls(i).Visible = False
            Next

            pnlOnSideBtn.Top = xxxSideBtn.Top
            Pnls(CInt(xxxSideBtn.Tag)).Visible = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' 「終了」ボタン押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Btn終了_Click(sender As Object, e As EventArgs) Handles Btn終了.Click

        Try

            pnlOnSideBtn.Top = Btn終了.Top

            gintMsg = MsgBox(MSG_COM003, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)
            If gintMsg = vbNo Then Exit Sub

            'Oracle切断
            OraDisConnect()

            Dispose()

            'アプリ終了
            Application.Exit()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            'Call ErrLog_Trace(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodBase.GetCurrentMethod.Name, CStr(Err.Number), ex.ToString)
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' 「×」ボタン押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Pic終了_Click(sender As Object, e As EventArgs) Handles pic終了.Click

        Try

            pnlOnSideBtn.Top = Btn終了.Top

            gintMsg = MsgBox(MSG_COM003, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, MsgBoxStyle), My.Application.Info.Title)
            If gintMsg = vbNo Then Exit Sub

            'Oracle切断
            OraDisConnect()

            Dispose()

            'アプリ終了
            Application.Exit()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' 「最小化」ボタン押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Pic最小化_Click(sender As Object, e As EventArgs) Handles pic最小化.Click

        Try

            WindowState = FormWindowState.Minimized

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try


    End Sub
    ''' <summary>
    ''' Form移動前処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Fm_MouseDown(sender As Object, e As MouseEventArgs)

        Try

            If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
                '位置を記憶する
                mousePoint = New Point(e.X, e.Y)
            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' Form移動処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Fm_MouseMove(sender As Object, e As MouseEventArgs)

        Try

            If (e.Button And MouseButtons.Left) = MouseButtons.Left Then

                Left += e.X - mousePoint.X
                Top += e.Y - mousePoint.Y

            End If

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' フォーム読み込み処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Fm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Cursor = Cursors.WaitCursor

            strProgram_ID = sender.GetType.Name
            Text = My.Application.Info.Title
            lblバージョン.Text = "Ver : " & Application.ProductVersion
            wbrお知らせ.Url = New Uri(My.Settings.TopUrl)
            wbrお知らせ.Refresh(WebBrowserRefreshOption.Completely)
            lbl事業所.Text = gstr部門名
            lblマシン名.Text = Get_MachineName()

#If DEBUG Then
            lblDebug.Text = DebugVer
            lblDebug.Visible = True
#Else
            lblDebug.Visible = False
           
#End If
            Update_Check()

            Initialize()

            掲示板情報設定()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub
    ''' <summary>
    ''' 各種コンポーネント初期化
    ''' </summary>
    Private Sub Initialize()

        Dim i As Integer

        Try

            For i = 0 To 5
                Pnls(i).Visible = False
            Next

            'お知らせを最前面
            pnlOnSideBtn.Top = btnSide99.Top
            Pnls(5).Visible = True

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    ''' <summary>
    ''' 掲示情報設定
    ''' </summary>
    Private Sub 掲示板情報設定()

        Dim i As Integer
        Dim Line As String

        Try

            If gint掲示版Cnt = 0 Then Exit Sub

            Line = ""

            For i = 0 To gint掲示版Cnt - 1

                Line += "=============================================================" & vbCr
                Line += 掲示板Array(i).str掲示情報 & vbCr

            Next

            txtお知らせ.Text = Line

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            Throw

        End Try

    End Sub
    ''' <summary>
    ''' PRINTSCREENキー押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Fm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp

        Try

            'PrintScreenキーは無効
            If gintKeyControl01 = 1 AndAlso e.KeyCode = Keys.PrintScreen Then Clipboard.SetDataObject(MSG_COM006, False)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' アップデートチェック処理
    ''' </summary>
    Private Sub Update_Check()

        Try

            log.Info("Update_Check")
            log.Info("現在のバージョン：" & My.Application.Info.Version.ToString)
            log.Info("現在の状態：" & UpdateManager.Instance.State.ToString)

            Select Case (UpdateManager.Instance.State)

                Case UpdateManager.UpdateProcessState.NotChecked

                    HARK_Update.Update_Check()

                Case UpdateManager.UpdateProcessState.Checked

                    HARK_Update.Update_Prepare()

                Case UpdateManager.UpdateProcessState.Prepared

                    HARK_Update.Update_Install()

                Case UpdateManager.UpdateProcessState.AppliedSuccessfully

                    MsgBox(MSG_UPD003, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)

                Case UpdateManager.UpdateProcessState.RollbackRequired

                    HARK_Update.Update_Rollback()

                Case UpdateManager.UpdateProcessState.AfterRestart

                    HARK_Update.Update_CheckAfterRestart()

            End Select

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' 各実行ボタン群押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub BtnExe_Click(sender As Object, e As EventArgs)

        Dim xxxExeBtn As GrapeCity.Win.Buttons.GcButton = DirectCast(sender, GrapeCity.Win.Buttons.GcButton)

        Try

            'Oracle接続状態確認
            If (OraConnectState(gintRtn, gintSQLCODE, gstrSQLERRM)) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM004 & vbCr & MSG_COM903, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            If IsNull(CStr(xxxExeBtn.Tag)) Then Exit Sub

            'プログラム処理可否確認
            If DLTP0000_PROC0003(CStr(xxxExeBtn.Tag), gintSQLCODE, gstrSQLERRM) = 0 Then
                MsgBox(MSG_COM010 & vbCr & MSG_COM011, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Information, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            'SPDシステムコード取得
            If DLTP0000_PROC0002(CStr(xxxExeBtn.Tag), gintSQLCODE, gstrSQLERRM) = False Then
                MsgBox(gintSQLCODE & "-" & gstrSQLERRM & vbCr & MSG_COM014 & vbCr & MSG_COM901, CType(MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), My.Application.Info.Title)
                Exit Sub
            End If

            SubForm_Show(gstrFormID, gstrFormTitle, CStr(xxxExeBtn.Tag))

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub
    ''' <summary>
    ''' 各実行画面表示処理
    ''' </summary>
    ''' <param name="FormID">Formクラス</param>
    ''' <param name="FormTitle">Form表示タイトル</param>
    ''' <param name="BtnTag">プログラム_ID</param>
    Private Sub SubForm_Show(ByVal FormID As String,
                             ByVal FormTitle As String,
                             ByVal BtnTag As String)

        Try

            Cursor.Current = Cursors.WaitCursor

            'フォームの型を取得
            Dim oType As Type = Reflection.[Assembly].LoadFrom("HARK000.exe").GetType(FormID)

            If oType Is Nothing Then
                MsgBox(MSG_COM906, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Exit Sub
            End If

            'インスタンス作成
            Dim oObj As Object = Activator.CreateInstance(oType, New Object() {Me, FormTitle, BtnTag})
            'インスタンスをフォーム型に変換
            strExeProgram_ID = CType(oObj, Form)
            '表示              
            strExeProgram_ID.Show()

            Hide()

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        Finally

            Cursor.Current = Cursors.Default

        End Try

    End Sub
    ''' <summary>
    ''' マニュアルリンクラベル押下処理
    ''' </summary>
    ''' <param name="sender">オブジェクト識別クラス</param>
    ''' <param name="e">イベントデータクラス</param>
    Private Sub Lblマニュアル_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblマニュアル.LinkClicked

        Try

            Process.Start(My.Settings.ManualUrl)

        Catch ex As Exception

            log.Error(Set_ErrMSG(Err.Number, ex.ToString))
            MsgBox(MSG_COM902 & vbCr & Err.Number & vbCr & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, My.Application.Info.Title)

        End Try

    End Sub

End Class
