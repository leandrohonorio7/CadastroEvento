CREATE TABLE [dbo].[Pessoa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Nome] VARCHAR(100) NOT NULL, 
	[IdTipoPessoa] INT NOT NULL,
    [Empresa] VARCHAR(100) NULL, 
    [Cargo] VARCHAR(50) NULL, 
    [CPF] VARCHAR(11) NULL, 
    [Telefone] VARCHAR(20) NULL, 
    [Celular] VARCHAR(20) NULL, 
	[Email] VARCHAR(100) NULL,
    [CNPJ] VARCHAR(14) NULL, 
    [CEP] VARCHAR(9) NULL, 
    [Endereco] VARCHAR(150) NULL, 
    [Numero] VARCHAR(10) NULL, 
    [Complemento] VARCHAR(100) NULL, 
    [Bairro] VARCHAR(50) NULL, 
    [Cidade] VARCHAR(50) NULL, 
    [Estado] VARCHAR(2) NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    CONSTRAINT [FK_Pessoa_TipoPessoa] FOREIGN KEY ([IdTipoPessoa]) REFERENCES [TipoPessoa]([Id])
)

GO
