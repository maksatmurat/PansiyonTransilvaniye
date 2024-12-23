namespace PansiyonTransilvaniye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnaSayfaResimler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnaSayfaResimleri = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galeri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GaleriResimler = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IletisimBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        telNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Il = c.String(nullable: false),
                        Ilce = c.String(nullable: false),
                        Mah = c.String(nullable: false),
                        AcikAdres = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KullaniciBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(nullable: false),
                        Sifre = c.Double(nullable: false),
                        Hakkimizda = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Odalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OdaUcreti = c.Int(nullable: false),
                        OdaAdi = c.String(nullable: false),
                        OdaOzellikleri = c.String(nullable: false),
                        OdaResimleri = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceAdi = c.String(nullable: false),
                        ServiceOzellik = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
            DropTable("dbo.Odalar");
            DropTable("dbo.KullaniciBilgileri");
            DropTable("dbo.IletisimBilgileri");
            DropTable("dbo.Galeri");
            DropTable("dbo.AnaSayfaResimler");
        }
    }
}
