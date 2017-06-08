use teste

alter table contato
alter column pessoa_id int not null unique
add endereco_contato_id int
add nome_contato varchar(20)

-- contato tipo
-- 0 familia
-- 1 trabalho
-- 2 escola
-- 3 amigos
-- 4 outros
 
create table Contato(
contato_id int not null,
pessoa_id int not null,
celular varchar(20),
telefoneResidencial varchar(20),
telefoneComercial varchar(20),
email varchar(50),
IM varchar(50),
sitioweb varchar(50), 
tipo int not null,
primary key(contato_id),
)
--Celular, Telefone Residencial ou Comercial, Email, IM, Site
create table Endereco(
endereco_id int not null,
pessoa_id int not null,
logradouro varchar(50) not null,
numero int ,
complemento varchar(30),
tipo int not null,
bairro varchar(30) ,
cidade varchar(30) ,
estado varchar(30) ,
primary key (endereco_id),
)

create table Pessoa(
pessoa_id int not null,
nome varchar(50) not null,
primary key (pessoa_id),

)

ALTER TABLE Pessoa alter COLUMN pessoa_id IDENTITY(1,1)
ALTER TABLE Pessoa ADD pessoa_id INT IDENTITY(1,1) primary key

insert into Pessoa(nome) values('carl')
insert into Contato(pessoa_id, telefoneComercial, email,tipo, nome_contato)
 values(2,'5097 5617', 'alan@email.com', 2, 'Alan')

select p.pessoa_id, p.nome, c.nome_contato from Contato c left join
Pessoa p on p.pessoa_id = c.pessoa_id
--left join Endereco e on e.endereco_id = c.endereco_contato_id 
where c.tipo = 0

update Contato set endereco_contato_id = 6 where nome_contato = 'x'

select p.nome from Contato c
inner join Pessoa p on c.contato_id = p.contato_id_pessoa
where c.pessoa_id = 1

select * from Contato
--------------------------
select * from Pessoa
-------------------------


select p.nome, e.logradouro, e.bairro from Pessoa p
inner join Endereco e on e.pessoa_id = p.pessoa_id
where p.nome = 'samuel'

select * from Endereco

alter table endereco
--drop column numero
add numero varchar(20)

insert into Endereco(pessoa_id, logradouro, tipo, bairro) 
values(5, 'av. silas mugunba', 0, 'passare')

