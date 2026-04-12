using System.Data.Entity;

namespace SistemaInventario.Models
{
    public class InventarioContext : DbContext
    {
        // Coincidir con App.config: "Proyecto_FinalG2"
        public InventarioContext() : base("name=Proyecto_FinalG2") { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } // <-- añadido
    }
}   