using IdentetyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


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

        [Authorize]
        public ActionResult GetMyRoles()
        {
            IList<string> roles = new List<string> { "Role not found" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user!=null)
            {
                roles = userManager.GetRoles(user.Id);
            }
            return View(roles);
        }

        [Authorize(Roles = "admin")] // only for admin
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