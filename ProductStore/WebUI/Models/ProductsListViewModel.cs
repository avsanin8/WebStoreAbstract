﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentСategory { get; set; }
    }
}