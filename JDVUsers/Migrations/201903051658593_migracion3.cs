namespace JDVUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Direccions", "Contacto_Nombre", "dbo.Contactoes");
            DropForeignKey("dbo.Telefonoes", "Contacto_Nombre", "dbo.Contactoes");
            DropIndex("dbo.Direccions", new[] { "Contacto_Nombre" });
            DropIndex("dbo.Telefonoes", new[] { "Contacto_Nombre" });
            RenameColumn(table: "dbo.Direccions", name: "Contacto_Nombre", newName: "Contacto_Id");
            RenameColumn(table: "dbo.Telefonoes", name: "Contacto_Nombre", newName: "Contacto_Id");
            DropPrimaryKey("dbo.Contactoes");
            DropPrimaryKey("dbo.Telefonoes");
            AddColumn("dbo.Contactoes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Telefonoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contactoes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Direccions", "Contacto_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Telefonoes", "Numero", c => c.String(nullable: false));
            AlterColumn("dbo.Telefonoes", "Contacto_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contactoes", "Id");
            AddPrimaryKey("dbo.Telefonoes", "Id");
            CreateIndex("dbo.Direccions", "Contacto_Id");
            CreateIndex("dbo.Telefonoes", "Contacto_Id");
            AddForeignKey("dbo.Direccions", "Contacto_Id", "dbo.Contactoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Telefonoes", "Contacto_Id", "dbo.Contactoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonoes", "Contacto_Id", "dbo.Contactoes");
            DropForeignKey("dbo.Direccions", "Contacto_Id", "dbo.Contactoes");
            DropIndex("dbo.Telefonoes", new[] { "Contacto_Id" });
            DropIndex("dbo.Direccions", new[] { "Contacto_Id" });
            DropPrimaryKey("dbo.Telefonoes");
            DropPrimaryKey("dbo.Contactoes");
            AlterColumn("dbo.Telefonoes", "Contacto_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Telefonoes", "Numero", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Direccions", "Contacto_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Contactoes", "Nombre", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Telefonoes", "Id");
            DropColumn("dbo.Contactoes", "Id");
            AddPrimaryKey("dbo.Telefonoes", "Numero");
            AddPrimaryKey("dbo.Contactoes", "Nombre");
            RenameColumn(table: "dbo.Telefonoes", name: "Contacto_Id", newName: "Contacto_Nombre");
            RenameColumn(table: "dbo.Direccions", name: "Contacto_Id", newName: "Contacto_Nombre");
            CreateIndex("dbo.Telefonoes", "Contacto_Nombre");
            CreateIndex("dbo.Direccions", "Contacto_Nombre");
            AddForeignKey("dbo.Telefonoes", "Contacto_Nombre", "dbo.Contactoes", "Nombre", cascadeDelete: true);
            AddForeignKey("dbo.Direccions", "Contacto_Nombre", "dbo.Contactoes", "Nombre", cascadeDelete: true);
        }
    }
}
