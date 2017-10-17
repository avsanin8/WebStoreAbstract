using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnnotations.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
    }

    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }
        // имя и фамилия покупателя
        public string Person { get; set; }
        // адрес покупателя
        public string Address { get; set; }
        // ID покупки
        public int ProductId { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }
}