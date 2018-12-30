namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawaRealacjiPytanieOdpowiedzPracownik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PytanieOdpowiedzs", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.PytanieOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropIndex("dbo.Pracowniks", new[] { "Pytanie_Id" });
            DropIndex("dbo.PytanieOdpowiedzs", new[] { "Pytanie_Id" });
            DropIndex("dbo.PytanieOdpowiedzs", new[] { "Odpowiedz_Id" });
            AddColumn("dbo.Odpowiedzs", "Pytanie_Id", c => c.Int());
            CreateIndex("dbo.Odpowiedzs", "Id", name: "IX_OdpowiedzPytaniePracownik");
            CreateIndex("dbo.Odpowiedzs", "Pytanie_Id");
            AddForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies", "Id");
            DropColumn("dbo.Pracowniks", "Pytanie_Id");
            DropTable("dbo.PytanieOdpowiedzs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PytanieOdpowiedzs",
                c => new
                    {
                        Pytanie_Id = c.Int(nullable: false),
                        Odpowiedz_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pytanie_Id, t.Odpowiedz_Id });
            
            AddColumn("dbo.Pracowniks", "Pytanie_Id", c => c.Int());
            DropForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies");
            DropIndex("dbo.Odpowiedzs", new[] { "Pytanie_Id" });
            DropIndex("dbo.Odpowiedzs", "IX_OdpowiedzPytaniePracownik");
            DropColumn("dbo.Odpowiedzs", "Pytanie_Id");
            CreateIndex("dbo.PytanieOdpowiedzs", "Odpowiedz_Id");
            CreateIndex("dbo.PytanieOdpowiedzs", "Pytanie_Id");
            CreateIndex("dbo.Pracowniks", "Pytanie_Id");
            AddForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies", "Id");
            AddForeignKey("dbo.PytanieOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PytanieOdpowiedzs", "Pytanie_Id", "dbo.Pytanies", "Id", cascadeDelete: true);
        }
    }
}
