using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Paging.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
    }

    public class MobileDbInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone { Model = "Nokia 3G", Produser = "Nokia" });
            db.Phones.Add(new Phone { Model = "Smart L", Produser = "Tesla" });
            db.Phones.Add(new Phone { Model = "Samsung Ace", Produser = "Samsung" });
            db.Phones.Add(new Phone { Model = "Huawei Ypro", Produser = "Huawei" });
            db.Phones.Add(new Phone { Model = "Optimus", Produser = "Prime" });
            db.Phones.Add(new Phone { Model = "Siroko LG", Produser = "LG" });
            db.Phones.Add(new Phone { Model = "Homosap PQ", Produser = "Sony" });
            db.Phones.Add(new Phone { Model = "Himera 8S", Produser = "Borcon" });
            db.Phones.Add(new Phone { Model = "KambojaSun", Produser = "SunIndustry" });
            db.Phones.Add(new Phone { Model = "Kirpidon Sens", Produser = "Architecs Royal" });
            db.SaveChanges();
        }
    }
}
