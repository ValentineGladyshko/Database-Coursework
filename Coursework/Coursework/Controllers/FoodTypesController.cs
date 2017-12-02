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
    public class FoodTypesController : Controller
    {
        private Model db = new Model();

        // GET: FoodTypes
        public ActionResult Index()
        {
            return View(db.FoodTypes.ToList());
        }

        // GET: FoodTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodTypes foodTypes = db.FoodTypes.Find(id);
            if (foodTypes == null)
            {
                return HttpNotFound();
            }
            return View(foodTypes);
        }

        // GET: FoodTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodTypeID,Name,Price")] FoodTypes foodTypes)
        {
            if (ModelState.IsValid)
            {
                db.FoodTypes.Add(foodTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodTypes);
        }

        // GET: FoodTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodTypes foodTypes = db.FoodTypes.Find(id);
            if (foodTypes == null)
            {
                return HttpNotFound();
            }
            return View(foodTypes);
        }

        // POST: FoodTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodTypeID,Name,Price")] FoodTypes foodTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodTypes);
        }

        // GET: FoodTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodTypes foodTypes = db.FoodTypes.Find(id);
            if (foodTypes == null)
            {
                return HttpNotFound();
            }
            return View(foodTypes);
        }

        // POST: FoodTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodTypes foodTypes = db.FoodTypes.Find(id);
            db.FoodTypes.Remove(foodTypes);
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
