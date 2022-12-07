CREATE TABLE [dbo].[EventoDia]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[IdEvento] INT NOT NULL,
    [Data] DATE NOT NULL, 
    [HoraInicio] DATETIME NULL, 
    [HoraFim] DATETIME NULL, 
    [Observacao] VARCHAR(500) NULL, 
    CONSTRAINT [FK_EventoDia_Evento] FOREIGN KEY ([IdEvento]) REFERENCES [Evento]([Id])
)
