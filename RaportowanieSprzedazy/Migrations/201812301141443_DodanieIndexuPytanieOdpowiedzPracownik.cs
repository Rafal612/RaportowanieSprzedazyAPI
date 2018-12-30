namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieIndexuPytanieOdpowiedzPracownik : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Odpowiedzs", "Id", name: "IX_OdpowiedzPytaniePracownik");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Odpowiedzs", "IX_OdpowiedzPytaniePracownik");
        }
    }
}
