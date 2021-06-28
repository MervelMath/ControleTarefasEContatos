
insert into TBCompromissos
		(
		[ASSUNTO], 
		[LOCAL], 
		[DATAINICIO], 
		[LINKREUNIAO],
		[IDCONTATO],
		[DATAFIM]
		)

values
		(
		'Negocios',
		'Bangu',
		'2021/07/08 14:20',
		'dadsdd.com',
		null,
		'2021/06/08 15:00'
		)


update TBCOMPROMISSOS 
		set
			[ASSUNTO] = 'Sei la',
			[LOCAL] = 'dasdas da Posse',
			[DATAINICIO] = '2021/06/20',
			[LINKREUNIAO] = '',
			[IDCONTATO] = 17,
			[DATAFIM] = '2021/06/21'
		where
			[ID] = 8


SELECT 
		CP.[ID],
		CP.[ASSUNTO], 
		CP.[LOCAL], 
		CP.[DATAINICIO], 
		CP.[LINKREUNIAO],
		CR.[ID],
		CR.[NOME],
		CP.[DATAFIM]
	FROM
		TBCOMPROMISSOS CP LEFT JOIN
		TBCARTOES CR
	ON
		CP.IDCONTATO = CR.ID
	WHERE
		CP.ID = 19

delete from TBCOMPROMISSOS

DBCC CHECKIDENT('TBCOMPROMISSOS', RESEED, 0)