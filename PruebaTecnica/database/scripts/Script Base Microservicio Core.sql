-- Eliminar la tabla Movimiento si existe
IF OBJECT_ID('dbo.Movimiento', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Movimiento;
END

-- Eliminar la tabla Cuenta si existe
IF OBJECT_ID('dbo.Cuenta', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Cuenta;
END

-- Crear tabla Cuenta
CREATE TABLE Cuenta (
    NumeroCuenta CHAR(6) PRIMARY KEY, -- Clave única de 6 dígitos
    ClienteId INT NOT NULL, -- Id del cliente, debe ser único
    TipoCuenta NVARCHAR(50) NOT NULL, -- Ej: "Ahorros", "Corriente", etc.
    SaldoInicial DECIMAL(18, 2) CHECK (SaldoInicial >= 0) DEFAULT (0), -- Saldo inicial de la cuenta
    Estado BIT NOT NULL  -- Estado de la cuenta: activo (true) o inactivo (false)
);


-- Crear tabla Movimiento
CREATE TABLE Movimiento (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Clave única para el movimiento
    Fecha DATETIME NOT NULL, -- Fecha del movimiento
    TipoMovimiento NVARCHAR(50) NOT NULL, -- Ej: "Depósito", "Retiro".
    Valor DECIMAL(18, 2) CHECK (Valor >= 0), -- Valor del movimiento
    Saldo DECIMAL(18, 2) CHECK (Saldo >= 0), -- Saldo después del movimiento
    NumeroCuenta CHAR(6) NOT NULL, -- Relación con la tabla Cuenta
    CONSTRAINT FK_Movimiento_Cuenta FOREIGN KEY (NumeroCuenta) REFERENCES Cuenta(NumeroCuenta)
);
