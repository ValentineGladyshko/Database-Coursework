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
    public class FoodOrdersController : Controller
    {
        private Model db = new Model();

        // GET: FoodOrders
        public ActionResult Index()
        {
            var foodOrders = db.FoodOrders.Include(f => f.Alpinists).Include(f => f.FoodTypes);
            return View(foodOrders.ToList());
        }

        // GET: FoodOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrders foodOrders = db.FoodOrders.Find(id);
            if (foodOrders == null)
            {
                return HttpNotFound();
            }
            return View(foodOrders);
        }

        // GET: FoodOrders/Create
        public ActionResult Create()
        {
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName");
            ViewBag.FoodTypeID = new SelectList(db.FoodTypes, "FoodTypeID", "Name");
            return View();
        }

        // POST: FoodOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodOrderID,AlpinistID,FoodTypeID,Date")] FoodOrders foodOrders)
        {
            if (ModelState.IsValid)
            {
                db.FoodOrders.Add(foodOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", foodOrders.AlpinistID);
            ViewBag.FoodTypeID = new SelectList(db.FoodTypes, "FoodTypeID", "Name", foodOrders.FoodTypeID);
            return View(foodOrders);
        }

        // GET: FoodOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrders foodOrders = db.FoodOrders.Find(id);
            if (foodOrders == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", foodOrders.AlpinistID);
            ViewBag.FoodTypeID = new SelectList(db.FoodTypes, "FoodTypeID", "Name", foodOrders.FoodTypeID);
            return View(foodOrders);
        }

        // POST: FoodOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodOrderID,AlpinistID,FoodTypeID,Date")] FoodOrders foodOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlpinistID = new SelectList(db.Alpinists, "AlpinistID", "FirstName", foodOrders.AlpinistID);
            ViewBag.FoodTypeID = new SelectList(db.FoodTypes, "FoodTypeID", "Name", foodOrders.FoodTypeID);
            return View(foodOrders);
        }

        // GET: FoodOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrders foodOrders = db.FoodOrders.Find(id);
            if (foodOrders == null)
            {
                return HttpNotFound();
            }
            return View(foodOrders);
        }

        // POST: FoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodOrders foodOrders = db.FoodOrders.Find(id);
            db.FoodOrders.Remove(foodOrders);
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
