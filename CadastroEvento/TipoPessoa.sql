CREATE TABLE [dbo].[TipoPessoa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] VARCHAR(100) NULL, 
    [Ativo] BIT NULL
)
