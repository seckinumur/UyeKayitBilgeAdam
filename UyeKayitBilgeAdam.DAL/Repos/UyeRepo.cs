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
                    UyeTipi = P.UyeTipi.Tipi,
                    Admin = P.Admin,
                    Sifre = P.Sifre
                }).ToList();
                return a;
            }
        }
        public static bool UyeKaydet(VMUye Al) //Kaydet
        {
            if (Al.UyeAdi != null && Al.Sifre != null && Al.UyeTipi != null)
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

                            if (Al.UyeTipi == "Başkan" || Al.UyeTipi == "Sekreter")
                            {
                                Al.Admin = true;
                            }
                            db.Uye.Add(new Uye()
                            {
                                Email = Al.Email,
                                Telefon = Al.Telefon,
                                UyeAdi = Al.UyeAdi,
                                UyeSoyadi = Al.UyeSoyadi,
                                UyeTipiID = simdibuluyetipi.UyeTipiID,
                                Admin = Al.Admin,
                                Sifre = Al.Sifre
                            });
                            db.SaveChanges();
                        }
                        else
                        {
                            if (Al.UyeTipi == "Başkan" || Al.UyeTipi == "Sekreter")
                            {
                                Al.Admin = true;
                            }
                            var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                            db.Uye.Add(new Uye()
                            {
                                Email = Al.Email,
                                Telefon = Al.Telefon,
                                UyeAdi = Al.UyeAdi,
                                UyeSoyadi = Al.UyeSoyadi,
                                UyeTipiID = simdibuluyetipi.UyeTipiID,
                                Admin = Al.Admin,
                                Sifre = Al.Sifre
                            });
                            db.SaveChanges();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public static bool UyeGuncelle(VMUye Al) //Guncelle
        {
            if (Al.UyeAdi != null && Al.Sifre != null && Al.UyeTipi != null)
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
                            if (Al.UyeTipi == "Başkan" || Al.UyeTipi == "Sekreter")
                            {
                                Al.Admin = true;
                            }
                            var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                            var guncelle = db.Uye.FirstOrDefault(p => p.UyeID == Al.UyeID);

                            guncelle.Email = Al.Email;
                            guncelle.Telefon = Al.Telefon;
                            guncelle.UyeAdi = Al.UyeAdi;
                            guncelle.UyeSoyadi = Al.UyeSoyadi;
                            guncelle.UyeTipiID = simdibuluyetipi.UyeTipiID;
                            guncelle.Admin = Al.Admin;
                            guncelle.Sifre = Al.Sifre;
                            db.SaveChanges();
                        }
                        else
                        {
                            if (Al.UyeTipi == "Başkan" || Al.UyeTipi == "Sekreter")
                            {
                                Al.Admin = true;
                            }
                            var simdibuluyetipi = db.UyeTipi.FirstOrDefault(p => p.Tipi == Al.UyeTipi);
                            var guncelle = db.Uye.FirstOrDefault(p => p.UyeID == Al.UyeID);

                            guncelle.Email = Al.Email;
                            guncelle.Telefon = Al.Telefon;
                            guncelle.UyeAdi = Al.UyeAdi;
                            guncelle.UyeSoyadi = Al.UyeSoyadi;
                            guncelle.UyeTipiID = simdibuluyetipi.UyeTipiID;
                            guncelle.Sifre = Al.Sifre;

                            db.SaveChanges();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public static void Sil(long Al) //Sil
        {
            using (UyeDB db = new UyeDB())
            {
                var Sil = db.Uye.FirstOrDefault(p => p.UyeID == Al);
                db.Uye.Remove(Sil);
                db.SaveChanges();
            }
        }
        public static bool Giris(VMUye Al) //Giris
        {
            using (UyeDB db = new UyeDB())
            {
                try
                {
                    var varmi = db.Uye.FirstOrDefault(p => p.UyeAdi == Al.UyeAdi && p.Sifre == Al.Sifre);
                    return varmi.Admin;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

