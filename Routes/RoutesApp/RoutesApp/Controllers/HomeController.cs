using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutesApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id=1, string name="")
        {
            return View();
        }
        public string GetController()
        {
            string controller = RouteData.Values["controller"].ToString();
            return controller;
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