using ModelBinderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinderApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            Product p = new Product { Id = 2, Name = "Linza", Manfacture = "Opticus", Year = 1986 };
            return View(p);
        }

        [HttpPost]
        public string Edit(Product p)
        {
            return "Name: " + p.Name + " <br> Manufacture: " + p.Manfacture + " <br>Year" + p.Year;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(Product p)
        {
            return "Name: " + p.Name + " <br> Manufacture: " + p.Manfacture+ " <br>Year"+p.Year;
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