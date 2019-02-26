namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePolaIntJakoFKStanowiskaWTabeliPracownik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pracowniks", "Stanowisko_Id", "dbo.Stanowiskoes");
            DropIndex("dbo.Pracowniks", new[] { "Stanowisko_Id" });
            RenameColumn(table: "dbo.Pracowniks", name: "Stanowisko_Id", newName: "StanowiskoID");
            AlterColumn("dbo.Pracowniks", "StanowiskoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pracowniks", "StanowiskoID");
            AddForeignKey("dbo.Pracowniks", "StanowiskoID", "dbo.Stanowiskoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pracowniks", "StanowiskoID", "dbo.Stanowiskoes");
            DropIndex("dbo.Pracowniks", new[] { "StanowiskoID" });
            AlterColumn("dbo.Pracowniks", "StanowiskoID", c => c.Int());
            RenameColumn(table: "dbo.Pracowniks", name: "StanowiskoID", newName: "Stanowisko_Id");
            CreateIndex("dbo.Pracowniks", "Stanowisko_Id");
            AddForeignKey("dbo.Pracowniks", "Stanowisko_Id", "dbo.Stanowiskoes", "Id");
        }
    }
}
