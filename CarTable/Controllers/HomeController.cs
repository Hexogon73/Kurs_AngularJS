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

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (CarDBEntities dc = new CarDBEntities())
            {
                var v = dc.Cars.Where(a => a.CarID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Car car)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using(CarDBEntities dc = new CarDBEntities())
                {
                    if (car.CarID > 0)
                    {
                        //edit
                        var v = dc.Cars.Where(a => a.CarID == car.CarID).FirstOrDefault();
                        if (v != null)
                        {
                            v.Brand = car.Brand;
                            v.Model = car.Model;
                            v.Number = car.Model;
                            v.Registration_date = car.Registration_date;
                            v.Owner = car.Owner;
                            v.Registration_place = car.Registration_place;
                        }
                    }
                    else
                    {
                        //save
                        dc.Cars.Add(car);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (CarDBEntities dc = new CarDBEntities())
            {
                var v = dc.Cars.Where(a => a.CarID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCars(int id)
        {
            bool status = false;
            using (CarDBEntities dc = new CarDBEntities())
            {
                var v = dc.Cars.Where(a => a.CarID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Cars.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult {Data = new { status = status} };
        }
    }
}