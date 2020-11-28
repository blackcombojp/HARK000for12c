'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK303
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
        Me.components = New System.ComponentModel.Container()
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim ShortcutKeyManager1 As GrapeCity.Win.MultiRow.ShortcutKeyManager = New GrapeCity.Win.MultiRow.ShortcutKeyManager()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK303))
        Me.cmb事業所 = New System.Windows.Forms.ComboBox()
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.txt入力担当コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl事業所 = New System.Windows.Forms.Label()
        Me.SttBar_3 = New System.Windows.Forms.StatusBarPanel()
        Me.SttBar_2 = New System.Windows.Forms.StatusBarPanel()
        Me.SttBarPnl_Err = New System.Windows.Forms.StatusBarPanel()
        Me.lbl入力担当 = New System.Windows.Forms.Label()
        Me.SttBar = New System.Windows.Forms.StatusBar()
        Me.BT_ID7 = New System.Windows.Forms.Button()
        Me.BT_ID8 = New System.Windows.Forms.Button()
        Me.BT_ID3 = New System.Windows.Forms.Button()
        Me.BT_ID2 = New System.Windows.Forms.Button()
        Me.BT_ID1 = New System.Windows.Forms.Button()
        Me.BT_ID6 = New System.Windows.Forms.Button()
        Me.Bt_Close = New System.Windows.Forms.Button()
        Me.BT_ID5 = New System.Windows.Forms.Button()
        Me.ExcelCreator = New AdvanceSoftware.ExcelCreator.Creator(Me.components)
        Me.BS一覧 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HARK303DS = New HARK000.HARK303DS()
        Me.lb_Msg = New GrapeCity.Win.Editors.GcListBox()
        Me.gcmr一覧 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.HARK303Template1 = New HARK000.HARK303Template()
        Me.CntMenuStrip.SuspendLayout()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK303DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb事業所
        '
        Me.cmb事業所.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb事業所.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb事業所.FormattingEnabled = True
        Me.cmb事業所.Location = New System.Drawing.Point(110, 29)
        Me.cmb事業所.Name = "cmb事業所"
        Me.cmb事業所.Size = New System.Drawing.Size(127, 26)
        Me.cmb事業所.TabIndex = 1
        Me.cmb事業所.TabStop = False
        Me.cmb事業所.Tag = "ID1"
        '
        'Menu_Log
        '
        Me.Menu_Log.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Menu_Log.Name = "Menu_Log"
        Me.Menu_Log.Size = New System.Drawing.Size(135, 22)
        Me.Menu_Log.Text = "操作ログ"
        '
        'CntMenuStrip
        '
        Me.CntMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Log, Me.Menu_ErrorLog})
        Me.CntMenuStrip.Name = "CntMenuStrip"
        Me.CntMenuStrip.Size = New System.Drawing.Size(136, 48)
        '
        'Menu_ErrorLog
        '
        Me.Menu_ErrorLog.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Menu_ErrorLog.Name = "Menu_ErrorLog"
        Me.Menu_ErrorLog.Size = New System.Drawing.Size(135, 22)
        Me.Menu_ErrorLog.Text = "エラーログ"
        '
        'BT_ID4
        '
        Me.BT_ID4.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID4.DropDown = Me.CntMenuStrip
        Me.BT_ID4.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID4.Location = New System.Drawing.Point(255, 0)
        Me.BT_ID4.Name = "BT_ID4"
        Me.BT_ID4.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID4.TabIndex = 134
        Me.BT_ID4.Tag = "ID4"
        Me.BT_ID4.Text = "ログ(&F4)"
        Me.BT_ID4.UseVisualStyleBackColor = False
        '
        'txt入力担当コード
        '
        Me.txt入力担当コード.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt入力担当コード.AcceptsTabChar = GrapeCity.Win.Editors.TabCharMode.Filter
        Me.txt入力担当コード.Enabled = False
        Me.txt入力担当コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt入力担当コード.Format = "9"
        Me.txt入力担当コード.HighlightText = True
        Me.txt入力担当コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt入力担当コード.Location = New System.Drawing.Point(425, 30)
        Me.txt入力担当コード.MaxLength = 10
        Me.txt入力担当コード.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt入力担当コード.Name = "txt入力担当コード"
        Me.txt入力担当コード.Size = New System.Drawing.Size(110, 24)
        Me.txt入力担当コード.TabIndex = 2
        Me.txt入力担当コード.TabStop = False
        Me.txt入力担当コード.WrapMode = GrapeCity.Win.Editors.WrapMode.NoWrap
        '
        'lbl事業所
        '
        Me.lbl事業所.AutoSize = True
        Me.lbl事業所.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl事業所.Location = New System.Drawing.Point(61, 32)
        Me.lbl事業所.Name = "lbl事業所"
        Me.lbl事業所.Size = New System.Drawing.Size(48, 20)
        Me.lbl事業所.TabIndex = 179
        Me.lbl事業所.Text = "事業所"
        '
        'SttBar_3
        '
        Me.SttBar_3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.SttBar_3.MinWidth = 135
        Me.SttBar_3.Name = "SttBar_3"
        Me.SttBar_3.Width = 135
        '
        'SttBar_2
        '
        Me.SttBar_2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.SttBar_2.Name = "SttBar_2"
        Me.SttBar_2.Width = 135
        '
        'SttBarPnl_Err
        '
        Me.SttBarPnl_Err.Name = "SttBarPnl_Err"
        Me.SttBarPnl_Err.Width = 720
        '
        'lbl入力担当
        '
        Me.lbl入力担当.AutoSize = True
        Me.lbl入力担当.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl入力担当.Location = New System.Drawing.Point(360, 32)
        Me.lbl入力担当.Name = "lbl入力担当"
        Me.lbl入力担当.Size = New System.Drawing.Size(61, 20)
        Me.lbl入力担当.TabIndex = 180
        Me.lbl入力担当.Text = "入力担当"
        '
        'SttBar
        '
        Me.SttBar.Location = New System.Drawing.Point(0, 701)
        Me.SttBar.Name = "SttBar"
        Me.SttBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SttBarPnl_Err, Me.SttBar_2, Me.SttBar_3})
        Me.SttBar.ShowPanels = True
        Me.SttBar.Size = New System.Drawing.Size(1004, 24)
        Me.SttBar.TabIndex = 170
        '
        'BT_ID7
        '
        Me.BT_ID7.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID7.Enabled = False
        Me.BT_ID7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID7.Location = New System.Drawing.Point(530, 0)
        Me.BT_ID7.Name = "BT_ID7"
        Me.BT_ID7.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID7.TabIndex = 137
        Me.BT_ID7.Tag = "ID7"
        Me.BT_ID7.UseVisualStyleBackColor = False
        '
        'BT_ID8
        '
        Me.BT_ID8.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID8.Enabled = False
        Me.BT_ID8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID8.Location = New System.Drawing.Point(615, 0)
        Me.BT_ID8.Name = "BT_ID8"
        Me.BT_ID8.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID8.TabIndex = 138
        Me.BT_ID8.Tag = "ID8"
        Me.BT_ID8.UseVisualStyleBackColor = False
        '
        'BT_ID3
        '
        Me.BT_ID3.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID3.Location = New System.Drawing.Point(170, 0)
        Me.BT_ID3.Name = "BT_ID3"
        Me.BT_ID3.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID3.TabIndex = 133
        Me.BT_ID3.Tag = "ID3"
        Me.BT_ID3.Text = "クリア(&F3)"
        Me.BT_ID3.UseVisualStyleBackColor = False
        '
        'BT_ID2
        '
        Me.BT_ID2.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID2.Location = New System.Drawing.Point(85, 0)
        Me.BT_ID2.Name = "BT_ID2"
        Me.BT_ID2.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID2.TabIndex = 132
        Me.BT_ID2.Tag = "ID2"
        Me.BT_ID2.Text = "取込(&F2)"
        Me.BT_ID2.UseVisualStyleBackColor = False
        '
        'BT_ID1
        '
        Me.BT_ID1.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID1.Enabled = False
        Me.BT_ID1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID1.Location = New System.Drawing.Point(0, 0)
        Me.BT_ID1.Name = "BT_ID1"
        Me.BT_ID1.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID1.TabIndex = 131
        Me.BT_ID1.Tag = "ID1"
        Me.BT_ID1.UseVisualStyleBackColor = False
        '
        'BT_ID6
        '
        Me.BT_ID6.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID6.Enabled = False
        Me.BT_ID6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID6.Location = New System.Drawing.Point(445, 0)
        Me.BT_ID6.Name = "BT_ID6"
        Me.BT_ID6.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID6.TabIndex = 136
        Me.BT_ID6.Tag = "ID6"
        Me.BT_ID6.UseVisualStyleBackColor = False
        '
        'Bt_Close
        '
        Me.Bt_Close.BackColor = System.Drawing.SystemColors.Control
        Me.Bt_Close.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Bt_Close.Location = New System.Drawing.Point(919, 0)
        Me.Bt_Close.Name = "Bt_Close"
        Me.Bt_Close.Size = New System.Drawing.Size(85, 24)
        Me.Bt_Close.TabIndex = 130
        Me.Bt_Close.Text = "戻る(&F12)"
        Me.Bt_Close.UseVisualStyleBackColor = False
        '
        'BT_ID5
        '
        Me.BT_ID5.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID5.Location = New System.Drawing.Point(360, 0)
        Me.BT_ID5.Name = "BT_ID5"
        Me.BT_ID5.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID5.TabIndex = 135
        Me.BT_ID5.Tag = "ID5"
        Me.BT_ID5.Text = "確定(&F5)"
        Me.BT_ID5.UseVisualStyleBackColor = False
        '
        'ExcelCreator
        '
        Me.ExcelCreator.ChangeRefSheetAddressMode = False
        Me.ExcelCreator.ExcelFileType = AdvanceSoftware.ExcelCreator.ExcelFileType.xlsx
        Me.ExcelCreator.TemporaryPath = ""
        '
        'BS一覧
        '
        Me.BS一覧.AllowNew = True
        Me.BS一覧.DataMember = "ds一覧"
        Me.BS一覧.DataSource = Me.HARK303DS
        '
        'HARK303DS
        '
        Me.HARK303DS.DataSetName = "HARK303DS"
        Me.HARK303DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lb_Msg
        '
        Me.lb_Msg.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lb_Msg.ListHeaderPane.AutoHeight = False
        Me.lb_Msg.ListHeaderPane.Visible = False
        Me.lb_Msg.Location = New System.Drawing.Point(25, 538)
        Me.lb_Msg.Name = "lb_Msg"
        Me.lb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lb_Msg.Size = New System.Drawing.Size(955, 169)
        Me.lb_Msg.TabIndex = 302
        Me.lb_Msg.TabStop = False
        '
        'gcmr一覧
        '
        Me.gcmr一覧.AllowClipboard = False
        Me.gcmr一覧.AllowUserToAddRows = False
        Me.gcmr一覧.AllowUserToAutoFitColumns = False
        Me.gcmr一覧.AllowUserToDeleteRows = False
        Me.gcmr一覧.AllowUserToResize = False
        Me.gcmr一覧.AllowUserToTouchResize = False
        Me.gcmr一覧.AllowUserToTouchZoom = False
        Me.gcmr一覧.AllowUserToZoom = False
        CellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        CellStyle1.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        Me.gcmr一覧.AlternatingRowsDefaultCellStyle = CellStyle1
        Me.gcmr一覧.ClipboardCopyMode = GrapeCity.Win.MultiRow.ClipboardCopyMode.Disable
        Me.gcmr一覧.CurrentCellBorderLine = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.None, System.Drawing.Color.Black)
        Me.gcmr一覧.DataSource = Me.BS一覧
        Me.gcmr一覧.Location = New System.Drawing.Point(25, 63)
        Me.gcmr一覧.MultiSelect = False
        Me.gcmr一覧.Name = "gcmr一覧"
        Me.gcmr一覧.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveUp, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveLeft, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveRight, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftLeft, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftRight, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstCellInRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastCellInRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastCellInRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.PageUp), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[Next]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F2))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.EndEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Return]))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CancelEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Escape))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CommitRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Clear, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Delete))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F4))
        ShortcutKeyManager1.DefaultModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollUp, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollLeft, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.ScrollRight, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToLastPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.VerticalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Space))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToFirstPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToLastPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToLastPage, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ComponentActions.SelectPreviousControl, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.DisplayModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ComponentActions.SelectNextControl, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ReverseSelectCurrentRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Space))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
        ShortcutKeyManager1.ListBoxModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.ScrollActions.HorizontalScrollToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Tab))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Tab), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Home))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[End]))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Up))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Left))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Down))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextRow, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Right))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.PageUp))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextPage, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.[Next]))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Home), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToFirstRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[End]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToLastRow, GrapeCity.Win.MultiRow.Action), CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToPreviousRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToPreviousRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToNextRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftToNextRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageUp, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.PageUp), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.ShiftPageDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[Next]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.SelectAll, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F2))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(New GrapeCity.Win.MultiRow.ActionList(New GrapeCity.Win.MultiRow.IAction() {CType(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), GrapeCity.Win.MultiRow.IAction), CType(CType(GrapeCity.Win.MultiRow.EditingActions.BeginEdit, GrapeCity.Win.MultiRow.Action), GrapeCity.Win.MultiRow.IAction)}), System.Windows.Forms.Keys.[Return]))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(New GrapeCity.Win.MultiRow.ActionList(New GrapeCity.Win.MultiRow.IAction() {CType(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToNextCell, GrapeCity.Win.MultiRow.Action), GrapeCity.Win.MultiRow.IAction), CType(CType(GrapeCity.Win.MultiRow.EditingActions.EndEdit, GrapeCity.Win.MultiRow.Action), GrapeCity.Win.MultiRow.IAction)}), System.Windows.Forms.Keys.[Return]))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.SelectionActions.MoveToPreviousCell, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CancelEdit, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Escape))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.CommitRow, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Cut, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Copy, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Paste, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.Clear, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.Delete))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.DeleteSelectedRows, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.InputNullValue, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.NumPad0), System.Windows.Forms.Keys)))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), System.Windows.Forms.Keys.F4))
        ShortcutKeyManager1.RowModeList.Add(New GrapeCity.Win.MultiRow.ShortcutKey(CType(GrapeCity.Win.MultiRow.EditingActions.ShowDropDown, GrapeCity.Win.MultiRow.Action), CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)))
        Me.gcmr一覧.ShortcutKeyManager = ShortcutKeyManager1
        Me.gcmr一覧.Size = New System.Drawing.Size(955, 469)
        Me.gcmr一覧.SplitMode = GrapeCity.Win.MultiRow.SplitMode.None
        Me.gcmr一覧.TabIndex = 301
        Me.gcmr一覧.TabStop = False
        Me.gcmr一覧.Template = Me.HARK303Template1
        Me.gcmr一覧.Text = "GcMultiRow1"
        '
        'HARK303
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 725)
        Me.Controls.Add(Me.lb_Msg)
        Me.Controls.Add(Me.gcmr一覧)
        Me.Controls.Add(Me.cmb事業所)
        Me.Controls.Add(Me.BT_ID4)
        Me.Controls.Add(Me.txt入力担当コード)
        Me.Controls.Add(Me.lbl事業所)
        Me.Controls.Add(Me.lbl入力担当)
        Me.Controls.Add(Me.SttBar)
        Me.Controls.Add(Me.BT_ID7)
        Me.Controls.Add(Me.BT_ID8)
        Me.Controls.Add(Me.BT_ID3)
        Me.Controls.Add(Me.BT_ID2)
        Me.Controls.Add(Me.BT_ID1)
        Me.Controls.Add(Me.BT_ID6)
        Me.Controls.Add(Me.Bt_Close)
        Me.Controls.Add(Me.BT_ID5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "HARK303"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK303DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents cmb事業所 As ComboBox
    Private WithEvents Menu_Log As ToolStripMenuItem
    Private WithEvents CntMenuStrip As ContextMenuStrip
    Private WithEvents Menu_ErrorLog As ToolStripMenuItem
    Private WithEvents BT_ID4 As GrapeCity.Win.Buttons.GcSplitButton
    Private WithEvents txt入力担当コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl事業所 As Label
    Private WithEvents SttBar_3 As StatusBarPanel
    Private WithEvents SttBar_2 As StatusBarPanel
    Private WithEvents SttBarPnl_Err As StatusBarPanel
    Private WithEvents lbl入力担当 As Label
    Private WithEvents SttBar As StatusBar
    Private WithEvents BT_ID7 As Button
    Private WithEvents BT_ID8 As Button
    Private WithEvents BT_ID3 As Button
    Private WithEvents BT_ID2 As Button
    Private WithEvents BT_ID1 As Button
    Private WithEvents BT_ID6 As Button
    Private WithEvents Bt_Close As Button
    Private WithEvents BT_ID5 As Button
    Private WithEvents ExcelCreator As AdvanceSoftware.ExcelCreator.Creator
    Private WithEvents gcmr一覧 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents BS一覧 As BindingSource
    Private WithEvents HARK303DS As HARK303DS
    Private WithEvents HARK303Template1 As HARK303Template

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxmForm As Form
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String


    Public Sub New(ByVal PerForm As Form, ByVal PerFormTitle As String, ByVal PerProgramID As String)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxmForm = PerForm
        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = 0

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb事業所.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Clickイベントハンドラの追加
        AddHandler BT_ID1.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID2.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID3.Click, AddressOf Bt_ID_Click
        'AddHandler BT_ID4.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID5.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID6.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID7.Click, AddressOf Bt_ID_Click
        AddHandler BT_ID8.Click, AddressOf Bt_ID_Click

    End Sub

    Private WithEvents lb_Msg As GrapeCity.Win.Editors.GcListBox


End Class
