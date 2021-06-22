

insert into TBTarefas
		(
		[Titulo], 
		[DataCriacao], 
		[DataConclusao], 
		[Percentual],
		[Prioridade]
		)

values
		(
		'Carro',
		'2021/06/05',
		'2021/06/08',
		'100%',
		'2'
		)

select SCOPE_IDENTITY();

update TBTarefas 
		set
			[Titulo] = 'Sair pra Rua',
			[DataCriacao] = '2021/06/10',
			[DataConclusao] = '2021/06/20',
			[Percentual] = '40%',
			[Prioridade] = '0'

			where
			[id] = 19


delete from TBTarefas
		where
			[id] = 8


select 
		[id],
		[Titulo],
		[DataCriacao], 
		[DataConclusao], 
		[Percentual], 
		[Prioridade] 
	from 
		TBTarefas
	order by
		[Prioridade] DESC