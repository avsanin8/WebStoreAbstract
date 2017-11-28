using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeStoreAbstract.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new ProductModel { Name = "TV 2000 3D", Author = "Леонид Данилович", Price = 1350.40m, Description = "asdasdas654s1df651dg", Category= "Сategory 1" });
            db.Products.Add(new ProductModel { Name = "Чайник електро-FullHD", Author = "Светлана", Price = 180.90m, Description = "asdgsdfg65++651dasdasdg", Category = "Сategory 1" });
            db.Products.Add(new ProductModel { Name = "ВАЗ-21093", Author = "Зигмунд 3", Price = 2400.00m, Description = "asdasds353465sdfsdf", Category = "Сategory 2" });

            base.Seed(db);
        }
    }
}