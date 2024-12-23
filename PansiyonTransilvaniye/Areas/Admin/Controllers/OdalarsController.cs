using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PansiyonTransilvaniye.DAL;
using PansiyonTransilvaniye.Models;

namespace PansiyonTransilvaniye.Areas.Admin.Controllers
{
    public class OdalarsController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/Odalars
        public ActionResult Index()
        {
            return View(db.odalar.ToList());
        }

        // GET: Admin/Odalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.odalar.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // GET: Admin/Odalars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Odalars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OdaUcreti,OdaAdi,OdaOzellikleri,OdaResimleri")] Odalar odalar, HttpPostedFileBase OdaResimi)
        {
            if (ModelState.IsValid && OdaResimi != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(OdaResimi.InputStream))
                {
                    imageData = binaryReader.ReadBytes(OdaResimi.ContentLength);
                }
                odalar.OdaResimleri = imageData;
                db.odalar.Add(odalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odalar);
        }

        // GET: Admin/Odalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.odalar.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // POST: Admin/Odalars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OdaUcreti,OdaAdi,OdaOzellikleri,OdaResimleri")] Odalar odalar,HttpPostedFileBase OdaResimi)
        {
            if (ModelState.IsValid)
            {
                
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(OdaResimi.InputStream))
                {
                    imageData = binaryReader.ReadBytes(OdaResimi.ContentLength);
                }
                odalar.OdaResimleri = imageData;
                db.Entry(odalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odalar);
        }

        // GET: Admin/Odalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.odalar.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // POST: Admin/Odalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odalar odalar = db.odalar.Find(id);
            db.odalar.Remove(odalar);
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
