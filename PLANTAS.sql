CREATE DATABASE Plantas;
GO

USE Plantas;
GO

CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY,
    NombreCategoria NVARCHAR(100)
);

CREATE TABLE Plantas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(200),
    CategoriaId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

-- Insertar categorías de prueba
INSERT INTO Categorias (NombreCategoria)
VALUES ('Decorativa'), ('Medicinal'), ('Aromática');

SELECT * FROM Plantas

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Plantas'

SELECT * FROM Plantas

SELECT * FROM Plantas;

EXEC sp_rename 'Plantas.Nombre', 'NombrePlanta', 'COLUMN';
