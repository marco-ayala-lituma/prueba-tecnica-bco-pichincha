-- Eliminar la tabla Cliente si existe
IF OBJECT_ID('dbo.Cliente', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Cliente;
END

-- Eliminar la tabla Persona si existe
IF OBJECT_ID('dbo.Persona', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Persona;
END

-- Crear tabla Persona
CREATE TABLE Persona (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Clave primaria autoincremental
    Nombre NVARCHAR(100) NOT NULL,
    Genero NVARCHAR(10) NOT NULL,
    Edad INT CHECK (Edad >= 0 AND Edad <= 150),
    Identificacion NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(15)
);

-- Crear tabla Cliente
CREATE TABLE Cliente (
    ClienteId INT PRIMARY KEY, -- Clave primaria autoincremental
    Contrasena NVARCHAR(100) NOT NULL,
    Estado BIT NOT NULL,
    -- Clave foránea que relaciona Cliente con Persona
    CONSTRAINT FK_Cliente_Persona FOREIGN KEY (ClienteId) REFERENCES Persona(Id)
);
