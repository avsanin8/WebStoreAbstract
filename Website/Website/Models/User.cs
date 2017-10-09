using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public int? TeamId { get; set; } // ? because maybe NULL
        public Team Team { get; set; }
    }
}