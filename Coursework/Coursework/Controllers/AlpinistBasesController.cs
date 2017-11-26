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
    public class AlpinistBasesController : Controller
    {
        private Model db = new Model();

        // GET: AlpinistBases
        public ActionResult Index()
        {
            return View(db.AlpinistBases.ToList());
        }

        // GET: AlpinistBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistBases alpinistBases = db.AlpinistBases.Find(id);
            if (alpinistBases == null)
            {
                return HttpNotFound();
            }
            return View(alpinistBases);
        }

        // GET: AlpinistBases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlpinistBases/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlpinistBaseID,Country,Address")] AlpinistBases alpinistBases)
        {
            if (ModelState.IsValid)
            {
                db.AlpinistBases.Add(alpinistBases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alpinistBases);
        }

        // GET: AlpinistBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistBases alpinistBases = db.AlpinistBases.Find(id);
            if (alpinistBases == null)
            {
                return HttpNotFound();
            }
            return View(alpinistBases);
        }

        // POST: AlpinistBases/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlpinistBaseID,Country,Address")] AlpinistBases alpinistBases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alpinistBases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alpinistBases);
        }

        // GET: AlpinistBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlpinistBases alpinistBases = db.AlpinistBases.Find(id);
            if (alpinistBases == null)
            {
                return HttpNotFound();
            }
            return View(alpinistBases);
        }

        // POST: AlpinistBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlpinistBases alpinistBases = db.AlpinistBases.Find(id);
            db.AlpinistBases.Remove(alpinistBases);
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
