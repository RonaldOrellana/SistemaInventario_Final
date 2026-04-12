using System;
using System.Data.Entity.Migrations;

namespace SistemaInventario.Migrations
{
    public partial class AddEstadoCategorias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "Estado", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categorias", "Estado");
        }
    }
}