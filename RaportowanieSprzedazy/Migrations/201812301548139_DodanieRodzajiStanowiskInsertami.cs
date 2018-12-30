namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieRodzajiStanowiskInsertami : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO STANOWISKOES VALUES ('Manager')");
            Sql("INSERT INTO STANOWISKOES VALUES ('Promotor')");

        }

        public override void Down()
        {

        }
    }
}
