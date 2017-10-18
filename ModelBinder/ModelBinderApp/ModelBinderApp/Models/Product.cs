using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ModelBinderApp.Binders;

namespace ModelBinderApp.Models
{
    //[Bind(Exclude = "Year")]
    //[ModelBinder(typeof(ProductModelBinder))] // альтернатива привязчику без регистрации в Global.asax
    public class Product
    {
        [ScaffoldColumn(false)] // в представлении поле для свойства Id не создается
        public int Id { get; set; }

        [Required(ErrorMessage = "Field must not be empty")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Manfacture { get; set; }

        [Display(Name = "Name")]
        public int Year { get; set; }
    }
}