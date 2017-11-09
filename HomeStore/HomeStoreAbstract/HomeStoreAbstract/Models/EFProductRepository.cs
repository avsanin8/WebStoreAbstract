using HomeStoreAbstract.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeStoreAbstract.Models
{
    public class EFProductRepository : IProductRepository
    {
        ProductContext context = new ProductContext();
        public IEnumerable<ProductModel> Products
        {
            get { return context.Products; }
        }
    }
}