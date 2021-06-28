CREATE TABLE [dbo].[TBCompromissos] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Assunto]     VARCHAR (100) NULL,
    [Local]       VARCHAR (100) NULL,
    [DataInicio]  DATETIME      NULL,
    [LinkReuniao] VARCHAR (200) NULL,
    [IDContato]   INT           NULL,
    [DataFim]     DATETIME      NULL,
    CONSTRAINT [PK_TBCompromissos] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TBCompromissos_TBCartoes] FOREIGN KEY ([IDContato]) REFERENCES [dbo].[TBCartoes] ([Id]) ON DELETE CASCADE
);





