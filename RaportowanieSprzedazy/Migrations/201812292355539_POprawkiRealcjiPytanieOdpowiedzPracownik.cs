namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POprawkiRealcjiPytanieOdpowiedzPracownik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pytanies", "Ankieta_Id", "dbo.Ankietas");
            DropIndex("dbo.Pytanies", new[] { "Ankieta_Id" });
            AlterColumn("dbo.Pytanies", "Ankieta_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Pytanies", "Ankieta_Id");
            AddForeignKey("dbo.Pytanies", "Ankieta_Id", "dbo.Ankietas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pytanies", "Ankieta_Id", "dbo.Ankietas");
            DropIndex("dbo.Pytanies", new[] { "Ankieta_Id" });
            AlterColumn("dbo.Pytanies", "Ankieta_Id", c => c.Int());
            CreateIndex("dbo.Pytanies", "Ankieta_Id");
            AddForeignKey("dbo.Pytanies", "Ankieta_Id", "dbo.Ankietas", "Id");
        }
    }
}
