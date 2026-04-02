-- =============================================
-- Procedimientos almacenados para CLIENTES
-- =============================================

IF OBJECT_ID('dbo.usp_Clientes_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Clientes_GetAll;
GO
CREATE PROCEDURE dbo.usp_Clientes_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CodigoCliente, Nombres, Apellidos, Dui, Sexo, Direccion, Telefono
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
    SELECT CodigoCliente, Nombres, Apellidos, Dui, Sexo, Direccion, Telefono
      FROM dbo.Clientes
     WHERE Nombres   LIKE '%' + @f + '%'
        OR Apellidos LIKE '%' + @f + '%'
        OR Dui       LIKE '%' + @f + '%'
        OR CONVERT(NVARCHAR, CodigoCliente) = @f
     ORDER BY Apellidos, Nombres;
END
GO