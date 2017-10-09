using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Boss { get; set; }

        public ICollection<User> Users { get; set; }

        public Team()
        {
            Users = new List<User>();
        }
    }
}