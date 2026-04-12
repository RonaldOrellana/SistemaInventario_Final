using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Rol { get; set; }
    }
}