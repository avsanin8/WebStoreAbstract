using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CheckName(string name)
        {
            var result = !(name == "Название");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product.Manufacture == "Guness" && product.Year > 1910)
            {
                ModelState.AddModelError("", "The year must be more than 1910");
            }
            //if (product.Year == 1980)
            //{
            //    ModelState.AddModelError("Year", "Error Incorrect year");
            //}
            //if (product.Name.Length > 5)
            //{
            //    ModelState.AddModelError("Name", "Incorrect length chars");
            //}
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}