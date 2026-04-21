using System;
using System.Data.Entity.Migrations;// Herramientas para modificar la estructura de la BD

namespace SistemaInventario.Migrations 
{
    // El nombre "AddEstadoCategorias" indica que estamos añadiendo un campo de estado
    public partial class AddEstadoCategorias : DbMigration
    {
        public override void Up()
        {
            // Agrega una nueva columna llamada "Estado" a la tabla "dbo.Categorias"
            AddColumn("dbo.Categorias", "Estado", c => c.Boolean(
                nullable: false, // No permite valores nulos (debe ser True o False)
                defaultValue: true)); // Por defecto, todas las categorías existentes serán "True" (Activo)
        }
        
        public override void Down()
        {
            // Quita la columna de la tabla para volver al diseño original
            DropColumn("dbo.Categorias", "Estado");
        }
    }
}