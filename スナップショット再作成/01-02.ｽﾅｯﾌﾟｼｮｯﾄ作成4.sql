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
	DROP	SNAPSHOT	����ŗ��}�X�^V;
	CREATE	SNAPSHOT	����ŗ��}�X�^V
		REFRESH	FORCE
		START	WITH	SYSDATE
		NEXT	SYSDATE + 1
		AS	SELECT	*	FROM	APTAGEV2.����ŗ��}�X�^@APTAGE_ITI;

