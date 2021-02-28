'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK501S1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK501S1))
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl明細 = New System.Windows.Forms.Panel()
        Me.txt明細部署名 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl明細部署 = New System.Windows.Forms.Label()
        Me.txt明細部署コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.cmb施設 = New System.Windows.Forms.ComboBox()
        Me.lbl明細施設 = New System.Windows.Forms.Label()
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
        Me.GB_更新 = New System.Windows.Forms.GroupBox()
        Me.RB_新規 = New System.Windows.Forms.RadioButton()
        Me.RB_更新 = New System.Windows.Forms.RadioButton()
        Me.lbl部署コード = New System.Windows.Forms.Label()
        Me.txt部署コード = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl明細.SuspendLayout()
        CType(Me.txt明細部署名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt明細部署コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
        Me.GB_更新.SuspendLayout()
        CType(Me.txt部署コード, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnl明細.Controls.Add(Me.txt明細部署名)
        Me.pnl明細.Controls.Add(Me.lblID)
        Me.pnl明細.Controls.Add(Me.lbl明細部署)
        Me.pnl明細.Controls.Add(Me.txt明細部署コード)
        Me.pnl明細.Controls.Add(Me.cmb施設)
        Me.pnl明細.Controls.Add(Me.lbl明細施設)
        Me.pnl明細.Location = New System.Drawing.Point(25, 128)
        Me.pnl明細.Name = "pnl明細"
        Me.pnl明細.Size = New System.Drawing.Size(955, 302)
        Me.pnl明細.TabIndex = 185
        '
        'txt明細部署名
        '
        Me.txt明細部署名.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt明細部署名.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt明細部署名.Location = New System.Drawing.Point(243, 52)
        Me.txt明細部署名.MaxLength = 60
        Me.txt明細部署名.Name = "txt明細部署名"
        Me.txt明細部署名.Size = New System.Drawing.Size(320, 26)
        Me.txt明細部署名.TabIndex = 23
        Me.txt明細部署名.Tag = "ID3"
        '
        'lblID
        '
        Me.lblID.AutoEllipsis = True
        Me.lblID.BackColor = System.Drawing.SystemColors.Control
        Me.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblID.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblID.Location = New System.Drawing.Point(127, 85)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(110, 26)
        Me.lblID.TabIndex = 201
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblID.Visible = False
        '
        'lbl明細部署
        '
        Me.lbl明細部署.AutoSize = True
        Me.lbl明細部署.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細部署.Location = New System.Drawing.Point(46, 55)
        Me.lbl明細部署.Name = "lbl明細部署"
        Me.lbl明細部署.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細部署.TabIndex = 220
        Me.lbl明細部署.Text = "【部署】"
        Me.lbl明細部署.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt明細部署コード
        '
        Me.txt明細部署コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt明細部署コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt明細部署コード.Format = "A9"
        Me.txt明細部署コード.Location = New System.Drawing.Point(127, 52)
        Me.txt明細部署コード.MaxLength = 10
        Me.txt明細部署コード.Name = "txt明細部署コード"
        Me.txt明細部署コード.Size = New System.Drawing.Size(110, 26)
        Me.txt明細部署コード.TabIndex = 22
        Me.txt明細部署コード.Tag = "ID2"
        '
        'cmb施設
        '
        Me.cmb施設.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb施設.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb施設.FormattingEnabled = True
        Me.cmb施設.Location = New System.Drawing.Point(127, 20)
        Me.cmb施設.Name = "cmb施設"
        Me.cmb施設.Size = New System.Drawing.Size(291, 26)
        Me.cmb施設.TabIndex = 21
        Me.cmb施設.Tag = "ID1"
        '
        'lbl明細施設
        '
        Me.lbl明細施設.AutoSize = True
        Me.lbl明細施設.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細施設.Location = New System.Drawing.Point(46, 23)
        Me.lbl明細施設.Name = "lbl明細施設"
        Me.lbl明細施設.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細施設.TabIndex = 169
        Me.lbl明細施設.Text = "【施設】"
        Me.lbl明細施設.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnl検索.Controls.Add(Me.GB_更新)
        Me.pnl検索.Controls.Add(Me.lbl部署コード)
        Me.pnl検索.Controls.Add(Me.txt部署コード)
        Me.pnl検索.Location = New System.Drawing.Point(25, 44)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(955, 78)
        Me.pnl検索.TabIndex = 184
        '
        'GB_更新
        '
        Me.GB_更新.Controls.Add(Me.RB_新規)
        Me.GB_更新.Controls.Add(Me.RB_更新)
        Me.GB_更新.Location = New System.Drawing.Point(11, -1)
        Me.GB_更新.Name = "GB_更新"
        Me.GB_更新.Size = New System.Drawing.Size(226, 41)
        Me.GB_更新.TabIndex = 168
        Me.GB_更新.TabStop = False
        '
        'RB_新規
        '
        Me.RB_新規.AutoSize = True
        Me.RB_新規.Location = New System.Drawing.Point(132, 16)
        Me.RB_新規.Name = "RB_新規"
        Me.RB_新規.Size = New System.Drawing.Size(47, 16)
        Me.RB_新規.TabIndex = 102
        Me.RB_新規.Text = "新規"
        Me.RB_新規.UseVisualStyleBackColor = True
        '
        'RB_更新
        '
        Me.RB_更新.AutoSize = True
        Me.RB_更新.Location = New System.Drawing.Point(39, 16)
        Me.RB_更新.Name = "RB_更新"
        Me.RB_更新.Size = New System.Drawing.Size(47, 16)
        Me.RB_更新.TabIndex = 101
        Me.RB_更新.Text = "更新"
        Me.RB_更新.UseVisualStyleBackColor = True
        '
        'lbl部署コード
        '
        Me.lbl部署コード.AutoSize = True
        Me.lbl部署コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl部署コード.Location = New System.Drawing.Point(7, 48)
        Me.lbl部署コード.Name = "lbl部署コード"
        Me.lbl部署コード.Size = New System.Drawing.Size(100, 20)
        Me.lbl部署コード.TabIndex = 167
        Me.lbl部署コード.Text = "【部署コード】"
        Me.lbl部署コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt部署コード
        '
        Me.txt部署コード.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt部署コード.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt部署コード.Format = "A9"
        Me.txt部署コード.Location = New System.Drawing.Point(127, 45)
        Me.txt部署コード.MaxLength = 10
        Me.txt部署コード.Name = "txt部署コード"
        Me.txt部署コード.Size = New System.Drawing.Size(110, 26)
        Me.txt部署コード.TabIndex = 11
        Me.txt部署コード.Tag = "ID1"
        '
        'HARK501S1
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
        Me.Name = "HARK501S1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl明細.ResumeLayout(False)
        Me.pnl明細.PerformLayout()
        CType(Me.txt明細部署名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt明細部署コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        Me.GB_更新.ResumeLayout(False)
        Me.GB_更新.PerformLayout()
        CType(Me.txt部署コード, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents lbl明細施設 As Label
    Private WithEvents pnl検索 As Panel
    Private WithEvents txt部署コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl部署コード As Label
    Private WithEvents txt明細部署コード As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents cmb施設 As ComboBox
    Private WithEvents lbl明細部署 As Label
    Private WithEvents lblID As Label
    Private WithEvents txt明細部署名 As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents GB_更新 As GroupBox
    Private WithEvents RB_新規 As RadioButton
    Private WithEvents RB_更新 As RadioButton

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxintSPDSystemCode As Integer
    Private xxxstrForTitle As String
    Private xxxstr病院コード As String
    Private xxxstr施設コード As String


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
        AddHandler txt部署コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txt明細部署コード.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txt明細部署名.PreviewKeyDown, AddressOf Txt_PreviewKeyDown

        'PreviewKeyDownイベントハンドラの追加
        AddHandler cmb施設.PreviewKeyDown, AddressOf Cmb_PreviewKeyDown

        'KeyDownイベントハンドラの追加
        AddHandler txt部署コード.KeyDown, AddressOf Txt_KeyDown
        AddHandler cmb施設.KeyDown, AddressOf Txt_KeyDown
        AddHandler txt明細部署コード.KeyDown, AddressOf Txt_KeyDown

        'SelectedValueChangedイベントハンドラの追加
        AddHandler cmb施設.SelectedValueChanged, AddressOf Cmb_SelectedValueChanged

        'Validatedイベントハンドラの追加
        AddHandler txt部署コード.Validated, AddressOf Txt_Validated

        'Rb_CheckedChanged
        AddHandler RB_更新.CheckedChanged, AddressOf Rb_CheckedChanged
        AddHandler RB_新規.CheckedChanged, AddressOf Rb_CheckedChanged


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
