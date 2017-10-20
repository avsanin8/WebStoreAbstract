using IdentetyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentetyApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Users.ToList();
            }
            return View(users);
        }

        public string GetProduct()
        {
            Product p = new Product { Name = "Model X", Manufacture = "Tesla" };
            Product firstProduct = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Products.Add(p);
                db.SaveChanges();
                firstProduct = db.Products.FirstOrDefault();
            }
            if (firstProduct == null)
                return "unknown";
            return firstProduct.Name + " (" + firstProduct.Manufacture + ")";
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