--#######################################################
--#
--#	◇	スナップショットログ作成	◇
--#
--#	create	snapshot	log	on	SIK21.商品マスタ_高知
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


	DROP	SNAPSHOT	LOG	ON	APTAGEV2.得意先商品売上単価マスタ;
	DROP	SNAPSHOT	LOG	ON	APTAGEV2.需要先商品売上単価マスタ;

--#######################################################


	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.得意先商品売上単価マスタ;
	CREATE	SNAPSHOT	LOG	ON	APTAGEV2.需要先商品売上単価マスタ;

