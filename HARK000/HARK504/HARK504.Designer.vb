'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK504
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
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim ShortcutKeyManager1 As GrapeCity.Win.MultiRow.ShortcutKeyManager = New GrapeCity.Win.MultiRow.ShortcutKeyManager()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK504))
        Me.cmb事業所 = New System.Windows.Forms.ComboBox()
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl検索 = New System.Windows.Forms.Panel()
        Me.cmb検索条件１ = New System.Windows.Forms.ComboBox()
        Me.cmb検索許可証２ = New System.Windows.Forms.ComboBox()
        Me.cmb検索分類２ = New System.Windows.Forms.ComboBox()
        Me.cmb検索許可証１ = New System.Windows.Forms.ComboBox()
        Me.cmb検索分類１ = New System.Windows.Forms.ComboBox()
        Me.txt検索Date = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl検索項目名６ = New System.Windows.Forms.Label()
        Me.lbl検索項目名４ = New System.Windows.Forms.Label()
        Me.lbl検索項目名５ = New System.Windows.Forms.Label()
        Me.lbl検索項目名３ = New System.Windows.Forms.Label()
        Me.txt検索得意先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl検索得意先名 = New System.Windows.Forms.Label()
        Me.Rb_検索条件１ = New System.Windows.Forms.RadioButton()
        Me.Rb_検索条件２ = New System.Windows.Forms.RadioButton()
        Me.lbl検索項目名１ = New System.Windows.Forms.Label()
        Me.lbl検索項目名２ = New System.Windows.Forms.Label()
        Me.btn検索 = New GrapeCity.Win.Buttons.GcButton()
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
        Me.HARK504DS = New HARK000.HARK504DS()
        Me.SaveFileDlg = New System.Windows.Forms.SaveFileDialog()
        Me.gcmr一覧 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.HARK504Template1 = New HARK000.HARK504Template()
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl検索.SuspendLayout()
        CType(Me.txt検索Date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt検索得意先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK504DS, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.cmb検索条件１)
        Me.pnl検索.Controls.Add(Me.cmb検索許可証２)
        Me.pnl検索.Controls.Add(Me.cmb検索分類２)
        Me.pnl検索.Controls.Add(Me.cmb検索許可証１)
        Me.pnl検索.Controls.Add(Me.cmb検索分類１)
        Me.pnl検索.Controls.Add(Me.txt検索Date)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名６)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名４)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名５)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名３)
        Me.pnl検索.Controls.Add(Me.txt検索得意先コード)
        Me.pnl検索.Controls.Add(Me.lbl検索得意先名)
        Me.pnl検索.Controls.Add(Me.Rb_検索条件１)
        Me.pnl検索.Controls.Add(Me.Rb_検索条件２)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名１)
        Me.pnl検索.Controls.Add(Me.lbl検索項目名２)
        Me.pnl検索.Controls.Add(Me.btn検索)
        Me.pnl検索.Location = New System.Drawing.Point(25, 60)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(970, 132)
        Me.pnl検索.TabIndex = 100
        '
        'cmb検索条件１
        '
        Me.cmb検索条件１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb検索条件１.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb検索条件１.FormattingEnabled = True
        Me.cmb検索条件１.ItemHeight = 18
        Me.cmb検索条件１.Location = New System.Drawing.Point(475, 95)
        Me.cmb検索条件１.Name = "cmb検索条件１"
        Me.cmb検索条件１.Size = New System.Drawing.Size(242, 26)
        Me.cmb検索条件１.TabIndex = 16
        Me.cmb検索条件１.Tag = "ID6"
        '
        'cmb検索許可証２
        '
        Me.cmb検索許可証２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb検索許可証２.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb検索許可証２.FormattingEnabled = True
        Me.cmb検索許可証２.ItemHeight = 18
        Me.cmb検索許可証２.Location = New System.Drawing.Point(475, 65)
        Me.cmb検索許可証２.Name = "cmb検索許可証２"
        Me.cmb検索許可証２.Size = New System.Drawing.Size(169, 26)
        Me.cmb検索許可証２.TabIndex = 15
        Me.cmb検索許可証２.Tag = "ID5"
        '
        'cmb検索分類２
        '
        Me.cmb検索分類２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb検索分類２.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb検索分類２.FormattingEnabled = True
        Me.cmb検索分類２.ItemHeight = 18
        Me.cmb検索分類２.Location = New System.Drawing.Point(475, 35)
        Me.cmb検索分類２.Name = "cmb検索分類２"
        Me.cmb検索分類２.Size = New System.Drawing.Size(169, 26)
        Me.cmb検索分類２.TabIndex = 14
        Me.cmb検索分類２.Tag = "ID4"
        '
        'cmb検索許可証１
        '
        Me.cmb検索許可証１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb検索許可証１.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb検索許可証１.FormattingEnabled = True
        Me.cmb検索許可証１.ItemHeight = 18
        Me.cmb検索許可証１.Location = New System.Drawing.Point(77, 95)
        Me.cmb検索許可証１.Name = "cmb検索許可証１"
        Me.cmb検索許可証１.Size = New System.Drawing.Size(169, 26)
        Me.cmb検索許可証１.TabIndex = 13
        Me.cmb検索許可証１.Tag = "ID3"
        '
        'cmb検索分類１
        '
        Me.cmb検索分類１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb検索分類１.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb検索分類１.FormattingEnabled = True
        Me.cmb検索分類１.ItemHeight = 18
        Me.cmb検索分類１.Location = New System.Drawing.Point(77, 64)
        Me.cmb検索分類１.Name = "cmb検索分類１"
        Me.cmb検索分類１.Size = New System.Drawing.Size(169, 26)
        Me.cmb検索分類１.TabIndex = 12
        Me.cmb検索分類１.Tag = "ID2"
        '
        'txt検索Date
        '
        Me.txt検索Date.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.txt検索Date.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.txt検索Date.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt検索Date.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt検索Date.Location = New System.Drawing.Point(723, 95)
        Me.txt検索Date.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt検索Date.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt検索Date.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt検索Date.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt検索Date.Name = "txt検索Date"
        Me.txt検索Date.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.txt検索Date.Size = New System.Drawing.Size(111, 26)
        Me.txt検索Date.TabIndex = 17
        Me.txt検索Date.Tag = ""
        Me.txt検索Date.Value = Nothing
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'lbl検索項目名６
        '
        Me.lbl検索項目名６.AutoSize = True
        Me.lbl検索項目名６.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名６.Location = New System.Drawing.Point(405, 99)
        Me.lbl検索項目名６.Name = "lbl検索項目名６"
        Me.lbl検索項目名６.Size = New System.Drawing.Size(56, 18)
        Me.lbl検索項目名６.TabIndex = 195
        Me.lbl検索項目名６.Text = "【条件】"
        Me.lbl検索項目名６.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl検索項目名４
        '
        Me.lbl検索項目名４.AutoSize = True
        Me.lbl検索項目名４.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名４.Location = New System.Drawing.Point(405, 39)
        Me.lbl検索項目名４.Name = "lbl検索項目名４"
        Me.lbl検索項目名４.Size = New System.Drawing.Size(56, 18)
        Me.lbl検索項目名４.TabIndex = 193
        Me.lbl検索項目名４.Text = "【業種】"
        Me.lbl検索項目名４.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl検索項目名５
        '
        Me.lbl検索項目名５.AutoSize = True
        Me.lbl検索項目名５.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名５.Location = New System.Drawing.Point(405, 69)
        Me.lbl検索項目名５.Name = "lbl検索項目名５"
        Me.lbl検索項目名５.Size = New System.Drawing.Size(68, 18)
        Me.lbl検索項目名５.TabIndex = 192
        Me.lbl検索項目名５.Text = "【許可証】"
        Me.lbl検索項目名５.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl検索項目名３
        '
        Me.lbl検索項目名３.AutoSize = True
        Me.lbl検索項目名３.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名３.Location = New System.Drawing.Point(7, 99)
        Me.lbl検索項目名３.Name = "lbl検索項目名３"
        Me.lbl検索項目名３.Size = New System.Drawing.Size(68, 18)
        Me.lbl検索項目名３.TabIndex = 188
        Me.lbl検索項目名３.Text = "【許可証】"
        Me.lbl検索項目名３.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt検索得意先コード
        '
        Me.txt検索得意先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt検索得意先コード.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt検索得意先コード.Format = "9"
        Me.txt検索得意先コード.HighlightText = True
        Me.txt検索得意先コード.Location = New System.Drawing.Point(77, 35)
        Me.txt検索得意先コード.MaxLength = 10
        Me.txt検索得意先コード.Name = "txt検索得意先コード"
        Me.txt検索得意先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt検索得意先コード.TabIndex = 11
        Me.txt検索得意先コード.Tag = "ID1"
        '
        'lbl検索得意先名
        '
        Me.lbl検索得意先名.AutoEllipsis = True
        Me.lbl検索得意先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl検索得意先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl検索得意先名.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索得意先名.Location = New System.Drawing.Point(172, 35)
        Me.lbl検索得意先名.Name = "lbl検索得意先名"
        Me.lbl検索得意先名.Size = New System.Drawing.Size(222, 24)
        Me.lbl検索得意先名.TabIndex = 183
        Me.lbl検索得意先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Rb_検索条件１
        '
        Me.Rb_検索条件１.AutoSize = True
        Me.Rb_検索条件１.Location = New System.Drawing.Point(26, 12)
        Me.Rb_検索条件１.Name = "Rb_検索条件１"
        Me.Rb_検索条件１.Size = New System.Drawing.Size(184, 16)
        Me.Rb_検索条件１.TabIndex = 200
        Me.Rb_検索条件１.Text = "得意先検索(登録済情報を検索)"
        Me.Rb_検索条件１.UseVisualStyleBackColor = True
        '
        'Rb_検索条件２
        '
        Me.Rb_検索条件２.AutoSize = True
        Me.Rb_検索条件２.Location = New System.Drawing.Point(436, 12)
        Me.Rb_検索条件２.Name = "Rb_検索条件２"
        Me.Rb_検索条件２.Size = New System.Drawing.Size(242, 16)
        Me.Rb_検索条件２.TabIndex = 201
        Me.Rb_検索条件２.Text = "条件検索(得意先マスタと登録済情報を検索)"
        Me.Rb_検索条件２.UseVisualStyleBackColor = True
        '
        'lbl検索項目名１
        '
        Me.lbl検索項目名１.AutoSize = True
        Me.lbl検索項目名１.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名１.Location = New System.Drawing.Point(7, 38)
        Me.lbl検索項目名１.Name = "lbl検索項目名１"
        Me.lbl検索項目名１.Size = New System.Drawing.Size(68, 18)
        Me.lbl検索項目名１.TabIndex = 176
        Me.lbl検索項目名１.Text = "【得意先】"
        Me.lbl検索項目名１.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl検索項目名２
        '
        Me.lbl検索項目名２.AutoSize = True
        Me.lbl検索項目名２.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl検索項目名２.Location = New System.Drawing.Point(7, 68)
        Me.lbl検索項目名２.Name = "lbl検索項目名２"
        Me.lbl検索項目名２.Size = New System.Drawing.Size(56, 18)
        Me.lbl検索項目名２.TabIndex = 189
        Me.lbl検索項目名２.Text = "【業種】"
        Me.lbl検索項目名２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn検索
        '
        Me.btn検索.BackColor = System.Drawing.SystemColors.Control
        Me.btn検索.Location = New System.Drawing.Point(864, 95)
        Me.btn検索.Name = "btn検索"
        Me.btn検索.Size = New System.Drawing.Size(85, 26)
        Me.btn検索.TabIndex = 18
        Me.btn検索.Tag = "ID1"
        Me.btn検索.Text = "検索(&R)"
        Me.btn検索.UseVisualStyleBackColor = False
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
        Me.SttBar.Location = New System.Drawing.Point(0, 713)
        Me.SttBar.Name = "SttBar"
        Me.SttBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SttBarPnl_Err, Me.SttBar_2, Me.SttBar_3})
        Me.SttBar.ShowPanels = True
        Me.SttBar.Size = New System.Drawing.Size(1022, 24)
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
        Me.BT_ID1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID1.Location = New System.Drawing.Point(0, 0)
        Me.BT_ID1.Name = "BT_ID1"
        Me.BT_ID1.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID1.TabIndex = 131
        Me.BT_ID1.Tag = "ID1"
        Me.BT_ID1.Text = "出力(&F1)"
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
        Me.Bt_Close.Location = New System.Drawing.Point(937, 0)
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
        Me.BS一覧.DataSource = Me.HARK504DS
        '
        'HARK504DS
        '
        Me.HARK504DS.DataSetName = "HARK504DS"
        Me.HARK504DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        CellStyle1.BackColor = System.Drawing.Color.LightCyan
        CellStyle1.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        Me.gcmr一覧.AlternatingRowsDefaultCellStyle = CellStyle1
        Me.gcmr一覧.ClipboardCopyMode = GrapeCity.Win.MultiRow.ClipboardCopyMode.Disable
        Me.gcmr一覧.CurrentCellBorderLine = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.None, System.Drawing.Color.Black)
        Me.gcmr一覧.DataSource = Me.BS一覧
        Me.gcmr一覧.Location = New System.Drawing.Point(25, 198)
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
        Me.gcmr一覧.Size = New System.Drawing.Size(970, 468)
        Me.gcmr一覧.SplitMode = GrapeCity.Win.MultiRow.SplitMode.None
        Me.gcmr一覧.TabIndex = 301
        Me.gcmr一覧.TabStop = False
        Me.gcmr一覧.Template = Me.HARK504Template1
        Me.gcmr一覧.Text = "gcmr一覧"
        '
        'HARK504
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1022, 737)
        Me.Controls.Add(Me.gcmr一覧)
        Me.Controls.Add(Me.cmb事業所)
        Me.Controls.Add(Me.BT_ID4)
        Me.Controls.Add(Me.pnl検索)
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
        Me.Name = "HARK504"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        CType(Me.txt検索Date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt検索得意先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK504DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents cmb事業所 As ComboBox
    Private WithEvents Menu_Log As ToolStripMenuItem
    Private WithEvents CntMenuStrip As ContextMenuStrip
    Private WithEvents Menu_ErrorLog As ToolStripMenuItem
    Private WithEvents BT_ID4 As GrapeCity.Win.Buttons.GcSplitButton
    Private WithEvents pnl検索 As Panel
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
    Private WithEvents btn検索 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents gcmr一覧 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents BS一覧 As BindingSource
    Private WithEvents lbl検索項目名１ As Label
    Private WithEvents HARK504DS As HARK504DS
    Private WithEvents HARK504Template1 As HARK504Template
    Private WithEvents Rb_検索条件２ As RadioButton
    Private WithEvents txt検索得意先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl検索得意先名 As Label
    Private WithEvents lbl検索項目名６ As Label
    Private WithEvents lbl検索項目名４ As Label
    Private WithEvents lbl検索項目名５ As Label
    Private WithEvents lbl検索項目名２ As Label
    Private WithEvents lbl検索項目名３ As Label
    Private WithEvents txt検索Date As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents Rb_検索条件１ As RadioButton
    Private WithEvents cmb検索分類１ As ComboBox
    Private WithEvents cmb検索許可証１ As ComboBox
    Private WithEvents cmb検索条件１ As ComboBox
    Private WithEvents cmb検索許可証２ As ComboBox
    Private WithEvents cmb検索分類２ As ComboBox
    Private WithEvents SaveFileDlg As SaveFileDialog

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxmForm As Form
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String
    Private xxxstr業種コード(2) As String
    Private xxxint許可証区分(2) As Integer
    Private xxxint条件 As Integer
    Private xxxlngResults() As Long
    Private xxxintResultCnt As Integer



    Public Sub New(ByVal PerForm As Form, ByVal PerFormTitle As String, ByVal PerProgramID As String)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxmForm = PerForm
        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = 0

        'Checkedイベントハンドラの追加
        AddHandler Rb_検索条件１.CheckedChanged, AddressOf Rb_CheckedChanged
        AddHandler Rb_検索条件２.CheckedChanged, AddressOf Rb_CheckedChanged


        'PreviewKeyDownイベントハンドラの追加
        AddHandler txt検索得意先コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler cmb検索分類２.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler btn検索.PreviewKeyDown, AddressOf Btn_PreviewKeyDown

        'Clickイベントハンドラの追加
        AddHandler btn検索.Click, AddressOf Btn_Click

        ''KeyDownイベントハンドラの追加
        AddHandler txt検索得意先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb検索分類１.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb検索許可証１.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb検索分類２.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb検索許可証２.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb検索条件１.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt検索Date.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb事業所.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb検索分類１.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb検索許可証１.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb検索分類２.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb検索許可証２.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb検索条件１.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Validatedイベントハンドラの追加
        AddHandler txt検索得意先コード.Validated, AddressOf Txt_Validated

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
