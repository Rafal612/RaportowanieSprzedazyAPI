namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DdoanieTestowegoPracownika : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PRACOWNIKS (Imie,Nazwisko) VALUES('Rafa³', 'Staniewski');");
        }
        
        public override void Down()
        {
        }
    }
}
