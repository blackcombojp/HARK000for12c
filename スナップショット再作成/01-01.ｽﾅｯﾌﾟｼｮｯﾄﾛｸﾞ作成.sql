--#######################################################
--#
--#	��	�X�i�b�v�V���b�g���O�쐬	��
--#
--#	create	snapshot	log	on	SIK21.���i�}�X�^_���m
--#	pctfree		50
--#	pctused		30
--#	tablespace	APTG_HDATA
--#	storage		(	initial		800K
--#				next		200K
--#				minextents	1
--#				maxextents	122
--#				pctincrease	0	);
--#
--#######################################################


--#######################################################


	DROP	SNAPSHOT	LOG	ON	APTAGEV2.���Ӑ敔���}�X�^;
	DROP	SNAPSHOT	LOG	ON	APTAGEV2.���Ӑ挻�݌ɏ��;
	DROP	SNAPSHOT	LOG	ON	APTAGEV2.����ʃ}�X�^;
	DROP	SNAPSHOT	LOG	ON	APTAGEV2.���v�i�����;



--#######################################################


	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.���Ӑ敔���}�X�^;
	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.���Ӑ挻�݌ɏ��;
	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.����ʃ}�X�^;
	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.���v�i�����;

