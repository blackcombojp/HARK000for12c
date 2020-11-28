<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HARK991
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK991))
        Me.ViewerCtl = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.SuspendLayout()
        '
        'ViewerCtl
        '
        Me.ViewerCtl.AllowSplitter = False
        Me.ViewerCtl.CurrentPage = 0
        Me.ViewerCtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewerCtl.Location = New System.Drawing.Point(0, 0)
        Me.ViewerCtl.Name = "ViewerCtl"
        Me.ViewerCtl.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.ViewerCtl.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.ViewerCtl.Sidebar.ParametersPanel.Text = "Parameters"
        Me.ViewerCtl.Sidebar.ParametersPanel.Width = 200
        '
        '
        '
        Me.ViewerCtl.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.ViewerCtl.Sidebar.SearchPanel.Text = "Search results"
        Me.ViewerCtl.Sidebar.SearchPanel.Width = 200
        '
        '
        '
        Me.ViewerCtl.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.ViewerCtl.Sidebar.ThumbnailsPanel.Text = "Page thumbnails"
        Me.ViewerCtl.Sidebar.ThumbnailsPanel.Width = 200
        Me.ViewerCtl.Sidebar.ThumbnailsPanel.Zoom = 0.1R
        '
        '
        '
        Me.ViewerCtl.Sidebar.TocPanel.ContextMenu = Nothing
        Me.ViewerCtl.Sidebar.TocPanel.Expanded = True
        Me.ViewerCtl.Sidebar.TocPanel.Text = "Document map"
        Me.ViewerCtl.Sidebar.TocPanel.Width = 200
        Me.ViewerCtl.Sidebar.Width = 200
        Me.ViewerCtl.Size = New System.Drawing.Size(1008, 729)
        Me.ViewerCtl.TabIndex = 0
        '
        'HARK991
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.ViewerCtl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HARK991"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FMTITLE"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Public WithEvents ViewerCtl As GrapeCity.ActiveReports.Viewer.Win.Viewer
End Class
