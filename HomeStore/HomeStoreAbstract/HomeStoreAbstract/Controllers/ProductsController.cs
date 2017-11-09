using HomeStoreAbstract.Models;
using HomeStoreAbstract.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStoreAbstract.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 3;
        public ProductsController (IProductRepository repos)
        {
            repository = repos;
        }

        public ViewResult List(string categ, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => categ == null || p.Сategory == categ)
                .OrderBy(product => product.Id) //упорядовачивание по первичному ключу
                .Skip((page - 1) * pageSize)     // пропускаем товары которые располагаются до начала текущей страницы 
                .Take(pageSize),           // выбираем какое кол-во товаров взять
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentСategory = categ
        };

            return View(model);
        }
    }
}