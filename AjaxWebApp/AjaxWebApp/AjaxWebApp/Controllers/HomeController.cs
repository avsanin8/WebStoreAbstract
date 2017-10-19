using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxWebApp.Models;

namespace AjaxWebApp.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductSearch(string name)
        {
            var allProducts = db.Products.Where(a => a.Manufacture.Contains(name)).ToList();
            return PartialView(allProducts);
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