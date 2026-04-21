using System;
using System.Data.Entity.Migrations;

namespace SistemaInventario.Migrations
{
    public partial class AddUsuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        Nombre = c.String(maxLength: 100),
                        Rol = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}