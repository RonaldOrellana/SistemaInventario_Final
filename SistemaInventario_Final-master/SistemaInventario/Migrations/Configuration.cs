using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using SistemaInventario.Models;

namespace SistemaInventario.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SistemaInventario.Models.InventarioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SistemaInventario.Models.InventarioContext context)
        {
            // Evita duplicados
            if (!context.Usuarios.Any(u => u.NombreUsuario == "admin"))
            {
                var admin = new Usuario
                {
                    NombreUsuario = "admin",
                    PasswordHash = ComputeSha256Hash("admin123"), // contraseña de ejemplo
                    Nombre = "Administrador",
                    Rol = "Admin"
                };
                context.Usuarios.Add(admin);
                context.SaveChanges();
            }
        }

        private static string ComputeSha256Hash(string raw)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
