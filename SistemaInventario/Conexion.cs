using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaInventario
{
    public static class Conexion
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["Proyecto_FinalG2"]?.ConnectionString
            ?? @"Data Source=DESKTOP-FLPOK2F\SQLEXPRESS01;Initial Catalog=Proyecto_FinalG2;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}