namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZamianaZWieluNaJedenOdpowiedzPracownik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PracownikOdpowiedzs", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.PracownikOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropForeignKey("dbo.PytaniePracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.PytaniePracowniks", "Pracownik_Id", "dbo.Pracowniks");
            DropIndex("dbo.PracownikOdpowiedzs", new[] { "Pracownik_Id" });
            DropIndex("dbo.PracownikOdpowiedzs", new[] { "Odpowiedz_Id" });
            DropIndex("dbo.PytaniePracowniks", new[] { "Pytanie_Id" });
            DropIndex("dbo.PytaniePracowniks", new[] { "Pracownik_Id" });
            CreateTable(
                "dbo.Stanowiskoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Odpowiedzs", "Pracownik_Id", c => c.Int());
            AddColumn("dbo.Pracowniks", "Stanowisko_Id", c => c.Int());
            AddColumn("dbo.Pracowniks", "Pytanie_Id", c => c.Int());
            CreateIndex("dbo.Odpowiedzs", "Pracownik_Id");
            CreateIndex("dbo.Pracowniks", "Stanowisko_Id");
            CreateIndex("dbo.Pracowniks", "Pytanie_Id");
            AddForeignKey("dbo.Pracowniks", "Stanowisko_Id", "dbo.Stanowiskoes", "Id");
            AddForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks", "Id");
            AddForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies", "Id");
            DropTable("dbo.PracownikOdpowiedzs");
            DropTable("dbo.PytaniePracowniks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PytaniePracowniks",
                c => new
                    {
                        Pytanie_Id = c.Int(nullable: false),
                        Pracownik_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pytanie_Id, t.Pracownik_Id });
            
            CreateTable(
                "dbo.PracownikOdpowiedzs",
                c => new
                    {
                        Pracownik_Id = c.Int(nullable: false),
                        Odpowiedz_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pracownik_Id, t.Odpowiedz_Id });
            
            DropForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.Pracowniks", "Stanowisko_Id", "dbo.Stanowiskoes");
            DropIndex("dbo.Pracowniks", new[] { "Pytanie_Id" });
            DropIndex("dbo.Pracowniks", new[] { "Stanowisko_Id" });
            DropIndex("dbo.Odpowiedzs", new[] { "Pracownik_Id" });
            DropColumn("dbo.Pracowniks", "Pytanie_Id");
            DropColumn("dbo.Pracowniks", "Stanowisko_Id");
            DropColumn("dbo.Odpowiedzs", "Pracownik_Id");
            DropTable("dbo.Stanowiskoes");
            CreateIndex("dbo.PytaniePracowniks", "Pracownik_Id");
            CreateIndex("dbo.PytaniePracowniks", "Pytanie_Id");
            CreateIndex("dbo.PracownikOdpowiedzs", "Odpowiedz_Id");
            CreateIndex("dbo.PracownikOdpowiedzs", "Pracownik_Id");
            AddForeignKey("dbo.PytaniePracowniks", "Pracownik_Id", "dbo.Pracowniks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PytaniePracowniks", "Pytanie_Id", "dbo.Pytanies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PracownikOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PracownikOdpowiedzs", "Pracownik_Id", "dbo.Pracowniks", "Id", cascadeDelete: true);
        }
    }
}
