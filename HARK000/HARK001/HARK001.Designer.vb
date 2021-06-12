'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Imports NAppUpdate.Framework

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HARK001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HARK001))
        Me.pnlSide = New System.Windows.Forms.Panel()
        Me.lblタイトル = New GrapeCity.Win.Buttons.GcLabel()
        Me.pic最大化 = New System.Windows.Forms.PictureBox()
        Me.pic最小化 = New System.Windows.Forms.PictureBox()
        Me.pic終了 = New System.Windows.Forms.PictureBox()
        Me.pnlOnSideBtn = New System.Windows.Forms.Panel()
        Me.btnSide01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnSide02 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnSide03 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnSide04 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnSide05 = New GrapeCity.Win.Buttons.GcButton()
        Me.btnSide99 = New GrapeCity.Win.Buttons.GcButton()
        Me.Btn終了 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblマシン名 = New GrapeCity.Win.Buttons.GcLabel()
        Me.lblバージョン = New GrapeCity.Win.Buttons.GcLabel()
        Me.lbl事業所 = New GrapeCity.Win.Buttons.GcLabel()
        Me.pnl受注 = New System.Windows.Forms.Panel()
        Me.btn受注07 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注02 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注03 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注04 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注05 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn受注06 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnl受注02 = New System.Windows.Forms.Panel()
        Me.pnl受注03 = New System.Windows.Forms.Panel()
        Me.pnl受注04 = New System.Windows.Forms.Panel()
        Me.pnl出荷 = New System.Windows.Forms.Panel()
        Me.btn出荷01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn出荷02 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn出荷03 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnl請求 = New System.Windows.Forms.Panel()
        Me.btn請求03 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn請求01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn請求02 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnl管理 = New System.Windows.Forms.Panel()
        Me.btn管理02 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn管理01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn管理03 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn管理04 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn管理05 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnlお知らせ = New System.Windows.Forms.Panel()
        Me.lblマニュアル = New System.Windows.Forms.LinkLabel()
        Me.txtお知らせ = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.lblDebug = New GrapeCity.Win.Buttons.GcLabel()
        Me.wbrお知らせ = New System.Windows.Forms.WebBrowser()
        Me.lblお知らせ = New GrapeCity.Win.Buttons.GcLabel()
        Me.pnl売上 = New System.Windows.Forms.Panel()
        Me.btn売上04 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn売上01 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn売上02 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn売上03 = New GrapeCity.Win.Buttons.GcButton()
        Me.btn管理06 = New GrapeCity.Win.Buttons.GcButton()
        Me.pnlSide.SuspendLayout()
        CType(Me.pic最大化, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic最小化, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic終了, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.pnl受注.SuspendLayout()
        Me.pnl出荷.SuspendLayout()
        Me.pnl請求.SuspendLayout()
        Me.pnl管理.SuspendLayout()
        Me.pnlお知らせ.SuspendLayout()
        CType(Me.txtお知らせ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl売上.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSide
        '
        Me.pnlSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlSide.Controls.Add(Me.lblタイトル)
        Me.pnlSide.Controls.Add(Me.pic最大化)
        Me.pnlSide.Controls.Add(Me.pic最小化)
        Me.pnlSide.Controls.Add(Me.pic終了)
        Me.pnlSide.Controls.Add(Me.pnlOnSideBtn)
        Me.pnlSide.Controls.Add(Me.btnSide01)
        Me.pnlSide.Controls.Add(Me.btnSide02)
        Me.pnlSide.Controls.Add(Me.btnSide03)
        Me.pnlSide.Controls.Add(Me.btnSide04)
        Me.pnlSide.Controls.Add(Me.btnSide05)
        Me.pnlSide.Controls.Add(Me.btnSide99)
        Me.pnlSide.Controls.Add(Me.Btn終了)
        Me.pnlSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSide.Location = New System.Drawing.Point(0, 0)
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.Size = New System.Drawing.Size(200, 768)
        Me.pnlSide.TabIndex = 0
        '
        'lblタイトル
        '
        Me.lblタイトル.AutoSize = True
        Me.lblタイトル.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblタイトル.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblタイトル.Location = New System.Drawing.Point(6, 40)
        Me.lblタイトル.Name = "lblタイトル"
        Me.lblタイトル.Size = New System.Drawing.Size(189, 71)
        Me.lblタイトル.TabIndex = 12
        Me.lblタイトル.Text = "SPDツール" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for Aptage.MD2"
        Me.lblタイトル.TextHAlign = GrapeCity.Win.Common.TextHAlign.Center
        Me.lblタイトル.WrapMode = GrapeCity.Win.Common.TextWrapMode.CrLfWrap
        '
        'pic最大化
        '
        Me.pic最大化.BackgroundImage = Global.HARK000.My.Resources.Resources.maximize
        Me.pic最大化.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic最大化.Location = New System.Drawing.Point(57, 3)
        Me.pic最大化.Name = "pic最大化"
        Me.pic最大化.Size = New System.Drawing.Size(21, 21)
        Me.pic最大化.TabIndex = 11
        Me.pic最大化.TabStop = False
        '
        'pic最小化
        '
        Me.pic最小化.BackgroundImage = Global.HARK000.My.Resources.Resources.minimize
        Me.pic最小化.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic最小化.Location = New System.Drawing.Point(30, 3)
        Me.pic最小化.Name = "pic最小化"
        Me.pic最小化.Size = New System.Drawing.Size(21, 21)
        Me.pic最小化.TabIndex = 10
        Me.pic最小化.TabStop = False
        '
        'pic終了
        '
        Me.pic終了.BackgroundImage = Global.HARK000.My.Resources.Resources.logout
        Me.pic終了.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic終了.Location = New System.Drawing.Point(3, 3)
        Me.pic終了.Name = "pic終了"
        Me.pic終了.Size = New System.Drawing.Size(21, 21)
        Me.pic終了.TabIndex = 9
        Me.pic終了.TabStop = False
        '
        'pnlOnSideBtn
        '
        Me.pnlOnSideBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlOnSideBtn.Location = New System.Drawing.Point(0, 157)
        Me.pnlOnSideBtn.Name = "pnlOnSideBtn"
        Me.pnlOnSideBtn.Size = New System.Drawing.Size(10, 60)
        Me.pnlOnSideBtn.TabIndex = 2
        '
        'btnSide01
        '
        Me.btnSide01.BackColor = System.Drawing.Color.Transparent
        Me.btnSide01.FlatAppearance.BorderSize = 0
        Me.btnSide01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide01.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide01.Image = CType(resources.GetObject("btnSide01.Image"), System.Drawing.Image)
        Me.btnSide01.Location = New System.Drawing.Point(0, 157)
        Me.btnSide01.Name = "btnSide01"
        Me.btnSide01.Size = New System.Drawing.Size(200, 60)
        Me.btnSide01.TabIndex = 0
        Me.btnSide01.Tag = "0"
        Me.btnSide01.Text = "受注業務"
        Me.btnSide01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide01.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide01.UseVisualStyleBackColor = False
        '
        'btnSide02
        '
        Me.btnSide02.BackColor = System.Drawing.Color.Transparent
        Me.btnSide02.FlatAppearance.BorderSize = 0
        Me.btnSide02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide02.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide02.Image = CType(resources.GetObject("btnSide02.Image"), System.Drawing.Image)
        Me.btnSide02.Location = New System.Drawing.Point(0, 223)
        Me.btnSide02.Name = "btnSide02"
        Me.btnSide02.Size = New System.Drawing.Size(200, 60)
        Me.btnSide02.TabIndex = 3
        Me.btnSide02.Tag = "1"
        Me.btnSide02.Text = "出荷業務"
        Me.btnSide02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide02.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide02.UseVisualStyleBackColor = False
        '
        'btnSide03
        '
        Me.btnSide03.BackColor = System.Drawing.Color.Transparent
        Me.btnSide03.FlatAppearance.BorderSize = 0
        Me.btnSide03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide03.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide03.Image = CType(resources.GetObject("btnSide03.Image"), System.Drawing.Image)
        Me.btnSide03.Location = New System.Drawing.Point(0, 289)
        Me.btnSide03.Name = "btnSide03"
        Me.btnSide03.Size = New System.Drawing.Size(200, 60)
        Me.btnSide03.TabIndex = 15
        Me.btnSide03.Tag = "2"
        Me.btnSide03.Text = "売上業務"
        Me.btnSide03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide03.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide03.UseVisualStyleBackColor = False
        '
        'btnSide04
        '
        Me.btnSide04.BackColor = System.Drawing.Color.Transparent
        Me.btnSide04.FlatAppearance.BorderSize = 0
        Me.btnSide04.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide04.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide04.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide04.Image = CType(resources.GetObject("btnSide04.Image"), System.Drawing.Image)
        Me.btnSide04.Location = New System.Drawing.Point(0, 355)
        Me.btnSide04.Name = "btnSide04"
        Me.btnSide04.Size = New System.Drawing.Size(200, 60)
        Me.btnSide04.TabIndex = 5
        Me.btnSide04.Tag = "3"
        Me.btnSide04.Text = "請求業務"
        Me.btnSide04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide04.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide04.UseVisualStyleBackColor = False
        '
        'btnSide05
        '
        Me.btnSide05.BackColor = System.Drawing.Color.Transparent
        Me.btnSide05.FlatAppearance.BorderSize = 0
        Me.btnSide05.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide05.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide05.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide05.Image = CType(resources.GetObject("btnSide05.Image"), System.Drawing.Image)
        Me.btnSide05.Location = New System.Drawing.Point(0, 421)
        Me.btnSide05.Name = "btnSide05"
        Me.btnSide05.Size = New System.Drawing.Size(200, 60)
        Me.btnSide05.TabIndex = 7
        Me.btnSide05.Tag = "4"
        Me.btnSide05.Text = "管理業務"
        Me.btnSide05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide05.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide05.UseVisualStyleBackColor = False
        '
        'btnSide99
        '
        Me.btnSide99.BackColor = System.Drawing.Color.Transparent
        Me.btnSide99.FlatAppearance.BorderSize = 0
        Me.btnSide99.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btnSide99.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSide99.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnSide99.Image = CType(resources.GetObject("btnSide99.Image"), System.Drawing.Image)
        Me.btnSide99.Location = New System.Drawing.Point(0, 630)
        Me.btnSide99.Name = "btnSide99"
        Me.btnSide99.Size = New System.Drawing.Size(200, 60)
        Me.btnSide99.TabIndex = 14
        Me.btnSide99.Tag = "5"
        Me.btnSide99.Text = "お知らせ"
        Me.btnSide99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSide99.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSide99.UseVisualStyleBackColor = False
        '
        'Btn終了
        '
        Me.Btn終了.BackColor = System.Drawing.Color.Transparent
        Me.Btn終了.FlatAppearance.BorderSize = 0
        Me.Btn終了.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.Btn終了.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn終了.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Btn終了.Image = Global.HARK000.My.Resources.Resources.logout2
        Me.Btn終了.Location = New System.Drawing.Point(0, 696)
        Me.Btn終了.Name = "Btn終了"
        Me.Btn終了.Size = New System.Drawing.Size(200, 60)
        Me.Btn終了.TabIndex = 13
        Me.Btn終了.Text = "終了"
        Me.Btn終了.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn終了.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn終了.UseVisualStyleBackColor = False
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.lblマシン名)
        Me.pnlTop.Controls.Add(Me.lblバージョン)
        Me.pnlTop.Controls.Add(Me.lbl事業所)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(200, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(824, 40)
        Me.pnlTop.TabIndex = 1
        '
        'lblマシン名
        '
        Me.lblマシン名.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblマシン名.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblマシン名.Location = New System.Drawing.Point(692, 21)
        Me.lblマシン名.Name = "lblマシン名"
        Me.lblマシン名.Size = New System.Drawing.Size(111, 18)
        Me.lblマシン名.TabIndex = 18
        Me.lblマシン名.Text = "lblマシン名"
        Me.lblマシン名.TextEffect = GrapeCity.Win.Common.TextEffect.Inset
        Me.lblマシン名.TextHAlign = GrapeCity.Win.Common.TextHAlign.Center
        Me.lblマシン名.TextVAlign = GrapeCity.Win.Common.TextVAlign.Middle
        '
        'lblバージョン
        '
        Me.lblバージョン.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblバージョン.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblバージョン.Location = New System.Drawing.Point(692, 3)
        Me.lblバージョン.Name = "lblバージョン"
        Me.lblバージョン.Size = New System.Drawing.Size(111, 18)
        Me.lblバージョン.TabIndex = 17
        Me.lblバージョン.Text = "lblバージョン"
        Me.lblバージョン.TextEffect = GrapeCity.Win.Common.TextEffect.Inset
        Me.lblバージョン.TextHAlign = GrapeCity.Win.Common.TextHAlign.Center
        Me.lblバージョン.TextVAlign = GrapeCity.Win.Common.TextVAlign.Middle
        '
        'lbl事業所
        '
        Me.lbl事業所.AutoSize = True
        Me.lbl事業所.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl事業所.ForeColor = System.Drawing.Color.Blue
        Me.lbl事業所.Location = New System.Drawing.Point(22, 2)
        Me.lbl事業所.Name = "lbl事業所"
        Me.lbl事業所.Size = New System.Drawing.Size(74, 37)
        Me.lbl事業所.TabIndex = 16
        Me.lbl事業所.Text = "事業所"
        Me.lbl事業所.TextVAlign = GrapeCity.Win.Common.TextVAlign.Middle
        '
        'pnl受注
        '
        Me.pnl受注.Controls.Add(Me.btn受注07)
        Me.pnl受注.Controls.Add(Me.btn受注01)
        Me.pnl受注.Controls.Add(Me.btn受注02)
        Me.pnl受注.Controls.Add(Me.btn受注03)
        Me.pnl受注.Controls.Add(Me.btn受注04)
        Me.pnl受注.Controls.Add(Me.btn受注05)
        Me.pnl受注.Controls.Add(Me.btn受注06)
        Me.pnl受注.Controls.Add(Me.pnl受注02)
        Me.pnl受注.Controls.Add(Me.pnl受注03)
        Me.pnl受注.Controls.Add(Me.pnl受注04)
        Me.pnl受注.Location = New System.Drawing.Point(200, 40)
        Me.pnl受注.Name = "pnl受注"
        Me.pnl受注.Size = New System.Drawing.Size(824, 728)
        Me.pnl受注.TabIndex = 2
        Me.pnl受注.Tag = "0"
        '
        'btn受注07
        '
        Me.btn受注07.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注07.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注07.FlatAppearance.BorderSize = 0
        Me.btn受注07.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注07.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注07.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注07.Location = New System.Drawing.Point(420, 210)
        Me.btn受注07.Name = "btn受注07"
        Me.btn受注07.Size = New System.Drawing.Size(150, 150)
        Me.btn受注07.TabIndex = 13
        Me.btn受注07.Tag = "HARKP107"
        Me.btn受注07.Text = "汎用" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "受注連携"
        Me.btn受注07.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注07.UseVisualStyleBackColor = False
        '
        'btn受注01
        '
        Me.btn受注01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注01.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注01.FlatAppearance.BorderSize = 0
        Me.btn受注01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注01.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注01.Location = New System.Drawing.Point(40, 30)
        Me.btn受注01.Name = "btn受注01"
        Me.btn受注01.Size = New System.Drawing.Size(150, 150)
        Me.btn受注01.TabIndex = 7
        Me.btn受注01.Tag = "HARKP101"
        Me.btn受注01.Text = "天神会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SPD受注"
        Me.btn受注01.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注01.UseVisualStyleBackColor = False
        '
        'btn受注02
        '
        Me.btn受注02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注02.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注02.FlatAppearance.BorderSize = 0
        Me.btn受注02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注02.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注02.Location = New System.Drawing.Point(230, 30)
        Me.btn受注02.Name = "btn受注02"
        Me.btn受注02.Size = New System.Drawing.Size(150, 150)
        Me.btn受注02.TabIndex = 8
        Me.btn受注02.Tag = "HARKP102"
        Me.btn受注02.Text = "KMC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EDI受注"
        Me.btn受注02.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注02.UseVisualStyleBackColor = False
        '
        'btn受注03
        '
        Me.btn受注03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注03.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注03.FlatAppearance.BorderSize = 0
        Me.btn受注03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注03.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注03.Location = New System.Drawing.Point(420, 30)
        Me.btn受注03.Name = "btn受注03"
        Me.btn受注03.Size = New System.Drawing.Size(150, 150)
        Me.btn受注03.TabIndex = 9
        Me.btn受注03.Tag = "HARKP103"
        Me.btn受注03.Text = "福医協" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EDI受注"
        Me.btn受注03.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注03.UseVisualStyleBackColor = False
        '
        'btn受注04
        '
        Me.btn受注04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注04.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注04.FlatAppearance.BorderSize = 0
        Me.btn受注04.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注04.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注04.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注04.Location = New System.Drawing.Point(610, 30)
        Me.btn受注04.Name = "btn受注04"
        Me.btn受注04.Size = New System.Drawing.Size(150, 150)
        Me.btn受注04.TabIndex = 10
        Me.btn受注04.Tag = "HARKP104"
        Me.btn受注04.Text = "Rツール" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "受注連携"
        Me.btn受注04.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注04.UseVisualStyleBackColor = False
        '
        'btn受注05
        '
        Me.btn受注05.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注05.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注05.FlatAppearance.BorderSize = 0
        Me.btn受注05.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注05.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注05.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注05.Location = New System.Drawing.Point(40, 210)
        Me.btn受注05.Name = "btn受注05"
        Me.btn受注05.Size = New System.Drawing.Size(150, 150)
        Me.btn受注05.TabIndex = 11
        Me.btn受注05.Tag = "HARKP105"
        Me.btn受注05.Text = "PHsmos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "受注連携"
        Me.btn受注05.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注05.UseVisualStyleBackColor = False
        '
        'btn受注06
        '
        Me.btn受注06.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn受注06.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn受注06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn受注06.FlatAppearance.BorderSize = 0
        Me.btn受注06.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn受注06.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn受注06.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn受注06.Location = New System.Drawing.Point(230, 210)
        Me.btn受注06.Name = "btn受注06"
        Me.btn受注06.Size = New System.Drawing.Size(150, 150)
        Me.btn受注06.TabIndex = 12
        Me.btn受注06.Tag = "HARKP106"
        Me.btn受注06.Text = "徳洲会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "受注連携"
        Me.btn受注06.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn受注06.UseVisualStyleBackColor = False
        '
        'pnl受注02
        '
        Me.pnl受注02.Location = New System.Drawing.Point(610, 210)
        Me.pnl受注02.Name = "pnl受注02"
        Me.pnl受注02.Size = New System.Drawing.Size(150, 150)
        Me.pnl受注02.TabIndex = 3
        '
        'pnl受注03
        '
        Me.pnl受注03.Location = New System.Drawing.Point(40, 390)
        Me.pnl受注03.Name = "pnl受注03"
        Me.pnl受注03.Size = New System.Drawing.Size(150, 150)
        Me.pnl受注03.TabIndex = 4
        '
        'pnl受注04
        '
        Me.pnl受注04.Location = New System.Drawing.Point(40, 570)
        Me.pnl受注04.Name = "pnl受注04"
        Me.pnl受注04.Size = New System.Drawing.Size(150, 150)
        Me.pnl受注04.TabIndex = 5
        '
        'pnl出荷
        '
        Me.pnl出荷.Controls.Add(Me.btn出荷01)
        Me.pnl出荷.Controls.Add(Me.btn出荷02)
        Me.pnl出荷.Controls.Add(Me.btn出荷03)
        Me.pnl出荷.Location = New System.Drawing.Point(200, 40)
        Me.pnl出荷.Name = "pnl出荷"
        Me.pnl出荷.Size = New System.Drawing.Size(824, 728)
        Me.pnl出荷.TabIndex = 3
        Me.pnl出荷.Tag = "1"
        '
        'btn出荷01
        '
        Me.btn出荷01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn出荷01.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn出荷01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn出荷01.FlatAppearance.BorderSize = 0
        Me.btn出荷01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn出荷01.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn出荷01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn出荷01.Location = New System.Drawing.Point(40, 30)
        Me.btn出荷01.Name = "btn出荷01"
        Me.btn出荷01.Size = New System.Drawing.Size(150, 150)
        Me.btn出荷01.TabIndex = 7
        Me.btn出荷01.Tag = "HARKP201"
        Me.btn出荷01.Text = "天神会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SPD出荷"
        Me.btn出荷01.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn出荷01.UseVisualStyleBackColor = False
        '
        'btn出荷02
        '
        Me.btn出荷02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn出荷02.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn出荷02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn出荷02.FlatAppearance.BorderSize = 0
        Me.btn出荷02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn出荷02.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn出荷02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn出荷02.Location = New System.Drawing.Point(230, 30)
        Me.btn出荷02.Name = "btn出荷02"
        Me.btn出荷02.Size = New System.Drawing.Size(150, 150)
        Me.btn出荷02.TabIndex = 8
        Me.btn出荷02.Tag = "HARKP202"
        Me.btn出荷02.Text = "天神会SPD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "貸出棚卸"
        Me.btn出荷02.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn出荷02.UseVisualStyleBackColor = False
        '
        'btn出荷03
        '
        Me.btn出荷03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn出荷03.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn出荷03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn出荷03.FlatAppearance.BorderSize = 0
        Me.btn出荷03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn出荷03.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn出荷03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn出荷03.Location = New System.Drawing.Point(420, 30)
        Me.btn出荷03.Name = "btn出荷03"
        Me.btn出荷03.Size = New System.Drawing.Size(150, 150)
        Me.btn出荷03.TabIndex = 9
        Me.btn出荷03.Tag = "HARKP203"
        Me.btn出荷03.Text = "KMC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "出荷連携"
        Me.btn出荷03.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn出荷03.UseVisualStyleBackColor = False
        '
        'pnl請求
        '
        Me.pnl請求.Controls.Add(Me.btn請求03)
        Me.pnl請求.Controls.Add(Me.btn請求01)
        Me.pnl請求.Controls.Add(Me.btn請求02)
        Me.pnl請求.Location = New System.Drawing.Point(200, 40)
        Me.pnl請求.Name = "pnl請求"
        Me.pnl請求.Size = New System.Drawing.Size(824, 728)
        Me.pnl請求.TabIndex = 4
        Me.pnl請求.Tag = "3"
        '
        'btn請求03
        '
        Me.btn請求03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn請求03.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn請求03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn請求03.FlatAppearance.BorderSize = 0
        Me.btn請求03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn請求03.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn請求03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn請求03.Location = New System.Drawing.Point(420, 30)
        Me.btn請求03.Name = "btn請求03"
        Me.btn請求03.Size = New System.Drawing.Size(150, 150)
        Me.btn請求03.TabIndex = 9
        Me.btn請求03.Tag = "HARKP403"
        Me.btn請求03.Text = "徳洲会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請求情報伝送"
        Me.btn請求03.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn請求03.UseVisualStyleBackColor = False
        '
        'btn請求01
        '
        Me.btn請求01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn請求01.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn請求01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn請求01.FlatAppearance.BorderSize = 0
        Me.btn請求01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn請求01.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn請求01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn請求01.Location = New System.Drawing.Point(40, 30)
        Me.btn請求01.Name = "btn請求01"
        Me.btn請求01.Size = New System.Drawing.Size(150, 150)
        Me.btn請求01.TabIndex = 7
        Me.btn請求01.Tag = "HARKP401"
        Me.btn請求01.Text = "天神会SPD請求確認"
        Me.btn請求01.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn請求01.UseVisualStyleBackColor = False
        '
        'btn請求02
        '
        Me.btn請求02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn請求02.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn請求02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn請求02.FlatAppearance.BorderSize = 0
        Me.btn請求02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn請求02.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn請求02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn請求02.Location = New System.Drawing.Point(230, 30)
        Me.btn請求02.Name = "btn請求02"
        Me.btn請求02.Size = New System.Drawing.Size(150, 150)
        Me.btn請求02.TabIndex = 8
        Me.btn請求02.Tag = "HARKP402"
        Me.btn請求02.Text = "Medi-TOM3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請求確認"
        Me.btn請求02.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn請求02.UseVisualStyleBackColor = False
        '
        'pnl管理
        '
        Me.pnl管理.Controls.Add(Me.btn管理06)
        Me.pnl管理.Controls.Add(Me.btn管理02)
        Me.pnl管理.Controls.Add(Me.btn管理01)
        Me.pnl管理.Controls.Add(Me.btn管理03)
        Me.pnl管理.Controls.Add(Me.btn管理04)
        Me.pnl管理.Controls.Add(Me.btn管理05)
        Me.pnl管理.Location = New System.Drawing.Point(200, 40)
        Me.pnl管理.Name = "pnl管理"
        Me.pnl管理.Size = New System.Drawing.Size(824, 728)
        Me.pnl管理.TabIndex = 5
        Me.pnl管理.Tag = "4"
        '
        'btn管理02
        '
        Me.btn管理02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理02.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理02.FlatAppearance.BorderSize = 0
        Me.btn管理02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理02.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理02.Location = New System.Drawing.Point(230, 30)
        Me.btn管理02.Name = "btn管理02"
        Me.btn管理02.Size = New System.Drawing.Size(150, 150)
        Me.btn管理02.TabIndex = 12
        Me.btn管理02.Tag = "HARKP502"
        Me.btn管理02.Text = "医薬品" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "入出庫履歴"
        Me.btn管理02.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理02.UseVisualStyleBackColor = False
        '
        'btn管理01
        '
        Me.btn管理01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理01.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理01.FlatAppearance.BorderSize = 0
        Me.btn管理01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理01.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理01.Location = New System.Drawing.Point(40, 30)
        Me.btn管理01.Name = "btn管理01"
        Me.btn管理01.Size = New System.Drawing.Size(150, 150)
        Me.btn管理01.TabIndex = 7
        Me.btn管理01.Tag = "HARKP501"
        Me.btn管理01.Text = "天神会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SPDマスタ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "メンテナンス"
        Me.btn管理01.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理01.UseVisualStyleBackColor = False
        '
        'btn管理03
        '
        Me.btn管理03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理03.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理03.FlatAppearance.BorderSize = 0
        Me.btn管理03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理03.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理03.Location = New System.Drawing.Point(420, 30)
        Me.btn管理03.Name = "btn管理03"
        Me.btn管理03.Size = New System.Drawing.Size(150, 150)
        Me.btn管理03.TabIndex = 9
        Me.btn管理03.Tag = "HARKP503"
        Me.btn管理03.Text = "得意先別" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "販売許可証" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        Me.btn管理03.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理03.UseVisualStyleBackColor = False
        '
        'btn管理04
        '
        Me.btn管理04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理04.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理04.FlatAppearance.BorderSize = 0
        Me.btn管理04.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理04.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理04.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理04.Location = New System.Drawing.Point(610, 30)
        Me.btn管理04.Name = "btn管理04"
        Me.btn管理04.Size = New System.Drawing.Size(150, 150)
        Me.btn管理04.TabIndex = 10
        Me.btn管理04.Tag = "HARKP504"
        Me.btn管理04.Text = "得意先別" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "販売許可証" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "メンテナンス"
        Me.btn管理04.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理04.UseVisualStyleBackColor = False
        '
        'btn管理05
        '
        Me.btn管理05.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理05.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理05.FlatAppearance.BorderSize = 0
        Me.btn管理05.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理05.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理05.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理05.Location = New System.Drawing.Point(40, 210)
        Me.btn管理05.Name = "btn管理05"
        Me.btn管理05.Size = New System.Drawing.Size(150, 150)
        Me.btn管理05.TabIndex = 11
        Me.btn管理05.Tag = "HARKP505"
        Me.btn管理05.Text = "PHsmos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "採用商品情報出力"
        Me.btn管理05.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理05.UseVisualStyleBackColor = False
        '
        'pnlお知らせ
        '
        Me.pnlお知らせ.Controls.Add(Me.lblマニュアル)
        Me.pnlお知らせ.Controls.Add(Me.txtお知らせ)
        Me.pnlお知らせ.Controls.Add(Me.lblDebug)
        Me.pnlお知らせ.Controls.Add(Me.wbrお知らせ)
        Me.pnlお知らせ.Controls.Add(Me.lblお知らせ)
        Me.pnlお知らせ.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlお知らせ.Location = New System.Drawing.Point(200, 40)
        Me.pnlお知らせ.Name = "pnlお知らせ"
        Me.pnlお知らせ.Size = New System.Drawing.Size(824, 728)
        Me.pnlお知らせ.TabIndex = 6
        Me.pnlお知らせ.Tag = "5"
        '
        'lblマニュアル
        '
        Me.lblマニュアル.AutoSize = True
        Me.lblマニュアル.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblマニュアル.Location = New System.Drawing.Point(22, 676)
        Me.lblマニュアル.Name = "lblマニュアル"
        Me.lblマニュアル.Size = New System.Drawing.Size(183, 28)
        Me.lblマニュアル.TabIndex = 17
        Me.lblマニュアル.TabStop = True
        Me.lblマニュアル.Text = "マニュアルはこちら"
        '
        'txtお知らせ
        '
        Me.txtお知らせ.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.Popup
        Me.txtお知らせ.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtお知らせ.Location = New System.Drawing.Point(22, 512)
        Me.txtお知らせ.Multiline = True
        Me.txtお知らせ.Name = "txtお知らせ"
        Me.txtお知らせ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtお知らせ.Size = New System.Drawing.Size(777, 143)
        Me.txtお知らせ.TabIndex = 16
        '
        'lblDebug
        '
        Me.lblDebug.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDebug.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblDebug.Location = New System.Drawing.Point(514, 661)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(287, 50)
        Me.lblDebug.TabIndex = 15
        Me.lblDebug.Text = "Delta2"
        Me.lblDebug.TextHAlign = GrapeCity.Win.Common.TextHAlign.Right
        '
        'wbrお知らせ
        '
        Me.wbrお知らせ.Location = New System.Drawing.Point(22, 65)
        Me.wbrお知らせ.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrお知らせ.Name = "wbrお知らせ"
        Me.wbrお知らせ.Size = New System.Drawing.Size(777, 427)
        Me.wbrお知らせ.TabIndex = 14
        Me.wbrお知らせ.Url = New System.Uri("", System.UriKind.Relative)
        Me.wbrお知らせ.WebBrowserShortcutsEnabled = False
        '
        'lblお知らせ
        '
        Me.lblお知らせ.AutoSize = True
        Me.lblお知らせ.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblお知らせ.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblお知らせ.Location = New System.Drawing.Point(13, 12)
        Me.lblお知らせ.Name = "lblお知らせ"
        Me.lblお知らせ.Size = New System.Drawing.Size(132, 50)
        Me.lblお知らせ.TabIndex = 13
        Me.lblお知らせ.Text = "お知らせ"
        '
        'pnl売上
        '
        Me.pnl売上.Controls.Add(Me.btn売上04)
        Me.pnl売上.Controls.Add(Me.btn売上01)
        Me.pnl売上.Controls.Add(Me.btn売上02)
        Me.pnl売上.Controls.Add(Me.btn売上03)
        Me.pnl売上.Location = New System.Drawing.Point(200, 40)
        Me.pnl売上.Name = "pnl売上"
        Me.pnl売上.Size = New System.Drawing.Size(824, 728)
        Me.pnl売上.TabIndex = 7
        Me.pnl売上.Tag = "2"
        '
        'btn売上04
        '
        Me.btn売上04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn売上04.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn売上04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn売上04.FlatAppearance.BorderSize = 0
        Me.btn売上04.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn売上04.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn売上04.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn売上04.Location = New System.Drawing.Point(610, 30)
        Me.btn売上04.Name = "btn売上04"
        Me.btn売上04.Size = New System.Drawing.Size(150, 150)
        Me.btn売上04.TabIndex = 10
        Me.btn売上04.Tag = "HARKP304"
        Me.btn売上04.Text = "徳洲会" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "納品情報伝送"
        Me.btn売上04.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn売上04.UseVisualStyleBackColor = False
        '
        'btn売上01
        '
        Me.btn売上01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn売上01.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn売上01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn売上01.FlatAppearance.BorderSize = 0
        Me.btn売上01.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn売上01.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn売上01.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn売上01.Location = New System.Drawing.Point(40, 30)
        Me.btn売上01.Name = "btn売上01"
        Me.btn売上01.Size = New System.Drawing.Size(150, 150)
        Me.btn売上01.TabIndex = 7
        Me.btn売上01.Tag = "HARKP301"
        Me.btn売上01.Text = "天神会SPD日次処理"
        Me.btn売上01.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn売上01.UseVisualStyleBackColor = False
        '
        'btn売上02
        '
        Me.btn売上02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn売上02.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn売上02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn売上02.FlatAppearance.BorderSize = 0
        Me.btn売上02.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn売上02.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn売上02.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn売上02.Location = New System.Drawing.Point(230, 30)
        Me.btn売上02.Name = "btn売上02"
        Me.btn売上02.Size = New System.Drawing.Size(150, 150)
        Me.btn売上02.TabIndex = 8
        Me.btn売上02.Tag = "HARKP302"
        Me.btn売上02.Text = "福医協" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "実績送信"
        Me.btn売上02.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn売上02.UseVisualStyleBackColor = False
        '
        'btn売上03
        '
        Me.btn売上03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn売上03.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn売上03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn売上03.FlatAppearance.BorderSize = 0
        Me.btn売上03.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn売上03.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn売上03.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn売上03.Location = New System.Drawing.Point(420, 30)
        Me.btn売上03.Name = "btn売上03"
        Me.btn売上03.Size = New System.Drawing.Size(150, 150)
        Me.btn売上03.TabIndex = 9
        Me.btn売上03.Tag = "HARKP303"
        Me.btn売上03.Text = "MD-TraC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "売上連携"
        Me.btn売上03.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn売上03.UseVisualStyleBackColor = False
        '
        'btn管理06
        '
        Me.btn管理06.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btn管理06.BackgroundImage = Global.HARK000.My.Resources.Resources.Execute
        Me.btn管理06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn管理06.FlatAppearance.BorderSize = 0
        Me.btn管理06.FlatStyle = GrapeCity.Win.Common.FlatStyleEx.Flat
        Me.btn管理06.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理06.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btn管理06.Location = New System.Drawing.Point(230, 210)
        Me.btn管理06.Name = "btn管理06"
        Me.btn管理06.Size = New System.Drawing.Size(150, 150)
        Me.btn管理06.TabIndex = 13
        Me.btn管理06.Tag = "HARKP506"
        Me.btn管理06.Text = "汎用受注用" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "商品情報出力"
        Me.btn管理06.TextAppearance = New GrapeCity.Win.Buttons.RotationTextAppearance(GrapeCity.Win.Common.TextEffect.Flat, GrapeCity.Win.Buttons.TextAdjustment.None, GrapeCity.Win.Buttons.TextAdjustment.None, 0)
        Me.btn管理06.UseVisualStyleBackColor = False
        '
        'HARK001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.pnl管理)
        Me.Controls.Add(Me.pnl出荷)
        Me.Controls.Add(Me.pnl売上)
        Me.Controls.Add(Me.pnl受注)
        Me.Controls.Add(Me.pnl請求)
        Me.Controls.Add(Me.pnlお知らせ)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlSide)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "HARK001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HARK001"
        Me.pnlSide.ResumeLayout(False)
        Me.pnlSide.PerformLayout()
        CType(Me.pic最大化, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic最小化, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic終了, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnl受注.ResumeLayout(False)
        Me.pnl出荷.ResumeLayout(False)
        Me.pnl請求.ResumeLayout(False)
        Me.pnl管理.ResumeLayout(False)
        Me.pnlお知らせ.ResumeLayout(False)
        Me.pnlお知らせ.PerformLayout()
        CType(Me.txtお知らせ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl売上.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlSide As Panel
    Private WithEvents btnSide01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnlTop As Panel
    Private WithEvents pnlOnSideBtn As Panel
    Private WithEvents btnSide05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btnSide04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btnSide02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnl受注 As Panel
    Private WithEvents pnl受注03 As Panel
    Private WithEvents pnl受注02 As Panel
    Private WithEvents btn受注01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn受注02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pic最大化 As PictureBox
    Private WithEvents pic最小化 As PictureBox
    Private WithEvents pic終了 As PictureBox
    Private WithEvents pnl出荷 As Panel
    Private WithEvents btn出荷01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents lblタイトル As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents Btn終了 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn受注03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnl請求 As Panel
    Private WithEvents btn請求01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnl管理 As Panel
    Private WithEvents btn管理01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnlお知らせ As Panel
    Private WithEvents lblお知らせ As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents wbrお知らせ As WebBrowser
    Private WithEvents lblバージョン As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents lbl事業所 As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents lblDebug As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents btnSide99 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents txtお知らせ As GrapeCity.Win.Editors.GcTextBox
    Private WithEvents pnl受注04 As Panel
    Private WithEvents btnSide03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents pnl売上 As Panel
    Private WithEvents btn売上01 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents lblマシン名 As GrapeCity.Win.Buttons.GcLabel
    Private WithEvents btn受注04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn売上02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn請求02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn管理03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn管理04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents lblマニュアル As LinkLabel
    Private WithEvents btn受注05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn管理05 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn売上03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn受注06 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn売上04 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn請求03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn出荷02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn管理02 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn受注07 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn出荷03 As GrapeCity.Win.Buttons.GcButton
    Private WithEvents btn管理06 As GrapeCity.Win.Buttons.GcButton

    Private mousePoint As Point
    Private strProgram_ID As String
    Private strExeProgram_ID As Form

    Private Pnls() As System.Windows.Forms.Panel
    Private BtnExe_Grp1() As GrapeCity.Win.Buttons.GcButton
    Private BtnExe_Grp2() As GrapeCity.Win.Buttons.GcButton
    Private BtnExe_Grp3() As GrapeCity.Win.Buttons.GcButton
    Private BtnExe_Grp4() As GrapeCity.Win.Buttons.GcButton
    Private BtnExe_Grp5() As GrapeCity.Win.Buttons.GcButton


    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'サイドパネル
        Me.Pnls = New Panel(6) {}

        Me.Pnls(0) = Me.pnl受注
        Me.Pnls(1) = Me.pnl出荷
        Me.Pnls(2) = Me.pnl売上
        Me.Pnls(3) = Me.pnl請求
        Me.Pnls(4) = Me.pnl管理
        Me.Pnls(5) = Me.pnlお知らせ

        AddHandler btnSide01.Click, AddressOf BtnSide_Click '受注
        AddHandler btnSide02.Click, AddressOf BtnSide_Click '出荷
        AddHandler btnSide03.Click, AddressOf BtnSide_Click '売上
        AddHandler btnSide04.Click, AddressOf BtnSide_Click '請求
        AddHandler btnSide05.Click, AddressOf BtnSide_Click '管理
        AddHandler btnSide99.Click, AddressOf BtnSide_Click 'お知らせ

        '受注パネル
        Me.BtnExe_Grp1 = New GrapeCity.Win.Buttons.GcButton(7) {}
        Me.BtnExe_Grp1(0) = Me.btn受注01
        Me.BtnExe_Grp1(1) = Me.btn受注02
        Me.BtnExe_Grp1(2) = Me.btn受注03
        Me.BtnExe_Grp1(3) = Me.btn受注04
        Me.BtnExe_Grp1(4) = Me.btn受注05
        Me.BtnExe_Grp1(5) = Me.btn受注06
        Me.BtnExe_Grp1(6) = Me.btn受注07

        '出荷パネル
        Me.BtnExe_Grp2 = New GrapeCity.Win.Buttons.GcButton(3) {}
        Me.BtnExe_Grp2(0) = Me.btn出荷01
        Me.BtnExe_Grp2(1) = Me.btn出荷02
        Me.BtnExe_Grp2(2) = Me.btn出荷03

        '売上パネル
        Me.BtnExe_Grp3 = New GrapeCity.Win.Buttons.GcButton(4) {}
        Me.BtnExe_Grp3(0) = Me.btn売上01
        Me.BtnExe_Grp3(1) = Me.btn売上02
        Me.BtnExe_Grp3(2) = Me.btn売上03
        Me.BtnExe_Grp3(3) = Me.btn売上04

        '請求パネル
        Me.BtnExe_Grp4 = New GrapeCity.Win.Buttons.GcButton(3) {}
        Me.BtnExe_Grp4(0) = Me.btn請求01
        Me.BtnExe_Grp4(1) = Me.btn請求02
        Me.BtnExe_Grp4(2) = Me.btn請求03

        '管理パネル
        Me.BtnExe_Grp5 = New GrapeCity.Win.Buttons.GcButton(6) {}
        Me.BtnExe_Grp5(0) = Me.btn管理01
        Me.BtnExe_Grp5(1) = Me.btn管理02
        Me.BtnExe_Grp5(2) = Me.btn管理03
        Me.BtnExe_Grp5(3) = Me.btn管理04
        Me.BtnExe_Grp5(4) = Me.btn管理05
        Me.BtnExe_Grp5(5) = Me.btn管理06

        AddHandler btn受注01.Click, AddressOf BtnExe_Click
        AddHandler btn受注02.Click, AddressOf BtnExe_Click
        AddHandler btn受注03.Click, AddressOf BtnExe_Click
        AddHandler btn受注04.Click, AddressOf BtnExe_Click
        AddHandler btn受注05.Click, AddressOf BtnExe_Click
        AddHandler btn受注06.Click, AddressOf BtnExe_Click
        AddHandler btn受注07.Click, AddressOf BtnExe_Click

        AddHandler btn出荷01.Click, AddressOf BtnExe_Click
        AddHandler btn出荷02.Click, AddressOf BtnExe_Click
        AddHandler btn出荷03.Click, AddressOf BtnExe_Click

        AddHandler btn売上01.Click, AddressOf BtnExe_Click
        AddHandler btn売上02.Click, AddressOf BtnExe_Click
        AddHandler btn売上03.Click, AddressOf BtnExe_Click
        AddHandler btn売上04.Click, AddressOf BtnExe_Click

        AddHandler btn請求01.Click, AddressOf BtnExe_Click
        AddHandler btn請求02.Click, AddressOf BtnExe_Click
        AddHandler btn請求03.Click, AddressOf BtnExe_Click

        AddHandler btn管理01.Click, AddressOf BtnExe_Click
        AddHandler btn管理02.Click, AddressOf BtnExe_Click
        AddHandler btn管理03.Click, AddressOf BtnExe_Click
        AddHandler btn管理04.Click, AddressOf BtnExe_Click
        AddHandler btn管理05.Click, AddressOf BtnExe_Click
        AddHandler btn管理06.Click, AddressOf BtnExe_Click

        'ヘッダパネル
        AddHandler MyBase.MouseDown, AddressOf Fm_MouseDown
        AddHandler pnlTop.MouseDown, AddressOf Fm_MouseDown
        AddHandler lbl事業所.MouseDown, AddressOf Fm_MouseDown
        AddHandler lblバージョン.MouseDown, AddressOf Fm_MouseDown
        AddHandler lblマシン名.MouseDown, AddressOf Fm_MouseDown

        AddHandler MyBase.MouseMove, AddressOf Fm_MouseMove
        AddHandler pnlTop.MouseMove, AddressOf Fm_MouseMove
        AddHandler lbl事業所.MouseMove, AddressOf Fm_MouseMove
        AddHandler lblバージョン.MouseMove, AddressOf Fm_MouseMove
        AddHandler lblマシン名.MouseMove, AddressOf Fm_MouseMove


        UpdateManager.Instance.UpdateSource = New Sources.SimpleWebSource(My.Settings.WebSource, My.Settings.WebProxy)
        UpdateManager.Instance.ReinstateIfRestarted()

    End Sub




End Class
