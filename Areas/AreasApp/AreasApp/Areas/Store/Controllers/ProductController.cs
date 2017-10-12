using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasApp.Areas.Store.Controllers
{
    public class ProductController : Controller
    {
        // GET: Store/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}