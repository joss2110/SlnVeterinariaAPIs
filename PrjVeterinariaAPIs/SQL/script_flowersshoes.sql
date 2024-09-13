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

CREATE OR ALTER PROCEDURE sp_LoginUser
    @nroDocumento VARCHAR(15),
    @password VARCHAR(100),
    @idtipodoc INT
AS
BEGIN
    SELECT *
    FROM tb_users
    WHERE nroDocumento = @nroDocumento
      AND password = @password
      AND idtipodoc = @idtipodoc;
END;
GO

CREATE PROCEDURE sp_ListarTipoDoc
AS
BEGIN
    SELECT *
    FROM tb_tipodoc;
END;
GO

INSERT INTO tb_tipodoc (description, ndigits, tdigits)
VALUES
('DNI', 8, 'Numerico'),
('CEX', 10, 'Alfanumerico'),
('PAS', 12, 'Numerico');

select * from tb_tipodoc


INSERT INTO tb_users (nombres, idtipodoc, nroDocumento, password)
VALUES
('Juan Pérez', 1, '12345678', 'Password123'),  -- DNI
('Ana Gómez', 2, 'A123456789', 'Password456'), -- CEX
('Luis Fernández', 3, '123456789012', 'Password789'); -- PAS


select * from tb_users



