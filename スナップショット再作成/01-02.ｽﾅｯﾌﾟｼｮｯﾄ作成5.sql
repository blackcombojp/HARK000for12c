--#######################################################
--#
--#		XibvVbgì¬	
--#
--#######################################################
--(ú©7:00©ç È~© 7:00)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			TRUNC(SYSDATE + 1) + 7/24
--(ú©7:00©ç È~PÔÔu)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			SYSDATE + 1/24
--(¡©çPÔÔu)
--		START	WITH	SYSDATE + 1/24
--		NEXT			SYSDATE + 1/24



--	=================================================
-- 		 ¾ÓæÊ¤iP¿ÝèV	(5ªÔu)
--	=================================================
/*
	DROP	SNAPSHOT	¾Óæ¤iãP¿}X^V;
	CREATE	SNAPSHOT	¾Óæ¤iãP¿}X^V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.¾Óæ¤iãP¿}X^@APTAGE_ITI;
*/
	DROP	SNAPSHOT	ùvæ¤iãP¿}X^V;
	CREATE	SNAPSHOT	ùvæ¤iãP¿}X^V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.ùvæ¤iãP¿}X^@APTAGE_ITI;

