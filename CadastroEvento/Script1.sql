select * from Usuario


select * from Evento

insert into Evento (titulo, Descricao, DataInicio, DataFim, Local, CEP, Endereco, Numero, Bairro, Cidade, Estado)
values ('Evento de Teste', 'Descrição do Evento de Teste', GETDATE(), GETDATE(), 'Transamerica Expo Center', '04757-020', 'Av. Dr. Mario Vilas Bôas Rodrigues', '387', 'Santo Amaro', 'São Paulo', 'SP')

select * from EventoDia

insert into EventoDia (IdEvento, Data, HoraInicio, HoraFim) values (1, '2016-03-15', '08:00', '21:00')
insert into EventoDia (IdEvento, Data, HoraInicio, HoraFim) values (1, '2016-03-16', '08:00', '21:00')
insert into EventoDia (IdEvento, Data, HoraInicio, HoraFim) values (1, '2016-03-17', '08:00', '21:00')
insert into EventoDia (IdEvento, Data, HoraInicio, HoraFim) values (1, '2016-03-18', '08:00', '21:00')

select * from TipoPessoa

delete TipoPessoa where id not in (1,2)

insert into TipoPessoa values('Visitante', 1);
insert into TipoPessoa values('Expositor', 2)


select len('15449187000182')

insert into Usuario values ('Maycon Zamora', 'mzamora', '123456', 'mzamora@madrisolution.com.br',  1, getdate())

select * from Usuario

insert into Usuario(Nome, Login, Senha, Email, Ativo, DataCadastro) values('Diego Passos', 'dipsilva', '123456', 'diego_passos2@hotmail.com', 1, getdate())


--alter table Pessoa add Email Varchar(100) NULL

select * from Foto


ALTER TABLE PessoaEventoDia
ADD PRIMARY KEY (IdPessoa, IdEventoDia)