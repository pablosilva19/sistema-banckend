--1 - CRIAR O BANCO
CREATE DATABASE programacao_do_zero;


--USAR O BANCO
USE programacao_do_zero

-- MUDAR OS NOME NA TABELA
ALTER TABLE  usuario 
RENAME COLUMN sobrenomme TO sobrenome

--CRIAR TABELA DO USUARIO
CREATE TABLE usuario(
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenomme VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	gereno VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

--CRIAR TABELA ENDERECO
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(250) NOT NULL,
	numero VARCHAR(30) NOT NULL,
	bairro VARCHAR(150) NOT NULL,
	cidade VARCHAR(250)  NOT NULL,
	complemento	VARCHAR(150) NULL,
	cep VARCHAR(9) NOT NULL,
	estado VARCHAR(2) NOT NULL,
	PRIMARY KEY (id)
);

-- CRIAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- ADICIONAR CHAVE ESTRANGEIRA
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--INSEIR USUARIO
INSERT INTO usuario 
(nome, sobrenome, telefone, email, gereno, senha) 
VALUE
('Pablo', 'Silva', '(19) 982250781', 'pablosilva@gmail.com', 'Masculino', '123');

--SELECINAR O USUARIO
SELECT * FROM usuario;

--SELECIONAR UM USUARIO ESPECIFICO 
SELECT * FROM usuario WHERE telefone = '(19) 982250781';

--ALTERAR O USUARIO

UPDATE usuario SET email = 'pablohenriquedias464@gmail' WHERE id = 2;

--EXCLUIR USUARIO
DELETE FROM usuario WHERE id = 2;