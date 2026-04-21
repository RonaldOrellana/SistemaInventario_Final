using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventario.Data
{
    public static class ProductoRepository
    {
        public static DataTable GetAll()
        {
            var dt = new DataTable();
            using (var cn = SistemaInventario.Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Productos_GetAll", cn) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable Search(string filtro)
        {
            var dt = new DataTable();
            using (var cn = SistemaInventario.Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Productos_Search", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@f", filtro);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static int Insert(string nombre, decimal precio, int stock, int? categoriaCodigo)
        {
            using (var cn = SistemaInventario.Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Producto_Insert", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoriaCodigo", (object)categoriaCodigo ?? DBNull.Value);
                var p = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(p);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)(p.Value ?? 0);
            }
        }

        public static bool Update(int codigo, string nombre, decimal precio, int stock, int? categoriaCodigo)
        {
            using (var cn = SistemaInventario.Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Producto_Update", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@CategoriaCodigo", (object)categoriaCodigo ?? DBNull.Value);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool Delete(int codigo)
        {
            using (var cn = SistemaInventario.Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Producto_Delete", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}