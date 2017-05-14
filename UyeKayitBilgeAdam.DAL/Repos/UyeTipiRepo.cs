using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UyeKayitBilgeAdam.DAL.VM;
using UyeKayitBilgeAdam.Entiti.Context;
using UyeKayitBilgeAdam.Entiti.Models;

namespace UyeKayitBilgeAdam.DAL.Repos
{
    public class UyeTipiRepo
    {
        public static List<VMUyeTipi> HepsiniListele() //Getir
        {
            using (UyeDB db = new UyeDB())
            {
                var a = db.UyeTipi.Select(p=> new VMUyeTipi { Tipi=p.Tipi, UyeTipiID=p.UyeTipiID}).ToList();
                return a;
            }
        }
        public static void UyeTipiKaydet(VMUyeTipi Al) //Kaydet
        {
            using (UyeDB db = new UyeDB())
            {
                bool kontrol = db.UyeTipi.Any(p => p.Tipi == Al.Tipi);
                if (kontrol != true)
                {
                    db.UyeTipi.Add(new UyeTipi() { Tipi = Al.Tipi });
                    db.SaveChanges();
                }
            }
        }
        public static void UyeTipiGuncelle(VMUyeTipi Al) //Güncelle
        {
            using (UyeDB db = new UyeDB())
            {
                bool kontrol = db.UyeTipi.Any(p => p.UyeTipiID == Al.UyeTipiID);
                if (kontrol != false)
                {
                    var guncelle = db.UyeTipi.FirstOrDefault(p => p.UyeTipiID == Al.UyeTipiID);
                    guncelle.Tipi = Al.Tipi;
                    db.SaveChanges();
                }
            }
        }
        public static void Sil(long Al) //Sil
        {
                using (UyeDB db = new UyeDB())
                {
                    var kontrol = db.UyeTipi.FirstOrDefault(p => p.UyeTipiID == Al);
                    db.UyeTipi.Remove(kontrol);
                    db.SaveChanges();
                }
        }
    }
}
