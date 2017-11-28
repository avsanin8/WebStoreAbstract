using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeStoreAbstract.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}