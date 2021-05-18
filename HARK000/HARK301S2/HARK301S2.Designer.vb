'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK301S2
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
        Dim CellStyle2 As GrapeCity.Win.MultiRow.CellStyle = New GrapeCity.Win.MultiRow.CellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK301S2))
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl明細 = New System.Windows.Forms.Panel()
        Me.SttBar_3 = New System.Windows.Forms.StatusBarPanel()
        Me.SttBar_2 = New System.Windows.Forms.StatusBarPanel()
        Me.SttBarPnl_Err = New System.Windows.Forms.StatusBarPanel()
        Me.SttBar = New System.Windows.Forms.StatusBar()
        Me.BT_ID7 = New System.Windows.Forms.Button()
        Me.BT_ID8 = New System.Windows.Forms.Button()
        Me.BT_ID3 = New System.Windows.Forms.Button()
        Me.BT_ID2 = New System.Windows.Forms.Button()
        Me.BT_ID1 = New System.Windows.Forms.Button()
        Me.BT_ID6 = New System.Windows.Forms.Button()
        Me.Bt_Close = New System.Windows.Forms.Button()
        Me.BT_ID5 = New System.Windows.Forms.Button()
        Me.pnl検索 = New System.Windows.Forms.Panel()
        Me.txtメーカ品番 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl商品コード = New System.Windows.Forms.Label()
        Me.txt商品コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lblメーカ = New System.Windows.Forms.Label()
        Me.txtメーカコード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lblメーカ名 = New System.Windows.Forms.Label()
        Me.lblメーカ品番 = New System.Windows.Forms.Label()
        Me.BS一覧 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HARK301S2DS = New HARK000.HARK301S2DS()
        Me.lbl備考 = New System.Windows.Forms.Label()
        Me.gcmr一覧 = New GrapeCity.Win.MultiRow.GcMultiRow()
        Me.HARK301S2Template1 = New HARK000.HARK301S2Template()
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl明細.SuspendLayout()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
        CType(Me.txtメーカ品番, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt商品コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtメーカコード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HARK301S2DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'pnl明細
        '
        Me.pnl明細.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl明細.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl明細.Controls.Add(Me.gcmr一覧)
        Me.pnl明細.Location = New System.Drawing.Point(25, 151)
        Me.pnl明細.Name = "pnl明細"
        Me.pnl明細.Size = New System.Drawing.Size(955, 279)
        Me.pnl明細.TabIndex = 185
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
        'SttBar
        '
        Me.SttBar.Location = New System.Drawing.Point(0, 433)
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
        Me.Bt_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        Me.BT_ID5.Enabled = False
        Me.BT_ID5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID5.Location = New System.Drawing.Point(380, 0)
        Me.BT_ID5.Name = "BT_ID5"
        Me.BT_ID5.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID5.TabIndex = 135
        Me.BT_ID5.Tag = "ID5"
        Me.BT_ID5.UseVisualStyleBackColor = False
        '
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.lbl備考)
        Me.pnl検索.Controls.Add(Me.txtメーカ品番)
        Me.pnl検索.Controls.Add(Me.lbl商品コード)
        Me.pnl検索.Controls.Add(Me.txt商品コード)
        Me.pnl検索.Controls.Add(Me.lblメーカ)
        Me.pnl検索.Controls.Add(Me.txtメーカコード)
        Me.pnl検索.Controls.Add(Me.lblメーカ名)
        Me.pnl検索.Controls.Add(Me.lblメーカ品番)
        Me.pnl検索.Location = New System.Drawing.Point(25, 44)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(955, 101)
        Me.pnl検索.TabIndex = 184
        '
        'txtメーカ品番
        '
        Me.txtメーカ品番.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtメーカ品番.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtメーカ品番.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtメーカ品番.Format = "KAa#@"
        Me.txtメーカ品番.Location = New System.Drawing.Point(162, 35)
        Me.txtメーカ品番.MaxLength = 60
        Me.txtメーカ品番.Name = "txtメーカ品番"
        Me.txtメーカ品番.Size = New System.Drawing.Size(233, 26)
        Me.txtメーカ品番.TabIndex = 12
        Me.txtメーカ品番.Tag = "ID2"
        '
        'lbl商品コード
        '
        Me.lbl商品コード.AutoSize = True
        Me.lbl商品コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl商品コード.Location = New System.Drawing.Point(59, 65)
        Me.lbl商品コード.Name = "lbl商品コード"
        Me.lbl商品コード.Size = New System.Drawing.Size(100, 20)
        Me.lbl商品コード.TabIndex = 182
        Me.lbl商品コード.Text = "【商品コード】"
        Me.lbl商品コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt商品コード
        '
        Me.txt商品コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt商品コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt商品コード.Format = "9"
        Me.txt商品コード.Location = New System.Drawing.Point(162, 63)
        Me.txt商品コード.MaxLength = 60
        Me.txt商品コード.Name = "txt商品コード"
        Me.txt商品コード.Size = New System.Drawing.Size(181, 26)
        Me.txt商品コード.TabIndex = 13
        Me.txt商品コード.Tag = "ID3"
        '
        'lblメーカ
        '
        Me.lblメーカ.AutoSize = True
        Me.lblメーカ.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblメーカ.Location = New System.Drawing.Point(85, 11)
        Me.lblメーカ.Name = "lblメーカ"
        Me.lblメーカ.Size = New System.Drawing.Size(74, 20)
        Me.lblメーカ.TabIndex = 181
        Me.lblメーカ.Text = "【メーカ】"
        Me.lblメーカ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtメーカコード
        '
        Me.txtメーカコード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txtメーカコード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtメーカコード.Format = "9"
        Me.txtメーカコード.HighlightText = True
        Me.txtメーカコード.Location = New System.Drawing.Point(162, 9)
        Me.txtメーカコード.MaxLength = 10
        Me.txtメーカコード.Name = "txtメーカコード"
        Me.txtメーカコード.Size = New System.Drawing.Size(93, 24)
        Me.txtメーカコード.TabIndex = 11
        Me.txtメーカコード.Tag = "ID1"
        '
        'lblメーカ名
        '
        Me.lblメーカ名.AutoEllipsis = True
        Me.lblメーカ名.BackColor = System.Drawing.SystemColors.Control
        Me.lblメーカ名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblメーカ名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblメーカ名.Location = New System.Drawing.Point(257, 9)
        Me.lblメーカ名.Name = "lblメーカ名"
        Me.lblメーカ名.Size = New System.Drawing.Size(287, 24)
        Me.lblメーカ名.TabIndex = 179
        Me.lblメーカ名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblメーカ品番
        '
        Me.lblメーカ品番.AutoSize = True
        Me.lblメーカ品番.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblメーカ品番.Location = New System.Drawing.Point(59, 38)
        Me.lblメーカ品番.Name = "lblメーカ品番"
        Me.lblメーカ品番.Size = New System.Drawing.Size(100, 20)
        Me.lblメーカ品番.TabIndex = 178
        Me.lblメーカ品番.Text = "【メーカ品番】"
        Me.lblメーカ品番.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BS一覧
        '
        Me.BS一覧.DataMember = "ds一覧"
        Me.BS一覧.DataSource = Me.HARK301S2DS
        '
        'HARK301S2DS
        '
        Me.HARK301S2DS.DataSetName = "HARK301S2DS"
        Me.HARK301S2DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbl備考
        '
        Me.lbl備考.AutoSize = True
        Me.lbl備考.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.lbl備考.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl備考.ForeColor = System.Drawing.Color.Red
        Me.lbl備考.Location = New System.Drawing.Point(619, 41)
        Me.lbl備考.Name = "lbl備考"
        Me.lbl備考.Size = New System.Drawing.Size(52, 20)
        Me.lbl備考.TabIndex = 183
        Me.lbl備考.Text = "lbl備考"
        Me.lbl備考.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.gcmr一覧.Location = New System.Drawing.Point(11, 8)
        Me.gcmr一覧.MultiSelect = False
        Me.gcmr一覧.Name = "gcmr一覧"
        Me.gcmr一覧.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcmr一覧.Size = New System.Drawing.Size(918, 264)
        Me.gcmr一覧.SplitMode = GrapeCity.Win.MultiRow.SplitMode.None
        Me.gcmr一覧.TabIndex = 0
        Me.gcmr一覧.TabStop = False
        Me.gcmr一覧.Template = Me.HARK301S2Template1
        Me.gcmr一覧.Text = "gcmr一覧"
        '
        'HARK301S2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 457)
        Me.Controls.Add(Me.pnl検索)
        Me.Controls.Add(Me.BT_ID4)
        Me.Controls.Add(Me.pnl明細)
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
        Me.Name = "HARK301S2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl明細.ResumeLayout(False)
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        CType(Me.txtメーカ品番, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt商品コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtメーカコード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HARK301S2DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcmr一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Menu_Log As ToolStripMenuItem
    Private WithEvents CntMenuStrip As ContextMenuStrip
    Private WithEvents Menu_ErrorLog As ToolStripMenuItem
    Private WithEvents BT_ID4 As GrapeCity.Win.Buttons.GcSplitButton
    Private WithEvents pnl明細 As Panel
    Private WithEvents SttBar_3 As StatusBarPanel
    Private WithEvents SttBar_2 As StatusBarPanel
    Private WithEvents SttBarPnl_Err As StatusBarPanel
    Private WithEvents SttBar As StatusBar
    Private WithEvents BT_ID7 As Button
    Private WithEvents BT_ID8 As Button
    Private WithEvents BT_ID3 As Button
    Private WithEvents BT_ID2 As Button
    Private WithEvents BT_ID1 As Button
    Private WithEvents BT_ID6 As Button
    Private WithEvents Bt_Close As Button
    Private WithEvents BT_ID5 As Button
    Private WithEvents pnl検索 As Panel
    Private WithEvents BS一覧 As BindingSource
    Private WithEvents gcmr一覧 As GrapeCity.Win.MultiRow.GcMultiRow
    Private WithEvents HARK301S2DS As HARK301S2DS
    Private WithEvents HARK301S2Template1 As HARK301S2Template
    Private WithEvents lbl商品コード As Label
    Private WithEvents txt商品コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lblメーカ As Label
    Private WithEvents txtメーカコード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lblメーカ名 As Label
    Private WithEvents lblメーカ品番 As Label
    Private WithEvents txtメーカ品番 As GrapeCity.Win.Editors.GcTextBox

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxintSPDSystemCode As Integer
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String



    Public Sub New(ByVal PerFormTitle As String, ByVal PerProgramID As String, ByVal PreSubProgramID As Integer, ByVal PreSPDSystemCode As Integer)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = PreSubProgramID
        xxxintSPDSystemCode = PreSPDSystemCode

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txtメーカコード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txtメーカ品番.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txt商品コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler txtメーカコード.KeyDown, AddressOf Txt_KeyDown
        AddHandler txtメーカ品番.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt商品コード.KeyDown, AddressOf Txt_KeyDown

        'Validatedイベントハンドラの追加
        AddHandler txt商品コード.Validated, AddressOf Txt_Validated
        AddHandler txtメーカコード.Validated, AddressOf Txt_Validated


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

    Private WithEvents lbl備考 As Label
End Class
