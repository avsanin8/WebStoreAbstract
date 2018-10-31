using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        public decimal Price { get; set; }
        
        [StringLength(40)]
        [Required]
        public string Category { get; set; }
        
        [StringLength(400)]
        [Required]
        public string Description { get; set; }

        public string UrlPicture { get; set; }
    }
}
