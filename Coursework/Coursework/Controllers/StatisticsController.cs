using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursework.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
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
    }
}