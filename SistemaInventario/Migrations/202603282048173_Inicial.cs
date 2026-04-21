namespace SistemaInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations; // Librería para gestionar versiones de la base de datos

    // El nombre "Inicial" sugiere que es la primera vez que se crea la estructura de la BD
    public partial class Inicial : DbMigration 
    {
        public override void Up()
        {
            // Orden para crear una nueva tabla física
            CreateTable(
                "dbo.Categorias", // Nombre de la tabla en SQL
                c => new
                    {
                    // Columna 'Codigo': 
                    // Es un entero (Int), obligatorio (nullable: false) 
                    // e incremental (identity: true), o sea, SQL pone 1, 2, 3... solo.
                    Codigo = c.Int(nullable: false, identity: true),

                    // Columna 'Descripcion':
                    // Es una cadena de texto (String) y es obligatoria.
                    Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo); // Define que 'Codigo' es la Llave Primaria (ID único)

        }
        
        public override void Down()
        {
            // Borra la tabla por completo si se decide volver atrás
            DropTable("dbo.Categorias");
        }
    }
}
