'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK501S2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK501S2))
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl明細 = New System.Windows.Forms.Panel()
        Me.lbl明細仕入先名 = New System.Windows.Forms.Label()
        Me.lbl明細９ = New System.Windows.Forms.Label()
        Me.lbl明細８ = New System.Windows.Forms.Label()
        Me.lbl明細販売元 = New System.Windows.Forms.Label()
        Me.cmbマルビシ対象 = New System.Windows.Forms.ComboBox()
        Me.lbl明細業者用コード = New System.Windows.Forms.Label()
        Me.cmb軽減税率対象 = New System.Windows.Forms.ComboBox()
        Me.lbl明細７ = New System.Windows.Forms.Label()
        Me.lbl商品ID = New System.Windows.Forms.Label()
        Me.lbl明細２ = New System.Windows.Forms.Label()
        Me.cmbマルコ対象 = New System.Windows.Forms.ComboBox()
        Me.lbl明細６ = New System.Windows.Forms.Label()
        Me.lbl明細５ = New System.Windows.Forms.Label()
        Me.lbl明細３ = New System.Windows.Forms.Label()
        Me.lbl明細４ = New System.Windows.Forms.Label()
        Me.lbl明細仕入先コード = New System.Windows.Forms.Label()
        Me.lbl明細商品コード = New System.Windows.Forms.Label()
        Me.lbl明細商品名 = New System.Windows.Forms.Label()
        Me.lbl明細規格 = New System.Windows.Forms.Label()
        Me.lbl明細１ = New System.Windows.Forms.Label()
        Me.txt院内コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
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
        Me.lbl院内コード = New System.Windows.Forms.Label()
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl明細.SuspendLayout()
        CType(Me.txt院内コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
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
        Me.BT_ID4.Location = New System.Drawing.Point(255, 0)
        Me.BT_ID4.Name = "BT_ID4"
        Me.BT_ID4.Size = New System.Drawing.Size(85, 24)
        Me.BT_ID4.TabIndex = 134
        Me.BT_ID4.Tag = "ID4"
        Me.BT_ID4.Text = "ログ(&F4)"
        Me.BT_ID4.UseVisualStyleBackColor = False
        '
        'pnl明細
        '
        Me.pnl明細.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl明細.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl明細.Controls.Add(Me.lbl明細仕入先名)
        Me.pnl明細.Controls.Add(Me.lbl明細９)
        Me.pnl明細.Controls.Add(Me.lbl明細８)
        Me.pnl明細.Controls.Add(Me.lbl明細販売元)
        Me.pnl明細.Controls.Add(Me.cmbマルビシ対象)
        Me.pnl明細.Controls.Add(Me.lbl明細業者用コード)
        Me.pnl明細.Controls.Add(Me.cmb軽減税率対象)
        Me.pnl明細.Controls.Add(Me.lbl明細７)
        Me.pnl明細.Controls.Add(Me.lbl商品ID)
        Me.pnl明細.Controls.Add(Me.lbl明細２)
        Me.pnl明細.Controls.Add(Me.cmbマルコ対象)
        Me.pnl明細.Controls.Add(Me.lbl明細６)
        Me.pnl明細.Controls.Add(Me.lbl明細５)
        Me.pnl明細.Controls.Add(Me.lbl明細３)
        Me.pnl明細.Controls.Add(Me.lbl明細４)
        Me.pnl明細.Controls.Add(Me.lbl明細仕入先コード)
        Me.pnl明細.Controls.Add(Me.lbl明細商品コード)
        Me.pnl明細.Controls.Add(Me.lbl明細商品名)
        Me.pnl明細.Controls.Add(Me.lbl明細規格)
        Me.pnl明細.Controls.Add(Me.lbl明細１)
        Me.pnl明細.Location = New System.Drawing.Point(25, 96)
        Me.pnl明細.Name = "pnl明細"
        Me.pnl明細.Size = New System.Drawing.Size(955, 334)
        Me.pnl明細.TabIndex = 185
        '
        'lbl明細仕入先名
        '
        Me.lbl明細仕入先名.AutoEllipsis = True
        Me.lbl明細仕入先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細仕入先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細仕入先名.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細仕入先名.Location = New System.Drawing.Point(234, 182)
        Me.lbl明細仕入先名.Name = "lbl明細仕入先名"
        Me.lbl明細仕入先名.Size = New System.Drawing.Size(461, 26)
        Me.lbl明細仕入先名.TabIndex = 227
        Me.lbl明細仕入先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細９
        '
        Me.lbl明細９.AutoSize = True
        Me.lbl明細９.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細９.Location = New System.Drawing.Point(7, 286)
        Me.lbl明細９.Name = "lbl明細９"
        Me.lbl明細９.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細９.TabIndex = 226
        Me.lbl明細９.Text = "【軽減税率対象】"
        Me.lbl明細９.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細８
        '
        Me.lbl明細８.AutoSize = True
        Me.lbl明細８.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細８.Location = New System.Drawing.Point(7, 252)
        Me.lbl明細８.Name = "lbl明細８"
        Me.lbl明細８.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細８.TabIndex = 225
        Me.lbl明細８.Text = "【マルビシ対象】"
        Me.lbl明細８.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細販売元
        '
        Me.lbl明細販売元.AutoEllipsis = True
        Me.lbl明細販売元.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細販売元.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細販売元.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細販売元.Location = New System.Drawing.Point(127, 54)
        Me.lbl明細販売元.Name = "lbl明細販売元"
        Me.lbl明細販売元.Size = New System.Drawing.Size(291, 26)
        Me.lbl明細販売元.TabIndex = 224
        Me.lbl明細販売元.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbマルビシ対象
        '
        Me.cmbマルビシ対象.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbマルビシ対象.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbマルビシ対象.FormattingEnabled = True
        Me.cmbマルビシ対象.Location = New System.Drawing.Point(127, 249)
        Me.cmbマルビシ対象.Name = "cmbマルビシ対象"
        Me.cmbマルビシ対象.Size = New System.Drawing.Size(181, 26)
        Me.cmbマルビシ対象.TabIndex = 22
        Me.cmbマルビシ対象.Tag = "ID2"
        '
        'lbl明細業者用コード
        '
        Me.lbl明細業者用コード.AutoEllipsis = True
        Me.lbl明細業者用コード.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細業者用コード.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細業者用コード.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細業者用コード.Location = New System.Drawing.Point(127, 22)
        Me.lbl明細業者用コード.Name = "lbl明細業者用コード"
        Me.lbl明細業者用コード.Size = New System.Drawing.Size(291, 26)
        Me.lbl明細業者用コード.TabIndex = 222
        Me.lbl明細業者用コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb軽減税率対象
        '
        Me.cmb軽減税率対象.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb軽減税率対象.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb軽減税率対象.FormattingEnabled = True
        Me.cmb軽減税率対象.Location = New System.Drawing.Point(127, 283)
        Me.cmb軽減税率対象.Name = "cmb軽減税率対象"
        Me.cmb軽減税率対象.Size = New System.Drawing.Size(181, 26)
        Me.cmb軽減税率対象.TabIndex = 23
        Me.cmb軽減税率対象.Tag = "ID3"
        '
        'lbl明細７
        '
        Me.lbl明細７.AutoSize = True
        Me.lbl明細７.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細７.Location = New System.Drawing.Point(7, 217)
        Me.lbl明細７.Name = "lbl明細７"
        Me.lbl明細７.Size = New System.Drawing.Size(100, 20)
        Me.lbl明細７.TabIndex = 221
        Me.lbl明細７.Text = "【マルコ対象】"
        Me.lbl明細７.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl商品ID
        '
        Me.lbl商品ID.AutoEllipsis = True
        Me.lbl商品ID.BackColor = System.Drawing.SystemColors.Control
        Me.lbl商品ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl商品ID.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl商品ID.Location = New System.Drawing.Point(488, 22)
        Me.lbl商品ID.Name = "lbl商品ID"
        Me.lbl商品ID.Size = New System.Drawing.Size(100, 26)
        Me.lbl商品ID.TabIndex = 204
        Me.lbl商品ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl商品ID.Visible = False
        '
        'lbl明細２
        '
        Me.lbl明細２.AutoSize = True
        Me.lbl明細２.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細２.Location = New System.Drawing.Point(7, 57)
        Me.lbl明細２.Name = "lbl明細２"
        Me.lbl明細２.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細２.TabIndex = 220
        Me.lbl明細２.Text = "【販売元】"
        Me.lbl明細２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbマルコ対象
        '
        Me.cmbマルコ対象.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbマルコ対象.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbマルコ対象.FormattingEnabled = True
        Me.cmbマルコ対象.Location = New System.Drawing.Point(127, 214)
        Me.cmbマルコ対象.Name = "cmbマルコ対象"
        Me.cmbマルコ対象.Size = New System.Drawing.Size(181, 26)
        Me.cmbマルコ対象.TabIndex = 21
        Me.cmbマルコ対象.Tag = "ID1"
        '
        'lbl明細６
        '
        Me.lbl明細６.AutoSize = True
        Me.lbl明細６.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細６.Location = New System.Drawing.Point(7, 185)
        Me.lbl明細６.Name = "lbl明細６"
        Me.lbl明細６.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細６.TabIndex = 205
        Me.lbl明細６.Text = "【仕入先】"
        Me.lbl明細６.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細５
        '
        Me.lbl明細５.AutoSize = True
        Me.lbl明細５.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細５.Location = New System.Drawing.Point(7, 153)
        Me.lbl明細５.Name = "lbl明細５"
        Me.lbl明細５.Size = New System.Drawing.Size(100, 20)
        Me.lbl明細５.TabIndex = 204
        Me.lbl明細５.Text = "【商品コード】"
        Me.lbl明細５.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細３
        '
        Me.lbl明細３.AutoSize = True
        Me.lbl明細３.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細３.Location = New System.Drawing.Point(7, 89)
        Me.lbl明細３.Name = "lbl明細３"
        Me.lbl明細３.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細３.TabIndex = 203
        Me.lbl明細３.Text = "【商品名】"
        Me.lbl明細３.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細４
        '
        Me.lbl明細４.AutoSize = True
        Me.lbl明細４.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細４.Location = New System.Drawing.Point(7, 121)
        Me.lbl明細４.Name = "lbl明細４"
        Me.lbl明細４.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細４.TabIndex = 202
        Me.lbl明細４.Text = "【規格】"
        Me.lbl明細４.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細仕入先コード
        '
        Me.lbl明細仕入先コード.AutoEllipsis = True
        Me.lbl明細仕入先コード.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細仕入先コード.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細仕入先コード.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細仕入先コード.Location = New System.Drawing.Point(127, 182)
        Me.lbl明細仕入先コード.Name = "lbl明細仕入先コード"
        Me.lbl明細仕入先コード.Size = New System.Drawing.Size(101, 26)
        Me.lbl明細仕入先コード.TabIndex = 203
        Me.lbl明細仕入先コード.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl明細商品コード
        '
        Me.lbl明細商品コード.AutoEllipsis = True
        Me.lbl明細商品コード.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細商品コード.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細商品コード.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細商品コード.Location = New System.Drawing.Point(127, 150)
        Me.lbl明細商品コード.Name = "lbl明細商品コード"
        Me.lbl明細商品コード.Size = New System.Drawing.Size(461, 26)
        Me.lbl明細商品コード.TabIndex = 202
        Me.lbl明細商品コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細商品名
        '
        Me.lbl明細商品名.AutoEllipsis = True
        Me.lbl明細商品名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細商品名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細商品名.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細商品名.Location = New System.Drawing.Point(127, 86)
        Me.lbl明細商品名.Name = "lbl明細商品名"
        Me.lbl明細商品名.Size = New System.Drawing.Size(461, 26)
        Me.lbl明細商品名.TabIndex = 200
        Me.lbl明細商品名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細規格
        '
        Me.lbl明細規格.AutoEllipsis = True
        Me.lbl明細規格.BackColor = System.Drawing.SystemColors.Control
        Me.lbl明細規格.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl明細規格.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細規格.Location = New System.Drawing.Point(127, 118)
        Me.lbl明細規格.Name = "lbl明細規格"
        Me.lbl明細規格.Size = New System.Drawing.Size(461, 26)
        Me.lbl明細規格.TabIndex = 201
        Me.lbl明細規格.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１
        '
        Me.lbl明細１.AutoSize = True
        Me.lbl明細１.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１.Location = New System.Drawing.Point(7, 25)
        Me.lbl明細１.Name = "lbl明細１"
        Me.lbl明細１.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細１.TabIndex = 169
        Me.lbl明細１.Text = "【業者用コード】"
        Me.lbl明細１.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt院内コード
        '
        Me.txt院内コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt院内コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt院内コード.Format = "A9"
        Me.txt院内コード.Location = New System.Drawing.Point(127, 10)
        Me.txt院内コード.MaxLength = 40
        Me.txt院内コード.Name = "txt院内コード"
        Me.txt院内コード.Size = New System.Drawing.Size(181, 26)
        Me.txt院内コード.TabIndex = 11
        Me.txt院内コード.Tag = "ID1"
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
        Me.Bt_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.lbl院内コード)
        Me.pnl検索.Controls.Add(Me.txt院内コード)
        Me.pnl検索.Location = New System.Drawing.Point(25, 44)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(955, 46)
        Me.pnl検索.TabIndex = 184
        '
        'lbl院内コード
        '
        Me.lbl院内コード.AutoSize = True
        Me.lbl院内コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl院内コード.Location = New System.Drawing.Point(7, 13)
        Me.lbl院内コード.Name = "lbl院内コード"
        Me.lbl院内コード.Size = New System.Drawing.Size(100, 20)
        Me.lbl院内コード.TabIndex = 167
        Me.lbl院内コード.Text = "【院内コード】"
        Me.lbl院内コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HARK501S2
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
        Me.Name = "HARK501S2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl明細.ResumeLayout(False)
        Me.pnl明細.PerformLayout()
        CType(Me.txt院内コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
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
    Private WithEvents lbl明細１ As Label
    Private WithEvents pnl検索 As Panel
    Private WithEvents lbl明細仕入先コード As Label
    Private WithEvents lbl明細商品コード As Label
    Private WithEvents lbl明細商品名 As Label
    Private WithEvents lbl明細規格 As Label
    Private WithEvents lbl院内コード As Label
    Private WithEvents lbl明細６ As Label
    Private WithEvents lbl明細５ As Label
    Private WithEvents lbl明細３ As Label
    Private WithEvents lbl明細４ As Label
    Private WithEvents txt院内コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents cmbマルコ対象 As ComboBox
    Private WithEvents lbl明細２ As Label
    Private WithEvents lbl商品ID As Label
    Private WithEvents cmb軽減税率対象 As ComboBox
    Private WithEvents lbl明細７ As Label
    Private WithEvents lbl明細業者用コード As Label
    Private WithEvents lbl明細９ As Label
    Private WithEvents lbl明細８ As Label
    Private WithEvents lbl明細販売元 As Label
    Private WithEvents cmbマルビシ対象 As ComboBox
    Private WithEvents lbl明細仕入先名 As Label

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxintSPDSystemCode As Integer
    Private xxxstrForTitle As String
    Private xxxintマルコ対象 As Integer
    Private xxxintマルビシ対象 As Integer
    Private xxxint軽減税率対象 As Integer
    Private xxxstr病院コード As String


    Public Sub New(ByVal PerFormTitle As String, ByVal PerProgramID As String, ByVal PreSubProgramID As Integer, ByVal PreSPDSystemCode As Integer)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = PreSubProgramID
        xxxintSPDSystemCode = PreSPDSystemCode
        xxxstr病院コード = "T01"

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txt院内コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmb軽減税率対象.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler cmbマルビシ対象.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler cmbマルコ対象.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler cmbマルコ対象.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmbマルビシ対象.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt院内コード.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmbマルコ対象.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmbマルビシ対象.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb軽減税率対象.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Validatedイベントハンドラの追加
        AddHandler txt院内コード.Validated, AddressOf Txt_Validated

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
