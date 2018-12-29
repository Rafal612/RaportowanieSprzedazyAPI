namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieOdpowiedziIPowiazanZPytaniemPracownikiem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Odpowiedzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pytanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                        Ankieta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ankietas", t => t.Ankieta_Id)
                .Index(t => t.Ankieta_Id);
            
            CreateTable(
                "dbo.PytanieOdpowiedzs",
                c => new
                    {
                        Pytanie_Id = c.Int(nullable: false),
                        Odpowiedz_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pytanie_Id, t.Odpowiedz_Id })
                .ForeignKey("dbo.Pytanies", t => t.Pytanie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Odpowiedzs", t => t.Odpowiedz_Id, cascadeDelete: true)
                .Index(t => t.Pytanie_Id)
                .Index(t => t.Odpowiedz_Id);
            
            AddColumn("dbo.Pracowniks", "Odpowiedz_Id", c => c.Int());
            AddColumn("dbo.Pracowniks", "Pytanie_Id", c => c.Int());
            CreateIndex("dbo.Pracowniks", "Odpowiedz_Id");
            CreateIndex("dbo.Pracowniks", "Pytanie_Id");
            AddForeignKey("dbo.Pracowniks", "Odpowiedz_Id", "dbo.Odpowiedzs", "Id");
            AddForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pracowniks", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.PytanieOdpowiedzs", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropForeignKey("dbo.PytanieOdpowiedzs", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.Pytanies", "Ankieta_Id", "dbo.Ankietas");
            DropForeignKey("dbo.Pracowniks", "Odpowiedz_Id", "dbo.Odpowiedzs");
            DropIndex("dbo.PytanieOdpowiedzs", new[] { "Odpowiedz_Id" });
            DropIndex("dbo.PytanieOdpowiedzs", new[] { "Pytanie_Id" });
            DropIndex("dbo.Pytanies", new[] { "Ankieta_Id" });
            DropIndex("dbo.Pracowniks", new[] { "Pytanie_Id" });
            DropIndex("dbo.Pracowniks", new[] { "Odpowiedz_Id" });
            DropColumn("dbo.Pracowniks", "Pytanie_Id");
            DropColumn("dbo.Pracowniks", "Odpowiedz_Id");
            DropTable("dbo.PytanieOdpowiedzs");
            DropTable("dbo.Pytanies");
            DropTable("dbo.Odpowiedzs");
        }
    }
}
