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
	DROP	SNAPSHOT	iµîñV;
	CREATE	SNAPSHOT	iµîñV
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.iµîñ@APTAGE_ITI;

