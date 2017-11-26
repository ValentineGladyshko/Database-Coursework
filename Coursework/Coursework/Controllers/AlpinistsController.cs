using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coursework.Models;

namespace Coursework.Controllers
{
    public class AlpinistsController : Controller
    {
        private Model db = new Model();

        // GET: Alpinists
        public ActionResult Index()
        {
            return View(db.Alpinists.ToList());
        }

        // GET: Alpinists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alpinists alpinists = db.Alpinists.Find(id);
            if (alpinists == null)
            {
                return HttpNotFound();
            }
            return View(alpinists);
        }

        // GET: Alpinists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alpinists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlpinistID,FirstName,LastName,Phone")] Alpinists alpinists)
        {
            if (ModelState.IsValid)
            {
                db.Alpinists.Add(alpinists);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alpinists);
        }

        // GET: Alpinists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alpinists alpinists = db.Alpinists.Find(id);
            if (alpinists == null)
            {
                return HttpNotFound();
            }
            return View(alpinists);
        }

        // POST: Alpinists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlpinistID,FirstName,LastName,Phone")] Alpinists alpinists)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alpinists).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alpinists);
        }

        // GET: Alpinists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alpinists alpinists = db.Alpinists.Find(id);
            if (alpinists == null)
            {
                return HttpNotFound();
            }
            return View(alpinists);
        }

        // POST: Alpinists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alpinists alpinists = db.Alpinists.Find(id);
            db.Alpinists.Remove(alpinists);
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
