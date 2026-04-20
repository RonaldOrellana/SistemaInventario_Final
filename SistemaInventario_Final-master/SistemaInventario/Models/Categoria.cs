using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public bool Estado { get; set; } = true;
    }
}