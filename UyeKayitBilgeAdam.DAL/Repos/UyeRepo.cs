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
    public class UyeRepo
    {
        public static List<VMUye> HepsiniListele() //Getir
        {
            using (UyeDB db = new UyeDB())
            {
                var a = db.Uye.Select(P => new VMUye
                {
                    UyeAdi = P.UyeAdi,
                    Email = P.Email,
                    Telefon = P.Telefon,
                    UyeID = P.UyeID,
                    UyeSoyadi = P.UyeSoyadi,
                    UyeTipi = P.UyeTipi.Tipi
                }).ToList();
                return a;
            }
        }
        public static void UyeKaydet(VMUye Al) //Kaydet
        {
            using (UyeDB db = new UyeDB())
            {
                bool kontrol = db.Uye.Any(p => p.UyeAdi == Al.UyeAdi);
                if (kontrol != true)
                {
                    bool uyetipikontrol = db.UyeTipi.Any(p => p.Tipi == Al.UyeTipi);
                    if (uyetipikontrol != true)
                    {
                        db.UyeTipi.Add(new UyeTipi()
                        {
                            Tipi = Al.UyeTipi
                        });
                        db.SaveChanges();

                        var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);

                        db.Uye.Add(new Uye()
                        {
                            Email = Al.Email,
                            Telefon = Al.Telefon,
                            UyeAdi = Al.UyeAdi,
                            UyeSoyadi = Al.UyeSoyadi,
                            UyeTipiID = simdibuluyetipi.UyeTipiID,
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                        db.Uye.Add(new Uye()
                        {
                            Email = Al.Email,
                            Telefon = Al.Telefon,
                            UyeAdi = Al.UyeAdi,
                            UyeSoyadi = Al.UyeSoyadi,
                            UyeTipiID = simdibuluyetipi.UyeTipiID,
                        });
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void UyeGuncelle(VMUye Al) //Guncelle
        {
            using (UyeDB db = new UyeDB())
            {
                bool kontrol = db.Uye.Any(p => p.UyeID == Al.UyeID);
                if (kontrol != false)
                {
                    bool uyetipikontrol = db.UyeTipi.Any(p => p.Tipi == Al.UyeTipi);
                    if (uyetipikontrol != true)
                    {
                        db.UyeTipi.Add(new UyeTipi()
                        {
                            Tipi = Al.UyeTipi
                        });
                        db.SaveChanges();

                        var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                        var guncelle = db.Uye.FirstOrDefault(p => p.UyeID == Al.UyeID);

                        guncelle.Email = Al.Email;
                        guncelle.Telefon = Al.Telefon;
                        guncelle.UyeAdi = Al.UyeAdi;
                        guncelle.UyeSoyadi = Al.UyeSoyadi;
                        guncelle.UyeTipiID = simdibuluyetipi.UyeTipiID;

                        db.SaveChanges();
                    }
                    else
                    {
                        var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                        var guncelle = db.Uye.FirstOrDefault(p => p.UyeID == Al.UyeID);

                        guncelle.Email = Al.Email;
                        guncelle.Telefon = Al.Telefon;
                        guncelle.UyeAdi = Al.UyeAdi;
                        guncelle.UyeSoyadi = Al.UyeSoyadi;
                        guncelle.UyeTipiID = simdibuluyetipi.UyeTipiID;

                        db.SaveChanges();
                    }
                }
            }
        }
        public static void Sil (long Al) //Sil
        {
                using (UyeDB db = new UyeDB())
                {
                    var Sil = db.Uye.FirstOrDefault(p => p.UyeID == Al);
                    db.Uye.Remove(Sil);
                    db.SaveChanges();
                }
        }
    }
}

