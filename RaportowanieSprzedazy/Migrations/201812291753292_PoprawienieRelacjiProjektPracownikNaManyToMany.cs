namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawienieRelacjiProjektPracownikNaManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pracowniks", "Projekt_Id", "dbo.Projekts");
            DropIndex("dbo.Pracowniks", new[] { "Projekt_Id" });
            CreateTable(
                "dbo.ProjektPracowniks",
                c => new
                    {
                        Projekt_Id = c.Int(nullable: false),
                        Pracownik_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Projekt_Id, t.Pracownik_Id })
                .ForeignKey("dbo.Projekts", t => t.Projekt_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pracowniks", t => t.Pracownik_Id, cascadeDelete: true)
                .Index(t => t.Projekt_Id)
                .Index(t => t.Pracownik_Id);
            
            DropColumn("dbo.Pracowniks", "Projekt_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pracowniks", "Projekt_Id", c => c.Int());
            DropForeignKey("dbo.ProjektPracowniks", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.ProjektPracowniks", "Projekt_Id", "dbo.Projekts");
            DropIndex("dbo.ProjektPracowniks", new[] { "Pracownik_Id" });
            DropIndex("dbo.ProjektPracowniks", new[] { "Projekt_Id" });
            DropTable("dbo.ProjektPracowniks");
            CreateIndex("dbo.Pracowniks", "Projekt_Id");
            AddForeignKey("dbo.Pracowniks", "Projekt_Id", "dbo.Projekts", "Id");
        }
    }
}
