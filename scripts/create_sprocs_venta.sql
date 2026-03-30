-- =============================================
-- Procedimientos almacenados para VENTAS
-- (Reemplaza el archivo existente)
-- =============================================

-- ---------- INSERT Venta ----------
IF OBJECT_ID('dbo.usp_Venta_Insert', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Venta_Insert;
GO
CREATE PROCEDURE dbo.usp_Venta_Insert
    @ClienteId INT = NULL,
    @Total     DECIMAL(18,2),
    @NewId     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Ventas(Fecha, ClienteId, Total)
    VALUES(GETDATE(), @ClienteId, @Total);
    SET @NewId = SCOPE_IDENTITY();
END
GO

-- ---------- INSERT VentaDetalle ----------
IF OBJECT_ID('dbo.usp_VentaDetalle_Insert', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_VentaDetalle_Insert;
GO
CREATE PROCEDURE dbo.usp_VentaDetalle_Insert
    @VentaId        INT,
    @ProductoCodigo INT,
    @Cantidad       INT,
    @Precio         DECIMAL(18,2),
    @Subtotal       DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.VentaDetalles(VentaId, ProductoCodigo, Cantidad, Precio, Subtotal)
    VALUES(@VentaId, @ProductoCodigo, @Cantidad, @Precio, @Subtotal);

    -- Reducir stock del producto vendido
    UPDATE dbo.Productos
       SET Stock = Stock - @Cantidad
     WHERE Codigo = @ProductoCodigo;
END
GO

-- ---------- GET ALL Ventas (actualizado para nueva tabla Clientes) ----------
IF OBJECT_ID('dbo.usp_Ventas_GetAll', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Ventas_GetAll;
GO
CREATE PROCEDURE dbo.usp_Ventas_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.Id,
           v.Fecha,
           ISNULL(c.Nombres + ' ' + c.Apellidos, '(Sin cliente)') AS Cliente,
           v.Total
      FROM dbo.Ventas v
      LEFT JOIN dbo.Clientes c ON c.CodigoCliente = v.ClienteId
     ORDER BY v.Fecha DESC;
END
GO

-- ---------- SEARCH Ventas ----------
IF OBJECT_ID('dbo.usp_Ventas_Search', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_Ventas_Search;
GO
CREATE PROCEDURE dbo.usp_Ventas_Search
    @f NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.Id,
           v.Fecha,
           ISNULL(c.Nombres + ' ' + c.Apellidos, '(Sin cliente)') AS Cliente,
           v.Total
      FROM dbo.Ventas v
      LEFT JOIN dbo.Clientes c ON c.CodigoCliente = v.ClienteId
     WHERE c.Nombres  LIKE '%' + @f + '%'
        OR c.Apellidos LIKE '%' + @f + '%'
        OR CONVERT(NVARCHAR, v.Id) = @f
     ORDER BY v.Fecha DESC;
END
GO

-- ---------- GET Detalles por VentaId ----------
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