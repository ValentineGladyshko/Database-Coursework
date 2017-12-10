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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return PartialView();
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
        public RedirectToRouteResult ChooseAlpinistHouse(MyInt myInt)
        {
            FoodOrder houseOrder = new FoodOrder();
            houseOrder.AlpinistID = myInt.ID;
            return RedirectToAction("CreateHouseOrder", houseOrder);
        }

        public ActionResult CreateHouseOrder(FoodOrder houseOrder)
        {
            HouseOrder houseOrder1 = new HouseOrder();
            houseOrder1.AlpinistID = houseOrder.AlpinistID;
            return View(houseOrder1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHouseOrder([Bind(Include = "AlpinistID,HouseID,DateStart,DateEnd")] HouseOrder houseOrder)
        {
            if (ModelState.IsValid)
            {
                string queryString = "INSERT INTO [HouseOrders] ([AlpinistID], [HouseID], [DateStart], [DateEnd])" +
                    "VALUES" +
                    "	(" + houseOrder.AlpinistID + "," + houseOrder.HouseID +
                    ", '" + houseOrder.DateStart.ToString("yyyy-MM-dd") + "', '" + houseOrder.DateEnd.ToString("yyyy-MM-dd") + "')";
                SqlConnection connection = new SqlConnection(@"Data Source = VALENTINE\SQLEXPRESS;
                    Initial Catalog = Coursework; Integrated Security = True");
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return View(houseOrder);
            }

            return View(houseOrder);
        }

        public ActionResult ChooseAlpinistWalk()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult ChooseAlpinistWalk(MyInt myInt)
        {
            FoodOrder walk = new FoodOrder();
            walk.AlpinistID = myInt.ID;
            return RedirectToAction("CreateWalk", walk);
        }

        public ActionResult CreateWalk(FoodOrder walk)
        {
            Walk walk1 = new Walk();
            walk1.AlpinistID = walk.AlpinistID;
            return View(walk1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWalk([Bind(Include = "AlpinistID,RouteID,DateStart,DateEnd")] Walk walk)
        {
            if (ModelState.IsValid)
            {
                string queryString = "INSERT INTO [Walks] ([AlpinistID], [RouteID], [DateStart], [DateEnd])" +
                    "VALUES" +
                    "	(" + walk.AlpinistID + "," + walk.RouteID +
                    ", '" + walk.DateStart.ToString("yyyy-MM-dd") + "', '" + walk.DateEnd.ToString("yyyy-MM-dd") + "')";
                SqlConnection connection = new SqlConnection(@"Data Source = VALENTINE\SQLEXPRESS;
                    Initial Catalog = Coursework; Integrated Security = True");
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return View(walk);
            }

            return View(walk);
        }
    }
}