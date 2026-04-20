using System;
using System.Configuration; // Permite leer archivos de configuración como el App.config
using System.Data.SqlClient; // Contiene las herramientas para conectarse a SQL Server

namespace SistemaInventario
{
    public static class Conexion
    {
        // Variable privada que guarda la "dirección" de la base de datos (Cadena de Conexión)
        private static readonly string connectionString =
            // 1. Intenta leer la conexión desde el archivo App.config o Web.config
            ConfigurationManager.ConnectionStrings["Proyecto_FinalG2"]?.ConnectionString
            // 2. Si no encuentra el archivo (??), usa esta dirección por defecto (Ruta manual)
            ?? @"Data Source=DESKTOP-FLPOK2F\SQLEXPRESS01;Initial Catalog=Proyecto_FinalG2;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            // Retorna un nuevo objeto SqlConnection usando la dirección definida arriba
            return new SqlConnection(connectionString);
        }
    }
}