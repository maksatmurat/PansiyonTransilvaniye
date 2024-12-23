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
    public class GalerisController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/Galeris
        public ActionResult Index()
        {
            return View(db.galeri.ToList());
        }

      
        // GET: Admin/Galeris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Galeris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GaleriResimler")] Galeri galeri, HttpPostedFileBase Galeriler)
        {
            if (ModelState.IsValid && Galeriler != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(Galeriler.InputStream))
                {
                    imageData = binaryReader.ReadBytes(Galeriler.ContentLength);
                }
                galeri.GaleriResimler = imageData;
                db.galeri.Add(galeri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galeri);
        }

       
        // GET: Admin/Galeris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeri galeri = db.galeri.Find(id);
            if (galeri == null)
            {
                return HttpNotFound();
            }
            return View(galeri);
        }

        // POST: Admin/Galeris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galeri galeri = db.galeri.Find(id);
            db.galeri.Remove(galeri);
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
