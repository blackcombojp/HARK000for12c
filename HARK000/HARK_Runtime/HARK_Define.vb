'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Module HARK_Define

    '*********************************************************************
    'アプリケーションタイトル
    '*********************************************************************
    Public Const DEVSection As String = "物流仕入部"
    Public Const DebugVer As String = "デバッグバージョン"


    '*********************************************************************
    '各メッセージ(プログラム）
    '*********************************************************************
    Public Const MSG_101001 As String = "取込ファイルを指定してください"
    Public Const MSG_101002 As String = "ファイル名が正しくありません"
    Public Const MSG_101103 As String = "ファイル拡張子が違います"
    Public Const MSG_101104 As String = "エラーデータ出力先を指定してください"
    Public Const MSG_101105 As String = "処理を開始しますか？"
    Public Const MSG_101106 As String = "受注データ取込中"
    Public Const MSG_101107 As String = "受注データ取込は正常終了しました"
    Public Const MSG_101108 As String = "受注データ取込は異常終了しました"
    Public Const MSG_101109 As String = "対象データはありません"
    Public Const MSG_101110 As String = "取込番号："
    Public Const MSG_101111 As String = "対象件数："
    Public Const MSG_101112 As String = "正常件数："
    Public Const MSG_101113 As String = "エラー件数："
    Public Const MSG_101114 As String = "汎用受注データ作成中"
    Public Const MSG_101115 As String = "エラーデータ出力中"
    Public Const MSG_101116 As String = "エラーデータ出力は正常終了しました"
    Public Const MSG_101117 As String = "エラーデータ出力は異常終了しました"
    Public Const MSG_101118 As String = "エラーデータ更新は正常終了しました"
    Public Const MSG_101119 As String = "エラーデータ更新は異常終了しました"
    Public Const MSG_101120 As String = "エラーデータはありません"
    Public Const MSG_101121 As String = "送信用エラーデータ出力中"
    Public Const MSG_101122 As String = "送信用エラーデータ出力は正常終了しました"
    Public Const MSG_101123 As String = "送信用エラーデータ出力は異常終了しました"
    Public Const MSG_101124 As String = "送信用エラーデータ更新は正常終了しました"
    Public Const MSG_101125 As String = "送信用エラーデータ更新は異常終了しました"
    Public Const MSG_101126 As String = "送信用エラーデータはありません"
    Public Const MSG_101127 As String = "エラーデータ送信中"
    Public Const MSG_101128 As String = "エラーデータ送信は正常終了しました"
    Public Const MSG_101129 As String = "エラーデータ送信は異常終了しました"
    Public Const MSG_101130 As String = "送信先アドレスが不明です"
    Public Const MSG_101131 As String = "汎用受注データ作成は正常終了しました"
    Public Const MSG_101132 As String = "汎用受注データ作成は異常終了しました"
    Public Const MSG_101133 As String = "得意先："
    Public Const MSG_101134 As String = "対象得意先一覧："

    Public Const MSG_201001 As String = "データ出力中"
    Public Const MSG_201002 As String = "データ出力は正常終了しました"
    Public Const MSG_201003 As String = "データ出力は異常終了しました"
    Public Const MSG_201004 As String = "データ更新は正常終了しました"
    Public Const MSG_201005 As String = "データ更新は異常終了しました"
    Public Const MSG_201006 As String = "該当データはありません"
    Public Const MSG_201007 As String = "ピッキング連携"
    Public Const MSG_201008 As String = "出荷検品未完了"
    Public Const MSG_201009 As String = "出力番号："
    Public Const MSG_201010 As String = "分納"
    Public Const MSG_201011 As String = "EXCEL"
    Public Const MSG_201012 As String = "有効期限切迫"
    Public Const MSG_201013 As String = "対象件数："



    Public Const MSG_301001 As String = "伝送番号："
    Public Const MSG_301002 As String = "実績送信データ作成中"
    Public Const MSG_301003 As String = "実績送信データ作成は正常終了しました"
    Public Const MSG_301004 As String = "実績送信データ作成は異常終了しました"
    Public Const MSG_301005 As String = "対象データはありません"
    Public Const MSG_301006 As String = "実績データ送信中"
    Public Const MSG_301007 As String = "実績データ送信は異常終了しました"
    Public Const MSG_301008 As String = "実績データ送信は正常終了しました"
    Public Const MSG_301009 As String = "データ更新は正常終了しました"
    Public Const MSG_301010 As String = "データ更新は異常終了しました"
    Public Const MSG_301011 As String = "対象日を指定してください"
    Public Const MSG_301012 As String = "日付の書式が間違っています"
    Public Const MSG_301013 As String = "OliverEANデータを指定してください"
    Public Const MSG_301014 As String = "データ取込中"
    Public Const MSG_301015 As String = "データ取込は正常終了しました"
    Public Const MSG_301016 As String = "データ取込は異常終了しました"
    Public Const MSG_301017 As String = "データ出力中"
    Public Const MSG_301018 As String = "データ出力は正常終了しました"
    Public Const MSG_301019 As String = "データ出力は異常終了しました"
    Public Const MSG_301020 As String = "件数："
    Public Const MSG_301021 As String = "データ出力先を指定してください"
    Public Const MSG_301022 As String = "[消費済みも出力]の場合、時間が掛かる可能性があります"
    Public Const MSG_301023 As String = "よろしいですか？"
    Public Const MSG_301024 As String = "未送信の実績ファイルがあります"
    Public Const MSG_301025 As String = "送信先アドレスが不明です"
    Public Const MSG_301026 As String = "[需要先全て]の場合、時間が掛かる可能性があります"
    Public Const MSG_301027 As String = "長期貸出番号を指定してください"
    Public Const MSG_301028 As String = "抹消日を指定してください"
    Public Const MSG_301029 As String = "既に消費済みの長期貸出番号です"
    Public Const MSG_301030 As String = "長期貸出番号の指定が不正です"
    Public Const MSG_301031 As String = "指定された長期貸出番号は存在しません"
    Public Const MSG_301032 As String = "抹消は正常終了しました"
    Public Const MSG_301033 As String = "抹消は異常終了しました"
    Public Const MSG_301034 As String = "指定された長期貸出番号は他の端末で表示中です"
    Public Const MSG_301035 As String = "商品コードの指定が不正です"
    Public Const MSG_301036 As String = "指定した商品コードは商品マスタに存在しません"
    Public Const MSG_301037 As String = "指定した商品コードは商品変換マスタで重複しています"
    Public Const MSG_301038 As String = "商品コードを指定してください"
    Public Const MSG_301039 As String = "院内コードを指定してください"
    Public Const MSG_301040 As String = "受注形態【不明】で確定はできません"
    Public Const MSG_301041 As String = "更新は正常終了しました"
    Public Const MSG_301042 As String = "更新は異常終了しました"
    Public Const MSG_301043 As String = "連携キーの指定が不正です"
    Public Const MSG_301044 As String = "連携キーを指定してください"
    Public Const MSG_301045 As String = "分納データを検索してください"
    Public Const MSG_301046 As String = "完了処理は正常終了しました"
    Public Const MSG_301047 As String = "完了処理は異常終了しました"

    Public Const MSG_304001 As String = "売掛先を指定してください"
    Public Const MSG_304002 As String = "対象開始日を指定してください"
    Public Const MSG_304003 As String = "対象終了日を指定してください"
    Public Const MSG_304004 As String = "対象データ出力中"
    Public Const MSG_304005 As String = "出力データが見つかりません"


    Public Const MSG_401001 As String = "チェック結果出力中"
    Public Const MSG_401002 As String = "出力中"
    Public Const MSG_401003 As String = "出力は異常終了しました"
    Public Const MSG_401004 As String = "出力は正常終了しました"
    Public Const MSG_401005 As String = "チェック結果出力は異常終了しました"
    Public Const MSG_401006 As String = "チェック結果出力は正常終了しました"

    Public Const MSG_402001 As String = "仕入一覧データを指定してください"
    Public Const MSG_402002 As String = "得意先を指定してください"

    Public Const MSG_403001 As String = "請求締日を指定してください"
    Public Const MSG_403002 As String = "請求鑑データ出力中"
    Public Const MSG_403003 As String = "請求明細データ出力中"


    Public Const MSG_501001 As String = "採用商品リストファイルを指定してください"
    Public Const MSG_501002 As String = "採用商品リスト取込中"
    Public Const MSG_501003 As String = "マスタ更新は正常終了しました"
    Public Const MSG_501004 As String = "マスタ更新は異常終了しました"

    Public Const MSG_502001 As String = "院内コード又は商品コードのどちらかを指定してください"
    Public Const MSG_502002 As String = "院内コード、商品コードの両方は指定できません"

    Public Const MSG_503001 As String = "許可証区分を選択してください"
    Public Const MSG_503002 As String = "許可証番号を入力してください"
    Public Const MSG_503003 As String = "許可証開始日を入力してください"
    Public Const MSG_503004 As String = "許可証終了日を入力してください"
    Public Const MSG_503005 As String = "画像ファイルを指定してください"
    Public Const MSG_503006 As String = "引用元得意先を指定してください"
    Public Const MSG_503007 As String = "許可証情報登録中"
    Public Const MSG_503008 As String = "得意先と引用元得意先が同一です"
    Public Const MSG_503009 As String = "引用元得意先で指定の許可証がありません"
    Public Const MSG_503010 As String = "処理できません"
    Public Const MSG_503011 As String = "既に許可証が登録されています"
    Public Const MSG_503012 As String = "上書きしますが、よろしいですか？"
    Public Const MSG_503013 As String = "許可証情報登録は正常終了しました"
    Public Const MSG_503014 As String = "許可証情報登録は異常終了しました"
    Public Const MSG_503015 As String = "許可証確認処理にて予期しないエラーが発生しました"
    Public Const MSG_503016 As String = "(引用)許可証確認処理にて予期しないエラーが発生しました"
    Public Const MSG_503017 As String = "許可証："

    Public Const MSG_504001 As String = "検索条件を指定してください"
    Public Const MSG_504002 As String = "業種を選択してください"
    Public Const MSG_504003 As String = "許可証を選択してください"
    Public Const MSG_504004 As String = "条件を選択してください"
    Public Const MSG_504005 As String = "対象日を指定してください"
    Public Const MSG_504006 As String = "該当データはありません"
    Public Const MSG_504007 As String = "指定された条件は他の端末で表示中です"
    Public Const MSG_504008 As String = "データを検索し、削除にチェックを入れてください"
    Public Const MSG_504009 As String = "削除にチェックを入れてください"
    Public Const MSG_504010 As String = "削除は正常終了しました"
    Public Const MSG_504011 As String = "削除は異常終了しました"
    Public Const MSG_504012 As String = "出力は正常終了しました"
    Public Const MSG_504013 As String = "出力は異常終了しました"


    Public Const MSG_505001 As String = "医療機関を選択してください"

    '*********************************************************************
    '各メッセージ（アップデート）
    '*********************************************************************
    Public Const MSG_UPD001 As String = "最新版がリリースされていますので更新します"
    Public Const MSG_UPD002 As String = "更新は異常終了しました"
    Public Const MSG_UPD003 As String = "お使いのバージョンが最新版です"

    '*********************************************************************
    '各メッセージ（共通）
    '*********************************************************************
    Public Const MSG_COM001 As String = "表示をクリアしますか？"
    Public Const MSG_COM002 As String = "ログファイルがありません"
    Public Const MSG_COM003 As String = "ツールを終了しますか？"
    Public Const MSG_COM004 As String = "サーバとの接続が遮断されています"
    Public Const MSG_COM005 As String = "既に起動しています"
    Public Const MSG_COM006 As String = "PrintScreenは無効です"
    Public Const MSG_COM007 As String = "事業所を選択してください"
    Public Const MSG_COM008 As String = "入力担当コードを指定してください"
    Public Const MSG_COM009 As String = "入力担当コードの指定が間違っています"
    Public Const MSG_COM010 As String = "選択した機能は実行できません"
    Public Const MSG_COM011 As String = "お使いの端末では許可されていません"
    Public Const MSG_COM012 As String = "サブプログラムを選択してください"
    Public Const MSG_COM013 As String = "需要先を選択してください"
    Public Const MSG_COM014 As String = "SPDシステムコードが取得できませんでした"
    Public Const MSG_COM015 As String = "取込指定したファイルを他アプリケーションで開いています。閉じてください"
    Public Const MSG_COM016 As String = "取込指定したファイルが存在しません"
    Public Const MSG_COM017 As String = "指定したファイルを取り込めませんでした"
    Public Const MSG_COM018 As String = "取込指定したファイルへのアクセス権がありません"
    Public Const MSG_COM019 As String = "本社情報システム課へ連絡してください"


    Public Const MSG_COM896 As String = "前回出力の同名ファイルが他アプリケーションで開いています。閉じてください"
    Public Const MSG_COM897 As String = "前回出力の同名ファイルは存在しません"
    Public Const MSG_COM898 As String = "前回出力の同名ファイルを削除できませんでした"
    Public Const MSG_COM899 As String = "エラーコード："
    Public Const MSG_COM900 As String = "エラーメッセージ："
    Public Const MSG_COM901 As String = "システム管理者までご連絡ください"
    Public Const MSG_COM902 As String = "予期しないエラーが発生しました"
    Public Const MSG_COM903 As String = "SPDツール for Aptage.MD2を再起動してください"
    Public Const MSG_COM904 As String = "指定のメニューは"
    Public Const MSG_COM905 As String = "用ではないため使用できません"
    Public Const MSG_COM906 As String = "開発中の為、指定のメニューは使用できません"
    Public Const MSG_COM907 As String = "稼働中事業所："
    Public Const MSG_COM908 As String = "設定情報を取得できませんでした"
    Public Const MSG_COM909 As String = "設定情報は事業所選択時に取得します"
    Public Const MSG_COM910 As String = "ログイン情報更新に失敗しました"


    '*********************************************************************
    '各システム規定値
    '*********************************************************************
    Public Const DUMMY_INTCODE As Integer = 999999999    '検索空白時ダミー定数
    Public Const DUMMY_LNGCODE As Long = 9999999999      '検索空白時ダミー定数
    Public Const DUMMY_STRCODE As String = "999999999"   '検索空白時ダミー定数
    Public Const DUMMY_REGKEY As String = "NULL"         'ダミーレジストリキー
    Public Const DUMMY_FILENAME As String = "DUMMY.txt"  'ダミーファイル名
    Public Const DUMMY_STRNULL As String = "NULL"        'ダミーファイル名


    Public Const HARKP101ImpFileName As String = "ピッキングデータ連携"
    Public Const HARKP102ImpFileName As String = "ONLINE-ITC"
    Public Const HARKP103ImpFileName As String = "福医協発注データ"
    Public Const HARKP104ImpFileName As String = "Romulus受注データ"
    Public Const HARKP105ImpFileName As String = "PHsmos_卸_受注データ"
    Public Const HARKP106ImpFileName As String = "_HAT_"
    Public Const HARKP301ImpFileName As String = "Aptage連携用ファイル"
    Public Const HARKP4011ImpFileName As String = "WEB在庫移動ログ"
    Public Const HARKP4012ImpFileName As String = "請求明細"
    Public Const HARKP402ImpFileName As String = "仕入一覧"
    Public Const HARKP501ImpFileName As String = "採用商品リスト"


    Public Const CSVExtension As String = "csv"
    Public Const DATExtension As String = "dat"
    Public Const TXTExtension As String = "txt"
    Public Const XLSXExtension As String = "xlsx"
    Public Const TIFExtension As String = "tif"



    '*********************************************************************
    'Get_OSVersion関数戻値
    '*********************************************************************
    Public Const OS_WINDOWS95 As Integer = 0
    Public Const OS_WINDOWS98 As Integer = 1
    Public Const OS_WINDOWSME As Integer = 2
    Public Const OS_WINDOWSNT3 As Integer = 3
    Public Const OS_WINDOWSNT31 As Integer = 4
    Public Const OS_WINDOWSNT35 As Integer = 5
    Public Const OS_WINDOWSNT351 As Integer = 6
    Public Const OS_WINDOWSNT4 As Integer = 7
    Public Const OS_WINDOWS2000 As Integer = 8
    Public Const OS_WINDOWSXP As Integer = 9
    Public Const OS_WINDOWSSERVER2003 As Integer = 10
    Public Const OS_WINDOWSVISTA As Integer = 11
    Public Const OS_WINDOWS7 As Integer = 12
    Public Const OS_WINDOWS32s As Integer = 13
    Public Const OS_WINDOWSCE As Integer = 14
    Public Const OS_UNIX As Integer = 15
    Public Const OS_XBOX As Integer = 16
    Public Const OS_MACINTOSH As Integer = 17
    Public Const OS_UNKNOWN As Integer = 18
    Public Const OS_WINDOWS8 As Integer = 19
    Public Const OS_WINDOWS81 As Integer = 20
    Public Const OS_WINDOWS10 As Integer = 21

    '*********************************************************************
    'Entry_Check関数用定数(Check_SIZE)
    '*********************************************************************
    Public Const CHECK_SIZE_WIDE As Integer = 1           '全角
    Public Const CHECK_SIZE_NARROW As Integer = 2         '半角
    Public Const CHECK_SIZE_BOTH As Integer = 0           '共用

    '*********************************************************************
    'Entry_Check関数用定数(Check_STYLE)
    '*********************************************************************
    Public Const CHECK_STYLE_NUMBER As Integer = 0        '数字のみ
    Public Const CHECK_STYLE_ALPH As Integer = 1          '英数字のみ
    Public Const CHECK_STYLE_ELSE As Integer = 2          'その他

    '*********************************************************************
    'Entry_Check関数用定数(Check_LEN)
    '*********************************************************************
    Public Const CHECK_LEN_MAKERCODE As Integer = 10            'メーカコード
    Public Const CHECK_LEN_ITEMMAKERCODE As Integer = 20        'メーカ品番
    Public Const CHECK_LEN_HPITEMOCDE As Integer = 30           '院内コード
 
End Module
