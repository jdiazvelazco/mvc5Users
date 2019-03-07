namespace JDVUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactoes",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        TipoContacto = c.Int(nullable: false),
                        CorreoElectronico = c.String(),
                        RFC = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoDireccion = c.Int(nullable: false),
                        Pais = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                        Estado = c.String(),
                        Colonia = c.String(),
                        Calle = c.String(),
                        Numero = c.String(),
                        CodigoPostal = c.String(),
                        Contacto_Nombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contactoes", t => t.Contacto_Nombre, cascadeDelete: true)
                .Index(t => t.Contacto_Nombre);
            
            CreateTable(
                "dbo.Telefonoes",
                c => new
                    {
                        Numero = c.String(nullable: false, maxLength: 128),
                        TipoTelefono = c.Int(nullable: false),
                        Contacto_Nombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.Contactoes", t => t.Contacto_Nombre, cascadeDelete: true)
                .Index(t => t.Contacto_Nombre);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonoes", "Contacto_Nombre", "dbo.Contactoes");
            DropForeignKey("dbo.Direccions", "Contacto_Nombre", "dbo.Contactoes");
            DropIndex("dbo.Telefonoes", new[] { "Contacto_Nombre" });
            DropIndex("dbo.Direccions", new[] { "Contacto_Nombre" });
            DropTable("dbo.Telefonoes");
            DropTable("dbo.Direccions");
            DropTable("dbo.Contactoes");
        }
    }
}
