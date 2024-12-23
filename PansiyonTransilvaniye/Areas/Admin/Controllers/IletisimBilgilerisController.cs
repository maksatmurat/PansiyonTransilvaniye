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
    public class IletisimBilgilerisController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/IletisimBilgileris
        public ActionResult Index()
        {
            return View(db.iletisimBilgileri.ToList());
        }

        // GET: Admin/IletisimBilgileris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IletisimBilgileri iletisimBilgileri = db.iletisimBilgileri.Find(id);
            if (iletisimBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(iletisimBilgileri);
        }

        // GET: Admin/IletisimBilgileris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/IletisimBilgileris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,telNo,Email,Il,Ilce,Mah,AcikAdres")] IletisimBilgileri iletisimBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.iletisimBilgileri.Add(iletisimBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iletisimBilgileri);
        }

        // GET: Admin/IletisimBilgileris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IletisimBilgileri iletisimBilgileri = db.iletisimBilgileri.Find(id);
            if (iletisimBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(iletisimBilgileri);
        }

        // POST: Admin/IletisimBilgileris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,telNo,Email,Il,Ilce,Mah,AcikAdres")] IletisimBilgileri iletisimBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iletisimBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iletisimBilgileri);
        }

        // GET: Admin/IletisimBilgileris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IletisimBilgileri iletisimBilgileri = db.iletisimBilgileri.Find(id);
            if (iletisimBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(iletisimBilgileri);
        }

        // POST: Admin/IletisimBilgileris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IletisimBilgileri iletisimBilgileri = db.iletisimBilgileri.Find(id);
            db.iletisimBilgileri.Remove(iletisimBilgileri);
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
