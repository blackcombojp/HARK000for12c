'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK503
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
        Dim DateYearField1 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateYearField2 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK503))
        Me.cmb事業所 = New System.Windows.Forms.ComboBox()
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.lb_Msg = New GrapeCity.Win.Editors.GcListBox()
        Me.btnファイル参照 = New GrapeCity.Win.Buttons.GcButton()
        Me.txt取込ファイル = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl取込ファイル = New System.Windows.Forms.Label()
        Me.pnl操作 = New System.Windows.Forms.Panel()
        Me.lbl引用元得意先名 = New System.Windows.Forms.Label()
        Me.lbl許可期間２ = New System.Windows.Forms.Label()
        Me.txt許可終了日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt許可証番号 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.cmb許可証区分 = New System.Windows.Forms.ComboBox()
        Me.lbl区分 = New System.Windows.Forms.Label()
        Me.txt引用元得意先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl引用元得意先 = New System.Windows.Forms.Label()
        Me.cmb引用 = New System.Windows.Forms.ComboBox()
        Me.lbl引用 = New System.Windows.Forms.Label()
        Me.lbl許可証番号 = New System.Windows.Forms.Label()
        Me.txt得意先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl得意先 = New System.Windows.Forms.Label()
        Me.lbl得意先名 = New System.Windows.Forms.Label()
        Me.txt許可開始日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl許可期間 = New System.Windows.Forms.Label()
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
        Me.CntMenuStrip.SuspendLayout()
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl操作.SuspendLayout()
        CType(Me.txt許可終了日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt許可証番号, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt引用元得意先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt得意先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt許可開始日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lb_Msg
        '
        Me.lb_Msg.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lb_Msg.ListHeaderPane.AutoHeight = False
        Me.lb_Msg.ListHeaderPane.Visible = False
        Me.lb_Msg.Location = New System.Drawing.Point(510, 60)
        Me.lb_Msg.Name = "lb_Msg"
        Me.lb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lb_Msg.Size = New System.Drawing.Size(475, 614)
        Me.lb_Msg.TabIndex = 21
        Me.lb_Msg.TabStop = False
        '
        'btnファイル参照
        '
        Me.btnファイル参照.BackColor = System.Drawing.SystemColors.Control
        Me.btnファイル参照.Location = New System.Drawing.Point(403, 319)
        Me.btnファイル参照.Name = "btnファイル参照"
        Me.btnファイル参照.Size = New System.Drawing.Size(60, 23)
        Me.btnファイル参照.TabIndex = 21
        Me.btnファイル参照.TabStop = False
        Me.btnファイル参照.Tag = "ID1"
        Me.btnファイル参照.Text = "参照"
        Me.btnファイル参照.UseVisualStyleBackColor = False
        '
        'txt取込ファイル
        '
        Me.txt取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt取込ファイル.Location = New System.Drawing.Point(12, 319)
        Me.txt取込ファイル.Name = "txt取込ファイル"
        Me.txt取込ファイル.Size = New System.Drawing.Size(382, 24)
        Me.txt取込ファイル.TabIndex = 20
        Me.txt取込ファイル.Tag = "ID4"
        '
        'lbl取込ファイル
        '
        Me.lbl取込ファイル.AutoSize = True
        Me.lbl取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl取込ファイル.Location = New System.Drawing.Point(12, 296)
        Me.lbl取込ファイル.Name = "lbl取込ファイル"
        Me.lbl取込ファイル.Size = New System.Drawing.Size(113, 20)
        Me.lbl取込ファイル.TabIndex = 166
        Me.lbl取込ファイル.Text = "【取込ファイル】"
        Me.lbl取込ファイル.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnl操作
        '
        Me.pnl操作.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnl操作.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl操作.Controls.Add(Me.lbl引用元得意先名)
        Me.pnl操作.Controls.Add(Me.lbl許可期間２)
        Me.pnl操作.Controls.Add(Me.txt許可終了日)
        Me.pnl操作.Controls.Add(Me.txt許可証番号)
        Me.pnl操作.Controls.Add(Me.cmb許可証区分)
        Me.pnl操作.Controls.Add(Me.lbl区分)
        Me.pnl操作.Controls.Add(Me.txt引用元得意先コード)
        Me.pnl操作.Controls.Add(Me.lbl引用元得意先)
        Me.pnl操作.Controls.Add(Me.cmb引用)
        Me.pnl操作.Controls.Add(Me.lbl引用)
        Me.pnl操作.Controls.Add(Me.lbl許可証番号)
        Me.pnl操作.Controls.Add(Me.txt得意先コード)
        Me.pnl操作.Controls.Add(Me.lbl得意先)
        Me.pnl操作.Controls.Add(Me.lbl得意先名)
        Me.pnl操作.Controls.Add(Me.txt許可開始日)
        Me.pnl操作.Controls.Add(Me.lbl許可期間)
        Me.pnl操作.Controls.Add(Me.btnファイル参照)
        Me.pnl操作.Controls.Add(Me.txt取込ファイル)
        Me.pnl操作.Controls.Add(Me.lbl取込ファイル)
        Me.pnl操作.Location = New System.Drawing.Point(25, 60)
        Me.pnl操作.Name = "pnl操作"
        Me.pnl操作.Size = New System.Drawing.Size(475, 614)
        Me.pnl操作.TabIndex = 0
        '
        'lbl引用元得意先名
        '
        Me.lbl引用元得意先名.AutoEllipsis = True
        Me.lbl引用元得意先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl引用元得意先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl引用元得意先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl引用元得意先名.Location = New System.Drawing.Point(206, 96)
        Me.lbl引用元得意先名.Name = "lbl引用元得意先名"
        Me.lbl引用元得意先名.Size = New System.Drawing.Size(257, 24)
        Me.lbl引用元得意先名.TabIndex = 15
        Me.lbl引用元得意先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl許可期間２
        '
        Me.lbl許可期間２.AutoSize = True
        Me.lbl許可期間２.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl許可期間２.Location = New System.Drawing.Point(139, 266)
        Me.lbl許可期間２.Name = "lbl許可期間２"
        Me.lbl許可期間２.Size = New System.Drawing.Size(22, 20)
        Me.lbl許可期間２.TabIndex = 186
        Me.lbl許可期間２.Text = "～"
        Me.lbl許可期間２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt許可終了日
        '
        Me.txt許可終了日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.txt許可終了日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.txt許可終了日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt許可終了日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt許可終了日.Location = New System.Drawing.Point(169, 263)
        Me.txt許可終了日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt許可終了日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt許可終了日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt許可終了日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt許可終了日.Name = "txt許可終了日"
        Me.txt許可終了日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.txt許可終了日.Size = New System.Drawing.Size(118, 26)
        Me.txt許可終了日.TabIndex = 19
        Me.txt許可終了日.Tag = ""
        Me.txt許可終了日.Value = New Date(2019, 9, 21, 0, 0, 0, 0)
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'txt許可証番号
        '
        Me.txt許可証番号.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt許可証番号.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt許可証番号.HighlightText = True
        Me.txt許可証番号.Location = New System.Drawing.Point(12, 207)
        Me.txt許可証番号.MaxLength = 60
        Me.txt許可証番号.Name = "txt許可証番号"
        Me.txt許可証番号.Size = New System.Drawing.Size(216, 24)
        Me.txt許可証番号.TabIndex = 17
        Me.txt許可証番号.Tag = "ID3"
        '
        'cmb許可証区分
        '
        Me.cmb許可証区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb許可証区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb許可証区分.FormattingEnabled = True
        Me.cmb許可証区分.Location = New System.Drawing.Point(12, 151)
        Me.cmb許可証区分.Name = "cmb許可証区分"
        Me.cmb許可証区分.Size = New System.Drawing.Size(216, 26)
        Me.cmb許可証区分.TabIndex = 16
        Me.cmb許可証区分.Tag = "ID3"
        '
        'lbl区分
        '
        Me.lbl区分.AutoSize = True
        Me.lbl区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl区分.Location = New System.Drawing.Point(12, 128)
        Me.lbl区分.Name = "lbl区分"
        Me.lbl区分.Size = New System.Drawing.Size(61, 20)
        Me.lbl区分.TabIndex = 183
        Me.lbl区分.Text = "【区分】"
        Me.lbl区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt引用元得意先コード
        '
        Me.txt引用元得意先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt引用元得意先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt引用元得意先コード.Format = "9"
        Me.txt引用元得意先コード.HighlightText = True
        Me.txt引用元得意先コード.Location = New System.Drawing.Point(111, 96)
        Me.txt引用元得意先コード.MaxLength = 10
        Me.txt引用元得意先コード.Name = "txt引用元得意先コード"
        Me.txt引用元得意先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt引用元得意先コード.TabIndex = 14
        Me.txt引用元得意先コード.Tag = "ID2"
        '
        'lbl引用元得意先
        '
        Me.lbl引用元得意先.AutoSize = True
        Me.lbl引用元得意先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl引用元得意先.Location = New System.Drawing.Point(111, 72)
        Me.lbl引用元得意先.Name = "lbl引用元得意先"
        Me.lbl引用元得意先.Size = New System.Drawing.Size(113, 20)
        Me.lbl引用元得意先.TabIndex = 181
        Me.lbl引用元得意先.Text = "【引用元得意先】"
        Me.lbl引用元得意先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb引用
        '
        Me.cmb引用.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb引用.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb引用.FormattingEnabled = True
        Me.cmb引用.Location = New System.Drawing.Point(12, 95)
        Me.cmb引用.Name = "cmb引用"
        Me.cmb引用.Size = New System.Drawing.Size(93, 26)
        Me.cmb引用.TabIndex = 13
        Me.cmb引用.Tag = "ID2"
        '
        'lbl引用
        '
        Me.lbl引用.AutoSize = True
        Me.lbl引用.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl引用.Location = New System.Drawing.Point(12, 72)
        Me.lbl引用.Name = "lbl引用"
        Me.lbl引用.Size = New System.Drawing.Size(61, 20)
        Me.lbl引用.TabIndex = 178
        Me.lbl引用.Text = "【引用】"
        Me.lbl引用.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl許可証番号
        '
        Me.lbl許可証番号.AutoSize = True
        Me.lbl許可証番号.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl許可証番号.Location = New System.Drawing.Point(12, 184)
        Me.lbl許可証番号.Name = "lbl許可証番号"
        Me.lbl許可証番号.Size = New System.Drawing.Size(100, 20)
        Me.lbl許可証番号.TabIndex = 176
        Me.lbl許可証番号.Text = "【許可証番号】"
        Me.lbl許可証番号.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt得意先コード
        '
        Me.txt得意先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt得意先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt得意先コード.Format = "9"
        Me.txt得意先コード.HighlightText = True
        Me.txt得意先コード.Location = New System.Drawing.Point(12, 39)
        Me.txt得意先コード.MaxLength = 10
        Me.txt得意先コード.Name = "txt得意先コード"
        Me.txt得意先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt得意先コード.TabIndex = 11
        Me.txt得意先コード.Tag = "ID1"
        '
        'lbl得意先
        '
        Me.lbl得意先.AutoSize = True
        Me.lbl得意先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl得意先.Location = New System.Drawing.Point(12, 16)
        Me.lbl得意先.Name = "lbl得意先"
        Me.lbl得意先.Size = New System.Drawing.Size(74, 20)
        Me.lbl得意先.TabIndex = 174
        Me.lbl得意先.Text = "【得意先】"
        Me.lbl得意先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl得意先名
        '
        Me.lbl得意先名.AutoEllipsis = True
        Me.lbl得意先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl得意先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl得意先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl得意先名.Location = New System.Drawing.Point(107, 39)
        Me.lbl得意先名.Name = "lbl得意先名"
        Me.lbl得意先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl得意先名.TabIndex = 12
        Me.lbl得意先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt許可開始日
        '
        Me.txt許可開始日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField3.Text = "/"
        DateLiteralField4.Text = "/"
        Me.txt許可開始日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField2, DateLiteralField3, DateMonthField2, DateLiteralField4, DateDayField2})
        Me.txt許可開始日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt許可開始日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt許可開始日.Location = New System.Drawing.Point(12, 263)
        Me.txt許可開始日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt許可開始日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt許可開始日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt許可開始日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt許可開始日.Name = "txt許可開始日"
        Me.txt許可開始日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.txt許可開始日.Size = New System.Drawing.Size(118, 26)
        Me.txt許可開始日.TabIndex = 18
        Me.txt許可開始日.Tag = ""
        Me.txt許可開始日.Value = New Date(2019, 9, 21, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl許可期間
        '
        Me.lbl許可期間.AutoSize = True
        Me.lbl許可期間.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl許可期間.Location = New System.Drawing.Point(12, 240)
        Me.lbl許可期間.Name = "lbl許可期間"
        Me.lbl許可期間.Size = New System.Drawing.Size(87, 20)
        Me.lbl許可期間.TabIndex = 169
        Me.lbl許可期間.Text = "【許可期間】"
        Me.lbl許可期間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.BT_ID2.Enabled = False
        Me.BT_ID2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID2.Location = New System.Drawing.Point(85, 0)
        Me.BT_ID2.Name = "BT_ID2"
        Me.BT_ID2.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID2.TabIndex = 132
        Me.BT_ID2.Tag = "ID2"
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
        'HARK503
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 725)
        Me.Controls.Add(Me.cmb事業所)
        Me.Controls.Add(Me.BT_ID4)
        Me.Controls.Add(Me.lb_Msg)
        Me.Controls.Add(Me.pnl操作)
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
        Me.Name = "HARK503"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl操作.ResumeLayout(False)
        Me.pnl操作.PerformLayout()
        CType(Me.txt許可終了日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt許可証番号, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt引用元得意先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt得意先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt許可開始日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents cmb事業所 As ComboBox
    Private WithEvents Menu_Log As ToolStripMenuItem
    Private WithEvents CntMenuStrip As ContextMenuStrip
    Private WithEvents Menu_ErrorLog As ToolStripMenuItem
    Private WithEvents BT_ID4 As GrapeCity.Win.Buttons.GcSplitButton
    Private WithEvents lb_Msg As GrapeCity.Win.Editors.GcListBox
    Private WithEvents btnファイル参照 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents txt取込ファイル As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl取込ファイル As Label
    Private WithEvents pnl操作 As Panel
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
    Private WithEvents txt許可開始日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl許可期間 As Label
    Private WithEvents lbl得意先名 As Label
    Private WithEvents txt得意先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl得意先 As Label
    Private WithEvents lbl許可証番号 As Label
    Private WithEvents lbl許可期間２ As Label
    Private WithEvents txt許可終了日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents txt許可証番号 As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents cmb許可証区分 As ComboBox
    Private WithEvents lbl区分 As Label
    Private WithEvents txt引用元得意先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl引用元得意先 As Label
    Private WithEvents lbl引用元得意先名 As Label
    Private WithEvents cmb引用 As ComboBox
    Private WithEvents lbl引用 As Label

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxmForm As Form
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String
    Private xxxint引用 As Integer
    Private xxxint許可証区分 As Integer

    Public Sub New(ByVal PerForm As Form, ByVal PerFormTitle As String, ByVal PerProgramID As String)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxmForm = PerForm
        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = 0

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txt取込ファイル.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txt得意先コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler txt得意先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt許可開始日.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt許可終了日.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt許可証番号.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt引用元得意先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb引用.KeyDown, AddressOf Cmb_KeyDown
        AddHandler cmb許可証区分.KeyDown, AddressOf Cmb_KeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmb事業所.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler cmb引用.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler cmb許可証区分.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb事業所.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb引用.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb許可証区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Validatedイベントハンドラの追加
        AddHandler txt得意先コード.Validated, AddressOf Txt_Validated
        AddHandler txt引用元得意先コード.Validated, AddressOf Txt_Validated

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



End Class
