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
    public class AnaSayfaResimlersController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/AnaSayfaResimlers
        public ActionResult Index()
        {
            return View(db.anaSayfaResimler.ToList());
        }

       
        // GET: Admin/AnaSayfaResimlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AnaSayfaResimlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnaSayfaResimleri")] AnaSayfaResimler anaSayfaResimler, HttpPostedFileBase AnaSayfa)
        {
            if (ModelState.IsValid && AnaSayfa!=null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(AnaSayfa.InputStream))
                {
                    imageData = binaryReader.ReadBytes(AnaSayfa.ContentLength);
                }
                anaSayfaResimler.AnaSayfaResimleri = imageData;
                db.anaSayfaResimler.Add(anaSayfaResimler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anaSayfaResimler);
        }

       
        // GET: Admin/AnaSayfaResimlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaSayfaResimler anaSayfaResimler = db.anaSayfaResimler.Find(id);
            if (anaSayfaResimler == null)
            {
                return HttpNotFound();
            }
            return View(anaSayfaResimler);
        }

        // POST: Admin/AnaSayfaResimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnaSayfaResimler anaSayfaResimler = db.anaSayfaResimler.Find(id);
            db.anaSayfaResimler.Remove(anaSayfaResimler);
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
