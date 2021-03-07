'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK992
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK992))
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl明細 = New System.Windows.Forms.Panel()
        Me.lbl明細発注納期設定区分 = New System.Windows.Forms.Label()
        Me.lbl明細商品手配方法区分 = New System.Windows.Forms.Label()
        Me.GB希望発注納期 = New System.Windows.Forms.GroupBox()
        Me.cmb希望発注納期_金 = New System.Windows.Forms.ComboBox()
        Me.cmb希望発注納期_木 = New System.Windows.Forms.ComboBox()
        Me.cmb希望発注納期_水 = New System.Windows.Forms.ComboBox()
        Me.cmb希望発注納期_火 = New System.Windows.Forms.ComboBox()
        Me.cmb希望発注納期_月 = New System.Windows.Forms.ComboBox()
        Me.lbl希望発注納期_金 = New System.Windows.Forms.Label()
        Me.lbl希望発注納期_木 = New System.Windows.Forms.Label()
        Me.lbl希望発注納期_水 = New System.Windows.Forms.Label()
        Me.lbl希望発注納期_火 = New System.Windows.Forms.Label()
        Me.lbl希望発注納期_月 = New System.Windows.Forms.Label()
        Me.cmb発注納期設定区分 = New System.Windows.Forms.ComboBox()
        Me.cmb商品手配方法区分 = New System.Windows.Forms.ComboBox()
        Me.cmb商品出荷指示区分 = New System.Windows.Forms.ComboBox()
        Me.lbl明細直送先コード = New System.Windows.Forms.Label()
        Me.txt直送先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl直送先名 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl明細商品出荷指示区分 = New System.Windows.Forms.Label()
        Me.cmb直送区分 = New System.Windows.Forms.ComboBox()
        Me.lbl明細直送区分 = New System.Windows.Forms.Label()
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
        Me.lbl得意先コード = New System.Windows.Forms.Label()
        Me.txt需要先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl需要先名 = New System.Windows.Forms.Label()
        Me.txt得意先コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lbl得意先名 = New System.Windows.Forms.Label()
        Me.lbl需要先コード = New System.Windows.Forms.Label()
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl明細.SuspendLayout()
        Me.GB希望発注納期.SuspendLayout()
        CType(Me.txt直送先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
        CType(Me.txt需要先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt得意先コード, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnl明細.Controls.Add(Me.lbl明細発注納期設定区分)
        Me.pnl明細.Controls.Add(Me.lbl明細商品手配方法区分)
        Me.pnl明細.Controls.Add(Me.GB希望発注納期)
        Me.pnl明細.Controls.Add(Me.cmb発注納期設定区分)
        Me.pnl明細.Controls.Add(Me.cmb商品手配方法区分)
        Me.pnl明細.Controls.Add(Me.cmb商品出荷指示区分)
        Me.pnl明細.Controls.Add(Me.lbl明細直送先コード)
        Me.pnl明細.Controls.Add(Me.txt直送先コード)
        Me.pnl明細.Controls.Add(Me.lbl直送先名)
        Me.pnl明細.Controls.Add(Me.lblID)
        Me.pnl明細.Controls.Add(Me.lbl明細商品出荷指示区分)
        Me.pnl明細.Controls.Add(Me.cmb直送区分)
        Me.pnl明細.Controls.Add(Me.lbl明細直送区分)
        Me.pnl明細.Location = New System.Drawing.Point(25, 128)
        Me.pnl明細.Name = "pnl明細"
        Me.pnl明細.Size = New System.Drawing.Size(955, 302)
        Me.pnl明細.TabIndex = 185
        '
        'lbl明細発注納期設定区分
        '
        Me.lbl明細発注納期設定区分.AutoSize = True
        Me.lbl明細発注納期設定区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細発注納期設定区分.Location = New System.Drawing.Point(11, 122)
        Me.lbl明細発注納期設定区分.Name = "lbl明細発注納期設定区分"
        Me.lbl明細発注納期設定区分.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細発注納期設定区分.TabIndex = 230
        Me.lbl明細発注納期設定区分.Text = "【発注納期設定】"
        Me.lbl明細発注納期設定区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細商品手配方法区分
        '
        Me.lbl明細商品手配方法区分.AutoSize = True
        Me.lbl明細商品手配方法区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細商品手配方法区分.Location = New System.Drawing.Point(11, 89)
        Me.lbl明細商品手配方法区分.Name = "lbl明細商品手配方法区分"
        Me.lbl明細商品手配方法区分.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細商品手配方法区分.TabIndex = 229
        Me.lbl明細商品手配方法区分.Text = "【商品手配方法】"
        Me.lbl明細商品手配方法区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GB希望発注納期
        '
        Me.GB希望発注納期.Controls.Add(Me.cmb希望発注納期_金)
        Me.GB希望発注納期.Controls.Add(Me.cmb希望発注納期_木)
        Me.GB希望発注納期.Controls.Add(Me.cmb希望発注納期_水)
        Me.GB希望発注納期.Controls.Add(Me.cmb希望発注納期_火)
        Me.GB希望発注納期.Controls.Add(Me.cmb希望発注納期_月)
        Me.GB希望発注納期.Controls.Add(Me.lbl希望発注納期_金)
        Me.GB希望発注納期.Controls.Add(Me.lbl希望発注納期_木)
        Me.GB希望発注納期.Controls.Add(Me.lbl希望発注納期_水)
        Me.GB希望発注納期.Controls.Add(Me.lbl希望発注納期_火)
        Me.GB希望発注納期.Controls.Add(Me.lbl希望発注納期_月)
        Me.GB希望発注納期.Location = New System.Drawing.Point(127, 151)
        Me.GB希望発注納期.Name = "GB希望発注納期"
        Me.GB希望発注納期.Size = New System.Drawing.Size(607, 89)
        Me.GB希望発注納期.TabIndex = 228
        Me.GB希望発注納期.TabStop = False
        Me.GB希望発注納期.Text = "希望発注納期"
        '
        'cmb希望発注納期_金
        '
        Me.cmb希望発注納期_金.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb希望発注納期_金.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb希望発注納期_金.FormattingEnabled = True
        Me.cmb希望発注納期_金.Location = New System.Drawing.Point(496, 48)
        Me.cmb希望発注納期_金.Name = "cmb希望発注納期_金"
        Me.cmb希望発注納期_金.Size = New System.Drawing.Size(93, 26)
        Me.cmb希望発注納期_金.TabIndex = 30
        Me.cmb希望発注納期_金.Tag = "ID9"
        '
        'cmb希望発注納期_木
        '
        Me.cmb希望発注納期_木.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb希望発注納期_木.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb希望発注納期_木.FormattingEnabled = True
        Me.cmb希望発注納期_木.Location = New System.Drawing.Point(376, 48)
        Me.cmb希望発注納期_木.Name = "cmb希望発注納期_木"
        Me.cmb希望発注納期_木.Size = New System.Drawing.Size(93, 26)
        Me.cmb希望発注納期_木.TabIndex = 29
        Me.cmb希望発注納期_木.Tag = "ID8"
        '
        'cmb希望発注納期_水
        '
        Me.cmb希望発注納期_水.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb希望発注納期_水.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb希望発注納期_水.FormattingEnabled = True
        Me.cmb希望発注納期_水.Location = New System.Drawing.Point(256, 48)
        Me.cmb希望発注納期_水.Name = "cmb希望発注納期_水"
        Me.cmb希望発注納期_水.Size = New System.Drawing.Size(93, 26)
        Me.cmb希望発注納期_水.TabIndex = 28
        Me.cmb希望発注納期_水.Tag = "ID7"
        '
        'cmb希望発注納期_火
        '
        Me.cmb希望発注納期_火.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb希望発注納期_火.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb希望発注納期_火.FormattingEnabled = True
        Me.cmb希望発注納期_火.Location = New System.Drawing.Point(136, 48)
        Me.cmb希望発注納期_火.Name = "cmb希望発注納期_火"
        Me.cmb希望発注納期_火.Size = New System.Drawing.Size(93, 26)
        Me.cmb希望発注納期_火.TabIndex = 27
        Me.cmb希望発注納期_火.Tag = "ID6"
        '
        'cmb希望発注納期_月
        '
        Me.cmb希望発注納期_月.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb希望発注納期_月.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb希望発注納期_月.FormattingEnabled = True
        Me.cmb希望発注納期_月.Location = New System.Drawing.Point(16, 48)
        Me.cmb希望発注納期_月.Name = "cmb希望発注納期_月"
        Me.cmb希望発注納期_月.Size = New System.Drawing.Size(93, 26)
        Me.cmb希望発注納期_月.TabIndex = 26
        Me.cmb希望発注納期_月.Tag = "ID5"
        '
        'lbl希望発注納期_金
        '
        Me.lbl希望発注納期_金.AutoSize = True
        Me.lbl希望発注納期_金.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl希望発注納期_金.Location = New System.Drawing.Point(492, 25)
        Me.lbl希望発注納期_金.Name = "lbl希望発注納期_金"
        Me.lbl希望発注納期_金.Size = New System.Drawing.Size(74, 20)
        Me.lbl希望発注納期_金.TabIndex = 237
        Me.lbl希望発注納期_金.Text = "【金曜日】"
        Me.lbl希望発注納期_金.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl希望発注納期_木
        '
        Me.lbl希望発注納期_木.AutoSize = True
        Me.lbl希望発注納期_木.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl希望発注納期_木.Location = New System.Drawing.Point(372, 25)
        Me.lbl希望発注納期_木.Name = "lbl希望発注納期_木"
        Me.lbl希望発注納期_木.Size = New System.Drawing.Size(74, 20)
        Me.lbl希望発注納期_木.TabIndex = 236
        Me.lbl希望発注納期_木.Text = "【木曜日】"
        Me.lbl希望発注納期_木.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl希望発注納期_水
        '
        Me.lbl希望発注納期_水.AutoSize = True
        Me.lbl希望発注納期_水.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl希望発注納期_水.Location = New System.Drawing.Point(252, 25)
        Me.lbl希望発注納期_水.Name = "lbl希望発注納期_水"
        Me.lbl希望発注納期_水.Size = New System.Drawing.Size(74, 20)
        Me.lbl希望発注納期_水.TabIndex = 235
        Me.lbl希望発注納期_水.Text = "【水曜日】"
        Me.lbl希望発注納期_水.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl希望発注納期_火
        '
        Me.lbl希望発注納期_火.AutoSize = True
        Me.lbl希望発注納期_火.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl希望発注納期_火.Location = New System.Drawing.Point(132, 25)
        Me.lbl希望発注納期_火.Name = "lbl希望発注納期_火"
        Me.lbl希望発注納期_火.Size = New System.Drawing.Size(74, 20)
        Me.lbl希望発注納期_火.TabIndex = 234
        Me.lbl希望発注納期_火.Text = "【火曜日】"
        Me.lbl希望発注納期_火.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl希望発注納期_月
        '
        Me.lbl希望発注納期_月.AutoSize = True
        Me.lbl希望発注納期_月.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl希望発注納期_月.Location = New System.Drawing.Point(12, 25)
        Me.lbl希望発注納期_月.Name = "lbl希望発注納期_月"
        Me.lbl希望発注納期_月.Size = New System.Drawing.Size(74, 20)
        Me.lbl希望発注納期_月.TabIndex = 233
        Me.lbl希望発注納期_月.Text = "【月曜日】"
        Me.lbl希望発注納期_月.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb発注納期設定区分
        '
        Me.cmb発注納期設定区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb発注納期設定区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb発注納期設定区分.FormattingEnabled = True
        Me.cmb発注納期設定区分.Location = New System.Drawing.Point(127, 119)
        Me.cmb発注納期設定区分.Name = "cmb発注納期設定区分"
        Me.cmb発注納期設定区分.Size = New System.Drawing.Size(93, 26)
        Me.cmb発注納期設定区分.TabIndex = 25
        Me.cmb発注納期設定区分.Tag = "ID4"
        '
        'cmb商品手配方法区分
        '
        Me.cmb商品手配方法区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb商品手配方法区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb商品手配方法区分.FormattingEnabled = True
        Me.cmb商品手配方法区分.Location = New System.Drawing.Point(127, 86)
        Me.cmb商品手配方法区分.Name = "cmb商品手配方法区分"
        Me.cmb商品手配方法区分.Size = New System.Drawing.Size(175, 26)
        Me.cmb商品手配方法区分.TabIndex = 24
        Me.cmb商品手配方法区分.Tag = "ID3"
        '
        'cmb商品出荷指示区分
        '
        Me.cmb商品出荷指示区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb商品出荷指示区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb商品出荷指示区分.FormattingEnabled = True
        Me.cmb商品出荷指示区分.Location = New System.Drawing.Point(127, 53)
        Me.cmb商品出荷指示区分.Name = "cmb商品出荷指示区分"
        Me.cmb商品出荷指示区分.Size = New System.Drawing.Size(175, 26)
        Me.cmb商品出荷指示区分.TabIndex = 23
        Me.cmb商品出荷指示区分.Tag = "ID2"
        '
        'lbl明細直送先コード
        '
        Me.lbl明細直送先コード.AutoSize = True
        Me.lbl明細直送先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細直送先コード.Location = New System.Drawing.Point(228, 23)
        Me.lbl明細直送先コード.Name = "lbl明細直送先コード"
        Me.lbl明細直送先コード.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細直送先コード.TabIndex = 223
        Me.lbl明細直送先コード.Text = "【直送先】"
        Me.lbl明細直送先コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt直送先コード
        '
        Me.txt直送先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt直送先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt直送先コード.Format = "9"
        Me.txt直送先コード.HighlightText = True
        Me.txt直送先コード.Location = New System.Drawing.Point(305, 21)
        Me.txt直送先コード.MaxLength = 10
        Me.txt直送先コード.Name = "txt直送先コード"
        Me.txt直送先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt直送先コード.TabIndex = 22
        Me.txt直送先コード.Tag = "ID3"
        '
        'lbl直送先名
        '
        Me.lbl直送先名.AutoEllipsis = True
        Me.lbl直送先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl直送先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl直送先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl直送先名.Location = New System.Drawing.Point(400, 21)
        Me.lbl直送先名.Name = "lbl直送先名"
        Me.lbl直送先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl直送先名.TabIndex = 222
        Me.lbl直送先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID
        '
        Me.lblID.AutoEllipsis = True
        Me.lblID.BackColor = System.Drawing.SystemColors.Control
        Me.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblID.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblID.Location = New System.Drawing.Point(720, 20)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(110, 26)
        Me.lblID.TabIndex = 201
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblID.Visible = False
        '
        'lbl明細商品出荷指示区分
        '
        Me.lbl明細商品出荷指示区分.AutoSize = True
        Me.lbl明細商品出荷指示区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細商品出荷指示区分.Location = New System.Drawing.Point(11, 56)
        Me.lbl明細商品出荷指示区分.Name = "lbl明細商品出荷指示区分"
        Me.lbl明細商品出荷指示区分.Size = New System.Drawing.Size(113, 20)
        Me.lbl明細商品出荷指示区分.TabIndex = 220
        Me.lbl明細商品出荷指示区分.Text = "【商品出荷指示】"
        Me.lbl明細商品出荷指示区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb直送区分
        '
        Me.cmb直送区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb直送区分.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb直送区分.FormattingEnabled = True
        Me.cmb直送区分.Location = New System.Drawing.Point(127, 20)
        Me.cmb直送区分.Name = "cmb直送区分"
        Me.cmb直送区分.Size = New System.Drawing.Size(93, 26)
        Me.cmb直送区分.TabIndex = 21
        Me.cmb直送区分.Tag = "ID1"
        '
        'lbl明細直送区分
        '
        Me.lbl明細直送区分.AutoSize = True
        Me.lbl明細直送区分.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細直送区分.Location = New System.Drawing.Point(63, 23)
        Me.lbl明細直送区分.Name = "lbl明細直送区分"
        Me.lbl明細直送区分.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細直送区分.TabIndex = 169
        Me.lbl明細直送区分.Text = "【直送】"
        Me.lbl明細直送区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.BT_ID5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BT_ID5.Location = New System.Drawing.Point(380, 0)
        Me.BT_ID5.Name = "BT_ID5"
        Me.BT_ID5.Size = New System.Drawing.Size(90, 24)
        Me.BT_ID5.TabIndex = 135
        Me.BT_ID5.Tag = "ID5"
        Me.BT_ID5.Text = "確定(&F5)"
        Me.BT_ID5.UseVisualStyleBackColor = False
        '
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.lbl得意先コード)
        Me.pnl検索.Controls.Add(Me.txt需要先コード)
        Me.pnl検索.Controls.Add(Me.lbl需要先名)
        Me.pnl検索.Controls.Add(Me.txt得意先コード)
        Me.pnl検索.Controls.Add(Me.lbl得意先名)
        Me.pnl検索.Controls.Add(Me.lbl需要先コード)
        Me.pnl検索.Location = New System.Drawing.Point(25, 44)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(955, 70)
        Me.pnl検索.TabIndex = 184
        '
        'lbl得意先コード
        '
        Me.lbl得意先コード.AutoSize = True
        Me.lbl得意先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl得意先コード.Location = New System.Drawing.Point(50, 11)
        Me.lbl得意先コード.Name = "lbl得意先コード"
        Me.lbl得意先コード.Size = New System.Drawing.Size(74, 20)
        Me.lbl得意先コード.TabIndex = 172
        Me.lbl得意先コード.Text = "【得意先】"
        Me.lbl得意先コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt需要先コード
        '
        Me.txt需要先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt需要先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt需要先コード.Format = "9"
        Me.txt需要先コード.HighlightText = True
        Me.txt需要先コード.Location = New System.Drawing.Point(127, 36)
        Me.txt需要先コード.MaxLength = 10
        Me.txt需要先コード.Name = "txt需要先コード"
        Me.txt需要先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt需要先コード.TabIndex = 12
        Me.txt需要先コード.Tag = "ID2"
        '
        'lbl需要先名
        '
        Me.lbl需要先名.AutoEllipsis = True
        Me.lbl需要先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl需要先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl需要先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl需要先名.Location = New System.Drawing.Point(222, 36)
        Me.lbl需要先名.Name = "lbl需要先名"
        Me.lbl需要先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl需要先名.TabIndex = 171
        Me.lbl需要先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt得意先コード
        '
        Me.txt得意先コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt得意先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt得意先コード.Format = "9"
        Me.txt得意先コード.HighlightText = True
        Me.txt得意先コード.Location = New System.Drawing.Point(127, 9)
        Me.txt得意先コード.MaxLength = 10
        Me.txt得意先コード.Name = "txt得意先コード"
        Me.txt得意先コード.Size = New System.Drawing.Size(93, 24)
        Me.txt得意先コード.TabIndex = 11
        Me.txt得意先コード.Tag = "ID1"
        '
        'lbl得意先名
        '
        Me.lbl得意先名.AutoEllipsis = True
        Me.lbl得意先名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl得意先名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl得意先名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl得意先名.Location = New System.Drawing.Point(222, 9)
        Me.lbl得意先名.Name = "lbl得意先名"
        Me.lbl得意先名.Size = New System.Drawing.Size(287, 24)
        Me.lbl得意先名.TabIndex = 169
        Me.lbl得意先名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl需要先コード
        '
        Me.lbl需要先コード.AutoSize = True
        Me.lbl需要先コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl需要先コード.Location = New System.Drawing.Point(50, 38)
        Me.lbl需要先コード.Name = "lbl需要先コード"
        Me.lbl需要先コード.Size = New System.Drawing.Size(74, 20)
        Me.lbl需要先コード.TabIndex = 167
        Me.lbl需要先コード.Text = "【需要先】"
        Me.lbl需要先コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HARK992
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
        Me.Name = "HARK992"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl明細.ResumeLayout(False)
        Me.pnl明細.PerformLayout()
        Me.GB希望発注納期.ResumeLayout(False)
        Me.GB希望発注納期.PerformLayout()
        CType(Me.txt直送先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        CType(Me.txt需要先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt得意先コード, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents lbl明細直送区分 As Label
    Private WithEvents pnl検索 As Panel
    Private WithEvents lbl需要先コード As Label
    Private WithEvents cmb直送区分 As ComboBox
    Private WithEvents lbl明細商品出荷指示区分 As Label
    Private WithEvents lblID As Label
    Private WithEvents txt需要先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl需要先名 As Label
    Private WithEvents txt得意先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl得意先名 As Label
    Private WithEvents lbl得意先コード As Label
    Private WithEvents cmb発注納期設定区分 As ComboBox
    Private WithEvents cmb商品手配方法区分 As ComboBox
    Private WithEvents cmb商品出荷指示区分 As ComboBox
    Private WithEvents lbl明細直送先コード As Label
    Private WithEvents txt直送先コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl直送先名 As Label
    Private WithEvents lbl明細発注納期設定区分 As Label
    Private WithEvents lbl明細商品手配方法区分 As Label
    Private WithEvents GB希望発注納期 As GroupBox
    Private WithEvents lbl希望発注納期_金 As Label
    Private WithEvents lbl希望発注納期_木 As Label
    Private WithEvents lbl希望発注納期_水 As Label
    Private WithEvents lbl希望発注納期_火 As Label
    Private WithEvents lbl希望発注納期_月 As Label
    Private WithEvents cmb希望発注納期_金 As ComboBox
    Private WithEvents cmb希望発注納期_木 As ComboBox
    Private WithEvents cmb希望発注納期_水 As ComboBox
    Private WithEvents cmb希望発注納期_火 As ComboBox
    Private WithEvents cmb希望発注納期_月 As ComboBox

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private Grp希望発注納期() As ComboBox

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxintSPDSystemCode As Integer
    Private xxxstrForTitle As String
    Private xxxint新規区分 As Integer
    Private xxxint直送区分 As Integer
    Private xxxint商品出荷指示区分 As Integer
    Private xxxint商品手配方法区分 As Integer
    Private xxxint発注納期設定区分 As Integer
    Private xxxint直送区分項目数 As Integer
    Private xxxint商品出荷指示区分項目数 As Integer
    Private xxxint商品手配方法区分項目数 As Integer
    Private xxxint発注納期設定区分項目数 As Integer
    Private xxxint希望発注納期項目数 As Integer



    Public Sub New(ByVal PerFormTitle As String, ByVal PerProgramID As String, ByVal PreSubProgramID As Integer, ByVal PreSPDSystemCode As Integer)

        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        xxxstrForTitle = PerFormTitle
        xxxstrProgram_ID = PerProgramID
        xxxintSubProgram_ID = PreSubProgramID
        xxxintSPDSystemCode = PreSPDSystemCode

        '出荷パネル
        Me.Grp希望発注納期 = New ComboBox(5) {}
        Me.Grp希望発注納期(0) = Me.cmb希望発注納期_月
        Me.Grp希望発注納期(1) = Me.cmb希望発注納期_火
        Me.Grp希望発注納期(2) = Me.cmb希望発注納期_水
        Me.Grp希望発注納期(3) = Me.cmb希望発注納期_木
        Me.Grp希望発注納期(4) = Me.cmb希望発注納期_金

        'PreviewKeyDownイベントハンドラの追加
        AddHandler txt得意先コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmb直送区分.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown
        AddHandler cmb希望発注納期_金.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler txt得意先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt需要先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb直送区分.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt直送先コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb商品出荷指示区分.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb商品手配方法区分.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb発注納期設定区分.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb希望発注納期_月.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb希望発注納期_火.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb希望発注納期_水.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb希望発注納期_木.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb直送区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb商品出荷指示区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb商品手配方法区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged
        AddHandler cmb発注納期設定区分.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Validatedイベントハンドラの追加
        AddHandler txt得意先コード.Validated, AddressOf Txt_Validated
        AddHandler txt需要先コード.Validated, AddressOf Txt_Validated
        AddHandler txt直送先コード.Validated, AddressOf Txt_Validated

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
