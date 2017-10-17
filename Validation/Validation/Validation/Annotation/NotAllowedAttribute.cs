using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validation.Models;

namespace Validation.Annotation
{
    public class NotAllowedAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            Product product = value as Product;
            if (product.Manufacture == "Guness" && product.Year > 1910)
            {                
                return false;
            }
            return true;
        }
                 
    }
}