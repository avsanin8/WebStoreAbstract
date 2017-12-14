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
        //[RegularExpression(@"^[a-zA-Z] [a-zA-Z0-9-_\.]{1,20}$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        public decimal Price { get; set; }
        //[RegularExpression(@" ^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(40)]
        [Required]
        public string Category { get; set; }
        //[RegularExpression(@"^[a-zA-Z] [a-zA-Z0-9-_\.]$")]
        [StringLength(250)]
        [Required]
        public string Description { get; set; }

        public string UrlPicture { get; set; }
    }
}
