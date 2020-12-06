<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class HARK502Reports
    Inherits GrapeCity.ActiveReports.SectionReport

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReports デザイナーで必要です。
    'ActiveReports デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    Private WithEvents PH帳票 As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PF帳票 As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HARK502Reports))
        Me.PH帳票 = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape倉庫 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.txt詳細入出庫数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt詳細単位名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt有効期限 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtロット = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.LineLeftロット = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineLeft入出庫区分 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineRight入出庫区分 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineRight入庫数量 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineRight出庫数量 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineRightDetail = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineTopDetail = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.LineLeftDetail = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.PF帳票 = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.lblプログラム = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl会社 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.RIページ = New GrapeCity.ActiveReports.SectionReportModel.ReportInfo()
        Me.GH商品 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txt商品コード = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtメーカ名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtメーカ品番 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt単位名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt前月末数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lbl前月末在庫 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt商品名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt規格 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape商品 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.GF商品 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.GH入出庫 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txt残在庫数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt在庫単位名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt出庫数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt入庫数量 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt入出庫区分 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt取引先名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt入出庫日付 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt入出庫番号 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt入出庫行番号 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt取引先コード = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.LineTop入出庫 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GF入出庫 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.LineBottom入出庫 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GH倉庫 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.lbl事業所 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt事業所名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lbl倉庫 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt倉庫名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GF倉庫 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt詳細入出庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt詳細単位名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt有効期限, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtロット, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblプログラム, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl会社, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIページ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt商品コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtメーカ名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtメーカ品番, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt単位名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt前月末数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl前月末在庫, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt商品名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt規格, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt残在庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt在庫単位名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt出庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入出庫区分, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt取引先名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入出庫日付, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入出庫番号, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt入出庫行番号, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt取引先コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl事業所, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt事業所名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl倉庫, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt倉庫名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PH帳票
        '
        Me.PH帳票.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label1})
        Me.PH帳票.Height = 0.4583333!
        Me.PH帳票.Name = "PH帳票"
        '
        'Label1
        '
        Me.Label1.Height = 0.34375!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = "kkk"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 2.885417!
        '
        'Shape倉庫
        '
        Me.Shape倉庫.Height = 0.5314961!
        Me.Shape倉庫.Left = 0.0492126!
        Me.Shape倉庫.Name = "Shape倉庫"
        Me.Shape倉庫.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape倉庫.Top = 0.2165354!
        Me.Shape倉庫.Width = 9.621257!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt詳細入出庫数量, Me.txt詳細単位名, Me.txt有効期限, Me.txtロット, Me.LineLeftロット, Me.LineLeft入出庫区分, Me.LineRight入出庫区分, Me.LineRight入庫数量, Me.LineRight出庫数量, Me.LineRightDetail, Me.LineTopDetail, Me.LineLeftDetail})
        Me.Detail.Height = 0.1771654!
        Me.Detail.Name = "Detail"
        '
        'txt詳細入出庫数量
        '
        Me.txt詳細入出庫数量.CanGrow = False
        Me.txt詳細入出庫数量.DataField = "詳細入出庫数量"
        Me.txt詳細入出庫数量.Height = 0.1771654!
        Me.txt詳細入出庫数量.Left = 6.864961!
        Me.txt詳細入出庫数量.Name = "txt詳細入出庫数量"
        Me.txt詳細入出庫数量.Style = "font-family: メイリオ; font-size: 9pt; text-align: right; text-justify: auto"
        Me.txt詳細入出庫数量.Text = "NNNNN"
        Me.txt詳細入出庫数量.Top = 0!
        Me.txt詳細入出庫数量.Width = 0.511811!
        '
        'txt詳細単位名
        '
        Me.txt詳細単位名.CanGrow = False
        Me.txt詳細単位名.DataField = "詳細単位名"
        Me.txt詳細単位名.Height = 0.1771653!
        Me.txt詳細単位名.Left = 7.393701!
        Me.txt詳細単位名.Name = "txt詳細単位名"
        Me.txt詳細単位名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt詳細単位名.Text = "XXXX"
        Me.txt詳細単位名.Top = 0!
        Me.txt詳細単位名.Width = 0.3803153!
        '
        'txt有効期限
        '
        Me.txt有効期限.CanGrow = False
        Me.txt有効期限.DataField = "有効期限"
        Me.txt有効期限.Height = 0.1771653!
        Me.txt有効期限.Left = 8.710629!
        Me.txt有効期限.Name = "txt有効期限"
        Me.txt有効期限.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt有効期限.Text = "XXXXXXXXXX"
        Me.txt有効期限.Top = 0!
        Me.txt有効期限.Width = 0.8858261!
        '
        'txtロット
        '
        Me.txtロット.CanGrow = False
        Me.txtロット.DataField = "ロット"
        Me.txtロット.Height = 0.1771653!
        Me.txtロット.Left = 7.80315!
        Me.txtロット.Name = "txtロット"
        Me.txtロット.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txtロット.Text = "XXXXXXXXXX"
        Me.txtロット.Top = 0!
        Me.txtロット.Width = 0.8858263!
        '
        'LineLeftロット
        '
        Me.LineLeftロット.Height = 0.1771654!
        Me.LineLeftロット.Left = 6.815748!
        Me.LineLeftロット.LineWeight = 1.0!
        Me.LineLeftロット.Name = "LineLeftロット"
        Me.LineLeftロット.Top = 0!
        Me.LineLeftロット.Width = 0!
        Me.LineLeftロット.X1 = 6.815748!
        Me.LineLeftロット.X2 = 6.815748!
        Me.LineLeftロット.Y1 = 0!
        Me.LineLeftロット.Y2 = 0.1771654!
        '
        'LineLeft入出庫区分
        '
        Me.LineLeft入出庫区分.Height = 0.1771654!
        Me.LineLeft入出庫区分.Left = 4.238189!
        Me.LineLeft入出庫区分.LineWeight = 1.0!
        Me.LineLeft入出庫区分.Name = "LineLeft入出庫区分"
        Me.LineLeft入出庫区分.Top = 0!
        Me.LineLeft入出庫区分.Width = 0!
        Me.LineLeft入出庫区分.X1 = 4.238189!
        Me.LineLeft入出庫区分.X2 = 4.238189!
        Me.LineLeft入出庫区分.Y1 = 0!
        Me.LineLeft入出庫区分.Y2 = 0.1771654!
        '
        'LineRight入出庫区分
        '
        Me.LineRight入出庫区分.Height = 0.1771654!
        Me.LineRight入出庫区分.Left = 4.699606!
        Me.LineRight入出庫区分.LineWeight = 1.0!
        Me.LineRight入出庫区分.Name = "LineRight入出庫区分"
        Me.LineRight入出庫区分.Top = 0!
        Me.LineRight入出庫区分.Width = 0!
        Me.LineRight入出庫区分.X1 = 4.699606!
        Me.LineRight入出庫区分.X2 = 4.699606!
        Me.LineRight入出庫区分.Y1 = 0!
        Me.LineRight入出庫区分.Y2 = 0.1771654!
        '
        'LineRight入庫数量
        '
        Me.LineRight入庫数量.Height = 0.1771654!
        Me.LineRight入庫数量.Left = 5.265748!
        Me.LineRight入庫数量.LineWeight = 1.0!
        Me.LineRight入庫数量.Name = "LineRight入庫数量"
        Me.LineRight入庫数量.Top = 0!
        Me.LineRight入庫数量.Width = 0!
        Me.LineRight入庫数量.X1 = 5.265748!
        Me.LineRight入庫数量.X2 = 5.265748!
        Me.LineRight入庫数量.Y1 = 0!
        Me.LineRight入庫数量.Y2 = 0.1771654!
        '
        'LineRight出庫数量
        '
        Me.LineRight出庫数量.Height = 0.1771654!
        Me.LineRight出庫数量.Left = 5.840945!
        Me.LineRight出庫数量.LineWeight = 1.0!
        Me.LineRight出庫数量.Name = "LineRight出庫数量"
        Me.LineRight出庫数量.Top = 0!
        Me.LineRight出庫数量.Width = 0!
        Me.LineRight出庫数量.X1 = 5.840945!
        Me.LineRight出庫数量.X2 = 5.840945!
        Me.LineRight出庫数量.Y1 = 0!
        Me.LineRight出庫数量.Y2 = 0.1771654!
        '
        'LineRightDetail
        '
        Me.LineRightDetail.Height = 0.1771654!
        Me.LineRightDetail.Left = 9.670472!
        Me.LineRightDetail.LineWeight = 1.0!
        Me.LineRightDetail.Name = "LineRightDetail"
        Me.LineRightDetail.Top = 0!
        Me.LineRightDetail.Width = 0!
        Me.LineRightDetail.X1 = 9.670472!
        Me.LineRightDetail.X2 = 9.670472!
        Me.LineRightDetail.Y1 = 0!
        Me.LineRightDetail.Y2 = 0.1771654!
        '
        'LineTopDetail
        '
        Me.LineTopDetail.Height = 0.0001804233!
        Me.LineTopDetail.Left = 6.815748!
        Me.LineTopDetail.LineWeight = 1.0!
        Me.LineTopDetail.Name = "LineTopDetail"
        Me.LineTopDetail.Top = 0!
        Me.LineTopDetail.Width = 2.854724!
        Me.LineTopDetail.X1 = 6.815748!
        Me.LineTopDetail.X2 = 9.670472!
        Me.LineTopDetail.Y1 = 0.0001804233!
        Me.LineTopDetail.Y2 = 0!
        '
        'LineLeftDetail
        '
        Me.LineLeftDetail.Height = 0.1771653!
        Me.LineLeftDetail.Left = 0.04921257!
        Me.LineLeftDetail.LineWeight = 1.0!
        Me.LineLeftDetail.Name = "LineLeftDetail"
        Me.LineLeftDetail.Top = 0!
        Me.LineLeftDetail.Width = 0!
        Me.LineLeftDetail.X1 = 0.04921257!
        Me.LineLeftDetail.X2 = 0.04921257!
        Me.LineLeftDetail.Y1 = 0!
        Me.LineLeftDetail.Y2 = 0.1771653!
        '
        'PF帳票
        '
        Me.PF帳票.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblプログラム, Me.lbl会社, Me.RIページ})
        Me.PF帳票.Height = 0.1771654!
        Me.PF帳票.Name = "PF帳票"
        '
        'lblプログラム
        '
        Me.lblプログラム.Height = 0.1771653!
        Me.lblプログラム.HyperLink = Nothing
        Me.lblプログラム.Left = 0.09842515!
        Me.lblプログラム.Name = "lblプログラム"
        Me.lblプログラム.Style = "font-family: メイリオ; font-size: 9pt; text-align: left"
        Me.lblプログラム.Text = "HARK502"
        Me.lblプログラム.Top = 0!
        Me.lblプログラム.Width = 0.6397638!
        '
        'lbl会社
        '
        Me.lbl会社.Height = 0.1771653!
        Me.lbl会社.HyperLink = Nothing
        Me.lbl会社.Left = 8.193701!
        Me.lbl会社.Name = "lbl会社"
        Me.lbl会社.Style = "font-family: メイリオ; font-size: 9pt; text-align: right"
        Me.lbl会社.Text = "アイティーアイ株式会社"
        Me.lbl会社.Top = 0!
        Me.lbl会社.Width = 1.402756!
        '
        'RIページ
        '
        Me.RIページ.FormatString = "{PageNumber} / {PageCount} ページ"
        Me.RIページ.Height = 0.1979167!
        Me.RIページ.Left = 3.469291!
        Me.RIページ.Name = "RIページ"
        Me.RIページ.Style = "font-family: メイリオ; font-size: 9pt; text-align: center"
        Me.RIページ.Top = 0!
        Me.RIページ.Width = 2.723818!
        '
        'GH商品
        '
        Me.GH商品.ColumnLayout = False
        Me.GH商品.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt商品コード, Me.txtメーカ名, Me.txtメーカ品番, Me.txt単位名, Me.txt前月末数量, Me.lbl前月末在庫, Me.txt商品名, Me.txt規格, Me.Shape商品})
        Me.GH商品.DataField = "商品コード"
        Me.GH商品.Height = 0.3543307!
        Me.GH商品.Name = "GH商品"
        Me.GH商品.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.All
        '
        'txt商品コード
        '
        Me.txt商品コード.CanGrow = False
        Me.txt商品コード.DataField = "商品コード"
        Me.txt商品コード.Height = 0.1771653!
        Me.txt商品コード.Left = 0.09842521!
        Me.txt商品コード.Name = "txt商品コード"
        Me.txt商品コード.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt商品コード.Text = "NNNNNNN"
        Me.txt商品コード.Top = 0!
        Me.txt商品コード.Width = 0.7086614!
        '
        'txtメーカ名
        '
        Me.txtメーカ名.CanGrow = False
        Me.txtメーカ名.DataField = "メーカ名"
        Me.txtメーカ名.Height = 0.1771653!
        Me.txtメーカ名.Left = 0.8366141!
        Me.txtメーカ名.Name = "txtメーカ名"
        Me.txtメーカ名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txtメーカ名.Text = "XXXXXXXXXX"
        Me.txtメーカ名.Top = 0!
        Me.txtメーカ名.Width = 1.053937!
        '
        'txtメーカ品番
        '
        Me.txtメーカ品番.CanGrow = False
        Me.txtメーカ品番.DataField = "メーカ品番"
        Me.txtメーカ品番.Height = 0.1771653!
        Me.txtメーカ品番.Left = 1.909449!
        Me.txtメーカ品番.Name = "txtメーカ品番"
        Me.txtメーカ品番.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txtメーカ品番.Text = "XXXXXXXXXX"
        Me.txtメーカ品番.Top = 0!
        Me.txtメーカ品番.Width = 1.968504!
        '
        'txt単位名
        '
        Me.txt単位名.CanGrow = False
        Me.txt単位名.DataField = "単位名"
        Me.txt単位名.Height = 0.1771653!
        Me.txt単位名.Left = 6.397638!
        Me.txt単位名.Name = "txt単位名"
        Me.txt単位名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt単位名.Text = "XXXX"
        Me.txt単位名.Top = 0!
        Me.txt単位名.Width = 0.380315!
        '
        'txt前月末数量
        '
        Me.txt前月末数量.CanGrow = False
        Me.txt前月末数量.DataField = "前月末数量"
        Me.txt前月末数量.Height = 0.1771653!
        Me.txt前月末数量.Left = 5.866142!
        Me.txt前月末数量.Name = "txt前月末数量"
        Me.txt前月末数量.Style = "font-family: メイリオ; font-size: 9pt; text-align: right; text-justify: auto"
        Me.txt前月末数量.Text = "NNNNN"
        Me.txt前月末数量.Top = 0!
        Me.txt前月末数量.Width = 0.511811!
        '
        'lbl前月末在庫
        '
        Me.lbl前月末在庫.Height = 0.1771654!
        Me.lbl前月末在庫.HyperLink = Nothing
        Me.lbl前月末在庫.Left = 5.019685!
        Me.lbl前月末在庫.Name = "lbl前月末在庫"
        Me.lbl前月末在庫.Style = "font-family: メイリオ; font-size: 9pt; text-align: center"
        Me.lbl前月末在庫.Text = "前月末残数量"
        Me.lbl前月末在庫.Top = 0!
        Me.lbl前月末在庫.Width = 0.82144!
        '
        'txt商品名
        '
        Me.txt商品名.CanGrow = False
        Me.txt商品名.DataField = "商品名"
        Me.txt商品名.Height = 0.1771653!
        Me.txt商品名.Left = 0.8366142!
        Me.txt商品名.Name = "txt商品名"
        Me.txt商品名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt商品名.Text = "XXXXXXXXXX"
        Me.txt商品名.Top = 0.1720472!
        Me.txt商品名.Width = 1.968504!
        '
        'txt規格
        '
        Me.txt規格.CanGrow = False
        Me.txt規格.DataField = "規格"
        Me.txt規格.Height = 0.1771653!
        Me.txt規格.Left = 2.829528!
        Me.txt規格.Name = "txt規格"
        Me.txt規格.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt規格.Text = "XXXXXXXXXX"
        Me.txt規格.Top = 0.1720472!
        Me.txt規格.Width = 1.968504!
        '
        'Shape商品
        '
        Me.Shape商品.Height = 0.3543307!
        Me.Shape商品.Left = 0.0492126!
        Me.Shape商品.Name = "Shape商品"
        Me.Shape商品.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape商品.Top = 0!
        Me.Shape商品.Width = 9.62126!
        '
        'GF商品
        '
        Me.GF商品.Height = 0!
        Me.GF商品.Name = "GF商品"
        Me.GF商品.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        '
        'GH入出庫
        '
        Me.GH入出庫.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt残在庫数量, Me.txt在庫単位名, Me.txt出庫数量, Me.txt入庫数量, Me.txt入出庫区分, Me.txt取引先名, Me.txt入出庫日付, Me.txt入出庫番号, Me.txt入出庫行番号, Me.txt取引先コード, Me.LineTop入出庫})
        Me.GH入出庫.DataField = "入出庫情報_ID"
        Me.GH入出庫.Height = 0.1771654!
        Me.GH入出庫.Name = "GH入出庫"
        Me.GH入出庫.UnderlayNext = True
        '
        'txt残在庫数量
        '
        Me.txt残在庫数量.CanGrow = False
        Me.txt残在庫数量.DataField = "残在庫数量"
        Me.txt残在庫数量.Height = 0.1771653!
        Me.txt残在庫数量.Left = 5.866142!
        Me.txt残在庫数量.Name = "txt残在庫数量"
        Me.txt残在庫数量.Style = "font-family: メイリオ; font-size: 9pt; text-align: right; text-justify: auto"
        Me.txt残在庫数量.Text = "NNNNN"
        Me.txt残在庫数量.Top = 0!
        Me.txt残在庫数量.Width = 0.511811!
        '
        'txt在庫単位名
        '
        Me.txt在庫単位名.CanGrow = False
        Me.txt在庫単位名.DataField = "在庫単位名"
        Me.txt在庫単位名.Height = 0.1771653!
        Me.txt在庫単位名.Left = 6.397638!
        Me.txt在庫単位名.Name = "txt在庫単位名"
        Me.txt在庫単位名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt在庫単位名.Text = "XXXX"
        Me.txt在庫単位名.Top = 0!
        Me.txt在庫単位名.Width = 0.380315!
        '
        'txt出庫数量
        '
        Me.txt出庫数量.CanGrow = False
        Me.txt出庫数量.DataField = "出庫数量"
        Me.txt出庫数量.Height = 0.1771653!
        Me.txt出庫数量.Left = 5.290157!
        Me.txt出庫数量.Name = "txt出庫数量"
        Me.txt出庫数量.Style = "font-family: メイリオ; font-size: 9pt; text-align: right; text-justify: auto"
        Me.txt出庫数量.Text = "NNNNN"
        Me.txt出庫数量.Top = 0!
        Me.txt出庫数量.Width = 0.511811!
        '
        'txt入庫数量
        '
        Me.txt入庫数量.CanGrow = False
        Me.txt入庫数量.DataField = "入庫数量"
        Me.txt入庫数量.Height = 0.1771653!
        Me.txt入庫数量.Left = 4.728346!
        Me.txt入庫数量.Name = "txt入庫数量"
        Me.txt入庫数量.Style = "font-family: メイリオ; font-size: 9pt; text-align: right; text-justify: auto"
        Me.txt入庫数量.Text = "NNNNN"
        Me.txt入庫数量.Top = 0!
        Me.txt入庫数量.Width = 0.511811!
        '
        'txt入出庫区分
        '
        Me.txt入出庫区分.CanGrow = False
        Me.txt入出庫区分.DataField = "入出庫区分"
        Me.txt入出庫区分.Height = 0.1771653!
        Me.txt入出庫区分.Left = 4.281496!
        Me.txt入出庫区分.Name = "txt入出庫区分"
        Me.txt入出庫区分.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt入出庫区分.Text = "XXXX"
        Me.txt入出庫区分.Top = 0!
        Me.txt入出庫区分.Width = 0.380315!
        '
        'txt取引先名
        '
        Me.txt取引先名.CanGrow = False
        Me.txt取引先名.DataField = "取引先名"
        Me.txt取引先名.Height = 0.1771653!
        Me.txt取引先名.Left = 3.153543!
        Me.txt取引先名.Name = "txt取引先名"
        Me.txt取引先名.Style = "font-family: メイリオ; font-size: 9pt; text-align: left; text-justify: auto"
        Me.txt取引先名.Text = "XXXXXXXXXXXXXXXX"
        Me.txt取引先名.Top = 0!
        Me.txt取引先名.Width = 1.053937!
        '
        'txt入出庫日付
        '
        Me.txt入出庫日付.CanGrow = False
        Me.txt入出庫日付.DataField = "入出庫日付"
        Me.txt入出庫日付.Height = 0.1771653!
        Me.txt入出庫日付.Left = 0.09842519!
        Me.txt入出庫日付.Name = "txt入出庫日付"
        Me.txt入出庫日付.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt入出庫日付.Text = "XXXXXXXXXX"
        Me.txt入出庫日付.Top = 0!
        Me.txt入出庫日付.Width = 0.8858263!
        '
        'txt入出庫番号
        '
        Me.txt入出庫番号.CanGrow = False
        Me.txt入出庫番号.DataField = "入出庫番号"
        Me.txt入出庫番号.Height = 0.1771653!
        Me.txt入出庫番号.Left = 1.0!
        Me.txt入出庫番号.Name = "txt入出庫番号"
        Me.txt入出庫番号.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt入出庫番号.Text = "NNNNNNNNNN"
        Me.txt入出庫番号.Top = 0!
        Me.txt入出庫番号.Width = 0.8858268!
        '
        'txt入出庫行番号
        '
        Me.txt入出庫行番号.CanGrow = False
        Me.txt入出庫行番号.DataField = "入出庫行番号"
        Me.txt入出庫行番号.Height = 0.1771653!
        Me.txt入出庫行番号.Left = 1.909449!
        Me.txt入出庫行番号.Name = "txt入出庫行番号"
        Me.txt入出庫行番号.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt入出庫行番号.Text = "NNN"
        Me.txt入出庫行番号.Top = 0!
        Me.txt入出庫行番号.Width = 0.3228346!
        '
        'txt取引先コード
        '
        Me.txt取引先コード.CanGrow = False
        Me.txt取引先コード.DataField = "取引先コード"
        Me.txt取引先コード.Height = 0.1771653!
        Me.txt取引先コード.Left = 2.251968!
        Me.txt取引先コード.Name = "txt取引先コード"
        Me.txt取引先コード.Style = "font-family: メイリオ; font-size: 9pt; text-align: center; text-justify: auto"
        Me.txt取引先コード.Text = "NNNNNNNNNN"
        Me.txt取引先コード.Top = 0!
        Me.txt取引先コード.Width = 0.8858268!
        '
        'LineTop入出庫
        '
        Me.LineTop入出庫.Height = 0.0001804233!
        Me.LineTop入出庫.Left = 0.04921257!
        Me.LineTop入出庫.LineWeight = 1.0!
        Me.LineTop入出庫.Name = "LineTop入出庫"
        Me.LineTop入出庫.Top = 0!
        Me.LineTop入出庫.Width = 9.62126!
        Me.LineTop入出庫.X1 = 0.04921257!
        Me.LineTop入出庫.X2 = 9.670472!
        Me.LineTop入出庫.Y1 = 0.0001804233!
        Me.LineTop入出庫.Y2 = 0!
        '
        'GF入出庫
        '
        Me.GF入出庫.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.LineBottom入出庫})
        Me.GF入出庫.Height = 0!
        Me.GF入出庫.Name = "GF入出庫"
        '
        'LineBottom入出庫
        '
        Me.LineBottom入出庫.Height = 0.0001804233!
        Me.LineBottom入出庫.Left = 0.0492126!
        Me.LineBottom入出庫.LineWeight = 1.0!
        Me.LineBottom入出庫.Name = "LineBottom入出庫"
        Me.LineBottom入出庫.Top = 0!
        Me.LineBottom入出庫.Width = 9.621261!
        Me.LineBottom入出庫.X1 = 0.0492126!
        Me.LineBottom入出庫.X2 = 9.670473!
        Me.LineBottom入出庫.Y1 = 0.0001804233!
        Me.LineBottom入出庫.Y2 = 0!
        '
        'GH倉庫
        '
        Me.GH倉庫.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape倉庫, Me.lbl事業所, Me.txt事業所名, Me.lbl倉庫, Me.txt倉庫名})
        Me.GH倉庫.DataField = "倉庫コード"
        Me.GH倉庫.Height = 0.7480315!
        Me.GH倉庫.Name = "GH倉庫"
        Me.GH倉庫.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.All
        '
        'lbl事業所
        '
        Me.lbl事業所.Height = 0.2165354!
        Me.lbl事業所.HyperLink = Nothing
        Me.lbl事業所.Left = 0.09842515!
        Me.lbl事業所.Name = "lbl事業所"
        Me.lbl事業所.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: right"
        Me.lbl事業所.Text = "事業所："
        Me.lbl事業所.Top = 0!
        Me.lbl事業所.Width = 0.7086614!
        '
        'txt事業所名
        '
        Me.txt事業所名.CanGrow = False
        Me.txt事業所名.DataField = "事業所名"
        Me.txt事業所名.Height = 0.2165354!
        Me.txt事業所名.Left = 0.8070866!
        Me.txt事業所名.Name = "txt事業所名"
        Me.txt事業所名.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: left; text-justify: auto"
        Me.txt事業所名.Text = "XXXXXXXXXX"
        Me.txt事業所名.Top = 0!
        Me.txt事業所名.Width = 1.702756!
        '
        'lbl倉庫
        '
        Me.lbl倉庫.Height = 0.2165354!
        Me.lbl倉庫.HyperLink = Nothing
        Me.lbl倉庫.Left = 2.633071!
        Me.lbl倉庫.Name = "lbl倉庫"
        Me.lbl倉庫.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: right"
        Me.lbl倉庫.Text = "倉庫："
        Me.lbl倉庫.Top = 0!
        Me.lbl倉庫.Width = 0.7086611!
        '
        'txt倉庫名
        '
        Me.txt倉庫名.CanGrow = False
        Me.txt倉庫名.DataField = "倉庫名"
        Me.txt倉庫名.Height = 0.2165354!
        Me.txt倉庫名.Left = 3.346457!
        Me.txt倉庫名.Name = "txt倉庫名"
        Me.txt倉庫名.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: left; text-justify: auto"
        Me.txt倉庫名.Text = "XXXXXXXXXX"
        Me.txt倉庫名.Top = 0!
        Me.txt倉庫名.Width = 1.702756!
        '
        'GF倉庫
        '
        Me.GF倉庫.Height = 0!
        Me.GF倉庫.Name = "GF倉庫"
        Me.GF倉庫.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        '
        'HARK502Reports
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 9.68504!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PH帳票)
        Me.Sections.Add(Me.GH倉庫)
        Me.Sections.Add(Me.GH商品)
        Me.Sections.Add(Me.GH入出庫)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GF入出庫)
        Me.Sections.Add(Me.GF商品)
        Me.Sections.Add(Me.GF倉庫)
        Me.Sections.Add(Me.PF帳票)
        Me.ShowParameterUI = False
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: ""MS UI Gothic""; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; font-family: ""MS UI Gothic""; ddo-char-set: 12" &
            "8", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; font-style: inherit; font-family: ""MS UI Goth" &
            "ic""; ddo-char-set: 128", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 128", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt詳細入出庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt詳細単位名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt有効期限, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtロット, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblプログラム, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl会社, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIページ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt商品コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtメーカ名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtメーカ品番, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt単位名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt前月末数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl前月末在庫, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt商品名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt規格, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt残在庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt在庫単位名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt出庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入出庫区分, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt取引先名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入出庫日付, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入出庫番号, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt入出庫行番号, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt取引先コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl事業所, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt事業所名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl倉庫, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt倉庫名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents GH商品 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GF商品 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents GH入出庫 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GF入出庫 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt詳細入出庫数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt詳細単位名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt有効期限 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtロット As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt残在庫数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt在庫単位名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt出庫数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt入庫数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt入出庫区分 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt取引先名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt入出庫行番号 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt入出庫日付 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt入出庫番号 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt取引先コード As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt商品コード As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtメーカ名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtメーカ品番 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt単位名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt前月末数量 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lbl前月末在庫 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt商品名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt規格 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents LineLeftロット As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineRight出庫数量 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineRight入庫数量 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineRight入出庫区分 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineLeft入出庫区分 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape商品 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape倉庫 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents LineRightDetail As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineTopDetail As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineLeftDetail As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineTop入出庫 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents LineBottom入出庫 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents lblプログラム As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl会社 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents RIページ As GrapeCity.ActiveReports.SectionReportModel.ReportInfo
    Private WithEvents GH倉庫 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GF倉庫 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents lbl事業所 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt事業所名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lbl倉庫 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt倉庫名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
