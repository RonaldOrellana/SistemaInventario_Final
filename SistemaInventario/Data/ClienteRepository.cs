using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaInventario.Data
{
    public static class ClienteRepository
    {
        public static DataTable GetAll()
        {
            var dt = new DataTable();
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Clientes_GetAll", cn) { CommandType = CommandType.StoredProcedure })
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
            using (var cmd = new SqlCommand("dbo.usp_Clientes_Search", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@f", filtro);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static int Insert(string nombres, string apellidos, string dni, string sexo, string direccion, string telefono)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Cliente_Insert", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Nombres", nombres);
                cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                cmd.Parameters.AddWithValue("@Dni", dni);
                cmd.Parameters.AddWithValue("@Sexo", sexo);
                cmd.Parameters.AddWithValue("@Direccion", (object)direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object)telefono ?? DBNull.Value);
                var p = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(p);
                cn.Open();
                cmd.ExecuteNonQuery();
                return (int)(p.Value ?? 0);
            }
        }

        public static bool Update(int codigoCliente, string nombres, string apellidos, string dni, string sexo, string direccion, string telefono)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Cliente_Update", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                cmd.Parameters.AddWithValue("@Nombres", nombres);
                cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                cmd.Parameters.AddWithValue("@Dni", dni);
                cmd.Parameters.AddWithValue("@Sexo", sexo);
                cmd.Parameters.AddWithValue("@Direccion", (object)direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object)telefono ?? DBNull.Value);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool Delete(int codigoCliente)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Cliente_Delete", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}