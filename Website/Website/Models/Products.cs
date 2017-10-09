using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Products
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public int Price { get; set; }

    }
}