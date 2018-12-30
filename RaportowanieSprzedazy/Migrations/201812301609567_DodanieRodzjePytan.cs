namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieRodzjePytan : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RODZAJPYTANIAS VALUES ('Otwarte')");
            Sql("INSERT INTO RODZAJPYTANIAS VALUES ('Liczba calkowita')");
            Sql("INSERT INTO RODZAJPYTANIAS VALUES ('Liczba z przecinkiem')");
            Sql("INSERT INTO RODZAJPYTANIAS VALUES ('TAK lub NIE')");


        }

        public override void Down()
        {
        }
    }
}
