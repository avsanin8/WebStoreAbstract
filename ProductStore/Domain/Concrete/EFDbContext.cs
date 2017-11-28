using Domain.Entities;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Concrete
{
    //[Table ("ProductModels")] 
    public class EFDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        //public DbSet<Purchase> Purchases { get; set; }
    }
}
