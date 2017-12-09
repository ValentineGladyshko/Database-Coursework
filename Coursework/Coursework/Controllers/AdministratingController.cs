using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coursework.Models;
using System.Data.SqlClient;

namespace Coursework.Controllers
{
    public class AdministratingController : Controller
    {
        private int alpinist1;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAlpinist()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlpinist([Bind(Include = "AlpinistBaseID,FirstName,LastName,Phone,")] Alpinist alpinist)
        {
            if (ModelState.IsValid)
            {
                string queryString = "INSERT INTO [Alpinists] ([FirstName], [LastName], [Phone])" +
                    "VALUES" +
                    "	('" + alpinist.FirstName +
                    "', '" + alpinist.LastName + "', '" + alpinist.Phone + "')" +
                    "INSERT INTO [AlpinistsList] ([AlpinistID], [AlpinistBaseID])" +
                    "VALUES(" +
                    "	(" +
                    "	SELECT TOP(1) [AlpinistID]     " +
                    "	FROM [Coursework].[dbo].[Alpinists]" +
                    "	ORDER BY [AlpinistID] DESC" +
                    "	), " + alpinist.AlpinistBaseID + ")";
                SqlConnection connection = new SqlConnection(@"Data Source = VALENTINE\SQLEXPRESS;
                    Initial Catalog = Coursework; Integrated Security = True");
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return View(alpinist);
            }

            return View(alpinist);
        }

        public ActionResult CreateFoodOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodOrder([Bind(Include = "AlpinistID,FoodTypeID,Date")] FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                string queryString = "INSERT INTO [FoodOrders] ([AlpinistID], [FoodTypeID], [Date])" +
                    "VALUES" +
                    "	(" + foodOrder.AlpinistID + "," + foodOrder.FoodTypeID + 
                    ", '" + foodOrder.Date.ToString("yyyy-MM-dd") + "')";
                SqlConnection connection = new SqlConnection(@"Data Source = VALENTINE\SQLEXPRESS;
                    Initial Catalog = Coursework; Integrated Security = True");
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return View(foodOrder);
            }

            return View(foodOrder);
        }

        public ActionResult ChooseAlpinistHouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseAlpinistHouse(int alpinist)
        {
            alpinist1 = alpinist;
            return RedirectToAction("CreateHouseOrder");
        }

        public ActionResult CreateHouseOrder()
        {
            HouseOrder houseOrder = new HouseOrder();
            houseOrder.AlpinistID = alpinist1;
            return View();
        }

    }
}