insert into TBCartoes
		(
		[nome],
		[email], 
		[telefone], 
		[empresa], 
		[cargo]
		)

values
		(
		'Aaa',
		'matheus@gmail.com',
		'291309',
		'NDD',
		'estagiario'
		)

select SCOPE_IDENTITY();

update TBCartoes 
		set
			[nome] = 'Teste',
			[email] = 'teste@gmail.com',
			[telefone] = '132311231',
			[empresa] = 'Samsung',
			[cargo] = 'funcionario'

			where
			[id] = 19


delete from TBCartoes
		where
			[id] = 8


select 
		[id],
		[nome],
		[email], 
		[telefone], 
		[empresa], 
		[cargo]
	from 
		TBCartoes
	order by
		[cargo]
	