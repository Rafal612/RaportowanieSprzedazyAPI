namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePodstawowychAndnotacjiDoMOdeli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ankietas", "Numer", c => c.Int(nullable: false));
            AlterColumn("dbo.Odpowiedzs", "Tresc", c => c.String(nullable: false, maxLength: 240));
            AlterColumn("dbo.Pracowniks", "Imie", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Pracowniks", "DrugieImie", c => c.String(maxLength: 60));
            AlterColumn("dbo.Pracowniks", "Nazwisko", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Projekts", "Nazwa", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Stanowiskoes", "Nazwa", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Pytanies", "Tresc", c => c.String(nullable: false, maxLength: 240));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pytanies", "Tresc", c => c.String());
            AlterColumn("dbo.Stanowiskoes", "Nazwa", c => c.String());
            AlterColumn("dbo.Projekts", "Nazwa", c => c.String());
            AlterColumn("dbo.Pracowniks", "Nazwisko", c => c.String());
            AlterColumn("dbo.Pracowniks", "DrugieImie", c => c.String());
            AlterColumn("dbo.Pracowniks", "Imie", c => c.String());
            AlterColumn("dbo.Odpowiedzs", "Tresc", c => c.String());
            DropColumn("dbo.Ankietas", "Numer");
        }
    }
}
