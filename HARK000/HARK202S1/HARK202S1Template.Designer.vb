<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.ComponentModel.ToolboxItem(True)> _
Partial Class HARK202S1Template
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CellStyle19 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border19 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle20 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border20 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle21 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border21 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle12 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border12 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle13 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border13 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle14 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border14 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle15 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border15 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle16 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border16 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle17 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border17 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle22 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border22 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Dim CellStyle18 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim Border18 As GrapeCity.Win.MultiRow.Border = New GrapeCity.Win.MultiRow.Border()
        Me.ColumnHeaderSection = New GrapeCity.Win.MultiRow.ColumnHeaderSection()
        Me.chc明細棚卸名 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.chc明細棚卸区分 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.chc明細完了区分 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.txt明細棚卸名 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.txt明細棚卸区分名 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.txt明細完了区分名 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.txt明細棚卸区分 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.txt明細完了区分 = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.txt明細ID = New GrapeCity.Win.MultiRow.TextBoxCell()
        Me.chc明細状態 = New GrapeCity.Win.MultiRow.ColumnHeaderCell()
        Me.txt明細状態 = New GrapeCity.Win.MultiRow.TextBoxCell()
        '
        'Row
        '
        Me.Row.Cells.Add(Me.txt明細棚卸名)
        Me.Row.Cells.Add(Me.txt明細棚卸区分名)
        Me.Row.Cells.Add(Me.txt明細完了区分名)
        Me.Row.Cells.Add(Me.txt明細棚卸区分)
        Me.Row.Cells.Add(Me.txt明細完了区分)
        Me.Row.Cells.Add(Me.txt明細ID)
        Me.Row.Cells.Add(Me.txt明細状態)
        Me.Row.Height = 21
        Me.Row.Width = 573
        '
        'ColumnHeaderSection
        '
        Me.ColumnHeaderSection.Cells.Add(Me.chc明細棚卸名)
        Me.ColumnHeaderSection.Cells.Add(Me.chc明細棚卸区分)
        Me.ColumnHeaderSection.Cells.Add(Me.chc明細完了区分)
        Me.ColumnHeaderSection.Cells.Add(Me.chc明細状態)
        Me.ColumnHeaderSection.Height = 21
        Me.ColumnHeaderSection.Name = "ColumnHeaderSection"
        Me.ColumnHeaderSection.Width = 573
        '
        'chc明細棚卸名
        '
        Me.chc明細棚卸名.Location = New System.Drawing.Point(0, 0)
        Me.chc明細棚卸名.Name = "chc明細棚卸名"
        Me.chc明細棚卸名.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細棚卸名.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細棚卸名.Size = New System.Drawing.Size(368, 21)
        Me.chc明細棚卸名.SortCellName = "txt明細棚卸名"
        Me.chc明細棚卸名.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle19.BackColor = System.Drawing.SystemColors.Control
        Border19.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle19.Border = Border19
        CellStyle19.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle19.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle19.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細棚卸名.Style = CellStyle19
        Me.chc明細棚卸名.TabIndex = 0
        Me.chc明細棚卸名.TabStop = False
        Me.chc明細棚卸名.Value = "棚卸名"
        '
        'chc明細棚卸区分
        '
        Me.chc明細棚卸区分.Location = New System.Drawing.Point(368, 0)
        Me.chc明細棚卸区分.Name = "chc明細棚卸区分"
        Me.chc明細棚卸区分.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細棚卸区分.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細棚卸区分.Size = New System.Drawing.Size(80, 21)
        Me.chc明細棚卸区分.SortCellName = "txt明細棚卸区分名"
        Me.chc明細棚卸区分.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle20.BackColor = System.Drawing.SystemColors.Control
        Border20.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle20.Border = Border20
        CellStyle20.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle20.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle20.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細棚卸区分.Style = CellStyle20
        Me.chc明細棚卸区分.TabIndex = 1
        Me.chc明細棚卸区分.TabStop = False
        Me.chc明細棚卸区分.Value = "棚卸区分"
        '
        'chc明細完了区分
        '
        Me.chc明細完了区分.Location = New System.Drawing.Point(448, 0)
        Me.chc明細完了区分.Name = "chc明細完了区分"
        Me.chc明細完了区分.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細完了区分.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細完了区分.Size = New System.Drawing.Size(80, 21)
        Me.chc明細完了区分.SortCellName = "txt明細完了区分名"
        Me.chc明細完了区分.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle21.BackColor = System.Drawing.SystemColors.Control
        Border21.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle21.Border = Border21
        CellStyle21.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle21.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle21.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細完了区分.Style = CellStyle21
        Me.chc明細完了区分.TabIndex = 2
        Me.chc明細完了区分.TabStop = False
        Me.chc明細完了区分.Value = "完了区分"
        '
        'txt明細棚卸名
        '
        Me.txt明細棚卸名.Ellipsis = GrapeCity.Win.MultiRow.MultiRowEllipsisMode.EllipsisEnd
        Me.txt明細棚卸名.Location = New System.Drawing.Point(0, 0)
        Me.txt明細棚卸名.MaxLength = 60
        Me.txt明細棚卸名.Name = "txt明細棚卸名"
        Me.txt明細棚卸名.ReadOnly = True
        Me.txt明細棚卸名.Size = New System.Drawing.Size(368, 21)
        Border12.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle12.Border = Border12
        CellStyle12.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle12.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle12.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細棚卸名.Style = CellStyle12
        Me.txt明細棚卸名.TabIndex = 1
        '
        'txt明細棚卸区分名
        '
        Me.txt明細棚卸区分名.Ellipsis = GrapeCity.Win.MultiRow.MultiRowEllipsisMode.EllipsisEnd
        Me.txt明細棚卸区分名.Location = New System.Drawing.Point(368, 0)
        Me.txt明細棚卸区分名.MaxLength = 8
        Me.txt明細棚卸区分名.Name = "txt明細棚卸区分名"
        Me.txt明細棚卸区分名.ReadOnly = True
        Border13.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle13.Border = Border13
        CellStyle13.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle13.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle13.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細棚卸区分名.Style = CellStyle13
        Me.txt明細棚卸区分名.TabIndex = 2
        '
        'txt明細完了区分名
        '
        Me.txt明細完了区分名.Ellipsis = GrapeCity.Win.MultiRow.MultiRowEllipsisMode.EllipsisEnd
        Me.txt明細完了区分名.Location = New System.Drawing.Point(448, 0)
        Me.txt明細完了区分名.MaxLength = 10
        Me.txt明細完了区分名.Name = "txt明細完了区分名"
        Me.txt明細完了区分名.ReadOnly = True
        Border14.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle14.Border = Border14
        CellStyle14.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle14.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle14.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細完了区分名.Style = CellStyle14
        Me.txt明細完了区分名.TabIndex = 3
        '
        'txt明細棚卸区分
        '
        Me.txt明細棚卸区分.Location = New System.Drawing.Point(393, 0)
        Me.txt明細棚卸区分.MaxLength = 2
        Me.txt明細棚卸区分.Name = "txt明細棚卸区分"
        Me.txt明細棚卸区分.ReadOnly = True
        Me.txt明細棚卸区分.Size = New System.Drawing.Size(30, 21)
        Border15.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle15.Border = Border15
        CellStyle15.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle15.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle15.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細棚卸区分.Style = CellStyle15
        Me.txt明細棚卸区分.TabIndex = 102
        Me.txt明細棚卸区分.TabStop = False
        '
        'txt明細完了区分
        '
        Me.txt明細完了区分.Location = New System.Drawing.Point(468, 0)
        Me.txt明細完了区分.MaxLength = 2
        Me.txt明細完了区分.Name = "txt明細完了区分"
        Me.txt明細完了区分.ReadOnly = True
        Me.txt明細完了区分.Size = New System.Drawing.Size(30, 21)
        Border16.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle16.Border = Border16
        CellStyle16.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle16.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle16.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細完了区分.Style = CellStyle16
        Me.txt明細完了区分.TabIndex = 103
        Me.txt明細完了区分.TabStop = False
        '
        'txt明細ID
        '
        Me.txt明細ID.Location = New System.Drawing.Point(37, 0)
        Me.txt明細ID.MaxLength = 10
        Me.txt明細ID.Name = "txt明細ID"
        Me.txt明細ID.ReadOnly = True
        Me.txt明細ID.Size = New System.Drawing.Size(89, 21)
        Border17.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle17.Border = Border17
        CellStyle17.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle17.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle17.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細ID.Style = CellStyle17
        Me.txt明細ID.TabIndex = 101
        Me.txt明細ID.TabStop = False
        '
        'chc明細状態
        '
        Me.chc明細状態.Location = New System.Drawing.Point(528, 0)
        Me.chc明細状態.Name = "chc明細状態"
        Me.chc明細状態.ResizeMode = GrapeCity.Win.MultiRow.ResizeMode.None
        Me.chc明細状態.SelectionMode = GrapeCity.Win.MultiRow.MultiRowSelectionMode.None
        Me.chc明細状態.Size = New System.Drawing.Size(45, 21)
        Me.chc明細状態.SortCellName = "txt明細状態"
        Me.chc明細状態.SortMode = GrapeCity.Win.MultiRow.SortMode.Automatic
        CellStyle22.BackColor = System.Drawing.SystemColors.Control
        Border22.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle22.Border = Border22
        CellStyle22.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle22.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle22.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.chc明細状態.Style = CellStyle22
        Me.chc明細状態.TabIndex = 3
        Me.chc明細状態.TabStop = False
        Me.chc明細状態.Value = "状態"
        '
        'txt明細状態
        '
        Me.txt明細状態.Ellipsis = GrapeCity.Win.MultiRow.MultiRowEllipsisMode.EllipsisEnd
        Me.txt明細状態.Location = New System.Drawing.Point(528, 0)
        Me.txt明細状態.MaxLength = 60
        Me.txt明細状態.Name = "txt明細状態"
        Me.txt明細状態.ReadOnly = True
        Me.txt明細状態.Size = New System.Drawing.Size(45, 21)
        Border18.Outline = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.Thin, System.Drawing.Color.Black)
        CellStyle18.Border = Border18
        CellStyle18.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        CellStyle18.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        CellStyle18.TextAlign = GrapeCity.Win.MultiRow.MultiRowContentAlignment.MiddleLeft
        Me.txt明細状態.Style = CellStyle18
        Me.txt明細状態.TabIndex = 4
        '
        'HARK202S1Template
        '
        Me.ColumnHeaders.AddRange(New GrapeCity.Win.MultiRow.ColumnHeaderSection() {Me.ColumnHeaderSection})
        Me.Height = 42
        Me.Width = 573

    End Sub
    Friend WithEvents ColumnHeaderSection As GrapeCity.Win.MultiRow.ColumnHeaderSection
    Private WithEvents chc明細棚卸名 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents chc明細棚卸区分 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents chc明細完了区分 As GrapeCity.Win.MultiRow.ColumnHeaderCell
    Private WithEvents txt明細棚卸名 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細棚卸区分名 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細完了区分名 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細棚卸区分 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細完了区分 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細ID As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents txt明細状態 As GrapeCity.Win.MultiRow.TextBoxCell
    Private WithEvents chc明細状態 As GrapeCity.Win.MultiRow.ColumnHeaderCell
End Class
