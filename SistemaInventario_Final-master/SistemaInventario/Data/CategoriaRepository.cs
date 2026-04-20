using System.Data;
using System.Data.SqlClient;
using System; // <-- Agregue esta línea
using System.Windows.Forms; // <-- Agregue esta línea

namespace SistemaInventario.Data
{
    public static class CategoriaRepository
    {
        public static DataTable GetAll()
        {
            var dt = new DataTable();
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("dbo.usp_Categorias_GetAll", cn) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static int? GetSelectedValue(object selectedValue)
        {
            return selectedValue == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(selectedValue);
        }
    }
}