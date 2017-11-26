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
    public class HouseTypesController : Controller
    {
        private Model db = new Model();

        // GET: HouseTypes
        public ActionResult Index()
        {
            return View(db.HouseTypes.ToList());
        }

        // GET: HouseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTypes houseTypes = db.HouseTypes.Find(id);
            if (houseTypes == null)
            {
                return HttpNotFound();
            }
            return View(houseTypes);
        }

        // GET: HouseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseTypeID,Name,Price")] HouseTypes houseTypes)
        {
            if (ModelState.IsValid)
            {
                db.HouseTypes.Add(houseTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(houseTypes);
        }

        // GET: HouseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTypes houseTypes = db.HouseTypes.Find(id);
            if (houseTypes == null)
            {
                return HttpNotFound();
            }
            return View(houseTypes);
        }

        // POST: HouseTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseTypeID,Name,Price")] HouseTypes houseTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseTypes);
        }

        // GET: HouseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseTypes houseTypes = db.HouseTypes.Find(id);
            if (houseTypes == null)
            {
                return HttpNotFound();
            }
            return View(houseTypes);
        }

        // POST: HouseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseTypes houseTypes = db.HouseTypes.Find(id);
            db.HouseTypes.Remove(houseTypes);
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
