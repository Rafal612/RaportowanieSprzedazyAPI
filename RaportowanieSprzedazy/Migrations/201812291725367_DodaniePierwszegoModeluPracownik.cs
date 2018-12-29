namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePierwszegoModeluPracownik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        DrugieImie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pracowniks");
        }
    }
}
