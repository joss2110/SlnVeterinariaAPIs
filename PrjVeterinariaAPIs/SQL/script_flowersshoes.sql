USE master
GO

DROP DATABASE IF EXISTS Veterinaria
GO

CREATE DATABASE Veterinaria
GO

USE Veterinaria
GO


CREATE TABLE tb_tipodoc
(
idtipodoc INT PRIMARY KEY identity(1,1),
description VARCHAR(100) NOT NULL,
ndigits int NOT NULL,
tdigits VARCHAR(100) NOT NULL
);
GO

CREATE TABLE tb_users
(
iduser INT PRIMARY KEY identity(1,1),
nombres VARCHAR(100) NOT NULL,
idtipodoc INT NOT NULL FOREIGN KEY REFERENCES tb_tipodoc(idtipodoc),
nroDocumento VARCHAR(15) NOT NULL,
password VARCHAR(100) NOT NULL
);
GO



