using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PansiyonTransilvaniye.Models;
using PansiyonTransilvaniye.DAL;
namespace PansiyonTransilvaniye.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Loged()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Models.KullaniciBilgileri kullaniciBilgileri)
        {
            using (PansiyonContext db = new PansiyonContext())
            {
                var kullanicidetay = db.kullaniciBilgileri.Where(x => x.KullaniciAd == kullaniciBilgileri.KullaniciAd && x.Sifre == kullaniciBilgileri.Sifre).FirstOrDefault();
                if(kullanicidetay!=null)
                {
                    Session["ID"] = kullanicidetay.Id;
                    return RedirectToAction("Index","IletisimBilgileris",new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı şifre veya İsim");
                    return View("Loged", kullaniciBilgileri);
                }
            }
        }
        public ActionResult cikis()
        {
            Session["Id"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}