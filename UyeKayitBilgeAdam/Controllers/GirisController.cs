using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UyeKayitBilgeAdam.DAL.Repos;
using UyeKayitBilgeAdam.DAL.VM;

namespace UyeKayitBilgeAdam.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(VMUye al)
        {
            if(UyeRepo.Giris(al)==true)
            {
                Session["Admin"] = Convert.ToString("true");
                return RedirectToAction("AnaSayfa");
            }
            else
            {
                return RedirectToAction("AnaSayfa");
            }
        }

        public ActionResult AnaSayfa()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Secret= "/Source/Code.rar";
                var listele = UyeRepo.HepsiniListele();
                ViewBag.UyeTipi = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = true;
                ViewBag.Uyari = true;
                return View(listele);

            }
            else
            {
                ViewBag.Secret = "";
                var listele = UyeRepo.HepsiniListele();
                ViewBag.UyeTipi = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = false;
                ViewBag.Uyari = true;
                return View(listele);
            }
        }

        [HttpPost]
        public ActionResult AnaSayfa(VMUye Al)
        {
            if (Session["Admin"] != null)
            {
                if (Al.Gorev == "Degistir")
                {
                    bool al= UyeRepo.UyeGuncelle(Al);
                    if (al == true)
                    {
                        ViewBag.UyariTipi = "alert alert-success";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Başarıyla Değiştirildi";
                    }
                    else
                    {
                        ViewBag.UyariTipi = "alert alert-warning";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Değiştirelemedi";
                    }
                }
                else if (Al.Gorev == "Sil")
                {
                    UyeRepo.Sil(Al.UyeID);

                }
                else if (Al.Gorev == "Ekle")
                {
                    bool al = UyeRepo.UyeKaydet(Al);
                    if (al == true)
                    {
                        ViewBag.UyariTipi = "alert alert-success";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Başarıyla Kaydedildi";
                    }
                    else
                    {
                        ViewBag.UyariTipi = "alert alert-warning";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Zaten Var";
                    }
                }
                ViewBag.Secret = "/Source/Code.rar";
                var listele = UyeRepo.HepsiniListele();
                ViewBag.UyeTipi = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = true;
                return View(listele);
            }
            else
            {
                if (Al.Gorev == "Degistir")
                {
                    bool al = UyeRepo.UyeGuncelle(Al);
                    if (al == true)
                    {
                        ViewBag.UyariTipi = "alert alert-success";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Başarıyla Değiştirildi";
                    }
                    else
                    {
                        ViewBag.UyariTipi = "alert alert-warning";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Değiştirelemedi";
                    }
                }
                else if (Al.Gorev == "Sil")
                {
                     UyeRepo.Sil(Al.UyeID);
                }
                else if (Al.Gorev == "Ekle")
                {
                    bool al = UyeRepo.UyeKaydet(Al);
                    if (al == true)
                    {
                        ViewBag.UyariTipi = "alert alert-success";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Başarıyla Kaydedildi";
                    }
                    else
                    {
                        ViewBag.UyariTipi = "alert alert-warning";
                        ViewBag.Uyari = false;
                        ViewBag.Sonuc = "Uye Zaten Var";
                    }
                }
                ViewBag.Secret = "";
                var listele = UyeRepo.HepsiniListele();
                ViewBag.UyeTipi = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = false;
                return View(listele);
            }
        }

        public ActionResult UyeTipi()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.Secret = "/Source/Code.rar";
                var listele = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = true;
                return View(listele);
            }
            else
            {
                ViewBag.Secret = "";
                var listele = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = false;
                return View(listele);
            }
        }

        [HttpPost]
        public ActionResult UyeTipi(VMUyeTipi Al)
        {
            if (Session["Admin"] != null)
            {
                if (Al.Gorev == "Degistir")
                {
                    UyeTipiRepo.UyeTipiGuncelle(Al);
                }
                else if (Al.Gorev == "Sil")
                {
                    UyeTipiRepo.Sil(Al.UyeTipiID);
                }
                else if (Al.Gorev == "Ekle")
                {
                    UyeTipiRepo.UyeTipiKaydet(Al);
                }
                ViewBag.Secret = "/Source/Code.rar";
                var listele = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = true;
                return View(listele);
            }
            else
            {
                if (Al.Gorev == "Degistir")
                {
                    UyeTipiRepo.UyeTipiGuncelle(Al);
                }
                else if (Al.Gorev == "Sil")
                {
                    UyeTipiRepo.Sil(Al.UyeTipiID);
                }
                else if (Al.Gorev == "Ekle")
                {
                    UyeTipiRepo.UyeTipiKaydet(Al);
                }
                ViewBag.Secret = "";
                var listele = UyeTipiRepo.HepsiniListele();
                ViewBag.Admin = false;
                return View(listele);
            }
        }

        public ActionResult OturumKapat()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}