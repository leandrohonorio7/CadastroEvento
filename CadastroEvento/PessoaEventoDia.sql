CREATE TABLE [dbo].[PessoaEventoDia]
(
	[IdPessoa] INT NOT NULL , 
    [IdEventoDia] INT NOT NULL, 
    CONSTRAINT [FK_PessoaEventoDia_Pessoa] FOREIGN KEY ([IdPessoa]) REFERENCES [Pessoa]([Id]), 
    CONSTRAINT [FK_PessoaEventoDia_EventoDia] FOREIGN KEY ([IdEventoDia]) REFERENCES [EventoDia]([Id])
)
