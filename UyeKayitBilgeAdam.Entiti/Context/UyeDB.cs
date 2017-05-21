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
            db.Uye.Add(new Uye
            {
                Admin = true,
                UyeAdi = "yavuz",
                Email = "mail@yavuzgedik.com",
                Sifre = "1234",
                Telefon = "5423428009",
                UyeSoyadi = "gedik",
                UyeTipiID = 1
            });
            db.SaveChanges();
        }
    }
}

