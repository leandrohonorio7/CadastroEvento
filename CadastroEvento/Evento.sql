CREATE TABLE [dbo].[Evento]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[Titulo] VARCHAR(200) NOT NULL,
    [Descricao] VARCHAR(500) NULL, 
    [DataInicio] DATE NOT NULL, 
    [DataFim] DATE NOT NULL, 
    [Local] VARCHAR(50) NOT NULL, 
    [CEP] VARCHAR(9) NULL, 
    [Endereco] VARCHAR(100) NULL, 
    [Numero] VARCHAR(20) NULL, 
    [Bairro] VARCHAR(100) NULL, 
    [Cidade] VARCHAR(100) NULL, 
    [Estado] VARCHAR(2) NULL
)
