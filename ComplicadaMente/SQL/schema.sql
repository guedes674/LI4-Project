-- criar schema
CREATE DATABASE ComplicadaMenteDB;

-- criar tabelas
CREATE TABLE Utilizador (
    ID INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(75) NOT NULL,
    Telefone VARCHAR(15) NOT NULL,
    Morada VARCHAR(150) NOT NULL,
    Password VARCHAR(45) NOT NULL,
);

CREATE TABLE Funcionario (
    ID INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Cargo VARCHAR(75) NOT NULL,
    Email VARCHAR(75) NOT NULL,
    Password VARCHAR(45) NOT NULL,
    Salario DECIMAL(9, 2) NOT NULL,
);

CREATE TABLE Encomenda (
    ID INT PRIMARY KEY,
    Estado VARCHAR(20) NOT NULL,
    Preco_Total DECIMAL(10, 2) NOT NULL,
    ID_Utilizador INT NOT NULL,
    ID_Funcionario INT NOT NULL,
    Data_Encomenda DATE NOT NULL,
    FOREIGN KEY (ID_Utilizador) REFERENCES Utilizador(ID),
);

CREATE TABLE Peca (
    ID INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Preco DECIMAL(9, 2) NOT NULL,
    ID_Quebra_Cabeca INT NOT NULL,
    Descricao VARCHAR(130) NOT NULL,
    Imagem BLOB NOT NULL,
    FOREIGN KEY (ID_Quebra_Cabeca) REFERENCES Quebra_Cabeca(ID)
);

CREATE TABLE Quebra_Cabeca (
    ID INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Preco DECIMAL(9, 2) NOT NULL,
    Descricao VARCHAR(130) NOT NULL,
    Imagem BLOB NOT NULL
);

CREATE TABLE Quebra_Cabeca_Encomenda (
    ID_Encomenda INT NOT NULL,
    ID_Quebra_Cabeca INT NOT NULL,
    Quantidade INT NOT NULL,
    FOREIGN KEY (ID_Encomenda) REFERENCES Encomenda(ID),
    FOREIGN KEY (ID_Quebra_Cabeca) REFERENCES Quebra_Cabeca(ID)
);

CREATE TABLE Peca_Encomenda (
    ID_Peca INT NOT NULL,
    ID_Encomenda INT NOT NULL,
    Quantidade INT NOT NULL,
    FOREIGN KEY (ID_Peca) REFERENCES Peca(ID),
    FOREIGN KEY (ID_Encomenda) REFERENCES Encomenda(ID),
);