-- =========================
-- TABLA CATEGORIAS
-- =========================
IF OBJECT_ID('dbo.Categorias', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categorias (
        Codigo INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion NVARCHAR(200) NOT NULL,
        Estado BIT NOT NULL DEFAULT(1)
    );
END
GO

-- =========================
-- TABLA PRODUCTOS
-- =========================
IF OBJECT_ID('dbo.Productos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        Codigo INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(200) NOT NULL,
        Precio DECIMAL(18,2) NOT NULL DEFAULT(0),
        Stock INT NOT NULL DEFAULT(0),
        CategoriaCodigo INT NULL,
        CONSTRAINT FK_Productos_Categorias 
            FOREIGN KEY (CategoriaCodigo) 
            REFERENCES dbo.Categorias(Codigo)
    );
END
GO

-- =========================
-- PROCEDIMIENTOS CATEGORIAS
-- =========================
IF OBJECT_ID('dbo.usp_Categorias_GetAll','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Categorias_GetAll;
GO

CREATE PROCEDURE dbo.usp_Categorias_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Codigo, Descripcion, Estado 
    FROM dbo.Categorias 
    WHERE Estado = 1;
END
GO

-- =========================
-- PRODUCTOS: LISTAR
-- =========================
IF OBJECT_ID('dbo.usp_Productos_GetAll','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Productos_GetAll;
GO

CREATE PROCEDURE dbo.usp_Productos_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Codigo, 
        p.Nombre, 
        p.Precio, 
        p.Stock, 
        p.CategoriaCodigo, 
        c.Descripcion AS Categoria
    FROM dbo.Productos p
    LEFT JOIN dbo.Categorias c 
        ON p.CategoriaCodigo = c.Codigo;
END
GO

-- =========================
-- BUSCAR PRODUCTOS
-- =========================
IF OBJECT_ID('dbo.usp_Productos_Search','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Productos_Search;
GO

CREATE PROCEDURE dbo.usp_Productos_Search
    @f NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Codigo, 
        p.Nombre, 
        p.Precio, 
        p.Stock, 
        p.CategoriaCodigo, 
        c.Descripcion AS Categoria
    FROM dbo.Productos p
    LEFT JOIN dbo.Categorias c 
        ON p.CategoriaCodigo = c.Codigo
    WHERE p.Nombre LIKE '%' + @f + '%'
       OR CAST(p.Codigo AS NVARCHAR(50)) LIKE '%' + @f + '%';
END
GO

-- =========================
-- INSERT
-- =========================
IF OBJECT_ID('dbo.usp_Producto_Insert','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Producto_Insert;
GO

CREATE PROCEDURE dbo.usp_Producto_Insert
    @Nombre NVARCHAR(200),
    @Precio DECIMAL(18,2),
    @Stock INT,
    @CategoriaCodigo INT = NULL,
    @NewId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Productos (Nombre, Precio, Stock, CategoriaCodigo)
    VALUES (@Nombre, @Precio, @Stock, @CategoriaCodigo);

    SET @NewId = SCOPE_IDENTITY();
END
GO

-- =========================
-- UPDATE
-- =========================
IF OBJECT_ID('dbo.usp_Producto_Update','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Producto_Update;
GO

CREATE PROCEDURE dbo.usp_Producto_Update
    @Codigo INT,
    @Nombre NVARCHAR(200),
    @Precio DECIMAL(18,2),
    @Stock INT,
    @CategoriaCodigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Productos
    SET 
        Nombre = @Nombre, 
        Precio = @Precio, 
        Stock = @Stock, 
        CategoriaCodigo = @CategoriaCodigo
    WHERE Codigo = @Codigo;
END
GO

-- =========================
-- DELETE
-- =========================
IF OBJECT_ID('dbo.usp_Producto_Delete','P') IS NOT NULL 
    DROP PROCEDURE dbo.usp_Producto_Delete;
GO

CREATE PROCEDURE dbo.usp_Producto_Delete
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Productos 
    WHERE Codigo = @Codigo;
END
GO