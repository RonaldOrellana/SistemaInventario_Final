-- =============================================
-- Migrar tabla Clientes a nueva estructura
-- Ejecutar en: Proyecto_FinalG2
-- =============================================

-- 1. Eliminar FK de Ventas → Clientes (vieja)
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Ventas_Clientes')
    ALTER TABLE dbo.Ventas DROP CONSTRAINT FK_Ventas_Clientes;
GO

-- 2. Eliminar tabla Clientes anterior
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Clientes') AND type = N'U')
    DROP TABLE dbo.Clientes;
GO

-- 3. Crear tabla Clientes con nueva estructura
CREATE TABLE dbo.Clientes
(
    CodigoCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres       NVARCHAR(100) NOT NULL,
    Apellidos     NVARCHAR(100) NOT NULL,
    Dui           NVARCHAR(20)  NOT NULL,
    Sexo          NVARCHAR(20)  NOT NULL,
    Direccion     NVARCHAR(200) NULL,
    Telefono      NVARCHAR(30)  NULL
);
GO

-- 4. Recrear FK de Ventas → Clientes (nueva)
ALTER TABLE dbo.Ventas
    ADD CONSTRAINT FK_Ventas_Clientes
    FOREIGN KEY (ClienteId) REFERENCES dbo.Clientes(CodigoCliente);
GO

-- 5. Verificar que Ventas y VentaDetalles existan (ya creadas en create_tables.sql)
-- Si no existen, ejecutar create_tables.sql primero.

PRINT 'Tabla Clientes creada/migrada correctamente.';
GO