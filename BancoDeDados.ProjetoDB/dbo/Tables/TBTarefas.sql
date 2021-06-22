CREATE TABLE [dbo].[TBTarefas] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]        VARCHAR (200) NULL,
    [DataCriacao]   DATETIME      NULL,
    [DataConclusao] DATETIME      NULL,
    [Percentual]    VARCHAR (200) NULL,
    [Prioridade]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

