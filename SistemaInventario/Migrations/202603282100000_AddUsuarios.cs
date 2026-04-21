using System;
using System.Data.Entity.Migrations; // Librería para el control de versiones de la base de datos

namespace SistemaInventario.Migrations
{
    // El nombre "AddUsuarios" describe claramente que esta migración agrega la funcionalidad de usuarios
    public partial class AddUsuarios : DbMigration 
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios", // Nombre de la tabla en la base de datos
                c => new
                    {
                    // Llave Primaria: Entero, obligatorio y autoincremental (identity: true)
                    Id = c.Int(nullable: false, identity: true),

                    // Nombre de acceso (Login): Obligatorio y máximo 100 caracteres
                    Usuario = c.String(nullable: false, maxLength: 100),

                    // Contraseña cifrada: Obligatoria (campo crítico para la seguridad)
                    PasswordHash = c.String(nullable: false),

                    // Nombre completo de la persona: Máximo 100 caracteres, puede ser nulo (opcional)
                    Nombre = c.String(maxLength: 100),

                    // Rol (ej: 'Administrador', 'Cajero'): Máximo 50 caracteres
                    Rol = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id); // Define formalmente que 'Id' es la clave principal
        }

        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}