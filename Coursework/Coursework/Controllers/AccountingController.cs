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

        public ActionResult Index1()
        {
            return PartialView("Index");
        }

        public ActionResult HouseProfit()
        {
            return View();
        }

        public ActionResult FoodProfit()
        {
            return View();
        }

        public ActionResult BaseProfit()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report([Bind(Include = "DateStart,DateEnd")] Date date)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index1");
            }
 
            return View(date);
        }
    }
}