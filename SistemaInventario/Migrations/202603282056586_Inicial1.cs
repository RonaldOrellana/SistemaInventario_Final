namespace SistemaInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations; // Herramientas para migración de datos

    // El nombre "Inicial1" sugiere que es una evolución o la segunda tabla del sistema
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios", // Nombre de la tabla física en SQL Server
                c => new
                    {
                    // Llave primaria autoincremental (1, 2, 3...)
                    Id = c.Int(nullable: false, identity: true),

                    // Nombre del login: Obligatorio y máximo 100 caracteres
                    NombreUsuario = c.String(nullable: false, maxLength: 100),

                    // Contraseña: Obligatoria (aquí se guardará el hash, no el texto plano por seguridad)
                    PasswordHash = c.String(nullable: false),

                    // Nombre real de la persona: Opcional (admite nulos) y máximo 100 caracteres
                    Nombre = c.String(maxLength: 100),

                    // Rol del usuario (ej: "Admin", "Vendedor"): Máximo 50 caracteres
                    Rol = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id); // Establece el campo 'Id' como la clave principal

        }
        
        public override void Down()
        {
            // Borra la tabla de Usuarios por completo
            DropTable("dbo.Usuarios");
        }
    }
}
