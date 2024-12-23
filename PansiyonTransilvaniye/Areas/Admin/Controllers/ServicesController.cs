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
    public class ServicesController : Controller
    {
        private PansiyonContext db = new PansiyonContext();

        // GET: Admin/Services
        public ActionResult Index()
        {
            return View(db.services.ToList());
        }

        // GET: Admin/Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // GET: Admin/Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServiceAdi,ServiceOzellik")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(services);
        }

        // GET: Admin/Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceAdi,ServiceOzellik")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(services);
        }

        // GET: Admin/Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services services = db.services.Find(id);
            db.services.Remove(services);
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
