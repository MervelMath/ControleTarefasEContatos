CREATE TABLE [dbo].[TBCartoes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR (200) NULL,
    [email]    VARCHAR (200) NULL,
    [telefone] INT           NULL,
    [empresa]  VARCHAR (200) NULL,
    [cargo]    VARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

