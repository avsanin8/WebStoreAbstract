using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinderApp.Models;

namespace ModelBinderApp.Binders
{
    public class ProductModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Получаем поставщик значений
            var valueProvider = bindingContext.ValueProvider;

            ValueProviderResult vprId = valueProvider.GetValue("Id");

            string name = (string)valueProvider.GetValue("Name").ConvertTo(typeof(string));
            string manfacture = (string)valueProvider.GetValue("Manfacture").ConvertTo(typeof(string));
            int year = (int)valueProvider.GetValue("Year").ConvertTo(typeof(int));

            Product product = new Product() { Name = name + " (new)", Manfacture = manfacture, Year = year };

            //если поле Id определено (редактирование)
            if(vprId!=null)
            {
                product.Name = name; // без new
                product.Id = (int)vprId.ConvertTo(typeof(int));
            }

            return product;
        }
    }
}