using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Validation.Models
{
    public class ProductContext : DbContext
    {

        public DbSet<Product> Products { get; set; }        
    }


    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "AutoGun", Manufacture = "Guness", Price = 1236, Year = 1996 });
            db.Products.Add(new Product { Name = "Lopata", Manufacture = "Libicore", Price = 50, Year = 1945 });
            db.Products.Add(new Product { Name = "Milk", Manufacture = "Crowns", Price = 15, Year = 2017 });
            
            base.Seed(db);
        }
    }

}