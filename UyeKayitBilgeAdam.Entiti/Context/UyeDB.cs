namespace UyeKayitBilgeAdam.Entiti.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UyeKayitBilgeAdam.Entiti.Models;

    public class UyeDB : DbContext
    {
        public UyeDB()
            : base("name=UyeDB")
        {
            Database.SetInitializer(new UyeDBInitializer());
        }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<UyeTipi> UyeTipi { get; set; }
    }
    public class UyeDBInitializer : CreateDatabaseIfNotExists<UyeDB>
    {
        protected override void Seed(UyeDB db)
        {
            db.UyeTipi.Add(new UyeTipi
            {
                Tipi = "Baþkan"
            });
            db.SaveChanges();
            db.UyeTipi.Add(new UyeTipi
            {
                Tipi = "Sekreter"
            });
            db.SaveChanges();
            db.UyeTipi.Add(new UyeTipi
            {
                Tipi = "Sayman"
            });
            db.SaveChanges();
        }
    }
}

