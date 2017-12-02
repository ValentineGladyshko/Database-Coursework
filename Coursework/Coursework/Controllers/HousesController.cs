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
    public class HousesController : Controller
    {
        private Model db = new Model();

        // GET: Houses
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.AlpinistBases).Include(h => h.HouseTypes);
            return View(houses.ToList());
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Houses houses = db.Houses.Find(id);
            if (houses == null)
            {
                return HttpNotFound();
            }
            return View(houses);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country");
            ViewBag.HouseTypeID = new SelectList(db.HouseTypes, "HouseTypeID", "Name");
            return View();
        }

        // POST: Houses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseID,Name,HouseTypeID,AlpinistBaseID")] Houses houses)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(houses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", houses.AlpinistBaseID);
            ViewBag.HouseTypeID = new SelectList(db.HouseTypes, "HouseTypeID", "Name", houses.HouseTypeID);
            return View(houses);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Houses houses = db.Houses.Find(id);
            if (houses == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", houses.AlpinistBaseID);
            ViewBag.HouseTypeID = new SelectList(db.HouseTypes, "HouseTypeID", "Name", houses.HouseTypeID);
            return View(houses);
        }

        // POST: Houses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseID,Name,HouseTypeID,AlpinistBaseID")] Houses houses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlpinistBaseID = new SelectList(db.AlpinistBases, "AlpinistBaseID", "Country", houses.AlpinistBaseID);
            ViewBag.HouseTypeID = new SelectList(db.HouseTypes, "HouseTypeID", "Name", houses.HouseTypeID);
            return View(houses);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Houses houses = db.Houses.Find(id);
            if (houses == null)
            {
                return HttpNotFound();
            }
            return View(houses);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Houses houses = db.Houses.Find(id);
            db.Houses.Remove(houses);
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
