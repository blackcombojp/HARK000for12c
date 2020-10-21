'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK301S1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK301S1))
        Me.Menu_Log = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ErrorLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_ID4 = New GrapeCity.Win.Buttons.GcSplitButton()
        Me.pnl明細 = New System.Windows.Forms.Panel()
        Me.lbl単位 = New System.Windows.Forms.Label()
        Me.lbl出荷数量 = New System.Windows.Forms.Label()
        Me.lbl受注形態 = New System.Windows.Forms.Label()
        Me.lbl出荷日 = New System.Windows.Forms.Label()
        Me.lbl部署 = New System.Windows.Forms.Label()
        Me.lbl需要先 = New System.Windows.Forms.Label()
        Me.lbl注意 = New System.Windows.Forms.Label()
        Me.lbl明細１７ = New System.Windows.Forms.Label()
        Me.lbl明細１６ = New System.Windows.Forms.Label()
        Me.lbl明細１５ = New System.Windows.Forms.Label()
        Me.lbl明細１４ = New System.Windows.Forms.Label()
        Me.lbl明細１３ = New System.Windows.Forms.Label()
        Me.lbl消費日 = New System.Windows.Forms.Label()
        Me.lbl消費部署 = New System.Windows.Forms.Label()
        Me.lbl消費需要先 = New System.Windows.Forms.Label()
        Me.lbl有効期限 = New System.Windows.Forms.Label()
        Me.lblシリアル = New System.Windows.Forms.Label()
        Me.lblロット = New System.Windows.Forms.Label()
        Me.lbl明細１１ = New System.Windows.Forms.Label()
        Me.lbl明細１０ = New System.Windows.Forms.Label()
        Me.lbl明細９ = New System.Windows.Forms.Label()
        Me.lbl明細８ = New System.Windows.Forms.Label()
        Me.lbl規格 = New System.Windows.Forms.Label()
        Me.lbl商品名 = New System.Windows.Forms.Label()
        Me.lblメーカ = New System.Windows.Forms.Label()
        Me.lblメーカ品番 = New System.Windows.Forms.Label()
        Me.lbl商品コード = New System.Windows.Forms.Label()
        Me.lbl明細７ = New System.Windows.Forms.Label()
        Me.lbl明細１２ = New System.Windows.Forms.Label()
        Me.lbl明細６ = New System.Windows.Forms.Label()
        Me.lbl明細２ = New System.Windows.Forms.Label()
        Me.lbl明細３ = New System.Windows.Forms.Label()
        Me.lbl明細４ = New System.Windows.Forms.Label()
        Me.lbl明細５ = New System.Windows.Forms.Label()
        Me.lbl明細１ = New System.Windows.Forms.Label()
        Me.txtDate = New GrapeCity.Win.Editors.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl抹消日 = New System.Windows.Forms.Label()
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
        Me.ExcelCreator = New AdvanceSoftware.ExcelCreator.Creator(Me.components)
        Me.pnl検索 = New System.Windows.Forms.Panel()
        Me.lbl長期貸出番号 = New System.Windows.Forms.Label()
        Me.txt長期貸出番号 = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.CntMenuStrip.SuspendLayout()
        Me.pnl明細.SuspendLayout()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl検索.SuspendLayout()
        CType(Me.txt長期貸出番号, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnl明細.Controls.Add(Me.lbl単位)
        Me.pnl明細.Controls.Add(Me.lbl出荷数量)
        Me.pnl明細.Controls.Add(Me.lbl受注形態)
        Me.pnl明細.Controls.Add(Me.lbl出荷日)
        Me.pnl明細.Controls.Add(Me.lbl部署)
        Me.pnl明細.Controls.Add(Me.lbl需要先)
        Me.pnl明細.Controls.Add(Me.lbl注意)
        Me.pnl明細.Controls.Add(Me.lbl明細１７)
        Me.pnl明細.Controls.Add(Me.lbl明細１６)
        Me.pnl明細.Controls.Add(Me.lbl明細１５)
        Me.pnl明細.Controls.Add(Me.lbl明細１４)
        Me.pnl明細.Controls.Add(Me.lbl明細１３)
        Me.pnl明細.Controls.Add(Me.lbl消費日)
        Me.pnl明細.Controls.Add(Me.lbl消費部署)
        Me.pnl明細.Controls.Add(Me.lbl消費需要先)
        Me.pnl明細.Controls.Add(Me.lbl有効期限)
        Me.pnl明細.Controls.Add(Me.lblシリアル)
        Me.pnl明細.Controls.Add(Me.lblロット)
        Me.pnl明細.Controls.Add(Me.lbl明細１１)
        Me.pnl明細.Controls.Add(Me.lbl明細１０)
        Me.pnl明細.Controls.Add(Me.lbl明細９)
        Me.pnl明細.Controls.Add(Me.lbl明細８)
        Me.pnl明細.Controls.Add(Me.lbl規格)
        Me.pnl明細.Controls.Add(Me.lbl商品名)
        Me.pnl明細.Controls.Add(Me.lblメーカ)
        Me.pnl明細.Controls.Add(Me.lblメーカ品番)
        Me.pnl明細.Controls.Add(Me.lbl商品コード)
        Me.pnl明細.Controls.Add(Me.lbl明細７)
        Me.pnl明細.Controls.Add(Me.lbl明細１２)
        Me.pnl明細.Controls.Add(Me.lbl明細６)
        Me.pnl明細.Controls.Add(Me.lbl明細２)
        Me.pnl明細.Controls.Add(Me.lbl明細３)
        Me.pnl明細.Controls.Add(Me.lbl明細４)
        Me.pnl明細.Controls.Add(Me.lbl明細５)
        Me.pnl明細.Controls.Add(Me.lbl明細１)
        Me.pnl明細.Controls.Add(Me.txtDate)
        Me.pnl明細.Controls.Add(Me.lbl抹消日)
        Me.pnl明細.Location = New System.Drawing.Point(25, 96)
        Me.pnl明細.Name = "pnl明細"
        Me.pnl明細.Size = New System.Drawing.Size(985, 334)
        Me.pnl明細.TabIndex = 185
        '
        'lbl単位
        '
        Me.lbl単位.AutoEllipsis = True
        Me.lbl単位.BackColor = System.Drawing.SystemColors.Control
        Me.lbl単位.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl単位.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl単位.Location = New System.Drawing.Point(660, 119)
        Me.lbl単位.Name = "lbl単位"
        Me.lbl単位.Size = New System.Drawing.Size(48, 24)
        Me.lbl単位.TabIndex = 189
        Me.lbl単位.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl出荷数量
        '
        Me.lbl出荷数量.AutoEllipsis = True
        Me.lbl出荷数量.BackColor = System.Drawing.SystemColors.Control
        Me.lbl出荷数量.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl出荷数量.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl出荷数量.Location = New System.Drawing.Point(590, 119)
        Me.lbl出荷数量.Name = "lbl出荷数量"
        Me.lbl出荷数量.Size = New System.Drawing.Size(68, 24)
        Me.lbl出荷数量.TabIndex = 188
        Me.lbl出荷数量.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl受注形態
        '
        Me.lbl受注形態.AutoEllipsis = True
        Me.lbl受注形態.BackColor = System.Drawing.SystemColors.Control
        Me.lbl受注形態.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl受注形態.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl受注形態.Location = New System.Drawing.Point(510, 119)
        Me.lbl受注形態.Name = "lbl受注形態"
        Me.lbl受注形態.Size = New System.Drawing.Size(78, 24)
        Me.lbl受注形態.TabIndex = 187
        Me.lbl受注形態.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl出荷日
        '
        Me.lbl出荷日.AutoEllipsis = True
        Me.lbl出荷日.BackColor = System.Drawing.SystemColors.Control
        Me.lbl出荷日.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl出荷日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl出荷日.Location = New System.Drawing.Point(420, 119)
        Me.lbl出荷日.Name = "lbl出荷日"
        Me.lbl出荷日.Size = New System.Drawing.Size(88, 24)
        Me.lbl出荷日.TabIndex = 186
        Me.lbl出荷日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl部署
        '
        Me.lbl部署.AutoEllipsis = True
        Me.lbl部署.BackColor = System.Drawing.SystemColors.Control
        Me.lbl部署.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl部署.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl部署.Location = New System.Drawing.Point(230, 119)
        Me.lbl部署.Name = "lbl部署"
        Me.lbl部署.Size = New System.Drawing.Size(188, 24)
        Me.lbl部署.TabIndex = 185
        Me.lbl部署.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl需要先
        '
        Me.lbl需要先.AutoEllipsis = True
        Me.lbl需要先.BackColor = System.Drawing.SystemColors.Control
        Me.lbl需要先.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl需要先.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl需要先.Location = New System.Drawing.Point(10, 119)
        Me.lbl需要先.Name = "lbl需要先"
        Me.lbl需要先.Size = New System.Drawing.Size(218, 24)
        Me.lbl需要先.TabIndex = 184
        Me.lbl需要先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl注意
        '
        Me.lbl注意.AutoSize = True
        Me.lbl注意.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl注意.ForeColor = System.Drawing.Color.Red
        Me.lbl注意.Location = New System.Drawing.Point(11, 208)
        Me.lbl注意.Name = "lbl注意"
        Me.lbl注意.Size = New System.Drawing.Size(400, 23)
        Me.lbl注意.TabIndex = 218
        Me.lbl注意.Text = "※当日出荷した番号の抹消は翌日以降に処理してください"
        Me.lbl注意.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１７
        '
        Me.lbl明細１７.AutoSize = True
        Me.lbl明細１７.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１７.Location = New System.Drawing.Point(810, 97)
        Me.lbl明細１７.Name = "lbl明細１７"
        Me.lbl明細１７.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細１７.TabIndex = 216
        Me.lbl明細１７.Text = "消費日"
        Me.lbl明細１７.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１６
        '
        Me.lbl明細１６.AutoSize = True
        Me.lbl明細１６.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１６.Location = New System.Drawing.Point(620, 97)
        Me.lbl明細１６.Name = "lbl明細１６"
        Me.lbl明細１６.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細１６.TabIndex = 215
        Me.lbl明細１６.Text = "消費部署"
        Me.lbl明細１６.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１５
        '
        Me.lbl明細１５.AutoSize = True
        Me.lbl明細１５.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１５.Location = New System.Drawing.Point(400, 99)
        Me.lbl明細１５.Name = "lbl明細１５"
        Me.lbl明細１５.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細１５.TabIndex = 214
        Me.lbl明細１５.Text = "消費需要先"
        Me.lbl明細１５.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１４
        '
        Me.lbl明細１４.AutoSize = True
        Me.lbl明細１４.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１４.Location = New System.Drawing.Point(310, 99)
        Me.lbl明細１４.Name = "lbl明細１４"
        Me.lbl明細１４.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細１４.TabIndex = 213
        Me.lbl明細１４.Text = "有効期限"
        Me.lbl明細１４.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１３
        '
        Me.lbl明細１３.AutoSize = True
        Me.lbl明細１３.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１３.Location = New System.Drawing.Point(160, 99)
        Me.lbl明細１３.Name = "lbl明細１３"
        Me.lbl明細１３.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細１３.TabIndex = 212
        Me.lbl明細１３.Text = "シリアル"
        Me.lbl明細１３.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl消費日
        '
        Me.lbl消費日.AutoEllipsis = True
        Me.lbl消費日.BackColor = System.Drawing.SystemColors.Control
        Me.lbl消費日.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl消費日.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl消費日.Location = New System.Drawing.Point(810, 171)
        Me.lbl消費日.Name = "lbl消費日"
        Me.lbl消費日.Size = New System.Drawing.Size(88, 24)
        Me.lbl消費日.TabIndex = 211
        Me.lbl消費日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl消費部署
        '
        Me.lbl消費部署.AutoEllipsis = True
        Me.lbl消費部署.BackColor = System.Drawing.SystemColors.Control
        Me.lbl消費部署.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl消費部署.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl消費部署.Location = New System.Drawing.Point(620, 171)
        Me.lbl消費部署.Name = "lbl消費部署"
        Me.lbl消費部署.Size = New System.Drawing.Size(188, 24)
        Me.lbl消費部署.TabIndex = 210
        Me.lbl消費部署.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl消費需要先
        '
        Me.lbl消費需要先.AutoEllipsis = True
        Me.lbl消費需要先.BackColor = System.Drawing.SystemColors.Control
        Me.lbl消費需要先.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl消費需要先.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl消費需要先.Location = New System.Drawing.Point(400, 171)
        Me.lbl消費需要先.Name = "lbl消費需要先"
        Me.lbl消費需要先.Size = New System.Drawing.Size(218, 24)
        Me.lbl消費需要先.TabIndex = 209
        Me.lbl消費需要先.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl有効期限
        '
        Me.lbl有効期限.AutoEllipsis = True
        Me.lbl有効期限.BackColor = System.Drawing.SystemColors.Control
        Me.lbl有効期限.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl有効期限.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl有効期限.Location = New System.Drawing.Point(310, 171)
        Me.lbl有効期限.Name = "lbl有効期限"
        Me.lbl有効期限.Size = New System.Drawing.Size(88, 24)
        Me.lbl有効期限.TabIndex = 208
        Me.lbl有効期限.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblシリアル
        '
        Me.lblシリアル.AutoEllipsis = True
        Me.lblシリアル.BackColor = System.Drawing.SystemColors.Control
        Me.lblシリアル.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblシリアル.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblシリアル.Location = New System.Drawing.Point(160, 171)
        Me.lblシリアル.Name = "lblシリアル"
        Me.lblシリアル.Size = New System.Drawing.Size(148, 24)
        Me.lblシリアル.TabIndex = 207
        Me.lblシリアル.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblロット
        '
        Me.lblロット.AutoEllipsis = True
        Me.lblロット.BackColor = System.Drawing.SystemColors.Control
        Me.lblロット.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblロット.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblロット.Location = New System.Drawing.Point(10, 171)
        Me.lblロット.Name = "lblロット"
        Me.lblロット.Size = New System.Drawing.Size(148, 24)
        Me.lblロット.TabIndex = 206
        Me.lblロット.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１１
        '
        Me.lbl明細１１.AutoSize = True
        Me.lbl明細１１.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１１.Location = New System.Drawing.Point(710, 77)
        Me.lbl明細１１.Name = "lbl明細１１"
        Me.lbl明細１１.Size = New System.Drawing.Size(35, 20)
        Me.lbl明細１１.TabIndex = 205
        Me.lbl明細１１.Text = "規格"
        Me.lbl明細１１.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１０
        '
        Me.lbl明細１０.AutoSize = True
        Me.lbl明細１０.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１０.Location = New System.Drawing.Point(460, 77)
        Me.lbl明細１０.Name = "lbl明細１０"
        Me.lbl明細１０.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細１０.TabIndex = 204
        Me.lbl明細１０.Text = "商品名"
        Me.lbl明細１０.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細９
        '
        Me.lbl明細９.AutoSize = True
        Me.lbl明細９.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細９.Location = New System.Drawing.Point(310, 77)
        Me.lbl明細９.Name = "lbl明細９"
        Me.lbl明細９.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細９.TabIndex = 203
        Me.lbl明細９.Text = "メーカ"
        Me.lbl明細９.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細８
        '
        Me.lbl明細８.AutoSize = True
        Me.lbl明細８.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細８.Location = New System.Drawing.Point(100, 77)
        Me.lbl明細８.Name = "lbl明細８"
        Me.lbl明細８.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細８.TabIndex = 202
        Me.lbl明細８.Text = "メーカ品番"
        Me.lbl明細８.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl規格
        '
        Me.lbl規格.AutoEllipsis = True
        Me.lbl規格.BackColor = System.Drawing.SystemColors.Control
        Me.lbl規格.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl規格.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl規格.Location = New System.Drawing.Point(710, 145)
        Me.lbl規格.Name = "lbl規格"
        Me.lbl規格.Size = New System.Drawing.Size(258, 24)
        Me.lbl規格.TabIndex = 201
        Me.lbl規格.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl商品名
        '
        Me.lbl商品名.AutoEllipsis = True
        Me.lbl商品名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl商品名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl商品名.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl商品名.Location = New System.Drawing.Point(460, 145)
        Me.lbl商品名.Name = "lbl商品名"
        Me.lbl商品名.Size = New System.Drawing.Size(248, 24)
        Me.lbl商品名.TabIndex = 200
        Me.lbl商品名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblメーカ
        '
        Me.lblメーカ.AutoEllipsis = True
        Me.lblメーカ.BackColor = System.Drawing.SystemColors.Control
        Me.lblメーカ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblメーカ.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblメーカ.Location = New System.Drawing.Point(310, 145)
        Me.lblメーカ.Name = "lblメーカ"
        Me.lblメーカ.Size = New System.Drawing.Size(148, 24)
        Me.lblメーカ.TabIndex = 199
        Me.lblメーカ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblメーカ品番
        '
        Me.lblメーカ品番.AutoEllipsis = True
        Me.lblメーカ品番.BackColor = System.Drawing.SystemColors.Control
        Me.lblメーカ品番.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblメーカ品番.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblメーカ品番.Location = New System.Drawing.Point(100, 145)
        Me.lblメーカ品番.Name = "lblメーカ品番"
        Me.lblメーカ品番.Size = New System.Drawing.Size(208, 24)
        Me.lblメーカ品番.TabIndex = 198
        Me.lblメーカ品番.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl商品コード
        '
        Me.lbl商品コード.AutoEllipsis = True
        Me.lbl商品コード.BackColor = System.Drawing.SystemColors.Control
        Me.lbl商品コード.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl商品コード.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl商品コード.Location = New System.Drawing.Point(10, 145)
        Me.lbl商品コード.Name = "lbl商品コード"
        Me.lbl商品コード.Size = New System.Drawing.Size(88, 24)
        Me.lbl商品コード.TabIndex = 197
        Me.lbl商品コード.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細７
        '
        Me.lbl明細７.AutoSize = True
        Me.lbl明細７.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細７.Location = New System.Drawing.Point(10, 77)
        Me.lbl明細７.Name = "lbl明細７"
        Me.lbl明細７.Size = New System.Drawing.Size(74, 20)
        Me.lbl明細７.TabIndex = 196
        Me.lbl明細７.Text = "商品コード"
        Me.lbl明細７.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１２
        '
        Me.lbl明細１２.AutoSize = True
        Me.lbl明細１２.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１２.Location = New System.Drawing.Point(10, 97)
        Me.lbl明細１２.Name = "lbl明細１２"
        Me.lbl明細１２.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細１２.TabIndex = 195
        Me.lbl明細１２.Text = "ロット"
        Me.lbl明細１２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細６
        '
        Me.lbl明細６.AutoSize = True
        Me.lbl明細６.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細６.Location = New System.Drawing.Point(660, 57)
        Me.lbl明細６.Name = "lbl明細６"
        Me.lbl明細６.Size = New System.Drawing.Size(35, 20)
        Me.lbl明細６.TabIndex = 194
        Me.lbl明細６.Text = "単位"
        Me.lbl明細６.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細２
        '
        Me.lbl明細２.AutoSize = True
        Me.lbl明細２.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細２.Location = New System.Drawing.Point(230, 57)
        Me.lbl明細２.Name = "lbl明細２"
        Me.lbl明細２.Size = New System.Drawing.Size(35, 20)
        Me.lbl明細２.TabIndex = 193
        Me.lbl明細２.Text = "部署"
        Me.lbl明細２.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細３
        '
        Me.lbl明細３.AutoSize = True
        Me.lbl明細３.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細３.Location = New System.Drawing.Point(420, 57)
        Me.lbl明細３.Name = "lbl明細３"
        Me.lbl明細３.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細３.TabIndex = 192
        Me.lbl明細３.Text = "出荷日"
        Me.lbl明細３.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細４
        '
        Me.lbl明細４.AutoSize = True
        Me.lbl明細４.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細４.Location = New System.Drawing.Point(510, 57)
        Me.lbl明細４.Name = "lbl明細４"
        Me.lbl明細４.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細４.TabIndex = 191
        Me.lbl明細４.Text = "受注形態"
        Me.lbl明細４.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細５
        '
        Me.lbl明細５.AutoSize = True
        Me.lbl明細５.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細５.Location = New System.Drawing.Point(590, 57)
        Me.lbl明細５.Name = "lbl明細５"
        Me.lbl明細５.Size = New System.Drawing.Size(61, 20)
        Me.lbl明細５.TabIndex = 190
        Me.lbl明細５.Text = "出荷数量"
        Me.lbl明細５.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl明細１
        '
        Me.lbl明細１.AutoSize = True
        Me.lbl明細１.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl明細１.Location = New System.Drawing.Point(10, 57)
        Me.lbl明細１.Name = "lbl明細１"
        Me.lbl明細１.Size = New System.Drawing.Size(48, 20)
        Me.lbl明細１.TabIndex = 171
        Me.lbl明細１.Text = "需要先"
        Me.lbl明細１.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDate
        '
        Me.txtDate.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.txtDate.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.txtDate.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtDate.Location = New System.Drawing.Point(130, 9)
        Me.txtDate.MaxDate = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txtDate.MaxValue = New Date(2999, 12, 31, 23, 59, 59, 0)
        Me.txtDate.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtDate.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.txtDate.Size = New System.Drawing.Size(118, 26)
        Me.txtDate.TabIndex = 21
        Me.txtDate.Tag = "ID1"
        Me.txtDate.Value = Nothing
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl抹消日
        '
        Me.lbl抹消日.AutoSize = True
        Me.lbl抹消日.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl抹消日.Location = New System.Drawing.Point(7, 12)
        Me.lbl抹消日.Name = "lbl抹消日"
        Me.lbl抹消日.Size = New System.Drawing.Size(74, 20)
        Me.lbl抹消日.TabIndex = 169
        Me.lbl抹消日.Text = "【抹消日】"
        Me.lbl抹消日.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'pnl検索
        '
        Me.pnl検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnl検索.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl検索.Controls.Add(Me.lbl長期貸出番号)
        Me.pnl検索.Controls.Add(Me.txt長期貸出番号)
        Me.pnl検索.Location = New System.Drawing.Point(25, 44)
        Me.pnl検索.Name = "pnl検索"
        Me.pnl検索.Size = New System.Drawing.Size(985, 46)
        Me.pnl検索.TabIndex = 184
        '
        'lbl長期貸出番号
        '
        Me.lbl長期貸出番号.AutoSize = True
        Me.lbl長期貸出番号.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl長期貸出番号.Location = New System.Drawing.Point(7, 12)
        Me.lbl長期貸出番号.Name = "lbl長期貸出番号"
        Me.lbl長期貸出番号.Size = New System.Drawing.Size(113, 20)
        Me.lbl長期貸出番号.TabIndex = 167
        Me.lbl長期貸出番号.Text = "【長期貸出番号】"
        Me.lbl長期貸出番号.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt長期貸出番号
        '
        Me.txt長期貸出番号.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.txt長期貸出番号.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt長期貸出番号.Format = "9"
        Me.txt長期貸出番号.Location = New System.Drawing.Point(130, 10)
        Me.txt長期貸出番号.MaxLength = 13
        Me.txt長期貸出番号.Name = "txt長期貸出番号"
        Me.txt長期貸出番号.Size = New System.Drawing.Size(118, 24)
        Me.txt長期貸出番号.TabIndex = 11
        Me.txt長期貸出番号.Tag = "ID1"
        '
        'HARK301S1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1022, 457)
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
        Me.Name = "HARK301S1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMTITLE"
        Me.CntMenuStrip.ResumeLayout(False)
        Me.pnl明細.ResumeLayout(False)
        Me.pnl明細.PerformLayout()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBar_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SttBarPnl_Err, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl検索.ResumeLayout(False)
        Me.pnl検索.PerformLayout()
        CType(Me.txt長期貸出番号, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents ExcelCreator As AdvanceSoftware.ExcelCreator.Creator
    Private WithEvents txtDate As GrapeCity.Win.Editors.GcDate
    Private WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Private WithEvents lbl抹消日 As Label
    Private WithEvents lbl明細１ As Label
    Private WithEvents pnl検索 As Panel
    Private WithEvents lbl長期貸出番号 As Label
    Private WithEvents txt長期貸出番号 As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents lbl規格 As Label
    Private WithEvents lbl商品名 As Label
    Private WithEvents lblメーカ As Label
    Private WithEvents lblメーカ品番 As Label
    Private WithEvents lbl商品コード As Label
    Private WithEvents lbl明細７ As Label
    Private WithEvents lbl明細１２ As Label
    Private WithEvents lbl明細６ As Label
    Private WithEvents lbl明細２ As Label
    Private WithEvents lbl明細３ As Label
    Private WithEvents lbl明細４ As Label
    Private WithEvents lbl明細５ As Label
    Private WithEvents lbl単位 As Label
    Private WithEvents lbl出荷数量 As Label
    Private WithEvents lbl受注形態 As Label
    Private WithEvents lbl出荷日 As Label
    Private WithEvents lbl部署 As Label
    Private WithEvents lbl需要先 As Label
    Private WithEvents lbl明細１７ As Label
    Private WithEvents lbl明細１６ As Label
    Private WithEvents lbl明細１５ As Label
    Private WithEvents lbl明細１４ As Label
    Private WithEvents lbl明細１３ As Label
    Private WithEvents lbl消費日 As Label
    Private WithEvents lbl消費部署 As Label
    Private WithEvents lbl消費需要先 As Label
    Private WithEvents lbl有効期限 As Label
    Private WithEvents lblシリアル As Label
    Private WithEvents lblロット As Label
    Private WithEvents lbl明細１１ As Label
    Private WithEvents lbl明細１０ As Label
    Private WithEvents lbl明細９ As Label
    Private WithEvents lbl明細８ As Label
    Private WithEvents lbl注意 As Label

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private xxxstrProgram_ID As String
    Private xxxintSubProgram_ID As Integer
    Private xxxintSPDSystemCode As Integer
    Private xxxstrForTitle As String
    Private xxxint事業所コード As Integer
    Private xxxstr担当者名 As String
    Private xxxlng需要先コード As Long
    'Private xxxintCnt(3) As Integer
    'Private xxxintNo As Integer


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
        AddHandler txt長期貸出番号.PreviewKeyDown, AddressOf Txt_PreviewKeyDown
        AddHandler txtDate.PreviewKeyDown, AddressOf Txt_PreviewKeyDown2

        'KeyDownイベントハンドラの追加
        AddHandler txt長期貸出番号.KeyDown, AddressOf Txt_KeyDown
        'AddHandler txtDate.KeyDown, AddressOf Txt_KeyDown

        'Validatedイベントハンドラの追加
        AddHandler txt長期貸出番号.Validated, AddressOf Txt_Validated

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
