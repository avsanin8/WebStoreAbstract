using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutesApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public string Index(string stringParam, int intParam)
        {
            return stringParam + " " + intParam;
        }
    }
}