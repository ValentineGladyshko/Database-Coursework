using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursework.Controllers
{
    public class RescueServiceController : Controller
    {
        public ActionResult Information()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RouteState RouteState)
        {
            if (ModelState.IsValid)
            {
                return View(RouteState);
            }

            return View(RouteState);
        }
    }
}