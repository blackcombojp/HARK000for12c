--#######################################################
--#
--#	��	�X�i�b�v�V���b�g�쐬	��
--#
--#######################################################
--(������7:00���� �ȍ~���� 7:00)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			TRUNC(SYSDATE + 1) + 7/24
--(������7:00���� �ȍ~�P���ԊԊu)
--		START	WITH	TRUNC(SYSDATE + 1) + 7/24
--		NEXT			SYSDATE + 1/24
--(������P���ԊԊu)
--		START	WITH	SYSDATE + 1/24
--		NEXT			SYSDATE + 1/24



--	=================================================
-- 		�� ���Ӑ�ʏ��i�P���ݒ�V	(5���Ԋu)
--	=================================================
	DROP	SNAPSHOT	���Ӑ敔���}�X�^V;
	CREATE	SNAPSHOT	���Ӑ敔���}�X�^V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.���Ӑ敔���}�X�^@APTAGE_ITI;

	DROP	SNAPSHOT	���Ӑ挻�݌ɏ��V;
	CREATE	SNAPSHOT	���Ӑ挻�݌ɏ��V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.���Ӑ挻�݌ɏ��@APTAGE_ITI;

	DROP	SNAPSHOT	����ʃ}�X�^V;
	CREATE	SNAPSHOT	����ʃ}�X�^V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.����ʃ}�X�^@APTAGE_ITI;

	DROP	SNAPSHOT	���v�i�����V;
	CREATE	SNAPSHOT	���v�i�����V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE
		AS	SELECT	*	FROM	APTAGEV2.���v�i�����@APTAGE_ITI;

