using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class ProductContext:ApplicationDbContext
    {

        public DbSet<Products> Products { get; set; }
        
        public DbSet<Purchase> Purchases { get; set; }
    }

    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Products { Name = "Banan", Manufacture = "Palma", Price = 19, Id = 0 });
            db.Products.Add(new Products { Name = "3D-00-Glasses v1.9", Manufacture = "Architect Games", Price = 69, Id = 1 });
            db.Products.Add(new Products { Name = "Model XXX", Manufacture = "Tesla", Price = 99000, Id = 2 });
            base.Seed(db);
        }
    }
}