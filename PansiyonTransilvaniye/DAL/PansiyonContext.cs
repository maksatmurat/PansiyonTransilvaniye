using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PansiyonTransilvaniye.Models;

namespace PansiyonTransilvaniye.DAL
{
    public class PansiyonContext : DbContext
    {
        public PansiyonContext() : base("PansiyonVeritabani") { }
        public DbSet<IletisimBilgileri> iletisimBilgileri { get; set; }
        public DbSet<Odalar> odalar { get; set; }
        public DbSet<AnaSayfaResimler> anaSayfaResimler { get; set; }
        public DbSet<Galeri>galeri { get; set; }
        public DbSet<KullaniciBilgileri> kullaniciBilgileri { get; set; }
        public DbSet<Services> services { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}