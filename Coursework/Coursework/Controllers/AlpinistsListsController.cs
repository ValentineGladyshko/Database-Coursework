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
    public class AlpinistsListsController : Controller
    {
        private Model db = new Model();

        // GET: AlpinistsLists
        public ActionResult Index()
        {
            var alpinistsList = db.AlpinistsList.Include(a => a.AlpinistBases).Include(a => a.Alpinists);
            return View(alpinistsList.ToList());
        }

        // GET: AlpinistsLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistsList alpinistsList = db.AlpinistsList.Find(id);
            if (alpinistsList == null)
            {
                return HttpNotFound();
            }
            return View(alpinistsList);
        }

        // GET: AlpinistsLists/Create
        public ActionResult Create()
        {
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country");
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName");
            return View();
        }

        // POST: AlpinistsLists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlpinistsListID,AlpinistID,AlpinistBaseID")] AlpinistsList alpinistsList)
        {
            if (ModelState.IsValid)
            {
                db.AlpinistsList.Add(alpinistsList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", alpinistsList.AlpinistBaseID);
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", alpinistsList.AlpinistID);
            return View(alpinistsList);
        }

        // GET: AlpinistsLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistsList alpinistsList = db.AlpinistsList.Find(id);
            if (alpinistsList == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", alpinistsList.AlpinistBaseID);
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", alpinistsList.AlpinistID);
            return View(alpinistsList);
        }

        // POST: AlpinistsLists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlpinistsListID,AlpinistID,AlpinistBaseID")] AlpinistsList alpinistsList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alpinistsList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", alpinistsList.AlpinistBaseID);
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", alpinistsList.AlpinistID);
            return View(alpinistsList);
        }

        // GET: AlpinistsLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistsList alpinistsList = db.AlpinistsList.Find(id);
            if (alpinistsList == null)
            {
                return HttpNotFound();
            }
            return View(alpinistsList);
        }

        // POST: AlpinistsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlpinistsList alpinistsList = db.AlpinistsList.Find(id);
            db.AlpinistsList.Remove(alpinistsList);
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
