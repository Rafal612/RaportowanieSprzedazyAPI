namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieWymaganegoNazwyWRodzajuPytania : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RodzajPytanias", "Nazwa", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RodzajPytanias", "Nazwa", c => c.String());
        }
    }
}
