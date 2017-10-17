using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Annotation
{
    public class ValidManufactureAttribute : ValidationAttribute
    {
        private string[] myManufacturers;

        public ValidManufactureAttribute(string [] manufacturers)
        {
            myManufacturers = manufacturers;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < myManufacturers.Length; i++)
                {
                    if (strval == myManufacturers[i])
                        return true;
                }
            }
            return false;
        }
    }
}