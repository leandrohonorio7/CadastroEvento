CREATE TABLE [dbo].[Foto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdPessoa] INT NOT NULL, 
    [Nome] VARCHAR(50) NULL, 
    [Tamanho] BIGINT NULL, 
    [Tipo] VARCHAR(50) NOT NULL, 
    [FileContent] VARBINARY(MAX) NOT NULL, 
    [Ativo] BIT NULL, 
    [DataCriacao] DATETIME NULL, 
    [DataAlteracao] DATETIME NULL, 
    CONSTRAINT [FK_Foto_Pessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoa]([Id]) 
)
