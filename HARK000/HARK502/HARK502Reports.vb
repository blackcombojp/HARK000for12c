'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Public Class HARK502Reports
    '/*-----------------------------------------------------------------------------
    ' *　モジュール機能　：　レポート実行処理
    ' *
    ' *　注意、制限事項　：　なし
    ' *　引数１　　　　　：　sender・・オブジェクト識別クラス
    ' *　引数２　　　　　：　e・・イベントデータクラス
    ' *　戻値　　　　　　：　なし
    ' *-----------------------------------------------------------------------------/
    Private Sub HARK502Reports_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart

        '帳票コンポーネントに値をセット
        lbl帳票名.Text = str帳票名
        txt出力条件.Text = str出力条件

    End Sub

End Class
