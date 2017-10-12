using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasApp.Areas.Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Store/Home
        [Route("My/Account")] 
        public ActionResult Index() // Home/Index and My/Account (if exist [Route("My/Account")]) 
        {
            return View();
        }
    }
}