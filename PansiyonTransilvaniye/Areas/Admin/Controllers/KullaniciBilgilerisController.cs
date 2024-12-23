using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PansiyonTransilvaniye.DAL;
using PansiyonTransilvaniye.Models;

namespace PansiyonTransilvaniye.Areas.Admin.Controllers
{
    public class KullaniciBilgilerisController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/KullaniciBilgileris
        public ActionResult Index()
        {
            return View(db.kullaniciBilgileri.ToList());
        }

       

        // GET: Admin/KullaniciBilgileris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KullaniciBilgileris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KullaniciAd,Sifre,Hakkimizda")] KullaniciBilgileri kullaniciBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.kullaniciBilgileri.Add(kullaniciBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullaniciBilgileri);
        }

        // GET: Admin/KullaniciBilgileris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciBilgileri kullaniciBilgileri = db.kullaniciBilgileri.Find(id);
            if (kullaniciBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciBilgileri);
        }

        // POST: Admin/KullaniciBilgileris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KullaniciAd,Sifre,Hakkimizda")] KullaniciBilgileri kullaniciBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullaniciBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullaniciBilgileri);
        }
        // GET: Admin/KullaniciBilgileris/Edit/5
       

        // GET: Admin/KullaniciBilgileris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciBilgileri kullaniciBilgileri = db.kullaniciBilgileri.Find(id);
            if (kullaniciBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciBilgileri);
        }

        // POST: Admin/KullaniciBilgileris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KullaniciBilgileri kullaniciBilgileri = db.kullaniciBilgileri.Find(id);
            db.kullaniciBilgileri.Remove(kullaniciBilgileri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
