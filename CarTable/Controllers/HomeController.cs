using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTable.Models;

namespace CarTable.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCars()
        {
            using(CarDBEntities dc = new CarDBEntities())
            {
                var cars = dc.Cars.OrderBy(a => a.Brand).ToList();
                return Json(new { data = cars }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}