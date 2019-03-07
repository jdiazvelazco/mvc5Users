namespace JDVUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telefonoes", "Contacto_Id", "dbo.Contactoes");
            DropIndex("dbo.Telefonoes", new[] { "Contacto_Id" });
            RenameColumn(table: "dbo.Telefonoes", name: "Contacto_Id", newName: "ContactoID");
            AlterColumn("dbo.Telefonoes", "ContactoID", c => c.Int());
            CreateIndex("dbo.Telefonoes", "ContactoID");
            AddForeignKey("dbo.Telefonoes", "ContactoID", "dbo.Contactoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonoes", "ContactoID", "dbo.Contactoes");
            DropIndex("dbo.Telefonoes", new[] { "ContactoID" });
            AlterColumn("dbo.Telefonoes", "ContactoID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Telefonoes", name: "ContactoID", newName: "Contacto_Id");
            CreateIndex("dbo.Telefonoes", "Contacto_Id");
            AddForeignKey("dbo.Telefonoes", "Contacto_Id", "dbo.Contactoes", "Id", cascadeDelete: true);
        }
    }
}
