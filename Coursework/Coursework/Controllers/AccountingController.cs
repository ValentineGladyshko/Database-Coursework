using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Coursework.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Report1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report1([Bind(Include = "DateStart,DateEnd")] Date date)
        {
            if (ModelState.IsValid)
            {
                return View(date);
            }

            return View(date);
        }

        public ActionResult Report2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report2([Bind(Include = "DateStart,DateEnd")] Date date)
        {
            if (ModelState.IsValid)
            {
                return View(date);
            }

            return View(date);
        }

        public ActionResult Report3()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report3([Bind(Include = "DateStart,DateEnd")] Date date)
        {
            if (ModelState.IsValid)
            {
                return View(date);
            }

            return View(date);
        }
    }
}