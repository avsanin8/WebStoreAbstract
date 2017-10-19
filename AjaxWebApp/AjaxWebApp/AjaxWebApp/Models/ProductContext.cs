using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AjaxWebApp.Models
{
    public class ProductContext : DbContext //using System.Data.Entity for use Db
    {
        public DbSet<Product> Products { get; set; } // create object with fields Products
    }

    public class ProductDbInializer : DropCreateDatabaseAlways<ProductContext> // procedure Create some Db initializer
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "KrossX9", Manufacture = "ArchiCompany" });
            db.Products.Add(new Product { Name = "SpunterK8", Manufacture = "SolarTeh" });
            db.Products.Add(new Product { Name = "Apple", Manufacture = "GreenLand" });
            db.Products.Add(new Product { Name = "Phone K16", Manufacture = "Microsoft" });
            db.Products.Add(new Product { Name = "Solar panel 7Kw", Manufacture = "SolarTeh" });
            db.Products.Add(new Product { Name = "Termobar U8", Manufacture = "GreenLand" });
            db.Products.Add(new Product { Name = "Pindol Y6", Manufacture = "ArchiCompany" });
            base.Seed(db);
        }
    }
}