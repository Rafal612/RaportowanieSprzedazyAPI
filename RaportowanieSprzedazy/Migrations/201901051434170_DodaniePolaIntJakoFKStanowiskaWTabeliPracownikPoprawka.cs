namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePolaIntJakoFKStanowiskaWTabeliPracownikPoprawka : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pracowniks", new[] { "StanowiskoID" });
            CreateIndex("dbo.Pracowniks", "StanowiskoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pracowniks", new[] { "StanowiskoId" });
            CreateIndex("dbo.Pracowniks", "StanowiskoID");
        }
    }
}
