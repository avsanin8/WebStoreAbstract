using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using Moq;
using WebUI.Controllers;
using WebUI.Models;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Организация (arrange)
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<ProductModel>
            {
                new ProductModel{Id = 1, Name = "Product 1"},
                new ProductModel{Id = 2, Name = "Product 2"},
                new ProductModel{Id = 3, Name = "Product 3"},
                new ProductModel{Id = 4, Name = "Product 4"},
                new ProductModel{Id = 5, Name = "Product 5"},
                new ProductModel{Id = 6, Name = "Product 6"},
                new ProductModel{Id = 7, Name = "Product 7"},
                new ProductModel{Id = 8, Name = "Product 8"},
                new ProductModel{Id = 9, Name = "Product 9"},
                new ProductModel{Id = 10, Name = "Product 10"},
                new ProductModel{Id = 11, Name = "Product 11"}
            });

            ProductsController controller = new ProductsController(mock.Object)
            {
                pageSize = 3
            };

            //чтобы получить последовательность для второй страницы...
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
            //для этого сначала необходимо преобразовать полученную 
            //полседовательность в колекцию с помощью LINQ-метода ToList()
            List<ProductModel> products = result.Products.ToList();

            //проверяем кол-во элементов на второй странице и значения отдельных объектов
            Assert.IsTrue(products.Count() == 3);
            Assert.AreEqual(products[0].Name, "Product 4");
            Assert.AreEqual(products[1].Name, "Product 5");

        }
    }
}
