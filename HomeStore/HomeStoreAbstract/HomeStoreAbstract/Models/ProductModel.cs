using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeStoreAbstract.Models
{
    public class ProductModel
    {
        // ID Product
        public int Id { get; set; }
        // название Product
        public string Name { get; set; }
        // автор Product
        public string Author { get; set; }
        // цена
        public decimal Price { get; set; }
        // категория
        public string Сategory { get; set; }
        // описание продукта
        public string Description { get; set; }
    }
}