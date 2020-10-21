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
	DROP	SNAPSHOT	消費税率マスタV;
	CREATE	SNAPSHOT	消費税率マスタV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.消費税率マスタ@APTAGE_ITI;

