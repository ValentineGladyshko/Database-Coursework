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
    public class HouseOrdersController : Controller
    {
        private Model db = new Model();

        // GET: HouseOrders
        public ActionResult Index()
        {
            var houseOrders = db.HouseOrders.Include(h => h.Alpinists).Include(h => h.Houses);
            return View(houseOrders.ToList());
        }

        // GET: HouseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseOrders houseOrders = db.HouseOrders.Find(id);
            if (houseOrders == null)
            {
                return HttpNotFound();
            }
            return View(houseOrders);
        }

        // GET: HouseOrders/Create
        public ActionResult Create()
        {
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName");
            ViewBag.HouseID = new SelectList(db.Houses, "HouseID", "Name");
            return View();
        }

        // POST: HouseOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseOrderID,AlpinistID,HouseID,DateStart,DateEnd")] HouseOrders houseOrders)
        {
            if (ModelState.IsValid)
            {
                db.HouseOrders.Add(houseOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", houseOrders.AlpinistID);
            ViewBag.HouseID = new SelectList(db.Houses, "HouseID", "Name", houseOrders.HouseID);
            return View(houseOrders);
        }

        // GET: HouseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseOrders houseOrders = db.HouseOrders.Find(id);
            if (houseOrders == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", houseOrders.AlpinistID);
            ViewBag.HouseID = new SelectList(db.Houses, "HouseID", "Name", houseOrders.HouseID);
            return View(houseOrders);
        }

        // POST: HouseOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseOrderID,AlpinistID,HouseID,DateStart,DateEnd")] HouseOrders houseOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", houseOrders.AlpinistID);
            ViewBag.HouseID = new SelectList(db.Houses, "HouseID", "Name", houseOrders.HouseID);
            return View(houseOrders);
        }

        // GET: HouseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseOrders houseOrders = db.HouseOrders.Find(id);
            if (houseOrders == null)
            {
                return HttpNotFound();
            }
            return View(houseOrders);
        }

        // POST: HouseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseOrders houseOrders = db.HouseOrders.Find(id);
            db.HouseOrders.Remove(houseOrders);
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
