-- Ejecutar en la base de datos apuntada por Conexion.cs (Initial Catalog=Proyecto_FinalG2)
-- Crea las tablas necesarias: Categorias, Productos, Clientes, Ventas, VentaDetalles, Usuarios

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categorias]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[Categorias](
        [Codigo] INT IDENTITY(1,1) PRIMARY KEY,
        [Descripcion] NVARCHAR(200) NOT NULL,
        [Estado] BIT NOT NULL DEFAULT(1)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[Productos](
        [Codigo] INT IDENTITY(1,1) PRIMARY KEY,
        [Nombre] NVARCHAR(200) NOT NULL,
        [Precio] DECIMAL(18,2) NOT NULL DEFAULT(0),
        [Stock] INT NOT NULL DEFAULT(0),
        [CategoriaCodigo] INT NULL,
        CONSTRAINT FK_Productos_Categorias FOREIGN KEY([CategoriaCodigo]) REFERENCES [dbo].[Categorias]([Codigo])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[Clientes](
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [Nombre] NVARCHAR(200) NOT NULL,
        [Telefono] NVARCHAR(50) NULL,
        [Email] NVARCHAR(200) NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ventas]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[Ventas](
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [Fecha] DATETIME NOT NULL DEFAULT(GETDATE()),
        [ClienteId] INT NULL,
        [Total] DECIMAL(18,2) NOT NULL DEFAULT(0),
        CONSTRAINT FK_Ventas_Clientes FOREIGN KEY([ClienteId]) REFERENCES [dbo].[Clientes]([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentaDetalles]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[VentaDetalles](
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [VentaId] INT NOT NULL,
        [ProductoCodigo] INT NOT NULL,
        [Cantidad] INT NOT NULL,
        [Precio] DECIMAL(18,2) NOT NULL,
        [Subtotal] DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_VentaDetalles_Ventas FOREIGN KEY([VentaId]) REFERENCES [dbo].[Ventas]([Id]),
        CONSTRAINT FK_VentaDetalles_Productos FOREIGN KEY([ProductoCodigo]) REFERENCES [dbo].[Productos]([Codigo])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[Usuarios](
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [NombreUsuario] NVARCHAR(100) NOT NULL,
        [PasswordHash] NVARCHAR(MAX) NOT NULL,
        [Nombre] NVARCHAR(100) NULL,
        [Rol] NVARCHAR(50) NULL
    );
END
GO