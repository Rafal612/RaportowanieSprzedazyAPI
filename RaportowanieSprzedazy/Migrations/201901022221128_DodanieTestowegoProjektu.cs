namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieTestowegoProjektu : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PROJEKTS (Nazwa) values ('Projekt testowy');");
        }
        
        public override void Down()
        {
        }
    }
}
