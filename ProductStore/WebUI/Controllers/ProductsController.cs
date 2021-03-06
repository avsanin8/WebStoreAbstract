﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 3;
        public ProductsController(IProductRepository repos)
        {
            repository = repos;
        }

        public ViewResult List(string categ, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => categ == null || p.Category == categ)
                .OrderBy(product => product.Id)   //упорядовачивание по первичному ключу
                .Skip((page - 1) * pageSize)    // пропускаем товары которые располагаются до начала текущей страницы 
                .Take(pageSize),                // выбираем какое кол-во товаров взять
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = categ == null ?
                        repository.Products.Count() : 
                        repository.Products.Where(product => product.Category == categ).Count()                        
                },
                CurrentCategory = categ
            };

            return View(model);
        }
    }
}