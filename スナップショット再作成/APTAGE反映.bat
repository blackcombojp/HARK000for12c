echo off
echo ■■■■■■■■■■■■■■■■■■■■■■■
echo ＢＯにスクリプトを反映します
echo よろしいですか？(OK:Enter  NG:Ctrl+C)
echo ■■■■■■■■■■■■■■■■■■■■■■■
pause

echo .
echo ▽反映処理を開始しました。
echo .

REM ★★BO_ITI(ITI本番)
START /W SQLPLUS.EXE APTAGEV2/APTG@ITI  @01-01.ｽﾅｯﾌﾟｼｮｯﾄﾛｸﾞ作成5.sql



echo .
echo ▽反映処理が終了しました。
echo .
pause
