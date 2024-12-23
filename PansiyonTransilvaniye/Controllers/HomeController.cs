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
    public class HomeController : Controller
    {
        PansiyonContext db = new PansiyonContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AnaSayfaArkaFon()
        {
            return PartialView("AnaSayfaArkaFon", db.anaSayfaResimler.ToList());
        }
        public ActionResult AnaSayfaOdaFon()
        {
            return PartialView("AnaSayfaOdaFon", db.odalar.ToList());
        }
        public ActionResult AnaSayfaHakkimizda()
        {
            return PartialView("AnaSayfaHakkimizda",db.kullaniciBilgileri.ToList());
        }
        public ActionResult AnaSayfaAdresBilgiler()
        {
            return PartialView("AnaSayfaAdresBilgiler", db.iletisimBilgileri.ToList());
        }
        public ActionResult AnaSayfaTelNo()
        {
            return PartialView("AnaSayfaTelNo",db.iletisimBilgileri.ToList());
        }
        public ActionResult Hakkimizda()
        {
            return View(db.kullaniciBilgileri.ToList());
        }
        public ActionResult Iletisim()
        {
            return View(db.iletisimBilgileri.ToList());
        }
        public ActionResult Feedback(ModelFeedback model)
        {
            try
            {
                model.Text = ModelEmailFeedback.GetHtmlText(model);
                Emailer.Send(model.Text);
                TempData["msg"] = "<script>alert('Mesajınız İletildi');</script>";
            }
            catch (Exception)
            {
                TempData["msg"] = "<script>alert('Mesajınız Iletilemedi');</script>";
            }
            return RedirectToAction("Iletisim", "Home");
        }
        public ActionResult Galeri()
        {
            return View(db.galeri.ToList());
        }
        public ActionResult AnaSayfaServislerAdi()
        {
            return PartialView(db.services.ToList());
        }
    }
}