﻿'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK502
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
        Dim DateYearField2 As GrapeCity.Win.Editors.Fields.DateYearField = New GrapeCity.Win.Editors.Fields.DateYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK502))
        Me.cmb事業所 = New System.Windows.Forms.ComboBox()
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.lb_Msg = New GrapeCity.Win.Editors.GcListBox()
        Me.btnフォルダ参照 = New GrapeCity.Win.Buttons.GcButton()
        Me.txtデータ出力先 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lblエラーデータ出力先 = New System.Windows.Forms.Label()
        Me.pnl操作 = New System.Windows.Forms.Panel()
        Me.lbl許可期間２ = New System.Windows.Forms.Label()
        Me.txt対象終了月 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmb医薬品区分 = New System.Windows.Forms.ComboBox()
        Me.lbl医薬品区分 = New System.Windows.Forms.Label()
        Me.txt対象開始月 = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl対象月 = New System.Windows.Forms.Label()
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
        Me.BS一覧 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HARK502DS = New HARK000.HARK502DS()
        Me.CntMenuStrip.SuspendLayout()
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtデータ出力先, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl操作.SuspendLayout()
        CType(Me.txt対象終了月, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt対象開始月, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK502DS, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnフォルダ参照.Location = New System.Drawing.Point(402, 207)
        Me.btnフォルダ参照.Name = "btnフォルダ参照"
        Me.btnフォルダ参照.Size = New System.Drawing.Size(60, 23)
        Me.btnフォルダ参照.TabIndex = 16
        Me.btnフォルダ参照.TabStop = False
        Me.btnフォルダ参照.Tag = "ID1"
        Me.btnフォルダ参照.Text = "参照"
        Me.btnフォルダ参照.UseVisualStyleBackColor = False
        '
        'txtデータ出力先
        '
        Me.txtデータ出力先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtデータ出力先.Location = New System.Drawing.Point(12, 207)
        Me.txtデータ出力先.Name = "txtデータ出力先"
        Me.txtデータ出力先.Size = New System.Drawing.Size(382, 24)
        Me.txtデータ出力先.TabIndex = 15
        Me.txtデータ出力先.Tag = "ID1"
        '
        'lblエラーデータ出力先
        '
        Me.lblエラーデータ出力先.AutoSize = True
        Me.lblエラーデータ出力先.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblエラーデータ出力先.Location = New System.Drawing.Point(12, 184)
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
        Me.pnl操作.Controls.Add(Me.lbl許可期間２)
        Me.pnl操作.Controls.Add(Me.txt対象終了月)
        Me.pnl操作.Controls.Add(Me.cmb医薬品区分)
        Me.pnl操作.Controls.Add(Me.lbl医薬品区分)
        Me.pnl操作.Controls.Add(Me.txt対象開始月)
        Me.pnl操作.Controls.Add(Me.lbl対象月)
        Me.pnl操作.Controls.Add(Me.cmbサブプログラム)
        Me.pnl操作.Controls.Add(Me.lblサブプログラム)
        Me.pnl操作.Controls.Add(Me.btnフォルダ参照)
        Me.pnl操作.Controls.Add(Me.txtデータ出力先)
        Me.pnl操作.Controls.Add(Me.lblエラーデータ出力先)
        Me.pnl操作.Location = New System.Drawing.Point(25, 60)
        Me.pnl操作.Name = "pnl操作"
        Me.pnl操作.Size = New System.Drawing.Size(475, 614)
        Me.pnl操作.TabIndex = 183
        '
        'lbl許可期間２
        '
        Me.lbl許可期間２.AutoSize = True
        Me.lbl許可期間２.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl許可期間２.Location = New System.Drawing.Point(139, 154)
        Me.lbl許可期間２.Name = "lbl許可期間２"
        Me.lbl許可期間２.Size = New System.Drawing.Size(22, 20)
        Me.lbl許可期間２.TabIndex = 187
        Me.lbl許可期間２.Text = "～"
        Me.lbl許可期間２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt対象終了月
        '
        Me.txt対象終了月.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        Me.txt対象終了月.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1})
        Me.txt対象終了月.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt対象終了月.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt対象終了月.Location = New System.Drawing.Point(167, 151)
        Me.txt対象終了月.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt対象終了月.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt対象終了月.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt対象終了月.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt対象終了月.Name = "txt対象終了月"
        Me.txt対象終了月.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.txt対象終了月.Size = New System.Drawing.Size(118, 26)
        Me.txt対象終了月.TabIndex = 14
        Me.txt対象終了月.Value = Nothing
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'cmb医薬品区分
        '
        Me.cmb医薬品区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb医薬品区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb医薬品区分.FormattingEnabled = True
        Me.cmb医薬品区分.Location = New System.Drawing.Point(12, 39)
        Me.cmb医薬品区分.Name = "cmb医薬品区分"
        Me.cmb医薬品区分.Size = New System.Drawing.Size(179, 26)
        Me.cmb医薬品区分.TabIndex = 11
        Me.cmb医薬品区分.Tag = "ID2"
        '
        'lbl医薬品区分
        '
        Me.lbl医薬品区分.AutoSize = True
        Me.lbl医薬品区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl医薬品区分.Location = New System.Drawing.Point(12, 16)
        Me.lbl医薬品区分.Name = "lbl医薬品区分"
        Me.lbl医薬品区分.Size = New System.Drawing.Size(100, 20)
        Me.lbl医薬品区分.TabIndex = 171
        Me.lbl医薬品区分.Text = "【医薬品区分】"
        Me.lbl医薬品区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt対象開始月
        '
        Me.txt対象開始月.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField2.Text = "/"
        Me.txt対象開始月.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField2, DateLiteralField2, DateMonthField2})
        Me.txt対象開始月.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt対象開始月.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt対象開始月.Location = New System.Drawing.Point(12, 151)
        Me.txt対象開始月.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt対象開始月.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txt対象開始月.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt対象開始月.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txt対象開始月.Name = "txt対象開始月"
        Me.txt対象開始月.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.txt対象開始月.Size = New System.Drawing.Size(118, 26)
        Me.txt対象開始月.TabIndex = 13
        Me.txt対象開始月.Value = Nothing
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl対象月
        '
        Me.lbl対象月.AutoSize = True
        Me.lbl対象月.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl対象月.Location = New System.Drawing.Point(12, 128)
        Me.lbl対象月.Name = "lbl対象月"
        Me.lbl対象月.Size = New System.Drawing.Size(74, 20)
        Me.lbl対象月.TabIndex = 169
        Me.lbl対象月.Text = "【対象月】"
        Me.lbl対象月.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbサブプログラム
        '
        Me.cmbサブプログラム.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbサブプログラム.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbサブプログラム.FormattingEnabled = True
        Me.cmbサブプログラム.Location = New System.Drawing.Point(12, 95)
        Me.cmbサブプログラム.Name = "cmbサブプログラム"
        Me.cmbサブプログラム.Size = New System.Drawing.Size(382, 26)
        Me.cmbサブプログラム.TabIndex = 12
        Me.cmbサブプログラム.Tag = "ID3"
        '
        'lblサブプログラム
        '
        Me.lblサブプログラム.AutoSize = True
        Me.lblサブプログラム.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblサブプログラム.Location = New System.Drawing.Point(12, 72)
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
        'BS一覧
        '
        Me.BS一覧.DataMember = "ds一覧"
        Me.BS一覧.DataSource = Me.HARK502DS
        '
        'HARK502DS
        '
        Me.HARK502DS.DataSetName = "HARK502DS"
        Me.HARK502DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HARK502
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
        Me.Name = "HARK502"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        CType(Me.lb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtデータ出力先, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl操作.ResumeLayout(False)
        Me.pnl操作.PerformLayout()
        CType(Me.txt対象終了月, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt対象開始月, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入力担当コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK502DS, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents txtデータ出力先 As GrapeCity.Win.Editors.GcTextBox
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
    Private WithEvents txt対象開始月 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl対象月 As Label
    Private WithEvents cmb医薬品区分 As ComboBox
    Private WithEvents lbl医薬品区分 As Label
    Private WithEvents txt対象終了月 As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl許可期間２ As Label

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxmForm As Form
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String
    Private xxxint医薬品区分 As Integer
    Private xxxintCnt As Integer
    Private xxxintNo As Integer
    Private xxxint処理対象区分 As Integer
    Private Viewer As HARK991 = Nothing
    Private Reports As HARK502Reports = Nothing
    Private WithEvents BS一覧 As BindingSource
    Private WithEvents HARK502DS As HARK502DS


    Public Sub New(ByVal PerForm As Form, ByVal PerFormTitle As String, ByVal PerProgramID As String)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxmForm = PerForm
        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txtデータ出力先.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmb医薬品区分.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler cmbサブプログラム.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt対象開始月.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt対象終了月.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb医薬品区分.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb事業所.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmbサブプログラム.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb医薬品区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

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
