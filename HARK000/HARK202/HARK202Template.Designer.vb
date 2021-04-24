<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.ComponentModel.ToolboxItem(True)> _
Partial Class HARK202Template
    Inherits GrapeCity.Win.MultiRow.Template

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'MultiRow テンプレート デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは MultiRow テンプレート デザイナで必要です。
    'MultiRow テンプレート デザイナを使用して変更できます。 
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CellStyle3 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border3 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle4 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border4 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border1 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border2 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Me.HeaderSection = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.chc明細選択区分 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.chc明細部署名 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.txt明細部署名 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.chk明細選択区分 = New GrapeCity.Win.MultiRow.CheckBoxCell()
        '
        'Row
        '
        Me.Row.Cells.Add(Me.txt明細部署名)
        Me.Row.Cells.Add(Me.chk明細選択区分)
        Me.Row.Height = 21
        Me.Row.Width = 266
        '
        'HeaderSection
        '
        Me.HeaderSection.Cells.Add(Me.chc明細選択区分)
        Me.HeaderSection.Cells.Add(Me.chc明細部署名)
        Me.HeaderSection.Height = 21
        Me.HeaderSection.Name = "HeaderSection"
        Me.HeaderSection.Width = 266
        '
        'chc明細選択区分
        '
        Me.chc明細選択区分.Location = New System.Drawing.Point(0, 0)
        Me.chc明細選択区分.Name = "chc明細選択区分"
        Me.chc明細選択区分.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細選択区分.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細選択区分.Size = New System.Drawing.Size(39, 21)
        Me.chc明細選択区分.SortCellName = "chk明細選択区分"
        Me.chc明細選択区分.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle3.BackColor = System.Drawing.SystemColors.Control
        Border3.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle3.Border = Border3
        CellStyle3.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle3.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細選択区分.Style = CellStyle3
        Me.chc明細選択区分.TabIndex = 1
        Me.chc明細選択区分.TabStop = False
        Me.chc明細選択区分.Value = "選択"
        '
        'chc明細部署名
        '
        Me.chc明細部署名.Location = New System.Drawing.Point(39, 0)
        Me.chc明細部署名.Name = "chc明細部署名"
        Me.chc明細部署名.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細部署名.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細部署名.Size = New System.Drawing.Size(227, 21)
        Me.chc明細部署名.SortCellName = "txt明細部署名"
        Me.chc明細部署名.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle4.BackColor = System.Drawing.SystemColors.Control
        Border4.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle4.Border = Border4
        CellStyle4.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle4.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle4.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細部署名.Style = CellStyle4
        Me.chc明細部署名.TabIndex = 2
        Me.chc明細部署名.TabStop = False
        Me.chc明細部署名.Value = "部署名"
        '
        'txt明細部署名
        '
        Me.txt明細部署名.DataField = "部署名"
        Me.txt明細部署名.Ellipsis = GrapeCity.Win.MultiRow.MultiRowEllipsisMode.EllipsisEnd
        Me.txt明細部署名.Location = New System.Drawing.Point(39, 0)
        Me.txt明細部署名.Name = "txt明細部署名"
        Me.txt明細部署名.ReadOnly = True
        Me.txt明細部署名.Size = New System.Drawing.Size(227, 21)
        Border1.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle1.Border = Border1
        CellStyle1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle1.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle1.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細部署名.Style = CellStyle1
        Me.txt明細部署名.TabIndex = 2
        '
        'chk明細選択区分
        '
        Me.chk明細選択区分.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk明細選択区分.DataField = "選択区分"
        Me.chk明細選択区分.Location = New System.Drawing.Point(0, 0)
        Me.chk明細選択区分.Name = "chk明細選択区分"
        Me.chk明細選択区分.Size = New System.Drawing.Size(39, 21)
        Border2.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle2.Border = Border2
        CellStyle2.ImeMode = System.Windows.Forms.ImeMode.Off
        CellStyle2.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        Me.chk明細選択区分.Style = CellStyle2
        Me.chk明細選択区分.TabIndex = 1
        '
        'HARK202Template
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.HeaderSection})
        Me.Height = 42
        Me.Width = 266

    End Sub
    Private WithEvents HeaderSection As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Private WithEvents txt明細部署名 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents chk明細選択区分 As GrapeCity.Win.MultiRow.CheckBoxCell
    Private WithEvents chc明細部署名 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents chc明細選択区分 As GrapeCity.Win.MultiRow.ColumnHeaderCell
End Class
