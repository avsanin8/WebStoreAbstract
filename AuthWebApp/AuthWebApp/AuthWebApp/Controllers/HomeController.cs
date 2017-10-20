using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        { 
            string result = "You are not registered";
            if (User.Identity.IsAuthenticated)
            {
                result = "Your login: " + User.Identity.Name;
            }
            return result;
        }

        [Authorize(Roles ="admin")]
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