using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        // Nuevo: Estado (true = activo, false = inactivo)
        public bool Estado { get; set; } = true;
    }
}