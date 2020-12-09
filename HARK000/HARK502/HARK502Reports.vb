Public Class HARK502Reports


    Private Sub HARK502Reports_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart

        lbl帳票名.Text = str帳票名
        txt出力条件.Text = str出力条件

    End Sub

End Class
