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
    public class RouteStatesController : Controller
    {
        private Model db = new Model();

        // GET: RouteStates
        public ActionResult Index()
        {
            var routeStates = db.RouteStates.Include(r => r.Routes);
            return View(routeStates.ToList());
        }

        // GET: RouteStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteStates routeStates = db.RouteStates.Find(id);
            if (routeStates == null)
            {
                return HttpNotFound();
            }
            return View(routeStates);
        }

        // GET: RouteStates/Create
        public ActionResult Create()
        {
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name");
            return View();
        }

        // POST: RouteStates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteStateID,State,RouteID,DateEnd")] RouteStates routeStates)
        {
            if (ModelState.IsValid)
            {
                db.RouteStates.Add(routeStates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", routeStates.RouteID);
            return View(routeStates);
        }

        // GET: RouteStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteStates routeStates = db.RouteStates.Find(id);
            if (routeStates == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", routeStates.RouteID);
            return View(routeStates);
        }

        // POST: RouteStates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteStateID,State,RouteID,DateEnd")] RouteStates routeStates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeStates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "Name", routeStates.RouteID);
            return View(routeStates);
        }

        // GET: RouteStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteStates routeStates = db.RouteStates.Find(id);
            if (routeStates == null)
            {
                return HttpNotFound();
            }
            return View(routeStates);
        }

        // POST: RouteStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteStates routeStates = db.RouteStates.Find(id);
            db.RouteStates.Remove(routeStates);
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
