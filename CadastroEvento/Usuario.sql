CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Nome] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(50) NOT NULL, 
    [Senha] VARCHAR(16) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NULL, 
    CONSTRAINT [AK_Usuario_Login] UNIQUE ([Login]) 
)
