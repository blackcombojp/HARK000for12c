--#######################################################
--#
--#	◇	スナップショット作成	◇
--#
--#######################################################
--(翌日朝7:00から 以降毎朝 7:00)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			TRUNC(SYSDATE + 1) + 7/24
--(翌日朝7:00から 以降１時間間隔)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			SYSDATE + 1/24
--(今から１時間間隔)
--		START	WITH	SYSDATE + 1/24
--		NEXT			SYSDATE + 1/24



--	=================================================
-- 		◆ 得意先別商品単価設定V	(5分間隔)
--	=================================================
	DROP	SNAPSHOT	得意先部署マスタV;
	CREATE	SNAPSHOT	得意先部署マスタV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.得意先部署マスタ@APTAGE_ITI;

	DROP	SNAPSHOT	得意先現在庫情報V;
	CREATE	SNAPSHOT	得意先現在庫情報V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.得意先現在庫情報@APTAGE_ITI;

	DROP	SNAPSHOT	部門個別マスタV;
	CREATE	SNAPSHOT	部門個別マスタV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.部門個別マスタ@APTAGE_ITI;

	DROP	SNAPSHOT	合計品揃情報V;
	CREATE	SNAPSHOT	合計品揃情報V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.合計品揃情報@APTAGE_ITI;

