-- Procedimientos almacenados para Productos

IF OBJECT_ID('dbo.usp_Producto_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Producto_GetAll;
GO
CREATE PROCEDURE dbo.usp_Producto_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Codigo,
           p.Nombre,
           p.Precio,
           p.Stock,
           p.CategoriaCodigo,
           ISNULL(c.Descripcion, '') AS CategoriaDescripcion
      FROM dbo.Productos p
      LEFT JOIN dbo.Categorias c ON c.Codigo = p.CategoriaCodigo;
END
GO

IF OBJECT_ID('dbo.usp_Producto_Search', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Producto_Search;
GO
CREATE PROCEDURE dbo.usp_Producto_Search
    @f NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Codigo,
           p.Nombre,
           p.Precio,
           p.Stock,
           p.CategoriaCodigo,
           ISNULL(c.Descripcion, '') AS CategoriaDescripcion
      FROM dbo.Productos p
      LEFT JOIN dbo.Categorias c ON c.Codigo = p.CategoriaCodigo
     WHERE p.Nombre LIKE @f;
END
GO

IF OBJECT_ID('dbo.usp_Producto_Insert', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Producto_Insert;
GO
CREATE PROCEDURE dbo.usp_Producto_Insert
    @Nombre          NVARCHAR(200),
    @Precio          DECIMAL(18,2),
    @Stock           INT,
    @CategoriaCodigo INT = NULL,
    @NewId           INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Productos(Nombre, Precio, Stock, CategoriaCodigo)
    VALUES(@Nombre, @Precio, @Stock, @CategoriaCodigo);
    SET @NewId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('dbo.usp_Producto_Update', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Producto_Update;
GO
CREATE PROCEDURE dbo.usp_Producto_Update
    @Codigo          INT,
    @Nombre          NVARCHAR(200),
    @Precio          DECIMAL(18,2),
    @Stock           INT,
    @CategoriaCodigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Productos
       SET Nombre          = @Nombre,
           Precio          = @Precio,
           Stock           = @Stock,
           CategoriaCodigo = @CategoriaCodigo
     WHERE Codigo = @Codigo;
END
GO

IF OBJECT_ID('dbo.usp_Producto_Delete', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Producto_Delete;
GO
CREATE PROCEDURE dbo.usp_Producto_Delete
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Productos WHERE Codigo = @Codigo;
END
GO

-- Procedimiento para obtener categorías activas (para ComboBox)
IF OBJECT_ID('dbo.usp_Categoria_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_GetAll;
GO
CREATE PROCEDURE dbo.usp_Categoria_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Codigo, Descripcion
      FROM dbo.Categorias
     WHERE Estado = 1
     ORDER BY Descripcion;
END
GO