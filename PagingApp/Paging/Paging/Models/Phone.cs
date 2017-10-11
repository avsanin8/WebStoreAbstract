using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paging.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Produser { get; set; }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } // count obj in page
        public int TotalItems { get; set; } // summ all objects in page
        public int TotalPages            // summ all pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }   
    }

    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}