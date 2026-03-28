using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario
{
    public class Conexion
    {
        public static SqlConnection cn = new SqlConnection(
            @"Data Source=DESKTOP-FLPOK2F\SQLEXPRESS01;Initial Catalog=Proyecto_FinalG2;Integrated Security=True"
        );
    }
}