-- Procedimientos almacenados para Ventas

IF OBJECT_ID('dbo.usp_Ventas_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Ventas_GetAll;
GO
CREATE PROCEDURE dbo.usp_Ventas_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.Id,
           v.Fecha,
           ISNULL(c.Nombre, '(Sin cliente)') AS Cliente,
           v.Total
      FROM dbo.Ventas v
      LEFT JOIN dbo.Clientes c ON c.Id = v.ClienteId
     ORDER BY v.Fecha DESC;
END
GO

IF OBJECT_ID('dbo.usp_Ventas_Search', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Ventas_Search;
GO
CREATE PROCEDURE dbo.usp_Ventas_Search
    @f NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.Id,
           v.Fecha,
           ISNULL(c.Nombre, '(Sin cliente)') AS Cliente,
           v.Total
      FROM dbo.Ventas v
      LEFT JOIN dbo.Clientes c ON c.Id = v.ClienteId
     WHERE c.Nombre LIKE '%' + @f + '%'
        OR CONVERT(NVARCHAR, v.Id) = @f
     ORDER BY v.Fecha DESC;
END
GO

IF OBJECT_ID('dbo.usp_VentaDetalles_GetByVentaId', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_VentaDetalles_GetByVentaId;
GO
CREATE PROCEDURE dbo.usp_VentaDetalles_GetByVentaId
    @VentaId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT d.Id,
           p.Nombre AS Producto,
           d.Cantidad,
           d.Precio,
           d.Subtotal
      FROM dbo.VentaDetalles d
      INNER JOIN dbo.Productos p ON p.Codigo = d.ProductoCodigo
     WHERE d.VentaId = @VentaId;
END
GO