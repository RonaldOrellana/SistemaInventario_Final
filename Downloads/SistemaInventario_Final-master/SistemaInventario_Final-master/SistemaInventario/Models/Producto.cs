using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int? CategoriaCodigo { get; set; }
    }
}