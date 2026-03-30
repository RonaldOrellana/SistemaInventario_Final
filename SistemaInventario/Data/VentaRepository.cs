using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventario.Data
{
    public static class VentaRepository
    {
        public static DataTable GetAll()
        {
            var dt = new DataTable();
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Ventas_GetAll", cn) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable Search(string filtro)
        {
            var dt = new DataTable();
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Ventas_Search", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@f", filtro);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetDetalles(int ventaId)
        {
            var dt = new DataTable();
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_VentaDetalles_GetByVentaId", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@VentaId", ventaId);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static int InsertVenta(int? clienteId, decimal total)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Venta_Insert", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@ClienteId", (object)clienteId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Total", total);
                var p = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(p);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)(p.Value ?? 0);
            }
        }

        public static void InsertDetalle(int ventaId, int productoCodigo, int cantidad, decimal precio, decimal subtotal)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_VentaDetalle_Insert", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@VentaId", ventaId);
                cmd.Parameters.AddWithValue("@ProductoCodigo", productoCodigo);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}