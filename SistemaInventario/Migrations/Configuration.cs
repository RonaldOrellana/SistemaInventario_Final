using System;
using System.Data.Entity;
using System.Data.Entity.Migrations; // Herramientas de migración
using System.Linq;
using System.Text;
using System.Security.Cryptography; // Necesario para cifrar contraseñas
using SistemaInventario.Models;

namespace SistemaInventario.Migrations
{
    // 'internal sealed' significa que esta clase solo se usa dentro de este proyecto y no se puede heredar
    internal sealed class Configuration : DbMigrationsConfiguration<SistemaInventario.Models.InventarioContext>
    {
        public Configuration()
        {
            // Desactiva las migraciones automáticas. 
            // Esto obliga al desarrollador a crear archivos de migración (como los que me mostraste antes)
            // lo cual es mucho más seguro para proyectos en producción.
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SistemaInventario.Models.InventarioContext context)
        {
            // 1. Verificación de existencia: 
            // Buscamos si ya existe un usuario llamado "admin" para no crearlo dos veces.
            if (!context.Usuarios.Any(u => u.NombreUsuario == "admin"))
            {
                // 2. Creación del usuario administrador por defecto
                var admin = new Usuario
                {
                    NombreUsuario = "admin",
                    // IMPORTANTE: No guardamos "admin123", sino su versión cifrada (Hash)
                    PasswordHash = ComputeSha256Hash("admin123"), // contraseña de ejemplo
                    Nombre = "Administrador",
                    Rol = "Admin"
                };

                // 3. Se agrega al contexto y se guardan los cambios en la BD
                context.Usuarios.Add(admin);
                context.SaveChanges();
            }
        }

        private static string ComputeSha256Hash(string raw)
        {
            using (var sha = SHA256.Create())
            {
                // Convierte el texto en un arreglo de bytes
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));

                // Convierte los bytes resultantes en una cadena hexadecimal limpia
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
