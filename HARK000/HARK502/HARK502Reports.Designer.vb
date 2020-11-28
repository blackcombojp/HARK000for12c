<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class HARK502Reports
    Inherits GrapeCity.ActiveReports.SectionReport

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReports デザイナーで必要です。
    'ActiveReports デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HARK502Reports))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionBox1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.詳細入出庫数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.詳細入出庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label1, Me.CrossSectionBox1})
        Me.PageHeader.Height = 0.6354166!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.34375!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = "kkk"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 2.885417!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0!
        Me.CrossSectionBox1.Left = 0.09400001!
        Me.CrossSectionBox1.LineWeight = 1.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Radius = New GrapeCity.ActiveReports.Controls.CornersRadius(0!, Nothing, Nothing, Nothing, Nothing)
        Me.CrossSectionBox1.Right = 5.906!
        Me.CrossSectionBox1.Top = 0.4375!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.詳細入出庫数量})
        Me.Detail.Name = "Detail"
        '
        '詳細入出庫数量
        '
        Me.詳細入出庫数量.DataField = "詳細入出庫数量"
        Me.詳細入出庫数量.Height = 0.3125!
        Me.詳細入出庫数量.Left = 2.052083!
        Me.詳細入出庫数量.Name = "詳細入出庫数量"
        Me.詳細入出庫数量.Text = "詳細入出庫数量"
        Me.詳細入出庫数量.Top = 0.5833333!
        Me.詳細入出庫数量.Width = 1.614583!
        '
        'PageFooter
        '
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'HARK502Reports
        '
        Me.MasterReport = False
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 11.10417!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.ShowParameterUI = False
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: ""MS UI Gothic""; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; font-family: ""MS UI Gothic""; ddo-char-set: 12" &
            "8", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; font-style: inherit; font-family: ""MS UI Goth" &
            "ic""; ddo-char-set: 128", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 128", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.詳細入出庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionBox1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox
    Private WithEvents 詳細入出庫数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
