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
    public class WalksController : Controller
    {
        private Model db = new Model();

        // GET: Walks
        public ActionResult Index()
        {
            var walks = db.Walks.Include(w => w.Alpinists).Include(w => w.Routes);
            return View(walks.ToList());
        }

        // GET: Walks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walks walks = db.Walks.Find(id);
            if (walks == null)
            {
                return HttpNotFound();
            }
            return View(walks);
        }

        // GET: Walks/Create
        public ActionResult Create()
        {
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName");
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name");
            return View();
        }

        // POST: Walks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WalkID,AlpinistID,RouteID,DateStart,DateEnd")] Walks walks)
        {
            if (ModelState.IsValid)
            {
                db.Walks.Add(walks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", walks.AlpinistID);
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", walks.RouteID);
            return View(walks);
        }

        // GET: Walks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walks walks = db.Walks.Find(id);
            if (walks == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", walks.AlpinistID);
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", walks.RouteID);
            return View(walks);
        }

        // POST: Walks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WalkID,AlpinistID,RouteID,DateStart,DateEnd")] Walks walks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", walks.AlpinistID);
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", walks.RouteID);
            return View(walks);
        }

        // GET: Walks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walks walks = db.Walks.Find(id);
            if (walks == null)
            {
                return HttpNotFound();
            }
            return View(walks);
        }

        // POST: Walks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Walks walks = db.Walks.Find(id);
            db.Walks.Remove(walks);
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
