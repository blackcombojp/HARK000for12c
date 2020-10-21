Imports System.ComponentModel
Imports NPOI.OpenXmlFormats.Dml

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK990
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl文言 = New System.Windows.Forms.Label()
        Me.PicWait = New System.Windows.Forms.PictureBox()
        CType(Me.PicWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl文言
        '
        Me.lbl文言.AutoSize = True
        Me.lbl文言.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl文言.ForeColor = System.Drawing.Color.Blue
        Me.lbl文言.Location = New System.Drawing.Point(88, 98)
        Me.lbl文言.Name = "lbl文言"
        Me.lbl文言.Size = New System.Drawing.Size(392, 31)
        Me.lbl文言.TabIndex = 1
        Me.lbl文言.Text = "処理中です。しばらくお待ちください。"
        Me.lbl文言.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicWait
        '
        Me.PicWait.Image = Global.HARK000.My.Resources.Resources.ajax_loader
        Me.PicWait.Location = New System.Drawing.Point(249, 19)
        Me.PicWait.Name = "PicWait"
        Me.PicWait.Size = New System.Drawing.Size(70, 68)
        Me.PicWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicWait.TabIndex = 0
        Me.PicWait.TabStop = False
        '
        'HARK990
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(568, 145)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl文言)
        Me.Controls.Add(Me.PicWait)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HARK990"
        Me.Opacity = 0.75R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HARK990"
        CType(Me.PicWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents lbl文言 As Label
    Private WithEvents PicWait As PictureBox

End Class
