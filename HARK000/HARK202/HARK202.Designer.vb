'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK202
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
        Dim DateYearField3 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateYearField4 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField4 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField4 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK202))
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
        Me.pnl検索 = New System.Windows.Forms.Panel()
        Me.btnファイル参照 = New GrapeCity.Win.Buttons.GcButton()
        Me.lbl取込ファイル = New System.Windows.Forms.Label()
        Me.txt取込ファイル = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.GcTabCtrl = New GrapeCity.Win.Containers.GcTabControl()
        Me.Tab未処理 = New GrapeCity.Win.Containers.GcTabPage()
        Me.tab未処理btn06 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn05 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn04 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn03 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn10 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn02 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未処理btn01 = New GrapeCity.Win.Buttons.GcButton()
        Me.gcmr未処理 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.Tab未出力 = New GrapeCity.Win.Containers.GcTabPage()
        Me.tab未出力btn06 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn05 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn03 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn02 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn10 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn04 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab未出力btn01 = New GrapeCity.Win.Buttons.GcButton()
        Me.gcmr未出力 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.Tab履歴 = New GrapeCity.Win.Containers.GcTabPage()
        Me.tab履歴btn06 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab履歴btn05 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab履歴btn04 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab履歴btn03 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab履歴btn02 = New GrapeCity.Win.Buttons.GcButton()
        Me.tab履歴btn01 = New GrapeCity.Win.Buttons.GcButton()
        Me.gcmr履歴 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.pnl履歴検索 = New System.Windows.Forms.Panel()
        Me.btn履歴検索 = New GrapeCity.Win.Buttons.GcButton()
        Me.lbl履歴規格 = New System.Windows.Forms.Label()
        Me.lbl履歴商品名 = New System.Windows.Forms.Label()
        Me.lbl履歴メーカ品番 = New System.Windows.Forms.Label()
        Me.lbl履歴メーカ名 = New System.Windows.Forms.Label()
        Me.txt履歴商品コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl履歴項目名5 = New System.Windows.Forms.Label()
        Me.lbl履歴項目名4 = New System.Windows.Forms.Label()
        Me.lbl履歴項目名3 = New System.Windows.Forms.Label()
        Me.txt履歴需要先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl履歴需要先名 = New System.Windows.Forms.Label()
        Me.txt履歴得意先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl履歴得意先名 = New System.Windows.Forms.Label()
        Me.lbl履歴期間2 = New System.Windows.Forms.Label()
        Me.txt履歴出力終了日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt履歴出力開始日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl履歴項目名2 = New System.Windows.Forms.Label()
        Me.lbl履歴期間1 = New System.Windows.Forms.Label()
        Me.txt履歴取込終了日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt履歴取込開始日 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl履歴項目名1 = New System.Windows.Forms.Label()
        Me.HARK202DS = New HARK000.HARK202DS()
        Me.BS未処理 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BS未出力 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BS履歴 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SaveFileDlg = New System.Windows.Forms.SaveFileDialog()
        Me.CntMenuStrip.SuspendLayout()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GcTabCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GcTabCtrl.SuspendLayout()
        Me.Tab未処理.SuspendLayout()
        CType(Me.gcmr未処理, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab未出力.SuspendLayout()
        CType(Me.gcmr未出力, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab履歴.SuspendLayout()
        CType(Me.gcmr履歴, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl履歴検索.SuspendLayout()
        CType(Me.txt履歴商品コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴需要先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴得意先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴出力終了日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴出力開始日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴取込終了日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt履歴取込開始日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK202DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS未処理, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS未出力, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS履歴, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BT_ID4.Location = New System.Drawing.Point(270, 0)
        Me.BT_ID4.Name = "BT_ID4"
        Me.BT_ID4.Size = New System.Drawing.Size(90, 24)
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
        Me.SttBarPnl_Err.Width = 960
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
        Me.SttBar.Location = New System.Drawing.Point(0, 893)
        Me.SttBar.Name = "SttBar"
        Me.SttBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SttBarPnl_Err, Me.SttBar_2, Me.SttBar_3})
        Me.SttBar.ShowPanels = True
        Me.SttBar.Size = New System.Drawing.Size(1260, 24)
        Me.SttBar.TabIndex = 170
        '
        'BT_ID7
        '
        Me.BT_ID7.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID7.Enabled = False
        Me.BT_ID7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID7.Location = New System.Drawing.Point(560, 0)
        Me.BT_ID7.Name = "BT_ID7"
        Me.BT_ID7.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID7.TabIndex = 137
        Me.BT_ID7.Tag = "ID7"
        Me.BT_ID7.UseVisualStyleBackColor = False
        '
        'BT_ID8
        '
        Me.BT_ID8.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID8.Enabled = False
        Me.BT_ID8.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID8.Location = New System.Drawing.Point(650, 0)
        Me.BT_ID8.Name = "BT_ID8"
        Me.BT_ID8.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID8.TabIndex = 138
        Me.BT_ID8.Tag = "ID8"
        Me.BT_ID8.UseVisualStyleBackColor = False
        '
        'BT_ID3
        '
        Me.BT_ID3.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID3.Location = New System.Drawing.Point(180, 0)
        Me.BT_ID3.Name = "BT_ID3"
        Me.BT_ID3.Size = New System.Drawing.Size(90, 24)
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
        Me.BT_ID2.Location = New System.Drawing.Point(90, 0)
        Me.BT_ID2.Name = "BT_ID2"
        Me.BT_ID2.Size = New System.Drawing.Size(90, 24)
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
        Me.BT_ID1.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID1.TabIndex = 131
        Me.BT_ID1.Tag = "ID1"
        Me.BT_ID1.UseVisualStyleBackColor = False
        '
        'BT_ID6
        '
        Me.BT_ID6.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID6.Enabled = False
        Me.BT_ID6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID6.Location = New System.Drawing.Point(470, 0)
        Me.BT_ID6.Name = "BT_ID6"
        Me.BT_ID6.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID6.TabIndex = 136
        Me.BT_ID6.Tag = "ID6"
        Me.BT_ID6.UseVisualStyleBackColor = False
        '
        'Bt_Close
        '
        Me.Bt_Close.BackColor = System.Drawing.SystemColors.Control
        Me.Bt_Close.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Bt_Close.Location = New System.Drawing.Point(1171, 0)
        Me.Bt_Close.Name = "Bt_Close"
        Me.Bt_Close.Size = New System.Drawing.Size(90, 24)
        Me.Bt_Close.TabIndex = 130
        Me.Bt_Close.Text = "戻る(&F12)"
        Me.Bt_Close.UseVisualStyleBackColor = False
        '
        'BT_ID5
        '
        Me.BT_ID5.BackColor = System.Drawing.SystemColors.Control
        Me.BT_ID5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID5.Location = New System.Drawing.Point(380, 0)
        Me.BT_ID5.Name = "BT_ID5"
        Me.BT_ID5.Size = New System.Drawing.Size(90, 24)
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
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.btnファイル参照)
        Me.pnl検索.Controls.Add(Me.lbl取込ファイル)
        Me.pnl検索.Controls.Add(Me.txt取込ファイル)
        Me.pnl検索.Location = New System.Drawing.Point(25, 65)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(1210, 46)
        Me.pnl検索.TabIndex = 185
        '
        'btnファイル参照
        '
        Me.btnファイル参照.BackColor = System.Drawing.SystemColors.Control
        Me.btnファイル参照.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnファイル参照.Location = New System.Drawing.Point(604, 11)
        Me.btnファイル参照.Name = "btnファイル参照"
        Me.btnファイル参照.Size = New System.Drawing.Size(60, 23)
        Me.btnファイル参照.TabIndex = 168
        Me.btnファイル参照.TabStop = False
        Me.btnファイル参照.Tag = "ID1"
        Me.btnファイル参照.Text = "参照"
        Me.btnファイル参照.UseVisualStyleBackColor = False
        '
        'lbl取込ファイル
        '
        Me.lbl取込ファイル.AutoSize = True
        Me.lbl取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl取込ファイル.Location = New System.Drawing.Point(7, 12)
        Me.lbl取込ファイル.Name = "lbl取込ファイル"
        Me.lbl取込ファイル.Size = New System.Drawing.Size(113, 20)
        Me.lbl取込ファイル.TabIndex = 167
        Me.lbl取込ファイル.Text = "【取込ファイル】"
        Me.lbl取込ファイル.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt取込ファイル
        '
        Me.txt取込ファイル.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt取込ファイル.Format = "9"
        Me.txt取込ファイル.Location = New System.Drawing.Point(120, 10)
        Me.txt取込ファイル.MaxLength = 13
        Me.txt取込ファイル.Name = "txt取込ファイル"
        Me.txt取込ファイル.Size = New System.Drawing.Size(471, 24)
        Me.txt取込ファイル.TabIndex = 11
        Me.txt取込ファイル.Tag = "ID1"
        '
        'GcTabCtrl
        '
        Me.GcTabCtrl.Appearance = GrapeCity.Win.Containers.TabAppearance.CutLeftCorner
        Me.GcTabCtrl.Flat = True
        Me.GcTabCtrl.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GcTabCtrl.Location = New System.Drawing.Point(25, 117)
        Me.GcTabCtrl.Name = "GcTabCtrl"
        Me.GcTabCtrl.ShowFocus = False
        Me.GcTabCtrl.Size = New System.Drawing.Size(1210, 770)
        Me.GcTabCtrl.SizeMode = GrapeCity.Win.Containers.TabSizeMode.Fixed
        Me.GcTabCtrl.TabIndex = 186
        Me.GcTabCtrl.TabPages.Add(Me.Tab未処理)
        Me.GcTabCtrl.TabPages.Add(Me.Tab未出力)
        Me.GcTabCtrl.TabPages.Add(Me.Tab履歴)
        Me.GcTabCtrl.TabStyle = New GrapeCity.Win.Containers.TabStyle(System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, Nothing, GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Common.TextHAlign.NotSet, GrapeCity.Win.Common.TextVAlign.NotSet, GrapeCity.Win.Common.ImageAlign.NotSet, GrapeCity.Win.Common.TextWrapMode.NotSet, GrapeCity.Win.Common.EllipsisMode.None, Nothing, Nothing, New GrapeCity.Win.Common.Margins(0, 0, 0, 0), New System.Drawing.Size(150, 30), New System.Drawing.Size(0, 0))
        Me.GcTabCtrl.TextOrientation = GrapeCity.Win.Common.TextOrientation.Horizontal
        Me.GcTabCtrl.TransparentBackground = True
        '
        'Tab未処理
        '
        Me.Tab未処理.Controls.Add(Me.tab未処理btn06)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn05)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn04)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn03)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn10)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn02)
        Me.Tab未処理.Controls.Add(Me.tab未処理btn01)
        Me.Tab未処理.Controls.Add(Me.gcmr未処理)
        Me.Tab未処理.Location = New System.Drawing.Point(4, 33)
        Me.Tab未処理.Name = "Tab未処理"
        Me.Tab未処理.Size = New System.Drawing.Size(1202, 733)
        Me.Tab未処理.TabIndex = 0
        Me.Tab未処理.Text = "突合未処理"
        Me.Tab未処理.UseVisualStyleBackColor = True
        '
        'tab未処理btn06
        '
        Me.tab未処理btn06.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn06.Enabled = False
        Me.tab未処理btn06.Location = New System.Drawing.Point(709, 695)
        Me.tab未処理btn06.Name = "tab未処理btn06"
        Me.tab未処理btn06.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn06.TabIndex = 25
        Me.tab未処理btn06.Tag = "ID1"
        Me.tab未処理btn06.UseVisualStyleBackColor = False
        '
        'tab未処理btn05
        '
        Me.tab未処理btn05.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn05.Enabled = False
        Me.tab未処理btn05.Location = New System.Drawing.Point(569, 695)
        Me.tab未処理btn05.Name = "tab未処理btn05"
        Me.tab未処理btn05.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn05.TabIndex = 24
        Me.tab未処理btn05.Tag = "ID1"
        Me.tab未処理btn05.UseVisualStyleBackColor = False
        '
        'tab未処理btn04
        '
        Me.tab未処理btn04.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn04.Enabled = False
        Me.tab未処理btn04.Location = New System.Drawing.Point(429, 695)
        Me.tab未処理btn04.Name = "tab未処理btn04"
        Me.tab未処理btn04.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn04.TabIndex = 23
        Me.tab未処理btn04.Tag = "ID1"
        Me.tab未処理btn04.UseVisualStyleBackColor = False
        '
        'tab未処理btn03
        '
        Me.tab未処理btn03.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn03.Location = New System.Drawing.Point(289, 695)
        Me.tab未処理btn03.Name = "tab未処理btn03"
        Me.tab未処理btn03.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn03.TabIndex = 22
        Me.tab未処理btn03.Tag = "ID1"
        Me.tab未処理btn03.Text = "エラー"
        Me.tab未処理btn03.UseVisualStyleBackColor = False
        '
        'tab未処理btn10
        '
        Me.tab未処理btn10.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn10.Location = New System.Drawing.Point(1056, 695)
        Me.tab未処理btn10.Name = "tab未処理btn10"
        Me.tab未処理btn10.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn10.TabIndex = 21
        Me.tab未処理btn10.Tag = "ID1"
        Me.tab未処理btn10.Text = "削除"
        Me.tab未処理btn10.UseVisualStyleBackColor = False
        '
        'tab未処理btn02
        '
        Me.tab未処理btn02.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn02.Location = New System.Drawing.Point(149, 695)
        Me.tab未処理btn02.Name = "tab未処理btn02"
        Me.tab未処理btn02.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn02.TabIndex = 20
        Me.tab未処理btn02.Tag = "ID1"
        Me.tab未処理btn02.Text = "手動"
        Me.tab未処理btn02.UseVisualStyleBackColor = False
        '
        'tab未処理btn01
        '
        Me.tab未処理btn01.BackColor = System.Drawing.SystemColors.Control
        Me.tab未処理btn01.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab未処理btn01.Location = New System.Drawing.Point(9, 695)
        Me.tab未処理btn01.Name = "tab未処理btn01"
        Me.tab未処理btn01.Size = New System.Drawing.Size(140, 26)
        Me.tab未処理btn01.TabIndex = 19
        Me.tab未処理btn01.Tag = "ID1"
        Me.tab未処理btn01.Text = "突合"
        Me.tab未処理btn01.UseVisualStyleBackColor = False
        '
        'gcmr未処理
        '
        Me.gcmr未処理.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcmr未処理.Location = New System.Drawing.Point(3, 3)
        Me.gcmr未処理.Name = "gcmr未処理"
        Me.gcmr未処理.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcmr未処理.Size = New System.Drawing.Size(1196, 680)
        Me.gcmr未処理.TabIndex = 0
        Me.gcmr未処理.Text = "gcmr未処理"
        '
        'Tab未出力
        '
        Me.Tab未出力.Controls.Add(Me.tab未出力btn06)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn05)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn03)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn02)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn10)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn04)
        Me.Tab未出力.Controls.Add(Me.tab未出力btn01)
        Me.Tab未出力.Controls.Add(Me.gcmr未出力)
        Me.Tab未出力.Location = New System.Drawing.Point(4, 33)
        Me.Tab未出力.Name = "Tab未出力"
        Me.Tab未出力.Size = New System.Drawing.Size(1202, 733)
        Me.Tab未出力.TabIndex = 1
        Me.Tab未出力.Text = "連携ファイル未出力"
        Me.Tab未出力.UseVisualStyleBackColor = True
        '
        'tab未出力btn06
        '
        Me.tab未出力btn06.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn06.Enabled = False
        Me.tab未出力btn06.Location = New System.Drawing.Point(709, 695)
        Me.tab未出力btn06.Name = "tab未出力btn06"
        Me.tab未出力btn06.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn06.TabIndex = 28
        Me.tab未出力btn06.Tag = "ID1"
        Me.tab未出力btn06.UseVisualStyleBackColor = False
        '
        'tab未出力btn05
        '
        Me.tab未出力btn05.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn05.Location = New System.Drawing.Point(569, 695)
        Me.tab未出力btn05.Name = "tab未出力btn05"
        Me.tab未出力btn05.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn05.TabIndex = 27
        Me.tab未出力btn05.Tag = "ID1"
        Me.tab未出力btn05.Text = "データ更新"
        Me.tab未出力btn05.UseVisualStyleBackColor = False
        '
        'tab未出力btn03
        '
        Me.tab未出力btn03.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn03.Location = New System.Drawing.Point(289, 695)
        Me.tab未出力btn03.Name = "tab未出力btn03"
        Me.tab未出力btn03.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn03.TabIndex = 26
        Me.tab未出力btn03.Tag = "ID1"
        Me.tab未出力btn03.Text = "全解除"
        Me.tab未出力btn03.UseVisualStyleBackColor = False
        '
        'tab未出力btn02
        '
        Me.tab未出力btn02.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn02.Location = New System.Drawing.Point(149, 695)
        Me.tab未出力btn02.Name = "tab未出力btn02"
        Me.tab未出力btn02.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn02.TabIndex = 25
        Me.tab未出力btn02.Tag = "ID1"
        Me.tab未出力btn02.Text = "全選択"
        Me.tab未出力btn02.UseVisualStyleBackColor = False
        '
        'tab未出力btn10
        '
        Me.tab未出力btn10.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn10.Location = New System.Drawing.Point(1056, 695)
        Me.tab未出力btn10.Name = "tab未出力btn10"
        Me.tab未出力btn10.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn10.TabIndex = 24
        Me.tab未出力btn10.Tag = "ID1"
        Me.tab未出力btn10.Text = "削除"
        Me.tab未出力btn10.UseVisualStyleBackColor = False
        '
        'tab未出力btn04
        '
        Me.tab未出力btn04.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn04.Enabled = False
        Me.tab未出力btn04.Location = New System.Drawing.Point(429, 695)
        Me.tab未出力btn04.Name = "tab未出力btn04"
        Me.tab未出力btn04.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn04.TabIndex = 23
        Me.tab未出力btn04.Tag = "ID1"
        Me.tab未出力btn04.UseVisualStyleBackColor = False
        '
        'tab未出力btn01
        '
        Me.tab未出力btn01.BackColor = System.Drawing.SystemColors.Control
        Me.tab未出力btn01.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab未出力btn01.Location = New System.Drawing.Point(9, 695)
        Me.tab未出力btn01.Name = "tab未出力btn01"
        Me.tab未出力btn01.Size = New System.Drawing.Size(140, 26)
        Me.tab未出力btn01.TabIndex = 22
        Me.tab未出力btn01.Tag = "ID1"
        Me.tab未出力btn01.Text = "連携ファイル出力"
        Me.tab未出力btn01.UseVisualStyleBackColor = False
        '
        'gcmr未出力
        '
        Me.gcmr未出力.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcmr未出力.Location = New System.Drawing.Point(3, 3)
        Me.gcmr未出力.Name = "gcmr未出力"
        Me.gcmr未出力.Size = New System.Drawing.Size(1196, 680)
        Me.gcmr未出力.SplitMode = GrapeCity.Win.MultiRow.SplitMode.Vertical
        Me.gcmr未出力.TabIndex = 0
        Me.gcmr未出力.Text = "gcmr未出力"
        '
        'Tab履歴
        '
        Me.Tab履歴.Controls.Add(Me.tab履歴btn06)
        Me.Tab履歴.Controls.Add(Me.tab履歴btn05)
        Me.Tab履歴.Controls.Add(Me.tab履歴btn04)
        Me.Tab履歴.Controls.Add(Me.tab履歴btn03)
        Me.Tab履歴.Controls.Add(Me.tab履歴btn02)
        Me.Tab履歴.Controls.Add(Me.tab履歴btn01)
        Me.Tab履歴.Controls.Add(Me.gcmr履歴)
        Me.Tab履歴.Controls.Add(Me.pnl履歴検索)
        Me.Tab履歴.Location = New System.Drawing.Point(4, 33)
        Me.Tab履歴.Name = "Tab履歴"
        Me.Tab履歴.Size = New System.Drawing.Size(1202, 733)
        Me.Tab履歴.TabIndex = 2
        Me.Tab履歴.Text = "履歴"
        Me.Tab履歴.UseVisualStyleBackColor = True
        '
        'tab履歴btn06
        '
        Me.tab履歴btn06.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn06.Enabled = False
        Me.tab履歴btn06.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn06.Location = New System.Drawing.Point(709, 695)
        Me.tab履歴btn06.Name = "tab履歴btn06"
        Me.tab履歴btn06.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn06.TabIndex = 193
        Me.tab履歴btn06.Tag = "ID1"
        Me.tab履歴btn06.UseVisualStyleBackColor = False
        '
        'tab履歴btn05
        '
        Me.tab履歴btn05.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn05.Enabled = False
        Me.tab履歴btn05.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn05.Location = New System.Drawing.Point(569, 695)
        Me.tab履歴btn05.Name = "tab履歴btn05"
        Me.tab履歴btn05.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn05.TabIndex = 192
        Me.tab履歴btn05.Tag = "ID1"
        Me.tab履歴btn05.UseVisualStyleBackColor = False
        '
        'tab履歴btn04
        '
        Me.tab履歴btn04.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn04.Enabled = False
        Me.tab履歴btn04.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn04.Location = New System.Drawing.Point(429, 695)
        Me.tab履歴btn04.Name = "tab履歴btn04"
        Me.tab履歴btn04.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn04.TabIndex = 191
        Me.tab履歴btn04.Tag = "ID1"
        Me.tab履歴btn04.UseVisualStyleBackColor = False
        '
        'tab履歴btn03
        '
        Me.tab履歴btn03.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn03.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn03.Location = New System.Drawing.Point(289, 695)
        Me.tab履歴btn03.Name = "tab履歴btn03"
        Me.tab履歴btn03.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn03.TabIndex = 190
        Me.tab履歴btn03.Tag = "ID1"
        Me.tab履歴btn03.Text = "全解除"
        Me.tab履歴btn03.UseVisualStyleBackColor = False
        '
        'tab履歴btn02
        '
        Me.tab履歴btn02.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn02.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn02.Location = New System.Drawing.Point(149, 695)
        Me.tab履歴btn02.Name = "tab履歴btn02"
        Me.tab履歴btn02.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn02.TabIndex = 189
        Me.tab履歴btn02.Tag = "ID1"
        Me.tab履歴btn02.Text = "全選択"
        Me.tab履歴btn02.UseVisualStyleBackColor = False
        '
        'tab履歴btn01
        '
        Me.tab履歴btn01.BackColor = System.Drawing.SystemColors.Control
        Me.tab履歴btn01.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tab履歴btn01.Location = New System.Drawing.Point(9, 695)
        Me.tab履歴btn01.Name = "tab履歴btn01"
        Me.tab履歴btn01.Size = New System.Drawing.Size(140, 26)
        Me.tab履歴btn01.TabIndex = 188
        Me.tab履歴btn01.Tag = "ID1"
        Me.tab履歴btn01.Text = "連携ファイル出力"
        Me.tab履歴btn01.UseVisualStyleBackColor = False
        '
        'gcmr履歴
        '
        Me.gcmr履歴.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcmr履歴.Location = New System.Drawing.Point(3, 129)
        Me.gcmr履歴.Name = "gcmr履歴"
        Me.gcmr履歴.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcmr履歴.Size = New System.Drawing.Size(1196, 554)
        Me.gcmr履歴.TabIndex = 187
        Me.gcmr履歴.Text = "gcmr履歴"
        '
        'pnl履歴検索
        '
        Me.pnl履歴検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl履歴検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl履歴検索.Controls.Add(Me.btn履歴検索)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴規格)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴商品名)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴メーカ品番)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴メーカ名)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴商品コード)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴項目名5)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴項目名4)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴項目名3)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴需要先コード)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴需要先名)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴得意先コード)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴得意先名)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴期間2)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴出力終了日)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴出力開始日)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴項目名2)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴期間1)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴取込終了日)
        Me.pnl履歴検索.Controls.Add(Me.txt履歴取込開始日)
        Me.pnl履歴検索.Controls.Add(Me.lbl履歴項目名1)
        Me.pnl履歴検索.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl履歴検索.Location = New System.Drawing.Point(3, 3)
        Me.pnl履歴検索.Name = "pnl履歴検索"
        Me.pnl履歴検索.Size = New System.Drawing.Size(1196, 126)
        Me.pnl履歴検索.TabIndex = 186
        '
        'btn履歴検索
        '
        Me.btn履歴検索.BackColor = System.Drawing.SystemColors.Control
        Me.btn履歴検索.Location = New System.Drawing.Point(1088, 89)
        Me.btn履歴検索.Name = "btn履歴検索"
        Me.btn履歴検索.Size = New System.Drawing.Size(90, 26)
        Me.btn履歴検索.TabIndex = 211
        Me.btn履歴検索.Tag = "ID1"
        Me.btn履歴検索.Text = "検索(&R)"
        Me.btn履歴検索.UseVisualStyleBackColor = False
        '
        'lbl履歴規格
        '
        Me.lbl履歴規格.AutoEllipsis = True
        Me.lbl履歴規格.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴規格.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴規格.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴規格.Location = New System.Drawing.Point(983, 34)
        Me.lbl履歴規格.Name = "lbl履歴規格"
        Me.lbl履歴規格.Size = New System.Drawing.Size(190, 24)
        Me.lbl履歴規格.TabIndex = 210
        Me.lbl履歴規格.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴商品名
        '
        Me.lbl履歴商品名.AutoEllipsis = True
        Me.lbl履歴商品名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴商品名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴商品名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴商品名.Location = New System.Drawing.Point(790, 34)
        Me.lbl履歴商品名.Name = "lbl履歴商品名"
        Me.lbl履歴商品名.Size = New System.Drawing.Size(190, 24)
        Me.lbl履歴商品名.TabIndex = 209
        Me.lbl履歴商品名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴メーカ品番
        '
        Me.lbl履歴メーカ品番.AutoEllipsis = True
        Me.lbl履歴メーカ品番.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴メーカ品番.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴メーカ品番.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴メーカ品番.Location = New System.Drawing.Point(597, 34)
        Me.lbl履歴メーカ品番.Name = "lbl履歴メーカ品番"
        Me.lbl履歴メーカ品番.Size = New System.Drawing.Size(190, 24)
        Me.lbl履歴メーカ品番.TabIndex = 208
        Me.lbl履歴メーカ品番.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴メーカ名
        '
        Me.lbl履歴メーカ名.AutoEllipsis = True
        Me.lbl履歴メーカ名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴メーカ名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴メーカ名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴メーカ名.Location = New System.Drawing.Point(692, 8)
        Me.lbl履歴メーカ名.Name = "lbl履歴メーカ名"
        Me.lbl履歴メーカ名.Size = New System.Drawing.Size(219, 24)
        Me.lbl履歴メーカ名.TabIndex = 207
        Me.lbl履歴メーカ名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt履歴商品コード
        '
        Me.txt履歴商品コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt履歴商品コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴商品コード.Format = "9"
        Me.txt履歴商品コード.HighlightText = True
        Me.txt履歴商品コード.Location = New System.Drawing.Point(597, 8)
        Me.txt履歴商品コード.MaxLength = 10
        Me.txt履歴商品コード.Name = "txt履歴商品コード"
        Me.txt履歴商品コード.Size = New System.Drawing.Size(93, 24)
        Me.txt履歴商品コード.TabIndex = 206
        Me.txt履歴商品コード.Tag = "ID1"
        '
        'lbl履歴項目名5
        '
        Me.lbl履歴項目名5.AutoSize = True
        Me.lbl履歴項目名5.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴項目名5.Location = New System.Drawing.Point(519, 10)
        Me.lbl履歴項目名5.Name = "lbl履歴項目名5"
        Me.lbl履歴項目名5.Size = New System.Drawing.Size(61, 20)
        Me.lbl履歴項目名5.TabIndex = 205
        Me.lbl履歴項目名5.Text = "【商品】"
        Me.lbl履歴項目名5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴項目名4
        '
        Me.lbl履歴項目名4.AutoSize = True
        Me.lbl履歴項目名4.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴項目名4.Location = New System.Drawing.Point(11, 91)
        Me.lbl履歴項目名4.Name = "lbl履歴項目名4"
        Me.lbl履歴項目名4.Size = New System.Drawing.Size(74, 20)
        Me.lbl履歴項目名4.TabIndex = 204
        Me.lbl履歴項目名4.Text = "【需要先】"
        Me.lbl履歴項目名4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴項目名3
        '
        Me.lbl履歴項目名3.AutoSize = True
        Me.lbl履歴項目名3.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴項目名3.Location = New System.Drawing.Point(11, 64)
        Me.lbl履歴項目名3.Name = "lbl履歴項目名3"
        Me.lbl履歴項目名3.Size = New System.Drawing.Size(74, 20)
        Me.lbl履歴項目名3.TabIndex = 203
        Me.lbl履歴項目名3.Text = "【得意先】"
        Me.lbl履歴項目名3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt履歴需要先コード
        '
        Me.txt履歴需要先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt履歴需要先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴需要先コード.Format = "9"
        Me.txt履歴需要先コード.HighlightText = True
        Me.txt履歴需要先コード.Location = New System.Drawing.Point(103, 89)
        Me.txt履歴需要先コード.MaxLength = 10
        Me.txt履歴需要先コード.Name = "txt履歴需要先コード"
        Me.txt履歴需要先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt履歴需要先コード.TabIndex = 201
        Me.txt履歴需要先コード.Tag = "ID1"
        '
        'lbl履歴需要先名
        '
        Me.lbl履歴需要先名.AutoEllipsis = True
        Me.lbl履歴需要先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴需要先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴需要先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴需要先名.Location = New System.Drawing.Point(198, 89)
        Me.lbl履歴需要先名.Name = "lbl履歴需要先名"
        Me.lbl履歴需要先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl履歴需要先名.TabIndex = 202
        Me.lbl履歴需要先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt履歴得意先コード
        '
        Me.txt履歴得意先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt履歴得意先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴得意先コード.Format = "9"
        Me.txt履歴得意先コード.HighlightText = True
        Me.txt履歴得意先コード.Location = New System.Drawing.Point(103, 62)
        Me.txt履歴得意先コード.MaxLength = 10
        Me.txt履歴得意先コード.Name = "txt履歴得意先コード"
        Me.txt履歴得意先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt履歴得意先コード.TabIndex = 199
        Me.txt履歴得意先コード.Tag = "ID1"
        '
        'lbl履歴得意先名
        '
        Me.lbl履歴得意先名.AutoEllipsis = True
        Me.lbl履歴得意先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl履歴得意先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl履歴得意先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴得意先名.Location = New System.Drawing.Point(198, 62)
        Me.lbl履歴得意先名.Name = "lbl履歴得意先名"
        Me.lbl履歴得意先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl履歴得意先名.TabIndex = 200
        Me.lbl履歴得意先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴期間2
        '
        Me.lbl履歴期間2.AutoSize = True
        Me.lbl履歴期間2.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴期間2.Location = New System.Drawing.Point(231, 37)
        Me.lbl履歴期間2.Name = "lbl履歴期間2"
        Me.lbl履歴期間2.Size = New System.Drawing.Size(22, 20)
        Me.lbl履歴期間2.TabIndex = 198
        Me.lbl履歴期間2.Text = "～"
        Me.lbl履歴期間2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt履歴出力終了日
        '
        Me.txt履歴出力終了日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.txt履歴出力終了日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.txt履歴出力終了日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴出力終了日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt履歴出力終了日.Location = New System.Drawing.Point(261, 34)
        Me.txt履歴出力終了日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴出力終了日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴出力終了日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴出力終了日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴出力終了日.Name = "txt履歴出力終了日"
        Me.txt履歴出力終了日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.txt履歴出力終了日.Size = New System.Drawing.Size(118, 26)
        Me.txt履歴出力終了日.TabIndex = 197
        Me.txt履歴出力終了日.Tag = ""
        Me.txt履歴出力終了日.Value = Nothing
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'txt履歴出力開始日
        '
        Me.txt履歴出力開始日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField3.Text = "/"
        DateLiteralField4.Text = "/"
        Me.txt履歴出力開始日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField2, DateLiteralField3, DateMonthField2, DateLiteralField4, DateDayField2})
        Me.txt履歴出力開始日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴出力開始日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt履歴出力開始日.Location = New System.Drawing.Point(103, 34)
        Me.txt履歴出力開始日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴出力開始日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴出力開始日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴出力開始日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴出力開始日.Name = "txt履歴出力開始日"
        Me.txt履歴出力開始日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.txt履歴出力開始日.Size = New System.Drawing.Size(118, 26)
        Me.txt履歴出力開始日.TabIndex = 196
        Me.txt履歴出力開始日.Tag = ""
        Me.txt履歴出力開始日.Value = Nothing
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'lbl履歴項目名2
        '
        Me.lbl履歴項目名2.AutoSize = True
        Me.lbl履歴項目名2.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴項目名2.Location = New System.Drawing.Point(11, 37)
        Me.lbl履歴項目名2.Name = "lbl履歴項目名2"
        Me.lbl履歴項目名2.Size = New System.Drawing.Size(74, 20)
        Me.lbl履歴項目名2.TabIndex = 195
        Me.lbl履歴項目名2.Text = "【出力日】"
        Me.lbl履歴項目名2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl履歴期間1
        '
        Me.lbl履歴期間1.AutoSize = True
        Me.lbl履歴期間1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴期間1.Location = New System.Drawing.Point(231, 10)
        Me.lbl履歴期間1.Name = "lbl履歴期間1"
        Me.lbl履歴期間1.Size = New System.Drawing.Size(22, 20)
        Me.lbl履歴期間1.TabIndex = 194
        Me.lbl履歴期間1.Text = "～"
        Me.lbl履歴期間1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt履歴取込終了日
        '
        Me.txt履歴取込終了日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.txt履歴取込終了日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField3, DateLiteralField5, DateMonthField3, DateLiteralField6, DateDayField3})
        Me.txt履歴取込終了日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴取込終了日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt履歴取込終了日.Location = New System.Drawing.Point(261, 7)
        Me.txt履歴取込終了日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴取込終了日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴取込終了日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴取込終了日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴取込終了日.Name = "txt履歴取込終了日"
        Me.txt履歴取込終了日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.txt履歴取込終了日.Size = New System.Drawing.Size(118, 26)
        Me.txt履歴取込終了日.TabIndex = 192
        Me.txt履歴取込終了日.Tag = ""
        Me.txt履歴取込終了日.Value = Nothing
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'txt履歴取込開始日
        '
        Me.txt履歴取込開始日.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField7.Text = "/"
        DateLiteralField8.Text = "/"
        Me.txt履歴取込開始日.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField4, DateLiteralField7, DateMonthField4, DateLiteralField8, DateDayField4})
        Me.txt履歴取込開始日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt履歴取込開始日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt履歴取込開始日.Location = New System.Drawing.Point(103, 7)
        Me.txt履歴取込開始日.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴取込開始日.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt履歴取込開始日.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴取込開始日.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt履歴取込開始日.Name = "txt履歴取込開始日"
        Me.txt履歴取込開始日.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.txt履歴取込開始日.Size = New System.Drawing.Size(118, 26)
        Me.txt履歴取込開始日.TabIndex = 191
        Me.txt履歴取込開始日.Tag = ""
        Me.txt履歴取込開始日.Value = Nothing
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl履歴項目名1
        '
        Me.lbl履歴項目名1.AutoSize = True
        Me.lbl履歴項目名1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl履歴項目名1.Location = New System.Drawing.Point(11, 10)
        Me.lbl履歴項目名1.Name = "lbl履歴項目名1"
        Me.lbl履歴項目名1.Size = New System.Drawing.Size(74, 20)
        Me.lbl履歴項目名1.TabIndex = 193
        Me.lbl履歴項目名1.Text = "【取込日】"
        Me.lbl履歴項目名1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HARK202DS
        '
        Me.HARK202DS.DataSetName = "HARK202DS"
        Me.HARK202DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BS未処理
        '
        Me.BS未処理.DataMember = "ds未処理"
        Me.BS未処理.DataSource = Me.HARK202DS
        '
        'BS未出力
        '
        Me.BS未出力.DataMember = "ds未出力"
        Me.BS未出力.DataSource = Me.HARK202DS
        '
        'BS履歴
        '
        Me.BS履歴.DataMember = "ds履歴"
        Me.BS履歴.DataSource = Me.HARK202DS
        '
        'HARK202
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1260, 917)
        Me.Controls.Add(Me.GcTabCtrl)
        Me.Controls.Add(Me.pnl検索)
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
        Me.Name = "HARK202"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GcTabCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GcTabCtrl.ResumeLayout(False)
        Me.Tab未処理.ResumeLayout(False)
        CType(Me.gcmr未処理, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab未出力.ResumeLayout(False)
        CType(Me.gcmr未出力, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab履歴.ResumeLayout(False)
        CType(Me.gcmr履歴, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl履歴検索.ResumeLayout(False)
        Me.pnl履歴検索.PerformLayout()
        CType(Me.txt履歴商品コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴需要先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴得意先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴出力終了日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴出力開始日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴取込終了日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt履歴取込開始日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK202DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS未処理, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS未出力, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS履歴, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents pnl検索 As Panel
    Private WithEvents lbl取込ファイル As Label
    Private WithEvents txt取込ファイル As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents GcTabCtrl As GrapeCity.Win.Containers.GcTabControl
    Private WithEvents Tab未処理 As GrapeCity.Win.Containers.GcTabPage
    Private WithEvents Tab未出力 As GrapeCity.Win.Containers.GcTabPage
    Private WithEvents Tab履歴 As GrapeCity.Win.Containers.GcTabPage
    Private WithEvents btnファイル参照 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents gcmr未処理 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents gcmr未出力 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents gcmr履歴 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents pnl履歴検索 As Panel
    Private WithEvents tab未処理btn10 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn10 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn06 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未出力btn02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn06 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab未処理btn03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn06 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents tab履歴btn01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents lbl履歴期間2 As Label
    Private WithEvents txt履歴出力終了日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents txt履歴出力開始日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl履歴項目名2 As Label
    Private WithEvents lbl履歴期間1 As Label
    Private WithEvents txt履歴取込終了日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents txt履歴取込開始日 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl履歴項目名1 As Label
    Private WithEvents lbl履歴項目名4 As Label
    Private WithEvents lbl履歴項目名3 As Label
    Private WithEvents txt履歴需要先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl履歴需要先名 As Label
    Private WithEvents txt履歴得意先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl履歴得意先名 As Label
    Private WithEvents lbl履歴規格 As Label
    Private WithEvents lbl履歴商品名 As Label
    Private WithEvents lbl履歴メーカ品番 As Label
    Private WithEvents lbl履歴メーカ名 As Label
    Private WithEvents txt履歴商品コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl履歴項目名5 As Label
    Private WithEvents btn履歴検索 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents HARK202DS As HARK202DS
    Private WithEvents BS未処理 As BindingSource
    Private WithEvents BS未出力 As BindingSource
    Private WithEvents BS履歴 As BindingSource
    Private WithEvents SaveFileDlg As SaveFileDialog

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

        xxxmForm = PerForm
        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = 0

        'KeyDownイベントハンドラの追加
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


End Class
