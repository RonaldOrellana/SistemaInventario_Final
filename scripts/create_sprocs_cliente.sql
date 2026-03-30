-- =============================================
-- Procedimientos almacenados para CLIENTES
-- =============================================

IF OBJECT_ID('dbo.usp_Clientes_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Clientes_GetAll;
GO
CREATE PROCEDURE dbo.usp_Clientes_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CodigoCliente, Nombres, Apellidos, Dni, Sexo, Direccion, Telefono
      FROM dbo.Clientes
     ORDER BY Apellidos, Nombres;
END
GO

IF OBJECT_ID('dbo.usp_Clientes_Search', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Clientes_Search;
GO
CREATE PROCEDURE dbo.usp_Clientes_Search
    @f NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CodigoCliente, Nombres, Apellidos, Dni, Sexo, Direccion, Telefono
      FROM dbo.Clientes
     WHERE Nombres   LIKE '%' + @f + '%'
        OR Apellidos LIKE '%' + @f + '%'
        OR Dni       LIKE '%' + @f + '%'
        OR CONVERT(NVARCHAR, CodigoCliente) = @f
     ORDER BY Apellidos, Nombres;
END
GO

IF OBJECT_ID('dbo.usp_Cliente_Insert', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Cliente_Insert;
GO
CREATE PROCEDURE dbo.usp_Cliente_Insert
    @Nombres   NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @Dni       NVARCHAR(20),
    @Sexo      NVARCHAR(20),
    @Direccion NVARCHAR(200) = NULL,
    @Telefono  NVARCHAR(30)  = NULL,
    @NewId     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Clientes(Nombres, Apellidos, Dni, Sexo, Direccion, Telefono)
    VALUES(@Nombres, @Apellidos, @Dni, @Sexo, @Direccion, @Telefono);
    SET @NewId = SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('dbo.usp_Cliente_Update', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Cliente_Update;
GO
CREATE PROCEDURE dbo.usp_Cliente_Update
    @CodigoCliente INT,
    @Nombres       NVARCHAR(100),
    @Apellidos     NVARCHAR(100),
    @Dni           NVARCHAR(20),
    @Sexo          NVARCHAR(20),
    @Direccion     NVARCHAR(200) = NULL,
    @Telefono      NVARCHAR(30)  = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Clientes
       SET Nombres   = @Nombres,
           Apellidos = @Apellidos,
           Dni       = @Dni,
           Sexo      = @Sexo,
           Direccion = @Direccion,
           Telefono  = @Telefono
     WHERE CodigoCliente = @CodigoCliente;
END
GO

IF OBJECT_ID('dbo.usp_Cliente_Delete', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Cliente_Delete;
GO
CREATE PROCEDURE dbo.usp_Cliente_Delete
    @CodigoCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Clientes WHERE CodigoCliente = @CodigoCliente;
END
GO