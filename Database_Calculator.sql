CREATE DATABASE IF NOT EXISTS Calculadora; 
USE Calculadora;

select * from userCalc;
select * from historico;

CREATE TABLE userCalc (
  cpf VARCHAR (11) NOT NULL,
  senha VARCHAR(45) NOT NULL,
  tipoUser VARCHAR(45) NOT NULL,
  email VARCHAR(100) NOT NULL,
  nome VARCHAR(100)NOT NULL,
  PRIMARY KEY (cpf));

CREATE TABLE historico(
  id INT (100) not null auto_increment,  
  cpfUser VARCHAR (11) NOT NULL,
  historico VARCHAR(255) NOT NULL,
  primary key (id)
);

insert into userCalc values ("358.242.058-40","1234", "Admin", "f@gmail.com", "Felps");
insert into userCalc values ("377.332.850-89","12", "usuario", "Jane@gmail.com", "Jane");

