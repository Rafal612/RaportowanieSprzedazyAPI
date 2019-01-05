namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieFKProjektuWTabeliAnkieta : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjektPracowniks", newName: "PracownikProjekts");
            DropForeignKey("dbo.Ankietas", "Projekt_Id", "dbo.Projekts");
            DropIndex("dbo.Ankietas", new[] { "Projekt_Id" });
            DropPrimaryKey("dbo.PracownikProjekts");
            AlterColumn("dbo.Ankietas", "Projekt_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PracownikProjekts", new[] { "Pracownik_Id", "Projekt_Id" });
            CreateIndex("dbo.Ankietas", "Projekt_Id");
            AddForeignKey("dbo.Ankietas", "Projekt_Id", "dbo.Projekts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ankietas", "Projekt_Id", "dbo.Projekts");
            DropIndex("dbo.Ankietas", new[] { "Projekt_Id" });
            DropPrimaryKey("dbo.PracownikProjekts");
            AlterColumn("dbo.Ankietas", "Projekt_Id", c => c.Int());
            AddPrimaryKey("dbo.PracownikProjekts", new[] { "Projekt_Id", "Pracownik_Id" });
            CreateIndex("dbo.Ankietas", "Projekt_Id");
            AddForeignKey("dbo.Ankietas", "Projekt_Id", "dbo.Projekts", "Id");
            RenameTable(name: "dbo.PracownikProjekts", newName: "ProjektPracowniks");
        }
    }
}
