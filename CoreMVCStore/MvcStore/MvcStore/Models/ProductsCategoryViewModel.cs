using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStore.Models
{
    public class ProductsCategoryViewModel
    {
        public List<Product> products;
        public SelectList categoryes;
        public string ProductCategory { get; set; }
    }
}
