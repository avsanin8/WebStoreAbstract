using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MvcStore.Models
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
    }
}
