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
/*
	DROP	SNAPSHOT	得意先商品売上単価マスタV;
	CREATE	SNAPSHOT	得意先商品売上単価マスタV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.得意先商品売上単価マスタ@APTAGE_ITI;
*/
	DROP	SNAPSHOT	需要先商品売上単価マスタV;
	CREATE	SNAPSHOT	需要先商品売上単価マスタV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.需要先商品売上単価マスタ@APTAGE_ITI;

