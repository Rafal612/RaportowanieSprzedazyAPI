namespace RaportowanieSprzedazy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usnienicieIndexuDodanieRodzaiPytan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies");
            DropIndex("dbo.Odpowiedzs", "IX_OdpowiedzPytaniePracownik");
            DropIndex("dbo.Odpowiedzs", new[] { "Pracownik_Id" });
            DropIndex("dbo.Odpowiedzs", new[] { "Pytanie_Id" });
            CreateTable(
                "dbo.RodzajPytanias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Odpowiedzs", "TrescString", c => c.String());
            AddColumn("dbo.Odpowiedzs", "TrescDouble", c => c.Double(nullable: false));
            AddColumn("dbo.Odpowiedzs", "TrescInt", c => c.Int(nullable: false));
            AddColumn("dbo.Odpowiedzs", "TrescBool", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pytanies", "RodzajPytania_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Odpowiedzs", "Pracownik_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Odpowiedzs", "Pytanie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Odpowiedzs", "Pracownik_Id");
            CreateIndex("dbo.Odpowiedzs", "Pytanie_Id");
            CreateIndex("dbo.Pytanies", "RodzajPytania_Id");
            AddForeignKey("dbo.Pytanies", "RodzajPytania_Id", "dbo.RodzajPytanias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies", "Id", cascadeDelete: true);
            DropColumn("dbo.Odpowiedzs", "Tresc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Odpowiedzs", "Tresc", c => c.String(nullable: false, maxLength: 240));
            DropForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies");
            DropForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks");
            DropForeignKey("dbo.Pytanies", "RodzajPytania_Id", "dbo.RodzajPytanias");
            DropIndex("dbo.Pytanies", new[] { "RodzajPytania_Id" });
            DropIndex("dbo.Odpowiedzs", new[] { "Pytanie_Id" });
            DropIndex("dbo.Odpowiedzs", new[] { "Pracownik_Id" });
            AlterColumn("dbo.Odpowiedzs", "Pytanie_Id", c => c.Int());
            AlterColumn("dbo.Odpowiedzs", "Pracownik_Id", c => c.Int());
            DropColumn("dbo.Pytanies", "RodzajPytania_Id");
            DropColumn("dbo.Odpowiedzs", "TrescBool");
            DropColumn("dbo.Odpowiedzs", "TrescInt");
            DropColumn("dbo.Odpowiedzs", "TrescDouble");
            DropColumn("dbo.Odpowiedzs", "TrescString");
            DropTable("dbo.RodzajPytanias");
            CreateIndex("dbo.Odpowiedzs", "Pytanie_Id");
            CreateIndex("dbo.Odpowiedzs", "Pracownik_Id");
            CreateIndex("dbo.Odpowiedzs", "Id", name: "IX_OdpowiedzPytaniePracownik");
            AddForeignKey("dbo.Odpowiedzs", "Pytanie_Id", "dbo.Pytanies", "Id");
            AddForeignKey("dbo.Odpowiedzs", "Pracownik_Id", "dbo.Pracowniks", "Id");
        }
    }
}
