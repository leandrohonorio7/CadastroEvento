CREATE TABLE [dbo].[ControleAcesso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdPessoa] INT NOT NULL, 
    [DataAcesso] DATETIME NOT NULL, 
    [TipoAcesso] VARCHAR NOT NULL, 
    CONSTRAINT [FK_ControleAcesso_Pessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoa]([Id])
)
