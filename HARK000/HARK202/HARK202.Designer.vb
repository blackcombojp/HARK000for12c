﻿'/*-----------------------------------------------------------------------------
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
        Dim CellStyle1 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK202))
        Me.cmb事業所 = New System.Windows.Forms.ComboBox()
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.lb_Msg = New GrapeCity.Win.Editors.GcListBox()
        Me.btnフォルダ参照 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnファイル参照 = New GrapeCity.Win.Buttons.GcButton()
        Me.txt取込ファイル = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.txtデータ出力先 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl取込ファイル = New System.Windows.Forms.Label()
        Me.lblエラーデータ出力先 = New System.Windows.Forms.Label()
        Me.pnl操作 = New System.Windows.Forms.Panel()
        Me.BS一覧 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HARK202DS = New HARK000.HARK202DS()
        Me.lbl部署 = New System.Windows.Forms.Label()
        Me.btn全解除 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn全選択 = New GrapeCity.Win.Buttons.GcButton()
        Me.cmb棚卸 = New System.Windows.Forms.ComboBox()
        Me.lbl棚卸 = New System.Windows.Forms.Label()
        Me.cmb需要先 = New System.Windows.Forms.ComboBox()
        Me.lbl需要先 = New System.Windows.Forms.Label()
        Me.txtDate = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl棚卸日 = New System.Windows.Forms.Label()
        Me.cmbサブプログラム = New System.Windows.Forms.ComboBox()
        Me.lblサブプログラム = New System.Windows.Forms.Label()
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
        Me.gcmr一覧 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.HARK202Template1 = New HARK000.HARK202Template()
        Me.CntMenuStrip.SuspendLayout()
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtデータ出力先, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl操作.SuspendLayout()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK202DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BT_ID4.Location = New System.Drawing.Point(270, 0)
        Me.BT_ID4.Name = "BT_ID4"
        Me.BT_ID4.Size = New System.Drawing.Size(90, 24)
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
        'btnフォルダ参照
        '
        Me.btnフォルダ参照.BackColor = System.Drawing.SystemColors.Control
        Me.btnフォルダ参照.Location = New System.Drawing.Point(402, 462)
        Me.btnフォルダ参照.Name = "btnフォルダ参照"
        Me.btnフォルダ参照.Size = New System.Drawing.Size(60, 23)
        Me.btnフォルダ参照.TabIndex = 17
        Me.btnフォルダ参照.TabStop = False
        Me.btnフォルダ参照.Tag = "ID1"
        Me.btnフォルダ参照.Text = "参照"
        Me.btnフォルダ参照.UseVisualStyleBackColor = False
        '
        'btnファイル参照
        '
        Me.btnファイル参照.BackColor = System.Drawing.SystemColors.Control
        Me.btnファイル参照.Location = New System.Drawing.Point(403, 406)
        Me.btnファイル参照.Name = "btnファイル参照"
        Me.btnファイル参照.Size = New System.Drawing.Size(60, 23)
        Me.btnファイル参照.TabIndex = 15
        Me.btnファイル参照.TabStop = False
        Me.btnファイル参照.Tag = "ID1"
        Me.btnファイル参照.Text = "参照"
        Me.btnファイル参照.UseVisualStyleBackColor = False
        '
        'txt取込ファイル
        '
        Me.txt取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt取込ファイル.Location = New System.Drawing.Point(12, 405)
        Me.txt取込ファイル.Name = "txt取込ファイル"
        Me.txt取込ファイル.Size = New System.Drawing.Size(382, 24)
        Me.txt取込ファイル.TabIndex = 16
        Me.txt取込ファイル.Tag = "ID1"
        '
        'txtデータ出力先
        '
        Me.txtデータ出力先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtデータ出力先.Location = New System.Drawing.Point(12, 461)
        Me.txtデータ出力先.Name = "txtデータ出力先"
        Me.txtデータ出力先.Size = New System.Drawing.Size(382, 24)
        Me.txtデータ出力先.TabIndex = 17
        Me.txtデータ出力先.Tag = "ID2"
        '
        'lbl取込ファイル
        '
        Me.lbl取込ファイル.AutoSize = True
        Me.lbl取込ファイル.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl取込ファイル.Location = New System.Drawing.Point(12, 382)
        Me.lbl取込ファイル.Name = "lbl取込ファイル"
        Me.lbl取込ファイル.Size = New System.Drawing.Size(113, 20)
        Me.lbl取込ファイル.TabIndex = 166
        Me.lbl取込ファイル.Text = "【取込ファイル】"
        Me.lbl取込ファイル.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblエラーデータ出力先
        '
        Me.lblエラーデータ出力先.AutoSize = True
        Me.lblエラーデータ出力先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblエラーデータ出力先.Location = New System.Drawing.Point(12, 438)
        Me.lblエラーデータ出力先.Name = "lblエラーデータ出力先"
        Me.lblエラーデータ出力先.Size = New System.Drawing.Size(113, 20)
        Me.lblエラーデータ出力先.TabIndex = 165
        Me.lblエラーデータ出力先.Text = "【データ出力先】"
        Me.lblエラーデータ出力先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnl操作
        '
        Me.pnl操作.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnl操作.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl操作.Controls.Add(Me.gcmr一覧)
        Me.pnl操作.Controls.Add(Me.lbl部署)
        Me.pnl操作.Controls.Add(Me.btn全解除)
        Me.pnl操作.Controls.Add(Me.btn全選択)
        Me.pnl操作.Controls.Add(Me.cmb棚卸)
        Me.pnl操作.Controls.Add(Me.lbl棚卸)
        Me.pnl操作.Controls.Add(Me.cmb需要先)
        Me.pnl操作.Controls.Add(Me.lbl需要先)
        Me.pnl操作.Controls.Add(Me.txtDate)
        Me.pnl操作.Controls.Add(Me.lbl棚卸日)
        Me.pnl操作.Controls.Add(Me.cmbサブプログラム)
        Me.pnl操作.Controls.Add(Me.lblサブプログラム)
        Me.pnl操作.Controls.Add(Me.btnフォルダ参照)
        Me.pnl操作.Controls.Add(Me.btnファイル参照)
        Me.pnl操作.Controls.Add(Me.txt取込ファイル)
        Me.pnl操作.Controls.Add(Me.txtデータ出力先)
        Me.pnl操作.Controls.Add(Me.lbl取込ファイル)
        Me.pnl操作.Controls.Add(Me.lblエラーデータ出力先)
        Me.pnl操作.Location = New System.Drawing.Point(25, 60)
        Me.pnl操作.Name = "pnl操作"
        Me.pnl操作.Size = New System.Drawing.Size(475, 614)
        Me.pnl操作.TabIndex = 183
        '
        'BS一覧
        '
        Me.BS一覧.DataMember = "ds一覧"
        Me.BS一覧.DataSource = Me.HARK202DS
        '
        'HARK202DS
        '
        Me.HARK202DS.DataSetName = "HARK202DS"
        Me.HARK202DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbl部署
        '
        Me.lbl部署.AutoSize = True
        Me.lbl部署.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl部署.Location = New System.Drawing.Point(12, 184)
        Me.lbl部署.Name = "lbl部署"
        Me.lbl部署.Size = New System.Drawing.Size(61, 20)
        Me.lbl部署.TabIndex = 177
        Me.lbl部署.Text = "【部署】"
        Me.lbl部署.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn全解除
        '
        Me.btn全解除.BackColor = System.Drawing.SystemColors.Control
        Me.btn全解除.Location = New System.Drawing.Point(306, 294)
        Me.btn全解除.Name = "btn全解除"
        Me.btn全解除.Size = New System.Drawing.Size(88, 23)
        Me.btn全解除.TabIndex = 176
        Me.btn全解除.TabStop = False
        Me.btn全解除.Tag = "ID2"
        Me.btn全解除.Text = "全解除"
        Me.btn全解除.UseVisualStyleBackColor = False
        '
        'btn全選択
        '
        Me.btn全選択.BackColor = System.Drawing.SystemColors.Control
        Me.btn全選択.Location = New System.Drawing.Point(306, 266)
        Me.btn全選択.Name = "btn全選択"
        Me.btn全選択.Size = New System.Drawing.Size(88, 23)
        Me.btn全選択.TabIndex = 175
        Me.btn全選択.TabStop = False
        Me.btn全選択.Tag = "ID1"
        Me.btn全選択.Text = "全選択"
        Me.btn全選択.UseVisualStyleBackColor = False
        '
        'cmb棚卸
        '
        Me.cmb棚卸.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb棚卸.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb棚卸.FormattingEnabled = True
        Me.cmb棚卸.Location = New System.Drawing.Point(12, 95)
        Me.cmb棚卸.Name = "cmb棚卸"
        Me.cmb棚卸.Size = New System.Drawing.Size(382, 26)
        Me.cmb棚卸.TabIndex = 12
        Me.cmb棚卸.Tag = "ID3"
        '
        'lbl棚卸
        '
        Me.lbl棚卸.AutoSize = True
        Me.lbl棚卸.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl棚卸.Location = New System.Drawing.Point(12, 72)
        Me.lbl棚卸.Name = "lbl棚卸"
        Me.lbl棚卸.Size = New System.Drawing.Size(61, 20)
        Me.lbl棚卸.TabIndex = 174
        Me.lbl棚卸.Text = "【棚卸】"
        Me.lbl棚卸.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb需要先
        '
        Me.cmb需要先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb需要先.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb需要先.FormattingEnabled = True
        Me.cmb需要先.Location = New System.Drawing.Point(12, 151)
        Me.cmb需要先.Name = "cmb需要先"
        Me.cmb需要先.Size = New System.Drawing.Size(382, 26)
        Me.cmb需要先.TabIndex = 13
        Me.cmb需要先.Tag = "ID4"
        '
        'lbl需要先
        '
        Me.lbl需要先.AutoSize = True
        Me.lbl需要先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl需要先.Location = New System.Drawing.Point(12, 128)
        Me.lbl需要先.Name = "lbl需要先"
        Me.lbl需要先.Size = New System.Drawing.Size(74, 20)
        Me.lbl需要先.TabIndex = 171
        Me.lbl需要先.Text = "【需要先】"
        Me.lbl需要先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDate
        '
        Me.txtDate.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.txtDate.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.txtDate.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtDate.Location = New System.Drawing.Point(12, 349)
        Me.txtDate.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txtDate.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txtDate.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtDate.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.txtDate.Size = New System.Drawing.Size(118, 26)
        Me.txtDate.TabIndex = 15
        Me.txtDate.Value = Nothing
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl棚卸日
        '
        Me.lbl棚卸日.AutoSize = True
        Me.lbl棚卸日.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl棚卸日.Location = New System.Drawing.Point(12, 326)
        Me.lbl棚卸日.Name = "lbl棚卸日"
        Me.lbl棚卸日.Size = New System.Drawing.Size(74, 20)
        Me.lbl棚卸日.TabIndex = 169
        Me.lbl棚卸日.Text = "【棚卸日】"
        Me.lbl棚卸日.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbサブプログラム
        '
        Me.cmbサブプログラム.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbサブプログラム.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbサブプログラム.FormattingEnabled = True
        Me.cmbサブプログラム.Location = New System.Drawing.Point(12, 39)
        Me.cmbサブプログラム.Name = "cmbサブプログラム"
        Me.cmbサブプログラム.Size = New System.Drawing.Size(382, 26)
        Me.cmbサブプログラム.TabIndex = 11
        Me.cmbサブプログラム.Tag = "ID2"
        '
        'lblサブプログラム
        '
        Me.lblサブプログラム.AutoSize = True
        Me.lblサブプログラム.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblサブプログラム.Location = New System.Drawing.Point(12, 16)
        Me.lblサブプログラム.Name = "lblサブプログラム"
        Me.lblサブプログラム.Size = New System.Drawing.Size(126, 20)
        Me.lblサブプログラム.TabIndex = 167
        Me.lblサブプログラム.Text = "【サブプログラム】"
        Me.lblサブプログラム.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Bt_Close.Location = New System.Drawing.Point(914, 0)
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
        CellStyle2.Multiline = GrapeCity.Win.MultiRow.MultiRowTriState.[False]
        Me.gcmr一覧.AlternatingRowsDefaultHeaderCellStyle = CellStyle2
        Me.gcmr一覧.ClipboardCopyMode = GrapeCity.Win.MultiRow.ClipboardCopyMode.Disable
        Me.gcmr一覧.CurrentCellBorderLine = New GrapeCity.Win.MultiRow.Line(GrapeCity.Win.MultiRow.LineStyle.None, System.Drawing.Color.Black)
        Me.gcmr一覧.DataSource = Me.BS一覧
        Me.gcmr一覧.Location = New System.Drawing.Point(12, 207)
        Me.gcmr一覧.Name = "gcmr一覧"
        Me.gcmr一覧.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcmr一覧.Size = New System.Drawing.Size(288, 109)
        Me.gcmr一覧.SplitMode = GrapeCity.Win.MultiRow.SplitMode.None
        Me.gcmr一覧.TabIndex = 14
        Me.gcmr一覧.Template = Me.HARK202Template1
        Me.gcmr一覧.Text = "gcmr一覧"
        '
        'HARK202
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
        Me.Name = "HARK202"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt取込ファイル, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtデータ出力先, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl操作.ResumeLayout(False)
        Me.pnl操作.PerformLayout()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK202DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents cmb事業所 As ComboBox
    Private WithEvents Menu_Log As ToolStripMenuItem
    Private WithEvents CntMenuStrip As ContextMenuStrip
    Private WithEvents Menu_ErrorLog As ToolStripMenuItem
    Private WithEvents BT_ID4 As GrapeCity.Win.Buttons.GcSplitButton
    Private WithEvents lb_Msg As GrapeCity.Win.Editors.GcListBox
    Private WithEvents btnフォルダ参照 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btnファイル参照 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents txt取込ファイル As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents txtデータ出力先 As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl取込ファイル As Label
    Private WithEvents lblエラーデータ出力先 As Label
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
    Private WithEvents cmbサブプログラム As ComboBox
    Private WithEvents lblサブプログラム As Label
    Private WithEvents ExcelCreator As AdvanceSoftware.ExcelCreator.Creator
    Private WithEvents txtDate As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl棚卸日 As Label
    Private WithEvents cmb需要先 As ComboBox
    Private WithEvents lbl需要先 As Label
    Private WithEvents btn全解除 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn全選択 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents cmb棚卸 As ComboBox
    Private WithEvents lbl棚卸 As Label
    Private WithEvents lbl部署 As Label
    Private WithEvents BS一覧 As BindingSource
    Private WithEvents HARK202DS As HARK202DS
    Private WithEvents gcmr一覧 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents HARK202Template1 As HARK202Template

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxmForm As Form
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String
    Private xxxlng需要先コード As Long
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

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txt取込ファイル.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txtデータ出力先.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmbサブプログラム.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler txt取込ファイル.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmbサブプログラム.KeyDown, AddressOf Txt_KeyDown
        AddHandler txtDate.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb需要先.KeyDown, AddressOf Txt_KeyDown
        AddHandler gcmr一覧.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb棚卸.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb事業所.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmbサブプログラム.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb需要先.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

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
