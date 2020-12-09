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
        Me.lbl帳票名 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.RIページ = New GrapeCity.ActiveReports.SectionReportModel.ReportInfo()
        Me.RI日付 = New GrapeCity.ActiveReports.SectionReportModel.ReportInfo()
        Me.lbl条件 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt出力条件 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
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
        Me.lbl商品コード = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblメーカ = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblメーカ品番 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl商品名 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl規格 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl入出庫日 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl入出庫番号 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl取引先 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl入出庫区分 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl入荷数量 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl出荷数量 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl残数量 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblロットNo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl有効期限 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.GF倉庫 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.lbl帳票名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIページ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RI日付, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl条件, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt出力条件, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt詳細入出庫数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt詳細単位名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt有効期限, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtロット, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblプログラム, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl会社, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.lbl商品コード, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblメーカ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblメーカ品番, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl商品名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl規格, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl入出庫日, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl入出庫番号, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl取引先, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl入出庫区分, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl入荷数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl出荷数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl残数量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblロットNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl有効期限, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PH帳票
        '
        Me.PH帳票.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lbl帳票名, Me.RIページ, Me.RI日付, Me.lbl条件, Me.txt出力条件})
        Me.PH帳票.Height = 0.597441!
        Me.PH帳票.Name = "PH帳票"
        '
        'lbl帳票名
        '
        Me.lbl帳票名.Height = 0.3543307!
        Me.lbl帳票名.HyperLink = Nothing
        Me.lbl帳票名.Left = 2.93317!
        Me.lbl帳票名.Name = "lbl帳票名"
        Me.lbl帳票名.Style = "font-family: メイリオ; font-size: 20.25pt; text-align: center; vertical-align: middle" &
    "; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl帳票名.Text = "帳票名"
        Me.lbl帳票名.Top = 0!
        Me.lbl帳票名.Width = 4.72441!
        '
        'RIページ
        '
        Me.RIページ.FormatString = "{PageNumber} / {PageCount}"
        Me.RIページ.Height = 0.1574803!
        Me.RIページ.Left = 8.651575!
        Me.RIページ.Name = "RIページ"
        Me.RIページ.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; vertical-align: middle"
        Me.RIページ.Top = 0.1574803!
        Me.RIページ.Width = 1.92933!
        '
        'RI日付
        '
        Me.RI日付.FormatString = "{RunDateTime:yyyy年M月d日}"
        Me.RI日付.Height = 0.1574803!
        Me.RI日付.Left = 8.661417!
        Me.RI日付.Name = "RI日付"
        Me.RI日付.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; vertical-align: middle"
        Me.RI日付.Top = 0!
        Me.RI日付.Width = 1.92933!
        '
        'lbl条件
        '
        Me.lbl条件.Height = 0.1574803!
        Me.lbl条件.HyperLink = Nothing
        Me.lbl条件.Left = 0.09842515!
        Me.lbl条件.Name = "lbl条件"
        Me.lbl条件.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl条件.Text = "【出力条件】："
        Me.lbl条件.Top = 0.3937008!
        Me.lbl条件.Width = 0.8366142!
        '
        'txt出力条件
        '
        Me.txt出力条件.CanGrow = False
        Me.txt出力条件.DistinctField = ""
        Me.txt出力条件.Height = 0.1574803!
        Me.txt出力条件.Left = 0.9350393!
        Me.txt出力条件.MultiLine = False
        Me.txt出力条件.Name = "txt出力条件"
        Me.txt出力条件.Style = "color: Black; font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justif" &
    "y: auto; vertical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt出力条件.SummaryGroup = ""
        Me.txt出力条件.Text = "XXXXXXXXXX"
        Me.txt出力条件.Top = 0.3937008!
        Me.txt出力条件.Width = 3.395669!
        '
        'Shape倉庫
        '
        Me.Shape倉庫.Height = 0.472441!
        Me.Shape倉庫.Left = 0.02440945!
        Me.Shape倉庫.Name = "Shape倉庫"
        Me.Shape倉庫.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape倉庫.Top = 0.2165354!
        Me.Shape倉庫.Width = 10.5563!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt詳細入出庫数量, Me.txt詳細単位名, Me.txt有効期限, Me.txtロット, Me.LineLeftロット, Me.LineLeft入出庫区分, Me.LineRight入出庫区分, Me.LineRight入庫数量, Me.LineRight出庫数量, Me.LineRightDetail, Me.LineTopDetail, Me.LineLeftDetail})
        Me.Detail.Height = 0.1574803!
        Me.Detail.Name = "Detail"
        '
        'txt詳細入出庫数量
        '
        Me.txt詳細入出庫数量.CanGrow = False
        Me.txt詳細入出庫数量.DataField = "詳細入出庫数量"
        Me.txt詳細入出庫数量.Height = 0.1574803!
        Me.txt詳細入出庫数量.Left = 8.095276!
        Me.txt詳細入出庫数量.Name = "txt詳細入出庫数量"
        Me.txt詳細入出庫数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; text-justify: auto; vert" &
    "ical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt詳細入出庫数量.Text = "NNNNN"
        Me.txt詳細入出庫数量.Top = 0!
        Me.txt詳細入出庫数量.Width = 0.472441!
        '
        'txt詳細単位名
        '
        Me.txt詳細単位名.CanGrow = False
        Me.txt詳細単位名.DataField = "詳細単位名"
        Me.txt詳細単位名.Height = 0.1574803!
        Me.txt詳細単位名.Left = 8.587401!
        Me.txt詳細単位名.Name = "txt詳細単位名"
        Me.txt詳細単位名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt詳細単位名.Text = "XXXX"
        Me.txt詳細単位名.Top = 0!
        Me.txt詳細単位名.Width = 0.3543307!
        '
        'txt有効期限
        '
        Me.txt有効期限.CanGrow = False
        Me.txt有効期限.DataField = "有効期限"
        Me.txt有効期限.Height = 0.1574803!
        Me.txt有効期限.Left = 9.768504!
        Me.txt有効期限.Name = "txt有効期限"
        Me.txt有効期限.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt有効期限.Text = "XXXXXXXXXX"
        Me.txt有効期限.Top = 0!
        Me.txt有効期限.Width = 0.7874016!
        '
        'txtロット
        '
        Me.txtロット.CanGrow = False
        Me.txtロット.DataField = "ロット"
        Me.txtロット.Height = 0.1574803!
        Me.txtロット.Left = 8.956693!
        Me.txtロット.Name = "txtロット"
        Me.txtロット.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txtロット.Text = "XXXXXXXXXX"
        Me.txtロット.Top = 0!
        Me.txtロット.Width = 0.7874016!
        '
        'LineLeftロット
        '
        Me.LineLeftロット.Height = 0.1574803!
        Me.LineLeftロット.Left = 8.070867!
        Me.LineLeftロット.LineWeight = 1.0!
        Me.LineLeftロット.Name = "LineLeftロット"
        Me.LineLeftロット.Top = 0!
        Me.LineLeftロット.Width = 0!
        Me.LineLeftロット.X1 = 8.070867!
        Me.LineLeftロット.X2 = 8.070867!
        Me.LineLeftロット.Y1 = 0!
        Me.LineLeftロット.Y2 = 0.1574803!
        '
        'LineLeft入出庫区分
        '
        Me.LineLeft入出庫区分.Height = 0.1574803!
        Me.LineLeft入出庫区分.Left = 5.757874!
        Me.LineLeft入出庫区分.LineWeight = 1.0!
        Me.LineLeft入出庫区分.Name = "LineLeft入出庫区分"
        Me.LineLeft入出庫区分.Top = 0!
        Me.LineLeft入出庫区分.Width = 0!
        Me.LineLeft入出庫区分.X1 = 5.757874!
        Me.LineLeft入出庫区分.X2 = 5.757874!
        Me.LineLeft入出庫区分.Y1 = 0!
        Me.LineLeft入出庫区分.Y2 = 0.1574803!
        '
        'LineRight入出庫区分
        '
        Me.LineRight入出庫区分.Height = 0.1574803!
        Me.LineRight入出庫区分.Left = 6.151575!
        Me.LineRight入出庫区分.LineWeight = 1.0!
        Me.LineRight入出庫区分.Name = "LineRight入出庫区分"
        Me.LineRight入出庫区分.Top = 0!
        Me.LineRight入出庫区分.Width = 0!
        Me.LineRight入出庫区分.X1 = 6.151575!
        Me.LineRight入出庫区分.X2 = 6.151575!
        Me.LineRight入出庫区分.Y1 = 0!
        Me.LineRight入出庫区分.Y2 = 0.1574803!
        '
        'LineRight入庫数量
        '
        Me.LineRight入庫数量.Height = 0.1574803!
        Me.LineRight入庫数量.Left = 6.66811!
        Me.LineRight入庫数量.LineWeight = 1.0!
        Me.LineRight入庫数量.Name = "LineRight入庫数量"
        Me.LineRight入庫数量.Top = 0!
        Me.LineRight入庫数量.Width = 0!
        Me.LineRight入庫数量.X1 = 6.66811!
        Me.LineRight入庫数量.X2 = 6.66811!
        Me.LineRight入庫数量.Y1 = 0!
        Me.LineRight入庫数量.Y2 = 0.1574803!
        '
        'LineRight出庫数量
        '
        Me.LineRight出庫数量.Height = 0.1574803!
        Me.LineRight出庫数量.Left = 7.18504!
        Me.LineRight出庫数量.LineWeight = 1.0!
        Me.LineRight出庫数量.Name = "LineRight出庫数量"
        Me.LineRight出庫数量.Top = 0!
        Me.LineRight出庫数量.Width = 0!
        Me.LineRight出庫数量.X1 = 7.18504!
        Me.LineRight出庫数量.X2 = 7.18504!
        Me.LineRight出庫数量.Y1 = 0!
        Me.LineRight出庫数量.Y2 = 0.1574803!
        '
        'LineRightDetail
        '
        Me.LineRightDetail.Height = 0.1574803!
        Me.LineRightDetail.Left = 10.58071!
        Me.LineRightDetail.LineWeight = 1.0!
        Me.LineRightDetail.Name = "LineRightDetail"
        Me.LineRightDetail.Top = 0!
        Me.LineRightDetail.Width = 0!
        Me.LineRightDetail.X1 = 10.58071!
        Me.LineRightDetail.X2 = 10.58071!
        Me.LineRightDetail.Y1 = 0!
        Me.LineRightDetail.Y2 = 0.1574803!
        '
        'LineTopDetail
        '
        Me.LineTopDetail.Height = 0!
        Me.LineTopDetail.Left = 8.070867!
        Me.LineTopDetail.LineWeight = 1.0!
        Me.LineTopDetail.Name = "LineTopDetail"
        Me.LineTopDetail.Top = 0!
        Me.LineTopDetail.Width = 2.509844!
        Me.LineTopDetail.X1 = 8.070867!
        Me.LineTopDetail.X2 = 10.58071!
        Me.LineTopDetail.Y1 = 0!
        Me.LineTopDetail.Y2 = 0!
        '
        'LineLeftDetail
        '
        Me.LineLeftDetail.Height = 0.1574803!
        Me.LineLeftDetail.Left = 0.02440945!
        Me.LineLeftDetail.LineWeight = 1.0!
        Me.LineLeftDetail.Name = "LineLeftDetail"
        Me.LineLeftDetail.Top = 0!
        Me.LineLeftDetail.Width = 0!
        Me.LineLeftDetail.X1 = 0.02440945!
        Me.LineLeftDetail.X2 = 0.02440945!
        Me.LineLeftDetail.Y1 = 0!
        Me.LineLeftDetail.Y2 = 0.1574803!
        '
        'PF帳票
        '
        Me.PF帳票.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lblプログラム, Me.lbl会社})
        Me.PF帳票.Height = 0.1377953!
        Me.PF帳票.Name = "PF帳票"
        '
        'lblプログラム
        '
        Me.lblプログラム.Height = 0.1574803!
        Me.lblプログラム.HyperLink = Nothing
        Me.lblプログラム.Left = 0.0492126!
        Me.lblプログラム.Name = "lblプログラム"
        Me.lblプログラム.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle"
        Me.lblプログラム.Text = "HARK502"
        Me.lblプログラム.Top = 0!
        Me.lblプログラム.Width = 0.6299213!
        '
        'lbl会社
        '
        Me.lbl会社.Height = 0.1574803!
        Me.lbl会社.HyperLink = Nothing
        Me.lbl会社.Left = 9.177953!
        Me.lbl会社.Name = "lbl会社"
        Me.lbl会社.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; vertical-align: middle"
        Me.lbl会社.Text = "アイティーアイ株式会社"
        Me.lbl会社.Top = 0!
        Me.lbl会社.Width = 1.402756!
        '
        'GH商品
        '
        Me.GH商品.ColumnLayout = False
        Me.GH商品.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt商品コード, Me.txtメーカ名, Me.txtメーカ品番, Me.txt単位名, Me.txt前月末数量, Me.lbl前月末在庫, Me.txt商品名, Me.txt規格, Me.Shape商品})
        Me.GH商品.DataField = "商品コード"
        Me.GH商品.Height = 0.3149606!
        Me.GH商品.Name = "GH商品"
        Me.GH商品.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.All
        '
        'txt商品コード
        '
        Me.txt商品コード.CanGrow = False
        Me.txt商品コード.DataField = "商品コード"
        Me.txt商品コード.Height = 0.1574803!
        Me.txt商品コード.Left = 0.0492126!
        Me.txt商品コード.Name = "txt商品コード"
        Me.txt商品コード.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt商品コード.Text = "NNNNNNN"
        Me.txt商品コード.Top = 0!
        Me.txt商品コード.Width = 0.6299213!
        '
        'txtメーカ名
        '
        Me.txtメーカ名.CanGrow = False
        Me.txtメーカ名.DataField = "メーカ名"
        Me.txtメーカ名.Height = 0.1574803!
        Me.txtメーカ名.Left = 0.7133858!
        Me.txtメーカ名.Name = "txtメーカ名"
        Me.txtメーカ名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txtメーカ名.Text = "XXXXXXXXXX"
        Me.txtメーカ名.Top = 0!
        Me.txtメーカ名.Width = 1.102362!
        '
        'txtメーカ品番
        '
        Me.txtメーカ品番.CanGrow = False
        Me.txtメーカ品番.DataField = "メーカ品番"
        Me.txtメーカ品番.Height = 0.1574803!
        Me.txtメーカ品番.Left = 1.845669!
        Me.txtメーカ品番.Name = "txtメーカ品番"
        Me.txtメーカ品番.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txtメーカ品番.Text = "XXXXXXXXXX"
        Me.txtメーカ品番.Top = 0!
        Me.txtメーカ品番.Width = 1.968504!
        '
        'txt単位名
        '
        Me.txt単位名.CanGrow = False
        Me.txt単位名.DataField = "単位名"
        Me.txt単位名.Height = 0.1574803!
        Me.txt単位名.Left = 7.701575!
        Me.txt単位名.Name = "txt単位名"
        Me.txt単位名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt単位名.Text = "XXXX"
        Me.txt単位名.Top = 0!
        Me.txt単位名.Width = 0.3543307!
        '
        'txt前月末数量
        '
        Me.txt前月末数量.CanGrow = False
        Me.txt前月末数量.DataField = "前月末数量"
        Me.txt前月末数量.Height = 0.1574803!
        Me.txt前月末数量.Left = 7.209449!
        Me.txt前月末数量.Name = "txt前月末数量"
        Me.txt前月末数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; text-justify: auto; vert" &
    "ical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt前月末数量.Text = "NNNNN"
        Me.txt前月末数量.Top = 0!
        Me.txt前月末数量.Width = 0.472441!
        '
        'lbl前月末在庫
        '
        Me.lbl前月末在庫.Height = 0.1574803!
        Me.lbl前月末在庫.HyperLink = Nothing
        Me.lbl前月末在庫.Left = 6.358268!
        Me.lbl前月末在庫.Name = "lbl前月末在庫"
        Me.lbl前月末在庫.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; vertical-align: middle;" &
    " white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl前月末在庫.Text = "前月末残数量"
        Me.lbl前月末在庫.Top = 0!
        Me.lbl前月末在庫.Width = 0.8267716!
        '
        'txt商品名
        '
        Me.txt商品名.CanGrow = False
        Me.txt商品名.DataField = "商品名"
        Me.txt商品名.Height = 0.1574803!
        Me.txt商品名.Left = 0.7133858!
        Me.txt商品名.Name = "txt商品名"
        Me.txt商品名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt商品名.Text = "XXXXXXXXXX"
        Me.txt商品名.Top = 0.1574803!
        Me.txt商品名.Width = 1.968504!
        '
        'txt規格
        '
        Me.txt規格.CanGrow = False
        Me.txt規格.DataField = "規格"
        Me.txt規格.Height = 0.1574803!
        Me.txt規格.Left = 2.706693!
        Me.txt規格.Name = "txt規格"
        Me.txt規格.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt規格.Text = "XXXXXXXXXX"
        Me.txt規格.Top = 0.1574803!
        Me.txt規格.Width = 1.968504!
        '
        'Shape商品
        '
        Me.Shape商品.Height = 0.3149606!
        Me.Shape商品.Left = 0.02440945!
        Me.Shape商品.Name = "Shape商品"
        Me.Shape商品.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape商品.Top = 0!
        Me.Shape商品.Width = 10.5563!
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
        Me.GH入出庫.Height = 0.1574803!
        Me.GH入出庫.Name = "GH入出庫"
        Me.GH入出庫.UnderlayNext = True
        '
        'txt残在庫数量
        '
        Me.txt残在庫数量.CanGrow = False
        Me.txt残在庫数量.DataField = "残在庫数量"
        Me.txt残在庫数量.Height = 0.1574803!
        Me.txt残在庫数量.Left = 7.209449!
        Me.txt残在庫数量.Name = "txt残在庫数量"
        Me.txt残在庫数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; text-justify: auto; vert" &
    "ical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt残在庫数量.Text = "NNNNN"
        Me.txt残在庫数量.Top = 0!
        Me.txt残在庫数量.Width = 0.472441!
        '
        'txt在庫単位名
        '
        Me.txt在庫単位名.CanGrow = False
        Me.txt在庫単位名.DataField = "在庫単位名"
        Me.txt在庫単位名.Height = 0.1574803!
        Me.txt在庫単位名.Left = 7.701575!
        Me.txt在庫単位名.Name = "txt在庫単位名"
        Me.txt在庫単位名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt在庫単位名.Text = "XXXX"
        Me.txt在庫単位名.Top = 0!
        Me.txt在庫単位名.Width = 0.3543307!
        '
        'txt出庫数量
        '
        Me.txt出庫数量.CanGrow = False
        Me.txt出庫数量.DataField = "出庫数量"
        Me.txt出庫数量.Height = 0.1574803!
        Me.txt出庫数量.Left = 6.692914!
        Me.txt出庫数量.Name = "txt出庫数量"
        Me.txt出庫数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; text-justify: auto; vert" &
    "ical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt出庫数量.Text = "NNNNN"
        Me.txt出庫数量.Top = 0!
        Me.txt出庫数量.Width = 0.472441!
        '
        'txt入庫数量
        '
        Me.txt入庫数量.CanGrow = False
        Me.txt入庫数量.DataField = "入庫数量"
        Me.txt入庫数量.Height = 0.1574803!
        Me.txt入庫数量.Left = 6.175984!
        Me.txt入庫数量.Name = "txt入庫数量"
        Me.txt入庫数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: right; text-justify: auto; vert" &
    "ical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt入庫数量.Text = "NNNNN"
        Me.txt入庫数量.Top = 0!
        Me.txt入庫数量.Width = 0.472441!
        '
        'txt入出庫区分
        '
        Me.txt入出庫区分.CanGrow = False
        Me.txt入出庫区分.DataField = "入出庫区分"
        Me.txt入出庫区分.Height = 0.1574803!
        Me.txt入出庫区分.Left = 5.782283!
        Me.txt入出庫区分.Name = "txt入出庫区分"
        Me.txt入出庫区分.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt入出庫区分.Text = "XXXX"
        Me.txt入出庫区分.Top = 0!
        Me.txt入出庫区分.Width = 0.3543307!
        '
        'txt取引先名
        '
        Me.txt取引先名.CanGrow = False
        Me.txt取引先名.DataField = "取引先名"
        Me.txt取引先名.Height = 0.1574803!
        Me.txt取引先名.Left = 2.927953!
        Me.txt取引先名.Name = "txt取引先名"
        Me.txt取引先名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; text-justify: auto; verti" &
    "cal-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt取引先名.Text = "XXXXXXXXXXXXXXXX"
        Me.txt取引先名.Top = 0!
        Me.txt取引先名.Width = 2.805512!
        '
        'txt入出庫日付
        '
        Me.txt入出庫日付.CanGrow = False
        Me.txt入出庫日付.DataField = "入出庫日付"
        Me.txt入出庫日付.DistinctField = ""
        Me.txt入出庫日付.Height = 0.1574803!
        Me.txt入出庫日付.Left = 0.0492126!
        Me.txt入出庫日付.MultiLine = False
        Me.txt入出庫日付.Name = "txt入出庫日付"
        Me.txt入出庫日付.Style = "color: Black; font-family: メイリオ; font-size: 8.25pt; text-align: center; text-just" &
    "ify: auto; vertical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt入出庫日付.SummaryGroup = ""
        Me.txt入出庫日付.Text = "XXXXXXXXXX"
        Me.txt入出庫日付.Top = 0!
        Me.txt入出庫日付.Width = 0.7874016!
        '
        'txt入出庫番号
        '
        Me.txt入出庫番号.CanGrow = False
        Me.txt入出庫番号.DataField = "入出庫番号"
        Me.txt入出庫番号.Height = 0.1574803!
        Me.txt入出庫番号.Left = 0.8614173!
        Me.txt入出庫番号.Name = "txt入出庫番号"
        Me.txt入出庫番号.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt入出庫番号.Text = "NNNNNNNNNN"
        Me.txt入出庫番号.Top = 0!
        Me.txt入出庫番号.Width = 0.8661417!
        '
        'txt入出庫行番号
        '
        Me.txt入出庫行番号.CanGrow = False
        Me.txt入出庫行番号.DataField = "入出庫行番号"
        Me.txt入出庫行番号.Height = 0.1574803!
        Me.txt入出庫行番号.Left = 1.74685!
        Me.txt入出庫行番号.Name = "txt入出庫行番号"
        Me.txt入出庫行番号.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt入出庫行番号.Text = "NNN"
        Me.txt入出庫行番号.Top = 0!
        Me.txt入出庫行番号.Width = 0.2755905!
        '
        'txt取引先コード
        '
        Me.txt取引先コード.CanGrow = False
        Me.txt取引先コード.DataField = "取引先コード"
        Me.txt取引先コード.Height = 0.1574803!
        Me.txt取引先コード.Left = 2.04252!
        Me.txt取引先コード.Name = "txt取引先コード"
        Me.txt取引先コード.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: center; text-justify: auto; ver" &
    "tical-align: middle; white-space: nowrap; ddo-wrap-mode: nowrap"
        Me.txt取引先コード.Text = "NNNNNNNNNN"
        Me.txt取引先コード.Top = 0!
        Me.txt取引先コード.Width = 0.8661417!
        '
        'LineTop入出庫
        '
        Me.LineTop入出庫.Height = 0!
        Me.LineTop入出庫.Left = 0.02440945!
        Me.LineTop入出庫.LineWeight = 1.0!
        Me.LineTop入出庫.Name = "LineTop入出庫"
        Me.LineTop入出庫.Top = 0!
        Me.LineTop入出庫.Width = 10.5563!
        Me.LineTop入出庫.X1 = 0.02440945!
        Me.LineTop入出庫.X2 = 10.58071!
        Me.LineTop入出庫.Y1 = 0!
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
        Me.LineBottom入出庫.Left = 0.02440945!
        Me.LineBottom入出庫.LineWeight = 1.0!
        Me.LineBottom入出庫.Name = "LineBottom入出庫"
        Me.LineBottom入出庫.Top = 0!
        Me.LineBottom入出庫.Width = 10.5563!
        Me.LineBottom入出庫.X1 = 0.02440945!
        Me.LineBottom入出庫.X2 = 10.58071!
        Me.LineBottom入出庫.Y1 = 0.0001804233!
        Me.LineBottom入出庫.Y2 = 0!
        '
        'GH倉庫
        '
        Me.GH倉庫.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.lbl事業所, Me.txt事業所名, Me.lbl倉庫, Me.txt倉庫名, Me.lbl商品コード, Me.lblメーカ, Me.lblメーカ品番, Me.lbl商品名, Me.lbl規格, Me.lbl入出庫日, Me.lbl入出庫番号, Me.lbl取引先, Me.lbl入出庫区分, Me.lbl入荷数量, Me.lbl出荷数量, Me.lbl残数量, Me.lblロットNo, Me.lbl有効期限, Me.Shape倉庫})
        Me.GH倉庫.DataField = "倉庫コード"
        Me.GH倉庫.Height = 0.6889764!
        Me.GH倉庫.Name = "GH倉庫"
        Me.GH倉庫.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.All
        '
        'lbl事業所
        '
        Me.lbl事業所.Height = 0.2165354!
        Me.lbl事業所.HyperLink = Nothing
        Me.lbl事業所.Left = 0.09842515!
        Me.lbl事業所.Name = "lbl事業所"
        Me.lbl事業所.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: right; vertical-align: middle"
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
        Me.txt事業所名.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: left; text-justify: auto; vert" &
    "ical-align: middle"
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
        Me.lbl倉庫.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: right; vertical-align: middle"
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
        Me.txt倉庫名.Style = "font-family: メイリオ; font-size: 11.25pt; text-align: left; text-justify: auto; vert" &
    "ical-align: middle"
        Me.txt倉庫名.Text = "XXXXXXXXXX"
        Me.txt倉庫名.Top = 0!
        Me.txt倉庫名.Width = 1.702756!
        '
        'lbl商品コード
        '
        Me.lbl商品コード.Height = 0.1574803!
        Me.lbl商品コード.HyperLink = Nothing
        Me.lbl商品コード.Left = 0.0492126!
        Me.lbl商品コード.Name = "lbl商品コード"
        Me.lbl商品コード.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl商品コード.Text = "商品コード"
        Me.lbl商品コード.Top = 0.2165354!
        Me.lbl商品コード.Width = 0.6299213!
        '
        'lblメーカ
        '
        Me.lblメーカ.Height = 0.1574803!
        Me.lblメーカ.HyperLink = Nothing
        Me.lblメーカ.Left = 0.7133858!
        Me.lblメーカ.Name = "lblメーカ"
        Me.lblメーカ.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lblメーカ.Text = "メーカ"
        Me.lblメーカ.Top = 0.2165354!
        Me.lblメーカ.Width = 1.102362!
        '
        'lblメーカ品番
        '
        Me.lblメーカ品番.Height = 0.1574803!
        Me.lblメーカ品番.HyperLink = Nothing
        Me.lblメーカ品番.Left = 1.845669!
        Me.lblメーカ品番.Name = "lblメーカ品番"
        Me.lblメーカ品番.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lblメーカ品番.Text = "メーカ品番"
        Me.lblメーカ品番.Top = 0.2165354!
        Me.lblメーカ品番.Width = 1.968504!
        '
        'lbl商品名
        '
        Me.lbl商品名.Height = 0.1574803!
        Me.lbl商品名.HyperLink = Nothing
        Me.lbl商品名.Left = 0.7133858!
        Me.lbl商品名.Name = "lbl商品名"
        Me.lbl商品名.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl商品名.Text = "商品名"
        Me.lbl商品名.Top = 0.3740157!
        Me.lbl商品名.Width = 1.968504!
        '
        'lbl規格
        '
        Me.lbl規格.Height = 0.1574803!
        Me.lbl規格.HyperLink = Nothing
        Me.lbl規格.Left = 2.706693!
        Me.lbl規格.Name = "lbl規格"
        Me.lbl規格.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl規格.Text = "規格"
        Me.lbl規格.Top = 0.3740157!
        Me.lbl規格.Width = 1.968504!
        '
        'lbl入出庫日
        '
        Me.lbl入出庫日.Height = 0.1574803!
        Me.lbl入出庫日.HyperLink = Nothing
        Me.lbl入出庫日.Left = 0.0492126!
        Me.lbl入出庫日.Name = "lbl入出庫日"
        Me.lbl入出庫日.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl入出庫日.Text = "入出庫日"
        Me.lbl入出庫日.Top = 0.531496!
        Me.lbl入出庫日.Width = 0.7874016!
        '
        'lbl入出庫番号
        '
        Me.lbl入出庫番号.Height = 0.1574803!
        Me.lbl入出庫番号.HyperLink = Nothing
        Me.lbl入出庫番号.Left = 0.8614173!
        Me.lbl入出庫番号.Name = "lbl入出庫番号"
        Me.lbl入出庫番号.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl入出庫番号.Text = "入出庫番号"
        Me.lbl入出庫番号.Top = 0.531496!
        Me.lbl入出庫番号.Width = 1.161023!
        '
        'lbl取引先
        '
        Me.lbl取引先.Height = 0.1574803!
        Me.lbl取引先.HyperLink = Nothing
        Me.lbl取引先.Left = 2.04252!
        Me.lbl取引先.Name = "lbl取引先"
        Me.lbl取引先.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl取引先.Text = "仕入先/得意先"
        Me.lbl取引先.Top = 0.531496!
        Me.lbl取引先.Width = 3.690945!
        '
        'lbl入出庫区分
        '
        Me.lbl入出庫区分.Height = 0.1574803!
        Me.lbl入出庫区分.HyperLink = Nothing
        Me.lbl入出庫区分.Left = 5.782283!
        Me.lbl入出庫区分.Name = "lbl入出庫区分"
        Me.lbl入出庫区分.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl入出庫区分.Text = "区分"
        Me.lbl入出庫区分.Top = 0.531496!
        Me.lbl入出庫区分.Width = 0.3543313!
        '
        'lbl入荷数量
        '
        Me.lbl入荷数量.Height = 0.1574803!
        Me.lbl入荷数量.HyperLink = Nothing
        Me.lbl入荷数量.Left = 6.175984!
        Me.lbl入荷数量.Name = "lbl入荷数量"
        Me.lbl入荷数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl入荷数量.Text = "入荷数量"
        Me.lbl入荷数量.Top = 0.531496!
        Me.lbl入荷数量.Width = 0.472441!
        '
        'lbl出荷数量
        '
        Me.lbl出荷数量.Height = 0.1574803!
        Me.lbl出荷数量.HyperLink = Nothing
        Me.lbl出荷数量.Left = 6.692914!
        Me.lbl出荷数量.Name = "lbl出荷数量"
        Me.lbl出荷数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl出荷数量.Text = "出荷数量"
        Me.lbl出荷数量.Top = 0.531496!
        Me.lbl出荷数量.Width = 0.4724408!
        '
        'lbl残数量
        '
        Me.lbl残数量.Height = 0.1574803!
        Me.lbl残数量.HyperLink = Nothing
        Me.lbl残数量.Left = 7.209449!
        Me.lbl残数量.Name = "lbl残数量"
        Me.lbl残数量.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl残数量.Text = "残数量"
        Me.lbl残数量.Top = 0.531496!
        Me.lbl残数量.Width = 0.8370078!
        '
        'lblロットNo
        '
        Me.lblロットNo.Height = 0.1574803!
        Me.lblロットNo.HyperLink = Nothing
        Me.lblロットNo.Left = 8.956693!
        Me.lblロットNo.Name = "lblロットNo"
        Me.lblロットNo.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lblロットNo.Text = "ロットNo"
        Me.lblロットNo.Top = 0.531496!
        Me.lblロットNo.Width = 0.7874012!
        '
        'lbl有効期限
        '
        Me.lbl有効期限.Height = 0.1574803!
        Me.lbl有効期限.HyperLink = Nothing
        Me.lbl有効期限.Left = 9.768504!
        Me.lbl有効期限.Name = "lbl有効期限"
        Me.lbl有効期限.Style = "font-family: メイリオ; font-size: 8.25pt; text-align: left; vertical-align: middle; w" &
    "hite-space: nowrap; ddo-wrap-mode: nowrap"
        Me.lbl有効期限.Text = "有効期限"
        Me.lbl有効期限.Top = 0.531496!
        Me.lbl有効期限.Width = 0.7874012!
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
        Me.PageSettings.Margins.Bottom = 0.3543307!
        Me.PageSettings.Margins.Left = 0.5511811!
        Me.PageSettings.Margins.Right = 0.5511811!
        Me.PageSettings.Margins.Top = 0.6692914!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 10.59075!
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
        CType(Me.lbl帳票名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIページ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RI日付, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl条件, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt出力条件, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt詳細入出庫数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt詳細単位名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt有効期限, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtロット, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblプログラム, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl会社, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.lbl商品コード, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblメーカ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblメーカ品番, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl商品名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl規格, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl入出庫日, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl入出庫番号, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl取引先, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl入出庫区分, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl入荷数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl出荷数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl残数量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblロットNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl有効期限, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents GH商品 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GF商品 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents GH入出庫 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GF入出庫 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents lbl帳票名 As GrapeCity.ActiveReports.SectionReportModel.Label
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
    Private WithEvents RI日付 As GrapeCity.ActiveReports.SectionReportModel.ReportInfo
    Private WithEvents lbl商品コード As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblメーカ As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblメーカ品番 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl商品名 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl規格 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl入出庫日 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl入出庫番号 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl取引先 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl入出庫区分 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl入荷数量 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl出荷数量 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl残数量 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lblロットNo As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl有効期限 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl条件 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt出力条件 As GrapeCity.ActiveReports.SectionReportModel.TextBox

    Public str帳票名 As String
    Public str出力条件 As String


End Class
