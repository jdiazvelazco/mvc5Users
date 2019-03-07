namespace JDVUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Direccions", "Contacto_Id", "dbo.Contactoes");
            DropIndex("dbo.Direccions", new[] { "Contacto_Id" });
            RenameColumn(table: "dbo.Direccions", name: "Contacto_Id", newName: "ContactoID");
            AlterColumn("dbo.Direccions", "ContactoID", c => c.Int());
            CreateIndex("dbo.Direccions", "ContactoID");
            AddForeignKey("dbo.Direccions", "ContactoID", "dbo.Contactoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccions", "ContactoID", "dbo.Contactoes");
            DropIndex("dbo.Direccions", new[] { "ContactoID" });
            AlterColumn("dbo.Direccions", "ContactoID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Direccions", name: "ContactoID", newName: "Contacto_Id");
            CreateIndex("dbo.Direccions", "Contacto_Id");
            AddForeignKey("dbo.Direccions", "Contacto_Id", "dbo.Contactoes", "Id", cascadeDelete: true);
        }
    }
}
