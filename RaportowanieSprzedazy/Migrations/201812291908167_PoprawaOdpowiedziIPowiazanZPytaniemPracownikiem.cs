namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawaOdpowiedziIPowiazanZPytaniemPracownikiem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pracowniks", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropIndex("dbo.Pracowniks", new[] { "Odpowiedz_Id" });
            DropIndex("dbo.Pracowniks", new[] { "Pytanie_Id" });
            CreateTable(
                "dbo.PracownikOdpowiedzs",
                c => new
                    {
                        Pracownik_Id = c.Int(nullable: false),
                        Odpowiedz_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pracownik_Id, t.Odpowiedz_Id })
                .ForeignKey("dbo.Pracowniks", t => t.Pracownik_Id, cascadeDelete: true)
                .ForeignKey("dbo.Odpowiedzs", t => t.Odpowiedz_Id, cascadeDelete: true)
                .Index(t => t.Pracownik_Id)
                .Index(t => t.Odpowiedz_Id);
            
            CreateTable(
                "dbo.PytaniePracowniks",
                c => new
                    {
                        Pytanie_Id = c.Int(nullable: false),
                        Pracownik_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pytanie_Id, t.Pracownik_Id })
                .ForeignKey("dbo.Pytanies", t => t.Pytanie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pracowniks", t => t.Pracownik_Id, cascadeDelete: true)
                .Index(t => t.Pytanie_Id)
                .Index(t => t.Pracownik_Id);
            
            DropColumn("dbo.Pracowniks", "Odpowiedz_Id");
            DropColumn("dbo.Pracowniks", "Pytanie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pracowniks", "Pytanie_Id", c => c.Int());
            AddColumn("dbo.Pracowniks", "Odpowiedz_Id", c => c.Int());
            DropForeignKey("dbo.PytaniePracowniks", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.PytaniePracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.PracownikOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropForeignKey("dbo.PracownikOdpowiedzs", "Pracownik_Id", "dbo.Pracowniks");
            DropIndex("dbo.PytaniePracowniks", new[] { "Pracownik_Id" });
            DropIndex("dbo.PytaniePracowniks", new[] { "Pytanie_Id" });
            DropIndex("dbo.PracownikOdpowiedzs", new[] { "Odpowiedz_Id" });
            DropIndex("dbo.PracownikOdpowiedzs", new[] { "Pracownik_Id" });
            DropTable("dbo.PytaniePracowniks");
            DropTable("dbo.PracownikOdpowiedzs");
            CreateIndex("dbo.Pracowniks", "Pytanie_Id");
            CreateIndex("dbo.Pracowniks", "Odpowiedz_Id");
            AddForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies", "Id");
            AddForeignKey("dbo.Pracowniks", "Odpowiedz_Id", "dbo.Odpowiedzs", "Id");
        }
    }
}
