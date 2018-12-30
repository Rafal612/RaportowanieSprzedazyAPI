namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawaIndexuPytanieOdpowiedzPracownik : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Odpowiedzs", "IX_OdpowiedzPytaniePracownik");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Odpowiedzs", "Id", name: "IX_OdpowiedzPytaniePracownik");
        }
    }
}
