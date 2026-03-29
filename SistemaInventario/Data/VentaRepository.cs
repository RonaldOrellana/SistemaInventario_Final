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
    }
}