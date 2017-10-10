using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Util;
using System.Data.Entity;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();
        TeamUserContext dbUser = new TeamUserContext();

        public ActionResult Index()
        {
            Session["name"] = "Andrew";
            HttpContext.Response.Cookies["id"].Value = "ca-4353w";
            var products = db.Products.ToList();
            ViewBag.Products = products;

            SelectList manufacture = new SelectList(db.Products, "Manufacture", "Name");
            ViewBag.Manufactures = manufacture;

            var users = dbUser.Users.Include(path => path.Team);

            return View(users.ToList());
        }

        public ActionResult GetManufacturer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetManufacturer(Manufacture manufacture)
        {
            return View();
        }

        public ActionResult EditArray()
        {
            List<Products> products = new List<Products>();
            products.Add(new Products { Name = "Ifone615", Manufacture = "Apple", Price = 56 });
            products.Add(new Products { Name = "Kamera16px", Manufacture = "Google", Price = 48 });
            products.Add(new Products { Name = "NanoRobot", Manufacture = "3DMedical", Price = 542 });
            return View(products);
        }

        [HttpPost]
        public string EditArray(List<Products> products)
        {
            return products.Count.ToString();
        }

        public ActionResult Array()
        {
            return View();
        }

        [HttpPost]
        public string Array (List<string> names)
        {
            string fin = "";
            for (int i = 0; i < names.Count; i++)
            {
                fin += names[i] + ";  ";
            }
            return fin;
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            SelectList teams = new SelectList(dbUser.Teams, "Id", "Name");
            ViewBag.Teams = teams;

            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            dbUser.Users.Add(user); 
            dbUser.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUser(int? idUser)
        {
            if (idUser == null)
            {
                return HttpNotFound("statusDescription" + idUser.ToString()); //404
            }
            User user = dbUser.Users.Find(idUser);
            if (user != null)
            {
                SelectList teams = new SelectList(dbUser.Teams, "Id", "Name");
                ViewBag.Teams = teams;
                return View(user);
            }
            return RedirectToAction("Index");
        }

        //if write without [HttpGet] or [HttpPost] -> Default [HttpGet]
        public ActionResult DeleteUser(int? idUser) 
        {
            if (idUser == null)
            {
                return HttpNotFound();
            }
            User user = dbUser.Users.Find(idUser);
            if (user != null)
            {
                dbUser.Users.Remove(user);
                dbUser.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            dbUser.Entry(user).State = EntityState.Modified;
            dbUser.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Products product)
        {
            db.Products.Add(product); // INSERT (in SQL)
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Products product)
        {
            db.Products.Add(product); // INSERT (in SQL)
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    Products p = db.Products.Find(id);
        //    if (p != null)
        //    {
        //        db.Products.Remove(p); // DELETE (in SQL)
        //        db.SaveChanges();
        //    }

        //    // <p><img src="http://adressCurrentSite/Home/Delete/1" /></p>>

        //    //Products p = new Products { Id = id };
        //    //db.Entry(p).State = EntityState.Deleted;
        //    //db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete (int id)
        {
            Products p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Products p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditProduct (Products product)
        {
            db.Entry(product).State = EntityState.Modified; //UPDATE (in SQL)
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Products p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            db.Entry(product).State = EntityState.Modified; //UPDATE (in SQL)
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public string GetForm(string anyText)
        {
            return anyText;
        }*/

        [HttpPost]
        public string GetForm(string[] anyText)//Html.ListBox
        {
            string result = "";
            foreach(string c in anyText)
            {
                result += c;
                result += ";";
            }
            return "You select: "+ result;
        }

        /*[HttpPost]
        public string GetForm(bool anyTextBool)
        {
            return anyTextBool.ToString();
        }*/

        //asinc method IIS - пул потоков 2000-5000 (thread pool)
        public async Task<ActionResult> ProductsList()
        {
            IEnumerable<Products> products = await db.Products.ToListAsync();
            ViewBag.Products = products;
            return View("Index");
        }

        public ActionResult GetProduct(int id)
        {
            Products p = db.Products.Find(id);
            if (p == null)
                return HttpNotFound();
            return View(p);
        }

        public string GetData()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            object sessionName = Session["name"];
            return "Cookies ID is: " + id.ToString() + ", Session name is: " + sessionName.ToString(); 
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/1912_131$Solmyr.jpg";
            return new ImageResult(path);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        { 
            ViewBag.ProductsId = id;
            Purchase purchase = new Purchase { ProductId = (int)id, Person = "Unknown" };
            return View(purchase);
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // paste info about purchase to DB 
            db.Purchases.Add(purchase);
            // Resave DB all moves
            db.SaveChanges();
            return "Thank you, " + purchase.Person + ", for your purchase!";
        }

        public void GetContext()
        {
            HttpContext.Response.Write("Trying to use HttpContext.Response.Write");
            string browser = HttpContext.Request.Browser.Browser;
            string userAgent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            HttpContext.Response.Write("<p>Browser: " + browser + "</p><p>User-Agent: " + userAgent +
                "</p><p>Url request: " + url + "</p><p>Referrer: " + referrer + "</p><p>IP-adress: " +
                ip + "</p>"); 
        }

        public FilePathResult GetFile()
        {
            //Way (path) to File
            string filePath = Server.MapPath("~/Files/7.jpg");
            // Type file - content-type
            string fileType = "application/jpg";
            //Name of file - NOT mustHave 
            string fileName = "7.jpg";
            return File(filePath, fileType, fileName);
        }

        public FileContentResult GetBytes()
        {
            string path = Server.MapPath("~/Files/7.jpg");
            byte[] mass = System.IO.File.ReadAllBytes(path);
            string fileType = "application/octet-stream"; // any Other type
            string fileName = "7.jpg";
            return File(mass, fileType, fileName);
        }

        public FileStreamResult GetStream()
        {
            string path = Server.MapPath("~/Files/7.jpg");
            //Object Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string fileType = "application/jpg";
            string fileName = "7.jpg";
            return File(fs, fileType, fileName);
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

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Worked method GetHtml() and return object HtmlResult</h2>");
        }

        public string GetId(int id)
        {
            return id.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}