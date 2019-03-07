namespace JDVUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String());
            AddColumn("dbo.AspNetUsers", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Rol", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rol");
            DropColumn("dbo.AspNetUsers", "Activo");
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
