namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieProjektuIAnkiety : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ankietas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Projekt_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projekts", t => t.Projekt_Id)
                .Index(t => t.Projekt_Id);
            
            CreateTable(
                "dbo.Projekts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pracowniks", "Projekt_Id", c => c.Int());
            CreateIndex("dbo.Pracowniks", "Projekt_Id");
            AddForeignKey("dbo.Pracowniks", "Projekt_Id", "dbo.Projekts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pracowniks", "Projekt_Id", "dbo.Projekts");
            DropForeignKey("dbo.Ankietas", "Projekt_Id", "dbo.Projekts");
            DropIndex("dbo.Pracowniks", new[] { "Projekt_Id" });
            DropIndex("dbo.Ankietas", new[] { "Projekt_Id" });
            DropColumn("dbo.Pracowniks", "Projekt_Id");
            DropTable("dbo.Projekts");
            DropTable("dbo.Ankietas");
        }
    }
}
